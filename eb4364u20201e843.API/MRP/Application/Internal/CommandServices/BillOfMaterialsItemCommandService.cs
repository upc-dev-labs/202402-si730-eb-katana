using eb4364u20201e843.API.MRP.Application.Internal.OutboundServices.ACL;
using eb4364u20201e843.API.MRP.Domain.Model.Aggregates;
using eb4364u20201e843.API.MRP.Domain.Model.Commands;
using eb4364u20201e843.API.MRP.Domain.Model.ValueObjects;
using eb4364u20201e843.API.MRP.Domain.Repositories;
using eb4364u20201e843.API.MRP.Domain.Services;
using eb4364u20201e843.API.Shared.Domain.Repositories;

namespace eb4364u20201e843.API.MRP.Application.Internal.CommandServices;

/// <summary>
///     Command service implementation for handling the creation of BillOfMaterialsItem aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class BillOfMaterialsItemCommandService(
    IBillOfMaterialsItemRepository billOfMaterialsItemRepository,
    IUnitOfWork unitOfWork,
    ExternalScmService externalScmService
    ) : IBillOfMaterialsItemCommandService
{
    /// <summary>
    ///     Handles the creation of a new BillOfMaterialsItem, including validation and persistence.
    /// </summary>
    /// <param name="command">The command containing the item data.</param>
    /// <returns>The created BillOfMaterialsItem aggregate.</returns>
    public async Task<BillOfMaterialsItem?> Handle(CreateBillOfMaterialsItemCommand command)
    {
        // if (!Guid.TryParse(command.ItemPartNumber, out _))
        //     throw new Exception($"Invalid ItemPartNumber format: {command.ItemPartNumber}.");

        var itemPartNumber = ItemPartNumber.FromString(command.ItemPartNumber);
        if (itemPartNumber is null)
            throw new Exception($"Invalid ItemPartNumber format: {command.ItemPartNumber}.");

        if (!await externalScmService.ExistsPartByPartNumberAsync(command.ItemPartNumber))
            throw new Exception($"Part with part number {command.ItemPartNumber} not found.");

        if (await billOfMaterialsItemRepository.ExistsByItemPartNumberAndBatchIdAndBillOfMaterialsIdAsync(
                new ItemPartNumber(command.ItemPartNumber), command.BatchId, command.BillOfMaterialsId))
            throw new Exception(
                $"Bill of materials item with item part number {command.ItemPartNumber}, " +
                $"batch ID {command.BatchId} and bill of materials ID {command.BillOfMaterialsId} " +
                $"already exists.");

        if (command.RequiredAt > DateTime.Now)
            throw new Exception("Required at date cannot be in the future.");

        if (command.ScheduledStartAt < command.RequiredAt.AddDays(30))
            throw new Exception("Scheduled start at must be at least 30 days greater than required at date.");

        var isCapacityAvailable = await externalScmService.ReserveCapacityAsync(command.ItemPartNumber, command.RequiredQuantity);
        if (isCapacityAvailable is false)
            throw new Exception($"Insufficient capacity for part number {command.ItemPartNumber}. Cannot reserve {command.RequiredQuantity} units.");

        var billOfMaterialsItem = new BillOfMaterialsItem(command);

        try
        {
            await billOfMaterialsItemRepository.AddAsync(billOfMaterialsItem);
            await unitOfWork.CompleteAsync();
            return billOfMaterialsItem;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occured while creating a new bill of materials item: {ex.Message}");
        }
    }
}
using eb4364u20201e843.API.MRP.Domain.Model.Commands;
using eb4364u20201e843.API.MRP.Domain.Model.ValueObjects;

namespace eb4364u20201e843.API.MRP.Domain.Model.Aggregates;

/// <summary>
///     Aggregate root representing a Bill Of Materials Item in the MRP context.
/// </summary>
/// /// <remarks>
///     Author: Author
/// </remarks>
public partial class BillOfMaterialsItem
{
    public int Id { get; }

    public int BillOfMaterialsId { get; private set; }

    public ItemPartNumber ItemPartNumber { get; private set; }

    public int BatchId { get; private set; }

    public int RequiredQuantity  { get; private set; }

    public DateTime ScheduledStartAt { get; private set; }

    public DateTime RequiredAt { get; private set; }

    /// <summary>
    ///     Parameterless constructor required by EF Core.
    /// </summary>
    public BillOfMaterialsItem()
    {
        ItemPartNumber = new ItemPartNumber();
    }

    /// <summary>
    ///     Creates a new BillOfMaterialsItem using the provided command data.
    /// </summary>
    /// <param name="command">The command containing the item data.</param>
    public BillOfMaterialsItem(CreateBillOfMaterialsItemCommand command)
    {
        BillOfMaterialsId = command.BillOfMaterialsId;
        ItemPartNumber = new ItemPartNumber(command.ItemPartNumber);
        BatchId = command.BatchId;
        RequiredQuantity = command.RequiredQuantity;
        ScheduledStartAt = command.ScheduledStartAt;
        RequiredAt = command.RequiredAt;
    }
}
using eb4364u20201e843.API.SCM.Domain.Model.Aggregates;
using eb4364u20201e843.API.SCM.Domain.Model.Commands;
using eb4364u20201e843.API.SCM.Domain.Repositories;
using eb4364u20201e843.API.SCM.Domain.Services;
using eb4364u20201e843.API.SCM.Infrastructure.Configuration;
using eb4364u20201e843.API.Shared.Domain.Repositories;
using Microsoft.Extensions.Options;

namespace eb4364u20201e843.API.SCM.Application.Internal.CommandServices;

/// <summary>
///     Service implementation for handling commands related to Part aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class PartCommandService(
    IPartRepository partRepository,
    IUnitOfWork unitOfWork,
    IConfiguration configuration,
    IOptions<CapacityThresholdsOptions> capacityOptions
    ) : IPartCommandService
{
    private readonly CapacityThresholdsOptions _thresholds = capacityOptions.Value;

    /// <summary>
    ///     Handles the creation of a new Part aggregate, including validation of business rules.
    /// </summary>
    /// <param name="command">The command containing the Part data.</param>
    /// <returns>The created Part aggregate.</returns>
    /// <exception cref="Exception">Thrown when validation fails or persistence encounters an error.</exception>
    public async Task<Part?> Handle(CreatePartCommand command)
    {
        // if (command.MaxProductionQuantity < _thresholds.MinCapacityThreshold
        //     || command.MaxProductionQuantity > _thresholds.MaxCapacityThreshold)
        // {
        //     throw new ArgumentException(
        //         $"MaxProductionQuantity must be between {_thresholds.MinCapacityThreshold} and {_thresholds.MaxCapacityThreshold}.");
        // }

        var minCapacityThreshold = configuration.GetValue<int>("CapacityThresholds:minCapacityThreshold");
        var maxCapacityThreshold = configuration.GetValue<int>("CapacityThresholds:maxCapacityThreshold");

        if (command.MaxProductionCapacity < minCapacityThreshold || command.MaxProductionCapacity > maxCapacityThreshold)
            throw new Exception($"Max production quantity must be between {minCapacityThreshold} and {maxCapacityThreshold}.");

        var part = new Part(command);

        var alreadyExists = await partRepository.ExistsByPartNumberAsync(part.PartNumber);
        if (alreadyExists)
            throw new Exception($"Part with part number {part.PartNumber.Identifier} already exists.");

        if (part.Name.Length is <= 0 or > 60)
            throw new Exception("Part name must be between 1 and 60 characters.");

        try
        {
            await partRepository.AddAsync(part);
            await unitOfWork.CompleteAsync();
            return part;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occured while creating a new part: {ex.Message}");
        }
    }
}
using eb4364u20201e843.API.SCM.Domain.Model.Commands;
using eb4364u20201e843.API.SCM.Domain.Model.ValueObjects;

namespace eb4364u20201e843.API.SCM.Domain.Model.Aggregates;

/// <summary>
///     Aggregate root representing a Part in Katana Manufacturing.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public partial class Part
{
    public int Id { get; }

    public PartNumber PartNumber { get; private set; } = new();

    public string Name { get; private set; }

    public EPartType PartType { get; private set; }

    public int CurrentProductionQuantity { get; private set; }

    public int MaxProductionQuantity { get; private set; }

    /// <summary>
    ///     Protected parameterless constructor required by Entity Framework Core.
    /// </summary>
    protected Part()
    {
        PartNumber = new PartNumber();
        Name = string.Empty;
        CurrentProductionQuantity = 0;
        MaxProductionQuantity = 0;
    }

    /// <summary>
    ///     Creates a new Part instance using the provided command data.
    /// </summary>
    /// <param name="command">Command containing the data to create the Part.</param>
    public Part(CreatePartCommand command)
    {
        Name = command.Name;
        PartType = FromAbbreviation(command.PartType);
        CurrentProductionQuantity = 0;
        MaxProductionQuantity = command.MaxProductionQuantity;
    }

    /// <summary>
    ///     Maps the request abbreviation to the corresponding PartType enum.
    /// </summary>
    /// <param name="abbreviation">Abbreviation like "BTP".</param>
    /// <returns>EPartType enum value.</returns>
    /// <exception cref="ArgumentException">Thrown if the abbreviation is invalid.</exception>
    private static EPartType FromAbbreviation(string abbreviation)
    {
        return abbreviation switch
        {
            "BTP" => EPartType.BuildToPrint,
            "BTS" => EPartType.BuildToSpecification,
            "MTS" => EPartType.MadeToStock,
            "MTO" => EPartType.MadeToOrder,
            "MTA" => EPartType.MadeToAssemble,
            _ => throw new ArgumentException($"Invalid part type abbreviation: {abbreviation}")
        };
    }
}
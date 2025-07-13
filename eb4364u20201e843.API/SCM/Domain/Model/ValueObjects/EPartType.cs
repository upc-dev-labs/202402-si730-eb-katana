namespace eb4364u20201e843.API.SCM.Domain.Model.ValueObjects;

/// <summary>
///     Enumeration representing the PartType supported by Katana.
///     Defines the operation mode for parts in the manufacturing process.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public enum EPartType
{
    BuildToPrint = 0,
    BuildToSpecification = 1,
    MadeToStock = 2,
    MadeToOrder = 3,
    MadeToAssemble = 4
}
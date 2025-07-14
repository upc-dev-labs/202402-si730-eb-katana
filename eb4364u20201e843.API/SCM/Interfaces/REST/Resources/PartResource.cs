namespace eb4364u20201e843.API.SCM.Interfaces.REST.Resources;

/// <summary>
///     Resource representing Part data returned via REST.
/// </summary>
/// <param name="Id">Database identifier.</param>
/// <param name="PartNumber">Business identifier (UUID).</param>
/// <param name="Name">The name of the Part.</param>
/// <param name="PartType">The type of the Part.</param>
/// <param name="CurrentProductionQuantity">Current production quantity.</param>
/// <param name="MaxProductionCapacity">Maximum production capacity.</param>
/// <remarks>
///     Author: Author
/// </remarks>
public record PartResource(
    int Id,
    string PartNumber,
    string Name,
    string PartType,
    int CurrentProductionQuantity,
    int MaxProductionCapacity
);
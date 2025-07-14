namespace eb4364u20201e843.API.SCM.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating a new Part via REST.
/// </summary>
/// <param name="Name">The name of the Part.</param>
/// <param name="PartType">The type of the Part.</param>
/// <param name="MaxProductionCapacity">The maximum production capacity.</param>
/// <remarks>
///     Author: Author
/// </remarks>
public record CreatePartResource(
    string Name,
    string PartType,
    int MaxProductionCapacity
);
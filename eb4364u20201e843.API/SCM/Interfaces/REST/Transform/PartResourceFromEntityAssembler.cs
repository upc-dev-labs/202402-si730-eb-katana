using eb4364u20201e843.API.SCM.Domain.Model.Aggregates;
using eb4364u20201e843.API.SCM.Interfaces.REST.Resources;

namespace eb4364u20201e843.API.SCM.Interfaces.REST.Transform;

/// <summary>
///     Assembler for converting Part aggregate roots into REST PartResource objects.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class PartResourceFromEntityAssembler
{
    /// <summary>
    ///     Converts a Part domain entity into a PartResource for REST responses.
    /// </summary>
    /// <param name="entity">The Part aggregate root from the domain layer.</param>
    /// <returns>The corresponding PartResource for REST.</returns>
    public static PartResource ToResourceFromEntity(Part entity)
    {
        return new PartResource(
            entity.Id,
            entity.PartNumber.Identifier.ToString(),
            entity.Name,
            entity.PartType.ToString(),
            entity.CurrentProductionQuantity,
            entity.MaxProductionCapacity
        );
    }
}
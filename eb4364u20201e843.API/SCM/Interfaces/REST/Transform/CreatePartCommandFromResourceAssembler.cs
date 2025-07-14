using eb4364u20201e843.API.SCM.Domain.Model.Commands;
using eb4364u20201e843.API.SCM.Interfaces.REST.Resources;

namespace eb4364u20201e843.API.SCM.Interfaces.REST.Transform;

/// <summary>
///     Assembler for converting REST CreatePartResource objects into CreatePartCommand objects.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class CreatePartCommandFromResourceAssembler
{
    /// <summary>
    ///     Converts a CreatePartResource into a CreatePartCommand for application layer processing.
    /// </summary>
    /// <param name="resource">The CreatePartResource received via REST.</param>
    /// <returns>The corresponding CreatePartCommand.</returns>
    public static CreatePartCommand ToCommandFromResource(CreatePartResource resource)
    {
        return new CreatePartCommand(
            resource.Name,
            resource.PartType,
            resource.MaxProductionCapacity
        );
    }
}
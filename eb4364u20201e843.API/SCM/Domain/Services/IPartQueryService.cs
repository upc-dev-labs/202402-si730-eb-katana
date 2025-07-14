using eb4364u20201e843.API.SCM.Domain.Model.Aggregates;
using eb4364u20201e843.API.SCM.Domain.Model.Queries;

namespace eb4364u20201e843.API.SCM.Domain.Services;

/// <summary>
///     Service interface for handling queries related to Part aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public interface IPartQueryService
{
    /// <summary>
    ///     Handles the retrieval of a Part aggregate by its ID.
    /// </summary>
    /// <param name="query">The query containing the Part ID.</param>
    /// <returns>The Part aggregate if found, or null.</returns>
    Task<Part?> Handle(GetPartByIdQuery query);
}
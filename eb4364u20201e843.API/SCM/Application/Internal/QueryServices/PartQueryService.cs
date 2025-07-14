using eb4364u20201e843.API.SCM.Domain.Model.Aggregates;
using eb4364u20201e843.API.SCM.Domain.Model.Queries;
using eb4364u20201e843.API.SCM.Domain.Repositories;
using eb4364u20201e843.API.SCM.Domain.Services;

namespace eb4364u20201e843.API.SCM.Application.Internal.QueryServices;

/// <summary>
///     Service implementation for handling queries related to Part aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class PartQueryService(IPartRepository partRepository) : IPartQueryService
{
    /// <inheritdoc />
    public async Task<Part?> Handle(GetPartByIdQuery query)
    {
        return await partRepository.FindByIdAsync(query.PartId);
    }
}
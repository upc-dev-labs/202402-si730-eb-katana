using eb4364u20201e843.API.SCM.Domain.Model.Aggregates;
using eb4364u20201e843.API.SCM.Domain.Model.ValueObjects;
using eb4364u20201e843.API.Shared.Domain.Repositories;

namespace eb4364u20201e843.API.SCM.Domain.Repositories;

/// <summary>
///     Repository interface for managing Part aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public interface IPartRepository : IBaseRepository<Part>
{
    /// <summary>
    ///     Finds a Part by its PartNumber.
    /// </summary>
    /// <param name="partNumber">The PartNumber to search for.</param>
    /// <returns>The Part if found, or null.</returns>
    Task<Part?> FindByPartNumberAsync(PartNumber partNumber);

    /// <summary>
    ///     Checks if a Part exists with the given PartNumber.
    /// </summary>
    /// <param name="partNumber">The PartNumber to check.</param>
    /// <returns>True if exists, false otherwise.</returns>
    Task<bool> ExistsByPartNumberAsync(PartNumber partNumber);
}
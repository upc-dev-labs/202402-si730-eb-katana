using eb4364u20201e843.API.SCM.Domain.Model.Aggregates;
using eb4364u20201e843.API.SCM.Domain.Model.ValueObjects;
using eb4364u20201e843.API.SCM.Domain.Repositories;
using eb4364u20201e843.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4364u20201e843.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eb4364u20201e843.API.SCM.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository implementation for Part aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class PartRepository(AppDbContext context) : BaseRepository<Part>(context), IPartRepository
{
    /// <inheritdoc />
    public async Task<Part?> FindByPartNumberAsync(PartNumber partNumber)
    {
        return await Context.Set<Part>()
            .Include(p => p.PartNumber)
            .FirstOrDefaultAsync(p => p.PartNumber == partNumber);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsByPartNumberAsync(PartNumber partNumber)
    {
        return await Context.Set<Part>()
            .AnyAsync(p => p.PartNumber == partNumber);
    }
}
using eb4364u20201e843.API.SCM.Domain.Model.ValueObjects;
using eb4364u20201e843.API.SCM.Domain.Repositories;
using eb4364u20201e843.API.SCM.Interfaces.ACL;
using eb4364u20201e843.API.Shared.Domain.Repositories;

namespace eb4364u20201e843.API.SCM.Application.ACL;

/// <summary>
///     Implementation of the ACL for accessing SCM context data.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class ScmContextFacade(
    IPartRepository partRepository,
    IUnitOfWork unitOfWork
    ) : IScmContextFacade
{
    /// <inheritdoc />
    public async Task<bool> ExistsByPartNumberAsync(string partNumber)
    {
        return await partRepository.ExistsByPartNumberAsync(new PartNumber(Guid.Parse(partNumber)));
    }

    /// <inheritdoc />
    public async Task<bool> ReserveCapacityAsync(string partNumber, int requiredQuantity)
    {
        var part = await partRepository.FindByPartNumberAsync(new PartNumber(Guid.Parse(partNumber)));
        if (part is null) throw new Exception($"Part with part number {partNumber} not found.");

        var reserved = part.TryReserveCapacity(requiredQuantity);

        if (!reserved) return false;

        partRepository.Update(part);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
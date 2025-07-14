using eb4364u20201e843.API.SCM.Interfaces.ACL;

namespace eb4364u20201e843.API.MRP.Application.Internal.OutboundServices.ACL;

/// <summary>
///     Outbound service for interacting with the SCM context via ACL.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class ExternalScmService(IScmContextFacade scmContextFacade)
{
    /// <summary>
    ///     Checks if a Part exists in the SCM context by its PartNumber.
    /// </summary>
    /// <param name="partNumber">The PartNumber as a string.</param>
    /// <returns>True if the Part exists; otherwise false.</returns>
    public async Task<bool> ExistsPartByPartNumberAsync(string partNumber)
    {
        return await scmContextFacade.ExistsByPartNumberAsync(partNumber);
    }

    /// <summary>
    ///     Attempts to reserve production capacity for a Part in the SCM context.
    /// </summary>
    /// <param name="partNumber">The PartNumber as a string.</param>
    /// <param name="requiredQuantity">The quantity to reserve.</param>
    /// <returns>True if the reservation succeeds; otherwise false.</returns>
    public async Task<bool> ReserveCapacityAsync(string partNumber, int requiredQuantity)
    {
        return await scmContextFacade.ReserveCapacityAsync(partNumber, requiredQuantity);
    }
}
namespace eb4364u20201e843.API.SCM.Interfaces.ACL;

/// <summary>
///     Defines the contract for accessing SCM context data from other bounded contexts.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public interface IScmContextFacade
{
    /// <summary>
    ///     Checks if a Part with the given PartNumber exists in the SCM context.
    /// </summary>
    /// <param name="partNumber">The PartNumber as a string.</param>
    /// <returns>True if the Part exists, false otherwise.</returns>
    Task<bool> ExistsByPartNumberAsync(string partNumber);

    /// <summary>
    ///     Checks if there is enough available production capacity for the given PartNumber and quantity.
    /// </summary>
    /// <param name="partNumber">The PartNumber as a string.</param>
    /// <param name="requiredQuantity">The quantity required.</param>
    /// <returns>True if enough capacity is available, false otherwise.</returns>
    Task<bool> ReserveCapacityAsync(string partNumber, int requiredQuantity);
}
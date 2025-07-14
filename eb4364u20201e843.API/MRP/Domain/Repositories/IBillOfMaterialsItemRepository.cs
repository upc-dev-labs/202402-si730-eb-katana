using eb4364u20201e843.API.MRP.Domain.Model.Aggregates;
using eb4364u20201e843.API.MRP.Domain.Model.ValueObjects;
using eb4364u20201e843.API.Shared.Domain.Repositories;

namespace eb4364u20201e843.API.MRP.Domain.Repositories;

/// <summary>
///     Repository interface for managing BillOfMaterialsItem aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public interface IBillOfMaterialsItemRepository : IBaseRepository<BillOfMaterialsItem>
{
    /// <summary>
    ///     Checks if a BillOfMaterialsItem exists with the specified ItemPartNumber, BatchId and BillOfMaterialsId combination.
    /// </summary>
    /// <param name="itemPartNumber">The ItemPartNumber value object.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="billOfMaterialsId">The Bill of Materials identifier.</param>
    /// <returns>True if such an item exists; otherwise false.</returns>
    Task<bool> ExistsByItemPartNumberAndBatchIdAndBillOfMaterialsIdAsync(
        ItemPartNumber itemPartNumber, int batchId, int billOfMaterialsId);
}
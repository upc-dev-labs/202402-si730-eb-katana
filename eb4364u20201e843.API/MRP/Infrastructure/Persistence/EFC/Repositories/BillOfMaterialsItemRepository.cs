using eb4364u20201e843.API.MRP.Domain.Model.Aggregates;
using eb4364u20201e843.API.MRP.Domain.Model.ValueObjects;
using eb4364u20201e843.API.MRP.Domain.Repositories;
using eb4364u20201e843.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4364u20201e843.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eb4364u20201e843.API.MRP.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository implementation for BillOfMaterialsItem aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class BillOfMaterialsItemRepository(AppDbContext context)
    : BaseRepository<BillOfMaterialsItem>(context), IBillOfMaterialsItemRepository
{
    /// <inheritdoc />
    public async Task<bool> ExistsByItemPartNumberAndBatchIdAndBillOfMaterialsIdAsync(
        ItemPartNumber itemPartNumber, int batchId, int billOfMaterialsId)
    {
        return await Context.Set<BillOfMaterialsItem>()
            .AnyAsync(b =>
                b.ItemPartNumber == itemPartNumber &&
                b.BatchId == batchId &&
                b.BillOfMaterialsId == billOfMaterialsId);
    }
}
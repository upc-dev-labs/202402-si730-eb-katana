using eb4364u20201e843.API.MRP.Domain.Model.Aggregates;
using eb4364u20201e843.API.MRP.Interfaces.REST.Resources;

namespace eb4364u20201e843.API.MRP.Interfaces.REST.Transform;

/// <summary>
///     Assembler for converting domain BillOfMaterialsItem to REST resource.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class BillOfMaterialsItemResourceFromEntityAssembler
{
    public static BillOfMaterialsItemResource ToResourceFromEntity(BillOfMaterialsItem entity)
    {
        return new BillOfMaterialsItemResource(
            entity.Id,
            entity.BillOfMaterialsId,
            entity.ItemPartNumber.Identifier.ToString(),
            entity.BatchId,
            entity.RequiredQuantity,
            entity.ScheduledStartAt,
            entity.RequiredAt
        );
    }
}
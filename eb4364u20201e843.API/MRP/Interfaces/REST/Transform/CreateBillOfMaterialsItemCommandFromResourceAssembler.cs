using eb4364u20201e843.API.MRP.Domain.Model.Commands;
using eb4364u20201e843.API.MRP.Interfaces.REST.Resources;

namespace eb4364u20201e843.API.MRP.Interfaces.REST.Transform;

/// <summary>
///     Assembler for converting REST CreateBillOfMaterialsItemResource objects into CreateBillOfMaterialsItemCommand objects.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class CreateBillOfMaterialsItemCommandFromResourceAssembler
{
    public static CreateBillOfMaterialsItemCommand ToCommandFromResource(int billOfMaterialsId, CreateBillOfMaterialsItemResource resource)
    {
        return new CreateBillOfMaterialsItemCommand(
            billOfMaterialsId,
            resource.ItemPartNumber,
            resource.BatchId,
            resource.RequiredQuantity,
            resource.ScheduledStartAt,
            resource.RequiredAt
        );
    }
}
namespace eb4364u20201e843.API.MRP.Interfaces.REST.Resources;

/// <summary>
///     Resource representing a BillOfMaterialsItem for REST responses.
/// </summary>
/// <param name="Id">Database ID.</param>
/// <param name="BillOfMaterialsId">The ID of the associated Bill of Materials.</param>
/// <param name="ItemPartNumber">The PartNumber (UUID) as string.</param>
/// <param name="BatchId">Batch identifier.</param>
/// <param name="RequiredQuantity">Required quantity.</param>
/// <param name="ScheduledStartAt">Scheduled start date.</param>
/// <param name="RequiredAt">Required date.</param>
/// <remarks>
///     Author: Author
/// </remarks>
public record BillOfMaterialsItemResource(
    int Id,
    int BillOfMaterialsId,
    string ItemPartNumber,
    int BatchId,
    int RequiredQuantity,
    DateTime ScheduledStartAt,
    DateTime RequiredAt
);
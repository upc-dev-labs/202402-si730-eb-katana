namespace eb4364u20201e843.API.MRP.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating a new BillOfMaterialsItem via REST.
/// </summary>
/// <param name="ItemPartNumber">The PartNumber (UUID) as string.</param>
/// <param name="BatchId">Batch identifier.</param>
/// <param name="RequiredQuantity">Required quantity.</param>
/// <param name="ScheduledStartAt">Scheduled start date.</param>
/// <param name="RequiredAt">Required date.</param>
/// <remarks>
///     Author: Author
/// </remarks>
public record CreateBillOfMaterialsItemResource(
    string ItemPartNumber,
    int BatchId,
    int RequiredQuantity,
    DateTime ScheduledStartAt,
    DateTime RequiredAt
);
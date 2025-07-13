namespace eb4364u20201e843.API.MRP.Domain.Model.Commands;

public record CreateBillOfMaterialsItemCommand(
    int BillOfMaterialsId,
    string ItemPartNumber,
    int BatchId,
    int RequiredQuantity,
    DateTime ScheduledStartAt,
    DateTime RequiredAt
);
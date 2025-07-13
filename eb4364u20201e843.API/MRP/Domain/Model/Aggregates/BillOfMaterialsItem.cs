using eb4364u20201e843.API.MRP.Domain.Model.Commands;
using eb4364u20201e843.API.MRP.Domain.Model.ValueObjects;

namespace eb4364u20201e843.API.MRP.Domain.Model.Aggregates;

public partial class BillOfMaterialsItem
{
    public int Id { get; }

    public int BillOfMaterialsId { get; private set; }

    public ItemPartNumber ItemPartNumber { get; private set; }

    public int BatchId { get; private set; }

    public int RequiredQuantity  { get; private set; }

    public DateTime ScheduledStartAt { get; private set; }

    public DateTime RequiredAt { get; private set; }

    public BillOfMaterialsItem()
    {
        ItemPartNumber = new ItemPartNumber();
    }

    public BillOfMaterialsItem(CreateBillOfMaterialsItemCommand command)
    {
        BillOfMaterialsId = command.BillOfMaterialsId;
        ItemPartNumber = new ItemPartNumber(command.ItemPartNumber);
        BatchId = command.BatchId;
        RequiredQuantity = command.RequiredQuantity;
        ScheduledStartAt = command.ScheduledStartAt;
        RequiredAt = command.RequiredAt;
    }
}
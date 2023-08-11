namespace StockControlApi.Data.Entities;

public class StockElasticModel
{
    public long Id { get; set; }

    public long InventoryItemId { get; set; }
    
    public long LocationId { get; set; }

    public long WarehouseId { get; set; }
}
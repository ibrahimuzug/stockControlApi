using StockControlApi.Data.Entities;

namespace StockControlApi.Strategies.Interfaces;

public interface IDataSourceStrategy
{
    Task<List<Stock>> GetStocksByInventoryItemId(long id, long page, long pageSize,
        CancellationToken cancellationToken);
}
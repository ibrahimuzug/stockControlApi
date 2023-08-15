using StockControlApi.Data.Entities;

namespace StockControlApi.Service.Interface;

public interface IDataSourceService
{
    Task<List<Stock>> GetStocks(long id, long page, long pageSize, CancellationToken cancellationToken);
}
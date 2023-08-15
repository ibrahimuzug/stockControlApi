using StockControlApi.Data.Entities;
using StockControlApi.Factories.Interfaces;
using StockControlApi.Service.Interface;

namespace StockControlApi.Service;

public class DataSourceService : IDataSourceService
{
    private readonly IDataSourceFactory _dataSourceFactory;

    public DataSourceService(IDataSourceFactory dataSourceFactory)
    {
        _dataSourceFactory = dataSourceFactory;
    }
    
    
    public async Task<List<Stock>> GetStocks(long id, long page, long pageSize, CancellationToken cancellationToken)
    {
            
        var stocksGetStrategy = _dataSourceFactory.GetStrategy();
        return await stocksGetStrategy.GetStocksByInventoryItemId(id, page, pageSize, cancellationToken);
    }
}
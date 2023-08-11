using StockControlApi.Service.ElasticSearch;
using StockControlApi.Service.Interface;
using StockControlApi.Service.SQL;

namespace StockControlApi.Service;

public class DataServiceFactory : IDataServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DataServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IStockService CreateDataService(string dataSource)
    {
        switch (dataSource)
        {
            case "Elasticsearch":
                return _serviceProvider.GetService<StockElasticService>();
            case "SQL":
                return _serviceProvider.GetService<StockSQLService>();
            default:
                throw new NotSupportedException("Invalid data source");
        }
    }
}
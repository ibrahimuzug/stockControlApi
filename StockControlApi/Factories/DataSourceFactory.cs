using Microsoft.VisualBasic;
using StockControlApi.Factories.Interfaces;
using StockControlApi.Strategies;
using StockControlApi.Strategies.Interfaces;
using Constants = StockControlApi.Helpers.Constants;

namespace StockControlApi.Factories;

public class DataSourceFactory : IDataSourceFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public DataSourceFactory(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }
    
    public IDataSourceStrategy GetStrategy()
    {
        var isMssqlActive = _configuration.GetValue<bool>(Constants.ConfigurationKeys.IsMssqlActive);

        return isMssqlActive switch
        {
            true => _serviceProvider.GetService<MsSqlDataStrategy>(),
            false => _serviceProvider.GetService<ElasticSearchDataStrategy>()
        };
    }
}
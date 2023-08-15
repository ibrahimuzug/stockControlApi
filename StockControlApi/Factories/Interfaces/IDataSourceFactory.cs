using StockControlApi.Strategies.Interfaces;

namespace StockControlApi.Factories.Interfaces;

public interface IDataSourceFactory
{
     IDataSourceStrategy GetStrategy();
}
namespace StockControlApi.Service.Interface;

public interface IDataServiceFactory
{
    IStockService CreateDataService(string dataSource);
}
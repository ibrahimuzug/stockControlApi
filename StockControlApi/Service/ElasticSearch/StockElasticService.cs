using StockControlApi.Bases;
using StockControlApi.Data.Entities;
using StockControlApi.Service.Interface;

namespace StockControlApi.Service.ElasticSearch;

public class StockElasticService : IStockService
{
    public Task<List<Stock>> GetStockById(long id, long page, long pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<bool>> DoesStockExist(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
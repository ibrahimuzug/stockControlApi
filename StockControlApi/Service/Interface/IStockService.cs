using StockControlApi.Bases;
using StockControlApi.Data.Entities;

namespace StockControlApi.Service.Interface;

public interface IStockService
{
    Task<List<Stock>> GetStockById(long id, long page, long pageSize, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DoesStockExist(long id, CancellationToken cancellationToken);
}
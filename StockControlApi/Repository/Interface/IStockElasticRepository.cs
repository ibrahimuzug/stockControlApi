using StockControlApi.Bases;
using StockControlApi.Data.Entities;

namespace StockControlApi.Repository.Interface;

public interface IStockElasticRepository
{
    Task<List<Stock>> GetStocksByInventoryItemId(long id, long page, long pageSize, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DoesStockExist(long id, CancellationToken cancellationToken);
}
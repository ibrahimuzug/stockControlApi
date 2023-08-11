using StockControlApi.Bases;
using StockControlApi.Data.Entities;
using StockControlApi.Repository.Interface;
using StockControlApi.Service.Interface;

namespace StockControlApi.Service;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }
    
    public async Task<List<Stock>> GetStockById(long id, long page, long pageSize, CancellationToken cancellationToken)
    {
        return await _stockRepository.GetStocksByInventoryItemId(id, page, pageSize, cancellationToken);
    }

    public async Task<BaseResponse<bool>> DoesStockExist(long id, CancellationToken cancellationToken)
    {
        return await _stockRepository.DoesStockExist(id, cancellationToken);
    }
}
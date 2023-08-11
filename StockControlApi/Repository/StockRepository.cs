using Microsoft.EntityFrameworkCore;
using StockControlApi.Bases;
using StockControlApi.Data.Context;
using StockControlApi.Data.Entities;
using StockControlApi.Repository.Interface;

namespace StockControlApi.Repository;

public class StockRepository : IStockRepository
{
    private readonly DataContext _context;
    
    public StockRepository(DataContext context)
    {
        _context = context;
    }


    public async Task<List<Stock>> GetStocksByInventoryItemId(long id, long page, long pageSize, CancellationToken cancellationToken)
    {
        return await _context.Stocks.AsNoTracking().Where(x => x.InventoryItemId == id).ToListAsync(cancellationToken);
    }

    public async Task<BaseResponse<bool>> DoesStockExist(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
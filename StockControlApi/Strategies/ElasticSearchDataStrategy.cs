using StockControlApi.Data.Entities;
using StockControlApi.Service.ElasticSearch.Interfaces;
using StockControlApi.Strategies.Interfaces;

namespace StockControlApi.Strategies;

public class ElasticSearchDataStrategy : IDataSourceStrategy
{
    private readonly IStockElasticService _elasticService;

    public ElasticSearchDataStrategy(IStockElasticService elasticService)
    {
        _elasticService = elasticService;
    }

    public async Task<List<Stock>> GetStocksByInventoryItemId(long id, long page, long pageSize,
        CancellationToken cancellationToken)
    {
        return await _elasticService.GetStocksByInventoryItemId(id, page, pageSize, cancellationToken);
    }
}
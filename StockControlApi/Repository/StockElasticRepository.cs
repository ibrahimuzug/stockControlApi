using Nest;
using StockControlApi.Bases;
using StockControlApi.Data.Entities;
using StockControlApi.Helpers;
using StockControlApi.Repository.Interface;

namespace StockControlApi.Repository;

public class StockElasticRepository : IStockElasticRepository
{
    private readonly ElasticClient _elasticClient;

    public StockElasticRepository(ElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }


    public async Task<List<Stock>> GetStocksByInventoryItemId(long id, long page, long pageSize, CancellationToken cancellationToken)
    {
        var elasticsearchResponse = await _elasticClient.SearchAsync<Stock>(s => s
            .Index(Constants.ElasticsearchConstants.StockElasticSearchIndex)
            .Query(q =>
                q.Term(b => b
                    .Field(x => x.InventoryItemId).Value(id)
                )), cancellationToken);

        return elasticsearchResponse.Documents.ToList();
    }

    public Task<BaseResponse<bool>> DoesStockExist(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
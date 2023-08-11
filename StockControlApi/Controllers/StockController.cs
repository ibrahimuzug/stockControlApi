using System.Net;
using Couchbase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using StockControlApi.Data.Entities;
using StockControlApi.Exceptions;
using StockControlApi.Service.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace StockControlApi.Controllers;

[ApiController]
[Route("{version:apiVersion}/stock")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[ApiVersion("3.0")]
public class StockController : Controller
{
    private readonly IStockService _stockService;
    private readonly ILogger<StockController> _logger;
    private readonly IStringLocalizer _stringLocalizer;
    
    public StockController(IStockService stockService, ILogger<StockController> logger, IStringLocalizer stringLocalizer)
    {
        _stockService = stockService;
        _logger = logger;
        _stringLocalizer = stringLocalizer;
    }
    
    [HttpGet("/{id}")]
    [ApiVersion("1.0")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Returns stock with the given Id", typeof(Stock))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Returns NotFound when given StockId not found")]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Returns InternalServerError when error occurs")]
    public async Task<IActionResult> GetStocksById(long id, long page, long pageSize, CancellationToken cancellationToken)
    {
        try
        {
            var stock = await _stockService.GetStockById(id, page, pageSize, cancellationToken);

            return Ok(stock);
        }
        catch (StockNotFoundException ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status404NotFound, _stringLocalizer["StockNotFoundWithGivenId"].Value);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
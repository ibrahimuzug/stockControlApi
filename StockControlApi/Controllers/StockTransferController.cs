using System.Net;
using Couchbase;
using Couchbase.Core.Exceptions.KeyValue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using StockControlApi.Data;
using StockControlApi.Service.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace StockControlApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[ApiVersion("3.0")]
public class StockTransferController : Controller
{
    private readonly IStockTransferService _stockTransferService;
    private readonly ILogger<StockTransferController> _logger;
    private readonly IStringLocalizer _stringLocalizer;

    public StockTransferController(IStockTransferService stockTransferService, ILogger<StockTransferController> logger, IStringLocalizer stringLocalizer)
    {
        _stockTransferService = stockTransferService;
        _logger = logger;
        _stringLocalizer = stringLocalizer;
    }
}
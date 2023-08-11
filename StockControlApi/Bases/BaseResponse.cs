using System.Net;

namespace StockControlApi.Bases;

public class BaseResponse <T>
{
    public string Message { get; set; }
    public bool HasError => !string.IsNullOrEmpty(Message);
    public T Result { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
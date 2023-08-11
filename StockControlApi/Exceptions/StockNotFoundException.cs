namespace StockControlApi.Exceptions;

public class StockNotFoundException : Exception
{
    public StockNotFoundException(string message) : base(message)
    {
    }
}
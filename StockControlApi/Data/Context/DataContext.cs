using Microsoft.EntityFrameworkCore;
using StockControlApi.Data.Entities;

namespace StockControlApi.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Stock> Stocks { get; set; }
    
}
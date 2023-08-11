using StockControlApi.Service;
using StockControlApi.Service.ElasticSearch;
using StockControlApi.Service.Interface;
using StockControlApi.Service.SQL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDataServiceFactory, DataServiceFactory>();
builder.Services.AddScoped<StockElasticService>();
builder.Services.AddScoped<StockSQLService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
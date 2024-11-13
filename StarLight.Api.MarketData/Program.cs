using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("historical-prices", (MarketDataContext context, HistoricalPrice historicalPrice) =>
{
    context.HistoricalPrices.Add(historicalPrice);
    context.SaveChanges();
})
.WithName("AddHistoricalPrice");

app.MapGet("historical-prices/", (MarketDataContext context, [FromQuery] string symbol, [FromQuery] string from, [FromQuery] string to) =>
    context.HistoricalPrices
    .WithCompany(symbol)
    .WithFromDate(from)
    .WithToDate(to)
    .ToList()
)
.WithName("GetHistoricalPriceByCompany");

app.MapGet("companies", (MarketDataContext context) =>
{
    return context.Companies.ToList();
})
.WithName("GetHistoricalPriceByCompany");
app.Run();

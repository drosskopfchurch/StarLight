using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.AddServiceDefaults();
builder.Services.AddDbContext<MarketDataContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("MarketData") ,
                    opts =>
                    {
                        opts.EnableRetryOnFailure();
                        opts.CommandTimeout(600); // 5 minutes
                    });
                options.EnableSensitiveDataLogging();
            },
            ServiceLifetime.Transient
            );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("historical-prices", async (MarketDataContext context, HistoricalPrice historicalPrice) =>
{
    context.HistoricalPrices.Add(historicalPrice);
    await context.SaveChangesAsync();
})
.WithName("AddHistoricalPrice");

app.MapGet("historical-prices", async (MarketDataContext context, [FromQuery] string symbol, [FromQuery] string? from, [FromQuery] string? to) =>
    await context.HistoricalPrices
    .WithCompany(symbol)
    .WithFromDate(from)
    .WithToDate(to)
    .ToListAsync()
)
.WithName("GetHistoricPrices");

app.MapGet("historical-prices/{symbol}/last", async (MarketDataContext context, string symbol) =>
    await context.HistoricalPrices
    .WithCompany(symbol)
    .OrderByDescending(p => p.DateTime)
    .LastOrDefaultAsync()
)
.WithName("GetLastHistoricalPriceByCompany");

app.MapGet("companies", async (MarketDataContext context) => await context.Companies.ToListAsync())
.WithName("GetCompanies");

app.Run();

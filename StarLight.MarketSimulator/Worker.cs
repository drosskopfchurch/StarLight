using Microsoft.Extensions.Caching.Hybrid;
using StackExchange.Redis;
using StarLight.Provider.MarketData;

namespace StarLight.MarketSimulator;

public class Worker(ILogger<Worker> logger, MarketDataService marketDataService, string symbol = "") : BackgroundService
{

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (string.IsNullOrEmpty(symbol)) return;


        while (!stoppingToken.IsCancellationRequested)
        {
            Random random = new();
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            var lastPrice = await marketDataService.GetLastPrice(symbol, stoppingToken);

            if (lastPrice is not null)
            {
                var price = lastPrice.Price;
                var change = random.Next(800, 1200) * 0.001;
                var newPrice = price + (price * change);
                if (newPrice <= 0)
                {
                    newPrice = price + 10;
                }
                var newHistoricalPrice = new HistoricalPrice(symbol, DateTimeOffset.Now, newPrice);
                await marketDataService.AddHistoricPrice(newHistoricalPrice, stoppingToken);
            }


            var delay = random.Next(1, 5) * 1000;

            await Task.Delay(delay, stoppingToken);
        }
    }
}

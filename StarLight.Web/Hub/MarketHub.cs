using Microsoft.AspNetCore.SignalR;
using StarLight.Provider.MarketData;
public class MarketHub(ILogger<MarketHub> logger, MarketDataService marketDataService) : Hub
{
    public async Task<IEnumerable<HistoricalPrice>?> GetHistoricalPrices(string symbol, DateTime startDate, DateTime endDate) => 
        await marketDataService.GetHistoricalPrices(symbol, startDate, endDate);
    
    public async Task AddHistoricalPrice(HistoricalPrice historicalPrice) => await Task.WhenAll(
        marketDataService.AddHistoricPrice(historicalPrice),
        Clients.All.SendAsync("HistoricalPriceAdded", historicalPrice)
    );
}
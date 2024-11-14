using System.Collections;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Hybrid;

namespace StarLight.Provider.MarketData;
public interface IMarketDataService
{
    Task AddHistoricPrice(HistoricalPrice historicalPrice, CancellationToken cancellationToken = default);
    Task<HistoricalPrice?> GetLastPrice(string symbol, CancellationToken cancellationToken = default);
    Task<IEnumerable<HistoricalPrice>?> GetHistoricalPrices(string symbol, DateTime from, DateTime to, CancellationToken cancellationToken = default);
}
public class MarketDataService(HttpClient client, HybridCache hybridCache, StarLightWebService starLightWebService) : IMarketDataService
{
    public async Task AddHistoricPrice(HistoricalPrice historicalPrice, CancellationToken cancellationToken = default) =>
        await Task.WhenAll(
            client.PostAsJsonAsync("/historical-prices", historicalPrice, cancellationToken),
            starLightWebService.AddHistoricPrice(historicalPrice),
            hybridCache.SetAsync(HistoricalPrice.GetKey(historicalPrice.Symbol, historicalPrice.DateTime), historicalPrice).AsTask()
        );

    public async Task<HistoricalPrice?> GetLastPrice(string symbol, CancellationToken cancellationToken = default) =>
        await hybridCache.GetOrCreateAsync(
            key: HistoricalPrice.GetLastKey(symbol),
            factory: async (cancellationToken) => await client.GetFromJsonAsync<HistoricalPrice>($"/historical-prices/{symbol}/last"),
            cancellationToken: cancellationToken);

    public async Task<IEnumerable<HistoricalPrice>?> GetHistoricalPrices(string symbol, DateTime from, DateTime to, CancellationToken cancellationToken = default) =>
        await hybridCache.GetOrCreateAsync(
            key: HistoricalPrice.GetListKey(symbol),
            factory: async (cancellationToken) => await client.GetFromJsonAsync<IEnumerable<HistoricalPrice>>($"/historical-prices?{new { symbol, from, to }.ToQueryString()}"),
            cancellationToken: cancellationToken);
}

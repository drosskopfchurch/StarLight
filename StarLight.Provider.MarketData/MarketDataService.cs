using System.Collections;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Hybrid;

namespace StarLight.Provider.MarketData;

public class MarketDataService(HttpClient client, HybridCache hybridCache)
{
    public async Task AddHistoricPrice(HistoricalPrice historicalPrice, CancellationToken cancellationToken = default) =>
        await Task.WhenAll(
            client.PostAsJsonAsync("/historicalprices", historicalPrice, cancellationToken),
            hybridCache.SetAsync(HistoricalPrice.GetKey(historicalPrice.Symbol, historicalPrice.DateTime), historicalPrice).AsTask()
        );

    public async Task<HistoricalPrice?> GetLastPrice(string symbol, CancellationToken cancellationToken = default) =>
        await hybridCache.GetOrCreateAsync(
            key: HistoricalPrice.GetLastKey(symbol),
            factory: async (cancellationToken) => await client.GetFromJsonAsync<HistoricalPrice>($"/historicalprices/{symbol}/last"),
            cancellationToken: cancellationToken);

    public async Task<IEnumerable<HistoricalPrice>?> GetHistoricalPrices(string symbol, DateTime from, DateTime to, CancellationToken cancellationToken = default) =>
        await hybridCache.GetOrCreateAsync(
            key: HistoricalPrice.GetListKey(symbol),
            factory: async (cancellationToken) => await client.GetFromJsonAsync<IEnumerable<HistoricalPrice>>($"/historicalprices?{new { symbol, from, to }.ToQueryString()}"),
            cancellationToken: cancellationToken);
}

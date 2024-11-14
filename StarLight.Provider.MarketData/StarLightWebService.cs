using System.Net.Http.Json;

namespace StarLight.Provider.MarketData;
public interface IStarLightWebService
{
    Task AddHistoricPrice(HistoricalPrice historicalPrice, CancellationToken cancellationToken = default);
}
public class StarLightWebService(HttpClient client) : IStarLightWebService
{
    public async Task AddHistoricPrice(HistoricalPrice historicalPrice, CancellationToken cancellationToken = default) =>
            await client.PostAsJsonAsync("/api/historical-prices", historicalPrice, cancellationToken);        
}

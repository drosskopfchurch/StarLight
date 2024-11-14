using BlazorBootstrap;
namespace StarLight.Web.Services;
public class PriceService
{
    public ChartData ChartData;
    private IList<HistoricalPrice> historicalPrices = [];

    public PriceService()
    {
        ChartData = InitialChartData.StockChartData;
    }

    public void AddPrice(HistoricalPrice historicalPrice)
    {
        historicalPrices.Add(historicalPrice);
        ChartData.Labels.Add(historicalPrice.DateTime.ToString("HH:mm"));
        foreach (LineChartDataset lineChartDataset in ChartData.Datasets)
        {
            if (lineChartDataset.Label == historicalPrice.Symbol)
                lineChartDataset.Data.Add(historicalPrice.Price);
            lineChartDataset.Data.Add(lineChartDataset.Data.Last());
        }
    }
}
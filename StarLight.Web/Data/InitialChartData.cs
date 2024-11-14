using BlazorBootstrap;
namespace StarLight.Web;
public static class InitialChartData
{
    public static LineChartOptions LineChartOptions
    {
        get
        {
            var lineChartOptions = new LineChartOptions();
            lineChartOptions.Locale = "de-DE";
            lineChartOptions.Responsive = true;
            lineChartOptions.Interaction = new Interaction { Mode = InteractionMode.Index };

            lineChartOptions.Scales.X!.Title = new ChartAxesTitle { Text = "Time", Display = true };
            lineChartOptions.Scales.Y!.Title = new ChartAxesTitle { Text = "Price", Display = true };

            lineChartOptions.Plugins.Title!.Text = "Stocks";
            lineChartOptions.Plugins.Title.Display = true;
            return lineChartOptions;
        }
    }
    public static ChartData StockChartData
    {
        get
        {
            var colors = ColorUtility.CategoricalTwelveColors;
            var chartData = new ChartData();

            chartData.Labels = new List<string> { "00:00" };
            chartData.Datasets = new List<IChartDataset>()
            {
                StockDataSet("APPL", colors[0]),
                StockDataSet("GOOGL", colors[1]),
                StockDataSet("NFLX", colors[2]),
                StockDataSet("DIS", colors[3])
            };
            return chartData;
        }
    }
    public static ChartData GetChartData(string symbol, string color)
    {
        
            var chartData = new ChartData();

            chartData.Labels = new List<string> { "00:00" };
            chartData.Datasets = new List<IChartDataset>()
            {
                StockDataSet(symbol, color),
            };
            return chartData;
    }
    public static LineChartDataset StockDataSet(string symbol, string color)
    {
        var lineChartDataset = new LineChartDataset();
        lineChartDataset.Label = symbol;
        lineChartDataset.Data = new List<double?> { 0 };
        lineChartDataset.BackgroundColor = color;
        lineChartDataset.BorderColor = color;
        lineChartDataset.Fill = false;
        lineChartDataset.BorderWidth = 2;
        lineChartDataset.HoverBorderWidth = 4;
        return lineChartDataset;
    }
}
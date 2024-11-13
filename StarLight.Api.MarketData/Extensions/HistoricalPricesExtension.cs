public static class HistoricalPricesExtension
{
    public static IQueryable<HistoricalPrice> WithCompany(this IQueryable<HistoricalPrice> historicalPrices, string symbol) => historicalPrices.Where(hp => hp.Symbol == symbol);
    public static IQueryable<HistoricalPrice> WithFromDate(this IQueryable<HistoricalPrice> historicalPrices, string dateTime) => String.IsNullOrEmpty(dateTime) ? historicalPrices.WithFromDate(DateTime.Parse(dateTime)) : historicalPrices;
    public static IQueryable<HistoricalPrice> WithFromDate(this IQueryable<HistoricalPrice> historicalPrices, DateTime dateTime) => historicalPrices.Where(hp => hp.DateTime > dateTime);
    public static IQueryable<HistoricalPrice> WithToDate(this IQueryable<HistoricalPrice> historicalPrices, string dateTime) => String.IsNullOrEmpty(dateTime) ? historicalPrices.WithToDate(DateTime.Parse(dateTime)) : historicalPrices;
    public static IQueryable<HistoricalPrice> WithToDate(this IQueryable<HistoricalPrice> historicalPrices, DateTime dateTime) => historicalPrices.Where(hp => hp.DateTime < dateTime);
}

public static class Prices
{
    public static IList<HistoricalPrice> SeedData => new List<HistoricalPrice>
    {
        new HistoricalPrice("AAPL", new DateTime(2023, 1, 1, 1, 0, 0, DateTimeKind.Utc), 150.00),
        new HistoricalPrice("MSFT", new DateTime(2023, 1, 1, 3, 0, 0, DateTimeKind.Utc), 250.00),
        new HistoricalPrice("AMZN", new DateTime(2023, 1, 1, 6, 0, 0, DateTimeKind.Utc), 3200.00),
        new HistoricalPrice("GOOGL", new DateTime(2023, 1, 1, 1, 0, 0, DateTimeKind.Utc), 2800.00),
        new HistoricalPrice("META", new DateTime(2023, 1, 1, 2, 0, 0, DateTimeKind.Utc), 200.00),
        new HistoricalPrice("BRK.B", new DateTime(2023, 1, 1, 4, 0, 0, DateTimeKind.Utc), 300.00),
        new HistoricalPrice("JNJ", new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), 160.00),
        new HistoricalPrice("JPM", new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), 130.00),
        new HistoricalPrice("V", new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), 220.00),
        new HistoricalPrice("PG", new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), 140.00),
        new HistoricalPrice("NVDA", new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), 500.00),
        new HistoricalPrice("UNH", new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), 450.00),
        new HistoricalPrice("HD", new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), 300.00),
        new HistoricalPrice("NFLX", new DateTime(2023, 2, 1, 0, 0, 0, DateTimeKind.Utc), 35.00),
        new HistoricalPrice("DIS", new DateTime(2023, 2, 1, 0, 0, 0, DateTimeKind.Utc), 135.00),
        new HistoricalPrice("PEP", new DateTime(2023, 2, 1, 0, 0, 0, DateTimeKind.Utc), 85.00),
        new HistoricalPrice("ADBE", new DateTime(2023, 2, 1, 0, 0, 0, DateTimeKind.Utc), 185.00),
    };
}
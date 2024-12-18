public record Company(
    string Symbol,
    string Name
);

public record HistoricalPrice(
    string Symbol,
    DateTimeOffset DateTime,
    double Price
)
{
    public static string GetKey(string symbol, DateTimeOffset dateTime) => $"{symbol}-{dateTime:yyyy-MM-dd}";
    public static string GetLastKey(string symbol) => $"{symbol}-Last";
    public static string GetListKey(string symbol) => $"{symbol}-List";
    public string Key => GetKey(Symbol, DateTime);
    public string LastKey => GetLastKey(Symbol);
    public string ListKey => GetListKey(Symbol);
};

public class PriceRecord
{
    public DateTime Date { get; set; }
    public string? SecurityId { get; set; }
    public int CompanyId { get; set; }
    public string? Ticker { get; set; }
    public string? IsoCountryCode { get; set; }
    public decimal Close { get; set; }
}
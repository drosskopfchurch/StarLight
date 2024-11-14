    public static class StringExtensions
{
    public static string ToQueryString(this object parameters)
    {
        var properties = parameters.GetType().GetProperties()
            .Where(p => p.GetValue(parameters) != null)
            .Select(p => $"{p.Name}={Uri.EscapeDataString(p.GetValue(parameters)?.ToString() ?? string.Empty)}");
        return string.Join("&", properties);
    }
}
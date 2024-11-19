using StarLight.MarketSimulator;
using StarLight.Provider.MarketData;

var builder = Host.CreateApplicationBuilder(args);
builder.AddServiceDefaults();
#pragma warning disable EXTEXP0018 // Suppress the warning for AddHybridCache
builder.Services.AddHybridCache();
#pragma warning restore EXTEXP0018 // Restore the warning for AddHybridCache
builder.Services.AddHttpClient<MarketDataService>((client =>
{
    client.BaseAddress =  new("https://api-market");
}));
builder.Services.AddHttpClient<StarLightWebService>((client =>
{
    client.BaseAddress =  new("https://web");
}));

builder.Services.AddHostedService<AAL>();
builder.Services.AddHostedService<AAPL>();
builder.Services.AddHostedService<APPL>();
builder.Services.AddHostedService<AMZN>();
builder.Services.AddHostedService<MSFT>();
builder.Services.AddHostedService<DIS>();
builder.Services.AddHostedService<GOOGL>();
builder.Services.AddHostedService<META>();
builder.Services.AddHostedService<JNJ>();
builder.Services.AddHostedService<NFLX>();
builder.Services.AddHostedService<ADBE>();
builder.Services.AddHostedService<PEP>();
builder.Services.AddHostedService<CAT>();

var host = builder.Build();
host.Run();

using StarLight.MarketSimulator;
using StarLight.Provider.MarketData;

var builder = Host.CreateApplicationBuilder(args);
builder.AddRedisClient(connectionName: "cache");
builder.Services.AddHttpClient<MarketDataService>((client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/");
}));
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

var host = builder.Build();
host.Run();

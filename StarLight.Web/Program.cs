using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using StarLight.Provider.MarketData;
using StarLight.Web.Components;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
#pragma warning disable EXTEXP0018 // Suppress the warning for AddHybridCache
builder.Services.AddHybridCache();
#pragma warning restore EXTEXP0018 // Restore the warning for AddHybridCache
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();
builder.Services.AddBlazorBootstrap();
builder.Services.AddSingleton<IMarketHub, MarketHub>();
builder.Services.AddHttpClient<MarketDataService>((client =>
{
    client.BaseAddress =  new("https://api-market");
}));
builder.Services.AddHttpClient<StarLightWebService>((client =>
{
    client.BaseAddress =  new("https://web");
}));
builder.Services.AddResponseCompression(opts =>
{
   opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
       ["application/octet-stream"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();
app.MapHub<MarketHub>("/market-hub");

app.MapPost("api/historical-prices", async (IHubContext<MarketHub> hub, IMarketHub marketHub,  HistoricalPrice historicalPrice) => 
{  
    // await marketHub.AddHistoricalPrice(historicalPrice);
    await hub.Clients.All.SendAsync("AddHistoricalPrice", historicalPrice);
    await hub.Clients.All.SendAsync("HistoricalPriceAdded", historicalPrice);
})
.WithName("AddHistoricalPrice");


app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithLifetime(ContainerLifetime.Persistent);

var sqlserver = builder.AddSqlServer("sqlserver")
    .WithLifetime(ContainerLifetime.Persistent);

var marketData = sqlserver.AddDatabase("MarketData");

var migrationService = builder.AddProject<Projects.StarLight_MigrationService>("migrationservice")
    .WithReference(marketData)
    .WaitFor(marketData);

var apiMarket = builder.AddProject<Projects.StarLight_Api_MarketData>("apimarket")    
    .WithReference(marketData)
    .WithReference(cache)
    .WaitForCompletion(migrationService);

var web = builder.AddProject<Projects.StarLight_Web>("web")    
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiMarket)
    .WaitForCompletion(migrationService);

builder.AddProject<Projects.StarLight_MarketSimulator>("simulator")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiMarket)
    .WithReference(web)
    .WaitForCompletion(migrationService);

builder.AddNpmApp("web-demo", "../StarLight.Web.Demo", "dev")
    .WithReference(apiMarket)
    .WaitFor(apiMarket)
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();

builder.Build().Run();

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithLifetime(ContainerLifetime.Persistent);

var sqlserver = builder.AddSqlServer("sqlserver")
    .WithLifetime(ContainerLifetime.Persistent);

var marketData = sqlserver.AddDatabase("MarketData");

var migrationService = builder.AddProject<Projects.StarLight_MigrationService>("migrationservice")
    .WithReference(marketData)
    .WaitFor(marketData);

var apiMarket = builder.AddProject<Projects.StarLight_Api_MarketData>("api-market")
    .WithHttpsEndpoint(port: 51000, name: "api-market")
    .WithReference(marketData)
    .WithReference(cache)
    .WaitForCompletion(migrationService);

builder.AddProject<Projects.StarLight_Web>("web")
    .WithHttpsEndpoint(port: 51002, name: "api-market")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiMarket)
    .WaitForCompletion(migrationService);

builder.AddProject<Projects.StarLight_MarketSimulator>("simulator")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiMarket)
    .WaitForCompletion(migrationService);

builder.Build().Run();

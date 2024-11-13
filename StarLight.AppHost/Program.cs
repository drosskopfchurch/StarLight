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
                .WithReference(sqlserver)
                .WithReference(cache)
                .WaitForCompletion(migrationService);

builder.AddProject<Projects.StarLight_Web>("web")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiMarket);

builder.Build().Run();

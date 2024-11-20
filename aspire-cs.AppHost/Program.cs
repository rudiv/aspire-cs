var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("project-cache");
var anothercache = builder.AddRedis("projectcache");

var api = builder.AddProject<Projects.aspire_cs_ApiService>("apiservice");

var frontend = builder.AddNpmApp("frontend", "../njs", "dev")
    .WithReference(api)
    .WithReference(cache)
    .WithReference(anothercache)
    .WaitFor(api)
    .WithEnvironment("NODE_TLS_REJECT_UNAUTHORIZED", "0")
    .WithHttpEndpoint(port: 7123, targetPort: 3000, env: "PORT")
    .WithEnvironment("ConnectionStrings__test", "Weee")
    .WithEnvironment("ConnectionStrings__test-i-do-not-work", "Weee")
    .WithEnvironment("ConnectionStrings__test_i_work", "Weee");

builder.Build().Run();

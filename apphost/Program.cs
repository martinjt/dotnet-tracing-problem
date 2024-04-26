var builder = DistributedApplication.CreateBuilder(args);

var backend = builder.AddProject<Projects.backend>("backend");

builder.AddProject<Projects.frontend>("frontend")
    .WithReference(backend);

builder.Build().Run();

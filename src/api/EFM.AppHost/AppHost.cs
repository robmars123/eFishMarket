using Google.Protobuf.WellKnownTypes;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

//main entry point
IResourceBuilder<ProjectResource>? entrypoint = builder.AddProject<Projects.EFM_Api>("api");

builder.Build().Run();

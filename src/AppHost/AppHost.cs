IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

//main entry point
IResourceBuilder<ProjectResource>? entrypoint = builder.AddProject<Projects.EFM_Api>("api");

//modules
IResourceBuilder<ProjectResource>? productsapi = builder.AddProject<Projects.EFM_Modules_Products_Api>("productsapi");

builder.Build().Run();

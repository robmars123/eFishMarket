var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.EFM_Products_Api>("productsapi");
builder.Build().Run();

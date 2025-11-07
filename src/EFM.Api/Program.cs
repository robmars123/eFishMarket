using EFM.Api.DependencyExtensions;
using EFM.Modules.Products.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddDependencyExtensions();
builder.Services.AddCORS();

WebApplication app = builder.Build();

app.EnvironmentConfig();

app.Run();

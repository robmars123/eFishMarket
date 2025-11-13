using EFM.Api.DependencyExtensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddDependencyExtensions();

WebApplication app = builder.Build();

app.AppConfig();

app.Run();

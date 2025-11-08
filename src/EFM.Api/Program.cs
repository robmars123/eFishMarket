using EFM.Api.DependencyExtensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddDependencyExtensions();
builder.Services.AddServiceDependencies();
builder.Services.AddCORS();
builder.Services.RegisterHandlers();

WebApplication app = builder.Build();

app.EnvironmentConfig();
app.Run();

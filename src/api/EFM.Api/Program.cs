using EFM.Api.DependencyExtensions;
using EFM.Common.Infrastructure.Logging;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.AddSerilogWithSeq(new Uri("http://localhost:5341"));

builder.Host.UseSerilog();

builder.AddDependencyExtensions();

WebApplication app = builder.Build();

app.AppConfig();

app.UseSerilogRequestLogging();

app.Run();

using EFM.Api.DependencyExtensions;
using EFM.Common.Infrastructure.Logging;
using Microsoft.Extensions.FileProviders;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.AddSerilogWithSeq(new Uri("http://localhost:5341"));

builder.Host.UseSerilog();

builder.AddDependencyExtensions();

string environment = builder.Environment.EnvironmentName;
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine($"[Startup] ASPNETCORE_ENVIRONMENT: {environment}");
Console.WriteLine($"[Startup] DefaultConnection: {connectionString}");


WebApplication app = builder.Build();

// Serve React build
//app.UseDefaultFiles();
//app.UseStaticFiles();
//app.MapFallbackToFile("index.html");

app.UseRouting();
app.AppConfig();


app.UseSerilogRequestLogging();

app.Run();

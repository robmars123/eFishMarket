using EFM.Modules.Products.Infrastructure;

namespace EFM.Api.DependencyExtensions;

public static class ApplicationDependencies
{
    public static void AddDependencyExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddRazorPages();

        builder.Services.AddProductsDependencies(builder.Configuration);
    }
}

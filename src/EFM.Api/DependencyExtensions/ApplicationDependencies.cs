using EFM.Products.Api;

namespace EFM.Api.DependencyExtensions;

internal static class ApplicationDependencies
{
    public static void AddDependencyExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddRazorPages();

        #region Bounded Context Dependencies
        builder.Services.AddProductsDependencies(builder.Configuration);
        #endregion
    }
}

using EFM.Common.Application;
using EFM.Common.Infrastructure.Configurations;
using EFM.Inventory.Api;
using EFM.Products.Api;

namespace EFM.Api.DependencyExtensions;

internal static class ServiceDependencyBootstrapper
{
    public static void AddDependencyExtensions(this WebApplicationBuilder builder)
    {
        AddMicrosoftEntraAuthentication(builder);
        AddApiDependencies(builder);

        #region Bounded Context Dependencies
        builder.Services.AddProductsDependencies(builder.Configuration);
        builder.Services.AddInventoryDependencies(builder.Configuration);
        #endregion

        #region Common Dependencies
        builder.Services.AddApplicationConfiguration();
        builder.Services.AddInfrastructureConfiguration();
        #endregion
    }

    private static void AddMicrosoftEntraAuthentication(WebApplicationBuilder builder)
    {
        builder.AddEntraAuthentication();
    }

    private static void AddApiDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddCORS();
        builder.Services.RegisterHandlers();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddRazorPages();
    }
}

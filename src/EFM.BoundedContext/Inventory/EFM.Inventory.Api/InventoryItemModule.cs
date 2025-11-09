using EFM.Common.Application.Database;
using EFM.Common.Infrastructure.Database;
using EFM.Inventory.Api.Extensions;
using EFM.Inventory.Application.Abstractions.Repositories;
using EFM.Inventory.Infrastructure.Database;
using EFM.Inventory.Infrastructure.Repositories;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Inventory.Api;
public static class InventoryItemModule
{
    public static IEndpointRouteBuilder MapInventoryModule(this IEndpointRouteBuilder app)
    {
        app.MapInventoryEndpoints();
        return app;
    }

    public static IServiceCollection AddInventoryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddSqlServer(services, configuration);
        AddRepositories(services);
        AddFactories(services);

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        //Add more repositories here
        services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
    }

    private static void AddFactories(IServiceCollection services)
    {
        services.AddInventoryApiDependencies();
    }

    private static void AddSqlServer(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IConnectionDbFactory, ConnectionDbFactory>();
        services.AddDbContext<InventoryDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("EFM.Inventory.Infrastructure");
                sqlOptions.EnableRetryOnFailure();
            });
        });
    }
}

using EFM.Products.Api.Extensions;
using EFM.Products.Application.Abstractions.Database;
using EFM.Products.Application.Repositories;
using EFM.Products.Infrastructure.Database;
using EFM.Products.Infrastructure.Repositories;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Products.Api;
public static class ProductModules
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapProductEndpoints();
        return app;
    }

    public static IServiceCollection AddProductsDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddSqlServer(services, configuration);
        AddRepositories(services);
        AddFactories(services);

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        //Add more repositories here
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IReadOnlyProductRepository, ReadOnlyProductRepository>();
    }

    private static void AddFactories(IServiceCollection services)
    {
        services.AddProductApiDependencies();
    }

    private static void AddSqlServer(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IConnectionDbFactory, ConnectionDbFactory>();
        services.AddDbContext<ProductDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("EFM.Products.Infrastructure");
                sqlOptions.EnableRetryOnFailure();
            });
        });
    }
}

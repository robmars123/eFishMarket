using EFM.Products.Api.Extensions;
using EFM.Products.Application.Repositories;
using EFM.Products.Infrastructure.Database;
using EFM.Products.Infrastructure.Repositories;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Products.Infrastructure;
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

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        //Add more repositories here
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    private static void AddSqlServer(IServiceCollection services, IConfiguration configuration)
    {
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

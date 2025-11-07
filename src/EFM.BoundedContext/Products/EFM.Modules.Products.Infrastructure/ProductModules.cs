using EFM.Modules.Products.Api.Extensions;
using EFM.Modules.Products.Infrastructure.Database;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Modules.Products.Infrastructure;
public static class ProductModules
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapProductEndpoints();
        return app;
    }

    public static IServiceCollection AddProductsDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductsDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("EFM.Modules.Products.Infrastructure");
                sqlOptions.EnableRetryOnFailure();
            });
        });

        return services;
    }
}

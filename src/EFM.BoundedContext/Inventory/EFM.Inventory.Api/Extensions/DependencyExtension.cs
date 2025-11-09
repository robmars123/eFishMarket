using EFM.Common.Domain.Abstractions;
using EFM.Inventory.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Inventory.Api.Extensions;
public static class DependencyExtension
{
    public static IServiceCollection AddInventoryApiDependencies(this IServiceCollection services)
    {
        //services.AddScoped<IGetPagedProductsFactory, GetPagedProductsFactory>();
        //services.AddScoped<IGetProductByIdFactory, GetProductByIdFactory>();
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<InventoryDbContext>());
        return services;
    }
}

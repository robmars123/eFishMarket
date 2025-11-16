using EFM.Common.Domain.Abstractions;
using EFM.Inventory.Application.Abstractions.Repositories;
using EFM.Inventory.Infrastructure.Database;
using EFM.Inventory.Infrastructure.PublicApi;
using EFM.Inventory.PublicApi;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Inventory.Api.Extensions;
public static class DependencyExtension
{
    public static IServiceCollection AddInventoryApiDependencies(this IServiceCollection services)
    {
        //services.AddScoped<IGetPagedProductsFactory, GetPagedProductsFactory>();
        //services.AddScoped<IGetProductByIdFactory, GetProductByIdFactory>();
        services.AddScoped<IInventoryUnitOfWork>(provider => provider.GetRequiredService<InventoryDbContext>());

        services.AddScoped<IInventoryApi, InventoryApi>();
        return services;
    }
}

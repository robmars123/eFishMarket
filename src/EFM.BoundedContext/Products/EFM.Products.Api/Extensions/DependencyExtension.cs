using EFM.Common.Domain.Abstractions;
using EFM.Products.Api.Factories;
using EFM.Products.Api.Factories.Abstractions;
using EFM.Products.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Products.Api.Extensions;
public static class DependencyExtension
{
    public static IServiceCollection AddProductApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<IGetPagedProductsFactory, GetPagedProductsFactory>();
        services.AddScoped<IGetProductByIdFactory, GetProductByIdFactory>();
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ProductDbContext>());
        return services;
    }
}

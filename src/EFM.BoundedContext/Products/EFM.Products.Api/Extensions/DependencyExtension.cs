using EFM.Products.Api.Factories;
using EFM.Products.Api.Factories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Products.Api.Extensions;
public static class DependencyExtension
{
    public static IServiceCollection AddProductApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<IGetPagedProductsFactory, GetPagedProductsFactory>();
        return services;
    }
}

using EFM.Products.Infrastructure.Database;
using EFM.Common.Application.Mediator;
using EFM.Common.Domain.Abstractions;
using EFM.Common.Infrastructure.Mediator;

namespace EFM.Api.DependencyExtensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ProductDbContext>());

        return services;
    }
}

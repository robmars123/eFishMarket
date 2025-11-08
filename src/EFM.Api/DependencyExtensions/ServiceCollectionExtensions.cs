using EFM.Products.Infrastructure.Database;
using EFM.SharedKernel.Application.Mediator;
using EFM.SharedKernel.Domain.Abstractions;
using EFM.SharedKernel.Infrastructure.Mediator;

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

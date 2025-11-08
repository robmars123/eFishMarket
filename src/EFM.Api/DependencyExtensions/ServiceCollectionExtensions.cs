using EFM.SharedKernel.Application.Mediator;
using EFM.SharedKernel.Infrastructure.Mediator;

namespace EFM.Api.DependencyExtensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();

        return services;
    }
}

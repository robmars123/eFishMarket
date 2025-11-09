using EFM.Common.Application.Clock;
using EFM.Common.Application.Database;
using EFM.Common.Application.Mediator;
using EFM.Common.Domain.Abstractions;
using EFM.Common.Infrastructure.Clock;
using EFM.Common.Infrastructure.Database;
using EFM.Common.Infrastructure.Mediator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EFM.Common.Infrastructure.Configurations;
public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services)
    {
        // Add infrastructure services here
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IConnectionDbFactory, ConnectionDbFactory>();
        services.AddScoped<IDispatcher, Dispatcher>();
        return services;
    }
}

using System.Reflection;
using EFM.Common.Application.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Common.Application;

/// <summary>
/// Provides extension methods for configuring application services.
/// </summary>
/// <remarks>This class contains methods to register application-specific services into the dependency injection
/// container.</remarks>
public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplicationConfiguration(
        this IServiceCollection services)
    {
        services.AddTransient(typeof(RequestLogger<,>));
        services.AddTransient(typeof(CommandLogger<>));

        return services;
    }
}

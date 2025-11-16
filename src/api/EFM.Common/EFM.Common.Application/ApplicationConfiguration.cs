using System.Reflection;
using EFM.Common.Application.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Common.Application;
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

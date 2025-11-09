using System.Reflection;
using EFM.Common.Application.Commands;
using EFM.Common.Application.Events;
using EFM.Common.Application.Queries;

namespace EFM.Api.DependencyExtensions;

internal static class HandlerRegistrationExtensions
{
    public static IServiceCollection RegisterHandlers(this IServiceCollection services)
    {
        // Load all assemblies that match the pattern "EFM.*.dll" from output folder
        // this ensure that all modules are scanned for handlers
        string path = AppContext.BaseDirectory;
        var allAssemblies = Directory.GetFiles(path, "EFM.*.dll")
            .Select(Assembly.LoadFrom)
            .ToList();

        services.Scan(scan => scan
                .FromAssemblies(allAssemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );

        return services;
    }
}

using System.Reflection;
using EFM.Common.Application.Commands;
using EFM.Common.Application.Events;
using EFM.Common.Application.Queries;

namespace EFM.Api.DependencyExtensions;

/// <summary>
/// Registers all command, domain event, and request handlers found in assemblies matching the pattern "EFM.*.dll".
/// </summary>
/// <remarks>This method scans the application's output directory for assemblies with names matching the pattern
/// "EFM.*.dll". It registers all classes implementing <see cref="ICommandHandler{T}"/>, <see
/// cref="IDomainEventHandler{T}"/>, and <see cref="IRequestHandler{TRequest, TResponse}"/> as their respective
/// implemented interfaces with a transient lifetime.</remarks>
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
                .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );

        return services;
    }
}

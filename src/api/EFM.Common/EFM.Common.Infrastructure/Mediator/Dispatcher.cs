using EFM.Common.Application.Commands;
using EFM.Common.Application.Events;
using EFM.Common.Application.Logger;
using EFM.Common.Application.Mediator;
using EFM.Common.Application.Queries;
using EFM.Common.Application.Results;
using EFM.Common.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EFM.Common.Infrastructure.Mediator;

/// <summary>
/// Provides a mechanism for dispatching commands, queries, and events to their respective handlers.
/// </summary>
/// <remarks>The <see cref="Dispatcher"/> class acts as a mediator, resolving and invoking the appropriate
/// handlers for commands, queries, and events. It supports the following operations: <list type="bullet">
/// <item><description>Sending commands to a single command handler.</description></item> <item><description>Sending
/// queries or requests to a single request handler and returning a result.</description></item>
/// <item><description>Publishing events to multiple event handlers.</description></item> </list> This class relies on
/// dependency injection to resolve handlers and loggers for the dispatched operations.</remarks>
public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    // Command: single handler
    public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
    {
        ICommandHandler<TCommand> handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        CommandLogger<TCommand> logger = _serviceProvider.GetRequiredService<CommandLogger<TCommand>>();
        await logger.Handle(() => handler.Handle(command, cancellationToken));
    }

    // Query/Request: single handler returning a result
    public async Task<TResult> Send<TRequest, TResult>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : class, IRequest<TResult>
            where TResult : Result
    {
        IRequestHandler<TRequest, TResult> handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResult>>();
        RequestLogger<TRequest, TResult> logger = _serviceProvider.GetRequiredService<RequestLogger<TRequest, TResult>>();

        return await logger.Handle(() => handler.Handle(request, cancellationToken));
    }

    // Event: multiple subscribers
    public async Task Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent
    {
        IEnumerable<IDomainEventHandler<TEvent>> handlers = _serviceProvider.GetServices<IDomainEventHandler<TEvent>>();
        foreach (IDomainEventHandler<TEvent> handler in handlers)
        {
            await handler.Handle(@event);
        }
    }
}

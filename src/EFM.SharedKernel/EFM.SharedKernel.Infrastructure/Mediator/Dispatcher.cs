using Microsoft.Extensions.DependencyInjection;
using EFM.SharedKernel.Application.Commands;
using EFM.SharedKernel.Application.Events;
using EFM.SharedKernel.Application.Mediator;
using EFM.SharedKernel.Application.Queries;
using EFM.SharedKernel.Domain.Abstractions;

namespace EFM.SharedKernel.Infrastructure.Mediator;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    // Command: single handler
    public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand
    {
        ICommandHandler<TCommand> handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.Handle(command, cancellationToken);
    }

    // Query/Request: single handler returning a result
    public async Task<TResult> Send<TRequest, TResult>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResult>
    {
        IRequestHandler<TRequest, TResult> handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResult>>();
        return await handler.Handle(request, cancellationToken);
    }

    // Event: multiple subscribers
    public async Task Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent
    {
        IEnumerable<IEventHandler<TEvent>> handlers = _serviceProvider.GetServices<IEventHandler<TEvent>>();
        foreach (IEventHandler<TEvent> handler in handlers)
        {
            await handler.Handle(@event);
        }
    }
}

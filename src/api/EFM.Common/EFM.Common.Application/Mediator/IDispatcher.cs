using EFM.Common.Application.Commands;
using EFM.Common.Application.Queries;
using EFM.Common.Application.Results;
using EFM.Common.Domain.Abstractions;

namespace EFM.Common.Application.Mediator;

/// <summary>
/// Defines a contract for dispatching commands, requests, and domain events to their respective handlers.
/// </summary>
/// <remarks>This interface provides methods for sending commands and requests, as well as publishing domain
/// events. It is typically used to decouple the invocation of handlers from the calling code, enabling a mediator
/// pattern.</remarks>
public interface IDispatcher
{
    Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : class, ICommand;
    Task<TResult> Send<TRequest, TResult>(TRequest request, CancellationToken cancellationToken)
            where TRequest : class, IRequest<TResult>
            where TResult : Result;
    Task Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent;
}

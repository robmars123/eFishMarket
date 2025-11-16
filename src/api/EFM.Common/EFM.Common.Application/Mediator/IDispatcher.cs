using EFM.Common.Application.Commands;
using EFM.Common.Application.Queries;
using EFM.Common.Application.Results;
using EFM.Common.Domain.Abstractions;

namespace EFM.Common.Application.Mediator;
public interface IDispatcher
{
    Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : class, ICommand;
    Task<TResult> Send<TRequest, TResult>(TRequest request, CancellationToken cancellationToken)
            where TRequest : class, IRequest<TResult>
            where TResult : Result;
    Task Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent;
}

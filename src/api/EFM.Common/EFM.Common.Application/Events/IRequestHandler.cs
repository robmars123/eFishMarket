using EFM.Common.Domain.Abstractions;

namespace EFM.Common.Application.Events;
/// <summary>
/// Defines a handler for processing domain events of a specific type.
/// </summary>
/// <typeparam name="TEvent">The type of the domain event to handle. Must implement the <see cref="IDomainEvent"/> interface.</typeparam>
public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
{
    Task Handle(TEvent @event);
}

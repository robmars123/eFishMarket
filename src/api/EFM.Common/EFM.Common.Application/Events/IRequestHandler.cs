using EFM.Common.Domain.Abstractions;

namespace EFM.Common.Application.Events;
public interface IEventHandler<TEvent> where TEvent : IDomainEvent
{
    Task Handle(TEvent @event);
}

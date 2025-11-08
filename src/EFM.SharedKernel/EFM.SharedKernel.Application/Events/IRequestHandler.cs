using EFM.SharedKernel.Domain.Abstractions;

namespace EFM.SharedKernel.Application.Events;
public interface IEventHandler<TEvent> where TEvent : IDomainEvent
{
    Task Handle(TEvent @event);
}

namespace EFM.Common.Domain.Abstractions;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}

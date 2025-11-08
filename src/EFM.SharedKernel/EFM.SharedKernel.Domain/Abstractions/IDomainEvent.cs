namespace EFM.SharedKernel.Domain.Abstractions;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}

namespace EFM.Common.Application.Commands;

/// <summary>
/// Defines a contract for handling commands of a specific type.
/// </summary>
/// <remarks>Implementations of this interface are responsible for processing commands of the specified type. This
/// typically involves executing the associated business logic or operations defined by the command.</remarks>
/// <typeparam name="TCommand">The type of command to be handled. Must implement the <see cref="ICommand"/> interface.</typeparam>
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command, CancellationToken cancellationToken);
}

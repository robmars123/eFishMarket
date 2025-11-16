namespace EFM.Common.Application.Commands;

/// <summary>
/// Represents a command that can be executed.  This interface is typically used to define operations or actions in a
/// command-based architecture.
/// </summary>
/// <remarks>Implementations of this interface should encapsulate the logic for a specific operation or action.
/// ICommand is often used in patterns such as Command Query Responsibility Segregation (CQRS)  or in scenarios where
/// commands are dispatched to a handler for execution.</remarks>
public interface ICommand
{
    // This can be used to mark types that represent commands
}

/// <summary>
/// Represents an operation that can be executed and returns a result of the specified type.
/// </summary>
/// <typeparam name="TResult">The type of the result returned by the command.</typeparam>
public interface ICommand<TResult>
{
}

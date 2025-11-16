using Microsoft.Extensions.Logging;

namespace EFM.Common.Application.Logger;

/// <summary>
/// Provides logging functionality for processing commands of type <typeparamref name="TCommand"/>.
/// </summary>
/// <remarks>This class logs the start, completion, and any exceptions that occur during the processing of a
/// command. It is designed to work with commands that are associated with a specific module, where the module name is
/// derived from the fully qualified name of the command type.</remarks>
/// <typeparam name="TCommand">The type of the command being processed. Must be a reference type.</typeparam>
public sealed class CommandLogger<TCommand>
    where TCommand : class
{
    private readonly ILogger<CommandLogger<TCommand>> _logger;

    public CommandLogger(ILogger<CommandLogger<TCommand>> logger)
    {
        _logger = logger;
    }

    public async Task Handle(Func<Task> handler)
    {
        string moduleName = GetModuleName(typeof(TCommand).FullName!);
        string commandName = typeof(TCommand).Name;

        _logger.LogInformation("Processing command {CommandName} in module {Module}", commandName, moduleName);

        try
        {
            await handler();
            _logger.LogInformation("Completed command {CommandName}", commandName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Command {CommandName} in module {Module} failed with exception", commandName, moduleName);
            throw; // rethrow so upstream middleware can handle it too
        }
    }

    /// <summary>
    /// Extracts the module name from the specified request name.
    /// </summary>
    /// <param name="requestName">The fully qualified request name, expected to be in a dot-separated format.</param>
    /// <returns>The module name, which is the third segment of the dot-separated request name.</returns>
    private static string GetModuleName(string requestName) => requestName.Split('.')[2];
}

using Microsoft.Extensions.Logging;

namespace EFM.Common.Application.Logger;
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

    private static string GetModuleName(string requestName) => requestName.Split('.')[2];
}

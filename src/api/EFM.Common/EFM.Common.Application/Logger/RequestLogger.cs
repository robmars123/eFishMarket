using EFM.Common.Application.Results;
using Microsoft.Extensions.Logging;

namespace EFM.Common.Application.Logger;

public sealed class RequestLogger<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    private readonly ILogger<RequestLogger<TRequest, TResponse>> _logger;

    public RequestLogger(ILogger<RequestLogger<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        Func<Task<TResponse>> handler)
    {
        string moduleName = GetModuleName(typeof(TRequest).FullName!);
        string requestName = typeof(TRequest).Name;

        _logger.LogInformation("Processing request {RequestName} in module {Module}", requestName, moduleName);

        try
        {
            TResponse result = await handler();

            if (result.IsSuccess)
            {
                _logger.LogInformation("Completed request {RequestName}", requestName);
            }
            else
            {
                _logger.LogError("Completed request {RequestName} with error: {Error}", requestName, result.Error);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Request {RequestName} in module {Module} failed with exception", requestName, moduleName);
            throw; // rethrow so upstream middleware can handle it
        }
    }

    private static string GetModuleName(string requestName) => requestName.Split('.')[2];
}

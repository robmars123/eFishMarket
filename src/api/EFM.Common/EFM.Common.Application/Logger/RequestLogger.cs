using EFM.Common.Application.Results;
using Microsoft.Extensions.Logging;

namespace EFM.Common.Application.Logger;

/// <summary>
/// Provides a logging wrapper for handling requests and responses, capturing key information such as request processing
/// status, errors, and exceptions.
/// </summary>
/// <remarks>This class is designed to log the lifecycle of a request, including its initiation, success, or
/// failure. It uses the provided <see cref="ILogger"/> instance to log informational messages, errors, and exceptions.
/// The logging includes the request name, the module name derived from the request's fully qualified type name, and any
/// error details if the response indicates failure.</remarks>
/// <typeparam name="TRequest">The type of the request being processed. Must be a reference type.</typeparam>
/// <typeparam name="TResponse">The type of the response returned by the handler. Must inherit from <see cref="Result"/>.</typeparam>
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

    /// <summary>
    /// Extracts the module name from the specified request name.
    /// </summary>
    /// <param name="requestName">The fully qualified request name, expected to be in a dot-separated format.</param>
    /// <returns>The module name, which is the third segment of the dot-separated request name.</returns>
    private static string GetModuleName(string requestName) => requestName.Split('.')[2];
}

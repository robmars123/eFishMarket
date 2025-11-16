using System.Globalization;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EFM.Common.Infrastructure.Logging;

/// <summary>
/// Configures the specified <see cref="IHostBuilder"/> to use Serilog with Seq as the logging provider.
/// </summary>
/// <remarks>This method initializes a Serilog logger with default console logging and Seq integration.  The
/// logger is configured to enrich log events with contextual information and uses the invariant culture for formatting.
/// The <paramref name="seqUrl"/> parameter specifies the Seq server endpoint for log event ingestion.</remarks>
public static class LoggingExtensions
{
    public static void AddSerilogWithSeq(this IHostBuilder hostBuilder, Uri seqUrl)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
            .WriteTo.Seq(
                serverUrl: seqUrl.ToString(),
                formatProvider: CultureInfo.InvariantCulture) // <-- added here
            .CreateLogger();

        hostBuilder.UseSerilog();
    }
}

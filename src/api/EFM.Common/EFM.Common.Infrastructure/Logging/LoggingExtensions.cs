using System.Globalization;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EFM.Common.Infrastructure.Logging;
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

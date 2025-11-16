using EFM.Common.Application.Clock;

namespace EFM.Common.Infrastructure.Clock;

/// <summary>
/// This class provides the current UTC date and time that can be used throughout the application.
/// </summary>
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

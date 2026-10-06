using System.Globalization;

namespace NextGenOS.Hub;

/// <summary>The time, so that tests can set it.</summary>
public interface IClock
{
    DateTimeOffset UtcNow { get; }
}

public sealed class SystemClock : IClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}

/// <summary>A clock that stands still until moved.</summary>
public sealed class FixedClock(DateTimeOffset start) : IClock
{
    public DateTimeOffset UtcNow { get; private set; } = start;

    public void Set(DateTimeOffset value) => UtcNow = value;

    public void Advance(TimeSpan by) => UtcNow += by;
}

public static class Iso
{
    /// <summary>The way every time is stored: UTC, to the second.</summary>
    public static string Text(DateTimeOffset value) => value.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss'Z'", CultureInfo.InvariantCulture);

    public static DateTimeOffset Parse(string text) => DateTimeOffset.Parse(text, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
}

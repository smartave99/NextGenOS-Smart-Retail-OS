namespace SmartRetail.Pos.Tests;

/// <summary>A clock stopped at one moment, in Indian Standard Time.</summary>
internal sealed class FixedClock : TimeProvider
{
    private static readonly TimeZoneInfo India =
        TimeZoneInfo.CreateCustomTimeZone("IST", TimeSpan.FromHours(5.5), "India Standard Time", "India Standard Time");

    private readonly DateTimeOffset _now;

    public FixedClock(DateTimeOffset now) => _now = now;

    public override DateTimeOffset GetUtcNow() => _now.ToUniversalTime();

    public override TimeZoneInfo LocalTimeZone => India;
}

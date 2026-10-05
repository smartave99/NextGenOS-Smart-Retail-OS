namespace NextGenOS.Hub.Shop;

/// <summary>
/// The shop's own clock: its local day, which decides "today" in reports and when a library fine starts. The country pack names the zone in the IANA way
/// (Asia/Kolkata); Windows PCs know zones by other names, so the common ones are mapped. A zone that cannot be found falls back to UTC.
/// </summary>
public sealed class ShopTime
{
    private static readonly Dictionary<string, string> Windows = new(StringComparer.Ordinal)
    {
        ["Asia/Kolkata"] = "India Standard Time", /* white-label-ok: Windows names of time zones, for every country */ ["Asia/Manila"] = "Singapore Standard Time", ["Europe/London"] = "GMT Standard Time", ["Europe/Dublin"] = "GMT Standard Time",
        ["Europe/Berlin"] = "W. Europe Standard Time", ["Europe/Amsterdam"] = "W. Europe Standard Time", ["Europe/Rome"] = "W. Europe Standard Time",
        ["Europe/Paris"] = "Romance Standard Time", ["Europe/Madrid"] = "Romance Standard Time", ["Asia/Dubai"] = "Arabian Standard Time", ["Asia/Riyadh"] = "Arab Standard Time",
        ["Asia/Singapore"] = "Singapore Standard Time", ["Asia/Kuala_Lumpur"] = "Singapore Standard Time", ["Asia/Bangkok"] = "SE Asia Standard Time",
        ["Asia/Jakarta"] = "SE Asia Standard Time", ["Asia/Ho_Chi_Minh"] = "SE Asia Standard Time", ["Asia/Dhaka"] = "Bangladesh Standard Time",
        ["Asia/Karachi"] = "Pakistan Standard Time", ["Asia/Colombo"] = "Sri Lanka Standard Time", ["Asia/Kathmandu"] = "Nepal Standard Time",
        ["Australia/Sydney"] = "AUS Eastern Standard Time", ["Pacific/Auckland"] = "New Zealand Standard Time", ["America/Toronto"] = "Eastern Standard Time",
        ["America/New_York"] = "Eastern Standard Time", ["America/Mexico_City"] = "Central Standard Time (Mexico)", ["Africa/Johannesburg"] = "South Africa Standard Time",
        ["Africa/Nairobi"] = "E. Africa Standard Time", ["Africa/Lagos"] = "W. Central Africa Standard Time", ["Africa/Cairo"] = "Egypt Standard Time",
        ["Asia/Tokyo"] = "Tokyo Standard Time", ["Asia/Seoul"] = "Korea Standard Time", ["Asia/Shanghai"] = "China Standard Time", ["Asia/Hong_Kong"] = "China Standard Time",
        ["Europe/Istanbul"] = "Turkey Standard Time",
    };

    private readonly TimeZoneInfo _zone;

    public ShopTime(string ianaId)
    {
        Id = ianaId;
        _zone = Find(ianaId);
    }

    public string Id { get; }

    public TimeZoneInfo Zone => _zone;

    private static TimeZoneInfo Find(string iana)
    {
        foreach (var id in new[] { iana, Windows.GetValueOrDefault(iana) })
        {
            if (string.IsNullOrEmpty(id)) continue;
            try { return TimeZoneInfo.FindSystemTimeZoneById(id); } catch (TimeZoneNotFoundException) { } catch (InvalidTimeZoneException) { }
        }
        return TimeZoneInfo.Utc;
    }

    public DateTimeOffset ToLocal(DateTimeOffset utc) => TimeZoneInfo.ConvertTime(utc, _zone);

    public DateOnly LocalDate(DateTimeOffset utc) => DateOnly.FromDateTime(ToLocal(utc).DateTime);

    /// <summary>The instant (UTC) at which a local day begins.</summary>
    public DateTimeOffset StartOfDay(DateOnly date)
    {
        var local = DateTime.SpecifyKind(date.ToDateTime(TimeOnly.MinValue), DateTimeKind.Unspecified);
        return new DateTimeOffset(TimeZoneInfo.ConvertTimeToUtc(local, _zone), TimeSpan.Zero);
    }

    /// <summary>The instant (UTC) at which the next local day begins: a day is [StartOfDay(d), StartOfNextDay(d)).</summary>
    public DateTimeOffset StartOfNextDay(DateOnly date) => StartOfDay(date.AddDays(1));

    /// <summary>The instant (UTC) of a local date and time of day.</summary>
    public DateTimeOffset At(DateOnly date, TimeOnly time)
    {
        var local = DateTime.SpecifyKind(date.ToDateTime(time), DateTimeKind.Unspecified);
        if (_zone.IsInvalidTime(local)) local = local.AddHours(1);
        return new DateTimeOffset(TimeZoneInfo.ConvertTimeToUtc(local, _zone), TimeSpan.Zero);
    }
}

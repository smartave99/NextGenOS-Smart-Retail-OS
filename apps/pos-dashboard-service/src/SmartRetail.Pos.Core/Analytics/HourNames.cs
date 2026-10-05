namespace SmartRetail.Pos.Core.Analytics;

/// <summary>Hours of the day as people say them, written as the app writes times: "9 am", "6–8 pm".</summary>
public static class HourNames
{
    /// <summary>"9 am", "12 pm" (noon), "6 pm", "12 am" (midnight); 24 is the midnight that ends the day.</summary>
    public static string Of(int hour)
    {
        var h = (hour % 24 + 24) % 24;
        return (h % 12 == 0 ? 12 : h % 12).ToString(System.Globalization.CultureInfo.InvariantCulture) + (h < 12 ? " am" : " pm");
    }

    /// <summary>From the start of hour <paramref name="from"/> to the start of hour <paramref name="to"/>: "6–8 pm",
    /// "11 am–1 pm".</summary>
    public static string Range(int from, int to)
    {
        var start = Of(from);
        var end = Of(to);
        return start[^2..] == end[^2..] ? start[..^3] + "–" + end : start + "–" + end;
    }
}

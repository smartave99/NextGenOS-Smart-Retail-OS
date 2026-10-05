using System.Globalization;
using SmartRetail.Pos.Core;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Dates and percentages the way an Indian shop writes them.</summary>
public static class Formats
{
    private static readonly CultureInfo India = CultureInfo.GetCultureInfo("en-IN");

    public static string Date(DateTime value) => value.ToString("d MMM yyyy", India);
    public static string DateAndTime(DateTime value) => value.ToString("d MMM yyyy, h:mm tt", India);

    /// <summary>The existing POS stores bill dates without a time of day; show those as just the date.</summary>
    public static string BillDate(DateTime value) => value.TimeOfDay == TimeSpan.Zero ? Date(value) : DateAndTime(value);
    public static string Time(DateTime value) => value.ToString("h:mm tt", India);
    public static string Time(TimeOnly value) => value.ToString("h:mm tt", India);

    /// <summary>"15 Sep 2026, 6:57 PM" when the bill's time is known, else just its date.</summary>
    public static string BillWhen(InvoiceSummary bill) =>
        bill.Time is { } time ? Date(bill.Date) + ", " + Time(time) : BillDate(bill.Date);

    /// <summary>"6 PM", "6–8 PM".</summary>
    public static string Hour(int hour) => HourNames.Of(hour);
    public static string Hours(int from, int to) => HourNames.Range(from, to);
    public static string TimeWithSeconds(DateTime value) => value.ToString("h:mm:ss tt", India);
    public static string LongDate(DateOnly value) => value.ToString("dddd, d MMMM yyyy", India);
    public static string DayName(DateOnly value) => value.ToString("ddd", India);
    /// <summary>A count with Indian grouping: 1,23,456.</summary>
    public static string Count(int value) => value.ToString("N0", India);

    public static string Percent(decimal value) => value.ToString("0.##", CultureInfo.InvariantCulture) + "%";

    public static string ShortDate(DateOnly value) => value.ToString("d MMM", India);
    public static string Date(DateOnly value) => value.ToString("d MMM yyyy", India);
    public static string MonthName(int year, int month) => new DateOnly(year, month, 1).ToString("MMM yyyy", India);

    /// <summary>A price as a shop writes it on a sticker: ₹28, or ₹27.50 when it has paise. Never rounded.</summary>
    public static string Price(decimal amount) => Money.FormatCompact(amount);

    /// <summary>Whole rupees with Indian grouping: ₹1,23,457.</summary>
    public static string Rupees(decimal amount) => Money.FormatCompact(Money.RoundToRupee(amount));

    /// <summary>Short amounts for chart axes and tight spaces: ₹950, ₹12.4k, ₹3.2L, ₹1.1Cr.</summary>
    public static string Compact(decimal amount)
    {
        var sign = amount < 0 ? "-" : "";
        var value = Math.Abs(amount);
        return sign + (value switch
        {
            < 1000m => "₹" + value.ToString("0", CultureInfo.InvariantCulture),
            < 100000m => "₹" + (value / 1000m).ToString("0.#", CultureInfo.InvariantCulture) + "k",
            < 10000000m => "₹" + (value / 100000m).ToString("0.##", CultureInfo.InvariantCulture) + "L",
            _ => "₹" + (value / 10000000m).ToString("0.##", CultureInfo.InvariantCulture) + "Cr",
        });
    }

    /// <summary>A share such as 0.325 as "33%", small ones with a decimal ("0.9%"), tiny ones as "&lt;0.1%".</summary>
    public static string Share(decimal? share) => share switch
    {
        null => "–",
        > 0m and < 0.001m => "<0.1%",
        < 0.1m => (share.Value * 100m).ToString("0.#", CultureInfo.InvariantCulture) + "%",
        _ => (share.Value * 100m).ToString("0", CultureInfo.InvariantCulture) + "%",
    };

    /// <summary>A change such as 0.12 as "▲ 12%"; under half a percent as "same"; null (nothing to compare
    /// with) as "new".</summary>
    public static string Change(decimal? change) => change switch
    {
        null => "new",
        > -0.005m and < 0.005m => "same",
        > 0m => "▲ " + (change.Value * 100m).ToString("0", CultureInfo.InvariantCulture) + "%",
        _ => "▼ " + Math.Abs(change.Value * 100m).ToString("0", CultureInfo.InvariantCulture) + "%",
    };

    /// <summary>The CSS class for a change: "trend-up", "trend-down", or "" when there is nothing to show.</summary>
    public static string ChangeTone(decimal? change) => change switch
    {
        null or (> -0.005m and < 0.005m) => "",
        > 0m => "trend-up",
        _ => "trend-down",
    };

    public static decimal? Growth(decimal now, decimal before) => before > 0 ? (now - before) / before : null;


    /// <summary>A value in a result table: numbers with Indian grouping, dates in words, empty as "–".</summary>
    public static string Cell(object? value) => value switch
    {
        null => "–",
        string text => text,
        bool flag => flag ? "Yes" : "No",
        DateTime date => BillDate(date),
        DateTimeOffset date => BillDate(date.DateTime),
        decimal number => Number(number),
        double number when double.IsFinite(number) => Number((decimal)number),
        float number when float.IsFinite(number) => Number((decimal)number),
        byte or short or int or long => Number(Convert.ToDecimal(value, CultureInfo.InvariantCulture)),
        _ => Convert.ToString(value, CultureInfo.InvariantCulture) ?? "",
    };

    /// <summary>1234567.5 as "12,34,567.5"; whole numbers without decimals.</summary>
    private static string Number(decimal value)
    {
        var text = Money.FormatAmount(value);
        return text.EndsWith(".00", StringComparison.Ordinal) ? text[..^3] : text.EndsWith('0') && text.Contains('.') ? text[..^1] : text;
    }

    public static string Days(decimal? days) => days switch
    {
        null => "–",
        >= 10m => days.Value.ToString("0", CultureInfo.InvariantCulture),
        _ => days.Value.ToString("0.#", CultureInfo.InvariantCulture),
    };
}

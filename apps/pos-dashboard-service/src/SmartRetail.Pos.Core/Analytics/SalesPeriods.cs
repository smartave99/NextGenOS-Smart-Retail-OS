using SmartRetail.Pos.Core.Abstractions;

namespace SmartRetail.Pos.Core.Analytics;

public enum SalesPeriod
{
    Last7Days,
    Last30Days,
    Last90Days,
    ThisMonth,
    ThisFinancialYear,
    Last12Months,
}

/// <summary>The periods the sales dashboard offers, and where they start and end.</summary>
public static class SalesPeriods
{
    /// <summary>With no bill for longer than this, periods end on the latest bill instead of today.</summary>
    public const int QuietDays = 3;

    private static readonly (SalesPeriod Period, string Key, string Label)[] Choices =
    {
        (SalesPeriod.Last7Days, "7d", "7 days"),
        (SalesPeriod.Last30Days, "30d", "30 days"),
        (SalesPeriod.Last90Days, "90d", "90 days"),
        (SalesPeriod.ThisMonth, "month", "This month"),
        (SalesPeriod.ThisFinancialYear, "fy", "This financial year"),
        (SalesPeriod.Last12Months, "12m", "12 months"),
    };

    public static SalesPeriod Default => SalesPeriod.Last30Days;

    public static IReadOnlyList<SalesPeriod> All { get; } = Choices.Select(c => c.Period).ToList();

    public static string Key(SalesPeriod period) => Choices.First(c => c.Period == period).Key;

    public static string Label(SalesPeriod period) => Choices.First(c => c.Period == period).Label;

    /// <summary>Reads a key such as "30d" from a link; anything else gives the default.</summary>
    public static SalesPeriod Parse(string? key) =>
        Choices.FirstOrDefault(c => string.Equals(c.Key, key?.Trim(), StringComparison.OrdinalIgnoreCase)) is { Key: not null } choice
            ? choice.Period
            : Default;

    /// <summary>The last day of every period: today, or the day of the latest bill when the POS has been quiet
    /// for more than <see cref="QuietDays"/> days (a copy of the database, or a shop closed for a while), so a
    /// report is never a row of empty days.</summary>
    public static DateOnly EndDay(DateOnly today, BillSpan? bills) =>
        bills is { } span && span.Last < today.AddDays(-QuietDays) ? span.Last : today;

    /// <summary>The days of <paramref name="period"/> up to <paramref name="end"/>, never starting before the
    /// first bill.</summary>
    public static DateRange Range(SalesPeriod period, DateOnly end, BillSpan? bills = null)
    {
        var range = period switch
        {
            SalesPeriod.Last7Days => DateRange.Ending(end, 7),
            SalesPeriod.Last90Days => DateRange.Ending(end, 90),
            SalesPeriod.ThisMonth => new DateRange(new DateOnly(end.Year, end.Month, 1), end),
            SalesPeriod.ThisFinancialYear => new DateRange(new DateOnly(FinancialYear.StartYear(end), 4, 1), end),
            SalesPeriod.Last12Months => DateRange.Ending(end, 365),
            _ => DateRange.Ending(end, 30),
        };

        return bills is { } span && span.First > range.From && span.First <= end ? new DateRange(span.First, end) : range;
    }
}

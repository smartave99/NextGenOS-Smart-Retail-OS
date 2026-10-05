namespace SmartRetail.Pos.Core.Analytics;

/// <summary>
/// The Today screen: today against the same day last week, the last 7 days against the 7 before them, and the
/// day of the week that sells most.
/// </summary>
public sealed record TodayFigures
{
    /// <summary>Days of sales, ending today, that <see cref="From(DateOnly, IEnumerable{TrendPoint})"/> needs: four full weeks plus today.</summary>
    public const int DaysNeeded = 29;

    /// <summary>A busiest day is only named when it sells at least this much more than the other days.</summary>
    public const decimal BusiestDayMinimumLift = 0.15m;

    public DateOnly Day { get; init; }
    public decimal Sales { get; init; }
    public int Bills { get; init; }
    public decimal AverageBill => Bills == 0 ? 0m : Sales / Bills;

    public decimal SameDayLastWeek { get; init; }

    /// <summary>Today against the same weekday a week ago; null when that day sold nothing.</summary>
    public decimal? ChangeVsLastWeek { get; init; }

    /// <summary>The 7 days ending today, days without bills included.</summary>
    public IReadOnlyList<TrendPoint> Week { get; init; } = Array.Empty<TrendPoint>();

    public decimal WeekSales { get; init; }
    public decimal PreviousWeekSales { get; init; }

    /// <summary>The last 7 days against the 7 before them; null when those sold nothing.</summary>
    public decimal? WeekChange { get; init; }

    /// <summary>Over the four full weeks before today; null when there is too little to go on or no day stands out.</summary>
    public BusiestDay? Busiest { get; init; }

    /// <summary>The time now, when bill times are known: <see cref="ChangeVsLastWeek"/> then compares today with the
    /// same day last week up to this time.</summary>
    public TimeOnly? ComparedAt { get; init; }

    /// <summary>What the same day last week had sold by <see cref="ComparedAt"/>.</summary>
    public decimal? LastWeekByNow { get; init; }

    /// <summary>When today's latest bill was made; null when none of today's bills has a time.</summary>
    public TimeOnly? LastBillAt { get; init; }

    /// <summary>Today and the same day last week, hour by hour, from the earliest hour either had a bill to the latest
    /// (and on to now once today has one); empty when no bill of either day has a time.</summary>
    public IReadOnlyList<TodayHour> Hours { get; init; } = Array.Empty<TodayHour>();

    /// <param name="daily">Sales per day; days that are missing count as no sales.</param>
    public static TodayFigures From(DateOnly today, IEnumerable<TrendPoint> daily)
    {
        ArgumentNullException.ThrowIfNull(daily);
        var byDay = daily
            .GroupBy(point => point.Day)
            .ToDictionary(group => group.Key, group => (Sales: group.Sum(p => p.Sales), Bills: group.Sum(p => p.Bills)));
        (decimal Sales, int Bills) On(DateOnly day) => byDay.TryGetValue(day, out var value) ? value : (0m, 0);

        var week = DateRange.Ending(today, 7).EachDay().Select(day => new TrendPoint(day, On(day).Sales, On(day).Bills, 0m)).ToList();
        var weekSales = week.Sum(point => point.Sales);
        var previousWeekSales = DateRange.Ending(today.AddDays(-7), 7).EachDay().Sum(day => On(day).Sales);
        var lastWeek = On(today.AddDays(-7)).Sales;

        return new TodayFigures
        {
            Day = today,
            Sales = On(today).Sales,
            Bills = On(today).Bills,
            SameDayLastWeek = lastWeek,
            ChangeVsLastWeek = Change(On(today).Sales, lastWeek),
            Week = week,
            WeekSales = weekSales,
            PreviousWeekSales = previousWeekSales,
            WeekChange = Change(weekSales, previousWeekSales),
            Busiest = FindBusiestDay(DateRange.Ending(today.AddDays(-1), DaysNeeded - 1), day => On(day).Sales),
        };
    }

    /// <summary>Last week's same day may miss a few bill times (typed in on a later day) and still be compared by the
    /// time of day: at most this share of its bills.</summary>
    public const decimal MostUntimedBills = 0.1m;

    /// <param name="now">The time now: today, and how far into it.</param>
    /// <param name="daily">Sales per day; days that are missing count as no sales.</param>
    /// <param name="times">Today's bills and the same day's last week, with when the POS saved them; null or empty
    /// when not known. Then today is compared with last week by this time and shown by the hour.</param>
    public static TodayFigures From(DateTime now, IEnumerable<TrendPoint> daily, IReadOnlyCollection<BillTime>? times)
    {
        var today = DateOnly.FromDateTime(now);
        var figures = From(today, daily);
        if (times is null || times.Count == 0)
        {
            return figures;
        }

        var clock = TimeOnly.FromDateTime(now);
        var madeToday = times.Where(t => t.Day == today && t.Time is not null).ToList();
        var lastWeek = times.Where(t => t.Day == today.AddDays(-7)).ToList();
        var madeLastWeek = lastWeek.Where(t => t.Time is not null).ToList();
        if (lastWeek.Count > 0 && lastWeek.Count - madeLastWeek.Count <= lastWeek.Count * MostUntimedBills)
        {
            var byNow = madeLastWeek.Where(t => t.Time <= clock).Sum(t => t.Total);
            figures = figures with { ComparedAt = clock, LastWeekByNow = byNow, ChangeVsLastWeek = Change(figures.Sales, byNow) };
        }

        if (madeToday.Count + madeLastWeek.Count == 0)
        {
            return figures;
        }

        var todayByHour = ByHour(madeToday);
        var lastWeekByHour = ByHour(madeLastWeek);
        var hours = todayByHour.Keys.Concat(lastWeekByHour.Keys).ToList();
        var first = hours.Min();
        var last = Math.Max(hours.Max(), madeToday.Count > 0 ? clock.Hour : 0);
        return figures with
        {
            LastBillAt = madeToday.Count > 0 ? madeToday.Max(t => t.Time) : null,
            Hours = Enumerable.Range(first, last - first + 1)
                .Select(hour =>
                {
                    var (sales, bills) = todayByHour.GetValueOrDefault(hour);
                    var (before, billsBefore) = lastWeekByHour.GetValueOrDefault(hour);
                    return new TodayHour(hour, sales, bills, before, billsBefore);
                })
                .ToList(),
        };
    }

    private static Dictionary<int, (decimal Sales, int Bills)> ByHour(IEnumerable<BillTime> bills) =>
        bills.GroupBy(t => t.Time!.Value.Hour).ToDictionary(g => g.Key, g => (g.Sum(t => t.Total), g.Count()));

    private static decimal? Change(decimal now, decimal before) => before > 0 ? (now - before) / before : null;

    private static BusiestDay? FindBusiestDay(DateRange weeks, Func<DateOnly, decimal> salesOn)
    {
        // Today is still going, so only whole days count; and at least half of them must have sold something.
        var days = weeks.EachDay().ToList();
        if (days.Count(day => salesOn(day) > 0) < days.Count / 2)
        {
            return null;
        }

        var averages = days
            .GroupBy(day => day.DayOfWeek)
            .Select(group => (Day: group.Key, Average: group.Average(salesOn)))
            .OrderByDescending(entry => entry.Average)
            .ThenBy(entry => ((int)entry.Day + 6) % 7)
            .ToList();
        var busiest = averages[0];
        var others = averages.Skip(1).Average(entry => entry.Average);
        if (others <= 0)
        {
            return null;
        }

        var lift = busiest.Average / others - 1m;
        return lift >= BusiestDayMinimumLift ? new BusiestDay(busiest.Day, busiest.Average, lift) : null;
    }
}

/// <param name="Lift">How much more it sells than the average of the other days, e.g. 0.5 for 50% more.</param>
public sealed record BusiestDay(DayOfWeek Day, decimal AverageSales, decimal Lift);

/// <summary>One hour of today, with the same hour of the same day last week.</summary>
/// <param name="Hour">0 to 23: 18 is from 6 to 7 PM.</param>
public sealed record TodayHour(int Hour, decimal Sales, int Bills, decimal LastWeekSales, int LastWeekBills);

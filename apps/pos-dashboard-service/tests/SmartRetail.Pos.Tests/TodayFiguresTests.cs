using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Tests;

public class TodayFiguresTests
{
    // Saturday 26 September 2026.
    private static readonly DateOnly Today = new(2026, 9, 26);

    private static TrendPoint Day(DateOnly day, decimal sales, int bills = 1) => new(day, sales, bills, 0m);

    /// <summary>Four weeks and today: 1,000 a day, 2,000 on Sundays.</summary>
    private static List<TrendPoint> SteadyWeeks() =>
        DateRange.Ending(Today, TodayFigures.DaysNeeded).EachDay()
            .Select(day => Day(day, day.DayOfWeek == DayOfWeek.Sunday ? 2000m : 1000m, 4))
            .ToList();

    [Fact]
    public void Today_is_compared_with_the_same_day_last_week()
    {
        var days = new[] { Day(Today, 1150m, 5), Day(Today.AddDays(-7), 1000m), Day(Today.AddDays(-1), 9000m) };

        var figures = TodayFigures.From(Today, days);

        Assert.Equal(1150m, figures.Sales);
        Assert.Equal(5, figures.Bills);
        Assert.Equal(230m, figures.AverageBill);
        Assert.Equal(1000m, figures.SameDayLastWeek);
        Assert.Equal(0.15m, figures.ChangeVsLastWeek);
    }

    [Fact]
    public void No_change_is_given_when_last_week_sold_nothing()
    {
        var figures = TodayFigures.From(Today, new[] { Day(Today, 500m) });

        Assert.Null(figures.ChangeVsLastWeek);
        Assert.Null(figures.WeekChange);
        Assert.Equal(500m, figures.AverageBill);
    }

    [Fact]
    public void The_week_has_seven_days_ending_today_with_empty_days_filled_in()
    {
        var days = new[] { Day(Today.AddDays(-6), 100m), Day(Today, 300m), Day(Today.AddDays(-9), 400m) };

        var figures = TodayFigures.From(Today, days);

        Assert.Equal(7, figures.Week.Count);
        Assert.Equal(Today.AddDays(-6), figures.Week[0].Day);
        Assert.Equal(Today, figures.Week[^1].Day);
        Assert.Equal(new[] { 100m, 0m, 0m, 0m, 0m, 0m, 300m }, figures.Week.Select(p => p.Sales));
        Assert.Equal(400m, figures.WeekSales);
        Assert.Equal(400m, figures.PreviousWeekSales);
        Assert.Equal(0m, figures.WeekChange);
    }

    [Fact]
    public void Days_given_twice_are_added_up()
    {
        var figures = TodayFigures.From(Today, new[] { Day(Today, 100m, 1), Day(Today, 50m, 2) });

        Assert.Equal(150m, figures.Sales);
        Assert.Equal(3, figures.Bills);
    }

    [Fact]
    public void The_busiest_day_is_the_one_that_sells_clearly_more()
    {
        var figures = TodayFigures.From(Today, SteadyWeeks());

        Assert.NotNull(figures.Busiest);
        Assert.Equal(DayOfWeek.Sunday, figures.Busiest!.Day);
        Assert.Equal(2000m, figures.Busiest.AverageSales);
        Assert.Equal(1m, figures.Busiest.Lift);
    }

    [Fact]
    public void Today_does_not_count_towards_the_busiest_day()
    {
        // A huge Saturday so far today, but Saturdays are ordinary.
        var days = SteadyWeeks().Where(p => p.Day != Today).Append(Day(Today, 50000m)).ToList();

        Assert.Equal(DayOfWeek.Sunday, TodayFigures.From(Today, days).Busiest!.Day);
    }

    [Fact]
    public void No_busiest_day_when_the_days_are_alike()
    {
        var days = DateRange.Ending(Today, TodayFigures.DaysNeeded).EachDay()
            .Select(day => Day(day, day.DayOfWeek == DayOfWeek.Sunday ? 1100m : 1000m))
            .ToList();

        Assert.Null(TodayFigures.From(Today, days).Busiest);
    }

    [Fact]
    public void No_busiest_day_with_too_few_days_of_sales()
    {
        var days = SteadyWeeks().Where(p => p.Day > Today.AddDays(-10)).ToList();

        Assert.Null(TodayFigures.From(Today, days).Busiest);
    }
}

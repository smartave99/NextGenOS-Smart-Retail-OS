using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Bills;

namespace SmartRetail.Pos.Tests;

public class BillTimeTests
{
    // Saturday 26 September 2026, 11:40 AM.
    private static readonly DateTime Now = new(2026, 9, 26, 11, 40, 0);
    private static readonly DateOnly Today = DateOnly.FromDateTime(Now);
    private static readonly DateOnly LastWeek = Today.AddDays(-7);

    private static BillTime At(DateOnly day, int hour, int minute, decimal total) => new(day, day.ToDateTime(new TimeOnly(hour, minute)), total);

    private static TrendPoint Day(DateOnly day, decimal sales, int bills) => new(day, sales, bills, 0m);

    [Fact]
    public void A_bill_saved_on_its_own_date_was_made_then()
    {
        var day = new DateOnly(2026, 9, 24);

        Assert.Equal(new TimeOnly(18, 45, 10), BillTimes.TimeOf(day, new DateTime(2026, 9, 24, 18, 45, 10)));
        Assert.False(BillTimes.EnteredLater(day, new DateTime(2026, 9, 24, 23, 59, 0)));
    }

    [Fact]
    public void A_bill_typed_in_on_a_later_day_has_no_time_of_sale()
    {
        var day = new DateOnly(2026, 9, 24);

        Assert.Null(BillTimes.TimeOf(day, new DateTime(2026, 9, 25, 10, 5, 0)));
        Assert.True(BillTimes.EnteredLater(day, new DateTime(2026, 9, 25, 10, 5, 0)));
        Assert.Null(BillTimes.TimeOf(day, null));
        Assert.False(BillTimes.EnteredLater(day, null));
        // Saved before its date: a time the bill was not made at.
        Assert.Null(BillTimes.TimeOf(day, new DateTime(2026, 9, 23, 20, 0, 0)));
        Assert.False(BillTimes.EnteredLater(day, new DateTime(2026, 9, 23, 20, 0, 0)));
    }

    [Fact]
    public void A_bill_in_a_list_shows_the_time_from_the_pos_log()
    {
        var bill = new InvoiceSummary { Date = new DateTime(2026, 9, 24), SavedAt = new DateTime(2026, 9, 24, 18, 45, 10) };

        Assert.Equal(new TimeOnly(18, 45, 10), bill.Time);
        Assert.False(bill.EnteredLater);
        Assert.True((bill with { SavedAt = new DateTime(2026, 9, 26, 9, 0, 0) }).EnteredLater);
    }

    [Theory]
    [InlineData(0, "12 am")]
    [InlineData(9, "9 am")]
    [InlineData(12, "12 pm")]
    [InlineData(18, "6 pm")]
    [InlineData(24, "12 am")]
    public void Hours_are_named_as_people_say_them(int hour, string expected) => Assert.Equal(expected, HourNames.Of(hour));

    [Theory]
    [InlineData(18, 20, "6–8 pm")]
    [InlineData(11, 13, "11 am–1 pm")]
    [InlineData(9, 10, "9–10 am")]
    [InlineData(22, 24, "10 pm–12 am")]
    public void Hour_ranges_share_am_or_pm_when_they_can(int from, int to, string expected) => Assert.Equal(expected, HourNames.Range(from, to));

    [Fact]
    public void Today_is_compared_with_last_week_by_this_time()
    {
        var times = new[]
        {
            At(Today, 9, 5, 200), At(Today, 10, 30, 300), At(Today, 11, 35, 100),
            At(LastWeek, 9, 50, 150), At(LastWeek, 11, 39, 250), At(LastWeek, 11, 41, 400), At(LastWeek, 19, 0, 900),
        };

        var figures = TodayFigures.From(Now, new[] { Day(Today, 600, 3), Day(LastWeek, 1700, 4) }, times);

        Assert.Equal(new TimeOnly(11, 40), figures.ComparedAt);
        Assert.Equal(400m, figures.LastWeekByNow);
        Assert.Equal(0.5m, figures.ChangeVsLastWeek);
        Assert.Equal(1700m, figures.SameDayLastWeek);
        Assert.Equal(new TimeOnly(11, 35), figures.LastBillAt);
    }

    [Fact]
    public void Today_by_the_hour_runs_from_the_first_bill_of_either_day_to_the_last()
    {
        var times = new[] { At(Today, 10, 30, 300), At(Today, 10, 45, 100), At(LastWeek, 9, 50, 150), At(LastWeek, 19, 0, 900) };

        var figures = TodayFigures.From(Now, new[] { Day(Today, 400, 2), Day(LastWeek, 1050, 2) }, times);

        Assert.Equal(Enumerable.Range(9, 11), figures.Hours.Select(h => h.Hour));
        Assert.Equal((400m, 2, 0m, 0), (figures.Hours[1].Sales, figures.Hours[1].Bills, figures.Hours[1].LastWeekSales, figures.Hours[1].LastWeekBills));
        Assert.Equal((0m, 150m), (figures.Hours[0].Sales, figures.Hours[0].LastWeekSales));
        Assert.Equal(900m, figures.Hours[^1].LastWeekSales);
    }

    [Fact]
    public void Once_today_has_a_bill_its_hours_run_on_to_now()
    {
        var evening = new DateTime(2026, 9, 26, 21, 10, 0);

        var figures = TodayFigures.From(evening, new[] { Day(Today, 300, 1) }, new[] { At(Today, 18, 0, 300) });

        Assert.Equal(new[] { 18, 19, 20, 21 }, figures.Hours.Select(h => h.Hour));
        // Nothing sold last week that day: nothing to compare with.
        Assert.Null(figures.ComparedAt);
        Assert.Null(figures.ChangeVsLastWeek);
    }

    [Fact]
    public void Last_week_with_many_bills_typed_in_later_is_compared_for_the_whole_day()
    {
        var later = new BillTime(LastWeek, LastWeek.AddDays(1).ToDateTime(new TimeOnly(10, 0)), 500);
        var times = new[] { At(Today, 9, 0, 400), At(LastWeek, 9, 0, 300), later };

        var figures = TodayFigures.From(Now, new[] { Day(Today, 400, 1), Day(LastWeek, 800, 2) }, times);

        Assert.Null(figures.ComparedAt);
        Assert.Equal(-0.5m, figures.ChangeVsLastWeek);
    }

    [Fact]
    public void Without_bill_times_today_is_compared_with_last_weeks_whole_day()
    {
        var figures = TodayFigures.From(Now, new[] { Day(Today, 400, 1), Day(LastWeek, 800, 2) }, Array.Empty<BillTime>());

        Assert.Equal((-0.5m, (TimeOnly?)null, (TimeOnly?)null), (figures.ChangeVsLastWeek, figures.ComparedAt, figures.LastBillAt));
        Assert.Empty(figures.Hours);
    }

    [Fact]
    public void The_period_is_split_by_hour_with_the_busiest_two_hours()
    {
        var period = new DateRange(new DateOnly(2026, 9, 1), new DateOnly(2026, 9, 7));
        var facts = new SalesFacts
        {
            Range = period,
            Days = new[] { new DaySales { Day = new DateOnly(2026, 9, 1), Bills = 7, Sales = 1300 } },
            Hours = new[]
            {
                new HourSales { Day = new DateOnly(2026, 9, 1), Hour = 9, Bills = 1, Sales = 100 },
                new HourSales { Day = new DateOnly(2026, 9, 1), Hour = 12, Bills = 1, Sales = 200 },
                new HourSales { Day = new DateOnly(2026, 9, 2), Hour = 18, Bills = 2, Sales = 300 },
                new HourSales { Day = new DateOnly(2026, 9, 3), Hour = 19, Bills = 2, Sales = 400 },
                new HourSales { Day = new DateOnly(2026, 9, 8), Hour = 20, Bills = 9, Sales = 9000 }, // outside the period: ignored
            },
        };

        var report = SalesAnalysis.Analyse(facts, new SalesFacts { Range = period.Previous }, Array.Empty<ProductFacts>());

        Assert.Equal(Enumerable.Range(9, 11), report.Hours.Select(h => h.Hour));
        Assert.Equal((0m, 0), (report.Hours[1].Sales, report.Hours[1].Bills));
        Assert.Equal(0.3m, report.Hours.Single(h => h.Hour == 18).Share);
        Assert.Equal(6, report.TimedBills);
        Assert.Equal(new HourWindow(18, 20, 700m, 4, 0.7m), report.BusiestHours);
    }

    [Fact]
    public void Without_bill_times_there_are_no_hours()
    {
        var period = new DateRange(new DateOnly(2026, 9, 1), new DateOnly(2026, 9, 7));

        var report = SalesAnalysis.Analyse(new SalesFacts { Range = period }, new SalesFacts { Range = period.Previous }, Array.Empty<ProductFacts>());

        Assert.Empty(report.Hours);
        Assert.Null(report.BusiestHours);
    }

    [Fact]
    public void The_ai_summary_gives_the_hours_as_shares_only()
    {
        var period = new DateRange(new DateOnly(2026, 9, 1), new DateOnly(2026, 9, 7));
        var facts = new SalesFacts
        {
            Range = period,
            Days = new[] { new DaySales { Day = new DateOnly(2026, 9, 1), Bills = 5, Sales = 1000 } },
            Hours = new[]
            {
                new HourSales { Day = new DateOnly(2026, 9, 1), Hour = 10, Bills = 1, Sales = 250 },
                new HourSales { Day = new DateOnly(2026, 9, 1), Hour = 18, Bills = 3, Sales = 750 },
            },
        };

        var brief = SalesBrief.Write(SalesAnalysis.Analyse(facts, new SalesFacts { Range = period.Previous }, Array.Empty<ProductFacts>()));

        Assert.Contains("SALES BY HOUR OF DAY (share of sales; the time is known for 80% of bills)", brief);
        Assert.Contains("- 10 am 25%, 11 am 0%, 12 pm 0%", brief);
        // The hour before sold nothing, so the busiest time is the one hour.
        Assert.Contains("- Busiest: 6–7 pm, 75% of sales", brief);
    }

    [Fact]
    public void The_spreadsheet_gets_the_time_from_the_pos_log()
    {
        var bill = new InvoiceSummary { Number = "GST-1", Date = new DateTime(2026, 9, 24), SavedAt = new DateTime(2026, 9, 24, 18, 45, 10), GrandTotal = 10 };

        Assert.Equal("GST-1,2026-09-24,18:45,,10.00,10.00,0.00", BillCsv.Row(bill));
        Assert.Equal("GST-1,2026-09-24,,,10.00,10.00,0.00", BillCsv.Row(bill with { SavedAt = new DateTime(2026, 9, 26, 9, 0, 0) }));
    }
}

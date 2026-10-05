using SmartRetail.Pos.Core.Actions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Tests;

/// <summary>Whether an action changed sales, on hand-worked figures.</summary>
public class ActionMeasureTests
{
    private static DateOnly D(int year, int month, int day) => new(year, month, day);

    private static WindowFigures Window(DateOnly from, DateOnly to, decimal sales, decimal? beforeTax = null, decimal? profit = null, int bills = 100) => new()
    {
        Range = new DateRange(from, to),
        Sales = sales,
        Bills = bills,
        LineSales = sales,
        LineSalesBeforeTax = beforeTax ?? sales,
        CostedSalesBeforeTax = profit is null ? 0m : beforeTax ?? sales,
        Profit = profit ?? 0m,
    };

    private static readonly ShopAction Rickshaw = new()
    {
        Title = "E-rickshaw ads around the market",
        Kind = ActionKind.Advert,
        Start = D(2025, 10, 1),
        End = D(2025, 10, 30),
        Cost = 6000m,
    };

    [Fact]
    public void A_rise_beyond_the_season_is_what_the_action_added_with_its_profit_against_its_cost()
    {
        // ₹12,600 a day against ₹11,480 before is 10% more; last year the same dates were 3% up on the days before
        // them, so about 6.6% came from the ads: ₹23,268 more sales, and at 90% before GST and a 15% margin,
        // ₹3,141 more profit, short of the ₹6,000 spent.
        var result = ActionMeasure.Judge(Rickshaw, D(2025, 11, 5),
            during: Window(D(2025, 10, 1), D(2025, 10, 30), 378000m, beforeTax: 340200m, profit: 51030m),
            before: Window(D(2025, 9, 1), D(2025, 9, 30), 344400m),
            lastYear: Window(D(2024, 10, 1), D(2024, 10, 30), 309000m),
            lastYearBefore: Window(D(2024, 9, 1), D(2024, 9, 30), 300000m));

        Assert.Equal(ActionVerdict.Rose, result.Verdict);
        Assert.Equal(0.03m, result.Season);
        Assert.Equal(23268m, result.ExtraSales);
        Assert.Equal(3141.18m, result.ExtraProfit);
        Assert.False(result.PaidBack);
        Assert.Equal("Sales a day: ₹12,600, 10% more than the 30 days before (₹11,480). Last year these dates were 3% up on the days before them. "
            + "So it seems to have added about 7%. About ₹23,268 more in sales and ₹3,141 more profit, for ₹6,000 spent: it did not pay for itself.", result.Summary);
        Assert.Equal("E-rickshaw ads around the market (advertising, 1–30 Oct 2025, ₹6,000): sales about 7% above the season, about ₹3,141 more profit; it did not pay for itself.", result.Lesson);
    }

    [Fact]
    public void Without_last_year_a_fall_is_measured_against_the_days_before()
    {
        var moved = new ShopAction { Title = "Moved the counter", Kind = ActionKind.Display, Start = D(2025, 10, 1), End = D(2025, 10, 14) };

        var result = ActionMeasure.Judge(moved, D(2025, 10, 20),
            during: Window(D(2025, 10, 1), D(2025, 10, 14), 126000m),
            before: Window(D(2025, 9, 17), D(2025, 9, 30), 140000m));

        Assert.Equal(ActionVerdict.Fell, result.Verdict);
        Assert.Null(result.Season);
        Assert.Equal("Sales a day: ₹9,000, 10% less than the 14 days before (₹10,000). The POS has no bills from these dates last year, so the season is not allowed for. "
            + "So sales were about 10% lower than before.", result.Summary);
        Assert.Equal("Moved the counter (display or placement, 1–14 Oct 2025): sales about 10% below before.", result.Lesson);
    }

    [Fact]
    public void A_small_change_for_some_products_is_no_clear_change()
    {
        var counter = new ShopAction { Title = "Maggi at the counter", Kind = ActionKind.Display, Start = D(2025, 10, 1), ProductIds = new[] { 5 } };

        var result = ActionMeasure.Judge(counter, D(2025, 10, 15),
            during: Window(D(2025, 10, 1), D(2025, 10, 14), 1400m),
            before: Window(D(2025, 9, 17), D(2025, 9, 30), 1358m),
            lastYear: Window(D(2024, 10, 1), D(2024, 10, 14), 1400m),
            lastYearBefore: Window(D(2024, 9, 17), D(2024, 9, 30), 1400m));

        Assert.Equal(ActionVerdict.NoClearChange, result.Verdict);
        Assert.Equal("Its products' sales a day: ₹100, 3% more than the 14 days before (₹97). Last year these dates were about the same as the days before them. "
            + "So no clear change came from it.", result.Summary);
        Assert.Equal("Maggi at the counter (display or placement, 1–14 Oct 2025 so far, for some products): no clear change in sales.", result.Lesson);
    }

    [Fact]
    public void Before_a_week_is_over_it_is_too_early_to_tell()
    {
        var running = Rickshaw with { End = null };

        Assert.Equal("Starts on 1 Oct. Its figures come a week after that.", ActionMeasure.Judge(running, D(2025, 9, 20), null, null).Summary);
        Assert.Equal("It starts today. Its figures come after a week.", ActionMeasure.Judge(running, D(2025, 10, 1), null, null).Summary);
        var early = ActionMeasure.Judge(running, D(2025, 10, 4), Window(D(2025, 10, 1), D(2025, 10, 3), 40000m), Window(D(2025, 9, 28), D(2025, 9, 30), 30000m));
        Assert.Equal((ActionVerdict.TooEarly, "Too early to tell: 3 days so far. The figures come after a week."), (early.Verdict, early.Summary));
        Assert.Null(early.Lesson);
        Assert.Equal(ActionVerdict.NothingToCompare, ActionMeasure.Judge(running, D(2025, 10, 20), Window(D(2025, 10, 1), D(2025, 10, 19), 40000m), null).Verdict);
    }

    [Fact]
    public void A_product_that_seldom_sells_has_too_few_sales_to_tell()
    {
        // ₹3 a day from 2 bills before, none during: not a 100% fall, just too little to go on.
        var slow = new ShopAction { Title = "Slow item at the front", Start = D(2026, 8, 1), End = D(2026, 8, 31), ProductIds = new[] { 9 } };

        var result = ActionMeasure.Judge(slow, D(2026, 9, 10),
            during: Window(D(2026, 8, 1), D(2026, 8, 31), 0m, bills: 0),
            before: Window(D(2026, 7, 1), D(2026, 7, 31), 93m, bills: 2));

        Assert.Equal(ActionVerdict.TooFewSales, result.Verdict);
        Assert.Equal("Too few sales to tell: 2 bills with its products in the 31 days before it, and a change needs at least 10 to mean something.", result.Summary);
        Assert.Null(result.Lesson);
    }

    [Fact]
    public void Its_days_run_to_its_end_or_to_yesterday_as_today_is_not_over()
    {
        Assert.Null(ActionMeasure.DaysSoFar(Rickshaw, D(2025, 10, 1)));
        Assert.Equal(new DateRange(D(2025, 10, 1), D(2025, 10, 9)), ActionMeasure.DaysSoFar(Rickshaw, D(2025, 10, 10)));
        Assert.Equal(new DateRange(D(2025, 10, 1), D(2025, 10, 29)), ActionMeasure.DaysSoFar(Rickshaw, D(2025, 10, 30)));
        Assert.Equal(new DateRange(D(2025, 10, 1), D(2025, 10, 30)), ActionMeasure.DaysSoFar(Rickshaw, D(2026, 1, 1)));
        Assert.Equal(new DateRange(D(2024, 10, 1), D(2024, 10, 30)), ActionMeasure.YearBefore(new DateRange(D(2025, 10, 1), D(2025, 10, 30))));
    }

    [Fact]
    public void The_figures_are_the_whole_shops_or_its_products()
    {
        var facts = new SalesFacts
        {
            Range = new DateRange(D(2025, 10, 1), D(2025, 10, 2)),
            Days = new[]
            {
                new DaySales { Day = D(2025, 10, 1), Bills = 10, Sales = 1000m, Returns = 50m },
                new DaySales { Day = D(2025, 10, 2), Bills = 12, Sales = 1100m },
            },
            ProductDays = new[]
            {
                new ProductDaySales { Day = D(2025, 10, 1), ProductId = 5, Qty = 4, Sales = 120m, SalesBeforeTax = 100m, CostedSalesBeforeTax = 100m, Cost = 80m, Bills = 3 },
                new ProductDaySales { Day = D(2025, 10, 2), ProductId = 5, Qty = 2, Sales = 60m, SalesBeforeTax = 50m, Bills = 2 },
                new ProductDaySales { Day = D(2025, 10, 2), ProductId = 7, Qty = 1, Sales = 1920m, SalesBeforeTax = 1600m, CostedSalesBeforeTax = 1600m, Cost = 1200m, Bills = 1 },
            },
        };

        var shop = WindowFigures.From(facts, Array.Empty<int>());
        var product = WindowFigures.From(facts, new[] { 5 });

        Assert.Equal((2050m, 22, 2100m, 1750m, 420m, 1700m), (shop.Sales, shop.Bills, shop.LineSales, shop.LineSalesBeforeTax, shop.Profit, shop.CostedSalesBeforeTax));
        Assert.Equal((180m, 5, 6m, 20m, 100m, 90m), (product.Sales, product.Bills, product.Qty, product.Profit, product.CostedSalesBeforeTax, product.SalesPerDay));

        // Two products on one day: 2 and 1 bills may be the same bill, so without the POS's count it is at least 2
        // that day, never 3; with the POS's count, that count.
        var both = new[] { 5, 7 };
        Assert.Equal(5, WindowFigures.From(facts, both).Bills);
        Assert.Equal(4, WindowFigures.From(facts, both, billsWithProducts: 4).Bills);
        Assert.Equal(22, WindowFigures.From(facts, Array.Empty<int>(), billsWithProducts: 4).Bills);
    }

    [Theory]
    [InlineData("", "Say what the shop did.")]
    [InlineData("Ads", null)]
    public void An_action_needs_a_name(string title, string? problem) =>
        Assert.Equal(problem, (Rickshaw with { Title = title }).Problem());

    [Fact]
    public void An_action_cannot_end_before_it_starts() =>
        Assert.Equal("It ends before it starts.", (Rickshaw with { End = D(2025, 9, 1) }).Problem());

    [Theory]
    [InlineData("advert", ActionKind.Advert)]
    [InlineData("new-product", ActionKind.NewProduct)]
    [InlineData("Discount", ActionKind.Offer)]
    [InlineData("festival", ActionKind.Other)]
    public void Kinds_are_read_from_words(string word, ActionKind kind) => Assert.Equal(kind, ActionKinds.Parse(word));
}

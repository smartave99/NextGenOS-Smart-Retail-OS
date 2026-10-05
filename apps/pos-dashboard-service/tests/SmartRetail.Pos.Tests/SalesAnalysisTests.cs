using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Tests;

public class SalesAnalysisTests
{
    // 1–14 Sep 2026 (a Tuesday to a Monday) against 18–31 Aug.
    private static readonly DateRange Period = new(new DateOnly(2026, 9, 1), new DateOnly(2026, 9, 14));

    private static readonly ProductFacts[] Catalog =
    {
        new() { Id = 1, Code = "R1", Name = "Rice 5 kg", Category = "Staples", StockInHand = 3, MinStock = 10, CostPrice = 400, SellingPrice = 600 },
        new() { Id = 2, Code = "T1", Name = "Tea 250 g", Category = "Beverages", StockInHand = 50, CostPrice = 100, SellingPrice = 200 },
        new() { Id = 3, Code = "S1", Name = "Soap", Category = "Personal Care", StockInHand = 20, CostPrice = 30, SellingPrice = 45 },
        new() { Id = 4, Code = "P1", Name = "Pen", Category = "Stationery", StockInHand = 5, CostPrice = 0, SellingPrice = 10 },
        new() { Id = 5, Code = "E1", Name = "Earring", Category = "Fashion", StockInHand = -4, CostPrice = 20, SellingPrice = 50 },
        new() { Id = 6, Code = "N1", Name = "New Mug", Category = "Home", StockInHand = 10, CostPrice = 80, SellingPrice = 120, AddedOn = new DateOnly(2026, 9, 10) },
        new() { Id = 7, Code = "O1", Name = "Old Stock", Category = "Home", StockInHand = 9, CostPrice = 5, SellingPrice = 8, Active = false },
    };

    private static SalesFacts Current => new()
    {
        Range = Period,
        Days = new[]
        {
            new DaySales { Day = Sep(1), Bills = 2, Sales = 1000 },
            new DaySales { Day = Sep(5), Bills = 3, Sales = 3000, Returns = 100, Outstanding = 200 },
            new DaySales { Day = Sep(12), Bills = 1, Sales = 500 },
            new DaySales { Day = Sep(20), Bills = 9, Sales = 9999 }, // outside the period: ignored
        },
        ProductDays = new[]
        {
            Line(Sep(1), product: 1, qty: 1, sales: 600, beforeTax: 570, cost: 400),
            Line(Sep(1), product: 2, qty: 2, sales: 400, beforeTax: 380, cost: 200),
            Line(Sep(5), product: 1, qty: 3, sales: 1800, beforeTax: 1710, cost: 1200, bills: 3),
            Line(Sep(5), product: 2, qty: 6, sales: 1200, beforeTax: 1140, cost: 0, costed: 0, bills: 2),
            Line(Sep(12), product: 5, qty: 10, sales: 500, beforeTax: 500, cost: 200),
        },
        Payments = new[]
        {
            new PaymentTotal { Mode = "By Cash", Payments = 3, Amount = 3000 },
            new PaymentTotal { Mode = "Cash", Payments = 1, Amount = 500 },
            new PaymentTotal { Mode = "Google Pay", Payments = 1, Amount = 700 },
            new PaymentTotal { Mode = "Credit Terms - 7 days", Payments = 1, Amount = 300 },
        },
        Customers = new[]
        {
            new CustomerFacts { Id = 1, Name = "Cash", Bills = 3, Sales = 2000, FirstBillEver = new DateOnly(2026, 3, 15), LastBill = Sep(12) },
            new CustomerFacts { Id = 8, Name = "Asha Rao", Bills = 2, Sales = 1500, FirstBillEver = new DateOnly(2026, 1, 2), LastBill = Sep(5) },
            new CustomerFacts { Id = 9, Name = "Vikram Das", Bills = 1, Sales = 1000, FirstBillEver = Sep(5), LastBill = Sep(5) },
        },
    };

    private static SalesFacts Previous => new()
    {
        Range = Period.Previous,
        Days = new[] { new DaySales { Day = new DateOnly(2026, 8, 20), Bills = 2, Sales = 1500 } },
        ProductDays = new[]
        {
            Line(new DateOnly(2026, 8, 20), product: 1, qty: 2, sales: 1200, beforeTax: 1140, cost: 800),
            Line(new DateOnly(2026, 8, 20), product: 3, qty: 10, sales: 300, beforeTax: 285, cost: 300),
        },
    };

    private static SalesReport Report => SalesAnalysis.Analyse(Current, Previous, Catalog);

    [Fact]
    public void Totals_add_up_the_period_and_the_one_before()
    {
        var now = Report.Current;
        Assert.Equal((4500m, 100m, 4400m, 6, 3, 200m), (now.Sales, now.Returns, now.NetSales, now.Bills, now.DaysWithSales, now.Outstanding));
        Assert.Equal(750m, now.AverageBill);
        Assert.Equal(4300m, now.SalesBeforeTax);

        // Profit only where the purchase price is known: the tea sold on 5 Sep has none.
        Assert.Equal(3160m, now.CostedSalesBeforeTax);
        Assert.Equal(1160m, now.Profit);
        Assert.Equal(1160m / 3160m, now.ProfitMargin);
        Assert.Equal(3160m / 4300m, now.ProfitCoverage);

        // 8 product lines on 6 bills.
        Assert.Equal(8m / 6m, now.ProductsPerBill);

        Assert.Equal((1500m, 2), (Report.Previous.Sales, Report.Previous.Bills));
        Assert.Equal(new DateRange(new DateOnly(2026, 8, 18), new DateOnly(2026, 8, 31)), Report.PreviousRange);
    }

    [Fact]
    public void Every_day_is_on_the_trend_with_a_seven_day_average()
    {
        var daily = Report.Daily;

        Assert.Equal(14, daily.Count);
        Assert.Equal(Sep(1), daily[0].Day);
        Assert.Equal((0m, 0), (daily[1].Sales, daily[1].Bills));
        Assert.Equal(1000m / 7, daily[0].SevenDayAverage);
        Assert.Equal(4000m / 7, daily[6].SevenDayAverage);
        Assert.Equal(3000m / 7, daily[10].SevenDayAverage);
        Assert.Equal(500m / 7, daily[11].SevenDayAverage);
    }

    [Fact]
    public void Weekdays_average_the_days_since_the_first_sale()
    {
        var weekdays = Report.Weekdays;

        Assert.Equal(DayOfWeek.Monday, weekdays[0].Day);
        Assert.Equal(DayOfWeek.Sunday, weekdays[6].Day);
        var saturday = weekdays.Single(w => w.Day == DayOfWeek.Saturday);
        Assert.Equal((1750m, 2m, 2), (saturday.AverageSales, saturday.AverageBills, saturday.DaysCounted));
        var tuesday = weekdays.Single(w => w.Day == DayOfWeek.Tuesday);
        Assert.Equal((500m, 2), (tuesday.AverageSales, tuesday.DaysCounted));
    }

    [Fact]
    public void Top_products_show_share_profit_stock_and_change()
    {
        var top = Report.TopProducts;

        Assert.Equal(new[] { "Rice 5 kg", "Tea 250 g", "Earring" }, top.Select(p => p.Name));
        var rice = top[0];
        Assert.Equal((4m, 2400m, 4), (rice.Qty, rice.Sales, rice.Bills));
        Assert.Equal(2400m / 4500m, rice.Share);
        Assert.Equal(680m, rice.Profit);
        Assert.Equal(680m / 2280m, rice.ProfitMargin);
        Assert.Equal(3m / (4m / 14m), rice.DaysOfStock);
        Assert.Equal(1200m, rice.PreviousSales);
        Assert.Equal(1m, rice.Change);

        Assert.Null(top[1].Change);
        Assert.Equal(0m, top[2].DaysOfStock);
    }

    [Fact]
    public void Rising_and_falling_products_compare_with_the_period_before()
    {
        Assert.Equal(new[] { "Tea 250 g", "Rice 5 kg", "Earring" }, Report.Rising.Select(c => c.Name));
        var soap = Assert.Single(Report.Falling);
        Assert.Equal(("Soap", 0m, 300m, -300m, -1m), (soap.Name, soap.Sales, soap.PreviousSales, soap.Difference, soap.Change));
    }

    [Fact]
    public void Categories_rank_by_sales_with_margin_and_change()
    {
        var categories = Report.Categories;

        Assert.Equal(new[] { "Staples", "Beverages", "Fashion" }, categories.Select(c => c.Name));
        Assert.Equal(1m, categories[0].Change);
        Assert.Null(categories[1].Change);
        Assert.Equal(180m / 380m, categories[1].ProfitMargin);
        Assert.Equal(1, categories[0].ProductsSold);
    }

    [Fact]
    public void Slow_movers_are_active_stock_that_never_sold_most_money_first()
    {
        // Priced at purchase price, or selling price without one. The new mug, the inactive
        // product and the negative earring stock are left out.
        Assert.Equal(new[] { ("Soap", 600m), ("Pen", 50m) }, Report.SlowMovers.Select(s => (s.Name, s.StockValue)));
        Assert.Equal((2, 650m), (Report.SlowMoverCount, Report.MoneyInSlowStock));
    }

    [Fact]
    public void Good_sellers_running_out_are_listed_for_reordering()
    {
        // The earring's stock is gone too, but it sold on one bill only: not a seller worth reordering.
        Assert.Equal(new[] { "Rice 5 kg" }, Report.ReorderNow.Select(r => r.Name));
        Assert.Equal(4m / 14m, Report.ReorderNow[0].QtyPerDay);
        Assert.Equal(("Earring", -4m), (Report.NegativeStock.Single().Name, Report.NegativeStock.Single().StockInHand));
        Assert.Equal(1, Report.NegativeStockCount);
    }

    [Fact]
    public void Payments_are_grouped_into_cash_upi_card_and_credit()
    {
        Assert.Equal(
            new[] { ("Cash", 3500m, 4), ("UPI / wallet", 700m, 1), ("Credit", 300m, 1) },
            Report.Payments.Select(p => (p.Group, p.Amount, p.Payments)));
        Assert.Equal(3500m / 4500m, Report.Payments[0].Share);
    }

    [Theory]
    [InlineData("By Cash", "Cash")]
    [InlineData("CASH", "Cash")]
    [InlineData("PhonePe", "UPI / wallet")]
    [InlineData("Paytm", "UPI / wallet")]
    [InlineData("E-Wallet", "UPI / wallet")]
    [InlineData("By Credit Card", "Card")]
    [InlineData("By Debit Card", "Card")]
    [InlineData("By Cheque", "Cheque")]
    [InlineData("Credit Terms - 7 days", "Credit")]
    [InlineData("NEFT", "Bank transfer")]
    [InlineData("Coupon", "Other")]
    [InlineData(null, "Other")]
    public void Payment_modes_fall_into_simple_groups(string? mode, string group)
    {
        Assert.Equal(group, SalesAnalysis.PaymentGroup(mode));
    }

    [Fact]
    public void Customers_leave_out_the_walk_in_customer()
    {
        var customers = Report.Customers;

        Assert.Equal((2, 1, 1, 3), (customers.NamedCustomers, customers.RepeatCustomers, customers.NewCustomers, customers.WalkInBills));
        Assert.Equal(0.5m, customers.WalkInShare);
        Assert.Equal(new[] { "Asha Rao", "Vikram Das" }, Report.TopCustomers.Select(c => c.Name));
    }

    [Theory]
    [InlineData("Cash", 1, 5, true)]
    [InlineData("  walk-in   customer ", 1, 5, true)]
    [InlineData("Ramesh", 30, 100, true)]
    [InlineData("Ramesh", 10, 100, false)]
    [InlineData("Ramesh", 3, 5, false)]
    public void The_walk_in_customer_is_found_by_name_or_by_its_share_of_bills(string name, int bills, int billsInPeriod, bool walkIn)
    {
        Assert.Equal(walkIn, SalesAnalysis.IsWalkIn(new CustomerFacts { Name = name, Bills = bills }, billsInPeriod));
    }

    [Fact]
    public void Months_are_listed_even_without_sales_and_part_months_are_marked()
    {
        var range = new DateRange(new DateOnly(2026, 7, 15), new DateOnly(2026, 9, 30));
        var report = SalesAnalysis.Analyse(Current with { Range = range }, Previous with { Range = range.Previous }, Catalog);

        Assert.Equal(
            new[] { (7, 0m, true), (8, 0m, false), (9, 14499m, false) }, // 20 Sep is inside this range
            report.Monthly.Select(m => (m.Month, m.Sales, m.Partial)));
        Assert.Equal(1160m, report.Monthly[2].Profit);
    }

    [Fact]
    public void An_empty_period_gives_an_empty_report_without_errors()
    {
        var empty = new SalesFacts { Range = Period };
        var report = SalesAnalysis.Analyse(empty, new SalesFacts { Range = Period.Previous }, Array.Empty<ProductFacts>());

        Assert.Equal((0m, 0, 0m), (report.Current.Sales, report.Current.Bills, report.Current.AverageBill));
        Assert.Null(report.Current.ProfitMargin);
        Assert.Empty(report.TopProducts);
        Assert.Empty(report.Rising);
        Assert.Equal(14, report.Daily.Count);
        Assert.All(report.Weekdays, w => Assert.Equal(0m, w.AverageSales));
    }

    [Fact]
    public void Date_ranges_know_their_length_and_the_period_before()
    {
        var week = DateRange.Ending(new DateOnly(2026, 9, 7), 7);

        Assert.Equal((new DateOnly(2026, 9, 1), 7), (week.From, week.Days));
        Assert.Equal(new DateRange(new DateOnly(2026, 8, 25), new DateOnly(2026, 8, 31)), week.Previous);
        Assert.Equal(7, week.EachDay().Count());
        Assert.Throws<ArgumentException>(() => new DateRange(new DateOnly(2026, 9, 2), new DateOnly(2026, 9, 1)));
    }

    [Fact]
    public void The_brief_for_the_ai_has_the_figures_but_no_customer_names()
    {
        var brief = SalesBrief.Write(Report);

        Assert.Contains("Period: 1 Sep 2026 to 14 Sep 2026 (14 days)", brief);
        Assert.Contains("- Sales: ₹4,500 (before: ₹1,500, +200%)", brief);
        Assert.Contains("- Average bill: ₹750", brief);
        Assert.Contains("Profit before GST: ₹1,160, a margin of 37%", brief);
        Assert.Contains("- Rice 5 kg [Staples]: ₹2,400, qty 4, margin 30%, stock 3, 11 days, +100%", brief);
        Assert.Contains("Best day: Saturday", brief);
        Assert.Contains("NOT SELLING: 2 products", brief);
        Assert.Contains("STOCK RECORDS TO CORRECT: 1 products", brief);
        Assert.Contains("Cash 78%", brief);
        Assert.Contains("- Rice 5 kg: stock 3, sells 2 a week", brief);
        Assert.Contains("BY WEEK", brief);
        Assert.Contains("- 8 Sep 2026 to 14 Sep 2026: ₹500, 1 bills", brief);
        Assert.DoesNotContain("Asha", brief);
        Assert.DoesNotContain("Vikram", brief);
    }

    [Fact]
    public void The_brief_says_what_a_product_is_when_a_photo_taught_the_ai()
    {
        var brief = SalesBrief.Write(Report, id => id switch
        {
            1 => "a 5 kg bag of basmati rice",
            3 => new string('x', 120),
            _ => null,
        });

        Assert.Contains("- Rice 5 kg (a 5 kg bag of basmati rice) [Staples]: ₹2,400", brief);
        Assert.Contains("- Rice 5 kg (a 5 kg bag of basmati rice): stock 3", brief);
        Assert.Contains("- Soap (" + new string('x', 90) + "…): ₹0, before ₹300", brief);
        Assert.Contains("- Tea 250 g [Beverages]: ₹1,600", brief);
    }

    [Fact]
    public void The_plan_prompt_carries_the_brief_the_language_and_the_goal()
    {
        var prompt = GrowthPlanPrompt.UserPrompt("FIGURES HERE", PlanLanguage.Hindi, "  More sales on weekdays  ");

        Assert.StartsWith("THE SHOP'S FIGURES\nFIGURES HERE\n\nTHE OWNER'S GOAL\nMore sales on weekdays\n", prompt);
        Assert.Contains("Hindi (Devanagari script)", prompt);
        Assert.Contains("## Plan for the next 30 days", prompt);
        Assert.DoesNotContain("THE OWNER'S GOAL", GrowthPlanPrompt.UserPrompt("x", PlanLanguage.English));
        Assert.Contains("simple English", GrowthPlanPrompt.UserPrompt("x", PlanLanguage.English));
        Assert.Contains("Never invent numbers", GrowthPlanPrompt.SystemPrompt);
    }

    [Fact]
    public void The_plan_builds_on_what_the_shop_tried_before()
    {
        var memory = "About the shop:\n- E-rickshaw ads in Oct 2026 cost ₹6,000 and brought about 8% more bills.\n";

        var prompt = GrowthPlanPrompt.UserPrompt("FIGURES HERE", PlanLanguage.English, "More sales", memory);

        Assert.StartsWith("THE SHOP'S FIGURES\nFIGURES HERE\n\nWHAT YOU REMEMBER\nAbout the shop:\n- E-rickshaw ads in Oct 2026", prompt);
        Assert.Contains("Build on what worked before, and do not suggest again what did not.\n\nTHE OWNER'S GOAL\n", prompt);
        Assert.DoesNotContain("WHAT YOU REMEMBER", GrowthPlanPrompt.UserPrompt("x", PlanLanguage.English, memory: ""));
    }

    [Fact]
    public void The_plan_knows_what_the_shop_is_doing_already()
    {
        var prompt = GrowthPlanPrompt.UserPrompt("FIGURES HERE", PlanLanguage.English, doingNow: new[] { "E-rickshaw ads around the market (advertising, 1–30 Oct 2026, ₹6,000)" });

        Assert.Contains("\n\nWHAT THE SHOP IS DOING NOW\n- E-rickshaw ads around the market (advertising, 1–30 Oct 2026, ₹6,000)\nBuild around these; do not suggest them again.\n\n", prompt);
        Assert.DoesNotContain("DOING NOW", GrowthPlanPrompt.UserPrompt("x", PlanLanguage.English, doingNow: Array.Empty<string>()));
    }

    private static DateOnly Sep(int day) => new(2026, 9, day);

    private static ProductDaySales Line(DateOnly day, int product, decimal qty, decimal sales, decimal beforeTax, decimal cost, decimal? costed = null, int bills = 1) => new()
    {
        Day = day,
        ProductId = product,
        Qty = qty,
        Sales = sales,
        SalesBeforeTax = beforeTax,
        CostedSalesBeforeTax = costed ?? beforeTax,
        Cost = cost,
        Bills = bills,
    };
}

public class SalesPeriodsTests
{
    private static readonly DateOnly Today = new(2026, 9, 24);

    [Theory]
    [InlineData(SalesPeriod.Last7Days, "2026-09-18")]
    [InlineData(SalesPeriod.Last30Days, "2026-08-26")]
    [InlineData(SalesPeriod.Last90Days, "2026-06-27")]
    [InlineData(SalesPeriod.ThisMonth, "2026-09-01")]
    [InlineData(SalesPeriod.ThisFinancialYear, "2026-04-01")]
    [InlineData(SalesPeriod.Last12Months, "2025-09-25")]
    public void Periods_end_today_and_start_where_the_owner_expects(SalesPeriod period, string from)
    {
        Assert.Equal(new DateRange(DateOnly.Parse(from), Today), SalesPeriods.Range(period, Today));
    }

    [Fact]
    public void A_quiet_pos_ends_periods_on_its_latest_bill()
    {
        var copy = new BillSpan(new DateOnly(2026, 3, 15), new DateOnly(2026, 9, 15));

        Assert.Equal(new DateOnly(2026, 9, 15), SalesPeriods.EndDay(Today, copy));
        Assert.Equal(Today, SalesPeriods.EndDay(Today, copy with { Last = Today.AddDays(-3) }));
        Assert.Equal(Today, SalesPeriods.EndDay(Today, null));
    }

    [Fact]
    public void Periods_never_start_before_the_first_bill()
    {
        var bills = new BillSpan(new DateOnly(2026, 3, 15), new DateOnly(2026, 9, 15));

        Assert.Equal(new DateRange(bills.First, bills.Last), SalesPeriods.Range(SalesPeriod.Last12Months, bills.Last, bills));
        Assert.Equal(DateRange.Ending(bills.Last, 30), SalesPeriods.Range(SalesPeriod.Last30Days, bills.Last, bills));
    }

    [Theory]
    [InlineData("90d", SalesPeriod.Last90Days)]
    [InlineData(" FY ", SalesPeriod.ThisFinancialYear)]
    [InlineData("nonsense", SalesPeriod.Last30Days)]
    [InlineData(null, SalesPeriod.Last30Days)]
    public void Period_keys_from_links_are_read_safely(string? key, SalesPeriod period)
    {
        Assert.Equal(period, SalesPeriods.Parse(key));
        Assert.Equal(period, SalesPeriods.Parse(SalesPeriods.Key(period)));
    }
}

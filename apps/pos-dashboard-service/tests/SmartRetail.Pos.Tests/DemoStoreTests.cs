using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Billing;
using SmartRetail.Pos.Core.Bills;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Core.Models;
using SmartRetail.Pos.Data.Demo;

namespace SmartRetail.Pos.Tests;

public class DemoStoreTests
{
    private static readonly DateTimeOffset Now = new(2026, 9, 24, 11, 0, 0, TimeSpan.FromHours(5.5));
    private static readonly DateOnly Today = new(2026, 9, 24);

    private static DemoStore Store(bool seedSales = false) => new(new FixedClock(Now), seedSales);

    private static async Task<NewInvoice> InvoiceAsync(DemoStore store, DateTime when, string code, decimal qty,
        int? customerId = null, decimal? received = null)
    {
        var bill = new Bill();
        bill.Add((await store.FindByCodeAsync(code))!, qty);
        if (customerId is { } id)
        {
            bill.Customer = new Customer { Id = id, Name = "Customer " + id };
        }
        return bill.ToInvoice(PaymentModes.Cash, received ?? bill.Totals.GrandTotal, when);
    }

    [Fact]
    public async Task Seeded_shop_has_two_years_of_bills_up_to_now()
    {
        var store = Store(seedSales: true);

        Assert.Equal(5, (await store.GetSalesForDayAsync(Today)).BillCount);
        for (var daysAgo = 1; daysAgo < DemoStore.HistoryDays; daysAgo += 23)
        {
            var day = await store.GetSalesForDayAsync(Today.AddDays(-daysAgo));
            Assert.InRange(day.BillCount, 3, 25);
            Assert.True(day.Total > 0m);
        }
        Assert.Equal(0, (await store.GetSalesForDayAsync(Today.AddDays(-DemoStore.HistoryDays))).BillCount);
        Assert.Equal(new BillSpan(Today.AddDays(-(DemoStore.HistoryDays - 1)), Today), await store.GetBillSpanAsync());

        var bills = await store.GetRecentAsync(100_000);
        Assert.All(bills, b => Assert.Matches(@"^SR/\d\d-\d\d/\d{4}$", b.Number));
        Assert.All(bills, b => Assert.True(b.Date <= Now.DateTime, $"{b.Number} is dated after now"));
        Assert.Equal(bills.OrderByDescending(b => b.Date).ThenByDescending(b => b.Id).Select(b => b.Id), bills.Select(b => b.Id));

        var numbersInTimeOrder = bills.OrderBy(b => b.Date).ThenBy(b => b.Id).Select(b => b.Number).ToList();
        Assert.Equal(numbersInTimeOrder.Order(StringComparer.Ordinal), numbersInTimeOrder);
        Assert.StartsWith("SR/24-25/", numbersInTimeOrder[0]);
    }

    [Fact]
    public async Task Demo_sales_facts_add_up_to_its_bills()
    {
        var store = Store(seedSales: true);
        var range = DateRange.Ending(Today, 30);

        var facts = await store.GetFactsAsync(range);

        var bills = (await store.GetRecentAsync(100_000)).Where(b => range.Contains(DateOnly.FromDateTime(b.Date))).ToList();
        Assert.Equal(bills.Count, facts.Days.Sum(d => d.Bills));
        Assert.Equal(bills.Sum(b => b.GrandTotal), facts.Days.Sum(d => d.Sales));
        Assert.Equal(bills.Sum(b => b.GrandTotal - b.Balance), facts.Payments.Sum(p => p.Amount));
        Assert.Equal(bills.Count, facts.Customers.Sum(c => c.Bills));
        // Lines add up to the bills, give or take the rounding to whole rupees.
        Assert.InRange(facts.ProductDays.Sum(p => p.Sales) - facts.Days.Sum(d => d.Sales), -0.5m * bills.Count, 0.5m * bills.Count);
    }

    [Fact]
    public async Task Demo_bills_keep_their_time_apart_from_the_date_as_the_pos_does()
    {
        var store = Store(seedSales: true);

        var bills = await store.GetRecentAsync(100_000);

        Assert.All(bills, b => Assert.Equal(TimeSpan.Zero, b.Date.TimeOfDay));
        var later = Assert.Single(bills, b => b.EnteredLater);
        Assert.Equal(Today.AddDays(-2), DateOnly.FromDateTime(later.Date));
        var timed = bills.Where(b => b.Time is not null).ToList();
        Assert.Equal(bills.Count - 1, timed.Count);
        Assert.All(timed.Where(b => DateOnly.FromDateTime(b.Date) < Today), b => Assert.InRange(b.Time!.Value, new TimeOnly(9, 0), new TimeOnly(20, 59, 59)));
        // The evening rush: more bills from 6 to 8 PM than from 9 to 11 AM.
        Assert.True(timed.Count(b => b.Time!.Value.Hour is 18 or 19) > timed.Count(b => b.Time!.Value.Hour is 9 or 10) * 1.5);
    }

    [Fact]
    public async Task Demo_sales_by_hour_and_bill_times_add_up_to_its_bills()
    {
        var store = Store(seedSales: true);
        var range = DateRange.Ending(Today, 30);

        var facts = await store.GetFactsAsync(range);
        var times = await store.GetBillTimesAsync(range);

        var bills = (await store.GetRecentAsync(100_000)).Where(b => range.Contains(DateOnly.FromDateTime(b.Date))).ToList();
        Assert.Equal(bills.Count, times.Count);
        Assert.Equal(bills.Sum(b => b.GrandTotal), times.Sum(t => t.Total));
        Assert.Equal(bills.Count(b => b.Time is not null), facts.Hours.Sum(h => h.Bills));
        Assert.Equal(bills.Where(b => b.Time is not null).Sum(b => b.GrandTotal), facts.Hours.Sum(h => h.Sales));
        Assert.Equal(times.OrderBy(t => t.Day).ToList(), times);
    }

    [Fact]
    public async Task The_demo_shop_has_something_to_say_on_the_sales_dashboard()
    {
        var report = await Store(seedSales: true).LoadReportAsync(DateRange.Ending(Today, 30));

        Assert.Contains(report.SlowMovers, s => s.Name.StartsWith("Instant Coffee", StringComparison.Ordinal));
        Assert.Contains(report.SlowMovers, s => s.Name.StartsWith("Notebook", StringComparison.Ordinal));
        Assert.Contains(report.ReorderNow, r => r.Name.StartsWith("Toothpaste", StringComparison.Ordinal));
        var weekdays = report.Weekdays.ToDictionary(w => w.Day);
        Assert.True(weekdays[DayOfWeek.Saturday].AverageSales > weekdays[DayOfWeek.Monday].AverageSales);
        Assert.InRange(report.Current.ProfitMargin ?? 0m, 0.1m, 0.3m);
        Assert.Equal(1m, report.Current.ProfitCoverage);
        Assert.True(report.Customers.RepeatCustomers > 0);
        Assert.Contains(report.Payments, p => p.Group == "UPI / wallet");
        Assert.True(report.Previous.Sales > 0);
    }

    [Fact]
    public async Task Seeded_shop_is_the_same_every_time()
    {
        var first = await Store(seedSales: true).GetRecentAsync(1000);
        var second = await Store(seedSales: true).GetRecentAsync(1000);

        Assert.Equal(first, second);
    }

    [Fact]
    public async Task Bill_numbers_restart_each_financial_year()
    {
        var store = Store();

        var march = await store.SaveAsync(await InvoiceAsync(store, new DateTime(2027, 3, 31, 20, 0, 0), "1001", 1m));
        var april = await store.SaveAsync(await InvoiceAsync(store, new DateTime(2027, 4, 1, 9, 0, 0), "1001", 1m));
        var next = await store.SaveAsync(await InvoiceAsync(store, new DateTime(2027, 4, 1, 9, 5, 0), "1001", 1m));

        Assert.Equal("SR/26-27/0001", march.Number);
        Assert.Equal("SR/27-28/0001", april.Number);
        Assert.Equal("SR/27-28/0002", next.Number);
        Assert.True(march.Id < april.Id && april.Id < next.Id);
    }

    [Fact]
    public async Task Every_demo_bill_can_be_paged_searched_and_opened()
    {
        var store = Store(seedSales: true);
        var all = await store.GetRecentAsync(100_000);

        var first = await store.SearchAsync(new BillQuery { Take = 50 });
        var last = await store.SearchAsync(new BillQuery { Skip = all.Count - 1, Take = 50 });
        Assert.Equal(all.Count, first.Total);
        Assert.Equal(all.Take(50).Select(b => b.Id), first.Items.Select(b => b.Id));
        Assert.Equal(all[^1].Id, Assert.Single(last.Items).Id);
        Assert.Equal(all.Sum(b => b.GrandTotal), first.TotalAmount);
        Assert.Equal((all.Min(b => b.Date), all.Max(b => b.Date)), (first.First, first.Last));
        Assert.Equal(all.Max(b => b.Id), first.NewestId);
        Assert.Equal(all.Count - 1, (await store.SearchAsync(new BillQuery { UpToId = first.NewestId - 1 })).Total);
        Assert.Equal(5, (await store.SearchAsync(new BillQuery { From = Today, To = Today })).Total);
        Assert.Equal(all.Count, (await store.SearchAsync(new BillQuery { From = DateOnly.MinValue, To = DateOnly.MaxValue })).Total);
        Assert.Equal(all[10].Id, Assert.Single((await store.SearchAsync(new BillQuery { Text = all[10].Number })).Items).Id);

        var owed = await store.SearchAsync(new BillQuery { OnlyOwed = true, Take = BillQuery.MaxTake });
        Assert.NotEmpty(owed.Items);
        Assert.All(owed.Items, b => Assert.True(b.Balance > 0m));
        Assert.Equal(owed.Items.Sum(b => b.Balance), owed.TotalOwed);

        var bill = (await store.GetAsync(owed.Items[0].Id))!;
        Assert.Equal(owed.Items[0], bill.Summary);
        Assert.NotEmpty(bill.Items);
        Assert.Equal(bill.Summary.GrandTotal, bill.SubTotal + bill.RoundOff);
        Assert.Equal(bill.Summary.GrandTotal - bill.Summary.Balance, bill.Paid);
        Assert.Equal(bill.Paid, bill.Payments.Sum(p => p.Amount));
        Assert.Contains(bill.Summary, (await store.SearchAsync(new BillQuery { Text = bill.CustomerPhone, Take = BillQuery.MaxTake })).Items);
        Assert.Null(await store.GetAsync(0));
    }

    [Fact]
    public async Task Exporting_reads_every_bill_once_even_while_new_bills_come_in()
    {
        var store = Store(seedSales: true);
        var all = await store.GetRecentAsync(100_000);
        Assert.True(all.Count > BillQuery.MaxTake, "The demo shop should need more than one read.");

        var exported = new List<InvoiceSummary>();
        await foreach (var bill in store.AllAsync(new BillQuery()))
        {
            if (exported.Count == 10)
            {
                await store.SaveAsync(await InvoiceAsync(store, Now.DateTime, "1001", 1m));
            }

            exported.Add(bill);
        }

        Assert.Equal(all.Select(b => b.Id), exported.Select(b => b.Id));
        Assert.Empty(await ToListAsync(Store().AllAsync(new BillQuery())));
    }

    private static async Task<List<T>> ToListAsync<T>(IAsyncEnumerable<T> items)
    {
        var list = new List<T>();
        await foreach (var item in items)
        {
            list.Add(item);
        }

        return list;
    }

    [Fact]
    public async Task The_demo_shop_has_mistakes_for_the_checks_to_find()
    {
        var store = Store(seedSales: true);

        var findings = ShopChecks.Run(await store.LoadCheckFactsAsync(store, Today, pricesIncludeTax: true));

        var kinds = findings.Select(f => f.Kind).Distinct().ToList();
        Assert.Contains(FindingKind.BelowCost, kinds); // the biscuits' supplier raised the price
        Assert.Contains(FindingKind.SoldAtLoss, kinds);
        Assert.Contains(FindingKind.BigDiscount, kinds); // 40% off yesterday
        Assert.Contains(FindingKind.MissingBills, kinds); // a bill deleted three days ago
        Assert.Contains(FindingKind.OwedLong, kinds);
        var biscuits = findings.First(f => f.Kind == FindingKind.BelowCost);
        Assert.Equal(("Glucose Biscuits 200 g", FindingLevel.FixNow), (biscuits.Title, biscuits.Level));
        Assert.Equal(1, findings.Count(f => f.Kind == FindingKind.MissingBills));
    }

    [Fact]
    public async Task Saving_a_bill_lowers_stock_and_records_credit()
    {
        var store = Store();
        Assert.Equal(18m, (await store.FindByCodeAsync("1001"))!.StockInHand);

        var saved = await store.SaveAsync(await InvoiceAsync(store, Now.DateTime, "1001", 3m, customerId: 2, received: 1000m));

        Assert.Equal(15m, (await store.FindByCodeAsync("1001"))!.StockInHand);
        Assert.Equal(1647m, saved.GrandTotal);
        Assert.Equal(647m, saved.Balance);
        Assert.Equal(0m, saved.ChangeDue);

        var today = await store.GetSalesForDayAsync(Today);
        Assert.Equal((1, 1647m, 647m), (today.BillCount, today.Total, today.Outstanding));
        Assert.Equal("Customer 2", Assert.Single(await store.GetRecentAsync(10)).CustomerName);
    }

    [Fact]
    public async Task Bills_for_unknown_customers_or_without_items_are_refused()
    {
        var store = Store();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await store.SaveAsync(await InvoiceAsync(store, Now.DateTime, "1001", 1m, customerId: 999)));
        await Assert.ThrowsAsync<InvalidOperationException>(() => store.SaveAsync(new NewInvoice()));
        Assert.Empty(await store.GetRecentAsync(10));
    }

    [Theory]
    [InlineData("1001")]
    [InlineData(" 2000000000015 ")]
    public async Task Finds_a_product_by_exact_code_or_barcode(string code)
    {
        Assert.Equal("Basmati Rice 5 kg", (await Store().FindByCodeAsync(code))?.Name);
    }

    [Theory]
    [InlineData("NOPE")]
    [InlineData("100")]
    [InlineData("")]
    public async Task Partial_or_unknown_codes_find_nothing(string code)
    {
        Assert.Null(await Store().FindByCodeAsync(code));
    }

    [Fact]
    public async Task Product_search_matches_name_code_or_barcode_sorted_by_name()
    {
        var store = Store();

        Assert.Equal(new[] { "Milk Chocolate 50 g", "Toned Milk 500 ml" }, (await store.SearchAsync("MILK", 10)).Select(p => p.Name));
        Assert.Equal("Milk Chocolate 50 g", Assert.Single(await store.SearchAsync("1016", 10)).Name);
        Assert.Equal(
            new[] { "Ball Pen, pack of 5", "Basmati Rice 5 kg", "Bath Soap 4 × 100 g", "Bhujia 200 g", "Butter 100 g" },
            (await store.SearchAsync(null, 5)).Select(p => p.Name));
    }

    [Fact]
    public async Task Customer_search_matches_name_or_phone()
    {
        ICustomerRepository customers = Store();

        Assert.Equal("Lakshmi Iyer", Assert.Single(await customers.SearchAsync("iyer", 10)).Name);
        Assert.Equal("Anil Verma", Assert.Single(await customers.SearchAsync("0103", 10)).Name);
        Assert.Equal(8, (await customers.SearchAsync("", 10)).Count);
    }

    [Fact]
    public async Task Low_stock_puts_the_biggest_shortfall_first()
    {
        var low = await Store().GetLowStockAsync(10);

        Assert.Equal(
            new[] { "Toothpaste 150 g", "Sunflower Oil 1 L", "Floor Cleaner 1 L", "Whole Wheat Atta 5 kg", "Paneer 200 g" },
            low.Select(s => s.Name));
        Assert.Equal(new[] { 9m, 8m, 4m, 4m, 2m }, low.Select(s => s.Shortfall));
    }
}

using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;
using NextGenOS.Hub.Reports;

namespace NextGenOS.Hub.Tests;

public class ReportTests
{
    private static readonly DateOnly Day1 = new(2026, 10, 5);
    private static readonly DateOnly Day2 = new(2026, 10, 6);

    private static Item Product(HubFixture f, string name, string price, string taxClass = "standard", bool track = true) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = f.App.Shop.Current.Minor(price), TaxClass = taxClass, TrackStock = track });

    /// <summary>Two trading days: day 1 sells two rice (cash); day 2 sells a pen (card) and gives one rice back.</summary>
    private static (HubFixture F, Item Rice, Item Pen, DocumentView RiceSale) TwoDays()
    {
        var f = new HubFixture("IN", "retail");
        var rice = Product(f, "Rice", "118.00");
        var pen = Product(f, "Pen", "11.80");
        f.App.Catalog.Adjust(rice.Id, 10_000, "delivery");
        f.App.Catalog.Adjust(pen.Id, 50_000, "delivery");
        var sale = f.App.Documents.Checkout(new CheckoutRequest
        {
            Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 2000 } },
            Payments = { new PaymentInput { Method = "cash", AmountMinor = 23_600 } },
        });
        f.Clock.Set(f.Clock.UtcNow.AddDays(1));
        f.App.Documents.Checkout(new CheckoutRequest
        {
            Lines = { new LineInput { ItemId = pen.Id } },
            Payments = { new PaymentInput { Method = "card", AmountMinor = 1_180 } },
        });
        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1_000L) }, "wrong pack", "cash", null);
        return (f, rice, pen, sale);
    }

    [Fact]
    public void Daily_sales_are_listed_by_local_day_with_credit_notes_taken_off()
    {
        var (f, _, _, _) = TwoDays();
        using (f)
        {
            var days = f.App.Reports.DailySales(Day1, Day2);
            Assert.Equal(2, days.Count);
            Assert.Equal(Day1, days[0].Day);
            Assert.Equal((1, 20_000L, 3_600L, 23_600L, 0L), (days[0].Documents, days[0].NetMinor, days[0].TaxMinor, days[0].TotalMinor, days[0].RefundsMinor));
            // Day 2: a pen of 1,180 sold, 11,800 given back for one rice.
            Assert.Equal(Day2, days[1].Day);
            Assert.Equal(1, days[1].Documents);
            Assert.Equal(1_180 - 11_800, days[1].TotalMinor);
            Assert.Equal(11_800, days[1].RefundsMinor);
            Assert.Equal(1_000 - 10_000, days[1].NetMinor);
            Assert.Equal(180 - 1_800, days[1].TaxMinor);

            var summary = f.App.Reports.Summary(Day1, Day2);
            Assert.Equal(2, summary.Documents);
            Assert.Equal(23_600 + 1_180 - 11_800, summary.TotalMinor);
            Assert.Equal(11_800, summary.RefundsMinor);
            Assert.Equal(summary.TotalMinor / 2, summary.AverageMinor);
        }
    }

    [Fact]
    public void A_day_without_sales_is_not_listed_and_an_empty_period_gives_zeros()
    {
        using var f = new HubFixture("IN", "retail");
        Assert.Empty(f.App.Reports.DailySales(Day1, Day2));
        var summary = f.App.Reports.Summary(Day1, Day2);
        Assert.Equal((0, 0L, 0L), (summary.Documents, summary.TotalMinor, summary.AverageMinor));
        Assert.Empty(f.App.Reports.TopItems(Day1, Day2));
        Assert.Empty(f.App.Reports.TaxSummary(Day1, Day2));
        Assert.Empty(f.App.Reports.Payments(Day1, Day2));
    }

    [Fact]
    public void A_sale_just_before_midnight_in_the_shops_time_belongs_to_that_day()
    {
        // 23:50 in India on 5 October is 18:20 UTC the same day; 00:10 on the 6th is 18:40 UTC.
        using var f = new HubFixture("IN", "retail", now: new DateTimeOffset(2026, 10, 5, 18, 20, 0, TimeSpan.Zero));
        var pen = Product(f, "Pen", "11.80", track: false);
        void Sell() => f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = pen.Id } }, Payments = { new PaymentInput { AmountMinor = 1_180 } } });
        Sell();
        f.Clock.Set(new DateTimeOffset(2026, 10, 5, 18, 40, 0, TimeSpan.Zero));
        Sell();
        var days = f.App.Reports.DailySales(Day1, Day2);
        Assert.Equal(new[] { Day1, Day2 }, days.Select(d => d.Day).ToArray());
        Assert.All(days, d => Assert.Equal(1, d.Documents));
    }

    [Fact]
    public void Top_items_are_ranked_by_what_they_earned_after_returns()
    {
        var (f, _, _, _) = TwoDays();
        using (f)
        {
            var top = f.App.Reports.TopItems(Day1, Day2);
            // Rice: 2 sold, 1 returned = 1 left earning 118.00. Pen: 1 earning 11.80.
            Assert.Equal(new[] { "Rice", "Pen" }, top.Select(t => t.Name).ToArray());
            Assert.Equal((1_000L, 11_800L), (top[0].QtyMilli, top[0].RevenueMinor));
            Assert.Equal((1_000L, 1_180L), (top[1].QtyMilli, top[1].RevenueMinor));
            Assert.Single(f.App.Reports.TopItems(Day1, Day2, limit: 1));
        }
    }

    [Fact]
    public void The_tax_summary_gives_taxable_value_and_each_part_by_rate_with_returns_taken_off()
    {
        var (f, _, _, _) = TwoDays();
        using (f)
        {
            var row = Assert.Single(f.App.Reports.TaxSummary(Day1, Day2));
            Assert.Equal("GST18", row.Code);
            // Taxable: 200.00 + 10.00 - 100.00; each half of the tax: 18.00 + 0.90 - 9.00.
            Assert.Equal(11_000, row.TaxableMinor);
            Assert.Equal(new[] { "CGST", "SGST" }, row.Components.Select(c => c.Name).ToArray());
            Assert.All(row.Components, c => Assert.Equal(990, c.AmountMinor));
            Assert.Equal(1_980, row.TaxMinor);
        }
    }

    [Fact]
    public void The_tax_summary_agrees_with_the_totals_of_the_documents()
    {
        var (f, _, _, _) = TwoDays();
        using (f)
        {
            var summary = f.App.Reports.Summary(Day1, Day2);
            var tax = f.App.Reports.TaxSummary(Day1, Day2).Sum(r => r.TaxMinor);
            Assert.Equal(summary.TaxMinor, tax);
        }
    }

    [Fact]
    public void Payments_are_totalled_by_method_with_refunds_taken_off()
    {
        var (f, _, _, _) = TwoDays();
        using (f)
        {
            var payments = f.App.Reports.Payments(Day1, Day2).ToDictionary(p => p.Method, p => p.AmountMinor);
            Assert.Equal(23_600 - 11_800, payments["cash"]); // taken in, less the refund given in cash
            Assert.Equal(1_180, payments["card"]);
        }
    }

    [Fact]
    public void Money_owed_is_shown_by_how_late_it_is()
    {
        using var f = new HubFixture("IN", "wholesale");
        var item = Product(f, "Bulk rice", "100.00", "zero", track: false);
        var party = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Sharma Store", CreditLimitMinor = 10_000_000, TermsDays = 15 });
        void Credit(long amount)
        {
            var d = f.App.Documents.Checkout(new CheckoutRequest { PartyId = party.Id, Lines = { new LineInput { ItemId = item.Id, QtyMilli = amount / 100 * 10 } }, OnCredit = true });
            Assert.Equal(amount, d.Document.PayableMinor);
        }
        Credit(100_000);                                  // due 15 days after 5 Oct
        f.Clock.Set(f.Clock.UtcNow.AddDays(-60));
        Credit(200_000);                                  // 60 days earlier: due 20 Aug, so about 46 days late on 5 Oct
        f.Clock.Set(f.Clock.UtcNow.AddDays(60));

        var row = Assert.Single(f.App.Reports.Outstanding());
        Assert.Equal("Sharma Store", row.Name);
        Assert.Equal(100_000, row.CurrentMinor);          // not yet due
        Assert.Equal(200_000, row.Days60Minor);
        Assert.Equal(300_000, row.TotalMinor);
        Assert.Equal(row.TotalMinor, f.App.Documents.Outstanding(party.Id));

        var top = Assert.Single(f.App.Reports.TopCustomers(new DateOnly(2026, 8, 1), Day1));
        Assert.Equal((2, 300_000L), (top.Documents, top.TotalMinor));
    }

    [Fact]
    public void Stock_is_valued_at_cost_and_empty_shelves_are_left_out()
    {
        using var f = new HubFixture("IN", "retail");
        var tea = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Tea", PriceMinor = 20_000, CostMinor = 12_550, TrackStock = true });
        var gone = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Gone", PriceMinor = 100, CostMinor = 50, TrackStock = true });
        f.App.Catalog.Adjust(tea.Id, 2_500, "delivery");   // 2.5 packs
        var value = Assert.Single(f.App.Reports.StockValues());
        Assert.Equal("Tea", value.Name);
        Assert.Equal(31_375, value.ValueMinor);            // 2.5 x 125.50
    }

    [Fact]
    public void Purchases_received_and_still_unpaid_are_reported()
    {
        using var f = new HubFixture("IN", "wholesale");
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        var rice = Product(f, "Rice", "170.00", "zero");
        var po = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 10_000, CostMinor = 15_000 } });
        f.App.Purchasing.Receive(po.Document.Id);
        f.App.Purchasing.Pay(po.Document.Id, 50_000, "bank");
        var (received, unpaid) = f.App.Reports.Purchases(Day1, Day1);
        Assert.Equal(150_000, received);
        Assert.Equal(100_000, unpaid);
    }

    [Fact]
    public void A_report_written_as_a_file_quotes_awkward_text_and_defuses_spreadsheet_formulas()
    {
        var csv = Csv.Build(new[] { "Name", "Amount" }, new IReadOnlyList<object?>[]
        {
            new object?[] { "Plain", 12.5m },
            new object?[] { "Has, comma", 1 },
            new object?[] { "Says \"hello\"", 2 },
            new object?[] { "=HYPERLINK(\"http://example.invalid\")", 3 },
            new object?[] { "+1+1", 4 },
            new object?[] { "@SUM(A1)", 5 },
            new object?[] { null, -7 },                      // a number below zero is a number, not a formula
        });
        var lines = csv.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        Assert.Equal("Name,Amount", lines[0]);
        Assert.Equal("Plain,12.5", lines[1]);
        Assert.Equal("\"Has, comma\",1", lines[2]);
        Assert.Equal("\"Says \"\"hello\"\"\",2", lines[3]);
        Assert.StartsWith("\"'=HYPERLINK(", lines[4]);
        Assert.Equal("'+1+1,4", lines[5]);
        Assert.Equal("'@SUM(A1),5", lines[6]);
        Assert.Equal(",-7", lines[7]);
    }
}

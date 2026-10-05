using NextGenOS.Hub;
using NextGenOS.Hub.Demo;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;

namespace NextGenOS.Hub.Tests;

/// <summary>A sample company for every industry, in every country, made through the same services the screens use, then checked for sense.</summary>
public class DemoCompanyTests
{
    private static readonly DateTimeOffset Now = new(2026, 10, 5, 9, 30, 0, TimeSpan.Zero);

    public static IEnumerable<object[]> Industries() => IndustryCatalog.All().Select(p => new object[] { p.Id });

    public static IEnumerable<object[]> Countries() => PackCatalog.All().Select(p => new object[] { p.Country });

    private static (HubApp App, DemoSummary Summary, string Path) Make(string industry, string country, int days = 14)
    {
        var path = Path.Combine(Path.GetTempPath(), "hub-demo-" + Guid.NewGuid().ToString("N") + ".db");
        var summary = DemoCompany.Fill(path, new DemoOptions { Industry = industry, Country = country, Days = days }, Now);
        return (HubApp.Open(path, new FixedClock(Now)), summary, path);
    }

    private static void Cleanup(string path)
    {
        foreach (var file in new[] { path, path + "-wal", path + "-shm" })
        {
            try { File.Delete(file); } catch (IOException) { }
        }
    }

    [Theory]
    [MemberData(nameof(Industries))]
    public void A_shop_that_chose_its_own_ways_of_paying_still_gets_a_sample_company(string industry)
    {
        var path = Path.Combine(Path.GetTempPath(), "hub-demo-" + Guid.NewGuid().ToString("N") + ".db");
        try
        {
            var first = HubApp.Open(path, new FixedClock(Now));
            first.Shop.Save(new ShopSettings { Name = "Own ways", Country = "PH", Industry = industry, PaymentMethods = new List<string> { "gcash", "card" } });
            var summary = DemoCompany.Fill(path, new DemoOptions { Industry = industry, Country = "PH", Days = 7 }, Now);
            Assert.True(summary.Documents > 0);
            var app = HubApp.Open(path, new FixedClock(Now));
            Assert.Equal(new[] { "gcash", "card" }, app.Shop.Settings.PaymentMethods);
        }
        finally { Cleanup(path); }
    }

    [Theory]
    [MemberData(nameof(Industries))]
    public void Every_industry_makes_a_company_with_items_people_and_trading_history(string industry)
    {
        var (app, summary, path) = Make(industry, "IN");
        try
        {
            Assert.Equal(industry, summary.Industry);
            Assert.True(summary.Items > 0, "no items");
            Assert.True(summary.People > 0, "no people");
            Assert.True(summary.Documents > 0, "no documents");
            Assert.True(app.Shop.Settings.SetupDone);
            Assert.False(string.IsNullOrWhiteSpace(app.Shop.Settings.Name));
            Assert.Equal(summary.Company, app.Shop.Settings.Name);
            Assert.Equal(summary.Items, app.Catalog.Search(limit: 1000).Count);
        }
        finally { Cleanup(path); }
    }

    [Theory]
    [MemberData(nameof(Industries))]
    public void The_same_seed_makes_the_same_company(string industry)
    {
        var (a, first, pathA) = Make(industry, "IN");
        var (b, second, pathB) = Make(industry, "IN");
        try
        {
            Assert.Equal(first, second);
            Assert.Equal(Convert.ToInt64(a.Db.Scalar("SELECT COALESCE(SUM(total_minor), 0) FROM documents")), Convert.ToInt64(b.Db.Scalar("SELECT COALESCE(SUM(total_minor), 0) FROM documents")));
        }
        finally { Cleanup(pathA); Cleanup(pathB); }
    }

    [Theory]
    [MemberData(nameof(Industries))]
    public void Every_issued_document_adds_up_and_every_payment_is_whole_money(string industry)
    {
        var (app, _, path) = Make(industry, "IN");
        try
        {
            foreach (var header in app.Documents.List(new DocumentFilter { Status = DocStatus.Issued, Limit = 5000 }))
            {
                var view = app.Documents.Get(header.Id)!;
                var d = view.Document;
                if (view.Result is not null)
                {
                    var totals = view.Result.Totals;
                    Assert.Equal(app.Shop.Current.Minor(totals.GrandTotal), d.TotalMinor);
                    Assert.Equal(app.Shop.Current.Minor(totals.Payable), d.PayableMinor);
                }
                Assert.True(d.PaidMinor >= 0, $"{d.Number} paid below zero");
                Assert.False(string.IsNullOrEmpty(d.Number), "an issued document has a number");
            }
            var numbers = app.Documents.List(new DocumentFilter { Status = DocStatus.Issued, Limit = 5000 }).Select(x => x.Number).ToList();
            Assert.Equal(numbers.Count, numbers.Distinct().Count());
        }
        finally { Cleanup(path); }
    }

    [Theory]
    [MemberData(nameof(Industries))]
    public void Reports_run_on_every_industrys_demo_and_agree_with_each_other(string industry)
    {
        var (app, _, path) = Make(industry, "IN");
        try
        {
            var from = new DateOnly(2026, 9, 1);
            var to = new DateOnly(2026, 10, 6);
            var summary = app.Reports.Summary(from, to);
            var tax = app.Reports.TaxSummary(from, to);
            Assert.Equal(summary.TaxMinor, tax.Sum(t => t.TaxMinor));
            Assert.All(app.Reports.Payments(from, to), p => Assert.False(string.IsNullOrEmpty(p.Method)));
            app.Reports.TopItems(from, to);
            app.Reports.Outstanding();
            app.Reports.StockValues();
            app.Reports.Purchases(from, to);
            app.Reports.TopCustomers(from, to);
        }
        finally { Cleanup(path); }
    }

    [Theory]
    [MemberData(nameof(Countries))]
    public void A_retail_demo_can_be_made_in_every_country_with_its_tax_and_money(string country)
    {
        var (app, summary, path) = Make("retail", country, days: 4);
        try
        {
            var pack = PackCatalog.Get(country);
            Assert.Equal(country, summary.Country);
            Assert.Equal(pack.Currency.Code, app.Shop.Current.CurrencyCode);
            var sales = app.Documents.List(new DocumentFilter { Type = DocTypes.Invoice, Status = DocStatus.Issued, Limit = 5000 });
            Assert.NotEmpty(sales);
            var unpaid = new List<string>();
            foreach (var d in sales)
            {
                var view = app.Documents.Get(d.Id)!;
                Assert.Equal(app.Shop.Current.Minor(view.Result!.Totals.GrandTotal), view.Document.TotalMinor);
                if (view.Document.PaidMinor < view.Document.PayableMinor) unpaid.Add(d.Number!);
            }
            // Counter sales are paid in full; the one exception is the sale a customer brought something back from, which was partly refunded.
            Assert.True(unpaid.Count <= 1, "not paid in full: " + string.Join(", ", unpaid));
        }
        finally { Cleanup(path); }
    }

    [Theory]
    [InlineData("restaurant", "PH")]
    [InlineData("restaurant", "US")]
    [InlineData("construction", "GB")]
    [InlineData("library", "JP")]
    [InlineData("services", "SG")]
    [InlineData("wholesale", "ID")]
    public void Other_industries_work_in_other_countries_too(string industry, string country)
    {
        var (app, summary, path) = Make(industry, country, days: 10);
        try
        {
            Assert.True(summary.Documents > 0);
            Assert.Equal(PackCatalog.Get(country).Currency.Code, app.Shop.Current.CurrencyCode);
            app.Reports.Summary(new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 6));
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public void The_restaurant_demo_has_tables_in_use_and_food_in_each_stage_of_the_kitchen()
    {
        var (app, summary, path) = Make("restaurant", "IN");
        try
        {
            Assert.Equal(7, summary.Tables);
            var floor = app.Restaurant.Floor();
            Assert.Equal(3, floor.Count(t => t.Occupied));
            var tickets = app.Restaurant.Tickets().Select(t => t.Status).Distinct().OrderBy(s => s).ToArray();
            Assert.Contains("preparing", tickets);
            Assert.Contains("ready", tickets);
            var bills = app.Documents.List(new DocumentFilter { Type = DocTypes.Invoice, Status = DocStatus.Issued, Limit = 5000 });
            Assert.True(bills.Count >= 30, "a fortnight of table bills");
            Assert.Contains(bills, b => b.TipsMinor > 0);
            Assert.NotEmpty(app.Restaurant.Turnover(Now.AddDays(-30), Now));
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public void The_library_demo_has_a_late_book_a_fine_a_renewal_and_a_reservation()
    {
        var (app, _, path) = Make("library", "IN");
        try
        {
            Assert.NotEmpty(app.Library.Overdue());
            Assert.NotEmpty(app.Library.AllFines());
            Assert.Contains(app.Library.OpenLoans(), l => l.Loan.Renewals > 0);
            Assert.True(app.Db.Scalar("SELECT COUNT(*) FROM reservations") is long n && n > 0);
            var members = app.Parties.Search("member");
            Assert.True(members.Count >= 4);
            Assert.All(app.Catalog.Search(kind: "title", limit: 100), t => Assert.True(app.Library.CopiesOf(t.Id).Count > 0));
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public void The_construction_demo_has_projects_with_bills_costs_a_variation_and_money_owed()
    {
        var (app, summary, path) = Make("construction", "IN");
        try
        {
            Assert.Equal(2, summary.Projects);
            var projects = app.Projects.List();
            Assert.Equal(2, projects.Count);
            var house = projects.First(p => p.Code == "P-001");
            Assert.Equal(2, app.Projects.Bills(house.Id).Count);
            Assert.NotEmpty(app.Projects.Costs(house.Id));
            Assert.Single(app.Projects.Variations(house.Id));
            Assert.True(app.Projects.RetentionHeld(house.Id) > 0);
            Assert.NotEmpty(app.Reports.Outstanding());
            var status = app.Projects.Status(house.Id);
            Assert.True(status.BilledGrossMinor > 0);
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public void The_services_demo_has_past_visits_and_bookings_to_come()
    {
        var (app, summary, path) = Make("services", "IN");
        try
        {
            Assert.True(summary.Bookings >= 10);
            var today = app.Shop.Current.Time.LocalDate(Now);
            var coming = Enumerable.Range(1, 10).SelectMany(d => app.Appointments.Day(today.AddDays(d))).Where(a => a.Appointment.Status is "booked").ToList();
            Assert.NotEmpty(coming);
            Assert.NotEmpty(app.Appointments.SalesByStaff(Now.AddDays(-30), Now.AddDays(1)));
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public void The_wholesale_demo_has_trade_credit_with_part_payments()
    {
        var (app, _, path) = Make("wholesale", "IN");
        try
        {
            var owed = app.Reports.Outstanding();
            Assert.NotEmpty(owed);
            Assert.All(owed, o => Assert.True(o.TotalMinor > 0));
            Assert.NotEmpty(app.Purchasing.Payable());
            var party = app.Parties.Search("customer").First(p => p.CreditLimitMinor > 0);
            Assert.True(app.Documents.Outstanding(party.Id) <= party.CreditLimitMinor);
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public void A_demo_is_refused_on_a_shop_that_already_has_data()
    {
        var path = Path.Combine(Path.GetTempPath(), "hub-demo-" + Guid.NewGuid().ToString("N") + ".db");
        try
        {
            DemoCompany.Fill(path, new DemoOptions { Industry = "retail", Country = "PH" }, Now);
            var ex = Assert.Throws<HubException>(() => DemoCompany.Fill(path, new DemoOptions { Industry = "retail", Country = "PH" }, Now));
            Assert.Equal("not-empty", ex.Code);
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public void An_unknown_industry_or_country_is_named_in_the_error()
    {
        var path = Path.Combine(Path.GetTempPath(), "hub-demo-" + Guid.NewGuid().ToString("N") + ".db");
        try
        {
            Assert.Contains("nonsense", Assert.Throws<ArgumentException>(() => DemoCompany.Fill(path, new DemoOptions { Industry = "nonsense" }, Now)).Message);
        }
        finally { Cleanup(path); }
    }
}

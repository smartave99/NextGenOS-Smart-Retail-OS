using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Review;
using SmartRetail.Pos.Data.Demo;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public class ShopAlertsTests
{
    private static readonly DateOnly Today = new(2026, 9, 28); // a Monday

    private static readonly ProductFacts[] Catalog =
    {
        new() { Id = 1, Code = "R1", Name = "Rice 5 kg", StockInHand = 4, CostPrice = 400, SellingPrice = 600 },
        new() { Id = 2, Code = "T1", Name = "Tea 250 g", StockInHand = 0, CostPrice = 100, SellingPrice = 200 },
        new() { Id = 3, Code = "P1", Name = "Pen", StockInHand = 40, CostPrice = 5, SellingPrice = 10 },
        new() { Id = 4, Code = "S1", Name = "Soap", StockInHand = 20, CostPrice = 30, SellingPrice = 45 },
        new() { Id = 5, Code = "M1", Name = "New Mug", StockInHand = 10, CostPrice = 80, SellingPrice = 120, AddedOn = new DateOnly(2026, 9, 1) },
        new() { Id = 6, Code = "O1", Name = "Old Stock", StockInHand = 9, CostPrice = 5, SellingPrice = 8, Active = false },
        new() { Id = 7, Code = "L1", Name = "Oil 1 L", StockInHand = 100, CostPrice = 150, SellingPrice = 180 },
    };

    /// <summary>Rice and oil sell every day of the last 4 weeks, tea three times; soap last sold 40 days ago, the pen 60.</summary>
    private static SalesFacts Facts()
    {
        var days = new List<DaySales>();
        var lines = new List<ProductDaySales>();
        for (var day = Today.AddDays(-28); day <= Today; day = day.AddDays(1))
        {
            days.Add(new DaySales { Day = day, Bills = 2, Sales = 780 });
            lines.Add(new ProductDaySales { Day = day, ProductId = 1, Qty = 1, Sales = 600, SalesBeforeTax = 571, Bills = 1 });
            lines.Add(new ProductDaySales { Day = day, ProductId = 7, Qty = 1, Sales = 180, SalesBeforeTax = 171, Bills = 1 });
        }

        foreach (var day in new[] { Today.AddDays(-20), Today.AddDays(-13), Today.AddDays(-6) })
        {
            lines.Add(new ProductDaySales { Day = day, ProductId = 2, Qty = 2, Sales = 400, SalesBeforeTax = 380, Bills = 1 });
        }

        lines.Add(new ProductDaySales { Day = Today.AddDays(-40), ProductId = 4, Qty = 1, Sales = 45, SalesBeforeTax = 43, Bills = 1 });
        lines.Add(new ProductDaySales { Day = Today.AddDays(-60), ProductId = 3, Qty = 5, Sales = 50, SalesBeforeTax = 48, Bills = 1 });
        return new SalesFacts { Range = new DateRange(Today.AddDays(-70), Today), Days = days, ProductDays = lines };
    }

    [Fact]
    public void Regular_sellers_running_out_and_stock_unsold_for_8_weeks_are_raised_with_their_figures()
    {
        var alerts = ShopAlerts.Find(Facts(), Catalog, Today);

        var running = alerts.Where(a => a.Kind == AlertKind.StockOut).ToList();
        Assert.Equal(new[] { "Rice 5 kg", "Tea 250 g" }, running.Select(a => a.Name));
        Assert.Equal("4 left; it sells about 1 a day", running[0].Figures);
        Assert.Equal("Reorder: at the last 4 weeks' pace it runs out in about 4 days.", running[0].Recommendation);
        Assert.Equal((1m, 4m), (running[0].QtyPerDay, running[0].DaysLeft));
        Assert.Equal("None in stock; it sells about 0.2 a day", running[1].Figures);
        Assert.Equal("Reorder: it is out of stock, and it sells every week.", running[1].Recommendation);

        // Soap sold within 8 weeks, the mug is new and the old stock is no longer sold: only the pen is dead stock.
        var dead = Assert.Single(alerts, a => a.Kind == AlertKind.DeadStock);
        Assert.Equal(("Pen", 40m, 200m), (dead.Name, dead.StockInHand, dead.StockValue));
        Assert.Equal("40 in stock, ₹200 tied up; not sold in 8 weeks", dead.Figures);
        Assert.StartsWith("Stop reordering it, and clear it", dead.Recommendation);
    }

    [Fact]
    public void A_regular_seller_at_its_reorder_level_says_so()
    {
        var catalog = Catalog.Select(p => p.Id == 7 ? p with { StockInHand = 12, MinStock = 15 } : p).ToList();

        var oil = Assert.Single(ShopAlerts.Find(Facts(), catalog, Today), a => a.ProductId == 7);

        Assert.Equal("Reorder: it is at its reorder level of 15.", oil.Recommendation);
    }

    [Fact]
    public void A_decision_waits_for_its_review_day_two_weeks_on_or_four_for_stock()
    {
        var alerts = ShopAlerts.Find(Facts(), Catalog, Today);
        var rice = alerts.First(a => a.ProductId == 1);
        var pen = alerts.First(a => a.ProductId == 3);
        var now = new DateTime(2026, 9, 28, 11, 0, 0);

        var reorder = AlertDecisions.Decide(rice, DecisionChoice.Accepted, null, now, "a1");
        var clear = AlertDecisions.Decide(pen, DecisionChoice.Rejected, "  Schools reopen in June; it sells then.  ", now, "a2");

        Assert.Equal((new DateOnly(2026, 10, 12), "", "4 left; it sells about 1 a day", 4m), (reorder.ReviewOn, reorder.Note, reorder.Figures, reorder.StockThen));
        Assert.Equal((new DateOnly(2026, 10, 26), "Schools reopen in June; it sells then."), (clear.ReviewOn, clear.Note));
        Assert.Equal(AlertDecision.MaxNote, AlertDecisions.Decide(rice, DecisionChoice.Changed, new string('x', 300), now, "a3").Note.Length);

        // Until then the alert stays away; on the day it may come back. Another kind for the same product is not held back.
        Assert.DoesNotContain(AlertDecisions.Open(alerts, new[] { reorder, clear }, new DateOnly(2026, 10, 11)), a => a.ProductId is 1 or 3);
        Assert.Contains(AlertDecisions.Open(alerts, new[] { reorder, clear }, new DateOnly(2026, 10, 12)), a => a.ProductId == 1);
        Assert.Contains(AlertDecisions.Open(alerts, new[] { reorder with { Kind = AlertKind.DeadStock } }, Today), a => a.ProductId == 1);
    }

    [Theory]
    [InlineData(DecisionChoice.Accepted, null, null)]
    [InlineData(DecisionChoice.Rejected, "", null)]
    [InlineData(DecisionChoice.Changed, " ", "Say what you will do instead.")]
    [InlineData(DecisionChoice.Changed, "Order from the wholesaler", null)]
    public void Something_else_needs_a_few_words(DecisionChoice choice, string? note, string? problem) =>
        Assert.Equal(problem, AlertDecisions.Problem(choice, note));

    [Fact]
    public void A_note_over_the_limit_is_refused() =>
        Assert.Equal($"Keep the note under {AlertDecision.MaxNote} characters.", AlertDecisions.Problem(DecisionChoice.Rejected, new string('x', AlertDecision.MaxNote + 1)));

    [Fact]
    public void On_its_review_day_a_decision_is_judged_from_the_stock_and_what_sold_since()
    {
        var reorder = new AlertDecision { Kind = AlertKind.StockOut, ProductId = 1, ReviewOn = new DateOnly(2026, 10, 12) };
        var clear = new AlertDecision { Kind = AlertKind.DeadStock, ProductId = 3, ReviewOn = new DateOnly(2026, 10, 26) };
        var rice = Catalog[0];

        Assert.Null(AlertDecisions.Outcome(reorder, rice, 3, new DateOnly(2026, 10, 11)));
        Assert.Equal(new DecisionOutcome("In stock on the review day: 4 left, 14 sold since.", true), AlertDecisions.Outcome(reorder, rice, 14, new DateOnly(2026, 10, 12)));
        Assert.Equal(new DecisionOutcome("Out of stock on the review day; 14 sold since.", false), AlertDecisions.Outcome(reorder, rice with { StockInHand = -2 }, 14, new DateOnly(2026, 10, 12)));
        Assert.Equal(new DecisionOutcome("It sold again: 6 by the review day, 34 left.", true), AlertDecisions.Outcome(clear, Catalog[2] with { StockInHand = 34 }, 6, new DateOnly(2026, 10, 26)));
        Assert.Equal(new DecisionOutcome("It is no longer in the POS.", null), AlertDecisions.Outcome(clear, null, 0, new DateOnly(2026, 10, 30)));
    }

    [Fact]
    public void Judged_after_its_review_day_sales_still_count_but_a_stock_out_is_not_known()
    {
        var reorder = new AlertDecision { Kind = AlertKind.StockOut, ProductId = 1, ReviewOn = new DateOnly(2026, 10, 12) };
        var clear = new AlertDecision { Kind = AlertKind.DeadStock, ProductId = 3, ReviewOn = new DateOnly(2026, 10, 26) };

        // Restocked after its review day, it may still have run out by then: not counted either way.
        Assert.Equal(new DecisionOutcome("Checked late, on 15 Oct: 4 in stock then, 14 sold by the review day. Whether it ran out by 12 Oct is not known, so it is not counted.", null),
            AlertDecisions.Outcome(reorder, Catalog[0], 14, new DateOnly(2026, 10, 15)));

        // Its sales to the review day are in the bills: the stock left now is not the review day's, so it is not given.
        Assert.Equal(new DecisionOutcome("Still not sold by the review day.", false), AlertDecisions.Outcome(clear, Catalog[2], 0, new DateOnly(2026, 10, 30)));
        Assert.Equal(new DecisionOutcome("It sold again: 2 by the review day.", true), AlertDecisions.Outcome(clear, Catalog[2], 2, new DateOnly(2026, 11, 3)));
    }

    [Fact]
    public void The_tally_compares_following_the_rules_with_the_owners_own_choices()
    {
        AlertDecision Judged(DecisionChoice choice, bool? well) => new() { Choice = choice, WentWell = well, Outcome = "…" };
        var decisions = new[]
        {
            Judged(DecisionChoice.Accepted, true), Judged(DecisionChoice.Accepted, true), Judged(DecisionChoice.Accepted, false),
            Judged(DecisionChoice.Changed, true), Judged(DecisionChoice.Rejected, false),
            Judged(DecisionChoice.Accepted, null), new AlertDecision { Choice = DecisionChoice.Rejected },
        };

        var tally = AlertDecisions.Tally(decisions);

        Assert.Equal(new DecisionTally(3, 2, 2, 1), tally);
        Assert.Equal(5, tally.Judged);
        Assert.Equal(0, AlertDecisions.Tally(Array.Empty<AlertDecision>()).Judged);
    }

    [Theory]
    [InlineData("2026-09-28", "2026-09-21", "2026-09-27")] // a Monday: the week just ended
    [InlineData("2026-10-04", "2026-09-21", "2026-09-27")] // a Sunday: still the week before
    [InlineData("2026-09-30", "2026-09-21", "2026-09-27")]
    [InlineData("2026-01-01", "2025-12-22", "2025-12-28")]
    public void The_review_looks_at_the_last_full_week_Monday_to_Sunday(string today, string from, string to) =>
        Assert.Equal(new DateRange(DateOnly.Parse(from), DateOnly.Parse(to)), ReviewWeeks.LastWeek(DateOnly.Parse(today)));

    [Fact]
    public void A_year_before_is_52_weeks_so_weekdays_match_and_weeks_have_short_names()
    {
        var week = ReviewWeeks.LastWeek(Today);
        var year = ReviewWeeks.YearBefore(week);

        Assert.Equal(new DateRange(new DateOnly(2025, 9, 22), new DateOnly(2025, 9, 28)), year);
        Assert.Equal(DayOfWeek.Monday, year.From.DayOfWeek);
        Assert.Equal("21–27 Sep", ReviewWeeks.Name(week));
        Assert.Equal("29 Sep – 5 Oct", ReviewWeeks.Name(new DateRange(new DateOnly(2026, 9, 29), new DateOnly(2026, 10, 5))));
    }
}

public sealed class ReviewServiceTests : IDisposable
{
    private static readonly DateTimeOffset Monday = new(2026, 9, 28, 11, 0, 0, TimeSpan.FromHours(5.5));

    private readonly string _root = Directory.CreateTempSubdirectory("review-service-").FullName;
    private readonly DemoStore _pos = new(new FixedClock(Monday), seedSales: true);
    private readonly StorageService _storage;
    private readonly MovableClock _clock = new(Monday);

    public ReviewServiceTests()
    {
        File.WriteAllText(Path.Combine(_root, SmartRetail.AI.Storage.StorageSettingsStore.FileName), JsonSerializer.Serialize(new { DataFolder = Path.Combine(_root, "data") }));
        _storage = new StorageService(Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") }));
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private ReviewService Service() => new(_storage, _pos, _clock, NullLogger<ReviewService>.Instance);

    [Fact]
    public async Task Last_week_is_set_against_the_week_before_and_a_year_before_with_the_rules_alerts()
    {
        var data = await Service().LoadAsync(CancellationToken.None);

        var week = new DateRange(new DateOnly(2026, 9, 21), new DateOnly(2026, 9, 27));
        var products = await _pos.GetProductsAsync();
        var expected = SalesAnalysis.Analyse(await _pos.GetFactsAsync(week), await _pos.GetFactsAsync(week.Previous), products);
        Assert.Equal(week, data.Week);
        Assert.Equal((expected.Current.Sales, expected.Current.Bills), (data.ThisWeek.Sales, data.ThisWeek.Bills));
        Assert.Equal((expected.Previous.Sales, expected.Previous.Bills), (data.WeekBefore.Sales, data.WeekBefore.Bills));
        var yearBefore = SalesAnalysis.Analyse(await _pos.GetFactsAsync(ReviewWeeks.YearBefore(week)), new SalesFacts(), products).Current;
        Assert.Equal(yearBefore.Sales, data.YearBefore?.Sales);
        Assert.Contains(data.Alerts, a => a.Kind == AlertKind.StockOut);
        Assert.Contains(data.Alerts, a => a.Kind == AlertKind.DeadStock);
        Assert.Empty(data.Decisions);
        Assert.Null(data.Reviewed);
    }

    [Fact]
    public async Task A_decision_is_kept_in_the_Memory_folder_and_judged_on_its_review_day()
    {
        var service = Service();
        var alert = (await service.LoadAsync(CancellationToken.None)).Alerts.First(a => a.Kind == AlertKind.StockOut);

        Assert.Equal("Say what you will do instead.", service.Decide(alert, DecisionChoice.Changed, " "));
        Assert.False(File.Exists(service.Path), "a refused decision was written");
        Assert.Null(service.Decide(alert, DecisionChoice.Accepted, null));
        Assert.Equal(Path.Combine(_root, "data", "Memory", ReviewService.FileName), service.Path);

        var data = await service.LoadAsync(CancellationToken.None);
        Assert.DoesNotContain(data.Alerts, a => a.Kind == alert.Kind && a.ProductId == alert.ProductId);
        var decision = Assert.Single(data.Decisions);
        Assert.Equal((alert.ProductId, alert.Figures, DecisionChoice.Accepted, new DateOnly(2026, 10, 12)), (decision.ProductId, decision.Figures, decision.Choice, decision.ReviewOn));
        Assert.Null(decision.Outcome);

        // Its review day: judged from the POS as it is then, and kept.
        _clock.Now = Monday.AddDays(14);
        decision = Assert.Single((await service.LoadAsync(CancellationToken.None)).Decisions);
        var product = (await _pos.GetProductsAsync()).Single(p => p.Id == alert.ProductId);
        Assert.Equal(product.StockInHand > 0, decision.WentWell);
        Assert.StartsWith(product.StockInHand > 0 ? "In stock on the review day" : "Out of stock on the review day", decision.Outcome);
        Assert.Equal(new DateOnly(2026, 10, 12), decision.OutcomeOn);
        Assert.Equal(decision, Service().Load().Decisions.Single());
    }

    [Fact]
    public async Task Judged_late_sales_count_to_the_review_day_and_a_stock_out_is_left_out_of_the_tally()
    {
        var service = Service();
        var products = await _pos.GetProductsAsync();
        var seller = SalesAnalysis.Analyse(await _pos.GetFactsAsync(new DateRange(new DateOnly(2026, 8, 1), new DateOnly(2026, 9, 27))), new SalesFacts(), products).TopProducts[0];

        // Decided on 1 Aug, so due on 15 Aug (a reorder) and 29 Aug (stock), and first judged on 28 Sep.
        _clock.Now = new DateTimeOffset(2026, 8, 1, 10, 0, 0, TimeSpan.FromHours(5.5));
        Assert.Null(service.Decide(new ShopAlert { Kind = AlertKind.DeadStock, ProductId = seller.ProductId, Name = seller.Name }, DecisionChoice.Accepted, null));
        Assert.Null(service.Decide(new ShopAlert { Kind = AlertKind.StockOut, ProductId = seller.ProductId, Name = seller.Name }, DecisionChoice.Rejected, null));
        _clock.Now = Monday;

        Assert.Equal(2, await service.JudgeDueAsync(CancellationToken.None));
        Assert.Equal(0, await service.JudgeDueAsync(CancellationToken.None));

        var decisions = service.Load().Decisions;
        var sold = (await _pos.GetFactsAsync(new DateRange(new DateOnly(2026, 8, 1), new DateOnly(2026, 8, 29)))).ProductDays
            .Where(p => p.ProductId == seller.ProductId).Sum(p => p.Qty);
        var clear = decisions.Single(d => d.Kind == AlertKind.DeadStock);
        Assert.Equal(($"It sold again: {SmartRetail.Pos.Core.Money.FormatQty(sold)} by the review day.", (bool?)true, new DateOnly(2026, 9, 28)), (clear.Outcome, clear.WentWell, clear.OutcomeOn!.Value));
        var reorder = decisions.Single(d => d.Kind == AlertKind.StockOut);
        Assert.StartsWith("Checked late, on 28 Sept:", reorder.Outcome);
        Assert.Null(reorder.WentWell);
        Assert.Equal(new DecisionTally(1, 1, 0, 0), AlertDecisions.Tally(decisions));
    }

    [Fact]
    public async Task Reading_the_review_for_the_owners_live_view_judges_and_writes_nothing()
    {
        var service = Service();
        var seller = (await service.LoadAsync(CancellationToken.None)).Alerts.First(a => a.Kind == AlertKind.StockOut);
        Assert.Null(service.Decide(seller, DecisionChoice.Accepted, null));
        var before = File.ReadAllText(service.Path);

        // Its review day came (14 days on), but only a look at the review judges it.
        _clock.Now = Monday.AddDays(14);
        var read = await service.LoadAsync(CancellationToken.None, judgeDue: false);

        Assert.Null(Assert.Single(read.Decisions).Outcome);
        Assert.Equal(before, File.ReadAllText(service.Path));
        Assert.NotNull(Assert.Single((await service.LoadAsync(CancellationToken.None)).Decisions).Outcome);
    }

    [Fact]
    public async Task The_week_is_marked_as_reviewed_once_and_the_next_week_waits_again()
    {
        var service = Service();
        var week = (await service.LoadAsync(CancellationToken.None)).Week;
        Assert.False(service.LastWeekReviewed());

        service.MarkReviewed(week);
        _clock.Now = Monday.AddHours(2);
        service.MarkReviewed(week);

        var reviewed = Assert.Single(service.Load().Reviewed);
        Assert.Equal((week.From, Monday.DateTime), (reviewed.Monday, reviewed.At));
        Assert.True(service.LastWeekReviewed());
        Assert.Equal(Monday.DateTime, (await service.LoadAsync(CancellationToken.None)).Reviewed);

        _clock.Now = Monday.AddDays(7);
        Assert.False(service.LastWeekReviewed());
    }

    [Fact]
    public void A_damaged_file_is_kept_aside_and_the_log_starts_again()
    {
        var service = Service();
        Directory.CreateDirectory(Path.GetDirectoryName(service.Path)!);
        File.WriteAllText(service.Path, "{ not json");

        Assert.Empty(service.Load().Decisions);
        Assert.Equal("{ not json", File.ReadAllText(service.Path + ".bad"));
    }

    /// <summary>A clock the test moves on, in Indian Standard Time.</summary>
    private sealed class MovableClock(DateTimeOffset now) : TimeProvider
    {
        private static readonly TimeZoneInfo India =
            TimeZoneInfo.CreateCustomTimeZone("IST", TimeSpan.FromHours(5.5), "India Standard Time", "India Standard Time");

        public DateTimeOffset Now { get; set; } = now;

        public override DateTimeOffset GetUtcNow() => Now.ToUniversalTime();

        public override TimeZoneInfo LocalTimeZone => India;
    }
}

using System.Globalization;
using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Settings;
using SmartRetail.AI.Storage;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>The month's short name is "Sept" in some machines' culture data and "Sep" in others': the tests read it as "Sep".</summary>
internal static class WordsExtensions
{
    public static string Plain(this string text) => text.Replace("Sept ", "Sep ", StringComparison.Ordinal);
}

/// <summary>When each Fix now finding happened, in words: a bill's date and time, or when a price problem was first noticed.</summary>
public class FindingTimesTests
{
    private static readonly CultureInfo India = CultureInfo.GetCultureInfo("en-IN");
    private static readonly IReadOnlyDictionary<long, DateTime> NoTimes = new Dictionary<long, DateTime>();

    /// <summary>"6:57 pm", written the way the app writes a time.</summary>
    private static string At(int hour, int minute) => new TimeOnly(hour, minute).ToString("h:mm tt", India);

    private static FindingBill Bill(long id, int day, int month = 9) => new(id, "SR/26-27/" + id.ToString("0000", CultureInfo.InvariantCulture), new DateOnly(2026, month, day));

    private static Finding Of(FindingKind kind, params FindingBill[] bills) => new() { Kind = kind, Bills = bills };

    private static string When(Finding finding, IReadOnlyDictionary<long, DateTime> savedAt, SeenProblems? seen) =>
        FindingTimes.When(finding, savedAt, seen).Plain();

    private static IReadOnlyDictionary<long, DateTime> Saved(params (long Id, DateTime At)[] times) => times.ToDictionary(t => t.Id, t => t.At);

    [Fact]
    public void A_bill_says_its_date_and_the_time_the_pos_log_has()
    {
        var times = Saved((20, new DateTime(2026, 9, 24, 18, 57, 0)));

        Assert.Equal("Billed 24 Sep 2026, " + At(18, 57), When(Of(FindingKind.SoldAtLoss, Bill(20, 24)), times, null));
        Assert.Equal("Billed 24 Sep 2026", When(Of(FindingKind.SoldAtLoss, Bill(20, 24)), NoTimes, null));
    }

    [Fact]
    public void A_bill_typed_in_on_a_later_day_has_no_time_of_sale_so_only_its_date_is_said()
    {
        var times = Saved((20, new DateTime(2026, 9, 25, 10, 5, 0)));

        Assert.Equal("Billed 24 Sep 2026", When(Of(FindingKind.BigDiscount, Bill(20, 24)), times, null));
    }

    [Fact]
    public void Several_bills_say_the_latest_one_and_when_the_first_was()
    {
        var times = Saved((20, new DateTime(2026, 9, 22, 9, 0, 0)), (21, new DateTime(2026, 9, 24, 11, 0, 0)), (22, new DateTime(2026, 9, 24, 18, 57, 0)));

        // The latest is the later day, then the higher bill number, whatever order the bills come in.
        Assert.Equal(
            "Latest bill 24 Sep 2026, " + At(18, 57) + "; the first on 22 Sep 2026",
            When(Of(FindingKind.SoldAtLoss, Bill(21, 24), Bill(20, 22), Bill(22, 24)), times, null));
        Assert.Equal(
            "Latest bill 24 Sep 2026, " + At(18, 57) + "; 2 bills that day",
            When(Of(FindingKind.SoldAboveMrp, Bill(22, 24), Bill(21, 24)), times, null));
    }

    [Fact]
    public void A_missing_bill_number_was_made_between_the_two_bills_around_it()
    {
        var sameDay = Saved((100, new DateTime(2026, 9, 24, 18, 12, 0)), (102, new DateTime(2026, 9, 24, 18, 30, 0)));
        Assert.Equal(
            $"Between {At(18, 12)} and {At(18, 30)} on 24 Sep 2026",
            When(Of(FindingKind.MissingBills, Bill(100, 24), Bill(102, 24)), sameDay, null));
        // In whichever order the two bills come.
        Assert.Equal(
            $"Between {At(18, 12)} and {At(18, 30)} on 24 Sep 2026",
            When(Of(FindingKind.MissingBills, Bill(102, 24), Bill(100, 24)), sameDay, null));

        var otherDays = Saved((100, new DateTime(2026, 9, 24, 21, 0, 0)), (102, new DateTime(2026, 9, 25, 10, 5, 0)));
        Assert.Equal(
            $"Between 24 Sep 2026, {At(21, 0)} and 25 Sep 2026, {At(10, 5)}",
            When(Of(FindingKind.MissingBills, Bill(100, 24), Bill(102, 25)), otherDays, null));

        // Without the times only the days are said, and times that do not follow each other are not made up.
        Assert.Equal("On 24 Sep 2026", When(Of(FindingKind.MissingBills, Bill(100, 24), Bill(102, 24)), NoTimes, null));
        Assert.Equal("Between 24 Sep 2026 and 25 Sep 2026", When(Of(FindingKind.MissingBills, Bill(100, 24), Bill(102, 25)), NoTimes, null));
        var backwards = Saved((100, new DateTime(2026, 9, 24, 19, 0, 0)), (102, new DateTime(2026, 9, 24, 18, 0, 0)));
        Assert.Equal("On 24 Sep 2026", When(Of(FindingKind.MissingBills, Bill(100, 24), Bill(102, 24)), backwards, null));
    }

    [Fact]
    public void Money_owed_for_long_says_the_day_of_its_oldest_bill()
    {
        var owed = new Finding { Kind = FindingKind.OwedLong, Since = new DateOnly(2026, 8, 2) };

        Assert.Equal("Oldest unpaid bill is from 2 Aug 2026", When(owed, NoTimes, null));
        Assert.Equal("", When(new Finding { Kind = FindingKind.OwedLong }, NoTimes, null));
    }

    [Fact]
    public void A_price_problem_says_when_it_was_first_noticed_or_that_it_was_already_there_at_the_first_check()
    {
        var finding = new Finding { Kind = FindingKind.BelowCost, Problem = "below-cost|1|1001" };
        var first = FindingTimes.Seen(null, new[] { "below-cost|1|1001" }, new DateTime(2026, 9, 26, 11, 0, 0));
        var later = FindingTimes.Seen(first, new[] { "below-cost|1|1001", "no-cost|2|1002" }, new DateTime(2026, 9, 26, 14, 30, 0));

        Assert.Equal("Already there when this app first checked, on 26 Sep 2026", When(finding, NoTimes, later));
        Assert.Equal(
            "First noticed 26 Sep 2026, " + At(14, 30),
            When(new Finding { Kind = FindingKind.NoCost, Problem = "no-cost|2|1002" }, NoTimes, later));
    }

    [Fact]
    public void A_finding_nothing_is_known_about_says_nothing()
    {
        var seen = FindingTimes.Seen(null, new[] { "below-cost|1|1001" }, new DateTime(2026, 9, 26, 11, 0, 0));

        Assert.Equal("", When(new Finding { Kind = FindingKind.BelowCost }, NoTimes, seen)); // no problem id
        Assert.Equal("", When(new Finding { Kind = FindingKind.BelowCost, Problem = "below-cost|9|9" }, NoTimes, seen)); // not seen
        Assert.Equal("", When(new Finding { Kind = FindingKind.BelowCost, Problem = "below-cost|1|1001" }, NoTimes, null)); // nothing kept
    }

    [Fact]
    public void What_was_seen_is_kept_while_the_problem_lasts_and_forgotten_when_it_is_gone()
    {
        var t0 = new DateTime(2026, 9, 26, 11, 0, 0);
        var first = FindingTimes.Seen(null, new[] { "a", "b", "a", "" }, t0);
        Assert.All(first.Items, item => Assert.True(item.AtStart));
        Assert.Equal(new[] { "a", "b" }, first.Items.Select(i => i.Problem));

        // The very first check found nothing: problems after it are new, not "already there".
        var empty = FindingTimes.Seen(null, Array.Empty<string>(), t0);
        var afterEmpty = FindingTimes.Seen(empty, new[] { "c" }, t0.AddHours(1));
        Assert.False(Assert.Single(afterEmpty.Items).AtStart);

        var next = FindingTimes.Seen(first, new[] { "b", "c" }, t0.AddHours(2));
        Assert.Equal(new[] { ("b", t0, true), ("c", t0.AddHours(2), false) }, next.Items.Select(i => (i.Problem, i.At, i.AtStart)));

        // A problem that comes back after it was gone is new again.
        var gone = FindingTimes.Seen(next, new[] { "c" }, t0.AddHours(3));
        var back = FindingTimes.Seen(gone, new[] { "b", "c" }, t0.AddHours(4));
        Assert.Equal((t0.AddHours(4), false), (back.Items.Single(i => i.Problem == "b").At, back.Items.Single(i => i.Problem == "b").AtStart));
    }
}

/// <summary>The Fix now service adding when each finding happened: the bill times asked of the POS, and when a price problem was first noticed.</summary>
public sealed class FixNowWhenTests : IDisposable
{
    private static readonly CultureInfo India = CultureInfo.GetCultureInfo("en-IN");

    /// <summary>A clock the test can move on, in Indian time.</summary>
    private sealed class Clock(DateTimeOffset start) : TimeProvider
    {
        private static readonly TimeZoneInfo Ist = TimeZoneInfo.CreateCustomTimeZone("IST", TimeSpan.FromHours(5.5), "India Standard Time", "India Standard Time");
        private DateTimeOffset _now = start;

        public void Advance(TimeSpan by) => _now += by;

        public override DateTimeOffset GetUtcNow() => _now.ToUniversalTime();

        public override TimeZoneInfo LocalTimeZone => Ist;
    }

    private sealed class Checks : IShopChecksRepository
    {
        public List<PriceFacts> Prices { get; } = new();
        public List<SoldLine> Lines { get; } = new();
        public List<BillStub> Bills { get; } = new();

        public Task<IReadOnlyList<PriceFacts>> GetPricesAsync(CancellationToken ct = default) => Task.FromResult<IReadOnlyList<PriceFacts>>(Prices.ToList());

        public Task<IReadOnlyList<SoldLine>> GetSoldLinesAsync(DateRange range, CancellationToken ct = default) => Task.FromResult<IReadOnlyList<SoldLine>>(Lines.ToList());

        public Task<IReadOnlyList<BillStub>> GetBillsAsync(DateRange range, CancellationToken ct = default) => Task.FromResult<IReadOnlyList<BillStub>>(Bills.ToList());
    }

    /// <summary>The bill list: only the search is used. It counts the days it was asked about.</summary>
    private sealed class Invoices : IInvoiceRepository
    {
        public List<InvoiceSummary> Bills { get; } = new();
        public List<DateOnly> DaysAsked { get; } = new();
        public bool Fails { get; set; }
        public BillPage? Owed { get; set; }

        public Task<BillPage> SearchAsync(BillQuery query, CancellationToken ct = default)
        {
            if (query.OnlyOwed)
            {
                return Task.FromResult(Owed ?? new BillPage());
            }

            DaysAsked.Add(query.From!.Value);
            if (Fails)
            {
                throw new InvalidOperationException("The POS log cannot be read.");
            }

            var items = Bills.Where(b => DateOnly.FromDateTime(b.Date) >= query.From && DateOnly.FromDateTime(b.Date) <= query.To).ToList();
            return Task.FromResult(new BillPage { Items = items, Total = items.Count });
        }

        public Task<SavedInvoice> SaveAsync(NewInvoice invoice, CancellationToken ct = default) => throw new NotSupportedException();

        public Task<IReadOnlyList<InvoiceSummary>> GetRecentAsync(int limit, CancellationToken ct = default) => throw new NotSupportedException();

        public Task<BillDetails?> GetAsync(long id, CancellationToken ct = default) => throw new NotSupportedException();

        public Task<SalesSummary> GetSalesForDayAsync(DateOnly day, CancellationToken ct = default) => throw new NotSupportedException();
    }

    private readonly string _root = Directory.CreateTempSubdirectory("fixnow-when-").FullName;
    private readonly StorageService _storage;
    private readonly Clock _clock = new(new DateTimeOffset(2026, 9, 26, 11, 0, 0, TimeSpan.FromHours(5.5)));
    private readonly Checks _checks = new();
    private readonly Invoices _invoices = new();

    public FixNowWhenTests()
    {
        File.WriteAllText(Path.Combine(_root, StorageSettingsStore.FileName), JsonSerializer.Serialize(new { DataFolder = DataFolder }));
        _storage = new StorageService(Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") }));
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private string DataFolder => Path.Combine(_root, "data");

    private string SeenFile => Path.Combine(DataFolders.Checks(DataFolder), "seen.json");

    private FixNowService Service() =>
        new(_checks, _invoices, _storage, Options.Create(new ShopOptions()), _clock, NullLogger<FixNowService>.Instance);

    private static string At(int hour, int minute) => new TimeOnly(hour, minute).ToString("h:mm tt", India);

    private static PriceFacts Price(int id, decimal price, decimal cost, decimal gst = 5m) => new()
    {
        ProductId = id,
        Name = "Product " + id,
        Code = (1000 + id).ToString(CultureInfo.InvariantCulture),
        Price = price,
        Cost = cost,
        GstPercent = gst,
        Qty = 10m,
    };

    /// <summary>Two pieces sold at ₹12 each that were bought at ₹20.50: a loss.</summary>
    private static SoldLine Loss(long bill, DateTime day) => new()
    {
        BillId = bill,
        BillNumber = "SR/26-27/" + bill.ToString("0000", CultureInfo.InvariantCulture),
        Date = day,
        ProductId = 7,
        Name = "Product 7",
        Qty = 2m,
        Rate = 12m,
        Amount = 24m,
        Taxable = 24m,
        PurchaseRate = 20.5m,
    };

    private static InvoiceSummary Bill(long id, DateTime day, DateTime? saved) =>
        new() { Id = id, Number = "SR/26-27/" + id.ToString("0000", CultureInfo.InvariantCulture), Date = day, SavedAt = saved };

    private static Finding Only(FixNowResult result, FindingKind kind) => Assert.Single(result.Open, f => f.Kind == kind);

    [Fact]
    public async Task A_finding_about_a_bill_says_its_date_and_the_time_the_pos_log_has()
    {
        _checks.Lines.Add(Loss(20, new DateTime(2026, 9, 24)));
        _invoices.Bills.Add(Bill(20, new DateTime(2026, 9, 24), new DateTime(2026, 9, 24, 18, 57, 0)));

        var result = await Service().CheckAsync();

        Assert.Equal("Billed 24 Sep 2026, " + At(18, 57), Only(result, FindingKind.SoldAtLoss).When.Plain());
        Assert.Null(result.Problem);
    }

    [Fact]
    public async Task A_bill_typed_in_on_a_later_day_shows_only_its_date()
    {
        _checks.Lines.Add(Loss(20, new DateTime(2026, 9, 24)));
        _invoices.Bills.Add(Bill(20, new DateTime(2026, 9, 24), new DateTime(2026, 9, 25, 10, 5, 0)));

        Assert.Equal("Billed 24 Sep 2026", Only(await Service().CheckAsync(), FindingKind.SoldAtLoss).When.Plain());
    }

    [Fact]
    public async Task The_pos_is_asked_for_a_days_bill_times_only_when_a_bill_needs_one_and_a_time_found_is_kept()
    {
        _checks.Lines.Add(Loss(20, new DateTime(2026, 9, 24)));
        _invoices.Bills.Add(Bill(20, new DateTime(2026, 9, 24), new DateTime(2026, 9, 24, 18, 57, 0)));
        var service = Service();

        await service.CheckAsync(fresh: true);
        await service.CheckAsync(fresh: true);
        Assert.Equal(new[] { new DateOnly(2026, 9, 24) }, _invoices.DaysAsked);

        // Another sale at a loss the same day is a new finding about a bill not asked for yet: asked at once.
        _checks.Lines.Add(Loss(21, new DateTime(2026, 9, 24)) with { Rate = 11m, Amount = 22m, Taxable = 22m });
        _invoices.Bills.Add(Bill(21, new DateTime(2026, 9, 24), new DateTime(2026, 9, 24, 19, 30, 0)));
        var result = await service.CheckAsync(fresh: true);

        Assert.Equal(2, _invoices.DaysAsked.Count);
        Assert.All(result.Open.Where(f => f.Kind == FindingKind.SoldAtLoss), f => Assert.Contains(", ", f.When.Plain()));
        Assert.Equal(
            new[] { "Billed 24 Sep 2026, " + At(18, 57), "Billed 24 Sep 2026, " + At(19, 30) },
            result.Open.Where(f => f.Kind == FindingKind.SoldAtLoss).Select(f => f.When.Plain()).OrderBy(when => when, StringComparer.Ordinal));
    }

    [Fact]
    public async Task A_bill_whose_time_was_not_there_is_asked_for_again_after_ten_minutes_not_at_every_check()
    {
        _checks.Lines.Add(Loss(20, new DateTime(2026, 9, 24)));
        _invoices.Bills.Add(Bill(20, new DateTime(2026, 9, 24), saved: null));
        var service = Service();

        Assert.Equal("Billed 24 Sep 2026", Only(await service.CheckAsync(fresh: true), FindingKind.SoldAtLoss).When.Plain());
        await service.CheckAsync(fresh: true);
        Assert.Single(_invoices.DaysAsked);

        _clock.Advance(TimeSpan.FromMinutes(11));
        _invoices.Bills.Clear();
        _invoices.Bills.Add(Bill(20, new DateTime(2026, 9, 24), new DateTime(2026, 9, 24, 18, 57, 0)));
        var result = await service.CheckAsync(fresh: true);

        Assert.Equal(2, _invoices.DaysAsked.Count);
        Assert.Equal("Billed 24 Sep 2026, " + At(18, 57), Only(result, FindingKind.SoldAtLoss).When.Plain());
    }

    [Fact]
    public async Task A_bill_list_that_cannot_be_read_does_not_hide_the_findings_they_show_their_dates()
    {
        _checks.Lines.Add(Loss(20, new DateTime(2026, 9, 24)));
        _invoices.Fails = true;

        var result = await Service().CheckAsync();

        Assert.Equal("Billed 24 Sep 2026", Only(result, FindingKind.SoldAtLoss).When.Plain());
        Assert.Null(result.Problem);
    }

    [Fact]
    public async Task A_missing_bill_number_and_money_owed_say_when()
    {
        _checks.Bills.Add(new BillStub(100, "SR/26-27/0100", new DateTime(2026, 9, 24)));
        _checks.Bills.Add(new BillStub(102, "SR/26-27/0102", new DateTime(2026, 9, 24)));
        _invoices.Bills.Add(Bill(100, new DateTime(2026, 9, 24), new DateTime(2026, 9, 24, 18, 12, 0)));
        _invoices.Bills.Add(Bill(102, new DateTime(2026, 9, 24), new DateTime(2026, 9, 24, 18, 30, 0)));
        _invoices.Owed = new BillPage { Total = 2, TotalOwed = 900m, First = new DateTime(2026, 8, 2) };

        var result = await Service().CheckAsync();

        Assert.Equal($"Between {At(18, 12)} and {At(18, 30)} on 24 Sep 2026", Only(result, FindingKind.MissingBills).When.Plain());
        Assert.Equal("Oldest unpaid bill is from 2 Aug 2026", Only(result, FindingKind.OwedLong).When.Plain());
    }

    [Fact]
    public async Task A_price_problem_says_when_it_was_first_noticed_and_keeps_saying_so_while_its_figures_change()
    {
        _checks.Prices.Add(Price(1, price: 9m, cost: 9.5m));
        var service = Service();

        var first = await service.CheckAsync();
        var below = Only(first, FindingKind.BelowCost);
        Assert.Equal("Already there when this app first checked, on 26 Sep 2026", below.When.Plain());
        Assert.True(File.Exists(SeenFile), "kept in the data folder, beside the on purpose notes");

        // Three hours later another price is wrong: this one is first noticed now.
        _clock.Advance(TimeSpan.FromHours(3));
        _checks.Prices.Add(Price(2, price: 20m, cost: 0m));
        var second = await service.CheckAsync(fresh: true);
        Assert.Equal("First noticed 26 Sep 2026, " + At(14, 0), Only(second, FindingKind.NoCost).When.Plain());
        Assert.Equal("Already there when this app first checked, on 26 Sep 2026", Only(second, FindingKind.BelowCost).When.Plain());

        // The price drops further and is still below cost: the finding's figures changed (so a note "on purpose" would no longer
        // hide it), but it is the same problem and keeps the day it was noticed.
        _checks.Prices[0] = Price(1, price: 8m, cost: 9.5m);
        var third = await service.CheckAsync(fresh: true);
        var lower = Only(third, FindingKind.BelowCost);
        Assert.NotEqual(below.Key, lower.Key);
        Assert.Equal("Already there when this app first checked, on 26 Sep 2026", lower.When.Plain());
    }

    [Fact]
    public async Task A_problem_that_was_fixed_and_comes_back_is_noticed_again_and_what_was_seen_survives_a_restart()
    {
        _checks.Prices.Add(Price(1, price: 9m, cost: 9.5m));
        await Service().CheckAsync();

        _clock.Advance(TimeSpan.FromHours(1));
        _checks.Prices.Clear();
        var fixedUp = await Service().CheckAsync(fresh: true);
        Assert.Empty(fixedUp.Open);
        Assert.DoesNotContain("below-cost", File.ReadAllText(SeenFile));

        _clock.Advance(TimeSpan.FromHours(1));
        _checks.Prices.Add(Price(1, price: 9m, cost: 9.5m));
        var restarted = Service(); // a new run of the app reads what was kept
        var again = await restarted.CheckAsync(fresh: true);
        Assert.Equal("First noticed 26 Sep 2026, " + At(13, 0), Only(again, FindingKind.BelowCost).When.Plain());

        _clock.Advance(TimeSpan.FromHours(1));
        Assert.Equal("First noticed 26 Sep 2026, " + At(13, 0), Only(await Service().CheckAsync(fresh: true), FindingKind.BelowCost).When.Plain());
    }

    [Fact]
    public async Task When_the_pos_cannot_be_read_what_was_seen_is_not_forgotten()
    {
        _checks.Prices.Add(Price(1, price: 9m, cost: 9.5m));
        var service = Service();
        await service.CheckAsync();
        var kept = File.ReadAllText(SeenFile);

        _clock.Advance(TimeSpan.FromHours(1));
        _checks.Prices.Clear(); // would be "fixed", but the POS cannot be read at all
        var broken = new BrokenChecks();
        var failing = new FixNowService(broken, _invoices, _storage, Options.Create(new ShopOptions()), _clock, NullLogger<FixNowService>.Instance);
        var result = await failing.CheckAsync(fresh: true);

        Assert.NotNull(result.Problem);
        Assert.Equal(kept, File.ReadAllText(SeenFile));
    }

    private sealed class BrokenChecks : IShopChecksRepository
    {
        public Task<IReadOnlyList<PriceFacts>> GetPricesAsync(CancellationToken ct = default) => throw new InvalidOperationException("The POS cannot be read.");

        public Task<IReadOnlyList<SoldLine>> GetSoldLinesAsync(DateRange range, CancellationToken ct = default) => throw new InvalidOperationException("The POS cannot be read.");

        public Task<IReadOnlyList<BillStub>> GetBillsAsync(DateRange range, CancellationToken ct = default) => throw new InvalidOperationException("The POS cannot be read.");
    }
}

using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SmartRetail.Pos.Core.Actions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Data.Demo;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public class ProductTestTests
{
    private static readonly DateOnly Start = new(2026, 9, 1);

    /// <summary>Makhana (product 7), bought 24 for a test judged on 28 Sep, hoping to sell 20.</summary>
    private static ShopAction Makhana(decimal bought = 24, decimal hoped = 20, TestDecision? decision = null) => new()
    {
        Id = "t1",
        Title = "Makhana 100 g",
        Kind = ActionKind.NewProduct,
        Start = Start,
        ProductIds = new[] { 7 },
        ProductNames = new[] { "Makhana 100 g" },
        Test = new ProductTest { Signal = ProductSignal.CustomersAsked, Bought = bought, Hoped = hoped, ReviewOn = new DateOnly(2026, 9, 28), Decision = decision },
    };

    /// <summary>Two sold each on the given days, at ₹150 (₹134 before GST, ₹100 cost); another product sells too.</summary>
    private static IEnumerable<ProductDaySales> Sold(params int[] days) => days
        .Select(day => new ProductDaySales { Day = Start.AddDays(day), ProductId = 7, Qty = 2, Sales = 300, SalesBeforeTax = 268, CostedSalesBeforeTax = 268, Cost = 200, Bills = 2 })
        .Append(new ProductDaySales { Day = Start.AddDays(3), ProductId = 8, Qty = 50, Sales = 5000, SalesBeforeTax = 4500, Bills = 20 });

    [Fact]
    public void Before_its_review_day_it_shows_the_units_so_far()
    {
        var result = ProductTests.Judge(Makhana(), Sold(0, 2, 4, 30), new DateOnly(2026, 9, 10));

        Assert.Equal((TestVerdict.Running, 6m, 0.25m, 10), (result.Verdict, result.Sold, result.SellThrough, result.Days));
        Assert.Equal((900m, (decimal?)204m), (result.Sales, result.Profit));
        Assert.Null(result.Suggested);
        Assert.Equal("So far: 6 of the 24 bought (25%) in 10 days. You hope for 20 by 28 Sept. ₹900 in sales, ₹204 profit.", result.Summary);
        Assert.Null(result.Lesson);
    }

    [Fact]
    public void Not_started_it_says_when_it_starts_and_is_judged() =>
        Assert.Equal((TestVerdict.NotStarted, "Starts on 1 Sept, and is judged on 28 Sept."),
            (ProductTests.Judge(Makhana(), Sold(), new DateOnly(2026, 8, 30)) is var r ? (r.Verdict, r.Summary) : default));

    [Theory]
    [InlineData(10, 24, TestVerdict.AsHoped, TestDecision.Reorder)]    // 20 of 24 (83%): reorder
    [InlineData(12, 24, TestVerdict.AsHoped, TestDecision.BuyMore)]    // 24 of 24: sold out, buy more
    [InlineData(10, 40, TestVerdict.AsHoped, TestDecision.Reorder)]    // as hoped, with stock left
    [InlineData(6, 24, TestVerdict.BelowHopes, TestDecision.Hold)]     // 12 of 20 hoped
    [InlineData(3, 24, TestVerdict.Slow, TestDecision.MarkDown)]       // 6 of 20 hoped
    [InlineData(0, 24, TestVerdict.Slow, TestDecision.Stop)]           // none sold
    public void On_its_review_day_the_rules_judge_it_and_suggest_a_decision(int days, int bought, TestVerdict verdict, TestDecision suggested)
    {
        var sold = Sold(Enumerable.Range(0, days).Select(d => d * 2).ToArray());

        var result = ProductTests.Judge(Makhana(bought), sold, new DateOnly(2026, 10, 5));

        Assert.Equal((verdict, suggested, 28), (result.Verdict, result.Suggested, result.Days));
        Assert.Contains("The rules suggest:", result.Summary);
    }

    [Fact]
    public void Sales_after_the_review_day_are_left_out_and_the_lesson_comes_with_the_decision()
    {
        var judged = ProductTests.Judge(Makhana(decision: TestDecision.Reorder), Sold(0, 5, 10, 15, 20, 25, 27, 28, 29), new DateOnly(2026, 10, 3));

        Assert.Equal(14m, judged.Sold);
        Assert.Equal(TestVerdict.BelowHopes, judged.Verdict);
        Assert.Equal("14 of the 24 bought (58%) in the 28 days to 28 Sept; you hoped for 20. ₹2,100 in sales, ₹476 profit. The rules suggest: It sells, more slowly than hoped: hold, and watch it another month.", judged.Summary);
        Assert.Equal("New product Makhana 100 g (customers asked for it, 1–28 Sept 2026): sold 14 (24 bought, 20 hoped for); decided: reorder as before.", judged.Lesson);
    }

    [Fact]
    public void Selling_all_or_more_than_was_bought_says_so()
    {
        var all = ProductTests.Judge(Makhana(bought: 8), Sold(0, 2, 4, 6), new DateOnly(2026, 9, 10));
        var more = ProductTests.Judge(Makhana(bought: 6), Sold(0, 2, 4, 6), new DateOnly(2026, 10, 1));

        Assert.StartsWith("So far: all 8 bought were sold in 10 days.", all.Summary);
        Assert.StartsWith("8 sold, more than the 6 bought for the test, in the 28 days to 28 Sept; you hoped for 20.", more.Summary);
    }

    [Theory]
    [InlineData("2026-08-30", null, "Planned")]
    [InlineData("2026-09-10", null, "Testing · day 10 of 28")]
    [InlineData("2026-09-28", null, "To decide")]
    [InlineData("2026-10-05", TestDecision.Stop, "Decided")]
    public void A_tests_status_follows_its_days_and_the_decision(string today, TestDecision? decision, string status) =>
        Assert.Equal(status, ProductTests.Status(Makhana(decision: decision), DateOnly.Parse(today)));

    [Fact]
    public void Without_purchase_prices_there_is_no_profit()
    {
        var lines = new[] { new ProductDaySales { Day = Start, ProductId = 7, Qty = 3, Sales = 450, SalesBeforeTax = 402, Bills = 3 } };

        Assert.Null(ProductTests.Judge(Makhana(), lines, new DateOnly(2026, 9, 5)).Profit);
    }

    [Theory]
    [InlineData(0, 20, 27, "Say how many were bought for the test.")]
    [InlineData(24, 0, 27, "Say how many you hope to sell by the review day.")]
    [InlineData(200_000, 20, 27, "Those are more units than a test needs.")]
    [InlineData(24, 20, 0, "The review day comes after the start.")]
    [InlineData(24, 20, 400, "Judge the test within a year of its start.")]
    [InlineData(24, 30, 27, null)]
    public void A_test_needs_units_and_a_review_day_after_its_start(decimal bought, decimal hoped, int reviewAfter, string? problem)
    {
        var test = new ProductTest { Bought = bought, Hoped = hoped, ReviewOn = Start.AddDays(reviewAfter) };

        Assert.Equal(problem, (Makhana() with { Test = test }).Problem());
    }

    [Fact]
    public void Only_a_new_product_chosen_in_the_POS_is_tested()
    {
        Assert.Equal("Only a new product is tested.", (Makhana() with { Kind = ActionKind.Offer }).Problem());
        Assert.Equal("Choose the new product, so its sales can be counted.", (Makhana() with { ProductIds = Array.Empty<int>() }).Problem());
        Assert.Equal("A test is for one new product: keep just that one, so its own units are judged.",
            (Makhana() with { ProductIds = new[] { 7, 8 }, ProductNames = new[] { "Makhana 100 g", "Roasted chana 200 g" } }).Problem());
        Assert.Null((Makhana() with { Test = null, ProductIds = Array.Empty<int>() }).Problem());
    }

    [Fact]
    public void Every_signal_and_decision_has_words()
    {
        Assert.Equal(6, ProductTests.Signals.Select(s => s.Name()).Distinct().Count());
        Assert.Equal(6, ProductTests.Decisions.Select(d => d.Name()).Distinct().Count());
        Assert.Equal(new string?[] { null, null, "good", "warn", "bad" }, Enum.GetValues<TestVerdict>().Select(v => v.Tone()));
    }
}

public sealed class ProductTestServiceTests : IDisposable
{
    private static readonly DateTimeOffset Monday = new(2026, 9, 28, 11, 0, 0, TimeSpan.FromHours(5.5));

    private readonly string _root = Directory.CreateTempSubdirectory("product-tests-").FullName;
    private readonly DemoStore _pos = new(new FixedClock(Monday), seedSales: true);
    private readonly ActionService _actions;

    public ProductTestServiceTests()
    {
        File.WriteAllText(Path.Combine(_root, SmartRetail.AI.Storage.StorageSettingsStore.FileName), JsonSerializer.Serialize(new { DataFolder = Path.Combine(_root, "data") }));
        var options = Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") });
        var storage = new StorageService(options);
        var clock = new FixedClock(Monday);
        _actions = new ActionService(storage, _pos, new MemoryService(storage, new AiEnvironment(options), clock, NullLogger<MemoryService>.Instance), clock,
            NullLogger<ActionService>.Instance);
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private async Task<(int Id, string Name)> BestSellerAsync()
    {
        var week = new DateRange(new DateOnly(2026, 9, 1), new DateOnly(2026, 9, 27));
        var top = SalesAnalysis.Analyse(await _pos.GetFactsAsync(week), new SalesFacts(), await _pos.GetProductsAsync()).TopProducts[0];
        return (top.ProductId, top.Name);
    }

    [Fact]
    public async Task A_test_is_judged_from_its_own_units_and_the_owners_decision_is_kept_once_it_is_due()
    {
        var (id, name) = await BestSellerAsync();
        Assert.Null(_actions.Add(new ShopAction
        {
            Title = name,
            Kind = ActionKind.NewProduct,
            Start = new DateOnly(2026, 9, 1),
            ProductIds = new[] { id },
            ProductNames = new[] { name },
            Test = new ProductTest { Signal = ProductSignal.SupplierOffer, Bought = 10, Hoped = 5, ReviewOn = new DateOnly(2026, 9, 21) },
        }));
        Assert.Null(_actions.Add(new ShopAction
        {
            Title = "Not due yet",
            Kind = ActionKind.NewProduct,
            Start = new DateOnly(2026, 9, 20),
            ProductIds = new[] { id },
            Test = new ProductTest { Bought = 10, Hoped = 5, ReviewOn = new DateOnly(2026, 10, 18) },
        }));
        var tested = _actions.Load().Actions.Single(a => a.Title == name);
        var waiting = _actions.Load().Actions.Single(a => a.Title == "Not due yet");

        var result = await _actions.MeasureAsync(tested, CancellationToken.None);
        var lines = (await _pos.GetFactsAsync(new DateRange(tested.Start, new DateOnly(2026, 9, 21)))).ProductDays.Where(l => l.ProductId == id);
        Assert.Equal(lines.Sum(l => l.Qty), result.Test!.Sold);
        Assert.Equal(TestVerdict.AsHoped, result.Test.Verdict);
        Assert.Equal(TestDecision.BuyMore, result.Test.Suggested);
        Assert.Null(result.Lesson);
        Assert.Equal(new[] { tested.Id }, _actions.TestsToDecide().Select(a => a.Id));

        Assert.Equal("Its test is judged on 18 Oct 2026: decide then.", _actions.DecideTest(waiting.Id, TestDecision.Stop, null));
        Assert.Equal($"Keep the note under {ProductTest.MaxNote} characters.", _actions.DecideTest(tested.Id, TestDecision.Hold, new string('x', 201)));
        Assert.Null(_actions.DecideTest(tested.Id, TestDecision.BuyMore, "  Order 30 from the wholesaler  "));

        var decided = _actions.Load().Actions.Single(a => a.Id == tested.Id).Test!;
        Assert.Equal((TestDecision.BuyMore, "Order 30 from the wholesaler", new DateOnly(2026, 9, 28)), (decided.Decision!.Value, decided.DecisionNote, decided.DecidedOn!.Value));
        Assert.Empty(_actions.TestsToDecide());
        var lesson = (await _actions.MeasureAsync(_actions.Load().Actions.Single(a => a.Id == tested.Id), CancellationToken.None)).Lesson;
        Assert.EndsWith("decided: buy more next time.", lesson);
    }
}

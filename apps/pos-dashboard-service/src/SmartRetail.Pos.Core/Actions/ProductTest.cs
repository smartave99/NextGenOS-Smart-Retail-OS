using System.Globalization;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Core.Actions;

/// <summary>Why a new product came into the shop: the plan's "signal source".</summary>
public enum ProductSignal
{
    CustomersAsked,
    SellsElsewhere,
    SupplierOffer,
    Season,
    NearbyShop,
    Other,
}

/// <summary>What the owner decided on a new product once its test was judged: the plan's "decision".</summary>
public enum TestDecision
{
    Reorder,
    BuyMore,
    Hold,
    Bundle,
    MarkDown,
    Stop,
}

/// <summary>How a new product's test went, by its review day.</summary>
public enum TestVerdict
{
    /// <summary>It has not started.</summary>
    NotStarted,

    /// <summary>Its review day has not come; the figures so far are shown.</summary>
    Running,

    /// <summary>It sold at least what was hoped for.</summary>
    AsHoped,

    /// <summary>It sold at least half of what was hoped for.</summary>
    BelowHopes,

    /// <summary>It sold less than half of what was hoped for.</summary>
    Slow,
}

public static class ProductTests
{
    /// <summary>A test is judged four weeks after it starts, unless the owner says otherwise.</summary>
    public const int DefaultReviewDays = 28;

    /// <summary>A test runs a year at most.</summary>
    public const int MaxReviewDays = 365;

    public const decimal MaxUnits = 100_000m;

    /// <summary>What sold out of what was bought, at or above which a product that sold as hoped is reordered.</summary>
    public const decimal GoodSellThrough = 0.8m;

    private static readonly CultureInfo India = CultureInfo.GetCultureInfo("en-IN");

    public static IReadOnlyList<ProductSignal> Signals { get; } = Enum.GetValues<ProductSignal>();

    public static IReadOnlyList<TestDecision> Decisions { get; } = Enum.GetValues<TestDecision>();

    public static string Name(this ProductSignal signal) => signal switch
    {
        ProductSignal.CustomersAsked => "Customers asked for it",
        ProductSignal.SellsElsewhere => "It sells well online or elsewhere",
        ProductSignal.SupplierOffer => "A supplier offered it",
        ProductSignal.Season => "A season or festival",
        ProductSignal.NearbyShop => "A shop nearby sells it",
        _ => "Something else",
    };

    public static string Name(this TestDecision decision) => decision switch
    {
        TestDecision.Reorder => "Reorder as before",
        TestDecision.BuyMore => "Buy more next time",
        TestDecision.Hold => "Hold: wait and watch",
        TestDecision.Bundle => "Bundle it with a best seller",
        TestDecision.MarkDown => "Mark it down",
        _ => "Stop: do not reorder",
    };

    public static string Name(this TestVerdict verdict) => verdict switch
    {
        TestVerdict.NotStarted => "Not started",
        TestVerdict.Running => "Testing",
        TestVerdict.AsHoped => "Sold as hoped",
        TestVerdict.BelowHopes => "Below hopes",
        _ => "Slow",
    };

    /// <summary>Where a test stands: planned, testing (day n of the test), to decide, or decided.</summary>
    public static string Status(ShopAction action, DateOnly today)
    {
        ArgumentNullException.ThrowIfNull(action);
        var test = action.Test ?? throw new ArgumentException("The action is not a new product's test.", nameof(action));
        return action.Start > today ? "Planned"
            : test.Decision is not null ? "Decided"
            : today >= test.ReviewOn ? "To decide"
            : $"Testing · day {today.DayNumber - action.Start.DayNumber + 1} of {test.ReviewOn.DayNumber - action.Start.DayNumber + 1}";
    }

    /// <summary>The tone of its label: "good", "warn", "bad", or null before the review day.</summary>
    public static string? Tone(this TestVerdict verdict) => verdict switch
    {
        TestVerdict.AsHoped => "good",
        TestVerdict.BelowHopes => "warn",
        TestVerdict.Slow => "bad",
        _ => null,
    };

    /// <summary>
    /// How a new product's test went: its units sold from the start to the review day (to today before then) against
    /// the units bought and the units hoped for, with its sales and profit. On the review day the rules suggest a
    /// decision, which the owner makes. Pure, so every rule is tested.
    /// </summary>
    /// <param name="lines">The action's products' bill lines from its start on; others are left out.</param>
    public static TestResult Judge(ShopAction action, IEnumerable<ProductDaySales> lines, DateOnly today)
    {
        ArgumentNullException.ThrowIfNull(action);
        ArgumentNullException.ThrowIfNull(lines);
        var test = action.Test ?? throw new ArgumentException("The action is not a new product's test.", nameof(action));
        if (today < action.Start)
        {
            return new TestResult
            {
                Verdict = TestVerdict.NotStarted,
                Summary = $"Starts on {Day(action.Start)}, and is judged on {Day(test.ReviewOn)}.",
            };
        }

        var judged = today >= test.ReviewOn;
        var last = judged ? test.ReviewOn : today;
        var products = action.ProductIds.ToHashSet();
        var counted = lines.Where(l => products.Contains(l.ProductId) && l.Day >= action.Start && l.Day <= last).ToList();
        var sold = counted.Sum(l => l.Qty);
        var costed = counted.Sum(l => l.CostedSalesBeforeTax);
        var result = new TestResult
        {
            Sold = sold,
            SellThrough = sold / test.Bought,
            Sales = counted.Sum(l => l.Sales),
            Profit = costed > 0 ? costed - counted.Sum(l => l.Cost) : null,
            Days = last.DayNumber - action.Start.DayNumber + 1,
        };
        // More than bought means it was restocked during the test.
        var figures = sold > test.Bought ? $"{Units(sold)} sold, more than the {Units(test.Bought)} bought for the test,"
            : sold == test.Bought ? $"all {Units(test.Bought)} bought were sold"
            : $"{Units(sold)} of the {Units(test.Bought)} bought ({Percent(result.SellThrough)})";
        var money = result.Sales > 0
            ? $" {Rupees(result.Sales)} in sales" + (result.Profit is { } profit ? $", {Rupees(profit)} profit." : ".")
            : "";

        if (!judged)
        {
            return result with
            {
                Verdict = TestVerdict.Running,
                Summary = $"So far: {figures} in {Plural(result.Days, "day")}. You hope for {Units(test.Hoped)} by {Day(test.ReviewOn)}.{money}",
            };
        }

        var verdict = sold >= test.Hoped ? TestVerdict.AsHoped : sold * 2 >= test.Hoped ? TestVerdict.BelowHopes : TestVerdict.Slow;
        var (suggested, why) = verdict switch
        {
            TestVerdict.AsHoped when sold >= test.Bought => (TestDecision.BuyMore, "It sold out: buy more next time."),
            TestVerdict.AsHoped when result.SellThrough >= GoodSellThrough => (TestDecision.Reorder, "It sold as hoped: reorder."),
            TestVerdict.AsHoped => (TestDecision.Reorder, "It sold as hoped, with stock left: reorder when it runs low."),
            TestVerdict.BelowHopes => (TestDecision.Hold, "It sells, more slowly than hoped: hold, and watch it another month."),
            _ when sold == 0 => (TestDecision.Stop, "Nothing sold: do not reorder, and clear what is left, e.g. with a clearance poster."),
            _ => (TestDecision.MarkDown, "It sells slowly: mark it down or bundle it with a best seller, and do not reorder."),
        };

        return result with
        {
            Verdict = verdict,
            Suggested = suggested,
            Summary = $"{Capital(figures)} in the {Plural(result.Days, "day")} to {Day(test.ReviewOn)}; you hoped for {Units(test.Hoped)}.{money} The rules suggest: {why}",
            Lesson = test.Decision is { } decision ? Lesson(action, test, sold, decision) : null,
        };
    }

    /// <summary>One line for memory once the owner decided, e.g. "New product Makhana 100 g (customers asked for it, 1–28
    /// Oct 2026): sold 18 (24 bought, 20 hoped for); decided: reorder as before."</summary>
    private static string Lesson(ShopAction action, ProductTest test, decimal sold, TestDecision decision)
    {
        var title = action.Title.Trim();
        if (title.Length > 80)
        {
            title = title[..80].TrimEnd() + "…";
        }

        return $"New product {title} ({test.Signal.Name().ToLowerInvariant()}, {ActionMeasure.Dates(new DateRange(action.Start, test.ReviewOn))}): "
            + $"sold {Units(sold)} ({Units(test.Bought)} bought, {Units(test.Hoped)} hoped for); decided: {decision.Name().ToLowerInvariant()}.";
    }

    private static string Units(decimal qty) => Money.FormatQty(qty);

    private static string Percent(decimal? share) => share is not { } value ? "–"
        : Math.Round(value * 100m, 0, MidpointRounding.AwayFromZero).ToString("0", CultureInfo.InvariantCulture) + "%";

    private static string Rupees(decimal amount) => Money.FormatCompact(Money.RoundToRupee(amount));

    private static string Day(DateOnly day) => day.ToString("d MMM", India);

    private static string Capital(string text) => text.Length == 0 ? text : char.ToUpperInvariant(text[0]) + text[1..];

    private static string Plural(int count, string word) => count == 1 ? "1 " + word : count + " " + word + "s";
}

/// <summary>
/// The plan's fields for a new product, kept on its action: why it came in, how many were bought for the test (few,
/// so it can fail cheaply), how many are hoped to sell by the review day, and what the owner decided then.
/// </summary>
public sealed record ProductTest
{
    public const int MaxNote = 200;

    public ProductSignal Signal { get; init; }

    /// <summary>Units bought for the test.</summary>
    public decimal Bought { get; init; }

    /// <summary>Units hoped to sell by <see cref="ReviewOn"/>.</summary>
    public decimal Hoped { get; init; }

    public DateOnly ReviewOn { get; init; }

    /// <summary>What the owner decided on the review day; null before.</summary>
    public TestDecision? Decision { get; init; }

    public string DecisionNote { get; init; } = "";

    public DateOnly? DecidedOn { get; init; }

    /// <summary>Why it cannot be saved for an action starting on <paramref name="start"/>, or null.</summary>
    public string? Problem(DateOnly start)
    {
        if (Bought <= 0)
        {
            return "Say how many were bought for the test.";
        }

        if (Hoped <= 0)
        {
            return "Say how many you hope to sell by the review day.";
        }

        if (Bought > ProductTests.MaxUnits || Hoped > ProductTests.MaxUnits)
        {
            return "Those are more units than a test needs.";
        }

        if (ReviewOn <= start)
        {
            return "The review day comes after the start.";
        }

        if (ReviewOn.DayNumber - start.DayNumber > ProductTests.MaxReviewDays)
        {
            return "Judge the test within a year of its start.";
        }

        return DecisionNote.Length > MaxNote ? $"Keep the note under {MaxNote} characters." : null;
    }
}

/// <summary>How a new product's test went (<see cref="ProductTests.Judge"/>).</summary>
public sealed record TestResult
{
    public TestVerdict Verdict { get; init; }

    /// <summary>Units sold from the start to the review day, or to today before then.</summary>
    public decimal Sold { get; init; }

    /// <summary>Sold out of what was bought, e.g. 0.75.</summary>
    public decimal? SellThrough { get; init; }

    /// <summary>Its sales, GST included.</summary>
    public decimal Sales { get; init; }

    /// <summary>Sales before GST less purchase cost, on lines with a purchase price; null when none has one.</summary>
    public decimal? Profit { get; init; }

    /// <summary>The days counted.</summary>
    public int Days { get; init; }

    /// <summary>What the rules suggest on the review day; null before.</summary>
    public TestDecision? Suggested { get; init; }

    public string Summary { get; init; } = "";

    /// <summary>One line for memory, once the owner decided; null before.</summary>
    public string? Lesson { get; init; }
}

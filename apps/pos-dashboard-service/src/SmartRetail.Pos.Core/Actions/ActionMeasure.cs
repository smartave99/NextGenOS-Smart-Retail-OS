using System.Globalization;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Core.Actions;

public enum ActionVerdict
{
    /// <summary>It has not started, or started today.</summary>
    Planned,

    /// <summary>Less than a week of its days is over.</summary>
    TooEarly,

    /// <summary>No sales in the days before it to compare with.</summary>
    NothingToCompare,

    /// <summary>Too few bills before it for a change to mean anything, e.g. a product that seldom sells.</summary>
    TooFewSales,
    Rose,
    NoClearChange,
    Fell,
}

public static class ActionVerdicts
{
    /// <summary>The verdict in a few words, as the Actions page and the Monday review show it.</summary>
    public static string Name(this ActionVerdict verdict) => verdict switch
    {
        ActionVerdict.Planned => "No figures yet",
        ActionVerdict.TooEarly => "Too early to tell",
        ActionVerdict.NothingToCompare => "Nothing to compare with",
        ActionVerdict.TooFewSales => "Too few sales to tell",
        ActionVerdict.Rose => "Sales rose",
        ActionVerdict.Fell => "Sales fell",
        _ => "No clear change",
    };

    /// <summary>The tone of its label: "good", "bad", "warn", or null for no verdict yet.</summary>
    public static string? Tone(this ActionVerdict verdict) => verdict switch
    {
        ActionVerdict.Rose => "good",
        ActionVerdict.Fell => "bad",
        ActionVerdict.NoClearChange => "warn",
        _ => null,
    };
}

/// <summary>Sales in some days: the whole shop's, or those of an action's products.</summary>
public sealed record WindowFigures
{
    public DateRange Range { get; init; }

    /// <summary>Sales, GST included; for the whole shop, less returns.</summary>
    public decimal Sales { get; init; }

    /// <summary>The bill lines' sales, GST included, and before GST: how much of the sales is GST.</summary>
    public decimal LineSales { get; init; }
    public decimal LineSalesBeforeTax { get; init; }

    /// <summary>For the whole shop, bills; for products, bills with any of them, each counted once.</summary>
    public int Bills { get; init; }
    public decimal Qty { get; init; }

    /// <summary>Profit before GST on the lines with a purchase price, and those lines' sales before GST.</summary>
    public decimal Profit { get; init; }
    public decimal CostedSalesBeforeTax { get; init; }

    public decimal SalesPerDay => Sales / Range.Days;

    /// <summary>The figures of <paramref name="productIds"/> in <paramref name="facts"/>, or the whole shop's when none.</summary>
    /// <param name="billsWithProducts">For products: the bills with any of them, each counted once, as the POS counts
    /// them (<see cref="Abstractions.ISalesFactsRepository.CountBillsWithAsync"/>). Without it the count is a floor,
    /// each day's most bills of any one product, so a bill with two of them never counts twice.</param>
    public static WindowFigures From(SalesFacts facts, IReadOnlyCollection<int> productIds, int? billsWithProducts = null)
    {
        ArgumentNullException.ThrowIfNull(facts);
        ArgumentNullException.ThrowIfNull(productIds);
        var wholeShop = productIds.Count == 0;
        var lines = wholeShop ? facts.ProductDays : facts.ProductDays.Where(p => productIds.Contains(p.ProductId)).ToList();
        var costed = lines.Sum(l => l.CostedSalesBeforeTax);
        return new WindowFigures
        {
            Range = facts.Range,
            Sales = wholeShop ? facts.Days.Sum(d => d.Sales - d.Returns) : lines.Sum(l => l.Sales),
            LineSales = lines.Sum(l => l.Sales),
            LineSalesBeforeTax = lines.Sum(l => l.SalesBeforeTax),
            Bills = wholeShop ? facts.Days.Sum(d => d.Bills) : billsWithProducts ?? lines.GroupBy(l => l.Day).Sum(day => day.Max(l => l.Bills)),
            Qty = lines.Sum(l => l.Qty),
            Profit = costed - lines.Sum(l => l.Cost),
            CostedSalesBeforeTax = costed,
        };
    }
}

/// <summary>What the figures say about an action.</summary>
public sealed record ActionResult
{
    public ActionVerdict Verdict { get; init; }
    public WindowFigures? During { get; init; }

    /// <summary>The same number of days just before it.</summary>
    public WindowFigures? Before { get; init; }

    /// <summary>The same dates last year, and the days before them, when the POS has bills from then.</summary>
    public WindowFigures? LastYear { get; init; }
    public WindowFigures? LastYearBefore { get; init; }

    /// <summary>Sales a day against the days just before, e.g. 0.08 for 8% more.</summary>
    public decimal? Change { get; init; }

    /// <summary>The season: how the same dates did last year against the days before them.</summary>
    public decimal? Season { get; init; }

    /// <summary>The change beyond the season: what the action seems to have done.</summary>
    public decimal? Lift { get; init; }

    public decimal? ExtraSales { get; init; }
    public decimal? ExtraProfit { get; init; }
    public bool? PaidBack { get; init; }

    /// <summary>What the figures say, in a few plain sentences.</summary>
    public string Summary { get; init; } = "";

    /// <summary>One line for memory, once there is a verdict; null before.</summary>
    public string? Lesson { get; init; }

    /// <summary>For a new product's test, how it went (its units against those bought and hoped for); null otherwise.</summary>
    public TestResult? Test { get; init; }

    public bool HasVerdict => Verdict is ActionVerdict.Rose or ActionVerdict.NoClearChange or ActionVerdict.Fell;
}

/// <summary>
/// Whether an action changed sales. Its days are compared with the same number of days just before it, and, when
/// the POS has bills from a year before, the season is allowed for: last year's same dates against the days before
/// them. Pure, so every rule is tested.
/// </summary>
public static class ActionMeasure
{
    /// <summary>Fewer days than this say too little.</summary>
    public const int MinDays = 7;

    /// <summary>A change beyond the season smaller than this (either way) is no clear change.</summary>
    public const decimal ClearChange = 0.05m;

    /// <summary>Fewer bills than this in the days before it (with its products, for some products) say too little.</summary>
    public const int MinBills = 10;

    private static readonly CultureInfo India = CultureInfo.GetCultureInfo("en-IN");

    /// <summary>Its days with full figures: from the start to its end, or to yesterday while it goes on, as today is
    /// not over. Null until a day of it is over.</summary>
    public static DateRange? DaysSoFar(ShopAction action, DateOnly today)
    {
        ArgumentNullException.ThrowIfNull(action);
        var last = action.End is { } end && end < today ? end : today.AddDays(-1);
        return last < action.Start ? null : new DateRange(action.Start, last);
    }

    /// <summary>The same dates a year before.</summary>
    public static DateRange YearBefore(DateRange range) => new(range.From.AddYears(-1), range.To.AddYears(-1));

    public static ActionResult Judge(ShopAction action, DateOnly today, WindowFigures? during, WindowFigures? before,
        WindowFigures? lastYear = null, WindowFigures? lastYearBefore = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (during is null)
        {
            return new ActionResult
            {
                Verdict = ActionVerdict.Planned,
                Summary = action.Start > today
                    ? $"Starts on {Day(action.Start)}. Its figures come a week after that."
                    : "It starts today. Its figures come after a week.",
            };
        }

        if (during.Range.Days < MinDays)
        {
            return new ActionResult
            {
                Verdict = ActionVerdict.TooEarly,
                During = during,
                Summary = $"Too early to tell: {Plural(during.Range.Days, "day")} so far. The figures come after a week.",
            };
        }

        if (before is not { Sales: > 0 })
        {
            return new ActionResult
            {
                Verdict = ActionVerdict.NothingToCompare,
                During = during,
                Before = before,
                Summary = "The POS has no sales from the days before it to compare with.",
            };
        }

        if (before.Bills < MinBills)
        {
            return new ActionResult
            {
                Verdict = ActionVerdict.TooFewSales,
                During = during,
                Before = before,
                Summary = $"Too few sales to tell: {Plural(before.Bills, "bill")}{(action.IsWholeShop ? "" : " with its products")} in the {Plural(before.Range.Days, "day")} before it, and a change needs at least {MinBills} to mean something.",
            };
        }

        var change = during.SalesPerDay / before.SalesPerDay - 1m;
        decimal? season = lastYear is { Sales: > 0 } year && lastYearBefore is { Sales: > 0 } yearBefore
            ? year.SalesPerDay / yearBefore.SalesPerDay - 1m
            : null;
        var lift = season is { } s ? (1m + change) / (1m + s) - 1m : change;
        var verdict = lift >= ClearChange ? ActionVerdict.Rose : lift <= -ClearChange ? ActionVerdict.Fell : ActionVerdict.NoClearChange;

        var extraSales = during.Sales - before.SalesPerDay * (1m + (season ?? 0m)) * during.Range.Days;
        decimal? extraProfit = during.CostedSalesBeforeTax > 0 && during.LineSales > 0
            ? extraSales * (during.LineSalesBeforeTax / during.LineSales) * (during.Profit / during.CostedSalesBeforeTax)
            : null;
        bool? paidBack = action.Cost > 0 && extraProfit is { } profit ? profit >= action.Cost : null;
        var running = action.End is not { } end || end >= today;

        var what = action.IsWholeShop ? "Sales a day" : "Its products' sales a day";
        var summary = $"{what}: {Rupees(during.SalesPerDay)}, {Compared(change)} the {Plural(before.Range.Days, "day")} before ({Rupees(before.SalesPerDay)}). ";
        summary += season is { } seasonChange
            ? $"Last year these dates were {Moved(seasonChange)} the days before them. "
            : "The POS has no bills from these dates last year, so the season is not allowed for. ";
        summary += verdict switch
        {
            ActionVerdict.Rose => $"So it seems to have added about {Percent(lift)}.",
            ActionVerdict.Fell => $"So sales were about {Percent(-lift)} lower than {(season is null ? "before" : "the season would bring")}.",
            _ => "So no clear change came from it.",
        };

        if (verdict == ActionVerdict.Rose)
        {
            summary += $" About {Rupees(extraSales)} more in sales" + (extraProfit is { } more ? $" and {Rupees(more)} more profit" : "");
            summary += action.Cost > 0
                ? $", for {Rupees(action.Cost)} spent: " + (paidBack == true ? "it paid for itself." : running ? "it has not paid for itself yet." : "it did not pay for itself.")
                : ".";
        }
        else if (action.Cost > 0)
        {
            summary += $" It cost {Rupees(action.Cost)}.";
        }

        return new ActionResult
        {
            Verdict = verdict,
            During = during,
            Before = before,
            LastYear = season is null ? null : lastYear,
            LastYearBefore = season is null ? null : lastYearBefore,
            Change = change,
            Season = season,
            Lift = lift,
            ExtraSales = extraSales,
            ExtraProfit = extraProfit,
            PaidBack = paidBack,
            Summary = summary,
            Lesson = Lesson(action, during.Range, verdict, lift, season is not null, extraProfit, paidBack, running),
        };
    }

    /// <summary>"1–30 Oct 2026", "25 Sept – 5 Oct 2026", or "20 Dec 2025 – 5 Jan 2026".</summary>
    public static string Dates(DateRange range)
    {
        if (range.From == range.To)
        {
            return range.From.ToString("d MMM yyyy", India);
        }

        if (range.From.Year != range.To.Year)
        {
            return $"{range.From.ToString("d MMM yyyy", India)} – {range.To.ToString("d MMM yyyy", India)}";
        }

        return range.From.Month == range.To.Month
            ? $"{range.From.Day}–{range.To.ToString("d MMM yyyy", India)}"
            : $"{range.From.ToString("d MMM", India)} – {range.To.ToString("d MMM yyyy", India)}";
    }

    private static string Lesson(ShopAction action, DateRange days, ActionVerdict verdict, decimal lift, bool seasonKnown,
        decimal? extraProfit, bool? paidBack, bool running)
    {
        var title = action.Title.Trim();
        if (title.Length > 80)
        {
            title = title[..80].TrimEnd() + "…";
        }

        var what = $"{title} ({action.Kind.Name().ToLowerInvariant()}, {Dates(days)}{(running ? " so far" : "")}"
            + (action.Cost > 0 ? $", {Rupees(action.Cost)}" : "")
            + (action.IsWholeShop ? "" : ", for some products")
            + "): ";
        var than = seasonKnown ? "the season" : "before";
        return what + verdict switch
        {
            ActionVerdict.Rose => $"sales about {Percent(lift)} above {than}"
                + (extraProfit is { } profit ? $", about {Rupees(profit)} more profit" : "")
                + (paidBack switch { true => "; it paid for itself.", false => "; it did not pay for itself.", _ => "." }),
            ActionVerdict.Fell => $"sales about {Percent(-lift)} below {than}.",
            _ => "no clear change in sales.",
        };
    }

    private static string Compared(decimal change) => Math.Abs(change) < 0.005m
        ? "about the same as"
        : change > 0 ? $"{Percent(change)} more than" : $"{Percent(-change)} less than";

    private static string Moved(decimal change) => Math.Abs(change) < 0.005m
        ? "about the same as"
        : change > 0 ? $"{Percent(change)} up on" : $"{Percent(-change)} down on";

    private static string Percent(decimal share) =>
        Math.Round(share * 100m, 0, MidpointRounding.AwayFromZero).ToString("0", CultureInfo.InvariantCulture) + "%";

    private static string Rupees(decimal amount) => Money.FormatCompact(Money.RoundToRupee(amount));

    private static string Day(DateOnly day) => day.ToString("d MMM", India);

    private static string Plural(int count, string word) => count == 1 ? "1 " + word : count + " " + word + "s";
}

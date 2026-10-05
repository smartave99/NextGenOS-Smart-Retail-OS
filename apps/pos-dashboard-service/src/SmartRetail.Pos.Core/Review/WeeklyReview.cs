using System.Globalization;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Core.Review;

public enum AlertKind
{
    /// <summary>A regular seller that is running out.</summary>
    StockOut,

    /// <summary>Stock that has not sold for <see cref="ShopAlerts.DeadAfterDays"/> days.</summary>
    DeadStock,
}

/// <summary>
/// What the rules recommend for one product, with the figures behind it, so the owner can judge it: the machine
/// proposes, the owner decides (<see cref="AlertDecision"/>).
/// </summary>
public sealed record ShopAlert
{
    public AlertKind Kind { get; init; }
    public int ProductId { get; init; }
    public string Name { get; init; } = "";
    public decimal StockInHand { get; init; }

    /// <summary>What it sold a day at the last 4 weeks' pace (stock-outs).</summary>
    public decimal? QtyPerDay { get; init; }

    /// <summary>Days its stock lasts at that pace (stock-outs).</summary>
    public decimal? DaysLeft { get; init; }

    /// <summary>Its stock at purchase price, or at selling price without one (dead stock).</summary>
    public decimal StockValue { get; init; }

    /// <summary>The figures, in words, e.g. "4 left; it sells about 2 a day".</summary>
    public string Figures { get; init; } = "";

    /// <summary>What to do, in words, e.g. "Reorder: at the last 4 weeks' pace it runs out in about 2 days."</summary>
    public string Recommendation { get; init; } = "";
}

/// <summary>
/// The rules that raise alerts: plain rules first, as the plan says, with their figures shown. Stock-outs use the same
/// rule as Today and the Sales page (a regular seller whose stock lasts under a week at the last 4 weeks' pace, is at
/// its reorder level, or is out); dead stock is stock not sold at all for 8 weeks. Pure and tested.
/// </summary>
public static class ShopAlerts
{
    /// <summary>Days whose sales set a product's pace, as on Today.</summary>
    public const int PaceDays = TodayFigures.DaysNeeded;

    /// <summary>Days without a sale after which stock counts as dead.</summary>
    public const int DeadAfterDays = 56;

    /// <summary>The alerts at most, of each kind, most urgent or valuable first.</summary>
    public const int MaxEach = 12;

    /// <summary>
    /// The alerts for <paramref name="today"/>, from the sales of the last <see cref="DeadAfterDays"/> days (at least) and
    /// every product's stock now.
    /// </summary>
    public static IReadOnlyList<ShopAlert> Find(SalesFacts facts, IReadOnlyList<ProductFacts> products, DateOnly today)
    {
        ArgumentNullException.ThrowIfNull(facts);
        ArgumentNullException.ThrowIfNull(products);
        var alerts = new List<ShopAlert>();

        var pace = DateRange.Ending(today, PaceDays);
        foreach (var item in SalesAnalysis.Analyse(facts with { Range = pace }, new SalesFacts { Range = pace.Previous }, products).ReorderNow.Take(MaxEach))
        {
            var left = Math.Max(0m, item.StockInHand);
            alerts.Add(new ShopAlert
            {
                Kind = AlertKind.StockOut,
                ProductId = item.ProductId,
                Name = item.Name,
                StockInHand = item.StockInHand,
                QtyPerDay = item.QtyPerDay,
                DaysLeft = item.DaysOfStock,
                Figures = $"{(left > 0 ? Qty(left) + " left" : "None in stock")}; it sells about {Rate(item.QtyPerDay)} a day",
                Recommendation = left <= 0 ? "Reorder: it is out of stock, and it sells every week."
                    : item.DaysOfStock < 1m ? "Reorder today: at the last 4 weeks' pace it may run out today."
                    : item.MinStock > 0 && item.StockInHand <= item.MinStock && item.DaysOfStock >= SalesAnalysis.ReorderWithinDays
                        ? $"Reorder: it is at its reorder level of {Qty(item.MinStock)}."
                        : $"Reorder: at the last 4 weeks' pace it runs out in about {Rate(item.DaysOfStock)} days.",
            });
        }

        var still = DateRange.Ending(today, DeadAfterDays);
        foreach (var item in SalesAnalysis.Analyse(facts with { Range = still }, new SalesFacts { Range = still.Previous }, products).SlowMovers.Take(MaxEach))
        {
            alerts.Add(new ShopAlert
            {
                Kind = AlertKind.DeadStock,
                ProductId = item.ProductId,
                Name = item.Name,
                StockInHand = item.StockInHand,
                StockValue = item.StockValue,
                Figures = $"{Qty(item.StockInHand)} in stock, {Rupees(item.StockValue)} tied up; not sold in 8 weeks",
                Recommendation = "Stop reordering it, and clear it: move it to the front, bundle it with a best seller, or make a clearance poster.",
            });
        }

        return alerts;
    }

    internal static string Qty(decimal qty) => Money.FormatQty(qty);

    internal static string Rate(decimal value) => value.ToString(value >= 10m ? "0" : "0.#", CultureInfo.InvariantCulture);

    internal static string Rupees(decimal amount) => Money.FormatCompact(Money.RoundToRupee(amount));
}

public enum DecisionChoice
{
    /// <summary>The owner does what was recommended.</summary>
    Accepted,

    /// <summary>The owner does something else, said in the note.</summary>
    Changed,

    /// <summary>The owner does nothing now, with the reason in the note.</summary>
    Rejected,
}

/// <summary>
/// A recommendation and what the owner decided, and later what happened (the plan's "decision event"): which rule
/// proposed what, with which figures, whether it was taken, and the outcome on its review day.
/// </summary>
public sealed record AlertDecision
{
    public const int MaxNote = 200;

    public string Id { get; init; } = "";
    public AlertKind Kind { get; init; }
    public int ProductId { get; init; }
    public string Name { get; init; } = "";
    public string Figures { get; init; } = "";
    public string Recommendation { get; init; } = "";
    public decimal StockThen { get; init; }
    public DecisionChoice Choice { get; init; }

    /// <summary>What the owner does instead, or why not; may be empty for an accepted one.</summary>
    public string Note { get; init; } = "";

    public DateTime Decided { get; init; }

    /// <summary>When its outcome is judged, and its alert may come back.</summary>
    public DateOnly ReviewOn { get; init; }

    /// <summary>What happened, once <see cref="ReviewOn"/> came; null before.</summary>
    public string? Outcome { get; init; }

    public DateOnly? OutcomeOn { get; init; }

    /// <summary>Whether it went as the rule hoped (<see cref="DecisionOutcome.WentWell"/>); null until judged, and for a
    /// product no longer in the POS.</summary>
    public bool? WentWell { get; init; }
}

/// <summary>
/// What happened after a decision, on its review day, and whether it went as the rule hoped: a regular seller in stock
/// on the day (it may have run out in between; the POS keeps no stock history), or stock that sold again.
/// </summary>
public sealed record DecisionOutcome(string Text, bool? WentWell);

/// <summary>
/// The decisions judged so far, split by whether the owner followed the rule: the plan's comparison of the rules'
/// recommendations with the owner's own choices.
/// </summary>
public sealed record DecisionTally(int FollowedJudged, int FollowedWell, int OtherJudged, int OtherWell)
{
    public int Judged => FollowedJudged + OtherJudged;
}

/// <summary>Decisions on alerts and their outcomes. Pure and tested.</summary>
public static class AlertDecisions
{
    /// <summary>A reorder shows within two weeks.</summary>
    public const int StockOutReviewDays = 14;

    /// <summary>Clearing stock takes longer.</summary>
    public const int DeadStockReviewDays = 28;

    /// <summary>The decision on an alert, due for its outcome after the kind's review days.</summary>
    public static AlertDecision Decide(ShopAlert alert, DecisionChoice choice, string? note, DateTime now, string id)
    {
        ArgumentNullException.ThrowIfNull(alert);
        var text = (note ?? "").Trim();
        return new AlertDecision
        {
            Id = id,
            Kind = alert.Kind,
            ProductId = alert.ProductId,
            Name = alert.Name,
            Figures = alert.Figures,
            Recommendation = alert.Recommendation,
            StockThen = alert.StockInHand,
            Choice = choice,
            Note = text.Length > AlertDecision.MaxNote ? text[..AlertDecision.MaxNote].TrimEnd() : text,
            Decided = now,
            ReviewOn = DateOnly.FromDateTime(now).AddDays(alert.Kind == AlertKind.StockOut ? StockOutReviewDays : DeadStockReviewDays),
        };
    }

    /// <summary>Why a decision cannot be kept, or null: something else, or not now, needs a few words.</summary>
    public static string? Problem(DecisionChoice choice, string? note) =>
        choice == DecisionChoice.Changed && string.IsNullOrWhiteSpace(note) ? "Say what you will do instead."
        : (note ?? "").Trim().Length > AlertDecision.MaxNote ? $"Keep the note under {AlertDecision.MaxNote} characters."
        : null;

    /// <summary>The alerts still to decide: those without a decision that waits for its review day.</summary>
    public static IReadOnlyList<ShopAlert> Open(IReadOnlyList<ShopAlert> alerts, IReadOnlyList<AlertDecision> decisions, DateOnly today)
    {
        ArgumentNullException.ThrowIfNull(alerts);
        ArgumentNullException.ThrowIfNull(decisions);
        return alerts.Where(alert => !decisions.Any(d => d.Kind == alert.Kind && d.ProductId == alert.ProductId && today < d.ReviewOn)).ToList();
    }

    /// <summary>
    /// What happened after a decision, judged on its review day. Its sales count from the decision to the review day,
    /// from the bills, so they are exact whenever it is judged. Stock is known only as it is now (the POS keeps no stock
    /// history), so a product that was running out is judged on its review day itself: judged later, whether it ran out
    /// is not known, and it is left out of the tally. Null before the review day; for a product no longer in the POS the
    /// outcome says so, unjudged.
    /// </summary>
    /// <param name="soldToReviewDay">Units sold from the day of the decision to its review day.</param>
    public static DecisionOutcome? Outcome(AlertDecision decision, ProductFacts? now, decimal soldToReviewDay, DateOnly today)
    {
        ArgumentNullException.ThrowIfNull(decision);
        if (today < decision.ReviewOn)
        {
            return null;
        }

        if (now is null)
        {
            return new DecisionOutcome("It is no longer in the POS.", null);
        }

        var onTheDay = today == decision.ReviewOn;
        var stock = Math.Max(0m, now.StockInHand);
        var sold = soldToReviewDay > 0 ? ShopAlerts.Qty(soldToReviewDay) : "none";
        if (decision.Kind == AlertKind.StockOut)
        {
            return !onTheDay
                ? new DecisionOutcome($"Checked late, on {Day(today)}: {ShopAlerts.Qty(stock)} in stock then, {sold} sold by the review day. Whether it ran out by {Day(decision.ReviewOn)} is not known, so it is not counted.", null)
                : stock > 0
                    ? new DecisionOutcome($"In stock on the review day: {ShopAlerts.Qty(stock)} left, {sold} sold since.", true)
                    : new DecisionOutcome($"Out of stock on the review day; {sold} sold since.", false);
        }

        var left = onTheDay ? $", {ShopAlerts.Qty(stock)} left" : "";
        return soldToReviewDay > 0
            ? new DecisionOutcome($"It sold again: {sold} by the review day{left}.", true)
            : new DecisionOutcome($"Still not sold by the review day{left}.", false);
    }

    private static string Day(DateOnly day) => day.ToString("d MMM", CultureInfo.GetCultureInfo("en-IN"));

    /// <summary>How the judged decisions went, when the owner followed the rule and when not.</summary>
    public static DecisionTally Tally(IEnumerable<AlertDecision> decisions)
    {
        ArgumentNullException.ThrowIfNull(decisions);
        var judged = decisions.Where(d => d.WentWell is not null).ToList();
        var followed = judged.Where(d => d.Choice == DecisionChoice.Accepted).ToList();
        var other = judged.Where(d => d.Choice != DecisionChoice.Accepted).ToList();
        return new DecisionTally(followed.Count, followed.Count(d => d.WentWell == true), other.Count, other.Count(d => d.WentWell == true));
    }
}

/// <summary>The week a Monday review looks at. Pure and tested.</summary>
public static class ReviewWeeks
{
    /// <summary>The last full week before <paramref name="today"/>, Monday to Sunday.</summary>
    public static DateRange LastWeek(DateOnly today)
    {
        var monday = today.AddDays(-(((int)today.DayOfWeek + 6) % 7));
        return new DateRange(monday.AddDays(-7), monday.AddDays(-1));
    }

    /// <summary>The same weekdays a year before (52 weeks back), so Monday is compared with a Monday.</summary>
    public static DateRange YearBefore(DateRange week) => new(week.From.AddDays(-364), week.To.AddDays(-364));

    /// <summary>E.g. "21–27 Sep" or "29 Sep – 5 Oct".</summary>
    public static string Name(DateRange week) =>
        week.From.Month == week.To.Month
            ? $"{week.From.Day}–{week.To.ToString("d MMM", CultureInfo.InvariantCulture)}"
            : $"{week.From.ToString("d MMM", CultureInfo.InvariantCulture)} – {week.To.ToString("d MMM", CultureInfo.InvariantCulture)}";
}

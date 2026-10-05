using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Review;

namespace SmartRetail.Pos.Core.Owner;

/// <summary>
/// What this PC sends for the owner's weekly screen, the Monday review: last week against the week before and the
/// same week a year before, and the products the rules say are running out or not selling, with their figures. Figures
/// and product names only, as in <see cref="OwnerLive"/>: never a customer's name or phone number, nor a bill; a long
/// number typed into a product's name is masked. The owner's decisions and their notes stay at the shop. The rules only
/// suggest; nothing here changes anything.
/// </summary>
public sealed record OwnerReview
{
    /// <summary>The kind this report is kept under in the owner's Supabase project (<c>shop_reports</c>).</summary>
    public const string Kind = "review";

    /// <summary>Raised when the shape changes, so the page can tell an old shop PC from a new one.</summary>
    public const int CurrentVersion = 1;

    /// <summary>The review is sent again this long after it was sent: last week's figures hardly change, the stock does.</summary>
    public static readonly TimeSpan SendEvery = TimeSpan.FromHours(1);

    /// <summary>After a failed try, this long.</summary>
    public static readonly TimeSpan RetryAfter = TimeSpan.FromMinutes(10);

    public int Version { get; init; } = CurrentVersion;

    /// <summary>The demo shop's figures, not a real shop's.</summary>
    public bool Demo { get; init; }

    public DateTimeOffset SentAt { get; init; }

    /// <summary>The last full week, Monday to Sunday.</summary>
    public OwnerWeek ThisWeek { get; init; } = new();

    public OwnerWeek WeekBefore { get; init; } = new();

    /// <summary>The same weekdays a year before; null when the POS has no bills then.</summary>
    public OwnerWeek? YearBefore { get; init; }

    /// <summary>Regular sellers with under a week of stock, the most urgent first.</summary>
    public IReadOnlyList<OwnerRunningOut> RunningOut { get; init; } = Array.Empty<OwnerRunningOut>();

    /// <summary>Stock in hand that has not sold for 8 weeks, the most money tied up first.</summary>
    public IReadOnlyList<OwnerNotSelling> NotSelling { get; init; } = Array.Empty<OwnerNotSelling>();

    /// <summary>The day the owner marked the week as reviewed at the shop; null while it is not.</summary>
    public DateOnly? ReviewedOn { get; init; }

    public static OwnerReview From(OwnerReviewInputs inputs)
    {
        ArgumentNullException.ThrowIfNull(inputs);
        var week = inputs.Week;
        return new OwnerReview
        {
            Demo = inputs.Demo,
            SentAt = inputs.Now,
            ThisWeek = OwnerWeek.Of(week, inputs.ThisWeek),
            WeekBefore = OwnerWeek.Of(week.Previous, inputs.WeekBefore),
            YearBefore = inputs.YearBefore is { } year ? OwnerWeek.Of(ReviewWeeks.YearBefore(week), year) : null,
            RunningOut = inputs.Alerts
                .Where(a => a.Kind == AlertKind.StockOut)
                .Take(ShopAlerts.MaxEach)
                .Select(a => new OwnerRunningOut(PersonalData.MaskNumbers(a.Name), Math.Max(0m, a.StockInHand), Round(a.QtyPerDay), Round(a.DaysLeft)))
                .ToList(),
            NotSelling = inputs.Alerts
                .Where(a => a.Kind == AlertKind.DeadStock)
                .Take(ShopAlerts.MaxEach)
                .Select(a => new OwnerNotSelling(PersonalData.MaskNumbers(a.Name), Math.Max(0m, a.StockInHand), Round(a.StockValue)))
                .ToList(),
            ReviewedOn = inputs.ReviewedOn,
        };
    }

    /// <summary>When the review is due next: after a send in <see cref="SendEvery"/>, after a failed try in <see cref="RetryAfter"/>.</summary>
    public static DateTimeOffset NextDue(DateTimeOffset now, bool sent) => now + (sent ? SendEvery : RetryAfter);

    internal static decimal Round(decimal value) => Math.Round(value, 2, MidpointRounding.AwayFromZero);

    internal static decimal? Round(decimal? value) => value is { } v ? Round(v) : null;
}

/// <summary>What the review is built from.</summary>
public sealed record OwnerReviewInputs
{
    public bool Demo { get; init; }
    public DateTimeOffset Now { get; init; }

    /// <summary>The week looked at; the week before and the year before are worked out from it.</summary>
    public DateRange Week { get; init; }

    public SalesTotals ThisWeek { get; init; } = new();
    public SalesTotals WeekBefore { get; init; } = new();
    public SalesTotals? YearBefore { get; init; }

    /// <summary>The alerts the owner has not decided yet.</summary>
    public IReadOnlyList<ShopAlert> Alerts { get; init; } = Array.Empty<ShopAlert>();

    public DateOnly? ReviewedOn { get; init; }
}

/// <summary>One week's figures: sales with GST, bills and the average bill; profit before GST and its margin, only
/// when purchase prices are recorded.</summary>
public sealed record OwnerWeek
{
    public DateOnly From { get; init; }
    public DateOnly To { get; init; }
    public decimal Sales { get; init; }
    public int Bills { get; init; }
    public decimal AverageBill { get; init; }

    /// <summary>Null when no purchase price is known for what sold.</summary>
    public decimal? Profit { get; init; }

    /// <summary>Profit as a share of the sales it was worked out on (0.19 for 19%); null with <see cref="Profit"/>.</summary>
    public decimal? Margin { get; init; }

    internal static OwnerWeek Of(DateRange week, SalesTotals totals)
    {
        var margin = totals.ProfitMargin;
        return new OwnerWeek
        {
            From = week.From,
            To = week.To,
            Sales = OwnerReview.Round(totals.Sales),
            Bills = totals.Bills,
            AverageBill = OwnerReview.Round(totals.AverageBill),
            Profit = margin is null ? null : OwnerReview.Round(totals.Profit),
            Margin = margin is { } m ? Math.Round(m, 4) : null,
        };
    }
}

/// <param name="InHand">Never below none.</param>
/// <param name="PerDay">What it sold a day at the last 4 weeks' pace.</param>
/// <param name="DaysLeft">Days its stock lasts at that pace.</param>
public sealed record OwnerRunningOut(string Name, decimal InHand, decimal? PerDay, decimal? DaysLeft);

/// <param name="Value">Its stock at purchase price, or at selling price without one.</param>
public sealed record OwnerNotSelling(string Name, decimal InHand, decimal Value);

using System.Globalization;

namespace SmartRetail.Pos.Core.Prices;

public enum PriceVerdict
{
    /// <summary>Nothing to compare with yet.</summary>
    NoData,

    /// <summary>The shop's price is above the lowest confirmed online price.</summary>
    Dearer,

    About,

    Cheaper,
}

/// <summary>A confirmed page's price.</summary>
public sealed record OnlinePrice(string Shop, decimal Price, DateTime Seen);

/// <summary>The shop's price against the online ones, in words. It only informs: nothing here changes a price.</summary>
public sealed record PriceComparison(PriceVerdict Verdict, OnlinePrice? Lowest, decimal Difference, decimal? Percent, bool BelowFloor, string Text);

/// <summary>Compares the shop's own price with the prices of the pages the owner confirmed. Pure and tested.</summary>
public static class PriceCompare
{
    private static readonly CultureInfo India = CultureInfo.GetCultureInfo("en-IN");

    /// <summary>Within this share of the online price counts as about the same.</summary>
    public const decimal AboutTheSame = 0.02m;

    /// <summary>A price older than this many days is called old.</summary>
    public const int OldAfterDays = 7;

    /// <summary>The lowest price to sell at without losing money: the purchase price plus GST, in whole rupees, rounded up;
    /// null when the POS has no purchase price.</summary>
    public static decimal? Floor(decimal costPrice, decimal gstRatePercent) =>
        costPrice <= 0 ? null : Math.Ceiling(costPrice * (1m + Math.Max(gstRatePercent, 0m) / 100m));

    public static bool IsOld(DateTime seen, DateTime now) => (now - seen).TotalDays >= OldAfterDays;

    /// <param name="ownPrice">What the customer pays, with GST (as posters show it).</param>
    /// <param name="floor">See <see cref="Floor"/>.</param>
    /// <param name="confirmed">The prices of the pages the owner confirmed.</param>
    public static PriceComparison Compare(decimal ownPrice, decimal? floor, IReadOnlyList<OnlinePrice> confirmed, DateTime now)
    {
        ArgumentNullException.ThrowIfNull(confirmed);
        if (ownPrice <= 0)
        {
            return new PriceComparison(PriceVerdict.NoData, null, 0m, null, false, "This product has no selling price in the POS, so there is nothing to compare.");
        }

        var lowest = confirmed.OrderBy(p => p.Price).ThenByDescending(p => p.Seen).FirstOrDefault();
        if (lowest is null)
        {
            return new PriceComparison(PriceVerdict.NoData, null, 0m, null, false,
                "Say which of the pages show exactly this product, in this pack, and your price is compared with theirs.");
        }

        var difference = Money.Round(ownPrice - lowest.Price);
        var percent = lowest.Price > 0 ? difference / lowest.Price : (decimal?)null;
        var verdict = percent is not { } share || Math.Abs(share) <= AboutTheSame ? PriceVerdict.About
            : share > 0 ? PriceVerdict.Dearer : PriceVerdict.Cheaper;
        var belowFloor = floor is { } lowestSafe && lowest.Price < lowestSafe;

        var where = $"{Money.FormatCompact(lowest.Price)} at {lowest.Shop}, seen {lowest.Seen.ToString("d MMM", India)}";
        var text = verdict switch
        {
            PriceVerdict.Dearer => $"Your price {Money.FormatCompact(ownPrice)} is {Money.FormatCompact(difference)} ({Percent(percent)}) above the lowest confirmed online price: {where}."
                + (floor is { } f
                    ? belowFloor
                        ? $" Matching it would go below your purchase price plus GST ({Money.FormatCompact(f)})."
                        : $" Matching it would still keep you above your purchase price plus GST ({Money.FormatCompact(f)})."
                    : " The POS has no purchase price for it, so whether matching it is safe cannot be checked."),
            PriceVerdict.Cheaper => $"Your price {Money.FormatCompact(ownPrice)} is {Money.FormatCompact(-difference)} ({Percent(-percent)}) below the lowest confirmed online price: {where}.",
            _ => $"Your price {Money.FormatCompact(ownPrice)} is about the same as the lowest confirmed online price: {where}.",
        };
        if (IsOld(lowest.Seen, now))
        {
            text += " That price is more than a week old: check again.";
        }

        return new PriceComparison(verdict, lowest, difference, percent, belowFloor, text);
    }

    private static string Percent(decimal? share) => share is not { } value ? "–"
        : Math.Round(value * 100m, 0, MidpointRounding.AwayFromZero).ToString("0", CultureInfo.InvariantCulture) + "%";
}

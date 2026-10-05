namespace SmartRetail.Pos.Core.Posters;

/// <summary>
/// Prices on posters. Pure, so every rule is tested:
/// <list type="bullet">
/// <item>Prices are what the customer pays, GST included.</item>
/// <item>An offer never goes below the purchase price plus GST, and never takes off more than the shop's limit.</item>
/// <item>Offer prices are whole rupees, rounded up, so rounding can never break either rule.</item>
/// <item>A product without a purchase price in the POS gets no offer: "never below cost" could not be checked.</item>
/// </list>
/// </summary>
public static class PosterPricing
{
    /// <summary>The biggest offer unless the owner sets another limit.</summary>
    public const decimal DefaultMaxOfferPercent = 30m;

    /// <summary>The steps offered to staff, in percent.</summary>
    public static IReadOnlyList<decimal> OfferSteps { get; } = new[] { 5m, 10m, 15m, 20m, 25m, 30m, 35m, 40m, 45m, 50m };

    /// <summary>What the customer pays: the selling price, with GST added when the shop's prices exclude it.</summary>
    public static decimal CustomerPrice(decimal sellingPrice, decimal gstRatePercent, bool pricesIncludeTax)
    {
        if (sellingPrice <= 0)
        {
            return 0m;
        }

        return pricesIncludeTax ? Money.Round(sellingPrice) : Money.Round(sellingPrice * (1m + Gst(gstRatePercent) / 100m));
    }

    /// <summary>
    /// The lowest offer price allowed, in whole rupees: the purchase price plus GST, and no more than
    /// <paramref name="maxOfferPercent"/> off. Equals <paramref name="price"/> when no offer is allowed.
    /// </summary>
    /// <param name="price">What the customer pays today (<see cref="CustomerPrice"/>).</param>
    /// <param name="costPrice">The purchase price before GST, as the POS keeps it; 0 when unknown.</param>
    public static decimal LowestOffer(decimal price, decimal costPrice, decimal gstRatePercent, decimal maxOfferPercent)
    {
        if (price <= 0 || costPrice <= 0 || maxOfferPercent <= 0)
        {
            return price;
        }

        var costWithGst = costPrice * (1m + Gst(gstRatePercent) / 100m);
        var limit = price * (1m - Math.Min(maxOfferPercent, 90m) / 100m);
        var lowest = Math.Ceiling(Math.Max(costWithGst, limit));
        return lowest >= price ? price : lowest;
    }

    /// <summary>The offer price for <paramref name="percent"/> off, kept at or above <paramref name="lowestOffer"/>;
    /// null when there is no offer (none allowed, or too small to change the price).</summary>
    public static decimal? OfferPrice(decimal price, decimal lowestOffer, decimal percent)
    {
        if (price <= 0 || percent <= 0 || lowestOffer >= price)
        {
            return null;
        }

        var offer = Math.Max(Math.Ceiling(price * (1m - Math.Min(percent, 100m) / 100m)), lowestOffer);
        return offer < price ? offer : null;
    }

    /// <summary>Checks an offer price someone chose: null when it is not a real offer or breaks a rule.</summary>
    public static decimal? CheckedOffer(decimal price, decimal lowestOffer, decimal? offer) =>
        offer is { } value && value >= lowestOffer && value < price && value == Math.Floor(value) ? value : null;

    /// <summary>The offers staff can choose from, smallest first: the steps up to the limit, the lowest allowed, and
    /// <paramref name="current"/> (e.g. the AI's) when it keeps to the rules.</summary>
    public static IReadOnlyList<decimal> OfferChoices(decimal price, decimal lowestOffer, decimal? current = null)
    {
        if (lowestOffer >= price)
        {
            return Array.Empty<decimal>();
        }

        var choices = OfferSteps
            .Select(step => OfferPrice(price, lowestOffer, step))
            .Append(CheckedOffer(price, lowestOffer, current))
            .OfType<decimal>()
            .Append(lowestOffer)
            .Distinct()
            .OrderByDescending(offer => offer)
            .ToList();
        return choices;
    }

    /// <summary>Whole percent off, rounded down, so a poster never claims more than it gives.</summary>
    public static decimal PercentOff(decimal price, decimal offer) =>
        price <= 0 || offer >= price ? 0m : Math.Floor((price - offer) / price * 100m);

    private static decimal Gst(decimal rate) => Math.Clamp(rate, 0m, 100m);
}

namespace SmartRetail.Pos.Core.Posters;

public enum PosterChangeKind
{
    /// <summary>The POS price is not the one on the poster.</summary>
    Price,

    /// <summary>The offer is now below the lowest allowed: the purchase price, GST or the owner's limit changed.</summary>
    OfferRules,

    /// <summary>The product is no longer in the POS.</summary>
    Gone,
}

/// <summary>Something on a saved poster that is no longer true.</summary>
public sealed record PosterChange(int ProductId, string Name, PosterChangeKind Kind, decimal OnPoster, decimal? PriceNow, decimal? LowestNow);

/// <summary>
/// Checks a saved poster against the POS as it is now, because prices, purchase prices, GST and the owner's offer
/// limit can all change after a poster is made. Pure and tested.
/// </summary>
public static class PosterRecheck
{
    /// <summary>
    /// Checks one product. When its price is unchanged and its offer is still allowed, the product comes back with
    /// today's lowest allowed offer (so the offers staff can choose follow the rules) and no change; otherwise the
    /// product is kept as it is, with what changed.
    /// </summary>
    /// <param name="priceNow">The price the customer pays today, or null when the product is no longer in the POS.</param>
    /// <param name="lowestNow">Today's lowest allowed offer (<see cref="PosterPricing.LowestOffer"/>).</param>
    public static (PosterItem Item, PosterChange? Change) Check(PosterItem item, decimal? priceNow, decimal lowestNow)
    {
        ArgumentNullException.ThrowIfNull(item);
        if (priceNow is not { } price)
        {
            return (item, new PosterChange(item.ProductId, item.Name, PosterChangeKind.Gone, item.Price, null, null));
        }

        if (price != item.Price)
        {
            return (item, new PosterChange(item.ProductId, item.Name, PosterChangeKind.Price, item.Price, price, lowestNow));
        }

        if (item.HasOffer && item.OfferPrice < lowestNow)
        {
            return (item, new PosterChange(item.ProductId, item.Name, PosterChangeKind.OfferRules, item.OfferPrice!.Value, price, lowestNow));
        }

        return (item with { LowestOffer = lowestNow }, null);
    }

    /// <summary>The product at today's price and rules, keeping its offer's percentage where the rules still allow it.</summary>
    public static PosterItem Refresh(PosterItem item, decimal priceNow, decimal lowestNow)
    {
        ArgumentNullException.ThrowIfNull(item);
        return item with
        {
            Price = priceNow,
            LowestOffer = lowestNow,
            OfferPrice = item.PercentOff is { } percent ? PosterPricing.OfferPrice(priceNow, lowestNow, percent) : null,
        };
    }
}

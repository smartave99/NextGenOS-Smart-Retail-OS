using System.Globalization;
using System.Text.Json.Serialization;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Core.Posters;

/// <summary>The shop's rules for posters.</summary>
public sealed record PosterRules
{
    public static PosterRules Default { get; } = new();

    /// <summary>The most an offer may take off, in percent. Offers never go below cost whatever this is.</summary>
    public decimal MaxOfferPercent { get; init; } = PosterPricing.DefaultMaxOfferPercent;

    /// <summary>A product that has not sold for this many days is ready for a clearance poster.</summary>
    public int SlowAfterDays { get; init; } = 30;

    /// <summary>New arrivals: products added to the POS within this many days.</summary>
    public int NewWithinDays { get; init; } = 30;

    /// <summary>Best sellers and festival offers go by this many days of sales.</summary>
    public int SalesDays { get; init; } = 30;

    /// <summary>How far back a product's last sale is looked for.</summary>
    public int LookBackDays { get; init; } = 120;

    /// <summary>The most products offered to choose from.</summary>
    public int MaxCandidates { get; init; } = 24;

    /// <summary>The days of sales <see cref="PosterPicker.Candidates"/> needs, ending today.</summary>
    public DateRange SalesRange(DateOnly today) => DateRange.Ending(today, Math.Max(LookBackDays, SalesDays));
}

/// <summary>What the poster rules know about one product.</summary>
public sealed record PosterInputs(
    DateOnly Today,
    IReadOnlyList<ProductFacts> Products,
    IReadOnlyList<ProductDaySales> Sales,
    IReadOnlyDictionary<int, string> Photos,
    bool PricesIncludeTax = true);

/// <summary>A product that could go on a poster, with what it can be offered at.</summary>
public sealed record PosterCandidate
{
    public int ProductId { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public string Category { get; init; } = "";

    /// <summary>What the customer pays today, GST included.</summary>
    public decimal Price { get; init; }

    /// <summary>The lowest offer price allowed; equal to <see cref="Price"/> when no offer is allowed.</summary>
    public decimal LowestOffer { get; init; }

    public decimal StockInHand { get; init; }

    /// <summary>Stock at purchase price, or at selling price when no purchase price is set.</summary>
    public decimal StockValue { get; init; }

    public DateOnly? AddedOn { get; init; }

    /// <summary>The last day it sold, within <see cref="PosterRules.LookBackDays"/>; null when it did not.</summary>
    public DateOnly? LastSold { get; init; }

    /// <summary>Units and money sold over <see cref="PosterRules.SalesDays"/>.</summary>
    public decimal QtySold { get; init; }
    public decimal Sales { get; init; }

    /// <summary>The product's white-background photo, or null.</summary>
    public string? Photo { get; init; }

    [JsonIgnore]
    public bool HasPhoto => Photo is not null;

    [JsonIgnore]
    public bool CanHaveOffer => LowestOffer < Price;

    /// <summary>The biggest offer allowed, in whole percent.</summary>
    [JsonIgnore]
    public decimal MaxOfferPercent => CanHaveOffer ? PosterPricing.PercentOff(Price, LowestOffer) : 0m;

    /// <summary>Why it was picked, for staff, e.g. "Last sold 41 days ago · 35 in stock".</summary>
    public string Why(PosterKind kind, DateOnly today, PosterRules rules)
    {
        var stock = Qty(StockInHand) + " in stock";
        switch (kind)
        {
            case PosterKind.Clearance:
                return (LastSold is { } last
                    ? "Last sold " + DaysAgo(today.DayNumber - last.DayNumber)
                    : "No sale in over " + rules.LookBackDays.ToString(CultureInfo.InvariantCulture) + " days") + " · " + stock;
            case PosterKind.NewArrivals:
                return "Added " + (AddedOn is { } added ? DaysAgo(today.DayNumber - added.DayNumber) : "recently") + " · " + stock;
            default:
                return Qty(QtySold) + " sold in " + rules.SalesDays.ToString(CultureInfo.InvariantCulture) + " days · " + stock;
        }
    }

    /// <summary>The item for the poster, with <paramref name="percent"/> off where allowed.</summary>
    public PosterItem ToItem(decimal percent) => new()
    {
        ProductId = ProductId,
        Code = Code,
        Name = Name,
        Price = Price,
        OfferPrice = PosterPricing.OfferPrice(Price, LowestOffer, percent),
        LowestOffer = LowestOffer,
        Photo = Photo,
    };

    private static string DaysAgo(int days) => days switch
    {
        <= 0 => "today",
        1 => "yesterday",
        _ => days.ToString(CultureInfo.InvariantCulture) + " days ago",
    };

    private static string Qty(decimal qty) => qty.ToString("0.###", CultureInfo.InvariantCulture);
}

/// <summary>
/// Chooses the products for each kind of poster from the POS's figures. Products with a photo always come first,
/// so posters show real products; products without stock or a price never appear. Pure and tested.
/// </summary>
public static class PosterPicker
{
    public static IReadOnlyList<PosterCandidate> Candidates(PosterKind kind, PosterInputs inputs, PosterRules? rules = null)
    {
        ArgumentNullException.ThrowIfNull(inputs);
        rules ??= PosterRules.Default;
        var today = inputs.Today;
        var lookBack = DateRange.Ending(today, rules.LookBackDays);
        var recent = DateRange.Ending(today, rules.SalesDays);

        var lastSold = new Dictionary<int, DateOnly>();
        var sold = new Dictionary<int, (decimal Qty, decimal Sales)>();
        foreach (var day in inputs.Sales)
        {
            if (day.Qty <= 0 || !lookBack.Contains(day.Day))
            {
                continue;
            }

            if (!lastSold.TryGetValue(day.ProductId, out var last) || day.Day > last)
            {
                lastSold[day.ProductId] = day.Day;
            }

            if (recent.Contains(day.Day))
            {
                sold.TryGetValue(day.ProductId, out var total);
                sold[day.ProductId] = (total.Qty + day.Qty, total.Sales + day.Sales);
            }
        }

        var candidates = new List<PosterCandidate>();
        foreach (var product in inputs.Products)
        {
            var price = PosterPricing.CustomerPrice(product.SellingPrice, product.GstRatePercent, inputs.PricesIncludeTax);
            if (!product.Active || price <= 0 || product.StockInHand <= 0 || string.IsNullOrWhiteSpace(product.Name))
            {
                continue;
            }

            sold.TryGetValue(product.Id, out var recentSales);
            candidates.Add(new PosterCandidate
            {
                ProductId = product.Id,
                Code = product.Code,
                Name = product.Name.Trim(),
                Category = product.Category,
                Price = price,
                LowestOffer = PosterPricing.LowestOffer(price, product.CostPrice, product.GstRatePercent, rules.MaxOfferPercent),
                StockInHand = product.StockInHand,
                StockValue = product.StockInHand * (product.CostPrice > 0 ? product.CostPrice : product.SellingPrice),
                AddedOn = product.AddedOn,
                LastSold = lastSold.TryGetValue(product.Id, out var last) ? last : null,
                QtySold = recentSales.Qty,
                Sales = recentSales.Sales,
                Photo = inputs.Photos.TryGetValue(product.Id, out var photo) && !string.IsNullOrWhiteSpace(photo) ? photo : null,
            });
        }

        IOrderedEnumerable<PosterCandidate> chosen = kind switch
        {
            PosterKind.Clearance => candidates
                .Where(c => IsSlow(c, today, rules) && !IsNew(c, today, rules.SlowAfterDays))
                .OrderByDescending(c => c.HasPhoto)
                .ThenByDescending(c => c.CanHaveOffer)
                .ThenByDescending(c => c.StockValue),
            PosterKind.NewArrivals => candidates
                .Where(c => IsNew(c, today, rules.NewWithinDays))
                .OrderByDescending(c => c.HasPhoto)
                .ThenByDescending(c => c.AddedOn),
            PosterKind.BestSellers => candidates
                .Where(c => c.QtySold > 0)
                .OrderByDescending(c => c.HasPhoto)
                .ThenByDescending(c => c.Sales)
                .ThenByDescending(c => c.QtySold),
            PosterKind.FestivalOffer => candidates
                .Where(c => c.QtySold > 0)
                .OrderByDescending(c => c.HasPhoto)
                .ThenByDescending(c => c.CanHaveOffer)
                .ThenByDescending(c => c.Sales),
            _ => throw new ArgumentOutOfRangeException(nameof(kind)),
        };

        return chosen.ThenBy(c => c.Name, StringComparer.OrdinalIgnoreCase).Take(Math.Max(1, rules.MaxCandidates)).ToList();
    }

    /// <summary>The poster's products when no AI picks them: the first <paramref name="count"/>, with the kind's usual offer.</summary>
    public static IReadOnlyList<PosterItem> DefaultPicks(PosterKind kind, IReadOnlyList<PosterCandidate> candidates, int count) =>
        candidates.Take(Math.Max(0, count)).Select(c => c.ToItem(kind.DefaultOfferPercent())).ToList();

    private static bool IsSlow(PosterCandidate candidate, DateOnly today, PosterRules rules) =>
        candidate.LastSold is not { } last || today.DayNumber - last.DayNumber >= rules.SlowAfterDays;

    private static bool IsNew(PosterCandidate candidate, DateOnly today, int withinDays) =>
        candidate.AddedOn is { } added && added <= today && today.DayNumber - added.DayNumber < withinDays;
}

using System.Globalization;
using System.Text.RegularExpressions;
using SmartRetail.Pos.Core.Posters;

namespace SmartRetail.Pos.Core.Creatives;

/// <summary>
/// What one price tag says. Every figure is the POS's, worked out as posters do (<see cref="PosterPricing"/>): the price
/// the customer pays, GST included, and an offer only while it keeps the rules. The AI never gives a figure.
/// </summary>
public sealed record PriceTag(int ProductId, string Name, decimal Price, decimal? Offer, decimal PercentOff)
{
    /// <summary>The big figure: the offer when there is one, else the price.</summary>
    public decimal Pays => Offer ?? Price;
}

/// <summary>A product as the POS has it now, for its price tag.</summary>
public sealed record TagFacts(int ProductId, string Name, decimal SellingPrice, decimal CostPrice, decimal GstRatePercent);

/// <summary>Price tags on creatives. Pure, so every rule is tested.</summary>
public static class CreativePricing
{
    /// <summary>
    /// The tag for a product as the POS has it now, with the owner's offer when it keeps the rules today (never below
    /// the purchase price plus GST, never more off than the limit, whole rupees). Otherwise the tag shows the plain
    /// price, and says what is wrong so the creative is not exported until the owner chooses again. No tag for a
    /// product without a price.
    /// </summary>
    public static (PriceTag? Tag, string? Problem) Tag(TagFacts product, decimal? offer, bool pricesIncludeTax, decimal maxOfferPercent)
    {
        ArgumentNullException.ThrowIfNull(product);
        var price = PosterPricing.CustomerPrice(product.SellingPrice, product.GstRatePercent, pricesIncludeTax);
        if (price <= 0)
        {
            return (null, $"{product.Name} has no price in the POS, so it gets no price tag.");
        }

        var plain = new PriceTag(product.ProductId, product.Name, price, null, 0m);
        if (offer is not { } chosen)
        {
            return (plain, null);
        }

        var lowest = PosterPricing.LowestOffer(price, product.CostPrice, product.GstRatePercent, maxOfferPercent);
        if (PosterPricing.CheckedOffer(price, lowest, chosen) is not { } allowed)
        {
            var why = lowest >= price
                ? "no offer is allowed on it now (its purchase price is missing, or too close to its price)"
                : $"the lowest allowed now is {Money.FormatCompact(lowest)}";
            return (plain, $"The offer of {Money.FormatCompact(chosen)} on {product.Name} no longer keeps the rules: {why}. Choose its offer again.");
        }

        return (plain with { Offer = allowed, PercentOff = PosterPricing.PercentOff(price, allowed) }, null);
    }

    /// <summary>The offers the owner can choose for a product, biggest price first; none when no offer is allowed.</summary>
    public static IReadOnlyList<decimal> OfferChoices(TagFacts product, bool pricesIncludeTax, decimal maxOfferPercent)
    {
        ArgumentNullException.ThrowIfNull(product);
        var price = PosterPricing.CustomerPrice(product.SellingPrice, product.GstRatePercent, pricesIncludeTax);
        return price <= 0
            ? Array.Empty<decimal>()
            : PosterPricing.OfferChoices(price, PosterPricing.LowestOffer(price, product.CostPrice, product.GstRatePercent, maxOfferPercent));
    }
}

/// <summary>
/// Where price tags sit on a creative. A tag is <see cref="Width"/> of the picture's width wide and half as high as it
/// is wide; its place is its top-left corner, as shares of the picture's width and height. Pure and tested.
/// </summary>
public static partial class TagLayout
{
    /// <summary>A tag's width, as a share of the picture's width.</summary>
    public const double Width = 0.26;

    /// <summary>A tag's height as a share of its own width.</summary>
    public const double HeightOfWidth = 0.5;

    private const double Margin = 0.04;

    private const double Gap = 0.03;

    /// <summary>A tag's height, as a share of the picture's height.</summary>
    public static double Height(CreativeFormat format)
    {
        ArgumentNullException.ThrowIfNull(format);
        return Width * HeightOfWidth * format.Width / format.Height;
    }

    /// <summary>The place kept inside the picture.</summary>
    public static TagPlace Clamp(TagPlace place, CreativeFormat format)
    {
        ArgumentNullException.ThrowIfNull(place);
        var x = double.IsFinite(place.X) ? place.X : 0;
        var y = double.IsFinite(place.Y) ? place.Y : 0;
        return new TagPlace(Round(Math.Clamp(x, 0, 1 - Width)), Round(Math.Clamp(y, 0, Math.Max(0, 1 - Height(format)))));
    }

    /// <summary>
    /// Where <paramref name="count"/> tags go at first: each centred in the empty place the AI left for it (shares of the
    /// picture: left, top, width, height), else in a row along the bottom from the right.
    /// </summary>
    public static IReadOnlyList<TagPlace> Place(int count, IReadOnlyList<(double X, double Y, double Width, double Height)> areas, CreativeFormat format)
    {
        ArgumentNullException.ThrowIfNull(areas);
        var height = Height(format);
        var perRow = Math.Max(1, (int)((1 - 2 * Margin + Gap) / (Width + Gap)));
        var places = new List<TagPlace>();
        for (var i = 0; i < count; i++)
        {
            var place = i < areas.Count
                ? new TagPlace(areas[i].X + areas[i].Width / 2 - Width / 2, areas[i].Y + areas[i].Height / 2 - height / 2)
                : new TagPlace(1 - Margin - Width - i % perRow * (Width + Gap), 1 - Margin * format.Width / format.Height - height - i / perRow * (height + Gap));
            places.Add(Clamp(place, format));
        }

        return places;
    }

    /// <summary>
    /// The tag's colours: the brand's first colour (a strong red without one), with white or near-black words,
    /// whichever stands out more (white while the colour's luminance is under 0.179, where both contrast equally).
    /// </summary>
    public static (string Background, string Words) Colours(string? brandColour)
    {
        var colour = brandColour is not null && HexColour().IsMatch(brandColour) ? brandColour.ToUpperInvariant() : "#D7263D";
        var red = Channel(colour, 1);
        var green = Channel(colour, 3);
        var blue = Channel(colour, 5);
        var luminance = 0.2126 * red + 0.7152 * green + 0.0722 * blue;
        return (colour, luminance < 0.179 ? "#FFFFFF" : "#1D1D1F");
    }

    /// <summary>A colour as #RRGGBB, or null when it is not one.</summary>
    public static string? CleanColour(string? colour) =>
        colour is not null && HexColour().IsMatch(colour.Trim()) ? colour.Trim().ToUpperInvariant() : null;

    private static double Channel(string colour, int at)
    {
        var value = int.Parse(colour.AsSpan(at, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture) / 255.0;
        return value <= 0.04045 ? value / 12.92 : Math.Pow((value + 0.055) / 1.055, 2.4);
    }

    private static double Round(double value) => Math.Round(value, 4);

    [GeneratedRegex("^#[0-9A-Fa-f]{6}$")]
    private static partial Regex HexColour();
}

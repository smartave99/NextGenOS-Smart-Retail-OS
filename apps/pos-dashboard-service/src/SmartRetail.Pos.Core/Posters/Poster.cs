using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

namespace SmartRetail.Pos.Core.Posters;

/// <summary>The poster's words: an English headline, a Hindi line and a short English line under them.</summary>
public sealed record PosterWords(string Headline, string HindiLine, string Subline)
{
    public const int MaxHeadlineLength = 28;
    public const int MaxHindiLineLength = 40;
    public const int MaxSublineLength = 60;
    public const int MaxFestivalLength = 24;

    public static PosterWords Empty { get; } = new("", "", "");

    /// <summary>The words staff typed, tidied and cut to length.</summary>
    public PosterWords Tidied() => new(
        Tidy(Headline, MaxHeadlineLength), Tidy(HindiLine, MaxHindiLineLength), Tidy(Subline, MaxSublineLength));

    /// <summary>
    /// An AI's words, checked: each line is tidied, and a line that is empty, in the wrong script, or has numbers,
    /// ₹ or % in it (prices and offers are printed by the app from the POS, never taken from an AI) is replaced by
    /// the matching line of <paramref name="fallback"/>.
    /// </summary>
    public static PosterWords FromAi(string? headline, string? hindiLine, string? subline, PosterWords fallback)
    {
        ArgumentNullException.ThrowIfNull(fallback);
        var head = Tidy(headline, MaxHeadlineLength);
        var hindi = Tidy(hindiLine, MaxHindiLineLength);
        var sub = Tidy(subline, MaxSublineLength);
        return new PosterWords(
            head.Length > 0 && !HasFigures(head) && !HasDevanagari(head) ? head : fallback.Headline,
            hindi.Length > 0 && !HasFigures(hindi) && HasDevanagari(hindi) ? hindi : fallback.HindiLine,
            sub.Length > 0 && !HasFigures(sub) && !HasDevanagari(sub) ? sub : fallback.Subline);
    }

    /// <summary>Trims, removes line breaks, control characters and wrapping quotes, and cuts at a word.</summary>
    public static string Tidy(string? text, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return "";
        }

        var builder = new StringBuilder(text.Length);
        foreach (var c in text.Trim())
        {
            if (char.IsWhiteSpace(c) || char.IsControl(c))
            {
                if (builder.Length > 0 && builder[^1] != ' ')
                {
                    builder.Append(' ');
                }
            }
            else
            {
                builder.Append(c);
            }
        }

        var tidy = builder.ToString().Trim().Trim('"', '\'', '“', '”', '‘', '’', '*', '`').Trim();
        if (tidy.Length <= maxLength)
        {
            return tidy;
        }

        var cut = tidy[..maxLength];
        var space = cut.LastIndexOf(' ');
        return (space > maxLength / 2 ? cut[..space] : cut).TrimEnd(' ', ',', '·', '-', '–', ':');
    }

    /// <summary>True when the text has digits (Latin or Devanagari), ₹, % or "Rs".</summary>
    public static bool HasFigures(string text) =>
        text.Any(c => char.IsDigit(c) || c is '₹' or '%' or '$')
        || text.Contains("Rs.", StringComparison.OrdinalIgnoreCase)
        || text.Split(' ').Any(word => word.Equals("Rs", StringComparison.OrdinalIgnoreCase));

    public static bool HasDevanagari(string text) => text.Any(c => c is >= 'ऀ' and <= 'ॿ');
}

/// <summary>One product on a poster, with the prices printed for it.</summary>
public sealed record PosterItem
{
    public int ProductId { get; init; }
    public string Code { get; init; } = "";

    /// <summary>The name as the POS has it, or as staff changed it for the poster.</summary>
    public string Name { get; init; } = "";

    /// <summary>What the customer pays today, GST included.</summary>
    public decimal Price { get; init; }

    /// <summary>The offer price, or null when the product is shown at today's price.</summary>
    public decimal? OfferPrice { get; init; }

    /// <summary>The lowest offer price allowed (<see cref="PosterPricing.LowestOffer"/>); equal to
    /// <see cref="Price"/> when the product can have no offer.</summary>
    public decimal LowestOffer { get; init; }

    /// <summary>The product's white-background photo (a file name the photo store made), or null.</summary>
    public string? Photo { get; init; }

    [JsonIgnore]
    public bool HasOffer => OfferPrice is { } offer && offer > 0 && offer < Price;

    /// <summary>The whole percent the offer takes off, rounded down so a poster never claims more than it gives.</summary>
    [JsonIgnore]
    public decimal? PercentOff => HasOffer ? PosterPricing.PercentOff(Price, OfferPrice!.Value) : null;

    /// <summary>The same product with another offer price, kept to the rules: an offer that breaks them is dropped.</summary>
    public PosterItem WithOffer(decimal? offer) => this with { OfferPrice = PosterPricing.CheckedOffer(Price, LowestOffer, offer) };
}

/// <summary>A poster as made and saved, to print again later.</summary>
public sealed record Poster
{
    public string Id { get; init; } = "";
    public PosterKind Kind { get; init; }

    /// <summary>When it was made (the shop's local time).</summary>
    public DateTime Made { get; init; }

    public string ShopName { get; init; } = "";

    /// <summary>The festival a festival offer is for, e.g. Diwali.</summary>
    public string? Festival { get; init; }

    public PosterWords Words { get; init; } = PosterWords.Empty;
    public DateOnly ValidFrom { get; init; }
    public DateOnly ValidTill { get; init; }

    public IReadOnlyList<PosterItem> Items { get; init; } = Array.Empty<PosterItem>();

    /// <summary>The artwork's file name in the poster's folder, or null for the app's own design.</summary>
    public string? Artwork { get; init; }

    /// <summary>The AI that made the artwork, e.g. "Codex CLI (OpenAI)".</summary>
    public string? ArtworkBy { get; init; }

    /// <summary>The AI that picked the products and wrote the words, or null when the app's own rules did.</summary>
    public string? PickedBy { get; init; }

    [JsonIgnore]
    public bool HasOffers => Items.Any(item => item.HasOffer);

    /// <summary>The biggest offer on the poster, for its "up to" badge; null without offers.</summary>
    [JsonIgnore]
    public decimal? UpToPercentOff => HasOffers ? Items.Where(item => item.HasOffer).Max(item => item.PercentOff) : null;

    /// <summary>The line at the foot of the poster, e.g. "Offers valid 26–30 September, while stock lasts".</summary>
    [JsonIgnore]
    public string ValidityText => (HasOffers ? "Offers valid " : "Prices valid ") + DateSpan(ValidFrom, ValidTill)
        + (HasOffers ? ", while stock lasts" : "");

    /// <summary>"26–30 September", "26 September – 3 October", or one day, "26 September".</summary>
    public static string DateSpan(DateOnly from, DateOnly till)
    {
        var culture = CultureInfo.InvariantCulture;
        if (till <= from)
        {
            return from.ToString("d MMMM", culture);
        }

        return from.Month == till.Month && from.Year == till.Year
            ? from.Day.ToString(culture) + "–" + till.ToString("d MMMM", culture)
            : from.ToString("d MMMM", culture) + " – " + till.ToString("d MMMM", culture);
    }
}

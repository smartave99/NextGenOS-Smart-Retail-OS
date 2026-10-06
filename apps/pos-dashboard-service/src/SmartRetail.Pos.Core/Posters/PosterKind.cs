namespace SmartRetail.Pos.Core.Posters;

/// <summary>The kinds of A4 poster the shop can print.</summary>
public enum PosterKind
{
    /// <summary>Products that have stopped selling, with an offer to clear them.</summary>
    Clearance,

    /// <summary>Products added to the POS recently.</summary>
    NewArrivals,

    /// <summary>The products customers buy most.</summary>
    BestSellers,

    /// <summary>Popular products with a festival offer.</summary>
    FestivalOffer,
}

public static class PosterKinds
{
    public static IReadOnlyList<PosterKind> All { get; } =
        new[] { PosterKind.Clearance, PosterKind.NewArrivals, PosterKind.BestSellers, PosterKind.FestivalOffer };

    /// <summary>How many products a poster can show; the A4 layouts are made for these.</summary>
    public static IReadOnlyList<int> ProductCounts { get; } = new[] { 1, 2, 4, 6 };

    public static string Title(this PosterKind kind) => kind switch
    {
        PosterKind.Clearance => "Clearance",
        PosterKind.NewArrivals => "New arrivals",
        PosterKind.BestSellers => "Best sellers",
        PosterKind.FestivalOffer => "Festival offer",
        _ => throw new ArgumentOutOfRangeException(nameof(kind)),
    };

    /// <summary>The kind's name in addresses and file names, e.g. "new-arrivals".</summary>
    public static string Slug(this PosterKind kind) => kind switch
    {
        PosterKind.Clearance => "clearance",
        PosterKind.NewArrivals => "new-arrivals",
        PosterKind.BestSellers => "best-sellers",
        PosterKind.FestivalOffer => "festival-offer",
        _ => throw new ArgumentOutOfRangeException(nameof(kind)),
    };

    public static bool TryParse(string? slug, out PosterKind kind)
    {
        foreach (var candidate in All)
        {
            if (string.Equals(candidate.Slug(), slug?.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                kind = candidate;
                return true;
            }
        }

        kind = PosterKind.Clearance;
        return false;
    }

    /// <summary>The offer used when no AI suggests one.</summary>
    public static decimal DefaultOfferPercent(this PosterKind kind) => kind switch
    {
        PosterKind.Clearance => 20m,
        PosterKind.FestivalOffer => 10m,
        _ => 0m,
    };

    /// <summary>
    /// The poster's words when no AI writes them: neutral English, and the second-language line the customer's profile gives for this kind
    /// (none without one).
    /// </summary>
    public static PosterWords DefaultWords(this PosterKind kind, string? festival = null, PosterLocale? locale = null)
    {
        locale ??= PosterLocale.Neutral;
        return kind switch
        {
            PosterKind.Clearance => new PosterWords("Clearance sale", locale.LocalLineFor(kind), "Grab them before they're gone"),
            PosterKind.NewArrivals => new PosterWords("New arrivals", locale.LocalLineFor(kind), "Just in at the shop"),
            PosterKind.BestSellers => new PosterWords("Best sellers", locale.LocalLineFor(kind), "Our customers' favourites"),
            PosterKind.FestivalOffer => new PosterWords(FestivalHeadline(festival), locale.LocalLineFor(kind), "Celebrate with special prices"),
            _ => throw new ArgumentOutOfRangeException(nameof(kind)),
        };
    }

    /// <summary>What the poster's artwork should look like, for the AI that makes it (no words or products: the app adds those). The place comes from the customer's profile.</summary>
    public static string ArtworkTheme(this PosterKind kind, string? festival = null, PosterLocale? locale = null)
    {
        locale ??= PosterLocale.Neutral;
        var name = PosterWords.Tidy(festival, PosterWords.MaxFestivalLength);
        return kind switch
        {
            PosterKind.Clearance => "a clearance sale: energetic red, coral and warm orange gradients, soft glowing light and a few subtle confetti shapes",
            PosterKind.NewArrivals => "new arrivals: fresh teal, mint and sky-blue gradients with soft light rays and a few gentle sparkles",
            PosterKind.BestSellers => "best sellers: deep royal blue with warm gold accents, a subtle star burst and soft sparkles",
            PosterKind.FestivalOffer => name.Length == 0
                ? "the festive season" + locale.InCountry + ": warm, celebratory colours with the decorations people there put up for festivals, placed around the edges"
                : "the festival of " + name + locale.InCountry + ": its traditional colours and decorations, placed around the edges",
            _ => throw new ArgumentOutOfRangeException(nameof(kind)),
        };
    }

    /// <summary>"Diwali offer", or "Festive offer" when no festival is named.</summary>
    public static string FestivalHeadline(string? festival)
    {
        var name = PosterWords.Tidy(festival, PosterWords.MaxFestivalLength);
        return name.Length == 0 ? "Festive offer" : name + " offer";
    }
}

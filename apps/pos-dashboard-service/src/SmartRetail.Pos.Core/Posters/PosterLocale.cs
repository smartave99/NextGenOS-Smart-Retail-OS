namespace SmartRetail.Pos.Core.Posters;

/// <summary>
/// What a customer's profile says about its posters: the country and kind of business (for the AI's task and the artwork), the festivals its shoppers keep,
/// the second language of its posters and a ready-made line in it for each kind. Nothing is assumed: <see cref="Neutral"/> has no country, no festival and
/// no second language, so a poster is one language and plain. The profile is the customer's (CLAUDE.md, section 8); the owner's settings do not change it.
/// </summary>
public sealed record PosterLocale
{
    /// <summary>The country as the prompts say it after "in", e.g. "the Philippines". Empty: no country is named.</summary>
    public string CountryName { get; init; } = "";

    /// <summary>E.g. "a small shop".</summary>
    public string ShopKind { get; init; } = "a small shop";

    /// <summary>The second language of the posters, e.g. "Hindi". Empty: posters are in one language.</summary>
    public string LocalLanguage { get; init; } = "";

    /// <summary>The language's tag, e.g. "hi": for the screen's and the print's language setting and for telling the script.</summary>
    public string LocalLanguageTag { get; init; } = "";

    /// <summary>Festivals to suggest for a festival offer. Empty: the occasion is typed in.</summary>
    public IReadOnlyList<string> Festivals { get; init; } = Array.Empty<string>();

    /// <summary>The ready-made second-language line by poster kind slug (e.g. "clearance").</summary>
    public IReadOnlyDictionary<string, string> LocalLines { get; init; } = new Dictionary<string, string>();

    public static PosterLocale Neutral { get; } = new();

    public bool HasLocalLanguage => LocalLanguage.Length > 0;

    /// <summary>" in the Philippines", or nothing.</summary>
    public string InCountry => CountryName.Length > 0 ? " in " + CountryName : "";

    /// <summary>"a small shop in the Philippines".</summary>
    public string Shop => ShopKind + InCountry;

    /// <summary>The ready-made second-language line for a kind; empty without a second language or without a line for that kind.</summary>
    public string LocalLineFor(PosterKind kind) =>
        HasLocalLanguage && LocalLines.TryGetValue(kind.Slug(), out var line) ? line : "";

    /// <summary>True when a character is in the second language's own script; null when its script is not told apart from English (e.g. Filipino, Spanish, Indonesian).</summary>
    public Func<char, bool>? InLocalScript => HasLocalLanguage ? Scripts.Of(LocalLanguageTag) : null;
}

/// <summary>Which writing system a language tag uses, for the languages whose script is not the Latin one.</summary>
public static class Scripts
{
    private static readonly (string[] Tags, (int From, int To)[] Ranges)[] Table =
    {
        (new[] { "hi", "mr", "ne", "sa", "kok", "mai", "bho" }, new[] { (0x0900, 0x097F), (0xA8E0, 0xA8FF) }),
        (new[] { "bn", "as" }, new[] { (0x0980, 0x09FF) }),
        (new[] { "pa" }, new[] { (0x0A00, 0x0A7F) }),
        (new[] { "gu" }, new[] { (0x0A80, 0x0AFF) }),
        (new[] { "or" }, new[] { (0x0B00, 0x0B7F) }),
        (new[] { "ta" }, new[] { (0x0B80, 0x0BFF) }),
        (new[] { "te" }, new[] { (0x0C00, 0x0C7F) }),
        (new[] { "kn" }, new[] { (0x0C80, 0x0CFF) }),
        (new[] { "ml" }, new[] { (0x0D00, 0x0D7F) }),
        (new[] { "si" }, new[] { (0x0D80, 0x0DFF) }),
        (new[] { "th" }, new[] { (0x0E00, 0x0E7F) }),
        (new[] { "lo" }, new[] { (0x0E80, 0x0EFF) }),
        (new[] { "my" }, new[] { (0x1000, 0x109F) }),
        (new[] { "km" }, new[] { (0x1780, 0x17FF) }),
        (new[] { "ar", "ur", "fa", "ps", "sd", "ug" }, new[] { (0x0600, 0x06FF), (0x0750, 0x077F), (0xFB50, 0xFDFF), (0xFE70, 0xFEFF) }),
        (new[] { "he", "yi" }, new[] { (0x0590, 0x05FF) }),
        (new[] { "ru", "uk", "bg", "sr", "mk", "be", "kk", "ky", "mn", "tg" }, new[] { (0x0400, 0x04FF) }),
        (new[] { "el" }, new[] { (0x0370, 0x03FF), (0x1F00, 0x1FFF) }),
        (new[] { "ka" }, new[] { (0x10A0, 0x10FF) }),
        (new[] { "hy" }, new[] { (0x0530, 0x058F) }),
        (new[] { "zh", "ja", "ko", "yue" }, new[] { (0x1100, 0x11FF), (0x3040, 0x30FF), (0x3400, 0x4DBF), (0x4E00, 0x9FFF), (0xAC00, 0xD7AF) }),
    };

    /// <summary>The test for a language tag's own script ("hi", "hi-IN"), or null when the language is written in the Latin script (or is not known here).</summary>
    public static Func<char, bool>? Of(string? tag)
    {
        var primary = (tag ?? "").Trim().ToLowerInvariant().Split('-', '_')[0];
        foreach (var (tags, ranges) in Table)
        {
            if (Array.IndexOf(tags, primary) >= 0)
            {
                return c => ranges.Any(r => c >= r.From && c <= r.To);
            }
        }

        return null;
    }
}

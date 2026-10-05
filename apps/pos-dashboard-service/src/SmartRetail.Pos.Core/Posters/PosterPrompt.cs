using System.Globalization;
using System.Text;
using System.Text.Json;

namespace SmartRetail.Pos.Core.Posters;

/// <summary>The products and words an AI chose for a poster, after the app checked them.</summary>
/// <param name="ChosenByAi">How many of the products the AI chose; the app adds the rest from its own list.</param>
public sealed record PosterPlan(IReadOnlyList<PosterItem> Items, PosterWords Words, int ChosenByAi);

/// <summary>
/// What the AI is asked when it picks a poster's products and writes its words, and how its answer is checked.
/// The AI gets product names and figures only (never customers), may only choose products from the list, and its
/// offers are held to each product's limit. Prices and offers on the poster always come from the POS.
/// </summary>
public static class PosterPrompt
{
    public const string SystemPrompt =
        "You plan A4 posters for a small shop in India. You are given the kind of poster, how many products it shows, "
        + "and the shop's products that suit it, with figures from its billing software.\n"
        + "Rules:\n"
        + "- Choose products only from the list, by their ref (P1, P2, ...). Never invent products.\n"
        + "- For each product choose an offer in whole percent, from 0 (no offer) up to its max_offer. Never more.\n"
        + "- Write a short English headline, one line in Hindi (Devanagari script) and a short English line to go under them.\n"
        + "- The words must not contain prices, numbers, percentages, ₹, dates or product names: the shop prints those itself.\n"
        + "- Reply with JSON only, no other text.";

    public static string UserPrompt(PosterKind kind, int count, IReadOnlyList<PosterCandidate> candidates, DateOnly today, PosterRules rules, string? festival = null)
    {
        ArgumentNullException.ThrowIfNull(candidates);
        ArgumentNullException.ThrowIfNull(rules);
        var culture = CultureInfo.InvariantCulture;
        var text = new StringBuilder();
        text.Append("THE POSTER\n");
        text.Append("Kind: ").Append(Describe(kind, festival, rules)).Append('\n');
        text.Append("Products on the poster: ").Append(count.ToString(culture)).Append('\n');
        text.Append("Today: ").Append(today.ToString("dddd d MMMM yyyy", culture)).Append("\n\n");

        text.Append("PRODUCTS TO CHOOSE FROM\n");
        text.Append("ref | product | category | price ₹ (GST included) | max_offer % | in stock | sold in last ")
            .Append(rules.SalesDays.ToString(culture)).Append(" days | last sold | added | has photo\n");
        for (var i = 0; i < candidates.Count; i++)
        {
            var c = candidates[i];
            text.Append('P').Append((i + 1).ToString(culture)).Append(" | ")
                .Append(OneLine(c.Name)).Append(" | ")
                .Append(OneLine(c.Category)).Append(" | ")
                .Append(c.Price.ToString("0.##", culture)).Append(" | ")
                .Append(c.MaxOfferPercent.ToString("0", culture)).Append(" | ")
                .Append(c.StockInHand.ToString("0.###", culture)).Append(" | ")
                .Append(c.QtySold.ToString("0.###", culture)).Append(" | ")
                .Append(c.LastSold is { } last ? Ago(today, last) : "not in " + rules.LookBackDays.ToString(culture) + " days").Append(" | ")
                .Append(c.AddedOn is { } added ? Ago(today, added) : "unknown").Append(" | ")
                .Append(c.HasPhoto ? "yes" : "no").Append('\n');
        }

        text.Append("\nHOW TO CHOOSE\n").Append(Guidance(kind, festival)).Append("\n\n");
        text.Append("ANSWER\nReply with this JSON and nothing else:\n");
        text.Append("{\"products\": [{\"ref\": \"P1\", \"offer_percent\": 0}], \"headline\": \"\", \"hindi_line\": \"\", \"subline\": \"\"}\n");
        text.Append("- products: exactly ").Append(Math.Min(count, candidates.Count).ToString(culture))
            .Append(", the most eye-catching first. Prefer products with a photo.\n");
        text.Append("- headline: English, at most ").Append(PosterWords.MaxHeadlineLength.ToString(culture)).Append(" characters.\n");
        text.Append("- hindi_line: Hindi in Devanagari script, at most ").Append(PosterWords.MaxHindiLineLength.ToString(culture)).Append(" characters.\n");
        text.Append("- subline: English, at most ").Append(PosterWords.MaxSublineLength.ToString(culture)).Append(" characters.");
        return text.ToString();
    }

    /// <summary>
    /// Reads the AI's answer: products must come from <paramref name="candidates"/> (each once), offers are held
    /// to each product's limit, words are checked (<see cref="PosterWords.FromAi"/>), and the app adds products
    /// from its own list when the AI chose too few. Null when the answer has no JSON the app can read.
    /// </summary>
    public static PosterPlan? ReadAnswer(string? answer, PosterKind kind, int count, IReadOnlyList<PosterCandidate> candidates, string? festival = null)
    {
        ArgumentNullException.ThrowIfNull(candidates);
        var json = JsonPart(answer);
        if (json is null)
        {
            return null;
        }

        JsonDocument document;
        try
        {
            document = JsonDocument.Parse(json, new JsonDocumentOptions { AllowTrailingCommas = true, CommentHandling = JsonCommentHandling.Skip });
        }
        catch (JsonException)
        {
            return null;
        }

        using (document)
        {
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object)
            {
                return null;
            }

            var wanted = Math.Min(Math.Max(0, count), candidates.Count);
            var chosen = new List<(PosterCandidate Candidate, decimal Percent)>();
            if (root.TryGetProperty("products", out var products) && products.ValueKind == JsonValueKind.Array)
            {
                foreach (var product in products.EnumerateArray())
                {
                    if (chosen.Count == wanted)
                    {
                        break;
                    }

                    var candidate = Find(product, candidates);
                    if (candidate is null || chosen.Any(c => c.Candidate.ProductId == candidate.ProductId))
                    {
                        continue;
                    }

                    var percent = Math.Clamp(Percent(product), 0m, candidate.MaxOfferPercent);
                    chosen.Add((candidate, percent));
                }
            }

            var byAi = chosen.Count;
            foreach (var candidate in candidates)
            {
                if (chosen.Count >= wanted)
                {
                    break;
                }

                if (chosen.All(c => c.Candidate.ProductId != candidate.ProductId))
                {
                    chosen.Add((candidate, Math.Min(kind.DefaultOfferPercent(), candidate.MaxOfferPercent)));
                }
            }

            var words = PosterWords.FromAi(Text(root, "headline"), Text(root, "hindi_line"), Text(root, "subline"), kind.DefaultWords(festival));
            return new PosterPlan(chosen.Select(c => c.Candidate.ToItem(c.Percent)).ToList(), words, byAi);
        }
    }

    private static string Describe(PosterKind kind, string? festival, PosterRules rules) => kind switch
    {
        PosterKind.Clearance => "Clearance sale: products that have not sold for " + rules.SlowAfterDays.ToString(CultureInfo.InvariantCulture)
            + " days or more. An offer helps clear them.",
        PosterKind.NewArrivals => "New arrivals: products the shop added recently.",
        PosterKind.BestSellers => "Best sellers: the products customers buy most.",
        PosterKind.FestivalOffer => "Festival offer for " + (string.IsNullOrWhiteSpace(festival) ? "the coming festival season" : OneLine(festival))
            + ": popular products at special prices.",
        _ => throw new ArgumentOutOfRangeException(nameof(kind)),
    };

    private static string Guidance(PosterKind kind, string? festival) => kind switch
    {
        PosterKind.Clearance => "Choose the products most worth clearing: more stock and longer without a sale first. "
            + "Suggest offers big enough for customers to notice, usually 10 to 25 percent, within each max_offer.",
        PosterKind.NewArrivals => "Choose the newest products that will interest customers. Usually no offer (0); "
            + "a small launch offer only where it clearly helps.",
        PosterKind.BestSellers => "Choose the products customers buy most. Usually no offer (0).",
        PosterKind.FestivalOffer => "Choose products people buy for "
            + (string.IsNullOrWhiteSpace(festival) ? "festivals" : OneLine(festival))
            + " (gifts, sweets, pooja items, decorations, household needs for guests) and popular products. Offers usually 5 to 15 percent.",
        _ => throw new ArgumentOutOfRangeException(nameof(kind)),
    };

    private static PosterCandidate? Find(JsonElement product, IReadOnlyList<PosterCandidate> candidates)
    {
        var reference = product.ValueKind switch
        {
            JsonValueKind.Object when product.TryGetProperty("ref", out var value) => value.ValueKind == JsonValueKind.Number ? value.GetRawText() : value.GetString(),
            JsonValueKind.String => product.GetString(),
            _ => null,
        };

        var digits = (reference ?? "").Trim().TrimStart('P', 'p');
        return int.TryParse(digits, NumberStyles.None, CultureInfo.InvariantCulture, out var number) && number >= 1 && number <= candidates.Count
            ? candidates[number - 1]
            : null;
    }

    private static decimal Percent(JsonElement product)
    {
        if (product.ValueKind != JsonValueKind.Object || !product.TryGetProperty("offer_percent", out var value))
        {
            return 0m;
        }

        var parsed = value.ValueKind switch
        {
            JsonValueKind.Number when value.TryGetDecimal(out var number) => number,
            JsonValueKind.String when decimal.TryParse(value.GetString()?.Trim().TrimEnd('%'), NumberStyles.Number, CultureInfo.InvariantCulture, out var number) => number,
            _ => 0m,
        };
        return Math.Floor(parsed);
    }

    private static string? Text(JsonElement root, string name) =>
        root.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.String ? value.GetString() : null;

    /// <summary>The JSON object in an answer, also when it is wrapped in a code block or a sentence.</summary>
    private static string? JsonPart(string? answer)
    {
        if (string.IsNullOrWhiteSpace(answer))
        {
            return null;
        }

        var start = answer.IndexOf('{');
        var end = answer.LastIndexOf('}');
        return start >= 0 && end > start ? answer[start..(end + 1)] : null;
    }

    private static string Ago(DateOnly today, DateOnly day)
    {
        var days = today.DayNumber - day.DayNumber;
        return days <= 0 ? "today" : days == 1 ? "yesterday" : days.ToString(CultureInfo.InvariantCulture) + " days ago";
    }

    private static string OneLine(string? text) => PosterWords.Tidy(text, 80).Replace('|', '/');
}

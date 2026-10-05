using System.Text.Json;
using System.Text.Json.Serialization;

namespace NextGenOS.Hub.Shop;

/// <summary>An industry pack (industry-packs/SPEC.md): the words, parts, rules and demo company of one kind of business.</summary>
public sealed class IndustryPack
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";
    [JsonPropertyName("name")] public string Name { get; set; } = "";
    [JsonPropertyName("summary")] public string Summary { get; set; } = "";
    [JsonPropertyName("icon")] public string Icon { get; set; } = "";
    [JsonPropertyName("vocabulary")] public Dictionary<string, string[]> Vocabulary { get; set; } = new();
    [JsonPropertyName("features")] public Features Features { get; set; } = new();
    [JsonPropertyName("itemKinds")] public List<ItemKind> ItemKinds { get; set; } = new();
    [JsonPropertyName("partyKinds")] public List<PartyKind> PartyKinds { get; set; } = new();
    [JsonPropertyName("defaults")] public IndustryDefaults Defaults { get; set; } = new();
    [JsonPropertyName("rules")] public JsonElement Rules { get; set; }
    [JsonPropertyName("reports")] public List<string> Reports { get; set; } = new();
    [JsonPropertyName("demo")] public JsonElement Demo { get; set; }
    [JsonPropertyName("aiContext")] public string AiContext { get; set; } = "";
    [JsonPropertyName("coverage")] public Coverage Coverage { get; set; } = new();

    public string Singular(string term) => Vocabulary.TryGetValue(term, out var pair) ? pair[0] : term;

    public string Plural(string term) => Vocabulary.TryGetValue(term, out var pair) ? pair[1] : term;

    /// <summary>A number from the pack's rules, or the fallback.</summary>
    public decimal RuleNumber(string name, decimal fallback)
    {
        if (Rules.ValueKind != JsonValueKind.Object || !Rules.TryGetProperty(name, out var value)) return fallback;
        return value.ValueKind switch
        {
            JsonValueKind.Number => value.GetDecimal(),
            JsonValueKind.String when decimal.TryParse(value.GetString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out var d) => d,
            _ => fallback,
        };
    }

    public string RuleText(string name, string fallback) =>
        Rules.ValueKind == JsonValueKind.Object && Rules.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.String ? value.GetString() ?? fallback : fallback;
}

public sealed class Features
{
    [JsonPropertyName("counterSale")] public bool CounterSale { get; set; }
    [JsonPropertyName("tables")] public bool Tables { get; set; }
    [JsonPropertyName("kitchen")] public bool Kitchen { get; set; }
    [JsonPropertyName("lending")] public bool Lending { get; set; }
    [JsonPropertyName("projects")] public bool Projects { get; set; }
    [JsonPropertyName("appointments")] public bool Appointments { get; set; }
    [JsonPropertyName("credit")] public bool Credit { get; set; }
    [JsonPropertyName("purchases")] public bool Purchases { get; set; }
    [JsonPropertyName("weighedItems")] public bool WeighedItems { get; set; }
    [JsonPropertyName("stockTracking")] public string StockTracking { get; set; } = "optional";

    public Features Clone() => (Features)MemberwiseClone();
}

public sealed class ItemKind
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";
    [JsonPropertyName("label")] public string Label { get; set; } = "";
    [JsonPropertyName("tracksStock")] public bool TracksStock { get; set; }
    [JsonPropertyName("hasDuration")] public bool HasDuration { get; set; }
}

public sealed class PartyKind
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";
    [JsonPropertyName("label")] public string Label { get; set; } = "";
}

public sealed class IndustryDefaults
{
    [JsonPropertyName("adjustments")] public List<DefaultAdjustment> Adjustments { get; set; } = new();
    [JsonPropertyName("paymentMethods")] public List<string> PaymentMethods { get; set; } = new();
}

public sealed class DefaultAdjustment
{
    [JsonPropertyName("code")] public string Code { get; set; } = "";
    [JsonPropertyName("kind")] public string Kind { get; set; } = "";
    [JsonPropertyName("label")] public string Label { get; set; } = "";
    [JsonPropertyName("percent")] public string? Percent { get; set; }
    [JsonPropertyName("base")] public string? Base { get; set; }
    [JsonPropertyName("taxed")] public bool Taxed { get; set; }
    [JsonPropertyName("optional")] public bool Optional { get; set; }
}

public sealed class Coverage
{
    [JsonPropertyName("works")] public List<string> Works { get; set; } = new();
    [JsonPropertyName("notYet")] public List<string> NotYet { get; set; } = new();
}

/// <summary>The industry packs built into the Hub (from industry-packs/packs).</summary>
public static class IndustryCatalog
{
    private const string Prefix = "NextGenOS.Hub.industries.";
    private static readonly object Gate = new();
    private static Dictionary<string, IndustryPack>? _packs;

    public static IReadOnlyList<IndustryPack> All() => Load().Values.OrderBy(p => p.Name, StringComparer.Ordinal).ToList();

    public static IndustryPack? Find(string? id) => id != null && Load().TryGetValue(id.Trim().ToLowerInvariant(), out var pack) ? pack : null;

    public static IndustryPack Get(string id) =>
        Find(id) ?? throw new ArgumentException($"There is no industry pack \"{id}\". Choose one of: {string.Join(", ", Load().Keys.OrderBy(k => k, StringComparer.Ordinal))}.");

    private static Dictionary<string, IndustryPack> Load()
    {
        lock (Gate)
        {
            if (_packs != null) return _packs;
            var assembly = typeof(IndustryCatalog).Assembly;
            var packs = new Dictionary<string, IndustryPack>(StringComparer.Ordinal);
            foreach (var name in assembly.GetManifestResourceNames().Where(n => n.StartsWith(Prefix, StringComparison.Ordinal) && n.EndsWith(".json", StringComparison.Ordinal)))
            {
                using var stream = assembly.GetManifestResourceStream(name)!;
                var pack = JsonSerializer.Deserialize<IndustryPack>(stream) ?? throw new InvalidDataException(name);
                packs[pack.Id] = pack;
            }
            _packs = packs;
            return _packs;
        }
    }
}

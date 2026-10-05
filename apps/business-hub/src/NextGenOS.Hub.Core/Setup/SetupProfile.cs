using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;

namespace NextGenOS.Hub.Setup;

/// <summary>An item the customer's profile starts the shop with.</summary>
public sealed record StarterItem(string Name, string Price, string Kind, string TaxClass, string? Barcode, string? Unit, string? Category);

/// <summary>A person (customer, supplier, member ...) the customer's profile starts the shop with.</summary>
public sealed record StarterParty(string Kind, string Name, string? Phone, string? Email);

/// <summary>
/// How a business is set up, prepared for one customer (profile/setup.json, written by the Setup Studio): the business, the settings, the words and parts, and a small list of
/// first items and people. It is data only. Read tolerantly: a part that is wrong is left out and named in <see cref="Problems"/>; the rest still applies. It never holds a
/// password, a licence or a tax rate: the owner's sign-in is chosen by the owner, the licence is activated with a key, and tax comes from the country's pack.
/// </summary>
public sealed class SetupProfile
{
    public const int MaxStarter = 2000;
    private static readonly string[] Features = { "counterSale", "tables", "kitchen", "lending", "projects", "appointments", "credit", "purchases", "weighedItems" };
    private static readonly string[] Known = { "schema", "business", "settings", "vocabulary", "features", "starter", "notes" };
    private static readonly Regex Price = new(@"^\d{1,12}(\.\d{1,4})?$", RegexOptions.CultureInvariant);
    private static readonly Regex Word = new(@"^[\p{L}\p{N} \-]{1,20}$", RegexOptions.CultureInvariant);

    /// <summary>True when the text was a setup profile (it said "schema": 1); false for no text or for text that is not one.</summary>
    public bool IsProfile { get; private set; }
    public string? Name { get; private set; }
    public string? Country { get; private set; }
    public string? Region { get; private set; }
    public string? Industry { get; private set; }
    public bool? PricesIncludeTax { get; private set; }
    public bool? TaxRegistered { get; private set; }
    public bool? RoundTotal { get; private set; }
    public bool? AllowNegativeStock { get; private set; }
    public string? ReceiptFooter { get; private set; }
    public List<string> PaymentMethods { get; } = new();
    public Dictionary<string, string[]> Vocabulary { get; } = new();
    public Dictionary<string, bool> FeatureChoices { get; } = new();
    public List<StarterItem> Items { get; } = new();
    public List<StarterParty> People { get; } = new();
    public string? Notes { get; private set; }

    /// <summary>What was wrong in the text, in plain words (each names the part that was left out).</summary>
    public List<string> Problems { get; } = new();

    public bool HasStarter => Items.Count > 0 || People.Count > 0;

    /// <summary>Reads the text of a setup profile. Never throws: a text that is not a profile gives an empty one with a problem named.</summary>
    public static SetupProfile Parse(string? json)
    {
        var p = new SetupProfile();
        if (string.IsNullOrWhiteSpace(json)) return p;
        JsonDocument doc;
        try { doc = JsonDocument.Parse(json, new JsonDocumentOptions { MaxDepth = 16, AllowTrailingCommas = false }); }
        catch (JsonException) { p.Problems.Add("The setup file is not readable (it is not valid JSON)."); return p; }
        using (doc)
        {
            var root = doc.RootElement;
            if (root.ValueKind != JsonValueKind.Object) { p.Problems.Add("The setup file is not a setup profile."); return p; }
            foreach (var prop in root.EnumerateObject()) if (Array.IndexOf(Known, prop.Name) < 0) p.Problems.Add($"\"{prop.Name}\" is not a part of a setup profile and is ignored.");
            if (!root.TryGetProperty("schema", out var schema) || schema.ValueKind != JsonValueKind.Number || !schema.TryGetInt32(out var version) || version != 1) { p.Problems.Add("The setup file must say \"schema\": 1."); return p; }
            p.IsProfile = true;
            p.ReadBusiness(root);
            p.ReadSettings(root);
            p.ReadWords(root);
            p.ReadStarter(root);
            if (root.TryGetProperty("notes", out var notes) && notes.ValueKind == JsonValueKind.String) p.Notes = Clean(notes.GetString(), 2000);
        }
        return p;
    }

    private static string? Clean(string? text, int max)
    {
        if (string.IsNullOrWhiteSpace(text)) return null;
        var t = new string(text.Where(c => !char.IsControl(c) || c == '\n').ToArray()).Trim();
        return t.Length == 0 ? null : t.Length <= max ? t : t[..max];
    }

    private static string? Text(JsonElement parent, string name) => parent.ValueKind == JsonValueKind.Object && parent.TryGetProperty(name, out var e) && e.ValueKind == JsonValueKind.String ? e.GetString() : null;

    private static bool? Flag(JsonElement parent, string name) => parent.ValueKind == JsonValueKind.Object && parent.TryGetProperty(name, out var e) && e.ValueKind is JsonValueKind.True or JsonValueKind.False ? e.GetBoolean() : null;

    private void ReadBusiness(JsonElement root)
    {
        if (!root.TryGetProperty("business", out var b) || b.ValueKind != JsonValueKind.Object) return;
        Name = Clean(Text(b, "name"), 80);
        var country = Text(b, "country")?.Trim().ToUpperInvariant();
        CountryPack? pack = null;
        if (!string.IsNullOrEmpty(country))
        {
            pack = PackCatalog.Find(country);
            if (pack is null) Problems.Add($"There is no tax pack for the country \"{country}\"; the country is left to choose.");
            else Country = country;
        }
        var industry = Text(b, "industry")?.Trim().ToLowerInvariant();
        if (!string.IsNullOrEmpty(industry))
        {
            if (IndustryCatalog.Find(industry) is null) Problems.Add($"There is no kind of business called \"{industry}\"; it is left to choose.");
            else Industry = industry;
        }
        var region = Text(b, "region")?.Trim();
        if (!string.IsNullOrEmpty(region))
        {
            if (pack?.Tax.Regions?.List?.Any(r => r.Code == region) == true) Region = region;
            else Problems.Add($"The region \"{region}\" is not one of the country's; it is left to choose.");
        }
    }

    private void ReadSettings(JsonElement root)
    {
        if (root.TryGetProperty("settings", out var s) && s.ValueKind == JsonValueKind.Object)
        {
            PricesIncludeTax = Flag(s, "pricesIncludeTax");
            TaxRegistered = Flag(s, "taxRegistered");
            RoundTotal = Flag(s, "roundTotal");
            AllowNegativeStock = Flag(s, "allowNegativeStock");
            ReceiptFooter = Clean(Text(s, "receiptFooter"), 160);
            if (s.TryGetProperty("paymentMethods", out var methods) && methods.ValueKind == JsonValueKind.Array)
            {
                foreach (var m in methods.EnumerateArray())
                {
                    var word = m.ValueKind == JsonValueKind.String ? m.GetString()!.Trim().ToLowerInvariant() : "";
                    if (!Word.IsMatch(word)) { Problems.Add("A way of paying must be a short word (letters, numbers, spaces); one was left out."); continue; }
                    if (!PaymentMethods.Contains(word) && PaymentMethods.Count < 12) PaymentMethods.Add(word);
                }
            }
        }
    }

    private void ReadWords(JsonElement root)
    {
        var pack = IndustryCatalog.Find(Industry ?? "retail");
        if (root.TryGetProperty("vocabulary", out var v) && v.ValueKind == JsonValueKind.Object)
        {
            foreach (var term in v.EnumerateObject())
            {
                var pair = term.Value.ValueKind == JsonValueKind.Array ? term.Value.EnumerateArray().Select(x => x.ValueKind == JsonValueKind.String ? Clean(x.GetString(), 30) : null).ToArray() : Array.Empty<string?>();
                if (pair.Length != 2 || pair[0] is null || pair[1] is null) { Problems.Add($"The word for \"{term.Name}\" needs a one and a many (two short words); it was left out."); continue; }
                if (pack is not null && !pack.Vocabulary.ContainsKey(term.Name)) { Problems.Add($"\"{term.Name}\" is not a word this kind of business uses; it was left out."); continue; }
                Vocabulary[term.Name] = new[] { pair[0]!, pair[1]! };
            }
        }
        if (root.TryGetProperty("features", out var f) && f.ValueKind == JsonValueKind.Object)
        {
            foreach (var feature in f.EnumerateObject())
            {
                if (Array.IndexOf(Features, feature.Name) < 0 || feature.Value.ValueKind is not (JsonValueKind.True or JsonValueKind.False)) { Problems.Add($"\"{feature.Name}\" is not a part of the program that can be switched on or off; it was left out."); continue; }
                FeatureChoices[feature.Name] = feature.Value.GetBoolean();
            }
        }
    }

    private void ReadStarter(JsonElement root)
    {
        if (!root.TryGetProperty("starter", out var starter) || starter.ValueKind != JsonValueKind.Object) return;
        var pack = IndustryCatalog.Find(Industry ?? "retail");
        var itemKinds = pack?.ItemKinds.Select(k => k.Id).ToHashSet() ?? new HashSet<string>();
        var partyKinds = pack?.PartyKinds.Select(k => k.Id).ToHashSet() ?? new HashSet<string>();
        if (starter.TryGetProperty("items", out var items) && items.ValueKind == JsonValueKind.Array)
        {
            var skipped = 0;
            foreach (var e in items.EnumerateArray())
            {
                if (Items.Count >= MaxStarter) { skipped++; continue; }
                var name = Clean(Text(e, "name"), 80);
                var price = e.ValueKind == JsonValueKind.Object && e.TryGetProperty("price", out var pr) ? (pr.ValueKind == JsonValueKind.Number ? pr.GetRawText() : pr.ValueKind == JsonValueKind.String ? pr.GetString()!.Trim() : null) : null;
                if (name is null || price is null || !Price.IsMatch(price)) { skipped++; continue; }
                var kind = Text(e, "kind")?.Trim() ?? "stock";
                if (itemKinds.Count > 0 && !itemKinds.Contains(kind)) kind = itemKinds.Contains("stock") ? "stock" : itemKinds.First();
                Items.Add(new StarterItem(name, price, kind, Clean(Text(e, "taxClass"), 20) ?? "standard", Clean(Text(e, "barcode"), 40), Clean(Text(e, "unit"), 10), Clean(Text(e, "category"), 40)));
            }
            if (skipped > 0) Problems.Add($"{skipped} starter item(s) were left out (a name and a price like 125.50 are needed, and at most {MaxStarter}).");
        }
        if (starter.TryGetProperty("people", out var people) && people.ValueKind == JsonValueKind.Array)
        {
            var skipped = 0;
            foreach (var e in people.EnumerateArray())
            {
                if (People.Count >= MaxStarter) { skipped++; continue; }
                var name = Clean(Text(e, "name"), 80);
                var kind = Text(e, "kind")?.Trim() ?? "customer";
                if (name is null || (partyKinds.Count > 0 && !partyKinds.Contains(kind))) { skipped++; continue; }
                People.Add(new StarterParty(kind, name, Clean(Text(e, "phone"), 30), Clean(Text(e, "email"), 120)));
            }
            if (skipped > 0) Problems.Add($"{skipped} starter person(s) were left out (a name and a kind this business uses are needed).");
        }
    }

    /// <summary>
    /// Puts the profile's settings, words and parts into a shop's settings (what the owner sets up later can still change them). Whether the business is registered for the tax
    /// is not put in here: the set-up wizard asks the owner, and the profile only fills in the answer to start from.
    /// </summary>
    public void ApplyTo(ShopSettings settings)
    {
        if (PricesIncludeTax is { } a) settings.PricesIncludeTax = a;
        if (RoundTotal is { } c) settings.RoundTotal = c;
        if (AllowNegativeStock is { } d) settings.AllowNegativeStock = d;
        if (ReceiptFooter is not null) settings.ReceiptFooter = ReceiptFooter;
        if (PaymentMethods.Count > 0) settings.PaymentMethods = PaymentMethods.ToList();
        foreach (var (term, pair) in Vocabulary) settings.VocabularyOverrides[term] = pair;
        foreach (var (feature, on) in FeatureChoices) settings.FeatureOverrides[feature] = on;
    }

    /// <summary>Adds the starter items and people through the same services the screens use. A line that cannot be added is left out and named; the rest go in.</summary>
    public StarterResult ApplyStarter(HubApp app)
    {
        var added = new StarterResult();
        var shop = app.Shop.Current;
        var classes = shop.TaxClasses();
        foreach (var item in Items)
        {
            try
            {
                app.Catalog.Create(new ItemInput
                {
                    Kind = item.Kind, Name = item.Name, PriceMinor = shop.Minor(item.Price), Barcode = item.Barcode, Unit = item.Unit ?? "pc", Category = item.Category,
                    TaxClass = classes.Contains(item.TaxClass) ? item.TaxClass : "standard",
                });
                added.Items++;
            }
            catch (HubException ex) { added.Skipped.Add($"{item.Name}: {ex.Message}"); }
        }
        foreach (var person in People)
        {
            try { app.Parties.Create(new PartyInput { Kind = person.Kind, Name = person.Name, Phone = person.Phone, Email = person.Email }); added.People++; }
            catch (HubException ex) { added.Skipped.Add($"{person.Name}: {ex.Message}"); }
        }
        return added;
    }
}

/// <summary>What adding the starter items and people did.</summary>
public sealed class StarterResult
{
    public int Items { get; set; }
    public int People { get; set; }
    public List<string> Skipped { get; } = new();
}

using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using SmartRetail.AI.Products;
using SmartRetail.Pos.Core;
using SmartRetail.Pos.Core.Labels;

namespace SmartRetail.Pos.Web.Services;

/// <summary>What a listing needs from the POS, and never from an AI: the name, the price the customer pays, the MRP,
/// and the barcode on the stock.</summary>
/// <param name="Price">What the customer pays, with GST (as the posters show it).</param>
/// <param name="Mrp">The stock's MRP; 0 when the POS has none.</param>
/// <param name="Barcode">The stock batch's code, as the till scans it; empty when the POS has none.</param>
/// <param name="MakerBarcode">A maker's barcode of any of the product's stock batches (see <see cref="Gtin.MakerCode"/>), which
/// may not be the batch the till scans; empty when none has one.</param>
public sealed record ListingFacts(string Name, string Code, decimal Price, decimal Mrp, string Barcode, decimal Stock, string MakerBarcode = "")
{
    /// <summary>"EAN-13" and the like when the barcode is the maker's, which Amazon asks for; null for a shop's own code.</summary>
    public string? BarcodeKind => Gtin.Kind(Barcode);
}

/// <summary>
/// A product's listings as files to use elsewhere: the Amazon listing as text to copy into Seller Central, and the
/// website's as JSON in the fields the shop's website keeps for a product (name, description, price, originalPrice,
/// highlights, specifications, tags, barcode). Prices and the barcode come from the POS.
/// </summary>
public static class ListingExport
{
    private static readonly JsonSerializerOptions Json = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public static string AmazonText(ProductListing listing, ListingFacts facts)
    {
        ArgumentNullException.ThrowIfNull(listing);
        ArgumentNullException.ThrowIfNull(facts);
        var amazon = listing.Amazon;
        var text = new StringBuilder();
        text.Append("AMAZON LISTING: ").Append(facts.Name).Append(" (").Append(facts.Code).Append(")\n\n");
        Section(text, "Title", amazon.Title);
        if (amazon.Bullets.Count > 0)
        {
            text.Append("Bullet points\n");
            foreach (var bullet in amazon.Bullets)
            {
                text.Append("- ").Append(bullet).Append('\n');
            }

            text.Append('\n');
        }

        Section(text, "Product description", amazon.Description);
        Section(text, "Search terms", amazon.SearchTerms);
        text.Append("Details\n");
        foreach (var (label, value) in Details(amazon))
        {
            text.Append(label).Append(": ").Append(value.Length > 0 ? value : "(not on the pack: fill in)").Append('\n');
        }

        text.Append("\nFrom the POS\n")
            .Append("Price the customer pays: ").Append(Money.Format(facts.Price)).Append('\n');
        if (facts.Mrp > 0)
        {
            text.Append("MRP: ").Append(Money.Format(facts.Mrp)).Append('\n');
        }

        text.Append("Barcode: ").Append(
            facts.Barcode.Length == 0 ? "none in the POS (Amazon asks for the maker's EAN barcode, or an exemption)\n"
            : facts.BarcodeKind is { } kind ? facts.Barcode + " (" + kind + ", the maker's barcode)\n"
            : facts.Barcode + " (the shop's own code: Amazon asks for the maker's EAN barcode, or an exemption)\n");
        return text.ToString();
    }

    /// <summary>The Amazon details with their labels, in the order Seller Central asks for them.</summary>
    public static IReadOnlyList<(string Label, string Value)> Details(AmazonListing amazon) => new[]
    {
        ("Brand", amazon.Brand),
        ("Generic name", amazon.GenericName),
        ("Product type", amazon.ProductType),
        ("Colour", amazon.Colour),
        ("Material", amazon.Material),
        ("Size", amazon.Size),
        ("Number of items", amazon.ItemCount),
        ("Included components", amazon.Included),
    };

    /// <param name="images">The photos' file names, as in the ZIP of all photos.</param>
    public static string WebsiteJson(ProductListing listing, ListingFacts facts, IReadOnlyList<string> images)
    {
        ArgumentNullException.ThrowIfNull(listing);
        ArgumentNullException.ThrowIfNull(facts);
        var website = listing.Website;
        var product = new WebsiteProduct(
            website.Name.Length > 0 ? website.Name : facts.Name,
            website.Description,
            facts.Price,
            facts.Mrp > facts.Price ? facts.Mrp : null,
            website.Highlights,
            website.Specifications.Select(s => new WebsiteSpec(s.Key, s.Value)).ToList(),
            website.Tags,
            website.Category.Length > 0 ? website.Category : null,
            facts.Barcode.Length > 0 ? facts.Barcode : null,
            images);
        return JsonSerializer.Serialize(product, Json);
    }

    /// <summary>E.g. "Sunflower Oil 1 L - Amazon listing.txt".</summary>
    public static string FileName(string productName, string what)
    {
        var safe = string.Concat((productName ?? "").Select(c => Path.GetInvalidFileNameChars().Contains(c) || c is '<' or '>' or ':' or '"' or '/' or '\\' or '|' or '?' or '*' ? ' ' : c));
        safe = System.Text.RegularExpressions.Regex.Replace(safe, @"\s+", " ").Trim();
        safe = safe.Length > 60 ? safe[..60].Trim() : safe;
        return (safe.Length > 0 ? safe : "Product") + " - " + what;
    }

    /// <summary>The whole of one tab, to copy at once.</summary>
    public static string WebsiteText(ProductListing listing, ListingFacts facts)
    {
        var website = listing.Website;
        var text = new StringBuilder();
        Section(text, "Name", website.Name);
        Section(text, "Description", website.Description);
        if (website.Highlights.Count > 0)
        {
            text.Append("Highlights\n").Append(string.Join("\n", website.Highlights.Select(h => "- " + h))).Append("\n\n");
        }

        if (website.Specifications.Count > 0)
        {
            text.Append("Specifications\n").Append(string.Join("\n", website.Specifications.Select(s => s.Key + ": " + s.Value))).Append("\n\n");
        }

        Section(text, "Tags", string.Join(", ", website.Tags));
        Section(text, "Category", website.Category);
        text.Append("Price: ").Append(Money.Format(facts.Price));
        if (facts.Mrp > facts.Price)
        {
            text.Append(" (MRP ").Append(Money.Format(facts.Mrp)).Append(')');
        }

        return text.Append('\n').ToString();
    }

    private static void Section(StringBuilder text, string title, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            text.Append(title).Append('\n').Append(value.Trim()).Append("\n\n");
        }
    }

    private sealed record WebsiteSpec(string Key, string Value);

    private sealed record WebsiteProduct(
        string Name,
        string Description,
        decimal Price,
        decimal? OriginalPrice,
        IReadOnlyList<string> Highlights,
        IReadOnlyList<WebsiteSpec> Specifications,
        IReadOnlyList<string> Tags,
        string? Category,
        string? Barcode,
        IReadOnlyList<string> Images);
}

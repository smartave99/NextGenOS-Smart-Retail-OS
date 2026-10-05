using System.Text.Json;
using SmartRetail.AI.Products;
using SmartRetail.Pos.Core.Labels;
using SmartRetail.Pos.Core.Models;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public class GtinTests
{
    [Theory]
    [InlineData("4006381333931", "EAN-13")]
    [InlineData("8901234567810", null)] // a wrong check digit
    [InlineData("036000291452", "UPC-A")]
    [InlineData("96385074", "EAN-8")]
    [InlineData("04006381333931", "GTIN-14")]
    [InlineData("00401234567893", null)] // a GTIN-14 around an in-store UPC
    [InlineData("02000000000060", null)] // and around an in-store EAN-13
    [InlineData(" 4006381333931 ", "EAN-13")]
    [InlineData("2000000000060", null)] // GS1's in-store numbers: the shop's own stickers
    [InlineData("21000000005", null)]
    [InlineData("020000000004", null)]
    [InlineData("201234563", null)]
    [InlineData("1006", null)]
    [InlineData("40063813339X1", null)]
    [InlineData("", null)]
    [InlineData(null, null)]
    public void Only_a_makers_barcode_is_named(string? code, string? kind)
    {
        Assert.Equal(kind, Gtin.Kind(code));
    }

    private static StockBatch Batch(string code, decimal qty) => new() { ProductId = 1, Name = "Basmati Rice", Code = code, Qty = qty };

    [Fact]
    public void The_makers_barcode_is_found_in_any_batch_the_one_with_most_stock_first()
    {
        // The batch with most stock has the shop's own sticker; another has the maker's: that one is the barcode to search by.
        Assert.Equal("4006381333931", Gtin.MakerCode(new[] { Batch("2000000000011", 40), Batch("4006381333931", 3) }));
        Assert.Equal("4006381333931", Gtin.MakerCode(new[] { Batch("RICE-BATCH-A", 40), Batch(" 4006381333931 ", 3), Batch("96385074", 1) }));
        Assert.Equal("96385074", Gtin.MakerCode(new[] { Batch("4006381333931", 3), Batch("96385074", 30) }));
        Assert.Equal("4006381333931", Gtin.MakerCode(new[] { Batch("4006381333931", 5), Batch("96385074", 5) }));
    }

    [Fact]
    public void No_makers_barcode_is_an_empty_one_never_the_shops_own_number()
    {
        Assert.Equal("", Gtin.MakerCode(new[] { Batch("2000000000011", 40), Batch("RICE-BATCH-B", 3), Batch("8901234567810", 9), Batch("", 2) }));
        Assert.Equal("", Gtin.MakerCode(Array.Empty<StockBatch>()));
        Assert.Equal("", Gtin.MakerCode(null));
    }

    [Fact]
    public void In_store_numbers_pass_the_check_digit_but_are_the_shops_own()
    {
        Assert.True(Gtin.IsValid("2000000000060"));
        Assert.True(Gtin.IsInStore("2000000000060"));
        Assert.True(Gtin.IsInStore("401234567893")); // UPC-A starting with 4
        Assert.True(Gtin.IsInStore("20123451")); // EAN-8 starting with 2
        Assert.True(Gtin.IsInStore("01234565")); // EAN-8 starting with 0
        Assert.True(Gtin.IsInStore("0412345678903")); // EAN-13 around an in-store UPC
        Assert.False(Gtin.IsInStore("4006381333931"));
        Assert.False(Gtin.IsInStore("123"));
    }
}

public class ListingExportTests
{
    private static ProductListing Listing()
    {
        var listing = ProductListing.Parse("""
            { "display_name": "Sunflower Oil 1 L Bottle, Light Cooking Oil",
              "amazon": { "bullets": ["Light oil: for everyday cooking.", "Easy grip: pours cleanly."],
              "description": "Golden sunflower oil.\n\nStore in a cool place.", "search_terms": "surajmukhi tel", "brand": "", "generic_name": "Sunflower Oil",
              "colour": "Golden", "material": "", "size": "1 L", "item_count": "1", "included": "1 bottle", "product_type": "Cooking oil" },
              "website": { "description": "Light oil.", "highlights": ["Light", "Easy grip"],
                "specifications": [{ "key": "Volume", "value": "1 L" }], "tags": ["sunflower oil", "cooking oil"], "category": "Oils & Ghee > Sunflower Oil" } }
            """)!;
        return ListingRules.Clean(listing).Listing;
    }

    private static readonly ListingFacts Facts = new("Sunflower Oil 1 L", "1006", 155m, 175m, "2000000000060", 4m);

    [Fact]
    public void The_amazon_text_has_every_part_and_the_pos_price_and_barcode()
    {
        var text = ListingExport.AmazonText(Listing(), Facts);

        Assert.StartsWith("AMAZON LISTING: Sunflower Oil 1 L (1006)\n\nTitle\nSunflower Oil 1 L Bottle, Light Cooking Oil\n\nBullet points\n- Light oil: for everyday cooking.\n- Easy grip: pours cleanly.\n\n", text);
        Assert.Contains("Product description\nGolden sunflower oil.\n\nStore in a cool place.\n\n", text);
        Assert.Contains("Search terms\nsurajmukhi tel\n\n", text);
        Assert.Contains("Brand: (not on the pack: fill in)\nGeneric name: Sunflower Oil\n", text);
        Assert.Contains("Price the customer pays: ₹155.00\nMRP: ₹175.00\n", text);
        Assert.EndsWith("Barcode: 2000000000060 (the shop's own code: Amazon asks for the maker's EAN barcode, or an exemption)\n", text);
        Assert.EndsWith("Barcode: 4006381333931 (EAN-13, the maker's barcode)\n",
            ListingExport.AmazonText(Listing(), Facts with { Barcode = "4006381333931" }));
        Assert.EndsWith("Barcode: none in the POS (Amazon asks for the maker's EAN barcode, or an exemption)\n",
            ListingExport.AmazonText(Listing(), Facts with { Barcode = "" }));
    }

    [Fact]
    public void The_website_file_has_the_fields_the_website_keeps_with_prices_from_the_pos()
    {
        var json = ListingExport.WebsiteJson(Listing(), Facts, new[] { "Sunflower Oil 1 L - 1 White background.png" });

        using var document = JsonDocument.Parse(json);
        var product = document.RootElement;
        // The one name, the same as Amazon's title; the POS keeps its own ("Sunflower Oil 1 L").
        Assert.Equal("Sunflower Oil 1 L Bottle, Light Cooking Oil", product.GetProperty("name").GetString());
        Assert.Equal(155m, product.GetProperty("price").GetDecimal());
        Assert.Equal(175m, product.GetProperty("originalPrice").GetDecimal());
        Assert.Equal("2000000000060", product.GetProperty("barcode").GetString());
        Assert.Equal(new[] { "Light", "Easy grip" }, product.GetProperty("highlights").EnumerateArray().Select(h => h.GetString()));
        Assert.Equal("Volume", product.GetProperty("specifications")[0].GetProperty("key").GetString());
        Assert.Equal("Oils & Ghee > Sunflower Oil", product.GetProperty("category").GetString());
        Assert.Equal("Sunflower Oil 1 L - 1 White background.png", product.GetProperty("images")[0].GetString());

        // No MRP above the price: no original price. No barcode in the POS: none, never the product's code.
        using var plain = JsonDocument.Parse(ListingExport.WebsiteJson(Listing(), Facts with { Mrp = 155m, Barcode = "" }, Array.Empty<string>()));
        Assert.False(plain.RootElement.TryGetProperty("originalPrice", out _));
        Assert.False(plain.RootElement.TryGetProperty("barcode", out _));
    }

    [Fact]
    public void Files_are_named_for_people_and_windows()
    {
        Assert.Equal("Sunflower Oil 1 L - Amazon listing.txt", ListingExport.FileName("Sunflower Oil 1 L", "Amazon listing.txt"));
        Assert.Equal("Oil 1 L 5 L - website listing.json", ListingExport.FileName("Oil 1 L / 5 L", "website listing.json"));
        Assert.Equal("Product - Amazon listing.txt", ListingExport.FileName("  ", "Amazon listing.txt"));
    }

    [Fact]
    public void Copying_the_website_tab_gives_every_part_and_the_price()
    {
        var text = ListingExport.WebsiteText(Listing(), Facts);

        Assert.StartsWith("Name\nSunflower Oil 1 L Bottle, Light Cooking Oil\n\nDescription\nLight oil.\n\nHighlights\n- Light\n- Easy grip\n\nSpecifications\nVolume: 1 L\n\n", text);
        Assert.EndsWith("Tags\nsunflower oil, cooking oil\n\nCategory\nOils & Ghee > Sunflower Oil\n\nPrice: ₹155.00 (MRP ₹175.00)\n", text);
    }
}

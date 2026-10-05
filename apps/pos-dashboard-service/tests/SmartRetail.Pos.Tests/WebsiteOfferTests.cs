using System.Text.Json;
using SmartRetail.AI.Products;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>A finished product as the shop PC offers it to the owner's website: the listing's words, the POS's prices, the photos and a
/// category of the website; and when it is not offered yet, why.</summary>
public class WebsiteOfferTests
{
    private static readonly DateTime Now = new(2026, 10, 4, 11, 0, 0);

    private static readonly SiteCategoryList Categories = SiteCategoryList.Parse(
        "[{\"id\":\"c-groc\",\"name\":\"Grocery\"},{\"id\":\"c-oils\",\"name\":\"Oils\",\"parentId\":\"c-groc\"},{\"id\":\"c-home\",\"name\":\"Home & Kitchen\"}]");

    private static ListingFacts Facts(decimal price = 160m, decimal mrp = 175m, string barcode = "8901234567890") =>
        new("Sunflower Oil 1 L (POS)", "1006", price, mrp, barcode, 40m);

    private static ProductPhotoInfo Finished(string? category = "c-oils", Action<ProductPhotoInfo>? change = null)
    {
        var set = new PhotoSet { Id = "set-1", Started = Now.AddDays(-1) };
        foreach (var kind in PhotoKinds.All)
        {
            set.Images.Add(new ProductPhotoImage { Kind = kind, File = kind.FilePrefix() + "-20261003-100000.png", Made = Now });
        }

        var info = new ProductPhotoInfo
        {
            ProductId = 1006,
            Code = "1006",
            Name = "Sunflower Oil 1 L (POS)",
            Sets = { set },
            Listing = new ProductListing
            {
                DisplayName = "Sunflower Oil, 1 Litre",
                SetId = "set-1",
                Website = new WebsiteListing
                {
                    Name = "Sunflower Oil, 1 Litre",
                    Description = "  Light, golden cooking oil for everyday cooking.  ",
                    Highlights = { "Light on the stomach", " ", "Good for frying" },
                    Specifications = { new ListingSpec { Key = " Volume ", Value = " 1 L " }, new ListingSpec { Key = "", Value = "x" } },
                    Tags = { "oil", "cooking", " " },
                    Category = "Grocery > Oils",
                },
            },
        };
        if (category is not null)
        {
            info.WebsiteCategory = WebsiteCategoryChoice.Of(Categories, category, WebsiteCategoryChoice.ByAi, Now);
        }

        change?.Invoke(info);
        return info;
    }

    private static string? Path(string name) => "/photos/" + name;

    private static OfferResult Build(ProductPhotoInfo info, ListingFacts? facts = null, SiteCategoryList? categories = null, Func<string, string?>? pathOf = null) =>
        WebsiteOffers.Build(info, facts ?? Facts(), categories ?? Categories, pathOf ?? Path);

    [Fact]
    public void A_finished_product_is_offered_with_the_listings_words_the_POS_prices_and_its_place_on_the_website()
    {
        var offer = Build(Finished()).Offer!;
        var data = offer.Data;

        Assert.Equal(1006, offer.ProductId);
        Assert.Equal("1006", offer.Key);
        Assert.Equal(("Sunflower Oil, 1 Litre", "Light, golden cooking oil for everyday cooking."), (data.Name, data.Description));
        Assert.Equal((160m, (decimal?)175m, "8901234567890"), (data.Price, data.OriginalPrice, data.Barcode));
        Assert.Equal(new[] { "Light on the stomach", "Good for frying" }, data.Highlights);
        Assert.Equal(new[] { new OfferSpec("Volume", "1 L") }, data.Specifications);
        Assert.Equal(new[] { "oil", "cooking" }, data.Tags);
        Assert.Equal(("c-groc", "c-oils", "Grocery › Oils"), (data.CategoryId, data.SubcategoryId, data.CategoryPath));
        Assert.Equal(("Sunflower Oil 1 L (POS)", "1006"), (data.PosName, data.Code));
    }

    [Fact]
    public void The_five_photos_go_in_the_order_they_are_made_and_the_kinds_are_the_ones_the_waiting_list_knows()
    {
        var offer = Build(Finished()).Offer!;

        Assert.Equal(new[] { "white", "in-use", "european-model", "indian-model", "east-asian-model" }, offer.Kinds);
        Assert.Equal("/photos/white-20261003-100000.png", offer.Photos[0].Path);
        Assert.All(offer.Photos, photo => Assert.Equal(photo.Kind.FilePrefix() + "-20261003-100000.png", photo.File));
    }

    [Fact]
    public void A_photo_skipped_or_missing_is_left_out_but_the_white_background_one_is_needed()
    {
        var offer = Build(Finished(change: info => info.LatestSet!.Images.RemoveAll(image => image.Kind == PhotoKind.IndianModel))).Offer!;
        Assert.Equal(new[] { "white", "in-use", "european-model", "east-asian-model" }, offer.Kinds);

        var noFile = Build(Finished(), pathOf: name => name.StartsWith("white") ? null : Path(name));
        Assert.Null(noFile.Offer);
        Assert.Equal("A photo file is missing from the product's folder.", noFile.Why);

        var noWhite = Build(Finished(change: info => info.LatestSet!.Images.RemoveAll(image => image.Kind == PhotoKind.WhiteBackground)));
        Assert.Equal("It has no white-background photo.", noWhite.Why);
    }

    [Fact]
    public void The_MRP_is_sent_only_when_it_is_above_the_price_and_the_barcode_only_when_there_is_one()
    {
        var same = Build(Finished(), Facts(mrp: 160m)).Offer!.Data;
        var below = Build(Finished(), Facts(mrp: 100m)).Offer!.Data;
        var none = Build(Finished(), Facts(mrp: 0m, barcode: "")).Offer!.Data;

        Assert.Null(same.OriginalPrice);
        Assert.Null(below.OriginalPrice);
        Assert.Equal((null, null), (none.OriginalPrice, none.Barcode));
    }

    [Fact]
    public void Only_these_things_leave_the_PC_in_the_offer_no_stock_cost_customer_or_bill()
    {
        var json = JsonSerializer.Serialize(WebsiteOffers.DataOf(Build(Finished()).Offer!));
        using var document = JsonDocument.Parse(json);
        var names = new HashSet<string>();
        void Collect(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in element.EnumerateObject())
                {
                    names.Add(property.Name);
                    Collect(property.Value);
                }
            }
            else if (element.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in element.EnumerateArray())
                {
                    Collect(item);
                }
            }
        }

        Collect(document.RootElement);

        // Every property the waiting list gets; a new one must be added here on purpose, after asking what it could reveal.
        Assert.Empty(names.Except(new[]
        {
            "name", "description", "price", "originalPrice", "highlights", "specifications", "key", "value", "tags",
            "categoryId", "subcategoryId", "categoryPath", "barcode", "posName", "code",
        }));
        Assert.Contains("\"price\":160", json);
        Assert.Contains("\"originalPrice\":175", json);
    }

    [Fact]
    public void A_new_price_changes_the_words_fingerprint_and_not_the_photos_a_new_photo_the_other_way_round()
    {
        var first = Build(Finished()).Offer!;
        var again = Build(Finished()).Offer!;
        var dearer = Build(Finished(), Facts(price: 170m)).Offer!;
        var remade = Build(Finished(change: info => info.LatestSet!.Images[1].File = "in-use-20261004-090000.png")).Offer!;

        Assert.Equal((first.Version, first.PhotosVersion), (again.Version, again.PhotosVersion));
        Assert.Matches("^[0-9a-f]{32}$", first.Version);
        Assert.Matches("^[0-9a-f]{32}$", first.PhotosVersion);
        Assert.NotEqual(first.Version, dearer.Version);
        Assert.Equal(first.PhotosVersion, dearer.PhotosVersion);
        Assert.Equal(first.Version, remade.Version);
        Assert.NotEqual(first.PhotosVersion, remade.PhotosVersion);
    }

    [Fact]
    public void The_same_amount_is_always_the_same_text_whatever_its_scale()
    {
        var a = Build(Finished(), Facts(price: 160m, mrp: 175m)).Offer!;
        var b = Build(Finished(), Facts(price: 160.00m, mrp: 175.0m)).Offer!;
        var c = Build(Finished(), Facts(price: 160.001m, mrp: 174.999m)).Offer!;

        Assert.Equal(a.Version, b.Version);
        Assert.Equal(a.Version, c.Version); // rounded to paise
        Assert.NotEqual(a.Version, Build(Finished(), Facts(price: 160.4m)).Offer!.Version);
    }

    [Fact]
    public void The_name_on_the_website_is_the_listings_one_name_and_the_POS_name_is_sent_only_to_say_which_product_it_is()
    {
        var data = Build(Finished()).Offer!.Data;

        Assert.Equal("Sunflower Oil, 1 Litre", data.Name);
        Assert.Equal("Sunflower Oil 1 L (POS)", data.PosName);
    }

    [Theory]
    [InlineData("none", "It has no photos yet.")]
    [InlineData("problem", "Its photos stopped: continue them first.")]
    [InlineData("pending", "Its photos are still being made.")]
    [InlineData("white", "It has no white-background photo.")]
    [InlineData("writing", "Its listing is still being written.")]
    [InlineData("nolisting", "It has no listing for the website yet.")]
    [InlineData("failed", "Its listing could not be written: write it again first.")]
    [InlineData("empty", "It has no listing for the website yet.")]
    public void A_product_that_is_not_finished_says_why(string what, string why)
    {
        var info = Finished(change: info =>
        {
            switch (what)
            {
                case "none": info.Sets.Clear(); break;
                case "problem": info.LatestSet!.Problem = "Codex stopped."; break;
                case "pending": info.LatestSet!.Pending.Add(PhotoKind.IndianModel); break;
                case "white": info.LatestSet!.Images.RemoveAll(image => image.Kind == PhotoKind.WhiteBackground); break;
                case "writing": info.ListingPending = true; break;
                case "nolisting": info.Listing = null; break;
                case "failed": info.Listing = null; info.ListingProblem = "Codex stopped."; break;
                case "empty": info.Listing!.Website.Description = "  "; break;
            }
        });

        Assert.Equal(why, WebsiteOffers.NotFinished(info));
        Assert.Equal((null, why), (Build(info).Offer, Build(info).Why));
        Assert.Null(WebsiteOffers.NotFinished(Finished()));
    }

    [Fact]
    public void A_finished_product_still_waits_for_a_price_and_a_category_of_the_website()
    {
        Assert.Equal("The POS has no selling price for it.", Build(Finished(), Facts(price: 0m)).Why);
        Assert.Equal("Your website's categories have not reached this PC yet.", Build(Finished(), categories: SiteCategoryList.Empty).Why);
        Assert.Equal("It needs a category of your website.", Build(Finished(category: null)).Why);

        // The website's list changed since the category was chosen: Oils is gone.
        var changed = SiteCategoryList.Parse("[{\"id\":\"c-groc\",\"name\":\"Grocery\"}]");
        Assert.Equal("Its category is not on your website any more.", Build(Finished(), categories: changed).Why);
        Assert.NotNull(Build(Finished(category: "c-groc"), categories: changed).Offer);
    }
}

using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using SmartRetail.AI.Products;

namespace SmartRetail.Pos.Web.Services;

/// <summary>One line of a product's specifications, e.g. "Material: Plastic".</summary>
public sealed record OfferSpec(string Key, string Value);

/// <summary>
/// What the shop PC tells the owner's website about a finished product, in the fields the website's products have: the listing's
/// words, the price the customer pays and the MRP from the POS (never an AI's), the barcode from the stock, and the website
/// category chosen from the website's own list. Nothing about customers, bills or stock quantities. The owner approves it on
/// the website before anything is published there.
/// </summary>
/// <param name="CategoryId">The website's main category.</param>
/// <param name="SubcategoryId">A subcategory of it, or null.</param>
/// <param name="CategoryPath">Where that is, e.g. "Grocery › Oils", for the owner to read.</param>
/// <param name="PosName">What the POS calls the product (the website shows <paramref name="Name"/>), so the owner knows which one it is.</param>
/// <param name="Code">The product's code in the POS.</param>
public sealed record WebsiteProductData(
    string Name,
    string Description,
    decimal Price,
    decimal? OriginalPrice,
    IReadOnlyList<string> Highlights,
    IReadOnlyList<OfferSpec> Specifications,
    IReadOnlyList<string> Tags,
    string CategoryId,
    string? SubcategoryId,
    string CategoryPath,
    string? Barcode,
    string PosName,
    string Code);

/// <summary>A photo to offer: which of the five, its file name in the product's folder, and the file.</summary>
public sealed record OfferPhoto(PhotoKind Kind, string File, string Path);

/// <summary>
/// A product ready to be offered to the website. <see cref="Version"/> is a fingerprint of the words and prices and
/// <see cref="PhotosVersion"/> of the photos, so the shop PC sends again only what changed: a new price sends no photo.
/// </summary>
public sealed record WebsiteOffer(int ProductId, WebsiteProductData Data, string Version, string PhotosVersion, IReadOnlyList<OfferPhoto> Photos)
{
    public string Key => ProductId.ToString(CultureInfo.InvariantCulture);

    /// <summary>The photos' kinds as the waiting list names them, in the order they are made in.</summary>
    public IReadOnlyList<string> Kinds => Photos.Select(photo => WebsiteOffers.KindName(photo.Kind)).ToList();
}

/// <summary>A finished product's offer, or why there is none yet (in words for the owner).</summary>
public sealed record OfferResult(WebsiteOffer? Offer, string? Why);

public static class WebsiteOffers
{
    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web)
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    /// <summary>The photo's kind as the waiting list names it: "white", "in-use", "european-model"…</summary>
    public static string KindName(PhotoKind kind) => kind.FilePrefix();

    /// <summary>
    /// Why a product is not finished, in words for the owner; null when its photos and listing are all made. The photos of the newest
    /// set are made and none is waiting or stopped, one of them is the white-background photo, and the listing is written.
    /// </summary>
    public static string? NotFinished(ProductPhotoInfo info)
    {
        ArgumentNullException.ThrowIfNull(info);
        if (info.LatestSet is not { } set)
        {
            return "It has no photos yet.";
        }

        if (set.Problem is not null)
        {
            return "Its photos stopped: continue them first.";
        }

        if (set.Pending.Count > 0)
        {
            return "Its photos are still being made.";
        }

        if (set.Latest(PhotoKind.WhiteBackground) is null)
        {
            return "It has no white-background photo.";
        }

        if (info.ListingPending)
        {
            return "Its listing is still being written.";
        }

        if (info.Listing is not { } listing || listing.IsEmpty || string.IsNullOrWhiteSpace(listing.Website?.Description))
        {
            return info.ListingProblem is not null ? "Its listing could not be written: write it again first." : "It has no listing for the website yet.";
        }

        return null;
    }

    /// <summary>
    /// The offer for a finished product, or why there is none: not finished, no price in the POS, or no category of the website
    /// chosen yet (a product on the website needs one). <paramref name="pathOf"/> gives a photo's file for its name, or null.
    /// </summary>
    public static OfferResult Build(ProductPhotoInfo info, ListingFacts facts, SiteCategoryList categories, Func<string, string?> pathOf)
    {
        ArgumentNullException.ThrowIfNull(info);
        ArgumentNullException.ThrowIfNull(facts);
        ArgumentNullException.ThrowIfNull(categories);
        ArgumentNullException.ThrowIfNull(pathOf);
        if (NotFinished(info) is { } unfinished)
        {
            return Not(unfinished);
        }

        var set = info.LatestSet!;
        var photos = new List<OfferPhoto>();
        foreach (var kind in PhotoKinds.All)
        {
            if (set.Latest(kind) is { } image && pathOf(image.File) is { } path)
            {
                photos.Add(new OfferPhoto(kind, image.File, path));
            }
        }

        if (!photos.Any(photo => photo.Kind == PhotoKind.WhiteBackground))
        {
            return Not("A photo file is missing from the product's folder.");
        }

        if (facts.Price <= 0)
        {
            return Not("The POS has no selling price for it.");
        }

        if (categories.IsEmpty)
        {
            return Not("Your website's categories have not reached this PC yet.");
        }

        if (info.WebsiteCategory is not { } choice)
        {
            return Not("It needs a category of your website.");
        }

        if (!choice.IsValidIn(categories))
        {
            return Not("Its category is not on your website any more.");
        }

        var listing = info.Listing!;
        var website = listing.Website;
        var data = new WebsiteProductData(
            listing.PublicName,
            website.Description.Trim(),
            Plain(facts.Price),
            facts.Mrp > facts.Price ? Plain(facts.Mrp) : null,
            website.Highlights.Where(h => !string.IsNullOrWhiteSpace(h)).Select(h => h.Trim()).ToList(),
            website.Specifications.Where(s => !string.IsNullOrWhiteSpace(s.Key)).Select(s => new OfferSpec(s.Key.Trim(), s.Value.Trim())).ToList(),
            website.Tags.Where(t => !string.IsNullOrWhiteSpace(t)).Select(t => t.Trim()).ToList(),
            choice.CategoryId,
            choice.SubcategoryId.Length > 0 ? choice.SubcategoryId : null,
            categories.PathOf(choice.CategoryId, choice.SubcategoryId),
            facts.Barcode.Length > 0 ? facts.Barcode : null,
            facts.Name,
            facts.Code);
        return new OfferResult(new WebsiteOffer(info.ProductId, data, Fingerprint(JsonSerializer.Serialize(data, Json)),
            Fingerprint(string.Join('\n', photos.Select(photo => KindName(photo.Kind) + ":" + photo.File))), photos), null);
    }

    /// <summary>The offer's words as the waiting list takes them (an object).</summary>
    public static JsonElement DataOf(WebsiteOffer offer) => JsonSerializer.SerializeToElement(offer.Data, Json);

    private static OfferResult Not(string why) => new(null, why);

    /// <summary>The same amount always written the same way: 349, 349.5, 349.99.</summary>
    private static decimal Plain(decimal amount) => Math.Round(amount, 2, MidpointRounding.AwayFromZero) / 1.0000000000000000000000000000m;

    /// <summary>32 letters and digits that change when the text does.</summary>
    private static string Fingerprint(string text) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(text))).ToLowerInvariant()[..32];
}

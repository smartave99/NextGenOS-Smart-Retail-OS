using SmartRetail.AI.Products;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public sealed class GoogleLensTests
{
    private static readonly DateTime Day = new(2026, 10, 3, 9, 0, 0);

    private static ProductPhotoInfo Product(params PhotoSet[] sets) => new() { ProductId = 6, Name = "Sunflower Oil 1 L", Sets = sets.ToList() };

    private static PhotoSet Set(string[] raws, params (PhotoKind Kind, string File, int Minute)[] made) => new()
    {
        Id = "set",
        RawFiles = raws.ToList(),
        Images = made.Select(m => new ProductPhotoImage { Kind = m.Kind, File = m.File, Made = Day.AddMinutes(m.Minute) }).ToList(),
    };

    [Fact]
    public void The_page_is_the_dashboards_own_with_the_photo_named_only_when_one_is_picked()
    {
        Assert.Equal("lens/6", GoogleLens.PageUrl(6));
        Assert.Equal("lens/6?photo=raw-20261003-090000.jpg", GoogleLens.PageUrl(6, "raw-20261003-090000.jpg"));
        Assert.Equal("lens/6?photo=a%20b%26c.jpg", GoogleLens.PageUrl(6, "a b&c.jpg"));
        Assert.Equal("lens/6", GoogleLens.PageUrl(6, ""));
    }

    [Fact]
    public void The_newest_phone_photo_is_searched_first_because_it_shows_the_real_packaging()
    {
        var info = Product(
            Set(new[] { "raw-20261003-090000.jpg", "raw-20261003-090001.jpg" }, (PhotoKind.WhiteBackground, "white-20261003-090500.png", 5)),
            Set(new[] { "raw-20260901-090000.jpg" }));

        Assert.Equal("raw-20261003-090000.jpg", GoogleLens.BestPhoto(info));
    }

    [Fact]
    public void Without_a_phone_photo_the_white_background_one_is_used_else_any_made_photo()
    {
        var onlyMade = Product(Set(Array.Empty<string>(),
            (PhotoKind.InUse, "in-use-20261003-090700.png", 7),
            (PhotoKind.WhiteBackground, "white-20261003-090500.png", 5)));
        Assert.Equal("white-20261003-090500.png", GoogleLens.BestPhoto(onlyMade));

        var noWhite = Product(Set(Array.Empty<string>(), (PhotoKind.InUse, "in-use-20261003-090700.png", 7)));
        Assert.Equal("in-use-20261003-090700.png", GoogleLens.BestPhoto(noWhite));
    }

    [Fact]
    public void A_product_without_a_photo_has_nothing_to_search_with()
    {
        Assert.Null(GoogleLens.BestPhoto(null));
        Assert.Null(GoogleLens.BestPhoto(Product()));
        Assert.Null(GoogleLens.BestPhoto(Product(Set(Array.Empty<string>()))));
    }

    [Fact]
    public void A_name_that_is_not_a_photo_the_store_made_is_never_chosen()
    {
        var info = Product(Set(new[] { "../../secret.jpg", "notes.txt" }, (PhotoKind.WhiteBackground, "..\\white.png", 1)));

        Assert.Null(GoogleLens.BestPhoto(info));
    }

    [Fact]
    public void The_page_sends_the_photo_to_Google_as_a_form_and_holds_only_what_it_is_given()
    {
        var page = GoogleLens.Html("Sunflower Oil 1 L", "/product-photos/6/raw-20261003-090000.jpg");

        Assert.Contains("data-upload=\"https://lens.google.com/v3/upload\"", page);
        Assert.Contains("input.name = 'encoded_image'", page);
        Assert.Contains("form.enctype = 'multipart/form-data'", page);
        Assert.Contains("data-photo=\"/product-photos/6/raw-20261003-090000.jpg\"", page);
        Assert.Contains("data-side=\"1600\"", page);
        Assert.Contains("<title>Google Lens · Sunflower Oil 1 L</title>", page);
        Assert.Contains("https://www.google.com/imghp", page);
        Assert.DoesNotContain("{{", page);

        // The photo is drawn again at a smaller size (which drops the place and camera details a phone puts in it).
        Assert.Contains("createImageBitmap(blob, { imageOrientation: 'from-image' })", page);
        Assert.Contains("canvas.toBlob", page);
        Assert.DoesNotContain("exif", page, StringComparison.OrdinalIgnoreCase);
    }

    [Theory]
    [InlineData("<script>alert(1)</script>")]
    [InlineData("\"><img src=x onerror=alert(1)>")]
    [InlineData("Tom & Jerry's {{PHOTO}} {{UPLOAD}}")]
    public void A_product_name_cannot_break_out_of_the_page(string name)
    {
        var page = GoogleLens.Html(name, "/product-photos/6/raw-20261003-090000.jpg");

        Assert.DoesNotContain("<script>alert(1)", page);
        Assert.DoesNotContain("<img src=x", page);
        Assert.DoesNotContain("\"><img", page);

        // Only the script that is part of the page runs: one script element.
        Assert.Single(System.Text.RegularExpressions.Regex.Matches(page, "<script", System.Text.RegularExpressions.RegexOptions.IgnoreCase));

        // A name that looks like a marker is not filled in a second time: the photo and the address stay what they were.
        Assert.Contains("data-upload=\"https://lens.google.com/v3/upload\"", page);
        Assert.Contains("data-photo=\"/product-photos/6/raw-20261003-090000.jpg\"", page);
    }

    [Fact]
    public void Text_in_a_name_that_looks_like_a_marker_is_shown_as_it_is_and_not_filled_in()
    {
        var page = GoogleLens.Html("Tom & Jerry's {{PHOTO}} {{UPLOAD}}", "/product-photos/6/raw-20261003-090000.jpg");

        Assert.Contains("<title>Google Lens · Tom &amp; Jerry&#39;s {{PHOTO}} {{UPLOAD}}</title>", page);
    }

    [Fact]
    public void The_page_for_a_product_without_a_photo_says_so_and_points_to_the_photos_page()
    {
        var page = GoogleLens.NoPhotoHtml("<b>Oil</b>", 6);

        Assert.Contains("No photo to search with", page);
        Assert.Contains("&lt;b&gt;Oil&lt;/b&gt; has no photo yet", page);
        Assert.DoesNotContain("<b>Oil</b>", page);
        Assert.Contains("href=\"/photos/6\"", page);
        Assert.DoesNotContain("<script", page);
    }
}

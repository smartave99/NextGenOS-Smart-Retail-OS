using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;

namespace NextGenOS.Hub.Tests;

/// <summary>Merge, products tools: pictures of items (the older POS's product images, study 02 A2.10): a few small pictures, the kind found from the file itself, the first shown on the till.</summary>
public class ItemImageTests
{
    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static Item Goods(HubFixture f, string name = "Rice") => f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = 10_000, TaxClass = "zero" });

    private static byte[] Png(int extra = 0) => new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }.Concat(new byte[extra + 8]).ToArray();

    private static byte[] Jpeg() => new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0, 0x10, (byte)'J', (byte)'F', (byte)'I', (byte)'F' };

    [Fact]
    public void The_kind_of_picture_comes_from_the_file_and_nothing_else_is_accepted()
    {
        Assert.Equal("image/png", ImageService.Sniff(Png()));
        Assert.Equal("image/jpeg", ImageService.Sniff(Jpeg()));
        Assert.Equal("image/webp", ImageService.Sniff("RIFF\0\0\0\0WEBPVP8 "u8));
        Assert.Equal("image/gif", ImageService.Sniff("GIF89a\0\0"u8));
        Assert.Null(ImageService.Sniff("<svg xmlns=\"http://www.w3.org/2000/svg\"><script>alert(1)</script></svg>"u8));   // a vector picture can carry a script
        Assert.Null(ImageService.Sniff("<html><script>alert(1)</script></html>"u8));
        Assert.Null(ImageService.Sniff("MZ\x90\0\x03\0\0\0"u8));
        Assert.Null(ImageService.Sniff(ReadOnlySpan<byte>.Empty));
    }

    [Fact]
    public void A_picture_is_kept_with_its_item_read_back_as_it_went_in_and_the_first_is_the_one_for_the_till()
    {
        using var f = Shop();
        var rice = Goods(f);
        var tea = Goods(f, "Tea");

        var first = f.App.Images.Add(rice.Id, Png(), null);
        var second = f.App.Images.Add(rice.Id, Jpeg(), null);

        Assert.Equal(new[] { first.Id, second.Id }, f.App.Images.ForItem(rice.Id).Select(i => i.Id).ToArray());
        var got = f.App.Images.Get(second.Id)!.Value;
        Assert.Equal("image/jpeg", got.ContentType);
        Assert.Equal(Jpeg(), got.Data);
        var tiles = f.App.Images.FirstFor(new[] { rice.Id, tea.Id });
        Assert.Equal(first.Id, tiles[rice.Id]);
        Assert.False(tiles.ContainsKey(tea.Id));   // no picture: left out

        f.App.Images.MakeFirst(second.Id);
        Assert.Equal(second.Id, f.App.Images.FirstFor(new[] { rice.Id })[rice.Id]);
        Assert.Equal(second.Id, f.App.Images.ForItem(rice.Id)[0].Id);

        f.App.Images.Remove(second.Id);
        Assert.Equal(first.Id, f.App.Images.FirstFor(new[] { rice.Id })[rice.Id]);
        Assert.Null(f.App.Images.Get(second.Id));
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Images.Remove(second.Id)).Code);
    }

    [Fact]
    public void A_picture_that_is_too_big_the_wrong_kind_empty_or_one_too_many_is_refused_in_plain_words()
    {
        using var f = Shop();
        var rice = Goods(f);

        Assert.Equal("image-big", Assert.Throws<HubException>(() => f.App.Images.Add(rice.Id, Png(ImageService.MaxBytes), null)).Code);
        Assert.Equal("image-type", Assert.Throws<HubException>(() => f.App.Images.Add(rice.Id, "<svg onload=alert(1)>"u8.ToArray(), null)).Code);
        Assert.Equal("image-empty", Assert.Throws<HubException>(() => f.App.Images.Add(rice.Id, Array.Empty<byte>(), null)).Code);
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Images.Add(9_999, Png(), null)).Code);
        for (var i = 0; i < ImageService.MaxPerItem; i++) f.App.Images.Add(rice.Id, Png(i), null);
        var many = Assert.Throws<HubException>(() => f.App.Images.Add(rice.Id, Png(), null));
        Assert.Equal("image-many", many.Code);
        Assert.Contains("Take one away first", many.Message);
        Assert.Equal(ImageService.MaxPerItem, f.App.Images.ForItem(rice.Id).Count);
    }

    [Fact]
    public void Changing_an_item_leaves_its_pictures_alone()
    {
        using var f = Shop();
        var rice = Goods(f);
        var picture = f.App.Images.Add(rice.Id, Png(), null);

        f.App.Catalog.Update(rice.Id, new ItemInput { Kind = "stock", Name = "Basmati rice", PriceMinor = 12_000, TaxClass = "zero" });

        Assert.Equal(picture.Id, f.App.Images.ForItem(rice.Id).Single().Id);
    }
}

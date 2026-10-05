using SmartRetail.Pos.Core.Posters;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>Posters kept in the data folder: they come back as saved, and only names the store makes are read or served.</summary>
public sealed class PosterStoreTests : IDisposable
{
    private readonly string _data = Path.Combine(Path.GetTempPath(), "srpos-poster-store-" + Guid.NewGuid().ToString("N"));

    private PosterStore Store => new(() => _data);

    private static Poster Sample(string id = "20260926-121500-clearance") => new()
    {
        Id = id,
        Kind = PosterKind.Clearance,
        Made = new DateTime(2026, 9, 26, 12, 15, 0),
        ShopName = "Demo Store",
        Words = new PosterWords("Clearance sale", "भारी छूट", "While stock lasts"),
        ValidFrom = new DateOnly(2026, 9, 26),
        ValidTill = new DateOnly(2026, 10, 2),
        Items = new[]
        {
            new PosterItem { ProductId = 23, Code = "1023", Name = "Notebook 172 pages", Price = 55m, LowestOffer = 39m, OfferPrice = 47m },
            new PosterItem { ProductId = 24, Code = "1024", Name = "Ball Pen, pack of 5", Price = 45m, LowestOffer = 32m, Photo = "white-20260920-100100.png" },
        },
        PickedBy = "Codex CLI (OpenAI)",
    };

    public void Dispose()
    {
        if (Directory.Exists(_data))
        {
            Directory.Delete(_data, recursive: true);
        }
    }

    [Fact]
    public void A_poster_comes_back_as_saved()
    {
        Store.Save(Sample());

        var loaded = Store.Load("20260926-121500-clearance")!;

        Assert.Equal(PosterKind.Clearance, loaded.Kind);
        Assert.Equal(new PosterWords("Clearance sale", "भारी छूट", "While stock lasts"), loaded.Words);
        Assert.Equal(new DateOnly(2026, 10, 2), loaded.ValidTill);
        Assert.Equal(Sample().Items, loaded.Items);
        Assert.True(File.Exists(Path.Combine(_data, "Posters", "20260926-121500-clearance", "poster.json")));
        Assert.DoesNotContain("HasOffer", File.ReadAllText(Path.Combine(_data, "Posters", "20260926-121500-clearance", "poster.json")));
    }

    [Fact]
    public void A_poster_saved_by_an_earlier_version_still_opens_when_a_field_it_holds_is_gone()
    {
        // Earlier versions also wrote "PricesIncludeGst": true, which nothing read.
        Store.Save(Sample());
        var file = Path.Combine(_data, "Posters", "20260926-121500-clearance", "poster.json");
        File.WriteAllText(file, File.ReadAllText(file).Replace("\"Items\":", "\"PricesIncludeGst\": true,\n  \"Items\":"));
        Assert.Contains("PricesIncludeGst", File.ReadAllText(file));

        var loaded = Store.Load("20260926-121500-clearance")!;

        Assert.Equal(PosterKind.Clearance, loaded.Kind);
        Assert.Equal(2, loaded.Items.Count);
    }

    [Fact]
    public void Offers_are_checked_again_when_a_poster_is_read()
    {
        // Someone edited poster.json by hand: the notebook's offer below its lowest allowed price is dropped.
        Store.Save(Sample() with { Items = new[] { Sample().Items[0] with { OfferPrice = 30m } } });

        Assert.Null(Store.Load("20260926-121500-clearance")!.Items[0].OfferPrice);
    }

    [Fact]
    public void The_newest_posters_come_first()
    {
        Store.Save(Sample("20260925-090000-best-sellers") with { Kind = PosterKind.BestSellers });
        Store.Save(Sample());
        Directory.CreateDirectory(Path.Combine(_data, "Posters", "not a poster"));

        Assert.Equal(new[] { "20260926-121500-clearance", "20260925-090000-best-sellers" }, Store.Recent().Select(p => p.Id));
    }

    [Fact]
    public void New_artwork_replaces_the_old_and_only_its_own_names_are_served()
    {
        var store = Store;
        store.Save(Sample());
        var first = store.SaveArtwork("20260926-121500-clearance", new byte[] { 1 }, new DateTime(2026, 9, 26, 12, 16, 0));
        var second = store.SaveArtwork("20260926-121500-clearance", new byte[] { 2 }, new DateTime(2026, 9, 26, 12, 20, 0))!;

        Assert.Equal("artwork-20260926-122000.png", second);
        Assert.Null(store.ArtworkPath("20260926-121500-clearance", first));
        Assert.NotNull(store.ArtworkPath("20260926-121500-clearance", second));
        Assert.Null(store.ArtworkPath("20260926-121500-clearance", "poster.json"));
        Assert.Null(store.ArtworkPath("../20260926-121500-clearance", second));
        Assert.Null(store.ArtworkPath("20260926-121500-clearance", "../../settings.json"));
        Assert.Throws<ArgumentException>(() => store.Save(Sample("../outside")));
        Assert.Null(store.Load("..\\outside"));
    }

    [Fact]
    public void Artwork_for_a_poster_deleted_meanwhile_is_not_kept()
    {
        var store = Store;
        store.Save(Sample());
        store.Delete("20260926-121500-clearance");

        Assert.Null(store.SaveArtwork("20260926-121500-clearance", new byte[] { 1 }, new DateTime(2026, 9, 26, 12, 20, 0)));
        Assert.False(Directory.Exists(Path.Combine(_data, "Posters", "20260926-121500-clearance")));
    }

    [Fact]
    public void Updates_keep_the_posters_own_id_and_deleting_removes_its_folder()
    {
        var store = Store;
        store.Save(Sample());

        var changed = store.Update("20260926-121500-clearance", p => p with { Id = "20990101-000000-clearance", ShopName = "Sharma Store" })!;

        Assert.Equal(("20260926-121500-clearance", "Sharma Store"), (changed.Id, changed.ShopName));
        Assert.True(store.Delete("20260926-121500-clearance"));
        Assert.Empty(store.Recent());
        Assert.False(store.Delete("20260926-121500-clearance"));
    }
}

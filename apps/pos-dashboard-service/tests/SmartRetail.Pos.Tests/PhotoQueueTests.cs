using SmartRetail.AI.Products;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public sealed class PhotoQueueTests : IDisposable
{
    private static readonly DateTime Day = new(2026, 10, 3, 9, 0, 0);

    /// <summary>The first bytes of a PNG: all the store needs to keep a photo.</summary>
    private static readonly byte[] Png = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0, 0, 0, 13, 0x49, 0x48, 0x44, 0x52, 0, 0, 4, 0, 0, 0, 3, 0 };

    private readonly string _root = Directory.CreateTempSubdirectory("photo-queue-").FullName;
    private readonly ProductPhotoStore _store;

    public PhotoQueueTests() => _store = new ProductPhotoStore(Path.Combine(_root, "Product photos"));

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private void Start(int id, string name, bool listing = false)
    {
        using var raw = new MemoryStream(new byte[] { 1, 2, 3 });
        var file = _store.SaveRaw(id, raw, ".jpg", Day, name);
        _store.StartSet(id, "C" + id, name, "", new[] { file }, Day);
        if (listing)
        {
            _store.QueueListing(id);
        }
    }

    [Fact]
    public void Nothing_is_made_and_nothing_waits_gives_an_empty_queue()
    {
        var queue = ProductPhotoService.Describe(_store, null, Array.Empty<int>());

        Assert.True(queue.IsEmpty);
        Assert.Equal(0, queue.PhotosLeft);
        Assert.Same(PhotoQueue.Empty, queue);
    }

    [Fact]
    public void The_queue_names_the_photo_being_made_what_comes_next_for_it_and_the_products_waiting()
    {
        Start(6, "Sunflower Oil 1 L", listing: true);
        Start(1, "Basmati Rice 5 kg");
        Start(4, "Sugar 1 kg");
        // The white photo and the one in use are made; the in-use photo of the oil is made now.
        var set = _store.Load(6)!.LatestSet!;
        _store.SaveImage(6, set.Id, PhotoKind.WhiteBackground, new ProductPhotoResult { Image = Png }, Day);
        var now = new PhotoWork(6, set.Id, PhotoKind.InUse, Day.AddMinutes(2));

        var queue = ProductPhotoService.Describe(_store, now, new[] { 1, 4 });

        Assert.Same(now, queue.Now);
        Assert.Equal("Sunflower Oil 1 L", queue.NowName);
        Assert.Equal(new[] { PhotoKind.EuropeanModel, PhotoKind.IndianModel, PhotoKind.EastAsianModel }, queue.NextKinds);
        Assert.True(queue.ListingNext);
        Assert.Equal(new[] { new QueuedProduct(1, "Basmati Rice 5 kg", 5, false), new QueuedProduct(4, "Sugar 1 kg", 5, false) }, queue.Waiting);
        Assert.False(queue.IsEmpty);

        // One being made, three after it, and two products of five.
        Assert.Equal(1 + 3 + 10, queue.PhotosLeft);
    }

    [Fact]
    public void While_the_listings_are_written_every_pending_photo_is_still_to_come()
    {
        Start(6, "Sunflower Oil 1 L", listing: true);
        var set = _store.Load(6)!.LatestSet!;
        var now = new PhotoWork(6, set.Id, PhotoKind.WhiteBackground, Day, isListing: true);

        var queue = ProductPhotoService.Describe(_store, now, Array.Empty<int>());

        Assert.Equal(PhotoKinds.All, queue.NextKinds);
        Assert.False(queue.ListingNext, "the listings are being written now, not next");
        Assert.Equal(5, queue.PhotosLeft);
    }

    [Fact]
    public void A_product_without_a_name_or_that_is_gone_is_still_told_and_skipped_respectively()
    {
        Start(9, "");
        var queue = ProductPhotoService.Describe(_store, null, new[] { 9, 777 });

        Assert.Equal(new[] { new QueuedProduct(9, "Product 9", 5, false) }, queue.Waiting);
        Assert.Null(queue.Now);
        Assert.False(queue.IsEmpty);
    }
}

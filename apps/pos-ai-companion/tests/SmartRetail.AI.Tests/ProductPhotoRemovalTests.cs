using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Products;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Removing a phone photo added by mistake, or the whole set, also while the AI is making the photos from it.</summary>
    public class ProductPhotoRemovalTests : IDisposable
    {
        private const int Bottle = 1193;

        private readonly TempFolder _temp = new TempFolder();
        private readonly List<ProductPhotoRequest> _requests = new List<ProductPhotoRequest>();
        private readonly ProductPhotoStore _store;
        private DateTime _now = new DateTime(2026, 9, 24, 10, 0, 0);

        public ProductPhotoRemovalTests()
        {
            _store = new ProductPhotoStore(Path.Combine(_temp.Path, "Product photos"));
        }

        public void Dispose() => _temp.Dispose();

        private string Raw(string content)
        {
            using (var photo = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content)))
            {
                _now = _now.AddSeconds(1);
                return _store.SaveRaw(Bottle, photo, ".jpg", _now, "Pink Bottle 750 ml");
            }
        }

        /// <summary>Stands in for Codex: records each request, lets the test act while the photo is being made, then makes it.</summary>
        private ProductPhotoMaker Maker(Func<ProductPhotoRequest, CancellationToken, Task> before = null, Func<ProductListingRequest, CancellationToken, Task> beforeListing = null)
        {
            return new ProductPhotoMaker(
                _store,
                async (request, ct) =>
                {
                    _requests.Add(request);
                    if (before != null)
                    {
                        await before(request, ct);
                    }

                    _now = _now.AddMinutes(1);
                    return new ProductPhotoResult
                    {
                        Image = ProductPhotoTests.Png,
                        Understanding = request.Describe ? ProductUnderstanding.Parse(ProductPhotoTests.Answer) : null,
                        ProviderName = "Codex CLI (OpenAI)",
                    };
                },
                () => _now,
                beforeListing == null
                    ? (Func<ProductListingRequest, CancellationToken, Task<ProductListingResult>>)null
                    : async (request, ct) =>
                    {
                        await beforeListing(request, ct);
                        return new ProductListingResult { Listing = ProductListing.Parse(ProductListingTests.Answer), ProviderName = "Codex CLI (OpenAI)" };
                    });
        }

        [Fact]
        public void A_phone_photo_is_deleted_and_the_set_goes_on_with_the_others_but_never_loses_its_last_one()
        {
            var front = Raw("front");
            var wrong = Raw("wrong product");
            var set = _store.StartSet(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { front, wrong }, _now);

            Assert.False(_store.RemoveRaw(Bottle, set.Id, "raw-20200101-000000.jpg"), "not one of the set's photos");
            Assert.False(_store.RemoveRaw(Bottle, "no-such-set", wrong));

            Assert.True(_store.RemoveRaw(Bottle, set.Id, wrong));
            Assert.Null(_store.PathOf(Bottle, wrong));
            Assert.NotNull(_store.PathOf(Bottle, front));
            Assert.Equal(new[] { front }, _store.Load(Bottle).LatestSet.RawFiles);

            var only = Assert.Throws<InvalidOperationException>(() => _store.RemoveRaw(Bottle, set.Id, front));
            Assert.Equal("It is the only phone photo of this set: remove the whole set instead.", only.Message);
            Assert.NotNull(_store.PathOf(Bottle, front));
        }

        [Fact]
        public async Task A_set_is_deleted_with_its_photos_and_what_the_AI_made_from_it_but_the_older_set_and_the_owners_listing_stay()
        {
            // An older set, then a newer one the AI made photos, a description and a listing from.
            var oldRaw = Raw("old");
            var older = _store.StartSet(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { oldRaw }, _now);
            var maker = Maker(beforeListing: (request, ct) => Task.CompletedTask);
            var wrong = Raw("wrong product");
            var set = maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { wrong });
            await maker.MakeNextAsync(CancellationToken.None);
            var made = _store.Load(Bottle).LatestSet.Images.Select(image => image.File).ToList();
            Assert.Equal(5, made.Count);
            Assert.NotNull(_store.Load(Bottle).Understanding);
            Assert.Equal(set.Id, _store.Load(Bottle).Listing.SetId);
            Assert.Equal(set.Id, _store.Load(Bottle).UnderstandingSetId);

            maker.RemoveSet(Bottle, set.Id);

            var info = _store.Load(Bottle);
            Assert.Equal(new[] { older.Id }, info.Sets.Select(s => s.Id));
            Assert.Null(_store.PathOf(Bottle, wrong));
            Assert.All(made, file => Assert.Null(_store.PathOf(Bottle, file)));
            Assert.NotNull(_store.PathOf(Bottle, oldRaw));
            Assert.Null(info.Understanding);
            Assert.Equal("", info.UnderstandingSetId);
            Assert.Null(info.Listing);
            Assert.False(info.ListingPending);
            Assert.Equal(older.Id, info.LatestSet.Id);

            // What the owner made theirs is kept: a listing they changed stays when its set goes.
            var second = Raw("second");
            var again = maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { second });
            await maker.MakeNextAsync(CancellationToken.None);
            var edited = _store.Load(Bottle).Listing.Copy();
            edited.Amazon.Brand = "Milton";
            _store.EditListing(Bottle, edited, _now);

            maker.RemoveSet(Bottle, again.Id);

            Assert.Equal("Milton", _store.Load(Bottle).Listing.Amazon.Brand);
            Assert.Throws<InvalidOperationException>(() => maker.RemoveSet(Bottle, again.Id));
        }

        [Fact]
        public async Task A_phone_photo_removed_while_a_photo_is_made_from_it_starts_that_photo_again_from_the_others()
        {
            var front = Raw("front");
            var wrong = Raw("wrong product");
            ProductPhotoMaker maker = null;
            var removed = false;
            maker = Maker(async (request, ct) =>
            {
                if (request.Kind == PhotoKind.InUse && !removed)
                {
                    removed = true;
                    maker.RemoveRaw(Bottle, wrong);
                    await Task.Delay(Timeout.Infinite, ct);
                }
            });
            maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { front, wrong });

            await maker.MakeNextAsync(CancellationToken.None);

            var set = _store.Load(Bottle).LatestSet;
            Assert.Null(set.Problem);
            Assert.Empty(set.Pending);
            Assert.Equal(PhotoKinds.All.Count, set.MadeCount);
            Assert.Equal(new[] { front }, set.RawFiles);
            Assert.Null(_store.PathOf(Bottle, wrong));
            var inUse = _requests.Where(request => request.Kind == PhotoKind.InUse).ToList();
            Assert.Equal(2, inUse.Count);
            Assert.Equal(2, inUse[0].RawPhotos.Count);
            Assert.Equal(new[] { _store.PathOf(Bottle, front) }, inUse[1].RawPhotos);
            Assert.True(maker.IsIdle);
        }

        [Fact]
        public async Task A_photo_that_finished_from_a_phone_photo_removed_meanwhile_is_made_again_keeping_the_earlier_one()
        {
            var front = Raw("front");
            var wrong = Raw("wrong product");
            ProductPhotoMaker maker = null;
            var removed = false;
            maker = Maker((request, ct) =>
            {
                if (request.Kind == PhotoKind.InUse && !removed)
                {
                    // The removal comes while the photo is being made; the photo finishes anyway.
                    removed = true;
                    maker.RemoveRaw(Bottle, wrong);
                }

                return Task.CompletedTask;
            });
            maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { front, wrong });

            await maker.MakeNextAsync(CancellationToken.None);

            var set = _store.Load(Bottle).LatestSet;
            Assert.Null(set.Problem);
            Assert.Empty(set.Pending);
            Assert.Equal(2, _requests.Count(request => request.Kind == PhotoKind.InUse));
            Assert.Equal(2, set.Images.Count(image => image.Kind == PhotoKind.InUse));
            Assert.Equal(new[] { _store.PathOf(Bottle, front) }, _requests.Last(request => request.Kind == PhotoKind.InUse).RawPhotos);
        }

        [Fact]
        public async Task A_phone_photo_removed_while_the_listing_is_written_from_it_writes_the_listing_again_from_the_others()
        {
            var front = Raw("front");
            var wrong = Raw("wrong product");
            ProductPhotoMaker maker = null;
            var removed = false;
            var written = new List<ProductListingRequest>();
            maker = Maker(beforeListing: async (request, ct) =>
            {
                written.Add(request);
                if (!removed)
                {
                    removed = true;
                    maker.RemoveRaw(Bottle, wrong);
                    await Task.Delay(Timeout.Infinite, ct);
                }
            });
            maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { front, wrong });

            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(2, written.Count);
            Assert.Equal(2, written[0].RawPhotos.Count);
            Assert.Equal(new[] { _store.PathOf(Bottle, front) }, written[1].RawPhotos);
            var info = _store.Load(Bottle);
            Assert.NotNull(info.Listing);
            Assert.Null(info.ListingProblem);
            Assert.False(info.ListingPending);
            Assert.Equal(PhotoKinds.All.Count, info.LatestSet.MadeCount);
        }

        [Fact]
        public async Task A_set_removed_while_a_photo_is_made_stops_the_work_on_it_without_a_problem_and_drops_the_photo()
        {
            var wrong = Raw("wrong product");
            ProductPhotoMaker maker = null;
            PhotoSet set = null;
            maker = Maker(async (request, ct) =>
            {
                if (request.Kind == PhotoKind.InUse)
                {
                    maker.RemoveSet(Bottle, set.Id);
                    await Task.Delay(Timeout.Infinite, ct);
                }
            });
            set = maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { wrong });

            await maker.MakeNextAsync(CancellationToken.None);

            var info = _store.Load(Bottle);
            Assert.Empty(info.Sets);
            Assert.Null(info.Understanding);
            Assert.Null(_store.PathOf(Bottle, wrong));
            Assert.Equal(new[] { PhotoKind.WhiteBackground, PhotoKind.InUse }, _requests.Select(request => request.Kind));
            Assert.Equal(new[] { "product.json" }, Directory.EnumerateFiles(_store.FolderOf(Bottle)).Select(Path.GetFileName));
            Assert.Empty(_store.Resumable());
            Assert.True(maker.IsIdle);
        }

        [Fact]
        public void Removing_what_is_not_there_says_so()
        {
            var maker = Maker();
            Assert.Equal("This product has no photos.", Assert.Throws<InvalidOperationException>(() => maker.RemoveRaw(Bottle, "raw-20260924-100001.jpg")).Message);

            var front = Raw("front");
            var back = Raw("back");
            maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "", new[] { front, back });

            Assert.Equal("That photo is not in the newest set any more.", Assert.Throws<InvalidOperationException>(() => maker.RemoveRaw(Bottle, "raw-20200101-000000.jpg")).Message);
            Assert.Equal("That set of photos is not there any more.", Assert.Throws<InvalidOperationException>(() => maker.RemoveSet(Bottle, "20200101-000000")).Message);
        }
    }
}

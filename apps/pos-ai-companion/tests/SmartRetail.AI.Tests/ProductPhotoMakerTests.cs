using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class ProductPhotoMakerTests : IDisposable
    {
        private const int Bottle = 1193;

        private readonly TempFolder _temp = new TempFolder();
        private readonly List<ProductPhotoRequest> _requests = new List<ProductPhotoRequest>();
        private readonly ProductPhotoStore _store;
        private DateTime _now = new DateTime(2026, 9, 24, 10, 0, 0);

        public ProductPhotoMakerTests()
        {
            _store = new ProductPhotoStore(Path.Combine(_temp.Path, "Product photos"));
        }

        public void Dispose() => _temp.Dispose();

        /// <summary>Stands in for Codex: records each request and makes a PNG, with the description for the white photo.</summary>
        private Func<ProductPhotoRequest, CancellationToken, Task<ProductPhotoResult>> Makes(Func<ProductPhotoRequest, CancellationToken, Task> before = null) =>
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
            };

        private ProductPhotoMaker Maker(Func<ProductPhotoRequest, CancellationToken, Task<ProductPhotoResult>> make) =>
            new ProductPhotoMaker(_store, make, () => _now);

        private string Raw(string content = "raw")
        {
            using (var photo = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content)))
            {
                return _store.SaveRaw(Bottle, photo, ".jpg", _now, "Pink Bottle 750 ml");
            }
        }

        [Fact]
        public async Task The_five_photos_are_made_in_order_one_by_one_from_one_upload()
        {
            var changes = new List<int>();
            var maker = Maker(Makes());
            maker.Changed += changes.Add;

            var set = maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "GENERAL", new[] { Raw("front"), Raw("back") });
            Assert.Equal(1, maker.PlaceInQueue(Bottle));
            Assert.True(await maker.MakeNextAsync(CancellationToken.None));

            Assert.Equal(PhotoKinds.All, _requests.Select(r => r.Kind));
            Assert.All(_requests, r => Assert.Equal(2, r.RawPhotos.Count));
            Assert.Null(_requests[0].CataloguePhoto);
            Assert.Null(_requests[0].Understanding);
            var white = _store.Load(Bottle).LatestSet.Latest(PhotoKind.WhiteBackground);
            Assert.All(_requests.Skip(1), r =>
            {
                Assert.Equal(_store.PathOf(Bottle, white.File), r.CataloguePhoto);
                Assert.Equal("a woman in her early 30s", r.Understanding.ModelPerson);
            });

            var info = _store.Load(Bottle);
            Assert.Equal(set.Id, info.LatestSet.Id);
            Assert.Empty(info.LatestSet.Pending);
            Assert.Equal(5, info.LatestSet.MadeCount);
            Assert.Equal("white-20260924-100100.png", white.File);
            Assert.Equal("east-asian-model-20260924-100500.png", info.LatestSet.Latest(PhotoKind.EastAsianModel).File);
            Assert.Equal("a pink plastic water bottle with a flip-top lid", info.Understanding.WhatItIs);
            Assert.Equal(white.File, info.Thumbnail);
            Assert.Equal(Path.Combine(_store.Root, "1193 Pink Bottle 750 ml"), _store.FolderOf(Bottle));
            Assert.Null(maker.Current);
            Assert.True(maker.IsIdle);
            Assert.True(changes.Count >= 6 && changes.All(id => id == Bottle));
            Assert.False(await maker.MakeNextAsync(CancellationToken.None));
        }

        [Fact]
        public async Task A_failure_stops_the_set_until_it_is_continued_or_the_photo_is_skipped()
        {
            var refuse = new HashSet<PhotoKind> { PhotoKind.InUse };
            var maker = Maker(Makes((request, ct) => refuse.Contains(request.Kind)
                ? throw new AiProviderException("codex-cli", "Codex is not signed in.")
                : Task.CompletedTask));
            maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });

            await maker.MakeNextAsync(CancellationToken.None);

            var set = _store.Load(Bottle).LatestSet;
            Assert.Equal("Codex is not signed in.", set.Problem);
            Assert.Equal(new[] { PhotoKind.InUse, PhotoKind.EuropeanModel, PhotoKind.IndianModel, PhotoKind.EastAsianModel }, set.Pending);
            Assert.Empty(_store.Resumable());

            maker.Continue(Bottle);
            await maker.MakeNextAsync(CancellationToken.None);
            Assert.Equal("Codex is not signed in.", _store.Load(Bottle).LatestSet.Problem);

            maker.Skip(Bottle, PhotoKind.InUse);
            await maker.MakeNextAsync(CancellationToken.None);
            set = _store.Load(Bottle).LatestSet;
            Assert.Null(set.Problem);
            Assert.Empty(set.Pending);
            Assert.Equal(4, set.MadeCount);
            Assert.Null(set.Latest(PhotoKind.InUse));

            refuse.Clear();
            maker.MakeAgain(Bottle, PhotoKind.InUse);
            await maker.MakeNextAsync(CancellationToken.None);
            Assert.Equal(5, _store.Load(Bottle).LatestSet.MadeCount);
        }

        [Fact]
        public async Task Stop_cancels_the_photo_being_made_and_keeps_the_rest_waiting()
        {
            ProductPhotoMaker maker = null;
            maker = Maker(Makes(async (request, ct) =>
            {
                Assert.Equal(request.Kind, maker.Current.Kind);
                maker.Stop(Bottle);
                await Task.Delay(Timeout.Infinite, ct);
            }));
            maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });

            await maker.MakeNextAsync(CancellationToken.None);

            var set = _store.Load(Bottle).LatestSet;
            Assert.Equal("Stopped.", set.Problem);
            Assert.Equal(PhotoKinds.All, set.Pending);
            Assert.Empty(_store.Resumable());
            Assert.True(maker.IsIdle);
        }

        [Fact]
        public async Task Photos_left_when_the_app_closed_are_made_after_the_next_start()
        {
            using (var closing = new CancellationTokenSource())
            {
                var first = Maker(Makes((request, ct) =>
                {
                    if (request.Kind == PhotoKind.EuropeanModel)
                    {
                        closing.Cancel();
                        ct.ThrowIfCancellationRequested();
                    }

                    return Task.CompletedTask;
                }));
                first.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });
                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => first.MakeNextAsync(closing.Token));
            }

            var left = _store.Load(Bottle).LatestSet;
            Assert.Null(left.Problem);
            Assert.Equal(new[] { PhotoKind.EuropeanModel, PhotoKind.IndianModel, PhotoKind.EastAsianModel }, left.Pending);
            Assert.Equal(new[] { Bottle }, _store.Resumable());

            _requests.Clear();
            var next = Maker(Makes());
            next.ResumeAll();
            await next.MakeNextAsync(CancellationToken.None);

            Assert.Equal(new[] { PhotoKind.EuropeanModel, PhotoKind.IndianModel, PhotoKind.EastAsianModel }, _requests.Select(r => r.Kind));
            Assert.Equal(5, _store.Load(Bottle).LatestSet.MadeCount);
        }

        [Fact]
        public async Task New_phone_photos_take_over_from_photos_still_waiting_for_older_ones()
        {
            ProductPhotoMaker maker = null;
            string newer = null;
            maker = Maker(Makes((request, ct) =>
            {
                if (request.Kind == PhotoKind.InUse && newer == null)
                {
                    // More photos arrive while the first set is being made.
                    newer = maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw("closer") }).Id;
                }

                return Task.CompletedTask;
            }));
            var older = maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw("far") }).Id;
            _now = _now.AddSeconds(1);

            await maker.MakeNextAsync(CancellationToken.None);

            var info = _store.Load(Bottle);
            Assert.Equal(new[] { newer, older }, info.Sets.Select(s => s.Id));
            Assert.Equal(5, info.Sets[0].MadeCount);
            Assert.Equal(2, info.Sets[1].MadeCount);
            Assert.Empty(info.Sets[1].Pending);
            Assert.Equal(7, _requests.Count);
        }

        [Fact]
        public void The_store_keeps_its_files_in_folders_named_for_people()
        {
            Assert.Equal("7 a b c name", ProductPhotoStore.FolderNameOf(7, "a/b:c*?\"<>|  name. "));
            Assert.Equal("7", ProductPhotoStore.FolderNameOf(7, " ... "));
            Assert.Equal(64, ProductPhotoStore.FolderNameOf(123, new string('x', 200)).Length);

            // A folder named by id alone, as older versions made, is still found.
            Directory.CreateDirectory(Path.Combine(_store.Root, "42"));
            File.WriteAllBytes(Path.Combine(_store.Root, "42", "white-20260924-100000.png"), ProductPhotoTests.Png);
            Assert.NotNull(_store.PathOf(42, "white-20260924-100000.png"));
            Assert.Null(_store.PathOf(4, "white-20260924-100000.png"));
        }

        [Fact]
        public void Photos_are_saved_under_the_extension_their_bytes_need()
        {
            var set = _store.StartSet(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() }, _now);
            var jpeg = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0, 4, 0, 0, 0xFF, 0xD9, 0, 0 };

            var image = _store.SaveImage(Bottle, set.Id, PhotoKind.InUse, new ProductPhotoResult { Image = jpeg }, _now);

            Assert.Equal("in-use-20260924-100000.jpg", image.File);
            Assert.Equal(jpeg, File.ReadAllBytes(_store.PathOf(Bottle, image.File)));
            Assert.Throws<ArgumentException>(() => _store.StartSet(Bottle, "", "x", "", new[] { "../../settings.json" }, _now));
            Assert.Throws<ArgumentException>(() => _store.StartSet(Bottle, "", "x", "", new string[0], _now));
        }

        [Theory]
        [InlineData("../settings.json")]
        [InlineData("product.json")]
        [InlineData("white-20260924-100100.png/../../x")]
        [InlineData("white-2026092-100100.png")]
        [InlineData("clean-20260924-100100.png")]
        [InlineData("raw-20260924-100000.exe")]
        [InlineData(null)]
        public void Only_photo_names_the_store_made_can_be_read(string name)
        {
            Assert.False(ProductPhotoStore.IsPhotoFileName(name));
            Assert.Null(_store.PathOf(1, name));
            Assert.Throws<ArgumentException>(() => _store.SaveRaw(1, new MemoryStream(), ".exe", DateTime.Now));
        }
    }
}

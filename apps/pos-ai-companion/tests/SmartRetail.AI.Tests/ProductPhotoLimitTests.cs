using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// When Codex's usage limit is reached nothing has failed: the photos and listings still to be made wait for the time Codex gave and
    /// then carry on from the photo they stopped at, without anyone pressing Continue.
    /// </summary>
    public class ProductPhotoLimitTests : IDisposable
    {
        private const int Bottle = 1193;

        private const string ListingAnswer = @"{""amazon"":{""title"":""Pink Water Bottle 750 ml"",""bullets"":[""Easy carry: a flip-top lid.""],""description"":""A pink bottle."",""search_terms"":""flask""},
            ""website"":{""name"":""Pink Water Bottle"",""description"":""A pink bottle."",""highlights"":[""Flip-top lid""]}}";

        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeTime _time = new FakeTime();
        private readonly ProductPhotoStore _store;
        private readonly UsageLimitPause _pause;
        private readonly List<string> _work = new List<string>();
        private readonly List<int> _changed = new List<int>();

        public ProductPhotoLimitTests()
        {
            _store = new ProductPhotoStore(Path.Combine(_temp.Path, "Product photos"));
            _pause = new UsageLimitPause(_time.Clock, _time.Delay);
        }

        public void Dispose() => _temp.Dispose();

        private DateTime LocalNow => _time.Now.DateTime;

        private AiProviderException Limit(DateTimeOffset? resetsAt = null) =>
            new AiProviderException("codex-cli", "Codex has reached its usage limit. It can answer again at 7:33 PM.", canFallback: true,
                usageLimit: new UsageLimitInfo("Codex has reached its usage limit. It can answer again at 7:33 PM.", resetsAt ?? _time.Now.AddHours(2)));

        /// <summary>A maker whose photos and listings are made by these steps; a step that throws makes that run fail.</summary>
        private ProductPhotoMaker Maker(Action<ProductPhotoRequest> photo = null, Action<ProductListingRequest> listing = null, bool withPause = true)
        {
            var maker = new ProductPhotoMaker(
                _store,
                (request, ct) =>
                {
                    _work.Add(request.Kind.FilePrefix());
                    photo?.Invoke(request);
                    return Task.FromResult(new ProductPhotoResult
                    {
                        Image = ProductPhotoTests.Png,
                        Understanding = request.Describe ? ProductUnderstanding.Parse(ProductPhotoTests.Answer) : null,
                        ProviderName = "Codex CLI (OpenAI)",
                    });
                },
                () => LocalNow,
                (request, ct) =>
                {
                    _work.Add("listing");
                    listing?.Invoke(request);
                    return Task.FromResult(new ProductListingResult { Listing = ProductListing.Parse(ListingAnswer), ProviderName = "Codex CLI (OpenAI)" });
                },
                pause: withPause ? _pause : null);
            maker.Changed += id =>
            {
                lock (_changed)
                {
                    _changed.Add(id);
                }
            };
            return maker;
        }

        private string Raw()
        {
            using (var photo = new MemoryStream(Encoding.UTF8.GetBytes("raw")))
            {
                return _store.SaveRaw(Bottle, photo, ".jpg", LocalNow, "Pink Bottle 750 ml");
            }
        }

        private PhotoSet StartSet(ProductPhotoMaker maker) => maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "GENERAL", new[] { Raw() });

        [Fact]
        public async Task A_photo_that_meets_the_usage_limit_is_not_lost_and_is_made_when_the_limit_lifts_from_where_it_stopped()
        {
            var refuse = true;
            var maker = Maker(photo: request =>
            {
                if (request.Kind == PhotoKind.InUse && refuse)
                {
                    throw Limit();
                }
            });
            StartSet(maker);

            await maker.MakeNextAsync(CancellationToken.None);

            // The white photo and the listing came; the second photo met the limit. Nothing failed: no problem, nothing lost.
            var set = _store.Load(Bottle).LatestSet;
            Assert.Null(set.Problem);
            Assert.Equal(new[] { PhotoKind.InUse, PhotoKind.EuropeanModel, PhotoKind.IndianModel, PhotoKind.EastAsianModel }, set.Pending);
            Assert.Equal(1, set.MadeCount);
            Assert.Equal(new[] { "white", "listing", "in-use" }, _work);
            Assert.True(maker.IsPaused);
            Assert.True(_pause.IsPaused);
            Assert.Equal(new[] { Bottle }, maker.Waiting());
            Assert.False(maker.IsIdle, "the work still waits: a data folder move must not begin");
            Assert.Null(maker.Current);

            // The limit lifts: the same photo is made, then the rest.
            refuse = false;
            _time.Advance(TimeSpan.FromHours(2) + UsageLimitPause.Margin);
            Assert.False(maker.IsPaused);
            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(new[] { "white", "listing", "in-use", "in-use", "european-model", "indian-model", "east-asian-model" }, _work);
            Assert.Equal(5, _store.Load(Bottle).LatestSet.MadeCount);
            Assert.Empty(_store.Load(Bottle).LatestSet.Pending);
            Assert.True(maker.IsIdle);
        }

        [Fact]
        public async Task The_work_goes_on_by_itself_when_the_time_comes_without_anyone_continuing_it()
        {
            var refuse = true;
            var maker = Maker(photo: request =>
            {
                if (request.Kind == PhotoKind.WhiteBackground && refuse)
                {
                    throw Limit();
                }
            });
            using (var stop = new CancellationTokenSource())
            {
                var run = maker.RunAsync(stop.Token);
                StartSet(maker);

                await Until(() => maker.IsPaused);
                Assert.Equal(new[] { "white" }, _work);

                // Time passes with nobody doing anything: the loop waits, then makes the photos.
                refuse = false;
                await Until(() => _time.Waiting > 0);
                _time.Advance(TimeSpan.FromHours(2) + UsageLimitPause.Margin);
                await Until(() => _store.Load(Bottle).LatestSet.MadeCount == 5);

                Assert.Null(_store.Load(Bottle).LatestSet.Problem);

                stop.Cancel();
                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => run);
            }
        }

        [Fact]
        public async Task While_the_limit_holds_no_other_product_is_tried()
        {
            var refuse = true;
            var maker = Maker(photo: request =>
            {
                if (refuse)
                {
                    throw Limit();
                }
            });
            using (var stop = new CancellationTokenSource())
            {
                var run = maker.RunAsync(stop.Token);
                StartSet(maker);
                using (var photo = new MemoryStream(Encoding.UTF8.GetBytes("other")))
                {
                    var other = _store.SaveRaw(Bottle + 1, photo, ".jpg", LocalNow, "Steel Lunch Box");
                    maker.Start(Bottle + 1, "SL-1", "Steel Lunch Box", "GENERAL", new[] { other });
                }

                await Until(() => maker.IsPaused);
                await Task.Delay(200);

                // One try was made, and nothing else while it waits.
                Assert.Equal(new[] { "white" }, _work);
                Assert.Equal(new[] { Bottle, Bottle + 1 }, maker.Waiting());

                refuse = false;
                await Until(() => _time.Waiting > 0);
                _time.Advance(TimeSpan.FromHours(2) + UsageLimitPause.Margin);
                await Until(() => _store.Load(Bottle).LatestSet.MadeCount == 5 && _store.Load(Bottle + 1).LatestSet.MadeCount == 5);

                stop.Cancel();
                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => run);
            }
        }

        [Fact]
        public async Task A_listing_that_meets_the_limit_waits_with_the_photos_and_is_written_when_it_lifts()
        {
            var refuse = true;
            var maker = Maker(listing: request =>
            {
                if (refuse)
                {
                    throw Limit();
                }
            });
            StartSet(maker);

            await maker.MakeNextAsync(CancellationToken.None);

            var info = _store.Load(Bottle);
            Assert.Null(info.ListingProblem);
            Assert.True(info.ListingPending, "the listing is still to be written");
            Assert.Null(info.Listing);
            Assert.Equal(4, info.LatestSet.Pending.Count);
            Assert.True(maker.IsPaused);

            refuse = false;
            _pause.Clear();
            await maker.MakeNextAsync(CancellationToken.None);

            info = _store.Load(Bottle);
            Assert.NotNull(info.Listing);
            Assert.False(info.ListingPending);
            Assert.Equal(5, info.LatestSet.MadeCount);
            Assert.Equal(new[] { "white", "listing", "listing", "in-use", "european-model", "indian-model", "east-asian-model" }, _work);
        }

        [Fact]
        public async Task When_another_job_met_the_limit_between_two_photos_no_photo_is_asked_for_until_it_lifts()
        {
            var maker = Maker(photo: request =>
            {
                // Something else that uses Codex (a creative) meets the limit while the second photo is made.
                if (request.Kind == PhotoKind.InUse)
                {
                    _pause.Hit(new UsageLimitInfo("Codex has reached its usage limit.", _time.Now.AddHours(1)));
                }
            });
            StartSet(maker);

            await maker.MakeNextAsync(CancellationToken.None);

            // Photos 1 and 2 were made; photo 3 was not even asked for.
            Assert.Equal(new[] { "white", "listing", "in-use" }, _work);
            Assert.Equal(2, _store.Load(Bottle).LatestSet.MadeCount);
            Assert.Null(_store.Load(Bottle).LatestSet.Problem);
            Assert.Equal(new[] { Bottle }, maker.Waiting());
            Assert.True(maker.IsPaused);

            _time.Advance(TimeSpan.FromHours(1) + UsageLimitPause.Margin);
            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(5, _store.Load(Bottle).LatestSet.MadeCount);
            Assert.Equal(new[] { "white", "listing", "in-use", "european-model", "indian-model", "east-asian-model" }, _work);
        }

        [Fact]
        public async Task A_second_limit_met_after_the_first_lifts_waits_again_for_the_new_time()
        {
            var attempts = 0;
            var maker = Maker(photo: request =>
            {
                if (request.Kind == PhotoKind.WhiteBackground && attempts++ < 2)
                {
                    throw Limit(_time.Now.AddHours(attempts == 1 ? 1 : 24));
                }
            });
            StartSet(maker);

            await maker.MakeNextAsync(CancellationToken.None);
            _time.Advance(TimeSpan.FromHours(1) + UsageLimitPause.Margin);
            await maker.MakeNextAsync(CancellationToken.None);

            // The weekly limit holds even though the hourly one lifted: the work waits again, and still has all five photos to make.
            Assert.True(maker.IsPaused);
            Assert.Equal(_time.Now.AddHours(24) + UsageLimitPause.Margin, _pause.Until);
            Assert.Equal(5, _store.Load(Bottle).LatestSet.Pending.Count);
            Assert.Null(_store.Load(Bottle).LatestSet.Problem);
        }

        [Fact]
        public async Task The_pages_are_told_when_the_work_waits_and_when_it_carries_on()
        {
            var refuse = true;
            var maker = Maker(photo: request =>
            {
                if (refuse)
                {
                    throw Limit();
                }
            });
            StartSet(maker);
            await maker.MakeNextAsync(CancellationToken.None);
            lock (_changed)
            {
                _changed.Clear();
            }

            _pause.Clear();

            lock (_changed)
            {
                Assert.Contains(Bottle, _changed);
            }
        }

        [Fact]
        public async Task Without_a_pause_the_limit_is_an_ordinary_failure_that_stops_the_set()
        {
            var maker = Maker(photo: request => throw Limit(), withPause: false);
            StartSet(maker);

            await maker.MakeNextAsync(CancellationToken.None);

            var set = _store.Load(Bottle).LatestSet;
            Assert.StartsWith("Codex has reached its usage limit.", set.Problem);
            Assert.Equal(5, set.Pending.Count);
            Assert.False(maker.IsPaused);
        }

        [Fact]
        public async Task Another_failure_still_stops_the_set_and_does_not_pause()
        {
            var maker = Maker(photo: request => throw new AiProviderException("codex-cli", "Codex is not signed in."));
            StartSet(maker);

            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal("Codex is not signed in.", _store.Load(Bottle).LatestSet.Problem);
            Assert.False(maker.IsPaused);
        }

        [Fact]
        public async Task Stop_ends_the_waiting_of_a_product_and_the_others_keep_theirs()
        {
            var maker = Maker(photo: request => throw Limit());
            StartSet(maker);
            await maker.MakeNextAsync(CancellationToken.None);
            Assert.Equal(new[] { Bottle }, maker.Waiting());

            maker.Stop(Bottle);

            Assert.Empty(maker.Waiting());
            Assert.Equal("Stopped.", _store.Load(Bottle).LatestSet.Problem);
        }

        [Fact]
        public async Task TryNow_stops_waiting_so_the_next_try_is_made_at_once()
        {
            var refuse = true;
            var maker = Maker(photo: request =>
            {
                if (refuse)
                {
                    throw Limit(_time.Now.AddDays(3));
                }
            });
            StartSet(maker);
            await maker.MakeNextAsync(CancellationToken.None);
            Assert.True(maker.IsPaused);

            refuse = false;
            maker.TryNow();
            Assert.False(maker.IsPaused);
            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(5, _store.Load(Bottle).LatestSet.MadeCount);
        }

        [Fact]
        public async Task A_set_an_earlier_version_stopped_on_the_limit_carries_on_by_itself_when_the_app_starts()
        {
            // Before the work waited by itself, a limit stopped the set with Codex's sentence, to be continued by hand.
            var first = Maker(photo: request =>
            {
                if (request.Kind == PhotoKind.InUse)
                {
                    throw Limit();
                }
            }, withPause: false);
            StartSet(first);
            await first.MakeNextAsync(CancellationToken.None);
            _store.StopListing(Bottle, "Codex has reached its usage limit. It can answer again later. For more now, see chatgpt.com/codex/settings/usage.");
            Assert.StartsWith("Codex has reached its usage limit.", _store.Load(Bottle).LatestSet.Problem);
            _work.Clear();

            var restarted = Maker();
            restarted.ResumeAll();

            Assert.Equal(new[] { Bottle }, restarted.Waiting());
            Assert.Null(_store.Load(Bottle).LatestSet.Problem);
            Assert.True(_store.Load(Bottle).ListingPending || _store.Load(Bottle).Listing != null);
            await restarted.MakeNextAsync(CancellationToken.None);
            Assert.Equal(5, _store.Load(Bottle).LatestSet.MadeCount);
            Assert.Equal("in-use", _work.First(item => item != "listing"));
        }

        [Fact]
        public async Task A_set_stopped_for_another_reason_is_left_for_the_owner_when_the_app_starts()
        {
            var first = Maker(photo: request => throw new AiProviderException("codex-cli", "Codex is not signed in."), withPause: false);
            StartSet(first);
            await first.MakeNextAsync(CancellationToken.None);

            var restarted = Maker();
            restarted.ResumeAll();

            Assert.Empty(restarted.Waiting());
            Assert.Equal("Codex is not signed in.", _store.Load(Bottle).LatestSet.Problem);
        }

        /// <summary>Waits (up to 10 seconds) until the condition holds, for work that goes on in the background.</summary>
        private static async Task Until(Func<bool> condition)
        {
            var give = DateTime.UtcNow.AddSeconds(10);
            while (!condition())
            {
                Assert.True(DateTime.UtcNow < give, "the work did not get there in time");
                await Task.Delay(10);
            }
        }
    }
}

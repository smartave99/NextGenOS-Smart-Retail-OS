using System.Net;
using System.Text.Json;
using SkiaSharp;
using SmartRetail.AI.Products;
using SmartRetail.Pos.Core.Owner;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>Offering the finished products to the owner's website: what is sent, what is left alone, and what stops a round.</summary>
public class WebsiteSenderTests
{
    private static readonly SiteCategoryList Categories = SiteCategoryList.Parse("[{\"id\":\"c-groc\",\"name\":\"Grocery\"},{\"id\":\"c-oils\",\"name\":\"Oils\",\"parentId\":\"c-groc\"}]");

    private static WebsiteOffer Offer(int id, decimal price = 160m, string photos = "a", params PhotoKind[] kinds)
    {
        kinds = kinds.Length == 0 ? new[] { PhotoKind.WhiteBackground, PhotoKind.InUse } : kinds;
        var data = new WebsiteProductData("Product " + id, "Good.", price, null, new[] { "h" }, Array.Empty<OfferSpec>(), new[] { "t" }, "c-groc", "c-oils", "Grocery › Oils", null, "POS " + id, id.ToString());
        return new WebsiteOffer(id, data, "v-" + id + "-" + price, "p-" + photos, kinds.Select(kind => new OfferPhoto(kind, kind.FilePrefix() + "-x.png", "/photos/" + id + "/" + kind.FilePrefix() + ".png")).ToList());
    }

    private static SiteProductState OnList(WebsiteOffer offer, string state = "waiting", string? version = null, string? photos = null) =>
        new(offer.Key, state, version ?? offer.Version, photos ?? offer.PhotosVersion, offer.Kinds, Array.Empty<string>());

    private static readonly PreparedPhoto Prepared = new("image/jpeg", "QUJD", 3, 1, 1);

    private static WebsiteSender Sender(FakeSite site, int perRound = WebsiteSender.PerRound) =>
        new(site, _ => Prepared, _ => new byte[] { 1 }, perRound);

    [Fact]
    public void What_the_list_does_not_have_as_it_is_gets_sent_and_what_it_has_is_left_alone()
    {
        var offer = Offer(1);

        Assert.Equal(OfferPlan.Send, WebsiteSender.Plan(offer, null));
        Assert.Equal(OfferPlan.UpToDate, WebsiteSender.Plan(offer, OnList(offer)));
        Assert.Equal(OfferPlan.UpToDate, WebsiteSender.Plan(offer, OnList(offer, "published")));
        Assert.Equal(OfferPlan.Send, WebsiteSender.Plan(offer, OnList(offer, "sending"))); // its photos are still on their way
        Assert.Equal(OfferPlan.Send, WebsiteSender.Plan(offer, OnList(offer, version: "old")));
        Assert.Equal(OfferPlan.Send, WebsiteSender.Plan(offer, OnList(offer, "published", photos: "old")));
        Assert.Equal(OfferPlan.Send, WebsiteSender.Plan(offer, OnList(offer with { Photos = offer.Photos.Take(1).ToList() })));
        Assert.Equal(OfferPlan.Declined, WebsiteSender.Plan(offer, OnList(offer, "declined")));
        Assert.Equal(OfferPlan.Declined, WebsiteSender.Plan(offer, OnList(offer, "declined", version: "old")));
    }

    [Fact]
    public async Task A_new_product_is_offered_and_then_the_photos_the_list_asks_for_are_sent_one_by_one()
    {
        var site = new FakeSite { Reply = (offer, again) => new SiteOfferReply("sending", new[] { "white", "in-use" }) };
        var offer = Offer(1);

        var round = await Sender(site).RunAsync(new[] { offer }, Array.Empty<SiteProductState>(), Array.Empty<string>(), default);

        Assert.Equal((1, 2, false, null), (round.Offered, round.Photos, round.ListFull, round.Problem));
        Assert.Equal(new[] { "offer 1 again=False", "photo 1 white p-a", "photo 1 in-use p-a" }, site.Calls);
    }

    [Fact]
    public async Task A_product_whose_price_changed_is_offered_again_without_a_photo_when_the_list_asks_for_none()
    {
        var site = new FakeSite { Reply = (offer, again) => new SiteOfferReply("waiting", Array.Empty<string>()) };
        var before = Offer(1, price: 160m);
        var now = Offer(1, price: 170m);

        var round = await Sender(site).RunAsync(new[] { now }, new[] { OnList(before, "published") }, Array.Empty<string>(), default);

        Assert.Equal((1, 0), (round.Offered, round.Photos));
        Assert.Equal(new[] { "offer 1 again=False" }, site.Calls);
    }

    [Fact]
    public async Task Products_the_list_has_as_they_are_or_the_owner_declined_cost_no_call_at_all()
    {
        var site = new FakeSite();
        var waiting = Offer(1);
        var published = Offer(2);
        var declined = Offer(3);

        var round = await Sender(site).RunAsync(new[] { waiting, published, declined },
            new[] { OnList(waiting), OnList(published, "published"), OnList(declined, "declined", version: "old") }, Array.Empty<string>(), default);

        Assert.Equal(0, round.Offered);
        Assert.Empty(site.Calls);
    }

    [Fact]
    public async Task A_round_offers_a_few_products_and_leaves_the_rest_for_the_next()
    {
        var site = new FakeSite { Reply = (offer, again) => new SiteOfferReply("waiting", Array.Empty<string>()) };

        var round = await Sender(site, perRound: 2).RunAsync(Enumerable.Range(1, 5).Select(id => Offer(id)).ToList(), Array.Empty<SiteProductState>(), Array.Empty<string>(), default);

        Assert.Equal(2, round.Offered);
        Assert.Equal(new[] { "offer 1 again=False", "offer 2 again=False" }, site.Calls);
    }

    [Fact]
    public async Task A_full_list_stops_the_round_without_a_problem_and_what_was_offered_before_stays_counted()
    {
        var site = new FakeSite { Reply = (offer, again) => offer.ProductId == 2 ? throw new OwnerViewException("The waiting list is full: decide on some of the products on the website, and more are sent.", listFull: true, refused: true) : new SiteOfferReply("waiting", Array.Empty<string>()) };

        var round = await Sender(site).RunAsync(new[] { Offer(1), Offer(2), Offer(3) }, Array.Empty<SiteProductState>(), Array.Empty<string>(), default);

        Assert.Equal((1, true, null), (round.Offered, round.ListFull, round.Problem));
        Assert.Equal(new[] { "offer 1 again=False", "offer 2 again=False" }, site.Calls);
    }

    [Fact]
    public async Task What_the_project_refuses_about_one_product_leaves_that_one_and_goes_on_with_the_others()
    {
        var site = new FakeSite { Reply = (offer, again) => offer.ProductId == 1 ? throw new OwnerViewException("The product is missing or too large.", refused: true) : new SiteOfferReply("waiting", Array.Empty<string>()) };

        var round = await Sender(site).RunAsync(new[] { Offer(1), Offer(2) }, Array.Empty<SiteProductState>(), Array.Empty<string>(), default);

        Assert.Equal((1, null), (round.Offered, round.Problem));
        Assert.Equal(new[] { 1 }, round.Failed);
    }

    [Fact]
    public async Task A_photo_that_cannot_be_read_leaves_that_product_for_later_and_the_others_go_on()
    {
        var site = new FakeSite { Reply = (offer, again) => new SiteOfferReply("sending", new[] { "white" }) };
        var sender = new WebsiteSender(site, bytes => bytes[0] == 9 ? throw new InvalidDataException("The photo could not be read.") : Prepared,
            path => new byte[] { (byte)(path.Contains("/1/") ? 9 : 1) });

        var round = await sender.RunAsync(new[] { Offer(1), Offer(2) }, Array.Empty<SiteProductState>(), Array.Empty<string>(), default);

        Assert.Equal((1, 1), (round.Offered, round.Photos));
        Assert.Equal(new[] { 1 }, round.Failed);
        Assert.Contains("photo 2 white p-a", site.Calls);
    }

    [Fact]
    public async Task A_missing_photo_file_is_the_same_the_product_is_left_for_later()
    {
        var site = new FakeSite { Reply = (offer, again) => new SiteOfferReply("sending", new[] { "white" }) };
        var sender = new WebsiteSender(site, _ => Prepared, _ => throw new FileNotFoundException("gone"));

        var round = await sender.RunAsync(new[] { Offer(1) }, Array.Empty<SiteProductState>(), Array.Empty<string>(), default);

        Assert.Equal(0, round.Offered);
        Assert.Equal(new[] { 1 }, round.Failed);
    }

    [Fact]
    public async Task A_list_that_asks_for_a_photo_the_product_does_not_have_is_not_believed()
    {
        var site = new FakeSite { Reply = (offer, again) => new SiteOfferReply("sending", new[] { "indian-model" }) };

        var round = await Sender(site).RunAsync(new[] { Offer(1) }, Array.Empty<SiteProductState>(), Array.Empty<string>(), default);

        Assert.Equal(new[] { 1 }, round.Failed);
        Assert.DoesNotContain(site.Calls, call => call.StartsWith("photo"));
    }

    [Fact]
    public async Task No_connection_stops_the_round_and_says_so_while_a_disconnected_PC_is_left_to_the_owner_view()
    {
        var offline = new FakeSite { Reply = (offer, again) => throw new OwnerViewException("Could not reach Supabase. Check the internet connection and the project URL.") };
        var round = await Sender(offline).RunAsync(new[] { Offer(1), Offer(2) }, Array.Empty<SiteProductState>(), Array.Empty<string>(), default);
        Assert.Equal((0, "Could not reach Supabase. Check the internet connection and the project URL."), (round.Offered, round.Problem));
        Assert.Single(offline.Calls);

        var gone = new FakeSite { Reply = (offer, again) => throw new OwnerViewException("This PC was disconnected on the website.", disconnected: true) };
        await Assert.ThrowsAsync<OwnerViewException>(() => Sender(gone).RunAsync(new[] { Offer(1) }, Array.Empty<SiteProductState>(), Array.Empty<string>(), default));
    }

    [Fact]
    public async Task Products_no_longer_fit_to_offer_are_taken_back_first()
    {
        var site = new FakeSite { Reply = (offer, again) => new SiteOfferReply("waiting", Array.Empty<string>()) };

        var round = await Sender(site).RunAsync(new[] { Offer(2) }, Array.Empty<SiteProductState>(), new[] { "1", "x" }, default);

        Assert.Equal(new[] { 1 }, round.Withdrawn);
        Assert.Equal(new[] { "withdraw 1", "withdraw x", "offer 2 again=False" }, site.Calls);
    }

    [Fact]
    public async Task A_declined_product_is_offered_again_only_when_asked_and_says_so_to_the_list()
    {
        var site = new FakeSite { Reply = (offer, again) => new SiteOfferReply("sending", new[] { "white" }) };

        var photos = await Sender(site).OfferAgainAsync(Offer(1), default);

        Assert.Equal(1, photos);
        Assert.Equal(new[] { "offer 1 again=True", "photo 1 white p-a" }, site.Calls);
    }

    [Fact]
    public async Task Several_listings_of_one_product_on_the_list_are_read_once()
    {
        var offer = Offer(1);
        var site = new FakeSite();

        var round = await Sender(site).RunAsync(new[] { offer }, new[] { OnList(offer), OnList(offer, "declined") }, Array.Empty<string>(), default);

        Assert.Equal(0, round.Offered);
    }

    private sealed class FakeSite : IWebsiteSite
    {
        public List<string> Calls { get; } = new();

        public Func<WebsiteOffer, bool, SiteOfferReply> Reply { get; set; } = (_, _) => new SiteOfferReply("waiting", Array.Empty<string>());

        public Task<IReadOnlyList<SiteProductState>> StatesAsync(CancellationToken ct) => Task.FromResult<IReadOnlyList<SiteProductState>>(Array.Empty<SiteProductState>());

        public Task<SiteOfferReply> OfferAsync(WebsiteOffer offer, bool again, CancellationToken ct)
        {
            Calls.Add($"offer {offer.Key} again={again}");
            return Task.FromResult(Reply(offer, again));
        }

        public Task<string> SendPhotoAsync(WebsiteOffer offer, OfferPhoto photo, PreparedPhoto prepared, CancellationToken ct)
        {
            Calls.Add($"photo {offer.Key} {WebsiteOffers.KindName(photo.Kind)} {offer.PhotosVersion}");
            return Task.FromResult("sending");
        }

        public Task WithdrawAsync(string product, CancellationToken ct)
        {
            Calls.Add("withdraw " + product);
            return Task.CompletedTask;
        }
    }
}

/// <summary>Making the AI's large pictures small enough for the owner's Supabase project.</summary>
public class WebsitePhotosTests
{
    private static byte[] Png(int width, int height, Action<SKCanvas, int, int>? draw = null, bool opaque = true)
    {
        using var surface = SKSurface.Create(new SKImageInfo(width, height, SKColorType.Rgba8888, opaque ? SKAlphaType.Opaque : SKAlphaType.Premul));
        surface.Canvas.Clear(opaque ? SKColors.White : SKColors.Transparent);
        draw?.Invoke(surface.Canvas, width, height);
        using var data = surface.Snapshot().Encode(SKEncodedImageFormat.Png, 100);
        return data.ToArray();
    }

    private static SKBitmap Decode(PreparedPhoto photo) => SKBitmap.Decode(Convert.FromBase64String(photo.Base64));

    [Fact]
    public void A_large_picture_becomes_a_smaller_JPEG_of_the_same_shape()
    {
        var prepared = WebsitePhotos.Prepare(Png(3000, 2000, (canvas, w, h) => canvas.DrawRect(w / 4, h / 4, w / 2, h / 2, new SKPaint { Color = SKColors.Red })));

        Assert.Equal("image/jpeg", prepared.Mime);
        Assert.Equal((1600, 1067), (prepared.Width, prepared.Height));
        Assert.InRange(prepared.Bytes, 1, WebsitePhotos.MaxBytes);
        using var bitmap = Decode(prepared);
        Assert.Equal((1600, 1067), (bitmap.Width, bitmap.Height));
        var middle = bitmap.GetPixel(800, 533);
        Assert.True(middle.Red > 200 && middle.Green < 60 && middle.Blue < 60, "the red square is still in the middle");
    }

    [Fact]
    public void A_small_picture_is_never_made_larger_and_a_tall_one_is_cut_by_its_height()
    {
        var small = WebsitePhotos.Prepare(Png(400, 300));
        var tall = WebsitePhotos.Prepare(Png(1000, 2400));

        Assert.Equal((400, 300), (small.Width, small.Height));
        Assert.Equal((667, 1600), (tall.Width, tall.Height));
    }

    [Fact]
    public void A_see_through_picture_is_laid_on_white_not_black()
    {
        var prepared = WebsitePhotos.Prepare(Png(200, 200, opaque: false));

        using var bitmap = Decode(prepared);
        var corner = bitmap.GetPixel(5, 5);
        Assert.True(corner.Red > 245 && corner.Green > 245 && corner.Blue > 245, "white, not black");
    }

    [Fact]
    public void A_picture_full_of_noise_is_still_made_small_enough()
    {
        var random = new Random(7);
        var noisy = Png(2400, 1600, (canvas, w, h) =>
        {
            using var paint = new SKPaint();
            for (var i = 0; i < 6000; i++)
            {
                paint.Color = new SKColor((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                canvas.DrawRect(random.Next(w), random.Next(h), random.Next(4, 60), random.Next(4, 60), paint);
            }
        });

        var prepared = WebsitePhotos.Prepare(noisy);

        Assert.InRange(prepared.Bytes, 1, WebsitePhotos.MaxBytes);
        Assert.True(prepared.Base64.Length <= 900_000, "the waiting list takes at most 900,000 letters");
    }

    [Theory]
    [InlineData(new byte[] { })]
    [InlineData(new byte[] { 1, 2, 3, 4 })]
    public void What_is_not_a_picture_is_refused_in_words(byte[] bytes)
    {
        Assert.Throws<InvalidDataException>(() => WebsitePhotos.Prepare(bytes));
    }
}

/// <summary>The client's calls for the website's waiting list and categories, and that the owner view's script has each of them as the
/// app calls it.</summary>
public class WebsiteClientTests
{
    private static OwnerViewClient Client(StubHandler handler) => new(new HttpClient(handler));

    [Fact]
    public async Task What_the_list_holds_is_read_with_each_products_state_versions_and_photos()
    {
        var handler = new StubHandler().Answer(HttpStatusCode.OK,
            "[{\"product\":\"1006\",\"state\":\"sending\",\"version\":\"v1\",\"photos_version\":\"p1\",\"photo_kinds\":[\"white\",\"in-use\"],\"staged\":[\"white\"]},"
            + "{\"product\":\"1007\",\"state\":\"published\",\"version\":\"v2\",\"photos_version\":\"p2\",\"photo_kinds\":[\"white\"],\"staged\":[]},{\"state\":\"waiting\"},5]");

        var states = await Client(handler).ProductStatesAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", default);

        Assert.Equal(2, states.Count);
        Assert.Equal(("1006", "sending", "v1", "p1"), (states[0].Product, states[0].State, states[0].Version, states[0].PhotosVersion));
        Assert.Equal(new[] { "white", "in-use" }, states[0].PhotoKinds);
        Assert.Equal(new[] { "white" }, states[0].Staged);
        Assert.Empty(states[1].Staged);
        Assert.EndsWith("/rest/v1/rpc/get_shop_product_states", handler.Requests[0].Uri);
        Assert.Equal("{\"p_key\":\"device-key\"}", handler.Requests[0].Body);
    }

    [Fact]
    public async Task A_product_is_offered_with_its_words_fingerprints_and_photo_kinds_and_the_reply_says_which_photos_to_send()
    {
        var handler = new StubHandler().Answer(HttpStatusCode.OK, "{\"state\":\"sending\",\"send_photos\":[\"white\",\"in-use\"]}");
        using var data = JsonDocument.Parse("{\"name\":\"Oil\",\"price\":160}");

        var reply = await Client(handler).OfferProductAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", "1006", data.RootElement.Clone(),
            "v1v1v1v1v1v1v1v1", "p1p1p1p1p1p1p1p1", new[] { "white", "in-use" }, true, default);

        Assert.Equal("sending", reply.State);
        Assert.Equal(new[] { "white", "in-use" }, reply.SendPhotos);
        using var body = JsonDocument.Parse(handler.Requests[0].Body!);
        var root = body.RootElement;
        Assert.Equal(new[] { "p_again", "p_data", "p_key", "p_photo_kinds", "p_photos_version", "p_product", "p_version" }, root.EnumerateObject().Select(p => p.Name).Order());
        Assert.Equal(("device-key", "1006", "v1v1v1v1v1v1v1v1", true), (root.GetProperty("p_key").GetString(), root.GetProperty("p_product").GetString(), root.GetProperty("p_version").GetString(), root.GetProperty("p_again").GetBoolean()));
        Assert.Equal(160, root.GetProperty("p_data").GetProperty("price").GetInt32());
        Assert.Equal(new[] { "white", "in-use" }, root.GetProperty("p_photo_kinds").EnumerateArray().Select(k => k.GetString()));
    }

    [Fact]
    public async Task A_photo_goes_with_its_kind_type_and_the_photos_fingerprint_and_the_answer_is_the_state()
    {
        var handler = new StubHandler().Answer(HttpStatusCode.OK, "\"waiting\"");

        var state = await Client(handler).SendProductPhotoAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", "1006", "in-use", "image/jpeg", "QUJD", "p1p1p1p1p1p1p1p1", default);

        Assert.Equal("waiting", state);
        using var body = JsonDocument.Parse(handler.Requests[0].Body!);
        Assert.Equal(new[] { "p_content", "p_key", "p_kind", "p_mime", "p_photos_version", "p_product" }, body.RootElement.EnumerateObject().Select(p => p.Name).Order());
    }

    [Fact]
    public async Task The_websites_categories_are_read_and_none_yet_is_null()
    {
        var some = new StubHandler().Answer(HttpStatusCode.OK, "{\"updated_at\":\"2026-10-04T09:30:00+00:00\",\"categories\":[{\"id\":\"c-groc\",\"name\":\"Grocery\",\"parentId\":null}]}");
        var none = new StubHandler().Answer(HttpStatusCode.OK, "null");

        var list = await Client(some).SiteCategoriesAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", default);

        Assert.Equal("Grocery", Assert.Single(list!.All).Name);
        Assert.Null(await Client(none).SiteCategoriesAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", default));
    }

    [Fact]
    public async Task A_full_list_is_told_apart_from_a_connection_problem_and_a_project_without_the_list_is_told_to_run_the_script_again()
    {
        var full = Client(new StubHandler().Answer(HttpStatusCode.BadRequest, "{\"code\":\"P0001\",\"message\":\"The waiting list is full: decide on some of the products on the website, and more are sent.\"}"));
        var refused = Client(new StubHandler().Answer(HttpStatusCode.BadRequest, "{\"code\":\"P0001\",\"message\":\"The product is missing or too large.\"}"));
        var old = Client(new StubHandler().Answer(HttpStatusCode.NotFound, "{\"code\":\"PGRST202\",\"message\":\"Could not find the function public.send_shop_product\"}"));
        var offline = Client(new StubHandler { Failure = new HttpRequestException("No such host") });
        using var data = JsonDocument.Parse("{}");

        Task Offer(OwnerViewClient client) => client.OfferProductAsync("https://abcd.supabase.co", "sb_publishable_abc", "k", "1", data.RootElement.Clone(), "v", "p", new[] { "white" }, false, default);

        var one = await Assert.ThrowsAsync<OwnerViewException>(() => Offer(full));
        Assert.True(one.ListFull);
        Assert.True(one.Refused);
        var two = await Assert.ThrowsAsync<OwnerViewException>(() => Offer(refused));
        Assert.False(two.ListFull);
        Assert.True(two.Refused);
        var three = await Assert.ThrowsAsync<OwnerViewException>(() => Offer(old));
        Assert.Equal(OwnerViewClient.MissingProducts, three.Message);
        Assert.Contains("waiting list", three.Message);
        Assert.False(three.Refused);
        var four = await Assert.ThrowsAsync<OwnerViewException>(() => Offer(offline));
        Assert.False(four.Refused);
        Assert.False(four.ListFull);
    }

    [Fact]
    public async Task The_PC_is_told_whether_it_is_the_main_PC_or_a_counter_and_a_project_without_roles_has_one_PC_per_shop()
    {
        const string url = "https://abcd.supabase.co", anon = "sb_publishable_abc";
        var main = await Client(new StubHandler().Answer(HttpStatusCode.OK, "{\"main\":true,\"main_label\":null}")).PcRoleAsync(url, anon, "k", default);
        var counter = await Client(new StubHandler().Answer(HttpStatusCode.OK, "{\"main\":false,\"main_label\":\"Mother PC\"}")).PcRoleAsync(url, anon, "k", default);
        var old = await Client(new StubHandler().Answer(HttpStatusCode.NotFound, "{\"code\":\"PGRST202\",\"message\":\"Could not find the function public.get_shop_pc_role\"}")).PcRoleAsync(url, anon, "k", default);

        Assert.Equal(new PcRole(true, null), main);
        Assert.Equal(new PcRole(false, "Mother PC"), counter);
        Assert.Equal(new PcRole(true, null), old);
        await Assert.ThrowsAsync<OwnerViewException>(() =>
            Client(new StubHandler { Failure = new HttpRequestException("No such host") }).PcRoleAsync(url, anon, "k", default));
        var disconnected = await Assert.ThrowsAsync<OwnerViewException>(() =>
            Client(new StubHandler().Answer(HttpStatusCode.Forbidden, "{\"code\":\"28000\",\"message\":\"This shop PC is not connected\"}")).PcRoleAsync(url, anon, "k", default));
        Assert.True(disconnected.Disconnected);
    }

    [Fact]
    public async Task Making_this_the_main_PC_names_the_PC_that_was_the_main_one()
    {
        const string url = "https://abcd.supabase.co", anon = "sb_publishable_abc";

        Assert.Equal("Mother PC", await Client(new StubHandler().Answer(HttpStatusCode.OK, "{\"previous\":\"Mother PC\"}")).ClaimMainPcAsync(url, anon, "k", default));
        Assert.Null(await Client(new StubHandler().Answer(HttpStatusCode.OK, "{\"previous\":null}")).ClaimMainPcAsync(url, anon, "k", default));
        var old = await Assert.ThrowsAsync<OwnerViewException>(() =>
            Client(new StubHandler().Answer(HttpStatusCode.NotFound, "{\"code\":\"PGRST202\",\"message\":\"no\"}")).ClaimMainPcAsync(url, anon, "k", default));
        Assert.Equal(OwnerViewClient.MissingRoles, old.Message);
    }

    [Fact]
    public async Task A_counters_refusal_is_told_apart_and_names_the_main_PC()
    {
        const string message = "Another shop PC, \"Mother PC\", is this shop's main PC and does this for the shop. Make this PC the main one in its Settings if it should.";
        var client = Client(new StubHandler().Answer(HttpStatusCode.BadRequest, "{\"code\":\"P0001\",\"message\":\"" + message.Replace("\"", "\\\"") + "\"}"));

        var refused = await Assert.ThrowsAsync<OwnerViewException>(() =>
            client.SendReportAsync("https://abcd.supabase.co", "sb_publishable_abc", "k", "review", new { }, default));

        Assert.True(refused.NotMain);
        Assert.True(refused.Refused);
        Assert.False(refused.ListFull);
        Assert.Equal("Mother PC", OwnerViewClient.MainLabelOf(refused.Message));
        Assert.Null(OwnerViewClient.MainLabelOf("No quotes here."));
    }

    [Fact]
    public async Task Every_call_the_app_makes_to_the_project_is_a_function_of_the_script_with_just_those_arguments()
    {
        var script = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "cloud", "supabase-owner-view.sql"));
        var functions = System.Text.RegularExpressions.Regex.Matches(script, @"create or replace function public\.(\w+)\(([^)]*)\)", System.Text.RegularExpressions.RegexOptions.Singleline)
            .ToDictionary(
                match => match.Groups[1].Value,
                match => match.Groups[2].Value.Split(',').Select(part => part.Trim()).Where(part => part.Length > 0)
                    .Select(part => (Name: part.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0], HasDefault: part.Contains(" default ", StringComparison.Ordinal))).ToList());
        var handler = new StubHandler().Answer(HttpStatusCode.OK, "{}");
        var client = Client(handler);
        const string url = "https://abcd.supabase.co", anon = "sb_publishable_abc", key = "device-key";
        using var empty = JsonDocument.Parse("{}");
        var live = OwnerLive.From(new OwnerLiveInputs { Now = DateTimeOffset.Now });

        async Task Call(Func<Task> call)
        {
            try
            {
                await call();
            }
            catch (OwnerViewException)
            {
                // The stand-in's answer is not what the call reads; only what was sent matters here.
            }
        }

        await Call(() => client.ConnectAsync(url, anon, "ABCDEFGH", "Shop PC", default));
        await Call(() => client.SendAsync(url, anon, key, live, Array.Empty<OwnerDay>(), default));
        await Call(() => client.SendReportAsync(url, anon, key, "review", new { }, default));
        await Call(() => client.DisconnectAsync(url, anon, key, default));
        await Call(() => client.NextQuestionAsync(url, anon, key, default));
        await Call(() => client.AnswerAsync(url, anon, key, Guid.NewGuid().ToString(), OwnerAnswer.Problem("x"), default));
        await Call(() => client.ProductStatesAsync(url, anon, key, default));
        await Call(() => client.OfferProductAsync(url, anon, key, "1", empty.RootElement, "v", "p", new[] { "white" }, false, default));
        await Call(() => client.SendProductPhotoAsync(url, anon, key, "1", "white", "image/jpeg", "QUJD", "p", default));
        await Call(() => client.WithdrawProductAsync(url, anon, key, "1", default));
        await Call(() => client.SiteCategoriesAsync(url, anon, key, default));
        await Call(() => client.PcRoleAsync(url, anon, key, default));
        await Call(() => client.ClaimMainPcAsync(url, anon, key, default));

        Assert.Equal(13, handler.Requests.Count);
        foreach (var request in handler.Requests)
        {
            var function = request.Uri[(request.Uri.LastIndexOf('/') + 1)..];
            Assert.True(functions.TryGetValue(function, out var parameters), $"the script has no function {function}");
            using var body = JsonDocument.Parse(request.Body!);
            var sent = body.RootElement.EnumerateObject().Select(property => property.Name).ToList();
            Assert.Empty(sent.Except(parameters!.Select(p => p.Name)));
            Assert.Empty(parameters!.Where(p => !p.HasDefault).Select(p => p.Name).Except(sent));
        }
    }

    private sealed class StubHandler : HttpMessageHandler
    {
        private HttpStatusCode _status = HttpStatusCode.OK;
        private string _body = "";

        public List<(string Uri, string? Body)> Requests { get; } = new();

        public Exception? Failure { get; init; }

        public StubHandler Answer(HttpStatusCode status, string body)
        {
            _status = status;
            _body = body;
            return this;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add((request.RequestUri!.ToString(), request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken)));
            if (Failure is not null)
            {
                throw Failure;
            }

            return new HttpResponseMessage(_status) { Content = new StringContent(_body, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

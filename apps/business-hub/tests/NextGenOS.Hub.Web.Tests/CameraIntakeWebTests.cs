using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Testing;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Cameras;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>
/// The door a camera program on this computer uses (<c>POST /api/cameras/observations</c>, Version 2 Phase 7 step 2): only from this computer (not from a paired counter PC, not from anything
/// that says it was passed on), only with the camera's key, only a small strict JSON message, no page token and no cookie, and answers that say as little as they can. The rules about what is kept
/// are in the Hub's own tests (<c>CameraIntakeTests</c>); here is the door itself. A test server has no network, so a request says where it "comes from" with a test-only header.
/// </summary>
public class CameraIntakeWebTests
{
    private const string Route = "/api/cameras/observations";
    private const string Remote = "192.168.1.50";

    private sealed record Setup(HubWebFactory Shop, HttpClient Http, string Key, long Camera, long Owner) : IDisposable
    {
        public void Dispose() => Shop.Dispose();
    }

    private static Setup Prepare(bool networkOn = false)
    {
        var f = new HubWebFactory { Modules = ["hub", "ai"], NetworkOn = networkOn };
        f.Hub.Shop.Save(new ShopSettings { Name = "Quiet Corner Shop", Country = "IN", Region = "27", Industry = "retail", SetupDone = true });
        var owner = f.Hub.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        f.Hub.Ai.Flags.Set(FlagKey.CameraAnalytics, true, owner);
        f.Hub.Ai.Flags.Set(FlagKey.EventEngine, true, owner);
        var camera = f.Hub.Cameras.Register(new CameraInput("Front door", CameraKind.Usb, "USB Camera", "zone:entrance", [CameraClass.Person], 50), owner);
        f.Hub.Cameras.TestAsync(camera.Id, owner).GetAwaiter().GetResult();
        f.Hub.Cameras.SetEnabled(camera.Id, true, owner);
        var key = f.Hub.CameraIntake.MakeKey(camera.Id, owner);
        var http = f.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false, HandleCookies = false });
        return new Setup(f, http, key, camera.Id, owner);
    }

    private static HttpRequestMessage Post(string? key, string? body, string? from = "127.0.0.1", string contentType = "application/json", params (string Name, string Value)[] headers)
    {
        var r = new HttpRequestMessage(HttpMethod.Post, Route);
        if (from is not null) r.Headers.Add(HubWebFactory.RemoteHeader, from);
        if (key is not null) r.Headers.TryAddWithoutValidation("Authorization", "Bearer " + key);
        foreach (var (name, value) in headers) r.Headers.TryAddWithoutValidation(name, value);
        if (body is not null) r.Content = new StringContent(body, Encoding.UTF8, contentType);
        return r;
    }

    private const string OneSeen = "{\"observations\":[{\"class\":\"person\",\"confidence\":0.9}]}";

    private static long Stored(Setup s) => s.Shop.Hub.Events.Counts().Observations;

    // ---- the key and the message --------------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_camera_program_with_the_right_key_is_answered_with_what_was_kept_and_what_was_not_and_the_answer_cannot_be_stored()
    {
        using var s = Prepare();

        var answer = await s.Http.SendAsync(Post(s.Key, "{\"model\":\"stand-in\",\"observations\":[{\"class\":\"person\",\"confidence\":0.9,\"count\":2},{\"class\":\"basket\",\"confidence\":0.9},{\"class\":\"person\",\"confidence\":0.1}]}"));

        Assert.Equal(HttpStatusCode.OK, answer.StatusCode);
        Assert.Equal("no-store", answer.Headers.CacheControl?.ToString());
        Assert.True(answer.Headers.Contains("X-Content-Type-Options"));
        Assert.False(answer.Headers.Contains("Set-Cookie"));
        using var json = JsonDocument.Parse(await answer.Content.ReadAsStringAsync());
        Assert.Equal(1, json.RootElement.GetProperty("accepted").GetInt32());
        var rejected = json.RootElement.GetProperty("rejected").EnumerateArray().ToList();
        Assert.Equal([1, 2], rejected.Select(r => r.GetProperty("index").GetInt32()).ToArray());
        Assert.Contains("not something this camera is set to look for", rejected[0].GetProperty("reason").GetString());
        Assert.Equal(1L, Stored(s));
        var seen = s.Shop.Hub.Events.QueryObservations(new NextGenOS.Hub.Events.ObservationQuery()).Single();
        Assert.Equal(("camera:front-door", "zone:entrance", "VIDEO", "stand-in"), (seen.SourceId, seen.ZoneRef, seen.DataClass, seen.ModelId));
    }

    [Fact]
    public async Task No_key_or_a_wrong_key_is_refused_with_a_401_that_names_nothing_and_nothing_is_kept()
    {
        using var s = Prepare();

        var none = await s.Http.SendAsync(Post(null, OneSeen));
        var wrong = await s.Http.SendAsync(Post("ngc-" + s.Camera + "-" + new string('A', 43), OneSeen));
        var garbage = await s.Http.SendAsync(Post("not a key", "this is not even json"));
        var basic = await s.Http.SendAsync(Post(null, OneSeen, headers: ("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("a:b")))));

        foreach (var answer in new[] { none, wrong, garbage, basic })
        {
            Assert.Equal(HttpStatusCode.Unauthorized, answer.StatusCode);
            Assert.Contains("Bearer", answer.Headers.WwwAuthenticate.ToString());
        }

        Assert.Equal(await wrong.Content.ReadAsStringAsync(), await garbage.Content.ReadAsStringAsync());   // the same words whatever was wrong, and the message was not even read
        Assert.Equal(0L, Stored(s));
    }

    [Fact]
    public async Task The_message_must_be_JSON_and_small_and_a_message_that_cannot_be_read_is_a_plain_400()
    {
        using var s = Prepare();

        var notJson = await s.Http.SendAsync(Post(s.Key, OneSeen, contentType: "text/plain"));
        var form = await s.Http.SendAsync(Post(s.Key, "a=b", contentType: "application/x-www-form-urlencoded"));
        var big = await s.Http.SendAsync(Post(s.Key, "{\"observations\":[" + new string(' ', IntakeBatch.MaxChars + 10) + "]}"));
        var bad = await s.Http.SendAsync(Post(s.Key, "{\"observations\":[]}"));
        var extra = await s.Http.SendAsync(Post(s.Key, "{\"observations\":[{\"class\":\"person\",\"confidence\":0.9}],\"image\":\"AAAA\"}"));

        Assert.Equal(HttpStatusCode.UnsupportedMediaType, notJson.StatusCode);
        Assert.Equal(HttpStatusCode.UnsupportedMediaType, form.StatusCode);
        Assert.Equal(HttpStatusCode.RequestEntityTooLarge, big.StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, bad.StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, extra.StatusCode);
        Assert.Contains("does not accept: 'image'", await extra.Content.ReadAsStringAsync());
        Assert.Equal(0L, Stored(s));
    }

    [Fact]
    public async Task What_the_owner_has_not_switched_on_is_answered_in_words_and_after_the_key_was_checked()
    {
        using var s = Prepare();
        s.Shop.Hub.Ai.Flags.Set(FlagKey.EventEngine, false, s.Owner);
        Assert.Equal(HttpStatusCode.ServiceUnavailable, (await s.Http.SendAsync(Post(s.Key, OneSeen))).StatusCode);
        s.Shop.Hub.Ai.Flags.Set(FlagKey.EventEngine, true, s.Owner);

        s.Shop.Hub.Cameras.SetEnabled(s.Camera, false, s.Owner);
        var off = await s.Http.SendAsync(Post(s.Key, OneSeen));
        Assert.Equal(HttpStatusCode.Conflict, off.StatusCode);
        Assert.Contains("switched off", await off.Content.ReadAsStringAsync());

        s.Shop.Hub.Ai.Flags.Set(FlagKey.CameraAnalytics, false, s.Owner);
        Assert.Equal(HttpStatusCode.ServiceUnavailable, (await s.Http.SendAsync(Post(s.Key, OneSeen))).StatusCode);
        // A wrong key is still just a wrong key.
        Assert.Equal(HttpStatusCode.Unauthorized, (await s.Http.SendAsync(Post("ngc-" + s.Camera + "-" + new string('A', 43), OneSeen))).StatusCode);
        Assert.Equal(0L, Stored(s));
    }

    // ---- who may use the door ----------------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task Only_this_computer_may_use_the_door_not_another_computer_on_the_network_and_not_something_that_passed_the_request_on()
    {
        using var s = Prepare(networkOn: true);

        foreach (var from in new[] { Remote, "10.0.0.7", "203.0.113.9" })
            Assert.Equal(HttpStatusCode.Forbidden, (await s.Http.SendAsync(Post(s.Key, OneSeen, from))).StatusCode);
        foreach (var header in new[] { "X-Forwarded-For", "Forwarded", "X-Real-IP" })
            Assert.Equal(HttpStatusCode.Forbidden, (await s.Http.SendAsync(Post(s.Key, OneSeen, "127.0.0.1", headers: (header, "203.0.113.9")))).StatusCode);
        Assert.Equal(0L, Stored(s));

        foreach (var from in new string?[] { null, "127.0.0.1", "::1", "::ffff:127.0.0.1" })
            Assert.Equal(HttpStatusCode.OK, (await s.Http.SendAsync(Post(s.Key, OneSeen, from))).StatusCode);
        Assert.Equal(4L, Stored(s));
    }

    [Fact]
    public async Task A_paired_counter_PC_with_a_right_key_is_still_refused_because_it_is_not_this_computer()
    {
        using var s = Prepare(networkOn: true);
        var code = s.Shop.Hub.Network.Pairing.NewCode(s.Owner).Code;
        var cookie = await PairCounterPc(s, code);

        var request = Post(s.Key, OneSeen, Remote);
        request.Headers.Add("Cookie", cookie);
        var answer = await s.Http.SendAsync(request);

        Assert.Equal(HttpStatusCode.Forbidden, answer.StatusCode);
        Assert.Equal(0L, Stored(s));
        // The same counter PC is welcome on the pages it was paired for, so it was this door that refused it.
        var page = Post(null, null, Remote);
        page.Method = HttpMethod.Get;
        page.RequestUri = new Uri("/login", UriKind.Relative);
        page.Headers.Add("Cookie", cookie);
        Assert.Equal(HttpStatusCode.OK, (await s.Http.SendAsync(page)).StatusCode);
    }

    [Fact]
    public async Task Without_a_usable_licence_nothing_is_answered_and_nothing_is_kept()
    {
        using var s = Prepare();
        s.Shop.Licensed = false;
        Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<NextGenOS.Licensing.AspNetCore.ProductLicence>(s.Shop.Services).Reload();   // the licence is looked at again now, not in half a minute

        var answer = await s.Http.SendAsync(Post(s.Key, OneSeen));

        Assert.NotEqual(HttpStatusCode.OK, answer.StatusCode);
        Assert.Equal(0L, Stored(s));
    }

    [Fact]
    public async Task A_web_page_in_a_browser_cannot_use_the_door_it_needs_no_page_token_but_allows_no_other_site()
    {
        using var s = Prepare();

        // Other sites are not allowed to call it from a browser: the door answers no cross-site request and sends no permission header, so a browser stops such a call before it is made.
        var preflight = new HttpRequestMessage(HttpMethod.Options, Route);
        preflight.Headers.Add(HubWebFactory.RemoteHeader, "127.0.0.1");
        preflight.Headers.Add("Origin", "https://evil.example");
        preflight.Headers.Add("Access-Control-Request-Method", "POST");
        preflight.Headers.Add("Access-Control-Request-Headers", "authorization,content-type");
        var answer = await s.Http.SendAsync(preflight);
        Assert.False(answer.Headers.Contains("Access-Control-Allow-Origin"));
        Assert.False(answer.Headers.Contains("Access-Control-Allow-Headers"));
        Assert.NotEqual(HttpStatusCode.OK, answer.StatusCode);

        // Without the key (which a page does not have) the same call from a page gets nothing.
        var fromPage = await s.Http.SendAsync(Post(null, OneSeen, "127.0.0.1", headers: ("Origin", "https://evil.example")));
        Assert.Equal(HttpStatusCode.Unauthorized, fromPage.StatusCode);
        Assert.False(fromPage.Headers.Contains("Access-Control-Allow-Origin"));

        // And a person who is signed in gains nothing from being signed in: the door looks at the key only.
        var get = new HttpRequestMessage(HttpMethod.Get, Route);
        get.Headers.Add(HubWebFactory.RemoteHeader, "127.0.0.1");
        Assert.NotEqual(HttpStatusCode.OK, (await s.Http.SendAsync(get)).StatusCode);
        Assert.Equal(0L, Stored(s));
    }

    // ---- helpers ----------------------------------------------------------------------------------------------------------------------------------

    /// <summary>Does what a counter PC does: opens the pairing page, types the code and a name. Returns the cookie the Hub gave.</summary>
    private static async Task<string> PairCounterPc(Setup s, string code)
    {
        var form = new HttpRequestMessage(HttpMethod.Get, "/pair");
        form.Headers.Add(HubWebFactory.RemoteHeader, Remote);
        var page = await s.Http.SendAsync(form);
        var html = await page.Content.ReadAsStringAsync();
        var token = Regex.Match(html, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var antiforgery = string.Join("; ", page.Headers.GetValues("Set-Cookie").Select(c => c.Split(';')[0]));
        var post = new HttpRequestMessage(HttpMethod.Post, "/pair");
        post.Headers.Add(HubWebFactory.RemoteHeader, Remote);
        post.Headers.Add("Cookie", antiforgery);
        post.Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["__RequestVerificationToken"] = token, ["code"] = code, ["name"] = "Counter 2" });
        var answer = await s.Http.SendAsync(post);
        Assert.Equal(HttpStatusCode.SeeOther, answer.StatusCode);
        return answer.Headers.GetValues("Set-Cookie").First(c => c.StartsWith("hub.device=", StringComparison.Ordinal)).Split(';')[0];
    }
}

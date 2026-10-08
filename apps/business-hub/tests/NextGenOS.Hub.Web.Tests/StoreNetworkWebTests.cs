using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NextGenOS.Hub.Counters;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>
/// The door of the Hub for computers on the shop's network (blueprint NET-006): this PC goes straight through, a computer that is not paired gets one plain refusal and nothing else, the
/// pairing pages work once with a code, a removed counter PC is refused with the very next request, and switching counter PCs off stops everyone at once.
/// A test server has no network, so a request says where it "comes from" with a test-only header.
/// </summary>
public class StoreNetworkWebTests
{
    private const string Remote = "192.168.1.50";
    private const string OtherRemote = "192.168.1.51";

    private static HttpClient Client(HubWebFactory f)
    {
        var http = f.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false, HandleCookies = false });
        http.DefaultRequestHeaders.Accept.ParseAdd("text/html");
        return http;
    }

    private static HubWebFactory Shop(bool networkOn = true, int devices = 0)
    {
        var f = new HubWebFactory { NetworkOn = networkOn, Devices = devices };
        f.Hub.Shop.Save(new ShopSettings { Name = "Quiet Corner Shop", Country = "IN", Region = "27", Industry = "retail", SetupDone = true });
        // A shop with nobody in it sends every page to the first-run set-up, so the shop has its owner from the start.
        f.Hub.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery");
        return f;
    }

    private static long Owner(HubWebFactory f) => f.Hub.Users.List().Single(u => u.Role == Roles.Owner).Id;

    private static HttpRequestMessage Req(HttpMethod method, string path, string? from, string? cookie = null, params (string Name, string Value)[] headers)
    {
        var r = new HttpRequestMessage(method, path);
        if (from is not null) r.Headers.Add(HubWebFactory.RemoteHeader, from);
        if (cookie is not null) r.Headers.Add("Cookie", cookie);
        foreach (var (name, value) in headers) r.Headers.Add(name, value);
        return r;
    }

    private static Task<HttpResponseMessage> Get(HttpClient http, string path, string? from, string? cookie = null) => http.SendAsync(Req(HttpMethod.Get, path, from, cookie));

    /// <summary>Does what a counter PC does: opens the pairing page, types the code and a name. Returns the answer and the cookie the Hub gave (if any).</summary>
    private static async Task<(HttpResponseMessage Answer, string? DeviceCookie, string Page)> TryPair(HttpClient http, string from, string code, string name)
    {
        var form = await Get(http, "/pair", from);
        var html = await form.Content.ReadAsStringAsync();
        var token = Regex.Match(html, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var antiforgery = string.Join("; ", form.Headers.GetValues("Set-Cookie").Select(c => c.Split(';')[0]));
        var post = Req(HttpMethod.Post, "/pair", from, antiforgery);
        post.Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["__RequestVerificationToken"] = token, ["code"] = code, ["name"] = name });
        var answer = await http.SendAsync(post);
        string? device = null;
        if (answer.Headers.TryGetValues("Set-Cookie", out var set))
            device = set.FirstOrDefault(c => c.StartsWith("hub.device=", StringComparison.Ordinal))?.Split(';')[0];
        return (answer, device, await answer.Content.ReadAsStringAsync());
    }

    private static async Task<string> PairedCookie(HubWebFactory f, HttpClient http, long owner, string name = "Counter 2", string from = Remote)
    {
        var code = f.Hub.Network.Pairing.NewCode(owner).Code;
        var (answer, cookie, page) = await TryPair(http, from, code, name);
        Assert.True(HttpStatusCode.SeeOther == answer.StatusCode, page);
        return cookie!;
    }

    // ---- this PC ----------------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task This_PC_is_never_stopped_by_the_door_with_counter_PCs_on_or_off()
    {
        foreach (var on in new[] { false, true })
        {
            using var f = Shop(on);
            var http = Client(f);
            foreach (var from in new string?[] { null, "127.0.0.1", "::1", "::ffff:127.0.0.1" })
            {
                Assert.Equal(HttpStatusCode.OK, (await Get(http, "/health", from)).StatusCode);
                Assert.Equal(HttpStatusCode.Redirect, (await Get(http, "/", from)).StatusCode);   // to the sign-in page, as it always did
                Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", from)).StatusCode);
            }
        }
    }

    [Fact]
    public async Task With_counter_PCs_off_a_forwarding_header_changes_nothing_for_this_PC()
    {
        using var f = Shop(networkOn: false);
        var http = Client(f);
        var answer = await http.SendAsync(Req(HttpMethod.Get, "/login", "127.0.0.1", null, ("X-Forwarded-For", "203.0.113.9")));
        Assert.Equal(HttpStatusCode.OK, answer.StatusCode);
    }

    [Fact]
    public async Task With_counter_PCs_on_a_request_from_this_PC_that_says_it_was_passed_on_is_treated_as_a_computer_on_the_network()
    {
        using var f = Shop();
        var http = Client(f);
        foreach (var header in new[] { "X-Forwarded-For", "Forwarded", "X-Real-IP", "X-Forwarded-Host", "X-Forwarded-Proto" })
        {
            var answer = await http.SendAsync(Req(HttpMethod.Get, "/login", "127.0.0.1", null, (header, "203.0.113.9")));
            Assert.Equal(HttpStatusCode.Forbidden, answer.StatusCode);
        }

        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", "127.0.0.1")).StatusCode);   // the same request without the header is this PC
    }

    // ---- a computer that is not paired ------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_computer_that_is_not_paired_gets_one_plain_refusal_and_learns_nothing_about_the_shop()
    {
        using var f = Shop();
        var http = Client(f);
        foreach (var path in new[] { "/", "/login", "/sell", "/settings", "/_blazor", "/_framework/blazor.web.js", "/tokens.css", "/barcode/ean13.png?data=5901234123457", "/license", "/error", "/nothing-here", "/pair/other" })
        {
            var answer = await Get(http, path, Remote);
            var html = await answer.Content.ReadAsStringAsync();
            Assert.True(HttpStatusCode.Forbidden == answer.StatusCode, path + " gave " + (int)answer.StatusCode);
            Assert.Contains("has not been paired", html);
            Assert.DoesNotContain("Quiet Corner", html);
            Assert.DoesNotContain("icence", html);
            Assert.DoesNotContain("   at ", html);
            Assert.Equal("no-store", answer.Headers.CacheControl?.ToString());
            Assert.Contains("frame-ancestors 'none'", string.Join(" ", answer.Headers.GetValues("Content-Security-Policy")));
            Assert.Equal("nosniff", answer.Headers.GetValues("X-Content-Type-Options").Single());
            Assert.False(answer.Headers.Contains("Set-Cookie"));
        }

        foreach (var method in new[] { HttpMethod.Post, HttpMethod.Put, HttpMethod.Delete, HttpMethod.Patch })
        {
            var answer = await http.SendAsync(Req(method, "/login", Remote));
            Assert.Equal(HttpStatusCode.Forbidden, answer.StatusCode);
        }

        var head = await http.SendAsync(Req(HttpMethod.Head, "/", Remote));
        Assert.Equal(HttpStatusCode.Forbidden, head.StatusCode);
        Assert.Empty(await head.Content.ReadAsByteArrayAsync());
    }

    [Fact]
    public async Task A_made_up_or_damaged_device_cookie_is_refused_like_no_cookie()
    {
        using var f = Shop();
        var http = Client(f);
        var owner = Owner(f);
        var real = await PairedCookie(f, http, owner);
        var value = real["hub.device=".Length..];
        foreach (var cookie in new[] { "hub.device=", "hub.device=1.AAAA", "hub.device=999.AAAA", "hub.device=abc", "hub.device=" + value + "x", "hub.device=2" + value[1..], "hub.device=" + new string('9', 400), "hub.device=-1.x" })
            Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, "/login", Remote, cookie)).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", Remote, real)).StatusCode);
    }

    [Fact]
    public async Task The_health_check_and_the_pairing_pages_are_the_only_things_open_to_a_computer_that_is_not_paired()
    {
        using var f = Shop();
        var http = Client(f);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/health", Remote)).StatusCode);
        var pair = await Get(http, "/pair", Remote);
        Assert.Equal(HttpStatusCode.OK, pair.StatusCode);
        var html = await pair.Content.ReadAsStringAsync();
        Assert.Contains("Pairing code", html);
        Assert.Contains("__RequestVerificationToken", html);
        Assert.DoesNotContain("Quiet Corner", html);
        Assert.Equal("no-store", pair.Headers.CacheControl?.ToString());
        Assert.Contains("DENY", pair.Headers.GetValues("X-Frame-Options").Single().ToUpperInvariant());   // not SAMEORIGIN: the pairing page cannot be framed

        var capitals = await Get(http, "/PAIR", Remote);   // the router does not care about capitals, so neither does the door
        Assert.Equal(HttpStatusCode.OK, capitals.StatusCode);
    }

    [Fact]
    public async Task The_shops_own_certificate_can_be_read_by_a_computer_that_is_not_paired_but_never_the_key()
    {
        using var f = Shop();
        var http = Client(f);
        var page = await (await Get(http, "/pair/ca", Remote)).Content.ReadAsStringAsync();
        var fingerprint = f.Hub.Network.Runtime.AuthorityFingerprint!;
        Assert.Contains(StoreCertificates.Spaced(fingerprint), page);
        Assert.Contains("Trusted Root Certification Authorities", page);

        var file = await Get(http, "/pair/ca.crt", Remote);
        Assert.Equal(HttpStatusCode.OK, file.StatusCode);
        Assert.Equal("application/x-x509-ca-cert", file.Content.Headers.ContentType?.MediaType);
        Assert.Contains("attachment", file.Content.Headers.ContentDisposition?.ToString());
        var pem = await file.Content.ReadAsStringAsync();
        Assert.StartsWith("-----BEGIN CERTIFICATE-----", pem);
        Assert.DoesNotContain("PRIVATE KEY", pem);
        Assert.DoesNotContain("PRIVATE KEY", page);
    }

    [Fact]
    public async Task On_this_PC_the_pairing_pages_say_where_to_go_and_pairing_is_not_done_here()
    {
        using var f = Shop();
        var http = Client(f);
        var page = await Get(http, "/pair", "127.0.0.1");
        Assert.Equal(HttpStatusCode.OK, page.StatusCode);
        Assert.Contains("shop's main PC", await page.Content.ReadAsStringAsync());
        var post = Req(HttpMethod.Post, "/pair", "127.0.0.1");
        post.Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["code"] = "ABCD-EFGH", ["name"] = "x" });
        Assert.Equal(HttpStatusCode.Forbidden, (await http.SendAsync(post)).StatusCode);
    }

    // ---- pairing ----------------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_counter_PC_pairs_once_with_the_code_and_then_reaches_the_shop_until_it_is_removed()
    {
        using var f = Shop();
        var http = Client(f);
        var owner = Owner(f);
        var code = f.Hub.Network.Pairing.NewCode(owner).Code;

        var (answer, cookie, page) = await TryPair(http, Remote, code, "Counter 2");
        Assert.True(HttpStatusCode.SeeOther == answer.StatusCode, page);
        Assert.Equal("/pair", answer.Headers.Location?.OriginalString);
        Assert.NotNull(cookie);
        var set = answer.Headers.GetValues("Set-Cookie").Single(c => c.StartsWith("hub.device=", StringComparison.Ordinal)).ToLowerInvariant();
        Assert.Contains("httponly", set);
        Assert.Contains("secure", set);
        Assert.Contains("samesite=strict", set);
        Assert.Contains("max-age=", set);

        // Paired: the sign-in page is reachable, and the pairing page says so.
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", Remote, cookie)).StatusCode);
        var again = await (await Get(http, "/pair", Remote, cookie)).Content.ReadAsStringAsync();
        Assert.Contains("paired as", again);
        Assert.Contains("Counter 2", again);
        var listed = f.Hub.Network.Pairing.List().Single();
        Assert.Equal("Counter 2", listed.Name);
        Assert.Equal(Remote, listed.LastAddress);

        // The code works once.
        var (second, secondCookie, _) = await TryPair(http, OtherRemote, code, "Counter 3");
        Assert.Equal(HttpStatusCode.BadRequest, second.StatusCode);
        Assert.Null(secondCookie);
        Assert.Single(f.Hub.Network.Pairing.List());
    }

    [Fact]
    public async Task A_wrong_code_gets_plain_words_and_too_many_wrong_codes_lock_that_address()
    {
        using var f = Shop();
        var http = Client(f);
        f.Hub.Network.Pairing.NewCode(Owner(f));
        HttpStatusCode last = default;
        string html = "";
        for (var i = 0; i < PairingService.WrongPerAddress; i++)
        {
            var (answer, cookie, page) = await TryPair(http, Remote, "WRNG-CODE", "Counter 2");
            last = answer.StatusCode;
            html = page;
            Assert.Null(cookie);
            Assert.Equal(HttpStatusCode.BadRequest, last);
            Assert.Contains("not right", html);
        }

        var (locked, _, lockedPage) = await TryPair(http, Remote, "WRNG-CODE", "Counter 2");
        Assert.Equal(HttpStatusCode.TooManyRequests, locked.StatusCode);
        Assert.True(locked.Headers.Contains("Retry-After"));
        Assert.Contains("Too many wrong codes", lockedPage);
        Assert.Empty(f.Hub.Network.Pairing.List());
        Assert.Contains("network.pair-refused", f.Hub.Audit.Recent(100).Select(a => a.Action));
    }

    [Fact]
    public async Task A_pairing_form_without_the_pages_own_token_is_not_accepted()
    {
        using var f = Shop();
        var http = Client(f);
        var code = f.Hub.Network.Pairing.NewCode(Owner(f)).Code;
        var post = Req(HttpMethod.Post, "/pair", Remote);
        post.Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["code"] = code, ["name"] = "Counter 2" });
        var answer = await http.SendAsync(post);
        Assert.Equal(HttpStatusCode.BadRequest, answer.StatusCode);
        Assert.Contains("expired", await answer.Content.ReadAsStringAsync());
        Assert.False(answer.Headers.Contains("Set-Cookie"));
        Assert.Empty(f.Hub.Network.Pairing.List());
        // ... and the code was not used up.
        var (ok, _, page) = await TryPair(http, Remote, code, "Counter 2");
        Assert.True(HttpStatusCode.SeeOther == ok.StatusCode, page);
    }

    [Fact]
    public async Task A_pairing_form_that_is_too_big_or_not_a_form_is_not_read()
    {
        using var f = Shop();
        var http = Client(f);
        var big = Req(HttpMethod.Post, "/pair", Remote);
        big.Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["code"] = new string('A', 6000), ["name"] = "x" });
        Assert.Equal(HttpStatusCode.BadRequest, (await http.SendAsync(big)).StatusCode);
        var notForm = Req(HttpMethod.Post, "/pair", Remote);
        notForm.Content = new StringContent("{\"code\":\"x\"}", System.Text.Encoding.UTF8, "application/json");
        Assert.Equal(HttpStatusCode.BadRequest, (await http.SendAsync(notForm)).StatusCode);
    }

    [Fact]
    public async Task A_name_is_shown_as_text_never_as_markup()
    {
        using var f = Shop();
        var http = Client(f);
        var owner = Owner(f);
        var code = f.Hub.Network.Pairing.NewCode(owner).Code;
        var (answer, cookie, _) = await TryPair(http, Remote, code, "<script>alert(1)</script>");
        // Whatever the name rule decides, no markup ever comes back in a page.
        var html = answer.StatusCode == HttpStatusCode.SeeOther ? await (await Get(http, "/pair", Remote, cookie)).Content.ReadAsStringAsync() : await answer.Content.ReadAsStringAsync();
        Assert.DoesNotContain("<script>alert(1)", html);
    }

    // ---- removing, switching off, the licence --------------------------------------------------------------------------------

    [Fact]
    public async Task A_removed_counter_PC_is_refused_with_its_very_next_request()
    {
        using var f = Shop();
        var http = Client(f);
        var owner = Owner(f);
        var cookie = await PairedCookie(f, http, owner);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", Remote, cookie)).StatusCode);

        f.Hub.Network.Pairing.Remove(f.Hub.Network.Pairing.List().Single().Id, owner);

        Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, "/login", Remote, cookie)).StatusCode);
        Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, "/", Remote, cookie)).StatusCode);
        // It can pair again as a new counter PC with a new code (the old token never comes back).
        var fresh = await PairedCookie(f, http, owner, "Counter 2b");
        Assert.NotEqual(cookie, fresh);
        Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, "/login", Remote, cookie)).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", Remote, fresh)).StatusCode);
    }

    [Fact]
    public async Task Switching_counter_PCs_off_refuses_every_counter_PC_at_once_and_this_PC_still_works()
    {
        using var f = Shop();
        var http = Client(f);
        var owner = Owner(f);
        var cookie = await PairedCookie(f, http, owner);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", Remote, cookie)).StatusCode);

        f.Hub.Network.Configure(owner, false, f.Hub.Network.Saved().Port);

        Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, "/login", Remote, cookie)).StatusCode);
        Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, "/health", Remote)).StatusCode);   // even the open pages: nothing is served to the network
        Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, "/pair", Remote)).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", "127.0.0.1")).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", null)).StatusCode);
        Assert.Throws<HubException>(() => f.Hub.Network.Pairing.NewCode(owner));   // and no new code can be made
    }

    [Fact]
    public async Task With_counter_PCs_never_switched_on_every_computer_on_the_network_is_refused()
    {
        using var f = Shop(networkOn: false);
        var http = Client(f);
        foreach (var path in new[] { "/", "/health", "/pair", "/pair/ca", "/login" })
            Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, path, Remote)).StatusCode);
        Assert.False(f.Hub.Network.Runtime.Running);
        Assert.Null(f.Hub.Network.Runtime.AuthorityPem);
        Assert.False(File.Exists(Path.Combine(f.Folder, "shop-network-authority.crt")));   // nothing is made unless the owner asked for it
    }

    [Fact]
    public async Task Without_a_usable_licence_a_counter_PC_gets_the_same_plain_refusal_never_the_licence_page()
    {
        using var f = Shop();
        var http = Client(f);
        var owner = Owner(f);
        var cookie = await PairedCookie(f, http, owner);

        f.Licensed = false;
        f.Services.GetRequiredService<ProductLicence>().Reload();

        foreach (var from in new[] { Remote, OtherRemote })
        {
            var answer = await Get(http, "/login", from, from == Remote ? cookie : null);
            var html = await answer.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.Forbidden, answer.StatusCode);
            Assert.DoesNotContain("icence", html);
        }

        var pairing = await Get(http, "/pair", Remote);   // no pairing either, while the shop is not licensed
        Assert.Equal(HttpStatusCode.Forbidden, pairing.StatusCode);
    }

    [Fact]
    public async Task The_licences_number_of_PCs_limits_the_counter_PCs_and_says_so_in_plain_words()
    {
        using var f = Shop(devices: 2);   // the main PC and one counter PC
        var http = Client(f);
        var owner = Owner(f);
        var cookie = await PairedCookie(f, http, owner);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", Remote, cookie)).StatusCode);

        var full = Assert.Throws<HubException>(() => f.Hub.Network.Pairing.NewCode(owner));
        Assert.Equal("device-limit", full.Code);
        Assert.Contains("licence is for 2 PCs", full.Message);

        // Remove the one, and the place is free again.
        f.Hub.Network.Pairing.Remove(f.Hub.Network.Pairing.List().Single().Id, owner);
        var next = await PairedCookie(f, http, owner, "Counter 3", OtherRemote);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", OtherRemote, next)).StatusCode);
    }

    [Fact]
    public async Task A_computer_that_keeps_asking_for_things_without_being_paired_is_noted_in_the_log_but_not_without_limit()
    {
        using var f = Shop();
        var http = Client(f);
        for (var i = 0; i < 60; i++) await Get(http, "/sell?x=" + i, Remote);
        var lines = f.Hub.Audit.Recent(500).Where(a => a.Action == "network.refused").ToList();
        Assert.NotEmpty(lines);
        Assert.True(lines.Count < 20, "the log must not grow with every request (" + lines.Count + " lines)");
    }

    [Fact]
    public async Task Two_counter_PCs_do_not_see_each_others_pairing()
    {
        using var f = Shop();
        var http = Client(f);
        var owner = Owner(f);
        var a = await PairedCookie(f, http, owner, "Counter A", Remote);
        var b = await PairedCookie(f, http, owner, "Counter B", OtherRemote);
        Assert.NotEqual(a, b);
        f.Hub.Network.Pairing.Remove(f.Hub.Network.Pairing.List().Single(c => c.Name == "Counter A").Id, owner);
        Assert.Equal(HttpStatusCode.Forbidden, (await Get(http, "/login", Remote, a)).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login", OtherRemote, b)).StatusCode);
    }
}

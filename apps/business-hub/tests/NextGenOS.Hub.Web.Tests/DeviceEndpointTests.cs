using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using NextGenOS.Devices.Barcodes;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web.Tests;

public class DeviceEndpointTests
{
    private static HttpClient Client(HubWebFactory f)
    {
        var http = f.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = false, HandleCookies = false });
        http.DefaultRequestHeaders.Accept.ParseAdd("text/html");
        return http;
    }

    private static async Task<(string Cookie, string Token)> SignedIn(HubWebFactory f, HttpClient http)
    {
        f.Hub.Shop.Save(new ShopSettings { Name = "Test Shop", Country = "IN", Region = "27", Industry = "retail", SetupDone = true });
        f.Hub.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery");
        var login = await http.GetAsync("/login");
        var html = await login.Content.ReadAsStringAsync();
        var form = new Dictionary<string, string>
        {
            ["__RequestVerificationToken"] = Regex.Match(html, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value,
            ["_handler"] = Regex.Match(html, "name=\"_handler\"[^>]*value=\"([^\"]+)\"").Groups[1].Value,
            ["Username"] = "owner", ["Password"] = "correct horse battery",
        };
        var csrfCookie = string.Join("; ", login.Headers.GetValues("Set-Cookie").Select(c => c.Split(';')[0]));
        var post = new HttpRequestMessage(HttpMethod.Post, "/login") { Content = new FormUrlEncodedContent(form) };
        post.Headers.Add("Cookie", csrfCookie);
        var signedIn = await http.SendAsync(post);
        var session = signedIn.Headers.GetValues("Set-Cookie").First(c => c.StartsWith("hub.session=", StringComparison.Ordinal)).Split(';')[0];
        // The token the page itself would send: made for this signed-in person.
        var page = new HttpRequestMessage(HttpMethod.Get, "/");
        page.Headers.Add("Cookie", csrfCookie + "; " + session);
        var home = await http.SendAsync(page);
        var token = Regex.Match(await home.Content.ReadAsStringAsync(), "name=\"csrf\" content=\"([^\"]+)\"").Groups[1].Value;
        var cookies = csrfCookie + "; " + session;
        if (home.Headers.TryGetValues("Set-Cookie", out var more)) cookies = string.Join("; ", more.Select(c => c.Split(';')[0]).Concat(new[] { session }));
        return (cookies, token);
    }

    private static HttpRequestMessage Get(string path, string cookie)
    {
        var r = new HttpRequestMessage(HttpMethod.Get, path);
        r.Headers.Add("Cookie", cookie);
        return r;
    }

    [Fact]
    public async Task A_barcode_picture_is_made_for_signed_in_people_and_reads_back()
    {
        using var f = new HubWebFactory();
        var http = Client(f);
        Assert.Equal(HttpStatusCode.Redirect, (await http.GetAsync("/barcode/ean13.png?data=5901234123457")).StatusCode);
        var (cookie, _) = await SignedIn(f, http);
        var ok = await http.SendAsync(Get("/barcode/ean13.png?data=5901234123457&w=300&h=90", cookie));
        Assert.Equal(HttpStatusCode.OK, ok.StatusCode);
        Assert.Equal("image/png", ok.Content.Headers.ContentType!.MediaType);
        Assert.Equal("5901234123457", BarcodeImages.Read(await ok.Content.ReadAsByteArrayAsync())!.Value.Text);
        Assert.Equal(HttpStatusCode.NotFound, (await http.SendAsync(Get("/barcode/nonsense.png?data=1", cookie))).StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, (await http.SendAsync(Get("/barcode/ean13.png?data=12AB", cookie))).StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, (await http.SendAsync(Get("/barcode/code128.png?data=" + new string('9', 400), cookie))).StatusCode);
    }

    [Fact]
    public async Task A_camera_picture_is_read_for_signed_in_people_with_the_pages_own_token()
    {
        using var f = new HubWebFactory();
        var http = Client(f);
        var (cookie, token) = await SignedIn(f, http);
        var png = BarcodeImages.Png(BarcodeKind.Ean13, "4006381333931", 500, 160);

        HttpRequestMessage Post(byte[] body, string type, bool withToken)
        {
            var r = new HttpRequestMessage(HttpMethod.Post, "/api/scan") { Content = new ByteArrayContent(body) };
            r.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(type);
            r.Headers.Add("Cookie", cookie);
            if (withToken) r.Headers.Add("RequestVerificationToken", token);
            return r;
        }

        var found = await http.SendAsync(Post(png, "image/png", true));
        Assert.Equal(HttpStatusCode.OK, found.StatusCode);
        Assert.Equal("4006381333931", JsonDocument.Parse(await found.Content.ReadAsStringAsync()).RootElement.GetProperty("text").GetString());

        var nothing = await http.SendAsync(Post(new byte[] { 1, 2, 3 }, "image/jpeg", true));
        Assert.Equal(HttpStatusCode.OK, nothing.StatusCode);
        Assert.Equal(JsonValueKind.Null, JsonDocument.Parse(await nothing.Content.ReadAsStringAsync()).RootElement.GetProperty("text").ValueKind);

        Assert.NotEqual(HttpStatusCode.OK, (await http.SendAsync(Post(png, "image/png", false))).StatusCode);          // no token: refused
        Assert.Equal(HttpStatusCode.BadRequest, (await http.SendAsync(Post(png, "text/plain", true))).StatusCode);       // not a picture
        Assert.Equal(HttpStatusCode.BadRequest, (await http.SendAsync(Post(new byte[6_000_001], "image/png", true))).StatusCode);
        var anonymous = new HttpRequestMessage(HttpMethod.Post, "/api/scan") { Content = new ByteArrayContent(png) };
        anonymous.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
        Assert.Equal(HttpStatusCode.Redirect, (await http.SendAsync(anonymous)).StatusCode);
    }

    [Fact]
    public async Task The_Settings_page_for_printers_and_the_posters_page_open_for_the_owner()
    {
        using var f = new HubWebFactory();
        var http = Client(f);
        var (cookie, _) = await SignedIn(f, http);
        foreach (var path in new[] { "/settings", "/posters", "/items" })
        {
            var r = await http.SendAsync(Get(path, cookie));
            Assert.Equal(HttpStatusCode.OK, r.StatusCode);
        }
    }
}

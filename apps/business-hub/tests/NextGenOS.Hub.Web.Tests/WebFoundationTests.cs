using System.Net;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web.Tests;

public class WebFoundationTests
{
    private static HttpClient Client(HubWebFactory factory)
    {
        // No cookie jar: each test sends the cookies it means to send.
        var http = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = false, HandleCookies = false });
        http.DefaultRequestHeaders.Accept.ParseAdd("text/html");
        return http;
    }

    private static string Where(HttpResponseMessage response) => response.Headers.Location!.IsAbsoluteUri ? response.Headers.Location.PathAndQuery : response.Headers.Location.OriginalString;

    private static void SetUp(HubWebFactory f, string industry = "retail")
    {
        f.Hub.Shop.Save(new ShopSettings { Name = "Test Shop", Country = "IN", Region = "27", Industry = industry, SetupDone = true });
        f.Hub.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery");
        f.Hub.Users.Create("till", "Tara Till", Roles.Cashier, "another good password");
    }

    private static async Task<string> SignIn(HttpClient http, string user, string password)
    {
        var page = await Get(http, "/login");
        var html = await page.Content.ReadAsStringAsync();
        var token = Regex.Match(html, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var formName = Regex.Match(html, "name=\"_handler\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var cookies = string.Join("; ", page.Headers.GetValues("Set-Cookie").Select(c => c.Split(';')[0]));
        var request = new HttpRequestMessage(HttpMethod.Post, "/login") { Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["__RequestVerificationToken"] = token, ["_handler"] = formName, ["Username"] = user, ["Password"] = password }) };
        request.Headers.Add("Cookie", cookies);
        var response = await http.SendAsync(request);
        var set = response.Headers.TryGetValues("Set-Cookie", out var values) ? values.ToList() : new List<string>();
        var session = set.FirstOrDefault(c => c.StartsWith("hub.session=", StringComparison.Ordinal));
        return session is null ? "" : cookies + "; " + session.Split(';')[0];
    }

    private static async Task<HttpResponseMessage> Get(HttpClient http, string path, string cookie = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        if (cookie.Length > 0) request.Headers.Add("Cookie", cookie);
        return await http.SendAsync(request);
    }

    [Fact]
    public async Task Without_a_licence_nothing_is_served_and_the_page_has_a_place_for_the_key()
    {
        using var f = new HubWebFactory { Licensed = false };
        var http = Client(f);
        foreach (var path in new[] { "/", "/login", "/setup", "/tokens.css", "/export/sales.csv", "/health" })
        {
            var response = await Get(http, path);
            Assert.Equal(HttpStatusCode.PaymentRequired, response.StatusCode);
        }
        var page = await (await Get(http, "/")).Content.ReadAsStringAsync();
        Assert.Contains("needs a licence", page);
        Assert.Contains("name=\"key\"", page);
    }

    [Fact]
    public async Task A_new_shop_sends_every_page_to_the_setup_and_the_setup_closes_once_the_shop_is_set_up()
    {
        using var f = new HubWebFactory();
        var http = Client(f);
        var home = await Get(http, "/");
        Assert.Equal(HttpStatusCode.Redirect, home.StatusCode);
        Assert.Equal("/setup", Where(home));
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/setup")).StatusCode);

        SetUp(f);
        var closed = await Get(http, "/setup");
        Assert.Equal(HttpStatusCode.Redirect, closed.StatusCode);
        Assert.Equal("/login", Where(closed));
    }

    [Fact]
    public async Task Pages_need_a_signed_in_person_and_the_sign_in_page_does_not()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        var home = await Get(http, "/");
        Assert.Equal(HttpStatusCode.Redirect, home.StatusCode);
        Assert.StartsWith("/login", Where(home));
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/login")).StatusCode);
        Assert.Equal(HttpStatusCode.Redirect, (await Get(http, "/export/sales.csv")).StatusCode);
    }

    [Fact]
    public async Task A_wrong_password_does_not_sign_in_and_a_right_one_does_with_a_safe_cookie()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        Assert.Equal("", await SignIn(http, "owner", "not the password"));
        var cookie = await SignIn(http, "owner", "correct horse battery");
        Assert.Contains("hub.session=", cookie);
        var home = await Get(http, "/", cookie);
        Assert.Equal(HttpStatusCode.OK, home.StatusCode);

        var login = await Get(http, "/login");
        var sessionCookie = (await http.SendAsync(Post(http, "/login", login, "owner", "correct horse battery"))).Headers.GetValues("Set-Cookie").First(c => c.StartsWith("hub.session=", StringComparison.Ordinal));
        Assert.Contains("httponly", sessionCookie, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("samesite=strict", sessionCookie, StringComparison.OrdinalIgnoreCase);
    }

    private static HttpRequestMessage Post(HttpClient http, string path, HttpResponseMessage page, string user, string password)
    {
        var html = page.Content.ReadAsStringAsync().Result;
        var token = Regex.Match(html, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var formName = Regex.Match(html, "name=\"_handler\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var request = new HttpRequestMessage(HttpMethod.Post, path) { Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["__RequestVerificationToken"] = token, ["_handler"] = formName, ["Username"] = user, ["Password"] = password }) };
        request.Headers.Add("Cookie", string.Join("; ", page.Headers.GetValues("Set-Cookie").Select(c => c.Split(';')[0])));
        return request;
    }

    [Fact]
    public async Task A_sign_in_form_without_the_antiforgery_token_is_refused()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        var response = await http.PostAsync("/login", new FormUrlEncodedContent(new Dictionary<string, string> { ["Username"] = "owner", ["Password"] = "correct horse battery" }));
        Assert.True(response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Forbidden, "status " + response.StatusCode);
        Assert.False(response.Headers.Contains("Set-Cookie") && response.Headers.GetValues("Set-Cookie").Any(c => c.StartsWith("hub.session=", StringComparison.Ordinal)));
    }

    [Fact]
    public async Task Every_answer_carries_the_security_headers()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var response = await Get(Client(f), "/login");
        Assert.Equal("nosniff", response.Headers.GetValues("X-Content-Type-Options").Single());
        Assert.Equal("DENY", response.Headers.GetValues("X-Frame-Options").Single());
        Assert.Equal("no-referrer", response.Headers.GetValues("Referrer-Policy").Single());
        var csp = string.Join(" ; ", response.Headers.GetValues("Content-Security-Policy"));
        Assert.Contains("default-src 'self'", csp);
        Assert.Contains("frame-ancestors 'none'", csp);
        Assert.DoesNotContain("script-src 'self' 'unsafe", csp);
    }

    [Fact]
    public async Task The_stock_movement_report_the_day_book_and_the_cash_books_are_files_for_people_who_may_see_reports()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        var owner = await SignIn(http, "owner", "correct horse battery");
        foreach (var path in new[] { "/export/stock-movement.csv", "/export/daybook.csv", "/export/moneybook.csv", "/export/moneybook.csv?way=cash", "/export/moneybook.csv?way=way:card" })
        {
            var csv = await Get(http, path, owner);
            Assert.Equal(HttpStatusCode.OK, csv.StatusCode);
            Assert.StartsWith("text/csv", csv.Content.Headers.ContentType!.ToString());
        }
        Assert.Equal(HttpStatusCode.NotFound, (await Get(http, "/export/moneybook.csv?way=nonsense", owner)).StatusCode);

        var cashier = await SignIn(http, "till", "another good password");
        foreach (var path in new[] { "/export/stock-movement.csv", "/export/daybook.csv", "/export/moneybook.csv" })
            Assert.NotEqual(HttpStatusCode.OK, (await Get(http, path, cashier)).StatusCode);
    }

    [Fact]
    public async Task Reports_as_files_are_for_people_allowed_to_see_reports()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        var owner = await SignIn(http, "owner", "correct horse battery");
        var csv = await Get(http, "/export/sales.csv", owner);
        Assert.Equal(HttpStatusCode.OK, csv.StatusCode);
        Assert.StartsWith("text/csv", csv.Content.Headers.ContentType!.ToString());
        var cashier = await SignIn(http, "till", "another good password");
        Assert.NotEqual(HttpStatusCode.OK, (await Get(http, "/export/sales.csv", cashier)).StatusCode);
        Assert.Equal(HttpStatusCode.NotFound, (await Get(http, "/export/nonsense.csv", owner)).StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, (await Get(http, "/export/sales.csv?from=2020-01-01&to=2026-01-01", owner)).StatusCode);
    }

    [Fact]
    public async Task A_person_switched_off_is_signed_out_at_their_next_request()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        var cashier = await SignIn(http, "till", "another good password");
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/", cashier)).StatusCode);
        var till = f.Hub.Users.List().First(u => u.Username == "till");
        f.Hub.Users.SetActive(till.Id, false, null);
        var after = await Get(http, "/", cashier);
        Assert.Equal(HttpStatusCode.Redirect, after.StatusCode);
    }

    [Fact]
    public async Task Signing_out_needs_the_antiforgery_token()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        var owner = await SignIn(http, "owner", "correct horse battery");
        var request = new HttpRequestMessage(HttpMethod.Post, "/logout");
        request.Headers.Add("Cookie", owner);
        var response = await http.SendAsync(request);
        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/", "/")]
    [InlineData("/sell", "/sell")]
    [InlineData("//evil.example", "/")]
    [InlineData("https://evil.example", "/")]
    [InlineData("/\\evil.example", "/")]
    [InlineData("", "/")]
    [InlineData(null, "/")]
    public void The_page_after_signing_in_is_always_a_page_of_this_program(string? asked, string expected) =>
        Assert.Equal(expected, NextGenOS.Hub.Web.Components.Pages.Login.Local(asked));
}

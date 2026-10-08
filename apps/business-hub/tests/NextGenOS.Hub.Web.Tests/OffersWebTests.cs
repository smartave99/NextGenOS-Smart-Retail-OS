using System.Net;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The Offers screen is for the people who may give discounts (owners and managers); a cashier uses what the shop made at the till but cannot make or change it.</summary>
public class OffersWebTests
{
    private static HttpClient Client(HubWebFactory factory)
    {
        var http = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = false, HandleCookies = false });
        http.DefaultRequestHeaders.Accept.ParseAdd("text/html");
        return http;
    }

    private static void SetUp(HubWebFactory f)
    {
        f.Hub.Shop.Save(new ShopSettings { Name = "Test Shop", Country = "IN", Region = "27", Industry = "retail", SetupDone = true });
        f.Hub.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery");
        f.Hub.Users.Create("boss", "Mia Manager", Roles.Manager, "manager good password");
        f.Hub.Users.Create("till", "Tara Till", Roles.Cashier, "another good password");
    }

    private static async Task<string> SignIn(HttpClient http, string user, string password)
    {
        var page = await http.GetAsync("/login");
        var html = await page.Content.ReadAsStringAsync();
        var token = Regex.Match(html, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var formName = Regex.Match(html, "name=\"_handler\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var cookies = string.Join("; ", page.Headers.GetValues("Set-Cookie").Select(c => c.Split(';')[0]));
        var request = new HttpRequestMessage(HttpMethod.Post, "/login") { Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["__RequestVerificationToken"] = token, ["_handler"] = formName, ["Username"] = user, ["Password"] = password }) };
        request.Headers.Add("Cookie", cookies);
        var response = await http.SendAsync(request);
        var session = response.Headers.GetValues("Set-Cookie").First(c => c.StartsWith("hub.session=", StringComparison.Ordinal));
        return cookies + "; " + session.Split(';')[0];
    }

    private static async Task<HttpResponseMessage> Get(HttpClient http, string path, string cookie = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        if (cookie.Length > 0) request.Headers.Add("Cookie", cookie);
        return await http.SendAsync(request);
    }

    [Fact]
    public void Owners_and_managers_may_give_discounts_and_so_make_offers_and_nobody_else_may()
    {
        Assert.True(Roles.Can(Roles.Owner, Perm.Discount));
        Assert.True(Roles.Can(Roles.Manager, Perm.Discount));
        foreach (var role in new[] { Roles.Cashier, Roles.Kitchen, Roles.Librarian }) Assert.False(Roles.Can(role, Perm.Discount), role);
    }

    [Fact]
    public async Task The_offers_screen_opens_for_the_owner_and_the_manager_and_not_for_a_cashier_or_a_stranger()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);

        var stranger = await Get(http, "/offers");
        Assert.Equal(HttpStatusCode.Redirect, stranger.StatusCode);
        Assert.Contains("/login", stranger.Headers.Location!.OriginalString);
        foreach (var (user, password) in new[] { ("owner", "correct horse battery"), ("boss", "manager good password") })
        {
            var page = await Get(http, "/offers", await SignIn(http, user, password));
            Assert.Equal(HttpStatusCode.OK, page.StatusCode);
        }
        var cashier = await Get(http, "/offers", await SignIn(http, "till", "another good password"));
        Assert.NotEqual(HttpStatusCode.OK, cashier.StatusCode);
        Assert.Contains("/denied", cashier.Headers.Location?.OriginalString ?? "");
    }

    [Fact]
    public async Task The_tax_registers_open_for_the_people_who_may_see_reports_and_the_downloads_need_the_same_right()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        Assert.Equal(HttpStatusCode.Redirect, (await Get(http, "/registers")).StatusCode);
        foreach (var (user, password) in new[] { ("owner", "correct horse battery"), ("boss", "manager good password") })
        {
            var cookie = await SignIn(http, user, password);
            Assert.Equal(HttpStatusCode.OK, (await Get(http, "/registers", cookie)).StatusCode);
            Assert.Equal(HttpStatusCode.OK, (await Get(http, "/export/register-sales.csv", cookie)).StatusCode);
            Assert.Equal(HttpStatusCode.OK, (await Get(http, "/export/codes.csv", cookie)).StatusCode);
            Assert.Equal(HttpStatusCode.OK, (await Get(http, "/export/summary.csv", cookie)).StatusCode);
            Assert.Equal(HttpStatusCode.OK, (await Get(http, "/export/list-b2b.csv", cookie)).StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, (await Get(http, "/export/list-nothing.csv", cookie)).StatusCode);
        }
        var till = await SignIn(http, "till", "another good password");
        Assert.Contains("/denied", (await Get(http, "/registers", till)).Headers.Location?.OriginalString ?? "");
        Assert.NotEqual(HttpStatusCode.OK, (await Get(http, "/export/register-sales.csv", till)).StatusCode);
    }

    [Fact]
    public async Task Opening_the_offers_screen_changes_nothing()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);
        long Count() => Convert.ToInt64(f.Hub.Db.Scalar("SELECT (SELECT COUNT(*) FROM offers) + (SELECT COUNT(*) FROM vouchers) + (SELECT COUNT(*) FROM document_offers) + (SELECT COUNT(*) FROM party_discounts)"));
        var before = Count();
        var owner = await SignIn(http, "owner", "correct horse battery");
        foreach (var path in new[] { "/offers", "/sell", "/people" }) Assert.Equal(HttpStatusCode.OK, (await Get(http, path, owner)).StatusCode);
        Assert.Equal(before, Count());
    }
}

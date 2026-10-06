using System.Net;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The AI settings screen: who may open it, what it says without and with the licence, and that merely looking at it changes nothing.</summary>
public class AiSettingsWebTests
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
    public async Task The_licence_decides_whether_the_AI_parts_exist_and_opening_the_screen_changes_nothing()
    {
        // The screen is drawn live in the browser (the browser test checks its words); here: what the server decides and keeps.
        foreach (var modules in new[] { new[] { "hub" }, new[] { "hub", "ai" } })
        {
            using var f = new HubWebFactory { Modules = modules };
            SetUp(f);
            var http = Client(f);
            var owner = await SignIn(http, "owner", "correct horse battery");

            var page = await Get(http, "/settings/ai", owner);

            Assert.Equal(HttpStatusCode.OK, page.StatusCode);
            Assert.Equal(modules.Contains("ai"), f.Hub.Ai.Flags.Licensed);
            Assert.All(f.Hub.Ai.Flags.All(), s => { Assert.False(s.Chosen); Assert.False(s.Effective); });
            Assert.Empty(f.Hub.Ai.Providers.List());
            Assert.Empty(f.Hub.Ai.Models.List());
            Assert.Empty(f.Hub.Ai.Usage.Recent());
        }
    }

    [Fact]
    public async Task A_signed_out_person_is_sent_to_sign_in_and_the_manager_is_not_the_owner()
    {
        using var f = new HubWebFactory { Modules = ["hub", "ai"] };
        SetUp(f);
        var http = Client(f);

        var anonymous = await Get(http, "/settings/ai");
        Assert.Equal(HttpStatusCode.Redirect, anonymous.StatusCode);
        Assert.Contains("/login", anonymous.Headers.Location!.OriginalString);

        Assert.True(Roles.Can(Roles.Owner, Perm.Ai));
        Assert.False(Roles.Can(Roles.Manager, Perm.Ai));
        // A manager can sign in; the screen itself says "not for your role" (checked in the browser test), and nothing about the AI is changed by trying.
        var manager = await SignIn(http, "boss", "manager good password");
        await Get(http, "/settings/ai", manager);
        Assert.All(f.Hub.Ai.Flags.All(), s => Assert.False(s.Chosen));
    }

    [Fact]
    public void The_program_asks_the_signed_licence_for_the_AI_part_and_a_licence_that_is_not_usable_allows_nothing()
    {
        var withAi = new NextGenOS.Licensing.AspNetCore.ProductLicence(() => new NextGenOS.Licensing.LicenceState { Status = NextGenOS.Licensing.LicenceStatus.Valid, Licence = new NextGenOS.Licensing.LicenceClaims { Modules = ["hub", "ai"] } });
        var without = new NextGenOS.Licensing.AspNetCore.ProductLicence(() => new NextGenOS.Licensing.LicenceState { Status = NextGenOS.Licensing.LicenceStatus.Valid, Licence = new NextGenOS.Licensing.LicenceClaims { Modules = ["hub"] } });
        var expired = new NextGenOS.Licensing.AspNetCore.ProductLicence(() => new NextGenOS.Licensing.LicenceState { Status = NextGenOS.Licensing.LicenceStatus.Expired, Licence = new NextGenOS.Licensing.LicenceClaims { Modules = ["hub", "ai"] } });
        var missing = new NextGenOS.Licensing.AspNetCore.ProductLicence(() => new NextGenOS.Licensing.LicenceState { Status = NextGenOS.Licensing.LicenceStatus.Missing });
        Assert.True(NextGenOS.Hub.Web.Auth.LicenceEntitlements.From(withAi).Has("ai"));
        Assert.False(NextGenOS.Hub.Web.Auth.LicenceEntitlements.From(without).Has("ai"));
        Assert.False(NextGenOS.Hub.Web.Auth.LicenceEntitlements.From(expired).Has("ai"));
        Assert.False(NextGenOS.Hub.Web.Auth.LicenceEntitlements.From(missing).Has("ai"));
    }
}

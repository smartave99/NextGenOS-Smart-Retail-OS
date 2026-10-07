using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;
using NextGenOS.Hub.Web.Components.Shared;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>Settings, "Move from the older POS": only the owner may open it. (The reading and the move themselves are tested without a screen, in the domain tests.)</summary>
public class MoveFromOlderPosWebTests
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

    /// <summary>Draws the move-from-the-older-POS part of the screen the way the browser would, for a person with this role, and gives the page's HTML.</summary>
    private static async Task<string> Render(HubWebFactory f, string role)
    {
        using var scope = f.Services.CreateScope();
        var services = scope.ServiceProvider;
        var identity = new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, "1"), new Claim(ClaimTypes.Name, "Someone"), new Claim(ClaimTypes.Role, role)], "test");
        ((IHostEnvironmentAuthenticationStateProvider)services.GetRequiredService<AuthenticationStateProvider>()).SetAuthenticationState(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        await using var renderer = new HtmlRenderer(services, services.GetRequiredService<ILoggerFactory>());
        return await renderer.Dispatcher.InvokeAsync(async () => (await renderer.RenderComponentAsync<MoveFromOlderPos>()).ToHtmlString());
    }

    [Fact]
    public void Only_the_owner_has_the_permission_the_tab_and_its_actions_need()
    {
        Assert.True(Roles.Can(Roles.Owner, Perm.Settings));
        foreach (var role in new[] { Roles.Manager, Roles.Cashier, Roles.Kitchen, Roles.Librarian })
            Assert.False(Roles.Can(role, Perm.Settings), role);
    }

    [Fact]
    public async Task The_settings_page_is_open_to_the_owner_and_not_to_the_manager_or_the_cashier()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var http = Client(f);

        Assert.Equal(HttpStatusCode.Redirect, (await Get(http, "/settings?tab=older")).StatusCode);   // signed out: to the sign-in page
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/settings?tab=older", await SignIn(http, "owner", "correct horse battery"))).StatusCode);
        foreach (var (user, password) in new[] { ("boss", "manager good password"), ("till", "another good password") })
        {
            var response = await Get(http, "/settings?tab=older", await SignIn(http, user, password));
            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("/denied", response.Headers.Location?.OriginalString ?? "");
        }
    }

    [Fact]
    public async Task The_owner_sees_the_form_with_a_password_box_and_everyone_else_sees_only_that_it_is_for_the_owner()
    {
        using var f = new HubWebFactory();
        SetUp(f);

        var owner = await Render(f, Roles.Owner);
        Assert.Contains("Move from the older POS", owner);
        Assert.Contains("id=\"op-server\"", owner);
        Assert.Contains("id=\"op-db\"", owner);
        Assert.Contains("id=\"op-user\"", owner);
        Assert.Matches("<input[^>]*id=\"op-pass\"[^>]*type=\"password\"|<input[^>]*type=\"password\"[^>]*id=\"op-pass\"", owner);   // the password is a password box, never plain text
        Assert.DoesNotContain("autocomplete=\"on\"", owner);
        Assert.Contains("id=\"op-check\"", owner);
        Assert.DoesNotContain("id=\"op-import\"", owner);      // nothing to move until a check has been read
        Assert.DoesNotContain("older-report", owner);

        foreach (var role in new[] { Roles.Manager, Roles.Cashier })
        {
            var other = await Render(f, role);
            Assert.Contains("Only the owner can move data from an older program", other);
            Assert.DoesNotContain("id=\"op-server\"", other);
            Assert.DoesNotContain("id=\"op-check\"", other);
            Assert.DoesNotContain("id=\"op-pass\"", other);
        }
    }

    [Fact]
    public async Task The_screen_text_has_no_country_word_and_opening_the_screen_changes_nothing()
    {
        using var f = new HubWebFactory();
        SetUp(f);
        var before = Convert.ToInt64(f.Hub.Db.Scalar("SELECT (SELECT COUNT(*) FROM items) + (SELECT COUNT(*) FROM parties) + (SELECT COUNT(*) FROM import_runs) + (SELECT COUNT(*) FROM audit_log)"));

        var html = await Render(f, Roles.Owner);

        foreach (var word in new[] { "India", "Indian", "rupee", "Hindi", "GST", "CGST", "SGST", "IGST", "HSN", "INR", "₹" })
            Assert.DoesNotContain(word, html, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(before, Convert.ToInt64(f.Hub.Db.Scalar("SELECT (SELECT COUNT(*) FROM items) + (SELECT COUNT(*) FROM parties) + (SELECT COUNT(*) FROM import_runs) + (SELECT COUNT(*) FROM audit_log)")));
    }
}

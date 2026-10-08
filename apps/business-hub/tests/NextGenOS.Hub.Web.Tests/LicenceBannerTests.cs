using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;
using NextGenOS.Hub.Web.Components.Layout;
using NextGenOS.Licensing;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>What a licence that is not simply "active" says across every screen (decision 15, blueprint LIC-015): a trial says when it ends, a paid licence that has ended says it keeps working, a PC that could not check in says how long it still works.</summary>
public class LicenceBannerTests
{
    private static long Unix(DateTime utc) => (long)(utc - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

    /// <summary>Draws the Hub's frame (the side menu, the top bar and the licence banner) around a plain page, the way the browser would, and gives the HTML.</summary>
    private static async Task<string> Frame(HubWebFactory f)
    {
        f.Hub.Shop.Save(new ShopSettings { Name = "Test Shop", Country = "IN", Region = "27", Industry = "retail", SetupDone = true });
        using var scope = f.Services.CreateScope();
        var services = scope.ServiceProvider;
        var identity = new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, "1"), new Claim(ClaimTypes.Name, "Someone"), new Claim(ClaimTypes.Role, Roles.Owner)], "test");
        ((IHostEnvironmentAuthenticationStateProvider)services.GetRequiredService<AuthenticationStateProvider>()).SetAuthenticationState(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        ((IHostEnvironmentNavigationManager)services.GetRequiredService<NavigationManager>()).Initialize("http://localhost/", "http://localhost/");
        await using var renderer = new HtmlRenderer(services, services.GetRequiredService<ILoggerFactory>());
        return await renderer.Dispatcher.InvokeAsync(async () =>
        {
            RenderFragment body = b => b.AddContent(0, "A plain page");
            var parameters = ParameterView.FromDictionary(new Dictionary<string, object?> { ["Body"] = body });
            return (await renderer.RenderComponentAsync<MainLayout>(parameters)).ToHtmlString();
        });
    }

    [Fact]
    public async Task An_active_licence_shows_no_banner()
    {
        using var f = new HubWebFactory();
        Assert.DoesNotContain("licence-banner", await Frame(f));
    }

    [Fact]
    public async Task A_trial_says_when_it_ends_and_that_the_program_stops_then()
    {
        using var f = new HubWebFactory { ShapeLicence = s => { s.Licence.Trial = true; s.Licence.End = "stop"; s.Licence.Expires = Unix(new DateTime(2099, 3, 4, 0, 0, 0, DateTimeKind.Utc)); } };
        var html = await Frame(f);
        Assert.Contains("id=\"licence-banner\"", html);
        Assert.Contains("This is a trial. It ends on", html);
        Assert.Contains("and then the program stops", html);
    }

    [Fact]
    public async Task A_paid_licence_that_has_ended_says_so_and_that_the_shop_keeps_working()
    {
        using var f = new HubWebFactory { ShapeLicence = s => { s.Status = LicenceStatus.Ended; s.Licence.End = "banner"; s.Licence.Expires = Unix(new DateTime(2026, 1, 15, 0, 0, 0, DateTimeKind.Utc)); } };
        var html = await Frame(f);
        Assert.Contains("id=\"licence-banner\"", html);
        Assert.Contains("ended on", html);
        Assert.Contains("The program keeps working", html);
    }

    [Fact]
    public async Task A_PC_that_could_not_check_in_says_how_many_days_it_still_works()
    {
        using var f = new HubWebFactory { ShapeLicence = s => { s.Status = LicenceStatus.Grace; s.GraceDaysLeft = 6; } };
        var html = await Frame(f);
        Assert.Contains("id=\"licence-banner\"", html);
        Assert.Contains("It works for 6 more days", html);
    }
}

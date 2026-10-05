using System.Security.Claims;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Features;
using NextGenOS.Hub.Reports;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Web.Auth;
using NextGenOS.Hub.Web.Components;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web;

/// <summary>How the Hub program is put together. The program and the tests build it the same way (the tests only swap what stands in for the licence).</summary>
public static class HubHost
{
    public const string CookieName = "hub.session";
    public const string CsrfHeader = "RequestVerificationToken";

    /// <summary>Where the shop's data lives: the Hub:DataFolder setting, or a folder of the PC (ProgramData on Windows).</summary>
    public static string DataFolder(IConfiguration configuration)
    {
        var chosen = configuration["Hub:DataFolder"];
        if (!string.IsNullOrWhiteSpace(chosen)) return Path.GetFullPath(chosen);
        var root = OperatingSystem.IsWindows()
            ? Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
            : Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(root, "NextGenOS", "Hub");
    }

    public static void AddHub(WebApplicationBuilder builder)
    {
        var folder = DataFolder(builder.Configuration);
        Directory.CreateDirectory(folder);
        var services = builder.Services;

        services.AddSingleton(_ => HubApp.Open(Path.Combine(folder, "shop.db")));

        // The sign-in cookie is protected with keys kept in the data folder (and, on Windows, locked to this PC), so a restart does not sign everyone out.
        var protection = services.AddDataProtection().SetApplicationName("NextGenOS.Hub").PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(folder, "keys")));
        if (OperatingSystem.IsWindows()) protection.ProtectKeysWithDpapi(protectToLocalMachine: true);

        services.AddHttpContextAccessor();
        services.AddAntiforgery(o => { o.HeaderName = CsrfHeader; o.Cookie.Name = "hub.csrf"; o.Cookie.SameSite = SameSiteMode.Strict; o.Cookie.HttpOnly = true; });
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o =>
        {
            o.Cookie.Name = CookieName;
            o.Cookie.HttpOnly = true;
            o.Cookie.SameSite = SameSiteMode.Strict;
            o.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            o.LoginPath = "/login";
            o.AccessDeniedPath = "/denied";
            o.ExpireTimeSpan = TimeSpan.FromHours(12);
            o.SlidingExpiration = false;
            o.Events.OnValidatePrincipal = async context =>
            {
                // Every request: the person must still be on, with the same role as when they signed in.
                var app = context.HttpContext.RequestServices.GetRequiredService<HubApp>();
                var id = context.Principal?.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = long.TryParse(id, out var n) ? app.Users.Get(n) : null;
                if (user is null || !user.Active || user.Role != context.Principal?.FindFirstValue(ClaimTypes.Role))
                {
                    context.RejectPrincipal();
                    await context.HttpContext.SignOutAsync();
                }
            };
        });
        services.AddAuthorization(o =>
        {
            o.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            foreach (var permission in Permissions.All) o.AddPolicy(permission, p => p.RequireAuthenticatedUser().RequireAssertion(c => Roles.Can(c.User.FindFirstValue(ClaimTypes.Role) ?? "", permission)));
        });
        services.AddCascadingAuthenticationState();
        services.AddScoped<Session>();
        services.AddSingleton<SetupState>();
        services.AddLicensedWorker<HubWorker>();

        // The signed licence: the Hub runs only with a valid one that includes the "hub" module.
        services.AddNextGenOSLicence("hub", typeof(HubHost).Assembly.GetName().Version?.ToString() ?? "0.0.0");

        services.AddRazorComponents().AddInteractiveServerComponents().AddHubOptions(o => o.MaximumReceiveMessageSize = 128 * 1024);
    }

    public static void UseHub(WebApplication app)
    {
        // First of all: nothing is served, not even a static file, without a usable licence.
        app.UseLicenceGate();
        app.Use(SecurityHeaders);
        if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/error", createScopeForErrors: true);
        app.UseAuthentication();
        app.Use(SetupFirst);
        app.UseAuthorization();
        app.UseAntiforgery();
        app.MapStaticAssets();

        app.MapGet("/health", () => Results.Text("ok")).AllowAnonymous();
        app.MapPost("/logout", async (HttpContext http, IAntiforgery antiforgery) =>
        {
            await antiforgery.ValidateRequestAsync(http);
            await http.SignOutAsync();
            return Results.Ok();
        });
        app.MapGet("/export/{report}.csv", ExportEndpoint.Handle).RequireAuthorization(Perm.Reports);
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode(o => o.ContentSecurityFrameAncestorsPolicy = "'none'");

        var hub = app.Services.GetRequiredService<HubApp>();
        hub.Documents.DiscardStaleDrafts();
    }

    /// <summary>Headers on every answer: nothing from another site runs, the page cannot be framed, and nothing is guessed about file types.</summary>
    private static Task SecurityHeaders(HttpContext context, RequestDelegate next)
    {
        var h = context.Response.Headers;
        h["X-Content-Type-Options"] = "nosniff";
        h["X-Frame-Options"] = "DENY";
        h["Referrer-Policy"] = "no-referrer";
        h["Cross-Origin-Opener-Policy"] = "same-origin";
        h["Permissions-Policy"] = "camera=(self), microphone=(), geolocation=(), payment=()";
        h.ContentSecurityPolicy = "default-src 'self'; script-src 'self'; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self'; connect-src 'self' ws: wss:; frame-ancestors 'none'; base-uri 'self'; form-action 'self'; object-src 'none'";
        return next(context);
    }

    /// <summary>Until the shop is set up, every page goes to the setup; afterwards the setup page is closed for good.</summary>
    private static async Task SetupFirst(HttpContext context, RequestDelegate next)
    {
        var path = context.Request.Path;
        var hub = context.RequestServices.GetRequiredService<HubApp>();
        var state = context.RequestServices.GetRequiredService<SetupState>();
        var done = state.IsDone(hub);
        var isSetup = path.StartsWithSegments("/setup");
        var plumbing = path.StartsWithSegments("/_blazor") || path.StartsWithSegments("/_framework") || path.StartsWithSegments("/health") || Path.HasExtension(path.Value);
        if (!done && !isSetup && !plumbing && HttpMethods.IsGet(context.Request.Method))
        {
            context.Response.Redirect("/setup");
            return;
        }

        if (done && isSetup && HttpMethods.IsGet(context.Request.Method))
        {
            context.Response.Redirect("/login");
            return;
        }

        await next(context);
    }
}

/// <summary>Remembers that the shop has been set up, so the database is not asked on every request after that.</summary>
public sealed class SetupState
{
    private volatile bool _done;

    public bool IsDone(HubApp app)
    {
        if (_done) return true;
        if (app.Shop.Settings.SetupDone && app.Users.Any()) _done = true;
        return _done;
    }

    public void Finished() => _done = true;
}

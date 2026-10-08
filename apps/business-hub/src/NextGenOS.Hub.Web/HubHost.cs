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
    public const string DocumentsPolicy = "documents";

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

    /// <summary>
    /// The builder both programs start from. The program's own folder is its home, not whatever folder it was started from: a Windows service
    /// starts in System32, and a shortcut can start it anywhere, so looking for files in "the current folder" would find none of ours.
    /// </summary>
    public static WebApplicationBuilder CreateBuilder(string[] args)
    {
        // Numbers, dates and text are written the same on every PC, whatever language the PC is set to: the shop's own settings (country pack) decide how money and dates look.
        System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
        System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        System.Globalization.CultureInfo.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { Args = args, ContentRootPath = AppContext.BaseDirectory });
        // On a shop PC the Hub runs as a Windows service, so it is there when the PC starts, before anyone signs in. Started by hand (or on another
        // system) this does nothing.
        builder.Host.UseWindowsService(o => o.ServiceName = ServiceName);
        return builder;
    }

    public const string ServiceName = "NextGenOSHub";

    public static void AddHub(WebApplicationBuilder builder)
    {
        var folder = DataFolder(builder.Configuration);
        Directory.CreateDirectory(folder);
        var services = builder.Services;

        // The AI parts of the Hub are allowed only when the signed licence has the "ai" module (and they are all off until the owner switches them on).
        services.AddSingleton(sp => HubApp.Open(Path.Combine(folder, "shop.db"), ai: new NextGenOS.Hub.Ai.AiOptions(LicenceEntitlements.From(sp.GetRequiredService<NextGenOS.Licensing.AspNetCore.ProductLicence>()))));

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
            // Everything needs a signed-in person, except the live connection (/_blazor): it is opened before anyone is known, by the sign-in and setup
            // screens too, and what each screen shows is decided inside it by [Authorize] on every page (Components/Pages/_Imports.razor).
            o.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
                .RequireAssertion(c => c.User.Identity?.IsAuthenticated == true || (c.Resource is HttpContext http && http.Request.Path.StartsWithSegments("/_blazor")))
                .Build();
            foreach (var permission in Permissions.All) o.AddPolicy(permission, p => p.RequireAuthenticatedUser().RequireAssertion(c => Roles.Can(c.User.FindFirstValue(ClaimTypes.Role) ?? "", permission)));
            // Anyone who works with bills, loans or bookings may look at the bills.
            o.AddPolicy(DocumentsPolicy, p => p.RequireAuthenticatedUser().RequireAssertion(c =>
            {
                var role = c.User.FindFirstValue(ClaimTypes.Role) ?? "";
                return new[] { Perm.Sell, Perm.Orders, Perm.Loans, Perm.Appointments, Perm.Projects, Perm.Reports }.Any(x => Roles.Can(role, x));
            }));
        });
        services.AddCascadingAuthenticationState();
        services.AddScoped<Session>();
        services.AddSingleton<SetupState>();
        // The look the owner chose on this PC; the licence's white-label level decides how much of it shows (BrandService).
        services.AddSingleton<NextGenOS.Hub.Web.Branding.ProfileStore>();
        services.AddSingleton<NextGenOS.Hub.Web.Branding.LocalThemeStore>();
        services.AddSingleton<NextGenOS.Hub.Web.Branding.ShopLookStore>();
        services.AddSingleton<NextGenOS.Hub.Web.Branding.ThemeService>();
        services.AddSingleton<NextGenOS.Hub.Web.Branding.LocalBrandStore>();
        services.AddSingleton<NextGenOS.Hub.Web.Branding.ProfiledBrand>();
        services.AddSingleton<NextGenOS.Licensing.AspNetCore.IBrandOverrides>(sp => sp.GetRequiredService<NextGenOS.Hub.Web.Branding.ProfiledBrand>());
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
        app.MapStaticAssets().AllowAnonymous();

        app.MapGet("/health", () => Results.Text("ok")).AllowAnonymous();
        app.MapGet("/tokens.css", (HttpContext http) =>
        {
            http.Response.Headers.CacheControl = "no-cache";
            return Results.File(Tokens.Value, "text/css; charset=utf-8", entityTag: Tokens.Tag);
        }).AllowAnonymous();
        app.MapPost("/logout", async (HttpContext http, IAntiforgery antiforgery) =>
        {
            await antiforgery.ValidateRequestAsync(http);
            await http.SignOutAsync();
            return Results.Ok();
        });
        app.MapGet("/export/{report}.csv", ExportEndpoint.Handle).RequireAuthorization(Perm.Reports);
        DeviceEndpoints.Map(app);
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode(o => o.ContentSecurityFrameAncestorsPolicy = "'none'");
        // Nothing is done in the shop's database until there is a licence: the background upkeep (HubWorker) starts with the licence, and the first request that needs the shop opens it.
    }

    private static class Tokens
    {
        public static readonly byte[] Value = Load();
        public static readonly Microsoft.Net.Http.Headers.EntityTagHeaderValue Tag = new("\"" + Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(Value))[..16] + "\"");

        private static byte[] Load()
        {
            using var stream = typeof(HubHost).Assembly.GetManifestResourceStream("tokens.css") ?? throw new InvalidOperationException("tokens.css is missing from the program.");
            using var copy = new MemoryStream();
            stream.CopyTo(copy);
            return copy.ToArray();
        }
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

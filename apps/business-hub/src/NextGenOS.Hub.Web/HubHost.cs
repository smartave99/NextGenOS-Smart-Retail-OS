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
using NextGenOS.Hub.Web.Counters;
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

    /// <param name="updates">Only for the browser tests: where to look for updates and whom to trust. The program passes nothing: it takes what its build kept (<see cref="NextGenOS.Hub.Web.Updates.UpdateHost"/>).</param>
    public static void AddHub(WebApplicationBuilder builder, NextGenOS.Hub.Updates.UpdateOptions? updates = null)
    {
        var folder = DataFolder(builder.Configuration);
        Directory.CreateDirectory(folder);
        var services = builder.Services;

        // The AI parts of the Hub are allowed only when the signed licence has the "ai" module (and they are all off until the owner switches them on).
        // Hub:BackupFolder is where the copy made before an update goes (a second disk is best); without it the copy is made next to the shop's file.
        var backupFolder = builder.Configuration["Hub:BackupFolder"];
        var shopFile = Path.Combine(folder, "shop.db");
        // Counter PCs on the shop's own network: off unless the owner chose it. Off, nothing is added and the Hub listens on this PC only, as it always did.
        var network = StoreNetworkHost.Add(builder, folder);
        services.AddSingleton(sp =>
        {
            // A copy the owner chose to put back (Settings, Backups, or the first screen of a PC with no shop) is put in place now, before the shop is opened: the running shop cannot swap its own file.
            var restored = NextGenOS.Hub.Backups.PendingRestore.ApplyIfPending(folder, shopFile);
            // The licence's number of PCs limits the counter PCs (the main PC counts as one); like the modules it is handed over as a function.
            var licence = sp.GetRequiredService<NextGenOS.Licensing.AspNetCore.ProductLicence>();
            var app = HubApp.Open(shopFile, ai: new NextGenOS.Hub.Ai.AiOptions(LicenceEntitlements.From(licence)), backupFolder: backupFolder,
                network: new NextGenOS.Hub.Counters.NetworkOptions(network, LicenceEntitlements.DeviceLimit(licence)),
                updates: updates ?? NextGenOS.Hub.Web.Updates.UpdateHost.FromBuild(folder));
            StoreNetworkHost.Connect(app, sp.GetRequiredService<ConnectionTracker>());
            if (restored is not null) app.Audit.Log(null, restored.Done ? "restore" : "restore-failed", "backup", null, restored.Message);
            return app;
        });

        // The sign-in cookie is protected with keys kept in the data folder (and, on Windows, locked to this PC), so a restart does not sign everyone out.
        var protection = services.AddDataProtection().SetApplicationName("NextGenOS.Hub").PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(folder, "keys")));
        if (OperatingSystem.IsWindows()) protection.ProtectKeysWithDpapi(protectToLocalMachine: true);

        // The Help button: the program remembers its last warnings and errors (in memory only) so that a support file can say what went wrong lately.
        var trouble = new NextGenOS.Hub.Web.Diagnostics.TroubleLog();
        services.AddSingleton(trouble);
        builder.Logging.AddProvider(trouble);
        services.AddSingleton<NextGenOS.Hub.Web.Diagnostics.SupportFileBuilder>();

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
        // Before even the licence page: a computer on the shop's network that was not paired with this shop gets one plain refusal and nothing else (it must not see the licence
        // page, or be able to type a licence key). Requests from this PC itself pass straight through, untouched.
        app.UseStoreNetworkGate();
        // Then: nothing is served, not even a static file, without a usable licence.
        app.UseLicenceGate();
        app.Use(SecurityHeaders);
        if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/error", createScopeForErrors: true);
        app.Use(ShopMustOpen);
        app.UseAuthentication();
        app.Use(SetupFirst);
        app.UseAuthorization();
        app.UseAntiforgery();
        app.MapStaticAssets().AllowAnonymous();

        StoreNetworkEndpoints.Map(app);
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
        ApplySecurityHeaders(context);
        return next(context);
    }

    /// <summary>The headers above, set on one answer (also used by the pages that are answered before this step, for computers that are not paired).</summary>
    internal static void ApplySecurityHeaders(HttpContext context)
    {
        var h = context.Response.Headers;
        h["X-Content-Type-Options"] = "nosniff";
        h["X-Frame-Options"] = "DENY";
        h["Referrer-Policy"] = "no-referrer";
        h["Cross-Origin-Opener-Policy"] = "same-origin";
        h["Permissions-Policy"] = "camera=(self), microphone=(), geolocation=(), payment=()";
        h.ContentSecurityPolicy = "default-src 'self'; script-src 'self'; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self'; connect-src 'self' ws: wss:; frame-ancestors 'none'; base-uri 'self'; form-action 'self'; object-src 'none'";
    }

    /// <summary>
    /// If the shop cannot be opened because an update could not make its safe copy first, every request gets one plain page that says so and what to check (the shop's data has not been
    /// touched). The page is built here, without the shop: the usual error page is drawn with the shop's own look and would need the shop to open, which is what failed.
    /// </summary>
    private static async Task ShopMustOpen(HttpContext context, RequestDelegate next)
    {
        try
        {
            _ = context.RequestServices.GetRequiredService<HubApp>();
        }
        catch (HubException e) when (e.Code == "backup")
        {
            var response = context.Response;
            response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            response.Headers.CacheControl = "no-store";
            response.Headers["Retry-After"] = "600";
            response.ContentType = "text/html; charset=utf-8";
            await response.WriteAsync(
                "<!doctype html><html lang=\"en\"><head><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"><title>The update has not started</title></head>" +
                "<body style=\"font-family:system-ui,sans-serif;max-width:40rem;margin:4rem auto;padding:0 1rem;line-height:1.5\"><h1>The update has not started</h1>" +
                "<p id=\"update-reason\">" + System.Net.WebUtility.HtmlEncode(e.Message) + "</p>" +
                "<p>Nothing was lost. When this is put right, open the program again.</p></body></html>");
            return;
        }

        await next(context);
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

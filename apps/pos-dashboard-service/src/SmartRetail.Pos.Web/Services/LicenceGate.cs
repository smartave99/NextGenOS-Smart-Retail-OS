using System.Net;
using Microsoft.AspNetCore.Components.Server.Circuits;
using NextGenOS.Licensing;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Without a usable licence the dashboard shows one page that says why and what to do, and answers nothing else: a browser
/// gets that page, anything else gets a short JSON answer, with status 402. It sits in front of everything, the static files
/// and the live connection included.
/// </summary>
public static class LicenceGate
{
    /// <summary>Looks at the licence again, then goes back to the dashboard. Allowed with no licence: it changes nothing.</summary>
    public const string RecheckPath = "/licence-recheck";

    public static IApplicationBuilder UseLicenceGate(this IApplicationBuilder app) => app.Use(async (context, next) =>
    {
        var licence = context.RequestServices.GetRequiredService<DashboardLicence>();
        if (context.Request.Path.Equals(RecheckPath, StringComparison.OrdinalIgnoreCase))
        {
            licence.Reload();
            context.Response.Redirect("/");
            return;
        }

        var state = licence.State;
        if (state.IsUsable)
        {
            await next();
            return;
        }

        var brand = context.RequestServices.GetRequiredService<BrandService>();
        context.Response.StatusCode = StatusCodes.Status402PaymentRequired;
        context.Response.Headers.CacheControl = "no-store";
        context.Response.Headers["X-Content-Type-Options"] = "nosniff";
        var wantsPage = HttpMethods.IsGet(context.Request.Method) && context.Request.Headers.Accept.ToString().Contains("text/html", StringComparison.OrdinalIgnoreCase);
        if (wantsPage)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            context.Response.Headers.ContentSecurityPolicy = "default-src 'none'; style-src 'unsafe-inline'; base-uri 'none'; form-action 'self'";
            await context.Response.WriteAsync(Page(state, brand));
        }
        else
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new { error = "licence", status = state.Status.ToString(), message = state.Message }));
        }
    });

    private const string PageTemplate = """
        <!DOCTYPE html>
        <html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1"><meta name="color-scheme" content="light dark">
        <title>@@NAME@@ · Licence</title>
        <style>
        :root{color-scheme:light dark;--bg:#f5f5f7;--card:#fff;--ink:#1d1d1f;--muted:#6e6e73;--accent:@@ACCENT@@}
        @media (prefers-color-scheme:dark){:root{--bg:#111113;--card:#1f1f22;--ink:#f5f5f7;--muted:#a1a1a6}}
        body{margin:0;min-height:100vh;display:grid;place-items:center;background:var(--bg);color:var(--ink);font:16px/1.5 "Segoe UI Variable Text","Segoe UI",system-ui,-apple-system,sans-serif}
        main{max-width:30rem;margin:1.5rem;padding:2rem 2.25rem;background:var(--card);border-radius:18px;box-shadow:0 2px 24px rgb(0 0 0 / .08)}
        h1{font-size:1.4rem;margin:0 0 .5rem}p{margin:.5rem 0}.muted{color:var(--muted);font-size:.9rem}
        a.btn{display:inline-block;margin-top:1rem;padding:.6rem 1.2rem;background:var(--accent);color:#fff;border-radius:999px;text-decoration:none;font-weight:600}
        </style></head><body><main>
        <h1>@@NAME@@ needs a licence</h1>
        <p>@@MESSAGE@@</p>
        <p class="muted">To activate, open the @@NAME@@ app on this PC and enter your licence key when asked. Then check again here.</p>
        <a class="btn" href="@@RECHECK@@">Check again</a>
        @@HELP@@
        </main></body></html>
        """;

    /// <summary>The page, with no outside file: it must show even when nothing else can load. Everything put in it is encoded.</summary>
    public static string Page(LicenceState state, BrandService brand)
    {
        static string E(string? text) => WebUtility.HtmlEncode(text ?? string.Empty);
        var help = new List<string>();
        if (brand.SupportEmail is { } email)
        {
            help.Add(E(email));
        }

        if (brand.SupportPhone is { } phone)
        {
            help.Add(E(phone));
        }

        var accent = BrandService.Hex(state.Licence?.Brand?.PrimaryColor) ?? "#0071e3";
        return PageTemplate
            .Replace("@@ACCENT@@", accent)
            .Replace("@@RECHECK@@", RecheckPath)
            .Replace("@@HELP@@", help.Count > 0 ? "<p class=\"muted\">Need help? " + string.Join(" · ", help) + "</p>" : string.Empty)
            .Replace("@@MESSAGE@@", E(state.Message))
            .Replace("@@NAME@@", E(brand.Name));
    }
}

/// <summary>A live screen stops the moment the licence is lost, not only the next page that is opened.</summary>
public sealed class LicenceCircuitHandler(DashboardLicence licence) : CircuitHandler
{
    public override Func<CircuitInboundActivityContext, Task> CreateInboundActivityHandler(Func<CircuitInboundActivityContext, Task> next) => async context =>
    {
        if (!licence.IsUsable)
        {
            throw new InvalidOperationException("The licence is no longer valid.");
        }

        await next(context);
    };
}

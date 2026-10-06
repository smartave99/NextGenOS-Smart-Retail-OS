using System.Net;
using Microsoft.AspNetCore.Components.Server.Circuits;
using NextGenOS.Licensing;

namespace NextGenOS.Licensing.AspNetCore;

/// <summary>
/// Without a usable licence the program shows one page that says why and what to do, and answers nothing else: a browser
/// gets that page, anything else gets a short JSON answer, with status 402. It sits in front of everything, the static files
/// and the live connection included.
/// </summary>
public static class LicenceGate
{
    /// <summary>Looks at the licence again, then goes back to the program. Allowed with no licence: it changes nothing.</summary>
    public const string RecheckPath = "/licence-recheck";

    /// <summary>Where a program with no licence lets the person enter a key (or paste a licence code) when it has a <see cref="LicenceManager"/> to activate with.</summary>
    public const string ActivatePath = "/licence-activate";

    public static IApplicationBuilder UseLicenceGate(this IApplicationBuilder app) => app.Use(async (context, next) =>
    {
        var licence = context.RequestServices.GetRequiredService<ProductLicence>();
        if (context.Request.Path.Equals(RecheckPath, StringComparison.OrdinalIgnoreCase))
        {
            licence.Reload();
            context.Response.Redirect("/");
            return;
        }

        var state = licence.State;
        if (state.IsUsable)
        {
            if (context.Request.Path.Equals(ActivatePath, StringComparison.OrdinalIgnoreCase))
            {
                context.Response.Redirect("/");
                return;
            }

            await next();
            return;
        }

        var brand = context.RequestServices.GetRequiredService<BrandService>();
        var manager = context.RequestServices.GetService<LicenceManager>();
        string? problem = null;
        if (manager is not null && context.Request.Path.Equals(ActivatePath, StringComparison.OrdinalIgnoreCase) && HttpMethods.IsPost(context.Request.Method))
        {
            problem = await TryActivateAsync(context, manager, licence);
            if (problem is null)
            {
                context.Response.Redirect("/");
                return;
            }
        }

        context.Response.StatusCode = StatusCodes.Status402PaymentRequired;
        context.Response.Headers.CacheControl = "no-store";
        context.Response.Headers["X-Content-Type-Options"] = "nosniff";
        var activating = problem is not null && context.Request.Path.Equals(ActivatePath, StringComparison.OrdinalIgnoreCase);
        var wantsPage = (HttpMethods.IsGet(context.Request.Method) || activating) && context.Request.Headers.Accept.ToString().Contains("text/html", StringComparison.OrdinalIgnoreCase);
        if (wantsPage)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            context.Response.Headers.ContentSecurityPolicy = "default-src 'none'; style-src 'unsafe-inline'; base-uri 'none'; form-action 'self'";
            await context.Response.WriteAsync(Page(state, brand, manager is not null, problem));
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
        form{margin:1rem 0 0}label{display:block;font-weight:600;font-size:.9rem;margin:.75rem 0 .25rem}
        input,textarea{box-sizing:border-box;width:100%;padding:.65rem .8rem;border:1px solid #8883;border-radius:12px;background:transparent;color:inherit;font:inherit}
        button{margin-top:.9rem;padding:.6rem 1.2rem;border:0;border-radius:999px;background:var(--accent);color:#fff;font:inherit;font-weight:600;cursor:pointer}
        .problem{margin:1rem 0 0;padding:.6rem .8rem;border-radius:12px;background:#fbe7e5;color:#8c1d18}
        a.btn{display:inline-block;margin-top:1rem;padding:.6rem 1.2rem;background:var(--accent);color:#fff;border-radius:999px;text-decoration:none;font-weight:600}
        </style></head><body><main>
        <h1>@@NAME@@ needs a licence</h1>
        <p>@@MESSAGE@@</p>
        @@ACTIVATE@@
        <a class="btn" href="@@RECHECK@@">Check again</a>
        @@HELP@@
        </main></body></html>
        """;

    private const string ActivateForm = """
        <form method="post" action="/licence-activate" autocomplete="off">
        <label for="key">Licence key</label>
        <input id="key" name="key" placeholder="NGOS-XXXXX-XXXXX-XXXXX-XXXXX" maxlength="64" autocomplete="off" autocapitalize="characters" spellcheck="false">
        <label for="code">Or paste a licence code (for a PC with no internet)</label>
        <textarea id="code" name="code" rows="3" maxlength="8000" spellcheck="false"></textarea>
        <button type="submit">Activate</button>
        </form>
        """;

    /// <summary>Takes a key or a licence code from the form. Returns what to tell the person when it did not work, or null when the licence is now usable.</summary>
    private static async Task<string?> TryActivateAsync(HttpContext context, LicenceManager manager, ProductLicence licence)
    {
        // The gate runs before anything else, so the same-site check is made here: a page on another site cannot activate a PC through the person's browser.
        var site = context.Request.Headers["Sec-Fetch-Site"].ToString();
        var origin = context.Request.Headers.Origin.ToString();
        var sameSite = (site.Length == 0 || site is "same-origin" or "none") &&
            (origin.Length == 0 || (Uri.TryCreate(origin, UriKind.Absolute, out var o) && string.Equals(o.Authority, context.Request.Host.Value, StringComparison.OrdinalIgnoreCase)));
        if (!sameSite || !context.Request.HasFormContentType || context.Request.ContentLength is > 20_000)
        {
            return "That could not be done from here. Open this page again and try once more.";
        }

        var form = await context.Request.ReadFormAsync(context.RequestAborted);
        var key = form["key"].ToString().Trim();
        var code = form["code"].ToString().Trim();
        try
        {
            if (code.Length > 0)
            {
                // Only the licence text itself: never a file name, so this page cannot be used to look at files on the PC.
                if (!code.Contains("NGOS1.", StringComparison.Ordinal))
                {
                    return "That does not look like a licence code.";
                }

                manager.ImportLicenceFile(code);
            }
            else if (key.Length > 0)
            {
                await manager.ActivateAsync(key, context.RequestAborted);
            }
            else
            {
                return "Please type your licence key.";
            }
        }
        catch (Exception ex) when (ex is LicenceException or LicenceServerException or HttpRequestException or TaskCanceledException)
        {
            return ex is HttpRequestException or TaskCanceledException ? "The licence server could not be reached. Check the internet connection and try again." : ex.Message;
        }

        return licence.Reload().IsUsable ? null : licence.State.Message;
    }

    /// <summary>The page, with no outside file: it must show even when nothing else can load. Everything put in it is encoded.</summary>
    public static string Page(LicenceState state, BrandService brand) => Page(state, brand, false, null);

    /// <summary>The same page with, when the program can activate itself, a place to enter the licence key or paste a licence code.</summary>
    public static string Page(LicenceState state, BrandService brand, bool canActivate, string? problem)
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
        var activate = canActivate
            ? (problem is null ? string.Empty : "<p class=\"problem\" role=\"alert\">" + E(problem) + "</p>") + ActivateForm
            : "<p class=\"muted\">To activate, open the @@NAME@@ app on this PC and enter your licence key when asked. Then check again here.</p>";
        return PageTemplate
            .Replace("@@ACTIVATE@@", activate)
            .Replace("@@ACCENT@@", accent)
            .Replace("@@RECHECK@@", RecheckPath)
            .Replace("@@HELP@@", help.Count > 0 ? "<p class=\"muted\">Need help? " + string.Join(" · ", help) + "</p>" : string.Empty)
            .Replace("@@MESSAGE@@", E(state.Message))
            .Replace("@@NAME@@", E(brand.Name));
    }
}

/// <summary>A live screen stops the moment the licence is lost, not only the next page that is opened.</summary>
public sealed class LicenceCircuitHandler(ProductLicence licence) : CircuitHandler
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

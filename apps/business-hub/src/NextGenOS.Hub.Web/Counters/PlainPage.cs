using System.Net;

namespace NextGenOS.Hub.Web.Counters;

/// <summary>
/// The few pages a computer sees before it has been paired (the refusal, the pairing page, the certificate page). They are self-contained on purpose: one answer with its own small style and
/// no script, no picture, no link to a file of the Hub, because a computer that is not paired is not allowed to fetch anything else. They carry no name, logo or colour of the shop or of
/// any company: a computer that has not been paired learns nothing about the shop.
/// </summary>
internal static class PlainPage
{
    private const string Style = """
        :root{color-scheme:light dark;--bg:#f5f5f7;--card:#fff;--ink:#1d1d1f;--muted:#6e6e73;--accent:#2c5fd4}
        @media (prefers-color-scheme:dark){:root{--bg:#111113;--card:#1f1f22;--ink:#f5f5f7;--muted:#a1a1a6;--accent:#6c97ff}}
        body{margin:0;min-height:100vh;display:grid;place-items:center;background:var(--bg);color:var(--ink);font:16px/1.5 "Segoe UI Variable Text","Segoe UI",system-ui,-apple-system,sans-serif}
        main{box-sizing:border-box;width:min(34rem,calc(100vw - 2rem));margin:1.5rem;padding:2rem 2.25rem;background:var(--card);border-radius:18px;box-shadow:0 2px 24px rgb(0 0 0 / .08)}
        h1{font-size:1.4rem;margin:0 0 .5rem}h2{font-size:1.05rem;margin:1.5rem 0 .25rem}p,li{margin:.4rem 0}.muted{color:var(--muted);font-size:.9rem}
        label{display:block;font-weight:600;font-size:.9rem;margin:.9rem 0 .25rem}
        input{box-sizing:border-box;width:100%;padding:.65rem .8rem;border:1px solid #8885;border-radius:12px;background:transparent;color:inherit;font:inherit}
        input.code{font-size:1.4rem;letter-spacing:.15em;text-transform:uppercase;text-align:center}
        button,a.btn{display:inline-block;margin-top:1rem;padding:.6rem 1.3rem;border:0;border-radius:999px;background:var(--accent);color:#fff;font:inherit;font-weight:600;text-decoration:none;cursor:pointer}
        .problem{margin:1rem 0 0;padding:.6rem .8rem;border-radius:12px;background:#fbe7e5;color:#8c1d18}.ok{margin:1rem 0 0;padding:.6rem .8rem;border-radius:12px;background:#e3f4e6;color:#1d5a2a}
        .letters{font:1.05rem/1.6 ui-monospace,Consolas,monospace;word-break:break-word;padding:.6rem .8rem;border-radius:12px;background:#8881}
        ol{padding-left:1.3rem}
        """;

    public static string Html(string title, string body) =>
        "<!DOCTYPE html><html lang=\"en\"><head><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"><meta name=\"color-scheme\" content=\"light dark\"><meta name=\"robots\" content=\"noindex\">" +
        "<title>" + WebUtility.HtmlEncode(title) + "</title><style>" + Style + "</style></head><body><main>" + body + "</main></body></html>";

    public static string E(string? text) => WebUtility.HtmlEncode(text ?? "");

    /// <summary>Writes one of these pages. Always uncached, always the Hub's security headers, and a policy that allows no script and nothing from anywhere else.</summary>
    public static async Task Write(HttpContext context, int status, string html, bool head = false)
    {
        var response = context.Response;
        response.StatusCode = status;
        HubHost.ApplySecurityHeaders(context);
        response.Headers.CacheControl = "no-store";
        response.Headers.ContentSecurityPolicy = "default-src 'none'; style-src 'unsafe-inline'; base-uri 'none'; form-action 'self'; frame-ancestors 'none'";
        response.ContentType = "text/html; charset=utf-8";
        if (!head) await response.WriteAsync(html, context.RequestAborted);
    }
}

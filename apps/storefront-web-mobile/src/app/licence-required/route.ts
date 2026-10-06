// Shown to visitors when the site's licence is missing, ended or withdrawn (the middleware rewrites to this route).
// A route handler, not a page, so that the answer really is HTTP 503: search engines and CDNs must not keep it.
// It says nothing about the reason: only the owner, signed in at /admin/licence, sees that.
export const dynamic = "force-dynamic";

const PAGE = `<!doctype html><html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="robots" content="noindex, nofollow"><title>Not available</title></head>
<body style="margin:0;min-height:100vh;display:grid;place-items:center;padding:2rem;text-align:center;font-family:-apple-system,BlinkMacSystemFont,'Segoe UI',Roboto,sans-serif;color:#1d1d1f;background:#f5f5f7">
<div><h1 style="font-size:1.75rem;margin:0 0 .5rem">This site is not available right now</h1>
<p style="color:#6e6e73;margin:0">Please come back a little later.</p>
<p style="margin-top:2rem;font-size:.85rem"><a href="/admin/licence" style="color:#6e6e73">Site owner</a></p></div></body></html>`;

function unavailable(): Response {
    return new Response(PAGE, {
        status: 503,
        headers: { "Content-Type": "text/html; charset=utf-8", "Retry-After": "3600", "Cache-Control": "no-store", "X-Robots-Tag": "noindex, nofollow" },
    });
}

export const GET = unavailable;
export const POST = unavailable;
export const HEAD = unavailable;

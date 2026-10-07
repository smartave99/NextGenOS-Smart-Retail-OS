using System.Net;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Counters;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Counters;

/// <summary>
/// The door of the Hub for computers on the shop's network. It runs before everything else, the licence page included:
/// <list type="bullet">
/// <item>A request that comes from this PC itself (a loopback address) goes straight through, as it always did. Nothing is looked up for it.</item>
/// <item>Any other request must come from a counter PC that was paired: the cookie must hold a live token. The only things open to a computer that is not paired are the health check,
/// the pairing page, and the page that lets it trust the shop's certificate.</item>
/// <item>Everything else gets one plain refusal (status 403) that says nothing about the shop.</item>
/// </list>
/// Forwarding headers (<c>X-Forwarded-For</c> and the like) are never believed: the address is the one the connection came from. A connection from this PC that carries such a header came
/// through a program that passes on other computers' requests, so it is treated as a computer on the network, not as this PC.
/// </summary>
internal static class StoreNetworkGate
{
    public const string CookieName = "hub.device";
    public static readonly object CounterKey = new();

    private static readonly string[] ForwardingHeaders = { "Forwarded", "X-Forwarded-For", "X-Forwarded-Host", "X-Forwarded-Proto", "X-Real-IP" };

    public static IApplicationBuilder UseStoreNetworkGate(this IApplicationBuilder app) => app.Use(Handle);

    /// <summary>True when the request came from this PC itself and nothing says it was passed on. No address at all (an in-process test server, a local pipe) is not a computer on a network.</summary>
    public static bool IsLocal(HttpContext context, NetworkRuntime net)
    {
        var ip = context.Connection.RemoteIpAddress;
        if (ip is null) return true;
        if (ip.IsIPv4MappedToIPv6) ip = ip.MapToIPv4();
        if (!IPAddress.IsLoopback(ip)) return false;
        // While counter PCs are served, a request that says it was forwarded is not trusted to be this PC's. With counter PCs off, nothing changes for anyone.
        if (net.Accepting && ForwardingHeaders.Any(h => context.Request.Headers.ContainsKey(h))) return false;
        return true;
    }

    /// <summary>The address the connection came from, as text, for the list of counter PCs and the log.</summary>
    public static string AddressOf(HttpContext context)
    {
        var ip = context.Connection.RemoteIpAddress;
        if (ip is null) return "unknown";
        if (ip.IsIPv4MappedToIPv6) ip = ip.MapToIPv4();
        return ip.ToString();
    }

    /// <summary>What a computer that is not paired may ask for. The same names the pairing pages are mapped on, compared the way the router compares them (capitals do not matter).</summary>
    public static bool IsOpenPath(HttpContext context)
    {
        var path = context.Request.Path.Value ?? "";
        var method = context.Request.Method;
        if (HttpMethods.IsGet(method))
            return path.Equals("/health", StringComparison.OrdinalIgnoreCase) || path.Equals("/pair", StringComparison.OrdinalIgnoreCase)
                || path.Equals("/pair/ca", StringComparison.OrdinalIgnoreCase) || path.Equals("/pair/ca.crt", StringComparison.OrdinalIgnoreCase);
        return HttpMethods.IsPost(method) && path.Equals("/pair", StringComparison.OrdinalIgnoreCase);
    }

    internal static async Task Handle(HttpContext context, RequestDelegate next)
    {
        var services = context.RequestServices;
        var net = services.GetRequiredService<NetworkRuntime>();
        if (IsLocal(context, net))
        {
            await next(context);
            return;
        }

        // A computer on the shop's network. Nothing is looked up in the shop's database unless counter PCs are served and the licence is usable (nothing is done in it before that).
        if (!net.Accepting || !services.GetRequiredService<ProductLicence>().IsUsable)
        {
            await Refuse(context);
            return;
        }

        var hub = services.GetRequiredService<HubApp>();
        var address = AddressOf(context);
        RecognisedCounter? seen;
        try
        {
            seen = hub.Network.Pairing.Recognise(context.Request.Cookies[CookieName], address);
        }
        catch (Exception ex) when (ex is SqliteException or IOException)
        {
            services.GetService<ILogger<HubApp>>()?.LogError(ex, "A counter PC could not be checked, so it was refused.");
            await Refuse(context);   // when in doubt, closed
            return;
        }

        if (seen is not null)
        {
            context.Items[CounterKey] = seen.Counter;
            if (seen.CookieIsOld) Issue(context, context.Request.Cookies[CookieName]!);
            if (context.Request.Path.StartsWithSegments("/_blazor"))
            {
                // The live screen is one long connection: noted, so that removing this counter PC (or switching counter PCs off) ends it at once.
                using var open = services.GetRequiredService<ConnectionTracker>().Track(seen.Counter.Id, context);
                await next(context);
                return;
            }

            await next(context);
            return;
        }

        if (IsOpenPath(context))
        {
            await next(context);
            return;
        }

        hub.Network.Pairing.NoteTurnedAway(address, "asked for " + context.Request.Path.Value + " without being paired");
        await Refuse(context);
    }

    /// <summary>Gives (or renews) the counter PC's cookie: kept for a long time, never readable by a script, only ever sent over the shop's secure connection and only to this PC.</summary>
    public static void Issue(HttpContext context, string token) => context.Response.Cookies.Append(CookieName, token, new CookieOptions
    {
        HttpOnly = true,
        Secure = true,
        SameSite = SameSiteMode.Strict,
        Path = "/",
        MaxAge = TimeSpan.FromDays(400),
        IsEssential = true,
    });

    /// <summary>The one refusal. It says only that this computer is not paired: nothing about the shop, the licence, or what exists here.</summary>
    public static Task Refuse(HttpContext context) => PlainPage.Write(context, StatusCodes.Status403Forbidden, PlainPage.Html("Not paired",
        "<h1>This computer has not been paired with this shop.</h1>" +
        "<p>If you work here, ask the owner for a pairing code, then pair this computer.</p>" +
        "<a class=\"btn\" href=\"/pair\">Pair this computer</a>"), head: HttpMethods.IsHead(context.Request.Method));
}

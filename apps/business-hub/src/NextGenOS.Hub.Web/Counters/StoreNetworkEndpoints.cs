using System.Text;
using Microsoft.AspNetCore.Antiforgery;
using NextGenOS.Hub.Counters;
using static NextGenOS.Hub.Web.Counters.PlainPage;

namespace NextGenOS.Hub.Web.Counters;

/// <summary>
/// The pages a counter PC uses to join the shop: <c>/pair</c> (type the code and a name), <c>/pair/ca</c> (trust the shop's own certificate once) and <c>/pair/ca.crt</c> (the certificate's
/// public part). They are the only pages open to a computer that is not paired (see <see cref="StoreNetworkGate"/>). All of them are plain, in the words of a shop owner, and carry nothing
/// about the shop.
/// </summary>
internal static class StoreNetworkEndpoints
{
    private const long MaxFormBytes = 4096;

    public static void Map(WebApplication app)
    {
        app.MapGet("/pair", Page).AllowAnonymous();
        app.MapPost("/pair", Pair).AllowAnonymous();
        app.MapGet("/pair/ca", AuthorityPage).AllowAnonymous();
        app.MapGet("/pair/ca.crt", AuthorityFile).AllowAnonymous();
    }

    // ---- /pair ------------------------------------------------------------------------------------------------------------------

    private static async Task Page(HttpContext context)
    {
        var net = context.RequestServices.GetRequiredService<NetworkRuntime>();
        if (StoreNetworkGate.IsLocal(context, net))
        {
            await Write(context, StatusCodes.Status200OK, Html("Counter PCs", Body("Counter PCs connect to this PC",
                "<p>This is the shop's main PC. A counter PC opens this page from its own browser, at the main PC's address, and types a pairing code.</p>" +
                "<p>To add a counter PC, open <strong>Settings</strong>, then <strong>Store network</strong>, on this PC.</p>")));
            return;
        }

        if (context.Items[StoreNetworkGate.CounterKey] is CounterPc already)
        {
            await Write(context, StatusCodes.Status200OK, Html("Connected", Body("This computer is connected to the shop",
                "<p class=\"ok\">It is paired as <strong>" + E(already.Name) + "</strong>.</p><a class=\"btn\" href=\"/\">Open the shop</a>" +
                "<p class=\"muted\">The owner can remove this computer at any time, in Settings on the main PC.</p>")));
            return;
        }

        await Form(context, StatusCodes.Status200OK, null, "");
    }

    private static async Task Form(HttpContext context, int status, string? problem, string name)
    {
        var antiforgery = context.RequestServices.GetRequiredService<IAntiforgery>();
        var token = antiforgery.GetAndStoreTokens(context);
        var body = Body("Connect this computer to the shop",
            "<p>This computer will work as a counter of the shop. It shows the shop's own screens; nothing is kept on this computer.</p>" +
            "<ol><li>The first time, your browser may warn that the connection is not private. That is expected until this computer trusts the shop's own certificate, once. <a href=\"/pair/ca\">How to do that</a>.</li>" +
            "<li>Ask the owner for a pairing code (on the main PC: Settings, then Store network). It works once and runs out after 10 minutes.</li></ol>" +
            (problem is null ? "" : "<div class=\"problem\" role=\"alert\">" + E(problem) + "</div>") +
            "<form method=\"post\" action=\"/pair\" autocomplete=\"off\">" +
            "<input type=\"hidden\" name=\"" + E(token.FormFieldName) + "\" value=\"" + E(token.RequestToken) + "\">" +
            "<label for=\"code\">Pairing code</label><input id=\"code\" class=\"code\" name=\"code\" maxlength=\"20\" autocomplete=\"off\" autocapitalize=\"characters\" spellcheck=\"false\" placeholder=\"ABCD-EFGH\" required autofocus>" +
            "<label for=\"name\">A name for this computer</label><input id=\"name\" name=\"name\" maxlength=\"40\" value=\"" + E(name) + "\" placeholder=\"For example: Counter 2\" required>" +
            "<button type=\"submit\">Connect</button></form>");
        // (The anti-forgery call above sets X-Frame-Options to SAMEORIGIN; Write sets the Hub's own headers after it, so the page cannot be framed.)
        await Write(context, status, Html("Connect this computer", body));
    }

    private static async Task Pair(HttpContext context)
    {
        var net = context.RequestServices.GetRequiredService<NetworkRuntime>();
        if (StoreNetworkGate.IsLocal(context, net))
        {
            await Write(context, StatusCodes.Status403Forbidden, Html("Counter PCs", Body("Pair from the counter PC",
                "<p>Pairing is done on the counter PC itself, not on the main PC.</p>")));
            return;
        }

        if (!context.Request.HasFormContentType || context.Request.ContentLength is null or > MaxFormBytes)
        {
            await Write(context, StatusCodes.Status400BadRequest, Html("Not understood", Body("That did not work", "<p>Open the pairing page again and try once more.</p><a class=\"btn\" href=\"/pair\">Back</a>")));
            return;
        }

        var antiforgery = context.RequestServices.GetRequiredService<IAntiforgery>();
        try
        {
            await antiforgery.ValidateRequestAsync(context);
        }
        catch (AntiforgeryValidationException)
        {
            await Write(context, StatusCodes.Status400BadRequest, Html("Page expired", Body("This page has expired", "<p>Open the pairing page again and try once more.</p><a class=\"btn\" href=\"/pair\">Back</a>")));
            return;
        }

        var form = await context.Request.ReadFormAsync(context.RequestAborted);
        var name = form["name"].ToString();
        var hub = context.RequestServices.GetRequiredService<HubApp>();
        try
        {
            var paired = hub.Network.Pairing.Redeem(form["code"].ToString(), name, StoreNetworkGate.AddressOf(context));
            StoreNetworkGate.Issue(context, paired.Token);
            context.Response.StatusCode = StatusCodes.Status303SeeOther;
            context.Response.Headers.Location = "/pair";
            context.Response.Headers.CacheControl = "no-store";
        }
        catch (HubException ex)
        {
            if (ex.Code == "pair-locked") context.Response.Headers.RetryAfter = ((int)PairingService.Window.TotalSeconds).ToString(System.Globalization.CultureInfo.InvariantCulture);
            var status = ex.Code switch
            {
                "pair-locked" => StatusCodes.Status429TooManyRequests,
                "device-limit" or "pair-name-taken" => StatusCodes.Status409Conflict,
                "network-off" => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status400BadRequest,
            };
            await Form(context, status, ex.Message, ex.Code is "pair-name" or "pair-name-taken" ? name : "");
        }
    }

    // ---- /pair/ca ---------------------------------------------------------------------------------------------------------------

    private static async Task AuthorityPage(HttpContext context)
    {
        var net = context.RequestServices.GetRequiredService<NetworkRuntime>();
        if (net.AuthorityFingerprint is not { } fingerprint)
        {
            await Write(context, StatusCodes.Status404NotFound, Html("No certificate", Body("There is no certificate yet",
                "<p>Counter PCs are not switched on for this shop. The owner can switch them on in Settings, then Store network, on the main PC.</p>")));
            return;
        }

        await Write(context, StatusCodes.Status200OK, Html("Trust the shop's certificate", Body("Trust the shop's own certificate, once",
            "<p>The connection between this computer and the main PC is protected by a certificate that the main PC made for this shop. Your computer does not know it yet, which is why the browser warns. Telling your computer to trust it takes a minute and has to be done only once on each computer. Nothing outside the shop is involved.</p>" +
            "<h2>First, check it is the right one</h2>" +
            "<p>On the main PC, open Settings, then Store network. The \"check letters\" there must be exactly the same as these:</p>" +
            "<p class=\"letters\">" + E(StoreCertificates.Spaced(fingerprint)) + "</p>" +
            "<p class=\"muted\">If they are not the same, do not go on. Tell the owner.</p>" +
            "<a class=\"btn\" href=\"/pair/ca.crt\">Download the certificate</a>" +
            "<h2>Windows, with Edge or Chrome</h2>" +
            "<ol><li>Open the file you downloaded (<strong>shop-network-authority.crt</strong>) and press <strong>Install Certificate</strong>.</li>" +
            "<li>Choose <strong>Current User</strong>, then <strong>Place all certificates in the following store</strong>, press <strong>Browse</strong> and choose <strong>Trusted Root Certification Authorities</strong>.</li>" +
            "<li>Finish, and answer <strong>Yes</strong> when Windows asks whether to trust it.</li>" +
            "<li>Close the browser completely, open it again, and open the shop's address.</li></ol>" +
            "<h2>Firefox</h2>" +
            "<ol><li>Open Settings, Privacy and Security, and press <strong>View Certificates</strong>.</li>" +
            "<li>On the <strong>Authorities</strong> tab press <strong>Import</strong>, choose the file, tick <strong>Trust this CA to identify websites</strong> and press OK.</li></ol>" +
            "<p class=\"muted\">Tablets and phones: the steps depend on the make and are not described here yet. <a href=\"/pair\">Back to pairing</a></p>")));
    }

    private static async Task AuthorityFile(HttpContext context)
    {
        var pem = context.RequestServices.GetRequiredService<NetworkRuntime>().AuthorityPem;
        if (pem is null)
        {
            await Write(context, StatusCodes.Status404NotFound, Html("No certificate", Body("There is no certificate yet", "<p>Counter PCs are not switched on for this shop.</p>")));
            return;
        }

        HubHost.ApplySecurityHeaders(context);
        context.Response.Headers.CacheControl = "no-store";
        context.Response.Headers.ContentDisposition = "attachment; filename=\"shop-network-authority.crt\"";
        context.Response.ContentType = "application/x-x509-ca-cert";
        await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(pem), context.RequestAborted);
    }

    private static string Body(string heading, string html) => "<h1>" + E(heading) + "</h1>" + html;
}

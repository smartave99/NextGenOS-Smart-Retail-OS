using NextGenOS.Hub.Cameras;
using NextGenOS.Hub.Counters;
using NextGenOS.Hub.Web.Counters;

namespace NextGenOS.Hub.Web;

/// <summary>
/// The door a camera program on <b>this computer</b> uses to tell the Hub what it saw (<c>POST /api/cameras/observations</c>, Version 2 Phase 7 step 2; the rules are in
/// <see cref="CameraIntakeService"/>). It is not for people and not for a browser, so it has no cookie and no page token; what protects it is, in this order:
/// <list type="number">
/// <item>the licence gate and the store network gate that every request passes first;</item>
/// <item>it answers a request from this computer only (a counter PC that is paired gets a plain refusal here, as does anything that says it was passed on by another program);</item>
/// <item>a key for one camera, in the <c>Authorization: Bearer</c> header, which a web page in a browser cannot send to another site and cannot guess;</item>
/// <item>a small, strict JSON message (see <see cref="IntakeBatch"/>), at most 64 KB, and a rate limit for each camera.</item>
/// </list>
/// Every answer is plain JSON with <c>Cache-Control: no-store</c>. A wrong or missing key gets one answer (401) that says nothing about which part was wrong.
/// </summary>
internal static class CameraIntakeEndpoint
{
    public const string Route = "/api/cameras/observations";

    public static void Map(WebApplication app) => app.MapPost(Route, Handle).AllowAnonymous().DisableAntiforgery();

    private static async Task<IResult> Handle(HttpContext http, HubApp hub, NetworkRuntime net)
    {
        http.Response.Headers.CacheControl = "no-store";
        if (!StoreNetworkGate.IsLocal(http, net)) return Results.StatusCode(StatusCodes.Status403Forbidden);

        var header = http.Request.Headers.Authorization.ToString();
        const string scheme = "Bearer ";
        if (header.Length <= scheme.Length || !header.StartsWith(scheme, StringComparison.OrdinalIgnoreCase))
        {
            http.Response.Headers.WWWAuthenticate = "Bearer";
            return Results.Json(new { error = "Send the camera's key as 'Authorization: Bearer <key>'." }, statusCode: StatusCodes.Status401Unauthorized);
        }

        var key = header[scheme.Length..].Trim();
        if (http.Request.ContentType is not { } type || !type.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
            return Results.Json(new { error = "Send the message as application/json." }, statusCode: StatusCodes.Status415UnsupportedMediaType);
        if (http.Request.ContentLength is > IntakeBatch.MaxChars)
            return Results.Json(new { error = "The message is too big (at most 64 KB)." }, statusCode: StatusCodes.Status413PayloadTooLarge);

        string body;
        using (var reader = new StreamReader(http.Request.Body, System.Text.Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 4096, leaveOpen: true))
        {
            // Read one letter more than the limit, so that a body without a length that is too big is noticed without reading all of it.
            var buffer = new char[IntakeBatch.MaxChars + 1];
            var read = await reader.ReadBlockAsync(buffer, http.RequestAborted);
            if (read > IntakeBatch.MaxChars) return Results.Json(new { error = "The message is too big (at most 64 KB)." }, statusCode: StatusCodes.Status413PayloadTooLarge);
            body = new string(buffer, 0, read);
        }

        try
        {
            // The key is checked before the message is read and before anything about the shop is said: a wrong key never learns how a message is read, or whether cameras, the event history
            // or the licence are on.
            var result = hub.CameraIntake.AcceptJson(key, body);
            return Results.Json(new { accepted = result.Accepted, rejected = result.Rejected.Select(r => new { index = r.Index, reason = r.Reason }) });
        }
        catch (HubException e)
        {
            var status = e.Code switch
            {
                "bad-key" => StatusCodes.Status401Unauthorized,
                "too-fast" => StatusCodes.Status429TooManyRequests,
                "not-licensed" or "cameras-off" or "events-off" => StatusCodes.Status503ServiceUnavailable,
                "camera-off" => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status400BadRequest,
            };
            if (status == StatusCodes.Status401Unauthorized) http.Response.Headers.WWWAuthenticate = "Bearer";
            return Results.Json(new { error = e.Message, code = e.Code }, statusCode: status);
        }
    }
}

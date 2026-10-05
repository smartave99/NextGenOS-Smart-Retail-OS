using Microsoft.AspNetCore.Antiforgery;
using NextGenOS.Devices.Barcodes;

namespace NextGenOS.Hub.Web;

/// <summary>Barcode pictures for labels and posters, and reading a barcode from a camera picture for browsers that cannot do it themselves.</summary>
public static class DeviceEndpoints
{
    private static readonly SemaphoreSlim Reading = new(2);

    private static readonly Dictionary<string, BarcodeKind> Kinds = new(StringComparer.OrdinalIgnoreCase)
    {
        ["ean13"] = BarcodeKind.Ean13, ["ean8"] = BarcodeKind.Ean8, ["upca"] = BarcodeKind.UpcA, ["code128"] = BarcodeKind.Code128, ["code39"] = BarcodeKind.Code39, ["qr"] = BarcodeKind.Qr,
    };

    public static void Map(WebApplication app)
    {
        app.MapGet("/barcode/{kind}.png", (string kind, string data, int? w, int? h) =>
        {
            if (!Kinds.TryGetValue(kind, out var k)) return Results.NotFound();
            if (string.IsNullOrEmpty(data) || data.Length > 300) return Results.BadRequest("Give the text of the barcode.");
            try
            {
                var png = BarcodeImages.Png(k, data, Math.Clamp(w ?? 300, 40, 1200), Math.Clamp(h ?? 100, 20, 1200));
                return Results.File(png, "image/png", lastModified: null, entityTag: null, enableRangeProcessing: false);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }).WithMetadata(new Microsoft.AspNetCore.Mvc.ResponseCacheAttribute { Duration = 86400, Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Client });

        // A picture from the camera, in the body. Only signed-in people, and only with the page's own token: another site cannot make the browser send one.
        app.MapPost("/api/scan", async (HttpContext http, IAntiforgery antiforgery) =>
        {
            await antiforgery.ValidateRequestAsync(http);
            if (http.Request.ContentLength is null or 0 or > 6_000_000) return Results.BadRequest(new { error = "The picture is missing or too big." });
            if (!http.Request.ContentType?.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ?? true) return Results.BadRequest(new { error = "That is not a picture." });
            using var memory = new MemoryStream();
            await http.Request.Body.CopyToAsync(memory, http.RequestAborted);
            if (!await Reading.WaitAsync(TimeSpan.FromSeconds(2), http.RequestAborted)) return Results.StatusCode(StatusCodes.Status429TooManyRequests);
            try
            {
                var found = await Task.Run(() => BarcodeImages.Read(memory.ToArray()), http.RequestAborted);
                return Results.Json(found is null ? new { text = (string?)null, format = (string?)null } : new { text = (string?)found.Value.Text, format = (string?)found.Value.Format });
            }
            finally { Reading.Release(); }
        });
    }
}

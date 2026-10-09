using System.Security.Claims;

namespace NextGenOS.Hub.Web;

/// <summary>
/// A picture of an item, at /item-images/{number}. Only for people signed in, and only those whose work shows items (the Hub's own check stands behind the route). The kind of picture was found from the
/// file when it was kept; the browser is told not to guess (the security headers say nosniff) and a picture never changes under its number, so it may be kept by the browser for a day.
/// </summary>
public static class ItemImageEndpoint
{
    public static IResult Handle(long id, HubApp app, HttpContext http)
    {
        long? who = long.TryParse(http.User.FindFirstValue(ClaimTypes.NameIdentifier), out var user) ? user : null;
        using var scope = app.Access.As(who);
        var image = app.Images.Get(id);
        if (image is null) return Results.NotFound();
        http.Response.Headers.CacheControl = "private, max-age=86400";
        return Results.Bytes(image.Value.Data, image.Value.ContentType);
    }
}

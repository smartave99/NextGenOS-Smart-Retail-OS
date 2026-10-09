using System.Security.Claims;

namespace NextGenOS.Hub.Web;

/// <summary>
/// The shop's items as a file for a spreadsheet, and the empty sheet to fill in: /sheets/items.csv and /sheets/items-template.csv. Only for people who may change the catalog; the reading is done
/// as the person signed in, so the Hub's own check stands behind the route. The file has a byte order mark so that Excel reads accents and non-Latin names properly.
/// </summary>
public static class ItemSheetEndpoint
{
    public static IResult Handle(string which, HubApp app, HttpContext http)
    {
        long? who = long.TryParse(http.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : null;
        using var scope = app.Access.As(who);
        string text;
        string name;
        switch (which)
        {
            case "items": text = app.ItemSheets.Export(); name = "items.csv"; break;
            case "items-template": text = app.ItemSheets.Template(); name = "items-to-fill-in.csv"; break;
            default: return Results.NotFound();
        }
        var bytes = new System.Text.UTF8Encoding(true).GetPreamble().Concat(System.Text.Encoding.UTF8.GetBytes(text)).ToArray();
        return Results.File(bytes, "text/csv; charset=utf-8", name);
    }
}

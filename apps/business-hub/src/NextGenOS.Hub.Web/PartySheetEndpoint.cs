using System.Security.Claims;

namespace NextGenOS.Hub.Web;

/// <summary>
/// The shop's customers and suppliers as a file for a spreadsheet, and the empty sheet to fill in: /people-sheets/people.csv and /people-sheets/people-template.csv. Only for people who may change people; the
/// reading is done as the person signed in. The file has a byte order mark so that Excel reads accents and non-Latin names properly.
/// </summary>
public static class PartySheetEndpoint
{
    public static IResult Handle(string which, HubApp app, HttpContext http)
    {
        long? who = long.TryParse(http.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : null;
        using var scope = app.Access.As(who);
        string text;
        string name;
        switch (which)
        {
            case "people": text = app.PartySheets.Export(); name = "people.csv"; break;
            case "people-template": text = app.PartySheets.Template(); name = "people-to-fill-in.csv"; break;
            default: return Results.NotFound();
        }
        var bytes = new System.Text.UTF8Encoding(true).GetPreamble().Concat(System.Text.Encoding.UTF8.GetBytes(text)).ToArray();
        return Results.File(bytes, "text/csv; charset=utf-8", name);
    }
}

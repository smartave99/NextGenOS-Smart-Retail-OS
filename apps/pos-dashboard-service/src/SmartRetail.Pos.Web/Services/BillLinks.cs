using System.Globalization;
using SmartRetail.Pos.Core.Abstractions;

namespace SmartRetail.Pos.Web.Services;

/// <summary>A bill search written in a link, so the Bills page and its download keep the same search, and Back
/// returns to it.</summary>
public static class BillLinks
{
    public static BillQuery Parse(string? text, string? from, string? to, bool? owed) => new BillQuery
    {
        Text = text,
        From = Date(from),
        To = Date(to),
        OnlyOwed = owed == true,
    }.Checked();

    /// <summary>"bills?q=priya&amp;from=2026-09-01&amp;page=2"; empty parts are left out.</summary>
    public static string Page(BillQuery query, int page = 1) => "bills" + QueryString(query, page);

    public static string Csv(BillQuery query) => "bills.csv" + QueryString(query, 1);

    public static string Iso(DateOnly? date) => date?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) ?? "";

    public static DateOnly? Date(string? text) =>
        DateOnly.TryParseExact(text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) ? date : null;

    private static string QueryString(BillQuery query, int page)
    {
        var parts = new List<string>();
        if (query.Text is { Length: > 0 } text)
        {
            parts.Add("q=" + Uri.EscapeDataString(text));
        }

        if (query.From is not null)
        {
            parts.Add("from=" + Iso(query.From));
        }

        if (query.To is not null)
        {
            parts.Add("to=" + Iso(query.To));
        }

        if (query.OnlyOwed)
        {
            parts.Add("owed=true");
        }

        if (page > 1)
        {
            parts.Add("page=" + page.ToString(CultureInfo.InvariantCulture));
        }

        return parts.Count == 0 ? "" : "?" + string.Join("&", parts);
    }
}

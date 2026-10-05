using System.Globalization;
using System.Text;
using SmartRetail.AI.Assistant;

namespace SmartRetail.Pos.Web.Services;

/// <summary>An answer's table as text to copy (as it shows, one row per line, cells split by tabs) or as a CSV file
/// that Excel opens (plain numbers and dates, and no cell that Excel would take for a formula).</summary>
public static class TableExport
{
    public static string Tabs(ChatTable table)
    {
        ArgumentNullException.ThrowIfNull(table);
        var text = new StringBuilder().AppendJoin('\t', table.Columns.Select(Flat)).Append('\n');
        foreach (var row in table.Rows)
        {
            text.AppendJoin('\t', table.Columns.Select((_, i) => Flat(Formats.Cell(i < row.Length ? row[i] : null)))).Append('\n');
        }

        return text.ToString();
    }

    public static string Csv(ChatTable table)
    {
        ArgumentNullException.ThrowIfNull(table);
        var text = new StringBuilder().AppendJoin(',', table.Columns.Select(Quote)).Append("\r\n");
        foreach (var row in table.Rows)
        {
            text.AppendJoin(',', table.Columns.Select((_, i) => Quote(Plain(i < row.Length ? row[i] : null)))).Append("\r\n");
        }

        return text.ToString();
    }

    /// <summary>E.g. "Ask AI 2026-09-27 1843.csv".</summary>
    public static string FileName(DateTime at) => "Ask AI " + at.ToString("yyyy-MM-dd HHmm", CultureInfo.InvariantCulture) + ".csv";

    /// <summary>A cell as data: numbers without grouping, dates as dates, yes/no as TRUE/FALSE.</summary>
    internal static string Plain(object? value) => value switch
    {
        null or DBNull => "",
        DateTime at when at.TimeOfDay == TimeSpan.Zero => at.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
        DateTime at => at.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
        bool flag => flag ? "TRUE" : "FALSE",
        double number when !double.IsFinite(number) => "",
        float number when !float.IsFinite(number) => "",
        IFormattable number => number.ToString(null, CultureInfo.InvariantCulture),
        _ => NoFormula(value.ToString() ?? ""),
    };

    /// <summary>Text starting with = + - @ would run as a formula in Excel: it gets a leading apostrophe.</summary>
    private static string NoFormula(string text) =>
        text.Length > 0 && text[0] is '=' or '+' or '-' or '@' or '\t' or '\r' ? "'" + text : text;

    private static string Quote(string text) =>
        text.IndexOfAny(new[] { ',', '"', '\n', '\r' }) >= 0 ? "\"" + text.Replace("\"", "\"\"") + "\"" : text;

    private static string Flat(string text) => text.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ');
}

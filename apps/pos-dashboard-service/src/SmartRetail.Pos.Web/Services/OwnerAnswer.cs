using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The shop's AI's answer to a question the owner asked on the website: its words and the table it found, as Ask AI
/// shows them at the shop, with contact details masked (<see cref="PiiMasker"/>) unless the shop turned that off in
/// Privacy; at most <see cref="MaxRows"/> rows, and small enough for Supabase to take (<see cref="Fit"/>). Never the
/// query itself.
/// </summary>
public sealed record OwnerAnswer
{
    public const int MaxRows = 100;
    public const int MaxCellLength = 200;
    public const int MaxTextLength = 20_000;

    /// <summary>Supabase refuses an answer over 262,144 bytes (answer_shop_question); this leaves room for its own
    /// way of writing the JSON.</summary>
    public const int MaxBytes = 240_000;

    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

    public string Text { get; init; } = "";
    public IReadOnlyList<string> Columns { get; init; } = Array.Empty<string>();
    public IReadOnlyList<IReadOnlyList<object?>> Rows { get; init; } = Array.Empty<IReadOnlyList<object?>>();

    /// <summary>The rows the query found, of which <see cref="Rows"/> are sent.</summary>
    public int TotalRows { get; init; }

    /// <summary>Who answered, e.g. "Codex CLI · 4.2 s".</summary>
    public string? Source { get; init; }

    /// <summary>The AI could not answer: <see cref="Text"/> says why.</summary>
    [JsonIgnore]
    public bool Failed { get; init; }

    /// <param name="maskContacts">Hide phone numbers, e-mail addresses and the like, as Privacy asks (the table on
    /// the shop's own screen shows them; the AI never saw them).</param>
    public static OwnerAnswer From(ChatMessage message, bool maskContacts)
    {
        ArgumentNullException.ThrowIfNull(message);
        var table = message.Table;
        var rows = table?.Rows.Take(MaxRows).ToList() ?? new List<object[]>();
        if (maskContacts && table is not null)
        {
            rows = PiiMasker.Mask(new QueryResult(table.Columns.ToList(), rows, truncated: false, TimeSpan.Zero)).Rows.ToList();
        }

        return new OwnerAnswer
        {
            Text = Cut(maskContacts ? PiiMasker.MaskText(message.Text) : message.Text, MaxTextLength),
            Columns = table?.Columns.Select(c => Cut(c, MaxCellLength)).ToList() ?? (IReadOnlyList<string>)Array.Empty<string>(),
            Rows = rows.Select(row => (IReadOnlyList<object?>)row.Select(Cell).ToList()).ToList(),
            TotalRows = table?.TotalRows ?? 0,
            Source = message.Source,
            Failed = message.IsProblem,
        };
    }

    /// <summary>The answer with fewer rows when it would be too large to send (the page then says how many there
    /// were); unchanged when it fits.</summary>
    public OwnerAnswer Fit(int maxBytes = MaxBytes)
    {
        var answer = this;
        while (answer.Rows.Count > 0 && JsonSerializer.SerializeToUtf8Bytes(answer, Json).Length > maxBytes)
        {
            answer = answer with { Rows = answer.Rows.Take(answer.Rows.Count / 2).ToList() };
        }

        return answer;
    }

    public static OwnerAnswer Problem(string text) => new() { Text = text, Failed = true };

    /// <summary>A cell as the page can show it: numbers and yes/no stay as they are, dates as dates, the rest as short
    /// text.</summary>
    internal static object? Cell(object? value) => value switch
    {
        null or DBNull => null,
        double number when !double.IsFinite(number) => null,
        float number when !float.IsFinite(number) => null,
        bool or byte or short or int or long or float or double or decimal => value,
        DateTime at when at.TimeOfDay == TimeSpan.Zero => at.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
        DateTime at => at.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
        DateOnly day => day.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
        byte[] => "(binary)",
        _ => Cut(Convert.ToString(value, CultureInfo.InvariantCulture) ?? "", MaxCellLength),
    };

    private static string Cut(string text, int length) => text.Length <= length ? text : text[..(length - 1)] + "…";
}

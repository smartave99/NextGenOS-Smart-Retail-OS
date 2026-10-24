using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NextGenOS.Hub.Cameras;

/// <summary>What the owner is told about a camera's key. The key itself is never kept, so it is never here.</summary>
public sealed record IntakeKeyInfo(long CameraId, DateTimeOffset CreatedAt, DateTimeOffset? LastUsedAt, long Accepted, long Rejected);

/// <summary>One thing in a message that was not kept, and why, in plain words (the number is its place in the message, from 0).</summary>
public sealed record IntakeReject(int Index, string Reason);

public sealed record IntakeResult(int Accepted, IReadOnlyList<IntakeReject> Rejected);

/// <summary>
/// One thing a camera program saw: so many of one kind of thing, how sure it is, and when. <see cref="Problem"/> is set when the part of the message could not even be read; the other
/// parts are then empty. Nothing else can be said here: no picture, no face, no name, no number plate, no track of one person (the message is checked field by field).
/// </summary>
public sealed record IntakeDetection(string? Class, int? Count, double? Confidence, DateTimeOffset? At, string? Problem = null);

/// <summary>A message from a camera program, read but not yet judged.</summary>
public sealed record IntakeBatch(string? Model, string? Version, IReadOnlyList<IntakeDetection> Detections)
{
    /// <summary>The biggest message the Hub reads, in letters.</summary>
    public const int MaxChars = 64 * 1024;

    /// <summary>The most things in one message.</summary>
    public const int MaxDetections = 100;

    private static readonly Regex OffsetEnd = new(@"(Z|[+-][0-9]{2}:[0-9]{2})$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

    /// <summary>
    /// Reads the body of a message. The shape is fixed and strict: <c>{"model": "...", "version": "...", "observations": [ {"class": "person", "count": 2, "confidence": 0.83, "at": "2026-10-24T09:15:00Z"} ]}</c>.
    /// A message with a part that is not on that list is refused whole, and an observation with a part that is not on its list is refused alone, so that nothing unexpected is ever kept.
    /// </summary>
    public static IntakeBatch Parse(string? json)
    {
        if (string.IsNullOrWhiteSpace(json)) throw new HubException("bad-batch", "The message is empty.");
        if (json.Length > MaxChars) throw new HubException("bad-batch", "The message is too big (at most 64 KB).");
        JsonDocument document;
        try
        {
            document = JsonDocument.Parse(json, new JsonDocumentOptions { MaxDepth = 4 });
        }
        catch (JsonException)
        {
            throw new HubException("bad-batch", "The message is not valid JSON.");
        }

        using (document)
        {
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object) throw new HubException("bad-batch", "The message must be a JSON object.");
            string? model = null, version = null;
            JsonElement? list = null;
            foreach (var part in root.EnumerateObject())
            {
                switch (part.Name)
                {
                    case "model": model = Text(part.Value, "model"); break;
                    case "version": version = Text(part.Value, "version"); break;
                    case "observations":
                        if (part.Value.ValueKind != JsonValueKind.Array) throw new HubException("bad-batch", "'observations' must be a list.");
                        list = part.Value;
                        break;
                    default:
                        throw new HubException("bad-batch", "The message has a part the Hub does not accept: '" + Safe(part.Name) + "'. Only model, version and observations are accepted.");
                }
            }

            if (list is null) throw new HubException("bad-batch", "The message has no 'observations'.");
            var count = list.Value.GetArrayLength();
            if (count is 0 or > MaxDetections) throw new HubException("bad-batch", "A message holds from 1 to " + MaxDetections + " observations.");
            var found = new List<IntakeDetection>(count);
            foreach (var item in list.Value.EnumerateArray()) found.Add(Detection(item));
            return new IntakeBatch(model, version, found);
        }
    }

    private static string Text(JsonElement value, string what) =>
        value.ValueKind == JsonValueKind.String ? value.GetString() ?? "" : throw new HubException("bad-batch", "'" + what + "' must be text.");

    private static IntakeDetection Detection(JsonElement item)
    {
        if (item.ValueKind != JsonValueKind.Object) return Bad("Each observation must be an object.");
        string? cls = null;
        int? count = null;
        double? confidence = null;
        DateTimeOffset? at = null;
        foreach (var part in item.EnumerateObject())
        {
            switch (part.Name)
            {
                case "class":
                    if (part.Value.ValueKind != JsonValueKind.String) return Bad("'class' must be text.");
                    cls = part.Value.GetString();
                    break;
                case "count":
                    if (part.Value.ValueKind != JsonValueKind.Number || !part.Value.TryGetInt32(out var n)) return Bad("'count' must be a whole number.");
                    count = n;
                    break;
                case "confidence":
                    if (part.Value.ValueKind != JsonValueKind.Number || !part.Value.TryGetDouble(out var c)) return Bad("'confidence' must be a number from 0 to 1.");
                    confidence = c;
                    break;
                case "at":
                    if (part.Value.ValueKind != JsonValueKind.String || part.Value.GetString() is not { } text || !OffsetEnd.IsMatch(text) || !part.Value.TryGetDateTimeOffset(out var when))
                        return Bad("'at' must be a date and time with its time zone, such as 2026-10-24T09:15:00Z.");
                    at = when;
                    break;
                default:
                    return Bad("'" + Safe(part.Name) + "' is not a part of an observation that the Hub accepts. Only class, count, confidence and at are accepted.");
            }
        }

        return new IntakeDetection(cls, count, confidence, at);

        static IntakeDetection Bad(string problem) => new(null, null, null, null, problem);
    }

    /// <summary>A name from the message, safe to show back: short and made of plain letters, or a stand-in.</summary>
    internal static string Safe(string name) => Regex.IsMatch(name, @"^[A-Za-z0-9_\-]{1,30}$", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(250)) ? name : "(unreadable name)";

    internal static string Percent(double fraction) => (fraction * 100).ToString("0.##", CultureInfo.InvariantCulture);
}

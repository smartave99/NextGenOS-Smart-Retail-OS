using System.Text.Json;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Ai;

namespace NextGenOS.Hub.Events;

/// <summary>
/// What a model or a sensor saw. Uncertain and cheap: it is not a business fact. It is kept for a short time (see <see cref="RetentionService"/>) and an event can point at it.
/// The data is a small JSON object (never a picture or a clip: those are evidence, kept elsewhere).
/// </summary>
public sealed record ObservationInput(
    string Kind, string SourceType, string SourceId, string DataClass, DateTimeOffset OccurredAt, double Confidence = 1,
    string? ModelId = null, string? ModelVersion = null, string? ZoneRef = null, string? SubjectRef = null, string? Label = null, string? DataJson = null);

public sealed record ObservationRecord(
    long Id, string Kind, string SourceType, string SourceId, string? ModelId, string? ModelVersion, string? ZoneRef, string? SubjectRef, string? Label, double Confidence, string? DataJson,
    string DataClass, DateTimeOffset OccurredAt, DateTimeOffset RecordedAt, DateTimeOffset RetainUntil);

/// <summary>A pointer to something kept elsewhere. The program never stores the picture, the clip or the document here.</summary>
public sealed record EvidenceInput(string Kind, string Reference, string DataClass, string? Sha256 = null);

public sealed record EvidenceRecord(long Id, long EventId, string Kind, string Reference, string? Sha256, string DataClass, DateTimeOffset CreatedAt, DateTimeOffset RetainUntil);

/// <summary>
/// A business fact: who or what did what to what, where and when, how sure the system is, why it believes it, which observations and which evidence support it, and what made it.
/// People and things are named by opaque references ("track:cam1:17", "user:5", "product:123"), never by a name: a reference has no spaces and no '@'.
/// </summary>
public sealed record EventInput(
    string Type, string MadeByType, string MadeById, string DataClass, DateTimeOffset OccurredAt, double Confidence = 1, string? MadeByVersion = null,
    string? ActorRef = null, string? SubjectRef = null, string? ObjectRef = null, string? ZoneRef = null, string Status = EventStatus.Confirmed, string? Explanation = null,
    string? DataJson = null, string? CorrelationId = null, string? IdempotencyKey = null, IReadOnlyList<long>? ObservationIds = null, IReadOnlyList<EvidenceInput>? Evidence = null);

public sealed record EventRecord(
    long Id, string Type, string? ActorRef, string? SubjectRef, string? ObjectRef, string? ZoneRef, DateTimeOffset OccurredAt, DateTimeOffset RecordedAt, double Confidence, string Status,
    string MadeByType, string MadeById, string? MadeByVersion, string? Explanation, string? DataJson, string DataClass, string? CorrelationId, string? IdempotencyKey, long? Supersedes,
    DateTimeOffset RetainUntil, long? CreatedBy);

/// <summary>What to look for. Newest first; <see cref="BeforeId"/> continues after a page.</summary>
public sealed record EventQuery(
    DateTimeOffset? From = null, DateTimeOffset? To = null, string? TypePrefix = null, string? Status = null, string? SubjectRef = null, string? ZoneRef = null,
    double? MinConfidence = null, string? CorrelationId = null, int Limit = 100, long? BeforeId = null);

public sealed record ObservationQuery(DateTimeOffset? From = null, DateTimeOffset? To = null, string? KindPrefix = null, string? SourceId = null, string? ZoneRef = null, int Limit = 100, long? BeforeId = null);

/// <summary>Why the system believes an event, in the order a person asks: what made it, what it rests on, what it points at, and what replaced it.</summary>
public sealed record EventExplanation(
    EventRecord Event, IReadOnlyList<ObservationRecord> Observations, int ObservationsForgotten, IReadOnlyList<EvidenceRecord> Evidence, EventRecord? Replaces, EventRecord? ReplacedBy, string Sentence);

public sealed record EventCounts(long Observations, long Proposed, long Confirmed, long Rejected, long Superseded, DateTimeOffset? OldestEvent, DateTimeOffset? NewestEvent);

public sealed record PruneResult(long Observations, long Events, long Evidence, IReadOnlyList<string> EvidenceReferences)
{
    public bool Any => Observations + Events + Evidence > 0;
}

/// <summary>The rules every record passes before it is written. They fail closed and say in plain words what is wrong.</summary>
public static partial class EventRules
{
    public const int MaxDataChars = 8192;
    public const int MaxLabelChars = 80;
    public const int MaxExplanationChars = 600;
    public const int MaxReferenceChars = 500;
    public const int MaxObservationsPerEvent = 200;
    public const int MaxEvidencePerEvent = 20;

    [GeneratedRegex(@"^[a-z][a-z0-9_]*(\.[a-z][a-z0-9_]*){1,4}$", RegexOptions.CultureInvariant)]
    private static partial Regex TypePattern();

    [GeneratedRegex(@"^[a-z][a-z0-9_]*(\.[a-z][a-z0-9_]*){0,4}$", RegexOptions.CultureInvariant)]
    private static partial Regex KindPattern();

    [GeneratedRegex(@"^[a-z][a-z0-9_]*:[A-Za-z0-9._:\-]{1,120}$", RegexOptions.CultureInvariant)]
    private static partial Regex RefPattern();

    [GeneratedRegex(@"^[A-Za-z0-9._:\-]{1,80}$", RegexOptions.CultureInvariant)]
    private static partial Regex IdPattern();

    [GeneratedRegex(@"^[0-9a-f]{64}$", RegexOptions.CultureInvariant)]
    private static partial Regex Sha256Pattern();

    public static string Type(string? type)
    {
        var text = (type ?? "").Trim();
        if (text.Length > 80 || !TypePattern().IsMatch(text))
            throw new HubException("bad-type", "An event type is a few lower-case words joined by dots, such as 'customer_session.picked_up_product'.");
        return text;
    }

    public static string Kind(string? kind)
    {
        var text = (kind ?? "").Trim();
        if (text.Length > 80 || !KindPattern().IsMatch(text))
            throw new HubException("bad-kind", "A kind of observation is a few lower-case words joined by dots, such as 'object.detected'.");
        return text;
    }

    /// <summary>An opaque reference such as "track:cam1:17". A name, an e-mail address or a phone number with spaces is not one, and is refused.</summary>
    public static string? Ref(string? value, string what)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        var text = value.Trim();
        if (!RefPattern().IsMatch(text))
            throw new HubException("bad-ref", "The " + what + " must be a short reference like 'track:cam1:17' or 'product:123', not a name, an e-mail address or a phone number.");
        return text;
    }

    public static string Id(string? value, string what)
    {
        var text = (value ?? "").Trim();
        if (!IdPattern().IsMatch(text)) throw new HubException("bad-id", "The " + what + " must be 1 to 80 letters, numbers, dots, dashes or colons.");
        return text;
    }

    public static double Confidence(double value)
    {
        if (double.IsNaN(value) || value < 0 || value > 1) throw new HubException("bad-confidence", "How sure the system is must be a number from 0 to 1.");
        return value;
    }

    /// <summary>A kind of data that may be stored here. Card and payment details never are.</summary>
    public static string StorableClass(string? dataClass)
    {
        if (!Ai.DataClass.IsKnown(dataClass)) throw new HubException("bad-class", "The kind of data was not named.");
        if (dataClass == Ai.DataClass.PaymentSensitive) throw new HubException("never-stored", "Card and payment details are never kept in the event history.");
        return dataClass!;
    }

    public static string? Words(string? value, int max, string what)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        var text = value.Trim();
        if (text.Length > max) throw new HubException("too-long", "The " + what + " is too long (at most " + max + " letters).");
        if (text.Any(char.IsControl)) throw new HubException("bad-text", "The " + what + " has characters that cannot be kept.");
        if (TextGuard.ContainsCardNumber(text)) throw new HubException("never-stored", "The " + what + " looks like it holds a card number, which is never kept in the event history.");
        return text;
    }

    /// <summary>A small JSON object, or nothing. A picture or a long text does not belong here.</summary>
    public static string? Json(string? value, string what)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        var text = value.Trim();
        if (text.Length > MaxDataChars) throw new HubException("too-long", "The " + what + " is too big (at most " + MaxDataChars + " characters).");
        try
        {
            using var document = JsonDocument.Parse(text, new JsonDocumentOptions { MaxDepth = 8 });
            if (document.RootElement.ValueKind != JsonValueKind.Object) throw new HubException("bad-json", "The " + what + " must be a JSON object.");
        }
        catch (JsonException)
        {
            throw new HubException("bad-json", "The " + what + " is not valid JSON.");
        }

        if (TextGuard.ContainsCardNumber(text)) throw new HubException("never-stored", "The " + what + " looks like it holds a card number, which is never kept in the event history.");
        return text;
    }

    public static string? Sha256(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        var text = value.Trim().ToLowerInvariant();
        if (!Sha256Pattern().IsMatch(text)) throw new HubException("bad-hash", "The fingerprint of the evidence must be 64 letters and numbers (a SHA-256).");
        return text;
    }

    public static string EvidenceReference(string? value)
    {
        var text = (value ?? "").Trim();
        if (text.Length is < 1 or > MaxReferenceChars || text.Any(char.IsControl)) throw new HubException("bad-evidence", "Evidence needs a short reference to where it is kept.");
        if (TextGuard.ContainsCardNumber(text)) throw new HubException("never-stored", "The evidence reference looks like it holds a card number, which is never kept.");
        return text;
    }
}

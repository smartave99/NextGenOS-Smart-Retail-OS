namespace NextGenOS.Hub.Events;

// The words the event store keeps and compares. Plain strings, not enums, for the same reasons as in Ai/Vocabulary.cs: they are written to the database and shown to people, and the
// shipped program's names are hidden, so a renamed enum member would change what is stored.

/// <summary>Where an event stands. Nothing is edited: a fact that was wrong says so here, and its correction points back at it.</summary>
public static class EventStatus
{
    public const string Proposed = "proposed";
    public const string Confirmed = "confirmed";
    public const string Rejected = "rejected";
    public const string Superseded = "superseded";

    public static readonly IReadOnlyList<string> All = new[] { Proposed, Confirmed, Rejected, Superseded };

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    /// <summary>A proposed event is confirmed or rejected by a person or a rule; a confirmed one can be rejected or replaced; rejected and replaced ones stay as they are.</summary>
    public static bool CanMove(string from, string to) => (from, to) switch
    {
        (Proposed, Confirmed) or (Proposed, Rejected) or (Confirmed, Rejected) or (Confirmed, Superseded) or (Proposed, Superseded) => true,
        _ => false,
    };

    public static string Label(string value) => value switch
    {
        Proposed => "Waiting to be checked", Confirmed => "Confirmed", Rejected => "Rejected (it was wrong)", Superseded => "Replaced by a correction", _ => value,
    };
}

/// <summary>What saw an observation.</summary>
public static class SourceType
{
    public const string Model = "model";
    public const string Sensor = "sensor";
    public const string Device = "device";
    public const string System = "system";
    public const string Person = "person";

    public static readonly IReadOnlyList<string> All = new[] { Model, Sensor, Device, System, Person };

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    public static string Label(string value) => value switch
    {
        Model => "An AI model", Sensor => "A sensor", Device => "A device", System => "The program", Person => "A person", _ => value,
    };
}

/// <summary>What made an event: the reason the system believes it.</summary>
public static class MadeBy
{
    public const string Rule = "rule";
    public const string Model = "model";
    public const string Person = "person";
    public const string System = "system";
    public const string Import = "import";

    public static readonly IReadOnlyList<string> All = new[] { Rule, Model, Person, System, Import };

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    public static string Label(string value) => value switch
    {
        Rule => "an automatic rule", Model => "an AI model", Person => "a person", System => "the program", Import => "an import from another system", _ => value,
    };
}

/// <summary>What a piece of evidence is. It is only ever a pointer to something kept elsewhere.</summary>
public static class EvidenceKind
{
    public const string Image = "image";
    public const string Clip = "clip";
    public const string Document = "document";
    public const string Record = "record";
    public const string Transcript = "transcript";

    public static readonly IReadOnlyList<string> All = new[] { Image, Clip, Document, Record, Transcript };

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    public static string Label(string value) => value switch
    {
        Image => "a picture", Clip => "a video clip", Document => "a document", Record => "a record in the shop's books", Transcript => "a written copy of speech", _ => value,
    };
}

/// <summary>What a retention rule is about.</summary>
public static class RetentionSubject
{
    public const string Observation = "observation";
    public const string Event = "event";
    public const string Evidence = "evidence";

    public static readonly IReadOnlyList<string> All = new[] { Observation, Event, Evidence };

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    public static string Label(string value) => value switch
    {
        Observation => "What cameras and sensors saw", Event => "Business events", Evidence => "Pointers to pictures, clips and documents", _ => value,
    };
}

public static class EventTypes
{
    /// <summary>"customer_session.picked_up_product" read as "Customer session: picked up product".</summary>
    public static string Label(string type)
    {
        if (string.IsNullOrWhiteSpace(type)) return "";
        var parts = type.Split('.', 2);
        static string Words(string s) => s.Replace('_', ' ');
        var first = Words(parts[0]);
        var head = char.ToUpperInvariant(first[0]) + first[1..];
        return parts.Length == 1 ? head : head + ": " + Words(parts[1].Replace('.', ' '));
    }
}

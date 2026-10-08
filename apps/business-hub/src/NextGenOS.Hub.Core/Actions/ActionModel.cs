using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Actions;

/// <summary>Where a request stands. It moves only forward along the lines <see cref="ActionStatus.CanMove"/> allows, and a request that has reached the end stays there.</summary>
public static class ActionStatus
{
    public const string Proposed = "proposed";
    public const string Validated = "validated";
    public const string AwaitingApproval = "awaiting_approval";
    public const string Approved = "approved";
    public const string Executing = "executing";
    public const string Succeeded = "succeeded";
    public const string Failed = "failed";
    public const string Cancelled = "cancelled";
    public const string Expired = "expired";

    public static readonly IReadOnlyList<string> All = [Proposed, Validated, AwaitingApproval, Approved, Executing, Succeeded, Failed, Cancelled, Expired];

    private static readonly Dictionary<string, string[]> Moves = new()
    {
        [Proposed] = [Validated, Failed, Cancelled],
        [Validated] = [AwaitingApproval, Cancelled, Expired],
        [AwaitingApproval] = [Approved, Cancelled, Expired, Failed],
        [Approved] = [Executing, Cancelled, Expired, Failed],
        [Executing] = [Succeeded, Failed],
    };

    public static bool CanMove(string from, string to) => Moves.TryGetValue(from, out var next) && next.Contains(to);

    public static bool IsEnd(string status) => status is Succeeded or Failed or Cancelled or Expired;

    public static string Label(string status) => status switch
    {
        Proposed => "Asked for", Validated => "Checked", AwaitingApproval => "Waiting for approval", Approved => "Approved", Executing => "Being done", Succeeded => "Done",
        Failed => "Could not be done", Cancelled => "Called off", Expired => "Ran out", _ => status,
    };
}

/// <summary>The request as a handler sees it after reading the input: what exactly it would do, the problems that stop it, and the facts it was judged on.</summary>
public sealed record Prepared(object? Input, string Summary, IReadOnlyList<string> Problems, string BoundJson)
{
    public bool Ok => Problems.Count == 0;
}

/// <summary>Who is asking a handler to act, and when.</summary>
public sealed record ActionContext(DateTimeOffset Now, long? ActorId);

/// <summary>
/// One kind of request the program knows how to carry out (blueprint ACT-012). Each is written in code, versioned, with a typed input that is checked before anything else, the permissions
/// of the people who may ask for it and of those who may approve it, a description of what it would do in plain words, and the one domain command that does it. There is no handler that runs
/// a query or calls an address it is given: the list is closed (<see cref="ActionRegistry"/>).
/// </summary>
public interface IActionHandler
{
    /// <summary>The name, for example <c>CreatePurchaseOrder</c>.</summary>
    string Id { get; }

    int Version { get; }

    string Title { get; }

    /// <summary>People with at least one of these permissions may ask for it.</summary>
    IReadOnlyList<string> ProposeAny { get; }

    /// <summary>People with at least one of these permissions may approve it.</summary>
    IReadOnlyList<string> ApproveAny { get; }

    /// <summary>True when the person who asked may also approve (they hold the permission); false when a second person must.</summary>
    bool AllowSelfApproval { get; }

    /// <summary>How long a request waits for approval before it runs out.</summary>
    TimeSpan ExpiresAfter { get; }

    /// <summary>Reads the input in the form this version expects and works out what it would do. Never changes anything.</summary>
    Prepared Prepare(string inputJson, ActionContext context);

    /// <summary>Says why an approval given on the facts then no longer holds on the facts now (a price moved, a supplier changed), or null when it still does.</summary>
    string? Changed(string boundThen, Prepared now);

    /// <summary>Does it, as the person who approved. Returns the result as JSON. Called once per request, only after approval.</summary>
    string Execute(Prepared prepared, ActionContext context);
}

/// <summary>What the Buying page and the tests see of a request.</summary>
public sealed record ActionView(
    long Id, string ActionId, int Version, string Status, string Summary, long? ProposedBy, string? ProposedByName, DateTimeOffset ProposedAt, DateTimeOffset ExpiresAt, string? SourceType, long? SourceId,
    long? DecidedBy, string? DecidedByName, DateTimeOffset? DecidedAt, string? DecisionNote, DateTimeOffset? ExecutedAt, string? Result, string? Error)
{
    public bool Waiting => Status == ActionStatus.AwaitingApproval;
}

/// <summary>One step in a request's life.</summary>
public sealed record ActionStep(long Id, DateTimeOffset At, string? From, string To, long? ActorId, string ActorLabel, string? Permission, string? Reason, string? Evidence);

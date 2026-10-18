using System.Globalization;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Intelligence;

/// <summary>The newest confirmed event about a thing or a place: enough to open it in the event history and see why the system believes it.</summary>
public sealed record StateEvent(long Id, string Type, DateTimeOffset OccurredAt, double Confidence, string MadeByType, string MadeById, string? ZoneRef);

/// <summary>How many events of one kind there are about a thing or a place, and when the newest happened.</summary>
public sealed record StateTypeCount(string Type, long Count, DateTimeOffset LastAt);

/// <summary>
/// What is true about one thing (a product, a till, a camera, a visitor's track) or one place, as the event history has it at a moment. <see cref="Latest"/> is the newest <b>confirmed</b>
/// event; events still waiting to be checked are counted apart in <see cref="WaitingToBeChecked"/> and never decide what is true; wrong and replaced events are left out.
/// </summary>
public sealed record EntityState(
    string Ref, DateTimeOffset At, StateEvent? Latest, long Confirmed, long WaitingToBeChecked, DateTimeOffset? FirstHeardOf, TimeSpan? Quiet, IReadOnlyList<StateTypeCount> ByType, string Sentence)
{
    /// <summary>True when the history has anything at all, confirmed or waiting, about it.</summary>
    public bool Known => Confirmed + WaitingToBeChecked > 0;
}

/// <summary>A thing that has been in the news lately: its newest event and how many there were.</summary>
public sealed record ActiveThing(string Ref, string LastType, DateTimeOffset LastAt, long Events);

/// <summary>
/// "What is true now?" (Version 2, Phase 4, step 1). The business event history is the one record of what happened; this reads it as a state: for one thing or one place, the newest
/// confirmed event, how many events there are of each kind, and how long it has been quiet. Nothing is copied into a second table that could drift from the history: the answer is worked out
/// from the events at the moment of asking, so a correction (an event marked wrong, a replacement) shows at once, and the same question about an earlier moment
/// (<c>at</c>) gives the state as the history now says it was then. Only the history's own rows are read: nothing is written, nothing waits in the till's path, and a switch that is off does not
/// stop a read (what was kept can always be looked at, as for the history itself).
/// <para>
/// Who may ask: the same people who may open the event history (the AI helpers' permission), because the history holds every kind of data. The answer holds the kind of event, the time, how
/// sure the system is and what made it, never the data inside an event.
/// </para>
/// <para>
/// Not here yet, and said so: states that are worked out from many events at once (a shelf's estimated stock, a queue's length), rules that make new events from old ones, and figures over
/// time. Those need a kind of event that nothing writes yet (cameras and sensors, Phase 7) and come in the next steps of Phase 4.
/// </para>
/// </summary>
public sealed partial class StateService(HubDb db, IClock clock, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    public const int MaxActive = 200;

    [GeneratedRegex(@"^[a-z][a-z0-9_]*(:[A-Za-z0-9._:\-]{0,120})?$", RegexOptions.CultureInvariant)]
    private static partial Regex PrefixPattern();

    /// <summary>What is true about a thing, named by a reference such as "item:12" or "track:cam1:17". <paramref name="at"/> asks about an earlier moment (default: now).</summary>
    public EntityState Of(string subjectRef, DateTimeOffset? at = null)
    {
        access.Require(Perm.Ai);
        return Build("subject_ref", EventRules.Ref(subjectRef, "thing") ?? throw NoReference("thing"), at);
    }

    /// <summary>What is true about a place, named by a reference such as "zone:entrance".</summary>
    public EntityState OfZone(string zoneRef, DateTimeOffset? at = null)
    {
        access.Require(Perm.Ai);
        return Build("zone_ref", EventRules.Ref(zoneRef, "place") ?? throw NoReference("place"), at);
    }

    /// <summary>
    /// The things that had a confirmed event within <paramref name="within"/> (default a day), the most recent first. <paramref name="refPrefix"/> narrows it to one kind of thing
    /// ("item:" or "track:cam1:").
    /// </summary>
    public IReadOnlyList<ActiveThing> Active(string? refPrefix = null, TimeSpan? within = null, int limit = 50)
    {
        access.Require(Perm.Ai);
        var window = within ?? TimeSpan.FromDays(1);
        if (window <= TimeSpan.Zero || window > TimeSpan.FromDays(366)) throw new HubException("bad-window", "Ask about a period from a minute to a year.");
        var prefix = string.IsNullOrWhiteSpace(refPrefix) ? null : refPrefix.Trim();
        if (prefix is not null && !PrefixPattern().IsMatch(prefix)) throw new HubException("bad-ref", "Narrow it with the start of a reference such as 'item:' or 'track:cam1:', not a name.");
        var from = clock.UtcNow - window;
        var args = new List<(string, object?)> { ("$t", Tenant), ("$s", Site), ("$from", Iso.Text(from)), ("$n", Math.Clamp(limit, 1, MaxActive)) };
        var narrow = "";
        if (prefix is not null)
        {
            narrow = " AND subject_ref LIKE $like ESCAPE '\\'";
            args.Add(("$like", Like(prefix) + "%"));
        }

        var rows = db.Query(
            // With exactly one MAX in the query, SQLite gives the other plain column (type) from the row that holds the maximum: the newest event's kind.
            "SELECT subject_ref, COUNT(*) AS n, MAX(occurred_at) AS last, type FROM events WHERE tenant_id = $t AND site_id = $s AND subject_ref IS NOT NULL AND status = 'confirmed' AND occurred_at >= $from" +
            narrow + " GROUP BY subject_ref ORDER BY last DESC, subject_ref LIMIT $n",
            r => new ActiveThing(r.Text("subject_ref"), r.Text("type"), r.Time("last"), r.Int("n")), args.ToArray());
        return rows;
    }

    // ---- inside -----------------------------------------------------------------------------------------------------------------

    private EntityState Build(string column, string reference, DateTimeOffset? asked)
    {
        var now = clock.UtcNow;
        var at = asked ?? now;
        if (at.UtcDateTime == default) throw new HubException("bad-time", "Say which moment you mean.");
        if (at > now) at = now;
        var until = Iso.Text(at);

        // The column is one of two names fixed above, never text from outside.
        var groups = db.Query(
            "SELECT type, status, COUNT(*) AS n, MAX(occurred_at) AS last, MIN(occurred_at) AS first FROM events " +
            "WHERE tenant_id = $t AND site_id = $s AND " + column + " = $ref AND occurred_at <= $until AND status IN ('confirmed', 'proposed') GROUP BY type, status",
            r => (Type: r.Text("type"), Status: r.Text("status"), N: r.Int("n"), Last: r.Time("last"), First: r.Time("first")),
            ("$t", Tenant), ("$s", Site), ("$ref", reference), ("$until", until));

        var confirmed = groups.Where(g => g.Status == EventStatus.Confirmed).ToList();
        var latest = db.QueryOne(
            "SELECT id, type, occurred_at, confidence, made_by_type, made_by_id, zone_ref FROM events " +
            "WHERE tenant_id = $t AND site_id = $s AND " + column + " = $ref AND occurred_at <= $until AND status = 'confirmed' ORDER BY occurred_at DESC, id DESC LIMIT 1",
            r => new StateEvent(r.Int("id"), r.Text("type"), r.Time("occurred_at"), r.GetDouble(r.GetOrdinal("confidence")), r.Text("made_by_type"), r.Text("made_by_id"), r.TextOrNull("zone_ref")),
            ("$t", Tenant), ("$s", Site), ("$ref", reference), ("$until", until));

        var byType = confirmed.GroupBy(g => g.Type).Select(g => new StateTypeCount(g.Key, g.Sum(x => x.N), g.Max(x => x.Last)))
            .OrderByDescending(x => x.LastAt).ThenBy(x => x.Type, StringComparer.Ordinal).ToList();
        var waiting = groups.Where(g => g.Status == EventStatus.Proposed).Sum(g => g.N);
        var total = confirmed.Sum(g => g.N);
        var first = groups.Count == 0 ? (DateTimeOffset?)null : groups.Min(g => g.First);
        var quiet = latest is null ? (TimeSpan?)null : at - latest.OccurredAt;
        return new EntityState(reference, at, latest, total, waiting, first, quiet, byType, Sentence(latest, total, waiting, quiet));
    }

    private static string Sentence(StateEvent? latest, long confirmed, long waiting, TimeSpan? quiet)
    {
        if (latest is null)
            return waiting > 0
                ? "Nothing is confirmed yet. " + Count(waiting, "event is", "events are") + " waiting to be checked."
                : "The event history knows nothing about this.";
        var parts = new List<string>
        {
            "Newest confirmed event: '" + EventTypes.Label(latest.Type) + "', " + Ago(quiet ?? TimeSpan.Zero) + " (" + Math.Round(latest.Confidence * 100).ToString(CultureInfo.InvariantCulture)
                + "% sure, made by " + MadeBy.Label(latest.MadeByType) + ").",
            Count(confirmed, "event is", "events are") + " confirmed in all.",
        };
        if (waiting > 0) parts.Add(Count(waiting, "more is", "more are") + " waiting to be checked.");
        return string.Join(" ", parts);
    }

    private static string Count(long n, string one, string many) => n.ToString(CultureInfo.InvariantCulture) + " " + (n == 1 ? one : many);

    /// <summary>"just now", "5 minutes ago", "3 hours ago", "2 days ago".</summary>
    public static string Ago(TimeSpan age)
    {
        if (age < TimeSpan.FromMinutes(1)) return "just now";
        if (age < TimeSpan.FromHours(1)) return Unit((long)age.TotalMinutes, "minute");
        if (age < TimeSpan.FromDays(1)) return Unit((long)age.TotalHours, "hour");
        return Unit((long)age.TotalDays, "day");

        static string Unit(long n, string word) => n.ToString(CultureInfo.InvariantCulture) + " " + word + (n == 1 ? "" : "s") + " ago";
    }

    private static HubException NoReference(string what) => new("bad-ref", "Say which " + what + " you mean, with a reference such as 'item:12' or 'zone:entrance'.");

    private static string Like(string text) => text.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("%", "\\%", StringComparison.Ordinal).Replace("_", "\\_", StringComparison.Ordinal);
}

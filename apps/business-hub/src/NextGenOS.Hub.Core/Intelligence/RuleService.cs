using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Intelligence;

/// <summary>Which events count together in a rule: the ones about the same thing, in the same place, or all of them.</summary>
public static class RuleGroup
{
    public const string Subject = "subject";
    public const string Zone = "zone";
    public const string All = "all";

    public static readonly IReadOnlyList<string> Known = new[] { Subject, Zone, All };

    public static bool IsKnown(string? value) => value is not null && Known.Contains(value);

    public static string Label(string value) => value switch { Subject => "about the same thing", Zone => "in the same place", All => "anywhere", _ => value };
}

/// <summary>What a person writes to make or change a rule. Every part is a plain value; there is nothing in it that can say "do".</summary>
public sealed record RuleInput(string Name, string TypePrefix, double MinConfidence, int Count, int WindowMinutes, string GroupBy, string ThenType, double ThenConfidence, string? Explanation = null);

/// <summary>
/// An automatic rule over the business event history: "when <see cref="Count"/> or more confirmed events whose type starts with <see cref="TypePrefix"/>, each at least
/// <see cref="MinConfidence"/> sure, happen <see cref="GroupBy"/> within <see cref="WindowMinutes"/> minutes, propose an event of type <see cref="ThenType"/>". The proposal waits for a person.
/// </summary>
public sealed record EventRule(
    long Id, string Name, bool Enabled, int Version, string TypePrefix, double MinConfidence, int Count, int WindowMinutes, string GroupBy, string ThenType, double ThenConfidence, string? Explanation,
    DateTimeOffset? CheckedUntil, long CheckedId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt, DateTimeOffset? RetiredAt)
{
    public bool Retired => RetiredAt is not null;

    /// <summary>The rule in words the owner reads.</summary>
    public string Sentence =>
        (Count == 1
            ? "When a confirmed event starting with '" + TypePrefix + "' (at least " + Percent + "% sure) happens "
            : "When " + Count.ToString(CultureInfo.InvariantCulture) + " or more confirmed events starting with '" + TypePrefix + "' (each at least " + Percent + "% sure) happen ")
        + RuleGroup.Label(GroupBy) + " within " + Minutes(WindowMinutes) + ", propose '" + EventTypes.Label(ThenType) + "' for a person to check.";

    private string Percent => Math.Round(MinConfidence * 100).ToString(CultureInfo.InvariantCulture);

    private static string Minutes(int n) => n % 1440 == 0 ? (n / 1440).ToString(CultureInfo.InvariantCulture) + (n == 1440 ? " day" : " days")
        : n % 60 == 0 ? (n / 60).ToString(CultureInfo.InvariantCulture) + (n == 60 ? " hour" : " hours") : n.ToString(CultureInfo.InvariantCulture) + (n == 1 ? " minute" : " minutes");
}

/// <summary>What one pass of the rules did.</summary>
public sealed record RuleRunResult(int Rules, int Looked, int Proposed, int Skipped)
{
    public static readonly RuleRunResult Nothing = new(0, 0, 0, 0);
}

/// <summary>
/// The rules engine, first step (Version 2, Phase 4, step 2). A rule is data in a fixed shape (<see cref="RuleInput"/>), so a rule cannot do anything: <b>the only thing a rule ever
/// produces is a proposed event</b>, written to the business event history as "made by an automatic rule" with the rule, its version, how many events it counted and which, so the owner can ask
/// "why?" and say yes or no. Nothing a rule produces is confirmed, acted on, sent to anybody or written to the shop's records.
/// <list type="bullet">
/// <item>A rule starts <b>switched off</b>; a person switches it on, and it then looks only at events recorded <b>after</b> that moment (no burst of proposals from old history). A rule that is
/// changed is switched off again and its version goes up, so that a change in meaning is always a person's decision.</item>
/// <item>Events that rules made never trigger rules, so rules cannot feed each other.</item>
/// <item>One trigger fires at most once (remembered in <c>event_rule_firings</c>, also across restarts), and the same thing or place does not fire again within the rule's window.</item>
/// <item>It runs only while the licence has the AI part and both "Business event history" and "Advanced automatic rules" are switched on, from the shop's upkeep or when a person presses the button;
/// never in the till's path. With a switch off, nothing runs and no rule loses its place.</item>
/// <item>Making, changing, switching and retiring a rule needs the AI helpers' permission and is written in the audit record.</item>
/// </list>
/// </summary>
public sealed partial class RuleService(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, EventStore events, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    public const int MaxRules = 50;
    public const int MaxLookedAtPerRule = 500;
    public const int MaxTriggersNamed = 20;
    public const int MaxCount = 1000;
    public const int MaxWindowMinutes = 10080;

    [GeneratedRegex(@"^[a-z][a-z0-9_]*(\.[a-z][a-z0-9_]*){0,4}$", RegexOptions.CultureInvariant)]
    private static partial Regex PrefixPattern();

    /// <summary>True while rules run: the licence has the AI part and both switches are on.</summary>
    public bool Running => flags.IsEnabled(FlagKey.AdvancedRules) && flags.IsEnabled(FlagKey.EventEngine);

    // ---- looking ------------------------------------------------------------------------------------------------------------------

    public IReadOnlyList<EventRule> List(bool includeRetired = false)
    {
        access.Require(Perm.Ai);
        return db.Query(Select + " AND (retired_at IS NULL OR $all = 1) ORDER BY id", Map, ("$t", Tenant), ("$s", Site), ("$all", includeRetired ? 1 : 0));
    }

    public EventRule? Get(long id)
    {
        access.Require(Perm.Ai);
        return Find(id);
    }

    // ---- making and changing --------------------------------------------------------------------------------------------------------

    /// <summary>Makes a rule. It starts switched off.</summary>
    public EventRule Create(RuleInput input, long? userId)
    {
        access.Require(Perm.Ai);
        var rule = Check(input);
        var now = clock.UtcNow;
        long id = 0;
        db.InTransaction((c, t) =>
        {
            var active = Convert.ToInt64(HubDb.Scalar(c, "SELECT COUNT(*) FROM event_rules WHERE tenant_id = $t AND site_id = $s AND retired_at IS NULL", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
            if (active >= MaxRules) throw new HubException("too-many", "There are already " + MaxRules + " rules. Retire one you no longer need first.");
            id = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM event_rules WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
            HubDb.Exec(c,
                "INSERT INTO event_rules(tenant_id, site_id, id, name, enabled, version, type_prefix, min_confidence, min_count, window_minutes, group_by, then_type, then_confidence, explanation, created_at, created_by, updated_at, updated_by) " +
                "VALUES ($t, $s, $id, $n, 0, 1, $p, $mc, $cnt, $w, $g, $tt, $tc, $x, $at, $u, $at, $u)", t,
                ("$t", Tenant), ("$s", Site), ("$id", id), ("$n", rule.Name), ("$p", rule.TypePrefix), ("$mc", rule.MinConfidence), ("$cnt", rule.Count), ("$w", rule.WindowMinutes), ("$g", rule.GroupBy),
                ("$tt", rule.ThenType), ("$tc", rule.ThenConfidence), ("$x", rule.Explanation), ("$at", Iso.Text(now)), ("$u", userId));
            audit.Log(c, t, userId, "rules.create", "event_rule", id, "'" + rule.Name + "': " + Describe(rule));
        });
        return Find(id)!;
    }

    /// <summary>
    /// Changes a rule. Its version goes up and it is switched off again, because a rule that means something else must be switched on again by a person. The proposals it already made stay.
    /// </summary>
    public EventRule Update(long id, RuleInput input, long? userId)
    {
        access.Require(Perm.Ai);
        var old = Find(id) ?? throw new HubException("no-rule", "That rule does not exist.");
        if (old.Retired) throw new HubException("retired", "That rule was retired. Make a new one.");
        var rule = Check(input);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c,
                "UPDATE event_rules SET name = $n, enabled = 0, version = version + 1, type_prefix = $p, min_confidence = $mc, min_count = $cnt, window_minutes = $w, group_by = $g, then_type = $tt, " +
                "then_confidence = $tc, explanation = $x, checkpoint_at = NULL, checkpoint_id = 0, updated_at = $at, updated_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$n", rule.Name), ("$p", rule.TypePrefix), ("$mc", rule.MinConfidence), ("$cnt", rule.Count), ("$w", rule.WindowMinutes), ("$g", rule.GroupBy), ("$tt", rule.ThenType), ("$tc", rule.ThenConfidence),
                ("$x", rule.Explanation), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "rules.update", "event_rule", id, "'" + rule.Name + "' is now version " + (old.Version + 1) + " and switched off: " + Describe(rule));
        });
        return Find(id)!;
    }

    /// <summary>Switches a rule on (it then looks only at events recorded from this moment) or off.</summary>
    public EventRule SetEnabled(long id, bool enabled, long? userId)
    {
        access.Require(Perm.Ai);
        var rule = Find(id) ?? throw new HubException("no-rule", "That rule does not exist.");
        if (rule.Retired) throw new HubException("retired", "That rule was retired. Make a new one.");
        if (enabled && !flags.Licensed) throw new HubException("not-licensed", "The AI features are not part of this shop's licence.");
        if (rule.Enabled == enabled) return rule;
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE event_rules SET enabled = $e, checkpoint_at = $cp, checkpoint_id = 0, updated_at = $at, updated_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$e", enabled ? 1 : 0), ("$cp", enabled ? Iso.Text(clock.UtcNow) : null), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "rules.switch", "event_rule", id, "'" + rule.Name + "': " + (enabled ? "on" : "off"));
        });
        return Find(id)!;
    }

    /// <summary>Takes a rule out of use for good. It and what it proposed stay in the record.</summary>
    public void Retire(long id, long? userId)
    {
        access.Require(Perm.Ai);
        var rule = Find(id) ?? throw new HubException("no-rule", "That rule does not exist.");
        if (rule.Retired) return;
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE event_rules SET enabled = 0, retired_at = $at, updated_at = $at, updated_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "rules.retire", "event_rule", id, "'" + rule.Name + "' retired");
        });
    }

    // ---- running --------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Looks at the events recorded since each switched-on rule last looked, and proposes what the rules say. Safe to call at any time and as often as wanted: a trigger fires once. Does
    /// nothing, and loses no place, while the licence or a switch is off.
    /// </summary>
    public RuleRunResult Run()
    {
        access.Require(Perm.Ai);
        if (!Running) return RuleRunResult.Nothing;
        int rules = 0, looked = 0, proposed = 0, skipped = 0;
        foreach (var rule in db.Query(Select + " AND enabled = 1 AND retired_at IS NULL AND checkpoint_at IS NOT NULL ORDER BY id", Map, ("$t", Tenant), ("$s", Site)))
        {
            rules++;
            var (l, p, k, stopped) = RunOne(rule);
            looked += l;
            proposed += p;
            skipped += k;
            if (stopped) break;
        }

        return new RuleRunResult(rules, looked, proposed, skipped);
    }

    private (int Looked, int Proposed, int Skipped, bool Stopped) RunOne(EventRule rule)
    {
        var started = clock.UtcNow;
        var from = rule.CheckedUntil ?? started;
        var column = rule.GroupBy == RuleGroup.Zone ? "zone_ref" : "subject_ref";
        // Read before the events are: every event with a number up to this one is seen by the query below, so a pass that reaches the end can say "up to here" by time and number.
        var newest = Convert.ToInt64(db.Scalar("SELECT COALESCE(MAX(id), 0) FROM events WHERE tenant_id = $t AND site_id = $s", ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
        var candidates = db.Query(
            "SELECT id, subject_ref, zone_ref, occurred_at, recorded_at, data_class FROM events WHERE tenant_id = $t AND site_id = $s AND status = 'confirmed' AND made_by_type <> 'rule' " +
            "AND (type = $p OR type LIKE $pl ESCAPE '\\') AND confidence >= $min AND (recorded_at > $from OR (recorded_at = $from AND id > $cid)) ORDER BY recorded_at, id LIMIT $n",
            r => new Trigger(r.Int("id"), r.TextOrNull("subject_ref"), r.TextOrNull("zone_ref"), r.Time("occurred_at"), r.Time("recorded_at"), r.Text("data_class")),
            ("$t", Tenant), ("$s", Site), ("$p", rule.TypePrefix), ("$pl", Like(rule.TypePrefix) + ".%"), ("$min", rule.MinConfidence), ("$from", Iso.Text(from)), ("$cid", rule.CheckedId), ("$n", MaxLookedAtPerRule));

        int proposed = 0, skipped = 0;
        var window = TimeSpan.FromMinutes(rule.WindowMinutes);
        foreach (var trigger in candidates)
        {
            var group = rule.GroupBy switch { RuleGroup.Subject => trigger.Subject, RuleGroup.Zone => trigger.Zone, _ => "all" };
            if (group is null) continue;
            if (AlreadyFired(rule, trigger)) continue;
            var span = " AND occurred_at > $since AND occurred_at <= $until";
            var match = "tenant_id = $t AND site_id = $s AND status = 'confirmed' AND made_by_type <> 'rule' AND (type = $p OR type LIKE $pl ESCAPE '\\') AND confidence >= $min"
                + (rule.GroupBy == RuleGroup.All ? "" : " AND " + column + " = $g") + span;
            var args = new[] { ("$t", (object?)Tenant), ("$s", Site), ("$p", rule.TypePrefix), ("$pl", Like(rule.TypePrefix) + ".%"), ("$min", rule.MinConfidence), ("$g", group), ("$since", Iso.Text(trigger.OccurredAt - window)), ("$until", Iso.Text(trigger.OccurredAt)) };
            var count = Convert.ToInt64(db.Scalar("SELECT COUNT(*) FROM events WHERE " + match, args), CultureInfo.InvariantCulture);
            if (count < rule.Count) continue;
            var cooling = db.Scalar(
                "SELECT 1 FROM event_rule_firings WHERE tenant_id = $t AND site_id = $s AND rule_id = $r AND rule_version = $v AND group_key = $g AND trigger_occurred_at > $since AND trigger_occurred_at <= $until LIMIT 1",
                ("$t", Tenant), ("$s", Site), ("$r", rule.Id), ("$v", rule.Version), ("$g", group), ("$since", Iso.Text(trigger.OccurredAt - window)), ("$until", Iso.Text(trigger.OccurredAt))) is not null;
            if (cooling) continue;

            var named = db.Query("SELECT id FROM events WHERE " + match + " ORDER BY occurred_at DESC, id DESC LIMIT " + MaxTriggersNamed, r => r.Int("id"), args);
            long? made = null;
            try
            {
                made = events.Append(Proposal(rule, trigger, group, count, named)).Id;
                proposed++;
            }
            catch (HubException ex) when (ex.Code is "events-off" or "not-licensed")
            {
                return (candidates.IndexOf(trigger), proposed, skipped, true);   // a switch went off while running: stop here and keep the place
            }
            catch (HubException)
            {
                skipped++;   // for example data that the owner has chosen not to keep: the trigger is remembered so that it is not tried again for ever
            }

            db.InTransaction((c, t) => HubDb.Exec(c,
                "INSERT OR IGNORE INTO event_rule_firings(tenant_id, site_id, rule_id, rule_version, trigger_event_id, trigger_recorded_at, trigger_occurred_at, group_key, event_id, fired_at) " +
                "VALUES ($t, $s, $r, $v, $e, $rec, $occ, $g, $ev, $at)", t,
                ("$t", Tenant), ("$s", Site), ("$r", rule.Id), ("$v", rule.Version), ("$e", trigger.Id), ("$rec", Iso.Text(trigger.RecordedAt)), ("$occ", Iso.Text(trigger.OccurredAt)), ("$g", group),
                ("$ev", made), ("$at", Iso.Text(clock.UtcNow))));
        }

        // When the list was not cut short, everything up to now was looked at; an event recorded in this same second after the look has a higher number and is read next time. Otherwise carry on
        // from the last one looked at, by its time and its number.
        var cut = candidates.Count >= MaxLookedAtPerRule;
        var nextAt = cut ? candidates[^1].RecordedAt : started;
        var nextId = cut ? candidates[^1].Id : newest;
        if (nextAt < from) { nextAt = from; nextId = rule.CheckedId; }
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE event_rules SET checkpoint_at = $cp, checkpoint_id = $cid WHERE tenant_id = $t AND site_id = $s AND id = $id AND version = $v AND enabled = 1", t,
            ("$cp", Iso.Text(nextAt)), ("$cid", nextId), ("$t", Tenant), ("$s", Site), ("$id", rule.Id), ("$v", rule.Version)));
        return (candidates.Count, proposed, skipped, false);
    }

    private bool AlreadyFired(EventRule rule, Trigger trigger) => db.Scalar(
        "SELECT 1 FROM event_rule_firings WHERE tenant_id = $t AND site_id = $s AND rule_id = $r AND rule_version = $v AND trigger_event_id = $e AND trigger_recorded_at = $rec",
        ("$t", Tenant), ("$s", Site), ("$r", rule.Id), ("$v", rule.Version), ("$e", trigger.Id), ("$rec", Iso.Text(trigger.RecordedAt))) is not null;

    private static EventInput Proposal(EventRule rule, Trigger trigger, string group, long count, IReadOnlyList<long> named)
    {
        var words = "Rule '" + rule.Name + "': " + count.ToString(CultureInfo.InvariantCulture) + " confirmed events starting with '" + rule.TypePrefix + "' " + RuleGroup.Label(rule.GroupBy)
            + (rule.GroupBy == RuleGroup.All ? "" : " (" + group + ")") + " within " + rule.WindowMinutes.ToString(CultureInfo.InvariantCulture) + " minutes."
            + (string.IsNullOrWhiteSpace(rule.Explanation) ? "" : " " + rule.Explanation!.Trim());
        if (words.Length > EventRules.MaxExplanationChars) words = words[..(EventRules.MaxExplanationChars - 1)] + "…";
        var data = JsonSerializer.Serialize(new Dictionary<string, object?> { ["rule"] = rule.Id, ["version"] = rule.Version, ["count"] = count, ["triggers"] = named });
        return new EventInput(
            Type: rule.ThenType, MadeByType: MadeBy.Rule, MadeById: "rule-" + rule.Id.ToString(CultureInfo.InvariantCulture), DataClass: trigger.DataClass, OccurredAt: trigger.OccurredAt, Confidence: rule.ThenConfidence,
            MadeByVersion: "v" + rule.Version.ToString(CultureInfo.InvariantCulture), SubjectRef: rule.GroupBy == RuleGroup.Subject ? trigger.Subject : null,
            ZoneRef: trigger.Zone, Status: EventStatus.Proposed, Explanation: words, DataJson: data,
            CorrelationId: "rule-" + rule.Id.ToString(CultureInfo.InvariantCulture),
            IdempotencyKey: "rule:" + rule.Id.ToString(CultureInfo.InvariantCulture) + ":v" + rule.Version.ToString(CultureInfo.InvariantCulture) + ":" + trigger.Id.ToString(CultureInfo.InvariantCulture) + ":"
                + trigger.RecordedAt.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture));
    }

    // ---- inside ---------------------------------------------------------------------------------------------------------------------

    private sealed record Trigger(long Id, string? Subject, string? Zone, DateTimeOffset OccurredAt, DateTimeOffset RecordedAt, string DataClass);

    private static RuleInput Check(RuleInput input)
    {
        var name = EventRules.Words(input.Name, 80, "name") ?? throw new HubException("bad-name", "Give the rule a name.");
        var prefix = (input.TypePrefix ?? "").Trim();
        if (prefix.Length > 80 || !PrefixPattern().IsMatch(prefix))
            throw new HubException("bad-prefix", "Say which events to count by the start of their type, such as 'door' or 'shelf.low_stock': lower-case words joined by dots.");
        if (double.IsNaN(input.MinConfidence) || input.MinConfidence is < 0 or > 1) throw new HubException("bad-confidence", "How sure the events must be is a number from 0 to 1.");
        if (input.Count is < 1 or > MaxCount) throw new HubException("bad-count", "The number of events must be from 1 to " + MaxCount + ".");
        if (input.WindowMinutes is < 1 or > MaxWindowMinutes) throw new HubException("bad-window", "The time must be from 1 minute to 7 days.");
        if (!RuleGroup.IsKnown(input.GroupBy)) throw new HubException("bad-group", "Say whether the events must be about the same thing, in the same place, or anywhere.");
        var then = EventRules.Type(input.ThenType);
        if (double.IsNaN(input.ThenConfidence) || input.ThenConfidence is < 0 or > 1) throw new HubException("bad-confidence", "How sure the proposal is must be a number from 0 to 1.");
        var explanation = EventRules.Words(input.Explanation, 300, "explanation");
        return new RuleInput(name, prefix, input.MinConfidence, input.Count, input.WindowMinutes, input.GroupBy, then, input.ThenConfidence, explanation);
    }

    private static string Describe(RuleInput r) =>
        r.Count + "+ events '" + r.TypePrefix + "' >= " + Math.Round(r.MinConfidence * 100).ToString(CultureInfo.InvariantCulture) + "% " + RuleGroup.Label(r.GroupBy) + " in " + r.WindowMinutes + " min -> propose '" + r.ThenType + "'";

    private EventRule? Find(long id) => db.QueryOne(Select + " AND id = $id", Map, ("$t", Tenant), ("$s", Site), ("$id", id));

    private static string Like(string text) => text.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("%", "\\%", StringComparison.Ordinal).Replace("_", "\\_", StringComparison.Ordinal);

    private const string Select =
        "SELECT id, name, enabled, version, type_prefix, min_confidence, min_count, window_minutes, group_by, then_type, then_confidence, explanation, checkpoint_at, checkpoint_id, created_at, updated_at, retired_at " +
        "FROM event_rules WHERE tenant_id = $t AND site_id = $s";

    private static EventRule Map(Microsoft.Data.Sqlite.SqliteDataReader r) => new(
        r.Int("id"), r.Text("name"), r.Flag("enabled"), (int)r.Int("version"), r.Text("type_prefix"), r.GetDouble(r.GetOrdinal("min_confidence")), (int)r.Int("min_count"), (int)r.Int("window_minutes"),
        r.Text("group_by"), r.Text("then_type"), r.GetDouble(r.GetOrdinal("then_confidence")), r.TextOrNull("explanation"), r.TimeOrNull("checkpoint_at"), r.Int("checkpoint_id"), r.Time("created_at"), r.Time("updated_at"), r.TimeOrNull("retired_at"));
}

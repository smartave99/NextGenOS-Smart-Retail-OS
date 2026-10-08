using System.Globalization;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Insights;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Actions;

/// <summary>
/// The typed actions with approval (blueprint ACT-012): a person (or, one day, an assistant) asks for one of a closed list of things; the request is checked and described in plain words; it waits
/// for a person who may approve it; on approval the facts are looked at again, and only then is it done, once. Every step is recorded with who took it, the permission that allowed it and why.
/// <para>
/// What this guards against, and how: <b>no approval</b> — the only way to the handler's command is through <see cref="Approve"/>, and the status moves only along the lines in
/// <see cref="ActionStatus.CanMove"/>; <b>the wrong person</b> — the permissions of the person asking and of the person approving are checked from the shop's roles at each step, so a person who was
/// switched off or changed role is judged as they are now; <b>an old approval</b> — a request runs out (48 hours for an order), and an approval is refused if the facts it was given on have moved
/// (the supplier, the goods, a cost price by more than a tenth); <b>doing it twice</b> — the move to "being done" is a single guarded update, so two approvals at once, or a second press, do it
/// once; the same request asked for twice with one key is one request; <b>a stuck request</b> — one left "being done" by a program that stopped is marked as not done (never done again by itself).
/// </para>
/// Off until the owner switches on "Suggested actions" (and the licence has the AI part). The shop never needs it to sell.
/// </summary>
public sealed class ActionService(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, OutboxService outbox, InsightService insights, ActionRegistry registry, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    private static readonly TimeSpan StuckAfter = TimeSpan.FromMinutes(15);

    public bool On => flags.IsEnabled(FlagKey.SuggestedActions);

    /// <summary>The kinds of request the program knows, for the screens and the guide.</summary>
    public IReadOnlyList<IActionHandler> Kinds => registry.All;

    private void RequireOn()
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "Suggested actions are not part of this shop's licence.");
        if (!flags.IsEnabled(FlagKey.SuggestedActions)) throw new HubException("actions-off", "Suggested actions are switched off. The owner can switch them on under Settings, AI helpers.");
    }

    private IActionHandler Handler(string id, int version) =>
        registry.Find(id, version) ?? throw new HubException("unknown-action", "The program does not know a request called '" + id + "' (version " + version + ").");

    private static string Label(Actor who) => who.IsSystem ? "the program" : who.Name;

    // ---- asking ------------------------------------------------------------------------------------------------------------------------

    /// <summary>What a request would do, in plain words, and what stops it, without keeping anything.</summary>
    public Prepared Preview(string actionId, int version, string inputJson)
    {
        var handler = Handler(actionId, version);
        var who = access.RequireAny(handler.ProposeAny.ToArray());
        return handler.Prepare(inputJson, new ActionContext(clock.UtcNow, who.UserId));
    }

    /// <summary>
    /// Asks for something. The input is checked first and a request that cannot be done is refused with the reason, keeping nothing; one that can is kept as "waiting for approval" with its description.
    /// With a key, asking again with the same key returns the first request instead of making another.
    /// </summary>
    public ActionView Propose(string actionId, int version, string inputJson, string? sourceType, long? sourceId, string? idempotencyKey, long? userId)
    {
        var handler = Handler(actionId, version);
        var who = access.RequireAny(handler.ProposeAny.ToArray());
        RequireOn();
        var key = string.IsNullOrWhiteSpace(idempotencyKey) ? null : idempotencyKey.Trim();
        if (key is { Length: > 100 }) throw new HubException("bad-key", "The key of a request is at most 100 letters.");
        if (key is not null && FindByKey(key) is { } existing) return existing;
        if (sourceType is not (null or "finding")) throw new HubException("bad-source", "A request can come from a warning (a finding) or from a person.");
        if (sourceType == "finding" && (sourceId is null || insights.Finding(sourceId.Value) is not { State: "open" }))
            throw new HubException("no-finding", "That warning is not open any more.");

        var by = who.UserId ?? userId;
        var now = clock.UtcNow;
        var prepared = handler.Prepare(inputJson, new ActionContext(now, by));
        if (!prepared.Ok) throw new HubException("invalid-action", prepared.Problems[0]);

        long id;
        try
        {
            id = db.InTransaction((c, t) =>
            {
                var next = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM actions WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
                HubDb.Exec(c,
                    "INSERT INTO actions(tenant_id, site_id, id, action_id, version, status, input, bound, bound_hash, summary, proposed_by, proposed_at, expires_at, source_type, source_id, idempotency_key) " +
                    "VALUES ($t, $s, $id, $a, $v, 'proposed', $in, $bound, $hash, $sum, $by, $at, $exp, $st, $si, $key)", t,
                    ("$t", Tenant), ("$s", Site), ("$id", next), ("$a", handler.Id), ("$v", handler.Version), ("$in", inputJson), ("$bound", prepared.BoundJson), ("$hash", CreatePurchaseOrderAction.Fingerprint(prepared.BoundJson)),
                    ("$sum", prepared.Summary), ("$by", by), ("$at", Iso.Text(now)), ("$exp", Iso.Text(now + handler.ExpiresAfter)), ("$st", sourceType), ("$si", sourceId), ("$key", key));
                Step(c, t, next, null, ActionStatus.Proposed, by, Label(who), handler.ProposeAny.FirstOrDefault(p => who.CanAny([p])), "Asked for", null);
                Move(c, t, next, ActionStatus.Proposed, ActionStatus.Validated, by, Label(who), null, "The request was checked and nothing stops it", prepared.BoundJson);
                Move(c, t, next, ActionStatus.Validated, ActionStatus.AwaitingApproval, by, Label(who), null, "Waiting for a person who may approve it", null);
                audit.Log(c, t, by, "action.propose", "action", next, handler.Id + " v" + handler.Version + ": " + prepared.Summary);
                return next;
            });
        }
        catch (SqliteException e) when (e.SqliteErrorCode == 19 && key is not null)
        {
            return FindByKey(key) ?? throw new HubException("duplicate-request", "That request was made just now.");
        }

        return Get(id)!;
    }

    // ---- deciding ------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Approves a request and does it. The facts are looked at again first: a request that ran out, that cannot be done now, or whose facts have moved since it was asked for is closed and not done.
    /// The thing is done once, as the person who approved, and the result is kept.
    /// </summary>
    public ActionView Approve(long id, string? note, long? userId)
    {
        access.RequireAny(registry.AnyApprove.ToArray());
        var row = Row(id) ?? throw new HubException("no-action", "That request was not found.");
        var handler = Handler(row.ActionId, row.Version);
        var who = access.RequireAny(handler.ApproveAny.ToArray());
        RequireOn();
        var approver = who.UserId ?? userId;
        if (row.Status != ActionStatus.AwaitingApproval)
            throw new HubException("not-waiting", "This is not waiting for approval any more (" + ActionStatus.Label(row.Status).ToLowerInvariant() + ").");
        if (!handler.AllowSelfApproval && approver is not null && row.ProposedBy == approver)
            throw new HubException("second-person", "Someone else has to approve this: the person who asked for it cannot.");
        var words = EventRules.Words(note, 200, "note");
        var now = clock.UtcNow;
        var context = new ActionContext(now, approver);

        if (now >= row.ExpiresAt) throw Close(id, ActionStatus.Expired, who, approver, "It ran out before it was approved.", "expired", "This request ran out on " + row.ExpiresAt.UtcDateTime.ToString("d MMM yyyy", CultureInfo.InvariantCulture) + ". Ask for it again.");
        var prepared = handler.Prepare(row.Input, context);
        if (!prepared.Ok) throw Close(id, ActionStatus.Failed, who, approver, string.Join(" ", prepared.Problems), "not-valid-now", prepared.Problems[0]);
        if (handler.Changed(row.Bound, prepared) is { } changed) throw Close(id, ActionStatus.Expired, who, approver, changed, "changed", changed + " Ask for it again.");

        // The one guarded step: waiting -> approved -> being done. Two approvals at once, or a second press, get 0 rows the second time and do nothing.
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE actions SET decided_by = $u, decided_at = $at, decision_note = $n WHERE tenant_id = $t AND site_id = $s AND id = $id AND status = 'awaiting_approval'", t,
                ("$u", approver), ("$at", Iso.Text(now)), ("$n", words), ("$t", Tenant), ("$s", Site), ("$id", id));
            Move(c, t, id, ActionStatus.AwaitingApproval, ActionStatus.Approved, approver, Label(who), handler.ApproveAny.FirstOrDefault(p => who.CanAny([p])), words ?? "Approved", null);
            Move(c, t, id, ActionStatus.Approved, ActionStatus.Executing, approver, Label(who), null, "Being done", null);
            audit.Log(c, t, approver, "action.approve", "action", id, handler.Id + " v" + handler.Version + (words is null ? "" : ": " + words));
        });

        string result;
        try
        {
            result = handler.Execute(prepared, context);
        }
        catch (HubException ex)
        {
            Finish(id, ActionStatus.Failed, who, approver, null, ex.Message);
            throw;
        }

        Finish(id, ActionStatus.Succeeded, who, approver, result, null);
        return Get(id)!;
    }

    /// <summary>A person who may approve says no (or the person who asked takes it back). Nothing is done.</summary>
    public ActionView Decline(long id, string? reason, long? userId)
    {
        access.RequireAny(registry.AnyApprove.Concat(registry.AnyPropose).Distinct().ToArray());
        var row = Row(id) ?? throw new HubException("no-action", "That request was not found.");
        var handler = Handler(row.ActionId, row.Version);
        var who = access.Who();
        var by = who.UserId ?? userId;
        var asker = by is not null && row.ProposedBy == by;
        if (!asker) access.RequireAny(handler.ApproveAny.ToArray());
        RequireOn();
        if (row.Status != ActionStatus.AwaitingApproval)
            throw new HubException("not-waiting", "This is not waiting for approval any more (" + ActionStatus.Label(row.Status).ToLowerInvariant() + ").");
        var words = EventRules.Words(reason, 200, "reason");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE actions SET decided_by = $u, decided_at = $at, decision_note = $n WHERE tenant_id = $t AND site_id = $s AND id = $id AND status = 'awaiting_approval'", t,
                ("$u", by), ("$at", Iso.Text(clock.UtcNow)), ("$n", words), ("$t", Tenant), ("$s", Site), ("$id", id));
            Move(c, t, id, ActionStatus.AwaitingApproval, ActionStatus.Cancelled, by, Label(who), null, words ?? (asker ? "Taken back by the person who asked" : "Declined"), null);
            audit.Log(c, t, by, "action.decline", "action", id, words);
        });
        return Get(id)!;
    }

    /// <summary>
    /// Closes a request that cannot go on and returns the plain refusal for the person who pressed the button. Only a request that is still waiting is closed: if someone else has just approved
    /// it (and it is being done, or is done) the person who pressed the button is told that, and the other person's request is left alone.
    /// </summary>
    private HubException Close(long id, string status, Actor who, long? by, string why, string code, string message)
    {
        try
        {
            db.InTransaction((c, t) => Move(c, t, id, ActionStatus.AwaitingApproval, status, by, Label(who), null, why, null));
        }
        catch (HubException ex) when (ex.Code == "not-waiting")
        {
            return ex;
        }

        return new HubException(code, message);
    }

    private void Finish(long id, string status, Actor who, long? by, string? result, string? error)
    {
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE actions SET executed_at = $at, result = $r, error = $e WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$at", Iso.Text(clock.UtcNow)), ("$r", result), ("$e", error), ("$t", Tenant), ("$s", Site), ("$id", id));
            Move(c, t, id, ActionStatus.Executing, status, by, Label(who), null, status == ActionStatus.Succeeded ? "Done" : error, result);
            if (status == ActionStatus.Succeeded)
            {
                var source = HubDb.Query(c, "SELECT source_type, source_id FROM actions WHERE tenant_id = $t AND site_id = $s AND id = $id", r => (Type: r.TextOrNull("source_type"), Id: r.IntOrNull("source_id")), t,
                    ("$t", Tenant), ("$s", Site), ("$id", id)).Single();
                if (source is { Type: "finding", Id: { } finding }) insights.MarkActioned(c, t, finding, by, "Ordered: request " + id);
            }

            audit.Log(c, t, by, status == ActionStatus.Succeeded ? "action.done" : "action.failed", "action", id, error);
        });
    }

    /// <summary>
    /// The program's own tidying: requests that waited past their time are marked as run out, and one left "being done" by a program that stopped is marked as not done (it is never done again by
    /// itself: a person looks at whether the thing exists). Called by the upkeep.
    /// </summary>
    internal int Sweep()
    {
        var now = clock.UtcNow;
        var closed = 0;
        db.InTransaction((c, t) =>
        {
            var late = HubDb.Query(c, "SELECT id FROM actions WHERE tenant_id = $t AND site_id = $s AND status = 'awaiting_approval' AND expires_at <= $now", r => r.Int("id"), t, ("$t", Tenant), ("$s", Site), ("$now", Iso.Text(now)));
            foreach (var id in late) { Move(c, t, id, ActionStatus.AwaitingApproval, ActionStatus.Expired, null, "the program", null, "It ran out before it was approved.", null); closed++; }
            var stuck = HubDb.Query(c, "SELECT a.id FROM actions a WHERE a.tenant_id = $t AND a.site_id = $s AND a.status = 'executing' AND COALESCE((SELECT MAX(x.at) FROM action_transitions x WHERE x.tenant_id = a.tenant_id AND x.site_id = a.site_id AND x.action_row = a.id), a.proposed_at) <= $old",
                r => r.Int("id"), t, ("$t", Tenant), ("$s", Site), ("$old", Iso.Text(now - StuckAfter)));
            foreach (var id in stuck)
            {
                HubDb.Exec(c, "UPDATE actions SET error = $e WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$e", "The program stopped while this was being done. Check whether it was done; it is not done again by itself."), ("$t", Tenant), ("$s", Site), ("$id", id));
                Move(c, t, id, ActionStatus.Executing, ActionStatus.Failed, null, "the program", null, "The program stopped while this was being done.", null);
                closed++;
            }
        });
        return closed;
    }

    // ---- the record of steps ----------------------------------------------------------------------------------------------------------------

    private void Step(SqliteConnection c, SqliteTransaction t, long row, string? from, string to, long? actorId, string actorLabel, string? permission, string? reason, string? evidence)
    {
        var next = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM action_transitions WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
        HubDb.Exec(c,
            "INSERT INTO action_transitions(tenant_id, site_id, id, action_row, at, from_status, to_status, actor_id, actor_label, permission, reason, evidence) VALUES ($t, $s, $id, $row, $at, $from, $to, $u, $l, $p, $r, $e)", t,
            ("$t", Tenant), ("$s", Site), ("$id", next), ("$row", row), ("$at", Iso.Text(clock.UtcNow)), ("$from", from), ("$to", to), ("$u", actorId), ("$l", actorLabel), ("$p", permission), ("$r", reason), ("$e", evidence));
        outbox.Add(c, t, "action." + to, "action", row, new Dictionary<string, object?> { ["actionRow"] = row, ["status"] = to, ["from"] = from }, DataClass.Internal, actorId);
    }

    /// <summary>One step of the status, along a line the program allows, and only if the request is still where the step starts (so two people cannot both move it).</summary>
    private void Move(SqliteConnection c, SqliteTransaction t, long row, string from, string to, long? actorId, string actorLabel, string? permission, string? reason, string? evidence)
    {
        if (!ActionStatus.CanMove(from, to)) throw new InvalidOperationException("A request cannot go from " + from + " to " + to + ".");
        var n = HubDb.Exec(c, "UPDATE actions SET status = $to WHERE tenant_id = $t AND site_id = $s AND id = $id AND status = $from", t, ("$to", to), ("$t", Tenant), ("$s", Site), ("$id", row), ("$from", from));
        if (n == 0) throw new HubException("not-waiting", "This request has just been dealt with by someone else.");
        Step(c, t, row, from, to, actorId, actorLabel, permission, reason, evidence);
    }

    // ---- reading ---------------------------------------------------------------------------------------------------------------------------

    private sealed record RowData(long Id, string ActionId, int Version, string Status, string Input, string Bound, long? ProposedBy, DateTimeOffset ExpiresAt);

    private RowData? Row(long id) => db.QueryOne("SELECT id, action_id, version, status, input, bound, proposed_by, expires_at FROM actions WHERE tenant_id = $t AND site_id = $s AND id = $id",
        r => new RowData(r.Int("id"), r.Text("action_id"), (int)r.Int("version"), r.Text("status"), r.Text("input"), r.Text("bound"), r.IntOrNull("proposed_by"), r.Time("expires_at")), ("$t", Tenant), ("$s", Site), ("$id", id));

    private const string ViewSelect =
        "SELECT a.id, a.action_id, a.version, a.status, a.summary, a.proposed_by, p.display_name AS proposer, a.proposed_at, a.expires_at, a.source_type, a.source_id, a.decided_by, d.display_name AS decider, a.decided_at, " +
        "a.decision_note, a.executed_at, a.result, a.error FROM actions a LEFT JOIN users p ON p.id = a.proposed_by LEFT JOIN users d ON d.id = a.decided_by WHERE a.tenant_id = $t AND a.site_id = $s";

    private static ActionView MapView(SqliteDataReader r) => new(r.Int("id"), r.Text("action_id"), (int)r.Int("version"), r.Text("status"), r.Text("summary"), r.IntOrNull("proposed_by"), r.TextOrNull("proposer"), r.Time("proposed_at"),
        r.Time("expires_at"), r.TextOrNull("source_type"), r.IntOrNull("source_id"), r.IntOrNull("decided_by"), r.TextOrNull("decider"), r.TimeOrNull("decided_at"), r.TextOrNull("decision_note"), r.TimeOrNull("executed_at"),
        r.TextOrNull("result"), r.TextOrNull("error"));

    private ActionView? FindByKey(string key) => db.QueryOne(ViewSelect + " AND a.idempotency_key = $k", MapView, ("$t", Tenant), ("$s", Site), ("$k", key));

    /// <summary>People who may approve see every request; anyone else sees only the ones they asked for.</summary>
    private bool CanSee(ActionView v)
    {
        var who = access.Who();
        return who.CanAny(registry.AnyApprove) || (who.UserId is { } me && v.ProposedBy == me);
    }

    public ActionView? Get(long id)
    {
        access.RequireAny(registry.AnyApprove.Concat(registry.AnyPropose).Distinct().ToArray());
        var v = db.QueryOne(ViewSelect + " AND a.id = $id", MapView, ("$t", Tenant), ("$s", Site), ("$id", id));
        return v is not null && CanSee(v) ? v : null;
    }

    /// <summary>Requests, newest first; only those in the given states when some are named.</summary>
    public IReadOnlyList<ActionView> List(IReadOnlyCollection<string>? statuses = null, int limit = 50)
    {
        access.RequireAny(registry.AnyApprove.Concat(registry.AnyPropose).Distinct().ToArray());
        var rows = db.Query(ViewSelect + " ORDER BY a.id DESC LIMIT $n", MapView, ("$t", Tenant), ("$s", Site), ("$n", Math.Clamp(limit, 1, 500)));
        return rows.Where(v => (statuses is null || statuses.Contains(v.Status)) && CanSee(v)).ToList();
    }

    /// <summary>Every step a request took, oldest first.</summary>
    public IReadOnlyList<ActionStep> Steps(long id)
    {
        if (Get(id) is null) return [];
        return db.Query("SELECT id, at, from_status, to_status, actor_id, actor_label, permission, reason, evidence FROM action_transitions WHERE tenant_id = $t AND site_id = $s AND action_row = $r ORDER BY id",
            r => new ActionStep(r.Int("id"), r.Time("at"), r.TextOrNull("from_status"), r.Text("to_status"), r.IntOrNull("actor_id"), r.Text("actor_label"), r.TextOrNull("permission"), r.TextOrNull("reason"), r.TextOrNull("evidence")),
            ("$t", Tenant), ("$s", Site), ("$r", id));
    }
}

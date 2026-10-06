using System.Globalization;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Events;

/// <summary>
/// The business event history. Rows are only added: a fact that turns out wrong is marked rejected, and a correction is a new event that points back at the one it replaces, so the
/// history can always be read as it was. Writing needs the switch "Business event history" (and the licence's "ai" part); reading and forgetting never do, so what was kept can still be
/// looked at, and expired records still go, after the switch is turned off.
/// </summary>
public sealed class EventStore(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, RetentionService retention)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    private static readonly TimeSpan ClockSkew = TimeSpan.FromMinutes(5);
    public const int MaxPage = 500;

    public bool Recording => flags.IsEnabled(FlagKey.EventEngine);

    // ---- writing ------------------------------------------------------------------------------------------------------------------

    public ObservationRecord Observe(ObservationInput input)
    {
        RequireOn();
        var kind = EventRules.Kind(input.Kind);
        if (!SourceType.IsKnown(input.SourceType)) throw new HubException("bad-source", "Say what saw it: a model, a sensor, a device, the program or a person.");
        var sourceId = EventRules.Id(input.SourceId, "source");
        var dataClass = EventRules.StorableClass(input.DataClass);
        var confidence = EventRules.Confidence(input.Confidence);
        var zone = EventRules.Ref(input.ZoneRef, "zone");
        var subject = EventRules.Ref(input.SubjectRef, "subject");
        var label = EventRules.Words(input.Label, EventRules.MaxLabelChars, "label");
        var data = EventRules.Json(input.DataJson, "data");
        var modelId = input.ModelId is null ? null : EventRules.Id(input.ModelId, "model");
        var modelVersion = input.ModelVersion is null ? null : EventRules.Id(input.ModelVersion, "model version");
        var occurred = CheckTime(input.OccurredAt);
        var recorded = clock.UtcNow;
        var keepUntil = retention.RetainUntil(RetentionSubject.Observation, dataClass, recorded) ?? throw NotKept(dataClass);

        long id = 0;
        db.InTransaction((c, t) =>
        {
            id = NextId(c, t, "observations");
            HubDb.Exec(c,
                "INSERT INTO observations(tenant_id, site_id, id, kind, source_type, source_id, model_id, model_version, zone_ref, subject_ref, label, confidence, data, data_class, occurred_at, recorded_at, retain_until) " +
                "VALUES ($t, $s, $id, $k, $st, $si, $m, $mv, $z, $sub, $l, $conf, $d, $dc, $occ, $rec, $keep)", t,
                ("$t", Tenant), ("$s", Site), ("$id", id), ("$k", kind), ("$st", input.SourceType), ("$si", sourceId), ("$m", modelId), ("$mv", modelVersion), ("$z", zone), ("$sub", subject), ("$l", label),
                ("$conf", confidence), ("$d", data), ("$dc", dataClass), ("$occ", Iso.Text(occurred)), ("$rec", Iso.Text(recorded)), ("$keep", Iso.Text(keepUntil)));
        });
        return GetObservation(id)!;
    }

    /// <summary>
    /// Records an event with what supports it. With an idempotency key the same fact sent twice (a device that retries) is kept once: the second call returns the first record.
    /// Nothing is written unless every part is valid.
    /// </summary>
    public EventRecord Append(EventInput input, long? userId = null)
    {
        RequireOn();
        var made = Validate(input, out var observationIds, out var evidence, out var keepUntil, out var occurred, out var dataClass);
        if (made.IdempotencyKey is { } key && FindByKey(key) is { } existing) return existing;

        long id = 0;
        try
        {
            db.InTransaction((c, t) => id = Insert(c, t, made, input, observationIds, evidence, keepUntil, occurred, dataClass, supersedes: null, userId));
        }
        catch (SqliteException e) when (e.SqliteErrorCode == 19 && made.IdempotencyKey is not null)
        {
            // Two senders with the same key at the same moment: the other one won.
            return FindByKey(made.IdempotencyKey) ?? throw new HubException("duplicate-event", "That event was recorded just now.");
        }

        return Get(id)!;
    }

    /// <summary>
    /// Replaces an event that was wrong with a corrected one. The old event is marked as replaced and the new one points back at it; both stay. A rejected or already replaced event
    /// cannot be replaced again (replace the latest one).
    /// </summary>
    public EventRecord Supersede(long oldId, EventInput replacement, long? userId, string? reason = null)
    {
        RequireOn();
        var old = Get(oldId) ?? throw new HubException("no-event", "That event does not exist.");
        if (!EventStatus.CanMove(old.Status, EventStatus.Superseded))
            throw new HubException("bad-move", "An event that is '" + EventStatus.Label(old.Status).ToLowerInvariant() + "' cannot be replaced. Replace the latest one.");
        var made = Validate(replacement, out var observationIds, out var evidence, out var keepUntil, out var occurred, out var dataClass);
        var note = EventRules.Words(reason, 200, "reason");
        long id = 0;
        db.InTransaction((c, t) =>
        {
            id = Insert(c, t, made, replacement, observationIds, evidence, keepUntil, occurred, dataClass, supersedes: oldId, userId);
            HubDb.Exec(c, "UPDATE events SET status = 'superseded' WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", oldId));
            audit.Log(c, t, userId, "events.supersede", "event", oldId, "replaced by event " + id + (note is null ? "" : " (" + note + ")"));
        });
        return Get(id)!;
    }

    /// <summary>A person (or a rule) confirms a proposed event, or says an event was wrong. The change is written down with who and why.</summary>
    public EventRecord SetStatus(long id, string status, long? userId, string? reason = null)
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "The business event history is not part of this shop's licence.");
        var current = Get(id) ?? throw new HubException("no-event", "That event does not exist.");
        if (!EventStatus.IsKnown(status) || status == EventStatus.Superseded) throw new HubException("bad-status", "Choose confirmed or rejected.");
        if (!EventStatus.CanMove(current.Status, status))
            throw new HubException("bad-move", "An event that is '" + EventStatus.Label(current.Status).ToLowerInvariant() + "' cannot be changed to '" + EventStatus.Label(status).ToLowerInvariant() + "'.");
        var note = EventRules.Words(reason, 200, "reason");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE events SET status = $st WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$st", status), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "events.status", "event", id, current.Status + " -> " + status + (note is null ? "" : " (" + note + ")"));
        });
        return Get(id)!;
    }

    // ---- reading ------------------------------------------------------------------------------------------------------------------

    public EventRecord? Get(long id) => db.QueryOne(EventSelect + " AND id = $id", MapEvent, ("$t", Tenant), ("$s", Site), ("$id", id));

    public ObservationRecord? GetObservation(long id) => db.QueryOne(ObservationSelect + " AND id = $id", MapObservation, ("$t", Tenant), ("$s", Site), ("$id", id));

    public EventRecord? FindByKey(string idempotencyKey) => db.QueryOne(EventSelect + " AND idempotency_key = $k", MapEvent, ("$t", Tenant), ("$s", Site), ("$k", idempotencyKey));

    public IReadOnlyList<EventRecord> Query(EventQuery q)
    {
        var where = new List<string>();
        var args = new List<(string, object?)> { ("$t", Tenant), ("$s", Site) };
        if (q.From is { } from) { where.Add("occurred_at >= $from"); args.Add(("$from", Iso.Text(from))); }
        if (q.To is { } to) { where.Add("occurred_at <= $to"); args.Add(("$to", Iso.Text(to))); }
        if (!string.IsNullOrWhiteSpace(q.TypePrefix)) { where.Add("(type = $type OR type LIKE $typeLike ESCAPE '\\')"); args.Add(("$type", q.TypePrefix.Trim())); args.Add(("$typeLike", Like(q.TypePrefix.Trim()) + ".%")); }
        if (!string.IsNullOrWhiteSpace(q.Status)) { where.Add("status = $status"); args.Add(("$status", q.Status)); }
        if (!string.IsNullOrWhiteSpace(q.SubjectRef)) { where.Add("subject_ref = $subject"); args.Add(("$subject", q.SubjectRef.Trim())); }
        if (!string.IsNullOrWhiteSpace(q.ZoneRef)) { where.Add("zone_ref = $zone"); args.Add(("$zone", q.ZoneRef.Trim())); }
        if (q.MinConfidence is { } min) { where.Add("confidence >= $min"); args.Add(("$min", min)); }
        if (!string.IsNullOrWhiteSpace(q.CorrelationId)) { where.Add("correlation_id = $corr"); args.Add(("$corr", q.CorrelationId.Trim())); }
        if (q.BeforeId is { } before) { where.Add("id < $before"); args.Add(("$before", before)); }
        var sql = EventSelect + (where.Count == 0 ? "" : " AND " + string.Join(" AND ", where)) + " ORDER BY id DESC LIMIT $n";
        args.Add(("$n", Math.Clamp(q.Limit, 1, MaxPage)));
        return db.Query(sql, MapEvent, args.ToArray());
    }

    public IReadOnlyList<ObservationRecord> QueryObservations(ObservationQuery q)
    {
        var where = new List<string>();
        var args = new List<(string, object?)> { ("$t", Tenant), ("$s", Site) };
        if (q.From is { } from) { where.Add("occurred_at >= $from"); args.Add(("$from", Iso.Text(from))); }
        if (q.To is { } to) { where.Add("occurred_at <= $to"); args.Add(("$to", Iso.Text(to))); }
        if (!string.IsNullOrWhiteSpace(q.KindPrefix)) { where.Add("(kind = $kind OR kind LIKE $kindLike ESCAPE '\\')"); args.Add(("$kind", q.KindPrefix.Trim())); args.Add(("$kindLike", Like(q.KindPrefix.Trim()) + ".%")); }
        if (!string.IsNullOrWhiteSpace(q.SourceId)) { where.Add("source_id = $source"); args.Add(("$source", q.SourceId.Trim())); }
        if (!string.IsNullOrWhiteSpace(q.ZoneRef)) { where.Add("zone_ref = $zone"); args.Add(("$zone", q.ZoneRef.Trim())); }
        if (q.BeforeId is { } before) { where.Add("id < $before"); args.Add(("$before", before)); }
        var sql = ObservationSelect + (where.Count == 0 ? "" : " AND " + string.Join(" AND ", where)) + " ORDER BY id DESC LIMIT $n";
        args.Add(("$n", Math.Clamp(q.Limit, 1, MaxPage)));
        return db.Query(sql, MapObservation, args.ToArray());
    }

    public IReadOnlyList<EvidenceRecord> EvidenceOf(long eventId) => db.Query(
        "SELECT id, event_id, kind, reference, sha256, data_class, created_at, retain_until FROM event_evidence WHERE tenant_id = $t AND site_id = $s AND event_id = $e ORDER BY id",
        r => new EvidenceRecord(r.Int("id"), r.Int("event_id"), r.Text("kind"), r.Text("reference"), r.TextOrNull("sha256"), r.Text("data_class"), r.Time("created_at"), r.Time("retain_until")),
        ("$t", Tenant), ("$s", Site), ("$e", eventId));

    public EventCounts Counts()
    {
        var byStatus = db.Query("SELECT status, COUNT(*) AS n FROM events WHERE tenant_id = $t AND site_id = $s GROUP BY status", r => (Status: r.Text("status"), N: r.Int("n")), ("$t", Tenant), ("$s", Site))
            .ToDictionary(x => x.Status, x => x.N);
        var range = db.Query("SELECT MIN(occurred_at) AS lo, MAX(occurred_at) AS hi FROM events WHERE tenant_id = $t AND site_id = $s", r => (Lo: r.TimeOrNull("lo"), Hi: r.TimeOrNull("hi")), ("$t", Tenant), ("$s", Site)).Single();
        var observations = Convert.ToInt64(db.Scalar("SELECT COUNT(*) FROM observations WHERE tenant_id = $t AND site_id = $s", ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
        return new EventCounts(observations, byStatus.GetValueOrDefault(EventStatus.Proposed), byStatus.GetValueOrDefault(EventStatus.Confirmed), byStatus.GetValueOrDefault(EventStatus.Rejected),
            byStatus.GetValueOrDefault(EventStatus.Superseded), range.Lo, range.Hi);
    }

    /// <summary>Why the system believes an event: what made it, what it rests on and what it points at.</summary>
    public EventExplanation Explain(long id)
    {
        var e = Get(id) ?? throw new HubException("no-event", "That event does not exist.");
        var linked = db.Query("SELECT observation_id FROM event_observations WHERE tenant_id = $t AND site_id = $s AND event_id = $e ORDER BY observation_id", r => r.Int("observation_id"), ("$t", Tenant), ("$s", Site), ("$e", id));
        var observations = linked.Select(GetObservation).Where(o => o is not null).Select(o => o!).ToList();
        var evidence = EvidenceOf(id);
        var replaces = e.Supersedes is { } before ? Get(before) : null;
        var replacedBy = db.QueryOne(EventSelect + " AND supersedes = $id", MapEvent, ("$t", Tenant), ("$s", Site), ("$id", id));
        return new EventExplanation(e, observations, linked.Count - observations.Count, evidence, replaces, replacedBy, Sentence(e, observations.Count, linked.Count - observations.Count, evidence.Count, replaces, replacedBy));
    }

    private static string Sentence(EventRecord e, int seen, int forgotten, int evidence, EventRecord? replaces, EventRecord? replacedBy)
    {
        var parts = new List<string>
        {
            "Made by " + MadeBy.Label(e.MadeByType) + " '" + e.MadeById + "'" + (e.MadeByVersion is null ? "" : " (version " + e.MadeByVersion + ")") + ", " + Math.Round(e.Confidence * 100).ToString(CultureInfo.InvariantCulture) + "% sure.",
        };
        if (!string.IsNullOrWhiteSpace(e.Explanation)) parts.Add(e.Explanation!.Trim().TrimEnd('.') + ".");
        var rests = new List<string>();
        if (seen > 0) rests.Add(seen + (seen == 1 ? " observation" : " observations"));
        if (evidence > 0) rests.Add(evidence + (evidence == 1 ? " piece of evidence" : " pieces of evidence"));
        parts.Add(rests.Count > 0 ? "It rests on " + string.Join(" and ", rests) + "." : "Nothing else is recorded as supporting it.");
        if (forgotten > 0) parts.Add(forgotten + (forgotten == 1 ? " observation it rested on has" : " observations it rested on have") + " been forgotten, as the retention rules say.");
        if (replaces is not null) parts.Add("It corrects event " + replaces.Id + ".");
        if (replacedBy is not null) parts.Add("It was replaced by event " + replacedBy.Id + ".");
        if (e.Status == EventStatus.Rejected) parts.Add("It was marked as wrong.");
        if (e.Status == EventStatus.Proposed) parts.Add("It is waiting for a person to check it.");
        return string.Join(" ", parts);
    }

    // ---- inside ---------------------------------------------------------------------------------------------------------------------

    private void RequireOn()
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "The business event history is not part of this shop's licence.");
        if (!flags.IsEnabled(FlagKey.EventEngine)) throw new HubException("events-off", "The business event history is switched off, so nothing is recorded.");
    }

    private DateTimeOffset CheckTime(DateTimeOffset at)
    {
        if (at.UtcDateTime == default) throw new HubException("bad-time", "Say when it happened.");
        if (at > clock.UtcNow + ClockSkew) throw new HubException("bad-time", "It cannot have happened in the future.");
        return at;
    }

    private static HubException NotKept(string dataClass) => dataClass == DataClass.Biometric
        ? new HubException("not-kept", "Biometric data is not kept unless the owner has chosen how long to keep it (Settings, Business events, retention).")
        : new HubException("not-kept", "This kind of data is not kept (its retention rule is nothing).");

    private sealed record Made(string Type, string? Actor, string? Subject, string? Object, string? Zone, double Confidence, string Status, string MadeById, string? MadeByVersion, string? Explanation, string? Data, string? Correlation, string? IdempotencyKey);

    private Made Validate(EventInput input, out IReadOnlyList<long> observationIds, out IReadOnlyList<(EvidenceInput Input, string Reference, string? Sha, string Class, DateTimeOffset KeepUntil)> evidence,
        out DateTimeOffset keepUntil, out DateTimeOffset occurred, out string dataClass)
    {
        var type = EventRules.Type(input.Type);
        if (!MadeBy.IsKnown(input.MadeByType)) throw new HubException("bad-maker", "Say what made the event: a rule, a model, a person, the program or an import.");
        var madeById = EventRules.Id(input.MadeById, "maker");
        var madeByVersion = input.MadeByVersion is null ? null : EventRules.Id(input.MadeByVersion, "maker's version");
        dataClass = EventRules.StorableClass(input.DataClass);
        var confidence = EventRules.Confidence(input.Confidence);
        if (input.Status is not (EventStatus.Proposed or EventStatus.Confirmed)) throw new HubException("bad-status", "A new event is either waiting to be checked or confirmed.");
        var made = new Made(type, EventRules.Ref(input.ActorRef, "actor"), EventRules.Ref(input.SubjectRef, "subject"), EventRules.Ref(input.ObjectRef, "object"), EventRules.Ref(input.ZoneRef, "zone"),
            confidence, input.Status, madeById, madeByVersion, EventRules.Words(input.Explanation, EventRules.MaxExplanationChars, "explanation"), EventRules.Json(input.DataJson, "data"),
            input.CorrelationId is null ? null : EventRules.Id(input.CorrelationId, "correlation id"), input.IdempotencyKey is null ? null : EventRules.Id(input.IdempotencyKey, "idempotency key"));
        occurred = CheckTime(input.OccurredAt);
        keepUntil = retention.RetainUntil(RetentionSubject.Event, dataClass, clock.UtcNow) ?? throw NotKept(dataClass);

        var ids = (input.ObservationIds ?? []).Distinct().ToList();
        if (ids.Count > EventRules.MaxObservationsPerEvent) throw new HubException("too-many", "An event can rest on at most " + EventRules.MaxObservationsPerEvent + " observations.");
        foreach (var id in ids)
            if (GetObservation(id) is null) throw new HubException("no-observation", "Observation " + id + " does not exist (it may have been forgotten).");
        observationIds = ids;

        var list = new List<(EvidenceInput, string, string?, string, DateTimeOffset)>();
        var pieces = input.Evidence ?? [];
        if (pieces.Count > EventRules.MaxEvidencePerEvent) throw new HubException("too-many", "An event can have at most " + EventRules.MaxEvidencePerEvent + " pieces of evidence.");
        foreach (var piece in pieces)
        {
            if (!EvidenceKind.IsKnown(piece.Kind)) throw new HubException("bad-evidence", "Say what the evidence is: a picture, a clip, a document, a record or a written copy of speech.");
            var evidenceClass = EventRules.StorableClass(piece.DataClass);
            var until = retention.RetainUntil(RetentionSubject.Evidence, evidenceClass, clock.UtcNow) ?? throw NotKept(evidenceClass);
            list.Add((piece, EventRules.EvidenceReference(piece.Reference), EventRules.Sha256(piece.Sha256), evidenceClass, until));
        }

        evidence = list;
        return made;
    }

    private long Insert(SqliteConnection c, SqliteTransaction t, Made made, EventInput input, IReadOnlyList<long> observationIds,
        IReadOnlyList<(EvidenceInput Input, string Reference, string? Sha, string Class, DateTimeOffset KeepUntil)> evidence, DateTimeOffset keepUntil, DateTimeOffset occurred, string dataClass, long? supersedes, long? userId)
    {
        var id = NextId(c, t, "events");
        HubDb.Exec(c,
            "INSERT INTO events(tenant_id, site_id, id, type, actor_ref, subject_ref, object_ref, zone_ref, occurred_at, recorded_at, confidence, status, made_by_type, made_by_id, made_by_version, explanation, data, data_class, " +
            "correlation_id, idempotency_key, supersedes, retain_until, created_by) VALUES ($t, $s, $id, $type, $actor, $subject, $object, $zone, $occ, $rec, $conf, $status, $mbt, $mbi, $mbv, $expl, $data, $dc, $corr, $key, $sup, $keep, $by)", t,
            ("$t", Tenant), ("$s", Site), ("$id", id), ("$type", made.Type), ("$actor", made.Actor), ("$subject", made.Subject), ("$object", made.Object), ("$zone", made.Zone), ("$occ", Iso.Text(occurred)),
            ("$rec", Iso.Text(clock.UtcNow)), ("$conf", made.Confidence), ("$status", made.Status), ("$mbt", input.MadeByType), ("$mbi", made.MadeById), ("$mbv", made.MadeByVersion), ("$expl", made.Explanation),
            ("$data", made.Data), ("$dc", dataClass), ("$corr", made.Correlation), ("$key", made.IdempotencyKey), ("$sup", supersedes), ("$keep", Iso.Text(keepUntil)), ("$by", userId));
        foreach (var observation in observationIds)
            HubDb.Exec(c, "INSERT INTO event_observations(tenant_id, site_id, event_id, observation_id) VALUES ($t, $s, $e, $o)", t, ("$t", Tenant), ("$s", Site), ("$e", id), ("$o", observation));
        foreach (var piece in evidence)
        {
            var evidenceId = NextId(c, t, "event_evidence");
            HubDb.Exec(c, "INSERT INTO event_evidence(tenant_id, site_id, id, event_id, kind, reference, sha256, data_class, created_at, retain_until) VALUES ($t, $s, $id, $e, $k, $r, $h, $dc, $at, $keep)", t,
                ("$t", Tenant), ("$s", Site), ("$id", evidenceId), ("$e", id), ("$k", piece.Input.Kind), ("$r", piece.Reference), ("$h", piece.Sha), ("$dc", piece.Class), ("$at", Iso.Text(clock.UtcNow)), ("$keep", Iso.Text(piece.KeepUntil)));
        }

        return id;
    }

    private static long NextId(SqliteConnection c, SqliteTransaction t, string table) =>
        Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM " + table + " WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);

    /// <summary>Makes a typed prefix safe to use in LIKE: the characters LIKE treats as special are written as themselves.</summary>
    private static string Like(string text) => text.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("%", "\\%", StringComparison.Ordinal).Replace("_", "\\_", StringComparison.Ordinal);

    private const string EventSelect =
        "SELECT id, type, actor_ref, subject_ref, object_ref, zone_ref, occurred_at, recorded_at, confidence, status, made_by_type, made_by_id, made_by_version, explanation, data, data_class, correlation_id, " +
        "idempotency_key, supersedes, retain_until, created_by FROM events WHERE tenant_id = $t AND site_id = $s";

    private const string ObservationSelect =
        "SELECT id, kind, source_type, source_id, model_id, model_version, zone_ref, subject_ref, label, confidence, data, data_class, occurred_at, recorded_at, retain_until FROM observations WHERE tenant_id = $t AND site_id = $s";

    private static EventRecord MapEvent(SqliteDataReader r) => new(
        r.Int("id"), r.Text("type"), r.TextOrNull("actor_ref"), r.TextOrNull("subject_ref"), r.TextOrNull("object_ref"), r.TextOrNull("zone_ref"), r.Time("occurred_at"), r.Time("recorded_at"),
        r.GetDouble(r.GetOrdinal("confidence")), r.Text("status"), r.Text("made_by_type"), r.Text("made_by_id"), r.TextOrNull("made_by_version"), r.TextOrNull("explanation"), r.TextOrNull("data"),
        r.Text("data_class"), r.TextOrNull("correlation_id"), r.TextOrNull("idempotency_key"), r.IntOrNull("supersedes"), r.Time("retain_until"), r.IntOrNull("created_by"));

    private static ObservationRecord MapObservation(SqliteDataReader r) => new(
        r.Int("id"), r.Text("kind"), r.Text("source_type"), r.Text("source_id"), r.TextOrNull("model_id"), r.TextOrNull("model_version"), r.TextOrNull("zone_ref"), r.TextOrNull("subject_ref"), r.TextOrNull("label"),
        r.GetDouble(r.GetOrdinal("confidence")), r.TextOrNull("data"), r.Text("data_class"), r.Time("occurred_at"), r.Time("recorded_at"), r.Time("retain_until"));
}

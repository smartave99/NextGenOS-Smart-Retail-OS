using System.Globalization;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Events;

/// <summary>One message waiting in, or delivered from, the outbox.</summary>
public sealed record OutboxMessage(
    long Id, string EventType, int SchemaVersion, string AggregateType, long AggregateId, DateTimeOffset OccurredAt, long? ActorId, string? CorrelationId, string DataClass, string Payload,
    string Status, int Attempts, DateTimeOffset NextAttemptAt, string? LastError);

/// <summary>How the outbox stands, for the owner's screen: what is waiting, how long the oldest has waited, what failed for good.</summary>
public sealed record OutboxStats(long Waiting, long Failed, long Delivered, DateTimeOffset? OldestWaiting, TimeSpan? OldestWaitingAge, bool Paused)
{
    public bool Healthy => Failed == 0 && (OldestWaitingAge is null || OldestWaitingAge < TimeSpan.FromMinutes(30));
}

/// <summary>
/// The transactional outbox for business events (blueprint EVT-009). A sale, a return, a payment, a purchase or a stock change writes a message here <b>inside its own transaction</b> (see
/// <see cref="Add"/>), so the fact and the message commit together or not at all. A dispatcher (<see cref="Dispatch"/>, run by the shop's upkeep and once when the shop opens) takes the
/// committed messages a few at a time under a lease that runs out if the program stops half-way, gives each to its consumer, and marks it delivered only after the consumer has kept it.
/// A message may be delivered twice, and does no harm: the event store keeps one event for one message (its key is <c>outbox:&lt;id&gt;</c>), and <c>outbox_processed</c> remembers what
/// each consumer has done. A message that keeps failing is tried again later and later, and after <see cref="MaxAttempts"/> tries is set aside as failed, where the owner can see it and
/// try it again; nothing is lost and nothing blocks the till.
/// <para>
/// Messages are written only while the business event history is switched on (and licensed): with it off nothing is written and nothing is delivered. What a message holds is identifiers
/// and a few figures, never a name, a note, a card detail or a secret.
/// </para>
/// </summary>
public sealed class OutboxService(HubDb db, IClock clock, FeatureFlagService flags, EventStore events, AuditService audit, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    public const int BatchSize = 50;
    public const int MaxAttempts = 8;
    public static readonly TimeSpan Lease = TimeSpan.FromMinutes(2);
    private const string EventStoreConsumer = "events";
    private const int MaxPayloadBytes = 8192;

    /// <summary>True while messages are written and delivered.</summary>
    public bool Recording => flags.IsEnabled(FlagKey.EventEngine);

    // ---- writing, inside the transaction of the thing that happened --------------------------------------------------------------------

    /// <summary>
    /// Writes a message in the caller's transaction (nothing when the business event history is off). The payload is figures and identifiers only; one that is too big is cut down to its
    /// first part rather than ever stopping the sale. Never throws for a payload problem.
    /// </summary>
    public void Add(SqliteConnection c, SqliteTransaction t, string eventType, string aggregateType, long aggregateId, IReadOnlyDictionary<string, object?> payload, string dataClass, long? actorId, string? correlationId = null)
    {
        if (!Recording) return;
        var text = JsonSerializer.Serialize(payload);
        if (text.Length > MaxPayloadBytes) text = JsonSerializer.Serialize(new Dictionary<string, object?> { ["cut"] = true });
        var now = clock.UtcNow;
        var id = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM outbox WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
        HubDb.Exec(c,
            "INSERT INTO outbox(tenant_id, site_id, id, event_type, schema_version, aggregate_type, aggregate_id, occurred_at, created_at, actor_id, correlation_id, data_class, payload, next_attempt_at) " +
            "VALUES ($t, $s, $id, $type, 1, $at, $aid, $occ, $now, $actor, $corr, $dc, $payload, $now)", t,
            ("$t", Tenant), ("$s", Site), ("$id", id), ("$type", eventType), ("$at", aggregateType), ("$aid", aggregateId), ("$occ", Iso.Text(now)), ("$now", Iso.Text(now)),
            ("$actor", actorId), ("$corr", correlationId), ("$dc", dataClass), ("$payload", text));
    }

    // ---- delivering ------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Delivers the messages that are due, a batch at a time. Returns how many were delivered. Does nothing while the business event history is off (the messages wait, and no try is
    /// used up). A message that cannot be delivered is put off by longer and longer, then set aside as failed.
    /// </summary>
    public int Dispatch(int limit = BatchSize)
    {
        if (!Recording) return 0;
        var delivered = 0;
        foreach (var message in TakeDue(Math.Clamp(limit, 1, 500)))
        {
            try
            {
                Deliver(message);
                MarkDelivered(message.Id);
                delivered++;
            }
            catch (Exception ex) when (ex is HubException or SqliteException or IOException or JsonException)
            {
                Failed(message, ex.Message);
            }
        }

        return delivered;
    }

    /// <summary>
    /// Delivers the messages that are due, batch after batch, until none is due or <paramref name="maxBatches"/> batches have been done (so that a very busy day cannot keep the upkeep here for ever;
    /// what is left waits for the next time). Returns how many were delivered.
    /// </summary>
    public int DispatchAll(int maxBatches = 20)
    {
        var total = 0;
        for (var i = 0; i < maxBatches; i++)
        {
            var n = Dispatch();
            total += n;
            if (n < BatchSize) break;
        }

        return total;
    }

    /// <summary>Takes a lease on the messages that are due, in one step that no other dispatcher can interleave with (the write transaction is exclusive).</summary>
    private IReadOnlyList<OutboxMessage> TakeDue(int limit)
    {
        var now = clock.UtcNow;
        return db.InTransaction((c, t) =>
        {
            var rows = HubDb.Query(c,
                Select + " AND status = 'pending' AND next_attempt_at <= $now AND (leased_until IS NULL OR leased_until <= $now) ORDER BY id LIMIT $n",
                Map, t, ("$t", Tenant), ("$s", Site), ("$now", Iso.Text(now)), ("$n", limit));
            foreach (var row in rows)
                HubDb.Exec(c, "UPDATE outbox SET leased_until = $until WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                    ("$until", Iso.Text(now + Lease)), ("$t", Tenant), ("$s", Site), ("$id", row.Id));
            return rows;
        });
    }

    /// <summary>The one consumer today: the event history. Idempotent by its key, so a second delivery of the same message is a second look at the same event.</summary>
    private void Deliver(OutboxMessage m)
    {
        if (AlreadyProcessed(EventStoreConsumer, m.Id)) return;
        var type = m.EventType + ".v" + m.SchemaVersion.ToString(CultureInfo.InvariantCulture);
        events.Append(new EventInput(
            Type: type, MadeByType: MadeBy.System, MadeById: "hub", DataClass: m.DataClass, OccurredAt: m.OccurredAt,
            ActorRef: m.ActorId is { } actor ? "user:" + actor.ToString(CultureInfo.InvariantCulture) : null,
            SubjectRef: m.AggregateType + ":" + m.AggregateId.ToString(CultureInfo.InvariantCulture), DataJson: m.Payload, CorrelationId: m.CorrelationId, IdempotencyKey: "outbox:" + m.Id.ToString(CultureInfo.InvariantCulture),
            Explanation: "Recorded by the program when it happened."));
        db.InTransaction((c, t) => HubDb.Exec(c, "INSERT OR IGNORE INTO outbox_processed(tenant_id, site_id, consumer, outbox_id, processed_at) VALUES ($t, $s, $c, $id, $at)", t,
            ("$t", Tenant), ("$s", Site), ("$c", EventStoreConsumer), ("$id", m.Id), ("$at", Iso.Text(clock.UtcNow))));
    }

    private bool AlreadyProcessed(string consumer, long id) =>
        db.Scalar("SELECT 1 FROM outbox_processed WHERE tenant_id = $t AND site_id = $s AND consumer = $c AND outbox_id = $id", ("$t", Tenant), ("$s", Site), ("$c", consumer), ("$id", id)) is not null;

    private void MarkDelivered(long id) => db.InTransaction((c, t) => HubDb.Exec(c,
        "UPDATE outbox SET status = 'delivered', delivered_at = $at, leased_until = NULL, last_error = NULL WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
        ("$at", Iso.Text(clock.UtcNow)), ("$t", Tenant), ("$s", Site), ("$id", id)));

    private void Failed(OutboxMessage m, string error)
    {
        var attempts = m.Attempts + 1;
        var terminal = attempts >= MaxAttempts;
        var wait = TimeSpan.FromMinutes(Math.Min(60, Math.Pow(2, attempts)));   // 2, 4, 8 ... at most an hour
        var text = error.Length > 300 ? error[..300] : error;
        db.InTransaction((c, t) => HubDb.Exec(c,
            "UPDATE outbox SET attempts = $a, status = $st, next_attempt_at = $next, leased_until = NULL, last_error = $e WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
            ("$a", attempts), ("$st", terminal ? "failed" : "pending"), ("$next", Iso.Text(clock.UtcNow + wait)), ("$e", text), ("$t", Tenant), ("$s", Site), ("$id", m.Id)));
    }

    // ---- looking and putting right -------------------------------------------------------------------------------------------------

    public OutboxStats Stats()
    {
        var now = clock.UtcNow;
        var row = db.Query(
            "SELECT COALESCE(SUM(status = 'pending'), 0), COALESCE(SUM(status = 'failed'), 0), COALESCE(SUM(status = 'delivered'), 0), MIN(CASE WHEN status = 'pending' THEN created_at END) FROM outbox WHERE tenant_id = $t AND site_id = $s",
            r => (Waiting: r.GetInt64(0), Failed: r.GetInt64(1), Delivered: r.GetInt64(2), Oldest: r.IsDBNull(3) ? (DateTimeOffset?)null : Iso.Parse(r.GetString(3))), ("$t", Tenant), ("$s", Site)).Single();
        return new OutboxStats(row.Waiting, row.Failed, row.Delivered, row.Oldest, row.Oldest is { } oldest ? now - oldest : null, Paused: !Recording && row.Waiting > 0);
    }

    /// <summary>Messages by state, newest first.</summary>
    public IReadOnlyList<OutboxMessage> List(string? status = null, int limit = 50) => db.Query(
        Select + " AND ($st IS NULL OR status = $st) ORDER BY id DESC LIMIT $n", Map, ("$t", Tenant), ("$s", Site), ("$st", status), ("$n", Math.Clamp(limit, 1, 500)));

    /// <summary>The messages that failed for good are made ready to be tried again (the owner pressed the button). Returns how many.</summary>
    public int RetryFailed(long? userId)
    {
        access.Require(Perm.Ai);
        return db.InTransaction((c, t) =>
        {
            var n = HubDb.Exec(c, "UPDATE outbox SET status = 'pending', attempts = 0, next_attempt_at = $now, leased_until = NULL WHERE tenant_id = $t AND site_id = $s AND status = 'failed'", t,
                ("$now", Iso.Text(clock.UtcNow)), ("$t", Tenant), ("$s", Site));
            if (n > 0) audit.Log(c, t, userId, "outbox.retry", "outbox", null, n + " failed message(s) will be tried again.");
            return n;
        });
    }

    /// <summary>
    /// Delivers again the messages of a period, as if they had not been delivered (a consumer that was changed or lost something). Safe: the event history keeps one event for one message, so
    /// a replay changes nothing that is already right. Returns how many were made ready.
    /// </summary>
    public int Replay(DateTimeOffset from, DateTimeOffset to, long? userId)
    {
        access.Require(Perm.Ai);
        return db.InTransaction((c, t) =>
        {
            var n = HubDb.Exec(c,
                "UPDATE outbox SET status = 'pending', attempts = 0, next_attempt_at = $now, leased_until = NULL, delivered_at = NULL WHERE tenant_id = $t AND site_id = $s AND status = 'delivered' AND occurred_at >= $f AND occurred_at < $to", t,
                ("$now", Iso.Text(clock.UtcNow)), ("$t", Tenant), ("$s", Site), ("$f", Iso.Text(from)), ("$to", Iso.Text(to)));
            HubDb.Exec(c, "DELETE FROM outbox_processed WHERE tenant_id = $t AND site_id = $s AND outbox_id IN (SELECT id FROM outbox WHERE tenant_id = $t AND site_id = $s AND status = 'pending')", t, ("$t", Tenant), ("$s", Site));
            if (n > 0) audit.Log(c, t, userId, "outbox.replay", "outbox", null, n + " message(s) will be delivered again.");
            return n;
        });
    }

    private const string Select =
        "SELECT id, event_type, schema_version, aggregate_type, aggregate_id, occurred_at, actor_id, correlation_id, data_class, payload, status, attempts, next_attempt_at, last_error " +
        "FROM outbox WHERE tenant_id = $t AND site_id = $s";

    private static OutboxMessage Map(SqliteDataReader r) => new(
        r.GetInt64(0), r.GetString(1), r.GetInt32(2), r.GetString(3), r.GetInt64(4), Iso.Parse(r.GetString(5)), r.IsDBNull(6) ? null : r.GetInt64(6), r.IsDBNull(7) ? null : r.GetString(7),
        r.GetString(8), r.GetString(9), r.GetString(10), r.GetInt32(11), Iso.Parse(r.GetString(12)), r.IsDBNull(13) ? null : r.GetString(13));
}

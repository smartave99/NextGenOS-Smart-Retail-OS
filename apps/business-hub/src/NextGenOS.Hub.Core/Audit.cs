using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub;

/// <summary>A plain record of what people did that matters (voiding a bill, changing stock by hand, changing settings). It is only ever added to.</summary>
public sealed class AuditService(HubDb db, IClock clock)
{
    public void Log(long? userId, string action, string? entity = null, long? entityId = null, string? detail = null) =>
        db.InTransaction((c, t) => Log(c, t, userId, action, entity, entityId, detail));

    public void Log(SqliteConnection connection, SqliteTransaction transaction, long? userId, string action, string? entity, long? entityId, string? detail) =>
        HubDb.Exec(connection, "INSERT INTO audit_log(at, user_id, action, entity, entity_id, detail) VALUES ($at, $u, $a, $e, $i, $d)", transaction,
            ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$a", action), ("$e", entity), ("$i", entityId), ("$d", detail));

    public IReadOnlyList<AuditEntry> Recent(int limit = 100) => db.Query(
        "SELECT a.id, a.at, a.user_id, u.display_name AS who, a.action, a.entity, a.entity_id, a.detail FROM audit_log a LEFT JOIN users u ON u.id = a.user_id ORDER BY a.id DESC LIMIT $n",
        r => new AuditEntry(r.Int("id"), r.Time("at"), r.IntOrNull("user_id"), r.TextOrNull("who"), r.Text("action"), r.TextOrNull("entity"), r.IntOrNull("entity_id"), r.TextOrNull("detail")), ("$n", limit));
}

public sealed record AuditEntry(long Id, DateTimeOffset At, long? UserId, string? Who, string Action, string? Entity, long? EntityId, string? Detail);

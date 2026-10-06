using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Events;

/// <summary>One effective rule: how many days a kind of record holding a kind of data is kept. 0 days means it is not kept at all.</summary>
public sealed record RetentionRule(string Subject, string DataClass, int Days, bool IsDefault);

/// <summary>
/// How long records are kept, and the forgetting. Defaults are short for what is private (camera pictures, sound, personal data) and biometric data is not kept at all unless the owner
/// writes a rule for it: keeping it is an opt-in. Card and payment details are never kept and no rule can change that. The forgetting does not depend on any switch: records past
/// their day are removed even when the event history is switched off.
/// </summary>
public sealed class RetentionService(HubDb db, IClock clock, AuditService audit)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    public const int MaxDays = 3650;
    private const int MaxReportedReferences = 1000;

    /// <summary>What applies when the owner has written nothing. 0: not kept.</summary>
    public static int DefaultDays(string subject, string dataClass) => (subject, dataClass) switch
    {
        (_, DataClass.PaymentSensitive) => 0,
        (_, DataClass.Biometric) => 0,
        (RetentionSubject.Observation, DataClass.Video or DataClass.Audio) => 3,
        (RetentionSubject.Observation, DataClass.Personal) => 7,
        (RetentionSubject.Observation, _) => 14,
        (RetentionSubject.Event, DataClass.Video or DataClass.Audio) => 30,
        (RetentionSubject.Event, DataClass.Personal) => 90,
        (RetentionSubject.Event, _) => 365,
        (RetentionSubject.Evidence, DataClass.Video or DataClass.Audio) => 7,
        (RetentionSubject.Evidence, _) => 30,
        _ => 0,
    };

    /// <summary>The days that apply, or null when this kind of record is not kept.</summary>
    public int? Days(string subject, string dataClass)
    {
        if (!RetentionSubject.IsKnown(subject) || !DataClass.IsKnown(dataClass) || dataClass == DataClass.PaymentSensitive) return null;
        var chosen = db.Scalar("SELECT days FROM retention_policies WHERE tenant_id = $t AND site_id = $s AND subject = $x AND data_class = $c",
            ("$t", Tenant), ("$s", Site), ("$x", subject), ("$c", dataClass));
        var days = chosen is null ? DefaultDays(subject, dataClass) : (int)Convert.ToInt64(chosen, System.Globalization.CultureInfo.InvariantCulture);
        return days > 0 ? days : null;
    }

    /// <summary>The day a record written at <paramref name="at"/> may be forgotten, or null when it must not be kept.</summary>
    public DateTimeOffset? RetainUntil(string subject, string dataClass, DateTimeOffset at) => Days(subject, dataClass) is { } days ? at.AddDays(days) : null;

    public IReadOnlyList<RetentionRule> Rules()
    {
        var chosen = db.Query("SELECT subject, data_class, days FROM retention_policies WHERE tenant_id = $t AND site_id = $s",
            r => (Subject: r.Text("subject"), Class: r.Text("data_class"), Days: (int)r.Int("days")), ("$t", Tenant), ("$s", Site)).ToDictionary(x => (x.Subject, x.Class), x => x.Days);
        var rules = new List<RetentionRule>();
        foreach (var subject in RetentionSubject.All)
            foreach (var dataClass in DataClass.All.Where(c => c != DataClass.PaymentSensitive))
                rules.Add(chosen.TryGetValue((subject, dataClass), out var days) ? new RetentionRule(subject, dataClass, days, false) : new RetentionRule(subject, dataClass, DefaultDays(subject, dataClass), true));
        return rules;
    }

    /// <summary>The owner decides how many days. For biometric data this is also the permission to keep any at all.</summary>
    public void Set(string subject, string dataClass, int days, long? userId)
    {
        if (!RetentionSubject.IsKnown(subject)) throw new HubException("bad-subject", "That kind of record does not exist.");
        if (!DataClass.IsKnown(dataClass)) throw new HubException("bad-class", "That kind of data does not exist.");
        if (dataClass == DataClass.PaymentSensitive) throw new HubException("never-stored", "Card and payment details are never kept, so there is nothing to set.");
        if (days is < 1 or > MaxDays) throw new HubException("bad-days", "Choose a number of days from 1 to " + MaxDays + ".");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "INSERT INTO retention_policies(tenant_id, site_id, subject, data_class, days, updated_at, updated_by) VALUES ($t, $s, $x, $c, $d, $at, $u) " +
                "ON CONFLICT(tenant_id, site_id, subject, data_class) DO UPDATE SET days = excluded.days, updated_at = excluded.updated_at, updated_by = excluded.updated_by", t,
                ("$t", Tenant), ("$s", Site), ("$x", subject), ("$c", dataClass), ("$d", days), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId));
            audit.Log(c, t, userId, "events.retention", "retention_policy", null, subject + " / " + dataClass + ": " + days + " days");
        });
    }

    /// <summary>Goes back to the default for this kind of record.</summary>
    public void UseDefault(string subject, string dataClass, long? userId)
    {
        db.InTransaction((c, t) =>
        {
            var removed = HubDb.Exec(c, "DELETE FROM retention_policies WHERE tenant_id = $t AND site_id = $s AND subject = $x AND data_class = $c", t,
                ("$t", Tenant), ("$s", Site), ("$x", subject), ("$c", dataClass));
            if (removed > 0) audit.Log(c, t, userId, "events.retention", "retention_policy", null, subject + " / " + dataClass + ": back to the default");
        });
    }

    /// <summary>
    /// Forgets what is past its day. Nothing else is touched. The references of the evidence that was forgotten are given back so that whoever keeps those files (the camera storage,
    /// later) can delete them too: this program keeps only the pointers.
    /// </summary>
    public PruneResult Prune(long? userId)
    {
        var now = Iso.Text(clock.UtcNow);
        var references = new List<string>();
        long observations = 0, events = 0, evidence = 0;
        db.InTransaction((c, t) =>
        {
            // Evidence of an event that is itself about to go is forgotten with it (the database removes it together with the event): count and list it before anything is removed.
            const string Expired = "FROM event_evidence WHERE tenant_id = $t AND site_id = $s AND (retain_until < $now OR event_id IN (SELECT id FROM events WHERE tenant_id = $t AND site_id = $s AND retain_until < $now))";
            evidence = Convert.ToInt64(HubDb.Scalar(c, "SELECT COUNT(*) " + Expired, t, ("$t", Tenant), ("$s", Site), ("$now", now)), System.Globalization.CultureInfo.InvariantCulture);
            references.AddRange(HubDb.Query(c, "SELECT reference " + Expired + " LIMIT " + MaxReportedReferences, r => r.Text("reference"), t, ("$t", Tenant), ("$s", Site), ("$now", now)));
            events = HubDb.Exec(c, "DELETE FROM events WHERE tenant_id = $t AND site_id = $s AND retain_until < $now", t, ("$t", Tenant), ("$s", Site), ("$now", now));
            HubDb.Exec(c, "DELETE FROM event_evidence WHERE tenant_id = $t AND site_id = $s AND retain_until < $now", t, ("$t", Tenant), ("$s", Site), ("$now", now));
            observations = HubDb.Exec(c, "DELETE FROM observations WHERE tenant_id = $t AND site_id = $s AND retain_until < $now", t, ("$t", Tenant), ("$s", Site), ("$now", now));
            if (events + evidence + observations > 0)
                audit.Log(c, t, userId, "events.forgotten", "retention_policy", null, observations + " observations, " + events + " events, " + evidence + " pieces of evidence past their day");
        });
        return new PruneResult(observations, events, evidence, references.Distinct().ToList());
    }
}

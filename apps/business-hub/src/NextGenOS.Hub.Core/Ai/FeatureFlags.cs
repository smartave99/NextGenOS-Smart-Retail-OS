using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Ai;

/// <summary>What the licence allows. The web program answers from the licence. Anything that is not told otherwise answers "nothing": the AI parts stay off.</summary>
public interface IEntitlements
{
    bool Has(string module);
}

public sealed class NoEntitlements : IEntitlements
{
    public bool Has(string module) => false;
}

/// <summary>
/// The switches for the major capabilities. Every one starts off, so that nothing new happens on a shop until its owner turns it on, and the owner can turn it off again.
/// A switch only counts when the licence has the "ai" module as well: <see cref="IsEnabled"/> is the one answer the program uses.
/// </summary>
public sealed class FeatureFlagService(HubDb db, IClock clock, AuditService audit, IEntitlements entitlements)
{
    public const string Tenant = "local";
    public const string Site = "main";
    /// <summary>The licence module that the AI capabilities belong to.</summary>
    public const string LicenceModule = "ai";

    /// <summary>True only when the owner switched it on AND the licence includes AI. An unknown name is off.</summary>
    public bool IsEnabled(string key) => FlagKey.All.Contains(key) && entitlements.Has(LicenceModule) && Chosen(key);

    /// <summary>What the owner chose, whatever the licence says (for the settings screen).</summary>
    public bool Chosen(string key) =>
        Convert.ToInt64(db.Scalar("SELECT enabled FROM feature_flags WHERE tenant_id = $t AND site_id = $s AND key = $k", ("$t", Tenant), ("$s", Site), ("$k", key)) ?? 0L) == 1;

    public bool Licensed => entitlements.Has(LicenceModule);

    public IReadOnlyList<FlagState> All() => FlagKey.All.Select(k => new FlagState(k, FlagKey.Label(k), FlagKey.Describe(k), Chosen(k), IsEnabled(k))).ToList();

    public void Set(string key, bool enabled, long? userId)
    {
        if (!FlagKey.All.Contains(key)) throw new HubException("unknown-flag", "That switch does not exist.");
        if (enabled && !entitlements.Has(LicenceModule)) throw new HubException("not-licensed", "The AI features are not part of this shop's licence.");
        var before = Chosen(key);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "INSERT INTO feature_flags(tenant_id, site_id, key, enabled, updated_at, updated_by) VALUES ($t, $s, $k, $e, $at, $u) " +
                "ON CONFLICT(tenant_id, site_id, key) DO UPDATE SET enabled = excluded.enabled, updated_at = excluded.updated_at, updated_by = excluded.updated_by", t,
                ("$t", Tenant), ("$s", Site), ("$k", key), ("$e", enabled ? 1 : 0), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId));
            audit.Log(c, t, userId, "ai.flag", "feature_flag", null, key + ": " + (before ? "on" : "off") + " -> " + (enabled ? "on" : "off"));
        });
    }
}

public sealed record FlagState(string Key, string Label, string Description, bool Chosen, bool Effective);

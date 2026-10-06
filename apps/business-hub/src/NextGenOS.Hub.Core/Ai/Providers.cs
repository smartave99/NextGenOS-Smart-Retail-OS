using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Ai;

/// <summary>The most an AI service may be used. An empty limit is no limit.</summary>
public sealed record ProviderLimits(long? RequestsPerDay = null, long? TokensPerDay = null, long? TokensPerMonth = null, long? CostMicrosPerMonth = null);

/// <summary>An AI service the owner connected. Prices are in millionths of the shop's own money for every 1,000 tokens (no currency is assumed).</summary>
public sealed record ProviderRecord(
    string Id, string Name, string Adapter, string Location, string BaseUrl, string? DefaultModel, string? SecretName, IReadOnlySet<string> Tasks, bool Enabled,
    long? PriceInMicrosPer1k, long? PriceOutMicrosPer1k, ProviderLimits Limits, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);

/// <summary>What the owner types to connect (or change) a service. Not a secret in it: the key is set apart.</summary>
public sealed record ProviderInput(
    string Id, string Name, string Adapter, string Location, string BaseUrl, string? DefaultModel, IEnumerable<string> Tasks,
    long? PriceInMicrosPer1k = null, long? PriceOutMicrosPer1k = null, ProviderLimits? Limits = null);

public sealed record ConsentRecord(string ProviderId, string DataClass, string Features, DateTimeOffset GrantedAt, long? GrantedBy);

/// <summary>
/// The AI services the owner connected, what each may receive, and where its key is kept. A new service is switched off and may receive nothing. Every change is written
/// to the audit log (never with a key in it), and changing where a service is clears what it was allowed to receive, because the permission was for the old place.
/// </summary>
public sealed partial class ProviderService(HubDb db, IClock clock, AuditService audit, ISecretStore secrets, IProviderFactory factory)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    public const int MaxKeyLength = Secrets.MaxLength;

    [GeneratedRegex(@"^[a-z0-9][a-z0-9\-]{0,39}$", RegexOptions.CultureInvariant)]
    private static partial Regex Slug();

    public IReadOnlyList<string> Adapters => factory.Adapters;

    public IReadOnlyList<ProviderRecord> List() => db.Query(Select + " ORDER BY created_at, id", Map, ("$t", Tenant), ("$s", Site));

    public ProviderRecord? Find(string id) => db.QueryOne(Select + " AND id = $id", Map, ("$t", Tenant), ("$s", Site), ("$id", id));

    public ProviderRecord Get(string id) => Find(id) ?? throw new HubException("no-provider", "That AI service does not exist.");

    public ProviderRecord Save(ProviderInput input, long? userId)
    {
        var id = (input.Id ?? "").Trim();
        if (!Slug().IsMatch(id)) throw new HubException("bad-id", "Give the service a short name of small letters, numbers and dashes, for example 'ollama-shop'.");
        var name = (input.Name ?? "").Trim();
        if (name.Length is < 1 or > 80) throw new HubException("bad-name", "Give the service a name (up to 80 letters).");
        if (!factory.Adapters.Contains(input.Adapter)) throw new HubException("bad-adapter", "This program cannot talk to that kind of service yet.");
        if (!ProviderLocation.IsKnown(input.Location)) throw new HubException("bad-location", "Say where the service runs.");
        var url = (input.BaseUrl ?? "").Trim();
        if (EndpointClassifier.Mismatch(input.Location, url) is { } mismatch) throw new HubException("bad-address", mismatch);
        var tasks = input.Tasks.Select(t => (t ?? "").Trim()).Where(t => t.Length > 0).Distinct().ToList();
        if (tasks.Count == 0) throw new HubException("no-tasks", "Choose what the service is used for.");
        if (tasks.FirstOrDefault(t => !AiTask.IsKnown(t)) is { } unknown) throw new HubException("bad-task", "'" + unknown + "' is not a kind of AI work this program knows.");
        var limits = input.Limits ?? new ProviderLimits();
        foreach (var number in new[] { input.PriceInMicrosPer1k, input.PriceOutMicrosPer1k, limits.RequestsPerDay, limits.TokensPerDay, limits.TokensPerMonth, limits.CostMicrosPerMonth })
            if (number is < 0) throw new HubException("bad-number", "Prices and limits cannot be negative.");
        var model = string.IsNullOrWhiteSpace(input.DefaultModel) ? null : input.DefaultModel.Trim();
        var now = Iso.Text(clock.UtcNow);

        db.InTransaction((c, t) =>
        {
            var before = HubDb.Query(c, Select + " AND id = $id", Map, t, ("$t", Tenant), ("$s", Site), ("$id", id)).FirstOrDefault();
            if (before is null)
            {
                HubDb.Exec(c,
                    "INSERT INTO ai_providers(tenant_id, site_id, id, name, adapter, location, base_url, default_model, tasks, enabled, price_in_micros_per_1k, price_out_micros_per_1k, " +
                    "limit_requests_per_day, limit_tokens_per_day, limit_tokens_per_month, limit_cost_micros_per_month, created_at, updated_at) " +
                    "VALUES ($t, $s, $id, $name, $adapter, $loc, $url, $model, $tasks, 0, $pin, $pout, $lr, $ltd, $ltm, $lc, $now, $now)", t,
                    ("$t", Tenant), ("$s", Site), ("$id", id), ("$name", name), ("$adapter", input.Adapter), ("$loc", input.Location), ("$url", url), ("$model", model),
                    ("$tasks", string.Join(',', tasks)), ("$pin", input.PriceInMicrosPer1k), ("$pout", input.PriceOutMicrosPer1k),
                    ("$lr", limits.RequestsPerDay), ("$ltd", limits.TokensPerDay), ("$ltm", limits.TokensPerMonth), ("$lc", limits.CostMicrosPerMonth), ("$now", now));
                audit.Log(c, t, userId, "ai.provider.add", "ai_provider", null, id + " (" + input.Location + ")");
                return;
            }

            // Moving a service to another place or address ends what it was allowed: it is switched off and its permissions are removed.
            var moved = before.Location != input.Location || !string.Equals(before.BaseUrl.TrimEnd('/'), url.TrimEnd('/'), StringComparison.OrdinalIgnoreCase) || before.Adapter != input.Adapter;
            HubDb.Exec(c,
                "UPDATE ai_providers SET name = $name, adapter = $adapter, location = $loc, base_url = $url, default_model = $model, tasks = $tasks, " +
                "enabled = CASE WHEN $moved = 1 THEN 0 ELSE enabled END, price_in_micros_per_1k = $pin, price_out_micros_per_1k = $pout, limit_requests_per_day = $lr, " +
                "limit_tokens_per_day = $ltd, limit_tokens_per_month = $ltm, limit_cost_micros_per_month = $lc, updated_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$t", Tenant), ("$s", Site), ("$id", id), ("$name", name), ("$adapter", input.Adapter), ("$loc", input.Location), ("$url", url), ("$model", model),
                ("$tasks", string.Join(',', tasks)), ("$moved", moved ? 1 : 0), ("$pin", input.PriceInMicrosPer1k), ("$pout", input.PriceOutMicrosPer1k),
                ("$lr", limits.RequestsPerDay), ("$ltd", limits.TokensPerDay), ("$ltm", limits.TokensPerMonth), ("$lc", limits.CostMicrosPerMonth), ("$now", now));
            if (moved)
            {
                HubDb.Exec(c, "DELETE FROM ai_provider_consent WHERE tenant_id = $t AND site_id = $s AND provider_id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id));
                audit.Log(c, t, userId, "ai.provider.moved", "ai_provider", null, id + ": " + before.Location + " -> " + input.Location + "; switched off, permissions removed");
            }
            else
            {
                audit.Log(c, t, userId, "ai.provider.change", "ai_provider", null, id);
            }
        });
        return Get(id);
    }

    public void SetEnabled(string id, bool enabled, long? userId)
    {
        var provider = Get(id);
        if (enabled && EndpointClassifier.Mismatch(provider.Location, provider.BaseUrl) is { } mismatch) throw new HubException("bad-address", mismatch);
        if (enabled && !factory.Adapters.Contains(provider.Adapter)) throw new HubException("bad-adapter", "This program cannot talk to that kind of service yet.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE ai_providers SET enabled = $e, updated_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$e", enabled ? 1 : 0), ("$now", Iso.Text(clock.UtcNow)), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, enabled ? "ai.provider.enable" : "ai.provider.disable", "ai_provider", null, id);
        });
    }

    public void Delete(string id, long? userId)
    {
        var provider = Get(id);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "DELETE FROM ai_provider_consent WHERE tenant_id = $t AND site_id = $s AND provider_id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id));
            HubDb.Exec(c, "DELETE FROM ai_providers WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "ai.provider.delete", "ai_provider", null, id);
        });
        if (provider.SecretName is not null) TryDeleteSecret(provider.SecretName);
    }

    // ---- the key ------------------------------------------------------------------------------------------------------------

    public bool HasSecret(string id)
    {
        var provider = Find(id);
        if (provider?.SecretName is null) return false;
        try { return secrets.Has(provider.SecretName); }
        catch (HubException) { return false; }   // a damaged safe means "no key", and the screen asks for it again
    }

    /// <summary>Keeps the key in the secret store and its name in the database. The key is never written to the database, the audit log or any message.</summary>
    public void SetSecret(string id, string secret, long? userId)
    {
        var provider = Get(id);
        if (string.IsNullOrWhiteSpace(secret)) throw new HubException("no-key", "Type the key.");
        var key = secret.Trim();
        if (key.Length > MaxKeyLength) throw new HubException("key-too-long", "That key is too long.");
        var name = "ai-provider/" + provider.Id;
        secrets.Set(name, key);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE ai_providers SET secret_name = $n, updated_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$n", name), ("$now", Iso.Text(clock.UtcNow)), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "ai.secret.set", "ai_provider", null, id);
        });
    }

    public void ClearSecret(string id, long? userId)
    {
        var provider = Get(id);
        if (provider.SecretName is not null) TryDeleteSecret(provider.SecretName);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE ai_providers SET secret_name = NULL, updated_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$now", Iso.Text(clock.UtcNow)), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "ai.secret.clear", "ai_provider", null, id);
        });
    }

    private void TryDeleteSecret(string name)
    {
        try { secrets.Delete(name); }
        catch (HubException) { /* a damaged safe has nothing to delete */ }
    }

    // ---- what a service may receive -------------------------------------------------------------------------------------------

    public IReadOnlyList<ConsentRecord> Consents(string providerId) => db.Query(
        "SELECT provider_id, data_class, features, granted_at, granted_by FROM ai_provider_consent WHERE tenant_id = $t AND site_id = $s AND provider_id = $p ORDER BY data_class",
        r => new ConsentRecord(r.Text("provider_id"), r.Text("data_class"), r.Text("features"), r.Time("granted_at"), r.IntOrNull("granted_by")),
        ("$t", Tenant), ("$s", Site), ("$p", providerId));

    /// <summary>The owner lets one service receive one kind of data (for every feature, or only for the named ones).</summary>
    public void Grant(string providerId, string dataClass, IEnumerable<string>? features, long? userId)
    {
        var provider = Get(providerId);
        if (!DataClass.IsKnown(dataClass)) throw new HubException("bad-class", "That kind of data does not exist.");
        if (Routing.NeverLeavesTheComputer(dataClass) && !ProviderLocation.StaysOnThisComputer(provider.Location))
            throw new HubException("never-leaves", DataClass.Label(dataClass) + " never leave this computer. That cannot be allowed for a service outside it.");
        var list = (features ?? []).Select(f => f.Trim()).Where(f => f.Length > 0).Distinct().ToList();
        if (list.Any(f => f.Contains(',') || f.Length > 40)) throw new HubException("bad-feature", "A feature name is not valid.");
        var text = list.Count == 0 ? "*" : string.Join(',', list);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c,
                "INSERT INTO ai_provider_consent(tenant_id, site_id, provider_id, data_class, features, granted_at, granted_by) VALUES ($t, $s, $p, $c, $f, $at, $u) " +
                "ON CONFLICT(tenant_id, site_id, provider_id, data_class) DO UPDATE SET features = excluded.features, granted_at = excluded.granted_at, granted_by = excluded.granted_by", t,
                ("$t", Tenant), ("$s", Site), ("$p", providerId), ("$c", dataClass), ("$f", text), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId));
            audit.Log(c, t, userId, "ai.consent.grant", "ai_provider", null, providerId + ": " + dataClass + " for " + text);
        });
    }

    public void Revoke(string providerId, string dataClass, long? userId)
    {
        Get(providerId);
        db.InTransaction((c, t) =>
        {
            var removed = HubDb.Exec(c, "DELETE FROM ai_provider_consent WHERE tenant_id = $t AND site_id = $s AND provider_id = $p AND data_class = $c", t,
                ("$t", Tenant), ("$s", Site), ("$p", providerId), ("$c", dataClass));
            if (removed > 0) audit.Log(c, t, userId, "ai.consent.revoke", "ai_provider", null, providerId + ": " + dataClass);
        });
    }

    /// <summary>The services as the routing rules see them.</summary>
    public IReadOnlyList<ProviderFacts> Facts()
    {
        var consents = db.Query("SELECT provider_id, data_class, features FROM ai_provider_consent WHERE tenant_id = $t AND site_id = $s",
            r => (Provider: r.Text("provider_id"), Fact: new ConsentFact(r.Text("data_class"), r.Text("features"))), ("$t", Tenant), ("$s", Site));
        return List().Select(p => new ProviderFacts(p.Id, p.Name, p.Location, p.Enabled, p.Tasks, EndpointClassifier.Classify(p.BaseUrl),
            consents.Where(c => c.Provider == p.Id).Select(c => c.Fact).ToList())).ToList();
    }

    // ---- reading --------------------------------------------------------------------------------------------------------------

    private const string Select =
        "SELECT id, name, adapter, location, base_url, default_model, secret_name, tasks, enabled, price_in_micros_per_1k, price_out_micros_per_1k, limit_requests_per_day, limit_tokens_per_day, " +
        "limit_tokens_per_month, limit_cost_micros_per_month, created_at, updated_at FROM ai_providers WHERE tenant_id = $t AND site_id = $s";

    private static ProviderRecord Map(SqliteDataReader r) => new(
        r.Text("id"), r.Text("name"), r.Text("adapter"), r.Text("location"), r.Text("base_url"), r.TextOrNull("default_model"), r.TextOrNull("secret_name"),
        r.Text("tasks").Split(',', StringSplitOptions.RemoveEmptyEntries).ToHashSet(), r.Int("enabled") == 1, r.IntOrNull("price_in_micros_per_1k"), r.IntOrNull("price_out_micros_per_1k"),
        new ProviderLimits(r.IntOrNull("limit_requests_per_day"), r.IntOrNull("limit_tokens_per_day"), r.IntOrNull("limit_tokens_per_month"), r.IntOrNull("limit_cost_micros_per_month")),
        r.Time("created_at"), r.Time("updated_at"));
}

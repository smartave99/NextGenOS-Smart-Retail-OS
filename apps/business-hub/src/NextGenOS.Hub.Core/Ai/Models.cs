using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Ai;

/// <summary>A model the owner knows about. The program never downloads one by itself: a model is added by the owner, and installed by the owner, from a source the owner trusts.</summary>
public sealed record ModelRecord(
    long Id, string ModelId, string? ProviderId, string? Family, string Task, string? Version, string? Quantization, string? Precision, long? ParameterCount, long? MemoryMb, long? DiskMb,
    string? Runtime, long? ContextLength, long? EmbeddingDimension, string? Licence, string CommercialUse, string Status, bool Installed, string? Notes, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);

public sealed record ModelInput(
    string ModelId, string Task, string? ProviderId = null, string? Family = null, string? Version = null, string? Quantization = null, string? Precision = null, long? ParameterCount = null,
    long? MemoryMb = null, long? DiskMb = null, string? Runtime = null, long? ContextLength = null, long? EmbeddingDimension = null, string? Licence = null, string CommercialUse = "unknown", string? Notes = null);

/// <summary>
/// The list of models and where each stands. Models are replaceable: nothing in the program names one. A newer model is not used because it is newer. It is added as a candidate, tested,
/// run beside the active one, and only then made the active one, and the one before it is kept so that it can be put back. A model whose licence does not allow use in a business is refused.
/// </summary>
public sealed class ModelRegistry(HubDb db, IClock clock, AuditService audit, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;

    public IReadOnlyList<ModelRecord> List(string? task = null) => db.Query(
        Select + (task is null ? "" : " AND task = $task") + " ORDER BY task, status, model_id", Map, ("$t", Tenant), ("$s", Site), ("$task", task));

    public ModelRecord? Find(long id) => db.QueryOne(Select + " AND id = $id", Map, ("$t", Tenant), ("$s", Site), ("$id", id));

    public ModelRecord Get(long id) => Find(id) ?? throw new HubException("no-model", "That model is not in the list.");

    /// <summary>The model in use for a kind of work, at one service (or any service when none is named).</summary>
    public ModelRecord? Active(string task, string? providerId = null) => db.QueryOne(
        Select + " AND task = $task AND status = 'active' AND ($p IS NULL OR provider_id = $p) ORDER BY updated_at DESC, id DESC", Map, ("$t", Tenant), ("$s", Site), ("$task", task), ("$p", providerId));

    public ModelRecord Add(ModelInput input, long? userId)
    {
        access.Require(Perm.Ai);
        var modelId = (input.ModelId ?? "").Trim();
        if (modelId.Length is < 1 or > 200) throw new HubException("bad-model", "Give the model's name.");
        if (!AiTask.IsKnown(input.Task)) throw new HubException("bad-task", "Say what the model is used for.");
        if (input.CommercialUse is not ("yes" or "no" or "unknown")) throw new HubException("bad-licence", "Say whether the model's licence allows use in a business: yes, no or not checked.");
        foreach (var number in new[] { input.ParameterCount, input.MemoryMb, input.DiskMb, input.ContextLength, input.EmbeddingDimension })
            if (number is < 0) throw new HubException("bad-number", "Sizes cannot be negative.");
        var now = Iso.Text(clock.UtcNow);
        long id = 0;
        try
        {
            db.InTransaction((c, t) =>
            {
                id = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM ai_models WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), System.Globalization.CultureInfo.InvariantCulture);
                HubDb.Exec(c,
                    "INSERT INTO ai_models(tenant_id, site_id, id, model_id, provider_id, family, task, version, quantization, precision, parameter_count, memory_mb, disk_mb, runtime, context_length, " +
                    "embedding_dimension, license, commercial_use, status, installed, notes, created_at, updated_at) " +
                    "VALUES ($t, $s, $id, $m, $p, $fam, $task, $ver, $q, $prec, $params, $mem, $disk, $rt, $ctx, $dim, $lic, $cu, 'candidate', 0, $notes, $now, $now)", t,
                    ("$t", Tenant), ("$s", Site), ("$id", id), ("$m", modelId), ("$p", Blank(input.ProviderId)), ("$fam", Blank(input.Family)), ("$task", input.Task), ("$ver", Blank(input.Version)),
                    ("$q", Blank(input.Quantization)), ("$prec", Blank(input.Precision)), ("$params", input.ParameterCount), ("$mem", input.MemoryMb), ("$disk", input.DiskMb), ("$rt", Blank(input.Runtime)),
                    ("$ctx", input.ContextLength), ("$dim", input.EmbeddingDimension), ("$lic", Blank(input.Licence)), ("$cu", input.CommercialUse), ("$notes", Blank(input.Notes)), ("$now", now));
                audit.Log(c, t, userId, "ai.model.add", "ai_model", id, modelId + " for " + input.Task);
            });
        }
        catch (SqliteException e) when (e.SqliteErrorCode == 19)
        {
            throw new HubException("duplicate-model", "That model is already in the list for this kind of work.");
        }

        return Get(id);
    }

    /// <summary>Moves a model along: candidate, testing, shadow (run beside the active one), active, retired. Making one active retires the one that was active (it is kept, to put back).</summary>
    public ModelRecord Move(long id, string to, long? userId, string? reason = null)
    {
        access.Require(Perm.Ai);
        var model = Get(id);
        if (!ModelStatus.IsKnown(to)) throw new HubException("bad-status", "That is not a stage a model can be in.");
        if (!ModelStatus.CanMove(model.Status, to))
            throw new HubException("bad-move", "A model that is '" + ModelStatus.Label(model.Status).ToLowerInvariant() + "' cannot be moved straight to '" + ModelStatus.Label(to).ToLowerInvariant() + "'.");
        if (to == ModelStatus.Active && model.CommercialUse == "no")
            throw new HubException("licence-no", "This model's licence does not allow use in a business, so it cannot be put in use.");
        var now = Iso.Text(clock.UtcNow);
        db.InTransaction((c, t) =>
        {
            if (to == ModelStatus.Active)
                HubDb.Exec(c, "UPDATE ai_models SET status = 'deprecated', updated_at = $now WHERE tenant_id = $t AND site_id = $s AND status = 'active' AND task = $task AND id <> $id " +
                    "AND COALESCE(provider_id, '') = $p", t, ("$now", now), ("$t", Tenant), ("$s", Site), ("$task", model.Task), ("$id", id), ("$p", model.ProviderId ?? ""));
            HubDb.Exec(c, "UPDATE ai_models SET status = $to, updated_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$to", to), ("$now", now), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "ai.model.move", "ai_model", id, model.ModelId + ": " + model.Status + " -> " + to + (string.IsNullOrWhiteSpace(reason) ? "" : " (" + reason.Trim() + ")"));
        });
        return Get(id);
    }

    /// <summary>Takes a model out of use and puts back the one that was in use before it (the most recently retired one for the same work and service). Returns the model now in use, or null.</summary>
    public ModelRecord? RollBack(long id, long? userId, string? reason = null)
    {
        access.Require(Perm.Ai);
        var model = Get(id);
        if (model.Status != ModelStatus.Active) throw new HubException("not-active", "Only the model in use can be rolled back.");
        var now = Iso.Text(clock.UtcNow);
        long? restored = null;
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE ai_models SET status = 'rolled-back', updated_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$now", now), ("$t", Tenant), ("$s", Site), ("$id", id));
            var previous = HubDb.Scalar(c, "SELECT id FROM ai_models WHERE tenant_id = $t AND site_id = $s AND status = 'deprecated' AND task = $task AND COALESCE(provider_id, '') = $p AND id <> $id " +
                "ORDER BY updated_at DESC, id DESC LIMIT 1", t, ("$t", Tenant), ("$s", Site), ("$task", model.Task), ("$p", model.ProviderId ?? ""), ("$id", id));
            if (previous is not null)
            {
                restored = Convert.ToInt64(previous, System.Globalization.CultureInfo.InvariantCulture);
                HubDb.Exec(c, "UPDATE ai_models SET status = 'active', updated_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$now", now), ("$t", Tenant), ("$s", Site), ("$id", restored));
            }

            audit.Log(c, t, userId, "ai.model.rollback", "ai_model", id, model.ModelId + (restored is null ? ": no earlier model to put back" : ": earlier model " + restored + " put back") + (string.IsNullOrWhiteSpace(reason) ? "" : " (" + reason.Trim() + ")"));
        });
        return restored is null ? null : Get(restored.Value);
    }

    public void SetInstalled(long id, bool installed, long? userId)
    {
        access.Require(Perm.Ai);
        var model = Get(id);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE ai_models SET installed = $i, updated_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$i", installed ? 1 : 0), ("$now", Iso.Text(clock.UtcNow)), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "ai.model.installed", "ai_model", id, model.ModelId + ": " + (installed ? "installed" : "not installed"));
        });
    }

    public void Remove(long id, long? userId)
    {
        access.Require(Perm.Ai);
        var model = Get(id);
        if (model.Status == ModelStatus.Active) throw new HubException("in-use", "That model is in use. Roll it back or retire it first.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "DELETE FROM ai_models WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "ai.model.remove", "ai_model", id, model.ModelId);
        });
    }

    private static string? Blank(string? text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();

    private const string Select =
        "SELECT id, model_id, provider_id, family, task, version, quantization, precision, parameter_count, memory_mb, disk_mb, runtime, context_length, embedding_dimension, license, commercial_use, " +
        "status, installed, notes, created_at, updated_at FROM ai_models WHERE tenant_id = $t AND site_id = $s";

    private static ModelRecord Map(SqliteDataReader r) => new(
        r.Int("id"), r.Text("model_id"), r.TextOrNull("provider_id"), r.TextOrNull("family"), r.Text("task"), r.TextOrNull("version"), r.TextOrNull("quantization"), r.TextOrNull("precision"),
        r.IntOrNull("parameter_count"), r.IntOrNull("memory_mb"), r.IntOrNull("disk_mb"), r.TextOrNull("runtime"), r.IntOrNull("context_length"), r.IntOrNull("embedding_dimension"),
        r.TextOrNull("license"), r.Text("commercial_use"), r.Text("status"), r.Int("installed") == 1, r.TextOrNull("notes"), r.Time("created_at"), r.Time("updated_at"));
}

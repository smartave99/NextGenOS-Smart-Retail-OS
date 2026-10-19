using System.Buffers.Binary;
using System.Globalization;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Knowledge;

/// <summary>
/// The vectors of the notes' pieces, kept in the shop's own database file (the table <c>knowledge_chunks</c>) and searched by comparing the question with every vector made by the same model. That
/// is exact and needs nothing installed, and is quick enough for thousands of pieces; for many more a different <see cref="IVectorIndex"/> (pgvector, Qdrant) takes its place without a change
/// anywhere else. Numbers are kept as 4-byte little-endian floats and made unit length when put in.
/// </summary>
public sealed class SqliteVectorIndex(HubDb db) : IVectorIndex
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    public const int MaxDimensions = 8192;

    public void Put(long sourceId, int seq, string model, float[] vector, DateTimeOffset at)
    {
        if (string.IsNullOrWhiteSpace(model) || model.Length > 120) throw new HubException("bad-model", "The name of the model that made the vectors is missing or too long.");
        var unit = Unit(vector) ?? throw new HubException("bad-vector", "A vector that is empty, too long, not a number or all zeros cannot be kept.");
        var bytes = new byte[unit.Length * 4];
        for (var i = 0; i < unit.Length; i++) BinaryPrimitives.WriteSingleLittleEndian(bytes.AsSpan(i * 4, 4), unit[i]);
        var changed = db.InTransaction((c, t) => HubDb.Exec(c,
            "UPDATE knowledge_chunks SET vector = $v, model = $m, dims = $d, embedded_at = $at WHERE tenant_id = $t AND site_id = $s AND source_id = $id AND seq = $q", t,
            ("$v", bytes), ("$m", model), ("$d", unit.Length), ("$at", Iso.Text(at)), ("$t", Tenant), ("$s", Site), ("$id", sourceId), ("$q", seq)));
        if (changed == 0) throw new HubException("no-piece", "That piece of a note does not exist (it may have been changed or retired while the vectors were made).");
    }

    public IReadOnlyList<VectorHit> Nearest(string model, float[] query, int limit, IReadOnlyCollection<long>? sourceIds = null)
    {
        var q = Unit(query);
        if (q is null || limit < 1) return [];
        var allowed = sourceIds is null ? null : sourceIds.ToHashSet();
        var hits = new List<VectorHit>();
        foreach (var row in db.Query(
            "SELECT c.source_id, c.seq, c.vector FROM knowledge_chunks c JOIN knowledge_sources s ON s.tenant_id = c.tenant_id AND s.site_id = c.site_id AND s.id = c.source_id " +
            "WHERE c.tenant_id = $t AND c.site_id = $s AND c.model = $m AND c.dims = $d AND c.vector IS NOT NULL AND s.retired_at IS NULL",
            r => (Source: r.GetInt64(0), Seq: r.GetInt32(1), Bytes: r.GetFieldValue<byte[]>(2)),
            ("$t", Tenant), ("$s", Site), ("$m", model), ("$d", q.Length)))
        {
            if (allowed is not null && !allowed.Contains(row.Source)) continue;
            if (row.Bytes.Length != q.Length * 4) continue;
            double dot = 0;
            for (var i = 0; i < q.Length; i++) dot += q[i] * (double)BinaryPrimitives.ReadSingleLittleEndian(row.Bytes.AsSpan(i * 4, 4));
            hits.Add(new VectorHit(row.Source, row.Seq, Math.Clamp(dot, -1, 1)));
        }

        return hits.OrderByDescending(h => h.Similarity).ThenBy(h => h.SourceId).ThenBy(h => h.Seq).Take(limit).ToList();
    }

    public int Clear() => db.InTransaction((c, t) => HubDb.Exec(c,
        "UPDATE knowledge_chunks SET vector = NULL, model = NULL, dims = NULL, embedded_at = NULL WHERE tenant_id = $t AND site_id = $s AND vector IS NOT NULL", t, ("$t", Tenant), ("$s", Site)));

    public IReadOnlyDictionary<string, long> Counts() => db.Query(
        "SELECT model, COUNT(*) AS n FROM knowledge_chunks WHERE tenant_id = $t AND site_id = $s AND vector IS NOT NULL GROUP BY model",
        r => (Model: r.Text("model"), N: r.Int("n")), ("$t", Tenant), ("$s", Site)).ToDictionary(x => x.Model, x => x.N);

    /// <summary>The same direction with length 1, or null when that cannot be made (empty, longer than allowed, a number that is not finite, or all zeros).</summary>
    private static float[]? Unit(float[]? vector)
    {
        if (vector is null || vector.Length == 0 || vector.Length > MaxDimensions) return null;
        double sum = 0;
        foreach (var x in vector)
        {
            if (!float.IsFinite(x)) return null;
            sum += (double)x * x;
        }

        if (sum <= 0 || !double.IsFinite(sum)) return null;
        var length = Math.Sqrt(sum);
        return vector.Select(x => (float)(x / length)).ToArray();
    }
}

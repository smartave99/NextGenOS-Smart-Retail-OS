using System.Globalization;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Insights;

/// <summary>What a stored low-stock finding says, read back from the run that made it.</summary>
public sealed record FindingDetail(
    long ItemId, string Name, string Unit, long SupplierId, string? SupplierName, string Status, long OnHandMilli, long SoldMilli, int Days, long OpenOrderMilli, int LeadDays, int SafetyDays,
    int ThresholdDays, int TargetDays, decimal? CoverDays, long ProposedMilli, long PackMilli, long MinOrderMilli, DateTimeOffset AsOf, DateTimeOffset TermsEnteredAt,
    IReadOnlyList<long> SaleDocuments, IReadOnlyList<long> OpenOrders, string Explanation, string WhyWrong);

public sealed record StoredFinding(long Id, long RunId, string RuleId, string RuleVersion, long ItemId, string Status, string State, DateTimeOffset CreatedAt, DateTimeOffset? DecidedAt, string? DecisionNote, FindingDetail Detail);

public sealed record InsightRun(long Id, string RuleId, string RuleVersion, DateTimeOffset AsOf, LowStockSettings Settings, string InputsHash, int ItemsChecked, int ItemsFlagged, DateTimeOffset CreatedAt);

/// <summary>What was looked at in a run, for the screen: how many items were judged, and why the rest were not.</summary>
/// <summary>How many items were judged and how many were left out, and why.</summary>
public sealed record RunCounts(int Judged, int NoTerms, int ShortHistory, int NoSales, int Fine);

public sealed record RunSummary(InsightRun Run, int Judged, int NoTerms, int ShortHistory, int NoSales, int Fine);

/// <summary>
/// Insights over the shop's own figures (blueprint INS-011): rules that are plain arithmetic on stock and sales, run once a day or when asked, whose results are kept with the figures they
/// rest on and the reasons, so that a person can see why, and the same figures always give the same answer. Off until the owner switches on "Stock forecasts" (and the licence has the AI
/// part); nothing here is needed to sell, and a failure here never reaches the till.
/// </summary>
public sealed class InsightService(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, OutboxService outbox, SupplyService supply, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    private static readonly TimeSpan RunEvery = TimeSpan.FromHours(20);
    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

    /// <summary>True while the rule may be run.</summary>
    public bool On => flags.IsEnabled(FlagKey.PredictiveInventory);

    private void RequireOn()
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "Stock forecasts are not part of this shop's licence.");
        if (!flags.IsEnabled(FlagKey.PredictiveInventory)) throw new HubException("insights-off", "Stock forecasts are switched off. The owner can switch them on under Settings, AI helpers.");
    }

    // ---- what the rule is told to use ---------------------------------------------------------------------------------------------------

    public LowStockSettings Settings()
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        return ReadSettings();
    }

    private LowStockSettings ReadSettings()
    {
        var text = db.QueryOne("SELECT settings FROM insight_settings WHERE tenant_id = $t AND site_id = $s AND rule_id = $r", r => r.Text("settings"), ("$t", Tenant), ("$s", Site), ("$r", LowStockRule.RuleId));
        if (text is null) return new LowStockSettings();
        try { var read = JsonSerializer.Deserialize<LowStockSettings>(text, Json); return read is { Problem: null } ? read : new LowStockSettings(); }
        catch (JsonException) { return new LowStockSettings(); }
    }

    public LowStockSettings SaveSettings(LowStockSettings settings, long? userId)
    {
        access.Require(Perm.Settings);
        if (settings.Problem is { } problem) throw new HubException("bad-settings", problem);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "INSERT INTO insight_settings(tenant_id, site_id, rule_id, settings, updated_at, updated_by) VALUES ($t, $s, $r, $v, $at, $u) " +
                          "ON CONFLICT(tenant_id, site_id, rule_id) DO UPDATE SET settings = $v, updated_at = $at, updated_by = $u", t,
                ("$t", Tenant), ("$s", Site), ("$r", LowStockRule.RuleId), ("$v", JsonSerializer.Serialize(settings, Json)), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId));
            audit.Log(c, t, userId, "insight.settings", "insight", null, LowStockRule.RuleId + ": " + settings.WindowDays + " day(s) looked at, " + settings.ReviewDays + " day(s) beyond delivery");
        });
        return ReadSettings();
    }

    // ---- reading the shop's figures --------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Everything the rule looks at for every item the shop keeps in stock, as at a moment: what is on the shelf, what was sold net of returns and voids in the days looked at, how long the
    /// item has been in stock, and what is on orders still open. Reads only; never changes anything.
    /// </summary>
    public IReadOnlyList<StockInput> Inputs(DateTimeOffset asOf, LowStockSettings settings)
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        return ReadInputs(asOf, settings);
    }

    private IReadOnlyList<StockInput> ReadInputs(DateTimeOffset asOf, LowStockSettings settings)
    {
        var from = Iso.Text(asOf.AddDays(-settings.WindowDays));
        var to = Iso.Text(asOf);
        var terms = db.Query("SELECT item_id, supplier_id, lead_days, safety_days, pack_milli, min_order_milli, entered_by, entered_at FROM supply_terms WHERE tenant_id = $t AND site_id = $s",
            r => new SupplyTerms(r.Int("item_id"), r.Int("supplier_id"), (int)r.Int("lead_days"), (int)r.Int("safety_days"), r.Int("pack_milli"), r.Int("min_order_milli"), r.IntOrNull("entered_by"), r.Time("entered_at")),
            ("$t", Tenant), ("$s", Site)).ToDictionary(x => x.ItemId);
        var suppliers = db.Query("SELECT id, name FROM parties WHERE kind = 'supplier'", r => (Id: r.Int("id"), Name: r.Text("name"))).ToDictionary(x => x.Id, x => x.Name);

        var rows = db.Query(
            "SELECT i.id, i.name, i.unit, " +
            "  COALESCE((SELECT SUM(m.qty_milli) FROM stock_moves m WHERE m.item_id = i.id AND m.at <= $to), 0) AS on_hand, " +
            // Sold: what left on a bill, less what came back on a credit note or when a bill was voided; the moves in the days looked at.
            "  COALESCE((SELECT SUM(-m.qty_milli) FROM stock_moves m JOIN documents d ON d.id = m.document_id WHERE m.item_id = i.id AND m.at > $from AND m.at <= $to " +
            "     AND ((d.type = 'invoice' AND m.reason IN ('sale', 'void')) OR (d.type = 'credit-note' AND m.reason = 'return'))), 0) AS sold, " +
            "  (SELECT MIN(m.at) FROM stock_moves m WHERE m.item_id = i.id AND m.reason <> 'valuation') AS first_at, " +
            "  COALESCE((SELECT SUM(l.qty_milli) FROM document_lines l JOIN documents d ON d.id = l.document_id WHERE l.item_id = i.id AND d.type = 'purchase' AND d.status = 'open'), 0) AS open_order " +
            "FROM items i WHERE i.active = 1 AND i.track_stock = 1 ORDER BY i.id",
            r => (Id: r.Int("id"), Name: r.Text("name"), Unit: r.Text("unit"), OnHand: r.Int("on_hand"), Sold: r.Int("sold"), First: r.TextOrNull("first_at"), Open: r.Int("open_order")),
            ("$from", from), ("$to", to));

        var result = new List<StockInput>(rows.Count);
        foreach (var row in rows)
        {
            var history = row.First is null ? 0 : (int)Math.Max(1, Math.Ceiling((asOf - Iso.Parse(row.First)).TotalDays));
            var saleDocs = row.Sold > 0 ? db.Query(
                "SELECT DISTINCT m.document_id FROM stock_moves m JOIN documents d ON d.id = m.document_id WHERE m.item_id = $i AND m.at > $from AND m.at <= $to AND d.type = 'invoice' AND m.reason = 'sale' ORDER BY m.document_id DESC LIMIT 10",
                r => r.Int("document_id"), ("$i", row.Id), ("$from", from), ("$to", to)) : [];
            var openOrders = row.Open > 0 ? db.Query(
                "SELECT DISTINCT d.id FROM document_lines l JOIN documents d ON d.id = l.document_id WHERE l.item_id = $i AND d.type = 'purchase' AND d.status = 'open' ORDER BY d.id LIMIT 10",
                r => r.Int("id"), ("$i", row.Id)) : [];
            var t = terms.GetValueOrDefault(row.Id);
            result.Add(new StockInput(row.Id, row.Name, row.Unit, row.OnHand, row.Sold, history, row.Open, t, t is null ? null : suppliers.GetValueOrDefault(t.SupplierId), saleDocs, openOrders));
        }

        return result;
    }

    // ---- running the rule --------------------------------------------------------------------------------------------------------------------

    /// <summary>The rule's answer for a moment, without keeping anything. The same shop figures and the same moment always give the same answer.</summary>
    public (IReadOnlyList<LowStockFinding> Findings, string Fingerprint) Preview(DateTimeOffset? asOf = null)
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        RequireOn();
        var at = asOf ?? clock.UtcNow;
        var settings = ReadSettings();
        var inputs = ReadInputs(at, settings);
        return (LowStockRule.Evaluate(inputs, settings), LowStockRule.Fingerprint(inputs, settings, at));
    }

    /// <summary>
    /// Runs the rule and keeps the run and what it found. What the previous run left open is replaced by what this one finds; an item a person set aside lately stays quiet for the days the
    /// owner chose, so the same warning is not shown every day. Each new finding leaves a message for the business event history, in the same step.
    /// </summary>
    public RunSummary Run(long? userId, DateTimeOffset? asOf = null)
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        RequireOn();
        var at = asOf ?? clock.UtcNow;
        var settings = ReadSettings();
        var inputs = ReadInputs(at, settings);
        var findings = LowStockRule.Evaluate(inputs, settings);
        var hash = LowStockRule.Fingerprint(inputs, settings, at);
        var flagged = findings.Where(f => LowStockStatus.NeedsAttention(f.Status)).ToList();
        var now = clock.UtcNow;

        var runId = db.InTransaction((c, t) =>
        {
            var id = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM insight_runs WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
            HubDb.Exec(c,
                "INSERT INTO insight_runs(tenant_id, site_id, id, rule_id, rule_version, as_of, settings, inputs_hash, items_checked, items_flagged, summary, created_at, created_by) VALUES ($t, $s, $id, $r, $v, $as, $set, $h, $n, $f, $sum, $now, $u)", t,
                ("$t", Tenant), ("$s", Site), ("$id", id), ("$r", LowStockRule.RuleId), ("$v", LowStockRule.Version), ("$as", Iso.Text(at)), ("$set", JsonSerializer.Serialize(settings, Json)), ("$h", hash),
                ("$n", findings.Count), ("$f", flagged.Count), ("$sum", JsonSerializer.Serialize(Counts(findings), Json)), ("$now", Iso.Text(now)), ("$u", userId));
            HubDb.Exec(c, "UPDATE insight_findings SET state = 'superseded', decided_at = $now WHERE tenant_id = $t AND site_id = $s AND rule_id = $r AND state = 'open'", t,
                ("$now", Iso.Text(now)), ("$t", Tenant), ("$s", Site), ("$r", LowStockRule.RuleId));
            foreach (var f in flagged)
            {
                if (settings.SnoozeDays > 0 && HubDb.Scalar(c,
                        "SELECT 1 FROM insight_findings WHERE tenant_id = $t AND site_id = $s AND rule_id = $r AND subject_type = 'item' AND subject_id = $i AND state = 'dismissed' AND decided_at > $since LIMIT 1", t,
                        ("$t", Tenant), ("$s", Site), ("$r", LowStockRule.RuleId), ("$i", f.ItemId), ("$since", Iso.Text(now.AddDays(-settings.SnoozeDays)))) is not null)
                    continue;   // set aside lately: quiet for now
                var detail = Detail(f, settings, at);
                var findingId = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM insight_findings WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
                HubDb.Exec(c,
                    "INSERT INTO insight_findings(tenant_id, site_id, id, run_id, rule_id, rule_version, subject_type, subject_id, status, payload, created_at) VALUES ($t, $s, $id, $run, $r, $v, 'item', $i, $st, $p, $now)", t,
                    ("$t", Tenant), ("$s", Site), ("$id", findingId), ("$run", id), ("$r", LowStockRule.RuleId), ("$v", LowStockRule.Version), ("$i", f.ItemId), ("$st", f.Status), ("$p", JsonSerializer.Serialize(detail, Json)), ("$now", Iso.Text(now)));
                outbox.Add(c, t, "recommendation.created", "finding", findingId,
                    new Dictionary<string, object?> { ["findingId"] = findingId, ["ruleId"] = LowStockRule.RuleId, ["ruleVersion"] = LowStockRule.Version, ["itemId"] = f.ItemId, ["status"] = f.Status, ["proposedMilli"] = f.ProposedMilli, ["runId"] = id },
                    DataClass.Internal, userId);
            }

            audit.Log(c, t, userId, "insight.run", "insight_run", id, LowStockRule.RuleId + ": " + findings.Count + " item(s) judged, " + flagged.Count + " running low");
            return id;
        });

        Prune();
        return Summary(runId)!;
    }

    private static RunCounts Counts(IReadOnlyList<LowStockFinding> judged)
    {
        int Count(string s) => judged.Count(j => j.Status == s);
        return new RunCounts(judged.Count - Count(LowStockStatus.NoTerms) - Count(LowStockStatus.ShortHistory) - Count(LowStockStatus.NoSales), Count(LowStockStatus.NoTerms), Count(LowStockStatus.ShortHistory), Count(LowStockStatus.NoSales), Count(LowStockStatus.Ok));
    }

    private static FindingDetail Detail(LowStockFinding f, LowStockSettings settings, DateTimeOffset asOf)
    {
        var i = f.Input;
        var t = i.Terms!;
        return new FindingDetail(i.ItemId, i.Name, i.Unit, t.SupplierId, i.SupplierName, f.Status, i.OnHandMilli, i.SoldMilli, f.EffectiveDays, i.OpenOrderMilli, t.LeadDays, t.SafetyDays, f.ThresholdDays, f.TargetDays,
            f.CoverDays, f.ProposedMilli, t.PackMilli, t.MinOrderMilli, asOf, t.EnteredAt, i.SaleDocuments, i.OpenOrders, LowStockRule.Explain(f, settings), LowStockRule.WhyWrong(f));
    }

    /// <summary>Runs the rule if it is switched on and has not been run in the last twenty hours. For the shop's upkeep; never throws into the till.</summary>
    public bool RunIfDue()
    {
        if (!On) return false;
        var last = db.Scalar("SELECT MAX(created_at) FROM insight_runs WHERE tenant_id = $t AND site_id = $s AND rule_id = $r", ("$t", Tenant), ("$s", Site), ("$r", LowStockRule.RuleId)) as string;
        if (last is not null && clock.UtcNow - Iso.Parse(last) < RunEvery) return false;
        Run(null);
        return true;
    }

    /// <summary>Forgets runs and decided findings older than half a year; what is still open is kept.</summary>
    private void Prune()
    {
        var cutoff = Iso.Text(clock.UtcNow.AddDays(-180));
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "DELETE FROM insight_findings WHERE tenant_id = $t AND site_id = $s AND state <> 'open' AND created_at < $c", t, ("$t", Tenant), ("$s", Site), ("$c", cutoff));
            HubDb.Exec(c, "DELETE FROM insight_runs WHERE tenant_id = $t AND site_id = $s AND created_at < $c AND NOT EXISTS (SELECT 1 FROM insight_findings f WHERE f.tenant_id = insight_runs.tenant_id AND f.site_id = insight_runs.site_id AND f.run_id = insight_runs.id)", t,
                ("$t", Tenant), ("$s", Site), ("$c", cutoff));
        });
    }

    // ---- reading what was found ------------------------------------------------------------------------------------------------------------

    private static InsightRun MapRun(Microsoft.Data.Sqlite.SqliteDataReader r) => new(r.Int("id"), r.Text("rule_id"), r.Text("rule_version"), r.Time("as_of"),
        JsonSerializer.Deserialize<LowStockSettings>(r.Text("settings"), Json) ?? new LowStockSettings(), r.Text("inputs_hash"), (int)r.Int("items_checked"), (int)r.Int("items_flagged"), r.Time("created_at"));

    private const string RunSelect = "SELECT id, rule_id, rule_version, as_of, settings, inputs_hash, items_checked, items_flagged, created_at FROM insight_runs WHERE tenant_id = $t AND site_id = $s";

    /// <summary>The most recent run and what it judged, or null when the rule has not been run.</summary>
    public RunSummary? Latest()
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        var run = db.QueryOne(RunSelect + " AND rule_id = $r ORDER BY id DESC LIMIT 1", MapRun, ("$t", Tenant), ("$s", Site), ("$r", LowStockRule.RuleId));
        return run is null ? null : Summary(run.Id);
    }

    private RunSummary? Summary(long runId) => db.QueryOne(RunSelect.Replace("created_at FROM", "created_at, summary FROM") + " AND id = $id", r =>
    {
        var counts = JsonSerializer.Deserialize<RunCounts>(r.Text("summary"), Json) ?? new RunCounts(0, 0, 0, 0, 0);
        return new RunSummary(MapRun(r), counts.Judged, counts.NoTerms, counts.ShortHistory, counts.NoSales, counts.Fine);
    }, ("$t", Tenant), ("$s", Site), ("$id", runId));

    /// <summary>The findings a person has not yet dealt with, most urgent first.</summary>
    public IReadOnlyList<StoredFinding> Open()
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        return db.Query(FindingSelect + " AND state = 'open' ORDER BY id", MapFinding, ("$t", Tenant), ("$s", Site));
    }

    public StoredFinding? Finding(long id)
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        return db.QueryOne(FindingSelect + " AND id = $id", MapFinding, ("$t", Tenant), ("$s", Site), ("$id", id));
    }

    private const string FindingSelect = "SELECT id, run_id, rule_id, rule_version, subject_id, status, state, payload, created_at, decided_at, decision_note FROM insight_findings WHERE tenant_id = $t AND site_id = $s";

    private static StoredFinding MapFinding(Microsoft.Data.Sqlite.SqliteDataReader r) => new(r.Int("id"), r.Int("run_id"), r.Text("rule_id"), r.Text("rule_version"), r.Int("subject_id"), r.Text("status"), r.Text("state"), r.Time("created_at"),
        r.TimeOrNull("decided_at"), r.TextOrNull("decision_note"), JsonSerializer.Deserialize<FindingDetail>(r.Text("payload"), Json)!);

    /// <summary>A person says this is not worth acting on now. It stays in the record, and the same warning stays quiet for the days the owner chose.</summary>
    public void Dismiss(long findingId, string? note, long? userId)
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        var words = EventRules.Words(note, 200, "reason");
        db.InTransaction((c, t) =>
        {
            var n = HubDb.Exec(c, "UPDATE insight_findings SET state = 'dismissed', decided_at = $at, decided_by = $u, decision_note = $n WHERE tenant_id = $t AND site_id = $s AND id = $id AND state = 'open'", t,
                ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$n", words), ("$t", Tenant), ("$s", Site), ("$id", findingId));
            if (n == 0) throw new HubException("no-finding", "That warning is not open any more.");
            audit.Log(c, t, userId, "insight.dismiss", "insight_finding", findingId, words);
        });
    }

    /// <summary>Marks a finding as acted on (an order was made from it). Used by the typed actions; the finding keeps the record of what was done.</summary>
    internal void MarkActioned(SqliteConnection c, SqliteTransaction t, long findingId, long? userId, string note)
    {
        HubDb.Exec(c, "UPDATE insight_findings SET state = 'actioned', decided_at = $at, decided_by = $u, decision_note = $n WHERE tenant_id = $t AND site_id = $s AND id = $id AND state = 'open'", t,
            ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$n", note), ("$t", Tenant), ("$s", Site), ("$id", findingId));
    }
}

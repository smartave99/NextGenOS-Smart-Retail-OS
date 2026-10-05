using System.Globalization;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;

namespace NextGenOS.Hub.Projects;

public sealed record Project(long Id, string Code, string Name, long PartyId, string? Site, string Status, long RetentionPctMilli, long AdvanceMinor, long AdvanceRecoveredMinor, string? StartOn, string? EndOn, string? Notes);

public sealed record BoqItem(long Id, long ProjectId, string Code, string Description, string Unit, long QtyMilli, long RateMinor, string Kind, string TaxCode, long? VariationId)
{
    /// <summary>What the item is worth in the contract: quantity times rate.</summary>
    public long AmountMinor => (2 * QtyMilli * RateMinor + 1000) / 2000;
}

public sealed record BoqProgress(BoqItem Item, long CumulativePctMilli, long BilledMinor);

public sealed record Cost(long Id, long ProjectId, DateTimeOffset At, string Kind, string Description, long? PartyId, long AmountMinor, long? BoqId, string? Reference);

public sealed record Variation(long Id, long ProjectId, int No, string Description, long AmountMinor, string TaxCode, string Status, DateTimeOffset At);

public sealed class ProgressInput
{
    public long BoqId { get; set; }
    /// <summary>How much of the item is complete in total, in thousandths of a percent (50000 is 50%).</summary>
    public long CumulativePctMilli { get; set; }
}

public sealed record ProjectStatus(
    Project Project, string ClientName, long ContractMinor, long VariationsMinor, long BilledNetMinor, long BilledGrossMinor, long PaidMinor, long OutstandingMinor,
    long RetentionHeldMinor, long AdvanceReceivedMinor, long AdvanceRecoveredMinor, long CostsMinor, IReadOnlyDictionary<string, long> CostsByKind,
    long ProfitSoFarMinor, long PercentCompleteMilli, IReadOnlyList<BoqProgress> Items);

/// <summary>Contract work: projects for clients, a bill of quantities, quotes, progress bills that hold back retention and recover advances, costs and variations.</summary>
public sealed class ProjectService(HubDb db, ShopContextProvider shop, IClock clock, DocumentService documents, PartyService parties, AuditService audit)
{
    private const string ProjectColumns = "id, code, name, party_id, site, status, retention_pct_milli, advance_minor, advance_recovered_minor, start_on, end_on, notes";

    private static Project MapProject(SqliteDataReader r) => new(r.Int("id"), r.Text("code"), r.Text("name"), r.Int("party_id"), r.TextOrNull("site"), r.Text("status"), r.Int("retention_pct_milli"),
        r.Int("advance_minor"), r.Int("advance_recovered_minor"), r.TextOrNull("start_on"), r.TextOrNull("end_on"), r.TextOrNull("notes"));

    private static BoqItem MapBoq(SqliteDataReader r) => new(r.Int("id"), r.Int("project_id"), r.Text("code"), r.Text("description"), r.Text("unit"), r.Int("qty_milli"), r.Int("rate_minor"), r.Text("kind"), r.Text("tax_code"), r.IntOrNull("variation_id"));

    // ---- projects --------------------------------------------------------------------------------------------------------------

    public Project Create(string code, string name, long clientId, string? site = null, string? retentionPercent = null, DateOnly? start = null)
    {
        if (string.IsNullOrWhiteSpace(code)) throw new HubException("code-missing", "Please give the project a code.");
        if (string.IsNullOrWhiteSpace(name)) throw new HubException("name-missing", "Please give the project a name.");
        var client = parties.Get(clientId) ?? throw new HubException("party-not-found", "That client was not found.");
        long retention;
        try { retention = ShopContext.QtyMilli(retentionPercent ?? shop.Current.Industry.RuleText("retentionPercent", "0")); }
        catch (FormatException) { throw new HubException("retention", "The retention must be a percent like 5 or 7.5."); }
        if (retention is < 0 or > 50_000) throw new HubException("retention", "The retention must be between 0 and 50 percent.");
        try
        {
            var id = db.InTransaction((c, t) => HubDb.Insert(c,
                "INSERT INTO projects(code, name, party_id, site, status, retention_pct_milli, start_on, created_at) VALUES ($c, $n, $p, $s, 'quoted', $r, $st, $at)", t,
                ("$c", code.Trim()), ("$n", name.Trim()), ("$p", client.Id), ("$s", string.IsNullOrWhiteSpace(site) ? null : site.Trim()), ("$r", retention),
                ("$st", start?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)), ("$at", Iso.Text(clock.UtcNow))));
            return Get(id)!;
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
        {
            throw new HubException("duplicate-code", $"There is already a project with the code {code.Trim()}.");
        }
    }

    public Project? Get(long id) => db.QueryOne($"SELECT {ProjectColumns} FROM projects WHERE id = $id", MapProject, ("$id", id));

    public IReadOnlyList<Project> List(string? status = null) =>
        db.Query($"SELECT {ProjectColumns} FROM projects WHERE ($s IS NULL OR status = $s) ORDER BY status, code", MapProject, ("$s", status));

    public void SetStatus(long id, string status)
    {
        if (status is not ("quoted" or "active" or "complete" or "closed")) throw new HubException("status", "That is not a project status.");
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE projects SET status = $s WHERE id = $id", t, ("$s", status), ("$id", id)));
    }

    // ---- bill of quantities ----------------------------------------------------------------------------------------------------

    public BoqItem AddBoq(long projectId, string code, string description, string unit, long qtyMilli, long rateMinor, string kind, string taxClass = "standard")
    {
        var project = Get(projectId) ?? throw new HubException("not-found", "That project was not found.");
        if (project.Status == "closed") throw new HubException("closed", "That project is closed.");
        if (string.IsNullOrWhiteSpace(description)) throw new HubException("description-missing", "Please describe the item.");
        if (qtyMilli <= 0) throw new HubException("qty", "The quantity must be more than zero.");
        if (rateMinor < 0) throw new HubException("price", "A rate cannot be negative.");
        var kinds = shop.Current.Industry.ItemKinds.Select(k => k.Id).ToList();
        if (!kinds.Contains(kind)) throw new HubException("kind", $"\"{kind}\" is not a kind of work item. Choose one of: {string.Join(", ", kinds)}.");
        string tax;
        try { tax = shop.Current.TaxCode(taxClass); } catch (ArgumentException ex) { throw new HubException("tax", ex.Message); }
        var id = db.InTransaction((c, t) => HubDb.Insert(c, "INSERT INTO boq_items(project_id, code, description, unit, qty_milli, rate_minor, kind, tax_code) VALUES ($p, $c, $d, $u, $q, $r, $k, $t)", t,
            ("$p", projectId), ("$c", code.Trim()), ("$d", description.Trim()), ("$u", string.IsNullOrWhiteSpace(unit) ? "lump sum" : unit.Trim()), ("$q", qtyMilli), ("$r", rateMinor), ("$k", kind), ("$t", tax)));
        return db.QueryOne("SELECT * FROM boq_items WHERE id = $id", MapBoq, ("$id", id))!;
    }

    public IReadOnlyList<BoqItem> Boq(long projectId) => db.Query("SELECT * FROM boq_items WHERE project_id = $p ORDER BY id", MapBoq, ("$p", projectId));

    /// <summary>The contract value: every bill-of-quantities item, including approved variations.</summary>
    public long ContractValue(long projectId) => Boq(projectId).Sum(b => b.AmountMinor);

    // ---- quote -----------------------------------------------------------------------------------------------------------------

    /// <summary>A quote (offer) for the client with the bill of quantities as its lines, tax added at the end.</summary>
    public DocumentView CreateQuote(long projectId, long? userId = null)
    {
        var project = Get(projectId) ?? throw new HubException("not-found", "That project was not found.");
        var boq = Boq(projectId).Where(b => b.VariationId is null).ToList();
        if (boq.Count == 0) throw new HubException("empty", "Add items to the bill of quantities first.");
        var draft = documents.CreateDraft(new DraftOptions
        {
            Type = DocTypes.Quote, PartyId = project.PartyId, ProjectId = projectId, UserId = userId, PricesIncludeTax = false, Notes = $"Quote for {project.Name}",
            Lines = boq.Select(b => new LineInput { Description = $"{b.Code} {b.Description}", QtyMilli = b.QtyMilli, Unit = b.Unit, UnitPriceMinor = b.RateMinor, TaxCode = b.TaxCode }).ToList(),
        });
        return documents.Issue(draft.Document.Id, new IssueOptions { UserId = userId });
    }

    // ---- advance ---------------------------------------------------------------------------------------------------------------

    /// <summary>Money the client paid before work started. It is kept as a payment on account; later bills recover it bit by bit.</summary>
    public void ReceiveAdvance(long projectId, long amountMinor, string method, string? reference = null, long? userId = null)
    {
        var project = Get(projectId) ?? throw new HubException("not-found", "That project was not found.");
        if (amountMinor <= 0) throw new HubException("amount", "The amount must be more than zero.");
        if (!shop.Current.PaymentMethods.Contains(method)) throw new HubException("method", $"\"{method}\" is not a way of paying here.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "INSERT INTO payments(project_id, party_id, method, amount_minor, reference, at, user_id, kind) VALUES ($p, $party, $m, $a, $r, $at, $u, 'advance')", t,
                ("$p", projectId), ("$party", project.PartyId), ("$m", method), ("$a", amountMinor), ("$r", reference), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId));
            HubDb.Exec(c, "UPDATE projects SET advance_minor = advance_minor + $a, status = CASE WHEN status = 'quoted' THEN 'active' ELSE status END WHERE id = $id", t, ("$a", amountMinor), ("$id", projectId));
            audit.Log(c, t, userId, "advance", "project", projectId, shop.Current.Money(amountMinor));
        });
    }

    // ---- progress bills --------------------------------------------------------------------------------------------------------

    /// <summary>How much of each item has been billed so far, as cumulative thousandths of a percent.</summary>
    public IReadOnlyDictionary<long, long> CumulativeBilled(long projectId) =>
        db.Query("SELECT pl.boq_id, MAX(pl.cum_pct_milli) AS cum FROM progress_lines pl JOIN documents d ON d.id = pl.document_id WHERE d.project_id = $p AND d.status = 'issued' GROUP BY pl.boq_id",
            r => (Boq: r.Int("boq_id"), Cum: r.Int("cum")), ("$p", projectId)).ToDictionary(x => x.Boq, x => x.Cum);

    private static long Part(long amountMinor, long pctMilli) => (2 * amountMinor * pctMilli + 100_000) / 200_000; // round half up

    /// <summary>
    /// A progress bill: for each item the percent complete in total; this bill charges the part since the last bill. The retention is held back
    /// (tax is charged in full), and a share of the advance is recovered in step with the work done.
    /// </summary>
    public DocumentView CreateProgressBill(long projectId, IReadOnlyList<ProgressInput> progress, string? notes = null, long? userId = null)
    {
        var context = shop.Current;
        var project = Get(projectId) ?? throw new HubException("not-found", "That project was not found.");
        if (project.Status is "closed" or "quoted") throw new HubException("not-active", project.Status == "quoted" ? "The project has not started: make it active first." : "That project is closed.");
        var boq = Boq(projectId).ToDictionary(b => b.Id);
        var previous = CumulativeBilled(projectId);
        var lines = new List<LineInput>();
        var rows = new List<(long Boq, long Cum, long Prev, long Value)>();
        long thisBill = 0;
        foreach (var input in progress)
        {
            var item = boq.GetValueOrDefault(input.BoqId) ?? throw new HubException("boq", "One of those items is not in this project.");
            if (input.CumulativePctMilli is < 0 or > 100_000) throw new HubException("percent", $"{item.Description}: the percent complete must be between 0 and 100.");
            var prev = previous.GetValueOrDefault(item.Id);
            if (input.CumulativePctMilli < prev) throw new HubException("percent-back", $"{item.Description} was already billed to {ShopContext.Qty(prev)}% and cannot go back to {ShopContext.Qty(input.CumulativePctMilli)}%.");
            if (input.CumulativePctMilli == prev) continue;
            var value = Part(item.AmountMinor, input.CumulativePctMilli) - Part(item.AmountMinor, prev);
            rows.Add((item.Id, input.CumulativePctMilli, prev, value));
            thisBill += value;
            lines.Add(new LineInput
            {
                Description = $"{item.Code} {item.Description}: {Pct(prev)} → {Pct(input.CumulativePctMilli)}", QtyMilli = 1000, Unit = "item", UnitPriceMinor = value, TaxCode = item.TaxCode, BoqId = item.Id,
            });
        }
        if (lines.Count == 0) throw new HubException("nothing-new", "No item has moved on since the last bill.");

        var adjustments = new List<TaxAdjustmentInput>();
        if (project.RetentionPctMilli > 0)
            adjustments.Add(new TaxAdjustmentInput { Code = "RET", Kind = "retention", Label = $"Retention {Pct(project.RetentionPctMilli)}", Percent = ShopContext.Qty(project.RetentionPctMilli), Base = "taxable" });
        long recovery = 0;
        var contract = boq.Values.Sum(b => b.AmountMinor);
        var advanceLeft = project.AdvanceMinor - project.AdvanceRecoveredMinor;
        if (advanceLeft > 0 && contract > 0)
        {
            recovery = Math.Min(advanceLeft, (2 * project.AdvanceMinor * thisBill + contract) / (2 * contract));
            // The last bill takes whatever is left, so the whole advance is recovered by the end of the work.
            var after = boq.Values.Sum(b => Part(b.AmountMinor, rows.Where(r => r.Boq == b.Id).Select(r => r.Cum).DefaultIfEmpty(previous.GetValueOrDefault(b.Id)).First()));
            if (after >= contract) recovery = advanceLeft;
            if (recovery > 0) adjustments.Add(new TaxAdjustmentInput { Code = "ADV", Kind = "advance", Label = "Advance recovered", Amount = context.Text(recovery) });
        }

        var id = db.InTransaction((c, t) =>
        {
            var docId = documents.CreateDraft(c, t, new DraftOptions
            {
                Type = DocTypes.ProgressBill, PartyId = project.PartyId, ProjectId = projectId, UserId = userId, PricesIncludeTax = false, Notes = notes, Lines = lines, Adjustments = adjustments,
            });
            documents.Issue(c, t, docId, new IssueOptions { UserId = userId, OnAccount = true, TermsDays = (int)context.Rule("paymentTermsDays", 30) });
            foreach (var r in rows)
                HubDb.Exec(c, "INSERT INTO progress_lines(document_id, boq_id, cum_pct_milli, prev_pct_milli, value_minor) VALUES ($d, $b, $cum, $prev, $v)", t, ("$d", docId), ("$b", r.Boq), ("$cum", r.Cum), ("$prev", r.Prev), ("$v", r.Value));
            if (recovery > 0) HubDb.Exec(c, "UPDATE projects SET advance_recovered_minor = advance_recovered_minor + $r WHERE id = $id", t, ("$r", recovery), ("$id", projectId));
            return docId;
        });
        return documents.Get(id)!;
    }

    private static string Pct(long milli) => ShopContext.Qty(milli).TrimEnd('0').TrimEnd('.') + "%";

    /// <summary>Every progress bill of a project, newest first.</summary>
    public IReadOnlyList<Document> Bills(long projectId) =>
        documents.List(new DocumentFilter { ProjectId = projectId, Type = DocTypes.ProgressBill, Limit = 500 });

    /// <summary>Takes a payment from the client on a progress bill.</summary>
    public DocumentView ReceivePayment(long billId, long amountMinor, string method, string? reference = null, long? userId = null) =>
        documents.AddPayment(billId, new PaymentInput { Method = method, AmountMinor = amountMinor, Reference = reference }, userId);

    // ---- retention -------------------------------------------------------------------------------------------------------------

    /// <summary>What has been held back from the client and not yet released.</summary>
    public long RetentionHeld(long projectId)
    {
        var held = Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(retention_minor), 0) FROM documents WHERE project_id = $p AND type = 'progress-bill' AND status = 'issued'", ("$p", projectId)) ?? 0L);
        var released = Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(total_minor), 0) FROM documents WHERE project_id = $p AND type = 'invoice' AND status = 'issued' AND meta LIKE '%\"retentionRelease\":\"1\"%'", ("$p", projectId)) ?? 0L);
        return held - released;
    }

    /// <summary>Releases retention to be paid by the client at the end of the work (or in part): an invoice for that amount. Tax was already charged in full on the progress bills, so there is none on this one.</summary>
    public DocumentView ReleaseRetention(long projectId, long? amountMinor = null, long? userId = null)
    {
        var project = Get(projectId) ?? throw new HubException("not-found", "That project was not found.");
        var held = RetentionHeld(projectId);
        var amount = amountMinor ?? held;
        if (amount <= 0 || amount > held) throw new HubException("retention-amount", $"Only {shop.Current.Money(held)} is being held.");
        var draft = documents.CreateDraft(new DraftOptions
        {
            Type = DocTypes.Invoice, PartyId = project.PartyId, ProjectId = projectId, UserId = userId, PricesIncludeTax = false, Notes = $"Retention released: {project.Name}",
            Meta = new Dictionary<string, string> { ["retentionRelease"] = "1" },
            Lines = { new LineInput { Description = $"Retention released for {project.Name}", QtyMilli = 1000, UnitPriceMinor = amount, TaxCode = "exempt", Unit = "item" } },
        });
        return documents.Issue(draft.Document.Id, new IssueOptions { UserId = userId, OnAccount = true });
    }

    // ---- costs -----------------------------------------------------------------------------------------------------------------

    public Cost AddCost(long projectId, string kind, string description, long amountMinor, long? supplierId = null, long? boqId = null, string? reference = null, DateTimeOffset? at = null)
    {
        _ = Get(projectId) ?? throw new HubException("not-found", "That project was not found.");
        var kinds = shop.Current.Industry.Rules.TryGetProperty("costKinds", out var list) ? list.EnumerateArray().Select(x => x.GetString()!).ToList() : new List<string> { "other" };
        if (!kinds.Contains(kind)) throw new HubException("kind", $"\"{kind}\" is not a kind of cost. Choose one of: {string.Join(", ", kinds)}.");
        if (string.IsNullOrWhiteSpace(description)) throw new HubException("description-missing", "Please say what the cost was for.");
        if (amountMinor <= 0) throw new HubException("amount", "The amount must be more than zero.");
        var id = db.InTransaction((c, t) => HubDb.Insert(c, "INSERT INTO project_costs(project_id, at, kind, description, party_id, amount_minor, boq_id, reference) VALUES ($p, $at, $k, $d, $s, $a, $b, $r)", t,
            ("$p", projectId), ("$at", Iso.Text(at ?? clock.UtcNow)), ("$k", kind), ("$d", description.Trim()), ("$s", supplierId), ("$a", amountMinor), ("$b", boqId), ("$r", reference)));
        return Costs(projectId).First(x => x.Id == id);
    }

    public IReadOnlyList<Cost> Costs(long projectId) => db.Query("SELECT id, project_id, at, kind, description, party_id, amount_minor, boq_id, reference FROM project_costs WHERE project_id = $p ORDER BY at DESC, id DESC",
        r => new Cost(r.Int("id"), r.Int("project_id"), r.Time("at"), r.Text("kind"), r.Text("description"), r.IntOrNull("party_id"), r.Int("amount_minor"), r.IntOrNull("boq_id"), r.TextOrNull("reference")), ("$p", projectId));

    // ---- variations ------------------------------------------------------------------------------------------------------------

    private static Variation MapVariation(SqliteDataReader r) => new(r.Int("id"), r.Int("project_id"), (int)r.Int("no"), r.Text("description"), r.Int("amount_minor"), r.Text("tax_code"), r.Text("status"), r.Time("at"));

    public Variation AddVariation(long projectId, string description, long amountMinor, string taxClass = "standard")
    {
        _ = Get(projectId) ?? throw new HubException("not-found", "That project was not found.");
        if (string.IsNullOrWhiteSpace(description)) throw new HubException("description-missing", "Please describe the change.");
        if (amountMinor == 0) throw new HubException("amount", "A variation needs an amount (a deduction is a negative amount).");
        string tax;
        try { tax = shop.Current.TaxCode(taxClass); } catch (ArgumentException ex) { throw new HubException("tax", ex.Message); }
        var id = db.InTransaction((c, t) =>
        {
            var no = Convert.ToInt32(HubDb.Scalar(c, "SELECT COALESCE(MAX(no), 0) + 1 FROM variations WHERE project_id = $p", t, ("$p", projectId)) ?? 1);
            return HubDb.Insert(c, "INSERT INTO variations(project_id, no, description, amount_minor, tax_code, status, at) VALUES ($p, $n, $d, $a, $t, 'proposed', $at)", t,
                ("$p", projectId), ("$n", no), ("$d", description.Trim()), ("$a", amountMinor), ("$t", tax), ("$at", Iso.Text(clock.UtcNow)));
        });
        return db.QueryOne("SELECT id, project_id, no, description, amount_minor, tax_code, status, at FROM variations WHERE id = $id", MapVariation, ("$id", id))!;
    }

    public IReadOnlyList<Variation> Variations(long projectId) => db.Query("SELECT id, project_id, no, description, amount_minor, tax_code, status, at FROM variations WHERE project_id = $p ORDER BY no", MapVariation, ("$p", projectId));

    /// <summary>An approved change joins the contract: it becomes a bill-of-quantities item that can be billed like any other.</summary>
    public Variation Approve(long variationId)
    {
        var v = db.QueryOne("SELECT id, project_id, no, description, amount_minor, tax_code, status, at FROM variations WHERE id = $id", MapVariation, ("$id", variationId)) ?? throw new HubException("not-found", "That variation was not found.");
        if (v.Status != "proposed") throw new HubException("decided", "That variation was already decided.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE variations SET status = 'approved' WHERE id = $id", t, ("$id", variationId));
            HubDb.Exec(c, "INSERT INTO boq_items(project_id, code, description, unit, qty_milli, rate_minor, kind, tax_code, variation_id) VALUES ($p, $c, $d, 'lump sum', 1000, $a, 'other', $t, $v)", t,
                ("$p", v.ProjectId), ("$c", $"VO-{v.No}"), ("$d", v.Description), ("$a", v.AmountMinor), ("$t", v.TaxCode), ("$v", variationId));
        });
        return Variations(v.ProjectId).First(x => x.Id == variationId);
    }

    public Variation Reject(long variationId)
    {
        var v = Variations(db.QueryOne("SELECT project_id FROM variations WHERE id = $id", r => new ProjectIdBox(r.Int("project_id")), ("$id", variationId))?.Id ?? throw new HubException("not-found", "That variation was not found.")).First(x => x.Id == variationId);
        if (v.Status != "proposed") throw new HubException("decided", "That variation was already decided.");
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE variations SET status = 'rejected' WHERE id = $id", t, ("$id", variationId)));
        return Variations(v.ProjectId).First(x => x.Id == variationId);
    }

    private sealed record ProjectIdBox(long Id);

    // ---- status ----------------------------------------------------------------------------------------------------------------

    public ProjectStatus Status(long projectId)
    {
        var project = Get(projectId) ?? throw new HubException("not-found", "That project was not found.");
        var boq = Boq(projectId);
        var cumulative = CumulativeBilled(projectId);
        var items = boq.Select(b => new BoqProgress(b, cumulative.GetValueOrDefault(b.Id), Part(b.AmountMinor, cumulative.GetValueOrDefault(b.Id)))).ToList();
        var contract = boq.Sum(b => b.AmountMinor);
        var variations = boq.Where(b => b.VariationId is not null).Sum(b => b.AmountMinor);
        var billed = db.Query("SELECT COALESCE(SUM(subtotal_minor), 0) AS net, COALESCE(SUM(total_minor), 0) AS gross, COALESCE(SUM(paid_minor), 0) AS paid, COALESCE(SUM(payable_minor - paid_minor), 0) AS owed " +
            "FROM documents WHERE project_id = $p AND type = 'progress-bill' AND status = 'issued'", r => (Net: r.Int("net"), Gross: r.Int("gross"), Paid: r.Int("paid"), Owed: r.Int("owed")), ("$p", projectId)).Single();
        var costs = Costs(projectId);
        var byKind = costs.GroupBy(x => x.Kind).ToDictionary(g => g.Key, g => g.Sum(x => x.AmountMinor));
        var client = parties.Get(project.PartyId)?.Name ?? "";
        var worked = items.Sum(i => i.BilledMinor);
        return new ProjectStatus(project, client, contract, variations, billed.Net, billed.Gross, billed.Paid, billed.Owed, RetentionHeld(projectId), project.AdvanceMinor, project.AdvanceRecoveredMinor,
            costs.Sum(x => x.AmountMinor), byKind, billed.Net - costs.Sum(x => x.AmountMinor), contract == 0 ? 0 : (worked * 100_000 + contract / 2) / contract, items);
    }
}

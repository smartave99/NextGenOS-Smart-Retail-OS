using System.Globalization;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Shop;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Import;

/// <summary>
/// Moving a shop across from an older system, in two separate steps:
///   1. <see cref="Check"/> reads the old system and builds the match report. It WRITES NOTHING (a dry run). This is the default.
///   2. <see cref="Import"/> writes what the person read, in ONE database transaction, after a copy of the Hub's database file has been made. If anything fails, nothing is kept.
/// Running it again adds nothing twice: every old row that was moved is remembered (import_id_map). The password is never an argument here: the source holds it, in memory, and the check
/// is done before the import so that the import needs no connection to the old system at all.
/// This class does not check who is asking: the screen does (the owner only), as for every service in the Hub.
/// </summary>
public sealed class ImportService(HubDb db, ShopContextProvider shop, IClock clock, AuditService audit, CatalogService catalog, PartyService parties, NextGenOS.Hub.Offers.OffersService offers, NextGenOS.Hub.Books.BooksService books, Access access)
{
    private const string Tenant = "local";
    private const string Site = "main";
    private static readonly JsonSerializerOptions Json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = false };

    /// <summary>Reads the old system and builds the report. Nothing is written to the Hub, and the old system is not changed.</summary>
    public ImportCheck Check(IOldSystemSource source)
    {
        access.Require(Perm.Settings);
        var data = source.Read();
        return CheckData(source.Kind, source.SourceId, source.Describe, data);
    }

    /// <summary>The same check on data that is already read (another kind of source, or a test).</summary>
    public ImportCheck CheckData(string sourceKind, string sourceId, string describe, OldSystemData data)
    {
        access.Require(Perm.Settings);
        var plan = Plan(sourceKind, sourceId, describe, data);
        return new ImportCheck(sourceKind, sourceId, describe, data, plan.Report);
    }

    private ImportPlan Plan(string sourceKind, string sourceId, string describe, OldSystemData data) =>
        PosMapper.Plan(sourceKind, sourceId, describe, data, shop.Current, Existing(sourceKind, sourceId), catalog.WouldTrackStock);

    private ExistingState Existing(string sourceKind, string sourceId)
    {
        var map = db.Query("SELECT entity, old_key FROM import_id_map WHERE tenant_id = $t AND site_id = $s AND source_kind = $k AND source_id = $i",
            r => (Entity: r.Text("entity"), Key: r.Text("old_key")), ("$t", Tenant), ("$s", Site), ("$k", sourceKind), ("$i", sourceId));
        return new ExistingState(
            map.Where(x => x.Entity == "item").Select(x => x.Key).ToHashSet(),
            map.Where(x => x.Entity == "customer").Select(x => x.Key).ToHashSet(),
            map.Where(x => x.Entity == "supplier").Select(x => x.Key).ToHashSet(),
            db.Query("SELECT barcode FROM items WHERE barcode IS NOT NULL", r => r.Text("barcode")).ToHashSet(StringComparer.Ordinal),
            db.Query("SELECT card_barcode FROM parties WHERE card_barcode IS NOT NULL", r => r.Text("card_barcode")).ToHashSet(StringComparer.Ordinal));
    }

    /// <summary>
    /// Writes what the person read in the check. It plans again against the shop as it is NOW and refuses if the numbers are not the ones that were read, or if anything blocks.
    /// A copy of the database file is made first (if it cannot be made, nothing is changed). Then everything is written in one transaction.
    /// </summary>
    public ImportResult Import(ImportCheck check, long? userId)
    {
        access.Require(Perm.Settings);
        var plan = Plan(check.SourceKind, check.SourceId, check.Describe, check.Data);
        if (plan.Report.Fingerprint != check.Report.Fingerprint)
            throw new HubException("import-changed", "The shop's records changed since you checked, so nothing was moved. Please check again and read the new report.");
        if (plan.Report.HasBlocking)
            throw new HubException("import-blocked", "Something in the report does not add up, so nothing was moved. Read the notes marked as blocking.");
        if (plan.Report.NothingToAdd)
            throw new HubException("import-nothing", "Everything from the older program is already here. There is nothing new to move.");

        var stamp = clock.UtcNow.UtcDateTime.ToString("yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture);
        var backup = db.BackupNow("before-import-" + stamp);   // throws, and nothing changes, if the copy cannot be made
        return db.InTransaction((c, t) => Write(c, t, plan, check, userId, backup));
    }

    private ImportResult Write(SqliteConnection c, SqliteTransaction t, ImportPlan plan, ImportCheck check, long? userId, string backup)
    {
        var now = Iso.Text(clock.UtcNow);
        var runId = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM import_runs WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
        int moves = 0, balances = 0, items = 0, customers = 0, suppliers = 0;
        long plannedStock = 0, plannedBalance = 0;

        foreach (var item in plan.Items)
        {
            long id;
            try { id = catalog.Create(c, t, item.Input); }
            catch (HubException ex) { throw new HubException(ex.Code, "The item \"" + item.Input.Name + "\" could not be added, so nothing was moved. " + ex.Message); }
            if (!item.Active) HubDb.Exec(c, "UPDATE items SET active = 0 WHERE id = $id", t, ("$id", id));
            if (item.MovesStock)
            {
                // The stock comes in worth its quantity times the cost price it had (half-up, as the stock report always worked it out), and the books take it in as an opening entry (decision 32).
                var move = StockCost.Insert(c, t, id, item.StockMilli, "opening stock", null, "Moved from the older program", clock.UtcNow, userId, StockCost.Worth(item.StockMilli, item.Input.CostMinor));
                books.SyncStockMove(c, t, move, userId);
                moves++; plannedStock += item.StockMilli;
            }
            Remember(c, t, check, "item", item.OldKey, id, runId);
            items++;
        }

        foreach (var party in plan.Parties)
        {
            long id;
            try { id = parties.Create(c, t, party.Input); }
            catch (HubException ex) { throw new HubException(ex.Code, "\"" + party.Input.Name + "\" could not be added, so nothing was moved. " + ex.Message); }
            if (party.DiscountPctMilli > 0) offers.SetPartyDiscount(c, t, id, party.DiscountPctMilli, true, userId);
            if (party.BalanceMinor != 0)
            {
                HubDb.Exec(c, "INSERT INTO party_opening_balances(party_id, balance_minor, as_of, run_id) VALUES ($p, $b, $at, $r)", t,
                    ("$p", id), ("$b", party.BalanceMinor), ("$at", now), ("$r", runId));
                balances++; plannedBalance += party.BalanceMinor;
            }
            Remember(c, t, check, party.Entity, party.OldKey, id, runId);
            if (party.Entity == "customer") customers++; else suppliers++;
        }

        // The Hub must now hold exactly what the report promised. If it does not, nothing is kept.
        var storedStock = Convert.ToInt64(HubDb.Scalar(c,
            "SELECT COALESCE(SUM(m.qty_milli), 0) FROM stock_moves m JOIN import_id_map x ON x.entity = 'item' AND x.hub_id = m.item_id AND x.run_id = $r WHERE m.reason = 'opening stock'", t, ("$r", runId)), CultureInfo.InvariantCulture);
        var storedBalance = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(balance_minor), 0) FROM party_opening_balances WHERE run_id = $r", t, ("$r", runId)), CultureInfo.InvariantCulture);
        if (storedStock != plannedStock || storedBalance != plannedBalance)
            throw new HubException("import-check", "After writing, the shop's stock or balances were not what the report said, so nothing was moved.");

        HubDb.Exec(c,
            "INSERT INTO import_runs(id, at, user_id, source_kind, source_id, items_added, customers_added, suppliers_added, stock_moves_added, balances_added, backup_path, report) " +
            "VALUES ($id, $at, $u, $k, $s, $i, $c, $su, $m, $b, $bk, $rep)", t,
            ("$id", runId), ("$at", now), ("$u", userId), ("$k", check.SourceKind), ("$s", check.SourceId), ("$i", items), ("$c", customers), ("$su", suppliers), ("$m", moves), ("$b", balances),
            ("$bk", backup), ("$rep", JsonSerializer.Serialize(plan.Report, Json)));
        audit.Log(c, t, userId, "import", "import", runId,
            $"Moved from {check.Describe}: {items} item(s), {customers} customer(s), {suppliers} supplier(s), {moves} stock count(s), {balances} balance(s). A copy of the shop's data was made first: {Path.GetFileName(backup)}.");
        return new ImportResult(runId, items, customers, suppliers, moves, balances, backup);
    }

    private static void Remember(SqliteConnection c, SqliteTransaction t, ImportCheck check, string entity, string oldKey, long hubId, long runId) =>
        HubDb.Exec(c, "INSERT INTO import_id_map(source_kind, source_id, entity, old_key, hub_id, run_id) VALUES ($k, $s, $e, $o, $h, $r)", t,
            ("$k", check.SourceKind), ("$s", check.SourceId), ("$e", entity), ("$o", oldKey), ("$h", hubId), ("$r", runId));

    /// <summary>The moves done so far, newest first.</summary>
    public IReadOnlyList<ImportRun> Runs(int limit = 20) => db.Query(
        "SELECT r.id, r.at, u.display_name AS who, r.source_id, r.items_added, r.customers_added, r.suppliers_added, r.balances_added FROM import_runs r LEFT JOIN users u ON u.id = r.user_id " +
        "WHERE r.tenant_id = $t AND r.site_id = $s ORDER BY r.id DESC LIMIT $n",
        r => new ImportRun(r.Int("id"), r.Time("at"), r.TextOrNull("who"), r.Text("source_id"), (int)r.Int("items_added"), (int)r.Int("customers_added"), (int)r.Int("suppliers_added"), (int)r.Int("balances_added")),
        ("$t", Tenant), ("$s", Site), ("$n", limit));

    /// <summary>What a customer or supplier owed the shop when the shop was moved across (negative: the shop owed them). Null when nothing was moved for that person.</summary>
    public long? OpeningBalance(long partyId) =>
        db.Scalar("SELECT balance_minor FROM party_opening_balances WHERE tenant_id = $t AND site_id = $s AND party_id = $p", ("$t", Tenant), ("$s", Site), ("$p", partyId)) is { } v ? Convert.ToInt64(v, CultureInfo.InvariantCulture) : null;
}

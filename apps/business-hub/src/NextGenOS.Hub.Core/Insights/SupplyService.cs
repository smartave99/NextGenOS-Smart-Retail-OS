using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Insights;

/// <summary>
/// Who supplies an item and how long they take (blueprint INS-011). A person types these in; the low-stock rule trusts what a named person wrote and judges nothing without it.
/// Only goods the shop keeps in stock can have a delivery time.
/// </summary>
public sealed class SupplyService(HubDb db, IClock clock, AuditService audit, Access access)
{
    private const string Tenant = "local";
    private const string Site = "main";

    private const string Select = "SELECT item_id, supplier_id, lead_days, safety_days, pack_milli, min_order_milli, entered_by, entered_at FROM supply_terms WHERE tenant_id = $t AND site_id = $s";

    private static SupplyTerms Map(Microsoft.Data.Sqlite.SqliteDataReader r) => new(r.Int("item_id"), r.Int("supplier_id"), (int)r.Int("lead_days"), (int)r.Int("safety_days"), r.Int("pack_milli"), r.Int("min_order_milli"), r.IntOrNull("entered_by"), r.Time("entered_at"));

    public SupplyTerms? Get(long itemId)
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        return db.QueryOne(Select + " AND item_id = $i", Map, ("$t", Tenant), ("$s", Site), ("$i", itemId));
    }

    public IReadOnlyList<SupplyTerms> All()
    {
        access.RequireAny(Perm.Stock, Perm.Purchases);
        return db.Query(Select + " ORDER BY item_id", Map, ("$t", Tenant), ("$s", Site));
    }

    /// <summary>Keeps who supplies an item and the terms, replacing what was there. Returns what was kept.</summary>
    public SupplyTerms Set(long itemId, long supplierId, int leadDays, int safetyDays, long packMilli, long minOrderMilli, long? userId)
    {
        access.Require(Perm.Purchases);
        if (leadDays is < 0 or > 365) throw new HubException("bad-lead", "The supplier's delivery time must be between 0 and 365 days.");
        if (safetyDays is < 0 or > 365) throw new HubException("bad-safety", "The spare days must be between 0 and 365.");
        if (packMilli <= 0) throw new HubException("bad-pack", "The pack size must be more than nothing (1 if it is sold one by one).");
        if (minOrderMilli < 0) throw new HubException("bad-minimum", "The least that is sent cannot be below nothing.");
        db.InTransaction((c, t) =>
        {
            var item = HubDb.Query(c, "SELECT track_stock, active, name FROM items WHERE id = $i", r => (Tracked: r.Flag("track_stock"), Active: r.Flag("active"), Name: r.Text("name")), t, ("$i", itemId)).FirstOrDefault();
            if (item.Name is null) throw new HubException("item-not-found", "That item was not found.");
            if (!item.Tracked) throw new HubException("not-stocked", item.Name + " is not kept in stock, so it has no delivery time to judge by.");
            var supplier = HubDb.Query(c, "SELECT kind FROM parties WHERE id = $p", r => r.Text("kind"), t, ("$p", supplierId)).FirstOrDefault();
            if (supplier is null) throw new HubException("party-not-found", "That supplier was not found.");
            if (supplier != "supplier") throw new HubException("not-supplier", "That is not a supplier.");
            HubDb.Exec(c,
                "INSERT INTO supply_terms(tenant_id, site_id, item_id, supplier_id, lead_days, safety_days, pack_milli, min_order_milli, entered_by, entered_at) VALUES ($t, $s, $i, $p, $l, $sa, $pk, $m, $u, $at) " +
                "ON CONFLICT(tenant_id, site_id, item_id) DO UPDATE SET supplier_id = $p, lead_days = $l, safety_days = $sa, pack_milli = $pk, min_order_milli = $m, entered_by = $u, entered_at = $at", t,
                ("$t", Tenant), ("$s", Site), ("$i", itemId), ("$p", supplierId), ("$l", leadDays), ("$sa", safetyDays), ("$pk", packMilli), ("$m", minOrderMilli), ("$u", userId), ("$at", Iso.Text(clock.UtcNow)));
            audit.Log(c, t, userId, "supply.set", "item", itemId, "supplier " + supplierId + ", " + leadDays + " day(s) + " + safetyDays + " spare");
        });
        return db.QueryOne(Select + " AND item_id = $i", Map, ("$t", Tenant), ("$s", Site), ("$i", itemId))!;
    }

    /// <summary>Takes the terms away: the item is no longer judged.</summary>
    public void Clear(long itemId, long? userId)
    {
        access.Require(Perm.Purchases);
        db.InTransaction((c, t) =>
        {
            var n = HubDb.Exec(c, "DELETE FROM supply_terms WHERE tenant_id = $t AND site_id = $s AND item_id = $i", t, ("$t", Tenant), ("$s", Site), ("$i", itemId));
            if (n > 0) audit.Log(c, t, userId, "supply.clear", "item", itemId, null);
        });
    }
}

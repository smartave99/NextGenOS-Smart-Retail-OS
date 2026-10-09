using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Catalog;

/// <summary>An item in a quick group, with the usual quantity (in thousandths).</summary>
public sealed record GroupMember(long ItemId, string Name, string Unit, long QtyMilli);

/// <summary>A quick group of items (the older POS's combo pack): picked at the till, it adds each member as a line of its own at its own price.</summary>
public sealed record ItemGroup(long Id, string Name, string? Barcode, bool Active, IReadOnlyList<GroupMember> Members);

public sealed class GroupInput
{
    public long? Id { get; set; }
    public string Name { get; set; } = "";
    public string? Barcode { get; set; }
    public bool Active { get; set; } = true;
    public List<(long ItemId, long QtyMilli)> Members { get; set; } = new();
}

/// <summary>
/// Quick groups of items (study 02 A2.7, combo packs). There is no bundle price: a group is only a faster way of adding several items, each sold at its own price, so nothing about tax, discounts, stock or
/// the books is different from adding the items one by one.
/// </summary>
public sealed class GroupService(HubDb db, CatalogService catalog, AuditService audit, IClock clock, Access access)
{
    private static readonly string[] Pickers = [Perm.Sell, Perm.Orders, Perm.Catalog];

    private const int MaxMembers = 50;

    private IReadOnlyList<GroupMember> Members(SqliteConnection? c, SqliteTransaction? t, long groupId)
    {
        const string sql = "SELECT m.item_id, i.name, i.unit, m.qty_milli FROM item_group_members m JOIN items i ON i.id = m.item_id WHERE m.group_id = $g ORDER BY i.name COLLATE NOCASE, i.id";
        Func<SqliteDataReader, GroupMember> map = r => new GroupMember(r.Int("item_id"), r.Text("name"), r.Text("unit"), r.Int("qty_milli"));
        return c is null ? db.Query(sql, map, ("$g", groupId)) : HubDb.Query(c, sql, map, t, ("$g", groupId));
    }

    /// <summary>The groups, by name; those switched off only when asked for. A cashier may read the active ones (to pick one at the till).</summary>
    public IReadOnlyList<ItemGroup> List(bool includeInactive = false)
    {
        var actor = access.RequireAny(Pickers);
        if (includeInactive && !actor.CanAny([Perm.Catalog])) throw new HubException("forbidden", "You are not allowed to do that.");
        var heads = db.Query("SELECT id, name, barcode, active FROM item_groups WHERE ($all = 1 OR active = 1) ORDER BY name COLLATE NOCASE", r => (Id: r.Int("id"), Name: r.Text("name"), Barcode: r.TextOrNull("barcode"), Active: r.Flag("active")), ("$all", includeInactive ? 1 : 0));
        return heads.Select(h => new ItemGroup(h.Id, h.Name, h.Barcode, h.Active, Members(null, null, h.Id))).ToList();
    }

    public ItemGroup? Get(long id)
    {
        access.RequireAny(Pickers);
        return db.Query("SELECT id, name, barcode, active FROM item_groups WHERE id = $id", r => (Id: r.Int("id"), Name: r.Text("name"), Barcode: r.TextOrNull("barcode"), Active: r.Flag("active")), ("$id", id))
            .Select(h => new ItemGroup(h.Id, h.Name, h.Barcode, h.Active, Members(null, null, h.Id))).FirstOrDefault();
    }

    /// <summary>The group a scanned or typed barcode names, if any (a group's barcode is never an item's).</summary>
    public ItemGroup? FindByBarcode(string code)
    {
        access.RequireAny(Pickers);
        var typed = (code ?? "").Trim();
        if (typed.Length == 0) return null;
        return db.Query("SELECT id, name, barcode, active FROM item_groups WHERE active = 1 AND barcode = $b", r => (Id: r.Int("id"), Name: r.Text("name"), Barcode: r.TextOrNull("barcode"), Active: r.Flag("active")), ("$b", typed))
            .Select(h => new ItemGroup(h.Id, h.Name, h.Barcode, h.Active, Members(null, null, h.Id))).FirstOrDefault();
    }

    /// <summary>Adds a group, or changes the one named by the id. A name (not used by another group) and at least one item are needed; a barcode, if given, must not be an item's or another group's.</summary>
    public ItemGroup Save(GroupInput input, long? userId = null)
    {
        access.Require(Perm.Catalog);
        var name = (input.Name ?? "").Trim();
        if (name.Length == 0) throw new HubException("group-name", "Please give the group a name.");
        if (name.Length > 80) throw new HubException("group-name", "That name is too long.");
        var barcode = string.IsNullOrWhiteSpace(input.Barcode) ? null : input.Barcode.Trim();
        if (barcode is { Length: > 40 }) throw new HubException("group-barcode", "That barcode is too long.");
        if (input.Members.Count == 0) throw new HubException("group-empty", "A group needs at least one item.");
        if (input.Members.Count > MaxMembers) throw new HubException("group-big", $"A group can have at most {MaxMembers} items.");
        if (input.Members.GroupBy(m => m.ItemId).Any(g => g.Count() > 1)) throw new HubException("group-twice", "An item is in the group twice. Give it once, with the quantity you want.");
        if (input.Members.Any(m => m.QtyMilli <= 0)) throw new HubException("group-qty", "Each item needs a quantity above nothing.");
        foreach (var m in input.Members)
        {
            var item = catalog.Get(m.ItemId) ?? throw new HubException("group-item", "One of the items was not found.");
            if (!item.Active) throw new HubException("group-item", $"{item.Name} is no longer sold.");
        }
        if (barcode is not null && catalog.FindByCode(barcode) is { } clash) throw new HubException("group-barcode", $"That barcode is on the item {clash.Name}.");
        return db.InTransaction((c, t) =>
        {
            if (HubDb.Scalar(c, "SELECT 1 FROM item_groups WHERE name = $n COLLATE NOCASE AND id <> $id", t, ("$n", name), ("$id", input.Id ?? 0)) is not null)
                throw new HubException("group-name", "Another group has that name.");
            if (barcode is not null && HubDb.Scalar(c, "SELECT 1 FROM item_groups WHERE barcode = $b AND id <> $id", t, ("$b", barcode), ("$id", input.Id ?? 0)) is not null)
                throw new HubException("group-barcode", "Another group has that barcode.");
            long id;
            if (input.Id is { } existing)
            {
                if (HubDb.Exec(c, "UPDATE item_groups SET name = $n, barcode = $b, active = $a WHERE id = $id", t, ("$n", name), ("$b", barcode), ("$a", input.Active ? 1 : 0), ("$id", existing)) == 0)
                    throw new HubException("not-found", "That group was not found.");
                HubDb.Exec(c, "DELETE FROM item_group_members WHERE group_id = $id", t, ("$id", existing));
                id = existing;
            }
            else id = HubDb.Insert(c, "INSERT INTO item_groups(name, barcode, active, created_at) VALUES ($n, $b, $a, $at)", t, ("$n", name), ("$b", barcode), ("$a", input.Active ? 1 : 0), ("$at", Iso.Text(clock.UtcNow)));
            foreach (var m in input.Members)
                HubDb.Exec(c, "INSERT INTO item_group_members(group_id, item_id, qty_milli) VALUES ($g, $i, $q)", t, ("$g", id), ("$i", m.ItemId), ("$q", m.QtyMilli));
            audit.Log(c, t, userId, input.Id is null ? "group-add" : "group-change", "item-group", id, $"{name}: {input.Members.Count} item(s)");
            var head = HubDb.Query(c, "SELECT id, name, barcode, active FROM item_groups WHERE id = $id", r => (Id: r.Int("id"), Name: r.Text("name"), Barcode: r.TextOrNull("barcode"), Active: r.Flag("active")), t, ("$id", id)).Single();
            return new ItemGroup(head.Id, head.Name, head.Barcode, head.Active, Members(c, t, id));
        });
    }

    /// <summary>Takes a group away. Only the shortcut goes: the items, and every bill that used it, are untouched.</summary>
    public void Delete(long id, long? userId = null)
    {
        access.Require(Perm.Catalog);
        db.InTransaction((c, t) =>
        {
            var name = HubDb.Scalar(c, "SELECT name FROM item_groups WHERE id = $id", t, ("$id", id)) as string ?? throw new HubException("not-found", "That group was not found.");
            HubDb.Exec(c, "DELETE FROM item_group_members WHERE group_id = $id", t, ("$id", id));
            HubDb.Exec(c, "DELETE FROM item_groups WHERE id = $id", t, ("$id", id));
            audit.Log(c, t, userId, "group-delete", "item-group", id, name);
        });
    }
}

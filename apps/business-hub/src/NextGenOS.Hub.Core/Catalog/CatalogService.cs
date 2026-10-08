using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Books;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Catalog;

/// <summary>Items (products, menu items, titles, services, materials) and their stock.</summary>
public sealed class CatalogService(HubDb db, ShopContextProvider shop, IClock clock, Access access, BooksService books)
{
    private const string Columns = "id, kind, sku, barcode, name, category, unit, price_minor, trade_price_minor, cost_minor, tax_code, track_stock, reorder_milli, station, duration_min, attrs, active";

    private static Item Map(SqliteDataReader r) => new(
        r.Int("id"), r.Text("kind"), r.TextOrNull("sku"), r.TextOrNull("barcode"), r.Text("name"), r.TextOrNull("category"), r.Text("unit"), r.Int("price_minor"),
        r.IntOrNull("trade_price_minor"), r.Int("cost_minor"), r.Text("tax_code"), r.Flag("track_stock"), r.Int("reorder_milli"), r.TextOrNull("station"),
        r.IntOrNull("duration_min") is { } d ? (int)d : null, ParseAttrs(r.Text("attrs")), r.Flag("active"));

    private static IReadOnlyDictionary<string, string> ParseAttrs(string json) =>
        JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();

    public Item Create(ItemInput input)
    {
        access.Require(Perm.Catalog);
        var id = db.InTransaction((c, t) => Create(c, t, input));
        return Get(id)!;
    }

    /// <summary>Adds an item inside the caller's transaction (so that a bigger action, such as moving a shop across from an older system, is all or nothing). Returns the new id.</summary>
    public long Create(SqliteConnection connection, SqliteTransaction transaction, ItemInput input)
    {
        var (taxCode, track) = Validate(input);
        try
        {
            return HubDb.Insert(connection,
                "INSERT INTO items(kind, sku, barcode, name, category, unit, price_minor, trade_price_minor, cost_minor, tax_code, track_stock, reorder_milli, station, duration_min, attrs, created_at) " +
                "VALUES ($kind, $sku, $barcode, $name, $category, $unit, $price, $trade, $cost, $tax, $track, $reorder, $station, $dur, $attrs, $at)", transaction,
                ("$kind", input.Kind), ("$sku", Blank(input.Sku)), ("$barcode", Blank(input.Barcode)), ("$name", input.Name.Trim()), ("$category", Blank(input.Category)),
                ("$unit", string.IsNullOrWhiteSpace(input.Unit) ? "pc" : input.Unit.Trim()), ("$price", input.PriceMinor), ("$trade", input.TradePriceMinor), ("$cost", input.CostMinor),
                ("$tax", taxCode), ("$track", track ? 1 : 0), ("$reorder", input.ReorderMilli), ("$station", Blank(input.Station)), ("$dur", input.DurationMin),
                ("$attrs", JsonSerializer.Serialize(input.Attrs)), ("$at", Iso.Text(clock.UtcNow)));
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
        {
            throw new HubException("duplicate-barcode", "That barcode is already on another item.");
        }
    }

    /// <summary>
    /// Whether an item of this kind keeps stock in this shop, by the same rule <see cref="Create(SqliteConnection, SqliteTransaction, ItemInput)"/> applies: the trade's setting decides
    /// ("never", "always", or "optional": the item's own choice, else the kind's default). Null when the kind is not one this business keeps.
    /// </summary>
    public bool? WouldTrackStock(string kindId, bool? requested)
    {
        var context = shop.Current;
        var kind = context.Industry.ItemKinds.FirstOrDefault(k => k.Id == kindId);
        if (kind is null) return null;
        return context.Features.StockTracking switch { "never" => false, "always" => kind.TracksStock, _ => requested ?? kind.TracksStock };
    }

    public Item Update(long id, ItemInput input)
    {
        access.Require(Perm.Catalog);
        var (taxCode, track) = Validate(input);
        try
        {
            var changed = db.InTransaction((c, t) => HubDb.Exec(c,
                "UPDATE items SET kind=$kind, sku=$sku, barcode=$barcode, name=$name, category=$category, unit=$unit, price_minor=$price, trade_price_minor=$trade, cost_minor=$cost, " +
                "tax_code=$tax, track_stock=$track, reorder_milli=$reorder, station=$station, duration_min=$dur, attrs=$attrs WHERE id=$id", t,
                ("$id", id), ("$kind", input.Kind), ("$sku", Blank(input.Sku)), ("$barcode", Blank(input.Barcode)), ("$name", input.Name.Trim()), ("$category", Blank(input.Category)),
                ("$unit", string.IsNullOrWhiteSpace(input.Unit) ? "pc" : input.Unit.Trim()), ("$price", input.PriceMinor), ("$trade", input.TradePriceMinor), ("$cost", input.CostMinor),
                ("$tax", taxCode), ("$track", track ? 1 : 0), ("$reorder", input.ReorderMilli), ("$station", Blank(input.Station)), ("$dur", input.DurationMin),
                ("$attrs", JsonSerializer.Serialize(input.Attrs))));
            if (changed == 0) throw new HubException("not-found", "That item was not found.");
            return Get(id)!;
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
        {
            throw new HubException("duplicate-barcode", "That barcode is already on another item.");
        }
    }

    public Item? Get(long id) => db.QueryOne($"SELECT {Columns} FROM items WHERE id = $id", Map, ("$id", id));

    /// <summary>The item with this barcode or SKU (what a scanner or a typed code gives).</summary>
    public Item? FindByCode(string code)
    {
        var trimmed = code.Trim();
        if (trimmed.Length == 0) return null;
        return db.QueryOne($"SELECT {Columns} FROM items WHERE active = 1 AND (barcode = $c OR sku = $c) ORDER BY barcode = $c DESC LIMIT 1", Map, ("$c", trimmed));
    }

    public IReadOnlyList<Item> Search(string? text = null, string? kind = null, string? category = null, int limit = 60, bool includeInactive = false)
    {
        var term = (text ?? "").Trim();
        var like = "%" + term.Replace("%", "\\%").Replace("_", "\\_") + "%";
        return db.Query(
            $"SELECT {Columns} FROM items WHERE ($all = 1 OR active = 1) AND ($kind IS NULL OR kind = $kind) AND ($cat IS NULL OR category = $cat) " +
            "AND ($t = '' OR name LIKE $like ESCAPE '\\' OR sku LIKE $like ESCAPE '\\' OR barcode LIKE $like ESCAPE '\\' OR category LIKE $like ESCAPE '\\') " +
            "ORDER BY category COLLATE NOCASE, name COLLATE NOCASE LIMIT $limit", Map,
            ("$all", includeInactive ? 1 : 0), ("$kind", kind), ("$cat", category), ("$t", term), ("$like", like), ("$limit", limit));
    }

    public IReadOnlyList<string> Categories(string? kind = null) =>
        db.Query("SELECT DISTINCT category FROM items WHERE active = 1 AND category IS NOT NULL AND ($kind IS NULL OR kind = $kind) ORDER BY category COLLATE NOCASE", r => r.Text("category"), ("$kind", kind));

    public void SetActive(long id, bool active)
    {
        access.Require(Perm.Catalog);
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE items SET active = $a WHERE id = $id", t, ("$a", active ? 1 : 0), ("$id", id)));
    }

    // ---- stock ---------------------------------------------------------------------------------------------------------------------

    public long OnHandMilli(long itemId) => Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves WHERE item_id = $i", ("$i", itemId)) ?? 0L);

    /// <summary>
    /// Changes the stock of an item: a count, damage, a delivery. The reason is kept with who did it. The change is valued (decision 36): stock taken off leaves at the average cost, stock found
    /// by a count joins at the average cost, and a delivery joins at the item's last cost price; the books take it in at once (a loss or a gain, or purchases for a delivery).
    /// </summary>
    public void Adjust(long itemId, long deltaMilli, string reason, string? note = null, long? userId = null)
    {
        access.Require(Perm.Stock);
        var item = Get(itemId) ?? throw new HubException("not-found", "That item was not found.");
        if (!item.TrackStock) throw new HubException("not-tracked", $"Stock is not tracked for {item.Name}.");
        if (deltaMilli == 0) return;
        db.InTransaction((c, t) =>
        {
            long value;
            if (deltaMilli < 0) value = -StockCost.TakeOut(c, t, itemId, -deltaMilli);
            else
            {
                var last = StockCost.LastCost(c, t, itemId);
                value = reason == "delivery" && last > 0 ? StockCost.Worth(deltaMilli, last) : StockCost.BringIn(c, t, itemId, deltaMilli);
            }
            var move = StockCost.Insert(c, t, itemId, deltaMilli, reason, null, note, clock.UtcNow, userId, value);
            books.SyncStockMove(c, t, move, userId);
        });
    }

    /// <summary>
    /// Stock of every tracked item, with what is on hand now and what it is worth. The cost shown is the average of what is on the shelf (the item's last cost price when nothing is, or when the
    /// shelf holds stock whose value is not known).
    /// </summary>
    public IReadOnlyList<StockRow> StockList(bool lowOnly = false)
    {
        var rows = db.Query(
            "SELECT i.id, i.name, i.category, i.unit, i.reorder_milli, i.cost_minor, COALESCE((SELECT SUM(qty_milli) FROM stock_moves m WHERE m.item_id = i.id), 0) AS on_hand, " +
            "COALESCE((SELECT SUM(value_minor) FROM stock_moves m WHERE m.item_id = i.id), 0) AS on_value " +
            "FROM items i WHERE i.track_stock = 1 AND i.active = 1 ORDER BY i.category COLLATE NOCASE, i.name COLLATE NOCASE",
            r =>
            {
                var onHand = r.Int("on_hand");
                var value = r.Int("on_value");
                var average = onHand > 0 && value > 0 ? StockCost.Share(value, 1000, onHand) : r.Int("cost_minor");
                return new StockRow(r.Int("id"), r.Text("name"), r.TextOrNull("category"), r.Text("unit"), onHand, r.Int("reorder_milli"), average, value);
            });
        return lowOnly ? rows.Where(x => x.OnHandMilli <= x.ReorderMilli).ToList() : rows;
    }

    // ---- rules ---------------------------------------------------------------------------------------------------------------------

    private (string TaxCode, bool Track) Validate(ItemInput input)
    {
        var context = shop.Current;
        if (string.IsNullOrWhiteSpace(input.Name)) throw new HubException("name-missing", "Please give a name.");
        if (input.Name.Length > 160) throw new HubException("name-long", "That name is too long.");
        var kind = context.Industry.ItemKinds.FirstOrDefault(k => k.Id == input.Kind)
            ?? throw new HubException("kind", $"\"{input.Kind}\" is not a kind of item this business keeps.");
        if (input.PriceMinor < 0 || input.CostMinor < 0 || input.TradePriceMinor < 0) throw new HubException("price", "A price cannot be negative.");
        if (input.DurationMin is < 0 or > 24 * 60) throw new HubException("duration", "A duration must be between 0 and 1440 minutes.");
        string taxCode;
        try { taxCode = context.TaxCode(input.TaxClass); }
        catch (ArgumentException ex) { throw new HubException("tax", ex.Message); }
        // "never": no item keeps stock. "always": the kinds that track stock do. "optional": the owner decides item by item, the kind is the default.
        var track = context.Features.StockTracking switch
        {
            "never" => false,
            "always" => kind.TracksStock,
            _ => input.TrackStock ?? kind.TracksStock,
        };
        return (taxCode, track);
    }

    private static string? Blank(string? text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();
}

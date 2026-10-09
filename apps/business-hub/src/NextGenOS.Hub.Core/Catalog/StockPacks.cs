using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Catalog;

/// <summary>
/// Selling loose from a pack: an item (a piece) can be linked to the item it comes out of (a box), with how many pieces one box holds. When a sale needs more pieces than are on the shelf, whole boxes are
/// opened first: the box stock goes down, the piece stock goes up by the pieces in them, and the boxes' value moves with them (so the cost of a piece is its box's average cost shared among the pieces and
/// nothing is lost to rounding: the pieces get exactly the value the boxes had). Both are ordinary stock moves with the reason "open-pack".
/// </summary>
internal static class StockPacks
{
    public static (long? PackItem, long PerPackMilli) Link(SqliteConnection c, SqliteTransaction? t, long itemId) =>
        HubDb.Query(c, "SELECT pack_item_id, per_pack_milli FROM items WHERE id = $i", r => (r.IsDBNull(0) ? (long?)null : r.GetInt64(0), r.IsDBNull(1) ? 0L : r.GetInt64(1)), t, ("$i", itemId)).FirstOrDefault();

    /// <summary>Checks a link before it is made. <paramref name="pieceId"/> is null for an item that is being made.</summary>
    public static void Validate(SqliteConnection c, SqliteTransaction t, long? pieceId, string pieceName, bool pieceKeepsStock, bool pieceKeepsBatches, long packItemId, long perPackMilli)
    {
        if (perPackMilli < 2_000 || perPackMilli % 1_000 != 0) throw new HubException("pack-size", "A pack must hold two or more whole pieces.");
        var pack = HubDb.Query(c, "SELECT name, track_stock, track_batches, pack_item_id FROM items WHERE id = $i", r => (Name: r.GetString(0), Stock: r.GetInt64(1) != 0, Batches: r.GetInt64(2) != 0, Linked: !r.IsDBNull(3)), t, ("$i", packItemId)).FirstOrDefault();
        if (pack == default) throw new HubException("pack-item", "The pack it is sold loose from was not found.");
        if (pieceId == packItemId) throw new HubException("pack-item", "An item cannot be sold loose from itself.");
        if (!pieceKeepsStock || !pack.Stock) throw new HubException("pack-stock", "Both the loose item and the pack must keep count of how many there are.");
        if (pieceKeepsBatches || pack.Batches) throw new HubException("pack-batches", "Items that keep batch numbers cannot be sold loose from a pack yet.");
        if (pack.Linked) throw new HubException("pack-chain", $"{pack.Name} is itself sold loose from another pack. A pack cannot be opened from a pack.");
        if (pieceId is { } id && HubDb.Scalar(c, "SELECT 1 FROM items WHERE pack_item_id = $i LIMIT 1", t, ("$i", id)) is not null)
            throw new HubException("pack-chain", $"Other items are sold loose from {pieceName}, so it cannot be sold loose from a pack itself.");
    }

    /// <summary>
    /// Opens the packs a sale of <paramref name="neededMilli"/> pieces needs, as many whole packs as it takes and the pack stock allows (never more packs than are on the shelf: the shop's rule about stock
    /// below nothing then decides what happens to the pieces). Returns the packs opened.
    /// </summary>
    public static long OpenFor(SqliteConnection c, SqliteTransaction t, long pieceId, long neededMilli, long? documentId, string? note, long? userId, DateTimeOffset at)
    {
        var (packItem, perPack) = Link(c, t, pieceId);
        if (packItem is not { } pack || perPack <= 0) return 0;
        var onHand = Math.Max(0, Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves WHERE item_id = $i", t, ("$i", pieceId)) ?? 0L));
        var shortage = neededMilli - onHand;
        if (shortage <= 0) return 0;
        var wanted = (shortage + perPack - 1) / perPack;
        var packsOnShelf = Math.Max(0, Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves WHERE item_id = $i", t, ("$i", pack)) ?? 0L)) / 1_000;
        return Open(c, t, pieceId, pack, perPack, Math.Min(wanted, packsOnShelf), documentId, note, userId, at);
    }

    /// <summary>Opens <paramref name="packs"/> whole packs: the packs leave at their average cost and the pieces arrive with exactly that value.</summary>
    public static long Open(SqliteConnection c, SqliteTransaction t, long pieceId, long packItem, long perPackMilli, long packs, long? documentId, string? note, long? userId, DateTimeOffset at)
    {
        if (packs <= 0) return 0;
        var value = StockCost.TakeOut(c, t, packItem, packs * 1_000);
        StockCost.Insert(c, t, packItem, -packs * 1_000, "open-pack", documentId, note, at, userId, -value);
        StockCost.Insert(c, t, pieceId, packs * perPackMilli, "open-pack", documentId, note, at, userId, value);
        return packs;
    }
}

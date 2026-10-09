using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Catalog;

/// <summary>A picture of an item: its number (the address of the picture is /item-images/number) and what kind of picture it is.</summary>
public sealed record ItemImage(long Id, long ItemId, string ContentType, int SortNo);

/// <summary>
/// Pictures of items (study 02 A2.10). A few small pictures for each item, the first shown on the till's tiles. The kind of picture is found from the file itself (PNG, JPEG, WebP or GIF), never from the
/// name or the type the browser claims; anything else (a vector picture or a page that can run code, a document, a program) is refused. Kept in the shop's database (see step 27).
/// </summary>
public sealed class ImageService(HubDb db, AuditService audit, IClock clock, CatalogService catalog, Access access)
{
    public const int MaxBytes = 400 * 1024;
    public const int MaxPerItem = 4;

    private static readonly string[] Viewers = [Perm.Sell, Perm.Orders, Perm.Catalog];

    /// <summary>What a file is, from its first bytes: "image/png", "image/jpeg", "image/webp" or "image/gif"; null for anything else.</summary>
    public static string? Sniff(ReadOnlySpan<byte> data)
    {
        if (data.Length >= 8 && data[0] == 0x89 && data[1] == 0x50 && data[2] == 0x4E && data[3] == 0x47 && data[4] == 0x0D && data[5] == 0x0A && data[6] == 0x1A && data[7] == 0x0A) return "image/png";
        if (data.Length >= 3 && data[0] == 0xFF && data[1] == 0xD8 && data[2] == 0xFF) return "image/jpeg";
        if (data.Length >= 12 && data[0] == (byte)'R' && data[1] == (byte)'I' && data[2] == (byte)'F' && data[3] == (byte)'F' && data[8] == (byte)'W' && data[9] == (byte)'E' && data[10] == (byte)'B' && data[11] == (byte)'P') return "image/webp";
        if (data.Length >= 6 && data[0] == (byte)'G' && data[1] == (byte)'I' && data[2] == (byte)'F' && data[3] == (byte)'8' && (data[4] == (byte)'7' || data[4] == (byte)'9') && data[5] == (byte)'a') return "image/gif";
        return null;
    }

    /// <summary>Adds a picture to an item. At most a few for each item; each at most 400 KB; a PNG, JPEG, WebP or GIF.</summary>
    public ItemImage Add(long itemId, byte[] data, long? userId = null)
    {
        access.Require(Perm.Catalog);
        var item = catalog.Get(itemId) ?? throw new HubException("not-found", "That item was not found.");
        if (data.Length == 0) throw new HubException("image-empty", "That file is empty.");
        if (data.Length > MaxBytes) throw new HubException("image-big", $"That picture is too big ({data.Length / 1024} KB). Please use one under {MaxBytes / 1024} KB; most phones and editing programs can make a smaller copy.");
        var type = Sniff(data) ?? throw new HubException("image-type", "That is not a picture the Hub can keep. Please use a PNG, JPEG, WebP or GIF picture.");
        return db.InTransaction((c, t) =>
        {
            var count = Convert.ToInt64(HubDb.Scalar(c, "SELECT COUNT(*) FROM item_images WHERE item_id = $i", t, ("$i", itemId)) ?? 0L);
            if (count >= MaxPerItem) throw new HubException("image-many", $"{item.Name} has {MaxPerItem} pictures already. Take one away first.");
            var next = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(sort_no), 0) + 1 FROM item_images WHERE item_id = $i", t, ("$i", itemId)) ?? 1L);
            var id = HubDb.Insert(c, "INSERT INTO item_images(item_id, content_type, data, sort_no, created_at) VALUES ($i, $c, $d, $s, $at)", t,
                ("$i", itemId), ("$c", type), ("$d", data), ("$s", next), ("$at", Iso.Text(clock.UtcNow)));
            audit.Log(c, t, userId, "image-add", "item", itemId, $"{type}, {data.Length / 1024} KB");
            return new ItemImage(id, itemId, type, (int)next);
        });
    }

    /// <summary>The pictures of an item, the first first.</summary>
    public IReadOnlyList<ItemImage> ForItem(long itemId)
    {
        access.RequireAny(Viewers);
        return db.Query("SELECT id, item_id, content_type, sort_no FROM item_images WHERE item_id = $i ORDER BY sort_no, id", r => new ItemImage(r.Int("id"), r.Int("item_id"), r.Text("content_type"), (int)r.Int("sort_no")), ("$i", itemId));
    }

    /// <summary>The first picture of each of these items (an item without one is left out): for the till's tiles.</summary>
    public IReadOnlyDictionary<long, long> FirstFor(IEnumerable<long> itemIds)
    {
        access.RequireAny(Viewers);
        var ids = itemIds.Distinct().ToList();
        if (ids.Count == 0) return new Dictionary<long, long>();
        var wanted = string.Join(",", ids.Select(i => i.ToString(System.Globalization.CultureInfo.InvariantCulture)));   // numbers only
        return db.Query($"SELECT item_id, MIN(id) AS id FROM item_images WHERE item_id IN ({wanted}) AND sort_no = (SELECT MIN(sort_no) FROM item_images x WHERE x.item_id = item_images.item_id) GROUP BY item_id",
            r => (Item: r.Int("item_id"), Image: r.Int("id"))).ToDictionary(x => x.Item, x => x.Image);
    }

    /// <summary>The picture itself, for the address /item-images/number.</summary>
    public (string ContentType, byte[] Data)? Get(long id)
    {
        access.RequireAny(Viewers);
        var rows = db.Query("SELECT content_type, data FROM item_images WHERE id = $id", r => (Type: r.GetString(0), Data: r.GetFieldValue<byte[]>(1)), ("$id", id));
        return rows.Count == 0 ? null : (rows[0].Type, rows[0].Data);
    }

    /// <summary>Takes a picture away.</summary>
    public void Remove(long id, long? userId = null)
    {
        access.Require(Perm.Catalog);
        db.InTransaction((c, t) =>
        {
            var item = HubDb.Query(c, "SELECT item_id FROM item_images WHERE id = $id", r => r.GetInt64(0), t, ("$id", id)).Cast<long?>().FirstOrDefault() ?? throw new HubException("not-found", "That picture was not found.");
            HubDb.Exec(c, "DELETE FROM item_images WHERE id = $id", t, ("$id", id));
            audit.Log(c, t, userId, "image-remove", "item", item, null);
        });
    }

    /// <summary>Makes a picture the first of its item (the one the till shows).</summary>
    public void MakeFirst(long id, long? userId = null)
    {
        access.Require(Perm.Catalog);
        db.InTransaction((c, t) =>
        {
            var item = HubDb.Query(c, "SELECT item_id FROM item_images WHERE id = $id", r => r.GetInt64(0), t, ("$id", id)).Cast<long?>().FirstOrDefault() ?? throw new HubException("not-found", "That picture was not found.");
            var first = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MIN(sort_no), 1) FROM item_images WHERE item_id = $i", t, ("$i", item)) ?? 1L);
            HubDb.Exec(c, "UPDATE item_images SET sort_no = $s WHERE id = $id", t, ("$s", first - 1), ("$id", id));
            audit.Log(c, t, userId, "image-first", "item", item, null);
        });
    }
}

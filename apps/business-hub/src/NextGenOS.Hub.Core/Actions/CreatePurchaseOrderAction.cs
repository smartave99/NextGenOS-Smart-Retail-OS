using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Purchasing;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Actions;

/// <summary>One line of a requested order.</summary>
public sealed record OrderLineInput(long ItemId, long QtyMilli, long CostMinor);

/// <summary>What <c>CreatePurchaseOrder</c> version 1 is asked with: the supplier, the lines (what, how many in thousandths, what one costs in minor units) and an optional note.</summary>
public sealed record CreatePurchaseOrderInput(long SupplierId, IReadOnlyList<OrderLineInput> Lines, string? Notes = null);

/// <summary>
/// <c>CreatePurchaseOrder</c>, version 1 (blueprint ACT-013): a draft order to a supplier, asked for by anyone who works with stock and approved by someone who may buy. It checks that the
/// supplier is a supplier and the goods are goods that can be bought, refuses an order that repeats one that is still open, says in plain words what it would do, and, only after approval,
/// makes the draft that the Buying page already knows (<see cref="PurchaseService.CreateOrder"/>): it is received, paid for and cancelled like any other order. It never receives goods or
/// pays anyone.
/// </summary>
public sealed class CreatePurchaseOrderAction(HubDb db, PartyService parties, CatalogService catalog, PurchaseService purchasing, ShopContextProvider shop) : IActionHandler
{
    public const int MaxLines = 50;
    public const long MaxQtyMilli = 1_000_000_000;      // a million units
    public const long MaxCostMinor = 1_000_000_000_000;
    /// <summary>An approval no longer holds if the cost price of any item moved by more than this share since the request was made.</summary>
    public const int CostMovePercent = 10;
    /// <summary>An order is a repeat if an open one to the same supplier for the same goods was made within this many days.</summary>
    public const int RepeatDays = 3;

    private static readonly JsonSerializerOptions Strict = new(JsonSerializerDefaults.Web) { UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow };

    public string Id => "CreatePurchaseOrder";
    public int Version => 1;
    public string Title => "Draft an order to a supplier";
    public IReadOnlyList<string> ProposeAny { get; } = [Perm.Sell, Perm.Orders, Perm.Catalog, Perm.Stock, Perm.Purchases];
    public IReadOnlyList<string> ApproveAny { get; } = [Perm.Purchases];
    public bool AllowSelfApproval => true;
    public TimeSpan ExpiresAfter => TimeSpan.FromHours(48);

    public Prepared Prepare(string inputJson, ActionContext context)
    {
        CreatePurchaseOrderInput? input;
        try { input = JsonSerializer.Deserialize<CreatePurchaseOrderInput>(inputJson, Strict); }
        catch (JsonException) { input = null; }
        if (input is null || input.Lines is null) return Fail("The request is not in the form this action expects (a supplier and the lines of the order).");

        var problems = new List<string>();
        var supplier = parties.Get(input.SupplierId);
        if (supplier is null) problems.Add("That supplier was not found.");
        else if (supplier.Kind != "supplier") problems.Add(supplier.Name + " is not a supplier.");
        else if (!supplier.Active) problems.Add(supplier.Name + " is not in use any more.");
        if (input.Lines.Count == 0) problems.Add("Add what is being ordered.");
        if (input.Lines.Count > MaxLines) problems.Add("An order has at most " + MaxLines + " lines.");
        if (input.Notes is { Length: > 300 }) problems.Add("The note is too long (at most 300 letters).");
        if (input.Lines.GroupBy(l => l.ItemId).Any(g => g.Count() > 1)) problems.Add("Each item can be on the order only once.");

        var shown = new List<string>();
        var bound = new List<object>();
        long total = 0;
        foreach (var line in input.Lines.Take(MaxLines))
        {
            var item = catalog.Get(line.ItemId);
            if (item is null) { problems.Add("Item " + line.ItemId + " was not found."); continue; }
            if (!item.Active) problems.Add(item.Name + " is not in use any more.");
            if (item.Kind is "service" or "title") problems.Add(item.Name + " is not goods that can be bought in.");
            if (line.QtyMilli <= 0 || line.QtyMilli > MaxQtyMilli) problems.Add("How many of " + item.Name + " must be more than nothing.");
            if (line.CostMinor < 0 || line.CostMinor > MaxCostMinor) problems.Add("What " + item.Name + " costs must not be below nothing.");
            total += (long)((System.Numerics.BigInteger)Math.Max(0, line.CostMinor) * Math.Max(0, line.QtyMilli) / 1000);
            shown.Add(ShopContext.Qty(line.QtyMilli).TrimEnd('0').TrimEnd('.') + (string.IsNullOrWhiteSpace(item.Unit) ? "" : " " + item.Unit) + " of " + item.Name);
            bound.Add(new { itemId = item.Id, qtyMilli = line.QtyMilli, costMinor = line.CostMinor, itemCostNow = item.CostMinor });
        }

        if (supplier is { Kind: "supplier" })
            foreach (var repeat in OpenOrdersFor(supplier.Id, input.Lines.Select(l => l.ItemId).ToList(), context.Now))
                problems.Add("There is already an open order to " + supplier.Name + " (number " + repeat + ") for some of the same goods. Receive it or take it off first.");

        var summary = problems.Count > 0 ? "Not ready: " + problems[0] :
            "Draft an order to " + supplier!.Name + " for " + string.Join(", ", shown) + ", " + shop.Current.Money(total) + " in all. Nothing is bought or paid until the goods arrive and you press “Goods arrived”.";
        var boundJson = JsonSerializer.Serialize(new { supplierId = input.SupplierId, lines = bound }, Strict);
        return new Prepared(input, summary, problems, boundJson);
    }

    private static Prepared Fail(string why) => new(null, "Not ready: " + why, [why], "{}");

    /// <summary>The open (not yet received) orders to this supplier, made lately, that have any of these goods on them.</summary>
    private List<long> OpenOrdersFor(long supplierId, IReadOnlyList<long> itemIds, DateTimeOffset now)
    {
        if (itemIds.Count == 0) return [];
        var since = Iso.Text(now.AddDays(-RepeatDays));
        var list = string.Join(",", itemIds.Select(i => i.ToString(System.Globalization.CultureInfo.InvariantCulture)));
        return db.Query(
            "SELECT DISTINCT d.id FROM documents d JOIN document_lines l ON l.document_id = d.id WHERE d.type = 'purchase' AND d.status = 'open' AND d.party_id = $p AND d.created_at >= $since AND l.item_id IN (" + list + ") ORDER BY d.id",
            r => r.Int("id"), ("$p", supplierId), ("$since", since));
    }

    public string? Changed(string boundThen, Prepared now)
    {
        try
        {
            using var then = JsonDocument.Parse(boundThen);
            using var current = JsonDocument.Parse(now.BoundJson);
            if (then.RootElement.GetProperty("supplierId").GetInt64() != current.RootElement.GetProperty("supplierId").GetInt64()) return "The supplier is not the same any more.";
            var before = then.RootElement.GetProperty("lines").EnumerateArray().ToDictionary(l => l.GetProperty("itemId").GetInt64(), l => l.GetProperty("itemCostNow").GetInt64());
            foreach (var l in current.RootElement.GetProperty("lines").EnumerateArray())
            {
                var item = l.GetProperty("itemId").GetInt64();
                var cost = l.GetProperty("itemCostNow").GetInt64();
                if (!before.TryGetValue(item, out var was)) return "The goods are not the same any more.";
                // A cost that moved by more than the allowed share (either way) since the request was made: ask again on the new figures.
                if (was == 0 ? cost != 0 : (long)Math.Abs(cost - was) * 100 > (long)was * CostMovePercent) return "The cost price of " + (catalog.Get(item)?.Name ?? "an item") + " has changed by more than " + CostMovePercent + "% since this was asked for.";
            }
        }
        catch (Exception e) when (e is JsonException or KeyNotFoundException or InvalidOperationException) { return "The request cannot be read any more."; }

        return null;
    }

    public string Execute(Prepared prepared, ActionContext context)
    {
        var input = (CreatePurchaseOrderInput)prepared.Input!;
        var notes = string.IsNullOrWhiteSpace(input.Notes) ? "Asked for as a suggested order and approved." : input.Notes.Trim() + " (asked for as a suggested order and approved)";
        var draft = purchasing.CreateOrder(input.SupplierId, input.Lines.Select(l => new PurchaseLine { ItemId = l.ItemId, QtyMilli = l.QtyMilli, CostMinor = l.CostMinor }).ToList(), notes, context.ActorId);
        return JsonSerializer.Serialize(new { documentId = draft.Document.Id });
    }

    /// <summary>A fingerprint of the facts an approval rests on, so two requests can be compared.</summary>
    public static string Fingerprint(string boundJson) => Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(boundJson)));
}

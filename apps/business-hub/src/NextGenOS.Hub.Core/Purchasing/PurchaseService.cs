using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Purchasing;

public sealed class PurchaseLine
{
    public long ItemId { get; set; }
    public long QtyMilli { get; set; }
    /// <summary>What one costs, in minor units.</summary>
    public long CostMinor { get; set; }
    /// <summary>For an item that keeps batches: the batch that arrives with this line, and its dates (they can also be given when the goods are received).</summary>
    public string? BatchNo { get; set; }
    public DateOnly? MfgOn { get; set; }
    public DateOnly? ExpOn { get; set; }
}

/// <summary>What a delivery says about the batch of one line of an order, when the goods arrive.</summary>
public sealed record ReceivedBatch(string? BatchNo, DateOnly? MfgOn, DateOnly? ExpOn);

/// <summary>Buying from suppliers: a purchase order, receiving the goods into stock, and paying the supplier.</summary>
public sealed class PurchaseService(DocumentService documents, CatalogService catalog, PartyService parties, Access access)
{
    public DocumentView CreateOrder(long supplierId, IEnumerable<PurchaseLine> lines, string? notes = null, long? userId = null)
    {
        access.Require(Perm.Purchases);
        var supplier = parties.Get(supplierId) ?? throw new HubException("party-not-found", "That supplier was not found.");
        if (supplier.Kind != "supplier") throw new HubException("not-supplier", $"{supplier.Name} is not a supplier.");
        var list = lines.ToList();
        if (list.Count == 0) throw new HubException("empty", "Add what is being ordered.");
        return documents.CreateDraft(new DraftOptions
        {
            Type = DocTypes.Purchase, Direction = "in", PartyId = supplierId, UserId = userId, Notes = notes,
            Lines = list.Select(l => new LineInput { ItemId = l.ItemId, QtyMilli = l.QtyMilli, UnitPriceMinor = l.CostMinor, BatchNo = l.BatchNo, MfgOn = l.MfgOn, ExpOn = l.ExpOn }).ToList(),
        });
    }

    /// <summary>The goods arrived: the order becomes final, stock goes up, and the cost price of each item is updated.</summary>
    public DocumentView Receive(long orderId, long? userId = null, IReadOnlyDictionary<long, ReceivedBatch>? batches = null)
    {
        access.Require(Perm.Purchases);
        var order = documents.Get(orderId) ?? throw new HubException("not-found", "That order was not found.");
        if (order.Document.Type != DocTypes.Purchase) throw new HubException("not-purchase", "That is not a purchase order.");
        if (batches is not null)
            foreach (var (lineId, batch) in batches) documents.SetLineBatch(orderId, lineId, batch.BatchNo, batch.MfgOn, batch.ExpOn);
        var view = documents.Issue(orderId, new IssueOptions { UserId = userId });
        foreach (var line in view.Lines.Where(l => l.ItemId is not null))
        {
            var item = catalog.Get(line.ItemId!.Value);
            if (item is null || line.UnitPriceMinor <= 0) continue;
            using var costUpdate = access.AsSystem();   // the new cost is part of the receive the person was allowed to do, not a catalogue edit of theirs
            catalog.Update(item.Id, new ItemInput
            {
                Kind = item.Kind, Sku = item.Sku, Barcode = item.Barcode, Name = item.Name, Category = item.Category, Unit = item.Unit, PriceMinor = item.PriceMinor, TradePriceMinor = item.TradePriceMinor,
                CostMinor = line.UnitPriceMinor, TaxClass = item.TaxCode, TrackStock = item.TrackStock, ReorderMilli = item.ReorderMilli, Station = item.Station, DurationMin = item.DurationMin,
                Attrs = item.Attrs.ToDictionary(k => k.Key, k => k.Value),
            });
        }
        return view;
    }

    /// <summary>A payment to the supplier for a received order.</summary>
    public DocumentView Pay(long orderId, long amountMinor, string method, string? reference = null, long? userId = null)
    {
        access.Require(Perm.Purchases);
        return documents.AddPayment(orderId, new PaymentInput { Method = method, AmountMinor = amountMinor, Reference = reference }, userId);
    }

    /// <summary>What is owed to suppliers: received orders not yet fully paid.</summary>
    public IReadOnlyList<Document> Payable() =>
        documents.List(new DocumentFilter { Type = DocTypes.Purchase, Status = DocStatus.Issued, OnlyUnpaid = true, Limit = 500 });
}

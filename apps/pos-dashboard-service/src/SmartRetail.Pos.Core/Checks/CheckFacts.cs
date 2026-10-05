namespace SmartRetail.Pos.Core.Checks;

/// <summary>A price as the till charges it: one stock batch (POS table <c>Temp_Stock</c>), or the product itself
/// when it has no batch.</summary>
public sealed record PriceFacts
{
    public int ProductId { get; init; }
    public string Name { get; init; } = "";

    /// <summary>The code the till scans for this batch.</summary>
    public string Code { get; init; } = "";

    /// <summary>What the customer pays, GST included.</summary>
    public decimal Price { get; init; }
    public decimal Mrp { get; init; }

    /// <summary>Purchase price before GST; 0 when the POS has none.</summary>
    public decimal Cost { get; init; }
    public decimal GstPercent { get; init; }
    public decimal Qty { get; init; }
}

/// <summary>One item on a recent bill (POS table <c>Invoice_Product</c>).</summary>
public sealed record SoldLine
{
    public long BillId { get; init; }
    public string BillNumber { get; init; } = "";
    public DateTime Date { get; init; }
    public int ProductId { get; init; }
    public string Name { get; init; } = "";
    public decimal Qty { get; init; }

    /// <summary>The rate billed per unit, GST included.</summary>
    public decimal Rate { get; init; }
    public decimal Mrp { get; init; }

    /// <summary>Rupees taken off the line.</summary>
    public decimal Discount { get; init; }

    /// <summary>What the line came to, GST included.</summary>
    public decimal Amount { get; init; }

    /// <summary>What the line came to before GST.</summary>
    public decimal Taxable { get; init; }

    /// <summary>Purchase price per unit before GST, as the POS saved it on the bill; 0 when unknown.</summary>
    public decimal PurchaseRate { get; init; }

    /// <summary>The discount on the whole bill (POS: InvoiceInfo's BillDiscount and OfferAmt), the same on each of
    /// its lines. <see cref="Amount"/> and <see cref="Taxable"/> are before it; the checks share it out over the
    /// bill's lines by their value.</summary>
    public decimal BillDiscount { get; init; }
}

/// <summary>A bill's id, number and date, to find bills missing from the POS's numbering.</summary>
public sealed record BillStub(long Id, string Number, DateTime Date);

/// <summary>Bills given on credit a while ago and still not paid.</summary>
public sealed record OwedBills(int Bills, decimal Owed, DateOnly Before, DateOnly? Oldest = null);

/// <summary>Everything the checks look at, read from the POS just before.</summary>
public sealed record CheckFacts
{
    public DateOnly Today { get; init; }
    public IReadOnlyList<PriceFacts> Prices { get; init; } = Array.Empty<PriceFacts>();

    /// <summary>This week's bill lines.</summary>
    public IReadOnlyList<SoldLine> RecentLines { get; init; } = Array.Empty<SoldLine>();

    /// <summary>The last 30 days' bills, for gaps in their numbering.</summary>
    public IReadOnlyList<BillStub> RecentBills { get; init; } = Array.Empty<BillStub>();
    public OwedBills? OwedLong { get; init; }
}

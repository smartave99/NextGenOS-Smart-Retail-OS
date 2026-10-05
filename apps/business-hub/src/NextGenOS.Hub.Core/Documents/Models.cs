using NextGenOS.Hub.Catalog;
using NextGenOS.Tax;

namespace NextGenOS.Hub.Documents;

public static class DocTypes
{
    public const string Invoice = "invoice";
    public const string Quote = "quote";
    public const string Order = "order";
    public const string CreditNote = "credit-note";
    public const string Purchase = "purchase";
    public const string ProgressBill = "progress-bill";
}

public static class DocStatus
{
    public const string Open = "open";
    public const string Issued = "issued";
    public const string Void = "void";
}

public sealed record Document(
    long Id, string Type, string? Number, string Status, string Direction, long? PartyId, DateTimeOffset? IssuedAt, DateTimeOffset CreatedAt, DateTimeOffset? DueAt,
    int CurrencyDecimals, bool PricesIncludeTax, string? SellerRegion, string? BuyerRegion, bool RoundTotal, bool Registered,
    long SubtotalMinor, long TaxMinor, long TotalMinor, long PayableMinor, long PaidMinor, long TipsMinor, long RetentionMinor, long AdvanceMinor,
    long? TableId, long? ProjectId, long? RefDocumentId, long? UserId, string? Notes, IReadOnlyDictionary<string, string> Meta)
{
    public long BalanceMinor => Status == DocStatus.Issued ? Math.Max(0, PayableMinor - PaidMinor) : 0;

    /// <summary>"unpaid", "partial" or "paid" for an issued document.</summary>
    public string PaymentState => Status != DocStatus.Issued ? "" : PaidMinor >= PayableMinor ? "paid" : PaidMinor > 0 ? "partial" : "unpaid";
}

public sealed record DocLine(
    long Id, int LineNo, long? ItemId, string Description, long QtyMilli, string? Unit, long UnitPriceMinor, long DiscountPctMilli, string TaxCode,
    string? CustomerDiscount, bool Fired, string? Note, string? Station, long? BoqId);

public sealed class LineInput
{
    /// <summary>When set, the description, unit, tax code and price come from the item (the price from the customer's price level).</summary>
    public long? ItemId { get; set; }
    public string? Description { get; set; }
    public long QtyMilli { get; set; } = 1000;
    public string? Unit { get; set; }
    public long? UnitPriceMinor { get; set; }
    public long DiscountPctMilli { get; set; }
    public string? TaxCode { get; set; }
    public string? CustomerDiscount { get; set; }
    public string? Note { get; set; }
    public string? Station { get; set; }
    public long? BoqId { get; set; }
}

public sealed record PaymentRow(long Id, long? DocumentId, string Method, long AmountMinor, string? Reference, DateTimeOffset At, string Kind, long? UserId);

public sealed class PaymentInput
{
    public string Method { get; set; } = "cash";
    public long AmountMinor { get; set; }
    public string? Reference { get; set; }
}

/// <summary>A document with everything needed to show or print it.</summary>
public sealed record DocumentView(Document Document, Party? Party, IReadOnlyList<DocLine> Lines, IReadOnlyList<TaxAdjustmentInput> Adjustments, TaxResult? Result, IReadOnlyList<PaymentRow> Payments);

public sealed class DraftOptions
{
    public string Type { get; set; } = DocTypes.Invoice;
    public long? PartyId { get; set; }
    public long? TableId { get; set; }
    public long? ProjectId { get; set; }
    public long? RefDocumentId { get; set; }
    public long? UserId { get; set; }
    public string? Notes { get; set; }
    public string Direction { get; set; } = "out";
    public bool? PricesIncludeTax { get; set; }
    public List<LineInput> Lines { get; set; } = new();
    public List<TaxAdjustmentInput> Adjustments { get; set; } = new();
    public Dictionary<string, string> Meta { get; set; } = new();
}

public sealed class IssueOptions
{
    public List<PaymentInput> Payments { get; set; } = new();
    public long? UserId { get; set; }
    /// <summary>Allow part or none of the bill to stay unpaid (credit). The customer must have a credit limit.</summary>
    public bool OnCredit { get; set; }
}

public sealed class CheckoutRequest
{
    public long? PartyId { get; set; }
    public List<LineInput> Lines { get; set; } = new();
    public List<TaxAdjustmentInput> Adjustments { get; set; } = new();
    public List<PaymentInput> Payments { get; set; } = new();
    public long? UserId { get; set; }
    public bool OnCredit { get; set; }
    public string? Notes { get; set; }
    public string Type { get; set; } = DocTypes.Invoice;
}

public sealed class DocumentFilter
{
    public string? Type { get; set; }
    public string? Status { get; set; }
    public long? PartyId { get; set; }
    public long? ProjectId { get; set; }
    public DateTimeOffset? From { get; set; }
    public DateTimeOffset? To { get; set; }
    public string? Text { get; set; }
    public bool OnlyUnpaid { get; set; }
    public int Limit { get; set; } = 100;
}

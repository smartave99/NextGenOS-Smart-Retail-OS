using SmartRetail.Pos.Core.Billing;

namespace SmartRetail.Pos.Core.Abstractions;

/// <summary>A finished bill, ready to be saved.</summary>
public sealed record NewInvoice
{
    /// <summary>Null for a walk-in customer.</summary>
    public int? CustomerId { get; init; }
    public string CustomerName { get; init; } = "";
    public BillOptions Options { get; init; } = BillOptions.Default;
    public string PaymentMode { get; init; } = PaymentModes.Cash;

    /// <summary>What the customer handed over.</summary>
    public decimal AmountReceived { get; init; }
    public DateTime CreatedAtLocal { get; init; }
    public IReadOnlyList<NewInvoiceLine> Lines { get; init; } = Array.Empty<NewInvoiceLine>();
    public BillTotals Totals { get; init; } = BillTotals.Empty;

    /// <summary>The part of the bill settled now; never more than the bill.</summary>
    public decimal Paid => Math.Min(AmountReceived, Totals.GrandTotal);

    /// <summary>Still owed by the customer.</summary>
    public decimal Balance => Totals.GrandTotal - Paid;

    /// <summary>Cash to hand back.</summary>
    public decimal ChangeDue => Math.Max(0m, AmountReceived - Totals.GrandTotal);
}

/// <summary>One line of a finished bill, with its money already worked out.</summary>
public sealed record NewInvoiceLine
{
    public int ProductId { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public string? HsnCode { get; init; }
    public decimal Qty { get; init; }
    public decimal Rate { get; init; }
    public decimal DiscountPercent { get; init; }
    public decimal GstRatePercent { get; init; }
    public decimal Discount { get; init; }
    public decimal Taxable { get; init; }
    public decimal Tax { get; init; }
    public decimal LineTotal { get; init; }
}

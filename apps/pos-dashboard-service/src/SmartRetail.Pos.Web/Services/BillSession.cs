using Microsoft.Extensions.Options;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Billing;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The counter's bill in progress. One per browser window (Blazor circuit), so a half-built bill
/// survives switching to another screen and back.
/// </summary>
public sealed class BillSession
{
    private readonly BillOptions _defaults;

    public BillSession(IOptions<ShopOptions> shop)
    {
        _defaults = shop.Value.ToBillOptions();
        Bill = new Bill { Options = _defaults };
    }

    public Bill Bill { get; private set; }
    public string PaymentMode { get; set; } = PaymentModes.Cash;

    /// <summary>What the customer handed over; null means the exact bill amount.</summary>
    public decimal? AmountReceived { get; set; }

    public NewInvoice? LastInvoice { get; private set; }
    public SavedInvoice? LastSaved { get; private set; }

    public void MarkSaved(NewInvoice invoice, SavedInvoice saved)
    {
        LastInvoice = invoice;
        LastSaved = saved;
    }

    public void StartNew()
    {
        Bill = new Bill { Options = _defaults };
        PaymentMode = PaymentModes.Cash;
        AmountReceived = null;
        LastInvoice = null;
        LastSaved = null;
    }
}

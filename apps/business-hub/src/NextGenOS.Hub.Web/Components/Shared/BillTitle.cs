using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web.Components.Shared;

/// <summary>What a bill is called at the top of the receipt and of the full-page invoice: the country's own name for a tax invoice when the shop is registered for the tax.</summary>
public static class BillTitle
{
    public static string For(Document document, ShopContext shop) => document.Type switch
    {
        DocTypes.CreditNote => "Credit note",
        DocTypes.DebitNote => "Debit note",
        DocTypes.Quote => "Quote",
        DocTypes.Purchase => "Purchase order",
        DocTypes.ProgressBill => "Progress bill",
        DocTypes.Order => "Order",
        _ => shop.Settings.TaxRegistered && !string.IsNullOrWhiteSpace(shop.Country.Invoice?.Title) ? shop.Country.Invoice.Title : "Bill",
    };
}

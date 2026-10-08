using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Estimates for a shop sale (decision 35): a quote is worked out exactly like a bill, with the same tax and discounts, so the bill made from it comes to the same. The older POS's estimate
/// showed no tax, so its estimate of 180.00 became a bill of 212.40; here the quote shows 212.40.
/// </summary>
public class EstimateTests
{
    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static DocumentView Draft(HubFixture f, long? party = null, long billDiscount = 0) => f.App.Documents.CreateDraft(new DraftOptions
    {
        PartyId = party, BillDiscountMinor = billDiscount,
        Lines = { new LineInput { Description = "Shirt", UnitPriceMinor = 9_000, QtyMilli = 2_000, TaxCode = "GST18" } },   // 180.00 + 18% = 212.40
    });

    [Fact]
    public void A_quote_shows_the_tax_and_the_bill_made_from_it_comes_to_the_same()
    {
        using var f = Shop();
        var asha = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" });
        var item = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Lamp", PriceMinor = 5_000, TaxClass = "standard", TrackStock = true });
        f.App.Catalog.Adjust(item.Id, 10_000, "delivery");
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { Description = "Shirt", UnitPriceMinor = 9_000, QtyMilli = 2_000, TaxCode = "GST18" }, new LineInput { ItemId = item.Id, QtyMilli = 1_000 } } });
        var quote = f.App.Documents.SaveAsEstimate(draft.Document.Id);
        Assert.Equal(DocTypes.Quote, quote.Document.Type);
        Assert.Equal(DocStatus.Issued, quote.Document.Status);
        Assert.StartsWith("QUO-", quote.Document.Number);
        Assert.Equal(21_240 + 5_900, quote.Document.PayableMinor);                    // the tax is in it: 212.40 + 59.00
        Assert.Equal(10_000, f.App.Catalog.OnHandMilli(item.Id));                     // nothing was sold
        Assert.Empty(quote.Payments);
        Assert.Empty(f.App.Db.Query("SELECT id FROM journal_entries", r => r.GetInt64(0)));   // nothing in the books
        // the bill
        var bill = f.App.Documents.BillFromEstimate(quote.Document.Id);
        Assert.Equal(quote.Document.PayableMinor, bill.Document.PayableMinor);
        Assert.Equal(asha.Id, bill.Document.PartyId);
        Assert.Equal(quote.Document.Id, bill.Document.RefDocumentId);
        var done = f.App.Documents.Issue(bill.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = bill.Document.PayableMinor } } });
        Assert.Equal(DocTypes.Invoice, done.Document.Type);
        Assert.Equal(9_000, f.App.Catalog.OnHandMilli(item.Id));                      // now it is sold
        Assert.Equal(done.Document.Number, f.App.Documents.Get(quote.Document.Id)!.Document.Meta["billedAs"]);
        // a quote is made into a bill once
        Assert.Equal("billed", Assert.Throws<HubException>(() => f.App.Documents.BillFromEstimate(quote.Document.Id)).Code);
    }

    [Fact]
    public void Discounts_come_across_to_the_bill_and_a_bill_started_from_a_quote_can_be_thrown_away()
    {
        using var f = Shop();
        var draft = Draft(f, billDiscount: 5_000);
        var quote = f.App.Documents.SaveAsEstimate(draft.Document.Id);
        Assert.Equal((18_000 - 5_000) * 118 / 100, quote.Document.PayableMinor);      // 130.00 + 18% = 153.40
        var bill = f.App.Documents.BillFromEstimate(quote.Document.Id);
        Assert.Equal(quote.Document.PayableMinor, bill.Document.PayableMinor);
        Assert.Equal(5_000, bill.Document.BillDiscountMinor);
        f.App.Documents.Discard(bill.Document.Id);                                    // the customer changed their mind: the quote is still there, not billed
        Assert.False(f.App.Documents.Get(quote.Document.Id)!.Document.Meta.ContainsKey("billedAs"));
        Assert.NotNull(f.App.Documents.BillFromEstimate(quote.Document.Id));
    }

    [Fact]
    public void Only_a_sale_with_something_on_it_that_is_still_being_made_can_be_kept_as_a_quote()
    {
        using var f = Shop();
        var empty = f.App.Documents.CreateDraft(new DraftOptions());
        Assert.Equal("empty", Assert.Throws<HubException>(() => f.App.Documents.SaveAsEstimate(empty.Document.Id)).Code);
        var sale = f.App.Documents.Issue(Draft(f).Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = 21_240 } } });
        Assert.Equal("not-draft", Assert.Throws<HubException>(() => f.App.Documents.SaveAsEstimate(sale.Document.Id)).Code);
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Documents.SaveAsEstimate(999_999)).Code);
        // a bill cannot be made from something that is not a finished quote
        Assert.Equal("not-quote", Assert.Throws<HubException>(() => f.App.Documents.BillFromEstimate(sale.Document.Id)).Code);
        var open = Draft(f);
        Assert.Equal("not-quote", Assert.Throws<HubException>(() => f.App.Documents.BillFromEstimate(open.Document.Id)).Code);
    }
}

using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;
using NextGenOS.Hub.Reports;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Goods sent back to a supplier (the older POS's "purchase return", merge wave 2; rules and worked examples in docs/old-programs/01 section 5.7, examples U13 and U14, and 02). India, rupees, tax
/// not in the prices; money in minor units (100.00 is 10,000), quantities in thousandths. The purchase of U2 is 12 units at 33.33 with 5% off and 9% + 9% tax: 399.96 less 20.00 is 379.96 before tax,
/// tax 34.20 + 34.20, total 448.36. Sending 1 unit back (U13): 33.33 less 1.67 is 31.66, tax 2.85 + 2.85, total 37.36.
/// </summary>
public class PurchaseReturnTests
{
    private static HubFixture Shop(bool allowNegative = true) => new("IN", "wholesale", s => { s.PricesIncludeTax = false; s.AllowNegativeStock = allowNegative; });

    private static Party Supplier(HubFixture f) => f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods", Region = "27" });

    private static Item Goods(HubFixture f, string name = "Rice") => f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = 5_000, TaxClass = "standard", TrackStock = true });

    /// <summary>Receives a purchase of the U2 lines (12 at 33.33, 5% off), optionally paying some of it.</summary>
    private static DocumentView BuyU2(HubFixture f, Party supplier, Item item, long paid = 0)
    {
        var draft = f.App.Documents.CreateDraft(new DraftOptions
        {
            Type = DocTypes.Purchase, Direction = "in", PartyId = supplier.Id,
            Lines = { new LineInput { ItemId = item.Id, QtyMilli = 12_000, UnitPriceMinor = 3_333, DiscountPctMilli = 5_000 } },
        });
        var received = f.App.Purchasing.Receive(draft.Document.Id);
        if (paid > 0) received = f.App.Purchasing.Pay(received.Document.Id, paid, "cash");
        return received;
    }

    private static long Balance(HubFixture f, string name) => f.App.Books.TrialBalance().SingleOrDefault(r => r.Name == name)?.BalanceMinor ?? 0;   // an account nothing was ever posted to does not exist yet

    private static void AssertBooksAgree(HubFixture f)
    {
        var rows = f.App.Books.TrialBalance();
        Assert.Equal(rows.Sum(r => r.DebitMinor), rows.Sum(r => r.CreditMinor));
        Assert.DoesNotContain(rows, r => r.Name == "Needs checking");
        Assert.Empty(f.App.Db.Query("SELECT entry_id FROM journal_lines GROUP BY entry_id HAVING SUM(debit_minor) <> SUM(credit_minor)", r => r.GetInt64(0)));
        Assert.Equal(Convert.ToInt64(f.App.Db.Scalar("SELECT COALESCE(SUM(value_minor), 0) FROM stock_moves")), Balance(f, "Stock on the shelves"));   // the shelf in the books is the stock the moves hold
    }

    [Fact]
    public void The_purchase_of_the_worked_example_comes_to_448_36()
    {
        using var f = Shop();
        var bought = BuyU2(f, Supplier(f), Goods(f));
        Assert.Equal(44_836, bought.Document.TotalMinor);
        Assert.Equal(37_996, bought.Document.SubtotalMinor);
        Assert.Equal(37_996, Balance(f, "Stock on the shelves"));
        Assert.Equal(3_420, Balance(f, "CGST paid on purchases"));
        Assert.Equal(-44_836, Balance(f, "We owe suppliers"));
    }

    [Fact]
    public void Sending_one_unit_back_on_credit_comes_to_37_36_takes_the_tax_back_and_lowers_what_is_owed()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        var purchase = BuyU2(f, supplier, rice);

        var note = f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "damaged in the van", null, null);

        Assert.Equal(DocTypes.DebitNote, note.Document.Type);
        Assert.Equal("DN-2026-000001", note.Document.Number);
        Assert.Equal(DocStatus.Issued, note.Document.Status);
        Assert.Equal("in", note.Document.Direction);
        Assert.Equal(purchase.Document.Id, note.Document.RefDocumentId);
        Assert.Equal(supplier.Id, note.Document.PartyId);
        Assert.Equal(3_166, note.Document.SubtotalMinor);                 // 33.33 - 1.67
        Assert.Equal(3_736, note.Document.TotalMinor);                    // 31.66 + 2.85 + 2.85 = 37.36 (U13)
        Assert.Equal(11_000, f.App.Catalog.OnHandMilli(rice.Id));         // 12 - 1

        // The stock leaves at what those lines cost without tax; the tax paid on them is taken back; the purchase is undone to the same amount.
        Assert.Equal(37_996 - 3_166, Balance(f, "Stock on the shelves"));
        Assert.Equal(3_420 - 285, Balance(f, "CGST paid on purchases"));
        Assert.Equal(3_420 - 285, Balance(f, "SGST paid on purchases"));
        Assert.Equal(0, Balance(f, "Purchases"));
        Assert.Equal(-(44_836 - 3_736), Balance(f, "We owe suppliers"));  // we owe 411.00 now
        Assert.Equal(44_836 - 3_736, f.App.Books.SupplierBalance(supplier.Id));
        AssertBooksAgree(f);

        // The credit counts as paid on the purchase it came from (nothing was paid before), so what the list of unpaid purchases says is true.
        var after = f.App.Documents.Get(purchase.Document.Id)!;
        Assert.Equal(3_736, after.Document.PaidMinor);
        Assert.Equal(44_836 - 3_736, after.Document.BalanceMinor);
        Assert.Equal(44_836 - 3_736, f.App.Purchasing.Payable().Single().BalanceMinor);
        // The credit moves no money.
        Assert.Equal(0, Balance(f, "Cash"));
        Assert.Empty(note.Payments);
    }

    [Fact]
    public void A_purchase_already_paid_in_full_gets_its_money_back_when_the_supplier_pays_back_and_otherwise_stays_as_credit()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        var purchase = BuyU2(f, supplier, rice, paid: 44_836);
        Assert.Equal(-44_836, Balance(f, "Cash"));
        Assert.Equal(0, f.App.Books.SupplierBalance(supplier.Id));

        // U14, cash purchase return: the supplier pays the return back, so what we owe does not change.
        var back = f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "wrong brand", "cash", null);
        Assert.Equal(3_736, back.Document.TotalMinor);
        Assert.Equal(3_736, back.Document.PaidMinor);
        var refund = Assert.Single(back.Payments);
        Assert.Equal((3_736L, "refund", "cash"), (refund.AmountMinor, refund.Kind, refund.Method));
        Assert.Equal(-44_836 + 3_736, Balance(f, "Cash"));
        Assert.Equal(0, f.App.Books.SupplierBalance(supplier.Id));
        Assert.Equal(44_836, f.App.Documents.Get(purchase.Document.Id)!.Document.PaidMinor);   // the purchase stays paid: nothing was left to credit
        AssertBooksAgree(f);

        // The same return left as credit instead: the supplier owes us the 37.36 (a negative balance), nothing moves in the till.
        var credit = f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "wrong brand again", null, null);
        Assert.Equal(0, credit.Document.PaidMinor);
        Assert.Equal(3_736, credit.Document.BalanceMinor);
        Assert.Equal(-3_736, f.App.Books.SupplierBalance(supplier.Id));
        Assert.Equal(-44_836 + 3_736, Balance(f, "Cash"));
        AssertBooksAgree(f);
    }

    [Fact]
    public void A_part_paid_purchase_puts_the_credit_against_what_is_unpaid_first_and_only_the_rest_comes_back_in_money()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        var purchase = BuyU2(f, supplier, rice, paid: 44_000);                 // 8.36 is still unpaid
        var all = f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 12_000L) }, "the whole lot", "cash", null);

        Assert.Equal(44_836, all.Document.TotalMinor);                          // the whole purchase goes back
        var paidBack = Assert.Single(all.Payments);
        Assert.Equal(44_000, paidBack.AmountMinor);                              // the 8.36 unpaid is cancelled by the credit; the 440.00 that was paid comes back
        var after = f.App.Documents.Get(purchase.Document.Id)!;
        Assert.Equal(0, after.Document.BalanceMinor);
        Assert.Equal(44_836, after.Document.PaidMinor);
        Assert.Equal(0, f.App.Books.SupplierBalance(supplier.Id));
        Assert.Equal(0, f.App.Catalog.OnHandMilli(rice.Id));
        Assert.Equal(0, Balance(f, "Stock on the shelves"));
        Assert.Equal(0, Balance(f, "CGST paid on purchases"));
        Assert.Equal(0, Balance(f, "Purchases"));
        Assert.Equal(0, Balance(f, "Cash"));
        AssertBooksAgree(f);
    }

    [Fact]
    public void Only_what_was_received_can_be_sent_back_and_only_once_and_only_on_a_finished_purchase()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        var purchase = BuyU2(f, supplier, rice);
        var line = purchase.Lines[0].Id;

        Assert.Equal("too-many", Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (line, 12_500L) }, "more", null, null)).Code);
        f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (line, 10_000L) }, "most of it", null, null);
        Assert.Equal("too-many", Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (line, 2_500L) }, "too many now", null, null)).Code);
        f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (line, 2_000L) }, "the rest", null, null);          // exactly what is left
        Assert.Equal(0, f.App.Catalog.OnHandMilli(rice.Id));
        Assert.Equal("too-many", Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (line, 1L) }, "nothing left", null, null)).Code);

        Assert.Equal("empty", Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(purchase.Document.Id, Array.Empty<(long, long)>(), "nothing", null, null)).Code);
        Assert.Equal("reason", Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (line, 1_000L) }, " ", null, null)).Code);
        Assert.Equal("line", Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (999_999L, 1_000L) }, "not on it", null, null)).Code);

        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 1_000, CostMinor = 3_000 } });   // ordered, not received
        Assert.Equal("not-purchase", Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(order.Document.Id, new[] { (order.Lines[0].Id, 1_000L) }, "not here yet", null, null)).Code);
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 1_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 100_000 } } });
        Assert.Equal("not-purchase", Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1_000L) }, "a sale", null, null)).Code);
    }

    [Fact]
    public void The_pieces_of_a_discount_taken_off_by_amount_add_up_to_the_whole_when_a_purchase_is_sent_back_in_parts()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        var draft = f.App.Documents.CreateDraft(new DraftOptions
        {
            Type = DocTypes.Purchase, Direction = "in", PartyId = supplier.Id,
            Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 3_000, UnitPriceMinor = 10_000, DiscountAmountMinor = 1_000 } },   // 300.00 less 10.00 amount discount
        });
        var purchase = f.App.Purchasing.Receive(draft.Document.Id);
        Assert.Equal(29_000, purchase.Document.SubtotalMinor);

        var first = f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "one", null, null);
        var second = f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "two", null, null);
        var third = f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "three", null, null);

        Assert.Equal(29_000, first.Document.SubtotalMinor + second.Document.SubtotalMinor + third.Document.SubtotalMinor);   // 96.67 + 96.67 + 96.66: the pieces make the whole
        Assert.Equal(purchase.Document.TotalMinor, first.Document.TotalMinor + second.Document.TotalMinor + third.Document.TotalMinor);
        Assert.Equal(0, f.App.Books.SupplierBalance(supplier.Id));
        Assert.Equal(0, Balance(f, "Stock on the shelves"));
        AssertBooksAgree(f);
    }

    [Fact]
    public void Goods_that_are_no_longer_there_cannot_be_sent_back_in_a_shop_that_does_not_allow_negative_stock()
    {
        using var f = Shop(allowNegative: false);
        var supplier = Supplier(f);
        var rice = Goods(f);
        var purchase = BuyU2(f, supplier, rice);
        f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 11_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 10_000_000 } } });
        var refused = Assert.Throws<HubException>(() => f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 2_000L) }, "gone", null, null));
        Assert.Equal("stock", refused.Code);
        Assert.Equal(0, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE type = 'debit-note'")));   // nothing was made, no number was used
        Assert.Equal(0, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM number_series WHERE type = 'debit-note'")));
        f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "the one that is left", null, null);
    }

    [Fact]
    public void A_purchase_that_was_sent_back_cannot_be_cancelled_and_a_return_cannot_be_cancelled()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        var purchase = BuyU2(f, supplier, rice);
        var note = f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "damaged", null, null);

        Assert.Equal("has-debit-note", Assert.Throws<HubException>(() => f.App.Documents.Void(purchase.Document.Id, "mistake", null)).Code);
        Assert.Equal("debit-note-final", Assert.Throws<HubException>(() => f.App.Documents.Void(note.Document.Id, "mistake", null)).Code);
        Assert.Equal(DocStatus.Issued, f.App.Documents.Get(note.Document.Id)!.Document.Status);
    }

    [Fact]
    public void The_purchase_report_takes_the_goods_sent_back_off_and_the_tax_register_lists_them_and_the_summary_takes_them_off()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        var purchase = BuyU2(f, supplier, rice);
        var today = DateOnly.FromDateTime(f.Clock.UtcNow.UtcDateTime);
        Assert.Equal((44_836L, 44_836L), f.App.Reports.Purchases(today, today));

        f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "damaged", null, null);

        Assert.Equal((44_836L - 3_736, 44_836L - 3_736), f.App.Reports.Purchases(today, today));      // received less sent back; unpaid less the credit
        var returns = Assert.Single(f.App.TaxRegisters.Register(RegisterKinds.PurchaseReturns, today, today));
        Assert.Equal(("DN-2026-000001", "National Foods", 3_736L, 3_166L), (returns.Number, returns.PartyName, returns.TotalMinor, returns.TaxableMinor));
        Assert.Equal([(("CGST"), 285L), ("SGST", 285L)], returns.Parts.Select(p => (p.Name, p.AmountMinor)).ToArray());
        Assert.Single(f.App.TaxRegisters.Register(RegisterKinds.Purchases, today, today));              // the purchase itself is still in the purchases register, whole
    }

    [Fact]
    public void The_summary_of_what_was_bought_for_the_return_takes_the_goods_sent_back_off()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var purchase = BuyU2(f, supplier, Goods(f));
        var today = DateOnly.FromDateTime(f.Clock.UtcNow.UtcDateTime);
        Assert.True(f.App.TaxRegisters.HasSupplySummary);
        var before = f.App.TaxRegisters.SupplySummary(today, today).Blocks.Where(b => b.Side == "inward").ToList();
        Assert.Equal(37_996, before.Sum(b => b.ValueMinor));

        f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "damaged", null, null);

        var after = f.App.TaxRegisters.SupplySummary(today, today).Blocks.Where(b => b.Side == "inward").ToList();
        Assert.Equal(37_996 - 3_166, after.Sum(b => b.ValueMinor));
        Assert.Equal(2 * (3_420 - 285), after.Sum(b => b.Parts.Sum(p => p.AmountMinor)));
    }

    [Fact]
    public void A_return_leaves_the_event_a_return_leaves_and_is_remembered_in_the_activity_list()
    {
        using var f = new AiFixture();
        f.Allow(NextGenOS.Hub.Ai.FlagKey.EventEngine);
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 5_000, TaxClass = "zero", TrackStock = true });
        var purchase = f.App.Purchasing.Receive(f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 5_000, CostMinor = 3_000 } }).Document.Id);

        f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "damaged", null, 7);

        var returned = f.App.Outbox.List().Single(m => m.EventType == "purchase.returned");
        Assert.Equal("debit_note", returned.AggregateType);
        var entry = Assert.Single(f.App.Audit.Recent(50), a => a.Action == "debit-note");
        Assert.Equal(7, entry.UserId);
        Assert.Contains("damaged", entry.Detail);
    }

    [Fact]
    public void The_shops_books_still_agree_after_a_long_mixture_of_purchases_and_returns_and_payments()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f, "Rice");
        var dal = Goods(f, "Dal");
        var random = new Random(2026);
        var purchases = new List<DocumentView>();
        for (var i = 0; i < 25; i++)
        {
            var item = i % 2 == 0 ? rice : dal;
            var draft = f.App.Documents.CreateDraft(new DraftOptions
            {
                Type = DocTypes.Purchase, Direction = "in", PartyId = supplier.Id,
                Lines = { new LineInput { ItemId = item.Id, QtyMilli = 1_000 * random.Next(2, 20), UnitPriceMinor = random.Next(500, 9_999), DiscountPctMilli = random.Next(0, 3) * 2_500 } },
            });
            var received = f.App.Purchasing.Receive(draft.Document.Id);
            if (random.Next(3) == 0) received = f.App.Purchasing.Pay(received.Document.Id, received.Document.TotalMinor / 2, "cash");
            purchases.Add(received);
        }

        foreach (var purchase in purchases.Where((_, i) => i % 2 == 0))
        {
            var line = purchase.Lines[0];
            var qty = Math.Max(1, (long)random.Next(1, (int)(line.QtyMilli / 1_000))) * 1_000;
            f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (line.Id, qty) }, "mixed", random.Next(2) == 0 ? "cash" : null, null);
            AssertBooksAgree(f);
        }

        // What the supplier is owed in the books is what the documents say is unpaid, less the credit still held with the supplier.
        var unpaid = f.App.Purchasing.Payable().Sum(d => d.BalanceMinor);
        var heldWithSupplier = Convert.ToInt64(f.App.Db.Scalar("SELECT COALESCE(SUM(total_minor - paid_minor), 0) FROM documents WHERE type = 'debit-note'"));
        Assert.Equal(unpaid - heldWithSupplier, f.App.Books.SupplierBalance(supplier.Id));
    }
}

using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, suppliers: the most the shop may owe a supplier (the older POS's supplier credit limit, study 02 A3.3, test vectors SL1 to SL4). What the shop would owe after the goods
/// arrive (what it owes now, plus the part of this bill not paid) may not be more than the limit; equal is allowed; no limit means none. Rupees, paise; goods with no tax.
/// </summary>
public class SupplierLimitTests
{
    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static Item Goods(HubFixture f) => f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 1_000, TaxClass = "zero", TrackStock = true });

    private static Party Supplier(HubFixture f, long limitMinor) => f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Grain Co", CreditLimitMinor = limitMinor });

    private static DocumentView Order(HubFixture f, Party supplier, Item item, long amountMinor) =>
        f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = item.Id, QtyMilli = 1000, CostMinor = amountMinor } });

    [Fact]
    public void SL1_what_is_owed_already_counts_so_a_bill_that_takes_the_total_over_the_limit_is_refused_and_nothing_is_received()
    {
        using var f = Shop();
        var item = Goods(f);
        var supplier = Supplier(f, 1_000_000);                                              // the limit is 10,000.00
        f.App.Purchasing.Receive(Order(f, supplier, item, 600_000).Document.Id);             // 6,000.00 is now owed

        var second = Order(f, supplier, item, 500_000);                                      // 5,000.00 more would make 11,000.00
        var ex = Assert.Throws<HubException>(() => f.App.Purchasing.Receive(second.Document.Id));
        Assert.Equal("over-limit", ex.Code);
        Assert.Contains("Grain Co", ex.Message);
        Assert.Contains("11,000.00", ex.Message);
        Assert.Contains("10,000.00", ex.Message);
        Assert.Equal(DocStatus.Open, f.App.Documents.Get(second.Document.Id)!.Document.Status);     // still an order
        Assert.Equal(1_000, f.App.Catalog.OnHandMilli(item.Id));                                     // only the first delivery is on the shelf
        Assert.Equal(600_000, f.App.Books.SupplierBalance(supplier.Id));
    }

    [Fact]
    public void SL2_paying_part_of_what_is_owed_makes_room_and_a_total_exactly_at_the_limit_is_allowed()
    {
        using var f = Shop();
        var item = Goods(f);
        var supplier = Supplier(f, 1_000_000);
        var first = f.App.Purchasing.Receive(Order(f, supplier, item, 600_000).Document.Id);
        f.App.Purchasing.Pay(first.Document.Id, 100_000, "cash");                            // 1,000.00 paid: 5,000.00 is owed

        var second = f.App.Purchasing.Receive(Order(f, supplier, item, 500_000).Document.Id);   // 5,000.00 + 5,000.00 = 10,000.00, not more
        Assert.Equal(DocStatus.Issued, second.Document.Status);
        Assert.Equal(1_000_000, f.App.Books.SupplierBalance(supplier.Id));
    }

    [Fact]
    public void SL3_a_supplier_with_no_limit_is_never_refused()
    {
        using var f = Shop();
        var item = Goods(f);
        var supplier = Supplier(f, 0);
        f.App.Purchasing.Receive(Order(f, supplier, item, 90_000_000).Document.Id);
        f.App.Purchasing.Receive(Order(f, supplier, item, 90_000_000).Document.Id);
        Assert.Equal(180_000_000, f.App.Books.SupplierBalance(supplier.Id));
    }

    [Fact]
    public void SL4_the_limit_is_on_what_stays_unpaid_so_a_big_bill_paid_when_the_goods_arrive_is_allowed()
    {
        using var f = Shop();
        var item = Goods(f);
        var supplier = Supplier(f, 1_000_000);
        var big = Order(f, supplier, item, 1_200_000);                                      // 12,000.00, more than the limit
        Assert.Equal("over-limit", Assert.Throws<HubException>(() => f.App.Purchasing.Receive(big.Document.Id)).Code);     // on account it is too much

        var paid = f.App.Documents.Issue(big.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = 1_200_000 } } });
        Assert.Equal(DocStatus.Issued, paid.Document.Status);
        Assert.Equal(0, f.App.Books.SupplierBalance(supplier.Id));
    }

    [Fact]
    public void A_limit_on_a_customer_or_goods_sold_are_not_touched_by_the_supplier_rule()
    {
        using var f = Shop();
        var item = Goods(f);
        var supplier = Supplier(f, 1_000_000);
        f.App.Purchasing.Receive(Order(f, supplier, item, 900_000).Document.Id);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = item.Id, QtyMilli = 1000 } } });
        var sold = f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = f.App.Documents.Get(draft.Document.Id)!.Document.PayableMinor } } });
        Assert.Equal(DocStatus.Issued, sold.Document.Status);
    }
}

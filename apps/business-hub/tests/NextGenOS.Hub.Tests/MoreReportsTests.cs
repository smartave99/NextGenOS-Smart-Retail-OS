using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, the older POS's report set (study 02 C): bills with how each was paid and the profit (R6, R8, F1 to F3), profit by item, best and low sellers by quantity (E1 to E3), the purchase list (U1, U2),
/// an item's sales history and the out-of-stock list (T1). The clock says 5 October 2026. Prices exclude tax and are in rupees; "zero" tax keeps the arithmetic plain.
/// </summary>
public class MoreReportsTests
{
    private static readonly DateOnly Day = new(2026, 10, 5);

    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static Item Goods(HubFixture f, string name, long priceMinor = 10_000, string tax = "zero") =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = priceMinor, TaxClass = tax, TrackStock = true });

    /// <summary>Stock bought at a price, so that sales have a cost.</summary>
    private static void Buy(HubFixture f, Item item, long qtyMilli, long costMinor)
    {
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Supplier of " + item.Name });
        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = item.Id, QtyMilli = qtyMilli, CostMinor = costMinor } });
        f.App.Purchasing.Receive(order.Document.Id);
    }

    private static DocumentView Sell(HubFixture f, Item item, long qtyMilli, long discountAmountMinor = 0, long? userId = null, params (string Method, long Amount)[] pays)
    {
        var draft = f.App.Documents.CreateDraft(new DraftOptions { UserId = userId, Lines = { new LineInput { ItemId = item.Id, QtyMilli = qtyMilli, DiscountAmountMinor = discountAmountMinor } } });
        var payable = f.App.Documents.Get(draft.Document.Id)!.Document.PayableMinor;
        var payments = pays.Length > 0 ? pays.Select(p => new PaymentInput { Method = p.Method, AmountMinor = p.Amount }).ToList() : [new PaymentInput { Method = "cash", AmountMinor = payable }];
        var options = new IssueOptions { UserId = userId };
        options.Payments.AddRange(payments);
        return f.App.Documents.Issue(draft.Document.Id, options);
    }

    // ---- bills ------------------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void R6_a_bill_shows_a_column_for_each_way_it_was_paid_and_what_is_still_owed()
    {
        using var f = new HubFixture("IN", "wholesale", s => s.PricesIncludeTax = false);   // a trade where customers can have credit
        var rice = Goods(f, "Rice", 100_000);
        var buyer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Sharma Store", CreditLimitMinor = 10_000_000 });
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = buyer.Id, Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 1_000 } } });
        var options = new IssueOptions { OnCredit = true };
        options.Payments.Add(new PaymentInput { Method = "cash", AmountMinor = 30_000 });
        options.Payments.Add(new PaymentInput { Method = "card", AmountMinor = 20_000 });
        f.App.Documents.Issue(draft.Document.Id, options);

        var bill = Assert.Single(f.App.Reports.Bills(Day, Day));

        Assert.Equal(100_000, bill.TotalMinor);
        Assert.Equal(30_000, bill.ByMethod["cash"]);
        Assert.Equal(20_000, bill.ByMethod["card"]);
        Assert.Equal(50_000, bill.PaidMinor);
        Assert.Equal(50_000, bill.DueMinor);   // the rest is on the customer's account
        Assert.Equal("Sharma Store", bill.Customer);
        Assert.False(bill.IsReturn);
    }

    [Fact]
    public void R8_only_the_bills_of_the_cashier_named_are_listed_and_the_cashier_is_shown()
    {
        using var f = Shop();
        var rice = Goods(f, "Rice");
        var anu = f.App.Users.Create("anu", "Anu", Roles.Cashier, "a good password for anu").Id;
        var raj = f.App.Users.Create("raj", "Raj", Roles.Cashier, "a good password for raj").Id;
        Sell(f, rice, 1_000, userId: anu);
        Sell(f, rice, 2_000, userId: raj);
        Sell(f, rice, 3_000, userId: anu);

        Assert.Equal(3, f.App.Reports.Bills(Day, Day).Count);
        var anus = f.App.Reports.Bills(Day, Day, anu);
        Assert.Equal(new[] { 10_000L, 30_000L }, anus.Select(b => b.TotalMinor).ToArray());
        Assert.All(anus, b => Assert.Equal("Anu", b.Cashier));
        Assert.Empty(f.App.Reports.Bills(Day.AddDays(1), Day.AddDays(1)));
    }

    [Fact]
    public void F1_to_F3_the_profit_of_a_bill_is_what_it_earned_before_tax_less_what_the_goods_cost_and_a_return_gives_both_back()
    {
        using var f = Shop();
        var rice = Goods(f, "Rice", 10_000);   // sold at 100.00
        Buy(f, rice, 10_000, 6_000);           // bought at 60.00
        var bill = Sell(f, rice, 2_000);       // 200.00 for goods that cost 120.00

        var row = Assert.Single(f.App.Reports.Bills(Day, Day));
        Assert.Equal((20_000L, 12_000L, 8_000L), (row.TaxableMinor, row.CostMinor, row.ProfitMinor));

        // F1: a discount lowers what the bill earned, not what the goods cost
        var cheap = Sell(f, rice, 1_000, discountAmountMinor: 1_500);
        var cheapRow = f.App.Reports.Bills(Day, Day).Single(b => b.Id == cheap.Document.Id);
        Assert.Equal((8_500L, 6_000L, 2_500L), (cheapRow.TaxableMinor, cheapRow.CostMinor, cheapRow.ProfitMinor));

        // a return is a row of its own, below nothing, and takes back the cost it had
        f.App.Documents.CreateCreditNote(bill.Document.Id, new[] { (bill.Lines[0].Id, 1_000L) }, "wrong", "cash", null);
        var back = f.App.Reports.Bills(Day, Day).Single(b => b.IsReturn);
        Assert.Equal((-10_000L, -6_000L, -4_000L), (back.TaxableMinor, back.CostMinor, back.ProfitMinor));
        Assert.Equal(-10_000, back.TotalMinor);
        Assert.Equal(-10_000, back.PaidMinor);
        Assert.Equal(0, back.DueMinor);
        Assert.Equal(8_000 + 2_500 - 4_000, f.App.Reports.Bills(Day, Day).Sum(b => b.ProfitMinor));
    }

    [Fact]
    public void A_loss_shows_as_a_profit_below_nothing_and_goods_that_keep_no_stock_have_no_cost()
    {
        using var f = Shop();
        var rice = Goods(f, "Rice", 4_000);
        Buy(f, rice, 5_000, 6_000);   // bought at 60.00, sold at 40.00
        Sell(f, rice, 1_000);
        var service = f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Haircut", PriceMinor = 30_000, TaxClass = "zero" });
        Sell(f, service, 1_000);

        var rows = f.App.Reports.Bills(Day, Day);

        Assert.Equal(-2_000, rows[0].ProfitMinor);
        Assert.Equal((30_000L, 0L, 30_000L), (rows[1].TaxableMinor, rows[1].CostMinor, rows[1].ProfitMinor));
    }

    // ---- profit by item, best and low sellers ------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Profit_by_item_adds_up_sales_and_costs_over_the_period_and_takes_returns_off()
    {
        using var f = Shop();
        var rice = Goods(f, "Rice", 10_000);
        var tea = Goods(f, "Tea", 5_000);
        Buy(f, rice, 20_000, 6_000);
        Buy(f, tea, 20_000, 4_000);
        var a = Sell(f, rice, 3_000);
        Sell(f, rice, 1_000, discountAmountMinor: 1_000);
        Sell(f, tea, 2_000);
        f.App.Documents.CreateCreditNote(a.Document.Id, new[] { (a.Lines[0].Id, 1_000L) }, "wrong", "cash", null);

        var rows = f.App.Reports.ProfitByItem(Day, Day).ToDictionary(r => r.Name);

        // rice: sold 3 + 1 less 1 back = 3; before tax 300.00 + 90.00 - 100.00 = 290.00; cost 3 x 60.00 = 180.00; profit 110.00
        Assert.Equal((3_000L, 29_000L, 18_000L, 11_000L), (rows["Rice"].QtyMilli, rows["Rice"].TaxableMinor, rows["Rice"].CostMinor, rows["Rice"].ProfitMinor));
        Assert.Equal((2_000L, 10_000L, 8_000L, 2_000L), (rows["Tea"].QtyMilli, rows["Tea"].TaxableMinor, rows["Tea"].CostMinor, rows["Tea"].ProfitMinor));
        Assert.Equal("Rice", f.App.Reports.ProfitByItem(Day, Day)[0].Name);   // most profit first
    }

    [Fact]
    public void E1_to_E3_best_and_low_sellers_by_quantity_leave_out_what_did_not_sell_and_take_returns_off()
    {
        using var f = Shop();
        var a = Goods(f, "A"); var b = Goods(f, "B"); Goods(f, "C");
        var first = Sell(f, a, 10_000);
        Sell(f, a, 5_000);
        Sell(f, b, 3_000);

        var best = f.App.Reports.TopItems(Day, Day, 20, byQuantity: true);
        var low = f.App.Reports.TopItems(Day, Day, 20, byQuantity: true, lowest: true);

        Assert.Equal(new[] { ("A", 15_000L), ("B", 3_000L) }, best.Select(x => (x.Name, x.QtyMilli)).ToArray());   // E1: C is absent
        Assert.Equal(new[] { ("B", 3_000L), ("A", 15_000L) }, low.Select(x => (x.Name, x.QtyMilli)).ToArray());

        // E2: the older program kept counting what came back; here it is taken off
        f.App.Documents.CreateCreditNote(first.Document.Id, new[] { (first.Lines[0].Id, 4_000L) }, "wrong", "cash", null);
        Assert.Equal(11_000, f.App.Reports.TopItems(Day, Day, 20, byQuantity: true).First(x => x.Name == "A").QtyMilli);
        // by money the order is as before
        Assert.Equal("A", f.App.Reports.TopItems(Day, Day).First().Name);
    }

    // ---- buying -----------------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void U1_and_U2_the_purchase_list_has_each_purchase_once_with_the_value_the_tax_and_what_is_unpaid_and_goods_sent_back_below_nothing()
    {
        using var f = Shop();
        var rice = Goods(f, "Rice", 10_000, tax: "standard");
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 10_000, CostMinor = 10_000 } });   // 10 x 100.00 + 18% tax
        var purchase = f.App.Purchasing.Receive(order.Document.Id);
        f.App.Purchasing.Pay(purchase.Document.Id, 50_000, "cash");
        f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 1_000L) }, "damaged", null, null);

        var rows = f.App.Reports.PurchaseRegister(Day, Day);

        Assert.Equal(2, rows.Count);
        var bought = rows[0];
        // 50,000 was paid; the 11,800 sent back became credit against what was still unpaid, so it counts as paid too (as in "Still to pay to suppliers")
        Assert.Equal(("National Foods", 100_000L, 18_000L, 118_000L, 61_800L, 56_200L), (bought.Supplier, bought.TaxableMinor, bought.TaxMinor, bought.TotalMinor, bought.PaidMinor, bought.DueMinor));
        var back = rows[1];
        Assert.True(back.IsReturn);
        Assert.Equal((-10_000L, -1_800L, -11_800L), (back.TaxableMinor, back.TaxMinor, back.TotalMinor));
        Assert.Equal(118_000 - 11_800, rows.Sum(r => r.TotalMinor));
        Assert.Empty(f.App.Reports.PurchaseRegister(Day.AddDays(1), Day.AddDays(2)));
    }

    // ---- an item's history, and what is out ----------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void An_items_history_shows_the_price_before_discount_and_tax_the_discount_and_the_return_below_nothing_newest_first()
    {
        using var f = Shop();
        var rice = Goods(f, "Rice", 10_000);
        var other = Goods(f, "Tea");
        var first = Sell(f, rice, 2_000, discountAmountMinor: 2_000);   // 2 x 100.00, 20.00 off: 180.00
        Sell(f, other, 1_000);
        f.Clock.Advance(TimeSpan.FromHours(1));
        Sell(f, rice, 1_000);
        f.App.Documents.CreateCreditNote(first.Document.Id, new[] { (first.Lines[0].Id, 1_000L) }, "wrong", "cash", null);

        var history = f.App.Reports.ProductHistory(rice.Id);

        Assert.Equal(3, history.Count);
        Assert.True(history[0].IsReturn);   // the return was made last
        var sold = history.Single(h => h.DocumentId == first.Document.Id && !h.IsReturn);
        Assert.Equal((2_000L, 10_000L, 2_000L, 0L, 18_000L), (sold.QtyMilli, sold.UnitMinor, sold.DiscountMinor, sold.TaxMinor, sold.TotalMinor));
        Assert.Single(f.App.Reports.ProductHistory(rice.Id, 1));
        Assert.DoesNotContain(history, h => h.Number == f.App.Documents.Get(first.Document.Id + 1)!.Document.Number);   // the other item's bill is not here
    }

    [Fact]
    public void T1_the_out_of_stock_list_has_the_items_with_nothing_or_less_than_nothing_and_leaves_out_items_that_keep_no_stock()
    {
        using var f = Shop();
        var has = Goods(f, "Has");
        var none = Goods(f, "None");
        var below = Goods(f, "Below");
        f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Haircut", PriceMinor = 1_000, TaxClass = "zero" });
        f.App.Catalog.Adjust(has.Id, 5_000, "opening stock");
        f.App.Catalog.Adjust(below.Id, -2_000, "count");

        var rows = f.App.Reports.OutOfStock();

        Assert.Equal(new[] { ("Below", -2_000L), ("None", 0L) }, rows.Select(r => (r.Name, r.OnHandMilli)).ToArray());
    }
}

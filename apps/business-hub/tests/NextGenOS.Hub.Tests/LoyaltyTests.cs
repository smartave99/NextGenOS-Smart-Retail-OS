using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Loyalty;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Loyalty points (decision 31): points per item with a money value per point. The numbers Q1 to Q10 are the older touch tills' worked examples from
/// docs/old-programs/02-masters-accounting-reports.md (A1.6); where the Hub differs on purpose (points on what the line comes to after discounts, a hard stop at the balance) the test says so.
/// </summary>
public class LoyaltyTests
{
    private static HubFixture Shop(string mode = "none", long value = 0, long pointValueMilli = 500, bool on = true) =>
        new("IN", "retail", s => { s.PricesIncludeTax = false; s.LoyaltyOn = on; s.LoyaltyDefaultMode = mode; s.LoyaltyDefaultValueMilli = value; s.LoyaltyPointValueMilli = pointValueMilli; });

    private static Item Product(HubFixture f, string name, long priceMinor, string? mode = null, string? value = null)
    {
        var attrs = new Dictionary<string, string>();
        if (mode is not null) attrs[LoyaltyService.ModeKey] = mode;
        if (value is not null) attrs[LoyaltyService.ValueKey] = value;
        return f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = priceMinor, TaxClass = "standard", TrackStock = false, Attrs = attrs });
    }

    private static Party Customer(HubFixture f, string name = "Asha") => f.App.Parties.Create(new PartyInput { Kind = "customer", Name = name });

    private static DocumentView Sell(HubFixture f, Party? who, long itemId, long qtyMilli = 1000, long points = 0, long cash = 0)
    {
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = who?.Id, Lines = { new LineInput { ItemId = itemId, QtyMilli = qtyMilli } } });
        if (points > 0) draft = f.App.Documents.SetLoyaltyPoints(draft.Document.Id, points);
        return f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = cash > 0 ? cash : draft.Document.PayableMinor } } });
    }

    private static void Give(HubFixture f, Party who, long pointsCent)
    {
        using var c = f.App.Db.Open();
        HubDb.Exec(c, "INSERT INTO loyalty_ledger(party_id, at, kind, points_cent, memo, created_at) VALUES ($p, '2026-10-01T00:00:00+00:00', 'opening', $n, 'brought across', '2026-10-01T00:00:00+00:00')", null, ("$p", who.Id), ("$n", pointsCent));
    }

    // ---- the arithmetic ------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Q1_to_Q3_and_Q9_the_points_of_a_line()
    {
        Assert.Equal(3_000, LoyaltyService.LinePointsCent("per", 5_000, 60_000, 3_000, 2));    // Q1: 200.00 x 3 at 5%  = 30.00 points
        Assert.Equal(800, LoyaltyService.LinePointsCent("point", 2_000, 0, 4_000, 2));         // Q2: 4 units at 2 points = 8.00
        Assert.Equal(375, LoyaltyService.LinePointsCent("per", 2_500, 15_000, 1_500, 2));      // Q3: 150.00 at 2.5%    = 3.75
        Assert.Equal(0, LoyaltyService.LinePointsCent("per", 0, 60_000, 3_000, 2));            // Q9: a value of nothing earns nothing
        Assert.Equal(0, LoyaltyService.LinePointsCent("none", 5_000, 60_000, 3_000, 2));
        Assert.Equal(3_000 + 800 + 375, LoyaltyService.LinePointsCent("per", 5_000, 60_000, 3_000, 2) + LoyaltyService.LinePointsCent("point", 2_000, 0, 4_000, 2) + LoyaltyService.LinePointsCent("per", 2_500, 15_000, 1_500, 2));   // Q4: 41.75
        Assert.Equal(6_000, LoyaltyService.PointsValueMinor(12_000, 500, 2));                  // Q5: 120 points at 0.50 each = 60.00
        Assert.Equal(2_500, LoyaltyService.PointsValueMinor(5_000, 500, 2));                   // Q6: 50 points = 25.00
        Assert.Equal(0, LoyaltyService.PointsValueMinor(5_000, 0, 2));
        Assert.Equal(25, LoyaltyService.PointsValueMinor(5_000, 500, 0));                      // a currency with no decimals: 50 points at 0.5 each = 25 whole units
    }

    // ---- earning -------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Q4_a_bill_with_three_kinds_of_item_earns_the_sum_and_a_walk_in_earns_nothing()
    {
        using var f = Shop();
        var a = Product(f, "Pens", 20_000, "per", "5");        // Q1
        var b = Product(f, "Cards", 100, "point", "2");        // Q2
        var c = Product(f, "Nuts", 10_000, "per", "2,5");      // Q3
        var asha = Customer(f);
        var draft = f.App.Documents.CreateDraft(new DraftOptions
        {
            PartyId = asha.Id,
            Lines = { new LineInput { ItemId = a.Id, QtyMilli = 3_000 }, new LineInput { ItemId = b.Id, QtyMilli = 4_000 }, new LineInput { ItemId = c.Id, QtyMilli = 1_500 } },
        });
        f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = draft.Document.PayableMinor } } });
        Assert.Equal(4_175, f.App.Loyalty.Balance(asha.Id));
        Assert.Equal(new[] { "earn" }, f.App.Loyalty.Ledger(asha.Id).Select(r => r.Kind).ToArray());
        // a walk-in customer has no points
        Sell(f, null, a.Id);
        Assert.Equal(1, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(DISTINCT party_id) FROM loyalty_ledger")));
    }

    [Fact]
    public void An_item_with_no_setting_of_its_own_follows_the_shops_default_and_nothing_is_earned_when_loyalty_is_off()
    {
        using var f = Shop("per", 1_000);                      // 1% by default
        var plain = Product(f, "Rice", 50_000);
        var asha = Customer(f);
        Sell(f, asha, plain.Id);                               // 500.00 at 1% = 5.00 points
        Assert.Equal(500, f.App.Loyalty.Balance(asha.Id));
        using var off = Shop("per", 1_000, on: false);
        var rice = Product(off, "Rice", 50_000);
        var bob = Customer(off, "Bob");
        Sell(off, bob, rice.Id);
        Assert.Equal(0, off.App.Loyalty.Balance(bob.Id));
        // an item that says "none" earns nothing even under a default
        var none = Product(f, "Gift card", 50_000, "none");
        Sell(f, asha, none.Id);
        Assert.Equal(500, f.App.Loyalty.Balance(asha.Id));
    }

    [Fact]
    public void Points_are_earned_on_what_the_line_comes_to_after_its_discounts_not_on_the_list_price()
    {
        using var f = Shop("per", 10_000);                     // 10%
        var item = Product(f, "Lamp", 100_000);
        var asha = Customer(f);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = item.Id, DiscountPctMilli = 20_000 } } });
        f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = draft.Document.PayableMinor } } });
        Assert.Equal(8_000, f.App.Loyalty.Balance(asha.Id));   // 10% of 800.00, not of 1,000.00 (the older POS gave 100.00 points)
    }

    // ---- using points --------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Q6_using_points_takes_their_value_off_the_bill_before_tax_and_the_balance_falls()
    {
        using var f = Shop("per", 5_000);                      // earn 5%, a point is worth 0.50
        var item = Product(f, "Lamp", 20_000);
        var asha = Customer(f);
        Give(f, asha, 12_000);                                 // 120 points
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = item.Id } } });
        var with = f.App.Documents.SetLoyaltyPoints(draft.Document.Id, 5_000);   // 50 points
        Assert.Equal(2_500, with.Document.LoyaltyDiscountMinor);                 // 25.00 off
        Assert.Equal("25.00", with.Result!.Totals.Discount);
        Assert.Equal(20_650, with.Document.PayableMinor);                        // (200.00 - 25.00) + 18% = 206.50
        var bill = f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = 20_650 } } });
        // 120 - 50 = 70 left, and 5% of the 175.00 the bill came to is 8.75 earned
        Assert.Equal(7_000 + 875, f.App.Loyalty.Balance(asha.Id));
        Assert.Equal(new[] { "opening", "redeem", "earn" }, f.App.Loyalty.Ledger(asha.Id).Select(r => r.Kind).ToArray());
        Assert.Equal(5_000, bill.Document.LoyaltyPointsUsedCent);
        // taking the points off again
        var d2 = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = item.Id } } });
        f.App.Documents.SetLoyaltyPoints(d2.Document.Id, 1_000);
        Assert.Equal(0, f.App.Documents.SetLoyaltyPoints(d2.Document.Id, 0).Document.LoyaltyDiscountMinor);
    }

    [Fact]
    public void Q10_more_points_than_the_balance_are_refused_and_so_are_points_without_a_customer_or_a_value()
    {
        using var f = Shop("none", 0);
        var item = Product(f, "Lamp", 20_000);
        var asha = Customer(f);
        Give(f, asha, 12_000);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = item.Id } } });
        Assert.Equal("loyalty", Assert.Throws<HubException>(() => f.App.Documents.SetLoyaltyPoints(draft.Document.Id, 13_000)).Code);   // the older POS did not stop this
        var walkIn = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = item.Id } } });
        Assert.Contains("customer", Assert.Throws<HubException>(() => f.App.Documents.SetLoyaltyPoints(walkIn.Document.Id, 100)).Message);
        Assert.Equal("loyalty", Assert.Throws<HubException>(() => f.App.Documents.SetLoyaltyPoints(draft.Document.Id, -1)).Code);
        // points worth more than the bill
        var cheap = Product(f, "Pen", 1_000);
        var small = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = cheap.Id } } });
        Assert.Contains("worth more than the bill", Assert.Throws<HubException>(() => f.App.Documents.SetLoyaltyPoints(small.Document.Id, 12_000)).Message);   // 60.00 off a 10.00 bill
        // a point with no value yet
        using var free = Shop("none", 0, pointValueMilli: 0);
        var asha2 = Customer(free);
        Give(free, asha2, 1_000);
        var d = free.App.Documents.CreateDraft(new DraftOptions { PartyId = asha2.Id, Lines = { new LineInput { ItemId = Product(free, "Pen", 1_000).Id } } });
        Assert.Contains("no value", Assert.Throws<HubException>(() => free.App.Documents.SetLoyaltyPoints(d.Document.Id, 500)).Message);
        // loyalty switched off
        using var off = Shop(on: false);
        var o = Customer(off);
        var od = off.App.Documents.CreateDraft(new DraftOptions { PartyId = o.Id, Lines = { new LineInput { ItemId = Product(off, "Pen", 1_000).Id } } });
        Assert.Contains("not switched on", Assert.Throws<HubException>(() => off.App.Documents.SetLoyaltyPoints(od.Document.Id, 100)).Message);
    }

    [Fact]
    public void Points_used_on_a_bill_are_checked_again_when_the_bill_is_made()
    {
        using var f = Shop("none", 0);
        var item = Product(f, "Lamp", 20_000);
        var asha = Customer(f);
        Give(f, asha, 6_000);
        var one = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = item.Id } } });
        var two = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = item.Id } } });
        f.App.Documents.SetLoyaltyPoints(one.Document.Id, 5_000);
        f.App.Documents.SetLoyaltyPoints(two.Document.Id, 5_000);     // each alone is allowed ...
        f.App.Documents.Issue(one.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = 20_650 } } });
        var ex = Assert.Throws<HubException>(() => f.App.Documents.Issue(two.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = 20_650 } } }));   // ... but not both
        Assert.Equal("loyalty", ex.Code);
        Assert.Equal(1_000, f.App.Loyalty.Balance(asha.Id));
        Assert.Equal(DocStatus.Open, f.App.Documents.Get(two.Document.Id)!.Document.Status);   // nothing of the failed bill was kept
    }

    // ---- taking points back --------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_cancelled_bill_gives_back_the_points_used_and_takes_back_the_points_earned()
    {
        using var f = Shop("per", 5_000);
        var item = Product(f, "Lamp", 20_000);
        var asha = Customer(f);
        Give(f, asha, 12_000);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = item.Id } } });
        f.App.Documents.SetLoyaltyPoints(draft.Document.Id, 5_000);
        var bill = f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = 20_650 } } });
        Assert.Equal(7_875, f.App.Loyalty.Balance(asha.Id));
        f.App.Documents.Void(bill.Document.Id, "mistake", null);
        Assert.Equal(12_000, f.App.Loyalty.Balance(asha.Id));
    }

    [Fact]
    public void Goods_taken_back_take_back_the_points_they_earned()
    {
        using var f = Shop("per", 10_000);                     // 10%
        var item = Product(f, "Lamp", 10_000);
        var asha = Customer(f);
        var bill = Sell(f, asha, item.Id, qtyMilli: 4_000);    // 400.00: 40.00 points
        Assert.Equal(4_000, f.App.Loyalty.Balance(asha.Id));
        f.App.Documents.CreateCreditNote(bill.Document.Id, new[] { (bill.Lines[0].Id, 1_000L) }, "wrong", "cash", null);   // one of four comes back
        Assert.Equal(3_000, f.App.Loyalty.Balance(asha.Id));
        Assert.Equal(new[] { "earn", "return" }, f.App.Loyalty.Ledger(asha.Id).Select(r => r.Kind).ToArray());
    }

    [Fact]
    public void The_points_ledger_cannot_be_changed_and_the_step_can_be_undone()
    {
        using var f = Shop("per", 10_000);
        var asha = Customer(f);
        Sell(f, asha, Product(f, "Lamp", 10_000).Id);
        void Run(string sql) { using var c = f.App.Db.Open(); HubDb.Exec(c, sql); }
        Assert.ThrowsAny<Exception>(() => Run("UPDATE loyalty_ledger SET points_cent = 99999"));
        Assert.ThrowsAny<Exception>(() => Run("DELETE FROM loyalty_ledger"));
        f.App.Db.Rollback(7);                     // the points step (008) and the newer ones are undone
        Assert.Empty(f.App.Db.Query("SELECT name FROM sqlite_master WHERE name = 'loyalty_ledger'", r => r.GetString(0)));
        Assert.DoesNotContain("loyalty_discount_minor", f.App.Db.Query("SELECT name FROM pragma_table_info('documents')", r => r.GetString(0)));
        Assert.NotEqual(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents")));
    }
}

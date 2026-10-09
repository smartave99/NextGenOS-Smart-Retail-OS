using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, products tools: batch numbers and expiry dates (the older POS kept stock per lot, study 01 6.2 and 6.8; T1 and T2 of the stock table: a lot has a batch and dates, and an expired lot cannot be sold).
/// The clock of these tests says 5 October 2026. Rice-like goods are bought at 10.00 a piece; rupees, paise.
/// </summary>
public class BatchTests
{
    private static HubFixture Shop(bool allowNegative = true) => new("IN", "retail", s => { s.AllowNegativeStock = allowNegative; s.PricesIncludeTax = false; });

    private static DateOnly D(int month, int day, int year = 2026) => new(year, month, day);

    private static Item Medicine(HubFixture f, string name = "Paracetamol", bool batches = true) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = 5_000, TaxClass = "zero", TrackStock = true, TrackBatches = batches });

    private static Party Supplier(HubFixture f) => f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Pharma Co" });

    private static DocumentView Receive(HubFixture f, Item item, params (string No, long Qty, DateOnly? Mfg, DateOnly? Exp)[] batches)
    {
        var order = f.App.Purchasing.CreateOrder(Supplier(f).Id, batches.Select(b => new PurchaseLine { ItemId = item.Id, QtyMilli = b.Qty, CostMinor = 1_000, BatchNo = b.No, MfgOn = b.Mfg, ExpOn = b.Exp }));
        return f.App.Purchasing.Receive(order.Document.Id);
    }

    private static DocumentView Sell(HubFixture f, Item item, long qtyMilli)
    {
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = item.Id, QtyMilli = qtyMilli } } });
        var pay = f.App.Documents.Get(draft.Document.Id)!.Document.PayableMinor;
        return f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = pay } } });
    }

    private static long Held(HubFixture f, Item item, string batchNo) => f.App.Batches.ForItem(item.Id, true).Single(b => b.BatchNo == batchNo).OnHandMilli;

    // ---- deliveries ---------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_delivery_names_each_batch_with_its_dates_and_the_batches_are_listed_soonest_expiry_first()
    {
        using var f = Shop();
        var item = Medicine(f);

        Receive(f, item, ("A100", 100_000, D(1, 1), D(12, 31)), ("B200", 50_000, D(2, 1), D(11, 30)), ("C300", 10_000, null, null));

        var list = f.App.Batches.ForItem(item.Id);
        Assert.Equal(new[] { "B200", "A100", "C300" }, list.Select(b => b.BatchNo).ToArray());   // no expiry last
        Assert.Equal(160_000, f.App.Catalog.OnHandMilli(item.Id));
        var a = list.Single(b => b.BatchNo == "A100");
        Assert.Equal((D(1, 1), D(12, 31), 100_000L, 87), (a.MfgOn, a.ExpOn, a.OnHandMilli, a.DaysLeft));
    }

    [Fact]
    public void A_purchase_line_of_an_item_that_keeps_batches_must_name_one_and_nothing_is_saved_without_it()
    {
        using var f = Shop();
        var item = Medicine(f);

        var ex = Assert.Throws<HubException>(() => Receive(f, item, ("", 10_000, null, null)));

        Assert.Equal("batch-no", ex.Code);
        Assert.Contains("batch number of Paracetamol", ex.Message);
        Assert.Equal(0, f.App.Catalog.OnHandMilli(item.Id));
    }

    [Fact]
    public void The_same_batch_number_in_another_delivery_adds_to_that_batch_but_cannot_have_a_different_expiry_date()
    {
        using var f = Shop();
        var item = Medicine(f);
        Receive(f, item, ("A100", 10_000, null, D(12, 31)));

        Receive(f, item, ("a100", 5_000, null, D(12, 31)));   // the number is not case sensitive

        Assert.Equal(15_000, Held(f, item, "A100"));
        Assert.Single(f.App.Batches.ForItem(item.Id));
        var ex = Assert.Throws<HubException>(() => Receive(f, item, ("A100", 5_000, null, D(11, 30))));
        Assert.Equal("batch-expiry", ex.Code);
        Assert.Contains("already expires on 31 Dec 2026", ex.Message);
        Assert.Equal(15_000, f.App.Catalog.OnHandMilli(item.Id));
    }

    [Fact]
    public void The_dates_of_a_batch_must_make_sense()
    {
        using var f = Shop();
        var item = Medicine(f);

        var ex = Assert.Throws<HubException>(() => Receive(f, item, ("A1", 1_000, D(6, 1), D(5, 1))));

        Assert.Equal("batch-dates", ex.Code);
    }

    [Fact]
    public void The_batch_can_be_named_when_the_goods_arrive_and_not_only_when_the_order_is_made()
    {
        using var f = Shop();
        var item = Medicine(f);
        var order = f.App.Purchasing.CreateOrder(Supplier(f).Id, new[] { new PurchaseLine { ItemId = item.Id, QtyMilli = 20_000, CostMinor = 1_000 } });

        f.App.Purchasing.Receive(order.Document.Id, null, new Dictionary<long, ReceivedBatch> { [order.Lines[0].Id] = new ReceivedBatch("Z9", null, D(12, 1)) });

        Assert.Equal(20_000, Held(f, item, "Z9"));
    }

    // ---- selling: soonest expiry first, never an expired batch (T2) -------------------------------------------------------------------------------------

    [Fact]
    public void A_sale_takes_the_batch_that_expires_first_and_then_the_next()
    {
        using var f = Shop();
        var item = Medicine(f);
        Receive(f, item, ("A100", 100_000, null, D(12, 31)), ("B200", 50_000, null, D(11, 30)));

        Sell(f, item, 60_000);

        Assert.Equal(0, Held(f, item, "B200"));
        Assert.Equal(90_000, Held(f, item, "A100"));
        Assert.Equal(90_000, f.App.Catalog.OnHandMilli(item.Id));
    }

    [Fact]
    public void T2_an_expired_batch_is_never_sold_and_the_expiry_date_itself_counts_as_expired()
    {
        using var f = Shop(allowNegative: false);
        var item = Medicine(f);
        Receive(f, item, ("OLD", 40_000, null, D(10, 5)), ("NEW", 10_000, null, D(12, 31)));   // OLD expires today: expired

        Sell(f, item, 10_000);
        Assert.Equal(40_000, Held(f, item, "OLD"));
        Assert.Equal(0, Held(f, item, "NEW"));

        var ex = Assert.Throws<HubException>(() => Sell(f, item, 1_000));
        Assert.Equal("stock", ex.Code);
        Assert.Contains("Only 0 of Paracetamol can be sold", ex.Message);
        Assert.Contains("40 more are past the expiry date", ex.Message);
        Assert.Equal(40_000, f.App.Catalog.OnHandMilli(item.Id));
    }

    [Fact]
    public void Without_enough_batches_the_shop_that_allows_stock_below_nothing_sells_the_rest_without_a_batch()
    {
        using var f = Shop(allowNegative: true);
        var item = Medicine(f);
        Receive(f, item, ("A100", 5_000, null, D(12, 31)));

        Sell(f, item, 8_000);

        Assert.Equal(-3_000, f.App.Catalog.OnHandMilli(item.Id));
        Assert.Equal(0, Held(f, item, "A100"));
        Assert.Contains(f.App.Batches.ForItem(item.Id), b => b.Id == 0 && b.OnHandMilli == -3_000);   // the stock in no batch is shown too
    }

    [Fact]
    public void A_batch_with_no_expiry_date_is_sold_after_the_ones_that_have_one()
    {
        using var f = Shop();
        var item = Medicine(f);
        Receive(f, item, ("PLAIN", 10_000, null, null), ("DATED", 10_000, null, D(12, 31)));

        Sell(f, item, 10_000);

        Assert.Equal(0, Held(f, item, "DATED"));
        Assert.Equal(10_000, Held(f, item, "PLAIN"));
    }

    // ---- bringing goods back, cancelling, sending back -------------------------------------------------------------------------------------------------------

    [Fact]
    public void Goods_a_customer_brings_back_go_into_the_batches_they_came_out_of_in_the_order_they_were_taken()
    {
        using var f = Shop();
        var item = Medicine(f);
        Receive(f, item, ("A100", 100_000, null, D(12, 31)), ("B200", 50_000, null, D(11, 30)));
        var sale = Sell(f, item, 60_000);   // 50 from B200, 10 from A100

        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 30_000L) }, "wrong", "cash", null);
        Assert.Equal(30_000, Held(f, item, "B200"));
        Assert.Equal(90_000, Held(f, item, "A100"));

        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 30_000L) }, "more", "cash", null);   // 20 more fit in B200, the last 10 go to A100
        Assert.Equal(50_000, Held(f, item, "B200"));
        Assert.Equal(100_000, Held(f, item, "A100"));
        Assert.Equal(150_000, f.App.Catalog.OnHandMilli(item.Id));
    }

    [Fact]
    public void Cancelling_a_sale_puts_every_batch_back_as_it_was()
    {
        using var f = Shop();
        var item = Medicine(f);
        Receive(f, item, ("A100", 100_000, null, D(12, 31)), ("B200", 50_000, null, D(11, 30)));
        var sale = Sell(f, item, 60_000);

        f.App.Documents.Void(sale.Document.Id, "mistake", null);

        Assert.Equal(50_000, Held(f, item, "B200"));
        Assert.Equal(100_000, Held(f, item, "A100"));
    }

    [Fact]
    public void Goods_sent_back_to_the_supplier_leave_the_batch_they_came_in_and_cancelling_a_purchase_takes_its_batches_out()
    {
        using var f = Shop();
        var item = Medicine(f);
        var purchase = Receive(f, item, ("A100", 100_000, null, D(12, 31)));

        f.App.Documents.CreateDebitNote(purchase.Document.Id, new[] { (purchase.Lines[0].Id, 30_000L) }, "damaged", null, null);
        Assert.Equal(70_000, Held(f, item, "A100"));

        var other = Receive(f, item, ("B200", 20_000, null, D(11, 30)));
        f.App.Documents.Void(other.Document.Id, "wrong delivery", null);
        Assert.Equal(0, Held(f, item, "B200"));
        Assert.Equal(70_000, Held(f, item, "A100"));
    }

    // ---- money is worked out as before, and only shared among the batches ---------------------------------------------------------------------------------------

    [Fact]
    public void The_value_of_the_stock_is_the_same_with_batches_as_without_and_the_values_of_the_batches_add_up()
    {
        using var f = Shop();
        var kept = Medicine(f, "With batches", batches: true);
        var plain = Medicine(f, "Without", batches: false);
        var supplier = Supplier(f);
        foreach (var (item, no) in new[] { (kept, "A1"), (plain, (string?)null) })
        {
            var order = f.App.Purchasing.CreateOrder(supplier.Id, new[]
            {
                new PurchaseLine { ItemId = item.Id, QtyMilli = 7_000, CostMinor = 1_000, BatchNo = no is null ? null : "A1", ExpOn = D(11, 30) },
                new PurchaseLine { ItemId = item.Id, QtyMilli = 2_000, CostMinor = 1_001, BatchNo = no is null ? null : "B1", ExpOn = D(12, 31) },
            });
            f.App.Purchasing.Receive(order.Document.Id);
            Sell(f, item, 4_000);
        }

        var rows = f.App.Catalog.StockList().ToDictionary(r => r.Name);
        Assert.Equal(rows["Without"].OnHandMilli, rows["With batches"].OnHandMilli);
        Assert.Equal(rows["Without"].ValueMinor, rows["With batches"].ValueMinor);
        var moves = f.App.Db.Query("SELECT SUM(value_minor), SUM(qty_milli) FROM stock_moves WHERE item_id = $i", r => (Value: r.GetInt64(0), Qty: r.GetInt64(1)), ("$i", kept.Id)).Single();
        Assert.Equal((rows["With batches"].ValueMinor, 5_000L), moves);
    }

    // ---- counts, damage and switching batches on ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_count_or_damage_names_the_batch_and_a_count_that_finds_more_can_make_a_batch()
    {
        using var f = Shop(allowNegative: false);
        var item = Medicine(f);
        Receive(f, item, ("A100", 10_000, null, D(12, 31)));

        Assert.Equal("batch-no", Assert.Throws<HubException>(() => f.App.Catalog.Adjust(item.Id, -1_000, "damaged")).Code);
        Assert.Equal("batch-none", Assert.Throws<HubException>(() => f.App.Catalog.Adjust(item.Id, -1_000, "damaged", batchNo: "NOPE")).Code);
        Assert.Equal("stock", Assert.Throws<HubException>(() => f.App.Catalog.Adjust(item.Id, -11_000, "damaged", batchNo: "A100")).Code);

        f.App.Catalog.Adjust(item.Id, -2_000, "damaged", batchNo: "A100");
        f.App.Catalog.Adjust(item.Id, 3_000, "count", batchNo: "FOUND", expOn: D(11, 1));

        Assert.Equal(8_000, Held(f, item, "A100"));
        Assert.Equal(3_000, Held(f, item, "FOUND"));
        Assert.Equal(11_000, f.App.Catalog.OnHandMilli(item.Id));
    }

    [Fact]
    public void An_expired_batch_can_be_written_off_even_though_it_cannot_be_sold()
    {
        using var f = Shop(allowNegative: false);
        var item = Medicine(f);
        Receive(f, item, ("OLD", 10_000, null, D(9, 1)));

        f.App.Catalog.Adjust(item.Id, -10_000, "damaged", "expired", batchNo: "OLD");

        Assert.Equal(0, f.App.Catalog.OnHandMilli(item.Id));
    }

    [Fact]
    public void Switching_batches_on_for_an_item_that_has_stock_puts_that_stock_into_one_first_batch_and_changes_no_total()
    {
        using var f = Shop();
        var item = Medicine(f, batches: false);
        f.App.Catalog.Adjust(item.Id, 12_000, "opening stock");
        var before = f.App.Catalog.StockList().Single();

        f.App.Catalog.Update(item.Id, new ItemInput { Kind = "stock", Name = item.Name, PriceMinor = item.PriceMinor, TaxClass = "zero", TrackStock = true, TrackBatches = true });

        var after = f.App.Catalog.StockList().Single();
        Assert.Equal((before.OnHandMilli, before.ValueMinor), (after.OnHandMilli, after.ValueMinor));
        var opening = Assert.Single(f.App.Batches.ForItem(item.Id));
        Assert.Equal(("OPENING", 12_000L), (opening.BatchNo, opening.OnHandMilli));
        Assert.True(f.App.Catalog.Get(item.Id)!.TrackBatches);
        // a change made without saying anything about batches leaves them on
        f.App.Catalog.Update(item.Id, new ItemInput { Kind = "stock", Name = "Renamed", PriceMinor = item.PriceMinor, TaxClass = "zero", TrackStock = true });
        Assert.True(f.App.Catalog.Get(item.Id)!.TrackBatches);
    }

    [Fact]
    public void An_item_that_keeps_no_stock_cannot_keep_batches()
    {
        using var f = Shop();

        var item = f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Haircut", PriceMinor = 1_000, TaxClass = "zero", TrackBatches = true });

        Assert.False(item.TrackBatches);
    }

    // ---- looking at them ---------------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_expiry_list_shows_what_has_expired_and_what_is_about_to_with_how_many_days_are_left()
    {
        using var f = Shop();
        var item = Medicine(f);
        var other = Medicine(f, "Cough syrup");
        Receive(f, item, ("OLD", 5_000, null, D(10, 1)), ("SOON", 5_000, null, D(10, 20)), ("LATER", 5_000, null, D(12, 31)));
        Receive(f, other, ("S1", 3_000, null, D(10, 10)));
        Receive(f, other, ("EMPTY", 1_000, null, D(10, 8)));
        f.App.Catalog.Adjust(other.Id, -1_000, "damaged", batchNo: "EMPTY");

        var list = f.App.Batches.Expiring(30);

        Assert.Equal(new[] { "OLD", "S1", "SOON" }, list.Select(b => b.BatchNo).ToArray());   // empty batches and later ones are left out
        Assert.Equal("expired", list[0].State(30));
        Assert.Equal(5, list[1].DaysLeft);
        Assert.Equal("soon", list[1].State(30));
        Assert.Equal(new[] { "S1", "SOON" }, f.App.Batches.Expiring(30, includeExpired: false).Select(b => b.BatchNo).ToArray());
        Assert.Equal("ok", list.Concat(f.App.Batches.ForItem(item.Id)).First(b => b.BatchNo == "LATER").State(30));
    }

    [Fact]
    public void A_wrong_date_can_be_corrected_and_the_correction_is_kept()
    {
        using var f = Shop();
        var item = Medicine(f);
        Receive(f, item, ("A100", 5_000, D(1, 1), D(12, 31)));
        var batch = f.App.Batches.ForItem(item.Id).Single();

        Assert.Equal("batch-dates", Assert.Throws<HubException>(() => f.App.Batches.SetDates(batch.Id, D(5, 1), D(4, 1))).Code);
        f.App.Batches.SetDates(batch.Id, D(1, 1), D(11, 30));

        Assert.Equal(D(11, 30), f.App.Batches.ForItem(item.Id).Single().ExpOn);
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Batches.SetDates(9_999, null, null)).Code);
    }

    [Fact]
    public void A_bill_lists_the_batches_its_goods_came_from()
    {
        using var f = Shop();
        var item = Medicine(f);
        Receive(f, item, ("A100", 100_000, null, D(12, 31)), ("B200", 50_000, null, D(11, 30)));

        var sale = Sell(f, item, 60_000);

        var batches = f.App.Batches.OnBill(sale.Document.Id);
        Assert.Equal(new[] { ("B200", 50_000L), ("A100", 10_000L) }, batches.Select(b => (b.BatchNo, b.QtyMilli)).ToArray());
        Assert.Equal(D(11, 30), batches[0].ExpOn);
    }

    [Fact]
    public void The_search_finds_batches_by_item_name_or_number()
    {
        using var f = Shop();
        var item = Medicine(f);
        Receive(f, item, ("LOT-77", 5_000, null, D(12, 31)));

        Assert.Single(f.App.Batches.Search("para"));
        Assert.Single(f.App.Batches.Search("lot-7"));
        Assert.Empty(f.App.Batches.Search("zzz"));
    }
}

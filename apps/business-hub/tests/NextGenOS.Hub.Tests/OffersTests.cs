using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Offers;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Offers, coupons and gift vouchers. The numbers K1 to K10 (coupons), G1 to G9 (gift vouchers) and D1 to D4, B1 to B4, Y1 to Y5 (discounts and free goods) are the older POS's worked
/// examples from docs/old-programs/02-masters-accounting-reports.md (A1.7 to A1.9). Where the Hub differs on purpose (the start day is tested, a gift voucher is tested against today, a
/// code is used when the bill is made and not before, free goods need the minimum, the offer that takes most off wins) the test says so, beside the older answer.
/// India, rupees (2 decimals), prices without tax unless a test says otherwise; "today" is 10 October 2026.
/// </summary>
public class OffersTests
{
    private static readonly DateTimeOffset Oct10 = new(2026, 10, 10, 6, 30, 0, TimeSpan.Zero);   // 12:00 in India

    private static HubFixture Shop(bool inclusive = false, bool loyalty = false) =>
        new("IN", "retail", s => { s.PricesIncludeTax = inclusive; s.LoyaltyOn = loyalty; s.LoyaltyDefaultMode = "none"; s.LoyaltyPointValueMilli = 500; }, now: Oct10);

    private static DateOnly D(int month, int day) => new(2026, month, day);

    private static Item Product(HubFixture f, string name, long priceMinor, bool track = false) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = priceMinor, TaxClass = "GST18", TrackStock = track });

    private static Party Customer(HubFixture f, string name = "Asha") => f.App.Parties.Create(new PartyInput { Kind = "customer", Name = name });

    private static LineInput Line(string name, long priceMinor, long qtyMilli = 1000) => new() { Description = name, UnitPriceMinor = priceMinor, QtyMilli = qtyMilli, TaxCode = "GST18" };

    private static DocumentView Sale(HubFixture f, long? party, params LineInput[] lines) => f.App.Documents.CreateDraft(new DraftOptions { PartyId = party, Lines = lines.ToList() });

    private static DocumentView Pay(HubFixture f, DocumentView draft) =>
        f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = draft.Document.PayableMinor } } });

    private static Voucher Coupon(HubFixture f, long partyId, long amountMinor = 10_000, DateOnly? from = null, DateOnly? to = null, bool enabled = true) =>
        f.App.Offers.GenerateCoupons(new[] { partyId }, amountMinor, from, to, enabled).Single();

    private static void Run(HubFixture f, string sql, params (string, object?)[] parameters) { using var c = f.App.Db.Open(); HubDb.Exec(c, sql, null, parameters); }

    private static string Fails(Action act) => Assert.Throws<HubException>(act).Code;

    // ---- D1 to D4: which percent a line gets ---------------------------------------------------------------------------------------------

    [Fact]
    public void D1_to_D4_the_customers_rate_wins_over_an_item_offer_and_they_never_add_up()
    {
        Assert.Equal((5_000L, "customer"), OffersService.ResolveLineDiscount(5_000, 10_000));     // D1: customer 5, item offer 10 -> 5
        Assert.Equal((10_000L, "offer"), OffersService.ResolveLineDiscount(0, 10_000));            // D2: the customer's discount is off -> the item offer
        Assert.Equal((0L, null), OffersService.ResolveLineDiscount(0, 0));                         // D3: nothing (the Hub has no discount of its own on an item; its price is its price)
        Assert.Equal((5_000L, "customer"), OffersService.ResolveLineDiscount(5_000, 0));           // D4
    }

    [Fact]
    public void A_line_gets_the_customers_rate_or_the_item_offer_unless_a_person_gave_a_discount()
    {
        using var f = Shop();
        var asha = Customer(f);
        var pen = Product(f, "Pen", 10_000);
        f.App.Offers.SetPartyDiscount(asha.Id, 5_000, true);
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.ItemPercent, ItemId = pen.Id, PctMilli = 10_000 });
        var line = new LineInput { ItemId = pen.Id };

        var d = Sale(f, asha.Id, line);
        Assert.Equal(5_000, d.Lines[0].DiscountPctMilli);
        Assert.Equal("customer", d.Lines[0].DiscountSource);
        Assert.Equal(11_210, d.Document.PayableMinor);                                              // 100.00 less 5% = 95.00, GST 18% = 17.10
        f.App.Offers.SetPartyDiscount(asha.Id, 5_000, false);                                       // D2
        Assert.Equal(10_000, Sale(f, asha.Id, line).Lines[0].DiscountPctMilli);
        Assert.Equal((5_000L, false), f.App.Offers.PartyDiscount(asha.Id));                          // switched off, the percent is not lost
        Assert.Equal(10_000, Sale(f, null, line).Lines[0].DiscountPctMilli);                         // a walk-in gets the item offer
        var typed = Sale(f, null, new LineInput { ItemId = pen.Id, DiscountPctMilli = 2_000 }).Lines[0];
        Assert.Equal(2_000, typed.DiscountPctMilli);                                                // a discount a person gave is kept
        Assert.Null(typed.DiscountSource);

        // choosing the customer after the lines are in: the automatic ones follow, the typed one stays
        f.App.Offers.SetPartyDiscount(asha.Id, 5_000, true);
        d = Sale(f, null, line, new LineInput { ItemId = pen.Id, DiscountPctMilli = 2_000 });
        d = f.App.Documents.SetParty(d.Document.Id, asha.Id);
        Assert.Equal(5_000, d.Lines[0].DiscountPctMilli);
        Assert.Equal(2_000, d.Lines[1].DiscountPctMilli);
        // a cashier changing the discount takes it out of the automatic ones
        d = f.App.Documents.UpdateLine(d.Document.Id, d.Lines[0].Id, discountPctMilli: 3_000);
        Assert.Null(d.Lines[0].DiscountSource);
        d = f.App.Documents.SetParty(d.Document.Id, null);
        Assert.Equal(3_000, d.Lines[0].DiscountPctMilli);
    }

    [Fact]
    public void A_customers_rate_is_between_nothing_and_a_hundred_percent_and_a_removed_rate_is_gone()
    {
        using var f = Shop();
        var asha = Customer(f);
        Assert.Equal("discount", Fails(() => f.App.Offers.SetPartyDiscount(asha.Id, 100_001, true)));
        Assert.Equal("discount", Fails(() => f.App.Offers.SetPartyDiscount(asha.Id, -1, true)));
        Assert.Equal("party-not-found", Fails(() => f.App.Offers.SetPartyDiscount(9999, 5_000, true)));
        f.App.Offers.SetPartyDiscount(asha.Id, 5_000, true);
        f.App.Offers.SetPartyDiscount(asha.Id, 0, true);
        Assert.Equal((0L, false), f.App.Offers.PartyDiscount(asha.Id));
    }

    // ---- Y1 to Y5: buy so many, get so many free ------------------------------------------------------------------------------------------

    [Fact]
    public void Y1_to_Y5_the_free_quantity_and_the_days_an_offer_runs()
    {
        Assert.Equal(2_000, OffersService.FreeQtyMilli(7_000, 3_000, 1_000));      // Y1: buy 3 get 1, buy 7 -> 2 free
        Assert.Equal(0, OffersService.FreeQtyMilli(2_000, 3_000, 1_000));           // Y2: below the minimum
        Assert.Equal(4_000, OffersService.FreeQtyMilli(12_000, 5_000, 2_000));      // Y3: buy 5 get 2, buy 12 -> 4 free
        Assert.Equal(0, OffersService.FreeQtyMilli(2_000, 3_000, 5_000));           // Y4: the older POS gave 3 free when two scans were merged below the minimum; here: nothing
        Assert.Equal(5_000, OffersService.FreeQtyMilli(3_000, 3_000, 5_000));       //     at the minimum the free goods are given
        Assert.Equal(2_000, OffersService.FreeQtyMilli(7_500, 3_000, 1_000));       // weighed goods: whole free units only
        Assert.Equal(0, OffersService.FreeQtyMilli(7_000, 0, 1_000));
        Assert.Equal(0, OffersService.FreeQtyMilli(7_000, 3_000, 0));
        Assert.False(OffersService.InWindow(null, D(10, 9), D(10, 10)));            // Y5: over since yesterday
        Assert.True(OffersService.InWindow(null, D(10, 10), D(10, 10)));            //     today is the last good day
        Assert.True(OffersService.InWindow(D(10, 10), D(10, 10), D(10, 10)));       //     a one-day offer
        Assert.False(OffersService.InWindow(D(10, 11), null, D(10, 10)));           //     not started
        Assert.True(OffersService.InWindow(null, null, D(10, 10)));                 //     no limit at all
    }

    [Fact]
    public void Free_goods_are_a_line_of_their_own_that_follows_the_line_they_came_with_and_stock_goes_out_for_both()
    {
        using var f = Shop();
        var pen = Product(f, "Pen", 10_000, track: true);
        f.App.Catalog.Adjust(pen.Id, 100_000, "delivery");
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BuyGet, ItemId = pen.Id, MinQtyMilli = 3_000, FreeQtyMilli = 1_000 });

        var d = Sale(f, null, new LineInput { ItemId = pen.Id, QtyMilli = 7_000 });
        var id = d.Document.Id;
        Assert.Equal(2, d.Lines.Count);
        var free = d.Lines[1];
        Assert.True(free.IsFree);
        Assert.Equal(2_000, free.QtyMilli);
        Assert.Equal(100_000, free.DiscountPctMilli);
        Assert.Equal(d.Lines[0].Id, free.FreeForLineId);
        Assert.Equal(82_600, d.Document.PayableMinor);                                              // seven are paid for: 700.00 + 18%
        Assert.Equal("0.00", d.Result!.Lines[1].Taxable);                                           // the free ones carry no tax

        d = f.App.Documents.UpdateLine(id, d.Lines[0].Id, qtyMilli: 2_000);                           // below the minimum: no free goods
        Assert.Single(d.Lines);
        d = f.App.Documents.UpdateLine(id, d.Lines[0].Id, qtyMilli: 3_000);
        Assert.Equal(1_000, d.Lines[1].QtyMilli);
        Assert.Equal("free-line", Fails(() => f.App.Documents.RemoveLine(id, d.Lines[1].Id)));        // free goods go with the line they came with
        Assert.Equal("free-line", Fails(() => f.App.Documents.UpdateLine(id, d.Lines[1].Id, qtyMilli: 5_000)));
        d = f.App.Documents.RemoveLine(id, d.Lines[0].Id);
        Assert.Empty(d.Lines);

        var done = Pay(f, Sale(f, null, new LineInput { ItemId = pen.Id, QtyMilli = 7_000 }));
        Assert.Equal(100_000 - 9_000, f.App.Catalog.OnHandMilli(pen.Id));                           // nine pens left the shop, seven were paid for
        Assert.Equal(2, done.Lines.Count);
    }

    [Fact]
    public void An_offer_that_is_over_or_off_gives_nothing_and_an_item_has_one_free_goods_offer_running_at_a_time()
    {
        using var f = Shop();
        var pen = Product(f, "Pen", 10_000);
        var line = new LineInput { ItemId = pen.Id, QtyMilli = 6_000 };
        var over = f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BuyGet, ItemId = pen.Id, MinQtyMilli = 3_000, FreeQtyMilli = 1_000, ValidTo = D(10, 9) });
        Assert.Single(Sale(f, null, line).Lines);                                                     // over since yesterday
        f.App.Offers.SaveOffer(new OfferInput { Id = over.Id, Kind = OfferKinds.BuyGet, ItemId = pen.Id, MinQtyMilli = 3_000, FreeQtyMilli = 1_000, ValidTo = D(10, 10) });
        Assert.Equal(2, Sale(f, null, line).Lines.Count);                                             // today is its last day
        f.App.Offers.SetOfferEnabled(over.Id, false);
        Assert.Single(Sale(f, null, line).Lines);
        f.App.Offers.SetOfferEnabled(over.Id, true);
        // a second one for the same pen is refused while the first runs, as the older POS did
        Assert.Equal("offer-twice", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BuyGet, ItemId = pen.Id, MinQtyMilli = 5_000, FreeQtyMilli = 2_000 })));
        f.App.Offers.SetOfferEnabled(over.Id, false);
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BuyGet, ItemId = pen.Id, MinQtyMilli = 5_000, FreeQtyMilli = 2_000 });
        Assert.Equal(2, Sale(f, null, new LineInput { ItemId = pen.Id, QtyMilli = 5_000 }).Lines.Count);
    }

    [Fact]
    public void A_rule_that_does_not_make_sense_is_refused_in_plain_words()
    {
        using var f = Shop();
        var pen = Product(f, "Pen", 10_000);
        Assert.Equal("offer-dates", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.ItemPercent, ItemId = pen.Id, PctMilli = 5_000, ValidFrom = D(10, 9), ValidTo = D(10, 1) })));
        Assert.Equal("offer-percent", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.ItemPercent, ItemId = pen.Id, PctMilli = 0 })));
        Assert.Equal("offer-percent", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.ItemPercent, ItemId = pen.Id, PctMilli = 100_001 })));
        Assert.Equal("offer-item", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.ItemPercent, PctMilli = 5_000 })));
        Assert.Equal("offer-item", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.ItemPercent, ItemId = 9999, PctMilli = 5_000 })));
        Assert.Equal("offer-quantity", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BuyGet, ItemId = pen.Id, MinQtyMilli = 0, FreeQtyMilli = 1_000 })));
        Assert.Equal("offer-quantity", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BuyGet, ItemId = pen.Id, MinQtyMilli = 3_000, FreeQtyMilli = 0 })));
        Assert.Equal("offer-amount", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 1_000, AmountMinor = 0 })));
        Assert.Equal("offer-range", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 5_000, ToMinor = 1_000, AmountMinor = 100 })));
        Assert.Equal("offer-range", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.GiftRule, FromMinor = -1, AmountMinor = 100 })));
        Assert.Equal("offer-kind", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Kind = "surprise" })));
        var rule = f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 1_000, AmountMinor = 100 });
        Assert.Equal("offer-kind", Fails(() => f.App.Offers.SaveOffer(new OfferInput { Id = rule.Id, Kind = OfferKinds.GiftRule, FromMinor = 1_000, AmountMinor = 100 })));
        f.App.Offers.DeleteOffer(rule.Id);
        Assert.Null(f.App.Offers.GetOffer(rule.Id));
    }

    // ---- B1 to B4: money off a bill ----------------------------------------------------------------------------------------------------------

    [Fact]
    public void B1_and_B2_a_bill_that_comes_to_the_right_amount_gets_money_off_before_tax_and_the_cashier_can_leave_it_out()
    {
        using var f = Shop();
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, Name = "Spend 2,000", FromMinor = 200_000, ToMinor = 299_900, AmountMinor = 5_000 });
        var d = Sale(f, null, Line("Shirt", 250_000));                                                // B1: 2,500.00 is in 2,000 to 2,999
        var id = d.Document.Id;
        Assert.Equal(5_000, d.Document.OfferDiscountMinor);
        Assert.Equal(289_100, d.Document.PayableMinor);                                             // the tax falls with it: (2,500.00 - 50.00) + 18% = 2,891.00
        var shown = f.App.Offers.ForDocument(id);
        Assert.Equal("Spend 2,000", shown.Applied.Single().Label);
        Assert.Equal(5_000, shown.TotalMinor);

        d = f.App.Documents.SetOfferDeclined(id, true);                                               // B2: the cashier leaves it out
        Assert.Equal(0, d.Document.OfferDiscountMinor);
        Assert.Equal(295_000, d.Document.PayableMinor);
        shown = f.App.Offers.ForDocument(id);
        Assert.Empty(shown.Applied);
        Assert.Equal(5_000, shown.Declined!.AmountMinor);                                           // still on offer, to take after all
        d = f.App.Documents.SetOfferDeclined(id, false);
        Assert.Equal(289_100, d.Document.PayableMinor);

        // what the customer is told after the bill is made: a declined offer leaves no trace
        d = f.App.Documents.SetOfferDeclined(id, true);
        var done = Pay(f, d);
        Assert.Empty(f.App.Offers.ForDocument(done.Document.Id).Applied);
        Assert.Null(f.App.Offers.ForDocument(done.Document.Id).Declined);
    }

    [Fact]
    public void A_bill_offer_needs_the_bill_to_come_to_an_amount_inside_the_limits_on_a_day_it_runs_and_the_best_one_wins()
    {
        using var f = Shop();
        var small = f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 200_000, ToMinor = 299_900, AmountMinor = 5_000 });
        long Off(long priceMinor) => Sale(f, null, Line("Shirt", priceMinor)).Document.OfferDiscountMinor;
        Assert.Equal(0, Off(199_999));                    // 1,999.99: not enough
        Assert.Equal(5_000, Off(200_000));                // both ends count
        Assert.Equal(5_000, Off(299_900));
        Assert.Equal(0, Off(299_901));
        // no top: any bill from the bottom up
        f.App.Offers.SaveOffer(new OfferInput { Id = small.Id, Kind = OfferKinds.BillRange, FromMinor = 200_000, AmountMinor = 5_000 });
        Assert.Equal(5_000, Off(900_000));
        // two fit: the one that takes most off wins (the older POS took the first row the database gave back)
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 250_000, AmountMinor = 12_000, Name = "Big spender" });
        Assert.Equal(12_000, Off(260_000));
        Assert.Equal(5_000, Off(210_000));
        // an offer never takes off more than the bill comes to
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 1, AmountMinor = 999_999_999 });
        Assert.Equal(1_000, Off(1_000));
        // a switched-off rule and a rule from tomorrow do nothing
        foreach (var rule in f.App.Offers.Offers().ToList()) f.App.Offers.SetOfferEnabled(rule.Id, false);
        Assert.Equal(0, Off(260_000));
        var later = f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 1, AmountMinor = 500, ValidFrom = D(10, 11) });
        Assert.Equal(0, Off(260_000));
        f.App.Offers.SaveOffer(new OfferInput { Id = later.Id, Kind = OfferKinds.BillRange, FromMinor = 1, AmountMinor = 500, ValidFrom = D(10, 10) });
        Assert.Equal(500, Off(260_000));
    }

    [Fact]
    public void B3_and_B4_everything_that_takes_money_off_a_bill_adds_up()
    {
        using var f = Shop(loyalty: true);
        var asha = Customer(f);
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 200_000, ToMinor = 299_900, AmountMinor = 5_000 });             // offer 50.00
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.GiftRule, FromMinor = 100_000, ToMinor = 199_999, AmountMinor = 3_000 });             // a bill of 1,000 to 1,999 earns a 30.00 voucher
        var coupon = Coupon(f, asha.Id, 10_000);                                                                                                         // coupon 100.00
        var gift = f.App.Offers.ForDocument(Pay(f, Sale(f, asha.Id, Line("Lamp", 120_000))).Document.Id).Earned.Single();                              // 30.00 from an earlier bill
        Run(f, "INSERT INTO loyalty_ledger(party_id, at, kind, points_cent, memo, created_at) VALUES ($p, '2026-10-01T00:00:00Z', 'opening', 4000, 'start', '2026-10-01T00:00:00Z')", ("$p", asha.Id));   // 40 points = 20.00

        var d = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, BillDiscountMinor = 1_000, Lines = { Line("Shirt", 250_000) } });     // typed 10.00
        d = f.App.Documents.SetLoyaltyPoints(d.Document.Id, 4_000);
        d = f.App.Documents.ApplyCode(d.Document.Id, coupon.Code);
        d = f.App.Documents.ApplyCode(d.Document.Id, gift.Pretty.ToLowerInvariant());                                                                   // typed in small letters with the dash
        Assert.Equal(1_000, d.Document.BillDiscountMinor);
        Assert.Equal(2_000, d.Document.LoyaltyDiscountMinor);
        Assert.Equal(5_000 + 10_000 + 3_000, d.Document.OfferDiscountMinor);
        Assert.Equal("210.00", d.Result!.Totals.Discount);                                          // B3: 10 + 20 + 50 + 100 + 30
        Assert.Equal(270_220, d.Document.PayableMinor);                                             // (2,500.00 - 210.00) + 18%

        d = f.App.Documents.SetOfferDeclined(d.Document.Id, true);                                    // B4: without the offer
        d = f.App.Documents.RemoveCode(d.Document.Id, coupon.Id);
        d = f.App.Documents.RemoveCode(d.Document.Id, gift.Id);
        Assert.Equal("30.00", d.Result!.Totals.Discount);                                           // 10 + 20
    }

    [Fact]
    public void A_coupon_worth_more_than_the_bill_takes_the_bill_to_nothing_and_no_further()
    {
        using var f = Shop();
        var asha = Customer(f);
        var coupon = Coupon(f, asha.Id, 50_000);                                                    // 500.00
        var d = f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 8_000)).Document.Id, coupon.Code);
        Assert.Equal(0, d.Document.PayableMinor);
        Assert.Equal(0, d.Document.TaxMinor);
        var done = f.App.Documents.Issue(d.Document.Id);                                              // nothing to pay
        Assert.Equal("paid", done.Document.PaymentState);
        Assert.True(f.App.Offers.FindByCode(coupon.Code)!.Used);                                    // the whole coupon is used, as in the older POS
    }

    // ---- K1 to K10: coupons -------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void K1_and_K10_a_coupon_needs_an_amount_and_a_customer_and_each_customer_gets_a_code_of_their_own()
    {
        using var f = Shop();
        var asha = Customer(f);
        var ravi = Customer(f, "Ravi");
        Assert.Equal("coupon-amount", Fails(() => f.App.Offers.GenerateCoupons(new[] { asha.Id }, 0, null, null)));                      // K1
        Assert.Equal("coupon-customers", Fails(() => f.App.Offers.GenerateCoupons(Array.Empty<long>(), 5_000, null, null)));
        Assert.Equal("coupon-dates", Fails(() => f.App.Offers.GenerateCoupons(new[] { asha.Id }, 5_000, D(10, 9), D(10, 1))));
        Assert.Equal("party-not-found", Fails(() => f.App.Offers.GenerateCoupons(new[] { 9999L }, 5_000, null, null)));
        var made = f.App.Offers.GenerateCoupons(new[] { asha.Id, ravi.Id }, 5_000, D(10, 1), D(10, 31));                                    // K10
        Assert.Equal(2, made.Count);
        Assert.NotEqual(made[0].Code, made[1].Code);
        Assert.All(made, v =>
        {
            Assert.Equal(8, v.Code.Length);
            Assert.All(v.Code, ch => Assert.Contains(ch, "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"));
            Assert.Equal("ready", v.State(D(10, 10)));
            Assert.False(v.Used);
            Assert.Equal("coupon", v.Kind);
        });
        Assert.Equal(new[] { "Asha", "Ravi" }, made.Select(v => v.PartyName).ToArray());
        Assert.Equal(2, f.App.Offers.Vouchers("coupon").Count);
        Assert.Single(f.App.Offers.Vouchers(text: "Ravi"));
        Assert.Single(f.App.Offers.Vouchers(text: made[0].Pretty));
        Assert.Equal(made[0].Code, OffersService.Normalize(made[0].Pretty));
    }

    [Fact]
    public void K2_to_K8_a_code_is_refused_for_each_way_it_can_fail_and_the_first_failure_is_the_one_told()
    {
        using var f = Shop();
        var asha = Customer(f);
        string Try(Voucher v) => Fails(() => f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, v.Code));
        string Said(Voucher v) => Assert.Throws<HubException>(() => f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, v.Code)).Message;

        var expired = Coupon(f, asha.Id, from: D(10, 1), to: D(10, 9));                              // K2
        Assert.Equal("voucher-expired", Try(expired));
        Assert.Equal("That coupon ran out on 9 Oct 2026.", Said(expired));
        var lastDay = Coupon(f, asha.Id, from: D(10, 1), to: D(10, 10));                              // K3: the last day counts
        Assert.Equal(10_000, f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, lastDay.Code).Document.OfferDiscountMinor);
        var future = Coupon(f, asha.Id, from: D(10, 15), to: D(10, 20));                              // K4: the older POS let this through; the Hub does not
        Assert.Equal("voucher-waiting", Try(future));
        Assert.Equal("That coupon can be used from 15 Oct 2026.", Said(future));
        var used = Coupon(f, asha.Id);                                                                 // K5
        Run(f, "UPDATE vouchers SET used_at = '2026-10-09T10:00:00Z', used_document_id = 1 WHERE id = $id", ("$id", used.Id));
        Assert.Equal("voucher-used", Try(used));
        var off = Coupon(f, asha.Id, enabled: false);                                                  // K6
        Assert.Equal("voucher-off", Try(off));
        var all = Coupon(f, asha.Id, from: D(10, 1), to: D(10, 9), enabled: false);                    // K7: expired, used and switched off: "expired" is told
        Run(f, "UPDATE vouchers SET used_at = '2026-10-05T10:00:00Z', used_document_id = 1 WHERE id = $id", ("$id", all.Id));
        Assert.Equal("voucher-expired", Try(all));
        Assert.Equal("voucher-not-found", Fails(() => f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, "ZZZZ-ZZZZ")));   // K8
        Assert.Equal("voucher-code", Fails(() => f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, "  - ")));
        // the same code twice on one sale
        var one = Coupon(f, asha.Id);
        var d = f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, one.Code);
        Assert.Equal("voucher-twice", Fails(() => f.App.Documents.ApplyCode(d.Document.Id, one.Pretty)));
        // the states a shop sees in its list
        Assert.Equal(new[] { "expired", "ready", "waiting", "used", "off", "expired" }, new[] { expired, lastDay, future, used, off, all }.Select(v => f.App.Offers.FindByCode(v.Code)!.State(D(10, 10))).ToArray());
    }

    [Fact]
    public void K9_a_coupon_is_used_up_when_the_bill_is_made_not_when_it_is_tried_and_a_cancelled_bill_gives_it_back()
    {
        using var f = Shop();
        var asha = Customer(f);
        var coupon = Coupon(f, asha.Id, 10_000);
        var d = f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Shirt", 50_000)).Document.Id, coupon.Code);
        Assert.Equal(10_000, d.Document.OfferDiscountMinor);
        var applied = f.App.Offers.ForDocument(d.Document.Id).Applied.Single();
        Assert.Equal(coupon.Id, applied.VoucherId);
        Assert.Equal($"Coupon {coupon.Pretty}", applied.Label);
        Assert.Equal("ready", f.App.Offers.FindByCode(coupon.Code)!.State(D(10, 10)));              // only tried
        f.App.Documents.Discard(d.Document.Id);                                                      // the cashier cancels: in the older POS the coupon was burned here
        Assert.Equal("ready", f.App.Offers.FindByCode(coupon.Code)!.State(D(10, 10)));

        d = f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Shirt", 50_000)).Document.Id, coupon.Code);
        d = f.App.Documents.RemoveCode(d.Document.Id, coupon.Id);                                     // taken off again
        Assert.Equal(0, d.Document.OfferDiscountMinor);
        d = f.App.Documents.ApplyCode(d.Document.Id, coupon.Code);
        var done = Pay(f, d);
        var after = f.App.Offers.FindByCode(coupon.Code)!;
        Assert.True(after.Used);
        Assert.Equal(done.Document.Id, after.UsedDocumentId);
        Assert.Equal("voucher-used", Fails(() => f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Shirt", 50_000)).Document.Id, coupon.Code)));
        Assert.Equal("voucher-used", Fails(() => f.App.Offers.SetVoucherEnabled(coupon.Id, false)));   // a used code cannot be changed
        Assert.Equal(coupon.Pretty, f.App.Offers.ForDocument(done.Document.Id).Applied.Single().Label.Replace("Coupon ", ""));   // the finished bill still shows it

        f.App.Documents.Void(done.Document.Id, "wrong bill", null);                                   // the customer did not get the discount: the coupon is good again
        Assert.Equal("ready", f.App.Offers.FindByCode(coupon.Code)!.State(D(10, 10)));
    }

    [Fact]
    public void Two_sales_with_the_same_coupon_cannot_both_be_made_and_the_second_saves_nothing()
    {
        using var f = Shop();
        var asha = Customer(f);
        var coupon = Coupon(f, asha.Id);
        var first = f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, coupon.Code);
        var second = f.App.Documents.ApplyCode(Sale(f, null, Line("Pen", 50_000)).Document.Id, coupon.Code);      // another till, a moment later
        Pay(f, first);
        Assert.Equal("voucher-used", Fails(() => Pay(f, second)));
        var left = f.App.Documents.Get(second.Document.Id)!;
        Assert.Equal(DocStatus.Open, left.Document.Status);                                          // still being made
        Assert.Null(left.Document.Number);
        Assert.Empty(left.Payments);
    }

    [Fact]
    public void A_coupon_can_be_switched_off_and_on_until_it_is_used()
    {
        using var f = Shop();
        var asha = Customer(f);
        var coupon = Coupon(f, asha.Id);
        f.App.Offers.SetVoucherEnabled(coupon.Id, false);
        Assert.Equal("off", f.App.Offers.FindByCode(coupon.Code)!.State(D(10, 10)));
        f.App.Offers.SetVoucherEnabled(coupon.Id, true);
        Assert.Equal("ready", f.App.Offers.FindByCode(coupon.Code)!.State(D(10, 10)));
        Assert.Equal("not-found", Fails(() => f.App.Offers.SetVoucherEnabled(9999, true)));
    }

    // ---- G1 to G9: gift vouchers --------------------------------------------------------------------------------------------------------------

    [Fact]
    public void G1_to_G5_a_bill_that_falls_in_a_voucher_rule_earns_a_gift_voucher_for_a_named_customer()
    {
        using var f = Shop(inclusive: true);                                                          // prices include tax, so a bill comes to exactly its price
        var asha = Customer(f);
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.GiftRule, FromMinor = 100_000, ToMinor = 499_900, AmountMinor = 10_000, ValidFrom = D(10, 1), ValidTo = D(10, 31) });
        var earned = f.App.Offers.ForDocument(Pay(f, Sale(f, asha.Id, Line("Lamp", 250_000))).Document.Id).Earned;           // G1: 2,500.00
        var gift = Assert.Single(earned);
        Assert.Equal(10_000, gift.AmountMinor);
        Assert.Equal(8, gift.Code.Length);
        Assert.Equal((D(10, 1), D(10, 31)), (gift.ValidFrom!.Value, gift.ValidTo!.Value));
        Assert.Equal(asha.Id, gift.PartyId);
        Assert.Equal("gift", gift.Kind);
        Assert.Equal("ready", gift.State(D(10, 10)));
        Assert.Empty(f.App.Offers.ForDocument(Pay(f, Sale(f, null, Line("Lamp", 250_000))).Document.Id).Earned);              // G2: a walk-in gets none
        Assert.Empty(f.App.Offers.ForDocument(Pay(f, Sale(f, asha.Id, Line("Lamp", 99_999))).Document.Id).Earned);             // G3: 999.99 is below the rule
        Assert.Single(f.App.Offers.ForDocument(Pay(f, Sale(f, asha.Id, Line("Lamp", 499_900))).Document.Id).Earned);           // G4: the top counts
        Assert.Empty(f.App.Offers.ForDocument(Pay(f, Sale(f, asha.Id, Line("Lamp", 499_950))).Document.Id).Earned);            //     but 4,999.50 falls in the gap above it, as in the older POS: a shop leaves the top empty to cover it
        // G5: two rules fit: the bigger voucher is given
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.GiftRule, FromMinor = 200_000, AmountMinor = 25_000 });
        Assert.Equal(25_000, f.App.Offers.ForDocument(Pay(f, Sale(f, asha.Id, Line("Lamp", 300_000))).Document.Id).Earned.Single().AmountMinor);
        // a gift voucher is not earned by a quote
        var quote = f.App.Documents.SaveAsEstimate(Sale(f, asha.Id, Line("Lamp", 300_000)).Document.Id);
        Assert.Empty(f.App.Offers.ForDocument(quote.Document.Id).Earned);
    }

    [Fact]
    public void G6_to_G9_a_gift_voucher_is_tested_against_today_at_both_ends_and_is_used_once()
    {
        using var f = Shop();
        var asha = Customer(f);
        Voucher Gift(DateOnly? from, DateOnly? to)
        {
            Run(f, "INSERT INTO vouchers(kind, code, amount_minor, party_id, valid_from, valid_to, enabled, issued_at) VALUES ('gift', $c, 10000, $p, $vf, $vt, 1, '2026-10-01T00:00:00Z')",
                ("$c", "GIFT" + Guid.NewGuid().ToString("N")[..4].ToUpperInvariant()), ("$p", asha.Id), ("$vf", from?.ToString("yyyy-MM-dd")), ("$vt", to?.ToString("yyyy-MM-dd")));
            return f.App.Offers.Vouchers("gift").First();
        }
        string Try(Voucher v) => Fails(() => f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, v.Code));

        var october = Gift(D(10, 1), D(10, 31));
        f.Clock.Set(new DateTimeOffset(2026, 11, 20, 6, 30, 0, TimeSpan.Zero));                       // G6: the older POS accepted this one (its two dates are 30 days apart); here it ran out
        Assert.Equal("voucher-expired", Try(october));
        f.Clock.Set(new DateTimeOffset(2026, 10, 5, 6, 30, 0, TimeSpan.Zero));
        var oneDay = Gift(D(10, 5), D(10, 5));                                                         // G7: a one-day voucher: the older POS refused it even on its day
        Assert.Equal(10_000, f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, oneDay.Code).Document.OfferDiscountMinor);
        f.Clock.Set(new DateTimeOffset(2026, 10, 4, 6, 30, 0, TimeSpan.Zero));                        // the day before it starts
        Assert.Equal("voucher-waiting", Try(oneDay));
        f.Clock.Set(Oct10);
        var fresh = Gift(D(10, 1), D(10, 31));
        var done = Pay(f, f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, fresh.Code));      // G9: used when the bill is made
        Assert.Equal(done.Document.Id, f.App.Offers.FindByCode(fresh.Code)!.UsedDocumentId);
        Assert.Equal("voucher-used", Try(fresh));                                                      // G8
    }

    [Fact]
    public void Cancelling_a_bill_switches_off_the_gift_voucher_it_earned_unless_it_was_already_used()
    {
        using var f = Shop(inclusive: true);
        var asha = Customer(f);
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.GiftRule, FromMinor = 100_000, AmountMinor = 10_000 });
        var a = Pay(f, Sale(f, asha.Id, Line("Lamp", 150_000)));
        var giftA = f.App.Offers.ForDocument(a.Document.Id).Earned.Single();
        f.App.Documents.Void(a.Document.Id, "mistake", null);
        Assert.Equal("off", f.App.Offers.FindByCode(giftA.Code)!.State(D(10, 10)));
        Assert.Equal("voucher-off", Fails(() => f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, giftA.Code)));

        var b = Pay(f, Sale(f, asha.Id, Line("Lamp", 150_000)));
        var giftB = f.App.Offers.ForDocument(b.Document.Id).Earned.Single();
        Pay(f, f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Pen", 50_000)).Document.Id, giftB.Code));        // used on another bill
        f.App.Documents.Void(b.Document.Id, "mistake", null);
        Assert.True(f.App.Offers.FindByCode(giftB.Code)!.Used);                                      // what was already used cannot be taken back
    }

    // ---- quotes, returns, undoing -------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_quote_shows_the_bill_offer_and_the_free_goods_but_uses_no_code_and_the_bill_made_from_it_comes_to_the_same()
    {
        using var f = Shop();
        var asha = Customer(f);
        var pen = Product(f, "Pen", 10_000);
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BuyGet, ItemId = pen.Id, MinQtyMilli = 3_000, FreeQtyMilli = 1_000 });
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BillRange, FromMinor = 50_000, AmountMinor = 5_000 });
        var coupon = Coupon(f, asha.Id, 10_000);
        var draft = Sale(f, asha.Id, new LineInput { ItemId = pen.Id, QtyMilli = 8_000 });             // 800.00 and 2 free
        draft = f.App.Documents.ApplyCode(draft.Document.Id, coupon.Code);
        var quote = f.App.Documents.SaveAsEstimate(draft.Document.Id);
        Assert.Equal(5_000, quote.Document.OfferDiscountMinor);                                       // the offer; the coupon is not used for a quote
        Assert.Equal(2, quote.Lines.Count);
        Assert.Equal("ready", f.App.Offers.FindByCode(coupon.Code)!.State(D(10, 10)));
        Assert.Equal("not-open", Fails(() => f.App.Documents.ApplyCode(quote.Document.Id, coupon.Code)));             // a finished quote takes no code
        var bill = f.App.Documents.BillFromEstimate(quote.Document.Id);
        Assert.Equal(quote.Document.PayableMinor, bill.Document.PayableMinor);
        Assert.Equal(2, bill.Lines.Count);                                                             // the free goods are worked out again, not copied twice
        Assert.Equal(5_000, bill.Document.OfferDiscountMinor);
    }

    [Fact]
    public void Goods_returned_from_a_bill_that_had_a_coupon_give_back_only_what_was_paid_for_them()
    {
        using var f = Shop();
        var asha = Customer(f);
        var coupon = Coupon(f, asha.Id, 20_000);
        var sale = Pay(f, f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Rice", 100_000), Line("Oil", 100_000)).Document.Id, coupon.Code));
        Assert.Equal(212_400, sale.Document.PayableMinor);                                           // (2,000.00 - 200.00) + 18%
        var rice = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "wrong", "cash", null);
        var oil = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[1].Id, 1000L) }, "wrong", "cash", null);
        Assert.Equal(106_200, rice.Document.TotalMinor);                                             // each line carried half the coupon: (1,000.00 - 100.00) + 18%
        Assert.Equal(212_400, rice.Document.TotalMinor + oil.Document.TotalMinor);
    }

    [Fact]
    public void Goods_returned_from_a_bill_paid_partly_with_loyalty_points_give_back_only_what_was_paid_for_them()
    {
        using var f = Shop(loyalty: true);
        var asha = Customer(f);
        Run(f, "INSERT INTO loyalty_ledger(party_id, at, kind, points_cent, memo, created_at) VALUES ($p, '2026-10-01T00:00:00Z', 'opening', 40000, 'start', '2026-10-01T00:00:00Z')", ("$p", asha.Id));   // 400 points = 200.00
        var draft = f.App.Documents.SetLoyaltyPoints(Sale(f, asha.Id, Line("Rice", 100_000), Line("Oil", 100_000)).Document.Id, 40_000);
        var sale = Pay(f, draft);
        Assert.Equal(212_400, sale.Document.PayableMinor);
        var rice = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "wrong", "cash", null);
        Assert.Equal(106_200, rice.Document.TotalMinor);                                             // before this was fixed a returned line gave back its full price, 1,180.00
    }

    [Fact]
    public void The_words_on_a_gift_voucher_come_from_the_shops_own_setting_and_say_when_it_can_be_used()
    {
        using var f = Shop();
        var money = f.App.Shop.Current.Money;
        Voucher Gift(DateOnly? from, DateOnly? to) => new(1, "gift", "ABCD2345", 10_000, null, null, from, to, true, Oct10, null, null, null);
        var plain = new NextGenOS.Hub.Shop.ShopSettings().GiftVoucherText;
        Assert.Equal("Gift voucher ABCD-2345 worth ₹100.00. Show this code on your next visit. Valid from 1 Oct 2026 until 31 Oct 2026.", OffersService.GiftText(plain, Gift(D(10, 1), D(10, 31)), money));
        Assert.Contains("Valid until 31 Oct 2026.", OffersService.GiftText(plain, Gift(null, D(10, 31)), money));
        Assert.Contains("Valid from 1 Oct 2026.", OffersService.GiftText(plain, Gift(D(10, 1), null), money));
        Assert.Contains("Valid any day.", OffersService.GiftText(plain, Gift(null, null), money));
        // another shop, another words: nothing of the default stays
        Assert.Equal("Present ABCD-2345 for ₹100.00 (any day)", OffersService.GiftText("Present {code} for {amount} ({valid})", Gift(null, null), money));
        // and the bill prints what the setting says
        var settings = f.App.Shop.Current.Settings;
        settings.GiftVoucherText = "Voucher {code}";
        f.App.Shop.Save(settings);
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.GiftRule, FromMinor = 1, AmountMinor = 10_000 });
        var earned = f.App.Offers.ForDocument(Pay(f, Sale(f, Customer(f).Id, Line("Lamp", 50_000))).Document.Id).Earned.Single();
        Assert.Equal($"Voucher {earned.Pretty}", OffersService.GiftText(f.App.Shop.Current.Settings.GiftVoucherText, earned, f.App.Shop.Current.Money));
    }

    [Fact]
    public void The_offers_step_can_be_undone_and_done_again_and_the_bills_stay()
    {
        using var f = Shop();
        var asha = Customer(f);
        var coupon = Coupon(f, asha.Id, 10_000);
        var sale = Pay(f, f.App.Documents.ApplyCode(Sale(f, asha.Id, Line("Shirt", 50_000)).Document.Id, coupon.Code));
        var path = f.App.Db.Path;
        f.App.Db.Rollback(8);
        foreach (var table in new[] { "offers", "vouchers", "document_offers", "party_discounts" })
            Assert.Empty(f.App.Db.Query($"SELECT name FROM sqlite_master WHERE name = '{table}'", r => r.GetString(0)));
        Assert.DoesNotContain("offer_discount_minor", f.App.Db.Query("SELECT name FROM pragma_table_info('documents')", r => r.GetString(0)));
        Assert.DoesNotContain("free_for_line_id", f.App.Db.Query("SELECT name FROM pragma_table_info('document_lines')", r => r.GetString(0)));
        Assert.Equal(1L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE status = 'issued'")));
        var again = HubApp.Open(path, f.Clock);
        Assert.Contains("offer_discount_minor", again.Db.Query("SELECT name FROM pragma_table_info('documents')", r => r.GetString(0)));
        Assert.Equal(sale.Document.PayableMinor, again.Documents.Get(sale.Document.Id)!.Document.PayableMinor);
    }

    [Fact]
    public void Every_table_the_offers_step_adds_carries_the_shop_and_the_site()
    {
        using var f = Shop();
        foreach (var table in new[] { "offers", "vouchers", "document_offers", "party_discounts" })
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0));
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
        }
    }
}

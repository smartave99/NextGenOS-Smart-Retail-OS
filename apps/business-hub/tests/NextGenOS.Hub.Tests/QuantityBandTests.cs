using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Offers;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, products tools B: quantity discounts (study 02 A2.8, QD1 to QD6). The older program's rule is kept, with its probable bug fixed: a quantity that is in no band gets NO discount (the
/// older one gave it the largest band's discount). Shop in India, prices without tax in them, so the numbers are worked by hand: 7 at 100.00 with 5% off is 665.00, plus 18% tax 119.70.
/// </summary>
public class QuantityBandTests
{
    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static Item Product(HubFixture f, string name = "Rice", long priceMinor = 10_000) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = priceMinor, TaxClass = "standard", TrackStock = false });

    /// <summary>The older program's example: 5 to 9 give 5 percent, 10 and more give 10 percent (the study's bands 1 to 4 give 0, which is the same as no band).</summary>
    private static void FiveAndTen(HubFixture f, Item item)
    {
        f.App.Offers.AddBand(item.Id, 5_000, 9_999, 5_000);
        f.App.Offers.AddBand(item.Id, 10_000, null, 10_000);
    }

    private static DocLine OnlyLine(HubFixture f, long documentId) => Assert.Single(f.App.Documents.Get(documentId)!.Lines);

    // ---- the rule: QD1 to QD6 ------------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(3_000, 0L, "QD1: below the first band")]
    [InlineData(7_000, 5_000L, "QD2: inside the 5 percent band")]
    [InlineData(10_000, 10_000L, "QD3: exactly the start of the top band")]
    [InlineData(500, 0L, "QD5: half a unit is below every band")]
    [InlineData(4_999, 0L, "just below the first band")]
    [InlineData(9_999, 5_000L, "the last thousandth of the first band")]
    [InlineData(1_000_000, 10_000L, "a band with no top has no end")]
    public void The_band_a_quantity_falls_in_gives_its_percent_and_a_quantity_in_no_band_gives_none(long qtyMilli, long expected, string why)
    {
        var bands = new[] { new QtyBand(1, 1, 5_000, 9_999, 5_000), new QtyBand(2, 1, 10_000, null, 10_000) };

        Assert.True(expected == OffersService.BandPctMilli(bands, qtyMilli), why);
    }

    [Fact]
    public void QD4_a_quantity_above_the_top_of_the_last_band_gets_nothing_where_the_older_program_gave_the_largest_discount()
    {
        var bands = new[] { new QtyBand(1, 1, 1_000, 4_000, 1_000), new QtyBand(2, 1, 5_000, 9_000, 5_000), new QtyBand(3, 1, 10_000, 999_000, 10_000) };

        Assert.Equal(0, OffersService.BandPctMilli(bands, 1_000_000));   // the older program: 10 percent (the largest of all the bands)
    }

    [Fact]
    public void QD6_an_item_with_no_bands_gets_no_band_discount()
    {
        Assert.Equal(0, OffersService.BandPctMilli(Array.Empty<QtyBand>(), 7_000));
    }

    // ---- making bands ----------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Bands_are_listed_smallest_quantity_first_and_can_be_taken_away()
    {
        using var f = Shop();
        var rice = Product(f);
        f.App.Offers.AddBand(rice.Id, 10_000, null, 10_000);
        var first = f.App.Offers.AddBand(rice.Id, 5_000, 9_999, 5_000);

        Assert.Equal(new[] { 5_000L, 10_000L }, f.App.Offers.Bands(rice.Id).Select(b => b.MinQtyMilli).ToArray());
        f.App.Offers.RemoveBand(first.Id);
        Assert.Equal(10_000L, Assert.Single(f.App.Offers.Bands(rice.Id)).MinQtyMilli);
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "band-add" && a.EntityId == rice.Id);
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "band-remove" && a.EntityId == rice.Id);
    }

    [Theory]
    [InlineData(0L, 5_000L, 5_000L, "band-from")]
    [InlineData(5_000L, 4_000L, 5_000L, "band-to")]
    [InlineData(5_000L, 9_000L, 0L, "band-percent")]
    [InlineData(5_000L, 9_000L, 100_001L, "band-percent")]
    public void A_band_that_makes_no_sense_is_refused_in_plain_words(long from, long to, long pct, string code)
    {
        using var f = Shop();
        var rice = Product(f);

        var ex = Assert.Throws<HubException>(() => f.App.Offers.AddBand(rice.Id, from, to, pct));

        Assert.Equal(code, ex.Code);
        Assert.Empty(f.App.Offers.Bands(rice.Id));
    }

    [Fact]
    public void Two_bands_may_not_cover_the_same_quantity_but_neighbours_are_fine()
    {
        using var f = Shop();
        var rice = Product(f);
        f.App.Offers.AddBand(rice.Id, 5_000, 9_000, 5_000);

        f.App.Offers.AddBand(rice.Id, 9_001, 20_000, 7_000);      // starts just after the first one ends
        f.App.Offers.AddBand(rice.Id, 1_000, 4_999, 1_000);       // ends just before the first one starts
        foreach (var (from, to) in new (long, long?)[] { (9_000, 9_500), (6_000, 7_000), (4_000, 5_000), (20_000, null), (15_000, 30_000), (1_000, null) })
            Assert.Equal("band-overlap", Assert.Throws<HubException>(() => f.App.Offers.AddBand(rice.Id, from, to, 2_000)).Code);
        Assert.Equal(3, f.App.Offers.Bands(rice.Id).Count);
    }

    [Fact]
    public void A_band_for_an_item_that_does_not_exist_and_taking_away_a_band_that_does_not_exist_are_refused()
    {
        using var f = Shop();

        Assert.Equal("band-item", Assert.Throws<HubException>(() => f.App.Offers.AddBand(9_999, 5_000, null, 5_000)).Code);
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Offers.RemoveBand(9_999)).Code);
    }

    // ---- at the till -------------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_line_gets_the_discount_of_its_band_and_works_it_out_again_when_the_quantity_changes()
    {
        using var f = Shop();
        var rice = Product(f);
        FiveAndTen(f, rice);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 3_000 } } });
        var line = OnlyLine(f, draft.Document.Id);
        Assert.Equal((0L, (string?)null), (line.DiscountPctMilli, line.DiscountSource));

        f.App.Documents.UpdateLine(draft.Document.Id, line.Id, qtyMilli: 7_000);
        var seven = OnlyLine(f, draft.Document.Id);
        Assert.Equal((5_000L, "band"), (seven.DiscountPctMilli, seven.DiscountSource));

        f.App.Documents.UpdateLine(draft.Document.Id, line.Id, qtyMilli: 12_000);
        Assert.Equal(10_000, OnlyLine(f, draft.Document.Id).DiscountPctMilli);

        f.App.Documents.UpdateLine(draft.Document.Id, line.Id, qtyMilli: 4_000);   // back below every band: the discount goes
        var back = OnlyLine(f, draft.Document.Id);
        Assert.Equal((0L, (string?)null), (back.DiscountPctMilli, back.DiscountSource));
    }

    [Fact]
    public void A_line_added_with_a_quantity_already_in_a_band_gets_the_discount_at_once_and_the_money_is_right()
    {
        using var f = Shop();
        var rice = Product(f);
        FiveAndTen(f, rice);

        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 7_000 } } });
        var bill = f.App.Documents.Get(draft.Document.Id)!;

        // 7 x 100.00 = 700.00, 5% off = 35.00, 665.00; tax 18% of 665.00 = 119.70; total 784.70
        Assert.Equal((5_000L, "band"), (bill.Lines[0].DiscountPctMilli, bill.Lines[0].DiscountSource));
        Assert.Equal((66_500L, 11_970L, 78_470L), (bill.Document.SubtotalMinor, bill.Document.TaxMinor, bill.Document.TotalMinor));
    }

    [Fact]
    public void A_discount_a_person_typed_is_never_replaced_by_a_band_when_the_quantity_changes()
    {
        using var f = Shop();
        var rice = Product(f);
        FiveAndTen(f, rice);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 7_000, DiscountPctMilli = 2_000 } } });
        var line = OnlyLine(f, draft.Document.Id);
        Assert.Equal((2_000L, (string?)null), (line.DiscountPctMilli, line.DiscountSource));

        f.App.Documents.UpdateLine(draft.Document.Id, line.Id, qtyMilli: 12_000);

        Assert.Equal(2_000, OnlyLine(f, draft.Document.Id).DiscountPctMilli);
    }

    [Fact]
    public void A_customers_standing_discount_and_an_item_offer_come_before_a_band_and_never_add_to_it()
    {
        using var f = Shop();
        var rice = Product(f);
        var tea = Product(f, "Tea");
        FiveAndTen(f, rice);
        FiveAndTen(f, tea);
        var asha = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" });
        f.App.Offers.SetPartyDiscount(asha.Id, 3_000, true);
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.ItemPercent, ItemId = tea.Id, PctMilli = 4_000 });

        var forAsha = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 12_000 } } });
        var walkIn = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = tea.Id, QtyMilli = 12_000 } } });

        var a = OnlyLine(f, forAsha.Document.Id);
        var w = OnlyLine(f, walkIn.Document.Id);
        Assert.Equal((3_000L, "customer"), (a.DiscountPctMilli, a.DiscountSource));   // not 10 and not 13
        Assert.Equal((4_000L, "offer"), (w.DiscountPctMilli, w.DiscountSource));
    }

    [Fact]
    public void A_bill_that_was_made_keeps_what_a_band_gave_it_when_the_band_is_taken_away()
    {
        using var f = Shop();
        var rice = Product(f);
        FiveAndTen(f, rice);
        var bill = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 7_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 1_000_000 } } });
        var total = bill.Document.TotalMinor;

        foreach (var band in f.App.Offers.Bands(rice.Id)) f.App.Offers.RemoveBand(band.Id);

        var after = f.App.Documents.Get(bill.Document.Id)!;
        Assert.Equal(total, after.Document.TotalMinor);
        Assert.Equal(5_000, after.Lines[0].DiscountPctMilli);
        var next = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 7_000 } } });
        Assert.Equal(0, OnlyLine(f, next.Document.Id).DiscountPctMilli);
    }

    [Fact]
    public void Changing_the_customer_of_a_bill_works_the_bands_out_again()
    {
        using var f = Shop();
        var rice = Product(f);
        FiveAndTen(f, rice);
        var asha = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" });
        f.App.Offers.SetPartyDiscount(asha.Id, 3_000, true);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 12_000 } } });
        Assert.Equal((10_000L, "band"), (OnlyLine(f, draft.Document.Id).DiscountPctMilli, OnlyLine(f, draft.Document.Id).DiscountSource));

        f.App.Documents.SetParty(draft.Document.Id, asha.Id);

        var line = OnlyLine(f, draft.Document.Id);
        Assert.Equal((3_000L, "customer"), (line.DiscountPctMilli, line.DiscountSource));
    }
}

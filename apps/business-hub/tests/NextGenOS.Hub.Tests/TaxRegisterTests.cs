using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;
using NextGenOS.Hub.Reports;
using NextGenOS.Tax;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The tax registers and the lists a country's tax return is made from (docs/old-programs/03-india-tax-and-staff.md, A2 to A4; R1 to R11, G1 to G12). They are read from what each bill stored, so they agree with the bills
/// by construction; the tests check the classification (which bill goes in which list, by the pack's rules), the "other" column, the buyer's number as it was on the bill, and the summary by code.
/// India, shop in state 27, rupees (2 decimals). Where the Hub differs from the older program on purpose (the bill discount lowers the tax, the large-bill limit is the pack's, a return's taxable value is stored and not
/// worked back from its total) the test says so.
/// </summary>
public class TaxRegisterTests
{
    private static readonly DateOnly Today = new(2026, 10, 5);

    private static HubFixture Shop(bool inclusive = false, bool roundTotal = false, bool registered = true) =>
        new("IN", "retail", s => { s.PricesIncludeTax = inclusive; s.RoundTotal = roundTotal; s.TaxRegistered = registered; });

    private static Party Buyer(HubFixture f, string name, string? taxId = null, string region = "27") =>
        f.App.Parties.Create(new PartyInput { Kind = "customer", Name = name, TaxId = taxId, Region = region });

    private static LineInput Line(string name, long priceMinor, string tax = "GST18", string? code = null, long qtyMilli = 1000) =>
        new() { Description = name, UnitPriceMinor = priceMinor, QtyMilli = qtyMilli, TaxCode = tax, ItemCode = code };

    private static DocumentView Sell(HubFixture f, long? party, params LineInput[] lines)
    {
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = party, Lines = lines.ToList() });
        return f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = draft.Document.PayableMinor } } });
    }

    private static IReadOnlyList<RegisterRow> Sales(HubFixture f) => f.App.TaxRegisters.Register(RegisterKinds.Sales, Today, Today);

    private static string[] In(IReadOnlyList<ReturnListResult> lists, string id) => lists.Single(l => l.Id == id).Rows.Select(r => r.Number).ToArray();

    // ---- the registers (R1 to R9) ----------------------------------------------------------------------------------------------------

    [Fact]
    public void R1_a_bill_is_a_row_with_its_taxable_value_each_tax_part_the_total_and_nothing_else()
    {
        using var f = Shop();
        var bill = Sell(f, Buyer(f, "Asha", "27AAPFU0939F1ZV").Id, Line("Shirt", 100_000));      // 1,000.00 and 18%
        var row = Assert.Single(Sales(f));
        Assert.Equal(bill.Document.Number, row.Number);
        Assert.Equal("bill", row.Kind);
        Assert.Equal("Asha", row.PartyName);
        Assert.Equal("27AAPFU0939F1ZV", row.PartyTaxId);
        Assert.Equal(100_000, row.TaxableMinor);
        Assert.Equal(new[] { ("CGST", 9_000L), ("SGST", 9_000L) }, row.Parts.ToArray());
        Assert.Equal(118_000, row.TotalMinor);
        Assert.Equal(0, row.OtherMinor);
        Assert.Equal(18_000, row.TaxMinor);
        Assert.Equal(Today, row.Day);
    }

    [Fact]
    public void R2_R3_R4_whatever_else_made_up_the_total_is_the_other_column_a_fee_a_round_off_and_the_bill_discount_is_not_in_it()
    {
        using var f = Shop(roundTotal: true);
        // R2: a freight fee that is not taxed (1,000.00 + 18% + 20.00 = 1,200.00)
        var fee = f.App.Documents.CreateDraft(new DraftOptions { Lines = { Line("Shirt", 100_000) }, Adjustments = { new TaxAdjustmentInput { Code = "freight", Kind = "fee", Label = "Freight", Amount = "20.00" } } });
        f.App.Documents.Issue(fee.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = fee.Document.PayableMinor } } });
        Assert.Equal(2_000, Sales(f).Single().OtherMinor);
        Assert.Equal(120_000, Sales(f).Single().TotalMinor);
        // R3: a bill discount lowers the tax too (decision 33), so it is not in the other column (the older program showed -50.00 there)
        var discounted = f.App.Documents.CreateDraft(new DraftOptions { BillDiscountMinor = 5_000, Lines = { Line("Shirt", 100_000) } });
        f.App.Documents.Issue(discounted.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = discounted.Document.PayableMinor } } });
        var second = Sales(f)[1];
        Assert.Equal(95_000, second.TaxableMinor);
        Assert.Equal(0, second.OtherMinor);
        // R4: rounded to the rupee: taxable 890.23 + 160.24 tax = 1,050.47, grand total 1,050.00, other -0.47
        var rounded = Sell(f, null, Line("Cloth", 89_023));
        Assert.Equal(105_000, rounded.Document.TotalMinor);
        Assert.Equal(-47, Sales(f)[2].OtherMinor);
    }

    [Fact]
    public void R5_R6_a_credit_note_has_the_taxable_value_it_stored_not_one_worked_back_from_its_total()
    {
        using var f = Shop(roundTotal: true);
        var bill = Sell(f, Buyer(f, "Asha", "27AAPFU0939F1ZV").Id, Line("Cloth", 89_023));
        var note = f.App.Documents.CreateCreditNote(bill.Document.Id, new[] { (bill.Lines[0].Id, 1000L) }, "wrong colour", "cash", null);
        var row = Assert.Single(f.App.TaxRegisters.Register(RegisterKinds.Credits, Today, Today));
        Assert.Equal(note.Document.Number, row.Number);
        Assert.Equal("credit", row.Kind);
        Assert.Equal(89_023, row.TaxableMinor);                                  // the older program worked 500.00 back from a 590.00 total and got 500.00 for a true 499.67 (R6)
        Assert.Equal("27AAPFU0939F1ZV", row.PartyTaxId);
        Assert.Equal(note.Document.TotalMinor - row.TaxableMinor - row.TaxMinor, row.OtherMinor);
    }

    [Fact]
    public void R7_R8_a_purchase_is_listed_once_with_its_total_and_nothing_of_what_was_owed_before()
    {
        using var f = Shop();
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Mill Co", TaxId = "29ABCDE1234F1Z5", Region = "29" });
        var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 5_000, TaxClass = "GST5", TrackStock = true });
        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 100_000, CostMinor = 5_000 }, new PurchaseLine { ItemId = rice.Id, QtyMilli = 20_000, CostMinor = 5_000 } });
        f.App.Purchasing.Receive(order.Document.Id);
        var row = Assert.Single(f.App.TaxRegisters.Register(RegisterKinds.Purchases, Today, Today));       // two lines, one row (the older purchase-return register repeated the header for each line)
        Assert.Equal("purchase", row.Kind);
        Assert.Equal("Mill Co", row.PartyName);
        Assert.Equal("29ABCDE1234F1Z5", row.PartyTaxId);
        Assert.True(row.BetweenRegions);                                          // the supplier is in state 29, the shop in 27: IGST
        Assert.Equal("IGST", Assert.Single(row.Parts).Name);
        Assert.Equal(row.TaxableMinor + row.TaxMinor, row.TotalMinor);
        Assert.Equal(0, row.OtherMinor);
        Assert.Empty(Sales(f));                                                   // not in the sales register
    }

    [Fact]
    public void A_cancelled_bill_and_a_bill_of_another_day_are_not_in_the_register_and_the_day_is_the_shops_own()
    {
        using var f = Shop();
        var kept = Sell(f, null, Line("Shirt", 10_000));
        var cancelled = Sell(f, null, Line("Shirt", 20_000));
        f.App.Documents.Void(cancelled.Document.Id, "mistake", null);
        f.Clock.Advance(TimeSpan.FromDays(1));
        var tomorrow = Sell(f, null, Line("Shirt", 30_000));
        Assert.Equal(new[] { kept.Document.Number }, f.App.TaxRegisters.Register(RegisterKinds.Sales, Today, Today).Select(r => r.Number).ToArray());
        Assert.Equal(new[] { tomorrow.Document.Number }, f.App.TaxRegisters.Register(RegisterKinds.Sales, Today.AddDays(1), Today.AddDays(1)).Select(r => r.Number).ToArray());
        Assert.Equal(2, f.App.TaxRegisters.Register(RegisterKinds.Sales, Today, Today.AddDays(1)).Count);
        Assert.Equal("register", Assert.Throws<HubException>(() => f.App.TaxRegisters.Register("other", Today, Today)).Code);
    }

    [Fact]
    public void The_buyers_number_is_the_one_on_the_bill_when_it_was_made_and_changing_the_customer_later_changes_nothing_old()
    {
        using var f = Shop();
        var asha = Buyer(f, "Asha", "27AAPFU0939F1ZV");
        var bill = Sell(f, asha.Id, Line("Shirt", 10_000));
        f.App.Parties.Update(asha.Id, new PartyInput { Kind = "customer", Name = "Asha", TaxId = "24BBBBB1111B1Z1", Region = "24" });
        var row = Sales(f).Single();
        Assert.Equal("27AAPFU0939F1ZV", row.PartyTaxId);
        Assert.False(row.BetweenRegions);
        Assert.Equal("27AAPFU0939F1ZV", f.App.Documents.Get(bill.Document.Id)!.Document.PartyTaxId);
        // a bill made now has the new number and place
        var next = Sell(f, asha.Id, Line("Shirt", 10_000));
        Assert.Equal("24BBBBB1111B1Z1", f.App.Documents.Get(next.Document.Id)!.Document.PartyTaxId);
        Assert.True(Sales(f)[1].BetweenRegions);
        // choosing another customer on a bill still being made takes that customer's number; no customer clears it
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = asha.Id, Lines = { Line("Shirt", 10_000) } });
        draft = f.App.Documents.SetParty(draft.Document.Id, null);
        Assert.Null(draft.Document.PartyTaxId);
    }

    // ---- the lists of the return (G1 to G12) ------------------------------------------------------------------------------------------

    [Fact]
    public void G1_to_G5_each_bill_goes_in_the_first_list_whose_rule_it_meets_by_the_packs_limits()
    {
        using var f = Shop(inclusive: true);                                     // prices include tax: a bill comes to its price
        var registered = Buyer(f, "Registered Ltd", "27AAPFU0939F1ZV");
        var walkIn = Buyer(f, "Asha");
        var farWalkIn = Buyer(f, "Gujarat walk-in", null, "24");
        var farRegistered = Buyer(f, "Gujarat Ltd", "24BBBBB1111B1Z1", "24");
        var g1 = Sell(f, registered.Id, Line("Lamp", 500_000));                                  // G1: a buyer with a number -> B2B
        var big = Sell(f, farRegistered.Id, Line("Lamp", 500_000));                              //     a big bill to a buyer with a number between states is B2B, not B2CL: the first list that fits
        var g3 = Sell(f, walkIn.Id, Line("Lamp", 2_499_999));                   // G3: no number, a small bill in the shop's state -> B2CS
        var same = Sell(f, walkIn.Id, Line("Lamp", 15_000_000));                                 // G4: 150,000.00 in the shop's own state: the pack's limit applies only between states -> B2CS
        var g5 = Sell(f, farWalkIn.Id, Line("Lamp", 15_000_000));                                // G5: 150,000.00 between states to a buyer without a number -> B2CL (the older program said B2CS)
        var small = Sell(f, farWalkIn.Id, Line("Lamp", 9_000_000));                              //     90,000.00 between states: under the limit -> B2CS
        var edge = Sell(f, farWalkIn.Id, Line("Lamp", 10_000_000));                              //     exactly 100,000.00 is not over it -> B2CS
        var lists = f.App.TaxRegisters.ReturnLists(Today, Today);
        Assert.Equal(new[] { g1.Document.Number, big.Document.Number }, In(lists, "b2b"));
        Assert.Equal(new[] { g5.Document.Number }, In(lists, "b2cl"));
        Assert.Equal(new[] { g3.Document.Number, same.Document.Number, small.Document.Number, edge.Document.Number }, In(lists, "b2cs"));
        Assert.Equal(new[] { "b2b", "b2cl", "b2cs", "cdnr", "cdnur" }, lists.Select(l => l.Id).ToArray());
        Assert.All(lists, l => Assert.False(string.IsNullOrWhiteSpace(l.Label)));
    }

    [Fact]
    public void G6_G7_G8_a_credit_note_is_listed_on_the_day_it_was_given_by_whether_the_buyer_had_a_number_and_a_cancelled_bill_is_in_no_list()
    {
        using var f = Shop(inclusive: true);
        var registered = Buyer(f, "Registered Ltd", "27AAPFU0939F1ZV");
        var walkIn = Buyer(f, "Asha");
        var b2b = Sell(f, registered.Id, Line("Lamp", 500_000));
        var b2cs = Sell(f, walkIn.Id, Line("Lamp", 300_000));
        var gone = Sell(f, registered.Id, Line("Lamp", 100_000));
        f.App.Documents.Void(gone.Document.Id, "mistake", null);
        f.Clock.Advance(TimeSpan.FromDays(1));                                   // the returns are made the next day
        var n1 = f.App.Documents.CreateCreditNote(b2b.Document.Id, new[] { (b2b.Lines[0].Id, 1000L) }, "wrong", "cash", null);
        var n2 = f.App.Documents.CreateCreditNote(b2cs.Document.Id, new[] { (b2cs.Lines[0].Id, 1000L) }, "wrong", "cash", null);
        var day1 = f.App.TaxRegisters.ReturnLists(Today, Today);
        Assert.Empty(In(day1, "cdnr"));                                          // G6: it is the return's date that counts, not the bill's
        Assert.Equal(new[] { b2b.Document.Number }, In(day1, "b2b"));            //     (the cancelled bill is in no list)
        var day2 = f.App.TaxRegisters.ReturnLists(Today.AddDays(1), Today.AddDays(1));
        Assert.Equal(new[] { n1.Document.Number }, In(day2, "cdnr"));
        Assert.Equal(new[] { n2.Document.Number }, In(day2, "cdnur"));           // G7: a credit note to a buyer without a number, of any amount
        Assert.Empty(In(day2, "b2b"));
    }

    [Fact]
    public void A_shop_that_is_not_registered_for_the_tax_and_a_country_without_lists_have_no_lists_but_still_have_registers()
    {
        using (var unregistered = Shop(registered: false))
        {
            Sell(unregistered, null, Line("Shirt", 10_000));                     // G2: a bill with no tax charged is in no list
            Assert.False(unregistered.App.TaxRegisters.HasReturnLists);
            Assert.Empty(unregistered.App.TaxRegisters.ReturnLists(Today, Today));
            Assert.Single(unregistered.App.TaxRegisters.Register(RegisterKinds.Sales, Today, Today));
        }
        using var uk = new HubFixture("GB", "retail");
        Assert.Null(uk.App.Shop.Current.Country.Tax.Returns);
        Assert.False(uk.App.TaxRegisters.HasReturnLists);
        Assert.Empty(uk.App.TaxRegisters.ReturnLists(Today, Today));
        uk.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { Description = "Thing", UnitPriceMinor = 1_000, TaxCode = "VAT20" } }, Payments = { new PaymentInput { AmountMinor = 1_200 } } });
        Assert.Single(uk.App.TaxRegisters.Register(RegisterKinds.Sales, Today, Today));
    }

    [Fact]
    public void The_rule_of_a_list_names_only_what_it_asks_for()
    {
        var row = new RegisterRow(1, "X", Today, "bill", "A", null, "24", true, 150_000_00, 1, Array.Empty<(string, long)>(), 0, 0, true);
        Assert.True(TaxRegisterService.Meets(null, row, 2));
        Assert.True(TaxRegisterService.Meets(new ReturnWhen(), row, 2));
        Assert.True(TaxRegisterService.Meets(new ReturnWhen { PartyHasTaxId = false, BetweenRegions = true, TotalOver = "100000" }, row, 2));
        Assert.False(TaxRegisterService.Meets(new ReturnWhen { PartyHasTaxId = true }, row, 2));
        Assert.False(TaxRegisterService.Meets(new ReturnWhen { BetweenRegions = false }, row, 2));
        Assert.False(TaxRegisterService.Meets(new ReturnWhen { TotalOver = "150000" }, row, 2));        // the limit itself is not over it
        Assert.True(TaxRegisterService.Meets(new ReturnWhen { TotalOver = "149999.99" }, row, 2));
    }

    // ---- the summary by code (G9 to G12) ----------------------------------------------------------------------------------------------

    [Fact]
    public void G9_G10_G11_what_was_sold_is_summed_for_the_whole_period_by_code_and_rate_whether_it_was_sold_in_the_shops_state_or_beyond_it()
    {
        using var f = Shop();
        var near = Buyer(f, "Asha");
        var far = Buyer(f, "Gujarat Ltd", "24BBBBB1111B1Z1", "24");
        // G9: product A (code 1006, 5%): two lines on the same bill; product B has no code
        Sell(f, near.Id, Line("Rice", 5_000, "GST5", "1006", 2_000), Line("Rice", 5_000, "GST5", "1006", 3_000), Line("Thing", 10_000, "GST18", null));
        // G10: the same product the next day: one row for the period (the older summary had one row for each day)
        f.Clock.Advance(TimeSpan.FromDays(1));
        Sell(f, near.Id, Line("Rice", 5_000, "GST5", "1006", 1_000));
        // G11: the same product at the same rate between states: the same row, with IGST beside the CGST and SGST
        Sell(f, far.Id, Line("Rice", 5_000, "GST5", "1006", 1_000));
        var summary = f.App.TaxRegisters.CodesSold(Today, Today.AddDays(1));
        var row = Assert.Single(summary.Rows);
        Assert.Equal("1006", row.Code);
        Assert.Equal("GST5", row.TaxCode);
        Assert.Equal(7_000, row.QtyMilli);                                       // 2 + 3 + 1 + 1
        Assert.Equal(7 * 5_000, row.TaxableMinor);
        Assert.Equal(new[] { "CGST", "IGST", "SGST" }, row.Parts.Select(p => p.Name).OrderBy(x => x).ToArray());
        Assert.Equal(6 * 5_000 * 25 / 1000, row.Parts.Single(p => p.Name == "CGST").AmountMinor);               // 6 units in the shop's own state: 2.5% each of CGST and SGST
        Assert.Equal(1 * 5_000 * 5 / 100, row.Parts.Single(p => p.Name == "IGST").AmountMinor);                 // 1 unit between states: 5% IGST
        Assert.Equal(row.Parts.Sum(p => p.AmountMinor), row.TaxMinor);
        Assert.Equal(1, summary.LinesWithoutCode);                               // the line with no code is counted so it can be put right (the older list dropped it silently)
    }

    [Fact]
    public void A_credit_note_takes_its_goods_off_the_summary_and_a_country_without_an_item_code_has_no_summary()
    {
        using var f = Shop();
        var bill = Sell(f, null, Line("Rice", 5_000, "GST5", "1006", 5_000));
        f.App.Documents.CreateCreditNote(bill.Document.Id, new[] { (bill.Lines[0].Id, 2_000L) }, "damaged", "cash", null);
        var row = Assert.Single(f.App.TaxRegisters.CodesSold(Today, Today).Rows);
        Assert.Equal(3_000, row.QtyMilli);
        Assert.Equal(3 * 5_000, row.TaxableMinor);
        using var uk = new HubFixture("GB", "retail");
        Assert.Empty(uk.App.TaxRegisters.CodesSold(Today, Today).Rows);
    }

    // ---- the summary of supplies (T1 to T14) -------------------------------------------------------------------------------------------

    private static SummaryBlockResult Block(SupplySummary summary, string id) => summary.Blocks.Single(b => b.Id == id);

    [Fact]
    public void T1_to_T7_every_line_goes_in_the_block_of_its_own_rate_buyer_and_place_even_inside_one_bill()
    {
        using var f = Shop();
        var near = Buyer(f, "Asha");
        var farUnregistered = Buyer(f, "Gujarat walk-in", null, "24");
        var farRegistered = Buyer(f, "Gujarat Ltd", "24BBBBB1111B1Z1", "24");
        Sell(f, near.Id, Line("Shirt", 100_000));                                                    // T1: inside the state
        Sell(f, farUnregistered.Id, Line("Shirt", 100_000));                                         // T2: between states, no number
        Sell(f, farRegistered.Id, Line("Shirt", 100_000));                                           // T3: between states, with a number
        Sell(f, near.Id, Line("Bread", 50_000, "GST0"));                                              // T4: taxed at nil
        Sell(f, near.Id, Line("Shirt", 100_000), Line("Bread", 20_000, "GST0"));                      // T6: one bill, two kinds of line: the older program put all 1,200.00 in the taxed block
        Sell(f, farRegistered.Id, Line("Bread", 30_000, "GST0"));                                     // T7: nil between states: the state does not matter for a nil line
        Sell(f, near.Id, Line("Flour", 10_000, "GSTEX"));                                             //     an exempt line
        var summary = f.App.TaxRegisters.SupplySummary(Today, Today);

        var inside = Block(summary, "out-inside");
        Assert.Equal(2, inside.Lines);
        Assert.Equal(200_000, inside.ValueMinor);                                                    // T1 and the taxed line of T6
        Assert.Equal(new[] { ("CGST", 18_000L), ("SGST", 18_000L) }, inside.Parts.ToArray());
        var unregistered = Block(summary, "out-between-unreg");
        Assert.Equal(100_000, unregistered.ValueMinor);
        Assert.Equal(new[] { ("IGST", 18_000L) }, unregistered.Parts.ToArray());
        Assert.Equal(100_000, Block(summary, "out-between-reg").ValueMinor);
        var zero = Block(summary, "out-zero");
        Assert.Equal(3, zero.Lines);
        Assert.Equal(50_000 + 20_000 + 30_000, zero.ValueMinor);                                     // T4, the nil line of T6 and T7
        Assert.Empty(zero.Parts);
        Assert.Equal(10_000, Block(summary, "out-exempt").ValueMinor);
        Assert.Equal(0, summary.UnplacedLines);
        Assert.True(summary.Blocks.Where(b => b.Side == "inward").All(b => b.Lines == 0));
    }

    [Fact]
    public void T8_to_T13_purchases_go_in_the_inward_blocks_by_supplier_number_and_rate_and_a_nil_purchase_from_an_unregistered_supplier_is_not_lost()
    {
        using var f = Shop();
        var registered = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Mill Co", TaxId = "27AAPFU0939F1ZV", Region = "27" });
        var unregistered = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Farm", Region = "29" });
        var taxed = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 5_000, TaxClass = "GST5", TrackStock = false });
        var nil = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Fresh milk", PriceMinor = 5_000, TaxClass = "GST0", TrackStock = false });
        void Buy(long supplier, long item, long cost) => f.App.Purchasing.Receive(f.App.Purchasing.CreateOrder(supplier, new[] { new PurchaseLine { ItemId = item, QtyMilli = 10_000, CostMinor = cost } }).Document.Id);
        Buy(registered.Id, taxed.Id, 50_000);        // T8: from a supplier with a number
        Buy(unregistered.Id, taxed.Id, 40_000);      // T10: from a supplier without one (between states: IGST)
        Buy(registered.Id, nil.Id, 4_000);           // T11: nil from a supplier with a number
        Buy(unregistered.Id, nil.Id, 2_500);         // T12: nil from a supplier without a number: the older program had no block for it
        var summary = f.App.TaxRegisters.SupplySummary(Today, Today);
        Assert.Equal(500_000, Block(summary, "in-reg").ValueMinor);
        Assert.Equal(new[] { ("CGST", 12_500L), ("SGST", 12_500L) }, Block(summary, "in-reg").Parts.ToArray());
        Assert.Equal(400_000, Block(summary, "in-unreg").ValueMinor);
        Assert.Equal(new[] { ("IGST", 20_000L) }, Block(summary, "in-unreg").Parts.ToArray());
        Assert.Equal(40_000 + 25_000, Block(summary, "in-zero").ValueMinor);
        Assert.Equal(0, summary.UnplacedLines);
        Assert.All(summary.Blocks.Where(b => b.Side == "outward"), b => Assert.Equal(0, b.Lines));
    }

    [Fact]
    public void T14_goods_given_back_are_taken_off_the_same_block_a_cancelled_bill_is_not_counted_and_a_period_holds_only_its_own_days()
    {
        using var f = Shop();
        var near = Buyer(f, "Asha");
        var bill = Sell(f, near.Id, Line("Shirt", 100_000, "GST18", null, 3_000));                    // 3 shirts
        var cancelled = Sell(f, near.Id, Line("Shirt", 100_000));
        f.App.Documents.Void(cancelled.Document.Id, "mistake", null);
        f.App.Documents.CreateCreditNote(bill.Document.Id, new[] { (bill.Lines[0].Id, 1_000L) }, "size", "cash", null);   // one comes back
        var inside = Block(f.App.TaxRegisters.SupplySummary(Today, Today), "out-inside");
        Assert.Equal(200_000, inside.ValueMinor);                                                    // 3,000.00 less 1,000.00 (the older program did not net returns)
        Assert.Equal(new[] { ("CGST", 18_000L), ("SGST", 18_000L) }, inside.Parts.ToArray());
        Assert.Equal(0, Block(f.App.TaxRegisters.SupplySummary(Today.AddDays(1), Today.AddDays(5)), "out-inside").Lines);
    }

    [Fact]
    public void A_shop_that_is_not_registered_and_a_country_without_blocks_have_no_summary()
    {
        using (var unregistered = Shop(registered: false))
        {
            Sell(unregistered, null, Line("Shirt", 10_000));
            Assert.False(unregistered.App.TaxRegisters.HasSupplySummary);
            Assert.Empty(unregistered.App.TaxRegisters.SupplySummary(Today, Today).Blocks);
        }
        using var uk = new HubFixture("GB", "retail");
        Assert.Null(uk.App.Shop.Current.Country.Tax.Summary);
        Assert.Empty(uk.App.TaxRegisters.SupplySummary(Today, Today).Blocks);
    }

    [Fact]
    public void The_step_that_keeps_the_buyers_number_can_be_undone_and_done_again()
    {
        using var f = Shop();
        var asha = Buyer(f, "Asha", "27AAPFU0939F1ZV");
        var bill = Sell(f, asha.Id, Line("Shirt", 10_000));
        var path = f.App.Db.Path;
        f.App.Db.Rollback(10);
        Assert.DoesNotContain("party_tax_id", f.App.Db.Query("SELECT name FROM pragma_table_info('documents')", r => r.GetString(0)));
        var again = HubApp.Open(path, f.Clock);                                   // forward again: a bill made before the step gets the number its customer has now
        Assert.Equal("27AAPFU0939F1ZV", again.Documents.Get(bill.Document.Id)!.Document.PartyTaxId);
    }
}

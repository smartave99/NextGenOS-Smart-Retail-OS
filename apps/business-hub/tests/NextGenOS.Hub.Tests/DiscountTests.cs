using NextGenOS.Hub;
using NextGenOS.Hub.Documents;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Line discounts (percent or amount) and a discount on the whole bill, which is spread over the lines before tax so that the tax falls with it (decision 33).
/// The examples are the ones worked out from the older POS in docs/old-programs/01-selling-buying-stock.md (L2, L3, L4, L13, B1, B4); where the owner decided to differ
/// from the older POS (the bill discount lowers the tax) the numbers below are the new ones, worked by hand and written beside the old ones.
/// India, rupees (2 decimals), prices without tax unless a test says otherwise.
/// </summary>
public class DiscountTests
{
    private static HubFixture Shop(bool inclusive = false) => new("IN", "retail", s => s.PricesIncludeTax = inclusive);

    private static LineInput Line(string name, long priceMinor, long qtyMilli, string tax, long pctMilli = 0, long amountMinor = 0) =>
        new() { Description = name, UnitPriceMinor = priceMinor, QtyMilli = qtyMilli, TaxCode = tax, DiscountPctMilli = pctMilli, DiscountAmountMinor = amountMinor };

    private static DocumentView Draft(HubFixture f, long billAmount, long billPct, params LineInput[] lines) =>
        f.App.Documents.CreateDraft(new DraftOptions { BillDiscountMinor = billAmount, BillDiscountPctMilli = billPct, Lines = lines.ToList() });

    private static string Part(DocumentView v, string name) => v.Result!.Totals.Components.Single(c => c.Name == name).Amount;

    // ---- splitting an amount over lines ---------------------------------------------------------------------------------------------

    [Fact]
    public void An_amount_is_split_over_the_lines_in_whole_units_that_add_up_exactly()
    {
        Assert.Equal(new long[] { 4, 3, 3 }, DocumentService.Allocate(new long[] { 10, 10, 10 }, 10));         // the leftover unit goes to the first of equal fractions
        Assert.Equal(new long[] { 2632, 2368 }, DocumentService.Allocate(new long[] { 10000, 8999 }, 5000));    // the worked example below: the bigger fraction wins
        Assert.Equal(new long[] { 0, 5, 0 }, DocumentService.Allocate(new long[] { 0, 7, 0 }, 5));               // a line with nothing on it takes nothing
        Assert.Equal(new long[] { 3, 4 }, DocumentService.Allocate(new long[] { 3, 4 }, 99));                    // more than the lines come to: capped at what they come to
        Assert.Equal(new long[] { 0, 0 }, DocumentService.Allocate(new long[] { 3, 4 }, 0));
        Assert.Equal(new long[] { 0, 0 }, DocumentService.Allocate(new long[] { 0, 0 }, 10));
    }

    [Fact]
    public void However_the_numbers_fall_the_parts_add_up_and_no_line_gives_more_than_it_has()
    {
        var random = new Random(20261007);
        for (var round = 0; round < 2000; round++)
        {
            var weights = Enumerable.Range(0, random.Next(1, 9)).Select(_ => random.Next(0, 5) == 0 ? 0L : (long)random.Next(1, 2_000_000)).ToArray();
            var total = weights.Sum();
            var amount = total == 0 ? 0 : random.NextInt64(0, total + 1);
            var shares = DocumentService.Allocate(weights, amount);
            Assert.Equal(total == 0 ? 0L : amount, shares.Sum());
            for (var i = 0; i < shares.Length; i++) Assert.InRange(shares[i], 0, weights[i]);
        }
    }

    // ---- a line discount by amount or by percent -------------------------------------------------------------------------------------

    [Fact]
    public void L3_a_line_discount_given_as_an_amount_is_taken_off_before_tax()
    {
        using var f = Shop();
        // qty 2 at 250.00, 37.50 off, GST 12%: base 462.50, CGST 27.75, SGST 27.75, total 518.00 (the older POS gives the same)
        var v = Draft(f, 0, 0, Line("Shirt", 25_000, 2000, "GST12", amountMinor: 3_750));
        Assert.Equal("27.75", Part(v, "CGST"));
        Assert.Equal("27.75", Part(v, "SGST"));
        Assert.Equal(46_250, v.Document.SubtotalMinor);
        Assert.Equal(51_800, v.Document.PayableMinor);
        Assert.Equal("37.50", v.Result!.Lines[0].Discount);
    }

    [Fact]
    public void L2_and_L13_a_line_discount_given_as_a_percent_is_unchanged()
    {
        using var f = Shop();
        // L2: 3 x 33.33 less 10%, GST 18%: discount 10.00, CGST 8.10, SGST 8.10, total 106.19
        var l2 = Draft(f, 0, 0, Line("Pens", 3_333, 3000, "GST18", pctMilli: 10_000));
        Assert.Equal("10.00", l2.Result!.Lines[0].Discount);
        Assert.Equal("8.10", Part(l2, "CGST"));
        Assert.Equal(10_619, l2.Document.PayableMinor);
        // L13: 99.95 less 12.5%: discount 12.49, CGST 7.87, SGST 7.87, total 103.20
        var l13 = Draft(f, 0, 0, Line("Cup", 9_995, 1000, "GST18", pctMilli: 12_500));
        Assert.Equal("12.49", l13.Result!.Lines[0].Discount);
        Assert.Equal("7.87", Part(l13, "CGST"));
        Assert.Equal(10_320, l13.Document.PayableMinor);
    }

    [Fact]
    public void A_line_takes_one_kind_of_discount_and_cannot_be_given_more_than_it_comes_to()
    {
        using var f = Shop();
        var v = Draft(f, 0, 0, Line("Pens", 10_000, 1000, "GST18", pctMilli: 10_000));
        var id = v.Lines[0].Id;
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.UpdateLine(v.Document.Id, id, null, 5_000, discountAmountMinor: 200)).Code);
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.AddLine(v.Document.Id, Line("x", 100, 1000, "GST18", pctMilli: 1_000, amountMinor: 10))).Code);
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.UpdateLine(v.Document.Id, id, discountAmountMinor: 10_001)).Code);
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.UpdateLine(v.Document.Id, id, discountAmountMinor: -1)).Code);
        // giving an amount takes the percent off the line, and the other way round
        var asAmount = f.App.Documents.UpdateLine(v.Document.Id, id, discountAmountMinor: 2_500);
        Assert.Equal(0, asAmount.Lines[0].DiscountPctMilli);
        Assert.Equal(2_500, asAmount.Lines[0].DiscountAmountMinor);
        Assert.Equal("25.00", asAmount.Result!.Lines[0].Discount);
        var asPercent = f.App.Documents.UpdateLine(v.Document.Id, id, discountPctMilli: 5_000);
        Assert.Equal(0, asPercent.Lines[0].DiscountAmountMinor);
        Assert.Equal("5.00", asPercent.Result!.Lines[0].Discount);
        var none = f.App.Documents.UpdateLine(v.Document.Id, id, discountPctMilli: 0, discountAmountMinor: 0);
        Assert.Equal("0.00", none.Result!.Lines[0].Discount);
        // the amount may not outgrow the line when the quantity is lowered
        f.App.Documents.UpdateLine(v.Document.Id, id, discountAmountMinor: 9_000);
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.UpdateLine(v.Document.Id, id, qtyMilli: 500)).Code);
        Assert.Equal(1000, f.App.Documents.Get(v.Document.Id)!.Lines[0].QtyMilli);
    }

    // ---- a discount on the whole bill -----------------------------------------------------------------------------------------------

    [Fact]
    public void B4_a_bill_discount_is_spread_before_tax_so_the_tax_falls_with_it()
    {
        using var f = Shop();
        var lines = new[] { Line("Rice", 10_000, 1000, "GST18"), Line("Pens", 3_333, 3000, "GST18", pctMilli: 10_000) };
        // The two lines alone (B1): taxable 189.99, CGST 17.10, SGST 17.10, total 224.19.
        var plain = Draft(f, 0, 0, lines);
        Assert.Equal(22_419, plain.Document.PayableMinor);
        // 50.00 off the bill. The older POS took 50.00 off after tax, left the tax at 34.20 and gave 174.19.
        // Here the 50.00 is shared 26.32 and 23.68 over the two lines (the lines come to 100.00 and 89.99), tax is worked out on what is left:
        //   rice   100.00 - 26.32 = 73.68  CGST 6.63 SGST 6.63
        //   pens    99.99 - 10.00 - 23.68 = 66.31  CGST 5.97 SGST 5.97
        // total 73.68 + 66.31 + 2 x 6.63 + 2 x 5.97 = 165.19 (= 224.19 - 50.00 x 1.18, the discount and its tax)
        var v = Draft(f, 5_000, 0, lines);
        Assert.Equal("26.32", v.Result!.Lines[0].Discount);
        Assert.Equal("33.68", v.Result.Lines[1].Discount);
        Assert.Equal(13_999, v.Document.SubtotalMinor);
        Assert.Equal("12.60", Part(v, "CGST"));
        Assert.Equal("12.60", Part(v, "SGST"));
        Assert.Equal(16_519, v.Document.PayableMinor);
        Assert.Equal(5_000, v.Document.BillDiscountMinor);
        Assert.Equal("60.00", v.Result.Totals.Discount); // the line discount 10.00 and the bill discount 50.00
    }

    [Fact]
    public void A_bill_discount_as_a_percent_is_worked_on_what_the_lines_come_to_after_their_own_discounts()
    {
        using var f = Shop();
        var lines = new[] { Line("Rice", 10_000, 1000, "GST18"), Line("Pens", 3_333, 3000, "GST18", pctMilli: 10_000) };
        var v = Draft(f, 0, 10_000, lines);                 // 10% of 189.99 = 19.00
        Assert.Equal("29.00", v.Result!.Totals.Discount);  // 10.00 on the pens already, 19.00 on the bill
        Assert.Equal(17_099, v.Document.SubtotalMinor);
        // asking again with an amount replaces the percent
        var again = f.App.Documents.SetBillDiscount(v.Document.Id, 5_000, 0);
        Assert.Equal(0, again.Document.BillDiscountPctMilli);
        Assert.Equal(16_519, again.Document.PayableMinor);
        var off = f.App.Documents.SetBillDiscount(v.Document.Id, 0, 0);
        Assert.Equal(22_419, off.Document.PayableMinor);
        Assert.False(off.Document.HasBillDiscount);
    }

    [Fact]
    public void A_bill_discount_follows_the_lines_when_they_change_and_cannot_be_more_than_the_bill()
    {
        using var f = Shop();
        var v = Draft(f, 0, 0, Line("Rice", 10_000, 1000, "GST18"));
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.SetBillDiscount(v.Document.Id, 10_001, 0)).Code);
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.SetBillDiscount(v.Document.Id, 100, 5_000)).Code);
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.SetBillDiscount(v.Document.Id, 0, 100_001)).Code);
        Assert.Equal("discount", Assert.Throws<HubException>(() => f.App.Documents.SetBillDiscount(v.Document.Id, -1, 0)).Code);
        var with = f.App.Documents.SetBillDiscount(v.Document.Id, 0, 10_000);   // 10%
        Assert.Equal(10_620 + 0, with.Document.PayableMinor);                    // 90.00 + 18% = 106.20
        // a second line is added: 10% is now taken from 100.00 + 20.00
        var more = f.App.Documents.AddLine(v.Document.Id, Line("Salt", 2_000, 1000, "GST5"));
        Assert.Equal("12.00", more.Result!.Totals.Discount);
        Assert.Equal(10_800, more.Document.SubtotalMinor);   // 108.00 before tax
    }

    [Fact]
    public void A_bill_discount_on_tax_inclusive_prices_comes_off_the_price_with_its_tax()
    {
        using var f = Shop(inclusive: true);
        // L4: 118.00 with 18% inside. 18.00 off the bill leaves 100.00 with the tax inside: taxable 84.75, tax 15.25 (CGST 7.63, SGST 7.62).
        var v = Draft(f, 1_800, 0, Line("Lamp", 11_800, 1000, "GST18"));
        Assert.Equal(10_000, v.Document.PayableMinor);
        Assert.Equal(8_475, v.Document.SubtotalMinor);
        Assert.Equal("7.63", Part(v, "CGST"));
        Assert.Equal("7.62", Part(v, "SGST"));
    }

    [Fact]
    public void The_discount_is_kept_on_the_final_bill_and_checkout_takes_it()
    {
        using var f = Shop();
        var sale = f.App.Documents.Checkout(new CheckoutRequest
        {
            BillDiscountMinor = 5_000,
            Lines = { Line("Rice", 10_000, 1000, "GST18"), Line("Pens", 3_333, 3000, "GST18", pctMilli: 10_000) },
            Payments = { new PaymentInput { Method = "cash", AmountMinor = 16_519 } },
        });
        Assert.Equal(16_519, sale.Document.TotalMinor);
        Assert.Equal(5_000, sale.Document.BillDiscountMinor);
        Assert.Equal("paid", sale.Document.PaymentState);
        Assert.Equal(5_000, f.App.Documents.Get(sale.Document.Id)!.Document.BillDiscountMinor);
        // a final bill can no longer be given a discount
        Assert.Equal("not-open", Assert.Throws<HubException>(() => f.App.Documents.SetBillDiscount(sale.Document.Id, 0, 0)).Code);
    }

    // ---- giving goods back on a discounted bill -----------------------------------------------------------------------------------------

    [Fact]
    public void Giving_every_line_back_gives_back_exactly_what_was_paid_however_the_discounts_fall()
    {
        using var f = Shop();
        var sale = f.App.Documents.Checkout(new CheckoutRequest
        {
            BillDiscountMinor = 5_000,
            Lines = { Line("Rice", 10_000, 1000, "GST18"), Line("Pens", 3_333, 3000, "GST18", pctMilli: 10_000) },
            Payments = { new PaymentInput { Method = "cash", AmountMinor = 16_519 } },
        });
        var rice = sale.Lines[0];
        var pens = sale.Lines[1];
        var first = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (rice.Id, 1000L) }, "wrong colour", "cash", null);
        Assert.Equal(7_368 + 1_326, first.Document.TotalMinor);            // 86.94: rice 73.68 + CGST 6.63 + SGST 6.63
        // one pen back, then the other two: the pieces add up to what the pens were sold for (66.31 + 11.94 tax = 78.25)
        var second = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (pens.Id, 1000L) }, "broken", "cash", null);
        var third = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (pens.Id, 2000L) }, "broken", "cash", null);
        Assert.Equal(7_825, second.Document.TotalMinor + third.Document.TotalMinor);
        Assert.Equal(16_519, first.Document.TotalMinor + second.Document.TotalMinor + third.Document.TotalMinor);
        // nothing is left to give back
        Assert.Equal("too-many", Assert.Throws<HubException>(() => f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (pens.Id, 1L) }, "again", "cash", null)).Code);
        Assert.Equal("too-many", Assert.Throws<HubException>(() => f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (rice.Id, 1000L) }, "again", "cash", null)).Code);
    }

    [Fact]
    public void A_line_with_an_amount_discount_is_given_back_in_proportion_and_a_percent_line_as_before()
    {
        using var f = Shop();
        var sale = f.App.Documents.Checkout(new CheckoutRequest
        {
            Lines = { Line("Shirt", 25_000, 2000, "GST12", amountMinor: 3_750), Line("Pens", 3_333, 3000, "GST18", pctMilli: 10_000) },
            Payments = { new PaymentInput { Method = "cash", AmountMinor = 51_800 + 10_619 } },
        });
        // one of two shirts: half of the line, half of its discount: 250.00 - 18.75 = 231.25, GST 12% is 13.875 for each of CGST and SGST, which rounds up to 13.88 each: 259.01.
        // Two halves therefore come to 518.02 where the whole line was 518.00: a part of a line is taxed on its own, so a paisa or two can show. The refund never goes above what was paid.
        var shirt = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "size", "cash", null);
        Assert.Equal(25_901, shirt.Document.TotalMinor);
        var rest = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "size", "cash", null);
        Assert.Equal(25_901, rest.Document.TotalMinor);
        Assert.Equal(1_875, shirt.Lines[0].DiscountAmountMinor);
        // the pens carry no amount discount and the bill none, so they go back at their percent, as they always did: 33.33 less 10% = 3.33 off, GST 18%
        var pen = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[1].Id, 1000L) }, "broken", "cash", null);
        Assert.Equal(0, pen.Lines[0].DiscountAmountMinor);
        Assert.Equal(10_000, pen.Lines[0].DiscountPctMilli);
        Assert.Equal(sale.Lines[1].Id, pen.Lines[0].RefLineId);
        Assert.Equal(3_540, pen.Document.TotalMinor);                          // 30.00 + 2 x 2.70 = 35.40
    }

    [Fact]
    public void The_answer_for_a_line_is_found_by_its_place_even_when_a_line_in_front_of_it_was_taken_off()
    {
        using var f = Shop();
        var v = Draft(f, 0, 0, Line("A", 10_000, 1000, "GST18"), Line("B", 20_000, 1000, "GST18"), Line("C", 30_000, 1000, "GST18"));
        var after = f.App.Documents.RemoveLine(v.Document.Id, v.Lines[1].Id);
        Assert.Equal(new[] { 1, 3 }, after.Lines.Select(l => l.LineNo).ToArray());   // the numbers keep their gap
        Assert.Equal("300.00", after.ResultFor(after.Lines[1])!.Gross);              // line C is the second answer of the engine, not the third
        Assert.Equal("100.00", after.ResultFor(after.Lines[0])!.Gross);
    }

    // ---- who may give a discount, and the database step -----------------------------------------------------------------------------------

    [Fact]
    public void Owners_and_managers_may_give_discounts_and_a_cashier_only_up_to_the_owners_limit()
    {
        Assert.True(NextGenOS.Hub.Security.Roles.Can("owner", NextGenOS.Hub.Security.Perm.Discount));
        Assert.True(NextGenOS.Hub.Security.Roles.Can("manager", NextGenOS.Hub.Security.Perm.Discount));
        Assert.False(NextGenOS.Hub.Security.Roles.Can("cashier", NextGenOS.Hub.Security.Perm.Discount));
        using var f = Shop();
        Assert.Equal(0, f.App.Shop.Current.Settings.CashierDiscountPctMilli);
    }

    [Fact]
    public void The_database_step_adds_only_columns_and_can_be_undone_leaving_the_bills()
    {
        using var f = Shop();
        var v = Draft(f, 5_000, 0, Line("Rice", 10_000, 1000, "GST18"));
        var before = f.App.Documents.Get(v.Document.Id)!.Document.PayableMinor;
        f.App.Db.Rollback(4);
        var columns = f.App.Db.Query("SELECT name FROM pragma_table_info('documents')", r => r.GetString(0));
        Assert.DoesNotContain("bill_discount_minor", columns);
        Assert.DoesNotContain("discount_amount_minor", f.App.Db.Query("SELECT name FROM pragma_table_info('document_lines')", r => r.GetString(0)));
        Assert.Equal(new long[] { 1, 2, 3, 4 }, f.App.Db.Query("SELECT version FROM schema_version ORDER BY version", r => r.GetInt64(0)).ToArray());
        Assert.NotEqual(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents")));
        // opening it again brings the step back; the bill is still there (its discount was kept only in the step's columns, so it is the plain bill again)
        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Clock);
        Assert.Contains("bill_discount_minor", again.Db.Query("SELECT name FROM pragma_table_info('documents')", r => r.GetString(0)));
        Assert.True(before > 0);
    }
}

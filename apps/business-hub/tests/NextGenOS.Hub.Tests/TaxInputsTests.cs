using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Import;
using NextGenOS.Hub.Offers;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The two things a country's tax may ask for besides the rate (docs/old-programs/03-india-tax-and-staff.md, A1 and C.3): a code for what is sold, and a further tax set per item. The country's pack names
/// them (or does not): a shop in a country whose pack names neither sees neither and is charged neither. The numbers E6 and I6 are the study's worked examples (a 28% rate with 12% extra tax, on
/// exclusive and on inclusive prices); the older program was wrong for I6 (it cut the two taxes out of the whole price separately), the Hub and its tax engine give the right answer.
/// </summary>
public class TaxInputsTests
{
    private static HubFixture India(bool inclusive = false) => new("IN", "retail", s => s.PricesIncludeTax = inclusive);

    private static string Part(DocumentView v, string name) => v.Result!.Totals.Components.Single(c => c.Name == name).Amount;

    private static LineInput Line(long priceMinor, string tax, long? extra = null, string? code = null, long qtyMilli = 1000) =>
        new() { Description = "Soft drink", UnitPriceMinor = priceMinor, QtyMilli = qtyMilli, TaxCode = tax, ExtraTaxPctMilli = extra, ItemCode = code };

    [Fact]
    public void E6_an_extra_tax_on_an_exclusive_price_is_added_on_top()
    {
        using var f = India();
        var v = f.App.Documents.CreateDraft(new DraftOptions { Lines = { Line(100_000, "GST28", 12_000) } });     // 1 x 1000.00, 28% and 12% extra
        Assert.Equal("140.00", Part(v, "CGST"));
        Assert.Equal("140.00", Part(v, "SGST"));
        Assert.Equal("120.00", v.Result!.Totals.Cess);
        Assert.Equal(140_000, v.Document.PayableMinor);                                                            // 1,400.00
        Assert.Equal(12_000, v.Lines[0].ExtraTaxPctMilli);
    }

    [Fact]
    public void I6_an_extra_tax_on_an_inclusive_price_is_cut_out_of_the_price_once_and_the_total_stays_the_price()
    {
        using var f = India(inclusive: true);
        var v = f.App.Documents.CreateDraft(new DraftOptions { Lines = { Line(140_000, "GST28", 12_000) } });     // 1 x 1,400.00 including both taxes
        Assert.Equal(100_000, v.Document.SubtotalMinor);                                                           // the older program had 943.76
        Assert.Equal("140.00", Part(v, "CGST"));
        Assert.Equal("140.00", Part(v, "SGST"));
        Assert.Equal("120.00", v.Result!.Totals.Cess);
        Assert.Equal(140_000, v.Document.PayableMinor);
    }

    [Fact]
    public void An_item_gives_its_code_and_its_extra_tax_to_the_line_and_the_line_keeps_them_when_the_item_changes()
    {
        using var f = India();
        var item = f.App.Catalog.Create(new ItemInput
        {
            Kind = "stock", Name = "Soft drink", PriceMinor = 100_000, TaxClass = "GST28", TrackStock = false,
            Attrs = new() { [ItemAttrs.Code] = "2202", [ItemAttrs.ExtraTax] = "12" },
        });
        var v = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = item.Id } } });
        Assert.Equal("2202", v.Lines[0].ItemCode);
        Assert.Equal(12_000, v.Lines[0].ExtraTaxPctMilli);
        Assert.Equal("120.00", v.Result!.Totals.Cess);
        // the item changes later: the bill that was made keeps what it was
        var done = f.App.Documents.Issue(v.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = v.Document.PayableMinor } } });
        f.App.Catalog.Update(item.Id, new ItemInput { Kind = "stock", Name = "Soft drink", PriceMinor = 100_000, TaxClass = "GST28", TrackStock = false, Attrs = new() { [ItemAttrs.Code] = "9999" } });
        var again = f.App.Documents.Get(done.Document.Id)!;
        Assert.Equal("2202", again.Lines[0].ItemCode);
        Assert.Equal(12_000, again.Lines[0].ExtraTaxPctMilli);
        Assert.Equal(done.Document.PayableMinor, again.Document.PayableMinor);
        // a typed value on the line wins over the item's
        var typed = f.App.Documents.AddLine(f.App.Documents.CreateDraft(new DraftOptions()).Document.Id, new LineInput { ItemId = item.Id, ItemCode = "1111", ExtraTaxPctMilli = 0 });
        Assert.Equal("1111", typed.Lines[0].ItemCode);
        Assert.Equal(0, typed.Lines[0].ExtraTaxPctMilli);
    }

    [Theory]
    [InlineData("PH", "VAT12")]
    [InlineData("GB", "VAT20")]
    public void A_country_whose_pack_names_neither_keeps_neither_and_charges_no_extra_tax(string country, string tax)
    {
        using var f = new HubFixture(country, "retail");
        Assert.Null(f.App.Shop.Current.Country.Tax.ItemCode);
        Assert.Null(f.App.Shop.Current.Country.Tax.ExtraTax);
        var item = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Thing", PriceMinor = 10_000, TaxClass = tax, TrackStock = false, Attrs = new() { [ItemAttrs.Code] = "2202", [ItemAttrs.ExtraTax] = "12" } });
        var v = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = item.Id } } });
        Assert.Null(v.Lines[0].ItemCode);
        Assert.Equal(0, v.Lines[0].ExtraTaxPctMilli);
        Assert.Equal("0.00", v.Result!.Totals.Cess);
    }

    [Fact]
    public void The_pack_says_what_the_two_fields_are_called()
    {
        using var f = India();
        var tax = f.App.Shop.Current.Country.Tax;
        Assert.Equal("HSN or SAC code", tax.ItemCode!.Label);
        Assert.Equal("Cess", tax.ExtraTax!.Label);
    }

    [Fact]
    public void A_percent_outside_nought_to_a_hundred_or_a_very_long_code_is_refused()
    {
        using var f = India();
        Assert.Equal("extra-tax", Assert.Throws<HubException>(() => f.App.Documents.CreateDraft(new DraftOptions { Lines = { Line(10_000, "GST18", 100_001) } })).Code);
        Assert.Equal("extra-tax", Assert.Throws<HubException>(() => f.App.Documents.CreateDraft(new DraftOptions { Lines = { Line(10_000, "GST18", -1) } })).Code);
        Assert.Equal("item-code", Assert.Throws<HubException>(() => f.App.Documents.CreateDraft(new DraftOptions { Lines = { Line(10_000, "GST18", null, new string('1', 41)) } })).Code);
    }

    [Fact]
    public void Goods_given_back_a_quote_made_into_a_bill_and_free_goods_all_keep_the_code_and_the_extra_tax()
    {
        using var f = India();
        var item = f.App.Catalog.Create(new ItemInput
        {
            Kind = "stock", Name = "Soft drink", PriceMinor = 100_000, TaxClass = "GST28", TrackStock = false,
            Attrs = new() { [ItemAttrs.Code] = "2202", [ItemAttrs.ExtraTax] = "12" },
        });
        f.App.Offers.SaveOffer(new OfferInput { Kind = OfferKinds.BuyGet, ItemId = item.Id, MinQtyMilli = 2_000, FreeQtyMilli = 1_000 });
        // a quote, then the bill made from it: the same code, the same extra tax, the same total
        var quote = f.App.Documents.SaveAsEstimate(f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = item.Id, QtyMilli = 2_000 } } }).Document.Id);
        var bill = f.App.Documents.BillFromEstimate(quote.Document.Id);
        Assert.Equal(quote.Document.PayableMinor, bill.Document.PayableMinor);
        Assert.All(bill.Lines, l => Assert.Equal("2202", l.ItemCode));                                              // the free line too: a list by code counts every unit that left
        Assert.All(bill.Lines, l => Assert.Equal(12_000, l.ExtraTaxPctMilli));
        var sale = f.App.Documents.Issue(bill.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = bill.Document.PayableMinor } } });
        // one of the two paid-for drinks comes back: its code and extra tax come with it, and what is given back is what was paid, extra tax included
        var note = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "damaged", "cash", null);
        Assert.Equal("2202", note.Lines[0].ItemCode);
        Assert.Equal(12_000, note.Lines[0].ExtraTaxPctMilli);
        Assert.Equal(140_000, note.Document.TotalMinor);                                                            // 1,000.00 + 28% + 12%
    }

    [Fact]
    public void The_importer_keeps_the_older_programs_code_and_extra_tax_when_the_country_has_them_and_says_so_when_it_does_not()
    {
        var data = OldPos.Only(d => d with { Products = [.. d.Products.Select(p => p.Id == 1 ? p with { Cess = 12m } : p)] });
        using (var india = India())
        {
            var plan = PosMapper.Plan("pos-sqlserver", "pc1/shopdata", "test", data, india.App.Shop.Current, ExistingState.None, india.App.Catalog.WouldTrackStock);
            var rice = plan.Items.Single(i => i.OldKey == "lot:11").Input;
            Assert.Equal("1006", rice.Attrs[ItemAttrs.Code]);
            Assert.Equal("12", rice.Attrs[ItemAttrs.ExtraTax]);
            Assert.Equal(FindingLevels.Info, plan.Report.Findings.Single(x => x.Code == "cess").Level);
        }
        using var germany = new HubFixture("DE", "retail");
        var other = PosMapper.Plan("pos-sqlserver", "pc1/shopdata", "test", data, germany.App.Shop.Current, ExistingState.None, germany.App.Catalog.WouldTrackStock);
        Assert.False(other.Items.Single(i => i.OldKey == "lot:11").Input.Attrs.ContainsKey(ItemAttrs.ExtraTax));
        Assert.Contains("not moved", other.Report.Findings.Single(x => x.Code == "cess").Text);
    }

    [Fact]
    public void The_step_can_be_undone_and_done_again_and_the_bills_stay()
    {
        using var f = India();
        var v = f.App.Documents.CreateDraft(new DraftOptions { Lines = { Line(100_000, "GST28", 12_000, "2202") } });
        var done = f.App.Documents.Issue(v.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = v.Document.PayableMinor } } });
        var path = f.App.Db.Path;
        f.App.Db.Rollback(9);
        Assert.DoesNotContain("item_code", f.App.Db.Query("SELECT name FROM pragma_table_info('document_lines')", r => r.GetString(0)));
        Assert.DoesNotContain("extra_tax_pct_milli", f.App.Db.Query("SELECT name FROM pragma_table_info('document_lines')", r => r.GetString(0)));
        Assert.Equal(done.Document.PayableMinor, Convert.ToInt64(f.App.Db.Scalar("SELECT payable_minor FROM documents WHERE id = $id", ("$id", done.Document.Id))));
        var again = HubApp.OpenTrusted(path, f.Clock);
        Assert.Contains("item_code", again.Db.Query("SELECT name FROM pragma_table_info('document_lines')", r => r.GetString(0)));
    }
}

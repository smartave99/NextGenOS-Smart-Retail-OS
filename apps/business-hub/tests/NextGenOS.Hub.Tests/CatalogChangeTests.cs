using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, products tools A: changing many items at once and taking it back (study 02 A2.6). The older program's own worked examples are here as tests, with the numbers worked by hand:
/// BP1 to BP5 (bulk price change) and GB1 to GB4 (bulk GST change). Shop in India, rupees, prices in paise.
/// </summary>
public class CatalogChangeTests
{
    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static Item Product(HubFixture f, string name, long priceMinor, string tax = "standard", string? category = null, long? trade = null, Dictionary<string, string>? attrs = null) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = priceMinor, TradePriceMinor = trade, TaxClass = tax, Category = category, TrackStock = false, Attrs = attrs ?? new() });

    private static long PriceOf(HubFixture f, Item item) => f.App.Catalog.Get(item.Id)!.PriceMinor;

    // ---- prices: BP1 to BP5, the typed price beside each item --------------------------------------------------------------------------------

    [Fact]
    public void BP2_a_price_typed_beside_an_item_changes_that_item_and_no_other()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var b = Product(f, "Tea", 5_000);

        var preview = f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "120", [b.Id] = "" }, "price");
        var change = Assert.Single(preview.Changes);
        Assert.Equal((a.Id, 10_000L, 12_000L), (change.ItemId, change.OldMinor, change.NewMinor));
        var result = f.App.CatalogChanges.ApplyPrices(preview);

        Assert.Equal(1, result.Changed);
        Assert.Equal(12_000, PriceOf(f, a));
        Assert.Equal(5_000, PriceOf(f, b));
    }

    [Theory]
    [InlineData("0")]
    [InlineData("0.00")]
    [InlineData("")]
    [InlineData("   ")]
    public void BP3_nothing_or_zero_typed_leaves_the_item_as_it_is(string typed)
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var b = Product(f, "Tea", 5_000);

        // the older program's rule: only rows whose new price is above nothing are changed; here one other item is changed so that the preview has something to show
        var preview = f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = typed, [b.Id] = "60" }, "price");

        Assert.Equal(b.Id, Assert.Single(preview.Changes).ItemId);
        f.App.CatalogChanges.ApplyPrices(preview);
        Assert.Equal(10_000, PriceOf(f, a));
    }

    [Fact]
    public void BP4_with_nothing_typed_the_screen_says_so_and_nothing_is_written()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);

        var ex = Assert.Throws<HubException>(() => f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "" }, "price"));

        Assert.Equal("nothing-typed", ex.Code);
        Assert.Empty(f.App.CatalogChanges.Recent());
    }

    [Fact]
    public void A_price_that_is_not_a_number_is_refused_in_plain_words()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);

        var ex = Assert.Throws<HubException>(() => f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "abc" }, "price"));

        Assert.Equal("amount", ex.Code);
        Assert.Contains("abc", ex.Message);
    }

    [Fact]
    public void A_price_typed_the_same_as_the_item_has_is_left_and_not_counted()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);

        var preview = f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "100.00", [Product(f, "Tea", 5_000).Id] = "55" }, "price");

        Assert.Single(preview.Changes);
        Assert.Contains(preview.Left, x => x.ItemId == a.Id && x.Why.Contains("stays the same"));
    }

    // ---- prices: by a percent or an amount ------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_percent_raises_every_chosen_price_and_rounds_to_the_nearest_paisa_with_halves_up()
    {
        using var f = Shop();
        var rice = Product(f, "Rice", 10_000);       // 100.00 + 5%     = 105.00
        var odd = Product(f, "Oddity", 9_999);       // 99.99 * 2.5% = 2.49975 -> 2.50 -> 102.49 for +2.5
        var other = Product(f, "Tea", 5_000);         // not chosen

        var five = f.App.CatalogChanges.PreviewPrices(new[] { rice.Id }, "price", "percent", "5");
        Assert.Equal(10_500, Assert.Single(five.Changes).NewMinor);

        var oddPreview = f.App.CatalogChanges.PreviewPrices(new[] { odd.Id }, "price", "percent", "2.5");
        Assert.Equal(10_249, Assert.Single(oddPreview.Changes).NewMinor);   // 9999 + 249.975 -> 9999 + 250

        f.App.CatalogChanges.ApplyPrices(five);
        Assert.Equal(10_500, PriceOf(f, rice));
        Assert.Equal(5_000, PriceOf(f, other));
    }

    [Fact]
    public void A_minus_percent_lowers_and_a_rounding_step_rounds_the_result_to_the_nearest_step()
    {
        using var f = Shop();
        var a = Product(f, "A", 10_000);   // -10% = 90.00
        var b = Product(f, "B", 9_999);    // +2.5% = 102.49, step 5 paise -> 102.50

        Assert.Equal(9_000, Assert.Single(f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "price", "percent", "-10").Changes).NewMinor);
        var stepped = f.App.CatalogChanges.PreviewPrices(new[] { b.Id }, "price", "percent", "2.5", roundStepMinor: 5);
        Assert.Equal(10_250, Assert.Single(stepped.Changes).NewMinor);
        Assert.Contains("rounded", stepped.Summary);
    }

    [Fact]
    public void An_amount_adds_or_takes_off_the_same_money_from_every_chosen_item()
    {
        using var f = Shop();
        var a = Product(f, "A", 10_000);
        var b = Product(f, "B", 1_500);

        var up = f.App.CatalogChanges.PreviewPrices(new[] { a.Id, b.Id }, "price", "amount", "10");
        Assert.Equal(new[] { 11_000L, 2_500L }, up.Changes.Select(x => x.NewMinor).ToArray());

        // minus 20.00 takes B (15.00) below nothing: it is left, with the reason; A (100.00) goes to 80.00
        var down = f.App.CatalogChanges.PreviewPrices(new[] { a.Id, b.Id }, "price", "amount", "-20");
        Assert.Equal(8_000, Assert.Single(down.Changes).NewMinor);
        var left = Assert.Single(down.Left);
        Assert.Equal(b.Id, left.ItemId);
        Assert.Contains("below nothing", left.Why);
    }

    [Fact]
    public void The_trade_price_is_changed_only_on_items_that_have_one()
    {
        using var f = Shop();
        var withTrade = Product(f, "Rice", 10_000, trade: 9_000);
        var without = Product(f, "Tea", 5_000);

        var preview = f.App.CatalogChanges.PreviewPrices(new[] { withTrade.Id, without.Id }, "trade", "percent", "10");

        Assert.Equal(9_900, Assert.Single(preview.Changes).NewMinor);
        Assert.Contains(preview.Left, x => x.ItemId == without.Id && x.Why.Contains("no trade price"));
        f.App.CatalogChanges.ApplyPrices(preview);
        Assert.Equal(9_900, f.App.Catalog.Get(withTrade.Id)!.TradePriceMinor);
        Assert.Null(f.App.Catalog.Get(without.Id)!.TradePriceMinor);
        Assert.Equal(10_000, PriceOf(f, withTrade));   // the retail price is not touched
    }

    [Theory]
    [InlineData("percent", "0", "percent")]
    [InlineData("percent", "-101", "percent")]
    [InlineData("percent", "1001", "percent")]
    [InlineData("percent", "five", "percent")]
    [InlineData("amount", "0", "amount")]
    [InlineData("amount", "x", "amount")]
    [InlineData("magic", "5", "rule")]
    public void A_change_that_means_nothing_or_cannot_be_read_is_refused_before_anything_is_worked_out(string rule, string value, string code)
    {
        using var f = Shop();
        var a = Product(f, "A", 10_000);

        var ex = Assert.Throws<HubException>(() => f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "price", rule, value));

        Assert.Equal(code, ex.Code);
    }

    [Fact]
    public void No_items_chosen_or_a_rounding_step_below_one_is_refused()
    {
        using var f = Shop();
        var a = Product(f, "A", 10_000);

        Assert.Equal("nothing-chosen", Assert.Throws<HubException>(() => f.App.CatalogChanges.PreviewPrices(Array.Empty<long>(), "price", "percent", "5")).Code);
        Assert.Equal("round", Assert.Throws<HubException>(() => f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "price", "percent", "5", 0)).Code);
        Assert.Equal("field", Assert.Throws<HubException>(() => f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "cost", "percent", "5")).Code);
    }

    // ---- the record, the audit log and old bills --------------------------------------------------------------------------------------------------

    [Fact]
    public void A_saved_change_is_in_the_record_with_every_item_before_and_after_and_in_the_audit_log()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var b = Product(f, "Tea", 5_000);

        var result = f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewPrices(new[] { a.Id, b.Id }, "price", "percent", "10"));

        var entry = Assert.Single(f.App.CatalogChanges.Recent());
        Assert.Equal((result.ChangeId, "price", 2, false), (entry.Id, entry.Kind, entry.ItemCount, entry.Undone));
        Assert.Equal("The price of 2 items raised by 10 percent", entry.Summary);
        var lines = f.App.CatalogChanges.Lines(entry.Id);
        Assert.Equal(new[] { "Soap: ₹100.00 → ₹110.00", "Tea: ₹50.00 → ₹55.00" }, lines.Select(l => $"{l.Name}: {l.Before} → {l.After}").ToArray());
        Assert.Contains(f.App.Audit.Recent(), x => x.Action == "catalog.prices" && x.EntityId == entry.Id);
    }

    [Fact]
    public void A_bill_that_was_made_keeps_the_price_it_was_made_with()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var bill = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = a.Id, QtyMilli = 1_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } });
        var before = f.App.Documents.Get(bill.Document.Id)!;

        f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "price", "percent", "50"));

        var after = f.App.Documents.Get(bill.Document.Id)!;
        Assert.Equal(before.Document.TotalMinor, after.Document.TotalMinor);
        Assert.Equal(before.Lines[0].UnitPriceMinor, after.Lines[0].UnitPriceMinor);
        Assert.Equal(15_000, PriceOf(f, a));
    }

    [Fact]
    public void An_item_changed_by_someone_else_after_the_preview_is_left_and_reported()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var b = Product(f, "Tea", 5_000);
        var preview = f.App.CatalogChanges.PreviewPrices(new[] { a.Id, b.Id }, "price", "percent", "10");

        f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "200" }, "price"));   // someone else
        var result = f.App.CatalogChanges.ApplyPrices(preview);

        Assert.Equal(1, result.Changed);
        Assert.Equal(20_000, PriceOf(f, a));
        Assert.Equal(5_500, PriceOf(f, b));
        Assert.Contains(result.Left, x => x.ItemId == a.Id && x.Why.Contains("changed by someone else"));
    }

    [Fact]
    public void A_change_that_changes_nothing_writes_nothing()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 0);

        var preview = f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "price", "percent", "10");   // 10% of nothing is nothing

        Assert.Empty(preview.Changes);
        var result = f.App.CatalogChanges.ApplyPrices(preview);
        Assert.Equal((0L, 0), (result.ChangeId, result.Changed));
        Assert.Empty(f.App.CatalogChanges.Recent());
    }

    // ---- tax: GB1 to GB4 ---------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void GB1_GB2_only_items_with_exactly_the_old_rate_change_and_the_others_are_not_counted()
    {
        using var f = Shop();
        var old12 = Product(f, "Packed snack", 10_000, tax: "GST12");
        var old12b = Product(f, "Biscuits", 4_000, tax: "GST12");
        var already18 = Product(f, "Soap", 10_000, tax: "GST18");
        var five = Product(f, "Rice", 10_000, tax: "GST5");

        var preview = f.App.CatalogChanges.PreviewTax("GST12", "GST18");
        Assert.Equal(new[] { old12b.Id, old12.Id }, preview.Changes.Select(x => x.ItemId).ToArray());   // by name: Biscuits, Packed snack

        var result = f.App.CatalogChanges.ApplyTax(preview);

        Assert.Equal(2, result.Changed);   // the older program counted the ticked items, even those it did not change
        Assert.Equal("GST18", f.App.Catalog.Get(old12.Id)!.TaxCode);
        Assert.Equal("GST18", f.App.Catalog.Get(already18.Id)!.TaxCode);
        Assert.Equal("GST5", f.App.Catalog.Get(five.Id)!.TaxCode);
        Assert.Equal("The tax of 2 items changed from GST 12% (old rate, until 21 Sep 2025) to GST 18%", f.App.CatalogChanges.Recent()[0].Summary);
    }

    [Fact]
    public void GB3_a_chosen_item_code_narrows_the_change_to_items_with_that_code()
    {
        using var f = Shop();
        var a = Product(f, "A", 10_000, tax: "GST12", attrs: new() { [ItemAttrs.Code] = "1234" });
        var b = Product(f, "B", 10_000, tax: "GST12", attrs: new() { [ItemAttrs.Code] = "5678" });

        var preview = f.App.CatalogChanges.PreviewTax("GST12", "GST18", itemCode: "1234");

        Assert.Equal(a.Id, Assert.Single(preview.Changes).ItemId);
        f.App.CatalogChanges.ApplyTax(preview);
        Assert.Equal("GST12", f.App.Catalog.Get(b.Id)!.TaxCode);
    }

    [Fact]
    public void A_category_or_a_list_of_items_narrows_the_tax_change_too()
    {
        using var f = Shop();
        var a = Product(f, "A", 10_000, tax: "GST12", category: "Food");
        var b = Product(f, "B", 10_000, tax: "GST12", category: "Home");
        var c = Product(f, "C", 10_000, tax: "GST12", category: "Food");

        Assert.Equal(new[] { a.Id, c.Id }, f.App.CatalogChanges.PreviewTax("GST12", "GST18", category: "Food").Changes.Select(x => x.ItemId).ToArray());
        Assert.Equal(b.Id, Assert.Single(f.App.CatalogChanges.PreviewTax("GST12", "GST18", itemIds: new[] { b.Id }).Changes).ItemId);
    }

    [Theory]
    [InlineData("GST12", "")]
    [InlineData("", "GST18")]
    [InlineData("GST12", "GST12")]
    [InlineData("GST12", "GST99")]
    public void GB4_a_missing_the_same_or_unknown_tax_is_refused(string from, string to)
    {
        using var f = Shop();

        var ex = Assert.Throws<HubException>(() => f.App.CatalogChanges.PreviewTax(from, to));

        Assert.Equal("tax", ex.Code);
    }

    // ---- on and off sale -----------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Items_are_taken_off_sale_and_put_back_and_one_already_as_asked_is_not_counted()
    {
        using var f = Shop();
        var a = Product(f, "A", 10_000);
        var b = Product(f, "B", 10_000);
        f.App.Catalog.SetActive(b.Id, false);

        var off = f.App.CatalogChanges.SetOnSale(new[] { a.Id, b.Id }, false);

        Assert.Equal(1, off.Changed);
        Assert.Contains(off.Left, x => x.ItemId == b.Id && x.Why.Contains("off sale already"));
        Assert.False(f.App.Catalog.Get(a.Id)!.Active);
        var back = f.App.CatalogChanges.SetOnSale(new[] { a.Id, b.Id }, true);
        Assert.Equal(2, back.Changed);
        Assert.True(f.App.Catalog.Get(b.Id)!.Active);
        Assert.Equal("2 items put back on sale", f.App.CatalogChanges.Recent()[0].Summary);
    }

    [Fact]
    public void Nothing_chosen_for_on_and_off_sale_is_refused()
    {
        using var f = Shop();

        Assert.Equal("nothing-chosen", Assert.Throws<HubException>(() => f.App.CatalogChanges.SetOnSale(Array.Empty<long>(), false)).Code);
    }

    // ---- taking a change back --------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_change_is_taken_back_and_the_undo_is_itself_in_the_record()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var change = f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "price", "percent", "10"));
        Assert.Equal(11_000, PriceOf(f, a));

        var undo = f.App.CatalogChanges.Undo(change.ChangeId);

        Assert.Equal(1, undo.Changed);
        Assert.Equal(10_000, PriceOf(f, a));
        var recent = f.App.CatalogChanges.Recent();
        Assert.Equal(new[] { "undo", "price" }, recent.Select(x => x.Kind).ToArray());
        Assert.True(recent[1].Undone);
        Assert.Equal(change.ChangeId, recent[0].Undoes);
        Assert.StartsWith("Taken back: ", recent[0].Summary);
        Assert.Contains(f.App.Audit.Recent(), x => x.Action == "catalog.undo" && x.EntityId == change.ChangeId);
    }

    [Fact]
    public void A_change_can_be_taken_back_once_and_a_taking_back_cannot_be_taken_back()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var change = f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "price", "percent", "10"));
        var undo = f.App.CatalogChanges.Undo(change.ChangeId);

        Assert.Equal("undone", Assert.Throws<HubException>(() => f.App.CatalogChanges.Undo(change.ChangeId)).Code);
        Assert.Equal("undo-undo", Assert.Throws<HubException>(() => f.App.CatalogChanges.Undo(undo.ChangeId)).Code);
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.CatalogChanges.Undo(9_999)).Code);
    }

    [Fact]
    public void An_item_changed_again_since_is_not_put_back_and_is_reported_while_the_others_are()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var b = Product(f, "Tea", 5_000);
        var change = f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewPrices(new[] { a.Id, b.Id }, "price", "percent", "10"));
        f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "300" }, "price"));

        var undo = f.App.CatalogChanges.Undo(change.ChangeId);

        Assert.Equal(1, undo.Changed);
        Assert.Equal(30_000, PriceOf(f, a));   // the later change stands
        Assert.Equal(5_000, PriceOf(f, b));
        Assert.Contains(undo.Left, x => x.ItemId == a.Id && x.Why.Contains("changed again"));
    }

    [Fact]
    public void When_every_item_has_been_changed_again_there_is_nothing_to_take_back_and_the_change_stays_open()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var change = f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewPrices(new[] { a.Id }, "price", "percent", "10"));
        f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "300" }, "price"));

        Assert.Equal("undo-impossible", Assert.Throws<HubException>(() => f.App.CatalogChanges.Undo(change.ChangeId)).Code);
        Assert.False(f.App.CatalogChanges.Recent().Single(x => x.Id == change.ChangeId).Undone);
    }

    [Fact]
    public void Tax_and_on_sale_changes_are_taken_back_too_and_a_trade_price_that_was_empty_goes_back_to_empty()
    {
        using var f = Shop();
        var a = Product(f, "Snack", 10_000, tax: "GST12");
        var tax = f.App.CatalogChanges.ApplyTax(f.App.CatalogChanges.PreviewTax("GST12", "GST18"));
        var off = f.App.CatalogChanges.SetOnSale(new[] { a.Id }, false);
        var trade = f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "90" }, "trade"));
        Assert.Equal(9_000, f.App.Catalog.Get(a.Id)!.TradePriceMinor);

        f.App.CatalogChanges.Undo(trade.ChangeId);
        f.App.CatalogChanges.Undo(off.ChangeId);
        f.App.CatalogChanges.Undo(tax.ChangeId);

        var item = f.App.Catalog.Get(a.Id)!;
        Assert.Null(item.TradePriceMinor);
        Assert.True(item.Active);
        Assert.Equal("GST12", item.TaxCode);
    }

    [Fact]
    public void The_record_shows_none_for_a_trade_price_that_did_not_exist()
    {
        using var f = Shop();
        var a = Product(f, "Soap", 10_000);
        var change = f.App.CatalogChanges.ApplyPrices(f.App.CatalogChanges.PreviewSetPrices(new Dictionary<long, string> { [a.Id] = "90" }, "trade"));

        var line = Assert.Single(f.App.CatalogChanges.Lines(change.ChangeId));

        Assert.Equal(("Trade price", "none", "₹90.00"), (line.Field, line.Before, line.After));
    }
}

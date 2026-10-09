using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Import;
using NextGenOS.Hub.Reports;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, products tools F: bringing items in from a spreadsheet, and sending them out to one (the older POS's staff import launcher and Excel product screens, study 04 C.1 and study 01 6.6).
/// Shop in India, rupees, prices in paise.
/// </summary>
public class ItemSheetTests
{
    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private const string Header = "Name,Category,Barcode,SKU,Unit,Price,Trade price,Cost price,Tax,Reorder level,Opening stock";

    private static SheetCheck Check(HubFixture f, string text) => f.App.ItemSheets.Check("items.csv", text);

    // ---- the file --------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_file_is_read_with_quotes_doubled_quotes_line_breaks_in_a_cell_a_mark_at_the_start_and_empty_lines()
    {
        var rows = Csv.Read("﻿Name,Note\r\n\"Salt, fine\",\"say \"\"hi\"\"\"\r\n\r\n\"two\nlines\",x\r\n");

        Assert.Equal(3, rows.Count);
        Assert.Equal(new[] { "Salt, fine", "say \"hi\"" }, rows[1]);
        Assert.Equal(new[] { "two\nlines", "x" }, rows[2]);
    }

    [Theory]
    [InlineData("Name;Price\nRice;10,5\n", ';')]
    [InlineData("Name\tPrice\nRice\t10\n", '\t')]
    [InlineData("Name,Price\nRice,10\n", ',')]
    public void The_separator_is_found_from_the_first_line(string text, char separator)
    {
        var rows = Csv.Read(text);

        Assert.Equal(2, rows[1].Length);
        Assert.Equal("Rice", rows[1][0]);
        Assert.Contains(separator.ToString(), text.Split('\n')[0]);
    }

    [Fact]
    public void Text_that_a_spreadsheet_would_run_as_a_formula_is_saved_as_plain_text_and_read_back_as_typed()
    {
        var built = Csv.Build(new[] { "Name" }, new[] { (IReadOnlyList<object?>)new object?[] { "=1+1" }, new object?[] { "-dash" }, new object?[] { "plain" } });

        var rows = Csv.Read(built);

        Assert.Equal(new[] { "=1+1", "-dash", "plain" }, rows.Skip(1).Select(r => r[0]).ToArray());
        Assert.Contains("'=1+1", built);
    }

    [Theory]
    [InlineData("1299.5", 2, 129_950L)]
    [InlineData("1,299.50", 2, 129_950L)]
    [InlineData("1.299,50", 2, 129_950L)]
    [InlineData("₹ 1299", 2, 129_900L)]
    [InlineData("Rs. 99", 2, 9_900L)]
    [InlineData("1,299", 2, 129_900L)]
    [InlineData("12.", 2, 1_200L)]
    [InlineData("0.5", 2, 50L)]
    [InlineData("2.5", 3, 2_500L)]
    [InlineData("1250", 0, 1_250L)]
    public void A_number_is_read_the_way_a_spreadsheet_writes_it(string text, int decimals, long expected)
    {
        Assert.True(ItemSheetService.Number(text, decimals, out var value, out var why), why);
        Assert.Equal(expected, value);
    }

    [Theory]
    [InlineData("-5", 2)]
    [InlineData("abc", 2)]
    [InlineData("", 2)]
    [InlineData("1.234,567", 2)]
    [InlineData("(5)", 2)]
    public void A_number_that_is_not_a_number_or_is_below_nothing_is_refused_with_a_reason(string text, int decimals)
    {
        Assert.False(ItemSheetService.Number(text, decimals, out _, out var why));
        Assert.NotEmpty(why);
    }

    // ---- looking before writing --------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_check_says_what_would_be_added_and_writes_nothing()
    {
        using var f = Shop();
        var check = Check(f, Header + "\nRice,Grocery,8900000000011,R1,kg,60,55,45,GST5,10,100\nSoap,Home,8900000000028,S1,pc,35.50,,20,18,,\n");

        Assert.Equal((2, 0, 0, false), (check.ToAdd, check.ToChange, check.Same, check.HasProblems));
        Assert.Equal(new[] { "Rice", "Soap" }, check.Lines.Select(l => l.Name).ToArray());
        Assert.Equal(new[] { 2, 3 }, check.Lines.Select(l => l.Row).ToArray());
        Assert.Contains("₹60.00", check.Lines[0].Detail);
        Assert.Empty(f.App.Catalog.Search(null, null, null, 100, includeInactive: true));
    }

    [Fact]
    public void Importing_adds_the_items_with_every_column_and_counts_the_opening_stock_at_cost_with_the_books()
    {
        using var f = Shop();
        var check = Check(f, Header + "\nRice,Grocery,8900000000011,R1,kg,60,55,45,GST5,10,100\nSoap,Home,8900000000028,S1,pc,35.50,,20,18,,\n");

        var result = f.App.ItemSheets.Import(check, null);

        Assert.Equal((2, 0, 1), (result.Added, result.Changed, result.StockCounts));
        var rice = f.App.Catalog.FindByCode("8900000000011")!;
        Assert.Equal(("Rice", "Grocery", "R1", "kg", 6_000L, 5_500L, 4_500L, "GST5", 10_000L), (rice.Name, rice.Category, rice.Sku, rice.Unit, rice.PriceMinor, rice.TradePriceMinor, rice.CostMinor, rice.TaxCode, rice.ReorderMilli));
        var soap = f.App.Catalog.FindByCode("S1")!;
        Assert.Equal((3_550L, "GST18"), (soap.PriceMinor, soap.TaxCode));
        Assert.Null(soap.TradePriceMinor);
        // 100 kg at 45.00 = 4,500.00 on the shelf
        Assert.Equal(100_000, f.App.Catalog.OnHandMilli(rice.Id));
        Assert.Equal(450_000, f.App.Catalog.StockList().Single(x => x.ItemId == rice.Id).ValueMinor);
        Assert.True(File.Exists(result.Backup));
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "import" && a.Detail!.Contains("items.csv") && a.Detail.Contains("2 item(s) added"));
        Assert.Equal("spreadsheet", f.App.Db.Scalar("SELECT source_kind FROM import_runs ORDER BY id DESC LIMIT 1"));
    }

    [Fact]
    public void A_column_left_empty_leaves_that_field_of_an_item_that_is_there_alone_and_a_changed_one_is_listed_with_before_and_after()
    {
        using var f = Shop();
        var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", Barcode = "8900000000011", Category = "Grocery", PriceMinor = 6_000, CostMinor = 4_500, TaxClass = "GST5", Unit = "kg" });

        var check = Check(f, "Barcode,Price,Cost price\n8900000000011,70,\n");
        var line = Assert.Single(check.Lines);

        Assert.Equal(("change", 2), (line.Action, line.Row));
        Assert.Equal("Price ₹60.00 → ₹70.00", line.Detail);
        f.App.ItemSheets.Import(check, null);
        var after = f.App.Catalog.Get(rice.Id)!;
        Assert.Equal((7_000L, 4_500L, "Grocery", "Rice", "GST5"), (after.PriceMinor, after.CostMinor, after.Category, after.Name, after.TaxCode));
    }

    [Fact]
    public void An_item_is_found_by_its_barcode_then_its_sku_then_its_name_and_the_stock_of_an_item_that_is_there_is_not_touched()
    {
        using var f = Shop();
        var byBarcode = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Tea", Barcode = "111", Sku = "T1", PriceMinor = 1_000, TrackStock = true });
        var bySku = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Coffee", Sku = "C1", PriceMinor = 2_000 });
        var byName = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Sugar", PriceMinor = 3_000 });

        var check = Check(f, "Name,Barcode,SKU,Price,Opening stock\nTea,111,,15,50\nCoffee,,C1,25,\nsugar,,,35,\n");

        Assert.Equal((0, 3, 0), (check.ToAdd, check.ToChange, check.Same));
        Assert.Contains(check.Notes, n => n.Contains("Row 2") && n.Contains("not changed from here"));
        f.App.ItemSheets.Import(check, null);
        Assert.Equal((1_500L, 2_500L, 3_500L), (f.App.Catalog.Get(byBarcode.Id)!.PriceMinor, f.App.Catalog.Get(bySku.Id)!.PriceMinor, f.App.Catalog.Get(byName.Id)!.PriceMinor));
        Assert.Equal(0, f.App.Catalog.OnHandMilli(byBarcode.Id));   // a count of an item that is there is made on the Products screen
    }

    [Fact]
    public void An_item_that_is_in_the_shop_exactly_as_the_row_says_is_the_same_and_a_file_of_only_such_rows_has_nothing_to_write()
    {
        using var f = Shop();
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", Barcode = "111", PriceMinor = 6_000, TaxClass = "GST5", Unit = "kg" });

        var check = Check(f, "Name,Barcode,Price,Tax,Unit\nRice,111,60.00,5,kg\n");

        Assert.Equal(("same", "As it is"), (check.Lines[0].Action, check.Lines[0].Detail));
        Assert.Equal("sheet-nothing", Assert.Throws<HubException>(() => f.App.ItemSheets.Import(check, null)).Code);
    }

    [Theory]
    [InlineData("18", "GST18")]
    [InlineData("5%", "GST5")]
    [InlineData("GST 18%", "GST18")]
    [InlineData("gst5", "GST5")]
    [InlineData("standard", "GST18")]
    [InlineData("exempt", "GSTEX")]
    [InlineData("GST12", "GST12")]
    public void A_tax_can_be_written_as_a_percent_the_label_the_code_or_a_class(string typed, string expected)
    {
        using var f = Shop();

        f.App.ItemSheets.Import(Check(f, $"Name,Price,Tax\nThing,10,{typed}\n"), null);

        Assert.Equal(expected, f.App.Catalog.Search("Thing", null, null, 10).Single().TaxCode);
    }

    [Fact]
    public void A_file_saved_with_semicolons_a_mark_and_quoted_names_is_read_the_same()
    {
        using var f = Shop();

        var check = Check(f, "﻿Name;Price;Category\r\n\"Salt; fine\";12,50;\"Spices, dry\"\r\n");
        f.App.ItemSheets.Import(check, null);

        var item = f.App.Catalog.Search("Salt", null, null, 10).Single();
        Assert.Equal(("Salt; fine", 1_250L, "Spices, dry"), (item.Name, item.PriceMinor, item.Category));
    }

    [Fact]
    public void The_on_sale_column_sets_an_item_off_sale_and_back()
    {
        using var f = Shop();
        f.App.ItemSheets.Import(Check(f, "Name,Price,On sale\nOld stock,10,no\nNew stock,10,yes\n"), null);
        Assert.False(f.App.Catalog.Search("Old", null, null, 10, includeInactive: true).Single().Active);
        Assert.True(f.App.Catalog.Search("New", null, null, 10).Single().Active);

        f.App.ItemSheets.Import(Check(f, "Name,On sale\nOld stock,yes\n"), null);

        Assert.True(f.App.Catalog.Search("Old", null, null, 10).Single().Active);
    }

    // ---- what is refused -----------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Every_row_that_cannot_be_used_is_listed_with_its_row_and_why_and_nothing_is_written()
    {
        using var f = Shop();
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Tea", Barcode = "111", Sku = "T1", PriceMinor = 1_000 });
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Coffee", Barcode = "222", Sku = "C1", PriceMinor = 1_000 });
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Dup", PriceMinor = 1 });
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "dup", PriceMinor = 2 });
        var check = Check(f, "Name,Barcode,SKU,Price,Tax,Kind\n" +
            ",,,10,,\n" +                            // row 2: no name
            "A,,,abc,,\n" +                          // row 3: not a price
            "B,,,-5,,\n" +                           // row 4: below nothing
            "C,,,10,GST99,\n" +                      // row 5: unknown tax
            "D,,,10,,spaceship\n" +                  // row 6: unknown kind
            "E,999,,10,,\n" +                        // row 7: fine
            "E2,999,,10,,\n" +                       // row 8: the same barcode as row 7
            "F,111,C1,10,,\n" +                      // row 9: barcode of Tea, SKU of Coffee
            "Dup,,,10,,\n");                         // row 10: two items are called Dup

        Assert.True(check.HasProblems);
        var byRow = check.Problems.ToDictionary(p => p.Row, p => p.Message);
        Assert.Contains("no name", byRow[2]);
        Assert.Contains("price", byRow[3]);
        Assert.Contains("below nothing", byRow[4]);
        Assert.Contains("GST99", byRow[5]);
        Assert.Contains("spaceship", byRow[6]);
        Assert.Contains("row 7", byRow[8]);
        Assert.Contains("two different items", byRow[9]);
        Assert.Contains("More than one item is called", byRow[10]);
        Assert.DoesNotContain(7, byRow.Keys);
        Assert.Equal("sheet-problems", Assert.Throws<HubException>(() => f.App.ItemSheets.Import(check, null)).Code);
        Assert.Empty(f.App.Catalog.Search("E", null, null, 10).Where(i => i.Name == "E"));
    }

    [Theory]
    [InlineData("", "empty")]
    [InlineData("Name\n", "no items under")]
    [InlineData("Price,Category\n10,Food\n", "called Name")]
    [InlineData("Name,Name\nA,B\n", "twice")]
    public void A_file_that_has_no_name_column_no_items_or_a_column_twice_is_refused_in_plain_words(string text, string fragment)
    {
        using var f = Shop();

        var check = Check(f, text);

        Assert.Contains(check.Problems, p => p.Message.Contains(fragment));
    }

    [Fact]
    public void A_column_the_hub_does_not_know_is_noted_and_does_not_stop_the_import()
    {
        using var f = Shop();

        var check = Check(f, "Name,Price,Shelf life\nRice,10,2 years\n");

        Assert.False(check.HasProblems);
        Assert.Contains(check.Notes, n => n.Contains("Shelf life") && n.Contains("not used"));
    }

    [Fact]
    public void If_the_shops_items_change_between_the_check_and_the_import_nothing_is_written()
    {
        using var f = Shop();
        var check = Check(f, "Name,Barcode,Price\nRice,111,10\n");
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Someone else's rice", Barcode = "111", PriceMinor = 5 });

        var ex = Assert.Throws<HubException>(() => f.App.ItemSheets.Import(check, null));

        Assert.Equal("sheet-changed", ex.Code);
        Assert.Single(f.App.Catalog.Search(null, null, null, 100));
    }

    [Fact]
    public void One_row_the_database_refuses_undoes_the_whole_import()
    {
        using var f = Shop();
        var check = Check(f, "Name,Price\nGood one,10\nToo long " + new string('x', 200) + ",10\n");

        // the name is longer than an item name may be: it is found at the check, with its row
        Assert.Contains(check.Problems, p => p.Row == 3 && p.Message.Contains("too long"));
        Assert.Throws<HubException>(() => f.App.ItemSheets.Import(check, null));
        Assert.Empty(f.App.Catalog.Search(null, null, null, 100));
    }

    // ---- going out, and coming back ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void What_goes_out_comes_back_in_as_exactly_the_same_items()
    {
        using var f = Shop();
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice, long grain", Category = "Grocery", Barcode = "111", Sku = "R1", Unit = "kg", PriceMinor = 6_050, TradePriceMinor = 5_500, CostMinor = 4_500, TaxClass = "GST5", ReorderMilli = 10_500, TrackStock = true });
        var soap = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "=Soap", PriceMinor = 3_550, TaxClass = "standard" });
        f.App.Catalog.SetActive(soap.Id, false);
        f.App.Catalog.Adjust(f.App.Catalog.FindByCode("111")!.Id, 25_500, "delivery");

        var sent = f.App.ItemSheets.Export();
        var check = Check(f, sent);

        Assert.False(check.HasProblems, string.Join("; ", check.Problems.Select(p => p.Message)));
        Assert.Equal((0, 0, 2), (check.ToAdd, check.ToChange, check.Same));
        // and into a new shop it makes the same items, with the stock that was on the shelf
        using var other = Shop();
        other.App.ItemSheets.Import(other.App.ItemSheets.Check("sent.csv", sent), null);
        var rice = other.App.Catalog.FindByCode("111")!;
        Assert.Equal(("Rice, long grain", "Grocery", "R1", 6_050L, 5_500L, 4_500L, "GST5", 10_500L), (rice.Name, rice.Category, rice.Sku, rice.PriceMinor, rice.TradePriceMinor, rice.CostMinor, rice.TaxCode, rice.ReorderMilli));
        Assert.Equal(25_500, other.App.Catalog.OnHandMilli(rice.Id));
        var copy = other.App.Catalog.Search("Soap", null, null, 10, includeInactive: true).Single();
        Assert.Equal(("=Soap", false), (copy.Name, copy.Active));
    }

    [Fact]
    public void The_empty_sheet_to_fill_in_has_the_columns_of_the_shops_country_and_nothing_else()
    {
        using var f = Shop();

        var rows = Csv.Read(f.App.ItemSheets.Template());

        var header = Assert.Single(rows);
        Assert.Equal(new[] { "Name", "Category", "Barcode", "SKU", "Unit", "Price", "Trade price", "Cost price", "Tax" }, header.Take(9).ToArray());
        Assert.Contains("Reorder level", header);
        Assert.Contains("Opening stock", header);
        // India's pack names a code for the goods (and an extra tax): their columns carry the pack's own words, and a country whose pack has neither has neither column
        Assert.Contains(f.App.Shop.Current.Country.Tax.ItemCode!.Label, header);
        using var other = new HubFixture("US", "retail");
        var usHeader = Assert.Single(Csv.Read(other.App.ItemSheets.Template()));
        Assert.DoesNotContain(f.App.Shop.Current.Country.Tax.ItemCode!.Label, usHeader);
    }

    [Fact]
    public void The_goods_code_and_the_extra_tax_of_a_country_that_asks_for_them_come_in_under_the_packs_own_words()
    {
        using var f = Shop();
        var codeLabel = f.App.Shop.Current.Country.Tax.ItemCode!.Label;
        var extraLabel = f.App.Shop.Current.Country.Tax.ExtraTax!.Label;

        f.App.ItemSheets.Import(Check(f, $"Name,Price,{codeLabel},{extraLabel}\nSoda,40,220210,12\n"), null);

        var soda = f.App.Catalog.Search("Soda", null, null, 10).Single();
        Assert.Equal(("220210", "12"), (soda.Attrs[ItemAttrs.Code], soda.Attrs[ItemAttrs.ExtraTax]));
    }
}

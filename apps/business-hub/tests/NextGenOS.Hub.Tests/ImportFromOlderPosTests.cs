using System.Text;
using System.Text.Json;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Import;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Moving a shop across from the older POS: the study's worked examples become the Hub's tests (docs/old-programs/02-masters-accounting-reports.md and 01-selling-buying-stock.md).
/// The old database is a small in-memory stand-in (<see cref="OldPos"/>); the real SQL Server reader is NOT exercised here (no SQL Server in this environment).
/// </summary>
public class ImportFromOlderPosTests
{
    private static ImportPlan PlanOf(HubFixture f, OldSystemData data) =>
        PosMapper.Plan("pos-sqlserver", "pc1/shopdata", "test", data, f.App.Shop.Current, ExistingState.None, f.App.Catalog.WouldTrackStock);

    private static PlannedItem Item(ImportPlan plan, string key) => plan.Items.Single(i => i.OldKey == key);

    private static PlannedParty Person(ImportPlan plan, string key) => plan.Parties.Single(p => p.OldKey == key);

    private static ReportLine Line(MatchReport report, string key) => report.Lines.Single(l => l.Key == key);

    private static long Count(HubApp app, string table) => Convert.ToInt64(app.Db.Scalar($"SELECT COUNT(*) FROM {table}"));

    private static readonly string[] Tables = ["items", "parties", "stock_moves", "documents", "audit_log", "import_runs", "import_id_map", "party_opening_balances", "settings", "payments"];

    private static Dictionary<string, long> Snapshot(HubApp app) => Tables.ToDictionary(t => t, t => Count(app, t));

    // ---- the maps and the traps, exactly -----------------------------------------------------------------------------------------

    [Fact]
    public void A_product_is_mapped_by_the_study_the_wholesale_price_is_not_the_reorder_level_and_the_barcode_comes_from_the_stock_row()
    {
        using var f = new HubFixture();
        var plan = PlanOf(f, OldPos.Study());

        var rice = Item(plan, "lot:11").Input;
        Assert.Equal("Basmati rice 5 kg", rice.Name);                  // the padding of the old fixed-width column is gone
        Assert.Equal("P-0001", rice.Sku);
        Assert.Equal("8901000000019", rice.Barcode);                    // the real barcode is the stock row's; Product.Barcode is "0"
        Assert.Equal(13000, rice.PriceMinor);                           // M8: retail 130.00
        Assert.Equal(12000, rice.TradePriceMinor);                      // THE TRAP: ReorderPoint 120 is the WHOLESALE price
        Assert.Equal(5000, rice.ReorderMilli);                          // the reorder level is MinStock 5, not 120
        Assert.Equal(10000, rice.CostMinor);                            // M8: cost 100.00
        Assert.Equal("GST5", rice.TaxClass);                            // two half rates of 2.5 are 5 percent
        Assert.Equal("Pcs", rice.Unit);
        Assert.Equal("Grocery", rice.Category);                         // the category comes through the sub-category, which holds the category's NAME (padded)
        Assert.Equal("Rice and sugar", rice.Attrs["subCategory"]);
        Assert.Equal("1006", rice.Attrs["hsn"]);
        Assert.Equal("150.00", rice.Attrs["mrp"]);
        Assert.True(Item(plan, "lot:11").Active);

        // The wholesale price is absent when the old program has none: not 0.
        Assert.Null(Item(plan, "lot:12").Input.TradePriceMinor);
        Assert.Equal(0, Item(plan, "lot:12").Input.ReorderMilli);
    }

    [Theory]
    [InlineData(9, 9, "GST18")]
    [InlineData(2.5, 2.5, "GST5")]
    [InlineData(6, 6, "GST12")]       // M5 and M6: a rate is stored as two equal halves; an old rate the pack still lists as "old" is still found
    [InlineData(0, 0, "GST0")]
    public void Tax_is_found_in_the_countrys_list_from_the_two_half_rates(double half1, double half2, string expected)
    {
        using var f = new HubFixture();
        var data = OldPos.Only(d => d with { Products = [new(1, "P", "Thing", null, null, 1m, 2m, 0m, 0m, (decimal)half1, (decimal)half2, 0m, "0", "Pcs", 0m, "Yes", "Inclusive")], Lots = [] });
        Assert.Equal(expected, PlanOf(f, data).Items.Single().Input.TaxClass);
    }

    [Fact]
    public void Exempt_and_no_tax_follow_the_old_sale_tax_type_and_an_unknown_rate_is_listed_for_a_person_to_look_at()
    {
        using var f = new HubFixture();
        Assert.Equal("GSTEX", Item(PlanOf(f, OldPos.Study()), "product:7").Input.TaxClass);

        var data = OldPos.Only(d => d with { Products = [new(1, "P", "No tax thing", null, null, 1m, 2m, 0m, 0m, 9m, 9m, 0m, "0", "Pcs", 0m, "Yes", "No Taxes"), new(2, "Q", "Odd rate", null, null, 1m, 2m, 0m, 0m, 3.5m, 3.5m, 0m, "0", "Pcs", 0m, "Yes", "Inclusive")], Lots = [] });
        var plan = PlanOf(f, data);
        Assert.Equal("GST0", plan.Items[0].Input.TaxClass);
        Assert.Equal("standard", plan.Items[1].Input.TaxClass);
        var note = plan.Report.Findings.Single(x => x.Code == "tax-rate");
        Assert.Equal(FindingLevels.Look, note.Level);
        Assert.Contains("Odd rate (7%)", note.Examples);
    }

    [Fact]
    public void Several_barcodes_of_one_product_become_several_items_with_their_own_price_and_stock_and_the_reorder_level_is_set_once()
    {
        using var f = new HubFixture();
        var plan = PlanOf(f, OldPos.Study());
        var blue = Item(plan, "lot:13");
        var red = Item(plan, "lot:14");
        Assert.Equal("T-shirt (M, Blue, B1)", blue.Input.Name);
        Assert.Equal("T-shirt (L, Red)", red.Input.Name);
        Assert.Equal(40000, blue.Input.PriceMinor);
        Assert.Equal(45000, red.Input.PriceMinor);                      // the stock row's price is the one the till read
        Assert.Equal(32000, red.Input.TradePriceMinor);
        Assert.Equal(4000, blue.StockMilli);
        Assert.Equal(3000, red.StockMilli);
        Assert.Equal(2000, blue.Input.ReorderMilli);
        Assert.Equal(0, red.Input.ReorderMilli);
        Assert.Contains(plan.Report.Findings, x => x.Code == "several-barcodes" && x.Count == 1);
        Assert.Contains(plan.Report.Findings, x => x.Code == "price-differs");
    }

    [Fact]
    public void The_placeholder_barcode_a_used_barcode_a_switched_off_product_and_a_negative_count_are_all_handled_and_listed()
    {
        using var f = new HubFixture();
        var plan = PlanOf(f, OldPos.Study());
        Assert.Null(Item(plan, "product:6").Input.Barcode);             // no stock row, and Product.Barcode "0" is not a barcode
        Assert.Equal("", Item(plan, "product:6").Input.Unit);           // no unit in the old program: the Hub's own default ("pc") is applied when it is saved
        Assert.Null(Item(plan, "lot:17").Input.Barcode);                // product 1 already has this barcode
        Assert.Contains(plan.Report.Findings, x => x.Code == "barcode-twice" && x.Level == FindingLevels.Look);
        Assert.False(Item(plan, "lot:15").Active);                      // Status "No"
        Assert.False(Item(plan, "lot:15").MovesStock);                  // nothing to count
        Assert.Equal(-2000, Item(plan, "lot:16").StockMilli);           // S2: moved as it is
        Assert.True(Item(plan, "lot:16").MovesStock);
        Assert.Contains(plan.Report.Findings, x => x.Code == "negative-stock");
        Assert.Contains(plan.Report.Findings, x => x.Code == "damaged");
    }

    [Fact]
    public void Rows_that_cannot_be_moved_are_left_out_with_a_plain_reason()
    {
        using var f = new HubFixture();
        var plan = PlanOf(f, OldPos.Study());
        Assert.DoesNotContain(plan.Items, i => i.OldKey == "product:8");
        Assert.Contains(plan.Report.Skipped, s => s.OldKey == "product:8" && s.Reason == "The product has no name.");
        Assert.Contains(plan.Report.Skipped, s => s.OldKey == "lot:99" && s.Reason.Contains("does not exist"));
        Assert.Contains(plan.Report.Skipped, s => s.OldKey == "customer:1" && s.Reason.Contains("walk-in"));
        Assert.Equal(3, plan.Report.Skipped.Count);
    }

    // ---- people ---------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Customers_and_suppliers_are_mapped_and_their_balance_is_the_running_ledger_with_the_typed_opening_balance_counted_once()
    {
        using var f = new HubFixture();
        var plan = PlanOf(f, OldPos.Study());

        var asha = Person(plan, "customer:2");
        Assert.Equal("C-0002", asha.Input.Code);
        Assert.Equal("Asha", asha.Input.Name);
        Assert.Equal("12 Market Road, Pune, Maharashtra, 411001", asha.Input.Address);
        Assert.Equal("27", asha.Input.Region);                          // the state NAME found in the country's own list
        Assert.Equal("TAXNO-1", asha.Input.TaxId);
        Assert.Equal("CARD-1", asha.Input.CardBarcode);
        Assert.Equal("good customer", asha.Input.Notes);
        Assert.Equal(60000, asha.BalanceMinor);                         // C4: Sales D 1,000 less Receipt C 400: owes 600.00
        Assert.Equal(50000, Person(plan, "customer:3").BalanceMinor);   // C1: opening DR 500 is the ledger's first row: 500.00, not 1,000.00
        Assert.Equal(-20000, Person(plan, "customer:4").BalanceMinor);  // C2: opening CR 200: the shop owes the customer 200.00
        Assert.Equal(0, Person(plan, "customer:5").BalanceMinor);       // C10: no rows at all
        Assert.Equal(0, Person(plan, "customer:6").BalanceMinor);       // typed 50, but not in the ledger: the ledger rules
        Assert.Contains(plan.Report.Findings, x => x.Code == "opening-missing");

        Assert.Equal(-390000, Person(plan, "supplier:1").BalanceMinor); // S3: the shop owes 3,900.00
        Assert.Equal(30000, Person(plan, "supplier:2").BalanceMinor);   // SM4: the supplier owes the shop 300.00
        Assert.Equal(-690000, Person(plan, "supplier:3").BalanceMinor); // S4 and SM3: 6,900.00 owed
        Assert.Equal("27", Person(plan, "supplier:1").Input.Region);
        Assert.DoesNotContain(plan.Parties, p => p.OldKey == "customer:1");   // the walk-in customer is not a record
    }

    [Theory]
    [InlineData(1000, 900, 10000)]     // C6: owes 100 after a cash receipt of 500 on a balance of 600 (here as plain sums)
    [InlineData(1000, 1200, -20000)]   // C7: paid more than owed: in credit 200
    [InlineData(1000, 1000, 0)]        // C3: paid in full
    [InlineData(1000, 750, 25000)]     // C8: a return of 250 not paid back
    public void A_balance_is_credit_minus_debit_of_the_ledger_whatever_the_rows_were(double debit, double credit, long expectedMinor)
    {
        using var f = new HubFixture();
        var data = OldPos.Only(d => d with { CustomerLedger = [new("C-0002", (decimal)debit, (decimal)credit, 3, 0)] });
        Assert.Equal(expectedMinor, Person(PlanOf(f, data), "customer:2").BalanceMinor);
    }

    [Theory]
    [InlineData(1000, "Yes", 100000, false)]        // L1: limit 1,000 and enforced
    [InlineData(1000, "No", 100_000_000_000, true)] // L3: the amount is 1,000 but the switch says not enforced: NOT limit 0
    [InlineData(0, "Yes", 0, false)]                // L7: limit 0 and enforced is no credit at all, in both programs
    [InlineData(0, "No", 100_000_000_000, true)]    // L8: not enforced, any amount
    [InlineData(1000, "", 100_000_000_000, true)]   // a blank switch is not "Yes", and the old program only checks the limit for "Yes"
    public void A_credit_limit_counts_only_when_its_switch_says_yes_and_a_customer_with_no_limit_never_becomes_limit_zero(double limit, string sw, long expectedMinor, bool noted)
    {
        using var f = new HubFixture();
        var customer = new OldCustomer(2, "C-0002", "Asha", null, null, null, null, null, null, null, null, null, 0m, null, (decimal)limit, sw, null, null);
        var plan = PlanOf(f, OldPos.Only(d => d with { Customers = [customer], CustomerLedger = [] }));
        var party = Person(plan, "customer:2");
        Assert.Equal(expectedMinor, party.Input.CreditLimitMinor);
        Assert.Equal(noted, party.Input.Notes?.Contains("not enforced") == true);
        Assert.Equal(noted, plan.Report.Findings.Any(x => x.Code == "no-limit" && x.Level == FindingLevels.Look));
        if (noted) Assert.Contains(f.App.Shop.Current.Money(expectedMinor), plan.Report.Findings.Single(x => x.Code == "no-limit").Text);   // said in the shop's own money
    }

    [Fact]
    public void Things_the_hub_cannot_keep_yet_are_listed_for_a_person_to_look_at_and_never_dropped_silently()
    {
        using var f = new HubFixture();
        var plan = PlanOf(f, OldPos.Study());
        var codes = plan.Report.Findings.ToDictionary(x => x.Code);
        Assert.Equal(FindingLevels.Look, codes["customer-discount"].Level);       // Bilal had a fixed discount
        Assert.Equal(FindingLevels.Look, codes["email"].Level);                   // Chen's address
        Assert.Equal(FindingLevels.Look, codes["region"].Level);                  // Dana's state
        Assert.Equal(FindingLevels.Look, codes["card-twice"].Level);              // Dana's card is Asha's
        Assert.Null(Person(plan, "customer:5").Input.CardBarcode);
        Assert.Null(Person(plan, "customer:4").Input.Email);
        Assert.Null(Person(plan, "customer:5").Input.Region);
        Assert.Equal("5 Hill Street, Narnia", Person(plan, "customer:5").Input.Address);   // the state text stays in the address
        Assert.Equal(FindingLevels.Look, codes["ledger-unknown-customer"].Level);
        Assert.Contains("C-0099", codes["ledger-unknown-customer"].Examples);
        Assert.Equal(FindingLevels.Info, codes["not-moved"].Level);
    }

    // ---- the match report -------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_match_report_puts_the_old_counts_and_money_next_to_what_the_hub_would_hold()
    {
        using var f = new HubFixture();
        var report = PlanOf(f, OldPos.Study()).Report;

        void Expect(string key, long old, long added, long skipped)
        {
            var line = Line(report, key);
            Assert.Equal(old, line.Old);
            Assert.Equal(added, line.Added);
            Assert.Equal(0, line.Before);
            Assert.Equal(skipped, line.Skipped);
            Assert.Equal(old - added, line.Difference);
            Assert.Equal(0, line.Unexplained);
            Assert.True(line.Matches, key);
        }
        Expect("items", 11, 9, 2);
        Expect("customers", 6, 5, 1);
        Expect("suppliers", 3, 3, 0);
        Expect("stock-quantity", 33_000, 28_000, 5_000);
        Expect("stock-value", 287_000, 287_000, 0);           // S12: 7 at 50.00 is 350.00; 10 at 100.00 is 1,000.00; 7 shirts at 200.00 is 1,400.00; 6 at 20.00 is 120.00. The negative row counts for nothing.
        Expect("customers-owe", 111_000, 110_000, 1_000);     // the 10.00 of a code nobody has is not moved, and is shown
        Expect("customers-credit", 20_000, 20_000, 0);
        Expect("suppliers-owe", 30_000, 30_000, 0);
        Expect("suppliers-owed", 1_080_000, 1_080_000, 0);
        Assert.False(report.HasBlocking);
        Assert.True(report.CanImport);
        Assert.Equal((9, 5, 3, 6, 6), (report.ItemsToAdd, report.CustomersToAdd, report.SuppliersToAdd, report.StockMovesToAdd, report.BalancesToAdd));
        Assert.NotEmpty(report.Fingerprint);
    }

    [Fact]
    public void Stock_comes_from_the_live_stock_rows_and_the_movement_history_is_never_read()
    {
        Assert.Contains(PosSqlServerQueries.All, q => q.Contains("FROM Temp_Stock"));
        Assert.DoesNotContain(PosSqlServerQueries.All, q => q.Contains("StockMovement", StringComparison.OrdinalIgnoreCase));
        Assert.DoesNotContain(PosSqlServerQueries.All, q => q.Contains("Product_OpeningStock", StringComparison.OrdinalIgnoreCase));   // the set-up record, not the live stock
    }

    [Fact]
    public void The_report_is_written_in_the_shops_own_money_and_has_no_country_word_in_its_fixed_text()
    {
        using var f = new HubFixture("DE", "retail");
        var data = OldPos.Only(d => d with
        {
            Products = [new(1, "P", "Thing", null, null, 5m, 9m, 0m, 0m, 9.5m, 9.5m, 0m, "0", "Pcs", 0m, "Yes", "Inclusive")],
            Lots = [new(1, 1, "X1", 2m, 0m, 0m, 9m, 0m, null, null, null)],
            Customers = [d.Customers[2]],    // Bilal: no limit in the old program
            CustomerLedger = [], Suppliers = [], SupplierLedger = [],
        });
        var report = PlanOf(f, data).Report;
        var fixedText = string.Join("\n", report.Lines.Select(l => l.Label).Concat(report.Findings.Select(x => x.Text)));
        foreach (var word in new[] { "India", "Indian", "rupee", "Hindi", "GST", "CGST", "SGST", "IGST", "HSN", "INR", "₹" })
            Assert.DoesNotContain(word, fixedText, StringComparison.OrdinalIgnoreCase);
        // The same sentence in another country uses that country's money: the euro here, with its own way of writing it.
        var no = Assert.Single(report.Findings, x => x.Code == "no-limit");
        Assert.Contains("€", no.Text);
        Assert.Contains(f.App.Shop.Current.Money(100_000_000_000), no.Text);
        // 9.5 + 9.5 is 19: the German list has 19, not an Indian one.
        Assert.Equal("MWST19", PlanOf(f, data).Items.Single().Input.TaxClass);
    }

    [Fact]
    public void A_shop_whose_money_has_no_decimals_cannot_take_cents_so_it_is_listed_and_the_move_is_blocked()
    {
        using var f = new HubFixture("JP", "retail");
        var data = OldPos.Only(d => d with
        {
            Products = [new(1, "P", "Thing", null, null, 5m, 9.5m, 0m, 0m, 5m, 5m, 0m, "0", "Pcs", 0m, "Yes", "Inclusive")],
            Lots = [], Customers = [d.Customers[1]], CustomerLedger = [new("C-0002", 10.5m, 0m, 1, 0)], Suppliers = [], SupplierLedger = [],
        });
        var plan = PlanOf(f, data);
        Assert.Contains(plan.Report.Skipped, s => s.Reason.Contains("more decimals"));             // the price with a half
        Assert.True(plan.Report.HasBlocking);                                                          // the balance 10.50 cannot be a whole number of the currency
        Assert.False(plan.Report.CanImport);
        Assert.Contains(plan.Report.Findings, x => x.Level == FindingLevels.Blocking);
        var ex = Assert.Throws<HubException>(() => f.App.Importer.Import(f.App.Importer.CheckData("pos-sqlserver", "pc1/shopdata", "test", data), 1));
        Assert.Equal("import-blocked", ex.Code);
        Assert.Equal(0, Count(f.App, "items"));
    }

    // ---- check writes nothing; import writes all or nothing ----------------------------------------------------------------------------

    [Fact]
    public void A_check_writes_nothing_at_all_and_makes_no_copy()
    {
        using var f = new HubFixture();
        var before = Snapshot(f.App);
        var source = new FakeOldSystem(OldPos.Study());

        var check = f.App.Importer.Check(source);

        Assert.Equal(1, source.Reads);
        Assert.Equal(before, Snapshot(f.App));
        Assert.Null(f.App.Db.LastBackup);
        Assert.True(check.Report.CanImport);
    }

    [Fact]
    public void An_import_writes_what_the_report_promised_after_a_copy_of_the_database_and_leaves_a_record()
    {
        using var f = new HubFixture();
        var check = f.App.Importer.Check(new FakeOldSystem(OldPos.Study()));
        var ownerId = f.App.Users.Create("owner", "Olivia Owner", NextGenOS.Hub.Security.Roles.Owner, "correct horse battery").Id;

        var result = f.App.Importer.Import(check, ownerId);

        Assert.Equal((9, 5, 3, 6, 6), (result.Items, result.Customers, result.Suppliers, result.StockMoves, result.Balances));
        Assert.True(File.Exists(result.BackupPath));
        Assert.Contains("before-import-", result.BackupPath);
        Assert.Equal(9, Count(f.App, "items"));
        Assert.Equal(5, Count(f.App, "parties WHERE kind = 'customer'"));
        Assert.Equal(3, Count(f.App, "parties WHERE kind = 'supplier'"));

        // The Hub now holds the numbers the report showed.
        Assert.Equal(28_000, f.App.Catalog.StockList().Sum(s => s.OnHandMilli));
        Assert.Equal(287_000, f.App.Reports.StockValues().Sum(v => v.ValueMinor));
        var rice = f.App.Catalog.FindByCode("8901000000019")!;
        Assert.Equal("Basmati rice 5 kg", rice.Name);
        Assert.Equal(12000, rice.TradePriceMinor);
        Assert.Equal(5000, rice.ReorderMilli);
        Assert.Equal(10_000, f.App.Catalog.OnHandMilli(rice.Id));
        Assert.False(f.App.Catalog.Search("Old tin", includeInactive: true).Single().Active);
        Assert.Equal(-2000, f.App.Catalog.OnHandMilli(f.App.Catalog.Search("Overdrawn").Single().Id));

        // People, credit and opening balances.
        var people = f.App.Parties.Search(includeInactive: true, limit: 100).ToDictionary(p => p.Name);
        Assert.Equal(100_000, people["Asha"].CreditLimitMinor);
        Assert.Equal(100_000_000_000, people["Bilal"].CreditLimitMinor);   // not enforced in the old program: NOT zero
        Assert.Equal(0, people["Chen"].CreditLimitMinor);
        Assert.Equal(60_000, f.App.Importer.OpeningBalance(people["Asha"].Id));
        Assert.Equal(-20_000, f.App.Importer.OpeningBalance(people["Chen"].Id));
        Assert.Null(f.App.Importer.OpeningBalance(people["Dana"].Id));
        Assert.Equal(-390_000, f.App.Importer.OpeningBalance(people["Mill Co"].Id));
        Assert.Equal(30_000, f.App.Importer.OpeningBalance(people["Dairy Ltd"].Id));

        // Remembered, logged, audited.
        Assert.Equal(17, Count(f.App, "import_id_map"));
        var runs = f.App.Importer.Runs();
        var run = Assert.Single(runs);
        Assert.Equal((9, 5, 3, 6), (run.Items, run.Customers, run.Suppliers, run.Balances));
        Assert.Equal("Olivia Owner", run.Who);
        var saved = JsonSerializer.Deserialize<JsonElement>((string)f.App.Db.Scalar("SELECT report FROM import_runs")!);
        Assert.Equal(11, saved.GetProperty("lines")[0].GetProperty("old").GetInt64());
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "import" && a.UserId == ownerId && a.Detail!.Contains("9 item(s)"));
    }

    [Fact]
    public void Running_it_again_adds_nothing_and_a_new_row_in_the_old_system_adds_only_that_row()
    {
        using var f = new HubFixture();
        f.App.Importer.Import(f.App.Importer.Check(new FakeOldSystem(OldPos.Study())), 1);
        var after = Snapshot(f.App);

        var again = f.App.Importer.Check(new FakeOldSystem(OldPos.Study()));
        Assert.True(again.Report.NothingToAdd);
        Assert.False(again.Report.CanImport);
        Assert.Equal((0, 0, 0, 0, 0), (again.Report.ItemsToAdd, again.Report.CustomersToAdd, again.Report.SuppliersToAdd, again.Report.StockMovesToAdd, again.Report.BalancesToAdd));
        var items = Line(again.Report, "items");
        Assert.Equal((11L, 0L, 9L, 2L), (items.Old, items.Added, items.Before, items.Skipped));   // what was moved before is counted, not added again
        Assert.True(items.Matches);
        Assert.Equal("import-nothing", Assert.Throws<HubException>(() => f.App.Importer.Import(again, 1)).Code);
        Assert.Equal(after, Snapshot(f.App));

        // A product that is new in the old system is added alone; the rest stays as it was.
        var grown = OldPos.Only(d => d with
        {
            Products = [.. d.Products, new(10, "P-0010", "Tea 250 g", null, null, 30m, 45m, 0m, 0m, 9m, 9m, 0m, "0", "Pcs", 0m, "Yes", "Inclusive")],
            Lots = [.. d.Lots, new(18, 10, "TEA-1", 12m, 0m, 0m, 45m, 0m, null, null, null)],
        });
        var third = f.App.Importer.Check(new FakeOldSystem(grown));
        Assert.Equal((1, 0, 0, 1, 0), (third.Report.ItemsToAdd, third.Report.CustomersToAdd, third.Report.SuppliersToAdd, third.Report.StockMovesToAdd, third.Report.BalancesToAdd));
        f.App.Importer.Import(third, 1);
        Assert.Equal(after["items"] + 1, Count(f.App, "items"));
        Assert.Equal(after["parties"], Count(f.App, "parties"));
        Assert.Equal(after["party_opening_balances"], Count(f.App, "party_opening_balances"));
        Assert.Equal(12_000, f.App.Catalog.OnHandMilli(f.App.Catalog.FindByCode("TEA-1")!.Id));
        Assert.Equal(2, f.App.Importer.Runs().Count);
    }

    [Fact]
    public void Another_old_database_is_not_mistaken_for_the_first()
    {
        using var f = new HubFixture();
        f.App.Importer.Import(f.App.Importer.Check(new FakeOldSystem(OldPos.Study(), id: "pc1/shopdata")), 1);
        var other = f.App.Importer.Check(new FakeOldSystem(OldPos.Only(d => d with { Lots = d.Lots.Where(l => l.Id != 11 && l.Id != 17).ToList() }), id: "pc2/otherdata"));
        // A different database: nothing there was moved before. (Its barcodes are taken, so they are listed, not duplicated.)
        Assert.Equal(0, Line(other.Report, "items").Before);
        Assert.Equal(9, other.Report.ItemsToAdd);
    }

    [Fact]
    public void A_failed_import_leaves_the_hub_exactly_as_it_was()
    {
        using var f = new HubFixture();
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Existing", PriceMinor = 100, TaxClass = "standard" });
        var check = f.App.Importer.Check(new FakeOldSystem(OldPos.Study()));
        // Something goes wrong half way: the 4th customer cannot be saved.
        f.App.Db.InTransaction((c, t) => NextGenOS.Hub.Data.HubDb.Exec(c, "CREATE TRIGGER stop_dana BEFORE INSERT ON parties WHEN NEW.name = 'Dana' BEGIN SELECT RAISE(ABORT, 'stopped on purpose'); END", t));
        var before = Snapshot(f.App);
        var stockBefore = f.App.Catalog.StockList().Sum(s => s.OnHandMilli);

        var ex = Assert.Throws<HubException>(() => f.App.Importer.Import(check, 1));

        Assert.Contains("Dana", ex.Message);
        Assert.Contains("nothing was moved", ex.Message);
        Assert.Equal(before, Snapshot(f.App));                 // not one row more in any table: no item, no person, no stock, no log, no map, no balance, no audit line
        Assert.Equal(stockBefore, f.App.Catalog.StockList().Sum(s => s.OnHandMilli));
        Assert.Empty(f.App.Importer.Runs());
        // Once the cause is gone, the same check can be imported.
        f.App.Db.InTransaction((c, t) => NextGenOS.Hub.Data.HubDb.Exec(c, "DROP TRIGGER stop_dana", t));
        Assert.Equal(9, f.App.Importer.Import(check, 1).Items);
    }

    [Fact]
    public void A_change_in_the_shop_since_the_check_makes_the_import_refuse_and_a_copy_that_cannot_be_made_stops_everything()
    {
        using var f = new HubFixture();
        var check = f.App.Importer.Check(new FakeOldSystem(OldPos.Study()));
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Taken", Barcode = "T-M-BLU", PriceMinor = 1, TaxClass = "standard" });   // someone used a planned barcode meanwhile
        var before = Snapshot(f.App);
        Assert.Equal("import-changed", Assert.Throws<HubException>(() => f.App.Importer.Import(check, 1)).Code);
        Assert.Equal(before, Snapshot(f.App));
    }

    // ---- the password -----------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_password_never_reaches_the_hubs_database_its_copy_the_report_the_audit_or_any_text_the_service_makes()
    {
        const string password = "Zx7!-pw-that-must-stay-in-memory";
        using var f = new HubFixture();
        var source = new FakeOldSystem(OldPos.Study(), password);   // the source holds it, like the real one does, while the check and the import run
        var check = f.App.Importer.Check(source);
        var result = f.App.Importer.Import(check, 1);

        var needles = new[] { Encoding.UTF8.GetBytes(password), Encoding.Unicode.GetBytes(password) };
        var files = new[] { f.App.Db.Path, f.App.Db.Path + "-wal", f.App.Db.Path + "-shm", result.BackupPath }.Where(File.Exists).ToList();
        Assert.True(files.Count >= 2);
        foreach (var file in files)
        {
            var bytes = File.ReadAllBytes(file);
            foreach (var needle in needles) Assert.True(bytes.AsSpan().IndexOf(needle) < 0, "the password was found in " + Path.GetFileName(file));
        }
        var everyText = string.Join("\n", f.App.Audit.Recent(500).Select(a => a.Detail))
            + JsonSerializer.Serialize(check.Report) + check.Describe + check.SourceId + string.Join("\n", f.App.Importer.Runs().Select(r => r.Source))
            + string.Join("\n", f.App.Db.Query("SELECT report FROM import_runs", r => r.GetString(0)));
        Assert.DoesNotContain(password, everyText);
        // The only place it is: the source in memory.
        Assert.Equal(password, source.Password);
    }
}

using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Data.SqlServer;

namespace SmartRetail.Pos.Tests.SqlServer;

/// <summary>Runs the SQL Server repositories against the real POS table definitions.</summary>
public sealed class SqlServerRepositoryTests : IClassFixture<PosTestDatabase>
{
    private readonly PosTestDatabase _database;

    public SqlServerRepositoryTests(PosTestDatabase database) => _database = database;

    private SqlDb Db => new(_database.ConnectionString, 15);

    [SqlServerFact]
    public async Task Product_search_trims_text_and_works_out_gst_stock_and_category()
    {
        var products = await new SqlServerProductRepository(Db).SearchAsync("rice", 10);

        var rice = Assert.Single(products);
        Assert.Equal(1, rice.Id);
        Assert.Equal("1001", rice.Code);
        Assert.Equal("Basmati Rice 5 kg", rice.Name);
        Assert.Equal("2000000000011", rice.Barcode);
        Assert.Equal("1006", rice.HsnCode);
        Assert.Equal("Staples", rice.Category);
        Assert.Equal(549m, rice.SellingPrice);
        Assert.Equal(599m, rice.Mrp);
        Assert.Equal(5m, rice.GstRatePercent);
        Assert.Equal(10m, rice.MinStock);
        Assert.Equal(7m, rice.StockInHand);
        Assert.True(rice.IsLowStock);
    }

    [SqlServerFact]
    public async Task Stock_batches_carry_the_code_the_till_scans_with_their_own_prices()
    {
        var batches = await new SqlServerProductRepository(Db).GetBatchesAsync(new[] { 1, 2, 3, 4, 99 });

        Assert.Equal(
            new[]
            {
                (1, "RICE-BATCH-A", 4m),
                (1, "2000000000011", 3m), // a batch without its own code: the product's barcode
                (2, "2000000000028", 30m),
                (3, "1003", 5m), // no barcode at all: the product code
                (4, "10_4", 0m), // no stock row
            },
            batches.Select(b => (b.ProductId, b.Code, b.Qty)));
        Assert.Equal(("Basmati Rice 5 kg", 599m, 549m), (batches[0].Name, batches[0].Mrp, batches[0].Price));
        Assert.Empty(await new SqlServerProductRepository(Db).GetBatchesAsync(Array.Empty<int>()));
    }

    [SqlServerFact]
    public async Task Product_search_finds_a_batch_code_too()
    {
        var found = await new SqlServerProductRepository(Db).SearchAsync("BATCH-A", 10);

        Assert.Equal(1, Assert.Single(found).Id);
    }

    [SqlServerFact]
    public async Task Product_search_without_a_term_lists_by_name_up_to_the_limit()
    {
        var products = await new SqlServerProductRepository(Db).SearchAsync(null, 3);

        Assert.Equal(new[] { "Basmati Rice 5 kg", "Cashback 50% Pack", "Toned Milk 500 ml" }, products.Select(p => p.Name));
    }

    [SqlServerFact]
    public async Task Product_search_treats_percent_and_underscore_literally()
    {
        var repository = new SqlServerProductRepository(Db);

        // Unescaped, "50%" would also match "Toned Milk 500 ml" and "_" would match everything.
        Assert.Equal(new[] { 3 }, (await repository.SearchAsync("50%", 10)).Select(p => p.Id));
        Assert.Equal(new[] { 4 }, (await repository.SearchAsync("_", 10)).Select(p => p.Id));
    }

    [SqlServerFact]
    public async Task Product_without_stock_rows_or_tax_reads_as_zero()
    {
        var item = Assert.Single(await new SqlServerProductRepository(Db).SearchAsync("Under_score", 10));

        Assert.Equal(0m, item.StockInHand);
        Assert.Equal(0m, item.GstRatePercent);
        Assert.Equal(0m, item.MinStock);
        Assert.Null(item.Barcode);
        Assert.Null(item.HsnCode);
    }

    [SqlServerTheory]
    [InlineData("1002", 2)]
    [InlineData("  1002  ", 2)]
    [InlineData("2000000000011", 1)]
    [InlineData("RICE-BATCH-A", 1)]
    public async Task Find_by_code_matches_product_code_barcode_or_batch_barcode(string code, int expectedId)
    {
        var product = await new SqlServerProductRepository(Db).FindByCodeAsync(code);

        Assert.NotNull(product);
        Assert.Equal(expectedId, product.Id);
    }

    [SqlServerTheory]
    [InlineData("nope")]
    [InlineData("")]
    [InlineData("   ")]
    public async Task Find_by_code_returns_null_when_nothing_matches(string code)
    {
        Assert.Null(await new SqlServerProductRepository(Db).FindByCodeAsync(code));
    }

    [SqlServerFact]
    public async Task Customer_search_matches_name_or_phone()
    {
        var repository = new SqlServerCustomerRepository(Db);

        var byName = Assert.Single(await repository.SearchAsync("priya", 10));
        Assert.Equal("Priya Sharma", byName.Name);
        Assert.Equal("9000000102", byName.Phone);

        var byPhone = Assert.Single(await repository.SearchAsync("0101", 10));
        Assert.Equal("Ramesh Kumar", byPhone.Name);
    }

    [SqlServerFact]
    public async Task Low_stock_lists_only_products_below_a_set_reorder_level()
    {
        var low = await new SqlServerStockRepository(Db).GetLowStockAsync(10);

        var rice = Assert.Single(low);
        Assert.Equal(1, rice.ProductId);
        Assert.Equal("Basmati Rice 5 kg", rice.Name);
        Assert.Equal(7m, rice.InHand);
        Assert.Equal(10m, rice.MinStock);
        Assert.Equal(3m, rice.Shortfall);
    }

    [SqlServerFact]
    public async Task Recent_bills_are_newest_first_with_customer_names()
    {
        var recent = await new SqlServerInvoiceRepository(Db).GetRecentAsync(10);

        Assert.Equal(new long[] { 4, 3, 2, 1 }, recent.Select(i => i.Id));
        Assert.Equal("SR/26-27/0002", recent[2].Number);
        Assert.Equal("Priya Sharma", recent[2].CustomerName);
        Assert.Equal(400m, recent[2].Balance);
        Assert.Equal(new DateTime(2026, 9, 24, 9, 30, 0), recent[2].Date);
    }

    [SqlServerFact]
    public async Task Every_bill_is_listed_newest_first_a_page_at_a_time_with_totals_for_all()
    {
        var repository = new SqlServerInvoiceRepository(Db);

        var first = await repository.SearchAsync(new BillQuery { Take = 2 });
        var second = await repository.SearchAsync(new BillQuery { Skip = 2, Take = 2 });
        var beyond = await repository.SearchAsync(new BillQuery { Skip = 4, Take = 2 });

        Assert.Equal(new long[] { 4, 3 }, first.Items.Select(i => i.Id));
        Assert.Equal(new long[] { 2, 1 }, second.Items.Select(i => i.Id));
        Assert.Empty(beyond.Items);
        Assert.Equal((4, 1704m, 400m), (first.Total, first.TotalAmount, first.TotalOwed));
        Assert.Equal((4, 1704m), (beyond.Total, beyond.TotalAmount));
        Assert.Equal(new DateTime(2026, 9, 23, 10, 0, 0), first.First);
        Assert.Equal(new DateTime(2026, 9, 25), first.Last);
        Assert.Equal(4, first.NewestId);
        Assert.Equal(("SR/26-27/0002", "Priya Sharma", 400m), (second.Items[0].Number, second.Items[0].CustomerName, second.Items[0].Balance));
    }

    [SqlServerTheory]
    [MemberData(nameof(BillSearches))]
    public async Task Bills_are_found_by_dates_bill_number_name_phone_or_money_owed(BillQuery query, long[] expected)
    {
        var page = await new SqlServerInvoiceRepository(Db).SearchAsync(query);

        Assert.Equal(expected, page.Items.Select(i => i.Id));
        Assert.Equal(expected.Length, page.Total);
    }

    public static TheoryData<BillQuery, long[]> BillSearches() => new()
    {
        { new BillQuery { From = new DateOnly(2026, 9, 24), To = new DateOnly(2026, 9, 24) }, new long[] { 3, 2 } },
        { new BillQuery { From = new DateOnly(2026, 9, 25) }, new long[] { 4 } },
        { new BillQuery { To = new DateOnly(2026, 9, 23) }, new long[] { 1 } },
        { new BillQuery { From = new DateOnly(2026, 9, 25), To = new DateOnly(2026, 9, 23) }, new long[] { 4, 3, 2, 1 } },
        { new BillQuery { Text = " 0003 " }, new long[] { 3 } },
        { new BillQuery { Text = "priya" }, new long[] { 2 } },
        { new BillQuery { Text = "0101" }, new long[] { 3 } },
        { new BillQuery { Text = "5%" }, Array.Empty<long>() },
        { new BillQuery { OnlyOwed = true }, new long[] { 2 } },
        { new BillQuery { OnlyOwed = true, From = new DateOnly(2026, 9, 25) }, Array.Empty<long>() },
        { new BillQuery { UpToId = 3 }, new long[] { 3, 2, 1 } },
        { new BillQuery { UpToId = 2, Text = "SR/26-27" }, new long[] { 2, 1 } },
        // Dates typed into the address beyond what SQL Server's datetime holds.
        { new BillQuery { From = DateOnly.MinValue, To = DateOnly.MaxValue }, new long[] { 4, 3, 2, 1 } },
        { new BillQuery { To = new DateOnly(1700, 1, 1) }, Array.Empty<long>() },
    };

    [SqlServerFact]
    public async Task A_bill_opens_with_its_items_payments_and_gst()
    {
        var bill = (await new SqlServerInvoiceRepository(Db).GetAsync(2))!;

        Assert.Equal(("SR/26-27/0002", "Priya Sharma", "9000000102"), (bill.Summary.Number, bill.Summary.CustomerName, bill.CustomerPhone));
        Assert.Equal((1000m, 600m, 400m), (bill.Summary.GrandTotal, bill.Paid, bill.Summary.Balance));
        Assert.Equal((1000m, 47.47m, 0m, 0m), (bill.SubTotal, bill.Cgst, bill.Sgst, bill.RoundOff));
        Assert.Equal(("counter1", "Pays the rest on Friday"), (bill.Operator, bill.Remarks));

        Assert.Equal(2, bill.Items.Count);
        Assert.Equal(("Basmati Rice 5 kg", "1001", 1m, 549m, 549m), (bill.Items[0].Name, bill.Items[0].Code, bill.Items[0].Qty, bill.Items[0].Rate, bill.Items[0].Amount));
        var pack = bill.Items[1];
        // The name printed on the bill, not the product's name today.
        Assert.Equal(("Cashback Pack (old name)", "PCS", 110m), (pack.Name, pack.Unit, pack.Mrp));
        Assert.Equal((4m, 112.75m, 9m, 34.40m, 451m), (pack.Qty, pack.Rate, pack.TaxPercent, pack.Tax, pack.Amount));

        Assert.Equal(new[] { new BillPayment(new DateTime(2026, 9, 24, 9, 30, 0), "Google Pay", 600m) }, bill.Payments);
    }

    [SqlServerFact]
    public async Task Bill_times_come_from_the_pos_log()
    {
        var recent = (await new SqlServerInvoiceRepository(Db).GetRecentAsync(10)).ToDictionary(b => b.Id);

        // Saved at 10:02; the later "updated the bill" entry does not move it.
        Assert.Equal((new DateTime(2026, 9, 23, 10, 2, 11), new TimeOnly(10, 2, 11), false),
            (recent[1].SavedAt, recent[1].Time, recent[1].EnteredLater));
        // The number was used, deleted and used again: the bill that has it now was saved at 11:15.
        Assert.Equal(new DateTime(2026, 9, 24, 11, 15, 30), recent[2].SavedAt);
        // Typed in two days after its date: when it was sold is not known.
        Assert.Equal((new DateTime(2026, 9, 26, 10, 5, 0), (TimeOnly?)null, true), (recent[3].SavedAt, recent[3].Time, recent[3].EnteredLater));
        // Only held in the log, never saved as a bill.
        Assert.Equal(((DateTime?)null, false), (recent[4].SavedAt, recent[4].EnteredLater));
    }

    [SqlServerFact]
    public async Task Bill_pages_and_a_bill_carry_their_times()
    {
        var repository = new SqlServerInvoiceRepository(Db);

        var page = await repository.SearchAsync(new BillQuery { Skip = 1, Take = 2 });
        var bill = (await repository.GetAsync(2))!;

        Assert.Equal(new DateTime?[] { new DateTime(2026, 9, 26, 10, 5, 0), new DateTime(2026, 9, 24, 11, 15, 30) }, page.Items.Select(b => b.SavedAt));
        Assert.Equal(new TimeOnly(11, 15, 30), bill.Summary.Time);
        Assert.Null((await repository.GetAsync(4))!.Summary.SavedAt);
    }

    [SqlServerFact]
    public async Task Sales_by_hour_count_only_bills_saved_on_their_own_date()
    {
        var facts = await new SqlServerSalesFactsRepository(Db).GetFactsAsync(new DateRange(new DateOnly(2026, 9, 23), new DateOnly(2026, 9, 25)));

        Assert.Equal(
            new[] { (new DateOnly(2026, 9, 23), 10, 1, 549m), (new DateOnly(2026, 9, 24), 11, 1, 1000m) },
            facts.Hours.OrderBy(h => h.Day).Select(h => (h.Day, h.Hour, h.Bills, h.Sales)));
    }

    [SqlServerFact]
    public async Task Bill_times_list_every_bill_of_the_days_with_when_it_was_saved()
    {
        var times = await new SqlServerSalesFactsRepository(Db).GetBillTimesAsync(new DateRange(new DateOnly(2026, 9, 24), new DateOnly(2026, 9, 25)));

        Assert.Equal(
            new[]
            {
                new BillTime(new DateOnly(2026, 9, 24), new DateTime(2026, 9, 24, 11, 15, 30), 1000m),
                new BillTime(new DateOnly(2026, 9, 24), new DateTime(2026, 9, 26, 10, 5, 0), 56m),
                new BillTime(new DateOnly(2026, 9, 25), null, 99m),
            },
            times);
        Assert.Equal(new TimeOnly?[] { new TimeOnly(11, 15, 30), null, null }, times.Select(t => t.Time));
    }

    [SqlServerFact]
    public async Task A_bill_that_is_not_there_opens_as_nothing()
    {
        var repository = new SqlServerInvoiceRepository(Db);

        Assert.Null(await repository.GetAsync(99));
        Assert.Null(await repository.GetAsync(0));
        Assert.Null(await repository.GetAsync(long.MaxValue));
    }

    [SqlServerFact]
    public async Task The_checks_read_each_batchs_price_with_the_products_own_as_fallback()
    {
        var prices = await new SqlServerShopChecksRepository(Db).GetPricesAsync();

        Assert.Equal(
            new[]
            {
                (1, "RICE-BATCH-A", 549m, 599m, 480m, 5m, 4m),
                (1, "2000000000011", 549m, 599m, 480m, 5m, 3m),
                (2, "2000000000028", 28m, 28m, 25m, 0m, 30m),
                (3, "1003", 100m, 110m, 90m, 18m, 5m),
                (4, "10_4", 12m, 12m, 10m, 0m, 0m), // no stock row
            },
            prices.Select(p => (p.ProductId, p.Code, p.Price, p.Mrp, p.Cost, p.GstPercent, p.Qty)));
    }

    [SqlServerFact]
    public async Task The_checks_read_the_weeks_bill_lines_and_bill_numbers()
    {
        var repository = new SqlServerShopChecksRepository(Db);
        var day = new DateRange(new DateOnly(2026, 9, 24), new DateOnly(2026, 9, 24));

        var lines = await repository.GetSoldLinesAsync(day);
        var bills = await repository.GetBillsAsync(new DateRange(new DateOnly(2026, 9, 23), new DateOnly(2026, 9, 25)));

        Assert.Equal(new long[] { 2, 2, 3 }, lines.Select(l => l.BillId));
        var pack = lines[1];
        Assert.Equal(("Cashback Pack (old name)", 4m, 112.75m, 110m, 451m, 382.20m), (pack.Name, pack.Qty, pack.Rate, pack.Mrp, pack.Amount, pack.Taxable));
        // No taxable amount saved: the amount with its GST (none here) taken out.
        Assert.Equal((56m, 25m), (lines[2].Taxable, lines[2].PurchaseRate));
        Assert.Equal(new long[] { 1, 2, 3, 4 }, bills.Select(b => b.Id));
        Assert.Equal("SR/26-27/0004", bills[3].Number);
    }

    [SqlServerFact]
    public async Task The_checks_find_the_mistakes_in_the_pos_tables()
    {
        var facts = await new SqlServerShopChecksRepository(Db).LoadCheckFactsAsync(new SqlServerInvoiceRepository(Db), new DateOnly(2026, 9, 26), pricesIncludeTax: true);

        var findings = ShopChecks.Run(facts);

        // The pack sells at ₹100 but cost ₹90 + 18% GST = ₹106.20; on bill 2 it was billed at ₹112.75, over its ₹110 MRP.
        Assert.Equal(new[] { (FindingKind.BelowCost, 3), (FindingKind.SoldAboveMrp, 3) }, findings.Select(f => (f.Kind, f.ProductId ?? 0)));
        Assert.Equal("In the POS, raise the price to at least ₹107, or correct the purchase price if it is wrong.", findings[0].WhatToDo);
        Assert.Null(facts.OwedLong); // Priya's bill is only two days old
    }

    [SqlServerFact]
    public async Task Bills_with_any_of_some_products_count_once_each()
    {
        var repository = new SqlServerSalesFactsRepository(Db);
        var week = new DateRange(new DateOnly(2026, 9, 23), new DateOnly(2026, 9, 29));

        // Bill 2 has both the rice and the pack: one bill, not two.
        Assert.Equal(2, await repository.CountBillsWithAsync(week, new[] { 1, 3 }));
        Assert.Equal(2, await repository.CountBillsWithAsync(week, new[] { 1 }));
        Assert.Equal(1, await repository.CountBillsWithAsync(new DateRange(new DateOnly(2026, 9, 24), new DateOnly(2026, 9, 24)), new[] { 1, 3, 3 }));
        Assert.Equal(0, await repository.CountBillsWithAsync(week, new[] { 99 }));
        Assert.Equal(0, await repository.CountBillsWithAsync(week, Array.Empty<int>()));
    }

    [SqlServerFact]
    public async Task Sales_for_a_day_count_only_that_days_bills()
    {
        var day = await new SqlServerInvoiceRepository(Db).GetSalesForDayAsync(new DateOnly(2026, 9, 24));

        Assert.Equal(2, day.BillCount);
        Assert.Equal(1056m, day.Total);
        Assert.Equal(400m, day.Outstanding);
    }

    [SqlServerFact]
    public async Task Sales_for_a_day_without_bills_are_zero()
    {
        var day = await new SqlServerInvoiceRepository(Db).GetSalesForDayAsync(new DateOnly(2026, 1, 1));

        Assert.Equal(0, day.BillCount);
        Assert.Equal(0m, day.Total);
    }

    [SqlServerFact]
    public async Task Sales_facts_add_up_bills_lines_payments_returns_and_customers()
    {
        var facts = await new SqlServerSalesFactsRepository(Db).GetFactsAsync(new DateRange(new DateOnly(2026, 9, 24), new DateOnly(2026, 9, 25)));

        Assert.Equal(
            new[] { (new DateOnly(2026, 9, 24), 2, 1056m, 100m, 400m), (new DateOnly(2026, 9, 25), 1, 99m, 0m, 0m) },
            facts.Days.Select(d => (d.Day, d.Bills, d.Sales, d.Returns, d.Outstanding)));

        var rice = facts.ProductDays.Single(p => p.ProductId == 1);
        Assert.Equal((new DateOnly(2026, 9, 24), 1m, 549m, 522.86m, 522.86m, 480m, 1), (rice.Day, rice.Qty, rice.Sales, rice.SalesBeforeTax, rice.CostedSalesBeforeTax, rice.Cost, rice.Bills));
        var pack = facts.ProductDays.Single(p => p.ProductId == 3);
        Assert.Equal((382.20m, 0m, 0m), (pack.SalesBeforeTax, pack.CostedSalesBeforeTax, pack.Cost));
        var milk = facts.ProductDays.Single(p => p.ProductId == 2);
        Assert.Equal((56m, 50m), (milk.SalesBeforeTax, milk.Cost));
        Assert.Equal((8.25m, 82.5m), (facts.ProductDays.Single(p => p.ProductId == 4).Qty, facts.ProductDays.Single(p => p.ProductId == 4).Cost));

        Assert.Equal(
            new[] { ("By Cash", 1, 56m), ("By Credit Card", 1, 99m), ("Google Pay", 1, 600m) },
            facts.Payments.OrderBy(p => p.Mode, StringComparer.Ordinal).Select(p => (p.Mode, p.Payments, p.Amount)));

        // The walk-in customer's first bill ever (23 Sep) is before the period.
        Assert.Equal(
            new[] { (1, "Cash", 1, 99m, new DateOnly(2026, 9, 23)), (2, "Priya Sharma", 1, 1000m, new DateOnly(2026, 9, 24)), (3, "Ramesh Kumar", 1, 56m, new DateOnly(2026, 9, 24)) },
            facts.Customers.OrderBy(c => c.Id).Select(c => (c.Id, c.Name, c.Bills, c.Sales, c.FirstBillEver)));
    }

    [SqlServerFact]
    public async Task Bill_span_and_products_for_the_dashboard()
    {
        var repository = new SqlServerSalesFactsRepository(Db);

        Assert.Equal(new BillSpan(new DateOnly(2026, 9, 23), new DateOnly(2026, 9, 25)), await repository.GetBillSpanAsync());

        var products = (await repository.GetProductsAsync()).ToDictionary(p => p.Id);
        var rice = products[1];
        Assert.Equal(("1001", "Basmati Rice 5 kg", "Staples", "Rice", 7m, 10m, 480m, 549m, true),
            (rice.Code, rice.Name, rice.Category, rice.SubCategory, rice.StockInHand, rice.MinStock, rice.CostPrice, rice.SellingPrice, rice.Active));
        Assert.Equal((0m, 0m, true), (products[4].StockInHand, products[4].MinStock, products[4].Active));

        // The GST rate is CGST + SGST; a product without them has none.
        Assert.Equal((5m, 0m, 18m, 0m), (rice.GstRatePercent, products[2].GstRatePercent, products[3].GstRatePercent, products[4].GstRatePercent));
    }

    [SqlServerFact]
    public async Task A_sales_report_runs_end_to_end_on_the_pos_tables()
    {
        var report = await new SqlServerSalesFactsRepository(Db).LoadReportAsync(new DateRange(new DateOnly(2026, 9, 24), new DateOnly(2026, 9, 25)));

        Assert.Equal((1155m, 100m, 3), (report.Current.Sales, report.Current.Returns, report.Current.Bills));
        Assert.Equal((549m, 1), (report.Previous.Sales, report.Previous.Bills));
        Assert.Equal("Basmati Rice 5 kg", report.TopProducts[0].Name);
        Assert.Equal(new[] { "UPI / wallet", "Card", "Cash" }, report.Payments.Select(p => p.Group));
        Assert.Equal((2, 2), (report.Customers.NamedCustomers, report.Customers.NewCustomers));
    }

    [SqlServerFact]
    public async Task Saving_a_bill_to_the_live_database_is_refused()
    {
        var error = await Assert.ThrowsAsync<NotSupportedException>(
            () => new SqlServerInvoiceRepository(Db).SaveAsync(new NewInvoice()));

        Assert.Equal(SqlServerInvoiceRepository.SavingDisabledMessage, error.Message);
    }
}

using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// What stock costs and what it is worth (decision 36, blueprint ticket FIN-003): the cost of an item is the average of what was paid, worked out again at each purchase; a sale books the cost
/// of what it took ("Cost of goods sold"); goods brought back return at the cost they left at; the stock the books show is the stock the moves hold. India, rupees; the amounts are worked by
/// hand beside each case (money in minor units: 100.00 is 10,000; quantities in thousandths: 5 is 5,000).
/// </summary>
public class StockCostTests
{
    private static HubFixture Shop() => new("IN", "wholesale", s => s.PricesIncludeTax = false);

    private static Party Supplier(HubFixture f) => f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });

    private static Item Goods(HubFixture f, string name = "Rice", long price = 20_000, long cost = 0, string tax = "zero", string kind = "stock") =>
        f.App.Catalog.Create(new ItemInput { Kind = kind, Name = name, PriceMinor = price, CostMinor = cost, TaxClass = tax });

    /// <summary>Buys quantity (in thousandths) of an item at a price for one, and receives it.</summary>
    private static DocumentView Buy(HubFixture f, Party supplier, Item item, long qtyMilli, long unitCostMinor)
    {
        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = item.Id, QtyMilli = qtyMilli, CostMinor = unitCostMinor } });
        return f.App.Purchasing.Receive(order.Document.Id);
    }

    private static DocumentView Sell(HubFixture f, Item item, long qtyMilli) => f.App.Documents.Checkout(new CheckoutRequest
    {
        Lines = { new LineInput { ItemId = item.Id, QtyMilli = qtyMilli } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 100_000_000 } },
    });

    /// <summary>What the item holds and what that is worth, from its moves.</summary>
    private static (long Qty, long Value) Held(HubFixture f, Item item)
    {
        var row = f.App.Db.Query("SELECT COALESCE(SUM(qty_milli), 0), COALESCE(SUM(value_minor), 0) FROM stock_moves WHERE item_id = $i", r => (r.GetInt64(0), r.GetInt64(1)), ("$i", item.Id)).Single();
        return row;
    }

    private static long Balance(HubFixture f, string name) => f.App.Books.TrialBalance().FirstOrDefault(r => r.Name == name)?.BalanceMinor ?? 0;

    /// <summary>The books balance entry by entry, nothing is on "Needs checking", and the stock the books show is exactly what the moves of all the items are worth.</summary>
    private static void AssertBooksAgree(HubFixture f)
    {
        var rows = f.App.Books.TrialBalance();
        Assert.Equal(rows.Sum(r => r.DebitMinor), rows.Sum(r => r.CreditMinor));
        Assert.DoesNotContain(rows, r => r.Name == "Needs checking");
        Assert.Empty(f.App.Db.Query("SELECT entry_id FROM journal_lines GROUP BY entry_id HAVING SUM(debit_minor) <> SUM(credit_minor)", r => r.GetInt64(0)));
        var moves = Convert.ToInt64(f.App.Db.Scalar("SELECT COALESCE(SUM(value_minor), 0) FROM stock_moves"));
        Assert.Equal(moves, Balance(f, "Stock on the shelves"));
        Assert.Equal(moves, f.App.Reports.StockValues().Sum(s => s.ValueMinor) + OtherThanShelves(f));
    }

    /// <summary>What the moves are worth for items that hold nothing or less (the stock report lists only what is on the shelves).</summary>
    private static long OtherThanShelves(HubFixture f) => Convert.ToInt64(f.App.Db.Scalar(
        "SELECT COALESCE(SUM(v), 0) FROM (SELECT SUM(value_minor) AS v, SUM(qty_milli) AS q FROM stock_moves GROUP BY item_id) WHERE q <= 0"));

    // ---- purchases ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_purchase_brings_stock_in_at_what_the_lines_cost_without_tax_and_after_discounts_and_the_shelf_not_purchases_holds_it()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f, tax: "standard");
        // 10 at 100.00 with 10% off the line: 900.00 before tax, tax on top; the goods cost 900.00, not what was paid with the tax.
        var order = f.App.Documents.CreateDraft(new DraftOptions
        {
            Type = DocTypes.Purchase, Direction = "in", PartyId = supplier.Id,
            Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 10_000, UnitPriceMinor = 10_000, DiscountPctMilli = 10_000, TaxCode = "GST18" } },
        });
        var received = f.App.Purchasing.Receive(order.Document.Id);
        Assert.True(received.Document.TotalMinor > 90_000);                 // the bill has tax on it ...
        Assert.Equal((10_000L, 90_000L), Held(f, rice));                    // ... the stock does not
        Assert.Equal(90_000, Balance(f, "Stock on the shelves"));
        Assert.Equal(0, Balance(f, "Purchases"));                           // what was bought is on the shelf, not a cost yet
        AssertBooksAgree(f);
    }

    [Fact]
    public void Each_purchase_works_the_average_out_again()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        Buy(f, supplier, rice, 10_000, 10_000);     // 10 at 100.00 = 1,000.00
        Assert.Equal((10_000L, 100_000L), Held(f, rice));
        Buy(f, supplier, rice, 10_000, 12_000);     // 10 at 120.00 = 1,200.00 more
        Assert.Equal((20_000L, 220_000L), Held(f, rice));     // 2,200.00 for 20: the average is 110.00
        var row = f.App.Catalog.StockList().Single();
        Assert.Equal(11_000, row.CostMinor);
        Assert.Equal(220_000, row.ValueMinor);
        AssertBooksAgree(f);
    }

    // ---- sales -------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_purchase_then_a_sale_then_a_stock_correction_reconcile_in_quantity_value_cost_of_goods_and_the_books()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);                        // sells at 200.00
        Buy(f, supplier, rice, 10_000, 10_000);
        Buy(f, supplier, rice, 10_000, 12_000);     // 20 held, worth 2,200.00
        var sale = Sell(f, rice, 5_000);            // 5 at 200.00 = 1,000.00; they cost 5/20 of 2,200.00 = 550.00
        Assert.Equal(100_000, sale.Document.TotalMinor);
        Assert.Equal((15_000L, 165_000L), Held(f, rice));
        Assert.Equal(55_000, Balance(f, "Cost of goods sold"));

        f.App.Catalog.Adjust(rice.Id, -1_000, "damaged");         // one is spoiled: 1/15 of 1,650.00 = 110.00 lost
        Assert.Equal((14_000L, 154_000L), Held(f, rice));
        Assert.Equal(11_000, Balance(f, "Stock lost, damaged or gained"));

        Assert.Equal(154_000, Balance(f, "Stock on the shelves"));
        Assert.Equal(0, Balance(f, "Purchases"));
        var profit = f.App.Books.Profit(null, null);
        Assert.Equal(100_000, profit.IncomeMinor);                // sales
        Assert.Equal(55_000 + 11_000, profit.CostsMinor);         // what the goods cost, and what was lost
        Assert.Equal(34_000, profit.NetMinor);
        AssertBooksAgree(f);
    }

    [Fact]
    public void A_sale_takes_the_average_rounded_half_up_and_the_last_unit_takes_whatever_is_left()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        Buy(f, supplier, rice, 7_000, 1_000);       // 7 at 10.00 = 70.00
        Buy(f, supplier, rice, 2_000, 1_001);       // 2 at 10.01 = 20.02: 9 worth 90.02
        Assert.Equal((9_000L, 9_002L), Held(f, rice));
        Sell(f, rice, 4_000);                        // 4/9 of 90.02 = 40.0088 -> 40.01
        Assert.Equal((5_000L, 5_001L), Held(f, rice));
        Assert.Equal(4_001, Balance(f, "Cost of goods sold"));
        Sell(f, rice, 5_000);                        // the last five take what is left, 50.01, so nothing is left behind
        Assert.Equal((0L, 0L), Held(f, rice));
        Assert.Equal(9_002, Balance(f, "Cost of goods sold"));
        Assert.Equal(0, Balance(f, "Stock on the shelves"));
        AssertBooksAgree(f);
    }

    [Fact]
    public void Goods_sold_with_no_stock_behind_them_are_costed_at_the_last_price_and_the_books_still_agree()
    {
        using var f = Shop();                          // a shop may sell below zero (the default)
        var supplier = Supplier(f);
        var rice = Goods(f);
        Buy(f, supplier, rice, 3_000, 1_000);          // 3 at 10.00 = 30.00
        Sell(f, rice, 5_000);                           // 3 are held (30.00), 2 are not: those cost the last price, 10.00 each
        Assert.Equal(5_000, Balance(f, "Cost of goods sold"));
        Assert.Equal((-2_000L, -2_000L), Held(f, rice));
        Buy(f, supplier, rice, 10_000, 900);           // 10 at 9.00 = 90.00
        Assert.Equal((8_000L, 7_000L), Held(f, rice));
        AssertBooksAgree(f);
    }

    // ---- returns and cancelling ------------------------------------------------------------------------------------------------------

    [Fact]
    public void Goods_brought_back_return_at_the_cost_they_left_at_and_the_returns_add_up_to_exactly_what_the_sale_cost()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        Buy(f, supplier, rice, 7_000, 1_000);
        Buy(f, supplier, rice, 2_000, 1_001);                        // 9 worth 90.02
        var sale = Sell(f, rice, 4_000);                              // cost 40.01
        Buy(f, supplier, rice, 5_000, 2_000);                         // the average moves on: not what the goods cost
        var line = sale.Lines.Single().Id;
        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (line, 1_000L) }, "one back", "cash", null);
        Assert.Equal(4_001 - 1_000, Balance(f, "Cost of goods sold"));   // 1/4 of 40.01 = 10.0025 -> 10.00
        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (line, 3_000L) }, "the rest", "cash", null);
        Assert.Equal(0, Balance(f, "Cost of goods sold"));                // together exactly what the sale cost: 10.00 + 30.01
        AssertBooksAgree(f);
    }

    [Fact]
    public void A_cancelled_sale_puts_the_goods_back_at_their_cost_and_a_cancelled_purchase_takes_them_off_at_theirs()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        Buy(f, supplier, rice, 10_000, 10_000);
        var second = Buy(f, supplier, rice, 10_000, 12_000);                // 20 worth 2,200.00
        var sale = Sell(f, rice, 8_000);                                      // 8/20 of 2,200.00 = 880.00
        Assert.Equal((12_000L, 132_000L), Held(f, rice));
        f.App.Documents.Void(sale.Document.Id, "mistake", null);
        Assert.Equal((20_000L, 220_000L), Held(f, rice));
        Assert.Equal(0, Balance(f, "Cost of goods sold"));
        f.App.Documents.Void(second.Document.Id, "wrong supplier", null);     // the second delivery was 1,200.00
        Assert.Equal((10_000L, 100_000L), Held(f, rice));
        Assert.Equal(100_000, Balance(f, "Stock on the shelves"));
        AssertBooksAgree(f);
    }

    // ---- counts, deliveries, things that are not stock --------------------------------------------------------------------------------

    [Fact]
    public void A_count_that_finds_more_joins_at_the_average_and_a_delivery_with_no_order_joins_at_the_last_price()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        Buy(f, supplier, rice, 10_000, 10_000);
        Buy(f, supplier, rice, 10_000, 12_000);                              // 20 worth 2,200.00, last price 120.00
        f.App.Catalog.Adjust(rice.Id, 2_000, "count");                       // two found: at the average, 110.00 each
        Assert.Equal((22_000L, 242_000L), Held(f, rice));
        Assert.Equal(-22_000, Balance(f, "Stock lost, damaged or gained"));   // a gain
        f.App.Catalog.Adjust(rice.Id, 3_000, "delivery");                    // three arrive with no order: at the last price, 120.00 each
        Assert.Equal((25_000L, 278_000L), Held(f, rice));
        Assert.Equal(-36_000, Balance(f, "Purchases"));                      // bought, with no order behind it
        AssertBooksAgree(f);
    }

    [Fact]
    public void What_is_not_kept_in_stock_stays_a_purchase_and_is_a_cost_when_bought()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var bags = Goods(f, "Carry bags", kind: "service");      // a kind that keeps no stock
        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = bags.Id, QtyMilli = 100_000, CostMinor = 500 } });
        f.App.Purchasing.Receive(order.Document.Id);
        Assert.Equal(50_000, Balance(f, "Purchases"));
        Assert.Equal(0, Balance(f, "Stock on the shelves"));
        Assert.Equal(0, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM stock_moves")));
        AssertBooksAgree(f);
    }

    // ---- stock that was there before costs were kept ---------------------------------------------------------------------------------

    [Fact]
    public void Stock_already_on_the_shelves_when_costs_began_is_given_its_value_once_as_an_opening_entry_and_nothing_old_is_worked_out_again()
    {
        using var f = Shop();
        var rice = Goods(f, cost: 2_500);                                   // the item's cost price is 25.00
        f.App.Catalog.Adjust(rice.Id, 10_000, "delivery");
        var path = f.App.Db.Path;
        f.App.Db.Rollback(14);                                              // the shop as it was before costs were kept: ten on the shelf, no value anywhere
        Assert.Equal(10_000, Convert.ToInt64(f.App.Db.Scalar("SELECT SUM(qty_milli) FROM stock_moves")));
        Assert.Empty(f.App.Db.Query("SELECT 1 FROM pragma_table_info('stock_moves') WHERE name = 'value_minor'", r => r.GetInt32(0)));

        var again = HubApp.OpenTrusted(path, f.Clock);                      // forward again
        var f2 = again;
        Assert.Equal(25_000, Convert.ToInt64(f2.Db.Scalar("SELECT SUM(value_minor) FROM stock_moves")));
        Assert.Equal(10_000, Convert.ToInt64(f2.Db.Scalar("SELECT SUM(qty_milli) FROM stock_moves")));
        Assert.Equal(1, Convert.ToInt64(f2.Db.Scalar("SELECT COUNT(*) FROM stock_moves WHERE reason = 'valuation'")));
        var trial = f2.Books.TrialBalance();
        Assert.Equal(25_000, trial.Single(r => r.Name == "Stock on the shelves").BalanceMinor);
        Assert.Equal(-25_000, trial.Single(r => r.Name == "Opening balances").BalanceMinor);
        Assert.Equal(0, f2.Books.CatchUp());                                // posted once, not again

        var sale = f2.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 4_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 10_000_000 } } });
        Assert.NotNull(sale.Document.Number);
        Assert.Equal(10_000, f2.Books.TrialBalance().Single(r => r.Name == "Cost of goods sold").BalanceMinor);    // 4 at 25.00
    }

    [Fact]
    public void The_way_back_removes_only_what_costs_made_and_the_rest_of_the_books_still_agree()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        Buy(f, supplier, rice, 10_000, 10_000);
        Sell(f, rice, 3_000);
        var withoutCosts = f.App.Books.TrialBalance().Where(r => r.Name is "Sales" or "Cash").Select(r => (r.Name, r.DebitMinor, r.CreditMinor)).ToList();

        f.App.Db.Rollback(14);
        var rows = f.App.Books.TrialBalance();
        Assert.Equal(rows.Sum(r => r.DebitMinor), rows.Sum(r => r.CreditMinor));
        Assert.DoesNotContain(rows, r => r.Name is "Stock on the shelves" or "Cost of goods sold" or "Stock lost, damaged or gained");
        Assert.Equal(withoutCosts, rows.Where(r => r.Name is "Sales" or "Cash").Select(r => (r.Name, r.DebitMinor, r.CreditMinor)).ToList());   // the bills stand as they were
        Assert.Equal(7_000, Convert.ToInt64(f.App.Db.Scalar("SELECT SUM(qty_milli) FROM stock_moves")));                                          // so does the stock

        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Clock);               // forward again works
        Assert.Equal((long)HubDb.LatestVersion, Convert.ToInt64(again.Db.Scalar("SELECT MAX(version) FROM schema_version")));
        Assert.Equal(7_000, Convert.ToInt64(again.Db.Scalar("SELECT SUM(qty_milli) FROM stock_moves")));
    }

    // ---- a long mixture ------------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(7)]
    [InlineData(1234)]
    [InlineData(98765)]
    public void A_mixture_of_buying_selling_returning_cancelling_and_counting_keeps_the_stock_and_the_books_in_agreement(int seed)
    {
        using var f = Shop();
        var random = new Random(seed);
        var supplier = Supplier(f);
        var items = new[] { Goods(f, "Rice", 20_000), Goods(f, "Dal", 15_000), Goods(f, "Oil", 30_000, tax: "standard") };
        var sales = new List<(DocumentView View, Item Item, long Qty)>();
        for (var step = 0; step < 120; step++)
        {
            var item = items[random.Next(items.Length)];
            switch (random.Next(7))
            {
                case 0:
                case 1:
                    Buy(f, supplier, item, random.Next(1, 40) * 1_000L + random.Next(0, 3) * 250, random.Next(500, 5_000));
                    break;
                case 2:
                case 3:
                {
                    var qty = random.Next(1, 25) * 500L;
                    sales.Add((Sell(f, item, qty), item, qty));
                    break;
                }
                case 4 when sales.Count > 0:
                {
                    var (sale, _, qty) = sales[random.Next(sales.Count)];
                    var back = Math.Max(250, qty / 3);
                    try { f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines.Single().Id, back) }, "back", "cash", null); }
                    catch (HubException) { /* more than is left to give back: refused, as it should be */ }
                    break;
                }
                case 5 when sales.Count > 0:
                {
                    var (sale, _, _) = sales[random.Next(sales.Count)];
                    try { f.App.Documents.Void(sale.Document.Id, "mistake", null); }
                    catch (HubException) { /* already cancelled, or has a credit note */ }
                    break;
                }
                default:
                    f.App.Catalog.Adjust(item.Id, random.Next(-3, 4) * 1_000L - 500, random.Next(3) switch { 0 => "count", 1 => "damaged", _ => "delivery" });
                    break;
            }

            if (step % 20 == 19) AssertBooksAgree(f);
        }

        AssertBooksAgree(f);
        // what is on the shelves, what was sold and what was lost explain the purchases: value bought = value held + cost of goods sold + net loss - what came back
        var values = f.App.Db.Query("SELECT reason, SUM(value_minor) FROM stock_moves GROUP BY reason", r => (r.GetString(0), r.GetInt64(1))).ToDictionary(x => x.Item1, x => x.Item2);
        var held = values.Values.Sum();
        Assert.Equal(held, Balance(f, "Stock on the shelves"));
        // the mixture really did all of it (so a change that stops costing one kind of move cannot pass unseen)
        foreach (var reason in new[] { "purchase", "sale", "return", "void", "count", "damaged", "delivery" })
            Assert.True(values.ContainsKey(reason), "the mixture never made a move of kind " + reason + " (seed " + seed + ")");
    }
}

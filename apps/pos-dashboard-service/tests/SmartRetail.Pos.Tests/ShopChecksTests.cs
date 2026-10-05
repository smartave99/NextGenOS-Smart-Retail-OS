using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Data.Demo;

namespace SmartRetail.Pos.Tests;

/// <summary>The Fix now checks on hand-worked figures.</summary>
public class ShopChecksTests
{
    private static readonly DateOnly Today = new(2026, 9, 26);

    private static PriceFacts Price(int id, decimal price, decimal cost, decimal gst = 0m, decimal mrp = 0m, decimal qty = 10m, string? code = null) => new()
    {
        ProductId = id,
        Name = "Product " + id,
        Code = code ?? (1000 + id).ToString(System.Globalization.CultureInfo.InvariantCulture),
        Price = price,
        Cost = cost,
        GstPercent = gst,
        Mrp = mrp,
        Qty = qty,
    };

    private static SoldLine Line(long bill, int product, decimal qty, decimal rate, decimal purchase, decimal mrp = 0m, decimal discount = 0m,
        decimal billDiscount = 0m) => new()
    {
        BillId = bill,
        BillNumber = "SR/26-27/" + bill.ToString("0000", System.Globalization.CultureInfo.InvariantCulture),
        Date = new DateTime(2026, 9, 20).AddDays(bill % 5),
        ProductId = product,
        Name = "Product " + product,
        Qty = qty,
        Rate = rate,
        Mrp = mrp,
        Discount = discount,
        Amount = rate * qty - discount,
        Taxable = rate * qty - discount,
        PurchaseRate = purchase,
        BillDiscount = billDiscount,
    };

    private static IReadOnlyList<Finding> Run(IReadOnlyList<PriceFacts>? prices = null, IReadOnlyList<SoldLine>? lines = null,
        IReadOnlyList<BillStub>? bills = null, OwedBills? owed = null) =>
        ShopChecks.Run(new CheckFacts
        {
            Today = Today,
            Prices = prices ?? Array.Empty<PriceFacts>(),
            RecentLines = lines ?? Array.Empty<SoldLine>(),
            RecentBills = bills ?? Array.Empty<BillStub>(),
            OwedLong = owed,
        });

    [Fact]
    public void A_price_below_cost_with_gst_is_to_fix_now_and_says_the_lowest_fair_price()
    {
        // Bought at ₹9.50 before GST; with 5% GST it costs ₹9.975, i.e. ₹9.98. Selling at ₹9 loses ₹0.98 each.
        var finding = Assert.Single(Run(new[] { Price(1, price: 9m, cost: 9.50m, gst: 5m, qty: 12m) }));

        Assert.Equal((FindingKind.BelowCost, FindingLevel.FixNow), (finding.Kind, finding.Level));
        Assert.Equal("Sells for ₹9.00 but costs ₹9.98 with 5% GST (bought at ₹9.50). Each one sold loses ₹0.98. 12 in stock.", finding.Detail);
        Assert.Equal("In the POS, raise the price to at least ₹10, or correct the purchase price if it is wrong.", finding.WhatToDo);
        Assert.Equal(0.98m * 12, finding.AtStake);
        Assert.Equal(1, finding.ProductId);
    }

    [Fact]
    public void Out_of_stock_mistakes_are_to_check_soon_and_a_fair_price_is_no_finding()
    {
        var findings = Run(new[]
        {
            Price(1, price: 9m, cost: 9.50m, gst: 5m, qty: 0m),
            Price(2, price: 10.50m, cost: 10m, gst: 5m), // exactly cost plus GST: fine
            Price(3, price: 118m, cost: 60m, gst: 18m), // ₹100 before GST, bought at ₹60: fine
        });

        Assert.Equal((FindingKind.BelowCost, FindingLevel.CheckSoon, 1), (Assert.Single(findings).Kind, findings[0].Level, findings[0].ProductId));
    }

    [Fact]
    public void A_price_above_mrp_is_to_fix_now()
    {
        var finding = Assert.Single(Run(new[] { Price(4, price: 32m, cost: 20m, mrp: 30m, qty: 5m) }));

        Assert.Equal((FindingKind.AboveMrp, FindingLevel.FixNow), (finding.Kind, finding.Level));
        Assert.Equal("Sells for ₹32.00, above its MRP of ₹30.00. Charging more than the MRP is not allowed. 5 in stock.", finding.Detail);
        Assert.Equal("In the POS, lower the price to ₹30 or less, or correct the MRP if it is wrong.", finding.WhatToDo);
        Assert.Equal(10m, finding.AtStake);
    }

    [Fact]
    public void Prices_far_above_cost_no_purchase_price_and_negative_stock_are_to_check_soon()
    {
        var findings = Run(new[]
        {
            Price(5, price: 118m, cost: 30m, gst: 18m), // ₹100 before GST is 3.3 times ₹30
            Price(6, price: 50m, cost: 0m, qty: 3m),
            Price(7, price: 50m, cost: 0m, qty: 0m), // none in stock: nothing to lose yet
            Price(8, price: 25m, cost: 20m, qty: -4m),
        });

        Assert.Equal(new[] { FindingKind.FarAboveCost, FindingKind.NoCost, FindingKind.NegativeStock }, findings.Select(f => f.Kind));
        Assert.All(findings, f => Assert.Equal(FindingLevel.CheckSoon, f.Level));
        Assert.Contains("3.3 times its purchase price of ₹30.00", findings[0].Detail);
        Assert.Equal(6, findings[1].ProductId);
        Assert.Contains("shows -4 in stock", findings[2].Detail);
    }

    [Fact]
    public void One_barcode_on_two_products_is_to_fix_now()
    {
        var findings = Run(new[]
        {
            Price(9, price: 40m, cost: 30m, code: "4172"),
            Price(7, price: 55m, cost: 40m, code: "4172"),
            Price(7, price: 60m, cost: 40m, code: "4172"), // a second batch of the same product is not a clash
            Price(3, price: 10m, cost: 8m, code: "0012"),
        });

        var finding = Assert.Single(findings);
        Assert.Equal((FindingKind.SameCode, FindingLevel.FixNow, "Barcode 4172"), (finding.Kind, finding.Level, finding.Title));
        Assert.StartsWith("2 products share it: Product 7, Product 9.", finding.Detail);
    }

    [Fact]
    public void Items_sold_at_a_loss_this_week_are_added_up_per_product_and_price()
    {
        var findings = Run(lines: new[]
        {
            Line(101, 5, qty: 1m, rate: 10m, purchase: 12m), // ₹2 lost
            Line(102, 5, qty: 2m, rate: 10m, purchase: 12m), // ₹4 lost
            Line(103, 6, qty: 1m, rate: 10m, purchase: 10.30m), // 30 paise: rounding, not a loss
            Line(104, 7, qty: 1m, rate: 10m, purchase: 0m), // no purchase price saved on the bill
        });

        var finding = Assert.Single(findings);
        Assert.Equal((FindingKind.SoldAtLoss, FindingLevel.FixNow, 6m), (finding.Kind, finding.Level, finding.AtStake));
        Assert.Equal("Sold 3 at ₹10.00 each, ₹10.00 before GST, though bought at ₹12.00 before GST: ₹6.00 lost on bills SR/26-27/0102, SR/26-27/0101.", finding.Detail);
        Assert.Equal(102, finding.BillId);
    }

    [Fact]
    public void A_discount_that_makes_a_loss_says_what_was_paid()
    {
        // ₹20 each less 40%: ₹12 paid for each; with 5% GST that is ₹11.43 before GST, below the ₹15.24 paid for it.
        var line = Line(301, 13, qty: 2m, rate: 20m, purchase: 15.24m, discount: 16m) with { Taxable = 22.86m };

        var findings = Run(lines: new[] { line });

        var loss = findings.Single(f => f.Kind == FindingKind.SoldAtLoss);
        Assert.Equal("Sold 2 at ₹12.00 each after a discount, ₹11.43 before GST, though bought at ₹15.24 before GST: ₹7.62 lost on bill SR/26-27/0301.", loss.Detail);
        Assert.Contains(findings, f => f.Kind == FindingKind.BigDiscount);
    }

    [Fact]
    public void Items_billed_above_mrp_and_big_discounts_are_found_on_the_bills()
    {
        var findings = Run(lines: new[]
        {
            Line(201, 8, qty: 2m, rate: 32m, purchase: 20m, mrp: 30m),
            Line(204, 8, qty: 1m, rate: 32m, purchase: 20m, mrp: 30m, discount: 2m), // discounted back to the MRP: fine
            Line(202, 9, qty: 1m, rate: 100m, purchase: 50m, discount: 30m), // 30% off
            Line(203, 9, qty: 1m, rate: 100m, purchase: 50m, discount: 29m), // just under
        });

        Assert.Equal(new[] { FindingKind.SoldAboveMrp, FindingKind.BigDiscount }, findings.Select(f => f.Kind));
        Assert.Equal("Billed at ₹32.00 each, above its MRP of ₹30.00: customers paid ₹4.00 too much on bill SR/26-27/0201.", findings[0].Detail);
        Assert.Equal(FindingLevel.CheckSoon, findings[1].Level);
        Assert.Equal("Product 9, bill SR/26-27/0202", findings[1].Title);
        Assert.StartsWith("₹30.00 off (30%)", findings[1].Detail);
    }

    [Fact]
    public void A_discount_on_the_whole_bill_is_shared_out_over_its_lines()
    {
        // ₹50 off a ₹500 bill is 10% off each line: the ₹100 item bought at ₹92 was sold for ₹90, and the one billed
        // at ₹100 against a ₹95 MRP was paid ₹90, within its MRP.
        var findings = Run(lines: new[]
        {
            Line(401, 20, qty: 1m, rate: 100m, purchase: 92m, billDiscount: 50m),
            Line(401, 21, qty: 2m, rate: 150m, purchase: 60m, billDiscount: 50m),
            Line(401, 22, qty: 1m, rate: 100m, purchase: 50m, mrp: 95m, billDiscount: 50m),
        });

        var loss = Assert.Single(findings);
        Assert.Equal((FindingKind.SoldAtLoss, 20, 2m), (loss.Kind, loss.ProductId!.Value, loss.AtStake));
        Assert.Equal("Sold 1 at ₹90.00 each after a discount, ₹90.00 before GST, though bought at ₹92.00 before GST: ₹2.00 lost on bill SR/26-27/0401.", loss.Detail);
    }

    [Fact]
    public void A_big_discount_on_a_whole_bill_is_one_finding_for_the_bill()
    {
        var findings = Run(lines: new[]
        {
            Line(402, 30, qty: 1m, rate: 500m, purchase: 100m, billDiscount: 300m),
            Line(402, 31, qty: 2m, rate: 250m, purchase: 100m, billDiscount: 300m),
            Line(403, 31, qty: 2m, rate: 250m, purchase: 100m, billDiscount: 149m), // under 30%
        });

        var finding = Assert.Single(findings);
        Assert.Equal((FindingKind.BigDiscount, FindingLevel.CheckSoon, "Bill SR/26-27/0402"), (finding.Kind, finding.Level, finding.Title));
        Assert.Equal("₹300.00 off the whole bill (30% of ₹1,000.00) on 22 Sept.", finding.Detail);
        Assert.Equal((402L, (int?)null, 300m), (finding.BillId!.Value, finding.ProductId, finding.AtStake));
    }

    [Fact]
    public void Sales_added_up_over_bills_show_again_after_another_sale_like_them()
    {
        var older = Line(101, 5, qty: 1m, rate: 10m, purchase: 12m);
        var newer = Line(102, 5, qty: 1m, rate: 10m, purchase: 12m);
        var aboveMrp = Line(201, 8, qty: 1m, rate: 32m, purchase: 20m, mrp: 30m);
        var aboveMrpAgain = Line(203, 8, qty: 1m, rate: 32m, purchase: 20m, mrp: 30m);

        var before = Run(lines: new[] { older, aboveMrp }).Select(f => f.Key).ToList();
        var after = Run(lines: new[] { older, newer, aboveMrp, aboveMrpAgain }).Select(f => f.Key).ToList();
        var olderGone = Run(lines: new[] { newer, aboveMrpAgain }).Select(f => f.Key).ToList();

        Assert.Equal(2, before.Count);
        Assert.Empty(before.Intersect(after)); // marked as on purpose before: shown again
        Assert.Equal(after, olderGone); // older bills leaving the week change nothing
    }

    [Fact]
    public async Task Prices_before_gst_get_gst_added_before_they_are_checked()
    {
        // ₹100 before 18% GST is ₹118 to the customer, above the ₹90 cost with GST (₹106.20). Read as ₹100 with GST
        // included, it would be below cost.
        var checks = new PricesOnly(Price(1, price: 100m, cost: 90m, gst: 18m, mrp: 120m));
        var invoices = new DemoStore(new FixedClock(new DateTimeOffset(2026, 9, 26, 11, 0, 0, TimeSpan.FromHours(5.5))), seedSales: false);

        var exclusive = await checks.LoadCheckFactsAsync(invoices, Today, pricesIncludeTax: false);
        var inclusive = await checks.LoadCheckFactsAsync(invoices, Today, pricesIncludeTax: true);

        Assert.Equal(118m, Assert.Single(exclusive.Prices).Price);
        Assert.Empty(ShopChecks.Run(exclusive));
        Assert.Equal(FindingKind.BelowCost, Assert.Single(ShopChecks.Run(inclusive)).Kind);
    }

    [Fact]
    public void Gaps_in_the_bills_numbering_are_found()
    {
        var bills = new[]
        {
            new BillStub(100, "SR/26-27/0100", new DateTime(2026, 9, 20)),
            new BillStub(101, "SR/26-27/0101", new DateTime(2026, 9, 20)),
            new BillStub(104, "SR/26-27/0104", new DateTime(2026, 9, 21)),
            new BillStub(105, "SR/26-27/0105", new DateTime(2026, 9, 21)),
        };

        var finding = Assert.Single(Run(bills: bills));

        Assert.Equal((FindingKind.MissingBills, "2 bills missing after SR/26-27/0101"), (finding.Kind, finding.Title));
        Assert.Contains("Between bill SR/26-27/0101 (20 Sept) and bill SR/26-27/0104 (21 Sept)", finding.Detail);
    }

    [Fact]
    public void Money_owed_for_long_is_one_finding()
    {
        var finding = Assert.Single(Run(owed: new OwedBills(3, 1500m, new DateOnly(2026, 8, 27))));

        Assert.Equal((FindingKind.OwedLong, "₹1,500.00 owed for over 30 days"), (finding.Kind, finding.Title));
        Assert.Equal("3 bills given on credit before 27 Aug are still not fully paid.", finding.Detail);
        Assert.Empty(Run(owed: new OwedBills(0, 0m, new DateOnly(2026, 8, 27))));
    }

    [Fact]
    public void Fix_now_comes_first_then_the_most_money_at_stake()
    {
        var findings = Run(new[]
        {
            Price(1, price: 50m, cost: 0m, qty: 3m), // check soon
            Price(2, price: 9m, cost: 9.50m, qty: 1m), // below cost, ₹0.50 at stake
            Price(3, price: 9m, cost: 12m, qty: 1m), // below cost, ₹3 at stake
            Price(4, price: 32m, cost: 20m, mrp: 30m), // above MRP
        });

        Assert.Equal(new[] { 3, 2, 4, 1 }, findings.Select(f => f.ProductId!.Value));
    }

    [Fact]
    public void A_finding_keeps_its_key_until_its_figures_change()
    {
        var key = Assert.Single(Run(new[] { Price(1, price: 9m, cost: 9.50m) })).Key;

        Assert.Equal(key, Assert.Single(Run(new[] { Price(1, price: 9m, cost: 9.50m) })).Key);
        Assert.NotEqual(key, Assert.Single(Run(new[] { Price(1, price: 9.20m, cost: 9.50m) })).Key);
        Assert.NotEqual(key, Assert.Single(Run(new[] { Price(1, price: 9m, cost: 9.60m) })).Key);
    }

    [Fact]
    public void The_lowest_fair_price_is_cost_plus_gst_rounded_up_to_the_rupee()
    {
        Assert.Equal(10m, ShopChecks.LowestFairPrice(9.50m, 5m));
        Assert.Equal(118m, ShopChecks.LowestFairPrice(100m, 18m));
        Assert.Equal(100m, ShopChecks.BeforeGst(118m, 18m));
    }

    private sealed class PricesOnly(params PriceFacts[] prices) : IShopChecksRepository
    {
        public Task<IReadOnlyList<PriceFacts>> GetPricesAsync(CancellationToken ct = default) =>
            Task.FromResult<IReadOnlyList<PriceFacts>>(prices);

        public Task<IReadOnlyList<SoldLine>> GetSoldLinesAsync(DateRange range, CancellationToken ct = default) =>
            Task.FromResult<IReadOnlyList<SoldLine>>(Array.Empty<SoldLine>());

        public Task<IReadOnlyList<BillStub>> GetBillsAsync(DateRange range, CancellationToken ct = default) =>
            Task.FromResult<IReadOnlyList<BillStub>>(Array.Empty<BillStub>());
    }
}

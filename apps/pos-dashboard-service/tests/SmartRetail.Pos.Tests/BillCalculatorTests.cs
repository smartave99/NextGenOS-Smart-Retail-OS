using SmartRetail.Pos.Core;
using SmartRetail.Pos.Core.Billing;

namespace SmartRetail.Pos.Tests;

public class BillCalculatorTests
{
    private static readonly BillOptions Inclusive = new();
    private static readonly BillOptions Exclusive = new() { PricesIncludeTax = false };

    private static decimal D(string value) => decimal.Parse(value, System.Globalization.CultureInfo.InvariantCulture);

    private static BillLine Line(decimal rate, decimal qty = 1m, decimal gst = 0m, decimal discount = 0m) =>
        new() { Name = "Item", Rate = rate, Qty = qty, GstRatePercent = gst, DiscountPercent = discount };

    [Fact]
    public void Inclusive_prices_keep_the_shelf_price_and_work_the_tax_out()
    {
        var charge = BillCalculator.Line(Line(105m, gst: 5m), Inclusive);

        Assert.Equal(100m, charge.Taxable);
        Assert.Equal(2.50m, charge.Cgst);
        Assert.Equal(2.50m, charge.Sgst);
        Assert.Equal(0m, charge.Igst);
        Assert.Equal(105m, charge.LineTotal);
    }

    [Fact]
    public void Inclusive_split_puts_the_odd_paisa_on_cgst_and_still_adds_up()
    {
        // 100 / 1.18 = 84.7457… → 84.75, so the tax is 15.25 and cannot split evenly.
        var charge = BillCalculator.Line(Line(100m, gst: 18m), Inclusive);

        Assert.Equal(84.75m, charge.Taxable);
        Assert.Equal(7.63m, charge.Cgst);
        Assert.Equal(7.62m, charge.Sgst);
        Assert.Equal(15.25m, charge.Tax);
        Assert.Equal(100m, charge.LineTotal);
    }

    [Fact]
    public void Exclusive_prices_add_cgst_and_sgst_at_half_the_rate_each()
    {
        var charge = BillCalculator.Line(Line(50m, qty: 2m, gst: 18m), Exclusive);

        Assert.Equal(100m, charge.Taxable);
        Assert.Equal(9m, charge.Cgst);
        Assert.Equal(9m, charge.Sgst);
        Assert.Equal(118m, charge.LineTotal);
    }

    [Fact]
    public void Interstate_sales_charge_igst_only()
    {
        var exclusive = BillCalculator.Line(Line(50m, qty: 2m, gst: 18m), Exclusive with { GstMode = GstMode.Interstate });
        var inclusive = BillCalculator.Line(Line(118m, gst: 18m), Inclusive with { GstMode = GstMode.Interstate });

        Assert.Equal((0m, 0m, 18m, 118m), (exclusive.Cgst, exclusive.Sgst, exclusive.Igst, exclusive.LineTotal));
        Assert.Equal((100m, 18m, 118m), (inclusive.Taxable, inclusive.Igst, inclusive.LineTotal));
    }

    [Fact]
    public void Discount_comes_off_before_tax()
    {
        var charge = BillCalculator.Line(Line(200m, qty: 3m, gst: 5m, discount: 10m), Inclusive);

        Assert.Equal(600m, charge.Gross);
        Assert.Equal(60m, charge.Discount);
        Assert.Equal(514.29m, charge.Taxable);
        Assert.Equal(25.71m, charge.Tax);
        Assert.Equal(540m, charge.LineTotal);
    }

    [Theory]
    [InlineData(150, 0)]
    [InlineData(-20, 50)]
    public void Discount_outside_0_to_100_percent_is_clamped(int discount, int expectedTotal)
    {
        var charge = BillCalculator.Line(Line(50m, discount: discount), Inclusive);

        Assert.Equal(expectedTotal, charge.LineTotal);
    }

    [Fact]
    public void Loose_quantities_are_charged_to_the_paisa()
    {
        Assert.Equal(100m, BillCalculator.Line(Line(80m, qty: 1.25m), Inclusive).LineTotal);
        Assert.Equal(99.99m, BillCalculator.Line(Line(33.33m, qty: 3m), Inclusive).LineTotal);
    }

    [Fact]
    public void Bill_totals_match_the_counter_example()
    {
        // The bill rung up in the browser test: rice with 10% off, two milks, one chocolate.
        var lines = new[]
        {
            Line(549m, gst: 5m, discount: 10m),
            Line(28m, qty: 2m),
            Line(45m, gst: 5m),
        };

        var totals = BillCalculator.Totals(lines, Inclusive);

        Assert.Equal(3, totals.ItemCount);
        Assert.Equal(4m, totals.TotalQty);
        Assert.Equal(54.90m, totals.Discount);
        Assert.Equal(569.43m, totals.Taxable);
        Assert.Equal(12.84m, totals.Cgst);
        Assert.Equal(12.83m, totals.Sgst);
        Assert.Equal(595.10m, totals.SubTotal);
        Assert.Equal(-0.10m, totals.RoundOff);
        Assert.Equal(595m, totals.GrandTotal);
    }

    [Theory]
    [InlineData("347.50", "348", "0.50")]
    [InlineData("347.49", "347", "-0.49")]
    [InlineData("347.00", "347", "0")]
    public void Grand_total_rounds_to_the_nearest_rupee(string price, string grand, string roundOff)
    {
        var totals = BillCalculator.Totals(new[] { Line(D(price)) }, Inclusive);

        Assert.Equal(D(grand), totals.GrandTotal);
        Assert.Equal(D(roundOff), totals.RoundOff);
    }

    [Fact]
    public void Rounding_to_the_rupee_can_be_switched_off()
    {
        var totals = BillCalculator.Totals(new[] { Line(347.49m) }, Inclusive with { RoundToNearestRupee = false });

        Assert.Equal(347.49m, totals.GrandTotal);
        Assert.Equal(0m, totals.RoundOff);
    }

    [Fact]
    public void An_empty_bill_is_all_zero()
    {
        Assert.Equal(BillTotals.Empty, BillCalculator.Totals(Array.Empty<BillLine>(), Inclusive));
    }

    [Fact]
    public void Every_line_adds_up_to_the_paisa()
    {
        var random = new Random(7);
        foreach (var options in AllOptions())
        {
            for (var i = 0; i < 1000; i++)
            {
                var charge = BillCalculator.Line(RandomLine(random), options);

                Assert.Equal(charge.LineTotal, charge.Taxable + charge.Tax);
                Assert.Equal(charge.Gross - charge.Discount, options.PricesIncludeTax ? charge.LineTotal : charge.Taxable);
                foreach (var amount in new[] { charge.Gross, charge.Discount, charge.Taxable, charge.Cgst, charge.Sgst, charge.Igst, charge.LineTotal })
                {
                    Assert.Equal(Money.Round(amount), amount);
                    Assert.True(amount >= 0m, $"negative amount {amount}");
                }

                if (options.GstMode == GstMode.Interstate)
                {
                    Assert.Equal(0m, charge.Cgst + charge.Sgst);
                }
                else
                {
                    Assert.Equal(0m, charge.Igst);
                    Assert.InRange(charge.Cgst - charge.Sgst, 0m, 0.01m);
                }
            }
        }
    }

    [Fact]
    public void Every_bill_adds_up_to_the_paisa()
    {
        var random = new Random(11);
        foreach (var options in AllOptions())
        {
            for (var i = 0; i < 300; i++)
            {
                var lines = Enumerable.Range(0, random.Next(1, 25)).Select(_ => RandomLine(random)).ToList();
                var totals = BillCalculator.Totals(lines, options);

                Assert.Equal(lines.Sum(l => BillCalculator.Line(l, options).LineTotal), totals.SubTotal);
                Assert.Equal(totals.SubTotal, totals.Taxable + totals.Tax);
                Assert.Equal(totals.GrandTotal, totals.SubTotal + totals.RoundOff);
                Assert.InRange(totals.RoundOff, -0.50m, 0.50m);
                Assert.Equal(decimal.Truncate(totals.GrandTotal), totals.GrandTotal);
            }
        }
    }

    private static IEnumerable<BillOptions> AllOptions() =>
        from inclusive in new[] { true, false }
        from mode in new[] { GstMode.Intrastate, GstMode.Interstate }
        select new BillOptions { PricesIncludeTax = inclusive, GstMode = mode };

    private static BillLine RandomLine(Random random)
    {
        decimal[] gstRates = { 0m, 0.25m, 3m, 5m, 12m, 18m, 28m, 40m };
        return Line(
            rate: random.Next(1, 500_000) / 100m,
            qty: random.Next(1, 5000) / 1000m * (random.Next(2) == 0 ? 1 : 10),
            gst: gstRates[random.Next(gstRates.Length)],
            discount: random.Next(3) == 0 ? random.Next(0, 10_001) / 100m : 0m);
    }
}

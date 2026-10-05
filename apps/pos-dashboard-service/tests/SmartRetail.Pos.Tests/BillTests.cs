using SmartRetail.Pos.Core.Billing;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Tests;

public class BillTests
{
    private static readonly DateTime Noon = new(2026, 9, 24, 12, 0, 0);

    private static Product P(int id, decimal price, decimal gst = 0m) =>
        new() { Id = id, Code = id.ToString(), Name = "Item " + id, SellingPrice = price, GstRatePercent = gst, HsnCode = "0000" };

    [Fact]
    public void Adding_a_product_already_on_the_bill_raises_its_quantity()
    {
        var bill = new Bill();
        var product = P(1, 10m);

        bill.Add(product);
        bill.Add(product, 2m);

        var line = Assert.Single(bill.Lines);
        Assert.Equal(3m, line.Qty);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Adding_a_zero_or_negative_quantity_is_refused(int qty)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Bill().Add(P(1, 10m), qty));
    }

    [Fact]
    public void An_empty_bill_cannot_be_saved()
    {
        Assert.Contains("Add at least one item.", new Bill().Problems(0m));
    }

    [Fact]
    public void A_walk_in_customer_must_pay_in_full()
    {
        var bill = new Bill();
        bill.Add(P(1, 500m));

        Assert.Contains("Choose a customer to save a bill that is not fully paid.", bill.Problems(499m));
        Assert.Empty(bill.Problems(500m));
    }

    [Fact]
    public void A_named_customer_can_take_credit()
    {
        var bill = new Bill { Customer = new Customer { Id = 7, Name = "Priya Sharma" } };
        bill.Add(P(1, 500m));

        var invoice = bill.ToInvoice(PaymentModes.Cash, 200m, Noon);

        Assert.Equal(7, invoice.CustomerId);
        Assert.Equal("Priya Sharma", invoice.CustomerName);
        Assert.Equal(500m, invoice.Totals.GrandTotal);
        Assert.Equal(200m, invoice.Paid);
        Assert.Equal(300m, invoice.Balance);
        Assert.Equal(0m, invoice.ChangeDue);
    }

    [Fact]
    public void Paying_more_than_the_bill_gives_change()
    {
        var bill = new Bill();
        bill.Add(P(1, 347m));

        var invoice = bill.ToInvoice(PaymentModes.Cash, 500m, Noon);

        Assert.Null(invoice.CustomerId);
        Assert.Equal("Walk-in customer", invoice.CustomerName);
        Assert.Equal(347m, invoice.Paid);
        Assert.Equal(0m, invoice.Balance);
        Assert.Equal(153m, invoice.ChangeDue);
    }

    [Fact]
    public void Bad_lines_and_amounts_are_reported()
    {
        var bill = new Bill();
        var line = bill.Add(P(1, 10m));
        line.Qty = 0m;
        line.Rate = -1m;
        line.DiscountPercent = 150m;

        var problems = bill.Problems(-5m);

        Assert.Contains("Quantity of Item 1 must be more than zero.", problems);
        Assert.Contains("Rate of Item 1 cannot be negative.", problems);
        Assert.Contains("Discount on Item 1 must be between 0% and 100%.", problems);
        Assert.Contains("Amount received cannot be negative.", problems);
    }

    [Fact]
    public void A_bill_with_problems_cannot_be_turned_into_an_invoice()
    {
        var error = Assert.Throws<InvalidOperationException>(() => new Bill().ToInvoice(PaymentModes.Cash, 0m, Noon));

        Assert.Contains("Add at least one item.", error.Message);
    }

    [Fact]
    public void The_invoice_carries_each_lines_money()
    {
        var bill = new Bill();
        var line = bill.Add(P(1, 105m, gst: 5m), 2m);
        line.DiscountPercent = 10m;

        var saved = Assert.Single(bill.ToInvoice(PaymentModes.Upi, 189m, Noon).Lines);

        Assert.Equal((1, "1", "Item 1", "0000"), (saved.ProductId, saved.Code, saved.Name, saved.HsnCode));
        Assert.Equal((2m, 105m, 10m, 5m), (saved.Qty, saved.Rate, saved.DiscountPercent, saved.GstRatePercent));
        Assert.Equal((21m, 180m, 9m, 189m), (saved.Discount, saved.Taxable, saved.Tax, saved.LineTotal));
    }

    [Fact]
    public void Removing_and_clearing_lines()
    {
        var bill = new Bill { Customer = new Customer { Id = 3, Name = "Anil Verma" } };
        var first = bill.Add(P(1, 10m));
        bill.Add(P(2, 20m));

        bill.Remove(first);
        Assert.Equal(2, Assert.Single(bill.Lines).ProductId);

        bill.Clear();
        Assert.True(bill.IsEmpty);
        Assert.True(bill.Customer.IsWalkIn);
    }
}

using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Data.SqlServer;

namespace SmartRetail.Pos.Tests.SqlServer;

/// <summary>A discount on the whole bill, in a database of its own so the other tests' bills stay as they are.</summary>
public sealed class SqlServerBillDiscountTests : IClassFixture<PosTestDatabase>
{
    private readonly PosTestDatabase _database;

    public SqlServerBillDiscountTests(PosTestDatabase database) => _database = database;

    private SqlDb Db => new(_database.ConnectionString, 15);

    [SqlServerFact]
    public async Task The_checks_share_a_discount_on_the_whole_bill_out_over_its_lines()
    {
        // ₹50 off and a ₹5 offer on a ₹605 bill take 1/11 off each line: the rice, bought at ₹480 before GST, was
        // sold for ₹475.33 before GST.
        await _database.ExecuteAsync(@"
INSERT INTO InvoiceInfo (Inv_ID, InvoiceNo, InvoiceDate, Customer_ID, SubTotal, BillDiscount, OfferAmt, GrandTotal, TotalPaid, Balance) VALUES
    (5, N'SR/26-27/0005', '2026-09-25T00:00:00', 1, 605, 50, 5, 550, 550, 0);
INSERT INTO Invoice_Product (InvoiceID, ProductID, SalesRate, Qty, DiscountPer, Discount, CGSTPer, CGSTAmt, TotalAmount, TaxableAmt, PurchaseRate, Margin) VALUES
    (5, 1, 549, 1, 0, 0, 2.5, 13.07, 549, 522.86, 480, 42.86),
    (5, 2, 28, 2, 0, 0, 0, 0, 56, 56, 25, 6);");
        var repository = new SqlServerShopChecksRepository(Db);

        var lines = await repository.GetSoldLinesAsync(new DateRange(new DateOnly(2026, 9, 25), new DateOnly(2026, 9, 25)));
        var facts = await repository.LoadCheckFactsAsync(new SqlServerInvoiceRepository(Db), new DateOnly(2026, 9, 26), pricesIncludeTax: true);

        Assert.Equal(new[] { (4L, 0m), (5L, 55m), (5L, 55m) }, lines.Select(l => (l.BillId, l.BillDiscount)));
        var loss = Assert.Single(ShopChecks.Run(facts), f => f.Kind == FindingKind.SoldAtLoss);
        Assert.Equal((1, 5L), (loss.ProductId!.Value, loss.BillId!.Value));
        Assert.Equal("Sold 1 at ₹499.09 each after a discount, ₹475.33 before GST, though bought at ₹480.00 before GST: ₹4.67 lost on bill SR/26-27/0005.", loss.Detail);
    }
}

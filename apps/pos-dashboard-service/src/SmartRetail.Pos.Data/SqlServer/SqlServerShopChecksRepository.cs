using System.Data;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Checks;

namespace SmartRetail.Pos.Data.SqlServer;

/// <summary>
/// The Fix now checks' figures from the POS tables, read-only like every query here. Prices come from each stock
/// batch (<c>Temp_Stock</c>: SPrice, MRP, PPrice), falling back to the product's own; GST is Product.CGST + SGST.
/// </summary>
public sealed class SqlServerShopChecksRepository : IShopChecksRepository
{
    // Inactive products (Status "No", "Inactive", …) are not sold, so their prices do not matter.
    private const string ActiveOnly = "RTRIM(ISNULL(p.Status, N'')) NOT IN (N'No', N'N', N'0', N'Inactive', N'Deactive', N'Disabled')";

    private readonly SqlDb _db;

    public SqlServerShopChecksRepository(SqlDb db) => _db = db;

    public async Task<IReadOnlyList<PriceFacts>> GetPricesAsync(CancellationToken ct = default)
    {
        const string sql = @"
SELECT p.PID, RTRIM(p.ProductName),
       COALESCE(NULLIF(RTRIM(t.Barcode), N''), NULLIF(RTRIM(p.Barcode), N''), RTRIM(p.ProductCode)),
       COALESCE(NULLIF(t.SPrice, 0), p.SellingPrice, 0),
       COALESCE(NULLIF(t.MRP, 0), p.MRP, 0),
       COALESCE(NULLIF(t.PPrice, 0), p.CostPrice, 0),
       ISNULL(p.CGST, 0) + ISNULL(p.SGST, 0),
       ISNULL(t.Qty, 0)
FROM Product p
LEFT JOIN Temp_Stock t ON t.ProductID = p.PID
WHERE " + ActiveOnly + @"
ORDER BY p.PID, t.Id";

        return await _db.QueryAsync(sql, _ => { }, r => new PriceFacts
        {
            ProductId = r.GetInt32(0),
            Name = SqlDb.Text(r, 1) ?? "",
            Code = SqlDb.Text(r, 2) ?? "",
            Price = SqlDb.Number(r, 3),
            Mrp = SqlDb.Number(r, 4),
            Cost = SqlDb.Number(r, 5),
            GstPercent = SqlDb.Number(r, 6),
            Qty = SqlDb.Number(r, 7),
        }, ct).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<SoldLine>> GetSoldLinesAsync(DateRange range, CancellationToken ct = default)
    {
        // Before GST: the POS's own taxable amount, or the amount with its GST taken out when that is not saved.
        // The lines add up to the bill before its own discount (SubTotal); the checks share that discount out.
        const string sql = @"
SELECT i.Inv_ID, RTRIM(i.InvoiceNo), i.InvoiceDate, ip.ProductID,
       COALESCE(NULLIF(RTRIM(CAST(ip.Descr AS nvarchar(400))), N''), RTRIM(p.ProductName), N''),
       ip.Qty, ip.SalesRate, ISNULL(ip.MRP, 0), ip.Discount, ip.TotalAmount,
       ISNULL(ip.TaxableAmt, ip.TotalAmount / (1 + (ip.CGSTPer + ISNULL(ip.SGSTPer, 0) + ISNULL(ip.IGSTPer, 0)) / 100)),
       ip.PurchaseRate, ISNULL(i.BillDiscount, 0) + ISNULL(i.OfferAmt, 0)
FROM Invoice_Product ip
JOIN InvoiceInfo i ON i.Inv_ID = ip.InvoiceID
LEFT JOIN Product p ON p.PID = ip.ProductID
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
ORDER BY i.InvoiceDate, i.Inv_ID, ip.IPo_ID";

        return await _db.QueryAsync(sql, ps => Bind(ps, range), r => new SoldLine
        {
            BillId = r.GetInt32(0),
            BillNumber = SqlDb.Text(r, 1) ?? "",
            Date = r.GetDateTime(2),
            ProductId = r.GetInt32(3),
            Name = SqlDb.Text(r, 4) ?? "",
            Qty = SqlDb.Number(r, 5),
            Rate = SqlDb.Number(r, 6),
            Mrp = SqlDb.Number(r, 7),
            Discount = SqlDb.Number(r, 8),
            Amount = SqlDb.Number(r, 9),
            Taxable = Math.Round(SqlDb.Number(r, 10), 2, MidpointRounding.AwayFromZero),
            PurchaseRate = SqlDb.Number(r, 11),
            BillDiscount = SqlDb.Number(r, 12),
        }, ct).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<BillStub>> GetBillsAsync(DateRange range, CancellationToken ct = default)
    {
        const string sql = @"
SELECT i.Inv_ID, RTRIM(i.InvoiceNo), i.InvoiceDate
FROM InvoiceInfo i
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
ORDER BY i.Inv_ID";

        return await _db.QueryAsync(sql, ps => Bind(ps, range), r => new BillStub(
            r.GetInt32(0), SqlDb.Text(r, 1) ?? "", r.GetDateTime(2)), ct).ConfigureAwait(false);
    }

    private static void Bind(Microsoft.Data.SqlClient.SqlParameterCollection ps, DateRange range)
    {
        ps.Add("@from", SqlDbType.DateTime).Value = range.From.ToDateTime(TimeOnly.MinValue);
        ps.Add("@to", SqlDbType.DateTime).Value = range.To.AddDays(1).ToDateTime(TimeOnly.MinValue);
    }
}

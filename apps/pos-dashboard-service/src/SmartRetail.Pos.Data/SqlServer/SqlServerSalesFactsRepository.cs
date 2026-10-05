using System.Data;
using Microsoft.Data.SqlClient;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Data.SqlServer;

/// <summary>
/// Sales history from the POS tables, added up by day (and by product and day) inside SQL Server, so a busy
/// year stays a few thousand rows. Bills: <c>InvoiceInfo</c>; lines: <c>Invoice_Product</c>; payments:
/// <c>Invoice_Payment</c>; returns: <c>SalesReturn</c>; bill times: the POS log (<see cref="PosLog"/>). Read-only.
/// </summary>
public sealed class SqlServerSalesFactsRepository : ISalesFactsRepository
{
    private readonly SqlDb _db;

    public SqlServerSalesFactsRepository(SqlDb db) => _db = db;

    public async Task<BillSpan?> GetBillSpanAsync(CancellationToken ct = default)
    {
        const string sql = "SELECT MIN(i.InvoiceDate), MAX(i.InvoiceDate) FROM InvoiceInfo i";
        var rows = await _db.QueryAsync(sql, _ => { }, r => r.IsDBNull(0) || r.IsDBNull(1)
            ? null
            : new BillSpan(DateOnly.FromDateTime(r.GetDateTime(0)), DateOnly.FromDateTime(r.GetDateTime(1))), ct).ConfigureAwait(false);
        return rows[0];
    }

    public async Task<SalesFacts> GetFactsAsync(DateRange range, CancellationToken ct = default)
    {
        var log = await _db.CanReadLogAsync(ct).ConfigureAwait(false);
        return new SalesFacts
        {
            Range = range,
            Days = await DaysAsync(range, ct).ConfigureAwait(false),
            Hours = log ? await HoursAsync(range, ct).ConfigureAwait(false) : Array.Empty<HourSales>(),
            TimesReadable = log,
            ProductDays = await ProductDaysAsync(range, ct).ConfigureAwait(false),
            Payments = await PaymentsAsync(range, ct).ConfigureAwait(false),
            Customers = await CustomersAsync(range, ct).ConfigureAwait(false),
        };
    }

    public async Task<IReadOnlyList<ProductFacts>> GetProductsAsync(CancellationToken ct = default)
    {
        // A category is linked through the subcategory, by name (SubCategory.Category = Category.CategoryName).
        const string sql = @"
SELECT p.PID, RTRIM(p.ProductCode), RTRIM(p.ProductName), RTRIM(sc.Category), RTRIM(sc.SubCategoryName),
       ISNULL(s.InHand, 0), ISNULL(p.MinStock, 0), ISNULL(p.CostPrice, 0), ISNULL(p.SellingPrice, 0),
       CASE WHEN RTRIM(ISNULL(p.Status, N'')) IN (N'No', N'N', N'0', N'Inactive', N'Deactive', N'Disabled') THEN 0 ELSE 1 END,
       p.AddDate, ISNULL(p.CGST, 0) + ISNULL(p.SGST, 0)
FROM Product p
LEFT JOIN SubCategory sc ON sc.ID = p.SubCategoryID
OUTER APPLY (SELECT SUM(ts.Qty) AS InHand FROM Temp_Stock ts WHERE ts.ProductID = p.PID) s";

        return await _db.QueryAsync(sql, _ => { }, r => new ProductFacts
        {
            Id = r.GetInt32(0),
            Code = SqlDb.Text(r, 1) ?.Trim() ?? "",
            Name = SqlDb.Text(r, 2) ?.Trim() ?? "",
            Category = SqlDb.Text(r, 3) ?.Trim() ?? "",
            SubCategory = SqlDb.Text(r, 4) ?.Trim() ?? "",
            StockInHand = SqlDb.Number(r, 5),
            MinStock = SqlDb.Number(r, 6),
            CostPrice = SqlDb.Number(r, 7),
            SellingPrice = SqlDb.Number(r, 8),
            Active = r.GetInt32(9) == 1,
            AddedOn = r.IsDBNull(10) ? null : DateOnly.FromDateTime(r.GetDateTime(10)),
            GstRatePercent = SqlDb.Number(r, 11),
        }, ct).ConfigureAwait(false);
    }

    private async Task<IReadOnlyList<DaySales>> DaysAsync(DateRange range, CancellationToken ct)
    {
        const string bills = @"
SELECT CAST(i.InvoiceDate AS date), COUNT(*), ISNULL(SUM(i.GrandTotal), 0),
       ISNULL(SUM(CASE WHEN i.Balance > 0 THEN i.Balance ELSE 0 END), 0)
FROM InvoiceInfo i
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
GROUP BY CAST(i.InvoiceDate AS date)";

        const string returns = @"
SELECT CAST(r.[Date] AS date), ISNULL(SUM(r.GrandTotal), 0)
FROM SalesReturn r
WHERE r.[Date] >= @from AND r.[Date] < @to
GROUP BY CAST(r.[Date] AS date)";

        var days = await _db.QueryAsync(bills, Bind(range), r => new DaySales
        {
            Day = DateOnly.FromDateTime(r.GetDateTime(0)),
            Bills = r.GetInt32(1),
            Sales = SqlDb.Number(r, 2),
            Outstanding = SqlDb.Number(r, 3),
        }, ct).ConfigureAwait(false);

        var returned = await _db.QueryAsync(returns, Bind(range), r => (Day: DateOnly.FromDateTime(r.GetDateTime(0)), Amount: SqlDb.Number(r, 1)), ct)
            .ConfigureAwait(false);
        foreach (var (day, amount) in returned)
        {
            var index = days.FindIndex(d => d.Day == day);
            if (index >= 0)
            {
                days[index] = days[index] with { Returns = amount };
            }
            else
            {
                days.Add(new DaySales { Day = day, Returns = amount });
            }
        }

        return days.OrderBy(d => d.Day).ToList();
    }

    // Only bills saved on their own date: one typed in on a later day was not made at the hour it was saved.
    private static readonly string HoursSql = @"
WITH " + PosLog.SavedBills(true, "@from") + @"
SELECT CAST(i.InvoiceDate AS date), DATEPART(hour, s.SavedAt), COUNT(*), ISNULL(SUM(i.GrandTotal), 0)
FROM InvoiceInfo i
JOIN saved s ON s.Number = RTRIM(i.InvoiceNo)
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
  AND CAST(s.SavedAt AS date) = CAST(i.InvoiceDate AS date)
GROUP BY CAST(i.InvoiceDate AS date), DATEPART(hour, s.SavedAt)";

    private async Task<IReadOnlyList<HourSales>> HoursAsync(DateRange range, CancellationToken ct)
    {
        return await _db.QueryAsync(HoursSql, Bind(range), r => new HourSales
        {
            Day = DateOnly.FromDateTime(r.GetDateTime(0)),
            Hour = r.GetInt32(1),
            Bills = r.GetInt32(2),
            Sales = SqlDb.Number(r, 3),
        }, ct).ConfigureAwait(false);
    }

    private static readonly string[] BillTimesSql = { BillTimesQuery(false), BillTimesQuery(true) };

    private static string BillTimesQuery(bool log) => @"
WITH " + PosLog.SavedBills(log, "@from") + @"
SELECT CAST(i.InvoiceDate AS date), s.SavedAt, ISNULL(i.GrandTotal, 0)
FROM InvoiceInfo i
LEFT JOIN saved s ON s.Number = RTRIM(i.InvoiceNo)
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
ORDER BY i.InvoiceDate, i.Inv_ID";

    public async Task<IReadOnlyList<BillTime>> GetBillTimesAsync(DateRange range, CancellationToken ct = default)
    {
        var sql = BillTimesSql[await _db.CanReadLogAsync(ct).ConfigureAwait(false) ? 1 : 0];
        return await _db.QueryAsync(sql, Bind(range), r => new BillTime(
            DateOnly.FromDateTime(r.GetDateTime(0)),
            r.IsDBNull(1) ? null : r.GetDateTime(1),
            SqlDb.Number(r, 2)), ct).ConfigureAwait(false);
    }

    private async Task<IReadOnlyList<ProductDaySales>> ProductDaysAsync(DateRange range, CancellationToken ct)
    {
        // Profit is only worked out on lines with a purchase price, as the POS's own Margin column does
        // (Margin = TaxableAmt - PurchaseRate * Qty).
        const string sql = @"
SELECT CAST(i.InvoiceDate AS date), ip.ProductID,
       SUM(ip.Qty),
       SUM(ip.TotalAmount),
       SUM(ISNULL(ip.TaxableAmt, ip.TotalAmount)),
       SUM(CASE WHEN ip.PurchaseRate > 0 THEN ISNULL(ip.TaxableAmt, ip.TotalAmount) ELSE 0 END),
       SUM(CASE WHEN ip.PurchaseRate > 0 THEN ip.PurchaseRate * ip.Qty ELSE 0 END),
       COUNT(DISTINCT ip.InvoiceID)
FROM Invoice_Product ip
JOIN InvoiceInfo i ON i.Inv_ID = ip.InvoiceID
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
GROUP BY CAST(i.InvoiceDate AS date), ip.ProductID";

        return await _db.QueryAsync(sql, Bind(range), r => new ProductDaySales
        {
            Day = DateOnly.FromDateTime(r.GetDateTime(0)),
            ProductId = r.GetInt32(1),
            Qty = SqlDb.Number(r, 2),
            Sales = SqlDb.Number(r, 3),
            SalesBeforeTax = SqlDb.Number(r, 4),
            CostedSalesBeforeTax = SqlDb.Number(r, 5),
            Cost = SqlDb.Number(r, 6),
            Bills = r.GetInt32(7),
        }, ct).ConfigureAwait(false);
    }

    private async Task<IReadOnlyList<PaymentTotal>> PaymentsAsync(DateRange range, CancellationToken ct)
    {
        const string sql = @"
SELECT RTRIM(p.PaymentMode), COUNT(*), ISNULL(SUM(p.TotalPaid), 0)
FROM Invoice_Payment p
JOIN InvoiceInfo i ON i.Inv_ID = p.InvoiceID
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
GROUP BY RTRIM(p.PaymentMode)";

        return await _db.QueryAsync(sql, Bind(range), r => new PaymentTotal
        {
            Mode = SqlDb.Text(r, 0) ?.Trim() ?? "",
            Payments = r.GetInt32(1),
            Amount = SqlDb.Number(r, 2),
        }, ct).ConfigureAwait(false);
    }

    private async Task<IReadOnlyList<CustomerFacts>> CustomersAsync(DateRange range, CancellationToken ct)
    {
        const string sql = @"
WITH firsts AS (
    SELECT Customer_ID, MIN(InvoiceDate) AS FirstBill FROM InvoiceInfo GROUP BY Customer_ID
)
SELECT i.Customer_ID, MAX(RTRIM(c.Name)), COUNT(*), ISNULL(SUM(i.GrandTotal), 0), MIN(f.FirstBill), MAX(i.InvoiceDate)
FROM InvoiceInfo i
JOIN firsts f ON f.Customer_ID = i.Customer_ID
LEFT JOIN Customer c ON c.ID = i.Customer_ID
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
GROUP BY i.Customer_ID";

        return await _db.QueryAsync(sql, Bind(range), r => new CustomerFacts
        {
            Id = r.GetInt32(0),
            Name = SqlDb.Text(r, 1) ?.Trim() ?? "",
            Bills = r.GetInt32(2),
            Sales = SqlDb.Number(r, 3),
            FirstBillEver = DateOnly.FromDateTime(r.GetDateTime(4)),
            LastBill = DateOnly.FromDateTime(r.GetDateTime(5)),
        }, ct).ConfigureAwait(false);
    }

    public async Task<int> CountBillsWithAsync(DateRange range, IReadOnlyCollection<int> productIds, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(productIds);
        var ids = productIds.Distinct().Take(SqlServerProductRepository.MaxBatchProducts).ToList();
        if (ids.Count == 0)
        {
            return 0;
        }

        // One parameter per product, as in GetBatchesAsync: only the parameter names are written into the query.
        var sql = $@"
SELECT COUNT(DISTINCT ip.InvoiceID)
FROM Invoice_Product ip
JOIN InvoiceInfo i ON i.Inv_ID = ip.InvoiceID
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to
  AND ip.ProductID IN ({string.Join(", ", ids.Select((_, i) => "@p" + i.ToString(System.Globalization.CultureInfo.InvariantCulture)))})";

        var rows = await _db.QueryAsync(sql, ps =>
        {
            Bind(range)(ps);
            for (var i = 0; i < ids.Count; i++)
            {
                ps.Add("@p" + i.ToString(System.Globalization.CultureInfo.InvariantCulture), SqlDbType.Int).Value = ids[i];
            }
        }, r => r.GetInt32(0), ct).ConfigureAwait(false);
        return rows[0];
    }

    private static Action<SqlParameterCollection> Bind(DateRange range) => ps =>
    {
        ps.Add("@from", SqlDbType.DateTime).Value = range.From.ToDateTime(TimeOnly.MinValue);
        ps.Add("@to", SqlDbType.DateTime).Value = range.To.AddDays(1).ToDateTime(TimeOnly.MinValue);
    };
}

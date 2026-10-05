using System.Data;
using Microsoft.Data.SqlClient;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Data.SqlServer;

/// <summary>
/// Products from the POS tables. The GST rate is Product.CGST + Product.SGST; stock in hand is the
/// sum of the product's Temp_Stock rows. Text columns are fixed-width nchar, hence RTRIM.
/// </summary>
public sealed class SqlServerProductRepository : IProductRepository
{
    private const string Select = @"
SELECT TOP (@limit)
    p.PID,
    RTRIM(p.ProductCode),
    RTRIM(p.ProductName),
    RTRIM(p.Barcode),
    RTRIM(p.HSNCode),
    RTRIM(sc.Category),
    ISNULL(p.SellingPrice, 0),
    ISNULL(p.MRP, 0),
    ISNULL(p.CGST, 0) + ISNULL(p.SGST, 0),
    ISNULL(p.MinStock, 0),
    ISNULL(st.InHand, 0)
FROM Product p
LEFT JOIN SubCategory sc ON sc.ID = p.SubCategoryID
OUTER APPLY (SELECT SUM(ts.Qty) AS InHand FROM Temp_Stock ts WHERE ts.ProductID = p.PID) st
";

    private readonly SqlDb _db;

    public SqlServerProductRepository(SqlDb db) => _db = db;

    public async Task<IReadOnlyList<Product>> SearchAsync(string? term, int limit, CancellationToken ct = default)
    {
        const string sql = Select + @"
WHERE @pattern IS NULL OR p.ProductName LIKE @pattern OR p.ProductCode LIKE @pattern OR p.Barcode LIKE @pattern
   OR EXISTS (SELECT 1 FROM Temp_Stock b WHERE b.ProductID = p.PID AND b.Barcode LIKE @pattern)
ORDER BY p.ProductName, p.PID";

        return await _db.QueryAsync(sql, ps =>
        {
            ps.Add("@limit", SqlDbType.Int).Value = limit;
            ps.Add("@pattern", SqlDbType.NVarChar, 210).Value = (object?)SqlDb.ContainsPattern(term) ?? DBNull.Value;
        }, Map, ct).ConfigureAwait(false);
    }

    public async Task<Product?> FindByCodeAsync(string codeOrBarcode, CancellationToken ct = default)
    {
        var code = codeOrBarcode?.Trim() ?? "";
        if (code.Length == 0 || code.Length > 50)
        {
            return null;
        }

        // Batch barcodes live on Temp_Stock, so a scan may match there rather than on the product.
        const string sql = Select + @"
WHERE p.ProductCode = @code OR p.Barcode = @code
   OR EXISTS (SELECT 1 FROM Temp_Stock b WHERE b.ProductID = p.PID AND b.Barcode = @code)
ORDER BY CASE WHEN p.Barcode = @code THEN 0 WHEN p.ProductCode = @code THEN 1 ELSE 2 END, p.PID";

        var rows = await _db.QueryAsync(sql, ps =>
        {
            ps.Add("@limit", SqlDbType.Int).Value = 1;
            ps.Add("@code", SqlDbType.NVarChar, 50).Value = code;
        }, Map, ct).ConfigureAwait(false);
        return rows.FirstOrDefault();
    }

    public const int MaxBatchProducts = 500;

    public async Task<IReadOnlyList<StockBatch>> GetBatchesAsync(IReadOnlyCollection<int> productIds, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(productIds);
        var ids = productIds.Distinct().Take(MaxBatchProducts).ToList();
        if (ids.Count == 0)
        {
            return Array.Empty<StockBatch>();
        }

        // One parameter per product, so it runs on every SQL Server edition a shop may have (no STRING_SPLIT or
        // table types). Only the parameter names are written into the query.
        var sql = $@"
SELECT p.PID,
       RTRIM(p.ProductName),
       COALESCE(NULLIF(RTRIM(t.Barcode), N''), NULLIF(RTRIM(p.Barcode), N''), RTRIM(p.ProductCode)),
       COALESCE(NULLIF(t.MRP, 0), p.MRP, 0),
       COALESCE(NULLIF(t.SPrice, 0), p.SellingPrice, 0),
       ISNULL(t.Qty, 0),
       NULLIF(RTRIM(t.Batch), N'')
FROM Product p
LEFT JOIN Temp_Stock t ON t.ProductID = p.PID
WHERE p.PID IN ({string.Join(", ", ids.Select((_, i) => "@p" + i.ToString(System.Globalization.CultureInfo.InvariantCulture)))})
ORDER BY p.PID, CASE WHEN t.Qty > 0 THEN 0 ELSE 1 END, t.Id";

        var rows = await _db.QueryAsync(sql, ps =>
        {
            for (var i = 0; i < ids.Count; i++)
            {
                ps.Add("@p" + i.ToString(System.Globalization.CultureInfo.InvariantCulture), SqlDbType.Int).Value = ids[i];
            }
        }, r => new StockBatch
        {
            ProductId = r.GetInt32(0),
            Name = SqlDb.Text(r, 1) ?? "",
            Code = SqlDb.Text(r, 2) ?? "",
            Mrp = SqlDb.Number(r, 3),
            Price = SqlDb.Number(r, 4),
            Qty = SqlDb.Number(r, 5),
            Batch = SqlDb.Text(r, 6),
        }, ct).ConfigureAwait(false);

        // Two batches with the same code are one sticker: their stock is added up.
        return rows
            .Where(b => b.Code.Length > 0)
            .GroupBy(b => (b.ProductId, b.Code))
            .Select(g => g.First() with { Qty = g.Sum(b => b.Qty) })
            .ToList();
    }

    private static Product Map(SqlDataReader r) => new()
    {
        Id = r.GetInt32(0),
        Code = SqlDb.Text(r, 1) ?? "",
        Name = SqlDb.Text(r, 2) ?? "",
        Barcode = SqlDb.Text(r, 3),
        HsnCode = SqlDb.Text(r, 4),
        Category = SqlDb.Text(r, 5),
        SellingPrice = SqlDb.Number(r, 6),
        Mrp = SqlDb.Number(r, 7),
        GstRatePercent = SqlDb.Number(r, 8),
        MinStock = SqlDb.Number(r, 9),
        StockInHand = SqlDb.Number(r, 10),
    };
}

using System.Data;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Data.SqlServer;

/// <summary>Stock levels: the sum of each product's Temp_Stock rows against Product.MinStock.</summary>
public sealed class SqlServerStockRepository : IStockRepository
{
    private readonly SqlDb _db;

    public SqlServerStockRepository(SqlDb db) => _db = db;

    public async Task<IReadOnlyList<StockLevel>> GetLowStockAsync(int limit, CancellationToken ct = default)
    {
        const string sql = @"
SELECT TOP (@limit) p.PID, RTRIM(p.ProductCode), RTRIM(p.ProductName), ISNULL(st.InHand, 0), p.MinStock
FROM Product p
OUTER APPLY (SELECT SUM(ts.Qty) AS InHand FROM Temp_Stock ts WHERE ts.ProductID = p.PID) st
WHERE p.MinStock > 0 AND ISNULL(st.InHand, 0) < p.MinStock
ORDER BY p.MinStock - ISNULL(st.InHand, 0) DESC, p.ProductName";

        return await _db.QueryAsync(sql, ps => ps.Add("@limit", SqlDbType.Int).Value = limit, r => new StockLevel
        {
            ProductId = r.GetInt32(0),
            Code = SqlDb.Text(r, 1) ?? "",
            Name = SqlDb.Text(r, 2) ?? "",
            InHand = SqlDb.Number(r, 3),
            MinStock = SqlDb.Number(r, 4),
        }, ct).ConfigureAwait(false);
    }
}

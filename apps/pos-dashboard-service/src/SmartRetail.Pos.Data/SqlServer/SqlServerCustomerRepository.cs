using System.Data;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Data.SqlServer;

/// <summary>Customers from the POS <c>Customer</c> table.</summary>
public sealed class SqlServerCustomerRepository : ICustomerRepository
{
    private readonly SqlDb _db;

    public SqlServerCustomerRepository(SqlDb db) => _db = db;

    public async Task<IReadOnlyList<Customer>> SearchAsync(string? term, int limit, CancellationToken ct = default)
    {
        const string sql = @"
SELECT TOP (@limit) c.ID, RTRIM(c.Name), RTRIM(c.ContactNo)
FROM Customer c
WHERE @pattern IS NULL OR c.Name LIKE @pattern OR c.ContactNo LIKE @pattern
ORDER BY c.Name, c.ID";

        return await _db.QueryAsync(sql, ps =>
        {
            ps.Add("@limit", SqlDbType.Int).Value = limit;
            ps.Add("@pattern", SqlDbType.NVarChar, 210).Value = (object?)SqlDb.ContainsPattern(term) ?? DBNull.Value;
        }, r => new Customer
        {
            Id = r.GetInt32(0),
            Name = SqlDb.Text(r, 1) ?? "",
            Phone = SqlDb.Text(r, 2),
        }, ct).ConfigureAwait(false);
    }
}

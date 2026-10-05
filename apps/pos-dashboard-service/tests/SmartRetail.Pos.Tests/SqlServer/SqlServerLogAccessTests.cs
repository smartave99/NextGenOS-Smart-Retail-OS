using Microsoft.Data.SqlClient;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Data.SqlServer;

namespace SmartRetail.Pos.Tests.SqlServer;

/// <summary>The times of bills come from the POS log (<c>Logs</c>), which a read-only login made by the login script of
/// 1.6 and before may not read: bills must still list, only without their times.</summary>
public sealed class SqlServerLogAccessTests : IClassFixture<PosTestDatabase>
{
    private static readonly DateRange Days = new(new DateOnly(2026, 9, 24), new DateOnly(2026, 9, 25));

    private readonly PosTestDatabase _database;

    public SqlServerLogAccessTests(PosTestDatabase database) => _database = database;

    [SqlServerFact]
    public async Task The_owners_login_may_read_the_pos_log() =>
        Assert.True(await new SqlDb(_database.ConnectionString, 15).CanReadLogAsync(default));

    [SqlServerFact]
    public async Task A_login_that_may_not_read_the_pos_log_lists_bills_without_times()
    {
        var login = "pos_test_nolog_" + Guid.NewGuid().ToString("N")[..8];
        var password = "Aa1!" + Guid.NewGuid().ToString("N");
        await _database.ExecuteAsync($@"
CREATE LOGIN [{login}] WITH PASSWORD = N'{password}', CHECK_POLICY = OFF;
CREATE USER [{login}] FOR LOGIN [{login}];
ALTER ROLE db_datareader ADD MEMBER [{login}];
DENY SELECT ON dbo.Logs TO [{login}];");
        try
        {
            var connection = new SqlConnectionStringBuilder(_database.ConnectionString) { UserID = login, Password = password, IntegratedSecurity = false };
            var db = new SqlDb(connection.ConnectionString, 15);
            var invoices = new SqlServerInvoiceRepository(db);
            var facts = new SqlServerSalesFactsRepository(db);

            Assert.False(await db.CanReadLogAsync(default));

            var recent = await invoices.GetRecentAsync(10);
            Assert.Equal(new long[] { 4, 3, 2, 1 }, recent.Select(b => b.Id));
            Assert.All(recent, b => Assert.Null(b.SavedAt));
            Assert.All((await invoices.SearchAsync(new BillQuery())).Items, b => Assert.Null(b.SavedAt));
            Assert.Null((await invoices.GetAsync(2))!.Summary.SavedAt);

            var sales = await facts.GetFactsAsync(Days);
            Assert.False(sales.TimesReadable);
            Assert.Empty(sales.Hours);
            Assert.Equal(3, sales.Days.Sum(d => d.Bills));

            var times = await facts.GetBillTimesAsync(Days);
            Assert.Equal(new[] { 1000m, 56m, 99m }, times.Select(t => t.Total));
            Assert.All(times, t => Assert.Null(t.SavedAt));
        }
        finally
        {
            SqlConnection.ClearAllPools();
            await _database.ExecuteAsync($"DROP USER [{login}]; DROP LOGIN [{login}];");
        }
    }
}

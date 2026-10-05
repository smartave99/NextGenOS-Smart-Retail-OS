using SmartRetail.AI.Assistant;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests.SqlServer;

/// <summary>Ask AI's query runner on the real POS table definitions: it keeps nothing a query does, and stops at
/// the row limit. The built-in reports the chat offers run on the POS tables.</summary>
public sealed class ChatQueryTests : IClassFixture<PosTestDatabase>
{
    private readonly PosTestDatabase _database;

    public ChatQueryTests(PosTestDatabase database) => _database = database;

    private SqlClientQueryExecutor Executor => new(_database.ConnectionString, 30);

    [SqlServerFact]
    public async Task Nothing_a_query_does_is_kept()
    {
        var inside = await Executor.QueryAsync(
            "INSERT INTO Category (CategoryName) VALUES (N'Temporary'); SELECT COUNT(*) AS Categories FROM Category", null!, 10, default);
        var after = await Executor.QueryAsync("SELECT COUNT(*) FROM Category", null!, 10, default);

        Assert.Equal(3, Convert.ToInt32(inside.Rows[0][0]));
        Assert.Equal(2, Convert.ToInt32(after.Rows[0][0]));
    }

    [SqlServerFact]
    public async Task Rows_stop_at_the_limit()
    {
        var some = await Executor.QueryAsync("SELECT PID, RTRIM(ProductName) AS Name FROM Product ORDER BY PID", null!, 2, default);
        var all = await Executor.QueryAsync("SELECT PID, ProductName AS Name FROM Product ORDER BY PID", null!, 10, default);

        Assert.Equal(new[] { "PID", "Name" }, some.Columns);
        Assert.Equal(2, some.Rows.Count);
        Assert.True(some.Truncated);
        Assert.Equal(4, all.Rows.Count);
        Assert.False(all.Truncated);
        Assert.Equal("Basmati Rice 5 kg", all.Rows[0][1]);
    }

    [SqlServerFact]
    public async Task A_query_the_database_rejects_is_reported_as_such()
    {
        var problem = await Assert.ThrowsAsync<SmartRetail.AI.Data.QueryExecutionException>(
            () => Executor.QueryAsync("SELECT NoSuchColumn FROM Product", null!, 10, default));

        Assert.False(problem.IsConnectionProblem);
    }

    [SqlServerFact]
    public async Task The_built_in_reports_run_on_the_pos_tables()
    {
        var settings = new AssistantSettings();
        var backend = new BusinessChatBackend(() => new ProviderRouter(Array.Empty<IAiProvider>(), () => settings), Executor, () => settings);

        // The expenses report reads Voucher, which is not among the tables the dashboard's tests create.
        foreach (var starter in backend.Starters.Where(s => !s.Report!.Sql.Contains("Voucher", StringComparison.Ordinal)))
        {
            var reply = await backend.RunAsync(starter, null, default);

            Assert.False(reply.IsProblem, starter.Title + ": " + reply.Text);
            Assert.NotNull(reply.Table);
            Assert.StartsWith("Report · ", reply.Source);
        }
    }
}

using System.Data;
using Microsoft.Data.SqlClient;

namespace SmartRetail.Pos.Data.SqlServer;

/// <summary>Runs parameterised, read-only queries against the POS database.</summary>
public sealed class SqlDb
{
    // Never wait on a lock the POS is holding for long; a slow screen beats a stuck till.
    private const string SessionSettings = "SET LOCK_TIMEOUT 5000;\n";

    // How long whether the POS log can be read is remembered, so a login given access later is noticed.
    private static readonly TimeSpan LogAccessKeptFor = TimeSpan.FromMinutes(10);

    private readonly string _connectionString;
    private readonly int _commandTimeoutSeconds;
    private volatile LogAccess? _logAccess;

    public SqlDb(string connectionString, int commandTimeoutSeconds)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("A connection string is required.", nameof(connectionString));
        }

        _connectionString = connectionString;
        _commandTimeoutSeconds = commandTimeoutSeconds;
    }

    /// <summary>"POS on SERVER" for display; never includes credentials.</summary>
    public string Describe()
    {
        var builder = new SqlConnectionStringBuilder(_connectionString);
        var database = string.IsNullOrEmpty(builder.InitialCatalog) ? "POS database" : builder.InitialCatalog;
        return $"{database} on {builder.DataSource}";
    }

    public async Task<List<T>> QueryAsync<T>(
        string sql,
        Action<SqlParameterCollection> bind,
        Func<SqlDataReader, T> map,
        CancellationToken ct)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(ct).ConfigureAwait(false);

        // Reads take no locks, so the POS is never held up while it bills, and the transaction is never
        // committed: disposing it rolls back, so nothing sent from here can change the POS database.
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.ReadUncommitted, ct).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = SessionSettings + sql;
        command.CommandTimeout = _commandTimeoutSeconds;
        bind(command.Parameters);

        var rows = new List<T>();
        await using var reader = await command.ExecuteReaderAsync(ct).ConfigureAwait(false);
        while (await reader.ReadAsync(ct).ConfigureAwait(false))
        {
            rows.Add(map(reader));
        }
        return rows;
    }

    /// <summary>Whether this login may read the POS log (<c>Logs</c>), where the times of bills are. The read-only
    /// login made by the login script of version 1.6 and before may not.</summary>
    public async Task<bool> CanReadLogAsync(CancellationToken ct)
    {
        if (_logAccess is { } known && DateTime.UtcNow - known.CheckedAt < LogAccessKeptFor)
        {
            return known.Readable;
        }

        const string sql = @"
SELECT CASE WHEN OBJECT_ID(N'dbo.Logs', N'U') IS NOT NULL AND HAS_PERMS_BY_NAME(N'dbo.Logs', N'OBJECT', N'SELECT') = 1 THEN 1 ELSE 0 END";
        var readable = (await QueryAsync(sql, _ => { }, r => r.GetInt32(0) == 1, ct).ConfigureAwait(false))[0];
        _logAccess = new LogAccess(readable, DateTime.UtcNow);
        return readable;
    }

    private sealed record LogAccess(bool Readable, DateTime CheckedAt);

    internal static string? Text(SqlDataReader reader, int ordinal) =>
        reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);

    internal static decimal Number(SqlDataReader reader, int ordinal) =>
        reader.IsDBNull(ordinal) ? 0m : reader.GetDecimal(ordinal);

    /// <summary>A LIKE pattern that matches <paramref name="term"/> anywhere, with its wildcards escaped.</summary>
    internal static string? ContainsPattern(string? term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return null;
        }

        var escaped = term.Trim().Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
        return "%" + escaped + "%";
    }
}

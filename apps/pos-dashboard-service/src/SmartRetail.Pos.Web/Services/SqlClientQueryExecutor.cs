using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using SmartRetail.AI.Data;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Runs read-only queries on the POS database with Microsoft.Data.SqlClient: the database finder's, and the chat's
/// (which <see cref="SqlGuard"/> has approved). As in the side panel, every query runs in a transaction that is
/// rolled back, so even a statement that got past the guard could not change anything.
/// </summary>
public sealed class SqlClientQueryExecutor : IQueryExecutor
{
    private readonly string _connectionString;
    private readonly int _commandTimeoutSeconds;

    public SqlClientQueryExecutor(string connectionString, int commandTimeoutSeconds = 15)
    {
        _connectionString = connectionString;
        _commandTimeoutSeconds = Math.Max(5, commandTimeoutSeconds);
    }

    public async Task<QueryResult> QueryAsync(string sql, IReadOnlyDictionary<string, object> parameters, int maxRows, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        await using var connection = new SqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync(cancellationToken);
        }
        catch (Exception ex) when (ex is SqlException or InvalidOperationException or ArgumentException or PlatformNotSupportedException)
        {
            throw new QueryExecutionException(ex.Message, isConnectionProblem: true, innerException: ex);
        }

        // No locks taken, so billing in the POS is never held up by a report.
        SqlTransaction? transaction = null;
        try
        {
            transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken);
            await using (var setup = connection.CreateCommand())
            {
                // Give up quickly instead of waiting on a busy table.
                setup.Transaction = transaction;
                setup.CommandText = "SET LOCK_TIMEOUT 5000; SET NOCOUNT ON;";
                await setup.ExecuteNonQueryAsync(cancellationToken);
            }

            await using var command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = sql;
            command.CommandTimeout = _commandTimeoutSeconds;
            foreach (var parameter in parameters ?? new Dictionary<string, object>())
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
            }

            var rows = new List<object[]>();
            var truncated = false;
            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleResult, cancellationToken);
            var columns = Enumerable.Range(0, reader.FieldCount)
                .Select(i => string.IsNullOrWhiteSpace(reader.GetName(i)) ? "Column" + (i + 1) : reader.GetName(i))
                .ToList();
            while (await reader.ReadAsync(cancellationToken))
            {
                if (rows.Count >= maxRows)
                {
                    truncated = true;
                    break;
                }

                var values = new object[reader.FieldCount];
                reader.GetValues(values);
                rows.Add(values.Select(Clean).ToArray());
            }

            if (truncated)
            {
                // Stop the server sending the rest instead of reading it all to close the reader.
                command.Cancel();
            }

            return new QueryResult(columns, rows, truncated, stopwatch.Elapsed);
        }
        catch (SqlException ex)
        {
            throw new QueryExecutionException(ex.Message, isConnectionProblem: false, innerException: ex);
        }
        finally
        {
            if (transaction is not null)
            {
                try
                {
                    await transaction.RollbackAsync(CancellationToken.None);
                }
                catch (Exception ex) when (ex is SqlException or InvalidOperationException)
                {
                    // Already ended, e.g. the server cancelled the batch; closing the connection ends it anyway.
                }

                await transaction.DisposeAsync();
            }
        }
    }

    private static object Clean(object value) => value switch
    {
        DBNull => null!,
        string text => text.TrimEnd(),
        byte[] => "(binary data)",
        _ => value,
    };
}

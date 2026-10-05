using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Data;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>Runs read-only queries against the POS's SQL Server database.</summary>
    internal sealed class SqlServerQueryExecutor : IQueryExecutor
    {
        private readonly Func<string> _connectionString;
        private readonly Func<int> _commandTimeoutSeconds;

        public SqlServerQueryExecutor(Func<string> connectionString, Func<int> commandTimeoutSeconds)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _commandTimeoutSeconds = commandTimeoutSeconds ?? throw new ArgumentNullException(nameof(commandTimeoutSeconds));
        }

        public static string BuildConnectionString(DatabaseSettings database, string password, string databaseOverride = null)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = database.Server ?? "",
                InitialCatalog = databaseOverride ?? database.Database ?? "",
                IntegratedSecurity = database.UseWindowsAuthentication,
                ApplicationName = Branding.AssistantName,
                ConnectTimeout = 10,
            };

            if (!database.UseWindowsAuthentication)
            {
                builder.UserID = database.UserName ?? "";
                builder.Password = password ?? "";
            }

            return builder.ConnectionString;
        }

        /// <summary>For searching: gives up on a server that does not answer after a few seconds.</summary>
        public static string BuildConnectionString(SqlTarget target, int connectTimeoutSeconds)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = target.Server,
                InitialCatalog = target.Database,
                IntegratedSecurity = target.Login.UseWindowsAuthentication,
                ApplicationName = Branding.AssistantName,
                ConnectTimeout = connectTimeoutSeconds,
            };

            if (!target.Login.UseWindowsAuthentication)
            {
                builder.UserID = target.Login.UserName;
                builder.Password = target.Login.Password;
            }

            return builder.ConnectionString;
        }

        public async Task<QueryResult> QueryAsync(string sql, IReadOnlyDictionary<string, object> parameters, int maxRows, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            using (var connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = _connectionString();
                    await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex) when (ex is SqlException || ex is InvalidOperationException || ex is ArgumentException)
                {
                    throw new QueryExecutionException(ex.Message, isConnectionProblem: true, innerException: ex);
                }

                // Read without holding locks so billing in the POS is never blocked by a report. The transaction
                // is never committed: even a statement that got past SqlGuard could not change anything.
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    using (var setup = connection.CreateCommand())
                    {
                        // Give up quickly instead of waiting on a busy table.
                        setup.Transaction = transaction;
                        setup.CommandText = "SET LOCK_TIMEOUT 5000; SET NOCOUNT ON;";
                        await setup.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = sql;
                        command.CommandTimeout = Math.Max(5, _commandTimeoutSeconds());
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                            }
                        }

                        return await ReadAsync(command, maxRows, stopwatch, cancellationToken).ConfigureAwait(false);
                    }
                }
                catch (SqlException ex)
                {
                    throw new QueryExecutionException(ex.Message, isConnectionProblem: false, innerException: ex);
                }
                finally
                {
                    RollBack(transaction);
                }
            }
        }

        private static void RollBack(SqlTransaction transaction)
        {
            if (transaction == null)
            {
                return;
            }

            try
            {
                transaction.Rollback();
            }
            catch (Exception ex) when (ex is SqlException || ex is InvalidOperationException)
            {
                // Already ended (e.g. the server cancelled the batch); closing the connection ends it anyway.
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private static async Task<QueryResult> ReadAsync(SqlCommand command, int maxRows, Stopwatch stopwatch, CancellationToken cancellationToken)
        {
            var columns = new List<string>();
            var rows = new List<object[]>();
            var truncated = false;
            var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
            try
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var name = reader.GetName(i);
                    columns.Add(string.IsNullOrWhiteSpace(name) ? "Column" + (i + 1) : name);
                }

                while (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                {
                    if (rows.Count >= maxRows)
                    {
                        truncated = true;
                        break;
                    }

                    var values = new object[reader.FieldCount];
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = Normalize(reader.IsDBNull(i) ? null : reader.GetValue(i));
                    }

                    rows.Add(values);
                }
            }
            finally
            {
                if (truncated)
                {
                    // Stop the server sending the remaining rows instead of draining them on dispose.
                    command.Cancel();
                }

                try
                {
                    reader.Dispose();
                }
                catch (SqlException) when (truncated)
                {
                }
            }

            return new QueryResult(columns, rows, truncated, stopwatch.Elapsed);
        }

        private static object Normalize(object value)
        {
            switch (value)
            {
                case byte[] _:
                    return "[binary data]";
                case string text:
                    // nchar columns are padded with spaces.
                    return text.TrimEnd();
                case Guid guid:
                    return guid.ToString();
                case TimeSpan time:
                    return time.ToString();
                case DateTimeOffset offset:
                    return offset.LocalDateTime;
                default:
                    return value;
            }
        }
    }
}

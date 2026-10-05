using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Data
{
    public sealed class QueryResult
    {
        public QueryResult(IReadOnlyList<string> columns, IReadOnlyList<object[]> rows, bool truncated, TimeSpan duration)
        {
            Columns = columns ?? throw new ArgumentNullException(nameof(columns));
            Rows = rows ?? throw new ArgumentNullException(nameof(rows));
            Truncated = truncated;
            Duration = duration;
        }

        public IReadOnlyList<string> Columns { get; }

        /// <summary>Cell values: null, string, number, bool or DateTime (binary data is never returned).</summary>
        public IReadOnlyList<object[]> Rows { get; }

        /// <summary>True when the query had more rows than were read.</summary>
        public bool Truncated { get; }

        public TimeSpan Duration { get; }
    }

    public interface IQueryExecutor
    {
        /// <summary>Runs one read-only statement (already approved by <see cref="SqlGuard"/>, or written by
        /// this app) and reads at most <paramref name="maxRows"/> rows.</summary>
        /// <exception cref="QueryExecutionException">The database rejected the query or could not be reached.</exception>
        Task<QueryResult> QueryAsync(string sql, IReadOnlyDictionary<string, object> parameters, int maxRows, CancellationToken cancellationToken);
    }

    public sealed class QueryExecutionException : Exception
    {
        public QueryExecutionException(string message, bool isConnectionProblem = false, Exception innerException = null)
            : base(message, innerException)
        {
            IsConnectionProblem = isConnectionProblem;
        }

        /// <summary>The database could not be reached at all, as opposed to rejecting this query.</summary>
        public bool IsConnectionProblem { get; }
    }
}

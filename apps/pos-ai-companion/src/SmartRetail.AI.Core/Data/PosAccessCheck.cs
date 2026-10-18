using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Data
{
    /// <summary>
    /// What the database account that the assistant reads with is allowed to do. The assistant never writes: its queries pass the safety check and run in a
    /// transaction that is rolled back. This is the last layer, the database's own: an account that can only read. The check asks the database itself
    /// (one fixed, harmless question) and says in plain words if the account could change the shop's data, so that the owner can switch to a read-only account.
    /// </summary>
    public sealed class PosAccessReport
    {
        /// <summary>False when the database could not be asked (not reachable, or it did not answer in the expected way).</summary>
        public bool Checked { get; set; }

        /// <summary>True when the account can change data or the database's layout (so it is not a read-only account).</summary>
        public bool CanChange { get; set; }

        /// <summary>In plain words, why <see cref="CanChange"/> is true (one line each).</summary>
        public List<string> Reasons { get; } = new List<string>();

        /// <summary>When <see cref="Checked"/> is false: why not.</summary>
        public string Problem { get; set; } = "";

        public DateTime At { get; set; }

        /// <summary>The account was asked and can only read.</summary>
        public bool IsReadOnly => Checked && !CanChange;
    }

    public static class PosAccessCheck
    {
        /// <summary>The one question asked. It reads only the account's own rights; it does not touch any table.</summary>
        public const string Sql = @"SELECT
 IS_SRVROLEMEMBER('sysadmin') AS IsSysAdmin,
 IS_MEMBER('db_owner') AS IsDbOwner,
 IS_MEMBER('db_datawriter') AS IsDataWriter,
 IS_MEMBER('db_ddladmin') AS IsDdlAdmin,
 HAS_PERMS_BY_NAME(DB_NAME(), 'DATABASE', 'INSERT') AS CanInsert,
 HAS_PERMS_BY_NAME(DB_NAME(), 'DATABASE', 'UPDATE') AS CanUpdate,
 HAS_PERMS_BY_NAME(DB_NAME(), 'DATABASE', 'DELETE') AS CanDelete,
 HAS_PERMS_BY_NAME(DB_NAME(), 'DATABASE', 'EXECUTE') AS CanExecute,
 HAS_PERMS_BY_NAME(DB_NAME(), 'DATABASE', 'ALTER') AS CanAlter";

        private static readonly (string Column, string Words)[] Findings =
        {
            ("IsSysAdmin", "the account is a server administrator (sysadmin)"),
            ("IsDbOwner", "the account owns the database (db_owner)"),
            ("IsDataWriter", "the account may write to every table (db_datawriter)"),
            ("IsDdlAdmin", "the account may change the database's layout (db_ddladmin)"),
            ("CanInsert", "the account may add rows"),
            ("CanUpdate", "the account may change rows"),
            ("CanDelete", "the account may delete rows"),
            ("CanExecute", "the account may run stored procedures, which can write"),
            ("CanAlter", "the account may alter the database"),
        };

        public static async Task<PosAccessReport> RunAsync(IQueryExecutor database, Func<DateTime> now, CancellationToken cancellationToken)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            var at = (now ?? (() => DateTime.Now))();
            try
            {
                var result = await database.QueryAsync(Sql, null, 2, cancellationToken).ConfigureAwait(false);
                var report = Read(result);
                report.At = at;
                return report;
            }
            catch (QueryExecutionException ex)
            {
                return new PosAccessReport { At = at, Problem = ex.IsConnectionProblem ? "The shop's database could not be reached: " + ex.Message : "The database did not answer the check: " + ex.Message };
            }
        }

        /// <summary>The report for the database's answer; not checked when the answer is not the one expected.</summary>
        public static PosAccessReport Read(QueryResult result)
        {
            var report = new PosAccessReport();
            if (result == null || result.Rows.Count != 1)
            {
                report.Problem = "The database did not answer the check.";
                return report;
            }

            var seen = 0;
            foreach (var (column, words) in Findings)
            {
                var index = IndexOf(result.Columns, column);
                if (index < 0)
                {
                    continue;
                }

                var value = result.Rows[0][index];
                if (value == null || value is DBNull)
                {
                    continue;
                }

                seen++;
                if (Convert.ToInt64(value, CultureInfo.InvariantCulture) == 1)
                {
                    report.Reasons.Add(words);
                }
            }

            if (seen == 0)
            {
                report.Problem = "The database did not say what the account may do.";
                return report;
            }

            report.Checked = true;
            report.CanChange = report.Reasons.Count > 0;
            return report;
        }

        private static int IndexOf(IReadOnlyList<string> columns, string name)
        {
            for (var i = 0; i < columns.Count; i++)
            {
                if (string.Equals(columns[i], name, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }
    }

    /// <summary>The last answer of <see cref="PosAccessCheck"/>, kept for ten minutes so that the question is not asked for every message.</summary>
    public sealed class PosAccessMonitor
    {
        public static readonly TimeSpan KeepFor = TimeSpan.FromMinutes(10);

        private readonly IQueryExecutor _database;
        private readonly Func<DateTime> _now;
        private readonly object _gate = new object();
        private PosAccessReport _last;

        public PosAccessMonitor(IQueryExecutor database, Func<DateTime> now = null)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _now = now ?? (() => DateTime.Now);
        }

        /// <summary>The latest answer, or null before the first check.</summary>
        public PosAccessReport Last
        {
            get
            {
                lock (_gate)
                {
                    return _last;
                }
            }
        }

        /// <summary>The latest answer if it is recent, else a new one. A failure to reach the database is not kept for long (it is asked again next time).</summary>
        public async Task<PosAccessReport> CheckAsync(CancellationToken cancellationToken, bool force = false)
        {
            lock (_gate)
            {
                if (!force && _last != null && _last.Checked && _now() - _last.At < KeepFor)
                {
                    return _last;
                }
            }

            var report = await PosAccessCheck.RunAsync(_database, _now, cancellationToken).ConfigureAwait(false);
            lock (_gate)
            {
                _last = report;
            }

            return report;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Data
{
    /// <summary>A way to sign in to SQL Server. The password is never shown or written to the steps.</summary>
    public sealed class SqlLogin
    {
        public SqlLogin(string userName, string password, string label)
        {
            UserName = (userName ?? "").Trim();
            Password = password ?? "";
            Label = label ?? "";
        }

        public static SqlLogin Windows { get; } = new SqlLogin("", "", "Windows sign-in");

        /// <summary>Empty for Windows sign-in.</summary>
        public string UserName { get; }

        public string Password { get; }

        public bool UseWindowsAuthentication => UserName.Length == 0;

        /// <summary>Where the login came from, for people, e.g. the POS's login "sa".</summary>
        public string Label { get; }
    }

    /// <summary>One database to connect to.</summary>
    public sealed class SqlTarget
    {
        public SqlTarget(string server, string database, SqlLogin login)
        {
            Server = server ?? "";
            Database = database ?? "";
            Login = login ?? SqlLogin.Windows;
        }

        public string Server { get; }

        public string Database { get; }

        public SqlLogin Login { get; }
    }

    /// <summary>A POS company database found on a SQL Server.</summary>
    public sealed class PosDatabaseCandidate
    {
        public string Server { get; set; } = "";

        public string Database { get; set; } = "";

        public SqlLogin Login { get; set; } = SqlLogin.Windows;

        /// <summary>The shop name saved in the POS, if any.</summary>
        public string CompanyName { get; set; } = "";

        public long Bills { get; set; }

        public DateTime? LastBill { get; set; }

        /// <summary>The POS is set to use this database (its TempDBSettings.dat names it).</summary>
        public bool InUseByPos { get; set; }

        /// <summary>The login could change bills. The assistant still only reads; a read-only login makes that certain.</summary>
        public bool LoginCanWrite { get; set; }

        /// <summary>The POS folder whose settings pointed here, or empty.</summary>
        public string PosFolder { get; set; } = "";

        /// <summary>The server's own name, so one server reached by two names is listed once.</summary>
        internal string ServerIdentity { get; set; } = "";

        public string Describe()
        {
            var text = Database + " on " + Server;
            if (CompanyName.Length > 0)
            {
                text = CompanyName + " (" + text + ")";
            }

            text += ": " + Bills.ToString("N0", CultureInfo.InvariantCulture) + (Bills == 1 ? " bill" : " bills");
            if (LastBill.HasValue)
            {
                text += ", the latest on " + LastBill.Value.ToString("d MMM yyyy", CultureInfo.InvariantCulture);
            }

            return text + ".";
        }
    }

    /// <summary>What a search found, best first, and what it checked, in words for the shop owner.</summary>
    public sealed class PosDatabaseSearch
    {
        public PosDatabaseSearch(IReadOnlyList<PosDatabaseCandidate> candidates, IReadOnlyList<string> steps)
        {
            Candidates = candidates;
            Steps = steps;
        }

        public IReadOnlyList<PosDatabaseCandidate> Candidates { get; }

        public IReadOnlyList<string> Steps { get; }

        public PosDatabaseCandidate Best => Candidates.Count > 0 ? Candidates[0] : null;
    }

    /// <summary>Things to try besides what the finder discovers, usually from the saved settings.</summary>
    public sealed class PosSearchHints
    {
        /// <summary>A POS folder the user picked.</summary>
        public string PosFolder { get; set; } = "";

        /// <summary>Another server to look at.</summary>
        public string Server { get; set; } = "";

        /// <summary>A login to try before any other, such as the read-only login.</summary>
        public SqlLogin Login { get; set; }
    }

    /// <summary>What the finder needs to know about this PC. <see cref="WindowsPosMachine"/> reads the real one.</summary>
    public interface IPosMachine
    {
        string MachineName { get; }

        /// <summary>Folders of the programs running now; the POS is usually open.</summary>
        IEnumerable<string> RunningProgramFolders();

        /// <summary>Folders that installers recorded in the registry.</summary>
        IEnumerable<string> InstalledProgramFolders();

        /// <summary>Folders to look through, two levels deep, when the POS is neither running nor recorded.</summary>
        IEnumerable<string> FoldersToSearch();

        /// <summary>Names of the SQL Server instances installed on this PC, e.g. MSSQLSERVER or SQLEXPRESS.</summary>
        IEnumerable<string> SqlServerInstances();
    }

    /// <summary>Finds the POS database on this PC without being told where it is: from the settings files of
    /// the POS program, then from every SQL Server installed here. It only runs the read-only queries below.</summary>
    public sealed class PosDatabaseFinder
    {
        /// <summary>Stops a server with very many databases from making the search slow.</summary>
        public const int MaxDatabasesPerServer = 60;

        /// <summary>Stops a search of a whole drive from taking long.</summary>
        public const int MaxFoldersSearched = 20000;

        internal const string ListDatabasesSql =
            "SELECT name, CAST(SERVERPROPERTY('ServerName') AS nvarchar(256)) AS ServerName FROM sys.databases "
            + "WHERE database_id > 4 AND state = 0 AND HAS_DBACCESS(name) = 1 ORDER BY name";

        internal const string ProbeSql =
            "SELECT CASE WHEN OBJECT_ID(N'dbo.InvoiceInfo', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.Invoice_Product', N'U') IS NOT NULL "
            + "AND OBJECT_ID(N'dbo.Product', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.Temp_Stock', N'U') IS NOT NULL THEN 1 ELSE 0 END AS IsPos, "
            + "CASE WHEN OBJECT_ID(N'dbo.Company', N'U') IS NULL THEN 0 ELSE 1 END AS HasCompany";

        internal const string BillsSql =
            "SELECT COUNT_BIG(*) AS Bills, MAX(InvoiceDate) AS LastBill, "
            + "HAS_PERMS_BY_NAME(N'dbo.InvoiceInfo', N'OBJECT', N'INSERT') + HAS_PERMS_BY_NAME(N'dbo.InvoiceInfo', N'OBJECT', N'UPDATE') "
            + "+ HAS_PERMS_BY_NAME(N'dbo.InvoiceInfo', N'OBJECT', N'DELETE') AS WriteRights FROM dbo.InvoiceInfo";

        internal const string CompanySql = "SELECT TOP (1) RTRIM(CompanyName) AS CompanyName FROM dbo.Company ORDER BY ID";

        private static readonly string[] SkippedFolderNames = { "Windows", "System Volume Information", "Recovery", "PerfLogs" };

        private readonly IPosMachine _machine;
        private readonly Func<SqlTarget, IQueryExecutor> _connect;

        public PosDatabaseFinder(IPosMachine machine, Func<SqlTarget, IQueryExecutor> connect)
        {
            _machine = machine ?? throw new ArgumentNullException(nameof(machine));
            _connect = connect ?? throw new ArgumentNullException(nameof(connect));
        }

        public async Task<PosDatabaseSearch> FindAsync(PosSearchHints hints, CancellationToken cancellationToken)
        {
            hints = hints ?? new PosSearchHints();
            var steps = new List<string>();
            var installs = FindPosInstalls(hints.PosFolder, steps);
            var plans = PlanServers(installs, hints, steps);

            var results = await Task.WhenAll(plans.Select(plan => SearchServerAsync(plan, cancellationToken))).ConfigureAwait(false);

            var candidates = new List<PosDatabaseCandidate>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var result in results)
            {
                steps.Add(result.Step);
                candidates.AddRange(result.Candidates.Where(candidate => seen.Add(candidate.ServerIdentity + "|" + candidate.Database)));
            }

            var ordered = candidates
                .OrderByDescending(candidate => candidate.InUseByPos)
                .ThenByDescending(candidate => candidate.LastBill ?? DateTime.MinValue)
                .ThenByDescending(candidate => candidate.Bills)
                .ThenBy(candidate => candidate.Database, StringComparer.OrdinalIgnoreCase)
                .ToList();
            return new PosDatabaseSearch(ordered, steps);
        }

        private List<PosInstall> FindPosInstalls(string pickedFolder, List<string> steps)
        {
            var folders = new List<(string Folder, string How)>();
            Add(folders, new[] { pickedFolder }, "the folder you chose");
            Add(folders, Safely(_machine.RunningProgramFolders), "it is open now");
            Add(folders, Safely(_machine.InstalledProgramFolders), "installed");

            var found = folders.Where(folder => HasPosFiles(folder.Folder)).ToList();
            if (found.Count == 0)
            {
                Add(found, SearchForPosFolders(Safely(_machine.FoldersToSearch)), "found on disk");
            }

            var installs = new List<PosInstall>();
            foreach (var (folder, how) in found)
            {
                var info = SafeDetect(folder);
                if (info != null)
                {
                    installs.Add(new PosInstall(folder, info));
                    steps.Add("Found the POS program in " + folder + " (" + how + ").");
                }
            }

            if (installs.Count == 0)
            {
                steps.Add("The POS program's settings were not found (it is not open, not in the installed programs, "
                    + "and not in Program Files or the top folders of the drives).");
            }

            return installs;
        }

        private List<ServerPlan> PlanServers(List<PosInstall> installs, PosSearchHints hints, List<string> steps)
        {
            var plans = new List<ServerPlan>();
            ServerPlan PlanFor(string server)
            {
                var key = SqlServerName.Key(server, _machine.MachineName);
                var plan = plans.FirstOrDefault(existing => existing.Key == key);
                if (plan == null)
                {
                    plan = new ServerPlan(server.Trim(), key);
                    plans.Add(plan);
                }

                return plan;
            }

            var databasesWithoutServer = new List<string>();
            foreach (var install in installs)
            {
                if (install.Info.Server.Length == 0)
                {
                    if (install.Info.Database.Length > 0)
                    {
                        databasesWithoutServer.Add(install.Info.Database);
                    }

                    continue;
                }

                var plan = PlanFor(install.Info.Server);
                if (plan.PosFolder.Length == 0)
                {
                    plan.PosFolder = install.Folder;
                }

                if (install.Info.Database.Length > 0)
                {
                    plan.PosDatabases.Add(install.Info.Database);
                }

                plan.PosLogins.Add(install.Info.UseWindowsAuthentication
                    ? SqlLogin.Windows
                    : new SqlLogin(install.Info.UserName, install.Info.Password, "the POS's login \"" + install.Info.UserName + "\""));
            }

            if (!string.IsNullOrWhiteSpace(hints.Server))
            {
                PlanFor(hints.Server);
            }

            var instances = Safely(_machine.SqlServerInstances)
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            foreach (var instance in instances)
            {
                PlanFor(SqlServerName.ForInstance(instance));
            }

            steps.Add(instances.Count > 0
                ? "SQL Server on this PC: " + string.Join(", ", instances) + "."
                : "No SQL Server is installed on this PC" + (plans.Count > 0 ? "; looking at the server the POS uses." : "."));

            foreach (var plan in plans)
            {
                plan.PosDatabases.AddRange(databasesWithoutServer);
                var logins = new List<SqlLogin>();
                if (hints.Login != null)
                {
                    logins.Add(hints.Login);
                }

                logins.Add(SqlLogin.Windows);
                logins.AddRange(plan.PosLogins);
                plan.Logins.AddRange(logins
                    .GroupBy(login => login.UserName.ToLowerInvariant() + "\n" + login.Password, StringComparer.Ordinal)
                    .Select(group => group.First()));
            }

            return plans;
        }

        private async Task<ServerResult> SearchServerAsync(ServerPlan plan, CancellationToken cancellationToken)
        {
            string lastError = null;
            var signedIn = false;
            foreach (var login in plan.Logins)
            {
                QueryResult databases;
                try
                {
                    databases = await _connect(new SqlTarget(plan.Server, "master", login))
                        .QueryAsync(ListDatabasesSql, null, MaxDatabasesPerServer, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex) when (!(ex is OperationCanceledException))
                {
                    lastError = ex.Message;
                    continue;
                }

                signedIn = true;
                var found = new List<PosDatabaseCandidate>();
                foreach (var row in databases.Rows)
                {
                    var candidate = await ProbeAsync(plan, login, Text(row[0]), Text(row[1]), cancellationToken).ConfigureAwait(false);
                    if (candidate != null)
                    {
                        found.Add(candidate);
                    }
                }

                if (found.Count > 0)
                {
                    var names = string.Join(", ", found.Select(candidate => candidate.Database));
                    return new ServerResult(plan.Server + ": found " + names + " using " + login.Label + ".", found);
                }
            }

            if (signedIn)
            {
                return new ServerResult(plan.Server + ": no POS database found.", new List<PosDatabaseCandidate>());
            }

            return new ServerResult(
                plan.Server + ": could not sign in (tried " + string.Join(", ", plan.Logins.Select(login => login.Label)) + "). "
                + FirstLine(lastError),
                new List<PosDatabaseCandidate>());
        }

        private async Task<PosDatabaseCandidate> ProbeAsync(ServerPlan plan, SqlLogin login, string database, string serverIdentity, CancellationToken cancellationToken)
        {
            if (database.Length == 0)
            {
                return null;
            }

            try
            {
                var executor = _connect(new SqlTarget(plan.Server, database, login));
                var probe = await executor.QueryAsync(ProbeSql, null, 1, cancellationToken).ConfigureAwait(false);
                if (probe.Rows.Count == 0 || ToLong(probe.Rows[0][0]) != 1)
                {
                    return null;
                }

                var bills = await executor.QueryAsync(BillsSql, null, 1, cancellationToken).ConfigureAwait(false);
                var row = bills.Rows.Count > 0 ? bills.Rows[0] : new object[3];
                var candidate = new PosDatabaseCandidate
                {
                    Server = plan.Server,
                    ServerIdentity = serverIdentity.Length > 0 ? serverIdentity : plan.Key,
                    Database = database,
                    Login = login,
                    Bills = ToLong(row[0]) ?? 0,
                    LastBill = row[1] as DateTime?,
                    // Unknown rights count as "could write", so the advice to use a read-only login still shows.
                    LoginCanWrite = (ToLong(row[2]) ?? 1) != 0,
                    InUseByPos = plan.PosDatabases.Contains(database, StringComparer.OrdinalIgnoreCase),
                    PosFolder = plan.PosFolder,
                };

                if (ToLong(probe.Rows[0][1]) == 1)
                {
                    try
                    {
                        var company = await executor.QueryAsync(CompanySql, null, 1, cancellationToken).ConfigureAwait(false);
                        candidate.CompanyName = company.Rows.Count > 0 ? Text(company.Rows[0][0]) : "";
                    }
                    catch (QueryExecutionException)
                    {
                        // The shop name is only a nicety.
                    }
                }

                return candidate;
            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                // Offline, being restored, or this login may not read it: not the POS database we can use.
                return null;
            }
        }

        private static IEnumerable<string> SearchForPosFolders(IEnumerable<string> roots)
        {
            var budget = MaxFoldersSearched;
            foreach (var root in roots)
            {
                foreach (var first in Subfolders(root))
                {
                    if (--budget < 0)
                    {
                        yield break;
                    }

                    if (HasPosFiles(first))
                    {
                        yield return first;
                    }

                    foreach (var second in Subfolders(first))
                    {
                        if (--budget < 0)
                        {
                            yield break;
                        }

                        if (HasPosFiles(second))
                        {
                            yield return second;
                        }
                    }
                }
            }
        }

        private static IEnumerable<string> Subfolders(string folder)
        {
            try
            {
                return Directory.GetDirectories(folder)
                    .Where(path =>
                    {
                        var name = Path.GetFileName(path);
                        return !name.StartsWith("$", StringComparison.Ordinal)
                            && !SkippedFolderNames.Contains(name, StringComparer.OrdinalIgnoreCase);
                    })
                    .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException || ex is NotSupportedException)
            {
                return Array.Empty<string>();
            }
        }

        private static bool HasPosFiles(string folder)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(folder)
                    && (File.Exists(Path.Combine(folder, PosConnectionDetector.SqlSettingsFile))
                        || File.Exists(Path.Combine(folder, PosConnectionDetector.DatabaseFile)));
            }
            catch (Exception ex) when (ex is ArgumentException || ex is NotSupportedException)
            {
                return false;
            }
        }

        private static PosConnectionInfo SafeDetect(string folder)
        {
            try
            {
                return PosConnectionDetector.Detect(folder);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return null;
            }
        }

        private static void Add(List<(string Folder, string How)> folders, IEnumerable<string> paths, string how)
        {
            foreach (var path in paths)
            {
                var folder = TidyFolder(path);
                if (folder.Length > 0 && !folders.Any(existing => string.Equals(existing.Folder, folder, StringComparison.OrdinalIgnoreCase)))
                {
                    folders.Add((folder, how));
                }
            }
        }

        /// <summary>Reading the PC can fail in many small ways; a failed source just adds nothing.</summary>
        private static List<string> Safely(Func<IEnumerable<string>> read)
        {
            try
            {
                return (read() ?? Enumerable.Empty<string>()).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        /// <summary>Drops a trailing slash, except from a drive root: "C:" alone means the current folder on C.</summary>
        internal static string TidyFolder(string folder)
        {
            var value = (folder ?? "").Trim();
            while (value.Length > 3 && (value.EndsWith("\\", StringComparison.Ordinal) || value.EndsWith("/", StringComparison.Ordinal)))
            {
                value = value.Substring(0, value.Length - 1);
            }

            return value;
        }

        private static string Text(object value) => (Convert.ToString(value, CultureInfo.InvariantCulture) ?? "").Trim();

        private static long? ToLong(object value)
        {
            if (value == null || value is DBNull)
            {
                return null;
            }

            try
            {
                return Convert.ToInt64(value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex) when (ex is FormatException || ex is InvalidCastException || ex is OverflowException)
            {
                return null;
            }
        }

        private static string FirstLine(string text)
        {
            var line = (text ?? "").Split('\n')[0].Trim();
            return line.Length > 200 ? line.Substring(0, 200) + "…" : line;
        }

        private sealed class PosInstall
        {
            public PosInstall(string folder, PosConnectionInfo info)
            {
                Folder = folder;
                Info = info;
            }

            public string Folder { get; }

            public PosConnectionInfo Info { get; }
        }

        private sealed class ServerPlan
        {
            public ServerPlan(string server, string key)
            {
                Server = server;
                Key = key;
            }

            public string Server { get; }

            public string Key { get; }

            public string PosFolder { get; set; } = "";

            public List<string> PosDatabases { get; } = new List<string>();

            public List<SqlLogin> PosLogins { get; } = new List<SqlLogin>();

            public List<SqlLogin> Logins { get; } = new List<SqlLogin>();
        }

        private sealed class ServerResult
        {
            public ServerResult(string step, List<PosDatabaseCandidate> candidates)
            {
                Step = step;
                Candidates = candidates;
            }

            public string Step { get; }

            public List<PosDatabaseCandidate> Candidates { get; }
        }
    }
}

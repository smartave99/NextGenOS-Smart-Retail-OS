using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Data;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class SqlServerNameTests
    {
        [Theory]
        [InlineData(".")]
        [InlineData("(local)")]
        [InlineData("localhost")]
        [InlineData("127.0.0.1")]
        [InlineData("SHOP-PC")]
        [InlineData("shop-pc\\MSSQLSERVER")]
        [InlineData("tcp:SHOP-PC,1433")]
        [InlineData(" . ")]
        public void Every_name_for_the_default_instance_on_this_pc_is_one_server(string name)
        {
            Assert.Equal(SqlServerName.Key(".", "SHOP-PC"), SqlServerName.Key(name, "SHOP-PC"));
        }

        [Theory]
        [InlineData(".\\SQLEXPRESS", "SHOP-PC\\sqlexpress", true)]
        [InlineData(".\\SQLEXPRESS", ".", false)]
        [InlineData("OFFICE-PC", ".", false)]
        [InlineData("127.0.0.1,14333", ".", false)]
        [InlineData("OFFICE-PC\\SQLEXPRESS", ".\\SQLEXPRESS", false)]
        public void Instances_ports_and_other_pcs_stay_apart(string first, string second, bool same)
        {
            Assert.Equal(same, SqlServerName.Key(first, "SHOP-PC") == SqlServerName.Key(second, "SHOP-PC"));
        }

        [Theory]
        [InlineData("MSSQLSERVER", ".")]
        [InlineData("mssqlserver", ".")]
        [InlineData("SQLEXPRESS", ".\\SQLEXPRESS")]
        public void Installed_instances_become_server_names(string instance, string server)
        {
            Assert.Equal(server, SqlServerName.ForInstance(instance));
        }
    }

    public class PosDatabaseFinderTests
    {
        private static readonly DateTime September15 = new DateTime(2026, 9, 15);

        [Fact]
        public async Task Finds_the_database_the_open_pos_uses_with_its_own_login()
        {
            using (var pos = new TempFolder())
            {
                pos.File(PosConnectionDetector.SqlSettingsFile, "SHOP-PC\nsa\n12345\n");
                pos.File(PosConnectionDetector.DatabaseFile, "Raintech_DB1");
                var machine = new FakeMachine { Running = { @"C:\Windows\System32", pos.Path }, Instances = { "MSSQLSERVER" } };
                var sql = new FakeSqlServers();
                var server = sql.Add(".", "SHOP-PC", logins: "sa");
                server.Databases["Raintech_DB1"] = new FakeDatabase { Bills = 2998, LastBill = September15, Company = "Demo Mart", CanWrite = true };
                server.Databases["Raintech_DB2"] = new FakeDatabase { Bills = 9000, LastBill = September15.AddDays(3) };
                server.Databases["RaintechMaster_DB"] = new FakeDatabase { IsPos = false };
                server.Databases["ShopAccounts"] = new FakeDatabase { IsPos = false };

                var search = await new PosDatabaseFinder(machine, sql.Connect).FindAsync(null, CancellationToken.None);

                var best = search.Best;
                Assert.Equal("Raintech_DB1", best.Database);
                Assert.Equal("SHOP-PC", best.Server);
                Assert.True(best.InUseByPos);
                Assert.Equal("sa", best.Login.UserName);
                Assert.Equal("12345", best.Login.Password);
                Assert.Equal("Demo Mart", best.CompanyName);
                Assert.Equal(2998, best.Bills);
                Assert.Equal(September15, best.LastBill);
                Assert.True(best.LoginCanWrite);
                Assert.Equal(pos.Path, best.PosFolder);
                Assert.Equal(new[] { "Raintech_DB1", "Raintech_DB2" }, search.Candidates.Select(candidate => candidate.Database));
                Assert.Equal("Demo Mart (Raintech_DB1 on SHOP-PC): 2,998 bills, the latest on 15 Sep 2026.", best.Describe());

                // The registry's MSSQLSERVER is the same server as SHOP-PC, so it was searched once:
                // Windows sign-in first (refused), then the POS's login.
                Assert.Equal(new[] { "(Windows)", "sa" }, sql.SignIns(".", "master"));
                Assert.Contains(search.Steps, step => step.Contains("Found the POS program in " + pos.Path + " (it is open now)"));
                Assert.Contains(search.Steps, step => step == "SHOP-PC: found Raintech_DB1, Raintech_DB2 using the POS's login \"sa\".");
                Assert.DoesNotContain(search.Steps, step => step.Contains("12345"));
            }
        }

        [Fact]
        public async Task Without_the_pos_program_it_looks_in_every_sql_server_and_prefers_the_latest_bills()
        {
            var machine = new FakeMachine { Instances = { "MSSQLSERVER", "SQLEXPRESS" } };
            var sql = new FakeSqlServers();
            sql.Add(".", "SHOP-PC", logins: "").Databases["OldShop"] = new FakeDatabase { Bills = 50000, LastBill = new DateTime(2024, 3, 31) };
            sql.Add(".\\SQLEXPRESS", "SHOP-PC\\SQLEXPRESS", logins: "").Databases["Raintech_DB1"] = new FakeDatabase { Bills = 10, LastBill = September15 };

            var search = await new PosDatabaseFinder(machine, sql.Connect).FindAsync(new PosSearchHints(), CancellationToken.None);

            Assert.Equal(new[] { "Raintech_DB1", "OldShop" }, search.Candidates.Select(candidate => candidate.Database));
            Assert.Equal(".\\SQLEXPRESS", search.Best.Server);
            Assert.True(search.Best.Login.UseWindowsAuthentication);
            Assert.False(search.Best.InUseByPos);
            Assert.Contains(search.Steps, step => step.StartsWith("The POS program's settings were not found", StringComparison.Ordinal));
            Assert.Contains("SQL Server on this PC: MSSQLSERVER, SQLEXPRESS.", search.Steps);
        }

        [Fact]
        public async Task A_saved_read_only_login_is_tried_first()
        {
            var machine = new FakeMachine { Instances = { "SQLEXPRESS" } };
            var sql = new FakeSqlServers();
            sql.Add(".\\SQLEXPRESS", "SHOP-PC\\SQLEXPRESS", logins: new[] { "", "smartretail_ai" })
                .Databases["Raintech_DB1"] = new FakeDatabase { Bills = 5, LastBill = September15, CanWrite = true, ReadOnlyLogins = { "smartretail_ai" } };
            var hints = new PosSearchHints { Login = new SqlLogin("smartretail_ai", "secret-pass", "the saved login \"smartretail_ai\"") };

            var best = (await new PosDatabaseFinder(machine, sql.Connect).FindAsync(hints, CancellationToken.None)).Best;

            Assert.Equal("smartretail_ai", best.Login.UserName);
            Assert.False(best.LoginCanWrite);
            Assert.Equal(new[] { "smartretail_ai" }, sql.SignIns(".\\SQLEXPRESS", "master"));
        }

        [Fact]
        public async Task A_server_it_cannot_reach_is_reported_without_the_password()
        {
            using (var pos = new TempFolder())
            {
                pos.File(PosConnectionDetector.SqlSettingsFile, "OFFICE-PC\\SQLEXPRESS\nsa\nTopSecret1\n");
                pos.File(PosConnectionDetector.DatabaseFile, "Raintech_DB1");
                var machine = new FakeMachine { Installed = { pos.Path + "\\" } };

                var search = await new PosDatabaseFinder(machine, new FakeSqlServers().Connect).FindAsync(null, CancellationToken.None);

                Assert.Null(search.Best);
                Assert.Contains(search.Steps, step => step.Contains("(installed)"));
                Assert.Contains("No SQL Server is installed on this PC; looking at the server the POS uses.", search.Steps);
                var failure = Assert.Single(search.Steps, step => step.StartsWith("OFFICE-PC\\SQLEXPRESS:", StringComparison.Ordinal));
                Assert.Contains("could not sign in (tried Windows sign-in, the POS's login \"sa\")", failure);
                Assert.Contains("server was not found", failure);
                Assert.DoesNotContain(search.Steps, step => step.Contains("TopSecret1"));
            }
        }

        [Fact]
        public async Task One_server_reached_by_two_names_lists_its_databases_once()
        {
            using (var pos = new TempFolder())
            {
                pos.File(PosConnectionDetector.SqlSettingsFile, "192.168.1.10");
                pos.File(PosConnectionDetector.DatabaseFile, "Raintech_DB1");
                var machine = new FakeMachine { Running = { pos.Path }, Instances = { "MSSQLSERVER" } };
                var sql = new FakeSqlServers();
                var shared = new FakeDatabase { Bills = 7, LastBill = September15 };
                sql.Add("192.168.1.10", "SHOP-PC", logins: "").Databases["Raintech_DB1"] = shared;
                sql.Add(".", "SHOP-PC", logins: "").Databases["Raintech_DB1"] = shared;

                var search = await new PosDatabaseFinder(machine, sql.Connect).FindAsync(null, CancellationToken.None);

                var only = Assert.Single(search.Candidates);
                Assert.Equal("192.168.1.10", only.Server);
                Assert.True(only.InUseByPos);
            }
        }

        [Fact]
        public async Task Looks_two_folders_deep_only_when_the_pos_is_not_open_or_installed()
        {
            using (var drive = new TempFolder())
            {
                var pos = Directory.CreateDirectory(Path.Combine(drive.Path, "NextGenOS", "DemoMart99 POS")).FullName;
                File.WriteAllText(Path.Combine(pos, PosConnectionDetector.DatabaseFile), "Raintech_DB1");
                var tooDeep = Directory.CreateDirectory(Path.Combine(drive.Path, "a", "b", "c")).FullName;
                File.WriteAllText(Path.Combine(tooDeep, PosConnectionDetector.DatabaseFile), "Other_DB");
                Directory.CreateDirectory(Path.Combine(drive.Path, "Windows", "POS"));
                File.WriteAllText(Path.Combine(drive.Path, "Windows", "POS", PosConnectionDetector.DatabaseFile), "Skipped_DB");
                var machine = new FakeMachine { SearchRoots = { drive.Path }, Instances = { "SQLEXPRESS" } };
                var sql = new FakeSqlServers();
                var server = sql.Add(".\\SQLEXPRESS", "SHOP-PC\\SQLEXPRESS", logins: "");
                server.Databases["Other_DB"] = new FakeDatabase { Bills = 1, LastBill = September15.AddDays(5) };
                server.Databases["Raintech_DB1"] = new FakeDatabase { Bills = 1, LastBill = September15 };

                var search = await new PosDatabaseFinder(machine, sql.Connect).FindAsync(null, CancellationToken.None);

                // A settings file with only the database name still marks the database the POS uses.
                Assert.Equal("Raintech_DB1", search.Best.Database);
                Assert.True(search.Best.InUseByPos);
                Assert.Contains("Found the POS program in " + pos + " (found on disk).", search.Steps);
                Assert.Equal(1, search.Steps.Count(step => step.StartsWith("Found the POS program", StringComparison.Ordinal)));

                machine.Running.Add(pos);
                machine.SearchRootsAsked = 0;
                await new PosDatabaseFinder(machine, sql.Connect).FindAsync(null, CancellationToken.None);
                Assert.Equal(0, machine.SearchRootsAsked);
            }
        }

        [Fact]
        public async Task A_folder_the_user_picks_is_used_even_if_the_pos_is_elsewhere()
        {
            using (var picked = new TempFolder())
            {
                picked.File(PosConnectionDetector.SqlSettingsFile, ".\\SQLEXPRESS");
                picked.File(PosConnectionDetector.DatabaseFile, "Branch_DB");
                var sql = new FakeSqlServers();
                sql.Add(".\\SQLEXPRESS", "SHOP-PC\\SQLEXPRESS", logins: "").Databases["Branch_DB"] = new FakeDatabase { Bills = 3 };

                var search = await new PosDatabaseFinder(new FakeMachine(), sql.Connect)
                    .FindAsync(new PosSearchHints { PosFolder = picked.Path }, CancellationToken.None);

                Assert.Equal("Branch_DB", search.Best.Database);
                Assert.Null(search.Best.LastBill);
                Assert.Equal("Branch_DB on .\\SQLEXPRESS: 3 bills.", search.Best.Describe());
                Assert.Contains(search.Steps, step => step.EndsWith("(the folder you chose).", StringComparison.Ordinal));
            }
        }

        [Fact]
        public async Task A_signed_in_server_without_pos_databases_says_so()
        {
            var machine = new FakeMachine { Instances = { "MSSQLSERVER" } };
            var sql = new FakeSqlServers();
            sql.Add(".", "SHOP-PC", logins: "").Databases["Payroll"] = new FakeDatabase { IsPos = false };

            var search = await new PosDatabaseFinder(machine, sql.Connect).FindAsync(null, CancellationToken.None);

            Assert.Empty(search.Candidates);
            Assert.Contains(".: no POS database found.", search.Steps);
        }

        [Fact]
        public async Task A_pc_that_cannot_be_read_just_finds_nothing()
        {
            var machine = new FakeMachine { Broken = true };

            var search = await new PosDatabaseFinder(machine, new FakeSqlServers().Connect).FindAsync(null, CancellationToken.None);

            Assert.Null(search.Best);
            Assert.Contains("No SQL Server is installed on this PC.", search.Steps);
        }

        [Fact]
        public void Reading_the_real_pc_never_fails()
        {
            // On Windows this reads the test machine; elsewhere it finds nothing. Either way, no exception.
            var machine = new WindowsPosMachine();

            Assert.NotNull(machine.RunningProgramFolders().ToList());
            Assert.NotNull(machine.InstalledProgramFolders().ToList());
            Assert.NotNull(machine.FoldersToSearch().ToList());
            Assert.NotNull(machine.SqlServerInstances().ToList());
            Assert.False(string.IsNullOrEmpty(machine.MachineName));
        }

        [Theory]
        [InlineData(@"C:\", @"C:\")]
        [InlineData(@"C:\POS Software\", @"C:\POS Software")]
        [InlineData(@" D:\Shop\POS\\ ", @"D:\Shop\POS")]
        [InlineData(null, "")]
        public void Folders_lose_trailing_slashes_but_drive_roots_keep_theirs(string folder, string expected)
        {
            Assert.Equal(expected, PosDatabaseFinder.TidyFolder(folder));
        }

        private sealed class FakeMachine : IPosMachine
        {
            public bool Broken { get; set; }

            public List<string> Running { get; } = new List<string>();

            public List<string> Installed { get; } = new List<string>();

            public List<string> SearchRoots { get; } = new List<string>();

            public List<string> Instances { get; } = new List<string>();

            public int SearchRootsAsked { get; set; }

            public string MachineName => "SHOP-PC";

            public IEnumerable<string> RunningProgramFolders() => Broken ? throw new InvalidOperationException("no access") : Running;

            public IEnumerable<string> InstalledProgramFolders() => Broken ? throw new UnauthorizedAccessException() : Installed;

            public IEnumerable<string> FoldersToSearch()
            {
                SearchRootsAsked++;
                return Broken ? throw new IOException("drive gone") : SearchRoots;
            }

            public IEnumerable<string> SqlServerInstances() => Broken ? throw new System.Security.SecurityException() : Instances;
        }

        private sealed class FakeDatabase
        {
            public bool IsPos { get; set; } = true;

            public long Bills { get; set; }

            public DateTime? LastBill { get; set; }

            public string Company { get; set; }

            public bool CanWrite { get; set; }

            public HashSet<string> ReadOnlyLogins { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        private sealed class FakeServer
        {
            public string Identity { get; set; }

            public HashSet<string> Logins { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            public Dictionary<string, FakeDatabase> Databases { get; } = new Dictionary<string, FakeDatabase>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>SQL Servers that answer the finder's queries. "" in a login list means Windows sign-in.</summary>
        private sealed class FakeSqlServers
        {
            private readonly Dictionary<string, FakeServer> _servers = new Dictionary<string, FakeServer>();
            private readonly List<(string Key, string Database, string User)> _signIns = new List<(string, string, string)>();

            public FakeServer Add(string name, string identity, params string[] logins)
            {
                var server = new FakeServer { Identity = identity };
                foreach (var login in logins)
                {
                    server.Logins.Add(login);
                }

                _servers[SqlServerName.Key(name, "SHOP-PC")] = server;
                return server;
            }

            public IEnumerable<string> SignIns(string server, string database)
            {
                var key = SqlServerName.Key(server, "SHOP-PC");
                return _signIns.Where(signIn => signIn.Key == key && signIn.Database == database)
                    .Select(signIn => signIn.User.Length == 0 ? "(Windows)" : signIn.User)
                    .ToList();
            }

            public IQueryExecutor Connect(SqlTarget target)
            {
                return new FakeQueryExecutor { Handler = sql => Answer(target, sql) };
            }

            private QueryResult Answer(SqlTarget target, string sql)
            {
                var key = SqlServerName.Key(target.Server, "SHOP-PC");
                lock (_signIns)
                {
                    _signIns.Add((key, target.Database, target.Login.UserName));
                }

                if (!_servers.TryGetValue(key, out var server))
                {
                    throw new QueryExecutionException(
                        "A network-related or instance-specific error occurred. The server was not found or was not accessible.\nMore detail.",
                        isConnectionProblem: true);
                }

                if (!server.Logins.Contains(target.Login.UserName))
                {
                    throw new QueryExecutionException("Login failed for user '" + target.Login.UserName + "'.", isConnectionProblem: true);
                }

                if (sql == PosDatabaseFinder.ListDatabasesSql)
                {
                    return FakeQueryExecutor.Table(
                        new[] { "name", "ServerName" },
                        server.Databases.Keys.OrderBy(name => name).Select(name => new object[] { name, server.Identity }).ToArray());
                }

                var database = server.Databases[target.Database];
                switch (sql)
                {
                    case PosDatabaseFinder.ProbeSql:
                        return FakeQueryExecutor.Table(new[] { "IsPos", "HasCompany" }, new object[] { database.IsPos ? 1 : 0, database.Company == null ? 0 : 1 });
                    case PosDatabaseFinder.BillsSql:
                        var canWrite = database.CanWrite && !database.ReadOnlyLogins.Contains(target.Login.UserName);
                        return FakeQueryExecutor.Table(new[] { "Bills", "LastBill", "WriteRights" }, new object[] { database.Bills, database.LastBill, canWrite ? 3 : 0 });
                    case PosDatabaseFinder.CompanySql:
                        return FakeQueryExecutor.Table(new[] { "CompanyName" }, new object[] { database.Company });
                    default:
                        throw new InvalidOperationException("Unexpected query: " + sql);
                }
            }
        }
    }
}

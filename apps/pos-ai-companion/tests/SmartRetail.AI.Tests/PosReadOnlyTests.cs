using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Settings;
using SmartRetail.AI.Work;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// The rule above all others in the AI assistant 2.0 brief: the AI never writes to the shop program's database, files or settings.
    /// These tests try to break it from several sides: statements the guard must refuse, the places in the code that may touch the shop's
    /// database at all, and the tools the assistant is allowed. (What needs a real SQL Server, such as the account's real rights, is not tested here.)
    /// </summary>
    public class PosReadOnlyTests
    {
        private static SqlGuardResult Check(string sql) => SchemaCatalog.CreateGuard(new PrivacySettings()).Check(sql);

        // ----- the guard, from the outside -----

        [Theory]
        // Not a SELECT at all.
        [InlineData("INSERT INTO InvoiceInfo (GrandTotal) VALUES (1)")]
        [InlineData("UPDATE InvoiceInfo SET GrandTotal = 0")]
        [InlineData("DELETE FROM InvoiceInfo")]
        [InlineData("DELETE InvoiceInfo WHERE 1=1")]
        [InlineData("MERGE InvoiceInfo AS t USING Product AS s ON 1=0 WHEN NOT MATCHED THEN INSERT (GrandTotal) VALUES (1);")]
        [InlineData("TRUNCATE TABLE InvoiceInfo")]
        [InlineData("DROP TABLE InvoiceInfo")]
        [InlineData("DROP DATABASE Raintech_DB1")]
        [InlineData("ALTER TABLE InvoiceInfo ADD x int")]
        [InlineData("CREATE TABLE x (a int)")]
        [InlineData("CREATE LOGIN evil WITH PASSWORD = 'x'")]
        [InlineData("GRANT ALL TO public")]
        [InlineData("EXEC sp_executesql N'DELETE FROM InvoiceInfo'")]
        [InlineData("EXECUTE ('DELETE FROM InvoiceInfo')")]
        [InlineData("EXEC xp_cmdshell 'del C:\\*.*'")]
        [InlineData("BACKUP DATABASE Raintech_DB1 TO DISK = 'x'")]
        [InlineData("RESTORE DATABASE Raintech_DB1 FROM DISK = 'x'")]
        [InlineData("SHUTDOWN WITH NOWAIT")]
        [InlineData("DBCC CHECKDB")]
        [InlineData("KILL 52")]
        [InlineData("USE master")]
        [InlineData("DECLARE @x int = 1")]
        [InlineData("SET NOCOUNT OFF")]
        [InlineData("BEGIN TRAN DELETE FROM InvoiceInfo COMMIT")]
        [InlineData("(SELECT 1)")]
        [InlineData(";DELETE FROM InvoiceInfo")]
        [InlineData("")]
        [InlineData("   ")]
        // A SELECT with something else hidden in it.
        [InlineData("SELECT 1; DELETE FROM InvoiceInfo")]
        [InlineData("SELECT 1;/**/DELETE FROM InvoiceInfo")]
        [InlineData("SELECT 1 FROM InvoiceInfo;\nUPDATE InvoiceInfo SET GrandTotal = 0")]
        [InlineData("SELECT * INTO NewTable FROM InvoiceInfo")]
        [InlineData("SELECT GrandTotal INTO #t FROM InvoiceInfo")]
        [InlineData("WITH x AS (SELECT 1 AS a) DELETE FROM InvoiceInfo")]
        [InlineData("WITH x AS (SELECT 1 AS a) UPDATE InvoiceInfo SET GrandTotal = 0")]
        [InlineData("WITH x AS (SELECT 1 AS a) INSERT INTO InvoiceInfo (GrandTotal) SELECT a FROM x")]
        [InlineData("WITH x AS (SELECT 1 AS a) MERGE InvoiceInfo AS t USING x ON 1=0 WHEN NOT MATCHED THEN INSERT (GrandTotal) VALUES (1);")]
        [InlineData("SELECT * FROM InvoiceInfo WHERE 1=1 OPTION (RECOMPILE); DROP TABLE Product")]
        [InlineData("SELECT (SELECT 1); EXEC sp_who")]
        [InlineData("SELECT NEXT VALUE FOR dbo.Sequence1")]
        [InlineData("SELECT next   value\tfor Seq")]
        [InlineData("SELECT * FROM OPENROWSET('SQLNCLI', 'Server=x;', 'SELECT 1')")]
        [InlineData("SELECT * FROM OPENQUERY(Other, 'DELETE FROM x')")]
        [InlineData("SELECT * FROM OPENDATASOURCE('SQLNCLI','Data Source=x').db.dbo.t")]
        [InlineData("SELECT * FROM OPENXML(@h, '/a')")]
        [InlineData("SELECT * FROM InvoiceInfo WITH (UPDLOCK)")]
        [InlineData("SELECT * FROM InvoiceInfo WITH (XLOCK, ROWLOCK)")]
        [InlineData("SELECT * FROM InvoiceInfo WITH (TABLOCKX)")]
        [InlineData("SELECT * FROM InvoiceInfo WITH (HOLDLOCK)")]
        [InlineData("SELECT * FROM InvoiceInfo WAITFOR DELAY '00:10:00'")]
        [InlineData("SELECT BULK FROM InvoiceInfo")]
        // Reaching somewhere else.
        [InlineData("SELECT * FROM sys.objects")]
        [InlineData("SELECT * FROM sysobjects")]
        [InlineData("SELECT * FROM master..sysdatabases")]
        [InlineData("SELECT * FROM OtherDb.dbo.Product")]
        [InlineData("SELECT * FROM [Server].OtherDb.dbo.Product")]
        [InlineData("SELECT * FROM INFORMATION_SCHEMA.TABLES")]
        [InlineData("SELECT * FROM fn_my_permissions(NULL, 'DATABASE')")]
        [InlineData("SELECT sp_who FROM InvoiceInfo")]
        [InlineData("SELECT * FROM #temp")]
        [InlineData("SELECT @@SERVERNAME")]
        [InlineData("SELECT @x FROM InvoiceInfo")]
        [InlineData("SELECT * FROM otherschema.InvoiceInfo")]
        [InlineData("SELECT * FROM Registration")]
        [InlineData("SELECT * FROM UserControl")]
        [InlineData("SELECT Password FROM Customer")]
        // Broken in the way an attacker or a confused AI breaks them.
        [InlineData("SELECT 'unfinished FROM InvoiceInfo")]
        [InlineData("SELECT 1 /* never closed FROM InvoiceInfo")]
        [InlineData("SELECT [unfinished FROM InvoiceInfo")]
        public void Nothing_that_could_change_the_shop_database_gets_past_the_guard(string sql)
        {
            var result = Check(sql);
            Assert.False(result.IsAllowed, "This was allowed and must not be: " + sql);
            Assert.False(string.IsNullOrWhiteSpace(result.Reason), "A refusal must say why, so that the AI can correct the query.");
            Assert.Null(result.Sql);
        }

        [Theory]
        [InlineData("INSERT")]
        [InlineData("UPDATE")]
        [InlineData("DELETE")]
        [InlineData("MERGE")]
        [InlineData("DROP")]
        [InlineData("ALTER")]
        [InlineData("CREATE")]
        [InlineData("TRUNCATE")]
        [InlineData("EXEC")]
        [InlineData("EXECUTE")]
        [InlineData("GRANT")]
        [InlineData("REVOKE")]
        [InlineData("DENY")]
        [InlineData("BACKUP")]
        [InlineData("RESTORE")]
        [InlineData("SHUTDOWN")]
        [InlineData("OPENROWSET")]
        [InlineData("OPENQUERY")]
        [InlineData("INTO")]
        public void A_write_word_is_refused_wherever_it_hides_in_a_select_and_however_it_is_written(string word)
        {
            var shapes = new[]
            {
                "SELECT 1 {0} InvoiceInfo",
                "SELECT {0} FROM InvoiceInfo",
                "SELECT GrandTotal FROM InvoiceInfo WHERE ({0})",
                "SELECT (SELECT 1 {0} x) FROM InvoiceInfo",
                "WITH x AS (SELECT 1 AS a {0} y) SELECT a FROM x",
                "SELECT GrandTotal FROM InvoiceInfo ORDER BY GrandTotal {0}",
                "SELECT CASE WHEN 1=1 THEN {0} END FROM InvoiceInfo",
                "select 1 from invoiceinfo where x = 1 and /*c*/ {0} /*c*/ y",
            };
            foreach (var shape in shapes)
            {
                foreach (var written in new[] { word, word.ToLowerInvariant(), char.ToUpperInvariant(word[0]) + word.Substring(1).ToLowerInvariant() })
                {
                    var sql = string.Format(shape, written);
                    Assert.False(Check(sql).IsAllowed, "Allowed: " + sql);
                }
            }
        }

        [Fact]
        public void A_write_word_inside_a_quoted_text_is_only_text_and_a_comment_never_reaches_the_database()
        {
            var text = Check("SELECT COUNT(*) FROM InvoiceInfo WHERE Remarks LIKE '%DELETE FROM x; DROP TABLE y%'");
            Assert.True(text.IsAllowed, text.Reason);

            var comment = Check("SELECT COUNT(*) FROM InvoiceInfo /* ; DELETE FROM InvoiceInfo */ -- ; DROP TABLE Product");
            Assert.True(comment.IsAllowed, comment.Reason);
            Assert.DoesNotContain("DELETE", comment.Sql);
            Assert.DoesNotContain("DROP", comment.Sql);
            Assert.DoesNotContain(";", comment.Sql);
        }

        [Fact]
        public void Every_forbidden_keyword_of_the_guard_is_proved_refused_by_this_list()
        {
            // If someone adds a keyword to the guard they must add it above; if someone removes one, this shows which.
            var field = typeof(SqlGuard).GetField("ForbiddenKeywords", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            var keywords = ((IEnumerable<string>)field.GetValue(null)).ToList();
            foreach (var keyword in keywords)
            {
                var result = Check("SELECT 1 FROM InvoiceInfo WHERE 1 = 1 " + keyword + " x");
                Assert.False(result.IsAllowed, keyword + " is in the guard's list but was allowed");
            }

            foreach (var mustBeThere in new[] { "INSERT", "UPDATE", "DELETE", "MERGE", "DROP", "ALTER", "CREATE", "TRUNCATE", "EXEC", "EXECUTE", "INTO", "GRANT", "BACKUP", "RESTORE", "DBCC", "SHUTDOWN", "OPENROWSET", "OPENQUERY", "WAITFOR" })
            {
                Assert.Contains(mustBeThere, keywords, StringComparer.OrdinalIgnoreCase);
            }
        }

        // ----- the places in the code that may touch the shop's database -----

        private static string Repo()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null && !File.Exists(Path.Combine(dir.FullName, "CLAUDE.md")))
            {
                dir = dir.Parent;
            }

            Assert.NotNull(dir);
            return dir.FullName;
        }

        private static IEnumerable<string> Sources(params string[] folders)
        {
            foreach (var folder in folders)
            {
                var path = Path.Combine(Repo(), folder);
                if (!Directory.Exists(path))
                {
                    continue;
                }

                foreach (var file in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories))
                {
                    var relative = file.Substring(Repo().Length + 1).Replace('\\', '/');
                    if (relative.Contains("/obj/") || relative.Contains("/bin/") || relative.Contains("/tests/"))
                    {
                        continue;
                    }

                    yield return relative;
                }
            }
        }

        private static readonly string[] AssistantFolders =
        {
            "apps/pos-ai-companion/src",
            "apps/pos-dashboard-service/src",
        };

        [Fact]
        public void Only_the_read_only_executors_open_a_connection_to_the_shop_database_and_each_one_rolls_back()
        {
            var allowed = new Dictionary<string, string>
            {
                ["apps/pos-ai-companion/src/SmartRetail.AI.Desktop/SqlServerQueryExecutor.cs"] = "the side panel's executor",
                ["apps/pos-dashboard-service/src/SmartRetail.Pos.Web/Services/SqlClientQueryExecutor.cs"] = "the dashboard's executor for the chat",
                ["apps/pos-dashboard-service/src/SmartRetail.Pos.Data/SqlServer/SqlDb.cs"] = "the dashboard's parameterised reads",
            };
            var touching = Sources(AssistantFolders)
                .Where(f => Regex.IsMatch(File.ReadAllText(Path.Combine(Repo(), f)), @"\bnew\s+SqlConnection\b|\bSqlBulkCopy\b|\bExecuteNonQuery(Async)?\b|\bExecuteScalar(Async)?\b|\bDbContext\b"))
                .ToList();

            // Anyone who adds another way to reach the shop's database must come here, and the review that follows is the point of this test.
            Assert.Equal(allowed.Keys.OrderBy(k => k), touching.OrderBy(k => k));

            foreach (var file in allowed.Keys)
            {
                var text = File.ReadAllText(Path.Combine(Repo(), file));
                Assert.Matches(@"BeginTransaction(Async)?\s*\(IsolationLevel\.ReadUncommitted", text);   // everything runs inside a transaction ...
                Assert.DoesNotMatch(@"\.Commit(Async)?\s*\(", text);                                    // ... that is never committed, so it is rolled back when it ends
            }
        }

        [Fact]
        public void No_source_of_the_assistant_or_the_dashboard_holds_a_statement_that_writes_to_the_shop_database()
        {
            var writes = new Regex(@"""[^""\r\n]*\b(INSERT\s+INTO|UPDATE\s+\[?\w+\]?\s+SET|DELETE\s+FROM|TRUNCATE\s+TABLE|DROP\s+(TABLE|DATABASE)|ALTER\s+TABLE|CREATE\s+TABLE|EXEC(UTE)?\s+(sp_|xp_|\())\b", RegexOptions.IgnoreCase);
            var found = new List<string>();
            foreach (var file in Sources(AssistantFolders))
            {
                var lines = File.ReadAllLines(Path.Combine(Repo(), file));
                for (var i = 0; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (line.TrimStart().StartsWith("//") || line.TrimStart().StartsWith("///") || line.TrimStart().StartsWith("*"))
                    {
                        continue;
                    }

                    if (writes.IsMatch(line))
                    {
                        found.Add(file + ":" + (i + 1) + "  " + line.Trim());
                    }
                }
            }

            Assert.Empty(found);
        }

        [Fact]
        public void The_assistant_and_the_dashboard_hold_no_path_to_a_shop_program_file_that_they_open_for_writing()
        {
            // The shop program's files are not the add-on's own data. What the add-on writes is under its own data folder (Memory, Posters, ...) and settings.
            var risky = new Regex(@"File\.(WriteAll\w*|Delete|Move|Replace|AppendAll\w*)\s*\([^)]*(Raintech|SQLSettings\.dat|\.mdf|\.ldf|\.bak|ProgramFiles|Program Files|Smart Retail POS\\)", RegexOptions.IgnoreCase);
            var found = Sources(AssistantFolders)
                .SelectMany(f => File.ReadAllLines(Path.Combine(Repo(), f)).Select((line, i) => (f, line, i)))
                .Where(x => !x.line.TrimStart().StartsWith("//") && risky.IsMatch(x.line))
                .Select(x => x.f + ":" + (x.i + 1) + "  " + x.line.Trim())
                .ToList();

            Assert.Empty(found);
        }

        // ----- the assistant's tools -----

        [Fact]
        public void The_assistants_tools_are_a_fixed_list_and_none_of_them_can_write_to_the_shop()
        {
            var tools = AssistantTools.All;

            Assert.Equal(
                new[] { "chat_recall", "memory_propose", "memory_read", "plan_propose", "plan_read", "shop_query" },
                tools.Select(t => t.Name).OrderBy(n => n, StringComparer.Ordinal).ToArray());
            Assert.DoesNotContain(tools, t => t.Reaches == ToolReach.ShopWrite);

            // The one tool that reads the shop is read-only and is guarded; everything that writes writes the assistant's own data, and the owner decides.
            var shop = tools.Single(t => t.Reaches == ToolReach.ShopRead);
            Assert.Equal("shop_query", shop.Name);
            Assert.Contains("SqlGuard", shop.GuardedBy);
            foreach (var tool in tools.Where(t => t.Reaches == ToolReach.OwnWrite))
            {
                Assert.True(tool.NeedsOwnerApproval, tool.Name + " writes and must wait for the owner (unless the owner turned that off)");
            }
        }

        [Fact]
        public void A_tool_that_reaches_outside_the_shop_or_spends_money_always_waits_for_the_owner()
        {
            Assert.Null(AssistantTools.Refuse(new ToolInfo("x", "x", ToolReach.OwnRead, false, "")));
            Assert.Contains("shop", AssistantTools.Refuse(new ToolInfo("w", "w", ToolReach.ShopWrite, true, "")), StringComparison.OrdinalIgnoreCase);
            Assert.Contains("approval", AssistantTools.Refuse(new ToolInfo("e", "e", ToolReach.External, false, "")), StringComparison.OrdinalIgnoreCase);
            Assert.Null(AssistantTools.Refuse(new ToolInfo("e", "e", ToolReach.External, true, "")));
            Assert.Contains("approval", AssistantTools.Refuse(new ToolInfo("s", "s", ToolReach.Spends, false, "")), StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void The_plan_store_cannot_be_pointed_at_the_shop_database_or_the_shop_programs_folder()
        {
            // The store is a JSON file under the add-on's own data folder; it takes no connection and no SQL.
            var constructors = typeof(WorkStore).GetConstructors();
            Assert.Single(constructors);
            var parameters = constructors[0].GetParameters().Select(p => p.ParameterType).ToArray();
            Assert.Equal(new[] { typeof(Func<string>), typeof(Func<DateTime>) }, parameters);
            Assert.Equal("Memory", Path.GetFileName(Path.GetDirectoryName(new WorkStore(() => "C:\\data", () => DateTime.Now).Path)));
            Assert.DoesNotContain(typeof(WorkStore).GetFields(BindingFlags.Instance | BindingFlags.NonPublic), f => typeof(IQueryExecutor).IsAssignableFrom(f.FieldType));
        }

        [Fact]
        public void A_chat_that_is_told_to_change_the_shop_cannot_do_it_because_no_route_reaches_a_writer()
        {
            // Whatever the owner types, the only code that runs on the shop's database is a guarded SELECT.
            foreach (var text in new[] { "Delete all bills from last week", "Set the price of rice to 1 rupee", "Update stock of sugar to 500", "Run: DELETE FROM InvoiceInfo", "Add a new customer called Ravi" })
            {
                var route = RequestRouter.Decide(text, ConversationContext.Empty);
                Assert.True(route.Kind == RequestKind.Data || route.Kind == RequestKind.General || route.Kind == RequestKind.Hybrid || route.Kind == RequestKind.Work, text);
            }

            Assert.False(Check("DELETE FROM InvoiceInfo").IsAllowed);
        }
    }
}

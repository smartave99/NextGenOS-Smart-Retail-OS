using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// The last layer of protection is the database's own: an account that can only read. The check asks the database what the account may do and says so
    /// in plain words; with "require a read-only account" on, nothing from the shop's data is asked until the account is shown to be one.
    /// (Whether a real SQL Server answers the check as these tests assume is not tested here: it needs a SQL Server.)
    /// </summary>
    public class PosAccessTests
    {
        private static readonly DateTime Noon = new DateTime(2026, 10, 12, 12, 0, 0);

        private static readonly string[] Columns = { "IsSysAdmin", "IsDbOwner", "IsDataWriter", "IsDdlAdmin", "CanInsert", "CanUpdate", "CanDelete", "CanExecute", "CanAlter" };

        private static QueryResult Rights(params object[] values) =>
            new QueryResult(Columns, new[] { values }, false, TimeSpan.Zero);

        [Fact]
        public void An_account_with_none_of_the_rights_is_read_only()
        {
            var report = PosAccessCheck.Read(Rights(0, 0, 0, 0, 0, 0, 0, 0, 0));

            Assert.True(report.Checked);
            Assert.False(report.CanChange);
            Assert.True(report.IsReadOnly);
            Assert.Empty(report.Reasons);
        }

        [Fact]
        public void An_administrator_is_not_read_only_and_the_reasons_are_in_plain_words()
        {
            var report = PosAccessCheck.Read(Rights(1, 1, 1, 1, 1, 1, 1, 1, 1));

            Assert.True(report.Checked);
            Assert.True(report.CanChange);
            Assert.False(report.IsReadOnly);
            Assert.Equal(9, report.Reasons.Count);
            Assert.Contains("the account is a server administrator (sysadmin)", report.Reasons);
            Assert.Contains("the account may delete rows", report.Reasons);
        }

        [Theory]
        [InlineData(4, "the account may add rows")]
        [InlineData(5, "the account may change rows")]
        [InlineData(6, "the account may delete rows")]
        [InlineData(7, "the account may run stored procedures, which can write")]
        [InlineData(8, "the account may alter the database")]
        public void Any_single_right_to_change_data_is_enough_to_say_the_account_is_not_read_only(int which, string words)
        {
            var values = new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            values[which] = 1;

            var report = PosAccessCheck.Read(Rights(values));

            Assert.True(report.CanChange);
            Assert.Equal(new[] { words }, report.Reasons.ToArray());
        }

        [Fact]
        public void An_answer_that_is_not_the_one_asked_for_is_not_a_pass()
        {
            Assert.False(PosAccessCheck.Read(null).Checked);
            Assert.False(PosAccessCheck.Read(new QueryResult(Columns, new object[0][], false, TimeSpan.Zero)).Checked);
            Assert.False(PosAccessCheck.Read(new QueryResult(new[] { "Other" }, new[] { new object[] { 1 } }, false, TimeSpan.Zero)).Checked);
            // All unknown (null) answers say nothing; that must never read as "read-only".
            var unknown = PosAccessCheck.Read(Rights(null, null, null, null, null, null, null, null, null));
            Assert.False(unknown.Checked);
            Assert.False(unknown.IsReadOnly);
        }

        [Fact]
        public void The_question_asked_of_the_database_is_one_select_that_reads_no_table_and_changes_nothing()
        {
            var sql = PosAccessCheck.Sql;

            Assert.StartsWith("SELECT", sql);
            Assert.DoesNotContain(";", sql);
            Assert.DoesNotContain(" FROM ", sql, StringComparison.OrdinalIgnoreCase);
            // The names of rights appear only as quoted text (the arguments of HAS_PERMS_BY_NAME), never as words of the statement.
            var outsideQuotes = Regex.Replace(sql, "'[^']*'", "''");
            Assert.DoesNotMatch(new Regex(@"\b(INSERT|UPDATE|DELETE|MERGE|DROP|ALTER|CREATE|TRUNCATE|EXEC|EXECUTE|INTO|GRANT)\b", RegexOptions.IgnoreCase), outsideQuotes);
        }

        [Fact]
        public async Task A_database_that_cannot_be_reached_is_reported_as_not_checked()
        {
            var database = new FakeQueryExecutor { Handler = _ => throw new QueryExecutionException("no route to host", isConnectionProblem: true) };

            var report = await PosAccessCheck.RunAsync(database, () => Noon, CancellationToken.None);

            Assert.False(report.Checked);
            Assert.Contains("could not be reached", report.Problem);
            Assert.False(report.IsReadOnly);
        }

        [Fact]
        public async Task The_answer_is_kept_for_ten_minutes_and_asked_again_after_that_or_when_forced()
        {
            var now = Noon;
            var database = new FakeQueryExecutor { Handler = _ => Rights(0, 0, 0, 0, 0, 0, 0, 0, 0) };
            var monitor = new PosAccessMonitor(database, () => now);

            await monitor.CheckAsync(CancellationToken.None);
            now = now.AddMinutes(9);
            await monitor.CheckAsync(CancellationToken.None);
            Assert.Single(database.Queries);

            now = now.AddMinutes(2);
            await monitor.CheckAsync(CancellationToken.None);
            Assert.Equal(2, database.Queries.Count);

            await monitor.CheckAsync(CancellationToken.None, force: true);
            Assert.Equal(3, database.Queries.Count);
            Assert.True(monitor.Last.IsReadOnly);
        }

        [Fact]
        public async Task A_failed_check_is_not_kept_and_is_asked_again_at_once()
        {
            var database = new FakeQueryExecutor { Handler = _ => throw new QueryExecutionException("down", isConnectionProblem: true) };
            var monitor = new PosAccessMonitor(database, () => Noon);

            await monitor.CheckAsync(CancellationToken.None);
            await monitor.CheckAsync(CancellationToken.None);

            Assert.Equal(2, database.Queries.Count);
        }

        // ----- the setting -----

        private const string BillsQuery = "{\"sql\": \"SELECT COUNT(*) AS Bills FROM InvoiceInfo\", \"explanation\": \"Bills\"}";

        private static (Conversation Chat, FakeProvider Codex, FakeQueryExecutor Database) NewChat(bool require, PosAccessMonitor monitor, Func<string, QueryResult> rights = null)
        {
            var settings = TestSettings.Create().Settings;
            settings.Privacy.RequireReadOnlyAccount = require;
            var codex = new FakeProvider(ProviderIds.CodexCli);
            var database = new FakeQueryExecutor
            {
                Handler = sql => sql.Contains("IS_SRVROLEMEMBER")
                    ? (rights ?? (_ => Rights(0, 0, 0, 0, 0, 0, 0, 0, 0)))(sql)
                    : sql.Contains("INFORMATION_SCHEMA")
                        ? FakeQueryExecutor.Table(new[] { "TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "CHARACTER_MAXIMUM_LENGTH" }, new object[] { "InvoiceInfo", "GrandTotal", "decimal", null })
                        : FakeQueryExecutor.Table(new[] { "Bills" }, new object[] { 12 }),
            };
            var backend = new BusinessChatBackend(() => new ProviderRouter(new IAiProvider[] { codex }, () => settings), database, () => settings, () => Noon, access: monitor ?? new PosAccessMonitor(database, () => Noon));
            return (new Conversation(backend, () => Noon), codex, database);
        }

        [Fact]
        public async Task With_the_setting_on_and_a_read_only_account_the_question_goes_to_the_database_as_before()
        {
            var (chat, codex, database) = NewChat(require: true, monitor: null);
            codex.Answers(BillsQuery, "12 bills today.");

            chat.Ask("How many bills did we make today?");
            await chat.Current;

            Assert.Equal("12 bills today.", chat.Messages.Last().Text);
            Assert.Contains(database.Queries, q => q.Contains("COUNT(*)"));
        }

        [Fact]
        public async Task With_the_setting_on_and_an_account_that_can_change_data_nothing_is_asked_of_the_shops_data_and_the_owner_is_told_why()
        {
            var (chat, codex, database) = NewChat(require: true, monitor: null, rights: _ => Rights(1, 0, 0, 0, 0, 0, 0, 0, 0));

            chat.Ask("How many bills did we make today?");
            await chat.Current;

            var reply = chat.Messages.Last().Text;
            Assert.Contains("only with a read-only database account", reply);
            Assert.Contains("server administrator", reply);
            Assert.Contains("create_readonly_login.sql", reply);
            Assert.Empty(codex.Requests);                                       // the AI was not even asked to write a query
            Assert.Single(database.Queries);                                    // only the check itself ran
            Assert.Contains("IS_SRVROLEMEMBER", database.Queries.Single());
        }

        [Fact]
        public async Task With_the_setting_on_and_a_database_that_cannot_be_checked_it_fails_closed()
        {
            var (chat, codex, database) = NewChat(require: true, monitor: null, rights: _ => throw new QueryExecutionException("timeout", isConnectionProblem: true));

            chat.Ask("How many bills did we make today?");
            await chat.Current;

            Assert.Contains("could not be checked", chat.Messages.Last().Text);
            Assert.Empty(codex.Requests);
            Assert.DoesNotContain(database.Queries, q => q.Contains("COUNT(*)"));
        }

        [Fact]
        public async Task With_the_setting_on_a_chat_that_has_no_way_to_check_refuses_the_data_but_still_gives_advice()
        {
            var settings = TestSettings.Create().Settings;
            settings.Privacy.RequireReadOnlyAccount = true;
            var codex = new FakeProvider(ProviderIds.CodexCli).Answers("Start with a small pilot.");
            var database = new FakeQueryExecutor();
            var backend = new BusinessChatBackend(() => new ProviderRouter(new IAiProvider[] { codex }, () => settings), database, () => settings, () => Noon);
            var chat = new Conversation(backend, () => Noon);

            chat.Ask("How many bills did we make today?");
            await chat.Current;
            Assert.Contains("this copy cannot check that", chat.Messages.Last().Text);

            chat.Ask("What do you think about e-rickshaw posters for the shop?");
            await chat.Current;
            Assert.Equal("Start with a small pilot.", chat.Messages.Last().Text);
            Assert.Empty(database.Queries);
        }

        [Fact]
        public async Task With_the_setting_off_the_database_is_not_even_asked_what_the_account_may_do()
        {
            var (chat, codex, database) = NewChat(require: false, monitor: null, rights: _ => Rights(1, 1, 1, 1, 1, 1, 1, 1, 1));
            codex.Answers(BillsQuery, "12 bills today.");

            chat.Ask("How many bills did we make today?");
            await chat.Current;

            Assert.Equal("12 bills today.", chat.Messages.Last().Text);
            Assert.DoesNotContain(database.Queries, q => q.Contains("IS_SRVROLEMEMBER"));
        }
    }
}

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class BusinessAssistantTests
    {
        private static readonly DateTime Today = new DateTime(2026, 9, 24, 18, 30, 0);

        private readonly AssistantSettings _settings = TestSettings.Create().Settings;
        private readonly FakeProvider _codex = new FakeProvider(ProviderIds.CodexCli);
        private readonly FakeProvider _claude = new FakeProvider(ProviderIds.ClaudeCli);
        private readonly FakeQueryExecutor _database = new FakeQueryExecutor();

        public BusinessAssistantTests()
        {
            _database.Handler = sql => sql.Contains("INFORMATION_SCHEMA")
                ? FakeQueryExecutor.Table(new[] { "TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "CHARACTER_MAXIMUM_LENGTH" },
                    new object[] { "InvoiceInfo", "Inv_ID", "int", null },
                    new object[] { "InvoiceInfo", "GrandTotal", "decimal", null },
                    new object[] { "Registration", "Password", "nchar", 50L })
                : FakeQueryExecutor.Table(new[] { "Bills", "Sales" }, new object[] { 18, 12500.50m });
        }

        private BusinessAssistant Assistant => new BusinessAssistant(
            new ProviderRouter(new IAiProvider[] { _codex, _claude }, () => _settings), _database, () => _settings, () => Today);

        [Fact]
        public async Task Writes_a_query_runs_it_and_explains_the_result()
        {
            _codex.Answers("{\"sql\": \"SELECT COUNT(*) AS Bills, SUM(GrandTotal) AS Sales FROM InvoiceInfo WHERE CAST(InvoiceDate AS date) = '2026-09-24'\", \"explanation\": \"Bills today\"}",
                "Aaj 18 bills mein ₹12,500.50 ki sale hui.");

            var answer = await Assistant.AskAsync("Aaj kitni sale hui?", ProviderIds.Auto, null, CancellationToken.None);

            Assert.Equal("Aaj 18 bills mein ₹12,500.50 ki sale hui.", answer.Answer);
            Assert.Equal(ProviderIds.CodexCli, answer.ProviderId);
            Assert.StartsWith("SELECT COUNT(*) AS Bills", answer.Sql);
            Assert.Equal(18, answer.Result.Rows[0][0]);

            var sqlPrompt = _codex.Requests[0];
            Assert.Contains("InvoiceInfo: Inv_ID int, GrandTotal decimal", sqlPrompt.UserPrompt);
            Assert.DoesNotContain("Password", sqlPrompt.UserPrompt);
            Assert.Contains("Today is 2026-09-24 (Thursday)", sqlPrompt.SystemPrompt);
            Assert.Contains("12500.5", _codex.Requests[1].UserPrompt);
        }

        [Fact]
        public async Task A_refused_query_is_sent_back_for_one_correction()
        {
            _codex.Answers("{\"sql\": \"DELETE FROM InvoiceInfo\"}", "{\"sql\": \"SELECT COUNT(*) AS Bills FROM InvoiceInfo\"}", "18 bills.");

            var answer = await Assistant.AskAsync("How many bills?", ProviderIds.Auto, null, CancellationToken.None);

            Assert.Equal("18 bills.", answer.Answer);
            Assert.DoesNotContain(_database.Queries, q => q.Contains("DELETE"));
            Assert.Contains("It could not be used", _codex.Requests[1].UserPrompt);
            Assert.Contains("DELETE FROM InvoiceInfo", _codex.Requests[1].UserPrompt);
        }

        [Fact]
        public async Task A_database_error_is_sent_back_for_correction()
        {
            var failedOnce = false;
            _database.Handler = sql =>
            {
                if (sql.Contains("INFORMATION_SCHEMA"))
                {
                    return FakeQueryExecutor.Table(new[] { "TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "CHARACTER_MAXIMUM_LENGTH" });
                }

                if (sql.Contains("InvoiceDat ") && !failedOnce)
                {
                    failedOnce = true;
                    throw new QueryExecutionException("Invalid column name 'InvoiceDat'.");
                }

                return FakeQueryExecutor.Table(new[] { "Bills" }, new object[] { 3 });
            };
            _codex.Answers("{\"sql\": \"SELECT COUNT(*) AS Bills FROM InvoiceInfo WHERE InvoiceDat > '2026-01-01'\"}",
                "{\"sql\": \"SELECT COUNT(*) AS Bills FROM InvoiceInfo WHERE InvoiceDate > '2026-01-01'\"}",
                "3 bills.");

            var answer = await Assistant.AskAsync("Bills this year?", ProviderIds.Auto, null, CancellationToken.None);

            Assert.Equal("3 bills.", answer.Answer);
            Assert.Contains("Invalid column name 'InvoiceDat'", _codex.Requests[1].UserPrompt);
        }

        [Fact]
        public async Task Gives_up_after_two_unusable_queries()
        {
            _codex.Answers("{\"sql\": \"DROP TABLE Product\"}", "{\"sql\": \"SELECT * FROM Registration\"}");

            var error = await Assert.ThrowsAsync<AssistantException>(() => Assistant.AskAsync("Delete everything", ProviderIds.Auto, null, CancellationToken.None));

            Assert.Contains("Registration", error.Message);
            Assert.Equal("SELECT * FROM Registration", error.LastSql);
        }

        [Fact]
        public async Task A_database_connection_problem_stops_immediately()
        {
            _database.Handler = _ => throw new QueryExecutionException("A network-related error occurred.", isConnectionProblem: true);

            var error = await Assert.ThrowsAsync<AssistantException>(() => Assistant.AskAsync("Sales?", ProviderIds.Auto, null, CancellationToken.None));

            Assert.Contains("Cannot reach the POS database", error.Message);
            Assert.Empty(_codex.Requests);
        }

        [Fact]
        public async Task A_question_without_a_query_returns_the_explanation()
        {
            _codex.Answers("{\"sql\": null, \"explanation\": \"I can only answer questions about this shop's data.\"}");

            var answer = await Assistant.AskAsync("Who won the cricket match?", ProviderIds.Auto, null, CancellationToken.None);

            Assert.Equal("I can only answer questions about this shop's data.", answer.Answer);
            Assert.Null(answer.Sql);
            Assert.Single(_codex.Requests);
        }

        [Fact]
        public async Task Contact_details_are_masked_before_they_reach_the_ai()
        {
            _database.Handler = sql => sql.Contains("INFORMATION_SCHEMA")
                ? FakeQueryExecutor.Table(new[] { "a", "b", "c", "d" })
                : FakeQueryExecutor.Table(new[] { "Name", "ContactNo", "Remarks" }, new object[] { "Ramesh Kumar", "9876543210", "call 9123456780 or ramesh@example.com" });
            _codex.Answers("{\"sql\": \"SELECT RTRIM(Name) AS Name, RTRIM(ContactNo) AS ContactNo, Remarks FROM Customer\"}", "done");

            var answer = await Assistant.AskAsync("List customers", ProviderIds.Auto, null, CancellationToken.None);

            var shared = _codex.Requests[1].UserPrompt;
            Assert.Contains("Ramesh Kumar", shared);
            Assert.DoesNotContain("9876543210", shared);
            Assert.DoesNotContain("9123456780", shared);
            Assert.DoesNotContain("ramesh@example.com", shared);
            Assert.Equal("9876543210", answer.Result.Rows[0][1]);
        }

        [Fact]
        public async Task The_same_provider_answers_both_steps()
        {
            _codex.Ready = false;
            _claude.Answers("{\"sql\": \"SELECT COUNT(*) AS Bills FROM InvoiceInfo\"}", "18 bills.");

            var answer = await Assistant.AskAsync("How many bills?", ProviderIds.Auto, null, CancellationToken.None);

            Assert.Equal(ProviderIds.ClaudeCli, answer.ProviderId);
            Assert.Equal(2, _claude.Requests.Count);
        }

        [Fact]
        public async Task Ai_written_queries_can_be_turned_off()
        {
            _settings.Privacy.AllowAiWrittenQueries = false;
            var answer = await Assistant.AskAsync("Sales?", ProviderIds.Auto, null, CancellationToken.None);

            Assert.Contains("turned off", answer.Answer);
            Assert.Empty(_codex.Requests);
            Assert.Empty(_database.Queries);
        }

        [Fact]
        public async Task Quick_insights_run_without_ai_or_with_a_summary()
        {
            var insight = QuickInsights.All.First();
            var plain = await Assistant.RunInsightAsync(insight, ProviderIds.Auto, summarize: false, null, CancellationToken.None);
            Assert.Null(plain.Answer);
            Assert.Null(plain.ProviderId);
            Assert.Equal(insight.Sql, _database.Queries.Single());

            _codex.Answers("Aaj 18 bills.");
            var summarized = await Assistant.RunInsightAsync(insight, ProviderIds.Auto, summarize: true, null, CancellationToken.None);
            Assert.Equal("Aaj 18 bills.", summarized.Answer);
        }
    }
}

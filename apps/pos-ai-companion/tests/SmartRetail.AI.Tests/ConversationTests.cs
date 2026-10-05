using System;
using System.Collections.Generic;
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
    public class ConversationTests
    {
        private static readonly DateTime Noon = new DateTime(2026, 9, 26, 12, 0, 0);

        [Fact]
        public async Task A_question_and_its_answer_join_the_chat()
        {
            var backend = new FakeBackend();
            var chat = new Conversation(backend, () => Noon);
            var changes = 0;
            chat.Changed += (sender, args) => Interlocked.Increment(ref changes);

            Assert.True(chat.Ask("  Aaj kitna cash aaya?  "));
            Assert.True(chat.Busy);
            await backend.Answer("₹12,400 in cash today.");
            await chat.Current;

            Assert.False(chat.Busy);
            Assert.Equal("", chat.Status);
            Assert.Equal(new[] { ChatRole.Owner, ChatRole.Assistant }, chat.Messages.Select(m => m.Role));
            Assert.Equal("Aaj kitna cash aaya?", chat.Messages[0].Text);
            Assert.Equal("₹12,400 in cash today.", chat.Messages[1].Text);
            Assert.Equal("Aaj kitna cash aaya?", backend.Questions.Single());
            Assert.True(changes >= 2);
        }

        [Fact]
        public async Task One_question_at_a_time()
        {
            var backend = new FakeBackend();
            var chat = new Conversation(backend, () => Noon);

            Assert.True(chat.Ask("First"));
            Assert.False(chat.Ask("Second"));
            Assert.False(chat.Ask("   "));
            await backend.Answer("One");
            await chat.Current;

            Assert.True(chat.Ask("Third"));
            await backend.Answer("Two");
            await chat.Current;
            Assert.Equal(new[] { "First", "One", "Third", "Two" }, chat.Messages.Select(m => m.Text));
        }

        [Fact]
        public async Task Progress_shows_as_the_status_while_it_runs()
        {
            var backend = new FakeBackend();
            var chat = new Conversation(backend, () => Noon);

            chat.Ask("Top products?");
            await backend.Started;
            backend.Progress.Report("Running the query on the shop database…");
            Assert.Equal("Running the query on the shop database…", chat.Status);

            await backend.Answer("Rice.");
            await chat.Current;
            Assert.Equal("", chat.Status);
        }

        [Fact]
        public async Task Stop_ends_the_question()
        {
            var backend = new FakeBackend();
            var chat = new Conversation(backend, () => Noon);

            chat.Ask("Slow question");
            await backend.Started;
            chat.Stop();
            await chat.Current;

            Assert.False(chat.Busy);
            Assert.Equal("Stopped.", chat.Messages.Last().Text);
            Assert.False(chat.Messages.Last().IsProblem);
        }

        [Fact]
        public async Task A_new_chat_forgets_everything_and_drops_a_late_answer()
        {
            var backend = new FakeBackend();
            var chat = new Conversation(backend, () => Noon);
            chat.Ask("Old question");
            await backend.Started;

            chat.Clear();
            await chat.Current;

            Assert.Empty(chat.Messages);
            Assert.False(chat.Busy);
            Assert.True(chat.Ask("New question"));
        }

        [Theory]
        [InlineData("ai")]
        [InlineData("assistant")]
        [InlineData("other")]
        public async Task Problems_are_shown_in_the_chat(string kind)
        {
            var backend = new FakeBackend();
            var chat = new Conversation(backend, () => Noon);
            Exception logged = null;
            chat.Failed += (sender, ex) => logged = ex;

            chat.Ask("Question");
            await backend.Fail(kind == "ai" ? new AiProviderException("codex-cli", "Codex is not signed in.")
                : kind == "assistant" ? (Exception)new AssistantException("Cannot reach the POS database.", "SELECT 1")
                : new InvalidOperationException("Disk full."));
            await chat.Current;

            var reply = chat.Messages.Last();
            Assert.True(reply.IsProblem);
            Assert.Contains(kind == "ai" ? "not signed in" : kind == "assistant" ? "Cannot reach" : "Disk full", reply.Text);
            Assert.Equal(kind == "assistant" ? "SELECT 1" : null, reply.Sql);
            Assert.Equal(kind == "other", logged != null);
        }

        [Fact]
        public void Tables_show_the_first_rows_with_unique_column_names()
        {
            var rows = Enumerable.Range(1, 150).Select(i => new object[] { "Item " + i, i * 10m, null }).ToList();
            var table = ChatTable.From(new QueryResult(new[] { "Product", "Product", "" }, rows, truncated: true, TimeSpan.Zero));

            Assert.Equal(new[] { "Product", "Product (2)", "Column 3" }, table.Columns);
            Assert.Equal(ChatTable.MaxRowsShown, table.Rows.Count);
            Assert.Equal(150, table.TotalRows);
            Assert.True(table.MoreInDatabase);
            Assert.False(table.IsNumeric(0));
            Assert.True(table.IsNumeric(1));
            Assert.False(table.IsNumeric(2));
            Assert.Null(ChatTable.From(null));
        }

        [Fact]
        public void An_answer_without_text_still_says_something()
        {
            var empty = ChatMessage.FromAnswer(new AssistantAnswer { Result = FakeQueryExecutor.Table(new[] { "x" }) }, "", Noon);
            var report = ChatMessage.FromAnswer(new AssistantAnswer { Result = FakeQueryExecutor.Table(new[] { "x" }, new object[] { 1 }), Duration = TimeSpan.FromSeconds(1.25) }, "Report", Noon);

            Assert.Equal("No matching records.", empty.Text);
            Assert.StartsWith("Here is the report.", report.Text);
            Assert.Equal("Report · 1.3 s", report.Source);
        }

        [Fact]
        public async Task The_database_backend_runs_a_report_and_the_ai_explains_it()
        {
            var provider = new FakeProvider("fake").Answers("Sales were **₹5,000** from 12 bills.");
            var database = new FakeQueryExecutor { Handler = _ => FakeQueryExecutor.Table(new[] { "Bills", "Sales" }, new object[] { 12, 5000m }) };
            var settings = new AssistantSettings { PreferredProvider = "fake" };
            var backend = new BusinessChatBackend(() => new ProviderRouter(new[] { provider }, () => settings), database, () => settings, () => Noon);

            var starter = backend.Starters.First(s => s.Title == "Today's sales");
            var reply = await backend.RunAsync(starter, null, CancellationToken.None);

            Assert.Equal(QuickInsights.All.Count, backend.Starters.Count);
            Assert.Equal(starter.Report.Sql, database.Queries.Single());
            Assert.Equal("Sales were **₹5,000** from 12 bills.", reply.Text);
            Assert.Equal(new[] { "Bills", "Sales" }, reply.Table.Columns);
            Assert.StartsWith("Fake fake · ", reply.Source);
            Assert.Equal(starter.Report.Sql, reply.Sql);
        }

        [Fact]
        public async Task The_database_backend_runs_reports_with_no_ai_tool_ready()
        {
            var provider = new FakeProvider("fake", ready: false);
            var database = new FakeQueryExecutor { Handler = _ => FakeQueryExecutor.Table(new[] { "Bills" }, new object[] { 3 }) };
            var settings = new AssistantSettings { PreferredProvider = "fake" };
            var backend = new BusinessChatBackend(() => new ProviderRouter(new[] { provider }, () => settings), database, () => settings, () => Noon);

            var reply = await backend.RunAsync(backend.Starters[0], null, CancellationToken.None);

            Assert.Empty(provider.Requests);
            Assert.StartsWith("Here is the report.", reply.Text);
            Assert.StartsWith("Report · ", reply.Source);
        }

        [Fact]
        public async Task The_database_backend_lets_only_guarded_queries_through()
        {
            var provider = new FakeProvider("fake").Answers(
                "{\"sql\": \"DELETE FROM InvoiceInfo\"}",
                "{\"sql\": \"SELECT COUNT(*) AS Bills FROM InvoiceInfo\"}",
                "12 bills.");
            var database = new FakeQueryExecutor
            {
                Handler = sql => sql.Contains("INFORMATION_SCHEMA")
                    ? FakeQueryExecutor.Table(new[] { "TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "CHARACTER_MAXIMUM_LENGTH" })
                    : FakeQueryExecutor.Table(new[] { "Bills" }, new object[] { 12 }),
            };
            var settings = new AssistantSettings { PreferredProvider = "fake" };
            var backend = new BusinessChatBackend(() => new ProviderRouter(new[] { provider }, () => settings), database, () => settings, () => Noon);

            var reply = await backend.AskAsync("How many bills?", null, CancellationToken.None);

            Assert.DoesNotContain(database.Queries, q => q.Contains("DELETE"));
            Assert.Equal("12 bills.", reply.Text);
            Assert.Contains("SELECT COUNT(*)", reply.Sql);
        }

        /// <summary>Answers when the test says so, once the question has reached it.</summary>
        private sealed class FakeBackend : IChatBackend
        {
            private TaskCompletionSource<bool> _started = New<bool>();
            private TaskCompletionSource<ChatMessage> _current;

            public List<string> Questions { get; } = new List<string>();

            public IProgress<string> Progress { get; private set; }

            public Task Started => _started.Task;

            public IReadOnlyList<ChatStarter> Starters { get; } = new[] { new ChatStarter("Today", "How was today?") };

            public Task Answer(string text) => Finish(reply => reply.TrySetResult(new ChatMessage(ChatRole.Assistant, text, Noon)));

            public Task Fail(Exception exception) => Finish(reply => reply.TrySetException(exception));

            public async Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken)
            {
                Questions.Add(question);
                Progress = progress;
                var reply = _current = New<ChatMessage>();
                using (cancellationToken.Register(() => reply.TrySetCanceled(cancellationToken)))
                {
                    _started.TrySetResult(true);
                    return await reply.Task;
                }
            }

            public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
                AskAsync(starter.Question, progress, cancellationToken);

            private async Task Finish(Action<TaskCompletionSource<ChatMessage>> finish)
            {
                await Started;
                var reply = _current;
                _started = New<bool>();
                finish(reply);
            }

            private static TaskCompletionSource<T> New<T>() => new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
        }
    }
}

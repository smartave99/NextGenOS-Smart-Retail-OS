using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Answers that arrive word by word: Codex's app server, a custom tool's output, and the chat's draft.</summary>
    public class CodexStreamingTests : IDisposable
    {
        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;

        public CodexStreamingTests()
        {
            _settings = TestSettings.Create().Settings;
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
            _settings.CustomCli.ExecutablePath = _temp.File("custom-tool");
        }

        public void Dispose() => _temp.Dispose();

        private static string Delta(string thread, string item, string text) =>
            new JObject { ["method"] = "item/agentMessage/delta", ["params"] = new JObject { ["threadId"] = thread, ["turnId"] = "tu-1", ["itemId"] = item, ["delta"] = text } }
                .ToString(Newtonsoft.Json.Formatting.None);

        /// <summary>A turn that streams "Aaj ₹12,500 ki sale hui." and asks once for permission to run a command.</summary>
        private static FakeAppServer Streaming(string status = "completed")
        {
            var fake = new FakeAppServer { Chatty = false };
            fake.Answers["thread/start"] = _ => JObject.Parse("{\"thread\":{\"id\":\"th-1\"},\"model\":\"gpt-6-sol\"}");
            fake.Answers["turn/start"] = _ =>
            {
                // The words can arrive before the answer to turn/start itself.
                fake.Say("{\"method\":\"turn/started\",\"params\":{\"threadId\":\"th-1\",\"turn\":{\"id\":\"tu-1\"}}}");
                fake.Say(Delta("th-1", "m1", "Aaj "));
                fake.Say("{\"id\":77,\"method\":\"item/commandExecution/requestApproval\",\"params\":{\"threadId\":\"th-1\",\"command\":\"del *\"}}");
                fake.Say(Delta("other-thread", "x", "not ours"));
                fake.Say(Delta("th-1", "m1", "₹12,500"));
                fake.Say("{\"method\":\"item/completed\",\"params\":{\"threadId\":\"th-1\",\"turnId\":\"tu-1\",\"item\":{\"type\":\"agentMessage\",\"id\":\"m1\",\"text\":\"Aaj ₹12,500 ki sale hui.\"}}}");
                fake.Say(status == "completed"
                    ? "{\"method\":\"turn/completed\",\"params\":{\"threadId\":\"th-1\",\"turn\":{\"id\":\"tu-1\",\"status\":\"completed\",\"error\":null}}}"
                    : "{\"method\":\"turn/completed\",\"params\":{\"threadId\":\"th-1\",\"turn\":{\"id\":\"tu-1\",\"status\":\"failed\",\"error\":{\"message\":\"You've hit your usage limit.\"}}}}");
                return JObject.Parse("{\"turn\":{\"id\":\"tu-1\",\"status\":\"inProgress\"}}");
            };
            return fake;
        }

        [Fact]
        public async Task A_turn_streams_its_words_declines_permission_and_returns_the_last_message()
        {
            var fake = Streaming();
            var seen = new List<string>();
            string answer;
            using (var server = await CodexAppServer.StartAsync(fake, "2.3.0"))
            {
                var turn = new CodexTurnRequest { Prompt = "Question?", WorkingDirectory = "/tmp/run", Model = "gpt-6-sol", ReasoningEffort = "low" };
                turn.Images.Add("/tmp/run/photo-1.jpg");
                answer = await server.RunTurnAsync(turn, seen.Add, TimeSpan.FromSeconds(20), CancellationToken.None);
            }

            Assert.Equal("Aaj ₹12,500 ki sale hui.", answer);
            Assert.Equal(new[] { "Aaj ", "Aaj ₹12,500", "Aaj ₹12,500 ki sale hui." }, seen);

            var thread = fake.Received.Single(m => (string)m["method"] == "thread/start")["params"];
            Assert.Equal(("never", "read-only", true, "/tmp/run", "gpt-6-sol", "low"),
                ((string)thread["approvalPolicy"], (string)thread["sandbox"], (bool)thread["ephemeral"], (string)thread["cwd"], (string)thread["model"], (string)thread["config"]["model_reasoning_effort"]));
            var input = (JArray)fake.Received.Single(m => (string)m["method"] == "turn/start")["params"]["input"];
            Assert.Equal("Question?", (string)input[0]["text"]);
            Assert.Equal(("localImage", "/tmp/run/photo-1.jpg"), ((string)input[1]["type"], (string)input[1]["path"]));
            var declined = fake.Received.Single(m => (int?)m["id"] == 77);
            Assert.Equal("decline", (string)declined["result"]["decision"]);
        }

        [Fact]
        public async Task A_failed_turn_says_why()
        {
            using (var server = await CodexAppServer.StartAsync(Streaming("failed"), "2.3.0"))
            {
                var failure = await Assert.ThrowsAsync<CodexAppServerException>(() =>
                    server.RunTurnAsync(new CodexTurnRequest { Prompt = "Q", WorkingDirectory = "/tmp/run" }, null, TimeSpan.FromSeconds(20), CancellationToken.None));
                Assert.Equal("You've hit your usage limit.", failure.Message);
            }
        }

        [Fact]
        public async Task Codex_streams_an_answer_through_its_app_server_in_an_empty_folder()
        {
            var fake = Streaming();
            var codex = new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs")) { StartChannel = _ => fake };
            var seen = new List<string>();

            var response = await codex.CompleteAsync(new AiRequest { SystemPrompt = "You are the shop assistant.", UserPrompt = "Aaj?", OnText = seen.Add }, CancellationToken.None);

            Assert.Equal("Aaj ₹12,500 ki sale hui.", response.Text);
            Assert.Equal(3, seen.Count);
            Assert.Empty(_runner.Calls);
            var turn = fake.Received.Single(m => (string)m["method"] == "turn/start");
            Assert.Contains("You are the shop assistant.", (string)turn["params"]["input"][0]["text"]);
            var folder = (string)fake.Received.Single(m => (string)m["method"] == "thread/start")["params"]["cwd"];
            Assert.StartsWith(Path.Combine(_temp.Path, "runs"), folder);
            Assert.False(Directory.Exists(folder), "the per-request folder is cleaned up");
            Assert.True(fake.Disposed, "the app server is stopped");
        }

        [Fact]
        public async Task Codex_without_an_app_server_answers_the_usual_way()
        {
            _runner.Handler = call =>
            {
                File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), "Aaj ₹12,500.");
                return new CliResult { ExitCode = 0 };
            };
            var codex = new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs"))
            {
                StartChannel = _ => throw new CliStartException("Could not start codex app-server", null),
            };

            var response = await codex.CompleteAsync(new AiRequest { UserPrompt = "Aaj?", OnText = _ => { } }, CancellationToken.None);

            Assert.Equal("Aaj ₹12,500.", response.Text);
            Assert.Equal("exec", _runner.Calls.Single().Arguments[0]);
        }

        [Fact]
        public async Task A_custom_tool_streams_what_it_prints()
        {
            _settings.CustomCli.Arguments = "{prompt_file}";
            _runner.Handler = call =>
            {
                call.StandardOutputLine?.Invoke("You asked about tea.");
                call.StandardOutputLine?.Invoke("");
                call.StandardOutputLine?.Invoke("It sells **best**.");
                return new CliResult { ExitCode = 0, StandardOutput = "You asked about tea.\n\nIt sells **best**.\n" };
            };
            var custom = new CustomCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs"));
            var seen = new List<string>();

            var response = await custom.CompleteAsync(new AiRequest { UserPrompt = "Tea?", OnText = seen.Add }, CancellationToken.None);

            Assert.Equal("You asked about tea.\n\nIt sells **best**.", response.Text.Replace("\r", ""));
            Assert.Equal(new[] { "You asked about tea.", "You asked about tea.", "You asked about tea.\n\nIt sells **best**." }, seen.Select(t => t.Replace("\r", "")));
        }

        [Fact]
        public async Task Only_the_answer_streams_never_the_query()
        {
            var codex = new FakeProvider(ProviderIds.CodexCli).Answers("{\"sql\": \"SELECT COUNT(*) AS Bills FROM InvoiceInfo\", \"explanation\": \"Bills\"}", "18 bills today.");
            var database = new FakeQueryExecutor
            {
                Handler = sql => sql.Contains("INFORMATION_SCHEMA")
                    ? FakeQueryExecutor.Table(new[] { "TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "CHARACTER_MAXIMUM_LENGTH" }, new object[] { "InvoiceInfo", "Inv_ID", "int", null })
                    : FakeQueryExecutor.Table(new[] { "Bills" }, new object[] { 18 }),
            };
            var progress = new RecordingProgress();

            await new BusinessAssistant(new ProviderRouter(new IAiProvider[] { codex }, () => _settings), database, () => _settings)
                .AskAsync("How many bills?", ProviderIds.Auto, progress, CancellationToken.None);

            Assert.Null(codex.Requests[0].OnText);
            Assert.NotNull(codex.Requests[1].OnText);
            Assert.Equal(18, progress.Found.Single().Rows[0][0]);
        }

        [Fact]
        public async Task The_chat_shows_the_table_and_the_words_so_far_then_the_answer()
        {
            var release = new TaskCompletionSource<bool>();
            var backend = new DraftingBackend(release.Task);
            var chat = new Conversation(backend);

            Assert.True(chat.Ask("Aaj?"));
            await backend.Drafted.Task;
            Assert.Equal("Aaj ₹12,500", chat.Draft);
            Assert.Equal(new[] { "Sales" }, chat.DraftTable.Columns);
            Assert.True(chat.Busy);

            release.SetResult(true);
            await chat.Current;
            Assert.Equal("", chat.Draft);
            Assert.Null(chat.DraftTable);
            Assert.Equal("Aaj ₹12,500 ki sale hui.", chat.Messages.Last().Text);
        }

        private sealed class RecordingProgress : IAnswerProgress
        {
            public List<QueryResult> Found { get; } = new List<QueryResult>();

            public void Report(string value)
            {
            }

            public void Draft(string textSoFar)
            {
            }

            void IAnswerProgress.Found(QueryResult result) => Found.Add(result);
        }

        private sealed class DraftingBackend : IChatBackend
        {
            private readonly Task _release;

            public DraftingBackend(Task release) => _release = release;

            public TaskCompletionSource<bool> Drafted { get; } = new TaskCompletionSource<bool>();

            public IReadOnlyList<ChatStarter> Starters => new ChatStarter[0];

            public async Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken)
            {
                var answer = (IAnswerProgress)progress;
                answer.Found(FakeQueryExecutor.Table(new[] { "Sales" }, new object[] { 12500 }));
                answer.Draft("Aaj");
                answer.Draft("Aaj ₹12,500");
                Drafted.SetResult(true);
                await _release;
                return new ChatMessage(ChatRole.Assistant, "Aaj ₹12,500 ki sale hui.", DateTime.Now);
            }

            public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
                AskAsync(starter.Question, progress, cancellationToken);
        }
    }
}

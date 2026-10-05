using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Stands in for <c>codex app-server</c>: answers each request with what the test gives for its method.</summary>
    internal sealed class FakeAppServer : IJsonLineChannel
    {
        private readonly BlockingCollection<string> _output = new BlockingCollection<string>();

        public Dictionary<string, Func<JObject, JToken>> Answers { get; } = new Dictionary<string, Func<JObject, JToken>>();

        public List<JObject> Received { get; } = new List<JObject>();

        public bool Disposed { get; private set; }

        /// <summary>Codex's own notifications, sent before each answer, which the client must skip.</summary>
        public bool Chatty { get; set; } = true;

        public Task WriteLineAsync(string line)
        {
            var message = JObject.Parse(line);
            Received.Add(message);
            var method = (string)message["method"];
            if (message["id"] == null || method == null)
            {
                return Task.CompletedTask; // A notification, or the client's reply to a request from Codex.
            }

            if (Chatty)
            {
                _output.Add("{\"method\":\"configWarning\",\"params\":{\"summary\":\"a warning\"}}");
                _output.Add("not json at all");
            }

            if (method == "initialize")
            {
                _output.Add(new JObject { ["id"] = message["id"], ["result"] = new JObject { ["userAgent"] = "codex" } }.ToString(Newtonsoft.Json.Formatting.None));
            }
            else if (Answers.TryGetValue(method, out var answer))
            {
                var result = answer(message["params"] as JObject);
                _output.Add((result is JObject error && error["code"] != null && error.Count == 2
                    ? new JObject { ["id"] = message["id"], ["error"] = error }
                    : new JObject { ["id"] = message["id"], ["result"] = result }).ToString(Newtonsoft.Json.Formatting.None));
            }

            return Task.CompletedTask;
        }

        /// <summary>Sends a line from Codex, e.g. a notification while a turn runs.</summary>
        public void Say(string line) => _output.Add(line);

        public Task<string> ReadLineAsync() => Task.Run(() => _output.TryTake(out var line, 2000) ? line : null);

        public void Dispose() => Disposed = true;
    }

    public class CodexAppServerTests
    {
        private static JObject Error(int code, string message) => new JObject { ["code"] = code, ["message"] = message };

        [Fact]
        public async Task It_says_hello_then_reads_the_sign_in_and_the_plan()
        {
            var fake = new FakeAppServer();
            fake.Answers["getAuthStatus"] = _ => JObject.Parse("{\"authMethod\":\"chatgpt\",\"authToken\":null,\"requiresOpenaiAuth\":true}");
            fake.Answers["account/read"] = _ => JObject.Parse("{\"account\":{\"type\":\"chatgpt\",\"email\":\"owner@example.com\",\"planType\":\"plus\"},\"requiresOpenaiAuth\":true}");

            using (var server = await CodexAppServer.StartAsync(fake, "1.3.1"))
            {
                var signIn = await server.GetSignInAsync();

                Assert.True(signIn.SignedIn);
                Assert.Equal("Signed in with ChatGPT (Plus).", signIn.Describe());
                Assert.Equal("owner@example.com", signIn.Email);
            }

            Assert.True(fake.Disposed);
            Assert.Equal(new[] { "initialize", "initialized", "getAuthStatus", "account/read" }, fake.Received.Select(m => (string)m["method"]));
            Assert.Equal("smart_retail_pos", (string)fake.Received[0]["params"]["clientInfo"]["name"]);
            Assert.Null(fake.Received[1]["id"]);
            Assert.False((bool)fake.Received[2]["params"]["includeToken"]);
        }

        [Fact]
        public async Task Not_signed_in_and_api_keys_are_described_plainly()
        {
            var fake = new FakeAppServer();
            fake.Answers["getAuthStatus"] = _ => JObject.Parse("{\"authMethod\":null,\"requiresOpenaiAuth\":true}");
            using (var server = await CodexAppServer.StartAsync(fake, "1.3.1"))
            {
                Assert.False((await server.GetSignInAsync()).SignedIn);
            }

            Assert.Equal("Signed in with an OpenAI API key.", new CodexSignIn { Method = "apikey" }.Describe());
        }

        [Fact]
        public async Task Models_come_with_their_thinking_levels_default_first_hidden_ones_left_out()
        {
            var fake = new FakeAppServer();
            var pages = 0;
            fake.Answers["model/list"] = parameters => ++pages == 1
                ? JObject.Parse(@"{""data"":[
                    {""id"":""gpt-6-sol"",""model"":""gpt-6-sol"",""displayName"":""GPT-6-Sol"",""description"":""Workhorse model."",""hidden"":false,""isDefault"":false,
                     ""defaultReasoningEffort"":""medium"",""supportedReasoningEfforts"":[{""reasoningEffort"":""low"",""description"":""Fast""},{""reasoningEffort"":""medium"",""description"":""Balanced""}]},
                    {""id"":""secret"",""model"":""secret"",""displayName"":""Hidden"",""hidden"":true,""isDefault"":false,""supportedReasoningEfforts"":[]}],
                    ""nextCursor"":""page-2""}")
                : JObject.Parse(@"{""data"":[
                    {""id"":""gpt-6-astra"",""model"":""gpt-6-astra"",""displayName"":""GPT-6-Astra"",""description"":""Frontier."",""hidden"":false,""isDefault"":true,
                     ""defaultReasoningEffort"":""low"",""supportedReasoningEfforts"":[{""reasoningEffort"":""low"",""description"":""Fast""},{""reasoningEffort"":""max"",""description"":""Deepest""}]}],
                    ""nextCursor"":null}");

            using (var server = await CodexAppServer.StartAsync(fake, "1.3.1"))
            {
                var models = await server.ListModelsAsync();

                Assert.Equal(new[] { "gpt-6-astra", "gpt-6-sol" }, models.Select(m => m.Id));
                Assert.True(models[0].IsDefault);
                Assert.Equal(new[] { "low", "max" }, models[0].ReasoningEfforts.Select(e => e.Effort));
                Assert.Equal("medium", models[1].DefaultReasoningEffort);
            }

            Assert.Equal("page-2", (string)fake.Received.Last()["params"]["cursor"]);
        }

        [Fact]
        public async Task Usage_limits_read_the_five_hour_and_weekly_windows()
        {
            var fake = new FakeAppServer();
            fake.Answers["account/rateLimits/read"] = _ => JObject.Parse(@"{""ordinaryUsageAllowed"":true,""rateLimits"":{
                ""primary"":{""usedPercent"":23.5,""windowDurationMins"":300,""resetsAt"":1790433000},
                ""secondary"":{""usedPercent"":8,""windowDurationMins"":10080,""resetsAt"":1790900000000},
                ""planType"":""plus""}}");

            using (var server = await CodexAppServer.StartAsync(fake, "1.3.1"))
            {
                var usage = await server.ReadUsageAsync();

                Assert.Equal(23.5, usage.Primary.UsedPercent);
                Assert.Equal(300, usage.Primary.WindowMinutes);
                Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(1790433000), usage.Primary.ResetsAt);
                Assert.Equal(DateTimeOffset.FromUnixTimeMilliseconds(1790900000000), usage.Secondary.ResetsAt);
                Assert.True(usage.Allowed);
                Assert.Equal("plus", usage.Plan);
            }

            Assert.Null(fake.Received.Last()["params"]);
        }

        [Fact]
        public async Task An_error_from_codex_is_reported_with_its_message()
        {
            var fake = new FakeAppServer();
            fake.Answers["account/rateLimits/read"] = _ => Error(-32600, "codex account authentication required to read rate limits");

            using (var server = await CodexAppServer.StartAsync(fake, "1.3.1"))
            {
                var error = await Assert.ThrowsAsync<CodexAppServerException>(() => server.ReadUsageAsync());

                Assert.Equal(-32600, error.Code);
                Assert.Contains("authentication required", error.Message);
            }
        }

        [Fact]
        public async Task A_codex_that_never_answers_times_out()
        {
            var fake = new FakeAppServer();
            using (var server = await CodexAppServer.StartAsync(fake, "1.3.1", TimeSpan.FromMilliseconds(300)))
            {
                await Assert.ThrowsAsync<CodexAppServerException>(() => server.GetSignInAsync());
            }
        }
    }

    public class CodexStatusTests : IDisposable
    {
        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;

        public CodexStatusTests()
        {
            (_settings, _) = TestSettings.Create();
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
            _runner.Handler = call => call.Arguments.FirstOrDefault() == "--version"
                ? new CliResult { ExitCode = 0, StandardOutput = "codex-cli 0.157.1" }
                : new CliResult { ExitCode = 1, StandardOutput = "Not logged in" };
        }

        public void Dispose() => _temp.Dispose();

        private CodexCliProvider Codex(Func<CliInvocation, IJsonLineChannel> channel) =>
            new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs")) { StartChannel = channel };

        [Fact]
        public async Task Codex_is_ready_when_its_app_server_says_it_is_signed_in()
        {
            CliInvocation started = null;
            var fake = new FakeAppServer();
            fake.Answers["getAuthStatus"] = _ => JObject.Parse("{\"authMethod\":\"chatgpt\"}");
            fake.Answers["account/read"] = _ => JObject.Parse("{\"account\":{\"type\":\"chatgpt\",\"planType\":\"pro\"}}");

            var status = await Codex(invocation => { started = invocation; return fake; }).CheckAsync(CancellationToken.None);

            Assert.True(status.IsReady);
            Assert.Equal("Signed in with ChatGPT (Pro).", status.Detail);
            Assert.Equal(new[] { "app-server" }, started.Arguments);
            Assert.DoesNotContain(_runner.Calls, call => call.Arguments.Contains("login"));
        }

        [Fact]
        public async Task An_older_codex_is_asked_with_login_status_and_warnings_are_skipped()
        {
            _runner.Handler = call => call.Arguments.FirstOrDefault() == "--version"
                ? new CliResult { ExitCode = 0, StandardOutput = "codex-cli 0.40.0" }
                : new CliResult { ExitCode = 0, StandardOutput = "WARNING: proceeding, even though we could not create PATH aliases\nLogged in using ChatGPT\n" };

            var status = await Codex(_ => throw new CliStartException("no app server", new IOException())).CheckAsync(CancellationToken.None);

            Assert.True(status.IsReady);
            Assert.Equal("Logged in using ChatGPT", status.Detail);
        }

        [Fact]
        public async Task Not_signed_in_is_checked_twice_before_saying_so()
        {
            var fake = new FakeAppServer();
            fake.Answers["getAuthStatus"] = _ => JObject.Parse("{\"authMethod\":null}");

            var status = await Codex(_ => fake).CheckAsync(CancellationToken.None);

            Assert.False(status.IsReady);
            Assert.Contains("not signed in", status.Detail);
            Assert.Contains(_runner.Calls, call => call.Arguments.SequenceEqual(new[] { "login", "status" }));
        }
    }
}

namespace SmartRetail.AI.Tests
{
    /// <summary>Runs only with a real Codex CLI: set CODEX_TEST_EXECUTABLE to its path (and CODEX_HOME to an empty folder).</summary>
    public sealed class RealCodexFactAttribute : FactAttribute
    {
        public RealCodexFactAttribute()
        {
            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("CODEX_TEST_EXECUTABLE")))
            {
                Skip = "Set CODEX_TEST_EXECUTABLE to a Codex CLI to run this test.";
            }
        }
    }

    public class RealCodexAppServerTests
    {
        [RealCodexFact]
        public async Task The_real_app_server_answers_over_the_process_channel()
        {
            var invocation = new CliInvocation { FileName = Environment.GetEnvironmentVariable("CODEX_TEST_EXECUTABLE"), WorkingDirectory = Path.GetTempPath() };
            invocation.Arguments.Add("app-server");

            using (var server = await CodexAppServer.StartAsync(ProcessJsonLineChannel.Start(invocation), "1.3.1"))
            {
                var signIn = await server.GetSignInAsync();
                var models = await server.ListModelsAsync();

                Assert.False(signIn.SignedIn);
                Assert.NotEmpty(models);
                Assert.All(models, model => Assert.NotEmpty(model.ReasoningEfforts));
                await Assert.ThrowsAsync<CodexAppServerException>(() => server.ReadUsageAsync());
            }
        }
    }
}

namespace SmartRetail.AI.Tests
{
    public class ObservingCliRunnerTests
    {
        private static CliInvocation Run(string file, params string[] arguments)
        {
            var invocation = new CliInvocation { FileName = file };
            invocation.Arguments.AddRange(arguments);
            return invocation;
        }

        [Theory]
        [InlineData(@"C:\Users\shop\AppData\Local\Programs\OpenAI\Codex\bin\codex.exe", "exec", 0, false, true)]
        [InlineData(@"C:\Users\shop\AppData\Roaming\npm\codex.cmd", "exec", 0, false, true)]
        [InlineData("/usr/local/bin/codex", "exec", 1, false, false)]
        [InlineData("/usr/local/bin/codex", "exec", 0, true, false)]
        [InlineData("/usr/local/bin/codex", "login", 0, false, false)]
        [InlineData("/usr/local/bin/claude", "exec", 0, false, false)]
        public void Only_a_codex_task_that_finished_well_counts(string file, string command, int exitCode, bool timedOut, bool expected) =>
            Assert.Equal(expected, ObservingCliRunner.IsCodexAnswer(Run(file, command, "-"), new CliResult { ExitCode = exitCode, TimedOut = timedOut }));

        [Fact]
        public async Task It_passes_every_run_through_and_a_failing_watcher_changes_nothing()
        {
            var inner = new FakeCliRunner { Handler = _ => new CliResult { ExitCode = 0, StandardOutput = "ok" } };
            var seen = 0;
            var runner = new ObservingCliRunner(inner, (invocation, result) => { seen++; throw new InvalidOperationException("watcher broke"); });

            var result = await runner.RunAsync(Run("codex", "exec"), CancellationToken.None);

            Assert.Equal("ok", result.StandardOutput);
            Assert.Equal(1, seen);
            Assert.Single(inner.Calls);
        }
    }
}

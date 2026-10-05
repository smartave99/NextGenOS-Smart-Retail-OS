using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class CliProviderTests : IDisposable
    {
        private static readonly AiRequest Request = new AiRequest { SystemPrompt = "You are the shop assistant.", UserPrompt = "Aaj ki sale kitni hai? ₹" };

        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;
        private readonly SecretStore _secrets;

        public CliProviderTests()
        {
            (_settings, _secrets) = TestSettings.Create();
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
            _settings.ClaudeCli.ExecutablePath = _temp.File("claude-tool");
            _settings.Antigravity.ExecutablePath = _temp.File("agy-tool");
            _settings.CustomCli.ExecutablePath = _temp.File("custom-tool");
        }

        public void Dispose() => _temp.Dispose();

        private string Runs => Path.Combine(_temp.Path, "runs");

        [Fact]
        public async Task Codex_runs_exec_read_only_with_the_prompt_on_stdin_and_returns_the_last_message()
        {
            _runner.Handler = call =>
            {
                File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), "  Aaj ₹12,500 ki sale hui.  ");
                return new CliResult { ExitCode = 0 };
            };
            var codex = new CodexCliProvider(_runner, () => _settings, Runs);

            var response = await codex.CompleteAsync(Request, CancellationToken.None);

            Assert.Equal("Aaj ₹12,500 ki sale hui.", response.Text);
            Assert.Equal(ProviderIds.CodexCli, response.ProviderId);
            var call = _runner.Calls.Single();
            Assert.Equal(_settings.Codex.ExecutablePath, call.FileName);
            Assert.Equal(new[] { "exec", "--skip-git-repo-check", "--ephemeral", "--sandbox", "read-only", "--color", "never" }, call.Arguments.Take(7));
            Assert.Equal(call.WorkingDirectory, FakeCliRunner.ArgumentAfter(call, "--cd"));
            Assert.Equal("-", call.Arguments.Last());
            Assert.Contains("You are the shop assistant.", call.StandardInput);
            Assert.Contains("Aaj ki sale kitni hai? ₹", call.StandardInput);
            Assert.False(Directory.Exists(call.WorkingDirectory), "the per-request folder is cleaned up");
        }

        [Fact]
        public async Task Codex_passes_model_and_reasoning_effort()
        {
            _settings.Codex.Model = "gpt-6-sol";
            _settings.Codex.ReasoningEffort = "Low";
            _runner.Handler = call =>
            {
                File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), "ok");
                return new CliResult();
            };

            await new CodexCliProvider(_runner, () => _settings, Runs).CompleteAsync(Request, CancellationToken.None);

            var call = _runner.Calls.Single();
            Assert.Equal("gpt-6-sol", FakeCliRunner.ArgumentAfter(call, "--model"));
            Assert.Equal("model_reasoning_effort=low", FakeCliRunner.ArgumentAfter(call, "--config"));
        }

        [Theory]
        [InlineData("read-only", "read-only")]
        [InlineData("workspace-write", "workspace-write")]
        [InlineData("danger-full-access", "read-only")]
        [InlineData("", "read-only")]
        public async Task Codex_only_ever_uses_a_confined_sandbox(string configured, string expected)
        {
            _settings.Codex.SandboxMode = configured;
            _runner.Handler = call =>
            {
                File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), "ok");
                return new CliResult();
            };

            await new CodexCliProvider(_runner, () => _settings, Runs).CompleteAsync(Request, CancellationToken.None);

            Assert.Equal(expected, FakeCliRunner.ArgumentAfter(_runner.Calls.Single(), "--sandbox"));
        }

        [Fact]
        public async Task Codex_rejects_a_model_name_with_shell_characters()
        {
            _settings.Codex.Model = "gpt & del *";
            var error = await Assert.ThrowsAsync<AiProviderException>(() => new CodexCliProvider(_runner, () => _settings, Runs).CompleteAsync(Request, CancellationToken.None));
            Assert.False(error.CanFallback);
            Assert.Empty(_runner.Calls);
        }

        [Fact]
        public async Task Codex_explains_how_to_sign_in_when_it_is_not_logged_in()
        {
            _runner.Handler = _ => new CliResult { ExitCode = 1, StandardError = "Error: Not logged in" };
            var error = await Assert.ThrowsAsync<AiProviderException>(() => new CodexCliProvider(_runner, () => _settings, Runs).CompleteAsync(Request, CancellationToken.None));
            Assert.Contains("codex login", error.Message);
            Assert.True(error.CanFallback);
        }

        [Fact]
        public async Task Codex_reports_a_timeout()
        {
            _runner.Handler = _ => new CliResult { ExitCode = -1, TimedOut = true };
            var error = await Assert.ThrowsAsync<AiProviderException>(() => new CodexCliProvider(_runner, () => _settings, Runs).CompleteAsync(Request, CancellationToken.None));
            Assert.Contains("did not answer within 180 seconds", error.Message);
        }

        [Fact]
        public async Task Codex_status_uses_version_and_login_status()
        {
            _runner.Handler = call => call.Arguments[0] == "--version"
                ? new CliResult { StandardOutput = "codex-cli 0.156.1\n" }
                : new CliResult { ExitCode = 0, StandardOutput = "Logged in using ChatGPT\n" };

            var status = await new CodexCliProvider(_runner, () => _settings, Runs).CheckAsync(CancellationToken.None);

            Assert.True(status.IsReady);
            Assert.Equal("codex-cli 0.156.1", status.Version);
            Assert.Equal("Logged in using ChatGPT", status.Detail);
            Assert.Equal(new[] { "login", "status" }, _runner.Calls[1].Arguments);
        }

        [Fact]
        public async Task Codex_status_is_not_ready_when_signed_out_or_missing()
        {
            _runner.Handler = call => call.Arguments[0] == "--version"
                ? new CliResult { StandardOutput = "codex-cli 0.156.1" }
                : new CliResult { ExitCode = 1, StandardError = "Not logged in" };
            Assert.False((await new CodexCliProvider(_runner, () => _settings, Runs).CheckAsync(CancellationToken.None)).IsReady);

            _settings.Codex.ExecutablePath = Path.Combine(_temp.Path, "missing", "codex.exe");
            var missing = await new CodexCliProvider(_runner, () => _settings, Runs).CheckAsync(CancellationToken.None);
            Assert.False(missing.IsReady);
            Assert.Contains("Not found", missing.Detail);
        }

        [Fact]
        public async Task Codex_sign_in_pipes_the_api_key_to_codex_login()
        {
            _runner.Handler = _ => new CliResult { StandardOutput = "Successfully logged in\n" };
            var message = await new CodexCliProvider(_runner, () => _settings, Runs).SignInWithApiKeyAsync(" sk-test ", CancellationToken.None);

            Assert.Equal("Successfully logged in", message);
            Assert.Equal(new[] { "login", "--with-api-key" }, _runner.Calls.Single().Arguments);
            Assert.Equal("sk-test", _runner.Calls.Single().StandardInput);
        }

        [Fact]
        public async Task Claude_requires_an_anthropic_api_key()
        {
            var claude = new ClaudeCliProvider(_runner, () => _settings, _secrets, Runs);
            _runner.Handler = _ => new CliResult { StandardOutput = "2.1.281 (Claude Code)" };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => claude.CompleteAsync(Request, CancellationToken.None));
            Assert.Contains("Anthropic API key", error.Message);
            Assert.False((await claude.CheckAsync(CancellationToken.None)).IsReady);
        }

        [Fact]
        public async Task Claude_runs_bare_with_no_tools_and_the_api_key_in_its_environment()
        {
            _secrets.Set(SecretNames.AnthropicApiKey, "sk-ant-test");
            string systemPromptSeen = null;
            _runner.Handler = call =>
            {
                systemPromptSeen = File.ReadAllText(FakeCliRunner.ArgumentAfter(call, "--system-prompt-file"));
                return new CliResult { StandardOutput = "{\"type\":\"result\",\"subtype\":\"success\",\"is_error\":false,\"result\":\"Namaste! ₹500\",\"total_cost_usd\":0.01}" };
            };

            var response = await new ClaudeCliProvider(_runner, () => _settings, _secrets, Runs).CompleteAsync(Request, CancellationToken.None);

            Assert.Equal("Namaste! ₹500", response.Text);
            var call = _runner.Calls.Single();
            Assert.Equal(new[] { "-p", "--bare", "--output-format", "json", "--tools", "", "--no-session-persistence", "--disable-slash-commands", "--strict-mcp-config" }, call.Arguments.Take(9));
            Assert.Equal("claude-opus-5", FakeCliRunner.ArgumentAfter(call, "--model"));
            Assert.Equal("You are the shop assistant.", systemPromptSeen);
            Assert.Equal(Request.UserPrompt, call.StandardInput);
            Assert.Equal("sk-ant-test", call.Environment["ANTHROPIC_API_KEY"]);
            Assert.True(call.Environment.ContainsKey("CLAUDE_CODE_OAUTH_TOKEN"));
            Assert.Null(call.Environment["CLAUDE_CODE_OAUTH_TOKEN"]);
        }

        [Fact]
        public async Task Claude_surfaces_an_error_result()
        {
            _secrets.Set(SecretNames.AnthropicApiKey, "sk-ant-test");
            _runner.Handler = _ => new CliResult { ExitCode = 1, StandardOutput = "{\"type\":\"result\",\"is_error\":true,\"result\":\"Credit balance is too low\"}" };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => new ClaudeCliProvider(_runner, () => _settings, _secrets, Runs).CompleteAsync(Request, CancellationToken.None));
            Assert.Contains("Credit balance is too low", error.Message);
        }

        [Fact]
        public async Task Antigravity_passes_short_prompts_inline_in_a_sandbox()
        {
            _runner.Handler = _ => new CliResult { StandardOutput = "{\"conversation_id\":\"c1\",\"status\":\"SUCCESS\",\"response\":\"Sales are up.\\n\",\"num_turns\":1}" };

            var response = await new AntigravityCliProvider(_runner, () => _settings, _secrets, Runs).CompleteAsync(Request, CancellationToken.None);

            Assert.Equal("Sales are up.", response.Text);
            var call = _runner.Calls.Single();
            Assert.Equal("-p", call.Arguments[0]);
            Assert.Contains("Aaj ki sale kitni hai?", call.Arguments[1]);
            Assert.Contains("You are the shop assistant.", call.Arguments[1]);
            Assert.Equal("json", FakeCliRunner.ArgumentAfter(call, "--output-format"));
            Assert.Contains("--sandbox", call.Arguments);
            Assert.Equal("180s", FakeCliRunner.ArgumentAfter(call, "--print-timeout"));
            Assert.False(call.Environment.ContainsKey("GEMINI_API_KEY"));
        }

        [Fact]
        public async Task Antigravity_hands_long_prompts_over_in_a_file()
        {
            var longRequest = new AiRequest { SystemPrompt = "sys", UserPrompt = new string('x', AntigravityCliProvider.MaxInlinePromptLength + 10) };
            string fileContent = null;
            _runner.Handler = call =>
            {
                fileContent = File.ReadAllText(Path.Combine(call.WorkingDirectory, AntigravityCliProvider.PromptFile));
                return new CliResult { StandardOutput = "{\"status\":\"SUCCESS\",\"response\":\"done\"}" };
            };

            await new AntigravityCliProvider(_runner, () => _settings, _secrets, Runs).CompleteAsync(longRequest, CancellationToken.None);

            Assert.Equal(AntigravityCliProvider.FileHandOffPrompt, _runner.Calls.Single().Arguments[1]);
            Assert.Contains(longRequest.UserPrompt, fileContent);
        }

        [Fact]
        public async Task Antigravity_can_use_the_gemini_api_key_and_reports_errors()
        {
            _settings.Antigravity.UseGeminiApiKey = true;
            _secrets.Set(SecretNames.GeminiApiKey, "gm-key");
            _runner.Handler = _ => new CliResult { ExitCode = 1, StandardOutput = "{\"status\":\"ERROR\",\"error\":{\"message\":\"quota exceeded\"}}" };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => new AntigravityCliProvider(_runner, () => _settings, _secrets, Runs).CompleteAsync(Request, CancellationToken.None));

            Assert.Contains("quota exceeded", error.Message);
            Assert.Equal("gm-key", _runner.Calls.Single().Environment["GEMINI_API_KEY"]);
        }

        [Fact]
        public async Task Custom_cli_fills_placeholders_and_reads_a_json_field()
        {
            _settings.CustomCli.Arguments = "run {model} --prompt-file \"{prompt_file}\"";
            _settings.CustomCli.Model = "llama3.1";
            _settings.CustomCli.PromptViaStdin = false;
            _settings.CustomCli.JsonResultField = "message.content";
            _runner.Handler = call => new CliResult { StandardOutput = "{\"message\":{\"content\":\"Local answer\"}}" };

            var response = await new CustomCliProvider(_runner, () => _settings, Runs).CompleteAsync(Request, CancellationToken.None);

            Assert.Equal("Local answer", response.Text);
            var call = _runner.Calls.Single();
            Assert.Equal("run", call.Arguments[0]);
            Assert.Equal("llama3.1", call.Arguments[1]);
            Assert.EndsWith(CustomCliProvider.PromptFile, call.Arguments[3]);
            Assert.Null(call.StandardInput);
        }

        [Fact]
        public async Task Custom_cli_is_not_ready_until_a_program_is_set()
        {
            _settings.CustomCli.ExecutablePath = "";
            var status = await new CustomCliProvider(_runner, () => _settings, Runs).CheckAsync(CancellationToken.None);
            Assert.False(status.IsReady);
        }
    }
}

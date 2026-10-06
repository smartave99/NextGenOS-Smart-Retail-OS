using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>The models, thinking levels, version and update of Claude Code and Antigravity, without the real tools or the internet.</summary>
    public sealed class CliToolCareTests : IDisposable
    {
        private readonly string _folder = Path.Combine(Path.GetTempPath(), "cli-care-" + Guid.NewGuid().ToString("N"));
        private readonly AssistantSettings _settings;
        private readonly SecretStore _secrets;
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly StubHttpHandler _http = new StubHttpHandler();
        private readonly string _claude;

        public CliToolCareTests()
        {
            (_settings, _secrets) = TestSettings.Create();
            Directory.CreateDirectory(_folder);
            _claude = Path.Combine(_folder, "claude");
            File.WriteAllText(_claude, "stand-in");
            _settings.ClaudeCli.ExecutablePath = _claude;
        }

        public void Dispose()
        {
            try { Directory.Delete(_folder, true); } catch (IOException) { }
        }

        private CliToolCare Care(string registry = null) => new CliToolCare(_runner, () => _settings, _secrets, new HttpClient(_http), registry ?? "https://registry.example/claude/latest");

        private static string Model(string id, string name, params string[] levels)
        {
            var effort = levels.Length == 0
                ? @"{""supported"":false}"
                : @"{""supported"":true," + string.Join(",", new[] { "low", "medium", "high", "xhigh", "max" }.Select(l => @"""" + l + @""":{""supported"":" + (levels.Contains(l) ? "true" : "false") + "}")) + "}";
            return @"{""id"":""" + id + @""",""display_name"":""" + name + @""",""capabilities"":{""effort"":" + effort + "}}";
        }

        [Fact]
        public async Task Without_a_key_Claudes_list_is_the_built_in_one_with_every_level_and_it_says_so()
        {
            var list = await Care().ModelsAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.Equal("built-in", list.Source);
            Assert.Contains("no Anthropic key", list.Note);
            Assert.Equal(new[] { "fable", "opus", "sonnet" }, list.Models.Take(3).Select(m => m.Id));
            var opus = list.Models.Single(m => m.Id == "claude-opus-5-5");
            Assert.Equal(new[] { "low", "medium", "high", "xhigh", "max" }, opus.Efforts);
            Assert.Equal(new[] { "low", "medium", "high", "max" }, list.Models.Single(m => m.Id == "claude-opus-4-6").Efforts);
            Assert.Empty(list.Models.Single(m => m.Id == "claude-haiku-4-5").Efforts);
            Assert.Empty(_http.Requests);
        }

        [Fact]
        public async Task With_a_key_the_list_is_Anthropics_own_for_that_key_with_each_models_levels()
        {
            _secrets.Set(SecretNames.AnthropicApiKey, "sk-ant-test");
            _http.Respond(HttpStatusCode.OK, @"{""data"":[" + Model("claude-opus-5-5", "Claude Opus 5.5", "low", "medium", "high", "xhigh", "max") + "," + Model("claude-haiku-4-5", "Claude Haiku 4.5") + @"],""has_more"":true,""last_id"":""claude-haiku-4-5""}")
                .Respond(HttpStatusCode.OK, @"{""data"":[" + Model("claude-sonnet-4-6", "Claude Sonnet 4.6", "low", "medium", "high", "max") + @"],""has_more"":false}");

            var list = await Care().ModelsAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.Equal("anthropic", list.Source);
            Assert.Equal(new[] { "fable", "opus", "sonnet", "claude-opus-5-5", "claude-haiku-4-5", "claude-sonnet-4-6" }, list.Models.Select(m => m.Id));
            Assert.Equal(new[] { "low", "medium", "high", "max" }, list.Models.Single(m => m.Id == "claude-sonnet-4-6").Efforts);
            Assert.Empty(list.Models.Single(m => m.Id == "claude-haiku-4-5").Efforts);
            Assert.Equal(2, _http.Requests.Count);
            var first = _http.Requests[0].Request;
            Assert.Equal("https://api.anthropic.com/v1/models?limit=100", first.RequestUri.ToString());
            Assert.Equal("sk-ant-test", first.Headers.GetValues("x-api-key").Single());
            Assert.Equal("2023-06-01", first.Headers.GetValues("anthropic-version").Single());
            Assert.Contains("after_id=claude-haiku-4-5", _http.Requests[1].Request.RequestUri.Query);
        }

        [Fact]
        public async Task The_Anthropic_API_provider_list_has_no_Claude_Code_short_names()
        {
            _secrets.Set(SecretNames.AnthropicApiKey, "sk-ant-test");
            _http.Respond(HttpStatusCode.OK, @"{""data"":[" + Model("claude-opus-5-5", "Claude Opus 5.5", "low", "high") + @"],""has_more"":false}");

            var list = await Care().ModelsAsync(ProviderIds.AnthropicApi, CancellationToken.None);

            Assert.Equal(new[] { "claude-opus-5-5" }, list.Models.Select(m => m.Id));
        }

        [Theory]
        [InlineData(HttpStatusCode.Unauthorized, "did not accept the key")]
        [InlineData(HttpStatusCode.TooManyRequests, "too many requests")]
        public async Task When_Anthropic_refuses_the_built_in_list_is_shown_and_the_reason_is_in_words(HttpStatusCode status, string words)
        {
            _secrets.Set(SecretNames.AnthropicApiKey, "sk-ant-test");
            _http.Respond(status, @"{""error"":{""type"":""x""}}");

            var list = await Care().ModelsAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.Equal("built-in", list.Source);
            Assert.Contains(words, list.Note);
            Assert.NotEmpty(list.Models);
        }

        [Fact]
        public async Task A_service_address_that_is_not_https_is_never_used_for_the_key()
        {
            _secrets.Set(SecretNames.AnthropicApiKey, "sk-ant-test");
            _settings.Anthropic.BaseUrl = "http://evil.example";
            _http.Respond(HttpStatusCode.OK, @"{""data"":[],""has_more"":false}");

            await Care().ModelsAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.StartsWith("https://api.anthropic.com/", _http.Requests.Single().Request.RequestUri.ToString());
        }

        private string Agy()
        {
            var agy = Path.Combine(_folder, "agy");
            File.WriteAllText(agy, "stand-in");
            _settings.Antigravity.ExecutablePath = agy;
            return agy;
        }

        [Fact]
        public async Task Antigravitys_list_is_what_agy_models_prints_with_the_levels_it_takes_and_headings_are_not_models()
        {
            Agy();
            _runner.Handler = _ => new CliResult { StandardOutput = "Available models:\n  gemini-3.5-pro  (most capable)\n- gemini-3.5-flash\n\n* gemini-3.5-pro\nusage: agy models\n" };

            var list = await Care().ModelsAsync(ProviderIds.AntigravityCli, CancellationToken.None);

            Assert.Equal("tool", list.Source);
            Assert.Equal(new[] { "gemini-3.5-pro", "gemini-3.5-flash" }, list.Models.Select(m => m.Id));
            Assert.Equal("gemini-3.5-pro: most capable", list.Models[0].Label);
            Assert.All(list.Models, m => Assert.Equal(new[] { "low", "medium", "high" }, m.Efforts));
            Assert.Equal(new[] { "models" }, _runner.Calls.Single().Arguments);
        }

        [Fact]
        public async Task When_agy_cannot_be_asked_Antigravity_has_no_list_and_says_so_and_still_offers_its_levels()
        {
            Agy();
            _runner.Handler = _ => new CliResult { ExitCode = 2, StandardError = "unknown command" };
            var failed = await Care().ModelsAsync(ProviderIds.AntigravityCli, CancellationToken.None);
            Assert.Equal("none", failed.Source);
            Assert.Empty(failed.Models);
            Assert.Equal(new[] { "low", "medium", "high" }, failed.DefaultEfforts);
            Assert.Contains("type the model name", failed.Note);

            _runner.Handler = _ => new CliResult { StandardOutput = "Models\n\n" };
            Assert.Equal("none", (await Care().ModelsAsync(ProviderIds.AntigravityCli, CancellationToken.None)).Source);

            _settings.Antigravity.ExecutablePath = Path.Combine(_folder, "not-there");
            var missing = await Care().ModelsAsync(ProviderIds.AntigravityCli, CancellationToken.None);
            Assert.Contains("not on this PC", missing.Note);
        }

        [Fact]
        public async Task The_version_is_read_from_what_the_tool_says_and_a_missing_tool_gets_install_words()
        {
            _runner.Handler = _ => new CliResult { StandardOutput = "2.1.289 (Claude Code)\n" };
            var found = await Care().StatusAsync(ProviderIds.ClaudeCli, CancellationToken.None);
            Assert.True(found.Found);
            Assert.Equal("2.1.289", found.Version);
            Assert.Equal(new[] { "--version" }, _runner.Calls.Single().Arguments);

            _settings.ClaudeCli.ExecutablePath = Path.Combine(_folder, "not-there");
            var missing = await Care().StatusAsync(ProviderIds.ClaudeCli, CancellationToken.None);
            Assert.False(missing.Found);
            Assert.Contains("claude.ai/install.ps1", missing.InstallHint);
        }

        [Theory]
        [InlineData("2.1.289", "2.2.0", "available")]
        [InlineData("2.2.0", "2.2.0", "current")]
        [InlineData("2.3.1", "2.2.0", "current")]
        public async Task A_newer_Claude_Code_is_found_by_comparing_with_npm(string installed, string latest, string expected)
        {
            _runner.Handler = _ => new CliResult { StandardOutput = installed + " (Claude Code)" };
            _http.Respond(HttpStatusCode.OK, @"{""name"":""@anthropic-ai/claude-code"",""version"":""" + latest + @"""}");

            var check = await Care().CheckUpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.Equal(expected, check.Update);
            Assert.Equal(latest, check.Latest);
            Assert.True(check.CanUpdate);
            Assert.Contains("claude update", check.How);
        }

        [Fact]
        public async Task When_the_newest_version_cannot_be_found_out_the_answer_is_unknown_not_current()
        {
            _runner.Handler = _ => new CliResult { StandardOutput = "2.1.289" };
            _http.Respond(HttpStatusCode.ServiceUnavailable, "{}");

            var check = await Care().CheckUpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.Equal("unknown", check.Update);
            Assert.Equal("", check.Latest);
        }

        [Fact]
        public async Task A_registry_address_that_is_not_https_is_not_asked()
        {
            _runner.Handler = _ => new CliResult { StandardOutput = "2.1.289" };

            var check = await Care("http://registry.example/latest").CheckUpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.Equal("unknown", check.Update);
            Assert.Empty(_http.Requests);
        }

        [Fact]
        public async Task A_tool_that_is_not_installed_is_told_to_be_installed_not_updated()
        {
            _settings.ClaudeCli.ExecutablePath = Path.Combine(_folder, "not-there");

            var check = await Care().CheckUpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.Equal("install", check.Update);
            Assert.False(check.CanUpdate);
        }

        [Fact]
        public async Task Updating_Claude_Code_runs_its_own_updater_and_proves_it_by_asking_the_version_again()
        {
            var version = "2.1.289";
            _runner.Handler = invocation =>
            {
                if (invocation.Arguments.SequenceEqual(new[] { "update" }))
                {
                    version = "2.2.0";
                    return new CliResult { StandardOutput = "Updated.\n" };
                }

                return new CliResult { StandardOutput = version };
            };

            var result = await Care().UpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.Equal("2.1.289", result.Before);
            Assert.Equal("2.2.0", result.After);
            Assert.True(result.Changed);
            Assert.Equal(new[] { "--version", "update", "--version" }, _runner.Calls.Select(c => string.Join(" ", c.Arguments)));
            Assert.Equal(_claude, _runner.Calls[1].FileName);
        }

        [Fact]
        public async Task An_update_that_leaves_the_version_as_it_was_is_reported_as_unchanged_not_as_a_success()
        {
            _runner.Handler = invocation => new CliResult { StandardOutput = "2.1.289" };

            var result = await Care().UpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);

            Assert.False(result.Changed);
        }

        [Fact]
        public async Task An_update_that_fails_or_runs_too_long_says_so_in_words()
        {
            _runner.Handler = invocation => invocation.Arguments.Contains("update") ? new CliResult { ExitCode = 3, StandardError = "disk is full" } : new CliResult { StandardOutput = "2.1.289" };
            var failed = await Assert.ThrowsAsync<CliToolException>(() => Care().UpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None));
            Assert.Contains("code 3", failed.Message);
            Assert.Contains("disk is full", failed.Message);

            _runner.Handler = invocation => invocation.Arguments.Contains("update") ? new CliResult { TimedOut = true } : new CliResult { StandardOutput = "2.1.289" };
            var slow = await Assert.ThrowsAsync<CliToolException>(() => Care().UpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None));
            Assert.Contains("took too long", slow.Message);
        }

        [Fact]
        public async Task Antigravity_is_updated_only_where_a_safe_way_is_known_and_a_missing_tool_is_never_updated()
        {
            var agy = Path.Combine(_folder, "agy");
            File.WriteAllText(agy, "stand-in");
            _settings.Antigravity.ExecutablePath = agy;
            _runner.Handler = _ => new CliResult { StandardOutput = "0.9.1" };

            var check = await Care().CheckUpdateAsync(ProviderIds.AntigravityCli, CancellationToken.None);
            Assert.Equal("unknown", check.Update);
            Assert.Equal(ExecutableLocator.IsWindows, check.CanUpdate);
            if (ExecutableLocator.IsWindows)
            {
                Assert.Contains("antigravity.google/cli/install.ps1", check.How);
            }
            else
            {
                await Assert.ThrowsAsync<CliToolException>(() => Care().UpdateAsync(ProviderIds.AntigravityCli, CancellationToken.None));
            }

            _settings.Antigravity.ExecutablePath = Path.Combine(_folder, "not-there");
            Assert.Equal("install", (await Care().CheckUpdateAsync(ProviderIds.AntigravityCli, CancellationToken.None)).Update);
        }

        [Fact]
        public async Task Only_Claude_Code_and_Antigravity_are_looked_after_here()
        {
            await Assert.ThrowsAsync<CliToolException>(() => Care().StatusAsync(ProviderIds.CodexCli, CancellationToken.None));
            await Assert.ThrowsAsync<CliToolException>(() => Care().ModelsAsync(ProviderIds.OpenAiApi, CancellationToken.None));
        }

        [Theory]
        [InlineData("2.10.0", "2.9.9", true)]
        [InlineData("2.9.9", "2.10.0", false)]
        [InlineData("2.0.0", "2.0.0", false)]
        [InlineData("3.0", "2.9.9", true)]
        public void Versions_are_compared_by_their_numbers_not_their_letters(string a, string b, bool newer)
        {
            Assert.Equal(newer, CliToolCare.IsNewer(a, b));
        }
    }
}

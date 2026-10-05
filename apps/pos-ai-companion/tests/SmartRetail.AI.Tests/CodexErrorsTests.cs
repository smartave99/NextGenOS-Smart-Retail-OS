using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Codex's errors, in a few plain words: never the prompt it echoes, each error once, a usage limit as one sentence.</summary>
    public class CodexErrorsTests : IDisposable
    {
        /// <summary>What codex exec wrote when the account hit its limit: the end of the prompt it echoes, then the error twice.</summary>
        internal const string UsageLimitOutput =
            "…ing text.\n- Amounts are Indian Rupees. The Indian financial year runs from 1 April to 31 March.\n\nQuestion: How did sales go today?\n"
            + "ERROR: You’ve hit your usage limit. Upgrade to Pro (https://chatgpt.com/explore/pro), visit https://chatgpt.com/codex/settings/usage to purchase more credits or try again at 7:33 PM.\n"
            + "ERROR: You’ve hit your usage limit. Upgrade to Pro (https://chatgpt.com/explore/pro), visit https://chatgpt.com/codex/settings/usage to purchase more credits or try again at 7:33 PM.\n";

        private const string Limit = "Codex has reached its usage limit. It can answer again at 7:33 PM. For more now, see chatgpt.com/codex/settings/usage.";

        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;

        public CodexErrorsTests()
        {
            _settings = TestSettings.Create().Settings;
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
        }

        public void Dispose() => _temp.Dispose();

        private CodexCliProvider Codex() => new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs"))
        {
            // No app server here: questions go through codex exec.
            StartChannel = _ => throw new CliStartException("Could not start codex app-server", null),
        };

        [Fact]
        public void A_usage_limit_is_one_sentence_that_says_when_Codex_can_answer_again()
        {
            Assert.Equal(Limit, CodexErrors.UsageLimitIn(UsageLimitOutput));
            Assert.Single(CodexErrors.Errors(UsageLimitOutput));
            Assert.DoesNotContain("Question:", CodexErrors.Short(UsageLimitOutput));
        }

        [Fact]
        public void Windows_line_endings_are_read_the_same()
        {
            var windows = UsageLimitOutput.Replace("\n", "\r\n");

            Assert.Equal(Limit, CodexErrors.UsageLimitIn(windows));
            Assert.Equal(new[] { "stream disconnected before completion" }, CodexErrors.Errors("Question: why?\r\nERROR: stream disconnected before completion\r\nERROR: stream disconnected before completion\r\n"));
            Assert.DoesNotContain("Question:", CodexErrors.Short(windows));
        }

        [Theory]
        [InlineData("You've hit your usage limit. Try again in 2 hours.", "Codex has reached its usage limit. It can answer again in 2 hours. For more now, see chatgpt.com/codex/settings/usage.")]
        [InlineData("You've hit your usage limit.", "Codex has reached its usage limit. It can answer again later. For more now, see chatgpt.com/codex/settings/usage.")]
        [InlineData("stream disconnected before completion", null)]
        [InlineData("", null)]
        public void Only_a_usage_limit_is_read_as_one(string error, string expected) => Assert.Equal(expected, CodexErrors.UsageLimit(error));

        [Fact]
        public void Words_in_the_echoed_prompt_are_never_taken_for_Codexs_error()
        {
            // The owner asked about a usage limit; Codex failed for another reason.
            var output = "Question: what is the usage limit on my card?\nERROR: stream disconnected before completion\n";

            Assert.Null(CodexErrors.UsageLimitIn(output));
            Assert.Equal("stream disconnected before completion", CodexErrors.Short(output));
            Assert.Equal("", CodexErrors.Short("Question: why?\nno error lines here"));
            Assert.EndsWith("…", CodexErrors.Short("ERROR: " + new string('x', 400)));
        }

        [Fact]
        public async Task A_usage_limit_from_codex_exec_is_shown_in_plain_words()
        {
            _runner.Handler = _ => new CliResult { ExitCode = 1, StandardError = UsageLimitOutput };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().CompleteAsync(new AiRequest { UserPrompt = "How did sales go today?" }, CancellationToken.None));

            Assert.Equal(Limit, error.Message);
            Assert.True(error.CanFallback, "another AI tool may still answer");
        }

        [Fact]
        public async Task Another_error_shows_Codexs_own_words_never_the_prompt()
        {
            // "sign in" in the echoed prompt is the owner's question, not a sign-in problem.
            _runner.Handler = _ => new CliResult { ExitCode = 1, StandardError = "Question: why can the cashier not sign in?\nERROR: stream disconnected before completion\nERROR: stream disconnected before completion\n" };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().CompleteAsync(new AiRequest { UserPrompt = "Q" }, CancellationToken.None));

            Assert.Equal("Codex CLI (OpenAI) failed (exit code 1): stream disconnected before completion", error.Message);
        }

        [Fact]
        public async Task A_usage_limit_from_the_app_server_is_not_asked_again_the_usual_way()
        {
            var fake = new FakeAppServer { Chatty = false };
            fake.Answers["thread/start"] = _ => JObject.Parse("{\"thread\":{\"id\":\"th-1\"},\"model\":\"gpt-6-sol\"}");
            fake.Answers["turn/start"] = _ =>
            {
                fake.Say("{\"method\":\"turn/completed\",\"params\":{\"threadId\":\"th-1\",\"turn\":{\"id\":\"tu-1\",\"status\":\"failed\",\"error\":{\"message\":\"You've hit your usage limit. Upgrade to Pro (https://chatgpt.com/explore/pro) or try again at 7:33 PM.\"}}}}");
                return JObject.Parse("{\"turn\":{\"id\":\"tu-1\",\"status\":\"inProgress\"}}");
            };
            var codex = new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs")) { StartChannel = _ => fake };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => codex.CompleteAsync(new AiRequest { UserPrompt = "Q", OnText = _ => { } }, CancellationToken.None));

            Assert.Equal(Limit, error.Message);
            Assert.Empty(_runner.Calls);
        }
    }
}

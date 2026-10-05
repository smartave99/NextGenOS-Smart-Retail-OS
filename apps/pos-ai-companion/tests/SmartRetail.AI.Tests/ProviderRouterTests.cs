using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class ProviderRouterTests
    {
        private readonly AssistantSettings _settings = TestSettings.Create().Settings;
        private readonly FakeProvider _codex = new FakeProvider(ProviderIds.CodexCli);
        private readonly FakeProvider _claude = new FakeProvider(ProviderIds.ClaudeCli);
        private readonly FakeProvider _gemini = new FakeProvider(ProviderIds.GeminiApi);

        private ProviderRouter Router => new ProviderRouter(new IAiProvider[] { _claude, _gemini, _codex }, () => _settings);

        private static AiRequest Request => new AiRequest { UserPrompt = "hi" };

        [Fact]
        public async Task Auto_uses_the_configured_order_with_codex_first_by_default()
        {
            var response = await Router.CompleteAsync(Request, ProviderIds.Auto, CancellationToken.None);
            Assert.Equal(ProviderIds.CodexCli, response.ProviderId);
        }

        [Fact]
        public async Task The_preferred_provider_goes_first_in_auto_mode()
        {
            _settings.PreferredProvider = ProviderIds.GeminiApi;
            var router = Router;

            Assert.Equal(ProviderIds.GeminiApi, router.PlanOrder(ProviderIds.Auto).First().Id);
            Assert.Equal(ProviderIds.GeminiApi, (await router.CompleteAsync(Request, ProviderIds.Auto, CancellationToken.None)).ProviderId);
            Assert.Equal(router.PlanOrder(ProviderIds.Auto).Count, router.PlanOrder(ProviderIds.Auto).Select(p => p.Id).Distinct().Count());
        }

        [Fact]
        public async Task Auto_skips_providers_that_are_not_ready()
        {
            _codex.Ready = false;
            var response = await Router.CompleteAsync(Request, ProviderIds.Auto, CancellationToken.None);
            Assert.Equal(ProviderIds.ClaudeCli, response.ProviderId);
            Assert.Empty(_codex.Requests);
        }

        [Fact]
        public async Task Auto_falls_back_after_a_failure_when_allowed()
        {
            _codex.Failure = new AiProviderException(ProviderIds.CodexCli, "quota reached");
            var response = await Router.CompleteAsync(Request, ProviderIds.Auto, CancellationToken.None);
            Assert.Equal(ProviderIds.ClaudeCli, response.ProviderId);
        }

        [Fact]
        public async Task Auto_does_not_fall_back_when_fallback_is_off()
        {
            _settings.FallbackToOtherProviders = false;
            _codex.Failure = new AiProviderException(ProviderIds.CodexCli, "quota reached");
            var error = await Assert.ThrowsAsync<AiProviderException>(() => Router.CompleteAsync(Request, ProviderIds.Auto, CancellationToken.None));
            Assert.Equal("quota reached", error.Message);
            Assert.Empty(_claude.Requests);
        }

        [Fact]
        public async Task An_explicit_choice_never_switches_provider()
        {
            _claude.Ready = false;
            var notReady = await Assert.ThrowsAsync<AiProviderException>(() => Router.CompleteAsync(Request, ProviderIds.ClaudeCli, CancellationToken.None));
            Assert.Contains("not ready", notReady.Message);

            _gemini.Failure = new AiProviderException(ProviderIds.GeminiApi, "boom");
            await Assert.ThrowsAsync<AiProviderException>(() => Router.CompleteAsync(Request, ProviderIds.GeminiApi, CancellationToken.None));
            Assert.Empty(_codex.Requests);
        }

        [Fact]
        public async Task When_the_one_tool_asked_fails_its_own_words_are_the_answer()
        {
            _codex.Ready = false;
            _claude.Failure = new AiProviderException(ProviderIds.ClaudeCli, "Codex has reached its usage limit. It can answer again at 7:33 PM.");
            _gemini.Ready = false;

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Router.CompleteAsync(Request, ProviderIds.Auto, CancellationToken.None));

            // The tools never set up are not listed: they were not what went wrong.
            Assert.Equal("Codex has reached its usage limit. It can answer again at 7:33 PM.", error.Message);
            Assert.Equal(ProviderIds.ClaudeCli, error.ProviderId);
        }

        [Fact]
        public async Task When_several_tools_fail_each_says_what_went_wrong_once()
        {
            _codex.Failure = new AiProviderException(ProviderIds.CodexCli, "Fake codex-cli failed (exit code 1): stream disconnected");
            _claude.Failure = new AiProviderException(ProviderIds.ClaudeCli, "no key");
            _gemini.Ready = false;

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Router.CompleteAsync(Request, ProviderIds.Auto, CancellationToken.None));

            Assert.Equal("No AI tool could answer." + Environment.NewLine
                + "• Fake codex-cli failed (exit code 1): stream disconnected" + Environment.NewLine
                + "• Fake claude-cli: no key", error.Message);
        }

        [Fact]
        public async Task When_no_tool_is_ready_the_error_says_how_each_stands()
        {
            _codex.Ready = false;
            _claude.Ready = false;
            _gemini.Ready = false;

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Router.CompleteAsync(Request, ProviderIds.Auto, CancellationToken.None));

            Assert.StartsWith("No AI tool is ready to answer.", error.Message);
            Assert.Contains("Fake codex-cli: not ready", error.Message);
            Assert.Contains("Fake claude-cli: not ready", error.Message);
        }
    }
}

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class ApiProviderTests
    {
        private static readonly AiRequest Request = new AiRequest { SystemPrompt = "Be brief.", UserPrompt = "Sales today?" };

        private readonly AssistantSettings _settings;
        private readonly SecretStore _secrets;
        private readonly StubHttpHandler _http = new StubHttpHandler();

        public ApiProviderTests()
        {
            (_settings, _secrets) = TestSettings.Create();
        }

        private HttpClient Client => new HttpClient(_http);

        [Fact]
        public async Task OpenAi_calls_the_responses_api_without_storing_and_reads_output_text()
        {
            _secrets.Set(SecretNames.OpenAiApiKey, "sk-openai");
            _http.Respond(HttpStatusCode.OK, @"{""status"":""completed"",""output"":[
                {""type"":""reasoning"",""summary"":[]},
                {""type"":""message"",""role"":""assistant"",""content"":[{""type"":""output_text"",""text"":""₹12,500 across 18 bills.""}]}]}");

            var response = await new OpenAiApiProvider(Client, () => _settings, _secrets).CompleteAsync(Request, CancellationToken.None);

            Assert.Equal("₹12,500 across 18 bills.", response.Text);
            var (request, body) = _http.Requests.Single();
            Assert.Equal("https://api.openai.com/v1/responses", request.RequestUri.ToString());
            Assert.Equal("Bearer sk-openai", request.Headers.Authorization.ToString());
            var json = JObject.Parse(body);
            Assert.Equal("gpt-6-sol", (string)json["model"]);
            Assert.Equal("Be brief.", (string)json["instructions"]);
            Assert.Equal("Sales today?", (string)json["input"]);
            Assert.False((bool)json["store"]);
        }

        [Fact]
        public async Task OpenAi_reports_a_rejected_key_clearly()
        {
            _secrets.Set(SecretNames.OpenAiApiKey, "sk-bad");
            _http.Respond(HttpStatusCode.Unauthorized, @"{""error"":{""message"":""Incorrect API key provided""}}");

            var error = await Assert.ThrowsAsync<AiProviderException>(() => new OpenAiApiProvider(Client, () => _settings, _secrets).CompleteAsync(Request, CancellationToken.None));

            Assert.Contains("rejected the API key", error.Message);
            Assert.Contains("Incorrect API key provided", error.Message);
        }

        [Fact]
        public async Task Api_calls_retry_after_a_rate_limit()
        {
            _secrets.Set(SecretNames.OpenAiApiKey, "sk-openai");
            _http.Respond((HttpStatusCode)429, @"{""error"":{""message"":""slow down""}}", r => r.Headers.RetryAfter = new System.Net.Http.Headers.RetryConditionHeaderValue(TimeSpan.FromMilliseconds(200)))
                 .Respond(HttpStatusCode.OK, @"{""output"":[{""type"":""message"",""content"":[{""type"":""output_text"",""text"":""ok""}]}]}");

            var response = await new OpenAiApiProvider(Client, () => _settings, _secrets).CompleteAsync(Request, CancellationToken.None);

            Assert.Equal("ok", response.Text);
            Assert.Equal(2, _http.Requests.Count);
        }

        [Fact]
        public async Task Gemini_sends_the_system_instruction_and_skips_thought_parts()
        {
            _secrets.Set(SecretNames.GeminiApiKey, "gm-key");
            _http.Respond(HttpStatusCode.OK, @"{""candidates"":[{""content"":{""parts"":[{""text"":""thinking…"",""thought"":true},{""text"":""Sales were good.""}]},""finishReason"":""STOP""}]}");

            var response = await new GeminiApiProvider(Client, () => _settings, _secrets).CompleteAsync(Request, CancellationToken.None);

            Assert.Equal("Sales were good.", response.Text);
            var (request, body) = _http.Requests.Single();
            Assert.Equal("https://generativelanguage.googleapis.com/v1beta/models/gemini-3.5-flash:generateContent", request.RequestUri.ToString());
            Assert.Equal("gm-key", request.Headers.GetValues("x-goog-api-key").Single());
            var json = JObject.Parse(body);
            Assert.Equal("Be brief.", (string)json.SelectToken("systemInstruction.parts[0].text"));
            Assert.Equal("Sales today?", (string)json.SelectToken("contents[0].parts[0].text"));
        }

        [Fact]
        public async Task Gemini_reports_a_blocked_prompt()
        {
            _secrets.Set(SecretNames.GeminiApiKey, "gm-key");
            _http.Respond(HttpStatusCode.OK, @"{""promptFeedback"":{""blockReason"":""SAFETY""}}");

            var error = await Assert.ThrowsAsync<AiProviderException>(() => new GeminiApiProvider(Client, () => _settings, _secrets).CompleteAsync(Request, CancellationToken.None));
            Assert.Contains("SAFETY", error.Message);
        }

        [Fact]
        public async Task Compatible_servers_use_chat_completions_and_need_no_key()
        {
            _settings.OpenAiCompatible.Model = "llama3.1";
            _http.Respond(HttpStatusCode.OK, @"{""choices"":[{""message"":{""role"":""assistant"",""content"":""Local answer""}}]}");
            var provider = new OpenAiCompatibleApiProvider(Client, () => _settings, _secrets);

            Assert.True((await provider.CheckAsync(CancellationToken.None)).IsReady);
            var response = await provider.CompleteAsync(Request, CancellationToken.None);

            Assert.Equal("Local answer", response.Text);
            var (request, body) = _http.Requests.Single();
            Assert.Equal("http://localhost:11434/v1/chat/completions", request.RequestUri.ToString());
            Assert.Null(request.Headers.Authorization);
            Assert.Equal("system", (string)JObject.Parse(body).SelectToken("messages[0].role"));
        }

        [Fact]
        public async Task Api_providers_are_not_ready_without_a_key()
        {
            Assert.False((await new OpenAiApiProvider(Client, () => _settings, _secrets).CheckAsync(CancellationToken.None)).IsReady);
            Assert.False((await new GeminiApiProvider(Client, () => _settings, _secrets).CheckAsync(CancellationToken.None)).IsReady);
            Assert.False((await new AnthropicApiProvider(() => _settings, _secrets).CheckAsync(CancellationToken.None)).IsReady);

            _secrets.Set(SecretNames.AnthropicApiKey, "sk-ant");
            var status = await new AnthropicApiProvider(() => _settings, _secrets).CheckAsync(CancellationToken.None);
            Assert.True(status.IsReady);
            Assert.Contains("claude-opus-5", status.Detail);
        }

        [Theory]
        [InlineData("claude-opus-5", true, true)]
        [InlineData("claude-fable-5-1", true, true)]
        [InlineData("claude-sonnet-5", false, true)]
        [InlineData("claude-opus-4-8", false, true)]
        [InlineData("claude-haiku-4-5", false, false)]
        public void Anthropic_request_options_match_the_model(string model, bool fallback, bool adaptive)
        {
            Assert.Equal(fallback, AnthropicApiProvider.SupportsServerSideFallback(model));
            Assert.Equal(adaptive, AnthropicApiProvider.SupportsAdaptiveThinking(model));
            Assert.NotNull(AnthropicApiProvider.BuildParameters(model, Request));
        }
    }
}

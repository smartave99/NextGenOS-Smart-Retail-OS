using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>Any server that speaks the OpenAI chat-completions format: a local Ollama or LM Studio,
    /// OpenRouter, Groq and similar. The API key is optional because local servers need none.</summary>
    public sealed class OpenAiCompatibleApiProvider : HttpApiProviderBase
    {
        public OpenAiCompatibleApiProvider(HttpClient http, Func<AssistantSettings> settings, SecretStore secrets)
            : base(http, settings, secrets)
        {
        }

        public override string Id => ProviderIds.OpenAiCompatibleApi;

        public override string DisplayName => "OpenAI-compatible API";

        protected override ApiProviderSettings ProviderSettings => Settings().OpenAiCompatible;

        protected override string SecretName => SecretNames.OpenAiCompatibleApiKey;

        protected override bool RequiresApiKey => false;

        public override Task<ProviderStatus> CheckAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(ProviderSettings.BaseUrl))
            {
                return Task.FromResult(ProviderStatus.NotReady("No server address set (Settings → API keys)."));
            }

            return base.CheckAsync(cancellationToken);
        }

        public override async Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            var baseUrl = ProviderSettings.BaseUrl;
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new AiProviderException(Id, "No server address set for the OpenAI-compatible provider.");
            }

            var apiKey = Secrets.Get(SecretName);
            var stopwatch = Stopwatch.StartNew();
            var json = await PostJsonAsync(
                CombineUrl(baseUrl, "chat/completions"),
                BuildBody(RequireModel(), request),
                message =>
                {
                    if (!string.IsNullOrEmpty(apiKey))
                    {
                        message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    }
                },
                cancellationToken).ConfigureAwait(false);

            var text = ExtractText(json);
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new AiProviderException(Id, DisplayName + " returned no answer.");
            }

            return new AiResponse(Id, text, stopwatch.Elapsed);
        }

        internal static JObject BuildBody(string model, AiRequest request)
        {
            return new JObject
            {
                ["model"] = model,
                ["stream"] = false,
                ["messages"] = new JArray
                {
                    new JObject { ["role"] = "system", ["content"] = request.SystemPrompt ?? "" },
                    new JObject { ["role"] = "user", ["content"] = request.UserPrompt ?? "" },
                },
            };
        }

        internal static string ExtractText(JObject json)
        {
            var content = json.SelectToken("choices[0].message.content");
            if (content == null)
            {
                return "";
            }

            if (content.Type == JTokenType.String)
            {
                return ((string)content).Trim();
            }

            var builder = new StringBuilder();
            foreach (var part in content as JArray ?? new JArray())
            {
                if ((string)part["type"] == "text")
                {
                    builder.Append((string)part["text"]);
                }
            }

            return builder.ToString().Trim();
        }
    }
}

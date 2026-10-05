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
    /// <summary>OpenAI's Responses API, called with the shop's own API key.</summary>
    public sealed class OpenAiApiProvider : HttpApiProviderBase
    {
        public OpenAiApiProvider(HttpClient http, Func<AssistantSettings> settings, SecretStore secrets)
            : base(http, settings, secrets)
        {
        }

        public override string Id => ProviderIds.OpenAiApi;

        public override string DisplayName => "OpenAI API";

        protected override ApiProviderSettings ProviderSettings => Settings().OpenAi;

        protected override string SecretName => SecretNames.OpenAiApiKey;

        public override async Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            var apiKey = RequireApiKey();
            var body = BuildBody(RequireModel(), request);
            var baseUrl = string.IsNullOrWhiteSpace(ProviderSettings.BaseUrl) ? "https://api.openai.com/v1" : ProviderSettings.BaseUrl;

            var stopwatch = Stopwatch.StartNew();
            var json = await PostJsonAsync(
                CombineUrl(baseUrl, "responses"),
                body,
                message => message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey),
                cancellationToken).ConfigureAwait(false);

            var text = ExtractText(json);
            if (string.IsNullOrWhiteSpace(text))
            {
                var reason = (string)json.SelectToken("incomplete_details.reason") ?? (string)json["status"] ?? "no text";
                throw new AiProviderException(Id, "OpenAI returned no answer (" + reason + ").");
            }

            return new AiResponse(Id, text, stopwatch.Elapsed);
        }

        internal static JObject BuildBody(string model, AiRequest request)
        {
            return new JObject
            {
                ["model"] = model,
                ["instructions"] = request.SystemPrompt ?? "",
                ["input"] = request.UserPrompt ?? "",
                // Business data: ask OpenAI not to keep the response for later retrieval.
                ["store"] = false,
            };
        }

        internal static string ExtractText(JObject json)
        {
            var builder = new StringBuilder();
            foreach (var item in json["output"] as JArray ?? new JArray())
            {
                if ((string)item["type"] != "message")
                {
                    continue;
                }

                foreach (var part in item["content"] as JArray ?? new JArray())
                {
                    if ((string)part["type"] == "output_text")
                    {
                        builder.Append((string)part["text"]);
                    }
                }
            }

            return builder.ToString().Trim();
        }
    }
}

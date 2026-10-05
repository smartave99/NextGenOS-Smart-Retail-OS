using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>Google's Gemini API (generateContent), called with the shop's own API key.</summary>
    public sealed class GeminiApiProvider : HttpApiProviderBase
    {
        public GeminiApiProvider(HttpClient http, Func<AssistantSettings> settings, SecretStore secrets)
            : base(http, settings, secrets)
        {
        }

        public override string Id => ProviderIds.GeminiApi;

        public override string DisplayName => "Gemini API (Google)";

        protected override ApiProviderSettings ProviderSettings => Settings().Gemini;

        protected override string SecretName => SecretNames.GeminiApiKey;

        public override async Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            var apiKey = RequireApiKey();
            var model = RequireModel();
            if (model.StartsWith("models/", StringComparison.OrdinalIgnoreCase))
            {
                model = model.Substring("models/".Length);
            }

            var baseUrl = string.IsNullOrWhiteSpace(ProviderSettings.BaseUrl) ? "https://generativelanguage.googleapis.com/v1beta" : ProviderSettings.BaseUrl;
            var stopwatch = Stopwatch.StartNew();
            var json = await PostJsonAsync(
                CombineUrl(baseUrl, "models/" + Uri.EscapeDataString(model) + ":generateContent"),
                BuildBody(request),
                message => message.Headers.Add("x-goog-api-key", apiKey),
                cancellationToken).ConfigureAwait(false);

            var blockReason = (string)json.SelectToken("promptFeedback.blockReason");
            if (!string.IsNullOrEmpty(blockReason))
            {
                throw new AiProviderException(Id, "Gemini blocked this request (" + blockReason + ").");
            }

            var text = ExtractText(json);
            if (string.IsNullOrWhiteSpace(text))
            {
                var finish = (string)json.SelectToken("candidates[0].finishReason") ?? "no text";
                throw new AiProviderException(Id, "Gemini returned no answer (" + finish + ").");
            }

            return new AiResponse(Id, text, stopwatch.Elapsed);
        }

        internal static JObject BuildBody(AiRequest request)
        {
            var body = new JObject
            {
                ["contents"] = new JArray
                {
                    new JObject
                    {
                        ["role"] = "user",
                        ["parts"] = new JArray { new JObject { ["text"] = request.UserPrompt ?? "" } },
                    },
                },
            };

            if (!string.IsNullOrWhiteSpace(request.SystemPrompt))
            {
                body["systemInstruction"] = new JObject
                {
                    ["parts"] = new JArray { new JObject { ["text"] = request.SystemPrompt } },
                };
            }

            return body;
        }

        internal static string ExtractText(JObject json)
        {
            var builder = new StringBuilder();
            foreach (var part in json.SelectToken("candidates[0].content.parts") as JArray ?? new JArray())
            {
                // Thought summaries are not part of the answer.
                if ((bool?)part["thought"] == true)
                {
                    continue;
                }

                builder.Append((string)part["text"]);
            }

            return builder.ToString().Trim();
        }
    }
}

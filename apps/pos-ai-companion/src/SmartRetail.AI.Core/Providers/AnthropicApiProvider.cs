using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>Claude through Anthropic's Messages API, using the official Anthropic C# SDK and the
    /// shop's own API key.</summary>
    public sealed class AnthropicApiProvider : IAiProvider
    {
        private const string ServerSideFallbackBeta = "server-side-fallback-2026-07-01";

        private readonly Func<AssistantSettings> _settings;
        private readonly SecretStore _secrets;
        private readonly object _clientLock = new object();
        private AnthropicClient _client;
        private string _clientKey;

        public AnthropicApiProvider(Func<AssistantSettings> settings, SecretStore secrets)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _secrets = secrets ?? throw new ArgumentNullException(nameof(secrets));
        }

        public string Id => ProviderIds.AnthropicApi;

        public string DisplayName => "Claude API (Anthropic)";

        public ProviderKind Kind => ProviderKind.Api;

        public Task<ProviderStatus> CheckAsync(CancellationToken cancellationToken)
        {
            if (!_secrets.Has(SecretNames.AnthropicApiKey))
            {
                return Task.FromResult(ProviderStatus.NotReady("No Anthropic API key saved (Settings → API keys)."));
            }

            var model = _settings().Anthropic.Model;
            return Task.FromResult(string.IsNullOrWhiteSpace(model)
                ? ProviderStatus.NotReady("No model set (Settings → API keys).")
                : ProviderStatus.Ready("Ready; model " + model.Trim() + "."));
        }

        public async Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            var apiKey = _secrets.Get(SecretNames.AnthropicApiKey)
                ?? throw new AiProviderException(Id, "No Anthropic API key saved (Settings → API keys).");
            var settings = _settings().Anthropic;
            var model = string.IsNullOrWhiteSpace(settings.Model) ? "claude-opus-5" : settings.Model.Trim();

            var stopwatch = Stopwatch.StartNew();
            BetaMessage response;
            using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                timeout.CancelAfter(TimeSpan.FromSeconds(Math.Max(10, settings.TimeoutSeconds)));
                try
                {
                    response = await GetClient(apiKey).Beta.Messages.Create(BuildParameters(model, request), cancellationToken: timeout.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    throw new AiProviderException(Id, "Claude did not answer within " + settings.TimeoutSeconds + " seconds.");
                }
                catch (AnthropicUnauthorizedException ex)
                {
                    throw new AiProviderException(Id, "Anthropic rejected the API key. Check it in Settings → API keys.", canFallback: true, innerException: ex);
                }
                catch (AnthropicRateLimitException ex)
                {
                    throw new AiProviderException(Id, "Anthropic is rate-limiting this API key; try again shortly.", canFallback: true, innerException: ex);
                }
                catch (Anthropic5xxException ex)
                {
                    throw new AiProviderException(Id, "Anthropic's service had an error; try again shortly.", canFallback: true, innerException: ex);
                }
                catch (AnthropicIOException ex)
                {
                    throw new AiProviderException(Id, "Could not reach Anthropic: " + ex.Message, canFallback: true, innerException: ex);
                }
                catch (AnthropicApiException ex)
                {
                    throw new AiProviderException(Id, "Anthropic API error: " + ex.Message, canFallback: true, innerException: ex);
                }
            }

            // A safety classifier can decline with HTTP 200; check before reading the content.
            if (response.StopReason == "refusal")
            {
                throw new AiProviderException(Id, "Claude declined this request. Try rephrasing it, or ask another provider.");
            }

            var text = new StringBuilder();
            foreach (var block in response.Content)
            {
                if (block.TryPickText(out var textBlock))
                {
                    text.Append(textBlock.Text);
                }
            }

            if (text.Length == 0)
            {
                throw new AiProviderException(Id, "Claude returned no text (stop reason: " + response.StopReason + ").");
            }

            return new AiResponse(Id, text.ToString().Trim(), stopwatch.Elapsed);
        }

        internal static MessageCreateParams BuildParameters(string model, AiRequest request)
        {
            var messages = new System.Collections.Generic.List<BetaMessageParam>
            {
                new BetaMessageParam { Role = Role.User, Content = request.UserPrompt ?? "" },
            };

            if (SupportsServerSideFallback(model))
            {
                // Lets Anthropic re-serve a policy decline on its recommended fallback model.
                return new MessageCreateParams
                {
                    Model = model,
                    MaxTokens = 16000,
                    System = request.SystemPrompt ?? "",
                    Thinking = new BetaThinkingConfigAdaptive(),
                    Fallbacks = new Default(),
                    Betas = [ServerSideFallbackBeta],
                    Messages = messages,
                };
            }

            if (SupportsAdaptiveThinking(model))
            {
                return new MessageCreateParams
                {
                    Model = model,
                    MaxTokens = 16000,
                    System = request.SystemPrompt ?? "",
                    Thinking = new BetaThinkingConfigAdaptive(),
                    Messages = messages,
                };
            }

            return new MessageCreateParams
            {
                Model = model,
                MaxTokens = 16000,
                System = request.SystemPrompt ?? "",
                Messages = messages,
            };
        }

        internal static bool SupportsServerSideFallback(string model)
        {
            return model == "claude-opus-5" || model == "claude-opus-5-5" || model == "claude-fable-5" || model == "claude-fable-5-1";
        }

        internal static bool SupportsAdaptiveThinking(string model)
        {
            string[] prefixes = { "claude-opus-5", "claude-fable-5", "claude-sonnet-5", "claude-mythos", "claude-opus-4-6", "claude-opus-4-7", "claude-opus-4-8", "claude-sonnet-4-6" };
            foreach (var prefix in prefixes)
            {
                if (model.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private AnthropicClient GetClient(string apiKey)
        {
            lock (_clientLock)
            {
                if (_client == null || _clientKey != apiKey)
                {
                    _client = new AnthropicClient { ApiKey = apiKey };
                    _clientKey = apiKey;
                }

                return _client;
            }
        }
    }
}

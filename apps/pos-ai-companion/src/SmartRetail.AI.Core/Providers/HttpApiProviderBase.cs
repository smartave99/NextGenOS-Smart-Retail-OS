using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>Shared HTTP handling for API-key providers: timeouts, retries on 429/5xx, readable errors.</summary>
    public abstract class HttpApiProviderBase : IAiProvider
    {
        private const int MaxAttempts = 3;

        protected HttpApiProviderBase(HttpClient http, Func<AssistantSettings> settings, SecretStore secrets)
        {
            Http = http ?? throw new ArgumentNullException(nameof(http));
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Secrets = secrets ?? throw new ArgumentNullException(nameof(secrets));
        }

        public abstract string Id { get; }

        public abstract string DisplayName { get; }

        public ProviderKind Kind => ProviderKind.Api;

        protected HttpClient Http { get; }

        protected Func<AssistantSettings> Settings { get; }

        protected SecretStore Secrets { get; }

        protected abstract ApiProviderSettings ProviderSettings { get; }

        protected abstract string SecretName { get; }

        protected virtual bool RequiresApiKey => true;

        public virtual Task<ProviderStatus> CheckAsync(CancellationToken cancellationToken)
        {
            var settings = ProviderSettings;
            if (RequiresApiKey && !Secrets.Has(SecretName))
            {
                return Task.FromResult(ProviderStatus.NotReady("No API key saved (Settings → API keys)."));
            }

            if (string.IsNullOrWhiteSpace(settings.Model))
            {
                return Task.FromResult(ProviderStatus.NotReady("No model set (Settings → API keys)."));
            }

            return Task.FromResult(ProviderStatus.Ready("Ready; model " + settings.Model.Trim() + "."));
        }

        public abstract Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken);

        protected string RequireApiKey()
        {
            return Secrets.Get(SecretName)
                ?? throw new AiProviderException(Id, DisplayName + " has no API key saved (Settings → API keys).");
        }

        protected string RequireModel()
        {
            var model = ProviderSettings.Model?.Trim();
            if (string.IsNullOrEmpty(model))
            {
                throw new AiProviderException(Id, DisplayName + " has no model set (Settings → API keys).");
            }

            return model;
        }

        protected static string CombineUrl(string baseUrl, string path)
        {
            return (baseUrl ?? "").Trim().TrimEnd('/') + "/" + path.TrimStart('/');
        }

        protected async Task<JObject> PostJsonAsync(string url, JObject body, Action<HttpRequestMessage> addHeaders, CancellationToken cancellationToken)
        {
            var timeoutSeconds = Math.Max(10, ProviderSettings.TimeoutSeconds);
            using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                timeout.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));
                for (var attempt = 1; ; attempt++)
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                    {
                        request.Content = new StringContent(body.ToString(Formatting.None), Encoding.UTF8, "application/json");
                        addHeaders(request);

                        HttpResponseMessage response;
                        try
                        {
                            response = await Http.SendAsync(request, timeout.Token).ConfigureAwait(false);
                        }
                        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                        {
                            throw new AiProviderException(Id, DisplayName + " did not answer within " + timeoutSeconds + " seconds.");
                        }
                        catch (HttpRequestException ex)
                        {
                            throw new AiProviderException(Id, "Could not reach " + DisplayName + ": " + ex.GetBaseException().Message, canFallback: true, innerException: ex);
                        }

                        using (response)
                        {
                            var text = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var status = (int)response.StatusCode;
                            if (response.IsSuccessStatusCode)
                            {
                                try
                                {
                                    return JObject.Parse(text);
                                }
                                catch (JsonException ex)
                                {
                                    throw new AiProviderException(Id, DisplayName + " returned a response that is not JSON.", canFallback: true, innerException: ex);
                                }
                            }

                            if ((status == 429 || status >= 500) && attempt < MaxAttempts)
                            {
                                await Task.Delay(RetryDelay(response, attempt), timeout.Token).ConfigureAwait(false);
                                continue;
                            }

                            throw new AiProviderException(Id, DescribeHttpError(status, text), canFallback: status != 400);
                        }
                    }
                }
            }
        }

        private static TimeSpan RetryDelay(HttpResponseMessage response, int attempt)
        {
            var retryAfter = response.Headers.RetryAfter?.Delta;
            if (retryAfter.HasValue && retryAfter.Value > TimeSpan.Zero)
            {
                return retryAfter.Value > TimeSpan.FromSeconds(20) ? TimeSpan.FromSeconds(20) : retryAfter.Value;
            }

            return TimeSpan.FromSeconds(Math.Pow(2, attempt));
        }

        internal string DescribeHttpError(int status, string body)
        {
            string message = null;
            try
            {
                var error = JObject.Parse(body)["error"];
                message = error?.Type == JTokenType.Object ? (string)error["message"] : error?.ToString();
            }
            catch (JsonException)
            {
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                message = new string((body ?? "").Take(300).ToArray()).Trim();
            }

            if (status == 401 || status == 403)
            {
                return DisplayName + " rejected the API key (HTTP " + status + "): " + message;
            }

            if (status == 429)
            {
                return DisplayName + " is rate-limiting or out of credit (HTTP 429): " + message;
            }

            return DisplayName + " returned HTTP " + status + ": " + message;
        }
    }
}

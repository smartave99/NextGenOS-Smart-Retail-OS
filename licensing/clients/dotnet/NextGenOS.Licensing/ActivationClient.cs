using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NextGenOS.Licensing
{
    /// <summary>The answer of activate and check-in: signed tokens (spec section 8).</summary>
    public sealed class ServerTokens
    {
        public string Licence { get; set; }
        public string Activation { get; set; }
        public string RevocationList { get; set; }
    }

    /// <summary>An answer from the licence server that says no, or no answer at all (<see cref="IsNetwork"/>).</summary>
    public sealed class LicenceServerException : Exception
    {
        public LicenceServerException(string code, string message, bool isNetwork) : base(message)
        {
            Code = code;
            IsNetwork = isNetwork;
        }

        public string Code { get; private set; }

        /// <summary>True when the server could not be reached (not when it answered with an error).</summary>
        public bool IsNetwork { get; private set; }
    }

    /// <summary>Talks to the Licence Studio over HTTPS.</summary>
    public sealed class ActivationClient : IDisposable
    {
        private readonly HttpClient _http;
        private readonly Uri _baseUri;

        public ActivationClient(string serverUrl, HttpMessageHandler handler = null, TimeSpan? timeout = null)
        {
            if (string.IsNullOrWhiteSpace(serverUrl)) throw new ArgumentException("The licence server address is not set.");
            _baseUri = new Uri(serverUrl.TrimEnd('/') + "/");
            try { ServicePointManager.SecurityProtocol |= (SecurityProtocolType)3072; } catch (Exception) { } // TLS 1.2 on .NET Framework
            _http = handler == null ? new HttpClient() : new HttpClient(handler, false);
            _http.Timeout = timeout ?? TimeSpan.FromSeconds(20);
        }

        public Task<ServerTokens> ActivateAsync(string key, string version, IDictionary<string, string> fingerprint, string host, CancellationToken ct = default(CancellationToken))
        {
            return PostAsync("api/v1/activate", new JObject { { "key", key }, { "product", LicenceEvaluator.ProductId }, { "version", version }, { "fp", JObject.FromObject(fingerprint) }, { "host", host } }, ct);
        }

        public Task<ServerTokens> CheckInAsync(string licenceId, string activationToken, IDictionary<string, string> fingerprint, string version, int? stores, int? devices, int? users, CancellationToken ct = default(CancellationToken))
        {
            var usage = new JObject();
            if (stores.HasValue) usage["stores"] = stores.Value;
            if (devices.HasValue) usage["devices"] = devices.Value;
            if (users.HasValue) usage["users"] = users.Value;
            return PostAsync("api/v1/checkin", new JObject { { "lid", licenceId }, { "act", activationToken }, { "fp", JObject.FromObject(fingerprint) }, { "version", version }, { "usage", usage } }, ct);
        }

        public async Task DeactivateAsync(string licenceId, string activationToken, IDictionary<string, string> fingerprint, CancellationToken ct = default(CancellationToken))
        {
            await PostAsync("api/v1/deactivate", new JObject { { "lid", licenceId }, { "act", activationToken }, { "fp", JObject.FromObject(fingerprint) } }, ct).ConfigureAwait(false);
        }

        public async Task<string> GetRevocationListAsync(CancellationToken ct = default(CancellationToken))
        {
            var body = await SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri(_baseUri, "api/v1/crl")), ct).ConfigureAwait(false);
            return (string)body["crl"];
        }

        private async Task<ServerTokens> PostAsync(string path, JObject json, CancellationToken ct)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(_baseUri, path))
            {
                Content = new StringContent(json.ToString(Formatting.None), Encoding.UTF8, "application/json"),
            };
            var body = await SendAsync(request, ct).ConfigureAwait(false);
            return new ServerTokens { Licence = (string)body["lic"], Activation = (string)body["act"], RevocationList = (string)body["crl"] };
        }

        private async Task<JObject> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            string text;
            HttpStatusCode status;
            try
            {
                using (var response = await _http.SendAsync(request, ct).ConfigureAwait(false))
                {
                    status = response.StatusCode;
                    text = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is OperationCanceledException || ex is WebException)
            {
                throw new LicenceServerException("network", "The licence server could not be reached. Check the Internet connection.", true);
            }

            JObject body = null;
            try { body = JObject.Parse(text); } catch (JsonException) { }
            if ((int)status >= 200 && (int)status < 300 && body != null) return body;

            var error = body == null ? null : body["error"] as JObject;
            if (error != null) throw new LicenceServerException((string)error["code"] ?? "error", (string)error["message"] ?? "The licence server refused the request.", false);
            throw new LicenceServerException("server_error", "The licence server answered with an error (" + (int)status + ").", status == HttpStatusCode.BadGateway || status == HttpStatusCode.ServiceUnavailable || status == HttpStatusCode.GatewayTimeout);
        }

        public void Dispose()
        {
            _http.Dispose();
        }
    }
}

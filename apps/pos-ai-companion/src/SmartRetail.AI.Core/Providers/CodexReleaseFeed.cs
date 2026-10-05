using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Providers
{
    /// <summary>
    /// The newest released Codex, from the place OpenAI's own installer looks first (releases.openai.com), and, when that does not
    /// answer, from GitHub's list of releases, as the installer does. Only those two addresses are used, over https, and only the
    /// release's tag is read: an alpha, a beta or anything else is not "the latest".
    /// </summary>
    public sealed class CodexReleaseFeed : ICodexReleases
    {
        public const string ChannelUrl = "https://releases.openai.com/codex/channels/latest";

        public const string GitHubUrl = "https://api.github.com/repos/openai/codex/releases/latest";

        /// <summary>The channel's answer lists every file of the release (about 50 KB); more than this is not a release.</summary>
        private const int MaxBytes = 2 * 1024 * 1024;

        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(20);

        private readonly HttpClient _http;
        private readonly string _channel;
        private readonly string _github;

        public CodexReleaseFeed(HttpClient http)
            : this(http, ChannelUrl, GitHubUrl)
        {
        }

        /// <summary>Other addresses, e.g. for a test: https, or this PC itself (an address that leaves the PC over http is refused).</summary>
        public CodexReleaseFeed(HttpClient http, string channel, string github)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _channel = Checked(channel, nameof(channel));
            _github = Checked(github, nameof(github));
        }

        private static string Checked(string url, string name)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttps && !(uri.Scheme == Uri.UriSchemeHttp && uri.IsLoopback)))
            {
                throw new ArgumentException("A release address must be https, or on this PC: " + url, name);
            }

            return url;
        }

        /// <summary>The newest stable release, or null when neither place could say (no internet, or an answer that is not a release).</summary>
        public async Task<Version> LatestAsync(CancellationToken cancellationToken)
        {
            return await TryAsync(_channel, cancellationToken).ConfigureAwait(false)
                ?? await TryAsync(_github, cancellationToken).ConfigureAwait(false);
        }

        private async Task<Version> TryAsync(string url, CancellationToken cancellationToken)
        {
            try
            {
                using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    timeout.CancelAfter(Timeout);
                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    {
                        request.Headers.UserAgent.ParseAdd("SmartRetailPOS-AI/1.0");
                        request.Headers.Accept.ParseAdd("application/json");
                        using (var response = await _http.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, timeout.Token).ConfigureAwait(false))
                        {
                            if (!response.IsSuccessStatusCode)
                            {
                                return null;
                            }

                            var final = response.RequestMessage?.RequestUri;
                            if (final != null && final.Scheme != Uri.UriSchemeHttps && !IsLoopback(final))
                            {
                                return null;
                            }

                            using (var body = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                            using (var copy = new MemoryStream())
                            {
                                var buffer = new byte[81920];
                                int read;
                                while ((read = await body.ReadAsync(buffer, 0, buffer.Length, timeout.Token).ConfigureAwait(false)) > 0)
                                {
                                    if (copy.Length + read > MaxBytes)
                                    {
                                        return null;
                                    }

                                    copy.Write(buffer, 0, read);
                                }

                                var json = JObject.Parse(Encoding.UTF8.GetString(copy.ToArray()));
                                return json["tag_name"]?.Type == JTokenType.String ? CodexVersions.OfTag((string)json["tag_name"]) : null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is OperationCanceledException && !cancellationToken.IsCancellationRequested
                || ex is Newtonsoft.Json.JsonException || ex is IOException)
            {
                return null;
            }
        }

        private static bool IsLoopback(Uri uri) => uri.IsLoopback;
    }
}

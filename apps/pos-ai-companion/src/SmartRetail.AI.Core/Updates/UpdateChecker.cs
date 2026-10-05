using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Updates
{
    /// <summary>
    /// Looks for a newer version in the update folder online (latest.json), and when there is one, makes sure GitHub
    /// signed it for the project's own release before downloading anything, then downloads the setup (whole, or in the
    /// pieces the folder keeps it in) and checks its size and SHA-256. The result is kept in the Updates folder's
    /// status.json; nothing is installed here.
    /// </summary>
    public sealed class UpdateChecker
    {
        private const int MaxTextBytes = 256 * 1024;

        private static readonly TimeSpan TextTimeout = TimeSpan.FromSeconds(30);

        private static readonly TimeSpan SetupTimeout = TimeSpan.FromMinutes(30);

        private readonly HttpClient _http;
        private readonly Uri _feed;
        private readonly string _folder;
        private readonly ReleaseSource _source;
        private readonly Func<DateTime> _now;

        /// <param name="feed">The public folder, e.g. https://….supabase.co/storage/v1/object/public/app-updates/ (https only).</param>
        public UpdateChecker(HttpClient http, Uri feed, string folder, ReleaseSource source, Func<DateTime> now)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _feed = IsUsable(feed) ? feed : throw new ArgumentException("The update folder must be an https address ending in /.", nameof(feed));
            _folder = folder ?? throw new ArgumentNullException(nameof(folder));
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _now = now ?? (() => DateTime.Now);
        }

        /// <summary>True for an https address ending in / (a folder), with no sign-in details, query or fragment.</summary>
        public static bool IsUsable(Uri feed) =>
            feed != null && feed.IsAbsoluteUri && feed.Scheme == Uri.UriSchemeHttps
            && feed.AbsolutePath.EndsWith("/", StringComparison.Ordinal)
            && feed.UserInfo.Length == 0 && feed.Query.Length == 0 && feed.Fragment.Length == 0;

        /// <summary>Checks, downloads when newer, and saves and returns what it found; a failure is saved as such too.</summary>
        public async Task<UpdateStatus> CheckAsync(Version current, CancellationToken ct)
        {
            UpdateStatus status;
            try
            {
                status = await FindAsync(current, ct);
            }
            catch (Exception ex) when (ex is UpdateException || ex is HttpRequestException || ex is IOException
                || (ex is OperationCanceledException && !ct.IsCancellationRequested))
            {
                status = new UpdateStatus
                {
                    State = UpdateState.Failed,
                    Current = Text(current),
                    CheckedAt = _now(),
                    Problem = ex is UpdateException ? ex.Message
                        : ex is OperationCanceledException ? "The update folder did not answer in time."
                        : "The update folder could not be reached: " + ex.Message,
                };
            }

            UpdateFolder.Save(_folder, status);
            return status;
        }

        private async Task<UpdateStatus> FindAsync(Version current, CancellationToken ct)
        {
            // A fresh copy each time: the folder is behind a cache.
            var stamp = _now().ToUniversalTime().ToString("yyyyMMddHHmm", CultureInfo.InvariantCulture);
            var manifest = UpdateManifest.Parse(await GetTextAsync(new Uri(_feed, "latest.json?check=" + stamp), null, ct));
            if (manifest.ParsedVersion <= current)
            {
                DeleteSetups(keep: null);
                return new UpdateStatus { State = UpdateState.UpToDate, Current = Text(current), CheckedAt = _now() };
            }

            // GitHub's word first, so nothing is downloaded that the project's release did not make.
            var problem = GitHubStatement.Check(manifest.Statement, await GetTextAsync(GitHubStatement.KeysUrl, GitHubStatement.KeysUrl.Host, ct), _source, manifest.Audience);
            if (problem != null)
            {
                throw new UpdateException("Version " + manifest.Version + " was not published by the app's own release (" + problem + "), so it was not downloaded.");
            }

            var path = Path.Combine(_folder, manifest.File);
            if (!File.Exists(path) || new FileInfo(path).Length != manifest.Size || Sha256Of(path) != manifest.Sha256)
            {
                await DownloadAsync(path, manifest, ct);
            }

            DeleteSetups(keep: manifest.File);
            return new UpdateStatus
            {
                State = UpdateState.Ready,
                Current = Text(current),
                Available = manifest.Version,
                File = manifest.File,
                Sha256 = manifest.Sha256,
                Notes = manifest.Notes,
                CheckedAt = _now(),
            };
        }

        /// <summary>The SHA-256 of a file, lower-case hex.</summary>
        public static string Sha256Of(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return Sha256Of(stream);
            }
        }

        public static string Sha256Of(Stream stream)
        {
            using (var sha = SHA256.Create())
            {
                return string.Concat(sha.ComputeHash(stream).Select(b => b.ToString("x2", CultureInfo.InvariantCulture)));
            }
        }

        private async Task<string> GetTextAsync(Uri url, string expectedHost, CancellationToken ct)
        {
            using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(ct))
            {
                timeout.CancelAfter(TextTimeout);
                using (var response = await _http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, timeout.Token))
                {
                    Check(response, url, expectedHost);
                    using (var body = await response.Content.ReadAsStreamAsync())
                    using (var copy = new MemoryStream())
                    {
                        await CopyAsync(body, copy, MaxTextBytes, timeout.Token);
                        return Encoding.UTF8.GetString(copy.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// The answer must be a success, and (also after any redirect) still come over https, and from
        /// <paramref name="expectedHost"/> when one is named: the place that says which key GitHub signs with is
        /// never taken from anywhere else.
        /// </summary>
        private static void Check(HttpResponseMessage response, Uri asked, string expectedHost)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new UpdateException(asked.Host + " answered " + (int)response.StatusCode + " for " + asked.AbsolutePath + ".");
            }

            var final = response.RequestMessage?.RequestUri ?? asked;
            if (final.Scheme != Uri.UriSchemeHttps || (expectedHost != null && !string.Equals(final.Host, expectedHost, StringComparison.OrdinalIgnoreCase)))
            {
                throw new UpdateException(asked.Host + " sent the answer from somewhere that cannot be trusted, so it was not used.");
            }
        }

        private async Task DownloadAsync(string path, UpdateManifest manifest, CancellationToken ct)
        {
            Directory.CreateDirectory(_folder);
            var partial = path + ".part";
            try
            {
                using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(ct))
                {
                    timeout.CancelAfter(SetupTimeout);
                    using (var file = new FileStream(partial, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // One file, or the pieces in order: each must have exactly the size the description gives.
                        for (var number = 1; number <= manifest.PartCount; number++)
                        {
                            var url = new Uri(_feed, manifest.PartName(number));
                            using (var response = await _http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, timeout.Token))
                            {
                                if (!response.IsSuccessStatusCode)
                                {
                                    throw new UpdateException("The setup for version " + manifest.Version + " could not be downloaded (" + (int)response.StatusCode + ").");
                                }

                                Check(response, url, null);
                                using (var body = await response.Content.ReadAsStreamAsync())
                                {
                                    var expected = manifest.PartLength(number);
                                    if (await CopyAsync(body, file, expected, timeout.Token) != expected)
                                    {
                                        throw new UpdateException(Different(manifest));
                                    }
                                }
                            }
                        }
                    }
                }

                if (new FileInfo(partial).Length != manifest.Size || Sha256Of(partial) != manifest.Sha256)
                {
                    throw new UpdateException(Different(manifest));
                }

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                File.Move(partial, path);
            }
            finally
            {
                if (File.Exists(partial))
                {
                    File.Delete(partial);
                }
            }
        }

        private static string Different(UpdateManifest manifest) =>
            "The setup for version " + manifest.Version + " came down different from what was published, so it was not kept.";

        /// <summary>Copies at most <paramref name="limit"/> bytes and returns how many; more than that is refused.</summary>
        private static async Task<long> CopyAsync(Stream from, Stream to, long limit, CancellationToken ct)
        {
            var buffer = new byte[81920];
            long total = 0;
            int read;
            while ((read = await from.ReadAsync(buffer, 0, buffer.Length, ct)) > 0)
            {
                total += read;
                if (total > limit)
                {
                    throw new UpdateException("The update folder sent more than was expected, so it was not kept.");
                }

                await to.WriteAsync(buffer, 0, read, ct);
            }

            return total;
        }

        /// <summary>Removes downloaded setups other than <paramref name="keep"/>, and any left half-downloaded.</summary>
        private void DeleteSetups(string keep)
        {
            if (!Directory.Exists(_folder))
            {
                return;
            }

            foreach (var path in Directory.EnumerateFiles(_folder, "SmartRetailAI-Setup-*").ToList())
            {
                if (!string.Equals(Path.GetFileName(path), keep, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                    {
                        // Still in use: next time.
                    }
                }
            }
        }

        private static string Text(Version version) => version == null ? "" : version.ToString(3);
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Dashboard;

namespace SmartRetail.AI.Desktop
{
    /// <summary>Starts the sales dashboard without a window, checks that it answers, and opens its pages in the
    /// default browser. A dashboard this app started is stopped when the app exits.</summary>
    internal sealed class WindowsDashboardHost : IDashboardHost, IDisposable
    {
        // The dashboard is on this PC: never send the check through a proxy.
        private readonly HttpClient _http = new HttpClient(new HttpClientHandler { UseProxy = false }) { Timeout = TimeSpan.FromSeconds(3) };
        private Process _started;

        public async Task<bool> RespondsAsync(Uri url, CancellationToken cancellationToken)
        {
            try
            {
                using (var response = await _http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
                {
                    return (int)response.StatusCode < 500;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
            catch (TaskCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                // Timed out: not answering (yet).
                return false;
            }
        }

        public bool FileExists(string path) => File.Exists(path);

        public void Start(string executable)
        {
            StopStarted();
            _started = Process.Start(new ProcessStartInfo(executable)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(executable) ?? "",
            });
        }

        public void OpenBrowser(Uri url)
        {
            Process.Start(new ProcessStartInfo(url.AbsoluteUri) { UseShellExecute = true })?.Dispose();
        }

        /// <summary>Stops the dashboard if this app started it.</summary>
        public void StopStarted()
        {
            try
            {
                if (_started != null && !_started.HasExited)
                {
                    _started.Kill();
                }
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is System.ComponentModel.Win32Exception)
            {
            }
            finally
            {
                _started?.Dispose();
                _started = null;
            }
        }

        public void Dispose()
        {
            StopStarted();
            _http.Dispose();
        }
    }
}

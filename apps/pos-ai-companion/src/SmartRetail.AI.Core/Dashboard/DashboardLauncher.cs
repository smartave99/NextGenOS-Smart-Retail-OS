using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Data;

namespace SmartRetail.AI.Dashboard
{
    /// <summary>Where the sales dashboard (the Smart Retail POS web app) lives and answers.</summary>
    public sealed class DashboardSettings
    {
        public const string DefaultUrl = "http://127.0.0.1:5080/";

        /// <summary>The dashboard's folder and program, as the package lays them out next to this app.</summary>
        public const string DefaultRelativePath = @"Dashboard\SmartRetail.Pos.Web.exe";

        /// <summary>Empty: <see cref="DefaultRelativePath"/> in this app's folder.</summary>
        public string ExecutablePath { get; set; } = "";

        /// <summary>Must stay on this PC: the dashboard shows the shop's figures.</summary>
        public string Url { get; set; } = DefaultUrl;

        public string ResolveExecutable(string appFolder)
        {
            var path = (ExecutablePath ?? "").Trim().Trim('"');
            if (path.Length == 0)
            {
                path = DefaultRelativePath;
            }

            return Path.IsPathRooted(path) ? path : Path.Combine(appFolder ?? "", path.Replace('\\', Path.DirectorySeparatorChar));
        }

        internal void Normalize()
        {
            ExecutablePath = (ExecutablePath ?? "").Trim();
            Url = IsLocal(Url, out var url) ? url.AbsoluteUri : DefaultUrl;
        }

        /// <summary>An http(s) address on this PC (127.0.0.1, ::1 or localhost).</summary>
        public static bool IsLocal(string text, out Uri url)
        {
            url = null;
            if (!Uri.TryCreate((text ?? "").Trim(), UriKind.Absolute, out var parsed)
                || (parsed.Scheme != Uri.UriSchemeHttp && parsed.Scheme != Uri.UriSchemeHttps)
                || !parsed.IsLoopback)
            {
                return false;
            }

            url = new Uri(parsed.GetLeftPart(UriPartial.Path).TrimEnd('/') + "/");
            return true;
        }
    }

    /// <summary>What <see cref="DashboardLauncher"/> needs from the PC.</summary>
    public interface IDashboardHost
    {
        Task<bool> RespondsAsync(Uri url, CancellationToken cancellationToken);

        bool FileExists(string path);

        /// <summary>Starts the dashboard program without a window.</summary>
        void Start(string executable);

        void OpenBrowser(Uri url);

        /// <summary>Stops the dashboard if this app started it.</summary>
        void StopStarted();
    }

    public sealed class DashboardOpenResult
    {
        private DashboardOpenResult(bool opened, bool started, string problem)
        {
            Opened = opened;
            Started = started;
            Problem = problem;
        }

        public bool Opened { get; }

        /// <summary>The dashboard was not running and this app started it.</summary>
        public bool Started { get; }

        public string Problem { get; }

        /// <summary>
        /// The dashboard was started although the POS database did not answer in time. It looks for the database once, when it
        /// starts, so it shows the demo shop until it is started again.
        /// </summary>
        public bool StartedWithoutPos { get; private set; }

        internal DashboardOpenResult WithoutPos() => new DashboardOpenResult(Opened, Started, Problem) { StartedWithoutPos = true };

        internal static DashboardOpenResult Success(bool started) => new DashboardOpenResult(true, started, null);

        internal static DashboardOpenResult Failure(string problem, bool started = false) => new DashboardOpenResult(false, started, problem);
    }

    /// <summary>Opens a page of the sales dashboard in the browser, starting the dashboard first when it is not running.</summary>
    public sealed class DashboardLauncher
    {
        public static readonly TimeSpan PollInterval = TimeSpan.FromMilliseconds(500);

        /// <summary>A cold start reads the POS database and loads .NET; give it time on an old shop PC.</summary>
        public static readonly TimeSpan StartTimeout = TimeSpan.FromSeconds(45);

        private readonly IDashboardHost _host;
        private readonly Func<TimeSpan, CancellationToken, Task> _delay;
        private readonly Func<DateTime> _now;

        public DashboardLauncher(IDashboardHost host, Func<TimeSpan, CancellationToken, Task> delay = null, Func<DateTime> now = null)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
            _delay = delay ?? Task.Delay;
            _now = now;
        }

        /// <summary>Opens <paramref name="page"/> in the browser once the dashboard answers.</summary>
        public async Task<DashboardOpenResult> OpenAsync(string executable, Uri url, string page, IProgress<string> progress, CancellationToken cancellationToken)
        {
            var result = await EnsureRunningAsync(executable, url, progress, cancellationToken).ConfigureAwait(false);
            if (result.Opened)
            {
                _host.OpenBrowser(new Uri(url, (page ?? "").TrimStart('/')));
            }

            return result;
        }

        /// <summary>
        /// Starts the dashboard for the app's own windows, like <see cref="EnsureRunningAsync"/>. The dashboard looks for the POS
        /// database once, when it starts, so when the app knows of a saved database (<paramref name="posAnswers"/>) and the dashboard
        /// is not running, the database first gets up to <paramref name="patience"/> to answer (see <see cref="PosReadiness"/>):
        /// Windows may have started the app before SQL Server was ready. If it never does, the dashboard is started anyway and the
        /// result says so. <paramref name="restart"/> stops the dashboard this app started, and starts it again.
        /// </summary>
        public async Task<DashboardOpenResult> StartAsync(
            string executable,
            Uri url,
            IProgress<string> progress,
            CancellationToken cancellationToken,
            TimeSpan patience = default(TimeSpan),
            Func<CancellationToken, Task<bool>> posAnswers = null,
            bool restart = false)
        {
            var onThisPc = url != null && url.IsLoopback;
            if (restart && onThisPc)
            {
                _host.StopStarted();
                for (var attempt = 0; attempt < 20 && await _host.RespondsAsync(url, cancellationToken).ConfigureAwait(false); attempt++)
                {
                    await _delay(TimeSpan.FromMilliseconds(250), cancellationToken).ConfigureAwait(false);
                }
            }

            var answered = true;
            if (onThisPc && patience > TimeSpan.Zero && posAnswers != null && !await _host.RespondsAsync(url, cancellationToken).ConfigureAwait(false))
            {
                answered = await PosReadiness.WaitAsync(posAnswers, patience, progress, cancellationToken, _now, _delay).ConfigureAwait(false);
            }

            var result = await EnsureRunningAsync(executable, url, progress, cancellationToken).ConfigureAwait(false);
            return result.Started && !answered ? result.WithoutPos() : result;
        }

        /// <summary>Makes sure the dashboard answers, starting it when it is not running. Opens nothing: the app shows it
        /// in its own window.</summary>
        public async Task<DashboardOpenResult> EnsureRunningAsync(string executable, Uri url, IProgress<string> progress, CancellationToken cancellationToken)
        {
            if (url == null || !url.IsLoopback)
            {
                return DashboardOpenResult.Failure("The dashboard address must be on this PC, e.g. " + DashboardSettings.DefaultUrl);
            }

            if (await _host.RespondsAsync(url, cancellationToken).ConfigureAwait(false))
            {
                return DashboardOpenResult.Success(started: false);
            }

            if (string.IsNullOrWhiteSpace(executable) || !_host.FileExists(executable))
            {
                return DashboardOpenResult.Failure("The sales dashboard is not installed here: " + executable
                    + " was not found. Copy the Dashboard folder from the package next to this app, or set its path in Settings → Side panel.");
            }

            progress?.Report("Starting the sales dashboard…");
            _host.Start(executable);
            var attempts = (int)Math.Ceiling(StartTimeout.TotalMilliseconds / PollInterval.TotalMilliseconds);
            for (var attempt = 0; attempt < attempts; attempt++)
            {
                await _delay(PollInterval, cancellationToken).ConfigureAwait(false);
                if (await _host.RespondsAsync(url, cancellationToken).ConfigureAwait(false))
                {
                    return DashboardOpenResult.Success(started: true);
                }
            }

            return DashboardOpenResult.Failure("The sales dashboard did not start within " + (int)StartTimeout.TotalSeconds + " seconds. "
                + "Another program may be using its address (" + url + "); it can be changed in the Dashboard folder's appsettings.json "
                + "(Kestrel → Url) and here in Settings → Side panel.", started: true);
        }
    }
}

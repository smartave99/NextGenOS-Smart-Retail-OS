using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Updates;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// Automatic updates. Two minutes after the app starts, and every six hours, the update folder online is checked
    /// (<see cref="UpdateChecker"/>): a newer version that GitHub signed for the app's own release is downloaded in the
    /// background and checked. The dashboard shows it (the bell, Settings) and the tray menu offers it; installing waits
    /// for the owner, and installs only what this run of the app checked itself, never a file or a status found on
    /// disk. A copy built without an update folder does not check.
    /// </summary>
    internal sealed class UpdateService : IDisposable
    {
        private static readonly TimeSpan FirstCheck = TimeSpan.FromMinutes(2);
        private static readonly TimeSpan Every = TimeSpan.FromHours(6);

        private readonly UpdateChecker _checker;
        private readonly System.Threading.Timer _timer;
        private readonly object _gate = new object();
        private int _checking;
        private UpdateStatus _verified;

        public UpdateService(HttpClient http, UpdateSettings settings, string folder)
        {
            Folder = folder;
            if (settings == null)
            {
                Save(new UpdateStatus { State = UpdateState.Off, Current = Current.ToString(3) });
                return;
            }

            _checker = new UpdateChecker(http, settings.Feed, folder, settings.Source, () => DateTime.Now);
            _timer = new System.Threading.Timer(_ => _ = CheckAsync(), null, FirstCheck, Every);
        }

        /// <summary>A check found something new, or nothing, or failed. Raised on any thread.</summary>
        public event EventHandler Changed;

        /// <summary>The Updates folder: the downloaded setup and status.json, which the dashboard reads.</summary>
        public string Folder { get; }

        /// <summary>True when this copy was built with an update folder to look in.</summary>
        public bool IsOn => _checker != null;

        /// <summary>This copy's version (three numbers).</summary>
        public static Version Current
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return new Version(version.Major, version.Minor, Math.Max(version.Build, 0));
            }
        }

        /// <summary>What the last check found, as it is on disk.</summary>
        public UpdateStatus Status => UpdateFolder.Load(Folder);

        /// <summary>The update this run of the app checked and downloaded itself; null until it has.</summary>
        public UpdateStatus Verified
        {
            get
            {
                lock (_gate)
                {
                    return _verified;
                }
            }
        }

        /// <summary>The update folder and the release workflow this copy was built with (-p:UpdateFeed=… …), or null.</summary>
        public static UpdateSettings SettingsOfThisBuild() => UpdateSettings.From(key =>
            Assembly.GetExecutingAssembly().GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault(a => a.Key == key)?.Value);

        public async Task CheckAsync()
        {
            if (_checker == null || Interlocked.Exchange(ref _checking, 1) == 1)
            {
                return;
            }

            try
            {
                var status = await _checker.CheckAsync(Current, CancellationToken.None);
                lock (_gate)
                {
                    if (status.State == UpdateState.Ready)
                    {
                        _verified = status;
                    }
                    else if (status.State == UpdateState.UpToDate)
                    {
                        _verified = null;
                    }
                }

                if (status.State == UpdateState.Failed)
                {
                    AppLog.Error("Checking for updates", new UpdateException(status.Problem));
                }

                Changed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                AppLog.Error("Checking for updates", ex);
            }
            finally
            {
                Interlocked.Exchange(ref _checking, 0);
            }
        }

        /// <summary>
        /// Installs the update this run of the app checked (checking now when it has not yet). Null when the setup has
        /// started, so the app should quit at once; else why it could not start.
        /// </summary>
        public async Task<string> InstallAsync()
        {
            if (_checker == null)
            {
                return "This copy of the app does not update itself.";
            }

            var ready = Verified;
            if (ready == null)
            {
                await CheckAsync();
                ready = Verified;
            }

            if (ready == null)
            {
                var status = Status;
                return status.State == UpdateState.Failed && status.Problem.Length > 0 ? status.Problem : "There is no update to install.";
            }

            return UpdateInstaller.Start(ready, Folder, Current);
        }

        public void Dispose() => _timer?.Dispose();

        private void Save(UpdateStatus status)
        {
            try
            {
                UpdateFolder.Save(Folder, status);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                AppLog.Error("Saving the update status", ex);
            }
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Dashboard;
using SmartRetail.AI.Data;
using SmartRetail.AI.Memory;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.AI.Storage;
using SmartRetail.AI.Updates;

namespace SmartRetail.AI.Desktop
{
    /// <summary>Wires the settings, providers, database and assistant together for the UI.</summary>
    internal sealed class AssistantApp : IDisposable
    {
        public AssistantApp(SettingsStore store)
        {
            Store = store;
            Settings = store.Load();
            Protector = new DpapiSecretProtector();
            Secrets = new SecretStore(() => Settings, Protector);
            Http = new HttpClient { Timeout = Timeout.InfiniteTimeSpan };
            Http.DefaultRequestHeaders.UserAgent.ParseAdd("SmartRetailPOS-AI/1.0");
            Router = new ProviderRouter(ProviderCatalog.CreateAll(AskSettings, Secrets, new ProcessCliRunner(), Http), () => Settings);
            Database = new SqlServerQueryExecutor(
                () => SqlServerQueryExecutor.BuildConnectionString(Settings.Database, Secrets.Get(SecretNames.DatabasePassword)),
                () => Settings.Database.CommandTimeoutSeconds);
            Assistant = new BusinessAssistant(Router, Database, () => Settings, null, MemorySnapshot);
            Updates = new UpdateService(Http, UpdateService.SettingsOfThisBuild(), UpdateFolder.Default);
        }

        public SettingsStore Store { get; }

        private DateTime _jobsWritten;

        /// <summary>The settings the AI tools run with here, where they answer Ask AI: the model and thinking level
        /// chosen for Ask AI in the dashboard, else the recommended ones. The dashboard saves each job's choice to the
        /// settings file, so it is read again when the file changes.</summary>
        private AssistantSettings AskSettings()
        {
            try
            {
                var written = File.GetLastWriteTimeUtc(Store.FilePath);
                if (written != _jobsWritten)
                {
                    Settings.Jobs = Store.Load().Jobs;
                    _jobsWritten = written;
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                // Being saved just now: the choices read last time do.
            }

            var settings = SettingsStore.Clone(Settings);
            AiJobs.Apply(settings, AiJob.Ask);
            return settings;
        }

        /// <summary>What the dashboard's assistant remembers and its saved playbooks, read from the data folder, so the
        /// earlier side panel's answers use them too. They are changed only in the dashboard.</summary>
        private string MemorySnapshot()
        {
            try
            {
                var folder = DataFolders.Resolve(StorageSettingsStore.Beside(Store.FilePath).Load());
                var playbooks = PlaybookFile.PathIn(folder);
                return MemoryRules.Snapshot(new MemoryStore(() => folder, () => DateTime.Now).Load())
                    + (File.Exists(playbooks) ? PlaybookRules.Snapshot(PlaybookFile.Saved(File.ReadAllText(playbooks))) : "");
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return "";
            }
        }

        public AssistantSettings Settings { get; private set; }

        public ISecretProtector Protector { get; }

        public SecretStore Secrets { get; }

        public HttpClient Http { get; }

        public ProviderRouter Router { get; }

        public SqlServerQueryExecutor Database { get; }

        public BusinessAssistant Assistant { get; }

        /// <summary>Looks for a newer version now and then, and installs it when the owner says so.</summary>
        public UpdateService Updates { get; }

        public CodexCliProvider Codex => Router.Providers.OfType<CodexCliProvider>().First();

        public bool IsDatabaseConfigured =>
            !string.IsNullOrWhiteSpace(Settings.Database.Server) && !string.IsNullOrWhiteSpace(Settings.Database.Database);

        public string DatabaseDescription => IsDatabaseConfigured
            ? Settings.Database.Database + " on " + Settings.Database.Server
            : "not set up";

        /// <summary>What the saved settings add to a search: the POS folder, and the server and login in use.</summary>
        public PosSearchHints SearchHintsFromSettings()
        {
            var database = Settings.Database;
            var hints = new PosSearchHints { PosFolder = database.PosFolder ?? "" };
            if (IsDatabaseConfigured)
            {
                hints.Server = database.Server;
            }

            var password = Secrets.Get(SecretNames.DatabasePassword);
            if (!database.UseWindowsAuthentication && !string.IsNullOrWhiteSpace(database.UserName) && !string.IsNullOrEmpty(password))
            {
                hints.Login = new SqlLogin(database.UserName, password, "the saved login \"" + database.UserName.Trim() + "\"");
            }

            return hints;
        }

        /// <summary>Looks for the POS database on this PC; see <see cref="PosDatabaseFinder"/>. Only reads.</summary>
        public Task<PosDatabaseSearch> FindPosDatabaseAsync(PosSearchHints hints, CancellationToken cancellationToken)
        {
            var finder = new PosDatabaseFinder(
                new WindowsPosMachine(),
                target => new SqlServerQueryExecutor(() => SqlServerQueryExecutor.BuildConnectionString(target, connectTimeoutSeconds: 5), () => 15));
            return finder.FindAsync(hints, cancellationToken);
        }

        /// <summary>Saves a found database as the one to use.</summary>
        public void UseDatabase(PosDatabaseCandidate candidate)
        {
            var updated = SettingsStore.Clone(Settings);
            updated.Database.Server = candidate.Server;
            updated.Database.Database = candidate.Database;
            updated.Database.UseWindowsAuthentication = candidate.Login.UseWindowsAuthentication;
            updated.Database.UserName = candidate.Login.UserName;
            if (candidate.PosFolder.Length > 0)
            {
                updated.Database.PosFolder = candidate.PosFolder;
            }

            new SecretStore(() => updated, Protector).Set(SecretNames.DatabasePassword, candidate.Login.Password);
            ApplySettings(updated);
        }

        /// <summary>Saves edited settings (a clone from the settings dialog) and makes them current.</summary>
        public void ApplySettings(AssistantSettings updated)
        {
            updated.Normalize();
            // The dashboard owns the poster offer limit, the sticker choices, the memory settings, each job's model
            // and thinking level, the owner's live view and camera search, and saves them itself: keep what is on disk.
            var onDisk = Store.Load();
            updated.Posters = onDisk.Posters;
            updated.Stickers = onDisk.Stickers;
            updated.Memory = onDisk.Memory;
            updated.Jobs = onDisk.Jobs;
            updated.OwnerView = onDisk.OwnerView;
            updated.CameraSearch = onDisk.CameraSearch;
            Store.Save(updated);
            Settings = updated;
            Router.InvalidateStatuses();
            Assistant.ForgetSchema();
        }

        public WindowsDashboardHost DashboardHost { get; } = new WindowsDashboardHost();

        /// <summary>Where the dashboard answers, always on this PC.</summary>
        public Uri DashboardUrl => DashboardSettings.IsLocal(Settings.Dashboard.Url, out var local) ? local : new Uri(DashboardSettings.DefaultUrl);

        /// <summary>Opens a page of the sales dashboard in the browser, starting the dashboard when it is not running.</summary>
        public Task<DashboardOpenResult> OpenDashboardAsync(string page, IProgress<string> progress, CancellationToken cancellationToken)
        {
            return new DashboardLauncher(DashboardHost).OpenAsync(
                Settings.Dashboard.ResolveExecutable(AppDomain.CurrentDomain.BaseDirectory), DashboardUrl, page, progress, cancellationToken);
        }

        /// <summary>
        /// The dashboard runs because this app started it although the saved POS database did not answer. The dashboard looks for
        /// the database once, when it starts, so it is showing the demo shop until it is started again
        /// (<see cref="StartDashboardAsync"/> with <c>restart</c>).
        /// </summary>
        public bool StartedWithoutPos { get; private set; }

        /// <summary>
        /// Starts the dashboard for the app's own windows, unless it is already running. When a POS database is saved, the dashboard
        /// waits up to <paramref name="patience"/> for it to answer first (<see cref="DashboardLauncher.StartAsync"/>).
        /// <paramref name="restart"/> stops the dashboard this app started and starts it again.
        /// </summary>
        public async Task<DashboardOpenResult> StartDashboardAsync(
            IProgress<string> progress, CancellationToken cancellationToken, TimeSpan patience = default(TimeSpan), bool restart = false)
        {
            if (restart)
            {
                StartedWithoutPos = false;
            }

            var result = await new DashboardLauncher(DashboardHost).StartAsync(
                Settings.Dashboard.ResolveExecutable(AppDomain.CurrentDomain.BaseDirectory), DashboardUrl, progress, cancellationToken,
                patience, IsDatabaseConfigured ? (Func<CancellationToken, Task<bool>>)PosAnswersAsync : null, restart).ConfigureAwait(false);
            if (result.Started)
            {
                StartedWithoutPos = result.StartedWithoutPos;
            }

            return result;
        }

        /// <summary>
        /// Whether the saved POS database answers, or another one on this PC does (the saved one may be out of date). Waiting for the
        /// database is a convenience, so whatever goes wrong here counts as "not yet": the dashboard is started as it always was.
        /// </summary>
        public async Task<bool> PosAnswersAsync(CancellationToken cancellationToken)
        {
            try
            {
                try
                {
                    await Database.QueryAsync("SELECT 1", null, 1, cancellationToken).ConfigureAwait(false);
                    return true;
                }
                catch (QueryExecutionException)
                {
                    // Not up yet, or not where it was saved: the search below says which.
                }

                var search = await FindPosDatabaseAsync(SearchHintsFromSettings(), cancellationToken).ConfigureAwait(false);
                return search.Best != null;
            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                AppLog.Error("Waiting for the POS database", ex);
                return false;
            }
        }

        public void Dispose()
        {
            Updates.Dispose();
            DashboardHost.Dispose();
            Http.Dispose();
        }
    }

    /// <summary>Errors only (never questions, answers or data), kept small.</summary>
    internal static class AppLog
    {
        private const long MaxBytes = 1024 * 1024;
        private static readonly object Gate = new object();

        public static string FilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Branding.Company,
            Branding.AppFolderName,
            "logs",
            "assistant.log");

        public static void Error(string context, Exception exception)
        {
            try
            {
                lock (Gate)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                    if (File.Exists(FilePath) && new FileInfo(FilePath).Length > MaxBytes)
                    {
                        File.Copy(FilePath, FilePath + ".old", overwrite: true);
                        File.Delete(FilePath);
                    }

                    File.AppendAllText(
                        FilePath,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + context + ": " + exception.GetType().Name + ": " + exception.Message + Environment.NewLine,
                        Encoding.UTF8);
                }
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}

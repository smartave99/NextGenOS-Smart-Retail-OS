using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using SmartRetail.AI.Data;
using SmartRetail.AI.Settings;
using SmartRetail.AI.Updates;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// Runs Smart Retail POS with the new design, shown by WebView2: the app in its own window, and (in side panel
    /// mode) the slim panel beside the POS with its "AI" tab, tray icon and shortcut. Both show pages of the
    /// dashboard, which this app starts and stops. Hiding the panel puts the cashier straight back where they were.
    /// </summary>
    internal sealed class AppHost : ApplicationContext
    {
        private static readonly int ProcessId = Process.GetCurrentProcess().Id;

        /// <summary>How often the app looks again for a POS database that was not there when the dashboard started: every 30 seconds
        /// for ten minutes (SQL Server coming up late), then every two minutes (a database on a PC that is switched off).</summary>
        private static readonly TimeSpan LookForPosEvery = TimeSpan.FromSeconds(30);
        private static readonly TimeSpan LookForPosSlowly = TimeSpan.FromMinutes(2);
        private const int LooksAtFirst = 20;

        private readonly AssistantApp _app;
        private readonly WindowsFormsSynchronizationContext _ui = new WindowsFormsSynchronizationContext();
        private readonly RegisteredWaitHandle _showRequests;
        private readonly Uri _dashboard;
        private readonly SmokeTest _smoke;
        private readonly AppWindow _window;
        private PanelWindow _panel;
        private EdgeTab _tab;
        private NotifyIcon _tray;
        private GlobalHotkey _hotkey;
        private string _activeShortcut;
        private IntPtr _returnTo;
        private Task<bool> _ready;
        private bool _panelOpened;
        private bool _toldAboutTray;
        private bool _settingsOpen;
        private bool _exiting;
        private bool _installingUpdate;
        private bool _restartingForPos;
        private readonly CancellationTokenSource _stopWatching = new CancellationTokenSource();
        private ToolStripMenuItem _updateItem;
        private string _toldAboutUpdate = "";

        /// <param name="startInBackground">Started with Windows: only the AI tab shows, until the cashier opens the panel.</param>
        /// <param name="showRequest">Set by a second copy of the app to bring this one to the front.</param>
        /// <param name="smoke">A check that the windows work on this PC, then exit (see <see cref="SmokeTest"/>).</param>
        public AppHost(AssistantApp app, bool startInBackground, WaitHandle showRequest, SmokeTest smoke = null)
        {
            _app = app;
            _smoke = smoke;
            _dashboard = app.DashboardUrl;
            _window = new AppWindow(_dashboard);
            _window.MessageReceived += (sender, message) => OnPageMessage(_window, message);
            _window.RetryRequested += (sender, args) => Retry();
            _window.HiddenOnClose += (sender, args) => TellAboutTray();
            _window.FormClosed += (sender, args) => Exit();
            _showRequests = ThreadPool.RegisterWaitForSingleObject(
                showRequest, (state, timedOut) => _ui.Post(_ => ShowApp(null), null), null, Timeout.Infinite, executeOnlyOnce: false);
            SystemEvents.DisplaySettingsChanged += OnDisplayChanged;
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
            app.Updates.Changed += OnUpdatesChanged;

            if (smoke != null)
            {
                _ready = PrepareAsync(findDatabase: false);
                _ = RunSmokeTestAsync();
                return;
            }

            if (StartupChoice.Effective(app.Settings.Panel.StartWithWindows, StartupRegistration.EntryExists(), StartupRegistration.SwitchedOffInWindows()))
            {
                // The setup's tick counts as the owner's choice, so Settings shows it and does not take it away. The entry is
                // kept pointing at this copy, even if the app folder was moved.
                app.Settings.Panel.StartWithWindows = true;
                StartupRegistration.Apply(true);
            }

            var firstRun = !app.IsDatabaseConfigured;
            // Started by Windows at sign-in, SQL Server may not answer yet: the dashboard is started once the POS database does.
            _ready = PrepareAsync(findDatabase: firstRun, patience: startInBackground ? PosReadiness.AtSignIn : PosReadiness.WhenOpenedByHand);
            _ = WatchForPosAsync();
            ApplyPanelMode();
            if (startInBackground && app.Settings.Panel.SidePanel && !firstRun)
            {
                ShowTab();
            }
            else
            {
                // First start after installing: Get started installs the AI tool and signs it in.
                ShowApp(firstRun ? "welcome" : "");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose runs twice (Application.Run ends the context, then the using in Program.Main): cancelling again does
                // nothing. The source has no timer and no wait handle, so it needs no Dispose of its own.
                _stopWatching.Cancel();
                _showRequests.Unregister(null);
                SystemEvents.DisplaySettingsChanged -= OnDisplayChanged;
                SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
                _app.Updates.Changed -= OnUpdatesChanged;
                RemovePanelChrome();
                _panel?.Dispose();
                _window.Dispose();
                _ui.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>On a first start, finds the POS database the way the side panel always has; then starts the dashboard.</summary>
        private async Task<bool> PrepareAsync(bool findDatabase, TimeSpan patience = default(TimeSpan), bool restart = false)
        {
            if (findDatabase)
            {
                ShowStatus("Looking for your shop’s data on this PC…");
                try
                {
                    var search = await _app.FindPosDatabaseAsync(_app.SearchHintsFromSettings(), CancellationToken.None);
                    if (search.Best != null && !_app.IsDatabaseConfigured)
                    {
                        _app.UseDatabase(search.Best);
                    }
                }
                catch (Exception ex)
                {
                    // The dashboard looks again by itself, and shows the demo shop if nothing is found.
                    AppLog.Error("Finding the POS database", ex);
                }
            }

            ShowStatus(restart ? "The POS database is ready. Restarting Smart Retail POS…" : "Starting Smart Retail POS…");
            try
            {
                var result = await _app.StartDashboardAsync(new Progress<string>(ShowStatus), CancellationToken.None, patience, restart);
                if (!result.Opened)
                {
                    ShowProblem(result.Problem);
                }

                return result.Opened;
            }
            catch (Exception ex) when (ex is System.ComponentModel.Win32Exception || ex is InvalidOperationException || ex is System.IO.IOException)
            {
                AppLog.Error("Starting the dashboard", ex);
                ShowProblem("Could not start the sales dashboard: " + ex.Message);
                return false;
            }
        }

        private void ShowStatus(string text)
        {
            _window.ShowStatus(text);
            _panel?.ShowStatus(text);
        }

        private void ShowProblem(string text)
        {
            _window.ShowProblem(text);
            _panel?.ShowProblem(text);
        }

        /// <summary>
        /// The dashboard looks for the POS database once, when it starts. When it had to be started before the database answered it
        /// shows the demo shop, so this looks again now and then and, once the database is there, starts it again.
        /// </summary>
        private async Task WatchForPosAsync()
        {
            var token = _stopWatching.Token;
            var looks = 0;
            while (!token.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(looks < LooksAtFirst ? LookForPosEvery : LookForPosSlowly, token);
                    if (_exiting || _restartingForPos || _installingUpdate || !_app.StartedWithoutPos)
                    {
                        looks = 0;
                        continue;
                    }

                    if (await _app.PosAnswersAsync(token))
                    {
                        looks = 0;
                        await RestartForPosAsync();
                    }
                    else
                    {
                        looks++;
                    }
                }
                catch (OperationCanceledException)
                {
                    return;
                }
                catch (Exception ex)
                {
                    // Looking again is a convenience: whatever went wrong, the app goes on and looks again later.
                    AppLog.Error("Looking again for the POS database", ex);
                }
            }
        }

        private async Task RestartForPosAsync()
        {
            _restartingForPos = true;
            try
            {
                _ready = PrepareAsync(findDatabase: false, patience: PosReadiness.WhenOpenedByHand, restart: true);
                if (!await _ready)
                {
                    return;
                }

                if (_window.HasPage)
                {
                    await _window.ReloadAsync();
                }

                if (_panel != null && _panelOpened)
                {
                    await _panel.ReloadAsync();
                }
            }
            finally
            {
                _restartingForPos = false;
            }
        }

        /// <summary>Try again after a problem: start the dashboard again, then show the pages again.</summary>
        private async void Retry()
        {
            _ready = PrepareAsync(findDatabase: false, patience: PosReadiness.WhenOpenedByHand);
            if (!await _ready)
            {
                return;
            }

            await _window.ReloadAsync();
            if (_panel != null && _panelOpened)
            {
                await _panel.ReloadAsync();
            }
        }

        /// <summary>Shows the app window, on <paramref name="page"/>, or where it was when null.</summary>
        private async void ShowApp(string page)
        {
            if (_exiting)
            {
                return;
            }

            _window.BringForward();
            if (!await _ready)
            {
                return;
            }

            if (page != null || !_window.HasPage)
            {
                await _window.OpenAsync(page ?? "");
            }

            _window.FocusPage();
        }

        private void OnPageMessage(WebWindow source, HostMessage message)
        {
            switch (message.Type)
            {
                case "settings":
                    OpenSettings(source);
                    break;
                case "open" when source == _window:
                    _ = _window.OpenAsync(message.Value);
                    break;
                case "dictate":
                    // The page put the cursor in Ask AI's box: Windows voice typing types what the owner says there.
                    VoiceTyping.Start();
                    break;
                case "startup" when source == _window:
                    // The owner turned Start with Windows on or off on the Settings page.
                    SetStartWithWindows(message.Value == "on");
                    break;
                case "update" when source == _window:
                    // The owner pressed Check now or Install now on the Updates card of Settings (the page asked first).
                    if (message.Value == "install")
                    {
                        InstallUpdate(confirm: false);
                    }
                    else if (message.Value == "check")
                    {
                        _ = _app.Updates.CheckAsync();
                    }

                    break;
            }
        }

        /// <summary>Saves the owner's choice to start with Windows, and makes the sign-in entry agree with it.</summary>
        private void SetStartWithWindows(bool on)
        {
            var edited = SettingsStore.Clone(_app.Settings);
            edited.Panel.StartWithWindows = on;
            _app.ApplySettings(edited);
            // Asked for by the owner, so a switch-off Windows kept for the entry is cleared too.
            var problem = StartupRegistration.Apply(on, switchOnInWindows: on);
            if (problem != null)
            {
                MessageBox.Show(problem, "Smart Retail POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ----- Updates -----

        /// <summary>Installs the update, when the owner said so: the setup starts, and the app quits for it.</summary>
        /// <param name="confirm">Ask first (the tray menu; the dashboard's card has asked already).</param>
        private async void InstallUpdate(bool confirm)
        {
            if (_exiting || _installingUpdate)
            {
                return;
            }

            _installingUpdate = true;
            try
            {
                if (await UpdatePrompt.InstallAsync(_app.Updates, confirm))
                {
                    Exit();
                }
            }
            finally
            {
                _installingUpdate = false;
            }
        }

        private void OnUpdatesChanged(object sender, EventArgs e) => _ui.Post(_ => ShowUpdateInTray(), null);

        /// <summary>The tray menu offers a ready update, and says so once for each version.</summary>
        private void ShowUpdateInTray()
        {
            if (_exiting || _tray == null || _updateItem == null)
            {
                return;
            }

            var status = _app.Updates.Status;
            var ready = status.State == UpdateState.Ready;
            _updateItem.Visible = ready;
            if (ready)
            {
                _updateItem.Text = UpdatePrompt.TrayText(status);
                if (_toldAboutUpdate != status.Available)
                {
                    _toldAboutUpdate = status.Available;
                    _tray.ShowBalloonTip(10000, "An update is ready", UpdatePrompt.BalloonText(status), ToolTipIcon.Info);
                }
            }
        }

        // ----- Side panel mode: the panel, its tab, the tray icon and the shortcut -----

        private void ApplyPanelMode()
        {
            var panel = _app.Settings.Panel;
            _window.HideOnClose = panel.SidePanel;
            if (!panel.SidePanel)
            {
                RemovePanelChrome();
                if (_panel != null)
                {
                    _panel.Hide();
                    _panel.Dispose();
                    _panel = null;
                    _panelOpened = false;
                }

                return;
            }

            if (_panel == null)
            {
                CreatePanel();
            }

            if (_tray == null)
            {
                _tray = new NotifyIcon { Icon = AppIcon.Get(), Text = "Smart Retail POS", ContextMenuStrip = BuildTrayMenu(), Visible = true };
                _tray.MouseClick += (sender, args) =>
                {
                    if (args.Button == MouseButtons.Left)
                    {
                        TogglePanel();
                    }
                };
                ShowUpdateInTray();
            }

            if (panel.ShowEdgeTab && _tab == null)
            {
                _tab = new EdgeTab();
                _tab.Click += (sender, args) => ShowPanel();
            }
            else if (!panel.ShowEdgeTab && _tab != null)
            {
                _tab.Dispose();
                _tab = null;
            }

            _hotkey?.Dispose();
            _hotkey = null;
            _activeShortcut = null;
            if (Hotkey.TryParse(panel.Shortcut, out var hotkey, out _))
            {
                _hotkey = new GlobalHotkey();
                _hotkey.Pressed += (sender, args) => TogglePanel();
                if (_hotkey.Register(hotkey))
                {
                    _activeShortcut = hotkey.ToString();
                }
                else
                {
                    _tray.ShowBalloonTip(8000, "Shortcut already in use",
                        "The shortcut " + hotkey + " is used by another program. Choose a different one in Settings → Side panel.", ToolTipIcon.Warning);
                }
            }

            _panel.UseEdge(panel.Edge);
            if (_panel.Visible)
            {
                PlacePanel();
            }
            else
            {
                ShowTab();
            }
        }

        private void CreatePanel()
        {
            _panel = new PanelWindow(_dashboard);
            _panel.HideRequested += (sender, args) => HidePanel(returnFocus: true);
            _panel.WidthToggled += (sender, args) => PlacePanel();
            _panel.SettingsRequested += (sender, args) => OpenSettings(_panel);
            _panel.RetryRequested += (sender, args) => Retry();
            _panel.MessageReceived += (sender, message) =>
            {
                if (message.Type != "settings")
                {
                    OnPageMessage(_panel, message);
                }
            };
            _panel.OpenAppRequested += (sender, page) =>
            {
                // The full window comes forward over the POS; the panel would only cover it.
                HidePanel(returnFocus: false);
                ShowApp(page);
            };
            _panel.FormClosing += (sender, args) =>
            {
                // Alt+F4 hides the panel; the app keeps running until Exit.
                if (!_exiting && args.CloseReason == CloseReason.UserClosing)
                {
                    args.Cancel = true;
                    HidePanel(returnFocus: true);
                }
            };
        }

        private async void ShowPanel()
        {
            if (_panel == null || _exiting)
            {
                return;
            }

            var front = NativeMethods.GetForegroundWindow();
            if (IsWorthReturningTo(front))
            {
                _returnTo = front;
            }

            PlacePanel();
            _tab?.Hide();
            _panel.Show();
            _panel.Activate();
            if (!_panelOpened)
            {
                _panelOpened = true;
                if (await _ready)
                {
                    await _panel.OpenAsync("panel");
                }
            }

            _panel.FocusQuestion();
        }

        private void HidePanel(bool returnFocus)
        {
            if (_panel == null || !_panel.Visible)
            {
                return;
            }

            _panel.Hide();
            ShowTab();
            if (returnFocus && _returnTo != IntPtr.Zero && NativeMethods.IsWindow(_returnTo))
            {
                NativeMethods.SetForegroundWindow(_returnTo);
            }

            _returnTo = IntPtr.Zero;
        }

        private void TogglePanel()
        {
            if (_panel == null)
            {
                ShowApp(null);
                return;
            }

            if (_panel.Visible && Form.ActiveForm == _panel)
            {
                HidePanel(returnFocus: true);
            }
            else
            {
                ShowPanel();
            }
        }

        private void PlacePanel()
        {
            if (_panel == null)
            {
                return;
            }

            var panel = _app.Settings.Panel;
            var bounds = PanelLayout.Panel(WorkArea(), panel.Edge, panel.Width, _panel.IsWide);
            _panel.Bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }

        private void ShowTab()
        {
            if (_tab == null || (_panel != null && _panel.Visible))
            {
                return;
            }

            var edge = _app.Settings.Panel.Edge;
            _tab.Place(PanelLayout.Tab(WorkArea(), edge), edge, "Open the AI panel" + (_activeShortcut == null ? "" : " (" + _activeShortcut + ")"));
            if (!_tab.Visible)
            {
                _tab.Show();
            }
        }

        private ContextMenuStrip BuildTrayMenu()
        {
            var menu = new ContextMenuStrip();
            var open = menu.Items.Add("Open Smart Retail POS", null, (sender, args) => ShowApp(null));
            open.Font = new Font(open.Font, FontStyle.Bold);
            menu.Items.Add("Side panel", null, (sender, args) => ShowPanel());
            menu.Items.Add("Settings…", null, (sender, args) => OpenSettings(null));
            _updateItem = new ToolStripMenuItem("Install update…", null, (sender, args) => InstallUpdate(confirm: true)) { Visible = false };
            menu.Items.Add(_updateItem);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("Exit", null, (sender, args) => Exit());
            return menu;
        }

        /// <summary>Once per run: closing the window does not stop the app beside the POS.</summary>
        private void TellAboutTray()
        {
            if (_toldAboutTray || _tray == null)
            {
                return;
            }

            _toldAboutTray = true;
            _tray.ShowBalloonTip(8000, "Smart Retail POS is still running",
                "Open it again from the AI tab on the screen edge or this icon. To close it completely, right-click the icon and choose Exit.",
                ToolTipIcon.Info);
        }

        private void RemovePanelChrome()
        {
            _hotkey?.Dispose();
            _hotkey = null;
            _activeShortcut = null;
            _tab?.Dispose();
            _tab = null;
            if (_tray != null)
            {
                _tray.Visible = false;
                _tray.ContextMenuStrip?.Dispose();
                _tray.Dispose();
                _tray = null;
                _updateItem = null;
            }
        }

        // ----- Settings -----

        /// <summary>The settings dialog (AI tools, database, privacy, side panel), as in earlier versions.</summary>
        private void OpenSettings(IWin32Window owner)
        {
            if (_settingsOpen || _exiting)
            {
                return;
            }

            _settingsOpen = true;
            try
            {
                var before = SettingsStore.Clone(_app.Settings);
                using (var dialog = new SettingsForm(_app) { StartPosition = FormStartPosition.CenterScreen })
                {
                    if (dialog.ShowDialog(owner) != DialogResult.OK)
                    {
                        return;
                    }

                    _app.ApplySettings(dialog.EditedSettings);
                }

                var problem = StartupRegistration.Apply(_app.Settings.Panel.StartWithWindows);
                if (problem != null)
                {
                    MessageBox.Show(problem, "Smart Retail POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ApplyPanelMode();
                if (!SameDatabase(before.Database, _app.Settings.Database))
                {
                    // The dashboard picks its database when it starts: start it again on the new one.
                    _app.DashboardHost.StopStarted();
                    Retry();
                }
            }
            finally
            {
                _settingsOpen = false;
            }
        }

        private static bool SameDatabase(DatabaseSettings a, DatabaseSettings b) =>
            string.Equals(a.Server, b.Server, StringComparison.OrdinalIgnoreCase)
            && string.Equals(a.Database, b.Database, StringComparison.OrdinalIgnoreCase)
            && a.UseWindowsAuthentication == b.UseWindowsAuthentication
            && string.Equals(a.UserName, b.UserName, StringComparison.OrdinalIgnoreCase);

        private void Exit()
        {
            if (_exiting)
            {
                return;
            }

            _exiting = true;
            RemovePanelChrome();
            _panel?.Close();
            _window.HideOnClose = false;
            if (!_window.IsDisposed)
            {
                _window.Close();
            }

            ExitThread();
        }

        // ----- The screen -----

        private void OnDisplayChanged(object sender, EventArgs e) => _ui.Post(_ => Reposition(), null);

        private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            // Moving or resizing the taskbar changes the work area.
            if (e.Category == UserPreferenceCategory.Desktop)
            {
                _ui.Post(_ => Reposition(), null);
            }
        }

        private void Reposition()
        {
            if (_panel == null || _exiting)
            {
                return;
            }

            if (_panel.Visible)
            {
                PlacePanel();
            }
            else
            {
                ShowTab();
            }
        }

        private static PixelRect WorkArea()
        {
            var area = Screen.PrimaryScreen.WorkingArea;
            return new PixelRect(area.X, area.Y, area.Width, area.Height);
        }

        /// <summary>
        /// A window of another program, such as the POS, that should get the focus back when the panel hides.
        /// Not the desktop or the taskbar: then Windows picks the next window itself.
        /// </summary>
        private static bool IsWorthReturningTo(IntPtr window)
        {
            if (window == IntPtr.Zero || !NativeMethods.IsWindowVisible(window) || window == NativeMethods.GetShellWindow())
            {
                return false;
            }

            NativeMethods.GetWindowThreadProcessId(window, out var processId);
            if (processId == ProcessId)
            {
                return false;
            }

            var className = new StringBuilder(64);
            NativeMethods.GetClassName(window, className, className.Capacity);
            switch (className.ToString())
            {
                case "Progman":
                case "WorkerW":
                case "Shell_TrayWnd":
                case "Shell_SecondaryTrayWnd":
                    return false;
                default:
                    return true;
            }
        }

        // ----- The check that the windows work on this PC -----

        private async Task RunSmokeTestAsync()
        {
            var report = new SmokeReport();
            try
            {
                report.WebView2 = WebViewSupport.IsAvailable(out var version) ? version : "";
                _window.Show();
                report.Dashboard = await SmokeTest.Within(_ready, TimeSpan.FromMinutes(2));
                if (!report.Dashboard)
                {
                    throw new InvalidOperationException("The dashboard did not start.");
                }

                await _window.OpenAsync("");
                report.Today = await WaitForAsync(_window, "!!document.querySelector('.hero, .load-error')");
                report.Title = (await _window.RunScriptAsync("document.title") ?? "").Trim('"');

                // Before the side panel, which stays on top and could cover the window's top bar.
                await TopBarCheck.RunAsync(_window, report, script => WaitForAsync(_window, script));

                CreatePanel();
                PlacePanel();
                _panel.Show();
                _panelOpened = true;
                await _panel.OpenAsync("panel");
                report.Panel = await WaitForAsync(_panel, "!!document.querySelector('.panel-page .composer textarea')");

                var answer = new TaskCompletionSource<string>();
                _panel.MessageReceived += (sender, message) =>
                {
                    if (message.Type == "ping")
                    {
                        answer.TrySetResult(message.Value);
                    }
                };
                await _panel.RunScriptAsync("srpos.send('ping', 'pong')");
                report.Bridge = await SmokeTest.Within(answer.Task.ContinueWith(t => t.Result == "pong", TaskScheduler.Default), TimeSpan.FromSeconds(15));

                await _window.OpenAsync("ask");
                report.Ask = await WaitForAsync(_window, "!!document.querySelector('.chat .composer textarea')");

                await _window.OpenAsync("posters");
                report.Posters = await WaitForAsync(_window, "!!document.querySelector('.poster-page .poster-kinds')");

                await _window.OpenAsync("barcodes?products=1");
                report.Barcodes = await WaitForAsync(_window, "!!document.querySelector('.label-page .sticker svg.barcode path')")
                    && await WaitForAsync(_panel, "!!document.querySelector('.panel-find input')");

                await _window.OpenAsync("fix-now");
                report.FixNow = await WaitForAsync(_window, "!!document.querySelector('.fix-summary')");

                await _window.OpenAsync("memory");
                report.Memory = await WaitForAsync(_window, "!!document.querySelector('.memory-part .memory-add input')");

                await _window.OpenAsync("actions");
                report.Actions = await WaitForAsync(_window, "!!document.querySelector('.page-head h1') && document.querySelector('.page-head h1').textContent === 'Actions and results'");

                await _window.OpenAsync("settings");
                report.Jobs = await WaitForAsync(_window, "document.querySelectorAll('.setting .ai-choice-chip').length === " + AiJobs.All.Count)
                    && await _window.RunScriptAsync("document.querySelector('.setting .ai-choice-chip').click(), true") == "true"
                    && await WaitForAsync(_window, "!!document.querySelector('.ai-choice-panel select')");
                report.Startup = await WaitForAsync(_window,
                    "(function () { var row = document.querySelector('#start-with-windows'); return !!row && row.offsetParent !== null && row.querySelectorAll('[role=radio]').length === 2; })()");
            }
            catch (Exception ex)
            {
                report.Error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                _smoke.Finish(report);
                Exit();
            }
        }

        /// <summary>Asks the page every half second until the script says true, for up to a minute.</summary>
        private static async Task<bool> WaitForAsync(WebWindow window, string script)
        {
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed < TimeSpan.FromMinutes(1))
            {
                if (await window.RunScriptAsync(script) == "true")
                {
                    return true;
                }

                await Task.Delay(500);
            }

            return false;
        }
    }
}

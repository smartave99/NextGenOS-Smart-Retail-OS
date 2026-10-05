using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// Runs the assistant as a normal window, or as a side panel beside the POS: a slim panel on the screen
    /// edge that stays above other windows, an "AI" tab and a tray icon that open it, and a shortcut that
    /// works while the POS is in front. Hiding the panel puts the cashier straight back where they were.
    /// </summary>
    internal sealed class AssistantHost : ApplicationContext
    {
        private static readonly int ProcessId = Process.GetCurrentProcess().Id;

        private readonly AssistantApp _app;
        private readonly WindowsFormsSynchronizationContext _ui = new WindowsFormsSynchronizationContext();
        private readonly RegisteredWaitHandle _showRequests;
        private MainForm _form;
        private EdgeTab _tab;
        private NotifyIcon _tray;
        private GlobalHotkey _hotkey;
        private string _activeShortcut;
        private IntPtr _returnTo;
        private bool _rebuilding;
        private bool _exiting;
        private bool _installingUpdate;
        private ToolStripMenuItem _updateItem;
        private string _toldAboutUpdate = "";

        /// <param name="showRequest">Set by a second copy of the app to bring this one to the front.</param>
        public AssistantHost(AssistantApp app, bool startHidden, WaitHandle showRequest)
        {
            _app = app;
            _showRequests = ThreadPool.RegisterWaitForSingleObject(
                showRequest, (state, timedOut) => _ui.Post(_ => ShowPanel(), null), null, Timeout.Infinite, executeOnlyOnce: false);
            SystemEvents.DisplaySettingsChanged += OnDisplayChanged;
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
            app.Updates.Changed += OnUpdatesChanged;
            if (StartupChoice.Effective(app.Settings.Panel.StartWithWindows, StartupRegistration.EntryExists(), StartupRegistration.SwitchedOffInWindows()))
            {
                // The setup's tick counts as the owner's choice, so Settings shows it and does not take it away. The entry is
                // kept pointing at this copy, even if the app folder was moved.
                app.Settings.Panel.StartWithWindows = true;
                StartupRegistration.Apply(true);
            }

            Build(startHidden);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _showRequests.Unregister(null);
                SystemEvents.DisplaySettingsChanged -= OnDisplayChanged;
                SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
                _app.Updates.Changed -= OnUpdatesChanged;
                RemovePanelChrome();
                _form?.Dispose();
                _ui.Dispose();
            }

            base.Dispose(disposing);
        }

        private void Build(bool startHidden)
        {
            var panel = _app.Settings.Panel;
            _form = new MainForm(_app, panel.SidePanel);
            _form.SettingsSaved += (sender, args) => _ui.Post(_ => ApplySettings(), null);
            _form.FormClosed += OnFormClosed;
            _form.UpdateRequested += (sender, args) => InstallUpdate();
            if (!panel.SidePanel)
            {
                // No tray icon in this layout: a ready update is offered in the window's status bar.
                ShowUpdate();
                _form.Show();
                return;
            }

            _form.HideRequested += (sender, args) => HidePanel();
            _form.WidthToggled += (sender, args) => PlacePanel();
            _form.FormClosing += OnPanelClosing;
            _tray = new NotifyIcon
            {
                Icon = AppIcon.Get(),
                Text = Branding.AssistantName,
                ContextMenuStrip = BuildTrayMenu(),
                Visible = true,
            };
            _tray.MouseClick += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    TogglePanel();
                }
            };
            ShowUpdate();

            ApplyPanelSettings();
            if (startHidden && _app.IsDatabaseConfigured)
            {
                ShowTab();
            }
            else
            {
                ShowPanel();
            }
        }

        /// <summary>Edge tab, shortcut and position, from the current settings.</summary>
        private void ApplyPanelSettings()
        {
            var panel = _app.Settings.Panel;
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
                    _form.ShowNotice("The shortcut " + hotkey + " is already used by another program. Choose a different one in Settings → Side panel.");
                }
            }

            _form.UseEdge(panel.Edge);
            if (_form.Visible)
            {
                PlacePanel();
            }
            else
            {
                ShowTab();
            }
        }

        private void ShowPanel()
        {
            if (_form == null || _form.IsDisposed)
            {
                return;
            }

            if (!_form.IsSidePanel)
            {
                if (_form.WindowState == FormWindowState.Minimized)
                {
                    _form.WindowState = FormWindowState.Normal;
                }

                _form.Show();
                _form.Activate();
                return;
            }

            var front = NativeMethods.GetForegroundWindow();
            if (IsWorthReturningTo(front))
            {
                _returnTo = front;
            }

            PlacePanel();
            _tab?.Hide();
            _form.Show();
            _form.Activate();
            _form.FocusQuestion();
        }

        private void HidePanel()
        {
            if (_form == null || _form.IsDisposed || !_form.IsSidePanel)
            {
                return;
            }

            _form.Hide();
            ShowTab();
            if (_returnTo != IntPtr.Zero && NativeMethods.IsWindow(_returnTo))
            {
                NativeMethods.SetForegroundWindow(_returnTo);
            }

            _returnTo = IntPtr.Zero;
        }

        private void TogglePanel()
        {
            if (_form == null || _form.IsDisposed)
            {
                return;
            }

            if (_form.IsSidePanel && _form.Visible && Form.ActiveForm == _form)
            {
                HidePanel();
            }
            else
            {
                ShowPanel();
            }
        }

        private void PlacePanel()
        {
            var panel = _app.Settings.Panel;
            var bounds = PanelLayout.Panel(WorkArea(), panel.Edge, panel.Width, _form.IsWide);
            _form.Bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }

        private void ShowTab()
        {
            if (_tab == null || _form.Visible)
            {
                return;
            }

            var edge = _app.Settings.Panel.Edge;
            _tab.Place(PanelLayout.Tab(WorkArea(), edge), edge, "Open the AI assistant" + (_activeShortcut == null ? "" : " (" + _activeShortcut + ")"));
            if (!_tab.Visible)
            {
                _tab.Show();
            }
        }

        private ContextMenuStrip BuildTrayMenu()
        {
            var menu = new ContextMenuStrip();
            var open = menu.Items.Add("Open the assistant", null, (sender, args) => ShowPanel());
            open.Font = new Font(open.Font, FontStyle.Bold);
            menu.Items.Add("Sales dashboard", null, async (sender, args) => await _form.OpenDashboardAsync());
            menu.Items.Add("Settings…", null, async (sender, args) =>
            {
                ShowPanel();
                await _form.ShowSettingsAsync();
            });
            _updateItem = new ToolStripMenuItem("Install update…", null, (sender, args) => InstallUpdate()) { Visible = false };
            menu.Items.Add(_updateItem);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("Exit", null, (sender, args) => Exit());
            return menu;
        }

        /// <summary>Without WebView2 the dashboard is in the browser, which cannot start the setup: the window's status bar and the tray menu offer a ready update.</summary>
        private async void InstallUpdate()
        {
            if (_exiting || _installingUpdate)
            {
                return;
            }

            _installingUpdate = true;
            try
            {
                if (await UpdatePrompt.InstallAsync(_app.Updates, confirm: true))
                {
                    Exit();
                }
            }
            finally
            {
                _installingUpdate = false;
            }
        }

        private void OnUpdatesChanged(object sender, EventArgs e) => _ui.Post(_ => ShowUpdate(), null);

        /// <summary>Shows a ready update where the owner can act on it: the window's status bar, and the tray menu and balloon where there is a tray.</summary>
        private void ShowUpdate()
        {
            if (_exiting || _form == null || _form.IsDisposed)
            {
                return;
            }

            var status = _app.Updates.Status;
            var ready = status.State == SmartRetail.AI.Updates.UpdateState.Ready;
            _form.ShowUpdate(ready ? UpdatePrompt.StatusBarText(status) : null);
            if (_tray == null || _updateItem == null)
            {
                return;
            }

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

        private void ApplySettings()
        {
            if (_form == null || _form.IsDisposed)
            {
                return;
            }

            var panel = _app.Settings.Panel;
            var problem = StartupRegistration.Apply(panel.StartWithWindows);
            if (problem != null)
            {
                _form.ShowNotice(problem);
            }

            if (panel.SidePanel != _form.IsSidePanel)
            {
                Rebuild();
            }
            else if (panel.SidePanel)
            {
                ApplyPanelSettings();
            }
        }

        /// <summary>Switches between the side panel and the normal window.</summary>
        private void Rebuild()
        {
            _rebuilding = true;
            try
            {
                RemovePanelChrome();
                var old = _form;
                _form = null;
                old.FormClosing -= OnPanelClosing;
                old.Close();
                old.Dispose();
                Build(startHidden: false);
            }
            finally
            {
                _rebuilding = false;
            }
        }

        private void OnPanelClosing(object sender, FormClosingEventArgs e)
        {
            // Alt+F4 hides the panel; the assistant keeps running in the tray until Exit.
            if (!_exiting && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                HidePanel();
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            // The normal window was closed, or Windows is shutting down.
            if (!_rebuilding)
            {
                _form = null;
                Exit();
            }
        }

        private void Exit()
        {
            if (_exiting)
            {
                return;
            }

            _exiting = true;
            RemovePanelChrome();
            _form?.Close();
            ExitThread();
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
            if (_form == null || _form.IsDisposed || !_form.IsSidePanel)
            {
                return;
            }

            if (_form.Visible)
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
    }
}

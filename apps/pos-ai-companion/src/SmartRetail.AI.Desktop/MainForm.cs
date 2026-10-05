using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    internal sealed class MainForm : Form
    {
        private static readonly Color HeaderColor = Color.FromArgb(31, 42, 68);
        private static readonly Color UserColor = Color.FromArgb(31, 91, 170);
        private static readonly Color AssistantColor = Color.FromArgb(22, 120, 72);
        private static readonly Color ProblemColor = Color.FromArgb(180, 40, 40);
        private static readonly Color MutedColor = Color.DimGray;

        private readonly AssistantApp _app;
        private readonly ComboBox _providerBox = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 280 };
        private readonly Label _providerStatus = new Label { AutoSize = true, Margin = new Padding(10, 8, 3, 3), ForeColor = MutedColor, Text = "Checking AI tools…" };
        private readonly Button _checkButton = new Button { Text = "Check AI tools", AutoSize = true };
        private readonly Button _settingsButton = new Button { Text = "Settings…", AutoSize = true };
        private readonly FlowLayoutPanel _insights = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true };
        private readonly RichTextBox _conversation = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true, BackColor = Color.White, BorderStyle = BorderStyle.None, DetectUrls = false };
        private readonly DataGridView _grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            RowHeadersVisible = false,
            BackgroundColor = SystemColors.Window,
            BorderStyle = BorderStyle.None,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
            ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText,
        };

        private readonly TextBox _sqlBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Both,
            WordWrap = false,
            Font = new Font("Consolas", 9f),
            BackColor = Color.FromArgb(248, 248, 248),
        };

        private readonly TextBox _questionBox = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11f) };
        private readonly Button _askButton = new Button { Text = "Ask", Width = 90, Height = 32 };
        private readonly Button _stopButton = new Button { Text = "Stop", Width = 80, Height = 32, Enabled = false };
        private readonly ToolStripStatusLabel _statusLabel = new ToolStripStatusLabel("Ready") { Spring = true, TextAlign = ContentAlignment.MiddleLeft };
        private readonly ToolStripStatusLabel _databaseLabel = new ToolStripStatusLabel();
        private readonly ToolStripStatusLabel _updateLabel = new ToolStripStatusLabel { IsLink = true, Visible = false, Margin = new Padding(8, 3, 8, 2) };
        private readonly SplitContainer _mainSplit = new SplitContainer { Dock = DockStyle.Fill, FixedPanel = FixedPanel.Panel1 };
        private readonly SplitContainer _rightSplit = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal };
        private readonly SplitContainer _resultSplit = new SplitContainer { Dock = DockStyle.Fill };
        private readonly ToolTip _toolTip = new ToolTip();
        private readonly Panel _edgeLine = new Panel { Dock = DockStyle.Left, Width = 1, BackColor = Color.FromArgb(150, 160, 180) };
        private readonly List<string> _pendingNotices = new List<string>();
        private Button _dashboardButton;
        private Button _widthButton;
        private CancellationTokenSource _running;
        private bool _settingsOpen;

        /// <param name="sidePanel">True for the slim panel beside the POS (placed by <see cref="AssistantHost"/>), false for a normal window.</param>
        public MainForm(AssistantApp app, bool sidePanel)
        {
            _app = app;
            IsSidePanel = sidePanel;
            Text = Branding.AssistantName;
            Icon = AppIcon.Get();
            Font = new Font("Segoe UI", 9.75f);
            _conversation.Font = new Font("Segoe UI", 10.5f);
            AcceptButton = _askButton;

            if (sidePanel)
            {
                FormBorderStyle = FormBorderStyle.None;
                TopMost = true;
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.Manual;
                MinimumSize = new Size(PanelSettings.MinimumWidth, 420);
                CueBanner.Set(_questionBox, "Ask anything, e.g. \"Aaj kitna cash aaya?\"");
                BuildSideLayout();
            }
            else
            {
                // Fit smaller shop screens such as 1366×768, where 1200×800 would run under the taskbar.
                var area = Screen.PrimaryScreen.WorkingArea;
                var bounds = PanelLayout.CenteredWindow(new PixelRect(area.X, area.Y, area.Width, area.Height), 1200, 800);
                MinimumSize = new Size(Math.Min(920, area.Width), Math.Min(620, area.Height));
                StartPosition = FormStartPosition.Manual;
                Bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
                CueBanner.Set(_questionBox, "Ask about sales, stock, customers or expenses — e.g. \"Top 5 products last week?\" or \"Aaj kitna cash aaya?\"");
                BuildLayout();
            }

            _updateLabel.Click += (sender, args) => UpdateRequested?.Invoke(this, EventArgs.Empty);
            _askButton.Click += async (sender, args) => await AskAsync();
            _stopButton.Click += (sender, args) => _running?.Cancel();
            _checkButton.Click += async (sender, args) => await ReportProvidersAsync();
            _settingsButton.Click += async (sender, args) => await OpenSettingsAsync();
            _providerBox.SelectedIndexChanged += async (sender, args) => await RefreshProviderStatusAsync(refresh: false);
        }

        /// <summary>Side panel: the user wants the panel out of the way (Hide button or Esc).</summary>
        public event EventHandler HideRequested;

        /// <summary>Side panel: the user switched between the normal and the wide panel.</summary>
        public event EventHandler WidthToggled;

        /// <summary>New settings were saved and applied.</summary>
        public event EventHandler SettingsSaved;

        /// <summary>The owner clicked the line that says an update is ready.</summary>
        public event EventHandler UpdateRequested;

        public bool IsSidePanel { get; }

        public bool IsWide { get; private set; }

        private string SelectedProviderId => (_providerBox.SelectedItem as ProviderChoice)?.Id ?? ProviderIds.Auto;

        public void FocusQuestion()
        {
            _questionBox.Focus();
            _questionBox.SelectAll();
        }

        public Task ShowSettingsAsync() => OpenSettingsAsync();

        /// <summary>
        /// Says in the status bar that an update is ready, and installs it when the owner clicks it: without WebView2 the dashboard
        /// is in a browser, which cannot start the setup, and the normal window has no tray icon. Null hides the line.
        /// </summary>
        public void ShowUpdate(string text)
        {
            _updateLabel.Text = text ?? "";
            _updateLabel.ToolTipText = string.IsNullOrEmpty(text) ? "" : "The app closes, updates and opens again by itself. Your settings, photos and plans are kept.";
            _updateLabel.Visible = !string.IsNullOrEmpty(text);
        }

        /// <summary>A message for the user; kept until the window is first shown.</summary>
        public void ShowNotice(string text)
        {
            if (IsHandleCreated)
            {
                AppendMessage("Notice", text, ProblemColor);
            }
            else
            {
                _pendingNotices.Add(text);
            }
        }

        /// <summary>Draws the panel's border line on the side that faces the POS.</summary>
        public void UseEdge(PanelEdge edge)
        {
            _edgeLine.Dock = edge == PanelEdge.Left ? DockStyle.Right : DockStyle.Left;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (IsSidePanel && keyData == Keys.Escape)
            {
                HideRequested?.Invoke(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (IsSidePanel)
            {
                _rightSplit.SplitterDistance = Math.Max(_rightSplit.Panel1MinSize, (int)(_rightSplit.Height * 0.6));
            }
            else
            {
                _mainSplit.SplitterDistance = 230;
                _rightSplit.SplitterDistance = (int)(_rightSplit.Height * 0.55);
                _resultSplit.SplitterDistance = (int)(_resultSplit.Width * 0.62);
            }

            PopulateProviders();
            UpdateDatabaseLabel();
            AppendMessage(
                Branding.AssistantName,
                "Ask questions about your sales, stock, customers and expenses in English or Hindi. "
                + "The assistant only reads your data; it never changes anything in the POS." + Environment.NewLine
                + "Try a quick insight " + (IsSidePanel ? "above" : "on the left") + ", or type a question below."
                + (_app.IsDatabaseConfigured ? "" : Environment.NewLine + Environment.NewLine
                    + "Looking for the POS database on this PC…"),
                AssistantColor);
            foreach (var notice in _pendingNotices)
            {
                AppendMessage("Notice", notice, ProblemColor);
            }

            _pendingNotices.Clear();
            var firstRun = !_app.IsDatabaseConfigured;
            var finding = firstRun ? FindDatabaseOnFirstRunAsync() : Task.CompletedTask;
            await RefreshProviderStatusAsync(refresh: false);
            await finding;
            if (firstRun && !IsDisposed)
            {
                // First start after installing: the dashboard's Get started page installs the AI tool and signs it in.
                await OpenDashboardAsync("welcome");
            }
        }

        /// <summary>First start: finds the POS database without asking, then says what it found.</summary>
        private async Task FindDatabaseOnFirstRunAsync()
        {
            PosDatabaseSearch search;
            try
            {
                search = await _app.FindPosDatabaseAsync(_app.SearchHintsFromSettings(), CancellationToken.None);
            }
            catch (Exception ex)
            {
                AppLog.Error("Finding the POS database", ex);
                search = new PosDatabaseSearch(new PosDatabaseCandidate[0], new[] { "The search stopped: " + ex.Message });
            }

            if (IsDisposed || _app.IsDatabaseConfigured)
            {
                // Closed, or set up by hand while the search ran.
                return;
            }

            var best = search.Best;
            if (best == null)
            {
                AppendMessage(
                    "Setup needed",
                    "Could not find the POS database on this PC by itself:" + Environment.NewLine
                    + string.Join(Environment.NewLine, search.Steps.Select(step => "• " + step)) + Environment.NewLine + Environment.NewLine
                    + "Open Settings → Database, choose the POS folder or type the SQL Server, then click \"Find automatically\".",
                    ProblemColor);
                return;
            }

            _app.UseDatabase(best);
            UpdateDatabaseLabel();
            var text = "Found the POS database by itself: " + best.Describe() + Environment.NewLine
                + "The assistant only reads it; it never changes anything in the POS.";
            if (best.LoginCanWrite)
            {
                text += Environment.NewLine + Environment.NewLine + "It signs in the way the POS does, with a login that could change data. "
                    + "For extra safety, set up the read-only login (see Settings → Database).";
            }

            var others = search.Candidates.Skip(1).Select(candidate => candidate.Database + " on " + candidate.Server).ToList();
            if (others.Count > 0)
            {
                text += Environment.NewLine + Environment.NewLine + "Also found " + string.Join(", ", others)
                    + ". To use another one, open Settings → Database → \"Find automatically\".";
            }

            AppendMessage(Branding.AssistantName, text, AssistantColor);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _running?.Cancel();
            base.OnFormClosing(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && IsSidePanel)
            {
                // Parts of the normal window that the side panel does not use, so they are not in Controls.
                _mainSplit.Dispose();
                _resultSplit.Dispose();
                _sqlBox.Dispose();
                _checkButton.Dispose();
            }

            base.Dispose(disposing);
        }

        private void BuildLayout()
        {
            var header = new Panel { Dock = DockStyle.Top, Height = 54, BackColor = HeaderColor };
            header.Controls.Add(new Label
            {
                Text = "by " + Branding.Company,
                ForeColor = Color.FromArgb(190, 200, 220),
                Dock = DockStyle.Right,
                Width = 160,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 16, 0),
            });
            header.Controls.Add(new Label
            {
                Text = Branding.Product + "  ·  AI Assistant",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 14f),
                AutoSize = true,
                Location = new Point(16, 13),
            });

            var toolbar = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 46, Padding = new Padding(10, 8, 10, 4), WrapContents = false };
            toolbar.Controls.Add(new Label { Text = "AI:", AutoSize = true, Margin = new Padding(3, 8, 3, 3) });
            toolbar.Controls.AddRange(new Control[] { _providerBox, _checkButton, _settingsButton, _providerStatus });

            var insightsGroup = new GroupBox { Text = "Quick insights", Dock = DockStyle.Fill, Padding = new Padding(8) };
            AddInsightButtons(200, 36);
            insightsGroup.Controls.Add(_insights);

            _resultSplit.Panel1.Controls.Add(Titled("Result", _grid));
            _resultSplit.Panel2.Controls.Add(Titled("SQL used (read-only)", _sqlBox));
            _rightSplit.Panel1.Controls.Add(_conversation);
            _rightSplit.Panel2.Controls.Add(_resultSplit);
            _mainSplit.Panel1.Controls.Add(insightsGroup);
            _mainSplit.Panel2.Controls.Add(_rightSplit);

            var askPanel = new TableLayoutPanel { Dock = DockStyle.Bottom, Height = 50, ColumnCount = 3, Padding = new Padding(10, 7, 10, 7) };
            askPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            askPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            askPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            askPanel.Controls.Add(_questionBox, 0, 0);
            askPanel.Controls.Add(_askButton, 1, 0);
            askPanel.Controls.Add(_stopButton, 2, 0);

            var status = new StatusStrip();
            status.Items.AddRange(new ToolStripItem[] { _statusLabel, _updateLabel, _databaseLabel });

            // Docking runs from the last-added control inwards, so the Fill area goes in first.
            Controls.Add(_mainSplit);
            Controls.Add(askPanel);
            Controls.Add(status);
            Controls.Add(toolbar);
            Controls.Add(header);
        }

        /// <summary>The slim panel: everything in one column, the result table under the conversation.</summary>
        private void BuildSideLayout()
        {
            var header = new Panel { Dock = DockStyle.Top, Height = 46, BackColor = HeaderColor };
            var actions = new FlowLayoutPanel { Dock = DockStyle.Right, AutoSize = true, WrapContents = false, BackColor = HeaderColor, Padding = new Padding(0, 8, 6, 0) };
            StyleHeaderButton(_settingsButton, "Settings", "Settings");
            _widthButton = HeaderButton("Wider", "Make the panel wider, for big tables");
            _widthButton.Click += (sender, args) =>
            {
                IsWide = !IsWide;
                _widthButton.Text = IsWide ? "Narrower" : "Wider";
                _toolTip.SetToolTip(_widthButton, IsWide ? "Back to the normal width" : "Make the panel wider, for big tables");
                WidthToggled?.Invoke(this, EventArgs.Empty);
            };
            var hide = HeaderButton("Hide", "Hide the panel and go back to the POS (Esc)");
            hide.Click += (sender, args) => HideRequested?.Invoke(this, EventArgs.Empty);
            actions.Controls.AddRange(new Control[] { _settingsButton, _widthButton, hide });
            header.Controls.Add(actions);
            header.Controls.Add(new Label
            {
                Text = Branding.Product + " · AI",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10.5f),
                AutoSize = true,
                Location = new Point(12, 14),
            });

            var providerRow = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2, RowCount = 2, Padding = new Padding(8, 8, 8, 0) };
            providerRow.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            providerRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            providerRow.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            providerRow.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            providerRow.Controls.Add(new Label { Text = "AI:", AutoSize = true, Margin = new Padding(3, 7, 3, 3) }, 0, 0);
            _providerBox.Dock = DockStyle.Fill;
            providerRow.Controls.Add(_providerBox, 1, 0);
            _providerStatus.Margin = new Padding(3, 5, 3, 3);
            _providerStatus.MaximumSize = new Size(PanelSettings.MinimumWidth - 40, 0);
            _providerStatus.Cursor = Cursors.Hand;
            _providerStatus.Click += async (sender, args) => await ReportProvidersAsync();
            providerRow.Controls.Add(_providerStatus, 0, 1);
            providerRow.SetColumnSpan(_providerStatus, 2);

            var insightsTitle = new Label { Text = "Quick insights", Dock = DockStyle.Top, Height = 26, ForeColor = MutedColor, Padding = new Padding(10, 8, 0, 0) };
            _insights.Dock = DockStyle.Top;
            _insights.FlowDirection = FlowDirection.LeftToRight;
            _insights.WrapContents = true;
            _insights.AutoScroll = false;
            _insights.AutoSize = true;
            _insights.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _insights.Padding = new Padding(6, 0, 6, 6);
            AddInsightButtons(196, 32);
            foreach (Button button in _insights.Controls)
            {
                button.Font = new Font("Segoe UI", 9f);
                button.AutoEllipsis = true;
            }

            _rightSplit.Panel1.Controls.Add(_conversation);
            _rightSplit.Panel2.Controls.Add(Titled("Result", _grid));

            _askButton.Width = 70;
            _stopButton.Width = 64;
            var askPanel = new TableLayoutPanel { Dock = DockStyle.Bottom, Height = 50, ColumnCount = 3, Padding = new Padding(8, 7, 8, 7) };
            askPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            askPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            askPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            askPanel.Controls.Add(_questionBox, 0, 0);
            askPanel.Controls.Add(_askButton, 1, 0);
            askPanel.Controls.Add(_stopButton, 2, 0);

            var status = new StatusStrip();
            status.Items.AddRange(new ToolStripItem[] { _statusLabel, _updateLabel, _databaseLabel });

            // Docking runs from the last-added control inwards: the border line spans the full height.
            Controls.Add(_rightSplit);
            Controls.Add(askPanel);
            Controls.Add(status);
            Controls.Add(_insights);
            Controls.Add(insightsTitle);
            Controls.Add(providerRow);
            Controls.Add(header);
            Controls.Add(_edgeLine);
        }

        private void AddInsightButtons(int width, int height)
        {
            foreach (var insight in QuickInsights.All)
            {
                var button = new Button { Text = insight.Title, Width = width, Height = height, TextAlign = ContentAlignment.MiddleLeft, Margin = new Padding(3, 3, 3, 5) };
                button.Click += async (sender, args) => await RunInsightAsync(insight);
                _toolTip.SetToolTip(button, insight.Question);
                _insights.Controls.Add(button);
            }

            // In the side panel the buttons wrap two to a row, so the dashboard button takes a whole row.
            _dashboardButton = new Button
            {
                Text = "Sales dashboard and growth plan  ›",
                Width = IsSidePanel ? width * 2 + 6 : width,
                Height = height + 4,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(3, 3, 3, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(79, 70, 229),
                ForeColor = Color.White,
                UseVisualStyleBackColor = false,
            };
            _dashboardButton.FlatAppearance.BorderSize = 0;
            _dashboardButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 56, 202);
            _dashboardButton.Click += async (sender, args) => await OpenDashboardAsync();
            _toolTip.SetToolTip(_dashboardButton, "Charts of sales, best and slow products, and an AI plan to grow sales, in the browser");
            _insights.Controls.Add(_dashboardButton);
        }

        /// <summary>Opens the sales dashboard in the browser, starting it first if needed.</summary>
        /// <param name="page">The dashboard page to open, e.g. "sales" or "welcome".</param>
        public async Task OpenDashboardAsync(string page = "sales")
        {
            if (_dashboardButton == null || !_dashboardButton.Enabled)
            {
                return;
            }

            _dashboardButton.Enabled = false;
            try
            {
                var result = await _app.OpenDashboardAsync(page, NewProgress(), CancellationToken.None);
                _statusLabel.Text = result.Opened ? "Dashboard opened" : "Ready";
                if (!result.Opened)
                {
                    AppendMessage("Sales dashboard", result.Problem, ProblemColor);
                }
            }
            catch (Exception ex) when (ex is System.ComponentModel.Win32Exception || ex is InvalidOperationException || ex is System.IO.IOException)
            {
                AppLog.Error("Opening the sales dashboard", ex);
                _statusLabel.Text = "Ready";
                AppendMessage("Sales dashboard", "Could not open the sales dashboard: " + ex.Message, ProblemColor);
            }
            finally
            {
                _dashboardButton.Enabled = true;
            }
        }

        private Button HeaderButton(string text, string toolTip)
        {
            var button = new Button();
            StyleHeaderButton(button, text, toolTip);
            return button;
        }

        private void StyleHeaderButton(Button button, string text, string toolTip)
        {
            button.Text = text;
            button.AutoSize = true;
            button.Height = 30;
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.White;
            button.BackColor = HeaderColor;
            button.UseVisualStyleBackColor = false;
            button.Margin = new Padding(3, 0, 3, 0);
            button.FlatAppearance.BorderColor = Color.FromArgb(78, 92, 128);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 72, 122);
            _toolTip.SetToolTip(button, toolTip);
        }

        private static Control Titled(string title, Control content)
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            panel.Controls.Add(content);
            panel.Controls.Add(new Label { Text = title, Dock = DockStyle.Top, Height = 22, ForeColor = MutedColor, Padding = new Padding(2, 4, 0, 0) });
            return panel;
        }

        private void PopulateProviders()
        {
            var selected = SelectedProviderId;
            var firstInAuto = _app.Router.PlanOrder(ProviderIds.Auto).FirstOrDefault();
            _providerBox.Items.Clear();
            _providerBox.Items.Add(new ProviderChoice(ProviderIds.Auto, "Auto" + (firstInAuto == null ? "" : " (" + firstInAuto.DisplayName + " first)")));
            foreach (var provider in _app.Router.Providers)
            {
                _providerBox.Items.Add(new ProviderChoice(provider.Id, provider.DisplayName));
            }

            var match = _providerBox.Items.Cast<ProviderChoice>().FirstOrDefault(choice => choice.Id == selected);
            _providerBox.SelectedItem = match ?? _providerBox.Items[0];
        }

        private void UpdateDatabaseLabel()
        {
            _databaseLabel.Text = "Database: " + _app.DatabaseDescription;
        }

        private async Task RefreshProviderStatusAsync(bool refresh)
        {
            var selection = SelectedProviderId;
            _providerStatus.Text = "Checking…";
            _providerStatus.ForeColor = MutedColor;
            try
            {
                foreach (var provider in _app.Router.PlanOrder(selection))
                {
                    var status = await _app.Router.GetStatusAsync(provider, refresh, CancellationToken.None);
                    if (selection != SelectedProviderId)
                    {
                        return; // the user picked something else meanwhile
                    }

                    if (status.IsReady || selection != ProviderIds.Auto)
                    {
                        ShowProviderStatus((status.IsReady ? "✓ " : "✗ ") + provider.DisplayName + " — " + status.Detail, status.IsReady);
                        return;
                    }
                }

                ShowProviderStatus(IsSidePanel
                    ? "✗ No AI tool is ready yet — click here for details."
                    : "✗ No AI tool is ready yet — click \"Check AI tools\" for details.", false);
            }
            catch (Exception ex)
            {
                AppLog.Error("Provider status", ex);
                ShowProviderStatus("✗ Could not check the AI tools: " + ex.Message, false);
            }
        }

        private void ShowProviderStatus(string text, bool ready)
        {
            _providerStatus.Text = text.Length > 110 ? text.Substring(0, 110) + "…" : text;
            _providerStatus.ForeColor = ready ? AssistantColor : ProblemColor;
            _toolTip.SetToolTip(_providerStatus, text);
        }

        private async Task ReportProvidersAsync()
        {
            if (_running != null || !_checkButton.Enabled)
            {
                return;
            }

            SetBusy(true, allowStop: false);
            try
            {
                _statusLabel.Text = "Checking the AI tools on this PC…";
                var report = new StringBuilder();
                foreach (var provider in _app.Router.Providers)
                {
                    var status = await _app.Router.GetStatusAsync(provider, refresh: true, CancellationToken.None);
                    report.Append(status.IsReady ? "✓ " : "✗ ").Append(provider.DisplayName).Append(" — ").Append(status.Detail);
                    if (status.Version.Length > 0)
                    {
                        report.Append(" [").Append(status.Version).Append(']');
                    }

                    report.AppendLine();
                }

                AppendMessage("AI tools on this PC", report.ToString(), AssistantColor);
            }
            finally
            {
                SetBusy(false, allowStop: false);
                _statusLabel.Text = "Ready";
            }

            await RefreshProviderStatusAsync(refresh: false);
        }

        private async Task OpenSettingsAsync()
        {
            // The tray menu can ask for settings too, so guard against a second dialog or a running request.
            if (_settingsOpen || _running != null)
            {
                return;
            }

            _settingsOpen = true;
            try
            {
                using (var dialog = new SettingsForm(_app))
                {
                    if (IsSidePanel)
                    {
                        // Centred on a slim panel at the screen edge, the dialog would hang off the screen.
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                    }

                    if (dialog.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }

                    _app.ApplySettings(dialog.EditedSettings);
                }
            }
            finally
            {
                _settingsOpen = false;
            }

            PopulateProviders();
            UpdateDatabaseLabel();
            await RefreshProviderStatusAsync(refresh: true);
            SettingsSaved?.Invoke(this, EventArgs.Empty);
        }

        private async Task AskAsync()
        {
            var question = _questionBox.Text.Trim();
            if (question.Length == 0 || _running != null || !EnsureDatabase())
            {
                return;
            }

            _questionBox.Clear();
            AppendMessage("You", question, UserColor);
            await RunAsync(token => _app.Assistant.AskAsync(question, SelectedProviderId, NewProgress(), token));
        }

        private async Task RunInsightAsync(QuickInsight insight)
        {
            if (_running != null || !EnsureDatabase())
            {
                return;
            }

            AppendMessage("You", insight.Question, UserColor);
            await RunAsync(async token =>
            {
                var summarize = await AnyProviderReadyAsync(token);
                return await _app.Assistant.RunInsightAsync(insight, SelectedProviderId, summarize, NewProgress(), token);
            });
        }

        private async Task RunAsync(Func<CancellationToken, Task<AssistantAnswer>> work)
        {
            _running = new CancellationTokenSource();
            SetBusy(true, allowStop: true);
            try
            {
                ShowAnswer(await work(_running.Token));
            }
            catch (OperationCanceledException)
            {
                AppendMessage("Stopped", "The request was cancelled.", MutedColor);
                _statusLabel.Text = "Cancelled";
            }
            catch (AiProviderException ex)
            {
                AppendMessage("AI problem", ex.Message, ProblemColor);
                _statusLabel.Text = "Ready";
            }
            catch (AssistantException ex)
            {
                AppendMessage("Problem", ex.Message, ProblemColor);
                if (!string.IsNullOrEmpty(ex.LastSql))
                {
                    _sqlBox.Text = ex.LastSql;
                }

                _statusLabel.Text = "Ready";
            }
            catch (Exception ex)
            {
                AppLog.Error("Request", ex);
                AppendMessage("Unexpected error", ex.Message, ProblemColor);
                _statusLabel.Text = "Ready";
            }
            finally
            {
                _running.Dispose();
                _running = null;
                SetBusy(false, allowStop: false);
            }
        }

        private async Task<bool> AnyProviderReadyAsync(CancellationToken cancellationToken)
        {
            foreach (var provider in _app.Router.PlanOrder(SelectedProviderId))
            {
                if ((await _app.Router.GetStatusAsync(provider, refresh: false, cancellationToken)).IsReady)
                {
                    return true;
                }
            }

            return false;
        }

        private bool EnsureDatabase()
        {
            if (_app.IsDatabaseConfigured)
            {
                return true;
            }

            AppendMessage("Setup needed", "Connect the assistant to the POS database first: Settings → Database → \"Find automatically\".", ProblemColor);
            return false;
        }

        private IProgress<string> NewProgress() => new Progress<string>(text => _statusLabel.Text = text);

        private void ShowAnswer(AssistantAnswer answer)
        {
            string text;
            if (!string.IsNullOrWhiteSpace(answer.Answer))
            {
                text = answer.Answer;
            }
            else if (answer.Result != null && answer.Result.Rows.Count == 0)
            {
                text = "No matching records.";
            }
            else
            {
                text = "Here is the report (no AI tool is ready, so there is no written summary).";
            }

            var who = answer.ProviderId == null ? "Report" : _app.Router.Find(answer.ProviderId)?.DisplayName ?? answer.ProviderId;
            AppendMessage(who, text, AssistantColor);
            ShowResult(answer.Result);
            _sqlBox.Text = answer.Sql ?? "";
            _statusLabel.Text = "Done in " + answer.Duration.TotalSeconds.ToString("0.0") + " s"
                + (answer.Result?.Truncated == true ? " · showing the first " + BusinessAssistant.MaxDisplayRows + " rows" : "");
        }

        private void ShowResult(QueryResult result)
        {
            if (result == null)
            {
                _grid.DataSource = null;
                return;
            }

            var table = new DataTable();
            var used = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var column in result.Columns)
            {
                var name = column;
                for (var n = 2; !used.Add(name); n++)
                {
                    name = column + " (" + n + ")";
                }

                table.Columns.Add(name, typeof(object));
            }

            foreach (var row in result.Rows)
            {
                table.Rows.Add(row);
            }

            _grid.DataSource = table;
        }

        private void AppendMessage(string who, string text, Color color)
        {
            _conversation.SelectionStart = _conversation.TextLength;
            _conversation.SelectionLength = 0;
            _conversation.SelectionFont = new Font(_conversation.Font, FontStyle.Bold);
            _conversation.SelectionColor = color;
            _conversation.AppendText(who + Environment.NewLine);
            _conversation.SelectionFont = _conversation.Font;
            _conversation.SelectionColor = Color.Black;
            _conversation.AppendText((text ?? "").Trim() + Environment.NewLine + Environment.NewLine);
            _conversation.ScrollToCaret();
        }

        private void SetBusy(bool busy, bool allowStop)
        {
            _askButton.Enabled = !busy;
            _stopButton.Enabled = busy && allowStop;
            _insights.Enabled = !busy;
            _checkButton.Enabled = !busy;
            _settingsButton.Enabled = !busy;
            _providerBox.Enabled = !busy;
            _questionBox.ReadOnly = busy;
        }

        private sealed class ProviderChoice
        {
            public ProviderChoice(string id, string text)
            {
                Id = id;
                Text = text;
            }

            public string Id { get; }

            public string Text { get; }

            public override string ToString() => Text;
        }
    }
}

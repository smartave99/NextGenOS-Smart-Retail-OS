using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Dashboard;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>Edits a copy of the settings; the caller applies it only when the user clicks Save.</summary>
    internal sealed class SettingsForm : Form
    {
        private readonly AssistantApp _app;
        private readonly AssistantSettings _settings;
        private readonly SecretStore _secrets;

        private ComboBox _preferred;
        private CheckBox _fallback;
        private ListBox _order;

        private TextBox _codexPath;
        private TextBox _codexModel;
        private ComboBox _codexEffort;
        private ComboBox _codexSandbox;
        private NumericUpDown _codexTimeout;
        private TextBox _claudePath;
        private TextBox _claudeModel;
        private ComboBox _claudeEffort;
        private NumericUpDown _claudeTimeout;
        private TextBox _agyPath;
        private TextBox _agyModel;
        private ComboBox _agyEffort;
        private NumericUpDown _agyTimeout;
        private CheckBox _agyUseKey;
        private TextBox _customName;
        private TextBox _customPath;
        private TextBox _customArgs;
        private TextBox _customModel;
        private TextBox _customJson;
        private CheckBox _customStdin;
        private NumericUpDown _customTimeout;

        private SecretField _openAiKey;
        private TextBox _openAiModel;
        private TextBox _openAiUrl;
        private SecretField _anthropicKey;
        private TextBox _anthropicModel;
        private SecretField _geminiKey;
        private TextBox _geminiModel;
        private TextBox _compatUrl;
        private SecretField _compatKey;
        private TextBox _compatModel;

        private TextBox _posFolder;
        private TextBox _server;
        private TextBox _database;
        private CheckBox _windowsAuth;
        private TextBox _user;
        private SecretField _dbPassword;
        private NumericUpDown _dbTimeout;
        private Label _dbResult;

        private CheckBox _mask;
        private CheckBox _allowSql;
        private NumericUpDown _maxRows;
        private TextBox _extraTables;

        private TabControl _tabs;
        private TabPage _panelPage;
        private CheckBox _sidePanel;
        private ComboBox _edge;
        private NumericUpDown _panelWidth;
        private CheckBox _edgeTab;
        private TextBox _shortcut;
        private CheckBox _startWithWindows;
        private TextBox _dashboardUrl;
        private TextBox _dashboardPath;

        public SettingsForm(AssistantApp app)
        {
            _app = app;
            _settings = SettingsStore.Clone(app.Settings);
            _secrets = new SecretStore(() => _settings, app.Protector);

            Text = "Settings — " + Branding.AssistantName;
            Icon = AppIcon.Get();
            Font = new Font("Segoe UI", 9.75f);
            Size = new Size(860, 720);
            MinimumSize = new Size(760, 560);
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            MinimizeBox = false;

            _tabs = new TabControl { Dock = DockStyle.Fill, Padding = new Point(12, 5) };
            _tabs.TabPages.Add(BuildProviderPage());
            _tabs.TabPages.Add(BuildCliPage());
            _tabs.TabPages.Add(BuildKeysPage());
            _tabs.TabPages.Add(BuildDatabasePage());
            _tabs.TabPages.Add(BuildPrivacyPage());
            _panelPage = BuildPanelPage();
            _tabs.TabPages.Add(_panelPage);

            var save = new Button { Text = "Save", Width = 100, Height = 32 };
            var cancel = new Button { Text = "Cancel", Width = 100, Height = 32, DialogResult = DialogResult.Cancel };
            save.Click += (sender, args) => Save();
            var buttons = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 48, FlowDirection = FlowDirection.RightToLeft, Padding = new Padding(10, 7, 10, 7) };
            buttons.Controls.AddRange(new Control[] { cancel, save });
            AcceptButton = save;
            CancelButton = cancel;

            Controls.Add(_tabs);
            Controls.Add(buttons);
        }

        public AssistantSettings EditedSettings => _settings;

        private TabPage BuildProviderPage()
        {
            var grid = FormLayout.NewGrid();
            FormLayout.Heading(grid, "Which AI answers");
            _preferred = FormLayout.Row(grid, "Preferred provider", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 300 });
            _preferred.Items.Add(new Choice(ProviderIds.Auto, "Auto (first ready tool in the order below)"));
            foreach (var provider in _app.Router.Providers)
            {
                _preferred.Items.Add(new Choice(provider.Id, provider.DisplayName));
            }

            _preferred.SelectedItem = _preferred.Items.Cast<Choice>().FirstOrDefault(c => c.Id == _settings.PreferredProvider) ?? _preferred.Items[0];
            _fallback = new CheckBox { Text = "If it fails, try the next ready provider automatically", AutoSize = true, Checked = _settings.FallbackToOtherProviders };
            FormLayout.Row(grid, "", _fallback);

            FormLayout.Heading(grid, "Order for Auto");
            _order = new ListBox { Width = 320, Height = 190 };
            foreach (var id in _settings.ProviderOrder)
            {
                var provider = _app.Router.Find(id);
                if (provider != null)
                {
                    _order.Items.Add(new Choice(id, provider.DisplayName));
                }
            }

            var up = new Button { Text = "Move up", AutoSize = true };
            var down = new Button { Text = "Move down", AutoSize = true };
            up.Click += (sender, args) => MoveSelected(-1);
            down.Click += (sender, args) => MoveSelected(1);
            var buttons = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
            buttons.Controls.AddRange(new Control[] { up, down });
            FormLayout.Row(grid, "Try in this order", FormLayout.Inline(_order, buttons));
            FormLayout.Note(grid, "Codex CLI is first by default. CLI tools use the account signed in on this PC; API providers use the keys on the API keys tab. The shop can put any provider first.");
            return FormLayout.Page("AI provider", grid);
        }

        private TabPage BuildCliPage()
        {
            var grid = FormLayout.NewGrid();

            FormLayout.Heading(grid, "Codex CLI (OpenAI) — recommended");
            _codexPath = PathRow(grid, _settings.Codex.ExecutablePath, "codex");
            _codexModel = FormLayout.Row(grid, "Model", FormLayout.Text(_settings.Codex.Model, 200));
            _codexEffort = FormLayout.Row(grid, "Reasoning effort", FormLayout.Choice(_settings.Codex.ReasoningEffort, "", "low", "medium", "high"));
            _codexSandbox = FormLayout.Row(grid, "Sandbox", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 });
            _codexSandbox.Items.AddRange(new object[] { "read-only", "workspace-write" });
            _codexSandbox.SelectedItem = _settings.Codex.SandboxMode == "workspace-write" ? "workspace-write" : "read-only";
            _codexTimeout = FormLayout.Row(grid, "Timeout (seconds)", FormLayout.Number(_settings.Codex.TimeoutSeconds, 15, 1800));
            var signIn = new Button { Text = "Sign in Codex with the OpenAI API key", AutoSize = true };
            signIn.Click += async (sender, args) => await SignInCodexAsync(signIn);
            FormLayout.Row(grid, "", signIn);
            FormLayout.Note(grid, "Install: Node.js, then \"npm install -g @openai/codex\". Sign in once with \"codex login\" (ChatGPT account), or use the button above with the OpenAI API key from the API keys tab. Leave model and effort empty to use Codex's defaults. Keep the sandbox on read-only; switch to workspace-write only if Codex reports a Windows sandbox error (it still runs in an empty temporary folder).");

            FormLayout.Heading(grid, "Claude CLI (Anthropic)");
            _claudePath = PathRow(grid, _settings.ClaudeCli.ExecutablePath, "claude");
            _claudeModel = FormLayout.Row(grid, "Model", FormLayout.Text(_settings.ClaudeCli.Model, 200));
            _claudeEffort = FormLayout.Row(grid, "Effort", FormLayout.Choice(_settings.ClaudeCli.Effort, "", "low", "medium", "high", "xhigh", "max"));
            FormLayout.Row(grid, "", ToolButtons(ProviderIds.ClaudeCli, _claudeModel, _claudeEffort));
            _claudeTimeout = FormLayout.Row(grid, "Timeout (seconds)", FormLayout.Number(_settings.ClaudeCli.TimeoutSeconds, 15, 1800));
            FormLayout.Note(grid, "Install Claude Code (PowerShell: irm https://claude.ai/install.ps1 | iex). It runs with the Anthropic API key from the API keys tab: Anthropic does not allow apps to use a Claude.ai subscription sign-in.");

            FormLayout.Heading(grid, "Antigravity CLI (Google)");
            _agyPath = PathRow(grid, _settings.Antigravity.ExecutablePath, "agy");
            _agyModel = FormLayout.Row(grid, "Model", FormLayout.Text(_settings.Antigravity.Model, 200));
            _agyEffort = FormLayout.Row(grid, "Effort", FormLayout.Choice(_settings.Antigravity.Effort, "", "low", "medium", "high"));
            FormLayout.Row(grid, "", ToolButtons(ProviderIds.AntigravityCli, _agyModel, _agyEffort));
            _agyTimeout = FormLayout.Row(grid, "Timeout (seconds)", FormLayout.Number(_settings.Antigravity.TimeoutSeconds, 15, 1800));
            _agyUseKey = new CheckBox { Text = "Use the Gemini API key instead of the Google sign-in", AutoSize = true, Checked = _settings.Antigravity.UseGeminiApiKey };
            FormLayout.Row(grid, "", _agyUseKey);
            FormLayout.Note(grid, "Install (PowerShell): irm https://antigravity.google/cli/install.ps1 | iex — then run \"agy\" once to sign in. Model names come from \"agy models\".");

            FormLayout.Heading(grid, "Custom CLI (any other tool)");
            _customName = FormLayout.Row(grid, "Display name", FormLayout.Text(_settings.CustomCli.DisplayName, 200));
            _customPath = PathRow(grid, _settings.CustomCli.ExecutablePath, null);
            _customArgs = FormLayout.Row(grid, "Arguments", FormLayout.Text(_settings.CustomCli.Arguments));
            _customModel = FormLayout.Row(grid, "Model ({model})", FormLayout.Text(_settings.CustomCli.Model, 200));
            _customStdin = new CheckBox { Text = "Send the prompt on standard input", AutoSize = true, Checked = _settings.CustomCli.PromptViaStdin };
            FormLayout.Row(grid, "", _customStdin);
            _customJson = FormLayout.Row(grid, "JSON answer field", FormLayout.Text(_settings.CustomCli.JsonResultField, 200));
            _customTimeout = FormLayout.Row(grid, "Timeout (seconds)", FormLayout.Number(_settings.CustomCli.TimeoutSeconds, 15, 1800));
            FormLayout.Note(grid, "Placeholders: {model}, {prompt_file}, {system_file}, {workdir}. Example for a local Ollama: program \"ollama\", arguments \"run {model}\", model \"llama3.1\", prompt on standard input, JSON field empty.");

            return FormLayout.Page("CLI tools", grid);
        }

        private TabPage BuildKeysPage()
        {
            var grid = FormLayout.NewGrid();
            FormLayout.Note(grid, "Keys are encrypted for this Windows user and never leave this PC except when sent to their own provider.");

            FormLayout.Heading(grid, "OpenAI (OpenAI API; also Codex sign-in)");
            _openAiKey = FormLayout.Row(grid, "API key", new SecretField(_secrets.Has(SecretNames.OpenAiApiKey)));
            _openAiModel = FormLayout.Row(grid, "Model", FormLayout.Text(_settings.OpenAi.Model, 200));
            _openAiUrl = FormLayout.Row(grid, "API address", FormLayout.Text(_settings.OpenAi.BaseUrl));

            FormLayout.Heading(grid, "Anthropic (Claude API and Claude CLI)");
            _anthropicKey = FormLayout.Row(grid, "API key", new SecretField(_secrets.Has(SecretNames.AnthropicApiKey)));
            _anthropicModel = FormLayout.Row(grid, "Model", FormLayout.Text(_settings.Anthropic.Model, 200));

            FormLayout.Heading(grid, "Google Gemini (Gemini API; optional for Antigravity CLI)");
            _geminiKey = FormLayout.Row(grid, "API key", new SecretField(_secrets.Has(SecretNames.GeminiApiKey)));
            _geminiModel = FormLayout.Row(grid, "Model", FormLayout.Text(_settings.Gemini.Model, 200));

            FormLayout.Heading(grid, "OpenAI-compatible server (Ollama, LM Studio, OpenRouter, …)");
            _compatUrl = FormLayout.Row(grid, "Server address", FormLayout.Text(_settings.OpenAiCompatible.BaseUrl));
            _compatKey = FormLayout.Row(grid, "API key (optional)", new SecretField(_secrets.Has(SecretNames.OpenAiCompatibleApiKey)));
            _compatModel = FormLayout.Row(grid, "Model", FormLayout.Text(_settings.OpenAiCompatible.Model, 200));
            FormLayout.Note(grid, "A local Ollama is usually http://localhost:11434/v1 and needs no key.");

            return FormLayout.Page("API keys", grid);
        }

        private TabPage BuildDatabasePage()
        {
            var grid = FormLayout.NewGrid();
            var db = _settings.Database;

            FormLayout.Heading(grid, "POS database");
            _posFolder = FormLayout.Text(db.PosFolder, 330);
            var browse = new Button { Text = "Browse…", AutoSize = true };
            var find = new Button { Text = "Find automatically", AutoSize = true };
            browse.Click += (sender, args) => BrowseFolder(_posFolder);
            find.Click += async (sender, args) => await FindAutomaticallyAsync(find);
            FormLayout.Row(grid, "POS install folder", FormLayout.Inline(_posFolder, browse, find));
            FormLayout.Note(grid, "\"Find automatically\" looks for the POS program and every SQL Server on this PC; the folder and server "
                + "below are optional hints. It only reads.");

            _server = FormLayout.Row(grid, "SQL Server", FormLayout.Text(db.Server, 260));
            _database = FormLayout.Text(db.Database, 260);
            var companies = new Button { Text = "Pick company…", AutoSize = true };
            companies.Click += async (sender, args) => await PickCompanyAsync(companies);
            FormLayout.Row(grid, "Company database", FormLayout.Inline(_database, companies));

            _windowsAuth = new CheckBox { Text = "Windows authentication", AutoSize = true, Checked = db.UseWindowsAuthentication };
            FormLayout.Row(grid, "", _windowsAuth);
            _user = FormLayout.Row(grid, "SQL login", FormLayout.Text(db.UserName, 200));
            _dbPassword = FormLayout.Row(grid, "Password", new SecretField(_secrets.Has(SecretNames.DatabasePassword)));
            _dbTimeout = FormLayout.Row(grid, "Query timeout (seconds)", FormLayout.Number(db.CommandTimeoutSeconds, 5, 300));
            _windowsAuth.CheckedChanged += (sender, args) => UpdateAuthFields();
            UpdateAuthFields();

            var test = new Button { Text = "Test connection", AutoSize = true };
            _dbResult = new Label { AutoSize = true, MaximumSize = new Size(520, 0), Margin = new Padding(8, 7, 3, 3) };
            test.Click += async (sender, args) => await TestConnectionAsync(test);
            FormLayout.Row(grid, "", FormLayout.Inline(test, _dbResult));
            FormLayout.Note(grid, "Recommended: create a read-only SQL login with sql\\create_readonly_login.sql (shipped with this app) and use it here instead of the POS's own administrator login.");

            return FormLayout.Page("Database", grid);
        }

        private TabPage BuildPrivacyPage()
        {
            var grid = FormLayout.NewGrid();
            var privacy = _settings.Privacy;
            FormLayout.Heading(grid, "What the AI may see");
            _mask = new CheckBox { Text = "Hide phone numbers, e-mail, addresses and tax IDs from the AI (recommended)", AutoSize = true, Checked = privacy.MaskContactDetails };
            FormLayout.Span(grid, _mask);
            _allowSql = new CheckBox { Text = "Let the AI write its own read-only queries (needed for typed questions)", AutoSize = true, Checked = privacy.AllowAiWrittenQueries };
            FormLayout.Span(grid, _allowSql);
            _maxRows = FormLayout.Row(grid, "Rows shared per answer", FormLayout.Number(privacy.MaxRowsSharedWithAi, 5, 500));
            _extraTables = FormLayout.Row(grid, "Extra tables", FormLayout.Text(string.Join(", ", privacy.ExtraAllowedTables)));
            FormLayout.Note(grid, "The AI can read sales, purchases, stock, customers, suppliers, payments and expenses. Tables holding passwords, API keys, licence data or logs are never shared, and bank account numbers are hidden. Every query is checked to be a single read-only SELECT before it runs.");
            return FormLayout.Page("Privacy", grid);
        }

        private TabPage BuildPanelPage()
        {
            var grid = FormLayout.NewGrid();
            var panel = _settings.Panel;
            FormLayout.Heading(grid, "Beside the POS");
            _sidePanel = new CheckBox { Text = "Show the assistant as a slim panel on the edge of the screen, above the POS", AutoSize = true, Checked = panel.SidePanel };
            FormLayout.Span(grid, _sidePanel);
            _edge = FormLayout.Row(grid, "Screen edge", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 });
            _edge.Items.AddRange(new object[] { "Right", "Left" });
            _edge.SelectedIndex = panel.Edge == PanelEdge.Left ? 1 : 0;
            _panelWidth = FormLayout.Row(grid, "Panel width (pixels)", FormLayout.Number(panel.Width, PanelSettings.MinimumWidth, PanelSettings.MaximumWidth));
            _edgeTab = new CheckBox { Text = "Show a small \"AI\" tab on the screen edge while the panel is hidden", AutoSize = true, Checked = panel.ShowEdgeTab };
            FormLayout.Row(grid, "", _edgeTab);
            _shortcut = FormLayout.Row(grid, "Shortcut", FormLayout.Text(panel.Shortcut, 200));
            CueBanner.Set(_shortcut, "Empty = no shortcut");
            _startWithWindows = new CheckBox { Text = "Start the assistant when Windows starts (it waits as the \"AI\" tab)", AutoSize = true, Checked = panel.StartWithWindows };
            FormLayout.Row(grid, "", _startWithWindows);
            FormLayout.Note(grid, "The panel floats above the POS and never changes it: the POS, its printers and its barcode scanner work exactly as before. Open the panel with the AI tab, the tray icon or the shortcut; press Esc or the shortcut again to go straight back to the POS. A shortcut must include Ctrl, Alt or Win, e.g. Ctrl+Shift+Space.");
            _sidePanel.CheckedChanged += (sender, args) => UpdatePanelFields();
            UpdatePanelFields();

            FormLayout.Heading(grid, "Sales dashboard");
            _dashboardUrl = FormLayout.Row(grid, "Address", FormLayout.Text(_settings.Dashboard.Url, 260));
            _dashboardPath = FormLayout.Text(_settings.Dashboard.ExecutablePath, 380);
            CueBanner.Set(_dashboardPath, "Empty = " + DashboardSettings.DefaultRelativePath + " next to this app");
            var browse = new Button { Text = "Browse…", AutoSize = true };
            browse.Click += (sender, args) =>
            {
                using (var dialog = new OpenFileDialog { Filter = "Programs (*.exe)|*.exe", Title = "The sales dashboard program" })
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        _dashboardPath.Text = dialog.FileName;
                    }
                }
            };
            FormLayout.Row(grid, "Program", FormLayout.Inline(_dashboardPath, browse));
            FormLayout.Note(grid, "The dashboard opens in the browser and stays on this PC; the address must start with http://127.0.0.1 or http://localhost.");
            return FormLayout.Page("Side panel", grid);
        }

        private void UpdatePanelFields()
        {
            foreach (var control in new Control[] { _edge, _panelWidth, _edgeTab, _shortcut, _startWithWindows })
            {
                control.Enabled = _sidePanel.Checked;
            }
        }

        private TextBox PathRow(TableLayoutPanel grid, string value, string command)
        {
            var box = FormLayout.Text(value, 380);
            if (command != null)
            {
                CueBanner.Set(box, "Empty = find \"" + command + "\" automatically");
            }

            var browse = new Button { Text = "Browse…", AutoSize = true };
            browse.Click += (sender, args) =>
            {
                using (var dialog = new OpenFileDialog { Filter = "Programs (*.exe;*.cmd;*.bat)|*.exe;*.cmd;*.bat|All files (*.*)|*.*" })
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        box.Text = dialog.FileName;
                    }
                }
            };
            FormLayout.Row(grid, "Program", FormLayout.Inline(box, browse));
            return box;
        }

        private void MoveSelected(int delta)
        {
            var index = _order.SelectedIndex;
            var target = index + delta;
            if (index < 0 || target < 0 || target >= _order.Items.Count)
            {
                return;
            }

            var item = _order.Items[index];
            _order.Items.RemoveAt(index);
            _order.Items.Insert(target, item);
            _order.SelectedIndex = target;
        }

        private void UpdateAuthFields()
        {
            _user.Enabled = !_windowsAuth.Checked;
            _dbPassword.Enabled = !_windowsAuth.Checked;
        }

        private void BrowseFolder(TextBox target)
        {
            using (var dialog = new FolderBrowserDialog { Description = "Select the folder where the POS is installed", SelectedPath = target.Text })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    target.Text = dialog.SelectedPath;
                }
            }
        }

        private async Task FindAutomaticallyAsync(Button button)
        {
            button.Enabled = false;
            ShowDbResult("Looking for the POS database…", true);
            try
            {
                var hints = new PosSearchHints { PosFolder = _posFolder.Text.Trim(), Server = _server.Text.Trim() };
                var password = _dbPassword.CurrentValue(_secrets, SecretNames.DatabasePassword);
                if (!_windowsAuth.Checked && _user.Text.Trim().Length > 0 && !string.IsNullOrEmpty(password))
                {
                    hints.Login = new SqlLogin(_user.Text, password, "the login \"" + _user.Text.Trim() + "\"");
                }

                var search = await _app.FindPosDatabaseAsync(hints, CancellationToken.None);
                var chosen = search.Best;
                if (chosen == null)
                {
                    ShowDbResult("Not found. " + string.Join(" ", search.Steps), false);
                    return;
                }

                if (search.Candidates.Count > 1)
                {
                    var choices = search.Candidates.Select((candidate, index) => new Choice(
                        index.ToString(CultureInfo.InvariantCulture),
                        candidate.Describe() + (candidate.InUseByPos ? "  (the POS uses this one)" : "")));
                    using (var picker = new PickerForm("Choose the POS database", choices))
                    {
                        if (picker.ShowDialog(this) != DialogResult.OK || picker.Selected == null)
                        {
                            ShowDbResult("Nothing changed.", true);
                            return;
                        }

                        chosen = search.Candidates[int.Parse(picker.Selected.Id, CultureInfo.InvariantCulture)];
                    }
                }

                if (chosen.PosFolder.Length > 0)
                {
                    _posFolder.Text = chosen.PosFolder;
                }

                _server.Text = chosen.Server;
                _database.Text = chosen.Database;
                _windowsAuth.Checked = chosen.Login.UseWindowsAuthentication;
                _user.Text = chosen.Login.UserName;
                if (chosen.Login.Password.Length > 0)
                {
                    _dbPassword.SetTyped(chosen.Login.Password);
                }

                ShowDbResult(
                    "Found " + chosen.Describe() + " Click Save to use it."
                    + (chosen.LoginCanWrite
                        ? " This login could change data; the assistant only reads, and the read-only login below makes that certain."
                        : " This login can only read."),
                    true);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private SqlServerQueryExecutor CurrentExecutor(string databaseOverride = null)
        {
            var settings = CurrentDatabaseSettings();
            var password = _dbPassword.CurrentValue(_secrets, SecretNames.DatabasePassword);
            return new SqlServerQueryExecutor(
                () => SqlServerQueryExecutor.BuildConnectionString(settings, password, databaseOverride),
                () => settings.CommandTimeoutSeconds);
        }

        private DatabaseSettings CurrentDatabaseSettings()
        {
            return new DatabaseSettings
            {
                PosFolder = _posFolder.Text.Trim(),
                Server = _server.Text.Trim(),
                Database = _database.Text.Trim(),
                UseWindowsAuthentication = _windowsAuth.Checked,
                UserName = _user.Text.Trim(),
                CommandTimeoutSeconds = (int)_dbTimeout.Value,
            };
        }

        private async Task TestConnectionAsync(Button button)
        {
            button.Enabled = false;
            ShowDbResult("Connecting…", true);
            try
            {
                var executor = CurrentExecutor();
                var server = await executor.QueryAsync(
                    "SELECT DB_NAME() AS DatabaseName, CAST(SERVERPROPERTY('ProductVersion') AS nvarchar(50)) AS Version",
                    null, 1, CancellationToken.None);
                var name = server.Rows.Count > 0 ? Convert.ToString(server.Rows[0][0]) : "?";
                var version = server.Rows.Count > 0 ? Convert.ToString(server.Rows[0][1]) : "?";
                try
                {
                    var bills = await executor.QueryAsync("SELECT COUNT(*) FROM InvoiceInfo", null, 1, CancellationToken.None);
                    ShowDbResult("Connected to " + name + " (SQL Server " + version + "), " + bills.Rows[0][0] + " bills found.", true);
                }
                catch (QueryExecutionException)
                {
                    ShowDbResult("Connected to " + name + ", but it does not look like a POS company database (no InvoiceInfo table), or this login cannot read it.", false);
                }
            }
            catch (QueryExecutionException ex)
            {
                ShowDbResult("Could not connect: " + ex.Message, false);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async Task PickCompanyAsync(Button button)
        {
            button.Enabled = false;
            try
            {
                var choices = new List<Choice>();
                try
                {
                    // The POS keeps its list of companies in its own master database.
                    var result = await CurrentExecutor("RaintechMaster_DB").QueryAsync(
                        "SELECT RTRIM(CompanyName), RTRIM(DBName) FROM dbo.RaintechMaster WHERE is_active = 1 ORDER BY 1",
                        null, 200, CancellationToken.None);
                    choices.AddRange(result.Rows.Select(row => new Choice(Convert.ToString(row[1]), row[0] + "  (" + row[1] + ")")));
                }
                catch (QueryExecutionException)
                {
                    var result = await CurrentExecutor("master").QueryAsync(
                        "SELECT name, name FROM sys.databases WHERE database_id > 4 ORDER BY name",
                        null, 500, CancellationToken.None);
                    choices.AddRange(result.Rows.Select(row => new Choice(Convert.ToString(row[0]), Convert.ToString(row[1]))));
                }

                if (choices.Count == 0)
                {
                    ShowDbResult("No company databases found on this server.", false);
                    return;
                }

                using (var picker = new PickerForm("Choose the company database", choices))
                {
                    if (picker.ShowDialog(this) == DialogResult.OK && picker.Selected != null)
                    {
                        _database.Text = picker.Selected.Id;
                    }
                }
            }
            catch (QueryExecutionException ex)
            {
                ShowDbResult("Could not list databases: " + ex.Message, false);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private void ShowDbResult(string text, bool ok)
        {
            _dbResult.Text = text;
            _dbResult.ForeColor = ok ? Color.FromArgb(22, 120, 72) : Color.FromArgb(180, 40, 40);
        }

        private static readonly System.Net.Http.HttpClient ToolHttp = new System.Net.Http.HttpClient { Timeout = Timeout.InfiniteTimeSpan };

        private ICliToolCare ToolCare()
        {
            ApplyToSettings();
            return new CliToolCare(new ProcessCliRunner(), () => _settings, _secrets, ToolHttp);
        }

        /// <summary>Two buttons under a tool's model and effort: choose a model from the tool's own list (with the thinking levels it takes), and look at the version and update.</summary>
        private Control ToolButtons(string providerId, TextBox model, ComboBox effort)
        {
            var choose = new Button { Text = "Choose a model from the list…", AutoSize = true };
            var update = new Button { Text = "Version and updates…", AutoSize = true };
            choose.Click += async (sender, args) => await ChooseModelAsync(providerId, model, effort, choose);
            update.Click += async (sender, args) => await ToolUpdateAsync(providerId, update);
            return FormLayout.Inline(choose, update);
        }

        private async Task ChooseModelAsync(string providerId, TextBox model, ComboBox effort, Button button)
        {
            button.Enabled = false;
            try
            {
                Cursor = Cursors.WaitCursor;
                var list = await ToolCare().ModelsAsync(providerId, CancellationToken.None);
                Cursor = Cursors.Default;
                if (list.Models.Count == 0)
                {
                    MessageBox.Show(this, list.Note, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillEfforts(effort, list.DefaultEfforts);
                    return;
                }

                using (var dialog = new ModelListForm(list))
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Chosen != null)
                    {
                        model.Text = dialog.Chosen.Id;
                        FillEfforts(effort, dialog.Chosen.Efforts);
                    }
                }
            }
            catch (CliToolException ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
                button.Enabled = true;
            }
        }

        /// <summary>The thinking levels of the chosen model: what was chosen stays when the model has it, else it is cleared (the tool's own default).</summary>
        private static void FillEfforts(ComboBox effort, System.Collections.Generic.IEnumerable<string> levels)
        {
            var current = effort.Text.Trim();
            var list = levels.ToList();
            effort.Items.Clear();
            effort.Items.Add("");
            effort.Items.AddRange(list.Cast<object>().ToArray());
            effort.Text = list.Contains(current) ? current : "";
            effort.Enabled = list.Count > 0;
        }

        private async Task ToolUpdateAsync(string providerId, Button button)
        {
            button.Enabled = false;
            try
            {
                Cursor = Cursors.WaitCursor;
                var care = ToolCare();
                var check = await care.CheckUpdateAsync(providerId, CancellationToken.None);
                Cursor = Cursors.Default;
                var name = check.Status.Name;
                if (check.Update == "install")
                {
                    MessageBox.Show(this, name + " is not on this PC. " + check.Status.InstallHint, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var version = check.Status.Version.Length > 0 ? "Version " + check.Status.Version + " is installed." : name + " is installed; it does not say its version.";
                var line = check.Update == "available" ? version + " A newer one, " + check.Latest + ", is out."
                    : check.Update == "current" ? version + " That is the newest (" + check.Latest + ")."
                    : version + " The newest version could not be found out just now.";
                if (!check.CanUpdate || check.Update == "current")
                {
                    MessageBox.Show(this, line + "\r\n\r\n" + check.How, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var ask = MessageBox.Show(this, line + "\r\n\r\n" + check.How + "\r\n\r\nUpdate " + name + " now? Please do not start an AI task until it is done.", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask != DialogResult.Yes)
                {
                    return;
                }

                Cursor = Cursors.WaitCursor;
                var done = await care.UpdateAsync(providerId, CancellationToken.None);
                Cursor = Cursors.Default;
                MessageBox.Show(this, done.Changed ? "Updated from " + done.Before + " to " + done.After + "." : (done.After.Length > 0 ? "Version " + done.After + " is installed; the update did not change it." : "The update finished."), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (CliToolException ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
                button.Enabled = true;
            }
        }

        /// <summary>A short list to choose a model from, with the thinking levels each takes.</summary>
        private sealed class ModelListForm : Form
        {
            private readonly ListBox _list = new ListBox { Dock = DockStyle.Fill, IntegralHeight = false };

            public ModelListForm(CliModelList models)
            {
                Text = "Choose a model";
                StartPosition = FormStartPosition.CenterParent;
                Size = new Size(620, 460);
                MinimizeBox = false;
                MaximizeBox = false;
                ShowInTaskbar = false;
                foreach (var model in models.Models)
                {
                    _list.Items.Add(new Entry(model));
                }

                var note = new Label { Text = models.Note, Dock = DockStyle.Top, AutoSize = false, Height = 52, ForeColor = Color.DimGray, Padding = new Padding(8, 8, 8, 0) };
                var ok = new Button { Text = "Use this model", DialogResult = DialogResult.OK, AutoSize = true };
                var cancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, AutoSize = true };
                var bar = new FlowLayoutPanel { Dock = DockStyle.Bottom, FlowDirection = FlowDirection.RightToLeft, Height = 44, Padding = new Padding(8) };
                bar.Controls.AddRange(new Control[] { cancel, ok });
                Controls.Add(_list);
                Controls.Add(note);
                Controls.Add(bar);
                AcceptButton = ok;
                CancelButton = cancel;
                _list.DoubleClick += (sender, args) => { if (_list.SelectedItem != null) { DialogResult = DialogResult.OK; } };
            }

            public CliModel Chosen => (_list.SelectedItem as Entry)?.Model;

            private sealed class Entry
            {
                public Entry(CliModel model) { Model = model; }

                public CliModel Model { get; }

                public override string ToString() =>
                    Model.Label + " (" + Model.Id + ")  —  " + (Model.Efforts.Count == 0 ? "no thinking level" : "thinking: " + string.Join(", ", Model.Efforts.Select(AiJobs.EffortName)));
            }
        }

        private async Task SignInCodexAsync(Button button)
        {
            var key = _openAiKey.CurrentValue(_secrets, SecretNames.OpenAiApiKey);
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show(this, "Enter the OpenAI API key on the API keys tab first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ApplyToSettings();
            button.Enabled = false;
            try
            {
                var codex = new CodexCliProvider(new ProcessCliRunner(), () => _settings);
                var message = await codex.SignInWithApiKeyAsync(key, CancellationToken.None);
                MessageBox.Show(this, "Codex: " + message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (AiProviderException ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private void ApplyToSettings()
        {
            _settings.PreferredProvider = (_preferred.SelectedItem as Choice)?.Id ?? ProviderIds.Auto;
            _settings.FallbackToOtherProviders = _fallback.Checked;
            _settings.ProviderOrder = _order.Items.Cast<Choice>().Select(c => c.Id).ToList();

            ReadCli(_settings.Codex, _codexPath, _codexModel, _codexTimeout);
            _settings.Codex.ReasoningEffort = _codexEffort.Text.Trim();
            _settings.Codex.SandboxMode = (string)_codexSandbox.SelectedItem ?? "read-only";
            ReadCli(_settings.ClaudeCli, _claudePath, _claudeModel, _claudeTimeout);
            _settings.ClaudeCli.Effort = _claudeEffort.Text.Trim();
            ReadCli(_settings.Antigravity, _agyPath, _agyModel, _agyTimeout);
            _settings.Antigravity.Effort = _agyEffort.Text.Trim();
            _settings.Antigravity.UseGeminiApiKey = _agyUseKey.Checked;
            ReadCli(_settings.CustomCli, _customPath, _customModel, _customTimeout);
            _settings.CustomCli.DisplayName = _customName.Text.Trim();
            _settings.CustomCli.Arguments = _customArgs.Text.Trim();
            _settings.CustomCli.JsonResultField = _customJson.Text.Trim();
            _settings.CustomCli.PromptViaStdin = _customStdin.Checked;

            _settings.OpenAi.Model = _openAiModel.Text.Trim();
            _settings.OpenAi.BaseUrl = _openAiUrl.Text.Trim();
            _settings.Anthropic.Model = _anthropicModel.Text.Trim();
            _settings.Gemini.Model = _geminiModel.Text.Trim();
            _settings.OpenAiCompatible.BaseUrl = _compatUrl.Text.Trim();
            _settings.OpenAiCompatible.Model = _compatModel.Text.Trim();

            _settings.Database = CurrentDatabaseSettings();

            _settings.Privacy.MaskContactDetails = _mask.Checked;
            _settings.Privacy.AllowAiWrittenQueries = _allowSql.Checked;
            _settings.Privacy.MaxRowsSharedWithAi = (int)_maxRows.Value;
            _settings.Privacy.ExtraAllowedTables = _extraTables.Text
                .Split(new[] { ',', ';', '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            _settings.Panel.SidePanel = _sidePanel.Checked;
            _settings.Panel.Edge = _edge.SelectedIndex == 1 ? PanelEdge.Left : PanelEdge.Right;
            _settings.Panel.Width = (int)_panelWidth.Value;
            _settings.Panel.ShowEdgeTab = _edgeTab.Checked;
            _settings.Panel.Shortcut = _shortcut.Text.Trim();
            _settings.Panel.StartWithWindows = _startWithWindows.Checked;
            _settings.Dashboard.Url = _dashboardUrl.Text.Trim();
            _settings.Dashboard.ExecutablePath = _dashboardPath.Text.Trim();
        }

        private static void ReadCli(CliProviderSettings target, TextBox path, TextBox model, NumericUpDown timeout)
        {
            target.ExecutablePath = path.Text.Trim();
            target.Model = model.Text.Trim();
            target.TimeoutSeconds = (int)timeout.Value;
        }

        private void Save()
        {
            var shortcut = _shortcut.Text.Trim();
            if (shortcut.Length > 0 && !Hotkey.TryParse(shortcut, out _, out var problem))
            {
                _tabs.SelectedTab = _panelPage;
                _shortcut.Focus();
                MessageBox.Show(this, "Shortcut: " + problem, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DashboardSettings.IsLocal(_dashboardUrl.Text, out _))
            {
                _tabs.SelectedTab = _panelPage;
                _dashboardUrl.Focus();
                MessageBox.Show(this, "Sales dashboard address: use an address on this PC, e.g. " + DashboardSettings.DefaultUrl, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplyToSettings();
            _openAiKey.Apply(_secrets, SecretNames.OpenAiApiKey);
            _anthropicKey.Apply(_secrets, SecretNames.AnthropicApiKey);
            _geminiKey.Apply(_secrets, SecretNames.GeminiApiKey);
            _compatKey.Apply(_secrets, SecretNames.OpenAiCompatibleApiKey);
            _dbPassword.Apply(_secrets, SecretNames.DatabasePassword);
            DialogResult = DialogResult.OK;
            Close();
        }

        private sealed class Choice
        {
            public Choice(string id, string text)
            {
                Id = id;
                Text = text;
            }

            public string Id { get; }

            public string Text { get; }

            public override string ToString() => Text;
        }

        private sealed class PickerForm : Form
        {
            private readonly ListBox _list = new ListBox { Dock = DockStyle.Fill, IntegralHeight = false };

            public PickerForm(string title, IEnumerable<Choice> choices)
            {
                Text = title;
                Font = new Font("Segoe UI", 9.75f);
                Size = new Size(460, 420);
                StartPosition = FormStartPosition.CenterParent;
                ShowInTaskbar = false;
                MinimizeBox = false;
                MaximizeBox = false;
                _list.Items.AddRange(choices.Cast<object>().ToArray());
                if (_list.Items.Count > 0)
                {
                    _list.SelectedIndex = 0;
                }

                var ok = new Button { Text = "OK", Width = 90, Height = 30, DialogResult = DialogResult.OK };
                var cancel = new Button { Text = "Cancel", Width = 90, Height = 30, DialogResult = DialogResult.Cancel };
                var buttons = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 44, FlowDirection = FlowDirection.RightToLeft, Padding = new Padding(8, 6, 8, 6) };
                buttons.Controls.AddRange(new Control[] { cancel, ok });
                _list.DoubleClick += (sender, args) =>
                {
                    DialogResult = DialogResult.OK;
                    Close();
                };
                AcceptButton = ok;
                CancelButton = cancel;
                Controls.Add(_list);
                Controls.Add(buttons);
            }

            public Choice Selected => _list.SelectedItem as Choice;
        }
    }
}

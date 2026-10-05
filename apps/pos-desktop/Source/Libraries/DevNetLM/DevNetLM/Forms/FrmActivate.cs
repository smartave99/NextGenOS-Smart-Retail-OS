using System;
using System.Drawing;
using System.Windows.Forms;
using NextGenOS.Licensing;

namespace DevNetLM.Forms
{
    /// <summary>
    /// The activation window. Plain words, one thing to do: type the licence key and press Activate. For a PC without Internet it
    /// shows a code to read to the supplier and takes the answer code back. Built in code (no designer file) so it is easy to read.
    /// </summary>
    public sealed class FrmActivate : Form
    {
        private readonly LicenceManager _manager;
        private readonly Label _status = new Label();
        private readonly TextBox _key = new TextBox();
        private readonly Button _activate = new Button();
        private readonly Label _error = new Label();
        private readonly LinkLabel _offlineLink = new LinkLabel();
        private readonly LinkLabel _fileLink = new LinkLabel();
        private readonly Panel _offline = new Panel();
        private readonly TextBox _request = new TextBox();
        private readonly TextBox _answer = new TextBox();
        private readonly Button _useAnswer = new Button();
        private readonly Button _copy = new Button();
        private readonly Label _support = new Label();

        /// <summary>True when the PC ended up with a usable licence.</summary>
        public bool WasActivated { get; private set; }

        public FrmActivate(LicenceManager manager)
        {
            _manager = manager;
            var brand = manager.Evaluate().Brand;
            Text = "Activate " + brand.Name;
            Font = new Font("Segoe UI", 10f);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(560, 330);
            BackColor = Color.White;
            AutoScaleMode = AutoScaleMode.Dpi;

            var title = new Label { Text = "Activate " + brand.Name, Font = new Font("Segoe UI Semibold", 17f), Location = new Point(24, 18), AutoSize = true };
            _status.Location = new Point(26, 58);
            _status.Size = new Size(510, 44);
            _status.ForeColor = Color.FromArgb(110, 110, 115);

            var keyLabel = new Label { Text = "Licence key", Location = new Point(26, 108), AutoSize = true, Font = new Font("Segoe UI Semibold", 10f) };
            _key.Location = new Point(26, 132);
            _key.Size = new Size(380, 30);
            _key.Font = new Font("Consolas", 12f);
            _key.MaxLength = 40;
            _activate.Text = "Activate";
            _activate.Location = new Point(418, 130);
            _activate.Size = new Size(118, 34);
            _activate.FlatStyle = FlatStyle.Flat;
            _activate.BackColor = ParseColour(brand.PrimaryColor, Color.FromArgb(0, 113, 227));
            _activate.ForeColor = Color.White;
            _activate.FlatAppearance.BorderSize = 0;
            _activate.Click += async (s, e) => await ActivateOnlineAsync();
            AcceptButton = _activate;

            _error.Location = new Point(26, 170);
            _error.Size = new Size(510, 40);
            _error.ForeColor = Color.FromArgb(179, 38, 30);

            _offlineLink.Text = "No Internet on this PC? Activate without Internet";
            _offlineLink.Location = new Point(26, 216);
            _offlineLink.AutoSize = true;
            _offlineLink.LinkClicked += (s, e) => ToggleOffline();
            _fileLink.Text = "I have a licence file…";
            _fileLink.Location = new Point(330, 216);
            _fileLink.AutoSize = true;
            _fileLink.LinkClicked += (s, e) => LoadFile();

            BuildOfflinePanel();

            _support.Location = new Point(26, 296);
            _support.AutoSize = true;
            _support.ForeColor = Color.FromArgb(110, 110, 115);
            _support.Text = SupportText(brand);

            Controls.AddRange(new Control[] { title, _status, keyLabel, _key, _activate, _error, _offlineLink, _fileLink, _offline, _support });
            Show_state(_manager.Evaluate());
            Shown += (s, e) => _key.Focus();
        }

        private void BuildOfflinePanel()
        {
            _offline.Location = new Point(0, 244);
            _offline.Size = new Size(560, 0);
            _offline.Visible = false;
            var l1 = new Label { Text = "1. Read this code to your supplier (or send it by e-mail):", Location = new Point(26, 4), AutoSize = true };
            _request.Location = new Point(26, 28);
            _request.Size = new Size(430, 52);
            _request.Multiline = true;
            _request.ReadOnly = true;
            _request.ScrollBars = ScrollBars.Vertical;
            _request.Font = new Font("Consolas", 9f);
            _copy.Text = "Copy";
            _copy.Location = new Point(466, 28);
            _copy.Size = new Size(70, 30);
            _copy.Click += (s, e) => { try { Clipboard.SetText(_request.Text); } catch (Exception) { } };
            var l2 = new Label { Text = "2. Type the answer code you receive:", Location = new Point(26, 90), AutoSize = true };
            _answer.Location = new Point(26, 114);
            _answer.Size = new Size(430, 52);
            _answer.Multiline = true;
            _answer.Font = new Font("Consolas", 9f);
            _useAnswer.Text = "Activate";
            _useAnswer.Location = new Point(466, 114);
            _useAnswer.Size = new Size(70, 30);
            _useAnswer.Click += (s, e) => UseAnswer();
            _offline.Controls.AddRange(new Control[] { l1, _request, _copy, l2, _answer, _useAnswer });
        }

        private void ToggleOffline()
        {
            var open = !_offline.Visible;
            if (open)
            {
                try
                {
                    var key = _key.Text.Trim();
                    if (LicenceKey.Normalise(key) == null) { Fail("Type your licence key first, then choose this."); return; }
                    _request.Text = _manager.CreateOfflineRequest(key);
                }
                catch (Exception ex) { Fail(ex.Message); return; }
            }
            _offline.Visible = open;
            _offline.Height = open == true ? 170 : 0;
            ClientSize = new Size(560, open ? 500 : 330);
            _support.Location = new Point(26, open ? 466 : 296);
        }

        private async System.Threading.Tasks.Task ActivateOnlineAsync()
        {
            Fail(string.Empty);
            _activate.Enabled = false;
            _activate.Text = "Please wait…";
            try
            {
                var state = await _manager.ActivateAsync(_key.Text);
                Show_state(state);
                if (state.IsUsable) { WasActivated = true; Close(); }
                else Fail(state.Message);
            }
            catch (LicenceServerException ex) { Fail(ex.Message); }
            catch (LicenceException) { Fail("The answer could not be trusted and was not used. Please contact your supplier."); }
            catch (Exception) { Fail("Something went wrong. Please try again, or contact your supplier."); }
            finally { _activate.Enabled = true; _activate.Text = "Activate"; }
        }

        private void UseAnswer()
        {
            try
            {
                var state = _manager.ImportOfflineResponse(_answer.Text);
                Show_state(state);
                if (state.IsUsable) { WasActivated = true; Close(); } else Fail(state.Message);
            }
            catch (LicenceException ex) { Fail(ex.Message); }
            catch (Exception) { Fail("That code could not be used. Please copy it again, all of it."); }
        }

        private void LoadFile()
        {
            using (var dialog = new OpenFileDialog { Title = "Choose the licence file", Filter = "Licence files (*.ngoslic;*.txt)|*.ngoslic;*.txt|All files|*.*" })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    var state = _manager.ImportLicenceFile(dialog.FileName);
                    Show_state(state);
                    if (state.IsUsable) { WasActivated = true; Close(); }
                    else Fail(state.Message);
                }
                catch (LicenceException ex) { Fail(ex.Message); }
                catch (Exception) { Fail("That file could not be read."); }
            }
        }

        private void Show_state(LicenceState state)
        {
            _status.Text = state.Status == LicenceStatus.Missing ? "Enter the licence key you received to start." : state.Message;
        }

        private void Fail(string text) { _error.Text = text; }

        private static string SupportText(BrandProfile brand)
        {
            var parts = new System.Collections.Generic.List<string>();
            if (!string.IsNullOrEmpty(brand.SupportEmail)) parts.Add(brand.SupportEmail);
            if (!string.IsNullOrEmpty(brand.SupportPhone)) parts.Add(brand.SupportPhone);
            return parts.Count == 0 ? string.Empty : "Need help? " + string.Join("  ·  ", parts);
        }

        private static Color ParseColour(string hex, Color fallback)
        {
            try
            {
                if (!string.IsNullOrEmpty(hex) && hex.Length == 7 && hex[0] == '#')
                    return Color.FromArgb(Convert.ToInt32(hex.Substring(1, 2), 16), Convert.ToInt32(hex.Substring(3, 2), 16), Convert.ToInt32(hex.Substring(5, 2), 16));
            }
            catch (Exception) { }
            return fallback;
        }
    }
}

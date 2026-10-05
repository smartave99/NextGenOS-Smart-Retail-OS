using System;
using System.Drawing;
using System.Windows.Forms;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// The side panel beside the POS, in the new design: the dashboard's /panel page (today's figures and Ask AI) in
    /// a slim window on the screen edge, above other windows. <see cref="AppHost"/> places, shows and hides it.
    /// </summary>
    internal sealed class PanelWindow : WebWindow
    {
        private readonly Panel _edgeLine = new Panel { Dock = DockStyle.Left, Width = 1 };

        public PanelWindow(Uri dashboard)
            : base(dashboard)
        {
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            MinimumSize = new Size(PanelSettings.MinimumWidth, 420);
            Text = "Smart Retail AI";
            Controls.Add(_edgeLine);
            OnThemeChanged(WebViewSupport.WindowsUsesDarkApps());
        }

        /// <summary>Esc, or the panel's close button: back to the POS.</summary>
        public event EventHandler HideRequested;

        /// <summary>The panel's width button: normal or wide, for big tables.</summary>
        public event EventHandler WidthToggled;

        /// <summary>The panel asks for the full app, on a page such as "ask".</summary>
        public event EventHandler<string> OpenAppRequested;

        /// <summary>The panel's settings button.</summary>
        public event EventHandler SettingsRequested;

        public bool IsWide { get; private set; }

        /// <summary>Draws the panel's border line on the side that faces the POS.</summary>
        public void UseEdge(PanelEdge edge)
        {
            _edgeLine.Dock = edge == PanelEdge.Left ? DockStyle.Right : DockStyle.Left;
        }

        /// <summary>Puts the cursor in the question box, so the cashier can type straight away.</summary>
        public async void FocusQuestion()
        {
            FocusPage();
            await RunScriptAsync("srpos.focusComposer()");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Esc while the page is still starting (the page itself sends "hide" once it is shown).
            if (keyData == Keys.Escape)
            {
                HideRequested?.Invoke(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnThemeChanged(bool dark)
        {
            _edgeLine.BackColor = dark ? Color.FromArgb(58, 58, 63) : Color.FromArgb(210, 210, 215);
        }

        protected override void OnMessage(HostMessage message)
        {
            base.OnMessage(message);
            switch (message.Type)
            {
                case "hide":
                    HideRequested?.Invoke(this, EventArgs.Empty);
                    break;
                case "wide":
                    IsWide = !IsWide;
                    WidthToggled?.Invoke(this, EventArgs.Empty);
                    break;
                case "open":
                    OpenAppRequested?.Invoke(this, message.Value);
                    break;
                case "settings":
                    SettingsRequested?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }
    }
}

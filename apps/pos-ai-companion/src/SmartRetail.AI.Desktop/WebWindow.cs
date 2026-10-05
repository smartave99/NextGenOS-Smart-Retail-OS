using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// A window that shows a page of the dashboard in WebView2, with a calm "Starting…" screen in its place until the
    /// page is there, and a way to try again when it is not.
    /// </summary>
    internal abstract class WebWindow : Form
    {
        // Always "visible" (a hidden WebView2 never gets a window, so never loads): the start screen covers it instead.
        private readonly WebView2 _view = new WebView2 { Dock = DockStyle.Fill };
        private readonly StartScreen _start = new StartScreen { Dock = DockStyle.Fill };
        private readonly Uri _dashboard;
        private Task _prepared;
        private bool _dark;
        private bool _loaded;

        protected WebWindow(Uri dashboard)
        {
            _dashboard = dashboard;
            Icon = AppIcon.Get();
            Text = "Smart Retail POS";
            _dark = WebViewSupport.WindowsUsesDarkApps();
            Controls.Add(_view);
            Controls.Add(_start);
            _start.BringToFront();
            ApplyTheme(_dark);
            _start.Retry += async (sender, args) =>
            {
                if (RetryRequested != null)
                {
                    RetryRequested(this, EventArgs.Empty);
                }
                else
                {
                    await ReloadAsync();
                }
            };
            _view.NavigationCompleted += OnNavigationCompleted;
        }

        /// <summary>A message from the page, e.g. "hide", "open" or "settings".</summary>
        public event EventHandler<HostMessage> MessageReceived;

        /// <summary>Try again was pressed; without a handler the page is simply loaded again.</summary>
        public event EventHandler RetryRequested;

        /// <summary>The page is shown and its scripts can be run.</summary>
        public bool IsPageReady => _loaded && !_start.Visible;

        /// <summary>A page has been asked for (it may still be loading).</summary>
        public bool HasPage => _view.CoreWebView2 != null && _view.Source != null && _view.Source.AbsoluteUri != "about:blank";

        protected Uri Dashboard => _dashboard;

        protected bool IsDark => _dark;

        /// <summary>What the "Starting…" screen says, e.g. "Looking for your shop's data…".</summary>
        public void ShowStatus(string text)
        {
            _start.Problem = null;
            _start.Status = text;
            ShowStartScreen();
        }

        /// <summary>Says what went wrong, with a Try again button.</summary>
        public void ShowProblem(string text)
        {
            _start.Problem = text;
            ShowStartScreen();
        }

        /// <summary>Shows a page of the dashboard, e.g. "" for Today or "ask".</summary>
        public async Task OpenAsync(string page)
        {
            await PrepareAsync();
            var target = new Uri(_dashboard, (page ?? "").TrimStart('/'));
            if (_view.Source != null && _view.Source == target && IsPageReady)
            {
                return;
            }

            _view.CoreWebView2.Navigate(target.AbsoluteUri);
        }

        public async Task ReloadAsync()
        {
            ShowStatus("Starting Smart Retail POS…");
            await PrepareAsync();
            if (_view.Source == null || _view.Source.AbsoluteUri == "about:blank")
            {
                _view.CoreWebView2.Navigate(_dashboard.AbsoluteUri);
            }
            else
            {
                _view.CoreWebView2.Reload();
            }
        }

        /// <summary>Runs a line of the page's script, e.g. "srpos.focusComposer()"; nothing when the page is not ready.</summary>
        public async Task<string> RunScriptAsync(string script)
        {
            if (_view.CoreWebView2 == null || !_loaded)
            {
                return null;
            }

            try
            {
                return await _view.CoreWebView2.ExecuteScriptAsync(script);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public void FocusPage()
        {
            if (IsPageReady)
            {
                _view.Focus();
            }
        }

        /// <summary>A point of the page (CSS pixels) on the screen, for the smoke test's mouse.</summary>
        public Point PageToScreen(double x, double y)
        {
            var origin = _view.PointToScreen(Point.Empty);
            var scale = DeviceDpi / 96.0 * _view.ZoomFactor;
            return new Point(origin.X + (int)Math.Round(x * scale), origin.Y + (int)Math.Round(y * scale));
        }

        /// <summary>Light or dark, as the page says it is shown.</summary>
        public void ApplyTheme(bool dark)
        {
            _dark = dark;
            BackColor = WebViewSupport.Background(dark);
            _view.DefaultBackgroundColor = WebViewSupport.Background(dark);
            _start.Dark = dark;
            WebViewSupport.StyleTitleBar(this, dark);
            OnThemeChanged(dark);
        }

        protected virtual void OnThemeChanged(bool dark)
        {
        }

        /// <summary>WebView2 is ready, before the first page: e.g. for settings that count from the next page on.</summary>
        protected virtual Task OnPreparedAsync(CoreWebView2 core) => Task.CompletedTask;

        /// <summary>A page was shown.</summary>
        protected virtual void OnPageShown()
        {
        }

        /// <summary>The "Starting…" screen, or a problem, is shown instead of the page.</summary>
        protected virtual void OnStartScreenShown()
        {
        }

        protected virtual void OnMessage(HostMessage message)
        {
            if (message.Type == "theme")
            {
                ApplyTheme(message.Value == "dark");
            }

            MessageReceived?.Invoke(this, message);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            WebViewSupport.StyleTitleBar(this, _dark);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _view.Dispose();
            }

            base.Dispose(disposing);
        }

        private Task PrepareAsync() => _prepared ?? (_prepared = PrepareCoreAsync());

        private async Task PrepareCoreAsync()
        {
            await WebViewSupport.PrepareAsync(_view, _dashboard, message => BeginInvoke((Action)(() => OnMessage(message))));
            await OnPreparedAsync(_view.CoreWebView2);
        }

        private void OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                _loaded = true;
                _start.Visible = false;
                OnPageShown();
                return;
            }

            // A link inside a page that failed, or a page left early, is not a problem worth a screen of its own.
            if (e.WebErrorStatus == CoreWebView2WebErrorStatus.OperationCanceled)
            {
                return;
            }

            ShowProblem("The page could not be shown (" + e.WebErrorStatus + "). The dashboard may have stopped.");
        }

        private void ShowStartScreen()
        {
            _start.Visible = true;
            _start.BringToFront();
            OnStartScreenShown();
        }

        /// <summary>The app's mark, a line of text and, after a problem, a Try again button.</summary>
        private sealed class StartScreen : Control
        {
            private readonly Button _retry = new Button { Text = "Try again", AutoSize = true, Visible = false, FlatStyle = FlatStyle.Flat };
            private string _status = "Starting Smart Retail POS…";
            private string _problem;
            private bool _dark;

            public StartScreen()
            {
                DoubleBuffered = true;
                SetStyle(ControlStyles.ResizeRedraw, true);
                _retry.FlatAppearance.BorderSize = 0;
                _retry.BackColor = Color.FromArgb(0, 113, 227);
                _retry.ForeColor = Color.White;
                _retry.Font = new Font("Segoe UI Semibold", 10f);
                _retry.Padding = new Padding(14, 4, 14, 4);
                _retry.Click += (sender, args) => Retry?.Invoke(this, EventArgs.Empty);
                Controls.Add(_retry);
            }

            public event EventHandler Retry;

            public string Status
            {
                get => _status;
                set
                {
                    _status = value ?? "";
                    Invalidate();
                }
            }

            public string Problem
            {
                get => _problem;
                set
                {
                    _problem = value;
                    _retry.Visible = value != null;
                    PlaceButton();
                    Invalidate();
                }
            }

            public bool Dark
            {
                get => _dark;
                set
                {
                    _dark = value;
                    BackColor = WebViewSupport.Background(value);
                    Invalidate();
                }
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                PlaceButton();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                var graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                var size = Math.Min(72, Math.Max(40, Width / 8));
                var top = Height / 2 - size - 10;
                AppMarkPainter.Draw(graphics, new Rectangle((Width - size) / 2, top, size, size));
                using (var titleFont = new Font("Segoe UI Semibold", 15f))
                using (var textFont = new Font("Segoe UI", 10.5f))
                using (var ink = new SolidBrush(WebViewSupport.InkColor(_dark)))
                using (var muted = new SolidBrush(_problem == null ? WebViewSupport.MutedColor(_dark) : Color.FromArgb(215, 0, 21)))
                using (var centred = new StringFormat { Alignment = StringAlignment.Center })
                {
                    graphics.DrawString("Smart Retail POS", titleFont, ink, new RectangleF(16, top + size + 18, Width - 32, 32), centred);
                    graphics.DrawString(_problem ?? _status, textFont, muted, new RectangleF(24, top + size + 52, Width - 48, 60), centred);
                }
            }

            private void PlaceButton()
            {
                _retry.Location = new Point((Width - _retry.Width) / 2, Height / 2 + 100);
            }
        }
    }
}

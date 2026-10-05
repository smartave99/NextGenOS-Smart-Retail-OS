using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// Smart Retail POS in its own window: the whole dashboard, with Ask AI, in the new design. Once the page shows its
    /// own top bar (search, the shop's data, the AI, the bell and the window buttons), that bar takes the place of the
    /// Windows title bar: it drags the window, a double click maximises it, and the frame still resizes and snaps.
    /// While the page is starting or cannot be shown, and on a WebView2 too old for it, the Windows title bar stays,
    /// so the window can always be moved and closed.
    /// </summary>
    internal sealed class AppWindow : WebWindow
    {
        // A page loaded after the top bar was handed over must show its own within this time, or the Windows title bar
        // comes back (e.g. the page cannot reach the dashboard's live session).
        private static readonly TimeSpan FrameGrace = TimeSpan.FromSeconds(10);

        private readonly Timer _frameCheck = new Timer();
        private bool _frameAllowed;
        private bool _ownTitleBar;
        private bool? _sentMaximized;

        public AppWindow(Uri dashboard)
            : base(dashboard)
        {
            Text = "Smart Retail POS";
            StartPosition = FormStartPosition.Manual;

            // Fit smaller shop screens such as 1366×768.
            var area = Screen.PrimaryScreen.WorkingArea;
            var bounds = PanelLayout.CenteredWindow(new PixelRect(area.X, area.Y, area.Width, area.Height), 1320, 860);
            Bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            MinimumSize = new Size(Math.Min(760, area.Width), Math.Min(560, area.Height));

            _frameCheck.Interval = (int)FrameGrace.TotalMilliseconds;
            _frameCheck.Tick += (sender, args) =>
            {
                _frameCheck.Stop();
                UseOwnTitleBar(false);
            };
        }

        /// <summary>Closing only hides the window; the app keeps running beside the POS (side panel, tray).</summary>
        public bool HideOnClose { get; set; }

        /// <summary>The window was closed while <see cref="HideOnClose"/> kept the app running.</summary>
        public event EventHandler HiddenOnClose;

        /// <summary>The page's top bar stands in for the Windows title bar.</summary>
        public bool HasOwnTitleBar => _ownTitleBar;

        public bool IsMaximized => IsHandleCreated && NativeMethods.IsZoomed(Handle);

        /// <summary>The strip above the page that resizes the window from the top, as the title bar's edge did.</summary>
        private int TopEdge => LogicalToDeviceUnits(4);

        public void BringForward()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            Show();
            Activate();
            FocusPage();
        }

        protected override async Task OnPreparedAsync(CoreWebView2 core)
        {
            _frameAllowed = await WebViewSupport.AllowOwnTitleBarAsync(core);
        }

        protected override void OnPageShown()
        {
            if (_ownTitleBar)
            {
                _frameCheck.Stop();
                _frameCheck.Start();
            }
        }

        protected override void OnStartScreenShown() => UseOwnTitleBar(false);

        protected override void OnMessage(HostMessage message)
        {
            switch (message.Type)
            {
                case "frame":
                    // The page's top bar is on screen.
                    _frameCheck.Stop();
                    _sentMaximized = null;
                    UseOwnTitleBar(_frameAllowed);
                    _ = SendWindowStateAsync();
                    return;
                case "window":
                    switch (message.Value)
                    {
                        case "minimize":
                            WindowState = FormWindowState.Minimized;
                            break;
                        case "maximize":
                            WindowState = IsMaximized ? FormWindowState.Normal : FormWindowState.Maximized;
                            break;
                        case "close":
                            Close();
                            break;
                    }

                    return;
                default:
                    base.OnMessage(message);
                    return;
            }
        }

        protected override void OnThemeChanged(bool dark) => ApplyTitleBarLook();

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_ownTitleBar)
            {
                ApplyTitleBarLook();
                _ = SendWindowStateAsync();
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (_ownTitleBar && m.Msg == NativeMethods.WmNcCalcSize && m.WParam != IntPtr.Zero)
            {
                // Keep the frame at the sides and the bottom (resizing, snapping, the shadow) and give the title bar's
                // room to the page. A maximised window's frame lies outside the screen: its top edge stays out too.
                var window = Marshal.PtrToStructure<NativeMethods.Rect>(m.LParam);
                base.WndProc(ref m);
                var client = Marshal.PtrToStructure<NativeMethods.Rect>(m.LParam);
                client.Top = window.Top + (NativeMethods.IsZoomed(Handle) ? client.Left - window.Left : 0);
                Marshal.StructureToPtr(client, m.LParam, false);
                return;
            }

            base.WndProc(ref m);

            if (_ownTitleBar && m.Msg == NativeMethods.WmNcHitTest && m.Result == (IntPtr)NativeMethods.HtClient && !NativeMethods.IsZoomed(Handle))
            {
                // The strip above the page resizes the window from the top, and from its top corners.
                var point = PointToClient(new Point(unchecked((short)(long)m.LParam), unchecked((short)((long)m.LParam >> 16))));
                if (point.Y < TopEdge)
                {
                    var corner = TopEdge * 4;
                    m.Result = (IntPtr)(point.X < corner ? NativeMethods.HtTopLeft
                        : point.X >= ClientSize.Width - corner ? NativeMethods.HtTopRight
                        : NativeMethods.HtTop);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (HideOnClose && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                HiddenOnClose?.Invoke(this, EventArgs.Empty);
                return;
            }

            base.OnFormClosing(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _frameCheck.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>The page's top bar in place of the Windows title bar, or the Windows one back.</summary>
        private void UseOwnTitleBar(bool on)
        {
            if (_ownTitleBar == on || !IsHandleCreated)
            {
                return;
            }

            _ownTitleBar = on;
            if (!on)
            {
                _frameCheck.Stop();
            }

            ApplyTitleBarLook();

            // Windows asks for the frame again (WM_NCCALCSIZE), now without or with its title bar.
            NativeMethods.SetWindowPos(Handle, IntPtr.Zero, 0, 0, 0, 0,
                NativeMethods.SwpFrameChanged | NativeMethods.SwpNoMove | NativeMethods.SwpNoSize | NativeMethods.SwpNoZOrder | NativeMethods.SwpNoActivate);
        }

        /// <summary>With the page's top bar: a thin strip above the page, in the bar's colour, to resize from the top
        /// (none when maximised).</summary>
        private void ApplyTitleBarLook()
        {
            Padding = new Padding(0, _ownTitleBar && !IsMaximized ? TopEdge : 0, 0, 0);
            BackColor = _ownTitleBar ? WebViewSupport.SidebarColor(IsDark) : WebViewSupport.Background(IsDark);
        }

        /// <summary>Tells the page whether the window is maximised, for its maximise or restore button.</summary>
        private async Task SendWindowStateAsync()
        {
            var maximized = IsMaximized;
            if (!_ownTitleBar || _sentMaximized == maximized)
            {
                return;
            }

            _sentMaximized = maximized;
            await RunScriptAsync("srpos.windowState('" + (maximized ? "maximized" : "normal") + "')");
        }
    }
}

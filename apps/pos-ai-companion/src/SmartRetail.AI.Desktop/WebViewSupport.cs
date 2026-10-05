using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Desktop
{
    /// <summary>A message from a page of the dashboard to this app, e.g. {"type":"hide"} from the side panel.</summary>
    internal sealed class HostMessage : EventArgs
    {
        public HostMessage(string type, string value)
        {
            Type = type ?? "";
            Value = value ?? "";
        }

        public string Type { get; }

        public string Value { get; }

        public static HostMessage Parse(string json)
        {
            try
            {
                var message = JObject.Parse(json ?? "");
                return new HostMessage((string)message["type"], (string)message["value"]);
            }
            catch (Exception ex) when (ex is Newtonsoft.Json.JsonException || ex is InvalidCastException || ex is ArgumentException)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// The Edge WebView2 engine that shows the dashboard's pages in this app's own windows: whether Windows has it,
    /// one shared browser profile in the user's app data (never in Program Files), and the rules every window follows.
    /// </summary>
    internal static class WebViewSupport
    {
        private static Task<CoreWebView2Environment> _environment;

        public static string DataFolder => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Branding.Company,
            Branding.AppFolderName,
            "WebView2");

        /// <summary>True when the WebView2 Runtime is installed (it comes with Windows 11 and with Edge on Windows 10).</summary>
        public static bool IsAvailable(out string version)
        {
            try
            {
                version = CoreWebView2Environment.GetAvailableBrowserVersionString();
                return !string.IsNullOrEmpty(version);
            }
            catch (Exception ex)
            {
                // Not installed, or its loader cannot run here (e.g. under Wine): the app falls back to its earlier windows.
                if (!(ex is WebView2RuntimeNotFoundException))
                {
                    AppLog.Error("Checking for WebView2", ex);
                }

                version = null;
                return false;
            }
        }

        public static Task<CoreWebView2Environment> EnvironmentAsync() =>
            _environment ?? (_environment = CoreWebView2Environment.CreateAsync(null, DataFolder, new CoreWebView2EnvironmentOptions()));

        /// <summary>
        /// Sets up a WebView2 for the dashboard: its pages stay inside, anything else opens in the browser, and only
        /// the dashboard's pages may send messages to the app.
        /// </summary>
        public static async Task PrepareAsync(WebView2 view, Uri dashboard, Action<HostMessage> onMessage)
        {
            await view.EnsureCoreWebView2Async(await EnvironmentAsync());
            var core = view.CoreWebView2;
            core.Settings.AreDevToolsEnabled = false;
            core.Settings.IsStatusBarEnabled = false;
            core.Settings.IsGeneralAutofillEnabled = false;
            core.Settings.IsPasswordAutosaveEnabled = false;
            core.NewWindowRequested += (sender, e) =>
            {
                // Links that open a new window (the sign-in page, a full-size photo) go to the browser, not a bare window.
                e.Handled = true;
                OpenInBrowser(e.Uri);
            };
            core.PermissionRequested += (sender, e) =>
            {
                // The camera and the microphone (photos, voice notes, finding a product by its look): only for the
                // dashboard's own pages, which start them only when a person presses a button. Anything else keeps
                // WebView2's usual answer.
                if (e.PermissionKind == CoreWebView2PermissionKind.Camera || e.PermissionKind == CoreWebView2PermissionKind.Microphone)
                {
                    e.State = IsDashboard(dashboard, e.Uri) ? CoreWebView2PermissionState.Allow : CoreWebView2PermissionState.Deny;
                }
            };
            core.NavigationStarting += (sender, e) =>
            {
                if (!IsDashboard(dashboard, e.Uri) && !e.Uri.StartsWith("about:", StringComparison.OrdinalIgnoreCase))
                {
                    e.Cancel = true;
                    OpenInBrowser(e.Uri);
                }
            };
            core.WebMessageReceived += (sender, e) =>
            {
                if (!IsDashboard(dashboard, e.Source))
                {
                    return;
                }

                string text;
                try
                {
                    text = e.TryGetWebMessageAsString();
                }
                catch (ArgumentException)
                {
                    return;
                }

                var message = HostMessage.Parse(text);
                if (message != null)
                {
                    onMessage(message);
                }
            };
            core.ProcessFailed += (sender, e) =>
            {
                // The page's renderer crashed or was killed: show it again rather than a blank window.
                if (e.ProcessFailedKind == CoreWebView2ProcessFailedKind.RenderProcessExited
                    || e.ProcessFailedKind == CoreWebView2ProcessFailedKind.RenderProcessUnresponsive)
                {
                    core.Reload();
                }
            };
        }

        public static bool IsDashboard(Uri dashboard, string address) =>
            Uri.TryCreate(address, UriKind.Absolute, out var uri)
            && uri.Scheme == dashboard.Scheme
            && string.Equals(uri.Host, dashboard.Host, StringComparison.OrdinalIgnoreCase)
            && uri.Port == dashboard.Port;

        public static void OpenInBrowser(string address)
        {
            if (!Uri.TryCreate(address, UriKind.Absolute, out var uri)
                || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps && uri.Scheme != Uri.UriSchemeMailto))
            {
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo(uri.AbsoluteUri) { UseShellExecute = true })?.Dispose();
            }
            catch (Exception ex) when (ex is System.ComponentModel.Win32Exception || ex is InvalidOperationException)
            {
                AppLog.Error("Opening a link in the browser", ex);
            }
        }

        /// <summary>Windows' own choice between light and dark apps.</summary>
        public static bool WindowsUsesDarkApps()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    return key?.GetValue("AppsUseLightTheme") is int light && light == 0;
                }
            }
            catch (Exception ex) when (ex is System.Security.SecurityException || ex is UnauthorizedAccessException || ex is IOException)
            {
                return false;
            }
        }

        /// <summary>The page background for light or dark, so a window never flashes white.</summary>
        public static Color Background(bool dark) => dark ? Color.FromArgb(17, 17, 19) : Color.FromArgb(245, 245, 247);

        public static Color SidebarColor(bool dark) => dark ? Color.FromArgb(27, 27, 30) : Color.FromArgb(235, 235, 240);

        public static Color InkColor(bool dark) => dark ? Color.FromArgb(245, 245, 247) : Color.FromArgb(29, 29, 31);

        public static Color MutedColor(bool dark) => dark ? Color.FromArgb(161, 161, 166) : Color.FromArgb(110, 110, 115);

        /// <summary>
        /// Lets the page's own top bar stand in for the title bar: its CSS app-region drags the window (a double click
        /// maximises it, a right click opens the window menu), and the page is told so before its scripts run. False on
        /// a WebView2 Runtime too old for it: the Windows title bar stays.
        /// </summary>
        public static async Task<bool> AllowOwnTitleBarAsync(CoreWebView2 core)
        {
            try
            {
                core.Settings.IsNonClientRegionSupportEnabled = true;
                await core.AddScriptToExecuteOnDocumentCreatedAsync("window.srposFrame = 'app';");
                return true;
            }
            catch (Exception ex) when (ex is NotImplementedException || ex is InvalidCastException || ex is COMException)
            {
                AppLog.Error("The page's own title bar (the Windows one stays)", ex);
                return false;
            }
        }

        /// <summary>A title bar that matches the page: dark in dark mode, and on Windows 11 the sidebar's colour.</summary>
        public static void StyleTitleBar(Form form, bool dark)
        {
            if (!form.IsHandleCreated)
            {
                return;
            }

            try
            {
                var on = dark ? 1 : 0;
                NativeMethods.DwmSetWindowAttribute(form.Handle, NativeMethods.DwmwaUseImmersiveDarkMode, ref on, sizeof(int));
                var caption = ColorTranslator.ToWin32(SidebarColor(dark));
                NativeMethods.DwmSetWindowAttribute(form.Handle, NativeMethods.DwmwaCaptionColor, ref caption, sizeof(int));
                var text = ColorTranslator.ToWin32(InkColor(dark));
                NativeMethods.DwmSetWindowAttribute(form.Handle, NativeMethods.DwmwaTextColor, ref text, sizeof(int));
            }
            catch (Exception ex) when (ex is DllNotFoundException || ex is EntryPointNotFoundException)
            {
                // Older Windows: the standard title bar.
            }
        }
    }
}

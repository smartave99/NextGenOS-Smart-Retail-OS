using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    internal static class Program
    {
        private const string InstanceName = "NextGenOS.SmartRetailPOS.AIAssistant";
        private const string ShowRequestName = InstanceName + ".Show";

        [STAThread]
        private static int Main(string[] args)
        {
            // Older Windows builds may not offer TLS 1.2 by default, which every AI API requires.
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var smoke = SmokeTest.FromArguments(args);
            if (smoke != null)
            {
                // A check run by the build: report and stop, never wait for someone to close a message box.
                Application.ThreadException += (sender, eventArgs) => FailSmokeTest(smoke, eventArgs.Exception);
                AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) => FailSmokeTest(smoke, eventArgs.ExceptionObject as Exception);
            }
            else
            {
                Application.ThreadException += (sender, eventArgs) => ShowFatal(eventArgs.Exception);
                AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) => ShowFatal(eventArgs.ExceptionObject as Exception);
            }

            using (var mutex = new Mutex(true, InstanceName, out var firstInstance))
            {
                if (!firstInstance)
                {
                    if (smoke != null)
                    {
                        smoke.Fail("Another copy of the app is running.");
                        return smoke.ExitCode;
                    }

                    BringRunningCopyForward();
                    return 0;
                }

                var background = args.Contains(StartupRegistration.BackgroundArgument);
                using (var showRequest = new EventWaitHandle(false, EventResetMode.AutoReset, ShowRequestName))
                using (var app = new AssistantApp(new SettingsStore(SettingsStore.DefaultFilePath)))
                {
                    if (WebViewSupport.IsAvailable(out _))
                    {
                        // The app in the new design: its own window and the side panel, both shown by WebView2.
                        using (var host = new AppHost(app, background, showRequest, smoke))
                        {
                            Application.Run(host);
                        }
                    }
                    else if (smoke != null)
                    {
                        smoke.Fail("The Microsoft Edge WebView2 Runtime is not installed.");
                    }
                    else
                    {
                        // Without WebView2 (it can be installed later): the earlier side panel, and the dashboard in the browser.
                        using (var host = new AssistantHost(app, background, showRequest))
                        {
                            Application.Run(host);
                        }
                    }
                }

                GC.KeepAlive(mutex);
            }

            return smoke?.ExitCode ?? 0;
        }

        /// <summary>The assistant is already running, e.g. started with Windows: show that copy instead.</summary>
        private static void BringRunningCopyForward()
        {
            if (EventWaitHandle.TryOpenExisting(ShowRequestName, out var showRequest))
            {
                using (showRequest)
                {
                    NativeMethods.AllowSetForegroundWindow(-1);
                    showRequest.Set();
                }

                return;
            }

            MessageBox.Show(Branding.AssistantName + " is already open.", Branding.AssistantName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void FailSmokeTest(SmokeTest smoke, Exception exception)
        {
            smoke.Fail("Unhandled: " + exception);
            Environment.Exit(smoke.ExitCode);
        }

        private static void ShowFatal(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            AppLog.Error("Unhandled", exception);
            MessageBox.Show("Something went wrong: " + exception.Message + Environment.NewLine + Environment.NewLine + "Details were written to " + AppLog.FilePath,
                Branding.AssistantName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

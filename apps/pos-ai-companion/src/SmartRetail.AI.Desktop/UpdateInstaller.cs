using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Windows.Forms;
using Microsoft.Win32;
using SmartRetail.AI.Updates;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// Installs an update the app checked itself (<see cref="UpdateService"/>) when the owner says so. The setup is
    /// checked once more and kept open, so nothing can change it before it runs; it is started quietly in the way the
    /// app was installed (for everyone, which asks Windows for administrator rights, or for this user), and waits for the
    /// app to quit. A small helper, started here without those rights, starts the app again once the setup is done.
    /// Settings, data and Codex are kept: the setup never touches them.
    /// </summary>
    internal static class UpdateInstaller
    {
        private const string UninstallKey = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\NextGenOS.SmartRetailPOS.AI";

        /// <summary>Starts the setup; null when it is running (the app should now quit), else why not.</summary>
        /// <param name="ready">What this run of the app checked: a status found on disk is never enough.</param>
        public static string Start(UpdateStatus ready, string folder, Version current)
        {
            var refused = UpdateInstallRules.Problem(ready, current);
            if (refused != null)
            {
                return refused;
            }

            var mode = InstalledMode();
            if (mode == null)
            {
                return "This copy was not put here by the setup, so it cannot update itself. Run the new setup instead.";
            }

            var path = Path.Combine(folder, ready.File);
            try
            {
                using (var setup = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    if (UpdateChecker.Sha256Of(setup) != ready.Sha256)
                    {
                        return "The downloaded update changed after it was checked, so it was not installed. It is downloaded again at the next check.";
                    }

                    var everyone = mode == "AllUsers";
                    var start = new ProcessStartInfo(path, "/S /UPDATE /" + mode)
                    {
                        UseShellExecute = true,
                        Verb = everyone ? "runas" : "",
                        WorkingDirectory = folder,
                    };
                    using (var process = Process.Start(start))
                    {
                        if (process == null)
                        {
                            return "The update could not be started.";
                        }

                        StartAppAfter(process.Id);
                    }
                }
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == 1223)
            {
                return "Installing the update needs administrator rights, and they were not given. The app keeps running as it is.";
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is Win32Exception)
            {
                AppLog.Error("Starting the update", ex);
                return "The update could not be started: " + ex.Message;
            }

            return null;
        }

        /// <summary>"AllUsers" when this copy is the one installed for everyone (Program Files and the like), "CurrentUser"
        /// when it is the current user's own, null when the setup did not put it here.</summary>
        private static string InstalledMode()
        {
            var folder = (Path.GetDirectoryName(Application.ExecutablePath) ?? "").TrimEnd('\\');
            try
            {
                using (var machine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = machine.OpenSubKey(UninstallKey))
                {
                    if (IsHere(key, folder))
                    {
                        return "AllUsers";
                    }
                }

                using (var user = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (var key = user.OpenSubKey(UninstallKey))
                {
                    return IsHere(key, folder) ? "CurrentUser" : null;
                }
            }
            catch (Exception ex) when (ex is SecurityException || ex is UnauthorizedAccessException || ex is IOException)
            {
                AppLog.Error("Reading how the app was installed", ex);
                return null;
            }
        }

        private static bool IsHere(RegistryKey key, string folder)
        {
            var location = (key?.GetValue("InstallLocation") as string ?? "").TrimEnd('\\');
            return location.Length > 0 && string.Equals(location, folder, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>Starts the app again, as the user and without administrator rights, once the setup has finished.</summary>
        private static void StartAppAfter(int setup)
        {
            try
            {
                var app = Application.ExecutablePath.Replace("'", "''");
                var command = "Wait-Process -Id " + setup + " -ErrorAction SilentlyContinue; Start-Process -FilePath '" + app + "'";
                Process.Start(new ProcessStartInfo("powershell.exe", "-NoProfile -NonInteractive -ExecutionPolicy Bypass -WindowStyle Hidden -Command \"" + command + "\"")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                })?.Dispose();
            }
            catch (Win32Exception ex)
            {
                // The update goes on; only the app does not open again by itself.
                AppLog.Error("Starting the app again after an update", ex);
            }
        }
    }
}

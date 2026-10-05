using System;
using System.IO;
using System.Security;
using System.Windows.Forms;
using Microsoft.Win32;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>Starts the assistant, waiting as the "AI" tab, when this Windows user signs in.</summary>
    internal static class StartupRegistration
    {
        public const string BackgroundArgument = "--background";

        private const string RunKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string ApprovedKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run";
        private const string ValueName = "SmartRetailPOS-AI-Assistant";

        /// <summary>Whether this Windows user has the sign-in entry (the setup writes it when "Start with Windows" is ticked).</summary>
        public static bool EntryExists()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(RunKey))
                {
                    return key?.GetValue(ValueName) != null;
                }
            }
            catch (Exception ex) when (ex is SecurityException || ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        /// <summary>
        /// Whether Windows' list of start-up apps (Task Manager, Settings → Apps → Startup) has the entry switched off: it stays in
        /// the Run key, but Windows does not start it.
        /// </summary>
        public static bool SwitchedOffInWindows()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(ApprovedKey))
                {
                    return StartupChoice.IsSwitchedOff(key?.GetValue(ValueName) as byte[]);
                }
            }
            catch (Exception ex) when (ex is SecurityException || ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds or removes the sign-in entry. Returns a problem to show, or null. <paramref name="switchOnInWindows"/>, for when the
        /// owner asked for it: also clears a switch-off Windows kept for the entry, so it starts again. At start the entry is only
        /// written again, never switched on against what someone chose in Windows.
        /// </summary>
        public static string Apply(bool enabled, bool switchOnInWindows = false)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(RunKey))
                {
                    if (enabled)
                    {
                        key.SetValue(ValueName, "\"" + Application.ExecutablePath + "\" " + BackgroundArgument);
                    }
                    else
                    {
                        key.DeleteValue(ValueName, throwOnMissingValue: false);
                    }
                }

                if (enabled && switchOnInWindows)
                {
                    using (var approved = Registry.CurrentUser.OpenSubKey(ApprovedKey, writable: true))
                    {
                        approved?.DeleteValue(ValueName, throwOnMissingValue: false);
                    }
                }

                return null;
            }
            catch (Exception ex) when (ex is UnauthorizedAccessException || ex is SecurityException || ex is IOException)
            {
                AppLog.Error("Start with Windows", ex);
                return "Could not change \"Start with Windows\": " + ex.Message;
            }
        }
    }
}

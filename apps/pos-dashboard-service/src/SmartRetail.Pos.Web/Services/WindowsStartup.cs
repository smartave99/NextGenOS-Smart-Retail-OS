using System.Security;
using SmartRetail.AI.Settings;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Whether this Windows user has the app's sign-in entry, read from the value the Windows app writes when "Start with Windows" is on
/// (StartupRegistration.cs in SmartRetailAI), and whether Windows' own list of start-up apps has it switched off. The dashboard only
/// reads them: turning it on or off is the app's job, by a message.
/// </summary>
public static class WindowsStartup
{
    private const string RunKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
    private const string ApprovedKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run";
    private const string ValueName = "SmartRetailPOS-AI-Assistant";

    /// <summary>True when the entry is there; false where there is no Windows registry, or it cannot be read.</summary>
    public static bool EntryExists()
    {
        if (!OperatingSystem.IsWindows())
        {
            return false;
        }

        try
        {
            using var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RunKey);
            return key?.GetValue(ValueName) is not null;
        }
        catch (Exception ex) when (ex is SecurityException or IOException or UnauthorizedAccessException)
        {
            return false;
        }
    }

    /// <summary>True when Task Manager or Settings → Apps → Startup has the entry switched off, so Windows does not start it.</summary>
    public static bool SwitchedOffInWindows()
    {
        if (!OperatingSystem.IsWindows())
        {
            return false;
        }

        try
        {
            using var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ApprovedKey);
            return StartupChoice.IsSwitchedOff(key?.GetValue(ValueName) as byte[]);
        }
        catch (Exception ex) when (ex is SecurityException or IOException or UnauthorizedAccessException)
        {
            return false;
        }
    }
}

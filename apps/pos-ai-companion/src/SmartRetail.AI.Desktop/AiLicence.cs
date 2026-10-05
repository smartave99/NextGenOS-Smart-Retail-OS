using System.Reflection;
using NextGenOS.Licensing;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// The licence of this PC for the Windows app. The licence files are shared with the POS and the dashboard (one licence per
    /// PC): activating in any of them is enough. The app needs the "ai" module.
    /// </summary>
    internal static class AiLicence
    {
        public const string Module = "ai";

        public static LicenceManager CreateManager()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return new LicenceManager(new LicenceOptions { RequiredModule = Module, AppVersion = version == null ? "0.0.0" : version.ToString() });
        }
    }
}

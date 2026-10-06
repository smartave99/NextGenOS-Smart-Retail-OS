using System;
using System.Reflection;
using NextGenOS.Licensing;

namespace DevNetLM
{
    /// <summary>The one licence manager of this PC: the POS needs the "pos" module. The AI add-on and the dashboard share the same files.</summary>
    internal static class PosLicence
    {
        private static LicenceManager _manager;
        private static readonly object Gate = new object();

        public static LicenceManager Manager
        {
            get
            {
                lock (Gate)
                {
                    if (_manager == null)
                    {
                        var version = Assembly.GetEntryAssembly() != null ? Assembly.GetEntryAssembly().GetName().Version.ToString() : "0.0.0";
                        _manager = new LicenceManager(new LicenceOptions { RequiredModule = "pos", AppVersion = version });
                    }
                    return _manager;
                }
            }
        }
    }
}

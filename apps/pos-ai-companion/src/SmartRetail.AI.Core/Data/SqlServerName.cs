using System;

namespace SmartRetail.AI.Data
{
    /// <summary>SQL Server names as the POS, the registry and people write them.</summary>
    public static class SqlServerName
    {
        public const string DefaultInstance = "MSSQLSERVER";

        /// <summary>The server name for an instance installed on this PC: the default instance is ".",
        /// a named one is ".\NAME".</summary>
        public static string ForInstance(string instanceName)
        {
            var name = (instanceName ?? "").Trim();
            return name.Length == 0 || name.Equals(DefaultInstance, StringComparison.OrdinalIgnoreCase) ? "." : @".\" + name;
        }

        /// <summary>A key that is the same for every way of writing one server, e.g. ".", "(local)", "localhost"
        /// and this PC's name, so the same server is not searched twice.</summary>
        public static string Key(string server, string machineName)
        {
            var text = (server ?? "").Trim();
            foreach (var protocol in new[] { "tcp:", "np:", "lpc:", "admin:" })
            {
                if (text.StartsWith(protocol, StringComparison.OrdinalIgnoreCase))
                {
                    text = text.Substring(protocol.Length).Trim();
                    break;
                }
            }

            var port = "";
            var comma = text.IndexOf(',');
            if (comma >= 0)
            {
                port = text.Substring(comma + 1).Trim();
                text = text.Substring(0, comma).Trim();
            }

            var instance = "";
            var slash = text.IndexOf('\\');
            if (slash >= 0)
            {
                instance = text.Substring(slash + 1).Trim();
                text = text.Substring(0, slash).Trim();
            }

            var host = text.ToLowerInvariant();
            if (host.Length == 0 || host == "." || host == "(local)" || host == "localhost" || host == "127.0.0.1" || host == "::1"
                || (!string.IsNullOrWhiteSpace(machineName) && host == machineName.Trim().ToLowerInvariant()))
            {
                host = ".";
            }

            instance = instance.ToLowerInvariant();
            if (instance == DefaultInstance.ToLowerInvariant())
            {
                instance = "";
            }

            if (port == "1433" && instance.Length == 0)
            {
                port = "";
            }

            return host + @"\" + instance + "," + port;
        }
    }
}

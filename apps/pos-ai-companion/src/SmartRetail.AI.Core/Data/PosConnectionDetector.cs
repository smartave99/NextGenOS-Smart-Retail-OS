using System.IO;
using System.Linq;
using System.Text;

namespace SmartRetail.AI.Data
{
    public sealed class PosConnectionInfo
    {
        public string Server { get; set; } = "";

        public string Database { get; set; } = "";

        public bool UseWindowsAuthentication { get; set; }

        public string UserName { get; set; } = "";

        public string Password { get; set; } = "";
    }

    /// <summary>Reads the connection the POS itself uses, from the files it keeps in its install folder:
    /// SQLSettings.dat (server, then optionally user and password) and TempDBSettings.dat (database name).</summary>
    public static class PosConnectionDetector
    {
        public const string SqlSettingsFile = "SQLSettings.dat";
        public const string DatabaseFile = "TempDBSettings.dat";

        /// <returns>The detected connection, or null when neither file exists in the folder.</returns>
        public static PosConnectionInfo Detect(string posFolder)
        {
            if (string.IsNullOrWhiteSpace(posFolder) || !Directory.Exists(posFolder))
            {
                return null;
            }

            var sqlSettings = ReadLines(Path.Combine(posFolder, SqlSettingsFile));
            var database = ReadLines(Path.Combine(posFolder, DatabaseFile));
            if (sqlSettings == null && database == null)
            {
                return null;
            }

            var info = new PosConnectionInfo();
            if (sqlSettings != null && sqlSettings.Length > 0)
            {
                info.Server = sqlSettings[0];
                info.UserName = sqlSettings.Length > 1 ? sqlSettings[1] : "";
                info.Password = sqlSettings.Length > 2 ? sqlSettings[2] : "";
            }

            info.UseWindowsAuthentication = info.UserName.Length == 0;
            info.Database = database != null && database.Length > 0 ? database[0] : "";
            return info;
        }

        private static string[] ReadLines(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            return File.ReadAllLines(path, Encoding.UTF8)
                .Select(line => line.Trim().TrimStart('﻿'))
                .Where(line => line.Length > 0)
                .ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NextGenOS.Licensing
{
    /// <summary>Gives the raw value of one hardware or system property ("bios", "board", "cpu", "disk", "os"), or null.</summary>
    public interface IFingerprintSource
    {
        string Get(string kind);
    }

    /// <summary>Spec section 7. Each part is a salted SHA-256 of one value, so no serial number leaves the PC.</summary>
    public static class DeviceFingerprint
    {
        public static readonly string[] Kinds = { "bios", "board", "cpu", "disk", "os" };

        public static string Part(string kind, string value)
        {
            using (var sha = SHA256.Create())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes("ngos-fp-v1:" + kind + ":" + value));
                var sb = new StringBuilder();
                for (var i = 0; i < 16; i++) sb.Append(hash[i].ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>kind -> part, skipping values that are empty or factory placeholders.</summary>
        public static Dictionary<string, string> Compute(IFingerprintSource source)
        {
            var result = new Dictionary<string, string>();
            foreach (var kind in Kinds)
            {
                string value = null;
                try { value = Clean(source.Get(kind)); } catch (Exception) { value = null; }
                if (value != null) result[kind] = Part(kind, value);
            }
            return result;
        }

        /// <summary>The parts as sorted "kind:hash" strings, the form stored in an activation.</summary>
        public static List<string> AsList(IDictionary<string, string> parts)
        {
            return parts.Select(p => p.Key + ":" + p.Value).OrderBy(x => x, StringComparer.Ordinal).ToList();
        }

        /// <summary>Spec section 7: at least <paramref name="required"/> stored parts present, and at least two strong parts (every kind except the CPU id).</summary>
        public static bool Matches(IList<string> stored, int required, IList<string> current)
        {
            if (stored == null || stored.Count == 0 || current == null) return false;
            var have = new HashSet<string>(current);
            var common = stored.Where(have.Contains).ToList();
            var strongStored = stored.Count(p => !p.StartsWith("cpu:", StringComparison.Ordinal));
            var strongCommon = common.Count(p => !p.StartsWith("cpu:", StringComparison.Ordinal));
            var need = Math.Max(1, Math.Min(required > 0 ? required : (int)Math.Ceiling(stored.Count * 0.6), stored.Count));
            return common.Count >= need && strongCommon >= Math.Min(2, strongStored);
        }

        public static Dictionary<string, string> ComputeForThisPc()
        {
            return Compute(CreateDefaultSource());
        }

        public static IFingerprintSource CreateDefaultSource()
        {
            return Environment.OSVersion.Platform == PlatformID.Win32NT ? (IFingerprintSource)new WindowsFingerprintSource() : new LinuxFingerprintSource();
        }

        private static readonly string[] Placeholders =
        {
            "TO BE FILLED BY O.E.M.", "DEFAULT STRING", "NONE", "NOT SPECIFIED", "NOT APPLICABLE", "N/A", "SYSTEM SERIAL NUMBER",
            "BASE BOARD SERIAL NUMBER", "SYSTEM MANUFACTURER", "SERIAL NUMBER", "UNKNOWN", "O.E.M.", "OEM", "0",
        };

        /// <summary>Trims and upper-cases; returns null for empty, placeholder or all-the-same-character values.</summary>
        public static string Clean(string value)
        {
            if (value == null) return null;
            var v = value.Trim().ToUpperInvariant();
            if (v.Length < 3) return null;
            if (Placeholders.Contains(v)) return null;
            if (v.Distinct().Count() == 1) return null;
            return v;
        }
    }

    /// <summary>WMI and the registry. Windows only.</summary>
    internal sealed class WindowsFingerprintSource : IFingerprintSource
    {
        public string Get(string kind)
        {
            switch (kind)
            {
                case "bios": return Wmi("SELECT SerialNumber FROM Win32_BIOS", "SerialNumber");
                case "board": return Wmi("SELECT SerialNumber FROM Win32_BaseBoard", "SerialNumber");
                case "cpu": return Wmi("SELECT ProcessorId FROM Win32_Processor", "ProcessorId");
                case "disk": return FirstDisk();
                case "os": return MachineGuid();
                default: return null;
            }
        }

        private static string Wmi(string query, string property)
        {
            using (var searcher = new System.Management.ManagementObjectSearcher(query))
            using (var results = searcher.Get())
            {
                foreach (System.Management.ManagementBaseObject item in results)
                {
                    var value = Convert.ToString(item[property]);
                    if (DeviceFingerprint.Clean(value) != null) return value;
                }
            }
            return null;
        }

        private static string FirstDisk()
        {
            using (var searcher = new System.Management.ManagementObjectSearcher("SELECT Index, SerialNumber FROM Win32_DiskDrive"))
            using (var results = searcher.Get())
            {
                var disks = new List<KeyValuePair<int, string>>();
                foreach (System.Management.ManagementBaseObject item in results)
                {
                    int index;
                    int.TryParse(Convert.ToString(item["Index"]), out index);
                    disks.Add(new KeyValuePair<int, string>(index, Convert.ToString(item["SerialNumber"])));
                }
                foreach (var disk in disks.OrderBy(d => d.Key))
                {
                    if (DeviceFingerprint.Clean(disk.Value) != null) return disk.Value;
                }
            }
            return null;
        }

        private static string MachineGuid()
        {
            using (var hklm = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64))
            using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography"))
            {
                return key == null ? null : Convert.ToString(key.GetValue("MachineGuid"));
            }
        }
    }

    /// <summary>For servers and tests on Linux: the machine id and, where readable, the board and product ids.</summary>
    internal sealed class LinuxFingerprintSource : IFingerprintSource
    {
        public string Get(string kind)
        {
            switch (kind)
            {
                case "os": return Read("/etc/machine-id") ?? Read("/var/lib/dbus/machine-id");
                case "board": return Read("/sys/class/dmi/id/board_serial");
                case "bios": return Read("/sys/class/dmi/id/product_uuid");
                default: return null;
            }
        }

        private static string Read(string path)
        {
            try { return File.Exists(path) ? File.ReadAllText(path).Trim() : null; } catch (Exception) { return null; }
        }
    }

    /// <summary>A fixed set of values, for tests.</summary>
    public sealed class FixedFingerprintSource : IFingerprintSource
    {
        private readonly Dictionary<string, string> _values;

        public FixedFingerprintSource(Dictionary<string, string> values) { _values = values; }

        public string Get(string kind)
        {
            string v;
            return _values.TryGetValue(kind, out v) ? v : null;
        }
    }
}

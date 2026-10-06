using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    /// <summary>A test that needs a running Licence Studio. It is skipped when none is available, and the release gate refuses a run with skips.</summary>
    public sealed class LiveFactAttribute : FactAttribute
    {
        public LiveFactAttribute()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NGOS_E2E_URL"))) Skip = "No Licence Studio: run through licensing/e2e/with-studio.mjs";
        }
    }

    /// <summary>The Studio started by with-studio.mjs, and the commands of its CLI.</summary>
    public static class LiveStudio
    {
        public static string Url { get { return Environment.GetEnvironmentVariable("NGOS_E2E_URL"); } }

        public static List<TrustedKey> Keys
        {
            get
            {
                var json = JObject.Parse(Environment.GetEnvironmentVariable("NGOS_E2E_KEYS"));
                return json["keys"].Select(k => new TrustedKey((string)k["kid"], (string)k["publicKey"])).ToList();
            }
        }

        /// <summary>Runs "cli <args>" and returns what it printed. Throws if it failed.</summary>
        public static string Cli(params string[] args)
        {
            var parts = Environment.GetEnvironmentVariable("NGOS_E2E_CLI").Split(' ');
            var psi = new ProcessStartInfo(parts[0]) { RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false };
            foreach (var p in parts.Skip(1)) psi.ArgumentList.Add(p);
            foreach (var a in args) psi.ArgumentList.Add(a);
            psi.Environment["STUDIO_DATA"] = Environment.GetEnvironmentVariable("NGOS_E2E_DATA");
            psi.Environment["NODE_NO_WARNINGS"] = "1";
            using (var proc = Process.Start(psi))
            {
                var output = proc.StandardOutput.ReadToEnd();
                var error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();
                if (proc.ExitCode != 0) throw new InvalidOperationException("Studio CLI failed: " + error + output);
                return output.Trim();
            }
        }

        private static int _counter;

        /// <summary>A new customer with a new licence. Returns (licence id, key).</summary>
        public static Tuple<string, string> NewLicence(string plan = "business", string term = "y1", params string[] extra)
        {
            var args = new List<string> { "create-licence", "--customer", "Customer " + System.Threading.Interlocked.Increment(ref _counter) + " " + Guid.NewGuid().ToString("N").Substring(0, 6), "--plan", plan, "--term", term };
            args.AddRange(extra);
            var json = JObject.Parse(Cli(args.ToArray()));
            return Tuple.Create((string)json["lid"], (string)json["key"]);
        }
    }

    /// <summary>One simulated PC: its own licence folder, its own hardware, and a clock the test can move.</summary>
    public sealed class FakePc : IDisposable
    {
        public readonly string Directory = Path.Combine(Path.GetTempPath(), "ngos-pc-" + Guid.NewGuid().ToString("N"));
        public TimeSpan ClockOffset = TimeSpan.Zero;
        public readonly Dictionary<string, string> Hardware;
        public string Server = LiveStudio.Url;
        public IList<TrustedKey> Keys = LiveStudio.Keys;
        public string Host;
        public string Module = "pos";

        public FakePc(string name)
        {
            Hardware = new Dictionary<string, string>
            {
                { "bios", name + "-BIOS-SERIAL" }, { "board", name + "-BOARD-SERIAL" }, { "cpu", name + "-CPU-ID" }, { "disk", name + "-DISK-SERIAL" }, { "os", name + "-machine-guid" },
            };
        }

        public LicenceManager Manager()
        {
            return new LicenceManager(new LicenceOptions
            {
                Directory = Directory, ServerUrl = Server, TrustedKeys = Keys, AppVersion = "2.18.0", RequiredModule = Module, Host = Host,
                Fingerprint = new FixedFingerprintSource(Hardware), UtcNow = () => DateTime.UtcNow + ClockOffset,
            });
        }

        public void Dispose()
        {
            try { System.IO.Directory.Delete(Directory, true); } catch (Exception) { }
        }
    }
}

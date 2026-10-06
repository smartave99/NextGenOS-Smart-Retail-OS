using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace NextGenOS.Licensing
{
    /// <summary>The licence files of this PC (spec section 11). Several programs of the suite share one folder, so one activation covers them all.</summary>
    public sealed class LicenceStore
    {
        private readonly object _gate = new object();

        public LicenceStore(string directory)
        {
            Directory = directory;
        }

        public string Directory { get; private set; }

        /// <summary>%ProgramData%\NextGenOS\&lt;product&gt; when it can be written (the installer should allow users to change it), otherwise the user's own folder.</summary>
        public static string DefaultDirectory(string product)
        {
            var common = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "NextGenOS", product);
            if (CanWrite(common)) return common;
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NextGenOS", product);
        }

        private static bool CanWrite(string directory)
        {
            try
            {
                System.IO.Directory.CreateDirectory(directory);
                var probe = Path.Combine(directory, ".write-test-" + Guid.NewGuid().ToString("N"));
                File.WriteAllText(probe, "x");
                File.Delete(probe);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string PathOf(string name) { return Path.Combine(Directory, name); }

        public string LicenceToken { get { return Read("licence.ngos"); } }
        public string ActivationToken { get { return Read("activation.ngos"); } }
        public string RevocationListToken { get { return Read("crl.ngos"); } }

        public void SaveLicence(string token) { Write("licence.ngos", token); }
        public void SaveActivation(string token) { Write("activation.ngos", token); }
        public void SaveRevocationList(string token) { Write("crl.ngos", token); }

        public void ClearActivation() { Delete("activation.ngos"); }

        public void ClearAll()
        {
            Delete("licence.ngos");
            Delete("activation.ngos");
            Delete("crl.ngos");
            Delete("state.json");
        }

        private string Read(string name)
        {
            lock (_gate)
            {
                try
                {
                    var path = PathOf(name);
                    return File.Exists(path) ? File.ReadAllText(path, Encoding.UTF8).Trim() : null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private void Write(string name, string content)
        {
            lock (_gate)
            {
                System.IO.Directory.CreateDirectory(Directory);
                var target = PathOf(name);
                var temp = target + "." + Guid.NewGuid().ToString("N") + ".tmp";
                File.WriteAllText(temp, (content ?? string.Empty).Trim() + "\n", new UTF8Encoding(false));
                if (File.Exists(target)) File.Delete(target);
                File.Move(temp, target);
            }
        }

        private void Delete(string name)
        {
            lock (_gate)
            {
                try { var path = PathOf(name); if (File.Exists(path)) File.Delete(path); } catch (Exception) { }
            }
        }

        // ----- state.json: the latest time this PC has seen, signed with a key made from its fingerprint -----

        private sealed class StateFile
        {
            [JsonProperty("lastSeen")] public long LastSeen { get; set; }
            [JsonProperty("lastCheckIn")] public long LastCheckIn { get; set; }
            [JsonProperty("mac")] public string Mac { get; set; }
        }

        private static string Mac(long lastSeen, long lastCheckIn, string[] fingerprint)
        {
            var key = Encoding.UTF8.GetBytes("ngos-state-v1:" + string.Join(",", fingerprint.OrderBy(x => x, StringComparer.Ordinal)));
            using (var hmac = new HMACSHA256(key))
            {
                return Base64Url.Encode(hmac.ComputeHash(Encoding.UTF8.GetBytes(lastSeen + ":" + lastCheckIn)));
            }
        }

        /// <summary>The latest time seen and the last successful check-in; zero when the file is missing or was edited.</summary>
        public void ReadState(string[] fingerprint, out long lastSeen, out long lastCheckIn)
        {
            lastSeen = 0;
            lastCheckIn = 0;
            var text = Read("state.json");
            if (text == null) return;
            try
            {
                var s = JsonConvert.DeserializeObject<StateFile>(text);
                if (s != null && s.Mac == Mac(s.LastSeen, s.LastCheckIn, fingerprint))
                {
                    lastSeen = s.LastSeen;
                    lastCheckIn = s.LastCheckIn;
                }
            }
            catch (JsonException) { }
        }

        /// <summary>After the licence server answered: its signed time is the truth, so the stored time is set to it (this is what ends a "clock tampered" state).</summary>
        public void ResetState(string[] fingerprint, long serverTime)
        {
            var s = new StateFile { LastSeen = serverTime, LastCheckIn = serverTime, Mac = Mac(serverTime, serverTime, fingerprint) };
            try { Write("state.json", JsonConvert.SerializeObject(s)); } catch (Exception) { }
        }

        /// <summary>Records the time; the stored value only ever moves forward.</summary>
        public void TouchState(string[] fingerprint, long now, bool checkedIn)
        {
            long seen;
            long checkIn;
            ReadState(fingerprint, out seen, out checkIn);
            if (!checkedIn && now < seen + 60) return; // no need to write the file on every look
            seen = Math.Max(seen, now);
            if (checkedIn) checkIn = now;
            var s = new StateFile { LastSeen = seen, LastCheckIn = checkIn, Mac = Mac(seen, checkIn, fingerprint) };
            try { Write("state.json", JsonConvert.SerializeObject(s)); } catch (Exception) { }
        }
    }
}

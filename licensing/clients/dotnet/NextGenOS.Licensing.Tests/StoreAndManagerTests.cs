using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    public class StoreAndManagerTests : IDisposable
    {
        private readonly string _dir = Path.Combine(Path.GetTempPath(), "ngos-test-" + Guid.NewGuid().ToString("N"));

        public void Dispose()
        {
            try { Directory.Delete(_dir, true); } catch (Exception) { }
        }

        [Fact]
        public void Files_are_written_whole_and_read_back()
        {
            var store = new LicenceStore(_dir);
            Assert.Null(store.LicenceToken);
            store.SaveLicence("NGOS1.a.b");
            store.SaveLicence("NGOS1.c.d");
            Assert.Equal("NGOS1.c.d", store.LicenceToken);
            store.SaveActivation("act");
            store.ClearActivation();
            Assert.Null(store.ActivationToken);
            Assert.Empty(Directory.GetFiles(_dir, "*.tmp"));
        }

        [Fact]
        public void The_time_only_moves_forward_and_an_edited_state_file_is_ignored()
        {
            var store = new LicenceStore(_dir);
            var fp = new[] { "aaa", "bbb" };
            store.TouchState(fp, 1000, false);
            store.TouchState(fp, 500, false);      // an earlier time must not lower it
            long seen, checkIn;
            store.ReadState(fp, out seen, out checkIn);
            Assert.Equal(1000, seen);

            // The same file on a PC with a different fingerprint is not believed.
            store.ReadState(new[] { "ccc", "ddd" }, out seen, out checkIn);
            Assert.Equal(0, seen);

            // Editing the number breaks the signature.
            var path = Path.Combine(_dir, "state.json");
            File.WriteAllText(path, File.ReadAllText(path).Replace("1000", "10"));
            store.ReadState(fp, out seen, out checkIn);
            Assert.Equal(0, seen);
        }

        [Fact]
        public void With_no_licence_the_state_is_Missing_and_with_junk_it_is_Invalid()
        {
            var manager = new LicenceManager(new LicenceOptions { Directory = _dir, TrustedKeys = new List<TrustedKey>(), Fingerprint = new FixedFingerprintSource(new Dictionary<string, string> { { "os", "guid-1" } }) });
            Assert.Equal(LicenceStatus.Missing, manager.Evaluate().Status);
            new LicenceStore(_dir).SaveLicence("junk");
            Assert.Equal(LicenceStatus.Invalid, manager.Evaluate().Status);
        }

        [Fact]
        public async Task A_bad_key_is_refused_before_any_network_call()
        {
            var manager = new LicenceManager(new LicenceOptions { Directory = _dir, ServerUrl = "https://licence.invalid", TrustedKeys = new List<TrustedKey>(), Fingerprint = new FixedFingerprintSource(new Dictionary<string, string> { { "os", "guid-1" } }) });
            var ex = await Assert.ThrowsAsync<LicenceServerException>(() => manager.ActivateAsync("nonsense"));
            Assert.Equal("bad_key", ex.Code);
        }

        [Fact]
        public async Task An_unreachable_server_is_reported_as_a_network_problem()
        {
            var manager = new LicenceManager(new LicenceOptions { Directory = _dir, ServerUrl = "http://127.0.0.1:1", TrustedKeys = new List<TrustedKey>(), Fingerprint = new FixedFingerprintSource(new Dictionary<string, string> { { "os", "guid-1" } }) });
            var ex = await Assert.ThrowsAsync<LicenceServerException>(() => manager.ActivateAsync("NGOS-00000-00000-00000-00000"));
            Assert.True(ex.IsNetwork);
        }

        [Fact]
        public void An_offline_request_code_holds_the_key_and_the_PC_but_no_raw_serial_numbers()
        {
            var manager = new LicenceManager(new LicenceOptions { Directory = _dir, TrustedKeys = new List<TrustedKey>(), Fingerprint = new FixedFingerprintSource(new Dictionary<string, string> { { "bios", "SECRET-SERIAL-9" }, { "os", "guid-1" } }) });
            var code = manager.CreateOfflineRequest("ngos 00000 00000 00000 00000");
            Assert.StartsWith("NGOSREQ1.", code);
            var json = System.Text.Encoding.UTF8.GetString(Base64Url.Decode(code.Substring(9)));
            Assert.Contains("NGOS-00000-00000-00000-00000", json);
            Assert.DoesNotContain("SECRET-SERIAL", json);
            Assert.Throws<LicenceException>(() => manager.ImportOfflineResponse("NGOSRES1.@@@"));
            Assert.Throws<LicenceException>(() => manager.ImportOfflineResponse("hello"));
        }

        [Fact]
        public void Base64Url_round_trips_every_length()
        {
            for (var n = 0; n < 40; n++)
            {
                var data = Enumerable.Range(0, n).Select(i => (byte)(i * 37 + 11)).ToArray();
                Assert.Equal(data, Base64Url.Decode(Base64Url.Encode(data)));
            }
        }
    }
}

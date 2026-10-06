using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    public class LegacyAdapterTests
    {
        private static LicenceState Run(string caseName, long? now = null)
        {
            var vectors = JObject.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "vectors.json")));
            var c = vectors["cases"].First(x => (string)x["name"] == caseName);
            return LicenceEvaluator.Evaluate(new EvaluationInput
            {
                LicenceToken = (string)c["lic"], ActivationToken = (string)c["act"], RevocationListToken = (string)c["crl"],
                Fingerprint = c["fp"].Children<JProperty>().Select(p => p.Name + ":" + (string)p.Value).OrderBy(x => x, StringComparer.Ordinal).ToList(),
                Now = now ?? (long)c["now"], TrustedKeys = vectors["publicKeys"].Select(k => new TrustedKey((string)k["kid"], (string)k["publicKey"])).ToList(),
            });
        }

        [Fact]
        public void A_valid_licence_gives_the_POS_what_it_asked_for()
        {
            var view = LegacyAdapter.From(Run("valid_online"), new DateTime(2027, 1, 15, 0, 0, 0, DateTimeKind.Utc));
            Assert.True(view.Allowed);
            Assert.False(view.ShowActivation);
            Assert.Equal("Smart Retail POS", view.ProductName);
            Assert.Equal("Green Mart", view.CustomerName);
            Assert.Equal("asha@greenmart.example", view.CustomerEmail);
            Assert.Equal("Business", view.CustomerPhone); // the POS shows this in a label; only "Trial" means a trial
            Assert.False(view.IsTrial);
            Assert.Equal("L-TEST0001", view.LicenceId);
            Assert.Matches("^[0-9A-F]{32}$", view.SystemId);
            Assert.True(view.Till > view.From);
        }

        [Fact]
        public void No_end_date_becomes_ten_years_so_the_expiry_reminder_stays_quiet()
        {
            var now = new DateTime(2027, 1, 15, 0, 0, 0, DateTimeKind.Utc);
            var view = LegacyAdapter.From(Run("perpetual_is_valid"), now);
            Assert.True((view.Till - now.Date).TotalDays > 3000);
        }

        [Theory]
        [InlineData("missing")]
        [InlineData("not_activated")]
        [InlineData("expired")]
        [InlineData("revoked_by_crl")]
        [InlineData("copied_to_another_pc")]
        [InlineData("tampered_licence_modules")]
        [InlineData("needs_checkin_after_grace")]
        [InlineData("clock_rolled_back")]
        public void Every_state_that_stops_the_program_says_so_and_opens_the_activation_window(string name)
        {
            var view = LegacyAdapter.From(Run(name), DateTime.UtcNow);
            Assert.False(view.Allowed);
            Assert.True(view.ShowActivation);
            Assert.False(string.IsNullOrWhiteSpace(view.Message));
        }

        [Fact]
        public void The_grace_period_still_lets_the_program_run_and_says_how_long()
        {
            var view = LegacyAdapter.From(Run("grace_after_checkin_due"), DateTime.UtcNow);
            Assert.True(view.Allowed);
            Assert.Contains("more days", view.Message);
        }

        [Fact]
        public async System.Threading.Tasks.Task The_heartbeat_reports_a_licence_that_is_no_longer_usable()
        {
            var dir = Path.Combine(Path.GetTempPath(), "ngos-hb-" + Guid.NewGuid().ToString("N"));
            try
            {
                var manager = new LicenceManager(new LicenceOptions { Directory = dir, TrustedKeys = new List<TrustedKey>(), Fingerprint = new FixedFingerprintSource(new Dictionary<string, string> { { "os", "guid-1" } }) });
                LicenceState lost = null;
                using (var beat = new LicenceHeartbeat(manager, s => lost = s))
                {
                    var state = await beat.TickAsync(); // nothing is installed: Missing
                    Assert.Equal(LicenceStatus.Missing, state.Status);
                    Assert.NotNull(lost);
                    Assert.Equal(LicenceStatus.Missing, beat.Last.Status);
                }
            }
            finally { try { Directory.Delete(dir, true); } catch (Exception) { } }
        }
    }
}

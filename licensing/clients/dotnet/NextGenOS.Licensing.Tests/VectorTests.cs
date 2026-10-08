using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    /// <summary>The Studio made these signed examples (licensing/testvectors/vectors.json); this library must reach the same decision for each.</summary>
    public class VectorTests
    {
        private static JObject Load()
        {
            return JObject.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "vectors.json")));
        }

        private static List<string> Fp(JToken map)
        {
            return map.Children<JProperty>().Select(p => p.Name + ":" + (string)p.Value).OrderBy(x => x, StringComparer.Ordinal).ToList();
        }

        public static IEnumerable<object[]> CaseNames()
        {
            return Load()["cases"].Select(c => new object[] { (string)c["name"] });
        }

        [Theory]
        [MemberData(nameof(CaseNames))]
        public void Reaches_the_same_decision_as_the_studio(string name)
        {
            var vectors = Load();
            var c = vectors["cases"].First(x => (string)x["name"] == name);
            var keys = vectors["publicKeys"].Select(k => new TrustedKey((string)k["kid"], (string)k["publicKey"])).ToList();

            var state = LicenceEvaluator.Evaluate(new EvaluationInput
            {
                LicenceToken = (string)c["lic"],
                ActivationToken = (string)c["act"],
                RevocationListToken = (string)c["crl"],
                Fingerprint = Fp(c["fp"]),
                Host = (string)c["host"],
                RequiredModule = (string)c["module"],
                Now = (long)c["now"],
                LastSeen = c["lastSeen"].Type == JTokenType.Null ? 0 : (long)c["lastSeen"],
                TrustedKeys = keys,
            });

            Assert.Equal((string)c["expect"], state.Status.ToString());
        }

        [Fact]
        public void The_vectors_cover_every_status()
        {
            var statuses = Load()["cases"].Select(c => (string)c["expect"]).Distinct().OrderBy(x => x).ToList();
            foreach (var status in Enum.GetNames(typeof(LicenceStatus)))
            {
                if (status == "NeedsCheckIn" || status == "Grace" || status == "Valid" || status == "NotActivated") Assert.Contains(status, statuses);
                else Assert.Contains(status, statuses);
            }
        }

        [Fact]
        public void A_paid_licence_past_its_end_date_keeps_working_with_a_banner_and_a_trial_stops()
        {
            var vectors = Load();
            LicenceState Run(string name)
            {
                var c = vectors["cases"].First(x => (string)x["name"] == name);
                return LicenceEvaluator.Evaluate(new EvaluationInput
                {
                    LicenceToken = (string)c["lic"], ActivationToken = c["act"].Type == JTokenType.Null ? null : (string)c["act"],
                    RevocationListToken = c["crl"].Type == JTokenType.Null ? null : (string)c["crl"],
                    Fingerprint = Fp(c["fp"]), Host = c["host"].Type == JTokenType.Null ? null : (string)c["host"],
                    Now = (long)c["now"], TrustedKeys = vectors["publicKeys"].Select(k => new TrustedKey((string)k["kid"], (string)k["publicKey"])).ToList(),
                });
            }

            var ended = Run("ended_paid_keeps_working");
            Assert.Equal(LicenceStatus.Ended, ended.Status);
            Assert.True(ended.IsUsable);
            Assert.Contains("ended on", ended.Message);
            Assert.Contains("keeps working", ended.Message);
            Assert.Equal(ended.Message, ended.Banner);                     // the program shows it across every screen
            Assert.True(ended.Licence.KeepsWorkingAfterEnd);

            var trial = Run("ended_trial_stops_even_if_it_says_banner");
            Assert.Equal(LicenceStatus.Expired, trial.Status);
            Assert.False(trial.IsUsable);
            Assert.False(trial.Licence.KeepsWorkingAfterEnd);              // a claim cannot make a trial keep working
            Assert.Null(trial.Banner);

            Assert.Equal(LicenceStatus.Expired, Run("expired").Status);    // a licence that does not say "banner" stops, as before
            Assert.Equal(LicenceStatus.Valid, Run("not_ended_paid_is_valid").Status);
            Assert.Null(Run("not_ended_paid_is_valid").Banner);
            Assert.Equal(LicenceStatus.Revoked, Run("ended_paid_that_is_revoked").Status);   // staff can always stop a licence
            Assert.Equal(LicenceStatus.Invalid, Run("end_claim_changed_after_signing").Status);
        }

        [Fact]
        public void A_trial_that_has_not_ended_shows_how_long_is_left()
        {
            var trial = new LicenceState { Status = LicenceStatus.Valid, Licence = new LicenceClaims { Trial = true, Expires = new DateTime(2026, 10, 22, 0, 0, 0, DateTimeKind.Utc).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks / TimeSpan.TicksPerSecond } };
            Assert.Contains("This is a trial. It ends on 22 October 2026", trial.Banner);
            Assert.Null(new LicenceState { Status = LicenceStatus.Valid, Licence = new LicenceClaims { Trial = false } }.Banner);
        }

        [Fact]
        public void Grace_counts_the_days_left()
        {
            var vectors = Load();
            var c = vectors["cases"].First(x => (string)x["name"] == "grace_after_checkin_due");
            var state = LicenceEvaluator.Evaluate(new EvaluationInput
            {
                LicenceToken = (string)c["lic"], ActivationToken = (string)c["act"],
                Fingerprint = Fp(c["fp"]),
                Now = (long)c["now"], TrustedKeys = vectors["publicKeys"].Select(k => new TrustedKey((string)k["kid"], (string)k["publicKey"])).ToList(),
            });
            Assert.Equal(LicenceStatus.Grace, state.Status);
            Assert.Equal(8, state.GraceDaysLeft); // until is 18 days after the start, now is 10
            Assert.True(state.IsUsable);
            Assert.Contains("8 more days", state.Message);
        }

        [Fact]
        public void The_brand_comes_from_the_licence_or_defaults_to_NextGen_OS()
        {
            var vectors = Load();
            var keys = vectors["publicKeys"].Select(k => new TrustedKey((string)k["kid"], (string)k["publicKey"])).ToList();
            var good = vectors["cases"].First(x => (string)x["name"] == "valid_online");
            var state = LicenceEvaluator.Evaluate(new EvaluationInput { LicenceToken = (string)good["lic"], ActivationToken = (string)good["act"], Fingerprint = Fp(good["fp"]), Now = (long)good["now"], TrustedKeys = keys });
            Assert.Equal("RetailPro", state.Brand.Name);
            Assert.True(state.Brand.PoweredBy);

            var none = new LicenceState { Status = LicenceStatus.Missing };
            Assert.Equal("Smart Retail POS", none.Brand.Name);
        }

        [Fact]
        public void An_empty_key_list_refuses_everything()
        {
            var vectors = Load();
            var good = vectors["cases"].First(x => (string)x["name"] == "valid_online");
            var state = LicenceEvaluator.Evaluate(new EvaluationInput { LicenceToken = (string)good["lic"], ActivationToken = (string)good["act"], Fingerprint = Fp(good["fp"]), Now = (long)good["now"], TrustedKeys = new List<TrustedKey>() });
            Assert.Equal(LicenceStatus.Invalid, state.Status);
        }
    }
}

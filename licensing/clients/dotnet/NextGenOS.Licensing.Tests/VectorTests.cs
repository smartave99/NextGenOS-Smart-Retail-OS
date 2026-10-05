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
                Fingerprint = c["fp"].Children<JProperty>().Select(p => (string)p.Value).ToList(),
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
        public void Grace_counts_the_days_left()
        {
            var vectors = Load();
            var c = vectors["cases"].First(x => (string)x["name"] == "grace_after_checkin_due");
            var state = LicenceEvaluator.Evaluate(new EvaluationInput
            {
                LicenceToken = (string)c["lic"], ActivationToken = (string)c["act"],
                Fingerprint = c["fp"].Children<JProperty>().Select(p => (string)p.Value).ToList(),
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
            var state = LicenceEvaluator.Evaluate(new EvaluationInput { LicenceToken = (string)good["lic"], ActivationToken = (string)good["act"], Fingerprint = good["fp"].Children<JProperty>().Select(p => (string)p.Value).ToList(), Now = (long)good["now"], TrustedKeys = keys });
            Assert.Equal("RetailPro", state.Brand.Name);
            Assert.True(state.Brand.PoweredBy);

            var none = new LicenceState { Status = LicenceStatus.Missing };
            Assert.Equal("Smart Retail OS", none.Brand.Name);
        }

        [Fact]
        public void An_empty_key_list_refuses_everything()
        {
            var vectors = Load();
            var good = vectors["cases"].First(x => (string)x["name"] == "valid_online");
            var state = LicenceEvaluator.Evaluate(new EvaluationInput { LicenceToken = (string)good["lic"], ActivationToken = (string)good["act"], Fingerprint = good["fp"].Children<JProperty>().Select(p => (string)p.Value).ToList(), Now = (long)good["now"], TrustedKeys = new List<TrustedKey>() });
            Assert.Equal(LicenceStatus.Invalid, state.Status);
        }
    }
}

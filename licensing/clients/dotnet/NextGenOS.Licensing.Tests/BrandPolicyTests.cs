using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NextGenOS.Licensing;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    /// <summary>The shared vectors (licensing/testvectors/brand-policy.json): the same cases the TypeScript library passes.</summary>
    public class BrandPolicyTests
    {
        private static readonly JObject Vectors = JObject.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "brand-policy.json")));

        private static JToken Expand(JToken value)
        {
            if (value.Type != JTokenType.String) return value;
            switch (value.Value<string>())
            {
                case "@logoSmall": return Vectors["logoSmall"];
                case "@oversizeLogo": return "data:image/png;base64," + new string('A', BrandPolicy.MaxLogoLength);
                case "@longText": return new string('x', 100);
                default: return value;
            }
        }

        private static LocalBrand LocalFrom(JToken local)
        {
            if (local == null || local.Type == JTokenType.Null) return null;
            var o = new JObject();
            foreach (var p in ((JObject)local).Properties()) o[p.Name] = Expand(p.Value);
            return LocalBrand.FromToken(o);
        }

        public static IEnumerable<object[]> Cases()
        {
            foreach (var c in Vectors["cases"])
            {
                var levels = c["levels"] != null ? c["levels"].Select(l => l.Type == JTokenType.Null ? null : l.Value<string>()).ToList() : new List<string> { (string)c["level"] };
                var locals = c["locals"] != null ? c["locals"].ToList() : new List<JToken> { c["local"] };
                foreach (var level in levels)
                    foreach (var local in locals)
                        yield return new object[] { (string)c["name"], level, local?.ToString(Newtonsoft.Json.Formatting.None), c["expect"].ToString(Newtonsoft.Json.Formatting.None), c["noLicenceBrand"] != null && (bool)c["noLicenceBrand"] };
            }
        }

        [Theory]
        [MemberData(nameof(Cases))]
        public void The_effective_brand_is_what_the_vectors_say(string name, string level, string localJson, string expectJson, bool noLicenceBrand)
        {
            var licence = noLicenceBrand ? null : Vectors["licence"].ToObject<BrandProfile>();
            var local = localJson == null ? null : LocalFrom(JToken.Parse(localJson));
            var result = BrandPolicy.Resolve(licence, level, local);
            foreach (var e in ((JObject)JToken.Parse(expectJson)).Properties())
            {
                var want = Expand(e.Value);
                switch (e.Name)
                {
                    case "name": Assert.Equal(want.Value<string>(), result.Name); break;
                    case "shortName": Assert.Equal(want.Value<string>(), result.ShortName); break;
                    case "shortNameLength": Assert.Equal(want.Value<int>(), result.ShortName.Length); break;
                    case "legalName": Assert.Equal(want.Value<string>(), result.LegalName); break;
                    case "id": Assert.Equal(want.Value<string>(), result.Id); break;
                    case "primaryColor": Assert.Equal(want.Value<string>(), result.PrimaryColor); break;
                    case "accentColor": Assert.Equal(want.Value<string>(), result.AccentColor); break;
                    case "logo": Assert.Equal(want.Type == JTokenType.Null ? null : want.Value<string>(), result.Logo); break;
                    case "supportEmail": Assert.Equal(want.Value<string>(), result.SupportEmail); break;
                    case "supportPhone": Assert.Equal(want.Value<string>(), result.SupportPhone); break;
                    case "websiteUrl": Assert.Equal(want.Value<string>(), result.WebsiteUrl); break;
                    case "poweredBy": Assert.Equal(want.Value<bool>(), result.PoweredBy); break;
                    default: throw new InvalidOperationException("The vectors name a field this test does not know: " + e.Name + " (in: " + name + ")");
                }
            }
        }

        [Fact]
        public void A_local_brand_that_cannot_be_read_is_an_empty_one_never_an_error()
        {
            foreach (var bad in new[] { null, "", "   ", "not json", "[1,2]", "{\"name\": 5, \"poweredBy\": \"yes\", \"primaryColor\": {\"a\":1}}", "{" })
            {
                Assert.True(LocalBrand.Parse(bad).IsEmpty, bad);
            }
        }

        [Fact]
        public void A_local_brand_survives_being_saved_and_read_again()
        {
            var original = new LocalBrand { Name = "Mine", PrimaryColor = "#aa2233", PoweredBy = false, SupportPhone = "+1 555" };
            var again = LocalBrand.Parse(original.ToJson());
            Assert.Equal("Mine", again.Name);
            Assert.Equal("#aa2233", again.PrimaryColor);
            Assert.False(again.PoweredBy);
            Assert.Equal("+1 555", again.SupportPhone);
            Assert.Null(again.Logo);
        }

        [Fact]
        public void The_input_brand_is_never_changed()
        {
            var licence = Vectors["licence"].ToObject<BrandProfile>();
            BrandPolicy.Resolve(licence, "full", new LocalBrand { Name = "Other", PrimaryColor = "#112233", PoweredBy = false });
            Assert.Equal("Luzon Fresh", licence.Name);
            Assert.Equal("#0f6cbd", licence.PrimaryColor);
            Assert.True(licence.PoweredBy);
        }
    }
}

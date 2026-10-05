using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using NextGenOS.Licensing;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    /// <summary>The shared vectors (licensing/testvectors/theme-policy.json): the same cases the JavaScript twin passes.</summary>
    public class ThemePolicyTests
    {
        private static readonly JObject Vectors = JObject.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "theme-policy.json")));

        public static IEnumerable<object[]> Cases()
        {
            foreach (var c in Vectors["cases"])
            {
                var levels = c["levels"] != null ? c["levels"].Select(l => l.Type == JTokenType.Null ? null : l.Value<string>()).ToList() : new List<string> { (string)c["level"] };
                var profiles = c["profiles"] != null ? c["profiles"].ToList() : new List<JToken> { c["profile"] };
                var locals = c["locals"] != null ? c["locals"].ToList() : new List<JToken> { c["local"] };
                foreach (var level in levels)
                    foreach (var profile in profiles)
                        foreach (var local in locals)
                            yield return new object[] { (string)c["name"], level, profile?.ToString(Newtonsoft.Json.Formatting.None) ?? "null", local?.ToString(Newtonsoft.Json.Formatting.None) ?? "null", c["expect"].ToString(Newtonsoft.Json.Formatting.None) };
            }
        }

        private static ThemeSettings From(string json)
        {
            var token = JToken.Parse(json);
            return token.Type == JTokenType.Null ? null : ThemeSettings.FromToken(token);
        }

        [Theory]
        [MemberData(nameof(Cases))]
        public void The_theme_is_what_the_vectors_say(string name, string level, string profileJson, string localJson, string expectJson)
        {
            var result = ThemePolicy.Resolve(level, From(profileJson), From(localJson));
            foreach (var e in ((JObject)JToken.Parse(expectJson)).Properties())
            {
                switch (e.Name)
                {
                    case "mode": Assert.Equal(e.Value.Value<string>(), result.Mode); break;
                    case "surface": Assert.Equal(e.Value.Value<string>(), result.Surface); break;
                    case "shape": Assert.Equal(e.Value.Value<string>(), result.Shape); break;
                    case "density": Assert.Equal(e.Value.Value<string>(), result.Density); break;
                    case "font": Assert.Equal(e.Value.Value<string>(), result.Font); break;
                    case "nav": Assert.Equal(e.Value.Value<string>(), result.Nav); break;
                    case "navLabels": Assert.Equal(e.Value.Value<string>(), result.NavLabels); break;
                    case "cart": Assert.Equal(e.Value.Value<string>(), result.Cart); break;
                    case "depth": Assert.Equal(e.Value.Value<string>(), result.Depth); break;
                    case "fontScale": Assert.Equal(e.Value.Value<double>(), result.FontScale.Value, 6); break;
                    default: throw new InvalidOperationException("The vectors name a field this test does not know: " + e.Name + " (in: " + name + ")");
                }
            }
        }

        [Fact]
        public void The_defaults_in_the_vectors_are_the_defaults_in_the_code()
        {
            var d = ThemePolicy.Defaults();
            var v = Vectors["defaults"];
            Assert.Equal((string)v["mode"], d.Mode);
            Assert.Equal((string)v["surface"], d.Surface);
            Assert.Equal((string)v["shape"], d.Shape);
            Assert.Equal((string)v["density"], d.Density);
            Assert.Equal((string)v["font"], d.Font);
            Assert.Equal((double)v["fontScale"], d.FontScale.Value, 6);
            Assert.Equal((string)v["nav"], d.Nav);
            Assert.Equal((string)v["navLabels"], d.NavLabels);
            Assert.Equal((string)v["cart"], d.Cart);
            Assert.Equal((string)v["depth"], d.Depth);
        }

        [Fact]
        public void A_theme_that_cannot_be_read_is_an_empty_one_never_an_error()
        {
            foreach (var bad in new[] { null, "", "  ", "nonsense", "[1]", "{", "{\"density\": 5, \"fontScale\": \"big\", \"nav\": {\"a\": 1}}" })
            {
                Assert.True(ThemeSettings.Parse(bad).IsEmpty, bad);
            }
        }

        [Fact]
        public void A_theme_survives_being_saved_and_read_again()
        {
            var original = new ThemeSettings { Density = "touch", Nav = "bottom", FontScale = 1.2, Shape = "pill" };
            var again = ThemeSettings.Parse(original.ToJson());
            Assert.Equal("touch", again.Density);
            Assert.Equal("bottom", again.Nav);
            Assert.Equal(1.2, again.FontScale.Value, 6);
            Assert.Equal("pill", again.Shape);
            Assert.Null(again.Font);
        }
    }
}

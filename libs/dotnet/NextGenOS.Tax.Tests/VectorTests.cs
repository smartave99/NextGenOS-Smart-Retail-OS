using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NextGenOS.Tax.Tests
{
    /// <summary>The engine contract: every case of country-packs/vectors/tax-vectors.json, answered exactly as the reference engine answers it.</summary>
    public class VectorTests
    {
        public static string RepositoryRoot()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null && !File.Exists(Path.Combine(dir.FullName, "country-packs", "SPEC.md"))) dir = dir.Parent;
            if (dir == null) throw new DirectoryNotFoundException("The repository folder with country-packs was not found above " + AppContext.BaseDirectory);
            return dir.FullName;
        }

        private static JObject Vectors()
        {
            return JObject.Parse(File.ReadAllText(Path.Combine(RepositoryRoot(), "country-packs", "vectors", "tax-vectors.json")));
        }

        public static IEnumerable<object[]> CalculationCases()
        {
            return ((JArray)Vectors()["cases"]).Select(c => new object[] { (string)c["name"] });
        }

        public static IEnumerable<object[]> FormatCases()
        {
            return ((JArray)Vectors()["formats"]).Select((c, i) => new object[] { i, (string)c["pack"] + " " + (string)c["amount"] });
        }

        [Theory]
        [MemberData(nameof(CalculationCases))]
        public void The_engine_answers_exactly_as_the_reference_does(string name)
        {
            var c = ((JArray)Vectors()["cases"]).Single(x => (string)x["name"] == name);
            var pack = c["inline"] != null ? c["inline"].ToObject<CountryPack>() : PackCatalog.Get((string)c["pack"]);
            var context = c["context"].ToObject<TaxContext>();
            var lines = c["lines"].ToObject<List<TaxLineInput>>();
            var adjustments = c["adjustments"] != null ? c["adjustments"].ToObject<List<TaxAdjustmentInput>>() : null;

            var result = TaxEngine.Calculate(pack, context, lines, adjustments);

            var actual = JToken.FromObject(result);
            var expected = c["expected"];
            Assert.True(JToken.DeepEquals(expected, actual), "Expected:\n" + expected.ToString(Formatting.Indented) + "\n\nActual:\n" + actual.ToString(Formatting.Indented));
        }

        [Theory]
        [MemberData(nameof(FormatCases))]
        public void Amounts_are_written_as_the_country_writes_them(int index, string label)
        {
            var f = ((JArray)Vectors()["formats"])[index];
            var pack = PackCatalog.Get((string)f["pack"]);
            Assert.Equal((string)f["expected"], MoneyText.Format((string)f["amount"], pack.Currency));
            Assert.False(string.IsNullOrEmpty(label));
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    public class FingerprintAndKeyTests
    {
        [Fact]
        public void A_part_is_the_same_hash_the_studio_and_node_compute()
        {
            var vectors = JObject.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "vectors.json")));
            var example = vectors["fingerprintExample"];
            Assert.Equal((string)example["part"], DeviceFingerprint.Part((string)example["kind"], (string)example["value"]));
        }

        [Theory]
        [InlineData("To be filled by O.E.M.")]
        [InlineData("Default string")]
        [InlineData("None")]
        [InlineData("00000000")]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        [InlineData("0")]
        public void Placeholder_values_are_not_used(string value)
        {
            Assert.Null(DeviceFingerprint.Clean(value));
        }

        [Fact]
        public void Real_values_are_kept_and_tidied()
        {
            Assert.Equal("ABC123", DeviceFingerprint.Clean("  abc123 "));
        }

        [Fact]
        public void Compute_skips_missing_kinds_and_never_exposes_the_raw_value()
        {
            var parts = DeviceFingerprint.Compute(new FixedFingerprintSource(new Dictionary<string, string> { { "bios", "SERIAL-1" }, { "cpu", "To be filled by O.E.M." }, { "os", "guid-1" } }));
            Assert.Equal(new[] { "bios", "os" }, parts.Keys.OrderBy(x => x).ToArray());
            Assert.All(parts.Values, v => Assert.Matches("^[0-9a-f]{32}$", v));
            Assert.DoesNotContain(parts.Values, v => v.Contains("SERIAL"));
        }

        [Fact]
        public void This_PC_gives_a_fingerprint()
        {
            Assert.NotNull(DeviceFingerprint.ComputeForThisPc());
        }

        [Theory]
        [InlineData("NGOS-0123M-4567N-89ABC-DEFGH", "NGOS-0123M-4567N-89ABC-DEFGH")]
        [InlineData("ngos 0123m 4567n 89abc defgh", "NGOS-0123M-4567N-89ABC-DEFGH")]
        [InlineData("0123M4567N89ABCDEFGH", "NGOS-0123M-4567N-89ABC-DEFGH")]
        [InlineData("NGOS-O1I1L-00000-00000-00000", "NGOS-01111-00000-00000-00000")]
        [InlineData("too short", null)]
        [InlineData("", null)]
        [InlineData(null, null)]
        [InlineData("NGOS-UUUUU-00000-00000-00000", null)]
        public void Keys_are_forgiving_to_type(string typed, string expected)
        {
            Assert.Equal(expected, LicenceKey.Normalise(typed));
        }
    }
}

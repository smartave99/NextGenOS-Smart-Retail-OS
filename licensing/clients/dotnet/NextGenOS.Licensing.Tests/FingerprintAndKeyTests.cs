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

        private static List<string> Parts(params string[] kinds)
        {
            return kinds.Select(k => k + ":" + DeviceFingerprint.Part(k, "v-" + k)).OrderBy(x => x, StringComparer.Ordinal).ToList();
        }

        [Fact]
        public void Matching_needs_most_parts_and_two_strong_ones()
        {
            var stored = Parts("bios", "board", "cpu", "disk", "os");
            Assert.True(DeviceFingerprint.Matches(stored, 3, stored));
            Assert.True(DeviceFingerprint.Matches(stored, 3, Parts("bios", "board", "cpu", "disk")));        // Windows reinstalled
            Assert.True(DeviceFingerprint.Matches(stored, 3, Parts("bios", "cpu", "os")));                   // 3 of 5, two strong
            Assert.False(DeviceFingerprint.Matches(stored, 3, Parts("cpu", "os")));                          // cloned image on the same model
            Assert.False(DeviceFingerprint.Matches(stored, 3, Parts("cpu", "bios")));                        // too few
            Assert.False(DeviceFingerprint.Matches(stored, 3, new List<string>()));
            Assert.False(DeviceFingerprint.Matches(null, 3, stored));
            Assert.False(DeviceFingerprint.Matches(new List<string>(), 1, stored));
        }

        [Fact]
        public void A_PC_with_one_part_is_matched_by_that_part_only()
        {
            var one = Parts("os");
            Assert.True(DeviceFingerprint.Matches(one, 1, one));
            Assert.False(DeviceFingerprint.Matches(one, 1, Parts("disk")));
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

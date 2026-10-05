using System;
using System.IO;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// Codex's own saved copy of its model list: removed when another Codex version fetched it (so Codex fetches the list
    /// again and the newest models show), and nothing else in Codex's folder is ever touched.
    /// </summary>
    public class CodexModelsCacheTests : IDisposable
    {
        private readonly TempFolder _temp = new TempFolder();
        private readonly string _home;

        public CodexModelsCacheTests()
        {
            _home = Path.Combine(_temp.Path, "codex-home");
            Directory.CreateDirectory(_home);
        }

        public void Dispose() => _temp.Dispose();

        private string Cache => Path.Combine(_home, CodexModelsCache.FileName);

        private void WriteCache(string version, string models = "[]") =>
            File.WriteAllText(Cache, "{\"fetched_at\":\"2026-10-01T09:00:00Z\",\"etag\":\"abc\",\"client_version\":\"" + version + "\",\"models\":" + models + "}");

        [Fact]
        public void A_copy_fetched_by_an_older_codex_is_removed_so_codex_fetches_its_list_again()
        {
            WriteCache("0.142.3");
            Assert.Equal("0.142.3", CodexModelsCache.VersionOf(_home));

            Assert.True(CodexModelsCache.RemoveIfFromOtherVersion(_home, "0.158.0"));

            Assert.False(File.Exists(Cache));
        }

        [Theory]
        [InlineData("0.158.0")]
        [InlineData(" v0.158.0 ")]
        public void A_copy_from_the_installed_version_stays(string installed)
        {
            WriteCache("0.158.0");

            Assert.False(CodexModelsCache.RemoveIfFromOtherVersion(_home, installed));

            Assert.True(File.Exists(Cache));
        }

        [Fact]
        public void A_copy_that_does_not_name_its_version_or_is_not_one_is_left_alone()
        {
            File.WriteAllText(Cache, "{\"models\":[]}");
            Assert.False(CodexModelsCache.RemoveIfFromOtherVersion(_home, "0.158.0"));
            Assert.True(File.Exists(Cache));

            File.WriteAllText(Cache, "not json at all");
            Assert.Equal("", CodexModelsCache.VersionOf(_home));
            Assert.False(CodexModelsCache.RemoveIfFromOtherVersion(_home, "0.158.0"));

            File.WriteAllText(Cache, "[1,2,3]");
            Assert.Equal("", CodexModelsCache.VersionOf(_home));

            File.WriteAllText(Cache, "{\"client_version\":158}");
            Assert.Equal("", CodexModelsCache.VersionOf(_home));
            Assert.True(File.Exists(Cache));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void Nothing_is_removed_when_the_installed_version_is_not_known(string installed)
        {
            WriteCache("0.142.3");

            Assert.False(CodexModelsCache.RemoveIfFromOtherVersion(_home, installed));

            Assert.True(File.Exists(Cache));
        }

        [Fact]
        public void No_folder_no_file_or_a_folder_that_is_not_there_is_not_a_problem()
        {
            Assert.Equal("", CodexModelsCache.VersionOf(null));
            Assert.Equal("", CodexModelsCache.VersionOf(""));
            Assert.Equal("", CodexModelsCache.VersionOf(Path.Combine(_temp.Path, "nowhere")));
            Assert.False(CodexModelsCache.RemoveIfFromOtherVersion(_home, "0.158.0"));
            Assert.False(CodexModelsCache.RemoveIfFromOtherVersion(null, "0.158.0"));
            Assert.False(CodexModelsCache.RemoveIfFromOtherVersion(Path.Combine(_temp.Path, "nowhere"), "0.158.0"));
        }

        [Fact]
        public void Only_that_one_file_is_ever_removed()
        {
            WriteCache("0.142.3");
            var keep = new[] { "auth.json", "config.toml", "models_cache.json.bak", "other_cache.json", Path.Combine("sessions", "models_cache.json") };
            foreach (var name in keep)
            {
                var path = Path.Combine(_home, name);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, "{\"client_version\":\"0.1.0\"}");
            }

            Assert.True(CodexModelsCache.RemoveIfFromOtherVersion(_home, "0.158.0"));

            Assert.False(File.Exists(Cache));
            foreach (var name in keep)
            {
                Assert.True(File.Exists(Path.Combine(_home, name)), name);
            }
        }

        [Fact]
        public void A_huge_file_is_not_read()
        {
            using (var stream = File.Create(Cache))
            {
                stream.SetLength(6 * 1024 * 1024);
            }

            Assert.Equal("", CodexModelsCache.VersionOf(_home));
            Assert.False(CodexModelsCache.RemoveIfFromOtherVersion(_home, "0.158.0"));
            Assert.True(File.Exists(Cache));
        }

        [Fact]
        public void A_model_name_typed_in_by_hand_is_checked_like_a_chosen_one()
        {
            Assert.Equal("gpt-6.1-sol", AiJobs.ModelId("gpt-6.1-sol"));
            Assert.Equal("gpt-6.1-sol", AiJobs.ModelId("  gpt-6.1-sol  "));
            Assert.Equal("o3_mini", AiJobs.ModelId("o3_mini"));
            Assert.Equal("", AiJobs.ModelId("gpt 6.1 sol"));
            Assert.Equal("", AiJobs.ModelId("gpt-6; del *"));
            Assert.Equal("", AiJobs.ModelId("models/gpt-6"));
            Assert.Equal("", AiJobs.ModelId(new string('a', 81)));
            Assert.Equal("", AiJobs.ModelId(null));
            Assert.Equal("", AiJobs.ModelId("   "));
        }
    }
}

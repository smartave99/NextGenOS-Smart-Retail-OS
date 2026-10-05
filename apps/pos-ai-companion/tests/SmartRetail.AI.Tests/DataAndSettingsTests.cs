using System;
using System.IO;
using System.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class SchemaCatalogTests
    {
        [Theory]
        [InlineData("Password", true)]
        [InlineData("FtpPassword", true)]
        [InlineData("token_id", true)]
        [InlineData("APIUrl", true)]
        [InlineData("HardwareID", true)]
        [InlineData("AccountNumber", true)]
        [InlineData("IFSCCode", true)]
        [InlineData("GrandTotal", false)]
        [InlineData("Optype", false)]
        [InlineData("ContactNo", false)]
        public void Knows_which_columns_are_private(string column, bool denied)
        {
            Assert.Equal(denied, SchemaCatalog.IsDeniedColumn(column));
        }

        [Fact]
        public void The_prompt_schema_hides_private_and_binary_columns()
        {
            var text = SchemaCatalog.DescribeForPrompt(SchemaCatalog.BuiltInColumns(SchemaCatalog.BusinessTables));

            Assert.Contains("InvoiceInfo: Inv_ID int, InvoiceNo nchar(30), InvoiceDate datetime", text);
            Assert.Contains("Temp_Stock:", text);
            Assert.DoesNotContain("AccountNumber", text);
            Assert.DoesNotContain("QrBarcode", text);
            Assert.DoesNotContain("Photo", text);
            Assert.DoesNotContain("AdminCode", text);
        }

        [Fact]
        public void Every_business_table_exists_in_the_pos_schema()
        {
            foreach (var table in SchemaCatalog.BusinessTables)
            {
                Assert.Contains(table, SchemaCatalog.KnownTables);
                Assert.NotEmpty(SchemaCatalog.BuiltInColumns(new[] { table }));
            }

            Assert.Equal(196, SchemaCatalog.KnownTables.Count);
        }

        [Fact]
        public void Every_quick_insight_passes_the_safety_check()
        {
            var guard = SchemaCatalog.CreateGuard(new PrivacySettings());
            foreach (var insight in QuickInsights.All)
            {
                var result = guard.Check(insight.Sql);
                Assert.True(result.IsAllowed, insight.Title + ": " + result.Reason);
            }
        }
    }

    public class ResultHandlingTests
    {
        [Fact]
        public void Masking_hides_contact_columns_and_numbers_in_text()
        {
            var result = FakeQueryExecutor.Table(new[] { "Name", "ContactNo", "EmailID", "Remarks", "GrandTotal" },
                new object[] { "Sita", "9876543210", "sita@example.com", "alt 91-9123456780", 250m });

            var masked = PiiMasker.Mask(result).Rows[0];

            Assert.Equal("Sita", masked[0]);
            Assert.Equal("98******10", masked[1]);
            Assert.DoesNotContain("example", (string)masked[2]);
            Assert.DoesNotContain("9123456780", (string)masked[3]);
            Assert.Equal(250m, masked[4]);
            Assert.Equal("9876543210", result.Rows[0][1]);
        }

        [Fact]
        public void Prompt_tables_are_culture_invariant_and_note_truncation()
        {
            var result = new QueryResult(new[] { "Day", "Sales", "Note" },
                new[] { new object[] { new DateTime(2026, 9, 24), 125000.5m, "a|b\nc" }, new object[] { null, 1m, "x" } },
                truncated: true, duration: TimeSpan.Zero);

            var text = ResultFormatter.ToPromptTable(result, maxRows: 1);

            Assert.Contains("Day | Sales | Note", text);
            Assert.Contains("2026-09-24 | 125000.5 | a/b c", text);
            Assert.DoesNotContain("NULL", text);
            Assert.Contains("showing the first 1 rows", text);
        }

        [Theory]
        [InlineData("{\"sql\": \"SELECT 1\", \"explanation\": \"x\"}", "SELECT 1", "x")]
        [InlineData("```json\n{\"sql\": \"SELECT 2\"}\n```", "SELECT 2", null)]
        [InlineData("```sql\nSELECT 3 FROM InvoiceInfo\n```", "SELECT 3 FROM InvoiceInfo", null)]
        [InlineData("SELECT 4", "SELECT 4", null)]
        [InlineData("{\"sql\": null, \"explanation\": \"Not about the shop.\"}", null, "Not about the shop.")]
        [InlineData("Sorry, I cannot help with that.", null, "Sorry, I cannot help with that.")]
        public void Reads_the_ai_query_plan_in_any_common_shape(string reply, string sql, string explanation)
        {
            var plan = SqlPlan.Parse(reply);
            Assert.Equal(sql, plan.Sql);
            Assert.Equal(explanation, plan.Explanation);
        }
    }

    public class PosConnectionDetectorTests
    {
        [Fact]
        public void Reads_the_pos_connection_files()
        {
            using (var folder = new TempFolder())
            {
                folder.File(PosConnectionDetector.SqlSettingsFile, "DESKTOP-SHOP\\SQLEXPRESS\r\nsa\r\n12345\r\n");
                folder.File(PosConnectionDetector.DatabaseFile, "Raintech_DB1");

                var info = PosConnectionDetector.Detect(folder.Path);

                Assert.Equal("DESKTOP-SHOP\\SQLEXPRESS", info.Server);
                Assert.Equal("Raintech_DB1", info.Database);
                Assert.Equal("sa", info.UserName);
                Assert.Equal("12345", info.Password);
                Assert.False(info.UseWindowsAuthentication);
            }
        }

        [Fact]
        public void A_server_line_alone_means_windows_authentication()
        {
            using (var folder = new TempFolder())
            {
                folder.File(PosConnectionDetector.SqlSettingsFile, ".\\SQLEXPRESS");
                var info = PosConnectionDetector.Detect(folder.Path);
                Assert.True(info.UseWindowsAuthentication);
                Assert.Equal("", info.Database);
            }
        }

        [Fact]
        public void Returns_null_for_a_folder_without_pos_files()
        {
            using (var folder = new TempFolder())
            {
                Assert.Null(PosConnectionDetector.Detect(folder.Path));
            }

            Assert.Null(PosConnectionDetector.Detect(null));
        }
    }

    public class SettingsTests
    {
        [Fact]
        public void Defaults_put_codex_first_and_use_current_models()
        {
            using (var folder = new TempFolder())
            {
                var settings = new SettingsStore(Path.Combine(folder.Path, "settings.json")).Load();

                Assert.Equal(ProviderIds.Auto, settings.PreferredProvider);
                Assert.Equal(ProviderIds.CodexCli, settings.ProviderOrder[0]);
                Assert.Equal(ProviderIds.DefaultOrder.Length, settings.ProviderOrder.Count);
                Assert.Equal("claude-opus-5", settings.Anthropic.Model);
                Assert.Equal("claude-opus-5", settings.ClaudeCli.Model);
                Assert.Equal("gpt-6-sol", settings.OpenAi.Model);
                Assert.Equal("gemini-3.5-flash", settings.Gemini.Model);
                Assert.True(settings.Privacy.MaskContactDetails);
            }
        }

        [Fact]
        public void Saving_and_loading_keeps_lists_without_duplicates()
        {
            using (var folder = new TempFolder())
            {
                var store = new SettingsStore(Path.Combine(folder.Path, "nested", "settings.json"));
                var settings = store.Load();
                settings.ProviderOrder = new[] { ProviderIds.GeminiApi, ProviderIds.CodexCli }.ToList();
                settings.Privacy.ExtraAllowedTables.Add("Estimate");
                store.Save(settings);
                store.Save(settings);

                var loaded = store.Load();

                Assert.Equal(ProviderIds.GeminiApi, loaded.ProviderOrder[0]);
                Assert.Equal(ProviderIds.CodexCli, loaded.ProviderOrder[1]);
                Assert.Equal(ProviderIds.DefaultOrder.Length, loaded.ProviderOrder.Count);
                Assert.Equal(new[] { "Estimate" }, loaded.Privacy.ExtraAllowedTables);
            }
        }

        [Theory]
        [InlineData("{ \"Posters\": null }", 30)]
        [InlineData("{ \"Posters\": { \"MaxOfferPercent\": 20 } }", 20)]
        [InlineData("{ \"Posters\": { \"MaxOfferPercent\": 95 } }", 30)]
        [InlineData("{ }", 30)]
        public void The_poster_offer_limit_falls_back_to_thirty_percent(string json, int expected)
        {
            using (var folder = new TempFolder())
            {
                var settings = new SettingsStore(folder.File("settings.json", json)).Load();

                Assert.Equal(expected, settings.Posters.CheckedMaxOfferPercent);
            }
        }

        [Theory]
        [InlineData("{ \"Stickers\": null }", "a4-65", true)]
        [InlineData("{ }", "a4-65", true)]
        [InlineData("{ \"Stickers\": { \"Paper\": \"a4-24\", \"ShowMrp\": false } }", "a4-24", false)]
        public void Sticker_choices_come_back_or_fall_back_to_a_65_sticker_sheet(string json, string paper, bool showMrp)
        {
            using (var folder = new TempFolder())
            {
                var settings = new SettingsStore(folder.File("settings.json", json)).Load();

                Assert.Equal((paper, showMrp, true), (settings.Stickers.Paper, settings.Stickers.ShowMrp, settings.Stickers.ShowPrice));
            }
        }

        [Fact]
        public void A_corrupt_file_is_kept_aside_and_defaults_are_used()
        {
            using (var folder = new TempFolder())
            {
                var path = folder.File("settings.json", "{ not json");
                var settings = new SettingsStore(path).Load();

                Assert.Equal(ProviderIds.CodexCli, settings.ProviderOrder[0]);
                Assert.True(File.Exists(path + ".bad"));
            }
        }

        [Fact]
        public void Unknown_providers_are_dropped_and_new_ones_added()
        {
            var settings = new AssistantSettings { PreferredProvider = "retired-tool" };
            settings.ProviderOrder = new[] { "retired-tool", ProviderIds.ClaudeCli, ProviderIds.ClaudeCli }.ToList();

            settings.Normalize();

            Assert.Equal(ProviderIds.Auto, settings.PreferredProvider);
            Assert.Equal(ProviderIds.ClaudeCli, settings.ProviderOrder[0]);
            Assert.Equal(ProviderIds.DefaultOrder.Length, settings.ProviderOrder.Count);
        }

        [Fact]
        public void Secrets_are_stored_encrypted_and_can_be_removed()
        {
            var (settings, secrets) = TestSettings.Create();

            secrets.Set(SecretNames.OpenAiApiKey, "  sk-live-123  ");

            Assert.Equal("sk-live-123", secrets.Get(SecretNames.OpenAiApiKey));
            Assert.DoesNotContain("sk-live-123", settings.ProtectedSecrets[SecretNames.OpenAiApiKey]);
            secrets.Set(SecretNames.OpenAiApiKey, "");
            Assert.False(secrets.Has(SecretNames.OpenAiApiKey));
        }

        [Fact]
        public void A_secret_saved_by_another_user_reads_as_missing()
        {
            var (settings, secrets) = TestSettings.Create();
            settings.ProtectedSecrets[SecretNames.AnthropicApiKey] = "AQAAANCMnd8BFdERjHoAwE/Cl+s=";
            Assert.Null(secrets.Get(SecretNames.AnthropicApiKey));
        }
    }
}

using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Each job's model and thinking level: recommended, the owner's, and what reaches the AI tools.</summary>
    public class AiJobsTests
    {
        [Fact]
        public void Each_job_thinks_as_much_as_it_needs_and_no_more()
        {
            Assert.Equal(
                new[] { ("Ask AI", "medium"), ("Growth plan", "high"), ("Poster words", "medium"), ("Poster artwork", "low"), ("Product photos", "low"), ("Learning from chats", "low"), ("Product listings", "medium"), ("Creatives", "medium"), ("Playbooks", "medium"), ("Price check", "medium"), ("Website category", "low") },
                AiJobs.All.Select(job => (AiJobs.Name(job), AiJobs.RecommendedEffort(job))));
            Assert.Equal(("", "high"), AiJobs.Resolve(new AssistantSettings(), AiJob.Plan));
        }

        [Fact]
        public void The_owners_choice_for_a_job_comes_first_then_the_tools_own_setting_then_the_recommendation()
        {
            var settings = new AssistantSettings();
            settings.Codex.Model = "gpt-6-sol";
            settings.Codex.ReasoningEffort = "medium";
            settings.SetChoice(AiJob.Photos, new AiJobChoice { Effort = "High" });

            Assert.Equal(("gpt-6-sol", "high"), AiJobs.Resolve(settings, AiJob.Photos));
            Assert.Equal(("gpt-6-sol", "medium"), AiJobs.Resolve(settings, AiJob.Plan)); // set for the tool: it wins over "high"

            settings.Codex.ReasoningEffort = "";
            settings.SetChoice(AiJob.Ask, new AiJobChoice { Model = "gpt-6-mini" });
            Assert.Equal(("gpt-6-mini", "medium"), AiJobs.Resolve(settings, AiJob.Ask));
        }

        [Fact]
        public void A_job_back_on_its_recommendation_is_not_kept_and_odd_values_are_refused()
        {
            var settings = new AssistantSettings();
            settings.SetChoice(AiJob.Ask, new AiJobChoice { Model = "gpt-6-mini", Effort = "low" });
            settings.SetChoice(AiJob.Ask, new AiJobChoice());
            settings.SetChoice(AiJob.Plan, new AiJobChoice { Model = "gpt; rm -rf /", Effort = "high" });

            Assert.False(settings.Jobs.ContainsKey("Ask"));
            Assert.Equal(("", "high"), (settings.Choice(AiJob.Plan).Model, settings.Choice(AiJob.Plan).Effort));
        }

        [Fact]
        public void Every_command_line_tool_gets_the_jobs_thinking_level_at_the_nearest_level_it_has()
        {
            var settings = new AssistantSettings();
            settings.ClaudeCli.Effort = "max";
            AiJobs.Apply(settings, AiJob.Plan);
            Assert.Equal(("high", "max", "high"), (settings.Codex.ReasoningEffort, settings.ClaudeCli.Effort, settings.Antigravity.Effort));

            var chosen = new AssistantSettings();
            chosen.SetChoice(AiJob.Ask, new AiJobChoice { Effort = "xhigh" });
            AiJobs.Apply(chosen, AiJob.Ask);
            Assert.Equal(("xhigh", "xhigh", "high"), (chosen.Codex.ReasoningEffort, chosen.ClaudeCli.Effort, chosen.Antigravity.Effort));
        }

        [Theory]
        [InlineData("high", "low,medium", "medium")]
        [InlineData("xhigh", "low,medium,high", "high")]
        [InlineData("minimal", "low,medium,high,xhigh,max", "low")]
        [InlineData("Medium", "low,medium", "medium")]
        [InlineData("", "low,medium", "")]
        [InlineData("high", "", "")]
        [InlineData("ultra", "low,medium", "")]
        [InlineData("high", "low,ultra", "low")]
        public void A_thinking_level_fits_the_nearest_one_a_tool_or_model_has(string wanted, string levels, string fitted) =>
            Assert.Equal(fitted, AiJobs.Fit(wanted, levels.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries)));

        [Fact]
        public void A_job_is_described_on_the_ai_tool_it_runs_on()
        {
            var settings = new AssistantSettings { PreferredProvider = ProviderIds.ClaudeCli };
            settings.ClaudeCli.Effort = "max";
            Assert.Equal(("claude-opus-5", "max"), AiJobs.Resolve(settings, AiJob.Ask)); // Claude's own level, not Codex's
            Assert.Equal("max", AiJobs.DefaultEffort(settings, AiJob.Ask));
            settings.SetChoice(AiJob.Ask, new AiJobChoice { Effort = "high" });
            Assert.Equal(("claude-opus-5", "high"), AiJobs.Resolve(settings, AiJob.Ask));
            Assert.Equal("Claude Code", AiJobs.ToolName(settings));

            settings.PreferredProvider = ProviderIds.AntigravityCli;
            settings.SetChoice(AiJob.Ask, new AiJobChoice { Effort = "xhigh" });
            Assert.Equal(("", "high"), AiJobs.Resolve(settings, AiJob.Ask));

            settings.PreferredProvider = ProviderIds.AnthropicApi;
            Assert.Equal(("", ""), AiJobs.Resolve(settings, AiJob.Ask)); // it thinks as it sees fit
            Assert.Empty(AiJobs.Efforts(AiJobs.Tool(settings)));

            settings.PreferredProvider = ProviderIds.Auto;
            Assert.Equal((ProviderIds.CodexCli, "", "xhigh"), (AiJobs.Tool(settings), AiJobs.Resolve(settings, AiJob.Ask).Model, AiJobs.Resolve(settings, AiJob.Ask).Effort));
        }

        [Fact]
        public async Task Codex_runs_a_job_with_its_model_and_thinking_level()
        {
            var settings = new AssistantSettings();
            settings.SetChoice(AiJob.PosterWords, new AiJobChoice { Model = "gpt-6-mini" });
            AiJobs.Apply(settings, AiJob.PosterWords);
            var runner = new FakeCliRunner();
            runner.Handler = call =>
            {
                File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), "ok");
                return new CliResult();
            };

            using (var temp = new TempFolder())
            {
                settings.Codex.ExecutablePath = temp.File("codex-tool");
                await new CodexCliProvider(runner, () => settings, Path.Combine(temp.Path, "runs")).CompleteAsync(new AiRequest { SystemPrompt = "s", UserPrompt = "u" }, CancellationToken.None);
            }

            var invocation = runner.Calls.Single();
            Assert.Equal("gpt-6-mini", FakeCliRunner.ArgumentAfter(invocation, "--model"));
            Assert.Equal("model_reasoning_effort=medium", FakeCliRunner.ArgumentAfter(invocation, "--config"));
        }

        [Fact]
        public void The_model_typed_for_the_tool_the_jobs_run_on_is_told_so_a_newer_one_can_be_typed_where_it_is_kept()
        {
            var settings = new AssistantSettings();
            Assert.Equal("", AiJobs.ToolModel(settings)); // Codex: its own default
            Assert.Equal("", AiJobs.ToolModel(null));

            settings.Codex.Model = " gpt-6-sol ";
            Assert.Equal("gpt-6-sol", AiJobs.ToolModel(settings));

            settings.PreferredProvider = ProviderIds.ClaudeCli;
            Assert.Equal("claude-opus-5", AiJobs.ToolModel(settings));

            settings.PreferredProvider = ProviderIds.AntigravityCli;
            Assert.Equal("", AiJobs.ToolModel(settings));
            settings.Antigravity.Model = "gemini-3.5-pro";
            Assert.Equal("gemini-3.5-pro", AiJobs.ToolModel(settings));

            settings.PreferredProvider = ProviderIds.OpenAiApi;
            Assert.Equal("gpt-6-sol", AiJobs.ToolModel(settings));
            settings.PreferredProvider = ProviderIds.AnthropicApi;
            Assert.Equal("claude-opus-5", AiJobs.ToolModel(settings));
            settings.PreferredProvider = ProviderIds.GeminiApi;
            Assert.Equal("gemini-3.5-flash", AiJobs.ToolModel(settings));
            settings.PreferredProvider = ProviderIds.OpenAiCompatibleApi;
            Assert.Equal("", AiJobs.ToolModel(settings));
            settings.PreferredProvider = ProviderIds.CustomCli;
            settings.CustomCli.Model = "my-model";
            Assert.Equal("my-model", AiJobs.ToolModel(settings));
        }

        [Fact]
        public void The_choices_are_kept_in_the_settings_file_and_unknown_jobs_dropped()
        {
            using (var folder = new TempFolder())
            {
                var store = new SettingsStore(Path.Combine(folder.Path, "settings.json"));
                var settings = new AssistantSettings();
                settings.SetChoice(AiJob.MemoryReview, new AiJobChoice { Effort = "medium" });
                settings.Jobs["Dance"] = new AiJobChoice { Effort = "high" };
                store.Save(settings);

                var loaded = store.Load();

                Assert.Equal(new[] { "MemoryReview" }, loaded.Jobs.Keys);
                Assert.DoesNotContain("IsRecommended", File.ReadAllText(Path.Combine(folder.Path, "settings.json")));
                Assert.Equal("medium", loaded.Choice(AiJob.MemoryReview).Effort);
                Assert.Equal(new[] { "Recommended", "Low", "Extra high" }, new[] { "", "low", "xhigh" }.Select(AiJobs.EffortName));
            }
        }
    }
}

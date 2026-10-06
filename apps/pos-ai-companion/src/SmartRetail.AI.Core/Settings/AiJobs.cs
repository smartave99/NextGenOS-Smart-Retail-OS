using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SmartRetail.AI.Providers;

namespace SmartRetail.AI.Settings
{
    /// <summary>The jobs the AI does, each with its own model and thinking level.</summary>
    public enum AiJob
    {
        /// <summary>Ask AI, in the app and the side panel.</summary>
        Ask,

        /// <summary>The growth plan.</summary>
        Plan,

        /// <summary>A poster's products and words.</summary>
        PosterWords,

        /// <summary>A poster's artwork, without text.</summary>
        PosterArtwork,

        /// <summary>The five product photos.</summary>
        Photos,

        /// <summary>The review after a chat, for memory.</summary>
        MemoryReview,

        /// <summary>A product's listings for Amazon and the shop's website, from its photos.</summary>
        Listing,

        /// <summary>An advertising creative, designed with the image tool.</summary>
        Creative,

        /// <summary>A playbook, written or improved from an action and what came of it.</summary>
        Playbook,

        /// <summary>A product's prices in online shops, read from the web.</summary>
        PriceCheck,

        /// <summary>A product's category on the shop's website, chosen from the website's own list.</summary>
        WebsiteCategory,
    }

    /// <summary>The owner's choice for one job; empty means the recommended one.</summary>
    public sealed class AiJobChoice
    {
        /// <summary>A Codex model id, e.g. from its model list; empty for Codex's default.</summary>
        public string Model { get; set; } = "";

        /// <summary>A thinking level, e.g. "low", "medium" or "high"; empty for the job's recommended one.</summary>
        public string Effort { get; set; } = "";

        [JsonIgnore]
        public bool IsRecommended => string.IsNullOrWhiteSpace(Model) && string.IsNullOrWhiteSpace(Effort);
    }

    /// <summary>
    /// Each job's model and thinking level. Thinking longer costs more of the Codex limit and takes longer, so each job
    /// gets the least it needs: a quick answer thinks a little, the growth plan thinks hard. The owner can change any
    /// job, and go back to the recommended one. The model and the thinking level are the chosen tool's: Codex's, Claude Code's or
    /// Antigravity's, the level at the nearest one the tool has. Other AI tools choose for themselves.
    /// </summary>
    public static class AiJobs
    {
        public static IReadOnlyList<AiJob> All { get; } = (AiJob[])Enum.GetValues(typeof(AiJob));

        /// <summary>The thinking levels every AI tool here understands, least first.</summary>
        public static IReadOnlyList<string> CommonEfforts { get; } = new[] { "low", "medium", "high" };

        /// <summary>Every thinking level any of the tools has, least first.</summary>
        private static readonly string[] Levels = { "none", "minimal", "low", "medium", "high", "xhigh", "max" };

        private static readonly string[] ClaudeEfforts = { "low", "medium", "high", "xhigh", "max" };

        private static readonly string[] AntigravityEfforts = { "low", "medium", "high" };

        /// <summary>The AI tool the jobs run on: the one chosen in the settings, or Codex for "auto", which tries it first.</summary>
        public static string Tool(AssistantSettings settings) =>
            settings == null || string.IsNullOrWhiteSpace(settings.PreferredProvider) || settings.PreferredProvider == ProviderIds.Auto
                ? ProviderIds.CodexCli
                : settings.PreferredProvider;

        /// <summary>E.g. "Claude Code", for saying which tool runs the jobs.</summary>
        public static string ToolName(AssistantSettings settings)
        {
            switch (Tool(settings))
            {
                case ProviderIds.CodexCli: return "Codex";
                case ProviderIds.ClaudeCli: return "Claude Code";
                case ProviderIds.AntigravityCli: return "Antigravity";
                case ProviderIds.OpenAiApi: return "the OpenAI API";
                case ProviderIds.AnthropicApi: return "the Claude API";
                case ProviderIds.GeminiApi: return "the Gemini API";
                case ProviderIds.OpenAiCompatibleApi: return "an OpenAI-compatible API";
                default: return string.IsNullOrWhiteSpace(settings?.CustomCli?.DisplayName) ? "your own AI tool" : settings.CustomCli.DisplayName.Trim();
            }
        }

        /// <summary>
        /// The model typed for the tool the jobs run on in Advanced settings (empty: the tool's own choice). The models of Codex come
        /// from Codex itself, those of Claude from Anthropic (<see cref="CliToolCare"/>); a model that is in no list is used once its name is typed.
        /// </summary>
        public static string ToolModel(AssistantSettings settings)
        {
            if (settings == null)
            {
                return "";
            }

            switch (Tool(settings))
            {
                case ProviderIds.CodexCli: return First(settings.Codex?.Model);
                case ProviderIds.ClaudeCli: return First(settings.ClaudeCli?.Model);
                case ProviderIds.AntigravityCli: return First(settings.Antigravity?.Model);
                case ProviderIds.OpenAiApi: return First(settings.OpenAi?.Model);
                case ProviderIds.AnthropicApi: return First(settings.Anthropic?.Model);
                case ProviderIds.GeminiApi: return First(settings.Gemini?.Model);
                case ProviderIds.OpenAiCompatibleApi: return First(settings.OpenAiCompatible?.Model);
                default: return First(settings.CustomCli?.Model);
            }
        }

        /// <summary>The thinking levels <paramref name="tool"/> has; empty for a tool that chooses for itself. Codex's
        /// depend on the model (its list says): these are the ones every model has.</summary>
        public static IReadOnlyList<string> Efforts(string tool)
        {
            switch (tool)
            {
                case ProviderIds.CodexCli: return CommonEfforts;
                case ProviderIds.ClaudeCli: return ClaudeEfforts;
                case ProviderIds.AntigravityCli: return AntigravityEfforts;
                default: return Array.Empty<string>();
            }
        }

        /// <summary>
        /// The level nearest <paramref name="wanted"/> that <paramref name="levels"/> has: the level itself, else the
        /// highest one below it, else the lowest one above it. Empty when there are no levels, none is wanted, or the
        /// wanted one is not a level known here (the tool then uses its own).
        /// </summary>
        public static string Fit(string wanted, IEnumerable<string> levels)
        {
            var have = (levels ?? Enumerable.Empty<string>()).Select(l => (l ?? "").Trim().ToLowerInvariant()).Where(l => l.Length > 0).Distinct().ToList();
            var want = (wanted ?? "").Trim().ToLowerInvariant();
            if (want.Length == 0 || have.Count == 0 || have.Contains(want))
            {
                return have.Count == 0 ? "" : want;
            }

            var rank = Array.IndexOf(Levels, want);
            var known = have.Where(l => Array.IndexOf(Levels, l) >= 0).OrderBy(l => Array.IndexOf(Levels, l)).ToList();
            if (rank < 0 || known.Count == 0)
            {
                return "";
            }

            return known.LastOrDefault(l => Array.IndexOf(Levels, l) < rank) ?? known[0];
        }

        public static string Name(AiJob job)
        {
            switch (job)
            {
                case AiJob.Ask: return "Ask AI";
                case AiJob.Plan: return "Growth plan";
                case AiJob.PosterWords: return "Poster words";
                case AiJob.PosterArtwork: return "Poster artwork";
                case AiJob.Photos: return "Product photos";
                case AiJob.Listing: return "Product listings";
                case AiJob.Creative: return "Creatives";
                case AiJob.Playbook: return "Playbooks";
                case AiJob.PriceCheck: return "Price check";
                case AiJob.WebsiteCategory: return "Website category";
                default: return "Learning from chats";
            }
        }

        /// <summary>Why the recommended thinking level suits the job, in a few words.</summary>
        public static string Why(AiJob job)
        {
            switch (job)
            {
                case AiJob.Ask: return "Quick, clear answers from the shop's figures.";
                case AiJob.Plan: return "A month's plan is worth thinking hard about.";
                case AiJob.PosterWords: return "A few products and short words.";
                case AiJob.PosterArtwork: return "The picture needs little thinking.";
                case AiJob.Photos: return "The pictures need little thinking.";
                case AiJob.Listing: return "Careful words from what the photos show.";
                case AiJob.Creative: return "A whole design from the brief, drawn by the image tool.";
                case AiJob.Playbook: return "Short steps from what the shop tried and what came of it.";
                case AiJob.PriceCheck: return "Finding and reading a few shop pages on the web.";
                case AiJob.WebsiteCategory: return "Picking one category from your website's list.";
                default: return "A small job in the background.";
            }
        }

        /// <summary>The least thinking that does the job well.</summary>
        public static string RecommendedEffort(AiJob job)
        {
            switch (job)
            {
                case AiJob.Plan: return "high";
                case AiJob.Ask:
                case AiJob.PosterWords:
                case AiJob.Listing:
                case AiJob.Creative:
                case AiJob.Playbook:
                case AiJob.PriceCheck: return "medium";
                default: return "low";
            }
        }

        /// <summary>"Low", "Medium", "High", "Extra high"…</summary>
        public static string EffortName(string effort)
        {
            var value = (effort ?? "").Trim().ToLowerInvariant();
            switch (value)
            {
                case "": return "Recommended";
                case "xhigh": return "Extra high";
                default: return char.ToUpperInvariant(value[0]) + value.Substring(1);
            }
        }

        /// <summary>The owner's choice for <paramref name="job"/>, or an empty one.</summary>
        public static AiJobChoice Choice(this AssistantSettings settings, AiJob job)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            return settings.Jobs != null && settings.Jobs.TryGetValue(job.ToString(), out var choice) && choice != null
                ? choice
                : new AiJobChoice();
        }

        /// <summary>
        /// The model and thinking level <paramref name="job"/> runs with on the AI tool the jobs run on (<see cref="Tool"/>):
        /// the owner's choice for the job, else what was set for that tool in its settings, else the job's
        /// recommendation. Claude Code and Antigravity keep their own model; a tool that chooses for itself gives none.
        /// </summary>
        public static (string Model, string Effort) Resolve(AssistantSettings settings, AiJob job) =>
            Resolve(settings, job, settings.Choice(job));

        /// <summary>The thinking level <paramref name="job"/> gets with no choice of its own: what was set for the tool,
        /// else the job's recommendation; empty for a tool that chooses for itself.</summary>
        public static string DefaultEffort(AssistantSettings settings, AiJob job) => Resolve(settings, job, new AiJobChoice()).Effort;

        private static (string Model, string Effort) Resolve(AssistantSettings settings, AiJob job, AiJobChoice choice)
        {
            switch (Tool(settings))
            {
                case ProviderIds.CodexCli:
                    return (First(choice.Model, settings.Codex?.Model), CodexEffort(settings, choice, job));
                case ProviderIds.ClaudeCli:
                    return (First(choice.Model, settings.ClaudeCli?.Model), ToolEffort(settings.ClaudeCli?.Effort, ClaudeEfforts, choice, job));
                case ProviderIds.AntigravityCli:
                    return (First(choice.Model, settings.Antigravity?.Model), ToolEffort(settings.Antigravity?.Effort, AntigravityEfforts, choice, job));
                default:
                    return ("", "");
            }
        }

        /// <summary>
        /// Sets <paramref name="settings"/>, a copy loaded for this one job, to run it: Codex gets the job's model and
        /// thinking level; the Claude and Antigravity command-line tools get the thinking level when they know it.
        /// </summary>
        public static void Apply(AssistantSettings settings, AiJob job)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            // Every tool, as "auto" may fall back from one to the next.
            var choice = settings.Choice(job);
            settings.Codex.Model = First(choice.Model, settings.Codex.Model);
            settings.Codex.ReasoningEffort = CodexEffort(settings, choice, job);
            settings.ClaudeCli.Model = First(choice.Model, settings.ClaudeCli.Model);
            settings.ClaudeCli.Effort = ToolEffort(settings.ClaudeCli.Effort, ClaudeEfforts, choice, job);
            settings.Antigravity.Model = First(choice.Model, settings.Antigravity.Model);
            settings.Antigravity.Effort = ToolEffort(settings.Antigravity.Effort, AntigravityEfforts, choice, job);
        }

        /// <summary>Saves the owner's choice for a job; an empty choice means the recommended one again.</summary>
        public static void SetChoice(this AssistantSettings settings, AiJob job, AiJobChoice choice)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Jobs = settings.Jobs ?? new Dictionary<string, AiJobChoice>();
            var clean = new AiJobChoice { Model = Token(choice?.Model), Effort = Token(choice?.Effort).ToLowerInvariant() };
            if (clean.IsRecommended)
            {
                settings.Jobs.Remove(job.ToString());
            }
            else
            {
                settings.Jobs[job.ToString()] = clean;
            }
        }

        // Codex's levels depend on the model: the choice is fitted to the model's own list when it is made.
        private static string CodexEffort(AssistantSettings settings, AiJobChoice choice, AiJob job) =>
            First(choice.Effort, settings.Codex?.ReasoningEffort, RecommendedEffort(job));

        /// <summary>The job's own choice at the nearest level the tool has, else what was set for the tool, else the
        /// job's recommendation at the nearest level.</summary>
        private static string ToolEffort(string own, string[] levels, AiJobChoice choice, AiJob job)
        {
            var chosen = Fit(choice.Effort, levels);
            if (chosen.Length > 0)
            {
                return chosen;
            }

            return string.IsNullOrWhiteSpace(own) ? Fit(RecommendedEffort(job), levels) : own.Trim();
        }

        private static string First(params string[] values) =>
            values.Select(v => (v ?? "").Trim()).FirstOrDefault(v => v.Length > 0) ?? "";

        /// <summary>
        /// A model's name as it may be saved for a job and put on a command line, e.g. "gpt-6.1-sol": letters, digits and . _ -
        /// only, 80 at most. Empty when <paramref name="value"/> is not one, so a name typed in by hand is checked the way a chosen one is.
        /// </summary>
        public static string ModelId(string value) => Token(value);

        /// <summary>A model id or thinking level: letters, digits and . _ - only, as they go on a command line.</summary>
        private static string Token(string value)
        {
            var text = (value ?? "").Trim();
            return text.Length <= 80 && text.All(c => char.IsLetterOrDigit(c) || c == '.' || c == '_' || c == '-') ? text : "";
        }
    }
}

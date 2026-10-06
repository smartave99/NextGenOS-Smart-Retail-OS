using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SmartRetail.AI.Providers;

namespace SmartRetail.AI.Settings
{
    /// <summary>Everything the assistant stores per Windows user. API keys and passwords live
    /// only in <see cref="ProtectedSecrets"/>, encrypted with the user's Windows account.</summary>
    public sealed class AssistantSettings
    {
        /// <summary><see cref="ProviderIds.Auto"/> or a provider id.</summary>
        public string PreferredProvider { get; set; } = ProviderIds.Auto;

        /// <summary>In Auto mode, try the next ready provider when one fails.</summary>
        public bool FallbackToOtherProviders { get; set; } = true;

        public List<string> ProviderOrder { get; set; } = new List<string>(ProviderIds.DefaultOrder);

        /// <summary>What the pictures the AI makes need to know about this business: its country, kind, models, festivals, second language. Read from the customer's
        /// profile (<c>profile/ai.json</c>) when the settings are loaded, never saved here, and neutral when there is no profile.</summary>
        [JsonIgnore]
        public ShopProfile Shop { get; set; } = new ShopProfile();

        public CodexCliSettings Codex { get; set; } = new CodexCliSettings();

        public ClaudeCliSettings ClaudeCli { get; set; } = new ClaudeCliSettings();

        public AntigravityCliSettings Antigravity { get; set; } = new AntigravityCliSettings();

        public CustomCliSettings CustomCli { get; set; } = new CustomCliSettings();

        public ApiProviderSettings OpenAi { get; set; } = new ApiProviderSettings
        {
            Model = "gpt-6-sol",
            BaseUrl = "https://api.openai.com/v1",
        };

        public ApiProviderSettings Anthropic { get; set; } = new ApiProviderSettings { Model = "claude-opus-5" };

        public ApiProviderSettings Gemini { get; set; } = new ApiProviderSettings
        {
            Model = "gemini-3.5-flash",
            BaseUrl = "https://generativelanguage.googleapis.com/v1beta",
        };

        /// <summary>Any server that speaks the OpenAI chat-completions format, e.g. a local Ollama.</summary>
        public ApiProviderSettings OpenAiCompatible { get; set; } = new ApiProviderSettings
        {
            BaseUrl = "http://localhost:11434/v1",
        };

        public DatabaseSettings Database { get; set; } = new DatabaseSettings();

        public PrivacySettings Privacy { get; set; } = new PrivacySettings();

        /// <summary>How the assistant appears: a side panel beside the POS, or a normal window.</summary>
        public PanelSettings Panel { get; set; } = new PanelSettings();

        public SmartRetail.AI.Dashboard.DashboardSettings Dashboard { get; set; } = new SmartRetail.AI.Dashboard.DashboardSettings();

        /// <summary>Sale posters: the biggest offer the AI may suggest.</summary>
        public PosterSettings Posters { get; set; } = new PosterSettings();

        /// <summary>Barcode stickers: the sticker paper and what each sticker shows.</summary>
        public StickerSettings Stickers { get; set; } = new StickerSettings();

        /// <summary>The assistant's memory: whether it learns from chats, and whether it asks before saving.</summary>
        public MemorySettings Memory { get; set; } = new MemorySettings();

        /// <summary>The owner's live view: the owner's Supabase project this PC sends the shop's figures to.</summary>
        public OwnerViewSettings OwnerView { get; set; } = new OwnerViewSettings();

        /// <summary>Camera search: whether products are found by their look too, not only their barcode.</summary>
        public CameraSearchSettings CameraSearch { get; set; } = new CameraSearchSettings();

        /// <summary>The owner's model and thinking level for each job (<see cref="AiJob"/> name → choice); a job left
        /// out uses its recommended ones (<see cref="AiJobs"/>).</summary>
        public Dictionary<string, AiJobChoice> Jobs { get; set; } = new Dictionary<string, AiJobChoice>();

        /// <summary>Secret name → encrypted value (base64). Never store plain text here.</summary>
        public Dictionary<string, string> ProtectedSecrets { get; set; } = new Dictionary<string, string>();

        /// <summary>Repairs lists after loading a file written by an older or hand-edited version.</summary>
        public void Normalize()
        {
            var order = new List<string>();
            foreach (var id in ProviderOrder ?? new List<string>())
            {
                if (ProviderIds.IsKnown(id) && !order.Contains(id))
                {
                    order.Add(id);
                }
            }

            foreach (var id in ProviderIds.DefaultOrder)
            {
                if (!order.Contains(id))
                {
                    order.Add(id);
                }
            }

            ProviderOrder = order;
            if (string.IsNullOrWhiteSpace(PreferredProvider) || (PreferredProvider != ProviderIds.Auto && !ProviderIds.IsKnown(PreferredProvider)))
            {
                PreferredProvider = ProviderIds.Auto;
            }

            Codex = Codex ?? new CodexCliSettings();
            ClaudeCli = ClaudeCli ?? new ClaudeCliSettings();
            Antigravity = Antigravity ?? new AntigravityCliSettings();
            CustomCli = CustomCli ?? new CustomCliSettings();
            OpenAi = OpenAi ?? new ApiProviderSettings();
            Anthropic = Anthropic ?? new ApiProviderSettings();
            Gemini = Gemini ?? new ApiProviderSettings();
            OpenAiCompatible = OpenAiCompatible ?? new ApiProviderSettings();
            Database = Database ?? new DatabaseSettings();
            Privacy = Privacy ?? new PrivacySettings();
            Privacy.ExtraAllowedTables = Privacy.ExtraAllowedTables ?? new List<string>();
            if (Privacy.MaxRowsSharedWithAi < 1)
            {
                Privacy.MaxRowsSharedWithAi = 50;
            }

            Panel = Panel ?? new PanelSettings();
            Panel.Normalize();
            Dashboard = Dashboard ?? new SmartRetail.AI.Dashboard.DashboardSettings();
            Dashboard.Normalize();
            Posters = Posters ?? new PosterSettings();
            Stickers = Stickers ?? new StickerSettings();
            Memory = Memory ?? new MemorySettings();
            OwnerView = OwnerView ?? new OwnerViewSettings();
            CameraSearch = CameraSearch ?? new CameraSearchSettings();
            CameraSearch.Model = (CameraSearch.Model ?? "").Trim();
            Jobs = (Jobs ?? new Dictionary<string, AiJobChoice>())
                .Where(pair => pair.Value != null && Enum.TryParse(pair.Key, out AiJob _) && !pair.Value.IsRecommended)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            ProtectedSecrets = ProtectedSecrets ?? new Dictionary<string, string>();
        }
    }

    public enum PanelEdge
    {
        Right,
        Left,
    }

    public sealed class PanelSettings
    {
        public const int MinimumWidth = 360;
        public const int MaximumWidth = 1200;

        /// <summary>Show the assistant as a slim panel on the screen edge, above the POS. Off = a normal window.</summary>
        public bool SidePanel { get; set; } = true;

        [JsonConverter(typeof(StringEnumConverter))]
        public PanelEdge Edge { get; set; } = PanelEdge.Right;

        /// <summary>Panel width in pixels. The panel never takes more than half the screen.</summary>
        public int Width { get; set; } = 440;

        /// <summary>Show a small "AI" tab on the screen edge while the panel is hidden.</summary>
        public bool ShowEdgeTab { get; set; } = true;

        /// <summary>Shows or hides the panel from any program, e.g. "Ctrl+Shift+Space". Empty = no shortcut.</summary>
        public string Shortcut { get; set; } = Hotkey.Default;

        /// <summary>Start the assistant, waiting as the "AI" tab, when this Windows user signs in.</summary>
        public bool StartWithWindows { get; set; }

        internal void Normalize()
        {
            if (!Enum.IsDefined(typeof(PanelEdge), Edge))
            {
                Edge = PanelEdge.Right;
            }

            Width = Math.Min(MaximumWidth, Math.Max(MinimumWidth, Width));
            Shortcut = (Shortcut ?? "").Trim();
            if (Shortcut.Length > 0)
            {
                Shortcut = Hotkey.TryParse(Shortcut, out var hotkey, out _) ? hotkey.ToString() : Hotkey.Default;
            }
        }
    }

    public class CliProviderSettings
    {
        /// <summary>Full path to the executable; empty means "find it on PATH".</summary>
        public string ExecutablePath { get; set; } = "";

        /// <summary>Model to request; empty means the tool's own default.</summary>
        public string Model { get; set; } = "";

        public int TimeoutSeconds { get; set; } = 180;
    }

    public sealed class CodexCliSettings : CliProviderSettings
    {
        /// <summary>Passed as <c>-c model_reasoning_effort=…</c>; empty keeps Codex's default.</summary>
        public string ReasoningEffort { get; set; } = "";

        /// <summary>"read-only" (default) or "workspace-write". Either way Codex works in an empty
        /// temporary folder; workspace-write is only a fallback for PCs where the read-only Windows
        /// sandbox fails to start.</summary>
        public string SandboxMode { get; set; } = "read-only";
    }

    public sealed class ClaudeCliSettings : CliProviderSettings
    {
        public ClaudeCliSettings()
        {
            Model = "claude-opus-5";
        }

        /// <summary>Passed as <c>--effort</c>; empty keeps the CLI default.</summary>
        public string Effort { get; set; } = "";
    }

    public sealed class AntigravityCliSettings : CliProviderSettings
    {
        /// <summary>Pass the saved Gemini API key as GEMINI_API_KEY instead of relying on a Google sign-in.</summary>
        public bool UseGeminiApiKey { get; set; }

        /// <summary>Passed as <c>--effort</c> (low, medium, high); empty keeps the CLI default.</summary>
        public string Effort { get; set; } = "";
    }

    public sealed class CustomCliSettings : CliProviderSettings
    {
        public string DisplayName { get; set; } = "Custom CLI";

        /// <summary>Space-separated arguments. Placeholders: {model}, {prompt_file}, {system_file}, {workdir}.</summary>
        public string Arguments { get; set; } = "";

        /// <summary>Send the prompt on standard input (otherwise pass it with {prompt_file}).</summary>
        public bool PromptViaStdin { get; set; } = true;

        /// <summary>When the tool prints JSON, the path of the answer inside it (e.g. "response"). Empty = plain text.</summary>
        public string JsonResultField { get; set; } = "";
    }

    public sealed class ApiProviderSettings
    {
        public string Model { get; set; } = "";

        public string BaseUrl { get; set; } = "";

        public int TimeoutSeconds { get; set; } = 180;
    }

    public sealed class DatabaseSettings
    {
        /// <summary>The POS installation folder, used to auto-detect the connection.</summary>
        public string PosFolder { get; set; } = "";

        public string Server { get; set; } = @".\SQLEXPRESS";

        public string Database { get; set; } = "";

        public bool UseWindowsAuthentication { get; set; } = true;

        public string UserName { get; set; } = "";

        public int CommandTimeoutSeconds { get; set; } = 30;
    }

    public sealed class PosterSettings
    {
        public const int DefaultMaxOfferPercent = 30;

        public static readonly IReadOnlyList<int> MaxOfferChoices = new[] { 10, 15, 20, 25, 30, 40, 50 };

        /// <summary>The most an offer on a poster may take off, in percent. Offers never go below cost whatever this is.</summary>
        public int MaxOfferPercent { get; set; } = DefaultMaxOfferPercent;

        /// <summary>The limit kept to the choices, for a settings file edited by hand.</summary>
        [JsonIgnore]
        public int CheckedMaxOfferPercent => MaxOfferChoices.Contains(MaxOfferPercent) ? MaxOfferPercent : DefaultMaxOfferPercent;
    }

    /// <summary>The dashboard's Barcodes page saves these as they are changed.</summary>
    public sealed class StickerSettings
    {
        /// <summary>A sticker paper id from the dashboard's list, e.g. "a4-65".</summary>
        public string Paper { get; set; } = "a4-65";

        public bool ShowPrice { get; set; } = true;

        public bool ShowMrp { get; set; } = true;

        public bool ShowShopName { get; set; } = true;
    }

    /// <summary>The dashboard's Memory page saves these as they are changed.</summary>
    public sealed class MemorySettings
    {
        /// <summary>After a chat, the AI suggests what is worth remembering for later.</summary>
        public bool LearnFromChats { get; set; } = true;

        /// <summary>The AI's suggestions wait for the owner's Save. Off: they are saved at once, and can be undone.</summary>
        public bool AskBeforeSaving { get; set; } = true;

        /// <summary>Keep ended chats for six months, to find and ask again (words only, no table rows).</summary>
        public bool KeepChats { get; set; } = true;
    }

    /// <summary>Where this PC sends the shop's figures for the owner's live view on the website.</summary>
    public sealed class OwnerViewSettings
    {
        /// <summary>The owner's Supabase project, e.g. https://abcd.supabase.co; empty when not connected.</summary>
        public string ProjectUrl { get; set; } = "";

        /// <summary>The project's public key (anon or publishable). Public by design: with it this PC can only connect
        /// with a one-time code and then send figures with its own key.</summary>
        public string PublicKey { get; set; } = "";

        /// <summary>The shop's name in the project, as the owner gave it on the website.</summary>
        public string ShopName { get; set; } = "";

        /// <summary>This PC's own key for sending figures, protected with Windows DPAPI; empty when not connected.</summary>
        public string ProtectedKey { get; set; } = "";

        public DateTime? ConnectedAt { get; set; }

        /// <summary>Offer the products whose photos and listing are finished to the owner's website: they wait in the owner's
        /// Supabase project, and nothing goes on the website until the owner approves each one there. Off until the owner turns it on.</summary>
        public bool SendProducts { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public bool IsConnected => !string.IsNullOrEmpty(ProjectUrl) && !string.IsNullOrEmpty(ProtectedKey);
    }

    public sealed class PrivacySettings
    {
        /// <summary>Hide phone numbers, e-mail, addresses and tax ids from the AI (they still show on screen).</summary>
        public bool MaskContactDetails { get; set; } = true;

        /// <summary>Let the AI write its own read-only queries. When off, only the built-in insights run.</summary>
        public bool AllowAiWrittenQueries { get; set; } = true;

        public int MaxRowsSharedWithAi { get; set; } = 50;

        /// <summary>Extra POS tables the AI may query, beyond the built-in business tables.</summary>
        public List<string> ExtraAllowedTables { get; set; } = new List<string>();
    }
}

using System;

namespace SmartRetail.AI.Providers
{
    public static class ProviderIds
    {
        /// <summary>Pseudo-provider: use the preferred provider, then the others in order.</summary>
        public const string Auto = "auto";

        public const string CodexCli = "codex-cli";
        public const string ClaudeCli = "claude-cli";
        public const string AntigravityCli = "antigravity-cli";
        public const string CustomCli = "custom-cli";
        public const string OpenAiApi = "openai-api";
        public const string AnthropicApi = "anthropic-api";
        public const string GeminiApi = "gemini-api";
        public const string OpenAiCompatibleApi = "openai-compatible-api";

        /// <summary>Codex first, as the product's primary integration; API-key providers after the CLIs.</summary>
        public static readonly string[] DefaultOrder =
        {
            CodexCli, ClaudeCli, AntigravityCli, OpenAiApi, AnthropicApi, GeminiApi, OpenAiCompatibleApi, CustomCli,
        };

        public static bool IsKnown(string id) => Array.IndexOf(DefaultOrder, id) >= 0;
    }
}

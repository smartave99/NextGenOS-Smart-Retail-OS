using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Providers
{
    public enum ProviderKind
    {
        /// <summary>A locally installed command-line tool (Codex, Claude, Antigravity, custom).</summary>
        Cli,

        /// <summary>A hosted HTTP API called directly with an API key.</summary>
        Api,
    }

    public sealed class AiRequest
    {
        public string SystemPrompt { get; set; } = "";
        public string UserPrompt { get; set; } = "";

        /// <summary>
        /// Gets the answer so far, again and again while it is written, from a provider that can stream it (Codex
        /// through its app server, a custom command-line tool through its output). Null to wait for the whole answer.
        /// Providers that cannot stream ignore it.
        /// </summary>
        public Action<string> OnText { get; set; }

        /// <summary>Photos sent with the question (files on this PC), for a provider that reads pictures.</summary>
        public List<string> Images { get; } = new List<string>();

        /// <summary>Voice recordings sent with the question (WAV files on this PC), for a provider that listens.</summary>
        public List<string> Audio { get; } = new List<string>();

        public bool HasAttachments => Images.Count > 0 || Audio.Count > 0;
    }

    /// <summary>A provider that can be given photos or voice recordings with a question.</summary>
    public interface IReadsAttachments
    {
        /// <summary>Null when it can read what <paramref name="request"/> carries; else why not, in a few words.</summary>
        string CannotRead(AiRequest request);
    }

    public sealed class AiResponse
    {
        public AiResponse(string providerId, string text, TimeSpan duration)
        {
            ProviderId = providerId;
            Text = text;
            Duration = duration;
        }

        public string ProviderId { get; }
        public string Text { get; }
        public TimeSpan Duration { get; }
    }

    public sealed class ProviderStatus
    {
        private ProviderStatus(bool isReady, string detail, string version)
        {
            IsReady = isReady;
            Detail = detail ?? "";
            Version = version ?? "";
        }

        public bool IsReady { get; }
        public string Detail { get; }
        public string Version { get; }

        public static ProviderStatus Ready(string detail, string version = null) => new ProviderStatus(true, detail, version);

        public static ProviderStatus NotReady(string detail, string version = null) => new ProviderStatus(false, detail, version);
    }

    public interface IAiProvider
    {
        string Id { get; }

        string DisplayName { get; }

        ProviderKind Kind { get; }

        /// <summary>Checks installation, sign-in and configuration without sending a prompt.</summary>
        Task<ProviderStatus> CheckAsync(CancellationToken cancellationToken);

        Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken);
    }

    public sealed class AiProviderException : Exception
    {
        public AiProviderException(string providerId, string message, bool canFallback = true, Exception innerException = null, UsageLimitInfo usageLimit = null)
            : base(message, innerException)
        {
            ProviderId = providerId;
            CanFallback = canFallback;
            UsageLimit = usageLimit;
        }

        public string ProviderId { get; }

        /// <summary>True when another provider could reasonably succeed where this one failed.</summary>
        public bool CanFallback { get; }

        /// <summary>Set when the tool refused because the account's usage limit is reached, with when it can answer again if it said;
        /// work that waits in the background waits for that time and carries on, instead of failing.</summary>
        public UsageLimitInfo UsageLimit { get; }
    }
}

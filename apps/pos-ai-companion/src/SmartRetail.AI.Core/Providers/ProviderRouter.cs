using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>Picks which provider answers: the one the user chose, or in Auto mode the preferred
    /// provider first and then the rest in the configured order, skipping any that are not ready.</summary>
    public sealed class ProviderRouter
    {
        private static readonly TimeSpan StatusCacheDuration = TimeSpan.FromMinutes(5);

        private readonly Func<AssistantSettings> _settings;
        private readonly ConcurrentDictionary<string, Tuple<ProviderStatus, DateTime>> _statusCache =
            new ConcurrentDictionary<string, Tuple<ProviderStatus, DateTime>>();

        public ProviderRouter(IEnumerable<IAiProvider> providers, Func<AssistantSettings> settings)
        {
            Providers = (providers ?? throw new ArgumentNullException(nameof(providers))).ToList();
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public IReadOnlyList<IAiProvider> Providers { get; }

        public IAiProvider Find(string id) => Providers.FirstOrDefault(p => p.Id == id);

        public async Task<ProviderStatus> GetStatusAsync(IAiProvider provider, bool refresh, CancellationToken cancellationToken)
        {
            if (!refresh && _statusCache.TryGetValue(provider.Id, out var cached) && DateTime.UtcNow - cached.Item2 < StatusCacheDuration)
            {
                return cached.Item1;
            }

            ProviderStatus status;
            try
            {
                status = await provider.CheckAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (AiProviderException ex)
            {
                status = ProviderStatus.NotReady(ex.Message);
            }

            _statusCache[provider.Id] = Tuple.Create(status, DateTime.UtcNow);
            return status;
        }

        /// <summary>Call after settings change so the next request re-checks every provider.</summary>
        public void InvalidateStatuses() => _statusCache.Clear();

        /// <summary>The providers to try, in order, for a selection ("auto" or a provider id).</summary>
        public IReadOnlyList<IAiProvider> PlanOrder(string selection)
        {
            if (!string.IsNullOrEmpty(selection) && selection != ProviderIds.Auto)
            {
                var chosen = Find(selection);
                return chosen == null ? new IAiProvider[0] : new[] { chosen };
            }

            var settings = _settings();
            var ids = new List<string>();
            if (settings.PreferredProvider != ProviderIds.Auto)
            {
                ids.Add(settings.PreferredProvider);
            }

            ids.AddRange(settings.ProviderOrder);
            return ids.Distinct().Select(Find).Where(p => p != null).ToList();
        }

        public async Task<AiResponse> CompleteAsync(AiRequest request, string selection, CancellationToken cancellationToken, IProgress<string> progress = null)
        {
            var explicitChoice = !string.IsNullOrEmpty(selection) && selection != ProviderIds.Auto;
            var candidates = PlanOrder(selection);
            if (candidates.Count == 0)
            {
                throw new AiProviderException(selection, "Unknown AI provider: " + selection, canFallback: false);
            }

            // Why tools could not be asked (not set up, cannot read the photos), and how those asked failed.
            var problems = new List<string>();
            var failures = new List<(IAiProvider Provider, AiProviderException Error)>();
            foreach (var provider in candidates)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var status = await GetStatusAsync(provider, refresh: false, cancellationToken).ConfigureAwait(false);
                if (!status.IsReady)
                {
                    if (explicitChoice)
                    {
                        throw new AiProviderException(provider.Id, provider.DisplayName + " is not ready: " + status.Detail, canFallback: false);
                    }

                    problems.Add(provider.DisplayName + ": " + status.Detail);
                    continue;
                }

                if (request.HasAttachments)
                {
                    var cannot = provider is IReadsAttachments reader
                        ? reader.CannotRead(request)
                        : "it cannot read photos or voice notes";
                    if (cannot != null)
                    {
                        if (explicitChoice)
                        {
                            throw new AiProviderException(provider.Id, provider.DisplayName + ": " + cannot + ".", canFallback: false);
                        }

                        problems.Add(provider.DisplayName + ": " + cannot + ".");
                        continue;
                    }
                }

                try
                {
                    progress?.Report("Asking " + provider.DisplayName + "…");
                    return await provider.CompleteAsync(request, cancellationToken).ConfigureAwait(false);
                }
                catch (AiProviderException ex) when (!cancellationToken.IsCancellationRequested)
                {
                    _statusCache.TryRemove(provider.Id, out _);
                    if (explicitChoice || !ex.CanFallback || !_settings().FallbackToOtherProviders)
                    {
                        throw;
                    }

                    failures.Add((provider, ex));
                    progress?.Report(provider.DisplayName + " failed; trying the next provider…");
                }
            }

            // What went wrong with the tools that were asked; the ones never set up only matter when none could be asked.
            if (failures.Count == 1)
            {
                throw new AiProviderException(failures[0].Provider.Id, failures[0].Error.Message, canFallback: false, innerException: failures[0].Error);
            }

            var lines = failures.Count > 0
                ? failures.Select(f => f.Error.Message.StartsWith(f.Provider.DisplayName, StringComparison.Ordinal) ? f.Error.Message : f.Provider.DisplayName + ": " + f.Error.Message)
                : problems;
            throw new AiProviderException(ProviderIds.Auto, (failures.Count > 0 ? "No AI tool could answer." : "No AI tool is ready to answer.") + Environment.NewLine
                + string.Join(Environment.NewLine, lines.Select(p => "• " + p)), canFallback: false);
        }
    }

    public static class ProviderCatalog
    {
        /// <summary>
        /// Creates every supported provider. All of them read the live settings on each call. With a <paramref name="gate"/>, every
        /// run of Codex goes in through it, so Codex is only replaced by a newer one when nothing is using it.
        /// </summary>
        public static IReadOnlyList<IAiProvider> CreateAll(
            Func<AssistantSettings> settings,
            SecretStore secrets,
            ICliRunner runner,
            HttpClient http,
            string workspaceRoot = null,
            AiRunGate gate = null)
        {
            return new IAiProvider[]
            {
                new CodexCliProvider(gate == null ? runner : new GatedCliRunner(runner, gate), settings, workspaceRoot) { Gate = gate },
                new ClaudeCliProvider(runner, settings, secrets, workspaceRoot),
                new AntigravityCliProvider(runner, settings, secrets, workspaceRoot),
                new OpenAiApiProvider(http, settings, secrets),
                new AnthropicApiProvider(settings, secrets),
                new GeminiApiProvider(http, settings, secrets),
                new OpenAiCompatibleApiProvider(http, settings, secrets),
                new CustomCliProvider(runner, settings, workspaceRoot),
            };
        }
    }
}

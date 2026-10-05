using System.Collections.Concurrent;
using SmartRetail.AI.Posters;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Posters;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Where a poster's artwork is: being made (with Codex's latest message), or stopped by a problem.</summary>
public sealed record ArtworkJob(bool Running, string Status, string? Problem);

/// <summary>
/// Makes posters' artwork with Codex in the background, so it goes on when staff leave the page. The poster can be
/// printed with the app's own design meanwhile; the artwork is added to it when ready. The data folder is never moved
/// while artwork is being made (<see cref="StorageService.ChangeAsync"/> asks <see cref="IsIdle"/>), and no artwork
/// starts while it moves.
/// </summary>
public sealed class PosterArtworkWorker
{
    private readonly ConcurrentDictionary<string, ArtworkJob> _jobs = new();
    private readonly ConcurrentDictionary<string, CancellationTokenSource> _running = new();
    private readonly AiEnvironment _ai;
    private readonly PosterStore _store;
    private readonly StorageService _storage;
    private readonly TimeProvider _clock;
    private readonly ILogger<PosterArtworkWorker> _log;

    public PosterArtworkWorker(AiEnvironment ai, PosterStore store, StorageService storage, TimeProvider clock, ILogger<PosterArtworkWorker> log)
    {
        _ai = ai;
        _store = store;
        _storage = storage;
        _clock = clock;
        _log = log;
    }

    /// <summary>Raised with the poster's id when its artwork job changes.</summary>
    public event Action<string>? Changed;

    /// <summary>True when no artwork is being made.</summary>
    public bool IsIdle => _jobs.Values.All(job => !job.Running);

    public ArtworkJob? Job(string id) => _jobs.TryGetValue(id, out var job) ? job : null;

    /// <summary>True while artwork (like every other work with Codex) waits for Codex's usage limit to lift.</summary>
    public bool IsWaitingForLimit => _ai.LimitPause.IsPaused;

    /// <summary>Stops waiting for the usage limit: the artwork is tried at once (e.g. the owner got more usage).</summary>
    public void TryNow() => _ai.LimitPause.Clear();

    public Task<ProviderStatus> CheckCodexAsync(CancellationToken ct) => _ai.CreateCodex().CheckAsync(ct);

    /// <summary>Starts making artwork for the poster; false when it is being made already, or the data folder is moving.</summary>
    public bool Start(Poster poster)
    {
        ArgumentNullException.ThrowIfNull(poster);
        lock (_jobs)
        {
            if (_jobs.TryGetValue(poster.Id, out var current) && current.Running)
            {
                return false;
            }

            // Counted as running before the move is checked, so a move that begins meanwhile sees this job.
            _jobs[poster.Id] = new ArtworkJob(true, "Starting Codex…", null);
            if (_storage.IsMoving)
            {
                _jobs[poster.Id] = new ArtworkJob(false, "", "The data folder is being moved. Make the artwork again when the move is done.");
                Changed?.Invoke(poster.Id);
                return false;
            }
        }

        var cancel = new CancellationTokenSource();
        _running[poster.Id] = cancel;
        Changed?.Invoke(poster.Id);
        _ = Task.Run(() => MakeAsync(poster.Id, poster.Kind.ArtworkTheme(poster.Festival), cancel));
        return true;
    }

    /// <summary>Stops the artwork being made for a poster, e.g. because the poster is being deleted.</summary>
    public void Cancel(string id)
    {
        if (_running.TryGetValue(id, out var cancel))
        {
            try
            {
                cancel.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // It finished just now.
            }
        }
    }

    private async Task MakeAsync(string id, string theme, CancellationTokenSource cancel)
    {
        try
        {
            // Reported at once, not posted later, so a late message never follows the finished artwork.
            var progress = new InlineProgress(message =>
            {
                if (!cancel.IsCancellationRequested)
                {
                    _jobs[id] = new ArtworkJob(true, message, null);
                    Changed?.Invoke(id);
                }
            });
            var result = await MakeWhenCodexCanAsync(id, theme, progress, cancel.Token);
            cancel.Token.ThrowIfCancellationRequested();

            // Nothing is written for a poster deleted meanwhile.
            if (_store.SaveArtwork(id, result.Image, _clock.GetLocalNow().DateTime) is { } name)
            {
                _store.Update(id, poster => poster with { Artwork = name, ArtworkBy = result.ProviderName });
            }

            _jobs.TryRemove(id, out _);
        }
        catch (OperationCanceledException)
        {
            _jobs.TryRemove(id, out _);
        }
        catch (Exception ex) when (ex is AiProviderException or IOException or UnauthorizedAccessException or InvalidOperationException)
        {
            _log.LogWarning(ex, "Poster artwork failed.");
            _jobs[id] = new ArtworkJob(false, "", ex.Message);
        }
        finally
        {
            _running.TryRemove(id, out _);
            cancel.Dispose();
        }

        Changed?.Invoke(id);
    }

    /// <summary>
    /// Makes the artwork. When Codex's usage limit is reached nothing has failed: the artwork waits for the time Codex gave and is made then,
    /// without the poster's page needing to be open.
    /// </summary>
    private async Task<PosterArtworkResult> MakeWhenCodexCanAsync(string id, string theme, IProgress<string> progress, CancellationToken ct)
    {
        while (true)
        {
            // Another job may have met the limit already: no try is made until it lifts.
            if (_ai.LimitPause.Until is { } waiting)
            {
                SayWaiting(id, waiting);
            }

            await _ai.LimitPause.WaitAsync(ct);
            try
            {
                return await _ai.CreateCodex(AiJob.PosterArtwork).MakePosterArtworkAsync(new PosterArtworkRequest { Theme = theme }, progress, ct);
            }
            catch (AiProviderException ex) when (ex.UsageLimit is { } limit && !ct.IsCancellationRequested)
            {
                SayWaiting(id, _ai.LimitPause.Hit(limit));
            }
        }
    }

    private void SayWaiting(string id, DateTimeOffset until)
    {
        _jobs[id] = new ArtworkJob(true, $"Codex's usage limit was reached. The artwork carries on by itself at {UsageLimitPause.Describe(until, DateTimeOffset.Now)}.", null);
        Changed?.Invoke(id);
    }

    private sealed class InlineProgress(Action<string> report) : IProgress<string>
    {
        public void Report(string value) => report(value);
    }
}

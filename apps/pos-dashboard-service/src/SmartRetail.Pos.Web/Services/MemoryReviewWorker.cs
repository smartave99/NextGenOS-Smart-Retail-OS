using SmartRetail.AI.Memory;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Runs the memory review in the background: at once when a chat ends, and every half minute for a chat that has
/// gone quiet. Nothing runs while the data folder is being moved.
/// </summary>
public sealed class MemoryReviewWorker : BackgroundService
{
    private static readonly TimeSpan Every = TimeSpan.FromSeconds(30);

    private readonly MemoryReviewer _reviewer;
    private readonly StorageService _storage;
    private readonly ILogger<MemoryReviewWorker> _log;
    private readonly SemaphoreSlim _due = new(0, 1);

    public MemoryReviewWorker(MemoryReviewer reviewer, StorageService storage, ILogger<MemoryReviewWorker> log)
    {
        _reviewer = reviewer;
        _storage = storage;
        _log = log;
        _reviewer.Due += (_, _) =>
        {
            try
            {
                _due.Release();
            }
            catch (SemaphoreFullException)
            {
                // A review is due already.
            }
        };
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await _due.WaitAsync(Every, stoppingToken);
                if (_storage.IsMoving)
                {
                    continue;
                }

                var outcomes = await _reviewer.ReviewDueAsync(stoppingToken);
                if (outcomes.Count > 0)
                {
                    _log.LogInformation("The memory review suggested {Count} changes; {Kept} kept.", outcomes.Count, outcomes.Count(o => o.Problem is null));
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
            catch (Exception ex)
            {
                // No AI tool ready, the AI failed, or the data folder began moving: the chat is not reviewed.
                _log.LogWarning(ex, "Reviewing a chat for the assistant's memory failed.");
            }
        }
    }

    public override void Dispose()
    {
        _due.Dispose();
        base.Dispose();
    }
}

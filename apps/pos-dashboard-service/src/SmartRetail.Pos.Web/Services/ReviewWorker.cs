namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Judges the Monday review's decisions whose review day came (<see cref="ReviewService.JudgeDueAsync"/>) when the app
/// starts and every hour, so while the app runs each is judged on its review day itself, as a product running out can
/// only be judged then.
/// </summary>
public sealed class ReviewWorker : BackgroundService
{
    private static readonly TimeSpan Every = TimeSpan.FromHours(1);

    private readonly ReviewService _reviews;
    private readonly ILogger<ReviewWorker> _log;

    public ReviewWorker(ReviewService reviews, ILogger<ReviewWorker> log)
    {
        _reviews = reviews;
        _log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Not while the app is starting.
        await Task.Yield();
        using var timer = new PeriodicTimer(Every);
        try
        {
            do
            {
                try
                {
                    await _reviews.JudgeDueAsync(stoppingToken);
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    _log.LogWarning(ex, "Judging the Monday review's decisions failed.");
                }
            }
            while (await timer.WaitForNextTickAsync(stoppingToken));
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The app is closing.
        }
    }
}

namespace SmartRetail.Pos.Web.Services;

/// <summary>Makes the creatives' pictures in the background, one at a time (<see cref="CreativeService.RunAsync"/>).</summary>
public sealed class CreativeWorker(CreativeService creatives, ILogger<CreativeWorker> log) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await creatives.RunAsync(stoppingToken);
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The app is closing.
        }
        catch (Exception ex)
        {
            log.LogError(ex, "Making creatives stopped.");
        }
    }
}

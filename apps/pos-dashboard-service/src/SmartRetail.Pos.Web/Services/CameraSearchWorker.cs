namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Keeps camera search going for as long as the dashboard runs: downloads and loads the model when finding by look is
/// turned on, and learns products' photos as they come.
/// </summary>
public sealed class CameraSearchWorker(CameraSearchService search, ILogger<CameraSearchWorker> log) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await search.RunAsync(stoppingToken);
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The dashboard is closing.
        }
        catch (Exception ex)
        {
            log.LogError(ex, "Camera search stopped.");
        }
    }
}

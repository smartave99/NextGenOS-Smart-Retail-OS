namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Makes product photos in the background for as long as the dashboard runs, starting with any the dashboard left
/// unfinished when it last closed.
/// </summary>
public sealed class PhotoMakerWorker : BackgroundService
{
    private readonly ProductPhotoService _photos;
    private readonly ILogger<PhotoMakerWorker> _log;

    public PhotoMakerWorker(ProductPhotoService photos, ILogger<PhotoMakerWorker> log)
    {
        _photos = photos;
        _log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _photos.Maker.ResumeAll();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogWarning(ex, "Could not look for unfinished product photos.");
        }

        try
        {
            await _photos.Maker.RunAsync(stoppingToken);
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The dashboard is closing; unfinished photos are made after the next start.
        }
    }
}

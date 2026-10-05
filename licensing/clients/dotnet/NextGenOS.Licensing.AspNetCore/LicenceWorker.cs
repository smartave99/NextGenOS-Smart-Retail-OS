using NextGenOS.Licensing;

namespace NextGenOS.Licensing.AspNetCore;

/// <summary>
/// Checks in with the licence server now and then (the library decides when it is due, and never waits long), and looks at
/// the licence again, so a licence withdrawn or ended stops the program in a running shop too.
/// </summary>
public sealed class LicenceWorker(LicenceManager manager, ProductLicence licence, ILogger<LicenceWorker> log) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(5));
        do
        {
            try
            {
                await manager.CheckInAsync(ct: stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
            catch (Exception ex)
            {
                // No Internet is normal: the licence has a grace period. Nothing else to do.
                log.LogDebug(ex, "The licence check-in did not complete.");
            }

            licence.Reload();
        }
        while (await timer.WaitForNextTickAsync(stoppingToken));
    }
}

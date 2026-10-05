namespace NextGenOS.Licensing.AspNetCore;

/// <summary>
/// Runs a background worker only while the licence is usable: it starts when the licence is there, and stops when it is
/// lost, so a PC without a licence does no work in the background (no AI jobs, no cloud sync, no updates) even though the
/// program is running.
/// </summary>
/// <param name="services">Builds the worker, so it gets what it asks for.</param>
/// <param name="licence">The licence to follow.</param>
/// <param name="log">Where a worker that did not stop cleanly is noted.</param>
/// <param name="look">How often the licence is looked at (five seconds; shorter only in tests).</param>
public sealed class LicensedWorker<TWorker>(IServiceProvider services, ProductLicence licence, ILogger<LicensedWorker<TWorker>> log, TimeSpan? look = null) : BackgroundService
    where TWorker : BackgroundService
{
    private readonly TimeSpan Look = look ?? TimeSpan.FromSeconds(5);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                while (!licence.IsUsable)
                {
                    await Task.Delay(Look, stoppingToken);
                }

                var inner = ActivatorUtilities.CreateInstance<TWorker>(services);
                try
                {
                    await inner.StartAsync(stoppingToken);
                    while (licence.IsUsable && !stoppingToken.IsCancellationRequested && inner.ExecuteTask is not { IsCompleted: true })
                    {
                        await Task.Delay(Look, stoppingToken);
                    }

                    // The worker ended by itself: it is done until the next start. Wait here until the program closes
                    // (or the licence comes back after a loss, then it runs again).
                    if (inner.ExecuteTask is { IsCompleted: true } && licence.IsUsable)
                    {
                        await Task.Delay(Timeout.Infinite, stoppingToken);
                    }
                }
                finally
                {
                    using var grace = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                    try
                    {
                        await inner.StopAsync(grace.Token);
                    }
                    catch (Exception ex)
                    {
                        log.LogDebug(ex, "{Worker} did not stop cleanly.", typeof(TWorker).Name);
                    }

                    inner.Dispose();
                }
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The program is closing.
        }
    }
}

public static class LicensedWorkerExtensions
{
    /// <summary>Registers a background worker that runs only with a usable licence.</summary>
    public static IServiceCollection AddLicensedWorker<TWorker>(this IServiceCollection services) where TWorker : BackgroundService
        => services.AddHostedService<LicensedWorker<TWorker>>();
}

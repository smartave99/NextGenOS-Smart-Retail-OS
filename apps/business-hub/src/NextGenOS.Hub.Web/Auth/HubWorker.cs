using NextGenOS.Hub.Web;

namespace NextGenOS.Hub.Web.Auth;

/// <summary>Looks after the shop in the background (<see cref="HubApp.Upkeep"/>): clears sales left open overnight, lets library holds run out, and forgets business-event records that are past their day. Runs only while the licence is valid, and only once the shop is set up.</summary>
public sealed class HubWorker(HubApp app, ILogger<HubWorker> log) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(10));
        do
        {
            try
            {
                app.Upkeep();   // does nothing until set-up has finished (a sample company is still being made until then)
            }
            catch (Exception ex)
            {
                log.LogWarning(ex, "The Hub's background upkeep could not finish.");
            }
        }
        while (await timer.WaitForNextTickAsync(stoppingToken));
    }
}

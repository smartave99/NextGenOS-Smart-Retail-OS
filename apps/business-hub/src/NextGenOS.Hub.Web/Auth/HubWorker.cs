using NextGenOS.Hub.Web;

namespace NextGenOS.Hub.Web.Auth;

/// <summary>Looks after the shop in the background (<see cref="HubApp.Upkeep"/>): clears sales left open overnight, lets library holds run out, and forgets business-event records that are past their day. Runs only while the licence is valid, and only once the shop is set up.</summary>
/// <remarks>
/// It asks for the shop inside its own try, not in its constructor: if the shop cannot be opened (an update that could not make its safe copy), the worker notes it and
/// tries again in ten minutes. A worker that threw while being made would stop the whole program, and the owner would never see the page that says what is wrong.
/// </remarks>
public sealed class HubWorker(IServiceProvider services, ILogger<HubWorker> log) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(10));
        do
        {
            try
            {
                var app = services.GetRequiredService<HubApp>();
                app.Upkeep();   // does nothing until set-up has finished (a sample company is still being made until then)
                await app.UpkeepOnlineAsync(stoppingToken);   // looks for a newer version about once a day (when this copy was built to, and the owner has not switched it off)
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
            catch (Exception ex)
            {
                log.LogWarning(ex, "The Hub's background upkeep could not finish.");
            }
        }
        while (await timer.WaitForNextTickAsync(stoppingToken));
    }
}

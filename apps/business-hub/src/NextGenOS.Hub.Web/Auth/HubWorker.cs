using NextGenOS.Hub.Web;

namespace NextGenOS.Hub.Web.Auth;

/// <summary>Looks after the shop in the background: clears sales left open overnight and lets library holds run out. Runs only while the licence is valid.</summary>
public sealed class HubWorker(HubApp app, ILogger<HubWorker> log) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(10));
        do
        {
            try
            {
                if (string.IsNullOrEmpty(app.Shop.Settings.Country)) continue;   // nothing to look after until set-up has chosen the shop's country
                app.Documents.DiscardStaleDrafts();
                if (app.Shop.Current.Features.Lending) app.Library.ProcessHolds();
            }
            catch (Exception ex)
            {
                log.LogWarning(ex, "The Hub's background upkeep could not finish.");
            }
        }
        while (await timer.WaitForNextTickAsync(stoppingToken));
    }
}

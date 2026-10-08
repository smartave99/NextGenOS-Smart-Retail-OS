using NextGenOS.Hub;
using NextGenOS.Hub.Demo;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Tests;

/// <summary>The shop's background tidying must never touch a shop that is still being set up (the sample company's open sales are dated days back, so they look forgotten).</summary>
public class UpkeepTests
{
    private static readonly DateTimeOffset Now = new(2026, 10, 5, 9, 30, 0, TimeSpan.Zero);

    private static string TempDb() => Path.Combine(Path.GetTempPath(), "hub-upkeep-" + Guid.NewGuid().ToString("N") + ".db");

    private static void Cleanup(string path)
    {
        foreach (var file in new[] { path, path + "-wal", path + "-shm" })
        {
            try { File.Delete(file); } catch (IOException) { }
        }
    }

    [Fact]
    public void Upkeep_leaves_a_shop_alone_until_its_set_up_has_finished_and_then_clears_old_open_sales()
    {
        var path = TempDb();
        try
        {
            var then = HubApp.OpenTrusted(path, new FixedClock(Now.AddDays(-3)));
            then.Shop.Save(new ShopSettings { Name = "Not yet", Country = "PH", Industry = "retail", SetupDone = false });
            var forgotten = then.Documents.CreateDraft(new DraftOptions());

            var app = HubApp.OpenTrusted(path, new FixedClock(Now));
            app.Upkeep();
            Assert.NotNull(app.Documents.Get(forgotten.Document.Id));   // set-up is not finished: nothing is tidied

            var settings = app.SettingsStore.Load();
            settings.SetupDone = true;
            app.Shop.Save(settings);
            app.Upkeep();
            Assert.Null(app.Documents.Get(forgotten.Document.Id));      // a finished shop: a sale left open for days is cleared
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public void Upkeep_does_nothing_before_the_shop_has_a_country()
    {
        var path = TempDb();
        try
        {
            var app = HubApp.OpenTrusted(path, new FixedClock(Now));
            app.Upkeep();   // nothing chosen yet: it must not throw "not set up"
            Assert.False(app.Shop.Settings.SetupDone);
        }
        finally { Cleanup(path); }
    }

    [Fact]
    public async Task The_upkeep_running_all_the_time_never_takes_a_sample_sale_that_is_still_being_made()
    {
        // As in the program: the set-up page saves the shop first (country chosen, set-up not finished), the sample company is then made through a second copy of the services
        // on the same database, and the background worker's upkeep may run at any moment of it.
        var path = TempDb();
        try
        {
            var web = HubApp.OpenTrusted(path, new FixedClock(Now));
            web.Shop.Save(new ShopSettings { Name = "Luzon Fresh Mart", Country = "PH", Industry = "retail", SetupDone = false });
            using var stop = new CancellationTokenSource();
            var upkeepErrors = new List<Exception>();
            var hammer = Task.Run(() =>
            {
                while (!stop.IsCancellationRequested)
                {
                    try { web.Upkeep(); } catch (Exception ex) { upkeepErrors.Add(ex); }
                }
            });
            try
            {
                var summary = DemoCompany.Fill(path, new DemoOptions { Industry = "retail", Country = "PH", Name = "Luzon Fresh Mart" }, Now);
                Assert.True(summary.Documents > 20, "the sample company has its trading history");
            }
            finally
            {
                stop.Cancel();
                await hammer;
            }
            Assert.Empty(upkeepErrors);
            Assert.True(web.Shop.Settings.SetupDone, "once the sample is made the shop is marked as set up");
            var sold = Convert.ToInt64(web.Db.Scalar("SELECT COUNT(*) FROM documents WHERE status = 'issued'"));
            Assert.True(sold > 20, "none of the sample's sales was taken away");
        }
        finally { Cleanup(path); }
    }
}

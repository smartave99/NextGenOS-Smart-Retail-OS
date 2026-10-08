using NextGenOS.Hub;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Tests;

/// <summary>A shop in a temporary database, in any country and industry, on a clock that stands still.</summary>
public sealed class HubFixture : IDisposable
{
    private readonly string _path = Path.Combine(Path.GetTempPath(), "hub-test-" + Guid.NewGuid().ToString("N") + ".db");

    public HubFixture(string country = "IN", string industry = "retail", Action<ShopSettings>? configure = null, DateTimeOffset? now = null, NextGenOS.Devices.Transport.IPrinterTransport? printer = null, NextGenOS.Hub.Ai.AiOptions? ai = null, NextGenOS.Hub.Updates.UpdateOptions? updates = null)
    {
        Clock = new FixedClock(now ?? new DateTimeOffset(2026, 10, 5, 6, 30, 0, TimeSpan.Zero)); // 12:00 in India
        App = HubApp.OpenTrusted(_path, Clock, printer is null ? null : new NextGenOS.Devices.Printing.PrintService(_ => printer), ai, updates: updates);
        var settings = new ShopSettings { Name = "Test Shop", Country = country, Industry = industry, SetupDone = true };
        if (country == "IN") settings.Region = "27";
        configure?.Invoke(settings);
        App.Shop.Save(settings);
    }

    public FixedClock Clock { get; }
    public HubApp App { get; }

    public void Dispose()
    {
        foreach (var file in new[] { _path, _path + "-wal", _path + "-shm" })
        {
            try { File.Delete(file); } catch (IOException) { }
        }
    }
}

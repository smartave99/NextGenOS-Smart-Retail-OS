using System.Net;
using NextGenOS.Hub.Counters;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>The owner's choice (saved at once, applied at the next start, switched off at once), the status the screen shows, and the database step with its way back.</summary>
public class StoreNetworkFacadeTests
{
    private static readonly DateTimeOffset Now = new(2026, 10, 7, 9, 0, 0, TimeSpan.Zero);
    private static readonly HostIdentity Shop = new("MAIN-PC", new[] { IPAddress.Parse("192.168.1.20") });

    private sealed class Run : IDisposable
    {
        private readonly TempFolder _folder = new();
        public int Limit;

        public Run(bool enabledAtStart = false, int limit = 0)
        {
            Limit = limit;
            Port = TempFolder.FreePort();
            if (enabledAtStart) NetworkSettingsFile.Write(_folder.Path, new NetworkSettings(true, Port));
            Runtime = NetworkStartup.Prepare(_folder.Path, new[] { 5280 }, Now, () => Shop);
            Clock = new FixedClock(Now);
            App = HubApp.OpenTrusted(Path.Combine(_folder.Path, "shop.db"), Clock, network: new NetworkOptions(Runtime, () => Limit));
            OwnerId = App.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        }

        public int Port { get; }
        public string Folder => _folder.Path;
        public NetworkRuntime Runtime { get; }
        public FixedClock Clock { get; }
        public HubApp App { get; }
        public long OwnerId { get; }

        public void Dispose() => _folder.Dispose();
    }

    [Fact]
    public void A_Hub_started_with_nothing_about_the_network_has_counter_PCs_off_and_cannot_make_a_code()
    {
        using var r = new Run();
        var status = r.App.Network.Status();
        Assert.False(status.Chosen);
        Assert.False(status.Running);
        Assert.False(status.Accepting);
        Assert.False(status.RestartNeeded);
        Assert.Null(status.Problem);
        Assert.Empty(status.Urls);
        Assert.Equal("network-off", Assert.Throws<HubException>(() => r.App.Network.Pairing.NewCode(r.OwnerId)).Code);
        // A program that gives the Hub no network options at all behaves the same.
        using var plain = new HubFixture();
        Assert.False(plain.App.Network.Runtime.Accepting);
        Assert.Equal("network-off", Assert.Throws<HubException>(() => plain.App.Network.Pairing.NewCode(null)).Code);
    }

    [Fact]
    public void Switching_on_is_saved_at_once_and_says_a_restart_is_needed_until_the_Hub_has_started_again()
    {
        using var r = new Run();
        r.App.Network.Configure(r.OwnerId, true, r.Port);

        var status = r.App.Network.Status();
        Assert.True(status.Chosen);
        Assert.Equal(r.Port, status.ChosenPort);
        Assert.False(status.Running);
        Assert.False(status.Accepting);       // not listening yet: a counter PC still cannot connect
        Assert.True(status.RestartNeeded);
        Assert.Equal("network-off", Assert.Throws<HubException>(() => r.App.Network.Pairing.NewCode(r.OwnerId)).Code);
        Assert.Contains("network.enable", r.App.Audit.Recent(10).Select(a => a.Action));
        Assert.Equal(r.Port, NetworkSettingsFile.Read(r.Folder).Port);

        // The Hub starts again: this time it listens, counter PCs are served, and no restart is needed.
        var restarted = NetworkStartup.Prepare(r.Folder, new[] { 5280 }, Now, () => Shop);
        var again = HubApp.OpenTrusted(Path.Combine(r.Folder, "shop.db"), r.Clock, network: new NetworkOptions(restarted));
        var after = again.Network.Status();
        Assert.True(after.Running);
        Assert.True(after.Accepting);
        Assert.False(after.RestartNeeded);
        Assert.Contains("https://MAIN-PC:" + r.Port, after.Urls);
        Assert.Contains("https://192.168.1.20:" + r.Port, after.Urls);
        Assert.DoesNotContain(after.Urls, u => u.Contains("localhost") || u.Contains("127.0.0.1"));
        Assert.Equal(64, after.AuthorityFingerprint!.Length);
        Assert.NotNull(after.CertificateEnds);
        Assert.NotEmpty(again.Network.Pairing.NewCode(r.OwnerId).Code);
    }

    [Fact]
    public void Switching_off_takes_effect_at_once_even_though_the_listener_stays_open_until_the_next_start()
    {
        using var r = new Run(enabledAtStart: true);
        Assert.True(r.App.Network.Status().Accepting);
        var paired = r.App.Network.Pairing.Redeem(r.App.Network.Pairing.NewCode(r.OwnerId).Code, "Counter 2", "192.168.1.31");
        bool? told = null;
        r.App.Network.ChoiceChanged += on => told = on;

        r.App.Network.Configure(r.OwnerId, false, r.Port);

        var status = r.App.Network.Status();
        Assert.True(status.Running);          // the listener is still open ...
        Assert.False(status.Accepting);       // ... but refuses every counter PC
        Assert.False(status.Chosen);
        Assert.False(status.RestartNeeded);
        Assert.Equal(false, told);
        Assert.Contains("network.disable", r.App.Audit.Recent(10).Select(a => a.Action));
        Assert.Equal("network-off", Assert.Throws<HubException>(() => r.App.Network.Pairing.NewCode(r.OwnerId)).Code);
        Assert.False(NetworkSettingsFile.Read(r.Folder).Enabled);

        // Switched on again without a restart: it works again straight away (the listener never closed).
        r.App.Network.Configure(r.OwnerId, true, r.Port);
        Assert.True(r.App.Network.Status().Accepting);
        Assert.NotNull(r.App.Network.Pairing.Recognise(paired.Token, "192.168.1.31"));   // the counter PC stayed paired
    }

    [Fact]
    public void A_change_of_port_needs_a_restart_and_a_port_that_is_not_allowed_is_refused_with_nothing_changed()
    {
        using var r = new Run(enabledAtStart: true);
        var other = TempFolder.FreePort();
        r.App.Network.Configure(r.OwnerId, true, other);
        Assert.True(r.App.Network.Status().RestartNeeded);
        Assert.Equal(r.Port, r.App.Network.Status().RunningPort);
        Assert.True(r.App.Network.Status().Accepting);   // the old port still serves

        foreach (var bad in new[] { 80, 1023, 65536, 0, -1, 5280 })
            Assert.Equal("bad-port", Assert.Throws<HubException>(() => r.App.Network.Configure(r.OwnerId, true, bad)).Code);
        Assert.Equal(other, NetworkSettingsFile.Read(r.Folder).Port);   // the refused ones changed nothing
    }

    [Fact]
    public void If_the_choice_cannot_be_written_the_owner_is_told_and_nothing_changes()
    {
        using var r = new Run();
        Directory.CreateDirectory(NetworkSettingsFile.PathIn(r.Folder));   // a folder where the file should be
        var refused = Assert.Throws<HubException>(() => r.App.Network.Configure(r.OwnerId, true, r.Port));
        Assert.Equal("not-saved", refused.Code);
        Assert.Contains("Nothing was changed", refused.Message);
        Assert.False(r.Runtime.Chosen);
        Assert.DoesNotContain("network.enable", r.App.Audit.Recent(10).Select(a => a.Action));
    }

    [Fact]
    public void A_start_that_could_not_listen_shows_its_reason_to_the_owner_and_nothing_is_served()
    {
        using var t = new TempFolder();
        using var holder = new System.Net.Sockets.TcpListener(IPAddress.Any, 0);
        holder.Start();
        var port = ((IPEndPoint)holder.LocalEndpoint).Port;
        NetworkSettingsFile.Write(t.Path, new NetworkSettings(true, port));
        var runtime = NetworkStartup.Prepare(t.Path, new[] { 5280 }, Now, () => Shop);
        var app = HubApp.OpenTrusted(Path.Combine(t.Path, "shop.db"), new FixedClock(Now), network: new NetworkOptions(runtime));
        var status = app.Network.Status();
        Assert.True(status.Chosen);
        Assert.False(status.Running);
        Assert.False(status.Accepting);
        Assert.True(status.RestartNeeded);
        Assert.Contains("already used by another program", status.Problem);
        Assert.Equal("network-off", Assert.Throws<HubException>(() => app.Network.Pairing.NewCode(null)).Code);
    }

    [Fact]
    public void The_licences_number_of_PCs_comes_from_a_function_and_is_asked_every_time()
    {
        using var r = new Run(enabledAtStart: true, limit: 0);
        Assert.Null(r.App.Network.Pairing.Use().Limit);
        r.Limit = 2;
        Assert.Equal(2, r.App.Network.Pairing.Use().Limit);
        Assert.Equal(1, r.App.Network.Pairing.Use().InUse);
        r.Limit = -3;
        Assert.Null(r.App.Network.Pairing.Use().Limit);
    }

    // ---- the database step ------------------------------------------------------------------------------------------------------

    private static readonly string[] NetworkTables = ["network_devices", "network_pairing_codes"];

    private static string[] Tables(HubApp app) => app.Db.Query("SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name", r => r.GetString(0)).ToArray();

    [Fact]
    public void The_step_that_adds_the_two_tables_can_be_undone_alone_and_run_forward_again()
    {
        using var f = new HubFixture();
        var owner = f.App.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 42500, TaxClass = "standard" });
        Assert.Subset(Tables(f.App).ToHashSet(), NetworkTables.ToHashSet());
        var latest = Convert.ToInt32(f.App.Db.Scalar("SELECT MAX(version) FROM schema_version"));
        Assert.True(latest >= 5);

        f.App.Db.Rollback(13);

        Assert.Empty(Tables(f.App).Intersect(NetworkTables));
        Assert.Equal(Enumerable.Range(1, 13).Select(v => (long)v).ToArray(), f.App.Db.Query("SELECT version FROM schema_version ORDER BY version", r => r.GetInt64(0)).ToArray());
        Assert.Contains("events", Tables(f.App));          // the earlier steps stay
        Assert.Contains("ontology_entities", Tables(f.App));
        Assert.Equal("Rice", f.App.Db.Scalar("SELECT name FROM items"));
        Assert.Equal(owner, Convert.ToInt64(f.App.Db.Scalar("SELECT id FROM users WHERE username = 'owner'")));
        Assert.True(File.Exists(f.App.Db.LastBackup));

        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Clock);
        Assert.Subset(Tables(again).ToHashSet(), NetworkTables.ToHashSet());
        Assert.Equal(0L, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM network_devices")));
    }
}

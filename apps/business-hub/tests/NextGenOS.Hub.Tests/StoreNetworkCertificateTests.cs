using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using NextGenOS.Hub.Counters;

namespace NextGenOS.Hub.Tests;

/// <summary>A folder of its own for one test, removed afterwards.</summary>
internal sealed class TempFolder : IDisposable
{
    public string Path { get; } = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "hub-net-" + Guid.NewGuid().ToString("N"));

    public TempFolder() => Directory.CreateDirectory(Path);

    public void Dispose()
    {
        try { Directory.Delete(Path, true); } catch (IOException) { } catch (UnauthorizedAccessException) { }
    }

    public static int FreePort()
    {
        var l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        var port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }
}

/// <summary>The choice about counter PCs (network.json), the shop's own certificates, and what the Hub does about them when it starts.</summary>
public class StoreNetworkCertificateTests
{
    private static readonly DateTimeOffset Now = new(2026, 10, 7, 9, 0, 0, TimeSpan.Zero);
    private static readonly HostIdentity Shop = new("MAIN-PC", new[] { IPAddress.Parse("192.168.1.20") });

    // ---- network.json -----------------------------------------------------------------------------------------------------------

    [Fact]
    public void With_no_file_counter_PCs_are_off_and_a_choice_is_written_and_read_back()
    {
        using var t = new TempFolder();
        Assert.Equal(NetworkSettings.Off, NetworkSettingsFile.Read(t.Path));
        Assert.False(NetworkSettingsFile.Read(t.Path).Enabled);
        Assert.Equal(5281, NetworkSettings.DefaultPort);

        NetworkSettingsFile.Write(t.Path, new NetworkSettings(true, 5290));
        var read = NetworkSettingsFile.Read(t.Path);
        Assert.True(read.Enabled);
        Assert.Equal(5290, read.Port);
        Assert.Null(read.Problem);
    }

    [Fact]
    public void The_choice_is_kept_in_a_file_only_the_Hubs_own_account_can_read()
    {
        using var t = new TempFolder();
        NetworkSettingsFile.Write(t.Path, new NetworkSettings(true, 5281));
        if (!OperatingSystem.IsWindows())
            Assert.Equal(UnixFileMode.UserRead | UnixFileMode.UserWrite, File.GetUnixFileMode(NetworkSettingsFile.PathIn(t.Path)));
        Assert.False(File.Exists(NetworkSettingsFile.PathIn(t.Path) + ".new"));   // written whole, then moved into place
    }

    [Theory]
    [InlineData("not json at all")]
    [InlineData("[]")]
    [InlineData("{\"enabled\": \"yes\"}")]
    [InlineData("{\"enabled\": 1}")]
    [InlineData("{\"enabled\": true, \"port\": 80}")]
    [InlineData("{\"enabled\": true, \"port\": 70000}")]
    [InlineData("{\"enabled\": true, \"port\": \"5281\"}")]
    [InlineData("{\"enabled\": true, \"port\": 5281.5}")]
    public void A_choice_that_cannot_be_read_or_is_not_allowed_means_off_with_a_plain_reason(string content)
    {
        using var t = new TempFolder();
        File.WriteAllText(NetworkSettingsFile.PathIn(t.Path), content);
        var read = NetworkSettingsFile.Read(t.Path);
        Assert.False(read.Enabled);
        Assert.False(string.IsNullOrWhiteSpace(read.Problem));
        Assert.Contains("switched off", read.Problem!);
    }

    [Fact]
    public void A_file_that_is_too_large_is_not_read()
    {
        using var t = new TempFolder();
        File.WriteAllText(NetworkSettingsFile.PathIn(t.Path), "{\"enabled\": true, \"x\": \"" + new string('a', 10_000) + "\"}");
        Assert.False(NetworkSettingsFile.Read(t.Path).Enabled);
    }

    [Fact]
    public void Ports_below_1024_above_65535_and_the_ports_the_Hub_already_uses_are_refused()
    {
        Assert.Null(NetworkSettingsFile.CheckPort(5281, new[] { 5280 }));
        Assert.NotNull(NetworkSettingsFile.CheckPort(1023, null));
        Assert.NotNull(NetworkSettingsFile.CheckPort(65536, null));
        Assert.NotNull(NetworkSettingsFile.CheckPort(0, null));
        Assert.NotNull(NetworkSettingsFile.CheckPort(-5, null));
        Assert.Contains("already used", NetworkSettingsFile.CheckPort(5280, new[] { 5280 })!);
    }

    // ---- the shop's own certificates --------------------------------------------------------------------------------------------

    [Fact]
    public void The_certificates_are_made_for_this_PC_signed_by_a_shop_authority_and_trusted_by_a_PC_that_trusts_only_that_authority()
    {
        using var t = new TempFolder();
        using var set = StoreCertificates.Ensure(t.Path, Shop, Now);

        Assert.True(set.AuthorityMade);
        Assert.True(set.ServerMade);
        Assert.True(set.Server.HasPrivateKey);
        // A counter PC that trusts the authority (and nothing else) accepts the PC's certificate, today and two years from now.
        Assert.True(StoreCertificates.ChainsTo(set.Server, set.CaPem, Now));
        Assert.True(StoreCertificates.ChainsTo(set.Server, set.CaPem, Now.AddDays(700)));
        // ... and it names this PC: its name (also with .local), its address and this PC itself.
        var san = set.Server.Extensions.OfType<X509SubjectAlternativeNameExtension>().Single();
        var dns = san.EnumerateDnsNames().ToList();
        var ips = san.EnumerateIPAddresses().Select(a => a.ToString()).ToList();
        Assert.Contains("MAIN-PC", dns);
        Assert.Contains("MAIN-PC.local", dns);
        Assert.Contains("localhost", dns);
        Assert.Contains("192.168.1.20", ips);
        Assert.Contains("127.0.0.1", ips);
        // Server authentication only; not an authority itself.
        Assert.False(set.Server.Extensions.OfType<X509BasicConstraintsExtension>().Single().CertificateAuthority);
        Assert.Contains(set.Server.Extensions.OfType<X509EnhancedKeyUsageExtension>().Single().EnhancedKeyUsages.Cast<Oid>(), o => o.Value == "1.3.6.1.5.5.7.3.1");
        // The certificate is valid for a little over two years (some systems refuse longer ones for an authority a person added).
        Assert.True(set.Server.NotAfter.ToUniversalTime() - Now.UtcDateTime <= TimeSpan.FromDays(825));
        // No company's name in what a person sees when they install it.
        using var authority = X509Certificate2.CreateFromPem(set.CaPem);
        Assert.StartsWith("CN=Shop network authority", authority.Subject);
        Assert.DoesNotContain("NextGenOS", authority.Subject + set.Server.Subject, StringComparison.OrdinalIgnoreCase);
        Assert.True(authority.Extensions.OfType<X509BasicConstraintsExtension>().Single().CertificateAuthority);
    }

    [Fact]
    public void A_PC_that_trusts_some_other_authority_does_not_accept_this_shops_certificate()
    {
        using var a = new TempFolder();
        using var b = new TempFolder();
        using var mine = StoreCertificates.Ensure(a.Path, Shop, Now);
        using var other = StoreCertificates.Ensure(b.Path, Shop, Now);
        Assert.False(StoreCertificates.ChainsTo(mine.Server, other.CaPem, Now));
        Assert.NotEqual(mine.CaFingerprint, other.CaFingerprint);
    }

    [Fact]
    public void Only_the_public_part_is_ever_handed_out_and_the_private_keys_are_in_files_only_the_Hubs_account_can_read()
    {
        using var t = new TempFolder();
        using var set = StoreCertificates.Ensure(t.Path, Shop, Now);
        Assert.Contains("BEGIN CERTIFICATE", set.CaPem);
        Assert.DoesNotContain("PRIVATE", set.CaPem);
        Assert.Equal(64, set.CaFingerprint.Length);
        Assert.Matches("^[0-9A-F]{64}$", set.CaFingerprint);
        Assert.Matches("^([0-9A-F]{4} ){15}[0-9A-F]{4}$", StoreCertificates.Spaced(set.CaFingerprint));

        var folder = StoreCertificates.FolderIn(t.Path);
        var files = Directory.GetFiles(folder).Select(Path.GetFileName).OrderBy(x => x).ToArray();
        Assert.Equal(new[] { "store-authority.crt", "store-authority.key", "this-pc.crt", "this-pc.key" }, files);
        Assert.Contains("PRIVATE KEY", File.ReadAllText(Path.Combine(folder, "store-authority.key")));
        if (!OperatingSystem.IsWindows())
        {
            Assert.Equal(UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute, File.GetUnixFileMode(folder));
            foreach (var f in Directory.GetFiles(folder)) Assert.Equal(UnixFileMode.UserRead | UnixFileMode.UserWrite, File.GetUnixFileMode(f));
        }
    }

    [Fact]
    public void Starting_again_changes_nothing_so_counter_PCs_keep_trusting_the_same_authority()
    {
        using var t = new TempFolder();
        using var first = StoreCertificates.Ensure(t.Path, Shop, Now);
        var before = File.ReadAllText(Path.Combine(StoreCertificates.FolderIn(t.Path), "this-pc.crt"));
        using var second = StoreCertificates.Ensure(t.Path, Shop, Now.AddDays(3));
        Assert.False(second.AuthorityMade);
        Assert.False(second.ServerMade);
        Assert.Equal(first.CaFingerprint, second.CaFingerprint);
        Assert.Equal(before, File.ReadAllText(Path.Combine(StoreCertificates.FolderIn(t.Path), "this-pc.crt")));
    }

    [Fact]
    public void When_the_PCs_address_changes_the_certificate_is_made_again_but_the_authority_is_kept()
    {
        using var t = new TempFolder();
        using var first = StoreCertificates.Ensure(t.Path, Shop, Now);
        var moved = new HostIdentity("MAIN-PC", new[] { IPAddress.Parse("10.0.0.7") });
        using var second = StoreCertificates.Ensure(t.Path, moved, Now.AddDays(1));
        Assert.False(second.AuthorityMade);
        Assert.True(second.ServerMade);
        Assert.Equal(first.CaFingerprint, second.CaFingerprint);
        // A counter PC that trusted the first authority accepts the new certificate, and it names the new address.
        Assert.True(StoreCertificates.ChainsTo(second.Server, first.CaPem, Now.AddDays(1)));
        Assert.Contains("10.0.0.7", second.Server.Extensions.OfType<X509SubjectAlternativeNameExtension>().Single().EnumerateIPAddresses().Select(a => a.ToString()));
        Assert.Contains("10.0.0.7", second.Names);
    }

    [Fact]
    public void When_the_PC_is_renamed_the_certificate_follows()
    {
        using var t = new TempFolder();
        using var first = StoreCertificates.Ensure(t.Path, Shop, Now);
        using var second = StoreCertificates.Ensure(t.Path, new HostIdentity("FRONT-DESK", Shop.Addresses), Now);
        Assert.True(second.ServerMade);
        Assert.False(second.AuthorityMade);
        Assert.Contains("FRONT-DESK", second.Names);
    }

    [Fact]
    public void A_certificate_near_its_end_is_renewed_and_an_authority_near_its_end_is_made_new()
    {
        using var t = new TempFolder();
        using var first = StoreCertificates.Ensure(t.Path, Shop, Now);

        using var renewed = StoreCertificates.Ensure(t.Path, Shop, Now.AddDays(780));   // the PC's certificate has fewer than 30 days left
        Assert.True(renewed.ServerMade);
        Assert.False(renewed.AuthorityMade);
        Assert.Equal(first.CaFingerprint, renewed.CaFingerprint);
        Assert.True(StoreCertificates.ChainsTo(renewed.Server, first.CaPem, Now.AddDays(780)));

        using var fresh = StoreCertificates.Ensure(t.Path, Shop, Now.AddDays(3600));    // the authority has fewer than 60 days left
        Assert.True(fresh.AuthorityMade);
        Assert.True(fresh.ServerMade);
        Assert.NotEqual(first.CaFingerprint, fresh.CaFingerprint);
        Assert.True(StoreCertificates.ChainsTo(fresh.Server, fresh.CaPem, Now.AddDays(3600)));
    }

    [Fact]
    public void Damaged_or_swapped_files_are_made_again_instead_of_stopping_the_Hub()
    {
        using var t = new TempFolder();
        using var first = StoreCertificates.Ensure(t.Path, Shop, Now);
        var folder = StoreCertificates.FolderIn(t.Path);

        File.WriteAllText(Path.Combine(folder, "this-pc.key"), "garbage");
        using var a = StoreCertificates.Ensure(t.Path, Shop, Now);
        Assert.True(a.ServerMade);
        Assert.False(a.AuthorityMade);

        File.WriteAllText(Path.Combine(folder, "store-authority.crt"), "garbage");
        using var b = StoreCertificates.Ensure(t.Path, Shop, Now);
        Assert.True(b.AuthorityMade);
        Assert.NotEqual(first.CaFingerprint, b.CaFingerprint);
        Assert.True(StoreCertificates.ChainsTo(b.Server, b.CaPem, Now));
    }

    [Fact]
    public void A_certificate_signed_by_another_authority_that_is_put_in_the_folder_is_not_used()
    {
        using var mine = new TempFolder();
        using var theirs = new TempFolder();
        using var first = StoreCertificates.Ensure(mine.Path, Shop, Now);
        using var foreign = StoreCertificates.Ensure(theirs.Path, Shop, Now);
        File.Copy(Path.Combine(StoreCertificates.FolderIn(theirs.Path), "this-pc.crt"), Path.Combine(StoreCertificates.FolderIn(mine.Path), "this-pc.crt"), true);
        File.Copy(Path.Combine(StoreCertificates.FolderIn(theirs.Path), "this-pc.key"), Path.Combine(StoreCertificates.FolderIn(mine.Path), "this-pc.key"), true);
        using var again = StoreCertificates.Ensure(mine.Path, Shop, Now);
        Assert.True(again.ServerMade);
        Assert.Equal(first.CaFingerprint, again.CaFingerprint);
        Assert.True(StoreCertificates.ChainsTo(again.Server, first.CaPem, Now));
    }

    // ---- what the Hub does when it starts ---------------------------------------------------------------------------------------

    [Fact]
    public void By_default_the_Hub_does_nothing_about_the_network_and_makes_no_files()
    {
        using var t = new TempFolder();
        var runtime = NetworkStartup.Prepare(t.Path, new[] { 5280 }, Now, () => Shop);
        Assert.False(runtime.Running);
        Assert.False(runtime.Accepting);
        Assert.False(runtime.Chosen);
        Assert.Null(runtime.Problem);
        Assert.Null(runtime.ServerCertificate);
        Assert.Empty(Directory.GetFileSystemEntries(t.Path));   // not even a certificate folder: the default is as it always was
    }

    [Fact]
    public void Switched_on_the_Hub_makes_the_certificates_and_listens_on_the_chosen_port_for_this_PCs_names_and_addresses()
    {
        using var t = new TempFolder();
        var port = TempFolder.FreePort();
        NetworkSettingsFile.Write(t.Path, new NetworkSettings(true, port));
        var runtime = NetworkStartup.Prepare(t.Path, new[] { 5280 }, Now, () => Shop);
        Assert.True(runtime.Running);
        Assert.True(runtime.Accepting);
        Assert.Equal(port, runtime.Port);
        Assert.Null(runtime.Problem);
        Assert.True(runtime.ServerCertificate!.HasPrivateKey);
        Assert.Contains("MAIN-PC", runtime.Hosts);
        Assert.Contains("192.168.1.20", runtime.Hosts);
        Assert.Contains("localhost", runtime.Hosts);
        Assert.Equal("MAIN-PC", runtime.HostName);
        Assert.Equal(new[] { 5280 }, runtime.ReservedPorts);
        Assert.Contains("BEGIN CERTIFICATE", runtime.AuthorityPem);
        Assert.Equal(64, runtime.AuthorityFingerprint!.Length);
    }

    [Fact]
    public void A_port_that_is_already_used_means_the_Hub_does_not_listen_and_says_so_in_plain_words()
    {
        using var t = new TempFolder();
        using var holder = new TcpListener(IPAddress.Any, 0);
        holder.Start();
        var port = ((IPEndPoint)holder.LocalEndpoint).Port;
        NetworkSettingsFile.Write(t.Path, new NetworkSettings(true, port));
        var runtime = NetworkStartup.Prepare(t.Path, new[] { 5280 }, Now, () => Shop);
        Assert.False(runtime.Running);
        Assert.False(runtime.Accepting);
        Assert.True(runtime.Chosen);
        Assert.Contains($"port {port} is already used", runtime.Problem);
        Assert.Contains("restart", runtime.Problem!, StringComparison.OrdinalIgnoreCase);
        Assert.False(Directory.Exists(StoreCertificates.FolderIn(t.Path)));   // nothing was made for a listener that will not exist
    }

    [Fact]
    public void The_Hubs_own_port_cannot_be_given_to_counter_PCs()
    {
        using var t = new TempFolder();
        NetworkSettingsFile.Write(t.Path, new NetworkSettings(true, 5280));
        var runtime = NetworkStartup.Prepare(t.Path, new[] { 5280 }, Now, () => Shop);
        Assert.False(runtime.Running);
        Assert.Contains("already used by the Hub", runtime.Problem);
    }

    [Fact]
    public void If_the_certificates_cannot_be_written_the_Hub_still_starts_on_this_PC_only()
    {
        using var t = new TempFolder();
        File.WriteAllText(Path.Combine(t.Path, StoreCertificates.FolderName), "a file where the folder should be");
        NetworkSettingsFile.Write(t.Path, new NetworkSettings(true, TempFolder.FreePort()));
        var runtime = NetworkStartup.Prepare(t.Path, Array.Empty<int>(), Now, () => Shop);   // does not throw
        Assert.False(runtime.Running);
        Assert.False(runtime.Accepting);
        Assert.Contains("certificate could not be made", runtime.Problem);
        Assert.Contains("this PC only", runtime.Problem);
    }

    [Fact]
    public void A_PC_with_no_network_address_still_gets_a_certificate_for_itself()
    {
        using var t = new TempFolder();
        NetworkSettingsFile.Write(t.Path, new NetworkSettings(true, TempFolder.FreePort()));
        var runtime = NetworkStartup.Prepare(t.Path, Array.Empty<int>(), Now, () => new HostIdentity("", Array.Empty<IPAddress>()));
        Assert.True(runtime.Running);
        Assert.Contains("localhost", runtime.Hosts);
        Assert.Empty(runtime.Addresses);
    }

    [Theory]
    [InlineData("MAIN-PC", "MAIN-PC")]
    [InlineData("shop.lan", "shop.lan")]
    [InlineData("  pc1.  ", "pc1")]
    [InlineData("bad name", null)]
    [InlineData("under_score", null)]
    [InlineData("-lead", null)]
    [InlineData("", null)]
    [InlineData("münchen", null)]
    public void Only_a_name_that_can_stand_in_a_certificate_is_used(string raw, string? expected) => Assert.Equal(expected, LocalNetwork.Clean(raw));

    [Fact]
    public void The_names_a_counter_PC_may_use_are_the_PCs_name_its_first_part_and_each_with_dot_local()
    {
        Assert.Equal(new[] { "shop.lan", "shop", "shop.local" }, LocalNetwork.Names(new HostIdentity("shop.lan", Array.Empty<IPAddress>())));
        Assert.Equal(new[] { "MAIN-PC", "MAIN-PC.local" }, LocalNetwork.Names(Shop));
        Assert.Empty(LocalNetwork.Names(new HostIdentity("not valid", Array.Empty<IPAddress>())));
    }

    [Fact]
    public void Looking_at_the_real_PC_never_throws_and_never_offers_a_loopback_or_self_assigned_address()
    {
        var me = LocalNetwork.Detect();
        Assert.NotNull(me.HostName);
        Assert.All(me.Addresses, a =>
        {
            Assert.Equal(System.Net.Sockets.AddressFamily.InterNetwork, a.AddressFamily);
            Assert.False(IPAddress.IsLoopback(a));
            var bytes = a.GetAddressBytes();
            Assert.False(bytes[0] == 169 && bytes[1] == 254);
        });
    }
}

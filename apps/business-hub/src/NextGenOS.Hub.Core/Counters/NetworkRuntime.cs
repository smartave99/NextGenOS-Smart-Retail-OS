using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace NextGenOS.Hub.Counters;

/// <summary>
/// What the Hub did about counter PCs when it started, and what the owner has chosen since. The web server cannot start or stop listening while it runs, so the two can differ: the owner's
/// choice is saved at once, but a new listener appears only at the next start. Switching counter PCs OFF, however, takes effect at once: <see cref="Accepting"/> turns false and every
/// counter PC is refused, even though the listener stays open until the next start.
/// </summary>
public sealed class NetworkRuntime
{
    private volatile bool _chosen;

    internal NetworkRuntime(bool running, bool chosen, int port, string? problem, string hostName, IReadOnlyList<string> addresses, IReadOnlyList<string> hosts, IReadOnlyList<int> reservedPorts, StoreCertificateSet? certificates)
    {
        Running = running;
        _chosen = chosen;
        Port = port;
        Problem = problem;
        HostName = hostName;
        Addresses = addresses;
        Hosts = hosts;
        ReservedPorts = reservedPorts;
        Certificates = certificates;
    }

    /// <summary>True when the Hub is listening on the shop's network in this run (it was switched on, and everything it needed was in order, when the Hub started).</summary>
    public bool Running { get; }

    /// <summary>The port of that listener (what the Hub started with, not necessarily what is saved now).</summary>
    public int Port { get; }

    /// <summary>In plain words, why counter PCs cannot connect even though the owner asked for it; null when there is nothing wrong.</summary>
    public string? Problem { get; }

    /// <summary>True while the owner's saved choice is "counter PCs may connect".</summary>
    public bool Chosen => _chosen;

    /// <summary>True when counter PCs are served right now: the Hub is listening and the owner has not switched it off since.</summary>
    public bool Accepting => Running && _chosen;

    public string HostName { get; }

    /// <summary>This PC's addresses on the shop's network (as text).</summary>
    public IReadOnlyList<string> Addresses { get; }

    /// <summary>The names and addresses a counter PC may use to reach this PC (the web server accepts only these, besides this PC's own).</summary>
    public IReadOnlyList<string> Hosts { get; }

    /// <summary>The ports the Hub itself already listens on, which counter PCs may not be given.</summary>
    public IReadOnlyList<int> ReservedPorts { get; }

    /// <summary>The shop's certificates, when they were made at this start. The private key inside is handed to the web server and nowhere else.</summary>
    public StoreCertificateSet? Certificates { get; }

    /// <summary>The certificate of this PC for the web server to use, or null when the Hub is not listening on the network.</summary>
    public X509Certificate2? ServerCertificate => Certificates?.Server;

    /// <summary>The authority's public certificate as text, for the page that lets a counter PC trust it. Null when there is none.</summary>
    public string? AuthorityPem => Certificates?.CaPem;

    public string? AuthorityFingerprint => Certificates?.CaFingerprint;

    internal void Choose(bool value) => _chosen = value;

    /// <summary>Counter PCs are not served: the default, and the state of every program that does not start the network.</summary>
    public static NetworkRuntime Off(IReadOnlyList<int>? reservedPorts = null, string? problem = null) =>
        new(false, false, NetworkSettings.DefaultPort, problem, "", Array.Empty<string>(), Array.Empty<string>(), reservedPorts ?? Array.Empty<int>(), null);
}

public static class NetworkStartup
{
    /// <summary>
    /// Decides, at the start of the Hub, whether to listen on the shop's network. Off by default. When the owner switched it on, it makes (or loads) the shop's certificates and checks that
    /// the port is free; if anything is wrong it does NOT listen and says why in plain words, and the Hub starts as it always did (on this PC only). Counter PCs are never a reason for the
    /// shop's own PC not to start. Never throws.
    /// </summary>
    /// <param name="dataFolder">The Hub's data folder (where network.json and the certificates are).</param>
    /// <param name="reservedPorts">Ports the Hub already listens on.</param>
    /// <param name="identity">This PC's name and addresses; null looks at the real PC.</param>
    /// <param name="portIsFree">Tells whether a port can be listened on; null tries it.</param>
    public static NetworkRuntime Prepare(string dataFolder, IReadOnlyList<int> reservedPorts, DateTimeOffset now, Func<HostIdentity>? identity = null, Func<int, bool>? portIsFree = null)
    {
        var settings = NetworkSettingsFile.Read(dataFolder);
        if (!settings.Enabled) return NetworkRuntime.Off(reservedPorts, settings.Problem);
        if (NetworkSettingsFile.CheckPort(settings.Port, reservedPorts) is { } badPort) return Failed(settings, reservedPorts, "Counter PCs could not be switched on. " + badPort);
        if (!(portIsFree ?? PortIsFree)(settings.Port))
            return Failed(settings, reservedPorts, $"Counter PCs could not be switched on: port {settings.Port} is already used by another program on this PC. Choose another port in Settings, Store network, and restart the Hub.");
        try
        {
            var me = (identity ?? LocalNetwork.Detect)();
            var certificates = StoreCertificates.Ensure(dataFolder, me, now);
            var names = LocalNetwork.Names(me);
            var addresses = me.Addresses.Select(a => a.ToString()).ToList();
            var hosts = names.Concat(addresses).Concat(new[] { "localhost", "127.0.0.1" }).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            return new NetworkRuntime(true, true, settings.Port, null, names.FirstOrDefault() ?? "", addresses, hosts, reservedPorts, certificates);
        }
        catch (Exception ex) when (ex is System.Security.Cryptography.CryptographicException or IOException or UnauthorizedAccessException or InvalidOperationException or ArgumentException)
        {
            return Failed(settings, reservedPorts, "Counter PCs could not be switched on: the shop's certificate could not be made or read (" + ex.Message + "). The Hub runs on this PC only.");
        }
    }

    private static NetworkRuntime Failed(NetworkSettings settings, IReadOnlyList<int> reserved, string problem) =>
        new(false, true, settings.Port, problem, "", Array.Empty<string>(), Array.Empty<string>(), reserved, null);

    /// <summary>Tries to listen on the port on every address, then lets go at once.</summary>
    public static bool PortIsFree(int port)
    {
        try
        {
            var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            listener.Stop();
            return true;
        }
        catch (SocketException)
        {
            return false;
        }
    }
}

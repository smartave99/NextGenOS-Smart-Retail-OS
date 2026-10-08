using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace NextGenOS.Hub.Counters;

/// <summary>What this PC is called on the shop's network and which addresses it has. The names are what a counter PC types in its address bar; the shop's certificate is made for them.</summary>
public sealed record HostIdentity(string HostName, IReadOnlyList<IPAddress> Addresses);

public static partial class LocalNetwork
{
    /// <summary>
    /// Looks at this PC. Never throws: what cannot be seen is left out. Only IPv4 addresses are used (counter PCs are told an IPv4 address or the PC's name), and only those
    /// of interfaces that are up; loopback and the self-assigned 169.254.x.x addresses are left out.
    /// </summary>
    public static HostIdentity Detect()
    {
        string name;
        try { name = Clean(Dns.GetHostName()) ?? ""; }
        catch (SocketException) { name = ""; }

        var found = new List<IPAddress>();
        try
        {
            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus != OperationalStatus.Up || nic.NetworkInterfaceType == NetworkInterfaceType.Loopback) continue;
                foreach (var unicast in nic.GetIPProperties().UnicastAddresses)
                {
                    var a = unicast.Address;
                    if (a.AddressFamily != AddressFamily.InterNetwork || IPAddress.IsLoopback(a)) continue;
                    var b = a.GetAddressBytes();
                    if (b[0] == 169 && b[1] == 254) continue;
                    if (!found.Any(x => x.Equals(a))) found.Add(a);
                }
            }
        }
        catch (Exception ex) when (ex is NetworkInformationException or SocketException or PlatformNotSupportedException) { }

        return new HostIdentity(name, found);
    }

    /// <summary>A computer name that can be written in a certificate and typed in an address bar: letters, digits, hyphens and dots only, at most 253 characters. Anything else gives null.</summary>
    public static string? Clean(string? raw)
    {
        var name = (raw ?? "").Trim().TrimEnd('.');
        return name.Length is >= 1 and <= 253 && ValidName().IsMatch(name) ? name : null;
    }

    [GeneratedRegex(@"^[A-Za-z0-9]([A-Za-z0-9\-]{0,61}[A-Za-z0-9])?(\.[A-Za-z0-9]([A-Za-z0-9\-]{0,61}[A-Za-z0-9])?)*$", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex ValidName();

    /// <summary>The names a counter PC may use for this PC: the PC's name, its first part, and each with ".local" (what many networks answer to), without repeats.</summary>
    public static IReadOnlyList<string> Names(HostIdentity identity)
    {
        var names = new List<string>();
        void Add(string? n)
        {
            if (!string.IsNullOrEmpty(n) && !names.Contains(n, StringComparer.OrdinalIgnoreCase)) names.Add(n);
        }

        var host = Clean(identity.HostName);
        if (host is null) return names;
        Add(host);
        var first = host.Split('.')[0];
        Add(first);
        Add(first + ".local");
        return names;
    }
}

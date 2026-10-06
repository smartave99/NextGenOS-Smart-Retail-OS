using System.Net;
using System.Net.Sockets;

namespace NextGenOS.Hub.Ai;

/// <summary>Where an address points: this computer, the shop's own network, or the internet. An address the owner calls "local" must really be this computer.</summary>
public static class EndpointClassifier
{
    public const string Loopback = "loopback";
    public const string PrivateNetwork = "private-network";
    public const string Internet = "internet";
    public const string Invalid = "invalid";

    public static string Classify(string? url)
    {
        if (!Uri.TryCreate(url?.Trim(), UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps) || string.IsNullOrEmpty(uri.Host)) return Invalid;
        var host = uri.Host.Trim('[', ']');
        if (host.Equals("localhost", StringComparison.OrdinalIgnoreCase) || host.EndsWith(".localhost", StringComparison.OrdinalIgnoreCase)) return Loopback;
        if (IPAddress.TryParse(host, out var ip)) return Classify(ip);
        // A name that is not an address: only the names a shop network uses for itself count as private; anything else is the internet (it could resolve anywhere).
        if (!host.Contains('.') || host.EndsWith(".local", StringComparison.OrdinalIgnoreCase) || host.EndsWith(".lan", StringComparison.OrdinalIgnoreCase) || host.EndsWith(".home.arpa", StringComparison.OrdinalIgnoreCase)) return PrivateNetwork;
        return Internet;
    }

    public static string Classify(IPAddress ip)
    {
        if (ip.IsIPv4MappedToIPv6) ip = ip.MapToIPv4();
        if (IPAddress.IsLoopback(ip)) return Loopback;
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
            var b = ip.GetAddressBytes();
            if (b[0] == 10 || (b[0] == 172 && b[1] is >= 16 and <= 31) || (b[0] == 192 && b[1] == 168) || (b[0] == 169 && b[1] == 254) || (b[0] == 100 && b[1] is >= 64 and <= 127)) return PrivateNetwork;
            return Internet;
        }
        if (ip.AddressFamily == AddressFamily.InterNetworkV6)
        {
            if (ip.IsIPv6LinkLocal || ip.IsIPv6SiteLocal) return PrivateNetwork;
            var b = ip.GetAddressBytes();
            if ((b[0] & 0xFE) == 0xFC) return PrivateNetwork;   // fc00::/7, unique local addresses
        }
        return Internet;
    }

    /// <summary>Checks that where a service is said to run matches its address. Returns a sentence for the owner when it does not, otherwise null.</summary>
    public static string? Mismatch(string location, string url)
    {
        // A tool the owner signed in to on this computer has no address to check.
        if (location == ProviderLocation.Cli) return null;
        var where = Classify(url);
        if (where == Invalid) return "That address is not a web address (it must start with http:// or https://).";
        // A name, a password or a token written into the address would be kept in the database and shown on screens. The key has its own box, which keeps it in the safe.
        var parsed = new Uri(url.Trim());
        if (!string.IsNullOrEmpty(parsed.UserInfo)) return "Do not put a name or password in the address. Type the key in the key box: it is kept safely there.";
        if (!string.IsNullOrEmpty(parsed.Query) || !string.IsNullOrEmpty(parsed.Fragment)) return "The address must not have a '?' or '#' part. If the service wants a key, type it in the key box.";
        switch (location)
        {
            case ProviderLocation.Local or ProviderLocation.LocalOptimized:
                return where == Loopback ? null : "A service on this computer must have an address that points to this computer (localhost or 127.0.0.1).";
            case ProviderLocation.Lan:
                return where is Loopback or PrivateNetwork ? null : "A service on the shop's network must have an address inside that network (for example 192.168.1.20), not on the internet.";
            case ProviderLocation.Api:
                if (where == Internet && new Uri(url.Trim()).Scheme != Uri.UriSchemeHttps) return "An online service must be reached over https:// so that nobody can read what is sent.";
                return null;
            case ProviderLocation.Cli:
                return null;
            default:
                return "Unknown place for the service.";
        }
    }
}

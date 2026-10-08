using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using NextGenOS.Hub.Counters;

namespace NextGenOS.Hub.Web.Counters;

/// <summary>
/// Starting the Hub with (or without) the shop's network. By default nothing changes: the Hub listens on this PC only, as the settings file says, and not one file or listener is added.
/// When the owner switched counter PCs on (and the Hub was started again since), the Hub listens on this PC as before and, in addition, on the shop's network on its own secure port.
/// The web server cannot start listening while it runs, which is why the choice is read here, once, at the start.
/// </summary>
internal static partial class StoreNetworkHost
{
    /// <summary>The port the Hub listens on this PC by default (the setup's shortcut and the health check use it). Counter PCs are never given it.</summary>
    public const int OwnPort = 5280;

    /// <summary>Reads the owner's choice, prepares the certificates, and (only when it is all in order) adds the secure listener. Never stops the Hub from starting.</summary>
    public static NetworkRuntime Add(WebApplicationBuilder builder, string dataFolder)
    {
        var runtime = NetworkStartup.Prepare(dataFolder, ConfiguredPorts(builder.Configuration), DateTimeOffset.UtcNow);
        builder.Services.AddSingleton(runtime);
        builder.Services.AddSingleton<ConnectionTracker>();
        if (!runtime.Running) return runtime;

        builder.WebHost.ConfigureKestrel(options => ListenOnTheNetwork(options, runtime, builder.Configuration));
        // A counter PC opens the Hub by this PC's name or address, which the Hub otherwise refuses (it answers only to this PC's own names).
        builder.Services.PostConfigure<HostFilteringOptions>(options =>
        {
            if (options.AllowedHosts is null || options.AllowedHosts.Count == 0 || options.AllowedHosts.Contains("*")) return;
            // (The list that comes from the settings file is an array of fixed size, so it is replaced, not added to.)
            var allowed = options.AllowedHosts.ToList();
            foreach (var host in runtime.Hosts)
                if (!allowed.Contains(host, StringComparer.OrdinalIgnoreCase)) allowed.Add(host);
            options.AllowedHosts = allowed;
        });
        return runtime;
    }

    /// <summary>
    /// Adds the secure listener on every network address of this PC. A listener written in code replaces the addresses given on the command line, so those are listened on again as they
    /// were (the ones in the Hub's settings file are kept by the web server itself). This PC's own address (127.0.0.1) is never taken away.
    /// </summary>
    internal static void ListenOnTheNetwork(KestrelServerOptions options, NetworkRuntime net, IConfiguration config)
    {
        if (!config.GetSection("Kestrel:Endpoints").GetChildren().Any())
        {
            var given = GivenAddresses(config);
            if (given.Count == 0) given.Add((IPAddress.Loopback, OwnPort));
            foreach (var (address, port) in given) options.Listen(address, port);
        }

        options.ListenAnyIP(net.Port, listen => listen.UseHttps(net.ServerCertificate!));
    }

    /// <summary>The ports the Hub already listens on (from the settings file, the command line or the environment), and its own.</summary>
    internal static IReadOnlyList<int> ConfiguredPorts(IConfiguration config)
    {
        var ports = new List<int> { OwnPort };
        foreach (var url in Urls(config))
            if (PortOf(url) is { } port && !ports.Contains(port)) ports.Add(port);
        return ports;
    }

    private static IEnumerable<string> Urls(IConfiguration config)
    {
        foreach (var child in config.GetSection("Kestrel:Endpoints").GetChildren())
            if (child["Url"] is { Length: > 0 } url) yield return url;
        foreach (var key in new[] { "urls", "http_ports" })
            if (config[key] is { Length: > 0 } value)
                foreach (var part in value.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) yield return key == "urls" ? part : "http://*:" + part;
    }

    private static int? PortOf(string url)
    {
        var m = PortAtEnd().Match(url);
        return m.Success && int.TryParse(m.Groups[1].Value, out var port) && port is > 0 and <= 65535 ? port : null;
    }

    [GeneratedRegex(@":(\d{1,5})(?:/.*)?$", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex PortAtEnd();

    private static List<(IPAddress Address, int Port)> GivenAddresses(IConfiguration config)
    {
        var found = new List<(IPAddress, int)>();
        foreach (var url in Urls(config))
        {
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || PortOf(url) is not { } port) continue;
            var host = url["http://".Length..];
            host = host[..host.LastIndexOf(':')].Trim('[', ']');
            var address = host switch
            {
                "localhost" or "127.0.0.1" => IPAddress.Loopback,
                "::1" => IPAddress.IPv6Loopback,
                "*" or "+" or "0.0.0.0" or "" => IPAddress.Any,
                _ => IPAddress.TryParse(host, out var ip) ? ip : IPAddress.Any,
            };
            found.Add((address, port));
        }

        return found;
    }

    /// <summary>Connects the Hub's counter PC events to the open connections: removing a counter PC, or switching counter PCs off, ends what is open at once.</summary>
    public static void Connect(HubApp hub, ConnectionTracker tracker)
    {
        hub.Network.Pairing.CounterRemoved += id => tracker.Cut(id);
        hub.Network.ChoiceChanged += on =>
        {
            if (!on) tracker.CutAll();
        };
    }
}

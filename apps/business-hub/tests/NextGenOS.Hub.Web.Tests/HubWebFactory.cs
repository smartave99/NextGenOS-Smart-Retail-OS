using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NextGenOS.Hub.Counters;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The Hub in memory with its own data folder. Only the licence is stood in for (as the gate tests do): the real check is in the licensing library's own tests.</summary>
public sealed class HubWebFactory : WebApplicationFactory<Program>
{
    private readonly string _folder = Path.Combine(Path.GetTempPath(), "hub-web-" + Guid.NewGuid().ToString("N"));

    public bool Licensed { get; set; } = true;

    /// <summary>The parts of the program the stand-in licence includes. The Hub needs "hub"; the AI parts need "ai" as well.</summary>
    public string[] Modules { get; set; } = ["hub"];

    public string Folder => _folder;

    /// <summary>Where the copy made before an update goes (the Hub:BackupFolder setting); null: next to the shop's file.</summary>
    public string? BackupFolder { get; set; }

    /// <summary>Shapes the stand-in licence further (for example makes it a trial that ends on a day, or a paid licence that has ended). Read when the licence is first looked at.</summary>
    public Action<LicenceState>? ShapeLicence { get; set; }

    /// <summary>The licence's number of PCs for the stand-in licence (0: no limit). Read on every pairing, as the real one is.</summary>
    public int Devices { get; set; }

    /// <summary>
    /// True: the owner had switched counter PCs on before the Hub started (the file network.json is written first, with a free port), so the Hub makes its certificates and serves counter PCs.
    /// The in-memory test server has no network, so a test says where a request "comes from" with <see cref="RemoteHeader"/>.
    /// </summary>
    public bool NetworkOn { get; set; }

    /// <summary>The header a test sets to say which address its request came from (a test server has none). Without it the request has no address, as it never had.</summary>
    public const string RemoteHeader = "X-Test-Remote";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        if (NetworkOn)
        {
            Directory.CreateDirectory(_folder);
            NetworkSettingsFile.Write(_folder, new NetworkSettings(true, FreePort()));
        }

        builder.UseSetting("Hub:DataFolder", _folder);
        if (BackupFolder is not null) builder.UseSetting("Hub:BackupFolder", BackupFolder);
        builder.UseEnvironment("Production");
        builder.ConfigureTestServices(services =>
        {
            services.AddSingleton(new ProductLicence(() =>
            {
                if (!Licensed) return new LicenceState { Status = LicenceStatus.Missing };
                var state = new LicenceState { Status = LicenceStatus.Valid, Licence = new LicenceClaims { Modules = [.. Modules], Limits = new Limits { Devices = Devices } } };
                ShapeLicence?.Invoke(state);
                return state;
            }));
            services.AddTransient<Microsoft.AspNetCore.Hosting.IStartupFilter>(_ => new RemoteAddressFilter());
        });
    }

    private static int FreePort()
    {
        var probe = new TcpListener(IPAddress.Loopback, 0);
        probe.Start();
        var port = ((IPEndPoint)probe.LocalEndpoint).Port;
        probe.Stop();
        return port;
    }

    /// <summary>Runs before the Hub's own steps and gives the request the address the test named (the way a real connection has one).</summary>
    private sealed class RemoteAddressFilter : Microsoft.AspNetCore.Hosting.IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) => app =>
        {
            app.Use((context, step) =>
            {
                if (context.Request.Headers.TryGetValue(RemoteHeader, out var value) && IPAddress.TryParse(value.ToString(), out var ip))
                    context.Connection.RemoteIpAddress = ip;
                return step(context);
            });
            next(app);
        };
    }

    /// <summary>
    /// The shop the web program uses, for the test to read and set up. What the test does with it is done as the program itself (the Hub's own lock would refuse a command that names nobody);
    /// the requests the test sends through the web server are NOT: they run as whoever is signed in, with the Hub's lock on.
    /// </summary>
    public HubApp Hub
    {
        get
        {
            var app = Services.GetRequiredService<HubApp>();
            app.Access.EnterSystemForTests();
            return app;
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (!disposing) return;
        try { Directory.Delete(_folder, true); } catch (IOException) { } catch (UnauthorizedAccessException) { }
    }
}

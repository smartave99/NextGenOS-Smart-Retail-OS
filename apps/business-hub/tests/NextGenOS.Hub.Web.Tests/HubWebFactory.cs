using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
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

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("Hub:DataFolder", _folder);
        if (BackupFolder is not null) builder.UseSetting("Hub:BackupFolder", BackupFolder);
        builder.UseEnvironment("Production");
        builder.ConfigureTestServices(services =>
        {
            services.AddSingleton(new ProductLicence(() => Licensed
                ? new LicenceState { Status = LicenceStatus.Valid, Licence = new LicenceClaims { Modules = [.. Modules] } }
                : new LicenceState { Status = LicenceStatus.Missing }));
        });
    }

    public HubApp Hub => Services.GetRequiredService<HubApp>();

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (!disposing) return;
        try { Directory.Delete(_folder, true); } catch (IOException) { } catch (UnauthorizedAccessException) { }
    }
}

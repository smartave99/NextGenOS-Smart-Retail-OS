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

    public string Folder => _folder;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("Hub:DataFolder", _folder);
        builder.UseEnvironment("Production");
        builder.ConfigureTestServices(services =>
        {
            services.AddSingleton(new ProductLicence(() => Licensed
                ? new LicenceState { Status = LicenceStatus.Valid, Licence = new LicenceClaims { Modules = ["hub"] } }
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

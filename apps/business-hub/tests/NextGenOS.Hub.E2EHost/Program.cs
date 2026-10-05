using Microsoft.Extensions.DependencyInjection;
using NextGenOS.Hub.Web;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

// dotnet run -- --Hub:DataFolder=/tmp/shop --urls=http://127.0.0.1:5291 [--E2E:Licensed=false]
var builder = HubHost.CreateBuilder(args);
builder.WebHost.UseStaticWebAssets();
HubHost.AddHub(builder);
var licensed = builder.Configuration.GetValue("E2E:Licensed", true);
builder.Services.AddSingleton(new ProductLicence(() => licensed
    ? new LicenceState { Status = LicenceStatus.Valid, Licence = new LicenceClaims { Modules = ["hub"] } }
    : new LicenceState { Status = LicenceStatus.Missing }));
var app = builder.Build();
HubHost.UseHub(app);
app.Run();

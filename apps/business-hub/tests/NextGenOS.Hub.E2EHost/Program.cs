using Microsoft.Extensions.DependencyInjection;
using NextGenOS.Hub.Web;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

// dotnet run -- --Hub:DataFolder=/tmp/shop --urls=http://127.0.0.1:5291 [--E2E:Licensed=false]
var builder = HubHost.CreateBuilder(args);
builder.WebHost.UseStaticWebAssets();
HubHost.AddHub(builder);
var licensed = builder.Configuration.GetValue("E2E:Licensed", true);
var white = builder.Configuration["E2E:White"];          // none, theme or full: how much of the look the licence lets the owner change
var modules = (builder.Configuration["E2E:Modules"] ?? "hub").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);   // the parts of the program the licence includes
var brand = builder.Configuration["E2E:Brand"];          // the name on the licence's own brand, if any
builder.Services.AddSingleton(new ProductLicence(() => licensed
    ? new LicenceState
    {
        Status = LicenceStatus.Valid,
        Licence = new LicenceClaims
        {
            Modules = [.. modules],
            White = white is null ? null : new WhiteLabel { Level = white },
            Brand = brand is null ? null : new BrandProfile { Id = "B-7", Name = brand, PrimaryColor = "#0f6cbd", PoweredBy = true },
        },
    }
    : new LicenceState { Status = LicenceStatus.Missing }));
var app = builder.Build();
HubHost.UseHub(app);
app.Run();

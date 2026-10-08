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
// Only for the browser test of the event history screen (--E2E:Seed=true): this test program is not shipped. There is nothing yet that records business events by itself, so the
// test records a few the way a camera service later will: through the event store.
if (builder.Configuration.GetValue("E2E:Seed", false))
{
    app.MapPost("/__e2e/seed-events", (NextGenOS.Hub.HubApp hub) =>
    {
        using var asTheProgram = hub.Access.AsSystem();   // the test host acts as the program itself (it is not shipped)
        hub.Ai.Flags.Set(NextGenOS.Hub.Ai.FlagKey.EventEngine, true, null);
        var now = DateTimeOffset.UtcNow;
        var a = hub.Events.Observe(new NextGenOS.Hub.Events.ObservationInput("object.detected", "model", "cam-1", "INTERNAL", now.AddMinutes(-4), 0.81, "detector", "2.1", "zone:aisle-3", "track:cam1:17", "hand", "{\"box\":[0.1,0.2,0.3,0.4]}"));
        var b = hub.Events.Observe(new NextGenOS.Hub.Events.ObservationInput("object.tracked", "model", "cam-1", "INTERNAL", now.AddMinutes(-4), 0.77, "tracker", "1.4", "zone:aisle-3", "track:cam1:17"));
        hub.Events.Append(new NextGenOS.Hub.Events.EventInput("customer_session.picked_up_product", "rule", "pickup-rule", "INTERNAL", now.AddMinutes(-3), 0.9, "1.0", "track:cam1:17", "track:cam1:17", "product:8901000000019", "zone:aisle-3",
            Explanation: "A hand stayed at the shelf and the product left it", ObservationIds: [a.Id, b.Id], Evidence: [new NextGenOS.Hub.Events.EvidenceInput("image", "camera-1/frame-0042.jpg", "INTERNAL")]));
        hub.Events.Append(new NextGenOS.Hub.Events.EventInput("shelf.low_stock", "model", "shelf-model", "INTERNAL", now.AddMinutes(-2), 0.62, "0.9", ZoneRef: "zone:aisle-3", Status: "proposed", Explanation: "The shelf looks nearly empty"));
        var wrong = hub.Events.Append(new NextGenOS.Hub.Events.EventInput("shelf.restocked", "system", "hub", "INTERNAL", now.AddMinutes(-2), ZoneRef: "zone:aisle-3"));
        hub.Events.Supersede(wrong.Id, new NextGenOS.Hub.Events.EventInput("shelf.checked", "person", "staff", "INTERNAL", now.AddMinutes(-1), ZoneRef: "zone:aisle-3", Explanation: "Someone only looked at it"), null, "it was only looked at");
        return Results.Ok(new { events = hub.Events.Counts().Confirmed });
    }).AllowAnonymous().DisableAntiforgery();
}

app.Run();

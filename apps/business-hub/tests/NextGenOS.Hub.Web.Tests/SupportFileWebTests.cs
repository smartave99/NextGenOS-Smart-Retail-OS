using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Web.Diagnostics;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The Help button's support file as the running program makes it: the program, the licence and the last problems it noticed, with every personal detail taken out.</summary>
public class SupportFileWebTests
{
    [Fact]
    public void The_file_has_the_program_the_licence_the_shop_and_the_last_problems_and_none_of_the_personal_details_that_were_in_them()
    {
        using var factory = new HubWebFactory { Modules = ["hub", "ai"], ShapeLicence = s => { s.Licence.LicenceId = "L-2026-0042"; s.Licence.Trial = true; s.Licence.Edition = "standard"; } };
        var services = factory.Services;
        var app = services.GetRequiredService<HubApp>();
        app.Shop.Save(new NextGenOS.Hub.Shop.ShopSettings { Name = "Test Shop", Country = "IN", Region = "27", Industry = "retail", SetupDone = true });
        var owner = app.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery staple").Id;     // the first person: allowed before anyone can sign in
        using (app.Access.As(owner)) app.Parties.Create(new NextGenOS.Hub.Catalog.PartyInput { Kind = "customer", Name = "Maria Santos", Phone = "+91 98765 43210" });

        var log = services.GetRequiredService<ILoggerFactory>().CreateLogger("Test.Screen");
        log.LogError(new InvalidOperationException("could not save for Maria Santos (maria@example.com) in C:\\Users\\maria\\AppData\\shop.db"), "A screen could not do what was asked for +91 98765 43210.");
        log.LogInformation("this is not trouble and is not kept");

        var builder = services.GetRequiredService<SupportFileBuilder>();
        string text;
        using (app.Access.As(owner)) text = builder.Build("It stopped when Maria Santos paid.");

        Assert.Contains("THE PROGRAM", text);
        Assert.Contains("Version: ", text);
        Assert.Contains("Runs on: ", text);
        Assert.Contains("YOUR LICENCE", text);
        Assert.Contains("State: Valid", text);
        Assert.Contains("Licence number: L-2026-0042, kind: trial, edition: standard.", text);
        Assert.Contains("Parts included: hub, ai.", text);
        Assert.Contains("PROBLEMS NOTICED SINCE THE PROGRAM STARTED (NEWEST FIRST)", text);
        Assert.Contains("Error in Test.Screen: A screen could not do what was asked for [number].", text);
        Assert.Contains("InvalidOperationException", text);
        Assert.DoesNotContain("this is not trouble", text);
        foreach (var private_ in new[] { "Maria", "Santos", "maria@example.com", "98765", "C:\\Users", "AppData", "Olivia", "correct horse" }) Assert.DoesNotContain(private_, text, StringComparison.OrdinalIgnoreCase);
        Assert.Contains(app.Audit.Recent(), a => a.Action == "support.made" && a.UserId == owner);
    }

    [Fact]
    public void The_recorder_keeps_only_the_last_two_hundred_warnings_and_errors_and_nothing_milder()
    {
        var recorder = new TroubleLog();
        var log = recorder.CreateLogger("x");
        for (var i = 0; i < 250; i++) log.LogWarning("warning {Number}", i);
        log.LogInformation("information");
        log.LogDebug("debug");
        Assert.Equal(TroubleLog.Capacity, recorder.Recent(500).Count);
        Assert.Equal("warning 249", recorder.Recent(1).Single().Message);
        Assert.Equal("warning 50", recorder.Recent(500).Last().Message);
        Assert.False(log.IsEnabled(LogLevel.Information));
    }

    [Fact]
    public void Where_to_send_it_comes_from_the_licence_or_the_owners_own_brand_and_is_never_built_in()
    {
        using var plain = new HubWebFactory();
        var product = plain.Services.GetRequiredService<SupportFileBuilder>().SendTo;     // with no brand of its own the program shows its maker's contact (the default brand)
        Assert.NotNull(product);
        using var branded = new HubWebFactory { ShapeLicence = s => s.Licence.Brand = new NextGenOS.Licensing.BrandProfile { Id = "B-7", Name = "Acme POS", SupportEmail = "help@acme.example", SupportPhone = "+1 555 0100" } };
        Assert.Equal("help@acme.example or +1 555 0100", branded.Services.GetRequiredService<SupportFileBuilder>().SendTo);
        Assert.NotEqual(product, branded.Services.GetRequiredService<SupportFileBuilder>().SendTo);
    }
}

using Microsoft.Extensions.Configuration;
using NextGenOS.Hub.Web.Branding;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The profile files and the owner's layout choices: read safely, kept cleanly, and shown only as far as the licence allows.</summary>
public class ThemeTests : IDisposable
{
    private readonly string folder = Path.Combine(Path.GetTempPath(), "hub-theme-" + Guid.NewGuid().ToString("N"));
    private readonly string path;
    private readonly HubApp app;

    public ThemeTests()
    {
        Directory.CreateDirectory(folder);
        path = Path.Combine(folder, "shop.db");
        app = HubApp.Open(path);
    }

    public void Dispose()
    {
        try { Directory.Delete(folder, true); } catch (IOException) { }
    }

    private ProfileStore Profile(string? theme = null, string? brand = null)
    {
        var dir = Path.Combine(folder, "profile");
        Directory.CreateDirectory(dir);
        if (theme is not null) File.WriteAllText(Path.Combine(dir, "theme.json"), theme);
        if (brand is not null) File.WriteAllText(Path.Combine(dir, "brand.json"), brand);
        return new ProfileStore(new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?> { ["Hub:ProfileFolder"] = dir }).Build());
    }

    private static ProductLicence Licence(string? level) => new(() => new LicenceState
    {
        Status = LicenceStatus.Valid,
        Licence = new LicenceClaims { Modules = ["hub"], White = level is null ? null : new WhiteLabel { Level = level } },
    });

    private LocalThemeStore? shared;
    private LocalThemeStore Local => shared ??= LocalThemeStore.Over(app);
    private ThemeService Service(string? level, ProfileStore profile) => new(profile, Local, new BrandService(Licence(level)));

    [Fact]
    public void A_missing_or_damaged_profile_is_an_empty_one()
    {
        var none = new ProfileStore(new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?> { ["Hub:ProfileFolder"] = Path.Combine(folder, "nowhere") }).Build());
        Assert.True(none.Theme.IsEmpty);
        Assert.True(none.Brand.IsEmpty);
        var damaged = Profile("{ not json", "[1,2,3]");
        Assert.True(damaged.Theme.IsEmpty);
        Assert.True(damaged.Brand.IsEmpty);
    }

    [Fact]
    public void A_profile_file_that_is_far_too_big_is_not_read()
    {
        var profile = Profile(theme: "{\"density\":\"touch\"}" + new string(' ', 2_100_000));
        Assert.True(profile.Theme.IsEmpty);
    }

    [Fact]
    public void The_profile_shows_as_far_as_the_licence_allows_and_the_owners_choice_wins_field_by_field()
    {
        var profile = Profile("{\"density\":\"touch\",\"nav\":\"bottom\",\"shape\":\"pill\",\"font\":\"serif\"}");
        var fixedLook = Service("none", profile).Current;
        Assert.Equal(("touch", "bottom", "rounded", "system"), (fixedLook.Density, fixedLook.Nav, fixedLook.Shape, fixedLook.Font));
        var styled = Service("theme", profile);
        Assert.Equal(("touch", "bottom", "pill", "serif"), (styled.Current.Density, styled.Current.Nav, styled.Current.Shape, styled.Current.Font));
        Assert.True(styled.IdentityAllowed);
        Assert.False(Service(null, profile).IdentityAllowed);

        Local.Save(new ThemeSettings { Nav = "left", Shape = "square" }, null);
        var mine = styled.Current;
        Assert.Equal(("touch", "left", "square", "serif"), (mine.Density, mine.Nav, mine.Shape, mine.Font));
    }

    [Fact]
    public void What_the_owner_saves_is_kept_clean_survives_a_restart_and_is_written_in_the_activity_list()
    {
        var store = LocalThemeStore.Over(app);
        store.Save(new ThemeSettings { Density = "touch", Nav = "weird", FontScale = 1.12, Shape = "pill", Cart = "left" }, null);
        var again = LocalThemeStore.Over(HubApp.Open(path)).Current;
        Assert.Equal("touch", again.Density);
        Assert.Null(again.Nav);                         // a value that is not in the list is not kept
        Assert.Equal(1.1, again.FontScale!.Value, 6);   // rounded
        Assert.Equal("left", again.Cart);
        store.Reset(null);
        Assert.True(store.Current.IsEmpty);
        var log = app.Audit.Recent(10).Select(a => a.Detail).ToList();
        Assert.Contains("layout changed", log);
        Assert.Contains("standard layout restored", log);
    }

    [Fact]
    public void A_damaged_saved_layout_is_an_empty_one_never_an_error()
    {
        app.SettingsStore.SetText(LocalThemeStore.Key, "{ broken");
        Assert.True(LocalThemeStore.Over(app).Current.IsEmpty);
    }

    [Fact]
    public void The_brand_in_the_profile_is_read_but_only_the_licence_decides_if_it_shows()
    {
        var profile = Profile(brand: "{\"primaryColor\":\"#aa2233\",\"name\":\"Mine\"}");
        Assert.Equal("#aa2233", profile.Brand.PrimaryColor);
        var resolved = BrandPolicy.Resolve(BrandProfile.Default(), "none", profile.Brand);
        Assert.Equal("#0f6cbd", resolved.PrimaryColor);
    }
}

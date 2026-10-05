using NextGenOS.Hub.Web.Branding;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The "Look" page's rules: what the owner chose shows only as far as the licence allows, and a bad choice is refused in plain words.</summary>
public class LookTests : IDisposable
{
    // A real 1 x 1 PNG.
    private const string Png = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==";
    private readonly string path = Path.Combine(Path.GetTempPath(), "hub-look-" + Guid.NewGuid().ToString("N") + ".db");
    private readonly HubApp app;

    public LookTests() => app = HubApp.Open(path);

    public void Dispose()
    {
        foreach (var f in new[] { path, path + "-wal", path + "-shm" }) { try { File.Delete(f); } catch (IOException) { } }
    }

    private static ProductLicence Licence(string? level, string? brandName = "Luzon Fresh") => new(() => new LicenceState
    {
        Status = LicenceStatus.Valid,
        Licence = new LicenceClaims
        {
            Modules = ["hub"],
            White = level is null ? null : new WhiteLabel { Level = level },
            Brand = brandName is null ? null : new BrandProfile { Id = "B-7", Name = brandName, PrimaryColor = "#0f6cbd", PoweredBy = true },
        },
    });

    private BrandService Brand(string? level, LocalBrandStore store, string? brandName = "Luzon Fresh") => new(Licence(level, brandName), store);

    private static LocalBrand Chosen() => new() { Name = "Mine Mart", PrimaryColor = "#AA2233", AccentColor = "#336699", Logo = Png, SupportEmail = "me@mine.example", PoweredBy = false };

    [Theory]
    [InlineData(null)]
    [InlineData("none")]
    [InlineData("nonsense")]
    public void A_licence_with_a_fixed_look_keeps_its_look_whatever_was_saved(string? level)
    {
        var store = new LocalBrandStore(app);
        store.Save(Chosen(), null);
        var brand = Brand(level, store);
        Assert.Equal("none", brand.WhiteLevel);
        Assert.Equal("Luzon Fresh", brand.Name);
        Assert.Contains("#0f6cbd", brand.Style);
        Assert.DoesNotContain("aa2233", brand.Style);
        Assert.Null(brand.Logo);
        Assert.Equal("by NextGenOS", brand.By);
    }

    [Fact]
    public void A_theme_licence_shows_the_colours_logo_and_help_but_keeps_the_program_name()
    {
        var store = new LocalBrandStore(app);
        store.Save(Chosen(), null);
        var brand = Brand("theme", store);
        Assert.Equal("Luzon Fresh", brand.Name);
        Assert.Equal("by NextGenOS", brand.By);
        Assert.Contains("--accent:#aa2233", brand.Style);
        Assert.Equal(Png, brand.Logo);
        Assert.Equal("me@mine.example", brand.SupportEmail);
    }

    [Fact]
    public void A_full_licence_may_also_rename_the_program_and_drop_by_NextGenOS()
    {
        var store = new LocalBrandStore(app);
        store.Save(Chosen(), null);
        var brand = Brand("full", store);
        Assert.Equal("Mine Mart", brand.Name);
        Assert.Null(brand.By);
    }

    [Fact]
    public void With_no_licence_brand_a_theme_licence_still_takes_the_owners_colour()
    {
        var store = new LocalBrandStore(app);
        store.Save(new LocalBrand { PrimaryColor = "#aa2233" }, null);
        var brand = Brand("theme", store, brandName: null);
        Assert.Equal("Smart Retail POS", brand.Name);
        Assert.Contains("--accent:#aa2233", brand.Style);
        // and with nothing chosen, the standard look is not touched at all
        store.Reset(null);
        Assert.Equal(string.Empty, Brand("theme", store, brandName: null).Style);
    }

    [Fact]
    public void What_was_saved_is_still_there_after_a_restart_and_going_back_clears_it_and_is_written_in_the_activity_list()
    {
        var first = new LocalBrandStore(app);
        first.Save(Chosen(), null);
        var again = new LocalBrandStore(HubApp.Open(path));
        Assert.Equal("#aa2233", again.Current?.PrimaryColor);
        Assert.Equal("Mine Mart", again.Current?.Name);
        first.Reset(null);
        Assert.Null(first.Current?.PrimaryColor);
        var log = app.Audit.Recent(10).Select(a => a.Detail).ToList();
        Assert.Contains("look changed", log);
        Assert.Contains("standard look restored", log);
    }

    [Theory]
    [InlineData("red", "must look like")]
    [InlineData("#12345", "must look like")]
    [InlineData("#ffff00", "too light")]
    public void A_colour_that_is_not_a_colour_or_is_too_light_to_read_is_refused_in_words(string colour, string words)
    {
        var problem = LocalBrandStore.Check(new LocalBrand { PrimaryColor = colour });
        Assert.NotNull(problem);
        Assert.Contains(words, problem);
        Assert.Throws<HubException>(() => new LocalBrandStore(app).Save(new LocalBrand { AccentColor = colour }, null));
    }

    [Fact]
    public void A_logo_must_be_a_real_small_png_or_jpeg()
    {
        Assert.Null(LocalBrandStore.CheckPicture(Png));
        Assert.NotNull(LocalBrandStore.CheckPicture("data:image/svg+xml;base64," + Convert.ToBase64String("<svg xmlns='http://www.w3.org/2000/svg'><script>alert(1)</script></svg>"u8.ToArray())));
        Assert.NotNull(LocalBrandStore.CheckPicture("data:image/png;base64," + Convert.ToBase64String("not a picture at all"u8.ToArray())));
        Assert.NotNull(LocalBrandStore.CheckPicture("data:image/jpeg;base64," + Convert.ToBase64String(new byte[] { 0x89, 0x50, 0x4E, 0x47, 1, 2, 3, 4, 5, 6 })));
        Assert.NotNull(LocalBrandStore.CheckPicture("https://evil.example/logo.png"));
        var big = new byte[120_000]; big[0] = 0x89; big[1] = 0x50; big[2] = 0x4E; big[3] = 0x47;
        Assert.NotNull(LocalBrandStore.CheckPicture("data:image/png;base64," + Convert.ToBase64String(big)));

        Assert.Null(LocalBrandStore.FromBytes(new byte[] { 1, 2, 3 }, out var problem));
        Assert.Contains("PNG or JPEG", problem);
        var png = LocalBrandStore.FromBytes(Convert.FromBase64String(Png["data:image/png;base64,".Length..]), out problem);
        Assert.Null(problem);
        Assert.Equal(Png, png);
    }

    [Fact]
    public void A_damaged_saved_value_is_an_empty_look_never_an_error()
    {
        app.SettingsStore.SetText(LocalBrandStore.Key, "{ this is not json");
        var store = new LocalBrandStore(app);
        Assert.True(store.Current?.IsEmpty ?? true);
        Assert.Equal("Luzon Fresh", Brand("full", store).Name);
    }

    [Fact]
    public void Text_is_cleaned_before_it_is_kept()
    {
        var store = new LocalBrandStore(app);
        store.Save(new LocalBrand { Name = "  Mi\u0000ne\n  ", SupportEmail = "a@b.example\u0007" }, null);
        Assert.Equal("Mine", store.Current?.Name);
        Assert.Equal("a@b.example", store.Current?.SupportEmail);
        Assert.Throws<HubException>(() => store.Save(new LocalBrand { Name = new string('x', 61) }, null));
    }
}

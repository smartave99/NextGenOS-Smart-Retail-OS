using System.Text.RegularExpressions;
using NextGenOS.Hub.Web.Branding;
using NextGenOS.Licensing;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The two looks (decision 30): the list look for a PC or laptop and the counter look for a touch screen, made only of settings the theme already has.</summary>
public class ShopLookTests : IDisposable
{
    private readonly string path = Path.Combine(Path.GetTempPath(), "hub-shoplook-" + Guid.NewGuid().ToString("N") + ".db");
    private readonly HubApp app;

    public ShopLookTests() => app = HubApp.OpenTrusted(path);

    public void Dispose()
    {
        foreach (var f in new[] { path, path + "-wal", path + "-shm" }) { try { File.Delete(f); } catch (IOException) { } }
    }

    [Theory]
    [InlineData("top")]
    [InlineData("list")]
    [InlineData("counter")]
    public void Each_look_is_made_only_of_settings_the_theme_already_accepts(string id)
    {
        var look = ShopLooks.Get(id)!;
        Assert.Contains(look.Density, ThemePolicy.Densities);
        Assert.Contains(look.Nav, ThemePolicy.NavPositions);
        Assert.Contains(look.NavLabels, ThemePolicy.NavLabelModes);
        Assert.Contains(look.Cart, ThemePolicy.CartPositions);
        Assert.Equal(look.FontScale, ThemePolicy.Scale(look.FontScale));   // a size the policy keeps as it is
    }

    [Fact]
    public void The_two_looks_differ_the_way_the_owner_described()
    {
        // list look: a normal monitor, the menu along the top, the bill below the items; counter look: a touch screen, the menu on the left, the bill on the right, bigger buttons.
        Assert.Equal(("top", "bottom"), (ShopLooks.List.Nav, ShopLooks.List.Cart));
        Assert.Equal(("left", "right", "touch"), (ShopLooks.Counter.Nav, ShopLooks.Counter.Cart, ShopLooks.Counter.Density));
        Assert.NotEqual(ShopLooks.List.Density, ShopLooks.Counter.Density);
    }

    [Fact]
    public void The_starting_look_is_the_top_menu_one_with_big_buttons_and_the_owner_can_choose_another()
    {
        // the owner's choice of 9 October 2026: the horizontal bar, because many counters are touch screens
        Assert.Equal("top", ShopLooks.Default);
        Assert.Equal(("top", "touch", "right"), (ShopLooks.Top.Nav, ShopLooks.Top.Density, ShopLooks.Top.Cart));
        Assert.Equal("top", ShopLooks.Choices[0]);
        var store = ShopLookStore.Over(app);
        Assert.Null(store.Chosen);                                              // nobody has chosen
        Assert.Equal("top", store.Effective(profileLook: null, themeSetsLayout: false));
    }

    [Fact]
    public void A_shop_that_already_set_its_own_layout_keeps_it_and_a_profile_can_name_the_look_for_its_customer()
    {
        var store = ShopLookStore.Over(app);
        Assert.Equal("standard", store.Effective(null, themeSetsLayout: true));         // a layout was set before: the shop does not change under its owner
        Assert.Equal("list", store.Effective("list", themeSetsLayout: false));          // the customer's profile names the look
        Assert.Equal("list", store.Effective("list", themeSetsLayout: true));
        Assert.Equal("top", store.Effective("poster", themeSetsLayout: false));         // a word that is not a look is left out
        store.Save("counter", userId: null);
        Assert.Equal("counter", store.Effective("list", themeSetsLayout: false));       // the owner's choice wins over the profile
    }

    [Fact]
    public void A_look_chosen_for_the_shop_is_kept_and_a_wrong_one_means_the_standard_layout()
    {
        var store = ShopLookStore.Over(app);
        store.Save("counter", userId: null);
        Assert.Equal("counter", ShopLookStore.Over(app).Chosen);   // read again from the shop's own database
        store.Save("auto", userId: null);
        Assert.Equal("auto", store.Chosen);
        store.Save("top", userId: null);
        Assert.Equal("top", store.Chosen);
        store.Save("sideways", userId: null);
        Assert.Equal("standard", store.Chosen);
        Assert.Contains(app.Audit.Recent(20), e => e.Detail != null && e.Detail.Contains("look of the shop: counter"));
    }

    [Fact]
    public void A_look_saved_with_its_settings_comes_back_as_the_same_settings()
    {
        var local = LocalThemeStore.Over(app);
        var look = ShopLooks.Counter;
        local.Save(new ThemeSettings { Density = look.Density, Nav = look.Nav, NavLabels = look.NavLabels, Cart = look.Cart, FontScale = look.FontScale }, userId: null);
        var back = local.Current;
        Assert.Equal((look.Density, look.Nav, look.NavLabels, look.Cart, look.FontScale), (back.Density, back.Nav, back.NavLabels, back.Cart, back.FontScale));
    }

    [Theory]
    [InlineData("top")]
    [InlineData("list")]
    [InlineData("counter")]
    public void The_values_the_page_script_applies_are_the_same_as_the_looks_here(string id)
    {
        // wwwroot/theme.js applies a look before the first picture is drawn, so it carries its own copy of the values: this keeps the two equal.
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir is not null && !File.Exists(Path.Combine(dir.FullName, "src", "NextGenOS.Hub.Web", "wwwroot", "theme.js"))) dir = dir.Parent;
        Assert.NotNull(dir);
        var script = File.ReadAllText(Path.Combine(dir!.FullName, "src", "NextGenOS.Hub.Web", "wwwroot", "theme.js"));
        var m = Regex.Match(script, id + @": \{ density: '(?<d>\w+)', nav: '(?<n>\w+)', navLabels: '(?<l>\w+)', cart: '(?<c>\w+)', scale: '(?<s>[\d.]+)' \}");
        Assert.True(m.Success, "theme.js has no values for " + id);
        var look = ShopLooks.Get(id)!;
        Assert.Equal((look.Density, look.Nav, look.NavLabels, look.Cart), (m.Groups["d"].Value, m.Groups["n"].Value, m.Groups["l"].Value, m.Groups["c"].Value));
        Assert.Equal(look.FontScale.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), m.Groups["s"].Value);
    }
}

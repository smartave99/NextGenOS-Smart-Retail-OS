using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Branding;

/// <summary>The theme the screens wear: the profile's and the owner's choices put together as far as the licence's white-label level allows.</summary>
public sealed class ThemeService(ProfileStore profile, LocalThemeStore local, BrandService brand)
{
    /// <summary>The theme to show. The owner's local choices are only looked up when a licence is in use (so no database is touched without one).</summary>
    public ThemeSettings Current => ThemePolicy.Resolve(brand.WhiteLevel, profile.Theme, local.Current);

    /// <summary>True when the customer's profile or this shop's own saved layout names any of the layout settings (button size, menu place, bill place, text size). A shop that has none takes the starting look; a shop that has some keeps them.</summary>
    public bool SetsLayout => Sets(profile.Theme) || Sets(local.Current);

    private static bool Sets(ThemeSettings t) => t.Density is not null || t.Nav is not null || t.NavLabels is not null || t.Cart is not null || t.FontScale is not null;

    /// <summary>The look the shop has now: what the owner chose, else what the profile names, else the starting look (or the saved layout when one is set).</summary>
    public string ShopLook(ShopLookStore store) => store.Effective(profile.Look, SetsLayout);

    /// <summary>The theme to show with only what the licence's level lets the owner decide marked as such: used by the Look page.</summary>
    public bool IdentityAllowed => brand.WhiteLevel is "theme" or "full";
}

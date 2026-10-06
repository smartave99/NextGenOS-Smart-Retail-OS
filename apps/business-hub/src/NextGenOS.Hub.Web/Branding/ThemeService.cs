using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Branding;

/// <summary>The theme the screens wear: the profile's and the owner's choices put together as far as the licence's white-label level allows.</summary>
public sealed class ThemeService(ProfileStore profile, LocalThemeStore local, BrandService brand)
{
    /// <summary>The theme to show. The owner's local choices are only looked up when a licence is in use (so no database is touched without one).</summary>
    public ThemeSettings Current => ThemePolicy.Resolve(brand.WhiteLevel, profile.Theme, local.Current);

    /// <summary>The theme to show with only what the licence's level lets the owner decide marked as such: used by the Look page.</summary>
    public bool IdentityAllowed => brand.WhiteLevel is "theme" or "full";
}

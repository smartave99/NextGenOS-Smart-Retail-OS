using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Branding;

/// <summary>
/// What the brand looks up when it needs the person's choices: the customer's profile (<c>profile/brand.json</c>, put there by NextGenOS) with what the owner chose on this PC
/// on top. It is still only a choice: the licence's white-label level decides how much of it shows (<see cref="BrandPolicy"/>), so a fixed-look licence ignores both.
/// </summary>
public sealed class ProfiledBrand(ProfileStore profile, LocalBrandStore owner) : IBrandOverrides
{
    public LocalBrand? Current => Merge(profile.Brand, owner.Current);

    /// <summary>The owner's values over the profile's; null when neither has anything.</summary>
    public static LocalBrand? Merge(LocalBrand? fromProfile, LocalBrand? fromOwner)
    {
        if ((fromProfile is null || fromProfile.IsEmpty) && (fromOwner is null || fromOwner.IsEmpty)) return null;
        if (fromProfile is null || fromProfile.IsEmpty) return fromOwner;
        if (fromOwner is null || fromOwner.IsEmpty) return fromProfile;
        string? Pick(string? mine, string? theirs) => string.IsNullOrEmpty(mine) ? theirs : mine;
        return new LocalBrand
        {
            Name = Pick(fromOwner.Name, fromProfile.Name), ShortName = Pick(fromOwner.ShortName, fromProfile.ShortName),
            PrimaryColor = Pick(fromOwner.PrimaryColor, fromProfile.PrimaryColor), AccentColor = Pick(fromOwner.AccentColor, fromProfile.AccentColor),
            Logo = Pick(fromOwner.Logo, fromProfile.Logo), SupportEmail = Pick(fromOwner.SupportEmail, fromProfile.SupportEmail),
            SupportPhone = Pick(fromOwner.SupportPhone, fromProfile.SupportPhone), PoweredBy = fromOwner.PoweredBy ?? fromProfile.PoweredBy,
        };
    }
}

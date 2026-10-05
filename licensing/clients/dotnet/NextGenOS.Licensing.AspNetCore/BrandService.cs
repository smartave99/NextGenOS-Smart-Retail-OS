using System.Text.RegularExpressions;
using NextGenOS.Licensing;

namespace NextGenOS.Licensing.AspNetCore;

/// <summary>What a person chose to change about the look on this PC (spec section 5.2); null when nothing was. A program that lets people choose gives this.</summary>
public interface IBrandOverrides
{
    LocalBrand? Current { get; }
}

/// <summary>
/// The name and colours the program shows: those of the licence's brand (a reseller or a customer with white label), or
/// NextGenOS's own Smart Retail POS when the licence has none, with what the person chose on this PC on top as far as the licence's
/// white-label level allows (<see cref="BrandPolicy"/>). Colours are checked as plain hex before they reach the page.
/// </summary>
public sealed partial class BrandService(ProductLicence licence, IBrandOverrides? local = null)
{
    public const string DefaultName = "Smart Retail POS";

    // The person's own choices are looked up only when the licence lets them change anything: a program with no licence, or a fixed look, never touches
    // wherever they are kept (so the "licence needed" page does not depend on a database being there).
    private BrandProfile Brand
    {
        get
        {
            var level = WhiteLevel;
            return BrandPolicy.Resolve(licence.State.Brand, level, level == "none" ? null : local?.Current);
        }
    }

    /// <summary>What the licence lets the person change on their own: "none", "theme" or "full" (spec section 5.1).</summary>
    public string WhiteLevel => licence.State.Licence?.White?.Level is "theme" or "full" ? licence.State.Licence.White.Level : "none";

    /// <summary>The logo, a small picture as a data address, or nothing.</summary>
    public string? Logo => BrandPolicy.ValidLogo(Brand.Logo);

    /// <summary>The name of the product as the customer knows it.</summary>
    public string Name => Clean(Brand.Name, 60) is { Length: > 0 } name ? name : DefaultName;

    /// <summary>"by NextGenOS" under the name, or nothing when the brand is the reseller's own and does not say so.</summary>
    public string? By => Brand.PoweredBy || Brand.Id == "B-0" || string.IsNullOrEmpty(Brand.Name) ? "by NextGenOS" : null;

    public string? SupportEmail => Clean(Brand.SupportEmail, 120) is { Length: > 0 } email ? email : null;

    public string? SupportPhone => Clean(Brand.SupportPhone, 40) is { Length: > 0 } phone ? phone : null;

    /// <summary>True when the licence brings its own colour: the default look is not touched otherwise.</summary>
    public bool HasOwnColour => Hex(Brand.PrimaryColor) is not null
        && (licence.State.Licence?.Brand is { Name.Length: > 0 } || !string.Equals(Brand.PrimaryColor, licence.State.Brand.PrimaryColor, StringComparison.OrdinalIgnoreCase));

    private const string Template = """
    :root{--accent:@@C@@;--accent-hover:color-mix(in srgb,@@C@@ 88%,white);--accent-ink:color-mix(in srgb,@@C@@ 85%,black);--accent-soft:color-mix(in srgb,@@C@@ 12%,transparent);--accent-softer:color-mix(in srgb,@@C@@ 7%,transparent);--bar-now:@@C@@;--bar:color-mix(in srgb,@@C@@ 45%,white);--focus:0 0 0 3.5px color-mix(in srgb,@@C@@ 30%,transparent)}
    @media (prefers-color-scheme:dark){:root:not([data-theme="light"]){--accent:color-mix(in srgb,@@C@@ 82%,white);--accent-ink:color-mix(in srgb,@@C@@ 65%,white);--accent-soft:color-mix(in srgb,@@C@@ 22%,transparent);--bar:color-mix(in srgb,@@C@@ 55%,black)}}
    :root[data-theme="dark"]{--accent:color-mix(in srgb,@@C@@ 82%,white);--accent-ink:color-mix(in srgb,@@C@@ 65%,white);--accent-soft:color-mix(in srgb,@@C@@ 22%,transparent);--bar:color-mix(in srgb,@@C@@ 55%,black)}
""";

    /// <summary>CSS for the head of the page: the brand colour in place of the default accent. Empty with no brand colour.</summary>
    public string Style
    {
        get
        {
            var colour = HasOwnColour ? Hex(Brand.PrimaryColor) : null;
            if (colour is null)
            {
                return string.Empty;
            }

            return Template.Replace("@@C@@", colour);
        }
    }

    /// <summary>"#rrggbb" or nothing: nothing else is ever put in the page's style.</summary>
    public static string? Hex(string? value) => value is not null && HexColour().IsMatch(value) ? value.ToLowerInvariant() : null;

    private static string Clean(string? text, int max)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        var trimmed = new string(text.Where(c => !char.IsControl(c)).ToArray()).Trim();
        return trimmed.Length <= max ? trimmed : trimmed[..max];
    }

    [GeneratedRegex("^#[0-9a-fA-F]{6}$")]
    private static partial Regex HexColour();
}

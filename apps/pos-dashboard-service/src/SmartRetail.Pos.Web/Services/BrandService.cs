using System.Text.RegularExpressions;
using NextGenOS.Licensing;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The name and colours the dashboard shows: those of the licence's brand (a reseller or a customer with white label), or
/// NextGenOS's own Smart Retail POS when the licence has none. Colours are checked as plain hex before they reach the page.
/// </summary>
public sealed partial class BrandService(DashboardLicence licence)
{
    public const string DefaultName = "Smart Retail POS";

    private BrandProfile Brand => licence.State.Brand;

    /// <summary>The name of the product as the customer knows it.</summary>
    public string Name => Clean(Brand.Name, 60) is { Length: > 0 } name ? name : DefaultName;

    /// <summary>"by NextGenOS" under the name, or nothing when the brand is the reseller's own and does not say so.</summary>
    public string? By => Brand.PoweredBy || Brand.Id == "B-0" || string.IsNullOrEmpty(Brand.Name) ? "by NextGenOS" : null;

    public string? SupportEmail => Clean(Brand.SupportEmail, 120) is { Length: > 0 } email ? email : null;

    public string? SupportPhone => Clean(Brand.SupportPhone, 40) is { Length: > 0 } phone ? phone : null;

    /// <summary>True when the licence brings its own colour: the default look is not touched otherwise.</summary>
    public bool HasOwnColour => Hex(Brand.PrimaryColor) is not null && licence.State.Licence?.Brand is { Name.Length: > 0 };

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

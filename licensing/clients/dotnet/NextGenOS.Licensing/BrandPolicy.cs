using System;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NextGenOS.Licensing
{
    /// <summary>
    /// What a person chose on their own PC to change about the look: the values of spec section 5.2. Every field may be missing. A file that is not
    /// understood gives an empty local brand: a bad file must never stop a shop from working.
    /// </summary>
    public sealed class LocalBrand
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PrimaryColor { get; set; }
        public string AccentColor { get; set; }
        public string Logo { get; set; }
        public string SupportEmail { get; set; }
        public string SupportPhone { get; set; }
        public bool? PoweredBy { get; set; }

        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(ShortName) && string.IsNullOrEmpty(PrimaryColor) && string.IsNullOrEmpty(AccentColor) &&
                       string.IsNullOrEmpty(Logo) && string.IsNullOrEmpty(SupportEmail) && string.IsNullOrEmpty(SupportPhone) && PoweredBy == null;
            }
        }

        /// <summary>Reads the text a local brand was saved as. Anything unreadable, or of the wrong kind, is left out; never an exception.</summary>
        public static LocalBrand Parse(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return new LocalBrand();
            try { return FromToken(JToken.Parse(json)); }
            catch (Exception) { return new LocalBrand(); }
        }

        public static LocalBrand FromToken(JToken token)
        {
            var o = token as JObject;
            if (o == null) return new LocalBrand();
            return new LocalBrand
            {
                Name = Text(o, "name"), ShortName = Text(o, "shortName"), PrimaryColor = Text(o, "primaryColor"), AccentColor = Text(o, "accentColor"),
                Logo = Text(o, "logo"), SupportEmail = Text(o, "supportEmail"), SupportPhone = Text(o, "supportPhone"),
                PoweredBy = o["poweredBy"] != null && o["poweredBy"].Type == JTokenType.Boolean ? (bool?)o["poweredBy"].Value<bool>() : null,
            };
        }

        private static string Text(JObject o, string name)
        {
            var t = o[name];
            return t != null && t.Type == JTokenType.String ? t.Value<string>() : null;
        }

        public string ToJson()
        {
            var o = new JObject();
            if (!string.IsNullOrEmpty(Name)) o["name"] = Name;
            if (!string.IsNullOrEmpty(ShortName)) o["shortName"] = ShortName;
            if (!string.IsNullOrEmpty(PrimaryColor)) o["primaryColor"] = PrimaryColor;
            if (!string.IsNullOrEmpty(AccentColor)) o["accentColor"] = AccentColor;
            if (!string.IsNullOrEmpty(Logo)) o["logo"] = Logo;
            if (!string.IsNullOrEmpty(SupportEmail)) o["supportEmail"] = SupportEmail;
            if (!string.IsNullOrEmpty(SupportPhone)) o["supportPhone"] = SupportPhone;
            if (PoweredBy != null) o["poweredBy"] = PoweredBy.Value;
            return o.ToString(Formatting.None);
        }
    }

    /// <summary>
    /// How a local brand is put on top of the licence's brand, as far as the licence's white-label level allows (spec section 5.2). Pure: no files, no
    /// network. The TypeScript library follows the same rules and both pass licensing/testvectors/brand-policy.json.
    /// </summary>
    public static class BrandPolicy
    {
        public const int MaxLogoLength = 140000;
        public const double MinContrastWithWhite = 3.0;

        private static readonly Regex Hex = new Regex("^#[0-9a-fA-F]{6}$", RegexOptions.CultureInvariant);
        private static readonly Regex LogoUri = new Regex("^data:image/(png|jpeg|svg\\+xml);base64,[A-Za-z0-9+/=]+$", RegexOptions.CultureInvariant);

        /// <summary>The licence's brand (or NextGenOS's own) with the local brand applied as far as <paramref name="level"/> allows.</summary>
        public static BrandProfile Resolve(BrandProfile licence, string level, LocalBrand local)
        {
            var b = licence ?? BrandProfile.Default();
            var result = new BrandProfile
            {
                Id = b.Id, Name = b.Name, ShortName = b.ShortName, LegalName = b.LegalName, PrimaryColor = b.PrimaryColor, AccentColor = b.AccentColor,
                SupportEmail = b.SupportEmail, SupportPhone = b.SupportPhone, SupportUrl = b.SupportUrl, WebsiteUrl = b.WebsiteUrl, Copyright = b.Copyright,
                Logo = b.Logo, PoweredBy = b.PoweredBy,
            };
            if (local == null || (level != "theme" && level != "full")) return result;

            var colour = UsableColour(local.PrimaryColor); if (colour != null) result.PrimaryColor = colour;
            colour = UsableColour(local.AccentColor); if (colour != null) result.AccentColor = colour;
            var logo = ValidLogo(local.Logo); if (logo != null) result.Logo = logo;
            var email = CleanText(local.SupportEmail, 120); if (email.Length > 0) result.SupportEmail = email;
            var phone = CleanText(local.SupportPhone, 40); if (phone.Length > 0) result.SupportPhone = phone;

            if (level == "full")
            {
                var name = CleanText(local.Name, 60); if (name.Length > 0) result.Name = name;
                var shortName = CleanText(local.ShortName, 60); if (shortName.Length > 0) result.ShortName = shortName;
                if (local.PoweredBy != null) result.PoweredBy = local.PoweredBy.Value;
            }
            return result;
        }

        /// <summary>"#rrggbb" in lower case when the value is a hex colour that white text can be read on; otherwise null.</summary>
        public static string UsableColour(string value)
        {
            if (value == null || !Hex.IsMatch(value)) return null;
            return ContrastWithWhite(value) >= MinContrastWithWhite ? value.ToLowerInvariant() : null;
        }

        /// <summary>The value when it is a small PNG, JPEG or SVG picture as a data URI; otherwise null.</summary>
        public static string ValidLogo(string value)
        {
            return value != null && value.Length <= MaxLogoLength && LogoUri.IsMatch(value) ? value : null;
        }

        /// <summary>Control characters removed, trimmed, cut to <paramref name="max"/> characters. Never null.</summary>
        public static string CleanText(string text, int max)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var trimmed = new string(text.Where(c => !char.IsControl(c)).ToArray()).Trim();
            return trimmed.Length <= max ? trimmed : trimmed.Substring(0, max);
        }

        /// <summary>WCAG contrast ratio of a "#rrggbb" colour with white (1 to 21).</summary>
        public static double ContrastWithWhite(string hex)
        {
            double Channel(int from)
            {
                var c = Convert.ToInt32(hex.Substring(from, 2), 16) / 255.0;
                return c <= 0.04045 ? c / 12.92 : Math.Pow((c + 0.055) / 1.055, 2.4);
            }
            var luminance = 0.2126 * Channel(1) + 0.7152 * Channel(3) + 0.0722 * Channel(5);
            return 1.05 / (luminance + 0.05);
        }
    }
}

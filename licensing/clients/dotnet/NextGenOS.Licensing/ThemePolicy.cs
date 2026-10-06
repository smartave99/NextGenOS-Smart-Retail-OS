using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NextGenOS.Licensing
{
    /// <summary>
    /// A theme: the named choices that decide how a program looks and is laid out (spec section 5.3). Every field may be missing. A file that is not understood gives an
    /// empty theme: a bad file must never stop a shop from working.
    /// </summary>
    public sealed class ThemeSettings
    {
        public string Mode { get; set; }
        public string Surface { get; set; }
        public string Shape { get; set; }
        public string Density { get; set; }
        public string Font { get; set; }
        public double? FontScale { get; set; }
        public string Nav { get; set; }
        public string NavLabels { get; set; }
        public string Cart { get; set; }
        public string Depth { get; set; }

        public bool IsEmpty
        {
            get
            {
                return Mode == null && Surface == null && Shape == null && Density == null && Font == null && FontScale == null && Nav == null && NavLabels == null && Cart == null && Depth == null;
            }
        }

        /// <summary>Reads the text a theme was saved as. Anything unreadable, or of the wrong kind, is left out; never an exception.</summary>
        public static ThemeSettings Parse(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return new ThemeSettings();
            try { return FromToken(JToken.Parse(json)); }
            catch (Exception) { return new ThemeSettings(); }
        }

        public static ThemeSettings FromToken(JToken token)
        {
            var o = token as JObject;
            if (o == null) return new ThemeSettings();
            var t = new ThemeSettings
            {
                Mode = Text(o, "mode"), Surface = Text(o, "surface"), Shape = Text(o, "shape"), Density = Text(o, "density"), Font = Text(o, "font"),
                Nav = Text(o, "nav"), NavLabels = Text(o, "navLabels"), Cart = Text(o, "cart"), Depth = Text(o, "depth"),
            };
            var scale = o["fontScale"];
            if (scale != null && (scale.Type == JTokenType.Float || scale.Type == JTokenType.Integer)) t.FontScale = scale.Value<double>();
            return t;
        }

        private static string Text(JObject o, string name)
        {
            var t = o[name];
            return t != null && t.Type == JTokenType.String ? t.Value<string>() : null;
        }

        public string ToJson()
        {
            var o = new JObject();
            if (Mode != null) o["mode"] = Mode;
            if (Surface != null) o["surface"] = Surface;
            if (Shape != null) o["shape"] = Shape;
            if (Density != null) o["density"] = Density;
            if (Font != null) o["font"] = Font;
            if (FontScale != null) o["fontScale"] = FontScale.Value;
            if (Nav != null) o["nav"] = Nav;
            if (NavLabels != null) o["navLabels"] = NavLabels;
            if (Cart != null) o["cart"] = Cart;
            if (Depth != null) o["depth"] = Depth;
            return o.ToString(Formatting.None);
        }
    }

    /// <summary>
    /// How a theme from the profile and a theme chosen on this PC are put together for a licence's white-label level (spec section 5.3). Pure: no files, no network.
    /// The JavaScript twin (the Setup Studio) follows the same rules and both pass licensing/testvectors/theme-policy.json.
    /// </summary>
    public static class ThemePolicy
    {
        public const double MinFontScale = 0.85;
        public const double MaxFontScale = 1.35;

        public static readonly string[] Densities = { "compact", "comfortable", "touch" };
        public static readonly string[] NavPositions = { "left", "top", "bottom" };
        public static readonly string[] NavLabelModes = { "full", "icons" };
        public static readonly string[] CartPositions = { "right", "left", "bottom" };
        public static readonly string[] Modes = { "auto", "light", "dark" };
        public static readonly string[] Surfaces = { "neutral", "warm", "cool", "paper" };
        public static readonly string[] Shapes = { "square", "soft", "rounded", "pill" };
        public static readonly string[] Fonts = { "system", "humanist", "serif", "rounded", "mono" };
        public static readonly string[] Depths = { "flat", "soft", "lifted" };

        public static ThemeSettings Defaults()
        {
            return new ThemeSettings { Mode = "auto", Surface = "neutral", Shape = "rounded", Density = "comfortable", Font = "system", FontScale = 1, Nav = "left", NavLabels = "full", Cart = "right", Depth = "soft" };
        }

        /// <summary>The theme to show: the defaults, then the profile, then the local choice, each token only when it is valid and the level allows it.</summary>
        public static ThemeSettings Resolve(string level, ThemeSettings profile, ThemeSettings local)
        {
            var result = Defaults();
            var identity = level == "theme" || level == "full";
            foreach (var source in new[] { profile, local })
            {
                if (source == null) continue;
                result.Density = Pick(source.Density, Densities, result.Density);
                result.Nav = Pick(source.Nav, NavPositions, result.Nav);
                result.NavLabels = Pick(source.NavLabels, NavLabelModes, result.NavLabels);
                result.Cart = Pick(source.Cart, CartPositions, result.Cart);
                var scale = Scale(source.FontScale);
                if (scale != null) result.FontScale = scale;
                if (!identity) continue;
                result.Mode = Pick(source.Mode, Modes, result.Mode);
                result.Surface = Pick(source.Surface, Surfaces, result.Surface);
                result.Shape = Pick(source.Shape, Shapes, result.Shape);
                result.Font = Pick(source.Font, Fonts, result.Font);
                result.Depth = Pick(source.Depth, Depths, result.Depth);
            }
            return result;
        }

        private static string Pick(string value, string[] allowed, string current)
        {
            return value != null && Array.IndexOf(allowed, value) >= 0 ? value : current;
        }

        /// <summary>A font scale inside 0.85 to 1.35, rounded to the nearest 0.05 (half up); otherwise null.</summary>
        public static double? Scale(double? value)
        {
            if (value == null || double.IsNaN(value.Value) || double.IsInfinity(value.Value) || value.Value < MinFontScale || value.Value > MaxFontScale) return null;
            return Math.Floor(value.Value * 20 + 0.5) / 20;
        }
    }
}

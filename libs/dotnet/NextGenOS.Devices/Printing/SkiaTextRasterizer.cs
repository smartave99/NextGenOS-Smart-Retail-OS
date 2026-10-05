using SkiaSharp;

namespace NextGenOS.Devices.Printing;

/// <summary>
/// Draws text as a black-and-white picture with the fonts of this PC, so any language the PC can show can be printed on a receipt printer
/// that has no character set for it (Russian, Greek, Chinese, Japanese, Korean and more). Letters that need shaping (Hindi, Arabic, Thai) are drawn one by one without it.
/// </summary>
public sealed class SkiaTextRasterizer : ITextRasterizer
{
    private const float BasePixels = 24;

    public BitmapElement Render(string text, int widthDots, int size, bool bold, Align align)
    {
        widthDots = Math.Max(8, widthDots / 8 * 8);
        var pixels = BasePixels * Math.Clamp(size, 1, 4);
        var runs = new List<(string Text, SKTypeface Face, float Width)>();
        foreach (var group in Runs(text, bold))
        {
            using var f = new SKFont(group.Face, pixels);
            runs.Add((group.Text, group.Face, f.MeasureText(group.Text)));
        }
        var total = runs.Sum(r => r.Width);
        var lineHeight = (int)Math.Ceiling(pixels * 1.25f);
        using var bitmap = new SKBitmap(widthDots, lineHeight, SKColorType.Gray8, SKAlphaType.Opaque);
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(SKColors.White);
        var x = align switch { Align.Center => Math.Max(0, (widthDots - total) / 2), Align.Right => Math.Max(0, widthDots - total), _ => 0f };
        foreach (var run in runs)
        {
            using var f = new SKFont(run.Face, pixels) { Subpixel = false, Edging = SKFontEdging.Alias, Embolden = bold };
            using var paint = new SKPaint { Color = SKColors.Black, IsAntialias = false };
            canvas.DrawText(run.Text, x, pixels, SKTextAlign.Left, f, paint);
            x += run.Width;
        }
        return ToBits(bitmap, widthDots, lineHeight);
    }

    // ---- fonts ------------------------------------------------------------------------------------------------------------------

    private static readonly object Gate = new();
    private static List<(SKTypeface Face, SKFont Probe, bool Bold)>? _files;
    private static readonly Dictionary<(int, bool), SKTypeface> Chosen = new();

    private static readonly string[] FontFolders =
    {
        @"C:\Windows\Fonts", "/System/Library/Fonts", "/Library/Fonts", "/usr/share/fonts", "/usr/local/share/fonts",
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".fonts"),
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".local", "share", "fonts"),
    };

    /// <summary>The typeface that can draw a letter: the system's own matching first, then font files found on this PC (Linux builds of SkiaSharp cannot see the system fonts by themselves).</summary>
    private static SKTypeface Pick(int codePoint, bool bold)
    {
        lock (Gate)
        {
            if (Chosen.TryGetValue((codePoint, bold), out var known)) return known;
            var style = bold ? SKFontStyle.Bold : SKFontStyle.Normal;
            SKTypeface? found = null;
            var system = SKFontManager.Default.MatchCharacter(null, style, null, codePoint);
            if (system is not null)
            {
                using var probe = new SKFont(system, BasePixels);
                if (probe.ContainsGlyph(codePoint)) found = system;
            }
            if (found is null)
            {
                _files ??= LoadFiles();
                var candidates = _files.Where(f => f.Probe.ContainsGlyph(codePoint)).ToList();
                found = (candidates.FirstOrDefault(f => f.Bold == bold).Face ?? candidates.FirstOrDefault().Face);
            }
            found ??= SKTypeface.Default;
            Chosen[(codePoint, bold)] = found;
            return found;
        }
    }

    private static List<(SKTypeface, SKFont, bool)> LoadFiles()
    {
        var list = new List<(SKTypeface, SKFont, bool)>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var folder in FontFolders.Where(Directory.Exists))
        {
            IEnumerable<string> files;
            try { files = Directory.EnumerateFiles(folder, "*.*", new EnumerationOptions { RecurseSubdirectories = true, IgnoreInaccessible = true, MaxRecursionDepth = 4 }).Where(f => f.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".otf", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".ttc", StringComparison.OrdinalIgnoreCase)); }
            catch (Exception) { continue; }
            // Plain, well-covered families first so Latin text looks ordinary; the rest fill in other scripts.
            foreach (var file in files.OrderBy(f => Rank(Path.GetFileName(f))).ThenBy(f => f, StringComparer.Ordinal).Take(400))
            {
                if (!seen.Add(Path.GetFileName(file))) continue;
                try
                {
                    var face = SKTypeface.FromFile(file);
                    if (face is null) continue;
                    list.Add((face, new SKFont(face, BasePixels), file.Contains("Bold", StringComparison.OrdinalIgnoreCase) && !file.Contains("Oblique", StringComparison.OrdinalIgnoreCase) && !file.Contains("Italic", StringComparison.OrdinalIgnoreCase)));
                }
                catch (Exception) { /* a font that cannot be read is left out */ }
            }
        }
        return list;
    }

    private static int Rank(string name) =>
        name.StartsWith("DejaVuSans.", StringComparison.OrdinalIgnoreCase) || name.StartsWith("DejaVuSans-Bold.", StringComparison.OrdinalIgnoreCase) || name.StartsWith("Arial.", StringComparison.OrdinalIgnoreCase) || name.StartsWith("arialbd.", StringComparison.OrdinalIgnoreCase) ? 0
        : name.Contains("Noto", StringComparison.OrdinalIgnoreCase) || name.Contains("FreeSans", StringComparison.OrdinalIgnoreCase) || name.Contains("segoeui", StringComparison.OrdinalIgnoreCase) ? 1
        : name.Contains("Mono", StringComparison.OrdinalIgnoreCase) || name.Contains("Serif", StringComparison.OrdinalIgnoreCase) ? 3 : 2;

    private static IEnumerable<(string Text, SKTypeface Face)> Runs(string text, bool bold)
    {
        var current = new System.Text.StringBuilder();
        SKTypeface? face = null;
        foreach (var rune in text.EnumerateRunes())
        {
            var use = Pick(rune.Value is ' ' ? 'A' : rune.Value, bold);
            if (face is not null && !ReferenceEquals(face, use) && current.Length > 0)
            {
                yield return (current.ToString(), face);
                current.Clear();
            }
            face = use;
            current.Append(rune.ToString());
        }
        if (face is not null && current.Length > 0) yield return (current.ToString(), face);
    }

    private static BitmapElement ToBits(SKBitmap gray, int width, int height)
    {
        var rowBytes = width / 8;
        var bits = new byte[rowBytes * height];
        var pixels = gray.GetPixelSpan();
        for (var y = 0; y < height; y++)
            for (var x = 0; x < width; x++)
                if (pixels[y * gray.RowBytes + x] < 140) bits[y * rowBytes + x / 8] |= (byte)(0x80 >> (x % 8));
        return new BitmapElement(width, height, bits);
    }
}

using SkiaSharp;

namespace SmartRetail.Pos.Vision;

/// <summary>
/// The colours in the middle of a picture, where the product usually is: a histogram of hue (8), saturation (3) and
/// value (3), with greys by lightness (4), square-rooted and made unit length. DINOv2 goes mostly by shape, so two
/// bottles of the same shape look alike to it whatever their colour; this tells them apart.
/// </summary>
public static class ColourHistogram
{
    public const int Length = 8 * 3 * 3 + 4;

    public static float[] Of(VisionImage image)
    {
        ArgumentNullException.ThrowIfNull(image);
        var counts = new float[Length];
        int left = image.Width / 5, right = image.Width - image.Width / 5;
        int top = image.Height / 5, bottom = image.Height - image.Height / 5;
        var step = Math.Max(1, Math.Min(right - left, bottom - top) / 150);
        for (var y = top; y < bottom; y += step)
        {
            for (var x = left; x < right; x += step)
            {
                var at = (y * image.Width + x) * 4;
                counts[Bin(image.Rgba[at], image.Rgba[at + 1], image.Rgba[at + 2])]++;
            }
        }

        return VectorMath.Normalize(counts.Select(MathF.Sqrt).ToArray());
    }

    internal static int Bin(byte r, byte g, byte b)
    {
        new SKColor(r, g, b).ToHsv(out var hue, out var saturation, out var value);
        if (saturation < 15 || value < 15)
        {
            return 72 + Math.Min(3, (int)(value / 25.01f));
        }

        return ((int)(hue / 45f) % 8) * 9 + Math.Min(2, (int)(saturation / 33.4f)) * 3 + Math.Min(2, (int)(value / 33.4f));
    }
}

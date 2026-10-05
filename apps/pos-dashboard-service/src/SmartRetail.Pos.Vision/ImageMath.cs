using SkiaSharp;

namespace SmartRetail.Pos.Vision;

/// <summary>Pixel work: turning a photo the right way up, and preparing it for the model.</summary>
public static class ImageMath
{
    /// <summary>The model's input: a square of this many pixels a side.</summary>
    public const int InputSize = 224;

    /// <summary>The shortest side is first made this long, then the middle square is taken (as DINOv2 was trained).</summary>
    public const int ResizeTo = 256;

    private static readonly float[] Mean = { 0.485f, 0.456f, 0.406f };
    private static readonly float[] Std = { 0.229f, 0.224f, 0.225f };

    /// <summary>
    /// Turns RGBA pixels as an EXIF orientation (1 to 8) says: 2 mirrored, 3 upside down, 4 flipped, 5 transposed,
    /// 6 turned a quarter clockwise (a phone held upright), 7 transversed, 8 a quarter anticlockwise. Other values leave
    /// it as it is.
    /// </summary>
    public static byte[] Orient(byte[] rgba, int width, int height, int orientation, out int newWidth, out int newHeight)
    {
        ArgumentNullException.ThrowIfNull(rgba);
        var swap = orientation is >= 5 and <= 8;
        newWidth = swap ? height : width;
        newHeight = swap ? width : height;
        if (orientation is < 2 or > 8)
        {
            return rgba;
        }

        var turned = new byte[rgba.Length];
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var (tx, ty) = orientation switch
                {
                    2 => (width - 1 - x, y),
                    3 => (width - 1 - x, height - 1 - y),
                    4 => (x, height - 1 - y),
                    5 => (y, x),
                    6 => (height - 1 - y, x),
                    7 => (height - 1 - y, width - 1 - x),
                    _ => (y, width - 1 - x),
                };
                Buffer.BlockCopy(rgba, (y * width + x) * 4, turned, (ty * newWidth + tx) * 4, 4);
            }
        }

        return turned;
    }

    /// <summary>
    /// The model's input for a picture, as DINOv2's own image processor makes it: the shortest side made 256 pixels
    /// (bicubic), the middle 224 x 224 taken, and each colour scaled to 0–1 and normalised with ImageNet's mean and
    /// spread. Channels first: all red, then green, then blue.
    /// </summary>
    public static float[] Preprocess(VisionImage image)
    {
        ArgumentNullException.ThrowIfNull(image);
        var scale = (double)ResizeTo / Math.Min(image.Width, image.Height);
        var width = Math.Max(InputSize, (int)Math.Round(image.Width * scale));
        var height = Math.Max(InputSize, (int)Math.Round(image.Height * scale));
        var pixels = Resize(image, width, height);

        var left = (width - InputSize) / 2;
        var top = (height - InputSize) / 2;
        var plane = InputSize * InputSize;
        var input = new float[3 * plane];
        for (var y = 0; y < InputSize; y++)
        {
            for (var x = 0; x < InputSize; x++)
            {
                var at = ((top + y) * width + left + x) * 4;
                var to = y * InputSize + x;
                for (var c = 0; c < 3; c++)
                {
                    input[c * plane + to] = (pixels[at + c] / 255f - Mean[c]) / Std[c];
                }
            }
        }

        return input;
    }

    /// <summary>The picture at another size (bicubic, Catmull-Rom), as RGBA bytes.</summary>
    internal static byte[] Resize(VisionImage image, int width, int height)
    {
        if (width == image.Width && height == image.Height)
        {
            return image.Rgba;
        }

        using var source = FromPixels(image);
        using var resized = source.Resize(new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Unpremul), new SKSamplingOptions(SKCubicResampler.CatmullRom))
            ?? throw new InvalidOperationException("The picture could not be resized.");
        return PixelsOf(resized);
    }

    internal static SKBitmap FromPixels(VisionImage image)
    {
        var bitmap = new SKBitmap(new SKImageInfo(image.Width, image.Height, SKColorType.Rgba8888, SKAlphaType.Unpremul));
        var span = bitmap.GetPixelSpan();
        for (var y = 0; y < image.Height; y++)
        {
            image.Rgba.AsSpan(y * image.Width * 4, image.Width * 4).CopyTo(span.Slice(y * bitmap.RowBytes, image.Width * 4));
        }

        return bitmap;
    }

    /// <summary>A bitmap's pixels as tightly packed RGBA rows, whatever its row padding.</summary>
    internal static byte[] PixelsOf(SKBitmap bitmap)
    {
        var rowLength = bitmap.Width * 4;
        var pixels = new byte[rowLength * bitmap.Height];
        var span = bitmap.GetPixelSpan();
        for (var y = 0; y < bitmap.Height; y++)
        {
            span.Slice(y * bitmap.RowBytes, rowLength).CopyTo(pixels.AsSpan(y * rowLength, rowLength));
        }

        return pixels;
    }
}

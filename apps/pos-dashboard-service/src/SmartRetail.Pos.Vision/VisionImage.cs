using SkiaSharp;

namespace SmartRetail.Pos.Vision;

/// <summary>A decoded picture, the right way up: RGBA pixels, 8 bits each, row after row, opaque.</summary>
public sealed class VisionImage
{
    /// <summary>Photos are read at most this size on their long side: plenty for a barcode and for the model.</summary>
    public const int DefaultMaxSide = 1600;

    public VisionImage(int width, int height, byte[] rgba)
    {
        ArgumentNullException.ThrowIfNull(rgba);
        if (width <= 0 || height <= 0 || rgba.Length != width * height * 4)
        {
            throw new ArgumentException("The pixels do not fit the size.", nameof(rgba));
        }

        Width = width;
        Height = height;
        Rgba = rgba;
    }

    public int Width { get; }

    public int Height { get; }

    public byte[] Rgba { get; }

    /// <summary>
    /// A JPEG, PNG or WebP as pixels: turned as its EXIF orientation says (a phone's portrait photo), made at most
    /// <paramref name="maxSide"/> pixels on its long side, and see-through parts laid on white. Null when the bytes are
    /// not a picture.
    /// </summary>
    public static VisionImage? Decode(byte[] bytes, int maxSide = DefaultMaxSide)
    {
        if (bytes is null || bytes.Length == 0)
        {
            return null;
        }

        using var data = SKData.CreateCopy(bytes);
        using var codec = SKCodec.Create(data);
        if (codec is null)
        {
            return null;
        }

        // JPEGs decode straight at a smaller size, which is much quicker for a large phone photo.
        var info = codec.Info;
        var scale = Math.Min(1f, (float)maxSide / Math.Max(info.Width, info.Height));
        var scaled = codec.GetScaledDimensions(scale);
        using var decoded = SKBitmap.Decode(codec, new SKImageInfo(scaled.Width, scaled.Height, SKColorType.Rgba8888, SKAlphaType.Unpremul));
        if (decoded is null)
        {
            return null;
        }

        var (width, height) = Fit(decoded.Width, decoded.Height, maxSide);
        using var sized = width == decoded.Width && height == decoded.Height
            ? decoded.Copy()
            : decoded.Resize(new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Unpremul), new SKSamplingOptions(SKFilterMode.Linear, SKMipmapMode.Linear));
        if (sized is null)
        {
            return null;
        }

        var pixels = ImageMath.PixelsOf(sized);
        OnWhite(pixels);
        var turned = ImageMath.Orient(pixels, sized.Width, sized.Height, (int)codec.EncodedOrigin, out var turnedWidth, out var turnedHeight);
        return new VisionImage(turnedWidth, turnedHeight, turned);
    }

    /// <summary>The size within <paramref name="maxSide"/>, keeping the shape.</summary>
    internal static (int Width, int Height) Fit(int width, int height, int maxSide)
    {
        if (Math.Max(width, height) <= maxSide)
        {
            return (width, height);
        }

        var scale = (double)maxSide / Math.Max(width, height);
        return (Math.Max(1, (int)Math.Round(width * scale)), Math.Max(1, (int)Math.Round(height * scale)));
    }

    /// <summary>Lays see-through pixels on white, as a product photo on a web page would show.</summary>
    internal static void OnWhite(byte[] rgba)
    {
        for (var i = 0; i < rgba.Length; i += 4)
        {
            var alpha = rgba[i + 3];
            if (alpha == 255)
            {
                continue;
            }

            for (var c = 0; c < 3; c++)
            {
                rgba[i + c] = (byte)((rgba[i + c] * alpha + 255 * (255 - alpha) + 127) / 255);
            }

            rgba[i + 3] = 255;
        }
    }
}

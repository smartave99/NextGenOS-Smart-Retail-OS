using SkiaSharp;

namespace SmartRetail.Pos.Web.Services;

/// <summary>A photo made ready for the website's waiting list: a JPEG, as the text the list takes.</summary>
/// <param name="Base64">The picture, as base64.</param>
/// <param name="Bytes">Its size before it was made text.</param>
public sealed record PreparedPhoto(string Mime, string Base64, int Bytes, int Width, int Height);

/// <summary>
/// Makes a product photo small enough for the owner's Supabase project: the AI's pictures are large PNG files, and the website
/// shows them in a few hundred pixels. The picture is drawn again on white at most <see cref="MaxSide"/> pixels on its longer
/// side (never larger than it was) and saved as a JPEG, at the best quality that keeps it under <see cref="MaxBytes"/>.
/// </summary>
public static class WebsitePhotos
{
    public const int MaxSide = 1600;

    /// <summary>What the waiting list takes is 900,000 letters of base64, which is about 675,000 bytes; this keeps well under.</summary>
    public const int MaxBytes = 600_000;

    private static readonly int[] Qualities = { 88, 80, 70, 60, 50 };

    /// <exception cref="InvalidDataException">The bytes are not a picture that can be read, or it cannot be made small enough.</exception>
    public static PreparedPhoto Prepare(byte[] image)
    {
        ArgumentNullException.ThrowIfNull(image);
        if (image.Length == 0)
        {
            throw new InvalidDataException("The photo is empty.");
        }

        using var picture = SKImage.FromEncodedData(image) ?? throw new InvalidDataException("The photo could not be read.");
        if (picture.Width < 1 || picture.Height < 1)
        {
            throw new InvalidDataException("The photo has no picture in it.");
        }

        var scale = Math.Min(1.0, MaxSide / (double)Math.Max(picture.Width, picture.Height));
        for (var round = 0; round < 6; round++)
        {
            var width = Math.Max(1, (int)Math.Round(picture.Width * scale));
            var height = Math.Max(1, (int)Math.Round(picture.Height * scale));
            using var surface = SKSurface.Create(new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Opaque));
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);
            canvas.DrawImage(picture, new SKRect(0, 0, width, height), new SKSamplingOptions(SKCubicResampler.Mitchell));
            using var drawn = surface.Snapshot();
            foreach (var quality in Qualities)
            {
                using var jpeg = drawn.Encode(SKEncodedImageFormat.Jpeg, quality);
                if (jpeg is not null && jpeg.Size <= MaxBytes)
                {
                    return new PreparedPhoto("image/jpeg", Convert.ToBase64String(jpeg.ToArray()), (int)jpeg.Size, width, height);
                }
            }

            scale *= 0.75;
        }

        throw new InvalidDataException("The photo could not be made small enough.");
    }
}

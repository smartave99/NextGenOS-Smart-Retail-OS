using SkiaSharp;
using SmartRetail.AI.Products;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Trims a photo the AI made to the shape of the owner's phone photo (<see cref="PhotoShape"/>): the middle part is kept, the picture
/// is never stretched, and the result is a PNG. The image tool only makes three shapes, so its photo is trimmed a little to be exactly
/// the shape the owner gave, and every photo of a product fills the same place on a website or Amazon.
/// </summary>
public static class PhotoFitter
{
    /// <summary>The photo trimmed to <paramref name="shape"/>; the same bytes when it already has that shape.</summary>
    /// <exception cref="InvalidDataException">The bytes are not a picture that can be read.</exception>
    public static byte[] Fit(byte[] image, PhotoShape shape)
    {
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(shape);
        using var picture = SKImage.FromEncodedData(image) ?? throw new InvalidDataException("The photo could not be read to fit it to the shape of your photo.");
        var (x, y, width, height) = shape.CropTo(picture.Width, picture.Height);
        if (width == picture.Width && height == picture.Height)
        {
            return image;
        }

        using var kept = picture.Subset(new SKRectI(x, y, x + width, y + height)) ?? throw new InvalidDataException("The photo could not be trimmed.");
        using var data = kept.Encode(SKEncodedImageFormat.Png, 100) ?? throw new InvalidDataException("The trimmed photo could not be saved.");
        return data.ToArray();
    }
}

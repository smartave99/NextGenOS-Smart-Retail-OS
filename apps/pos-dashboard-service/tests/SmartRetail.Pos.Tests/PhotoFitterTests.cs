using SkiaSharp;
using SmartRetail.AI.Products;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public sealed class PhotoFitterTests
{
    /// <summary>A picture of this size, each row a different shade, so which rows were kept can be told.</summary>
    private static byte[] Bands(int width, int height, SKEncodedImageFormat format = SKEncodedImageFormat.Png)
    {
        using var bitmap = new SKBitmap(width, height);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                bitmap.SetPixel(x, y, new SKColor((byte)(y % 256), (byte)(x % 256), 40));
            }
        }

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(format, 100);
        return data.ToArray();
    }

    private static (int Width, int Height) SizeOf(byte[] bytes)
    {
        using var picture = SKImage.FromEncodedData(bytes);
        return (picture.Width, picture.Height);
    }

    [Fact]
    public void A_photo_of_the_tools_shape_is_trimmed_from_the_middle_to_the_owners_shape_and_not_stretched()
    {
        var tall = Bands(1024, 1536);

        var fitted = PhotoFitter.Fit(tall, new PhotoShape(3024, 4032));

        Assert.Equal((1024, 1365), SizeOf(fitted));
        Assert.Equal(new[] { (byte)0x89, (byte)0x50, (byte)0x4E, (byte)0x47 }, fitted.Take(4));

        // The first kept row is row 85 of the original (the middle was kept), not row 0.
        using var picture = SKBitmap.Decode(fitted);
        Assert.Equal(85, picture.GetPixel(0, 0).Red);
        Assert.Equal((85 + 1364) % 256, picture.GetPixel(0, 1364).Red);
        Assert.Equal(10, picture.GetPixel(10, 0).Green);
    }

    [Fact]
    public void A_wider_photo_loses_its_side_columns_and_a_photo_of_the_right_shape_is_returned_as_it_is()
    {
        var square = Bands(1024, 1024, SKEncodedImageFormat.Jpeg);

        var fitted = PhotoFitter.Fit(square, new PhotoShape(3024, 4032));

        Assert.Equal((768, 1024), SizeOf(fitted));
        using var picture = SKBitmap.Decode(fitted);
        Assert.InRange(picture.GetPixel(0, 5).Green, 120, 136);

        var already = Bands(1000, 1333);
        Assert.Same(already, PhotoFitter.Fit(already, new PhotoShape(3024, 4032)));
        Assert.Same(already, PhotoFitter.Fit(already, new PhotoShape(0, 0)));
    }

    [Fact]
    public void Bytes_that_are_not_a_picture_are_refused()
    {
        var error = Assert.Throws<InvalidDataException>(() => PhotoFitter.Fit(new byte[] { 1, 2, 3, 4 }, new PhotoShape(3000, 4000)));

        Assert.Contains("could not be read", error.Message);
    }
}

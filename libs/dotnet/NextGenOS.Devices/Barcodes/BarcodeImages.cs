using SkiaSharp;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace NextGenOS.Devices.Barcodes;

/// <summary>Barcodes as pictures (for posters, shelf labels and printers that need a picture) and the other way: reading a barcode from a photograph (a phone or webcam).</summary>
public static class BarcodeImages
{
    private static BarcodeFormat Format(BarcodeKind kind) => kind switch
    {
        BarcodeKind.Ean13 => BarcodeFormat.EAN_13, BarcodeKind.Ean8 => BarcodeFormat.EAN_8, BarcodeKind.UpcA => BarcodeFormat.UPC_A,
        BarcodeKind.Code39 => BarcodeFormat.CODE_39, BarcodeKind.Qr => BarcodeFormat.QR_CODE, _ => BarcodeFormat.CODE_128,
    };

    /// <summary>The dots of a barcode, one bit for each, row after row (true is black).</summary>
    public static BitMatrix Matrix(BarcodeKind kind, string data, int width = 0, int height = 0)
    {
        try
        {
            var hints = new Dictionary<EncodeHintType, object> { [EncodeHintType.MARGIN] = 0 };
            if (kind == BarcodeKind.Qr) hints[EncodeHintType.ERROR_CORRECTION] = ZXing.QrCode.Internal.ErrorCorrectionLevel.M;
            if (kind == BarcodeKind.Qr) hints[EncodeHintType.CHARACTER_SET] = "UTF-8";
            return new MultiFormatWriter().encode(data, Format(kind), width, height, hints);
        }
        catch (Exception ex) when (ex is ArgumentException or WriterException)
        {
            throw new ArgumentException($"\"{data}\" cannot be made into that kind of barcode: {ex.Message}", nameof(data), ex);
        }
    }

    /// <summary>A PNG of the barcode at the given size in pixels, black on white, with a quiet margin around it.</summary>
    public static byte[] Png(BarcodeKind kind, string data, int width, int height, int margin = 8)
    {
        var matrix = Matrix(kind, data, kind == BarcodeKind.Qr ? Math.Min(width, height) : width, kind == BarcodeKind.Qr ? Math.Min(width, height) : height);
        using var bitmap = new SKBitmap(matrix.Width + 2 * margin, matrix.Height + 2 * margin, SKColorType.Gray8, SKAlphaType.Opaque);
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(SKColors.White);
        using var paint = new SKPaint { Color = SKColors.Black, IsAntialias = false };
        for (var y = 0; y < matrix.Height; y++)
            for (var x = 0; x < matrix.Width; x++)
                if (matrix[x, y]) canvas.DrawRect(x + margin, y + margin, 1, 1, paint);
        using var image = SKImage.FromBitmap(bitmap);
        using var data2 = image.Encode(SKEncodedImageFormat.Png, 100);
        return data2.ToArray();
    }

    /// <summary>Reads the first barcode found in a picture (JPEG, PNG, WebP). Null when there is none, or when the picture is not one.</summary>
    public static (string Text, string Format)? Read(byte[] picture)
    {
        if (picture.Length is 0 or > 12_000_000) return null;
        SKBitmap? decoded;
        try
        {
            using var data = SKData.CreateCopy(picture);
            using var codec = SKCodec.Create(data);
            decoded = codec is null ? null : SKBitmap.Decode(codec);
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException or IOException)
        {
            return null;
        }
        if (decoded is null) return null;
        using var _ = decoded;
        // A big photograph is reduced: barcodes are found faster and more reliably at about 1600 pixels across.
        var scale = Math.Min(1f, 1600f / Math.Max(decoded.Width, decoded.Height));
        using var bitmap = scale < 1f ? decoded.Resize(new SKImageInfo((int)(decoded.Width * scale), (int)(decoded.Height * scale), SKColorType.Rgba8888), new SKSamplingOptions(SKFilterMode.Linear, SKMipmapMode.Linear)) : decoded.Copy(SKColorType.Rgba8888);
        if (bitmap is null) return null;
        var reader = new BarcodeReaderGeneric
        {
            AutoRotate = true,
            Options = new DecodingOptions
            {
                TryHarder = true, TryInverted = true,
                PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.EAN_13, BarcodeFormat.EAN_8, BarcodeFormat.UPC_A, BarcodeFormat.UPC_E, BarcodeFormat.CODE_128, BarcodeFormat.CODE_39, BarcodeFormat.QR_CODE, BarcodeFormat.ITF, BarcodeFormat.CODABAR, BarcodeFormat.DATA_MATRIX },
            },
        };
        var source = new RGBLuminanceSource(bitmap.Bytes, bitmap.Width, bitmap.Height, RGBLuminanceSource.BitmapFormat.RGBA32);
        var result = reader.Decode(source);
        return result is null ? null : (result.Text, result.BarcodeFormat.ToString());
    }
}

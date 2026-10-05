using System.Net;
using System.Security.Cryptography;
using SkiaSharp;
using SmartRetail.Pos.Vision;
using ZXing;

namespace SmartRetail.Pos.Tests.Vision;

/// <summary>Pictures made in the tests, as a phone or a scanner would give them.</summary>
internal static class Pictures
{
    /// <summary>A picture of one colour.</summary>
    public static VisionImage Plain(int width, int height, byte r, byte g, byte b)
    {
        var rgba = new byte[width * height * 4];
        for (var i = 0; i < rgba.Length; i += 4)
        {
            (rgba[i], rgba[i + 1], rgba[i + 2], rgba[i + 3]) = (r, g, b, 255);
        }

        return new VisionImage(width, height, rgba);
    }

    /// <summary>A barcode as ZXing draws it, black on white with a quiet margin.</summary>
    public static VisionImage Barcode(string text, BarcodeFormat format, int width = 600, int height = 220)
    {
        var matrix = new MultiFormatWriter().encode(text, format, width, height, new Dictionary<EncodeHintType, object> { [EncodeHintType.MARGIN] = 20 });
        var rgba = new byte[matrix.Width * matrix.Height * 4];
        for (var y = 0; y < matrix.Height; y++)
        {
            for (var x = 0; x < matrix.Width; x++)
            {
                var value = matrix[x, y] ? (byte)0 : (byte)255;
                var at = (y * matrix.Width + x) * 4;
                (rgba[at], rgba[at + 1], rgba[at + 2], rgba[at + 3]) = (value, value, value, 255);
            }
        }

        return new VisionImage(matrix.Width, matrix.Height, rgba);
    }

    /// <summary>A bottle (body, cap and label) drawn at a place and size, on a background, as a product in a photo.</summary>
    public static VisionImage Bottle(SKColor body, SKColor cap, SKColor label, float x, float y, float size, SKColor background, float angle = 0) =>
        Draw(480, 480, canvas =>
        {
            canvas.Clear(background);
            canvas.RotateDegrees(angle, x, y);
            using var paint = new SKPaint { IsAntialias = true };
            paint.Color = body;
            canvas.DrawRoundRect(new SKRect(x - 60 * size, y - 100 * size, x + 60 * size, y + 160 * size), 30 * size, 30 * size, paint);
            paint.Color = cap;
            canvas.DrawRect(new SKRect(x - 25 * size, y - 150 * size, x + 25 * size, y - 100 * size), paint);
            paint.Color = label;
            canvas.DrawRect(new SKRect(x - 60 * size, y - 10 * size, x + 60 * size, y + 70 * size), paint);
        });

    /// <summary>A striped box, as a pack of tea in a photo.</summary>
    public static VisionImage Box(SKColor body, SKColor stripe, float x, float y, float size, SKColor background) =>
        Draw(480, 480, canvas =>
        {
            canvas.Clear(background);
            using var paint = new SKPaint { IsAntialias = true };
            paint.Color = body;
            canvas.DrawRect(new SKRect(x - 110 * size, y - 70 * size, x + 110 * size, y + 70 * size), paint);
            paint.Color = stripe;
            for (var i = 0; i < 4; i++)
            {
                canvas.DrawRect(new SKRect(x - 110 * size, y - 60 * size + i * 35 * size, x + 110 * size, y - 45 * size + i * 35 * size), paint);
            }
        });

    private static VisionImage Draw(int width, int height, Action<SKCanvas> paint)
    {
        using var bitmap = new SKBitmap(new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Unpremul));
        using (var canvas = new SKCanvas(bitmap))
        {
            paint(canvas);
        }

        return new VisionImage(width, height, ImageMath.PixelsOf(bitmap));
    }

    /// <summary>The picture in the middle of a white one, as a photo taken from further away.</summary>
    public static VisionImage WithBorder(VisionImage image, int border)
    {
        var width = image.Width + 2 * border;
        var framed = Plain(width, image.Height + 2 * border, 255, 255, 255);
        for (var y = 0; y < image.Height; y++)
        {
            Buffer.BlockCopy(image.Rgba, y * image.Width * 4, framed.Rgba, ((y + border) * width + border) * 4, image.Width * 4);
        }

        return framed;
    }

    /// <summary>A picture encoded as a file, as the camera or an upload gives it.</summary>
    public static byte[] Encode(VisionImage image, SKEncodedImageFormat format, byte alpha = 255)
    {
        using var bitmap = new SKBitmap(new SKImageInfo(image.Width, image.Height, SKColorType.Rgba8888, SKAlphaType.Unpremul));
        var pixels = (byte[])image.Rgba.Clone();
        for (var i = 3; i < pixels.Length; i += 4)
        {
            pixels[i] = alpha;
        }

        var span = bitmap.GetPixelSpan();
        for (var y = 0; y < image.Height; y++)
        {
            pixels.AsSpan(y * image.Width * 4, image.Width * 4).CopyTo(span.Slice(y * bitmap.RowBytes, image.Width * 4));
        }

        using var data = bitmap.Encode(format, 95);
        return data.ToArray();
    }

    /// <summary>A JPEG with an EXIF orientation, as a phone saves a photo taken upright (6).</summary>
    public static byte[] WithOrientation(byte[] jpeg, ushort orientation)
    {
        // APP1 "Exif": a little-endian TIFF header and one IFD entry, Orientation (0x0112), a SHORT.
        var tiff = new byte[]
        {
            (byte)'I', (byte)'I', 42, 0, 8, 0, 0, 0,
            1, 0,
            0x12, 0x01, 3, 0, 1, 0, 0, 0, (byte)orientation, 0, 0, 0,
            0, 0, 0, 0,
        };
        var exif = new byte[] { (byte)'E', (byte)'x', (byte)'i', (byte)'f', 0, 0 }.Concat(tiff).ToArray();
        var length = exif.Length + 2;
        var segment = new byte[] { 0xFF, 0xE1, (byte)(length >> 8), (byte)length }.Concat(exif);
        return jpeg.Take(2).Concat(segment).Concat(jpeg.Skip(2)).ToArray();
    }
}

public class VisionImageTests
{
    //  a b c
    //  d e f
    private static readonly VisionImage Six = new(3, 2, Enumerable.Range(0, 6).SelectMany(i => new[] { (byte)(10 * (i + 1)), (byte)0, (byte)0, (byte)255 }).ToArray());

    private static string Layout(byte[] rgba, int width, int height) =>
        string.Join("/", Enumerable.Range(0, height).Select(y => string.Concat(Enumerable.Range(0, width).Select(x => (char)('a' + rgba[(y * width + x) * 4] / 10 - 1)))));

    [Theory]
    [InlineData(1, 3, "abc/def")]
    [InlineData(2, 3, "cba/fed")]
    [InlineData(3, 3, "fed/cba")]
    [InlineData(4, 3, "def/abc")]
    [InlineData(5, 2, "ad/be/cf")]
    [InlineData(6, 2, "da/eb/fc")]
    [InlineData(7, 2, "fc/eb/da")]
    [InlineData(8, 2, "cf/be/ad")]
    [InlineData(0, 3, "abc/def")]
    public void Each_exif_orientation_turns_the_picture_the_right_way_up(int orientation, int width, string layout)
    {
        var turned = ImageMath.Orient(Six.Rgba, 3, 2, orientation, out var newWidth, out var newHeight);

        Assert.Equal(width, newWidth);
        Assert.Equal(6 / width, newHeight);
        Assert.Equal(layout, Layout(turned, newWidth, newHeight));
    }

    [Fact]
    public void A_photo_taken_upright_on_a_phone_is_turned_when_decoded()
    {
        var wide = Pictures.Plain(40, 20, 200, 30, 30);
        // The top-left corner blue, to see where it goes.
        for (var y = 0; y < 5; y++)
        {
            for (var x = 0; x < 5; x++)
            {
                (wide.Rgba[(y * 40 + x) * 4], wide.Rgba[(y * 40 + x) * 4 + 2]) = (0, 255);
            }
        }

        var jpeg = Pictures.WithOrientation(Pictures.Encode(wide, SKEncodedImageFormat.Jpeg), 6);

        var decoded = VisionImage.Decode(jpeg)!;

        Assert.Equal((20, 40), (decoded.Width, decoded.Height));
        // Turned a quarter clockwise, the top-left corner is now at the top right.
        var topRight = (1 * decoded.Width + decoded.Width - 2) * 4;
        Assert.True(decoded.Rgba[topRight + 2] > 150 && decoded.Rgba[topRight] < 100, "the corner did not move with the picture");
    }

    [Fact]
    public void Large_photos_are_made_smaller_and_see_through_parts_lie_on_white()
    {
        var png = Pictures.Encode(Pictures.Plain(3000, 1000, 0, 0, 0), SKEncodedImageFormat.Png, alpha: 0);

        var decoded = VisionImage.Decode(png)!;

        Assert.Equal((VisionImage.DefaultMaxSide, 533), (decoded.Width, decoded.Height));
        Assert.All(decoded.Rgba.Take(400), value => Assert.Equal(255, value));
        Assert.Equal((100, 50), VisionImage.Fit(100, 50, 1600));
        Assert.Equal((1600, 800), VisionImage.Fit(3200, 1600, 1600));
    }

    [Fact]
    public void Bytes_that_are_not_a_picture_give_nothing()
    {
        Assert.Null(VisionImage.Decode("not a picture at all"u8.ToArray()));
        Assert.Null(VisionImage.Decode(Array.Empty<byte>()));
        Assert.Throws<ArgumentException>(() => new VisionImage(2, 2, new byte[15]));
    }

    [Fact]
    public void The_models_input_is_the_middle_square_normalised_channel_by_channel()
    {
        var input = ImageMath.Preprocess(Pictures.Plain(300, 200, 128, 64, 255));

        Assert.Equal(3 * 224 * 224, input.Length);
        var plane = 224 * 224;
        Assert.All(new[] { 0, plane / 2, plane - 1 }, i =>
        {
            Assert.Equal((128 / 255f - 0.485f) / 0.229f, input[i], 3);
            Assert.Equal((64 / 255f - 0.456f) / 0.224f, input[plane + i], 3);
            Assert.Equal((255 / 255f - 0.406f) / 0.225f, input[2 * plane + i], 3);
        });
    }
}

public class BarcodeScannerTests
{
    [Theory]
    [InlineData("4006381333931", BarcodeFormat.EAN_13)]
    [InlineData("96385074", BarcodeFormat.EAN_8)]
    [InlineData("036000291452", BarcodeFormat.UPC_A)]
    [InlineData("2000000000060", BarcodeFormat.EAN_13)]
    [InlineData("1006-A", BarcodeFormat.CODE_128)]
    public void Makers_codes_and_the_shops_own_stickers_are_read(string text, BarcodeFormat format)
    {
        var code = Assert.Single(BarcodeScanner.Read(Pictures.Barcode(text, format)));

        Assert.Equal(text, code.Text);
        Assert.Equal(format.ToString(), code.Format);
    }

    [Fact]
    public void A_code_photographed_on_its_side_is_read_too()
    {
        var upright = Pictures.Barcode("8901030865275", BarcodeFormat.EAN_13);
        var turned = ImageMath.Orient(upright.Rgba, upright.Width, upright.Height, 6, out var width, out var height);

        Assert.Equal("8901030865275", Assert.Single(BarcodeScanner.Read(new VisionImage(width, height, turned))).Text);
    }

    [Fact]
    public void A_photo_without_a_code_has_none()
    {
        Assert.Empty(BarcodeScanner.Read(Pictures.Plain(400, 300, 120, 160, 90)));
    }

    [Fact]
    public void A_code_is_looked_for_as_the_pos_may_keep_it()
    {
        Assert.Equal(new[] { "036000291452", "0036000291452" }, BarcodeScanner.Forms(new ScannedCode("036000291452", "UPC_A")));
        Assert.Equal(new[] { "0036000291452", "036000291452" }, BarcodeScanner.Forms(new ScannedCode("0036000291452", "EAN_13")));
        Assert.Equal(new[] { "1006-A" }, BarcodeScanner.Forms(new ScannedCode("1006-A", "CODE_128")));
    }
}

public class ImageEmbedderTests
{
    private static string Model(string name) => Path.Combine(AppContext.BaseDirectory, "Vision", name);

    [Fact]
    public void The_model_turns_a_picture_into_a_unit_vector_alike_for_alike_pictures()
    {
        using var embedder = new OnnxImageEmbedder(Model("tiny-embedder.onnx"), "tiny@1");

        var red = embedder.Embed(Pictures.Plain(320, 240, 220, 40, 40));
        var redAgain = embedder.Embed(Pictures.Plain(640, 400, 222, 42, 38));
        var green = embedder.Embed(Pictures.Plain(320, 240, 40, 200, 60));

        Assert.Equal("tiny@1", embedder.ModelId);
        Assert.Equal(6, red.Length);
        Assert.Equal(1f, VectorMath.Similarity(red, red), 4);
        Assert.True(VectorMath.Similarity(red, redAgain) > 0.99f);
        Assert.True(VectorMath.Similarity(red, green) < VectorMath.Similarity(red, redAgain) - 0.2f);
    }

    [Fact]
    public void A_model_let_go_is_never_used_again()
    {
        var embedder = new OnnxImageEmbedder(Model("tiny-embedder.onnx"), "tiny@1");
        embedder.Dispose();
        embedder.Dispose();

        Assert.Throws<ObjectDisposedException>(() => embedder.Embed(Pictures.Plain(50, 50, 1, 2, 3)));
    }

    [Fact]
    public void A_model_without_a_pooled_output_gives_its_class_token()
    {
        using var pooled = new OnnxImageEmbedder(Model("tiny-embedder.onnx"), "tiny@1");
        using var tokens = new OnnxImageEmbedder(Model("tiny-embedder-tokens.onnx"), "tiny-tokens@1");
        var picture = Pictures.Plain(300, 300, 90, 120, 200);

        var fromPooled = pooled.Embed(picture);
        var fromTokens = tokens.Embed(picture);

        Assert.Equal(fromPooled.Length, fromTokens.Length);
        Assert.Equal(1f, VectorMath.Similarity(fromPooled, fromTokens), 5);
    }
}

public class VisionModelsTests
{
    [Fact]
    public void Every_model_is_pinned_to_a_fixed_revision_with_its_exact_size_and_hash()
    {
        Assert.Equal(new[] { "dinov2-small@8b1f705", "dinov2-base@31ef06c" }, VisionModels.All.Select(m => m.Id));
        Assert.Same(VisionModels.Dinov2Small, VisionModels.Default);
        Assert.Same(VisionModels.Dinov2Small, VisionModels.All[0]); // every shop starts on the first, and an update never changes it
        Assert.Equal(VisionModels.All.Count, VisionModels.All.Select(m => m.FileName).Distinct().Count());
        foreach (var model in VisionModels.All)
        {
            Assert.Equal("https", model.Url.Scheme);
            Assert.Equal("huggingface.co", model.Url.Host);
            Assert.Matches("^/onnx-community/dinov2-[a-z]+/resolve/[0-9a-f]{40}/onnx/model\\.onnx$", model.Url.AbsolutePath);
            Assert.StartsWith(model.Id.Split('@')[1], model.Url.AbsolutePath.Split('/')[4]);
            Assert.Matches("^[0-9a-f]{64}$", model.Sha256);
            Assert.True(model.Size > 50_000_000);
            Assert.NotEmpty(model.Name);
            Assert.NotEmpty(model.Note);
        }

        Assert.True(VisionModels.Dinov2Base.Size > VisionModels.Dinov2Small.Size);
    }

    [Fact]
    public void A_model_is_found_by_its_id_and_an_empty_id_is_the_first()
    {
        Assert.Same(VisionModels.Dinov2Small, VisionModels.Find(VisionModels.All, null));
        Assert.Same(VisionModels.Dinov2Small, VisionModels.Find(VisionModels.All, " "));
        Assert.Same(VisionModels.Dinov2Base, VisionModels.Find(VisionModels.All, " dinov2-base@31ef06c "));
        Assert.Null(VisionModels.Find(VisionModels.All, "dinov2-huge@1"));
        Assert.Null(VisionModels.Find(Array.Empty<VisionModel>(), ""));
    }
}

/// <summary>Needs a DINOv2 model itself: skipped unless the variable is the path of its model.onnx.</summary>
public sealed class Dinov2FactAttribute : FactAttribute
{
    public const string EnvironmentVariable = "POS_TEST_DINOV2";
    public const string BaseEnvironmentVariable = "POS_TEST_DINOV2_BASE";

    public Dinov2FactAttribute(string variable = EnvironmentVariable)
    {
        if (!File.Exists(Environment.GetEnvironmentVariable(variable) ?? ""))
        {
            Skip = $"Set {variable} to the model.onnx of {(variable == BaseEnvironmentVariable ? "DINOv2-base" : "DINOv2-small")} to run this test.";
        }
    }
}

public class Dinov2Tests
{
    [Dinov2Fact]
    public void A_photo_of_a_product_finds_it_among_products_of_the_same_shape() =>
        FindsAmongTheSameShape(Dinov2FactAttribute.EnvironmentVariable, VisionModels.Dinov2Small, 384);

    [Dinov2Fact(Dinov2FactAttribute.BaseEnvironmentVariable)]
    public void The_base_model_finds_them_too_with_more_numbers_to_a_picture() =>
        FindsAmongTheSameShape(Dinov2FactAttribute.BaseEnvironmentVariable, VisionModels.Dinov2Base, 768);

    private static void FindsAmongTheSameShape(string variable, VisionModel model, int numbers)
    {
        using var embedder = new OnnxImageEmbedder(Environment.GetEnvironmentVariable(variable)!, model.Id);
        var shelf = new SKColor(170, 140, 110);
        // The catalogue: white-background photos. Oil and shampoo come in the same bottle.
        var catalogue = new Dictionary<int, VisionImage>
        {
            [1] = Pictures.Bottle(new SKColor(240, 190, 40), new SKColor(250, 220, 0), new SKColor(30, 120, 60), 240, 240, 1.2f, SKColors.White),
            [2] = Pictures.Bottle(new SKColor(40, 90, 220), new SKColor(250, 250, 250), new SKColor(220, 40, 60), 240, 240, 1.2f, SKColors.White),
            [3] = Pictures.Box(new SKColor(180, 30, 30), new SKColor(250, 200, 60), 240, 240, 1.3f, SKColors.White),
        };
        var index = new VisualIndex();
        foreach (var (id, picture) in catalogue)
        {
            index.Set(id, new[] { new PhotoVector($"white-{id}.png", embedder.Embed(picture), ColourHistogram.Of(picture)) });
        }

        // Photos taken in the shop: on the shelf, smaller, a little turned.
        var photos = new (int Product, VisionImage Photo)[]
        {
            (1, Pictures.Bottle(new SKColor(230, 180, 45), new SKColor(245, 215, 10), new SKColor(35, 115, 65), 260, 250, 0.9f, shelf, 8)),
            (2, Pictures.Bottle(new SKColor(45, 95, 210), new SKColor(240, 240, 240), new SKColor(210, 45, 60), 250, 245, 0.9f, shelf, -6)),
            (3, Pictures.Box(new SKColor(175, 35, 35), new SKColor(245, 195, 70), 230, 260, 1.0f, shelf)),
        };

        Assert.Equal(numbers, embedder.Embed(photos[0].Photo).Length);
        foreach (var (product, photo) in photos)
        {
            var matches = index.Search(embedder.Embed(photo), ColourHistogram.Of(photo));
            Assert.True(matches[0].ProductId == product, $"product {product} was not found first: " + string.Join(", ", matches.Select(m => $"{m.ProductId}={m.Score:0.000}")));
            Assert.True(VisualIndex.IsSure(matches), $"product {product} was found by too little: " + string.Join(", ", matches.Select(m => $"{m.ProductId}={m.Score:0.000}")));
        }
    }
}

public class VisualIndexTests
{
    private static float[] V(params float[] values) => VectorMath.Normalize(values);

    private static readonly float[] Grey = V(1, 0);

    [Fact]
    public void Each_product_counts_once_by_its_most_alike_photo()
    {
        var index = new VisualIndex();
        index.Set(1, new[] { new PhotoVector("white-1.png", V(1, 0, 0), Grey), new PhotoVector("raw-1.jpg", V(0.8f, 0.6f, 0), Grey) });
        index.Set(2, new[] { new PhotoVector("white-2.png", V(0, 1, 0), Grey) });
        index.Set(3, new[] { new PhotoVector("white-3.png", V(0, 0, 1), Grey) });

        var matches = index.Search(V(0.7f, 0.7f, 0), Grey, 2);

        Assert.Equal(new[] { 1, 2 }, matches.Select(m => m.ProductId));
        Assert.Equal("raw-1.jpg", matches[0].File);
        Assert.Equal(0.7f * 0.98995f + 0.3f, matches[0].Score, 3);
        Assert.Equal(3, index.ProductCount);

        index.Set(1, Array.Empty<PhotoVector>());
        Assert.False(index.Contains(1));
        Assert.Equal(2, index.Search(V(1, 1, 0), Grey).First().ProductId);
        index.Clear();
        Assert.Empty(index.Search(V(1, 0, 0), Grey));
    }

    [Fact]
    public void Colour_tells_apart_products_that_look_the_same_and_nothing_alike_is_left_out()
    {
        var index = new VisualIndex();
        var shape = V(1, 0, 0);
        index.Set(1, new[] { new PhotoVector("white-1.png", shape, V(1, 0)) });
        index.Set(2, new[] { new PhotoVector("white-2.png", shape, V(0, 1)) });
        index.Set(3, new[] { new PhotoVector("white-3.png", V(-1, 0, 0), V(0, 1)) });

        var matches = index.Search(shape, V(0, 1));

        Assert.Equal(new[] { 2, 1 }, matches.Select(m => m.ProductId));
        Assert.True(VisualIndex.IsSure(matches));
        Assert.False(VisualIndex.IsSure(new[] { new LookMatch(1, 0.70f, "a"), new LookMatch(2, 0.68f, "b") }));
        Assert.True(VisualIndex.IsSure(new[] { new LookMatch(1, 0.70f, "a") }));
        Assert.False(VisualIndex.IsSure(Array.Empty<LookMatch>()));
    }
}

public sealed class VisualStoreTests : IDisposable
{
    private readonly string _folder = Directory.CreateTempSubdirectory("visual-").FullName;

    public void Dispose() => Directory.Delete(_folder, recursive: true);

    [Fact]
    public void Vectors_are_kept_next_to_the_photos_for_their_model_only()
    {
        var colour = VectorMath.Normalize(Enumerable.Range(1, ColourHistogram.Length).Select(i => (float)i).ToArray());
        var vectors = new[] { new PhotoVector("white-20260928-100000.png", new[] { 0.6f, -0.8f }, colour), new PhotoVector("raw-20260928-095900.jpg", new[] { 1f, 0f }, colour) };

        VisualStore.Write(_folder, "dinov2-small@8b1f705", vectors);

        var read = VisualStore.Read(_folder, "dinov2-small@8b1f705");
        Assert.Equal(vectors.Select(v => v.File), read.Select(v => v.File));
        Assert.Equal(vectors[0].Vector, read[0].Vector);
        Assert.Equal(colour, read[1].Colour);
        Assert.Empty(VisualStore.Read(_folder, "another-model@1"));
        Assert.False(File.Exists(Path.Combine(_folder, VisualStore.FileName + ".tmp")));

        VisualStore.Write(_folder, "dinov2-small@8b1f705", Array.Empty<PhotoVector>());
        Assert.False(File.Exists(Path.Combine(_folder, VisualStore.FileName)));
        Assert.Empty(VisualStore.Read(_folder, "dinov2-small@8b1f705"));
    }

    [Fact]
    public void A_broken_or_hand_edited_file_gives_only_what_is_sound()
    {
        var good = VisualStore.Encode(new[] { 1f, 0f });
        var colour = "\",\"Colour\":\"" + VisualStore.Encode(new float[ColourHistogram.Length]) + "\"}";
        File.WriteAllText(Path.Combine(_folder, VisualStore.FileName), "{\"Model\":\"m@1\",\"Photos\":["
            + "{\"File\":\"white-1.png\",\"Vector\":\"" + good + colour + ","
            + "{\"File\":\"../settings.json\",\"Vector\":\"" + good + colour + ","
            + "{\"File\":\"raw-2.jpg\",\"Vector\":\"not base64!" + colour + ","
            + "{\"File\":\"raw-3.jpg\",\"Vector\":\"AAA=" + colour + ","
            + "{\"File\":\"raw-4.jpg\",\"Vector\":\"" + VisualStore.Encode(new[] { float.NaN }) + colour + ","
            + "{\"File\":\"raw-5.jpg\",\"Vector\":\"" + good + "\",\"Colour\":\"" + VisualStore.Encode(new[] { 1f }) + "\"}]}");

        Assert.Equal(new[] { "white-1.png" }, VisualStore.Read(_folder, "m@1").Select(v => v.File));

        File.WriteAllText(Path.Combine(_folder, VisualStore.FileName), "{ broken");
        Assert.Empty(VisualStore.Read(_folder, "m@1"));
    }
}

public sealed class ModelDownloaderTests : IDisposable
{
    private static readonly byte[] Bytes = Enumerable.Range(0, 300_000).Select(i => (byte)(i * 7)).ToArray();

    private readonly string _folder = Directory.CreateTempSubdirectory("models-").FullName;

    public void Dispose() => Directory.Delete(_folder, recursive: true);

    private static VisionModel Model(byte[] bytes, string? sha256 = null) => new(
        "test@1", "test.onnx", new Uri("https://models.example/test.onnx"), bytes.Length, sha256 ?? Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant());

    private ModelDownloader Downloader(HttpMessageHandler handler) => new(new HttpClient(handler), _folder);

    [Fact]
    public async Task The_model_is_kept_only_whole_and_with_its_hash()
    {
        var reported = new List<double>();
        var downloader = Downloader(new Serves(Bytes));

        await downloader.DownloadAsync(Model(Bytes), new SyncProgress(reported.Add), CancellationToken.None);

        Assert.Equal(Bytes, File.ReadAllBytes(downloader.PathOf(Model(Bytes))));
        Assert.True(downloader.IsDownloaded(Model(Bytes)));
        Assert.True(await downloader.VerifyAsync(Model(Bytes), CancellationToken.None));
        Assert.Equal(1d, reported[^1]);
        Assert.True(reported.Count > 1, "progress is reported as it comes");
        Assert.False(File.Exists(downloader.PathOf(Model(Bytes)) + ".part"));
    }

    [Fact]
    public async Task Another_file_is_never_kept()
    {
        var wrongHash = Model(Bytes, new string('0', 64));
        var downloader = Downloader(new Serves(Bytes));

        var problem = await Assert.ThrowsAsync<InvalidDataException>(() => downloader.DownloadAsync(wrongHash, null, CancellationToken.None));
        Assert.Contains("SHA-256", problem.Message);
        Assert.False(File.Exists(downloader.PathOf(wrongHash)));
        Assert.False(File.Exists(downloader.PathOf(wrongHash) + ".part"));

        var tooLong = Model(Bytes[..1000]);
        await Assert.ThrowsAsync<InvalidDataException>(() => Downloader(new Serves(Bytes)).DownloadAsync(tooLong, null, CancellationToken.None));
        var tooShort = Model(Bytes.Concat(new byte[10]).ToArray());
        await Assert.ThrowsAsync<InvalidDataException>(() => Downloader(new Serves(Bytes)).DownloadAsync(tooShort, null, CancellationToken.None));
        Assert.Empty(Directory.GetFiles(_folder));

        var missing = await Assert.ThrowsAsync<HttpRequestException>(() => Downloader(new Serves(Bytes, HttpStatusCode.NotFound)).DownloadAsync(Model(Bytes), null, CancellationToken.None));
        Assert.Equal(HttpStatusCode.NotFound, missing.StatusCode);
    }

    [Fact]
    public async Task A_download_that_stops_gives_up_and_a_spoilt_file_is_deleted()
    {
        var downloader = Downloader(new Serves(Bytes, stallAfter: 1000)) ;
        downloader.StallTimeout = TimeSpan.FromMilliseconds(200);

        await Assert.ThrowsAsync<IOException>(() => downloader.DownloadAsync(Model(Bytes), null, CancellationToken.None));
        Assert.Empty(Directory.GetFiles(_folder));

        var spoilt = (byte[])Bytes.Clone();
        spoilt[5] ^= 0xFF;
        File.WriteAllBytes(downloader.PathOf(Model(Bytes)), spoilt);
        Assert.True(downloader.IsDownloaded(Model(Bytes)), "the size alone looks right");
        Assert.False(await downloader.VerifyAsync(Model(Bytes), CancellationToken.None));
        Assert.False(File.Exists(downloader.PathOf(Model(Bytes))));
    }

    [Fact]
    public void Dinov2_is_pinned_to_one_file()
    {
        var model = VisionModels.Dinov2Small;

        Assert.Equal("https", model.Url.Scheme);
        Assert.Equal("huggingface.co", model.Url.Host);
        Assert.Contains("/resolve/8b1f705a3a7f6f062f6bdd21986c1583d3ef105d/", model.Url.AbsolutePath);
        Assert.Equal(64, model.Sha256.Length);
        Assert.Equal(88_532_934, model.Size);
    }

    private sealed class SyncProgress(Action<double> report) : IProgress<double>
    {
        public void Report(double value) => report(value);
    }

    /// <summary>Serves the bytes in small pieces; can answer with an error, or stop sending part-way.</summary>
    private sealed class Serves(byte[] bytes, HttpStatusCode status = HttpStatusCode.OK, int stallAfter = -1) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
            Task.FromResult(new HttpResponseMessage(status) { Content = new StreamContent(new Trickle(bytes, stallAfter)) });
    }

    private sealed class Trickle(byte[] bytes, int stallAfter) : Stream
    {
        private int _at;

        public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            if (stallAfter >= 0 && _at >= stallAfter)
            {
                await Task.Delay(Timeout.Infinite, cancellationToken);
            }

            var count = Math.Min(Math.Min(buffer.Length, 50_000), bytes.Length - _at);
            bytes.AsMemory(_at, count).CopyTo(buffer);
            _at += count;
            return count;
        }

        public override int Read(byte[] buffer, int offset, int count) => ReadAsync(buffer.AsMemory(offset, count)).AsTask().GetAwaiter().GetResult();

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => bytes.Length;

        public override long Position { get => _at; set => throw new NotSupportedException(); }

        public override void Flush()
        {
        }

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    }
}

public sealed class VisualLearnerTests : IDisposable
{
    private readonly string _folder = Directory.CreateTempSubdirectory("learner-").FullName;

    public void Dispose() => Directory.Delete(_folder, recursive: true);

    private static string Model => Path.Combine(AppContext.BaseDirectory, "Vision", "tiny-embedder.onnx");

    private string Photo(string name, byte r, byte g, byte b)
    {
        File.WriteAllBytes(Path.Combine(_folder, name), Pictures.Encode(Pictures.Plain(120, 90, r, g, b), SKEncodedImageFormat.Png));
        return name;
    }

    private static VisionImage Yellow => Pictures.Plain(100, 100, 238, 198, 32);

    [Fact]
    public void Each_photo_is_looked_at_once_and_its_vectors_kept_next_to_it()
    {
        using var embedder = new CountingEmbedder(new OnnxImageEmbedder(Model, "tiny@1"));
        var index = new VisualIndex();
        var learner = new VisualLearner(index, embedder);
        var white = Photo("white-1.png", 240, 200, 30);
        var raw = Photo("raw-1.png", 230, 190, 40);
        var files = new[] { white, raw };

        Assert.True(learner.Load(1, _folder, files), "nothing was learned yet");
        Assert.True(learner.Learn(1, _folder, files));
        Assert.Equal(2, embedder.Count);
        Assert.True(File.Exists(Path.Combine(_folder, VisualStore.FileName)));
        Assert.Equal(1, index.Search(embedder.Embed(Yellow), ColourHistogram.Of(Yellow)).First().ProductId);

        // Again: nothing new to look at, and another index loads it without looking.
        embedder.Count = 0;
        Assert.True(learner.Learn(1, _folder, files));
        Assert.Equal(0, embedder.Count);
        var fresh = new VisualIndex();
        Assert.False(new VisualLearner(fresh, embedder).Load(1, _folder, files));
        Assert.True(fresh.Contains(1));

        // New photos: only the new one is looked at, and the one no longer used goes.
        var closer = Photo("raw-2.png", 235, 195, 35);
        Assert.True(learner.Load(1, _folder, new[] { white, closer }));
        Assert.True(learner.Learn(1, _folder, new[] { white, closer }));
        Assert.Equal(1, embedder.Count);
        Assert.Equal(new[] { white, closer }, VisualStore.Read(_folder, "tiny@1").Select(v => v.File));
    }

    [Fact]
    public void Nothing_is_written_while_it_may_not_be_and_unreadable_photos_are_left_out()
    {
        using var embedder = new OnnxImageEmbedder(Model, "tiny@1");
        var index = new VisualIndex();
        var learner = new VisualLearner(index, embedder);
        var white = Photo("white-1.png", 240, 200, 30);
        File.WriteAllText(Path.Combine(_folder, "raw-9.png"), "not a photo");

        Assert.False(learner.Learn(1, _folder, new[] { white }, mayWrite: () => false));
        Assert.False(File.Exists(Path.Combine(_folder, VisualStore.FileName)));
        Assert.False(index.Contains(1));

        Assert.True(learner.Learn(1, _folder, new[] { white, "raw-9.png", "raw-missing.png" }, mayWrite: () => true));
        Assert.Equal(new[] { white }, VisualStore.Read(_folder, "tiny@1").Select(v => v.File));

        Assert.True(learner.Learn(1, null, new[] { white }));
        Assert.False(index.Contains(1));
        Assert.True(learner.Load(1, _folder, Array.Empty<string>()), "visual.json holds a photo no longer used");
    }

    private sealed class CountingEmbedder(IImageEmbedder inner) : IImageEmbedder
    {
        public int Count { get; set; }

        public string ModelId => inner.ModelId;

        public float[] Embed(VisionImage image)
        {
            Count++;
            return inner.Embed(image);
        }

        public void Dispose() => inner.Dispose();
    }
}

public class ColourHistogramTests
{
    [Fact]
    public void The_middle_of_the_picture_counts_and_its_colours_tell_products_apart()
    {
        var yellow = ColourHistogram.Of(Pictures.Plain(200, 200, 240, 200, 30));
        var yellowOnShelf = Pictures.Plain(200, 200, 150, 120, 100);
        for (var y = 50; y < 150; y++)
        {
            for (var x = 50; x < 150; x++)
            {
                (yellowOnShelf.Rgba[(y * 200 + x) * 4], yellowOnShelf.Rgba[(y * 200 + x) * 4 + 1], yellowOnShelf.Rgba[(y * 200 + x) * 4 + 2]) = (235, 195, 35);
            }
        }

        var blue = ColourHistogram.Of(Pictures.Plain(200, 200, 40, 80, 220));

        Assert.Equal(ColourHistogram.Length, yellow.Length);
        Assert.Equal(1f, VectorMath.Similarity(yellow, yellow), 4);
        Assert.True(VectorMath.Similarity(yellow, ColourHistogram.Of(yellowOnShelf)) > 0.7f);
        Assert.True(VectorMath.Similarity(yellow, blue) < 0.1f);
        Assert.Equal(72, ColourHistogram.Bin(0, 0, 0));
        Assert.Equal(75, ColourHistogram.Bin(255, 255, 255));
    }
}

public class VectorMathTests
{
    [Fact]
    public void Vectors_are_made_unit_length_and_compared_by_their_dot_product()
    {
        Assert.Equal(new[] { 0.6f, 0.8f }, VectorMath.Normalize(new[] { 3f, 4f }));
        Assert.Equal(new[] { 0f, 0f }, VectorMath.Normalize(new[] { 0f, 0f }));
        Assert.Equal(0f, VectorMath.Similarity(new[] { 1f, 0f }, new[] { 1f }));
        Assert.Equal(-1f, VectorMath.Similarity(new[] { 1f, 0f }, new[] { -1f, 0f }));
    }
}

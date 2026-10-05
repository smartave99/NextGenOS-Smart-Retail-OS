using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// The photos the AI makes follow the shape of the owner's phone photo, and a photo can be changed with a few words: the shape is
    /// read from the phone photo as it is shown (a phone's turn noted in EXIF counts), the image tool is asked for the nearest shape it
    /// makes, and the result is trimmed to exactly the owner's shape; a note is kept with the photo waiting to be made again and goes
    /// with the new one.
    /// </summary>
    public class ProductPhotoChangeTests : IDisposable
    {
        private const int Bottle = 1193;

        private readonly TempFolder _temp = new TempFolder();
        private readonly List<ProductPhotoRequest> _requests = new List<ProductPhotoRequest>();
        private readonly ProductPhotoStore _store;
        private DateTime _now = new DateTime(2026, 10, 3, 10, 0, 0);

        public ProductPhotoChangeTests()
        {
            _store = new ProductPhotoStore(Path.Combine(_temp.Path, "Product photos"));
        }

        public void Dispose() => _temp.Dispose();

        /// <summary>A JPEG's header with this size, and a turn in its EXIF part when one is given (little or big endian).</summary>
        internal static byte[] Jpeg(int width, int height, int? orientation = null, bool bigEndian = false)
        {
            var bytes = new List<byte> { 0xFF, 0xD8 };
            if (orientation is int turn)
            {
                var tiff = bigEndian
                    ? new byte[] { (byte)'M', (byte)'M', 0, 42, 0, 0, 0, 8, 0, 1, 0x01, 0x12, 0, 3, 0, 0, 0, 1, 0, (byte)turn, 0, 0, 0, 0, 0, 0 }
                    : new byte[] { (byte)'I', (byte)'I', 42, 0, 8, 0, 0, 0, 1, 0, 0x12, 0x01, 3, 0, 1, 0, 0, 0, (byte)turn, 0, 0, 0, 0, 0, 0, 0 };
                var body = Encoding.ASCII.GetBytes("Exif\0\0").Concat(tiff).ToArray();
                bytes.AddRange(new byte[] { 0xFF, 0xE1, (byte)((body.Length + 2) >> 8), (byte)((body.Length + 2) & 0xFF) });
                bytes.AddRange(body);
            }

            bytes.AddRange(new byte[] { 0xFF, 0xC0, 0, 17, 8, (byte)(height >> 8), (byte)height, (byte)(width >> 8), (byte)width, 3, 1, 0x22, 0, 2, 0x11, 1, 3, 0x11, 1 });
            bytes.AddRange(new byte[] { 0xFF, 0xD9 });
            return bytes.ToArray();
        }

        private string Raw(byte[] content)
        {
            using (var photo = new MemoryStream(content))
            {
                return _store.SaveRaw(Bottle, photo, ".jpg", _now, "Pink Bottle 750 ml");
            }
        }

        private Func<ProductPhotoRequest, CancellationToken, Task<ProductPhotoResult>> Makes() => (request, ct) =>
        {
            _requests.Add(request);
            _now = _now.AddMinutes(1);
            return Task.FromResult(new ProductPhotoResult
            {
                Image = ProductPhotoTests.Png,
                Understanding = request.Describe ? ProductUnderstanding.Parse(ProductPhotoTests.Answer) : null,
                ProviderName = "Codex CLI (OpenAI)",
            });
        };

        // ----- The shape of the owner's photo -----

        [Theory]
        [InlineData(3024, 4032, "portrait", "3:4", "1024 x 1536 (tall)")]
        [InlineData(4032, 3024, "landscape", "4:3", "1536 x 1024 (wide)")]
        [InlineData(3000, 3000, "square", "1:1", "1024 x 1024 (square)")]
        [InlineData(1080, 1350, "portrait", "4:5", "1024 x 1536 (tall)")]
        [InlineData(1920, 1080, "landscape", "16:9", "1536 x 1024 (wide)")]
        [InlineData(1000, 1100, "square", "1000:1100", "1024 x 1024 (square)")]
        [InlineData(1200, 1000, "square", "1200:1000", "1024 x 1024 (square)")]
        [InlineData(1000, 1234, "portrait", "4:5", "1024 x 1536 (tall)")]
        public void The_shape_says_its_orientation_its_ratio_and_the_nearest_shape_the_image_tool_makes(int width, int height, string orientation, string ratio, string tool)
        {
            var shape = new PhotoShape(width, height);

            Assert.Equal((orientation, ratio, tool), (shape.Orientation, shape.RatioText, shape.ToolSize));
        }

        [Fact]
        public void A_ratio_is_written_width_first_and_an_unknown_shape_is_square()
        {
            Assert.Equal("3:4", new PhotoShape(3024, 4032).RatioText);
            Assert.Equal("2:3", new PhotoShape(2000, 3000).RatioText);
            Assert.Equal("9:16", new PhotoShape(1080, 1920).RatioText);
            Assert.Equal("portrait, 3:4 (3024 × 4032 pixels)", new PhotoShape(3024, 4032).Describe());
            Assert.Equal("square", new PhotoShape(0, 0).Describe());
            Assert.Equal("1:1", new PhotoShape(0, 0).RatioText);
            Assert.False(new PhotoShape(0, 100).IsKnown);
        }

        [Fact]
        public void An_image_is_trimmed_from_the_middle_to_exactly_the_owners_shape_and_never_stretched()
        {
            var portrait = new PhotoShape(3024, 4032);

            // The tool's 1024 x 1536 is too tall for 3:4: keep the middle rows.
            Assert.Equal((0, 85, 1024, 1365), portrait.CropTo(1024, 1536));
            // A square result is too wide for 3:4: keep the middle columns.
            Assert.Equal((128, 0, 768, 1024), portrait.CropTo(1024, 1024));
            // Already the shape, within half a percent: left as it is.
            Assert.Equal((0, 0, 1024, 1365), portrait.CropTo(1024, 1365));
            Assert.Equal((0, 0, 1000, 1333), portrait.CropTo(1000, 1333));

            var landscape = new PhotoShape(4000, 3000);
            Assert.Equal((85, 0, 1365, 1024), landscape.CropTo(1536, 1024));
            Assert.Equal((0, 128, 1024, 768), landscape.CropTo(1024, 1024));

            // Not known: nothing is cut.
            Assert.Equal((0, 0, 800, 600), new PhotoShape(0, 0).CropTo(800, 600));
            Assert.True(portrait.Matches(1024, 1365));
            Assert.False(portrait.Matches(1024, 1536));
            Assert.True(new PhotoShape(0, 0).Matches(10, 500));
        }

        [Fact]
        public void The_size_of_a_phone_photo_is_the_size_it_is_shown_with_its_turn_applied()
        {
            // A phone holding a portrait photo stores it as landscape with a turn noted (EXIF 6 or 8): shown, it is portrait.
            foreach (var turn in new[] { 5, 6, 7, 8 })
            {
                Assert.True(ImageFile.TryReadShownSize(Jpeg(4032, 3024, turn), out var width, out var height));
                Assert.Equal((3024, 4032), (width, height));
            }

            foreach (var turn in new[] { 1, 2, 3, 4 })
            {
                Assert.True(ImageFile.TryReadShownSize(Jpeg(4032, 3024, turn), out var width, out var height));
                Assert.Equal((4032, 3024), (width, height));
            }

            Assert.True(ImageFile.TryReadShownSize(Jpeg(4032, 3024, 6, bigEndian: true), out var bigWidth, out var bigHeight));
            Assert.Equal((3024, 4032), (bigWidth, bigHeight));

            // No EXIF, a damaged one, or no JPEG: the stored size, or nothing.
            Assert.True(ImageFile.TryReadShownSize(Jpeg(4032, 3024), out var plainWidth, out _));
            Assert.Equal(4032, plainWidth);
            var broken = Jpeg(4032, 3024, 6);
            Array.Resize(ref broken, 30);
            Assert.False(ImageFile.ExifOrientation(broken) is int);
            Assert.False(ImageFile.TryReadShownSize(new byte[] { 1, 2, 3 }, out _, out _));
            Assert.Null(ImageFile.ExifOrientation(new byte[] { 1, 2, 3 }));
            Assert.Null(ImageFile.ExifOrientation(Jpeg(10, 10, 9)));
            Assert.Null(ImageFile.ExifOrientation(null));

            // A PNG has no turn.
            Assert.True(ImageFile.TryReadShownSize(ProductPhotoTests.Png, out var pngWidth, out var pngHeight));
            Assert.Equal((1024, 768), (pngWidth, pngHeight));
        }

        // ----- The words of a note -----

        [Theory]
        [InlineData("", null)]
        [InlineData(null, null)]
        [InlineData("  make the label easier to read  ", null)]
        [InlineData("brighter, 20% bigger", null)]
        public void A_note_is_a_few_words_and_may_be_empty_or_hold_numbers(string note, string problem)
        {
            Assert.Equal(problem, PhotoNotes.Problem(note));
        }

        [Fact]
        public void A_note_that_is_too_long_or_has_a_control_character_is_refused_and_quotes_cannot_end_it_in_the_prompt()
        {
            Assert.Contains("too long", PhotoNotes.Problem(new string('a', PhotoNotes.MaxLength + 1)));
            Assert.Null(PhotoNotes.Problem(new string('a', PhotoNotes.MaxLength)));
            Assert.Contains("cannot be used", PhotoNotes.Problem("make it\u0007 red"));
            Assert.Equal("make the 'label' clear, then 'more'", PhotoNotes.Tidy("  make the \"label\"\n clear,\t then “more”  "));
        }

        // ----- The prompt -----

        [Fact]
        public void The_prompt_names_the_owners_shape_and_the_tool_size_and_a_photo_with_no_known_shape_stays_square()
        {
            var request = new ProductPhotoRequest { Name = "Pink Bottle", Code = "PP", Kind = PhotoKind.InUse, ReferenceWidth = 3024, ReferenceHeight = 4032 };
            var known = ProductPhotoPrompt.CodexPrompt(request);

            Assert.Contains("The owner's phone photo is portrait, 3:4 (3024 × 4032 pixels): the photo you make has the same shape and orientation.", known);
            Assert.Contains("The image is portrait, the same shape as the owner's phone photo (3:4): make it 1024 x 1536 (tall)", known);
            Assert.DoesNotContain("Square image.", known);

            request.Kind = PhotoKind.WhiteBackground;
            var white = ProductPhotoPrompt.CodexPrompt(request);
            Assert.Contains("filling about 85% of a portrait image", white);
            Assert.Contains("make it 1024 x 1536 (tall)", white);

            request.ReferenceWidth = request.ReferenceHeight = 0;
            var unknown = ProductPhotoPrompt.CodexPrompt(request);
            Assert.Contains("filling about 85% of a square image", unknown);
            Assert.DoesNotContain("owner's phone photo is", unknown);

            request.Kind = PhotoKind.EuropeanModel;
            Assert.Contains("Square image.", ProductPhotoPrompt.CodexPrompt(request));
        }

        [Fact]
        public void A_change_gives_the_photo_before_first_with_the_owners_words_and_the_rules_still_hold()
        {
            var before = _temp.File("in-use-20261003-100100.png", "before");
            var request = new ProductPhotoRequest
            {
                Name = "Pink Bottle",
                Code = "PP",
                Kind = PhotoKind.InUse,
                RawPhotos = new List<string> { _temp.File("raw.jpg", "raw") },
                CataloguePhoto = _temp.File("white-20261003-100000.png", "white"),
                PreviousPhoto = before,
                Note = "make the \"label\" easier to read",
            };

            Assert.True(request.IsChange);
            Assert.Equal(new[] { before, request.CataloguePhoto, request.RawPhotos[0] }, request.Attachments());
            var prompt = ProductPhotoPrompt.CodexPrompt(request);
            Assert.Contains("The owner asks for this change to the photo you made before: \"make the 'label' easier to read\".", prompt);
            Assert.Contains("keeping everything the same except this change", prompt);
            Assert.Contains("if the change asks for text, a price, an offer, a logo, a watermark or a different product, leave that part out", prompt);
            Assert.Contains("The first attached photo is the photo you made before, which the owner wants changed.", prompt);
            Assert.Contains("The next attached photo is a catalogue photo of it made earlier", prompt);
            Assert.Contains("make the photo again from the first attached photo, with the change.", prompt);
            Assert.Contains("Keep the product exactly as it is", prompt);
            Assert.False(request.Describe, "a change to the white photo does not describe the product again");

            // No note, or no photo before: a plain new photo.
            request.Note = "";
            Assert.False(request.IsChange);
            Assert.DoesNotContain("asks for this change", ProductPhotoPrompt.CodexPrompt(request));
            Assert.Equal(new[] { request.CataloguePhoto, request.RawPhotos[0] }, request.Attachments());
        }

        [Fact]
        public void A_request_with_a_bad_note_or_a_photo_before_that_is_not_there_cannot_be_run()
        {
            var request = new ProductPhotoRequest
            {
                Name = "Pink Bottle",
                RawPhotos = new List<string> { _temp.File("raw.jpg", "raw") },
                PreviousPhoto = _temp.File("in-use-20261003-100100.png", "before"),
                Note = new string('a', PhotoNotes.MaxLength + 1),
            };
            Assert.Contains("too long", request.Problem());

            request.Note = "brighter";
            Assert.Null(request.Problem());

            File.Delete(request.PreviousPhoto);
            Assert.Contains("was not found", request.Problem());
        }

        // ----- The store: a note waits with its photo and goes onto the new one -----

        [Fact]
        public void A_note_waits_with_the_photo_to_make_again_and_goes_onto_the_new_photo()
        {
            var set = _store.StartSet(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Jpeg(3024, 4032)) }, _now);
            foreach (var kind in PhotoKinds.All)
            {
                _store.SaveImage(Bottle, set.Id, kind, new ProductPhotoResult { Image = ProductPhotoTests.Png }, _now = _now.AddMinutes(1));
            }

            Assert.True(_store.QueueChange(Bottle, set.Id, PhotoKind.InUse, "  make the \"label\" clear "));
            var queued = _store.Load(Bottle).LatestSet;
            Assert.Equal(new[] { PhotoKind.InUse }, queued.Pending);
            Assert.Equal("make the 'label' clear", queued.PendingNotes[PhotoKind.InUse]);
            Assert.Equal("", queued.Latest(PhotoKind.InUse).Note);

            _store.SaveImage(Bottle, set.Id, PhotoKind.InUse, new ProductPhotoResult { Image = ProductPhotoTests.Png }, _now = _now.AddMinutes(1));
            var made = _store.Load(Bottle).LatestSet;
            Assert.Empty(made.Pending);
            Assert.Empty(made.PendingNotes);
            Assert.Equal("make the 'label' clear", made.Latest(PhotoKind.InUse).Note);
            Assert.Equal("", made.Images.Last(image => image.Kind == PhotoKind.InUse).Note);
            Assert.Equal("", made.Latest(PhotoKind.WhiteBackground).Note);
        }

        [Fact]
        public void A_plain_make_again_drops_an_earlier_note_and_skipping_drops_it_too()
        {
            var set = _store.StartSet(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Jpeg(3024, 4032)) }, _now);
            _store.QueueChange(Bottle, set.Id, PhotoKind.InUse, "brighter");
            _store.QueueChange(Bottle, set.Id, PhotoKind.InUse, "");
            Assert.Empty(_store.Load(Bottle).LatestSet.PendingNotes);

            _store.QueueChange(Bottle, set.Id, PhotoKind.IndianModel, "a smile");
            _store.Skip(Bottle, set.Id, PhotoKind.IndianModel);
            Assert.Empty(_store.Load(Bottle).LatestSet.PendingNotes);
            Assert.DoesNotContain(PhotoKind.IndianModel, _store.Load(Bottle).LatestSet.Pending);
            Assert.Throws<ArgumentException>(() => _store.QueueChange(Bottle, set.Id, PhotoKind.InUse, new string('a', 301)));
        }

        [Fact]
        public void A_note_written_into_the_file_by_hand_is_screened_when_it_is_read()
        {
            var set = _store.StartSet(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Jpeg(3024, 4032)) }, _now);
            _store.QueueChange(Bottle, set.Id, PhotoKind.InUse, "brighter");
            var file = Path.Combine(_store.FolderOf(Bottle), "product.json");
            var text = File.ReadAllText(file).Replace("\"brighter\"", "\"" + new string('x', 400) + "\"");
            File.WriteAllText(file, text);

            Assert.Empty(_store.Load(Bottle).LatestSet.PendingNotes);
            Assert.Contains(PhotoKind.InUse, _store.Load(Bottle).LatestSet.Pending);
        }

        // ----- The maker -----

        [Fact]
        public async Task A_photo_is_made_in_the_shape_of_the_owners_first_phone_photo_as_it_is_shown()
        {
            var maker = new ProductPhotoMaker(_store, Makes(), () => _now);

            // Stored landscape, with the turn of a portrait photo.
            maker.Start(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Jpeg(4032, 3024, 6)), Raw(Jpeg(1000, 1000)) });
            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(5, _requests.Count);
            Assert.All(_requests, request =>
            {
                Assert.Equal((3024, 4032), (request.ReferenceWidth, request.ReferenceHeight));
                Assert.Equal("portrait", request.Shape.Orientation);
            });
        }

        [Fact]
        public async Task A_photo_the_tool_made_is_trimmed_to_the_owners_shape_and_one_that_cannot_be_trimmed_is_kept()
        {
            var fits = new List<(byte[] Image, PhotoShape Shape)>();
            var trimmed = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 9, 9, 9, 9 };
            var errors = new List<Exception>();
            var maker = new ProductPhotoMaker(_store, Makes(), () => _now, fit: (image, shape) =>
            {
                fits.Add((image, shape));
                return fits.Count == 2 ? throw new InvalidOperationException("no decoder") : trimmed;
            });
            maker.Error += errors.Add;

            maker.Start(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Jpeg(3024, 4032)) });
            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(5, fits.Count);
            Assert.All(fits, fit => Assert.Equal(3024, fit.Shape.Width));
            var set = _store.Load(Bottle).LatestSet;
            Assert.Equal(5, set.MadeCount);
            Assert.Equal(trimmed, File.ReadAllBytes(_store.PathOf(Bottle, set.Latest(PhotoKind.WhiteBackground).File)));
            Assert.Equal(ProductPhotoTests.Png, File.ReadAllBytes(_store.PathOf(Bottle, set.Latest(PhotoKind.InUse).File)));
            Assert.Equal("no decoder", Assert.Single(errors).Message);
        }

        [Fact]
        public async Task Without_a_known_shape_nothing_is_trimmed()
        {
            var fitted = 0;
            var maker = new ProductPhotoMaker(_store, Makes(), () => _now, fit: (image, shape) =>
            {
                fitted++;
                return image;
            });

            maker.Start(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Encoding.UTF8.GetBytes("not a picture")) });
            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(0, fitted);
            Assert.All(_requests, request => Assert.False(request.Shape.IsKnown));
        }

        [Fact]
        public async Task Making_a_photo_again_with_a_note_changes_the_photo_made_before_and_keeps_the_note_with_the_new_one()
        {
            var maker = new ProductPhotoMaker(_store, Makes(), () => _now);
            maker.Start(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Jpeg(3024, 4032)) });
            await maker.MakeNextAsync(CancellationToken.None);
            _requests.Clear();
            var before = _store.Load(Bottle).LatestSet.Latest(PhotoKind.InUse);

            maker.MakeAgain(Bottle, PhotoKind.InUse, "make the label easier to read");
            Assert.Equal(1, maker.PlaceInQueue(Bottle));
            await maker.MakeNextAsync(CancellationToken.None);

            var request = Assert.Single(_requests);
            Assert.Equal(PhotoKind.InUse, request.Kind);
            Assert.True(request.IsChange);
            Assert.Equal("make the label easier to read", request.Note);
            Assert.Equal(_store.PathOf(Bottle, before.File), request.PreviousPhoto);
            Assert.Equal((3024, 4032), (request.ReferenceWidth, request.ReferenceHeight));

            var set = _store.Load(Bottle).LatestSet;
            Assert.Empty(set.Pending);
            Assert.Empty(set.PendingNotes);
            Assert.Equal("make the label easier to read", set.Latest(PhotoKind.InUse).Note);
            Assert.NotEqual(before.File, set.Latest(PhotoKind.InUse).File);
            Assert.Equal(2, set.Images.Count(image => image.Kind == PhotoKind.InUse));
            Assert.True(File.Exists(_store.PathOf(Bottle, before.File)), "the earlier photo is kept");
        }

        [Fact]
        public async Task A_change_that_fails_keeps_its_note_for_the_next_try()
        {
            var fail = false;
            var maker = new ProductPhotoMaker(_store, (request, ct) =>
            {
                if (fail && request.IsChange)
                {
                    throw new AiProviderException("codex-cli", "Codex is busy.");
                }

                return Makes()(request, ct);
            }, () => _now);
            maker.Start(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Jpeg(3024, 4032)) });
            await maker.MakeNextAsync(CancellationToken.None);

            fail = true;
            maker.MakeAgain(Bottle, PhotoKind.EuropeanModel, "she should smile");
            await maker.MakeNextAsync(CancellationToken.None);
            var stopped = _store.Load(Bottle).LatestSet;
            Assert.Equal("Codex is busy.", stopped.Problem);
            Assert.Equal("she should smile", stopped.PendingNotes[PhotoKind.EuropeanModel]);

            fail = false;
            _requests.Clear();
            maker.Continue(Bottle);
            await maker.MakeNextAsync(CancellationToken.None);
            Assert.Equal("she should smile", Assert.Single(_requests).Note);
            Assert.Equal("she should smile", _store.Load(Bottle).LatestSet.Latest(PhotoKind.EuropeanModel).Note);
        }

        [Fact]
        public void A_note_that_is_too_long_is_refused_before_anything_is_queued()
        {
            var maker = new ProductPhotoMaker(_store, Makes(), () => _now);
            maker.Start(Bottle, "PP", "Pink Bottle", "", new[] { Raw(Jpeg(3024, 4032)) });

            var error = Assert.Throws<ArgumentException>(() => maker.MakeAgain(Bottle, PhotoKind.InUse, new string('a', 400)));

            Assert.Contains("too long", error.Message);
            Assert.Empty(_store.Load(Bottle).LatestSet.PendingNotes);
        }
    }
}

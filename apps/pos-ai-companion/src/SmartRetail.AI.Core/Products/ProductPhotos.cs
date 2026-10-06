using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Products
{
    /// <summary>
    /// The five photos made for every product, in the order they are made. The last three show a person; who, and the titles on the screen, come from the customer's
    /// profile (<see cref="ShopProfile"/>). The names here are the slots' stable ids, kept because they are in file names and in what the website was sent.
    /// </summary>
    public enum PhotoKind
    {
        /// <summary>The product alone on pure white: the main image Amazon and online shops ask for.</summary>
        WhiteBackground,

        /// <summary>The product in a real place where it is used.</summary>
        InUse,

        EuropeanModel,

        IndianModel,

        EastAsianModel,
    }

    public static class PhotoKinds
    {
        public static readonly IReadOnlyList<PhotoKind> All = (PhotoKind[])Enum.GetValues(typeof(PhotoKind));

        /// <summary>1 to 5, the order the photos are made and listed in.</summary>
        public static int Number(this PhotoKind kind) => (int)kind + 1;

        /// <summary>The photo's title with no profile: the neutral one ("Model 1" for the first photo with a person).</summary>
        public static string Title(this PhotoKind kind) => kind.Title(null);

        /// <summary>The photo's title on the screen: the customer's own for the photos with a person (e.g. "Filipino model"), else "White background" and "In use".</summary>
        public static string Title(this PhotoKind kind, ShopProfile shop)
        {
            switch (kind)
            {
                case PhotoKind.WhiteBackground: return "White background";
                case PhotoKind.InUse: return "In use";
                default: return (shop ?? ShopProfile.Neutral).ModelAt(kind.ModelIndex()).Title;
            }
        }

        /// <summary>0, 1 or 2 for the three photos with a person; throws for the others.</summary>
        public static int ModelIndex(this PhotoKind kind) =>
            kind.IsModel() ? (int)kind - (int)PhotoKind.EuropeanModel : throw new ArgumentOutOfRangeException(nameof(kind), "Only photos 3 to 5 have a model.");

        /// <summary>How the kind's files start, e.g. "in-use-20260924-101500.png".</summary>
        public static string FilePrefix(this PhotoKind kind) => kind switch
        {
            PhotoKind.WhiteBackground => "white",
            PhotoKind.InUse => "in-use",
            PhotoKind.EuropeanModel => "european-model",
            PhotoKind.IndianModel => "indian-model",
            PhotoKind.EastAsianModel => "east-asian-model",
            _ => throw new ArgumentOutOfRangeException(nameof(kind)),
        };

        public static bool IsModel(this PhotoKind kind) => kind >= PhotoKind.EuropeanModel;
    }

    /// <summary>One photo to make of a product, from its phone photos.</summary>
    public sealed class ProductPhotoRequest
    {
        public const int MaxPhotos = 4;
        public const long MaxPhotoBytes = 20L * 1024 * 1024;

        public static readonly string[] PhotoExtensions = { ".jpg", ".jpeg", ".png", ".webp" };

        public int ProductId { get; set; }

        public string Code { get; set; } = "";

        public string Name { get; set; } = "";

        public string Category { get; set; } = "";

        /// <summary>The phone photos, as full paths.</summary>
        public List<string> RawPhotos { get; set; } = new List<string>();

        public PhotoKind Kind { get; set; } = PhotoKind.WhiteBackground;

        /// <summary>The customer's business: its country, kind and who the model photos show (from its profile). Neutral when not given.</summary>
        public ShopProfile Shop { get; set; } = ShopProfile.Neutral;

        /// <summary>The white-background photo made earlier, if any, so every photo shows the same product. Optional.</summary>
        public string CataloguePhoto { get; set; }

        /// <summary>The size of the owner's first phone photo as it is shown, in pixels; 0 when it is not known. The photo made follows
        /// its shape (<see cref="Shape"/>).</summary>
        public int ReferenceWidth { get; set; }

        public int ReferenceHeight { get; set; }

        /// <summary>The shape the photo is made in: the owner's photo's.</summary>
        public PhotoShape Shape => new PhotoShape(ReferenceWidth, ReferenceHeight);

        /// <summary>What the owner asks to change in this kind of photo, in a few words (see <see cref="PhotoNotes"/>); empty for a new photo.</summary>
        public string Note { get; set; } = "";

        /// <summary>The photo made before, to change as the owner asks; only with a <see cref="Note"/>. Optional.</summary>
        public string PreviousPhoto { get; set; }

        /// <summary>The owner asked for a change to the photo made before.</summary>
        public bool IsChange => !string.IsNullOrWhiteSpace(Note) && !string.IsNullOrEmpty(PreviousPhoto);

        /// <summary>What the AI understood earlier: what the product is, where it is used and who uses it. Optional.</summary>
        public ProductUnderstanding Understanding { get; set; }

        /// <summary>Whether to ask the AI to describe the product as well. Done with the white-background photo, not when the owner only
        /// asks for a change to it.</summary>
        public bool Describe => Kind == PhotoKind.WhiteBackground && !IsChange;

        /// <summary>The photos to attach: the photo to change first (for a change), then the catalogue photo, then the phone photos, at
        /// most <see cref="MaxPhotos"/> in all.</summary>
        public IReadOnlyList<string> Attachments()
        {
            var attachments = new List<string>();
            if (IsChange)
            {
                attachments.Add(PreviousPhoto);
            }

            if (!string.IsNullOrEmpty(CataloguePhoto))
            {
                attachments.Add(CataloguePhoto);
            }

            attachments.AddRange((RawPhotos ?? new List<string>()).Take(MaxPhotos - attachments.Count));
            return attachments;
        }

        /// <summary>Why the request cannot be run, or null when it can.</summary>
        public string Problem()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return "The product has no name.";
            }

            if (RawPhotos == null || RawPhotos.Count == 0)
            {
                return "Add at least one photo of the product.";
            }

            if (RawPhotos.Count > MaxPhotos)
            {
                return "Use at most " + MaxPhotos + " photos of one product.";
            }

            if (PhotoNotes.Problem(Note) is string noteProblem)
            {
                return noteProblem;
            }

            foreach (var photo in RawPhotos.Concat(string.IsNullOrEmpty(CataloguePhoto) ? new string[0] : new[] { CataloguePhoto })
                         .Concat(string.IsNullOrEmpty(PreviousPhoto) ? new string[0] : new[] { PreviousPhoto }))
            {
                if (!PhotoExtensions.Contains(Path.GetExtension(photo ?? "").ToLowerInvariant()))
                {
                    return "Photos must be JPG, PNG or WEBP files.";
                }

                var file = new FileInfo(photo);
                if (!file.Exists)
                {
                    return "The photo " + Path.GetFileName(photo) + " was not found.";
                }

                if (file.Length > MaxPhotoBytes)
                {
                    return "The photo " + Path.GetFileName(photo) + " is larger than 20 MB.";
                }
            }

            return null;
        }
    }

    /// <summary>
    /// What the owner may ask when a photo the AI made needs a small change ("make the label easier to read", "less shine"): a few
    /// words in the owner's own language, kept to one line and a few hundred letters, as it goes into the AI's instructions.
    /// </summary>
    public static class PhotoNotes
    {
        public const int MaxLength = 300;

        /// <summary>The words on one line, without quotes that would end them in the prompt.</summary>
        public static string Tidy(string note) =>
            System.Text.RegularExpressions.Regex.Replace((note ?? "").Replace('"', '\'').Replace('“', '\'').Replace('”', '\''), @"\s+", " ").Trim();

        /// <summary>What is wrong with the words, for the owner; null when they are fine (empty is fine: it asks for no change).</summary>
        public static string Problem(string note)
        {
            var text = Tidy(note);
            if (text.Length > MaxLength)
            {
                return "What to change is too long: at most " + MaxLength + " letters.";
            }

            foreach (var letter in text)
            {
                if (char.IsControl(letter))
                {
                    return "What to change has a character that cannot be used.";
                }
            }

            return null;
        }
    }

    /// <summary>What the AI saw in the photos, in words a shop assistant would use.</summary>
    public sealed class ProductUnderstanding
    {
        /// <summary>A clear name for customers, e.g. "Pink Flip-Top Water Bottle, 750 ml".</summary>
        public string DisplayName { get; set; } = "";

        /// <summary>One short phrase, e.g. "a pink plastic water bottle with a flip-top lid".</summary>
        public string WhatItIs { get; set; } = "";

        /// <summary>Two sentences for a catalogue or a WhatsApp message.</summary>
        public string Description { get; set; } = "";

        public string ProductType { get; set; } = "";

        public string SuggestedCategory { get; set; } = "";

        public List<string> Colours { get; set; } = new List<string>();

        public string Material { get; set; } = "";

        public string SizeOrQuantity { get; set; } = "";

        public List<string> Keywords { get; set; } = new List<string>();

        /// <summary>The product's common name in the second language of the shop's posters (the profile's), in its own script; empty when the shop has none.</summary>
        public string LocalName { get; set; } = "";

        /// <summary>Product files written before the second language was a setting called it by one language's name: read, never written.</summary>
        [JsonProperty("HindiName")]
        private string LegacyLocalName
        {
            set
            {
                if (string.IsNullOrEmpty(LocalName))
                {
                    LocalName = value ?? "";
                }
            }
        }

        /// <summary>A real place where the product is used, for the lifestyle photos.</summary>
        public string UseCaseScene { get; set; } = "";

        /// <summary>Who to show with the product: the gender and age of its typical buyer or user, e.g. "a woman in her early 30s".</summary>
        public string ModelPerson { get; set; } = "";

        /// <summary>What could not be seen or read, e.g. a label too small to read.</summary>
        public string Notes { get; set; } = "";

        /// <summary>Reads the AI's JSON answer; tolerates a Markdown code fence and missing fields. Null when there is none.</summary>
        public static ProductUnderstanding Parse(string text)
        {
            var body = (text ?? "").Trim();
            var start = body.IndexOf('{');
            var end = body.LastIndexOf('}');
            if (start < 0 || end <= start)
            {
                return null;
            }

            JObject json;
            try
            {
                json = JObject.Parse(body.Substring(start, end - start + 1));
            }
            catch (JsonException)
            {
                return null;
            }

            var understanding = new ProductUnderstanding
            {
                DisplayName = Text(json, "display_name"),
                WhatItIs = Text(json, "what_it_is"),
                Description = Text(json, "description"),
                ProductType = Text(json, "product_type"),
                SuggestedCategory = Text(json, "suggested_category"),
                Colours = List(json, "colours"),
                Material = Text(json, "material"),
                SizeOrQuantity = Text(json, "size_or_quantity"),
                Keywords = List(json, "keywords"),
                LocalName = Text(json, "local_name").Length > 0 ? Text(json, "local_name") : Text(json, "hindi_name"),
                UseCaseScene = Text(json, "use_case_scene"),
                ModelPerson = Text(json, "model_person"),
                Notes = Text(json, "notes"),
            };

            return understanding.WhatItIs.Length == 0 && understanding.DisplayName.Length == 0 && understanding.Description.Length == 0
                ? null
                : understanding;
        }

        private static string Text(JObject json, string name)
        {
            var value = json[name];
            return value == null || value.Type == JTokenType.Null ? "" : Clip(value.ToString().Trim(), 600);
        }

        private static List<string> List(JObject json, string name)
        {
            return json[name] is JArray array
                ? array.Select(item => Clip(item.ToString().Trim(), 60)).Where(item => item.Length > 0).Distinct(StringComparer.OrdinalIgnoreCase).Take(12).ToList()
                : new List<string>();
        }

        private static string Clip(string text, int length) => text.Length <= length ? text : text.Substring(0, length);
    }

    /// <summary>A photo made by the AI and, for the white-background photo, what it understood about the product.</summary>
    public sealed class ProductPhotoResult
    {
        public byte[] Image { get; set; }

        /// <summary>Null when the AI was not asked to, or did not, describe the product.</summary>
        public ProductUnderstanding Understanding { get; set; }

        public string ProviderName { get; set; } = "";

        public TimeSpan Duration { get; set; }
    }

    /// <summary>What the AI is asked to do for each of the five photos.</summary>
    public static class ProductPhotoPrompt
    {
        public const string ResultFileName = "clean.png";

        /// <summary>A strict JSON schema: every field required, nothing else allowed.</summary>
        private const string SchemaTemplate = @"{
  ""type"": ""object"",
  ""additionalProperties"": false,
  ""required"": [""display_name"", ""what_it_is"", ""description"", ""product_type"", ""suggested_category"", ""colours"", ""material"", ""size_or_quantity"", ""keywords"", ""local_name"", ""use_case_scene"", ""model_person"", ""notes""],
  ""properties"": {
    ""display_name"": { ""type"": ""string"", ""description"": ""A clear product name for customers, with size or pack if visible."" },
    ""what_it_is"": { ""type"": ""string"", ""description"": ""A short phrase saying what the product is, e.g. a pink plastic water bottle with a flip-top lid."" },
    ""description"": { ""type"": ""string"", ""description"": ""Two plain sentences for a catalogue or a WhatsApp message."" },
    ""product_type"": { ""type"": ""string"" },
    ""suggested_category"": { ""type"": ""string"", ""description"": ""A shop category, e.g. Home Essentials > Bottles."" },
    ""colours"": { ""type"": ""array"", ""items"": { ""type"": ""string"" } },
    ""material"": { ""type"": ""string"" },
    ""size_or_quantity"": { ""type"": ""string"" },
    ""keywords"": { ""type"": ""array"", ""items"": { ""type"": ""string"" }, ""description"": ""Words customers would search for."" },
    ""local_name"": { ""type"": ""string"", ""description"": ""{LOCAL_NAME}"" },
    ""use_case_scene"": { ""type"": ""string"", ""description"": ""A real place where the product is used, for a lifestyle photo, e.g. a sunny kitchen counter while cooking dinner."" },
    ""model_person"": { ""type"": ""string"", ""description"": ""The person to show with the product: the gender and age of its typical buyer or user, e.g. a woman in her early 30s. An adult; for a product made for children, a parent."" },
    ""notes"": { ""type"": ""string"", ""description"": ""Anything that could not be seen or read; empty if none."" }
  }
}";

        /// <summary>The schema with no second language: the local name is to be left empty.</summary>
        public static string UnderstandingSchema => SchemaFor(null);

        /// <summary>The schema for a shop: the local name is asked for in its second language, in that language's own script, or left empty when it has none.</summary>
        public static string SchemaFor(ShopProfile shop)
        {
            var language = (shop ?? ShopProfile.Neutral).LocalLanguage;
            return SchemaTemplate.Replace("{LOCAL_NAME}", language.Length > 0 ? "The common " + language + " name, in the script " + language + " is written in." : "Leave empty.");
        }

        private const string KeepTheProduct =
            " Keep the product exactly as it is in the photos: the same shape, proportions, materials, finish, colours, printed text, labels, logos"
            + " and working parts (such as caps, buttons and handles). Do not redesign it, and do not invent features, finishes, branding, labels or accessories."
            + " Do not add, remove or change any text or logo on the product. No watermark, no border and no added text or graphics.";

        private static string LikeARealPhoto(PhotoShape shape) =>
            " It must look like a real photograph, not a render or an illustration: natural light, real textures and a real place,"
            + " shot on a professional camera with a shallow depth of field." + ShapeSentence(shape);

        /// <summary>The shape of the picture: the owner's phone photo's, within what the image tool makes, and trimmed to it afterwards.
        /// A square one when the owner's photo is not known.</summary>
        private static string ShapeSentence(PhotoShape shape) =>
            shape == null || !shape.IsKnown
                ? " Square image."
                : " The image is " + shape.Orientation + ", the same shape as the owner's phone photo (" + shape.RatioText + "): make it " + shape.ToolSize
                    + ", with everything that matters kept away from the edges, as it is trimmed a little to fit that shape exactly.";

        private static string FrameOf(PhotoShape shape) => (shape == null || !shape.IsKnown ? "square" : shape.Orientation) + " image";

        /// <summary>How the model in photos 3 to 5 looks, as the customer's profile says; empty when it asks for no look.</summary>
        public static string ModelLooks(PhotoKind kind, ShopProfile shop = null) => (shop ?? ShopProfile.Neutral).ModelAt(kind.ModelIndex()).Looks;

        public static string ImageInstructions(PhotoKind kind, ProductUnderstanding understanding = null, PhotoShape shape = null, ShopProfile shop = null)
        {
            shop = shop ?? ShopProfile.Neutral;
            var scene = string.IsNullOrWhiteSpace(understanding?.UseCaseScene)
                ? shop.TypicalPlace
                : understanding.UseCaseScene.Trim().TrimEnd('.');
            var person = string.IsNullOrWhiteSpace(understanding?.ModelPerson)
                ? "an adult whose gender and age suit the product's typical buyer or user"
                : understanding.ModelPerson.Trim().TrimEnd('.');

            switch (kind)
            {
                case PhotoKind.WhiteBackground:
                    return "Edit the phone photo into the product's main catalogue image, as Amazon and online shops require: the product alone"
                        + " on a pure white background (RGB 255, 255, 255), centred and filling about 85% of a " + FrameOf(shape) + ", with soft even"
                        + " studio lighting and a subtle natural shadow under it. Remove everything that is not the product, such as hands,"
                        + " the table, other items and price stickers. No props and no people."
                        + (shape != null && shape.IsKnown ? ShapeSentence(shape) : "") + KeepTheProduct;
                case PhotoKind.InUse:
                    return "Make a lifestyle photo of the product being used in a real place: " + scene + "."
                        + " The product is the hero: large, in sharp focus and well lit, with the background softly blurred."
                        + " Hands may appear using the product, but no faces." + LikeARealPhoto(shape) + KeepTheProduct;
                default:
                    var looks = ModelLooks(kind, shop);
                    return "Make an emotional lifestyle photo of one model, " + person + (looks.Length > 0 ? " (" + looks + ")" : "") + ", using or holding the product in "
                        + scene + ". Capture a genuine moment that shows how the product makes them feel, such as joy, comfort, confidence or"
                        + " pride, with a natural expression rather than a posed stock-photo smile. The product is clearly visible, in focus"
                        + " and at its real size. Modest everyday clothes that suit the scene, with no logos." + LikeARealPhoto(shape) + KeepTheProduct;
            }
        }

        /// <summary>The whole task for Codex: make the photo with its image tool, save it, then answer.</summary>
        public static string CodexPrompt(ProductPhotoRequest request)
        {
            var attachments = request.Attachments();
            var category = string.IsNullOrWhiteSpace(request.Category) ? "" : ", category " + request.Category.Trim();
            var text = "You are making product photos for " + (request.Shop ?? ShopProfile.Neutral).Shop + ", for its website and for Amazon.\n"
                + (attachments.Count == 1 ? "The attached photo shows" : "The attached photos show")
                + " one product from the shop: \"" + request.Name.Trim() + "\" (code " + (request.Code ?? "").Trim() + category + ").\n";
            if (request.IsChange)
            {
                text += "The first attached photo is the photo you made before, which the owner wants changed.\n";
            }

            if (!string.IsNullOrEmpty(request.CataloguePhoto))
            {
                text += (request.IsChange ? "The next attached photo" : "The first attached photo") + " is a catalogue photo of it made earlier; the others are the original phone photos."
                    + " Where they differ, trust the phone photos.\n";
            }
            else if (request.IsChange)
            {
                text += "The others are the original phone photos. Where they differ, trust the phone photos.\n";
            }

            if (!string.IsNullOrWhiteSpace(request.Understanding?.WhatItIs))
            {
                text += "It is " + request.Understanding.WhatItIs.Trim().TrimEnd('.') + ".\n";
            }

            text += "This is photo " + request.Kind.Number() + " of " + PhotoKinds.All.Count + ": " + request.Kind.Title(request.Shop) + ".\n";
            if (request.Shape.IsKnown)
            {
                text += "The owner's phone photo is " + request.Shape.Describe() + ": the photo you make has the same shape and orientation.\n";
            }

            if (request.IsChange)
            {
                text += "The owner asks for this change to the photo you made before: \"" + PhotoNotes.Tidy(request.Note) + "\". Make it again, keeping everything"
                    + " the same except this change. Everything below still holds: if the change asks for text, a price, an offer, a logo, a watermark or"
                    + " a different product, leave that part out.\n";
            }

            text += "\n1. Use your image generation tool to " + (request.IsChange ? "make the photo again from the first attached photo, with the change. " : request.Kind == PhotoKind.WhiteBackground ? "edit the attached photo. " : "make this photo. ")
                + ImageInstructions(request.Kind, request.Understanding, request.Shape, request.Shop) + "\n"
                + "2. Copy the final image into the current folder as " + ResultFileName + ". Do not leave it only in the Codex home folder,"
                + " and do not create any other files.\n";
            return text + (request.Describe
                ? "3. Then answer with JSON only, matching the given schema, describing the product as a shop assistant would from what you can see."
                    + " Do not guess brand names, sizes or prices you cannot read; mention them in notes instead."
                : "3. Then answer with one short sentence saying what the photo shows.");
        }
    }
}

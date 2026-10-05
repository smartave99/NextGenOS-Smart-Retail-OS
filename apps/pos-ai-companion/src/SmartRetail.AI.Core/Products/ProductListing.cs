using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Products
{
    /// <summary>What Amazon asks for when a product is listed: the title, five bullet points, the description, the
    /// hidden search terms, and the product's details. Never a price: the shop sets it.</summary>
    public sealed class AmazonListing
    {
        public string Title { get; set; } = "";

        public List<string> Bullets { get; set; } = new List<string>();

        public string Description { get; set; } = "";

        /// <summary>Words shoppers search for that are not in the title, as Amazon's "search terms" (at most 249 bytes).</summary>
        public string SearchTerms { get; set; } = "";

        /// <summary>Only when it can be read on the product; empty otherwise.</summary>
        public string Brand { get; set; } = "";

        /// <summary>What the product is in two or three words, e.g. "Water Bottle" (Amazon.in asks for it).</summary>
        public string GenericName { get; set; } = "";

        public string Colour { get; set; } = "";

        public string Material { get; set; } = "";

        public string Size { get; set; } = "";

        public string ItemCount { get; set; } = "";

        public string Included { get; set; } = "";

        public string ProductType { get; set; } = "";
    }

    /// <summary>One line of a product's details, e.g. "Material: Plastic".</summary>
    public sealed class ListingSpec
    {
        public string Key { get; set; } = "";

        public string Value { get; set; } = "";
    }

    /// <summary>What the shop's own website shows for a product, in the fields its products have.</summary>
    public sealed class WebsiteListing
    {
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public List<string> Highlights { get; set; } = new List<string>();

        public List<ListingSpec> Specifications { get; set; } = new List<ListingSpec>();

        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>A category to put it in, e.g. "Home &amp; Kitchen &gt; Bottles".</summary>
        public string Category { get; set; } = "";
    }

    /// <summary>
    /// A product's listings for Amazon and the shop's website, written by the AI from its photos, and kept with the
    /// photos so they are not written again. The owner can change any word; prices always come from the POS.
    /// </summary>
    public sealed class ProductListing
    {
        /// <summary>
        /// The one name the product is shown by on the shop's website and on Amazon (its title there). The POS keeps its own name for the
        /// product, which is never shown to customers here and never changed by this app.
        /// </summary>
        public string DisplayName { get; set; } = "";

        public AmazonListing Amazon { get; set; } = new AmazonListing();

        public WebsiteListing Website { get; set; } = new WebsiteListing();

        public DateTime Written { get; set; }

        /// <summary>Who wrote it, e.g. "Codex CLI (OpenAI)", or "You" once the owner changed it.</summary>
        public string Provider { get; set; } = "";

        /// <summary>The photo set it was written from.</summary>
        public string SetId { get; set; } = "";

        /// <summary>When the owner last changed it by hand; null when it is as the AI wrote it.</summary>
        public DateTime? Edited { get; set; }

        /// <summary>What was taken out of the AI's words, e.g. a price, for the owner to know.</summary>
        public List<string> Notes { get; set; } = new List<string>();

        [JsonIgnore]
        public bool IsEmpty => string.IsNullOrWhiteSpace(DisplayName) && string.IsNullOrWhiteSpace(Amazon?.Title) && string.IsNullOrWhiteSpace(Website?.Name);

        /// <summary>The one name: the display name, else (for a listing kept when the website and Amazon had a name each) the website's name,
        /// else Amazon's title.</summary>
        [JsonIgnore]
        public string PublicName =>
            !string.IsNullOrWhiteSpace(DisplayName) ? DisplayName.Trim()
            : !string.IsNullOrWhiteSpace(Website?.Name) ? Website.Name.Trim()
            : (Amazon?.Title ?? "").Trim();

        /// <summary>Makes Amazon's title and the website's name the display name, so the listing has one name; returns the listing.</summary>
        public ProductListing WithOneName()
        {
            var name = PublicName;
            DisplayName = name;
            Amazon = Amazon ?? new AmazonListing();
            Website = Website ?? new WebsiteListing();
            Amazon.Title = name;
            Website.Name = name;
            return this;
        }

        public ProductListing Copy() => JsonConvert.DeserializeObject<ProductListing>(JsonConvert.SerializeObject(this));

        /// <summary>Reads the AI's JSON answer; tolerates a Markdown code fence and missing fields. Null when there is none.</summary>
        public static ProductListing Parse(string text)
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

            var amazon = json["amazon"] as JObject ?? new JObject();
            var website = json["website"] as JObject ?? new JObject();
            var listing = new ProductListing
            {
                DisplayName = Text(json, "display_name"),
                Amazon = new AmazonListing
                {
                    Title = Text(amazon, "title"),
                    Bullets = List(amazon, "bullets"),
                    Description = Text(amazon, "description"),
                    SearchTerms = Text(amazon, "search_terms"),
                    Brand = Text(amazon, "brand"),
                    GenericName = Text(amazon, "generic_name"),
                    Colour = Text(amazon, "colour"),
                    Material = Text(amazon, "material"),
                    Size = Text(amazon, "size"),
                    ItemCount = Text(amazon, "item_count"),
                    Included = Text(amazon, "included"),
                    ProductType = Text(amazon, "product_type"),
                },
                Website = new WebsiteListing
                {
                    Name = Text(website, "name"),
                    Description = Text(website, "description"),
                    Highlights = List(website, "highlights"),
                    Specifications = (website["specifications"] as JArray ?? new JArray())
                        .OfType<JObject>()
                        .Select(spec => new ListingSpec { Key = Text(spec, "key"), Value = Text(spec, "value") })
                        .ToList(),
                    Tags = List(website, "tags"),
                    Category = Text(website, "category"),
                },
            };
            return listing.IsEmpty ? null : listing.WithOneName();
        }

        private static string Text(JObject json, string name)
        {
            var value = json[name];
            if (value == null || value.Type == JTokenType.Null)
            {
                return "";
            }

            var text = value.Type == JTokenType.Array ? string.Join(" ", value.Select(item => item.ToString())) : value.ToString();
            return Clip(text.Trim(), 5000);
        }

        private static List<string> List(JObject json, string name)
        {
            var value = json[name];
            if (value is JArray array)
            {
                return array.Select(item => Clip(item.ToString().Trim(), 1000)).Where(item => item.Length > 0).Take(30).ToList();
            }

            // A list sent as one text: one item per line.
            return value != null && value.Type == JTokenType.String
                ? value.ToString().Split('\n').Select(line => line.Trim()).Where(line => line.Length > 0).Take(30).ToList()
                : new List<string>();
        }

        private static string Clip(string text, int length) => text.Length <= length ? text : text.Substring(0, length);
    }

    /// <summary>A listing to write for one product, from its photos and what the AI saw in them.</summary>
    public sealed class ProductListingRequest
    {
        public int ProductId { get; set; }

        public string Code { get; set; } = "";

        public string Name { get; set; } = "";

        public string Category { get; set; } = "";

        public string SetId { get; set; } = "";

        public List<string> RawPhotos { get; set; } = new List<string>();

        /// <summary>The white-background photo, if made: shown first.</summary>
        public string CataloguePhoto { get; set; }

        public ProductUnderstanding Understanding { get; set; }

        /// <summary>The photos to attach: the catalogue photo first, then the phone photos, at most four.</summary>
        public IReadOnlyList<string> Attachments()
        {
            var attachments = new List<string>();
            if (!string.IsNullOrEmpty(CataloguePhoto))
            {
                attachments.Add(CataloguePhoto);
            }

            attachments.AddRange((RawPhotos ?? new List<string>()).Take(ProductPhotoRequest.MaxPhotos - attachments.Count));
            return attachments;
        }

        /// <summary>Why the listing cannot be written, or null when it can.</summary>
        public string Problem()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return "The product has no name.";
            }

            if (Attachments().Count == 0)
            {
                return "Add photos of the product first: the listing is written from them.";
            }

            return Attachments().Any(photo => !File.Exists(photo)) ? "A photo of the product was not found. Add the photos again." : null;
        }
    }

    public sealed class ProductListingResult
    {
        public ProductListing Listing { get; set; }

        public string ProviderName { get; set; } = "";

        public TimeSpan Duration { get; set; }
    }

    /// <summary>What the AI is asked when it writes a product's listings.</summary>
    public static class ProductListingPrompt
    {
        /// <summary>A strict JSON schema: every field required, nothing else allowed.</summary>
        public const string Schema = @"{
  ""type"": ""object"",
  ""additionalProperties"": false,
  ""required"": [""display_name"", ""amazon"", ""website""],
  ""properties"": {
    ""display_name"": { ""type"": ""string"", ""description"": ""One clear name for the product, shown on Amazon.in (as its title) and on the shop's website: brand (only if printed on the product), product, key feature, size or pack. At most 120 characters."" },
    ""amazon"": {
      ""type"": ""object"",
      ""additionalProperties"": false,
      ""required"": [""bullets"", ""description"", ""search_terms"", ""brand"", ""generic_name"", ""colour"", ""material"", ""size"", ""item_count"", ""included"", ""product_type""],
      ""properties"": {
        ""bullets"": { ""type"": ""array"", ""items"": { ""type"": ""string"" }, ""description"": ""Exactly five key features, each a short capitalised phrase, a colon, then the benefit. At most 200 characters each."" },
        ""description"": { ""type"": ""string"", ""description"": ""Three short paragraphs of plain text, at most 1500 characters."" },
        ""search_terms"": { ""type"": ""string"", ""description"": ""Words shoppers type that are not in the name: other names, uses, Hindi words in Latin letters. Lower case, separated by spaces, at most 200 characters, no brand names."" },
        ""brand"": { ""type"": ""string"", ""description"": ""Only if printed on the product; empty otherwise."" },
        ""generic_name"": { ""type"": ""string"", ""description"": ""What it is in two or three words, e.g. Water Bottle."" },
        ""colour"": { ""type"": ""string"" },
        ""material"": { ""type"": ""string"", ""description"": ""Only if it can be seen or read; empty otherwise."" },
        ""size"": { ""type"": ""string"", ""description"": ""Size, volume or weight as printed; empty if it cannot be read."" },
        ""item_count"": { ""type"": ""string"", ""description"": ""How many items come in one pack, e.g. 1."" },
        ""included"": { ""type"": ""string"", ""description"": ""What comes in the box, e.g. 1 bottle with lid."" },
        ""product_type"": { ""type"": ""string"" }
      }
    },
    ""website"": {
      ""type"": ""object"",
      ""additionalProperties"": false,
      ""required"": [""description"", ""highlights"", ""specifications"", ""tags"", ""category""],
      ""properties"": {
        ""description"": { ""type"": ""string"", ""description"": ""Two short, friendly paragraphs of plain text."" },
        ""highlights"": { ""type"": ""array"", ""items"": { ""type"": ""string"" }, ""description"": ""Three to six short points."" },
        ""specifications"": {
          ""type"": ""array"",
          ""items"": {
            ""type"": ""object"",
            ""additionalProperties"": false,
            ""required"": [""key"", ""value""],
            ""properties"": { ""key"": { ""type"": ""string"" }, ""value"": { ""type"": ""string"" } }
          },
          ""description"": ""Details that can be seen or read, e.g. Material: Plastic.""
        },
        ""tags"": { ""type"": ""array"", ""items"": { ""type"": ""string"" }, ""description"": ""Five to twelve lower-case words or short phrases shoppers search for."" },
        ""category"": { ""type"": ""string"", ""description"": ""A shop category, e.g. Home & Kitchen > Bottles."" }
      }
    }
  }
}";

        /// <summary>The whole task for Codex: look at the photos, then answer with the listings as JSON.</summary>
        public static string CodexPrompt(ProductListingRequest request)
        {
            var attachments = request.Attachments();
            var category = string.IsNullOrWhiteSpace(request.Category) ? "" : ", category " + request.Category.Trim();
            var text = new StringBuilder()
                .Append("You are writing product listings for a small shop in India: one for Amazon.in and one for the shop's own website.\n")
                .Append(attachments.Count == 1 ? "The attached photo shows" : "The attached photos show")
                .Append(" one product from the shop: \"").Append(request.Name.Trim()).Append("\" (code ").Append((request.Code ?? "").Trim()).Append(category).Append(").\n");
            if (!string.IsNullOrEmpty(request.CataloguePhoto))
            {
                text.Append("The first attached photo is its catalogue photo; the others are the original phone photos. Read labels on the phone photos.\n");
            }

            var seen = request.Understanding;
            if (seen != null)
            {
                text.Append("\nWhat was seen in the photos before:\n");
                Line(text, "Name", seen.DisplayName);
                Line(text, "What it is", seen.WhatItIs);
                Line(text, "Type", seen.ProductType);
                Line(text, "Colours", string.Join(", ", seen.Colours ?? new List<string>()));
                Line(text, "Material", seen.Material);
                Line(text, "Size or quantity", seen.SizeOrQuantity);
                Line(text, "Search words", string.Join(", ", seen.Keywords ?? new List<string>()));
                Line(text, "Hindi name", seen.HindiName);
                Line(text, "Could not be read", seen.Notes);
            }

            text.Append("\nRules:\n")
                .Append("- Write only what the photos show or the pack says, and what is plainly true of this kind of product. Never invent a brand, size, weight,")
                .Append(" ingredients, certificates, a warranty or the country it was made in: leave a field empty when you cannot read it.\n")
                .Append("- No prices, offers or discounts, and no words such as \"sale\", \"best seller\", \"free delivery\", \"guaranteed\" or \"No. 1\": the shop adds its prices itself.\n")
                .Append("- No links, phone numbers, e-mail addresses, emojis, HTML or Markdown. Plain, clear English for shoppers in India.\n")
                .Append("- One name, display_name, is shown on Amazon.in (as its title) and on the shop's website: at most 120 characters, with no word more than twice and none of")
                .Append(" ! $ ? _ { } ^ ~ # < > *. The name in quotes above is the shop's own name for the product in its billing system, which customers never see:")
                .Append(" write a clear name for customers instead (the brand only if it is printed on the pack, the product, its key feature, the size or pack).\n")
                .Append("- Amazon: exactly five bullet points; a description in three short paragraphs; search terms that are not already in the name.\n")
                .Append("- Website: two short paragraphs, three to six highlights, specifications that can be seen or read, five to twelve tags and a category.\n\n")
                .Append("Look at the photos, then answer with JSON only, matching the given schema. Do not create or change any files.");
            return text.ToString();
        }

        private static void Line(StringBuilder text, string label, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                text.Append("- ").Append(label).Append(": ").Append(value.Trim()).Append('\n');
            }
        }
    }

    /// <summary>A listing after <see cref="ListingRules.Clean"/>, with what was taken out.</summary>
    public sealed class ListingCheck
    {
        public ListingCheck(ProductListing listing, IReadOnlyList<string> notes)
        {
            Listing = listing;
            Notes = notes;
        }

        public ProductListing Listing { get; }

        /// <summary>What was changed, in words for the owner; empty when nothing was.</summary>
        public IReadOnlyList<string> Notes { get; }
    }

    /// <summary>
    /// Keeps a listing to what Amazon and the website allow, whoever wrote it: no prices or offers (the shop sets them),
    /// no promotional claims, links, phone numbers or e-mail addresses, none of the characters Amazon refuses in titles,
    /// no word more than twice in a title, and every part within its length.
    /// </summary>
    public static class ListingRules
    {
        public const int TitleMax = 200;
        public const int BulletCount = 5;
        public const int BulletMax = 250;
        public const int DescriptionMax = 2000;

        /// <summary>Amazon counts the search terms in bytes.</summary>
        public const int SearchTermsMaxBytes = 249;

        public const int AttributeMax = 120;

        /// <summary>The one name for the website and Amazon: short enough to read on both.</summary>
        public const int DisplayNameMax = 120;
        public const int WebsiteDescriptionMax = 3000;
        public const int HighlightCount = 8;
        public const int HighlightMax = 200;
        public const int SpecCount = 12;
        public const int SpecKeyMax = 40;
        public const int TagCount = 15;
        public const int TagMax = 30;

        internal const string NotePrices = "Prices and offers were taken out: the shop's own prices are added from the POS.";
        internal const string NoteClaims = "Words Amazon does not allow, such as “best seller” or “free delivery”, were taken out.";
        internal const string NoteContacts = "Links, phone numbers and e-mail addresses were taken out.";
        internal const string NoteCharacters = "Characters Amazon does not allow in a title were taken out.";
        internal const string NoteRepeats = "A word used more than twice in the title was taken out.";
        internal const string NoteLength = "Text over Amazon's or the website's length limits was shortened.";

        /// <summary>A price with its amount (so none is left behind in a title), however it is written: a currency sign or
        /// name before it (₹ 499, Rs.499, INR 499, $10, रु 499) or after it (499 rupees, 499/-, 499 रुपये), a currency on its
        /// own, MRP, an amount off; or a word about prices or offers.</summary>
        private static readonly Regex Prices = new Regex(
            @"(?:\bonly\s+)?(?:[₹$€£¥]|\bRs\.?|\b(?:INR|USD|EUR|GBP)\b|रु\.?)\s*\d[\d,]*(?:\.\d+)?(?:\s*/-)?(?:\s+only\b)?"
            + @"|\b\d[\d,]*(?:\.\d+)?\s*(?:/-|(?:rupees?|rs|inr|paise|dollars?|usd|euros?|eur|gbp)\b\.?|रुपये|रुपए|रुपया|रु\.?)(?:\s*/-)?(?:\s+only\b)?"
            + @"|[₹$€£¥]|\b(?:rupees?|paise|dollars?|euros?|INR)\b|रुपये|रुपए|रुपया"
            + @"|\bMRP\b(?:\s*[:-]?\s*[\d,]+(?:\.\d+)?)?|\b\d+(?:\.\d+)?\s*%\s*(?:off|discount)\b"
            + @"|\b(?:discount(?:s|ed)?|cashback|coupons?|sale|prices?|priced|cheap(?:er|est)?|bargain)\b"
            + @"|\b(?:special|great|best|limited[- ]time|festive)\s+(?:offers?|deals?)\b|\bon\s+offer\b|\bdeal\s+of\s+the\s+day\b",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        private static readonly Regex Claims = new Regex(
            @"\bbest[- ]?sell(er|ers|ing)\b|#\s?1\b|\bno\.?\s?1\b|\bnumber\s+one\b|\btop[- ]rated\b|\bhot\s+(item|sale|selling|product)\b"
            + @"|\bfree\s+(shipping|delivery|gift)\b|\bmoney[- ]back\b|\bguarantee(d|s)?\b|\blimited[- ]time\b|\b(buy|order|shop)\s+now\b"
            + @"|\bamazon'?s\s+choice\b|\blowest\b|\bbest\s+(price|quality|value)\b|\b100\s*%\s*(quality|satisfaction|original|genuine)\b",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>A link, an e-mail address or a phone number, with words that lead to it such as "visit" or "call us on".</summary>
        private static readonly Regex Contacts = new Regex(
            @"(?:\b(?:visit|call|whats\s?app|contact|e-?mail|write\s+to|see)(?:\s+us)?(?:\s+(?:at|on))?\s+)?"
            + @"(?:https?://\S+|\bwww\.\S+|\b[\w.+-]+@[\w-]+(?:\.[\w-]+)+\b|(?:\+?91[\s-]?)?\b[6-9]\d{4}[\s-]?\d{5}\b|\b\d{10,}\b"
            + @"|\b[a-z0-9-]+\.(?:com|in|net|org|co|shop|store)\b)",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>Not allowed in an Amazon title (unless part of the brand, which cannot be told here).</summary>
        private static readonly Regex TitleCharacters = new Regex(@"[!$?_{}^¬¦~#<>*]", RegexOptions.Compiled);

        private static readonly Regex Html = new Regex(@"<[^>]{1,200}>", RegexOptions.Compiled);

        private static readonly Regex ListMarker = new Regex(@"^\s*([-*•●▪–]|\d{1,2}[.)])\s+", RegexOptions.Compiled);

        /// <summary>Between sentences, but not after an abbreviation such as "Rs." or "No.".</summary>
        private static readonly Regex Sentence = new Regex(
            @"(?<=[.!?।])(?<!\b(?:[Rr]s|[Nn]o|[Mm]rs?|[Dd]r|[Ss]t|[Vv]s|approx|[Ee]\.g|[Ii]\.e)\.)\s+", RegexOptions.Compiled);

        private static readonly HashSet<string> SmallWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "a", "an", "and", "or", "the", "for", "with", "of", "in", "on", "to", "by", "at", "from", "x", "&", "-", "|", "/", ",",
        };

        private static readonly HashSet<string> EmptySearchWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "a", "an", "and", "or", "the", "for", "with", "of", "in", "on", "to", "by", "at", "from",
            "best", "cheap", "cheapest", "sale", "offer", "offers", "discount", "free", "new", "latest", "amazing", "top", "quality",
        };

        /// <summary>The listing as it may be kept and shown, with what was changed.</summary>
        public static ListingCheck Clean(ProductListing listing)
        {
            if (listing == null)
            {
                throw new ArgumentNullException(nameof(listing));
            }

            var notes = new List<string>();
            var amazon = listing.Amazon ?? new AmazonListing();
            var website = listing.Website ?? new WebsiteListing();
            // One name for both: held to Amazon's rules for a title (the strictest), and short.
            var cleanTitle = DisplayName(listing.PublicName, notes);
            var clean = new ProductListing
            {
                DisplayName = cleanTitle,
                Amazon = new AmazonListing
                {
                    Title = cleanTitle,
                    Bullets = Points(amazon.Bullets, BulletCount, BulletMax, notes),
                    Description = Paragraphs(amazon.Description, DescriptionMax, notes),
                    SearchTerms = SearchTerms(amazon.SearchTerms, cleanTitle, notes),
                    Brand = Attribute(amazon.Brand, notes),
                    GenericName = Attribute(amazon.GenericName, notes),
                    Colour = Attribute(amazon.Colour, notes),
                    Material = Attribute(amazon.Material, notes),
                    Size = Attribute(amazon.Size, notes),
                    ItemCount = Attribute(amazon.ItemCount, notes),
                    Included = Attribute(amazon.Included, notes),
                    ProductType = Attribute(amazon.ProductType, notes),
                },
                Website = new WebsiteListing
                {
                    Name = cleanTitle,
                    Description = Paragraphs(website.Description, WebsiteDescriptionMax, notes),
                    Highlights = Points(website.Highlights, HighlightCount, HighlightMax, notes),
                    Specifications = Specifications(website.Specifications, notes),
                    Tags = Tags(website.Tags, notes),
                    Category = Category(website.Category, notes),
                },
                Written = listing.Written,
                Provider = listing.Provider ?? "",
                SetId = listing.SetId ?? "",
                Edited = listing.Edited,
            };
            clean.Notes = notes.Distinct().ToList();
            return new ListingCheck(clean, clean.Notes);
        }

        /// <summary>The one name for the website and Amazon: what an Amazon title may hold (<see cref="Title"/>), cut to
        /// <see cref="DisplayNameMax"/> characters.</summary>
        public static string DisplayName(string name, List<string> notes = null)
        {
            notes = notes ?? new List<string>();
            return Tidy(Cut(Title(name, notes), DisplayNameMax, notes));
        }

        /// <summary>An Amazon title: prices, claims, links and the characters Amazon refuses taken out, no word more than
        /// twice, at most <see cref="TitleMax"/> characters.</summary>
        public static string Title(string title, List<string> notes = null)
        {
            notes = notes ?? new List<string>();
            var text = Plain(title);
            text = Remove(text, Prices, notes, NotePrices);
            text = Remove(text, Claims, notes, NoteClaims);
            text = Remove(text, Contacts, notes, NoteContacts);
            if (TitleCharacters.IsMatch(text))
            {
                text = TitleCharacters.Replace(text, " ");
                notes.Add(NoteCharacters);
            }

            var seen = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var kept = new List<string>();
            foreach (var word in Words(text))
            {
                var key = word.Trim(',', '.', ';', ':', '(', ')', '-', '|', '/');
                if (key.Length > 1 && !SmallWords.Contains(key) && key.Any(char.IsLetter))
                {
                    seen[key] = seen.TryGetValue(key, out var count) ? count + 1 : 1;
                    if (seen[key] > 2)
                    {
                        notes.Add(NoteRepeats);
                        continue;
                    }
                }

                kept.Add(word);
            }

            return Tidy(Cut(string.Join(" ", kept), TitleMax, notes));
        }

        /// <summary>Amazon's search terms: lower case, words not in the title, no repeats or empty words, within
        /// <see cref="SearchTermsMaxBytes"/> bytes.</summary>
        public static string SearchTerms(string terms, string title, List<string> notes = null)
        {
            notes = notes ?? new List<string>();
            var text = Remove(Remove(Plain(terms), Prices, notes, NotePrices), Contacts, notes, NoteContacts);
            var inTitle = new HashSet<string>(Words(Regex.Replace(title ?? "", @"[^\p{L}\p{N}\p{M}]+", " ")), StringComparer.OrdinalIgnoreCase);
            var words = Words(Regex.Replace(text.ToLowerInvariant(), @"[^\p{L}\p{N}\p{M}]+", " "))
                .Where(word => !inTitle.Contains(word) && !EmptySearchWords.Contains(word))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            var kept = new StringBuilder();
            foreach (var word in words)
            {
                var next = kept.Length == 0 ? word : kept + " " + word;
                if (Encoding.UTF8.GetByteCount(next) > SearchTermsMaxBytes)
                {
                    notes.Add(NoteLength);
                    break;
                }

                kept.Clear().Append(next);
            }

            return kept.ToString();
        }

        /// <summary>Bullet points or highlights: sentences with prices, claims or contacts taken out, each within
        /// <paramref name="max"/> characters, no repeats, at most <paramref name="count"/>.</summary>
        public static List<string> Points(IEnumerable<string> points, int count, int max, List<string> notes = null)
        {
            notes = notes ?? new List<string>();
            var kept = new List<string>();
            foreach (var point in points ?? Enumerable.Empty<string>())
            {
                var text = Capital(Tidy(Cut(Sentences(ListMarker.Replace(Plain(point), ""), notes), max, notes)));
                if (text.Length > 0 && !kept.Contains(text, StringComparer.OrdinalIgnoreCase))
                {
                    kept.Add(text);
                }
            }

            if (kept.Count > count)
            {
                notes.Add(NoteLength);
            }

            return kept.Take(count).ToList();
        }

        /// <summary>A description: plain paragraphs, sentences with prices, claims or contacts taken out, within
        /// <paramref name="max"/> characters.</summary>
        public static string Paragraphs(string text, int max, List<string> notes = null)
        {
            notes = notes ?? new List<string>();
            var paragraphs = Regex.Split(Html.Replace((text ?? "").Replace("\r\n", "\n"), " "), @"\n\s*\n")
                .Select(paragraph => Sentences(Plain(Regex.Replace(paragraph, @"^\s*#+\s*", "", RegexOptions.Multiline)), notes))
                .Where(paragraph => paragraph.Length > 0)
                .ToList();
            var joined = string.Join("\n\n", paragraphs);
            if (joined.Length <= max)
            {
                return joined;
            }

            notes.Add(NoteLength);
            var cut = joined.Substring(0, max);
            var end = cut.LastIndexOfAny(new[] { '.', '!', '?', '।' });
            return (end > max / 2 ? cut.Substring(0, end + 1) : Cut(joined, max, null)).Trim();
        }

        private static string Attribute(string value, List<string> notes)
        {
            var text = Plain(value);
            if (Prices.IsMatch(text) || Claims.IsMatch(text) || Contacts.IsMatch(text))
            {
                notes.Add(Contacts.IsMatch(text) ? NoteContacts : Claims.IsMatch(text) ? NoteClaims : NotePrices);
                return "";
            }

            return Tidy(Cut(text, AttributeMax, notes));
        }

        private static List<ListingSpec> Specifications(IEnumerable<ListingSpec> specs, List<string> notes)
        {
            var kept = new List<ListingSpec>();
            foreach (var spec in specs ?? Enumerable.Empty<ListingSpec>())
            {
                var key = Tidy(Cut(Plain(spec?.Key).TrimEnd(':'), SpecKeyMax, notes));
                var value = Attribute(spec?.Value, notes);
                if (key.Length > 0 && value.Length > 0 && !kept.Any(k => string.Equals(k.Key, key, StringComparison.OrdinalIgnoreCase)))
                {
                    kept.Add(new ListingSpec { Key = key, Value = value });
                }
            }

            if (kept.Count > SpecCount)
            {
                notes.Add(NoteLength);
            }

            return kept.Take(SpecCount).ToList();
        }

        private static List<string> Tags(IEnumerable<string> tags, List<string> notes)
        {
            var kept = new List<string>();
            foreach (var tag in tags ?? Enumerable.Empty<string>())
            {
                var text = Plain(tag).TrimStart('#').ToLowerInvariant();
                if (Prices.IsMatch(text) || Claims.IsMatch(text) || Contacts.IsMatch(text))
                {
                    notes.Add(Contacts.IsMatch(text) ? NoteContacts : Claims.IsMatch(text) ? NoteClaims : NotePrices);
                    continue;
                }

                text = Tidy(Cut(text, TagMax, notes));
                if (text.Length > 0 && !kept.Contains(text))
                {
                    kept.Add(text);
                }
            }

            if (kept.Count > TagCount)
            {
                notes.Add(NoteLength);
            }

            return kept.Take(TagCount).ToList();
        }

        private static string Category(string category, List<string> notes)
        {
            var parts = Plain(category).Split('>').Select(part => part.Trim()).Where(part => part.Length > 0);
            return Cut(string.Join(" > ", parts), AttributeMax, notes);
        }

        /// <summary>The text without sentences that have prices, claims or contacts.</summary>
        private static string Sentences(string text, List<string> notes)
        {
            var kept = new List<string>();
            foreach (var sentence in Sentence.Split(text))
            {
                if (Prices.IsMatch(sentence))
                {
                    notes.Add(NotePrices);
                }
                else if (Claims.IsMatch(sentence))
                {
                    notes.Add(NoteClaims);
                }
                else if (Contacts.IsMatch(sentence))
                {
                    notes.Add(NoteContacts);
                }
                else if (sentence.Trim().Length > 0)
                {
                    kept.Add(sentence.Trim());
                }
            }

            return string.Join(" ", kept);
        }

        private static string Remove(string text, Regex pattern, List<string> notes, string note)
        {
            if (!pattern.IsMatch(text))
            {
                return text;
            }

            notes.Add(note);
            return pattern.Replace(text, " ");
        }

        /// <summary>One line of plain text: no HTML, Markdown emphasis, emojis or control characters.</summary>
        private static string Plain(string text)
        {
            var value = Html.Replace(text ?? "", " ").Replace("**", "").Replace("__", "").Replace("`", "");
            var builder = new StringBuilder(value.Length);
            foreach (var c in value)
            {
                var category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (char.IsWhiteSpace(c) || char.IsControl(c))
                {
                    builder.Append(' ');
                }
                else if (c == '°' || (category != UnicodeCategory.OtherSymbol && category != UnicodeCategory.Surrogate
                    && category != UnicodeCategory.PrivateUse && category != UnicodeCategory.Format))
                {
                    builder.Append(c);
                }
            }

            return Regex.Replace(builder.ToString(), @"\s+", " ").Trim();
        }

        private static string Capital(string text) =>
            text.Length > 0 && char.IsLower(text[0]) ? char.ToUpperInvariant(text[0]) + text.Substring(1) : text;

        private static IEnumerable<string> Words(string text) =>
            (text ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>At most <paramref name="max"/> characters, cut between words.</summary>
        private static string Cut(string text, int max, List<string> notes)
        {
            if (text.Length <= max)
            {
                return text;
            }

            notes?.Add(NoteLength);
            var cut = text.Substring(0, max);
            var space = cut.LastIndexOf(' ');
            return (space > max / 2 ? cut.Substring(0, space) : cut).Trim();
        }

        /// <summary>No doubled spaces, and no stray separators or spaces before punctuation left where words were taken out.</summary>
        private static string Tidy(string text)
        {
            var value = Regex.Replace(text ?? "", @"\s+", " ");
            value = Regex.Replace(value, @"\s+([,.;:!?)])", "$1");
            value = Regex.Replace(value, @"\(\s*\)", "");
            value = Regex.Replace(value, @"(\s*[-–—|,/:;]\s*){2,}", " - ");
            return Regex.Replace(value, @"\s+", " ").Trim().Trim('-', '–', '—', '|', ',', '/', ':', ';').Trim();
        }
    }
}

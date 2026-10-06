using System;
using SmartRetail.AI.Settings;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Creatives
{
    /// <summary>A product shown in a creative.</summary>
    public sealed class CreativeArtProduct
    {
        public string Name { get; set; } = "";

        /// <summary>What it is, as seen in its photos, e.g. "a 1 litre plastic bottle of sunflower oil with a yellow cap".</summary>
        public string WhatItIs { get; set; } = "";

        /// <summary>Its photo on this PC (the white-background one when it has one); null when it has none.</summary>
        public string Photo { get; set; }

        /// <summary>The app puts its price on the picture, so Codex leaves room for it.</summary>
        public bool HasPrice { get; set; }
    }

    /// <summary>
    /// An advertising creative for Codex's image tool to design: the format, the style, the shop's brand, the products
    /// with their photos, and the owner's words, which never hold a number (<see cref="CreativeWords"/>); only the shop's
    /// own name may, as it is the brand. Prices are never drawn by the AI: the app puts them in the room Codex leaves. A
    /// revision gives the picture to change and what to change.
    /// </summary>
    public sealed class CreativeArtRequest
    {
        public const int MaxProducts = 4;

        public const int MaxReferences = 2;

        /// <summary>The customer's business (from its profile): the creative is made for it, in its country. Neutral when not given.</summary>
        public ShopProfile Shop { get; set; } = ShopProfile.Neutral;

        /// <summary>E.g. "Square post".</summary>
        public string FormatName { get; set; } = "";

        /// <summary>Where it is used, e.g. "Instagram, Facebook and WhatsApp posts".</summary>
        public string FormatUse { get; set; } = "";

        public int Width { get; set; }

        public int Height { get; set; }

        /// <summary>The look, e.g. "Festive: rich colours, marigolds and warm lights, for an Indian festival".</summary>
        public string Style { get; set; } = "";

        /// <summary>Who the advertisement is for, in the owner's words (e.g. "families with young children"). Empty when not given:
        /// then the prompt says nothing about it. It is never drawn: it only guides the people, the setting and the mood.</summary>
        public string Audience { get; set; } = "";

        public string ShopName { get; set; } = "";

        /// <summary>The shop's colours, as #RRGGBB.</summary>
        public List<string> BrandColours { get; set; } = new List<string>();

        /// <summary>The shop's own notes on its brand, e.g. "friendly, family-run, since the nineties".</summary>
        public string BrandNotes { get; set; } = "";

        /// <summary>The shop's logo on this PC; null when it has none.</summary>
        public string Logo { get; set; }

        public string Headline { get; set; } = "";

        public string Subtitle { get; set; } = "";

        public string CallToAction { get; set; } = "";

        public string SmallPrint { get; set; } = "";

        public string Background { get; set; } = "";

        /// <summary>Anything else the owner asks for.</summary>
        public string Instructions { get; set; } = "";

        public List<CreativeArtProduct> Products { get; set; } = new List<CreativeArtProduct>();

        /// <summary>Pictures whose look the owner likes, on this PC.</summary>
        public List<string> References { get; set; } = new List<string>();

        /// <summary>For a revision: the picture made before, on this PC.</summary>
        public string Previous { get; set; }

        /// <summary>For a revision: what to change, in the owner's words.</summary>
        public string Change { get; set; } = "";

        public bool IsRevision => !string.IsNullOrWhiteSpace(Previous);

        /// <summary>How many price tags the app will put on the picture.</summary>
        public int PriceTags => Products.Count(p => p != null && p.HasPrice);

        /// <summary>What is wrong with the request, in words for the owner; null when it can be made.</summary>
        public string Problem()
        {
            if (Width <= 0 || Height <= 0)
            {
                return "Choose the creative's size.";
            }

            if (Products.Count > MaxProducts)
            {
                return "A creative shows at most " + MaxProducts + " products.";
            }

            if (References.Count > MaxReferences)
            {
                return "Add at most " + MaxReferences + " pictures to take the look from.";
            }

            if (IsRevision && string.IsNullOrWhiteSpace(Change))
            {
                return "Say what to change.";
            }

            return CreativeWords.Problem("The headline", Headline, CreativeWords.MaxHeadline)
                ?? CreativeWords.Problem("The line under it", Subtitle, CreativeWords.MaxLine)
                ?? CreativeWords.Problem("What to do", CallToAction, CreativeWords.MaxLine)
                ?? CreativeWords.Problem("The small print", SmallPrint, CreativeWords.MaxLine)
                ?? CreativeWords.NameProblem("The shop's name", ShopName, CreativeWords.MaxLine)
                ?? CreativeWords.Problem("The background", Background, CreativeWords.MaxNotes, allowNumbers: true)
                ?? CreativeWords.Problem("The instructions", Instructions, CreativeWords.MaxNotes, allowNumbers: true)
                ?? CreativeWords.Problem("Who it is for", Audience, CreativeWords.MaxNotes, allowNumbers: true)
                ?? CreativeWords.Problem("The brand notes", BrandNotes, CreativeWords.MaxNotes, allowNumbers: true)
                ?? CreativeWords.Problem("What to change", Change, CreativeWords.MaxNotes, allowNumbers: true);
        }

        /// <summary>The files Codex is given, each with the name of its copy in Codex's empty folder.</summary>
        public IReadOnlyList<KeyValuePair<string, string>> Attachments()
        {
            var files = new List<KeyValuePair<string, string>>();
            void Add(string path, string name)
            {
                if (!string.IsNullOrWhiteSpace(path))
                {
                    files.Add(new KeyValuePair<string, string>(path, name + Extension(path)));
                }
            }

            // The picture to change first: it is what Codex works on.
            Add(Previous, "previous");
            for (var i = 0; i < Products.Count; i++)
            {
                Add(Products[i]?.Photo, "product-" + (i + 1));
            }

            Add(Logo, "logo");
            for (var i = 0; i < References.Count; i++)
            {
                Add(References[i], "reference-" + (i + 1));
            }

            return files;
        }

        private static string Extension(string path)
        {
            var extension = System.IO.Path.GetExtension(path).ToLowerInvariant();
            return extension == ".jpeg" ? ".jpg" : extension;
        }
    }

    public sealed class CreativeArtResult
    {
        public byte[] Image { get; set; }

        /// <summary>Where Codex left room for each price tag, in order; missing ones are placed by the app.</summary>
        public List<CreativeArea> PriceAreas { get; set; } = new List<CreativeArea>();

        /// <summary>What Codex says it made, in a sentence.</summary>
        public string Notes { get; set; } = "";

        /// <summary>The prompt Codex was given, kept with the picture.</summary>
        public string Prompt { get; set; } = "";

        public string ProviderName { get; set; } = "";

        public TimeSpan Duration { get; set; }
    }

    /// <summary>A place on the picture: its top-left corner and size, each a share (0 to 1) of the picture's width or height.</summary>
    public sealed class CreativeArea
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }

    /// <summary>
    /// The owner's words that the AI draws into the picture. They never hold a number, a currency or a percent sign: the
    /// AI could draw a number wrong, and prices and offers only ever come from the POS, drawn by the app.
    /// </summary>
    public static class CreativeWords
    {
        public const int MaxHeadline = 60;

        public const int MaxLine = 90;

        public const int MaxNotes = 400;

        // Digits in any script (Devanagari ones too).
        private static readonly Regex Digits = new Regex(@"\p{Nd}", RegexOptions.CultureInvariant);

        // Currency signs and codes, and percent.
        private static readonly Regex Money = new Regex(@"[₹$€£¥%]|\bRs\b\.?|\bINR\b|रु", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        /// <summary>True when the words hold a number, a currency or a percent sign.</summary>
        public static bool HasNumbers(string words) => !string.IsNullOrEmpty(words) && (Digits.IsMatch(words) || Money.IsMatch(words));

        /// <summary>True when the words hold a number, in any script.</summary>
        public static bool HasDigits(string words) => !string.IsNullOrEmpty(words) && Digits.IsMatch(words);

        /// <summary>True when the words hold a currency sign or code, or a percent sign.</summary>
        public static bool HasMoney(string words) => !string.IsNullOrEmpty(words) && Money.IsMatch(words);

        /// <summary>What is wrong with the words, for the owner; null when they are fine.</summary>
        /// <param name="allowNumbers">For instructions to the AI, which are never drawn as they are written.</param>
        public static string Problem(string label, string words, int maxLength, bool allowNumbers = false)
        {
            var text = Tidy(words);
            if (text.Length > maxLength)
            {
                return label + " is too long: at most " + maxLength + " letters.";
            }

            return !allowNumbers && HasNumbers(text)
                ? label + " has a number, ₹ or % in it. Write it in words only: the app adds each price itself, from the POS."
                : null;
        }

        /// <summary>
        /// What is wrong with the shop's own name, for the owner; null when it is fine. A name is the shop's brand, drawn exactly
        /// as written, and may hold a number ("Demo Mart 99", "Shop 24"). A ₹ or % sign in it would look like a price or an
        /// offer, which only the app draws, so those are refused.
        /// </summary>
        public static string NameProblem(string label, string name, int maxLength)
        {
            var text = Tidy(name);
            if (text.Length > maxLength)
            {
                return label + " is too long: at most " + maxLength + " letters.";
            }

            return HasMoney(text)
                ? label + " has a ₹, a % or a money word in it. A number is fine (like Avenue 99), but not a price sign: the app adds each price itself, from the POS."
                : null;
        }

        /// <summary>The words on one line, without quotes that would end them in the prompt, and without line breaks or other
        /// control characters (each becomes a space), so the owner's words can never start another line of the prompt.</summary>
        public static string Tidy(string words) =>
            Regex.Replace((words ?? "").Replace('"', '\'').Replace('“', '\'').Replace('”', '\''), @"[\s\p{Cc}]+", " ").Trim();
    }

    /// <summary>The task for Codex: one finished advertisement, drawn by its image tool, with room left for prices.</summary>
    public static class CreativeArtPrompt
    {
        public const string ResultFileName = "creative.png";

        /// <summary>The answer Codex gives after saving the picture: where it left room for the prices, and what it made.</summary>
        public const string Schema = @"{
  ""type"": ""object"",
  ""additionalProperties"": false,
  ""required"": [""image"", ""price_areas"", ""notes""],
  ""properties"": {
    ""image"": { ""type"": ""string"", ""description"": ""The file name of the picture saved in the current folder."" },
    ""price_areas"": {
      ""type"": ""array"",
      ""description"": ""For each price tag, in the order asked, the empty place left for it."",
      ""items"": {
        ""type"": ""object"",
        ""additionalProperties"": false,
        ""required"": [""x"", ""y"", ""width"", ""height""],
        ""properties"": {
          ""x"": { ""type"": ""number"", ""description"": ""Left edge, as a share of the picture's width, 0 to 1."" },
          ""y"": { ""type"": ""number"", ""description"": ""Top edge, as a share of the picture's height, 0 to 1."" },
          ""width"": { ""type"": ""number"", ""description"": ""As a share of the picture's width."" },
          ""height"": { ""type"": ""number"", ""description"": ""As a share of the picture's height."" }
        }
      }
    },
    ""notes"": { ""type"": ""string"", ""description"": ""One sentence on what was made."" }
  }
}";

        /// <summary>The shape to ask the image tool for: the sizes it makes that come closest to the creative's shape.</summary>
        public static string ToolSize(int width, int height)
        {
            var ratio = height <= 0 ? 1d : (double)width / height;
            return ratio > 1.2 ? "1536 x 1024 (wide)" : ratio < 0.83 ? "1024 x 1536 (tall)" : "1024 x 1024 (square)";
        }

        public static string CodexPrompt(CreativeArtRequest request)
        {
            var problem = request == null ? "No creative was given." : request.Problem();
            if (problem != null)
            {
                throw new ArgumentException(problem, nameof(request));
            }

            // A file given twice (one photo for two products) is named by its first copy.
            var names = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var file in request.Attachments())
            {
                if (!names.ContainsKey(file.Key))
                {
                    names[file.Key] = file.Value;
                }
            }

            var prompt = new StringBuilder();
            var shop = CreativeWords.Tidy(request.ShopName);
            prompt.Append("You are the designer of an advertising creative for " + (request.Shop ?? ShopProfile.Neutral).Shop)
                .Append(shop.Length > 0 ? ", " + shop : "").Append(".\n");
            if (request.IsRevision)
            {
                prompt.Append("You made the picture ").Append(names[request.Previous]).Append(" before. Make it again with your image generation tool, ")
                    .Append("keeping everything the same except this change the owner asks for: \"").Append(CreativeWords.Tidy(request.Change)).Append("\".\n")
                    .Append("The brief it was made from, which still holds:\n");
            }
            else
            {
                prompt.Append("Use your image generation tool to make one finished, professional advertisement: a complete design, not a template.\n");
            }

            prompt.Append("- Format: ").Append(CreativeWords.Tidy(request.FormatName));
            if (!string.IsNullOrWhiteSpace(request.FormatUse))
            {
                prompt.Append(", for ").Append(CreativeWords.Tidy(request.FormatUse));
            }

            prompt.Append(", ").Append(request.Width.ToString(CultureInfo.InvariantCulture)).Append(" x ")
                .Append(request.Height.ToString(CultureInfo.InvariantCulture)).Append(" pixels. Make the image ")
                .Append(ToolSize(request.Width, request.Height)).Append(" and keep the important parts away from the edges, as it is fitted to that shape.\n");
            if (!string.IsNullOrWhiteSpace(request.Style))
            {
                prompt.Append("- Style: ").Append(CreativeWords.Tidy(request.Style)).Append(".\n");
            }

            var colours = request.BrandColours.Where(c => c != null && Regex.IsMatch(c, "^#[0-9A-Fa-f]{6}$")).ToList();
            if (colours.Count > 0 || !string.IsNullOrWhiteSpace(request.BrandNotes) || request.Logo != null)
            {
                prompt.Append("- The shop's brand:");
                if (colours.Count > 0)
                {
                    prompt.Append(" its colours are ").Append(string.Join(" and ", colours)).Append(';');
                }

                if (!string.IsNullOrWhiteSpace(request.BrandNotes))
                {
                    prompt.Append(' ').Append(CreativeWords.Tidy(request.BrandNotes).TrimEnd('.')).Append(';');
                }

                if (request.Logo != null)
                {
                    prompt.Append(" its logo is ").Append(names[request.Logo]).Append(": show it small and clear, exactly as it is;");
                }

                prompt.Length--;
                prompt.Append(".\n");
            }

            var products = request.Products.Where(p => p != null).ToList();
            if (products.Count > 0)
            {
                prompt.Append("- Products to feature, each exactly as in its photo (the same shape, materials, colours, labels and printed text; ")
                    .Append("never invent a brand, a label, a feature or an accessory, and never change a label):\n");
                for (var i = 0; i < products.Count; i++)
                {
                    var product = products[i];
                    prompt.Append("  ").Append(i + 1).Append(". ").Append(CreativeWords.Tidy(product.Name));
                    if (!string.IsNullOrWhiteSpace(product.WhatItIs))
                    {
                        prompt.Append(" (").Append(CreativeWords.Tidy(product.WhatItIs).TrimEnd('.')).Append(')');
                    }

                    prompt.Append(product.Photo != null ? ": photo " + names[product.Photo] : ": no photo, so show it plainly from its name").Append(".\n");
                }
            }

            var words = new List<string>();
            void Words(string label, string text)
            {
                var tidy = CreativeWords.Tidy(text);
                if (tidy.Length > 0)
                {
                    words.Add("  " + label + ": \"" + tidy + "\"");
                }
            }

            Words("Headline", request.Headline);
            Words("Line under it", request.Subtitle);
            Words("What to do", request.CallToAction);
            Words("Small print", request.SmallPrint);
            Words("Shop's name", request.ShopName);
            if (words.Count > 0)
            {
                prompt.Append("- The words to show, exactly as written and spelled, and no other words:\n").Append(string.Join("\n", words)).Append('\n');
            }
            else
            {
                prompt.Append("- Show no words at all.\n");
            }

            // The shop's name is its brand: a number in it ("Avenue 99") is drawn as written, the only number besides the packaging's.
            prompt.Append("- Strictly no numbers, prices, currency signs such as ₹, percent signs, dates, phone numbers, web addresses or QR codes ")
                .Append("anywhere in the picture, except what is printed on the products' own packaging")
                .Append(CreativeWords.HasDigits(shop) ? " and the number that is part of the shop's name, drawn exactly as written" : "")
                .Append(". No watermark or signature.\n");
            var tags = request.PriceTags;
            if (tags > 0)
            {
                prompt.Append("- The shop adds ").Append(tags == 1 ? "a price tag" : tags.ToString(CultureInfo.InvariantCulture) + " price tags, one for each product in order,")
                    .Append(" itself. Leave a clear, calm, empty place for ").Append(tags == 1 ? "it" : "each")
                    .Append(", about a quarter of the picture's width and a tenth of its height, near its product and away from the words.\n");
            }

            if (!string.IsNullOrWhiteSpace(request.Background))
            {
                prompt.Append("- Background: ").Append(CreativeWords.Tidy(request.Background).TrimEnd('.')).Append(".\n");
            }

            // Who it is for guides the people, the setting and the mood. It is never a word to draw: the list of words above stays the only one.
            var audience = CreativeWords.Tidy(request.Audience).TrimEnd('.');
            if (audience.Length > 0)
            {
                prompt.Append("- Who it is for: ").Append(audience).Append(". Let the people, the setting and the mood suit them. ")
                    .Append("Do not write any words about them: the only words are the ones listed above, if any.\n");
            }

            if (request.References.Count > 0)
            {
                prompt.Append("- Take the look and feel (not the content or any words) from ")
                    .Append(string.Join(" and ", request.References.Select(r => names[r]))).Append(".\n");
            }

            if (!string.IsNullOrWhiteSpace(request.Instructions))
            {
                prompt.Append("- The owner also asks: ").Append(CreativeWords.Tidy(request.Instructions).TrimEnd('.')).Append(".\n");
            }

            prompt.Append("It must look like the work of a professional studio: a clear focus, strong hierarchy, generous space and sharp, correct words.\n")
                .Append("Save the picture as ").Append(ResultFileName).Append(" in the current folder. Then answer with JSON: \"image\" is its file name; ")
                .Append("\"price_areas\" lists ").Append(tags > 0 ? "the empty place left for each price tag, in order," : "nothing (an empty list),")
                .Append(" as shares of the picture's width and height from 0 to 1; \"notes\" says in one sentence what you made.");
            return prompt.ToString();
        }
    }

    /// <summary>Codex's answer after a creative, checked: the places for the price tags stay inside the picture.</summary>
    public static class CreativeArtAnswer
    {
        /// <summary>The smallest place for a price tag, as a share of the picture.</summary>
        public const double MinSize = 0.06;

        /// <summary>The places Codex left for the price tags, at most <paramref name="tags"/>, each kept inside the picture;
        /// and its notes. Nothing when the answer cannot be read.</summary>
        public static (List<CreativeArea> Areas, string Notes) Parse(string json, int tags)
        {
            var areas = new List<CreativeArea>();
            if (string.IsNullOrWhiteSpace(json))
            {
                return (areas, "");
            }

            JObject answer;
            try
            {
                answer = JObject.Parse(json.Trim());
            }
            catch (JsonException)
            {
                return (areas, "");
            }

            var notes = CreativeWords.Tidy(answer.Value<string>("notes") ?? "");
            if (answer["price_areas"] is JArray list)
            {
                foreach (var item in list.OfType<JObject>().Take(Math.Max(0, tags)))
                {
                    if (Area(item) is { } area)
                    {
                        areas.Add(area);
                    }
                }
            }

            return (areas, notes.Length > 300 ? notes.Substring(0, 300) : notes);
        }

        private static CreativeArea Area(JObject item)
        {
            double? Number(string name) =>
                item[name] is JValue value && (value.Type == JTokenType.Float || value.Type == JTokenType.Integer)
                    && !double.IsNaN(value.Value<double>()) && !double.IsInfinity(value.Value<double>())
                    ? value.Value<double>()
                    : (double?)null;

            if (!(Number("x") is double x) || !(Number("y") is double y) || !(Number("width") is double width) || !(Number("height") is double height))
            {
                return null;
            }

            width = Clamp(width, MinSize, 1);
            height = Clamp(height, MinSize, 1);
            return new CreativeArea
            {
                X = Clamp(x, 0, 1 - width),
                Y = Clamp(y, 0, 1 - height),
                Width = width,
                Height = height,
            };
        }

        private static double Clamp(double value, double min, double max) => Math.Round(Math.Min(max, Math.Max(min, value)), 4);
    }
}

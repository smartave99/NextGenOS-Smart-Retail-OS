using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Products
{
    /// <summary>One category of the shop's website: a main category, or a subcategory under one.</summary>
    public sealed class SiteCategory
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        /// <summary>The main category this is under; empty for a main category.</summary>
        public string ParentId { get; set; } = "";
    }

    /// <summary>
    /// The categories of the shop's website, as its admin sent them to the owner's Supabase project: main categories and
    /// their subcategories (two levels, as the website's product form has). A product on the website needs one, so the
    /// shop PC chooses it from this list and from nothing else: a name made up from a photo would not be a category there.
    /// Anything in the list that cannot be used (no id or name, an id twice, a parent that is not a main category) is left out.
    /// </summary>
    public sealed class SiteCategoryList
    {
        public const int MaxCategories = 1000;

        /// <summary>Between a main category and its subcategory when they are written as one place: "Grocery › Oils".</summary>
        public const string Between = " › ";

        public static readonly SiteCategoryList Empty = new SiteCategoryList(new SiteCategory[0], null);

        private readonly Dictionary<string, SiteCategory> _byId;
        private readonly ILookup<string, SiteCategory> _subs;

        public SiteCategoryList(IEnumerable<SiteCategory> categories, DateTime? updatedAt)
        {
            var kept = new List<SiteCategory>();
            _byId = new Dictionary<string, SiteCategory>(StringComparer.Ordinal);
            foreach (var category in (categories ?? Enumerable.Empty<SiteCategory>()).Where(c => c != null))
            {
                var id = (category.Id ?? "").Trim();
                var name = Tidy(category.Name);
                if (id.Length == 0 || id.Length > 64 || name.Length == 0 || _byId.ContainsKey(id) || kept.Count >= MaxCategories)
                {
                    continue;
                }

                var copy = new SiteCategory { Id = id, Name = name.Length > 120 ? name.Substring(0, 120) : name, ParentId = (category.ParentId ?? "").Trim() };
                _byId[id] = copy;
                kept.Add(copy);
            }

            // A subcategory needs a main category to be under; deeper levels have no place in the product form.
            var mains = new HashSet<string>(kept.Where(c => c.ParentId.Length == 0).Select(c => c.Id), StringComparer.Ordinal);
            All = kept.Where(c => c.ParentId.Length == 0 || mains.Contains(c.ParentId)).ToList();
            _byId = All.ToDictionary(c => c.Id, StringComparer.Ordinal);
            _subs = All.Where(c => c.ParentId.Length > 0).ToLookup(c => c.ParentId, StringComparer.Ordinal);
            UpdatedAt = updatedAt;
        }

        /// <summary>Every usable category, in the order the website sent them.</summary>
        public IReadOnlyList<SiteCategory> All { get; }

        /// <summary>When the website last sent the list; null when that is not known.</summary>
        public DateTime? UpdatedAt { get; }

        public bool IsEmpty => All.Count == 0;

        public IEnumerable<SiteCategory> Mains => All.Where(c => c.ParentId.Length == 0);

        public IEnumerable<SiteCategory> SubsOf(string mainId) => _subs[mainId ?? ""];

        public SiteCategory Find(string id) => id != null && _byId.TryGetValue(id.Trim(), out var category) ? category : null;

        /// <summary>The place a product gets from a category id of either kind (a subcategory puts it under its main category);
        /// null when there is no such category.</summary>
        public SitePlace Resolve(string id)
        {
            var category = Find(id);
            if (category == null)
            {
                return null;
            }

            return category.ParentId.Length == 0 ? new SitePlace(category.Id, "") : new SitePlace(category.ParentId, category.Id);
        }

        /// <summary>Whether the pair is a place a product can have: a main category, and a subcategory of that one (or none).</summary>
        public bool IsValid(string categoryId, string subcategoryId)
        {
            var main = Find(categoryId);
            if (main == null || main.ParentId.Length > 0)
            {
                return false;
            }

            return string.IsNullOrEmpty(subcategoryId) || (Find(subcategoryId) is SiteCategory sub && sub.ParentId == main.Id);
        }

        /// <summary>E.g. "Grocery › Oils", or "Grocery".</summary>
        public string PathOf(string categoryId, string subcategoryId)
        {
            var main = Find(categoryId);
            if (main == null)
            {
                return "";
            }

            return Find(subcategoryId) is SiteCategory sub && sub.ParentId == main.Id ? main.Name + Between + sub.Name : main.Name;
        }

        /// <summary>The places a product can be put in, for the owner to choose from and for the AI: each main category, then its
        /// subcategories.</summary>
        public IReadOnlyList<SiteCategoryOption> Options()
        {
            var options = new List<SiteCategoryOption>();
            foreach (var main in Mains)
            {
                options.Add(new SiteCategoryOption(main.Id, main.Name, false));
                foreach (var sub in SubsOf(main.Id))
                {
                    options.Add(new SiteCategoryOption(sub.Id, main.Name + Between + sub.Name, true));
                }
            }

            return options;
        }

        /// <summary>Reads what the Supabase function <c>get_site_categories</c> answers (<c>{"updated_at": …, "categories": […]}</c>), or a
        /// bare list of categories; an empty list when it cannot be read. Never throws.</summary>
        public static SiteCategoryList Parse(string json)
        {
            try
            {
                var token = JToken.Parse(string.IsNullOrWhiteSpace(json) ? "null" : json);
                DateTime? updated = null;
                JToken list = token;
                if (token is JObject envelope)
                {
                    list = envelope["categories"];
                    if (envelope["updated_at"] is JToken when && when.Type != JTokenType.Null
                        && DateTime.TryParse(when.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var parsed))
                    {
                        updated = parsed;
                    }
                }

                if (!(list is JArray array))
                {
                    return Empty;
                }

                var categories = new List<SiteCategory>();
                foreach (var item in array.OfType<JObject>())
                {
                    var parent = item["parentId"];
                    categories.Add(new SiteCategory
                    {
                        Id = item["id"]?.Type == JTokenType.String ? (string)item["id"] : "",
                        Name = item["name"]?.Type == JTokenType.String ? (string)item["name"] : "",
                        ParentId = parent?.Type == JTokenType.String ? (string)parent : "",
                    });
                }

                return new SiteCategoryList(categories, updated);
            }
            catch (JsonException)
            {
                return Empty;
            }
        }

        public string ToJson() => JsonConvert.SerializeObject(new
        {
            updated_at = UpdatedAt,
            categories = All.Select(c => new { id = c.Id, name = c.Name, parentId = c.ParentId.Length == 0 ? null : c.ParentId }),
        });

        internal static string Tidy(string text) => Regex.Replace(text ?? "", @"[\s\u0000-\u001f]+", " ").Trim();
    }

    /// <summary>A product's place on the website: a main category and, if it has one, a subcategory of it.</summary>
    public sealed class SitePlace
    {
        public SitePlace(string categoryId, string subcategoryId)
        {
            CategoryId = categoryId ?? "";
            SubcategoryId = subcategoryId ?? "";
        }

        public string CategoryId { get; }

        /// <summary>Empty for none.</summary>
        public string SubcategoryId { get; }
    }

    /// <summary>One place a product can be put in: a category id and where it is, e.g. "Grocery › Oils".</summary>
    public sealed class SiteCategoryOption
    {
        public SiteCategoryOption(string id, string path, bool isSub)
        {
            Id = id;
            Path = path;
            IsSub = isSub;
        }

        public string Id { get; }

        public string Path { get; }

        public bool IsSub { get; }
    }

    /// <summary>Where a product goes on the website, as chosen on the shop PC and kept with the product's photos.</summary>
    public sealed class WebsiteCategoryChoice
    {
        public const string ByMatch = "match";
        public const string ByAi = "ai";
        public const string ByOwner = "owner";

        public string CategoryId { get; set; } = "";

        /// <summary>A subcategory of <see cref="CategoryId"/>; empty for none.</summary>
        public string SubcategoryId { get; set; } = "";

        /// <summary>Who chose: <see cref="ByMatch"/> (the AI's first guess named a category of the website), <see cref="ByAi"/>
        /// (the AI chose from the website's list) or <see cref="ByOwner"/>.</summary>
        public string Source { get; set; } = "";

        public DateTime Chosen { get; set; }

        /// <summary>Where it was when chosen, e.g. "Grocery › Oils", to show when the website's list is not at hand.</summary>
        public string Path { get; set; } = "";

        public bool IsValidIn(SiteCategoryList list) => list != null && list.IsValid(CategoryId, SubcategoryId);

        public static WebsiteCategoryChoice Of(SiteCategoryList list, string categoryOrSubcategoryId, string source, DateTime now)
        {
            var place = list?.Resolve(categoryOrSubcategoryId);
            if (place == null)
            {
                return null;
            }

            return new WebsiteCategoryChoice
            {
                CategoryId = place.CategoryId,
                SubcategoryId = place.SubcategoryId,
                Source = source,
                Chosen = now,
                Path = list.PathOf(place.CategoryId, place.SubcategoryId),
            };
        }
    }

    /// <summary>
    /// Finds a category of the website named in words, without asking an AI: the AI that looked at the photos gave a first guess
    /// ("Home &amp; Kitchen &gt; Bottles"), and when that names a category of the website, that is the one.
    /// </summary>
    public static class CategoryMatcher
    {
        private static readonly char[] Separators = { '>', '/', '|', '›', '»', ',', ';' };

        /// <summary>The one category that the words name, or null when none does or they could mean more than one. The most specific
        /// part of each phrase is what counts ("Home &amp; Kitchen &gt; Bottles" is about bottles); with <paramref name="broader"/>, when
        /// the website has no such category, the part before it counts too (Home &amp; Kitchen).</summary>
        public static SiteCategory Find(SiteCategoryList list, bool broader, params string[] phrases)
        {
            if (list == null || list.IsEmpty)
            {
                return null;
            }

            foreach (var phrase in phrases ?? new string[0])
            {
                var parts = (phrase ?? "").Split(Separators).Select(Key).Where(part => part.Length > 0).ToList();
                for (var at = parts.Count - 1; at >= 0; at--)
                {
                    var found = list.All.Where(category => Key(category.Name) == parts[at]).ToList();
                    if (found.Count > 1 && at > 0)
                    {
                        var under = found.Where(c => c.ParentId.Length > 0 && Key(list.Find(c.ParentId)?.Name) == parts[at - 1]).ToList();
                        if (under.Count > 0)
                        {
                            found = under;
                        }
                    }

                    if (found.Count == 1)
                    {
                        return found[0];
                    }

                    if (!broader || found.Count > 1)
                    {
                        break;
                    }
                }
            }

            return null;
        }

        /// <summary>Words as they are compared: lower case, "&amp;" as "and", no marks, a plural as its single.</summary>
        internal static string Key(string text)
        {
            var words = Regex.Replace((text ?? "").ToLowerInvariant().Replace("&", " and "), @"[^\p{L}\p{N}]+", " ").Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Single);
            return string.Join(" ", words);
        }

        private static string Single(string word)
        {
            if (word.Length > 4 && word.EndsWith("ies", StringComparison.Ordinal))
            {
                return word.Substring(0, word.Length - 3) + "y";
            }

            if (word.Length > 4 && (word.EndsWith("ses", StringComparison.Ordinal) || word.EndsWith("xes", StringComparison.Ordinal)
                || word.EndsWith("ches", StringComparison.Ordinal) || word.EndsWith("shes", StringComparison.Ordinal)))
            {
                return word.Substring(0, word.Length - 2);
            }

            return word.Length > 3 && word.EndsWith("s", StringComparison.Ordinal) && !word.EndsWith("ss", StringComparison.Ordinal)
                ? word.Substring(0, word.Length - 1)
                : word;
        }
    }

    /// <summary>What the AI is told about a product to choose its category: words about it, never a price or a customer.</summary>
    public sealed class CategoryProduct
    {
        public string Name { get; set; } = "";

        public string WhatItIs { get; set; } = "";

        public string Description { get; set; } = "";

        public string ProductType { get; set; } = "";

        public List<string> Keywords { get; set; } = new List<string>();

        /// <summary>The AI's first guess at a category, written while it looked at the photos.</summary>
        public string SuggestedCategory { get; set; } = "";

        /// <summary>The category the POS keeps the product in.</summary>
        public string PosCategory { get; set; } = "";
    }

    /// <summary>
    /// Asks the AI to put a product in one category of the website, from the list of the website's own categories; an answer
    /// that is not on the list is not used. The AI chooses a place, and nothing else: no price and no new category.
    /// </summary>
    public static class CategoryPrompt
    {
        public const string SystemPrompt =
            "You file one product of a small shop in India under one category of the shop's website. Choose only from the list you are given,"
            + " and never make up a category or an id. Answer with JSON only.";

        public static string UserPrompt(CategoryProduct product, SiteCategoryList list)
        {
            var text = new StringBuilder();
            text.Append("Product: ").Append(Cut(product.Name, 160)).Append('\n');
            Line(text, "What it is", product.WhatItIs, 200);
            Line(text, "Description", product.Description, 400);
            Line(text, "Type", product.ProductType, 100);
            Line(text, "Search words", string.Join(", ", (product.Keywords ?? new List<string>()).Take(12)), 200);
            Line(text, "A first guess at the category, made from its photos", product.SuggestedCategory, 120);
            Line(text, "The shop's own category for it", product.PosCategory, 120);
            text.Append("\nThe website's categories, each with its id and where it is:\n");
            foreach (var option in list.Options())
            {
                text.Append(option.Id).Append(" | ").Append(option.Path).Append('\n');
            }

            return text.Append("\nChoose the one category where a customer would look for this product. Choose the most specific one that fits; a main category")
                .Append(" only when none of its subcategories fits. Answer with JSON only: {\"category_id\": \"<an id from the list>\"}.")
                .Append(" Use an empty string when nothing in the list fits at all.").ToString();
        }

        /// <summary>The category the answer names, when it is on the list; else null.</summary>
        public static SiteCategory ReadAnswer(string text, SiteCategoryList list)
        {
            var body = (text ?? "").Trim();
            var start = body.IndexOf('{');
            var end = body.LastIndexOf('}');
            if (list == null || list.IsEmpty || start < 0 || end <= start)
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

            var id = json["category_id"];
            if (id == null || id.Type != JTokenType.String)
            {
                return null;
            }

            var answer = ((string)id).Trim();
            if (answer.Length == 0)
            {
                return null;
            }

            // The id as given; or, if the AI wrote the place instead ("Grocery › Oils"), the option that has exactly that place.
            return list.Find(answer)
                ?? list.Options().Where(option => string.Equals(option.Path, answer, StringComparison.OrdinalIgnoreCase)).Select(option => list.Find(option.Id)).FirstOrDefault();
        }

        private static void Line(StringBuilder text, string label, string value, int length)
        {
            var tidy = SiteCategoryList.Tidy(value);
            if (tidy.Length > 0)
            {
                text.Append(label).Append(": ").Append(Cut(tidy, length)).Append('\n');
            }
        }

        private static string Cut(string text, int length)
        {
            var tidy = SiteCategoryList.Tidy(text);
            return tidy.Length <= length ? tidy : tidy.Substring(0, length);
        }
    }
}

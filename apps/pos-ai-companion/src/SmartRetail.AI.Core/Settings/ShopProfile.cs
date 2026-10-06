using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Settings
{
    /// <summary>Who one of the model photos shows: its title on the screen, and how the person looks.</summary>
    public sealed class ModelLook
    {
        /// <summary>E.g. "Filipino model". Shown on the screen and in the task for the AI.</summary>
        public string Title { get; set; } = "";

        /// <summary>E.g. "Filipino, in her late twenties". Empty: the AI chooses the person, with no look asked for.</summary>
        public string Looks { get; set; } = "";
    }

    /// <summary>
    /// What the pictures the AI makes need to know about the customer's business, from the profile NextGenOS prepares for it (<c>profile/ai.json</c>, beside the program):
    /// the country, the kind of business, who the model photos show, the festivals of its shoppers, the second language of its posters. Nothing here is assumed: with no profile
    /// every value is neutral (no country, no festival, no second language, models with no look asked for), and the owner's settings never change it
    /// (CLAUDE.md, section 8; docs/SETUP-STUDIO.md). The same file is made by the Setup Studio, and both read it by the same rules (tests/vectors/ai-profile.json).
    /// </summary>
    public sealed class ShopProfile
    {
        public const string FileName = "ai.json";
        public const int ModelPhotos = 3;
        public const int MaxFestivals = 24;
        private const long MaxBytes = 200 * 1024;

        /// <summary>The country as the prompts say it after "in", e.g. "the Philippines". Empty: no country is named.</summary>
        public string CountryName { get; set; } = "";

        /// <summary>The business as the prompts name it, e.g. "a small shop", "a small restaurant".</summary>
        public string ShopKind { get; set; } = "a small shop";

        /// <summary>The up to three model photos (photo 3, 4 and 5 of a product). Missing ones are neutral: "Model 1", with no look asked for.</summary>
        public List<ModelLook> Models { get; set; } = new List<ModelLook>();

        /// <summary>The festivals of this business's shoppers, for offer posters. Empty: a poster's occasion is typed in.</summary>
        public List<string> Festivals { get; set; } = new List<string>();

        /// <summary>The second language of the posters, e.g. "Hindi" or "Filipino". Empty: posters are in one language.</summary>
        public string LocalLanguage { get; set; } = "";

        /// <summary>The language's tag for the screen and the print, e.g. "hi" or "fil".</summary>
        public string LocalLanguageTag { get; set; } = "";

        /// <summary>The kinds of poster a ready-made second-language line can be given for (the dashboard's poster kinds).</summary>
        public static readonly string[] PosterLineKinds = { "clearance", "new-arrivals", "best-sellers", "festival-offer" };

        /// <summary>The poster's second-language line when no AI writes one, by kind (e.g. "clearance"). Empty: such a poster has no second-language line until an AI or a person writes it.</summary>
        public Dictionary<string, string> PosterLines { get; set; } = new Dictionary<string, string>();

        public static ShopProfile Neutral => new ShopProfile();

        /// <summary>" in the Philippines", or nothing.</summary>
        public string InCountry => CountryName.Length > 0 ? " in " + CountryName : "";

        /// <summary>"a small shop in the Philippines".</summary>
        public string Shop => ShopKind + InCountry;

        /// <summary>The scene for a product photo when the AI saw none: a typical place, in the country when it is named.</summary>
        public string TypicalPlace => "the most typical real-world place for this product" + InCountry + ", at home, at work or outdoors";

        public bool HasLocalLanguage => LocalLanguage.Length > 0;

        /// <summary>The model photo at <paramref name="index"/> (0 to 2), as the profile has it, else neutral.</summary>
        public ModelLook ModelAt(int index)
        {
            if (index < 0 || index >= ModelPhotos)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var given = index < Models.Count ? Models[index] : null;
            return new ModelLook
            {
                Title = !string.IsNullOrWhiteSpace(given?.Title) ? given.Title.Trim() : "Model " + (index + 1),
                Looks = given?.Looks?.Trim() ?? "",
            };
        }

        /// <summary>
        /// Reads a profile file's text. Tolerant: what cannot be used is left out and said in <paramref name="problems"/>, and nothing in it can do more than set these few words
        /// (no markup, no control characters, short). A file that is not JSON gives the neutral profile.
        /// </summary>
        public static ShopProfile Parse(string json, List<string> problems = null)
        {
            problems = problems ?? new List<string>();
            var profile = new ShopProfile();
            JObject root;
            try
            {
                root = JToken.Parse(json ?? "") as JObject;
            }
            catch (JsonException)
            {
                root = null;
            }

            if (root == null)
            {
                problems.Add("The AI profile is not a JSON object; the neutral one is used.");
                return profile;
            }

            if (root["schema"]?.Type != JTokenType.Integer || (int)root["schema"] != 1)
            {
                problems.Add("The AI profile does not say \"schema\": 1; the neutral one is used.");
                return profile;
            }

            profile.CountryName = Words((root["country"] as JObject)?["name"], 60, "the country's name", problems);
            var kind = Words(root["shopKind"], 60, "the kind of business", problems);
            if (kind.Length > 0)
            {
                profile.ShopKind = kind;
            }

            var images = root["images"] as JObject;
            if (images?["models"] is JArray models)
            {
                foreach (var item in models.Take(ModelPhotos))
                {
                    var one = item as JObject;
                    profile.Models.Add(new ModelLook { Title = Words(one?["title"], 40, "a model's title", problems), Looks = Words(one?["looks"], 120, "a model's looks", problems) });
                }
            }

            if (images?["festivals"] is JArray festivals)
            {
                foreach (var item in festivals)
                {
                    var name = Words(item, 40, "a festival", problems);
                    if (name.Length > 0 && !profile.Festivals.Contains(name, StringComparer.OrdinalIgnoreCase) && profile.Festivals.Count < MaxFestivals)
                    {
                        profile.Festivals.Add(name);
                    }
                }
            }

            var language = images?["localLanguage"] as JObject;
            if (language != null)
            {
                var name = Words(language["name"], 40, "the second language", problems);
                var tag = Words(language["tag"], 12, "the language tag", problems);
                if (name.Length > 0 && System.Text.RegularExpressions.Regex.IsMatch(tag, "^[a-z]{2,3}(-[A-Za-z0-9]{2,8})*$"))
                {
                    profile.LocalLanguage = name;
                    profile.LocalLanguageTag = tag;
                    if (language["lines"] is JObject lines)
                    {
                        foreach (var posterKind in PosterLineKinds)
                        {
                            var line = Words(lines[posterKind], 40, "a poster line", problems);
                            if (line.Length > 0)
                            {
                                profile.PosterLines[posterKind] = line;
                            }
                        }
                    }
                }
                else if (name.Length > 0 || tag.Length > 0)
                {
                    problems.Add("The second language needs a name and a tag like hi or fil; it is left out.");
                }
            }

            return profile;
        }

        /// <summary>A short plain phrase: no markup, no control characters, trimmed, at most <paramref name="max"/> letters; empty when it is not one.</summary>
        private static string Words(JToken token, int max, string what, List<string> problems)
        {
            if (token == null || token.Type == JTokenType.Null)
            {
                return "";
            }

            var text = token.Type == JTokenType.String ? (string)token : null;
            text = text?.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            if (text.Length > max || text.Any(c => char.IsControl(c) || c == '<' || c == '>' || c == '"' || c == '\\'))
            {
                problems.Add("Something in the AI profile is not usable as " + what + "; it is left out.");
                return "";
            }

            return text;
        }

        /// <summary>The profile in a folder (or, for the dashboard that lives in a folder inside the program's, the one above it); neutral when there is none.</summary>
        public static ShopProfile LoadNear(string baseDirectory, List<string> problems = null)
        {
            foreach (var folder in new[] { baseDirectory, baseDirectory == null ? null : Path.GetDirectoryName(baseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)) })
            {
                if (string.IsNullOrEmpty(folder))
                {
                    continue;
                }

                try
                {
                    var file = new FileInfo(Path.Combine(folder, "profile", FileName));
                    if (file.Exists && file.Length <= MaxBytes && (file.Attributes & FileAttributes.ReparsePoint) == 0)
                    {
                        return Parse(File.ReadAllText(file.FullName, System.Text.Encoding.UTF8), problems);
                    }
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    // as if it were not there
                }
            }

            return new ShopProfile();
        }
    }
}

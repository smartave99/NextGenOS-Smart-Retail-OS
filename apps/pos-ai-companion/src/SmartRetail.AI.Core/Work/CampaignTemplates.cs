using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Work
{
    /// <summary>One step of a campaign plan: what to do, and when, counted in days from the campaign's first day (before it is negative).</summary>
    public sealed class CampaignStep
    {
        public string Title { get; set; } = "";

        public int AfterDays { get; set; }

        public string Detail { get; set; } = "";
    }

    /// <summary>
    /// A way of planning a campaign: a name, how it reaches people, the steps in order, and the signs that will show whether it worked. A starting point the owner changes
    /// afterwards, never a promise of a result: it holds no price, no reach and no expected sales. The built-in one is neutral (no country, no trade, no channel assumed);
    /// the customer's own come from its profile (<c>profile/campaigns.json</c>, beside the program), which is where words about a market belong (CLAUDE.md, section 8).
    /// </summary>
    public sealed class CampaignTemplate
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        /// <summary>How it reaches people, in the owner's words ("pamphlets", "posters on vehicles"). May be empty.</summary>
        public string Channel { get; set; } = "";

        public string Summary { get; set; } = "";

        /// <summary>How many days it runs, when the owner does not choose.</summary>
        public int Days { get; set; } = 14;

        public List<CampaignStep> Steps { get; set; } = new List<CampaignStep>();

        /// <summary>What will show whether it worked, in words (what to count, what to ask).</summary>
        public List<string> Signs { get; set; } = new List<string>();

        /// <summary>
        /// The changes that make this plan for a campaign that starts on <paramref name="start"/>: the project, its steps as tasks (a step dated before today is moved to today),
        /// a note of the signs to watch, and a reminder to look at the numbers the day after it ends. Nothing is saved here.
        /// </summary>
        public List<WorkChange> Plan(string name, DateTime start, int days, decimal? budget, string area, DateTime today)
        {
            var title = WorkRules.Normalize(string.IsNullOrWhiteSpace(name) ? Name : name).Replace('\n', ' ');
            var end = start.Date.AddDays(Math.Max(1, days) - 1);
            var changes = new List<WorkChange>
            {
                new WorkChange
                {
                    Op = WorkOp.Add,
                    Item = new WorkItem { Kind = WorkKind.Project, Title = title, Detail = Summary, Starts = start.Date, Due = end, Budget = budget, Channel = Channel, Area = area ?? "" },
                },
            };

            foreach (var step in Steps)
            {
                var due = start.Date.AddDays(step.AfterDays);
                changes.Add(new WorkChange
                {
                    Op = WorkOp.Add,
                    Item = new WorkItem { Kind = WorkKind.Task, Title = step.Title, Detail = step.Detail, ProjectName = title, Due = due < today.Date ? today.Date : due },
                });
            }

            if (Signs.Count > 0)
            {
                changes.Add(new WorkChange
                {
                    Op = WorkOp.Add,
                    Item = new WorkItem { Kind = WorkKind.Note, Title = "How you will know", Detail = "Watch: " + string.Join("; ", Signs) + ".", ProjectName = title },
                });
            }

            changes.Add(new WorkChange
            {
                Op = WorkOp.Add,
                Item = new WorkItem { Kind = WorkKind.Reminder, Title = "Look at what you entered for " + title, ProjectName = title, Due = end.AddDays(1) < today.Date ? today.Date : end.AddDays(1) },
            });
            return changes;
        }
    }

    public static class CampaignTemplates
    {
        public const string FileName = "campaigns.json";
        public const int MaxTemplates = 12;
        public const int MaxSteps = 20;
        public const int MaxSigns = 6;
        private const long MaxBytes = 200 * 1024;

        private static readonly Regex Id = new Regex("^[a-z0-9][a-z0-9-]{0,29}$", RegexOptions.Compiled);

        /// <summary>The one every customer has: plain steps for a small advertising test, with no country, trade or channel in them.</summary>
        public static CampaignTemplate Neutral => new CampaignTemplate
        {
            Id = "local-advertising-test",
            Name = "A small advertising test",
            Channel = "",
            Summary = "Try one way of reaching people for a short time, count what you can, and decide afterwards. A starting point: change the steps to fit.",
            Days = 14,
            Steps =
            {
                new CampaignStep { Title = "Get at least three written quotations", AfterDays = -10, Detail = "Ask each for the full price and when it can be ready. Enter each as a quotation." },
                new CampaignStep { Title = "Decide the one message and the offer", AfterDays = -7, Detail = "One clear line, and what a person should do next." },
                new CampaignStep { Title = "Get the artwork or the wording made, and check it", AfterDays = -4 },
                new CampaignStep { Title = "Agree where, when and with whom it runs", AfterDays = -2 },
                new CampaignStep { Title = "Start, and take a photo of it in place", AfterDays = 0 },
                new CampaignStep { Title = "Count the people at the shop on the days before and on the days during", AfterDays = 0, Detail = "At least three days on each side, at the same hours." },
                new CampaignStep { Title = "Ask every new customer how they heard of the shop", AfterDays = 0, Detail = "Enter the enquiries you can count." },
            },
            Signs =
            {
                "people counted at the shop before and during",
                "enquiries, and what people say about how they heard of the shop",
                "the sales figures for the same days (the page shows them apart from your counts)",
            },
        };

        /// <summary>The built-in template, then the customer's.</summary>
        public static IReadOnlyList<CampaignTemplate> LoadNear(string baseDirectory, List<string> problems = null)
        {
            var all = new List<CampaignTemplate> { Neutral };
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
                        all.AddRange(Parse(File.ReadAllText(file.FullName, System.Text.Encoding.UTF8), problems));
                        break;
                    }
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    // as if it were not there
                }
            }

            return all;
        }

        /// <summary>
        /// Reads a profile file's text. Tolerant: a template or a step that cannot be used is left out and said in <paramref name="problems"/>. Words pass the same checks as
        /// anything else that goes into the plan, so a file cannot carry an instruction to the AI.
        /// </summary>
        public static IReadOnlyList<CampaignTemplate> Parse(string json, List<string> problems = null)
        {
            problems = problems ?? new List<string>();
            var found = new List<CampaignTemplate>();
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
                problems.Add("The campaign templates are not a JSON object; the built-in one is used.");
                return found;
            }

            if (!(root["schema"] is JValue schema && schema.Type == JTokenType.Integer && schema.Value is long number && number == 1))
            {
                problems.Add("The campaign templates do not say \"schema\": 1; the built-in one is used.");
                return found;
            }

            foreach (var item in (root["templates"] as JArray ?? new JArray()).OfType<JObject>())
            {
                if (found.Count >= MaxTemplates)
                {
                    problems.Add("Only the first " + MaxTemplates + " campaign templates are used.");
                    break;
                }

                var template = ReadTemplate(item, problems);
                if (template != null && found.All(t => t.Id != template.Id) && template.Id != Neutral.Id)
                {
                    found.Add(template);
                }
            }

            return found;
        }

        private static CampaignTemplate ReadTemplate(JObject item, List<string> problems)
        {
            var id = ((string)item["id"] ?? "").Trim();
            var name = Words(item["name"], 60, "a template's name", problems);
            if (!Id.IsMatch(id) || name.Length == 0)
            {
                problems.Add("A campaign template needs an id (letters, numbers and hyphens) and a name; it is left out.");
                return null;
            }

            var template = new CampaignTemplate
            {
                Id = id,
                Name = name,
                Channel = Words(item["channel"], WorkRules.ChannelLimit, "a template's channel", problems),
                Summary = Words(item["summary"], 200, "a template's summary", problems),
            };
            var days = item["days"];
            if (days != null && days.Type == JTokenType.Integer && (int)days >= 1 && (int)days <= 365)
            {
                template.Days = (int)days;
            }

            foreach (var step in (item["steps"] as JArray ?? new JArray()).OfType<JObject>().Take(MaxSteps))
            {
                var title = Words(step["title"], 100, "a step's title", problems);
                var after = step["afterDays"];
                if (title.Length == 0 || after == null || after.Type != JTokenType.Integer || (int)after < -60 || (int)after > 365)
                {
                    problems.Add("A step of \"" + name + "\" needs a title and afterDays between -60 and 365; it is left out.");
                    continue;
                }

                template.Steps.Add(new CampaignStep { Title = title, AfterDays = (int)after, Detail = Words(step["detail"], 300, "a step's note", problems) });
            }

            foreach (var sign in (item["signs"] as JArray ?? new JArray()).Take(MaxSigns))
            {
                var words = Words(sign, 120, "a sign", problems);
                if (words.Length > 0)
                {
                    template.Signs.Add(words);
                }
            }

            if (template.Steps.Count == 0)
            {
                problems.Add("\"" + name + "\" has no usable steps; it is left out.");
                return null;
            }

            return template;
        }

        private static string Words(JToken token, int max, string what, List<string> problems)
        {
            var text = token != null && token.Type == JTokenType.String ? ((string)token).Trim() : "";
            if (text.Length == 0)
            {
                return "";
            }

            var problem = WorkRules.CheckWords(text, max, what);
            if (problem != null || text.Any(c => c == '<' || c == '>'))
            {
                problems.Add("Something in the campaign templates is not usable as " + what + "; it is left out.");
                return "";
            }

            return text;
        }
    }
}

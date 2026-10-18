using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SmartRetail.AI.Work
{
    /// <summary>People counted by hand before and during a campaign, set side by side.</summary>
    public sealed class FootfallComparison
    {
        /// <summary>Days the owner counted before the campaign (a day counted twice is added up), and the people a counted day brought on average.</summary>
        public int BaselineDays { get; set; }

        public decimal BaselineAverage { get; set; }

        public int DuringDays { get; set; }

        public decimal DuringAverage { get; set; }

        /// <summary>The during average against the baseline one (0.2 is 20% more); null when there is not enough to compare.</summary>
        public decimal? Change { get; set; }

        /// <summary>"Not enough counted days", "Higher", "Lower" or "About the same".</summary>
        public string Verdict { get; set; } = "";

        public string Words { get; set; } = "";
    }

    /// <summary>
    /// What the owner's own entries and plan say about one campaign, in the owner's words and with the limits said. Everything here comes from the assistant's own plan:
    /// the owner's entries (counts, enquiries, spending, quotations) are labelled as entered by the owner and are never mixed with the POS's sales figures, which the page
    /// shows separately. Nothing here is estimated: no price, no reach, no sale is made up.
    /// </summary>
    public sealed class CampaignReport
    {
        /// <summary>Fewer counted days than this on either side say too little.</summary>
        public const int MinCountedDays = 3;

        /// <summary>A change smaller than this (either way) is "about the same".</summary>
        public const decimal ClearChange = 0.10m;

        /// <summary>The days before the campaign that count as its baseline.</summary>
        public const int BaselineWindowDays = 28;

        /// <summary>What a comparison of counts can and cannot show, for every screen that shows one.</summary>
        public const string Limits = "These are counts the owner entered by hand, on the days the owner chose to count. Weather, market days, holidays, where the counter stood and who counted can all change them, "
            + "so a difference is a hint to look further, not proof that the campaign caused it.";

        public WorkItem Project { get; set; }

        public int TasksOpen { get; set; }

        public int TasksDone { get; set; }

        public int TasksLate { get; set; }

        public decimal? Budget { get; set; }

        /// <summary>Money spent as the owner entered it (the sum of the expense entries); not read from any bill or bank.</summary>
        public decimal Spent { get; set; }

        public int ExpenseEntries { get; set; }

        public bool OverBudget => Budget.HasValue && Spent > Budget.Value;

        /// <summary>The owner's quotations, cheapest first, as entered.</summary>
        public List<WorkItem> Quotes { get; } = new List<WorkItem>();

        /// <summary>Enquiries the owner entered, added up.</summary>
        public decimal Enquiries { get; set; }

        /// <summary>Money spent per enquiry, from the owner's entries; null when there is no spending or no enquiry.</summary>
        public decimal? SpentPerEnquiry { get; set; }

        public FootfallComparison Footfall { get; set; }

        /// <summary>Whether there is nothing the owner entered yet.</summary>
        public bool NoEntries => ExpenseEntries == 0 && Quotes.Count == 0 && Enquiries == 0 && Footfall == null;

        public static CampaignReport For(WorkBook book, WorkItem project, DateTime now)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            var inside = book.In(project.Id).ToList();
            var report = new CampaignReport { Project = project, Budget = project.Budget };

            foreach (var task in inside.Where(i => i.Kind == WorkKind.Task || i.Kind == WorkKind.Reminder))
            {
                if (task.Status == WorkStatus.Done)
                {
                    report.TasksDone++;
                }
                else if (task.Status == WorkStatus.Open)
                {
                    report.TasksOpen++;
                    if (task.Due.HasValue && task.Due.Value.Date < now.Date)
                    {
                        report.TasksLate++;
                    }
                }
            }

            var records = inside.Where(i => i.Kind == WorkKind.Record && i.Status == WorkStatus.Open).ToList();
            var expenses = records.Where(r => r.Label == RecordLabels.Expense && r.Amount.HasValue).ToList();
            report.Spent = expenses.Sum(r => r.Amount.Value);
            report.ExpenseEntries = expenses.Count;
            report.Quotes.AddRange(records.Where(r => r.Label == RecordLabels.Quote && r.Amount.HasValue).OrderBy(r => r.Amount));
            report.Enquiries = records.Where(r => r.Label == RecordLabels.Leads && r.Amount.HasValue).Sum(r => r.Amount.Value);
            report.SpentPerEnquiry = report.Spent > 0 && report.Enquiries > 0 ? Math.Round(report.Spent / report.Enquiries, 2) : (decimal?)null;
            report.Footfall = Compare(records.Where(r => r.Label == RecordLabels.Footfall && r.Amount.HasValue && r.Due.HasValue).ToList(), project, now);
            return report;
        }

        private static FootfallComparison Compare(IReadOnlyList<WorkItem> counts, WorkItem project, DateTime now)
        {
            if (counts.Count == 0)
            {
                return null;
            }

            var comparison = new FootfallComparison { Verdict = "Not enough counted days" };
            if (!project.Starts.HasValue)
            {
                comparison.Words = "Give the campaign a start day, so the days before it and the days during it can be told apart.";
                return comparison;
            }

            var start = project.Starts.Value.Date;
            var end = (project.Due?.Date ?? now.Date) > now.Date ? now.Date : (project.Due?.Date ?? now.Date);
            var perDay = counts.GroupBy(c => c.Due.Value.Date).ToDictionary(g => g.Key, g => g.Sum(c => c.Amount.Value));
            var before = perDay.Where(d => d.Key < start && d.Key >= start.AddDays(-BaselineWindowDays)).Select(d => d.Value).ToList();
            var during = perDay.Where(d => d.Key >= start && d.Key <= end).Select(d => d.Value).ToList();

            comparison.BaselineDays = before.Count;
            comparison.BaselineAverage = before.Count == 0 ? 0 : Math.Round(before.Average(), 1);
            comparison.DuringDays = during.Count;
            comparison.DuringAverage = during.Count == 0 ? 0 : Math.Round(during.Average(), 1);

            if (before.Count < MinCountedDays || during.Count < MinCountedDays)
            {
                comparison.Words = "Counted on " + Days(before.Count) + " before and " + Days(during.Count) + " during. To compare, count on at least "
                    + MinCountedDays + " days on each side (the " + BaselineWindowDays + " days before the start count as before).";
                return comparison;
            }

            if (comparison.BaselineAverage <= 0)
            {
                comparison.Words = "The days counted before had no people, so there is nothing to compare with.";
                return comparison;
            }

            var change = comparison.DuringAverage / comparison.BaselineAverage - 1m;
            comparison.Change = Math.Round(change, 3);
            comparison.Verdict = Math.Abs(change) < ClearChange ? "About the same" : change > 0 ? "Higher" : "Lower";
            comparison.Words = "Before: " + Number(comparison.BaselineAverage) + " people a counted day (" + Days(before.Count) + "). During: " + Number(comparison.DuringAverage) + " (" + Days(during.Count) + "), "
                + (comparison.Verdict == "About the same" ? "about the same."
                    : Math.Round(Math.Abs(change) * 100m, 0, MidpointRounding.AwayFromZero).ToString("0", CultureInfo.InvariantCulture) + "% " + (change > 0 ? "higher." : "lower."));
            return comparison;
        }

        private static string Days(int n) => n == 1 ? "1 counted day" : n + " counted days";

        private static string Number(decimal value) => value.ToString("0.#", CultureInfo.InvariantCulture);
    }
}

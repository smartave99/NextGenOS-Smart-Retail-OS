using System.Globalization;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Knowledge;
using NextGenOS.Hub.Reports;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Assistant;

/// <summary>A lookup the assistant may run: what it is called, what it can be told, who may use it, and the one function that does it.</summary>
internal sealed record ToolSpec(string Id, string Title, string Describes, IReadOnlyList<ToolArg> Args, IReadOnlyList<string> NeededAny, Func<IReadOnlyDictionary<string, string>, string, CancellationToken, Task<ToolResult>> Run)
{
    public ToolInfo Info => new(Id, Title, Describes, Args);

    /// <summary>Empty list: anyone who is signed in (what comes back is still limited by the kind of thing the person may read). Otherwise: a person with at least one of these permissions.</summary>
    public bool CanUse(Actor who) => NeededAny.Count == 0 || who.CanAny(NeededAny);
}

/// <summary>The periods a lookup can be asked about, in words a model can choose from.</summary>
public static class AssistantPeriods
{
    public static readonly IReadOnlyList<string> All = ["today", "yesterday", "last-7-days", "last-30-days", "this-month", "last-month"];

    /// <summary>The first and last day and the words for it, or null when the word is not one of the periods.</summary>
    public static (DateOnly From, DateOnly To, string Label)? Resolve(string? period, DateOnly today) => period switch
    {
        "today" => (today, today, "today"),
        "yesterday" => (today.AddDays(-1), today.AddDays(-1), "yesterday"),
        "last-7-days" => (today.AddDays(-6), today, "the last 7 days"),
        "last-30-days" => (today.AddDays(-29), today, "the last 30 days"),
        "this-month" => (new DateOnly(today.Year, today.Month, 1), today, "this month"),
        "last-month" => (new DateOnly(today.Year, today.Month, 1).AddMonths(-1), new DateOnly(today.Year, today.Month, 1).AddDays(-1), "last month"),
        _ => null,
    };

    public static string Describe((DateOnly From, DateOnly To, string Label) p) =>
        p.From == p.To ? p.Label + " (" + Day(p.From) + ")" : p.Label + " (" + Day(p.From) + " to " + Day(p.To) + ")";

    private static string Day(DateOnly day) => day.ToString("d MMM yyyy", CultureInfo.InvariantCulture);
}

/// <summary>
/// The closed list of lookups (Version 2, Phase 6, step 1). Each one only READS, uses the shop's own services (which ask for the person's permission again themselves), and says in the
/// lines it returns what period and what kind of figure it is, so that a line can be read and checked on its own.
/// </summary>
internal static class AssistantTools
{
    public const string NotesId = "notes.search";
    public const string SalesId = "sales.summary";
    public const string BestId = "sales.best-sellers";
    public const string StockId = "stock.out";

    private const int OutOfStockLines = 15;
    private const int BestSellers = 5;

    private static readonly ToolArg PeriodArg = new("period", "the days to look at", AssistantPeriods.All);

    public static IReadOnlyList<ToolSpec> Build(ReportService reports, KnowledgeService knowledge, ShopContextProvider shop, IClock clock)
    {
        DateOnly Today() => shop.Current.Time.LocalDate(clock.UtcNow);

        (DateOnly From, DateOnly To, string Label) Period(IReadOnlyDictionary<string, string> args)
        {
            var asked = args.GetValueOrDefault("period");
            return AssistantPeriods.Resolve(asked, Today())
                ?? throw new HubException("bad-lookup", asked is null ? "The lookup was not told which days to look at." : "'" + Prompts.Clip(asked, 30) + "' is not a period the assistant knows.");
        }

        return
        [
            new ToolSpec(NotesId, "Your notes", "Search the shop's own written notes (a supplier's terms, a way of doing things, a decision).",
                [new ToolArg("words", "what to look for, in a few words")], [],
                async (args, question, cancel) =>
                {
                    var words = Prompts.Clip(Prompts.OneLine(args.GetValueOrDefault("words") is { Length: > 0 } w ? w : question), KnowledgeService.MaxQueryChars);
                    var found = await knowledge.SearchAsync(words, 5, cancel);
                    var lines = found.Hits.Select(h => new ToolLine("From the note “" + h.Title + "” (" + h.Ref + "): " + h.Excerpt, h.Ref)).ToList();
                    return new ToolResult(lines, found.Hits.Aggregate(DataClass.Internal, (all, h) => Stricter(all, h.DataClass)), found.Note);
                }),

            new ToolSpec(SalesId, "Sales", "Total sales, the number of sales, the average sale, the tax and what was given back, for a period.",
                [PeriodArg], [Perm.Reports, Perm.Sell],
                (args, _, _) =>
                {
                    var p = Period(args);
                    var s = reports.Summary(p.From, p.To);
                    var when = AssistantPeriods.Describe(p);
                    var sale = shop.Current.Singular("sale").ToLowerInvariant();
                    var text = s.Documents == 0
                        ? "Sales for " + when + ": there were no " + shop.Current.Plural("sale").ToLowerInvariant() + "."
                        : "Sales for " + when + ": " + shop.Current.Money(s.TotalMinor) + " from " + s.Documents.ToString(CultureInfo.InvariantCulture) + " " + (s.Documents == 1 ? sale : shop.Current.Plural("sale").ToLowerInvariant()) +
                          ", " + shop.Current.Money(s.AverageMinor) + " on average for each; tax " + shop.Current.Money(s.TaxMinor) + "; given back to customers " + shop.Current.Money(s.RefundsMinor) + ".";
                    return Task.FromResult(new ToolResult([new ToolLine(text)], DataClass.Financial));
                }),

            new ToolSpec(BestId, "Best sellers", "The " + BestSellers + " items that sold the most, by money earned or by quantity sold, for a period.",
                [PeriodArg, new ToolArg("by", "what to rank by", ["money", "quantity"])], [Perm.Reports],
                (args, _, _) =>
                {
                    var p = Period(args);
                    var by = args.GetValueOrDefault("by") ?? "money";
                    if (by is not ("money" or "quantity")) throw new HubException("bad-lookup", "'" + Prompts.Clip(by, 30) + "' is not a way of ranking the assistant knows.");
                    var top = reports.TopItems(p.From, p.To, BestSellers, byQuantity: by == "quantity");
                    var when = AssistantPeriods.Describe(p);
                    List<ToolLine> lines = top.Count == 0
                        ? [new ToolLine("Best sellers for " + when + ": nothing was sold.")]
                        : top.Select((t, i) => new ToolLine("Best seller number " + (i + 1).ToString(CultureInfo.InvariantCulture) + " by " + by + " for " + when + ": " + t.Name + ", " +
                            ShopContext.Qty(t.QtyMilli).TrimEnd('0').TrimEnd('.') + " sold for " + shop.Current.Money(t.RevenueMinor) + ".")).ToList();
                    return Task.FromResult(new ToolResult(lines, DataClass.Financial));
                }),

            new ToolSpec(StockId, "Out of stock", "The items that keep stock and have none left.",
                [], [Perm.Reports, Perm.Stock],
                (_, _, _) =>
                {
                    var gone = reports.OutOfStock();
                    var lines = new List<ToolLine> { new(gone.Count == 0 ? "No item that keeps stock is out of stock." : gone.Count + (gone.Count == 1 ? " item that keeps stock has none left." : " items that keep stock have none left (or less than none).")) };
                    lines.AddRange(gone.Take(OutOfStockLines).Select(o => new ToolLine("Out of stock: " + o.Name + " (" + ShopContext.Qty(o.OnHandMilli).TrimEnd('0').TrimEnd('.') + " " + o.Unit + " on hand).")));
                    if (gone.Count > OutOfStockLines) lines.Add(new ToolLine("There are " + (gone.Count - OutOfStockLines) + " more out of stock that are not listed here."));
                    return Task.FromResult(new ToolResult(lines, DataClass.Internal));
                }),
        ];
    }

    private static readonly string[] Strictness =
        [DataClass.Public, DataClass.Internal, DataClass.Confidential, DataClass.Financial, DataClass.Personal, DataClass.Video, DataClass.Audio, DataClass.Biometric, DataClass.PaymentSensitive];

    /// <summary>The more private of two kinds of information (an unknown kind counts as the most private, so it is never sent where less would be allowed).</summary>
    public static string Stricter(string a, string b)
    {
        var ra = Array.IndexOf(Strictness, a) is var x and >= 0 ? x : int.MaxValue;
        var rb = Array.IndexOf(Strictness, b) is var y and >= 0 ? y : int.MaxValue;
        return ra >= rb ? a : b;
    }
}

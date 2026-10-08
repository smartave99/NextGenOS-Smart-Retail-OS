using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Insights;

/// <summary>What the low-stock rule is told to use. Kept as data (one row in <c>insight_settings</c>), changed by the owner; these are the starting values.</summary>
public sealed record LowStockSettings(int WindowDays = 28, int ReviewDays = 7, int MinHistoryDays = 7, int SnoozeDays = 7)
{
    public const int MaxWindowDays = 365;

    /// <summary>The settings, or the reason they cannot be used.</summary>
    public string? Problem =>
        WindowDays is < 7 or > MaxWindowDays ? "Look back over between 7 and 365 days." :
        ReviewDays is < 0 or > 90 ? "An order should cover between 0 and 90 days beyond the delivery time." :
        MinHistoryDays < 1 || MinHistoryDays > WindowDays ? "The least history needed must be at least 1 day and no more than the days looked back over." :
        SnoozeDays is < 0 or > 90 ? "Keep a set-aside item quiet for between 0 and 90 days." : null;
}

/// <summary>For an item that is bought in: who delivers it, how long they take, the spare days the owner wants, how it is packed and the least that is sent.</summary>
public sealed record SupplyTerms(long ItemId, long SupplierId, int LeadDays, int SafetyDays, long PackMilli, long MinOrderMilli, long? EnteredBy, DateTimeOffset EnteredAt)
{
    /// <summary>The days the shelf must last: the supplier's delivery time plus the spare days.</summary>
    public int ThresholdDays => LeadDays + SafetyDays;
}

/// <summary>Everything the rule looks at for one item, as plain numbers, so the same figures always give the same answer.</summary>
public sealed record StockInput(
    long ItemId, string Name, string Unit, long OnHandMilli, long SoldMilli, int HistoryDays, long OpenOrderMilli, SupplyTerms? Terms, string? SupplierName,
    IReadOnlyList<long> SaleDocuments, IReadOnlyList<long> OpenOrders);

public static class LowStockStatus
{
    /// <summary>It will run out before a new delivery could arrive, and an order is proposed.</summary>
    public const string Order = "order";
    /// <summary>It will run out before a delivery could arrive, but orders already on the way cover it.</summary>
    public const string Covered = "covered";
    public const string Ok = "ok";
    /// <summary>Nothing was sold in the days looked at, so there is no pace to judge by.</summary>
    public const string NoSales = "no-sales";
    /// <summary>The item has not been in stock for long enough to know its pace.</summary>
    public const string ShortHistory = "short-history";
    /// <summary>Nobody has said who supplies it or how long they take.</summary>
    public const string NoTerms = "no-terms";

    public static bool NeedsAttention(string status) => status is Order or Covered;
}

/// <summary>One item's result, with the figures it rests on.</summary>
public sealed record LowStockFinding(
    StockInput Input, string Status, int EffectiveDays, long ProposedMilli, int ThresholdDays, int TargetDays)
{
    public long ItemId => Input.ItemId;

    /// <summary>How many days what is on the shelf lasts at the pace of the last days, to one decimal place; null when there is no pace.</summary>
    public decimal? CoverDays => Input.SoldMilli > 0 && EffectiveDays > 0 ? Math.Round(Math.Max(0, Input.OnHandMilli) * (decimal)EffectiveDays / Input.SoldMilli, 1, MidpointRounding.AwayFromZero) : null;

    /// <summary>The pace, in thousandths of a unit a day, to one decimal place.</summary>
    public decimal PerDayMilli => EffectiveDays > 0 ? Math.Round(Input.SoldMilli / (decimal)EffectiveDays, 1, MidpointRounding.AwayFromZero) : 0;
}

/// <summary>
/// The low-stock rule (blueprint INS-011), version 1. It is arithmetic on figures the shop already keeps, never a guess by a model: for each item that has a supplier and a delivery time, how
/// many days does what is on the shelf last at the pace the item has really sold at lately, and is that less than the days the supplier needs plus the spare days the owner wants? If so an
/// order is proposed that covers the delivery time, the spare days and the review days beyond it, less what is already on the shelf and already ordered, rounded up to the pack the supplier
/// sends and never below the least they send.
/// <para>
/// Everything is whole numbers: the test is "on hand × days looked at &lt; sold × days to last" so no rounding decides whether an item is flagged, and the proposed quantity is rounded up,
/// never down. The pace is net: returns bring sales down.
/// </para>
/// </summary>
public static class LowStockRule
{
    public const string RuleId = "low_stock";
    public const string Version = "1";

    private static long CeilDiv(BigInteger a, BigInteger b) => (long)((a + b - 1) / b);

    /// <summary>Judges one item.</summary>
    public static LowStockFinding Judge(StockInput input, LowStockSettings settings)
    {
        var terms = input.Terms;
        if (terms is null) return new LowStockFinding(input, LowStockStatus.NoTerms, 0, 0, 0, 0);
        var days = Math.Min(settings.WindowDays, input.HistoryDays);
        var threshold = terms.ThresholdDays;
        var target = threshold + settings.ReviewDays;
        if (input.HistoryDays < settings.MinHistoryDays) return new LowStockFinding(input, LowStockStatus.ShortHistory, days, 0, threshold, target);
        if (input.SoldMilli <= 0 || days <= 0) return new LowStockFinding(input, LowStockStatus.NoSales, days, 0, threshold, target);

        // Flagged when what is on hand lasts fewer days than the delivery time plus the spare days: onHand / (sold / days) < threshold, without dividing.
        var lasts = (BigInteger)Math.Max(0, input.OnHandMilli) * days < (BigInteger)input.SoldMilli * threshold;
        if (!lasts) return new LowStockFinding(input, LowStockStatus.Ok, days, 0, threshold, target);

        // The order: enough for the days to come, less what is here and what is already on its way.
        var need = CeilDiv((BigInteger)input.SoldMilli * target, days) - input.OnHandMilli - input.OpenOrderMilli;
        if (need <= 0) return new LowStockFinding(input, LowStockStatus.Covered, days, 0, threshold, target);
        var packs = CeilDiv(need, terms.PackMilli);
        var proposed = Math.Max(packs * terms.PackMilli, CeilDiv(terms.MinOrderMilli, terms.PackMilli) * terms.PackMilli);
        return new LowStockFinding(input, LowStockStatus.Order, days, proposed, threshold, target);
    }

    /// <summary>Judges every item, most urgent first (the least cover compared with what is needed), then by item number. The same inputs always come out in the same order.</summary>
    public static IReadOnlyList<LowStockFinding> Evaluate(IEnumerable<StockInput> inputs, LowStockSettings settings) =>
        inputs.Select(i => Judge(i, settings))
            .OrderBy(f => LowStockStatus.NeedsAttention(f.Status) ? 0 : 1)
            .ThenBy(f => Urgency(f))
            .ThenBy(f => f.ItemId)
            .ToList();

    private static decimal Urgency(LowStockFinding f) =>
        f.CoverDays is { } cover && f.ThresholdDays > 0 ? cover / f.ThresholdDays : decimal.MaxValue;

    /// <summary>A fingerprint of everything the rule looked at. The same figures give the same fingerprint, so a run can be shown to rest on the figures it says it does.</summary>
    public static string Fingerprint(IEnumerable<StockInput> inputs, LowStockSettings settings, DateTimeOffset asOf)
    {
        var text = new StringBuilder();
        text.Append(RuleId).Append('|').Append(Version).Append('|').Append(asOf.UtcDateTime.ToString("O", CultureInfo.InvariantCulture)).Append('|')
            .Append(settings.WindowDays).Append(',').Append(settings.ReviewDays).Append(',').Append(settings.MinHistoryDays).Append(',').Append(settings.SnoozeDays).Append('\n');
        foreach (var i in inputs.OrderBy(x => x.ItemId))
        {
            var t = i.Terms;
            text.Append(i.ItemId).Append('|').Append(i.OnHandMilli).Append('|').Append(i.SoldMilli).Append('|').Append(i.HistoryDays).Append('|').Append(i.OpenOrderMilli).Append('|')
                .Append(t is null ? "-" : string.Join(',', t.SupplierId, t.LeadDays, t.SafetyDays, t.PackMilli, t.MinOrderMilli)).Append('\n');
        }

        return Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text.ToString())));
    }

    // ---- in plain words ---------------------------------------------------------------------------------------------------------------

    private static string Q(long milli, string unit) => ShopContext.Qty(milli).TrimEnd('0').TrimEnd('.') + (string.IsNullOrWhiteSpace(unit) ? "" : " " + unit);

    /// <summary>What the rule found and why, for the owner to read.</summary>
    public static string Explain(LowStockFinding f, LowStockSettings settings)
    {
        var i = f.Input;
        switch (f.Status)
        {
            case LowStockStatus.NoTerms: return i.Name + " has no supplier or delivery time yet, so it cannot be judged.";
            case LowStockStatus.ShortHistory: return i.Name + " has been in stock for only " + i.HistoryDays + " day(s); at least " + settings.MinHistoryDays + " are needed to know how fast it sells.";
            case LowStockStatus.NoSales: return "No " + i.Name + " was sold in the last " + f.EffectiveDays + " day(s), so there is no pace to judge by.";
        }

        var pace = Q((long)Math.Round(f.PerDayMilli, MidpointRounding.AwayFromZero), i.Unit);
        var text = new StringBuilder();
        text.Append(i.Name).Append(": ").Append(Q(i.OnHandMilli, i.Unit)).Append(" on the shelf. It sold ").Append(Q(i.SoldMilli, i.Unit)).Append(" in the last ").Append(f.EffectiveDays)
            .Append(" day(s), about ").Append(pace).Append(" a day, so what is here lasts about ").Append(f.CoverDays?.ToString("0.#", CultureInfo.InvariantCulture)).Append(" day(s). ");
        text.Append(i.SupplierName ?? "The supplier").Append(" takes ").Append(i.Terms!.LeadDays).Append(" day(s) to deliver and you want ").Append(i.Terms.SafetyDays).Append(" spare, so it should last at least ").Append(f.ThresholdDays).Append(". ");
        if (f.Status == LowStockStatus.Ok) text.Append("It does.");
        else if (f.Status == LowStockStatus.Covered) text.Append("It will not, but ").Append(Q(i.OpenOrderMilli, i.Unit)).Append(" already ordered covers the next ").Append(f.TargetDays).Append(" day(s).");
        else
        {
            text.Append("It will not. About ").Append(Q(f.ProposedMilli, i.Unit)).Append(" would cover the next ").Append(f.TargetDays).Append(" day(s)");
            if (i.OpenOrderMilli > 0) text.Append(" after the ").Append(Q(i.OpenOrderMilli, i.Unit)).Append(" already ordered");
            text.Append('.');
        }

        return text.ToString();
    }

    /// <summary>The ways this could be wrong, always shown with the finding.</summary>
    public static string WhyWrong(LowStockFinding f) =>
        "Sales may not go on at the same pace (a season, a price change, a supplier that is shut). Returns and stock counts are taken as they were written down. " +
        "The delivery time is the one a person typed" + (f.Input.Terms is { } t ? " on " + t.EnteredAt.UtcDateTime.ToString("d MMM yyyy", CultureInfo.InvariantCulture) : "") + "; a supplier that has become slower is not noticed until it is changed. " +
        "Goods already ordered are counted only while the order is open. A quantity is a proposal: look at it before you order.";
}

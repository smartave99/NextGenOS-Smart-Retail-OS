using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Core.Labels;

/// <summary>What one sticker shows: the code the till scans, the product's name, and its MRP and price.</summary>
public sealed record Sticker(int ProductId, string Code, string Name, decimal Mrp, decimal Price)
{
    /// <summary>At most this many stickers are printed at once (about 30 sheets of 65).</summary>
    public const int MaxPerPrint = 2000;

    public static Sticker For(StockBatch batch)
    {
        ArgumentNullException.ThrowIfNull(batch);
        return new Sticker(batch.ProductId, batch.Code, batch.Name, batch.Mrp, batch.Price);
    }

    /// <summary>Each sticker repeated as many times as asked, in order, up to <see cref="MaxPerPrint"/> in all.</summary>
    public static IReadOnlyList<Sticker> Repeat(IEnumerable<(Sticker Sticker, int Count)> wanted)
    {
        ArgumentNullException.ThrowIfNull(wanted);
        return wanted
            .SelectMany(w => Enumerable.Repeat(w.Sticker, Math.Max(0, w.Count)))
            .Take(MaxPerPrint)
            .ToList();
    }

    /// <summary>The MRP when it is printed on the sticker too, i.e. set and not below the price.</summary>
    public bool ShowsMrp => Mrp > 0 && Mrp > Price;

    /// <summary>The narrowest bar most shop scanners read reliably, in mm (Code 128's usual minimum is 0.19 mm).</summary>
    public const decimal NarrowestBarMm = 0.19m;

    /// <summary>Why <paramref name="code"/> would not scan on <paramref name="sheet"/>, or null when it will.</summary>
    public static string? Fits(string code, LabelSheet sheet)
    {
        ArgumentNullException.ThrowIfNull(sheet);
        if (!Code128.CanEncode(code))
        {
            return string.IsNullOrEmpty(code)
                ? "It has no code to print."
                : "Its code has letters a barcode cannot hold (only English letters, digits and simple signs).";
        }

        return ModuleMm(code, sheet) < NarrowestBarMm
            ? $"Its code is too long to scan on {(sheet.Id == "book" ? "a card" : "these stickers")}: choose bigger stickers."
            : null;
    }

    /// <summary>How wide the thinnest bar prints on <paramref name="sheet"/>, in mm.</summary>
    public static decimal ModuleMm(string code, LabelSheet sheet)
    {
        ArgumentNullException.ThrowIfNull(sheet);
        return sheet.BarsWidthMm / Code128.Width(code);
    }
}

namespace SmartRetail.Pos.Core.Labels;

/// <summary>
/// Sticker paper: an A4 sheet of stickers for any printer, or a roll in a label printer, where each page is one row
/// of stickers. Sizes in millimetres, as printed on the pack.
/// </summary>
public sealed record LabelSheet(
    string Id,
    string Name,
    decimal PageWidthMm,
    decimal PageHeightMm,
    int Across,
    int Down,
    decimal LabelWidthMm,
    decimal LabelHeightMm,
    decimal TopMm = 0,
    decimal LeftMm = 0,
    decimal GapAcrossMm = 0,
    decimal GapDownMm = 0)
{
    public int PerPage => Across * Down;

    public bool IsRoll => Down == 1 && PageHeightMm == LabelHeightMm;

    /// <summary>How wide a sticker's barcode prints, in mm: 92% of the sticker less its margins (1.5 mm a side, 2.5 mm
    /// on stickers 30 mm tall or more), or the counter book card's width less its margins. As laid out in app.css.</summary>
    public decimal BarsWidthMm => Id == "book"
        ? LabelWidthMm - 5.6m
        : (LabelWidthMm - (LabelHeightMm >= 30 ? 5m : 3m)) * 0.92m;

    /// <summary>The common sheets (A4 sizes as Avery and the Indian brands make them) and label printer rolls.</summary>
    public static IReadOnlyList<LabelSheet> All { get; } = new[]
    {
        new LabelSheet("a4-65", "A4 sheet, 65 stickers (38.1 × 21.2 mm)", 210, 297, 5, 13, 38.1m, 21.2m, 10.7m, 4.65m, 2.5m),
        new LabelSheet("a4-40", "A4 sheet, 40 stickers (45.7 × 25.4 mm)", 210, 297, 4, 10, 45.7m, 25.4m, 21.5m, 9.7m, 2.6m),
        new LabelSheet("a4-24", "A4 sheet, 24 stickers (63.5 × 33.9 mm)", 210, 297, 3, 8, 63.5m, 33.9m, 12.9m, 7.25m, 2.5m),
        new LabelSheet("a4-21", "A4 sheet, 21 stickers (63.5 × 38.1 mm)", 210, 297, 3, 7, 63.5m, 38.1m, 15.15m, 7.25m, 2.5m),
        new LabelSheet("a4-14", "A4 sheet, 14 stickers (99.1 × 38.1 mm)", 210, 297, 2, 7, 99.1m, 38.1m, 15.15m, 4.65m, 2.5m),
        new LabelSheet("roll-50x25", "Label printer, 50 × 25 mm", 50, 25, 1, 1, 50, 25),
        new LabelSheet("roll-38x25", "Label printer, 38 × 25 mm", 38, 25, 1, 1, 38, 25),
        new LabelSheet("roll-2x38x25", "Label printer, 2 across, 38 × 25 mm", 80, 25, 2, 1, 38, 25, 0, 1, 2),
    };

    public static LabelSheet Default => All[0];

    /// <summary>The counter book: A4 pages of 18 cards (3 across, 6 down), each with a photo, the name, the price and
    /// a big barcode to scan from the page.</summary>
    public static LabelSheet CounterBook { get; } = new("book", "Counter book, 18 a page", 210, 297, 3, 6, 64, 44, 10.5m, 6, 3, 3);

    public static LabelSheet Find(string? id) => All.FirstOrDefault(s => s.Id == id) ?? Default;

    /// <summary>The top-left corner of sticker <paramref name="index"/> (0 = top left, then along the row).</summary>
    public (decimal X, decimal Y) Position(int index)
    {
        if (index < 0 || index >= PerPage)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return (LeftMm + index % Across * (LabelWidthMm + GapAcrossMm), TopMm + index / Across * (LabelHeightMm + GapDownMm));
    }

    /// <summary>
    /// The stickers page by page. On a part-used sheet, printing starts at sticker <paramref name="startAt"/>
    /// (1 = top left); the places before it stay empty.
    /// </summary>
    public IReadOnlyList<IReadOnlyList<T?>> Pages<T>(IEnumerable<T> stickers, int startAt = 1)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(stickers);
        var skip = IsRoll ? 0 : Math.Clamp(startAt, 1, PerPage) - 1;
        return Enumerable.Repeat<T?>(null, skip)
            .Concat(stickers)
            .Chunk(PerPage)
            .Where(page => page.Any(sticker => sticker is not null))
            .Select(page => (IReadOnlyList<T?>)page)
            .ToList();
    }
}

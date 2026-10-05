namespace SmartRetail.Pos.Core.Paging;

/// <summary>
/// Which page of a long list is shown: the page asked for, kept inside the list, and what the pager draws (the numbers to
/// link, which rows are on the page). Pure, so every list pages the same way.
/// </summary>
public sealed class PageWindow
{
    /// <summary>The page sizes a person may choose.</summary>
    public static readonly IReadOnlyList<int> Sizes = [10, 25, 50, 100];

    private PageWindow(int page, int size, int total)
    {
        Size = size;
        Total = total;
        Page = Math.Clamp(page, 1, Pages);
    }

    public int Size { get; }

    public int Total { get; }

    public int Pages => Total <= 0 ? 1 : (Total + Size - 1) / Size;

    /// <summary>The page shown, from 1.</summary>
    public int Page { get; }

    /// <summary>How many rows come before this page.</summary>
    public int Skip => (Page - 1) * Size;

    /// <summary>The number of the first row on the page, from 1; 0 when the list is empty.</summary>
    public int First => Total <= 0 ? 0 : Skip + 1;

    /// <summary>The number of the last row on the page.</summary>
    public int Last => Math.Min(Total, Skip + Size);

    public bool HasPrevious => Page > 1;

    public bool HasNext => Page < Pages;

    /// <summary>The page asked for (a missing or wrong one is the first), in a list of <paramref name="total"/> rows.</summary>
    public static PageWindow Of(int? page, int size, int total) => new(page ?? 1, Math.Max(1, size), Math.Max(0, total));

    /// <summary>A number from an address, or null when it is not plain digits (a mistyped address must never stop the page).</summary>
    public static int? Parse(string? text) =>
        int.TryParse(text, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out var number) ? number : null;

    /// <summary>A page size asked for, when it is one a person may choose; else <paramref name="fallback"/>.</summary>
    public static int SizeOrDefault(int? asked, int fallback) => asked is { } size && Sizes.Contains(size) ? size : fallback;

    /// <summary>
    /// The page numbers to link: the first, the last and the ones beside this page. A gap of one page shows that page; a longer
    /// gap is null, which stands for "…".
    /// </summary>
    public IReadOnlyList<int?> Numbers()
    {
        var shown = new SortedSet<int> { 1, Pages };
        for (var number = Page - 1; number <= Page + 1; number++)
        {
            if (number >= 1 && number <= Pages)
            {
                shown.Add(number);
            }
        }

        var numbers = new List<int?>();
        var before = 0;
        foreach (var number in shown)
        {
            if (number - before == 2)
            {
                numbers.Add(before + 1);
            }
            else if (number - before > 2)
            {
                numbers.Add(null);
            }

            numbers.Add(number);
            before = number;
        }

        return numbers;
    }
}

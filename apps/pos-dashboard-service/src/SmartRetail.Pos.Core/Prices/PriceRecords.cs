using System.Globalization;
using System.Text.RegularExpressions;

namespace SmartRetail.Pos.Core.Prices;

/// <summary>What the owner said about a page found by the price check.</summary>
public enum LinkStatus
{
    /// <summary>Found, and not looked at yet: it is not compared with the shop's price.</summary>
    New,

    /// <summary>The owner confirmed that the page shows this product, in this pack: its price is compared.</summary>
    Confirmed,

    /// <summary>The owner said it is another product: it never comes back.</summary>
    Rejected,
}

/// <summary>A price a page showed on a day.</summary>
public sealed class PricePoint
{
    public DateTime Seen { get; set; }

    public decimal Price { get; set; }
}

/// <summary>A page of an online shop that may show the product, with the price it showed when last read.</summary>
public sealed class PriceLink
{
    public const int MaxHistory = 8;

    public string Url { get; set; } = "";

    public string Shop { get; set; } = "";

    public string Title { get; set; } = "";

    public string Pack { get; set; } = "";

    public LinkStatus Status { get; set; }

    /// <summary>The AI thought the page shows this product in this pack: only a hint, the owner decides.</summary>
    public bool LooksSame { get; set; }

    /// <summary>What one pack cost on the page when it was last read, in rupees.</summary>
    public decimal Price { get; set; }

    public DateTime Seen { get; set; }

    public bool InStock { get; set; } = true;

    /// <summary>The prices read, oldest first, at most <see cref="MaxHistory"/>.</summary>
    public List<PricePoint> History { get; set; } = new();
}

/// <summary>A product whose online prices are followed.</summary>
public sealed class WatchedProduct
{
    public int ProductId { get; set; }

    /// <summary>The product's name when it was last checked.</summary>
    public string Name { get; set; } = "";

    public DateTime? Checked { get; set; }

    /// <summary>What the AI said about the last check, e.g. a site with nothing; may be empty.</summary>
    public string Note { get; set; } = "";

    public List<PriceLink> Links { get; set; } = new();
}

/// <summary>Everything in pricecheck.json.</summary>
public sealed class PriceBook
{
    public List<WatchedProduct> Products { get; set; } = new();
}

/// <summary>A price found on a page, as a check reports it.</summary>
public sealed record PriceFound(string Url, string Shop, string Title, string Pack, decimal Price, bool LooksSame, bool InStock);

/// <summary>How a check's findings join what is known about a product. Pure and tested.</summary>
public static class PriceLinks
{
    /// <summary>The most pages kept for one product: the oldest not yet looked at go first, then the oldest rejected ones.</summary>
    public const int MaxLinks = 30;

    /// <summary>A price read again within this many hours of the last reading, and the same, is not kept as another point.</summary>
    public const int SamePointHours = 20;

    /// <summary>
    /// Adds what a check found: a new page waits for the owner (<see cref="LinkStatus.New"/>); a page known already gets its
    /// new price, stock and words and a point in its history; a rejected page is left alone. A confirmed page that now shows
    /// another pack (its numbers changed: 1 L, then 2 L) is no longer this product until the owner confirms it again, so a
    /// shop changing what an address sells never keeps a price in the comparison unnoticed.
    /// </summary>
    /// <returns>Pages added, known pages read again, and confirmed pages that wait for the owner again.</returns>
    public static (int Added, int Updated, int Reopened) Merge(WatchedProduct product, IEnumerable<PriceFound> found, DateTime now)
    {
        ArgumentNullException.ThrowIfNull(product);
        ArgumentNullException.ThrowIfNull(found);
        var added = 0;
        var updated = 0;
        var reopened = 0;
        foreach (var price in found)
        {
            var link = product.Links.FirstOrDefault(l => l.Url == price.Url);
            if (link is null)
            {
                link = new PriceLink { Url = price.Url, Shop = price.Shop, Status = LinkStatus.New, LooksSame = price.LooksSame };
                product.Links.Add(link);
                added++;
            }
            else if (link.Status == LinkStatus.Rejected)
            {
                continue;
            }
            else
            {
                updated++;
                if (link.Status == LinkStatus.Confirmed && PackChanged(link.Pack, price.Pack))
                {
                    link.Status = LinkStatus.New;
                    reopened++;
                }
            }

            link.Shop = price.Shop;
            link.Title = price.Title;
            link.Pack = price.Pack;
            link.InStock = price.InStock;
            if (link.Status == LinkStatus.New)
            {
                link.LooksSame = price.LooksSame;
            }

            var last = link.History.LastOrDefault();
            if (last is null || last.Price != price.Price || (now - last.Seen).TotalHours >= SamePointHours)
            {
                link.History.Add(new PricePoint { Seen = now, Price = price.Price });
                if (link.History.Count > PriceLink.MaxHistory)
                {
                    link.History.RemoveRange(0, link.History.Count - PriceLink.MaxHistory);
                }
            }

            link.Price = price.Price;
            link.Seen = now;
        }

        Trim(product);
        return (added, updated, reopened);
    }

    /// <summary>True when both packs name numbers and they are not the same numbers in the same order ("1 L" and "1 Litre" are
    /// the same, "1 L" and "2 L" are not); a pack without a number cannot be compared.</summary>
    public static bool PackChanged(string before, string after)
    {
        var was = Numbers(before);
        var now = Numbers(after);
        return was.Count > 0 && now.Count > 0 && !was.SequenceEqual(now);
    }

    private static List<string> Numbers(string pack) => Regex.Matches(pack ?? "", @"\d+(?:\.\d+)?")
        .Select(match => decimal.TryParse(match.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var number)
            ? number.ToString("0.############", CultureInfo.InvariantCulture)
            : match.Value)
        .ToList();

    private static void Trim(WatchedProduct product)
    {
        while (product.Links.Count > MaxLinks)
        {
            var drop = product.Links.Where(l => l.Status == LinkStatus.New).OrderBy(l => l.Seen).FirstOrDefault()
                ?? product.Links.Where(l => l.Status == LinkStatus.Rejected).OrderBy(l => l.Seen).FirstOrDefault();
            if (drop is null)
            {
                return;
            }

            product.Links.Remove(drop);
        }
    }
}

using SmartRetail.Pos.Core.Prices;

namespace SmartRetail.Pos.Tests;

/// <summary>What a price check finds joins what the owner has confirmed, and the shop's price is set against it.</summary>
public class PriceCheckTests
{
    private static readonly DateTime Now = new(2026, 9, 29, 16, 0, 0);

    private static PriceFound Found(string url, decimal price, string shop = "Amazon.in", bool same = true, string title = "Sunflower Oil 1 L", string pack = "1 L", bool inStock = true)
        => new(url, shop, title, pack, price, same, inStock);

    [Fact]
    public void A_page_found_for_the_first_time_waits_for_the_owner_and_keeps_its_first_price()
    {
        var product = new WatchedProduct { ProductId = 6 };

        var (added, updated, _) = PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 189m), Found("https://www.flipkart.com/oil/p/itm1", 172m, "Flipkart", same: false) }, Now);

        Assert.Equal((2, 0), (added, updated));
        var amazon = product.Links[0];
        Assert.Equal((LinkStatus.New, true, 189m, Now, "Amazon.in"), (amazon.Status, amazon.LooksSame, amazon.Price, amazon.Seen, amazon.Shop));
        Assert.Equal(new[] { (Now, 189m) }, amazon.History.Select(p => (p.Seen, p.Price)));
        Assert.False(product.Links[1].LooksSame);
    }

    [Fact]
    public void A_confirmed_page_that_shows_another_pack_now_waits_for_the_owner_again()
    {
        var product = new WatchedProduct { ProductId = 6 };
        PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 189m), Found("https://www.amazon.in/dp/B2", 150m) }, Now);
        product.Links[0].Status = LinkStatus.Confirmed;
        product.Links[1].Status = LinkStatus.Confirmed;

        // B1 is now a 2 L pack; B2 only says "Litre" in words.
        var (added, updated, reopened) = PriceLinks.Merge(product, new[]
        {
            Found("https://www.amazon.in/dp/B1", 350m, pack: "2 L", same: false),
            Found("https://www.amazon.in/dp/B2", 149m, pack: "1 Litre"),
        }, Now.AddDays(1));

        Assert.Equal((0, 2, 1), (added, updated, reopened));
        Assert.Equal((LinkStatus.New, false, 350m), (product.Links[0].Status, product.Links[0].LooksSame, product.Links[0].Price));
        Assert.Equal((LinkStatus.Confirmed, 149m), (product.Links[1].Status, product.Links[1].Price));

        // Compared with the shop's price, only the page that is still confirmed counts.
        var confirmed = product.Links.Where(l => l.Status == LinkStatus.Confirmed).Select(l => new OnlinePrice(l.Shop, l.Price, l.Seen)).ToList();
        Assert.Equal(149m, PriceCompare.Compare(155m, null, confirmed, Now.AddDays(1)).Lowest!.Price);
    }

    [Theory]
    [InlineData("1 L", "1 Litre", false)]
    [InlineData("1 L", "1L", false)]
    [InlineData("1.0 L", "1 L", false)]
    [InlineData("1 L", "2 L", true)]
    [InlineData("500 ml", "1 L", true)]
    [InlineData("Pack of 2 (1 L each)", "Pack of 2 (1 L each)", false)]
    [InlineData("Pack of 2 (1 L each)", "Pack of 3 (1 L each)", true)]
    [InlineData("Pack of 2", "2 x 1 L", true)]
    [InlineData("", "2 L", false)]
    [InlineData("1 L", "", false)]
    [InlineData("large", "small", false)]
    [InlineData("99999999999999999999999999999999 L", "1 L", true)]
    public void A_pack_has_changed_when_its_numbers_do(string before, string after, bool changed) =>
        Assert.Equal(changed, PriceLinks.PackChanged(before, after));

    [Fact]
    public void A_page_read_again_gets_its_new_price_and_a_point_when_it_changed_or_a_day_passed()
    {
        var product = new WatchedProduct { ProductId = 6 };
        PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 189m) }, Now);
        product.Links[0].Status = LinkStatus.Confirmed;

        // The same price an hour later: seen again, no new point.
        var (added, updated, _) = PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 189m, inStock: false, title: "Sunflower Oil 1 Litre") }, Now.AddHours(1));
        Assert.Equal((0, 1), (added, updated));
        var link = product.Links.Single();
        Assert.Equal((Now.AddHours(1), false, "Sunflower Oil 1 Litre"), (link.Seen, link.InStock, link.Title));
        Assert.Single(link.History);

        // Another price: a point. The same price a day later: a point too.
        PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 179m) }, Now.AddHours(2));
        PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 179m) }, Now.AddHours(30));
        Assert.Equal(new[] { 189m, 179m, 179m }, link.History.Select(p => p.Price));
        Assert.Equal((179m, LinkStatus.Confirmed), (link.Price, link.Status));
    }

    [Fact]
    public void A_rejected_page_stays_rejected_and_a_confirmed_one_keeps_what_the_owner_decided()
    {
        var product = new WatchedProduct { ProductId = 6 };
        PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 189m), Found("https://www.amazon.in/dp/B2", 150m, same: false) }, Now);
        product.Links[0].Status = LinkStatus.Rejected;
        product.Links[1].Status = LinkStatus.Confirmed;

        var (added, updated, _) = PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 99m), Found("https://www.amazon.in/dp/B2", 140m, same: true) }, Now.AddDays(1));

        Assert.Equal((0, 1), (added, updated));
        Assert.Equal((LinkStatus.Rejected, 189m), (product.Links[0].Status, product.Links[0].Price));
        Assert.Equal((LinkStatus.Confirmed, false, 140m), (product.Links[1].Status, product.Links[1].LooksSame, product.Links[1].Price));
    }

    [Fact]
    public void A_history_keeps_only_the_last_eight_points()
    {
        var product = new WatchedProduct { ProductId = 6 };
        for (var day = 0; day < 12; day++)
        {
            PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B1", 100 + day) }, Now.AddDays(day));
        }

        var history = product.Links.Single().History;
        Assert.Equal(PriceLink.MaxHistory, history.Count);
        Assert.Equal(104m, history[0].Price);
        Assert.Equal(111m, history[^1].Price);
    }

    [Fact]
    public void Too_many_pages_drop_the_oldest_not_looked_at_then_the_oldest_rejected_and_never_a_confirmed_one()
    {
        var product = new WatchedProduct { ProductId = 6 };
        for (var i = 0; i < PriceLinks.MaxLinks; i++)
        {
            PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/B" + i, 100 + i) }, Now.AddMinutes(i));
        }

        product.Links[0].Status = LinkStatus.Confirmed;
        product.Links[1].Status = LinkStatus.Rejected;
        PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/NEW", 50m) }, Now.AddHours(1));

        Assert.Equal(PriceLinks.MaxLinks, product.Links.Count);
        Assert.Contains(product.Links, l => l.Url.EndsWith("/B0"));
        Assert.Contains(product.Links, l => l.Url.EndsWith("/B1"));
        Assert.DoesNotContain(product.Links, l => l.Url.EndsWith("/B2"));
        Assert.Contains(product.Links, l => l.Url.EndsWith("/NEW"));

        // Nothing but confirmed pages: a page found next is the one not kept (it is found again at the next check).
        foreach (var link in product.Links)
        {
            link.Status = LinkStatus.Confirmed;
        }

        PriceLinks.Merge(product, new[] { Found("https://www.amazon.in/dp/MORE", 50m) }, Now.AddHours(2));
        Assert.DoesNotContain(product.Links, l => l.Url.EndsWith("/MORE"));
        Assert.All(product.Links, l => Assert.Equal(LinkStatus.Confirmed, l.Status));

        // A file with too many pages (edited by hand): the rejected go first, whatever the check finds.
        product.Links.Add(new PriceLink { Url = "https://www.amazon.in/dp/OLD1", Status = LinkStatus.Rejected, Seen = Now.AddDays(-2) });
        product.Links.Add(new PriceLink { Url = "https://www.amazon.in/dp/OLD2", Status = LinkStatus.Rejected, Seen = Now.AddDays(-1) });
        PriceLinks.Merge(product, Array.Empty<PriceFound>(), Now.AddHours(3));
        Assert.Equal(PriceLinks.MaxLinks, product.Links.Count);
        Assert.DoesNotContain(product.Links, l => l.Status == LinkStatus.Rejected);
    }

    [Theory]
    [InlineData(100, 5, 105)]
    [InlineData(47.6, 12, 54)]
    [InlineData(100, 0, 100)]
    public void The_lowest_safe_price_is_the_purchase_price_plus_GST_in_whole_rupees_rounded_up(double cost, double gst, double expected) =>
        Assert.Equal((decimal)expected, PriceCompare.Floor((decimal)cost, (decimal)gst));

    [Fact]
    public void Without_a_purchase_price_there_is_no_floor() => Assert.Null(PriceCompare.Floor(0m, 5m));

    private static OnlinePrice Online(string shop, decimal price, int daysAgo = 1) => new(shop, price, Now.AddDays(-daysAgo));

    [Fact]
    public void There_is_nothing_to_compare_without_the_shops_price_or_a_confirmed_page()
    {
        Assert.Equal(PriceVerdict.NoData, PriceCompare.Compare(0m, 90m, new[] { Online("Flipkart", 100m) }, Now).Verdict);
        var none = PriceCompare.Compare(155m, 90m, Array.Empty<OnlinePrice>(), Now);
        Assert.Equal(PriceVerdict.NoData, none.Verdict);
        Assert.Equal("Say which of the pages show exactly this product, in this pack, and your price is compared with theirs.", none.Text);
    }

    [Fact]
    public void A_dearer_price_says_by_how_much_and_whether_matching_it_keeps_the_shop_above_cost()
    {
        var pages = new[] { Online("Amazon.in", 160m), Online("Flipkart", 140m), Online("JioMart", 150m) };

        var safe = PriceCompare.Compare(155m, 105m, pages, Now);

        Assert.Equal((PriceVerdict.Dearer, "Flipkart", 15m, false), (safe.Verdict, safe.Lowest!.Shop, safe.Difference, safe.BelowFloor));
        Assert.Equal("Your price ₹155 is ₹15 (11%) above the lowest confirmed online price: ₹140 at Flipkart, seen 28 Sept. Matching it would still keep you above your purchase price plus GST (₹105).", safe.Text);

        var unsafeToMatch = PriceCompare.Compare(155m, 145m, pages, Now);
        Assert.True(unsafeToMatch.BelowFloor);
        Assert.EndsWith("Matching it would go below your purchase price plus GST (₹145).", unsafeToMatch.Text);

        var unknown = PriceCompare.Compare(155m, null, pages, Now);
        Assert.EndsWith("The POS has no purchase price for it, so whether matching it is safe cannot be checked.", unknown.Text);
    }

    [Fact]
    public void A_cheaper_price_and_about_the_same_are_told_plainly()
    {
        var cheaper = PriceCompare.Compare(130m, 90m, new[] { Online("Amazon.in", 150m, 0) }, Now);
        Assert.Equal((PriceVerdict.Cheaper, -20m), (cheaper.Verdict, cheaper.Difference));
        Assert.Equal("Your price ₹130 is ₹20 (13%) below the lowest confirmed online price: ₹150 at Amazon.in, seen 29 Sept.", cheaper.Text);

        var about = PriceCompare.Compare(152m, 90m, new[] { Online("Amazon.in", 150m) }, Now);
        Assert.Equal(PriceVerdict.About, about.Verdict);
        Assert.Equal("Your price ₹152 is about the same as the lowest confirmed online price: ₹150 at Amazon.in, seen 28 Sept.", about.Text);
    }

    [Fact]
    public void The_lowest_of_equal_prices_is_the_newest_and_an_old_price_says_to_check_again()
    {
        var newest = PriceCompare.Compare(155m, null, new[] { Online("Amazon.in", 140m, 3), Online("Flipkart", 140m, 1) }, Now);
        Assert.Equal("Flipkart", newest.Lowest!.Shop);

        var old = PriceCompare.Compare(155m, null, new[] { Online("Amazon.in", 140m, 8) }, Now);
        Assert.EndsWith("That price is more than a week old: check again.", old.Text);
        Assert.True(PriceCompare.IsOld(Now.AddDays(-7), Now));
        Assert.False(PriceCompare.IsOld(Now.AddDays(-6), Now));
    }
}

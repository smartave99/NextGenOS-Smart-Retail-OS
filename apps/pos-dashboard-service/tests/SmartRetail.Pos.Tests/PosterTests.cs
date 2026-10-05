using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Posters;

namespace SmartRetail.Pos.Tests;

public class PosterPricingTests
{
    [Theory]
    [InlineData(55, 5, true, 55)]
    [InlineData(100, 18, false, 118)]
    [InlineData(84.32, 18, false, 99.5)]
    [InlineData(0, 5, true, 0)]
    public void The_poster_price_is_what_the_customer_pays(decimal selling, decimal gst, bool includesTax, decimal expected) =>
        Assert.Equal(expected, PosterPricing.CustomerPrice(selling, gst, includesTax));

    [Fact]
    public void An_offer_never_goes_below_the_purchase_price_plus_gst()
    {
        // Bought at ₹40 before 5% GST: ₹42 is the least the shop can take.
        var lowest = PosterPricing.LowestOffer(price: 55m, costPrice: 40m, gstRatePercent: 5m, maxOfferPercent: 30m);

        Assert.Equal(42m, lowest);
        Assert.Equal(42m, PosterPricing.OfferPrice(55m, lowest, 30m));
        Assert.Equal(42m, PosterPricing.OfferPrice(55m, lowest, 90m));
    }

    [Fact]
    public void An_offer_never_takes_off_more_than_the_limit()
    {
        // Plenty of margin, so the 30% limit decides: 70% of ₹175 is ₹122.50, rounded up to ₹123.
        var lowest = PosterPricing.LowestOffer(175m, 50m, 5m, 30m);

        Assert.Equal(123m, lowest);
        Assert.Equal(29m, PosterPricing.PercentOff(175m, lowest));
        Assert.Equal(123m, PosterPricing.OfferPrice(175m, lowest, 40m));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Without_a_purchase_price_there_is_no_offer(decimal cost)
    {
        var lowest = PosterPricing.LowestOffer(99m, cost, 18m, 30m);

        Assert.Equal(99m, lowest);
        Assert.Null(PosterPricing.OfferPrice(99m, lowest, 20m));
        Assert.Empty(PosterPricing.OfferChoices(99m, lowest));
    }

    [Fact]
    public void Selling_at_or_below_cost_already_allows_no_offer()
    {
        Assert.Equal(50m, PosterPricing.LowestOffer(50m, 48m, 5m, 30m));
        Assert.Equal(50m, PosterPricing.LowestOffer(50m, 60m, 0m, 30m));
    }

    [Fact]
    public void Offer_prices_are_whole_rupees_rounded_up()
    {
        // 15% off ₹55 is ₹46.75: ₹47, which is 14% off.
        var offer = PosterPricing.OfferPrice(55m, 30m, 15m);

        Assert.Equal(47m, offer);
        Assert.Equal(14m, PosterPricing.PercentOff(55m, offer!.Value));
    }

    [Fact]
    public void An_offer_too_small_to_change_the_price_is_no_offer()
    {
        Assert.Null(PosterPricing.OfferPrice(10m, 5m, 5m));
        Assert.Null(PosterPricing.OfferPrice(55m, 30m, 0m));
    }

    [Fact]
    public void Staff_choose_from_steps_up_to_the_lowest_allowed()
    {
        var lowest = PosterPricing.LowestOffer(55m, 40m, 5m, 30m);

        // 5% → ₹53, 10% → ₹50, 15% → ₹47, 20% → ₹44, then the lowest allowed, ₹42 (23% off).
        Assert.Equal(new[] { 53m, 50m, 47m, 44m, 42m }, PosterPricing.OfferChoices(55m, lowest));

        // The offer on the poster is always among them, when it keeps to the rules.
        Assert.Equal(new[] { 53m, 50m, 48m, 47m, 44m, 42m }, PosterPricing.OfferChoices(55m, lowest, current: 48m));
        Assert.Equal(new[] { 53m, 50m, 47m, 44m, 42m }, PosterPricing.OfferChoices(55m, lowest, current: 41m));
    }

    [Theory]
    [InlineData(47, 47)]
    [InlineData(41, null)]
    [InlineData(55, null)]
    [InlineData(46.5, null)]
    public void A_chosen_offer_is_checked_against_the_rules(decimal chosen, int? expected) =>
        Assert.Equal(expected, (int?)PosterPricing.CheckedOffer(55m, 42m, chosen));
}

public class PosterWordsTests
{
    private static readonly PosterWords Fallback = PosterKind.Clearance.DefaultWords();

    [Fact]
    public void An_ais_words_are_used_when_they_follow_the_rules()
    {
        var words = PosterWords.FromAi("  Big Clearance\nSale ", "बड़ी बचत, सीमित स्टॉक", "\"Grab a bargain today\"", Fallback);

        Assert.Equal(new PosterWords("Big Clearance Sale", "बड़ी बचत, सीमित स्टॉक", "Grab a bargain today"), words);
    }

    [Theory]
    [InlineData("50% off everything")]
    [InlineData("Everything under ₹99")]
    [InlineData("Save Rs 20")]
    [InlineData("भारी छूट")]
    [InlineData("")]
    public void A_headline_with_figures_or_in_hindi_is_replaced(string headline) =>
        Assert.Equal(Fallback.Headline, PosterWords.FromAi(headline, "भारी छूट", "While stock lasts", Fallback).Headline);

    [Theory]
    [InlineData("Big discount")]
    [InlineData("२०% छूट")]
    [InlineData("20% छूट")]
    public void A_hindi_line_must_be_hindi_without_figures(string hindi) =>
        Assert.Equal(Fallback.HindiLine, PosterWords.FromAi("Sale", hindi, "While stock lasts", Fallback).HindiLine);

    [Fact]
    public void Long_lines_are_cut_at_a_word()
    {
        var headline = PosterWords.Tidy("The biggest clearance sale of the whole year", PosterWords.MaxHeadlineLength);

        Assert.Equal("The biggest clearance sale", headline);
    }

    [Fact]
    public void Festival_posters_name_the_festival()
    {
        Assert.Equal("Diwali offer", PosterKind.FestivalOffer.DefaultWords(" Diwali ").Headline);
        Assert.Equal("Festive offer", PosterKind.FestivalOffer.DefaultWords(null).Headline);
    }

    [Fact]
    public void Each_kind_has_its_own_artwork_theme()
    {
        var themes = PosterKinds.All.Select(kind => kind.ArtworkTheme()).ToList();

        Assert.Equal(themes.Count, themes.Distinct().Count());
        Assert.Contains("Holi", PosterKind.FestivalOffer.ArtworkTheme(" Holi\n"));
        Assert.Contains("diyas", PosterKind.FestivalOffer.ArtworkTheme());
    }

    [Fact]
    public void Kinds_round_trip_through_their_slugs()
    {
        foreach (var kind in PosterKinds.All)
        {
            Assert.True(PosterKinds.TryParse(kind.Slug(), out var parsed));
            Assert.Equal(kind, parsed);
        }

        Assert.False(PosterKinds.TryParse("posters", out _));
    }
}

public class PosterTests
{
    [Fact]
    public void The_badge_shows_the_biggest_offer_and_the_foot_says_how_long()
    {
        var poster = new Poster
        {
            Items = new[]
            {
                new PosterItem { Name = "Bhujia 200 g", Price = 55m, OfferPrice = 49m },
                new PosterItem { Name = "Shampoo 180 ml", Price = 160m, OfferPrice = 139m },
                new PosterItem { Name = "Tea 250 g", Price = 140m },
            },
            ValidFrom = new DateOnly(2026, 9, 26),
            ValidTill = new DateOnly(2026, 9, 30),
        };

        Assert.Equal(13m, poster.UpToPercentOff);
        Assert.Equal("Offers valid 26–30 September, while stock lasts", poster.ValidityText);
    }

    [Fact]
    public void A_poster_without_offers_gives_its_prices_dates()
    {
        var poster = new Poster
        {
            Items = new[] { new PosterItem { Name = "Tea 250 g", Price = 140m, OfferPrice = 140m } },
            ValidFrom = new DateOnly(2026, 9, 28),
            ValidTill = new DateOnly(2026, 10, 4),
        };

        Assert.False(poster.HasOffers);
        Assert.Null(poster.UpToPercentOff);
        Assert.Equal("Prices valid 28 September – 4 October", poster.ValidityText);
    }
}

public class PosterPickerTests
{
    private static readonly DateOnly Today = new(2026, 9, 26);

    private static ProductFacts Product(int id, string name, decimal price = 100m, decimal cost = 60m, decimal stock = 10m,
        int addedDaysAgo = 400, bool active = true) => new()
    {
        Id = id,
        Code = (1000 + id).ToString(System.Globalization.CultureInfo.InvariantCulture),
        Name = name,
        Category = "Test",
        SellingPrice = price,
        CostPrice = cost,
        GstRatePercent = 5m,
        StockInHand = stock,
        Active = active,
        AddedOn = Today.AddDays(-addedDaysAgo),
    };

    private static ProductDaySales Sold(int id, int daysAgo, decimal qty, decimal sales) =>
        new() { ProductId = id, Day = Today.AddDays(-daysAgo), Qty = qty, Sales = sales };

    private static PosterInputs Inputs(IReadOnlyList<ProductFacts> products, IReadOnlyList<ProductDaySales> sales, params int[] withPhotos) =>
        new(Today, products, sales, withPhotos.ToDictionary(id => id, id => $"white-{id}.png"));

    [Fact]
    public void Clearance_offers_what_stopped_selling_photos_first_then_the_most_money_tied_up()
    {
        var products = new[]
        {
            Product(1, "Sells every day"),
            Product(2, "Slow, small stock", stock: 2),
            Product(3, "Slow, big stock", stock: 50),
            Product(4, "Never sold, with photo", stock: 1),
            Product(5, "Slow, no stock", stock: 0),
            Product(6, "Slow, switched off", active: false),
            Product(7, "Just added", addedDaysAgo: 5),
        };
        var sales = new[] { Sold(1, 0, 3, 300), Sold(2, 45, 1, 100), Sold(3, 60, 1, 100) };

        var candidates = PosterPicker.Candidates(PosterKind.Clearance, Inputs(products, sales, 4));

        Assert.Equal(new[] { 4, 3, 2 }, candidates.Select(c => c.ProductId));
        Assert.Equal("No sale in over 120 days · 1 in stock", candidates[0].Why(PosterKind.Clearance, Today, PosterRules.Default));
        Assert.Equal("Last sold 60 days ago · 50 in stock", candidates[1].Why(PosterKind.Clearance, Today, PosterRules.Default));
    }

    [Fact]
    public void New_arrivals_are_products_added_this_month_newest_first()
    {
        var products = new[] { Product(1, "Old"), Product(2, "Added last week", addedDaysAgo: 7), Product(3, "Added yesterday", addedDaysAgo: 1), Product(4, "Added long ago", addedDaysAgo: 30) };

        var candidates = PosterPicker.Candidates(PosterKind.NewArrivals, Inputs(products, Array.Empty<ProductDaySales>()));

        Assert.Equal(new[] { 3, 2 }, candidates.Select(c => c.ProductId));
        Assert.Equal("Added yesterday · 10 in stock", candidates[0].Why(PosterKind.NewArrivals, Today, PosterRules.Default));
    }

    [Fact]
    public void Best_sellers_go_by_the_last_thirty_days_with_photos_first()
    {
        var products = new[] { Product(1, "Top"), Product(2, "Second, with photo"), Product(3, "Sold long ago"), Product(4, "Top but sold out", stock: 0) };
        var sales = new[] { Sold(1, 3, 20, 2000), Sold(1, 10, 10, 1000), Sold(2, 2, 5, 500), Sold(3, 40, 50, 5000), Sold(4, 1, 99, 9900) };

        var candidates = PosterPicker.Candidates(PosterKind.BestSellers, Inputs(products, sales, 2));

        Assert.Equal(new[] { 2, 1 }, candidates.Select(c => c.ProductId));
        Assert.Equal("30 sold in 30 days · 10 in stock", candidates[1].Why(PosterKind.BestSellers, Today, PosterRules.Default));
    }

    [Fact]
    public void Default_picks_take_the_kinds_usual_offer_within_the_rules()
    {
        // ₹100 incl. GST, bought at ₹80 + 5% GST = ₹84: 20% off would be ₹80, so the offer stops at ₹84.
        var products = new[] { Product(1, "Tight margin", price: 100m, cost: 80m), Product(2, "No cost known", cost: 0m) };

        var candidates = PosterPicker.Candidates(PosterKind.Clearance, Inputs(products, Array.Empty<ProductDaySales>()));
        var picks = PosterPicker.DefaultPicks(PosterKind.Clearance, candidates, 4);

        Assert.Equal(2, picks.Count);
        Assert.Equal((1, 84m), (picks[0].ProductId, picks[0].OfferPrice!.Value));
        Assert.Equal(16m, candidates[0].MaxOfferPercent);
        Assert.False(picks[1].HasOffer);
        Assert.Null(picks[1].OfferPrice);
    }

    [Fact]
    public void New_arrivals_and_best_sellers_keep_todays_prices()
    {
        var products = new[] { Product(1, "New", addedDaysAgo: 3) };

        var picks = PosterPicker.DefaultPicks(PosterKind.NewArrivals, PosterPicker.Candidates(PosterKind.NewArrivals, Inputs(products, Array.Empty<ProductDaySales>())), 1);

        Assert.False(Assert.Single(picks).HasOffer);
    }

    [Fact]
    public void Prices_without_gst_get_it_added()
    {
        var inputs = Inputs(new[] { Product(1, "Tax on top", price: 100m, cost: 50m) }, Array.Empty<ProductDaySales>()) with { PricesIncludeTax = false };

        var candidate = Assert.Single(PosterPicker.Candidates(PosterKind.Clearance, inputs));

        Assert.Equal(105m, candidate.Price);
    }
}

public class PosterPromptTests
{
    private static readonly DateOnly Today = new(2026, 9, 26);

    private static readonly PosterCandidate[] Candidates =
    {
        new() { ProductId = 11, Name = "Bhujia 200 g", Category = "Snacks", Price = 55m, LowestOffer = 42m, StockInHand = 35m, LastSold = Today.AddDays(-41), Photo = "white-1.png" },
        new() { ProductId = 12, Name = "Instant Coffee 50 g", Category = "Beverages", Price = 175m, LowestOffer = 140m, StockInHand = 9m },
        new() { ProductId = 13, Name = "Notebook | 172 pages", Category = "Stationery", Price = 55m, LowestOffer = 55m, StockInHand = 80m },
    };

    [Fact]
    public void The_ai_sees_the_products_with_their_limits()
    {
        var prompt = PosterPrompt.UserPrompt(PosterKind.Clearance, 2, Candidates, Today, PosterRules.Default);

        Assert.Contains("Products on the poster: 2", prompt);
        Assert.Contains("P1 | Bhujia 200 g | Snacks | 55 | 23 | 35 | 0 | 41 days ago | unknown | yes", prompt);
        Assert.Contains("P2 | Instant Coffee 50 g | Beverages | 175 | 20 | 9 | 0 | not in 120 days | unknown | no", prompt);
        Assert.Contains("P3 | Notebook / 172 pages | Stationery | 55 | 0 |", prompt);
        Assert.Contains("exactly 2,", prompt);
    }

    [Fact]
    public void The_answer_is_held_to_the_list_and_the_limits()
    {
        const string answer = """
            Here is the plan:
            ```json
            {"products": [{"ref": "P9", "offer_percent": 10}, {"ref": "P2", "offer_percent": 45}, {"ref": "P2", "offer_percent": 5}, {"ref": "p3", "offer_percent": "15%"}],
             "headline": "Clearance Bonanza", "hindi_line": "जल्दी करें, स्टॉक सीमित", "subline": "Everything at 50% off"}
            ```
            """;

        var plan = PosterPrompt.ReadAnswer(answer, PosterKind.Clearance, 3, Candidates);

        Assert.NotNull(plan);
        // P9 does not exist and P2 comes once; its 45% is held to its 20% limit (₹140). P3 cannot have an offer.
        Assert.Equal(new[] { 12, 13, 11 }, plan!.Items.Select(i => i.ProductId));
        Assert.Equal(2, plan.ChosenByAi);
        Assert.Equal(140m, plan.Items[0].OfferPrice);
        Assert.Null(plan.Items[1].OfferPrice);
        // The app added Bhujia with the clearance offer of 20%: ₹44.
        Assert.Equal(44m, plan.Items[2].OfferPrice);
        Assert.Equal(new PosterWords("Clearance Bonanza", "जल्दी करें, स्टॉक सीमित", PosterKind.Clearance.DefaultWords().Subline), plan.Words);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("I could not decide.")]
    [InlineData("{\"products\": [")]
    [InlineData("[1, 2]")]
    public void An_answer_without_readable_json_is_no_plan(string? answer) =>
        Assert.Null(PosterPrompt.ReadAnswer(answer, PosterKind.Clearance, 2, Candidates));

    [Fact]
    public void A_poster_never_asks_for_more_products_than_there_are()
    {
        var plan = PosterPrompt.ReadAnswer("{\"products\": []}", PosterKind.BestSellers, 6, Candidates);

        Assert.Equal(3, plan!.Items.Count);
        Assert.Equal(0, plan.ChosenByAi);
        Assert.All(plan.Items, item => Assert.False(item.HasOffer));
        Assert.Equal(PosterKind.BestSellers.DefaultWords(), plan.Words);
    }
}

public class PosterRecheckTests
{
    // ₹55, allowed down to ₹42, on offer at ₹47.
    private static readonly PosterItem Notebook = new() { ProductId = 23, Name = "Notebook 172 pages", Price = 55m, LowestOffer = 42m, OfferPrice = 47m };

    [Fact]
    public void An_unchanged_product_takes_todays_lowest_offer_quietly()
    {
        var (item, change) = PosterRecheck.Check(Notebook, priceNow: 55m, lowestNow: 45m);

        Assert.Null(change);
        Assert.Equal(Notebook with { LowestOffer = 45m }, item);
    }

    [Fact]
    public void A_new_price_is_a_change()
    {
        var (item, change) = PosterRecheck.Check(Notebook, priceNow: 60m, lowestNow: 46m);

        Assert.Equal(Notebook, item);
        Assert.Equal(new PosterChange(23, "Notebook 172 pages", PosterChangeKind.Price, 55m, 60m, 46m), change);
    }

    [Fact]
    public void An_offer_below_what_is_allowed_now_is_a_change()
    {
        // The purchase price went up, or the owner lowered the limit: ₹47 is now below the lowest allowed, ₹50.
        var (item, change) = PosterRecheck.Check(Notebook, priceNow: 55m, lowestNow: 50m);

        Assert.Equal(Notebook, item);
        Assert.Equal(new PosterChange(23, "Notebook 172 pages", PosterChangeKind.OfferRules, 47m, 55m, 50m), change);
    }

    [Fact]
    public void A_product_gone_from_the_pos_is_a_change()
    {
        var (_, change) = PosterRecheck.Check(Notebook, priceNow: null, lowestNow: 42m);

        Assert.Equal(PosterChangeKind.Gone, change!.Kind);
    }

    [Fact]
    public void Todays_prices_keep_the_offer_within_todays_rules()
    {
        // 14% off at ₹60 would be ₹52 (rounded up); today's rules allow no lower than ₹50.
        Assert.Equal(52m, PosterRecheck.Refresh(Notebook, priceNow: 60m, lowestNow: 50m).OfferPrice);
        // An offer that is no longer allowed comes up to the lowest allowed.
        Assert.Equal(50m, PosterRecheck.Refresh(Notebook with { OfferPrice = 40m }, priceNow: 55m, lowestNow: 50m).OfferPrice);
        Assert.Null(PosterRecheck.Refresh(Notebook with { OfferPrice = null }, priceNow: 60m, lowestNow: 50m).OfferPrice);
    }
}

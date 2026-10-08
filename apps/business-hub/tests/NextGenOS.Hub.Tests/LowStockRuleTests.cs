using NextGenOS.Hub.Insights;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The low-stock rule as arithmetic (blueprint INS-011): every case is worked by hand beside it. Quantities are in thousandths (12 kg is 12,000), a delivery time is in days. The rule
/// says an item is running low when what is on the shelf lasts fewer days than the supplier's delivery time plus the spare days, at the pace the item has really sold at lately.
/// </summary>
public class LowStockRuleTests
{
    private static readonly DateTimeOffset Now = new(2026, 10, 5, 6, 30, 0, TimeSpan.Zero);
    private static readonly LowStockSettings Defaults = new();   // 28 days looked at, 7 days of order beyond delivery, 7 days of history needed

    private static SupplyTerms Terms(int lead = 5, int safety = 2, long pack = 1_000, long min = 0, long item = 1) => new(item, 9, lead, safety, pack, min, 1, Now.AddDays(-3));

    private static StockInput Item(long onHand, long sold, int history = 28, long open = 0, SupplyTerms? terms = null, long id = 1, string name = "Rice", bool noTerms = false) =>
        new(id, name, "kg", onHand, sold, history, open, noTerms ? null : terms ?? Terms(item: id), noTerms ? null : "National Foods", [101, 102], open > 0 ? [201] : []);

    // ---- the test: does what is here last as long as the supplier needs? ------------------------------------------------------------------

    [Fact]
    public void Twelve_kilos_that_sell_three_a_day_last_four_days_and_the_supplier_needs_seven_so_thirty_kilos_are_proposed()
    {
        // 84 kg sold in 28 days is 3 kg a day. 12 kg lasts 12 / 3 = 4 days. Delivery 5 + spare 2 = 7 days needed.
        // An order should cover 7 + 7 review = 14 days = 42 kg; 12 are here; 30 are missing; they come in packs of 1 kg: 30 kg.
        var f = LowStockRule.Judge(Item(onHand: 12_000, sold: 84_000), Defaults);
        Assert.Equal(LowStockStatus.Order, f.Status);
        Assert.Equal(4.0m, f.CoverDays);
        Assert.Equal(3_000m, f.PerDayMilli);
        Assert.Equal((7, 14, 28), (f.ThresholdDays, f.TargetDays, f.EffectiveDays));
        Assert.Equal(30_000, f.ProposedMilli);
    }

    [Fact]
    public void An_item_that_lasts_exactly_as_many_days_as_are_needed_is_fine_and_one_unit_less_is_not()
    {
        // 21 kg at 3 kg a day is exactly 7 days: 21,000 × 28 = 588,000 = 84,000 × 7. Not less, so fine.
        Assert.Equal(LowStockStatus.Ok, LowStockRule.Judge(Item(21_000, 84_000), Defaults).Status);
        // One thousandth of a kilo less is 20,999 × 28 = 587,972 < 588,000: running low.
        var low = LowStockRule.Judge(Item(20_999, 84_000), Defaults);
        Assert.Equal(LowStockStatus.Order, low.Status);
        // 14 days of order = 42,000; 20,999 here; 21,001 missing; in packs of 1,000 that is 22,000.
        Assert.Equal(22_000, low.ProposedMilli);
    }

    [Fact]
    public void What_is_already_on_order_counts_and_an_order_that_covers_it_all_means_nothing_more_is_proposed()
    {
        // 12 here, 42 needed: 30 missing. 30 already ordered: nothing more, but it is still shown as running low (covered).
        var covered = LowStockRule.Judge(Item(12_000, 84_000, open: 30_000), Defaults);
        Assert.Equal((LowStockStatus.Covered, 0), (covered.Status, covered.ProposedMilli));
        // One thousandth short of that is 1 missing, which is a whole pack of 1 kg.
        var short1 = LowStockRule.Judge(Item(12_000, 84_000, open: 29_999), Defaults);
        Assert.Equal((LowStockStatus.Order, 1_000), (short1.Status, short1.ProposedMilli));
    }

    [Fact]
    public void An_order_is_rounded_up_to_the_pack_the_supplier_sends_and_is_never_less_than_the_least_they_send()
    {
        // 30 kg missing, sent in cases of 12 kg: 3 cases = 36 kg (2 cases is only 24).
        Assert.Equal(36_000, LowStockRule.Judge(Item(12_000, 84_000, terms: Terms(pack: 12_000)), Defaults).ProposedMilli);
        // Exactly 24 missing is exactly 2 cases, not 3.
        Assert.Equal(24_000, LowStockRule.Judge(Item(18_000, 84_000, terms: Terms(pack: 12_000)), Defaults).ProposedMilli);
        // The least they send is 48 kg (4 cases): the proposal is raised to it.
        Assert.Equal(48_000, LowStockRule.Judge(Item(12_000, 84_000, terms: Terms(pack: 12_000, min: 48_000)), Defaults).ProposedMilli);
        // A least that is not a whole number of cases is raised to the next whole case: 50 kg is 5 cases = 60 kg.
        Assert.Equal(60_000, LowStockRule.Judge(Item(12_000, 84_000, terms: Terms(pack: 12_000, min: 50_000)), Defaults).ProposedMilli);
    }

    [Fact]
    public void A_shorter_history_is_judged_over_the_days_it_has_and_too_short_a_history_is_not_judged_at_all()
    {
        // In stock for 14 days, 28 kg sold: 2 kg a day. 5 kg lasts 2.5 days against 7 needed: running low. Order covers 14 days = 28 kg, less 5 = 23.
        var f = LowStockRule.Judge(Item(5_000, 28_000, history: 14), Defaults);
        Assert.Equal((LowStockStatus.Order, 14, 23_000), (f.Status, f.EffectiveDays, f.ProposedMilli));
        // Only 6 days in stock, and 7 are needed to know the pace.
        Assert.Equal(LowStockStatus.ShortHistory, LowStockRule.Judge(Item(5_000, 12_000, history: 6), Defaults).Status);
        Assert.Equal(LowStockStatus.Ok, LowStockRule.Judge(Item(500_000, 12_000, history: 7), Defaults).Status);
    }

    [Fact]
    public void Nothing_sold_or_more_returned_than_sold_means_no_pace_and_so_no_warning_and_a_missing_supplier_is_never_guessed()
    {
        Assert.Equal(LowStockStatus.NoSales, LowStockRule.Judge(Item(0, 0), Defaults).Status);
        Assert.Equal(LowStockStatus.NoSales, LowStockRule.Judge(Item(0, -2_000), Defaults).Status);
        Assert.Equal(LowStockStatus.NoTerms, LowStockRule.Judge(Item(0, 84_000, noTerms: true), Defaults).Status);
    }

    [Fact]
    public void An_item_below_nothing_counts_as_having_no_cover_and_what_is_owed_is_added_to_the_order()
    {
        // -3 kg on hand (sold past zero), 1 kg a day. Lasts 0 days. 14 days = 14 kg, and 3 kg are owed: 17 kg.
        var f = LowStockRule.Judge(Item(-3_000, 28_000), Defaults);
        Assert.Equal((LowStockStatus.Order, 0.0m, 17_000), (f.Status, f.CoverDays, f.ProposedMilli));
    }

    [Fact]
    public void The_owner_can_change_how_far_back_and_how_far_ahead_the_rule_looks()
    {
        var item = Item(12_000, 84_000);
        // Looking ahead 14 days beyond delivery instead of 7: 21 days = 63 kg, 12 here: 51 missing.
        Assert.Equal(51_000, LowStockRule.Judge(item, Defaults with { ReviewDays = 14 }).ProposedMilli);
        // Looking over only 14 of the 28 days: the same 84 kg sold in 14 days is 6 kg a day; 12 kg lasts 2 days; 21 days of order... 7 + 7 = 14 days = 84 kg; 72 missing.
        var shorter = LowStockRule.Judge(item, Defaults with { WindowDays = 14 });
        Assert.Equal((14, 72_000), (shorter.EffectiveDays, shorter.ProposedMilli));
        Assert.Null(Defaults.Problem);
        Assert.NotNull((Defaults with { WindowDays = 3 }).Problem);
        Assert.NotNull((Defaults with { ReviewDays = -1 }).Problem);
        Assert.NotNull((Defaults with { MinHistoryDays = 40 }).Problem);
        Assert.NotNull((Defaults with { SnoozeDays = 91 }).Problem);
    }

    // ---- order, determinism and the fingerprint ---------------------------------------------------------------------------------------------

    private static IReadOnlyList<StockInput> Shop() =>
    [
        Item(12_000, 84_000, id: 1, name: "Rice"),                         // cover 4.0 of 7: 0.57
        Item(2_000, 28_000, id: 2, name: "Dal"),                           // 2 / 1 = 2 days of 7: 0.29
        Item(100_000, 28_000, id: 3, name: "Sugar"),                       // fine
        Item(1_000, 28_000, id: 4, name: "Tea", noTerms: true),
        Item(5_000, 56_000, id: 5, name: "Oil"),                           // 2.5 of 7: 0.36
        Item(0, 0, id: 6, name: "Salt"),
    ];

    [Fact]
    public void The_most_urgent_come_first_then_the_rest_and_the_same_figures_in_any_order_give_the_same_answer()
    {
        var first = LowStockRule.Evaluate(Shop(), Defaults);
        Assert.Equal(new long[] { 2, 5, 1, 3, 4, 6 }, first.Select(f => f.ItemId).ToArray());
        Assert.Equal(new[] { "order", "order", "order", "ok", "no-terms", "no-sales" }, first.Select(f => f.Status).ToArray());
        var random = new Random(3);
        for (var i = 0; i < 20; i++)
            Assert.Equal(first.Select(f => (f.ItemId, f.Status, f.ProposedMilli)), LowStockRule.Evaluate(Shop().OrderBy(_ => random.Next()), Defaults).Select(f => (f.ItemId, f.Status, f.ProposedMilli)));
    }

    [Fact]
    public void The_fingerprint_is_the_same_for_the_same_figures_and_changes_with_any_one_of_them()
    {
        var baseline = LowStockRule.Fingerprint(Shop(), Defaults, Now);
        Assert.Equal(baseline, LowStockRule.Fingerprint(Shop().Reverse(), Defaults, Now));
        Assert.Matches("^[0-9a-f]{64}$", baseline);
        Assert.NotEqual(baseline, LowStockRule.Fingerprint(Shop(), Defaults, Now.AddMinutes(1)));
        Assert.NotEqual(baseline, LowStockRule.Fingerprint(Shop(), Defaults with { ReviewDays = 8 }, Now));
        Assert.NotEqual(baseline, LowStockRule.Fingerprint(Shop().Select(i => i.ItemId == 3 ? i with { OnHandMilli = i.OnHandMilli + 1 } : i), Defaults, Now));
        Assert.NotEqual(baseline, LowStockRule.Fingerprint(Shop().Select(i => i.ItemId == 5 ? i with { Terms = i.Terms! with { LeadDays = 6 } } : i), Defaults, Now));
    }

    // ---- what it says -------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_explanation_gives_the_figures_in_plain_words_and_always_says_how_it_might_be_wrong()
    {
        var f = LowStockRule.Judge(Item(12_000, 84_000), Defaults);
        var text = LowStockRule.Explain(f, Defaults);
        Assert.Contains("12 kg on the shelf", text);
        Assert.Contains("sold 84 kg in the last 28 day(s)", text);
        Assert.Contains("about 3 kg a day", text);
        Assert.Contains("lasts about 4 day(s)", text);
        Assert.Contains("National Foods takes 5 day(s) to deliver and you want 2 spare", text);
        Assert.Contains("About 30 kg would cover the next 14 day(s)", text);
        Assert.Contains("a proposal", LowStockRule.WhyWrong(f));
        Assert.Contains("typed on 2 Oct 2026", LowStockRule.WhyWrong(f));
        Assert.Contains("already ordered", LowStockRule.Explain(LowStockRule.Judge(Item(12_000, 84_000, open: 30_000), Defaults), Defaults));
        Assert.Contains("no supplier or delivery time", LowStockRule.Explain(LowStockRule.Judge(Item(1, 1, noTerms: true), Defaults), Defaults));
    }

    // ---- rules that hold for any figures --------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void For_any_figures_the_order_is_whole_packs_never_below_the_least_and_more_stock_never_makes_things_worse(int seed)
    {
        var random = new Random(seed);
        for (var n = 0; n < 4_000; n++)
        {
            var terms = Terms(lead: random.Next(0, 30), safety: random.Next(0, 10), pack: random.Next(1, 20) * 100, min: random.Next(0, 5) * 1_000);
            var sold = random.Next(0, 200_000);
            var history = random.Next(1, 60);
            var onHand = random.Next(-5_000, 300_000);
            var open = random.Next(0, 3) == 0 ? random.Next(0, 100_000) : 0;
            var f = LowStockRule.Judge(Item(onHand, sold, history, open, terms), Defaults);
            if (f.Status == LowStockStatus.Order)
            {
                Assert.True(f.ProposedMilli > 0 && f.ProposedMilli % terms.PackMilli == 0, $"{f.ProposedMilli} is not whole packs of {terms.PackMilli}");
                Assert.True(f.ProposedMilli >= terms.MinOrderMilli);
                // Enough: what is here, what is ordered and the proposal together last the target days at this pace.
                Assert.True((onHand + open + f.ProposedMilli) * f.EffectiveDays >= (long)sold * f.TargetDays, "the order does not cover the days it should");
            }

            if (f.Status == LowStockStatus.Ok) Assert.True(Math.Max(0, onHand) * f.EffectiveDays >= (long)sold * f.ThresholdDays);
            // More on the shelf never turns "fine" into "running low".
            if (f.Status == LowStockStatus.Ok) Assert.Equal(LowStockStatus.Ok, LowStockRule.Judge(Item(onHand + 1_000, sold, history, open, terms), Defaults).Status);
        }
    }
}

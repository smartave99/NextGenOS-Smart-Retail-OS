using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Insights;
using NextGenOS.Hub.Purchasing;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The low-stock rule over a real shop (blueprint INS-011): what it reads from sales, returns, voids, purchases and open orders; the delivery terms a person types in; the runs and findings it
/// keeps with their reasons; setting a warning aside; and that nothing happens until the owner switches stock forecasts on. India, rupees; stock in thousandths of a kilo.
/// </summary>
public class LowStockInsightTests
{
    private static AiFixture Shop(bool on = true, bool events = false)
    {
        var f = new AiFixture();
        if (on) f.Allow(FlagKey.PredictiveInventory);
        if (events) f.Allow(FlagKey.EventEngine);
        return f;
    }

    private static Party Supplier(AiFixture f, string name = "National Foods") => f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = name });

    private static Item Goods(AiFixture f, string name = "Rice", string kind = "stock", bool track = true) =>
        f.App.Catalog.Create(new ItemInput { Kind = kind, Name = name, Unit = "kg", PriceMinor = 20_000, CostMinor = 10_000, TaxClass = "zero", TrackStock = track });

    private static void Buy(AiFixture f, Party supplier, Item item, long qtyMilli) =>
        f.App.Purchasing.Receive(f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = item.Id, QtyMilli = qtyMilli, CostMinor = 10_000 } }).Document.Id);

    private static DocumentView Sell(AiFixture f, Item item, long qtyMilli) => f.App.Documents.Checkout(new CheckoutRequest
    {
        Lines = { new LineInput { ItemId = item.Id, QtyMilli = qtyMilli } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 100_000_000 } },
    });

    /// <summary>The scenario of the hand-worked case: 100 kg bought on day 0, 3 kg sold on each of the 28 days after, so 16 kg are left and 84 kg sold in the last 28 days.</summary>
    private static (Item Rice, Party Supplier) RiceThatSellsThreeAKilo(AiFixture f, int lead = 5, int safety = 2, Action<Party>? Early = null)
    {
        var supplier = Supplier(f);
        var rice = Goods(f);
        Buy(f, supplier, rice, 100_000);
        f.App.Supply.Set(rice.Id, supplier.Id, lead, safety, 1_000, 0, null);
        Early?.Invoke(supplier);
        for (var day = 1; day <= 28; day++)
        {
            f.Shop.Clock.Advance(TimeSpan.FromDays(1));
            Sell(f, rice, 3_000);
        }

        return (rice, supplier);
    }

    // ---- switched off by default --------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Nothing_is_run_or_kept_until_the_owner_switches_stock_forecasts_on_and_the_licence_has_the_AI_part()
    {
        using var off = Shop(on: false);
        Assert.False(off.App.Insights.On);
        Assert.Equal("insights-off", Assert.Throws<HubException>(() => off.App.Insights.Run(null)).Code);
        Assert.Equal("insights-off", Assert.Throws<HubException>(() => off.App.Insights.Preview()).Code);
        Assert.False(off.App.Insights.RunIfDue());
        Assert.Equal(0, Convert.ToInt64(off.App.Db.Scalar("SELECT COUNT(*) FROM insight_runs")));

        using var unlicensed = new AiFixture(licensed: false);
        Assert.Equal("not-licensed", Assert.Throws<HubException>(() => unlicensed.App.Insights.Run(null)).Code);

        // The delivery times can be kept while it is off: nothing is judged, and switching it on later finds them.
        var supplier = Supplier(off);
        var rice = Goods(off);
        off.App.Supply.Set(rice.Id, supplier.Id, 5, 2, 1_000, 0, null);
        Assert.Equal(5, off.App.Supply.Get(rice.Id)!.LeadDays);
    }

    // ---- reading the shop's figures ------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_shop_that_sold_three_kilos_a_day_for_four_weeks_has_the_hand_worked_finding_and_the_documents_behind_it()
    {
        using var f = Shop();
        var (rice, supplier) = RiceThatSellsThreeAKilo(f);
        var run = f.App.Insights.Run(null);
        var finding = Assert.Single(f.App.Insights.Open());
        var d = finding.Detail;

        Assert.Equal((rice.Id, "order", 16_000, 84_000, 28), (finding.ItemId, finding.Status, d.OnHandMilli, d.SoldMilli, d.Days));
        // Hand-worked: 16 kg last 16 / 3 = 5.3 days of the 7 needed; 14 days = 42 kg; 16 here; 26 kg missing, in packs of 1 kg.
        Assert.Equal((5.3m, 7, 14, 26_000), (d.CoverDays, d.ThresholdDays, d.TargetDays, d.ProposedMilli));
        Assert.Equal((supplier.Id, "National Foods", 5, 2), (d.SupplierId, d.SupplierName, d.LeadDays, d.SafetyDays));
        Assert.Equal(10, d.SaleDocuments.Count);                                            // the latest bills it rests on
        Assert.All(d.SaleDocuments, id => Assert.Equal("invoice", f.App.Db.Scalar("SELECT type FROM documents WHERE id = $i", ("$i", id))));
        Assert.Contains("16 kg on the shelf", d.Explanation);
        Assert.Contains("proposal", d.WhyWrong);
        Assert.Equal((1, 1, 1), (run.Judged, run.Run.ItemsChecked, run.Run.ItemsFlagged));
        Assert.Equal(LowStockRule.RuleId + "|" + LowStockRule.Version, run.Run.RuleId + "|" + run.Run.RuleVersion);
        Assert.Equal(f.Shop.Clock.UtcNow, run.Run.AsOf);
    }

    [Fact]
    public void Returns_and_cancelled_bills_bring_the_pace_down_and_a_cancelled_purchase_is_not_a_sale()
    {
        using var f = Shop();
        var (rice, supplier) = RiceThatSellsThreeAKilo(f);
        // One of the bills is cancelled (3 kg back) and 2 kg of another come back on a credit note: 84 - 3 - 2 = 79 kg sold.
        var last = Sell(f, rice, 3_000);                                                     // 87 kg sold
        f.App.Documents.Void(last.Document.Id, "wrong item", null);                           // back to 84, 16 on hand
        var another = Sell(f, rice, 4_000);                                                  // 88 sold, 12 on hand
        f.App.Documents.CreateCreditNote(another.Document.Id, new[] { (another.Lines.Single().Id, 2_000L) }, "two back", "cash", null);   // 86 sold, 14 on hand
        // A purchase of 10 kg that is cancelled again takes the 10 kg back out: stock, but not a sale.
        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 10_000, CostMinor = 10_000 } });
        f.App.Purchasing.Receive(order.Document.Id);
        f.App.Documents.Void(order.Document.Id, "wrong supplier", null);

        var input = f.App.Insights.Inputs(f.Shop.Clock.UtcNow, new LowStockSettings()).Single();
        Assert.Equal((14_000L, 86_000L, 28), (input.OnHandMilli, input.SoldMilli, input.HistoryDays));
    }

    [Fact]
    public void Orders_that_are_still_open_count_and_items_that_are_not_kept_in_stock_or_are_switched_off_are_not_judged()
    {
        using var f = Shop();
        var (rice, supplier) = RiceThatSellsThreeAKilo(f);
        var draft = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 26_000, CostMinor = 10_000 } });   // placed, not yet received
        var service = Goods(f, "Haircut", "service", track: false);
        var retired = Goods(f, "Old tin");
        f.App.Catalog.SetActive(retired.Id, false);

        var inputs = f.App.Insights.Inputs(f.Shop.Clock.UtcNow, new LowStockSettings());
        Assert.Equal(new[] { rice.Id }, inputs.Select(i => i.ItemId).ToArray());
        Assert.Equal(26_000L, inputs.Single().OpenOrderMilli);
        Assert.Equal(new[] { draft.Document.Id }, inputs.Single().OpenOrders.ToArray());

        // 26 kg were missing and 26 kg are on order: running low, but covered; nothing more is proposed.
        var summary = f.App.Insights.Run(null);
        var finding = Assert.Single(f.App.Insights.Open());
        Assert.Equal(("covered", 0L), (finding.Status, finding.Detail.ProposedMilli));
        Assert.Contains("already ordered", finding.Detail.Explanation);
        Assert.Equal(1, summary.Run.ItemsFlagged);

        // The goods arrive: the order is no longer open, the shelf is fuller, and the item is fine.
        f.App.Purchasing.Receive(draft.Document.Id);
        f.App.Insights.Run(null);
        Assert.Empty(f.App.Insights.Open());
    }

    [Fact]
    public void Items_without_a_supplier_or_with_too_little_history_or_no_sales_are_counted_and_said_so_never_guessed()
    {
        using var f = Shop();
        var noTerms = Goods(f, "Tea");
        var still = Goods(f, "Salt");
        var (rice, supplier) = RiceThatSellsThreeAKilo(f, Early: s =>
        {
            Buy(f, s, noTerms, 10_000);
            Buy(f, s, still, 10_000);
            f.App.Supply.Set(still.Id, s.Id, 3, 0, 1_000, 0, null);
        });
        var young = Goods(f, "Biscuits");
        Buy(f, supplier, young, 10_000);                                    // bought today: a day of history at most
        Sell(f, young, 2_000);
        f.App.Supply.Set(young.Id, supplier.Id, 3, 0, 1_000, 0, null);

        var run = f.App.Insights.Run(null);
        // Rice is judged; tea has no supplier; biscuits are new; salt has been on the shelf for four weeks and never sold.
        Assert.Equal((4, 1, 1, 1, 1), (run.Run.ItemsChecked, run.NoTerms, run.ShortHistory, run.NoSales, run.Judged));
        Assert.Equal(new[] { rice.Id }, f.App.Insights.Open().Select(x => x.ItemId).ToArray());
    }

    // ---- the terms a person types --------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Delivery_terms_are_kept_with_who_typed_them_checked_replaced_and_taken_away_and_every_change_is_written_down()
    {
        using var f = Shop();
        var supplier = Supplier(f);
        var rice = Goods(f);
        var other = Supplier(f, "Mill Co");
        var terms = f.App.Supply.Set(rice.Id, supplier.Id, 5, 2, 12_000, 48_000, 4);
        Assert.Equal((supplier.Id, 5, 2, 12_000L, 48_000L, 4L, f.Shop.Clock.UtcNow), (terms.SupplierId, terms.LeadDays, terms.SafetyDays, terms.PackMilli, terms.MinOrderMilli, terms.EnteredBy, terms.EnteredAt));
        Assert.Equal(7, terms.ThresholdDays);

        f.Shop.Clock.Advance(TimeSpan.FromDays(1));
        var changed = f.App.Supply.Set(rice.Id, other.Id, 9, 0, 1_000, 0, 4);                                  // a second try replaces the first
        Assert.Equal((other.Id, 9, f.Shop.Clock.UtcNow), (changed.SupplierId, changed.LeadDays, changed.EnteredAt));
        Assert.Single(f.App.Supply.All());

        Assert.Equal("item-not-found", Assert.Throws<HubException>(() => f.App.Supply.Set(9_999, supplier.Id, 5, 2, 1_000, 0, 4)).Code);
        Assert.Equal("not-stocked", Assert.Throws<HubException>(() => f.App.Supply.Set(Goods(f, "Haircut", "service", track: false).Id, supplier.Id, 5, 2, 1_000, 0, 4)).Code);
        Assert.Equal("party-not-found", Assert.Throws<HubException>(() => f.App.Supply.Set(rice.Id, 9_999, 5, 2, 1_000, 0, 4)).Code);
        var customer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" });
        Assert.Equal("not-supplier", Assert.Throws<HubException>(() => f.App.Supply.Set(rice.Id, customer.Id, 5, 2, 1_000, 0, 4)).Code);
        foreach (var (lead, safety, pack, min, code) in new[] { (-1, 0, 1_000L, 0L, "bad-lead"), (366, 0, 1_000L, 0L, "bad-lead"), (5, -1, 1_000L, 0L, "bad-safety"), (5, 366, 1_000L, 0L, "bad-safety"), (5, 2, 0L, 0L, "bad-pack"), (5, 2, 1_000L, -1L, "bad-minimum") })
            Assert.Equal(code, Assert.Throws<HubException>(() => f.App.Supply.Set(rice.Id, supplier.Id, lead, safety, pack, min, 4)).Code);
        Assert.Equal(other.Id, f.App.Supply.Get(rice.Id)!.SupplierId);                                         // the refused tries changed nothing

        f.App.Supply.Clear(rice.Id, 4);
        Assert.Null(f.App.Supply.Get(rice.Id));
        var actions = f.App.Audit.Recent().Select(a => a.Action).ToArray();
        Assert.Equal(2, actions.Count(a => a == "supply.set"));
        Assert.Contains("supply.clear", actions);
    }

    // ---- runs, findings, setting aside ---------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_same_shop_at_the_same_moment_gives_the_same_answer_every_time_and_a_run_keeps_what_it_looked_at()
    {
        using var f = Shop();
        RiceThatSellsThreeAKilo(f);
        var at = f.Shop.Clock.UtcNow;
        var first = f.App.Insights.Preview(at);
        var second = f.App.Insights.Preview(at);
        Assert.Equal(first.Fingerprint, second.Fingerprint);
        Assert.Equal(first.Findings.Select(x => (x.ItemId, x.Status, x.ProposedMilli)), second.Findings.Select(x => (x.ItemId, x.Status, x.ProposedMilli)));
        Assert.Equal(0, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM insight_runs")));            // looking keeps nothing

        var a = f.App.Insights.Run(null, at);
        var b = f.App.Insights.Run(null, at);
        Assert.Equal(first.Fingerprint, a.Run.InputsHash);
        Assert.Equal(a.Run.InputsHash, b.Run.InputsHash);
        Assert.NotEqual(a.Run.Id, b.Run.Id);
        // The earlier run's finding is replaced by the later run's, never left open twice.
        Assert.Single(f.App.Insights.Open());
        Assert.Equal(1, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM insight_findings WHERE state = 'superseded'")));
        // A later moment with no new sales is another fingerprint (the figures are the same but the moment is not).
        Assert.NotEqual(a.Run.InputsHash, f.App.Insights.Preview(at.AddHours(1)).Fingerprint);
        Assert.Equal(b.Run.Id, f.App.Insights.Latest()!.Run.Id);
    }

    [Fact]
    public void A_warning_that_is_set_aside_stays_quiet_for_the_days_chosen_and_comes_back_if_things_are_still_the_same_after_that()
    {
        using var f = Shop();
        RiceThatSellsThreeAKilo(f);
        f.App.Insights.SaveSettings(new LowStockSettings(SnoozeDays: 5), 1);
        f.App.Insights.Run(null);
        var finding = f.App.Insights.Open().Single();
        f.App.Insights.Dismiss(finding.Id, "I will order on Friday", 4);
        Assert.Empty(f.App.Insights.Open());
        Assert.Equal(("dismissed", "I will order on Friday"), (f.App.Insights.Finding(finding.Id)!.State, f.App.Insights.Finding(finding.Id)!.DecisionNote));
        Assert.Equal("no-finding", Assert.Throws<HubException>(() => f.App.Insights.Dismiss(finding.Id, null, 4)).Code);

        f.Shop.Clock.Advance(TimeSpan.FromDays(3));
        f.App.Insights.Run(null);
        Assert.Empty(f.App.Insights.Open());                                    // 3 days is inside the 5 days of quiet (and it is still running low: the three oldest days of selling fell out of the 28)
        f.Shop.Clock.Advance(TimeSpan.FromDays(3));
        f.App.Insights.Run(null);
        Assert.Single(f.App.Insights.Open());                                   // 6 days later it is still running low (66 kg in 28 days: 16 kg last 6.8 days of the 7 needed), and it says so again
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "insight.dismiss");
    }

    [Fact]
    public void The_owner_changes_what_the_rule_looks_at_and_a_wrong_setting_is_refused_in_plain_words()
    {
        using var f = Shop();
        Assert.Equal(new LowStockSettings(), f.App.Insights.Settings());
        var saved = f.App.Insights.SaveSettings(new LowStockSettings(WindowDays: 14, ReviewDays: 14, MinHistoryDays: 3, SnoozeDays: 0), 1);
        Assert.Equal(14, saved.WindowDays);
        Assert.Equal(saved, f.App.Insights.Settings());
        Assert.Equal("bad-settings", Assert.Throws<HubException>(() => f.App.Insights.SaveSettings(new LowStockSettings(WindowDays: 2), 1)).Code);
        Assert.Equal(14, f.App.Insights.Settings().WindowDays);
        RiceThatSellsThreeAKilo(f);
        var run = f.App.Insights.Run(null);
        Assert.Equal(14, run.Run.Settings.WindowDays);                          // the run keeps the settings it used
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "insight.settings");
    }

    [Fact]
    public void The_daily_run_happens_once_in_twenty_hours_and_a_finding_leaves_a_message_for_the_event_history()
    {
        using var f = Shop(events: true);
        RiceThatSellsThreeAKilo(f);
        Assert.True(f.App.Insights.RunIfDue());
        Assert.False(f.App.Insights.RunIfDue());
        f.Shop.Clock.Advance(TimeSpan.FromHours(19));
        Assert.False(f.App.Insights.RunIfDue());
        f.Shop.Clock.Advance(TimeSpan.FromHours(2));
        Assert.True(f.App.Insights.RunIfDue());
        var message = f.App.Outbox.List().First(m => m.EventType == "recommendation.created");
        Assert.Equal(("finding", DataClass.Internal), (message.AggregateType, message.DataClass));
        Assert.Contains("\"itemId\"", message.Payload);
        Assert.DoesNotContain("Rice", message.Payload);
        f.App.Outbox.DispatchAll();
        Assert.Equal(2, f.App.Events.Query(new NextGenOS.Hub.Events.EventQuery(TypePrefix: "recommendation.created")).Count);
    }

    [Fact]
    public void The_way_back_takes_the_four_tables_away_and_leaves_the_shop_and_every_table_has_tenant_and_site()
    {
        using var f = Shop();
        RiceThatSellsThreeAKilo(f);
        f.App.Insights.Run(null);
        foreach (var table in new[] { "supply_terms", "insight_settings", "insight_runs", "insight_findings" })
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0)).ToArray();
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
        }

        var sales = Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE number IS NOT NULL"));
        f.App.Db.Rollback(16);   // the step before this one (later steps are undone with it)
        Assert.Empty(f.App.Db.Query("SELECT name FROM sqlite_master WHERE name IN ('supply_terms', 'insight_settings', 'insight_runs', 'insight_findings')", r => r.GetString(0)));
        Assert.Equal(sales, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE number IS NOT NULL")));
        var again = f.Reopen();
        Assert.Equal(0, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM supply_terms")));
    }
}

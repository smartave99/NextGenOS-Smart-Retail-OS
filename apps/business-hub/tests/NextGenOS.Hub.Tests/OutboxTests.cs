using System.Text.Json;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Purchasing;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The transactional outbox for business events (blueprint ticket EVT-009): a sale, a payment, a return, a purchase or a stock change leaves a message in the very transaction that makes it;
/// a dispatcher gives the committed messages to the event history, once each, even when the program stops half-way, two dispatchers run at once, or a message is delivered again.
/// </summary>
public class OutboxTests
{
    private static AiFixture Shop(bool historyOn = true)
    {
        var f = new AiFixture();
        if (historyOn) f.Allow(FlagKey.EventEngine);
        return f;
    }

    private static Item Haircut(AiFixture f) => f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Haircut", PriceMinor = 40_000, TaxClass = "zero" });

    private static DocumentView Sell(AiFixture f, Item item, string? key = null, string? notes = null, string? reference = null, long? partyId = null) => f.App.Documents.Checkout(new CheckoutRequest
    {
        PartyId = partyId, Notes = notes, RequestKey = key,
        Lines = { new LineInput { ItemId = item.Id, QtyMilli = 1_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 40_000, Reference = reference } },
    });

    private static long Rows(AiFixture f, string? type = null, string? status = null) => Convert.ToInt64(f.App.Db.Scalar(
        "SELECT COUNT(*) FROM outbox WHERE ($t IS NULL OR event_type = $t) AND ($s IS NULL OR status = $s)", ("$t", type), ("$s", status)));

    private static IReadOnlyList<EventRecord> Events(AiFixture f, string? type = null) =>
        f.App.Events.Query(new EventQuery { Limit = 500 }).Where(e => type is null || e.Type == type).OrderBy(e => e.Id).ToList();

    /// <summary>Changes the shop file directly, as a fault or a person with a database tool would.</summary>
    private static void Sql(AiFixture f, string sql, params (string Name, object? Value)[] args) => f.App.Db.InTransaction((c, t) => HubDb.Exec(c, sql, t, args));

    private static long EventRows(AiFixture f) => Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM events"));

    // ---- writing in the same transaction ------------------------------------------------------------------------------------------

    [Fact]
    public void Nothing_is_written_while_the_history_is_off_and_nothing_is_delivered_when_it_is_switched_on_later()
    {
        using var f = Shop(historyOn: false);
        Sell(f, Haircut(f));
        Assert.Equal(0, Rows(f));
        Assert.Equal(0, f.App.Outbox.Dispatch());
        Assert.Equal(0, EventRows(f));
    }

    [Fact]
    public void A_sale_leaves_one_message_for_the_sale_and_one_for_the_payment_and_the_message_is_written_with_the_sale()
    {
        using var f = Shop();
        var sale = Sell(f, Haircut(f), key: "till-1-sale-1");

        Assert.Equal(1, Rows(f, "sale.issued"));
        Assert.Equal(1, Rows(f, "payment.recorded"));
        Assert.Equal(2, Rows(f));
        Assert.Equal(2, Rows(f, status: "pending"));
        var message = f.App.Outbox.List().Single(m => m.EventType == "sale.issued");
        Assert.Equal(("invoice", sale.Document.Id, DataClass.Financial, "till-1-sale-1", 1), (message.AggregateType, message.AggregateId, message.DataClass, message.CorrelationId, message.SchemaVersion));
        using var payload = JsonDocument.Parse(message.Payload);
        Assert.Equal(sale.Document.Id, payload.RootElement.GetProperty("documentId").GetInt64());
        Assert.Equal(sale.Document.TotalMinor, payload.RootElement.GetProperty("totalMinor").GetInt64());
        Assert.Equal(1, payload.RootElement.GetProperty("lines").GetArrayLength());
    }

    [Fact]
    public void The_same_sale_asked_for_again_with_the_same_key_leaves_no_second_message()
    {
        using var f = Shop();
        var item = Haircut(f);
        var first = Sell(f, item, key: "till-1-sale-9");
        var again = Sell(f, item, key: "till-1-sale-9");
        Assert.Equal(first.Document.Id, again.Document.Id);
        Assert.Equal(1, Rows(f, "sale.issued"));
        Assert.Equal(1, Rows(f, "payment.recorded"));
    }

    [Fact]
    public void A_message_written_in_a_transaction_that_is_rolled_back_is_not_kept_and_a_sale_that_is_refused_leaves_none()
    {
        using var f = Shop();
        var item = Haircut(f);
        Assert.Throws<InvalidOperationException>(() => f.App.Db.InTransaction((c, t) =>
        {
            f.App.Outbox.Add(c, t, "sale.issued", "invoice", 1, new Dictionary<string, object?> { ["documentId"] = 1 }, DataClass.Financial, null);
            Assert.Equal(1L, Convert.ToInt64(HubDb.Scalar(c, "SELECT COUNT(*) FROM outbox", t)));   // there inside the transaction
            throw new InvalidOperationException("the sale failed after the message was written");
        }));
        Assert.Equal(0, Rows(f));

        // A sale the shop refuses (too little paid, nobody to owe it) makes no bill and so no message.
        Assert.Throws<HubException>(() => f.App.Documents.Checkout(new CheckoutRequest
        {
            Lines = { new LineInput { ItemId = item.Id, QtyMilli = 1_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 100 } },
        }));
        Assert.Equal(0, Rows(f));
        Assert.Equal(0, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE number IS NOT NULL")));
    }

    [Fact]
    public void Every_kind_of_thing_that_happens_leaves_its_own_message()
    {
        using var f = Shop();
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 20_000, TaxClass = "zero" });
        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 10_000, CostMinor = 10_000 } });
        var bought = f.App.Purchasing.Receive(order.Document.Id);                                          // purchase.received
        f.App.Catalog.Adjust(rice.Id, -1_000, "damaged");                                                  // stock.adjusted
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 4_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 10_000_000 } } });   // sale.issued, payment.recorded
        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines.Single().Id, 1_000L) }, "one back", "cash", null);   // sale.returned (+ a refund payment)
        f.App.Documents.Void(bought.Document.Id, "wrong supplier", null);                                  // purchase.voided
        var second = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 1_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 10_000_000 } } });
        f.App.Documents.Void(second.Document.Id, "mistake", null);                                         // sale.voided

        var kinds = f.App.Outbox.List(limit: 500).Select(m => m.EventType).Distinct().Order().ToArray();
        Assert.Equal(new[] { "payment.recorded", "purchase.received", "purchase.voided", "sale.issued", "sale.returned", "sale.voided", "stock.adjusted" }, kinds);
        Assert.Equal(2, Rows(f, "sale.issued"));
        Assert.Equal(1, Rows(f, "stock.adjusted"));
        Assert.Equal("item", f.App.Outbox.List().Single(m => m.EventType == "stock.adjusted").AggregateType);
        Assert.Equal("credit_note", f.App.Outbox.List().Single(m => m.EventType == "sale.returned").AggregateType);
        Assert.Equal(f.App.Outbox.List(limit: 500).Count, f.App.Outbox.List(limit: 500).Select(m => m.Id).Distinct().Count());
    }

    [Fact]
    public void A_message_holds_figures_and_numbers_never_a_name_a_note_or_what_the_person_typed_with_the_payment()
    {
        using var f = Shop();
        var customer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Maria Santos", Phone = "+91 98765 43210", Email = "maria@example.com" });
        Sell(f, Haircut(f), notes: "ring the bell twice, card 4111 1111 1111 1111", reference: "UPI-ref-SECRET-77", partyId: customer.Id);

        foreach (var m in f.App.Outbox.List(limit: 500))
        {
            Assert.DoesNotContain("Maria", m.Payload);
            Assert.DoesNotContain("example.com", m.Payload);
            Assert.DoesNotContain("98765", m.Payload);
            Assert.DoesNotContain("4111", m.Payload);
            Assert.DoesNotContain("ring the bell", m.Payload);
            Assert.DoesNotContain("SECRET", m.Payload);
            Assert.DoesNotContain("Haircut", m.Payload);
            Assert.NotEqual(DataClass.PaymentSensitive, m.DataClass);
        }
    }

    // ---- delivering ------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Delivering_gives_the_event_history_one_event_for_each_message_with_its_key_its_subject_and_its_reason()
    {
        using var f = Shop();
        var sale = Sell(f, Haircut(f), key: "till-1-sale-2");
        Assert.Equal(0, EventRows(f));                                   // nothing is delivered by the sale itself: the till does not wait for it

        Assert.Equal(2, f.App.Outbox.Dispatch());
        var issued = Events(f, "sale.issued.v1").Single();
        Assert.Equal(("invoice:" + sale.Document.Id, DataClass.Financial, "till-1-sale-2", MadeBy.System, EventStatus.Confirmed), (issued.SubjectRef, issued.DataClass, issued.CorrelationId, issued.MadeByType, issued.Status));
        Assert.Matches("^outbox:[0-9]+$", issued.IdempotencyKey);
        Assert.Contains("Recorded by the program", issued.Explanation);
        Assert.Equal(sale.Document.TotalMinor, JsonDocument.Parse(issued.DataJson!).RootElement.GetProperty("totalMinor").GetInt64());
        Assert.Single(Events(f, "payment.recorded.v1"));
        Assert.Equal(0, Rows(f, status: "pending"));
        Assert.Equal(2, Rows(f, status: "delivered"));
        Assert.Equal(2, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM outbox_processed")));
        Assert.Equal(0, f.App.Outbox.Dispatch());                       // nothing is left to deliver
        Assert.Equal(2, EventRows(f));
    }

    [Fact]
    public void A_busy_day_leaves_more_than_one_batch_and_the_upkeep_delivers_them_all_up_to_a_limit()
    {
        using var f = Shop();
        var item = Haircut(f);
        for (var i = 0; i < 60; i++) Sell(f, item);                          // 120 messages: a sale and a payment each, more than the 50 of one batch
        Assert.Equal(120, Rows(f, status: "pending"));
        Assert.Equal(50, f.App.Outbox.Dispatch());                           // one batch is 50
        Assert.Equal(70, f.App.Outbox.DispatchAll());                        // the rest, batch after batch
        Assert.Equal(0, Rows(f, status: "pending"));
        Assert.Equal(120, EventRows(f));

        for (var i = 0; i < 30; i++) Sell(f, item);                          // 60 more
        Assert.Equal(50, f.App.Outbox.DispatchAll(maxBatches: 1));           // a limit on the batches stops it there; the rest wait for next time
        Assert.Equal(10, f.App.Outbox.DispatchAll());
    }

    [Fact]
    public void A_message_delivered_again_changes_nothing_whether_it_is_replayed_or_the_note_of_what_was_done_is_lost()
    {
        using var f = Shop();
        var item = Haircut(f);
        Sell(f, item);
        Sell(f, item);
        f.App.Outbox.Dispatch();
        var before = Events(f).Select(e => (e.Id, e.IdempotencyKey)).ToList();
        Assert.Equal(4, before.Count);

        // The owner asks for the period again: the messages are made ready, delivered, and the history is exactly as it was.
        var n = f.App.Outbox.Replay(f.Shop.Clock.UtcNow.AddDays(-1), f.Shop.Clock.UtcNow.AddDays(1), null);
        Assert.Equal(4, n);
        Assert.Equal(4, Rows(f, status: "pending"));
        Assert.Equal(4, f.App.Outbox.Dispatch());
        Assert.Equal(before, Events(f).Select(e => (e.Id, e.IdempotencyKey)).ToList());

        // The program stopped after the event was kept but before it wrote that it had: the message is simply delivered once more.
        Sql(f, "UPDATE outbox SET status = 'pending', delivered_at = NULL");
        Sql(f, "DELETE FROM outbox_processed");
        Assert.Equal(4, f.App.Outbox.Dispatch());
        Assert.Equal(before, Events(f).Select(e => (e.Id, e.IdempotencyKey)).ToList());
        Assert.Equal(4, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM outbox_processed")));

        // And a message whose note says it was done is not delivered a second time at all.
        Sql(f, "UPDATE outbox SET status = 'pending', delivered_at = NULL");
        Assert.Equal(4, f.App.Outbox.Dispatch());
        Assert.Equal(4, EventRows(f));
    }

    [Fact]
    public void A_replay_is_only_for_the_period_asked_and_only_for_what_was_delivered()
    {
        using var f = Shop();
        var item = Haircut(f);
        Sell(f, item);
        f.App.Outbox.Dispatch();
        f.Shop.Clock.Advance(TimeSpan.FromDays(10));
        Sell(f, item);                                                       // not yet delivered
        Assert.Equal(0, f.App.Outbox.Replay(f.Shop.Clock.UtcNow.AddDays(-1), f.Shop.Clock.UtcNow.AddDays(1), null));   // the old ones are outside the period, the new ones are not delivered yet
        Assert.Equal(2, f.App.Outbox.Replay(f.Shop.Clock.UtcNow.AddDays(-11), f.Shop.Clock.UtcNow.AddDays(-9), null));
        Assert.Contains(f.App.Db.Query("SELECT action FROM audit_log", r => r.GetString(0)), a => a == "outbox.replay");
    }

    [Fact]
    public void A_stopped_program_loses_nothing_the_messages_wait_in_the_shop_file_and_are_delivered_once_when_it_starts_again()
    {
        using var f = Shop();
        Sell(f, Haircut(f));
        Assert.Equal(2, Rows(f, status: "pending"));
        Assert.Equal(0, EventRows(f));                                       // ... and now the program is stopped before it delivered anything

        var again = f.Reopen();                                              // started again: it delivers what it finds, once
        Assert.Equal(2, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM events")));
        Assert.Equal(0, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM outbox WHERE status <> 'delivered'")));
        var third = f.Reopen();
        Assert.Equal(2, Convert.ToInt64(third.Db.Scalar("SELECT COUNT(*) FROM events")));
    }

    [Fact]
    public void A_message_taken_by_a_program_that_stopped_half_way_is_taken_again_when_its_lease_has_run_out_and_not_before()
    {
        using var f = Shop();
        Sell(f, Haircut(f));
        // Another dispatcher took the messages two minutes ago minus a second and then stopped.
        Sql(f, "UPDATE outbox SET leased_until = $until", ("$until", Iso.Text(f.Shop.Clock.UtcNow + OutboxService.Lease - TimeSpan.FromSeconds(1))));
        Assert.Equal(0, f.App.Outbox.Dispatch());
        f.Shop.Clock.Advance(OutboxService.Lease);
        Assert.Equal(2, f.App.Outbox.Dispatch());
        Assert.Equal(2, EventRows(f));
    }

    [Fact]
    public async Task Several_dispatchers_at_the_same_moment_deliver_each_message_once()
    {
        using var f = Shop();
        var item = Haircut(f);
        for (var i = 0; i < 12; i++) Sell(f, item);
        var other = f.Reopen();                                              // a second program on the same file would deliver them already: put them back
        Sql(f, "DELETE FROM events");
        Sql(f, "DELETE FROM outbox_processed");
        Sql(f, "UPDATE outbox SET status = 'pending', delivered_at = NULL, leased_until = NULL, next_attempt_at = $now", ("$now", Iso.Text(f.Shop.Clock.UtcNow)));

        var total = (await Task.WhenAll(Enumerable.Range(0, 6).Select(i => Task.Run(() => (i % 2 == 0 ? f.App : other).Outbox.Dispatch())))).Sum();

        Assert.Equal(24, total);                                             // 12 sales and 12 payments, each delivered by exactly one of them
        Assert.Equal(24, EventRows(f));
        Assert.Equal(24, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(DISTINCT idempotency_key) FROM events")));
        Assert.Equal(24, Rows(f, status: "delivered"));
    }

    [Fact]
    public void Delivery_waits_while_the_history_is_off_and_goes_on_when_it_is_switched_on_again()
    {
        using var f = Shop();
        Sell(f, Haircut(f));
        f.Ai.Flags.Set(FlagKey.EventEngine, false, null);
        Assert.Equal(0, f.App.Outbox.Dispatch());
        var stats = f.App.Outbox.Stats();
        Assert.Equal((2L, 0L, true), (stats.Waiting, stats.Failed, stats.Paused));
        Assert.Equal(0, Convert.ToInt64(f.App.Db.Scalar("SELECT MAX(attempts) FROM outbox")));   // no try was used up

        f.Ai.Flags.Set(FlagKey.EventEngine, true, null);
        Assert.Equal(2, f.App.Outbox.Dispatch());
        Assert.False(f.App.Outbox.Stats().Paused);
    }

    // ---- failing, trying again, and showing it --------------------------------------------------------------------------------

    /// <summary>A message the event history will refuse (an event type it does not accept), as if a consumer were failing.</summary>
    private static long Spoil(AiFixture f)
    {
        Sell(f, Haircut(f));
        f.App.Outbox.Dispatch();
        Sql(f, "DELETE FROM events");
        Sql(f, "DELETE FROM outbox_processed");
        Sql(f, "UPDATE outbox SET status = 'pending', delivered_at = NULL");
        var id = Convert.ToInt64(f.App.Db.Scalar("SELECT id FROM outbox WHERE event_type = 'sale.issued'"));
        Sql(f, "UPDATE outbox SET event_type = 'Not A Type' WHERE id = $id", ("$id", id));
        return id;
    }

    [Fact]
    public void A_message_that_cannot_be_delivered_is_tried_again_later_and_later_and_then_set_aside_while_the_others_go_on()
    {
        using var f = Shop();
        var bad = Spoil(f);

        Assert.Equal(1, f.App.Outbox.Dispatch());                            // the payment goes, the spoiled one does not
        var first = f.App.Outbox.List().Single(m => m.Id == bad);
        Assert.Equal(("pending", 1), (first.Status, first.Attempts));
        Assert.Equal(f.Shop.Clock.UtcNow + TimeSpan.FromMinutes(2), first.NextAttemptAt);
        Assert.Contains("event type", first.LastError!, StringComparison.OrdinalIgnoreCase);

        Assert.Equal(0, f.App.Outbox.Dispatch());                            // not yet due
        Assert.Equal(1, f.App.Outbox.List().Single(m => m.Id == bad).Attempts);

        var waits = new List<TimeSpan>();
        for (var i = 2; i <= OutboxService.MaxAttempts; i++)
        {
            f.Shop.Clock.Advance(TimeSpan.FromHours(2));
            f.App.Outbox.Dispatch();
            var m = f.App.Outbox.List().Single(x => x.Id == bad);
            Assert.Equal(i, m.Attempts);
            waits.Add(m.NextAttemptAt - f.Shop.Clock.UtcNow);
        }

        Assert.Equal(TimeSpan.FromMinutes(60), waits.Max());                  // never longer than an hour
        Assert.Equal(waits.Order().ToList(), waits);                          // longer and longer
        var last = f.App.Outbox.List().Single(m => m.Id == bad);
        Assert.Equal("failed", last.Status);
        f.Shop.Clock.Advance(TimeSpan.FromDays(1));
        Assert.Equal(0, f.App.Outbox.Dispatch());                            // set aside: not tried again by itself
        Assert.Equal(OutboxService.MaxAttempts, f.App.Outbox.List().Single(m => m.Id == bad).Attempts);
        var stats = f.App.Outbox.Stats();
        Assert.Equal((0L, 1L, 1L), (stats.Waiting, stats.Failed, stats.Delivered));
        Assert.False(stats.Healthy);
    }

    [Fact]
    public void What_failed_for_good_is_tried_again_when_the_owner_asks_after_the_cause_is_put_right_and_it_is_audited()
    {
        using var f = Shop();
        var bad = Spoil(f);
        for (var i = 0; i < OutboxService.MaxAttempts; i++)
        {
            f.Shop.Clock.Advance(TimeSpan.FromHours(2));
            f.App.Outbox.Dispatch();
        }

        Assert.Equal("failed", f.App.Outbox.List().Single(m => m.Id == bad).Status);
        Sql(f, "UPDATE outbox SET event_type = 'sale.issued' WHERE id = $id", ("$id", bad));      // the cause is put right
        Assert.Equal(1, f.App.Outbox.RetryFailed(null));
        Assert.Equal(1, f.App.Outbox.Dispatch());
        Assert.Equal(("delivered", 0), (f.App.Outbox.List().Single(m => m.Id == bad).Status, f.App.Outbox.List().Single(m => m.Id == bad).Attempts));
        Assert.Single(Events(f, "sale.issued.v1"));
        Assert.Equal(0, f.App.Outbox.RetryFailed(null));                      // nothing left to retry
        Assert.Contains(f.App.Db.Query("SELECT action FROM audit_log", r => r.GetString(0)), a => a == "outbox.retry");
        Assert.True(f.App.Outbox.Stats().Healthy);
    }

    [Fact]
    public void The_screen_numbers_say_what_waits_for_how_long_and_what_failed()
    {
        using var f = Shop();
        Assert.Equal((0L, 0L, 0L, null), (f.App.Outbox.Stats().Waiting, f.App.Outbox.Stats().Failed, f.App.Outbox.Stats().Delivered, f.App.Outbox.Stats().OldestWaitingAge));
        Assert.True(f.App.Outbox.Stats().Healthy);

        Sell(f, Haircut(f));
        f.Shop.Clock.Advance(TimeSpan.FromMinutes(45));
        var stats = f.App.Outbox.Stats();
        Assert.Equal(2, stats.Waiting);
        Assert.Equal(TimeSpan.FromMinutes(45), stats.OldestWaitingAge);
        Assert.False(stats.Healthy);                                          // waiting for more than half an hour is not healthy
        f.App.Outbox.Dispatch();
        Assert.True(f.App.Outbox.Stats().Healthy);
    }

    // ---- the way back and the rules ------------------------------------------------------------------------------------------------

    [Fact]
    public void The_outbox_is_new_tables_with_tenant_and_site_and_the_way_back_takes_them_away_and_leaves_the_shop_and_its_events()
    {
        using var f = Shop();
        Sell(f, Haircut(f));
        f.App.Outbox.Dispatch();
        foreach (var table in new[] { "outbox", "outbox_processed" })
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0)).ToArray();
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
        }

        var sales = Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE number IS NOT NULL"));
        f.App.Db.Rollback(15);   // the step before the outbox (later steps are undone with it)
        Assert.Empty(f.App.Db.Query("SELECT name FROM sqlite_master WHERE name LIKE 'outbox%'", r => r.GetString(0)));
        Assert.Equal(sales, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE number IS NOT NULL")));
        Assert.Equal(2, EventRows(f));                                        // what the history already kept stays

        var again = f.Reopen();                                               // forward again: the tables come back, empty
        Assert.Equal(0, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM outbox")));
        again.Outbox.Dispatch();
    }

    [Fact]
    public void A_sale_is_made_just_the_same_when_the_history_cannot_take_what_was_left_for_it()
    {
        using var f = Shop();
        var item = Haircut(f);
        Sell(f, item);
        f.Ai.Flags.Set(FlagKey.EventEngine, false, null);
        var sale = Sell(f, item);                                             // history off, outbox idle: the till does not notice
        Assert.NotNull(sale.Document.Number);
        f.Allow(FlagKey.EventEngine);
        Assert.Equal(2, Rows(f));                                             // only the first sale left messages
    }

    [Fact]
    public void Withdrawing_the_licence_stops_both_writing_and_delivering()
    {
        using var f = Shop();
        Sell(f, Haircut(f));
        f.Entitled.Allowed = false;                                           // the licence is withdrawn: no flag counts any more
        Assert.False(f.App.Outbox.Recording);
        Assert.Equal(0, f.App.Outbox.Dispatch());
        Sell(f, Haircut(f));
        Assert.Equal(2, Rows(f));                                             // and no message is written
    }
}

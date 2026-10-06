using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Events;

namespace NextGenOS.Hub.Tests;

/// <summary>The business event history: what is kept apart (what was seen, and what is true), how it is written, corrected and read, and how it is forgotten.</summary>
public class EventStoreTests
{
    private static ObservationInput Seen(AiFixture f, string kind = "object.detected", string dataClass = DataClass.Internal, double confidence = 0.8, TimeSpan? ago = null, string? zone = "zone:entrance", string? subject = "track:cam1:17", string? data = "{\"box\":[0.1,0.2,0.3,0.4]}") =>
        new(kind, SourceType.Model, "cam-1", dataClass, f.Shop.Clock.UtcNow - (ago ?? TimeSpan.FromSeconds(5)), confidence, "detector", "2.1", zone, subject, "hand", data);

    private static EventInput Fact(AiFixture f, string type = "customer_session.picked_up_product", string dataClass = DataClass.Internal, double confidence = 0.9, TimeSpan? ago = null,
        IReadOnlyList<long>? observations = null, IReadOnlyList<EvidenceInput>? evidence = null, string? key = null, string status = EventStatus.Confirmed, string? subject = "track:cam1:17") =>
        new(type, MadeBy.Rule, "pickup-rule", dataClass, f.Shop.Clock.UtcNow - (ago ?? TimeSpan.FromSeconds(3)), confidence, "1.0", "track:cam1:17", subject, "product:8901000000019", "zone:aisle-3", status,
            "A hand stayed at the shelf and the product left it", "{\"count\":1}", "visit-42", key, observations, evidence);

    private static AiFixture Recording(bool licensed = true)
    {
        var f = new AiFixture(licensed);
        if (licensed) f.Allow(FlagKey.EventEngine);
        return f;
    }

    [Fact]
    public void Nothing_is_recorded_until_the_owner_switches_the_history_on_and_the_licence_has_the_AI_part()
    {
        using var off = new AiFixture();
        Assert.False(off.App.Events.Recording);
        Assert.Equal("events-off", Assert.Throws<HubException>(() => off.App.Events.Observe(Seen(off))).Code);
        Assert.Equal("events-off", Assert.Throws<HubException>(() => off.App.Events.Append(Fact(off))).Code);

        using var unlicensed = new AiFixture(licensed: false);
        Assert.Equal("not-licensed", Assert.Throws<HubException>(() => unlicensed.App.Events.Append(Fact(unlicensed))).Code);
        Assert.Equal("not-licensed", Assert.Throws<HubException>(() => unlicensed.App.Events.SetStatus(1, EventStatus.Confirmed, 1)).Code);
        Assert.Equal(0, unlicensed.App.Events.Counts().Observations);

        using var on = Recording();
        Assert.True(on.App.Events.Recording);
        Assert.Equal(1, on.App.Events.Observe(Seen(on)).Id);
        on.Entitled.Allowed = false;   // the licence is withdrawn: writing stops, what was kept stays readable
        Assert.Throws<HubException>(() => on.App.Events.Observe(Seen(on)));
        Assert.Single(on.App.Events.QueryObservations(new ObservationQuery()));
    }

    [Fact]
    public void An_observation_is_kept_as_it_was_seen_with_its_source_model_and_the_day_it_may_be_forgotten()
    {
        using var f = Recording();
        var o = f.App.Events.Observe(Seen(f, dataClass: DataClass.Video));

        Assert.Equal(("object.detected", "model", "cam-1", "detector", "2.1", "hand"), (o.Kind, o.SourceType, o.SourceId, o.ModelId, o.ModelVersion, o.Label));
        Assert.Equal(("zone:entrance", "track:cam1:17", 0.8, DataClass.Video), (o.ZoneRef, o.SubjectRef, o.Confidence, o.DataClass));
        Assert.Equal("{\"box\":[0.1,0.2,0.3,0.4]}", o.DataJson);
        Assert.Equal(f.Shop.Clock.UtcNow, o.RecordedAt);
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(3), o.RetainUntil);   // camera pictures are kept for 3 days unless the owner says otherwise
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(14), f.App.Events.Observe(Seen(f)).RetainUntil);
    }

    [Theory]
    [InlineData("Object.Detected")]
    [InlineData("object detected")]
    [InlineData("1object")]
    [InlineData("")]
    public void A_kind_of_observation_is_a_few_lower_case_words_joined_by_dots(string kind)
    {
        using var f = Recording();
        Assert.Equal("bad-kind", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, kind))).Code);
    }

    [Theory]
    [InlineData("Maria Santos")]
    [InlineData("maria@example.com")]
    [InlineData("+91 98765 43210")]
    [InlineData("track:")]
    [InlineData("track:has space")]
    [InlineData("TRACK:1")]
    [InlineData("12345")]
    public void People_and_things_are_named_by_opaque_references_never_by_a_name_an_address_or_a_phone_number(string reference)
    {
        using var f = Recording();
        Assert.Equal("bad-ref", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, subject: reference))).Code);
        Assert.Equal("bad-ref", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, subject: reference))).Code);
        Assert.Equal("bad-ref", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, zone: reference))).Code);
        Assert.Equal(0, f.App.Events.Counts().Observations);
    }

    [Fact]
    public void Card_details_are_never_kept_in_any_part_of_a_record_and_a_kind_of_data_that_is_not_named_is_refused()
    {
        using var f = Recording();
        Assert.Equal("never-stored", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, dataClass: DataClass.PaymentSensitive))).Code);
        Assert.Equal("never-stored", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, dataClass: DataClass.PaymentSensitive))).Code);
        Assert.Equal("never-stored", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, data: "{\"note\":\"card 4111 1111 1111 1111\"}"))).Code);
        Assert.Equal("never-stored", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f) with { Label = "4111111111111111" })).Code);
        Assert.Equal("never-stored", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f) with { Explanation = "paid with 5500005555555559" })).Code);
        Assert.Equal("never-stored", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, evidence: [new EvidenceInput(EvidenceKind.Image, "file:/pay/4111111111111111.jpg", DataClass.Internal)]))).Code);
        Assert.Equal("bad-class", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, dataClass: "SECRET"))).Code);
        Assert.Equal(0, f.App.Events.Counts().Observations);
        Assert.Equal(0, f.App.Events.Counts().Confirmed);
    }

    [Theory]
    [InlineData(-0.1)]
    [InlineData(1.01)]
    [InlineData(double.NaN)]
    public void How_sure_the_system_is_must_be_between_nothing_and_certain(double confidence)
    {
        using var f = Recording();
        Assert.Equal("bad-confidence", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, confidence: confidence))).Code);
        Assert.Equal("bad-confidence", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, confidence: confidence))).Code);
    }

    [Fact]
    public void The_data_of_a_record_is_a_small_JSON_object_and_not_a_picture_or_a_long_text()
    {
        using var f = Recording();
        foreach (var bad in new[] { "[1,2]", "\"text\"", "{not json", "{\"a\":{\"b\":{\"c\":{\"d\":{\"e\":{\"f\":{\"g\":{\"h\":{\"i\":1}}}}}}}}}" })
            Assert.Equal("bad-json", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, data: bad))).Code);
        Assert.Equal("too-long", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, data: "{\"x\":\"" + new string('a', EventRules.MaxDataChars) + "\"}"))).Code);
        Assert.Null(f.App.Events.Observe(Seen(f, data: null)).DataJson);
        Assert.Null(f.App.Events.Observe(Seen(f, data: "  ")).DataJson);
    }

    [Fact]
    public void Nothing_can_have_happened_in_the_future_but_a_little_clock_difference_between_devices_is_allowed()
    {
        using var f = Recording();
        var now = f.Shop.Clock.UtcNow;
        Assert.Equal("bad-time", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f) with { OccurredAt = now.AddMinutes(30) })).Code);
        Assert.Equal("bad-time", Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f) with { OccurredAt = default })).Code);
        Assert.Equal(now.AddMinutes(2), f.App.Events.Observe(Seen(f) with { OccurredAt = now.AddMinutes(2) }).OccurredAt);
    }

    [Fact]
    public void Biometric_data_is_not_kept_at_all_unless_the_owner_chooses_how_long_and_card_details_can_never_be_chosen()
    {
        using var f = Recording();
        var refusal = Assert.Throws<HubException>(() => f.App.Events.Observe(Seen(f, dataClass: DataClass.Biometric)));
        Assert.Equal("not-kept", refusal.Code);
        Assert.Contains("Biometric", refusal.Message);
        Assert.Equal("not-kept", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, dataClass: DataClass.Biometric))).Code);

        f.App.Retention.Set(RetentionSubject.Observation, DataClass.Biometric, 2, 1);   // the owner's opt-in, for observations only
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(2), f.App.Events.Observe(Seen(f, dataClass: DataClass.Biometric)).RetainUntil);
        Assert.Equal("not-kept", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, dataClass: DataClass.Biometric))).Code);   // events were not opted in

        Assert.Equal("never-stored", Assert.Throws<HubException>(() => f.App.Retention.Set(RetentionSubject.Event, DataClass.PaymentSensitive, 30, 1)).Code);
        Assert.Null(f.App.Retention.Days(RetentionSubject.Event, DataClass.PaymentSensitive));
    }

    [Fact]
    public void An_event_keeps_who_did_what_where_and_when_how_sure_why_and_what_it_rests_on()
    {
        using var f = Recording();
        var o1 = f.App.Events.Observe(Seen(f));
        var o2 = f.App.Events.Observe(Seen(f, kind: "object.tracked"));
        var sha = new string('a', 64);
        var e = f.App.Events.Append(Fact(f, observations: [o1.Id, o2.Id, o1.Id], evidence: [new EvidenceInput(EvidenceKind.Image, "camera-1/2026/10/05/frame-0042.jpg", DataClass.Video, sha.ToUpperInvariant())]), userId: 7);

        Assert.Equal(1, e.Id);
        Assert.Equal(("customer_session.picked_up_product", "track:cam1:17", "track:cam1:17", "product:8901000000019", "zone:aisle-3"), (e.Type, e.ActorRef, e.SubjectRef, e.ObjectRef, e.ZoneRef));
        Assert.Equal((0.9, EventStatus.Confirmed, "rule", "pickup-rule", "1.0"), (e.Confidence, e.Status, e.MadeByType, e.MadeById, e.MadeByVersion));
        Assert.Equal(("visit-42", 7L, null), (e.CorrelationId, e.CreatedBy, e.Supersedes));
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(365), e.RetainUntil);

        var why = f.App.Events.Explain(e.Id);
        Assert.Equal(new[] { o1.Id, o2.Id }, why.Observations.Select(o => o.Id));   // a repeated observation is linked once
        var piece = Assert.Single(why.Evidence);
        Assert.Equal((EvidenceKind.Image, "camera-1/2026/10/05/frame-0042.jpg", sha, DataClass.Video), (piece.Kind, piece.Reference, piece.Sha256, piece.DataClass));
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(7), piece.RetainUntil);   // evidence of camera pictures: 7 days
        Assert.Equal("Made by an automatic rule 'pickup-rule' (version 1.0), 90% sure. A hand stayed at the shelf and the product left it. It rests on 2 observations and 1 piece of evidence.", why.Sentence);
    }

    [Fact]
    public void A_record_is_refused_whole_when_any_part_of_it_is_wrong_and_nothing_half_written_is_left()
    {
        using var f = Recording();
        var o = f.App.Events.Observe(Seen(f));
        Assert.Equal("no-observation", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, observations: [o.Id, 999]))).Code);
        Assert.Equal("bad-evidence", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, evidence: [new EvidenceInput("movie", "x", DataClass.Internal)]))).Code);
        Assert.Equal("bad-evidence", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, evidence: [new EvidenceInput(EvidenceKind.Image, "  ", DataClass.Internal)]))).Code);
        Assert.Equal("bad-hash", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, evidence: [new EvidenceInput(EvidenceKind.Image, "x", DataClass.Internal, "not-a-hash")]))).Code);
        Assert.Equal("too-many", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, evidence: Enumerable.Range(0, EventRules.MaxEvidencePerEvent + 1).Select(i => new EvidenceInput(EvidenceKind.Record, "r" + i, DataClass.Internal)).ToList()))).Code);
        Assert.Equal("bad-type", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, type: "Picked Up"))).Code);
        Assert.Equal("bad-type", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, type: "single"))).Code);
        Assert.Equal("bad-maker", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f) with { MadeByType = "magic" })).Code);
        Assert.Equal("bad-status", Assert.Throws<HubException>(() => f.App.Events.Append(Fact(f, status: EventStatus.Rejected))).Code);
        Assert.Equal(0, f.App.Events.Counts().Confirmed);
        Assert.Empty(f.App.Db.Query("SELECT 1 FROM event_evidence", r => 1));
        Assert.Empty(f.App.Db.Query("SELECT 1 FROM event_observations", r => 1));
    }

    [Fact]
    public void The_same_fact_sent_twice_with_the_same_key_is_kept_once()
    {
        using var f = Recording();
        var first = f.App.Events.Append(Fact(f, key: "device-9:msg-100"));
        var again = f.App.Events.Append(Fact(f, key: "device-9:msg-100", confidence: 0.1));
        var other = f.App.Events.Append(Fact(f, key: "device-9:msg-101"));
        var none1 = f.App.Events.Append(Fact(f));
        var none2 = f.App.Events.Append(Fact(f));

        Assert.Equal(first.Id, again.Id);
        Assert.Equal(0.9, again.Confidence);   // the first one stands
        Assert.NotEqual(first.Id, other.Id);
        Assert.NotEqual(none1.Id, none2.Id);   // without a key every event is its own
        Assert.Equal(4, f.App.Events.Counts().Confirmed);
    }

    [Fact]
    public void A_proposed_event_is_confirmed_or_rejected_by_a_person_with_the_change_written_down_and_a_final_state_stays_final()
    {
        using var f = Recording();
        var proposed = f.App.Events.Append(Fact(f, status: EventStatus.Proposed));
        Assert.Equal(1, f.App.Events.Counts().Proposed);

        Assert.Equal(EventStatus.Confirmed, f.App.Events.SetStatus(proposed.Id, EventStatus.Confirmed, 4, "I watched the clip").Status);
        Assert.Equal(EventStatus.Rejected, f.App.Events.SetStatus(proposed.Id, EventStatus.Rejected, 4, "it was the wrong shelf").Status);
        Assert.Equal("bad-move", Assert.Throws<HubException>(() => f.App.Events.SetStatus(proposed.Id, EventStatus.Confirmed, 4)).Code);
        Assert.Equal("bad-status", Assert.Throws<HubException>(() => f.App.Events.SetStatus(proposed.Id, EventStatus.Superseded, 4)).Code);
        Assert.Equal("bad-status", Assert.Throws<HubException>(() => f.App.Events.SetStatus(proposed.Id, "deleted", 4)).Code);
        Assert.Equal("no-event", Assert.Throws<HubException>(() => f.App.Events.SetStatus(404, EventStatus.Confirmed, 4)).Code);

        var changes = f.App.Audit.Recent().Where(a => a.Action == "events.status").Select(a => a.Detail).Reverse().ToList();
        Assert.Equal(new[] { "proposed -> confirmed (I watched the clip)", "confirmed -> rejected (it was the wrong shelf)" }, changes);
        Assert.Equal(f.Shop.Clock.UtcNow.AddSeconds(-3), f.App.Events.Get(proposed.Id)!.OccurredAt);   // nothing but the status changed
    }

    [Fact]
    public void A_wrong_event_is_replaced_by_a_correction_that_points_back_and_both_stay_in_the_history()
    {
        using var f = Recording();
        var wrong = f.App.Events.Append(Fact(f, type: "shelf.restocked"));
        var right = f.App.Events.Supersede(wrong.Id, Fact(f, type: "shelf.checked"), 5, "it was only looked at");

        Assert.Equal(wrong.Id, right.Supersedes);
        Assert.Equal(EventStatus.Superseded, f.App.Events.Get(wrong.Id)!.Status);
        Assert.Equal(EventStatus.Confirmed, right.Status);
        Assert.Equal("shelf.restocked", f.App.Events.Get(wrong.Id)!.Type);   // the old one is as it was
        Assert.Contains("It corrects event " + wrong.Id, f.App.Events.Explain(right.Id).Sentence);
        Assert.Contains("replaced by event " + right.Id, f.App.Events.Explain(wrong.Id).Sentence);
        Assert.Equal(right.Id, f.App.Events.Explain(wrong.Id).ReplacedBy!.Id);
        Assert.Equal(wrong.Id, f.App.Events.Explain(right.Id).Replaces!.Id);
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "events.supersede" && a.Detail!.Contains("it was only looked at"));

        // The old one cannot be replaced twice; the latest one can.
        Assert.Equal("bad-move", Assert.Throws<HubException>(() => f.App.Events.Supersede(wrong.Id, Fact(f), 5)).Code);
        var third = f.App.Events.Supersede(right.Id, Fact(f, type: "shelf.refilled"), 5);
        Assert.Equal(right.Id, third.Supersedes);
        // A replacement that is invalid changes nothing.
        Assert.Throws<HubException>(() => f.App.Events.Supersede(third.Id, Fact(f, type: "NOPE"), 5));
        Assert.Equal(EventStatus.Confirmed, f.App.Events.Get(third.Id)!.Status);
        Assert.Equal("no-event", Assert.Throws<HubException>(() => f.App.Events.Supersede(999, Fact(f), 5)).Code);
    }

    [Fact]
    public void Events_are_found_by_time_type_status_who_where_how_sure_and_visit_and_read_a_page_at_a_time_newest_first()
    {
        using var f = Recording();
        var now = f.Shop.Clock.UtcNow;
        var a = f.App.Events.Append(Fact(f, type: "customer_session.entered", ago: TimeSpan.FromHours(5), confidence: 0.5, subject: "track:cam1:1"));
        var b = f.App.Events.Append(Fact(f, type: "customer_session.picked_up_product", ago: TimeSpan.FromHours(3), subject: "track:cam1:2"));
        var c = f.App.Events.Append(Fact(f, type: "shelf.restocked", ago: TimeSpan.FromHours(1), status: EventStatus.Proposed));
        var d = f.App.Events.Append(Fact(f, type: "shelfxrestocked.done", ago: TimeSpan.FromMinutes(5)));

        Assert.Equal(new[] { d.Id, c.Id, b.Id, a.Id }, f.App.Events.Query(new EventQuery()).Select(e => e.Id));
        Assert.Equal(new[] { b.Id, a.Id }, f.App.Events.Query(new EventQuery(TypePrefix: "customer_session")).Select(e => e.Id));
        Assert.Equal(new[] { a.Id }, f.App.Events.Query(new EventQuery(TypePrefix: "customer_session.entered")).Select(e => e.Id));
        Assert.Equal(new[] { c.Id }, f.App.Events.Query(new EventQuery(Status: EventStatus.Proposed)).Select(e => e.Id));
        Assert.Equal(new[] { b.Id }, f.App.Events.Query(new EventQuery(SubjectRef: "track:cam1:2")).Select(e => e.Id));
        Assert.Equal(new[] { d.Id, c.Id, b.Id }, f.App.Events.Query(new EventQuery(MinConfidence: 0.8)).Select(e => e.Id));
        Assert.Equal(new[] { d.Id, c.Id }, f.App.Events.Query(new EventQuery(From: now.AddHours(-2))).Select(e => e.Id));
        Assert.Equal(new[] { b.Id, a.Id }, f.App.Events.Query(new EventQuery(To: now.AddHours(-2))).Select(e => e.Id));
        Assert.Equal(4, f.App.Events.Query(new EventQuery(ZoneRef: "zone:aisle-3")).Count);
        Assert.Equal(4, f.App.Events.Query(new EventQuery(CorrelationId: "visit-42")).Count);
        Assert.Empty(f.App.Events.Query(new EventQuery(CorrelationId: "visit-43")));
        // A typed underscore or percent sign is a letter, not a wildcard: "shelf_restocked" does not find "shelfxrestocked.done".
        Assert.Empty(f.App.Events.Query(new EventQuery(TypePrefix: "shelf_restocked")));
        Assert.Empty(f.App.Events.Query(new EventQuery(TypePrefix: "%")));
        // Pages.
        var page1 = f.App.Events.Query(new EventQuery(Limit: 2));
        var page2 = f.App.Events.Query(new EventQuery(Limit: 2, BeforeId: page1[^1].Id));
        Assert.Equal(new[] { d.Id, c.Id }, page1.Select(e => e.Id));
        Assert.Equal(new[] { b.Id, a.Id }, page2.Select(e => e.Id));
        Assert.Single(f.App.Events.Query(new EventQuery(Limit: 0)));
        Assert.Equal(4, f.App.Events.Query(new EventQuery(Limit: 100000)).Count);
    }

    [Fact]
    public void Observations_are_found_by_kind_source_zone_and_time()
    {
        using var f = Recording();
        var a = f.App.Events.Observe(Seen(f, "object.detected", ago: TimeSpan.FromHours(2)));
        var b = f.App.Events.Observe(Seen(f, "object.tracked", zone: "zone:till"));
        var c = f.App.Events.Observe(Seen(f, "sensor.temperature", zone: null) with { SourceType = SourceType.Sensor, SourceId = "fridge-2" });
        Assert.Equal(new[] { c.Id, b.Id, a.Id }, f.App.Events.QueryObservations(new ObservationQuery()).Select(o => o.Id));
        Assert.Equal(new[] { b.Id, a.Id }, f.App.Events.QueryObservations(new ObservationQuery(KindPrefix: "object")).Select(o => o.Id));
        Assert.Equal(new[] { c.Id }, f.App.Events.QueryObservations(new ObservationQuery(SourceId: "fridge-2")).Select(o => o.Id));
        Assert.Equal(new[] { b.Id }, f.App.Events.QueryObservations(new ObservationQuery(ZoneRef: "zone:till")).Select(o => o.Id));
        Assert.Equal(new[] { c.Id, b.Id }, f.App.Events.QueryObservations(new ObservationQuery(From: f.Shop.Clock.UtcNow.AddHours(-1))).Select(o => o.Id));
        Assert.Equal(new[] { a.Id }, f.App.Events.QueryObservations(new ObservationQuery(Limit: 1, BeforeId: b.Id)).Select(o => o.Id));
    }

    [Fact]
    public void The_counts_say_how_much_is_kept_and_over_what_time()
    {
        using var f = Recording();
        Assert.Equal(new EventCounts(0, 0, 0, 0, 0, null, null), f.App.Events.Counts());
        f.App.Events.Observe(Seen(f));
        f.App.Events.Append(Fact(f, ago: TimeSpan.FromDays(2)));
        f.App.Events.Append(Fact(f, status: EventStatus.Proposed));
        var rejected = f.App.Events.Append(Fact(f));
        f.App.Events.SetStatus(rejected.Id, EventStatus.Rejected, 1);
        var counts = f.App.Events.Counts();
        Assert.Equal((1L, 1L, 1L, 1L, 0L), (counts.Observations, counts.Proposed, counts.Confirmed, counts.Rejected, counts.Superseded));
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(-2), counts.OldestEvent);
    }

    [Fact]
    public void The_shops_own_work_does_not_write_to_the_event_history_even_when_it_is_switched_on()
    {
        // Phase 2 builds the store only. The sale below is the same sale as before; the history stays empty until a source is connected (Phase 3 and later).
        using var f = Recording();
        var item = f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Rice", PriceMinor = f.App.Shop.Current.Minor("118.00"), TaxClass = "standard", TrackStock = false });
        var sale = f.App.Documents.Checkout(new NextGenOS.Hub.Documents.CheckoutRequest
        {
            Lines = { new NextGenOS.Hub.Documents.LineInput { ItemId = item.Id, QtyMilli = 2000 } },
            Payments = { new NextGenOS.Hub.Documents.PaymentInput { Method = "cash", AmountMinor = 30_000 } },
        });
        Assert.Equal(23_600, sale.Document.TotalMinor);
        Assert.Equal(new EventCounts(0, 0, 0, 0, 0, null, null), f.App.Events.Counts());
    }

    [Fact]
    public void Event_types_are_shown_in_plain_words()
    {
        Assert.Equal("Customer session: picked up product", EventTypes.Label("customer_session.picked_up_product"));
        Assert.Equal("Shelf: restocked", EventTypes.Label("shelf.restocked"));
        Assert.Equal("Device: health low battery", EventTypes.Label("device.health.low_battery"));
        Assert.Equal("Sale", EventTypes.Label("sale"));
        Assert.Equal("", EventTypes.Label(""));
        foreach (var s in EventStatus.All) Assert.NotEqual(s, EventStatus.Label(s));
        foreach (var s in SourceType.All) Assert.NotEqual(s, SourceType.Label(s));
        foreach (var s in MadeBy.All) Assert.NotEqual(s, MadeBy.Label(s));
        foreach (var s in EvidenceKind.All) Assert.NotEqual(s, EvidenceKind.Label(s));
        foreach (var s in RetentionSubject.All) Assert.NotEqual(s, RetentionSubject.Label(s));
    }
}

public class RetentionTests
{
    private static AiFixture Recording()
    {
        var f = new AiFixture();
        f.Allow(FlagKey.EventEngine);
        return f;
    }

    private static ObservationInput Seen(AiFixture f, string dataClass = DataClass.Internal) => new("object.detected", SourceType.Model, "cam-1", dataClass, f.Shop.Clock.UtcNow, 0.8);

    private static EventInput Fact(AiFixture f, string dataClass = DataClass.Internal, IReadOnlyList<long>? observations = null, IReadOnlyList<EvidenceInput>? evidence = null) =>
        new("shelf.restocked", MadeBy.System, "hub", dataClass, f.Shop.Clock.UtcNow, ObservationIds: observations, Evidence: evidence);

    [Fact]
    public void What_is_private_is_kept_for_a_short_time_by_default_and_the_owner_can_change_every_rule()
    {
        using var f = Recording();
        var days = f.App.Retention;
        Assert.Equal(14, days.Days(RetentionSubject.Observation, DataClass.Internal));
        Assert.Equal(7, days.Days(RetentionSubject.Observation, DataClass.Personal));
        Assert.Equal(3, days.Days(RetentionSubject.Observation, DataClass.Video));
        Assert.Equal(3, days.Days(RetentionSubject.Observation, DataClass.Audio));
        Assert.Equal(365, days.Days(RetentionSubject.Event, DataClass.Financial));
        Assert.Equal(90, days.Days(RetentionSubject.Event, DataClass.Personal));
        Assert.Equal(7, days.Days(RetentionSubject.Evidence, DataClass.Video));
        Assert.Equal(30, days.Days(RetentionSubject.Evidence, DataClass.Internal));
        Assert.Null(days.Days(RetentionSubject.Observation, DataClass.Biometric));
        Assert.Null(days.Days(RetentionSubject.Event, DataClass.Biometric));
        Assert.Null(days.Days(RetentionSubject.Observation, DataClass.PaymentSensitive));
        Assert.Null(days.Days("nonsense", DataClass.Internal));
        Assert.Null(days.Days(RetentionSubject.Event, "nonsense"));

        days.Set(RetentionSubject.Observation, DataClass.Video, 30, 2);
        Assert.Equal(30, days.Days(RetentionSubject.Observation, DataClass.Video));
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(30), days.RetainUntil(RetentionSubject.Observation, DataClass.Video, f.Shop.Clock.UtcNow));
        var rule = days.Rules().Single(r => r.Subject == RetentionSubject.Observation && r.DataClass == DataClass.Video);
        Assert.Equal((30, false), (rule.Days, rule.IsDefault));
        Assert.True(days.Rules().Single(r => r.Subject == RetentionSubject.Observation && r.DataClass == DataClass.Audio).IsDefault);
        Assert.Equal(3 * 8, days.Rules().Count);   // every kind of record for every kind of data that can be kept (card details never)
        Assert.DoesNotContain(days.Rules(), r => r.DataClass == DataClass.PaymentSensitive);

        days.UseDefault(RetentionSubject.Observation, DataClass.Video, 2);
        Assert.Equal(3, days.Days(RetentionSubject.Observation, DataClass.Video));
        var written = f.App.Audit.Recent().Where(a => a.Action == "events.retention").Select(a => a.Detail).Reverse().ToList();
        Assert.Equal(new[] { "observation / VIDEO: 30 days", "observation / VIDEO: back to the default" }, written);
    }

    [Theory]
    [InlineData("nonsense", DataClass.Internal, 5, "bad-subject")]
    [InlineData(RetentionSubject.Event, "SECRET", 5, "bad-class")]
    [InlineData(RetentionSubject.Event, DataClass.PaymentSensitive, 5, "never-stored")]
    [InlineData(RetentionSubject.Event, DataClass.Internal, 0, "bad-days")]
    [InlineData(RetentionSubject.Event, DataClass.Internal, -3, "bad-days")]
    [InlineData(RetentionSubject.Event, DataClass.Internal, 4000, "bad-days")]
    public void A_retention_rule_must_make_sense(string subject, string dataClass, int days, string code)
    {
        using var f = Recording();
        Assert.Equal(code, Assert.Throws<HubException>(() => f.App.Retention.Set(subject, dataClass, days, 1)).Code);
    }

    [Fact]
    public void Forgetting_removes_only_what_is_past_its_day_with_its_links_and_evidence_and_says_what_it_removed()
    {
        using var f = Recording();
        var oldObservation = f.App.Events.Observe(Seen(f));                 // kept 14 days
        var youngObservation = f.App.Events.Observe(Seen(f, DataClass.Internal));
        var shortEvent = f.App.Events.Append(Fact(f, DataClass.Video, observations: [oldObservation.Id], evidence: [new EvidenceInput(EvidenceKind.Clip, "cam-1/clip-1.mp4", DataClass.Video)]));   // event 30 days, clip 7 days
        var longEvent = f.App.Events.Append(Fact(f, DataClass.Internal, observations: [youngObservation.Id], evidence: [new EvidenceInput(EvidenceKind.Image, "cam-1/pic-1.jpg", DataClass.Internal), new EvidenceInput(EvidenceKind.Clip, "cam-1/clip-2.mp4", DataClass.Video)]));

        Assert.False(f.App.Retention.Prune(1).Any);   // nothing is due yet
        f.Shop.Clock.Advance(TimeSpan.FromDays(8));   // the video clips are past their 7 days
        var first = f.App.Retention.Prune(1);
        Assert.Equal((0L, 0L, 2L), (first.Observations, first.Events, first.Evidence));
        Assert.Equal(new[] { "cam-1/clip-1.mp4", "cam-1/clip-2.mp4" }, first.EvidenceReferences.OrderBy(x => x));
        Assert.Equal(new[] { "cam-1/pic-1.jpg" }, f.App.Events.EvidenceOf(longEvent.Id).Select(e => e.Reference));

        f.Shop.Clock.Advance(TimeSpan.FromDays(10));  // 18 days: observations (14) are past it
        var second = f.App.Retention.Prune(1);
        Assert.Equal((2L, 0L, 0L), (second.Observations, second.Events, second.Evidence));
        Assert.NotNull(f.App.Events.Get(shortEvent.Id));
        Assert.Equal(1, f.App.Events.Explain(shortEvent.Id).ObservationsForgotten);
        Assert.Contains("1 observation it rested on has been forgotten", f.App.Events.Explain(shortEvent.Id).Sentence);

        f.Shop.Clock.Advance(TimeSpan.FromDays(15));  // 33 days: the video event (30) is past it, with everything attached
        var third = f.App.Retention.Prune(1);
        Assert.Equal((0L, 1L, 1L), (third.Observations, third.Events, third.Evidence));   // the event, and the picture that was past its own 30 days too
        Assert.Null(f.App.Events.Get(shortEvent.Id));
        Assert.NotNull(f.App.Events.Get(longEvent.Id));
        Assert.Empty(f.App.Db.Query("SELECT 1 FROM event_observations WHERE event_id = " + shortEvent.Id, r => 1));

        var forgotten = f.App.Audit.Recent().Where(a => a.Action == "events.forgotten").Select(a => a.Detail).Reverse().ToList();
        Assert.Equal(3, forgotten.Count);
        Assert.Equal("0 observations, 0 events, 2 pieces of evidence past their day", forgotten[0]);
        Assert.False(f.App.Retention.Prune(1).Any);
    }

    [Fact]
    public void Evidence_goes_with_its_event_and_its_pointer_is_given_back_so_the_file_can_be_deleted_too()
    {
        using var f = Recording();
        f.App.Retention.Set(RetentionSubject.Evidence, DataClass.Internal, 365, 1);   // the picture would live longer than its event
        f.App.Retention.Set(RetentionSubject.Event, DataClass.Internal, 2, 1);
        var e = f.App.Events.Append(Fact(f, evidence: [new EvidenceInput(EvidenceKind.Document, "scans/receipt-9.pdf", DataClass.Internal, new string('b', 64))]));
        f.Shop.Clock.Advance(TimeSpan.FromDays(3));
        var result = f.App.Retention.Prune(null);
        Assert.Equal((1L, 1L), (result.Events, result.Evidence));
        Assert.Equal(new[] { "scans/receipt-9.pdf" }, result.EvidenceReferences);
        Assert.Empty(f.App.Events.EvidenceOf(e.Id));
    }

    [Fact]
    public void Forgetting_goes_on_when_the_history_is_switched_off_and_even_when_the_licence_lapses()
    {
        using var f = Recording();
        f.App.Events.Observe(Seen(f));
        f.Ai.Flags.Set(FlagKey.EventEngine, false, 1);
        f.Entitled.Allowed = false;
        f.Shop.Clock.Advance(TimeSpan.FromDays(20));
        Assert.Equal(1L, f.App.Retention.Prune(null).Observations);
        Assert.Equal(0, f.App.Events.Counts().Observations);
    }

    [Fact]
    public void A_changed_rule_applies_to_new_records_and_what_was_kept_before_keeps_its_own_day()
    {
        using var f = Recording();
        var before = f.App.Events.Observe(Seen(f));
        f.App.Retention.Set(RetentionSubject.Observation, DataClass.Internal, 1, 1);
        var after = f.App.Events.Observe(Seen(f));
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(14), before.RetainUntil);
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(1), after.RetainUntil);
    }
}

/// <summary>The database steps are layered: each can be undone on its own, and the shop's data stays through all of them.</summary>
public class EventMigrationTests
{
    private static readonly string[] EventTables = ["event_evidence", "event_observations", "events", "observations", "retention_policies"];
    private static readonly string[] AiTables = ["ai_models", "ai_provider_consent", "ai_providers", "ai_usage", "feature_flags"];

    private static string[] Tables(HubApp app) => app.Db.Query("SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name", r => r.GetString(0)).ToArray();

    [Fact]
    public void The_event_tables_exist_each_with_tenant_and_site_and_the_AI_tables_are_still_there()
    {
        using var f = new HubFixture();
        Assert.Subset(Tables(f.App).ToHashSet(), EventTables.Concat(AiTables).ToHashSet());
        foreach (var table in EventTables)
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0));
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
        }

        Assert.Equal(new long[] { 1, 2, 3, 4 }, f.App.Db.Query("SELECT version FROM schema_version ORDER BY version", r => r.GetInt64(0)).ToArray());
    }

    [Fact]
    public void The_newest_step_can_be_undone_alone_and_leaves_the_AI_foundation_and_the_shop_in_place()
    {
        using var f = new HubFixture();
        f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 42500, TaxClass = "standard" });
        f.App.Db.Rollback(2);
        Assert.Empty(Tables(f.App).Intersect(EventTables));
        Assert.Subset(Tables(f.App).ToHashSet(), AiTables.ToHashSet());
        Assert.Equal(new long[] { 1, 2 }, f.App.Db.Query("SELECT version FROM schema_version ORDER BY version", r => r.GetInt64(0)).ToArray());
        Assert.Equal("Rice", f.App.Db.Scalar("SELECT name FROM items"));
        Assert.True(File.Exists(f.App.Db.LastBackup));

        var again = HubApp.Open(f.App.Db.Path, f.Clock);
        Assert.Subset(Tables(again).ToHashSet(), EventTables.ToHashSet());
    }

    [Fact]
    public void Undoing_both_steps_takes_the_database_back_to_the_shops_own_tables_and_a_forward_run_restores_both()
    {
        using var f = new HubFixture();
        f.App.Db.Rollback(1);
        Assert.Empty(Tables(f.App).Intersect(EventTables.Concat(AiTables)));
        var again = HubApp.Open(f.App.Db.Path, f.Clock);
        Assert.Subset(Tables(again).ToHashSet(), EventTables.Concat(AiTables).ToHashSet());
        Assert.Contains("before-update-1-to-4", again.Db.LastBackup);
    }
}

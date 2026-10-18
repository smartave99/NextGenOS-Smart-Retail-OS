using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Intelligence;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// "What is true now?" (Version 2, Phase 4, step 1): the state of one thing or place is worked out from the business event history at the moment of asking: the newest confirmed event,
/// the counts, how long it has been quiet. Corrections show at once, an earlier moment can be asked about, only the people who may open the history may ask, and nothing is ever written.
/// </summary>
public sealed class StateTests : IDisposable
{
    private readonly AiFixture f = new();

    public StateTests() => f.Allow(FlagKey.EventEngine);

    public void Dispose() => f.Dispose();

    private DateTimeOffset Now => f.Shop.Clock.UtcNow;

    private EventRecord Fact(string type, TimeSpan ago, string? subject = "item:12", string? zone = "zone:aisle-3", double confidence = 0.9, string status = EventStatus.Confirmed, string maker = MadeBy.Rule) =>
        f.App.Events.Append(new EventInput(type, maker, "rule-1", DataClass.Internal, Now - ago, confidence, "1.0", null, subject, null, zone, status, "Because the rule says so", "{\"secret\":\"do not show\"}"));

    // ---- the answer ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_thing_nothing_is_known_about_says_so_plainly()
    {
        var state = f.App.State.Of("item:404");
        Assert.False(state.Known);
        Assert.Null(state.Latest);
        Assert.Null(state.Quiet);
        Assert.Empty(state.ByType);
        Assert.Equal("The event history knows nothing about this.", state.Sentence);
    }

    [Fact]
    public void The_state_is_the_newest_confirmed_event_with_the_count_of_each_kind_and_how_long_it_has_been_quiet()
    {
        Fact("shelf.item_removed", TimeSpan.FromHours(5));
        Fact("shelf.item_removed", TimeSpan.FromHours(3));
        var newest = Fact("shelf.item_added", TimeSpan.FromMinutes(20), confidence: 0.75);

        var state = f.App.State.Of("item:12");

        Assert.True(state.Known);
        Assert.Equal(newest.Id, state.Latest!.Id);
        Assert.Equal(("shelf.item_added", 0.75, "rule", "rule-1", "zone:aisle-3"), (state.Latest.Type, state.Latest.Confidence, state.Latest.MadeByType, state.Latest.MadeById, state.Latest.ZoneRef));
        Assert.Equal(3, state.Confirmed);
        Assert.Equal(TimeSpan.FromMinutes(20), state.Quiet);
        Assert.Equal(Now - TimeSpan.FromHours(5), state.FirstHeardOf);
        Assert.Equal(new[] { ("shelf.item_added", 1L), ("shelf.item_removed", 2L) }, state.ByType.Select(t => (t.Type, t.Count)).ToArray());
        Assert.Equal("Newest confirmed event: 'Shelf: item added', 20 minutes ago (75% sure, made by an automatic rule). 3 events are confirmed in all.", state.Sentence);
    }

    [Fact]
    public void An_event_waiting_to_be_checked_is_counted_apart_and_never_decides_what_is_true()
    {
        var sure = Fact("shelf.item_removed", TimeSpan.FromHours(2));
        Fact("shelf.item_added", TimeSpan.FromMinutes(1), status: EventStatus.Proposed, confidence: 0.4);

        var state = f.App.State.Of("item:12");
        Assert.Equal(sure.Id, state.Latest!.Id);
        Assert.Equal((1, 1), (state.Confirmed, state.WaitingToBeChecked));
        Assert.EndsWith("1 more is waiting to be checked.", state.Sentence);

        var onlyGuess = f.App.State.Of("item:99");
        Assert.False(onlyGuess.Known);
        Fact("shelf.item_added", TimeSpan.FromMinutes(1), subject: "item:99", status: EventStatus.Proposed);
        onlyGuess = f.App.State.Of("item:99");
        Assert.True(onlyGuess.Known);
        Assert.Null(onlyGuess.Latest);
        Assert.Equal("Nothing is confirmed yet. 1 event is waiting to be checked.", onlyGuess.Sentence);
    }

    [Fact]
    public void A_correction_shows_at_once_a_wrong_event_and_a_replaced_event_are_left_out()
    {
        Fact("shelf.item_removed", TimeSpan.FromHours(4));
        var wrong = Fact("shelf.item_added", TimeSpan.FromHours(1));
        Assert.Equal(wrong.Id, f.App.State.Of("item:12").Latest!.Id);

        f.App.Events.SetStatus(wrong.Id, EventStatus.Rejected, 1, "the camera saw a reflection");
        var after = f.App.State.Of("item:12");
        Assert.Equal("shelf.item_removed", after.Latest!.Type);
        Assert.Equal(1, after.Confirmed);

        var replaced = Fact("shelf.item_added", TimeSpan.FromMinutes(30));
        var fixedOne = f.App.Events.Supersede(replaced.Id, new EventInput("shelf.item_moved", MadeBy.Person, "owner", DataClass.Internal, Now - TimeSpan.FromMinutes(30), 1, null, null, "item:12", null, "zone:aisle-3"), 1);
        var latest = f.App.State.Of("item:12");
        Assert.Equal(fixedOne.Id, latest.Latest!.Id);
        Assert.Equal(new[] { "shelf.item_moved", "shelf.item_removed" }, latest.ByType.Select(t => t.Type).ToArray());
        Assert.Equal(2, latest.Confirmed);
    }

    [Fact]
    public void An_earlier_moment_gives_the_state_then_and_ignores_what_happened_after()
    {
        var early = Fact("shelf.item_removed", TimeSpan.FromHours(6));
        Fact("shelf.item_added", TimeSpan.FromHours(2));
        Fact("shelf.item_removed", TimeSpan.FromMinutes(5));

        var then = f.App.State.Of("item:12", Now - TimeSpan.FromHours(4));
        Assert.Equal(early.Id, then.Latest!.Id);
        Assert.Equal(1, then.Confirmed);
        Assert.Equal(TimeSpan.FromHours(2), then.Quiet);   // quiet for the two hours before that moment, not until today
        Assert.Equal(Now - TimeSpan.FromHours(4), then.At);

        Assert.Equal(3, f.App.State.Of("item:12").Confirmed);
        Assert.Equal(3, f.App.State.Of("item:12", Now + TimeSpan.FromDays(3)).Confirmed);   // a moment that has not come is today
        Assert.False(f.App.State.Of("item:12", Now - TimeSpan.FromDays(2)).Known);
        Assert.Equal("bad-time", Assert.Throws<HubException>(() => f.App.State.Of("item:12", default(DateTimeOffset))).Code);
    }

    [Fact]
    public void A_place_has_its_own_state_from_the_events_that_happened_in_it()
    {
        Fact("shelf.item_removed", TimeSpan.FromHours(2), subject: "item:1", zone: "zone:entrance");
        var last = Fact("door.opened", TimeSpan.FromMinutes(3), subject: "device:door-1", zone: "zone:entrance");
        Fact("shelf.item_removed", TimeSpan.FromMinutes(1), subject: "item:2", zone: "zone:aisle-3");

        var entrance = f.App.State.OfZone("zone:entrance");
        Assert.Equal(last.Id, entrance.Latest!.Id);
        Assert.Equal(2, entrance.Confirmed);
        Assert.Equal("zone:entrance", entrance.Ref);
        Assert.False(f.App.State.Of("zone:entrance").Known);   // a place is not a thing: ask the right question
    }

    [Fact]
    public void The_answer_shows_the_kind_of_event_and_never_the_data_inside_it()
    {
        Fact("shelf.item_removed", TimeSpan.FromMinutes(1));
        var state = f.App.State.Of("item:12");
        var text = System.Text.Json.JsonSerializer.Serialize(state);
        Assert.DoesNotContain("do not show", text);
        Assert.DoesNotContain("Because the rule says so", text);
    }

    // ---- who is active ------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_things_that_were_active_lately_come_most_recent_first_and_a_prefix_narrows_them()
    {
        Fact("shelf.item_removed", TimeSpan.FromHours(30), subject: "item:old");
        Fact("shelf.item_removed", TimeSpan.FromHours(3), subject: "item:1");
        Fact("shelf.item_added", TimeSpan.FromHours(2), subject: "item:1");
        Fact("track.entered", TimeSpan.FromMinutes(10), subject: "track:cam1:17");
        Fact("shelf.item_removed", TimeSpan.FromMinutes(1), subject: "item:2", status: EventStatus.Proposed);
        Fact("shelf.item_removed", TimeSpan.FromMinutes(2), subject: "item:3");
        f.App.Events.SetStatus(f.App.Events.Query(new EventQuery(SubjectRef: "item:3")).Single().Id, EventStatus.Rejected, 1);

        var all = f.App.State.Active();
        Assert.Equal(new[] { "track:cam1:17", "item:1" }, all.Select(a => a.Ref).ToArray());   // the old, the guessed and the wrong ones are not there
        Assert.Equal(("shelf.item_added", 2L), (all[1].LastType, all[1].Events));
        Assert.Equal(Now - TimeSpan.FromMinutes(10), all[0].LastAt);

        Assert.Equal(new[] { "item:1" }, f.App.State.Active("item:").Select(a => a.Ref).ToArray());
        Assert.Equal(new[] { "item:old", "item:1" }.OrderBy(x => x).ToArray(), f.App.State.Active("item:", TimeSpan.FromDays(3)).Select(a => a.Ref).OrderBy(x => x).ToArray());
        Assert.Single(f.App.State.Active(limit: 1));
        Assert.Empty(f.App.State.Active("track:cam2:"));
    }

    [Theory]
    [InlineData("Maria")]
    [InlineData("maria@example.com")]
    [InlineData("ITEM:")]
    [InlineData("item: 1")]
    [InlineData("%")]
    public void Narrowing_by_a_name_or_a_wild_card_is_refused(string prefix) =>
        Assert.Equal("bad-ref", Assert.Throws<HubException>(() => f.App.State.Active(prefix)).Code);

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(400 * 24 * 60)]
    public void A_period_from_a_minute_to_a_year_is_allowed(int minutes) =>
        Assert.Equal("bad-window", Assert.Throws<HubException>(() => f.App.State.Active(within: TimeSpan.FromMinutes(minutes))).Code);

    [Fact]
    public void A_percent_sign_or_underscore_in_a_prefix_means_only_itself()
    {
        Fact("shelf.item_removed", TimeSpan.FromMinutes(1), subject: "item:a_b");
        Fact("shelf.item_removed", TimeSpan.FromMinutes(1), subject: "item:axb");
        Assert.Equal(new[] { "item:a_b" }, f.App.State.Active("item:a_").Select(a => a.Ref).ToArray());
    }

    [Theory]
    [InlineData("Maria Santos")]
    [InlineData("maria@example.com")]
    [InlineData("+91 98765 43210")]
    [InlineData("")]
    [InlineData("item:12' OR '1'='1")]
    public void A_thing_is_named_by_a_reference_never_by_a_name_an_address_a_phone_number_or_a_trick(string reference)
    {
        Assert.Equal("bad-ref", Assert.Throws<HubException>(() => f.App.State.Of(reference)).Code);
        Assert.Equal("bad-ref", Assert.Throws<HubException>(() => f.App.State.OfZone(reference)).Code);
    }

    // ---- the switches, the licence and the people ---------------------------------------------------------------------------------

    [Fact]
    public void What_was_kept_can_still_be_looked_at_after_the_history_is_switched_off_or_the_licence_ends()
    {
        Fact("shelf.item_removed", TimeSpan.FromMinutes(1));
        f.Entitled.Allowed = false;
        Assert.False(f.App.Events.Recording);
        Assert.Equal(1, f.App.State.Of("item:12").Confirmed);
        Assert.Single(f.App.State.Active());
    }

    [Fact]
    public void Asking_changes_nothing_no_event_no_observation_no_audit_line_no_setting()
    {
        Fact("shelf.item_removed", TimeSpan.FromMinutes(1));
        string Fingerprint() => string.Join("|", new[] { "events", "observations", "event_observations", "event_evidence", "audit_log", "feature_flags", "outbox" }
            .Select(t => t + "=" + f.App.Db.Scalar($"SELECT COUNT(*) FROM {t}")));
        var before = Fingerprint();
        f.App.State.Of("item:12");
        f.App.State.Of("item:12", Now - TimeSpan.FromHours(1));
        f.App.State.OfZone("zone:aisle-3");
        f.App.State.Active();
        Assert.Equal(before, Fingerprint());
    }

    [Fact]
    public void Only_the_people_who_may_open_the_event_history_may_ask_and_nobody_signed_in_is_refused()
    {
        var owner = f.App.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        var cashier = f.App.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        Fact("shelf.item_removed", TimeSpan.FromMinutes(1));
        var strict = f.OpenStrict();

        using (strict.Access.As(owner))
        {
            Assert.Equal(1, strict.State.Of("item:12").Confirmed);
            Assert.Single(strict.State.Active());
        }

        using (strict.Access.As(cashier))
        {
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.State.Of("item:12")).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.State.OfZone("zone:aisle-3")).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.State.Active()).Code);
        }

        using (strict.Access.As(null as long?))
        {
            Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.State.Of("item:12")).Code);
        }
    }

    // ---- the index step -----------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_question_about_one_thing_reads_through_the_new_index_and_not_the_whole_history()
    {
        var plan = string.Join(" ", f.App.Db.Query(
            "EXPLAIN QUERY PLAN SELECT id FROM events WHERE tenant_id = 'local' AND site_id = 'main' AND subject_ref = 'item:12' AND occurred_at <= '2030' AND status = 'confirmed' ORDER BY occurred_at DESC, id DESC LIMIT 1",
            r => r.GetString(3)));
        Assert.Contains("ix_events_subject", plan);
        var zonePlan = string.Join(" ", f.App.Db.Query(
            "EXPLAIN QUERY PLAN SELECT id FROM events WHERE tenant_id = 'local' AND site_id = 'main' AND zone_ref = 'zone:aisle-3' AND occurred_at <= '2030'", r => r.GetString(3)));
        Assert.Contains("ix_events_zone", zonePlan);
    }

    [Fact]
    public void The_step_can_be_undone_and_keeps_every_event_and_a_forward_run_makes_the_indexes_again()
    {
        var kept = Fact("shelf.item_removed", TimeSpan.FromMinutes(1));
        f.App.Db.Rollback(27);   // back to before the indexes (and before any later step)

        var names = f.App.Db.Query("SELECT name FROM sqlite_master WHERE type = 'index'", r => r.GetString(0)).ToHashSet();
        Assert.DoesNotContain("ix_events_subject", names);
        Assert.DoesNotContain("ix_events_zone", names);
        Assert.Contains("ix_events_time", names);   // the older indexes stay
        Assert.Equal(kept.Id, Convert.ToInt64(f.App.Db.Scalar("SELECT id FROM events")));
        Assert.True(File.Exists(f.App.Db.LastBackup));

        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Shop.Clock);
        var back = again.Db.Query("SELECT name FROM sqlite_master WHERE type = 'index'", r => r.GetString(0)).ToHashSet();
        Assert.Contains("ix_events_subject", back);
        Assert.Contains("ix_events_zone", back);
        Assert.Equal(kept.Id, Convert.ToInt64(again.Db.Scalar("SELECT id FROM events")));
    }

    [Theory]
    [InlineData(0, "just now")]
    [InlineData(59, "just now")]
    [InlineData(60, "1 minute ago")]
    [InlineData(120, "2 minutes ago")]
    [InlineData(3_600, "1 hour ago")]
    [InlineData(3 * 3_600, "3 hours ago")]
    [InlineData(86_400, "1 day ago")]
    [InlineData(5 * 86_400, "5 days ago")]
    public void Time_is_said_in_plain_words(int seconds, string expected) => Assert.Equal(expected, StateService.Ago(TimeSpan.FromSeconds(seconds)));
}

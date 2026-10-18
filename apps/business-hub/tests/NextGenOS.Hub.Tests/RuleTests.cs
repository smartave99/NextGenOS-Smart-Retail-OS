using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Intelligence;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Automatic rules over the business event history (Version 2, Phase 4, step 2). A rule is data in a fixed shape and can only propose an event for a person to check; it starts switched off,
/// looks only at events recorded after it was switched on, fires once for one trigger, never fires on what rules made, and runs only while the licence and both switches allow it.
/// </summary>
public sealed class RuleTests : IDisposable
{
    private readonly AiFixture f = new();

    public RuleTests() => f.Allow(FlagKey.EventEngine, FlagKey.AdvancedRules);

    public void Dispose() => f.Dispose();

    private DateTimeOffset Now => f.Shop.Clock.UtcNow;

    /// <summary>A confirmed event that happened <paramref name="ago"/> before the clock's now. The clock is not moved, so its record time is now.</summary>
    private EventRecord Door(TimeSpan ago, string type = "door.opened", string? subject = "device:door-1", string? zone = "zone:back", double confidence = 0.9, string status = EventStatus.Confirmed,
        string maker = MadeBy.Model, string dataClass = DataClass.Internal) =>
        f.App.Events.Append(new EventInput(type, maker, "door-model", dataClass, Now - ago, confidence, "1.0", null, subject, null, zone, status, null, "{\"secret\":\"do not show\"}"));

    private static RuleInput Input(string name = "Door forced", string prefix = "door.opened", double min = 0.6, int count = 3, int window = 10, string group = RuleGroup.Subject,
        string then = "alert.door_forced", double confidence = 0.7, string? explanation = "Check the door.") => new(name, prefix, min, count, window, group, then, confidence, explanation);

    /// <summary>A rule that is made and switched on, as the owner does.</summary>
    private EventRule Armed(RuleInput? input = null)
    {
        var rule = f.App.Rules.Create(input ?? Input(), 1);
        return f.App.Rules.SetEnabled(rule.Id, true, 1);
    }

    private IReadOnlyList<EventRecord> Proposals(string type = "alert.door_forced") => f.App.Events.Query(new EventQuery(TypePrefix: type, Limit: 100));

    // ---- the shape of a rule --------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_rule_starts_switched_off_and_says_what_it_does_in_plain_words()
    {
        var rule = f.App.Rules.Create(Input(), 1);
        Assert.False(rule.Enabled);
        Assert.Equal(1, rule.Version);
        Assert.Null(rule.CheckedUntil);
        Assert.Equal("When 3 or more confirmed events starting with 'door.opened' (each at least 60% sure) happen about the same thing within 10 minutes, propose 'Alert: door forced' for a person to check.", rule.Sentence);
        Assert.Equal("When a confirmed event starting with 'shelf' (at least 0% sure) happens anywhere within 2 hours, propose 'Alert: low' for a person to check.",
            f.App.Rules.Create(Input(prefix: "shelf", min: 0, count: 1, window: 120, group: RuleGroup.All, then: "alert.low"), 1).Sentence);
        Assert.Contains("within 1 day,", f.App.Rules.Create(Input(window: 1440), 1).Sentence);
        Assert.Contains("within 3 days,", f.App.Rules.Create(Input(window: 4320), 1).Sentence);
    }

    [Fact]
    public void A_rule_that_is_switched_on_looks_only_at_events_recorded_after_that_moment()
    {
        var rule = f.App.Rules.Create(Input(count: 2), 1);
        Door(TimeSpan.FromMinutes(2));
        Door(TimeSpan.FromMinutes(1));   // two events already in the history before the rule is switched on

        f.Shop.Clock.Advance(TimeSpan.FromSeconds(30));
        var armed = f.App.Rules.SetEnabled(rule.Id, true, 1);
        Assert.Equal(Now, armed.CheckedUntil);
        Assert.Equal(new RuleRunResult(1, 0, 0, 0), f.App.Rules.Run());
        Assert.Empty(Proposals());

        f.Shop.Clock.Advance(TimeSpan.FromSeconds(30));
        Door(TimeSpan.FromSeconds(20));
        Door(TimeSpan.FromSeconds(10));
        var run = f.App.Rules.Run();
        Assert.Equal(1, run.Proposed);
        Assert.Single(Proposals());
    }

    // ---- what a rule produces -------------------------------------------------------------------------------------------------------

    [Fact]
    public void Enough_events_about_the_same_thing_within_the_time_make_one_proposed_event_that_says_why()
    {
        Armed();
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(5));
        var first = Door(TimeSpan.FromMinutes(6));
        Door(TimeSpan.FromMinutes(4));
        Assert.Equal(new RuleRunResult(1, 2, 0, 0), f.App.Rules.Run());   // two are not enough
        var last = Door(TimeSpan.FromMinutes(1));

        var run = f.App.Rules.Run();
        Assert.Equal(1, run.Proposed);
        var made = Assert.Single(Proposals());
        Assert.Equal(("alert.door_forced", EventStatus.Proposed, MadeBy.Rule, "rule-1", "v1", 0.7), (made.Type, made.Status, made.MadeByType, made.MadeById, made.MadeByVersion, made.Confidence));
        Assert.Equal(("device:door-1", "zone:back", DataClass.Internal, "rule-1"), (made.SubjectRef, made.ZoneRef, made.DataClass, made.CorrelationId));
        Assert.Equal(last.OccurredAt, made.OccurredAt);
        Assert.Contains("Rule 'Door forced': 3 confirmed events starting with 'door.opened' about the same thing (device:door-1) within 10 minutes. Check the door.", made.Explanation);
        using var data = System.Text.Json.JsonDocument.Parse(made.DataJson!);
        Assert.Equal((1, 1, 3), (data.RootElement.GetProperty("rule").GetInt32(), data.RootElement.GetProperty("version").GetInt32(), data.RootElement.GetProperty("count").GetInt32()));
        Assert.Equal(3, data.RootElement.GetProperty("triggers").GetArrayLength());
        Assert.DoesNotContain("do not show", made.DataJson);   // the data of the events that triggered it is not copied
        var why = f.App.Events.Explain(made.Id);
        Assert.StartsWith("Made by an automatic rule 'rule-1' (version v1), 70% sure.", why.Sentence);
        Assert.EndsWith("It is waiting for a person to check it.", why.Sentence);
        Assert.NotEqual(first.Id, made.Id);
    }

    [Fact]
    public void Nothing_a_rule_makes_is_confirmed_and_a_person_decides()
    {
        Armed(Input(count: 1));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(1));
        f.App.Rules.Run();
        var made = Assert.Single(Proposals());
        Assert.Equal(EventStatus.Proposed, made.Status);
        Assert.Equal(1, f.App.Events.Counts().Confirmed);   // the only confirmed event is the door's own
        var confirmed = f.App.Events.SetStatus(made.Id, EventStatus.Confirmed, 1, "yes, the door was forced");
        Assert.Equal(EventStatus.Confirmed, confirmed.Status);
    }

    [Fact]
    public void Running_again_never_proposes_the_same_trigger_twice_not_even_after_the_program_is_opened_again()
    {
        Armed();
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(3));
        Door(TimeSpan.FromMinutes(2));
        Door(TimeSpan.FromMinutes(1));
        Assert.Equal(1, f.App.Rules.Run().Proposed);
        Assert.Equal(0, f.App.Rules.Run().Proposed);

        var reopened = f.Reopen();
        using (reopened.Access.AsSystem()) Assert.Equal(0, reopened.Rules.Run().Proposed);
        Assert.Single(Proposals());
    }

    [Fact]
    public void A_trigger_that_was_looked_at_but_whose_firing_was_lost_still_does_not_make_a_second_proposal()
    {
        Armed();
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(3));
        Door(TimeSpan.FromMinutes(2));
        Door(TimeSpan.FromMinutes(1));
        f.App.Rules.Run();
        f.App.Db.InTransaction((c, t) => HubDb.Exec(c, "DELETE FROM event_rule_firings", t));   // the program stopped between writing the proposal and writing the note
        f.App.Db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE event_rules SET checkpoint_at = $at, checkpoint_id = 0", t, ("$at", Iso.Text(Now - TimeSpan.FromMinutes(5)))));
        f.App.Rules.Run();
        Assert.Single(Proposals());   // the event history keeps one event for one trigger
        Assert.Equal(1L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM event_rule_firings")));
    }

    [Fact]
    public void Events_further_apart_than_the_time_are_not_counted_together()
    {
        Armed(Input(window: 10));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(40));
        Door(TimeSpan.FromMinutes(25));
        Door(TimeSpan.FromMinutes(1));
        Assert.Equal(0, f.App.Rules.Run().Proposed);
    }

    [Fact]
    public void Events_that_are_not_sure_enough_wrong_waiting_or_of_another_kind_are_not_counted()
    {
        Armed();
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(7), confidence: 0.3);                              // not sure enough
        Door(TimeSpan.FromMinutes(6), status: EventStatus.Proposed);                  // only a guess
        Door(TimeSpan.FromMinutes(5), type: "door.closed");                           // another kind
        var wrong = Door(TimeSpan.FromMinutes(4));
        f.App.Events.SetStatus(wrong.Id, EventStatus.Rejected, 1);                    // it was wrong
        Door(TimeSpan.FromMinutes(2));
        Door(TimeSpan.FromMinutes(1));                                                // two good ones: one short of three
        Assert.Equal(0, f.App.Rules.Run().Proposed);
        Door(TimeSpan.FromSeconds(30));                                               // and now three good ones
        Assert.Equal(1, f.App.Rules.Run().Proposed);
    }

    [Fact]
    public void Events_are_counted_together_only_as_the_rule_says_the_same_thing_the_same_place_or_anywhere()
    {
        var bySubject = Armed(Input(name: "by thing", group: RuleGroup.Subject, then: "alert.thing"));
        var byZone = Armed(Input(name: "by place", group: RuleGroup.Zone, then: "alert.place"));
        var anywhere = Armed(Input(name: "anywhere", group: RuleGroup.All, then: "alert.anywhere"));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(3), subject: "device:door-1", zone: "zone:back");
        Door(TimeSpan.FromMinutes(2), subject: "device:door-2", zone: "zone:back");
        Door(TimeSpan.FromMinutes(1), subject: "device:door-3", zone: "zone:front");

        f.App.Rules.Run();
        Assert.Empty(Proposals("alert.thing"));      // three different doors
        Assert.Empty(Proposals("alert.place"));      // two in one place, one in another
        Assert.Single(Proposals("alert.anywhere"));
        Assert.NotEqual(bySubject.Id, byZone.Id);
        Assert.NotEqual(byZone.Id, anywhere.Id);

        Door(TimeSpan.FromSeconds(30), subject: "device:door-4", zone: "zone:back");
        f.App.Rules.Run();
        var place = Assert.Single(Proposals("alert.place"));
        Assert.Equal(("zone:back", null), (place.ZoneRef, place.SubjectRef));
    }

    [Fact]
    public void An_event_with_nothing_to_group_by_is_skipped_for_a_rule_that_groups_by_it()
    {
        Armed(Input(count: 1, group: RuleGroup.Subject));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(1), subject: null);
        Assert.Equal(new RuleRunResult(1, 1, 0, 0), f.App.Rules.Run());
        Assert.Empty(Proposals());
    }

    [Fact]
    public void The_same_thing_does_not_fire_again_within_the_time_but_does_once_the_time_has_passed()
    {
        Armed(Input(count: 2, window: 10));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(4));
        Door(TimeSpan.FromMinutes(3));
        f.App.Rules.Run();
        Assert.Single(Proposals());

        Door(TimeSpan.FromMinutes(2));   // another, a minute later: still the same burst
        Door(TimeSpan.FromMinutes(1));
        f.App.Rules.Run();
        Assert.Single(Proposals());

        f.Shop.Clock.Advance(TimeSpan.FromMinutes(30));
        Door(TimeSpan.FromMinutes(2));
        Door(TimeSpan.FromMinutes(1));
        f.App.Rules.Run();
        Assert.Equal(2, Proposals().Count);
    }

    [Fact]
    public void What_rules_make_is_never_counted_by_rules_even_once_a_person_has_confirmed_it()
    {
        Armed(Input(name: "first", prefix: "door.opened", count: 1, then: "door.alert"));
        Armed(Input(name: "broad", prefix: "door", count: 3, group: RuleGroup.All, then: "boss.told"));   // 'door' also starts the type of what the first rule makes
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(3));
        f.App.Rules.Run();
        var alert = Assert.Single(Proposals("door.alert"));
        f.App.Events.SetStatus(alert.Id, EventStatus.Confirmed, 1);   // a person says yes
        Door(TimeSpan.FromMinutes(2));
        f.App.Rules.Run();
        Assert.Empty(Proposals("boss.told"));   // two doors and one confirmed alert are not three doors
        Door(TimeSpan.FromMinutes(1));
        f.App.Rules.Run();
        Assert.Single(Proposals("boss.told"));  // three doors are
    }

    [Fact]
    public void An_event_that_a_person_confirms_later_counts_in_later_windows_but_does_not_start_a_trigger_by_itself()
    {
        Armed(Input(count: 2));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromMinutes(3));
        var guess = Door(TimeSpan.FromMinutes(2), status: EventStatus.Proposed);
        f.App.Rules.Run();                                           // the guess is not counted and has been passed by
        f.App.Events.SetStatus(guess.Id, EventStatus.Confirmed, 1);
        f.App.Rules.Run();
        Assert.Empty(Proposals());                                   // nothing started: only a new event starts a trigger
        Door(TimeSpan.FromMinutes(1));
        f.App.Rules.Run();
        Assert.Single(Proposals());                                  // and then the confirmed one counts with it
    }

    [Fact]
    public void A_proposal_has_the_same_kind_of_data_as_the_events_that_caused_it()
    {
        Armed(Input(count: 1, then: "alert.person_seen"));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(10), dataClass: DataClass.Personal);
        f.App.Rules.Run();
        Assert.Equal(DataClass.Personal, Assert.Single(Proposals("alert.person_seen")).DataClass);
    }

    [Fact]
    public void A_trigger_whose_data_may_not_be_kept_is_remembered_and_counted_as_skipped_and_never_tried_again_for_ever()
    {
        f.App.Retention.Set(RetentionSubject.Event, DataClass.Biometric, 5, 1);   // the owner chose to keep biometric events for 5 days
        Armed(Input(count: 1, then: "alert.face_seen"));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(10), dataClass: DataClass.Biometric);
        f.App.Retention.UseDefault(RetentionSubject.Event, DataClass.Biometric, 1);   // and then withdrew it, so the proposal may not be kept
        var run = f.App.Rules.Run();
        Assert.Equal((0, 1), (run.Proposed, run.Skipped));
        Assert.Equal((0, 0), (f.App.Rules.Run().Proposed, f.App.Rules.Run().Skipped));
        Assert.Empty(Proposals("alert.face_seen"));
    }

    [Fact]
    public void A_burst_of_more_events_than_one_pass_reads_is_worked_through_and_none_is_read_twice()
    {
        Armed(Input(count: 1000, window: 60));   // never fires: only the reading is under test
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        for (var i = 0; i < RuleService.MaxLookedAtPerRule + 20; i++) Door(TimeSpan.FromSeconds(1), subject: "device:door-" + i);
        Assert.Equal(RuleService.MaxLookedAtPerRule, f.App.Rules.Run().Looked);
        Assert.Equal(20, f.App.Rules.Run().Looked);
        Assert.Equal(0, f.App.Rules.Run().Looked);
    }

    // ---- the switches ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Nothing_runs_while_the_rules_switch_the_history_switch_or_the_licence_is_off_and_no_rule_loses_its_place()
    {
        var rule = Armed(Input(count: 1));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(10));

        f.Ai.Flags.Set(FlagKey.AdvancedRules, false, 1);
        Assert.False(f.App.Rules.Running);
        Assert.Equal(RuleRunResult.Nothing, f.App.Rules.Run());
        f.Ai.Flags.Set(FlagKey.AdvancedRules, true, 1);

        f.Entitled.Allowed = false;
        Assert.Equal(RuleRunResult.Nothing, f.App.Rules.Run());
        f.Entitled.Allowed = true;

        Assert.Empty(Proposals());
        Assert.Equal(rule.CheckedUntil, f.App.Rules.Get(rule.Id)!.CheckedUntil);   // it has not moved on
        Assert.Equal(1, f.App.Rules.Run().Proposed);                                 // and it picks up what happened meanwhile
    }

    [Fact]
    public void Without_the_licence_a_rule_cannot_be_switched_on_but_can_be_switched_off()
    {
        var rule = Armed();
        f.Entitled.Allowed = false;
        Assert.Equal("not-licensed", Assert.Throws<HubException>(() => f.App.Rules.SetEnabled(f.App.Rules.Create(Input(name: "another"), 1).Id, true, 1)).Code);
        Assert.False(f.App.Rules.SetEnabled(rule.Id, false, 1).Enabled);
    }

    [Fact]
    public void The_shops_upkeep_runs_the_rules()
    {
        Armed(Input(count: 1));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(10));
        f.App.Upkeep();
        Assert.Single(Proposals());
    }

    // ---- changing, switching, retiring ----------------------------------------------------------------------------------------------

    [Fact]
    public void Changing_a_rule_makes_a_new_version_switches_it_off_and_keeps_what_it_proposed()
    {
        var rule = Armed(Input(count: 1));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(10));
        f.App.Rules.Run();
        var before = Assert.Single(Proposals());

        var changed = f.App.Rules.Update(rule.Id, Input(count: 2, name: "Door forced twice"), 1);
        Assert.Equal((2, false, "Door forced twice", 2), (changed.Version, changed.Enabled, changed.Name, changed.Count));
        Assert.Null(changed.CheckedUntil);
        Door(TimeSpan.FromSeconds(5));
        Door(TimeSpan.FromSeconds(4));
        Assert.Equal(RuleRunResult.Nothing, f.App.Rules.Run());   // switched off until a person says otherwise

        f.App.Rules.SetEnabled(rule.Id, true, 1);
        Assert.Equal("v1", f.App.Events.Get(before.Id)!.MadeByVersion);   // the old proposal still says which version made it
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(3));
        Door(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(1));
        f.App.Rules.Run();
        Assert.Equal("v2", Proposals().First().MadeByVersion);
    }

    [Fact]
    public void A_retired_rule_stays_on_record_never_runs_and_cannot_be_changed_or_switched_on()
    {
        var rule = Armed(Input(count: 1));
        f.App.Rules.Retire(rule.Id, 1);
        Assert.Empty(f.App.Rules.List());
        var kept = Assert.Single(f.App.Rules.List(includeRetired: true));
        Assert.True(kept.Retired);
        Assert.False(kept.Enabled);
        Assert.Equal("retired", Assert.Throws<HubException>(() => f.App.Rules.SetEnabled(rule.Id, true, 1)).Code);
        Assert.Equal("retired", Assert.Throws<HubException>(() => f.App.Rules.Update(rule.Id, Input(), 1)).Code);
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(1));
        Assert.Equal(RuleRunResult.Nothing, f.App.Rules.Run());
        f.App.Rules.Retire(rule.Id, 1);   // again: nothing happens
    }

    [Fact]
    public void There_are_at_most_fifty_rules_in_use_and_retiring_one_makes_room()
    {
        for (var i = 0; i < RuleService.MaxRules; i++) f.App.Rules.Create(Input(name: "rule " + i), 1);
        Assert.Equal("too-many", Assert.Throws<HubException>(() => f.App.Rules.Create(Input(name: "one more"), 1)).Code);
        f.App.Rules.Retire(1, 1);
        f.App.Rules.Create(Input(name: "one more"), 1);
        Assert.Equal(RuleService.MaxRules, f.App.Rules.List().Count);
    }

    [Fact]
    public void Every_change_to_a_rule_is_written_in_the_audit_record_with_who_made_it()
    {
        var rule = f.App.Rules.Create(Input(), 7);
        f.App.Rules.SetEnabled(rule.Id, true, 7);
        f.App.Rules.Update(rule.Id, Input(name: "Door forced v2"), 7);
        f.App.Rules.Retire(rule.Id, 7);
        var lines = f.App.Audit.Recent(20).Where(a => a.Action.StartsWith("rules.", StringComparison.Ordinal)).Reverse().ToList();
        Assert.Equal(new[] { "rules.create", "rules.switch", "rules.update", "rules.retire" }, lines.Select(l => l.Action).ToArray());
        Assert.All(lines, l => Assert.Equal(7, l.UserId));
        Assert.Contains("propose 'alert.door_forced'", lines[0].Detail);
    }

    // ---- what a rule may say --------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData("name", "")]
    [InlineData("name", "   ")]
    [InlineData("name", "bad\u0007name")]
    [InlineData("prefix", "")]
    [InlineData("prefix", "Door")]
    [InlineData("prefix", "door..opened")]
    [InlineData("prefix", "door.")]
    [InlineData("prefix", "door opened")]
    [InlineData("prefix", "a.b.c.d.e.f")]
    [InlineData("then", "alert")]
    [InlineData("then", "Alert.Forced")]
    [InlineData("then", "alert forced")]
    [InlineData("group", "everything")]
    [InlineData("group", "")]
    [InlineData("explanation", "paid with 4111 1111 1111 1111")]
    public void A_rule_with_a_part_that_is_not_allowed_is_refused_and_nothing_is_made(string part, string value)
    {
        var input = part switch
        {
            "name" => Input(name: value), "prefix" => Input(prefix: value), "then" => Input(then: value), "group" => Input(group: value), _ => Input(explanation: value),
        };
        Assert.Throws<HubException>(() => f.App.Rules.Create(input, 1));
        Assert.Empty(f.App.Rules.List(includeRetired: true));
    }

    [Theory]
    [InlineData(-0.1, 1, 10, 0.7)]
    [InlineData(1.1, 1, 10, 0.7)]
    [InlineData(double.NaN, 1, 10, 0.7)]
    [InlineData(0.5, 0, 10, 0.7)]
    [InlineData(0.5, 1001, 10, 0.7)]
    [InlineData(0.5, 1, 0, 0.7)]
    [InlineData(0.5, 1, 10081, 0.7)]
    [InlineData(0.5, 1, 10, -1)]
    [InlineData(0.5, 1, 10, 2)]
    [InlineData(0.5, 1, 10, double.NaN)]
    public void The_numbers_of_a_rule_must_be_sensible(double min, int count, int window, double confidence) =>
        Assert.Throws<HubException>(() => f.App.Rules.Create(Input(min: min, count: count, window: window, confidence: confidence), 1));

    [Fact]
    public void The_edges_of_what_is_allowed_are_allowed()
    {
        f.App.Rules.Create(Input(name: "edge", prefix: "a", min: 0, count: 1, window: 1, then: "alert.x", confidence: 0), 1);
        f.App.Rules.Create(Input(name: "edge 2", prefix: "a.b.c.d.e", min: 1, count: 1000, window: 10080, then: "alert.x", confidence: 1, explanation: null), 1);
        Assert.Equal(2, f.App.Rules.List().Count);
    }

    [Fact]
    public void A_wild_card_in_the_start_of_a_type_means_only_itself()
    {
        Assert.Throws<HubException>(() => f.App.Rules.Create(Input(prefix: "door%"), 1));
        Armed(Input(prefix: "do_r", count: 1));   // an underscore is a letter of the type, not "any one letter"
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(10));
        Assert.Equal(new RuleRunResult(1, 0, 0, 0), f.App.Rules.Run());
    }

    // ---- who may ----------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Only_the_people_who_may_use_the_AI_helpers_may_see_or_change_rules_and_nobody_signed_in_is_refused()
    {
        var owner = f.App.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        var cashier = f.App.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        var rule = f.App.Rules.Create(Input(), owner);
        var strict = f.OpenStrict();

        using (strict.Access.As(owner))
        {
            Assert.Single(strict.Rules.List());
            Assert.True(strict.Rules.SetEnabled(rule.Id, true, owner).Enabled);
            strict.Rules.Run();
        }

        using (strict.Access.As(cashier))
        {
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Rules.List()).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Rules.Get(rule.Id)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Rules.Create(Input(), cashier)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Rules.Update(rule.Id, Input(), cashier)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Rules.SetEnabled(rule.Id, false, cashier)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Rules.Retire(rule.Id, cashier)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Rules.Run()).Code);
        }

        using (strict.Access.As(null as long?)) Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Rules.List()).Code);
    }

    // ---- the database step -------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_step_can_be_undone_alone_and_keeps_every_event_and_proposal_and_a_forward_run_makes_the_tables_again()
    {
        Armed(Input(count: 1));
        f.Shop.Clock.Advance(TimeSpan.FromSeconds(2));
        Door(TimeSpan.FromSeconds(10));
        f.App.Rules.Run();
        var events = Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM events"));
        Assert.Equal(2, events);

        f.App.Db.Rollback(28);
        var names = f.App.Db.Query("SELECT name FROM sqlite_master", r => r.GetString(0)).ToHashSet();
        Assert.DoesNotContain("event_rules", names);
        Assert.DoesNotContain("event_rule_firings", names);
        Assert.DoesNotContain("ix_rule_firings_group", names);
        Assert.Contains("ix_events_subject", names);   // the step before stays
        Assert.Equal(events, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM events")));
        Assert.True(File.Exists(f.App.Db.LastBackup));

        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Shop.Clock, null, null);
        Assert.Equal(0L, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM event_rules")));
        Assert.Equal(events, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM events")));
    }

    [Fact]
    public void The_new_tables_carry_the_tenant_and_the_site()
    {
        foreach (var table in new[] { "event_rules", "event_rule_firings" })
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0));
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
        }
    }
}

using System.Text.Json;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Cameras;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// How a camera program on this computer tells the Hub what it saw (Version 2, Phase 7, step 2): a key for each camera that is shown once and kept only as a fingerprint; nothing kept unless the
/// owner switched on cameras, the event history and that camera; only what the camera is set to look for and only if it is sure enough; a strict message in which no picture, face or name fits;
/// a limit on how much a camera can send; and what is kept is plain counts, written as video-derived data.
/// </summary>
public sealed class CameraIntakeTests : IDisposable
{
    private readonly AiFixture f = new();
    private readonly long owner, manager, cashier;
    private HubApp? strict;
    private readonly long door;     // a camera that is on, looks for people and trolleys, at least 60 percent sure, at "zone:entrance"

    public CameraIntakeTests()
    {
        f.Allow(FlagKey.CameraAnalytics, FlagKey.EventEngine);
        owner = f.App.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        manager = f.App.Users.Create("mia", "Mia Manager", Roles.Manager, "manager good password").Id;
        cashier = f.App.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        door = SwitchedOn("Front door", "USB Camera", "zone:entrance").Id;
    }

    public void Dispose() => f.Dispose();

    private HubApp S => strict ??= f.OpenStrict();

    private CameraIntakeService I => f.App.CameraIntake;

    private static string Code(Action act) => Assert.Throws<HubException>(act).Code;

    private Camera SwitchedOn(string name, string usb, string? zone, string[]? classes = null, int confidence = 60)
    {
        var camera = f.App.Cameras.Register(new CameraInput(name, CameraKind.Usb, usb, zone, classes ?? [CameraClass.Person, CameraClass.Cart], confidence), owner);
        f.App.Cameras.TestAsync(camera.Id, owner).GetAwaiter().GetResult();   // a camera plugged into this computer "cannot be checked from here", which is what lets it be switched on
        return f.App.Cameras.SetEnabled(camera.Id, true, owner);
    }

    private static string Message(params string[] observations) => "{\"model\":\"stand-in\",\"version\":\"1.0\",\"observations\":[" + string.Join(",", observations) + "]}";

    private static string Seen(string cls = "person", double confidence = 0.9, int? count = null, string? at = null) =>
        "{\"class\":\"" + cls + "\",\"confidence\":" + confidence.ToString(System.Globalization.CultureInfo.InvariantCulture) + (count is null ? "" : ",\"count\":" + count) + (at is null ? "" : ",\"at\":\"" + at + "\"") + "}";

    /// <summary>The secret part of a key, after "ngc-&lt;number&gt;-" (it can itself hold dashes).</summary>
    private string Secret(string key, long camera) => key.Substring("ngc-".Length + camera.ToString(System.Globalization.CultureInfo.InvariantCulture).Length + 1);

    private IReadOnlyList<ObservationRecord> Stored() => f.App.Events.QueryObservations(new ObservationQuery(Limit: 500));

    // ---- the key -------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Only_the_owner_may_make_remove_or_list_keys_and_nobody_signed_out_may()
    {
        foreach (var person in new[] { manager, cashier })
        {
            using var scope = S.Access.As(person);
            Assert.Equal("forbidden", Code(() => S.CameraIntake.MakeKey(door, person)));
            Assert.Equal("forbidden", Code(() => S.CameraIntake.RemoveKey(door, person)));
            Assert.Equal("forbidden", Code(() => S.CameraIntake.Keys()));
        }

        using (S.Access.As(null as long?)) Assert.Equal("not-signed-in", Code(() => S.CameraIntake.MakeKey(door, null)));
        using (S.Access.As(owner)) Assert.NotEmpty(S.CameraIntake.MakeKey(door, owner));
    }

    [Fact]
    public void A_key_is_shown_once_only_its_fingerprint_is_kept_and_a_new_key_ends_the_old_one()
    {
        var first = I.MakeKey(door, owner);
        Assert.Matches(@"^ngc-" + door + @"-[A-Za-z0-9_\-]{43}$", first);
        var row = f.App.Db.Query("SELECT key_hash FROM camera_intake_keys", r => r.GetString(0)).Single();
        Assert.Matches("^[0-9a-f]{64}$", row);
        Assert.DoesNotContain(first, row);
        // Nowhere in the shop's file, the activity list or what the screen is given is the key itself.
        var everywhere = string.Join("\n", new[] { "camera_intake_keys", "audit_log", "cameras" }.SelectMany(t => f.App.Db.Query($"SELECT * FROM {t}",
            r => string.Join("|", Enumerable.Range(0, r.FieldCount).Select(i => r.IsDBNull(i) ? "" : Convert.ToString(r.GetValue(i), System.Globalization.CultureInfo.InvariantCulture))))));
        Assert.DoesNotContain(Secret(first, door), everywhere);
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "camera.key" && a.Detail == "Front door");
        Assert.DoesNotContain(I.Keys().Select(k => k.ToString()), text => text!.Contains(first, StringComparison.Ordinal));

        Assert.Equal(1, I.AcceptJson(first, Message(Seen())).Accepted);
        var second = I.MakeKey(door, owner);
        Assert.NotEqual(first, second);
        Assert.Equal("bad-key", Code(() => I.AcceptJson(first, Message(Seen()))));
        Assert.Equal(1, I.AcceptJson(second, Message(Seen())).Accepted);
        Assert.Single(I.Keys());
        Assert.Equal((1L, 0L), (I.Keys().Single().Accepted, I.Keys().Single().Rejected));   // the counters start again with a new key
    }

    [Fact]
    public void A_key_is_made_only_while_cameras_are_on_and_for_a_camera_that_exists_and_was_not_retired()
    {
        Assert.Equal("no-camera", Code(() => I.MakeKey(999, owner)));
        var old = f.App.Cameras.Register(new CameraInput("Old", CameraKind.Usb, "USB Old", null, [CameraClass.Person]), owner);
        f.App.Cameras.Retire(old.Id, owner);
        Assert.Equal("retired", Code(() => I.MakeKey(old.Id, owner)));

        f.Ai.Flags.Set(FlagKey.CameraAnalytics, false, owner);
        Assert.Equal("cameras-off", Code(() => I.MakeKey(door, owner)));
        Assert.Empty(I.Keys());
    }

    [Fact]
    public void Removing_a_key_refuses_the_camera_program_that_had_it_and_retiring_a_camera_deletes_its_key()
    {
        var key = I.MakeKey(door, owner);
        I.RemoveKey(door, owner);
        I.RemoveKey(door, owner);   // twice is harmless
        Assert.Equal("bad-key", Code(() => I.AcceptJson(key, Message(Seen()))));
        Assert.Empty(I.Keys());
        Assert.Single(f.App.Audit.Recent(), a => a.Action == "camera.key-removed");

        var second = SwitchedOn("Back room", "USB Back", null);
        var secondKey = I.MakeKey(second.Id, owner);
        Assert.Equal(1, I.AcceptJson(secondKey, Message(Seen())).Accepted);
        f.App.Cameras.Retire(second.Id, owner);
        Assert.Equal("bad-key", Code(() => I.AcceptJson(secondKey, Message(Seen()))));
        Assert.Empty(I.Keys());
    }

    // ---- who is speaking ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_wrong_or_missing_key_gets_one_answer_that_says_nothing_about_which_part_was_wrong_and_before_the_message_is_read()
    {
        var key = I.MakeKey(door, owner);
        var secret = Secret(key, door);
        var wrong = new List<string?>
        {
            null, "", " ", "x", "ngc-", key + "x", key[..^1], key[..^1] + (key[^1] == 'A' ? 'B' : 'A'), "ngc-" + door + "-" + new string('A', 43), "ngc-" + (door + 1) + "-" + secret,
            "ngc-0-" + secret, "ngc-99999999999-" + secret, "NGC-" + door + "-" + secret, "Bearer " + key, key.ToUpperInvariant(), new string('a', 5000), key + "\n", "ngc-" + door + "-" + secret[..42] + "!",
        };
        var answers = wrong.Select(k => Assert.Throws<HubException>(() => I.AcceptJson(k, "this is not even json")));
        Assert.All(answers, e => Assert.Equal("bad-key", e.Code));
        Assert.Single(answers.Select(e => e.Message).Distinct());   // the same words every time
        Assert.Equal("bad-key", Code(() => I.Accept(null, null)));
        Assert.Empty(Stored());

        // With everything switched off a wrong key still learns nothing about it, and a right key is told.
        f.Ai.Flags.Set(FlagKey.CameraAnalytics, false, owner);
        Assert.Equal("bad-key", Code(() => I.AcceptJson("ngc-" + door + "-" + new string('A', 43), Message(Seen()))));
        Assert.Equal("cameras-off", Code(() => I.AcceptJson(key, Message(Seen()))));
    }

    [Fact]
    public void The_key_of_one_camera_only_speaks_for_that_camera()
    {
        var other = SwitchedOn("Aisle", "USB Aisle", "zone:aisle-3");
        var keyA = I.MakeKey(door, owner);
        var keyB = I.MakeKey(other.Id, owner);

        Assert.Equal(1, I.AcceptJson(keyA, Message(Seen())).Accepted);
        Assert.Equal(1, I.AcceptJson(keyB, Message(Seen("cart"))).Accepted);

        var bySource = Stored().GroupBy(o => o.SourceId).ToDictionary(g => g.Key, g => g.Single());
        Assert.Equal(("zone:entrance", "person"), (bySource["camera:front-door"].ZoneRef, bySource["camera:front-door"].Label));
        Assert.Equal(("zone:aisle-3", "cart"), (bySource["camera:aisle"].ZoneRef, bySource["camera:aisle"].Label));
        // A key with the digits of the other camera's number but its own secret is not accepted for that camera.
        Assert.Equal("bad-key", Code(() => I.AcceptJson("ngc-" + other.Id + "-" + Secret(keyA, door), Message(Seen()))));
    }

    // ---- what the owner switched on ----------------------------------------------------------------------------------------------------

    [Fact]
    public void Nothing_is_kept_unless_the_licence_cameras_the_event_history_and_that_camera_are_all_on()
    {
        var key = I.MakeKey(door, owner);
        Assert.Equal(1, I.AcceptJson(key, Message(Seen())).Accepted);

        f.Ai.Flags.Set(FlagKey.EventEngine, false, owner);
        Assert.Equal("events-off", Code(() => I.AcceptJson(key, Message(Seen()))));
        f.Ai.Flags.Set(FlagKey.EventEngine, true, owner);

        f.App.Cameras.SetEnabled(door, false, owner);
        Assert.Equal("camera-off", Code(() => I.AcceptJson(key, Message(Seen()))));
        f.App.Cameras.SetEnabled(door, true, owner);

        f.Ai.Flags.Set(FlagKey.CameraAnalytics, false, owner);
        Assert.Equal("cameras-off", Code(() => I.AcceptJson(key, Message(Seen()))));
        f.Ai.Flags.Set(FlagKey.CameraAnalytics, true, owner);

        f.Entitled.Allowed = false;
        Assert.Equal("not-licensed", Code(() => I.AcceptJson(key, Message(Seen()))));
        f.Entitled.Allowed = true;

        Assert.Single(Stored());   // only the first one, before anything was switched off
        Assert.Equal(2, I.AcceptJson(key, Message(Seen(), Seen("cart"))).Accepted);
        Assert.Equal(3, Stored().Count);
    }

    // ---- what is kept --------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void What_passes_is_written_as_plain_counts_with_the_cameras_place_the_senders_model_and_the_video_class()
    {
        var key = I.MakeKey(door, owner);
        var at = "2026-10-05T06:25:30Z";

        var result = I.AcceptJson(key, Message(Seen("person", 0.83, count: 3, at: at), Seen("cart", 0.61)));

        Assert.Equal(2, result.Accepted);
        Assert.Empty(result.Rejected);
        var kept = Stored().OrderBy(o => o.Id).ToList();
        var first = kept[0];
        Assert.Equal(("object.detected", "model", "camera:front-door", "stand-in", "1.0", "zone:entrance", "person", 0.83, "VIDEO"),
            (first.Kind, first.SourceType, first.SourceId, first.ModelId, first.ModelVersion, first.ZoneRef, first.Label, first.Confidence, first.DataClass));
        Assert.Equal(new DateTimeOffset(2026, 10, 5, 6, 25, 30, TimeSpan.Zero), first.OccurredAt);
        Assert.Null(first.SubjectRef);
        using (var data = JsonDocument.Parse(first.DataJson!))
        {
            Assert.Equal(["class", "count"], data.RootElement.EnumerateObject().Select(p => p.Name).ToArray());
            Assert.Equal(("person", 3), (data.RootElement.GetProperty("class").GetString(), data.RootElement.GetProperty("count").GetInt32()));
        }

        Assert.Equal(f.Shop.Clock.UtcNow, kept[1].OccurredAt);   // no time sent: now
        Assert.Contains("\"count\":1", kept[1].DataJson);
        // Camera video is kept only briefly (the event history's own rule for video-derived data).
        Assert.Equal(f.Shop.Clock.UtcNow.AddDays(3), first.RetainUntil);
        var info = I.Keys().Single();
        Assert.Equal((2L, 0L, f.Shop.Clock.UtcNow), (info.Accepted, info.Rejected, info.LastUsedAt!.Value));
    }

    [Fact]
    public void An_observation_is_kept_only_for_what_the_camera_is_set_to_look_for_and_only_if_the_program_was_sure_enough()
    {
        var key = I.MakeKey(door, owner);

        var result = I.AcceptJson(key, Message(
            Seen("person", 0.9),              // 0 kept
            Seen("basket", 0.9),              // 1 not set to look for baskets
            Seen("face", 0.99),               // 2 never
            Seen("person", 0.59),             // 3 less sure than 60 percent
            Seen("person", 0.6),              // 4 exactly as sure as asked: kept
            Seen("person", 1.5),              // 5 not a fraction
            Seen("person", -0.1),             // 6
            Seen("person", 0.9, count: 0),    // 7
            Seen("person", 0.9, count: 1001), // 8
            Seen("cart", 0.9, count: 1000)));  // 9 kept

        Assert.Equal(3, result.Accepted);
        Assert.Equal([1, 2, 3, 5, 6, 7, 8], result.Rejected.Select(r => r.Index).ToArray());
        var why = result.Rejected.ToDictionary(r => r.Index, r => r.Reason);
        Assert.Equal("'basket' is not something this camera is set to look for.", why[1]);
        Assert.Equal("'face' is not something this camera is set to look for.", why[2]);
        Assert.Contains("less sure than this camera's setting (at least 60 percent)", why[3]);
        Assert.Contains("number from 0 to 1", why[5]);
        Assert.Contains("number from 0 to 1", why[6]);
        Assert.Contains("from 1 to 1000", why[7]);
        Assert.Contains("from 1 to 1000", why[8]);
        Assert.Equal(["cart", "person", "person"], Stored().OrderBy(o => o.Id).Select(o => o.Label).Order().ToArray());
        var info = I.Keys().Single();
        Assert.Equal((3L, 7L), (info.Accepted, info.Rejected));
    }

    [Fact]
    public void A_time_in_the_message_must_be_recent_and_not_in_the_future()
    {
        var key = I.MakeKey(door, owner);
        var now = f.Shop.Clock.UtcNow;

        var result = I.AcceptJson(key, Message(
            Seen(at: now.AddMinutes(-59).ToString("o")),     // 0 kept
            Seen(at: now.AddHours(-2).ToString("o")),        // 1 too old
            Seen(at: now.AddMinutes(30).ToString("o")),      // 2 in the future
            Seen(at: now.AddSeconds(-5).ToString("yyyy-MM-ddTHH:mm:ss"))));  // 3 no time zone

        Assert.Equal(1, result.Accepted);
        Assert.Equal([1, 2, 3], result.Rejected.Select(r => r.Index).ToArray());
        Assert.Contains("too old", result.Rejected[0].Reason);
        Assert.Contains("future", result.Rejected[1].Reason);
        Assert.Contains("time zone", result.Rejected[2].Reason);
    }

    [Fact]
    public void The_message_is_strict_so_that_no_picture_face_name_place_or_track_can_be_sent()
    {
        var key = I.MakeKey(door, owner);
        foreach (var extra in new[] { "image", "face", "embedding", "name", "track", "zone", "box", "frame", "plate", "age", "gender", "customer", "x y", "a\u0001b" })
        {
            var one = "{\"class\":\"person\",\"confidence\":0.9," + JsonSerializer.Serialize(extra) + ":\"anything\"}";
            var result = I.AcceptJson(key, Message(one, Seen()));
            Assert.Equal(1, result.Accepted);                       // the good one next to it is kept
            Assert.Equal([0], result.Rejected.Select(r => r.Index).ToArray());
            Assert.Contains("Only class, count, confidence and at are accepted", result.Rejected[0].Reason);
            Assert.DoesNotContain("anything", result.Rejected[0].Reason);
        }

        // A weird name is not repeated back.
        Assert.Contains("(unreadable name)", I.AcceptJson(key, Message("{\"class\":\"person\",\"confidence\":0.9,\"a b\":1}")).Rejected[0].Reason);
        // Nothing sent in is in what was kept except the class, the count and the model (a test cannot put a face in by a side door).
        Assert.All(Stored(), o => Assert.Null(o.SubjectRef));
        Assert.All(Stored(), o => Assert.Equal(["class", "count"], JsonDocument.Parse(o.DataJson!).RootElement.EnumerateObject().Select(p => p.Name).ToArray()));

        // Parts of the whole message that are not on its short list refuse the whole message.
        foreach (var extra in new[] { "image", "camera", "zone", "key", "frames" })
            Assert.Equal("bad-batch", Code(() => I.AcceptJson(key, "{\"observations\":[" + Seen() + "],\"" + extra + "\":1}")));
    }

    [Fact]
    public void A_message_that_cannot_be_read_or_is_too_big_is_refused_whole_and_nothing_is_kept()
    {
        var key = I.MakeKey(door, owner);
        var bad = new[]
        {
            "", "   ", "not json", "[]", "\"text\"", "{}", "{\"observations\":{}}", "{\"observations\":[]}", "{\"observations\":\"x\"}", "{\"model\":5,\"observations\":[" + Seen() + "]}",
            "{\"version\":[1],\"observations\":[" + Seen() + "]}", "{\"observations\":[" + string.Join(",", Enumerable.Repeat(Seen(), IntakeBatch.MaxDetections + 1)) + "]}",
            "{\"observations\":[[[[[[1]]]]]]}", new string(' ', IntakeBatch.MaxChars + 1),
        };
        foreach (var message in bad) Assert.Equal("bad-batch", Code(() => I.AcceptJson(key, message)));
        Assert.Empty(Stored());

        // A part of an observation of the wrong type refuses that observation only.
        var wrongTypes = I.AcceptJson(key, Message("{\"class\":5,\"confidence\":0.9}", "{\"class\":\"person\",\"confidence\":\"high\"}", "{\"class\":\"person\",\"confidence\":0.9,\"count\":1.5}",
            "{\"class\":\"person\",\"confidence\":0.9,\"at\":7}", "[1]", "null", Seen()));
        Assert.Equal(1, wrongTypes.Accepted);
        Assert.Equal([0, 1, 2, 3, 4, 5], wrongTypes.Rejected.Select(r => r.Index).ToArray());
        Assert.Equal(IntakeBatch.MaxDetections, IntakeBatch.Parse(Message(Enumerable.Repeat(Seen(), IntakeBatch.MaxDetections).ToArray())).Detections.Count);
    }

    [Fact]
    public void A_model_name_or_version_that_is_not_a_plain_reference_refuses_the_whole_message()
    {
        var key = I.MakeKey(door, owner);
        foreach (var model in new[] { "my model!", "a b", "<script>", new string('m', 81) })
            Assert.Equal("bad-id", Code(() => I.AcceptJson(key, "{\"model\":\"" + model + "\",\"observations\":[" + Seen() + "]}")));
        Assert.Equal("bad-id", Code(() => I.AcceptJson(key, "{\"version\":\"1 0\",\"observations\":[" + Seen() + "]}")));
        Assert.Equal(1, I.AcceptJson(key, "{\"observations\":[" + Seen() + "]}").Accepted);   // both are optional
        Assert.Empty(Stored().Where(o => o.ModelId is not null));
    }

    // ---- not too fast ------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_camera_can_send_at_most_six_hundred_observations_a_minute_unless_the_owner_changes_that_here()
    {
        Assert.Equal(600, CameraIntakeService.DefaultMaxPerMinute);
        Assert.Equal(600, I.MaxPerMinute);
    }

    [Fact]
    public void A_message_that_would_go_over_a_cameras_limit_in_a_minute_is_refused_whole_and_the_limit_starts_again_a_minute_later()
    {
        I.MaxPerMinute = 30;
        var key = I.MakeKey(door, owner);
        var ten = Message(Enumerable.Repeat(Seen(), 10).ToArray());
        for (var i = 0; i < 3; i++) Assert.Equal(10, I.AcceptJson(key, ten).Accepted);
        Assert.Equal(30L, f.App.Events.Counts().Observations);

        Assert.Equal("too-fast", Code(() => I.AcceptJson(key, Message(Seen()))));
        Assert.Equal(30L, f.App.Events.Counts().Observations);   // nothing of the refused message was kept

        f.Shop.Clock.Advance(TimeSpan.FromSeconds(61));
        Assert.Equal(1, I.AcceptJson(key, Message(Seen())).Accepted);
        Assert.Equal(31L, f.App.Events.Counts().Observations);
    }

    [Fact]
    public void The_limit_is_for_each_camera_and_a_new_key_starts_it_again()
    {
        I.MaxPerMinute = 10;
        var other = SwitchedOn("Aisle", "USB Aisle", null);
        var key = I.MakeKey(door, owner);
        var keyOther = I.MakeKey(other.Id, owner);
        Assert.Equal(10, I.AcceptJson(key, Message(Enumerable.Repeat(Seen(), 10).ToArray())).Accepted);

        Assert.Equal("too-fast", Code(() => I.AcceptJson(key, Message(Seen()))));
        Assert.Equal(1, I.AcceptJson(keyOther, Message(Seen())).Accepted);
        Assert.Equal(1, I.AcceptJson(I.MakeKey(door, owner), Message(Seen())).Accepted);
    }

    // ---- the database step ------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_new_table_carries_the_tenant_and_the_site_and_has_no_place_for_the_key_or_a_picture()
    {
        var columns = f.App.Db.Query("SELECT name FROM pragma_table_info('camera_intake_keys')", r => r.GetString(0));
        Assert.Contains("tenant_id", columns);
        Assert.Contains("site_id", columns);
        Assert.DoesNotContain(columns, c => c is "key" or "secret" or "token" || c.Contains("image", StringComparison.OrdinalIgnoreCase) || c.Contains("frame", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void The_step_can_be_undone_alone_and_the_cameras_and_what_was_already_written_are_untouched()
    {
        var key = I.MakeKey(door, owner);
        I.AcceptJson(key, Message(Seen()));
        f.App.Db.Rollback(32);
        var names = f.App.Db.Query("SELECT name FROM sqlite_master", r => r.GetString(0)).ToHashSet();
        Assert.DoesNotContain("camera_intake_keys", names);
        Assert.Contains("cameras", names);                                  // the step before stays
        Assert.Equal(1L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM cameras")));
        Assert.Equal(1L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM observations")));   // what the camera program already sent stays in the event history
        Assert.True(File.Exists(f.App.Db.LastBackup));

        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Shop.Clock, null, null);
        Assert.Equal(0L, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM camera_intake_keys")));   // a new key has to be made
        Assert.Equal(1L, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM cameras")));
    }
}

using NextGenOS.Hub.Counters;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Pairing a counter PC: the one-time code, the token, the licence's number of PCs, removal, and every way of being refused (a wrong, old, used or flooded code; a made-up or removed token).
/// </summary>
public class StoreNetworkPairingTests
{
    private sealed class Store : IDisposable
    {
        private readonly HubFixture _fixture = new();
        public int Limit;
        public bool Accepting = true;
        public long OwnerId;

        public Store(int limit = 0)
        {
            Limit = limit;
            OwnerId = App.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
            Pairing = new PairingService(App.Db, Clock, App.Audit, App.Access, () => Limit, () => Accepting);
        }

        public PairingService Pairing { get; }
        public FixedClock Clock => _fixture.Clock;
        public HubApp App => _fixture.App;

        public PairedCounter Pair(string name, string address = "192.168.1.30")
        {
            var code = Pairing.NewCode(OwnerId);
            return Pairing.Redeem(code.Code, name, address);
        }

        public long Rows(string sql) => Convert.ToInt64(App.Db.Scalar(sql));

        public string[] Actions() => App.Audit.Recent(500).Select(a => a.Action).ToArray();

        public void Dispose() => _fixture.Dispose();
    }

    private static string CodeOf(NewPairingCode code) => code.Code;

    private static string Refusal(Action what) => Assert.Throws<HubException>(what).Code;

    // ---- making a code -----------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_code_is_short_easy_to_read_runs_out_after_ten_minutes_and_is_not_kept_in_readable_form()
    {
        using var s = new Store();
        var code = s.Pairing.NewCode(s.OwnerId);

        Assert.Matches("^[A-HJKMNP-Z2-9]{4}-[A-HJKMNP-Z2-9]{4}$", code.Code);
        Assert.Equal(s.Clock.UtcNow.AddMinutes(10), code.ExpiresAt);
        // Only a salted hash is in the database: neither the code, nor its letters in a row, appear anywhere in the row.
        var row = s.App.Db.Query("SELECT code_hash || '|' || salt || '|' || created_at || '|' || expires_at FROM network_pairing_codes", r => r.GetString(0)).Single();
        Assert.DoesNotContain(code.Code.Replace("-", ""), row);
        Assert.DoesNotContain(code.Code, row);
        Assert.Equal(64, s.App.Db.Query("SELECT length(code_hash) FROM network_pairing_codes", r => r.GetInt32(0)).Single());
        Assert.Contains("network.code", s.Actions());
        Assert.Equal(code.ExpiresAt, s.Pairing.WaitingCodeRunsOutAt());
    }

    [Fact]
    public void Codes_are_different_every_time_and_use_only_letters_and_digits_that_cannot_be_misread()
    {
        using var s = new Store();
        var codes = Enumerable.Range(0, 200).Select(_ => s.Pairing.NewCode(s.OwnerId).Code).ToList();
        Assert.True(codes.Distinct().Count() > 195);
        Assert.All(codes, c => Assert.Matches("^[A-HJKMNP-Z2-9]{4}-[A-HJKMNP-Z2-9]{4}$", c));   // no I, L, O, 0 or 1
    }

    [Fact]
    public void A_new_code_replaces_the_old_one()
    {
        using var s = new Store();
        var first = s.Pairing.NewCode(s.OwnerId);
        var second = s.Pairing.NewCode(s.OwnerId);
        Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem(first.Code, "Counter 1", "192.168.1.31")));
        Assert.Equal("Counter 1", s.Pairing.Redeem(second.Code, "Counter 1", "192.168.1.31").Counter.Name);
    }

    [Fact]
    public void No_code_can_be_made_and_none_redeemed_while_counter_PCs_are_not_switched_on()
    {
        using var s = new Store { Accepting = false };
        Assert.Equal("network-off", Refusal(() => s.Pairing.NewCode(s.OwnerId)));
        Assert.Equal("network-off", Refusal(() => s.Pairing.Redeem("ABCD-EFGH", "Counter 2", "192.168.1.31")));
        Assert.Equal(0, s.Rows("SELECT COUNT(*) FROM network_pairing_codes"));
    }

    // ---- pairing -----------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_counter_PC_that_gives_the_code_and_a_name_gets_a_long_token_of_which_only_a_hash_is_kept()
    {
        using var s = new Store();
        var code = s.Pairing.NewCode(s.OwnerId);
        var paired = s.Pairing.Redeem(code.Code, "  Counter 2  ", "192.168.1.31");

        Assert.Equal("Counter 2", paired.Counter.Name);
        Assert.True(paired.Counter.Active);
        Assert.Equal(s.Clock.UtcNow, paired.Counter.PairedAt);
        Assert.Equal("192.168.1.31", paired.Counter.LastAddress);
        Assert.Matches(@"^\d+\.[A-Za-z0-9_-]{43}$", paired.Token);   // number, then 256 bits of randomness
        var secret = paired.Token[(paired.Token.IndexOf('.') + 1)..];
        var row = s.App.Db.Query("SELECT token_hash || '|' || name || '|' || COALESCE(last_address, '') FROM network_devices", r => r.GetString(0)).Single();
        Assert.DoesNotContain(secret, row);
        Assert.Equal(64, s.App.Db.Query("SELECT length(token_hash) FROM network_devices", r => r.GetInt32(0)).Single());
        Assert.Contains("network.pair", s.Actions());
        Assert.Null(s.Pairing.WaitingCodeRunsOutAt());   // used up
        Assert.Equal(paired.Counter.Id, Assert.Single(s.Pairing.List()).Id);
    }

    [Fact]
    public void Two_counter_PCs_get_different_tokens_and_each_is_recognised_as_itself()
    {
        using var s = new Store();
        var a = s.Pair("Counter 1");
        var b = s.Pair("Counter 2", "192.168.1.32");
        Assert.NotEqual(a.Token, b.Token);
        Assert.Equal("Counter 1", s.Pairing.Recognise(a.Token, "192.168.1.30")!.Counter.Name);
        Assert.Equal("Counter 2", s.Pairing.Recognise(b.Token, "192.168.1.32")!.Counter.Name);
    }

    [Fact]
    public void A_code_works_once_only()
    {
        using var s = new Store();
        var code = s.Pairing.NewCode(s.OwnerId);
        s.Pairing.Redeem(code.Code, "Counter 2", "192.168.1.31");
        Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem(code.Code, "Counter 3", "192.168.1.32")));
        Assert.Single(s.Pairing.List());
    }

    [Fact]
    public void A_code_stops_working_when_its_ten_minutes_are_over()
    {
        using var s = new Store();
        var code = s.Pairing.NewCode(s.OwnerId);
        s.Clock.Advance(TimeSpan.FromMinutes(10).Add(TimeSpan.FromSeconds(1)));
        Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem(code.Code, "Counter 2", "192.168.1.31")));
        Assert.Empty(s.Pairing.List());
        Assert.Null(s.Pairing.WaitingCodeRunsOutAt());
    }

    [Fact]
    public void A_code_still_works_a_moment_before_its_time_is_over()
    {
        using var s = new Store();
        var code = s.Pairing.NewCode(s.OwnerId);
        s.Clock.Advance(TimeSpan.FromMinutes(9).Add(TimeSpan.FromSeconds(59)));
        Assert.Equal("Counter 2", s.Pairing.Redeem(code.Code, "Counter 2", "192.168.1.31").Counter.Name);
    }

    [Fact]
    public void A_code_is_read_the_way_people_type_it()
    {
        using var s = new Store();
        var code = s.Pairing.NewCode(s.OwnerId).Code;
        var plain = code.Replace("-", "");
        foreach (var typed in new[] { code.ToLowerInvariant(), plain, plain.ToLowerInvariant(), plain[..4] + " " + plain[4..], "  " + code + "  ", plain[..2] + "-" + plain[2..4] + " " + plain[4..] })
            Assert.Equal(plain, PairingService.Normalize(typed));
        Assert.Equal("Counter 2", s.Pairing.Redeem(code.ToLowerInvariant(), "Counter 2", "192.168.1.31").Counter.Name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("ABCD")]
    [InlineData("ABCD-EFGH-JKMN")]
    [InlineData("ABCD-EFG0")]   // 0, O, 1, I and L are not in any code
    [InlineData("ABCD-EFGO")]
    [InlineData("ABCD-EFG1")]
    [InlineData("ABCD-EFGI")]
    [InlineData("ABCD-EFGL")]
    [InlineData("ABCD-EF'--")]
    [InlineData("ABCD-EFGH; DROP TABLE users")]
    public void Anything_that_cannot_be_a_code_is_not_one(string? typed) => Assert.Null(PairingService.Normalize(typed));

    [Fact]
    public void A_name_that_is_not_allowed_does_not_use_up_the_code_or_count_as_a_wrong_try()
    {
        using var s = new Store();
        var code = s.Pairing.NewCode(s.OwnerId);
        foreach (var bad in new[] { "", "   ", null, new string('x', 41) })
            Assert.Equal("pair-name", Refusal(() => s.Pairing.Redeem(code.Code, bad, "192.168.1.31")));
        for (var i = 0; i < 10; i++) Assert.Equal("pair-name", Refusal(() => s.Pairing.Redeem(code.Code, "", "192.168.1.31")));
        Assert.Equal("Counter 2", s.Pairing.Redeem(code.Code, "Counter 2", "192.168.1.31").Counter.Name);
    }

    [Fact]
    public void A_name_with_control_characters_is_cleaned_before_it_is_kept()
    {
        using var s = new Store();
        var paired = s.Pairing.Redeem(s.Pairing.NewCode(s.OwnerId).Code, "Counter\r\n2\u0000", "192.168.1.31");
        Assert.Equal("Counter2", paired.Counter.Name);
    }

    [Fact]
    public void Two_counter_PCs_cannot_have_the_same_name_and_the_code_stays_valid_for_another_try()
    {
        using var s = new Store();
        s.Pair("Counter 2");
        var code = s.Pairing.NewCode(s.OwnerId);
        Assert.Equal("pair-name-taken", Refusal(() => s.Pairing.Redeem(code.Code, "counter 2", "192.168.1.32")));
        Assert.Equal("Counter 3", s.Pairing.Redeem(code.Code, "Counter 3", "192.168.1.32").Counter.Name);
    }

    [Fact]
    public void A_removed_counter_PCs_name_can_be_used_again()
    {
        using var s = new Store();
        var old = s.Pair("Counter 2");
        s.Pairing.Remove(old.Counter.Id, s.OwnerId);
        Assert.Equal("Counter 2", s.Pair("Counter 2").Counter.Name);
    }

    // ---- wrong codes and floods ---------------------------------------------------------------------------------------------------

    [Fact]
    public void A_wrong_code_gets_one_plain_answer_whatever_was_wrong()
    {
        using var s = new Store();
        var live = s.Pairing.NewCode(s.OwnerId);
        var answers = new[]
        {
            Assert.Throws<HubException>(() => s.Pairing.Redeem("ZZZZ-ZZZZ", "Counter 2", "192.168.1.31")),
            Assert.Throws<HubException>(() => s.Pairing.Redeem("not a code", "Counter 2", "192.168.1.32")),
            Assert.Throws<HubException>(() => s.Pairing.Redeem(null, "Counter 2", "192.168.1.33")),
        };
        Assert.All(answers, a => { Assert.Equal("pair-wrong", a.Code); Assert.Equal(answers[0].Message, a.Message); });
        Assert.DoesNotContain(live.Code, answers[0].Message);
    }

    [Fact]
    public void Five_wrong_tries_from_one_address_lock_it_and_even_the_right_code_is_then_refused_from_there()
    {
        using var s = new Store();
        var live = s.Pairing.NewCode(s.OwnerId);
        for (var i = 0; i < PairingService.WrongPerAddress - 1; i++) Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem("ZZZZ-ZZZZ", "Counter 2", "192.168.1.31")));
        // The fifth wrong try is still answered as a wrong code; from the sixth on the address is locked, even for the right code.
        Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem("ZZZZ-ZZZZ", "Counter 2", "192.168.1.31")));
        var locked = Assert.Throws<HubException>(() => s.Pairing.Redeem(live.Code, "Counter 2", "192.168.1.31"));
        Assert.Equal("pair-locked", locked.Code);
        Assert.Contains("minute", locked.Message);
        Assert.Empty(s.Pairing.List());
        // Ten minutes later the address may try again.
        s.Clock.Advance(PairingService.Window.Add(TimeSpan.FromSeconds(1)));
        var again = s.Pairing.NewCode(s.OwnerId);
        Assert.Equal("Counter 2", s.Pairing.Redeem(again.Code, "Counter 2", "192.168.1.31").Counter.Name);
    }

    [Fact]
    public void Five_wrong_tries_from_anywhere_cancel_the_code_so_it_cannot_be_guessed_by_many_addresses_in_turn()
    {
        using var s = new Store();
        var live = s.Pairing.NewCode(s.OwnerId);
        for (var i = 0; i < PairingService.WrongPerCode; i++) Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem("ZZZZ-ZZZZ", "Counter 2", "192.168.1." + (40 + i))));
        // A sixth address with the real code: the code was cancelled, so it no longer works. The owner makes a new one.
        Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem(live.Code, "Counter 2", "192.168.1.99")));
        Assert.Contains("network.code-cancelled", s.Actions());
        var fresh = s.Pairing.NewCode(s.OwnerId);
        Assert.Equal("Counter 2", s.Pairing.Redeem(fresh.Code, "Counter 2", "192.168.1.99").Counter.Name);
    }

    [Fact]
    public void A_flood_of_wrong_codes_from_many_addresses_locks_pairing_for_everybody_for_a_while()
    {
        using var s = new Store();
        for (var i = 0; i < PairingService.WrongInAll; i++) Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem("ZZZZ-ZZZZ", "x", "10.0." + i / 250 + "." + i % 250)));
        var code = s.Pairing.NewCode(s.OwnerId);
        var locked = Assert.Throws<HubException>(() => s.Pairing.Redeem(code.Code, "Counter 2", "192.168.1.31"));   // an address that never tried, with the right code
        Assert.Equal("pair-locked", locked.Code);
        Assert.Empty(s.Pairing.List());
        s.Clock.Advance(PairingService.Window.Add(TimeSpan.FromSeconds(1)));
        Assert.Equal("Counter 2", s.Pairing.Redeem(s.Pairing.NewCode(s.OwnerId).Code, "Counter 2", "192.168.1.31").Counter.Name);
    }

    [Fact]
    public void A_correct_pairing_forgives_the_wrong_tries_of_that_address()
    {
        using var s = new Store();
        s.Pairing.NewCode(s.OwnerId);
        for (var i = 0; i < 3; i++) Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem("ZZZZ-ZZZZ", "Counter 2", "192.168.1.31")));
        s.Pairing.Redeem(s.Pairing.NewCode(s.OwnerId).Code, "Counter 2", "192.168.1.31");
        for (var i = 0; i < 4; i++) Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem("ZZZZ-ZZZZ", "Counter 3", "192.168.1.31")));   // four more would have been over five without the forgiving
        Assert.Equal("pair-wrong", Refusal(() => s.Pairing.Redeem("ZZZZ-ZZZZ", "Counter 3", "192.168.1.31")));
    }

    [Fact]
    public void Two_counter_PCs_typing_the_same_code_at_the_same_moment_get_one_pairing_between_them()
    {
        using var s = new Store();
        var code = s.Pairing.NewCode(s.OwnerId);
        var results = new string[8];
        Parallel.For(0, results.Length, i =>
        {
            try { results[i] = "ok:" + s.Pairing.Redeem(code.Code, "Counter " + i, "192.168.1.5" + i).Counter.Name; }
            catch (HubException ex) { results[i] = ex.Code; }
        });
        Assert.Equal(1, results.Count(r => r.StartsWith("ok:", StringComparison.Ordinal)));
        Assert.Single(s.Pairing.List());
    }

    [Fact]
    public void Refusals_reach_the_audit_log_but_a_flood_cannot_fill_it()
    {
        using var s = new Store();
        s.Pairing.NewCode(s.OwnerId);
        var before = s.Rows("SELECT COUNT(*) FROM audit_log");
        // One address knocking a thousand times (with the wrong code and as an unknown computer): a handful of entries, not a thousand.
        for (var i = 0; i < 1000; i++)
        {
            try { s.Pairing.Redeem("ZZZZ-ZZZZ", "x", "192.168.1.77"); } catch (HubException) { }
            s.Pairing.NoteTurnedAway("192.168.1.78", "asked for /products without being paired");
        }

        var written = s.Rows("SELECT COUNT(*) FROM audit_log") - before;
        Assert.InRange(written, 2, 8);
        // Many different addresses cannot do it either: there is a limit for the whole hour.
        for (var i = 0; i < 500; i++) s.Pairing.NoteTurnedAway("10.1." + i / 250 + "." + i % 250, "asked for /products without being paired");
        Assert.True(s.Rows("SELECT COUNT(*) FROM audit_log") - before <= 50);
        // After the hour the log may be written again, and the entry says how many tries were left out.
        s.Clock.Advance(TimeSpan.FromHours(1).Add(TimeSpan.FromMinutes(1)));
        s.Pairing.NoteTurnedAway("192.168.1.78", "asked again");
        var latest = s.App.Audit.Recent(1).Single();
        Assert.Equal("network.refused", latest.Action);
        Assert.Contains("more tries since the last note", latest.Detail);
    }

    [Fact]
    public void Text_from_outside_cannot_put_control_characters_or_a_long_story_in_the_log()
    {
        using var s = new Store();
        s.Pairing.NoteTurnedAway("192.168.1.9\r\nFORGED", "asked for /a\r\n" + new string('x', 5000));
        var entry = s.App.Audit.Recent(1).Single();
        Assert.DoesNotContain('\n', entry.Detail!);
        Assert.DoesNotContain('\r', entry.Detail!);
        Assert.True(entry.Detail!.Length < 300);
    }

    // ---- recognising a counter PC --------------------------------------------------------------------------------------------------

    [Fact]
    public void A_counter_PC_is_recognised_by_its_token_and_its_last_visit_is_noted_at_most_once_a_minute()
    {
        using var s = new Store();
        var paired = s.Pair("Counter 2", "192.168.1.31");
        s.Clock.Advance(TimeSpan.FromMinutes(5));
        var seen = s.Pairing.Recognise(paired.Token, "192.168.1.31")!;
        Assert.Equal("Counter 2", seen.Counter.Name);
        Assert.False(seen.CookieIsOld);
        Assert.Equal(s.Clock.UtcNow, s.Pairing.Find(paired.Counter.Id)!.LastSeenAt);

        var noted = s.Pairing.Find(paired.Counter.Id)!.LastSeenAt;
        s.Clock.Advance(TimeSpan.FromSeconds(30));
        s.Pairing.Recognise(paired.Token, "192.168.1.31");
        Assert.Equal(noted, s.Pairing.Find(paired.Counter.Id)!.LastSeenAt);   // not written again within a minute

        s.Clock.Advance(TimeSpan.FromSeconds(31));
        s.Pairing.Recognise(paired.Token, "192.168.1.31");
        Assert.Equal(s.Clock.UtcNow, s.Pairing.Find(paired.Counter.Id)!.LastSeenAt);
    }

    [Fact]
    public void A_new_address_is_noted_at_once()
    {
        using var s = new Store();
        var paired = s.Pair("Counter 2", "192.168.1.31");
        s.Clock.Advance(TimeSpan.FromSeconds(5));
        s.Pairing.Recognise(paired.Token, "192.168.1.44");
        Assert.Equal("192.168.1.44", s.Pairing.Find(paired.Counter.Id)!.LastAddress);
    }

    [Fact]
    public void A_cookie_that_was_not_used_for_a_day_is_given_a_fresh_life()
    {
        using var s = new Store();
        var paired = s.Pair("Counter 2");
        s.Clock.Advance(TimeSpan.FromHours(23));
        Assert.False(s.Pairing.Recognise(paired.Token, "192.168.1.30")!.CookieIsOld);
        s.Clock.Advance(TimeSpan.FromHours(25));
        Assert.True(s.Pairing.Recognise(paired.Token, "192.168.1.30")!.CookieIsOld);
        Assert.False(s.Pairing.Recognise(paired.Token, "192.168.1.30")!.CookieIsOld);   // noted: seen just now
    }

    [Fact]
    public void A_made_up_cookie_is_never_a_counter_PC()
    {
        using var s = new Store();
        var paired = s.Pair("Counter 2");
        var id = paired.Counter.Id;
        var secret = paired.Token[(paired.Token.IndexOf('.') + 1)..];
        var forged = new[]
        {
            null, "", ".", "x", "1.", ".abc", "abc.def", "1.short",
            id + "." + new string('A', 43),                                  // right number, wrong secret
            id + "." + secret[..42] + (secret[42] == 'A' ? 'B' : 'A'),     // one character off
            (id + 1) + "." + secret,                                         // another number with the right secret
            "0." + secret, "-1." + secret, "99999999999999999999." + secret,
            id + "." + secret + "A",                                         // too long
            id + "." + secret.Replace(secret[0], '*'),                       // not a legal character
            new string('1', 200),
            paired.Token + ";" + paired.Token,
            "'; DROP TABLE network_devices; --",
        };
        foreach (var cookie in forged) Assert.Null(s.Pairing.Recognise(cookie, "192.168.1.30"));
        Assert.NotNull(s.Pairing.Recognise(paired.Token, "192.168.1.30"));
        Assert.Equal(1, s.Rows("SELECT COUNT(*) FROM network_devices"));
    }

    [Fact]
    public void A_token_of_one_shop_is_not_good_in_another()
    {
        using var a = new Store();
        using var b = new Store();
        var token = a.Pair("Counter 2").Token;
        b.Pair("Counter 2");   // the same numbers on both sides: id 1
        Assert.Null(b.Pairing.Recognise(token, "192.168.1.30"));
    }

    // ---- removing a counter PC --------------------------------------------------------------------------------------------------

    [Fact]
    public void A_removed_counter_PC_is_refused_with_the_very_next_request_and_the_history_stays()
    {
        using var s = new Store();
        var paired = s.Pair("Counter 2");
        var other = s.Pair("Counter 3", "192.168.1.32");
        Assert.NotNull(s.Pairing.Recognise(paired.Token, "192.168.1.30"));
        long announced = 0;
        s.Pairing.CounterRemoved += id => announced = id;

        s.Pairing.Remove(paired.Counter.Id, s.OwnerId);

        Assert.Null(s.Pairing.Recognise(paired.Token, "192.168.1.30"));
        Assert.NotNull(s.Pairing.Recognise(other.Token, "192.168.1.32"));   // the others are not touched
        Assert.Equal(paired.Counter.Id, announced);
        Assert.Equal(other.Counter.Id, Assert.Single(s.Pairing.List()).Id);
        var gone = Assert.Single(s.Pairing.Removed());
        Assert.Equal("Counter 2", gone.Name);
        Assert.False(gone.Active);
        Assert.Contains("network.revoke", s.Actions());
        Assert.Equal(2, s.Rows("SELECT COUNT(*) FROM network_devices"));   // never deleted
    }

    [Fact]
    public void Removing_twice_is_harmless_and_an_unknown_counter_PC_is_a_plain_message()
    {
        using var s = new Store();
        var paired = s.Pair("Counter 2");
        var announced = 0;
        s.Pairing.CounterRemoved += _ => announced++;
        s.Pairing.Remove(paired.Counter.Id, s.OwnerId);
        s.Pairing.Remove(paired.Counter.Id, s.OwnerId);
        Assert.Equal(1, announced);
        Assert.Equal("no-counter", Refusal(() => s.Pairing.Remove(999, s.OwnerId)));
    }

    [Fact]
    public void A_removed_token_cannot_be_used_to_pair_again_and_a_new_pairing_gives_a_new_token()
    {
        using var s = new Store();
        var first = s.Pair("Counter 2");
        s.Pairing.Remove(first.Counter.Id, s.OwnerId);
        var second = s.Pair("Counter 2");
        Assert.NotEqual(first.Counter.Id, second.Counter.Id);
        Assert.Null(s.Pairing.Recognise(first.Token, "192.168.1.30"));
        Assert.NotNull(s.Pairing.Recognise(second.Token, "192.168.1.30"));
    }

    [Fact]
    public void A_handler_that_fails_when_a_counter_PC_is_removed_does_not_stop_the_removal()
    {
        using var s = new Store();
        var paired = s.Pair("Counter 2");
        s.Pairing.CounterRemoved += _ => throw new InvalidOperationException("the connection was already gone");
        s.Pairing.Remove(paired.Counter.Id, s.OwnerId);
        Assert.Null(s.Pairing.Recognise(paired.Token, "192.168.1.30"));
    }

    // ---- the licence's number of PCs ----------------------------------------------------------------------------------------------

    [Fact]
    public void With_no_limit_in_the_licence_any_number_of_counter_PCs_may_be_paired()
    {
        using var s = new Store(limit: 0);
        for (var i = 0; i < 12; i++) s.Pair("Counter " + i, "192.168.1." + (50 + i));
        Assert.Equal(12, s.Pairing.List().Count);
        Assert.Null(s.Pairing.Use().Limit);
        Assert.False(s.Pairing.Use().Full);
    }

    [Fact]
    public void The_main_PC_and_the_counter_PCs_together_may_not_be_more_than_the_licence_allows()
    {
        using var s = new Store(limit: 3);
        s.Pair("Counter 1");
        Assert.Equal(2, s.Pairing.Use().InUse);   // the main PC and one counter
        s.Pair("Counter 2", "192.168.1.31");
        Assert.True(s.Pairing.Use().Full);

        var refused = Assert.Throws<HubException>(() => s.Pairing.NewCode(s.OwnerId));
        Assert.Equal("device-limit", refused.Code);
        Assert.Contains("3 PCs", refused.Message);
        Assert.Contains("main PC and 2 counter PCs", refused.Message);
        Assert.Contains("supplier", refused.Message);
        Assert.Equal(2, s.Pairing.List().Count);
    }

    [Fact]
    public void A_licence_for_one_PC_allows_no_counter_PC_and_says_so_in_plain_words()
    {
        using var s = new Store(limit: 1);
        var refused = Assert.Throws<HubException>(() => s.Pairing.NewCode(s.OwnerId));
        Assert.Equal("device-limit", refused.Code);
        Assert.Contains("1 PC", refused.Message);
        Assert.Contains("no counter PC can be added", refused.Message);
    }

    [Fact]
    public void A_licence_for_two_PCs_allows_one_counter_PC_and_the_message_is_in_the_singular()
    {
        using var s = new Store(limit: 2);
        s.Pair("Counter 1");
        var refused = Assert.Throws<HubException>(() => s.Pairing.NewCode(s.OwnerId));
        Assert.Contains("the main PC and 1 counter PC.", refused.Message);
    }

    [Fact]
    public void Removing_a_counter_PC_frees_a_place()
    {
        using var s = new Store(limit: 2);
        var one = s.Pair("Counter 1");
        Assert.Equal("device-limit", Refusal(() => s.Pairing.NewCode(s.OwnerId)));
        s.Pairing.Remove(one.Counter.Id, s.OwnerId);
        Assert.False(s.Pairing.Use().Full);
        s.Pair("Counter 2", "192.168.1.31");
        Assert.Single(s.Pairing.List());
    }

    [Fact]
    public void A_licence_with_fewer_PCs_than_are_paired_stops_new_pairings_but_does_not_remove_anybody()
    {
        using var s = new Store(limit: 4);
        s.Pair("Counter 1");
        s.Pair("Counter 2", "192.168.1.31");
        var code = s.Pairing.NewCode(s.OwnerId);
        s.Limit = 2;   // the licence changed after the code was made
        var refused = Assert.Throws<HubException>(() => s.Pairing.Redeem(code.Code, "Counter 3", "192.168.1.32"));
        Assert.Equal("device-limit", refused.Code);
        Assert.Equal(2, s.Pairing.List().Count);    // nobody was removed
        Assert.True(s.Pairing.Use().Full);
        // The code was not used up by the failed try: with a bigger licence again it works.
        s.Limit = 4;
        Assert.Equal("Counter 3", s.Pairing.Redeem(code.Code, "Counter 3", "192.168.1.32").Counter.Name);
    }

    // ---- the tables ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_tables_carry_tenant_and_site_and_are_empty_until_a_counter_PC_is_paired()
    {
        using var s = new Store();
        foreach (var table in new[] { "network_devices", "network_pairing_codes" })
        {
            var columns = s.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0));
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
            Assert.Equal(0, s.Rows($"SELECT COUNT(*) FROM {table}"));
        }

        s.Pair("Counter 2");
        Assert.Equal("local", s.App.Db.Scalar("SELECT tenant_id FROM network_devices"));
        Assert.Equal("main", s.App.Db.Scalar("SELECT site_id FROM network_devices"));
    }

    [Fact]
    public void A_cookie_has_to_have_exactly_the_shape_of_a_token_before_the_database_is_asked()
    {
        var secret = new string('A', 43);
        Assert.True(PairingService.TryParse("1." + secret, out var id, out var read));
        Assert.Equal(1, id);
        Assert.Equal(secret, read);
        Assert.True(PairingService.TryParse("123456789012." + secret, out _, out _));
        Assert.False(PairingService.TryParse("1234567890123." + secret, out _, out _));   // a number too long to be one of ours
        Assert.False(PairingService.TryParse("1." + new string('A', 42), out _, out _));
        Assert.False(PairingService.TryParse("1." + new string('A', 44), out _, out _));
        Assert.False(PairingService.TryParse("1." + new string('A', 42) + "=", out _, out _));
        Assert.False(PairingService.TryParse(" 1." + secret, out _, out _));
        Assert.False(PairingService.TryParse("+1." + secret, out _, out _));
        Assert.False(PairingService.TryParse("0." + secret, out _, out _));
        Assert.False(PairingService.TryParse("1" + secret, out _, out _));
        Assert.False(PairingService.TryParse(null, out _, out _));
    }
}

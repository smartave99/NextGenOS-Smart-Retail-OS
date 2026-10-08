using NextGenOS.Hub.Data;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

public class FeatureSwitchTests
{
    [Fact]
    public void Every_switch_starts_off_so_a_shop_that_never_opens_the_AI_settings_is_unchanged()
    {
        using var f = new AiFixture();
        Assert.Equal(FlagKey.All.Count, f.Ai.Flags.All().Count);
        Assert.All(f.Ai.Flags.All(), s => { Assert.False(s.Chosen); Assert.False(s.Effective); });
        Assert.All(FlagKey.All, key => Assert.False(f.Ai.Flags.IsEnabled(key)));
    }

    [Fact]
    public void A_switch_counts_only_when_the_owner_chose_it_and_the_licence_has_the_AI_part()
    {
        using var f = new AiFixture();
        f.Ai.Flags.Set(FlagKey.AiAssistant, true, 7);
        Assert.True(f.Ai.Flags.IsEnabled(FlagKey.AiAssistant));
        Assert.False(f.Ai.Flags.IsEnabled(FlagKey.CameraAnalytics));

        // The licence is withdrawn: the choice is remembered, but nothing is active.
        f.Entitled.Allowed = false;
        Assert.False(f.Ai.Flags.IsEnabled(FlagKey.AiAssistant));
        Assert.True(f.Ai.Flags.Chosen(FlagKey.AiAssistant));
        Assert.False(f.Ai.Flags.Licensed);

        f.Entitled.Allowed = true;
        Assert.True(f.Ai.Flags.IsEnabled(FlagKey.AiAssistant));
        f.Ai.Flags.Set(FlagKey.AiAssistant, false, 7);
        Assert.False(f.Ai.Flags.IsEnabled(FlagKey.AiAssistant));
    }

    [Fact]
    public void Without_the_AI_part_in_the_licence_nothing_can_be_switched_on_and_an_unknown_switch_does_not_exist()
    {
        using var f = new AiFixture(licensed: false);
        var ex = Assert.Throws<HubException>(() => f.Ai.Flags.Set(FlagKey.AiAssistant, true, 1));
        Assert.Equal("not-licensed", ex.Code);
        Assert.False(f.Ai.Flags.Chosen(FlagKey.AiAssistant));
        Assert.Equal("unknown-flag", Assert.Throws<HubException>(() => f.Ai.Flags.Set("telepathy", true, 1)).Code);
        Assert.False(f.Ai.Flags.IsEnabled("telepathy"));
        // Switching off is always allowed.
        f.Ai.Flags.Set(FlagKey.AiAssistant, false, 1);
    }

    [Fact]
    public void A_shop_program_started_without_being_told_about_the_licence_has_no_AI_at_all()
    {
        // Nothing hands the Hub an entitlement here: the safe default is "nothing".
        using var f = new HubFixture();
        Assert.False(f.App.Ai.Flags.Licensed);
        Assert.Throws<HubException>(() => f.App.Ai.Flags.Set(FlagKey.AiAssistant, true, 1));
    }

    [Fact]
    public void Switching_is_written_in_the_audit_log_with_who_and_what()
    {
        using var f = new AiFixture();
        f.Ai.Flags.Set(FlagKey.RemoteAi, true, 1);
        f.Ai.Flags.Set(FlagKey.RemoteAi, false, 1);
        var entries = f.App.Audit.Recent().Where(a => a.Action == "ai.flag").Select(a => a.Detail).ToList();
        Assert.Equal(new[] { "remote_ai: on -> off", "remote_ai: off -> on" }, entries);
    }

    [Fact]
    public void Only_the_owner_can_reach_the_AI_settings_and_every_permission_has_a_policy()
    {
        Assert.True(Roles.Can(Roles.Owner, Perm.Ai));
        foreach (var role in Roles.All.Where(r => r != Roles.Owner)) Assert.False(Roles.Can(role, Perm.Ai), role);
        Assert.False(Roles.Can("nobody", Perm.Ai));
    }
}

public class AiProviderTests
{
    private static ProviderInput Local(string id = "ollama") => new(id, "Ollama", OpenAiCompatibleProvider.AdapterId, ProviderLocation.Local, "http://127.0.0.1:11434", "llama", [AiTask.Generate]);

    [Fact]
    public void A_new_service_is_switched_off_and_may_receive_nothing()
    {
        using var f = new AiFixture();
        var saved = f.Ai.Providers.Save(Local(), 1);
        Assert.False(saved.Enabled);
        Assert.Empty(f.Ai.Providers.Consents("ollama"));
        Assert.False(f.Ai.Providers.HasSecret("ollama"));
        Assert.Equal(new[] { AiTask.Generate }, saved.Tasks);
    }

    [Theory]
    [InlineData("Not Valid", "bad-id")]
    [InlineData("", "bad-id")]
    [InlineData("a/../b", "bad-id")]
    public void A_service_needs_a_short_plain_name_to_be_kept_under(string id, string code)
    {
        using var f = new AiFixture();
        Assert.Equal(code, Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Id = id }, 1)).Code);
    }

    [Fact]
    public void A_service_is_refused_when_its_address_does_not_fit_where_it_is_said_to_run()
    {
        using var f = new AiFixture();
        var elsewhere = Local() with { BaseUrl = "https://api.example.com/v1" };
        Assert.Equal("bad-address", Assert.Throws<HubException>(() => f.Ai.Providers.Save(elsewhere, 1)).Code);
        Assert.Equal("bad-address", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Location = ProviderLocation.Lan, BaseUrl = "https://api.example.com" }, 1)).Code);
        Assert.Equal("bad-address", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Location = ProviderLocation.Api, BaseUrl = "http://api.example.com" }, 1)).Code);
        Assert.Null(f.Ai.Providers.Find("ollama"));
    }

    [Fact]
    public void A_service_is_refused_for_an_unknown_adapter_task_place_or_a_negative_number()
    {
        using var f = new AiFixture();
        Assert.Equal("bad-adapter", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Adapter = "magic" }, 1)).Code);
        Assert.Equal("bad-location", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Location = "moon" }, 1)).Code);
        Assert.Equal("no-tasks", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Tasks = Array.Empty<string>() }, 1)).Code);
        Assert.Equal("bad-task", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Tasks = ["dance"] }, 1)).Code);
        Assert.Equal("bad-number", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { PriceInMicrosPer1k = -1 }, 1)).Code);
        Assert.Equal("bad-number", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Limits = new ProviderLimits(RequestsPerDay: -5) }, 1)).Code);
        Assert.Equal("bad-name", Assert.Throws<HubException>(() => f.Ai.Providers.Save(Local() with { Name = "  " }, 1)).Code);
        Assert.Empty(f.Ai.Providers.List());
    }

    [Fact]
    public void Moving_a_service_to_another_place_switches_it_off_and_takes_back_what_it_was_allowed()
    {
        using var f = new AiFixture();
        f.Connect("shop-box", ProviderLocation.Lan);
        f.Ai.Providers.Grant("shop-box", DataClass.Personal, null, 1);
        Assert.True(f.Ai.Providers.Get("shop-box").Enabled);
        Assert.Single(f.Ai.Providers.Consents("shop-box"));

        // Only the name and the limits change: nothing else is touched.
        var current = f.Ai.Providers.Get("shop-box");
        f.Ai.Providers.Save(new ProviderInput(current.Id, "Renamed", current.Adapter, current.Location, current.BaseUrl, current.DefaultModel, current.Tasks, null, null, new ProviderLimits(RequestsPerDay: 5)), 1);
        Assert.True(f.Ai.Providers.Get("shop-box").Enabled);
        Assert.Single(f.Ai.Providers.Consents("shop-box"));

        // The address changes: the permission was for the old address.
        f.Ai.Providers.Save(new ProviderInput(current.Id, "Renamed", current.Adapter, current.Location, "http://192.168.1.99:11434", current.DefaultModel, current.Tasks), 1);
        Assert.False(f.Ai.Providers.Get("shop-box").Enabled);
        Assert.Empty(f.Ai.Providers.Consents("shop-box"));
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "ai.provider.moved");
    }

    [Fact]
    public void A_service_cannot_be_switched_on_when_its_address_no_longer_fits()
    {
        using var f = new AiFixture();
        f.Ai.Providers.Save(Local(), 1);
        // Someone changed the address in the database file by hand.
        f.App.Db.InTransaction((c, t) => NextGenOS.Hub.Data.HubDb.Exec(c, "UPDATE ai_providers SET base_url = 'https://api.example.com' WHERE id = 'ollama'", t));
        Assert.Equal("bad-address", Assert.Throws<HubException>(() => f.Ai.Providers.SetEnabled("ollama", true, 1)).Code);
        f.Ai.Providers.SetEnabled("ollama", false, 1);   // switching off always works
    }

    [Fact]
    public void Card_details_and_biometric_data_cannot_be_allowed_for_a_service_outside_this_computer_but_everything_else_can()
    {
        using var f = new AiFixture();
        f.Connect("shop-box", ProviderLocation.Lan);
        f.Connect("online", ProviderLocation.Api);
        foreach (var id in new[] { "shop-box", "online" })
        {
            Assert.Equal("never-leaves", Assert.Throws<HubException>(() => f.Ai.Providers.Grant(id, DataClass.PaymentSensitive, null, 1)).Code);
            Assert.Equal("never-leaves", Assert.Throws<HubException>(() => f.Ai.Providers.Grant(id, DataClass.Biometric, null, 1)).Code);
        }

        Assert.Equal("bad-class", Assert.Throws<HubException>(() => f.Ai.Providers.Grant("online", "SECRET", null, 1)).Code);
        f.Ai.Providers.Grant("online", DataClass.Financial, ["reports", "forecast"], 1);
        f.Ai.Providers.Grant("online", DataClass.Financial, ["reports"], 1);   // a second grant replaces the first
        var consent = Assert.Single(f.Ai.Providers.Consents("online"));
        Assert.Equal("reports", consent.Features);
        f.Ai.Providers.Revoke("online", DataClass.Financial, 1);
        Assert.Empty(f.Ai.Providers.Consents("online"));
        Assert.Equal(new[] { "ai.consent.grant", "ai.consent.grant", "ai.consent.revoke" }, f.App.Audit.Recent().Where(a => a.Action.StartsWith("ai.consent", StringComparison.Ordinal)).Select(a => a.Action).Reverse());
    }

    [Fact]
    public void Removing_a_service_removes_its_permissions_and_its_key_and_is_written_down()
    {
        using var f = new AiFixture();
        f.Connect("online", ProviderLocation.Api);
        f.Ai.Providers.Grant("online", DataClass.Internal, null, 1);
        f.Ai.Providers.SetSecret("online", "sk-test-0123456789abcdef", 1);
        Assert.True(f.Secrets.Has("ai-provider/online"));
        f.Ai.Providers.Delete("online", 1);
        Assert.Null(f.Ai.Providers.Find("online"));
        Assert.False(f.Secrets.Has("ai-provider/online"));
        Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM ai_provider_consent")));
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "ai.provider.delete" && a.Detail == "online");
    }

    [Fact]
    public void A_key_goes_to_the_safe_and_never_into_the_database_the_audit_log_or_a_backup()
    {
        using var f = new AiFixture();
        f.Connect("online", ProviderLocation.Api);
        const string key = "sk-live-ABCDEFGH12345678-ZZZ";
        f.Ai.Providers.SetSecret("online", "  " + key + "  ", 1);

        Assert.Equal(key, f.Secrets.Get("ai-provider/online"));   // trimmed
        Assert.True(f.Ai.Providers.HasSecret("online"));
        Assert.Equal("ai-provider/online", f.Ai.Providers.Get("online").SecretName);

        // Look in everything that is kept: no table holds the key, and the audit log does not either.
        var dump = string.Join("\n", new[] { "ai_providers", "ai_provider_consent", "ai_models", "ai_usage", "audit_log", "feature_flags", "settings" }
            .Where(t => f.App.Db.Scalar("SELECT name FROM sqlite_master WHERE name = $n", ("$n", t)) is not null)
            .SelectMany(t => f.App.Db.Query("SELECT * FROM " + t, r => string.Join("|", Enumerable.Range(0, r.FieldCount).Select(i => r.IsDBNull(i) ? "" : Convert.ToString(r.GetValue(i), System.Globalization.CultureInfo.InvariantCulture))))));
        Assert.DoesNotContain(key, dump);
        // Nor does the file itself (the part still waiting in the write-ahead file included).
        foreach (var file in new[] { f.App.Db.Path, f.App.Db.Path + "-wal" }.Where(File.Exists))
        {
            using var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
            using var reader = new StreamReader(stream, System.Text.Encoding.Latin1);
            Assert.DoesNotContain("ABCDEFGH", reader.ReadToEnd());
        }

        // A screen may show the last four characters of a long key and nothing of a short one.
        Assert.Equal("••••••••" + key[^4..], Secrets.Mask(key));
        Assert.DoesNotContain("ABCDEFGH", Secrets.Mask(key));
        Assert.Equal("••••••••", Secrets.Mask("short-key"));
        Assert.Equal("", Secrets.Mask(null));
        f.Ai.Providers.ClearSecret("online", 1);
        Assert.False(f.Ai.Providers.HasSecret("online"));
        Assert.Null(f.Ai.Providers.Get("online").SecretName);
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "ai.secret.set");
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "ai.secret.clear");
    }

    [Fact]
    public void An_empty_or_huge_key_is_refused()
    {
        using var f = new AiFixture();
        f.Connect("online", ProviderLocation.Api);
        Assert.Equal("no-key", Assert.Throws<HubException>(() => f.Ai.Providers.SetSecret("online", "   ", 1)).Code);
        Assert.Equal("key-too-long", Assert.Throws<HubException>(() => f.Ai.Providers.SetSecret("online", new string('k', ProviderService.MaxKeyLength + 1), 1)).Code);
        Assert.Equal("no-provider", Assert.Throws<HubException>(() => f.Ai.Providers.SetSecret("ghost", "x", 1)).Code);
    }

    [Fact]
    public void The_routing_rules_see_the_services_as_they_are_kept()
    {
        using var f = new AiFixture();
        f.Connect("here", ProviderLocation.Local);
        f.Connect("online", ProviderLocation.Api, on: false);
        f.Ai.Providers.Grant("online", DataClass.Personal, ["assistant"], 1);
        var facts = f.Ai.Providers.Facts().ToDictionary(x => x.Id);
        Assert.Equal(EndpointClassifier.Loopback, facts["here"].EndpointClass);
        Assert.True(facts["here"].Enabled);
        Assert.False(facts["online"].Enabled);
        Assert.Equal(EndpointClassifier.Internet, facts["online"].EndpointClass);
        Assert.Equal(new ConsentFact(DataClass.Personal, "assistant"), Assert.Single(facts["online"].Consents));
    }
}

public class AiModelTests
{
    [Fact]
    public void A_model_moves_from_candidate_through_testing_and_shadow_to_in_use_and_cannot_skip_the_testing()
    {
        using var f = new AiFixture();
        var model = f.Ai.Models.Add(new ModelInput("small-model", AiTask.Generate, CommercialUse: "yes"), 1);
        Assert.Equal(ModelStatus.Candidate, model.Status);
        Assert.False(model.Installed);

        Assert.Equal("bad-move", Assert.Throws<HubException>(() => f.Ai.Models.Move(model.Id, ModelStatus.Active, 1)).Code);
        Assert.Equal(ModelStatus.Testing, f.Ai.Models.Move(model.Id, ModelStatus.Testing, 1).Status);
        Assert.Equal(ModelStatus.Shadow, f.Ai.Models.Move(model.Id, ModelStatus.Shadow, 1).Status);
        Assert.Equal(ModelStatus.Active, f.Ai.Models.Move(model.Id, ModelStatus.Active, 1, "better answers in the trial").Status);
        Assert.Equal(model.Id, f.Ai.Models.Active(AiTask.Generate)!.Id);
        Assert.Null(f.Ai.Models.Active(AiTask.Embed));
        Assert.Equal("bad-status", Assert.Throws<HubException>(() => f.Ai.Models.Move(model.Id, "flying", 1)).Code);
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "ai.model.move" && a.Detail!.Contains("better answers in the trial"));
    }

    [Fact]
    public void Putting_a_new_model_in_use_retires_the_old_one_and_rolling_back_puts_the_old_one_back()
    {
        using var f = new AiFixture();
        var old = Promote(f, "old-model");
        var fresh = Promote(f, "new-model");
        Assert.Equal(ModelStatus.Deprecated, f.Ai.Models.Get(old.Id).Status);
        Assert.Equal(fresh.Id, f.Ai.Models.Active(AiTask.Generate)!.Id);

        var restored = f.Ai.Models.RollBack(fresh.Id, 1, "answers got worse");
        Assert.Equal(old.Id, restored!.Id);
        Assert.Equal(ModelStatus.Active, f.Ai.Models.Get(old.Id).Status);
        Assert.Equal(ModelStatus.RolledBack, f.Ai.Models.Get(fresh.Id).Status);
        Assert.Equal(old.Id, f.Ai.Models.Active(AiTask.Generate)!.Id);
        Assert.Equal("not-active", Assert.Throws<HubException>(() => f.Ai.Models.RollBack(fresh.Id, 1)).Code);
        // A model that was rolled back can be tried again, from the start.
        Assert.Equal(ModelStatus.Candidate, f.Ai.Models.Move(fresh.Id, ModelStatus.Candidate, 1).Status);
    }

    [Fact]
    public void Rolling_back_the_only_model_leaves_nothing_in_use_and_the_shop_does_not_depend_on_it()
    {
        using var f = new AiFixture();
        var only = Promote(f, "only-model");
        Assert.Null(f.Ai.Models.RollBack(only.Id, 1));
        Assert.Null(f.Ai.Models.Active(AiTask.Generate));
    }

    [Fact]
    public void A_model_whose_licence_does_not_allow_business_use_cannot_be_put_in_use()
    {
        using var f = new AiFixture();
        var model = f.Ai.Models.Add(new ModelInput("research-only", AiTask.Generate, CommercialUse: "no", Licence: "non-commercial"), 1);
        f.Ai.Models.Move(model.Id, ModelStatus.Testing, 1);
        Assert.Equal("licence-no", Assert.Throws<HubException>(() => f.Ai.Models.Move(model.Id, ModelStatus.Active, 1)).Code);
        Assert.Equal("licence-no", Assert.Throws<HubException>(() => { f.Ai.Models.Move(model.Id, ModelStatus.Shadow, 1); f.Ai.Models.Move(model.Id, ModelStatus.Active, 1); }).Code);
    }

    [Fact]
    public void The_same_model_is_not_listed_twice_for_the_same_work_and_service_and_what_is_in_use_cannot_be_removed()
    {
        using var f = new AiFixture();
        f.Ai.Models.Add(new ModelInput("m", AiTask.Generate), 1);
        Assert.Equal("duplicate-model", Assert.Throws<HubException>(() => f.Ai.Models.Add(new ModelInput("m", AiTask.Generate), 1)).Code);
        f.Ai.Models.Add(new ModelInput("m", AiTask.Embed), 1);          // another kind of work
        f.Ai.Models.Add(new ModelInput("m", AiTask.Generate, ProviderId: "other"), 1);   // another service
        Assert.Equal(3, f.Ai.Models.List().Count);
        Assert.Equal(2, f.Ai.Models.List(AiTask.Generate).Count);

        var active = Promote(f, "in-use");
        Assert.Equal("in-use", Assert.Throws<HubException>(() => f.Ai.Models.Remove(active.Id, 1)).Code);
        var candidate = f.Ai.Models.Add(new ModelInput("scratch", AiTask.Generate), 1);
        f.Ai.Models.Remove(candidate.Id, 1);
        Assert.Null(f.Ai.Models.Find(candidate.Id));
    }

    [Fact]
    public void A_model_is_refused_without_a_name_a_known_task_or_a_licence_answer_it_understands()
    {
        using var f = new AiFixture();
        Assert.Equal("bad-model", Assert.Throws<HubException>(() => f.Ai.Models.Add(new ModelInput(" ", AiTask.Generate), 1)).Code);
        Assert.Equal("bad-task", Assert.Throws<HubException>(() => f.Ai.Models.Add(new ModelInput("m", "juggle"), 1)).Code);
        Assert.Equal("bad-licence", Assert.Throws<HubException>(() => f.Ai.Models.Add(new ModelInput("m", AiTask.Generate, CommercialUse: "maybe"), 1)).Code);
        Assert.Equal("bad-number", Assert.Throws<HubException>(() => f.Ai.Models.Add(new ModelInput("m", AiTask.Generate, MemoryMb: -1), 1)).Code);
        Assert.Equal("no-model", Assert.Throws<HubException>(() => f.Ai.Models.Get(999)).Code);
    }

    [Fact]
    public void Every_stage_has_words_and_only_sensible_moves_are_allowed()
    {
        foreach (var status in ModelStatus.All) Assert.NotEqual(status, ModelStatus.Label(status));
        Assert.True(ModelStatus.CanMove(ModelStatus.Active, ModelStatus.RolledBack));
        Assert.False(ModelStatus.CanMove(ModelStatus.Candidate, ModelStatus.Active));
        Assert.False(ModelStatus.CanMove(ModelStatus.Deprecated, ModelStatus.Active));
        Assert.False(ModelStatus.CanMove(ModelStatus.Active, ModelStatus.Candidate));
    }

    private static ModelRecord Promote(AiFixture f, string name)
    {
        var model = f.Ai.Models.Add(new ModelInput(name, AiTask.Generate, CommercialUse: "yes"), 1);
        f.Ai.Models.Move(model.Id, ModelStatus.Testing, 1);
        f.Ai.Models.Move(model.Id, ModelStatus.Shadow, 1);
        return f.Ai.Models.Move(model.Id, ModelStatus.Active, 1);
    }
}

public class AiUsageTests
{
    [Fact]
    public void Use_is_counted_by_day_and_month_and_only_the_calls_that_went_through_count_toward_a_limit()
    {
        using var f = new AiFixture();
        f.Connect("here", ProviderLocation.Local);
        var usage = f.Ai.Usage;
        UsageEntry Entry(string outcome, int tin = 10, int tout = 5, long cost = 7) => new("here", "m", AiTask.Generate, "assistant", DataClass.Internal, tin, tout, cost, 12, outcome, null, 1);

        usage.Record(Entry(Outcome.Ok));
        usage.Record(Entry(Outcome.Ok));
        usage.Record(Entry(Outcome.Failed));
        usage.Record(Entry(Outcome.Refused));
        f.Shop.Clock.Advance(TimeSpan.FromDays(1));   // 6 October
        usage.Record(Entry(Outcome.Ok, 100, 0, 1000));

        var today = usage.Today("here");
        Assert.Equal(new UsageTotals(1, 100, 0, 1000), today);
        var month = usage.ThisMonth("here");
        Assert.Equal(3, month.Requests);
        Assert.Equal(120, month.TokensIn);
        Assert.Equal(1014, month.CostMicros);

        f.Shop.Clock.Advance(TimeSpan.FromDays(30));   // November: a new month
        Assert.Equal(UsageTotals.None, usage.ThisMonth("here"));
        Assert.Equal(UsageTotals.None, usage.Today("here"));
        Assert.Equal(UsageTotals.None, usage.Today("nobody"));
    }

    [Fact]
    public void The_summary_shows_what_was_used_what_was_refused_and_what_failed_for_every_service()
    {
        using var f = new AiFixture();
        var usage = f.Ai.Usage;
        var since = f.Shop.Clock.UtcNow.AddDays(-1);
        usage.Record(new UsageEntry("a", "m", AiTask.Generate, "x", DataClass.Public, 10, 10, 5, 1, Outcome.Ok, null, null));
        usage.Record(new UsageEntry("a", "m", AiTask.Generate, "x", DataClass.Public, 0, 0, 0, 1, Outcome.Failed, "unreachable", null));
        usage.Record(new UsageEntry("a", "m", AiTask.Generate, "x", DataClass.Public, 0, 0, 0, 0, Outcome.OverBudget, "limit", null));
        usage.Record(new UsageEntry(null, null, AiTask.Generate, "x", DataClass.Biometric, 0, 0, 0, 0, Outcome.Refused, "never leaves", null));
        var summary = usage.Summary(since).ToDictionary(s => s.ProviderId ?? "");
        Assert.Equal(1, summary["a"].Used.Requests);
        Assert.Equal(20, summary["a"].Used.Tokens);
        Assert.Equal(1, summary["a"].Failed);
        Assert.Equal(1, summary["a"].OverBudget);
        Assert.Equal(1, summary[""].Refused);
        Assert.Equal(4, usage.Recent(10).Count);
        Assert.Equal(Outcome.Refused, usage.Recent(1).Single().Outcome);
    }

    [Fact]
    public void A_long_error_text_is_cut_so_it_cannot_fill_the_record()
    {
        using var f = new AiFixture();
        f.Ai.Usage.Record(new UsageEntry("a", null, AiTask.Generate, "x", DataClass.Public, 0, 0, 0, 0, Outcome.Failed, new string('e', 5000), null));
        Assert.True(f.Ai.Usage.Recent(1).Single().Detail!.Length <= 301);
    }
}

/// <summary>Version 2 changes the shop database only by adding tables, can always be undone, and copies the file before it changes an existing shop.</summary>
public class AiMigrationTests
{
    private static string[] Tables(HubApp app) => app.Db.Query("SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name", r => r.GetString(0)).ToArray();

    private static readonly string[] AiTables = ["ai_models", "ai_provider_consent", "ai_providers", "ai_usage", "feature_flags"];

    [Fact]
    public void The_new_tables_exist_every_one_carries_tenant_and_site_and_nothing_of_the_shops_own_tables_changed()
    {
        using var f = new HubFixture();
        Assert.Subset(Tables(f.App).ToHashSet(), AiTables.ToHashSet());
        foreach (var table in AiTables)
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0));
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
        }

        // The tables a shop sells with are exactly the ones the first step made.
        var shop = Tables(f.App).Except(AiTables).Except(new[] { "event_evidence", "event_observations", "events", "observations", "retention_policies", "ontology_entities", "ontology_entity_types", "ontology_relation_types", "ontology_relationships", "import_runs", "import_id_map", "party_opening_balances", "accounts", "journal_entries", "journal_lines", "loyalty_ledger", "offers", "vouchers", "document_offers", "party_discounts" }).ToArray();
        Assert.Contains("documents", shop);
        Assert.Contains("audit_log", shop);
        Assert.DoesNotContain(shop, t => t.StartsWith("ai_", StringComparison.Ordinal));
    }

    [Fact]
    public void Undoing_the_AI_step_removes_only_its_tables_keeps_every_sale_and_can_be_run_forward_again()
    {
        using var f = new HubFixture();
        f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 42500, TaxClass = "standard" });
        var shopTablesBefore = Tables(f.App).Except(AiTables).Except(new[] { "event_evidence", "event_observations", "events", "observations", "retention_policies", "ontology_entities", "ontology_entity_types", "ontology_relation_types", "ontology_relationships", "import_runs", "import_id_map", "party_opening_balances", "accounts", "journal_entries", "journal_lines", "loyalty_ledger", "offers", "vouchers", "document_offers", "party_discounts" }).ToArray();

        f.App.Db.Rollback(1);

        Assert.Equal(shopTablesBefore, Tables(f.App));
        Assert.Equal(new long[] { 1 }, f.App.Db.Query("SELECT version FROM schema_version", r => r.GetInt64(0)).ToArray());
        Assert.Equal("Rice", f.App.Db.Scalar("SELECT name FROM items"));
        Assert.NotNull(f.App.Db.LastBackup);
        Assert.True(File.Exists(f.App.Db.LastBackup));

        // Forward again: the step runs once more and the tables are back, empty.
        var again = HubApp.Open(f.App.Db.Path, f.Clock);
        Assert.Subset(Tables(again).ToHashSet(), AiTables.ToHashSet());
        Assert.Equal(Enumerable.Range(1, HubDb.LatestVersion).Select(v => (long)v).ToArray(), again.Db.Query("SELECT version FROM schema_version ORDER BY version", r => r.GetInt64(0)).ToArray());
        Assert.Equal("Rice", again.Db.Scalar("SELECT name FROM items"));
    }

    [Fact]
    public void The_first_step_the_shops_own_tables_cannot_be_undone_and_nothing_happens_when_there_is_nothing_to_undo()
    {
        using var f = new HubFixture();
        Assert.Throws<InvalidOperationException>(() => f.App.Db.Rollback(0));
        f.App.Db.Rollback(3);   // already there: nothing to do
        Assert.Subset(Tables(f.App).ToHashSet(), AiTables.ToHashSet());
    }

    [Fact]
    public void An_existing_shop_is_copied_whole_before_an_update_and_a_new_shop_is_not()
    {
        using var f = new HubFixture();
        Assert.Null(f.App.Db.LastBackup);   // a new database has nothing to lose
        f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Sugar", PriceMinor = 5000, TaxClass = "standard" });
        f.App.Db.Rollback(1);
        var made = f.App.Db.LastBackup!;
        File.Delete(made);

        var updated = HubApp.Open(f.App.Db.Path, f.Clock);   // version 1 -> 2 on an existing shop
        Assert.Null(updated.Db.BackupProblem);
        Assert.NotNull(updated.Db.LastBackup);
        Assert.Contains($"before-update-1-to-{HubDb.LatestVersion}", updated.Db.LastBackup);
        Assert.True(File.Exists(updated.Db.LastBackup));

        // The copy is a whole shop database as it was before the update: it has the sale data and not the new tables.
        var copy = new NextGenOS.Hub.Data.HubDb(updated.Db.LastBackup!);
        Assert.Equal("Sugar", copy.Scalar("SELECT name FROM items"));
        Assert.Null(copy.Scalar("SELECT name FROM sqlite_master WHERE name = 'ai_providers'"));

        // Opening again changes nothing and copies nothing.
        var third = HubApp.Open(f.App.Db.Path, f.Clock);
        Assert.Null(third.Db.LastBackup);
    }
}

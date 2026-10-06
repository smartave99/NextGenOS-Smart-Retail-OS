using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;

namespace NextGenOS.Hub.Tests;

/// <summary>The one door to AI services: licence, switch, privacy rules, limits, fall-back, and a record of everything that was or was not done.</summary>
public class AiGatewayTests
{
    private static AiContext Ctx(string dataClass = DataClass.Internal, string feature = "assistant", string? flag = FlagKey.AiAssistant, string? preferred = null) => new(feature, dataClass, 4, flag, preferred);

    private static LlmRequest Say(string text) => new([new LlmMessage("user", text)]);

    private static Task<AiAnswer<LlmResponse>> Ask(AiFixture f, AiContext context, string text = "What sold best?") => f.Ai.Gateway.GenerateAsync(context, Say(text), CancellationToken.None);

    [Fact]
    public async Task Without_the_AI_part_in_the_licence_nothing_is_asked_and_the_refusal_is_written_down()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local);
        f.Allow(FlagKey.AiAssistant);
        f.Entitled.Allowed = false;

        var answer = await Ask(f, Ctx());

        Assert.False(answer.Ok);
        Assert.Contains("licence", answer.Refusal);
        Assert.Equal(0, here.Calls);
        var row = f.Ai.Usage.Recent(1).Single();
        Assert.Equal(Outcome.Refused, row.Outcome);
        Assert.Equal(4, row.UserId);
    }

    [Fact]
    public async Task A_feature_whose_switch_is_off_gets_no_answer_and_no_service_is_asked()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local);

        var answer = await Ask(f, Ctx());

        Assert.False(answer.Ok);
        Assert.Contains("switched off", answer.Refusal);
        Assert.Equal(0, here.Calls);
    }

    [Fact]
    public async Task A_service_on_this_computer_answers_and_the_use_is_written_down_with_what_it_cost()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local, priceIn: 2_000, priceOut: 6_000);
        f.Allow(FlagKey.AiAssistant);
        here.TokensIn = 1_000;
        here.TokensOut = 500;

        var answer = await Ask(f, Ctx(DataClass.Personal));

        Assert.True(answer.Ok);
        Assert.Equal("answer from here", answer.Value!.Text);
        Assert.Equal("here", answer.ProviderId);
        var row = f.Ai.Usage.Recent(1).Single();
        Assert.Equal((Outcome.Ok, "here", "model-here", 1_000, 500, 5_000L, DataClass.Personal, "assistant"), (row.Outcome, row.ProviderId, row.Model, row.TokensIn, row.TokensOut, row.CostMicros, row.DataClass, row.Feature));
    }

    [Fact]
    public async Task An_online_service_is_never_asked_without_the_online_switch_even_when_the_owner_allowed_the_data()
    {
        using var f = new AiFixture();
        var online = f.Connect("online", ProviderLocation.Api);
        f.Ai.Providers.Grant("online", DataClass.Internal, null, 1);
        f.Allow(FlagKey.AiAssistant);   // but not remote_ai

        var answer = await Ask(f, Ctx());

        Assert.False(answer.Ok);
        Assert.Equal(0, online.Calls);
        Assert.Contains("Online AI services are switched off", answer.Refusal);

        f.Allow(FlagKey.RemoteAi);
        var now = await Ask(f, Ctx());
        Assert.True(now.Ok);
        Assert.Equal(1, online.Calls);
    }

    [Fact]
    public async Task An_online_service_receives_only_the_kinds_of_data_the_owner_allowed_for_it_and_for_that_feature()
    {
        using var f = new AiFixture();
        var online = f.Connect("online", ProviderLocation.Api);
        f.Allow(FlagKey.AiAssistant, FlagKey.RemoteAi);
        f.Ai.Providers.Grant("online", DataClass.Financial, ["reports"], 1);

        Assert.False((await Ask(f, Ctx(DataClass.Personal, "reports"))).Ok);
        Assert.False((await Ask(f, Ctx(DataClass.Financial, "assistant"))).Ok);
        Assert.Equal(0, online.Calls);
        Assert.True((await Ask(f, Ctx(DataClass.Financial, "reports"))).Ok);
        Assert.Equal(1, online.Calls);

        // Taking the permission back stops it at once.
        f.Ai.Providers.Revoke("online", DataClass.Financial, 1);
        Assert.False((await Ask(f, Ctx(DataClass.Financial, "reports"))).Ok);
        Assert.Equal(1, online.Calls);
    }

    [Theory]
    [InlineData("Customer paid with card 4111 1111 1111 1111 yesterday")]
    [InlineData("5500005555555559")]
    public async Task A_card_number_found_in_a_text_makes_it_payment_data_that_only_this_computer_may_see(string text)
    {
        using var f = new AiFixture();
        var online = f.Connect("online", ProviderLocation.Api);
        var shop = f.Connect("shop-box", ProviderLocation.Lan);
        f.Allow(FlagKey.AiAssistant, FlagKey.RemoteAi);
        foreach (var id in new[] { "online", "shop-box" })
            foreach (var c in new[] { DataClass.Public, DataClass.Internal, DataClass.Confidential, DataClass.Personal, DataClass.Financial })
                f.Ai.Providers.Grant(id, c, null, 1);

        // The caller said "public"; the text says otherwise.
        var refused = await Ask(f, Ctx(DataClass.Public), text);
        Assert.False(refused.Ok);
        Assert.Equal(0, online.Calls + shop.Calls);
        Assert.Equal(DataClass.PaymentSensitive, f.Ai.Usage.Recent(1).Single().DataClass);

        var here = f.Connect("here", ProviderLocation.Local);
        var answered = await Ask(f, Ctx(DataClass.Public), text);
        Assert.True(answered.Ok);
        Assert.Equal("here", answered.ProviderId);
        Assert.Equal(1, here.Calls);
        Assert.Equal(0, online.Calls + shop.Calls);
    }

    [Fact]
    public async Task An_email_address_or_phone_number_in_a_text_makes_it_personal_data_whatever_the_caller_called_it()
    {
        using var f = new AiFixture();
        var online = f.Connect("online", ProviderLocation.Api);
        f.Allow(FlagKey.AiAssistant, FlagKey.RemoteAi);
        f.Ai.Providers.Grant("online", DataClass.Internal, null, 1);   // allowed to receive internal figures, not personal data

        var plain = await Ask(f, Ctx(DataClass.Internal), "What sold best this week?");
        Assert.True(plain.Ok);
        Assert.Equal(1, online.Calls);

        foreach (var text in new[] { "Remind maria.santos@example.com that her order is ready", "Call +91 98765 43210 about the order" })
        {
            var refused = await Ask(f, Ctx(DataClass.Internal), text);
            Assert.False(refused.Ok, text);
            Assert.Equal(DataClass.Personal, f.Ai.Usage.Recent(1).Single().DataClass);
        }

        Assert.Equal(1, online.Calls);
        f.Ai.Providers.Grant("online", DataClass.Personal, null, 1);   // now the owner has allowed personal data too
        Assert.True((await Ask(f, Ctx(DataClass.Internal), "Remind maria.santos@example.com that her order is ready")).Ok);
        Assert.Equal(2, online.Calls);

        // On this computer it needs no permission at all.
        var here = f.Connect("here", ProviderLocation.Local);
        var answered = await Ask(f, Ctx(DataClass.Public), "Call +91 98765 43210");
        Assert.Equal("here", answered.ProviderId);
        Assert.Equal(1, here.Calls);
    }

    [Fact]
    public async Task When_the_best_service_fails_the_next_allowed_one_is_tried_and_both_are_written_down()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local);
        var shop = f.Connect("shop-box", ProviderLocation.Lan);
        f.Allow(FlagKey.AiAssistant);
        here.Fails = new ProviderException(ProviderException.Unreachable, "here cannot be reached");

        var answer = await Ask(f, Ctx(DataClass.Public));

        Assert.True(answer.Ok);
        Assert.Equal("shop-box", answer.ProviderId);
        Assert.Equal((1, 1), (here.Calls, shop.Calls));
        var rows = f.Ai.Usage.Recent(2);
        Assert.Equal(new[] { Outcome.Ok, Outcome.Failed }, rows.Select(r => r.Outcome));
        Assert.Contains("unreachable", rows[1].Detail);
        Assert.Contains(answer.Trace, s => s.ProviderId == "here" && !s.Allowed);
    }

    [Fact]
    public async Task When_every_allowed_service_fails_there_is_no_answer_and_the_reason_is_in_plain_words()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local);
        f.Allow(FlagKey.AiAssistant);
        here.Fails = new ProviderException(ProviderException.Timeout, "here did not answer in time.");

        var answer = await Ask(f, Ctx());

        Assert.False(answer.Ok);
        Assert.Contains("No AI service could do this just now", answer.Refusal);
        Assert.Contains("did not answer in time", answer.Refusal);
        Assert.Equal(Outcome.Failed, f.Ai.Usage.Recent(1).Single().Outcome);
    }

    [Fact]
    public async Task A_service_that_breaks_in_an_unexpected_way_is_written_down_without_its_message_and_does_not_stop_the_caller()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local);
        f.Allow(FlagKey.AiAssistant);
        f.Factory.Services["here"] = new Exploding("here", ProviderLocation.Local);

        var answer = await Ask(f, Ctx());

        Assert.False(answer.Ok);
        Assert.DoesNotContain("customer list", answer.Refusal);
        var row = f.Ai.Usage.Recent(1).Single();
        Assert.Equal(Outcome.Failed, row.Outcome);
        Assert.Equal(nameof(InvalidOperationException), row.Detail);
        Assert.Equal(0, here.Calls);
    }

    [Fact]
    public async Task A_sign_in_header_inside_a_service_error_is_hidden_before_it_is_written_down()
    {
        using var f = new AiFixture();
        var online = f.Connect("online", ProviderLocation.Api);
        f.Allow(FlagKey.AiAssistant, FlagKey.RemoteAi);
        f.Ai.Providers.Grant("online", DataClass.Internal, null, 1);
        online.Fails = new ProviderException(ProviderException.BadAnswer, "error: Authorization: Bearer sk-abcdefghijklmnop1234");

        await Ask(f, Ctx());

        var detail = f.Ai.Usage.Recent(1).Single().Detail!;
        Assert.DoesNotContain("sk-abcdefghijklmnop1234", detail);
        Assert.Contains("[hidden]", detail);
    }

    [Fact]
    public async Task A_service_over_its_limit_is_not_asked_the_refusal_names_the_limit_and_another_allowed_service_is_used()
    {
        using var f = new AiFixture();
        var cheap = f.Connect("cheap", ProviderLocation.Local, limits: new ProviderLimits(RequestsPerDay: 1));
        var spare = f.Connect("spare", ProviderLocation.Lan);
        f.Allow(FlagKey.AiAssistant);

        Assert.Equal("cheap", (await Ask(f, Ctx(DataClass.Public))).ProviderId);
        var second = await Ask(f, Ctx(DataClass.Public));

        Assert.Equal("spare", second.ProviderId);
        Assert.Equal((1, 1), (cheap.Calls, spare.Calls));
        Assert.Contains(f.Ai.Usage.Recent(5), r => r.Outcome == Outcome.OverBudget && r.ProviderId == "cheap" && r.Detail!.Contains("limit"));

        // With no other service allowed, the limit is the answer.
        f.Ai.Providers.SetEnabled("spare", false, 1);
        var third = await Ask(f, Ctx(DataClass.Public));
        Assert.False(third.Ok);
        Assert.Contains("limit", third.Refusal);
    }

    [Fact]
    public async Task A_spending_limit_stops_the_calls_once_the_month_has_cost_that_much()
    {
        using var f = new AiFixture();
        var paid = f.Connect("paid", ProviderLocation.Local, limits: new ProviderLimits(CostMicrosPerMonth: 5_000), priceIn: 2_000, priceOut: 6_000);
        paid.TokensIn = 1_000;
        paid.TokensOut = 500;   // 5,000 millionths a call
        f.Allow(FlagKey.AiAssistant);

        Assert.True((await Ask(f, Ctx())).Ok);
        var again = await Ask(f, Ctx());
        Assert.False(again.Ok);
        Assert.Contains("spending limit", again.Refusal);
        Assert.Equal(1, paid.Calls);

        // A new month starts again at nothing.
        f.Shop.Clock.Advance(TimeSpan.FromDays(31));
        Assert.True((await Ask(f, Ctx())).Ok);
    }

    [Fact]
    public async Task Embeddings_go_through_the_same_door_and_rules()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local, tasks: [AiTask.Embed]);
        f.Allow(FlagKey.LocalEmbeddings);

        var answer = await f.Ai.Gateway.EmbedAsync(new AiContext("search", DataClass.Internal, 4, FlagKey.LocalEmbeddings), new EmbeddingRequest(["rice", "sugar"]), CancellationToken.None);

        Assert.True(answer.Ok);
        Assert.Equal(2, answer.Value!.Vectors.Count);
        Assert.Equal(2, answer.Value.Dimensions);
        Assert.Equal(1, here.Calls);
        Assert.Equal(AiTask.Embed, f.Ai.Usage.Recent(1).Single().Task);

        // A service that is only set up for writing is not asked to embed.
        var writer = f.Connect("writer", ProviderLocation.Local, tasks: [AiTask.Generate]);
        f.Ai.Providers.SetEnabled("here", false, 1);
        Assert.False((await f.Ai.Gateway.EmbedAsync(new AiContext("search", DataClass.Internal, 4, FlagKey.LocalEmbeddings), new EmbeddingRequest(["rice"]), CancellationToken.None)).Ok);
        Assert.Equal(0, writer.Calls);
    }

    [Fact]
    public async Task A_caller_that_gives_up_stops_the_call_and_it_is_not_counted_as_a_failure()
    {
        using var f = new AiFixture();
        f.Connect("here", ProviderLocation.Local);
        f.Allow(FlagKey.AiAssistant);
        f.Factory.Services["here"] = new Cancelling("here", ProviderLocation.Local);
        using var source = new CancellationTokenSource();
        source.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => f.Ai.Gateway.GenerateAsync(Ctx(), Say("hello"), source.Token));
        Assert.DoesNotContain(f.Ai.Usage.Recent(5), r => r.Outcome == Outcome.Failed);
    }

    [Fact]
    public async Task An_unknown_kind_of_data_is_refused_before_anything_leaves()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local);
        f.Allow(FlagKey.AiAssistant);

        var answer = await Ask(f, Ctx("EVERYTHING"));

        Assert.False(answer.Ok);
        Assert.Equal(0, here.Calls);
        Assert.Equal(Outcome.Refused, f.Ai.Usage.Recent(1).Single().Outcome);
    }

    [Fact]
    public async Task The_service_the_owner_prefers_for_a_feature_goes_first_when_it_is_allowed()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local);
        var shop = f.Connect("shop-box", ProviderLocation.Lan);
        f.Allow(FlagKey.AiAssistant);

        var answer = await Ask(f, Ctx(DataClass.Public, preferred: "shop-box"));

        Assert.Equal("shop-box", answer.ProviderId);
        Assert.Equal((0, 1), (here.Calls, shop.Calls));
    }

    [Fact]
    public async Task Asking_a_service_whether_it_is_there_needs_the_licence_a_fitting_address_and_sends_nothing_of_the_shop()
    {
        using var f = new AiFixture();
        var here = f.Connect("here", ProviderLocation.Local);

        var up = await f.Ai.Gateway.CheckAsync("here", CancellationToken.None);
        Assert.True(up.Reachable);
        Assert.Equal(new[] { "model-a" }, up.Models);
        Assert.Equal(0, here.Calls);
        Assert.Empty(f.Ai.Usage.Recent(5));

        Assert.False((await f.Ai.Gateway.CheckAsync("nobody", CancellationToken.None)).Reachable);
        f.App.Db.InTransaction((c, t) => NextGenOS.Hub.Data.HubDb.Exec(c, "UPDATE ai_providers SET base_url = 'https://api.example.com' WHERE id = 'here'", t));
        Assert.False((await f.Ai.Gateway.CheckAsync("here", CancellationToken.None)).Reachable);

        f.Entitled.Allowed = false;
        Assert.Contains("licence", (await f.Ai.Gateway.CheckAsync("here", CancellationToken.None)).Message);
    }

    [Fact]
    public async Task The_shop_keeps_selling_with_every_AI_service_off_or_gone()
    {
        // The Definition of "the shop never depends on AI" (CLAUDE.md, section 15): the shop's own work does not touch the gateway at all.
        using var f = new AiFixture(licensed: false);
        var item = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = f.App.Shop.Current.Minor("118.00"), TaxClass = "standard", TrackStock = false });
        var sale = f.App.Documents.Checkout(new CheckoutRequest
        {
            Lines = { new LineInput { ItemId = item.Id, QtyMilli = 2000 } },
            Payments = { new PaymentInput { Method = "cash", AmountMinor = 30_000 } },
        });
        // The same bill, to the paisa, that the shop made before any of this existed.
        Assert.Equal(23_600, sale.Document.TotalMinor);
        Assert.Equal("paid", sale.Document.PaymentState);
        Assert.False((await Ask(f, Ctx())).Ok);
        Assert.Empty(f.Ai.Providers.List());
    }

    private sealed class Exploding(string id, string location) : ILlmProvider
    {
        public string Id => id;
        public string DisplayName => id;
        public string Location => location;
        public IReadOnlySet<string> Tasks { get; } = new HashSet<string> { AiTask.Generate };
        public Task<ProviderHealth> CheckAsync(CancellationToken cancel) => throw new InvalidOperationException("customer list leaked");
        public Task<LlmResponse> GenerateAsync(LlmRequest request, CancellationToken cancel) => throw new InvalidOperationException("customer list leaked");
    }

    private sealed class Cancelling(string id, string location) : ILlmProvider
    {
        public string Id => id;
        public string DisplayName => id;
        public string Location => location;
        public IReadOnlySet<string> Tasks { get; } = new HashSet<string> { AiTask.Generate };
        public Task<ProviderHealth> CheckAsync(CancellationToken cancel) => throw new OperationCanceledException(cancel);
        public Task<LlmResponse> GenerateAsync(LlmRequest request, CancellationToken cancel) => throw new OperationCanceledException(cancel);
    }
}

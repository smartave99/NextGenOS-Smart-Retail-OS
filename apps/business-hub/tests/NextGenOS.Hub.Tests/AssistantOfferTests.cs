using NextGenOS.Hub.Actions;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Assistant;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// "Ask the shop", step 2 (Version 2, Phase 6): an answer that points at a running-low warning can offer the order that warning proposes. The program builds the offer from the warning's own
/// figures, a person presses "Ask for approval", and the request waits for someone who may buy to approve it, as any request does. The assistant cannot ask for it, approve it or do it, and a model
/// never writes the request. India, rupees; rice sold at 3 kg a day for four weeks, 16 kg left, 26 kg proposed from National Foods.
/// </summary>
public sealed class AssistantOfferTests : IDisposable
{
    private readonly AiFixture f = new();
    private readonly long owner, manager, cashier, kitchen;
    private readonly Item rice;
    private readonly Party supplier;
    private readonly ScriptedModel model;
    private HubApp? strict;

    public AssistantOfferTests()
    {
        f.Allow(FlagKey.AiAssistant, FlagKey.PredictiveInventory, FlagKey.SuggestedActions);
        owner = f.App.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        manager = f.App.Users.Create("mia", "Mia Manager", Roles.Manager, "manager good password").Id;
        cashier = f.App.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        kitchen = f.App.Users.Create("kim", "Kim Kitchen", Roles.Kitchen, "kitchen good password").Id;
        supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", Unit = "kg", PriceMinor = 20_000, CostMinor = 10_000, TaxClass = "zero", TrackStock = true });
        f.App.Purchasing.Receive(f.App.Purchasing.CreateOrder(supplier.Id, [new PurchaseLine { ItemId = rice.Id, QtyMilli = 100_000, CostMinor = 10_000 }]).Document.Id);
        f.App.Supply.Set(rice.Id, supplier.Id, 5, 2, 1_000, 0, null);
        for (var day = 1; day <= 28; day++)
        {
            f.Shop.Clock.Advance(TimeSpan.FromDays(1));
            f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 3_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 100_000_000 } } });
        }

        model = new ScriptedModel("here", ProviderLocation.Local);
        f.Factory.Services["here"] = model;
        f.Ai.Providers.Save(new ProviderInput("here", "here", OpenAiCompatibleProvider.AdapterId, ProviderLocation.Local, "http://127.0.0.1:11434", "m", [AiTask.Generate], null, null, null), 1);
        f.Ai.Providers.SetEnabled("here", true, 1);
        model.PlanReply = "{\"tools\":[{\"tool\":\"stock.running-low\"}]}";
        model.AnswerReply = _ => "Rice is running low and the program suggests an order [1].";
    }

    public void Dispose() => f.Dispose();

    private HubApp S => strict ??= f.OpenStrict();

    private async Task<AssistantReply> Ask(long who, string question = "What is running low?")
    {
        using var scope = S.Access.As(who);
        return await S.Assistant.AskAsync(question);
    }

    private T As<T>(long who, Func<T> work)
    {
        using var scope = S.Access.As(who);
        return work();
    }

    private long OpenOrders() => Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE type = 'purchase' AND status <> 'issued' AND status <> 'cancelled'"));

    private long Requests() => Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM actions"));

    private void Forecast() => f.App.Insights.Run(null);

    // ---- the warning as a fact --------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_running_low_warning_is_a_fact_with_its_reference_in_the_shops_own_words_and_the_order_the_program_suggests()
    {
        Forecast();

        var reply = await Ask(manager);

        var fact = Assert.Single(reply.Facts, x => x.Tool == "stock.running-low");
        Assert.Equal("finding:1", fact.Ref);
        Assert.Equal("Running low (warning 1): Rice: 16 kg on hand, 84 kg sold in the last 28 days, and delivery takes 5 days. The forecast suggests ordering 26 kg from National Foods.", fact.Text);
        Assert.Equal(AssistantMode.Answered, reply.Mode);
        Assert.Equal([1], reply.Cited);
        Assert.Contains("finding:1", f.App.Db.Query("SELECT sources FROM assistant_questions", r => r.GetString(0)).Single());   // the record points at the warning, not at its figures
    }

    [Fact]
    public async Task With_no_warning_open_it_says_so_and_with_forecasts_off_the_lookup_says_why_it_gave_nothing()
    {
        var none = await Ask(manager);
        Assert.Contains(none.Facts, x => x.Tool == "stock.running-low" && x.Text == "There are no running-low warnings open.");
        Assert.Empty(none.Offers);

        f.Ai.Flags.Set(FlagKey.PredictiveInventory, false, owner);
        var off = await Ask(manager);
        var run = off.Tools.Single(t => t.Tool == "stock.running-low");
        Assert.Equal(0, run.Facts);
        Assert.Contains("switched off", run.Problem);
    }

    [Fact]
    public async Task Only_people_who_work_with_stock_or_buying_are_offered_the_lookup_or_can_look_at_a_warning()
    {
        Forecast();
        model.PlanReply = "{\"tools\":[{\"tool\":\"stock.running-low\"},{\"tool\":\"sales.summary\",\"args\":{\"period\":\"today\"}}]}";

        foreach (var person in new[] { cashier, kitchen })
        {
            var reply = await Ask(person);
            Assert.DoesNotContain(reply.Tools, t => t.Tool == "stock.running-low");
            Assert.Empty(reply.Offers);
            Assert.DoesNotContain(reply.Facts, x => x.Tool == "stock.running-low");
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => As(person, () => S.Assistant.AskForApproval(1))).Code);
        }

        foreach (var plan in model.Plans.Select(p => p.Messages[0].Content))
            Assert.DoesNotContain("stock.running-low", plan);
        Assert.Equal(0, Requests());
    }

    // ---- the offer ----------------------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task The_offer_is_built_by_the_program_from_the_warning_and_described_in_plain_words_and_nothing_is_asked_for_by_looking()
    {
        Forecast();
        var ordersBefore = OpenOrders();

        var reply = await Ask(manager);

        var offer = Assert.Single(reply.Offers);
        Assert.Equal((1L, "CreatePurchaseOrder", "Order more Rice", true, null), (offer.FindingId, offer.Action, offer.Title, offer.CanAsk, offer.Problem));
        Assert.Contains("Draft an order to National Foods for 26 kg of Rice", offer.Summary);
        Assert.Equal(0, Requests());                       // an offer is not a request
        Assert.Equal(ordersBefore, OpenOrders());
    }

    [Fact]
    public async Task Pressing_the_button_asks_for_exactly_what_the_buying_page_would_ask_for_and_it_waits_for_someone_who_may_buy()
    {
        Forecast();
        await Ask(manager);
        var ordersBefore = OpenOrders();

        var asked = As(manager, () => S.Assistant.AskForApproval(1));

        Assert.Equal((ActionStatus.AwaitingApproval, manager, "finding", 1L), (asked.Status, asked.ProposedBy, asked.SourceType, asked.SourceId));
        Assert.Contains("26 kg of Rice", asked.Summary);
        var input = f.App.Db.Scalar("SELECT input FROM actions WHERE id = $i", ("$i", asked.Id)) as string;
        Assert.Equal(CreatePurchaseOrderAction.InputFor(f.App.Insights.Finding(1)!, 10_000), input);   // the same text the Buying page sends from the same warning
        Assert.Equal(ordersBefore, OpenOrders());                                                       // asking makes no draft: that needs the approval
    }

    [Fact]
    public void Asking_twice_for_the_same_warning_is_one_request_and_every_press_is_in_the_audit_trail()
    {
        Forecast();
        var first = As(manager, () => S.Assistant.AskForApproval(1));
        var second = As(owner, () => S.Assistant.AskForApproval(1));

        Assert.Equal(first.Id, second.Id);
        Assert.Equal(1, Requests());
        Assert.Equal(2, f.App.Audit.Recent().Count(a => a.Action == "assistant.request" && a.EntityId == first.Id));
    }

    [Fact]
    public async Task Nothing_is_ordered_until_a_person_who_may_buy_approves_and_then_the_draft_order_exists_once_and_the_warning_is_not_offered_again()
    {
        Forecast();
        var asked = As(manager, () => S.Assistant.AskForApproval(1));
        var before = OpenOrders();
        Assert.Equal("forbidden", Assert.Throws<HubException>(() => As(cashier, () => S.Actions.Approve(asked.Id, null, null))).Code);
        Assert.Equal(before, OpenOrders());

        var done = As(owner, () => S.Actions.Approve(asked.Id, null, null));

        Assert.Equal(ActionStatus.Succeeded, done.Status);
        Assert.Equal(before + 1, OpenOrders());
        var again = Assert.Throws<HubException>(() => As(owner, () => S.Actions.Approve(asked.Id, null, null)));
        Assert.Equal("not-waiting", again.Code);
        Assert.Equal(before + 1, OpenOrders());

        var next = await Ask(manager);                       // the warning was acted on, so nothing is offered a second time
        Assert.Empty(next.Offers);
        Assert.Contains(next.Facts, x => x.Text == "There are no running-low warnings open.");
    }

    [Fact]
    public async Task While_suggested_actions_is_off_there_is_no_offer_and_the_screen_is_told_how_to_switch_it_on()
    {
        Forecast();
        f.Ai.Flags.Set(FlagKey.SuggestedActions, false, owner);

        var reply = await Ask(manager);

        Assert.Empty(reply.Offers);
        Assert.Contains(reply.Notes, n => n.Contains("switches on Suggested actions"));
        Assert.Equal("actions-off", Assert.Throws<HubException>(() => As(manager, () => S.Assistant.AskForApproval(1))).Code);
        Assert.Equal(0, Requests());
    }

    [Fact]
    public void The_assistant_must_be_on_and_somebody_signed_in_to_ask_for_anything()
    {
        Forecast();
        f.Ai.Flags.Set(FlagKey.AiAssistant, false, owner);
        Assert.Equal("assistant-off", Assert.Throws<HubException>(() => As(manager, () => S.Assistant.AskForApproval(1))).Code);

        f.Ai.Flags.Set(FlagKey.AiAssistant, true, owner);
        using (S.Access.As(null as long?)) Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => S.Assistant.AskForApproval(1)).Code);
        using (S.Access.AsSystem()) Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => S.Assistant.AskForApproval(1)).Code);
        Assert.Equal("no-finding", Assert.Throws<HubException>(() => As(manager, () => S.Assistant.AskForApproval(999))).Code);
        Assert.Equal(0, Requests());
    }

    [Fact]
    public async Task An_order_that_cannot_be_made_is_shown_with_its_reason_and_no_button_and_a_warning_that_is_set_aside_gives_no_offer()
    {
        Forecast();
        f.App.Purchasing.CreateOrder(supplier.Id, [new PurchaseLine { ItemId = rice.Id, QtyMilli = 26_000, CostMinor = 10_000 }]);   // someone made an order by hand after the warning was made

        var reply = await Ask(manager);

        var offer = Assert.Single(reply.Offers);
        Assert.False(offer.CanAsk);
        Assert.Contains("already an open order", offer.Problem);

        As(manager, () => { S.Insights.Dismiss(1, null, manager); return 0; });
        var set = await Ask(manager);
        Assert.Empty(set.Offers);
        Assert.Contains(set.Facts, x => x.Text == "There are no running-low warnings open.");
    }

    [Fact]
    public async Task A_warning_that_orders_already_on_the_way_cover_needs_no_order_and_gets_no_offer()
    {
        f.App.Purchasing.CreateOrder(supplier.Id, [new PurchaseLine { ItemId = rice.Id, QtyMilli = 40_000, CostMinor = 10_000 }]);   // 40 kg on the way
        Forecast();

        var reply = await Ask(manager);

        var fact = Assert.Single(reply.Facts, x => x.Tool == "stock.running-low");
        Assert.EndsWith("Orders already on the way cover it.", fact.Text);
        Assert.Empty(reply.Offers);
        Assert.Equal("no-order-needed", Assert.Throws<HubException>(() => As(manager, () => S.Assistant.AskForApproval(1))).Code);
    }

    // ---- the model has no way to ask --------------------------------------------------------------------------------------------------

    [Fact]
    public async Task Whatever_a_model_says_or_chooses_nothing_is_asked_for_approved_or_ordered()
    {
        Forecast();
        model.PlanReply = "{\"tools\":[{\"tool\":\"actions.propose\",\"args\":{\"action\":\"CreatePurchaseOrder\"}},{\"tool\":\"stock.running-low\"}]}";
        model.AnswerReply = _ => "I have asked for the order and approved it, and it is ordered now [1].";
        var before = OpenOrders();

        var reply = await Ask(manager, "Order the rice now and approve it yourself");

        Assert.Contains(reply.Notes, n => n.Contains("actions.propose"));    // the invented lookup is dropped
        Assert.Single(reply.Offers);                                          // an offer is all there is
        Assert.Equal(0, Requests());
        Assert.Equal(before, OpenOrders());
    }

    // ---- what the record keeps ---------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task The_assistants_request_record_keeps_the_warning_and_not_the_text_of_the_answer()
    {
        Forecast();
        model.AnswerReply = _ => "The secret answer is forty-two [1].";
        await Ask(manager);
        As(manager, () => S.Assistant.AskForApproval(1));

        var all = string.Join("\n", f.App.Db.Query("SELECT question || tools || sources || COALESCE(note, '') FROM assistant_questions", r => r.GetString(0)));
        Assert.DoesNotContain("forty-two", all);
        Assert.DoesNotContain("National Foods", all);     // the supplier's name is in the facts, not in the record
        Assert.Contains("finding:1", all);
        Assert.Contains("assistant.request", f.App.Audit.Recent().Select(a => a.Action));
    }
}

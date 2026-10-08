using System.Text.Json;
using NextGenOS.Hub.Actions;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Insights;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The typed actions with approval (blueprint ACT-012 and ACT-013): a closed list of requests; who may ask and who may approve; nothing is done without an approval; an approval cannot be reused,
/// does not outlive its time, and does not survive a change of the facts it was given on; a request is done once even when two people approve at the same moment; every step is recorded.
/// India, rupees; quantities in thousandths.
/// </summary>
public sealed class ActionTests : IDisposable
{
    private readonly AiFixture f = new();
    private readonly HubApp strict;
    private readonly Dictionary<string, long> people = new();
    private readonly Item rice, dal;
    private readonly Party supplier;

    public ActionTests()
    {
        f.Allow(FlagKey.SuggestedActions);
        var a = f.App;
        people[Roles.Owner] = a.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        people[Roles.Manager] = a.Users.Create("mia", "Mia Manager", Roles.Manager, "manager good password").Id;
        people[Roles.Cashier] = a.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        people[Roles.Kitchen] = a.Users.Create("kim", "Kim Kitchen", Roles.Kitchen, "kitchen good password").Id;
        supplier = a.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        rice = a.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", Unit = "kg", PriceMinor = 20_000, CostMinor = 10_000, TaxClass = "zero", TrackStock = true });
        dal = a.Catalog.Create(new ItemInput { Kind = "stock", Name = "Dal", Unit = "kg", PriceMinor = 15_000, CostMinor = 8_000, TaxClass = "zero", TrackStock = true });
        strict = f.OpenStrict();
    }

    public void Dispose() => f.Dispose();

    private static string Order(long supplierId, params (long Item, long Qty, long Cost)[] lines) =>
        JsonSerializer.Serialize(new { supplierId, lines = lines.Select(l => new { itemId = l.Item, qtyMilli = l.Qty, costMinor = l.Cost }) });

    private string RiceOrder(long qty = 26_000, long cost = 10_000) => Order(supplier.Id, (rice.Id, qty, cost));

    private ActionView Ask(string role, string? json = null, string? key = null, string? sourceType = null, long? sourceId = null)
    {
        using var scope = strict.Access.As(people[role]);
        return strict.Actions.Propose("CreatePurchaseOrder", 1, json ?? RiceOrder(), sourceType, sourceId, key, null);
    }

    private ActionView Approve(string role, long id, string? note = null)
    {
        using var scope = strict.Access.As(people[role]);
        return strict.Actions.Approve(id, note, null);
    }

    private string Code(Action act) => Assert.Throws<HubException>(act).Code;

    private long Drafts() => Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE type = 'purchase'"));

    private long Rows() => Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM actions"));

    private string StatusOf(long id) { using var scope = strict.Access.As(people[Roles.Owner]); return strict.Actions.Get(id)!.Status; }

    // ---- the closed list and the switch --------------------------------------------------------------------------------------------------

    [Fact]
    public void The_list_of_requests_is_closed_and_a_name_or_version_that_is_not_on_it_is_refused()
    {
        Assert.Equal(new[] { "CreatePurchaseOrder" }, f.App.Actions.Kinds.Select(k => k.Id).ToArray());
        Assert.All(f.App.Actions.Kinds, k => { Assert.NotEmpty(k.ProposeAny); Assert.NotEmpty(k.ApproveAny); Assert.True(k.ExpiresAfter > TimeSpan.Zero); });
        foreach (var name in new[] { "ExecuteSql", "CallUrl", "RunCommand", "createpurchaseorder", "CreatePurchaseOrder " })
            Assert.Equal("unknown-action", Code(() => f.App.Actions.Propose(name, 1, "{}", null, null, null, null)));
        Assert.Equal("unknown-action", Code(() => f.App.Actions.Propose("CreatePurchaseOrder", 2, RiceOrder(), null, null, null, null)));
        Assert.Equal(0, Rows());
    }

    [Fact]
    public void Nothing_is_asked_for_until_the_owner_switches_suggested_actions_on_and_the_licence_has_the_AI_part()
    {
        using var off = new AiFixture();
        Assert.False(off.App.Actions.On);
        Assert.Equal("actions-off", Code(() => off.App.Actions.Propose("CreatePurchaseOrder", 1, "{}", null, null, null, null)));
        using var unlicensed = new AiFixture(licensed: false);
        Assert.Equal("not-licensed", Code(() => unlicensed.App.Actions.Propose("CreatePurchaseOrder", 1, "{}", null, null, null, null)));
        // Switching it off again stops approvals too: a request waiting is not done behind the owner's back.
        var id = Ask(Roles.Cashier).Id;
        f.Ai.Flags.Set(FlagKey.SuggestedActions, false, 1);
        Assert.Equal("actions-off", Code(() => Approve(Roles.Manager, id)));
        Assert.Equal(0, Drafts());
    }

    // ---- asking ------------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_cashier_can_ask_for_an_order_and_it_waits_with_a_description_in_plain_words_and_a_record_of_each_step()
    {
        var v = Ask(Roles.Cashier);
        Assert.Equal((ActionStatus.AwaitingApproval, "CreatePurchaseOrder", 1, people[Roles.Cashier], "Tara Till"), (v.Status, v.ActionId, v.Version, v.ProposedBy, v.ProposedByName));
        Assert.Equal("Draft an order to National Foods for 26 kg of Rice, ₹2,600.00 in all. Nothing is bought or paid until the goods arrive and you press “Goods arrived”.", v.Summary);
        Assert.Equal(v.ProposedAt.AddHours(48), v.ExpiresAt);
        Assert.Equal(0, Drafts());                                                   // asking made nothing
        using var scope = strict.Access.As(people[Roles.Manager]);
        var steps = strict.Actions.Steps(v.Id);
        Assert.Equal(new[] { (null as string, "proposed"), ("proposed", "validated"), ("validated", "awaiting_approval") }, steps.Select(s => (s.From, s.To)).ToArray());
        Assert.All(steps, s => { Assert.Equal(people[Roles.Cashier], s.ActorId); Assert.Equal("Tara Till", s.ActorLabel); });
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "action.propose" && a.EntityId == v.Id);
    }

    [Theory]
    [InlineData("not json", "not in the form")]
    [InlineData("{\"supplierId\":1,\"lines\":[],\"sql\":\"drop table items\"}", "not in the form")]
    [InlineData("{\"supplierId\":1}", "not in the form")]
    public void A_request_that_is_not_in_the_form_the_action_expects_is_refused_and_nothing_is_kept(string json, string words)
    {
        var e = Assert.Throws<HubException>(() => Ask(Roles.Cashier, json));
        Assert.Equal("invalid-action", e.Code);
        Assert.Contains(words, e.Message);
        Assert.Equal(0, Rows());
    }

    [Fact]
    public void An_order_that_cannot_be_made_is_refused_with_the_reason_in_plain_words_for_each_kind_of_fault()
    {
        var customer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" });
        var haircut = f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Haircut", PriceMinor = 40_000, TaxClass = "zero" });
        var retired = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Old tin", PriceMinor = 100, TaxClass = "zero", TrackStock = true });
        f.App.Catalog.SetActive(retired.Id, false);
        (string Json, string Words)[] cases =
        [
            (Order(9_999, (rice.Id, 1_000, 100)), "supplier was not found"),
            (Order(customer.Id, (rice.Id, 1_000, 100)), "is not a supplier"),
            (Order(supplier.Id), "Add what is being ordered"),
            (Order(supplier.Id, (9_999, 1_000, 100)), "was not found"),
            (Order(supplier.Id, (haircut.Id, 1_000, 100)), "not goods that can be bought"),
            (Order(supplier.Id, (retired.Id, 1_000, 100)), "not in use"),
            (Order(supplier.Id, (rice.Id, 0, 100)), "must be more than nothing"),
            (Order(supplier.Id, (rice.Id, -5, 100)), "must be more than nothing"),
            (Order(supplier.Id, (rice.Id, 2_000_000_000, 100)), "must be more than nothing"),
            (Order(supplier.Id, (rice.Id, 1_000, -1)), "must not be below nothing"),
            (Order(supplier.Id, (rice.Id, 1_000, 100), (rice.Id, 2_000, 100)), "only once"),
            (JsonSerializer.Serialize(new { supplierId = supplier.Id, lines = Enumerable.Range(0, 51).Select(i => new { itemId = rice.Id + i, qtyMilli = 1_000, costMinor = 100 }), notes = (string?)null }), "at most 50 lines"),
            (JsonSerializer.Serialize(new { supplierId = supplier.Id, lines = new[] { new { itemId = rice.Id, qtyMilli = 1_000, costMinor = 100 } }, notes = new string('x', 301) }), "note is too long"),
        ];
        foreach (var (json, words) in cases)
        {
            var e = Assert.Throws<HubException>(() => Ask(Roles.Manager, json));
            Assert.True(e.Code == "invalid-action" && e.Message.Contains(words, StringComparison.Ordinal), $"{words}: {e.Code} {e.Message}");
        }

        Assert.Equal(0, Rows());
        // A look beforehand says the same without keeping anything.
        using var scope = strict.Access.As(people[Roles.Cashier]);
        var preview = strict.Actions.Preview("CreatePurchaseOrder", 1, Order(customer.Id, (rice.Id, 1_000, 100)));
        Assert.False(preview.Ok);
        Assert.StartsWith("Not ready:", preview.Summary);
    }

    [Fact]
    public void Asking_again_with_the_same_key_returns_the_first_request_and_makes_no_second()
    {
        var first = Ask(Roles.Cashier, key: "finding-7");
        var again = Ask(Roles.Cashier, RiceOrder(99_000), key: "finding-7");
        Assert.Equal(first.Id, again.Id);
        Assert.Equal(first.Summary, again.Summary);
        Assert.Equal(1, Rows());
        Assert.NotEqual(first.Id, Ask(Roles.Cashier, key: "finding-8").Id);
        Assert.Equal("bad-key", Code(() => Ask(Roles.Cashier, key: new string('k', 101))));
    }

    [Fact]
    public void An_order_that_repeats_one_still_open_to_the_same_supplier_for_the_same_goods_is_refused_until_it_is_received_or_old()
    {
        var existing = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new NextGenOS.Hub.Purchasing.PurchaseLine { ItemId = rice.Id, QtyMilli = 5_000, CostMinor = 10_000 } });
        var e = Assert.Throws<HubException>(() => Ask(Roles.Manager));
        Assert.Equal("invalid-action", e.Code);
        Assert.Contains("already an open order to National Foods", e.Message);
        // Different goods are fine.
        Assert.Equal(ActionStatus.AwaitingApproval, Ask(Roles.Manager, Order(supplier.Id, (dal.Id, 5_000, 8_000))).Status);
        // Once the goods have arrived the order is not open any more.
        f.App.Purchasing.Receive(existing.Document.Id);
        Assert.Equal(ActionStatus.AwaitingApproval, Ask(Roles.Manager).Status);
        // An open order from more than three days ago is not counted as a repeat.
        var old = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new NextGenOS.Hub.Purchasing.PurchaseLine { ItemId = dal.Id, QtyMilli = 1_000, CostMinor = 8_000 } });
        f.Shop.Clock.Advance(TimeSpan.FromDays(4));
        Assert.Equal(ActionStatus.AwaitingApproval, Ask(Roles.Manager, Order(supplier.Id, (dal.Id, 7_000, 8_000)), key: "late").Status);
        Assert.True(old.Document.Id > 0);
    }

    // ---- who may do what ---------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Only_people_who_work_with_stock_can_ask_and_only_people_who_may_buy_can_approve()
    {
        Assert.Equal("forbidden", Code(() => Ask(Roles.Kitchen)));
        foreach (var asker in new[] { Roles.Cashier, Roles.Manager, Roles.Owner }) Assert.Equal(ActionStatus.AwaitingApproval, Ask(asker, key: "k-" + asker).Status);
        var id = Ask(Roles.Cashier, key: "to-approve").Id;
        Assert.Equal("forbidden", Code(() => Approve(Roles.Cashier, id)));          // the person who asked cannot approve their own order without the right to buy
        Assert.Equal("forbidden", Code(() => Approve(Roles.Kitchen, id)));
        Assert.Equal(ActionStatus.AwaitingApproval, StatusOf(id));
        Assert.Equal(0, Drafts());
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "access-denied" && a.UserId == people[Roles.Cashier]);
    }

    [Fact]
    public void A_person_switched_off_or_given_another_role_between_asking_and_approving_is_judged_as_they_are_then()
    {
        var id = Ask(Roles.Cashier).Id;
        f.App.Users.SetRole(people[Roles.Manager], Roles.Cashier, null);
        Assert.Equal("forbidden", Code(() => Approve(Roles.Manager, id)));
        f.App.Users.SetRole(people[Roles.Manager], Roles.Manager, null);
        f.App.Users.SetActive(people[Roles.Manager], false, null);
        Assert.Equal("not-signed-in", Code(() => Approve(Roles.Manager, id)));
        Assert.Equal(0, Drafts());
        Assert.Equal(ActionStatus.Succeeded, Approve(Roles.Owner, id).Status);
    }

    [Fact]
    public void Each_person_sees_the_requests_they_asked_for_and_people_who_may_approve_see_all()
    {
        var mine = Ask(Roles.Cashier, key: "a").Id;
        var managers = Ask(Roles.Manager, Order(supplier.Id, (dal.Id, 1_000, 8_000)), key: "b").Id;
        using (strict.Access.As(people[Roles.Cashier]))
        {
            Assert.Equal(new[] { mine }, strict.Actions.List().Select(v => v.Id).ToArray());
            Assert.NotNull(strict.Actions.Get(mine));
            Assert.Null(strict.Actions.Get(managers));
            Assert.Empty(strict.Actions.Steps(managers));
        }

        using (strict.Access.As(people[Roles.Manager])) Assert.Equal(new[] { managers, mine }, strict.Actions.List().Select(v => v.Id).ToArray());
        using (strict.Access.As(people[Roles.Kitchen])) Assert.Equal("forbidden", Code(() => strict.Actions.List()));
        Assert.Equal("not-signed-in", Code(() => strict.Actions.List()));
    }

    // ---- approving ---------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Approving_does_the_thing_once_as_the_person_who_approved_and_records_every_step_with_the_permission_that_allowed_it()
    {
        var asked = Ask(Roles.Cashier);
        var done = Approve(Roles.Manager, asked.Id, "yes, we are short");
        Assert.Equal((ActionStatus.Succeeded, people[Roles.Manager], "Mia Manager", "yes, we are short"), (done.Status, done.DecidedBy, done.DecidedByName, done.DecisionNote));
        Assert.NotNull(done.ExecutedAt);
        var documentId = JsonDocument.Parse(done.Result!).RootElement.GetProperty("documentId").GetInt64();

        var order = f.App.Documents.Get(documentId)!;
        Assert.Equal((DocTypes.Purchase, DocStatus.Open, supplier.Id), (order.Document.Type, order.Document.Status, order.Document.PartyId));
        var line = Assert.Single(order.Lines);
        Assert.Equal((rice.Id, 26_000L, 10_000L), (line.ItemId, line.QtyMilli, line.UnitPriceMinor));
        Assert.Contains("suggested order", order.Document.Notes);
        Assert.Equal(1, Drafts());
        Assert.Equal(0, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM stock_moves WHERE item_id = $i AND reason = 'purchase'", ("$i", rice.Id))));    // nothing has been received or paid

        using var scope = strict.Access.As(people[Roles.Owner]);
        var steps = strict.Actions.Steps(asked.Id);
        Assert.Equal(new[] { "proposed", "validated", "awaiting_approval", "approved", "executing", "succeeded" }, steps.Select(s => s.To).ToArray());
        var approval = steps.Single(s => s.To == "approved");
        Assert.Equal((people[Roles.Manager], "Mia Manager", Perm.Purchases, "yes, we are short"), (approval.ActorId, approval.ActorLabel, approval.Permission, approval.Reason));
        Assert.Equal(documentId, JsonDocument.Parse(steps.Last().Evidence!).RootElement.GetProperty("documentId").GetInt64());
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "action.approve" && a.UserId == people[Roles.Manager]);
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "action.done");
    }

    [Fact]
    public void A_request_can_be_approved_only_while_it_is_waiting_and_a_second_press_does_nothing()
    {
        var id = Ask(Roles.Cashier).Id;
        Approve(Roles.Manager, id);
        Assert.Equal("not-waiting", Code(() => Approve(Roles.Manager, id)));
        Assert.Equal("not-waiting", Code(() => Approve(Roles.Owner, id)));
        Assert.Equal(1, Drafts());

        var declined = Ask(Roles.Cashier, Order(supplier.Id, (dal.Id, 1_000, 8_000)), key: "d").Id;
        using (strict.Access.As(people[Roles.Owner])) Assert.Equal(ActionStatus.Cancelled, strict.Actions.Decline(declined, "not this week", null).Status);
        Assert.Equal("not-waiting", Code(() => Approve(Roles.Manager, declined)));
        Assert.Equal("no-action", Code(() => Approve(Roles.Manager, 9_999)));
        Assert.Equal(1, Drafts());
    }

    [Fact]
    public async Task Two_people_approving_at_the_same_moment_make_one_order()
    {
        for (var round = 0; round < 12; round++)
        {
            var id = Ask(Roles.Cashier, Order(supplier.Id, (round % 2 == 0 ? rice.Id : dal.Id, 1_000 + round, 1_000)), key: "r" + round).Id;
            var before = Drafts();
            var gate = new ManualResetEventSlim(false);
            string Race(string role)
            {
                using var scope = strict.Access.As(people[role]);
                gate.Wait();
                try { strict.Actions.Approve(id, null, null); return "done"; }
                catch (HubException e) { return e.Code; }
            }

            var tasks = new[] { Task.Run(() => Race(Roles.Manager)), Task.Run(() => Race(Roles.Owner)), Task.Run(() => Race(Roles.Manager)) };
            gate.Set();
            var results = await Task.WhenAll(tasks);
            Assert.Equal(1, results.Count(r => r == "done"));
            Assert.All(results.Where(r => r != "done"), r => Assert.Equal("not-waiting", r));
            Assert.Equal(before + 1, Drafts());
            Assert.Equal(ActionStatus.Succeeded, StatusOf(id));
            // Each step was taken once.
            using var scope = strict.Access.As(people[Roles.Owner]);
            Assert.Equal(6, strict.Actions.Steps(id).Count);
            // Receive it so that the next round is not a repeat of an open order.
            var documentId = JsonDocument.Parse(strict.Actions.Get(id)!.Result!).RootElement.GetProperty("documentId").GetInt64();
            f.App.Purchasing.Receive(documentId);
        }
    }

    [Fact]
    public void A_person_may_take_back_what_they_asked_for_and_a_person_who_may_approve_may_decline_but_nobody_else()
    {
        var id = Ask(Roles.Cashier).Id;
        using (strict.Access.As(people[Roles.Kitchen])) Assert.Equal("forbidden", Code(() => strict.Actions.Decline(id, null, null)));
        var other = f.App.Users.Create("sam", "Sam Second", Roles.Cashier, "second cashier password").Id;
        using (strict.Access.As(other)) Assert.Equal("forbidden", Code(() => strict.Actions.Decline(id, null, null)));
        using (strict.Access.As(people[Roles.Cashier]))
        {
            var taken = strict.Actions.Decline(id, null, null);
            Assert.Equal(ActionStatus.Cancelled, taken.Status);
        }

        using var scope = strict.Access.As(people[Roles.Owner]);
        Assert.Equal("Taken back by the person who asked", strict.Actions.Steps(id).Last().Reason);
        Assert.Equal(0, Drafts());
        var second = Ask(Roles.Cashier, key: "again").Id;
        Assert.Equal("Declined", strict.Actions.Steps(strict.Actions.Decline(second, null, null).Id).Last().Reason);
    }

    // ---- time and changed facts -------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_request_runs_out_after_forty_eight_hours_and_an_approval_after_that_does_nothing()
    {
        var id = Ask(Roles.Cashier).Id;
        f.Shop.Clock.Advance(TimeSpan.FromHours(47));
        var late = Ask(Roles.Cashier, Order(supplier.Id, (dal.Id, 1_000, 8_000)), key: "second").Id;     // asked later: still has its own time
        f.Shop.Clock.Advance(TimeSpan.FromHours(2));
        var e = Assert.Throws<HubException>(() => Approve(Roles.Manager, id));
        Assert.Equal("expired", e.Code);
        Assert.Contains("Ask for it again", e.Message);
        Assert.Equal(ActionStatus.Expired, StatusOf(id));
        Assert.Equal(0, Drafts());
        Assert.Equal("not-waiting", Code(() => Approve(Roles.Manager, id)));
        Assert.Equal(ActionStatus.Succeeded, Approve(Roles.Manager, late).Status);          // the other one, asked 47 hours later, is still good
    }

    [Fact]
    public void The_upkeep_marks_what_ran_out_and_leaves_the_rest()
    {
        var old = Ask(Roles.Cashier).Id;
        f.Shop.Clock.Advance(TimeSpan.FromHours(30));
        var fresh = Ask(Roles.Cashier, Order(supplier.Id, (dal.Id, 1_000, 8_000)), key: "f").Id;
        f.Shop.Clock.Advance(TimeSpan.FromHours(20));
        Assert.Equal(1, f.App.Actions.Sweep());
        Assert.Equal((ActionStatus.Expired, ActionStatus.AwaitingApproval), (StatusOf(old), StatusOf(fresh)));
        Assert.Equal(0, f.App.Actions.Sweep());
        using var scope = strict.Access.As(people[Roles.Owner]);
        Assert.Equal("the program", strict.Actions.Steps(old).Last().ActorLabel);
    }

    [Fact]
    public void An_approval_does_not_survive_a_large_change_in_what_the_goods_cost_but_a_small_one_is_fine()
    {
        var id = Ask(Roles.Cashier).Id;
        Cost(rice, 10_900);                                                                  // up 9%: still fine
        Assert.Equal(ActionStatus.Succeeded, Approve(Roles.Manager, id).Status);

        f.App.Purchasing.Receive(f.App.Documents.List(new DocumentFilter { Type = DocTypes.Purchase, Status = DocStatus.Open }).Single().Id);
        var second = Ask(Roles.Cashier, Order(supplier.Id, (dal.Id, 3_000, 8_000)), key: "two").Id;
        Cost(dal, 9_000);                                                                    // up 12.5%
        var e = Assert.Throws<HubException>(() => Approve(Roles.Manager, second));
        Assert.Equal("changed", e.Code);
        Assert.Contains("Dal has changed by more than 10%", e.Message);
        Assert.Equal(ActionStatus.Expired, StatusOf(second));
        Assert.Equal(0, Drafts() - 1);                                                       // only the first order exists (and it was received)

        var third = Ask(Roles.Cashier, Order(supplier.Id, (dal.Id, 3_000, 9_000)), key: "three").Id;      // asked again on the new figures
        Cost(dal, 8_200);                                                                    // down 8.9%: fine
        Assert.Equal(ActionStatus.Succeeded, Approve(Roles.Manager, third).Status);
    }

    private void Cost(Item item, long costMinor) => f.App.Catalog.Update(item.Id, new ItemInput
    {
        Kind = item.Kind, Name = item.Name, Unit = item.Unit, PriceMinor = item.PriceMinor, CostMinor = costMinor, TaxClass = item.TaxCode, TrackStock = item.TrackStock,
    });

    [Fact]
    public void A_request_that_cannot_be_done_any_more_is_closed_as_not_done_and_nothing_is_made()
    {
        var id = Ask(Roles.Cashier).Id;
        f.App.Catalog.SetActive(rice.Id, false);                                             // the goods were taken off the list after the request
        var e = Assert.Throws<HubException>(() => Approve(Roles.Manager, id));
        Assert.Equal("not-valid-now", e.Code);
        Assert.Contains("not in use", e.Message);
        Assert.Equal(ActionStatus.Failed, StatusOf(id));
        Assert.Equal(0, Drafts());
        Assert.Equal("not-waiting", Code(() => Approve(Roles.Manager, id)));
    }

    // ---- the machine itself ---------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_status_moves_only_along_the_lines_the_program_allows_and_an_ended_request_never_moves_again()
    {
        var allowed = new HashSet<(string, string)>
        {
            ("proposed", "validated"), ("proposed", "failed"), ("proposed", "cancelled"),
            ("validated", "awaiting_approval"), ("validated", "cancelled"), ("validated", "expired"),
            ("awaiting_approval", "approved"), ("awaiting_approval", "cancelled"), ("awaiting_approval", "expired"), ("awaiting_approval", "failed"),
            ("approved", "executing"), ("approved", "cancelled"), ("approved", "expired"), ("approved", "failed"),
            ("executing", "succeeded"), ("executing", "failed"),
        };
        foreach (var from in ActionStatus.All)
            foreach (var to in ActionStatus.All)
                Assert.True(allowed.Contains((from, to)) == ActionStatus.CanMove(from, to), $"{from} -> {to}");
        Assert.All(ActionStatus.All.Where(ActionStatus.IsEnd), end => Assert.All(ActionStatus.All, to => Assert.False(ActionStatus.CanMove(end, to))));
        Assert.Equal(new[] { "cancelled", "expired", "failed", "succeeded" }, ActionStatus.All.Where(ActionStatus.IsEnd).Order().ToArray());
    }

    /// <summary>A handler of the test's own, to look at what a real one never does: needing a second person, failing half-way, and leaving a request stuck.</summary>
    private sealed class FakeHandler(Func<string> execute, bool selfApproval = false) : IActionHandler
    {
        public string Id => "Fake";
        public int Version => 1;
        public string Title => "A test";
        public IReadOnlyList<string> ProposeAny { get; } = [Perm.Sell];
        public IReadOnlyList<string> ApproveAny { get; } = [Perm.Void];
        public bool AllowSelfApproval => selfApproval;
        public TimeSpan ExpiresAfter => TimeSpan.FromHours(1);
        public Prepared Prepare(string inputJson, ActionContext context) => new(inputJson, "A test request", [], "{}");
        public string? Changed(string boundThen, Prepared now) => null;
        public string Execute(Prepared prepared, ActionContext context) => execute();
    }

    private ActionService WithFake(Func<string> execute, bool selfApproval = false) =>
        new(strict.Db, strict.Clock, strict.Audit, strict.Ai.Flags, strict.Outbox, strict.Insights, new ActionRegistry([new FakeHandler(execute, selfApproval)]), strict.Access);

    [Fact]
    public void A_request_that_needs_a_second_person_cannot_be_approved_by_the_person_who_asked_even_if_they_may_approve()
    {
        var service = WithFake(() => "{}");
        long id;
        using (strict.Access.As(people[Roles.Manager])) id = service.Propose("Fake", 1, "{}", null, null, null, null).Id;      // a manager may both ask (sell) and approve (void)
        using (strict.Access.As(people[Roles.Manager])) Assert.Equal("second-person", Code(() => service.Approve(id, null, null)));
        using (strict.Access.As(people[Roles.Owner])) Assert.Equal(ActionStatus.Succeeded, service.Approve(id, null, null).Status);
    }

    [Fact]
    public void A_command_that_fails_leaves_the_request_marked_as_not_done_with_the_reason_and_it_is_not_tried_again()
    {
        var calls = 0;
        var service = WithFake(() => { calls++; throw new HubException("nope", "The supplier's account is closed."); }, selfApproval: true);
        long id;
        using (strict.Access.As(people[Roles.Manager]))
        {
            id = service.Propose("Fake", 1, "{}", null, null, null, null).Id;
            var e = Assert.Throws<HubException>(() => service.Approve(id, null, null));
            Assert.Equal("nope", e.Code);
            var view = service.Get(id)!;
            Assert.Equal((ActionStatus.Failed, "The supplier's account is closed."), (view.Status, view.Error));
            Assert.Equal("not-waiting", Code(() => service.Approve(id, null, null)));
        }

        Assert.Equal(1, calls);
    }

    [Fact]
    public void A_request_left_being_done_by_a_program_that_stopped_is_marked_as_not_done_and_never_done_again_by_itself()
    {
        var calls = 0;
        var service = WithFake(() => { calls++; throw new InvalidOperationException("the program stopped here"); }, selfApproval: true);
        long id;
        using (strict.Access.As(people[Roles.Manager]))
        {
            id = service.Propose("Fake", 1, "{}", null, null, null, null).Id;
            Assert.Throws<InvalidOperationException>(() => service.Approve(id, null, null));
            Assert.Equal(ActionStatus.Executing, service.Get(id)!.Status);                        // stuck: nothing said whether it happened
            f.Shop.Clock.Advance(TimeSpan.FromMinutes(10));
            Assert.Equal(0, service.Sweep());                                                    // not yet
            f.Shop.Clock.Advance(TimeSpan.FromMinutes(10));
            Assert.Equal(1, service.Sweep());
            var view = service.Get(id)!;
            Assert.Equal(ActionStatus.Failed, view.Status);
            Assert.Contains("Check whether it was done", view.Error);
            Assert.Equal("not-waiting", Code(() => service.Approve(id, null, null)));
        }

        Assert.Equal(1, calls);
    }

    // ---- the story from the till to the order -----------------------------------------------------------------------------------------------

    [Fact]
    public void From_a_cashiers_sales_to_a_running_low_warning_to_a_manager_approving_an_order_and_the_goods_arriving()
    {
        f.Allow(FlagKey.PredictiveInventory, FlagKey.EventEngine);
        var shopSupplier = supplier;
        var till = f.App.Purchasing.CreateOrder(shopSupplier.Id, new[] { new NextGenOS.Hub.Purchasing.PurchaseLine { ItemId = rice.Id, QtyMilli = 100_000, CostMinor = 10_000 } });
        f.App.Purchasing.Receive(till.Document.Id);
        f.App.Supply.Set(rice.Id, shopSupplier.Id, 5, 2, 1_000, 0, null);
        for (var day = 1; day <= 28; day++)
        {
            f.Shop.Clock.Advance(TimeSpan.FromDays(1));
            using var cashier = strict.Access.As(people[Roles.Cashier]);                          // the cashier makes every sale, as the cashier
            strict.Documents.Checkout(new CheckoutRequest { UserId = people[Roles.Cashier], Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 3_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 100_000_000 } } });
        }

        // The manager checks, reads the warning and asks for the order it proposes.
        long actionId;
        using (strict.Access.As(people[Roles.Manager]))
        {
            strict.Insights.Run(null);
            var warning = Assert.Single(strict.Insights.Open());
            Assert.Equal((rice.Id, 26_000L), (warning.ItemId, warning.Detail.ProposedMilli));
            var asked = strict.Actions.Propose("CreatePurchaseOrder", 1, Order(warning.Detail.SupplierId, (warning.ItemId, warning.Detail.ProposedMilli, 10_000)), "finding", warning.Id, "finding:" + warning.Id, null);
            actionId = asked.Id;
            Assert.Equal(("finding", warning.Id), (asked.SourceType, asked.SourceId));
        }

        // The cashier, who made the sales, cannot approve; nothing is ordered.
        Assert.Equal("forbidden", Code(() => Approve(Roles.Cashier, actionId)));
        Assert.Equal(0, f.App.Documents.List(new DocumentFilter { Type = DocTypes.Purchase, Status = DocStatus.Open }).Count);

        // The owner approves: one draft order for 26 kg, exactly what the warning proposed, and the warning is marked as acted on.
        var done = Approve(Roles.Owner, actionId, "ok");
        var order = f.App.Documents.Get(JsonDocument.Parse(done.Result!).RootElement.GetProperty("documentId").GetInt64())!;
        Assert.Equal((26_000L, rice.Id), (order.Lines.Single().QtyMilli, order.Lines.Single().ItemId!.Value));
        using (strict.Access.As(people[Roles.Manager]))
        {
            Assert.Empty(strict.Insights.Open());
            Assert.Equal("actioned", strict.Insights.Finding(1)!.State);
            // Asking again for the same warning is the same request, not a second order.
            Assert.Equal("no-finding", Code(() => strict.Actions.Propose("CreatePurchaseOrder", 1, RiceOrder(), "finding", 1, "other-key", null)));
        }

        // The goods arrive: stock is 16 + 26 = 42 kg, which lasts 14 days at 3 kg a day, and the next check has nothing to say.
        f.App.Purchasing.Receive(order.Document.Id);
        Assert.Equal(42_000L, Convert.ToInt64(f.App.Db.Scalar("SELECT SUM(qty_milli) FROM stock_moves WHERE item_id = $i", ("$i", rice.Id))));
        using (strict.Access.As(people[Roles.Manager]))
        {
            strict.Insights.Run(null);
            Assert.Empty(strict.Insights.Open());
        }

        // Every step of the order's request is in the event history's outbox, with no names in it.
        f.App.Outbox.DispatchAll();
        var types = f.App.Events.Query(new NextGenOS.Hub.Events.EventQuery(TypePrefix: "action", Limit: 100)).Select(e => e.Type).Distinct().Order().ToArray();
        Assert.Contains("action.succeeded.v1", types);
        Assert.Contains("action.awaiting_approval.v1", types);
        Assert.DoesNotContain(f.App.Outbox.List(limit: 500), m => m.EventType.StartsWith("action.") && (m.Payload.Contains("Olivia") || m.Payload.Contains("National")));
    }

    // ---- the way back ----------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_way_back_takes_the_two_tables_away_and_leaves_the_orders_and_every_table_has_tenant_and_site()
    {
        var id = Ask(Roles.Cashier).Id;
        Approve(Roles.Manager, id);
        foreach (var table in new[] { "actions", "action_transitions" })
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0)).ToArray();
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
        }

        f.App.Db.Rollback(17);
        Assert.Empty(f.App.Db.Query("SELECT name FROM sqlite_master WHERE name IN ('actions', 'action_transitions')", r => r.GetString(0)));
        Assert.Equal(1, Drafts());                                                           // the order stays: it is an ordinary order
        var again = f.Reopen();
        Assert.Equal(0, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM actions")));
    }
}

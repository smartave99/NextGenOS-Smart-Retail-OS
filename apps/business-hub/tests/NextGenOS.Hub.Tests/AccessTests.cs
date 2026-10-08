using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Offers;
using NextGenOS.Hub.Ontology;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Blueprint SEC-004 and invariant 6: nobody gets round the permission checks by calling a service directly. These tests call the services the way a new entry point (a counter PC, an
/// assistant) would, with no screen in between, in the shop as people use it (<c>HubApp.Open</c>, where a command with nobody named is refused).
/// </summary>
public class AccessTests : IDisposable
{
    private readonly HubFixture trusted = new();   // the shop is prepared as the program itself, then opened again the way people use it
    private readonly HubApp strict;
    private readonly Dictionary<string, long> people = new();
    private readonly long itemId, partyId, supplierId, invoiceId, draftId, invoiceLineId;

    public AccessTests()
    {
        var a = trusted.App;
        people[Roles.Owner] = a.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        people[Roles.Manager] = a.Users.Create("mia", "Mia Manager", Roles.Manager, "manager good password").Id;
        people[Roles.Cashier] = a.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        people[Roles.Kitchen] = a.Users.Create("kim", "Kim Kitchen", Roles.Kitchen, "kitchen good password").Id;
        people[Roles.Librarian] = a.Users.Create("lee", "Lee Librarian", Roles.Librarian, "library good password").Id;
        itemId = a.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 11_800, TaxClass = "standard", TrackStock = true }).Id;
        a.Catalog.Adjust(itemId, 100_000, "delivery");
        partyId = a.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" }).Id;
        supplierId = a.Parties.Create(new PartyInput { Kind = "supplier", Name = "Mill Co" }).Id;
        var bill = a.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = itemId, QtyMilli = 2000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 23_600 } } });
        invoiceId = bill.Document.Id;
        invoiceLineId = bill.Lines[0].Id;
        draftId = a.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = itemId } } }).Document.Id;
        strict = HubApp.Open(a.Db.Path, trusted.Clock);   // the way the web program opens it
    }

    public void Dispose() => trusted.Dispose();

    /// <summary>One command, the permissions of which any one is enough, and how to call it with nothing but ids.</summary>
    private sealed record Command(string Name, string[] AnyOf, Action<HubApp> Call);

    private IEnumerable<Command> Commands()
    {
        var doc = new[] { Perm.Sell, Perm.Orders, Perm.Loans, Perm.Appointments, Perm.Projects, Perm.Purchases };
        yield return new("Documents.CreateDraft", doc, a => a.Documents.CreateDraft(new DraftOptions()));
        yield return new("Documents.AddLine", doc, a => a.Documents.AddLine(draftId, new LineInput { ItemId = itemId }));
        yield return new("Documents.RemoveLine", doc, a => a.Documents.RemoveLine(draftId, 0));
        yield return new("Documents.SetAdjustments", doc, a => a.Documents.SetAdjustments(draftId, Array.Empty<NextGenOS.Tax.TaxAdjustmentInput>()));
        yield return new("Documents.SetParty", doc, a => a.Documents.SetParty(draftId, null));
        yield return new("Documents.SetLoyaltyPoints", doc, a => a.Documents.SetLoyaltyPoints(draftId, 0));
        yield return new("Documents.ApplyCode", doc, a => a.Documents.ApplyCode(draftId, "NOPE"));
        yield return new("Documents.RemoveCode", doc, a => a.Documents.RemoveCode(draftId, 0));
        yield return new("Documents.SetOfferDeclined", doc, a => a.Documents.SetOfferDeclined(draftId, true));
        yield return new("Documents.SaveAsEstimate", doc, a => a.Documents.SaveAsEstimate(draftId));
        yield return new("Documents.BillFromEstimate", doc, a => a.Documents.BillFromEstimate(0));
        yield return new("Documents.Discard", doc, a => a.Documents.Discard(0));
        yield return new("Documents.Issue", doc, a => a.Documents.Issue(0));
        yield return new("Documents.Checkout", doc, a => a.Documents.Checkout(new CheckoutRequest()));
        yield return new("Documents.AddPayment", new[] { Perm.Sell, Perm.Projects, Perm.Purchases }, a => a.Documents.AddPayment(0, new PaymentInput { Method = "cash", AmountMinor = 1 }));
        yield return new("Documents.ReceiveOnAccount", new[] { Perm.Sell }, a => a.Documents.ReceiveOnAccount(partyId, 100, "cash"));
        yield return new("Documents.Void", new[] { Perm.Void }, a => a.Documents.Void(0, "no reason", null));
        yield return new("Documents.CreateCreditNote", new[] { Perm.Sell }, a => a.Documents.CreateCreditNote(0, Array.Empty<(long, long)>(), "returned", "cash", null));

        yield return new("Catalog.Create", new[] { Perm.Catalog }, a => a.Catalog.Create(new ItemInput()));
        yield return new("Catalog.Update", new[] { Perm.Catalog }, a => a.Catalog.Update(itemId, new ItemInput()));
        yield return new("Catalog.SetActive", new[] { Perm.Catalog }, a => a.Catalog.SetActive(0, true));
        yield return new("Catalog.Adjust", new[] { Perm.Stock }, a => a.Catalog.Adjust(0, 1, "count"));
        yield return new("Parties.Create", new[] { Perm.Parties }, a => a.Parties.Create(new PartyInput()));
        yield return new("Parties.Update", new[] { Perm.Parties }, a => a.Parties.Update(partyId, new PartyInput()));
        yield return new("Parties.SetActive", new[] { Perm.Parties }, a => a.Parties.SetActive(0, true));

        yield return new("Purchasing.CreateOrder", new[] { Perm.Purchases }, a => a.Purchasing.CreateOrder(supplierId, Array.Empty<NextGenOS.Hub.Purchasing.PurchaseLine>()));
        yield return new("Purchasing.Receive", new[] { Perm.Purchases }, a => a.Purchasing.Receive(0));
        yield return new("Purchasing.Pay", new[] { Perm.Purchases }, a => a.Purchasing.Pay(0, 1, "cash"));

        yield return new("Users.Create", new[] { Perm.Users }, a => a.Users.Create("x", "X", Roles.Cashier, "x"));
        yield return new("Users.SetActive", new[] { Perm.Users }, a => a.Users.SetActive(0, true, null));
        yield return new("Users.SetRole", new[] { Perm.Users }, a => a.Users.SetRole(0, Roles.Cashier, null));
        yield return new("Users.ChangePassword (someone else's)", new[] { Perm.Users }, a => a.Users.ChangePassword(people[Roles.Owner], "a new password 1", null));

        yield return new("Offers.SaveOffer", new[] { Perm.Discount }, a => a.Offers.SaveOffer(null!));
        yield return new("Offers.SetOfferEnabled", new[] { Perm.Discount }, a => a.Offers.SetOfferEnabled(0, true));
        yield return new("Offers.DeleteOffer", new[] { Perm.Discount }, a => a.Offers.DeleteOffer(0));
        yield return new("Offers.SetPartyDiscount", new[] { Perm.Discount }, a => a.Offers.SetPartyDiscount(0, 0, false));
        yield return new("Offers.GenerateCoupons", new[] { Perm.Discount }, a => a.Offers.GenerateCoupons(Array.Empty<long>(), 100, null, null));
        yield return new("Offers.SetVoucherEnabled", new[] { Perm.Discount }, a => a.Offers.SetVoucherEnabled(0, true));

        yield return new("Settings: the shop's settings", new[] { Perm.Settings }, a => a.Shop.Save(a.Shop.Settings));
        yield return new("Settings: a stored setting", new[] { Perm.Settings }, a => a.SettingsStore.SetText("look.test", "x"));
        yield return new("Import.Check", new[] { Perm.Settings }, a => a.Importer.Check(null!));
        yield return new("Import.Import", new[] { Perm.Settings }, a => a.Importer.Import(null!, null));

        yield return new("Restaurant.AddTable", new[] { Perm.Orders }, a => a.Restaurant.AddTable("T9"));
        yield return new("Restaurant.RemoveTable", new[] { Perm.Orders }, a => a.Restaurant.RemoveTable(0));
        yield return new("Restaurant.OpenOrder", new[] { Perm.Orders }, a => a.Restaurant.OpenOrder(0));
        yield return new("Restaurant.OpenTakeaway", new[] { Perm.Orders }, a => a.Restaurant.OpenTakeaway());
        yield return new("Restaurant.AddItem", new[] { Perm.Orders }, a => a.Restaurant.AddItem(0, 0));
        yield return new("Restaurant.Transfer", new[] { Perm.Orders }, a => a.Restaurant.Transfer(0, 0));
        yield return new("Restaurant.CancelOrder", new[] { Perm.Orders }, a => a.Restaurant.CancelOrder(0, "changed mind", null));
        yield return new("Restaurant.Fire", new[] { Perm.Orders }, a => a.Restaurant.Fire(0));
        yield return new("Restaurant.Advance (the kitchen)", new[] { Perm.Kitchen }, a => a.Restaurant.Advance(0));
        yield return new("Restaurant.SetBillOptions", new[] { Perm.Orders }, a => a.Restaurant.SetBillOptions(0, false));
        yield return new("Restaurant.Pay", new[] { Perm.Orders }, a => a.Restaurant.Pay(0, Array.Empty<PaymentInput>()));
        yield return new("Restaurant.SplitByLines", new[] { Perm.Orders }, a => a.Restaurant.SplitByLines(0, Array.Empty<IReadOnlyList<long>>()));

        yield return new("Library.AddTitle", new[] { Perm.Catalog }, a => a.Library.AddTitle("A book"));
        yield return new("Library.AddCopies", new[] { Perm.Catalog }, a => a.Library.AddCopies(0, 1));
        yield return new("Library.WithdrawCopy", new[] { Perm.Catalog }, a => a.Library.WithdrawCopy(0, "damaged", null));
        yield return new("Library.Issue", new[] { Perm.Loans }, a => a.Library.Issue(0, "x"));
        yield return new("Library.Return", new[] { Perm.Loans }, a => a.Library.Return("x"));
        yield return new("Library.Renew", new[] { Perm.Loans }, a => a.Library.Renew(0));
        yield return new("Library.Reserve", new[] { Perm.Loans }, a => a.Library.Reserve(0, 0));
        yield return new("Library.CancelReservation", new[] { Perm.Loans }, a => a.Library.CancelReservation(0));
        yield return new("Library.Charge", new[] { Perm.Loans }, a => a.Library.Charge(0, 1, "late", null));
        yield return new("Library.MarkLost", new[] { Perm.Loans }, a => a.Library.MarkLost(0, null));
        yield return new("Library.Waive", new[] { Perm.Loans }, a => a.Library.Waive(0, "kind", null));
        yield return new("Library.PayFines", new[] { Perm.Loans }, a => a.Library.PayFines(0, Array.Empty<PaymentInput>(), null));

        yield return new("Projects.Create", new[] { Perm.Projects }, a => a.Projects.Create("P-9", "A job", 0));
        yield return new("Projects.SetStatus", new[] { Perm.Projects }, a => a.Projects.SetStatus(0, "active"));
        yield return new("Projects.AddBoq", new[] { Perm.Projects }, a => a.Projects.AddBoq(0, "1", "Work", "m", 1000, 100, "item"));
        yield return new("Projects.CreateQuote", new[] { Perm.Projects }, a => a.Projects.CreateQuote(0));
        yield return new("Projects.ReceiveAdvance", new[] { Perm.Projects }, a => a.Projects.ReceiveAdvance(0, 1, "cash"));
        yield return new("Projects.CreateProgressBill", new[] { Perm.Projects }, a => a.Projects.CreateProgressBill(0, Array.Empty<NextGenOS.Hub.Projects.ProgressInput>()));
        yield return new("Projects.ReceivePayment", new[] { Perm.Projects }, a => a.Projects.ReceivePayment(0, 1, "cash"));
        yield return new("Projects.ReleaseRetention", new[] { Perm.Projects }, a => a.Projects.ReleaseRetention(0));
        yield return new("Projects.AddCost", new[] { Perm.Projects }, a => a.Projects.AddCost(0, "labour", "Day", 1));
        yield return new("Projects.AddVariation", new[] { Perm.Projects }, a => a.Projects.AddVariation(0, "Extra", 1));
        yield return new("Projects.Approve", new[] { Perm.Projects }, a => a.Projects.Approve(0));
        yield return new("Projects.Reject", new[] { Perm.Projects }, a => a.Projects.Reject(0));

        yield return new("Appointments.Book", new[] { Perm.Appointments }, a => a.Appointments.Book(null, 0, 0, new DateOnly(2026, 10, 5), new TimeOnly(10, 0)));
        yield return new("Appointments.SetStatus", new[] { Perm.Appointments }, a => a.Appointments.SetStatus(0, "arrived"));
        yield return new("Appointments.Invoice", new[] { Perm.Appointments }, a => a.Appointments.Invoice(0, null, Array.Empty<PaymentInput>()));

        yield return new("Network.Configure", new[] { Perm.Network }, a => a.Network.Configure(null, false, 5290));
        yield return new("Network.Pairing.NewCode", new[] { Perm.Network }, a => a.Network.Pairing.NewCode(null));
        yield return new("Network.Pairing.Remove", new[] { Perm.Network }, a => a.Network.Pairing.Remove(0, null));

        yield return new("Ai.Flags.Set", new[] { Perm.Ai }, a => a.Ai.Flags.Set("nope", false, null));
        yield return new("Ai.Providers.Save", new[] { Perm.Ai }, a => a.Ai.Providers.Save(null!, null));
        yield return new("Ai.Providers.SetEnabled", new[] { Perm.Ai }, a => a.Ai.Providers.SetEnabled("x", true, null));
        yield return new("Ai.Providers.Delete", new[] { Perm.Ai }, a => a.Ai.Providers.Delete("x", null));
        yield return new("Ai.Providers.SetSecret", new[] { Perm.Ai }, a => a.Ai.Providers.SetSecret("x", "secret", null));
        yield return new("Ai.Providers.ClearSecret", new[] { Perm.Ai }, a => a.Ai.Providers.ClearSecret("x", null));
        yield return new("Ai.Providers.Grant", new[] { Perm.Ai }, a => a.Ai.Providers.Grant("x", "PUBLIC", null, null));
        yield return new("Ai.Providers.Revoke", new[] { Perm.Ai }, a => a.Ai.Providers.Revoke("x", "PUBLIC", null));
        yield return new("Ai.Models.Add", new[] { Perm.Ai }, a => a.Ai.Models.Add(null!, null));
        yield return new("Ai.Models.Move", new[] { Perm.Ai }, a => a.Ai.Models.Move(0, "active", null));
        yield return new("Ai.Models.RollBack", new[] { Perm.Ai }, a => a.Ai.Models.RollBack(0, null));
        yield return new("Ai.Models.SetInstalled", new[] { Perm.Ai }, a => a.Ai.Models.SetInstalled(0, true, null));
        yield return new("Ai.Models.Remove", new[] { Perm.Ai }, a => a.Ai.Models.Remove(0, null));
        yield return new("Ontology.AddEntityType", new[] { Perm.Ai }, a => a.Ontology.AddEntityType("x", "X", "PUBLIC", null));
        yield return new("Ontology.CreateThing", new[] { Perm.Ai }, a => a.Ontology.CreateThing("zone", null, "Back room", null, null));
        yield return new("Ontology.Unrelate", new[] { Perm.Ai }, a => a.Ontology.Unrelate(0, null));
        yield return new("Retention.Set", new[] { Perm.Ai }, a => a.Retention.Set("event", "PUBLIC", 30, null));
        yield return new("Retention.Prune", new[] { Perm.Ai }, a => a.Retention.Prune(null));
        yield return new("Events.SetStatus", new[] { Perm.Ai }, a => a.Events.SetStatus(0, "verified", null));
        yield return new("Support.Sections", new[] { Perm.Settings }, a => a.Support.Sections());
        yield return new("Ontology.Check", new[] { Perm.Ai }, a => a.Ontology.Check());
        yield return new("Supply.Set", new[] { Perm.Purchases }, a => a.Supply.Set(itemId, supplierId, 5, 2, 1_000, 0, null));
        yield return new("Supply.Clear", new[] { Perm.Purchases }, a => a.Supply.Clear(itemId, null));
        yield return new("Insights.Run", new[] { Perm.Stock, Perm.Purchases }, a => a.Insights.Run(null));
        yield return new("Insights.Dismiss", new[] { Perm.Stock, Perm.Purchases }, a => a.Insights.Dismiss(0, null, null));
        yield return new("Actions.Propose", new[] { Perm.Sell, Perm.Orders, Perm.Catalog, Perm.Stock, Perm.Purchases }, a => a.Actions.Propose("CreatePurchaseOrder", 1, "{}", null, null, null, null));
        yield return new("Actions.Approve", new[] { Perm.Purchases }, a => a.Actions.Approve(0, null, null));
        yield return new("Actions.Decline", new[] { Perm.Sell, Perm.Orders, Perm.Catalog, Perm.Stock, Perm.Purchases }, a => a.Actions.Decline(0, null, null));
        yield return new("Insights.SaveSettings", new[] { Perm.Settings }, a => a.Insights.SaveSettings(new NextGenOS.Hub.Insights.LowStockSettings(), null));
        yield return new("Outbox.RetryFailed", new[] { Perm.Ai }, a => a.Outbox.RetryFailed(null));
        yield return new("Outbox.Replay", new[] { Perm.Ai }, a => a.Outbox.Replay(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, null));

        // Reading the shop's numbers (blueprint SEC-004, reads): the same Hub-side check, so a new screen or a counter PC cannot see more than the role allows.
        var from = new DateOnly(2026, 10, 1);
        var to = new DateOnly(2026, 10, 31);
        yield return new("Reports.Summary", new[] { Perm.Reports, Perm.Sell }, a => a.Reports.Summary(from, to));
        yield return new("Reports.DailySales", new[] { Perm.Reports }, a => a.Reports.DailySales(from, to));
        yield return new("Reports.TopItems", new[] { Perm.Reports }, a => a.Reports.TopItems(from, to));
        yield return new("Reports.TaxSummary", new[] { Perm.Reports }, a => a.Reports.TaxSummary(from, to));
        yield return new("Reports.Payments", new[] { Perm.Reports }, a => a.Reports.Payments(from, to));
        yield return new("Reports.Outstanding", new[] { Perm.Reports }, a => a.Reports.Outstanding());
        yield return new("Reports.TopCustomers", new[] { Perm.Reports }, a => a.Reports.TopCustomers(from, to));
        yield return new("Reports.StockValues", new[] { Perm.Reports, Perm.Stock }, a => a.Reports.StockValues());
        yield return new("Reports.Purchases", new[] { Perm.Reports }, a => a.Reports.Purchases(from, to));
        yield return new("TaxRegisters.Register", new[] { Perm.Reports }, a => a.TaxRegisters.Register("sales", from, to));
        yield return new("TaxRegisters.ReturnLists", new[] { Perm.Reports }, a => a.TaxRegisters.ReturnLists(from, to));
        yield return new("TaxRegisters.SupplySummary", new[] { Perm.Reports }, a => a.TaxRegisters.SupplySummary(from, to));
        yield return new("TaxRegisters.CodesSold", new[] { Perm.Reports }, a => a.TaxRegisters.CodesSold(from, to));
        yield return new("Books.TrialBalance", new[] { Perm.Reports }, a => a.Books.TrialBalance(null, null));
        yield return new("Books.Profit", new[] { Perm.Reports }, a => a.Books.Profit(null, null));
        yield return new("Books.Position", new[] { Perm.Reports }, a => a.Books.Position(null));
        var accounts = new[] { Perm.Parties, Perm.Reports, Perm.Sell, Perm.Purchases, Perm.Orders, Perm.Loans, Perm.Projects, Perm.Appointments };
        yield return new("Books.CustomerLedger", accounts, a => a.Books.CustomerLedger(partyId));
        yield return new("Books.SupplierLedger", accounts, a => a.Books.SupplierLedger(supplierId));
        yield return new("Books.CustomerBalance", accounts, a => a.Books.CustomerBalance(partyId));
        yield return new("Books.SupplierBalance", accounts, a => a.Books.SupplierBalance(supplierId));
    }

    private static bool Refusal(Exception? e) => e is HubException { Code: "forbidden" or "not-signed-in" };

    private static Exception? Try(Action work)
    {
        try { work(); return null; }
        catch (Exception e) { return e; }
    }

    [Fact]
    public void Every_guarded_command_refuses_a_call_that_names_nobody()
    {
        foreach (var command in Commands())
        {
            var problem = Try(() => command.Call(strict));
            Assert.True(problem is HubException { Code: "not-signed-in" }, $"{command.Name}: expected 'not-signed-in', got {problem?.GetType().Name}: {problem?.Message}");
        }
    }

    [Fact]
    public void Every_guarded_command_is_refused_to_a_role_without_its_permission_and_not_refused_to_a_role_with_it()
    {
        foreach (var command in Commands())
        {
            foreach (var role in Roles.All)
            {
                using var scope = strict.Access.As(people[role]);
                var problem = Try(() => command.Call(strict));
                var allowed = command.AnyOf.Any(p => Roles.Can(role, p));
                if (allowed) Assert.False(Refusal(problem), $"{command.Name} was refused to the {role}, who may do it: {problem?.Message}");
                else Assert.True(problem is HubException { Code: "forbidden" }, $"{command.Name} was not refused to the {role} (got {problem?.GetType().Name}: {problem?.Message})");
            }
        }
    }

    [Fact]
    public void A_person_switched_off_or_given_another_role_loses_their_rights_at_once_even_inside_a_scope()
    {
        using var scope = strict.Access.As(people[Roles.Manager]);
        strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Tea", PriceMinor = 1000, TaxClass = "standard" });   // a manager may

        trusted.App.Users.SetRole(people[Roles.Manager], Roles.Kitchen, null);                                              // ... and then is made kitchen staff
        Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Coffee", PriceMinor = 1000, TaxClass = "standard" })).Code);

        trusted.App.Users.SetRole(people[Roles.Manager], Roles.Manager, null);
        strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Coffee", PriceMinor = 1000, TaxClass = "standard" });
        trusted.App.Users.SetActive(people[Roles.Manager], false, null);                                                    // ... and then is switched off
        Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Milk", PriceMinor = 1000, TaxClass = "standard" })).Code);
    }

    [Fact]
    public void A_refusal_is_written_to_the_audit_log_with_who_and_what()
    {
        using (strict.Access.As(people[Roles.Cashier]))
            Assert.Throws<HubException>(() => strict.Catalog.Adjust(itemId, 5, "count"));
        var entry = Assert.Single(strict.Audit.Recent(), a => a.Action == "access-denied");
        Assert.Equal(people[Roles.Cashier], entry.UserId);
        Assert.Equal(Perm.Stock, entry.Detail);
    }

    [Fact]
    public async Task Two_people_at_two_counters_at_the_same_moment_are_each_judged_as_themselves_and_a_scope_ends_when_it_ends()
    {
        var gate = new ManualResetEventSlim(false);
        Exception? Make(long who, string name)
        {
            using var scope = strict.Access.As(who);
            gate.Wait();
            return Try(() => strict.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = 1000, TaxClass = "standard" }));
        }

        var cashier = Task.Factory.StartNew(() => Make(people[Roles.Cashier], "Tea"), TaskCreationOptions.LongRunning);
        var manager = Task.Factory.StartNew(() => Make(people[Roles.Manager], "Sugar"), TaskCreationOptions.LongRunning);
        gate.Set();
        Assert.Equal("forbidden", Assert.IsType<HubException>(await cashier).Code);
        Assert.Null(await manager);

        using (strict.Access.As(people[Roles.Manager]))
        {
            using (strict.Access.As(people[Roles.Cashier]))   // an inner scope is another person
                Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Salt", PriceMinor = 1000, TaxClass = "standard" })).Code);
            strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Salt", PriceMinor = 1000, TaxClass = "standard" });   // the manager is back
        }

        Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Pepper", PriceMinor = 1000, TaxClass = "standard" })).Code);
    }

    [Fact]
    public async Task Work_started_without_carrying_the_scope_across_names_nobody()
    {
        Task<Exception?> other;
        using (strict.Access.As(people[Roles.Manager]))
        {
            using (ExecutionContext.SuppressFlow())
                other = Task.Factory.StartNew(() => Try(() => strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Salt", PriceMinor = 1000, TaxClass = "standard" })), TaskCreationOptions.LongRunning);
            Assert.Equal("not-signed-in", Assert.IsType<HubException>(await other).Code);
        }
    }

    [Fact]
    public void Your_own_password_is_yours_to_change_and_somebody_elses_is_the_owners_to_change()
    {
        using (strict.Access.As(people[Roles.Cashier]))
        {
            strict.Users.ChangePassword(people[Roles.Cashier], "a brand new password", people[Roles.Cashier]);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Users.ChangePassword(people[Roles.Manager], "a brand new password", people[Roles.Cashier])).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Users.SetRole(people[Roles.Cashier], Roles.Owner, people[Roles.Cashier])).Code);   // no promoting yourself
        }

        using (strict.Access.As(people[Roles.Owner]))
            strict.Users.ChangePassword(people[Roles.Manager], "a brand new password", people[Roles.Owner]);
    }

    [Fact]
    public void The_program_may_act_for_itself_and_a_shop_with_nobody_in_it_yet_may_be_set_up_but_only_the_settings_and_the_owner()
    {
        using (strict.Access.AsSystem())
            strict.Catalog.Create(new ItemInput { Kind = "stock", Name = "Tea", PriceMinor = 1000, TaxClass = "standard" });

        var fresh = Path.Combine(Path.GetTempPath(), "hub-access-" + Guid.NewGuid().ToString("N") + ".db");
        try
        {
            var app = HubApp.Open(fresh);
            Assert.False(app.Users.Any());
            app.Shop.Save(new ShopSettings { Name = "New Shop", Country = "IN", Region = "27", Industry = "retail" });   // the first-run set-up
            app.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery");
            Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => app.Users.Create("second", "Second", Roles.Owner, "correct horse battery")).Code);   // closed as soon as there is an owner
            Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => app.Shop.Save(new ShopSettings { Name = "Changed", Country = "IN", Region = "27", Industry = "retail" })).Code);
        }
        finally
        {
            foreach (var file in new[] { fresh, fresh + "-wal", fresh + "-shm" }) { try { File.Delete(file); } catch (IOException) { } }
        }

        var empty = Path.Combine(Path.GetTempPath(), "hub-access-" + Guid.NewGuid().ToString("N") + ".db");
        try
        {
            var app = HubApp.Open(empty);
            Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => app.Catalog.Create(new ItemInput { Kind = "stock", Name = "X", PriceMinor = 1, TaxClass = "standard" })).Code);   // no users yet still does not open the till's commands
        }
        finally
        {
            foreach (var file in new[] { empty, empty + "-wal", empty + "-shm" }) { try { File.Delete(file); } catch (IOException) { } }
        }
    }

    // ---- the cashier's discount limit, held by the Hub itself --------------------------------------------------------------------------------------------

    private void LimitIs(long pctMilli)
    {
        var settings = trusted.App.Shop.Settings;
        settings.CashierDiscountPctMilli = pctMilli;
        trusted.App.Shop.Save(settings);
    }

    private DocumentView NewDraft(long qtyMilli = 1000)
    {
        using var asSystem = strict.Access.AsSystem();
        return strict.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = itemId, QtyMilli = qtyMilli } } });
    }

    [Fact]
    public void A_cashier_gives_no_discount_at_all_unless_the_owner_has_set_a_limit_above_nothing()
    {
        LimitIs(0);
        var draft = NewDraft();
        using var scope = strict.Access.As(people[Roles.Cashier]);
        var line = draft.Lines[0];
        Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Documents.UpdateLine(draft.Document.Id, line.Id, discountPctMilli: 1_000)).Code);
        Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Documents.SetBillDiscount(draft.Document.Id, 0, 1_000)).Code);
        Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Documents.AddLine(draft.Document.Id, new LineInput { ItemId = itemId, DiscountPctMilli = 1_000 })).Code);
        Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Documents.CreateDraft(new DraftOptions { BillDiscountPctMilli = 1_000, Lines = { new LineInput { ItemId = itemId } } })).Code);
        Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Documents.Checkout(new CheckoutRequest { BillDiscountMinor = 100, Lines = { new LineInput { ItemId = itemId } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } })).Code);
        Assert.Equal(0, strict.Documents.Get(draft.Document.Id)!.Lines[0].DiscountPctMilli);   // nothing was changed

        // Taking a discount off, or leaving it at nothing, is not "giving" one.
        strict.Documents.UpdateLine(draft.Document.Id, line.Id, discountPctMilli: 0);
        strict.Documents.SetBillDiscount(draft.Document.Id, 0, 0);
    }

    [Fact]
    public void A_cashier_with_a_limit_may_take_off_up_to_it_counting_every_discount_and_not_a_cent_more()
    {
        LimitIs(5_000);   // 5 percent
        var draft = NewDraft(2000);   // two units, 236.00 together
        var line = draft.Lines[0];
        using var scope = strict.Access.As(people[Roles.Cashier]);

        strict.Documents.UpdateLine(draft.Document.Id, line.Id, discountPctMilli: 3_000);   // 3 percent: within the limit
        var refused = Assert.Throws<HubException>(() => strict.Documents.SetBillDiscount(draft.Document.Id, 0, 3_000));   // 3 + about 3 more is over 5 percent in all
        Assert.Equal("discount-limit", refused.Code);
        Assert.Contains("up to 5%", refused.Message);
        var after = strict.Documents.Get(draft.Document.Id)!;
        Assert.Equal(3_000, after.Lines[0].DiscountPctMilli);   // the line discount stayed, the bill discount was not kept
        Assert.Equal(0, after.Document.BillDiscountPctMilli);

        strict.Documents.SetBillDiscount(draft.Document.Id, 0, 2_000);                      // 3 percent + 2 percent of the rest is under 5 percent
        Assert.Equal("discount-limit", Assert.Throws<HubException>(() => strict.Documents.UpdateLine(draft.Document.Id, line.Id, discountPctMilli: 6_000)).Code);
        Assert.Equal("discount-limit", Assert.Throws<HubException>(() => strict.Documents.SetBillDiscount(draft.Document.Id, 20_000, 0)).Code);   // an amount: 200.00 of 236.00
    }

    [Fact]
    public void A_sale_made_in_one_step_with_a_discount_over_the_limit_makes_nothing()
    {
        LimitIs(5_000);
        var before = Convert.ToInt64(trusted.App.Db.Scalar("SELECT COUNT(*) FROM documents"));
        using var scope = strict.Access.As(people[Roles.Cashier]);
        var ex = Assert.Throws<HubException>(() => strict.Documents.Checkout(new CheckoutRequest
        {
            Lines = { new LineInput { ItemId = itemId, DiscountPctMilli = 10_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } },
        }));
        Assert.Equal("discount-limit", ex.Code);
        Assert.Equal(before, Convert.ToInt64(trusted.App.Db.Scalar("SELECT COUNT(*) FROM documents")));   // no draft, no bill, no number
        Assert.Equal(100_000 - 2_000, Convert.ToInt64(trusted.App.Db.Scalar("SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves WHERE item_id = $i", ("$i", itemId))));   // stock untouched
    }

    [Fact]
    public void Owners_and_managers_give_any_discount_and_a_discount_that_was_agreed_beforehand_does_not_count_against_a_cashier()
    {
        LimitIs(5_000);
        var draft = NewDraft();
        using (strict.Access.As(people[Roles.Manager]))
        {
            strict.Documents.UpdateLine(draft.Document.Id, draft.Lines[0].Id, discountPctMilli: 50_000);
            strict.Documents.SetBillDiscount(draft.Document.Id, 0, 10_000);
        }

        // A bill made from a manager's quote keeps the manager's discount, and the cashier who bills it is not held to the cashier's limit for it.
        using (strict.Access.As(people[Roles.Manager]))
        {
            var quote = strict.Documents.SaveAsEstimate(draft.Document.Id, people[Roles.Manager]);
            using var asCashier = strict.Access.As(people[Roles.Cashier]);
            var bill = strict.Documents.BillFromEstimate(quote.Document.Id, people[Roles.Cashier]);
            var made = strict.Documents.Issue(bill.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = bill.Document.PayableMinor } }, UserId = people[Roles.Cashier] });
            Assert.Equal(DocStatus.Issued, made.Document.Status);
        }
    }

    // ---- the program's own use of the escape hatch stays in a few named places ----------------------------------------------------------------------------

    [Fact]
    public void The_programs_own_scope_is_used_only_in_the_few_places_that_do_the_programs_own_work()
    {
        var root = AppContext.BaseDirectory;
        while (root is not null && !File.Exists(Path.Combine(root, "CLAUDE.md"))) root = Path.GetDirectoryName(root);
        Assert.NotNull(root);
        var src = Path.Combine(root!, "apps", "business-hub", "src");
        var allowed = new[] { "NextGenOS.Hub.Core/Security/Access.cs", "NextGenOS.Hub.Core/HubApp.cs", "NextGenOS.Hub.Core/Purchasing/PurchaseService.cs" };
        var separator = Path.DirectorySeparatorChar;
        var users = Directory.EnumerateFiles(src, "*.*", SearchOption.AllDirectories)
            .Where(f => (f.EndsWith(".cs") || f.EndsWith(".razor")) && !f.Contains($"{separator}obj{separator}") && !f.Contains($"{separator}bin{separator}"))
            .Where(f => { var text = File.ReadAllText(f); return text.Contains("AsSystem(", StringComparison.Ordinal) || text.Contains("EnterSystemForTests", StringComparison.Ordinal); })
            .Select(f => Path.GetRelativePath(src, f).Replace('\\', '/'))
            .Where(f => !allowed.Contains(f))
            .ToList();
        Assert.True(users.Count == 0, "The program's own scope (AsSystem) is used in: " + string.Join(", ", users));
    }
}

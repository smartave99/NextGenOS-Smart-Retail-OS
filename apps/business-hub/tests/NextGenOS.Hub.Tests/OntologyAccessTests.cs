using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Ontology;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The business map shows each person what the shop's own screens already show them, and nothing more (blueprint ONT-010): nodes, connections and details are filtered by the person's role
/// and the kind of information before anything is returned, so a screen or, later, an assistant cannot be told what the person asking could not see. The shop is opened the way people use it.
/// </summary>
public sealed class OntologyAccessTests : IDisposable
{
    private readonly AiFixture f = new();
    private readonly HubApp strict;
    private readonly Dictionary<string, long> people = new();
    private readonly long productId, customerId, supplierId, invoiceId, paymentId, projectId;

    public OntologyAccessTests()
    {
        f.Allow(FlagKey.BusinessOntology);
        var a = f.App;
        people[Roles.Owner] = a.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        people[Roles.Manager] = a.Users.Create("mia", "Mia Manager", Roles.Manager, "manager good password").Id;
        people[Roles.Cashier] = a.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        people[Roles.Kitchen] = a.Users.Create("kim", "Kim Kitchen", Roles.Kitchen, "kitchen good password").Id;
        people[Roles.Librarian] = a.Users.Create("lee", "Lee Librarian", Roles.Librarian, "library good password").Id;
        productId = a.Catalog.Create(new ItemInput { Kind = "service", Name = "Haircut", PriceMinor = 40_000, TaxClass = "zero" }).Id;
        customerId = a.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" }).Id;
        supplierId = a.Parties.Create(new PartyInput { Kind = "supplier", Name = "Mill Co" }).Id;
        var bill = a.Documents.Checkout(new CheckoutRequest
        {
            PartyId = customerId, UserId = people[Roles.Cashier],
            Lines = { new LineInput { ItemId = productId, QtyMilli = 1_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 40_000 } },
        });
        invoiceId = bill.Document.Id;
        paymentId = Convert.ToInt64(a.Db.Scalar("SELECT id FROM payments WHERE document_id = $d", ("$d", invoiceId)));
        projectId = a.Projects.Create("P-001", "Villa", customerId).Id;
        var site = a.Ontology.CreateThing(EntityType.Site, null, "Corner Mart", null, 1);
        var zone = a.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3", null, 1);
        var shelf = a.Ontology.CreateThing(EntityType.Shelf, null, "Shelf 1", null, 1);
        var camera = a.Ontology.CreateThing(EntityType.Device, null, "Camera 1", null, 1);
        a.Ontology.Relate(RelationType.PartOf, zone.Ref, site.Ref, 1);
        a.Ontology.Relate(RelationType.LocatedIn, shelf.Ref, zone.Ref, 1);
        a.Ontology.Relate(RelationType.LocatedIn, camera.Ref, zone.Ref, 1);
        a.Ontology.Relate(RelationType.Observes, camera.Ref, shelf.Ref, 1);
        a.Ontology.Relate(RelationType.StockedOn, Product, shelf.Ref, 1);
        a.Ontology.Relate(RelationType.SuppliedBy, Product, Party(supplierId), 1);
        strict = f.OpenStrict();
    }

    public void Dispose() => f.Dispose();

    private ThingRef Product => new(EntityType.Product, productId.ToString());
    private static ThingRef Party(long id) => new(EntityType.Party, id.ToString());
    private ThingRef Invoice => new(EntityType.Document, invoiceId.ToString());
    private ThingRef Payment => new(EntityType.Payment, paymentId.ToString());
    private ThingRef Project => new(EntityType.Project, projectId.ToString());
    private ThingRef User(string role) => new(EntityType.User, people[role].ToString());

    private static readonly string[] Kinds = ["product", "party", "user", "document", "payment", "table", "project", "site", "zone", "shelf", "device"];

    /// <summary>Which kinds of thing each role may see, written out by hand from what the shop's screens let that role open (a letter for each kind, in the order of <see cref="Kinds"/>).</summary>
    private static readonly Dictionary<string, string> Expected = new()
    {
        //                  product party user document payment table project site zone shelf device
        [Roles.Owner] =     "Y       Y     Y    Y        Y       Y     Y       Y    Y    Y     Y",
        [Roles.Manager] =   "Y       Y     N    Y        Y       Y     Y       Y    Y    Y     N",
        [Roles.Cashier] =   "Y       Y     N    Y        Y       Y     N       Y    Y    Y     N",
        [Roles.Kitchen] =   "Y       N     N    N        N       Y     N       Y    Y    Y     N",
        [Roles.Librarian] = "Y       Y     N    Y        N       N     N       Y    Y    Y     N",
    };

    public static IEnumerable<object[]> RolesToTry() => Roles.All.Select(r => new object[] { r });

    // ---- the rule itself ----------------------------------------------------------------------------------------------------------------

    [Theory]
    [MemberData(nameof(RolesToTry))]
    public void Each_role_may_see_exactly_the_kinds_of_thing_its_screens_let_it_open(string role)
    {
        var want = Expected[role].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x == "Y").ToArray();
        Assert.Equal(Kinds.Length, want.Length);
        var types = f.App.Ontology.EntityTypes().ToDictionary(t => t.Name);
        var actor = new Actor(people[role], role, role);
        for (var i = 0; i < Kinds.Length; i++)
            Assert.True(want[i] == ReadPolicy.CanSee(actor, Kinds[i], types[Kinds[i]].DataClass), $"{role} and '{Kinds[i]}': expected {(want[i] ? "visible" : "hidden")}");
        Assert.True(ReadPolicy.CanSee(Actor.System, "user", DataClass.Personal));
    }

    [Fact]
    public void A_kind_the_owner_adds_is_judged_by_what_it_holds_and_card_or_biometric_kinds_are_for_nobody()
    {
        Assert.Equal(new[] { Perm.Reports }, ReadPolicy.Needed("vault", DataClass.Confidential));
        Assert.Equal(new[] { Perm.Parties }, ReadPolicy.Needed("notebook", DataClass.Personal));
        Assert.Contains(Perm.Kitchen, ReadPolicy.Needed("board", DataClass.Public));
        Assert.Contains(Perm.Kitchen, ReadPolicy.Needed("board", DataClass.Internal));
        foreach (var never in new[] { DataClass.PaymentSensitive, DataClass.Biometric, DataClass.Video, DataClass.Audio })
        {
            Assert.Empty(ReadPolicy.Needed("mystery", never));
            foreach (var role in Roles.All) Assert.False(ReadPolicy.CanSee(new Actor(1, role, role), "mystery", never), role + " / " + never);
        }

        // The data classes the map accepts for a new kind are exactly the four it can judge.
        var map = f.App.Ontology;
        map.AddEntityType("vault", "Strong room", DataClass.Confidential, 1);
        map.AddEntityType("notebook", "Staff notebook", DataClass.Personal, 1);
        map.AddEntityType("board", "Notice board", DataClass.Public, 1);
        map.CreateThing("vault", null, "Safe 1", null, 1);
        map.CreateThing("notebook", null, "Rota", null, 1);
        map.CreateThing("board", null, "Front board", null, 1);
        var seen = Roles.All.ToDictionary(r => r, r =>
        {
            using var scope = strict.Access.As(people[r]);
            return string.Concat(strict.Ontology.Things("vault").Count, strict.Ontology.Things("notebook").Count, strict.Ontology.Things("board").Count);
        });
        Assert.Equal("111", seen[Roles.Owner]);
        Assert.Equal("111", seen[Roles.Manager]);      // reports, customers, anything
        Assert.Equal("011", seen[Roles.Cashier]);      // customers, not the reports
        Assert.Equal("001", seen[Roles.Kitchen]);
        Assert.Equal("011", seen[Roles.Librarian]);
    }

    // ---- looking a thing up ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_thing_a_role_may_not_see_cannot_be_told_from_a_thing_that_is_not_there()
    {
        using var scope = strict.Access.As(people[Roles.Cashier]);
        var hidden = strict.Ontology.Resolve(User(Roles.Owner));                           // a real person who works here
        var absent = strict.Ontology.Resolve(new ThingRef(EntityType.User, "99999"));      // nobody
        var invented = strict.Ontology.Resolve(new ThingRef("nonsense", "1"));             // not a kind
        var camera = strict.Ontology.Resolve(new ThingRef(EntityType.Device, "camera-1"));
        Assert.Null(hidden);
        Assert.Null(absent);
        Assert.Null(invented);
        Assert.Null(camera);
        Assert.NotNull(strict.Ontology.Resolve(Invoice));
        Assert.NotNull(strict.Ontology.Resolve(Party(customerId)));
        Assert.Null(strict.Ontology.Resolve(Project));
        Assert.Empty(strict.Ontology.Things(EntityType.User));
        Assert.Empty(strict.Ontology.Things(EntityType.Device));
        Assert.NotEmpty(strict.Ontology.Things(EntityType.Zone));
    }

    [Fact]
    public void What_is_shown_says_when_it_was_read_and_whether_it_is_a_record_the_shop_keeps_or_something_kept_only_in_the_map()
    {
        using var scope = strict.Access.As(people[Roles.Owner]);
        var product = strict.Ontology.Resolve(Product)!;
        var zone = strict.Ontology.Things(EntityType.Zone).Single();
        Assert.Equal((OntologyService.OriginShop, f.Shop.Clock.UtcNow), (product.Origin, product.AsOf));
        Assert.Equal((OntologyService.OriginMap, f.Shop.Clock.UtcNow), (zone.Origin, zone.AsOf));
        var derived = strict.Ontology.Related(Invoice).Where(l => l.Derived).ToList();
        Assert.NotEmpty(derived);
        Assert.All(derived, l => Assert.Equal(OntologyService.OriginShop, l.Source));
        Assert.All(strict.Ontology.Related(zone.Ref).Where(l => !l.Derived), l => Assert.Equal("person", l.Source));
    }

    // ---- connections ----------------------------------------------------------------------------------------------------------------------

    private static string Describe(IEnumerable<Link> links) => string.Join(" | ", links.Select(l => l.From + " " + l.Relation + " " + l.To).Order());

    [Fact]
    public void A_cashier_sees_who_a_bill_was_for_and_what_was_on_it_but_not_which_member_of_staff_handled_it_or_the_cameras()
    {
        using var scope = strict.Access.As(people[Roles.Cashier]);
        var links = strict.Ontology.Related(Invoice);
        Assert.Contains(links, l => l.Relation == "issued_to" && l.To == Party(customerId));
        Assert.Contains(links, l => l.Relation == "contains" && l.To == Product);
        Assert.DoesNotContain(links, l => l.Relation == "handled_by");
        Assert.DoesNotContain(links, l => l.To.Type == EntityType.User || l.From.Type == EntityType.User);
        Assert.Contains(strict.Ontology.Related(Payment), l => l.Relation == "settles" && l.To == Invoice);
        Assert.DoesNotContain(strict.Ontology.Related(Payment), l => l.Relation == "taken_by");

        var owner = strict.Access.As(people[Roles.Owner]);
        Assert.Contains(strict.Ontology.Related(Invoice), l => l.Relation == "handled_by" && l.To == User(Roles.Cashier));
        owner.Dispose();
        // The cashier cannot even ask what a member of staff handled, or what a camera watches.
        Assert.Empty(strict.Ontology.Related(User(Roles.Cashier)));
        Assert.Empty(strict.Ontology.Related(new ThingRef(EntityType.Device, "camera-1")));
        Assert.DoesNotContain(strict.Ontology.Related(new ThingRef(EntityType.Shelf, "shelf-1")), l => l.Relation == "observes");
        Assert.Contains(strict.Ontology.Related(new ThingRef(EntityType.Shelf, "shelf-1")), l => l.Relation == "located_in");
    }

    [Fact]
    public void A_kitchen_screen_sees_menu_items_and_places_and_nothing_about_money_or_customers()
    {
        using var scope = strict.Access.As(people[Roles.Kitchen]);
        Assert.Empty(strict.Ontology.Related(Invoice));
        Assert.Empty(strict.Ontology.Related(Payment));
        Assert.Empty(strict.Ontology.Related(Party(customerId)));
        Assert.Null(strict.Ontology.Resolve(Invoice));
        var links = strict.Ontology.Related(Product);
        Assert.DoesNotContain(links, l => l.From.Type == EntityType.Document || l.To.Type == EntityType.Document);   // the bills that contain it are not shown
        Assert.DoesNotContain(links, l => l.To.Type == EntityType.Party);                                           // nor the supplier
        Assert.Contains(links, l => l.Relation == "stocked_on");
    }

    [Theory]
    [MemberData(nameof(RolesToTry))]
    public void Whatever_a_role_is_shown_is_exactly_what_the_program_itself_sees_without_the_connections_to_things_that_role_may_not_see(string role)
    {
        var map = f.App.Ontology;                           // the prepared shop acts as the program itself: it sees everything
        var refs = new List<ThingRef> { Product, Party(customerId), Party(supplierId), Invoice, Payment, Project, User(Roles.Cashier), User(Roles.Owner) };
        refs.AddRange(new[] { EntityType.Site, EntityType.Zone, EntityType.Shelf, EntityType.Device }.SelectMany(t => map.Things(t).Select(x => x.Ref)));
        var types = map.EntityTypes().ToDictionary(t => t.Name);
        var actor = new Actor(people[role], role, role);
        bool Sees(string type) => ReadPolicy.CanSee(actor, type, types[type].DataClass);

        using var scope = strict.Access.As(people[role]);
        foreach (var thing in refs)
        {
            var all = map.Related(thing);
            var want = Sees(thing.Type) ? all.Where(l => Sees(l.From.Type) && Sees(l.To.Type)) : [];
            Assert.Equal(Describe(want), Describe(strict.Ontology.Related(thing)));
            Assert.Equal(Sees(thing.Type) ? map.Resolve(thing)?.Label : null, strict.Ontology.Resolve(thing)?.Label);
        }
    }

    [Fact]
    public void The_path_up_to_the_shop_is_shown_to_everyone_who_works_here()
    {
        foreach (var role in Roles.All)
        {
            using var scope = strict.Access.As(people[role]);
            Assert.Equal(new[] { "Aisle 3", "Corner Mart" }, strict.Ontology.Ancestors(new ThingRef(EntityType.Shelf, "shelf-1")).Select(x => x.Label).ToArray());
        }
    }

    [Fact]
    public void The_map_checks_itself_only_for_the_owner()
    {
        using (strict.Access.As(people[Roles.Owner])) Assert.Empty(strict.Ontology.Check());
        foreach (var role in Roles.All.Where(r => r != Roles.Owner))
        {
            using var scope = strict.Access.As(people[role]);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Ontology.Check()).Code);
        }
    }

    // ---- who is asking --------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_read_that_names_nobody_is_refused_in_the_shop_as_people_use_it_and_allowed_to_the_program_itself()
    {
        Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Ontology.Resolve(Product)).Code);
        Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Ontology.Things(EntityType.Zone)).Code);
        Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Ontology.Related(Product)).Code);
        Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Ontology.Ancestors(new ThingRef(EntityType.Shelf, "shelf-1"))).Code);
        using (strict.Access.As(null as long?)) Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Ontology.Resolve(Product)).Code);
        using (strict.Access.AsSystem())
        {
            Assert.NotNull(strict.Ontology.Resolve(User(Roles.Owner)));
            Assert.NotEmpty(strict.Ontology.Related(Invoice).Where(l => l.Relation == "handled_by"));
        }

        Assert.NotNull(f.App.Ontology.Resolve(User(Roles.Owner)));   // the shop prepared for tests acts as the program
    }

    [Fact]
    public void A_person_given_another_role_or_switched_off_is_judged_as_they_are_now_even_inside_one_scope()
    {
        using var scope = strict.Access.As(people[Roles.Cashier]);
        Assert.Null(strict.Ontology.Resolve(Project));
        f.App.Users.SetRole(people[Roles.Cashier], Roles.Manager, null);
        Assert.NotNull(strict.Ontology.Resolve(Project));
        f.App.Users.SetRole(people[Roles.Cashier], Roles.Kitchen, null);
        Assert.Null(strict.Ontology.Resolve(Project));
        Assert.Null(strict.Ontology.Resolve(Invoice));
        f.App.Users.SetActive(people[Roles.Cashier], false, null);
        Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Ontology.Resolve(Product)).Code);
    }

    [Fact]
    public void Two_people_asking_at_the_same_moment_are_each_shown_their_own_map()
    {
        var gate = new ManualResetEventSlim(false);
        string Ask(string role)
        {
            using var scope = strict.Access.As(people[role]);
            gate.Wait();
            Thread.Sleep(5);
            return (strict.Ontology.Resolve(Project) is null ? "-" : "P") + (strict.Ontology.Resolve(User(Roles.Owner)) is null ? "-" : "U") + strict.Ontology.Related(Invoice).Count;
        }

        var tasks = Enumerable.Range(0, 20).Select(i => Task.Run(() => (Role: i % 2 == 0 ? Roles.Owner : Roles.Cashier, Result: Ask(i % 2 == 0 ? Roles.Owner : Roles.Cashier)))).ToArray();
        gate.Set();
        Task.WaitAll(tasks);
        var owner = tasks.First(t => t.Result.Role == Roles.Owner).Result.Result;
        var cashier = tasks.First(t => t.Result.Role == Roles.Cashier).Result.Result;
        Assert.StartsWith("PU", owner);
        Assert.StartsWith("--", cashier);
        Assert.All(tasks, t => Assert.Equal(t.Result.Role == Roles.Owner ? owner : cashier, t.Result.Result));
    }
}

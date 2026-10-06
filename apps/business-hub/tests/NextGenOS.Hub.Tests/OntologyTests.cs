using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Ontology;

namespace NextGenOS.Hub.Tests;

/// <summary>The business map: the kinds of thing and connection as data, the shop's own records read in place, connections kept with their days, and what is worked out rather than stored.</summary>
public class OntologyTests
{
    private static AiFixture Mapping(bool licensed = true)
    {
        var f = new AiFixture(licensed);
        if (licensed) f.Allow(FlagKey.BusinessOntology);
        return f;
    }

    private static ThingRef Site(AiFixture f, string name = "Corner Mart") => f.App.Ontology.CreateThing(EntityType.Site, null, name, null, 1).Ref;

    private static Item Product(AiFixture f, string name = "Basmati rice 5 kg") =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = f.App.Shop.Current.Minor("118.00"), TaxClass = "standard", TrackStock = false });

    [Fact]
    public void The_map_knows_the_shops_own_kinds_of_record_and_its_own_kinds_of_place_and_says_which_are_which()
    {
        using var f = Mapping();
        var types = f.App.Ontology.EntityTypes().ToDictionary(t => t.Name);
        foreach (var mapped in new[] { "product", "party", "user", "document", "payment", "table", "project" }) Assert.Equal(EntityKind.Mapped, types[mapped].Kind);
        foreach (var native in new[] { "site", "zone", "shelf", "device" }) Assert.Equal(EntityKind.Native, types[native].Kind);
        Assert.All(types.Values, t => Assert.True(t.Builtin));
        // What each kind holds, for the privacy rules that come later.
        Assert.Equal(DataClass.Personal, types["party"].DataClass);
        Assert.Equal(DataClass.Personal, types["user"].DataClass);
        Assert.Equal(DataClass.Financial, types["document"].DataClass);
        Assert.Equal(DataClass.Financial, types["payment"].DataClass);
        Assert.Equal(DataClass.Internal, types["zone"].DataClass);
        // Asking again changes nothing.
        Assert.Equal(types.Count, f.App.Ontology.EntityTypes().Count);
        var relations = f.App.Ontology.RelationTypes().ToDictionary(r => r.Name);
        foreach (var stored in new[] { "part_of", "located_in", "observes", "stocked_on", "supplied_by" }) Assert.False(relations[stored].Derived, stored);
        foreach (var derived in new[] { "issued_to", "handled_by", "contains", "settles", "taken_by", "seated_at", "for_project", "for_client", "corrects" }) Assert.True(relations[derived].Derived, derived);
        // Every derived connection has a rule that works it out, and every rule names a connection the map knows.
        Assert.Equal(relations.Values.Where(r => r.Derived).Select(r => r.Name).OrderBy(x => x), DerivedRules.All.Select(r => r.Relation).OrderBy(x => x));
        Assert.All(relations.Values, r => { Assert.All(r.FromTypes, x => Assert.Contains(x, types.Keys)); Assert.All(r.ToTypes, x => Assert.Contains(x, types.Keys)); });
    }

    [Fact]
    public void Nothing_can_be_added_until_the_owner_switches_the_map_on_and_the_licence_has_the_AI_part_but_it_can_always_be_read()
    {
        using var off = new AiFixture();
        Assert.False(off.App.Ontology.Writable);
        Assert.Equal("map-off", Assert.Throws<HubException>(() => off.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3", null, 1)).Code);
        Assert.Equal("map-off", Assert.Throws<HubException>(() => off.App.Ontology.AddEntityType("fridge", "Fridge", DataClass.Internal, 1)).Code);
        Assert.NotEmpty(off.App.Ontology.EntityTypes());   // reading needs nothing

        using var unlicensed = new AiFixture(licensed: false);
        Assert.Equal("not-licensed", Assert.Throws<HubException>(() => unlicensed.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3", null, 1)).Code);

        using var on = Mapping();
        on.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3", null, 1);
        on.Entitled.Allowed = false;
        Assert.Throws<HubException>(() => on.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 4", null, 1));
        Assert.Single(on.App.Ontology.Things(EntityType.Zone));
    }

    [Fact]
    public void A_place_or_device_is_added_with_a_short_plain_key_made_from_its_name_and_written_down()
    {
        using var f = Mapping();
        var zone = f.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3 (dry goods)", "{\"floor\":1}", 4);
        Assert.Equal("zone:aisle-3-dry-goods", zone.Ref.ToString());
        Assert.Equal(("Aisle 3 (dry goods)", EntityKind.Native, true, false, "{\"floor\":1}"), (zone.Label, zone.Kind, zone.Exists, zone.Retired, zone.AttributesJson));
        Assert.Equal("zone:entrance", f.App.Ontology.CreateThing(EntityType.Zone, "Entrance", "Front door", null, 4).Ref.ToString());
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "map.add" && a.Detail == "zone:aisle-3-dry-goods (Aisle 3 (dry goods))" && a.UserId == 4);
        Assert.Equal(2, f.App.Ontology.Things(EntityType.Zone).Count);
        Assert.Empty(f.App.Ontology.Things(EntityType.Shelf));
    }

    [Fact]
    public void A_thing_is_refused_for_a_known_wrong_reason_in_plain_words()
    {
        using var f = Mapping();
        Assert.Equal("duplicate-thing", Capture(() => { f.App.Ontology.CreateThing(EntityType.Zone, "back", "Back", null, 1); f.App.Ontology.CreateThing(EntityType.Zone, "back", "Back again", null, 1); }));
        Assert.Equal("mapped-type", Capture(() => f.App.Ontology.CreateThing(EntityType.Product, null, "Rice", null, 1)));
        Assert.Equal("bad-type", Capture(() => f.App.Ontology.CreateThing("spaceship", null, "Rocket", null, 1)));
        Assert.Equal("bad-key", Capture(() => f.App.Ontology.CreateThing(EntityType.Zone, "not valid!", "Name", null, 1)));
        Assert.Equal("bad-name", Capture(() => f.App.Ontology.CreateThing(EntityType.Zone, null, "  ", null, 1)));
        Assert.Equal("bad-name", Capture(() => f.App.Ontology.CreateThing(EntityType.Zone, null, "***", null, 1)));
        Assert.Equal("bad-json", Capture(() => f.App.Ontology.CreateThing(EntityType.Zone, null, "Fine", "[1]", 1)));
        Assert.Equal("never-stored", Capture(() => f.App.Ontology.CreateThing(EntityType.Zone, null, "Card 4111 1111 1111 1111", null, 1)));
        Assert.Equal("too-long", Capture(() => f.App.Ontology.CreateThing(EntityType.Zone, null, new string('x', 81), null, 1)));
        Assert.Single(f.App.Ontology.Things(EntityType.Zone));
    }

    private static string Capture(Action action) => Assert.Throws<HubException>(action).Code;

    [Fact]
    public void A_place_has_a_parent_and_a_shelf_is_in_a_place_and_a_camera_watches_a_place_and_the_map_can_say_where_a_thing_is()
    {
        using var f = Mapping();
        var site = Site(f);
        var back = f.App.Ontology.CreateThing(EntityType.Zone, null, "Back shop", null, 1).Ref;
        var aisle = f.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3", null, 1).Ref;
        var shelf = f.App.Ontology.CreateThing(EntityType.Shelf, null, "Top shelf", null, 1).Ref;
        var camera = f.App.Ontology.CreateThing(EntityType.Device, "cam-1", "Camera 1", "{\"kind\":\"camera\"}", 1).Ref;

        f.App.Ontology.Relate(RelationType.PartOf, back, site, 1);
        f.App.Ontology.Relate(RelationType.PartOf, aisle, back, 1);
        f.App.Ontology.Relate(RelationType.LocatedIn, shelf, aisle, 1);
        f.App.Ontology.Relate(RelationType.LocatedIn, camera, back, 1);
        f.App.Ontology.Relate(RelationType.Observes, camera, aisle, 1);

        Assert.Equal(new[] { "Aisle 3", "Back shop", "Corner Mart" }, f.App.Ontology.Ancestors(shelf).Select(x => x.Label).Skip(0).ToArray());
        Assert.Equal(new[] { "Back shop", "Corner Mart" }, f.App.Ontology.Ancestors(aisle).Select(x => x.Label));
        Assert.Empty(f.App.Ontology.Ancestors(site));
        Assert.Equal(new[] { aisle }, f.App.Ontology.Related(camera, OntologyService.Outgoing, RelationType.Observes).Select(l => l.To));
        Assert.Equal(new[] { camera }, f.App.Ontology.Related(aisle, OntologyService.Incoming, RelationType.Observes).Select(l => l.From));
        Assert.Equal(3, f.App.Ontology.Related(aisle).Count);   // the camera watches it, the shelf is in it, and it is part of the back shop
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "map.connect" && a.Detail == "device:cam-1 observes zone:aisle-3");
    }

    [Fact]
    public void A_stored_connection_can_join_the_shops_own_records_to_the_map()
    {
        using var f = Mapping();
        var rice = Product(f);
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Sharma Traders" });
        var shelf = f.App.Ontology.CreateThing(EntityType.Shelf, null, "Top shelf", null, 1).Ref;
        var product = new ThingRef(EntityType.Product, rice.Id.ToString());

        f.App.Ontology.Relate(RelationType.StockedOn, product, shelf, 1);
        f.App.Ontology.Relate(RelationType.SuppliedBy, product, new ThingRef(EntityType.Party, supplier.Id.ToString()), 1, "{\"leadDays\":3}");

        var links = f.App.Ontology.Related(product);
        Assert.Equal(new[] { RelationType.StockedOn, RelationType.SuppliedBy }, links.Select(l => l.Relation));
        Assert.All(links, l => Assert.False(l.Derived));
        Assert.Equal("{\"leadDays\":3}", links[1].AttributesJson);
        Assert.Equal(f.Shop.Clock.UtcNow, links[0].Since);
        Assert.Equal("is kept on", links[0].RelationLabel);
        Assert.Equal("Basmati rice 5 kg", f.App.Ontology.Resolve(product)!.Label);
        Assert.Equal("Sharma Traders", f.App.Ontology.Resolve(links[1].To)!.Label);
    }

    [Fact]
    public void A_connection_is_refused_when_it_does_not_make_sense()
    {
        using var f = Mapping();
        var site = Site(f);
        var zone = f.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3", null, 1).Ref;
        var shelf = f.App.Ontology.CreateThing(EntityType.Shelf, null, "Top shelf", null, 1).Ref;
        var rice = new ThingRef(EntityType.Product, Product(f).Id.ToString());

        Assert.Equal("bad-type", Capture(() => f.App.Ontology.Relate("likes", zone, site, 1)));
        Assert.Equal("bad-ends", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, shelf, site, 1)));        // a shelf is not part of a site: it is in a place
        Assert.Equal("bad-ends", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, zone, shelf, 1)));
        Assert.Equal("bad-ends", Capture(() => f.App.Ontology.Relate(RelationType.StockedOn, shelf, zone, 1)));      // stock is kept, shelves do not keep stock
        Assert.Equal("bad-ends", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, zone, zone, 1)));          // not itself
        Assert.Equal("no-thing", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, zone, new ThingRef(EntityType.Site, "nowhere"), 1)));
        Assert.Equal("no-thing", Capture(() => f.App.Ontology.Relate(RelationType.StockedOn, new ThingRef(EntityType.Product, "99999"), shelf, 1)));
        Assert.Equal("no-thing", Capture(() => f.App.Ontology.Relate(RelationType.StockedOn, new ThingRef(EntityType.Product, "not-a-number"), shelf, 1)));
        Assert.Equal("derived-type", Capture(() => f.App.Ontology.Relate(RelationType.Contains, rice, rice, 1)));
        Assert.Equal("derived-type", Capture(() => f.App.Ontology.Relate(RelationType.Settles, rice, rice, 1)));
        Assert.Equal("bad-source", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, zone, site, 1, null, "gossip")));
        Assert.Equal("bad-json", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, zone, site, 1, "oops")));
        Assert.Empty(f.App.Ontology.Related(zone));

        f.App.Ontology.Relate(RelationType.PartOf, zone, site, 1);
        Assert.Equal("duplicate-link", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, zone, site, 1)));
    }

    [Fact]
    public void A_place_cannot_be_put_inside_itself_however_far_round()
    {
        using var f = Mapping();
        var a = f.App.Ontology.CreateThing(EntityType.Zone, null, "A", null, 1).Ref;
        var b = f.App.Ontology.CreateThing(EntityType.Zone, null, "B", null, 1).Ref;
        var c = f.App.Ontology.CreateThing(EntityType.Zone, null, "C", null, 1).Ref;
        f.App.Ontology.Relate(RelationType.PartOf, a, b, 1);
        f.App.Ontology.Relate(RelationType.PartOf, b, c, 1);
        Assert.Equal("loop", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, c, a, 1)));
        Assert.Equal("loop", Capture(() => f.App.Ontology.Relate(RelationType.PartOf, b, a, 1)));
        // Once the chain is broken it is allowed.
        f.App.Ontology.Unrelate(f.App.Ontology.Related(b, OntologyService.Outgoing, RelationType.PartOf).Single().Id!.Value, 1);
        f.App.Ontology.Relate(RelationType.PartOf, c, a, 1);
    }

    [Fact]
    public void An_ended_connection_stays_in_the_history_with_its_days_and_can_begin_again()
    {
        using var f = Mapping();
        var site = Site(f);
        var zone = f.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3", null, 1).Ref;
        var link = f.App.Ontology.Relate(RelationType.PartOf, zone, site, 1);
        f.Shop.Clock.Advance(TimeSpan.FromDays(10));
        f.App.Ontology.Unrelate(link.Id!.Value, 2);

        Assert.Empty(f.App.Ontology.Related(zone));
        var history = Assert.Single(f.App.Ontology.Related(zone, includeEnded: true));
        Assert.Equal((f.Shop.Clock.UtcNow.AddDays(-10), f.Shop.Clock.UtcNow), (history.Since, history.Until));
        Assert.Equal("no-link", Capture(() => f.App.Ontology.Unrelate(link.Id.Value, 2)));
        Assert.Equal("no-link", Capture(() => f.App.Ontology.Unrelate(999, 2)));

        var again = f.App.Ontology.Relate(RelationType.PartOf, zone, site, 1);
        Assert.NotEqual(link.Id, again.Id);
        Assert.Equal(2, f.App.Ontology.Related(zone, includeEnded: true).Count);
        Assert.Single(f.App.Ontology.Related(zone));
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "map.disconnect" && a.UserId == 2);
    }

    [Fact]
    public void Retiring_a_place_ends_every_connection_to_it_and_it_cannot_be_connected_again()
    {
        using var f = Mapping();
        var site = Site(f);
        var zone = f.App.Ontology.CreateThing(EntityType.Zone, null, "Old store room", null, 1).Ref;
        var shelf = f.App.Ontology.CreateThing(EntityType.Shelf, null, "Shelf 1", null, 1).Ref;
        f.App.Ontology.Relate(RelationType.PartOf, zone, site, 1);
        f.App.Ontology.Relate(RelationType.LocatedIn, shelf, zone, 1);

        f.App.Ontology.Retire(zone, 3);

        Assert.True(f.App.Ontology.Resolve(zone)!.Retired);
        Assert.Empty(f.App.Ontology.Things(EntityType.Zone));
        Assert.Single(f.App.Ontology.Things(EntityType.Zone, includeRetired: true));
        Assert.Empty(f.App.Ontology.Related(zone));
        Assert.Equal(2, f.App.Ontology.Related(zone, includeEnded: true).Count);
        Assert.Equal("retired-thing", Capture(() => f.App.Ontology.Relate(RelationType.LocatedIn, shelf, zone, 1)));
        Assert.Equal("no-thing", Capture(() => f.App.Ontology.Retire(zone, 3)));
        Assert.Equal("no-thing", Capture(() => f.App.Ontology.Rename(zone, "New name", 3)));
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "map.retire" && a.Detail == "zone:old-store-room retired; 2 connections ended");
        Assert.Empty(f.App.Ontology.Check());
    }

    [Fact]
    public void A_place_can_be_renamed_and_keeps_its_key_and_its_connections()
    {
        using var f = Mapping();
        var site = Site(f);
        var zone = f.App.Ontology.CreateThing(EntityType.Zone, null, "Aisle 3", null, 1).Ref;
        f.App.Ontology.Relate(RelationType.PartOf, zone, site, 1);
        var renamed = f.App.Ontology.Rename(zone, "Snacks aisle", 1);
        Assert.Equal(("zone:aisle-3", "Snacks aisle"), (renamed.Ref.ToString(), renamed.Label));
        Assert.Single(f.App.Ontology.Related(zone));
        Assert.Equal("bad-name", Capture(() => f.App.Ontology.Rename(zone, " ", 1)));
    }

    [Fact]
    public void The_shops_own_records_are_read_in_place_never_copied_and_a_removed_record_is_noticed()
    {
        using var f = Mapping();
        var rice = Product(f);
        var product = new ThingRef(EntityType.Product, rice.Id.ToString());
        var view = f.App.Ontology.Resolve(product)!;
        Assert.Equal(("Basmati rice 5 kg", EntityKind.Mapped, DataClass.Internal), (view.Label, view.Kind, view.DataClass));
        Assert.Contains("\"kind\":\"stock\"", view.AttributesJson);
        // Nothing of the product was written to the map's own tables.
        Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM ontology_entities")));

        // A renamed product shows its new name: the map does not hold a copy.
        f.App.Catalog.Update(rice.Id, new ItemInput { Kind = "stock", Name = "Basmati rice 10 kg", PriceMinor = rice.PriceMinor, TaxClass = "standard", TrackStock = false });
        Assert.Equal("Basmati rice 10 kg", f.App.Ontology.Resolve(product)!.Label);

        Assert.Null(f.App.Ontology.Resolve(new ThingRef(EntityType.Product, "424242")));
        Assert.Null(f.App.Ontology.Resolve(new ThingRef(EntityType.Product, "abc")));
        Assert.Null(f.App.Ontology.Resolve(new ThingRef("spaceship", "1")));
        Assert.Null(f.App.Ontology.Resolve(new ThingRef(EntityType.Zone, "nowhere")));

        // A record that is removed behind the map's back is reported, not hidden.
        var shelf = f.App.Ontology.CreateThing(EntityType.Shelf, null, "Top shelf", null, 1).Ref;
        var link = f.App.Ontology.Relate(RelationType.StockedOn, product, shelf, 1);
        Assert.Empty(f.App.Ontology.Check());
        f.App.Db.InTransaction((c, t) => NextGenOS.Hub.Data.HubDb.Exec(c, "DELETE FROM items WHERE id = $id", t, ("$id", rice.Id)));
        var problem = Assert.Single(f.App.Ontology.Check());
        Assert.Equal(link.Id, problem.RelationshipId);
        Assert.Contains("product:" + rice.Id + " is in a connection", problem.What);
    }

    [Fact]
    public void Connections_the_shops_records_already_hold_are_worked_out_when_asked_and_never_stored()
    {
        using var f = Mapping();
        var rice = Product(f);
        var customer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Maria Santos" });
        var sale = f.App.Documents.Checkout(new CheckoutRequest
        {
            PartyId = customer.Id, UserId = null,
            Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 2000 } },
            Payments = { new PaymentInput { Method = "cash", AmountMinor = 30_000 } },
        });
        var document = new ThingRef(EntityType.Document, sale.Document.Id.ToString());
        var product = new ThingRef(EntityType.Product, rice.Id.ToString());
        var party = new ThingRef(EntityType.Party, customer.Id.ToString());
        var payment = new ThingRef(EntityType.Payment, sale.Payments[0].Id.ToString());

        var out1 = f.App.Ontology.Related(document, OntologyService.Outgoing);
        Assert.Contains(out1, l => l.Relation == RelationType.IssuedTo && l.To == party && l.Derived);
        Assert.Contains(out1, l => l.Relation == RelationType.Contains && l.To == product);
        var in1 = f.App.Ontology.Related(document, OntologyService.Incoming);
        Assert.Contains(in1, l => l.Relation == RelationType.Settles && l.From == payment);
        Assert.Equal(document, Assert.Single(f.App.Ontology.Related(payment, OntologyService.Outgoing, RelationType.Settles)).To);
        Assert.Equal(document, Assert.Single(f.App.Ontology.Related(product, OntologyService.Incoming, RelationType.Contains)).From);
        Assert.Equal(document, Assert.Single(f.App.Ontology.Related(party, OntologyService.Incoming, RelationType.IssuedTo)).From);
        Assert.All(f.App.Ontology.Related(document), l => { Assert.Null(l.Id); Assert.Null(l.Since); });
        Assert.Equal("INV-2026-000001", f.App.Ontology.Resolve(document)!.Label);
        Assert.Equal("Maria Santos", f.App.Ontology.Resolve(party)!.Label);

        // The same fact is never stored a second time.
        Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM ontology_relationships")));
        Assert.Empty(f.App.Ontology.Related(document, OntologyService.Both, "supplied_by"));
        Assert.Equal("bad-direction", Capture(() => f.App.Ontology.Related(document, "sideways")));
    }

    [Fact]
    public void An_owner_can_add_a_kind_of_thing_and_a_kind_of_connection_and_use_them()
    {
        using var f = Mapping();
        var fridge = f.App.Ontology.AddEntityType("fridge", "Fridge or cold room", DataClass.Internal, 1);
        Assert.Equal((EntityKind.Native, false), (fridge.Kind, fridge.Builtin));
        var site = Site(f);
        var f1 = f.App.Ontology.CreateThing("fridge", null, "Dairy fridge", null, 1).Ref;
        var zone = f.App.Ontology.CreateThing(EntityType.Zone, null, "Dairy", null, 1).Ref;
        var nextTo = f.App.Ontology.AddRelationType("cools", "keeps cold", ["fridge"], [EntityType.Zone, EntityType.Shelf], 1);
        Assert.False(nextTo.Derived);
        f.App.Ontology.Relate("cools", f1, zone, 1);
        Assert.Equal("keeps cold", Assert.Single(f.App.Ontology.Related(f1)).RelationLabel);
        Assert.Equal("bad-ends", Capture(() => f.App.Ontology.Relate("cools", zone, f1, 1)));
        _ = site;

        Assert.Equal("duplicate-type", Capture(() => f.App.Ontology.AddEntityType("fridge", "Again", DataClass.Internal, 1)));
        Assert.Equal("duplicate-type", Capture(() => f.App.Ontology.AddEntityType("zone", "Again", DataClass.Internal, 1)));
        Assert.Equal("bad-type", Capture(() => f.App.Ontology.AddEntityType("Not Valid", "x", DataClass.Internal, 1)));
        Assert.Equal("bad-class", Capture(() => f.App.Ontology.AddEntityType("camera_faces", "Faces", DataClass.Biometric, 1)));
        Assert.Equal("bad-class", Capture(() => f.App.Ontology.AddEntityType("cards", "Cards", DataClass.PaymentSensitive, 1)));
        Assert.Equal("bad-class", Capture(() => f.App.Ontology.AddEntityType("ledger", "Ledger", DataClass.Financial, 1)));
        Assert.Equal("duplicate-type", Capture(() => f.App.Ontology.AddRelationType("cools", "again", ["fridge"], [EntityType.Zone], 1)));
        Assert.Equal("duplicate-type", Capture(() => f.App.Ontology.AddRelationType("settles", "again", ["fridge"], [EntityType.Zone], 1)));
        Assert.Equal("bad-type", Capture(() => f.App.Ontology.AddRelationType("freezes", "freezes", ["freezer"], [EntityType.Zone], 1)));
        Assert.Equal("bad-type", Capture(() => f.App.Ontology.AddRelationType("freezes", "freezes", Array.Empty<string>(), [EntityType.Zone], 1)));
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "map.type" && a.Detail == "new kind of thing: fridge");
    }

    [Theory]
    [InlineData("product:12", true)]
    [InlineData("zone:aisle-3", true)]
    [InlineData("device:cam_1.left", true)]
    [InlineData("Product:12", false)]
    [InlineData("product:", false)]
    [InlineData("product", false)]
    [InlineData("product:has space", false)]
    [InlineData("maria@example.com", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void A_reference_is_a_kind_a_colon_and_a_short_key_with_no_spaces(string? text, bool valid)
    {
        Assert.Equal(valid, ThingRef.TryParse(text, out _));
        if (valid) Assert.Equal(text, ThingRef.Parse(text).ToString());
        else Assert.Equal("bad-ref", Assert.Throws<HubException>(() => ThingRef.Parse(text)).Code);
    }

    [Fact]
    public void An_event_names_things_the_way_the_map_does_so_the_two_can_be_read_together()
    {
        using var f = Mapping();
        f.Allow(FlagKey.EventEngine);
        var zone = f.App.Ontology.CreateThing(EntityType.Zone, "aisle-3", "Aisle 3", null, 1).Ref;
        var rice = new ThingRef(EntityType.Product, Product(f).Id.ToString());
        var e = f.App.Events.Append(new NextGenOS.Hub.Events.EventInput("customer_session.picked_up_product", "rule", "pickup-rule", DataClass.Internal, f.Shop.Clock.UtcNow.AddSeconds(-2),
            ObjectRef: rice.ToString(), ZoneRef: zone.ToString()));
        Assert.Equal("Aisle 3", f.App.Ontology.Resolve(ThingRef.Parse(e.ZoneRef))!.Label);
        Assert.Equal("Basmati rice 5 kg", f.App.Ontology.Resolve(ThingRef.Parse(e.ObjectRef))!.Label);
    }
}

/// <summary>The business map's own database step: tables only added, never the shop's records copied, and undone alone.</summary>
public class OntologyMigrationTests
{
    private static readonly string[] MapTables = ["ontology_entities", "ontology_entity_types", "ontology_relation_types", "ontology_relationships"];

    private static string[] Tables(HubApp app) => app.Db.Query("SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name", r => r.GetString(0)).ToArray();

    [Fact]
    public void The_map_tables_exist_with_tenant_and_site_and_are_empty_until_the_map_is_used()
    {
        using var f = new HubFixture();
        Assert.Subset(Tables(f.App).ToHashSet(), MapTables.ToHashSet());
        foreach (var table in MapTables)
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0));
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
            Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar($"SELECT COUNT(*) FROM {table}")));
        }
    }

    [Fact]
    public void The_newest_step_is_undone_alone_and_the_events_and_the_shop_stay()
    {
        using var f = new HubFixture();
        f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 42500, TaxClass = "standard" });
        f.App.Db.Rollback(3);
        var tables = Tables(f.App);
        Assert.Empty(tables.Intersect(MapTables));
        Assert.Contains("events", tables);
        Assert.Contains("ai_providers", tables);
        Assert.Equal(new long[] { 1, 2, 3 }, f.App.Db.Query("SELECT version FROM schema_version ORDER BY version", r => r.GetInt64(0)).ToArray());
        Assert.Equal("Rice", f.App.Db.Scalar("SELECT name FROM items"));
        Assert.Subset(Tables(HubApp.Open(f.App.Db.Path, f.Clock)).ToHashSet(), MapTables.ToHashSet());
    }
}

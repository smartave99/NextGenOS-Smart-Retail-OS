using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;

namespace NextGenOS.Hub.Tests;

/// <summary>Merge, products tools: quick groups of items (the older POS's combo packs, study 02 A2.7: CB1 to CB3). There is no bundle price; a group only adds its items.</summary>
public class GroupTests
{
    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static Item Goods(HubFixture f, string name, string? barcode = null) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, Barcode = barcode, PriceMinor = 10_000, TaxClass = "zero", TrackStock = false });

    [Fact]
    public void CB1_a_group_lists_its_items_with_their_usual_quantities()
    {
        using var f = Shop();
        var bread = Goods(f, "Bread");
        var milk = Goods(f, "Milk");

        var group = f.App.Groups.Save(new GroupInput { Name = "Breakfast", Barcode = "BF-1", Members = { (bread.Id, 1_000), (milk.Id, 2_000) } });

        Assert.Equal(("Breakfast", "BF-1"), (group.Name, group.Barcode));
        Assert.Equal(new[] { ("Bread", 1_000L), ("Milk", 2_000L) }, group.Members.Select(m => (m.Name, m.QtyMilli)).ToArray());
        Assert.Single(f.App.Groups.List());
        Assert.Equal(group.Id, f.App.Groups.FindByBarcode("BF-1")!.Id);
        Assert.Null(f.App.Groups.FindByBarcode("nope"));
    }

    [Fact]
    public void CB2_a_name_cannot_be_used_twice_not_even_in_other_letters()
    {
        using var f = Shop();
        var bread = Goods(f, "Bread");
        f.App.Groups.Save(new GroupInput { Name = "Breakfast", Members = { (bread.Id, 1_000) } });

        var ex = Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = "BREAKFAST", Members = { (bread.Id, 1_000) } }));

        Assert.Equal("group-name", ex.Code);
    }

    [Fact]
    public void CB3_deleting_a_group_takes_its_members_with_it_and_leaves_the_items()
    {
        using var f = Shop();
        var bread = Goods(f, "Bread");
        var group = f.App.Groups.Save(new GroupInput { Name = "Breakfast", Members = { (bread.Id, 1_000) } });

        f.App.Groups.Delete(group.Id);

        Assert.Empty(f.App.Groups.List(true));
        Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM item_group_members")));
        Assert.NotNull(f.App.Catalog.Get(bread.Id));
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Groups.Delete(group.Id)).Code);
    }

    [Fact]
    public void A_group_needs_a_name_items_with_a_quantity_each_once_and_a_barcode_that_is_not_an_items()
    {
        using var f = Shop();
        var bread = Goods(f, "Bread", "8900000000011");
        var milk = Goods(f, "Milk");
        f.App.Catalog.SetActive(milk.Id, false);

        Assert.Equal("group-name", Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = " ", Members = { (bread.Id, 1_000) } })).Code);
        Assert.Equal("group-empty", Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = "A" })).Code);
        Assert.Equal("group-twice", Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = "A", Members = { (bread.Id, 1_000), (bread.Id, 2_000) } })).Code);
        Assert.Equal("group-qty", Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = "A", Members = { (bread.Id, 0) } })).Code);
        Assert.Equal("group-item", Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = "A", Members = { (9_999, 1_000) } })).Code);
        Assert.Equal("group-item", Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = "A", Members = { (milk.Id, 1_000) } })).Code);
        Assert.Contains("on the item Bread", Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = "A", Barcode = "8900000000011", Members = { (bread.Id, 1_000) } })).Message);
        f.App.Groups.Save(new GroupInput { Name = "One", Barcode = "G1", Members = { (bread.Id, 1_000) } });
        Assert.Equal("group-barcode", Assert.Throws<HubException>(() => f.App.Groups.Save(new GroupInput { Name = "Two", Barcode = "G1", Members = { (bread.Id, 1_000) } })).Code);
    }

    [Fact]
    public void A_group_can_be_changed_and_switched_off_and_a_switched_off_group_is_not_found_by_its_barcode()
    {
        using var f = Shop();
        var bread = Goods(f, "Bread");
        var milk = Goods(f, "Milk");
        var group = f.App.Groups.Save(new GroupInput { Name = "Breakfast", Barcode = "BF", Members = { (bread.Id, 1_000) } });

        var changed = f.App.Groups.Save(new GroupInput { Id = group.Id, Name = "Morning", Barcode = "BF", Active = false, Members = { (milk.Id, 3_000) } });

        Assert.Equal(("Morning", false), (changed.Name, changed.Active));
        Assert.Equal(new[] { ("Milk", 3_000L) }, changed.Members.Select(m => (m.Name, m.QtyMilli)).ToArray());
        Assert.Empty(f.App.Groups.List());
        Assert.Single(f.App.Groups.List(true));
        Assert.Null(f.App.Groups.FindByBarcode("BF"));
    }
}

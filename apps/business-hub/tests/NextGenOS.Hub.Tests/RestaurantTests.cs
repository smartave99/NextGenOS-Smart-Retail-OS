using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Restaurant;

namespace NextGenOS.Hub.Tests;

public class RestaurantTests
{
    private static Item Dish(HubFixture f, string name, string price, string station = "Kitchen") =>
        f.App.Catalog.Create(new ItemInput { Kind = "menu", Name = name, PriceMinor = f.App.Shop.Current.Minor(price), TaxClass = "standard", Station = station });

    [Fact]
    public void The_floor_shows_free_and_busy_tables_and_a_table_has_one_open_order()
    {
        using var f = new HubFixture("GB", "restaurant");
        var t1 = f.App.Restaurant.AddTable("T1", 2, "Inside");
        var t2 = f.App.Restaurant.AddTable("T2", 4, "Inside");
        Assert.Equal("duplicate-table", Assert.Throws<HubException>(() => f.App.Restaurant.AddTable("T1")).Code);
        var coffee = Dish(f, "Coffee", "3.00", "Bar");

        Assert.All(f.App.Restaurant.Floor(), x => Assert.False(x.Occupied));
        var order = f.App.Restaurant.OpenOrder(t1.Id, 2);
        f.App.Restaurant.AddItem(order.Document.Id, coffee.Id, 2000);
        Assert.Equal(order.Document.Id, f.App.Restaurant.OpenOrder(t1.Id).Document.Id); // seating again returns the same order
        var floor = f.App.Restaurant.Floor();
        Assert.True(floor.Single(x => x.Table.Id == t1.Id).Occupied);
        Assert.Equal(2, floor.Single(x => x.Table.Id == t1.Id).Guests);
        Assert.False(floor.Single(x => x.Table.Id == t2.Id).Occupied);
        Assert.Equal("table-busy", Assert.Throws<HubException>(() => f.App.Restaurant.RemoveTable(t1.Id)).Code);
        Assert.Equal("table-busy", Assert.Throws<HubException>(() => f.App.Restaurant.Transfer(order.Document.Id, t1.Id)).Code);
        var moved = f.App.Restaurant.Transfer(order.Document.Id, t2.Id);
        Assert.Equal(t2.Id, moved.Document.TableId);
    }

    [Fact]
    public void Firing_sends_one_ticket_per_station_and_only_what_is_new_and_the_kitchen_moves_it_along()
    {
        using var f = new HubFixture("GB", "restaurant");
        var table = f.App.Restaurant.AddTable("T1");
        var coffee = Dish(f, "Coffee", "3.00", "Bar");
        var pasta = Dish(f, "Pasta", "12.00", "Kitchen");
        var cake = Dish(f, "Cake", "5.00", "Kitchen");
        var order = f.App.Restaurant.OpenOrder(table.Id);
        Assert.Equal("nothing-new", Assert.Throws<HubException>(() => f.App.Restaurant.Fire(order.Document.Id)).Code);
        f.App.Restaurant.AddItem(order.Document.Id, coffee.Id, 2000, "oat milk");
        f.App.Restaurant.AddItem(order.Document.Id, pasta.Id);

        var tickets = f.App.Restaurant.Fire(order.Document.Id);
        Assert.Equal(new[] { "Bar", "Kitchen" }, tickets.Select(t => t.Station).OrderBy(x => x).ToArray());
        Assert.Equal("oat milk", tickets.Single(t => t.Station == "Bar").Lines.Single().Note);
        Assert.Equal("T1", tickets[0].TableName);

        f.App.Restaurant.AddItem(order.Document.Id, cake.Id);
        var second = f.App.Restaurant.Fire(order.Document.Id);
        Assert.Single(second);
        Assert.Equal("Cake", second[0].Lines.Single().Description);
        Assert.Equal(3, f.App.Restaurant.Tickets().Count);
        Assert.Equal(2, f.App.Restaurant.Tickets("Kitchen").Count);

        var ticket = tickets.Single(t => t.Station == "Bar");
        Assert.Equal("preparing", f.App.Restaurant.Advance(ticket.Id).Status);
        Assert.Equal("ready", f.App.Restaurant.Advance(ticket.Id).Status);
        f.Clock.Advance(TimeSpan.FromMinutes(4));
        var served = f.App.Restaurant.Advance(ticket.Id);
        Assert.Equal("served", served.Status);
        Assert.NotNull(served.ReadyAt);
        Assert.Equal("ticket-done", Assert.Throws<HubException>(() => f.App.Restaurant.Advance(ticket.Id)).Code);
        Assert.Equal(2, f.App.Restaurant.Tickets().Count); // served tickets leave the screen

        var sent = f.App.Documents.Get(order.Document.Id)!.Lines;
        Assert.Equal("already-sent", Assert.Throws<HubException>(() => f.App.Documents.RemoveLine(order.Document.Id, sent[0].Id)).Code);
    }

    [Fact]
    public void A_bill_with_service_charge_and_tip_is_taxed_by_the_countrys_rules_and_paying_it_frees_the_table()
    {
        using var f = new HubFixture("GB", "restaurant", s => s.PricesIncludeTax = true);
        var table = f.App.Restaurant.AddTable("T1");
        var dish = Dish(f, "Set meal", "12.00");
        var order = f.App.Restaurant.OpenOrder(table.Id, 2);
        f.App.Restaurant.AddItem(order.Document.Id, dish.Id, 2000);
        // The restaurant default: 10% service charge, taxed. 24.00 incl 20% VAT => 20.00 net; service 2.00 + 0.40 VAT.
        Assert.Equal(2_640, order.Document.Id > 0 ? f.App.Documents.Get(order.Document.Id)!.Document.TotalMinor : 0);

        var withTip = f.App.Restaurant.SetBillOptions(order.Document.Id, serviceCharge: true, tipMinor: 300);
        Assert.Equal(2_640, withTip.Document.TotalMinor);
        Assert.Equal(2_940, withTip.Document.PayableMinor);
        Assert.Equal(300, withTip.Document.TipsMinor);

        var noService = f.App.Restaurant.SetBillOptions(order.Document.Id, serviceCharge: false);
        Assert.Equal(2_400, noService.Document.TotalMinor);
        f.App.Restaurant.SetBillOptions(order.Document.Id, serviceCharge: true, tipMinor: 300);

        var split = FloorOccupied(f);
        Assert.True(split);
        var paid = f.App.Restaurant.Pay(order.Document.Id, new[] { new PaymentInput { Method = "card", AmountMinor = 2_940 } });
        Assert.Equal("INV-2026-000001", paid.Document.Number); // 2026 is the fiscal year start in the UK for a date after 6 April
        Assert.Equal(DocTypes.Invoice, paid.Document.Type);
        Assert.StartsWith("ORD-", paid.Document.Meta["orderNumber"]);
        Assert.False(f.App.Restaurant.Floor().Single().Occupied);
        Assert.Equal("paid", paid.Document.PaymentState);
    }

    private static bool FloorOccupied(HubFixture f) => f.App.Restaurant.Floor().Single().Occupied;

    [Fact]
    public void A_bill_can_be_split_by_items_or_paid_in_equal_parts_that_add_up_exactly()
    {
        using var f = new HubFixture("GB", "restaurant");
        var table = f.App.Restaurant.AddTable("T1");
        var a = Dish(f, "Soup", "5.00");
        var b = Dish(f, "Steak", "20.00");
        var order = f.App.Restaurant.OpenOrder(table.Id);
        var view = f.App.Restaurant.AddItem(order.Document.Id, a.Id);
        view = f.App.Restaurant.AddItem(order.Document.Id, b.Id);
        var lines = view.Lines;
        var parts = f.App.Restaurant.SplitByLines(order.Document.Id, new[] { new long[] { lines[0].Id }, new long[] { lines[1].Id } });
        Assert.Equal(2, parts.Count);
        Assert.Equal(DocStatus.Void, f.App.Documents.Get(order.Document.Id)!.Document.Status);
        Assert.Equal(new long[] { 500 + 50, 2000 + 200 }, parts.Select(p => p.Document.TotalMinor).ToArray()); // with the 10% service charge
        foreach (var part in parts) f.App.Restaurant.Pay(part.Document.Id, new[] { new PaymentInput { Method = "cash", AmountMinor = part.Document.PayableMinor } });
        Assert.Equal(2L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE type = 'invoice' AND status = 'issued'")));

        Assert.Equal(new long[] { 3334, 3333, 3333 }, RestaurantService.EqualParts(10_000, 3));
        Assert.Equal(10_000, RestaurantService.EqualParts(10_000, 7).Sum());
        Assert.Equal("people", Assert.Throws<HubException>(() => RestaurantService.EqualParts(100, 0)).Code);
    }

    [Fact]
    public void A_split_refuses_lines_that_are_not_on_the_order_or_used_twice()
    {
        using var f = new HubFixture("GB", "restaurant");
        var table = f.App.Restaurant.AddTable("T1");
        var a = Dish(f, "Soup", "5.00");
        var order = f.App.Restaurant.OpenOrder(table.Id);
        var view = f.App.Restaurant.AddItem(order.Document.Id, a.Id);
        var lineId = view.Lines[0].Id;
        Assert.Equal("empty-group", Assert.Throws<HubException>(() => f.App.Restaurant.SplitByLines(order.Document.Id, new[] { new long[] { } })).Code);
        Assert.Equal("line-twice", Assert.Throws<HubException>(() => f.App.Restaurant.SplitByLines(order.Document.Id, new[] { new[] { lineId }, new[] { lineId } })).Code);
        Assert.Equal("line", Assert.Throws<HubException>(() => f.App.Restaurant.SplitByLines(order.Document.Id, new[] { new long[] { 9999 } })).Code);
    }

    [Fact]
    public void Cancelling_an_order_clears_its_tickets_and_needs_a_reason_and_takeaway_has_no_table()
    {
        using var f = new HubFixture("GB", "restaurant");
        var table = f.App.Restaurant.AddTable("T1");
        var a = Dish(f, "Soup", "5.00");
        var order = f.App.Restaurant.OpenOrder(table.Id);
        f.App.Restaurant.AddItem(order.Document.Id, a.Id);
        f.App.Restaurant.Fire(order.Document.Id);
        Assert.Single(f.App.Restaurant.Tickets());
        Assert.Equal("reason", Assert.Throws<HubException>(() => f.App.Restaurant.CancelOrder(order.Document.Id, "", null)).Code);
        f.App.Restaurant.CancelOrder(order.Document.Id, "guests left", null);
        Assert.Empty(f.App.Restaurant.Tickets());
        Assert.False(f.App.Restaurant.Floor().Single().Occupied);

        var take = f.App.Restaurant.OpenTakeaway("Maya");
        f.App.Restaurant.AddItem(take.Document.Id, a.Id, 2000);
        var tickets = f.App.Restaurant.Fire(take.Document.Id);
        Assert.Equal("Takeaway: Maya", tickets.Single().TableName);
        var paid = f.App.Restaurant.Pay(take.Document.Id, new[] { new PaymentInput { Method = "cash", AmountMinor = 1_200 } });
        Assert.Equal(1_000, paid.Document.TotalMinor);
        Assert.Equal(1_000, paid.Document.PaidMinor);
    }

    [Fact]
    public void Table_turnover_counts_paid_bills_and_how_long_guests_stayed()
    {
        using var f = new HubFixture("GB", "restaurant");
        var table = f.App.Restaurant.AddTable("T1");
        var a = Dish(f, "Soup", "5.00");
        var order = f.App.Restaurant.OpenOrder(table.Id);
        f.App.Restaurant.AddItem(order.Document.Id, a.Id);
        f.Clock.Advance(TimeSpan.FromMinutes(45));
        f.App.Restaurant.Pay(order.Document.Id, new[] { new PaymentInput { Method = "cash", AmountMinor = 550 } });
        var row = f.App.Restaurant.Turnover(f.Clock.UtcNow.AddHours(-2), f.Clock.UtcNow.AddHours(1)).Single();
        Assert.Equal("T1", row.Table);
        Assert.Equal(1, row.Bills);
        Assert.Equal(45, row.AverageMinutes);
    }
}

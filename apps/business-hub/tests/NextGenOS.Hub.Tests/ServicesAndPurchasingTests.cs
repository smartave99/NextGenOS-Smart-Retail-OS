using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;

namespace NextGenOS.Hub.Tests;

public class AppointmentTests
{
    private static (HubFixture F, Party Kavya, Party Imran, Item Cut, Item Colour, Party Client) Studio()
    {
        // 5 October 2026 is a Monday; 12:00 in India.
        var f = new HubFixture("IN", "services");
        var kavya = f.App.Parties.Create(new PartyInput { Kind = "staff", Name = "Kavya" });
        var imran = f.App.Parties.Create(new PartyInput { Kind = "staff", Name = "Imran" });
        var cut = f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Haircut", PriceMinor = 40_000, DurationMin = 30 });
        var colour = f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Hair colour", PriceMinor = 180_000, DurationMin = 90 });
        var client = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Priya" });
        return (f, kavya, imran, cut, colour, client);
    }

    private static readonly DateOnly Monday = new(2026, 10, 5);
    private static readonly DateOnly Tuesday = new(2026, 10, 6);
    private static readonly DateOnly Sunday = new(2026, 10, 11);

    [Fact]
    public void A_booking_takes_the_services_time_and_a_staff_member_cannot_be_double_booked()
    {
        var (f, kavya, imran, cut, colour, client) = Studio();
        using (f)
        {
            var a = f.App.Appointments.Book(client.Id, kavya.Id, colour.Id, Tuesday, new TimeOnly(10, 0));
            Assert.Equal(f.App.Shop.Current.Time.At(Tuesday, new TimeOnly(11, 30)), a.End);
            var clash = Assert.Throws<HubException>(() => f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Tuesday, new TimeOnly(11, 0)));
            Assert.Equal("clash", clash.Code);
            Assert.Contains("10:00 to 11:30", clash.Message);
            f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Tuesday, new TimeOnly(11, 30)); // right after: fine
            f.App.Appointments.Book(client.Id, imran.Id, cut.Id, Tuesday, new TimeOnly(10, 30)); // another staff member: fine
            Assert.Equal(3, f.App.Appointments.Day(Tuesday).Count);
            Assert.Equal(2, f.App.Appointments.Day(Tuesday, kavya.Id).Count);
        }
    }

    [Fact]
    public void Bookings_respect_opening_hours_closed_days_and_the_past()
    {
        var (f, kavya, _, cut, colour, client) = Studio();
        using (f)
        {
            Assert.Equal("closed", Assert.Throws<HubException>(() => f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Sunday, new TimeOnly(10, 0))).Code);
            Assert.Equal("hours", Assert.Throws<HubException>(() => f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Tuesday, new TimeOnly(8, 30))).Code);
            Assert.Equal("hours", Assert.Throws<HubException>(() => f.App.Appointments.Book(client.Id, kavya.Id, colour.Id, Tuesday, new TimeOnly(17, 0))).Code); // runs past 18:00
            Assert.Equal("past", Assert.Throws<HubException>(() => f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Monday, new TimeOnly(9, 0))).Code);
            f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Monday, new TimeOnly(9, 0), walkIn: true); // a walk-in is recorded even though the hour is gone
            Assert.Equal("staff", Assert.Throws<HubException>(() => f.App.Appointments.Book(client.Id, client.Id, cut.Id, Tuesday, new TimeOnly(10, 0))).Code);
            Assert.Equal("not-service", Assert.Throws<HubException>(() => f.App.Appointments.Book(client.Id, kavya.Id, f.App.Catalog.Create(new ItemInput { Name = "Shampoo", Kind = "stock", PriceMinor = 100 }).Id, Tuesday, new TimeOnly(10, 0))).Code);
        }
    }

    [Fact]
    public void Free_slots_leave_out_what_is_taken_and_what_would_not_fit()
    {
        var (f, kavya, _, cut, colour, client) = Studio();
        using (f)
        {
            Assert.Equal(18, f.App.Appointments.FreeSlots(kavya.Id, cut.Id, Tuesday).Count); // 09:00 to 18:00 in half hours
            f.App.Appointments.Book(client.Id, kavya.Id, colour.Id, Tuesday, new TimeOnly(10, 0));
            var slots = f.App.Appointments.FreeSlots(kavya.Id, cut.Id, Tuesday);
            Assert.DoesNotContain(new TimeOnly(10, 0), slots);
            Assert.DoesNotContain(new TimeOnly(11, 0), slots);
            Assert.Contains(new TimeOnly(11, 30), slots);
            Assert.Contains(new TimeOnly(9, 30), slots);
            Assert.DoesNotContain(new TimeOnly(9, 45), slots);
            Assert.Empty(f.App.Appointments.FreeSlots(kavya.Id, cut.Id, Sunday));
            Assert.DoesNotContain(new TimeOnly(17, 30), f.App.Appointments.FreeSlots(kavya.Id, colour.Id, Tuesday)); // 90 minutes would pass 18:00
        }
    }

    [Fact]
    public void A_visit_goes_from_booked_to_arrived_to_done_and_becomes_an_invoice_with_extras_and_staff_sales()
    {
        var (f, kavya, _, cut, _, client) = Studio();
        using (f)
        {
            var serum = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Serum", PriceMinor = 75_000, TrackStock = true });
            f.App.Catalog.Adjust(serum.Id, 5_000, "delivery");
            var a = f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Tuesday, new TimeOnly(10, 0));
            Assert.Equal("status", Assert.Throws<HubException>(() => f.App.Appointments.SetStatus(a.Id, "done")).Code);
            f.App.Appointments.SetStatus(a.Id, "arrived");
            var view = f.App.Appointments.Invoice(a.Id, new[] { new LineInput { ItemId = serum.Id } }, new[] { new PaymentInput { Method = "card", AmountMinor = 115_000 } });
            Assert.Equal(115_000, view.Document.TotalMinor);
            Assert.Equal("done", f.App.Appointments.Get(a.Id)!.Status);
            Assert.Equal(4_000, f.App.Catalog.OnHandMilli(serum.Id));
            Assert.Equal("invoiced", Assert.Throws<HubException>(() => f.App.Appointments.Invoice(a.Id, null, new[] { new PaymentInput { AmountMinor = 1 } })).Code);
            var sales = f.App.Appointments.SalesByStaff(f.Clock.UtcNow.AddDays(-1), f.Clock.UtcNow.AddDays(1)).Single();
            Assert.Equal("Kavya", sales.Name);
            Assert.Equal(115_000, sales.SalesMinor);
        }
    }

    [Fact]
    public void A_cancelled_booking_frees_the_time_and_cannot_be_invoiced()
    {
        var (f, kavya, _, cut, _, client) = Studio();
        using (f)
        {
            var a = f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Tuesday, new TimeOnly(10, 0));
            f.App.Appointments.SetStatus(a.Id, "cancelled");
            Assert.Equal("status", Assert.Throws<HubException>(() => f.App.Appointments.Invoice(a.Id, null, new[] { new PaymentInput { AmountMinor = 1 } })).Code);
            Assert.Equal("status", Assert.Throws<HubException>(() => f.App.Appointments.SetStatus(a.Id, "arrived")).Code);
            f.App.Appointments.Book(client.Id, kavya.Id, cut.Id, Tuesday, new TimeOnly(10, 0));
        }
    }
}

public class PurchasingTests
{
    [Fact]
    public void Receiving_a_purchase_order_adds_stock_updates_the_cost_and_the_supplier_is_paid_in_parts()
    {
        using var f = new HubFixture("IN", "wholesale");
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice 25 kg", PriceMinor = 170_000, TaxClass = "reduced" });
        var po = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 40_000, CostMinor = 150_000 } });
        Assert.StartsWith("PO-", po.Document.Number);
        Assert.Equal(DocStatus.Open, po.Document.Status);
        Assert.Equal(0, f.App.Catalog.OnHandMilli(rice.Id));

        var received = f.App.Purchasing.Receive(po.Document.Id);
        Assert.Equal(po.Document.Number, received.Document.Number); // the order keeps its number
        Assert.Equal(DocStatus.Issued, received.Document.Status);
        Assert.Equal(40_000, f.App.Catalog.OnHandMilli(rice.Id));
        Assert.Equal(150_000, f.App.Catalog.Get(rice.Id)!.CostMinor);
        Assert.Single(f.App.Purchasing.Payable());

        var total = received.Document.PayableMinor;
        f.App.Purchasing.Pay(po.Document.Id, 1_000_000, "bank", "UTR 1");
        Assert.Equal(total - 1_000_000, f.App.Purchasing.Payable().Single().BalanceMinor);
        f.App.Purchasing.Pay(po.Document.Id, total - 1_000_000, "bank");
        Assert.Empty(f.App.Purchasing.Payable());
        Assert.Equal(0, f.App.Documents.Outstanding(supplier.Id)); // what a supplier is owed is not what a customer owes
    }

    [Fact]
    public void Only_suppliers_are_ordered_from_and_an_empty_order_is_refused()
    {
        using var f = new HubFixture("IN", "wholesale");
        var customer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "A customer" });
        var item = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Item", PriceMinor = 100 });
        Assert.Equal("not-supplier", Assert.Throws<HubException>(() => f.App.Purchasing.CreateOrder(customer.Id, new[] { new PurchaseLine { ItemId = item.Id, QtyMilli = 1000, CostMinor = 50 } })).Code);
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "S" });
        Assert.Equal("empty", Assert.Throws<HubException>(() => f.App.Purchasing.CreateOrder(supplier.Id, Array.Empty<PurchaseLine>())).Code);
    }
}

using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Lending;

namespace NextGenOS.Hub.Tests;

public class LibraryTests
{
    private static HubFixture Library(Action<NextGenOS.Hub.Shop.ShopSettings>? configure = null) => new("IN", "library", configure);

    private static Party Member(HubFixture f, string name = "Asha", string type = "adult", string? card = null) =>
        f.App.Parties.Create(new PartyInput { Kind = "member", Name = name, MemberType = type, CardBarcode = card });

    private static (Item Title, IReadOnlyList<Copy> Copies) BookWithCopies(HubFixture f, string name = "The Hobbit", int copies = 2, string? isbn = "9780261103344", long price = 40_000)
    {
        var title = f.App.Library.AddTitle(name, "Tolkien", isbn, "Fiction", price);
        return (title, f.App.Library.AddCopies(title.Id, copies));
    }

    [Fact]
    public void An_ISBN_is_checked_and_each_copy_gets_its_own_barcode()
    {
        Assert.True(Isbn.IsValid("978-0-261-10334-4"));
        Assert.True(Isbn.IsValid("0-306-40615-2"));
        Assert.True(Isbn.IsValid("080442957X"));
        Assert.False(Isbn.IsValid("9780261103345"));
        Assert.False(Isbn.IsValid("12345"));
        using var f = Library();
        Assert.Equal("isbn", Assert.Throws<HubException>(() => f.App.Library.AddTitle("Bad", null, "9780261103345")).Code);
        var (title, copies) = BookWithCopies(f, copies: 3);
        Assert.Equal(new[] { $"C{title.Id:0000}-001", $"C{title.Id:0000}-002", $"C{title.Id:0000}-003" }, copies.Select(c => c.Barcode).ToArray());
        var more = f.App.Library.AddCopies(title.Id, 1);
        Assert.Equal($"C{title.Id:0000}-004", more[0].Barcode);
        Assert.Equal(4, f.App.Library.AvailableCopies(title.Id));
        Assert.Equal("duplicate-barcode", Assert.Throws<HubException>(() => f.App.Library.AddTitle("Same ISBN", null, "9780261103344")).Code);
    }

    [Fact]
    public void A_loan_is_due_at_the_end_of_the_day_the_period_runs_out_in_the_shops_own_time()
    {
        using var f = Library(); // 12:00 in India on 5 October 2026
        var member = Member(f);
        var (_, copies) = BookWithCopies(f);
        var loan = f.App.Library.Issue(member.Id, copies[0].Barcode);
        // 14 days: due the end of 19 October, which is the start of 20 October in India (18:30 UTC on the 19th)
        Assert.Equal(new DateTimeOffset(2026, 10, 19, 18, 30, 0, TimeSpan.Zero), loan.DueAt);
        Assert.Equal("on-loan", f.App.Library.FindCopy(copies[0].Barcode)!.Status);
    }

    [Fact]
    public void A_copy_cannot_be_lent_twice_and_a_member_has_a_limit_by_membership_type_and_is_stopped_by_overdue_items_or_fines()
    {
        using var f = Library();
        var child = Member(f, "Tara", "child"); // 3 loans
        var (_, copies) = BookWithCopies(f, "Many books", 5);
        for (var i = 0; i < 3; i++) f.App.Library.Issue(child.Id, copies[i].Barcode);
        Assert.Equal("limit", Assert.Throws<HubException>(() => f.App.Library.Issue(child.Id, copies[3].Barcode)).Code);

        var other = Member(f, "Ravi");
        Assert.Equal("copy-on-loan", Assert.Throws<HubException>(() => f.App.Library.Issue(other.Id, copies[0].Barcode)).Code);
        Assert.Equal("copy-not-found", Assert.Throws<HubException>(() => f.App.Library.Issue(other.Id, "NOPE")).Code);

        // an overdue item blocks new loans
        f.Clock.Advance(TimeSpan.FromDays(15));
        Assert.Equal("overdue", Assert.Throws<HubException>(() => f.App.Library.Issue(child.Id, copies[3].Barcode)).Code);
        // returning it late makes a fine, which blocks until paid or waived
        var returned = f.App.Library.Return(copies[0].Barcode);
        Assert.True(returned.FineMinor > 0);
        f.App.Library.Return(copies[1].Barcode);
        f.App.Library.Return(copies[2].Barcode);
        Assert.Equal("fines", Assert.Throws<HubException>(() => f.App.Library.Issue(child.Id, copies[3].Barcode)).Code);
        var fines = f.App.Library.UnpaidFines(child.Id);
        foreach (var fine in fines) f.App.Library.Waive(fine.Id, "first offence", null);
        Assert.NotNull(f.App.Library.Issue(child.Id, copies[3].Barcode));
        Assert.Equal("not-unpaid", Assert.Throws<HubException>(() => f.App.Library.Waive(fines[0].Id, "again", null)).Code);
    }

    [Fact]
    public void Fines_are_per_late_day_after_the_grace_period_and_stop_at_the_cap()
    {
        using var f = Library(s => { s.RuleOverrides["graceDays"] = "2"; s.RuleOverrides["fineCap"] = "10.00"; s.RuleOverrides["finePerDay"] = "1.50"; });
        var member = Member(f);
        var (_, copies) = BookWithCopies(f, copies: 3);
        // returned on time: no fine
        f.App.Library.Issue(member.Id, copies[0].Barcode);
        f.Clock.Advance(TimeSpan.FromDays(14));
        Assert.Equal(0, f.App.Library.Return(copies[0].Barcode).FineMinor);

        // 1 day late is inside the 2-day grace
        f.App.Library.Issue(member.Id, copies[1].Barcode);
        f.Clock.Advance(TimeSpan.FromDays(15));
        var r1 = f.App.Library.Return(copies[1].Barcode);
        Assert.Equal(0, r1.FineMinor);

        // 5 days late: 3 chargeable days x 1.50
        f.App.Library.Issue(member.Id, copies[2].Barcode);
        f.Clock.Advance(TimeSpan.FromDays(19));
        var r2 = f.App.Library.Return(copies[2].Barcode);
        Assert.Equal(450, r2.FineMinor);
        Assert.Equal(3, r2.DaysLate);
        f.App.Library.Waive(f.App.Library.UnpaidFines(member.Id)[0].Id, "test", null);

        // 40 days late: capped at 10.00
        f.App.Library.Issue(member.Id, copies[0].Barcode);
        f.Clock.Advance(TimeSpan.FromDays(54));
        Assert.Equal(1_000, f.App.Library.Return(copies[0].Barcode).FineMinor);
    }

    [Fact]
    public void Renewing_extends_the_loan_up_to_the_limit_and_not_when_overdue_or_when_someone_is_waiting()
    {
        using var f = Library();
        var member = Member(f);
        var waiting = Member(f, "Waiting member");
        var (title, copies) = BookWithCopies(f, copies: 1);
        var loan = f.App.Library.Issue(member.Id, copies[0].Barcode);
        f.Clock.Advance(TimeSpan.FromDays(5));
        var renewed = f.App.Library.Renew(loan.Id);
        Assert.Equal(1, renewed.Renewals);
        Assert.True(renewed.DueAt > loan.DueAt);
        f.App.Library.Renew(loan.Id);
        Assert.Equal("renew-limit", Assert.Throws<HubException>(() => f.App.Library.Renew(loan.Id)).Code);

        var second = BookWithCopies(f, "Another", 1, "9780141439518");
        var l2 = f.App.Library.Issue(member.Id, second.Copies[0].Barcode);
        f.App.Library.Reserve(second.Title.Id, waiting.Id);
        Assert.Equal("reserved", Assert.Throws<HubException>(() => f.App.Library.Renew(l2.Id)).Code);

        f.Clock.Advance(TimeSpan.FromDays(20));
        Assert.Equal("overdue", Assert.Throws<HubException>(() => f.App.Library.Renew(l2.Id)).Code);
        Assert.NotNull(title);
    }

    [Fact]
    public void A_reservation_holds_the_returned_copy_for_the_first_in_the_queue_and_lets_go_when_it_is_not_collected()
    {
        using var f = Library();
        var holder = Member(f, "Holder");
        var first = Member(f, "First in line");
        var second = Member(f, "Second in line");
        var (title, copies) = BookWithCopies(f, copies: 1);

        Assert.Equal("available", Assert.Throws<HubException>(() => f.App.Library.Reserve(title.Id, first.Id)).Code);
        f.App.Library.Issue(holder.Id, copies[0].Barcode);
        var r1 = f.App.Library.Reserve(title.Id, first.Id);
        f.Clock.Advance(TimeSpan.FromMinutes(5));
        f.App.Library.Reserve(title.Id, second.Id);
        Assert.Equal("already-reserved", Assert.Throws<HubException>(() => f.App.Library.Reserve(title.Id, first.Id)).Code);
        Assert.Equal("has-it", Assert.Throws<HubException>(() => f.App.Library.Reserve(title.Id, holder.Id)).Code);

        var back = f.App.Library.Return(copies[0].Barcode);
        Assert.Equal("First in line", back.HeldForMember);
        Assert.Equal("held", f.App.Library.FindCopy(copies[0].Barcode)!.Status);
        Assert.Equal("copy-held", Assert.Throws<HubException>(() => f.App.Library.Issue(second.Id, copies[0].Barcode)).Code);

        // not collected within the hold days: it passes to the second member
        f.Clock.Advance(TimeSpan.FromDays(4));
        f.App.Library.ProcessHolds();
        Assert.Equal("expired", f.App.Library.ReservationById(r1.Id)!.Status);
        Assert.Equal("held", f.App.Library.FindCopy(copies[0].Barcode)!.Status);
        Assert.Equal("ready", f.App.Library.ReservationsOf(second.Id).Single().Status);
        var loan = f.App.Library.Issue(second.Id, copies[0].Barcode);
        Assert.Equal(second.Id, loan.PartyId);
        Assert.Empty(f.App.Library.ReservationsOf(second.Id));
    }

    [Fact]
    public void Cancelling_a_ready_reservation_puts_the_copy_back_on_the_shelf()
    {
        using var f = Library();
        var holder = Member(f, "Holder");
        var waiter = Member(f, "Waiter");
        var (title, copies) = BookWithCopies(f, copies: 1);
        f.App.Library.Issue(holder.Id, copies[0].Barcode);
        var r = f.App.Library.Reserve(title.Id, waiter.Id);
        f.App.Library.Return(copies[0].Barcode);
        f.App.Library.CancelReservation(r.Id);
        Assert.Equal("available", f.App.Library.FindCopy(copies[0].Barcode)!.Status);
    }

    [Fact]
    public void Paying_fines_makes_a_receipt_with_the_fines_as_untaxed_fees_and_clears_them()
    {
        using var f = Library();
        var member = Member(f);
        var (_, copies) = BookWithCopies(f, copies: 2);
        f.App.Library.Issue(member.Id, copies[0].Barcode);
        f.Clock.Advance(TimeSpan.FromDays(20)); // due after 14 days: 6 days late at 1.00
        var back = f.App.Library.Return(copies[0].Barcode);
        Assert.Equal(600, back.FineMinor);
        f.App.Library.Charge(member.Id, 2_500, "Membership card replacement", null);
        var view = f.App.Library.PayFines(member.Id, new[] { new PaymentInput { Method = "cash", AmountMinor = 3_100 } }, null);
        Assert.Equal(3_100, view.Document.TotalMinor);
        Assert.Equal(0, view.Document.TaxMinor);
        Assert.Equal("paid", view.Document.PaymentState);
        Assert.Equal(2, view.Adjustments.Count);
        Assert.Empty(f.App.Library.UnpaidFines(member.Id));
        Assert.Equal(3_100, f.App.Library.FinesCollected(f.Clock.UtcNow.AddDays(-1), f.Clock.UtcNow.AddDays(1)));
        Assert.Equal("no-fines", Assert.Throws<HubException>(() => f.App.Library.PayFines(member.Id, new[] { new PaymentInput { AmountMinor = 1 } }, null)).Code);
        Assert.NotNull(f.App.Library.Issue(member.Id, copies[1].Barcode)); // fines paid: borrowing is allowed again
    }

    [Fact]
    public void A_lost_copy_charges_the_titles_price_and_leaves_the_catalogue_of_available_copies()
    {
        using var f = Library();
        var member = Member(f);
        var (title, copies) = BookWithCopies(f, copies: 2, price: 45_000);
        var loan = f.App.Library.Issue(member.Id, copies[0].Barcode);
        var fine = f.App.Library.MarkLost(loan.Id, null);
        Assert.Equal(45_000, fine.AmountMinor);
        Assert.Equal("lost", f.App.Library.FindCopy(copies[0].Barcode)!.Status);
        Assert.Equal(1, f.App.Library.AvailableCopies(title.Id));
        Assert.Equal("copy-gone", Assert.Throws<HubException>(() => f.App.Library.Issue(Member(f, "Other").Id, copies[0].Barcode)).Code);
        Assert.Equal("returned", Assert.Throws<HubException>(() => f.App.Library.MarkLost(loan.Id, null)).Code);
    }

    [Fact]
    public void The_overdue_list_shows_who_has_what_how_late_and_the_fine_so_far_and_popular_titles_are_counted()
    {
        using var f = Library();
        var member = Member(f);
        var (title, copies) = BookWithCopies(f, copies: 2);
        f.App.Library.Issue(member.Id, copies[0].Barcode);
        f.App.Library.Issue(Member(f, "Ravi").Id, copies[1].Barcode);
        Assert.Empty(f.App.Library.Overdue());
        f.Clock.Advance(TimeSpan.FromDays(17));
        var overdue = f.App.Library.Overdue();
        Assert.Equal(2, overdue.Count);
        Assert.All(overdue, o => Assert.Equal(3, o.DaysLate)); // due 19 Oct (end of day); on 22 Oct it is 3 days late
        Assert.All(overdue, o => Assert.Equal(300, o.FineSoFarMinor));
        var popular = f.App.Library.Popular(f.Clock.UtcNow.AddDays(-30), f.Clock.UtcNow.AddDays(1));
        Assert.Equal(title.Id, popular.Single().ItemId);
        Assert.Equal(2, popular.Single().Loans);
    }

    [Fact]
    public void Only_members_borrow_and_a_switched_off_membership_stops_loans_and_withdrawn_copies_cannot_be_lent()
    {
        using var f = Library();
        var customer = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "A supplier" });
        var (_, copies) = BookWithCopies(f, copies: 2);
        Assert.Equal("not-member", Assert.Throws<HubException>(() => f.App.Library.Issue(customer.Id, copies[0].Barcode)).Code);
        var member = Member(f);
        f.App.Parties.SetActive(member.Id, false);
        Assert.Equal("member-off", Assert.Throws<HubException>(() => f.App.Library.Issue(member.Id, copies[0].Barcode)).Code);
        f.App.Parties.SetActive(member.Id, true);
        f.App.Library.WithdrawCopy(copies[0].Id, "torn", null);
        Assert.Equal("copy-gone", Assert.Throws<HubException>(() => f.App.Library.Issue(member.Id, copies[0].Barcode)).Code);
        f.App.Library.Issue(member.Id, copies[1].Barcode);
        Assert.Equal("on-loan", Assert.Throws<HubException>(() => f.App.Library.WithdrawCopy(copies[1].Id, "x", null)).Code);
    }

    [Fact]
    public void A_member_is_found_by_card_or_name()
    {
        using var f = Library();
        var member = Member(f, "Asha Verma", "adult", "M-0001");
        Assert.Equal(member.Id, f.App.Library.FindMember("M-0001")!.Id);
        Assert.Equal(member.Id, f.App.Library.FindMember("verma")!.Id);
        Assert.Null(f.App.Library.FindMember("nobody"));
        Assert.Equal("duplicate-card", Assert.Throws<HubException>(() => Member(f, "Other", "adult", "M-0001")).Code);
    }
}

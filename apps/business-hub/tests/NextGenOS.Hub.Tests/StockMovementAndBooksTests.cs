using NextGenOS.Hub;
using NextGenOS.Hub.Books;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Reports;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge wave 2, reports from the older POS: the stock movement report (study 01 section 6.7, S11) and the day book and cash and bank books (study 02). Shop in India, rupees, local time UTC+5:30
/// (the clock starts at 12:00 on 5 October, which is 06:30 UTC). The numbers are worked by hand beside each case.
/// </summary>
public class StockMovementAndBooksTests
{
    private static readonly DateOnly Oct4 = new(2026, 10, 4);
    private static readonly DateOnly Oct5 = new(2026, 10, 5);
    private static readonly DateOnly Oct6 = new(2026, 10, 6);

    private static DateTimeOffset NoonOn(int day) => new(2026, 10, day, 6, 30, 0, TimeSpan.Zero);   // 12:00 in India

    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static Item Product(HubFixture f, string name, long costMinor = 5_000) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = 10_000, CostMinor = costMinor, TaxClass = "standard", TrackStock = true });

    private static void Sell(HubFixture f, Item item, long qtyMilli) => f.App.Documents.Checkout(new CheckoutRequest
    {
        Lines = { new LineInput { ItemId = item.Id, QtyMilli = qtyMilli } },
        Payments = { new PaymentInput { Method = "cash", AmountMinor = 1_000_000 } },
    });

    /// <summary>
    /// Rice, cost 50.00 each. 4 Oct: a delivery of 10. 5 Oct: a sale of 2, 1 damaged, a delivery of 4. 6 Oct: a sale of 3, a count that found half a unit more.
    /// </summary>
    private static (HubFixture F, Item Rice) ThreeDaysOfRice()
    {
        var f = Shop();
        var rice = Product(f, "Rice");
        f.Clock.Set(NoonOn(4));
        f.App.Catalog.Adjust(rice.Id, 10_000, "delivery");
        f.Clock.Set(NoonOn(5));
        Sell(f, rice, 2_000);
        f.App.Catalog.Adjust(rice.Id, -1_000, "damaged", "wet in the rain");
        f.App.Catalog.Adjust(rice.Id, 4_000, "delivery");
        f.Clock.Set(NoonOn(6));
        Sell(f, rice, 3_000);
        f.App.Catalog.Adjust(rice.Id, 500, "count");
        return (f, rice);
    }

    // ---- the stock movement report ---------------------------------------------------------------------------------------------

    [Fact]
    public void A_period_shows_what_was_held_before_what_came_in_what_went_out_and_what_was_left()
    {
        var (f, rice) = ThreeDaysOfRice();
        using (f)
        {
            // before 5 Oct: 10. In: 4 + 0.5 = 4.5. Out: sale 2 + damaged 1 + sale 3 = 6. Left: 10 + 4.5 - 6 = 8.5
            var row = Assert.Single(f.App.Reports.StockMovement(Oct5, Oct6));
            Assert.Equal((rice.Id, "Rice", 10_000L, 4_500L, 6_000L, 8_500L), (row.ItemId, row.Name, row.OpeningMilli, row.InMilli, row.OutMilli, row.ClosingMilli));
            Assert.Null(row.Day);
            // for a period that ends today, what was left is what the shelf holds now
            Assert.Equal(f.App.Catalog.OnHandMilli(rice.Id), row.ClosingMilli);
        }
    }

    [Fact]
    public void By_day_each_day_starts_where_the_last_one_ended()
    {
        var (f, _) = ThreeDaysOfRice();
        using (f)
        {
            var rows = f.App.Reports.StockMovement(Oct4, Oct6, byDay: true);
            // 4 Oct: 0 + 10 - 0 = 10.  5 Oct: 10 + 4 - 3 (sale 2, damaged 1) = 11.  6 Oct: 11 + 0.5 - 3 = 8.5
            Assert.Equal(new[] { (Oct4, 0L, 10_000L, 0L, 10_000L), (Oct5, 10_000L, 4_000L, 3_000L, 11_000L), (Oct6, 11_000L, 500L, 3_000L, 8_500L) },
                rows.Select(r => (r.Day!.Value, r.OpeningMilli, r.InMilli, r.OutMilli, r.ClosingMilli)).ToArray());
        }
    }

    [Fact]
    public void A_period_with_no_moves_shows_stock_that_was_held_and_nothing_that_was_not()
    {
        var (f, rice) = ThreeDaysOfRice();
        using (f)
        {
            Assert.Empty(f.App.Reports.StockMovement(new DateOnly(2026, 10, 1), new DateOnly(2026, 10, 3)));    // nothing existed yet
            var later = Assert.Single(f.App.Reports.StockMovement(new DateOnly(2026, 10, 10), new DateOnly(2026, 10, 11)));    // 8.5 on the shelf, nothing moved
            Assert.Equal((rice.Id, 8_500L, 0L, 0L, 8_500L), (later.ItemId, later.OpeningMilli, later.InMilli, later.OutMilli, later.ClosingMilli));
            Assert.Empty(f.App.Reports.StockMovement(new DateOnly(2026, 10, 10), new DateOnly(2026, 10, 11), byDay: true));
        }
    }

    [Fact]
    public void One_item_can_be_chosen_and_every_item_closes_at_what_the_shelf_holds()
    {
        var (f, rice) = ThreeDaysOfRice();
        using (f)
        {
            var pen = Product(f, "Pen", 800);
            f.App.Catalog.Adjust(pen.Id, 20_000, "delivery");
            f.Clock.Set(NoonOn(6).AddHours(1));
            Sell(f, pen, 5_000);

            var all = f.App.Reports.StockMovement(Oct5, Oct6);
            Assert.Equal(new[] { "Pen", "Rice" }, all.Select(r => r.Name).ToArray());     // by name
            foreach (var row in all) Assert.Equal(f.App.Catalog.OnHandMilli(row.ItemId), row.ClosingMilli);
            var pens = Assert.Single(f.App.Reports.StockMovement(Oct5, Oct6, pen.Id));
            Assert.Equal((0L, 20_000L, 5_000L, 15_000L), (pens.OpeningMilli, pens.InMilli, pens.OutMilli, pens.ClosingMilli));
            Assert.Equal(rice.Id, Assert.Single(f.App.Reports.StockMovement(Oct5, Oct6, rice.Id)).ItemId);
        }
    }

    [Fact]
    public void Damage_is_a_move_out_in_the_report_unlike_the_older_program_where_it_was_not()
    {
        var (f, rice) = ThreeDaysOfRice();
        using (f)
        {
            // 5 Oct alone: the sale of 2 and the damaged 1 both leave: out 3; the older POS's report would have shown 2
            var day = Assert.Single(f.App.Reports.StockMovement(Oct5, Oct5));
            Assert.Equal((10_000L, 4_000L, 3_000L, 11_000L), (day.OpeningMilli, day.InMilli, day.OutMilli, day.ClosingMilli));
            Assert.Equal(rice.Id, day.ItemId);
        }
    }

    // ---- the stock card ---------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_card_of_an_item_lists_each_move_with_its_reason_its_value_and_the_bill_it_came_with()
    {
        var (f, rice) = ThreeDaysOfRice();
        using (f)
        {
            var card = f.App.Reports.StockCard(rice.Id, Oct5, Oct6);
            // all at 50.00 each: sale 2 = -100.00; damaged 1 = -50.00; delivery 4 at the last cost = +200.00; sale 3 = -150.00; a count that found 0.5 more, at the average = +25.00
            Assert.Equal(new[] { ("sale", -2_000L, -10_000L), ("damaged", -1_000L, -5_000L), ("delivery", 4_000L, 20_000L), ("sale", -3_000L, -15_000L), ("count", 500L, 2_500L) },
                card.Select(c => (c.Reason, c.QtyMilli, c.ValueMinor!.Value)).ToArray());
            Assert.StartsWith("INV", card[0].Document);
            Assert.Null(card[1].Document);
            Assert.Equal("wet in the rain", card[1].Note);
            Assert.Equal(rice.Id, f.App.Reports.StockMovement(Oct5, Oct6).Single().ItemId);
            // the sum of the card is what the period added up to: 4.5 in, 6 out
            Assert.Equal(-1_500L, card.Sum(c => c.QtyMilli));
        }
    }

    // ---- the day book -----------------------------------------------------------------------------------------------------------

    private static LineInput Line(long priceMinor, long qtyMilli = 1000) => new() { Description = "Rice", UnitPriceMinor = priceMinor, QtyMilli = qtyMilli, TaxCode = "GST18" };

    /// <summary>4 Oct: a cash sale of 2 x 100.00 + 18% = 236.00. 5 Oct: a sale of 1 x 100.00 + 18% = 118.00 paid by card, and another of 118.00 paid in cash.</summary>
    private static HubFixture ThreeSales()
    {
        var f = Shop();
        f.Clock.Set(NoonOn(4));
        f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line(10_000, 2000) }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 23_600 } } });
        f.Clock.Set(NoonOn(5));
        f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line(10_000) }, Payments = { new PaymentInput { Method = "card", AmountMinor = 11_800 } } });
        f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line(10_000) }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } });
        return f;
    }

    private static (DateTimeOffset From, DateTimeOffset To) Days(HubFixture f, DateOnly from, DateOnly to) => (f.App.Shop.Current.Time.StartOfDay(from), f.App.Shop.Current.Time.StartOfNextDay(to));

    [Fact]
    public void The_day_book_lists_what_was_written_in_the_order_it_was_written_and_every_entry_adds_up()
    {
        using var f = ThreeSales();
        var (from, to) = Days(f, Oct5, Oct5);
        var entries = f.App.Books.DayBook(from, to);

        // each sale of 118.00 writes the bill (118.00 owed by the customer, 100.00 sales, 18.00 tax) and its payment (118.00 in, 118.00 less owed): 236.00 of debits each, 472.00 for the day
        Assert.Equal(4, entries.Count);
        Assert.Equal(new[] { "Bill", "Payment", "Bill", "Payment" }, entries.Select(e => e.Kind).ToArray());
        Assert.Equal(4 * 11_800L, entries.Sum(e => e.TotalMinor));
        foreach (var e in entries)
        {
            Assert.Equal(e.Lines.Sum(l => l.DebitMinor), e.Lines.Sum(l => l.CreditMinor));
            Assert.All(e.Lines, l => Assert.True(l.DebitMinor == 0 || l.CreditMinor == 0));
            Assert.False(string.IsNullOrWhiteSpace(e.Memo));
        }
        Assert.Equal(entries.OrderBy(e => e.At).ThenBy(e => e.Id).Select(e => e.Id), entries.Select(e => e.Id));
        // the whole period has the first day's two as well
        var (all0, all1) = Days(f, Oct4, Oct5);
        Assert.Equal(6, f.App.Books.DayBook(all0, all1).Count);
    }

    [Fact]
    public void The_day_book_can_be_cut_short_and_shows_the_earliest_entries()
    {
        using var f = ThreeSales();
        var (from, to) = Days(f, Oct4, Oct5);
        var all = f.App.Books.DayBook(from, to);
        var three = f.App.Books.DayBook(from, to, 3);
        Assert.Equal(all.Take(3).Select(e => e.Id), three.Select(e => e.Id));
        Assert.Equal(3, three.Count);
        Assert.Equal(all[0].Lines.Count, three[0].Lines.Count);     // a cut-short book still has each entry whole
    }

    [Fact]
    public void A_cancelled_bill_shows_as_its_own_entry_that_turns_the_first_one_round()
    {
        using var f = Shop();
        f.Clock.Set(NoonOn(5));
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line(10_000) }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } });
        f.Clock.Set(NoonOn(6));
        f.App.Documents.Void(sale.Document.Id, "wrong customer", null);
        var (from, to) = Days(f, Oct5, Oct6);
        var entries = f.App.Books.DayBook(from, to);

        Assert.Contains(entries, e => e.Kind == "Cancelled bill");
        var cancelled = entries.Single(e => e.Kind == "Cancelled bill");
        var bill = entries.Single(e => e.Kind == "Bill");
        // the cancelled entry has the bill's lines the other way round
        Assert.Equal(bill.Lines.Select(l => (l.Code, l.DebitMinor, l.CreditMinor)).OrderBy(x => x.Code).ToArray(), cancelled.Lines.Select(l => (l.Code, l.CreditMinor, l.DebitMinor)).OrderBy(x => x.Code).ToArray());
        Assert.All(entries, e => Assert.Equal(e.Lines.Sum(l => l.DebitMinor), e.Lines.Sum(l => l.CreditMinor)));
    }

    // ---- the cash and bank books ------------------------------------------------------------------------------------------------

    [Fact]
    public void The_cash_book_has_the_cash_that_came_in_with_what_the_till_held_at_the_start_and_at_the_end()
    {
        using var f = ThreeSales();
        var (from, to) = Days(f, Oct5, Oct5);
        var page = f.App.Books.MoneyBook("cash", from, to);

        // before 5 Oct the till took 236.00; on 5 Oct it took 118.00 in cash (the card sale is not in it)
        Assert.Equal("Cash", page.Name);
        Assert.Equal(23_600, page.OpeningMinor);
        var row = Assert.Single(page.Rows);
        Assert.Equal((11_800L, 0L, 35_400L), (row.InMinor, row.OutMinor, row.BalanceMinor));
        Assert.Equal((11_800L, 0L, 35_400L), (page.InMinor, page.OutMinor, page.ClosingMinor));

        var (a, b) = Days(f, Oct4, Oct6);
        var whole = f.App.Books.MoneyBook("cash", a, b);
        Assert.Equal(new[] { 23_600L, 35_400L }, whole.Rows.Select(r => r.BalanceMinor).ToArray());
        Assert.Equal(f.App.Books.TrialBalance().Single(r => r.Name == "Cash").BalanceMinor, whole.ClosingMinor);
    }

    [Fact]
    public void Each_other_way_of_being_paid_has_a_book_of_its_own()
    {
        using var f = ThreeSales();
        var ways = f.App.Books.MoneyWays();
        Assert.Equal(new[] { ("cash", "Cash"), ("way:card", "Received by Card") }, ways.Select(w => (w.Key, w.Name)).ToArray());

        var (from, to) = Days(f, Oct4, Oct6);
        var card = f.App.Books.MoneyBook("way:card", from, to);
        Assert.Equal("Received by Card", card.Name);
        Assert.Equal((0L, 11_800L), (card.OpeningMinor, card.ClosingMinor));
        Assert.Equal(f.App.Books.TrialBalance().Single(r => r.Name == "Received by Card").BalanceMinor, card.ClosingMinor);

        // a way nobody has paid by yet has an empty book; a key that is not a book is refused in plain words
        var upi = f.App.Books.MoneyBook("way:upi", from, to);
        Assert.Equal((0L, 0L), (upi.OpeningMinor, upi.ClosingMinor));
        Assert.Empty(upi.Rows);
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Books.MoneyBook("bank", from, to)).Code);
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Books.MoneyBook("way:", from, to)).Code);
    }

    [Fact]
    public void Money_given_back_for_a_cancelled_sale_is_money_out_of_the_till()
    {
        using var f = Shop();
        f.Clock.Set(NoonOn(5));
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line(10_000) }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } });
        f.Clock.Set(NoonOn(6));
        f.App.Documents.Void(sale.Document.Id, "wrong customer", null);
        var (from, to) = Days(f, Oct5, Oct6);
        var page = f.App.Books.MoneyBook("cash", from, to);

        Assert.Equal(new[] { (11_800L, 0L, 11_800L), (0L, 11_800L, 0L) }, page.Rows.Select(r => (r.InMinor, r.OutMinor, r.BalanceMinor)).ToArray());
        Assert.Equal((11_800L, 11_800L, 0L), (page.InMinor, page.OutMinor, page.ClosingMinor));
    }
}

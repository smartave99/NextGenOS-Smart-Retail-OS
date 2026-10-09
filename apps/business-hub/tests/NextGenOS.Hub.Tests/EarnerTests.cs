using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Staff;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, staff part 1: salespeople and brokers who earn a commission on bills (study 03 B1 and B2). The older program's worked examples are here with the Hub's one method: a salesperson earns a
/// percent of the bill's taxable value (after every discount, before tax). Shop in India, rupees, tax 18 percent; the numbers are worked by hand beside each case.
/// </summary>
public class EarnerTests
{
    private static HubFixture Shop(bool pricesIncludeTax = false) => new("IN", "retail", s => s.PricesIncludeTax = pricesIncludeTax);

    private static Item Product(HubFixture f, string name = "Rice", long price = 10_000) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = price, TaxClass = "standard", TrackStock = false });

    private static Earner Person(HubFixture f, string name, long pctMilli, string kind = EarnerKinds.Salesperson) =>
        f.App.Earners.Save(new EarnerInput { Kind = kind, Name = name, PctMilli = pctMilli });

    private static DocumentView Sell(HubFixture f, long itemId, long qtyMilli, Action<long>? choose = null, long discountAmountMinor = 0, long billDiscountMinor = 0)
    {
        var draft = f.App.Documents.CreateDraft(new DraftOptions { BillDiscountMinor = billDiscountMinor, Lines = { new LineInput { ItemId = itemId, QtyMilli = qtyMilli, DiscountAmountMinor = discountAmountMinor } } });
        choose?.Invoke(draft.Document.Id);
        var pay = f.App.Documents.Get(draft.Document.Id)!.Document.PayableMinor;
        return f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = pay } } });
    }

    // ---- salespeople: M1 to M8 ---------------------------------------------------------------------------------------------------------------

    [Fact]
    public void M1_a_salesperson_earns_a_percent_of_the_taxable_value_and_it_is_owed_to_them()
    {
        using var f = Shop();
        var rice = Product(f);
        var asha = Person(f, "Asha", 2_500);   // 2.5 percent

        var bill = Sell(f, rice.Id, 2_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));

        // 2 x 100.00 = 200.00 taxable, 2.5% = 5.00 (the bill is 236.00 with 36.00 tax)
        Assert.Equal(23_600, bill.Document.TotalMinor);
        var line = Assert.Single(f.App.Earners.Statement(asha.Id));
        Assert.Equal(("commission", 500L, 500L), (line.Kind, line.AmountMinor, line.BalanceMinor));
        Assert.Equal(500, f.App.Earners.Owed(asha.Id));
        Assert.Contains($"bill {bill.Document.Number}", line.Memo);
    }

    [Fact]
    public void M2_a_line_discount_lowers_the_base_and_the_commission_is_rounded_half_up()
    {
        using var f = Shop();
        var tape = Product(f, "Tape", 3_333);
        var asha = Person(f, "Asha", 2_500);

        Sell(f, tape.Id, 3_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id), discountAmountMinor: 1_000);

        // 3 x 33.33 = 99.99, less 10.00 = 89.99; 2.5% of 89.99 = 2.24975 -> 2.25
        Assert.Equal(225, f.App.Earners.Owed(asha.Id));
    }

    [Fact]
    public void M3_M4_the_same_goods_earn_the_same_whether_prices_include_tax_or_not()
    {
        using var inclusive = Shop(pricesIncludeTax: true);
        using var exclusive = Shop(pricesIncludeTax: false);
        var a = Person(inclusive, "Asha", 2_000);
        var b = Person(exclusive, "Asha", 2_000);

        Sell(inclusive, Product(inclusive, "Rice", 11_800).Id, 1_000, id => inclusive.App.Earners.ChooseSalesperson(id, a.Id));
        Sell(exclusive, Product(exclusive, "Rice", 10_000).Id, 1_000, id => exclusive.App.Earners.ChooseSalesperson(id, b.Id));

        // taxable value is 100.00 in both shops: 2% = 2.00 (the older program gave 2.36 in one and 2.00 in the other)
        Assert.Equal((200L, 200L), (inclusive.App.Earners.Owed(a.Id), exclusive.App.Earners.Owed(b.Id)));
    }

    [Fact]
    public void M5_a_discount_on_the_whole_bill_lowers_the_base_because_the_tax_falls_with_it()
    {
        using var f = Shop();
        var asha = Person(f, "Asha", 2_500);

        Sell(f, Product(f).Id, 2_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id), billDiscountMinor: 5_000);

        // 200.00 less the 50.00 bill discount (spread over the lines before tax) = 150.00; 2.5% = 3.75 (the older program ignored the bill discount: 5.00)
        Assert.Equal(375, f.App.Earners.Owed(asha.Id));
    }

    [Fact]
    public void M6_M7_a_salesperson_with_no_percent_and_a_bill_with_nobody_named_write_nothing()
    {
        using var f = Shop();
        var rice = Product(f);
        var nothing = Person(f, "Zero", 0);

        Sell(f, rice.Id, 1_000, id => f.App.Earners.ChooseSalesperson(id, nothing.Id));
        Sell(f, rice.Id, 1_000);

        Assert.Empty(f.App.Earners.Statement(nothing.Id));
    }

    [Fact]
    public void M8_two_lines_with_a_discount_on_one_add_up_before_the_percent_is_taken()
    {
        using var f = Shop();
        var a = Product(f, "A", 5_000);
        var b = Product(f, "B", 15_000);
        var asha = Person(f, "Asha", 4_000);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = a.Id, QtyMilli = 1_000, DiscountAmountMinor = 500 }, new LineInput { ItemId = b.Id, QtyMilli = 1_000 } } });
        f.App.Earners.ChooseSalesperson(draft.Document.Id, asha.Id);
        var pay = f.App.Documents.Get(draft.Document.Id)!.Document.PayableMinor;

        f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = pay } } });

        // (50.00 - 5.00) + 150.00 = 195.00; 4% = 7.80
        Assert.Equal(780, f.App.Earners.Owed(asha.Id));
    }

    [Fact]
    public void The_percent_is_the_one_at_the_moment_the_person_is_named_and_a_later_change_changes_no_bill()
    {
        using var f = Shop();
        var rice = Product(f);
        var asha = Person(f, "Asha", 2_000);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 1_000 } } });
        f.App.Earners.ChooseSalesperson(draft.Document.Id, asha.Id);

        f.App.Earners.Save(new EarnerInput { Id = asha.Id, Kind = EarnerKinds.Salesperson, Name = "Asha", PctMilli = 5_000 });
        var pay = f.App.Documents.Get(draft.Document.Id)!.Document.PayableMinor;
        f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = pay } } });

        Assert.Equal(200, f.App.Earners.Owed(asha.Id));   // 2% of 100.00, not 5%
    }

    // ---- brokers: K1 to K10 --------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void K1_K2_a_broker_is_paid_a_percent_of_the_taxable_value_or_of_the_whole_total_as_chosen()
    {
        using var f = Shop();
        var rice = Product(f, "Rice", 100_000);   // 1,000.00 plus 18% tax = 1,180.00
        var ravi = Person(f, "Ravi", 0, EarnerKinds.Broker);

        Sell(f, rice.Id, 1_000, id => f.App.Earners.ChooseBroker(id, ravi.Id, withTax: false, pctMilli: 2_000));
        Assert.Equal(2_000, f.App.Earners.Owed(ravi.Id));   // K1: 2% of 1,000.00 = 20.00

        Sell(f, rice.Id, 1_000, id => f.App.Earners.ChooseBroker(id, ravi.Id, withTax: true, pctMilli: 2_000));
        Assert.Equal(2_000 + 2_360, f.App.Earners.Owed(ravi.Id));   // K2: 2% of 1,180.00 = 23.60
    }

    [Fact]
    public void K3_a_broker_can_be_given_an_amount_for_the_bill_instead_of_a_percent()
    {
        using var f = Shop();
        var ravi = Person(f, "Ravi", 0, EarnerKinds.Broker);

        Sell(f, Product(f, "Rice", 100_000).Id, 1_000, id => f.App.Earners.ChooseBroker(id, ravi.Id, amountMinor: 2_500));

        Assert.Equal(2_500, f.App.Earners.Owed(ravi.Id));
    }

    [Fact]
    public void K8_K9_a_broker_with_no_commission_or_not_chosen_writes_nothing_and_a_salesperson_and_a_broker_can_share_a_bill()
    {
        using var f = Shop();
        var rice = Product(f);
        var ravi = Person(f, "Ravi", 0, EarnerKinds.Broker);
        var asha = Person(f, "Asha", 1_000);

        Sell(f, rice.Id, 1_000, id => f.App.Earners.ChooseBroker(id, ravi.Id, pctMilli: 0));
        Sell(f, rice.Id, 1_000);
        Sell(f, rice.Id, 1_000, id => { f.App.Earners.ChooseSalesperson(id, asha.Id); f.App.Earners.ChooseBroker(id, ravi.Id, pctMilli: 3_000); });

        Assert.Equal((100L, 300L), (f.App.Earners.Owed(asha.Id), f.App.Earners.Owed(ravi.Id)));
        Assert.Single(f.App.Earners.Statement(ravi.Id));
    }

    [Fact]
    public void A_broker_needs_exactly_one_of_a_percent_and_an_amount_and_neither_can_be_below_nothing()
    {
        using var f = Shop();
        var ravi = Person(f, "Ravi", 0, EarnerKinds.Broker);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = Product(f).Id } } });

        Assert.Equal("broker-how", Assert.Throws<HubException>(() => f.App.Earners.ChooseBroker(draft.Document.Id, ravi.Id)).Code);
        Assert.Equal("broker-how", Assert.Throws<HubException>(() => f.App.Earners.ChooseBroker(draft.Document.Id, ravi.Id, pctMilli: 1_000, amountMinor: 100)).Code);
        Assert.Equal("earner-percent", Assert.Throws<HubException>(() => f.App.Earners.ChooseBroker(draft.Document.Id, ravi.Id, pctMilli: 100_001)).Code);
        Assert.Equal("broker-amount", Assert.Throws<HubException>(() => f.App.Earners.ChooseBroker(draft.Document.Id, ravi.Id, amountMinor: -1)).Code);
    }

    // ---- taking commission back ------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void L2_goods_brought_back_take_back_a_share_of_the_commission_not_the_whole_line()
    {
        using var f = Shop();
        var tea = Product(f, "Tea", 4_000);
        var asha = Person(f, "Asha", 3_000);   // 3 percent
        var bill = Sell(f, tea.Id, 5_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id), discountAmountMinor: 1_000);
        Assert.Equal(570, f.App.Earners.Owed(asha.Id));   // L1: (5 x 40.00 - 10.00) = 190.00; 3% = 5.70

        f.App.Documents.CreateCreditNote(bill.Document.Id, new[] { (bill.Lines[0].Id, 2_000L) }, "two came back", "cash", null);

        // two of five units: 76.00 of the 190.00 taxable; 5.70 x 76/190 = 2.28 taken back, 3.42 stays (the older program took back all 5.70)
        Assert.Equal(342, f.App.Earners.Owed(asha.Id));
        var back = f.App.Earners.Statement(asha.Id).Last();
        Assert.Equal(("reversal", -228L), (back.Kind, back.AmountMinor));
        Assert.Contains("credit note", back.Memo);
    }

    [Fact]
    public void Everything_brought_back_takes_back_all_of_it_and_never_more_than_was_earned()
    {
        using var f = Shop();
        var tea = Product(f, "Tea", 4_000);
        var asha = Person(f, "Asha", 3_000);
        var bill = Sell(f, tea.Id, 5_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));
        var line = bill.Lines[0].Id;

        f.App.Documents.CreateCreditNote(bill.Document.Id, new[] { (line, 3_000L) }, "three back", "cash", null);
        f.App.Documents.CreateCreditNote(bill.Document.Id, new[] { (line, 2_000L) }, "the rest back", "cash", null);

        Assert.Equal(0, f.App.Earners.Owed(asha.Id));   // 200.00 x 3% = 6.00 earned, 3.60 + 2.40 taken back
    }

    [Fact]
    public void L6_a_cancelled_bill_takes_back_all_of_its_commission_once()
    {
        using var f = Shop();
        var asha = Person(f, "Asha", 2_500);
        var bill = Sell(f, Product(f).Id, 2_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));
        Assert.Equal(500, f.App.Earners.Owed(asha.Id));

        f.App.Documents.Void(bill.Document.Id, "wrong customer", null);

        Assert.Equal(0, f.App.Earners.Owed(asha.Id));
        Assert.Equal(new[] { "commission", "reversal" }, f.App.Earners.Statement(asha.Id).Select(x => x.Kind).ToArray());
    }

    // ---- paying them -------------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void L3_L4_paying_lowers_what_is_owed_and_paying_more_than_is_owed_is_allowed_with_a_warning()
    {
        using var f = Shop();
        var tea = Product(f, "Tea", 4_000);
        var asha = Person(f, "Asha", 3_000);
        Sell(f, tea.Id, 5_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id), discountAmountMinor: 1_000);   // 5.70 earned

        var first = f.App.Earners.Pay(asha.Id, 500, "cash");
        Assert.Equal((570L, 70L, false), (first.OwedBeforeMinor, first.OwedAfterMinor, first.Overpaid));   // L3: 0.70 still owed

        var second = f.App.Earners.Pay(asha.Id, 200, "cash", "advance");
        Assert.Equal((70L, -130L, true), (second.OwedBeforeMinor, second.OwedAfterMinor, second.Overpaid));   // L4: paid 1.30 too much
        Assert.Equal(-130, f.App.Earners.Owed(asha.Id));
    }

    [Fact]
    public void Nothing_or_a_negative_amount_cannot_be_paid_and_nobody_unknown_can_be_paid()
    {
        using var f = Shop();
        var asha = Person(f, "Asha", 1_000);

        Assert.Equal("pay-amount", Assert.Throws<HubException>(() => f.App.Earners.Pay(asha.Id, 0, "cash")).Code);
        Assert.Equal("pay-amount", Assert.Throws<HubException>(() => f.App.Earners.Pay(asha.Id, -5, "cash")).Code);
        Assert.Equal("not-found", Assert.Throws<HubException>(() => f.App.Earners.Pay(9_999, 100, "cash")).Code);
    }

    [Fact]
    public void The_statement_runs_oldest_first_with_the_balance_after_each_line_and_words_for_each()
    {
        using var f = Shop();
        var asha = Person(f, "Asha", 2_500);
        var bill = Sell(f, Product(f).Id, 2_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));
        f.App.Earners.Pay(asha.Id, 200, "upi", "part payment");

        var lines = f.App.Earners.Statement(asha.Id);

        Assert.Equal(new long[] { 500, 300 }, lines.Select(x => x.BalanceMinor).ToArray());
        Assert.Equal($"Commission on bill {bill.Document.Number}", lines[0].Memo);
        Assert.Equal("Paid by upi (part payment)", lines[1].Memo);
    }

    [Fact]
    public void The_summary_adds_up_a_period_per_person_and_shows_what_is_owed_now()
    {
        using var f = Shop();
        var asha = Person(f, "Asha", 2_500);
        var ravi = Person(f, "Ravi", 0, EarnerKinds.Broker);
        var rice = Product(f);
        Sell(f, rice.Id, 2_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));
        Sell(f, rice.Id, 4_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));
        f.App.Earners.Pay(asha.Id, 300, "cash");
        Sell(f, rice.Id, 1_000, id => f.App.Earners.ChooseBroker(id, ravi.Id, pctMilli: 1_000));

        var rows = f.App.Earners.Summary(f.Clock.UtcNow.AddDays(-1), f.Clock.UtcNow.AddDays(1));

        var a = rows.Single(r => r.EarnerId == asha.Id);
        // bills of 200.00 and 400.00 taxable: 5.00 + 10.00 earned, 3.00 paid, 12.00 owed
        Assert.Equal((2, 60_000L, 1_500L, 0L, 300L, 1_200L), (a.Bills, a.BaseMinor, a.EarnedMinor, a.ReversedMinor, a.PaidMinor, a.OwedMinor));
        Assert.Equal(1, rows.Single(r => r.EarnerId == ravi.Id).Bills);
        Assert.Single(f.App.Earners.Summary(f.Clock.UtcNow.AddDays(-1), f.Clock.UtcNow.AddDays(1), EarnerKinds.Broker));
    }

    // ---- the books ---------------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Commission_is_a_cost_and_a_debt_in_the_books_until_it_is_paid_and_the_books_still_balance()
    {
        using var f = Shop();
        var asha = Person(f, "Asha", 2_500);
        Sell(f, Product(f).Id, 2_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));

        var trial = f.App.Books.TrialBalance();
        Assert.Equal(500, trial.Single(x => x.Name == "Sales commission").DebitMinor);
        Assert.Equal(500, trial.Single(x => x.Name == "Commission to pay").CreditMinor);
        Assert.Equal(trial.Sum(x => x.DebitMinor), trial.Sum(x => x.CreditMinor));

        f.App.Earners.Pay(asha.Id, 500, "cash");
        var after = f.App.Books.TrialBalance();
        Assert.Equal(0, after.Single(x => x.Name == "Commission to pay").BalanceMinor);
        Assert.Equal(after.Sum(x => x.DebitMinor), after.Sum(x => x.CreditMinor));
        Assert.Contains(f.App.Books.DayBook(f.Clock.UtcNow.AddDays(-1), f.Clock.UtcNow.AddDays(1)), e => e.Kind == "Commission earned");
        Assert.Contains(f.App.Books.DayBook(f.Clock.UtcNow.AddDays(-1), f.Clock.UtcNow.AddDays(1)), e => e.Kind == "Commission paid");
    }

    [Fact]
    public void Taking_commission_back_is_in_the_books_too()
    {
        using var f = Shop();
        var asha = Person(f, "Asha", 2_500);
        var bill = Sell(f, Product(f).Id, 2_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));

        f.App.Documents.Void(bill.Document.Id, "mistake", null);

        var trial = f.App.Books.TrialBalance();
        Assert.Equal(0, trial.Single(x => x.Name == "Sales commission").BalanceMinor);
        Assert.Equal(0, trial.Single(x => x.Name == "Commission to pay").BalanceMinor);
    }

    // ---- who may do what, and the master -----------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_name_a_kind_and_a_percent_between_nothing_and_a_hundred_are_needed_and_a_phone_number_is_not_used_twice()
    {
        using var f = Shop();
        Person(f, "Asha", 1_000);
        f.App.Earners.Save(new EarnerInput { Kind = EarnerKinds.Salesperson, Name = "Bina", Phone = "99999" });

        Assert.Equal("earner-name", Assert.Throws<HubException>(() => f.App.Earners.Save(new EarnerInput { Name = "  " })).Code);
        Assert.Equal("earner-kind", Assert.Throws<HubException>(() => f.App.Earners.Save(new EarnerInput { Name = "X", Kind = "agent" })).Code);
        Assert.Equal("earner-percent", Assert.Throws<HubException>(() => f.App.Earners.Save(new EarnerInput { Name = "X", PctMilli = 100_001 })).Code);
        Assert.Equal("earner-phone", Assert.Throws<HubException>(() => f.App.Earners.Save(new EarnerInput { Name = "Chitra", Phone = "99999" })).Code);
    }

    [Fact]
    public void A_person_switched_off_is_not_offered_and_cannot_be_named_but_keeps_their_account()
    {
        using var f = Shop();
        var rice = Product(f);
        var asha = Person(f, "Asha", 1_000);
        Sell(f, rice.Id, 1_000, id => f.App.Earners.ChooseSalesperson(id, asha.Id));

        f.App.Earners.SetActive(asha.Id, false);

        Assert.Empty(f.App.Earners.List());
        Assert.Single(f.App.Earners.List(includeInactive: true));
        Assert.Equal(100, f.App.Earners.Owed(asha.Id));
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id } } });
        Assert.Equal("earner-off", Assert.Throws<HubException>(() => f.App.Earners.ChooseSalesperson(draft.Document.Id, asha.Id)).Code);
    }

    [Fact]
    public void A_salesperson_cannot_be_named_as_a_broker_and_a_final_bill_cannot_be_given_anyone()
    {
        using var f = Shop();
        var rice = Product(f);
        var asha = Person(f, "Asha", 1_000);
        var ravi = Person(f, "Ravi", 0, EarnerKinds.Broker);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id } } });
        Assert.Equal("earner-kind", Assert.Throws<HubException>(() => f.App.Earners.ChooseBroker(draft.Document.Id, asha.Id, pctMilli: 1)).Code);
        Assert.Equal("earner-kind", Assert.Throws<HubException>(() => f.App.Earners.ChooseSalesperson(draft.Document.Id, ravi.Id)).Code);

        var done = Sell(f, rice.Id, 1_000);
        Assert.Equal("not-open", Assert.Throws<HubException>(() => f.App.Earners.ChooseSalesperson(done.Document.Id, asha.Id)).Code);
    }

    [Fact]
    public void Naming_nobody_takes_the_name_off_the_bill()
    {
        using var f = Shop();
        var asha = Person(f, "Asha", 1_000);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = Product(f).Id, QtyMilli = 1_000 } } });
        f.App.Earners.ChooseSalesperson(draft.Document.Id, asha.Id);
        Assert.Single(f.App.Earners.ForBill(draft.Document.Id));

        f.App.Earners.ChooseSalesperson(draft.Document.Id, null);

        Assert.Empty(f.App.Earners.ForBill(draft.Document.Id));
    }
}

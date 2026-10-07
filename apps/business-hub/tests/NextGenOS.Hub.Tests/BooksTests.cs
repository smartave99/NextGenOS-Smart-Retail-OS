using NextGenOS.Hub;
using NextGenOS.Hub.Books;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The books (decision 32): every final bill, payment, refund and cancellation is posted as an entry whose lines add up to nothing, and a customer's account read from the books says
/// what the customer owes. India, rupees; the amounts are worked by hand beside each case.
/// </summary>
public class BooksTests
{
    private static LineInput Line(string name, long priceMinor, long qtyMilli = 1000, string tax = "GST18", long pctMilli = 0) =>
        new() { Description = name, UnitPriceMinor = priceMinor, QtyMilli = qtyMilli, TaxCode = tax, DiscountPctMilli = pctMilli };

    private static HubFixture Shop(string industry = "retail", bool round = false) => new("IN", industry, s => { s.PricesIncludeTax = false; s.RoundTotal = round; });

    private static long Balance(HubFixture f, string name) => f.App.Books.TrialBalance().Single(r => r.Name == name).BalanceMinor;

    private static void AssertBalanced(HubFixture f)
    {
        var rows = f.App.Books.TrialBalance();
        Assert.Equal(rows.Sum(r => r.DebitMinor), rows.Sum(r => r.CreditMinor));
        Assert.DoesNotContain(rows, r => r.Name == "Needs checking");
        // every entry adds up on its own, too
        var bad = f.App.Db.Query("SELECT entry_id FROM journal_lines GROUP BY entry_id HAVING SUM(debit_minor) <> SUM(credit_minor)", r => r.GetInt64(0));
        Assert.Empty(bad);
    }

    [Fact]
    public void A_counter_sale_paid_in_cash_is_posted_as_cash_in_and_sales_and_tax_out_and_the_customer_owes_nothing()
    {
        using var f = Shop();
        // 2 x 100.00 + 18% = 236.00 (tax 18.00 + 18.00)
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line("Rice", 10_000, 2000) }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 30_000 } } });
        Assert.Equal(23_600, sale.Document.TotalMinor);
        Assert.Equal(23_600, Balance(f, "Cash"));                // the change given is not money kept
        Assert.Equal(-20_000, Balance(f, "Sales"));
        Assert.Equal(-1_800, Balance(f, "CGST collected"));
        Assert.Equal(-1_800, Balance(f, "SGST collected"));
        Assert.Equal(0, Balance(f, "Customers owe us"));
        AssertBalanced(f);
    }

    [Fact]
    public void A_sale_on_credit_makes_the_customer_owe_and_each_payment_and_a_return_lowers_it()
    {
        using var f = Shop("wholesale");
        var buyer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Sharma Store", CreditLimitMinor = 1_000_000 });
        var sale = f.App.Documents.Checkout(new CheckoutRequest
        {
            PartyId = buyer.Id, OnCredit = true, Lines = { Line("Rice", 10_000, 2000) }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 5_000 } },
        });
        Assert.Equal(23_600 - 5_000, f.App.Books.CustomerBalance(buyer.Id));
        f.App.Documents.AddPayment(sale.Document.Id, new PaymentInput { Method = "card", AmountMinor = 8_000 });
        Assert.Equal(23_600 - 13_000, f.App.Books.CustomerBalance(buyer.Id));
        Assert.Equal(8_000, Balance(f, "Received by Card"));
        // one of the two bags comes back and the customer still owes: the credit note lowers what is owed; no money moves (decision 34: kept on the account)
        var back = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "wrong", "cash", null, refundPaid: false);
        Assert.Equal(11_800, back.Document.TotalMinor);
        Assert.Equal(23_600 - 13_000 - 11_800, f.App.Books.CustomerBalance(buyer.Id));   // -1,200: the shop now owes the customer 12.00
        var rows = f.App.Books.CustomerLedger(buyer.Id);
        Assert.Equal(new[] { "Bill INV-2026-000001", "Payment (cash) for INV-2026-000001", "Payment (card) for INV-2026-000001", "Credit note CN-2026-000001" }, rows.Select(r => r.Memo).ToArray());
        Assert.Equal(new long[] { 23_600, 18_600, 10_600, -1_200 }, rows.Select(r => r.BalanceMinor).ToArray());
        AssertBalanced(f);
    }

    [Fact]
    public void A_return_with_cash_back_leaves_the_customer_owing_nothing_and_the_cash_down()
    {
        using var f = Shop();
        var buyer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" });
        var sale = f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, Lines = { Line("Lamp", 10_000, 2000) }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 23_600 } } });
        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "broken", "cash", null);
        Assert.Equal(0, f.App.Books.CustomerBalance(buyer.Id));
        Assert.Equal(23_600 - 11_800, Balance(f, "Cash"));
        Assert.Equal(-10_000, Balance(f, "Sales"));
        AssertBalanced(f);
    }

    [Fact]
    public void A_cancelled_bill_turns_round_and_its_refund_is_posted_so_nothing_is_left()
    {
        using var f = Shop();
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line("Rice", 10_000, 2000) }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 23_600 } } });
        f.App.Documents.Void(sale.Document.Id, "keyed in wrong", null);
        Assert.All(f.App.Books.TrialBalance().Where(r => r.Name is "Cash" or "Sales" or "CGST collected" or "SGST collected" or "Customers owe us"), r => Assert.Equal(0, r.BalanceMinor));
        Assert.Equal(new[] { "bill", "payment", "payment", "void" }.OrderBy(x => x), f.App.Db.Query("SELECT source FROM journal_entries", r => r.GetString(0)).OrderBy(x => x));
        AssertBalanced(f);
    }

    [Fact]
    public void A_purchase_is_posted_with_the_tax_paid_and_the_supplier_is_owed_until_paid()
    {
        using var f = Shop("wholesale");
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice 25 kg", PriceMinor = 170_000, TaxClass = "reduced" });
        var po = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = rice.Id, QtyMilli = 10_000, CostMinor = 100_000 } });
        Assert.Equal(0, f.App.Books.SupplierBalance(supplier.Id));        // an order is not owed yet
        var received = f.App.Purchasing.Receive(po.Document.Id);
        var owed = received.Document.PayableMinor;
        Assert.Equal(owed, f.App.Books.SupplierBalance(supplier.Id));
        Assert.Equal(1_000_000, Balance(f, "Purchases"));
        f.App.Purchasing.Pay(po.Document.Id, 400_000, "bank");
        Assert.Equal(owed - 400_000, f.App.Books.SupplierBalance(supplier.Id));
        Assert.Equal(-400_000, Balance(f, "Received by Bank"));           // money out of the bank
        AssertBalanced(f);
    }

    [Fact]
    public void Rounding_a_total_goes_to_its_own_account_and_a_discount_on_the_bill_lowers_the_tax_in_the_books_too()
    {
        using var f = Shop(round: true);
        // 99.95 less 12.5% = 87.46, GST 18% = 15.74 (CGST 7.87 + SGST 7.87): 103.20, rounded to 103.00
        var one = f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line("Cup", 9_995, 1000, pctMilli: 12_500) }, Payments = { new PaymentInput { AmountMinor = 10_300 } } });
        Assert.Equal(10_300, one.Document.TotalMinor);
        Assert.Equal(20, Balance(f, "Rounding"));                       // the shop is 20 paise worse off: a debit of 0.20 on the rounding account
        // 50.00 off a 100.00 line before tax: sales 50.00, tax 9.00
        var two = f.App.Documents.Checkout(new CheckoutRequest { BillDiscountMinor = 5_000, Lines = { Line("Rice", 10_000) }, Payments = { new PaymentInput { AmountMinor = 5_900 } } });
        Assert.Equal(5_900, two.Document.TotalMinor);
        Assert.Equal(-(8_746 + 5_000), Balance(f, "Sales"));
        AssertBalanced(f);
    }

    [Fact]
    public void A_restaurant_bill_with_a_service_charge_and_a_tip_split_in_two_payments_is_posted_whole()
    {
        using var f = new HubFixture("IN", "restaurant", s => s.PricesIncludeTax = false);
        var table = f.App.Restaurant.AddTable("T1", 4, "Inside");
        var dish = f.App.Catalog.Create(new ItemInput { Kind = "menu", Name = "Dal", PriceMinor = 20_000, TaxClass = "standard", Station = "Kitchen" });
        var order = f.App.Restaurant.OpenOrder(table.Id, 2);
        f.App.Restaurant.AddItem(order.Document.Id, dish.Id, 2000);
        var withTip = f.App.Restaurant.SetBillOptions(order.Document.Id, serviceCharge: true, tipMinor: 5_000);
        var due = withTip.Document.PayableMinor;
        var done = f.App.Restaurant.Pay(order.Document.Id, new[] { new PaymentInput { Method = "cash", AmountMinor = 10_000 }, new PaymentInput { Method = "card", AmountMinor = due - 10_000 } });
        Assert.Equal("paid", done.Document.PaymentState);
        Assert.Equal(-5_000, Balance(f, "Tips to hand on"));
        Assert.Equal(0, Balance(f, "Customers owe us"));
        AssertBalanced(f);
    }

    [Fact]
    public void The_books_cannot_be_changed_and_asking_again_posts_nothing_twice()
    {
        using var f = Shop();
        f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line("Rice", 10_000) }, Payments = { new PaymentInput { AmountMinor = 11_800 } } });
        var count = Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM journal_entries"));
        Assert.Equal(0, f.App.Books.CatchUp());
        Assert.Equal(count, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM journal_entries")));
        void Run(string sql) { using var c = f.App.Db.Open(); HubDb.Exec(c, sql); }
        Assert.ThrowsAny<Exception>(() => Run("UPDATE journal_lines SET debit_minor = 1 WHERE id = (SELECT MIN(id) FROM journal_lines)"));
        Assert.ThrowsAny<Exception>(() => Run("DELETE FROM journal_lines"));
        Assert.ThrowsAny<Exception>(() => Run("UPDATE journal_entries SET memo = 'x'"));
        Assert.ThrowsAny<Exception>(() => Run("DELETE FROM journal_entries"));
        // a line is a debit or a credit, never both, never less than nothing
        Assert.ThrowsAny<Exception>(() => Run("INSERT INTO journal_lines(entry_id, account_id, debit_minor, credit_minor) VALUES (1, 1, 5, 5)"));
        Assert.ThrowsAny<Exception>(() => Run("INSERT INTO journal_lines(entry_id, account_id, debit_minor, credit_minor) VALUES (1, 1, -5, 0)"));
    }

    [Fact]
    public void Bills_made_before_the_books_existed_are_posted_by_catching_up_and_come_out_the_same()
    {
        using var f = Shop("wholesale");
        var buyer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Sharma Store", CreditLimitMinor = 1_000_000 });
        var sale = f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, OnCredit = true, Lines = { Line("Rice", 10_000, 2000) }, Payments = { new PaymentInput { AmountMinor = 5_000 } } });
        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "wrong", "cash", null);
        var cash = f.App.Documents.Checkout(new CheckoutRequest { Lines = { Line("Pens", 3_333, 3000, pctMilli: 10_000) }, Payments = { new PaymentInput { AmountMinor = 20_000 } } });
        f.App.Documents.Void(cash.Document.Id, "mistake", null);
        var before = f.App.Books.TrialBalance().Select(r => (r.Code, r.Name, r.DebitMinor, r.CreditMinor)).ToList();
        var balanceBefore = f.App.Books.CustomerBalance(buyer.Id);
        var shopPath = f.App.Db.Path;
        f.App.Db.Rollback(HubDb.LatestVersion - 1);                    // the books step is undone: the bills and payments stay
        Assert.Empty(f.App.Db.Query("SELECT name FROM sqlite_master WHERE name = 'journal_entries'", r => r.GetString(0)));
        var again = HubApp.Open(shopPath, f.Clock);                     // forward again: opening the shop posts what was not posted
        Assert.Equal(0, again.Books.CatchUp());
        Assert.Equal(before, again.Books.TrialBalance().Select(r => (r.Code, r.Name, r.DebitMinor, r.CreditMinor)).ToList());
        Assert.Equal(balanceBefore, again.Books.CustomerBalance(buyer.Id));
    }

    [Fact]
    public void A_project_advance_is_kept_for_the_client_and_used_up_by_the_bill()
    {
        using var f = new HubFixture("IN", "construction", s => s.PricesIncludeTax = false);
        var client = f.App.Parties.Create(new PartyInput { Kind = "client", Name = "Mehta Builders" });
        var project = f.App.Projects.Create("P-001", "Villa", client.Id, "12 Garden Lane", "5");
        f.App.Projects.ReceiveAdvance(project.Id, 100_000, "bank");
        Assert.Equal(-100_000, f.App.Books.CustomerBalance(client.Id));                 // the client has 1,000.00 with us
        Assert.Equal(-100_000, Balance(f, "Customers' money kept for them"));
        AssertBalanced(f);
    }

    [Fact]
    public void Balances_brought_across_from_an_older_system_become_opening_entries_for_customers_and_suppliers()
    {
        using var f = Shop("wholesale");
        var owing = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Sharma Store" });
        var owed = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha" });
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods" });
        using (var c = f.App.Db.Open())
        {
            foreach (var (party, minor) in new[] { (owing.Id, 150_000L), (owed.Id, -4_000L), (supplier.Id, -900_000L) })
                HubDb.Exec(c, "INSERT INTO party_opening_balances(party_id, balance_minor, as_of) VALUES ($p, $b, '2026-04-01T00:00:00+00:00')", null, ("$p", party), ("$b", minor));
        }
        Assert.Equal(3, f.App.Books.CatchUp());
        Assert.Equal(0, f.App.Books.CatchUp());
        Assert.Equal(150_000, f.App.Books.CustomerBalance(owing.Id));
        Assert.Equal(-4_000, f.App.Books.CustomerBalance(owed.Id));      // the shop owes this customer 40.00
        Assert.Equal(900_000, f.App.Books.SupplierBalance(supplier.Id)); // and owes the supplier 9,000.00
        Assert.Equal(-150_000 + 4_000 + 900_000, Balance(f, "Opening balances"));   // the other side of all three
        AssertBalanced(f);
    }

    // ---- money received on account, credit kept for a customer, and the credit limit read from the books ---------------------------------------

    private static (HubFixture F, Party Buyer) Credit(long limit = 100_000_000)
    {
        var f = Shop("wholesale");
        return (f, f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Sharma Store", CreditLimitMinor = limit }));
    }

    private static DocumentView CreditSale(HubFixture f, Party buyer, long priceMinor, long paidNow = 0) =>
        f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, OnCredit = true, Lines = { Line("Rice", priceMinor) }, Payments = paidNow > 0 ? new() { new PaymentInput { AmountMinor = paidNow } } : new() });

    [Fact]
    public void Money_received_on_account_settles_the_oldest_bills_first_and_keeps_any_extra_as_credit()
    {
        var (f, buyer) = Credit();
        using var _ = f;
        var first = CreditSale(f, buyer, 10_000);     // 118.00
        var second = CreditSale(f, buyer, 5_000);     // 59.00
        Assert.Equal(11_800 + 5_900, f.App.Books.CustomerBalance(buyer.Id));
        var receipt = f.App.Documents.ReceiveOnAccount(buyer.Id, 14_000, "cash");
        Assert.Equal(new[] { (first.Document.Id, 11_800L), (second.Document.Id, 2_200L) }, receipt.Settled.Select(x => (x.DocumentId, x.AmountMinor)).ToArray());
        Assert.Equal(0, receipt.KeptMinor);
        Assert.Equal("paid", f.App.Documents.Get(first.Document.Id)!.Document.PaymentState);
        Assert.Equal("partial", f.App.Documents.Get(second.Document.Id)!.Document.PaymentState);
        Assert.Equal(17_700 - 14_000, f.App.Books.CustomerBalance(buyer.Id));
        // paying more than is owed keeps the rest as credit for the customer
        var more = f.App.Documents.ReceiveOnAccount(buyer.Id, 5_000, "card");
        Assert.Equal(1_300, more.KeptMinor);      // 37.00 settles the rest of the second bill, 13.00 is kept
        Assert.Equal(-1_300, f.App.Books.CustomerBalance(buyer.Id));
        Assert.Equal("paid", f.App.Documents.Get(second.Document.Id)!.Document.PaymentState);
        Assert.Equal("amount", Assert.Throws<HubException>(() => f.App.Documents.ReceiveOnAccount(buyer.Id, 0, "cash")).Code);
        Assert.Equal("method", Assert.Throws<HubException>(() => f.App.Documents.ReceiveOnAccount(buyer.Id, 100, "account")).Code);
        AssertBalanced(f);
    }

    [Fact]
    public void Credit_on_the_account_pays_part_or_all_of_a_later_bill_without_moving_any_money()
    {
        var (f, buyer) = Credit();
        using var _ = f;
        f.App.Documents.ReceiveOnAccount(buyer.Id, 20_000, "cash");                       // nothing owed: all of it is kept as credit
        Assert.Equal(-20_000, f.App.Books.CustomerBalance(buyer.Id));
        var cashBefore = Balance(f, "Cash");
        var bill = f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, Lines = { Line("Rice", 10_000) }, Payments = { new PaymentInput { Method = "account", AmountMinor = 11_800 } } });
        Assert.Equal("paid", bill.Document.PaymentState);
        Assert.Equal(cashBefore, Balance(f, "Cash"));                                      // no money moved
        Assert.Equal(-20_000 + 11_800, f.App.Books.CustomerBalance(buyer.Id));            // 82.00 of credit left
        // more than the credit is refused; so is credit for a customer who has none, and a payment of credit after the bill was made
        Assert.Equal("account-credit", Assert.Throws<HubException>(() => f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, Lines = { Line("Rice", 100_000) }, Payments = { new PaymentInput { Method = "account", AmountMinor = 9_000 } } })).Code);
        var stranger = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Nobody" });
        Assert.Equal("account-credit", Assert.Throws<HubException>(() => f.App.Documents.Checkout(new CheckoutRequest { PartyId = stranger.Id, Lines = { Line("Rice", 1_000) }, Payments = { new PaymentInput { Method = "account", AmountMinor = 100 } } })).Code);
        var open = CreditSale(f, buyer, 100_000);
        Assert.Equal("account-credit", Assert.Throws<HubException>(() => f.App.Documents.AddPayment(open.Document.Id, new PaymentInput { Method = "account", AmountMinor = 100 })).Code);
        AssertBalanced(f);
    }

    [Fact]
    public void A_return_kept_as_credit_can_pay_the_next_bill()
    {
        var (f, buyer) = Credit();
        using var _ = f;
        var sale = f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, Lines = { Line("Lamp", 10_000, 2000) }, Payments = { new PaymentInput { AmountMinor = 23_600 } } });
        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 1000L) }, "wrong", "cash", null, refundPaid: false);   // decision 34: kept as credit
        Assert.Equal(-11_800, f.App.Books.CustomerBalance(buyer.Id));
        Assert.Equal(23_600, Balance(f, "Cash"));                                          // no money went back
        var next = f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, Lines = { Line("Lamp", 10_000) }, Payments = { new PaymentInput { Method = "account", AmountMinor = 11_800 } } });
        Assert.Equal("paid", next.Document.PaymentState);
        Assert.Equal(0, f.App.Books.CustomerBalance(buyer.Id));
        AssertBalanced(f);
    }

    [Fact]
    public void A_cancelled_bill_that_was_partly_paid_from_the_account_gives_the_credit_back_and_refunds_only_the_money()
    {
        var (f, buyer) = Credit();
        using var _ = f;
        f.App.Documents.ReceiveOnAccount(buyer.Id, 5_000, "cash");
        var bill = f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, Lines = { Line("Rice", 10_000) }, Payments = { new PaymentInput { Method = "account", AmountMinor = 5_000 }, new PaymentInput { Method = "cash", AmountMinor = 6_800 } } });
        Assert.Equal(0, f.App.Books.CustomerBalance(buyer.Id));                            // 50.00 of credit and 68.00 in cash paid the 118.00 bill
        f.App.Documents.Void(bill.Document.Id, "mistake", null);
        Assert.Equal(-5_000, f.App.Books.CustomerBalance(buyer.Id));                       // the 50.00 of credit is back
        Assert.Equal(5_000, Balance(f, "Cash"));                                           // only the advance is left in the till
        AssertBalanced(f);
    }

    [Fact]
    public void The_credit_limit_counts_what_the_books_say_so_a_balance_brought_across_counts_too()
    {
        var (f, buyer) = Credit(limit: 100_000);
        using var _ = f;
        using (var c = f.App.Db.Open()) HubDb.Exec(c, "INSERT INTO party_opening_balances(party_id, balance_minor, as_of) VALUES ($p, 99_900, '2026-04-01T00:00:00+00:00')".Replace("99_900", "99900"), null, ("$p", buyer.Id));
        f.App.Books.CatchUp();
        Assert.Equal(99_900, f.App.Books.CustomerBalance(buyer.Id));
        var ex = Assert.Throws<HubException>(() => CreditSale(f, buyer, 10_000));          // 99.900 + 118.00 is more than the limit
        Assert.Equal("over-limit", ex.Code);
        // paying down what was owed makes room again
        f.App.Documents.ReceiveOnAccount(buyer.Id, 50_000, "cash");
        Assert.Equal(49_900, f.App.Books.CustomerBalance(buyer.Id));
        CreditSale(f, buyer, 10_000);
        Assert.Equal(49_900 + 11_800, f.App.Books.CustomerBalance(buyer.Id));
        AssertBalanced(f);
    }

    // ---- many things in a row ------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Any_mixture_of_sales_payments_returns_and_cancellations_keeps_the_books_balanced_and_the_customers_accounts_equal_to_the_bills()
    {
        var random = new Random(20261007);
        for (var round = 0; round < 6; round++)
        {
            using var f = Shop("wholesale", round: random.Next(2) == 0);
            var customers = Enumerable.Range(1, 3).Select(i => f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Customer " + i, CreditLimitMinor = 100_000_000 })).ToList();
            var invoices = new List<DocumentView>();
            for (var step = 0; step < 40; step++)
            {
                var kind = random.Next(10);
                if (kind < 5 || invoices.Count == 0)
                {
                    var party = random.Next(4) == 0 ? null : customers[random.Next(customers.Count)];
                    var lines = Enumerable.Range(0, random.Next(1, 4)).Select(_ => Line("Thing " + random.Next(100), random.Next(100, 90_000), random.Next(1, 6) * 1000, random.Next(3) switch { 0 => "GST5", 1 => "GST12", _ => "GST18" },
                        random.Next(3) == 0 ? random.Next(1, 30) * 1000L : 0)).ToList();
                    var request = new CheckoutRequest { PartyId = party?.Id, Lines = lines, OnCredit = party is not null };
                    if (random.Next(3) == 0) request.BillDiscountPctMilli = random.Next(1, 20) * 1000L;
                    var payNow = party is null || random.Next(2) == 0;
                    var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = party?.Id, Lines = lines, BillDiscountPctMilli = request.BillDiscountPctMilli });
                    var due = draft.Document.PayableMinor;
                    var pay = payNow ? due : random.Next(0, 3) == 0 ? 0 : due / 3;
                    invoices.Add(f.App.Documents.Issue(draft.Document.Id, new IssueOptions { OnCredit = party is not null, Payments = pay > 0 ? new List<PaymentInput> { new() { Method = random.Next(2) == 0 ? "cash" : "card", AmountMinor = pay } } : new() }));
                }
                else if (kind < 7)
                {
                    var open = invoices.Select(v => f.App.Documents.Get(v.Document.Id)!).Where(v => v.Document.Status == DocStatus.Issued && v.Document.BalanceMinor > 0).ToList();
                    if (open.Count == 0) continue;
                    var pick = open[random.Next(open.Count)];
                    f.App.Documents.AddPayment(pick.Document.Id, new PaymentInput { Method = "cash", AmountMinor = Math.Max(1, random.NextInt64(1, pick.Document.BalanceMinor + 1)) });
                }
                else if (kind < 9)
                {
                    var candidates = invoices.Select(v => f.App.Documents.Get(v.Document.Id)!).Where(v => v.Document.Status == DocStatus.Issued).ToList();
                    if (candidates.Count == 0) continue;
                    var pick = candidates[random.Next(candidates.Count)];
                    var line = pick.Lines[random.Next(pick.Lines.Count)];
                    try { f.App.Documents.CreateCreditNote(pick.Document.Id, new[] { (line.Id, Math.Max(1, line.QtyMilli / 2)) }, "back", random.Next(2) == 0 ? "cash" : "card", null, refundPaid: random.Next(2) == 0); }
                    catch (HubException) { /* nothing left to give back on that line */ }
                }
                else
                {
                    var candidates = invoices.Select(v => f.App.Documents.Get(v.Document.Id)!).Where(v => v.Document.Status == DocStatus.Issued).ToList();
                    if (candidates.Count == 0) continue;
                    var pick = candidates[random.Next(candidates.Count)];
                    try { f.App.Documents.Void(pick.Document.Id, "mistake", null); }
                    catch (HubException) { /* it has a credit note: cancelled through that */ }
                }
            }
            AssertBalanced(f);
            // each customer's account in the books = what their bills say: bills less credit notes less everything paid (a refund is a negative payment)
            foreach (var c in customers)
            {
                var expected = Convert.ToInt64(f.App.Db.Scalar(
                    "SELECT COALESCE(SUM(CASE WHEN d.type IN ('invoice','progress-bill') AND d.status = 'issued' THEN d.payable_minor WHEN d.type = 'credit-note' AND d.status = 'issued' THEN -d.payable_minor ELSE 0 END), 0) " +
                    "FROM documents d WHERE d.party_id = $p", ("$p", c.Id)))
                    - Convert.ToInt64(f.App.Db.Scalar("SELECT COALESCE(SUM(amount_minor), 0) FROM payments WHERE party_id = $p AND document_id IS NOT NULL", ("$p", c.Id)));
                Assert.Equal(expected, f.App.Books.CustomerBalance(c.Id));
            }
        }
    }
}

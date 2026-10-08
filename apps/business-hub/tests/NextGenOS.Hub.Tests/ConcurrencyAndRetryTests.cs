using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Blueprint item NET-007 and invariants 1 and 2: a sale is made once however often it is asked for, many sales at the same moment are each whole and each get their own number, and
/// the last unit is sold once. These are the proofs that the main PC can be put on a network for several counters.
/// </summary>
public class ConcurrencyAndRetryTests
{
    private static Item Rice(HubFixture f, long stockMilli, string price = "118.00")
    {
        var item = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = f.App.Shop.Current.Minor(price), TaxClass = "standard", TrackStock = true });
        f.App.Catalog.Adjust(item.Id, stockMilli, "delivery");
        return item;
    }

    private static CheckoutRequest Sale(Item item, string? key, long qtyMilli = 1000, long pay = 11_800) => new()
    {
        Lines = { new LineInput { ItemId = item.Id, QtyMilli = qtyMilli } },
        Payments = { new PaymentInput { Method = "cash", AmountMinor = pay } },
        RequestKey = key,
    };

    private static long Count(HubFixture f, string sql) => Convert.ToInt64(f.App.Db.Scalar(sql) ?? 0L);

    private static long OnHand(HubFixture f, Item item) => Convert.ToInt64(f.App.Db.Scalar("SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves WHERE item_id = $i", ("$i", item.Id)) ?? 0L);

    /// <summary>Runs the work on its own thread each, all released at the same moment, and returns what each one threw (null: nothing).</summary>
    private static Exception?[] AtTheSameMoment(int count, Action<int> work)
    {
        var gate = new ManualResetEventSlim(false);
        var problems = new Exception?[count];
        var threads = Enumerable.Range(0, count).Select(i => new Thread(() =>
        {
            gate.Wait();
            try { work(i); }
            catch (Exception e) { problems[i] = e; }
        })).ToList();
        threads.ForEach(t => t.Start());
        gate.Set();
        threads.ForEach(t => t.Join());
        return problems;
    }

    [Fact]
    public void The_same_request_twice_gives_back_the_first_bill_and_does_nothing_more()
    {
        using var f = new HubFixture();
        var rice = Rice(f, 10_000);

        var first = f.App.Documents.Checkout(Sale(rice, "till-1-sale-7"));
        var again = f.App.Documents.Checkout(Sale(rice, "till-1-sale-7"));   // the answer was lost on the way: the till asks again

        Assert.Equal(first.Document.Id, again.Document.Id);
        Assert.Equal(first.Document.Number, again.Document.Number);
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM documents WHERE status = 'issued'"));
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM payments"));
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM stock_moves WHERE reason = 'sale'"));
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM journal_entries WHERE source = 'bill'"));
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM journal_entries WHERE source = 'payment'"));
        Assert.Equal(9_000, OnHand(f, rice));
        Assert.True(DatabaseCheck.Inspect(f.App.Db.Path).Healthy);
    }

    [Fact]
    public void A_bill_finished_from_an_open_sale_twice_with_the_same_key_gives_back_the_same_bill_and_without_a_key_the_second_is_refused_as_before()
    {
        using var f = new HubFixture();
        var rice = Rice(f, 10_000);
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id } } });
        var pay = new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } }, RequestKey = "counter-2-abc" };

        var first = f.App.Documents.Issue(draft.Document.Id, pay);
        var again = f.App.Documents.Issue(draft.Document.Id, pay);   // the Pay button pressed twice

        Assert.Equal(first.Document.Number, again.Document.Number);
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM payments"));
        Assert.Equal(9_000, OnHand(f, rice));

        var plain = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id } } });
        f.App.Documents.Issue(plain.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } });
        var ex = Assert.Throws<HubException>(() => f.App.Documents.Issue(plain.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } }));
        Assert.Equal("not-open", ex.Code);   // no key, no protection: as it always was
    }

    [Fact]
    public void A_key_that_already_made_a_bill_answers_with_that_bill_even_for_another_open_sale_and_a_new_key_makes_a_new_bill()
    {
        using var f = new HubFixture();
        var rice = Rice(f, 10_000);
        var one = f.App.Documents.Checkout(Sale(rice, "key-one"));
        var other = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = rice.Id } } });

        var answer = f.App.Documents.Issue(other.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } }, RequestKey = "key-one" });
        Assert.Equal(one.Document.Number, answer.Document.Number);
        Assert.Equal(DocStatus.Open, f.App.Documents.GetHeader(other.Document.Id)!.Status);   // the second sale was never finished

        var two = f.App.Documents.Checkout(Sale(rice, "key-two"));
        Assert.NotEqual(one.Document.Number, two.Document.Number);
        Assert.Equal(2, Count(f, "SELECT COUNT(*) FROM documents WHERE status = 'issued'"));
        Assert.Equal(8_000, OnHand(f, rice));
    }

    [Theory]
    [InlineData("has a space")]
    [InlineData("semi;colon")]
    [InlineData("quote'")]
    public void A_request_key_with_odd_characters_or_a_long_one_is_refused_and_an_empty_one_means_none(string bad)
    {
        using var f = new HubFixture();
        var rice = Rice(f, 10_000);
        Assert.Equal("request-key", Assert.Throws<HubException>(() => f.App.Documents.Checkout(Sale(rice, bad))).Code);
        Assert.Equal("request-key", Assert.Throws<HubException>(() => f.App.Documents.Checkout(Sale(rice, new string('a', 81)))).Code);
        Assert.Equal(0, Count(f, "SELECT COUNT(*) FROM documents WHERE status = 'issued'"));   // nothing was made by a refused request

        f.App.Documents.Checkout(Sale(rice, "  "));                                              // blank: no key, no protection
        f.App.Documents.Checkout(Sale(rice, null));
        Assert.Equal(2, Count(f, "SELECT COUNT(*) FROM documents WHERE status = 'issued'"));
    }

    [Fact]
    public void Twenty_five_sales_at_the_same_moment_each_get_their_own_number_and_every_one_is_whole()
    {
        using var f = new HubFixture();
        var rice = Rice(f, 100_000);

        var problems = AtTheSameMoment(25, i => f.App.Documents.Checkout(Sale(rice, "burst-" + i)));

        Assert.All(problems, p => Assert.Null(p));   // no "database is busy" gets out to a cashier
        var numbers = f.App.Db.Query("SELECT number FROM documents WHERE status = 'issued' ORDER BY number", r => r.GetString(0));
        Assert.Equal(25, numbers.Count);
        Assert.Equal(25, numbers.Distinct().Count());
        Assert.Equal(Enumerable.Range(1, 25).Select(n => $"INV-2026-{n:000000}").ToArray(), numbers.ToArray());   // no gap, no repeat
        Assert.Equal(25, Count(f, "SELECT COUNT(*) FROM payments"));
        Assert.Equal(25, Count(f, "SELECT COUNT(*) FROM stock_moves WHERE reason = 'sale'"));
        Assert.Equal(75_000, OnHand(f, rice));
        Assert.Equal(25, Count(f, "SELECT COUNT(*) FROM journal_entries WHERE source = 'bill'"));
        Assert.Equal(25, Count(f, "SELECT COUNT(*) FROM journal_entries WHERE source = 'payment'"));
        Assert.Equal(0, Count(f, "SELECT COUNT(*) FROM documents WHERE status = 'issued' AND paid_minor <> payable_minor"));
        var report = DatabaseCheck.Inspect(f.App.Db.Path);
        Assert.True(report.Healthy, string.Join("; ", report.Problems));   // the books still add up to nothing
    }

    [Fact]
    public void Ten_requests_with_the_same_key_at_the_same_moment_make_exactly_one_sale()
    {
        using var f = new HubFixture();
        var rice = Rice(f, 10_000);
        var numbers = new string?[10];

        var problems = AtTheSameMoment(10, i => numbers[i] = f.App.Documents.Checkout(Sale(rice, "same-key")).Document.Number);

        Assert.All(problems, p => Assert.Null(p));
        Assert.Single(numbers.Distinct());   // every caller was told about the same bill
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM documents WHERE status = 'issued'"));
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM payments"));
        Assert.Equal(9_000, OnHand(f, rice));
    }

    [Fact]
    public void Two_counters_selling_the_last_unit_at_the_same_moment_sell_it_once_when_the_shop_does_not_allow_stock_below_zero()
    {
        using var f = new HubFixture(configure: s => s.AllowNegativeStock = false);
        var rice = Rice(f, 1_000);   // one unit

        var problems = AtTheSameMoment(2, i => f.App.Documents.Checkout(Sale(rice, "counter-" + i)));

        Assert.Equal(1, problems.Count(p => p is null));
        var refused = Assert.Single(problems, p => p is not null);
        Assert.Equal("stock", Assert.IsType<HubException>(refused).Code);
        Assert.Equal(1, Count(f, "SELECT COUNT(*) FROM documents WHERE status = 'issued'"));
        Assert.Equal(0, OnHand(f, rice));
        Assert.Equal(0, Count(f, "SELECT COUNT(*) FROM documents WHERE status <> 'issued' AND number IS NOT NULL"));   // the loser left no numbered half-bill
    }

    [Fact]
    public void Undoing_the_request_key_step_keeps_every_bill_and_the_step_can_be_run_again()
    {
        using var f = new HubFixture();
        var rice = Rice(f, 10_000);
        var made = f.App.Documents.Checkout(Sale(rice, "before-undo"));
        var path = f.App.Db.Path;

        f.App.Db.Rollback(11);
        Assert.Equal(0, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM pragma_table_info('documents') WHERE name = 'request_key'")));
        Assert.Equal(made.Document.Number, f.App.Db.Scalar("SELECT number FROM documents WHERE status = 'issued'"));   // the bill is still there

        var again = HubApp.Open(path, f.Clock);
        Assert.Equal(1, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM pragma_table_info('documents') WHERE name = 'request_key'")));
        Assert.Equal(1, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM documents WHERE status = 'issued'")));
    }
}

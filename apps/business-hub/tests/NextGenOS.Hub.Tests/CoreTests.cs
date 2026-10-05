using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Tests;

public class CoreTests
{
    private static Item Product(HubFixture f, string name, string price, string taxClass = "standard", string? barcode = null, bool track = true) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, PriceMinor = f.App.Shop.Current.Minor(price), TaxClass = taxClass, Barcode = barcode, TrackStock = track });

    [Fact]
    public void A_new_database_is_made_with_every_table_and_opens_again_without_harm()
    {
        using var f = new HubFixture();
        Assert.NotNull(f.App.Db.Scalar("SELECT name FROM sqlite_master WHERE name = 'documents'"));
        var again = HubApp.Open(f.App.Db.Path, f.Clock);
        Assert.Equal(1L, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM schema_version")));
    }

    [Fact]
    public void Items_are_found_by_barcode_and_name_and_a_barcode_cannot_be_used_twice()
    {
        using var f = new HubFixture();
        var rice = Product(f, "Basmati rice 5 kg", "425.00", "reduced", "8901000000011");
        Assert.Equal(rice.Id, f.App.Catalog.FindByCode(" 8901000000011 ")!.Id);
        Assert.Contains(f.App.Catalog.Search("rice"), i => i.Id == rice.Id);
        Assert.Equal("GST5", rice.TaxCode);
        var ex = Assert.Throws<HubException>(() => Product(f, "Another", "1.00", "standard", "8901000000011"));
        Assert.Equal("duplicate-barcode", ex.Code);
        Assert.Throws<HubException>(() => f.App.Catalog.Create(new ItemInput { Name = "", PriceMinor = 1 }));
        Assert.Throws<HubException>(() => f.App.Catalog.Create(new ItemInput { Name = "x", PriceMinor = -1 }));
        Assert.Throws<HubException>(() => f.App.Catalog.Create(new ItemInput { Name = "x", TaxClass = "nonsense" }));
    }

    [Fact]
    public void A_counter_sale_in_India_is_worked_out_by_the_engine_numbered_and_takes_stock()
    {
        using var f = new HubFixture("IN", "retail");
        var rice = Product(f, "Rice", "118.00", "standard");
        f.App.Catalog.Adjust(rice.Id, 10_000, "delivery");
        var view = f.App.Documents.Checkout(new CheckoutRequest
        {
            Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 2000 } },
            Payments = { new PaymentInput { Method = "cash", AmountMinor = 30_000 } },
        });
        var d = view.Document;
        Assert.Equal("INV-2026-000001", d.Number);
        Assert.Equal(DocStatus.Issued, d.Status);
        Assert.Equal(23_600, d.TotalMinor);
        Assert.Equal(3_600, d.TaxMinor);
        Assert.Equal(20_000, d.SubtotalMinor);
        Assert.Equal("paid", d.PaymentState);
        Assert.Equal(23_600, d.PaidMinor);
        Assert.Equal("6400", d.Meta["changeGiven"]);
        Assert.Equal(new[] { "CGST", "SGST" }, view.Result!.Totals.Components.Select(c => c.Name).ToArray());
        Assert.Equal("18.00", view.Result.Totals.Components[0].Amount);
        Assert.Equal(8_000, f.App.Catalog.OnHandMilli(rice.Id));
        Assert.Single(view.Payments);
        Assert.Equal(23_600, view.Payments[0].AmountMinor);
    }

    [Fact]
    public void The_next_invoice_gets_the_next_number_and_a_new_fiscal_year_starts_again_at_one()
    {
        using var f = new HubFixture("IN", "retail");
        var item = Product(f, "Pen", "10.00", track: false);
        string Sell() => f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = item.Id } }, Payments = { new PaymentInput { AmountMinor = 1_200 } } }).Document.Number!;
        Assert.Equal("INV-2026-000001", Sell());
        Assert.Equal("INV-2026-000002", Sell());
        f.Clock.Set(new DateTimeOffset(2027, 4, 1, 6, 0, 0, TimeSpan.Zero)); // a new Indian financial year
        Assert.Equal("INV-2027-000001", Sell());
        f.Clock.Set(new DateTimeOffset(2027, 3, 31, 6, 0, 0, TimeSpan.Zero));
        Assert.Equal("INV-2026-000003", Sell());
    }

    [Fact]
    public void A_sale_to_another_state_is_charged_IGST()
    {
        using var f = new HubFixture("IN", "retail");
        var item = Product(f, "Laptop bag", "1180.00");
        var buyer = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Delhi buyer", Region = "07" });
        var view = f.App.Documents.Checkout(new CheckoutRequest { PartyId = buyer.Id, Lines = { new LineInput { ItemId = item.Id } }, Payments = { new PaymentInput { AmountMinor = 118_000 } } });
        Assert.Equal(new[] { "IGST" }, view.Result!.Totals.Components.Select(c => c.Name).ToArray());
        Assert.Equal("180.00", view.Result.Totals.Components[0].Amount);
    }

    [Fact]
    public void A_bill_must_be_paid_in_full_unless_the_customer_has_credit_and_room()
    {
        using var f = new HubFixture("IN", "wholesale");
        var item = Product(f, "Sugar 50 kg", "2000.00", "exempt");
        var shopper = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Cash customer" });
        var trade = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Sharma Store", CreditLimitMinor = 500_000, TermsDays = 15 });
        var ex = Assert.Throws<HubException>(() => f.App.Documents.Checkout(new CheckoutRequest { PartyId = shopper.Id, Lines = { new LineInput { ItemId = item.Id } }, Payments = { new PaymentInput { AmountMinor = 100_000 } } }));
        Assert.Equal("short", ex.Code);
        ex = Assert.Throws<HubException>(() => f.App.Documents.Checkout(new CheckoutRequest { PartyId = shopper.Id, Lines = { new LineInput { ItemId = item.Id } }, OnCredit = true }));
        Assert.Equal("no-credit", ex.Code);

        var sale = f.App.Documents.Checkout(new CheckoutRequest { PartyId = trade.Id, Lines = { new LineInput { ItemId = item.Id, QtyMilli = 2000 } }, OnCredit = true });
        Assert.Equal("unpaid", sale.Document.PaymentState);
        Assert.Equal(400_000, f.App.Documents.Outstanding(trade.Id));
        Assert.Equal(new DateTimeOffset(2026, 10, 20, 6, 30, 0, TimeSpan.Zero), sale.Document.DueAt);

        ex = Assert.Throws<HubException>(() => f.App.Documents.Checkout(new CheckoutRequest { PartyId = trade.Id, Lines = { new LineInput { ItemId = item.Id, QtyMilli = 1000 } }, OnCredit = true }));
        Assert.Equal("over-limit", ex.Code);

        var paid = f.App.Documents.AddPayment(sale.Document.Id, new PaymentInput { Method = "bank", AmountMinor = 150_000 });
        Assert.Equal("partial", paid.Document.PaymentState);
        Assert.Equal(250_000, paid.Document.BalanceMinor);
        Assert.Throws<HubException>(() => f.App.Documents.AddPayment(sale.Document.Id, new PaymentInput { Method = "bank", AmountMinor = 250_001 }));
        paid = f.App.Documents.AddPayment(sale.Document.Id, new PaymentInput { Method = "bank", AmountMinor = 250_000 });
        Assert.Equal("paid", paid.Document.PaymentState);
        Assert.Equal(0, f.App.Documents.Outstanding(trade.Id));
    }

    [Fact]
    public void Prices_follow_the_customers_price_level()
    {
        using var f = new HubFixture("IN", "wholesale");
        var item = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice 25 kg", PriceMinor = 170_000, TradePriceMinor = 158_000, TaxClass = "reduced" });
        var trade = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Trader", PriceLevel = "trade" });
        var draft = f.App.Documents.CreateDraft(new DraftOptions { PartyId = trade.Id, Lines = { new LineInput { ItemId = item.Id } } });
        Assert.Equal(158_000, draft.Lines[0].UnitPriceMinor);
        var retail = f.App.Documents.SetParty(draft.Document.Id, null);
        Assert.Equal(158_000, retail.Lines[0].UnitPriceMinor); // setting no customer leaves prices as they are
        var other = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Walk-in" });
        Assert.Equal(170_000, f.App.Documents.SetParty(draft.Document.Id, other.Id).Lines[0].UnitPriceMinor);
    }

    [Fact]
    public void A_final_document_cannot_be_changed_and_an_empty_one_cannot_be_issued()
    {
        using var f = new HubFixture();
        var item = Product(f, "Pen", "10.00", track: false);
        var draft = f.App.Documents.CreateDraft(new DraftOptions());
        Assert.Equal("empty", Assert.Throws<HubException>(() => f.App.Documents.Issue(draft.Document.Id)).Code);
        var withLine = f.App.Documents.AddLine(draft.Document.Id, new LineInput { ItemId = item.Id });
        var issued = f.App.Documents.Issue(withLine.Document.Id, new IssueOptions { Payments = { new PaymentInput { AmountMinor = 1_200 } } });
        Assert.Equal("not-open", Assert.Throws<HubException>(() => f.App.Documents.AddLine(issued.Document.Id, new LineInput { ItemId = item.Id })).Code);
        Assert.Equal("not-open", Assert.Throws<HubException>(() => f.App.Documents.Issue(issued.Document.Id)).Code);
    }

    [Fact]
    public void Voiding_gives_the_stock_back_and_refunds_what_was_paid_and_is_recorded()
    {
        using var f = new HubFixture();
        var item = Product(f, "Rice", "100.00");
        f.App.Catalog.Adjust(item.Id, 5_000, "delivery");
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = item.Id, QtyMilli = 2000 } }, Payments = { new PaymentInput { AmountMinor = 21_000 } } });
        Assert.Equal(3_000, f.App.Catalog.OnHandMilli(item.Id));
        Assert.Equal("reason", Assert.Throws<HubException>(() => f.App.Documents.Void(sale.Document.Id, " ", null)).Code);
        var voided = f.App.Documents.Void(sale.Document.Id, "wrong customer", null);
        Assert.Equal(DocStatus.Void, voided.Document.Status);
        Assert.Equal(5_000, f.App.Catalog.OnHandMilli(item.Id));
        Assert.Equal(0, voided.Document.PaidMinor);
        Assert.Contains(voided.Payments, p => p.Kind == "refund" && p.AmountMinor == -20_000); // 2 x 100.00; the 10.00 of change was never kept
        Assert.Equal("already-void", Assert.Throws<HubException>(() => f.App.Documents.Void(sale.Document.Id, "again", null)).Code);
        Assert.Contains(f.App.Audit.Recent(), a => a.Action == "void" && a.Detail == "wrong customer");
    }

    [Fact]
    public void A_credit_note_returns_some_of_the_goods_and_refunds_them_and_cannot_return_more_than_was_sold()
    {
        using var f = new HubFixture("IN", "retail");
        var item = Product(f, "Rice", "118.00");
        f.App.Catalog.Adjust(item.Id, 10_000, "delivery");
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = item.Id, QtyMilli = 3000 } }, Payments = { new PaymentInput { AmountMinor = 35_400 } } });
        var line = sale.Lines[0];
        var note = f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (line.Id, 1000L) }, "damaged", "cash", null);
        Assert.Equal("CN-2026-000001", note.Document.Number);
        Assert.Equal(11_800, note.Document.TotalMinor);
        Assert.Equal(sale.Document.Id, note.Document.RefDocumentId);
        Assert.Contains(note.Payments, p => p.Kind == "refund" && p.AmountMinor == -11_800);
        Assert.Equal(8_000, f.App.Catalog.OnHandMilli(item.Id)); // 10 - 3 + 1 = 8
        var invoice = f.App.Documents.Get(sale.Document.Id)!;
        Assert.Equal(23_600, invoice.Document.PaidMinor);
        Assert.Equal("too-many", Assert.Throws<HubException>(() => f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (line.Id, 2500L) }, "more", "cash", null)).Code);
        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (line.Id, 2000L) }, "rest", "cash", null);
        Assert.Equal("has-credit-note", Assert.Throws<HubException>(() => f.App.Documents.Void(sale.Document.Id, "late", null)).Code);
    }

    [Fact]
    public void A_shop_that_does_not_allow_negative_stock_refuses_to_sell_what_it_does_not_have()
    {
        using var f = new HubFixture("IN", "retail", s => s.AllowNegativeStock = false);
        var item = Product(f, "Rice", "100.00");
        f.App.Catalog.Adjust(item.Id, 1_000, "delivery");
        var ex = Assert.Throws<HubException>(() => f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = item.Id, QtyMilli = 2000 } }, Payments = { new PaymentInput { AmountMinor = 30_000 } } }));
        Assert.Equal("stock", ex.Code);
        Assert.Equal(1_000, f.App.Catalog.OnHandMilli(item.Id));
        Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE status = 'issued'")));
    }

    [Fact]
    public void A_country_that_needs_a_region_uses_the_shops_own_and_the_shops_own_rate_override_applies()
    {
        using var f = new HubFixture("US", "retail", s => { s.ComponentOverrides["STORE/Sales tax"] = "8.875"; s.PricesIncludeTax = false; });
        var item = Product(f, "T-shirt", "19.99");
        var sale = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = item.Id } }, Payments = { new PaymentInput { AmountMinor = 2_176 } } });
        Assert.Equal(2_176, sale.Document.TotalMinor); // 19.99 + 8.875% of it (1.774, so 1.77) = 21.76
    }
}

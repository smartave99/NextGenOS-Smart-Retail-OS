using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Import;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, customers and suppliers in a spreadsheet (the older POS's staff import launcher, study 04 C.1): check first, write nothing until it is right; a copy of the shop's data first; one transaction;
/// opening balances for new people only. Shop in India, rupees, prices in paise.
/// </summary>
public class PartySheetTests
{
    private static HubFixture Shop() => new("IN", "retail", s => s.PricesIncludeTax = false);

    private static PartySheetCheck Check(HubFixture f, string text) => f.App.PartySheets.Check("people.csv", text);

    private const string Header = "Name,Kind,Phone,Email,Address,Credit limit,Days to pay,Prices,Balance,Notes";

    [Fact]
    public void The_template_and_the_export_have_the_columns_the_check_reads_and_a_round_trip_changes_nothing()
    {
        using var f = Shop();
        f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha Traders", Phone = "98000 11111", CreditLimitMinor = 5_000_000, TermsDays = 15, PriceLevel = "trade", Region = "27", TaxId = "27AAAAA0000A1Z5" });
        f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Mill Co", Phone = "98000 22222" });

        var template = f.App.PartySheets.Template();
        var export = f.App.PartySheets.Export();

        Assert.StartsWith("Name,Kind,Phone,Email,Address,", template);
        Assert.Contains("GSTIN", template.Split('\n')[0]);
        Assert.Contains("Maharashtra", export);
        var back = Check(f, export);
        Assert.False(back.HasProblems);
        Assert.Equal((0, 0, 2), (back.ToAdd, back.ToChange, back.Same));
    }

    [Fact]
    public void New_customers_and_suppliers_are_added_and_what_they_owe_goes_into_the_books_as_an_opening_balance()
    {
        using var f = Shop();
        var check = Check(f, Header + "\n" +
            "Sharma Store,customer,98000 11111,,,50000,30,trade,12500.50,Good payer\n" +
            "National Foods,supplier,98000 22222,,,,,,8000,\n" +
            "Walk-in friend,customer,,,,,,,,\n");

        Assert.False(check.HasProblems);
        Assert.Equal((3, 0, 0), (check.ToAdd, check.ToChange, check.Same));
        Assert.Contains("owed to the shop", check.Lines[0].Detail);
        Assert.Contains("owed by the shop", check.Lines[1].Detail);

        var result = f.App.PartySheets.Import(check, null);

        Assert.Equal((3, 0, 2), (result.Added, result.Changed, result.Balances));
        Assert.True(File.Exists(result.Backup));
        var sharma = f.App.Parties.Search("customer", "Sharma").Single();
        Assert.Equal((5_000_000L, 30, "trade", "Good payer"), (sharma.CreditLimitMinor, sharma.TermsDays, sharma.PriceLevel, sharma.Notes));
        Assert.Equal(1_250_050, f.App.Books.CustomerBalance(sharma.Id));                                    // owes the shop 12,500.50
        Assert.Equal(800_000, f.App.Books.SupplierBalance(f.App.Parties.Search("supplier", "National").Single().Id));   // the shop owes 8,000.00
        var trial = f.App.Books.TrialBalance();
        Assert.Equal(trial.Sum(x => x.DebitMinor), trial.Sum(x => x.CreditMinor));
    }

    [Fact]
    public void Somebody_who_is_there_is_found_by_phone_then_name_and_only_the_columns_with_something_in_them_change()
    {
        using var f = Shop();
        var asha = f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Asha Traders", Phone = "98000 11111", Address = "Old road", CreditLimitMinor = 1_000_000 });

        var check = Check(f, "Name,Kind,Phone,Address,Credit limit,Balance\nAsha Traders Pvt,customer,+91 98000-11111,New road,,999\n");

        Assert.False(check.HasProblems);
        Assert.Equal(1, check.ToChange);
        Assert.Contains("Name Asha Traders → Asha Traders Pvt", check.Lines[0].Detail);
        Assert.Contains("Address Old road → New road", check.Lines[0].Detail);
        Assert.DoesNotContain("Credit limit", check.Lines[0].Detail);
        Assert.Contains(check.Notes, n => n.Contains("balance of \"Asha Traders\" is not changed from here"));

        f.App.PartySheets.Import(check, null);

        var now = f.App.Parties.Get(asha.Id)!;
        Assert.Equal(("Asha Traders Pvt", "New road", 1_000_000L), (now.Name, now.Address, now.CreditLimitMinor));
        Assert.Equal(0, f.App.Books.CustomerBalance(asha.Id));   // the balance of somebody who is there is not touched
    }

    [Fact]
    public void A_row_that_cannot_be_used_is_said_in_plain_words_with_its_row_number_and_nothing_is_written()
    {
        using var f = Shop();
        f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Twin", Phone = "1" });
        f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "Twin", Phone = "2" });

        var check = Check(f, Header + "\n" +
            ",customer,,,,,,,,\n" +                                   // row 2: no name
            "Bad kind,robot,,,,,,,,\n" +                              // row 3
            "Bad limit,customer,,,,lots,,,,\n" +                      // row 4
            "Bad days,customer,,,,,400,,,\n" +                        // row 5
            "Bad prices,customer,,,,,,gold,,\n" +                     // row 6
            "Dup,customer,,,,,,,,\nDup,customer,,,,,,,,\n" +          // rows 7 and 8
            "Twin,customer,,,,,,,,\n");                               // row 9: two people have that name

        Assert.True(check.HasProblems);
        var said = check.Problems.ToDictionary(p => p.Row, p => p.Message);
        Assert.Contains("no name", said[2]);
        Assert.Contains("not a kind of person", said[3]);
        Assert.Contains("credit limit", said[4]);
        Assert.Contains("0 to 365", said[5]);
        Assert.Contains("retail or trade", said[6]);
        Assert.Contains("also on row 7", said[8]);
        Assert.Contains("More than one person is called", said[9]);
        var ex = Assert.Throws<HubException>(() => f.App.PartySheets.Import(check, null));
        Assert.Equal("sheet-problems", ex.Code);
        Assert.Equal(2, f.App.Parties.Search(null, null, 100).Count);
    }

    [Fact]
    public void The_state_can_be_typed_by_name_or_code_and_a_wrong_one_is_refused()
    {
        using var f = Shop();

        var ok = Check(f, "Name,GSTIN,State\nA,27AAAAA0000A1Z5,Maharashtra\nB,,27\n");
        var bad = Check(f, "Name,State\nC,Atlantis\n");

        Assert.False(ok.HasProblems);
        f.App.PartySheets.Import(ok, null);
        Assert.Equal(new[] { "27", "27" }, f.App.Parties.Search(null, null, 10).Select(p => p.Region).ToArray());
        Assert.Contains("not one of the", bad.Problems.Single().Message);
    }

    [Fact]
    public void If_the_shops_people_changed_since_the_check_nothing_is_written_and_a_file_with_nothing_new_is_refused()
    {
        using var f = Shop();
        var check = Check(f, "Name,Phone\nNew Person,98000 33333\n");
        f.App.Parties.Create(new PartyInput { Kind = "customer", Name = "New Person", Phone = "98000 33333" });

        Assert.Equal("sheet-changed", Assert.Throws<HubException>(() => f.App.PartySheets.Import(check, null)).Code);

        var same = Check(f, "Name,Phone\nNew Person,98000 33333\n");
        Assert.True(same.NothingToDo);
        Assert.Equal("sheet-nothing", Assert.Throws<HubException>(() => f.App.PartySheets.Import(same, null)).Code);
    }

    [Fact]
    public void A_balance_below_nothing_is_what_the_other_side_owes_and_a_balance_for_a_member_is_left_out()
    {
        using var f = new HubFixture("IN", "services", s => s.PricesIncludeTax = false);   // a trade that also keeps staff as people
        var check = Check(f, "Name,Kind,Balance\nPaid ahead,customer,-500\nWe overpaid,supplier,-300\nAn odd one,staff,100\n");

        Assert.False(check.HasProblems);
        f.App.PartySheets.Import(check, null);

        Assert.Equal(-50_000, f.App.Books.CustomerBalance(f.App.Parties.Search("customer", "Paid ahead").Single().Id));   // the shop holds 500.00 for them
        Assert.Equal(-30_000, f.App.Books.SupplierBalance(f.App.Parties.Search("supplier", "We overpaid").Single().Id));   // below nothing: the supplier owes the shop
        Assert.Contains(check.Notes, n => n.Contains("is not a customer or a supplier"));
    }
}

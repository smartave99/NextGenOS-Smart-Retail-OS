using NextGenOS.Hub.Backups;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Diagnostics;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The Help button's support file (the owner's decision 18): it says how the shop is set up and how it is doing, and holds no sales, no customers, no staff names, no amounts, no passwords and no
/// keys. These tests fill a shop with exactly those things and look for them in the file.
/// </summary>
public sealed class SupportFileTests : IDisposable
{
    private readonly HubFixture f = new("IN", "retail", s => s.Name = "Corner Mart of Pune");
    private readonly long ownerId;

    public SupportFileTests()
    {
        var a = f.App;
        ownerId = a.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery staple").Id;
        a.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password here");
        var customer = a.Parties.Create(new PartyInput { Kind = "customer", Name = "Maria Santos", Phone = "+91 98765 43210", Email = "maria@example.com", Address = "12 Garden Lane, Pune 411001", Notes = "always pays late, secret gate code 4471" });
        var supplier = a.Parties.Create(new PartyInput { Kind = "supplier", Name = "National Foods Pvt Ltd" });
        var rice = a.Catalog.Create(new ItemInput { Kind = "stock", Name = "Basmati Gold Reserve", Unit = "kg", PriceMinor = 123_456, CostMinor = 98_765, TaxClass = "zero", TrackStock = true });
        a.Purchasing.Receive(a.Purchasing.CreateOrder(supplier.Id, new[] { new NextGenOS.Hub.Purchasing.PurchaseLine { ItemId = rice.Id, QtyMilli = 50_000, CostMinor = 98_765 } }).Document.Id);
        a.Documents.Checkout(new CheckoutRequest { PartyId = customer.Id, Notes = "deliver to the blue door", Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 3_000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 100_000_000, Reference = "UPI-777-SECRET" } } });
    }

    public void Dispose() => f.Dispose();

    private string File()
    {
        using var scope = f.App.Access.As(ownerId);
        return SupportService.Render("Business Hub", f.Clock.UtcNow, "The printer froze.", f.App.Support.Sections());
    }

    // ---- taking things out -----------------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(@"cannot open C:\Users\maria.santos\AppData\shop.db now", "maria.santos")]
    [InlineData("failed at /home/maria.santos/backups/copy-1.db", "maria.santos")]
    [InlineData(@"cannot reach \\office-pc\share\copies", "office-pc")]
    [InlineData("write to maria@example.com failed", "maria@example.com")]
    [InlineData("rang +91 98765 43210 twice", "98765")]
    [InlineData("rang 9876543210 twice", "9876543210")]
    [InlineData("paid with 4111 1111 1111 1111 today", "4111")]
    [InlineData("from 192.168.1.20 port 5290", "192.168.1.20")]
    [InlineData("password=hunter2-correct and more", "hunter2")]
    [InlineData("Authorization: Bearer abc.def.ghi-jkl", "abc.def")]
    [InlineData("connectionstring=Server=db;User=sa;Pwd=Secret1!", "Secret1")]
    [InlineData("key AbCdEfGhIjKlMnOpQrStUvWxYz0123456789AbCd done", "AbCdEfGhIjKlMnOpQrStUvWxYz0123456789AbCd")]
    public void Folders_addresses_numbers_passwords_and_keys_are_taken_out_of_any_text(string text, string gone)
    {
        var cleaned = SupportRedaction.Clean(text);
        Assert.DoesNotContain(gone, cleaned);
        Assert.NotEmpty(cleaned);
    }

    [Fact]
    public void The_names_and_addresses_the_shop_keeps_are_taken_out_too_and_ordinary_words_are_left_alone()
    {
        var known = new[] { "Maria Santos", "12 Garden Lane", "Olivia Owner" };
        var cleaned = SupportRedaction.Clean("Could not print for maria santos at 12 Garden Lane (signed in: Olivia Owner): the printer is offline", known);
        Assert.Equal("Could not print for [a person] at [a person] (signed in: [a person]): the printer is offline", cleaned);
        Assert.Equal("The printer is offline", SupportRedaction.Clean("The printer is offline", known));
        Assert.Equal(401, SupportRedaction.Clean(string.Join(" ", Enumerable.Repeat("word", 200)), null, 400).Length);
        Assert.Equal("[hidden]", SupportRedaction.Clean(new string('x', 900)));          // a very long run of letters is a code, not words
        Assert.Equal("one two three", SupportRedaction.Clean("one\r\ntwo\nthree"));
        Assert.Equal("", SupportRedaction.Clean(null));
    }

    // ---- what is in the file ---------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_file_says_how_the_shop_stands_in_plain_words()
    {
        var text = File();
        Assert.StartsWith("BUSINESS HUB — SUPPORT FILE", text);
        Assert.Contains("Read this before you send it.", text);
        Assert.Contains("The program has not sent it anywhere", text);
        Assert.Contains("WHAT YOU SAID\nThe printer froze.", text.Replace("\r", ""));
        Assert.Contains("YOUR SHOP'S DATA", text);
        Assert.Contains($"database step {HubDb.LatestVersion} of {HubDb.LatestVersion}", text);
        Assert.Contains("File check: no problem found", text);
        Assert.Contains("COPIES OF YOUR SHOP", text);
        Assert.Contains("Nightly copies: off; place not chosen", text);
        Assert.Contains("Last good copy: none", text);
        Assert.Contains("COUNTER PCS", text);
        Assert.Contains("NEW VERSIONS OF THE PROGRAM", text);
        Assert.Contains("This copy was not made to look for new versions.", text);
        Assert.Contains("Where it stands: not looked yet.", text);
        Assert.Contains("Counter PCs: chosen off, listening no, 0 paired PC(s).", text);
        Assert.Contains("AI HELPERS AND WAITING LINES", text);
        Assert.Contains("AI part in the licence: no", text);
        Assert.Contains("Switches on: none", text);
        Assert.Contains("Business-event messages: 0 waiting, 0 could not be written, 0 written.", text);
        Assert.Contains("THE KIND OF SHOP", text);
        Assert.Contains("Kind of business: retail; country: IN; set-up finished: yes.", text);
    }

    [Fact]
    public void A_failed_copy_is_in_the_file_with_the_folder_and_the_person_in_its_name_taken_out()
    {
        var place = Path.Combine(Path.GetTempPath(), "support-copies-maria.santos-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(place);
        f.App.Backups.Save(new BackupSettings(true, place, "02:00", 5), 1);
        Directory.Delete(place, recursive: true);                                       // the drive is unplugged
        try { f.App.Backups.RunNow(); } catch (HubException) { /* the failure is written down */ }
        var text = File();
        Assert.Contains("Nightly copies: on, 02:00, keeping 5; place chosen", text);
        Assert.Contains("Last failed copy:", text);
        Assert.Contains("Last good copy: none", text);
        Assert.DoesNotContain("maria.santos", text);
        Assert.DoesNotContain(Path.GetTempPath().TrimEnd('/'), text);
    }

    [Fact]
    public void The_counts_of_what_happened_lately_are_numbers_only()
    {
        for (var i = 0; i < 3; i++) { using var scope = f.App.Access.As(null as long?); }
        f.App.Audit.Log(null, "access-denied", "permission", null, "sell");
        f.App.Audit.Log(null, "access-denied", "permission", null, "settings");
        var text = File();
        Assert.Contains("LAST 7 DAYS IN THE ACTIVITY RECORD (COUNTS ONLY)", text);
        Assert.Contains("- access-denied: 2", text);
        Assert.DoesNotContain("settings", text.Split("ACTIVITY RECORD")[1].Split("THE KIND OF SHOP")[0].Replace("(COUNTS ONLY)", ""));   // what was refused is not in it, only how often
    }

    // ---- what is not in the file -----------------------------------------------------------------------------------------------------------------

    [Fact]
    public void No_sale_customer_staff_name_amount_password_note_or_the_shops_own_name_is_in_the_file()
    {
        var text = File();
        foreach (var private_ in new[]
        {
            "Maria", "Santos", "98765", "maria@example.com", "Garden Lane", "411001", "4471", "gate code", "always pays late",
            "National Foods", "Basmati", "Gold Reserve", "123456", "1,234.56", "98765", "987.65", "blue door", "UPI-777", "SECRET", "INV-", "100000000",
            "Olivia", "Tara Till", "olivia", "tara", "correct horse", "another good password",
            "Corner Mart", "Pune",
        })
            Assert.DoesNotContain(private_, text, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain(f.App.Db.Path, text);
        Assert.DoesNotContain(Path.GetDirectoryName(f.App.Db.Path)!, text);
    }

    [Fact]
    public void What_the_owner_types_in_the_message_is_cleaned_of_the_obvious_and_kept_to_a_thousand_letters()
    {
        using var scope = f.App.Access.As(ownerId);
        var people = new NextGenOS.Hub.Ai.PersonalValues(f.App.Db).Known();
        var text = SupportService.Render("Business Hub", f.Clock.UtcNow, "Maria Santos rang from +91 98765 43210 about card 4111 1111 1111 1111 and said maria@example.com. " + new string('x', 2_000), f.App.Support.Sections(), people);
        var said = text.Replace("\r", "").Split("WHAT YOU SAID\n")[1].Split("\n")[0];
        Assert.DoesNotContain("Maria", said);
        Assert.DoesNotContain("98765", said);
        Assert.DoesNotContain("4111", said);
        Assert.DoesNotContain("example.com", said);
        Assert.True(said.Length <= 1_001);
        Assert.Contains("(nothing was written)", SupportService.Render("Business Hub", f.Clock.UtcNow, "   ", []));
    }

    // ---- who may make it -------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void Only_the_owner_can_make_it_and_nobody_unnamed_in_the_shop_as_people_use_it()
    {
        var strict = HubApp.Open(f.App.Db.Path, f.Clock);
        var cashier = strict.Users.List().First(u => u.Role == Roles.Cashier).Id;
        Assert.Equal("not-signed-in", Assert.Throws<HubException>(() => strict.Support.Sections()).Code);
        using (strict.Access.As(cashier)) Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Support.Sections()).Code);
        using (strict.Access.As(ownerId)) Assert.NotEmpty(strict.Support.Sections());
    }
}

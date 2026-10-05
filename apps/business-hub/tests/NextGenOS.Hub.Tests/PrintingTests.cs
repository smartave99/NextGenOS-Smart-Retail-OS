using System.Text;
using NextGenOS.Devices.Printing;
using NextGenOS.Devices.Transport;
using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Tests;

public class PrintingTests
{
    private sealed class Recorder : IPrinterTransport
    {
        public List<byte[]> Sent { get; } = new();
        public bool Fail { get; set; }

        public Task SendAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            if (Fail) throw new PrinterException("The printer at 10.0.0.9:9100 could not be reached (ConnectionRefused). Check that it is on and on the same network.");
            Sent.Add(data);
            return Task.CompletedTask;
        }
    }

    private static (HubFixture F, Recorder R) Shop(string industry = "retail")
    {
        var recorder = new Recorder();
        return (new HubFixture("IN", industry, printer: recorder), recorder);
    }

    private static PrinterProfile Receipt(string name = "Counter", bool auto = false) => new() { Name = name, Role = PrinterRole.Receipt, Connection = Connection.Network, Address = "10.0.0.9", Columns = 42, AutoPrint = auto };

    private static string Text(byte[] bytes) => Encoding.Latin1.GetString(bytes);

    [Fact]
    public async Task A_bill_is_printed_with_the_shop_the_tax_and_the_total()
    {
        var (f, r) = Shop();
        using (f)
        {
            f.App.PrinterProfiles.Save(Receipt());
            var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Basmati rice 5 kg", PriceMinor = 11_800, TaxClass = "standard" });
            var bill = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 2000 } }, Payments = { new PaymentInput { AmountMinor = 30_000 } } });
            await f.App.Printing.PrintBillAsync(bill.Document.Id);
            var text = Text(r.Sent.Single());
            Assert.Contains("Test Shop", text);
            Assert.Contains("Tax Invoice", text);
            Assert.Contains("INV-2026-000001", text);
            Assert.Contains("Basmati rice 5 kg", text);
            Assert.Contains("CGST", text);
            Assert.Contains("SGST", text);
            Assert.Contains("TOTAL", text);
            Assert.Contains("Rs236.00", text);                 // the rupee sign is written as Rs: receipt printers do not have it
            Assert.Contains("Change", text);
            Assert.Contains("Rs64.00", text);
        }
    }

    [Fact]
    public async Task Without_a_printer_the_message_says_where_to_add_one_and_nothing_is_lost()
    {
        var (f, _) = Shop();
        using (f)
        {
            var item = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Pen", PriceMinor = 1_180 });
            var bill = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = item.Id } }, Payments = { new PaymentInput { AmountMinor = 1_180 } } });
            var ex = await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintBillAsync(bill.Document.Id));
            Assert.Contains("Settings", ex.Message);
            Assert.Equal(DocStatus.Issued, f.App.Documents.Get(bill.Document.Id)!.Document.Status);
        }
    }

    [Fact]
    public async Task A_printer_that_is_off_gives_the_message_to_the_cashier_and_is_logged_nowhere_as_a_crash()
    {
        var (f, r) = Shop();
        using (f)
        {
            r.Fail = true;
            f.App.PrinterProfiles.Save(Receipt());
            var item = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Pen", PriceMinor = 1_180 });
            var bill = f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = item.Id } }, Payments = { new PaymentInput { AmountMinor = 1_180 } } });
            var ex = await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintBillAsync(bill.Document.Id));
            Assert.Equal("printer-failed", ex.Code);
            Assert.Contains("Check that it is on", ex.Message);
        }
    }

    [Fact]
    public void Printers_are_saved_listed_found_by_job_and_removed()
    {
        var (f, _) = Shop("restaurant");
        using (f)
        {
            var store = f.App.PrinterProfiles;
            Assert.Empty(store.List());
            store.Save(Receipt("Counter", auto: true));
            store.Save(new PrinterProfile { Name = "Bar", Role = PrinterRole.Kitchen, Station = "Bar", Connection = Connection.Network, Address = "10.0.0.20" });
            store.Save(new PrinterProfile { Name = "Hot kitchen", Role = PrinterRole.Kitchen, Connection = Connection.Network, Address = "10.0.0.21" });
            store.Save(new PrinterProfile { Name = "Labels", Role = PrinterRole.Label, Language = PrinterLanguage.Tspl, Connection = Connection.Device, Address = "/dev/usb/lp0" });
            Assert.Equal(4, store.List().Count);
            Assert.Equal("Counter", store.For(PrinterRole.Receipt)!.Name);
            Assert.Equal("Bar", store.For(PrinterRole.Kitchen, "Bar")!.Name);
            Assert.Equal("Hot kitchen", store.For(PrinterRole.Kitchen, "Kitchen")!.Name);        // the one for all stations
            Assert.Equal(PrinterLanguage.Tspl, store.For(PrinterRole.Label)!.Language);
            Assert.Equal("Counter", f.App.Printing.AutoPrinter()!.Name);
            Assert.Equal("printer-name", Assert.Throws<HubException>(() => store.Save(Receipt("counter"))).Code);
            Assert.Equal("printer", Assert.Throws<HubException>(() => store.Save(new PrinterProfile { Name = "Broken" })).Code);
            var counter = store.For(PrinterRole.Receipt)!;
            counter.Columns = 32;
            store.Save(counter);
            Assert.Equal(32, store.Get(counter.Id)!.Columns);
            store.Remove(counter.Id);
            Assert.Null(store.For(PrinterRole.Receipt));
        }
    }

    [Fact]
    public async Task Kitchen_tickets_go_to_the_printer_of_their_station_and_a_dead_printer_does_not_stop_the_order()
    {
        var (f, r) = Shop("restaurant");
        using (f)
        {
            f.App.PrinterProfiles.Save(new PrinterProfile { Name = "Bar", Role = PrinterRole.Kitchen, Station = "Bar", Connection = Connection.Network, Address = "10.0.0.20" });
            var table = f.App.Restaurant.AddTable("T1", 4);
            var espresso = f.App.Catalog.Create(new ItemInput { Kind = "menu", Name = "Espresso", PriceMinor = 12_000, Station = "Bar" });
            var croissant = f.App.Catalog.Create(new ItemInput { Kind = "menu", Name = "Croissant", PriceMinor = 11_000, Station = "Kitchen" });
            var order = f.App.Restaurant.OpenOrder(table.Id, 2);
            f.App.Restaurant.AddItem(order.Document.Id, espresso.Id, 1000, "Extra hot");
            f.App.Restaurant.AddItem(order.Document.Id, croissant.Id);
            var tickets = f.App.Restaurant.Fire(order.Document.Id);
            var problems = await f.App.Printing.PrintTicketsAsync(tickets);
            Assert.Empty(problems);
            var text = Text(r.Sent.Single());                               // only the Bar has a printer
            Assert.Contains("BAR", text);
            Assert.Contains("Table T1", text);
            Assert.Contains("Espresso", text);
            Assert.Contains("Extra hot", text);
            Assert.DoesNotContain("Croissant", text);
            r.Fail = true;
            var second = f.App.Restaurant.AddItem(order.Document.Id, espresso.Id);
            var more = f.App.Restaurant.Fire(order.Document.Id);
            var failed = await f.App.Printing.PrintTicketsAsync(more);
            Assert.Contains("Bar: ", Assert.Single(failed));
            Assert.Equal(DocStatus.Open, f.App.Documents.Get(order.Document.Id)!.Document.Status);
        }
    }

    [Fact]
    public async Task A_label_is_printed_in_the_language_of_the_label_printer_with_the_items_barcode()
    {
        var (f, r) = Shop();
        using (f)
        {
            f.App.PrinterProfiles.Save(new PrinterProfile { Name = "Labels", Role = PrinterRole.Label, Language = PrinterLanguage.Zpl, Connection = Connection.Network, Address = "10.0.0.30", LabelWidthMm = 50, LabelHeightMm = 30 });
            var tea = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Tea leaves 250 g", PriceMinor = 12_000, Barcode = "5901234123457" });
            await f.App.Printing.PrintLabelsAsync(tea.Id, 3);
            var text = Encoding.UTF8.GetString(r.Sent.Single());
            Assert.Contains("^XA", text);
            Assert.Contains("Tea leaves 250 g", text);
            Assert.Contains("^FD5901234123457^FS", text);
            Assert.Contains("^PQ3", text);
            Assert.Equal("copies", (await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintLabelsAsync(tea.Id, 0))).Code);
            Assert.Equal("copies", (await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintLabelsAsync(tea.Id, 501))).Code);
        }
    }

    [Fact]
    public void New_barcodes_are_valid_in_store_numbers_that_no_other_item_uses()
    {
        var (f, _) = Shop();
        using (f)
        {
            var numbers = new HashSet<string>();
            for (var i = 0; i < 5; i++)
            {
                var code = f.App.Printing.NewBarcode();
                Assert.True(NextGenOS.Devices.Barcodes.Barcode.IsValidEan13(code));
                Assert.StartsWith("2", code);
                Assert.True(numbers.Add(code));
                f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Item " + i, PriceMinor = 100, Barcode = code });
            }
        }
    }

    [Fact]
    public async Task The_test_page_and_the_drawer_use_the_printer_chosen()
    {
        var (f, r) = Shop();
        using (f)
        {
            var profile = f.App.PrinterProfiles.Save(Receipt());
            await f.App.Printing.TestAsync(profile.Id);
            Assert.Contains("Printer test", Text(r.Sent[0]));
            await f.App.Printing.OpenDrawerAsync();
            Assert.Contains("\u001bp\0\u0019ú", Text(r.Sent[1]));
            Assert.Equal("no-printer", (await Assert.ThrowsAsync<HubException>(() => f.App.Printing.TestAsync("nope"))).Code);
        }
    }
}

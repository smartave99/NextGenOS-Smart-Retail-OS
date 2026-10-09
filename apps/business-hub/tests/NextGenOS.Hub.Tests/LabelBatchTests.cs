using System.Text;
using NextGenOS.Devices.Printing;
using NextGenOS.Devices.Transport;
using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;

namespace NextGenOS.Hub.Tests;

/// <summary>Merge, products tools D: labels for many items at once, and for what a delivery brought (study 02 A2.5, BC3 to BC5). A label printer with a recording line stands in for the real one.</summary>
public class LabelBatchTests
{
    private sealed class Recorder : IPrinterTransport
    {
        public List<byte[]> Sent { get; } = new();
        public bool FailOnSecond { get; set; }

        public Task SendAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            if (FailOnSecond && Sent.Count == 1) throw new PrinterException("The printer ran out of labels.");
            Sent.Add(data);
            return Task.CompletedTask;
        }
    }

    private static (HubFixture F, Recorder R) Shop(bool withPrinter = true)
    {
        var recorder = new Recorder();
        var f = new HubFixture("IN", "retail", printer: recorder);
        if (withPrinter) f.App.PrinterProfiles.Save(new PrinterProfile { Name = "Labels", Role = PrinterRole.Label, Language = PrinterLanguage.Zpl, Connection = Connection.Network, Address = "10.0.0.30", LabelWidthMm = 50, LabelHeightMm = 30 });
        return (f, recorder);
    }

    private static Item Product(HubFixture f, string name, string barcode, bool track = true) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = name, Barcode = barcode, PriceMinor = 10_000, TaxClass = "standard", TrackStock = track });

    private static string Text(byte[] bytes) => Encoding.UTF8.GetString(bytes);

    [Fact]
    public async Task BC3_each_item_gets_its_own_number_of_labels_in_one_run()
    {
        var (f, r) = Shop();
        using (f)
        {
            var tea = Product(f, "Tea", "5901234123457");
            var rice = Product(f, "Rice", "4006381333931");

            var printed = await f.App.Printing.PrintLabelBatchAsync(new[] { (tea.Id, 3), (rice.Id, 2) });

            Assert.Equal(5, printed);   // 3 + 2: the older program's example, two rows with copies add up
            Assert.Equal(2, r.Sent.Count);
            Assert.Contains("^PQ3", Text(r.Sent[0]));
            Assert.Contains("Tea", Text(r.Sent[0]));
            Assert.Contains("^PQ2", Text(r.Sent[1]));
            Assert.Contains("^FD4006381333931^FS", Text(r.Sent[1]));
            Assert.Contains(f.App.Audit.Recent(), a => a.Action == "labels-printed" && a.Detail!.Contains("5 labels for 2 item(s)"));
        }
    }

    [Fact]
    public async Task BC4_nothing_chosen_is_refused_in_plain_words_and_prints_nothing()
    {
        var (f, r) = Shop();
        using (f)
        {
            var ex = await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintLabelBatchAsync(Array.Empty<(long, int)>()));

            Assert.Equal("nothing-chosen", ex.Code);
            Assert.Empty(r.Sent);
        }
    }

    [Fact]
    public async Task BC5_with_no_label_printer_set_up_it_says_where_to_add_one()
    {
        var (f, r) = Shop(withPrinter: false);
        using (f)
        {
            var tea = Product(f, "Tea", "5901234123457");

            var ex = await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintLabelBatchAsync(new[] { (tea.Id, 1) }));

            Assert.Equal("no-printer", ex.Code);
            Assert.Contains("Settings", ex.Message);
            Assert.Empty(r.Sent);
        }
    }

    [Fact]
    public async Task A_wrong_row_prints_nothing_at_all_because_everything_is_checked_first()
    {
        var (f, r) = Shop();
        using (f)
        {
            var tea = Product(f, "Tea", "5901234123457");

            Assert.Equal("copies", (await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintLabelBatchAsync(new[] { (tea.Id, 2), (tea.Id, 0) }))).Code);
            Assert.Equal("copies", (await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintLabelBatchAsync(new[] { (tea.Id, 501) }))).Code);
            Assert.Equal("item-not-found", (await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintLabelBatchAsync(new[] { (tea.Id, 1), (9_999L, 1) }))).Code);
            Assert.Empty(r.Sent);
        }
    }

    [Fact]
    public async Task If_the_printer_fails_part_way_the_message_names_the_item_and_says_how_many_were_printed()
    {
        var (f, r) = Shop();
        using (f)
        {
            r.FailOnSecond = true;
            var tea = Product(f, "Tea", "5901234123457");
            var rice = Product(f, "Rice", "4006381333931");

            var ex = await Assert.ThrowsAsync<HubException>(() => f.App.Printing.PrintLabelBatchAsync(new[] { (tea.Id, 3), (rice.Id, 2) }));

            Assert.Equal("printer-failed", ex.Code);
            Assert.Contains("Rice", ex.Message);
            Assert.Contains("3 labels were printed before this", ex.Message);
        }
    }

    [Fact]
    public void A_delivery_needs_one_label_for_each_unit_that_came_for_each_stocked_item_and_none_for_services()
    {
        var (f, _) = Shop();
        using (f)
        {
            var tea = Product(f, "Tea", "5901234123457");
            var loose = Product(f, "Loose rice", "4006381333931");
            var tape = f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Tape", PriceMinor = 10_000, TaxClass = "standard" });
            var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Mill Co" });
            var order = f.App.Purchasing.CreateOrder(supplier.Id, new[]
            {
                new NextGenOS.Hub.Purchasing.PurchaseLine { ItemId = tea.Id, QtyMilli = 12_000, CostMinor = 5_000 },
                new NextGenOS.Hub.Purchasing.PurchaseLine { ItemId = loose.Id, QtyMilli = 2_500, CostMinor = 4_000 },
                new NextGenOS.Hub.Purchasing.PurchaseLine { ItemId = tape.Id, QtyMilli = 5_000, CostMinor = 100 },
            });
            var received = f.App.Purchasing.Receive(order.Document.Id);

            var wishes = f.App.Printing.LabelsFor(received.Document.Id);

            Assert.Equal(new[] { ("Loose rice", 3), ("Tea", 12) }.OrderBy(x => x.Item1).ToArray(), wishes.Select(w => (w.Name, w.Copies)).OrderBy(x => x.Name).ToArray());   // 2.5 kg: 3 labels (rounded to the nearest whole)
        }
    }
}

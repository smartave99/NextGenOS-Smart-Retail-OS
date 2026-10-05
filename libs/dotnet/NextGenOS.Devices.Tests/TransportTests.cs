using System.Net;
using System.Net.Sockets;
using NextGenOS.Devices.Barcodes;
using NextGenOS.Devices.Printing;
using NextGenOS.Devices.Transport;

namespace NextGenOS.Devices.Tests;

public class TransportTests
{
    /// <summary>A stand-in network printer: it accepts one connection and keeps what it is sent.</summary>
    private sealed class FakePrinter : IDisposable
    {
        private readonly TcpListener _listener = new(IPAddress.Loopback, 0);
        public int Port => ((IPEndPoint)_listener.LocalEndpoint).Port;
        public Task<byte[]> Received { get; }

        public FakePrinter()
        {
            _listener.Start();
            Received = Task.Run(async () =>
            {
                using var client = await _listener.AcceptTcpClientAsync();
                using var memory = new MemoryStream();
                await client.GetStream().CopyToAsync(memory);
                return memory.ToArray();
            });
        }

        public void Dispose() => _listener.Stop();
    }

    [Fact]
    public async Task Bytes_reach_a_network_printer_whole()
    {
        using var printer = new FakePrinter();
        var data = Enumerable.Range(0, 5000).Select(i => (byte)(i % 251)).ToArray();
        await new TcpTransport("127.0.0.1", printer.Port).SendAsync(data);
        Assert.Equal(data, await printer.Received.WaitAsync(TimeSpan.FromSeconds(5)));
    }

    [Theory]
    [InlineData("192.168.1.50", "192.168.1.50", 9100)]
    [InlineData("192.168.1.50:9101", "192.168.1.50", 9101)]
    [InlineData(" printer.local ", "printer.local", 9100)]
    [InlineData("printer.local:abc", "printer.local:abc", 9100)]
    public void A_network_address_may_name_the_port(string address, string host, int port) => Assert.Equal((host, port), TcpTransport.Parse(address));

    [Fact]
    public async Task A_printer_that_is_off_gives_a_message_a_cashier_can_use()
    {
        var closed = new TcpListener(IPAddress.Loopback, 0);
        closed.Start();
        var port = ((IPEndPoint)closed.LocalEndpoint).Port;
        closed.Stop();
        var ex = await Assert.ThrowsAsync<PrinterException>(() => new TcpTransport("127.0.0.1", port, TimeSpan.FromSeconds(2)).SendAsync(new byte[] { 1 }));
        Assert.Contains("could not be reached", ex.Message);
        Assert.Contains("is on", ex.Message);
    }

    [Fact]
    public async Task A_device_file_gets_the_bytes_added_to_it()
    {
        var path = Path.Combine(Path.GetTempPath(), "printer-" + Guid.NewGuid().ToString("N"));
        try
        {
            var transport = new DeviceFileTransport(path);
            await transport.SendAsync(new byte[] { 1, 2, 3 });
            await transport.SendAsync(new byte[] { 4, 5 });
            Assert.Equal(new byte[] { 1, 2, 3, 4, 5 }, await File.ReadAllBytesAsync(path));
        }
        finally { File.Delete(path); }
        var ex = await Assert.ThrowsAsync<PrinterException>(() => new DeviceFileTransport("/no/such/folder/lp0").SendAsync(new byte[] { 1 }));
        Assert.Contains("could not be written to", ex.Message);
    }

    [Fact]
    public async Task The_system_print_service_gets_the_bytes_raw_through_lp()
    {
        if (OperatingSystem.IsWindows()) return;
        var folder = Path.Combine(Path.GetTempPath(), "cups-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(folder);
        try
        {
            var script = Path.Combine(folder, "lp");
            await File.WriteAllTextAsync(script, "#!/bin/sh\nprintf '%s\\n' \"$@\" > \"" + folder + "/args\"\ncat > \"" + folder + "/data\"\n");
            File.SetUnixFileMode(script, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);
            await new CupsTransport("Kitchen_Printer", script).SendAsync(new byte[] { 0x1B, 0x40, 65 });
            Assert.Equal(new byte[] { 0x1B, 0x40, 65 }, await File.ReadAllBytesAsync(Path.Combine(folder, "data")));
            Assert.Equal(new[] { "-d", "Kitchen_Printer", "-o", "raw" }, (await File.ReadAllTextAsync(Path.Combine(folder, "args"))).Split('\n', StringSplitOptions.RemoveEmptyEntries));
            var bad = Path.Combine(folder, "lp-fails");
            await File.WriteAllTextAsync(bad, "#!/bin/sh\necho 'printer is offline' >&2\nexit 1\n");
            File.SetUnixFileMode(bad, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);
            var ex = await Assert.ThrowsAsync<PrinterException>(() => new CupsTransport("X", bad).SendAsync(new byte[] { 1 }));
            Assert.Contains("printer is offline", ex.Message);
        }
        finally { Directory.Delete(folder, true); }
    }

    [Theory]
    [InlineData("-o evil")]
    [InlineData("a\nb")]
    public async Task A_queue_name_cannot_smuggle_options_into_the_print_command(string queue)
    {
        if (queue.StartsWith('-') is false && queue.Contains('\n') is false) return;
        await Assert.ThrowsAsync<PrinterException>(() => new CupsTransport(queue).SendAsync(new byte[] { 1 }));
    }

    [Fact]
    public async Task A_missing_print_service_is_said_plainly()
    {
        var ex = await Assert.ThrowsAsync<PrinterException>(() => new CupsTransport("X", "/no/such/lp").SendAsync(new byte[] { 1 }));
        Assert.Contains("no print service", ex.Message);
    }

    [Fact]
    public async Task Windows_printers_are_refused_off_Windows_with_a_plain_message()
    {
        if (OperatingSystem.IsWindows()) return;
        var ex = await Assert.ThrowsAsync<PrinterException>(() => new WindowsSpoolerTransport("EPSON TM-T20").SendAsync(new byte[] { 1 }));
        Assert.Contains("Windows computer", ex.Message);
        Assert.Empty(WindowsSpooler.ListPrinters());
    }

    // ---- profiles and the print service -----------------------------------------------------------------------------------------

    private static PrinterProfile Receipt(string address = "127.0.0.1:9100") => new() { Name = "Counter", Role = PrinterRole.Receipt, Connection = Connection.Network, Address = address, Columns = 32, PaperDots = 384 };

    private static PrinterProfile Label(PrinterLanguage language) => new() { Name = "Labels", Role = PrinterRole.Label, Language = language, Connection = Connection.Network, Address = "127.0.0.1", LabelWidthMm = 40, LabelHeightMm = 25 };

    [Fact]
    public void A_profile_that_is_not_ready_says_what_is_missing_in_plain_words()
    {
        Assert.Null(Receipt().Problem());
        Assert.Contains("name", new PrinterProfile { Address = "x" }.Problem());
        Assert.Contains("address", new PrinterProfile { Name = "A", Connection = Connection.Network }.Problem());
        Assert.Contains("port", new PrinterProfile { Name = "A", Connection = Connection.Serial }.Problem());
        Assert.Contains("ESC/POS", new PrinterProfile { Name = "A", Address = "x", Role = PrinterRole.Receipt, Language = PrinterLanguage.Zpl }.Problem());
        Assert.Contains("language of the label printer", new PrinterProfile { Name = "A", Address = "x", Role = PrinterRole.Label, Language = PrinterLanguage.EscPos }.Problem());
        Assert.Contains("label size", new PrinterProfile { Name = "A", Address = "x", Role = PrinterRole.Label, Language = PrinterLanguage.Zpl, LabelWidthMm = 5 }.Problem());
        Assert.Contains("how the printer is connected", new PrinterProfile { Name = "A", Address = "x", Connection = "carrier-pigeon" }.Problem());
    }

    [Fact]
    public async Task A_receipt_goes_to_the_printer_in_its_own_columns_with_a_cut()
    {
        using var printer = new FakePrinter();
        var profile = Receipt("127.0.0.1:" + printer.Port);
        var doc = new ReceiptDoc().Text("Corner Mart", Align.Center, true).Split("Rice", "425.00").Cut();
        await new PrintService().PrintReceiptAsync(profile, doc);
        var bytes = await printer.Received.WaitAsync(TimeSpan.FromSeconds(5));
        var text = System.Text.Encoding.Latin1.GetString(bytes);
        Assert.Contains("Corner Mart", text);
        Assert.Contains("Rice" + new string(' ', 32 - 4 - 6) + "425.00", text);
        Assert.Contains("\u001dVB", text);            // the cut
    }

    [Fact]
    public async Task A_printer_set_not_to_cut_does_not_cut_and_one_with_a_drawer_opens_it()
    {
        using var printer = new FakePrinter();
        var profile = Receipt("127.0.0.1:" + printer.Port);
        profile.Cut = false;
        profile.OpenDrawer = true;
        await new PrintService().PrintReceiptAsync(profile, new ReceiptDoc().Text("x").Cut());
        var text = System.Text.Encoding.Latin1.GetString(await printer.Received.WaitAsync(TimeSpan.FromSeconds(5)));
        Assert.DoesNotContain("\u001dV", text);
        Assert.Contains("\u001bp\0\u0019ú", text);
    }

    [Fact]
    public async Task Receipts_and_labels_are_not_mixed_up_between_the_two_kinds_of_printer()
    {
        var service = new PrintService(_ => throw new InvalidOperationException("nothing should be sent"));
        var a = await Assert.ThrowsAsync<PrinterException>(() => service.PrintReceiptAsync(Label(PrinterLanguage.Zpl), new ReceiptDoc()));
        Assert.Contains("label printer", a.Message);
        var b = await Assert.ThrowsAsync<PrinterException>(() => service.PrintLabelAsync(Receipt(), new LabelDoc()));
        Assert.Contains("receipt printer", b.Message);
    }

    [Theory]
    [InlineData(PrinterLanguage.Zpl, "^XA")]
    [InlineData(PrinterLanguage.Tspl, "SIZE 40 mm,25 mm")]
    [InlineData(PrinterLanguage.Epl, "q320")]
    [InlineData(PrinterLanguage.Cpcl, "PAGE-WIDTH 320")]
    public async Task A_label_goes_out_in_the_language_of_the_label_printer(PrinterLanguage language, string expected)
    {
        var sent = new List<byte[]>();
        var service = new PrintService(_ => new Recorder(sent));
        await service.PrintLabelAsync(Label(language), LabelTemplates.PriceTag("Tea", "120.00", "5901234123457", 40, 25));
        Assert.Contains(expected, System.Text.Encoding.Latin1.GetString(sent.Single()));
    }

    [Theory]
    [InlineData(PrinterRole.Receipt, "Printer test")]
    [InlineData(PrinterRole.Label, "Test label")]
    public async Task The_test_page_proves_the_printer_works(string role, string expected)
    {
        var sent = new List<byte[]>();
        var profile = role == PrinterRole.Receipt ? Receipt() : Label(PrinterLanguage.Zpl);
        await new PrintService(_ => new Recorder(sent)).PrintTestAsync(profile, "Corner Mart");
        Assert.Contains(expected, System.Text.Encoding.Latin1.GetString(sent.Single()));
    }

    [Fact]
    public async Task A_profile_with_a_problem_is_not_sent_anywhere()
    {
        var service = new PrintService(_ => throw new InvalidOperationException("nothing should be sent"));
        var ex = await Assert.ThrowsAsync<PrinterException>(() => service.PrintReceiptAsync(new PrinterProfile { Name = "", Address = "x" }, new ReceiptDoc()));
        Assert.Contains("name", ex.Message);
    }

    [Fact]
    public void Each_way_of_connecting_gets_its_own_transport()
    {
        Assert.IsType<TcpTransport>(PrinterTransports.For(new PrinterProfile { Connection = Connection.Network, Address = "1.2.3.4:9100" }));
        Assert.IsType<SerialTransport>(PrinterTransports.For(new PrinterProfile { Connection = Connection.Serial, Address = "COM4" }));
        Assert.IsType<DeviceFileTransport>(PrinterTransports.For(new PrinterProfile { Connection = Connection.Device, Address = "/dev/usb/lp0" }));
        Assert.IsType<CupsTransport>(PrinterTransports.For(new PrinterProfile { Connection = Connection.Queue, Address = "Office" }));
        Assert.IsType<WindowsSpoolerTransport>(PrinterTransports.For(new PrinterProfile { Connection = Connection.Spooler, Address = "EPSON TM-T20" }));
    }

    private sealed class Recorder(List<byte[]> sent) : IPrinterTransport
    {
        public Task SendAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            sent.Add(data);
            return Task.CompletedTask;
        }
    }

    // ---- barcode pictures ----------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(BarcodeKind.Ean13, "5901234123457")]
    [InlineData(BarcodeKind.Code128, "ABC-12345")]
    [InlineData(BarcodeKind.Ean8, "96385074")]
    [InlineData(BarcodeKind.Qr, "https://example.com/pay?x=1&y=2")]
    [InlineData(BarcodeKind.Qr, "Chai ₹80 — स्वागत")]
    public void A_barcode_picture_can_be_read_back(BarcodeKind kind, string text)
    {
        var png = BarcodeImages.Png(kind, text, 400, 140);
        var read = BarcodeImages.Read(png);
        Assert.NotNull(read);
        Assert.Equal(text, read!.Value.Text);
    }

    [Fact]
    public void A_picture_with_no_barcode_or_not_a_picture_gives_nothing()
    {
        Assert.Null(BarcodeImages.Read(new byte[] { 1, 2, 3, 4 }));
        Assert.Null(BarcodeImages.Read(Array.Empty<byte>()));
        using var blank = new SkiaSharp.SKBitmap(200, 200);
        using var image = SkiaSharp.SKImage.FromBitmap(blank);
        Assert.Null(BarcodeImages.Read(image.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100).ToArray()));
    }

    [Fact]
    public void A_number_that_cannot_be_that_barcode_is_refused_in_words()
    {
        var ex = Assert.Throws<ArgumentException>(() => BarcodeImages.Png(BarcodeKind.Ean13, "12AB", 200, 80));
        Assert.Contains("cannot be made into that kind of barcode", ex.Message);
    }
}

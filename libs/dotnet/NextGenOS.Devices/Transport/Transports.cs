using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using NextGenOS.Devices.Printing;

namespace NextGenOS.Devices.Transport;

/// <summary>Something that carries bytes to a printer.</summary>
public interface IPrinterTransport
{
    Task SendAsync(byte[] data, CancellationToken cancellationToken = default);
}

/// <summary>What went wrong reaching a printer, in words for the person at the till.</summary>
public sealed class PrinterException(string message, Exception? inner = null) : Exception(message, inner);

/// <summary>A printer on the network that takes its commands on a TCP port (9100 is the usual one).</summary>
public sealed class TcpTransport(string host, int port = 9100, TimeSpan? timeout = null) : IPrinterTransport
{
    private readonly TimeSpan _timeout = timeout ?? TimeSpan.FromSeconds(5);

    public static (string Host, int Port) Parse(string address)
    {
        var text = address.Trim();
        var colon = text.LastIndexOf(':');
        if (colon > 0 && !text.EndsWith(']') && int.TryParse(text[(colon + 1)..], out var p) && p is > 0 and < 65536) return (text[..colon], p);
        return (text, 9100);
    }

    public async Task SendAsync(byte[] data, CancellationToken cancellationToken = default)
    {
        using var client = new TcpClient();
        using var timer = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timer.CancelAfter(_timeout);
        try
        {
            await client.ConnectAsync(host, port, timer.Token).ConfigureAwait(false);
            var stream = client.GetStream();
            await stream.WriteAsync(data, timer.Token).ConfigureAwait(false);
            await stream.FlushAsync(timer.Token).ConfigureAwait(false);
            client.Client.Shutdown(SocketShutdown.Send);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            throw new PrinterException($"The printer at {host}:{port} did not answer. Check that it is on, and that its address is right.");
        }
        catch (SocketException ex)
        {
            throw new PrinterException($"The printer at {host}:{port} could not be reached ({ex.SocketErrorCode}). Check that it is on and on the same network.", ex);
        }
    }
}

/// <summary>A USB printer, a Bluetooth printer paired as a port, or a plain file: written to like a file.</summary>
public sealed class DeviceFileTransport(string path) : IPrinterTransport
{
    public async Task SendAsync(byte[] data, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite, 4096, FileOptions.WriteThrough);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.End);
            await stream.WriteAsync(data, cancellationToken).ConfigureAwait(false);
            await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or DirectoryNotFoundException)
        {
            throw new PrinterException($"The printer at {path} could not be written to. Check that it is plugged in and switched on{(ex is UnauthorizedAccessException ? ", and that this program may use it" : "")}.", ex);
        }
    }
}

/// <summary>A serial port (also a Bluetooth printer paired as a serial port, and USB-to-serial printers).</summary>
public sealed class SerialTransport(string port, int baud = 9600) : IPrinterTransport
{
    public Task SendAsync(byte[] data, CancellationToken cancellationToken = default) => Task.Run(() =>
    {
        try
        {
            using var serial = new System.IO.Ports.SerialPort(port, baud, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One)
            {
                Handshake = System.IO.Ports.Handshake.None, WriteTimeout = 10_000, ReadTimeout = 1000,
            };
            serial.Open();
            // Printers have small buffers: send in pieces so nothing is lost.
            for (var offset = 0; offset < data.Length; offset += 512)
            {
                cancellationToken.ThrowIfCancellationRequested();
                serial.Write(data, offset, Math.Min(512, data.Length - offset));
            }
            serial.BaseStream.Flush();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidOperationException or TimeoutException or ArgumentException)
        {
            throw new PrinterException($"The printer on {port} could not be reached. Check the cable or the Bluetooth pairing, and that the port is the right one.", ex);
        }
    }, cancellationToken);
}

/// <summary>A queue of the system's print service (CUPS on Linux and macOS), sent raw so the printer's own language gets through.</summary>
public sealed class CupsTransport(string queue, string command = "lp") : IPrinterTransport
{
    public async Task SendAsync(byte[] data, CancellationToken cancellationToken = default)
    {
        if (queue.StartsWith('-') || queue.Any(char.IsControl)) throw new PrinterException("That printer queue name is not valid.");
        var info = new ProcessStartInfo(command) { RedirectStandardInput = true, RedirectStandardError = true, RedirectStandardOutput = true, UseShellExecute = false };
        info.ArgumentList.Add("-d");
        info.ArgumentList.Add(queue);
        info.ArgumentList.Add("-o");
        info.ArgumentList.Add("raw");
        Process process;
        try { process = Process.Start(info) ?? throw new PrinterException("The print service could not be started."); }
        catch (Exception ex) when (ex is System.ComponentModel.Win32Exception or FileNotFoundException)
        {
            throw new PrinterException("This computer has no print service (CUPS) to send to.", ex);
        }
        using (process)
        {
            await process.StandardInput.BaseStream.WriteAsync(data, cancellationToken).ConfigureAwait(false);
            process.StandardInput.Close();
            var error = await process.StandardError.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
            await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
            if (process.ExitCode != 0) throw new PrinterException($"The printer \"{queue}\" refused the job. {error.Trim()}".Trim());
        }
    }
}

/// <summary>A printer installed in Windows. The bytes go to it untouched (a RAW job), so a receipt or label printer's own language works whatever its driver.</summary>
public sealed class WindowsSpoolerTransport(string printerName, string documentName = "Smart Retail POS") : IPrinterTransport
{
    public Task SendAsync(byte[] data, CancellationToken cancellationToken = default) => Task.Run(() =>
    {
        if (!OperatingSystem.IsWindows()) throw new PrinterException("Windows printers can only be used on a Windows computer.");
        WindowsSpooler.WriteRaw(printerName, documentName, data);
    }, cancellationToken);
}

/// <summary>The Windows print spooler (winspool.drv).</summary>
public static class WindowsSpooler
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct DocInfo1
    {
        [MarshalAs(UnmanagedType.LPWStr)] public string pDocName;
        [MarshalAs(UnmanagedType.LPWStr)] public string? pOutputFile;
        [MarshalAs(UnmanagedType.LPWStr)] public string pDataType;
    }

    [DllImport("winspool.drv", EntryPoint = "OpenPrinterW", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool OpenPrinter(string name, out IntPtr handle, IntPtr defaults);

    [DllImport("winspool.drv", SetLastError = true)]
    private static extern bool ClosePrinter(IntPtr handle);

    [DllImport("winspool.drv", EntryPoint = "StartDocPrinterW", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern int StartDocPrinter(IntPtr handle, int level, ref DocInfo1 info);

    [DllImport("winspool.drv", SetLastError = true)]
    private static extern bool EndDocPrinter(IntPtr handle);

    [DllImport("winspool.drv", SetLastError = true)]
    private static extern bool StartPagePrinter(IntPtr handle);

    [DllImport("winspool.drv", SetLastError = true)]
    private static extern bool EndPagePrinter(IntPtr handle);

    [DllImport("winspool.drv", SetLastError = true)]
    private static extern bool WritePrinter(IntPtr handle, byte[] bytes, int count, out int written);

    [DllImport("winspool.drv", EntryPoint = "EnumPrintersW", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool EnumPrinters(int flags, string? name, int level, IntPtr buffer, int size, out int needed, out int returned);

    public static void WriteRaw(string printerName, string documentName, byte[] data)
    {
        if (!OpenPrinter(printerName, out var handle, IntPtr.Zero)) throw new PrinterException($"The printer \"{printerName}\" was not found in Windows. Check its name.");
        try
        {
            var info = new DocInfo1 { pDocName = documentName, pOutputFile = null, pDataType = "RAW" };
            if (StartDocPrinter(handle, 1, ref info) == 0) throw new PrinterException($"Windows would not start a print job on \"{printerName}\".");
            try
            {
                if (!StartPagePrinter(handle)) throw new PrinterException($"Windows would not start a page on \"{printerName}\".");
                if (!WritePrinter(handle, data, data.Length, out var written) || written != data.Length) throw new PrinterException($"\"{printerName}\" did not take everything that was sent. Check that it is switched on and has paper.");
                EndPagePrinter(handle);
            }
            finally { EndDocPrinter(handle); }
        }
        finally { ClosePrinter(handle); }
    }

    /// <summary>The names of the printers installed in Windows (local and connected), as Windows shows them.</summary>
    public static IReadOnlyList<string> ListPrinters()
    {
        if (!OperatingSystem.IsWindows()) return Array.Empty<string>();
        const int local = 2, connections = 4, level4 = 4;
        EnumPrinters(local | connections, null, level4, IntPtr.Zero, 0, out var needed, out _);
        if (needed == 0) return Array.Empty<string>();
        var buffer = Marshal.AllocHGlobal(needed);
        try
        {
            if (!EnumPrinters(local | connections, null, level4, buffer, needed, out _, out var returned)) return Array.Empty<string>();
            var size = IntPtr.Size == 8 ? 24 : 12;           // PRINTER_INFO_4: name, server, attributes
            var names = new List<string>();
            for (var i = 0; i < returned; i++)
            {
                var name = Marshal.PtrToStringUni(Marshal.ReadIntPtr(buffer, i * size));
                if (!string.IsNullOrEmpty(name)) names.Add(name);
            }
            return names.OrderBy(n => n, StringComparer.CurrentCultureIgnoreCase).ToList();
        }
        finally { Marshal.FreeHGlobal(buffer); }
    }
}

public static class PrinterTransports
{
    /// <summary>The way of reaching a printer, made from its settings.</summary>
    public static IPrinterTransport For(PrinterProfile profile)
    {
        var address = profile.Address.Trim();
        switch (profile.Connection)
        {
            case Connection.Network:
                var (host, port) = TcpTransport.Parse(address);
                return new TcpTransport(host, port);
            case Connection.Serial: return new SerialTransport(address, profile.BaudRate);
            case Connection.Device: return new DeviceFileTransport(address);
            case Connection.Queue: return new CupsTransport(address);
            case Connection.Spooler: return new WindowsSpoolerTransport(address);
            default: throw new PrinterException("Please choose how the printer is connected.");
        }
    }

    /// <summary>What this PC can offer to connect to: serial and Bluetooth ports, system queues, Windows printers.</summary>
    public static IReadOnlyList<(string Connection, string Address, string Label)> Discover()
    {
        var found = new List<(string, string, string)>();
        try { foreach (var p in System.IO.Ports.SerialPort.GetPortNames().OrderBy(p => p, StringComparer.OrdinalIgnoreCase)) found.Add((Connection.Serial, p, "Port " + p)); }
        catch (Exception) { /* no ports on this computer */ }
        foreach (var p in WindowsSpooler.ListPrinters()) found.Add((Connection.Spooler, p, p + " (installed in Windows)"));
        if (!OperatingSystem.IsWindows())
        {
            try
            {
                var info = new ProcessStartInfo("lpstat") { RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false };
                info.ArgumentList.Add("-e");
                using var process = Process.Start(info);
                if (process is not null)
                {
                    var output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit(3000);
                    foreach (var q in output.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) found.Add((Connection.Queue, q, q + " (print queue)"));
                }
            }
            catch (Exception) { /* no print service */ }
            foreach (var lp in Directory.Exists("/dev/usb") ? Directory.GetFiles("/dev/usb", "lp*") : Array.Empty<string>()) found.Add((Connection.Device, lp, lp + " (USB printer)"));
        }
        return found;
    }
}

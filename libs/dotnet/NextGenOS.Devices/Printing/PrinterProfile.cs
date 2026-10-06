namespace NextGenOS.Devices.Printing;

public enum PrinterLanguage { EscPos, Zpl, Tspl, Epl, Cpcl }

/// <summary>How a printer is reached.</summary>
public static class Connection
{
    /// <summary>A printer on the network: "192.168.1.50" or "192.168.1.50:9100".</summary>
    public const string Network = "network";
    /// <summary>A serial or Bluetooth (serial profile) port: "COM4", "/dev/rfcomm0", "/dev/ttyUSB0".</summary>
    public const string Serial = "serial";
    /// <summary>A device file of a USB printer: "/dev/usb/lp0", "\\.\USB001", or any file path.</summary>
    public const string Device = "device";
    /// <summary>A print queue of the system (CUPS on Linux and macOS): the queue name.</summary>
    public const string Queue = "queue";
    /// <summary>A printer installed in Windows, sent raw: the printer's name as Windows shows it.</summary>
    public const string Spooler = "spooler";

    public static readonly string[] All = { Network, Serial, Device, Queue, Spooler };
}

public static class PrinterRole
{
    public const string Receipt = "receipt";
    public const string Label = "label";
    public const string Kitchen = "kitchen";
}

/// <summary>One printer the shop has: what it is for, the language it speaks, how to reach it and the size of its paper.</summary>
public sealed class PrinterProfile
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N")[..8];
    public string Name { get; set; } = "";
    public string Role { get; set; } = PrinterRole.Receipt;
    public PrinterLanguage Language { get; set; } = PrinterLanguage.EscPos;
    public string Connection { get; set; } = Printing.Connection.Network;
    public string Address { get; set; } = "";
    public int BaudRate { get; set; } = 9600;
    /// <summary>Receipt paper: characters per line (32 for 58 mm paper, 42 or 48 for 80 mm).</summary>
    public int Columns { get; set; } = 42;
    public int PaperDots { get; set; } = 576;
    public PrinterCodePage CodePage { get; set; } = PrinterCodePage.Pc858;
    public bool Cut { get; set; } = true;
    /// <summary>Kick the cash drawer (connected to the printer) after a receipt.</summary>
    public bool OpenDrawer { get; set; }
    /// <summary>Print every finished bill by itself, without pressing Print.</summary>
    public bool AutoPrint { get; set; }
    /// <summary>Kitchen printers: the station they print (Kitchen, Bar); empty means all.</summary>
    public string? Station { get; set; }
    public double LabelWidthMm { get; set; } = 50;
    public double LabelHeightMm { get; set; } = 30;
    public double LabelGapMm { get; set; } = 3;
    public int Dpi { get; set; } = 203;

    /// <summary>Why this profile cannot be used yet, in plain words; null when it is complete.</summary>
    public string? Problem()
    {
        if (string.IsNullOrWhiteSpace(Name)) return "Please give the printer a name.";
        if (!Printing.Connection.All.Contains(Connection)) return "Please choose how the printer is connected.";
        if (string.IsNullOrWhiteSpace(Address)) return Connection switch
        {
            Printing.Connection.Network => "Please type the printer's address on the network, like 192.168.1.50.",
            Printing.Connection.Serial => "Please choose the port the printer is on, like COM4.",
            Printing.Connection.Spooler => "Please choose the printer.",
            _ => "Please say where the printer is.",
        };
        if (Role is not (PrinterRole.Receipt or PrinterRole.Label or PrinterRole.Kitchen)) return "Please say what the printer is for.";
        if (Role != PrinterRole.Label && Language != PrinterLanguage.EscPos) return "Receipt and kitchen printers use the ESC/POS language.";
        if (Role == PrinterRole.Label && Language == PrinterLanguage.EscPos) return "Please choose the language of the label printer (ZPL, TSPL, EPL or CPCL).";
        if (Columns is < 16 or > 80) return "The paper should be between 16 and 80 characters wide.";
        if (LabelWidthMm is < 10 or > 200 || LabelHeightMm is < 10 or > 300) return "The label size looks wrong: give it in millimetres, like 50 by 30.";
        return null;
    }
}

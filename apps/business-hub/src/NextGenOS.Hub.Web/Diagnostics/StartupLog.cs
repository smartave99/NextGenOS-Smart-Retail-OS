using System.Text;

namespace NextGenOS.Hub.Web.Diagnostics;

/// <summary>
/// A small plain-text note of how the program started, or why it could not: kept where anyone using this PC can read it
/// (<c>C:\ProgramData\NextGenOS\Logs\hub-start.txt</c>; the setup makes the folder readable). When the shop program does not open, the icon's launcher and the setup put this note
/// into the note they show the person, so that the reason is written down and nobody has to guess. It holds the program's version, the PC's system, the places the program uses and
/// the error text: never a sale, a customer, a password or a licence key. Writing never stops the program: if the note cannot be written, nothing happens.
/// </summary>
public static class StartupLog
{
    public const string FileName = "hub-start.txt";
    public const int MaxBytes = 64 * 1024;
    private static readonly object Gate = new();

    /// <summary>Where the note is kept: the PC's shared program-data folder on Windows (so every account can read it), nowhere on other systems (they have their own logs).</summary>
    public static string? DefaultFolder => OperatingSystem.IsWindows() ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "NextGenOS", "Logs") : null;

    /// <summary>Adds a line with the time in front. A file that has grown past <see cref="MaxBytes"/> keeps only its newest half first.</summary>
    public static void Write(string text, string? folder = null)
    {
        try
        {
            folder ??= DefaultFolder;
            if (folder is null) return;
            lock (Gate)
            {
                Directory.CreateDirectory(folder);
                var file = Path.Combine(folder, FileName);
                Trim(file);
                var line = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss zzz", System.Globalization.CultureInfo.InvariantCulture) + "  " + text.Replace("\r\n", "\n").Replace("\n", "\r\n    ") + "\r\n";
                File.AppendAllText(file, line, new UTF8Encoding(false));
            }
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or System.Security.SecurityException or ArgumentException or NotSupportedException)
        {
            // The note is a help; the program goes on without it.
        }
    }

    /// <summary>The first line of a start: which program, which system, who runs it and where, so that a note read later says what it is about.</summary>
    public static void Begin(string? folder = null)
    {
        var version = typeof(StartupLog).Assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyInformationalVersionAttribute), false)
            .OfType<System.Reflection.AssemblyInformationalVersionAttribute>().FirstOrDefault()?.InformationalVersion ?? "unknown";
        var plus = version.IndexOf('+');
        Write($"Starting Smart Retail POS {(plus > 0 ? version[..plus] : version)} on {System.Runtime.InteropServices.RuntimeInformation.OSDescription} ({System.Runtime.InteropServices.RuntimeInformation.OSArchitecture}), " +
              $"account {Environment.UserDomainName}\\{Environment.UserName}, program folder {AppContext.BaseDirectory}", folder);
        AppDomain.CurrentDomain.UnhandledException += (_, e) => Write("The program stopped because of an error that nothing caught: " + e.ExceptionObject, folder);
    }

    private static void Trim(string file)
    {
        var info = new FileInfo(file);
        if (!info.Exists || info.Length <= MaxBytes) return;
        var text = File.ReadAllText(file, Encoding.UTF8);
        var keep = text[(text.Length / 2)..];
        var firstLine = keep.IndexOf('\n');
        File.WriteAllText(file, "(older lines left out)\r\n" + (firstLine >= 0 ? keep[(firstLine + 1)..] : keep), new UTF8Encoding(false));
    }
}

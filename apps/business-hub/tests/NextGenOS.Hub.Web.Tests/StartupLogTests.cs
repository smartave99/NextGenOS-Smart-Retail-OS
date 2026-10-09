using NextGenOS.Hub.Web.Diagnostics;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The note of how the program started: when the shop program does not open, the icon and the setup show it, so it must be written, kept small, and never stop the program.</summary>
public class StartupLogTests : IDisposable
{
    private readonly string folder = Path.Combine(Path.GetTempPath(), "hub-startlog-" + Guid.NewGuid().ToString("N"));

    public void Dispose()
    {
        try { Directory.Delete(folder, true); } catch (IOException) { }
    }

    private string Text() => File.ReadAllText(Path.Combine(folder, StartupLog.FileName));

    [Fact]
    public void A_line_is_added_with_the_time_in_front_and_a_second_line_after_it()
    {
        StartupLog.Write("Ready. It answers at http://127.0.0.1:5280.", folder);
        StartupLog.Write("Stopping.", folder);
        var lines = Text().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        Assert.Equal(2, lines.Length);
        Assert.Matches(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2} [+-]\d{2}:\d{2}  Ready\. It answers at http://127\.0\.0\.1:5280\.$", lines[0]);
        Assert.EndsWith("Stopping.", lines[1]);
    }

    [Fact]
    public void An_error_with_many_lines_stays_together_under_its_time()
    {
        StartupLog.Write("The program could not start: System.Net.Sockets.SocketException (10013)\n   at Kestrel.Bind()\n   at Host.Start()", folder);
        var text = Text();
        Assert.Contains("SocketException (10013)", text);
        Assert.Contains("\r\n       at Kestrel.Bind()", text);   // the next lines are pushed in, so a new time always starts a new event
    }

    [Fact]
    public void A_note_that_grows_too_big_keeps_the_newest_lines_and_says_it_left_older_ones_out()
    {
        for (var i = 0; i < 3000; i++) StartupLog.Write("line number " + i + " " + new string('x', 40), folder);
        var info = new FileInfo(Path.Combine(folder, StartupLog.FileName));
        Assert.True(info.Length < StartupLog.MaxBytes + 4096, "the note stays small: " + info.Length);
        var text = Text();
        Assert.Contains("line number 2999", text);
        Assert.DoesNotContain("line number 0 ", text);
        Assert.StartsWith("(older lines left out)", text);
    }

    [Fact]
    public void A_place_that_cannot_be_written_never_stops_the_program()
    {
        var file = Path.Combine(folder, "in-the-way");
        Directory.CreateDirectory(folder);
        File.WriteAllText(file, "a file where a folder is wanted");
        StartupLog.Write("this goes nowhere", Path.Combine(file, "Logs"));      // the folder cannot be made: no exception
        StartupLog.Write("this goes nowhere", "\0not a path");
        Assert.True(true);
    }

    [Fact]
    public void The_first_line_says_which_program_and_system_it_is_about_and_holds_nothing_of_the_shop()
    {
        StartupLog.Begin(folder);
        var text = Text();
        Assert.Contains("Starting Smart Retail POS", text);
        Assert.Contains(AppContext.BaseDirectory, text);
        foreach (var never in new[] { "password", "licence key", "token" }) Assert.DoesNotContain(never, text, StringComparison.OrdinalIgnoreCase);
    }
}

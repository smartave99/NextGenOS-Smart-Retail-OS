using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using NextGenOS.Hub.Diagnostics;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Diagnostics;

/// <summary>
/// Makes the Help button's support file (the owner's decision 18 in <c>docs/PLATFORM-DECISIONS.md</c>): what the program is and where it runs, how the licence stands, how the shop's data, copies, counter
/// PCs and AI helpers stand (<see cref="SupportService"/>), and what went wrong lately, with every personal detail taken out. It is text the owner reads and sends, or does not send. It holds no
/// sales, no customers, no staff names, no amounts, no passwords and no keys.
/// </summary>
public sealed class SupportFileBuilder(HubApp app, ProductLicence licence, BrandService brand, TroubleLog trouble)
{
    private static readonly DateTimeOffset Started = DateTimeOffset.UtcNow;

    /// <summary>Who to send it to, if the licence or the owner's own brand names a person (the supplier's contact is theirs to set; nothing is built in).</summary>
    public string? SendTo
    {
        get
        {
            var parts = new[] { brand.SupportEmail, brand.SupportPhone }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            return parts.Count == 0 ? null : string.Join(" or ", parts);
        }
    }

    public string Build(string? message)
    {
        var at = app.Clock.UtcNow;
        var people = new NextGenOS.Hub.Ai.PersonalValues(app.Db).Known();
        var sections = new List<SupportSection>
        {
            Program(at),
            Licence(),
        };
        sections.AddRange(app.Support.Sections());
        sections.Add(Trouble(people));
        app.Audit.Log(app.Access.CurrentUserId, "support.made", "support", null, "A support file was made (nothing was sent).");
        return SupportService.Render(brand.Name, at, message, sections, people);
    }

    private static SupportSection Program(DateTimeOffset at)
    {
        var version = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown";
        var up = at - Started;
        return new SupportSection("The program", [
            "Version: " + version.Split('+')[0],
            "Runs on: " + RuntimeInformation.OSDescription + ", " + RuntimeInformation.OSArchitecture + "; " + RuntimeInformation.FrameworkDescription + ".",
            "Running for: " + (up.TotalDays >= 1 ? (int)up.TotalDays + " day(s) " : "") + up.Hours + " hour(s) " + up.Minutes + " minute(s).",
            "Memory in use by the program: " + Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024 + " MB.",
            "Time zone of this PC: UTC" + (TimeZoneInfo.Local.GetUtcOffset(at) >= TimeSpan.Zero ? "+" : "-") + TimeZoneInfo.Local.GetUtcOffset(at).ToString("hh\\:mm", CultureInfo.InvariantCulture) + ".",
        ]);
    }

    /// <summary>A name or number from the signed licence (not private, and support needs it as it is) when it is short and plain; anything else is not shown.</summary>
    private static string Plain(string? value) => value is { Length: > 0 and <= 40 } v && v.All(c => char.IsAsciiLetterOrDigit(c) || c is '.' or '-' or '_') ? v : "(not shown)";

    private SupportSection Licence()
    {
        var state = licence.State;
        var claims = state.Licence;
        var lines = new List<string> { "State: " + state.Status + (state.Banner is { } banner ? " (" + SupportRedaction.Clean(banner, null, 200) + ")" : "") + "." };
        if (claims is not null)
        {
            lines.Add("Licence number: " + Plain(claims.LicenceId) + ", kind: " + (claims.Trial ? "trial" : "paid") + ", edition: " + Plain(claims.Edition) + ".");
            lines.Add("Ends: " + (state.ExpiresUtc is { } end ? end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + (claims.KeepsWorkingAfterEnd ? " (keeps working after, with a banner)" : "") : "no end date") + ".");
            lines.Add("Parts included: " + (claims.Modules is { Count: > 0 } ? string.Join(", ", claims.Modules.Select(Plain)) : "none") + ".");
            lines.Add("PCs allowed: " + (claims.Limits?.Devices > 0 ? claims.Limits.Devices.ToString(CultureInfo.InvariantCulture) : "not limited") + ".");
        }

        if (state.GraceDaysLeft > 0) lines.Add("Days left before this PC must check in: " + state.GraceDaysLeft + ".");
        return new SupportSection("Your licence", lines);
    }

    private SupportSection Trouble(IReadOnlyCollection<string> people)
    {
        var recent = trouble.Recent(25);
        if (recent.Count == 0) return new SupportSection("Problems noticed since the program started", ["None."]);
        var lines = new List<string>();
        foreach (var e in recent)
        {
            var line = e.At.UtcDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) + " " + e.Level + " in " + SupportRedaction.Clean(e.Category, people, 80) + ": " + SupportRedaction.Clean(e.Message, people, 250);
            if (e.ExceptionType is not null) line += " [" + e.ExceptionType + (e.ExceptionMessage is null ? "" : ": " + SupportRedaction.Clean(e.ExceptionMessage, people, 200)) + (e.Where.Count == 0 ? "" : "; at " + string.Join(" < ", e.Where.Select(w => SupportRedaction.Clean(w, null, 100)))) + "]";
            lines.Add(line);
        }

        return new SupportSection("Problems noticed since the program started (newest first)", lines);
    }
}

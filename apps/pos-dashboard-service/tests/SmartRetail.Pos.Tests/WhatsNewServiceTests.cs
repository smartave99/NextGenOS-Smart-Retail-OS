using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public sealed class WhatsNewServiceTests : IDisposable
{
    private const string Log = """
        # Change log

        ## 2.14.0 · 10 October 2026
        The next one.
        ### New
        - Newer.

        ## 2.13.0 · 3 October 2026
        This one.
        ### New
        - Now.

        ## 2.12.0 · 1 October 2026
        ### Fixed
        - Before.
        """;

    private readonly string _folder = Directory.CreateTempSubdirectory("whats-new-").FullName;

    public void Dispose() => Directory.Delete(_folder, recursive: true);

    private string State => Path.Combine(_folder, WhatsNewService.FileName);

    private WhatsNewService Service(string current, string? state = null) =>
        new(Log, current, state ?? State, NullLogger<WhatsNewService>.Instance);

    [Fact]
    public void A_version_nobody_has_looked_at_is_unseen_until_its_entry_is_opened()
    {
        var service = Service("2.13.0");

        Assert.Equal("2.13.0", service.Current!.Version);
        Assert.True(service.HasUnseen);
        Assert.Equal(new[] { "2.13.0" }, service.UnseenReleases.Select(r => r.Version));
        Assert.Equal(new[] { "2.14.0", "2.13.0", "2.12.0" }, service.Releases.Select(r => r.Version));

        var changed = 0;
        service.Changed += () => changed++;
        service.MarkSeen();
        service.MarkSeen();

        Assert.False(service.HasUnseen);
        Assert.Equal("2.13.0", service.Seen);
        Assert.Equal(1, changed);
        Assert.Equal("2.13.0", JsonDocument.Parse(File.ReadAllText(State)).RootElement.GetProperty("Seen").GetString());
        Assert.False(File.Exists(State + ".tmp"));
    }

    [Fact]
    public void What_was_seen_is_kept_for_the_next_start_and_an_update_brings_the_dot_back()
    {
        Service("2.13.0").MarkSeen();

        var again = Service("2.13.0");
        Assert.False(again.HasUnseen);
        Assert.Empty(again.UnseenReleases);

        // The owner updates to 2.14.0: only what came after the one last seen is new.
        var updated = Service("2.14.0");
        Assert.True(updated.HasUnseen);
        Assert.Equal(new[] { "2.14.0" }, updated.UnseenReleases.Select(r => r.Version));
        updated.MarkSeen();
        Assert.False(Service("2.14.0").HasUnseen);
    }

    [Fact]
    public void An_update_that_skipped_versions_marks_every_one_since_the_last_seen_as_new()
    {
        File.WriteAllText(State, "{\"Seen\":\"2.12.0\"}");

        var service = Service("2.14.0");

        Assert.True(service.HasUnseen);
        Assert.Equal(new[] { "2.14.0", "2.13.0" }, service.UnseenReleases.Select(r => r.Version));
    }

    [Fact]
    public void A_copy_whose_version_the_log_does_not_know_shows_nothing_and_writes_nothing()
    {
        var service = Service("9.9.9");

        Assert.Null(service.Current);
        Assert.False(service.HasUnseen);
        Assert.Empty(service.UnseenReleases);
        service.MarkSeen();
        Assert.False(File.Exists(State));

        var noLog = new WhatsNewService("", "2.13.0", State, NullLogger<WhatsNewService>.Instance);
        Assert.Empty(noLog.Releases);
        Assert.False(noLog.HasUnseen);
    }

    [Theory]
    [InlineData("{not json")]
    [InlineData("{\"Seen\":\"abc\"}")]
    [InlineData("{\"Seen\":null}")]
    [InlineData("[]")]
    [InlineData("")]
    public void A_damaged_file_counts_as_not_seen_and_is_written_again(string content)
    {
        File.WriteAllText(State, content);

        var service = Service("2.13.0");

        Assert.True(service.HasUnseen);
        Assert.Equal("", service.Seen);
        service.MarkSeen();
        Assert.False(Service("2.13.0").HasUnseen);
    }

    [Fact]
    public void A_file_that_cannot_be_written_never_stops_the_screen()
    {
        // The folder for the file is a file, so it cannot be made.
        var blocker = Path.Combine(_folder, "blocker");
        File.WriteAllText(blocker, "x");
        var service = Service("2.13.0", Path.Combine(blocker, "inside", WhatsNewService.FileName));

        service.MarkSeen();

        Assert.False(service.HasUnseen);
    }

    [Fact]
    public void The_log_built_into_the_dashboard_is_the_projects_and_its_newest_entry_is_this_version()
    {
        var options = Microsoft.Extensions.Options.Options.Create(new AiOptions { SettingsFile = Path.Combine(_folder, "settings.json") });

        var service = new WhatsNewService(options, NullLogger<WhatsNewService>.Instance);

        Assert.True(service.Releases.Count >= 24);
        Assert.Equal(service.Releases[0].Version, service.CurrentVersion);
        Assert.NotNull(service.Current);
        Assert.True(service.HasUnseen);
        service.MarkSeen();
        Assert.True(File.Exists(Path.Combine(_folder, WhatsNewService.FileName)), "what was seen is kept beside the settings");
    }
}

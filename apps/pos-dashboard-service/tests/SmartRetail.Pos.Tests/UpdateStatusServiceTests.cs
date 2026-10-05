using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Updates;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>The dashboard shows what the Windows app found when it looked for a newer version, and nothing else.</summary>
public sealed class UpdateStatusServiceTests : IDisposable
{
    private readonly string _folder = Path.Combine(Path.GetTempPath(), "srpos-updates-" + Guid.NewGuid().ToString("N"));
    private int _written;

    public void Dispose()
    {
        if (Directory.Exists(_folder))
        {
            Directory.Delete(_folder, recursive: true);
        }
    }

    private UpdateStatusService Service() => new(Options.Create(new UpdateOptions { Folder = _folder }), NullLogger<UpdateStatusService>.Instance);

    private void Write(string json)
    {
        Directory.CreateDirectory(_folder);
        var path = Path.Combine(_folder, UpdateFolder.StatusFileName);
        File.WriteAllText(path, json);
        // Every write counts as a new one, whatever the file system's clock does.
        File.SetLastWriteTimeUtc(path, new DateTime(2026, 9, 29, 12, 0, 0, DateTimeKind.Utc).AddMinutes(++_written));
    }

    [Fact]
    public void Nothing_written_yet_is_no_check_yet_and_nothing_is_ready()
    {
        using var service = Service();

        Assert.Equal(UpdateState.Unknown, service.Status.State);
        Assert.Null(service.Ready);
        Assert.False(Directory.Exists(_folder), "the dashboard never makes the app's folder");
    }

    [Fact]
    public void A_ready_update_is_shown_with_its_version_and_what_is_new_and_a_new_check_replaces_it()
    {
        Write("""{"State":"Ready","Current":"2.9.0","Available":"2.10.0","File":"SmartRetailAI-Setup-2.10.0.exe","Notes":"Faster posters."}""");
        using var service = Service();
        var changes = 0;
        service.Changed += () => changes++;

        Assert.Equal(("2.10.0", "Faster posters.", "2.9.0"), (service.Ready, service.Status.Notes, service.Status.Current));

        Write("""{"State":"UpToDate","Current":"2.10.0"}""");
        service.Refresh();
        Assert.Null(service.Ready);
        Assert.Equal((UpdateState.UpToDate, 1), (service.Status.State, changes));

        // Nothing written since: nothing read, nothing announced.
        service.Refresh();
        Assert.Equal(1, changes);
    }

    [Theory]
    [InlineData("""{"State":"Ready","Available":"2.10"}""")]
    [InlineData("""{"State":"Ready","Available":"latest <b>"}""")]
    [InlineData("""{"State":"Ready","Available":null}""")]
    [InlineData("""{"State":"UpToDate","Available":"2.10.0"}""")]
    [InlineData("""{"State":"Failed","Available":"2.10.0"}""")]
    public void Only_a_ready_status_with_a_version_written_the_way_the_release_writes_it_counts_as_ready(string json)
    {
        Write(json);
        using var service = Service();

        Assert.Null(service.Ready);
    }

    [Theory]
    [InlineData("")]
    [InlineData("not json")]
    [InlineData("[1, 2]")]
    [InlineData("""{"State":"Exploded"}""")]
    [InlineData("""{"State":"Ready","Notes":null,"Problem":null,"Current":null,"Available":"2.10.0"}""")]
    public void A_status_file_edited_by_hand_or_damaged_never_breaks_the_page(string json)
    {
        Write(json);
        using var service = Service();

        var status = service.Status;
        Assert.NotNull(status.Notes);
        Assert.NotNull(status.Problem);
        Assert.NotNull(status.Current);
        Assert.NotNull(status.Available);
    }

    [Fact]
    public void A_folder_that_appears_later_is_read_when_the_app_writes_to_it()
    {
        using var service = Service();
        Assert.Equal(UpdateState.Unknown, service.Status.State);
        var changed = new ManualResetEventSlim();
        service.Changed += changed.Set;

        Write("""{"State":"Failed","Problem":"The update folder could not be reached."}""");
        service.Refresh();

        Assert.True(changed.IsSet);
        Assert.Equal(("The update folder could not be reached.", UpdateState.Failed), (service.Status.Problem, service.Status.State));
    }
}

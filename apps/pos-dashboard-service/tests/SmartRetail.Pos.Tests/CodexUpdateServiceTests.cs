using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>The dashboard looks at Codex now and then, updates it at a quiet moment unless the owner said not to, and says what happened.</summary>
public sealed class CodexUpdateServiceTests : IDisposable
{
    private readonly string _folder = Path.Combine(Path.GetTempPath(), "srpos-codexupdate-" + Guid.NewGuid().ToString("N"));
    private readonly AiRunGate _gate = new();
    private DateTime _now = new(2026, 9, 29, 12, 0, 0);

    public CodexUpdateServiceTests() => Directory.CreateDirectory(_folder);

    public void Dispose() => Directory.Delete(_folder, recursive: true);

    private static string Top() => "Commands:\n  exec\n  login\n  app-server\n\nOptions:\n      --search\n";

    private static string Exec() => string.Concat(new[] { "--image", "--skip-git-repo-check", "--ephemeral", "--sandbox", "--color", "--cd", "--output-last-message", "--output-schema", "--model", "--config", "--enable" }
        .Select(flag => "      " + flag + " <X>\n"));

    private static string Login() => "Commands:\n  status\n\nOptions:\n      --device-auth\n      --with-api-key\n";

    private sealed class Tool : ICodexTool
    {
        public string Printed = "codex-cli 0.158.0";
        public bool Managed = true;
        public Exception? Breaks;
        public Action? DuringInstall;
        public readonly List<string> Installs = new();

        public Task<string> VersionAsync(CancellationToken cancellationToken) => Breaks is null ? Task.FromResult(Printed) : Task.FromException<string>(Breaks);

        public Task<CodexHelp> HelpAsync(CancellationToken cancellationToken) => Task.FromResult(new CodexHelp(Top(), Exec(), Login()));

        public Task<bool?> SignedInAsync(CancellationToken cancellationToken) => Task.FromResult<bool?>(true);

        public bool IsInstallerManaged() => Managed;

        public async Task InstallAsync(string release, Action<string> progress, CancellationToken cancellationToken)
        {
            Installs.Add(release);
            progress?.Invoke("Downloading Codex CLI");
            DuringInstall?.Invoke();
            await Task.Yield();
            Printed = "codex-cli 0.159.0";
        }
    }

    private sealed class Releases : ICodexReleases
    {
        public Version? Latest = new(0, 159, 0);

        public Task<Version> LatestAsync(CancellationToken cancellationToken) => Task.FromResult(Latest!);
    }

    private (CodexUpdateService Service, Tool Tool, Releases Releases, string ReleasesFolder) Make()
    {
        var tool = new Tool();
        var releases = new Releases();
        var releasesFolder = Path.Combine(_folder, "releases");
        var updater = new CodexUpdater(tool, releases, _gate, new CodexUpdateFile(_folder), () => _now);
        return (new CodexUpdateService(updater, new CodexUpdateOptions(), NullLogger<CodexUpdateService>.Instance, () => releasesFolder), tool, releases, releasesFolder);
    }

    [Fact]
    public async Task By_default_a_newer_release_settles_for_a_day_and_is_then_installed_by_itself()
    {
        var (service, tool, _, _) = Make();
        Assert.True(service.State.Automatic);

        var first = await service.RunScheduledAsync(CancellationToken.None);
        Assert.Equal(CodexUpdateOutcome.Settling, first.Outcome);
        Assert.Empty(tool.Installs);

        _now += CodexUpdater.Settle + TimeSpan.FromMinutes(1);
        var second = await service.RunScheduledAsync(CancellationToken.None);

        Assert.Equal((CodexUpdateOutcome.Updated, "0.159.0", "0.158.0"), (second.Outcome, second.Installed, second.Previous));
        Assert.Equal(new[] { "" }, tool.Installs);
        Assert.Same(second, service.Last);
        Assert.Null(service.NeedsYou);
        Assert.False(service.IsBusy);
        Assert.False(_gate.IsClosed);
    }

    [Fact]
    public async Task With_automatic_updates_off_it_only_looks_and_tells_the_bell_that_a_newer_codex_is_out()
    {
        var (service, tool, _, _) = Make();
        service.SetAutomatic(false);
        _now += TimeSpan.FromDays(3);

        var result = await service.RunScheduledAsync(CancellationToken.None);

        Assert.Equal(CodexUpdateOutcome.Available, result.Outcome);
        Assert.Empty(tool.Installs);
        Assert.Equal(("Codex 0.159.0 is out", "Automatic updates are off. Update it in Settings."), service.NeedsYou);

        // The owner turns it back on: nothing needs them any more.
        service.SetAutomatic(true);
        Assert.Null(service.NeedsYou);
    }

    [Fact]
    public async Task The_owner_can_update_at_once_and_the_page_hears_of_each_step()
    {
        var (service, tool, _, _) = Make();
        var doings = new List<string>();
        var lines = new List<string>();
        service.Changed += () =>
        {
            doings.Add(service.Doing);
            lines.Add(service.Progress);
        };
        tool.DuringInstall = () =>
        {
            Assert.True(service.IsBusy);
            Assert.True(_gate.IsClosed, "AI tasks wait while Codex is replaced");
        };

        var result = await service.UpdateAsync(ownerAsked: true, CancellationToken.None);

        Assert.Equal(CodexUpdateOutcome.Updated, result.Outcome);
        Assert.Equal("Looking for a newer Codex…", doings.First());
        Assert.Contains(CodexUpdateService.Updating, doings);
        Assert.True(doings.IndexOf(CodexUpdateService.Updating) < lines.IndexOf("Downloading Codex CLI"), "it says it is updating before the installer speaks");
        Assert.Contains("Downloading Codex CLI", lines);
        Assert.Equal("", doings.Last());
        Assert.False(service.IsBusy);
    }

    [Fact]
    public async Task A_scheduled_look_with_nothing_to_install_never_says_it_is_updating()
    {
        var (service, tool, _, _) = Make();
        tool.Printed = "codex-cli 0.159.0";
        var doings = new List<string>();
        service.Changed += () => doings.Add(service.Doing);

        var result = await service.RunScheduledAsync(CancellationToken.None);

        Assert.Equal(CodexUpdateOutcome.UpToDate, result.Outcome);
        Assert.DoesNotContain(CodexUpdateService.Updating, doings);
        Assert.Contains("Looking for a newer Codex…", doings);

        // A release still settling is only looked at as well.
        tool.Printed = "codex-cli 0.158.0";
        doings.Clear();
        Assert.Equal(CodexUpdateOutcome.Settling, (await service.RunScheduledAsync(CancellationToken.None)).Outcome);
        Assert.DoesNotContain(CodexUpdateService.Updating, doings);
    }

    [Fact]
    public async Task While_one_look_goes_on_another_is_not_started()
    {
        var (service, tool, _, _) = Make();
        var second = (CodexUpdateResult?)null;
        tool.DuringInstall = () => second = service.CheckAsync(CancellationToken.None).GetAwaiter().GetResult();

        await service.UpdateAsync(ownerAsked: true, CancellationToken.None);

        Assert.Equal(CodexUpdateOutcome.Waiting, second!.Outcome);
        Assert.Equal("Codex is being looked at now.", second.Message);
        Assert.Equal(new[] { "" }, tool.Installs);
    }

    [Fact]
    public async Task After_an_update_the_older_releases_the_installer_left_are_removed_but_the_one_replaced_stays()
    {
        var (service, _, _, releases) = Make();
        foreach (var version in new[] { "0.150.0", "0.155.0", "0.156.0", "0.157.0", "0.158.0", "0.159.0" })
        {
            Directory.CreateDirectory(Path.Combine(releases, version + "-x86_64-pc-windows-msvc", "bin"));
        }

        await service.UpdateAsync(ownerAsked: true, CancellationToken.None);

        Assert.Equal(
            new[] { "0.157.0-x86_64-pc-windows-msvc", "0.158.0-x86_64-pc-windows-msvc", "0.159.0-x86_64-pc-windows-msvc" },
            Directory.GetDirectories(releases).Select(Path.GetFileName).OrderBy(name => name));
    }

    [Fact]
    public async Task A_look_that_breaks_says_so_and_the_next_one_can_start()
    {
        var (service, tool, _, _) = Make();
        tool.Breaks = new InvalidOperationException("disk unplugged");

        var result = await service.CheckAsync(CancellationToken.None);

        Assert.Equal(CodexUpdateOutcome.Failed, result.Outcome);
        Assert.Equal("Codex could not be looked at: disk unplugged", result.Message);
        Assert.False(service.IsBusy);

        tool.Breaks = null;
        Assert.Equal(CodexUpdateOutcome.Available, (await service.CheckAsync(CancellationToken.None)).Outcome);
    }

    [Fact]
    public async Task Cancelling_ends_the_look_without_leaving_it_busy()
    {
        var (service, tool, _, _) = Make();
        tool.Breaks = new OperationCanceledException();

        await Assert.ThrowsAsync<OperationCanceledException>(() => service.CheckAsync(CancellationToken.None));

        Assert.False(service.IsBusy);
        Assert.Equal("", service.Doing);
    }

    [Fact]
    public async Task A_codex_from_another_installer_is_left_alone()
    {
        var (service, tool, _, _) = Make();
        tool.Managed = false;

        var result = await service.UpdateAsync(ownerAsked: true, CancellationToken.None);

        Assert.Equal(CodexUpdateOutcome.Manual, result.Outcome);
        Assert.Empty(tool.Installs);
        Assert.Null(service.NeedsYou);
    }

    [Theory]
    [InlineData(CodexUpdateOutcome.Waiting, 600)]
    [InlineData(CodexUpdateOutcome.Failed, 10800)]
    [InlineData(CodexUpdateOutcome.Unknown, 3600)]
    [InlineData(CodexUpdateOutcome.Settling, 3600)]
    [InlineData(CodexUpdateOutcome.UpToDate, 21600)]
    [InlineData(CodexUpdateOutcome.Updated, 21600)]
    [InlineData(CodexUpdateOutcome.RolledBack, 21600)]
    [InlineData(CodexUpdateOutcome.Available, 21600)]
    [InlineData(CodexUpdateOutcome.Skipped, 21600)]
    [InlineData(CodexUpdateOutcome.Manual, 21600)]
    [InlineData(CodexUpdateOutcome.NotInstalled, 21600)]
    public void The_next_look_comes_sooner_when_something_is_waiting_or_went_wrong(CodexUpdateOutcome outcome, int seconds) =>
        Assert.Equal(TimeSpan.FromSeconds(seconds), CodexUpdateSchedule.Next(outcome, TimeSpan.FromHours(6)));

    [Fact]
    public void A_short_usual_time_is_never_made_longer()
    {
        var every = TimeSpan.FromSeconds(20);

        Assert.Equal(every, CodexUpdateSchedule.Next(CodexUpdateOutcome.Failed, every));
        Assert.Equal(every, CodexUpdateSchedule.Next(CodexUpdateOutcome.Settling, every));
        Assert.Equal(CodexUpdateSchedule.WhenBusy, CodexUpdateSchedule.Next(CodexUpdateOutcome.Waiting, every));
    }

    [Fact]
    public void The_defaults_are_two_minutes_after_the_start_and_then_every_six_hours()
    {
        var options = new CodexUpdateOptions();

        Assert.Equal((120, 21600, "", ""), (options.FirstLookSeconds, options.EverySeconds, options.ChannelUrl, options.GitHubUrl));
    }
}

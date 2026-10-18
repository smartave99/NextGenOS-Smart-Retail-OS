using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Work;
using SmartRetail.Pos.Core.Actions;
using SmartRetail.Pos.Data.Demo;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>The assistant's own plan as the pages use it: a file in the add-on's data folder (never in the POS), tells the pages when it changes,
/// is read again after a restart, and is moved with the rest of the data when the folder is changed.</summary>
public sealed class WorkServiceTests : IDisposable
{
    private readonly string _root = Directory.CreateTempSubdirectory("work-service-").FullName;
    private readonly StorageService _storage;
    private readonly FixedClock _clock = new(new DateTimeOffset(2026, 10, 12, 12, 0, 0, TimeSpan.FromHours(5.5)));

    public WorkServiceTests()
    {
        File.WriteAllText(Path.Combine(_root, SmartRetail.AI.Storage.StorageSettingsStore.FileName), JsonSerializer.Serialize(new { DataFolder = Path.Combine(_root, "data") }));
        _storage = new StorageService(Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") }));
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private WorkService NewService() => new(_storage, _clock, NullLogger<WorkService>.Instance);

    private static WorkChange Task(string title, DateTime? due = null) =>
        new() { Op = WorkOp.Add, Item = new WorkItem { Kind = WorkKind.Task, Title = title, Due = due } };

    [Fact]
    public void The_plan_is_kept_in_the_memory_part_of_the_data_folder_and_comes_back_after_a_restart()
    {
        var service = NewService();
        Assert.Null(service.Change(Task("Get three quotations", new DateTime(2026, 10, 20))));

        var expected = Path.Combine(_root, "data", SmartRetail.AI.Storage.DataFolders.MemoryFolderName, "work.json");
        Assert.Equal(expected, service.Path);
        Assert.True(File.Exists(expected));
        var again = NewService().Load();
        Assert.Equal("Get three quotations", again.Items.Single().Title);
        Assert.Equal(new DateTime(2026, 10, 20), again.Items.Single().Due);
    }

    [Fact]
    public void The_pages_are_told_when_the_plan_changes()
    {
        var service = NewService();
        var told = 0;
        service.Changed += () => told++;

        service.Change(Task("Print posters"));
        var proposal = service.Propose(new[] { Task("Brief the riders") }, "A small pilot", askFirst: true);
        service.Approve(proposal.Id);
        service.Reject("not-there");

        Assert.Equal(4, told);
        Assert.Equal(2, service.Load().Items.Count);
    }

    [Fact]
    public void What_the_assistant_suggests_waits_for_the_owner_in_the_service_too()
    {
        var service = NewService();

        var proposal = service.Propose(new[] { Task("Print posters") }, "", askFirst: true);

        Assert.Empty(service.Load().Items);
        Assert.Equal(proposal.Id, service.Load().Pending.Single().Id);
        Assert.Equal("That change cannot be undone.", service.Undo(proposal.Id));   // nothing saved yet, so nothing to take back
    }

    [Fact]
    public void A_damaged_file_gives_an_empty_plan_and_keeps_the_bad_file_aside()
    {
        var service = NewService();
        service.Change(Task("Print posters"));
        File.WriteAllText(service.Path, "{ not json");

        Assert.Empty(service.Load().Items);
        Assert.True(File.Exists(service.Path + ".bad"));
    }

    [Fact]
    public async Task A_campaign_can_be_tracked_in_Actions_and_its_sales_are_read_from_the_POS_without_being_mixed_with_the_owners_numbers()
    {
        var options = Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") });
        var actions = new ActionService(_storage, new DemoStore(_clock, seedSales: true), new MemoryService(_storage, new AiEnvironment(options), _clock, NullLogger<MemoryService>.Instance), _clock,
            NullLogger<ActionService>.Instance);
        var today = DateOnly.FromDateTime(_clock.GetLocalNow().DateTime);

        var (problem, id) = actions.Create(new ShopAction { Title = "Pilot: posters", Kind = ActionKind.Advert, Start = today.AddDays(-45), End = today.AddDays(-25), Cost = 4000m, Source = "Plan" });

        Assert.Null(problem);
        Assert.NotEmpty(id);
        var action = actions.Load().Actions.Single();
        Assert.Equal((id, "Plan", 4000m), (action.Id, action.Source, action.Cost));
        var result = await actions.MeasureAsync(action, CancellationToken.None);
        Assert.NotEqual(ActionVerdict.Planned, result.Verdict);
        Assert.NotNull(result.During);
        Assert.False(string.IsNullOrWhiteSpace(result.Summary));
        // Nothing the owner entered about the campaign is in what the POS gave.
        Assert.DoesNotContain("entered", result.Summary);

        var (bad, noId) = actions.Create(new ShopAction { Title = " ", Kind = ActionKind.Advert, Start = today });
        Assert.Equal("Say what the shop did.", bad);
        Assert.Equal("", noId);
        Assert.Single(actions.Load().Actions);
    }

    [Fact]
    public void The_service_is_not_busy_when_nothing_is_being_written()
    {
        Assert.False(NewService().IsWriting);
    }
}

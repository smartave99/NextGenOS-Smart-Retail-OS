using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;
using SmartRetail.AI.Work;
using SmartRetail.Pos.Core.Actions;
using SmartRetail.Pos.Data.Demo;
using SmartRetail.Pos.Web.Components.Pages;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>The "Plan &amp; tasks" page, rendered to HTML over a real plan file: what waits for the owner, what is due or late, the projects with their tasks, and the
/// words that say what the page does and does not do. (Clicking is not tested here: no browser. The page's buttons call the same service the other tests cover.)</summary>
public sealed class WorkPlanPageTests : IDisposable
{
    private readonly string _root = Directory.CreateTempSubdirectory("work-page-").FullName;
    private readonly StorageService _storage;
    private readonly FixedClock _clock = new(new DateTimeOffset(2026, 10, 12, 12, 0, 0, TimeSpan.FromHours(5.5)));

    public WorkPlanPageTests()
    {
        File.WriteAllText(Path.Combine(_root, SmartRetail.AI.Storage.StorageSettingsStore.FileName), JsonSerializer.Serialize(new { DataFolder = Path.Combine(_root, "data") }));
        _storage = new StorageService(Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") }));
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private static WorkChange Add(WorkKind kind, string title, string project = "", DateTime? due = null, decimal? budget = null) =>
        new() { Op = WorkOp.Add, Item = new WorkItem { Kind = kind, Title = title, ProjectName = project, Due = due, Budget = budget } };

    private async Task<string> RenderAsync(WorkService work, string? campaignId = null)
    {
        var options = Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") });
        var memory = new MemoryService(_storage, new AiEnvironment(options), _clock, NullLogger<MemoryService>.Instance);
        var actions = new ActionService(_storage, new DemoStore(_clock, seedSales: true), memory, _clock, NullLogger<ActionService>.Instance);
        var licence = new ProductLicence(() => new LicenceState { Status = LicenceStatus.Valid, Licence = new LicenceClaims { Modules = ["pos", "ai", "dashboard"] } }, _clock);
        var services = new ServiceCollection()
            .AddSingleton<IJSRuntime, NoJs>()
            .AddSingleton(work)
            .AddSingleton(actions)
            .AddSingleton(new AiEnvironment(options))
            .AddSingleton<Microsoft.AspNetCore.Components.NavigationManager>(new NoNavigation())
            .AddSingleton<TimeProvider>(_clock)
            .AddSingleton(licence)
            .AddSingleton<BrandService>()
            .AddSingleton(NullLoggerFactory.Instance)
            .AddSingleton(typeof(Microsoft.Extensions.Logging.ILogger<>), typeof(Microsoft.Extensions.Logging.Abstractions.NullLogger<>))
            .BuildServiceProvider();
        await using var _ = services;
        await using var renderer = new HtmlRenderer(services, NullLoggerFactory.Instance);
        return await renderer.Dispatcher.InvokeAsync(async () => campaignId is null
            ? (await renderer.RenderComponentAsync<WorkPlan>(ParameterView.Empty)).ToHtmlString()
            : (await renderer.RenderComponentAsync<CampaignView>(ParameterView.FromDictionary(new Dictionary<string, object?> { ["Id"] = campaignId }))).ToHtmlString());
    }

    private sealed class NoNavigation : Microsoft.AspNetCore.Components.NavigationManager
    {
        public NoNavigation() => Initialize("http://localhost/", "http://localhost/");
    }

    private WorkService NewService() => new(_storage, _clock, NullLogger<WorkService>.Instance);

    [Fact]
    public async Task An_empty_plan_says_so_and_what_the_page_is_for()
    {
        var html = await RenderAsync(NewService());

        Assert.Contains("Plan &amp; tasks", html);
        Assert.Contains("never in the POS", html);
        Assert.Contains("they are not sent to anyone", html);
        Assert.Contains("Nothing yet. Add something below", html);
        Assert.DoesNotContain("Waiting for your Save", html);
    }

    [Fact]
    public async Task What_the_assistant_suggested_waits_with_Save_and_Dont_save_and_is_not_yet_in_the_plan()
    {
        var work = NewService();
        work.Propose(new[] { Add(WorkKind.Project, "Pilot: e-rickshaw ads", budget: 5000m), Add(WorkKind.Task, "Get three quotations", "Pilot", new DateTime(2026, 10, 20)) },
            "A small pilot keeps the risk low.", askFirst: true);

        var html = await RenderAsync(work);

        Assert.Contains("Suggested by the assistant", html);
        Assert.Contains("Waiting for your Save", html);
        Assert.Contains("A small pilot keeps the risk low.", html);
        Assert.Contains("Add project: Pilot: e-rickshaw ads", html);
        Assert.Contains("Add task: Get three quotations (due 20 Oct)", html);
        Assert.Contains("Save all", html);
        Assert.Contains("Don’t save", html);
        Assert.DoesNotContain("aria-label=\"Pilot: e-rickshaw ads\"", html);   // no project card yet: nothing is saved
    }

    [Fact]
    public async Task Saved_work_shows_by_project_with_its_budget_and_what_is_late_or_due_soon_is_listed_first()
    {
        var work = NewService();
        work.Change(Add(WorkKind.Project, "Pilot: e-rickshaw ads", budget: 5000m));
        work.Change(Add(WorkKind.Task, "Get three quotations", "Pilot", new DateTime(2026, 10, 11)));    // yesterday: late
        work.Change(Add(WorkKind.Task, "Brief the riders", "Pilot"));
        work.Change(Add(WorkKind.Reminder, "Count the offer codes", due: new DateTime(2026, 10, 12)));    // today
        work.Change(Add(WorkKind.Reminder, "Check the printer's price", due: new DateTime(2026, 11, 30))); // far off: not "due soon"
        work.Change(new WorkChange { Op = WorkOp.Complete, ItemWords = "Brief the riders" });

        var html = await RenderAsync(work);

        Assert.Contains("Due soon", html);
        Assert.Contains("late: 11 Oct 2026", html);
        Assert.Contains("Count the offer codes", html);
        Assert.Contains("today", html);
        Assert.Contains("aria-label=\"Pilot: e-rickshaw ads\"", html);
        Assert.Contains("Budget you set:", html);
        Assert.Contains("1 open, 1 done", html);
        var due = html.IndexOf("Due soon", StringComparison.Ordinal);
        var project = html.IndexOf("aria-label=\"Pilot: e-rickshaw ads\"", StringComparison.Ordinal);
        Assert.True(due < project, "what is late comes before the projects");
        // The far-off reminder is a loose item, not in "due soon".
        var dueSection = html[due..project];
        Assert.DoesNotContain("Check the printer", dueSection);
        Assert.Contains("Check the printer&#x27;s price", html.Replace("&#39;", "&#x27;"));
    }

    [Fact]
    public async Task What_changed_lists_each_saved_change_with_Undo()
    {
        var work = NewService();
        work.Change(Add(WorkKind.Task, "Print posters"));

        var html = await RenderAsync(work);

        Assert.Contains("What changed", html);
        Assert.Contains("Saved:", html);
        Assert.Contains("Add task: Print posters", html);
        Assert.Contains("Undo", html);
    }

    [Fact]
    public async Task The_plan_page_offers_the_neutral_campaign_plan_with_its_steps_and_promises_nothing()
    {
        var html = await RenderAsync(NewService());

        Assert.Contains("Plan a campaign", html);
        Assert.Contains("A small advertising test", html);
        Assert.Contains("Get at least three written quotations", html);
        Assert.Contains("10 days before it starts", html);
        Assert.Contains("holds no prices and promises no results", html);
        foreach (var word in new[] { "rickshaw", "India", "Diwali" })
        {
            Assert.DoesNotContain(word, html, StringComparison.OrdinalIgnoreCase);
        }
    }

    [Fact]
    public async Task A_campaigns_page_keeps_the_owners_numbers_apart_from_the_POS_and_says_what_a_comparison_cannot_show()
    {
        var work = NewService();
        work.Change(Add(WorkKind.Project, "Pilot: e-rickshaw ads", budget: 5000m));
        var id = work.Load().Projects.Single().Id;
        work.Change(new WorkChange { Op = WorkOp.Update, ItemId = id, Item = new WorkItem { Starts = new DateTime(2026, 10, 5), Due = new DateTime(2026, 10, 20), Channel = "posters on e-rickshaws", Area = "the market road" } });
        foreach (var (day, people) in new[] { (30, 80m), (2, 90m), (3, 100m), (6, 130m), (7, 140m), (8, 150m) })
        {
            work.Change(new WorkChange { Op = WorkOp.Add, Item = new WorkItem { Kind = WorkKind.Record, Title = "People at the stall", ProjectId = id, Label = "footfall", Amount = people, Due = new DateTime(2026, 10, 1).AddDays(day - 1 < 0 ? 0 : day - 1) } });
        }

        work.Change(new WorkChange { Op = WorkOp.Add, Item = new WorkItem { Kind = WorkKind.Record, Title = "Printer A", ProjectId = id, Label = "quote", Amount = 5200m, Due = new DateTime(2026, 10, 1) } });
        work.Change(new WorkChange { Op = WorkOp.Add, Item = new WorkItem { Kind = WorkKind.Record, Title = "Printer deposit", ProjectId = id, Label = "expense", Amount = 3000m, Due = new DateTime(2026, 10, 2) } });

        var html = await RenderAsync(work, id);

        Assert.Contains("posters on e-rickshaws &#xB7; the market road", html);   // the page writer spells · as &#xB7;
        Assert.Contains("Numbers you entered", html);
        Assert.Contains("Not from the POS", html);
        Assert.Contains("Printer A", html);
        Assert.Contains("Spent, as you entered it", html);
        Assert.Contains("the assistant never estimates them", html);
        Assert.Contains("not proof that the campaign caused it", html);           // the counts' limits
        Assert.Contains("It cannot show that the action caused any change", html); // the sales' limits
        Assert.Contains("Track sales around this campaign", html);
        Assert.Contains("Nothing is changed in the POS", html);
    }

    [Fact]
    public async Task A_project_that_is_not_in_the_plan_says_so()
    {
        var html = await RenderAsync(NewService(), "nothing-here");

        Assert.Contains("That project is not in the plan any more", html);
    }

    private sealed class NoJs : IJSRuntime
    {
        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args) => default;

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args) => default;
    }
}

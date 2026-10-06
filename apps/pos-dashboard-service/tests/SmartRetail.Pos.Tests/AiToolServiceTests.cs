using SmartRetail.AI.Providers;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>Claude Code and Antigravity as the dashboard's screens use them: the model lists are kept a few minutes, a look changes nothing, an update runs one at a time and leaves what it did.</summary>
public sealed class AiToolServiceTests
{
    private sealed class Care : ICliToolCare
    {
        public int ModelCalls;
        public int Updates;
        public string Installed = "2.1.289";
        public string Newest = "2.2.0";
        public Exception? Breaks;
        public TaskCompletionSource<bool>? Hold;

        public Task<CliToolStatus> StatusAsync(string providerId, CancellationToken cancellationToken) =>
            Task.FromResult(new CliToolStatus { ProviderId = providerId, Name = "Claude Code", Found = true, Version = Installed });

        public Task<CliModelList> ModelsAsync(string providerId, CancellationToken cancellationToken)
        {
            ModelCalls++;
            return Task.FromResult(new CliModelList { Source = "built-in", Models = { new CliModel { Id = "claude-opus-5-5", Label = "Claude Opus 5.5" } } });
        }

        public Task<CliUpdateCheck> CheckUpdateAsync(string providerId, CancellationToken cancellationToken) =>
            Task.FromResult(new CliUpdateCheck { Status = new CliToolStatus { Version = Installed, Found = true }, Latest = Newest, Update = "available", CanUpdate = true });

        public async Task<CliUpdateResult> UpdateAsync(string providerId, CancellationToken cancellationToken)
        {
            Updates++;
            if (Hold is not null)
            {
                await Hold.Task;
            }

            if (Breaks is not null)
            {
                throw Breaks;
            }

            var before = Installed;
            Installed = Newest;
            return new CliUpdateResult { Before = before, After = Installed, Changed = true };
        }
    }

    private DateTime _now = new(2026, 10, 6, 9, 0, 0);

    private AiToolService Service(Care care) => new(() => care, () => _now);

    [Fact]
    public async Task A_model_list_is_kept_for_a_few_minutes_and_asked_again_when_it_is_old_or_when_the_owner_presses_refresh()
    {
        var care = new Care();
        var service = Service(care);

        await service.ModelsAsync(ProviderIds.ClaudeCli, fresh: false, CancellationToken.None);
        await service.ModelsAsync(ProviderIds.ClaudeCli, fresh: false, CancellationToken.None);
        Assert.Equal(1, care.ModelCalls);

        await service.ModelsAsync(ProviderIds.ClaudeCli, fresh: true, CancellationToken.None);
        Assert.Equal(2, care.ModelCalls);

        _now = _now.AddMinutes(6);
        await service.ModelsAsync(ProviderIds.ClaudeCli, fresh: false, CancellationToken.None);
        Assert.Equal(3, care.ModelCalls);

        await service.ModelsAsync(ProviderIds.AntigravityCli, fresh: false, CancellationToken.None);
        Assert.Equal(4, care.ModelCalls); // each tool has its own list
    }

    [Fact]
    public async Task A_look_is_remembered_per_tool_and_changes_nothing()
    {
        var care = new Care();
        var service = Service(care);
        Assert.Null(service.LastCheck(ProviderIds.ClaudeCli));

        var check = await service.CheckAsync(ProviderIds.ClaudeCli, CancellationToken.None);

        Assert.Equal("available", check!.Update);
        Assert.Same(check, service.LastCheck(ProviderIds.ClaudeCli));
        Assert.Null(service.LastCheck(ProviderIds.AntigravityCli));
        Assert.Equal(0, care.Updates);
        Assert.False(service.IsBusy);
    }

    [Fact]
    public async Task An_update_forgets_the_old_look_and_the_old_model_list_and_says_what_it_did()
    {
        var care = new Care();
        var service = Service(care);
        await service.CheckAsync(ProviderIds.ClaudeCli, CancellationToken.None);
        await service.ModelsAsync(ProviderIds.ClaudeCli, fresh: false, CancellationToken.None);

        var result = await service.UpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);

        Assert.True(result!.Changed);
        Assert.Equal(("2.1.289", "2.2.0"), (result.Before, result.After));
        Assert.Null(service.LastCheck(ProviderIds.ClaudeCli));
        Assert.Same(result, service.LastUpdate);
        await service.ModelsAsync(ProviderIds.ClaudeCli, fresh: false, CancellationToken.None);
        Assert.Equal(2, care.ModelCalls); // a newer tool may know newer models
    }

    [Fact]
    public async Task An_update_that_fails_says_why_and_the_service_is_free_again()
    {
        var care = new Care { Breaks = new CliToolException("The update did not finish (it stopped with code 3).") };
        var service = Service(care);

        var result = await service.UpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);

        Assert.Null(result);
        Assert.Contains("code 3", service.LastProblem);
        Assert.False(service.IsBusy);
        care.Breaks = null;
        Assert.NotNull(await service.UpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None));
        Assert.Null(service.LastProblem);
    }

    [Fact]
    public async Task Only_one_thing_is_done_to_the_tools_at_a_time()
    {
        var care = new Care { Hold = new TaskCompletionSource<bool>() };
        var service = Service(care);
        var changes = 0;
        service.Changed += () => changes++;

        var first = service.UpdateAsync(ProviderIds.ClaudeCli, CancellationToken.None);
        Assert.True(service.IsBusy);
        Assert.StartsWith("Updating", service.Doing);

        Assert.Null(await service.UpdateAsync(ProviderIds.AntigravityCli, CancellationToken.None)); // asked while busy: not started
        Assert.Equal(1, care.Updates);

        care.Hold.SetResult(true);
        await first;
        Assert.False(service.IsBusy);
        Assert.True(changes >= 2, "the screen is told when it starts and when it ends");
    }
}

using NextGenOS.Hub.Web.Updates;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>Blueprint REL-016: what the build writes into the program decides whether (and where) it looks for updates. Tried on any system through the plain function.</summary>
public class UpdateHostTests
{
    private static readonly Dictionary<string, string?> Good = new()
    {
        ["UpdateFeed"] = "https://updates.example.test/hub/", ["ReleaseRepositoryId"] = "111", ["ReleaseOwnerId"] = "222", ["ReleaseWorkflow"] = ".github/workflows/release.yml",
    };

    private static NextGenOS.Hub.Updates.UpdateOptions? Make(Action<Dictionary<string, string?>>? change = null, string? version = "1.2.3", string folder = "/data")
    {
        var values = new Dictionary<string, string?>(Good);
        change?.Invoke(values);
        return UpdateHost.Make(key => values.GetValueOrDefault(key), version, folder);
    }

    [Fact]
    public void A_program_built_with_a_folder_and_a_release_looks_there_and_keeps_what_it_finds_in_its_own_updates_folder()
    {
        var options = Make()!;
        Assert.Equal(new Uri("https://updates.example.test/hub/"), options.Trust!.Feed);
        Assert.Equal("111", options.Trust.Source.RepositoryId);
        Assert.Equal(new Version(1, 2, 3), options.Current);
        Assert.Equal(Path.Combine("/data", "updates"), options.Folder);
        Assert.NotNull(options.Http);
    }

    [Theory]
    [InlineData("1.2.3", 1, 2, 3)]
    [InlineData("1.2.3+abc123", 1, 2, 3)]
    [InlineData("1.2.3-rc1", 1, 2, 3)]
    [InlineData("10.20.30.0", 10, 20, 30)]
    public void The_running_version_is_the_first_three_numbers_of_what_the_build_wrote(string written, int major, int minor, int patch)
    {
        Assert.Equal(new Version(major, minor, patch), Make(version: written)!.Current);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("unknown")]
    [InlineData("1.2")]
    public void A_program_that_does_not_know_which_version_it_is_never_looks(string? written)
    {
        Assert.Null(Make(version: written));
    }

    [Fact]
    public void A_program_built_without_all_of_it_or_with_any_of_it_wrong_never_looks()
    {
        Assert.Null(UpdateHost.Make(_ => null, "1.2.3", "/data"));
        foreach (var key in Good.Keys) Assert.Null(Make(v => v.Remove(key)));
        Assert.Null(Make(v => v["UpdateFeed"] = "http://updates.example.test/hub/"));
        Assert.Null(Make(v => v["ReleaseRepositoryId"] = "not-a-number"));
        Assert.Null(Make(v => v["ReleaseWorkflow"] = "release.yml"));
    }

    [Fact]
    public void The_test_program_itself_carries_no_update_settings_and_so_never_looks()
    {
        // FromBuild reads the entry assembly; on the build machines (and under the test runner) nothing was written into it, and off Windows it never looks at all.
        Assert.Null(UpdateHost.FromBuild("/data"));
    }
}

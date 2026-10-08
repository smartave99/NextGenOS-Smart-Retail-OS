using System.Text.Json;
using System.Text.Json.Nodes;
using NextGenOS.Hub.Backups;
using NextGenOS.Hub.Diagnostics;
using NextGenOS.Hub.Updates;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Blueprint REL-016: updates through the main PC. The statement GitHub signs for the project's own release is the only thing that makes a download trusted, so it is tried from every
/// side; the checker is tried against an online folder that goes wrong in every way it can; the service is tried as the owner uses it (look, read, approve, not now). Nothing here
/// installs anything: that step is the owner's, and the tests say so by never expecting it.
/// </summary>
public sealed class UpdateTests : IDisposable
{
    private const string Sha = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    private readonly GitHubStandIn github = new();
    private readonly FeedStandIn feed = new();
    private readonly string folder = Path.Combine(Path.GetTempPath(), "hub-upd-" + Guid.NewGuid().ToString("N"));
    private readonly string place = Path.Combine(Path.GetTempPath(), "hub-upd-place-" + Guid.NewGuid().ToString("N"));
    private readonly List<HubFixture> shops = [];

    public void Dispose()
    {
        foreach (var shop in shops) shop.Dispose();
        github.Dispose();
        feed.Dispose();
        foreach (var path in new[] { folder, place })
        {
            try { if (Directory.Exists(path)) Directory.Delete(path, true); } catch (IOException) { }
        }
    }

    private static UpdateSettings Trust => new(FeedStandIn.Folder, GitHubStandIn.Source);

    private UpdateOptions Options(string current = "1.0.0") => new(Trust, folder, Version.Parse(current), () => new HttpClient(feed, disposeHandler: false));

    private HubFixture Shop(string current = "1.0.0")
    {
        var shop = new HubFixture(updates: Options(current));
        shops.Add(shop);
        return shop;
    }

    private UpdateChecker Checker(string current = "1.0.0") => new(new HttpClient(feed, disposeHandler: false), Trust, folder, Version.Parse(current));

    private Published Publish(string version = "1.2.0", int size = 4096, long partSize = 0, Action<JsonObject>? change = null, string? statement = null)
    {
        var published = Published.Make(version, size, partSize: partSize);
        published.PutIn(feed, github, change, statement);
        return published;
    }

    private static string Description(Action<JsonObject>? change = null)
    {
        var json = new JsonObject
        {
            ["Version"] = "1.2.0", ["File"] = UpdateManifest.SetupFileName("1.2.0"), ["Sha256"] = Sha, ["Size"] = 100, ["PartSize"] = 0, ["Notes"] = "Faster checkout.", ["Statement"] = "a.b.c",
        };
        change?.Invoke(json);
        return json.ToJsonString();
    }

    // ---- the description of a version ---------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_description_as_the_release_writes_it_is_read()
    {
        var manifest = UpdateManifest.Parse(Description());
        Assert.Equal("1.2.0", manifest.Version);
        Assert.Equal(new Version(1, 2, 0), manifest.ParsedVersion);
        Assert.Equal("smartretail-hub-update:1.2.0:" + Sha, manifest.Audience);
        Assert.Equal(1, manifest.PartCount);
    }

    [Theory]
    [InlineData("no statement")]
    [InlineData("the add-on's setup name")]
    [InlineData("upper case fingerprint")]
    [InlineData("short fingerprint")]
    [InlineData("size nothing")]
    [InlineData("size too big")]
    [InlineData("version with two numbers")]
    [InlineData("version with four numbers")]
    [InlineData("pieces too small")]
    [InlineData("pieces too many")]
    [InlineData("not a description")]
    [InlineData("nothing at all")]
    public void A_description_that_is_not_exactly_what_the_release_writes_is_refused(string what)
    {
        var json = what switch
        {
            "no statement" => Description(j => j["Statement"] = " "),
            "the add-on's setup name" => Description(j => j["File"] = "SmartRetailAI-Setup-1.2.0.exe"),
            "upper case fingerprint" => Description(j => j["Sha256"] = Sha.ToUpperInvariant().Replace('A', 'F')),
            "short fingerprint" => Description(j => j["Sha256"] = Sha[..63]),
            "size nothing" => Description(j => j["Size"] = 0),
            "size too big" => Description(j => j["Size"] = UpdateManifest.MaxSize + 1),
            "version with two numbers" => Description(j => { j["Version"] = "1.2"; j["File"] = "SmartRetailHub-Setup-1.2.exe"; }),
            "version with four numbers" => Description(j => { j["Version"] = "1.2.0.1"; j["File"] = "SmartRetailHub-Setup-1.2.0.1.exe"; }),
            "pieces too small" => Description(j => { j["Size"] = 5_000_000; j["PartSize"] = 1000; }),
            "pieces too many" => Description(j => { j["Size"] = 100L * 1024 * 1024; j["PartSize"] = 1024 * 1024; }),
            "not a description" => "this is not json",
            _ => "null",
        };
        var refused = Assert.Throws<HubException>(() => UpdateManifest.Parse(json));
        Assert.Equal("update", refused.Code);
    }

    [Fact]
    public void Long_notes_are_cut_short_and_a_setup_in_pieces_knows_its_pieces()
    {
        var manifest = UpdateManifest.Parse(Description(j => { j["Notes"] = new string('x', 900); j["Size"] = 2_500_000; j["PartSize"] = 1024 * 1024; }));
        Assert.Equal(UpdateManifest.MaxNotes, manifest.Notes.Length);
        Assert.Equal(3, manifest.PartCount);
        Assert.Equal("SmartRetailHub-Setup-1.2.0.exe.001", manifest.PartName(1));
        Assert.Equal(1024 * 1024, manifest.PartLength(1));
        Assert.Equal(2_500_000 - 2 * 1024 * 1024, manifest.PartLength(3));
    }

    // ---- GitHub's word ----------------------------------------------------------------------------------------------------------------------------

    private string? Check(string token, string? keys = null, string version = "1.2.0", string sha = Sha) =>
        ReleaseStatement.Check(token, keys ?? github.KeysJson(), GitHubStandIn.Source, UpdateManifest.AudienceFor(version, sha), version);

    [Fact]
    public void A_statement_from_the_projects_own_release_for_this_version_and_this_file_holds_even_long_after_it_was_made()
    {
        Assert.Null(Check(github.Statement("1.2.0", Sha)));                                                                   // its expiry is long past: it is kept as a signature, not used to sign in
        Assert.Null(Check(github.Statement("1.2.0", Sha, c => c["aud"] = new JsonArray("other", UpdateManifest.AudienceFor("1.2.0", Sha)))));   // GitHub may name several audiences
    }

    [Theory]
    [InlineData("another file", "it is for another version or another file")]
    [InlineData("the add-on's audience", "it is for another version or another file")]
    [InlineData("another repository", "it comes from another repository")]
    [InlineData("another owner", "it comes from another repository")]
    [InlineData("a branch", "it does not come from a release tag")]
    [InlineData("a trial tag", "it does not come from a release tag")]
    [InlineData("the Studio's tag", "it does not come from a release tag")]
    [InlineData("another version's tag", "it is for another version than the one described")]
    [InlineData("another workflow", "it comes from another workflow")]
    [InlineData("a run started by hand", "it was not made by a release started with a version tag")]
    [InlineData("another maker", "it was not made by GitHub Actions")]
    public void A_statement_that_is_not_for_exactly_this_release_is_refused(string what, string reason)
    {
        void Tag(JsonObject c, string reference) { c["ref"] = reference; c["workflow_ref"] = GitHubStandIn.Repository + "/" + GitHubStandIn.Workflow + "@" + reference; }
        var token = github.Statement("1.2.0", Sha, c =>
        {
            switch (what)
            {
                case "another file": c["aud"] = UpdateManifest.AudienceFor("1.2.0", new string('b', 64)); break;
                case "the add-on's audience": c["aud"] = "smartretail-update:1.2.0:" + Sha; break;
                case "another repository": c["repository_id"] = "999"; break;
                case "another owner": c["repository_owner_id"] = "999"; break;
                case "a branch": Tag(c, "refs/heads/main"); break;
                case "a trial tag": Tag(c, "refs/tags/v1.2.0-rc1"); break;
                case "the Studio's tag": Tag(c, "refs/tags/studio-v1.2.0"); break;
                case "another version's tag": Tag(c, "refs/tags/v1.2.1"); break;
                case "another workflow": c["workflow_ref"] = GitHubStandIn.Repository + "/.github/workflows/other.yml@refs/tags/v1.2.0"; break;
                case "a run started by hand": c["event_name"] = "workflow_dispatch"; break;
                case "another maker": c["iss"] = "https://example.test"; break;
            }
        });
        Assert.Equal(reason, Check(token));
    }

    [Fact]
    public void A_statement_that_GitHub_did_not_sign_is_refused_whatever_it_says()
    {
        using var other = System.Security.Cryptography.RSA.Create(2048);
        Assert.Equal("GitHub's signature does not match", Check(github.Statement("1.2.0", Sha, signWith: other)));                          // signed with someone else's key under GitHub's key name
        Assert.Equal("GitHub's key for it was not found", Check(github.Statement("1.2.0", Sha, kid: "unknown-key")));
        Assert.Equal("it is not signed the way GitHub signs", Check(github.Statement("1.2.0", Sha, alg: "none")));
        Assert.Equal("it is not signed the way GitHub signs", Check(github.Statement("1.2.0", Sha, alg: "HS256")));

        // The claims changed after signing.
        var parts = github.Statement("1.2.0", Sha).Split('.');
        var claims = JsonNode.Parse(System.Text.Encoding.UTF8.GetString(ReleaseStatement.FromBase64Url(parts[1])))!.AsObject();
        claims["repository_id"] = "999";
        var edited = parts[0] + "." + GitHubStandIn.B64(System.Text.Encoding.UTF8.GetBytes(claims.ToJsonString())) + "." + parts[2];
        Assert.Equal("GitHub's signature does not match", Check(edited));

        foreach (var junk in new[] { "", "abc", "a.b", "a.b.c", "a.b.c.d", "!!.!!.!!" }) Assert.Equal("it is not a signed statement", Check(junk));
        Assert.Equal("it is not a signed statement", ReleaseStatement.Check(null, github.KeysJson(), GitHubStandIn.Source, "x", "1.2.0"));
        Assert.Equal("GitHub's key for it was not found", Check(github.Statement("1.2.0", Sha), keys: "not json"));
        Assert.Equal("GitHub's key for it was not found", Check(github.Statement("1.2.0", Sha), keys: "{\"keys\":[]}"));
    }

    // ---- where to look, fixed when the program is built -----------------------------------------------------------------------------------------

    private static Func<string, string?> Meta(params (string Key, string? Value)[] changes)
    {
        var values = new Dictionary<string, string?>
        {
            [UpdateSettings.FeedKey] = "https://updates.example.test/hub/", [UpdateSettings.RepositoryIdKey] = "111", [UpdateSettings.OwnerIdKey] = "222", [UpdateSettings.WorkflowKey] = ".github/workflows/release.yml",
        };
        foreach (var (key, value) in changes) values[key] = value;
        return key => values.GetValueOrDefault(key);
    }

    [Fact]
    public void A_copy_looks_only_where_and_for_whom_the_build_said_and_otherwise_never()
    {
        var settings = UpdateSettings.From(Meta())!;
        Assert.Equal(new Uri("https://updates.example.test/hub/"), settings.Feed);
        Assert.Equal(GitHubStandIn.Source, settings.Source);

        Assert.Null(UpdateSettings.From(null));
        Assert.Null(UpdateSettings.From(_ => null));
        Assert.Null(UpdateSettings.From(Meta((UpdateSettings.FeedKey, "http://updates.example.test/hub/"))));            // not https
        Assert.Null(UpdateSettings.From(Meta((UpdateSettings.FeedKey, "https://updates.example.test/hub"))));             // not a folder
        Assert.Null(UpdateSettings.From(Meta((UpdateSettings.FeedKey, "https://updates.example.test/hub/?x=1"))));        // a query
        Assert.Null(UpdateSettings.From(Meta((UpdateSettings.FeedKey, "https://user:pw@updates.example.test/hub/"))));    // sign-in details
        Assert.Null(UpdateSettings.From(Meta((UpdateSettings.RepositoryIdKey, "abc"))));
        Assert.Null(UpdateSettings.From(Meta((UpdateSettings.OwnerIdKey, ""))));
        Assert.Null(UpdateSettings.From(Meta((UpdateSettings.WorkflowKey, "scripts/release.yml"))));                       // not a workflow file
        Assert.Null(UpdateSettings.From(Meta((UpdateSettings.WorkflowKey, ".github/workflows/../../evil.yml"))));
    }

    // ---- the checker ------------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_version_that_is_not_newer_is_left_alone_and_a_kept_setup_is_cleared_away()
    {
        Directory.CreateDirectory(folder);
        File.WriteAllText(Path.Combine(folder, "SmartRetailHub-Setup-0.9.0.exe"), "old");
        File.WriteAllText(Path.Combine(folder, "SmartRetailHub-Setup-0.9.0.exe.part"), "half");
        File.WriteAllText(Path.Combine(folder, "other.txt"), "mine");
        Publish("1.0.0");

        var found = await Checker().CheckAsync(DateTimeOffset.UtcNow, default);

        Assert.Equal(UpdateStates.UpToDate, found.State);
        Assert.Empty(feed.AskedFor(".exe"));
        Assert.Empty(feed.AskedFor("jwks"));
        Assert.Equal(["other.txt"], Directory.GetFiles(folder).Select(Path.GetFileName).ToArray());   // only the Hub's own kept setups go

        Publish("0.9.0");   // an older one published later is not newer either
        Assert.Equal(UpdateStates.UpToDate, (await Checker().CheckAsync(DateTimeOffset.UtcNow, default)).State);
    }

    [Fact]
    public async Task A_newer_version_is_proved_before_it_is_downloaded_then_kept_whole_and_checked_and_only_two_plain_requests_are_made()
    {
        var published = Publish("1.2.0", 20_000);

        var found = await Checker().CheckAsync(new DateTimeOffset(2026, 10, 8, 10, 30, 0, TimeSpan.Zero), default);

        Assert.Equal(UpdateStates.Ready, found.State);
        Assert.Equal("1.2.0", found.Available);
        Assert.Equal(published.Sha, found.Sha256);
        Assert.Equal("Faster checkout.", found.Notes);
        Assert.Equal(published.Setup, File.ReadAllBytes(Path.Combine(folder, published.Name)));

        // The order matters: the description, then GitHub's key, and only then the setup. Everything is a plain GET.
        Assert.Equal(["hub-latest.json", "jwks", published.Name], feed.Asked.Select(a => Path.GetFileName(a.Url.AbsolutePath)).ToArray());
        Assert.All(feed.Asked, a => Assert.Equal(HttpMethod.Get, a.Method));
        Assert.All(feed.Asked, a => Assert.Equal("https", a.Url.Scheme));
        Assert.Equal("?check=202610081030", feed.Asked[0].Url.Query);                                  // a time stamp so that a cached copy is not read; nothing else
        Assert.Empty(feed.Asked[1].Url.Query);
        Assert.Equal("SmartRetailPOS-Hub/1.0.0", feed.Asked[0].Agent);                                  // the program and its version, as decision 7 says
        Assert.Equal("SmartRetailPOS-Hub/1.0.0", feed.Asked[2].Agent);
        Assert.Null(feed.Asked[1].Agent);                                                               // nothing of ours goes to GitHub
        Assert.Equal(1, feed.Asked[0].Headers);                                                         // the user-agent line and no other: no cookie, no sign-in, no shop name
        Assert.Equal(0, feed.Asked[1].Headers);
        Assert.Equal("updates.example.test", feed.Asked[0].Url.Host);
        Assert.Equal("token.actions.githubusercontent.com", feed.Asked[1].Url.Host);
    }

    [Fact]
    public async Task A_version_the_projects_release_did_not_make_is_not_even_downloaded()
    {
        using var other = System.Security.Cryptography.RSA.Create(2048);
        var published = Published.Make("1.2.0");
        published.PutIn(feed, github, statement: github.Statement("1.2.0", published.Sha, signWith: other));   // someone with write access to the online folder, with their own key

        var found = await Checker().CheckAsync(DateTimeOffset.UtcNow, default);

        Assert.Equal(UpdateStates.Failed, found.State);
        Assert.Contains("was not published by the program's own release (GitHub's signature does not match), so it was not downloaded", found.Problem);
        Assert.Empty(feed.AskedFor(".exe"));
        Assert.False(Directory.Exists(folder) && Directory.GetFiles(folder).Length > 0);
    }

    [Fact]
    public async Task A_setup_in_pieces_is_joined_in_order_and_checked_as_a_whole()
    {
        var published = Publish("1.2.0", 2_500_000, partSize: 1024 * 1024);

        var found = await Checker().CheckAsync(DateTimeOffset.UtcNow, default);

        Assert.Equal(UpdateStates.Ready, found.State);
        Assert.Equal(published.Setup, File.ReadAllBytes(Path.Combine(folder, published.Name)));
        Assert.Equal([".001", ".002", ".003"], feed.Asked.Where(a => a.Url.AbsolutePath.Contains(".exe.")).Select(a => a.Url.AbsolutePath[^4..]).ToArray());
    }

    [Fact]
    public async Task A_setup_that_comes_down_wrong_in_any_way_is_not_kept()
    {
        var published = Publish("1.2.0", 2_500_000, partSize: 1024 * 1024);
        feed.Put(FeedStandIn.Url(published.Name + ".002"), new byte[1000]);                     // a piece with the wrong length
        var short1 = await Checker().CheckAsync(DateTimeOffset.UtcNow, default);
        Assert.Equal(UpdateStates.Failed, short1.State);
        Assert.Contains("came down different from what was published", short1.Problem);
        Assert.Empty(Directory.GetFiles(folder));                                                // not the setup, not a half-finished download

        var altered = Published.Make("1.2.1", 5000);
        altered.PutIn(feed, github);
        var changed = (byte[])altered.Setup.Clone();
        changed[100] ^= 0xFF;                                                                    // the right length with one byte changed: only the fingerprint can tell
        feed.Put(FeedStandIn.Url(altered.Name), changed);
        var different = await Checker().CheckAsync(DateTimeOffset.UtcNow, default);
        Assert.Equal(UpdateStates.Failed, different.State);
        Assert.Contains("came down different", different.Problem);
        Assert.Empty(Directory.GetFiles(folder));

        feed.Put(FeedStandIn.Url(altered.Name), altered.Setup.Concat(new byte[10]).ToArray());   // more than was said
        var more = await Checker().CheckAsync(DateTimeOffset.UtcNow, default);
        Assert.Equal(UpdateStates.Failed, more.State);
        Assert.Contains("sent more than was expected", more.Problem);
        Assert.Empty(Directory.GetFiles(folder));
    }

    [Fact]
    public async Task An_online_folder_that_cannot_be_reached_or_that_sends_the_answer_from_somewhere_else_is_a_plain_problem_and_never_a_crash()
    {
        var down = await Checker().CheckAsync(DateTimeOffset.UtcNow, default);                    // nothing published at all
        Assert.Equal(UpdateStates.Failed, down.State);
        Assert.Contains("answered 404", down.Problem);

        Publish("1.2.0");
        feed.Break(FeedStandIn.Url(UpdateManifest.FeedFile));
        Assert.Contains("could not be reached", (await Checker().CheckAsync(DateTimeOffset.UtcNow, default)).Problem);
        feed.Mend(FeedStandIn.Url(UpdateManifest.FeedFile));

        feed.Redirect(FeedStandIn.Url(UpdateManifest.FeedFile), new Uri("http://updates.example.test/hub/hub-latest.json"));        // sent on to plain http
        Assert.Contains("cannot be trusted", (await Checker().CheckAsync(DateTimeOffset.UtcNow, default)).Problem);
        feed.Redirect(FeedStandIn.Url(UpdateManifest.FeedFile), new Uri(FeedStandIn.Url(UpdateManifest.FeedFile)));                  // (put back)

        feed.Redirect(ReleaseStatement.KeysUrl.ToString(), new Uri("https://example.test/jwks"));                                    // GitHub's key taken from somewhere else
        var elsewhere = await Checker().CheckAsync(DateTimeOffset.UtcNow, default);
        Assert.Equal(UpdateStates.Failed, elsewhere.State);
        Assert.Contains("cannot be trusted", elsewhere.Problem);
        Assert.Empty(feed.AskedFor(".exe"));
    }

    [Fact]
    public async Task A_setup_already_kept_and_whole_is_not_downloaded_again_but_one_that_was_changed_on_the_disk_is_and_an_older_kept_one_goes()
    {
        Directory.CreateDirectory(folder);
        File.WriteAllText(Path.Combine(folder, "SmartRetailHub-Setup-1.1.0.exe"), "older");
        var published = Publish("1.2.0", 8000);
        await Checker().CheckAsync(DateTimeOffset.UtcNow, default);
        Assert.False(File.Exists(Path.Combine(folder, "SmartRetailHub-Setup-1.1.0.exe")));
        Assert.Single(feed.AskedFor(".exe"));

        await Checker().CheckAsync(DateTimeOffset.UtcNow, default);                                // looked again: it is there and whole
        Assert.Single(feed.AskedFor(".exe"));

        var path = Path.Combine(folder, published.Name);
        var tampered = File.ReadAllBytes(path);
        tampered[5] ^= 0xFF;
        File.WriteAllBytes(path, tampered);                                                        // changed on the PC's disk after it was checked
        await Checker().CheckAsync(DateTimeOffset.UtcNow, default);
        Assert.Equal(2, feed.AskedFor(".exe").Count());
        Assert.Equal(published.Setup, File.ReadAllBytes(path));
    }

    // ---- the owner's side -------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_copy_not_built_to_look_says_so_and_sends_nothing()
    {
        using var shop = new HubFixture();
        var updates = shop.App.Updates;
        Assert.False(updates.Built);
        var view = updates.View();
        Assert.False(view.Built);
        Assert.Contains("was not made to look for new versions", view.Summary);
        foreach (var call in new Func<Task>[]
        {
            () => Task.FromResult(updates.SetLooking(true, null)), () => updates.LookNowAsync(null), () => Task.FromResult(updates.Approve(null)), () => Task.FromResult(updates.Skip(null)),
        })
            Assert.Equal("update-not-built", (await Assert.ThrowsAsync<HubException>(call)).Code);
        await updates.LookIfDueAsync();
        Assert.Empty(feed.Asked);
    }

    [Fact]
    public async Task Looking_finds_a_version_and_keeps_it_checked_and_installs_nothing()
    {
        var shop = Shop();
        var published = Publish("1.2.0", 9000);

        var view = await shop.App.Updates.LookNowAsync(null);

        Assert.True(view.Built);
        Assert.Equal(UpdateStates.Ready, view.State);
        Assert.Equal("1.2.0", view.Version);
        Assert.Equal("Faster checkout.", view.Notes);
        Assert.Equal(Path.Combine(folder, published.Name), view.StagedPath);
        Assert.True(File.Exists(view.StagedPath));
        Assert.Contains("Version 1.2.0 is ready.", view.Summary);
        Assert.Contains("Nothing is installed until you approve it.", view.Summary);
        Assert.False(view.Skipped);
        var audit = shop.App.Audit.Recent(50).Select(a => a.Action).ToList();
        Assert.Contains("update.found", audit);
        Assert.Contains("update.look", audit);
        Assert.DoesNotContain("update.approve", audit);

        // The support file says how updates stand, without the address of the online folder.
        var file = SupportService.Render("Business Hub", shop.Clock.UtcNow, null, shop.App.Support.Sections());
        Assert.Contains("NEW VERSIONS OF THE PROGRAM", file);
        Assert.Contains("Looks for new versions: yes", file);
        Assert.Contains("Where it stands: version 1.2.0 is ready and waiting for the owner.", file);
        Assert.DoesNotContain("updates.example.test", file);

        // Nothing of the shop went out: a few plain requests to two hosts, none of which names the shop.
        Assert.Equal(3, feed.Asked.Count);
        Assert.All(feed.Asked, a => Assert.DoesNotContain("Test Shop", a.Url.ToString(), StringComparison.OrdinalIgnoreCase));
        Assert.All(feed.Asked, a => Assert.True(a.Agent is null || a.Agent == "SmartRetailPOS-Hub/1.0.0"));
    }

    [Fact]
    public async Task The_background_look_happens_about_once_a_day_after_a_failure_six_hours_later_and_never_when_switched_off()
    {
        var shop = Shop();
        Publish("1.0.0");
        int Looks() => feed.AskedFor("hub-latest.json").Count();

        await shop.App.Updates.LookIfDueAsync();
        Assert.Equal(1, Looks());
        shop.Clock.Advance(TimeSpan.FromHours(23));
        await shop.App.Updates.LookIfDueAsync();
        Assert.Equal(1, Looks());
        shop.Clock.Advance(TimeSpan.FromHours(2));
        await shop.App.Updates.LookIfDueAsync();
        Assert.Equal(2, Looks());

        feed.Break(FeedStandIn.Url(UpdateManifest.FeedFile));
        shop.Clock.Advance(TimeSpan.FromHours(25));
        await shop.App.Updates.LookIfDueAsync();                                                   // fails: written down, not thrown
        Assert.Equal(3, Looks());
        Assert.Equal(UpdateStates.Failed, shop.App.Updates.View().State);
        shop.Clock.Advance(TimeSpan.FromHours(5));
        await shop.App.Updates.LookIfDueAsync();
        Assert.Equal(3, Looks());
        shop.Clock.Advance(TimeSpan.FromHours(2));
        await shop.App.Updates.LookIfDueAsync();
        Assert.Equal(4, Looks());

        shop.App.Updates.SetLooking(false, null);
        Assert.False(shop.App.Updates.View().Looking);
        shop.Clock.Advance(TimeSpan.FromDays(3));
        await shop.App.Updates.LookIfDueAsync();
        Assert.Equal(4, Looks());
        await shop.App.Updates.LookNowAsync(null);                                                  // the owner may still ask by hand
        Assert.Equal(5, Looks());
        shop.App.Updates.SetLooking(true, null);
        await shop.App.Updates.LookIfDueAsync();                                                    // switched on again, but it looked a moment ago
        Assert.Equal(5, Looks());
        shop.Clock.Advance(TimeSpan.FromHours(7));
        await shop.App.Updates.LookIfDueAsync();
        Assert.Equal(6, Looks());
    }

    [Fact]
    public async Task Two_looks_at_the_same_moment_make_one_and_the_owner_is_told_to_wait()
    {
        var shop = Shop();
        Publish("1.2.0");
        var gate = new TaskCompletionSource();
        feed.Hold = gate.Task;
        var first = shop.App.Updates.LookNowAsync(null);
        await Task.Delay(50);
        Assert.Equal("update-busy", (await Assert.ThrowsAsync<HubException>(() => shop.App.Updates.LookNowAsync(null))).Code);
        await shop.App.Updates.LookIfDueAsync();                                                    // the background one just leaves it
        gate.SetResult();
        Assert.Equal(UpdateStates.Ready, (await first).State);
        Assert.Single(feed.AskedFor("hub-latest.json"));
    }

    [Fact]
    public async Task Approving_copies_the_shop_to_the_owners_second_place_first_and_installs_nothing()
    {
        var shop = Shop();
        Directory.CreateDirectory(place);
        shop.App.Backups.Save(new BackupSettings(true, place, "02:00", 14), null);
        Publish("1.2.0");
        await shop.App.Updates.LookNowAsync(null);

        var view = shop.App.Updates.Approve(7);

        Assert.Equal(UpdateStates.Approved, view.State);
        Assert.NotNull(view.ApprovedAt);
        Assert.Contains($"The shop was copied to {place} first", view.Note);
        Assert.Contains("is approved.", view.Summary);
        Assert.Contains("It is not installed yet", view.Summary);
        var run = Assert.Single(shop.App.Backups.Runs(), r => r.Good && r.Kind == BackupKinds.Manual);
        Assert.True(File.Exists(Path.Combine(place, run.FileName!)));
        Assert.True(File.Exists(view.StagedPath));                                                   // the checked setup is still there for the owner to run
        var approve = Assert.Single(shop.App.Audit.Recent(50), a => a.Action == "update.approve");
        Assert.Equal(7, approve.UserId);
        Assert.Equal("1.2.0", approve.Detail);
        Assert.Equal("update-approved", Assert.Throws<HubException>(() => shop.App.Updates.Approve(7)).Code);
    }

    [Fact]
    public async Task With_no_second_place_the_copy_is_made_on_this_PC_and_the_owner_is_told_that_it_does_not_replace_a_real_backup()
    {
        var shop = Shop();
        Publish("1.2.0");
        await shop.App.Updates.LookNowAsync(null);

        var view = shop.App.Updates.Approve(null);

        Assert.Contains("No second place for copies is chosen yet", view.Note);
        var copy = Path.Combine(folder, "copies", "NextGenOS-shop-before-1.2.0.bak");
        Assert.True(File.Exists(copy));
        Assert.True(new FileInfo(copy).Length > 0);
        Assert.Empty(shop.App.Backups.Runs());
    }

    [Fact]
    public async Task An_approval_is_refused_and_nothing_changes_when_the_shop_cannot_be_copied_first()
    {
        var shop = Shop();
        Directory.CreateDirectory(place);
        shop.App.Backups.Save(new BackupSettings(true, place, "02:00", 14), null);
        File.Delete(Path.Combine(place, ".nextgenos-backup-place"));                                // the drive was swapped for another: not the place that was chosen
        Publish("1.2.0");
        await shop.App.Updates.LookNowAsync(null);

        var refused = Assert.Throws<HubException>(() => shop.App.Updates.Approve(null));

        Assert.Equal("update-backup", refused.Code);
        Assert.Contains("The shop could not be copied first, so the update was not approved.", refused.Message);
        Assert.Equal(UpdateStates.Ready, shop.App.Updates.View().State);
        Assert.DoesNotContain(shop.App.Audit.Recent(50), a => a.Action == "update.approve");
    }

    [Fact]
    public async Task A_kept_setup_that_changed_on_the_disk_is_not_trusted_and_cannot_be_approved()
    {
        var shop = Shop();
        var published = Publish("1.2.0");
        var view = await shop.App.Updates.LookNowAsync(null);
        File.AppendAllText(view.StagedPath!, "x");

        var refused = Assert.Throws<HubException>(() => shop.App.Updates.Approve(null));

        Assert.Equal("update-changed", refused.Code);
        Assert.False(File.Exists(Path.Combine(folder, published.Name)));
        Assert.Equal(UpdateStates.None, shop.App.Updates.View().State);
        Assert.Equal("update-not-ready", Assert.Throws<HubException>(() => shop.App.Updates.Approve(null)).Code);
        Assert.Equal("update-not-ready", Assert.Throws<HubException>(() => shop.App.Updates.Skip(null)).Code);
        await shop.App.Updates.LookNowAsync(null);                                                   // the next look fetches it again, whole
        Assert.Equal(UpdateStates.Ready, shop.App.Updates.View().State);
    }

    [Fact]
    public async Task Not_now_stops_the_reminder_for_that_version_only_and_a_newer_version_asks_again()
    {
        var shop = Shop();
        Publish("1.2.0");
        await shop.App.Updates.LookNowAsync(null);

        var view = shop.App.Updates.Skip(null);
        Assert.True(view.Skipped);
        Assert.Equal(UpdateStates.Ready, view.State);                                                // still offered on its page

        await shop.App.Updates.LookNowAsync(null);                                                   // the same version again: still not now
        Assert.True(shop.App.Updates.View().Skipped);

        Publish("1.3.0");
        var newer = await shop.App.Updates.LookNowAsync(null);
        Assert.Equal("1.3.0", newer.Version);
        Assert.False(newer.Skipped);
        Assert.False(File.Exists(Path.Combine(folder, "SmartRetailHub-Setup-1.2.0.exe")));
    }

    [Fact]
    public async Task An_approval_stays_for_the_same_version_and_is_lost_when_a_newer_one_comes()
    {
        var shop = Shop();
        Publish("1.2.0");
        await shop.App.Updates.LookNowAsync(null);
        shop.App.Updates.Approve(null);

        var again = await shop.App.Updates.LookNowAsync(null);
        Assert.Equal(UpdateStates.Approved, again.State);
        Assert.NotNull(again.ApprovedAt);

        Publish("1.3.0");
        var newer = await shop.App.Updates.LookNowAsync(null);
        Assert.Equal(UpdateStates.Ready, newer.State);
        Assert.Equal("1.3.0", newer.Version);
        Assert.Null(newer.ApprovedAt);
        Assert.Null(newer.Note);
    }

    [Fact]
    public async Task A_look_that_fails_does_not_take_away_a_version_that_was_already_checked_and_kept()
    {
        var shop = Shop();
        Publish("1.2.0");
        await shop.App.Updates.LookNowAsync(null);
        feed.Break(FeedStandIn.Url(UpdateManifest.FeedFile));

        var view = await shop.App.Updates.LookNowAsync(null);

        Assert.Equal(UpdateStates.Ready, view.State);
        Assert.Contains("could not be reached", view.Problem);
        Assert.Contains("The last look for a newer one did not work", view.Summary);
        Assert.True(File.Exists(view.StagedPath));
        shop.App.Updates.Approve(null);                                                              // and it can still be approved
    }

    [Fact]
    public async Task When_the_program_that_runs_is_the_approved_version_the_kept_setup_is_removed_and_the_page_says_it_is_the_newest()
    {
        var shop = Shop();
        var published = Publish("1.2.0");
        await shop.App.Updates.LookNowAsync(null);
        shop.App.Updates.Approve(7);
        Assert.True(File.Exists(Path.Combine(folder, published.Name)));

        // The owner ran the setup; the program that starts afterwards is 1.2.0.
        var after = HubApp.OpenTrusted(shop.App.Db.Path, shop.Clock, updates: Options("1.2.0"));
        var view = after.Updates.View();

        Assert.Equal(UpdateStates.UpToDate, view.State);
        Assert.Contains("You have the newest version (1.2.0)", view.Summary);
        Assert.False(File.Exists(Path.Combine(folder, published.Name)));
        var installed = Assert.Single(after.Audit.Recent(50), a => a.Action == "update.installed");
        Assert.Equal(7, installed.UserId);                                                           // the person who approved it
        Assert.Equal("1.2.0", installed.Detail);
        Assert.True(Directory.Exists(Path.Combine(folder, "copies")));                              // the copy made before stays: it is the way back
    }

    [Fact]
    public void The_owners_page_text_is_in_plain_words_for_every_state()
    {
        var shop = Shop();
        Assert.Equal("Not looked yet. It looks about once a day, or press Look now.", shop.App.Updates.View().Summary);
        shop.App.Updates.SetLooking(false, null);
        Assert.Equal("Looking for new versions is switched off.", shop.App.Updates.View().Summary);
    }

    [Fact]
    public void An_update_note_cannot_carry_a_page_or_a_path_to_the_screen_because_the_description_is_text_only()
    {
        // The notes come from the online folder and are shown in the page as text. They are cut to 300 characters and never read as markup; the page encodes them (Razor does it).
        var manifest = UpdateManifest.Parse(Description(j => j["Notes"] = "<script>alert(1)</script>"));
        Assert.Equal("<script>alert(1)</script>", manifest.Notes);                                  // kept as text: the screen's encoding is what makes it harmless
        Assert.Equal(JsonValueKind.String, JsonDocument.Parse(Description()).RootElement.GetProperty("Notes").ValueKind);
    }
}

using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using NextGenOS.Hub.Updates;

namespace NextGenOS.Hub.Tests;

/// <summary>Runs a test only where the release script can run: bash, jq, curl, split and sha256sum (Linux, and the release workflow).</summary>
public sealed class PublishScriptFactAttribute : FactAttribute
{
    public PublishScriptFactAttribute()
    {
        if (!PublishHubUpdateScriptTests.CanRun(out var why)) Skip = why;
    }
}

/// <summary>
/// Blueprint REL-016, the producing side: what the release workflow's publish-update.sh writes for the Hub (<c>--product hub</c>) is exactly what the Hub's own checker accepts: the same file
/// names, the pieces, the SHA-256, GitHub's statement for that version and that file, and the description's fields. The script runs for real (bash, jq, curl, split); GitHub's token
/// service is a stand-in on this PC that signs like GitHub and names the tag the way a version-tag release does; the checker is the Hub's.
/// </summary>
public sealed class PublishHubUpdateScriptTests : IDisposable
{
    private static readonly Uri PublicFolder = new("https://shop.supabase.co/storage/v1/object/public/app-updates/");

    private readonly GitHubStandIn github = new();
    private readonly string work = Path.Combine(Path.GetTempPath(), "hub-pub-" + Guid.NewGuid().ToString("N"));
    private readonly HttpListener tokens = new();
    private readonly int port;
    private readonly List<string> audiencesAsked = [];

    public PublishHubUpdateScriptTests()
    {
        Directory.CreateDirectory(work);
        var probe = new TcpListener(IPAddress.Loopback, 0);
        probe.Start();
        port = ((IPEndPoint)probe.LocalEndpoint).Port;
        probe.Stop();
        tokens.Prefixes.Add($"http://127.0.0.1:{port}/");
        tokens.Start();
        _ = Task.Run(ServeAsync);
    }

    public void Dispose()
    {
        tokens.Close();
        github.Dispose();
        try { Directory.Delete(work, true); } catch (IOException) { }
    }

    public static bool CanRun(out string? why)
    {
        why = null;
        if (!OperatingSystem.IsLinux() && !OperatingSystem.IsMacOS()) { why = "the release script runs on Linux (bash, jq, curl, split)"; return false; }
        foreach (var tool in new[] { "bash", "jq", "curl", "split", "sha256sum" })
        {
            if (!(Environment.GetEnvironmentVariable("PATH") ?? "").Split(':').Any(folder => folder.Length > 0 && File.Exists(Path.Combine(folder, tool)))) { why = "needs " + tool; return false; }
        }
        return true;
    }

    private static string Script()
    {
        for (var folder = new DirectoryInfo(AppContext.BaseDirectory); folder is not null; folder = folder.Parent)
        {
            var candidate = Path.Combine(folder.FullName, "apps", "pos-ai-companion", "publish-update.sh");
            if (File.Exists(candidate)) return candidate;
        }
        throw new FileNotFoundException("publish-update.sh was not found above " + AppContext.BaseDirectory);
    }

    /// <summary>GitHub's token service as far as the script uses it: a signed token for the audience asked, for the right bearer, for a run started by a version tag.</summary>
    private async Task ServeAsync()
    {
        while (tokens.IsListening)
        {
            HttpListenerContext context;
            try { context = await tokens.GetContextAsync(); }
            catch (Exception e) when (e is HttpListenerException or ObjectDisposedException or InvalidOperationException) { return; }

            if (context.Request.Headers["Authorization"] != "bearer request-token") { context.Response.StatusCode = 401; context.Response.Close(); continue; }
            var audience = context.Request.QueryString["audience"] ?? "";
            lock (audiencesAsked) audiencesAsked.Add(audience);
            var parts = audience.Split(':');   // "<word>:<version>:<sha256>"
            var token = github.Statement(parts[1], parts[2], c => c["aud"] = audience);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { value = token }));
            context.Response.ContentType = "application/json";
            context.Response.OutputStream.Write(body, 0, body.Length);
            context.Response.Close();
        }
    }

    private (int Code, string Output) Publish(string setup, string version, string outDir, string product = "hub", long partBytes = 0, string requestToken = "request-token", bool withToken = true)
    {
        var start = new ProcessStartInfo("bash", $"\"{Script()}\" --version {version} --setup \"{setup}\" --notes \"What is new.\" --product {product}")
        {
            UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true,
        };
        start.Environment["UPDATE_FEED_URL"] = PublicFolder.ToString();
        start.Environment["UPDATE_DRY_RUN_DIR"] = outDir;
        if (withToken)
        {
            start.Environment["ACTIONS_ID_TOKEN_REQUEST_URL"] = $"http://127.0.0.1:{port}/oidc?api-version=2.0";
            start.Environment["ACTIONS_ID_TOKEN_REQUEST_TOKEN"] = requestToken;
        }
        if (partBytes > 0) start.Environment["UPDATE_PART_BYTES"] = partBytes.ToString();
        using var process = Process.Start(start)!;
        var output = process.StandardOutput.ReadToEndAsync();
        var errors = process.StandardError.ReadToEndAsync();
        Assert.True(process.WaitForExit(120_000), "the script did not finish");
        return (process.ExitCode, output.Result + errors.Result);
    }

    private string Setup(int bytes)
    {
        var path = Path.Combine(work, "setup.exe");
        var content = new byte[bytes];
        new Random(11).NextBytes(content);
        File.WriteAllBytes(path, content);
        return path;
    }

    /// <summary>The Hub's own checker reading the folder the script wrote, as if it were the online one.</summary>
    private async Task<UpdateCheckResult> HubChecks(string outDir, string appFolder)
    {
        var web = new FeedStandIn();
        foreach (var file in Directory.GetFiles(outDir)) web.Put(new Uri(PublicFolder, Path.GetFileName(file)).ToString(), File.ReadAllBytes(file));
        web.Put(ReleaseStatement.KeysUrl.ToString(), github.KeysJson());
        var checker = new UpdateChecker(new HttpClient(web, disposeHandler: false), new UpdateSettings(PublicFolder, GitHubStandIn.Source), appFolder, new Version(1, 0, 0));
        return await checker.CheckAsync(new DateTimeOffset(2026, 10, 8, 12, 0, 0, TimeSpan.Zero), CancellationToken.None);
    }

    [PublishScriptFact]
    public async Task A_setup_in_pieces_is_written_the_way_the_hub_reads_it()
    {
        var setup = Setup(2 * 1024 * 1024 + 300_000);
        var outDir = Path.Combine(work, "online");

        var (code, output) = Publish(setup, "9.9.9", outDir, partBytes: 1024 * 1024);

        Assert.True(code == 0, output);
        Assert.Equal(["SmartRetailHub-Setup-9.9.9.exe.001", "SmartRetailHub-Setup-9.9.9.exe.002", "SmartRetailHub-Setup-9.9.9.exe.003", "hub-latest.json"],
            Directory.GetFiles(outDir).Select(Path.GetFileName).OrderBy(n => n, StringComparer.Ordinal).ToArray());
        Assert.False(File.Exists(Path.Combine(outDir, "latest.json")), "the add-on's description is not touched");

        var manifest = UpdateManifest.Parse(File.ReadAllText(Path.Combine(outDir, "hub-latest.json")));
        Assert.Equal(("9.9.9", "SmartRetailHub-Setup-9.9.9.exe", 1024 * 1024L, 3, "What is new."), (manifest.Version, manifest.File, manifest.PartSize, manifest.PartCount, manifest.Notes));
        Assert.Equal(new FileInfo(setup).Length, manifest.Size);
        Assert.Equal(UpdateChecker.Sha256Of(setup), manifest.Sha256);

        // GitHub was asked for exactly this version and this file, in the Hub's own audience word, and what it gave holds for the project's own release tag.
        Assert.Equal([manifest.Audience], audiencesAsked);
        Assert.StartsWith("smartretail-hub-update:9.9.9:", manifest.Audience);
        Assert.Null(ReleaseStatement.Check(manifest.Statement, github.KeysJson(), GitHubStandIn.Source, manifest.Audience, "9.9.9"));

        // The pieces are the ones the description names, in size and in bytes.
        var joined = Enumerable.Range(1, manifest.PartCount).SelectMany(n => File.ReadAllBytes(Path.Combine(outDir, manifest.PartName(n)))).ToArray();
        Assert.Equal(File.ReadAllBytes(setup), joined);

        // And the Hub itself takes it: downloads, joins, checks, and keeps it ready.
        var app = Path.Combine(work, "app");
        var found = await HubChecks(outDir, app);
        Assert.Equal((UpdateStates.Ready, "9.9.9"), (found.State, found.Available));
        Assert.Equal(File.ReadAllBytes(setup), File.ReadAllBytes(Path.Combine(app, "SmartRetailHub-Setup-9.9.9.exe")));
    }

    [PublishScriptFact]
    public async Task A_small_setup_is_one_file_and_the_hub_takes_that_too()
    {
        var setup = Setup(400_000);
        var outDir = Path.Combine(work, "online");

        var (code, output) = Publish(setup, "2.10.0", outDir);

        Assert.True(code == 0, output);
        Assert.Equal(["SmartRetailHub-Setup-2.10.0.exe", "hub-latest.json"], Directory.GetFiles(outDir).Select(Path.GetFileName).OrderBy(n => n, StringComparer.Ordinal).ToArray());
        var manifest = UpdateManifest.Parse(File.ReadAllText(Path.Combine(outDir, "hub-latest.json")));
        Assert.Equal((0L, 1), (manifest.PartSize, manifest.PartCount));
        Assert.Equal((UpdateStates.Ready, "2.10.0"), ((await HubChecks(outDir, Path.Combine(work, "app"))) is var f ? (f.State, f.Available) : default));
    }

    [PublishScriptFact]
    public void A_statement_made_for_the_ai_add_on_can_never_pass_for_a_hub_update()
    {
        var setup = Setup(300_000);
        var outDir = Path.Combine(work, "online-ai");

        var (code, output) = Publish(setup, "9.9.9", outDir, product: "ai");

        Assert.True(code == 0, output);
        Assert.True(File.Exists(Path.Combine(outDir, "latest.json")));
        var json = File.ReadAllText(Path.Combine(outDir, "latest.json"));
        var statement = JsonDocument.Parse(json).RootElement.GetProperty("Statement").GetString();
        var sha = JsonDocument.Parse(json).RootElement.GetProperty("Sha256").GetString()!;
        // The add-on's own description is not a Hub description (its file name is another), and its statement does not hold for the Hub's audience.
        Assert.Throws<HubException>(() => UpdateManifest.Parse(json));
        Assert.Equal("it is for another version or another file", ReleaseStatement.Check(statement, github.KeysJson(), GitHubStandIn.Source, UpdateManifest.AudienceFor("9.9.9", sha), "9.9.9"));
    }

    [PublishScriptFact]
    public void The_script_stops_when_it_cannot_prove_the_release_or_is_asked_for_nonsense()
    {
        var setup = Setup(300_000);
        var outDir = Path.Combine(work, "online-bad");

        var noToken = Publish(setup, "9.9.9", outDir, withToken: false);
        Assert.NotEqual(0, noToken.Code);
        Assert.Contains("id-token: write", noToken.Output);

        var refused = Publish(setup, "9.9.9", outDir, requestToken: "wrong");
        Assert.NotEqual(0, refused.Code);
        Assert.Matches("returned error|did not give a signed statement", refused.Output);   // GitHub refused the run its statement (curl says so first)

        Assert.NotEqual(0, Publish(setup, "9.9", outDir).Code);                    // not three numbers
        Assert.NotEqual(0, Publish(setup, "9.9.9", outDir, product: "pos").Code);   // not a product it knows
        Assert.False(Directory.Exists(outDir) && Directory.GetFiles(outDir).Length > 0, "nothing was written for a release that was not proved");
    }
}

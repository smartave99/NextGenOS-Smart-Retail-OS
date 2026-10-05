using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Updates;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Runs a test only where the release script can run: bash, jq, curl and GNU's split (Linux, and the release workflow).</summary>
    public sealed class PublishScriptFactAttribute : FactAttribute
    {
        public PublishScriptFactAttribute()
        {
            if (!PublishUpdateScriptTests.CanRun(out var why))
            {
                Skip = why;
            }
        }
    }

    /// <summary>
    /// What the release workflow's publish-update.sh writes is exactly what the app accepts: the same file names, the
    /// pieces, the SHA-256, GitHub's statement for that version and that SHA-256, and the description's fields. The script
    /// runs for real (bash, jq, curl, split), GitHub's token service is a stand-in on this PC that signs like GitHub, and the
    /// app's own UpdateChecker reads what came out.
    /// </summary>
    public sealed class PublishUpdateScriptTests : IDisposable
    {
        private static readonly Uri Feed = new Uri("https://shop.supabase.co/storage/v1/object/public/app-updates/");
        private static readonly ReleaseSource Source = new ReleaseSource("1384926224", "260031592", "refs/heads/main", ".github/workflows/installer.yml");

        private readonly RSA _github = RSA.Create(2048);
        private readonly TempFolder _work = new TempFolder();
        private readonly HttpListener _tokens = new HttpListener();
        private readonly int _port;
        private readonly List<string> _audiencesAsked = new List<string>();

        public PublishUpdateScriptTests()
        {
            var probe = new TcpListener(IPAddress.Loopback, 0);
            probe.Start();
            _port = ((IPEndPoint)probe.LocalEndpoint).Port;
            probe.Stop();
            _tokens.Prefixes.Add("http://127.0.0.1:" + _port + "/");
            _tokens.Start();
            _ = Task.Run(ServeAsync);
        }

        public void Dispose()
        {
            _tokens.Close();
            _github.Dispose();
            _work.Dispose();
        }

        public static bool CanRun(out string why)
        {
            why = null;
            if (Environment.OSVersion.Platform != PlatformID.Unix)
            {
                why = "the release script runs on Linux (bash, jq, curl, split)";
                return false;
            }

            foreach (var tool in new[] { "bash", "jq", "curl", "split", "sha256sum" })
            {
                if (!(Environment.GetEnvironmentVariable("PATH") ?? "").Split(':').Any(folder => folder.Length > 0 && File.Exists(Path.Combine(folder, tool))))
                {
                    why = "needs " + tool;
                    return false;
                }
            }

            return true;
        }

        private static string Script()
        {
            for (var folder = new DirectoryInfo(AppContext.BaseDirectory); folder != null; folder = folder.Parent)
            {
                var candidate = Path.Combine(folder.FullName, "publish-update.sh");
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            throw new FileNotFoundException("publish-update.sh was not found above " + AppContext.BaseDirectory);
        }

        /// <summary>GitHub's token service as far as the script uses it: a signed token for the audience asked, for the right bearer.</summary>
        private async Task ServeAsync()
        {
            while (_tokens.IsListening)
            {
                HttpListenerContext context;
                try
                {
                    context = await _tokens.GetContextAsync();
                }
                catch (Exception ex) when (ex is HttpListenerException || ex is ObjectDisposedException || ex is InvalidOperationException)
                {
                    return;
                }

                if (context.Request.Headers["Authorization"] != "bearer request-token")
                {
                    context.Response.StatusCode = 401;
                    context.Response.Close();
                    continue;
                }

                var audience = context.Request.QueryString["audience"];
                lock (_audiencesAsked)
                {
                    _audiencesAsked.Add(audience);
                }

                var claims = new JObject
                {
                    ["iss"] = GitHubStatement.Issuer,
                    ["aud"] = audience,
                    ["repository"] = "smartave99/Test",
                    ["repository_id"] = "1384926224",
                    ["repository_owner_id"] = "260031592",
                    ["ref"] = "refs/heads/main",
                    ["workflow_ref"] = "smartave99/Test/.github/workflows/installer.yml@refs/heads/main",
                    ["event_name"] = "workflow_dispatch",
                };
                var body = Encoding.UTF8.GetBytes(new JObject { ["value"] = Sign(claims) }.ToString(Formatting.None));
                context.Response.ContentType = "application/json";
                context.Response.OutputStream.Write(body, 0, body.Length);
                context.Response.Close();
            }
        }

        private string Sign(JObject claims)
        {
            var header = Base64Url(Encoding.UTF8.GetBytes(new JObject { ["alg"] = "RS256", ["typ"] = "JWT", ["kid"] = "github-key" }.ToString(Formatting.None)));
            var payload = Base64Url(Encoding.UTF8.GetBytes(claims.ToString(Formatting.None)));
            var signature = _github.SignData(Encoding.ASCII.GetBytes(header + "." + payload), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return header + "." + payload + "." + Base64Url(signature);
        }

        private static string Base64Url(byte[] bytes) => Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');

        private string Keys => new JObject
        {
            ["keys"] = new JArray(new JObject
            {
                ["kty"] = "RSA", ["alg"] = "RS256", ["use"] = "sig", ["kid"] = "github-key",
                ["n"] = Base64Url(_github.ExportParameters(false).Modulus), ["e"] = Base64Url(_github.ExportParameters(false).Exponent),
            }),
        }.ToString();

        private (int Code, string Output) Publish(string setup, string version, string outDir, long partBytes = 0, string requestToken = "request-token", string notes = "What is new.")
        {
            var start = new ProcessStartInfo("bash", "\"" + Script() + "\" --version " + version + " --setup \"" + setup + "\" --notes \"" + notes + "\"")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            start.Environment["UPDATE_FEED_URL"] = Feed.ToString();
            start.Environment["UPDATE_DRY_RUN_DIR"] = outDir;
            start.Environment["ACTIONS_ID_TOKEN_REQUEST_URL"] = "http://127.0.0.1:" + _port + "/oidc?api-version=2.0";
            start.Environment["ACTIONS_ID_TOKEN_REQUEST_TOKEN"] = requestToken;
            if (partBytes > 0)
            {
                start.Environment["UPDATE_PART_BYTES"] = partBytes.ToString();
            }

            using (var process = Process.Start(start))
            {
                var output = process.StandardOutput.ReadToEndAsync();
                var errors = process.StandardError.ReadToEndAsync();
                Assert.True(process.WaitForExit(120000), "the script did not finish");
                return (process.ExitCode, output.Result + errors.Result);
            }
        }

        private string Setup(int bytes)
        {
            var path = Path.Combine(_work.Path, "SmartRetailAI-Setup.exe");
            var content = new byte[bytes];
            new Random(11).NextBytes(content);
            File.WriteAllBytes(path, content);
            return path;
        }

        /// <summary>The app's own checker reading the folder the script wrote, as if it were the online one.</summary>
        private async Task<UpdateStatus> AppChecks(string outDir, string appFolder)
        {
            var web = new RoutedHttpHandler().On("/.well-known/jwks", Keys);
            foreach (var file in Directory.GetFiles(outDir))
            {
                web.On("/storage/v1/object/public/app-updates/" + Path.GetFileName(file), File.ReadAllBytes(file));
            }

            var checker = new UpdateChecker(new HttpClient(web), Feed, appFolder, Source, () => new DateTime(2026, 9, 29, 12, 0, 0));
            return await checker.CheckAsync(new Version(2, 8, 0), CancellationToken.None);
        }

        [PublishScriptFact]
        public async Task A_setup_in_pieces_is_written_the_way_the_app_reads_it()
        {
            var setup = Setup(2 * 1024 * 1024 + 300_000);
            var outDir = Path.Combine(_work.Path, "online");

            var (code, output) = Publish(setup, "9.9.9", outDir, partBytes: 1024 * 1024);

            Assert.True(code == 0, output);
            Assert.Equal(
                new[] { "SmartRetailAI-Setup-9.9.9.exe.001", "SmartRetailAI-Setup-9.9.9.exe.002", "SmartRetailAI-Setup-9.9.9.exe.003", "latest.json" },
                Directory.GetFiles(outDir).Select(Path.GetFileName).OrderBy(name => name, StringComparer.Ordinal).ToArray());

            var manifest = UpdateManifest.Parse(File.ReadAllText(Path.Combine(outDir, "latest.json")));
            Assert.Equal(("9.9.9", "SmartRetailAI-Setup-9.9.9.exe", 1024 * 1024L, 3, "What is new."), (manifest.Version, manifest.File, manifest.PartSize, manifest.PartCount, manifest.Notes));
            Assert.Equal(new FileInfo(setup).Length, manifest.Size);
            Assert.Equal(UpdateChecker.Sha256Of(setup), manifest.Sha256);

            // GitHub's statement is for this version and this very SHA-256, and holds for the project's own release.
            Assert.Equal(new[] { manifest.Audience }, _audiencesAsked);
            Assert.Null(GitHubStatement.Check(manifest.Statement, Keys, Source, manifest.Audience));

            // The pieces are the ones the description names, in size and in bytes.
            var joined = Enumerable.Range(1, manifest.PartCount).SelectMany(number => File.ReadAllBytes(Path.Combine(outDir, manifest.PartName(number)))).ToArray();
            Assert.Equal(File.ReadAllBytes(setup), joined);
            Assert.All(Enumerable.Range(1, manifest.PartCount), number => Assert.Equal(manifest.PartLength(number), new FileInfo(Path.Combine(outDir, manifest.PartName(number))).Length));

            // And the app itself takes it: downloads, joins, checks, and has it ready.
            var app = Path.Combine(_work.Path, "app");
            var status = await AppChecks(outDir, app);
            Assert.Equal((UpdateState.Ready, "9.9.9"), (status.State, status.Available));
            Assert.Equal(File.ReadAllBytes(setup), File.ReadAllBytes(Path.Combine(app, "SmartRetailAI-Setup-9.9.9.exe")));
        }

        [PublishScriptFact]
        public async Task A_small_setup_is_one_file_and_the_app_takes_that_too()
        {
            var setup = Setup(400_000);
            var outDir = Path.Combine(_work.Path, "online");

            var (code, output) = Publish(setup, "2.10.0", outDir);

            Assert.True(code == 0, output);
            Assert.Equal(new[] { "SmartRetailAI-Setup-2.10.0.exe", "latest.json" }, Directory.GetFiles(outDir).Select(Path.GetFileName).OrderBy(name => name, StringComparer.Ordinal).ToArray());
            var manifest = UpdateManifest.Parse(File.ReadAllText(Path.Combine(outDir, "latest.json")));
            Assert.Equal((0L, 1), (manifest.PartSize, manifest.PartCount));
            Assert.Equal(UpdateState.Ready, (await AppChecks(outDir, Path.Combine(_work.Path, "app"))).State);
        }

        [PublishScriptFact]
        public void Nothing_is_written_when_GitHub_does_not_give_a_statement_or_the_input_is_wrong()
        {
            var setup = Setup(400_000);
            var outDir = Path.Combine(_work.Path, "online");

            var (denied, _) = Publish(setup, "9.9.9", outDir, requestToken: "not-the-token");
            Assert.NotEqual(0, denied);
            Assert.False(Directory.Exists(outDir), "no statement, nothing published");

            var (badVersion, message) = Publish(setup, "9.9", outDir);
            Assert.NotEqual(0, badVersion);
            Assert.Contains("three numbers", message);

            var (badNotes, _) = Publish(setup, "9.9.9", outDir, notes: new string('x', 900));
            Assert.Equal(0, badNotes);
            Assert.Equal(300, UpdateManifest.Parse(File.ReadAllText(Path.Combine(outDir, "latest.json"))).Notes.Length);
        }
    }
}

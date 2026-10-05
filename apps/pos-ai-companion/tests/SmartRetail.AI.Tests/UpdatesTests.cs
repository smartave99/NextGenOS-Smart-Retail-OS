using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    /// <summary>Automatic updates: only the project's own release, signed by GitHub, is downloaded, and only as published.</summary>
    public class UpdatesTests : IDisposable
    {
        private static readonly Uri Feed = new Uri("https://shop.supabase.co/storage/v1/object/public/app-updates/");
        private static readonly byte[] Setup = Encoding.ASCII.GetBytes("MZ a stand-in for the setup");
        private static readonly ReleaseSource Source = new ReleaseSource("1384926224", "260031592", "refs/heads/main", ".github/workflows/installer.yml");

        private readonly RSA _github = RSA.Create(2048);
        private readonly TempFolder _folder = new TempFolder();
        private readonly DateTime _now = new DateTime(2026, 9, 27, 10, 0, 0);

        public void Dispose()
        {
            _github.Dispose();
            _folder.Dispose();
        }

        private string Keys => new JObject
        {
            ["keys"] = new JArray(new JObject
            {
                ["kty"] = "RSA", ["alg"] = "RS256", ["use"] = "sig", ["kid"] = "github-key",
                ["n"] = Base64Url(_github.ExportParameters(false).Modulus), ["e"] = Base64Url(_github.ExportParameters(false).Exponent),
            }),
        }.ToString();

        private static string Sha(byte[] bytes)
        {
            using (var sha = SHA256.Create())
            {
                return string.Concat(sha.ComputeHash(bytes).Select(b => b.ToString("x2")));
            }
        }

        private static JObject Claims(string version, byte[] setup) => new JObject
        {
            ["iss"] = GitHubStatement.Issuer,
            ["aud"] = UpdateManifest.AudienceFor(version, Sha(setup)),
            ["repository"] = "smartave99/Test",
            ["repository_id"] = "1384926224",
            ["repository_owner_id"] = "260031592",
            ["ref"] = "refs/heads/main",
            ["workflow_ref"] = "smartave99/Test/.github/workflows/installer.yml@refs/heads/main",
            ["event_name"] = "workflow_dispatch",
            ["exp"] = 1,
        };

        private string Token(JObject claims, string kid = "github-key", string alg = "RS256", RSA key = null)
        {
            var header = Base64Url(Encoding.UTF8.GetBytes(new JObject { ["alg"] = alg, ["typ"] = "JWT", ["kid"] = kid }.ToString(Formatting.None)));
            var payload = Base64Url(Encoding.UTF8.GetBytes(claims.ToString(Formatting.None)));
            var signature = (key ?? _github).SignData(Encoding.ASCII.GetBytes(header + "." + payload), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return header + "." + payload + "." + Base64Url(signature);
        }

        private static string Base64Url(byte[] bytes) => Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');

        private string Manifest(string version, byte[] setup, string statement = null, long? size = null, long partSize = 0) => JsonConvert.SerializeObject(new
        {
            Version = version,
            File = UpdateManifest.SetupFileName(version),
            Sha256 = Sha(setup),
            Size = size ?? setup.Length,
            PartSize = partSize,
            Notes = "Faster posters.",
            Statement = statement ?? Token(Claims(version, setup)),
        });

        private UpdateChecker Checker(RoutedHttpHandler web) =>
            new UpdateChecker(new HttpClient(web), Feed, _folder.Path, Source, () => _now);

        private RoutedHttpHandler Web(string manifest, byte[] setup = null, string version = "1.7.0") => new RoutedHttpHandler()
            .On("/storage/v1/object/public/app-updates/latest.json", manifest)
            .On("/.well-known/jwks", Keys)
            .On("/storage/v1/object/public/app-updates/" + UpdateManifest.SetupFileName(version), setup ?? Setup);

        [Fact]
        public void GitHubs_statement_holds_only_for_the_projects_own_release_of_this_very_setup()
        {
            var audience = UpdateManifest.AudienceFor("1.7.0", Sha(Setup));
            Assert.Null(GitHubStatement.Check(Token(Claims("1.7.0", Setup)), Keys, Source, audience));

            string With(Action<JObject> change)
            {
                var claims = Claims("1.7.0", Setup);
                change(claims);
                return GitHubStatement.Check(Token(claims), Keys, Source, audience);
            }

            Assert.Equal("it comes from another repository", With(c => c["repository_id"] = "42"));
            Assert.Equal("it comes from another repository", With(c => c["repository_owner_id"] = "42"));
            Assert.Equal("it comes from another branch", With(c => c["ref"] = "refs/pull/13/merge"));
            Assert.Equal("it comes from another workflow", With(c => c["workflow_ref"] = "smartave99/Test/.github/workflows/other.yml@refs/heads/main"));
            Assert.Equal("it is for another version or another file", With(c => c["aud"] = UpdateManifest.AudienceFor("1.7.0", Sha(new byte[] { 1 }))));
            Assert.Equal("it is for another version or another file", With(c => c["aud"] = UpdateManifest.AudienceFor("9.9.9", Sha(Setup))));
            Assert.Equal("it was not made by GitHub Actions", With(c => c["iss"] = "https://example.com"));
            Assert.Equal("it was not made by a release started by hand", With(c => c["event_name"] = "push"));
            Assert.Equal("it was not made by a release started by hand", With(c => c["event_name"] = "pull_request"));
            Assert.Null(With(c => c["aud"] = new JArray("sts.amazonaws.com", audience)));

            using (var stranger = RSA.Create(2048))
            {
                Assert.Equal("GitHub's signature does not match", GitHubStatement.Check(Token(Claims("1.7.0", Setup), key: stranger), Keys, Source, audience));
            }

            Assert.Equal("GitHub's key for it was not found", GitHubStatement.Check(Token(Claims("1.7.0", Setup), kid: "other"), Keys, Source, audience));
            Assert.Equal("it is not signed the way GitHub signs", GitHubStatement.Check(Token(Claims("1.7.0", Setup), alg: "none"), Keys, Source, audience));
            Assert.Equal("it is not a signed statement", GitHubStatement.Check("not.a.token!", Keys, Source, audience));

            // The claims changed after GitHub signed them.
            var parts = Token(Claims("1.7.0", Setup)).Split('.');
            var forged = Claims("1.7.0", Setup);
            forged["repository_id"] = "42";
            parts[1] = Base64Url(Encoding.UTF8.GetBytes(forged.ToString(Formatting.None)));
            Assert.Equal("GitHub's signature does not match", GitHubStatement.Check(string.Join(".", parts), Keys, Source, audience));
        }

        [Theory]
        [InlineData("{}")]
        [InlineData("not json")]
        [InlineData("{\"Version\":\"1.7\",\"File\":\"SmartRetailAI-Setup-1.7.exe\",\"Sha256\":\"%SHA%\",\"Size\":10,\"Statement\":\"x\"}")]
        [InlineData("{\"Version\":\"1.7.0\",\"File\":\"..\\\\evil.exe\",\"Sha256\":\"%SHA%\",\"Size\":10,\"Statement\":\"x\"}")]
        [InlineData("{\"Version\":\"1.7.0\",\"File\":\"SmartRetailAI-Setup-1.7.0.exe\",\"Sha256\":\"ABC\",\"Size\":10,\"Statement\":\"x\"}")]
        [InlineData("{\"Version\":\"1.7.0\",\"File\":\"SmartRetailAI-Setup-1.7.0.exe\",\"Sha256\":\"%SHA%\",\"Size\":0,\"Statement\":\"x\"}")]
        [InlineData("{\"Version\":\"1.7.0\",\"File\":\"SmartRetailAI-Setup-1.7.0.exe\",\"Sha256\":\"%SHA%\",\"Size\":999999999999,\"Statement\":\"x\"}")]
        [InlineData("{\"Version\":\"1.7.0\",\"File\":\"SmartRetailAI-Setup-1.7.0.exe\",\"Sha256\":\"%SHA%\",\"Size\":10,\"Statement\":\"\"}")]
        public void A_description_that_is_not_exactly_what_the_release_writes_is_refused(string json) =>
            Assert.Throws<UpdateException>(() => UpdateManifest.Parse(json.Replace("%SHA%", Sha(Setup))));

        [Fact]
        public async Task A_newer_version_is_downloaded_once_GitHub_vouches_for_it()
        {
            var web = Web(Manifest("1.7.0", Setup));

            var status = await Checker(web).CheckAsync(new Version(1, 6, 0), CancellationToken.None);

            Assert.Equal((UpdateState.Ready, "1.6.0", "1.7.0", "Faster posters."), (status.State, status.Current, status.Available, status.Notes));
            Assert.Equal(Setup, File.ReadAllBytes(Path.Combine(_folder.Path, "SmartRetailAI-Setup-1.7.0.exe")));
            Assert.Equal(new[] { "latest.json", "jwks", "SmartRetailAI-Setup-1.7.0.exe" }, web.Asked.Select(u => u.Segments.Last()));
            Assert.StartsWith("check=", web.Asked[0].Query.TrimStart('?'));
            Assert.Equal(UpdateState.Ready, UpdateFolder.Load(_folder.Path).State);

            // Checked again: nothing downloaded twice.
            var again = Web(Manifest("1.7.0", Setup));
            Assert.Equal(UpdateState.Ready, (await Checker(again).CheckAsync(new Version(1, 6, 0), CancellationToken.None)).State);
            Assert.DoesNotContain(again.Asked, u => u.AbsolutePath.EndsWith(".exe", StringComparison.Ordinal));
        }

        [Fact]
        public async Task The_same_version_is_up_to_date_and_an_older_download_goes()
        {
            File.WriteAllBytes(Path.Combine(_folder.Path, "SmartRetailAI-Setup-1.6.0.exe"), Setup);
            var web = Web(Manifest("1.7.0", Setup));

            var status = await Checker(web).CheckAsync(new Version(1, 7, 0), CancellationToken.None);

            Assert.Equal(UpdateState.UpToDate, status.State);
            Assert.Single(web.Asked);
            Assert.False(File.Exists(Path.Combine(_folder.Path, "SmartRetailAI-Setup-1.6.0.exe")));
        }

        [Fact]
        public async Task An_update_GitHub_did_not_vouch_for_is_never_downloaded()
        {
            var claims = Claims("1.7.0", Setup);
            claims["repository_id"] = "42";
            var web = Web(Manifest("1.7.0", Setup, Token(claims)));

            var status = await Checker(web).CheckAsync(new Version(1, 6, 0), CancellationToken.None);

            Assert.Equal(UpdateState.Failed, status.State);
            Assert.Contains("was not published by the app's own release (it comes from another repository)", status.Problem);
            Assert.DoesNotContain(web.Asked, u => u.AbsolutePath.EndsWith(".exe", StringComparison.Ordinal));
            Assert.Empty(Directory.GetFiles(_folder.Path, "*.exe*"));
        }

        [Fact]
        public async Task A_setup_that_came_down_different_or_too_big_is_not_kept()
        {
            var changed = await Checker(Web(Manifest("1.7.0", Setup), Encoding.ASCII.GetBytes("MZ something else here"))).CheckAsync(new Version(1, 6, 0), CancellationToken.None);
            Assert.Equal(UpdateState.Failed, changed.State);
            Assert.Contains("came down different from what was published", changed.Problem);

            var tooBig = await Checker(Web(Manifest("1.7.0", Setup), Setup.Concat(new byte[100]).ToArray())).CheckAsync(new Version(1, 6, 0), CancellationToken.None);
            Assert.Equal(UpdateState.Failed, tooBig.State);
            Assert.Contains("sent more than was expected", tooBig.Problem);
            Assert.Empty(Directory.GetFiles(_folder.Path, "*.exe*"));
        }

        [Fact]
        public async Task A_folder_that_cannot_be_read_is_a_failure_to_show()
        {
            var web = new RoutedHttpHandler();

            var status = await Checker(web).CheckAsync(new Version(1, 6, 0), CancellationToken.None);

            Assert.Equal(UpdateState.Failed, status.State);
            Assert.Equal("shop.supabase.co answered 404 for /storage/v1/object/public/app-updates/latest.json.", status.Problem);
            Assert.Equal(_now, UpdateFolder.Load(_folder.Path).CheckedAt);
        }

        /// <summary>Bytes that differ from one to the next, so a piece in the wrong place changes the whole's SHA-256.</summary>
        private static byte[] Big(int length)
        {
            var bytes = new byte[length];
            var random = new Random(7);
            random.NextBytes(bytes);
            return bytes;
        }

        private RoutedHttpHandler WebInPieces(byte[] setup, long partSize, string version = "1.7.0", Action<RoutedHttpHandler> change = null)
        {
            var web = new RoutedHttpHandler()
                .On("/storage/v1/object/public/app-updates/latest.json", Manifest(version, setup, partSize: partSize))
                .On("/.well-known/jwks", Keys);
            var manifest = UpdateManifest.Parse(Manifest(version, setup, partSize: partSize));
            for (var number = 1; number <= manifest.PartCount; number++)
            {
                web.On("/storage/v1/object/public/app-updates/" + manifest.PartName(number),
                    setup.Skip((int)(partSize * (number - 1))).Take((int)manifest.PartLength(number)).ToArray());
            }

            change?.Invoke(web);
            return web;
        }

        [Fact]
        public async Task A_setup_kept_in_pieces_is_joined_and_checked_as_a_whole()
        {
            var big = Big(2 * 1024 * 1024 + 500_000);
            var web = WebInPieces(big, 1024 * 1024);

            var status = await Checker(web).CheckAsync(new Version(1, 6, 0), CancellationToken.None);

            Assert.Equal(UpdateState.Ready, status.State);
            Assert.Equal(big, File.ReadAllBytes(Path.Combine(_folder.Path, "SmartRetailAI-Setup-1.7.0.exe")));
            Assert.Equal(new[] { "latest.json", "jwks", "SmartRetailAI-Setup-1.7.0.exe.001", "SmartRetailAI-Setup-1.7.0.exe.002", "SmartRetailAI-Setup-1.7.0.exe.003" }, web.Asked.Select(u => u.Segments.Last()));
            Assert.Empty(Directory.GetFiles(_folder.Path, "*.part"));
        }

        [Fact]
        public async Task A_piece_that_is_short_missing_or_swapped_is_never_kept()
        {
            var big = Big(2 * 1024 * 1024 + 500_000);
            var third = "/storage/v1/object/public/app-updates/SmartRetailAI-Setup-1.7.0.exe.003";

            var shortPiece = await Checker(WebInPieces(big, 1024 * 1024, change: web => web.On(third, new byte[10]))).CheckAsync(new Version(1, 6, 0), CancellationToken.None);
            Assert.Equal(UpdateState.Failed, shortPiece.State);
            Assert.Contains("came down different from what was published", shortPiece.Problem);

            var missing = await Checker(WebInPieces(big, 1024 * 1024, change: web => web.Remove(third))).CheckAsync(new Version(1, 6, 0), CancellationToken.None);
            Assert.Equal(UpdateState.Failed, missing.State);
            Assert.Contains("could not be downloaded (404)", missing.Problem);

            // The right size, but not the bytes GitHub signed for.
            var swapped = await Checker(WebInPieces(big, 1024 * 1024, change: web => web.On(third, new byte[500_000]))).CheckAsync(new Version(1, 6, 0), CancellationToken.None);
            Assert.Equal(UpdateState.Failed, swapped.State);
            Assert.Contains("came down different from what was published", swapped.Problem);

            var tooBig = await Checker(WebInPieces(big, 1024 * 1024, change: web => web.On(third, new byte[500_001]))).CheckAsync(new Version(1, 6, 0), CancellationToken.None);
            Assert.Equal(UpdateState.Failed, tooBig.State);
            Assert.Contains("sent more than was expected", tooBig.Problem);

            Assert.Empty(Directory.GetFiles(_folder.Path, "*.exe*"));
        }

        [Theory]
        [InlineData(1L)]
        [InlineData(1024L * 1024 - 1)]
        [InlineData(65L * 1024 * 1024)]
        [InlineData(-5L)]
        public void Pieces_of_a_silly_size_are_refused(long partSize) =>
            Assert.Throws<UpdateException>(() => UpdateManifest.Parse(Manifest("1.7.0", Setup, partSize: partSize)));

        [Fact]
        public void Too_many_pieces_are_refused_and_a_sensible_split_is_counted()
        {
            var many = JObject.Parse(Manifest("1.7.0", Setup));
            many["Size"] = 100L * 1024 * 1024;
            many["PartSize"] = 1024 * 1024;
            Assert.Throws<UpdateException>(() => UpdateManifest.Parse(many.ToString()));

            var fine = JObject.Parse(Manifest("1.7.0", Setup));
            fine["Size"] = 52_822_912L;
            fine["PartSize"] = 32L * 1024 * 1024;
            var manifest = UpdateManifest.Parse(fine.ToString());
            Assert.Equal(2, manifest.PartCount);
            Assert.Equal(new[] { "SmartRetailAI-Setup-1.7.0.exe.001", "SmartRetailAI-Setup-1.7.0.exe.002" }, new[] { manifest.PartName(1), manifest.PartName(2) });
            Assert.Equal(52_822_912L, manifest.PartLength(1) + manifest.PartLength(2));

            Assert.Equal(1, UpdateManifest.Parse(Manifest("1.7.0", Setup)).PartCount);
            Assert.Equal("SmartRetailAI-Setup-1.7.0.exe", UpdateManifest.Parse(Manifest("1.7.0", Setup)).PartName(1));
        }

        [Fact]
        public async Task An_answer_that_came_over_http_or_from_another_host_is_not_used()
        {
            // The list of GitHub's keys is the root of trust: it must come from GitHub, over https, whatever a redirect does.
            var otherHost = Web(Manifest("1.7.0", Setup)).Redirected("/.well-known/jwks", "https://keys.example.com/.well-known/jwks");
            var fromElsewhere = await Checker(otherHost).CheckAsync(new Version(1, 6, 0), CancellationToken.None);
            Assert.Equal(UpdateState.Failed, fromElsewhere.State);
            Assert.Contains("cannot be trusted", fromElsewhere.Problem);

            var plain = Web(Manifest("1.7.0", Setup)).Redirected("/storage/v1/object/public/app-updates/latest.json", "http://shop.supabase.co/storage/v1/object/public/app-updates/latest.json");
            var overHttp = await Checker(plain).CheckAsync(new Version(1, 6, 0), CancellationToken.None);
            Assert.Equal(UpdateState.Failed, overHttp.State);
            Assert.Contains("cannot be trusted", overHttp.Problem);
            Assert.DoesNotContain(plain.Asked, u => u.AbsolutePath.EndsWith(".exe", StringComparison.Ordinal));
        }

        [Fact]
        public void Update_settings_exist_only_when_the_build_kept_all_of_them_in_the_form_GitHub_uses()
        {
            var good = new Dictionary<string, string>
            {
                [UpdateSettings.FeedKey] = "https://shop.supabase.co/storage/v1/object/public/app-updates/",
                [UpdateSettings.RepositoryIdKey] = "1384926224",
                [UpdateSettings.OwnerIdKey] = "260031592",
                [UpdateSettings.RefKey] = "refs/heads/main",
                [UpdateSettings.WorkflowKey] = ".github/workflows/installer.yml",
            };
            UpdateSettings Made(Action<Dictionary<string, string>> change = null)
            {
                var copy = new Dictionary<string, string>(good);
                change?.Invoke(copy);
                return UpdateSettings.From(key => copy.TryGetValue(key, out var value) ? value : null);
            }

            var settings = Made();
            Assert.NotNull(settings);
            Assert.Equal("1384926224", settings.Source.RepositoryId);
            Assert.Equal(".github/workflows/installer.yml", settings.Source.WorkflowPath);

            Assert.Null(UpdateSettings.From(null));
            Assert.Null(Made(c => c.Remove(UpdateSettings.FeedKey)));
            Assert.Null(Made(c => c[UpdateSettings.FeedKey] = "http://shop.supabase.co/storage/v1/object/public/app-updates/"));
            Assert.Null(Made(c => c[UpdateSettings.FeedKey] = "https://user:pass@shop.supabase.co/updates/"));
            Assert.Null(Made(c => c[UpdateSettings.FeedKey] = "https://shop.supabase.co/updates/?x=1"));
            Assert.Null(Made(c => c.Remove(UpdateSettings.RepositoryIdKey)));
            Assert.Null(Made(c => c[UpdateSettings.RepositoryIdKey] = "smartave99/Test"));
            Assert.Null(Made(c => c[UpdateSettings.OwnerIdKey] = ""));
            Assert.Null(Made(c => c[UpdateSettings.RefKey] = "refs/pull/1/merge"));
            Assert.Null(Made(c => c[UpdateSettings.RefKey] = "main"));
            Assert.Null(Made(c => c[UpdateSettings.WorkflowKey] = "../../evil.yml"));
            Assert.Null(Made(c => c[UpdateSettings.WorkflowKey] = ".github/workflows/installer.exe"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("not json")]
        [InlineData("[1, 2]")]
        [InlineData("{\"State\":\"Exploded\"}")]
        [InlineData("{\"State\":\"Ready\",\"Notes\":null,\"Problem\":null,\"Current\":null,\"Available\":null,\"File\":null,\"Sha256\":null}")]
        public void A_status_file_that_is_damaged_or_edited_by_hand_reads_as_a_whole_status(string json)
        {
            File.WriteAllText(Path.Combine(_folder.Path, UpdateFolder.StatusFileName), json);

            var status = UpdateFolder.Load(_folder.Path);

            Assert.All(new[] { status.Current, status.Available, status.File, status.Sha256, status.Notes, status.Problem }, text => Assert.NotNull(text));
        }

        private static UpdateStatus Ready(string version = "9.9.9") => new UpdateStatus
        {
            State = UpdateState.Ready,
            Available = version,
            File = UpdateManifest.SetupFileName(version),
            Sha256 = Sha(Setup),
        };

        [Fact]
        public void Only_a_checked_newer_update_written_the_way_the_release_writes_it_may_be_installed()
        {
            Assert.Null(UpdateInstallRules.Problem(Ready(), new Version(2, 9, 0)));
            Assert.Null(UpdateInstallRules.Problem(Ready("2.10.0"), new Version(2, 9, 0)));

            const string none = "No update is ready to install.";
            Assert.Equal(none, UpdateInstallRules.Problem(null, new Version(2, 9, 0)));
            Assert.Equal(none, UpdateInstallRules.Problem(new UpdateStatus { State = UpdateState.UpToDate }, new Version(2, 9, 0)));
            Assert.Equal(none, UpdateInstallRules.Problem(new UpdateStatus { State = UpdateState.Failed, Problem = "x" }, new Version(2, 9, 0)));

            var badVersion = Ready();
            badVersion.Available = "9.9";
            Assert.Equal(none, UpdateInstallRules.Problem(badVersion, new Version(2, 9, 0)));

            var otherFile = Ready();
            otherFile.File = "..\\evil.exe";
            Assert.Equal(none, UpdateInstallRules.Problem(otherFile, new Version(2, 9, 0)));

            var otherVersionFile = Ready();
            otherVersionFile.File = UpdateManifest.SetupFileName("1.0.0");
            Assert.Equal(none, UpdateInstallRules.Problem(otherVersionFile, new Version(2, 9, 0)));

            foreach (var sha in new[] { "", "ABC", new string('A', 64), new string('g', 64), new string('a', 63) })
            {
                var bad = Ready();
                bad.Sha256 = sha;
                Assert.Equal(none, UpdateInstallRules.Problem(bad, new Version(2, 9, 0)));
            }
        }

        [Fact]
        public void The_version_that_is_running_or_a_newer_one_is_never_installed_over_itself()
        {
            Assert.Equal("Version 9.9.9 is already installed, or newer is.", UpdateInstallRules.Problem(Ready(), new Version(9, 9, 9)));
            Assert.Equal("Version 9.9.9 is already installed, or newer is.", UpdateInstallRules.Problem(Ready(), new Version(10, 0, 0)));
            Assert.Null(UpdateInstallRules.Problem(Ready(), new Version(9, 9, 8)));
        }

        [Theory]
        [InlineData("https://shop.supabase.co/storage/v1/object/public/app-updates/", true)]
        [InlineData("http://shop.supabase.co/storage/v1/object/public/app-updates/", false)]
        [InlineData("https://shop.supabase.co/storage/v1/object/public/app-updates", false)]
        public void Only_an_https_folder_is_used(string feed, bool usable) =>
            Assert.Equal(usable, UpdateChecker.IsUsable(new Uri(feed)));
    }

    /// <summary>Stand-in for the web: answers by path, 404 for anything else, and records what was asked.</summary>
    internal sealed class RoutedHttpHandler : HttpMessageHandler
    {
        private readonly Dictionary<string, byte[]> _answers = new Dictionary<string, byte[]>();
        private readonly Dictionary<string, Uri> _redirects = new Dictionary<string, Uri>();

        public List<Uri> Asked { get; } = new List<Uri>();

        public RoutedHttpHandler On(string path, string text) => On(path, Encoding.UTF8.GetBytes(text));

        public RoutedHttpHandler On(string path, byte[] body)
        {
            _answers[path] = body;
            return this;
        }

        public RoutedHttpHandler Remove(string path)
        {
            _answers.Remove(path);
            return this;
        }

        /// <summary>Answers the path as if a redirect had sent the request to <paramref name="finalUrl"/>.</summary>
        public RoutedHttpHandler Redirected(string path, string finalUrl)
        {
            _redirects[path] = new Uri(finalUrl);
            return this;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Asked.Add(request.RequestUri);
            if (!_answers.TryGetValue(request.RequestUri.AbsolutePath, out var body))
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(body) };
            if (_redirects.TryGetValue(request.RequestUri.AbsolutePath, out var final))
            {
                response.RequestMessage = new HttpRequestMessage(HttpMethod.Get, final);
            }

            return Task.FromResult(response);
        }
    }
}

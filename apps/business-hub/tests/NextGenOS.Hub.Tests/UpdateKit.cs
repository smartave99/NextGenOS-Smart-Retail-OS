using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using NextGenOS.Hub.Updates;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// What the update tests stand on: a stand-in for GitHub that signs the way GitHub signs (RS256, a published key), and a stand-in for the online update folder that serves files from
/// memory and writes down every request it was asked for, so a test can say exactly what was and was not sent.
/// </summary>
internal sealed class GitHubStandIn : IDisposable
{
    public const string Repository = "nextgenos/smart-retail";
    public const string Workflow = ".github/workflows/release.yml";

    public static readonly ReleaseSource Source = new("111", "222", Workflow);

    public RSA Key { get; } = RSA.Create(2048);
    public string Kid { get; } = "test-key-1";

    public void Dispose() => Key.Dispose();

    /// <summary>The keys GitHub publishes (what the Hub is told to trust).</summary>
    public string KeysJson(RSA? key = null, string? kid = null)
    {
        var parameters = (key ?? Key).ExportParameters(false);
        return new JsonObject
        {
            ["keys"] = new JsonArray(new JsonObject
            {
                ["kty"] = "RSA", ["use"] = "sig", ["alg"] = "RS256", ["kid"] = kid ?? Kid,
                ["n"] = B64(parameters.Modulus!), ["e"] = B64(parameters.Exponent!),
            }),
        }.ToJsonString();
    }

    /// <summary>A statement for a setup, as the release workflow would get it: <paramref name="change"/> lets a test spoil one claim.</summary>
    public string Statement(string version, string sha, Action<JsonObject>? change = null, RSA? signWith = null, string? kid = null, string alg = "RS256")
    {
        var reference = "refs/tags/v" + version;
        var claims = new JsonObject
        {
            ["iss"] = ReleaseStatement.Issuer,
            ["aud"] = UpdateManifest.AudienceFor(version, sha),
            ["repository"] = Repository,
            ["repository_id"] = Source.RepositoryId,
            ["repository_owner_id"] = Source.OwnerId,
            ["ref"] = reference,
            ["workflow_ref"] = Repository + "/" + Workflow + "@" + reference,
            ["event_name"] = "push",
            ["exp"] = 1,   // long past: the statement is kept as a signature, never used to sign in
        };
        change?.Invoke(claims);
        var header = new JsonObject { ["alg"] = alg, ["kid"] = kid ?? Kid, ["typ"] = "JWT" };
        var signed = B64(Encoding.UTF8.GetBytes(header.ToJsonString())) + "." + B64(Encoding.UTF8.GetBytes(claims.ToJsonString()));
        var signature = (signWith ?? Key).SignData(Encoding.ASCII.GetBytes(signed), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        return signed + "." + B64(signature);
    }

    public static string B64(byte[] bytes) => Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
}

/// <summary>The online folder, in memory. Every request is written down with its address and its user-agent line.</summary>
internal sealed class FeedStandIn : HttpMessageHandler
{
    public static readonly Uri Folder = new("https://updates.example.test/hub/");

    private readonly Dictionary<string, byte[]> files = new(StringComparer.Ordinal);
    private readonly Dictionary<string, Uri> redirects = new(StringComparer.Ordinal);
    private readonly HashSet<string> unreachable = new(StringComparer.Ordinal);

    public List<(Uri Url, string? Agent, HttpMethod Method, int Headers)> Asked { get; } = [];

    /// <summary>When set, every request waits for it before it is answered (to have two looks at once).</summary>
    public Task? Hold { get; set; }

    public void Put(string url, byte[] body) => files[url] = body;
    public void Put(string url, string text) => files[url] = Encoding.UTF8.GetBytes(text);
    public void Remove(string url) => files.Remove(url);
    public void Redirect(string url, Uri to) => redirects[url] = to;
    public void Break(string url) => unreachable.Add(url);
    public void Mend(string url) => unreachable.Remove(url);

    public IEnumerable<Uri> AskedFor(string pathEnd) => Asked.Where(a => a.Url.AbsolutePath.EndsWith(pathEnd, StringComparison.Ordinal)).Select(a => a.Url);

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (Hold is { } hold) await hold;
        var url = request.RequestUri!;
        Asked.Add((url, request.Headers.UserAgent.ToString() is { Length: > 0 } agent ? agent : null, request.Method, request.Headers.Count()));
        var key = url.GetLeftPart(UriPartial.Path);
        if (unreachable.Contains(key)) throw new HttpRequestException("No such host is known.");
        var response = new HttpResponseMessage();
        if (redirects.TryGetValue(key, out var to))
        {
            response.RequestMessage = new HttpRequestMessage(HttpMethod.Get, to);   // what the client sees after following a redirect
            response.Content = new ByteArrayContent(files.TryGetValue(to.GetLeftPart(UriPartial.Path), out var moved) ? moved : []);
            return response;
        }
        response.RequestMessage = request;
        if (!files.TryGetValue(key, out var body))
        {
            response.StatusCode = System.Net.HttpStatusCode.NotFound;
            return response;
        }
        response.Content = new ByteArrayContent(body);
        return response;
    }

    public static string Url(string name) => new Uri(Folder, name).ToString();
}

/// <summary>A published version: the bytes of the setup and the description beside it.</summary>
internal sealed class Published
{
    public required string Version { get; init; }
    public required byte[] Setup { get; init; }
    public required string Sha { get; init; }
    public long PartSize { get; init; }

    public static Published Make(string version, int size = 4096, int seed = 7, long partSize = 0)
    {
        var bytes = new byte[size];
        new Random(seed).NextBytes(bytes);
        return new Published { Version = version, Setup = bytes, Sha = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant(), PartSize = partSize };
    }

    public string Name => UpdateManifest.SetupFileName(Version);

    /// <summary>Puts the setup (whole or in pieces) and its description into the stand-in folder, with a statement from <paramref name="github"/>.</summary>
    public void PutIn(FeedStandIn feed, GitHubStandIn github, Action<JsonObject>? change = null, string? statement = null, string notes = "Faster checkout.")
    {
        var manifest = new UpdateManifest { Version = Version, File = Name, Sha256 = Sha, Size = Setup.Length, PartSize = PartSize, Notes = notes, Statement = statement ?? github.Statement(Version, Sha, change) };
        if (PartSize <= 0) feed.Put(FeedStandIn.Url(Name), Setup);
        else
        {
            for (var n = 1; n <= manifest.PartCount; n++)
                feed.Put(FeedStandIn.Url(manifest.PartName(n)), Setup.AsSpan((int)(PartSize * (n - 1)), (int)manifest.PartLength(n)).ToArray());
        }
        feed.Put(FeedStandIn.Url(UpdateManifest.FeedFile), JsonSerializer.Serialize(new { manifest.Version, manifest.File, manifest.Sha256, manifest.Size, manifest.PartSize, manifest.Notes, manifest.Statement }));
        feed.Put(ReleaseStatement.KeysUrl.ToString(), github.KeysJson());
    }
}

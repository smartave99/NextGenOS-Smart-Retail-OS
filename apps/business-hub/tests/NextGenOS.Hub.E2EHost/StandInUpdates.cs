using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using NextGenOS.Hub.Updates;

namespace NextGenOS.Hub.E2EHost;

/// <summary>
/// Only for the browser test of the Updates page (--E2E:Updates=true): this test program is not shipped. A stand-in for the online update folder and for GitHub's signing, in memory, so that
/// the real checker (the statement is really verified, the file is really downloaded, checked and kept) runs without an internet. The test publishes a version through a door.
/// </summary>
internal sealed class StandInUpdates : HttpMessageHandler
{
    private static readonly Uri Folder = new("https://updates.example.test/hub/");
    private const string Repository = "nextgenos/smart-retail", Workflow = ".github/workflows/release.yml";
    private readonly RSA key = RSA.Create(2048);
    private readonly Dictionary<string, byte[]> files = new();

    public StandInUpdates(string dataFolder)
    {
        Options = new UpdateOptions(new UpdateSettings(Folder, new ReleaseSource("111", "222", Workflow)), Path.Combine(dataFolder, "updates"), new Version(1, 0, 0), () => new HttpClient(this, disposeHandler: false));
        var p = key.ExportParameters(false);
        files[ReleaseStatement.KeysUrl.ToString()] = Encoding.UTF8.GetBytes(new JsonObject
        {
            ["keys"] = new JsonArray(new JsonObject { ["kty"] = "RSA", ["use"] = "sig", ["kid"] = "k1", ["n"] = B64(p.Modulus!), ["e"] = B64(p.Exponent!) }),
        }.ToJsonString());
    }

    public UpdateOptions Options { get; }

    /// <summary>Puts a version into the stand-in folder, signed the way the release workflow gets it signed.</summary>
    public void Publish(string version, string notes)
    {
        var setup = new byte[20_000];
        new Random(11).NextBytes(setup);
        var sha = Convert.ToHexString(SHA256.HashData(setup)).ToLowerInvariant();
        var name = UpdateManifest.SetupFileName(version);
        var reference = "refs/tags/v" + version;
        var claims = new JsonObject
        {
            ["iss"] = ReleaseStatement.Issuer, ["aud"] = UpdateManifest.AudienceFor(version, sha), ["repository"] = Repository, ["repository_id"] = "111", ["repository_owner_id"] = "222",
            ["ref"] = reference, ["workflow_ref"] = Repository + "/" + Workflow + "@" + reference, ["event_name"] = "push",
        };
        var signed = B64(Encoding.UTF8.GetBytes(new JsonObject { ["alg"] = "RS256", ["kid"] = "k1" }.ToJsonString())) + "." + B64(Encoding.UTF8.GetBytes(claims.ToJsonString()));
        var statement = signed + "." + B64(key.SignData(Encoding.ASCII.GetBytes(signed), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        files[new Uri(Folder, name).ToString()] = setup;
        files[new Uri(Folder, UpdateManifest.FeedFile).ToString()] = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { Version = version, File = name, Sha256 = sha, Size = setup.Length, PartSize = 0, Notes = notes, Statement = statement }));
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage { RequestMessage = request };
        if (files.TryGetValue(request.RequestUri!.GetLeftPart(UriPartial.Path), out var body)) response.Content = new ByteArrayContent(body);
        else response.StatusCode = System.Net.HttpStatusCode.NotFound;
        return Task.FromResult(response);
    }

    private static string B64(byte[] bytes) => Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
}

using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace NextGenOS.Hub.Updates;

/// <summary>
/// The project's own release workflow, as GitHub names it in its statements: the repository and its owner by their numbers (which never change, even if the repository is renamed) and
/// the workflow file. A copy of the Hub is built to trust the repository that built it (<see cref="UpdateSettings"/>), so moving the project never lets the old one's statements through
/// by accident. A real release is made by pushing a version tag such as v1.2.3 (<see cref="ReleaseTag"/>): not a test version (v1.2.3-rc1), not the Studio's release, not a branch.
/// </summary>
public sealed record ReleaseSource(string RepositoryId, string OwnerId, string WorkflowPath)
{
    /// <summary>The way a real release starts: a tag pushed to the repository.</summary>
    public const string ReleaseEvent = "push";

    /// <summary>A tag of exactly three numbers after a "v".</summary>
    public static readonly Regex ReleaseTag = new(@"^refs/tags/v(\d{1,4}\.\d{1,4}\.\d{1,4})$", RegexOptions.CultureInvariant);
}

/// <summary>
/// GitHub's word that a setup came from the project's own release workflow. The workflow asks GitHub Actions for an OIDC token whose audience is the setup's version and SHA-256; GitHub
/// signs it (RS256) with a key it publishes. Nobody else can make one: not whoever can write to the download folder, nor a workflow on a branch, in a pull request or in another
/// repository. The token's expiry is not checked: it is kept as a signed statement, never used to sign in. This is why no update-signing key has to be kept by anyone.
/// </summary>
public static class ReleaseStatement
{
    public const string Issuer = "https://token.actions.githubusercontent.com";

    public static Uri KeysUrl { get; } = new(Issuer + "/.well-known/jwks");

    /// <summary>Why the statement does not hold for this setup, or null when it does.</summary>
    /// <param name="version">The version the description claims; the tag the statement names must be exactly that version.</param>
    public static string? Check(string? token, string? keysJson, ReleaseSource source, string audience, string version)
    {
        var parts = (token ?? "").Split('.');
        if (parts.Length != 3) return "it is not a signed statement";

        JsonNode? header, claims;
        byte[] signature;
        try
        {
            header = JsonNode.Parse(Encoding.UTF8.GetString(FromBase64Url(parts[0])));
            claims = JsonNode.Parse(Encoding.UTF8.GetString(FromBase64Url(parts[1])));
            signature = FromBase64Url(parts[2]);
        }
        catch (Exception e) when (e is FormatException or System.Text.Json.JsonException or ArgumentException)
        {
            return "it is not a signed statement";
        }

        if (header is not JsonObject || claims is not JsonObject) return "it is not a signed statement";
        if (Text(header["alg"]) != "RS256") return "it is not signed the way GitHub signs";

        var key = FindKey(keysJson, Text(header["kid"]));
        if (key is null) return "GitHub's key for it was not found";
        using (var rsa = RSA.Create())
        {
            rsa.ImportParameters(key.Value);
            if (!rsa.VerifyData(Encoding.ASCII.GetBytes(parts[0] + "." + parts[1]), signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1))
                return "GitHub's signature does not match";
        }

        if (Text(claims["iss"]) != Issuer) return "it was not made by GitHub Actions";
        if (!Audiences(claims["aud"]).Contains(audience, StringComparer.Ordinal)) return "it is for another version or another file";
        if (Text(claims["repository_id"]) != source.RepositoryId || Text(claims["repository_owner_id"]) != source.OwnerId) return "it comes from another repository";

        var reference = Text(claims["ref"]) ?? "";
        var tag = ReleaseSource.ReleaseTag.Match(reference);
        if (!tag.Success) return "it does not come from a release tag";
        if (tag.Groups[1].Value != version) return "it is for another version than the one described";

        var repository = Text(claims["repository"]) ?? "";
        if (Text(claims["workflow_ref"]) != repository + "/" + source.WorkflowPath + "@" + reference) return "it comes from another workflow";
        if (Text(claims["event_name"]) != ReleaseSource.ReleaseEvent) return "it was not made by a release started with a version tag";
        return null;
    }

    private static string? Text(JsonNode? node) => node is JsonValue value && value.TryGetValue<string>(out var text) ? text : null;

    private static IEnumerable<string> Audiences(JsonNode? aud) =>
        aud is JsonArray many ? many.Select(Text).OfType<string>() : Text(aud) is { } one ? [one] : [];

    internal static byte[] FromBase64Url(string text)
    {
        var base64 = (text ?? "").Replace('-', '+').Replace('_', '/');
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
            case 1: throw new FormatException("Not base64url.");
        }
        return Convert.FromBase64String(base64);
    }

    private static RSAParameters? FindKey(string? keysJson, string? kid)
    {
        if (string.IsNullOrEmpty(kid)) return null;
        try
        {
            var found = (JsonNode.Parse(keysJson ?? "")?["keys"] as JsonArray)?.OfType<JsonObject>()
                .FirstOrDefault(k => Text(k["kid"]) == kid && Text(k["kty"]) == "RSA" && (Text(k["use"]) ?? "sig") == "sig");
            if (found is null || Text(found["n"]) is not { } n || Text(found["e"]) is not { } e) return null;
            return new RSAParameters { Modulus = FromBase64Url(n), Exponent = FromBase64Url(e) };
        }
        catch (Exception e) when (e is FormatException or System.Text.Json.JsonException or ArgumentException)
        {
            return null;
        }
    }
}

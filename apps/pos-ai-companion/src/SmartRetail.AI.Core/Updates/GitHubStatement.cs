using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Updates
{
    /// <summary>
    /// The project's own release workflow, as GitHub names it in its statements: the repository and its owner by their
    /// ids, which never change (a renamed repository keeps them), the branch, the workflow file and the way it was
    /// started. A copy of the app is built to trust the repository that built it (see <see cref="UpdateSettings"/>),
    /// so moving the project to another repository never lets the old one's statements through by accident.
    /// </summary>
    public sealed class ReleaseSource
    {
        /// <summary>The release is started by hand, with its version (workflow_dispatch), never by a push or a pull request.</summary>
        public const string ReleaseEvent = "workflow_dispatch";

        public ReleaseSource(string repositoryId, string ownerId, string branchRef, string workflowPath)
        {
            RepositoryId = repositoryId;
            OwnerId = ownerId;
            Ref = branchRef;
            WorkflowPath = workflowPath;
        }

        public string RepositoryId { get; }

        public string OwnerId { get; }

        /// <summary>For example refs/heads/main.</summary>
        public string Ref { get; }

        /// <summary>For example .github/workflows/installer.yml.</summary>
        public string WorkflowPath { get; }
    }

    /// <summary>
    /// GitHub's word that a setup came from the project's own release workflow. The workflow asks GitHub Actions for an
    /// OIDC token whose audience is the setup's version and SHA-256; GitHub signs it (RS256) with a key it publishes.
    /// Nobody else can make one: not whoever can write to the download folder, nor a workflow on another branch, in a
    /// pull request or in another repository. The token's expiry is not checked: it is kept as a signed statement,
    /// never used to sign in.
    /// </summary>
    public static class GitHubStatement
    {
        public const string Issuer = "https://token.actions.githubusercontent.com";

        public static Uri KeysUrl { get; } = new Uri(Issuer + "/.well-known/jwks");

        /// <summary>Why the statement does not hold for this setup, or null when it does.</summary>
        public static string Check(string token, string keysJson, ReleaseSource source, string audience)
        {
            var parts = (token ?? "").Split('.');
            if (parts.Length != 3)
            {
                return "it is not a signed statement";
            }

            JObject header, claims;
            byte[] signature;
            try
            {
                header = JObject.Parse(Encoding.UTF8.GetString(FromBase64Url(parts[0])));
                claims = JObject.Parse(Encoding.UTF8.GetString(FromBase64Url(parts[1])));
                signature = FromBase64Url(parts[2]);
            }
            catch (Exception ex) when (ex is FormatException || ex is JsonException || ex is ArgumentException)
            {
                return "it is not a signed statement";
            }

            if ((string)header["alg"] != "RS256")
            {
                return "it is not signed the way GitHub signs";
            }

            var key = FindKey(keysJson, (string)header["kid"]);
            if (key == null)
            {
                return "GitHub's key for it was not found";
            }

            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(key.Value);
                var signed = Encoding.ASCII.GetBytes(parts[0] + "." + parts[1]);
                if (!rsa.VerifyData(signed, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1))
                {
                    return "GitHub's signature does not match";
                }
            }

            if ((string)claims["iss"] != Issuer)
            {
                return "it was not made by GitHub Actions";
            }

            if (!Audiences(claims["aud"]).Contains(audience, StringComparer.Ordinal))
            {
                return "it is for another version or another file";
            }

            if ((string)claims["repository_id"] != source.RepositoryId || (string)claims["repository_owner_id"] != source.OwnerId)
            {
                return "it comes from another repository";
            }

            if ((string)claims["ref"] != source.Ref)
            {
                return "it comes from another branch";
            }

            var repository = (string)claims["repository"] ?? "";
            if ((string)claims["workflow_ref"] != repository + "/" + source.WorkflowPath + "@" + source.Ref)
            {
                return "it comes from another workflow";
            }

            if ((string)claims["event_name"] != ReleaseSource.ReleaseEvent)
            {
                return "it was not made by a release started by hand";
            }

            return null;
        }

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

        private static string[] Audiences(JToken aud) =>
            aud is JArray many ? many.Select(a => (string)a).ToArray() : new[] { (string)aud };

        private static RSAParameters? FindKey(string keysJson, string kid)
        {
            if (string.IsNullOrEmpty(kid))
            {
                return null;
            }

            try
            {
                var key = (JObject.Parse(keysJson ?? "")["keys"] as JArray)?.OfType<JObject>().FirstOrDefault(k =>
                    (string)k["kid"] == kid && (string)k["kty"] == "RSA" && ((string)k["use"] ?? "sig") == "sig");
                return key == null
                    ? (RSAParameters?)null
                    : new RSAParameters { Modulus = FromBase64Url((string)key["n"]), Exponent = FromBase64Url((string)key["e"]) };
            }
            catch (Exception ex) when (ex is FormatException || ex is JsonException || ex is ArgumentException)
            {
                return null;
            }
        }
    }
}

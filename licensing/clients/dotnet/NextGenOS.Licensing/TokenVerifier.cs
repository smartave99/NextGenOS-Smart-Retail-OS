using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NextGenOS.Licensing
{
    /// <summary>A public key the app trusts: the key id and the 65-byte uncompressed P-256 point, base64url.</summary>
    public sealed class TrustedKey
    {
        public TrustedKey(string keyId, string publicKey)
        {
            KeyId = keyId;
            PublicKey = publicKey;
        }

        public string KeyId { get; private set; }
        public string PublicKey { get; private set; }
    }

    public sealed class LicenceException : Exception
    {
        public LicenceException(string message) : base(message) { }
    }

    /// <summary>Checks the signature and shape of a NextGen OS token (spec section 3). Throws <see cref="LicenceException"/> for anything wrong.</summary>
    public static class TokenVerifier
    {
        public const string Prefix = "NGOS1";
        public const string Issuer = "nextgenos";

        public static T Verify<T>(string token, IEnumerable<TrustedKey> keys, string expectedType) where T : class
        {
            var parts = (token ?? string.Empty).Trim().Split('.');
            if (parts.Length != 3 || parts[0] != Prefix) throw new LicenceException("Not a NextGen OS token.");

            JObject payload;
            byte[] signature;
            try
            {
                payload = JObject.Parse(Encoding.UTF8.GetString(Base64Url.Decode(parts[1])));
                signature = Base64Url.Decode(parts[2]);
            }
            catch (Exception ex) when (ex is FormatException || ex is JsonException)
            {
                throw new LicenceException("The token is damaged.");
            }

            if ((string)payload["iss"] != Issuer) throw new LicenceException("Wrong issuer.");
            var kid = (string)payload["kid"];
            var key = (keys ?? Enumerable.Empty<TrustedKey>()).FirstOrDefault(k => k.KeyId == kid);
            if (key == null) throw new LicenceException("Unknown signing key.");
            if (signature.Length != 64) throw new LicenceException("Signature does not match.");

            bool ok;
            try
            {
                using (var ecdsa = CreateKey(key.PublicKey))
                {
                    ok = ecdsa.VerifyData(Encoding.ASCII.GetBytes(parts[0] + "." + parts[1]), signature, HashAlgorithmName.SHA256);
                }
            }
            catch (CryptographicException)
            {
                throw new LicenceException("Signature does not match.");
            }
            if (!ok) throw new LicenceException("Signature does not match.");

            if ((int?)payload["v"] != 1) throw new LicenceException("Unsupported version.");
            if (expectedType != null && (string)payload["typ"] != expectedType) throw new LicenceException("Expected a " + expectedType + " token.");
            return payload.ToObject<T>();
        }

        private static ECDsa CreateKey(string publicKey)
        {
            byte[] point;
            try { point = Base64Url.Decode(publicKey); }
            catch (FormatException) { throw new LicenceException("The built-in public key is damaged."); }
            if (point.Length != 65 || point[0] != 0x04) throw new LicenceException("The built-in public key is damaged.");
            var x = new byte[32];
            var y = new byte[32];
            Buffer.BlockCopy(point, 1, x, 0, 32);
            Buffer.BlockCopy(point, 33, y, 0, 32);
            return ECDsa.Create(new ECParameters { Curve = ECCurve.NamedCurves.nistP256, Q = new ECPoint { X = x, Y = y } });
        }
    }
}

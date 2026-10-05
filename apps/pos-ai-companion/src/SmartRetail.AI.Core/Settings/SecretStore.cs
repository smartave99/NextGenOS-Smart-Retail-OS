using System;
using System.Security.Cryptography;
using System.Text;

namespace SmartRetail.AI.Settings
{
    public static class SecretNames
    {
        public const string OpenAiApiKey = "openai-api-key";
        public const string AnthropicApiKey = "anthropic-api-key";
        public const string GeminiApiKey = "gemini-api-key";
        public const string OpenAiCompatibleApiKey = "openai-compatible-api-key";
        public const string DatabasePassword = "database-password";
    }

    public interface ISecretProtector
    {
        string Protect(string plainText);

        /// <summary>Throws <see cref="CryptographicException"/> when the value cannot be decrypted.</summary>
        string Unprotect(string protectedValue);
    }

    /// <summary>Windows DPAPI, scoped to the current Windows user: a settings file copied to another
    /// PC or account cannot be decrypted there. Windows only.</summary>
#if NET
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public sealed class DpapiSecretProtector : ISecretProtector
    {
        private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("NextGenOS.SmartRetailPOS.AI.v1");

        public string Protect(string plainText)
        {
            var bytes = ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), Entropy, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(bytes);
        }

        public string Unprotect(string protectedValue)
        {
            var bytes = ProtectedData.Unprotect(Convert.FromBase64String(protectedValue), Entropy, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(bytes);
        }
    }

    /// <summary>For systems without DPAPI: saved secrets cannot be read, so API providers report a missing key.</summary>
    public sealed class NoSecretProtector : ISecretProtector
    {
        public string Protect(string plainText) => throw new PlatformNotSupportedException("Secrets can only be saved on Windows.");

        public string Unprotect(string protectedValue) => throw new CryptographicException("Secrets saved on Windows cannot be read here.");
    }

    public sealed class SecretStore
    {
        private readonly Func<AssistantSettings> _settings;
        private readonly ISecretProtector _protector;

        public SecretStore(Func<AssistantSettings> settings, ISecretProtector protector)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _protector = protector ?? throw new ArgumentNullException(nameof(protector));
        }

        /// <summary>Returns null when the secret is missing or was saved by another Windows user.</summary>
        public string Get(string name)
        {
            if (!_settings().ProtectedSecrets.TryGetValue(name, out var value) || string.IsNullOrEmpty(value))
            {
                return null;
            }

            try
            {
                return _protector.Unprotect(value);
            }
            catch (CryptographicException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public bool Has(string name) => !string.IsNullOrEmpty(Get(name));

        /// <summary>Saves the secret; an empty value removes it.</summary>
        public void Set(string name, string value)
        {
            var secrets = _settings().ProtectedSecrets;
            if (string.IsNullOrWhiteSpace(value))
            {
                secrets.Remove(name);
                return;
            }

            secrets[name] = _protector.Protect(value.Trim());
        }
    }
}

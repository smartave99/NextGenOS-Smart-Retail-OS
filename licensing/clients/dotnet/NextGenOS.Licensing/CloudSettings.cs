using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace NextGenOS.Licensing
{
    /// <summary>
    /// Secrets and addresses of a customer's own cloud services (their own Firebase, their own AI key): never in source code.
    /// They are read from <c>cloud.json</c> in the licence folder (written when the customer is set up, and readable only by the
    /// administrators of the PC), or from the environment (NGOS_CLOUD_&lt;NAME&gt;_SECRET and _URL). Nothing set means "not configured":
    /// the secret is empty and the address cannot be reached, which the programs already handle like having no Internet.
    /// </summary>
    public static class CloudSettings
    {
        public const string NotConfiguredUrl = "https://not-configured.invalid/";

        /// <summary>The licence folder of the product that is running, unless a test sets another.</summary>
        public static string Directory { get; set; }

        private static string File_()
        {
            return Path.Combine(Directory ?? LicenceStore.DefaultDirectory("SmartRetailPOS"), "cloud.json");
        }

        private static string Read(string name, string field)
        {
            var env = Environment.GetEnvironmentVariable("NGOS_CLOUD_" + name.ToUpperInvariant() + "_" + field.ToUpperInvariant());
            if (!string.IsNullOrWhiteSpace(env)) return env.Trim();
            try
            {
                var path = File_();
                if (!File.Exists(path)) return string.Empty;
                var node = JObject.Parse(File.ReadAllText(path))[name];
                return node == null ? string.Empty : ((string)node[field] ?? string.Empty).Trim();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>The secret (key or password) of a service, or an empty text.</summary>
        public static string Secret(string name) { return Read(name, "secret"); }

        /// <summary>The address of a service, or an address that cannot be reached.</summary>
        public static string Url(string name)
        {
            var url = Read(name, "url");
            return url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? url : NotConfiguredUrl;
        }

        public static bool IsConfigured(string name) { return Secret(name).Length > 0 && Url(name) != NotConfiguredUrl; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace NextGenOS.Licensing
{
    public sealed class CustomerInfo
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
    }

    public sealed class Limits
    {
        [JsonProperty("devices")] public int Devices { get; set; }
        [JsonProperty("stores")] public int Stores { get; set; }
        [JsonProperty("users")] public int Users { get; set; }
    }

    public sealed class Binding
    {
        [JsonProperty("mode")] public string Mode { get; set; }
        [JsonProperty("domains")] public List<string> Domains { get; set; }
    }

    public sealed class ActivationTerms
    {
        [JsonProperty("online")] public bool Online { get; set; }
        [JsonProperty("checkInDays")] public int CheckInDays { get; set; }
        [JsonProperty("graceDays")] public int GraceDays { get; set; }
        [JsonProperty("offlineDays")] public int OfflineDays { get; set; }
    }

    public sealed class WhiteLabel
    {
        /// <summary>"none", "theme" or "full" (spec section 5.1).</summary>
        [JsonProperty("level")] public string Level { get; set; }
    }

    public sealed class ResellerInfo
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }

    /// <summary>The brand a licence carries (spec section 5). Apps show these names, colours and the logo.</summary>
    public sealed class BrandProfile
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("shortName")] public string ShortName { get; set; }
        [JsonProperty("legalName")] public string LegalName { get; set; }
        [JsonProperty("primaryColor")] public string PrimaryColor { get; set; }
        [JsonProperty("accentColor")] public string AccentColor { get; set; }
        [JsonProperty("supportEmail")] public string SupportEmail { get; set; }
        [JsonProperty("supportPhone")] public string SupportPhone { get; set; }
        [JsonProperty("supportUrl")] public string SupportUrl { get; set; }
        [JsonProperty("websiteUrl")] public string WebsiteUrl { get; set; }
        [JsonProperty("copyright")] public string Copyright { get; set; }
        [JsonProperty("logo")] public string Logo { get; set; }
        [JsonProperty("poweredBy")] public bool PoweredBy { get; set; }

        /// <summary>NextGen OS's own identity, used when there is no licence or the licence has no brand.</summary>
        public static BrandProfile Default()
        {
            return new BrandProfile
            {
                Id = "B-0",
                Name = "Smart Retail OS",
                ShortName = "Smart Retail OS",
                LegalName = "NextGen OS",
                PrimaryColor = "#0f6cbd",
                AccentColor = "#f59e0b",
                Copyright = "© 2026 NextGen OS. All rights reserved.",
                PoweredBy = false,
            };
        }
    }

    public sealed class LicenceClaims
    {
        [JsonProperty("typ")] public string Type { get; set; }
        [JsonProperty("v")] public int Version { get; set; }
        [JsonProperty("iss")] public string Issuer { get; set; }
        [JsonProperty("kid")] public string KeyId { get; set; }
        [JsonProperty("lid")] public string LicenceId { get; set; }
        [JsonProperty("rev")] public int Revision { get; set; }
        [JsonProperty("iat")] public long IssuedAt { get; set; }
        [JsonProperty("nbf")] public long NotBefore { get; set; }
        [JsonProperty("exp")] public long? Expires { get; set; }
        [JsonProperty("cust")] public CustomerInfo Customer { get; set; }
        [JsonProperty("product")] public string Product { get; set; }
        [JsonProperty("edition")] public string Edition { get; set; }
        [JsonProperty("modules")] public List<string> Modules { get; set; }
        [JsonProperty("limits")] public Limits Limits { get; set; }
        [JsonProperty("bind")] public Binding Bind { get; set; }
        [JsonProperty("brand")] public BrandProfile Brand { get; set; }
        [JsonProperty("reseller")] public ResellerInfo Reseller { get; set; }
        [JsonProperty("act")] public ActivationTerms Terms { get; set; }
        [JsonProperty("trial")] public bool Trial { get; set; }
        [JsonProperty("white")] public WhiteLabel White { get; set; }
    }

    public sealed class ActivationClaims
    {
        [JsonProperty("typ")] public string Type { get; set; }
        [JsonProperty("v")] public int Version { get; set; }
        [JsonProperty("iss")] public string Issuer { get; set; }
        [JsonProperty("kid")] public string KeyId { get; set; }
        [JsonProperty("lid")] public string LicenceId { get; set; }
        [JsonProperty("rev")] public int Revision { get; set; }
        [JsonProperty("iat")] public long IssuedAt { get; set; }
        [JsonProperty("fp")] public List<string> Fingerprint { get; set; }
        [JsonProperty("fpMin")] public int FingerprintMin { get; set; }
        [JsonProperty("next")] public long NextCheckIn { get; set; }
        [JsonProperty("until")] public long Until { get; set; }
    }

    public sealed class RevocationListClaims
    {
        [JsonProperty("typ")] public string Type { get; set; }
        [JsonProperty("v")] public int Version { get; set; }
        [JsonProperty("iss")] public string Issuer { get; set; }
        [JsonProperty("kid")] public string KeyId { get; set; }
        [JsonProperty("iat")] public long IssuedAt { get; set; }
        [JsonProperty("next")] public long Next { get; set; }
        [JsonProperty("revoked")] public List<string> Revoked { get; set; }
    }
}

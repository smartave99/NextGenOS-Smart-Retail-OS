using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NextGenOS.Hub.Counters;

/// <summary>
/// The shop's own certificates: one authority made for this shop alone, and one certificate for this PC that the authority signs. A counter PC that trusts the authority (once) can open
/// the Hub over HTTPS with no warning, and nobody outside the shop is involved. The private keys stay in the data folder, in files only the Hub's own account can read, and are never
/// shown, logged or sent anywhere: only the authority's public part (<see cref="CaPem"/>) is ever handed out.
/// </summary>
public sealed class StoreCertificateSet : IDisposable
{
    internal StoreCertificateSet(X509Certificate2 server, string caPem, string caFingerprint, DateTimeOffset caExpires, bool authorityMade, bool serverMade, IReadOnlyList<string> names)
    {
        Server = server;
        CaPem = caPem;
        CaFingerprint = caFingerprint;
        CaExpires = caExpires;
        AuthorityMade = authorityMade;
        ServerMade = serverMade;
        Names = names;
    }

    /// <summary>The certificate of this PC, with its key: handed to the web server and nowhere else.</summary>
    public X509Certificate2 Server { get; }

    /// <summary>The authority's certificate, public part only, as text to save in a file.</summary>
    public string CaPem { get; }

    /// <summary>SHA-256 of the authority's certificate, as 64 capital hexadecimal characters. People compare it by eye to be sure they trust the right one.</summary>
    public string CaFingerprint { get; }

    public DateTimeOffset CaExpires { get; }

    public DateTimeOffset ServerExpires => new(Server.NotAfter.ToUniversalTime());

    /// <summary>True when a new authority was made at this start (the first time, or the old one was missing, damaged or about to end): every counter PC must trust it again.</summary>
    public bool AuthorityMade { get; }

    /// <summary>True when a new certificate for this PC was made at this start (the first time, the PC's name or addresses changed, or the old one was about to end).</summary>
    public bool ServerMade { get; }

    /// <summary>The names and addresses the certificate is valid for.</summary>
    public IReadOnlyList<string> Names { get; }

    public void Dispose() => Server.Dispose();
}

public static class StoreCertificates
{
    public const string FolderName = "network";
    private const string AuthorityCertFile = "store-authority.crt";
    private const string AuthorityKeyFile = "store-authority.key";
    private const string ServerCertFile = "this-pc.crt";
    private const string ServerKeyFile = "this-pc.key";

    /// <summary>The authority lasts ten years. The PC's certificate lasts a little over two years (some systems refuse longer ones for an authority the person added themselves).</summary>
    private static readonly TimeSpan AuthorityLife = TimeSpan.FromDays(3650);
    private static readonly TimeSpan ServerLife = TimeSpan.FromDays(800);
    private static readonly TimeSpan AuthorityRenewBefore = TimeSpan.FromDays(60);
    private static readonly TimeSpan ServerRenewBefore = TimeSpan.FromDays(30);
    private static readonly TimeSpan BackDate = TimeSpan.FromDays(1);
    private const string ServerAuth = "1.3.6.1.5.5.7.3.1";

    public static string FolderIn(string dataFolder) => Path.Combine(dataFolder, FolderName);

    /// <summary>
    /// Makes sure the certificates exist and fit this PC, and loads them. The authority is made once and kept (counter PCs trust it once); the PC's certificate is made again, signed by
    /// the same authority, when it is missing or damaged, when this PC's name or addresses are not all in it, or when it is about to end. Throws when the files cannot be written or read.
    /// </summary>
    public static StoreCertificateSet Ensure(string dataFolder, HostIdentity identity, DateTimeOffset now)
    {
        var folder = FolderIn(dataFolder);
        Private.MakeFolder(folder);
        var (dns, addresses) = Wanted(identity);

        var authorityMade = false;
        var ca = TryLoad(Path.Combine(folder, AuthorityCertFile), Path.Combine(folder, AuthorityKeyFile));
        if (ca is null || !IsUsableAuthority(ca, now))
        {
            ca?.Dispose();
            ca = MakeAuthority(identity, now);
            Private.WriteFile(Path.Combine(folder, AuthorityCertFile), Encoding.ASCII.GetBytes(ca.ExportCertificatePem()));
            Private.WriteFile(Path.Combine(folder, AuthorityKeyFile), Encoding.ASCII.GetBytes(PrivateKeyPem(ca)));
            authorityMade = true;
        }

        try
        {
            var server = authorityMade ? null : TryLoad(Path.Combine(folder, ServerCertFile), Path.Combine(folder, ServerKeyFile));
            var serverMade = false;
            if (server is null || !Fits(server, ca, dns, addresses, now))
            {
                server?.Dispose();
                server = MakeServer(ca, dns, addresses, now);
                Private.WriteFile(Path.Combine(folder, ServerCertFile), Encoding.ASCII.GetBytes(server.ExportCertificatePem()));
                Private.WriteFile(Path.Combine(folder, ServerKeyFile), Encoding.ASCII.GetBytes(PrivateKeyPem(server)));
                serverMade = true;
            }

            var names = dns.Concat(addresses.Select(a => a.ToString())).ToList();
            var caPem = ca.ExportCertificatePem();
            return new StoreCertificateSet(ForTheWebServer(server), caPem, Fingerprint(ca), new DateTimeOffset(ca.NotAfter.ToUniversalTime()), authorityMade, serverMade, names);
        }
        finally
        {
            ca.Dispose();
        }
    }

    /// <summary>SHA-256 of the certificate, as 64 capital hexadecimal characters.</summary>
    public static string Fingerprint(X509Certificate2 certificate) => Convert.ToHexString(SHA256.HashData(certificate.RawData));

    /// <summary>The fingerprint in groups of four characters, easier to compare by eye: <c>AB12 CD34 ...</c></summary>
    public static string Spaced(string fingerprint) => string.Join(' ', Enumerable.Range(0, (fingerprint.Length + 3) / 4).Select(i => fingerprint.Substring(i * 4, Math.Min(4, fingerprint.Length - i * 4))));

    /// <summary>True when a PC that trusts <paramref name="authorityPem"/> accepts <paramref name="server"/>: the chain leads to it. (Used by the tests, and by the program to notice a certificate made by another authority.)</summary>
    public static bool ChainsTo(X509Certificate2 server, string authorityPem, DateTimeOffset now)
    {
        using var authority = X509Certificate2.CreateFromPem(authorityPem);
        return ChainsTo(server, authority, now);
    }

    private static bool ChainsTo(X509Certificate2 server, X509Certificate2 authority, DateTimeOffset now)
    {
        using var chain = new X509Chain();
        chain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;
        chain.ChainPolicy.CustomTrustStore.Add(authority);
        chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        chain.ChainPolicy.VerificationTime = now.UtcDateTime;
        chain.ChainPolicy.ApplicationPolicy.Add(new Oid(ServerAuth));
        return chain.Build(server);
    }

    private static (List<string> Dns, List<IPAddress> Addresses) Wanted(HostIdentity identity)
    {
        var dns = new List<string> { "localhost" };
        dns.AddRange(LocalNetwork.Names(identity));
        var addresses = new List<IPAddress> { IPAddress.Loopback, IPAddress.IPv6Loopback };
        foreach (var a in identity.Addresses) if (!addresses.Any(x => x.Equals(a))) addresses.Add(a);
        return (dns.Distinct(StringComparer.OrdinalIgnoreCase).ToList(), addresses);
    }

    private static X509Certificate2? TryLoad(string certPath, string keyPath)
    {
        if (!File.Exists(certPath) || !File.Exists(keyPath)) return null;
        try
        {
            return X509Certificate2.CreateFromPem(File.ReadAllText(certPath), File.ReadAllText(keyPath));
        }
        catch (Exception ex) when (ex is CryptographicException or IOException or UnauthorizedAccessException or ArgumentException)
        {
            return null;   // damaged or unreadable: made again
        }
    }

    private static bool IsUsableAuthority(X509Certificate2 ca, DateTimeOffset now)
    {
        if (!ca.HasPrivateKey || ca.NotBefore.ToUniversalTime() > now.UtcDateTime || ca.NotAfter.ToUniversalTime() < now.UtcDateTime + AuthorityRenewBefore) return false;
        return ca.Extensions.OfType<X509BasicConstraintsExtension>().Any(b => b.CertificateAuthority);
    }

    private static bool Fits(X509Certificate2 server, X509Certificate2 ca, IReadOnlyList<string> dns, IReadOnlyList<IPAddress> addresses, DateTimeOffset now)
    {
        try
        {
            if (!server.HasPrivateKey || server.NotBefore.ToUniversalTime() > now.UtcDateTime || server.NotAfter.ToUniversalTime() < now.UtcDateTime + ServerRenewBefore) return false;
            if (!ChainsTo(server, ca, now)) return false;
            var san = server.Extensions.OfType<X509SubjectAlternativeNameExtension>().FirstOrDefault();
            if (san is null) return false;
            var haveDns = san.EnumerateDnsNames().ToHashSet(StringComparer.OrdinalIgnoreCase);
            var haveIps = san.EnumerateIPAddresses().ToList();
            return dns.All(haveDns.Contains) && addresses.All(a => haveIps.Any(h => h.Equals(a)));
        }
        catch (CryptographicException)
        {
            return false;
        }
    }

    private static X509Certificate2 MakeAuthority(HostIdentity identity, DateTimeOffset now)
    {
        using var key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        // A name that is the same wherever the Hub is sold: nothing of a company in it. The PC's name and four random characters keep two shops' authorities apart on one computer.
        var label = (LocalNetwork.Clean(identity.HostName) ?? "this PC") + " " + Convert.ToHexString(RandomNumberGenerator.GetBytes(2));
        var request = new CertificateRequest(new X500DistinguishedName("CN=Shop network authority (" + label + ")"), key, HashAlgorithmName.SHA256);
        request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, true, 0, true));
        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));
        request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));
        using var selfSigned = request.CreateSelfSigned(now - BackDate, now + AuthorityLife);
        // Round trip through PEM so that the object carries its own copy of the key (the self-signed object's key goes away with <c>key</c>).
        return X509Certificate2.CreateFromPem(selfSigned.ExportCertificatePem(), key.ExportPkcs8PrivateKeyPem());
    }

    private static X509Certificate2 MakeServer(X509Certificate2 ca, IReadOnlyList<string> dns, IReadOnlyList<IPAddress> addresses, DateTimeOffset now)
    {
        using var key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var primary = dns.FirstOrDefault(n => n != "localhost") ?? addresses.FirstOrDefault(a => !IPAddress.IsLoopback(a))?.ToString() ?? "localhost";
        var request = new CertificateRequest(new X500DistinguishedName("CN=" + primary), key, HashAlgorithmName.SHA256);
        request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, true));
        request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(ServerAuth) }, false));
        var names = new SubjectAlternativeNameBuilder();
        foreach (var n in dns) names.AddDnsName(n);
        foreach (var a in addresses) names.AddIpAddress(a);
        request.CertificateExtensions.Add(names.Build());
        request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));
        request.CertificateExtensions.Add(X509AuthorityKeyIdentifierExtension.CreateFromCertificate(ca, true, false));
        var serial = RandomNumberGenerator.GetBytes(16);
        serial[0] &= 0x7F;   // a positive number
        if (serial[0] == 0) serial[0] = 1;
        using var signed = request.Create(ca, now - BackDate, now + ServerLife, serial);
        return X509Certificate2.CreateFromPem(signed.ExportCertificatePem(), key.ExportPkcs8PrivateKeyPem());
    }

    private static string PrivateKeyPem(X509Certificate2 certificate)
    {
        using var ecdsa = certificate.GetECDsaPrivateKey() ?? throw new CryptographicException("The certificate has no private key.");
        return ecdsa.ExportPkcs8PrivateKeyPem();
    }

    /// <summary>
    /// On Windows the web server's secure channel needs a key it can reach by itself, which a key read from text is not: the certificate is turned into a PKCS #12 block and loaded
    /// again. Elsewhere the certificate is used as it is. (Not tried on a real Windows PC: docs/OPEN-WORK.md.)
    /// </summary>
    private static X509Certificate2 ForTheWebServer(X509Certificate2 certificate)
    {
        if (!OperatingSystem.IsWindows()) return certificate;
        var pfx = certificate.Export(X509ContentType.Pfx);
        certificate.Dispose();
        return X509CertificateLoader.LoadPkcs12(pfx, null);
    }
}

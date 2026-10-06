using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NextGenOS.Hub.Ai;

/// <summary>
/// Where an AI service's key is kept. The shop database holds only the NAME of a secret (never its value), a backup of the database therefore holds no key, and a key is never
/// shown again after it was typed: screens show <see cref="Secrets.Mask"/>.
/// </summary>
public interface ISecretStore
{
    /// <summary>Says where the secrets are kept, for the settings screen.</summary>
    string Description { get; }

    bool Has(string name);

    string? Get(string name);

    void Set(string name, string value);

    void Delete(string name);
}

public static partial class Secrets
{
    public const int MaxLength = 1024;

    /// <summary>What a screen may show of a secret: nothing of a short one, the last four characters of a long one.</summary>
    public static string Mask(string? secret) =>
        string.IsNullOrEmpty(secret) ? "" : secret.Length < 16 ? "••••••••" : "••••••••" + secret[^4..];

    /// <summary>Takes any secret, and anything that looks like a sign-in header, out of a text that may be shown or logged (for example an answer from a service that repeats what it was sent).</summary>
    public static string Redact(string? text, params string?[] secrets)
    {
        if (string.IsNullOrEmpty(text)) return "";
        var result = text;
        foreach (var secret in secrets)
            if (!string.IsNullOrEmpty(secret) && secret.Length >= 6) result = result.Replace(secret, "[hidden]", StringComparison.Ordinal);
        return Bearer().Replace(result, "$1[hidden]");
    }

    [GeneratedRegex(@"(?i)(bearer\s+)[A-Za-z0-9._~+/=\-]{8,}", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex Bearer();

    /// <summary>The store this computer uses: the Windows Credential Manager on Windows, an encrypted file elsewhere.</summary>
    public static ISecretStore Open(string dataFolder) =>
        OperatingSystem.IsWindows() ? new WindowsCredentialStore() : new EncryptedFileVault(Path.Combine(dataFolder, "ai-secrets.vault"), Path.Combine(dataFolder, "keys", "ai-secrets.key"));
}

/// <summary>Keeps secrets for tests and for a computer with no store: they are gone when the program stops.</summary>
public sealed class MemorySecretStore : ISecretStore
{
    private readonly Dictionary<string, string> _items = new();

    public string Description => "Kept in memory only (lost when the program stops).";

    public bool Has(string name) { lock (_items) return _items.ContainsKey(name); }

    public string? Get(string name) { lock (_items) return _items.GetValueOrDefault(name); }

    public void Set(string name, string value) { lock (_items) _items[name] = value; }

    public void Delete(string name) { lock (_items) _items.Remove(name); }
}

/// <summary>
/// The Windows Credential Manager (the same safe the system keeps passwords in). A secret belongs to the Windows account the Hub runs as; another account on the PC cannot read it.
/// Written with direct calls to the system so that no extra library is needed. It can only be tried on a real Windows PC (docs/OPEN-WORK.md).
/// </summary>
[SupportedOSPlatform("windows")]
public sealed class WindowsCredentialStore : ISecretStore
{
    private const string Prefix = "NextGenOS.Hub/";
    private const uint TypeGeneric = 1;
    private const uint PersistLocalMachine = 2;
    private const int MaxBlobBytes = 2560;

    public string Description => "The Windows Credential Manager of the account the Hub runs as.";

    public bool Has(string name) => Get(name) is not null;

    public string? Get(string name)
    {
        if (!CredReadW(Prefix + name, TypeGeneric, 0, out var pointer)) return null;
        try
        {
            var credential = Marshal.PtrToStructure<Credential>(pointer);
            if (credential.CredentialBlob == IntPtr.Zero || credential.CredentialBlobSize == 0) return "";
            var bytes = new byte[credential.CredentialBlobSize];
            Marshal.Copy(credential.CredentialBlob, bytes, 0, bytes.Length);
            return Encoding.Unicode.GetString(bytes);
        }
        finally
        {
            CredFree(pointer);
        }
    }

    public void Set(string name, string value)
    {
        var bytes = Encoding.Unicode.GetBytes(value);
        if (bytes.Length > MaxBlobBytes) throw new HubException("secret-too-long", "That key is too long for the Windows Credential Manager.");
        var blob = Marshal.AllocHGlobal(bytes.Length);
        try
        {
            Marshal.Copy(bytes, 0, blob, bytes.Length);
            var credential = new Credential
            {
                Type = TypeGeneric,
                TargetName = Prefix + name,
                UserName = "NextGenOS Hub",
                CredentialBlob = blob,
                CredentialBlobSize = (uint)bytes.Length,
                Persist = PersistLocalMachine,
            };
            if (!CredWriteW(ref credential, 0)) throw new HubException("secret-not-saved", "Windows would not keep the key (error " + Marshal.GetLastWin32Error() + ").");
        }
        finally
        {
            Array.Clear(bytes);
            Marshal.FreeHGlobal(blob);
        }
    }

    public void Delete(string name) => CredDeleteW(Prefix + name, TypeGeneric, 0);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct Credential
    {
        public uint Flags;
        public uint Type;
        public string TargetName;
        public string? Comment;
        public System.Runtime.InteropServices.ComTypes.FILETIME LastWritten;
        public uint CredentialBlobSize;
        public IntPtr CredentialBlob;
        public uint Persist;
        public uint AttributeCount;
        public IntPtr Attributes;
        public string? TargetAlias;
        public string? UserName;
    }

#pragma warning disable SYSLIB1054 // the direct call is intentional and small
    [DllImport("advapi32.dll", EntryPoint = "CredReadW", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern bool CredReadW(string target, uint type, uint flags, out IntPtr credential);

    [DllImport("advapi32.dll", EntryPoint = "CredWriteW", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern bool CredWriteW(ref Credential credential, uint flags);

    [DllImport("advapi32.dll", EntryPoint = "CredDeleteW", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern bool CredDeleteW(string target, uint type, uint flags);

    [DllImport("advapi32.dll", EntryPoint = "CredFree")]
    private static extern void CredFree(IntPtr buffer);
#pragma warning restore SYSLIB1054
}

/// <summary>
/// For a computer without a system safe (Linux): the secrets are in one file, encrypted with AES-256-GCM, and the key for it is in another file that only the Hub's account can read.
/// This keeps a key out of the database, out of backups of the database and out of a copy of the data file; it does not stop someone who can already read every file of the account.
/// </summary>
public sealed class EncryptedFileVault(string vaultPath, string keyPath) : ISecretStore
{
    private readonly object _gate = new();

    public string Description => "An encrypted file on this computer (" + Path.GetFileName(vaultPath) + "); its key is kept apart, readable by the Hub's account only.";

    public bool Has(string name) { lock (_gate) return Read().ContainsKey(name); }

    public string? Get(string name) { lock (_gate) return Read().GetValueOrDefault(name); }

    public void Set(string name, string value)
    {
        if (value.Length > Secrets.MaxLength) throw new HubException("secret-too-long", "That key is too long.");
        lock (_gate)
        {
            var items = Read();
            items[name] = value;
            Write(items);
        }
    }

    public void Delete(string name)
    {
        lock (_gate)
        {
            var items = Read();
            if (items.Remove(name)) Write(items);
        }
    }

    private Dictionary<string, string> Read()
    {
        if (!File.Exists(vaultPath)) return new Dictionary<string, string>();
        var blob = File.ReadAllBytes(vaultPath);
        if (blob.Length < 12 + 16) throw new HubException("vault-damaged", "The file that keeps the AI keys is damaged. Enter the keys again.");
        var plain = new byte[blob.Length - 28];
        try
        {
            using var aes = new AesGcm(Key(create: false), 16);
            aes.Decrypt(blob.AsSpan(0, 12), blob.AsSpan(28), blob.AsSpan(12, 16), plain);
        }
        catch (CryptographicException)
        {
            throw new HubException("vault-damaged", "The file that keeps the AI keys cannot be read (it was changed, or its key is missing). Enter the keys again.");
        }

        return JsonSerializer.Deserialize<Dictionary<string, string>>(plain) ?? new Dictionary<string, string>();
    }

    private void Write(Dictionary<string, string> items)
    {
        var plain = JsonSerializer.SerializeToUtf8Bytes(items);
        var blob = new byte[12 + 16 + plain.Length];
        RandomNumberGenerator.Fill(blob.AsSpan(0, 12));
        using (var aes = new AesGcm(Key(create: true), 16))
            aes.Encrypt(blob.AsSpan(0, 12), plain, blob.AsSpan(28), blob.AsSpan(12, 16));
        Array.Clear(plain);
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(vaultPath))!);
        var temporary = vaultPath + ".new";
        File.WriteAllBytes(temporary, blob);
        File.Move(temporary, vaultPath, overwrite: true);
    }

    private byte[] Key(bool create)
    {
        if (File.Exists(keyPath))
        {
            var key = File.ReadAllBytes(keyPath);
            if (key.Length != 32) throw new HubException("vault-damaged", "The key of the file that keeps the AI keys is damaged. Enter the keys again.");
            return key;
        }

        if (!create) throw new HubException("vault-damaged", "The key of the file that keeps the AI keys is missing. Enter the keys again.");
        var fresh = RandomNumberGenerator.GetBytes(32);
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(keyPath))!);
        var options = new FileStreamOptions { Mode = FileMode.CreateNew, Access = FileAccess.Write };
        if (!OperatingSystem.IsWindows()) options.UnixCreateMode = UnixFileMode.UserRead | UnixFileMode.UserWrite;   // never readable by anyone else, not even for a moment
        using (var stream = new FileStream(keyPath, options)) stream.Write(fresh);
        return fresh;
    }
}

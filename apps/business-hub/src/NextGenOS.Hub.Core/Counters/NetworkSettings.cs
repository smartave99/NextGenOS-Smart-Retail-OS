using System.Text.Json;

namespace NextGenOS.Hub.Counters;

/// <summary>
/// What the owner chose about counter PCs: whether they may connect over the shop's network, and on which port the Hub then listens (besides the one on this PC itself). It is kept in a
/// small file in the data folder, not in the database, because the program has to know it before it starts listening, which is before the database is opened.
/// </summary>
public sealed record NetworkSettings(bool Enabled, int Port, string? Problem = null)
{
    public const int DefaultPort = 5281;

    /// <summary>The lowest port a program running under a plain account may listen on.</summary>
    public const int LowestPort = 1024;

    public const int HighestPort = 65535;

    /// <summary>Counter PCs may not connect (the default), and the file may not even exist.</summary>
    public static NetworkSettings Off => new(false, DefaultPort);
}

/// <summary>Reads and writes <c>network.json</c> in the data folder. Written by hand with a small reader: the program's own names are hidden in a shipped build, so nothing here may depend on a type's property names.</summary>
public static class NetworkSettingsFile
{
    public const string FileName = "network.json";
    private const int MaxBytes = 4096;

    public static string PathIn(string folder) => Path.Combine(folder, FileName);

    /// <summary>
    /// What the file says. Never throws: no file means off; a file that cannot be read, or says something that is not allowed, also means off, with a plain sentence in
    /// <see cref="NetworkSettings.Problem"/>. Doubt always ends as "counter PCs may not connect".
    /// </summary>
    public static NetworkSettings Read(string folder)
    {
        var path = PathIn(folder);
        if (!File.Exists(path)) return NetworkSettings.Off;
        const string unreadable = "The file that keeps the choice about counter PCs (network.json) could not be read, so counter PCs stay switched off.";
        try
        {
            var info = new FileInfo(path);
            if (info.Length > MaxBytes) return new NetworkSettings(false, NetworkSettings.DefaultPort, unreadable);
            using var doc = JsonDocument.Parse(File.ReadAllBytes(path), new JsonDocumentOptions { MaxDepth = 4 });
            var root = doc.RootElement;
            if (root.ValueKind != JsonValueKind.Object) return new NetworkSettings(false, NetworkSettings.DefaultPort, unreadable);
            var enabled = false;
            if (root.TryGetProperty("enabled", out var e))
            {
                if (e.ValueKind is not (JsonValueKind.True or JsonValueKind.False)) return new NetworkSettings(false, NetworkSettings.DefaultPort, unreadable);
                enabled = e.ValueKind == JsonValueKind.True;
            }

            var port = NetworkSettings.DefaultPort;
            if (root.TryGetProperty("port", out var p))
            {
                if (p.ValueKind != JsonValueKind.Number || !p.TryGetInt32(out port) || port is < NetworkSettings.LowestPort or > NetworkSettings.HighestPort)
                    return new NetworkSettings(false, NetworkSettings.DefaultPort, "The port in network.json is not a number between 1024 and 65535, so counter PCs stay switched off.");
            }

            return new NetworkSettings(enabled, port);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
        {
            return new NetworkSettings(false, NetworkSettings.DefaultPort, unreadable);
        }
    }

    /// <summary>Writes the choice, whole or not at all (a temporary file, then a move), readable by the program's own account only where the system allows it.</summary>
    public static void Write(string folder, NetworkSettings settings)
    {
        Directory.CreateDirectory(folder);
        using var memory = new MemoryStream();
        using (var json = new Utf8JsonWriter(memory, new JsonWriterOptions { Indented = true }))
        {
            json.WriteStartObject();
            json.WriteBoolean("enabled", settings.Enabled);
            json.WriteNumber("port", settings.Port);
            json.WriteEndObject();
        }

        Private.WriteFile(PathIn(folder), memory.ToArray());
    }

    /// <summary>A plain sentence about a port that cannot be used, or null when it can. <paramref name="reserved"/> are the ports the Hub already listens on.</summary>
    public static string? CheckPort(int port, IEnumerable<int>? reserved)
    {
        if (port is < NetworkSettings.LowestPort or > NetworkSettings.HighestPort) return "The port must be a number between 1024 and 65535.";
        if (reserved is not null && reserved.Contains(port)) return "That port is already used by the Hub itself on this PC. Choose another one.";
        return null;
    }
}

/// <summary>Writing a file only the program's own account may read: created with that mode from the first byte (never readable by anyone else, not even for a moment), then moved into place.</summary>
internal static class Private
{
    public static void WriteFile(string path, byte[] content)
    {
        var temporary = path + ".new";
        if (File.Exists(temporary)) File.Delete(temporary);
        var options = new FileStreamOptions { Mode = FileMode.CreateNew, Access = FileAccess.Write, Share = FileShare.None };
        if (!OperatingSystem.IsWindows()) options.UnixCreateMode = UnixFileMode.UserRead | UnixFileMode.UserWrite;
        using (var stream = new FileStream(temporary, options)) stream.Write(content);
        File.Move(temporary, path, overwrite: true);
    }

    /// <summary>A folder only the program's own account may enter (on Windows it keeps the rights of the folder it is in, which the Hub's setup limits to the service and administrators).</summary>
    public static void MakeFolder(string path)
    {
        if (Directory.Exists(path)) return;
        if (OperatingSystem.IsWindows()) Directory.CreateDirectory(path);
        else Directory.CreateDirectory(path, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);
    }
}

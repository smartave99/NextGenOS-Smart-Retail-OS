using System.Text.Json;
using NextGenOS.Devices.Printing;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Printing;

/// <summary>The printers the shop has, kept with the other settings.</summary>
public sealed class PrinterStore(SettingsStore settings, AuditService audit)
{
    private const string Key = "printers";
    private static readonly JsonSerializerOptions Json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() } };

    public IReadOnlyList<PrinterProfile> List() =>
        settings.GetText(Key) is { } text ? JsonSerializer.Deserialize<List<PrinterProfile>>(text, Json) ?? new() : new List<PrinterProfile>();

    public PrinterProfile? Get(string id) => List().FirstOrDefault(p => p.Id == id);

    public PrinterProfile Save(PrinterProfile profile, long? userId = null)
    {
        if (profile.Problem() is { } problem) throw new HubException("printer", problem);
        profile.Name = profile.Name.Trim();
        profile.Address = profile.Address.Trim();
        var all = List().ToList();
        var index = all.FindIndex(p => p.Id == profile.Id);
        if (all.Any(p => p.Id != profile.Id && string.Equals(p.Name, profile.Name, StringComparison.OrdinalIgnoreCase))) throw new HubException("printer-name", $"There is already a printer called {profile.Name}.");
        if (index >= 0) all[index] = profile; else all.Add(profile);
        settings.SetText(Key, JsonSerializer.Serialize(all, Json));
        audit.Log(userId, "printer-saved", "printer", null, $"{profile.Name} ({profile.Role}, {profile.Language}, {profile.Connection})");
        return profile;
    }

    public void Remove(string id, long? userId = null)
    {
        var all = List().ToList();
        var gone = all.FirstOrDefault(p => p.Id == id);
        if (gone is null) return;
        all.Remove(gone);
        settings.SetText(Key, JsonSerializer.Serialize(all, Json));
        audit.Log(userId, "printer-removed", "printer", null, gone.Name);
    }

    /// <summary>The printer to use for a job: the first of its kind (a kitchen printer is the one for the station, or one for all stations).</summary>
    public PrinterProfile? For(string role, string? station = null)
    {
        var all = List().Where(p => p.Role == role).ToList();
        return role == PrinterRole.Kitchen
            ? all.FirstOrDefault(p => string.Equals(p.Station, station, StringComparison.OrdinalIgnoreCase)) ?? all.FirstOrDefault(p => string.IsNullOrEmpty(p.Station))
            : all.FirstOrDefault();
    }
}

using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace SmartRetail.Pos.Vision;

/// <summary>What visual.json holds: the model that made the vectors, and each photo's vector and colours (base64,
/// 32-bit floats).</summary>
public sealed class VisualFile
{
    public string Model { get; set; } = "";

    public List<VisualEntry> Photos { get; set; } = new();
}

public sealed class VisualEntry
{
    public string File { get; set; } = "";

    public string Vector { get; set; } = "";

    public string Colour { get; set; } = "";
}

/// <summary>
/// The vectors of one product's photos, kept next to the photos as visual.json, so each photo is looked at once and
/// the vectors move with the data folder. Vectors made by another model are never read.
/// </summary>
public static class VisualStore
{
    public const string FileName = "visual.json";

    private static readonly JsonSerializerOptions Json = new() { WriteIndented = false };

    /// <summary>The product's vectors made by <paramref name="modelId"/>; none when there are none, or another model made them.</summary>
    public static IReadOnlyList<PhotoVector> Read(string folder, string modelId)
    {
        var path = Path.Combine(folder, FileName);
        if (!File.Exists(path))
        {
            return Array.Empty<PhotoVector>();
        }

        try
        {
            var file = JsonSerializer.Deserialize<VisualFile>(File.ReadAllText(path, Encoding.UTF8), Json);
            if (file is null || file.Model != modelId)
            {
                return Array.Empty<PhotoVector>();
            }

            return (file.Photos ?? new List<VisualEntry>())
                .Where(entry => entry is not null && IsPlainName(entry.File))
                .Select(entry => (entry.File, Vector: Decode(entry.Vector), Colour: Decode(entry.Colour)))
                .Where(entry => entry.Vector is { Length: > 0 } && entry.Colour is { Length: ColourHistogram.Length })
                .Select(entry => new PhotoVector(entry.File, entry.Vector!, entry.Colour!))
                .ToList();
        }
        catch (Exception ex) when (ex is JsonException or IOException or UnauthorizedAccessException)
        {
            return Array.Empty<PhotoVector>();
        }
    }

    /// <summary>Keeps the product's vectors (a new file, then swapped in); none removes the file.</summary>
    public static void Write(string folder, string modelId, IReadOnlyList<PhotoVector> vectors)
    {
        ArgumentNullException.ThrowIfNull(vectors);
        var path = Path.Combine(folder, FileName);
        if (vectors.Count == 0)
        {
            File.Delete(path);
            return;
        }

        var file = new VisualFile
        {
            Model = modelId,
            Photos = vectors.Select(v => new VisualEntry { File = v.File, Vector = Encode(v.Vector), Colour = Encode(v.Colour) }).ToList(),
        };
        var temporary = path + ".tmp";
        File.WriteAllText(temporary, JsonSerializer.Serialize(file, Json), new UTF8Encoding(false));
        File.Move(temporary, path, overwrite: true);
    }

    public static string Encode(float[] vector) => Convert.ToBase64String(MemoryMarshal.AsBytes(vector.AsSpan()));

    /// <summary>The vector, or null when the text is not one (not base64, a broken length, or not finite).</summary>
    public static float[]? Decode(string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }

        try
        {
            var bytes = Convert.FromBase64String(text);
            if (bytes.Length == 0 || bytes.Length % sizeof(float) != 0)
            {
                return null;
            }

            var vector = MemoryMarshal.Cast<byte, float>(bytes).ToArray();
            return vector.All(float.IsFinite) ? vector : null;
        }
        catch (FormatException)
        {
            return null;
        }
    }

    private static bool IsPlainName(string? name) =>
        !string.IsNullOrWhiteSpace(name) && name.Length <= 120 && Path.GetFileName(name) == name && name.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
}

using System.Text.RegularExpressions;
using SmartRetail.AI;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Products;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Why a photo or voice note could not be added, for the owner.</summary>
public sealed class ChatAttachmentException(string message) : Exception(message);

/// <summary>
/// Photos and voice notes sent with a chat question: temporary files on this PC, next to the AI's run folders (never
/// in the data folder or the POS database). They go when the chat ends or the app closes; the chat lives only while
/// the app runs, so any found when it starts (after a crash) go then. Only JPEG, PNG and WebP photos and WAV
/// recordings are kept, checked by their first bytes, and <c>/chat-attachments</c> serves only names the store made.
/// </summary>
public sealed partial class ChatAttachmentStore
{
    public const long MaxPhotoBytes = 10 * 1024 * 1024;
    public const long MaxVoiceBytes = 12 * 1024 * 1024;

    public ChatAttachmentStore(string? folder = null)
    {
        Folder = folder ?? Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Branding.Company, Branding.AppFolderName, "chat-attachments");
    }

    public string Folder { get; }

    /// <summary>Keeps a photo or voice note sent with a question.</summary>
    /// <exception cref="ChatAttachmentException">It is too large or not a photo or recording the AI can read.</exception>
    public async Task<ChatAttachment> SaveAsync(AttachmentKind kind, Stream content, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(content);
        var limit = kind == AttachmentKind.Photo ? MaxPhotoBytes : MaxVoiceBytes;
        using var memory = new MemoryStream();
        var buffer = new byte[81920];
        int read;
        while ((read = await content.ReadAsync(buffer, ct)) > 0)
        {
            if (memory.Length + read > limit)
            {
                throw new ChatAttachmentException(kind == AttachmentKind.Photo ? "That photo is larger than 10 MB." : "That voice note is too long: keep it under 5 minutes.");
            }

            memory.Write(buffer, 0, read);
        }

        var bytes = memory.ToArray();
        var extension = kind == AttachmentKind.Photo ? ImageFile.ExtensionOf(bytes) : IsWave(bytes) ? ".wav" : null;
        if (extension is null)
        {
            throw new ChatAttachmentException(kind == AttachmentKind.Photo ? "Only JPEG, PNG or WebP photos can be sent." : "That recording could not be read.");
        }

        Directory.CreateDirectory(Folder);
        var name = (kind == AttachmentKind.Photo ? "photo-" : "voice-") + Guid.NewGuid().ToString("N") + extension;
        var path = Path.Combine(Folder, name);
        await File.WriteAllBytesAsync(path, bytes, ct);
        return new ChatAttachment(kind, path, name);
    }

    /// <summary>The file for a name the store made; null for anything else.</summary>
    public string? PathOf(string? name)
    {
        if (name is null || !FileName().IsMatch(name))
        {
            return null;
        }

        var path = Path.Combine(Folder, name);
        return File.Exists(path) ? path : null;
    }

    /// <summary>Removes the files of a chat that ended; only files in this store's folder.</summary>
    public void Delete(IEnumerable<ChatAttachment> attachments)
    {
        foreach (var attachment in attachments)
        {
            if (PathOf(attachment.Name) is { } path && string.Equals(Path.GetFullPath(path), Path.GetFullPath(attachment.Path), StringComparison.OrdinalIgnoreCase))
            {
                TryDelete(path);
            }
        }
    }

    /// <summary>Removes every file the store made, at start: the chat they belonged to ended with the app (e.g. when
    /// it stopped suddenly). Other files in the folder are left alone.</summary>
    public int DeleteLeftOver()
    {
        if (!Directory.Exists(Folder))
        {
            return 0;
        }

        var removed = 0;
        foreach (var path in Directory.EnumerateFiles(Folder))
        {
            if (FileName().IsMatch(Path.GetFileName(path)) && TryDelete(path))
            {
                removed++;
            }
        }

        return removed;
    }

    public static string Url(ChatAttachment attachment) => "chat-attachments/" + Uri.EscapeDataString(attachment.Name);

    public static string ContentType(string path) => Path.GetExtension(path).ToLowerInvariant() switch
    {
        ".png" => "image/png",
        ".webp" => "image/webp",
        ".wav" => "audio/wav",
        _ => "image/jpeg",
    };

    private static bool IsWave(byte[] bytes) =>
        bytes.Length > 44 && bytes[0] == 'R' && bytes[1] == 'I' && bytes[2] == 'F' && bytes[3] == 'F'
        && bytes[8] == 'W' && bytes[9] == 'A' && bytes[10] == 'V' && bytes[11] == 'E';

    private static bool TryDelete(string path)
    {
        try
        {
            File.Delete(path);
            return true;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            return false;
        }
    }

    [GeneratedRegex(@"^(photo|voice)-[0-9a-f]{32}\.(jpg|png|webp|wav)$")]
    private static partial Regex FileName();
}

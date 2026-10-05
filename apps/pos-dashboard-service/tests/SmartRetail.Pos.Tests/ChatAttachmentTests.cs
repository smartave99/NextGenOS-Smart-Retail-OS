using SmartRetail.AI.Assistant;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public sealed class ChatAttachmentStoreTests : IDisposable
{
    private static readonly byte[] Png = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0, 0, 0, 13, (byte)'I', (byte)'H', (byte)'D', (byte)'R'];
    private static readonly byte[] Jpeg = [0xFF, 0xD8, 0xFF, 0xE0, 0, 16, (byte)'J', (byte)'F', (byte)'I', (byte)'F', 0, 1, 1];

    private readonly string _root = Path.Combine(Path.GetTempPath(), "chat-attachments-" + Guid.NewGuid().ToString("N"));

    private string Folder => Path.Combine(_root, "chat-attachments");

    public void Dispose()
    {
        if (Directory.Exists(_root))
        {
            Directory.Delete(_root, recursive: true);
        }
    }

    private static byte[] Wave(int samples = 100)
    {
        var bytes = new byte[44 + samples * 2];
        "RIFF"u8.CopyTo(bytes);
        "WAVE"u8.CopyTo(bytes.AsSpan(8));
        "fmt "u8.CopyTo(bytes.AsSpan(12));
        return bytes;
    }

    private static Task<ChatAttachment> Save(ChatAttachmentStore store, AttachmentKind kind, byte[] bytes) =>
        store.SaveAsync(kind, new MemoryStream(bytes), CancellationToken.None);

    [Fact]
    public async Task A_photo_is_kept_under_a_name_the_store_made_and_served_by_it()
    {
        var store = new ChatAttachmentStore(Folder);

        var png = await Save(store, AttachmentKind.Photo, Png);
        var jpeg = await Save(store, AttachmentKind.Photo, Jpeg);

        Assert.Equal(AttachmentKind.Photo, png.Kind);
        Assert.Matches("^photo-[0-9a-f]{32}\\.png$", png.Name);
        Assert.Matches("^photo-[0-9a-f]{32}\\.jpg$", jpeg.Name);
        Assert.Equal(Png, await File.ReadAllBytesAsync(png.Path));
        Assert.Equal(png.Path, store.PathOf(png.Name));
        Assert.Equal("chat-attachments/" + png.Name, ChatAttachmentStore.Url(png));
        Assert.Equal("image/png", ChatAttachmentStore.ContentType(png.Path));
        Assert.Equal("image/jpeg", ChatAttachmentStore.ContentType(jpeg.Path));
    }

    [Fact]
    public async Task A_voice_note_must_be_a_wave_recording()
    {
        var store = new ChatAttachmentStore(Folder);

        var voice = await Save(store, AttachmentKind.Voice, Wave());

        Assert.Matches("^voice-[0-9a-f]{32}\\.wav$", voice.Name);
        Assert.Equal("audio/wav", ChatAttachmentStore.ContentType(voice.Path));
        var problem = await Assert.ThrowsAsync<ChatAttachmentException>(() => Save(store, AttachmentKind.Voice, Png));
        Assert.Equal("That recording could not be read.", problem.Message);
        await Assert.ThrowsAsync<ChatAttachmentException>(() => Save(store, AttachmentKind.Voice, Wave()[..44]));
    }

    [Fact]
    public async Task Only_photos_the_ai_can_read_are_kept()
    {
        var store = new ChatAttachmentStore(Folder);

        var notPhoto = await Assert.ThrowsAsync<ChatAttachmentException>(() => Save(store, AttachmentKind.Photo, "<svg onload=alert(1)>....."u8.ToArray()));
        Assert.Equal("Only JPEG, PNG or WebP photos can be sent.", notPhoto.Message);
        await Assert.ThrowsAsync<ChatAttachmentException>(() => Save(store, AttachmentKind.Photo, Wave()));
        await Assert.ThrowsAsync<ChatAttachmentException>(() => Save(store, AttachmentKind.Photo, []));
        Assert.False(Directory.Exists(Folder) && Directory.EnumerateFiles(Folder).Any(), "nothing is written for a refused file");
    }

    [Fact]
    public async Task Files_over_the_limit_are_refused_while_reading()
    {
        var store = new ChatAttachmentStore(Folder);
        var tooBig = new byte[ChatAttachmentStore.MaxPhotoBytes + 1];
        Png.CopyTo(tooBig, 0);

        var problem = await Assert.ThrowsAsync<ChatAttachmentException>(() => Save(store, AttachmentKind.Photo, tooBig));

        Assert.Equal("That photo is larger than 10 MB.", problem.Message);
        var justRight = await Save(store, AttachmentKind.Photo, tooBig[..(int)ChatAttachmentStore.MaxPhotoBytes]);
        Assert.Equal(ChatAttachmentStore.MaxPhotoBytes, new FileInfo(justRight.Path).Length);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("../settings.json")]
    [InlineData("..\\settings.json")]
    [InlineData("photo-0123456789abcdef0123456789abcdef.svg")]
    [InlineData("photo-0123456789ABCDEF0123456789ABCDEF.png")]
    [InlineData("other-0123456789abcdef0123456789abcdef.png")]
    [InlineData("photo-0123456789abcdef0123456789abcdef.png")] // made by the store's pattern, but never saved
    public void Only_names_the_store_made_are_served(string? name)
    {
        Directory.CreateDirectory(Folder);
        File.WriteAllText(Path.Combine(_root, "settings.json"), "{}");

        Assert.Null(new ChatAttachmentStore(Folder).PathOf(name));
    }

    [Fact]
    public async Task A_chat_that_ends_takes_only_its_own_files_with_it()
    {
        var store = new ChatAttachmentStore(Folder);
        var sent = await Save(store, AttachmentKind.Photo, Png);
        var other = await Save(store, AttachmentKind.Voice, Wave());
        var outside = Path.Combine(_root, Path.GetFileName(sent.Name));
        File.WriteAllBytes(outside, Png);

        // An attachment whose path points outside the store's folder is never deleted there.
        store.Delete([sent, new ChatAttachment(AttachmentKind.Photo, outside, sent.Name)]);

        Assert.False(File.Exists(sent.Path));
        Assert.True(File.Exists(other.Path));
        Assert.True(File.Exists(outside));
    }

    [Fact]
    public async Task Files_left_from_an_earlier_run_are_removed_at_start()
    {
        var store = new ChatAttachmentStore(Folder);
        var old = await Save(store, AttachmentKind.Photo, Png);
        var recent = await Save(store, AttachmentKind.Voice, Wave());
        var ownFile = Path.Combine(Folder, "notes.txt");
        File.WriteAllText(ownFile, "not the store's");
        File.SetLastWriteTimeUtc(old.Path, DateTime.UtcNow.AddDays(-2));

        // The chat they belonged to lived in the app, so every one of them is left over, however new.
        Assert.Equal(2, new ChatAttachmentStore(Folder).DeleteLeftOver());

        Assert.False(File.Exists(old.Path));
        Assert.False(File.Exists(recent.Path));
        Assert.True(File.Exists(ownFile));
        Assert.Equal(0, new ChatAttachmentStore(Path.Combine(_root, "missing")).DeleteLeftOver());
    }
}

public class ChatInputsTests
{
    private static CodexModel Model(string id, bool isDefault = false, params string[] takes) =>
        new() { Id = id, IsDefault = isDefault, InputModalities = takes.ToList() };

    private static AssistantSettings Settings(string provider, string? askModel = null)
    {
        var settings = new AssistantSettings { PreferredProvider = provider };
        if (askModel is not null)
        {
            settings.Jobs[nameof(AiJob.Ask)] = new AiJobChoice { Model = askModel };
        }

        return settings;
    }

    [Fact]
    public void Codex_takes_what_the_chosen_model_takes()
    {
        var models = new[] { Model("gpt-a", true, "text", "image"), Model("gpt-voice", false, "text", "image", "audio"), Model("gpt-text", false, "text") };

        Assert.Equal(new ChatInputOptions(true, false), ChatInputs.For(Settings(ProviderIds.CodexCli), models));
        Assert.Equal(new ChatInputOptions(true, true), ChatInputs.For(Settings(ProviderIds.CodexCli, "GPT-VOICE"), models));
        Assert.Equal(new ChatInputOptions(false, false), ChatInputs.For(Settings(ProviderIds.CodexCli, "gpt-text"), models));
        Assert.Equal(new ChatInputOptions(true, true), ChatInputs.For(Settings(ProviderIds.Auto, "gpt-voice"), models));
    }

    [Fact]
    public void A_codex_that_does_not_say_still_reads_photos()
    {
        Assert.Equal(new ChatInputOptions(true, false), ChatInputs.For(Settings(ProviderIds.CodexCli), []));
        Assert.Equal(new ChatInputOptions(true, false), ChatInputs.For(Settings(ProviderIds.CodexCli), [Model("old", true)]));
        Assert.Equal(new ChatInputOptions(true, false), ChatInputs.For(Settings(ProviderIds.CodexCli, "not-listed"), [Model("gpt-voice", true, "audio")]));
    }

    [Fact]
    public void A_custom_tool_takes_what_its_command_asks_for()
    {
        var settings = Settings(ProviderIds.CustomCli);

        settings.CustomCli.Arguments = "run.js {prompt_file}";
        Assert.Equal(ChatInputOptions.TypingOnly, ChatInputs.For(settings, []));
        settings.CustomCli.Arguments = "run.js {prompt_file} {image_files}";
        Assert.Equal(new ChatInputOptions(true, false), ChatInputs.For(settings, []));
        settings.CustomCli.Arguments = "run.js {prompt_file} {image_files} {audio_files}";
        Assert.Equal(new ChatInputOptions(true, true), ChatInputs.For(settings, []));
    }

    [Theory]
    [InlineData(ProviderIds.ClaudeCli)]
    [InlineData(ProviderIds.AntigravityCli)]
    [InlineData(ProviderIds.OpenAiApi)]
    public void Other_tools_take_typing(string provider)
    {
        Assert.Equal(ChatInputOptions.TypingOnly, ChatInputs.For(Settings(provider), [Model("gpt-voice", true, "image", "audio")]));
    }
}

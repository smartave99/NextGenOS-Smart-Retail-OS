using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.Pos.Web.Services;

/// <summary>What Ask AI's box offers besides typing: photos, and voice notes.</summary>
/// <param name="Photos">The AI that answers can look at photos.</param>
/// <param name="Voice">The AI that answers can listen to a voice note (its model takes audio).</param>
public sealed record ChatInputOptions(bool Photos, bool Voice)
{
    public static readonly ChatInputOptions TypingOnly = new(false, false);
}

/// <summary>
/// Which inputs the AI that answers Ask AI takes, from what the tool itself says: Codex reads photos, and listens to a
/// voice note only with a model whose <c>inputModalities</c> include audio; a custom tool takes what its command asks
/// for ({image_files}, {audio_files}); other tools take typing only. Without a voice model, the app's microphone
/// button starts Windows voice typing instead, which types into the box.
/// </summary>
public sealed class ChatInputs(AiEnvironment ai, CodexAccountService codex, ILogger<ChatInputs> log)
{
    public async Task<ChatInputOptions> ForAskAsync(CancellationToken ct)
    {
        try
        {
            var settings = ai.LoadSettings();
            var models = AiJobs.Tool(settings) == ProviderIds.CodexCli ? await codex.ModelsAsync(ct) : Array.Empty<CodexModel>();
            return For(settings, models);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidOperationException)
        {
            log.LogInformation(ex, "Could not tell which inputs Ask AI's AI takes.");
            return ChatInputOptions.TypingOnly;
        }
    }

    /// <summary>The inputs Ask AI's AI takes with these settings; <paramref name="models"/> are the models Codex
    /// lists (none when it could not say).</summary>
    public static ChatInputOptions For(AssistantSettings settings, IReadOnlyList<CodexModel> models)
    {
        ArgumentNullException.ThrowIfNull(settings);
        switch (AiJobs.Tool(settings))
        {
            case ProviderIds.CustomCli:
                var arguments = settings.CustomCli?.Arguments ?? "";
                return new ChatInputOptions(arguments.Contains("{image_files}"), arguments.Contains("{audio_files}"));

            case ProviderIds.CodexCli:
                var (model, _) = AiJobs.Resolve(settings, AiJob.Ask);
                var chosen = string.IsNullOrWhiteSpace(model)
                    ? models.FirstOrDefault(m => m.IsDefault) ?? models.FirstOrDefault()
                    : models.FirstOrDefault(m => string.Equals(m.Id, model, StringComparison.OrdinalIgnoreCase));
                // A Codex that does not list what its models take (an older one, or one not reached) still reads photos.
                var takes = chosen?.InputModalities ?? new List<string>();
                return new ChatInputOptions(takes.Count == 0 || takes.Contains("image"), takes.Contains("audio"));

            default:
                return ChatInputOptions.TypingOnly;
        }
    }
}

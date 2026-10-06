namespace NextGenOS.Hub.Ai;

// The contracts between the shop program and the AI services. Business code talks to these and to nothing else: no vendor, no model name and no vector database appears in it, so that
// a service or a model can be replaced without touching the business. A contract is only an interface until an adapter implements it: the adapters that exist are listed in
// docs/V2-ARCHITECTURE-ASSESSMENT.md and shown in the AI settings; the others are honestly "not implemented yet".

/// <summary>Something that can be asked to do AI work, wherever it runs.</summary>
public interface IAiProvider
{
    /// <summary>The stable name the owner's settings use.</summary>
    string Id { get; }

    string DisplayName { get; }

    /// <summary>One of <see cref="ProviderLocation"/>.</summary>
    string Location { get; }

    /// <summary>The tasks it can do, from <see cref="AiTask"/>.</summary>
    IReadOnlySet<string> Tasks { get; }

    /// <summary>Is it there and does it answer? Never throws: a failure is the answer.</summary>
    Task<ProviderHealth> CheckAsync(CancellationToken cancel);
}

public sealed record ProviderHealth(bool Reachable, string Message, IReadOnlyList<string> Models, TimeSpan Latency);

public sealed record LlmMessage(string Role, string Content);

public sealed record LlmRequest(IReadOnlyList<LlmMessage> Messages, string? Model = null, double? Temperature = null, int? MaxTokens = null);

public sealed record LlmResponse(string Text, string Model, int TokensIn, int TokensOut, TimeSpan Duration);

/// <summary>Writing and answering.</summary>
public interface ILlmProvider : IAiProvider
{
    Task<LlmResponse> GenerateAsync(LlmRequest request, CancellationToken cancel);
}

public sealed record EmbeddingRequest(IReadOnlyList<string> Inputs, string? Model = null);

public sealed record EmbeddingResponse(IReadOnlyList<float[]> Vectors, string Model, int Dimensions, int TokensIn, TimeSpan Duration);

/// <summary>Turning text (later pictures) into vectors, to find similar things.</summary>
public interface IEmbeddingProvider : IAiProvider
{
    Task<EmbeddingResponse> EmbedAsync(EmbeddingRequest request, CancellationToken cancel);
}

/// <summary>A picture, or one frame of a video, given as bytes with its type.</summary>
public sealed record ImageInput(byte[] Bytes, string MediaType);

public sealed record VisionRequest(ImageInput Image, string Question, string? Model = null);

public sealed record VisionResponse(string Text, string Model, TimeSpan Duration);

/// <summary>Understanding a picture, in words.</summary>
public interface IVisionProvider : IAiProvider
{
    Task<VisionResponse> AnalyzeAsync(VisionRequest request, CancellationToken cancel);
}

public sealed record SpeechRequest(byte[] Audio, string MediaType, string? Language = null, string? Model = null);

public sealed record SpeechResponse(string Text, string? Language, TimeSpan Duration);

/// <summary>Turning speech into text.</summary>
public interface ISpeechProvider : IAiProvider
{
    Task<SpeechResponse> TranscribeAsync(SpeechRequest request, CancellationToken cancel);
}

public sealed record TextRegion(string Text, double Confidence, double X, double Y, double Width, double Height);

public sealed record OcrResponse(IReadOnlyList<TextRegion> Regions, TimeSpan Duration);

/// <summary>Reading the text in a picture or a scanned document.</summary>
public interface IOcrProvider : IAiProvider
{
    Task<OcrResponse> ReadAsync(ImageInput image, CancellationToken cancel);
}

public sealed record RankedItem(int Index, double Score);

/// <summary>Putting search results in a better order.</summary>
public interface IRerankerProvider : IAiProvider
{
    Task<IReadOnlyList<RankedItem>> RerankAsync(string query, IReadOnlyList<string> candidates, CancellationToken cancel);
}

/// <summary>A box around something in a picture, as shares (0 to 1) of the picture's width and height.</summary>
public sealed record Detection(string Label, double Confidence, double X, double Y, double Width, double Height);

/// <summary>Finding objects in a picture. What it finds is an OBSERVATION, not a business fact (docs/VERSION-2.md).</summary>
public interface IObjectDetectionProvider : IAiProvider
{
    Task<IReadOnlyList<Detection>> DetectAsync(ImageInput frame, CancellationToken cancel);
}

public sealed record Outline(string Label, double Confidence, IReadOnlyList<(double X, double Y)> Points);

/// <summary>Outlining objects in a picture.</summary>
public interface ISegmentationProvider : IAiProvider
{
    Task<IReadOnlyList<Outline>> SegmentAsync(ImageInput frame, IReadOnlyList<Detection>? hints, CancellationToken cancel);
}

public sealed record TrackedObject(string TrackId, Detection Detection);

/// <summary>Following the same object from picture to picture. One tracker follows one camera.</summary>
public interface ITrackingProvider : IAiProvider
{
    Task<IReadOnlyList<TrackedObject>> UpdateAsync(string cameraId, IReadOnlyList<Detection> detections, DateTimeOffset at, CancellationToken cancel);
}

/// <summary>Why a call to an AI service did not work, in a few kinds a screen can explain.</summary>
public sealed class ProviderException(string kind, string message, Exception? inner = null) : Exception(message, inner)
{
    public const string Unreachable = "unreachable";
    public const string Timeout = "timeout";
    public const string Unauthorized = "unauthorized";
    public const string RateLimited = "rate-limited";
    public const string BadAnswer = "bad-answer";
    public const string Refused = "refused";
    public const string NotSetUp = "not-set-up";

    public string Kind { get; } = kind;
}

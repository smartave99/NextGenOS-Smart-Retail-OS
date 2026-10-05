using Microsoft.ML.OnnxRuntime;

namespace SmartRetail.Pos.Vision;

/// <summary>Turns a picture into a vector: pictures of the same product give vectors close together.</summary>
public interface IImageEmbedder : IDisposable
{
    /// <summary>Which model made the vectors: vectors from different models are never compared.</summary>
    string ModelId { get; }

    /// <summary>The picture's vector, at unit length.</summary>
    float[] Embed(VisionImage image);
}

/// <summary>
/// DINOv2-small (or any model with its input) run on this PC with ONNX Runtime: the picture's class token, which says
/// what the picture shows as a whole. Two threads only, so the POS stays quick; one picture at a time.
/// </summary>
public sealed class OnnxImageEmbedder : IImageEmbedder
{
    private const string Input = "pixel_values";

    private readonly InferenceSession _session;
    private readonly string _output;
    private readonly object _gate = new();
    private bool _disposed;

    public OnnxImageEmbedder(string modelPath, string modelId, int threads = 2)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(modelPath);
        ModelId = modelId ?? throw new ArgumentNullException(nameof(modelId));
        using var options = new SessionOptions
        {
            GraphOptimizationLevel = GraphOptimizationLevel.ORT_ENABLE_ALL,
            ExecutionMode = ExecutionMode.ORT_SEQUENTIAL,
            IntraOpNumThreads = Math.Max(1, threads),
            InterOpNumThreads = 1,
        };
        _session = new InferenceSession(modelPath, options);
        if (!_session.InputMetadata.ContainsKey(Input))
        {
            _session.Dispose();
            throw new InvalidOperationException("The model has no \"" + Input + "\" input.");
        }

        // DINOv2's pooled output is its class token after the last layer norm; without it, the first token is the same.
        _output = _session.OutputMetadata.ContainsKey("pooler_output") ? "pooler_output"
            : _session.OutputMetadata.ContainsKey("last_hidden_state") ? "last_hidden_state"
            : throw new InvalidOperationException("The model gives neither \"pooler_output\" nor \"last_hidden_state\".");
    }

    public string ModelId { get; }

    public float[] Embed(VisionImage image)
    {
        var input = ImageMath.Preprocess(image);
        lock (_gate)
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            using var tensor = OrtValue.CreateTensorValueFromMemory(input, new long[] { 1, 3, ImageMath.InputSize, ImageMath.InputSize });
            using var runOptions = new RunOptions();
            using var results = _session.Run(runOptions, new[] { Input }, new[] { tensor }, new[] { _output });
            var output = results[0];
            var shape = output.GetTensorTypeAndShape().Shape;
            var size = (int)shape[^1];
            // pooler_output is 1 x size; last_hidden_state is 1 x tokens x size, the class token first.
            return VectorMath.Normalize(output.GetTensorDataAsSpan<float>()[..size].ToArray());
        }
    }

    /// <summary>Frees the model; waits for a picture being looked at to finish first.</summary>
    public void Dispose()
    {
        lock (_gate)
        {
            if (!_disposed)
            {
                _disposed = true;
                _session.Dispose();
            }
        }
    }
}

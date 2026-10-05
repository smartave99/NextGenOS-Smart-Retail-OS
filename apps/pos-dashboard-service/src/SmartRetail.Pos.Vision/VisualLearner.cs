namespace SmartRetail.Pos.Vision;

/// <summary>
/// Keeps each product's visual.json and the index up to date with its photos: a photo is looked at once, its vectors
/// kept next to it, and vectors of photos no longer used are dropped. A photo that cannot be read is left out.
/// </summary>
public sealed class VisualLearner
{
    private readonly VisualIndex _index;
    private readonly IImageEmbedder _embedder;

    public VisualLearner(VisualIndex index, IImageEmbedder embedder)
    {
        _index = index ?? throw new ArgumentNullException(nameof(index));
        _embedder = embedder ?? throw new ArgumentNullException(nameof(embedder));
    }

    /// <summary>
    /// Puts what was learned before about the product's <paramref name="files"/> (names in <paramref name="folder"/>)
    /// into the index. True when some of them are still to be learned, or visual.json holds photos no longer used.
    /// </summary>
    public bool Load(int productId, string? folder, IReadOnlyCollection<string> files)
    {
        ArgumentNullException.ThrowIfNull(files);
        if (folder is null || files.Count == 0)
        {
            _index.Set(productId, Array.Empty<PhotoVector>());
            return folder is not null && VisualStore.Read(folder, _embedder.ModelId).Count > 0;
        }

        var kept = VisualStore.Read(folder, _embedder.ModelId);
        var used = kept.Where(v => files.Contains(v.File)).ToList();
        _index.Set(productId, used);
        return used.Count != files.Count || used.Count != kept.Count;
    }

    /// <summary>
    /// Learns the product's photos not learned yet, keeps visual.json and updates the index. Nothing is written when
    /// <paramref name="mayWrite"/> says no (e.g. the data folder is being moved): false then, to try again later.
    /// </summary>
    public bool Learn(int productId, string? folder, IReadOnlyCollection<string> files, Func<bool>? mayWrite = null)
    {
        ArgumentNullException.ThrowIfNull(files);
        if (folder is null)
        {
            _index.Set(productId, Array.Empty<PhotoVector>());
            return true;
        }

        var kept = VisualStore.Read(folder, _embedder.ModelId);
        var known = kept.Where(v => files.Contains(v.File)).ToDictionary(v => v.File);
        var vectors = new List<PhotoVector>();
        var changed = known.Count != kept.Count;
        foreach (var file in files)
        {
            if (known.TryGetValue(file, out var vector))
            {
                vectors.Add(vector);
                continue;
            }

            var path = Path.Combine(folder, file);
            var image = File.Exists(path) ? VisionImage.Decode(File.ReadAllBytes(path)) : null;
            if (image is null)
            {
                continue;
            }

            vectors.Add(new PhotoVector(file, _embedder.Embed(image), ColourHistogram.Of(image)));
            changed = true;
        }

        if (changed)
        {
            if (mayWrite is not null && !mayWrite())
            {
                return false;
            }

            VisualStore.Write(folder, _embedder.ModelId, vectors);
        }

        _index.Set(productId, vectors);
        return true;
    }
}

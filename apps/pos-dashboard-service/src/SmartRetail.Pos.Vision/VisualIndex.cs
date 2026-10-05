namespace SmartRetail.Pos.Vision;

/// <summary>One photo's vectors, by the photo's file name: what the model sees, and its colours.</summary>
public sealed record PhotoVector(string File, float[] Vector, float[] Colour);

/// <summary>A product that looks like the photo: how alike (0 to 1) its most alike photo is, and which photo that is.</summary>
public sealed record LookMatch(int ProductId, float Score, string File);

/// <summary>
/// Every product's photo vectors, in memory, to find the products a camera photo looks like: each product counts once,
/// by its most alike photo. How alike is mostly what the model sees (its shape and detail) and partly its colours, so
/// that products of the same shape in other colours come apart. Safe to read while it is being filled.
/// </summary>
public sealed class VisualIndex
{
    public const float LookWeight = 0.7f;
    public const float ColourWeight = 0.3f;

    /// <summary>Below this, a product does not look like the photo at all.</summary>
    public const float Floor = 0.35f;

    /// <summary>The first match is the best one only when it leads the next by this much.</summary>
    public const float SureMargin = 0.05f;

    private readonly object _gate = new();
    private Dictionary<int, IReadOnlyList<PhotoVector>> _products = new();

    public int ProductCount
    {
        get
        {
            lock (_gate)
            {
                return _products.Count;
            }
        }
    }

    /// <summary>Sets a product's vectors; none takes it out.</summary>
    public void Set(int productId, IReadOnlyList<PhotoVector> vectors)
    {
        ArgumentNullException.ThrowIfNull(vectors);
        lock (_gate)
        {
            var next = new Dictionary<int, IReadOnlyList<PhotoVector>>(_products);
            if (vectors.Count == 0)
            {
                next.Remove(productId);
            }
            else
            {
                next[productId] = vectors.ToList();
            }

            _products = next;
        }
    }

    public void Clear()
    {
        lock (_gate)
        {
            _products = new Dictionary<int, IReadOnlyList<PhotoVector>>();
        }
    }

    public bool Contains(int productId)
    {
        lock (_gate)
        {
            return _products.ContainsKey(productId);
        }
    }

    /// <summary>The <paramref name="count"/> products most like the photo, most alike first, none below <see cref="Floor"/>.</summary>
    public IReadOnlyList<LookMatch> Search(float[] vector, float[] colour, int count = 5)
    {
        ArgumentNullException.ThrowIfNull(vector);
        ArgumentNullException.ThrowIfNull(colour);
        Dictionary<int, IReadOnlyList<PhotoVector>> products;
        lock (_gate)
        {
            products = _products;
        }

        return products
            .Select(product => product.Value
                .Select(photo => new LookMatch(product.Key, Score(vector, colour, photo), photo.File))
                .MaxBy(match => match.Score)!)
            .Where(match => match.Score >= Floor)
            .OrderByDescending(match => match.Score)
            .ThenBy(match => match.ProductId)
            .Take(Math.Max(0, count))
            .ToList();
    }

    /// <summary>The first match leads the next by enough to call it the best one.</summary>
    public static bool IsSure(IReadOnlyList<LookMatch> matches) =>
        matches.Count == 1 || (matches.Count > 1 && matches[0].Score - matches[1].Score >= SureMargin);

    public static float Score(float[] vector, float[] colour, PhotoVector photo) =>
        LookWeight * VectorMath.Similarity(vector, photo.Vector) + ColourWeight * VectorMath.Similarity(colour, photo.Colour);
}

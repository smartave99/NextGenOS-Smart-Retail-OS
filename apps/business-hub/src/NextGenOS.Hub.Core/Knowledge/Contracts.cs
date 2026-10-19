namespace NextGenOS.Hub.Knowledge;

// What the notes and the search of them are made of. The business never names a vector database: it talks to <see cref="IVectorIndex"/>, and what is behind it (today a table of the shop's own
// file, searched by comparing every vector; later pgvector or Qdrant, which need no change here) can be replaced.

/// <summary>One close vector: which piece of which note, and how close (1 is the same direction, 0 unrelated).</summary>
public sealed record VectorHit(long SourceId, int Seq, double Similarity);

/// <summary>
/// Where the vectors of the notes' pieces are kept and searched. Vectors made by different models are kept apart by the model's name and are never compared with each other. The numbers are
/// made unit length when they are put in, so that the closeness of two is their dot product.
/// </summary>
public interface IVectorIndex
{
    /// <summary>Keeps the vector of one piece (replacing one that was there). A vector that is empty, not a number or all zeros is refused.</summary>
    void Put(long sourceId, int seq, string model, float[] vector, DateTimeOffset at);

    /// <summary>The pieces closest to <paramref name="query"/> among those made by <paramref name="model"/>, closest first; only those of <paramref name="sourceIds"/> when given.</summary>
    IReadOnlyList<VectorHit> Nearest(string model, float[] query, int limit, IReadOnlyCollection<long>? sourceIds = null);

    /// <summary>Forgets every vector (the notes' words stay), for example before the model is changed.</summary>
    int Clear();

    /// <summary>How many pieces have a vector, by the model that made it.</summary>
    IReadOnlyDictionary<string, long> Counts();
}

/// <summary>A note as the owner's screen lists it.</summary>
public sealed record KnowledgeSource(
    long Id, string Ref, string Kind, string Title, string DataClass, int Chars, int Pieces, int PiecesWithVectors, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt, DateTimeOffset? RetiredAt)
{
    public bool Retired => RetiredAt is not null;
}

/// <summary>One thing found: which note (by its reference, so that an answer can point at it), the piece that matched and how well. <see cref="ByMeaning"/> says a vector helped to find it. <see cref="DataClass"/> is the kind of information the note holds, so that whoever uses the piece next (the assistant) sends it only where that kind may go.</summary>
public sealed record KnowledgeHit(string Ref, string Title, int Piece, string Excerpt, double Score, bool ByMeaning, string DataClass);

/// <summary>What a search found, and whether the meaning of the words was used (and, when not, why not, in plain words).</summary>
public sealed record KnowledgeAnswer(IReadOnlyList<KnowledgeHit> Hits, bool UsedMeaning, string? Note);

/// <summary>What a pass of making vectors did.</summary>
public sealed record PrepareResult(int Prepared, int Waiting, string? Note);

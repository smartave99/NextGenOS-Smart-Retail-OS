namespace SmartRetail.Pos.Vision;

/// <summary>Vectors made from photos: made unit length, so that how alike two photos are is their dot product.</summary>
public static class VectorMath
{
    /// <summary>The vector at unit length (all zeros stay zeros).</summary>
    public static float[] Normalize(float[] vector)
    {
        ArgumentNullException.ThrowIfNull(vector);
        double sum = 0;
        foreach (var value in vector)
        {
            sum += (double)value * value;
        }

        var length = Math.Sqrt(sum);
        var unit = new float[vector.Length];
        if (length > 1e-12 && double.IsFinite(length))
        {
            for (var i = 0; i < vector.Length; i++)
            {
                unit[i] = (float)(vector[i] / length);
            }
        }

        return unit;
    }

    /// <summary>How alike two unit vectors are: 1 the same, 0 unrelated. Vectors of different lengths are unrelated.</summary>
    public static float Similarity(float[] a, float[] b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);
        if (a.Length != b.Length)
        {
            return 0f;
        }

        double sum = 0;
        for (var i = 0; i < a.Length; i++)
        {
            sum += (double)a[i] * b[i];
        }

        return (float)sum;
    }
}

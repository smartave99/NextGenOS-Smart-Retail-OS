using System;

namespace SmartRetail.AI.Products
{
    /// <summary>
    /// The shape of the owner's phone photo (as it is shown, turned the way it is held), which the photos the AI makes follow:
    /// the same orientation and the same width to height, so each one fills the same place on a website or Amazon. The
    /// image tool makes only three shapes (1024 × 1024, 1536 × 1024 and 1024 × 1536), so it is asked for the nearest and
    /// the result is then trimmed from the middle to exactly the shape of the owner's photo (<see cref="CropTo"/>).
    /// </summary>
    public sealed class PhotoShape
    {
        /// <summary>A result within this share of the owner's shape is left as it is: a trim of a few pixels is not worth it.</summary>
        public const double Tolerance = 0.005;

        public PhotoShape(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>The owner's photo as shown, in pixels; 0 when it is not known.</summary>
        public int Width { get; }

        public int Height { get; }

        public bool IsKnown => Width > 0 && Height > 0;

        /// <summary>Width divided by height.</summary>
        public double Ratio => IsKnown ? (double)Width / Height : 1d;

        /// <summary>"portrait", "landscape" or "square" (within a fifth either way).</summary>
        public string Orientation => !IsKnown || (Ratio <= 1.2 && Ratio >= 1d / 1.2) ? "square" : Ratio > 1 ? "landscape" : "portrait";

        /// <summary>The shape the image tool is asked for, e.g. "1024 x 1536 (tall)".</summary>
        public string ToolSize => Orientation == "landscape" ? "1536 x 1024 (wide)" : Orientation == "portrait" ? "1024 x 1536 (tall)" : "1024 x 1024 (square)";

        /// <summary>The shape as a simple ratio, e.g. "3:4"; the nearest of the usual ones when it is close to one, else the numbers.</summary>
        public string RatioText
        {
            get
            {
                if (!IsKnown)
                {
                    return "1:1";
                }

                var wide = Width >= Height;
                var longer = Math.Max(Width, Height);
                var shorter = Math.Min(Width, Height);
                foreach (var (a, b) in new[] { (1, 1), (5, 4), (4, 3), (3, 2), (16, 9), (2, 1) })
                {
                    if (Math.Abs((double)longer / shorter - (double)a / b) <= 0.02 * a / b)
                    {
                        return wide ? a + ":" + b : b + ":" + a;
                    }
                }

                return wide ? longer + ":" + shorter : shorter + ":" + longer;
            }
        }

        /// <summary>E.g. "portrait, 3:4 (3024 × 4032 pixels)".</summary>
        public string Describe() => IsKnown ? Orientation + ", " + RatioText + " (" + Width + " × " + Height + " pixels)" : "square";

        /// <summary>Whether an image of this size is already the owner's shape.</summary>
        public bool Matches(int width, int height) =>
            !IsKnown || (width > 0 && height > 0 && Math.Abs((double)width / height - Ratio) <= Tolerance * Ratio);

        /// <summary>
        /// The part of a <paramref name="width"/> × <paramref name="height"/> image to keep so that it has this shape: cut from
        /// the middle, never stretched. The whole image when it already has the shape or the shape is not known.
        /// </summary>
        public (int X, int Y, int Width, int Height) CropTo(int width, int height)
        {
            if (!IsKnown || width <= 0 || height <= 0 || Matches(width, height))
            {
                return (0, 0, Math.Max(0, width), Math.Max(0, height));
            }

            var current = (double)width / height;
            if (current > Ratio)
            {
                // Too wide: keep the middle columns.
                var kept = Math.Max(1, (int)Math.Round(height * Ratio));
                return ((width - kept) / 2, 0, kept, height);
            }

            var rows = Math.Max(1, (int)Math.Round(width / Ratio));
            return (0, (height - rows) / 2, width, rows);
        }
    }
}

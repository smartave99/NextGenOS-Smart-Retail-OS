using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;

namespace SmartRetail.AI.Desktop
{
    /// <summary>The app's mark (a sparkle on a violet-to-blue square), as the dashboard draws it, for native parts.</summary>
    internal static class AppMarkPainter
    {
        private static Image _mark;

        /// <summary>The mark as a 256-pixel image (app-mark.png, built into the app).</summary>
        public static Image Mark
        {
            get
            {
                if (_mark == null)
                {
                    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SmartRetail.AI.Desktop.app-mark.png"))
                    {
                        _mark = stream == null ? new Bitmap(1, 1) : Image.FromStream(new MemoryStream(ReadAll(stream)));
                    }
                }

                return _mark;
            }
        }

        public static void Draw(Graphics graphics, Rectangle bounds)
        {
            var mode = graphics.InterpolationMode;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(Mark, bounds);
            graphics.InterpolationMode = mode;
        }

        /// <summary>The mark's four-pointed star, fitted into <paramref name="bounds"/>.</summary>
        public static GraphicsPath Sparkle(RectangleF bounds)
        {
            // The mark's big star, from its 64-unit drawing (centre 28, 33; 38 units across).
            var path = new GraphicsPath();
            path.AddBezier(28f, 14f, 29.6f, 25.6f, 34.4f, 30.4f, 47f, 33f);
            path.AddBezier(47f, 33f, 34.4f, 35.6f, 29.6f, 40.4f, 28f, 52f);
            path.AddBezier(28f, 52f, 26.4f, 40.4f, 21.6f, 35.6f, 9f, 33f);
            path.AddBezier(9f, 33f, 21.6f, 30.4f, 26.4f, 25.6f, 28f, 14f);
            path.CloseFigure();
            using (var fit = new Matrix())
            {
                var scale = System.Math.Min(bounds.Width, bounds.Height) / 38f;
                fit.Translate(bounds.X + bounds.Width / 2f, bounds.Y + bounds.Height / 2f);
                fit.Scale(scale, scale);
                fit.Translate(-28f, -33f);
                path.Transform(fit);
            }

            return path;
        }

        private static byte[] ReadAll(Stream stream)
        {
            using (var copy = new MemoryStream())
            {
                stream.CopyTo(copy);
                return copy.ToArray();
            }
        }
    }
}

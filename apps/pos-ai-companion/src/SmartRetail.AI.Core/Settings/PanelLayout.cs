using System;

namespace SmartRetail.AI.Settings
{
    /// <summary>A rectangle in screen pixels.</summary>
    public readonly struct PixelRect : IEquatable<PixelRect>
    {
        public PixelRect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int X { get; }

        public int Y { get; }

        public int Width { get; }

        public int Height { get; }

        public int Right => X + Width;

        public int Bottom => Y + Height;

        public bool Equals(PixelRect other) => X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;

        public override bool Equals(object obj) => obj is PixelRect other && Equals(other);

        public override int GetHashCode() => ((X * 397 ^ Y) * 397 ^ Width) * 397 ^ Height;

        public override string ToString() => "(" + X + ", " + Y + ", " + Width + " × " + Height + ")";
    }

    /// <summary>Where the assistant's windows go on a screen. The work area is the screen without the taskbar.</summary>
    public static class PanelLayout
    {
        public const int TabWidth = 28;
        public const int TabHeight = 112;

        /// <summary>
        /// The side panel fills the height of the work area on the chosen edge. It never takes more than half
        /// the screen, so the POS stays usable beside it; <paramref name="wide"/> makes room for big tables.
        /// </summary>
        public static PixelRect Panel(PixelRect workArea, PanelEdge edge, int width, bool wide = false)
        {
            var half = Math.Max(PanelSettings.MinimumWidth, workArea.Width / 2);
            var panelWidth = Math.Min(Math.Max(width, PanelSettings.MinimumWidth), half);
            if (wide)
            {
                panelWidth = Math.Max(panelWidth, workArea.Width * 3 / 5);
            }

            panelWidth = Math.Min(panelWidth, workArea.Width);
            var x = edge == PanelEdge.Left ? workArea.X : workArea.Right - panelWidth;
            return new PixelRect(x, workArea.Y, panelWidth, workArea.Height);
        }

        /// <summary>The "AI" tab sits on the same edge, a little above the middle of the work area.</summary>
        public static PixelRect Tab(PixelRect workArea, PanelEdge edge)
        {
            var height = Math.Min(TabHeight, workArea.Height);
            var x = edge == PanelEdge.Left ? workArea.X : workArea.Right - TabWidth;
            var y = workArea.Y + (workArea.Height - height) * 2 / 5;
            return new PixelRect(x, y, TabWidth, height);
        }

        /// <summary>A normal window of the wanted size, shrunk to fit the work area and centred in it.</summary>
        public static PixelRect CenteredWindow(PixelRect workArea, int width, int height)
        {
            var fittedWidth = Math.Min(width, workArea.Width);
            var fittedHeight = Math.Min(height, workArea.Height);
            return new PixelRect(
                workArea.X + (workArea.Width - fittedWidth) / 2,
                workArea.Y + (workArea.Height - fittedHeight) / 2,
                fittedWidth,
                fittedHeight);
        }
    }
}

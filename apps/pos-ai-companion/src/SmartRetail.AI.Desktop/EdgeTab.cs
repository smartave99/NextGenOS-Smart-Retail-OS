using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>The small "AI" tab on the screen edge that opens the side panel. It never takes the focus away from the POS.</summary>
    internal sealed class EdgeTab : Form
    {
        private const int WsExTopmost = 0x00000008;
        private const int WsExToolWindow = 0x00000080;
        private const int WsExNoActivate = 0x08000000;
        // The app's colours: violet at the top to blue at the bottom.
        private static readonly Color TopColor = Color.FromArgb(122, 92, 255);
        private static readonly Color BottomColor = Color.FromArgb(10, 132, 255);

        private readonly ToolTip _toolTip = new ToolTip();
        private PanelEdge _edge;

        public EdgeTab()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            BackColor = BottomColor;
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Text = Branding.AssistantName;
        }

        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                var parameters = base.CreateParams;
                parameters.ExStyle |= WsExTopmost | WsExToolWindow | WsExNoActivate;
                return parameters;
            }
        }

        public void Place(PixelRect bounds, PanelEdge edge, string toolTip)
        {
            _edge = edge;
            Bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            var old = Region;
            Region = RoundedOnInnerSide(bounds.Width, bounds.Height, edge);
            old?.Dispose();
            _toolTip.SetToolTip(this, toolTip);
            Invalidate();
        }

        private bool _hover;

        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var fill = new LinearGradientBrush(ClientRectangle, TopColor, BottomColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(fill, ClientRectangle);
            }

            if (_hover)
            {
                using (var light = new SolidBrush(Color.FromArgb(40, Color.White)))
                {
                    e.Graphics.FillRectangle(light, ClientRectangle);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // The app's sparkle, and an arrow pointing into the screen.
            var size = Math.Min(Width - 8f, 18f);
            using (var sparkle = AppMarkPainter.Sparkle(new RectangleF((Width - size) / 2f, Height * 0.2f, size, size)))
            {
                e.Graphics.FillPath(Brushes.White, sparkle);
            }

            using (var arrowFont = new Font("Segoe UI", 12f, FontStyle.Bold))
            using (var centred = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(_edge == PanelEdge.Left ? "›" : "‹", arrowFont, Brushes.White, new RectangleF(0, Height * 0.58f, Width, 26), centred);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _toolTip.Dispose();
            }

            base.Dispose(disposing);
        }

        private static Region RoundedOnInnerSide(int width, int height, PanelEdge edge)
        {
            const int diameter = 16;
            using (var path = new GraphicsPath())
            {
                if (edge == PanelEdge.Right)
                {
                    path.AddArc(0, 0, diameter, diameter, 180, 90);
                    path.AddLine(diameter / 2, 0, width, 0);
                    path.AddLine(width, 0, width, height);
                    path.AddLine(width, height, diameter / 2, height);
                    path.AddArc(0, height - diameter, diameter, diameter, 90, 90);
                }
                else
                {
                    path.AddLine(0, 0, width - diameter / 2, 0);
                    path.AddArc(width - diameter, 0, diameter, diameter, 270, 90);
                    path.AddArc(width - diameter, height - diameter, diameter, diameter, 0, 90);
                    path.AddLine(width - diameter / 2, height, 0, height);
                }

                path.CloseFigure();
                return new Region(path);
            }
        }
    }
}

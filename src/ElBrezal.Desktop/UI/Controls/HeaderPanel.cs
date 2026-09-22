using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ElBrezal.Desktop.UI.Controls
{
    public class HeaderPanel : Panel
    {
        private static readonly Color ColorInicioDefault =
            Color.FromArgb(185, 215, 245);

        private static readonly Color ColorFinDefault =
            Color.FromArgb(235, 245, 255);

        private Color _colorInicio = ColorInicioDefault;
        private Color _colorFin = ColorFinDefault;

        [Category("Apariencia")]
        [Description("Color inicial del degradado.")]
        public Color ColorInicio
        {
            get => _colorInicio;
            set
            {
                _colorInicio = value;
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Color final del degradado.")]
        public Color ColorFin
        {
            get => _colorFin;
            set
            {
                _colorFin = value;
                Invalidate();
            }
        }

        public HeaderPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        public bool ShouldSerializeColorInicio()
        {
            return ColorInicio != ColorInicioDefault;
        }

        public void ResetColorInicio()
        {
            ColorInicio = ColorInicioDefault;
        }

        public bool ShouldSerializeColorFin()
        {
            return ColorFin != ColorFinDefault;
        }

        public void ResetColorFin()
        {
            ColorFin = ColorFinDefault;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (ClientRectangle.Width <= 0 ||
                ClientRectangle.Height <= 0)
            {
                return;
            }

            using var brush = new LinearGradientBrush(
                ClientRectangle,
                ColorInicio,
                ColorFin,
                LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(
                brush,
                ClientRectangle);
        }
    }
}
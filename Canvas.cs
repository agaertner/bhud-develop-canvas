using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlishHUD
{
    public partial class Canvas : Form
    {
        public Canvas(Size size, Color backColor)
        {
            InitializeComponent();

            Size = size;
            BackColor = backColor;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Paint += Canvas_Paint;
            Resize += Canvas_Resize;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // Draw watermark
            using (var brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                var watermarkText = "Work in Progress";
                var textSize = e.Graphics.MeasureString(watermarkText, Font);

                var watermarkX = ClientSize.Width - (int)textSize.Width - 10;
                var watermarkY = ClientSize.Height - (int)textSize.Height - 10;

                e.Graphics.DrawString(watermarkText, Font, brush, watermarkX, watermarkY);
            }
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            // Trigger a repaint of the form to reposition the watermark.
            Invalidate();
        }
    }
}

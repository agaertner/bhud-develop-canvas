using System;
using System.Drawing;
using System.Windows.Forms;

namespace canvas
{
    public partial class Canvas : Form
    {

        private Label _watermarkLabel;
        private Timer animationTimer = new Timer();
        private int frameCount = 0;

        public Canvas(Size size, Color backColor)
        {
            InitializeComponent();
            // Initialize form properties
            Size = size;
            BackColor = backColor;

            // Set the form icon to the icon of the executable
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            // Hook up the Paint event to draw the watermark
            Paint += Canvas_Paint;

            // Set up the animation timer
            animationTimer.Interval = 60; // Set the desired frame rate (e.g., 60 fps)
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // Draw the watermark label with transparency
            using (var brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0))) // Adjust the alpha value to control transparency
            {
                var watermarkText = "Work in Progress";
                var textSize = e.Graphics.MeasureString(watermarkText, Font);

                // Calculate the position to center the watermark in the bottom-right corner
                var watermarkX = ClientSize.Width - (int)textSize.Width - 10;
                var watermarkY = ClientSize.Height - (int)textSize.Height - 10;

                e.Graphics.DrawString(watermarkText, Font, brush, watermarkX, watermarkY);
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Trigger a repaint of the form
            Invalidate();
        }
    }
}

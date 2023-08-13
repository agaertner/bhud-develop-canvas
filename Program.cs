using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlishHUD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var formSize = new Size(1280, 720); // Default form size
            var backColor = Color.FromArgb(255,0,255,0); // Default background color

            for (int i = 0; i < args.Length; i += 2)
            {
                if (i + 1 < args.Length)
                {
                    if (args[i] == "--resolution")
                    {
                        string[] resolutionArgs = args[i + 1].Split('x');
                        if (resolutionArgs.Length == 2 && int.TryParse(resolutionArgs[0], out int width) && int.TryParse(resolutionArgs[1], out int height))
                        {
                            formSize = new Size(width, height);
                        }
                    }
                    else if (args[i] == "--color")
                    {
                        try
                        {
                            backColor = ColorTranslator.FromHtml(args[i + 1]);
                        }
                        catch (Exception e)
                        {
                            throw new ArgumentException("Invalid color format. Please use a hex color code.", e);
                        }
                    }
                }
            }
            Application.Run(new Canvas(formSize, backColor));
        }
    }
}

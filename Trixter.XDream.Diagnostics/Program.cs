using System;
using System.Windows.Forms;

namespace Trixter.XDream.Diagnostics
{

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm() { DataAccess = dataAccess };
            Application.Run(mainForm);

            return 0;
        }
    }
}

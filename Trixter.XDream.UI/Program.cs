using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixter.XDream.UI.Properties;

namespace Trixter.XDream.UI
{

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {

            if (args.Length > 0 && args[0].ToLower() == "--console")
            {
             

                    return ConsoleFunctionality.Entry(args);
                
            }
            else
            {
                //Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }

            return 0;
        }
    }
}

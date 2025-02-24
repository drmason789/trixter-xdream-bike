using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixter.XDream.Diagnostics.Properties;

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
     

            if (args.Length > 0 && args[0].ToLower() == "--console")
            {
             

                    return ConsoleFunctionality.Entry(args);
                
            }
            else
            {
                DataAccess dataAccess = new DataAccess();
                //Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm mainForm = new MainForm() { DataAccess = dataAccess };
                Application.Run(mainForm);
            }

            return 0;
        }
    }
}

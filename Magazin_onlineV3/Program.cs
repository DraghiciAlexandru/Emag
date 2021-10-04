using Magazin_onlineV3.Controlere;
using Magazin_onlineV3.Model;
using Magazin_onlineV3.Template;
using Magazin_onlineV3.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ViewHome());
        }
    }
}

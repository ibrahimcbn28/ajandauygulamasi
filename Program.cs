using ajanda;
using ajanda.Cls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ajanda
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            SQLConnectionClass.Baglanti();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Anaform());
        }
    }
}

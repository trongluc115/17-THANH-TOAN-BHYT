using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediIT115
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
            //  Application.Run(new frmLogin());
            //  Application.Run(new FrmMain1());
            Application.Run(new FrmMain1());
        }
    }
}
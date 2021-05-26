using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WFFDR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {


            if (Environment.OSVersion.Version.Major == 6)
                SetProcessDPIAware();
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());



            Form1 login = new Form1();
            login.Show();

            //frmLoan frmloan = new frmLoan();
            //frmloan.Show();


            
            Application.Run();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

    }
}

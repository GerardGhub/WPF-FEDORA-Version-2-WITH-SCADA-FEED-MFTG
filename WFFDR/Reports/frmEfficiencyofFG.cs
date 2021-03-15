using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class frmEfficiencyofFG : Form
    {
        public frmEfficiencyofFG()
        {
            InitializeComponent();
        }

        private void frmEfficiencyofFG_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            myglobal.DATE_REPORT = dateTimePicker3.Text;
            myglobal.DATE_REPORT2 = dtp3.Text;
       
            myglobal.REPORT_NAME = "DailyFGTotalPercentage";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
     frmEfficiencyofFG_Load(sender, e);
        }
    }
}

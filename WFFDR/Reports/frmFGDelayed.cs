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
    public partial class frmFGDelayed : Form
    {
        public frmFGDelayed()
        {
            InitializeComponent();
        }

        private void frmFGDelayed_Load(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            myglobal.DATE_REPORT = dateTimePicker5.Text;
            myglobal.DATE_REPORT2 = dtp5.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "DailyFGTotalDelayed";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
       frmFGDelayed_Load(sender, e);
        }
    }
}

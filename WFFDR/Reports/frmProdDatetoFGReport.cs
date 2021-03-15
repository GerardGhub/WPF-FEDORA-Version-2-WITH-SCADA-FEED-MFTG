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
    public partial class frmProdDatetoFGReport : Form
    {
        public frmProdDatetoFGReport()
        {
            InitializeComponent();
        }

        private void frmProdDatetoFGReport_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            myglobal.DATE_REPORT = dateTimePicker1.Text;
            myglobal.DATE_REPORT2 = dtp1.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "DailyFGTotalProduction";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        frmProdDatetoFGReport_Load(sender, e);
        }
    }
}

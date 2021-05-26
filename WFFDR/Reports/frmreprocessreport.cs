using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR.Reports
{
    public partial class frmreprocessreport : Form
    {
        public frmreprocessreport()
        {
            InitializeComponent();
        }

        private void frmreprocessreport_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            dtp1.MaxDate = DateTime.Today;

        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dateTimePicker1.Text;
            myglobal.DATE_REPORT2 = dtp1.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            //myglobal.REPORT_NAME = "DailyFGTotalProduction";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
            this.Close();
        }
    }
}

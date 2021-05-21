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
    public partial class FrmfGTransactReceivedReport : Form
    {
        public FrmfGTransactReceivedReport()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtpprod1.Text;
            myglobal.DATE_REPORT2 = dtpprod2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGTransactReceivedReports";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

            this.Close();
        }

        private void FrmfGTransactReceivedReport_Load(object sender, EventArgs e)
        {
            dtpprod1.MaxDate = DateTime.Today;
             dtpprod2.MaxDate = DateTime.Today;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}

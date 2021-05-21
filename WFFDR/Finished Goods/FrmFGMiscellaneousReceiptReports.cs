using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR.Finished_Goods
{
    public partial class FrmFGMiscellaneousReceiptReports : Form
    {
        public FrmFGMiscellaneousReceiptReports()
        {
            InitializeComponent();
        }

        private void btndailyprod_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtpprod1.Text;
            myglobal.DATE_REPORT2 = dtpprod2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMiscellaneousReceiptReports";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void FrmFGMiscellaneousReceiptReports_Load(object sender, EventArgs e)
        {
            dtpprod1.MaxDate = DateTime.Now;
            dtpprod2.MaxDate = DateTime.Now;
        }
    }
}

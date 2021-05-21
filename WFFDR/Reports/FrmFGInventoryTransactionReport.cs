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
    public partial class FrmFGInventoryTransactionReport : Form
    {
        public FrmFGInventoryTransactionReport()
        {
            InitializeComponent();
        }

        private void FrmFGInventoryTransactionReport_Load(object sender, EventArgs e)
        {
            dtpprod1.MaxDate = DateTime.Now;
            dtpprod2.MaxDate = DateTime.Now;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtpprod1.Text;
            myglobal.DATE_REPORT2 = dtpprod2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGInventory";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

            this.Close();
        }
    }
}

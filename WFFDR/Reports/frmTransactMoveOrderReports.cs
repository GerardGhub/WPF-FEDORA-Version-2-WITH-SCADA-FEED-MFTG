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
    public partial class frmTransactMoveOrderReports : Form
    {
        public frmTransactMoveOrderReports()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btndailyprod_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtpprod1.Text;
            myglobal.DATE_REPORT2 = dtpprod2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMoveOrderDone";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void frmTransactMoveOrderReports_Load(object sender, EventArgs e)
        {
            dtpprod1.MaxDate = DateTime.Today;
            dtpprod2.MaxDate = DateTime.Today;
        }
    }
    }


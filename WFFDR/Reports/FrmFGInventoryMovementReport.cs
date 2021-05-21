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
    public partial class FrmFGInventoryMovementReport : Form
    {
        public FrmFGInventoryMovementReport()
        {
            InitializeComponent();
        }

        private void FrmFGInventoryMovementReport_Load(object sender, EventArgs e)
        {
            f1.Text = "04/08/2021";
            f2.MaxDate = DateTime.Now;
            f2.MinDate = f1.Value;
            
            f4.Value = DateTime.Now;

            //if (f4.Text == f2.Text)
            //{
            //    f3.Value = DateTime.Now;


            //}
            //else
            //{
                f3.Value = f2.Value.AddDays(1);
            //}
        }

        private void f2_ValueChanged(object sender, EventArgs e)
        {
            
            //if(f4.Text==f2.Text)
            //{
            //    f3.Value = DateTime.Now;


            //}
            //else
            //{ 
            f3.Value = f2.Value.AddDays(1);
            //}
        }

        private void btnFeedCodeSearch_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = "04/08/2021";
            myglobal.DATE_REPORT2 = f2.Text;
            myglobal.DATE_REPORT3 = f3.Text;
            myglobal.DATE_REPORT4 = f4.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGInventoryMovementReport";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }
    }
}

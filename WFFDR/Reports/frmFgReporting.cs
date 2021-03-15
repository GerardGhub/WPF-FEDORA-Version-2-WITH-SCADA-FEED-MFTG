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
    public partial class frmFgReporting : Form
    {
        public frmFgReporting(string prod1, string prod2)
        {
            InitializeComponent();
            this.prod1 = prod1;
            this.prod2 = prod2;
        }
        public string prod1 { get; set;}
        public string prod2 { get; set; }

        private void frmFgReporting_Load(object sender, EventArgs e)
        {


     dtpprod1.Text = prod1;
     dtpprod2.Text = prod2;
            btnGenerate.Enabled = true;

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
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

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
    public partial class frmRawMatsTheoMovementReports : Form
    {
        public frmRawMatsTheoMovementReports()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(cboStatus.Text.Trim() == string.Empty)
            {
                return;
            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Print the Data ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (cboStatus.Text == "MICRO")
                {

                    myglobal.DATE_REPORT = dtp1.Text; //@ddate
                    myglobal.DATE_REPORT2 = dtp2.Text; //@ddate2
                    myglobal.DATE_REPORT3 = dtpDayadd1.Text; //@ddate3

                    myglobal.REPORT_NAME = "MicroInventoryMovementPrint";

                    frmReport fr = new frmReport();

                    fr.WindowState = FormWindowState.Maximized;
                    fr.Show();
                }
                else
                {
                    myglobal.DATE_REPORT = dtp1.Text;
                    myglobal.DATE_REPORT2 = dtp2.Text;
                    myglobal.DATE_REPORT3 = dtpDayadd1.Text;

                    myglobal.REPORT_NAME = "MacroInventoryMovementPrint";

                    frmReport fr = new frmReport();

                    fr.WindowState = FormWindowState.Maximized;
                    fr.Show();
                }



            }
            else
            {

                return;
            }




        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
           dtpDayadd1.Value = dtp2.Value.AddDays(1);
        }

        private void frmRawMatsTheoMovementReports_Load(object sender, EventArgs e)
        {
            dtp1.Text = "1/10/2021 10:47 AM";
            dtpDayadd1.Value = dtp2.Value.AddDays(1);
        }
    }
}

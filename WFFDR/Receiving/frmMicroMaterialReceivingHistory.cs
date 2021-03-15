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
    public partial class frmMicroMaterialReceivingHistory : Form
    {
        public frmMicroMaterialReceivingHistory()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dateTimePicker3.Text;
            myglobal.DATE_REPORT2 = dtp3.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "MicroMaterialHistoryTracking";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dateTimePicker1.Text;
            myglobal.DATE_REPORT2 = dateTimePicker2.Text;

            myglobal.REPORT_NAME = "MacroMaterialHistoryTracking";



            frmReport fr = new frmReport();
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void frmMicroMaterialReceivingHistory_Load(object sender, EventArgs e)
        {
            if (myglobal.rep_gen == "Micro")
            {
                groupBox3.Visible = true;
                groupBox1.Visible = false;
            }
            else if (myglobal.rep_gen == "Macros")
            {
                groupBox1.Visible = true;
                groupBox3.Visible = false;
            }

            else
            {
                groupBox1.Visible = true;
                groupBox3.Visible = false;
            }

            }
    }
}

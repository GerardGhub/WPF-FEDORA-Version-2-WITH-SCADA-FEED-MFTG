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
    public partial class frmFgReportPerFeedCode : Form
    {
        frmFGMainInventory ths;
        public frmFgReportPerFeedCode(string feed_code, frmFGMainInventory frm)
        {
            InitializeComponent();
            this.feed_code = feed_code;
            ths = frm;

            textBox4.TextChanged += new EventHandler(textBox4_TextChanged);
            textBox4.Text = "";
        }
        public string feed_code { get; set; }
        private void frmFgReportPerFeedCode_Load(object sender, EventArgs e)
        {
            lblfcode.Text = feed_code;
            btnFeedCodeSearch.Visible = true;
            f1.MaxDate = DateTime.Now;
            f2.MaxDate = DateTime.Now;
        }

        private void btnFeedCodeSearch_Click(object sender, EventArgs e)
        {
            btnFeedCodeSearch.Visible = false;
            myglobal.DATE_REPORT = f1.Text;
            myglobal.DATE_REPORT2 = f2.Text;
            myglobal.DATE_REPORT3 = lblfcode.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGInventorySearchFeedCode";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

            this.Close();
            textBox4.Text = "232";

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ths.textBox40.Text = textBox4.Text;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void btnHIDE_Click(object sender, EventArgs e)
        {
            textBox4.Text = "DONE";
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmFgReportPerFeedCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox4.Text = "DONE";
        }
    }
}

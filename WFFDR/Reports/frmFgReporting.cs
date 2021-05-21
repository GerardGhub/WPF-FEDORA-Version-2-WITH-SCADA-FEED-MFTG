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
        frmFGMainInventory ths;
        public frmFgReporting(string prod1, string prod2, frmFGMainInventory frm)
        {
            InitializeComponent();
            //this.prod1 = prod1;
            //this.prod2 = prod2;

            ths = frm;

            textBox4.TextChanged += new EventHandler(textBox4_TextChanged);
            textBox4.Text = "";
        }
        public string prod1 { get; set; }
        public string prod2 { get; set; }

        private void frmFgReporting_Load(object sender, EventArgs e)
        {


            dtpprod1.Text = prod1;
            dtpprod2.Text = prod2;
            btnGenerate.Enabled = true;


            dtpprod1.MaxDate = DateTime.Now;
            dtpprod2.MaxDate = DateTime.Now;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            textBox4.Text = "sarap";
            myglobal.DATE_REPORT = dtpprod1.Text;
            myglobal.DATE_REPORT2 = dtpprod2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGInventory";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmFgReporting_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox4.Text = "DONE";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ths.textBox40.Text = textBox4.Text;
        }
    }
}

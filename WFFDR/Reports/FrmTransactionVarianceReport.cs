﻿using System;
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
    public partial class FrmTransactionVarianceReport : Form
    {
        public FrmTransactionVarianceReport()
        {
            InitializeComponent();
        }
        private void FrmTransactionVarianceReport_Load(object sender, EventArgs e)
        {
            dtpprod1.MaxDate = DateTime.Today;
            dtpprod2.MaxDate = DateTime.Today;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtpprod1.Text;
            myglobal.DATE_REPORT2 = dtpprod2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGTransactionVarianceReport";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

            this.Close();
        }
    }
}
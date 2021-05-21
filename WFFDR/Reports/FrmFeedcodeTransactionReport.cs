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
    public partial class FrmFeedcodeTransactionReport : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSet = new DataSet();
        
        public FrmFeedcodeTransactionReport()
        {
            InitializeComponent();
        }

        private void FrmFeedcodeTransactionReport_Load(object sender, EventArgs e)
        {

            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadFeedCode();
            f1.MaxDate = DateTime.Now;
            f2.MaxDate = DateTime.Now;
        }

      private  void loadFeedCode()
        {


            xClass.fillComboBoxFGMoveorder(Cbfeedcode, "feed_code_fg_moveorder", dSet);



        }

        private void btnFeedCodeSearch_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = f1.Text;
            myglobal.DATE_REPORT2 = f2.Text;
            myglobal.DATE_REPORT3 = Cbfeedcode.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGInventorySearchFeedCode";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

            this.Close();
        }
    }
}

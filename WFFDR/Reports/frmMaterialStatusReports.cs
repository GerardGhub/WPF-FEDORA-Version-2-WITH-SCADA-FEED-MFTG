using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WFFDR
{
    public partial class frmMaterialStatusReports : Form
    {

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;


        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds = new DataSet();

        int p_id = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        public frmMaterialStatusReports()
        {
            InitializeComponent();
        }

        private void frmSupplierEvaluation_Load(object sender, EventArgs e)
        {
     
            objStorProc = xClass.g_objStoredProc.GetCollections();
   
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Print the Fast Moving Raw Materials? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                myglobal.REPORT_NAME = "MaterialFastMoving";

                frmReport frmReport = new frmReport();

                frmReport.Show();
            }
            else
            {
                return;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Print the Slow Moving Raw Materials? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                myglobal.REPORT_NAME = "MaterialSlowMoving";

                frmReport frmReport = new frmReport();

                frmReport.Show();
            }
            else
            {
                return;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Print the Non Moving Raw Materials? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                myglobal.REPORT_NAME = "MaterialNonMoving";

                frmReport frmReport = new frmReport();

                frmReport.Show();
            }
            else
            {
                return;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Print the Movement of  Raw Materials? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                myglobal.REPORT_NAME = "MaterialMoving";

                frmReport frmReport = new frmReport();

                frmReport.Show();
            }
            else
            {
                return;
            }
        }
    }
}

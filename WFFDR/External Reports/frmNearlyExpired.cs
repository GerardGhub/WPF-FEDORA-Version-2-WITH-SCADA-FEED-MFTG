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
    public partial class frmNearlyExpired : Form
    {
        myclasses xClass = new myclasses();
        myglobal pointer_module = new myglobal();
        IStoredProcedures objStorProc = null;
        DataSet dsetHeader = new DataSet();
        DataSet dSet = new DataSet();
        DataSet dset_offense = new DataSet();

        string mode = "";
 


        Boolean ready = false;

        DataSet dSet_temp = new DataSet();

        public frmNearlyExpired()
        {
            InitializeComponent();
        }

        private void frmNearlyExpired_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_nearly_expired();
        }

        public void load_nearly_expired()
        {
            string mcolumns = "test,r_item_code,r_item_description,actual_count_good,r_item_category,uniquedate,r_expiry_date,r_supplier,r_quantity,transaction_type,r_receiving_by,DAYSEXPIRED";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_all, mcolumns, "nearly_expired");
            lblrecords3.Text = dgv_all.RowCount.ToString();

        }

        private void dgv_all_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);

        }

        private void btnReprint_Click(object sender, EventArgs e)
        {

            //myglobal.DATE_REPORT = txtorder.Text;
            myglobal.REPORT_NAME = "PrintNearlyExpired";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }
    }
}

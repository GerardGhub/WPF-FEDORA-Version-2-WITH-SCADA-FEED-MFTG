using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WFFDR
{
    public partial class frmFullDepreciationReceiving : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        int p_id = 0;
        public frmFullDepreciationReceiving()
        {
            InitializeComponent();
        }

        private void frmFullDepreciationReceiving_Load(object sender, EventArgs e)
        {
            ListofActiveFormulationFeedCode();
            objStorProc = xClass.g_objStoredProc.GetCollections();

            ActiveReceivingRawMaterials();
        }

        public void ListofActiveFormulationFeedCode()
        {

            string mcolumns = "r_item_id,received_id, r_item_category, r_item_code,r_supplier,r_item_description,actual_count_good,target_weight,last_receiving_id, time_stamp_out,uniquedate";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "fulldepreceiving");
            lbl1.Text = dgv_table.RowCount.ToString();
            lblrecord.Text = dgv_table.RowCount.ToString();
        }

        public void ActiveReceivingRawMaterials()
        {

            string mcolumns = "r_item_id,received_id, r_item_category, r_item_code,r_supplier,r_item_description,actual_count_good,production_id_last_used, days_to_expired,uniquedate";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvActiveMaterials, mcolumns, "ActiveReceivingMaterials");
            //lbl1.Text = dgv_table.RowCount.ToString();
            lblcountactive.Text = dgvActiveMaterials.RowCount.ToString();
            //lblrecord.Text = dgv_table.RowCount.ToString();
        }


        private void dgv_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_table_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvActiveMaterials_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
    }
}

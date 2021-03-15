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
    public partial class frmMonthlyInventoryMicro : Form
    {
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dSet = new DataSet();
        IStoredProcedures objStorProc = null;
        myclasses xClass = new myclasses();
        public frmMonthlyInventoryMicro()
        {
            InitializeComponent();
        }

        private void frmMonthlyInventoryMicro_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_micro();
        }


        public void load_micro()
        {


            string mcolumns = "test,item_code,item_description,item_group,RESERVED,ONHAND,MICRO_RECIPE_NOT";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "micro_inventory_monthly");
            lblrecord.Text = dgv_table.RowCount.ToString();


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

        private void btnShowData_Click(object sender, EventArgs e)
        {

            frmMicroPendingProd shower = new frmMicroPendingProd(this,lblitemcode.Text);
            shower.Show();


        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgv_table.CurrentRow != null)
            {
                if (dgv_table.CurrentRow.Cells["item_code"].Value != null)
                {
                    lblitemcode.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();
 
                }
            }


        }
    }
}

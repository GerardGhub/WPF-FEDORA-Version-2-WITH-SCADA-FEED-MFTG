using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR.Admin
{
    public partial class FrmRepackingAdjustment : Form
    {

        DataSet dset = new DataSet();
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        public myclasses classes = new myclasses();

        public FrmRepackingAdjustment()
        {
            InitializeComponent();
        }

        private void FrmRepackingAdjustment_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
           

        }

        private void Loadmicro()
        {
            string mcolumns = "test,order_no,feed_code,feed_type,sack_bin,qty,uom,binnumber,Pdate,Fdate,production,my_fgid,added_by";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvrawmats, mcolumns, "callmicro", cbrawmats.Text.ToString(), 0, "", "");
        }

        private void Loadmacro()
        {
            string mcolumns = "test,order_no,feed_code,feed_type,sack_bin,qty,uom,binnumber,Pdate,Fdate,production,my_fgid,added_by";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvrawmats, mcolumns, "callmacro", cbrawmats.Text.ToString(), 0, "", "");
        }


        private void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void HideAll()
        {

            grp1.Visible = false;
            grp2.Visible = false;
            grp3.Visible = false;


        }
        private void UNHideAll()
        {

            grp1.Visible = true;
            grp2.Visible = true;
            grp3.Visible = true;


        }

        private void cbrawmats_DropDownClosed(object sender, EventArgs e)
        {
            if (cbrawmats.Text == "MICRO")
            {
                UNHideAll();
                Loadmicro();
            }
            else if (cbrawmats.Text == "MACRO")
            {
                UNHideAll();
                Loadmacro();

            }
            else
            {
                HideAll();
            }
        }
    }
}

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
            lblstatus.Text = "firstshow";

        }

        private void Loadrepackreceived()
        {
            string mcolumns = "test,itemcode,itemdescription,ActualReceived,TotalRepack,Balance";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvrepackreceived, mcolumns, "repackreceived", txtitemcode.Text.ToString(), 0, "", "");
            lblrepackreceived.Text = dgvrawmats.Rows.Count.ToString();
        }

        private void Loadmicro()
        {
            string mcolumns = "test,item_code,item_description,ONHAND,RESERVED";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvrawmats, mcolumns, "callmicro", cbrawmats.Text.ToString(), 0, "", "");
            rawmatscount.Text = dgvrawmats.Rows.Count.ToString();
        }

        private void Loadmacro()
        {
            string mcolumns = "test,item_code,item_description,ONHAND,RESERVED";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvrawmats, mcolumns, "callmacro", cbrawmats.Text.ToString(), 0, "", "");
            rawmatscount.Text = dgvrawmats.Rows.Count.ToString();
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

            if (lblstatus.Text == "firstshow")
            {


                if (cbrawmats.Text == "MICRO")
                {

                    UNHideAll();
                    Loadmicro();
                    lblstatus.Text = "second";

                }
                else if (cbrawmats.Text == "MACRO")
                {
                    UNHideAll();
                    Loadmacro();
                    lblstatus.Text = "third";
                }
                else
                {

                    HideAll();
                    lblstatus.Text = "firstshow";
                    return;

                }

            }
            else
            { 
                if(lblstatus.Text=="second")
                { 

                if (dgvrawmats.Visible==true && cbrawmats.Text == "MICRO")

                {
                    return;

                }
                else if(dgvrawmats.Visible == true && cbrawmats.Text == "MACRO")
                {

                        UNHideAll();
                        Loadmacro();
                        lblstatus.Text = "third";
                        return;
                }

                else
                {
                        HideAll();
                        lblstatus.Text = "firstshow";
                        return;
                    }

            }

                if(lblstatus.Text=="third")
                {
                    if (dgvrawmats.Visible == true && cbrawmats.Text == "MACRO")

                    {
                        return;

                    }

                    else if(dgvrawmats.Visible == true && cbrawmats.Text == "MICRO")
                    {
                        UNHideAll();
                        Loadmicro();
                        lblstatus.Text = "second";
                        return;

                    }

                    else
                    {
                        HideAll();
                        lblstatus.Text = "firstshow";
                        return;
                    }

                }





            }
           
            

        }

        private void cbrawmats_Click(object sender, EventArgs e)
        {
            cbrawmats.SelectedIndex = -1;
        }

        private void dgvrawmats_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvrawmats.CurrentCell != null)
            {
                if (dgvrawmats.CurrentRow.Cells["item_code"].Value != null)
                {
                    txtitemcode.Text = dgvrawmats.CurrentRow.Cells["item_code"].Value.ToString();

                    Loadrepackreceived();
                }

            }
        }

        private void dgvrepackreceived_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

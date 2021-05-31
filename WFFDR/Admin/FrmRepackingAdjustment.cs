using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

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
            lblstatus.Visible = false;
          
        }


        public void Success()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully Update!";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        public void load_AdjustReceived()
        {

            xClass.fillComboBoxAdjustReceived(cbreceivedid, "AdjustReceived", txtitemcode.Text, "", "", dset);
            cbreceivedid.SelectedIndex = -1;

        }
        private void Loadrepack()
        {
            string mcolumns = "test,repack_id,rp_item_id,rp_item_code,rp_item_description,total_repack";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvrepack, mcolumns, "repackactive", lblitemid.Text.ToString(), 0, "", "");
            lblrepack.Text = dgvrepack.Rows.Count.ToString();
            lblrepack.Visible = true;
        }

        private void Loadrepackreceived()
        {
            string mcolumns = "test,ReceivedID,itemcode,itemdescription,ActualReceived,TotalRepack,Balance";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvrepackreceived, mcolumns, "repackreceived", txtitemcode.Text.ToString(), 0, "", "");
            lblrepackreceived.Text = dgvrepackreceived.Rows.Count.ToString();
            lblrepackreceived.Visible = true;
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
            grp4.Visible = false;

        }
        private void UNHideAll()
        {

            grp1.Visible = true;
            grp2.Visible = true;
            grp3.Visible = true;

            if (lblrepack.Text == "0")
            {
                grp4.Visible = false;
            }
            else
            {
                grp4.Visible = true;
            }



        }

        private void cbrawmats_DropDownClosed(object sender, EventArgs e)
        {

            if (lblstatus.Text == "firstshow")
            {


                if (cbrawmats.Text == "MICRO")
                {
                    lblitemid.Text = "0";
                    UNHideAll();
                    Loadmicro();
                    lblstatus.Text = "second";

                }
                else if (cbrawmats.Text == "MACRO")
                {
                    lblitemid.Text = "0";
                    UNHideAll();
                    Loadmacro();
                    lblstatus.Text = "third";
                }
                else
                {
                    lblitemid.Text = "0";
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
                        lblitemid.Text = "0";
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
                        lblitemid.Text = "0";
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
                    load_AdjustReceived();

                    if (lblrepackreceived.Text == "0")
                    {
                        lblitemid.Text = "0";
                        Loadrepack();
                       

                    }
                    else
                    {
                       
                     
                    }


                    if (lblrepack.Text == "0")
                    {
                        grp4.Visible = false;
                    }
                    else
                    {
                        grp4.Visible = true;
                    }

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

        private void dgvrepackreceived_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvrepackreceived.CurrentCell != null)
            {
                if (dgvrepackreceived.CurrentRow.Cells["ReceivedID"].Value != null)
                {



                    lblitemid.Text = dgvrepackreceived.CurrentRow.Cells["ReceivedID"].Value.ToString();
                        Loadrepack();

                    if (lblrepack.Text == "0")
                    {
                        grp4.Visible = false;
                    }
                    else
                    {
                        grp4.Visible = true;
                    }



                }

            }

        }

        private void dgvrepack_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvrepack.CurrentCell != null)
            {
                if (dgvrepack.CurrentRow.Cells["repack_id"].Value != null)
                {



                    repackid.Text = dgvrepack.CurrentRow.Cells["repack_id"].Value.ToString();

                    if (lblrepack.Text == "0")
                    {
                        grp4.Visible = false;
                    }
                    else
                    {
                        grp4.Visible = true;
                    }



                }

            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to update this '" + txtitemcode.Text + "' item code ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                dset.Clear();
                dset = objStorProc.sp_rdf_fg_feedcodetransaction(0, repackid.Text, cbreceivedid.Text, "", "", "", "", "", "", "", "", "", "updateactive");
                Success();
                Loadrepackreceived();
                load_AdjustReceived();
                Loadrepack();

            }
            else
            {
                return;

            }
        }

        private void txtitemcode_TextChanged(object sender, EventArgs e)
        {
            lblitemcode.Text = txtitemcode.Text;
        }
    }
}

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

namespace WFFDR
{
    public partial class frmBulkValueMgmt : Form
    {

 

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();




        DataSet dset_section = new DataSet();
        Boolean ready = false;
   

        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();

        public frmBulkValueMgmt()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //start
            dSet.Clear();


            dSet = objStorProc.rdf_sp_bulk_data(0, txtqty.Text.Trim(), txtremarks.Text.Trim(), txtdateadded.Text.Trim(), txtaddedby.Text.Trim(), "1", "qtyexist");



            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboFeedCode.Focus();
                QtyAlreadyExist();
                
                return;
            }
            else
            {
           
            }



            if (txtqty.Text.Trim() == string.Empty)
            {
                FillData();
               txtqty.Focus();
                return;
            }
            if (txtremarks.Text.Trim() == string.Empty)
            {
                FillData();
                txtremarks.Focus();
                return;
            }


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Insert a new Bulk Entry Quantity ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    dSet = objStorProc.rdf_sp_bulk_data(0, txtqty.Text.Trim(), txtremarks.Text.Trim(), txtdateadded.Text.Trim(), txtaddedby.Text.Trim(),"1","add");



                    dSet.Clear();

                    SuccessFullySave();
                frmBulkValueMgmt_Load(sender, e);


                }
                else
                {

                    return;
                }
            















        }

        public void SuccessFullySave()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "SuccessFully Save !";

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





        public void FillData()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Fill up the required Field";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        public void QtyAlreadyExist ()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Quantity Already Exists";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        private void frmBulkValueMgmt_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();

            txtdateadded.Text = (DateTime.Now.ToString("M/d/yyyy"));
            txtaddedby.Text = userinfo.emp_name.ToUpper();
            load_bulkentry();
            load_bulkentry_not_active();
            txtremarks.Text ="Standard Quantity";
            txtqty.Text = "";
        }

        public void load_bulkentry()
        {
            string mcolumns = "test,qty,remarks,added_by,date_added,";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvBulkData, mcolumns, "bulk_entry_qty_list");
         //   lblrecords.Text = dataGridView1.RowCount.ToString();

        }

        public void load_bulkentry_not_active()
        {
            string mcolumns = "test,qty,remarks,added_by,date_added,";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvInactive, mcolumns, "bulk_entry_qty_list_not_active");
            //   lblrecords.Text = dataGridView1.RowCount.ToString();

        }

        private void dgvBulkData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvBulkData_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgvBulkData.CurrentRow != null)
            {
                if (dgvBulkData.CurrentRow.Cells["id"].Value != null)
                {
                   lblidactive.Text = dgvBulkData.CurrentRow.Cells["id"].Value.ToString();


                }
            }












        }

        private void dgvBulkData_DoubleClick(object sender, EventArgs e)
        {


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Inactive Bulk Entry Quantity ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet = objStorProc.rdf_sp_bulk_data(0, lblidactive.Text.Trim(), txtremarks.Text.Trim(), txtdateadded.Text.Trim(), txtaddedby.Text.Trim(), "1", "inactive");



                dSet.Clear();
                frmBulkValueMgmt_Load(sender, e);

            }
            else
            {
                return;
            }

            }

        private void dgvInactive_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvInactive_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvInactive.CurrentRow != null)
            {
                if (dgvInactive.CurrentRow.Cells["id"].Value != null)
                {
                    lblactive.Text = dgvInactive.CurrentRow.Cells["id"].Value.ToString();


                }
            }

        }

        private void dgvInactive_DoubleClick(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Active Bulk Entry Quantity ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet = objStorProc.rdf_sp_bulk_data(0, lblactive.Text.Trim(), txtdateadded.Text.Trim(), txtdateadded.Text.Trim(), txtaddedby.Text.Trim(), "1", "active");



                dSet.Clear();
                frmBulkValueMgmt_Load(sender, e);

            }
            else
            {
                return;
            }
        }
    }
}

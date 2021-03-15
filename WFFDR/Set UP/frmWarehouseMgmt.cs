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
    public partial class frmWarehouseMgmt : Form
    {

        int i;

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();


        private const int BaudRate = 9600;

        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;

        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();

        public frmWarehouseMgmt()
        {
            InitializeComponent();
        }

        private void frmWarehouseMgmt_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_active_warehouse();
            textBox1.Text = "";
            btnNew.Visible = true;
            btnUpdate.Visible = true;
        }

        public void load_active_warehouse()
        {
            string mcolumns = "test,warehouse,account_title,addded_by,date_added";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "warehouse_view");
            lblrecords.Text = dgvApproved.RowCount.ToString();

        }

        private void dgvApproved_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Visible = false;
            btnUpdate.Visible = false;
            frmAddNewWarehouse mywipwh = new frmAddNewWarehouse(this, txtadd.Text, txtwarehouse.Text, txtaccounttitle.Text, txtaddedby.Text, txtdateadded.Text,txtid.Text);
            mywipwh.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            frmWarehouseMgmt_Load(sender, e);
        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvApproved.CurrentRow != null)
            {
                if (dgvApproved.CurrentRow.Cells["wh_id"].Value != null)
                {
                    txtid.Text = dgvApproved.CurrentRow.Cells["wh_id"].Value.ToString();

                    txtwarehouse.Text = dgvApproved.CurrentRow.Cells["warehouse"].Value.ToString();
                    txtaccounttitle.Text = dgvApproved.CurrentRow.Cells["account_title"].Value.ToString();
                  txtaddedby.Text = dgvApproved.CurrentRow.Cells["addded_by"].Value.ToString();
                    txtdateadded.Text = dgvApproved.CurrentRow.Cells["date_added"].Value.ToString();
                }
            }








        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            frmAddNewWarehouse mywipwh = new frmAddNewWarehouse(this,txtedit.Text,txtwarehouse.Text,txtaccounttitle.Text,txtaddedby.Text,txtdateadded.Text,txtid.Text);
            mywipwh.ShowDialog();
        }

        public void SuccessFullyDelete()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Deleted Successfully!";

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



        private void btnDelete_Click(object sender, EventArgs e)
        {



            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Delete the Warehouse Info ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet = objStorProc.rdf_sp_warehouse(0, txtwarehouse.Text.Trim(), txtaccounttitle.Text.Trim(), txtid.Text.Trim(), txtaddedby.Text.Trim(), "delete");



                dSet.Clear();
                textBox1.Text = "UpdateNA";
                SuccessFullyDelete();
                frmWarehouseMgmt_Load(sender, e);

            }
            else
            {

                return;
            }



        }
    }
}

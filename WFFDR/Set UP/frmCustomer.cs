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
    public partial class frmCustomer : Form
    {
        int rowindex;
        int i;
        string mode = ""; //mymode
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
        int sec;
        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;

        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            load_active_customer();
            btnNew.Visible = true;
            textBox1.Text = "";
            btnUpdate.Visible = true;
   dataGridView1_CurrentCellChanged(sender, e);
        }
        public void load_active_customer()
        {
            string mcolumns = "test,name,type,company,mobile,lead_man,address,added_by,date_addded";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataGridView1, mcolumns, "customer_view");
            lblrecords.Text = dataGridView1.RowCount.ToString();

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
            frmAddNewCustomer addingcustomer = new frmAddNewCustomer(this,txtadd.Text,txtname.Text,cboType.Text,cboCompany.Text,txtmobile.Text,txtleadman.Text,txtaddress.Text,txtaddedby.Text,txtdateadded.Text,txtid.Text);
                addingcustomer.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            frmCustomer_Load(sender, e);
        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (dgvApproved.CurrentRow != null)
            //{
            //    if (dgvApproved.CurrentRow.Cells["customer_id"].Value != null)
            //    {
            //        txtid.Text = dgvApproved.CurrentRow.Cells["customer_id"].Value.ToString();

            //        txtname.Text = dgvApproved.CurrentRow.Cells["name"].Value.ToString();
            //        cboType.Text = dgvApproved.CurrentRow.Cells["type"].Value.ToString();
            //        cboCompany.Text = dgvApproved.CurrentRow.Cells["company"].Value.ToString();
            //        txtmobile.Text = dgvApproved.CurrentRow.Cells["mobile"].Value.ToString();

            //        txtleadman.Text = dgvApproved.CurrentRow.Cells["lead_man"].Value.ToString();
            //      txtaddress.Text = dgvApproved.CurrentRow.Cells["address"].Value.ToString();
            //        txtaddedby.Text = dgvApproved.CurrentRow.Cells["added_by"].Value.ToString();
            //        txtdateadded.Text = dgvApproved.CurrentRow.Cells["date_added"].Value.ToString();
            //    }
            //}





        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            dataGridView1_CurrentCellChanged(sender, e);
            frmAddNewCustomer addingcustomer = new frmAddNewCustomer(this, txtedit.Text, txtname.Text, cboType.Text, cboCompany.Text, txtmobile.Text, txtleadman.Text, txtaddress.Text, txtaddedby.Text, txtdateadded.Text,txtid.Text);
            addingcustomer.Show();
        }

        public void SuccessFullyDeleted()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Deleted SuccessFully!";

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

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Delete the Customer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet = objStorProc.rdf_sp_customer(0, txtname.Text.Trim(), cboType.Text.Trim(), cboCompany.Text.Trim(), txtmobile.Text.Trim(), txtleadman.Text.Trim(), txtaddress.Text.Trim(), txtid.Text.Trim(), txtdateadded.Text.Trim(), "delete");



                dSet.Clear();
                textBox1.Text = "DeleteNA";
                SuccessFullyDeleted();

                frmCustomer_Load(sender, e);

            }
            else
            {

                return;
            }

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

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.CurrentRow.Cells["customer_id"].Value != null)
                {
                    txtid.Text = dataGridView1.CurrentRow.Cells["customer_id"].Value.ToString();

                    txtname.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                    cboType.Text = dataGridView1.CurrentRow.Cells["type"].Value.ToString();
                    cboCompany.Text = dataGridView1.CurrentRow.Cells["company"].Value.ToString();
                    txtmobile.Text = dataGridView1.CurrentRow.Cells["mobile"].Value.ToString();

                    txtleadman.Text = dataGridView1.CurrentRow.Cells["lead_man"].Value.ToString();
                    txtaddress.Text = dataGridView1.CurrentRow.Cells["address"].Value.ToString();
                    txtaddedby.Text = dataGridView1.CurrentRow.Cells["added_by"].Value.ToString();
                    txtdateadded.Text = dataGridView1.CurrentRow.Cells["date_added"].Value.ToString();
                }



            }
                //emd
            }
    }
}

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
using Tulpep.NotificationWindow;

namespace WFFDR
{
    public partial class frmMiscellaneoustransactionIssueIN : Form
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




        public frmMiscellaneoustransactionIssueIN()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMiscellaneoustransactionIssueIN_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();

            mfg_datePicker.Text = DateTime.Now.ToString("M/d/yyyy");
   dtpMfgDate.Text = DateTime.Now.ToString("M/d/yyyy");

            xpired.Text = DateTime.Now.ToString("M/d/yyyy");
            lbldateandtime.Text = DateTime.Now.ToString();

            xpired.MinDate = DateTime.Today;
            LoadItemCode();
            textBox1.Text = "";
            btnInsert.Visible = true;
            load_Materials();



            Initializer();

            this.BringToFront();
        }

        public void Initializer()
        {

            CallMaterialsDescription();

            dgvViewDescriptions_CurrentCellChanged(new object(), new System.EventArgs());

            if (lblrecords.Text == "0")
            {
                return;
            }

                if (lblsearhcountrawmats.Text == "0")
            {
                return;
               
              

            }
            else
            {
                lblsumstock.Text = (float.Parse(lbltotalqty.Text) + float.Parse(txtqty.Text)).ToString();

                lblsumrepack.Text = (float.Parse(lbltotalrepack.Text) + float.Parse(txtqty.Text)).ToString();

                lblsumserved.Text = (float.Parse(lbltotalreserve.Text) + float.Parse(txtqty.Text)).ToString();
            }


        }


        public void load_Materials()
        {
            string mcolumns = "test,item_code,item_description,category,supplier,qty,mfg_date,expiry_date,expiry_days";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "show_transaction_in");
            lblrecords.Text = dgvApproved.RowCount.ToString();

        }

        void LoadItemCode()
        {
            ready = false;
            mfg_datePicker.Enabled = false;
            txtdescription.Enabled = false;
            txtxp.Enabled = false;
            xClass.fillComboBoxWH(cboItemCode, "rdf_item_code_view", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;

        }


        private void xpired_ValueChanged(object sender, EventArgs e)
        {
         
        

            mfg_datePicker.Text = DateTime.Now.ToString("M/d/yyyy");
            expirationdays();
        }

        void CallMaterialsDescription()
        {

   
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);


                string sqlquery = "SELECT * FROM [dbo].[rdf_raw_materials] where is_active='1' and item_code='"+cboItemCode.Text+"'";



                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
               dgvViewDescriptions.DataSource = dt;
            lblsearhcountrawmats.Text = dgvViewDescriptions.RowCount.ToString();
      

        }

        void expirationdays()
        {
            xpired.MinDate = DateTime.Today;
            //autocomputer expired open start
            DateTime FirstDate = mfg_datePicker.Value;
            DateTime SecondDate = xpired.Value;


            // Difference in days, hours, and minutes.
            TimeSpan ts = SecondDate - FirstDate;

            // Difference in days.
            int differenceInDays = ts.Days;
            txtxp.Text = differenceInDays.ToString();
        }

        private void dgvViewDescriptions_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgvViewDescriptions.CurrentRow != null)
            {
                if (dgvViewDescriptions.CurrentRow.Cells["item_code"].Value != null)
                {
                   txtdescription.Text = dgvViewDescriptions.CurrentRow.Cells["item_description"].Value.ToString();

                  txtCategory.Text = dgvViewDescriptions.CurrentRow.Cells["Category"].Value.ToString();

                    lbltotalqty.Text = dgvViewDescriptions.CurrentRow.Cells["total_quantity_raw"].Value.ToString();
                    lbltotalrepack.Text = dgvViewDescriptions.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                    lbltotalreserve.Text = dgvViewDescriptions.CurrentRow.Cells["qty_production"].Value.ToString();





                }
            }


            //keepp
            


        }

        private void cboItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallMaterialsDescription();

            dgvViewDescriptions_CurrentCellChanged(sender, e);
        }

        private void mfg_datePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void txtorder_TextChanged(object sender, EventArgs e)
        {

        }
        public void RequiredFiel()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Field up the required !";

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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtothedescription.Text.Trim()== string.Empty)
            {
                RequiredFiel();
                txtothedescription.Focus();
                return;
            }


            frmAddNewTransactionIn shower = new frmAddNewTransactionIn(this);
            shower.Show();

            btnInsert.Visible = false;

            return;



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            frmMiscellaneoustransactionIssueIN_Load(sender, e);
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

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgvApproved.RowCount > 0)
            {
                if (dgvApproved.CurrentRow != null)
                {
                    if (dgvApproved.CurrentRow.Cells["item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        cboItemCode.Text = dgvApproved.CurrentRow.Cells["item_code"].Value.ToString();
                       txtdescription.Text = dgvApproved.CurrentRow.Cells["item_description"].Value.ToString();
                       txtCategory.Text = dgvApproved.CurrentRow.Cells["category"].Value.ToString();

                        txtSupplier.Text = dgvApproved.CurrentRow.Cells["supplier"].Value.ToString();
                        txtqty.Text = dgvApproved.CurrentRow.Cells["qty"].Value.ToString();

                        lbldateandtime.Text = dgvApproved.CurrentRow.Cells["time_stamp"].Value.ToString();
                       dtpMfgDate.Text = dgvApproved.CurrentRow.Cells["mfg_date"].Value.ToString();
                        mfg_datePicker.Text = dgvApproved.CurrentRow.Cells["date_added"].Value.ToString();

                  txttransactcount.Text = dgvApproved.CurrentRow.Cells["transact_number"].Value.ToString();

                        xpired.Text = dgvApproved.CurrentRow.Cells["expiry_date"].Value.ToString();

                      lblprimarykey.Text = dgvApproved.CurrentRow.Cells["transact_id"].Value.ToString();

                        lblmaterialid.Text = dgvApproved.CurrentRow.Cells["material_id"].Value.ToString();

                        txtremarks.Text = dgvApproved.CurrentRow.Cells["remarks"].Value.ToString();
                        txtaddedby.Text = dgvApproved.CurrentRow.Cells["added_by"].Value.ToString();
                        expirationdays();



                    }

                }


                CallMaterialsDescription();

                dgvViewDescriptions_CurrentCellChanged(sender, e);

                if (lblsearhcountrawmats.Text == "0")
                {
                    return;
                }
                else
                {
                    lblsumstock.Text = (float.Parse(lbltotalqty.Text) + float.Parse(txtqty.Text)).ToString();

                    lblsumrepack.Text = (float.Parse(lbltotalrepack.Text) + float.Parse(txtqty.Text)).ToString();

                    lblsumserved.Text = (float.Parse(lbltotalreserve.Text) + float.Parse(txtqty.Text)).ToString();
                }



            }













        }

        public void SuccessCancel()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully Cancelled a new Transaction of Raw Material";

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





        public void SuccessSave()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully Saved a new Transaction of Raw Material";

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

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if(lblrecords.Text =="0")
            {
                return;
            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancelled the Transaction ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dSet.Clear();
                dSet = objStorProc.sp_transaction_in(0, lblprimarykey.Text.Trim(), txtdescription.Text, txtCategory.Text.Trim(), txtSupplier.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "","", "cancel");


                dSet.Clear();

                dSets = objStorProc.rdf_sp_new_micro_received(0, txttransactcount.Text.Trim(), txtCategory.Text.Trim(), cboItemCode.Text.Trim(), txtSupplier.Text.Trim(), txtdescription.Text.Trim(), txtremarks.Text.Trim(), txtqty.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), txtaddedby.Text.Trim(), txtxp.Text.Trim(), mfg_datePicker.Text.Trim(), txtqty.Text.Trim(), txtqty.Text.Trim(), "", "", "0", "", txtqty.Text.Trim(), mfg_datePicker.Text.Trim(), xpired.Text.Trim(), "", "", "", "", "", txtqty.Text.Trim(), "", "", "", "", "", "1", "", "", "", "", txttransactcount.Text.Trim(), txtremarks.Text.Trim(), "Miscellaneous Receipt", "cancelreceiving");

                SuccessCancel();
                frmMiscellaneoustransactionIssueIN_Load(sender, e); //after saved !
            }

            else
            {
                return;
            }


            }

        private void btnsavebyone_Click(object sender, EventArgs e)
        {
            dSet.Clear();
    
            dSets = objStorProc.rdf_sp_new_micro_received(0, lblmaterialid.Text.Trim(), txtCategory.Text.Trim(), cboItemCode.Text.Trim(), txtSupplier.Text.Trim(), txtdescription.Text.Trim(), "GOOD", txtqty.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), txtaddedby.Text.Trim(), txtxp.Text.Trim(), mfg_datePicker.Text.Trim(), txtqty.Text.Trim(), txtqty.Text.Trim(), "", "", "0", "", txtqty.Text.Trim(), mfg_datePicker.Text.Trim(), xpired.Text.Trim(), "", "", "", "", "", txtqty.Text.Trim(), "", "", "", "","", "1", "", "", "", "",txttransactcount.Text.Trim(),txtremarks.Text.Trim(), "Miscellaneous Receipt", "add");

            //Inventory
            dSet.Clear();
            dSet = objStorProc.sp_transaction_in(0, lblsumstock.Text.Trim(), lblsumrepack.Text, lblsumserved.Text.Trim(), cboItemCode.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "", "", "addstock");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnsavebyone_Click(sender, e);

            CallMaterialsDescription();

            dgvViewDescriptions_CurrentCellChanged(sender, e);

            if (lblsearhcountrawmats.Text == "0")
            {
                return;
            }
            else
            {
                lblsumstock.Text = (float.Parse(lbltotalqty.Text) + float.Parse(txtqty.Text)).ToString();

                lblsumrepack.Text = (float.Parse(lbltotalrepack.Text) + float.Parse(txtqty.Text)).ToString();

                lblsumserved.Text = (float.Parse(lbltotalreserve.Text) + float.Parse(txtqty.Text)).ToString();
            }


            if (dgvApproved.Rows.Count >= 1)
            {


                int i = dgvApproved.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvApproved.Rows.Count)
                    dgvApproved.CurrentCell = dgvApproved.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);
                else
                {
                    LastLine();

                    dSet.Clear();
                    dSet = objStorProc.sp_transaction_in(0, txttransactcount.Text.Trim(), txtdescription.Text, txtCategory.Text.Trim(), txtSupplier.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "", "", "cancelall");

                    SuccessSave();
                    //MessageBox.Show("Last muna nyan  haha");
                    frmMiscellaneoustransactionIssueIN_Load(sender, e);


                    return;
                }



               btnlessthan_Click_1(sender, e);


            }

        }


        public void LastLine()
        {

    

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);


                string sqlquery = "INSERT INTO [dbo].[rdf_transaction_in_progress] (item_code,item_description,category,supplier,qty,time_stamp,mfg_date,expiry_date,expiry_days,remarks,date_added,added_by,is_active,transact_number)SELECT item_code,item_description,category,supplier,qty,time_stamp,mfg_date,expiry_date,expiry_days,remarks,date_added,added_by,is_active,transact_number FROM [dbo].[rdf_transaction_in] where is_active='1' and transact_number='" + txttransactcount.Text + "'";



                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
              dgvFinal.DataSource = dt;



        


        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        public void RequiredField()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Field up the required Description";

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


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblrecords.Text == "0")
            {
                return;
            }
            if (txtothedescription.Text.Trim() == string.Empty)
            {
                RequiredField();
                txtothedescription.Focus();

                return;

            }

            frmMiscellaneoustransactionIssueIN_Load(sender, e);

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Save the Transaction ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                UpdateDescription();
                button1_Click(sender,  e);


            }
            else
            {
                return;
            }


            }

        private void btnlessthan_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender,e);
        }

        private void frmMiscellaneoustransactionIssueIN_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(lblrecords.Text=="0")
            {

            }
            else
            {
                dSet.Clear();
                dSet = objStorProc.sp_transaction_in(0, lblprimarykey.Text.Trim(), txtdescription.Text, txtCategory.Text.Trim(), txtSupplier.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "", "", "cancelallclosed");

            }

        }

        public void SuccessUpdate()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully Updated";

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

        public void UpdateDescription()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_transaction_in] SET descripto='" + txtothedescription.Text + "' where transact_number='" + txttransactcount.Text + "'";



            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvViewDescriptions.DataSource = dt;




        }


        private void txtothedescription_DoubleClick(object sender, EventArgs e)
        {



            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Description ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                UpdateDescription();

                SuccessUpdate();
               frmMiscellaneoustransactionIssueIN_Load(sender, e);
            }
            else
            {
                return;
            }



        }
    }
}

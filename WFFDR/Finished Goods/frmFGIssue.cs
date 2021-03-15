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
    public partial class frmFGIssue : Form
    {
        myclasses xClass = new myclasses();
        DataSet dSet = new DataSet();
        DataSet dSets = new DataSet();
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        IStoredProcedures objStorProc = null;
        public frmFGIssue()
        {
            InitializeComponent();
        }

        private void frmFGIssue_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();


            txtaddedby.Text = userinfo.emp_name.ToUpper();

            loadFeedCode();
            DateTime dNow = DateTime.Now;
            mfg_datePicker.Text = (dNow.ToString("M/d/yyyy"));
            SelectMisCellaneousIndent();
            load_Schedules();

            if (lblrecords.Text == "0")
            {
                btnTransact.Visible = false;
            }
            else
            {
                btnTransact.Visible = true;
            }
        }
        public void load_Schedules()
        {
            string mcolumns = "prod_adv,fg_feed_code,fg_feed_type,fg_bags,fg_batch,fg_options,actual_weight,fg_proddate";
            pointer_module.populateModule(dsetHeader, dgvFG, mcolumns, "isForFGholloReceiptISSUE");
            lblrecords.Text = dgvFG.RowCount.ToString();
        }

        public void SelectMisCellaneousIndent()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);
            string sqlquery = "select DISTINCT prod_adv from [dbo].[rdf_fg_hollow_receipt] WHERE transaction_type='ISSUE'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvCountISSUE.DataSource = dt;
            txtorderno.Text = dgvCountISSUE.RowCount.ToString();
            txtorderno.Text = (float.Parse(txtorderno.Text) + 1).ToString();
            sql_con.Close();

        }
        void loadFeedCode()
        {


            xClass.fillComboBoxFGReceipt(cboFeedCode, "feed_code_fg_issue", dSet);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cboFeedCode.Enabled = true;
            btnInsert.Visible = false;
            btnsave.Visible = true;
            btnCancel.Visible = true;
            cboOptions.Text = "";
            cboFeedCode.Text = "";
            txtFeedType.Text = "";
            txtbags.Text = "";
            cboOptions.Text = "";
            txtremarks.Enabled = true;
            txtbags.Enabled = true;
        }

        void EmptyFieldNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Fill up the required Fields !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }




        void NotEnoughtInventory()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Not Enought Inventory !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void InvalidQuantity()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Invalid Quantity !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        public void SuccessFullyInsert()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully insert a new Finished Goods Receipt " + cboOptions.Text + "";

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

            txtremarks.Text = "";
        }


        public void SuccessFullyCancel()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully cancelled a  Finished Goods Receipt " + cboOptions.Text + "";

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
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtbags.Text.Trim() == string.Empty)
            {

            }
            else
            {
                double Bags;
                double Available;

                Bags = double.Parse(txtbags.Text);
                Available = double.Parse(txtavailable.Text);
                if (Bags > Available)
                {
                    txtbags.Text = "";
                    NotEnoughtInventory();

                    return;
                }
                else
                {
                    //MessageBox.Show("b");
                    //return;
                }
            }

            if (cboFeedCode.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                cboFeedCode.Focus();
                return;
            }

            if (cboOptions.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                cboOptions.Focus();
                return;
            }


            if (txtFeedType.Text.Trim() == string.Empty)
            {

                EmptyFieldNotify();
                txtFeedType.Focus();
                return;
            }

            if (txtbags.Text.Trim() == string.Empty)
            {

                EmptyFieldNotify();
                txtbags.Focus();
                return;
            }

            if (txtbacthno.Text.Contains("."))
            {

                InvalidQuantity();
                txtbags.Text = "";
                txtbags.Focus();
                return;
            }
            if (txtremarks.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                txtremarks.Focus();
                return;
            }
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to save the Transaction " + txtaddedby.Text + "", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //Do something bad

                if (cboOptions.Text == "BULK ENTRY")
                {
                    dSet.Clear();

                    dSets = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text.Trim(), cboFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtbags.Text.Trim(), txtbacthno.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), "NO BARCODE", txtbags.Text.Trim(), txtorderno.Text.Trim(), txtbacthno.Text.Trim(), txtbags.Text.Trim(), cboOptions.Text.Trim(), "Good", mfg_datePicker.Text.Trim(), "0", "addbulk_issue_hollow");
                    txtremarks.Enabled = false;
                    txtbags.Enabled = false;

                    btnsave.Visible = false;
                    btnInsert.Visible = true;
                    SuccessFullyInsert();
                    txtbags.Text = "";
                    frmFGIssue_Load(sender, e);
                }
                else
                {

                    dSet.Clear();

                    dSets = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text.Trim(), cboFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtbags.Text.Trim(), txtbacthno.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), "NO BARCODE", txtbags.Text.Trim(), txtorderno.Text.Trim(), txtbacthno.Text.Trim(), txtbags.Text.Trim(), cboOptions.Text.Trim(), "Good", mfg_datePicker.Text.Trim(), "0", "addbulk_issue_hollow");

                    btnsave.Visible = false;
                    btnInsert.Visible = true;
                    SuccessFullyInsert();
                    txtbags.Text = "";

                    frmFGIssue_Load(sender, e);
                }


            }
            else
            {
                return;
            }
            //

        }
        public void QueryStraightForwardFeedCode()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);
            string sqlquery = "select * from [dbo].[rdf_recipe] WHERE feed_code = '" + cboFeedCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView2.DataSource = dt;

            sql_con.Close();

        }
        private void cboFeedCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            QueryStraightForwardFeedCode();
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                if (dataGridView2.CurrentRow != null)
                {
                    if (dataGridView2.CurrentRow.Cells["feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);
                        txtFeedType.Text = dataGridView2.CurrentRow.Cells["rp_feed_type"].Value.ToString();

                    }

                }


            }
        }

        void cleartext()
        {
            cboFeedCode.Text = string.Empty;
            txtFeedType.Text = string.Empty;
            cboOptions.Text = string.Empty;
            txtremarks.Text = string.Empty;
          
            txtbags.Text = string.Empty;
            txtbacthno.Text = string.Empty;
            txttimes50.Text = string.Empty;
            txtaddedby.Text = string.Empty;
            txtavailable.Text = string.Empty;





        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnInsert.Visible = true;
            btnsave.Visible = false;
            cboFeedCode.Enabled = false;
            btnCancel.Visible = false;
            cleartext();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (lblrecords.Text == "0")
            {
                return;
            }
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Cancelled the Transaction " + txtaddedby.Text + "", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet.Clear();

                dSets = objStorProc.rdf_sp_new_finish_goods(0, txtid.Text.Trim(), cboFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtbags.Text.Trim(), txtbacthno.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), "NO BARCODE", txtbags.Text.Trim(), txtorderno.Text.Trim(), txtbacthno.Text.Trim(), txtbags.Text.Trim(), cboOptions.Text.Trim(), "Good", mfg_datePicker.Text.Trim(), "0", "addbulk_issue_hollow_cancel_one");
                SuccessFullyCancel();
                frmFGIssue_Load(sender, e);
            }
            else
            {
                return;
            }
        }
        public void SuccessFullyTransactAllitems()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully Transactions of  Finished Goods Issue " + cboOptions.Text + "";

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
        private void btnTransact_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to save all the Transaction " + txtaddedby.Text + "", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                dSet.Clear();

                dSets = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text.Trim(), cboFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtbags.Text.Trim(), txtbacthno.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), "NO BARCODE", txtbags.Text.Trim(), txtorderno.Text.Trim(), txtbacthno.Text.Trim(), txtbags.Text.Trim(), cboOptions.Text.Trim(), "Good", mfg_datePicker.Text.Trim(), "0", "addbulk_issue_hollow_all");
                SuccessFullyTransactAllitems();
                frmFGIssue_Load(sender, e);
            }
            else
            {
                return;
            }
        }

        private void dgvFG_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvFG.RowCount > 0)
            {
                if (dgvFG.CurrentRow != null)
                {
                    if (dgvFG.CurrentRow.Cells["prod_adv"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);
                        txtorderno.Text = dgvFG.CurrentRow.Cells["prod_adv"].Value.ToString().ToUpper();
                        txtFeedType.Text = dgvFG.CurrentRow.Cells["fg_feed_type"].Value.ToString().ToUpper();
                        cboOptions.Text = dgvFG.CurrentRow.Cells["fg_options"].Value.ToString().ToUpper();
                        txttimes50.Text = dgvFG.CurrentRow.Cells["actual_weight"].Value.ToString().ToUpper();
                        cboFeedCode.Text = dgvFG.CurrentRow.Cells["fg_feed_code"].Value.ToString().ToUpper();
                        txtbags.Text = dgvFG.CurrentRow.Cells["fg_bags"].Value.ToString().ToUpper();
                        mfg_datePicker.Text = dgvFG.CurrentRow.Cells["fg_proddate"].Value.ToString().ToUpper();
                        txtid.Text = dgvFG.CurrentRow.Cells["fg_id"].Value.ToString();
                    }

                }
            }


        }

        private void dgvFG_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void txtbags_TextChanged(object sender, EventArgs e)
        {
            if (txtbags.Text.Trim() == string.Empty)
            {
                txttimes50.Text = "";
                txtbacthno.Text = "";
            }
            else
            {
                txttimes50.Text = (float.Parse(txtbags.Text) * 50).ToString();
                txtbacthno.Text = (float.Parse(txtbags.Text) / 40).ToString();
            }
        }

        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFeedCode_SelectedValueChanged(object sender, EventArgs e)
        {
  
            myglobal.global_module = "FGINVENTORY";
            load_search2(); //palit muna
            doSearch();


        }

        DataSet dset_emp = new DataSet();
        public void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "FGINVENTORY")
            { dset_emp = objStorProc.sp_getMajorTables("fg_inventory"); }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee_B"); }
            else if (myglobal.global_module == "PHONEBOOK")
            { dset_emp = objStorProc.sp_getMajorTables("phonebook"); }
            else if (myglobal.global_module == "DA")
            { dset_emp = objStorProc.sp_getMajorTables("get_da"); }
            else if (myglobal.global_module == "ATTENDANCE")
            { dset_emp = objStorProc.sp_getMajorTables("attendance_monitoring"); }
            else if (myglobal.global_module == "VISITORS")
            { dset_emp = objStorProc.sp_getMajorTables("visitors"); }


            doSearch();

        }



        public void load_search2()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "FGINVENTORY")
            { dset_emp = objStorProc.sp_getMajorTables("fg_inventory_overall"); }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee_B"); }
            else if (myglobal.global_module == "PHONEBOOK")
            { dset_emp = objStorProc.sp_getMajorTables("phonebook"); }
            else if (myglobal.global_module == "DA")
            { dset_emp = objStorProc.sp_getMajorTables("get_da"); }
            else if (myglobal.global_module == "ATTENDANCE")
            { dset_emp = objStorProc.sp_getMajorTables("attendance_monitoring"); }
            else if (myglobal.global_module == "VISITORS")
            { dset_emp = objStorProc.sp_getMajorTables("visitors"); }


            doSearch();

        }

        void doSearch()
        {

            try
            {
                if (dset_emp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "MICRO")
                    {

                        //dv.RowFilter = "item_description like '%" + txtsearchs.Text + "%' or item_code like '%" + txtsearchs.Text + "%'";
                    }
     
                    else if (myglobal.global_module == "FGINVENTORY")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "FeedCode like '%" + cboFeedCode.Text + "%'";
                    }


                    dgvFGInventory.DataSource = dv;
                    lblsasa.Text = dgvFGInventory.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtsearch.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtsearch.Focus();
                return;
            }

        }

        private void dgvFGInventory_CurrentCellChanged(object sender, EventArgs e)
        {
            CellChangedofInventory();
        }

        public void CellChangedofInventory()
        {
            if (dgvFGInventory.RowCount > 0)
            {
                if (dgvFGInventory.CurrentRow != null)
                {
                    if (dgvFGInventory.CurrentRow.Cells["INVENTORY"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        if (cboOptions.Text == "Bagging")
                        {
                            txtavailable.Text = dgvFGInventory.CurrentRow.Cells["BAG_INVENTORY"].Value.ToString().ToUpper();
                        }
                        else if (cboOptions.Text == "BULK ENTRY")
                        {
                            txtavailable.Text = dgvFGInventory.CurrentRow.Cells["BULK_INVENTORY"].Value.ToString().ToUpper();
                        }
                        else
                        {
                            txtavailable.Text = dgvFGInventory.CurrentRow.Cells["INVENTORY"].Value.ToString().ToUpper();
                        }
                    }

                }
            }


        }

        private void frmFGIssue_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingClearCache();
        }


        public void FormClosingClearCache()
        {

            dSet.Clear();

            dSets = objStorProc.rdf_sp_new_finish_goods(0, txtorderno.Text.Trim(), cboFeedCode.Text.Trim(), txtFeedType.Text.Trim(), txtbags.Text.Trim(), txtbacthno.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text.Trim(), mfg_datePicker.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), "NO BARCODE", txtbags.Text.Trim(), txtorderno.Text.Trim(), txtbacthno.Text.Trim(), txtbags.Text.Trim(), cboOptions.Text.Trim(), "Good", mfg_datePicker.Text.Trim(), "0", "addbulk_issue_hollow_clear");

        }

        private void cboOptions_SelectionChangeCommitted(object sender, EventArgs e)
        {

            myglobal.global_module = "FGINVENTORY";
            load_search2();
            doSearch();



        }

        private void cboOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void txtbags_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar)
    && !char.IsDigit(e.KeyChar)
    && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }
    }
}

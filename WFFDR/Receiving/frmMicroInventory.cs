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
    public partial class frmMicroInventory : Form
    {

        myclasses myClass = new myclasses();
        //IStoredProcedures g_objStoredProcCollection = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dSet = new DataSet();
        int p_id = 0;
        int temp_hid = 0;
        string mode = "";
        Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        public frmMicroInventory()
        {
            InitializeComponent();
        }

        private void frmQAwebsite_Load(object sender, EventArgs e)
        {
            txtDateAdded.Text = Convert.ToString(DateTime.Now);
            // Calling the Stored PROC 
            txtItemAddedBy.Text = userinfo.emp_name.ToUpper();
            objStorProc = xClass.g_objStoredProc.GetCollections();
            
            toolStrip.Visible = false;
            //this.WindowState = FormWindowState.Maximized;
    

            if(txtItemAddedBy.Text== "KABAYONG PROGRAMMER")
            {
                toolStripButton2.Visible = true;
            }
            else
            {
                toolStripButton2.Visible = false;
            }
            checkingGrandtotal();



            lblid.Text = userinfo.user_id.ToString();

            if (lblid.Text == "2")
            {
                toolStrip.Visible = true;
                toolStripButton2.Visible = true;
            }
            else
            {
                toolStrip.Visible = false;
                toolStripButton2.Visible = false;
            }

            bunifuStartImport_Click(sender, e);
            //InitialValueinDataGrid();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        void checkingGrandtotal()
        {


          //  for (int n = 0; n < (dgv_table.Rows.Count); n++)
          //  {
          //      //9

          //      double s1 = Convert.ToDouble(dgv_table.Rows[n].Cells[9].Value);

          //      double s2 = Convert.ToDouble(dgv_table.Rows[n].Cells[21].Value);
          //      double s7 = Convert.ToDouble(dgv_table.Rows[n].Cells[9].Value);
          //      //double s70 = Convert.ToDouble(dgvImport2.Rows[n].Cells[14].Value);
          //      //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
          //      //double s13 = s * 2;
          //      double s15 = s1 * s7;
          //      double s18 = s7 * 2;

          //      //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
          //      //dgvImport2.Rows[n].Cells[14].Value = s18.ToString();

          //      //dgvImport2.Rows[n].Cells[13].Value = s15.ToString();
          //      ////dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");

          //      double s180 = s1 * s2;

          //dgv_table.Rows[n].Cells[19].Value = s180.ToString();

          //  }




















            decimal tot = 0;

            for (int i = 0; i < dgv_table.RowCount - 0; i++)
            {
                var value = dgv_table.Rows[i].Cells["active_qty_repack"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

           lblgrandtotal.Text = tot.ToString("#,0.00");






        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.Text = e.Url.ToString() + "Is Loading .. .....";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuStartImport_Click(object sender, EventArgs e)
        {
            bunifuStartImport.Visible = false;
            load_micro();
            toolStrip.Visible = true;
            panel4.Visible = true;

            dgv_table.Visible = true;
  

            myglobal.global_module = "MICRO";

            lblactivemodule.Text = "MICRO";
            load_search();
            WelcomeUser();
        }
        void WelcomeUser()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Starting Micro Inventory ..";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
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

        public void load_micro()
        {

            if(lblid.Text =="2")
            { 


                string mcolumns = "test,item_code,item_description,item_group,buffer_of_stocks,price,MACRESERVED,MACREPACK,RECEIVING,ISSUE,OUTING,TOTAL_RECEIVED,RESERVED,ONHAND,LAST_USED,MOVEMENT,report,classification_buffer,ordering_buffer,QA_RECEIVING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
                pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "micro_raw_materialsnew");
                lblrecords.Text = dgv_table.RowCount.ToString();
                lbltotalrecords.Text = dgv_table.RowCount.ToString();


            }
            else
            {
                string mcolumns = "test,item_code,item_description,Category,item_group,RESERVED,ONHAND,buffer_of_stocks,price,REPACK,RECEIVING,OUTING,REPACK,ISSUE,LAST_USED,report,classification_buffer,ordering_buffer,QA_RECEIVING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
                pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "micro_raw_materialsnew");
                lblrecords.Text = dgv_table.RowCount.ToString();
                lbltotalrecords.Text = dgv_table.RowCount.ToString();
            }

        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            GroupBox1.Visible = true;
            label7.Visible = true;
            bunifuSearch.Visible = true;
            txtsearchs.Visible = true;
            txtsearchs.Focus();
        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            showValue();
        }

        void showValue()
        {
            try
            {



            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["item_id"].Value);
                        txtItemCode.Text = dgv_table.CurrentRow.Cells["item_code"].Value.ToString();
                        txtstock.Text = dgv_table.CurrentRow.Cells["total_quantity_raw"].Value.ToString();
                        txtDescription.Text = dgv_table.CurrentRow.Cells["item_description"].Value.ToString();
                        txtCategory.Text = dgv_table.CurrentRow.Cells["Category"].Value.ToString();
                        txtgroup.Text = dgv_table.CurrentRow.Cells["item_group"].Value.ToString();
                        txtqtyrepack.Text = dgv_table.CurrentRow.Cells["MACREPACK"].Value.ToString();
                        txtrepackavailable.Text = dgv_table.CurrentRow.Cells["ONHAND"].Value.ToString();

                        txtPrice.Text = dgv_table.CurrentRow.Cells["price"].Value.ToString();


                        txtBufferStocks.Text = dgv_table.CurrentRow.Cells["buffer_of_stocks"].Value.ToString();


                        cboABC.Text = dgv_table.CurrentRow.Cells["classification_buffer"].Value.ToString();

                        cboOrdering.Text = dgv_table.CurrentRow.Cells["ordering_buffer"].Value.ToString();
                            txtabc.Text = dgv_table.CurrentRow.Cells["classification_buffer"].Value.ToString();
                            txtordering.Text = dgv_table.CurrentRow.Cells["ordering_buffer"].Value.ToString();


                        }
                    }
            }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void txtsearchs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                

                doSearch();
            }
               
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        DataSet dset_emp = new DataSet();

        void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "MACRO")
            { dset_emp = objStorProc.sp_getMajorTables("macro_raw_materialsnew"); }
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
                        dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "MICRO")
                    {

                        dv.RowFilter = "item_description like '%" + txtsearchs.Text + "%' or item_code like '%" + txtsearchs.Text + "%'";
                    }
                    else if (myglobal.global_module == "HOME")
                    {

                        dv.RowFilter = "item_description like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "MACRO")
                    {

                        dv.RowFilter = "item_description like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "RESIGNED EMPLOYEE")
                    {
                        dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "PHONEBOOK")
                    {
                        dv.RowFilter = "company_name like '%" + txtsearch.Text + "%' or contact_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "DA")
                    {
                        dv.RowFilter = "employee_name like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or da_number like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "ATTENDANCE")
                    {
                        dv.RowFilter = "lastname like '%" + txtsearch.Text + "%' or firstname like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_table.DataSource = dv;
                    lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearch.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearch.Focus();
                return;
            }
        }
        void Clear()
        {
            txtItemCode.Text = "";
            txtstock.Text = "";
            txtDescription.Text = "";
            txtCategory.Text = "";
            txtgroup.Text = "";
            txtrepackavailable.Text = "";
            txtqtyrepack.Text = "";
        }
        void Enabled()
        {
            //txtItemCode.Enabled = true;

            //txtDescription.Enabled = true;
            //txtCategory.Enabled = true;
            //txtgroup.Enabled = true;

            txtBufferStocks.Enabled = true;
            txtPrice.Enabled = true;
        }
        void loadGroup()
        {
            ready = false;
            myClass.fillComboBox(txtgroup, "microgroup", dSet);
            ready = true;
        }
        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtgroup.Enabled = true;
            txtCategory.Text = "MICRO";
            Clear();
            loadGroup();
            Enabled();
            txtItemCode.Focus();
            dgv_table.Enabled = false;
            saveToolStripButton.Visible = true;
        }

        void ItemCodeNotExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIALS ITEM CODE ALREADY EXIST !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80); ;
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

        void EmptyFieldNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE REQUIRED FIELDS";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
   
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);


        }


        void ItemCodeExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "ITEM CODE EXIST !";
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



        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text, 0, txtDescription.Text, "", "", "", "", "", "", "", "", "", "",txtBufferStocks.Text,"", "","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "add");

                    return true;
                }
            }
            else if (mode == "edit")
            {
              

                dSet.Clear();

                dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(),txtPrice.Text.Trim(),cboABC.Text.Trim(), cboOrdering.Text.Trim(), "getbyname");
                dSet_temp.Clear();



                dSet_temp = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(),txtPrice.Text.Trim(),cboABC.Text.Trim(), cboOrdering.Text.Trim(), "getbyid");
      
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        ///   dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");
                        dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(), txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "edit");


                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescription.Focus();
                        return false;
                    }


            }
                else
                {
                    dSet.Clear();
                    ///        dSet = dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");
                    dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(),txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "edit");

                    return true;
                }
            }
            else if (mode == "editinactive")
            {
                dSet.Clear();

                dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(),cboABC.Text.Trim(), cboOrdering.Text.Trim(), "getbyname");
                dSet_temp.Clear();

                dSet_temp = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(),cboABC.Text.Trim(), cboOrdering.Text.Trim(), "getbyid");
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        ///   dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");
                        dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(),txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "editinactive");

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescription.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(),  "editinactive");

                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_supplier(p_id, "", "", "", "", "delete");
                return true;
            }
            return false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to save the Data? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                dSet.Clear();
                //dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, txtbags.Text, "", "", "", "", "existsornot");
                dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text, 0, txtDescription.Text, "", "", "", "", "", "", "", "", "", "","","","","", "existsornot");

                if (dSet.Tables[0].Rows.Count > 0)
                {

                    ItemCodeNotExists();
                    return;

                }
                else
                {
;

                }






                mode = "add";
                if (txtDescription.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtDescription.Focus();
                    return;
                }

                if (txtgroup.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtgroup.Focus();
                    return;
                }

                if (txtCategory.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtCategory.Focus();
                    return;
                }


                if (txtItemCode.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtItemCode.Focus();
                    return;
                }
                else
                {
                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];

                            //MessageBox.Show("Raw Materials Addeds SuccesFully.", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AddedSuccess();
                            txtItemCode.Enabled = false;
                            txtDescription.Enabled = false;
                            txtgroup.Enabled = false;
                            txtCategory.Enabled = false;
                            txtBufferStocks.Enabled = false;
                            load_micro();
                            //Mainmenu.load_micro();
                            //Mainmenu.Refresh();
                            //this.Close();
                            dgv_table.Enabled = true;
                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }



                    }
                    else
                        MessageBox.Show("Failed");

                }
            }

            else
            {
                return;
            }

        }


        void AddedSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Raw Material Added Successfully!";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void AddedSuccessUpdate()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Raw Material updated Successfully!";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void AddedInactivedUpdate()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Raw Material Inactived Successfully!";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        void Disabled()
        {
            txtItemCode.Enabled = false;
            txtDescription.Enabled = false;
            txtCategory.Enabled = false;
            txtgroup.Enabled = false;
            txtBufferStocks.Enabled = false;
            txtPrice.Enabled = false;
            cboABC.Enabled = false;
            cboOrdering.Enabled = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            cboABC.Enabled = true;
            cboOrdering.Enabled = true;

            saveToolStripButton.Visible = false;
            Enabled();

            txtgroup.Enabled = false;
            txtabc.Visible = false;
            txtordering.Visible = false;
            cboABC.Visible = true;
            cboOrdering.Visible = true;


        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Disabled();
            dgv_table.Enabled = true;
            saveToolStripButton.Visible = false;
            cboABC.Visible = false;
            cboOrdering.Visible = false;
            txtabc.Visible = true;
            txtordering.Visible = true;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {

            metroButton1_Click(sender, e);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Update the Micro Raw Materials ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
            

                mode = "edit";
      
                if (txtDescription.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtDescription.Focus();
                    return;
                }

                if (txtgroup.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtgroup.Focus();
                    return;
                }

                if (txtCategory.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtCategory.Focus();
                    return;
                }


                if (txtItemCode.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtItemCode.Focus();
                    return;
                }

                else
                {
                    if (saveMode())
                    {

                        string tmode = mode;

                        if (tmode == "edit")
                        {
                      
                            AddedSuccessUpdate();
                            load_micro();
                            Disabled();
                            cboABC.Visible = false;
                            cboOrdering.Visible = false;
                            txtabc.Visible = true;
                            txtordering.Visible = true;


                            //MessageBox.Show("Supplier Update Successfully", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dgv_table.CurrentCell = dgv_table[0, temp_hid];
                        }

                        //   btnCancel_Click(sender, e);

                    }
                    else
                    {
                        //MessageBox.Show("Failedes");
                    }
                }

            }
            else
            {
                //bunifuUndo_Click(sender, e);
                Disabled();
                return;
            }
            checkingGrandtotal();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Update the Raw Materials as Inactive ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {


                mode = "editinactive";

                if (txtDescription.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtDescription.Focus();
                    return;
                }

                if (txtgroup.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtgroup.Focus();
                    return;
                }

                if (txtCategory.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtCategory.Focus();
                    return;
                }


                if (txtItemCode.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtItemCode.Focus();
                    return;
                }

                else
                {
                    if (saveMode())
                    {

                        string tmode = mode;

                        if (tmode == "editinactive")
                        {
                            AddedInactivedUpdate();
                            load_micro();
                            Disabled();

                            //MessageBox.Show("Supplier Update Successfully", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dgv_table.CurrentCell = dgv_table[0, temp_hid];
                        }

                        //   btnCancel_Click(sender, e);

                    }
                    else
                    {
                        //MessageBox.Show("Failedes");
                    }
                }

            }
            else
            {
                //bunifuUndo_Click(sender, e);
                Disabled();
                return;
            }
        }

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_repack_available"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n2");
                    }
                }
            }

            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("active_qty_repack"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n2");
                    }
                }
            }



            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("price"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n2");
                    }
                }
            }


            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_production"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n2");
                    }
                }
            }


            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("buffer_of_stocks"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n2");
                    }
                }
            }




            foreach (DataGridViewRow row in dgv_table.Rows)
            {
                if (Convert.ToDouble(row.Cells["buffer_of_stocks"].Value) > Convert.ToDouble(row.Cells["RESERVED"].Value))
                {
                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
                    row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
                }
                else if (Convert.ToDouble(row.Cells["buffer_of_stocks"].Value) < Convert.ToDouble(row.Cells["RESERVED"].Value))
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
                }
     
            }



            //2 data fast slow now
            //foreach (DataGridViewRow row in dgv_table.Rows)
            //{
            //    if (1 == Convert.ToDouble(row.Cells["MOVEMENT"].Value))
            //    {
            //        //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
            //        row.Cells["report"].Style.BackColor = Color.Green;
            //    }
            //    else if (200 < Convert.ToDouble(row.Cells["MOVEMENT"].Value))
            //    {
            //        row.Cells["report"].Style.BackColor = Color.Red;

            //    }
            //    else if (5 > Convert.ToDouble(row.Cells["MOVEMENT"].Value))
            //    {
            //        // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row
            //        row.Cells["report"].Style.BackColor = Color.Yellow;
            //    }
            //}
            foreach (DataGridViewRow row in dgv_table.Rows)
            {
                if (1 == Convert.ToDouble(row.Cells["MOVEMENT"].Value) || 0 == Convert.ToDouble(row.Cells["MOVEMENT"].Value))
                {
                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
                    row.Cells["report"].Style.BackColor = Color.Green;
                }
                else if (2 == Convert.ToDouble(row.Cells["MOVEMENT"].Value) || 3 == Convert.ToDouble(row.Cells["MOVEMENT"].Value) || 4 == Convert.ToDouble(row.Cells["MOVEMENT"].Value) || 5 == Convert.ToDouble(row.Cells["MOVEMENT"].Value))
                {
                    row.Cells["report"].Style.BackColor = Color.Yellow;

                }
                else
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row
                    row.Cells["report"].Style.BackColor = Color.Red;
                }
            }


            //gerard singian lastcard








        }

        public void InitialValueinDataGrid()
        {

            //2 data fast slow now
            foreach (DataGridViewRow row in dgv_table.Rows)
            {
                if (1 == Convert.ToDouble(row.Cells["MOVEMENT"].Value))
                {
                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
                    row.Cells["MOVEMENT"].Style.BackColor = Color.Green;
                }
                else if (200 < Convert.ToDouble(row.Cells["MOVEMENT"].Value))
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row
                    row.Cells["MOVEMENT"].Style.BackColor = Color.Red;
                    //row.Cells["SCADA"].Value ="sss".ToString();

                    //row.Cells["MACREPACK"].Value = "1241";

                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
                }
                else if (5 > Convert.ToDouble(row.Cells["MOVEMENT"].Value))
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row
                    row.Cells["MOVEMENT"].Style.BackColor = Color.Yellow;
                }
            }

        }

        void Refresher()
        {

            //reove muna 9/10/2020
            for (int n = 1; n < (dgv_table.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);
                //double tak = 2;
                string s1 = Convert.ToString(dgv_table.Rows[n].Cells["MOVEMENT"].Value);
                string s2 = Convert.ToString(dgv_table.Rows[n].Cells["MOVEMENT"].Value);
                //DateTime b = DateTime.Parse(lbldatenow.Text);
                //double s7 = Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);
                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                //double s15 = s1 * 2;
                //double s18 = s7 * s15;
                //////////double sample = 4 + 4;
                //takla
                //dataGridView1.Rows[n].Cells[1].Value = s15.ToString();
                //TimeSpan t = s1 - b;
                //double NrOfDays = t.TotalDays;
                //28
                if (s1 == s2)
                {
                    dgv_table.Rows[n].Cells["MOVEMENT"].Value = "ONTIME";
                    dgv_table.Rows[n].Cells["MOVEMENT"].Style.BackColor = Color.CornflowerBlue;
                }
                else
                {
                    dgv_table.Rows[n].Cells["MOVEMENT"].Value = "DELAY";
                    dgv_table.Rows[n].Cells["MOVEMENT"].Style.BackColor = Color.Red;
                }
                //dgvProductionSchedules.Rows[n].Cells[25].Value = Convert.ToString(NrOfDays + " days");
                //label11.Text = Convert.ToString(NrOfDays + "day");
            }
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

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MicroInventorys";
       
            frmReport frmReport = new frmReport();
            //frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void btnShowInactivE_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to show the Inactive Raw Materials? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                frmInactiveRawmaterials Cute = new frmInactiveRawmaterials();
                Cute.ShowDialog();

            }

            else
            {
                return;
            }



            }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}

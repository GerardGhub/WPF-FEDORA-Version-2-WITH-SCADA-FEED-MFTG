using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmMacroInventory : Form
    {

        myclasses myClass = new myclasses();
        //IStoredProcedures g_objStoredProcCollection = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_rights = new DataSet();
        DataSet dSet = new DataSet();
        int p_id = 0;
        int temp_hid = 0;
        string mode = "";

        ReportDocument rpt = new ReportDocument();



        Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        int rights_id = 0;
        public frmMacroInventory()
        {
            InitializeComponent();
        }

        private void bunifuStartImport_Click(object sender, EventArgs e)
        {
            bunifuStartImport.Visible = false;
            load_macro();
            Disabled();
            toolStrip.Visible = true;
            panel4.Visible = true;
            dgv_table.Visible = true;



            myglobal.global_module = "MACRO";

            lblactivemodule.Text = "MACRO";
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
            popup.ContentText = "Starting Macro Inventory ...";
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


        public void load_macro()
        {

            if (lblid.Text == "2")
            {
                string mcolumns = "test,item_code,item_description,item_group,buffer_of_stocks,price,SCADA,MACRESERVED,MACREPACK,RECEIVING,ISSUE,OUTING,TOTAL_RECEIVED,RESERVED,ONHAND,LAST_USED,MOVEMENT,report,QA_RECEIVING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
                pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "macro_raw_materials");
                lblrecords.Text = dgv_table.RowCount.ToString();
                lbltotalrecords.Text = dgv_table.RowCount.ToString();
            }
            else
            {
                string mcolumns = "test,item_code,item_description,Category,item_group,RESERVED,ONHAND,buffer_of_stocks,price,REPACK,RECEIVING,SCADA,ISSUE,OUTING,LAST_USED,report,QA_RECEIVING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "macro_raw_materials");
            lblrecords.Text = dgv_table.RowCount.ToString();
            lbltotalrecords.Text = dgv_table.RowCount.ToString();
            }







        }

        private void bunifuSearch_Click(object sender, EventArgs e)
        {

        }

        private void frmMacroInventory_Load(object sender, EventArgs e)
        {
            txtDateAdded.Text = Convert.ToString(DateTime.Now);
            // Calling the Stored PROCEDURE
            txtItemAddedBy.Text = userinfo.emp_name.ToUpper();
            // Calling the Stored PROCEDURE
            objStorProc = xClass.g_objStoredProc.GetCollections();
            headers();
            lblid.Text = userinfo.user_id.ToString();
            rights_id = userinfo.user_rights_id;
            dset_rights.Clear();
            bunifuStartImport_Click(sender,e);
            checkingGrandtotal();

            txtabc.Enabled = false;
            txtordering.Enabled = false;

  

            if(lblid.Text =="2")
            {
                toolStrip.Visible = true;
                toolStripButton2.Visible = true;
                toolStripButtonNew.Visible = true;
            }
            else
            {
                toolStrip.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButtonNew.Visible = false;
            }
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



            //for (int n = 0; n < (dgv_table.Rows.Count); n++)
            //{
            //    //9

            //    double s1 = Convert.ToDouble(dgv_table.Rows[n].Cells[9].Value);

            //    double s2 = Convert.ToDouble(dgv_table.Rows[n].Cells[13].Value);
            //    double s7 = Convert.ToDouble(dgv_table.Rows[n].Cells[9].Value);

            //    //double s100 = Convert.ToDouble(dgv_table.Rows[n].Cells[18].Value);
            //    //22

             
            //    //    double s100 = Convert.ToDouble(dgv_table.Rows[n].Cells[22].Value);
              
            //    //    double s456 = s100 * 1;
            //    //dgv_table.Rows[n].Cells[18].Value = s456.ToString();
                

            //    //double s13 = s * 2;
            //    double s15 = s1 * s7;
            //    double s18 = s7 * 2;


            //    double s180 = s2 * s1;

               
            //    dgv_table.Rows[n].Cells[7].Value = s180.ToString();
        
            //}









            ////decimal tot = 0;

            ////for (int i = 0; i < dgv_table.RowCount - 0; i++)
            ////{
            ////    var value = dgv_table.Rows[i].Cells["classification"].Value;
            ////    if (value != DBNull.Value)
            ////    {
            ////        tot += Convert.ToDecimal(value);
            ////    }
            ////}
            ////if (tot == 0)
            ////{

            ////}

            ////lblgrandtotal.Text = tot.ToString("#,0.00");





            /////


            //decimal toti = 0;

            //for (int i2 = 0; i2 < dgv_table.RowCount - 0; i2++)
            //{
            //    var values = dgv_table.Rows[i2].Cells[22].Value;
            //    if (values != DBNull.Value)
            //    {
            //        toti += Convert.ToDecimal(values);
            //    }
            //}
            //if (toti == 0)
            //{

            //}

            //lbljaja.Text = toti.ToString("#,0.00");
        }

        void headers()
        {

            if (rights_id == 1 || rights_id == 2 || rights_id == 5)
            {
                if (rights_id == 2)
                {
                    this.dgv_table.Columns["total_quantity_raw"].Visible = false;
                }
                else
                {
                    this.dgv_table.Columns["total_quantity_raw"].Visible = false;
                }
            }
         
        }
        void loadGroup()
        {
            //ready = false;
            //myClass.fillComboBox(txtgroup, "macrogroup", dSet);
            //ready = true;
        }
        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            showValue();
        }


        void showValue()
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
                        txtqtyrepack.Text = dgv_table.CurrentRow.Cells["qty_repack"].Value.ToString();
                        txtrepackavailable.Text = dgv_table.CurrentRow.Cells["ONHAND"].Value.ToString();


                        txtBufferStocks.Text = dgv_table.CurrentRow.Cells["buffer_of_stocks"].Value.ToString();
                        txtPrice.Text = dgv_table.CurrentRow.Cells["price"].Value.ToString();

                        txtabc.Text = dgv_table.CurrentRow.Cells["classification_buffer"].Value.ToString();
                        txtordering.Text = dgv_table.CurrentRow.Cells["ordering_buffer"].Value.ToString();




                    }
                }
            }

        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            bunifuSearch.Visible = true;
            txtsearchs.Visible = true;
        }

        private void txtsearchs_TextChanged(object sender, EventArgs e)
        {
            doSearch();
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
            { dset_emp = objStorProc.sp_getMajorTables("macro_raw_materials"); }
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
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "item_description like '%" + txtsearchs.Text + "%' or item_code like '%" + txtsearchs.Text + "%'";
                    }
                    else if (myglobal.global_module == "HOME")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "item_description like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "MACRO")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "item_description like '%" + txtsearchs.Text + "%' or item_code like '%" + txtsearchs.Text + "%'";
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
                            load_macro();
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


        void Disabled()
        {
            txtItemCode.Enabled = false;
            txtDescription.Enabled = false;
            txtCategory.Enabled = false;
            txtgroup.Enabled = false;
            txtBufferStocks.Enabled = false;
            txtPrice.Enabled = false;
        }

        void AddedSuccessUpdate()
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

        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text, 0, txtDescription.Text, "", "", "", "", "", "", "", "", "","", "","","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Raw Material is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(),txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "add");

                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();

                dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(),txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "getbyname");
                dSet_temp.Clear();

                dSet_temp = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "getbyid");
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "edit");

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
                    dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "edit");

                    return true;
                }
            }
            else if (mode == "editinactive")
            {
                dSet.Clear();

                dSet = objStorProc.rdf_sp_new_micro(0, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "getbyname");
                dSet_temp.Clear();

                dSet_temp = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(),txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "getbyid");
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        ///   dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");
                        dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "editinactive");

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
                    dSet = objStorProc.rdf_sp_new_micro(p_id, 0, txtItemCode.Text.Trim(), 0, txtDescription.Text.Trim(), "NULL", "NULL", txtDateAdded.Text.Trim(), "NULL", "BULLY", "deliver", txtItemAddedBy.Text.Trim(), "BULLty", txtgroup.Text.Trim(), txtCategory.Text.Trim(),txtBufferStocks.Text.Trim(), txtPrice.Text.Trim(), cboABC.Text.Trim(), cboOrdering.Text.Trim(), "editinactive");

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
                            load_macro();
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

        void EmptyFieldNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE REQUIRED FIELD";
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
        void ItemCodeNotExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIALS ITEM CODE ALREADY EXISTS !";
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Update the Raw Materials ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                            cboOrdering.Visible = false;
                            cboABC.Visible = false;
                            txtabc.Visible = true;
                            txtordering.Visible = true;



                            load_macro();
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
            checkingGrandtotal();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Enabledd();

            txtgroup.Enabled = false;
            txtCategory.Enabled = false;
            cboABC.Visible = true;
            cboABC.Enabled = true;
            cboOrdering.Enabled = true;
            cboOrdering.Visible = true;
            txtabc.Visible = false;
            txtordering.Visible = false;
        }

        void Clear()
        {
            txtItemCode.Text = "";
            txtstock.Text = "";
            txtDescription.Text = "";
         
            txtgroup.Text = "";
            txtrepackavailable.Text = "";
            txtqtyrepack.Text = "";
        }
        void Enabledd()
        {
            //txtItemCode.Enabled = true;
            txtBufferStocks.Enabled = true;
            //txtDescription.Enabled = true;
            //txtCategory.Enabled = true;
            //txtgroup.Enabled = true;
            txtPrice.Enabled = true;

        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtgroup.Enabled = true;
            Clear();
            loadGroup();
            //Enabled();
            txtItemCode.Enabled = true;
            txtDescription.Enabled = true;
            txtgroup.Enabled = true;
            txtCategory.Text = "MACRO";
            txtItemCode.Focus();
            dgv_table.Enabled = false;
            saveToolStripButton.Visible = true;
        }

        private void printPreviewToolStripButton_Click_1(object sender, EventArgs e)
        {
            GroupBox1.Visible = true;
            label7.Visible = true;
            bunifuSearch.Visible = true;
            txtsearchs.Visible = true;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);

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

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

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
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("SCADA"))
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

                    //if (Convert.ToInt32(row.Cells["buffer_of_stocks"].Value) > Convert.ToDouble(row.Cells["qty_production"].Value))
                    //{
                        //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
                        row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
                }
                else if (Convert.ToDouble(row.Cells["buffer_of_stocks"].Value) < Convert.ToDouble(row.Cells["RESERVED"].Value))
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightSalmon;
                }
            }



            foreach (DataGridViewRow row in dgv_table.Rows)
            {
                if (1 == Convert.ToDouble(row.Cells["MOVEMENT"].Value) || 0 == Convert.ToDouble(row.Cells["MOVEMENT"].Value))
                {
                    //row.Cells["buffer_of_stocks"].Style.BackColor = Color.LightGreen;
                    row.Cells["report"].Style.BackColor = Color.Green;
                }
                else if (2 == Convert.ToDouble(row.Cells["MOVEMENT"].Value) || 3 == Convert.ToDouble(row.Cells["MOVEMENT"].Value) || 4== Convert.ToDouble(row.Cells["MOVEMENT"].Value)|| 5== Convert.ToDouble(row.Cells["MOVEMENT"].Value))
                {
                    row.Cells["report"].Style.BackColor = Color.Yellow;

                }
                else 
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row
                    row.Cells["report"].Style.BackColor = Color.Red;
                }
            }






        }

        private void dgv_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblid_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "MacroInventorys";
           // rpt.Load(Rpt_Path + "\\MacroInventoryPrint.rpt");

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

        private void btnimport_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtBufferStocks_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

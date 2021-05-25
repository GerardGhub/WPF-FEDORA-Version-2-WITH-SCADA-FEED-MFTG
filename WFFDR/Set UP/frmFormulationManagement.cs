using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Tulpep.NotificationWindow;

namespace WFFDR
{
    public partial class frmFormulationManagement : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        int p_id = 0;
        DataSet dSet_temp = new DataSet();
        public frmFormulationManagement()
        {
            InitializeComponent();
        }

        private void frmFormulationManagement_Load(object sender, EventArgs e)
        {
            
            objStorProc = xClass.g_objStoredProc.GetCollections();

            //  ListofActiveFormulationFeedCode();

            LoadInactiveFormula();
            showInactiveFormula();
            lblactive.Text = "Active";
        
            myglobal.global_module = "Active";
            txtaddedby.Text = userinfo.emp_name.ToUpper();


            ActiveFormula();
            load_search();
            lbldatenow.Text = DateTime.Now.ToString("M/d/yyyy");
            lbldateminus1.Text = DateTime.Now.AddDays(-1).ToString("M/d/yyyy");

            lblcountprod.Text = "0";
        }

        public void LoadInactiveFormula()
        {
            string mcolumns = "rp_type,feed_code,rp_feed_type,Reason,inactive_by";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvInactive, mcolumns, "inactiveformulationmgmt");
            lbl2.Text = dgvInactive.RowCount.ToString();
        }


        public void ListofActiveFormulationFeedCode()
        {
          //  string mcolumns = "rp_type,fcode,ftype";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
          //  pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "activeformulationmgmtbea");
          //lbl1.Text = dgv_table.RowCount.ToString();
     
        
        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
            showActiveFormulation();

        }
        void showActiveFormulation()
        {
      

            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)               {
                    if (dgv_table.CurrentRow.Cells["FEEDCODE"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["recipe_id"].Value);

                        txtswine1.Text = dgv_table.CurrentRow.Cells["TYPE"].Value.ToString();

                     txtfeedcode1.Text = dgv_table.CurrentRow.Cells["FEEDCODE"].Value.ToString();
                        txtfeedtype1.Text = dgv_table.CurrentRow.Cells["FEEDTYPE"].Value.ToString();



                    }

                }
            }

        }


        void ActiveFormula()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT DISTINCT rp_type as TYPE, feed_code as FEEDCODE, rp_feed_type as FEEDTYPE,mixing_capacity FROM rdf_recipe WHERE is_active = 1";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table.DataSource = dt;

    
            sql_con.Close();
            lbl1.Text = dgv_table.RowCount.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_recipe] SET is_active='0'  WHERE feed_code = '" + txtfeedcode1.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table.DataSource = dt;

            ListofActiveFormulationFeedCode();
            LoadInactiveFormula();
            //cboFeedType_SelectedValueChanged(sender, e);
            //dgvImport.Refresh();
            sql_con.Close();
        }

        public void QueryActiveProdutionBeforeInactive()
        {
            string mcolumns = "test,order_no,FeedCode,Bags,Batch,Proddate,Status,ProdID";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvProduction, mcolumns, "QueryActiveProdutionBeforeInactive", txtfeedcode1.Text, 0, "", "");

       
            lblcountprod.Text = dgvProduction.RowCount.ToString();

        }
      
        //void QueryActiveProdutionBeforeInactive()
        //{


        //    String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


        //    SqlConnection sql_con = new SqlConnection(connetionString);


        //    String sqlquery = "SELECT emp.p_feed_code AS FeedCode,emp.bags_int AS Bags,emp.batch_int AS Batch,emp.proddate AS Proddate,emp.bagorbin AS Status,emp.prod_id AS ProdID FROM rdf_production_advance emp WHERE NOT emp.canceltheapprove IS NOT NULL AND emp.p_feed_code = '" + txtfeedcode1.Text + "' AND emp.end_macro_repacking IS NULL ORDER BY emp.prod_id ASC";

        //    //string sqlquery = "SELECT emp.p_feed_code AS FeedCode,emp.bags_int AS Bags,emp.batch_int AS Batch,emp.proddate AS Proddate,emp.bagorbin AS Status,emp.prod_id AS ProdID FROM rdf_production_advance emp WHERE NOT emp.canceltheapprove IS NOT NULL AND emp.p_feed_code='"+ txtfeedcode1.Text + "' AND emp.end_macro_repacking IS NULL AND NOT repacking_status='NULL'  ORDER BY emp.prod_id ASC";






        //    sql_con.Open();
        //    SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
        //    SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
        //    DataTable dt = new DataTable();
        //    sdr.Fill(dt);
        //    dgvProduction.DataSource = dt;
        //    lblcountprod.Text = dgvProduction.RowCount.ToString();

        //    sql_con.Close();


        //}


        void CheckMicroRepacking()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);




            string sqlquery = "SELECT emp.p_feed_code AS FeedCode,emp.bags_int AS Bags,emp.batch_int AS Batch,emp.proddate AS Proddate,emp.bagorbin AS Status,emp.prod_id AS ProdID FROM rdf_production_advance emp WHERE NOT emp.canceltheapprove IS NOT NULL AND emp.p_feed_code='" + txtfeedcode1.Text + "' AND emp.end_micro_repacking IS NULL AND NOT repacking_status='NULL'  ORDER BY emp.prod_id ASC";






            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvcheckmicro.DataSource = dt;
            lblcountprod.Text = dgvProduction.RowCount.ToString();

            sql_con.Close();


        }



        private void button2_Click(object sender, EventArgs e)
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_recipe] SET is_active='1'  WHERE feed_code = '" + txtfeedcode2.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvInactive.DataSource = dt;

            ListofActiveFormulationFeedCode();
            LoadInactiveFormula();

            sql_con.Close();
        }

        private void dgvInactive_CurrentCellChanged(object sender, EventArgs e)
        {
            showInactiveFormula();
        }
        void showInactiveFormula()
        {

            if (dgvInactive.RowCount > 0)
            {
                if (dgvInactive.CurrentRow != null)
                {
                    if (dgvInactive.CurrentRow.Cells["rp_type"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv_table.CurrentRow.Cells["recipe_id"].Value);

                        txttype2.Text = dgvInactive.CurrentRow.Cells["rp_type"].Value.ToString();

                        txtfeedcode2.Text = dgvInactive.CurrentRow.Cells["feed_code"].Value.ToString();
                        txtfeedtype2.Text = dgvInactive.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                        textBox6.Text = dgvInactive.CurrentRow.Cells["Reason"].Value.ToString();
                lblinactiveby.Text = dgvInactive.CurrentRow.Cells["inactive_by"].Value.ToString();
                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
            }
        }

        void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "Active")
            { dset_emp = objStorProc.sp_getMajorTables("activeFeedCodeversion2"); }
            else if (myglobal.global_module == "InActive")
            { dset_emp = objStorProc.sp_getMajorTables("InactiveFeedCode"); }
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


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            metroButton1_Click(sender,e);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender,e);
        }


  


        void activeNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Successfully Mark as active !";
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


        void InactiveNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Successfully Mark as Inactive !";
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

        void ReasonRequired()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Reason for Inactive is strictly required";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
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


        void SelectRequired()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Select Data in the DataGrid First";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
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


        void FreezeFormulationAtProd()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Warning cannot mark as Inactive the selected Feed Code, Finish the production first or cancel in the production plan!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
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





        void SubQuery()
        {

            if (lblcountprod.Text == "0")
            {
                btnrefresh.Visible = false;
                //MessageBox.Show("Wala");
                textBox4.Focus();
                //return;
            }
            else
            {
                FreezeFormulationAtProd();
                dgv_table.Visible = false;
                dgvProduction.Visible = true;
                lblcountprod.Visible = true;
                btnrefresh.Visible = true;
                label9.Text = "Active Prod. Schedule ";


                return;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark the Selected FeedCode As Inactive ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {


                QueryActiveProdutionBeforeInactive();
                //Macro 
                if (lblcountprod.Text == "0")
                {
                    btnrefresh.Visible = false;
                    //MessageBox.Show("Wala");
                    textBox4.Focus();
                    //return;
                }
                else
                {
                    FreezeFormulationAtProd();
                    dgv_table.Visible = false;
                    dgvProduction.Visible = true;
                    lblcountprod.Visible = true;
                    btnrefresh.Visible = true;
                    label9.Text = "Active Prod. Schedule ";


                    return;
                }

                CheckMicroRepacking();


                if (lblcountprod.Text == "0")
                {
                    btnrefresh.Visible = false;
                    //MessageBox.Show("Wala");
                    textBox4.Focus();
                    //return;
                }
                else
                {
                    FreezeFormulationAtProd();
                    dgv_table.Visible = false;
                    dgvProduction.Visible = true;
                    lblcountprod.Visible = true;
                    btnrefresh.Visible = true;
                    label9.Text = "Active Prod. Schedule ";


                    return;
                }
                //Micro

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);

                if(textBox4.Text.Trim() == string.Empty)
                {
                    ReasonRequired();
                    textBox4.Focus();
                    return;
                }


                string sqlquery = "UPDATE [dbo].[rdf_recipe] SET is_active='0',reason_for_inactive='"+textBox4.Text+"', inactive_by='"+txtaddedby.Text+"'  WHERE feed_code = '" + txtfeedcode1.Text + "'";

                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgv_table.DataSource = dt;


                lbldate.Text = DateTime.Now.ToString();
                //4 query is for insert the audit trail
                dSet = objStorProc.rdf_sp_new_preparation(0, txtfeedcode1.Text, txtaddedby.Text, "8.3.1 Formulation Management IN OUT", "Inactive A FeedCode", lbldate.Text, "", "", "", "", "", "", "", "", "", "", "", "", "addTrailLogs");



                textBox4.Text = "";

                //ListofActiveFormulationFeedCode();
                LoadInactiveFormula();
                //cboFeedType_SelectedValueChanged(sender, e);
                //dgvImport.Refresh();
                InactiveNotify();
                sql_con.Close();
               // MessageBox.Show("Cheesy");
                frmFormulationManagement_Load(sender, e);
            }
            else
            {

                return;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Mark the Selected FeedCode As Active ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

                SqlConnection sql_con = new SqlConnection(connetionString);



                string sqlquery = "UPDATE [dbo].[rdf_recipe] SET is_active='1'  WHERE feed_code = '" + txtfeedcode2.Text + "'";

                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvInactive.DataSource = dt;

                ActiveFormula();
              //  ListofActiveFormulationFeedCode();
                LoadInactiveFormula();
                //cboFeedType_SelectedValueChanged(sender, e);
                //dgvImport.Refresh();
                activeNotify();
                sql_con.Close();
                lbldate.Text = DateTime.Now.ToString();

                //4 query is for insert the audit trail
                dSet = objStorProc.rdf_sp_new_preparation(0, txtfeedcode2.Text, txtaddedby.Text, "8.3.1 Formulation Management IN OUT", "Mark as Active A FeedCode", lbldate.Text, "", "", "", "", "", "", "", "", "", "", "", "", "addTrailLogs");


                frmFormulationManagement_Load(sender,e);
            }
            else
            {

                return;
            }
        }

        private void txtmainsearch_TextChanged(object sender, EventArgs e)
        {

         //   doSearch();
            if (txtmainsearch.Text.Trim() == string.Empty)
            {
                ListofActiveFormulationFeedCode();
                ActiveFormula();
                lblrecords.Visible = false;
            }
            else
            {
                load_search();

                doSearch();
                lblrecords.Visible = true;
            }
            if(txtmainsearch.Text.Trim() == string.Empty)
            {
                frmFormulationManagement_Load(sender, e);
            }
        }
        DataSet dset_emp = new DataSet();
        private DataSet dSet;

        void doSearch()
        {
            try
            {
                if (dset_emp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "FEEDCODE like '%" + txtmainsearch.Text + "%' or FEEDTYPE like '%" + txtmainsearch.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_table.DataSource = dv;
                    lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainsearch.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainsearch.Focus();
                return;
            }
        }

        void doSearch2()
        {
            try
            {
                if (dset_emp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "feed_code like '%" + txtmainsearch2.Text + "%' or rp_feed_type like '%" + txtmainsearch2.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgvInactive.DataSource = dv;
                    lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainsearch.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainsearch.Focus();
                return;
            }
        }

        private void txtmainsearch2_TextChanged(object sender, EventArgs e)
        {
            doSearch2();
        }

        private void lblactive_Click(object sender, EventArgs e)
        {

        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Permanently Delete the selected Feed Code?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);



                string sqlquery = "DELETE [dbo].[rdf_recipe] WHERE feed_code = '" + txtfeedcode1.Text + "'";

                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgv_table.DataSource = dt;

                ListofActiveFormulationFeedCode();
                LoadInactiveFormula();
                //cboFeedType_SelectedValueChanged(sender, e);
                //dgvImport.Refresh();
                InactiveNotify();
                sql_con.Close();

                LoadInactiveFormula();
                lblactive.Text = "Active";

                myglobal.global_module = "Active";

                load_search();
            }
            else
            {

                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CheckMicroRepacking();


            if (lblcountprod.Text == "0")
            {
                btnrefresh.Visible = false;
                //MessageBox.Show("Wala");
                textBox4.Focus();
                //return;
            }
            else
            {
                FreezeFormulationAtProd();
                dgv_table.Visible = false;
                dgvProduction.Visible = true;
                lblcountprod.Visible = true;
                btnrefresh.Visible = true;
                label9.Text = "Active Prod. Schedule ";


                return;
            }





            metroButton3_Click(sender, e);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton214_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
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

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = "List of Active Formulation ";
            dgvProduction.Visible = false;
            dgv_table.Visible = true;
            lblcountprod.Visible = false;
            btnrefresh.Visible = false;



        }

        private void lblcountprod_Click(object sender, EventArgs e)
        {

        }

        private void dgvProduction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProduction_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void dgv_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showActiveFormulation();
        }

        private void lbl2_Click(object sender, EventArgs e)
        {

        }

        private void dgvProduction_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           if(txtfeedcode1.Text.Trim()==string.Empty)
            {
                SelectRequired();
                return;
            }

            if (textBox4.Text.Trim()==string.Empty)
            {
                ReasonRequired();
                textBox4.Focus();
                return;
            }

            metroButton1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);
        }
    }
    }

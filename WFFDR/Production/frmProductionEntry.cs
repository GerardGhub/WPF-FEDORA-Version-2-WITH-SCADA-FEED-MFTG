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

    public partial class txtremainingbatch : Form
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds = new DataSet();
        DataSet dSet_temp = new DataSet();

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSet2 = new DataSet();

        DataSet dSets = new DataSet();

        string mode = "";
        int p_id = 0;
        int temp_hid = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        //declare as global

        int nRow;

        public txtremainingbatch()
        {
            InitializeComponent();
        }

        private void frmProductionEntry_Load(object sender, EventArgs e)
        {
            
            load_Schedules();

            //nRow = dgv1stView.CurrentCell.RowIndex;4/18/2020
            DateTime dNow = DateTime.Now;
            txtdatenow.Text = (dNow.ToString("M/d/yyyy"));
            txtaddedby.Text = userinfo.emp_name.ToUpper();

            txtSolutions.Text = "";
            txtvariance.Text = "";
            txtSumofReserved.Text = "";
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            myglobal.global_module = "Active";
            load_search();
            if (lbltotalprod.Text == "0")
            {
                txtTheorotical.Enabled = false;
                lblstatus.Visible = false;
                lblmacro.Visible = false;
                    label6.Visible = false;
            }
            else
            {
                lblmacro.Visible = true;
                label6.Visible = true;
                timer2_Tick(sender, e);

                lblvalidateTheo.Text = "0";
                txtitemcodemacro1.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                txtquantitymacro1.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                txtitemcode1.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                txtquantity1.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                lblvalidatecount.Text = "0";
            }
            txtactualweight.Text = "";
            HideControlls();
            checkEntry();
            load_TheoMaterials();
            checkingofTheoMaterials();


            //txtMacro2.Visible = true;
            //txtMacro3.Visible = true;
            //txtMacro4.Visible = true;
            //txtMacro5.Visible = true;
            //txtMacro6.Visible = true;
        }

        void HideControlls()
        {
            txtTheorotical.Text = "";
            //txtTheorotical.Enabled = true;
            //txtTheorotical.Focus();

            txtTheorotical1.Enabled = true;
            txtTheorotical1.Text = "";
   

            txtTheorotical2.Visible = false;
            txtTheorotical2.Enabled = true;
            txtTheorotical2.Text = "";

            txtTheorotical3.Visible = false;
            txtTheorotical3.Enabled = true;
            txtTheorotical3.Text = "";

            txtTheorotical4.Visible = false;
            txtTheorotical4.Enabled = true;
            txtTheorotical4.Text = "";

            txtTheorotical5.Visible = false;
            txtTheorotical5.Enabled = true;
            txtTheorotical5.Text = "";

            txtTheorotical6.Visible = false;
            txtTheorotical6.Enabled = true;
            txtTheorotical6.Text = "";

            txtTheorotical7.Visible = false;
            txtTheorotical7.Enabled = true;
            txtTheorotical7.Text = "";


            txtTheorotical8.Visible = false;
            txtTheorotical8.Enabled = true;
            txtTheorotical8.Text = "";

            txtTheorotical9.Visible = false;
            txtTheorotical9.Enabled = true;
            txtTheorotical9.Text = "";

            txtTheorotical10.Visible = false;
            txtTheorotical10.Enabled = true;
            txtTheorotical10.Text = "";

            txtMacro.Visible = false;
            txtMacro.Enabled = true;
            txtMacro.Text = "";

            txtMacro.Visible = false;
            txtMacro.Enabled = true;
            txtMacro.Text = "";

            txtMacro1.Visible = false;
            txtMacro1.Enabled = true;
            txtMacro1.Text = "";


            txtMacro2.Visible = false;
            txtMacro2.Enabled = true;
            txtMacro2.Text = "";


            txtMacro3.Visible = false;
            txtMacro3.Enabled = true;
            txtMacro3.Text = "";


            txtMacro4.Visible = false;
            txtMacro4.Enabled = true;
            txtMacro4.Text = "";


            txtMacro5.Visible = false;
            txtMacro5.Enabled = true;
            txtMacro5.Text = "";


            txtMacro6.Visible = false;
            txtMacro6.Enabled = true;
            txtMacro6.Text = "";


            txtMacro7.Visible = false;
            txtMacro7.Enabled = true;
            txtMacro7.Text = "";


            txtMacro8.Visible = false;
            txtMacro8.Enabled = true;
            txtMacro8.Text = "";


            txtMacro9.Visible = false;
            txtMacro9.Enabled = true;
            txtMacro9.Text = "";


            txtMacro10.Visible = false;
            txtMacro10.Enabled = true;
            txtMacro10.Text = "";


            txtMacro11.Visible = false;
            txtMacro11.Enabled = true;
            txtMacro11.Text = "";

            txtMacro12.Visible = false;
            txtMacro12.Enabled = true;
            txtMacro12.Text = "";


            txtMacro13.Visible = false;
            txtMacro13.Enabled = true;
            txtMacro13.Text = "";

            txtMacro14.Visible = false;
            txtMacro14.Enabled = true;
            txtMacro14.Text = "";


            txtMacro15.Visible = false;
            txtMacro15.Enabled = true;
            txtMacro15.Text = "";

            txtactualweight.Text = "";
            txtactualweight.Visible = false;

            txtbmx.Text = "";
            txtbmx.Visible = false;
            txtbmx.Enabled = true;
        }


        void MyQueryforRefresh()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_production_advance]  WHERE prod_id = '" + txtprodid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
          dgvRemoveRefreshRate.DataSource = dt;
        }












        void checkingofTheoMaterials()
        {

            if (txtTheorotical.Text.Trim() == string.Empty)
            {
                txtTheorotical1.Enabled = false;
                if (lbltotalprod.Text == "0")
                {

                }
                else
                {
                    btnValidate1.Visible = true;
                }

            }


            else if (txtTheorotical2.Text.Trim() == string.Empty)
            {

                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical2.Visible = false;
                    btnValidate2.Visible = false;
           
                }


                if (txtTheorotical2.Text.Trim() == string.Empty)
                {
                    txtTheorotical2.Enabled = false;
                    btnValidate2.Visible = true;
                }
                else
                {
                    btnValidate2.Visible = false;
                }
            }
            else if (txtTheorotical3.Text.Trim() == string.Empty)
            {
                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical3.Visible = false;
                    btnValidate3.Visible = false;
       
                }
                txtTheorotical3.Visible = true;
                txtTheorotical3.Enabled = false;
                btnValidate3.Visible = true;

            }

            else if (txtTheorotical4.Text.Trim() == string.Empty)
            {

                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical4.Visible = false;
                    btnValidate4.Visible = false;

                }


                txtTheorotical4.Enabled = false;
                btnValidate4.Visible = true;

            }

            else if (txtTheorotical5.Text.Trim() == string.Empty)
            {
                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical5.Visible = false;
                    btnValidate5.Visible = false;
       
                }

                txtTheorotical5.Enabled = false;
                btnValidate5.Visible = true;

            }


            else if (txtTheorotical6.Text.Trim() == string.Empty)
            {

                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical6.Visible = false;
                    btnValidate6.Visible = false;
     
                }

                txtTheorotical6.Enabled = false;
                btnValidate6.Visible = true;

            }


            else if (txtTheorotical7.Text.Trim() == string.Empty)
            {

                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical7.Visible = false;
                    btnValidate7.Visible = false;
         
                }

                txtTheorotical7.Enabled = false;
                btnValidate7.Visible = true;

            }

            else if (txtTheorotical8.Text.Trim() == string.Empty)
            {

                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical8.Visible = false;
                    btnValidate8.Visible = false;
    
                }

                txtTheorotical8.Enabled = false;
                btnValidate8.Visible = true;

            }

            else if (txtTheorotical9.Text.Trim() == string.Empty)
            {
                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical9.Visible = false;
                    btnValidate9.Visible = false;
       
                }


                txtTheorotical9.Enabled = false;
                btnValidate9.Visible = true;

            }

            else if (txtTheorotical10.Text.Trim() == string.Empty)
            {
                if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
                {
                    txtTheorotical10.Visible = false;
                    btnValidate10.Visible = false;
            
                }


                txtTheorotical10.Enabled = false;
                btnValidate10.Visible = true;

            }




            else
            {
                btnValidate1.Visible = false;
                txtTheorotical1.Enabled = false;
                btnValidate2.Visible = false;
                btnValidate3.Visible = false;
                btnValidate4.Visible = false;
                btnValidate5.Visible = false;
                btnValidate6.Visible = false;
                btnValidate7.Visible = false;
                btnValidate8.Visible = false;
                btnValidate9.Visible = false;
                btnValidate10.Visible = false;
            }




    



        }



        void NoDataFound2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "No Data Found " + txtaddedby.Text + " ";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
            btngreaterthan.Visible = false;
            btnlessthan.Visible = false;
            ControlBox = false;
            lblscanthebarcode.Visible = false;

            lblTheoCounts.Visible = false;
            lblmacrovalidatecount.Visible = false;
            timer1_Tick(new object(), new System.EventArgs());
            ControlBox = true;
        }


        void FillRequiredField()
        {
            if (txtScanner.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
            }


            //    PopupNotifier popup = new PopupNotifier();
            //popup.Image = Properties.Resources.info;
            //popup.TitleText = "Fedora Notifications";
            //popup.ContentText = "Filled up the required Fields " + txtaddedby.Text + " ";
            //popup.Size = new Size(350, 100);
            //popup.ImageSize = new Size(70, 80);
            //popup.BodyColor = Color.Red;
            //popup.Popup();

            //popup.ContentColor = Color.White;
            //popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            //popup.TitleColor = Color.White;
            //popup.TitlePadding = new Padding(95, 7, 0, 0);
            ////popup.AnimationDuration = 1000;
            ////popup.ShowOptionsButton.ToString();
            //popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            //popup.Delay = 500;
            //popup.AnimationInterval = 10;
            //popup.AnimationDuration = 1000;


            //popup.ShowOptionsButton = true;

        }



        void checkEntry()
        {
            if(lbltotalprod.Text=="0")
            {
                txtTheorotical.Visible = false;
                txtTheorotical.Enabled = false;
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;

                dataView.Visible = false;
                lbltotalprod.Visible = false;
                label1.Visible = false;
                NoDataFound2();

                lblmain1.Visible = false;
                lblmain2.Visible = false;
                lblmain3.Visible = false;
                lblmain4.Visible = false;
                lblmain5.Visible = false;
                lblmain6.Visible = false;
                lblmain7.Visible = false;
                lblmain8.Visible = false;
                txtbatchremain.Visible = false;
                txtmainbatch.Visible = false;
                txtbatch.Text = "";
              
            }
            else
            {
                txtTheorotical.Select();
                txtTheorotical.Focus();
            }
        }
       void load_TheoMaterials()
        {

            dset_emp9.Clear();



     
            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");
            doSearch9();



        }
        DataSet dset_emp9 = new DataSet();
        void doSearch9()
        {
            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode0.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView7.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }

            
        }


        void load_search()
        {
            
            dset_emp.Clear();
            dset_emp8.Clear();


            dset_emp = objStorProc.sp_getMajorTables("Theorotical");
            dset_emp1 = objStorProc.sp_getMajorTables("Validate");
            dset_emp2 = objStorProc.sp_getMajorTables("Basemixed");
            dset_emp3 = objStorProc.sp_getMajorTables("BMXRepack");
            dset_emp4 = objStorProc.sp_getMajorTables("ProductionCount");
            dset_emp5 = objStorProc.sp_getMajorTables("repackingEntry");
                            dset_emp8 = objStorProc.sp_getMajorTables("repackingEntry");
            doSearch();
            doSearchValidate();
            doSearchBMX();
            doBMXRepack();
            doProdCount();
            doRepackingEntry();
            doRepackingEntry2();

        }
        DataSet dset_emp = new DataSet();
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

                        dv.RowFilter = "feed_code like '%" + txtmainfeedcode.Text + "%' AND production_id like '%" + txtproductionid.Text + "%' ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView1.DataSource = dv;
                    lblTheoCounts.Text = dataGridView1.RowCount.ToString();
                    //lblrecords.Text = dgv_table.RowCount.ToString();gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }

            for (int n = 0; n < (dataGridView1.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);

                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dataGridView1.Rows[n].Cells[3].Value = s15.ToString();


                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }
        }

        DataSet dset_emp1 = new DataSet();
        void doSearchValidate()
        {
            try
            {
                if (dset_emp1.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp1.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        //dv.RowFilter = "feed_code like '%" + txtmainfeedcode.Text + "%' AND production_id like '%" + txtproductionid.Text + "%'";
                        //gerard sira

                        dv.RowFilter = "feed_code = '" + txtmainfeedcode.Text + "' AND production_id = '" + txtproductionid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView2.DataSource = dv;

                    lblmacrovalidatecount.Text = dataGridView2.RowCount.ToString();
                    //lblrecords.Text = dgv_table.RowCount.ToString();gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }

            for (int n = 0; n < (dataGridView2.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dataGridView2.Rows[n].Cells[3].Value);

                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dataGridView2.Rows[n].Cells[3].Value = s15.ToString("#,0.00");


                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }



        }


        DataSet dset_emp2 = new DataSet();
        void doSearchBMX()
        {
            try
            {
                if (dset_emp2.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp2.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "bmx_feed_code like '%" + txtmainfeedcode.Text + "%' AND bmx_prepa_date like '%" + txtproductionid.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView3.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
        }


        DataSet dset_emp3 = new DataSet();
        void doBMXRepack()
        {
            try
            {
                if (dset_emp3.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp3.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "bmx_id_string = '" + txtbmx.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView4.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
        }


        DataSet dset_emp4 = new DataSet();
        void doProdCount()
        {
            try
            {
                if (dset_emp4.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp4.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "product_feed_code ='" + txtmainfeedcode.Text + "' AND prod_id ='"+ txtproductionid.Text + "'";
                        //dv.RowFilter = "product_feed_code like '%" + txtmainfeedcode.Text + "%' AND prod_id like '%" + txtproductionid.Text + "%'";
                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView5.DataSource = dv;
                    txtbatch.Text = dataGridView5.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
        }



        DataSet dset_emp5 = new DataSet();
        void doRepackingEntry()
        {
            try
            {
                if (dset_emp5.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp5.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "string_id = '" + txtMacroMatic.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView6.DataSource = dv;
                
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 200.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
        }





        DataSet dset_emp8 = new DataSet();
        void doRepackingEntry2()
        {
            try
            {
                if (dset_emp8.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp8.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "string_id = '" + txtScanner.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView8.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 200.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }
        }




        public void load_Schedules()
        {
            string mcolumns = "test,prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate,repacking_status,bagorbin";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "isForproduction");
            lbltotalprod.Text = dataView.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();

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



        void showValueDailyProduction()
        {

            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtmainfeedcode.Text = dataView.CurrentRow.Cells["p_feed_code"].Value.ToString().ToUpper();
                        txtproductionid.Text = dataView.CurrentRow.Cells["prod_id"].Value.ToString();
                        //txtmainbatch.Text = dataView.CurrentRow.Cells["no_batch_in_production"].Value.ToString();

                 lblbins.Text = dataView.CurrentRow.Cells["additional_bin"].Value.ToString();

                        txtmainbatch.Text = dataView.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        txtfeedtype.Text = dataView.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                        txtProddate.Text = dataView.CurrentRow.Cells["proddate"].Value.ToString();
                        lblstatus.Text = dataView.CurrentRow.Cells["bagorbin"].Value.ToString();
                    }

                }
            }

        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueDailyProduction();
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

        private void txtmainfeedcode_TextChanged(object sender, EventArgs e)
        {

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

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void txtbatch_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtbatchremain.Text = (float.Parse(txtbatch.Text) + 1).ToString();
            }
            catch (Exception)
            {


            }
        }

        void ProductIDExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING CANNOT BE USED THE RAW MATERIALS, BECAUSE ITS ALREADY IN THE PRODUCTION !";
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
        void BMXIDExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING CANNOT BE USED THE BASEMIXED, BECAUSE ITS ALREADY IN THE PRODUCTION !";
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
  
        void BMXNotIDExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "BASEMIXED ID IS NOT EXISTS";
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

        void RepackIDExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL REPACK IS NOT EXISTS!";
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

        void RepackIDExists2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL IS NOT FOUND!";
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
        void ItemCodeNotMatched()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "ITEM CODE NOT MATCH!";
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

        void FeedCodeNotMatched()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FEED CODE NOT MATCH!";
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


        void ItemAlreadySwiped()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "RAW MATERIAL ALREADY SCANNED!";
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

        void ItemValueNotMatched()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "ITEM QUANITY NOT MATCHED!";
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
        private void btnMacro_Click(object sender, EventArgs e)
        {
            if(txtMacro.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }

          

   








            //if (dataGridView2.Rows.Count >= 1)
            //{
            //    int i = dataGridView2.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dataGridView2.Rows.Count)

                    if (txtMacro.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro.Select();
                        txtMacro.Focus();
                        txtMacro.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {




                        //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
                        //SqlConnection sql_con = new SqlConnection(connetionString);

                        //cmd = new SqlCommand("SELECT repack_id FROM [dbo].[rdf_repackin_entry]  WHERE repack_id=" + txtMacro.Text + " AND prod_id_repack='" + txtproductionid.Text + "' AND rp_item_category='MACRO' AND rp_item_code='" + txtitemcodemacro.Text + "'AND total_repack='" + txtquantitymacro.Text + "' ", sql_con);

                        //SqlDataAdapter daks = new SqlDataAdapter(cmd);

                        //daks.Fill(ds);
                        //int ia = ds.Tables[0].Rows.Count;
                        //if (ia > 0)
                        //{


                            if (txtMacro1.Text.Trim() == string.Empty)
                            {
                                txtMacro1.Text = (float.Parse(txtMacro.Text) * 1).ToString();
                            }
                txtMacro.Enabled = false;
                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //if (txtMacro2.Text.Trim() == string.Empty)
                //{
                //    txtitemcodemacro2.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //    txtquantitymacro2.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //txtMacro.Enabled = false;
                //txtMacroMatic.Text = "";
                //    txtMacro2.Visible = true;
                //    txtMacro2.Focus();

                //}


                //}


                //else
                //{
                //    ItemNotExists();

                //        txtMacro.Text = "";
                //    txtMacro.Select();
                //    txtMacro.Focus();
                //    return;
                //}

                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro.Enabled = false;
                //    txtbmx.Focus();
                //}

            }





        }





        void batchqtyNotMacthed()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "BATCH QUANTITY IS NOT MATCH!";
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
        void SuccessFullyValidateMacroValidate ()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "MACRO GROUP VALIDATE, ALREADY CHECK. ...";
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
            lblmain6.Visible = true;

            popup.ShowOptionsButton = true;
            txtbmx.Visible = true;
            load_search();
            doSearchValidate();
            showValueDailyProduction();




            //txtScanner.Enabled = false;


            lblmain6.Visible = true;

        }

        void SuccessFullyProduction()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "PRODUCTION OF "+txtfeedtype.Text+" "+txtbatchremain.Text+" OUT OF "+txtmainbatch.Text+" BATCH SUCCESSFULLY SAVE !";
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
            //game
            if(lbltotalprod.Text=="0")
            {

            }
            else
            {
                txtTheorotical.Enabled = true;
                txtTheorotical.Focus();

            }
        }

        void SuccessFullyTheorotical()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "MACRO GROUP THEOROTICAL, ALREADY CHECKs !";
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







            lblvalidatecount.Visible = true;
          lblmacrocount.Visible = true;




            btnnextline_Click(new object(), new System.EventArgs());



















            lblmain5.Visible = true;


            lblscanthebarcode.Visible = true;
            txtScanner.Visible = true;
            txtScanner.Enabled = true;
            txtScanner.Select();
            txtScanner.Focus();

        }






        void FillEmptyFields()
            {

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.info;
                popup.TitleText = "Fedora Notifications";
                popup.TitleColor = Color.White;
                popup.TitlePadding = new Padding(95, 7, 0, 0);
                popup.TitleFont = new Font("Tahoma", 10);
                popup.ContentText = "FILL UP THE EMPTY FIELDS !";
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















            private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueMacro();
        }



        void showValueMacro()
        {

            if (dataGridView2.RowCount > 0)
            {
                if (dataGridView2.CurrentRow != null)
                {
                    if (dataGridView2.CurrentRow.Cells["item_code_macro"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtitemcodemacro.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

              txtsubfeedcode.Text = dataGridView2.CurrentRow.Cells["feed_coded"].Value.ToString();

                    }

                }
            }

        }

        private void txtbatchremain_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMacro2_Click(object sender, EventArgs e)
        {
            if (txtMacro2.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "exit");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{
            //    //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //cboFeedCode.Focus();
            //    ProductIDExists();
            //    txtMacro2.Text = "";
            //    txtMacro2.Focus();
            //    return;
            //}
            //else
            //{
            //    //FeedCodeNotExists();

            //}

            //2




            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "checkrepackingid");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    txtMacroMatic.Text = (float.Parse(txtMacro2.Text) * 1).ToString();

            //}
            //else
            //{
            //    RepackIDExists();
            //    txtMacro2.Text = "";
            //    txtMacro2.Focus();
            //    return;
            //}


            //if (txtmainfeedcode.Text.Trim() == txtfeedcodechecking.Text.Trim())
            //{

            //}
            //else
            //{

            //    FeedCodeNotMatched();
            //    txtMacro2.Text = "";
            //    txtMacro2.Focus();
            //    return;
            //}


            //if (txtitemcodemacro2.Text.Trim() == txtrp_item_code.Text.Trim())
            //{

            //}
            //else
            //{
            //    ItemCodeNotMatched();
            //    //txtMacro2.Text = "";
            //    //txtMacro2.Focus();
            //    doRepackingEntry();
            //    return;
            //}

            //if (txtquantitymacro2.Text.Trim() == txttotal_repack.Text.Trim())
            //{


            //}
            //else
            //{

            //    ItemValueNotMatched();
            //    txtMacro2.Text = "";
            //    txtMacro2.Focus();
            //    return;
            //}


            //if (dataGridView2.Rows.Count >= 1)
            //{
            //    int i = dataGridView2.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dataGridView2.Rows.Count)

                    if (txtMacro2.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro2.Select();
                        txtMacro2.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {



                txtMacro2.Enabled = false;



                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //if (txtMacro3.Text.Trim() == string.Empty)
                //{
                //    txtitemcodemacro3.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //    txtquantitymacro3.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //    txtMacro2.Enabled = false;
                //    txtMacroMatic.Text = "";
                //    txtMacro3.Visible = true;
                //    txtMacro3.Focus();

                //}




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro2.Enabled = false;
                //    txtbmx.Focus();
                //}

            }

        }

        private void btnMacro3_Click(object sender, EventArgs e)
        {
            if (txtMacro3.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "exit");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{
            //    //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //cboFeedCode.Focus();
            //    ProductIDExists();
            //    txtMacro3.Text = "";
            //    txtMacro3.Focus();
            //    return;
            //}
            //else
            //{
            //    //FeedCodeNotExists();

            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "checkrepackingid");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    txtMacroMatic.Text = (float.Parse(txtMacro3.Text) * 1).ToString();

            //}
            //else
            //{
            //    RepackIDExists();
            //    txtMacro3.Text = "";
            //    txtMacro3.Focus();
            //    return;
            //}


            //if (txtmainfeedcode.Text.Trim() == txtfeedcodechecking.Text.Trim())
            //{

            //}
            //else
            //{

            //    FeedCodeNotMatched();
            //    txtMacro3.Text = "";
            //    txtMacro3.Focus();
            //    return;
            //}


            //if (txtitemcodemacro3.Text.Trim() == txtrp_item_code.Text.Trim())
            //{

            //}
            //else
            //{
            //    ItemCodeNotMatched();
            //    //txtMacro3.Text = "";
            //    //txtMacro3.Focus();
            //    return;
            //}

            //if (txtquantitymacro3.Text.Trim() == txttotal_repack.Text.Trim())
            //{


            //}
            //else
            //{

            //    ItemValueNotMatched();
            //    txtMacro3.Text = "";
            //    txtMacro3.Focus();
            //    return;
            //}


            //if (dataGridView2.Rows.Count >= 1)
            //{
            //    int i = dataGridView2.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dataGridView2.Rows.Count)

                    if (txtMacro3.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro3.Select();
                        txtMacro3.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {





                txtMacro3.Enabled = false;

                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //if (txtMacro4.Text.Trim() == string.Empty)
                //        {
                //            txtitemcodemacro4.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //            txtquantitymacro4.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //            txtMacro3.Enabled = false;
                //            txtMacroMatic.Text = "";
                //            txtMacro4.Visible = true;
                //            txtMacro4.Focus();

                //        }




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro3.Enabled = false;
                //    txtbmx.Focus();
                //}

            }
        }

        private void btnMacro4_Click(object sender, EventArgs e)
        {
            if (txtMacro4.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }


            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "exit");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{
            //    //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //cboFeedCode.Focus();
            //    ProductIDExists();
            //    txtMacro4.Text = "";
            //    txtMacro4.Focus();
            //    return;
            //}
            //else
            //{
            //    //FeedCodeNotExists();

            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "checkrepackingid");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    txtMacroMatic.Text = (float.Parse(txtMacro4.Text) * 1).ToString();

            //}
            //else
            //{
            //    RepackIDExists();
            //    txtMacro4.Text = "";
            //    txtMacro4.Focus();
            //    return;
            //}

            //if (txtmainfeedcode.Text.Trim() == txtfeedcodechecking.Text.Trim())
            //{

            //}
            //else
            //{

            //    FeedCodeNotMatched();
            //    txtMacro4.Text = "";
            //    txtMacro4.Focus();
            //    return;
            //}



            //if (txtitemcodemacro4.Text.Trim() == txtrp_item_code.Text.Trim())
            //{

            //}
            //else
            //{
            //    ItemCodeNotMatched();
            //    //txtMacro4.Text = "";
            //    //txtMacro4.Focus();
            //    return;
            //}

            //if (txtquantitymacro4.Text.Trim() == txttotal_repack.Text.Trim())
            //{


            //}
            //else
            //{

            //    ItemValueNotMatched();
            //    txtMacro4.Text = "";
            //    txtMacro4.Focus();
            //    return;
            //}


            //if (dataGridView2.Rows.Count >= 1)
            //{
            //    int i = dataGridView2.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dataGridView2.Rows.Count)

                    if (txtMacro4.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro4.Select();
                        txtMacro4.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {





                txtMacro4.Enabled = false;

                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //        if (txtMacro5.Text.Trim() == string.Empty)
                //        {
                //            txtitemcodemacro5.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //            txtquantitymacro5.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //            txtMacro4.Enabled = false;
                //            txtMacroMatic.Text = "";
                //            txtMacro5.Visible = true;
                //            txtMacro5.Focus();

                //        }




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro4.Enabled = false;
                //    txtbmx.Focus();
                //}

            }
        }

        private void btnMacro5_Click(object sender, EventArgs e)
        {
            if (txtMacro5.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "exit");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{
            //    //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //cboFeedCode.Focus();
            //    ProductIDExists();
            //    txtMacro5.Text = "";
            //    txtMacro5.Focus();
            //    return;
            //}
            //else
            //{
            //    //FeedCodeNotExists();

            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "checkrepackingid");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    txtMacroMatic.Text = (float.Parse(txtMacro5.Text) * 1).ToString();

            //}
            //else
            //{
            //    RepackIDExists();
            //    txtMacro5.Text = "";
            //    txtMacro5.Focus();
            //    return;
            //}


            //if (txtmainfeedcode.Text.Trim() == txtfeedcodechecking.Text.Trim())
            //{

            //}
            //else
            //{

            //    FeedCodeNotMatched();
            //    txtMacro5.Text = "";
            //    txtMacro5.Focus();
            //    return;
            //}


            //if (txtitemcodemacro5.Text.Trim() == txtrp_item_code.Text.Trim())
            //{

            //}
            //else
            //{
            //    ItemCodeNotMatched();
            //    //txtMacro5.Text = "";
            //    //txtMacro5.Focus();
            //    return;
            //}

            //if (txtquantitymacro5.Text.Trim() == txttotal_repack.Text.Trim())
            //{


            //}
            //else
            //{

            //    ItemValueNotMatched();
            //    txtMacro5.Text = "";
            //    txtMacro5.Focus();
            //    return;
            //}


            //if (dataGridView2.Rows.Count >= 1)
            //{
            //    int i = dataGridView2.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dataGridView2.Rows.Count)

                    if (txtMacro5.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro5.Select();
                        txtMacro5.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {





                txtMacro5.Enabled = false;

                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //        if (txtMacro6.Text.Trim() == string.Empty)
                //        {
                //            txtitemcodemacro6.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //            txtquantitymacro6.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //            txtMacro5.Enabled = false;
                //            txtMacroMatic.Text = "";
                //            txtMacro6.Visible = true;
                //            txtMacro6.Focus();

                //        }




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro5.Enabled = false;
                //    txtbmx.Focus();
                //}

            }
        }

        private void btnMacro6_Click(object sender, EventArgs e)
        {
            if (txtMacro6.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }
            dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "exit");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{
            //    //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //cboFeedCode.Focus();
            //    ProductIDExists();
            //    txtMacro6.Text = "";
            //    txtMacro6.Focus();
            //    return;
            //}
            //else
            //{
            //    //FeedCodeNotExists();

            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "checkrepackingid");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    txtMacroMatic.Text = (float.Parse(txtMacro6.Text) * 1).ToString();

            //}
            //else
            //{
            //    RepackIDExists();
            //    txtMacro6.Text = "";
            //    txtMacro6.Focus();
            //    return;
            //}

            //if (txtmainfeedcode.Text.Trim() == txtfeedcodechecking.Text.Trim())
            //{

            //}
            //else
            //{

            //    FeedCodeNotMatched();
            //    txtMacro6.Text = "";
            //    txtMacro6.Focus();
            //    return;
            //}


            //if (txtitemcodemacro6.Text.Trim() == txtrp_item_code.Text.Trim())
            //{

            //}
            //else
            //{
            //    ItemCodeNotMatched();
            //    //txtMacro6.Text = "";
            //    //txtMacro6.Focus();
            //    return;
            //}

            //if (txtquantitymacro6.Text.Trim() == txttotal_repack.Text.Trim())
            //{


            //}
            //else
            //{

            //    ItemValueNotMatched();
            //    txtMacro6.Text = "";
            //    txtMacro6.Focus();
            //    return;
            //}


            //if (dataGridView2.Rows.Count >= 1)
            //{
            //    int i = dataGridView2.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dataGridView2.Rows.Count)

                    if (txtMacro6.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro6.Select();
                        txtMacro6.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {





                txtMacro6.Enabled = false;

                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //        if (txtMacro7.Text.Trim() == string.Empty)
                //        {
                //            txtitemcodemacro7.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //            txtquantitymacro7.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //            txtMacro6.Enabled = false;
                //            txtMacroMatic.Text = "";
                //            txtMacro7.Visible = true;
                //            txtMacro7.Focus();

                //        }




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro6.Enabled = false;
                //    txtbmx.Focus();
                //}

            }
        }

        private void btnMacro7_Click(object sender, EventArgs e)
        {
            if (txtMacro7.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "exit");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{
            //    //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //cboFeedCode.Focus();
            //    ProductIDExists();
            //    txtMacro7.Text = "";
            //    txtMacro7.Focus();
            //    return;
            //}
            //else
            //{
            //    //FeedCodeNotExists();

            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "checkrepackingid");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    txtMacroMatic.Text = (float.Parse(txtMacro7.Text) * 1).ToString();

            //}
            //else
            //{
            //    RepackIDExists();
            //    txtMacro7.Text = "";
            //    txtMacro7.Focus();
            //    return;
            //}

            //if (txtmainfeedcode.Text.Trim() == txtfeedcodechecking.Text.Trim())
            //{

            //}
            //else
            //{

            //    FeedCodeNotMatched();
            //    txtMacro7.Text = "";
            //    txtMacro7.Focus();
            //    return;
            //}



            //if (txtitemcodemacro7.Text.Trim() == txtrp_item_code.Text.Trim())
            //{

            //}
            //else
            //{
            //    ItemCodeNotMatched();
            //    //txtMacro7.Text = "";
            //    //txtMacro7.Focus();
            //    return;
            //}

            //if (txtquantitymacro7.Text.Trim() == txttotal_repack.Text.Trim())
            //{


            //}
            //else
            //{

            //    ItemValueNotMatched();
            //    txtMacro7.Text = "";
            //    txtMacro7.Focus();
            //    return;
            //}


            //if (dataGridView2.Rows.Count >= 1)
            //{
            //    int i = dataGridView2.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dataGridView2.Rows.Count)

                    if (txtMacro7.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro7.Select();
                        txtMacro7.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {




                txtMacro7.Enabled = false;


                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //        if (txtMacro8.Text.Trim() == string.Empty)
                //        {
                //            txtitemcodemacro8.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //            txtquantitymacro8.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //            txtMacro7.Enabled = false;
                //            txtMacroMatic.Text = "";
                //            txtMacro8.Visible = true;
                //            txtMacro8.Focus();

                //        }




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro7.Enabled = false;
                //    txtbmx.Focus();
                //}

            }
        }

        private void btnMacro8_Click(object sender, EventArgs e)
        {
            if (txtMacro8.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "exit");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{
            //    //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //cboFeedCode.Focus();
            //    ProductIDExists();
            //    txtMacro8.Text = "";
            //    txtMacro8.Focus();
            //    return;
            //}
            //else
            //{
            //    //FeedCodeNotExists();

            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", "", "", "checkrepackingid");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    txtMacroMatic.Text = (float.Parse(txtMacro8.Text) * 1).ToString();

            //}
            //else
            //{
            //    RepackIDExists();
            //    txtMacro8.Text = "";
            //    txtMacro8.Focus();
            //    return;
            //}

            //if (txtmainfeedcode.Text.Trim() == txtfeedcodechecking.Text.Trim())
            //{

            //}
            //else
            //{

            //    FeedCodeNotMatched();
            //    txtMacro8.Text = "";
            //    txtMacro8.Focus();
            //    return;
            //}



            //if (txtitemcodemacro8.Text.Trim() == txtrp_item_code.Text.Trim())
            //{

            //}
            //else
            //{
            //    ItemCodeNotMatched();
            //    //txtMacro8.Text = "";
            //    //txtMacro8.Focus();
            //    return;
            //}

            //if (txtquantitymacro8.Text.Trim() == txttotal_repack.Text.Trim())
            //{


            //}
            //else
            //{

            //    ItemValueNotMatched();
            //    txtMacro8.Text = "";
            //    txtMacro8.Focus();
            //    return;
            //}


            //if (dataGridView2.Rows.Count >= 1)
            //{
            //    int i = dataGridView2.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dataGridView2.Rows.Count)

                    if (txtMacro8.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro8.Select();
                        txtMacro8.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {




                txtMacro8.Enabled = false;


                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //        if (txtMacro9.Text.Trim() == string.Empty)
                //        {
                //            txtitemcodemacro9.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //            txtquantitymacro9.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //            txtMacro8.Enabled = false;
                //            txtMacroMatic.Text = "";
                //            txtMacro9.Visible = true;
                //            txtMacro9.Focus();

                //        }




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro8.Enabled = false;
                //    txtbmx.Focus();
                //}

            }
        }

        private void btnMacro9_Click(object sender, EventArgs e)
        {
            if (txtMacro9.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }




                    if (txtMacro9.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro9.Select();
                        txtMacro9.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {




                txtMacro9.Enabled = false;


                //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                //        if (txtMacro10.Text.Trim() == string.Empty)
                //        {
                //            txtitemcodemacro10.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                //            txtquantitymacro10.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //            txtMacro9.Enabled = false;
                //            txtMacroMatic.Text = "";
                //            txtMacro10.Visible = true;
                //            txtMacro10.Focus();

                //        }




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();
                //    txtMacro9.Enabled = false;
                //    txtbmx.Focus();
                //}

            }
        }

        private void btnMacro10_Click(object sender, EventArgs e)
        {
            if (txtMacro10.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }






                    if (txtMacro10.Text.Trim() == string.Empty)
                    {

                        FillEmptyFields();
                        txtMacro10.Select();
                        txtMacro10.Focus();
                        //txtMacro2.BackColor = Color.Yellow;


                        return;
                    }
                    else
                    {







                        //dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                    
                            txtMacro10.Enabled = false;
              




                //    }



                //else
                //{
                //    SuccessFullyValidateMacroValidate();

                //    txtMacro10.Enabled = false;
                //    txtbmx.Focus();
                //}

            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {

            if(txtbmx.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtbmx.Select();
                txtbmx.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, txtbmx.Text, txtproductionid.Text, "", "", "", "",txtMacro11.Text,txtMacro12.Text,txtMacro13.Text,txtMacro14.Text,txtMacro15.Text, "bmxexisting");
            if (dSet.Tables[0].Rows.Count > 0)
            {
//pekpek
                BMXIDExists();
                txtbmx.Text = "";
                txtbmx.Focus();
                return;
            }
            else
            {
                //FeedCodeNotExists();

            }





            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            SqlConnection sql_con = new SqlConnection(connetionString);

            cmd = new SqlCommand("SELECT bmx_id_string FROM [dbo].[rdf_repackin_bmx]  WHERE bmx_id_string=" + txtbmx.Text + " AND prod_adv='" + txtproductionid.Text + "' AND bmx_feed_code='" + txtmainfeedcode.Text + "'", sql_con);

            SqlDataAdapter daks = new SqlDataAdapter(cmd);

            daks.Fill(ds);
            int ia = ds.Tables[0].Rows.Count;
            if (ia > 0)
            {

                dset_emp2 = objStorProc.sp_getMajorTables("Basemixed");
                dset_emp3 = objStorProc.sp_getMajorTables("BMXRepack");
                doBMXRepack();

    
                //MessageBox.Show("Ready to save");//
                //bakala
                if (txtactualweight.Text.Trim() ==string.Empty)
                {

                    txtbmx.Text = "";
                    txtbmx.Select();
                    txtbmx.Focus();
                    //MessageBox.Show("actualweight");
                    BMXNotIDExists();
                    return;
                }

                btnsubmit.Visible = true;
                txtactualweight.Visible = true;
                //if (txtbatchremain.Text=="0")
                //{
                txtbmx.Enabled = false;
                lblactualweightinfo.Visible = true;
                //}

                //else
                //{

                //}
            }


            else
            {
                BMXNotIDExists();
           
                //MessageBox.Show("Not Exists");
                txtbmx.Text = "";
                txtbmx.Select();
                return;
            }


        }

        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueBMX();
        }
        void showValueBMX()
        {

            if (dataGridView3.RowCount > 0)
            {
                if (dataGridView3.CurrentRow != null)
                {
                    if (dataGridView3.CurrentRow.Cells["bmx_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                     txtbmxqtybatch.Text = dataGridView3.CurrentRow.Cells["bmx_qty_batch"].Value.ToString();
                   //txtprodid.Text = dataGridView3.CurrentRow.Cells["prod_id"].Value.ToString();
                        txtmixingdate.Text = dataGridView3.CurrentRow.Cells["bmx_date_of_mixing"].Value.ToString();


                    }

                }
            }

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueTheorotical();
        }


        void showValueTheorotical()
        {

            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtitemcode0.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                        txtquantity0.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                        txtdes.Text = dataGridView1.CurrentRow.Cells["rp_description"].Value.ToString();


                    }

                }
            }

        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
       
            //Angela
            load_TheoMaterials();
            dataGridView7_CurrentCellChanged(sender, e);

            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtquantity0.Text);
            selectquantity = double.Parse(txtTheorotical.Text);

            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)


                    //if (mainbalance == selectquantity)

                    //    if (txtquantity0.Text.Trim() == txtTheorotical.Text.Trim())

                    //    {
                           
                    //    }
                    //    else 
                    //    {
                    //    batchqtyNotMacthed();
                    //    txtTheorotical.Text = "";
                    //    txtTheorotical.Select();
                    //    txtTheorotical.Focus();
                    //    return;
                    //}

                //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtquantity0.Text)).ToString();
                //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical.Text)).ToString();
txtvariance.Text = (float.Parse(txtTheorotical.Text) - float.Parse(txtquantity0.Text)).ToString();
                //txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();
                
                dSet.Clear();

                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                   bunifuStart.Visible = false;
                   btngreaterthan.Visible = false;
                   btnlessthan.Visible = false;
                   ControlBox = false;
                            if (txtTheorotical2.Text.Trim() == string.Empty)
                            {
                                txtitemcode2.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                                txtquantity2.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                    txtTheorotical.Enabled = false;
                    txtTheorotical2.Visible = true;
                                txtTheorotical2.Focus();
                                return;
                            }


                //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtquantity0.Text)).ToString();



                else
                {
                    //if (txtquantity0.Text.Trim() == txtTheorotical.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    batchqtyNotMacthed();
                    //    txtTheorotical.Text = "";
                    //    txtTheorotical.Select();
                    //    txtTheorotical.Focus();
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);
                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();

                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text,txtTheorotical.Text, txtbatchremain.Text, txtmainfeedcode.Text,"1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text,txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                    txtTheorotical.Enabled = false;
                    SuccessFullyTheorotical();

                }

            }

        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical2.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical2.Select();
                        txtTheorotical2.Focus();
                        txtTheorotical2.BackColor = Color.Yellow;
                        FillEmptyFields();

                        return;
                    }
                    else
                    {


                        //if (txtquantity2.Text.Trim() == txtTheorotical2.Text.Trim())

                        //{
                         
                        //}
                        //else
                        //{
                        //    batchqtyNotMacthed();
                        //    txtTheorotical2.Text = "";
                        //    txtTheorotical2.Select();
                        //    txtTheorotical2.Focus();
                        //    return;
                        //}
                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);

                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical2.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical2.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();

                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical2.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text,txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        if (txtTheorotical3.Text.Trim() == string.Empty)
                        {
                            txtitemcode3.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                            txtquantity3.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                            txtTheorotical2.Enabled = false;
                            txtTheorotical3.Visible = true;
                            txtTheorotical3.Focus();
                            return;
                        }


                    }

           


                else
                {
                    //if (txtquantity2.Text.Trim() == txtTheorotical2.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    batchqtyNotMacthed();
                    //    txtTheorotical2.Text = "";
                    //    txtTheorotical2.Select();
                    //    txtTheorotical2.Focus();
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);
                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical2.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical2.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();
                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical2.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text,txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    txtTheorotical2.Enabled = false;
                    SuccessFullyTheorotical();

                }

            }

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical3.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical3.Select();
                        txtTheorotical3.Focus();
                        txtTheorotical3.BackColor = Color.Yellow;
                        FillEmptyFields();

                        return;
                    }
                    else
                    {


                        //if (txtquantity3.Text.Trim() == txtTheorotical3.Text.Trim())

                        //{

                        //}
                        //else
                        //{
                        //    txtTheorotical3.Text = "";
                        //    batchqtyNotMacthed();
                        //    txtTheorotical3.Select();
                        //    txtTheorotical3.Focus();
                        //    return;
                        //}

                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);

                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical3.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical3.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();
                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical3.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        if (txtTheorotical4.Text.Trim() == string.Empty)
                        {
                            txtitemcode4.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                            txtquantity4.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                            txtTheorotical3.Enabled = false;
                            txtTheorotical4.Visible = true;
                            txtTheorotical4.Focus();
                            return;
                        }


                    }



                else
                {
                    //if (txtquantity3.Text.Trim() == txtTheorotical3.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    txtTheorotical3.Text = "";
                    //    batchqtyNotMacthed();
                    //    txtTheorotical3.Select();
                    //    txtTheorotical3.Focus();
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);
                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical3.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical3.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();
                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical3.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text,txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    txtTheorotical3.Enabled = false;
                    SuccessFullyTheorotical();

                }

            }
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical4.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical4.Select();
                        txtTheorotical4.Focus();
                        txtTheorotical4.BackColor = Color.Yellow;
                        FillEmptyFields();

                        return;
                    }
                    else
                    {


                        //if (txtquantity4.Text.Trim() == txtTheorotical4.Text.Trim())

                        //{

                        //}
                        //else
                        //{
                        //    txtTheorotical4.Text = "";
                        //    batchqtyNotMacthed();
                        //    txtTheorotical4.Select();
                        //    txtTheorotical4.Focus();
                        //    txtTheorotical4.Text = "";
                        //    return;
                        //}
                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);

                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical4.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical4.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();
                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical4.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        if (txtTheorotical5.Text.Trim() == string.Empty)
                        {
                            txtTheorotical4.Enabled = false;
                            txtitemcode5.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                            txtquantity5.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                            txtTheorotical5.Visible = true;

                            txtTheorotical5.Focus();
                            return;
                        }


                    }



                else
                {
                    //if (txtquantity4.Text.Trim() == txtTheorotical4.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    txtTheorotical4.Text = "";
                    //    batchqtyNotMacthed();
                    //    txtTheorotical4.Select();
                    //    txtTheorotical4.Focus();
                    //    txtTheorotical4.Text = "";
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);
                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical4.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical4.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();

                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical4.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    txtTheorotical4.Enabled = false;
                    SuccessFullyTheorotical();
        
                }

            }
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical5.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical5.Select();
                        txtTheorotical5.Focus();
                        txtTheorotical5.BackColor = Color.Yellow;
                        FillEmptyFields();

                        return;
                    }
                    else
                    {


                        //if (txtquantity5.Text.Trim() == txtTheorotical5.Text.Trim())

                        //{

                        //}
                        //else
                        //{
                        //    txtTheorotical5.Text = "";
                        //    batchqtyNotMacthed();
                        //    txtTheorotical5.Select();
                        //    txtTheorotical5.Focus();
                        //    txtTheorotical5.Text = "";
                        //    return;
                        //}
                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);

                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical5.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical5.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();
                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical5.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        if (txtTheorotical6.Text.Trim() == string.Empty)
                        {
                            txtTheorotical5.Enabled = false;
                            txtitemcode6.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                            txtquantity6.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                            txtTheorotical6.Visible = true;

                            txtTheorotical6.Focus();
                            return;
                        }


                    }



                else
                {
                    //if (txtquantity5.Text.Trim() == txtTheorotical5.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    txtTheorotical5.Text = "";
                    //    batchqtyNotMacthed();
                    //    txtTheorotical5.Select();
                    //    txtTheorotical5.Focus();
                    //    txtTheorotical5.Text = "";
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);
                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical5.Text)).ToString();

                    txtvariance.Text = (float.Parse(txtTheorotical5.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();
                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical5.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");

                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    txtTheorotical5.Enabled = false;
                    SuccessFullyTheorotical();
     
                }

            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical6.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical6.Select();
                        txtTheorotical6.Focus();
                        txtTheorotical6.BackColor = Color.Yellow;

                        FillEmptyFields();
                        return;
                    }
                    else
                    {


                        //if (txtquantity6.Text.Trim() == txtTheorotical6.Text.Trim())

                        //{
                    
                        //}
                        //else
                        //{
                        //    batchqtyNotMacthed();
                        //    txtTheorotical6.Text = "";
                        //    txtTheorotical6.Select();
                        //    txtTheorotical6.Focus();
                        //    txtTheorotical6.Text = "";
                        //    return;
                        //}
                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);
                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical6.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical6.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();
                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical6.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        if (txtTheorotical7.Text.Trim() == string.Empty)
                        {
                            txtitemcode7.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                            txtquantity7.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                            txtTheorotical6.Enabled = false;
                            txtTheorotical7.Visible = true;
                            txtTheorotical7.Focus();
                            return;
                        }


                    }



                else
                {
                    //if (txtquantity6.Text.Trim() == txtTheorotical6.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    batchqtyNotMacthed();
                    //    txtTheorotical6.Text = "";
                    //    txtTheorotical6.Select();
                    //    txtTheorotical6.Focus();
                    //    txtTheorotical6.Text = "";
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);
                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical6.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical6.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();
                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical6.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    txtTheorotical6.Enabled = false;
                    SuccessFullyTheorotical();

                }

            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical7.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical7.Select();
                        txtTheorotical7.Focus();
                        txtTheorotical7.BackColor = Color.Yellow;
                        FillEmptyFields();

                        return;
                    }
                    else
                    {


                        //if (txtquantity7.Text.Trim() == txtTheorotical7.Text.Trim())

                        //{

                        //}
                        //else
                        //{
                        //    batchqtyNotMacthed();
                        //    txtTheorotical7.Text = "";
                        //    txtTheorotical7.Select();
                        //    txtTheorotical7.Focus();
                        //    txtTheorotical7.Text = "";
                        //    return;
                        //}
                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);
                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical7.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical7.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();
                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical7.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        if (txtTheorotical8.Text.Trim() == string.Empty)
                        {
                            txtitemcode8.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                            txtquantity8.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                            txtTheorotical7.Enabled = false;
                            txtTheorotical8.Visible = true;
                            txtTheorotical8.Focus();
                            return;
                        }


                    }



                else
                {
                    //if (txtquantity7.Text.Trim() == txtTheorotical7.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    batchqtyNotMacthed();
                    //    txtTheorotical7.Text = "";
                    //    txtTheorotical7.Select();
                    //    txtTheorotical7.Focus();
                    //    txtTheorotical7.Text = "";
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);
                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical7.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical7.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();
                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical7.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    txtTheorotical7.Enabled = false;
                    SuccessFullyTheorotical();
                    txtMacro.Focus();
                }

            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical8.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical8.Select();
                        txtTheorotical8.Focus();
                        txtTheorotical8.BackColor = Color.Yellow;
                        FillEmptyFields();

                        return;
                    }
                    else
                    {


                        //if (txtquantity8.Text.Trim() == txtTheorotical8.Text.Trim())

                        //{

                        //}
                        //else
                        //{
                        //    batchqtyNotMacthed();
                        //    txtTheorotical8.Text = "";
                        //    txtTheorotical8.Select();
                        //    txtTheorotical8.Focus();
                        //    txtTheorotical8.Text = "";
                        //    return;
                        //}
                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);
                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical8.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical8.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();
                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical8.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        if (txtTheorotical9.Text.Trim() == string.Empty)
                        {
                            txtitemcode9.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                            txtquantity9.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                            txtTheorotical8.Enabled = false;
                            txtTheorotical9.Visible = true;
                            txtTheorotical9.Focus();
                            return;
                        }


                    }



                else
                {
                    //if (txtquantity8.Text.Trim() == txtTheorotical8.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    batchqtyNotMacthed();
                    //    txtTheorotical8.Text = "";
                    //    txtTheorotical8.Select();
                    //    txtTheorotical8.Focus();
                    //    txtTheorotical8.Text = "";
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);

                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical8.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical8.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();
                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical8.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG"); 
                    txtTheorotical8.Enabled = false;
                    SuccessFullyTheorotical();
                    txtMacro.Focus();
                }

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical9.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical9.Select();
                        txtTheorotical9.Focus();
                        txtTheorotical9.BackColor = Color.Yellow;
                        FillEmptyFields();

                        return;
                    }
                    else
                    {


                        //if (txtquantity9.Text.Trim() == txtTheorotical9.Text.Trim())

                        //{

                        //}
                        //else
                        //{
                        //    batchqtyNotMacthed();
                        //    txtTheorotical9.Text = "";
                        //    txtTheorotical9.Select();
                        //    txtTheorotical9.Focus();
                        //    txtTheorotical9.Text = "";
                        //    return;
                        //}
                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);
                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical9.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical9.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();
                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical9.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        if (txtTheorotical10.Text.Trim() == string.Empty)
                        {
                            txtitemcode10.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                            txtquantity10.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                            txtTheorotical9.Enabled = false;
                            txtTheorotical10.Visible = true;
                            txtTheorotical10.Focus();
                            return;
                        }


                    }



                else
                {
                    //if (txtquantity9.Text.Trim() == txtTheorotical9.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    batchqtyNotMacthed();
                    //    txtTheorotical9.Text = "";
                    //    txtTheorotical9.Select();
                    //    txtTheorotical9.Focus();
                    //    txtTheorotical9.Text = "";
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);
                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical9.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical9.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();


                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical9.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    txtTheorotical9.Enabled = false;
                    SuccessFullyTheorotical();
                    txtMacro.Focus();
                }

            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                int i = dataGridView1.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView1.Rows.Count)

                    if (txtTheorotical10.Text.Trim() == string.Empty)
                    {

                        //BarcodeNotFound();//4/18/2020
                        //MessageBox.Show("Part1", "Barcode Input Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTheorotical10.Select();
                        txtTheorotical10.Focus();
                        txtTheorotical10.BackColor = Color.Yellow;
                        FillEmptyFields();

                        return;
                    }
                    else
                    {


                        //if (txtquantity10.Text.Trim() == txtTheorotical10.Text.Trim())

                        //{

                        //}
                        //else
                        //{
                        //    batchqtyNotMacthed();
                        //    txtTheorotical10.Text = "";
                        //    txtTheorotical10.Select();
                        //    txtTheorotical10.Focus();
                        //    txtTheorotical10.Text = "";
                        //    return;
                        //}
                        load_TheoMaterials();
                        dataGridView7_CurrentCellChanged(sender, e);
                        //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical10.Text)).ToString();
                        txtvariance.Text = (float.Parse(txtTheorotical10.Text) - float.Parse(txtquantity0.Text)).ToString();
                        dSet.Clear();
                        dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical10.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                        //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                        //if (txtTheorotical10.Text.Trim() == string.Empty)
                        //{
                        //    txtitemcode10.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                        //    txtquantity10.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();


                        //    txtTheorotical10.Focus();
                        //    return;
                        //}


                    }



                else
                {
                    //if (txtquantity10.Text.Trim() == txtTheorotical10.Text.Trim())

                    //{

                    //}
                    //else
                    //{
                    //    batchqtyNotMacthed();
                    //    txtTheorotical10.Text = "";
                    //    txtTheorotical10.Select();
                    //    txtTheorotical10.Focus();
                    //    txtTheorotical10.Text = "";
                    //    return;
                    //}
                    load_TheoMaterials();
                    dataGridView7_CurrentCellChanged(sender, e);

                    //txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical10.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical10.Text) - float.Parse(txtquantity0.Text)).ToString();
                    dSet.Clear();

                    dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode0.Text, txtTheorotical10.Text, txtbatchremain.Text, txtmainfeedcode.Text, "1", txtaddedby.Text, txtdatenow.Text, txtquantity0.Text, txtvariance.Text, "", "", "", "", "", "", "", "InsertTheoBoy");
                    //dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode0.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");
                    txtTheorotical10.Enabled = false;
                    SuccessFullyTheorotical();
                    txtMacro.Focus();
                }

            }
        }

        private void txtbmx_TextChanged(object sender, EventArgs e)
        {
            doBMXRepack();
        }

        private void dataGridView4_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueBMXSearchFinal();
        }



        void showValueBMXSearchFinal()
        {

            if (dataGridView4.RowCount > 0)
            {
                if (dataGridView4.CurrentRow != null)
                {
                    if (dataGridView4.CurrentRow.Cells["bmx_id_string"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtbmx_id.Text = dataGridView4.CurrentRow.Cells["bmx_id_string"].Value.ToString();
                txtbatchprint.Text = dataGridView4.CurrentRow.Cells["bmx_batch_print"].Value.ToString();
                      txtactualweight.Text = dataGridView4.CurrentRow.Cells["actual_weight"].Value.ToString();


                    }

                }
            }

        }

        private void txtTheorotical_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTheorotical_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton210_Click(sender, e);
            //}
        }

        private void txtTheorotical2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTheorotical2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton29_Click(sender, e);
            //}
        }

        private void txtbmx_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bntSave_Click(sender, e);
            //}
        }

        private void txtbmx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtTheorotical3_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton28_Click(sender, e);
            //}
        }

        private void txtTheorotical4_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton27_Click(sender, e);
            //}
        }

        private void txtTheorotical5_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton26_Click(sender, e);
            //}
        }

        private void txtTheorotical6_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton25_Click(sender, e);
            //}
        }

        private void txtTheorotical7_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton24_Click(sender, e);
            //}
        }

        private void txtTheorotical8_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton23_Click(sender, e);
            //}
        }

        private void txtTheorotical9_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton22_Click(sender, e);
            //}
        }

        private void txtTheorotical10_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bunifuThinButton21_Click(sender, e);
            //}
        }

        private void txtMacro10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMacro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMacro_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro_Click(sender, e);
            //}
        }

        private void txtMacro2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro2_Click(sender, e);
            //}
        }

        private void txtMacro3_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro3_Click(sender, e);
            //}
        }

        private void txtMacro4_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro4_Click(sender, e);
            //}
        }

        private void txtMacro5_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro5_Click(sender, e);
            //}
        }

        private void txtMacro6_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro6_Click(sender, e);
            //}
        }

        private void txtMacro7_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro7_Click(sender, e);
            //}
        }

        private void txtMacro8_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro8_Click(sender, e);
            //}
        }

        private void txtMacro9_KeyDown(object sender, KeyEventArgs e)
        {


            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro9_Click(sender, e);
            //}
        }

        private void txtMacro10_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnMacro10_Click(sender, e);
            //}
        }

        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","","","","","","","","","","","","","","","","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
   
                    dSets = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text.Trim(), txtfeedtype.Text.Trim(),txtproductionid.Text.Trim(), txtmainbatch.Text.Trim(), txtbatchremain.Text.Trim(), txtTheorotical.Text.Trim(), txtTheorotical2.Text.Trim(), txtTheorotical3.Text.Trim(), txtTheorotical4.Text.Trim(), txtTheorotical5.Text.Trim(), txtTheorotical6.Text.Trim(), txtTheorotical7.Text.Trim(), txtTheorotical8.Text.Trim(), txtTheorotical9.Text.Trim(), txtTheorotical10.Text.Trim(),txtMacro1.Text.Trim(), txtMacro2.Text.Trim(), txtMacro3.Text.Trim(), txtMacro4.Text.Trim(), txtMacro5.Text.Trim(), txtMacro6.Text.Trim(), txtMacro7.Text.Trim(), txtMacro8.Text.Trim(), txtMacro9.Text.Trim(), txtMacro10.Text.Trim(), txtbmx_id.Text.Trim(), txtbmxqtybatch.Text.Trim(), txtactualweight.Text.Trim(), txtmixingdate.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),txtMacro11.Text.Trim(),txtMacro12.Text.Trim(),txtMacro13.Text.Trim(),txtMacro14.Text.Trim(),txtMacro15.Text.Trim(),"add");

                    if (txtbatchremain.Text.Trim() == txtmainbatch.Text.Trim())
                    {
                        //MessageBox.Show("Ready To Stock out");

                        dSet.Clear();

                        dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtproductionid.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", txtdatenow.Text, txtaddedby.Text,txtMacro11.Text,txtMacro12.Text,txtMacro13.Text,txtMacro14.Text,txtMacro15.Text, "productionfinish");
                    }
                    //load_macro_count();
                    SuccessFullyProduction();
                    //load_Schedules();
                    MyQueryforRefresh();
                    CurrentCellofDuplicateSchedules();
                    showValueDailyProduction();
                    load_search();
              
                    return false;
                }

                else
                {
                    dSet.Clear();

                    //buje
                    //dSets = objStorProc.rdf_sp_new_preparation(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), label24.Text.Trim(), txtitemcodeactive.Text.Trim(), txtdescriptionactive.Text.Trim(), txtbatchactive.Text.Trim(), txtqtybactchactive.Text.Trim(), txtsumtotalactive.Text.Trim(), txtcode1.Text.Trim(), txttotalrepack1.Text.Trim(), txt1.Text.Trim(), "1", "2", "1", txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), "", "add");

                    dSets = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text.Trim(), txtfeedtype.Text.Trim(), txtproductionid.Text.Trim(), txtmainbatch.Text.Trim(), txtbatchremain.Text.Trim(), txtTheorotical.Text.Trim(), txtTheorotical2.Text.Trim(), txtTheorotical3.Text.Trim(), txtTheorotical4.Text.Trim(), txtTheorotical5.Text.Trim(), txtTheorotical6.Text.Trim(), txtTheorotical7.Text.Trim(), txtTheorotical8.Text.Trim(), txtTheorotical9.Text.Trim(), txtTheorotical10.Text.Trim(), txtMacro1.Text.Trim(), txtMacro2.Text.Trim(), txtMacro3.Text.Trim(), txtMacro4.Text.Trim(), txtMacro5.Text.Trim(), txtMacro6.Text.Trim(), txtMacro7.Text.Trim(), txtMacro8.Text.Trim(), txtMacro9.Text.Trim(), txtMacro10.Text.Trim(), txtbmx_id.Text.Trim(), txtbmxqtybatch.Text.Trim(), txtactualweight.Text.Trim(), txtmixingdate.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),txtMacro11.Text.Trim(),txtMacro12.Text.Trim(),txtMacro13.Text.Trim(),txtMacro14.Text.Trim(),txtMacro15.Text.Trim(), "add");

                    if (txtbatchremain.Text.Trim() == txtmainbatch.Text.Trim())
                    {
                        //MessageBox.Show("Ready To Stock out");

                        dSet.Clear();

                        dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtproductionid.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", txtdatenow.Text, txtaddedby.Text,txtMacro11.Text,txtMacro12.Text,txtMacro13.Text,txtMacro14.Text,txtMacro15.Text, "productionfinish");
                    }



                    SuccessFullyProduction();
                    //load_Schedules();
                    MyQueryforRefresh();
                    CurrentCellofDuplicateSchedules();
                    showValueDailyProduction();
                    load_search();
                    return true;
                }
            }
            
            else if (mode == "edit")
            {
                dSet.Clear();
                /// dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyname");

                dSet_temp.Clear();
          

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        ///   dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtMainInput.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    ///        dSet = dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit");


                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_supplier(p_id, "", "", "", "", "delete");

                //dSet_temp.Clear();
                //dSet_temp = objStorProc.sp_positions(p_id,0,"","delete");

                return true;
            }


            if (lbltotalprod.Text == "0")
            {

            }
            else
            {
                txtTheorotical.Enabled = true;
                txtTheorotical.Focus();

            }




            return false;



        }

        void ViewDataProduction()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_production_advance] WHERE prod_id= '" + txtproductionid.Text + "' AND is_selected='1' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();





        }





        void QueryTryCatchProdTimes()
        {
            txtdatenowstamp.Text = DateTime.Now.ToString();
            //November 11
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET production_time='" + txtSumofRepacking.Text + "' WHERE prod_id= '" + txtproductionid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();




        }



        private void metrosave_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Save the Production of " + txtmainfeedcode.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                theoroticalOperations();

                mode = "add";
                if (txtmainfeedcode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Select production", "Production Today", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



                            //load_Schedules();
                            //MessageBox.Show("Micro Preparation  SuccesFully Saved !.", "Raw Material Received", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //calling the dashboards!
                            btnsubmit.Visible = false;

                            //button27_Click(sender, e);



                            //   Mainmenu.Refresh();
                            //   this.Close();
                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        /// btnCancel_Click(sender, e);

                    }
                    else
                    {

                    }

         
                    // MessageBox.Show("Failed");
        
                }














                //SuccessFullyProduction();
                //SaveSuccesfull();
                load_TheoMaterials();
            }

            else
            {
                return; // this will return the query here
            }


            if (txtbatchremain.Text.Trim() == txtbatchminus1.Text.Trim())
            {
                txtdatenowstamp.Text = DateTime.Now.ToString();
                //November 11

                dSets.Clear();
                dSets = objStorProc.rdf_sp_new_production(0, txtdatenowstamp.Text.Trim(), txtfeedtype.Text.Trim(), txtproductionid.Text.Trim(), txtmainbatch.Text.Trim(), txtbatchremain.Text.Trim(), txtTheorotical.Text.Trim(), txtTheorotical2.Text.Trim(), txtTheorotical3.Text.Trim(), txtTheorotical4.Text.Trim(), txtTheorotical5.Text.Trim(), txtTheorotical6.Text.Trim(), txtTheorotical7.Text.Trim(), txtTheorotical8.Text.Trim(), txtTheorotical9.Text.Trim(), txtTheorotical10.Text.Trim(), txtMacro1.Text.Trim(), txtMacro2.Text.Trim(), txtMacro3.Text.Trim(), txtMacro4.Text.Trim(), txtMacro5.Text.Trim(), txtMacro6.Text.Trim(), txtMacro7.Text.Trim(), txtMacro8.Text.Trim(), txtMacro9.Text.Trim(), txtMacro10.Text.Trim(), txtbmx_id.Text.Trim(), txtbmxqtybatch.Text.Trim(), txtactualweight.Text.Trim(), txtmixingdate.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(),txtMacro11.Text.Trim(),txtMacro12.Text.Trim(),txtMacro13.Text.Trim(),txtMacro14.Text.Trim(),txtMacro15.Text.Trim(), "endProduction");


                //3 query function james foul
                ViewDataProduction();
                ViewCellChanger();

                QueryTryCatchProdTimes();

                //4 additonal
                dSet = objStorProc.rdf_sp_new_preparation(0, txtmainfeedcode.Text, txtaddedby.Text, "6.1 Production Module", "Production of Raw Materials", txtdatenowstamp.Text, txtproductionid.Text, txtmainbatch.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");




                frmProductionEntry_Load(sender, e);
            }
            else
            {
                btnValidate1.Visible = true;
                lblvalidateTheo.Text = "0";
                lblvalidatecount.Text = "0";
                lblmain5.Visible = false;
                    lblmain6.Visible = false;
                txtTheorotical.Enabled = true;
                txtTheorotical.Focus();
            }
      
            txtquantity0.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
            checkEntry();
            lblactualweightinfo.Visible = false;
            btnsubmit.Visible = false;
            load_TheoMaterials();
            bunifuStart.Visible = true;
            btngreaterthan.Visible = true;
            btnlessthan.Visible = true;
            ControlBox = true;
            txtitemcodemacro2.Text = "";

            txtitemcodemacro3.Text = "";
            txtitemcodemacro4.Text = "";
            txtitemcodemacro5.Text = "";
            txtitemcodemacro6.Text = "";
            txtitemcodemacro7.Text = "";
            txtitemcodemacro8.Text = "";
            txtitemcodemacro9.Text = "";

            txtitemcodemacro10.Text = "";
            txtitemcodemacro11.Text = "";
            txtitemcodemacro12.Text = "";
            txtitemcodemacro13.Text = "";
            txtitemcodemacro14.Text = "";
            txtitemcodemacro15.Text = "";

            txtquantitymacro2.Text = "";
            txtquantitymacro3.Text = "";

            txtquantitymacro4.Text = "";
            txtquantitymacro5.Text = "";
            txtquantitymacro6.Text = "";
            txtquantitymacro7.Text = "";
            txtquantitymacro8.Text = "";
            txtquantitymacro9.Text = "";
            txtquantitymacro10.Text = "";
            txtquantitymacro11.Text = "";
            txtquantitymacro12.Text = "";
            txtquantitymacro13.Text = "";
            txtquantitymacro14.Text = "";
            txtquantitymacro15.Text = "";

            txtitemcode2.Text = "";
            txtitemcode3.Text = "";
            txtitemcode4.Text = "";
            txtitemcode5.Text = "";
            txtitemcode6.Text = "";
            txtitemcode7.Text = "";
            txtitemcode8.Text = "";
            txtitemcode9.Text = "";
            txtitemcode10.Text = "";

            txtquantity2.Text = "";
            txtquantity3.Text = "";
            txtquantity4.Text = "";
            txtquantity5.Text = "";
            txtquantity6.Text = "";
            txtquantity7.Text = "";
            txtquantity8.Text = "";

            txtquantity9.Text = "";
            txtquantity10.Text = "";

            txtSolutions.Text = "";
            txtvariance.Text = "";
            txtSumofReserved.Text = "";






            txtactualweight.Text = "";
            HideControlls();//lara citu
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            metrosave_Click(sender, e);
        }







        private void txtMacroMatic_TextChanged(object sender, EventArgs e)
        {
            doRepackingEntry();
        }

        private void dataGridView6_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueRepack();
        }


        void showValueRepack()
        {

            if (dataGridView6.RowCount > 0)
            {
                if (dataGridView6.CurrentRow != null)
                {
                    if (dataGridView6.CurrentRow.Cells["rp_item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtrp_item_code.Text = dataGridView6.CurrentRow.Cells["rp_item_code"].Value.ToString();


                        //my_item_code.Text = dataGridView6.CurrentRow.Cells["rp_item_code"].Value.ToString();


                        txttotal_repack.Text = dataGridView6.CurrentRow.Cells["total_repack"].Value.ToString();
                       txtfeedcodechecking.Text = dataGridView6.CurrentRow.Cells["rp_feed_code"].Value.ToString();

                    }

                }
            }

        }

        void showValueRepack2()
        {

            if (dataGridView8.RowCount > 0)
            {
                if (dataGridView8.CurrentRow != null)
                {
                    if (dataGridView8.CurrentRow.Cells["rp_item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

 


                        my_item_code.Text = dataGridView8.CurrentRow.Cells["rp_item_code"].Value.ToString();
                        txtfeedchecklist.Text = dataGridView8.CurrentRow.Cells["rp_feed_code"].Value.ToString().ToUpper();


                    }

                }
            }

        }

        private void dataGridView7_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView7.RowCount > 0)
            {
                if (dataGridView7.CurrentRow != null)
                {
                    if (dataGridView7.CurrentRow.Cells["item_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtItemCode.Text = dataGridView7.CurrentRow.Cells["item_code"].Value.ToString();

                        txtRepackAvailable.Text = dataGridView7.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        txtQtyProductionReserved.Text = dataGridView7.CurrentRow.Cells["qty_production"].Value.ToString();

                    }

                }
            }
        }

        private void txtitemcode0_TextChanged(object sender, EventArgs e)
        {


    
        }

        private void bunifuMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Data will not be save, are you sure you want to Exit ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

                return;
            }
        }

        private void bunifuStart_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
        }

        private void txtTheorotical_Click(object sender, EventArgs e)
        {
            load_TheoMaterials();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Start();
            if(lbltotalprod.Text=="0")
            {
                load_Schedules();
            }
            else
            {

                txtTheorotical.Visible = true;
                //txtTheorotical.Enabled = true;
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;

                dataView.Visible = true;
                lbltotalprod.Visible = true;
                label1.Visible = true;


                lblmain1.Visible = true;
                lblmain2.Visible = true;
                lblmain3.Visible = true;
                lblmain4.Visible = true;

                //lblmain6.Visible = true;
                lblmain7.Visible = true;
                lblmain8.Visible = true;
                txtbatchremain.Visible = true;
                txtmainbatch.Visible = true;
                txtbatch.Text = "";
                timer1.Stop();

                txtTheorotical.Select();
                txtTheorotical.Focus();

            }
        }

        private void btnValidate1_Click(object sender, EventArgs e)
        {


            if (txtTheorotical.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical.Select();
                txtTheorotical.Focus();
                txtTheorotical.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical.Text);
            //lower = double.Parse(txtquantity1.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical.Text = "";
            //    txtTheorotical.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity1.Text}  over { txtTheorotical.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical.Text = "";
                    txtTheorotical.Focus();
                    return;
                }



             //}


















            // double subjectquantity;
            // double sagot;

            // subjectquantity = double.Parse(txtquantity1.Text);
            // sagot = subjectquantity * 1;
            //txtTheorotical.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton210_Click(sender, e);
            lblvalidateTheo.Text = "1";
            checkingofTheoMaterials();
            txtTheorotical2.Visible = true;
           
            btnValidate1.Visible = false;

            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                //    txtTheorotical3.Visible = false;
                //    btnValidate3.Visible = false;
                //return;
            }
            else
            {
                //txtTheorotical3.Visible = true;
                txtTheorotical2.Enabled = true;
                txtTheorotical2.Focus();
            }

        }

        private void btnValidate2_Click(object sender, EventArgs e)
        {


            if (txtTheorotical2.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical2.Select();
                txtTheorotical2.Focus();
                txtTheorotical2.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical2.Text);
            //lower = double.Parse(txtquantity2.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical2.Text = "";
            //    txtTheorotical2.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity2.Text}  over { txtTheorotical2.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical2.Text = "";
                    txtTheorotical2.Focus();
                    return;
                }



            //}







            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity2.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical2.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton29_Click(sender, e);
            lblvalidateTheo.Text = "2";
            checkingofTheoMaterials();

            btnValidate2.Visible = false;

            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                txtTheorotical3.Visible = false;
                btnValidate3.Visible = false;
                //return;
            }
            else
            {
                txtTheorotical3.Visible = true;
                txtTheorotical3.Enabled = true;
                txtTheorotical3.Focus();
            }

        }

        private void btnValidate3_Click(object sender, EventArgs e)
        {



            if (txtTheorotical3.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical3.Select();
                txtTheorotical3.Focus();
                txtTheorotical3.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical3.Text);
            //lower = double.Parse(txtquantity3.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical3.Text = "";
            //    txtTheorotical3.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity3.Text}  over { txtTheorotical3.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical3.Text = "";
                    txtTheorotical3.Focus();
                    return;
                }



            //}


            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity3.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical3.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton28_Click(sender, e);
            lblvalidateTheo.Text = "3";
            checkingofTheoMaterials();
 
            btnValidate3.Visible = false;
            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                txtTheorotical4.Visible = false;
                btnValidate4.Visible = false;
                //return;
            }
            else
            {
                txtTheorotical4.Visible = true;
                txtTheorotical4.Enabled = true;
                txtTheorotical4.Focus();
            }

        }

        private void btnValidate5_Click(object sender, EventArgs e)
        {
            if (txtTheorotical5.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical5.Select();
                txtTheorotical5.Focus();
                txtTheorotical5.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical5.Text);
            //lower = double.Parse(txtquantity5.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical5.Text = "";
            //    txtTheorotical5.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity5.Text}  over { txtTheorotical5.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical5.Text = "";
                    txtTheorotical5.Focus();
                    return;
                }



            //}




            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity5.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical5.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton26_Click(sender, e);
            lblvalidateTheo.Text = "5";
            checkingofTheoMaterials();

            btnValidate5.Visible = false;
            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                txtTheorotical6.Visible = false;
                btnValidate6.Visible = false;
                //return;
            }
            else
            {
                txtTheorotical6.Visible = true;
                txtTheorotical6.Enabled = true;
                txtTheorotical6.Focus();
            }
        }

        private void btnValidate4_Click(object sender, EventArgs e)
        {

            if (txtTheorotical4.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical4.Select();
                txtTheorotical4.Focus();
                txtTheorotical4.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical4.Text);
            //lower = double.Parse(txtquantity4.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical4.Text = "";
            //    txtTheorotical4.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity4.Text}  over { txtTheorotical4.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical4.Text = "";
                    txtTheorotical4.Focus();
                    return;
                }



            //}

            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity4.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical4.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton27_Click(sender, e);
            lblvalidateTheo.Text = "4";
            checkingofTheoMaterials();
            btnValidate4.Visible = false;

            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                txtTheorotical5.Visible = false;
                btnValidate5.Visible = false;
                //return;
            }
            else
            {
                txtTheorotical5.Visible = true;
                txtTheorotical5.Enabled = true;
                txtTheorotical5.Focus();
            }
        }

        private void btnValidate6_Click(object sender, EventArgs e)
        {

            if (txtTheorotical6.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical6.Select();
                txtTheorotical6.Focus();
                txtTheorotical6.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical6.Text);
            //lower = double.Parse(txtquantity6.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical6.Text = "";
            //    txtTheorotical6.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity6.Text}  over { txtTheorotical6.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical6.Text = "";
                    txtTheorotical6.Focus();
                    return;
                }



            //}


            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity6.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical6.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton25_Click(sender, e);
            lblvalidateTheo.Text = "6";
            checkingofTheoMaterials();
 
            btnValidate6.Visible = false;

            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                txtTheorotical7.Visible = false;
                btnValidate7.Visible = false;
                //return;
            }
            else
            {
                txtTheorotical7.Visible = true;
                txtTheorotical7.Enabled = true;
                txtTheorotical7.Focus();
            }
        }

        private void btnValidate7_Click(object sender, EventArgs e)
        {

            if (txtTheorotical7.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical7.Select();
                txtTheorotical7.Focus();
                txtTheorotical7.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical7.Text);
            //lower = double.Parse(txtquantity7.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical7.Text = "";
            //    txtTheorotical7.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity7.Text}  over { txtTheorotical7.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical7.Text = "";
                    txtTheorotical7.Focus();
                    return;
                }



            //}


            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity7.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical7.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton24_Click(sender, e);
            lblvalidateTheo.Text = "7";
            checkingofTheoMaterials();
   
            btnValidate7.Visible = false;
            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                txtTheorotical8.Visible = false;
                btnValidate8.Visible = false;
                //return;
            }
            else
            {
                txtTheorotical8.Visible = true;
                txtTheorotical8.Enabled = true;
                txtTheorotical8.Focus();
            }
        }

        private void btnValidate8_Click(object sender, EventArgs e)
        {
            if (txtTheorotical8.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical8.Select();
                txtTheorotical8.Focus();
                txtTheorotical8.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical8.Text);
            //lower = double.Parse(txtquantity8.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical8.Text = "";
            //    txtTheorotical8.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity8.Text}  over { txtTheorotical8.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical8.Text = "";
                    txtTheorotical8.Focus();
                    return;
                }



            //}

            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity8.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical8.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton23_Click(sender, e);
            lblvalidateTheo.Text = "8";
            checkingofTheoMaterials();

            btnValidate8.Visible = false;
            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                txtTheorotical9.Visible = false;
                btnValidate9.Visible = false;
                //return;
            }
            else
            {
                txtTheorotical9.Visible = true;
                txtTheorotical9.Enabled = true;
                txtTheorotical9.Focus();
            }
        }

        private void btnValidate9_Click(object sender, EventArgs e)
        {

            if (txtTheorotical9.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical9.Select();
                txtTheorotical9.Focus();
                txtTheorotical9.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical9.Text);
            //lower = double.Parse(txtquantity9.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical9.Text = "";
            //    txtTheorotical9.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity9.Text}  over { txtTheorotical9.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical9.Text = "";
                    txtTheorotical9.Focus();
                    return;
                }



            //}

            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity9.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical9.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton22_Click(sender, e);
            lblvalidateTheo.Text = "9";
            checkingofTheoMaterials();

            btnValidate9.Visible = false;
            if (lblTheoCounts.Text.Trim() == lblvalidateTheo.Text.Trim())
            {
                txtTheorotical10.Visible = false;
                btnValidate10.Visible = false;
                //return;
            }
            else
            {
                txtTheorotical10.Visible = true;
                txtTheorotical10.Enabled = true;
                txtTheorotical10.Focus();
            }
        }

        private void btnValidate10_Click(object sender, EventArgs e)
        {
            if (txtTheorotical10.Text.Trim() == string.Empty)
            {


                FillEmptyFields();
                txtTheorotical10.Select();
                txtTheorotical10.Focus();
                txtTheorotical10.BackColor = Color.Yellow;


                return;
            }

            //double higher;
            //double lower;

            //higher = double.Parse(txtTheorotical10.Text);
            //lower = double.Parse(txtquantity10.Text);
            //if (higher < lower)
            //{
            //    LessThanActuaLNeeded();
            //    txtTheorotical10.Text = "";
            //    txtTheorotical10.Focus();
            //    return;
            //}
            //else
            //{

                if (MetroFramework.MetroMessageBox.Show(this, $"Validate the Theorotical {txtdes.Text}   { txtquantity10.Text}  over { txtTheorotical10.Text} ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                }
                else
                {
                    txtTheorotical10.Text = "";
                    txtTheorotical10.Focus();
                    return;
                }



            //}



            //double subjectquantity;
            //double sagot;

            //subjectquantity = double.Parse(txtquantity10.Text);
            //sagot = subjectquantity * 1;
            //txtTheorotical10.Text = Convert.ToString(sagot);

            //click the button
            bunifuThinButton21_Click(sender, e);
            lblvalidateTheo.Text = "10";
            checkingofTheoMaterials();
            //txtTheorotical4.Visible = true;
            //txtTheorotical4.Enabled = false;
            btnValidate10.Visible = false;
        }

        private void btnnextline_Click(object sender, EventArgs e)
        {

  

            if (txtvalidate1.Text.Trim() == string.Empty)
            {

                txtvalidate1.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                txtvalidate2.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                //txtMacro.Visible = true;
                //txtMacro.Text = "sample";
            }



            //if (txtMacro4.Text.Trim() == string.Empty)
            //{

            //    txtitemcodemacro4.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
            //    txtquantitymacro4.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
            //}

            if (dataGridView2.Rows.Count >= 1)
            {


                int i = dataGridView2.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView2.Rows.Count)
                    dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);
                else
                {

                    //MessageBox.Show("Last Line kana!");
                    this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[this.dataGridView2.CurrentCell.ColumnIndex];
                    return;
                }
            }




            //if (txtitemcodemacro4.Text.Trim() == string.Empty)
            //{
            //    if (txtMacro4.Text.Trim() == string.Empty)

            //    {
            //        txtitemcodemacro4.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
            //        txtquantitymacro4.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

            //    }
            //}







            if (txtitemcodemacro2.Text.Trim() == string.Empty)
            {
                if (txtMacro2.Text.Trim() == string.Empty)

                {
                    txtitemcodemacro2.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                    txtquantitymacro2.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                }
            }



            if (txtitemcodemacro3.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro4.Text.Trim() == string.Empty)
                {
                    if (txtMacro4.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro4.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro4.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }



            if (txtitemcodemacro5.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro6.Text.Trim() == string.Empty)
                {
                    if (txtMacro6.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro6.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro6.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }

            //if (txtMacro5.Text.Trim() == string.Empty)

            //{
            //    txtitemcodemacro5.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
            //    txtquantitymacro5.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

            //}


            if (txtitemcodemacro7.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro8.Text.Trim() == string.Empty)
                {
                    if (txtMacro8.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro8.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro8.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }


            //if (txtitemcodemacro9.Text.Trim() == string.Empty)
            //{

            //}
            //else
            //{

            //    if (txtitemcodemacro10.Text.Trim() == string.Empty)
            //    {
            //        if (txtMacro10.Text.Trim() == string.Empty)

            //        {
            //            txtitemcodemacro10.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
            //            txtquantitymacro10.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

            //        }
            //    }


            //}


            if (txtitemcodemacro9.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro10.Text.Trim() == string.Empty)
                {
                    if (txtMacro10.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro10.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro10.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }



            if (txtitemcodemacro11.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro12.Text.Trim() == string.Empty)
                {
                    if (txtMacro12.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro12.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro12.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }



            if (txtitemcodemacro13.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro14.Text.Trim() == string.Empty)
                {
                    if (txtMacro14.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro14.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro14.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }






            btnnext2_Click(sender, e);


        }

        void checkData()
        {

            if (txtitemcodemacro2.Text.Trim() == string.Empty)
            {
                if (txtMacro2.Text.Trim() == string.Empty)

                {
                    txtitemcodemacro2.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                    txtquantitymacro2.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                }
            }


            if (txtitemcodemacro3.Text.Trim() == string.Empty)
            {
                if (txtMacro3.Text.Trim() == string.Empty)

                {
                    txtitemcodemacro3.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                    txtquantitymacro3.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                }
            }



            if (txtitemcodemacro4.Text.Trim() == string.Empty)
            {
                if (txtMacro4.Text.Trim() == string.Empty)

                {
                    txtitemcodemacro4.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                    txtquantitymacro4.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                }
            }





            if (txtitemcodemacro5.Text.Trim() == string.Empty)
            {
                if (txtMacro5.Text.Trim() == string.Empty)

                {
                    txtitemcodemacro5.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                    txtquantitymacro5.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                }
            }


            if (txtitemcodemacro6.Text.Trim() == string.Empty)
            {
                if (txtMacro6.Text.Trim() == string.Empty)

                {
                    txtitemcodemacro6.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                    txtquantitymacro.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                }
            }


        }

        private void btnnext2_Click(object sender, EventArgs e)
        {

            if (dataGridView2.Rows.Count >= 1)
            {


                int i = dataGridView2.CurrentRow.Index + 1;
                if (i >= -1 && i < dataGridView2.Rows.Count)
                    dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);
                else
                {

                    //MessageBox.Show("Last Line kana!");
                    this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[this.dataGridView2.CurrentCell.ColumnIndex];
                    return;
                }
            }


            if (txtitemcodemacro3.Text.Trim() == string.Empty)
            {
                if (txtMacro3.Text.Trim() == string.Empty)

                {
                    txtitemcodemacro3.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                    txtquantitymacro3.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                }
            }


            //if (txtitemcodemacro5.Text.Trim() == string.Empty)
            //{
            //    if (txtMacro5.Text.Trim() == string.Empty)

            //    {
            //        txtitemcodemacro5.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
            //        txtquantitymacro5.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

            //    }
            //}


            //if (txtitemcodemacro4.Text.Trim() == string.Empty)
            //{
            //    if (txtMacro4.Text.Trim() == string.Empty)

            //    {
            //        txtitemcodemacro4.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
            //        txtquantitymacro4.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

            //    }
            //}
            if (txtitemcodemacro4.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro5.Text.Trim() == string.Empty)
                {
                    if (txtMacro5.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro5.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro5.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }

            if (txtitemcodemacro6.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro7.Text.Trim() == string.Empty)
                {
                    if (txtMacro7.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro7.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro7.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }


            if (txtitemcodemacro8.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro9.Text.Trim() == string.Empty)
                {
                    if (txtMacro9.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro9.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro9.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }


            if (txtitemcodemacro10.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro11.Text.Trim() == string.Empty)
                {
                    if (txtMacro11.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro11.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro11.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }


            if (txtitemcodemacro12.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro13.Text.Trim() == string.Empty)
                {
                    if (txtMacro13.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro13.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro13.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }





            if (txtitemcodemacro14.Text.Trim() == string.Empty)
            {

            }
            else
            {

                if (txtitemcodemacro15.Text.Trim() == string.Empty)
                {
                    if (txtMacro15.Text.Trim() == string.Empty)

                    {
                        txtitemcodemacro15.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                        txtquantitymacro15.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();

                    }
                }


            }




            btnnextline_Click(sender, e);

        }

        void CheckIfNull()
        {
            if (txtMacro.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
            }



            if (txtvalidate1.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
            }
            if (txtMacro2.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
            }

            if (txtMacro3.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
            }

            if (txtMacro4.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
            }

            if (txtMacro5.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
            }

            if (txtMacro6.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
            }


        }
        void ValidateProd()
        {
            //hindi man nagagamit
            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit2");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit3");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}
            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit4");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit5");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit6");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit7");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit8");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit9");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}

            //dSet.Clear();

            //dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", "exit10");
            //if (dSet.Tables[0].Rows.Count > 0)
            //{

            //    ProductIDExists();
            //    txtScanner.Text = "";
            //    txtScanner.Focus();
            //    return;
            //}



        }
        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
      
            if(txtScanner.Text.Trim() == string.Empty)
            {

                FillRequiredField();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }



            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "",txtScanner.Text,txtScanner.Text,txtScanner.Text,txtScanner.Text,txtScanner.Text, "exit");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit2");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit3");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit4");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit5");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit6");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit7");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit8");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit9");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit10");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            //11

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit11");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }


            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit12");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }


            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit13");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit14");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            //15
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit15");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            //ValidateProd();

            //checking kung na repack ba ito barcode na 
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "checkrepackingid");
            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("tama");
                //return;
            }
            else
            {
                RepackIDExists();
                //MessageBox.Show("Libag");
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }


            dset_emp8 = objStorProc.sp_getMajorTables("repackingEntry");

            doRepackingEntry2();
            showValueRepack2();

            //if (txtmainfeedcode.Text.Trim() == txtfeedcodechecking.Text.Trim())
            if (txtmainfeedcode.Text.Trim() == txtfeedchecklist.Text.Trim())
            {

            }
            else
            {

                FeedCodeNotMatched();//susu
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }



 










            //dset_emp8 = objStorProc.sp_getMajorTables("repackingEntry");
            //doRepackingEntry2();
            //showValueRepack2();

            //CheckIfNull();
            if (my_item_code.Text.Trim() == txtvalidate1.Text.Trim())
            {

                if (txtMacro.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;

                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;
         

                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro.Text = Convert.ToString(sagot);


                    btnMacro_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();

            

                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }
            else if (my_item_code.Text.Trim() == txtitemcodemacro2.Text.Trim())
            {
                if (txtMacro2.Text.Trim() == string.Empty)
                {

                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;
           




                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro2.Text = Convert.ToString(sagot);




                    btnMacro2_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro2.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
         
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }
            else if (my_item_code.Text.Trim() == txtitemcodemacro3.Text.Trim())
            {
                if (txtMacro3.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;


                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro3.Text = Convert.ToString(sagot);






                    btnMacro3_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro3.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }

            else if (my_item_code.Text.Trim() == txtitemcodemacro4.Text.Trim())
            {
                if (txtMacro4.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;
        

                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro4.Text = Convert.ToString(sagot);



                    btnMacro4_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro4.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }

            else if (my_item_code.Text.Trim() == txtitemcodemacro5.Text.Trim())
            {

                if (txtMacro5.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;

                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro5.Text = Convert.ToString(sagot);



                    btnMacro5_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro5.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();

                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }

            else if (my_item_code.Text.Trim() == txtitemcodemacro6.Text.Trim())
            {

                if (txtMacro6.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;


                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro6.Text = Convert.ToString(sagot);



                    btnMacro6_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro6.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {

                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }

            else if (my_item_code.Text.Trim() == txtitemcodemacro7.Text.Trim())
            {
                if (txtMacro7.Text.Trim() == string.Empty)
                {



                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;
      
                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro7.Text = Convert.ToString(sagot);



                    btnMacro7_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro7.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }


            else if (my_item_code.Text.Trim() == txtitemcodemacro8.Text.Trim())
            {

                if (txtMacro8.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;


                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro8.Text = Convert.ToString(sagot);



                    btnMacro8_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro8.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }

            else if (my_item_code.Text.Trim() == txtitemcodemacro9.Text.Trim())
            {

                if (txtMacro9.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;
 

                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro9.Text = Convert.ToString(sagot);



                    btnMacro9_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro9.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
            }

            else if (my_item_code.Text.Trim() == txtitemcodemacro10.Text.Trim())
            {

                if (txtMacro10.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;
   

                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro10.Text = Convert.ToString(sagot);



                    btnMacro10_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro10.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {
            
                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }
             
            }

            //11

            else if (my_item_code.Text.Trim() == txtitemcodemacro11.Text.Trim())
            {

                if (txtMacro11.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;


                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro11.Text = Convert.ToString(sagot);



                    btnMacro11_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro11.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }

            }


            else if (my_item_code.Text.Trim() == txtitemcodemacro12.Text.Trim())
            {

                if (txtMacro12.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;


                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro11.Text = Convert.ToString(sagot);



                    btnMacro12_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro12.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }

            }


            //13

            else if (my_item_code.Text.Trim() == txtitemcodemacro13.Text.Trim())
            {

                if (txtMacro13.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;


                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro13.Text = Convert.ToString(sagot);



                    btnMacro13_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro13.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }

            }
            //14

            else if (my_item_code.Text.Trim() == txtitemcodemacro14.Text.Trim())
            {

                if (txtMacro14.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;


                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro14.Text = Convert.ToString(sagot);



                    btnMacro14_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro14.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }

            }


            else if (my_item_code.Text.Trim() == txtitemcodemacro15.Text.Trim())
            {

                if (txtMacro15.Text.Trim() == string.Empty)
                {


                    double subjectquantity;
                    double sagot;
                    double validate;
                    double validatecount;

                    validate = double.Parse(lblvalidatecount.Text);
                    validatecount = validate + 1;


                    subjectquantity = double.Parse(txtScanner.Text);
                    sagot = subjectquantity * 1;
                    txtMacro15.Text = Convert.ToString(sagot);



                    btnMacro15_Click(sender, e);
                    lblvalidatecount.Text = Convert.ToString(validatecount);
                    txtMacro15.Visible = true;
                    txtScanner.Text = "";
                    txtScanner.Focus();
                    if (lblmacrovalidatecount.Text.Trim() == lblmacrovalidatecount.Text.Trim())
                    {

                    }
                    else
                    {
                        txtScanner.Visible = false;
                    }
                }
                else
                {
                    ItemAlreadySwiped();
                    txtScanner.Text = "";
                    txtScanner.Focus();
                }

            }

            else
            {
                RepackIDExists2();
                //MessageBox.Show("Takla");
                txtScanner.Text = "";
                txtScanner.Focus();
                return;

            }
         



        }

        private void txtScanner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

  
            bunifuThinButton211_Click(sender, e);

            }


            }

        private void txtScanner_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblvalidatecount_Click(object sender, EventArgs e)
        {

     
        }

        private void lblvalidatecount_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lblmacrovalidatecount.Text + " " + lblvalidatecount.Text);
            if (int.Parse(lblmacrovalidatecount.Text) == int.Parse(lblvalidatecount.Text))
            {
                //MessageBox.Show("Equal");
                txtScanner.Visible = false;
                lblscanthebarcode.Visible = false;



                lblvalidatecount.Visible = false;
                lblmacrocount.Visible = false;


                SuccessFullyValidateMacroValidate();
                txtbmx.Visible = true;
                txtbmx.Select();
                txtbmx.Focus();
            }
            else
            {

            }

            if(txtTheorotical10.Text.Trim() ==string.Empty)
            {
                txtTheorotical10.Visible = false;
            }
            if (txtTheorotical9.Text.Trim() == string.Empty)
            {
                txtTheorotical9.Visible = false;
            }
            if (txtTheorotical8.Text.Trim() == string.Empty)
            {
                txtTheorotical8.Visible = false;
            }
            if (txtTheorotical7.Text.Trim() == string.Empty)
            {
                txtTheorotical7.Visible = false;
            }
            if (txtTheorotical6.Text.Trim() == string.Empty)
            {
                txtTheorotical6.Visible = false;
            }
            if (txtTheorotical5.Text.Trim() == string.Empty)
            {
                txtTheorotical5.Visible = false;
            }
            if (txtTheorotical4.Text.Trim() == string.Empty)
            {
                txtTheorotical4.Visible = false;
            }
            if (txtTheorotical3.Text.Trim() == string.Empty)
            {
                txtTheorotical3.Visible = false;
            }
            if (txtTheorotical2.Text.Trim() == string.Empty)
            {
                txtTheorotical2.Visible = false;
            }
            if (txtTheorotical.Text.Trim() == string.Empty)
            {
                txtTheorotical.Visible = false;
            }
        }

        private void txtScanner_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {

            //if (txtbatchremain.Text.Trim() == txtmainbatch.Text.Trim())
            //{

            //}
            //else
            //{
            //    ProdFirst();
            //    return;
            //}

            //if (txtbatchremain.Text.Trim() == txtbatchminus1.Text.Trim())
            //{

            //}
            //else
            //{
            //    ProdFirst();
            //    return;
            //}



            //if(txtbatchremain.Text.Trim() == txtmainbatch.Text.Trim())
            //{

            //}
            //else
            //{
            //    ProdFirst();
            //    return;
            //}

            //metroNext_Click(sender, e);

        }





        void ProdFirst()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "Complete the Transcation process of "+txtmainfeedcode.Text+" before proceed in to the next feedtype";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }










        void FirstLine()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "YOU ARE ALREADY IN THE FIRST LINE";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void LastLine()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "YOU ARE ALREADY IN THE LAST LINE";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void LessThanActuaLNeeded()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "Less Than Actual Needed !";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }






        void InvalidControlNumber()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "INVALID CONTROL NUMBER";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        private void btngreaterthan_Click(object sender, EventArgs e)
        {

            //if (txtbatchremain.Text == "1")
            //{

            //}

            //else
            //{

            //    if (txtbatchremain.Text.Trim() == txtmainbatch.Text.Trim())
            //    {

            //    }
            //    else
            //    {
            //        ProdFirst();
            //        return;
            //    }

            //    if (txtbatchremain.Text.Trim() == txtbatchminus1.Text.Trim())
            //    {

            //    }
            //    else
            //    {
            //        ProdFirst();
            //        return;
            //    }
            //}








            int prev = this.dataView.CurrentRow.Index - 1;
            if (prev >= 0)
            {

                this.dataView.CurrentCell = this.dataView.Rows[prev].Cells[this.dataView.CurrentCell.ColumnIndex];
                //dgvMaster_Click(sender, e);
            }
            else
            {
                FirstLine();
                return;
            }
            showValueDailyProduction();
            myglobal.global_module = "Active";
            load_search();

            showValueTheorotical();


            if (lbltotalprod.Text == "0")
            {

            }
            else
            {
                txtitemcodemacro1.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                txtquantitymacro1.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                txtitemcode1.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                txtquantity1.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                lblvalidatecount.Text = "0";
                txtTheorotical.Enabled = true;
            }
            txtactualweight.Text = "";
            HideControlls();
            checkEntry();
            load_TheoMaterials();
            checkingofTheoMaterials();
            txtTheorotical.Focus();
            //txtTheorotical.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        void CallNextLine()


        {

            if (dataView.Rows.Count >= 1)
            {


                int i = dataView.CurrentRow.Index + 1;
                if (i >= -1 && i < dataView.Rows.Count)
                    dataView.CurrentCell = dataView.Rows[i].Cells[1];




                //dgvMaster_Click(sender,e);
                else
                {
                    LastLine();
                    return;

                }

            }


            showValueDailyProduction();
            myglobal.global_module = "Active";
            load_search();
            showValueTheorotical();


            if (lbltotalprod.Text == "0")
            {

            }
            else
            {
                txtTheorotical.Enabled = true;

                txtitemcodemacro1.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                txtquantitymacro1.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                txtitemcode1.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                txtquantity1.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                lblvalidatecount.Text = "0";
            }
            txtactualweight.Text = "";
            HideControlls();
            checkEntry();
            load_TheoMaterials();
            checkingofTheoMaterials();
            txtTheorotical.Focus();


        }


        private void btnValidate_Click(object sender, EventArgs e)
        {
            if(txtControlNumber.Text.Trim()==string.Empty)
            {
                FillEmptyFields();
                txtControlNumber.Focus();
                return;
            }

            if (txtControlNumber.Text == "787898")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";





                CallNextLine();






            }
            else if (txtControlNumber.Text == "787899")
            {

                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                CallNextLine();
            }

            else if (txtControlNumber.Text == "787420")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                CallNextLine();
            }

            else
            {
                InvalidControlNumber();
                txtControlNumber.Text = "";
                txtControlNumber.Focus();
                return;
            }
        }



        void storedProcCntrNumber()
        {

            txtdatenowstamp.Text = DateTime.Now.ToString("M/d/yyyy");
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, "Next Production Entry", txtControlNumber.Text, "PRODUCTION", txtaddedby.Text, txtdatenowstamp.Text, "", "", "", "", "", "", "", "", "", "", "", "", "addcontrolnumberlogs");

        }







        private void metroNext_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Select another Production ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                panelCode.Visible = true;
                txtControlNumber.Focus();
     











            }
            else
            {
                panelCode.Visible = false;
                return;
            }



            }

        private void txtScanner_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                // Here: user pressed ENTER key
                bunifuThinButton211_Click(sender, e);
            }
        }

        private void txtbmx_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                bntSave_Click(sender, e);
            }


            }

        private void txtControlNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                //bn(sender, e);
            }

        }

        private void txtControlNumber_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
              btnValidate_Click(sender, e);
            }
        }

        private void btnlessthan_MouseClick(object sender, MouseEventArgs e)
        {
            //if (txtbatchremain.Text == "1")
            //{
                metroNext_Click(sender, e);
            //}
            //else
            //{
            //    if (txtbatchremain.Text.Trim() == txtmainbatch.Text.Trim())
            //    {

            //    }
            //    else
            //    {
            //        ProdFirst();
            //        return;
            //    }

            //    if (txtbatchremain.Text.Trim() == txtbatchminus1.Text.Trim())
            //    {

            //    }
            //    else
            //    {
            //        ProdFirst();
            //        return;
            //    }


        
            //}
        }

        private void dgvRemoveRefreshRate_CurrentCellChanged(object sender, EventArgs e)
        {
            CurrentCellofDuplicateSchedules();
        }





        public void FindTheoMaterials1()
        {

            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode1.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }






        }


        public void FindTheoMaterials2()
        {


            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode2.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }



        }


        public void FindTheoMaterials3()
        {

            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode3.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }




        }



        public void FindTheoMaterials4()
        {

            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode4.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }




        }


        public void FindTheoMaterials5()
        {


            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode5.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }



        }


        public void FindTheoMaterials6()
        {

            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode6.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }




        }



        public void FindTheoMaterials7()
        {

            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode7.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }




        }



        public void FindTheoMaterials8()
        {

            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode8.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }




        }



        public void FindTheoMaterials9()
        {

            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode9.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }




        }




        public void FindTheoMaterials10()
        {

            dset_emp9.Clear();

            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");

            try
            {
                if (dset_emp9.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp9.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "item_code like '%" + txtitemcode10.Text + "%'  ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView7.DataSource = dv;

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmainfeedcode.Focus();
                return;
            }




        }
        // pek pek

        public void theoroticalOperations()
        {
            //This code is for Theorotical 1 only
            if(txtitemcode1.Text.Trim() == string.Empty)
            {
                // no process

            }
            else
            {

                //load_TheoMaterials();
                FindTheoMaterials1();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                        txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical.Text)).ToString();
                    txtvariance.Text = (float.Parse(txtTheorotical.Text) - float.Parse(txtquantity1.Text)).ToString();
                    txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                    dSet.Clear();


                    dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode1.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode1.Text, txtTheorotical.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity1.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");


          
            }



           if (txtitemcode2.Text.Trim() == string.Empty)
            {


                //No Process

            }
           else
            {

                FindTheoMaterials2();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical2.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical2.Text) - float.Parse(txtquantity2.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode2.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode2.Text, txtTheorotical2.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity2.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");



            }


            if (txtitemcode3.Text.Trim() == string.Empty)
            {


                //No Process

            }
            else
            {


                FindTheoMaterials3();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical3.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical3.Text) - float.Parse(txtquantity3.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode3.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");



                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode3.Text, txtTheorotical3.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity3.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");
            }



            if (txtitemcode4.Text.Trim() == string.Empty)
            {


                //No Process

            }
            else
            {


                FindTheoMaterials4();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical4.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical4.Text) - float.Parse(txtquantity4.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode4.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode4.Text, txtTheorotical4.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity4.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");

            }



            if (txtitemcode5.Text.Trim() == string.Empty)
            {


                //No Process

            }
            else
            {


                FindTheoMaterials5();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical5.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical5.Text) - float.Parse(txtquantity5.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode5.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");



                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode5.Text, txtTheorotical5.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity5.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");
            }



            if (txtitemcode6.Text.Trim() == string.Empty)
            {


                //No Process

            }
            else
            {

                FindTheoMaterials6();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical6.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical6.Text) - float.Parse(txtquantity6.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode6.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode6.Text, txtTheorotical6.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity6.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");
            }



            if (txtitemcode7.Text.Trim() == string.Empty)
            {


                //No Process

            }
            else
            {


                FindTheoMaterials7();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical7.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical7.Text) - float.Parse(txtquantity7.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode7.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode7.Text, txtTheorotical7.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity7.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");
            }



            if (txtitemcode8.Text.Trim() == string.Empty)
            {


                //No Process

            }
            else
            {

                FindTheoMaterials8();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical8.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical8.Text) - float.Parse(txtquantity8.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode8.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode8.Text, txtTheorotical8.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity8.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");

            }




            if (txtitemcode9.Text.Trim() == string.Empty)
            {


                //No Process

            }
            else
            {

                FindTheoMaterials9();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical9.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical9.Text) - float.Parse(txtquantity9.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode9.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");


                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode9.Text, txtTheorotical9.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity9.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");
            }



            if (txtitemcode10.Text.Trim() == string.Empty)
            {


                //No Process

            }
            else
            {

                FindTheoMaterials10();
                dataGridView7_CurrentCellChanged(new object(), new System.EventArgs());


                txtSolutions.Text = (float.Parse(txtRepackAvailable.Text) - float.Parse(txtTheorotical10.Text)).ToString();
                txtvariance.Text = (float.Parse(txtTheorotical10.Text) - float.Parse(txtquantity10.Text)).ToString();
                txtSumofReserved.Text = (float.Parse(txtQtyProductionReserved.Text) - float.Parse(txtvariance.Text)).ToString();

                dSet.Clear();


                dSet = objStorProc.rdf_sp_new_preparation(0, txtSolutions.Text, txtitemcode10.Text, txtSumofReserved.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "UpdateTheoinFG");

                dSet2 = objStorProc.rdf_sp_new_preparation(0, txtproductionid.Text, txtitemcode10.Text, txtTheorotical10.Text, txtbatchremain.Text, txtmainfeedcode.Text, "2", txtaddedby.Text, txtdatenow.Text, txtquantity10.Text, txtvariance.Text, txtProddate.Text, "", "", "", "", "", "", "InsertTheoBoy");

            }




        }








        void CurrentCellofDuplicateSchedules()
        {


      

                if (dgvRemoveRefreshRate.RowCount > 0)
                {
                    if (dgvRemoveRefreshRate.CurrentRow != null)
                    {
                        if (dgvRemoveRefreshRate.CurrentRow.Cells["prod_id"].Value != null)
                        {
                            //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

             
                            txtproductionid.Text = dgvRemoveRefreshRate.CurrentRow.Cells["prod_id"].Value.ToString();

                        }

                    }
                }

        


        }

        private void txtmainbatch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtbatchminus1.Text = (float.Parse(txtmainbatch.Text) + 1).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void txtTheorotical_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }


        private void dataGridView8_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dataView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTheorotical_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate1_Click(sender, e);
            }


        }

        private void txtTheorotical2_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtTheorotical2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate2_Click(sender, e);
            }


        }

        private void txtTheorotical3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate3_Click(sender, e);
            }


        }

        private void txtTheorotical4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate4_Click(sender, e);
            }

        }

        private void txtTheorotical5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate5_Click(sender, e);
            }
        }

        private void txtTheorotical6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate6_Click(sender, e);
            }
        }

        private void txtTheorotical7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate7_Click(sender, e);
            }
        }

        private void txtTheorotical8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate8_Click(sender, e);
            }
        }

        private void txtTheorotical9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate9_Click(sender, e);
            }
        }

        private void txtTheorotical10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate10_Click(sender, e);
            }
        }

        private void dgvUpdateTimeLampse_CurrentCellChanged(object sender, EventArgs e)
        {
            ViewCellChanger();
        }

        void ViewCellChanger()
        {


            if (dgvUpdateTimeLampse.RowCount > 0)
            {
                if (dgvUpdateTimeLampse.CurrentRow != null)
                {
                    if (dgvUpdateTimeLampse.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);

                        txtstartproduction.Text = dgvUpdateTimeLampse.CurrentRow.Cells["start_of_production"].Value.ToString();

                    }

                }
            }

            txtdatenowstamp.Text = DateTime.Now.ToString();


            DateTime time1 = DateTime.Parse(txtstartproduction.Text);
            DateTime time2 = DateTime.Parse(txtdatenowstamp.Text);

            TimeSpan difference = time2 - time1;



            txtSumofRepacking.Text = Convert.ToString(difference);



        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            metrosave_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtControlNumber.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtControlNumber.Focus();
                return;
            }

            if (txtControlNumber.Text == "787898")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";





                CallNextLine();






            }
            else if (txtControlNumber.Text == "787899")
            {

                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                CallNextLine();
            }

            else if (txtControlNumber.Text == "787420")
            {
                panelCode.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                CallNextLine();
            }

            else
            {
                InvalidControlNumber();
                txtControlNumber.Text = "";
                txtControlNumber.Focus();
                return;
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            metroNext_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int prev = this.dataView.CurrentRow.Index - 1;
            if (prev >= 0)
            {

                this.dataView.CurrentCell = this.dataView.Rows[prev].Cells[this.dataView.CurrentCell.ColumnIndex];
                //dgvMaster_Click(sender, e);
            }
            else
            {
                FirstLine();
                return;
            }
            showValueDailyProduction();
            myglobal.global_module = "Active";
            load_search();

            showValueTheorotical();


            if (lbltotalprod.Text == "0")
            {

            }
            else
            {
                txtitemcodemacro1.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                txtquantitymacro1.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
                txtitemcode1.Text = dataGridView1.CurrentRow.Cells["item_code"].Value.ToString();
                txtquantity1.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
                lblvalidatecount.Text = "0";
                txtTheorotical.Enabled = true;
            }
            txtactualweight.Text = "";
            HideControlls();
            checkEntry();
            load_TheoMaterials();
            checkingofTheoMaterials();
            txtTheorotical.Focus();
            //txtTheorotical.Enabled = false;
        }

        private void lblmain8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnMacro11_Click(object sender, EventArgs e)
        {
            if (txtMacro11.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }



            if (txtMacro11.Text.Trim() == string.Empty)
            {

                FillEmptyFields();
                txtMacro11.Select();
                txtMacro11.Focus();
                //txtMacro2.BackColor = Color.Yellow;


                return;
            }
            else
            {






                txtMacro11.Enabled = false;






            }

        }

        private void btnMacro12_Click(object sender, EventArgs e)
        {
            if (txtMacro12.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }



            if (txtMacro12.Text.Trim() == string.Empty)
            {

                FillEmptyFields();
                txtMacro12.Select();
                txtMacro12.Focus();
                //txtMacro2.BackColor = Color.Yellow;


                return;
            }
            else
            {






                txtMacro12.Enabled = false;






            }


        }

        private void btnMacro13_Click(object sender, EventArgs e)
        {

            if (txtMacro13.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }



            if (txtMacro13.Text.Trim() == string.Empty)
            {

                FillEmptyFields();
                txtMacro13.Select();
                txtMacro13.Focus();
                //txtMacro2.BackColor = Color.Yellow;


                return;
            }
            else
            {






                txtMacro13.Enabled = false;






            }


        }

        private void btnMacro14_Click(object sender, EventArgs e)
        {
            if (txtMacro14.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }



            if (txtMacro14.Text.Trim() == string.Empty)
            {

                FillEmptyFields();
                txtMacro14.Select();
                txtMacro14.Focus();
                //txtMacro2.BackColor = Color.Yellow;


                return;
            }
            else
            {






                txtMacro14.Enabled = false;






            }


        }

        private void btnMacro15_Click(object sender, EventArgs e)
        {
            if (txtMacro15.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }



            if (txtMacro15.Text.Trim() == string.Empty)
            {

                FillEmptyFields();
                txtMacro15.Select();
                txtMacro15.Focus();
                //txtMacro2.BackColor = Color.Yellow;


                return;
            }
            else
            {






                txtMacro15.Enabled = false;






            }



        }

        private void txtquantity4_TextChanged(object sender, EventArgs e)
        {

        }

        private void a_TextChanged(object sender, EventArgs e)
        {
            //c.Text = (float.Parse(a.Text) - float.Parse(b.Text)).ToString();
        }

        private void b_TextChanged(object sender, EventArgs e)
        {
            c.Text = (float.Parse(a.Text) - float.Parse(b.Text)).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "checkrepackingid");
            if (dSet.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("tama");
                return;
            }
            else
            {
                RepackIDExists();
                MessageBox.Show("Libag");
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            MyTimerData();
    
            showValueTheoroticalauto();

        }

        void showValueTheoroticalauto()
        {

            if (dgvAutomation.RowCount > 0)
            {
                if (dgvAutomation.CurrentRow != null)
                {
                    if (dgvAutomation.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        lblmacro.Text = dgvAutomation.CurrentRow.Cells["theo_batch_macro"].Value.ToString();


                    }

                }
            }

        }


        public void MyTimerData()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [Fedoramain].[dbo].[rdf_production_advance]  WHERE prod_id = '" + txtproductionid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
          dgvAutomation.DataSource = dt;

        }



    }
}



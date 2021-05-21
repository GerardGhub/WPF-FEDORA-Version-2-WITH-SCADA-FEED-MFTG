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
    public partial class frmProductionAutomation : Form
    {


        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds = new DataSet();
        DataSet dSet_temp = new DataSet();

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSet40 = new DataSet();
        DataSet dSet2 = new DataSet();
        DataSet dSet22 = new DataSet();
        DataSet dSets = new DataSet();

        string mode = "";
        int p_id = 0;
        int temp_hid = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        //declare as global

        int nRow;
        public frmProductionAutomation()
        {
            InitializeComponent();
        }

        private void frmProductionAutomation_Load(object sender, EventArgs e)
        {
            //Clear qty
            ClearData();
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

                    label3.Visible = false;
                    label6.Visible = false;
                    txtNewCount.Visible = false;
        
                    lblliquidbatch.Visible = false;
            }
            else
            {

                label6.Visible = true;
                txtNewCount.Visible = true;
      
                lblliquidbatch.Visible =true;


                lblvalidateTheo.Text = "0";
                lblvalidatecount.Text = "0";
               
           
                txtitemcodemacro1.Text = dataGridView2.CurrentRow.Cells["item_code_macro"].Value.ToString();
                txtquantitymacro1.Text = dataGridView2.CurrentRow.Cells["quantity_macro"].Value.ToString();
               
            }

         

            txtactualweight.Text = "";
            // Timer Tick
            timer2_Tick(sender, e);

            //
            HideControlls();
            checkEntry();
            load_TheoMaterials();
            checkingofTheoMaterials();

            if (lbltotalprod.Text == "0")
            {
                lblmacro.Visible = false;
                lblscanthebarcode.Visible = false;
                lblstatus.Visible = false;
                label2.Visible = false;
                lblliquidcount.Visible = false;
                txtScanner.Visible = false;
            }
            else
            {
                lblstatus.Visible = true;
                //lblscanthebarcode.Visible = true;
                lblmacro.Visible = true;
                lblmacrocount.Visible = true;
                lblvalidatecount.Visible = true;
                //

                txtraSelection.Text = "SameSelection";
                if (txtitemcodemacro2.Text.Trim() == string.Empty)
                {
                    btnnextline_Click(sender, e);
                }
            }



            txtTheorotical.Enabled = false;
        


        }


        void ClearData()
        {
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
            //btngreaterthan.Visible = false;pekpek
            //btnlessthan.Visible = false;pekpek
            ControlBox = false;
            lblscanthebarcode.Visible = false;

            lblTheoCounts.Visible = false;
            lblmacrovalidatecount.Visible = false;
            timer1_Tick(new object(), new System.EventArgs());
            ControlBox = true;
        }

        void checkEntry()
        {
            if (lbltotalprod.Text == "0")
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



        void load_TheoMaterials()
        {

            dset_emp9.Clear();




            dset_emp9 = objStorProc.sp_getMajorTables("RawMatsTheo");
            doSearch9();



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


        void load_search()
        {

            dset_emp.Clear();
            dset_emp8.Clear();


            dset_emp = objStorProc.sp_getMajorTables("Theorotical_Automation");
            dset_emp1 = objStorProc.sp_getMajorTables("Validate_Automation");
            dset_emp2 = objStorProc.sp_getMajorTables("Basemixed_Automation");
            dset_emp3 = objStorProc.sp_getMajorTables("BMXRepack_Automation");
            dset_emp4 = objStorProc.sp_getMajorTables("ProductionCount_Automation");
            dset_emp5 = objStorProc.sp_getMajorTables("repackingEntry_Automation");
            dset_emp8 = objStorProc.sp_getMajorTables("repackingEntry_Automation");

            doProdCount();

      
            doSearchValidate();
            doSearchBMX();
            doBMXRepack();

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
                        dv.RowFilter = "theo_feed_code = '" + txtmainfeedcode.Text + "' AND theo_prod_id = '" + txtproductionid.Text + "' AND batch_num = '" + txtbatchremain.Text + "'";

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

                //double s1 = Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value);


                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                //double s15 = s1 * 2; remove 12/23/2020

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                //dataGridView1.Rows[n].Cells[3].Value = s15.ToString();12/23/2020
                //dataGridView1.Rows[n].Cells[3].Value = s15.ToString();


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
                    dgvbmx.DataSource = dv;
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

                        dv.RowFilter = "product_feed_code ='" + txtmainfeedcode.Text + "' AND prod_id ='" + txtproductionid.Text + "'";
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
            string mcolumns = "test,prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate,repacking_status,bagorbin,theo_batch_macro";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "isForproduction_Automation");
            lbltotalprod.Text = dataView.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();

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
            dataGridView1.DataSource = dt;

        }
        void showValueTheorotical()
        {

            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        lblmacro.Text = dataGridView1.CurrentRow.Cells["theo_batch_macro"].Value.ToString();


                    }

                }
            }

        }


        public void MyTimerDataLiquid()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);
            string sqlquery = "SELECT distinct a.batch_num,a.theo_item_desc FROM [Fedoramain].[dbo].[theo_logs_tbl] a LEFT JOIN rdf_raw_materials b ON b.item_code=a.theo_item_code  WHERE a.theo_prod_id = '" + txtproductionid.Text + "' and b.item_group = 'Theoretical2' and a.batch_num='"+ lblliquidbatch.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvLiquid.DataSource = dt;
            lblliquidcount.Text = dgvLiquid.RowCount.ToString();

   
        }
        public void MyTimerDataLiquid2()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);
            string sqlquery = "SELECT distinct a.batch_num,a.theo_item_desc FROM [Fedoramain].[dbo].[theo_logs_tbl] a LEFT JOIN rdf_raw_materials b ON b.item_code=a.theo_item_code  WHERE a.theo_prod_id = '" + txtproductionid.Text + "' and b.item_group = 'Theoretical2' and a.batch_num='1'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvLiquid.DataSource = dt;
            lblliquidcount.Text = dgvLiquid.RowCount.ToString();


        }



        public void DataLiquidCountRecipe()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);
            string sqlquery = "SELECT distinct item_code from rdf_recipe_to_production where production_id= '" + txtproductionid.Text + "' and rp_category='MACRO' and rp_group = 'Theoretical2'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
        dgvCountTotalTheo2.DataSource = dt;
           lbltotalTheo.Text = dgvCountTotalTheo2.RowCount.ToString();


        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                return;
            }

       
                timer2.Start();


            //MessageBox.Show("sdsdsds");

            MyTimerData();

            //count recipe theo 2 
            DataLiquidCountRecipe();
            //
            //count already produce
            //////MyTimerDataLiquid();  secret
            //if else structure set the county
            //if(lblliquidcount.Text =="0")
            //{
            //    lblliquidbatch.Text = "0";
            //}
            //if(lblliquidbatch.Text =="0")
            //{ 
            //if(lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
            //    {
            //        lblliquidbatch.Text = "1";
            //    }
            //}

           

            showValueTheorotical();

            if (btnsubmit.Visible == false)
            {
                if (txtMacro.Text.Trim() == string.Empty)
                {
                    txtScanner.Focus();
                    txtScanner.Select();
                    if (txtitemcodemacro2.Text.Trim() == string.Empty)
                    {
                        btnnextline_Click(new object(), new System.EventArgs());
                    }

                }

            }


            dSet22.Clear();


            dSet22 = objStorProc.rdf_sp_bulk_data(0, txtproductionid.Text.Trim(), "", "", txtaddedby.Text.Trim(), "1", "checkselectionzero_Automation");

            if (dSet22.Tables[0].Rows.Count > 0)
            {
                txtScanner.Enabled = false;
                lblscanthebarcode.Visible = false;
                txtScanner.Visible = false;
            }
            else
            {

                if (lbltotalprod.Text == "0")
                {

                }
                else
                {

                    txtScanner.Visible = true;
                    if (txtbmx.Visible == true)
                    {
                        txtScanner.Visible = false;
                        lblmain6.Visible = true;
                    }
                    else
                    {
                        lblmain6.Visible = false;
                    }


                    if (txtMacro.Text.Trim() == string.Empty)
                    {
                        lblscanthebarcode.Visible = true;
                        txtScanner.Enabled = true;
                        txtScanner.Focus();
                        txtScanner.Select();
                    }
                }


            }


            //paalam na 
            dSet.Clear();


            dSet = objStorProc.rdf_sp_bulk_data(0, txtproductionid.Text.Trim(), "", "", txtaddedby.Text.Trim(), "1", "checkselection_Automation");



            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboFeedCode.Focus();
                //QtyAlreadyExist();
                //MessageBox.Show("Wait for the Status in the Controll Room before Save !");
                // AlreadySelect();

                //MessageBox.Show("Same ID Select!");
                if (txtraSelection.Text.Trim() == string.Empty)
                {

                }
                else
                {
                    txtraSelection.Text = "SameSelection";

                }

            }

            else
            {



                if (txtraSelection.Text.Trim() == "SameSelection")
                {
                    txtraSelection.Text = "DifferentSelection";
                    if (txtraSelection.Text.Trim() == string.Empty)
                    {

                    }
                    else
                    {

                    }
                    //MessageBox.Show("null");

                    frmProductionAutomation_Load(sender, e);


                }
                else
                {


                }

                //frmProductionEntry_Load(sender, e);

                //if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Refresh the Production of " + txtaddedby.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //{
                //    frmProductionEntry_Load(sender, e);
                //}
                //else
                //{
                //    frmProductionEntry_Load(sender, e);
                //}

                //MessageBox.Show("Different ID Select!");

            }



            Checking();

        }



        void Checking()
        {
         
            if(lblliquidcount.Text =="0")
            {

                if (lblmacro.Text == "0")
                {

                    lblliquidbatch.Text = "0";
                }
                MyTimerDataLiquid2();
            }
            else
            {
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "1";
                }
                else
                {
                    return;
                }

            }

            if (lblliquidbatch.Text == "1")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "2";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "2")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "3";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "3")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "4";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "4")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "5";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "5")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "6";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "6")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "7";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "7")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "8";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "8")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "9";
                }
                else
                {
                    return;
                }

            }
            if (lblliquidbatch.Text == "9")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "10";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "10")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "11";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "11")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "12";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "12")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "13";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "13")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "14";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "14")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "15";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "15")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "16";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "16")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "17";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "17")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "18";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "18")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "19";
                }
                else
                {
                    return;
                }
            }
            if (lblliquidbatch.Text == "19")
            {
                MyTimerDataLiquid();
                if (lbltotalTheo.Text.Trim() == lblliquidcount.Text.Trim())
                {
                    lblliquidbatch.Text = "20";
                }
                else
                {
                    return;
                }
            }
        }
        private void btnnextline_Click(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                return;
            }


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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Start();
            //if (lbltotalprod.Text == "0")
            //{
            //    load_Schedules();
            //}
            //else
            //{

            //    txtTheorotical.Visible = true;
            //    //txtTheorotical.Enabled = true;
            //    dataGridView1.Visible = true;
            //    dataGridView2.Visible = true;
            //    dataGridView3.Visible = true;

            //    dataView.Visible = true;
            //    lbltotalprod.Visible = true;
            //    label1.Visible = true;


            //    lblmain1.Visible = true;
            //    lblmain2.Visible = true;
            //    lblmain3.Visible = true;
            //    lblmain4.Visible = true;

            //    //lblmain6.Visible = true;
            //    lblmain7.Visible = true;
            //    lblmain8.Visible = true;
            //    txtbatchremain.Visible = true;
            //    txtmainbatch.Visible = true;
            //    txtbatch.Text = "";
            //    timer1.Stop();

            //    txtTheorotical.Select();
            //    txtTheorotical.Focus();

            //}
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

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueTheorotical();
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueDailyProduction();
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

                        lblmacro.Text = dataView.CurrentRow.Cells["theo_batch_macro"].Value.ToString();

                    }

                }
            }

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {




            if (txtbatchremain.Text.Trim() == lblmacro.Text.Trim())
            {

            }




            double basemixed;
            double mash;

            basemixed = double.Parse(txtbatchremain.Text);
            mash = double.Parse(lblmacro.Text);

            if (basemixed > mash)
            {
                WaitforSave();

            }
            else
            {


                btnFinalSave_Click(sender, e);



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

        void FillRequiredField()
        {
            if (txtScanner.Text.Trim() == string.Empty)
            {

            }
            else
            {
                return;
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


    
    void WaitforSave()
    {

        PopupNotifier popup = new PopupNotifier();
        popup.Image = Properties.Resources.info;
        popup.TitleText = "Fedora Notifications";
        popup.TitleColor = Color.White;
        popup.TitlePadding = new Padding(95, 7, 0, 0);
        popup.TitleFont = new Font("Tahoma", 10);
        popup.ContentText = "Hintayin Mo muna Mag match ang Macro Mash Bago Mag Save !";
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

        //data 8
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
        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {

            if (txtScanner.Text.Trim() == string.Empty)
            {

                FillRequiredField();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }



            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit2_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit3_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit4_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit5_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit6_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit7_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit8_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit9_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit10_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            //11

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit11_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }


            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit12_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }


            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit13_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit14_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {

                ProductIDExists();
                txtScanner.Text = "";
                txtScanner.Focus();
                return;
            }

            //15
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "exit15_Automation");
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

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "", "", "", "", "", "", txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, txtScanner.Text, "checkrepackingid_Automation");
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


            dset_emp8 = objStorProc.sp_getMajorTables("repackingEntry_Automation");

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


           

            }
        }

        private void btnMacro7_Click(object sender, EventArgs e)
        {
            if (txtMacro7.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }

            




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

              

            }
        }

        private void btnMacro5_Click(object sender, EventArgs e)
        {
            if (txtMacro5.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }

    
      

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

      

            }
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

        private void btnMacro4_Click(object sender, EventArgs e)
        {

            
         



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



            }
        }

        private void btnMacro3_Click(object sender, EventArgs e)
        {






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

           

            }
        }

        private void btnMacro2_Click(object sender, EventArgs e)
        {
            if (txtMacro2.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                return;
            }


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




            }
        }

        private void btnMacro_Click(object sender, EventArgs e)
        {
            if (txtMacro.Text.Trim() == string.Empty)
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

        private void lblvalidatecount_Click(object sender, EventArgs e)
        {

        }

        void SuccessFullyValidateMacroValidate()
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
            //doSearchValidate();
            showValueDailyProduction();




            //txtScanner.Enabled = false;


            lblmain6.Visible = true;

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

            if (txtTheorotical10.Text.Trim() == string.Empty)
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

        private void txtbmx_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                bntSave_Click(sender, e);
            }

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

        private void bntSave_Click(object sender, EventArgs e)
        {


            if (txtbmx.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtbmx.Select();
                txtbmx.Focus();
                return;
            }

            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, txtbmx.Text, txtproductionid.Text, "", "", "", "", txtMacro11.Text, txtMacro12.Text, txtMacro13.Text, txtMacro14.Text, txtMacro15.Text, "bmxexisting_Automation");
            if (dSet.Tables[0].Rows.Count > 0)
            {
                
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

            cmd = new SqlCommand("SELECT bmx_id_string FROM [Fedoramain].[dbo].[rdf_repackin_bmx]  WHERE bmx_id_string=" + txtbmx.Text + " AND prod_adv='" + txtproductionid.Text + "' AND bmx_feed_code='" + txtmainfeedcode.Text + "'", sql_con);

            SqlDataAdapter daks = new SqlDataAdapter(cmd);

            daks.Fill(ds);
            int ia = ds.Tables[0].Rows.Count;
            if (ia > 0)
            {

                dset_emp2 = objStorProc.sp_getMajorTables("Basemixed_Automation");
                dset_emp3 = objStorProc.sp_getMajorTables("BMXRepack_Automation");
                doBMXRepack();


         
                if (txtactualweight.Text.Trim() == string.Empty)
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

        void SuccessFullyProduction()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "PRODUCTION OF " + txtfeedtype.Text + " " + txtbatchremain.Text + " OUT OF " + txtmainbatch.Text + " BATCH SUCCESSFULLY SAVE !";
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
            if (lbltotalprod.Text == "0")
            {

            }
            else
            {
                txtTheorotical.Enabled = true;
                txtTheorotical.Focus();

            }
        }


        void MyQueryforRefresh()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [Fedoramain].[dbo].[rdf_production_advance]  WHERE prod_id = '" + txtprodid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRemoveRefreshRate.DataSource = dt;
        }


        public bool saveMode()
        {
         
            if (mode == "add_Automation")
            {
       


                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtmainfeedcode.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "getbyname_Automation");

                    if (dSet.Tables[0].Rows.Count > 0)
                    {

                    //Start
                    dSet40.Clear();
                    dSet40 = objStorProc.rdf_sp_prod_schedules(0, txtproductionid.Text, txtbatchremain.Text, "", "", "", "", "", "", "", "", "","", "HaveProductionRemainingBatch");

                    if (dSet40.Tables[0].Rows.Count > 0)
                    {


                    }
                    else
                    {
                        dSets = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text.Trim(), txtfeedtype.Text.Trim(), txtproductionid.Text.Trim(), txtmainbatch.Text.Trim(), txtbatchremain.Text.Trim(), txtTheorotical.Text.Trim(), txtTheorotical2.Text.Trim(), txtTheorotical3.Text.Trim(), txtTheorotical4.Text.Trim(), txtTheorotical5.Text.Trim(), txtTheorotical6.Text.Trim(), txtTheorotical7.Text.Trim(), txtTheorotical8.Text.Trim(), txtTheorotical9.Text.Trim(), txtTheorotical10.Text.Trim(), txtMacro1.Text.Trim(), txtMacro2.Text.Trim(), txtMacro3.Text.Trim(), txtMacro4.Text.Trim(), txtMacro5.Text.Trim(), txtMacro6.Text.Trim(), txtMacro7.Text.Trim(), txtMacro8.Text.Trim(), txtMacro9.Text.Trim(), txtMacro10.Text.Trim(), txtbmx_id.Text.Trim(), txtbmxqtybatch.Text.Trim(), txtactualweight.Text.Trim(), txtmixingdate.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), txtMacro11.Text.Trim(), txtMacro12.Text.Trim(), txtMacro13.Text.Trim(), txtMacro14.Text.Trim(), txtMacro15.Text.Trim(), "add_Automation");
                    }



                        if (txtbatchremain.Text.Trim() == txtmainbatch.Text.Trim())
                        {

                        

                                dSet.Clear();

                                dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtproductionid.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", txtdatenow.Text, txtaddedby.Text, txtMacro11.Text, txtMacro12.Text, txtMacro13.Text, txtMacro14.Text, txtMacro15.Text, "productionfinish_Automation");
                          

                        }
                        //load_macro_count();

                        SuccessFullyProduction();
                        //load_Schedules();
                        MyQueryforRefresh();
                        CurrentCellofDuplicateSchedules();
                        showValueDailyProduction();
                        load_search();


                        MySelect();
                        txtScanner.Focus();
                        txtScanner.Select();
                        return false;
                    }
             

                else
                {
                    //Start
                    dSet40.Clear();
                    dSet40 = objStorProc.rdf_sp_prod_schedules(0, txtproductionid.Text, txtbatchremain.Text, "", "", "", "", "", "", "", "", "","", "HaveProductionRemainingBatch");

                    if (dSet40.Tables[0].Rows.Count > 0)
                    {


                    }
                    else
                    {
                        dSet.Clear();
                        dSets = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text.Trim(), txtfeedtype.Text.Trim(), txtproductionid.Text.Trim(), txtmainbatch.Text.Trim(), txtbatchremain.Text.Trim(), txtTheorotical.Text.Trim(), txtTheorotical2.Text.Trim(), txtTheorotical3.Text.Trim(), txtTheorotical4.Text.Trim(), txtTheorotical5.Text.Trim(), txtTheorotical6.Text.Trim(), txtTheorotical7.Text.Trim(), txtTheorotical8.Text.Trim(), txtTheorotical9.Text.Trim(), txtTheorotical10.Text.Trim(), txtMacro1.Text.Trim(), txtMacro2.Text.Trim(), txtMacro3.Text.Trim(), txtMacro4.Text.Trim(), txtMacro5.Text.Trim(), txtMacro6.Text.Trim(), txtMacro7.Text.Trim(), txtMacro8.Text.Trim(), txtMacro9.Text.Trim(), txtMacro10.Text.Trim(), txtbmx_id.Text.Trim(), txtbmxqtybatch.Text.Trim(), txtactualweight.Text.Trim(), txtmixingdate.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), txtMacro11.Text.Trim(), txtMacro12.Text.Trim(), txtMacro13.Text.Trim(), txtMacro14.Text.Trim(), txtMacro15.Text.Trim(), "add_Automation");
                    }


                    if (txtbatchremain.Text.Trim() == txtmainbatch.Text.Trim())
                    {
                        //MessageBox.Show("Ready To Stock out");

                        dSet.Clear();

                        dSet = objStorProc.rdf_sp_new_production(0, txtmainfeedcode.Text, txtproductionid.Text, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "", "", "", txtMacro.Text, txtMacro2.Text, txtMacro3.Text, txtMacro4.Text, txtMacro5.Text, txtMacro6.Text, txtMacro7.Text, txtMacro8.Text, txtMacro9.Text, txtMacro10.Text, "", "", "", "", txtdatenow.Text, txtaddedby.Text, txtMacro11.Text, txtMacro12.Text, txtMacro13.Text, txtMacro14.Text, txtMacro15.Text, "productionfinish_Automation");
                    }



                    SuccessFullyProduction();
                    //load_Schedules();
                    MyQueryforRefresh();
                    CurrentCellofDuplicateSchedules();
                    showValueDailyProduction();
                    load_search();

                    btnnextline_Click(new object(), new System.EventArgs());
                    MySelect();
                    txtScanner.Focus();
                    txtScanner.Select();
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
        void ViewDataProduction()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [Fedoramain].[dbo].[rdf_production_advance] WHERE prod_id= '" + txtproductionid.Text + "' AND is_selected='1' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();





        }


        private void btnFinalSave_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Save the Production of " + txtmainfeedcode.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //theoroticalOperations();
                lblliquidbatch.Text = "0";
                mode = "add_Automation";
                if (txtproductionid.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Pleased Selectx production", "Production Today", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "add_Automation")
                        {
                            btnsubmit.Visible = false;

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




                //load_TheoMaterials();
            }

            else
            {

                //MessageBox.Show("return");
                return; // this will return the query here
            }






            if (txtbatchremain.Text.Trim() == txtbatchminus1.Text.Trim())
            {
                //new update 3/7/2021 Gerard Roques Singian Full Stack Developer @ singian28@gmail.com
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "","", "HaveTheoretical");

                if (dSet.Tables[0].Rows.Count > 0)
                {



                    //MessageBox.Show("b");




                    txtdatenowstamp.Text = DateTime.Now.ToString();
                    //November 11
                    //Gerard MEdical



                    dSets.Clear();
                    dSets = objStorProc.rdf_sp_new_production(0, txtdatenowstamp.Text.Trim(), txtfeedtype.Text.Trim(), txtproductionid.Text.Trim(), txtmainbatch.Text.Trim(), txtbatchremain.Text.Trim(), txtTheorotical.Text.Trim(), txtTheorotical2.Text.Trim(), txtTheorotical3.Text.Trim(), txtTheorotical4.Text.Trim(), txtTheorotical5.Text.Trim(), txtTheorotical6.Text.Trim(), txtTheorotical7.Text.Trim(), txtTheorotical8.Text.Trim(), txtTheorotical9.Text.Trim(), txtTheorotical10.Text.Trim(), txtMacro1.Text.Trim(), txtMacro2.Text.Trim(), txtMacro3.Text.Trim(), txtMacro4.Text.Trim(), txtMacro5.Text.Trim(), txtMacro6.Text.Trim(), txtMacro7.Text.Trim(), txtMacro8.Text.Trim(), txtMacro9.Text.Trim(), txtMacro10.Text.Trim(), txtbmx_id.Text.Trim(), txtbmxqtybatch.Text.Trim(), txtactualweight.Text.Trim(), txtmixingdate.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), txtMacro11.Text.Trim(), txtMacro12.Text.Trim(), txtMacro13.Text.Trim(), txtMacro14.Text.Trim(), txtMacro15.Text.Trim(), "endProduction_Automation");


                    //3 query function james foul
                    ViewDataProduction();
                    ViewCellChanger();

                    QueryTryCatchProdTimes();

                    //4 additonal
                    dSet = objStorProc.rdf_sp_new_preparation(0, txtmainfeedcode.Text, txtaddedby.Text, "6.1 Production Module", "Production of Raw Materials", txtdatenowstamp.Text, txtproductionid.Text, txtmainbatch.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");




                    frmProductionAutomation_Load(sender, e);

                }
                else
                {

                }
            }

            else
            {
                btnValidate1.Visible = true;
                lblvalidateTheo.Text = "0";
                lblvalidatecount.Text = "0";
                lblmain5.Visible = false;
                lblmain6.Visible = false;
                MySelect();
                btnnextline_Click(sender, e);

            }

            //txtquantity0.Text = dataGridView1.CurrentRow.Cells["actual_qty"].Value.ToString();
            checkEntry();
            lblactualweightinfo.Visible = false;
            btnsubmit.Visible = false;
            load_TheoMaterials();
            bunifuStart.Visible = true;
            //btngreaterthan.Visible = true;
            //btnlessthan.Visible = true;
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
            btnnextline_Click(new object(), new System.EventArgs());
            HideControlls();//lara citu



        }

        void QueryTryCatchProdTimes()
        {
            txtdatenowstamp.Text = DateTime.Now.ToString();
            //November 11
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [Fedoramain].[dbo].[rdf_production_advance] SET production_time='" + txtSumofRepacking.Text + "' WHERE prod_id= '" + txtproductionid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();




        }



        private void dgvUpdateTimeLampse_CurrentCellChanged(object sender, EventArgs e)
        {
            ViewCellChanger();
        }


        void MySelect()
        {

            txtTheorotical.Enabled = false;
            //lblscanthebarcode.Visible = true;
            txtScanner.Visible = true;
            txtScanner.Enabled = true;
            txtScanner.Focus();
            txtScanner.Select();
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

        private void dgvRemoveRefreshRate_CurrentCellChanged(object sender, EventArgs e)
        {
            CurrentCellofDuplicateSchedules();
        }

        private void dgvbmx_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueBMXSearchFinal();
        }


        void showValueBMXSearchFinal()
        {

            if (dgvbmx.RowCount > 0)
            {
                if (dgvbmx.CurrentRow != null)
                {
                    if (dgvbmx.CurrentRow.Cells["bmx_id_string"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtbmx_id.Text = dgvbmx.CurrentRow.Cells["bmx_id_string"].Value.ToString();
                        txtbatchprint.Text = dgvbmx.CurrentRow.Cells["bmx_batch_print"].Value.ToString();
                        txtactualweight.Text = dgvbmx.CurrentRow.Cells["actual_weight"].Value.ToString();


                    }

                }
            }

        }

        private void lblmain1_Click(object sender, EventArgs e)
        {
      //     lblmacro.Text = "1";
      //lblliquidcount.Text = "puke";
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

        private void lblmacro_TextChanged(object sender, EventArgs e)
        {
            if (txtScanner.Visible == true)
            {

                player.SoundLocation = @"C:\Reports\Fedora_Voice\pwedengmagscanngbmx.wav";
                player.Play();
            }

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

        private void txtbatchremain_TextChanged(object sender, EventArgs e)
        {
          txtNewCount.Text = (float.Parse(txtbatchremain.Text) - 1).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, txtproductionid.Text, "", "", "", "", "", "", "", "", "", "","", "HaveTheoretical");

            if (dSet.Tables[0].Rows.Count > 0)
            {
 
                MessageBox.Show("A");
                //return;
            }
            else
            {
                MessageBox.Show("b");


            }


        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, txtproductionid.Text, txtbatchremain.Text, "", "", "", "", "", "", "", "", "","", "HaveProductionRemainingBatch");

            if (dSet.Tables[0].Rows.Count > 0)
            {

                MessageBox.Show("A");
                //return;
            }
            else
            {
                MessageBox.Show("b");


            }

        }

        ///

    }
}

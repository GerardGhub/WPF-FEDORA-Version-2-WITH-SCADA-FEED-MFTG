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
    public partial class frmFGReprocessModule : Form
    {
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        myclasses xClass = new myclasses();
        DataSet dSet = new DataSet();
        public frmFGReprocessModule()
        {
            InitializeComponent();
        }

        private void frmFGReprocessModule_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();

            load_FGmonitoring();
            myglobal.global_module = "Active";
            //load_search();


            txtMainInput.Text = "";
            txtMainInput.Select();
            txtMainInput.Focus();

            txtprocessBy.Text = userinfo.emp_name.ToUpper();
            lbladdedby.Text = userinfo.emp_name.ToUpper();

            lblid.Text = userinfo.user_rights_id.ToString();
            gbMain.Visible = false;
            loadCode();
        }



        void loadCode()
        {


            xClass.fillComboBoxWH(cboMixingCombination, "rdf_code_overall", dSet);



        }
        public void load_FGmonitoring()
        {
            string mcolumns = "test,prod_id,p_feed_code,feed_type,bags_int,proddate,total_reprocess_count,DONE,TOTAL,AGING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "FGmonitoringReprocess");
            lbltotaldata.Text = dataView.RowCount.ToString();

        }

        private void txtMainInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (txtMainInput.Text.Trim() == string.Empty)
            {
                FillUpRequiredFields();
                return;

            }
            load_search();
            //doSearch();
        }

        DataSet dset_emp = new DataSet();
        void load_search()
        {

            dset_emp.Clear();



            dset_emp = objStorProc.sp_getMajorTables("FGBarcoding");

            doSearch();


        }

        void ValidatedSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY SCAN! " + txtfeedtype.Text + "";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.AnimationDuration = 100;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 100;
            popup.AnimationInterval = 1;
            popup.AnimationDuration = 100;


            popup.ShowOptionsButton = true;
            gbMain.Visible = false;
            btnTransForm.Visible = false;
        }


        void TransFormedValidatedSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "TRANSFORM SUCCESSFULLY SCAN! " + txtfeedtype.Text + "";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.AnimationDuration = 100;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 100;
            popup.AnimationInterval = 1;
            popup.AnimationDuration = 100;


            popup.ShowOptionsButton = true;
            gbMain.Visible = false;
            btnTransForm.Visible = false;
        }
        void ValidatedSuccessReprocess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY REPROCESS! " + txtfeedtype.Text + "";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.AnimationDuration = 100;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 100;
            popup.AnimationInterval = 2;
            popup.AnimationDuration = 100;


            popup.ShowOptionsButton = true;


        }



        void NotExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FINISHED GOOD IS NOT EXISTS!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void RequiredField()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL THE REQUIRED FIELDS!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void DuplicateStatus()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "DUPLICATE STATUS!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        public void UpdateFg()
        {

            lbltimestamp.Text = DateTime.Now.ToString();
            txtdate.Text = DateTime.Now.ToString("M/d/yyyy");

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_repackin_finishgoods] SET reproccess_prod_id='" + lblprod_id.Text + "',fg_reprocess_by='" + lbladdedby.Text + "',proc_time_stamp='" + lbltimestamp.Text + "',fg_added_by='" + txtdate.Text + "'  WHERE  bmx_id_string='" + txtfg_id.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dgvUpdatefg.DataSource = dt;


        }

        void UpdateProdSchedule()
        {


            txtactualprocess.Text = (float.Parse(txtreprocessdata.Text) - 1).ToString();


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET total_reprocess_count='" + txtactualprocess.Text + "' WHERE prod_id='" + txtproductionid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dgvProdSched.DataSource = dt;

        }
        void Alreadyreprocess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Already reprocess By " + txtprocessBy.Text + "!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void FifoMethod()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Invalid Reprocess FIFO Method, Recommended for Reprocess is the Production ID  " + lblprod_id.Text + "!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }



        void NoMatchedFeedCode()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Error Cannot Find the similar FeedType failed to Reprocess " + txtprocessBy.Text + "!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
            txtMainInput.Focus();

        }


        void ReprocessOnly()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Reprocess transaction only! System Found a " + lblstatus.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }



        void FillUpRequiredFields()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE REQUIRED FIELDS!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void LoadData()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            //string sqlquery = "SELECT p_feed_code as FeedCode, feed_type as FeedType, p_bags as Bags, p_nobatch as Batch, proddate as ProductionDate, prod_id FROM [dbo].[rdf_production_advance] a  WHERE  p_feed_code='" + txtfeedcode.Text + "' AND  NOT a.prod_id = '" + txtproductionid.Text + "' AND" +
            //    "        a.repacking_status='Finish' AND a.BMX_Status IS NOT NULL AND a.finish_production_date IS NOT NULL AND a.fg_date_finish IS NULL";



            //laarnie


            string sqlquery = "SELECT p_feed_code as FeedCode, feed_type as FeedType, p_bags as Bags, p_nobatch as Batch, proddate as ProductionDate, prod_id FROM [dbo].[rdf_production_advance] a  WHERE  feed_type='" + txtfeedtype.Text + "' AND  NOT a.prod_id = '" + txtproductionid.Text + "' AND" +
                "        a.repacking_status='Finish' AND a.BMX_Status IS NOT NULL AND a.fg_date_finish IS NULL";



            //       string sqlquery = "SELECT p_feed_code as FeedCode, feed_type as FeedType, p_bags as Bags, p_nobatch as Batch, proddate as ProductionDate, prod_id FROM [dbo].[rdf_production_advance] a  WHERE  feed_type='" + txtfeedtype.Text + "' AND  NOT a.prod_id = '" + txtproductionid.Text + "' AND" +
            //"        a.repacking_status='Finish' AND a.BMX_Status IS NOT NULL AND a.finish_production_date IS NOT NULL AND a.fg_date_finish IS NULL";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvduplicatedata.DataSource = dt;
            lblrecordforreprocess.Text = dgvduplicatedata.RowCount.ToString();



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
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "fg_id = '" + txtMainInput.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView1.DataSource = dv;
                    lblrecords.Text = dataGridView1.RowCount.ToString();

                    txtMainInput.Text = "";
                    txtMainInput.Select();
                    txtMainInput.Focus();
                    if (lblrecords.Text == "0")
                    {
                        //MessageBox.Show("FG Barcode Not Found!");
                        NotExists();
                        panel1.Visible = false;
                        panel2.Visible = false;
                        txtMainInput.Text = "";
                        txtMainInput.Select();
                        txtMainInput.Focus();
                        btnReprocessclick.Visible = false;
                        lblrecordforreprocess.Visible = false;
                        dgvduplicatedata.Visible = false;
                        lblstatus.Visible = false;
                        label2.Visible = false;
                    }

                    else
                    {


                        lblfglabel.Visible = true;
                        txtdate4.Visible = true;
                        panel1.Visible = true;
                        panel2.Visible = true;
                        label2.Visible = true;
                        lblstatus.Visible = true;



                        ValidatedSuccess();//gerard
                        if (lblstatus.Text == "Reprocess")
                        {
                            LoadData();
                            if (lblrecordforreprocess.Text == "0")
                            {
                                NoMatchedFeedCode();
                                return;

                            }
                            else
                            {


                                lblprod_id.Text = dgvduplicatedata.CurrentRow.Cells["prod_id"].Value.ToString();
                                dgvduplicatedata.Visible = true;
                            }



                        }
                        else
                        {
                            if (lblid.Text == "1063" || lblid.Text == "2")
                            {
                                SearchUpdate();
                                btnTransForm.Visible = true;
                                gbMain.Visible = true;
                                cboStatus.Text = "Select Status";
                            }

                            ReprocessOnly();
                            dgvduplicatedata.Visible = false;
                            lblrecordforreprocess.Text = "0";
                        }

                        if (lblstatus.Text == "Good")
                        {
                            if (lblid.Text == "1063" || lblid.Text == "2")
                            {
                                SearchUpdate();
                                btnTransForm.Visible = true;
                                gbMain.Visible = true;
                                cboStatus.Text = "Select Status";
                            }

                            ReprocessOnly();
                            txtMainInput.Text = "";
                            txtMainInput.Focus();
                            return;
                        }





                        if (lblrecordforreprocess.Text == "0")
                        {
                            btnReprocessclick.Visible = false;
                            lblrecordforreprocess.Visible = false;
                        }
                        else
                        {
                            btnReprocessclick.Visible = true;
                            lblrecordforreprocess.Visible = true;
                        }

                        if (txtprocessBy.Text.Trim() == string.Empty)
                        {
                            if (lblid.Text == "61" || lblid.Text == "2")
                            {
                                SearchUpdate();
                                btnTransForm.Visible = true;
                                gbMain.Visible = true;
                                cboStatus.Text = "Select Status";
                            }

                        }
                        else
                        {

                            lbladdedby.Visible = false;
                            dgvduplicatedata.Visible = false;
                            btnReprocessclick.Visible = false;
                            lblrecordforreprocess.Visible = false;
                            btnTransForm.Visible = false;
                            gbMain.Visible = false;

                            Alreadyreprocess();
                        }




                    }
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
                //MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }


        }







  



        private void txtMainInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (lblid.Text == "61")
                //{
                //    MessageBox.Show("Lovely Github!");
                //    if (txtMainInput.Text.Trim() == string.Empty)
                //    {
                //        FillUpRequiredFields();
                //        txtMainInput.Focus();
                //        return;

                //    }
                 
                //        load_search();
                //        doSearch();
                  
         
                //}
                //else
                //{

                    btnBarcode_Click(sender, e);
                //}
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueDailyProduction();

        }


        void showValueDailyProduction()
        {

            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["fg_id"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);
                        txtdate1.Text = dataGridView1.CurrentRow.Cells["fg_micro_prepa"].Value.ToString();
                        lblproduction.Text = dataGridView1.CurrentRow.Cells["fg_finish_production"].Value.ToString();
                        txtdate2.Text = dataGridView1.CurrentRow.Cells["fg_micro_bmx"].Value.ToString();
                        txtdate3.Text = dataGridView1.CurrentRow.Cells["fg_macro_prepa"].Value.ToString();
                        txtfg_id.Text = dataGridView1.CurrentRow.Cells["fg_id"].Value.ToString();
                        txtfgoptions.Text = dataGridView1.CurrentRow.Cells["fg_options"].Value.ToString();
                        txtactualweight.Text = dataGridView1.CurrentRow.Cells["actual_weight"].Value.ToString();
                        txtfeedcode.Text = dataGridView1.CurrentRow.Cells["fg_feed_code"].Value.ToString();
                        txtbags.Text = dataGridView1.CurrentRow.Cells["fg_bags"].Value.ToString();
                        txtbatch.Text = dataGridView1.CurrentRow.Cells["fg_batch"].Value.ToString();
                        txtfeedtype.Text = dataGridView1.CurrentRow.Cells["fg_feed_type"].Value.ToString();
                        txtproductionid.Text = dataGridView1.CurrentRow.Cells["prod_adv"].Value.ToString();
                        dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fg_proddate"].Value.ToString();
                        txtdate4.Text = dataGridView1.CurrentRow.Cells["fg_date_added"].Value.ToString();
                        txtprocessBy.Text = dataGridView1.CurrentRow.Cells["fg_reprocess_by"].Value.ToString();
                        txtbulkentrytotal.Text = dataGridView1.CurrentRow.Cells["bulkentry_total"].Value.ToString();
                        txtbagsentrytotal.Text = dataGridView1.CurrentRow.Cells["bags_total"].Value.ToString();
                        lblstatus.Text = dataGridView1.CurrentRow.Cells["status"].Value.ToString();

                     lblbarcode.Text = dataGridView1.CurrentRow.Cells["bmx_id_string"].Value.ToString();
                        //txtfeedtype.Text = dataGridView1.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                    }

                }
            }

        }

        void SearchUpdate()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);





            string sqlquery = "SELECT * FROM [dbo].[rdf_production_advance] WHERE prod_id ='" + txtproductionid.Text + "'";




            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
           dgvProdPlan.DataSource = dt;


        }

        private void btnReprocessclick_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Reprocess  feedcode " + txtfeedcode.Text + ", ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                checkdata();
                txtreprocessdata.Text = dgvCheckdata.RowCount.ToString();
                //txtreprocessdata.Text = dgvCheckdata.CurrentRow.Cells["total_reprocess_count"].Value.ToString();
                dgvCheckdata_CurrentCellChanged(sender, e);



                UpdateFg();

                UpdateProdSchedule();
                panel1.Visible = false;
                panel2.Visible = false;

                lblrecordforreprocess.Visible = false;
                dgvduplicatedata.Visible = false;
                lblstatus.Visible = false;
                label2.Visible = false;
                txtMainInput.Text = "";
                btnReprocessclick.Visible = false;
                ValidatedSuccessReprocess();
                frmFGReprocessModule_Load(sender, e);



            }
            else
            {
                return;
            }
  




        }

        void checkdata()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);




            string sqlquery = "SELECT * FROM [dbo].[rdf_repackin_finishgoods] WHERE prod_adv ='" + txtproductionid.Text +"' AND status='Reprocess' AND fg_added_by IS NULL";




            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
    dgvCheckdata.DataSource = dt;
           //txtreprocessdata.Text = dgvCheckdata.RowCount.ToString();

        }

        private void dgvduplicatedata_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void lblrecords_Click(object sender, EventArgs e)
        {

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

        private void txtMainInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCheckdata_CurrentCellChanged(object sender, EventArgs e)
        {



            if (dgvCheckdata.RowCount > 0)
            {
                if (dgvCheckdata.CurrentRow != null)
                {
                    if (dgvCheckdata.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);
               txtreprocessdata.Text = dgvCheckdata.CurrentRow.Cells["total_reprocess_count"].Value.ToString();

                    }

                }
            }












        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
                    }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            myglobal.REPORT_NAME = "ReprocessData";
            // rpt.Load(Rpt_Path + "\\MacroInventoryPrint.rpt");

            frmReport frmReport = new frmReport();
            //frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTransForm_Click(object sender, EventArgs e)
        {
            if(cboStatus.Text == "Select Status")
            {
                RequiredField();
                cboStatus.Focus();
                return;
            }
            if (cboStatus.Text.Trim() == lblstatus.Text.Trim())
            {
                DuplicateStatus();
                return;
            }

            if (txtremarks.Text.Trim() == string.Empty)
            {
                RequiredField();
                txtremarks.Focus();
                return;
            }



            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to transform the Barcode of feedcode " + txtfeedcode.Text + ", ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {



                    if (lblstatus.Text == "Good")
                    {
                        lblfinalgood.Text = (float.Parse(lblgood.Text) - 1).ToString();

                    }
                    else if (lblstatus.Text == "Rejected")
                    {
                        lblfinalreject.Text = (float.Parse(lblreject.Text) - 1).ToString();
                    }
                    else if (lblstatus.Text == "Reprocess")
                    {
                        lblfinalreprocess.Text = (float.Parse(lblreprocess.Text) - 1).ToString();
                    }
                    else if (lblstatus.Text == "Outright")
                    {
                        lblfinaloutright.Text = (float.Parse(lbloutright.Text) - 1).ToString();
                    }
                    else
                    {

                    }


                    if (cboStatus.Text == "Good")
                    {
                        lblfinalgood.Text = (float.Parse(lblgood.Text) + 1).ToString();

                    }
                    else if (cboStatus.Text == "Rejected")
                    {
                        lblfinalreject.Text = (float.Parse(lblreject.Text) + 1).ToString();
                    }
                    else if (cboStatus.Text == "Reprocess")
                    {
                        lblfinalreprocess.Text = (float.Parse(lblreprocess.Text) + 1).ToString();
                    }
                    else if (cboStatus.Text == "Outright")
                    {
                        lblfinaloutright.Text = (float.Parse(lbloutright.Text) + 1).ToString();
                    }
                    else
                    {

                    }

                    if (lblfinalgood.Text == "Good")
                    {
                        //lblfinalgood.Text = "0";
                        lblfinalgood.Text = (float.Parse(lblgood.Text) * 1).ToString();

                    }

                    if (lblfinalreprocess.Text == "Reprocess")
                    {
          /*              lblfinalreprocess.Text = "0"*/;
                        lblfinalreprocess.Text = (float.Parse(lblreprocess.Text) * 1).ToString();
                    }

                    if (lblfinalreject.Text == "Rejected")
                    {
                        //lblfinalreject.Text = "0";
                        lblfinalreject.Text = (float.Parse(lblreject.Text) * 1).ToString();
                    }

                    if (lblfinaloutright.Text == "Outright")
                    {
                        //lblfinaloutright.Text = "0";
                        lblfinaloutright.Text = (float.Parse(lbloutright.Text) * 1).ToString();
                    }


                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_prod_schedules(0, txtfg_id.Text, cboStatus.Text, txtremarks.Text, lbladdedby.Text, cboMixingCombination.Text, cboMixingCombination.Text, lblstatus.Text, lblfinaloutright.Text, lblstatus.Text, "", "","", "updatefgstatus");



                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_prod_schedules(0, txtproductionid.Text, lblfinalgood.Text, lblfinalreprocess.Text, lblfinalreject.Text, lblfinaloutright.Text, lblfinalreject.Text, lblfinalreprocess.Text, lblfinaloutright.Text, "", "", "","", "updateprodplanstatuscount");

                }

                    
                catch (Exception ex)
            {

                    MessageBox.Show(ex.Message);
            }

            TransFormedValidatedSuccess();
                btnReprocessclick.Visible = false;
                frmFGReprocessModule_Load(sender, e);
            }
            else
            {
                return;
            }



        }

        private void lblprod_id_Click(object sender, EventArgs e)
        {

        }

        private void dgvProdPlan_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgvProdPlan.RowCount > 0)
            {
                if (dgvProdPlan.CurrentRow != null)
                {
                    if (dgvProdPlan.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);
                    lblgood.Text = dgvProdPlan.CurrentRow.Cells["total_good_count"].Value.ToString();
                       lblreprocess.Text = dgvProdPlan.CurrentRow.Cells["total_reprocess_count"].Value.ToString();
                        lblreject.Text = dgvProdPlan.CurrentRow.Cells["total_reject_count"].Value.ToString();
                        lbloutright.Text = dgvProdPlan.CurrentRow.Cells["total_outright_count"].Value.ToString();
                    }

                }

            }
            }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void cboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if(cboStatus.Text =="Outright")
            {
                lblmixing.Visible = true;
               cboMixingCombination.Visible = true;
            }
            else if(cboStatus.Text == "Good")
            {

                lblmixing.Visible = false;
               cboMixingCombination.Visible = false;
                cboMixingCombination.Text="";
            }
            else if (cboStatus.Text == "Reprocess")
            {

                lblmixing.Visible = false;
                cboMixingCombination.Visible = false;
                cboMixingCombination.Text = "";
            }
            else if (cboStatus.Text == "Rejected")
            {

                lblmixing.Visible = false;
                cboMixingCombination.Visible = false;
                cboMixingCombination.Text = "";
            }
            else
            {

            }


        }
    }
}

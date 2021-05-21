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
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.IO;
using Tulpep.NotificationWindow;

namespace WFFDR
{

    public partial class frmFinishGoods : Form
    {
        //SqlCommand cmd;
        //SqlDataAdapter da;
        //DataTable dt;
        //DataSet ds = new DataSet();
        DataSet dSet_temp = new DataSet();

        DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();

        DataSet dSets = new DataSet();

        string mode = "";
        int p_id = 0;

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        ReportDocument rpt = new ReportDocument();
        string Rpt_Path = "";
        //declare as global
        int i;


        public frmFinishGoods()
        {
            InitializeComponent();
        }
        
        private void frmFinishGoods_Load(object sender, EventArgs e)
        {

            txtbagsprinting.Visible = false;
            txtactualremaining.Enabled = false;
            txtvariance.Enabled = false;
            crV1.Visible = true;

            radioButton1.Select();
         
            objStorProc = xClass.g_objStoredProc.GetCollections();
            //loadSchedulesDuplicate();
            load_Schedules();
            txtbagsprinting.Text = "0";
            bunifucheckcount_Click(sender, e);


            DateTime dNow = DateTime.Now;
            txtdatenow.Text = (dNow.ToString("M/d/yyyy"));
            txtaddedby.Text = userinfo.emp_name.ToUpper();

            loadPrintingData();

            //kick them  with the magic code

            if (txtminusbags.Text == "0")
            {
                //metroButton1_Click(sender, e);
                btnSaveFG.Visible = true;
                load_search();
                doSearch();
                doSearch2();
                bunifuThinButton26.Visible = false;
                bunifuSubmit.Visible = false;
                txtactualweight.Enabled = false;
                btnSave.Visible = false;
                txtvariance.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();
            }
            else
            {

                txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();
            }
            myglobal.global_module = "Active";
            load_search();



            if (lbltotalprod.Text == "0")
            {
                lblprod_id.Visible = false;
                groupBox1.Visible = false;
            }
            else
            {
                groupBox1.Visible = true;
                lblxx.Visible = false;
                lblyy.Visible = false;
                lblbagorbin.Visible = true;
                txttotalbags.Text = (float.Parse(txtbags.Text) - float.Parse(txttotalbulkentry.Text)).ToString();
                ShowRemaingBatchQuery();
                SumthetotalBulkandBag();
            

                if (txtbagsmonitoring.Text == "0")
                {

                }
                else
                {


                    txtvariance.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
                    GetPercentage2();

                }

            }





            doSearch8();

            btnSaveFG.Visible = false;
            bunifuThinButton26.Visible = true;


            radgood.Checked = true;
            if (radgood.Checked == true)
            {

                lblcurrentstatus.Text = "Good";
                bunifuThinButton26.Visible = true;
                btnReprocessbtn.Visible = false;
            }
            else
            {
                lblcurrentstatus.Text = "Reprocess";
            }
            if(lbltotalprod.Text=="0")
            {
                //
                return;
            }

            double a;
            double b;
            a = double.Parse(txtbags.Text);
            b = double.Parse(txtbagsprinting.Text);
            if (a > b)
            {
                //MessageBox.Show("Gerard");
                btnSaveFG.Visible = true;
            }
            else
            {
                //MessageBox.Show("Laarnie");
                //forNextPrevious();
                bunifuSubmit.Visible = false;
                return;
            }


            MonitoringSubtractBy();


            if (lbltotalprod.Text == "0")
            {
  
            }
            else
            {
                bunifuSubmit.Visible = true;
                PercentMasterData();
            }
            loadCode();
            lbldateformat.Text = (DateTime.Now.ToString("M/d/yyyy"));

            if(txtcurrentoutright.Text.Trim() == string.Empty)
            {

            }
            else
            {
                if(txtcurrentoutright.Text =="0")
                {

                }
                else
                {
                    radoutright.Checked = true;
                    radoutright_CheckedChanged( sender, e);
                }

            }

            //start

            loadBulk();
            btnSaveBulk.Visible = false;

      
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

        void loadBulk()
        {
            //ready = false;

            xClass.fillComboBoxWH(cmbBulk, "bulk_data_show", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            //ready = true;

        }


        void loadCode()
        {
            ready = false;

            xClass.fillComboBoxWH(cboCode, "rdf_code_fg", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;

        }



        void MonitoringSubtractBy()
            {

            
                double subtractbagsto5;
            double bagsmonitoring;
            subtractbagsto5 = double.Parse(lblminus5bags.Text);
            bagsmonitoring = double.Parse(txtbagsmonitoring.Text);
                if (subtractbagsto5 > bagsmonitoring)
                {
                //MessageBox.Show("True");
                btnSaveFG.Visible = false;
                }
                else
                {
                //MessageBox.Show("False");
                btnSaveFG.Visible = true;
                }


            }







        public void forNextPrevious()
        {





            label8.Visible = false;
            label7.Visible = false;
            bunifuThinButton28.Visible = false;
            txtactualcount.Visible = false;
            txtproductionbatch.Visible = false;
            bunifuThinButton214.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label6.Visible = false;
            txtoutofprobatch.Visible = false;
            txtbags2.Visible = false;
            bunifuThinButton213.Visible = false;
            bunifuThinButton215.Visible = false;
            if (lbltotalprod.Text == "0")
            {
                bunifuThinButton26.Visible = false;
                bunifuSubmit.Visible = false;
                bunifuThinButton216.Visible = false;
                label9.Visible = false;
                txtbagsprinting.Visible = false;
                txttotalbulkentry.Visible = false;
                txt.Visible = false;

                lbltotalbulk.Visible = false;
                lbltotalbagging.Visible = false;
                NoDataFound2();
            }
            else
            {


                label9.Visible = true;
                //txtbagsprinting.Visible = true;
                txttotalbulkentry.Visible = true;
                txt.Visible = true;

                lbltotalbulk.Visible = true;
                lbltotalbagging.Visible = true;



            }












            txtbagsprinting.Text = "0";
            bunifucheckcount_Click(new object(), new System.EventArgs());


            DateTime dNow = DateTime.Now;
            txtdatenow.Text = (dNow.ToString("M/d/yyyy"));
            txtaddedby.Text = userinfo.emp_name.ToUpper();

            loadPrintingData();



            if (txtminusbags.Text == "0")
            {
                //metroButton1_Click(sender, e);
                btnSaveFG.Visible = true;
                load_search();
                doSearch();
                doSearch2();
                bunifuThinButton26.Visible = false;
                bunifuSubmit.Visible = false;
                txtactualweight.Enabled = false;
                btnSave.Visible = false;
                txtvariance.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();
            }
            else
            {

                txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();
            }
            myglobal.global_module = "Active";
            load_search();



            if (lbltotalprod.Text == "0")
            {

            }
            else
            {
                lblxx.Visible = false;
                lblyy.Visible = false;

                txttotalbags.Text = (float.Parse(txtbags.Text) - float.Parse(txttotalbulkentry.Text)).ToString();



                if (txtbagsmonitoring.Text == "0")
                {

                }
                else
                {


                    txtvariance.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
                    GetPercentage2();

                }

            }





            doSearch8();

            btnSaveFG.Visible = false;
            bunifuThinButton26.Visible = true;


            //bagging else

            label15.Visible = false;

            bunifuThinButton218.Visible = false;


            txtactualweight.Enabled = false;
            bunifuSubmit.Visible = true;
            btnSave.Visible = false;
            label13.Visible = false;
            txtactualweight.Visible = false;
            bunifuThinButton217.Visible = false;


            label16.Visible = false;
            txtvariance.Visible = false;
            txtoptions.Text = "";



            //bulk else
            txtvariance.Visible = false;

            txtactualweight.Enabled = false;
            bunifuThinButton26.Visible = true;
            txtoptions.Text = "";
            btnSaveBulk.Visible = false;
            btnstockson.Visible = false;
            lblupdatestocks.Visible = false;
            txttotaltruckandmain.Visible = false;
            lblbulkentry.Visible = false;
            cmbBulk.Visible = false;
            bunifuThinButton29.Visible = false;
            label15.Visible = false;
            bunifuThinButton218.Visible = false;
            txtminusbags.Visible = false;
            label14.Visible = false;
            bunifuThinButton219.Visible = false;
            txtactualremaining.Visible = false;
            txttotaltruckandmain.Visible = false;
        }




        public void load_Schedules()
        {
            string mcolumns = "prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate,repacking_status,preparation_date_finish,macro_prep_status_date,finish_production_date,BMX_finish_date,bags_printing,remaining_batch,total_outright_count";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "isForFinishGoods");
            lbltotalprod.Text = dataView.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();

            label8.Visible = false;
            label7.Visible = false;
            bunifuThinButton28.Visible = false;
            txtactualcount.Visible = false;
            txtproductionbatch.Visible = false;
                bunifuThinButton214.Visible = false;
            label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label6.Visible = false;
            txtoutofprobatch.Visible = false;
                txtbags2.Visible = false;
            bunifuThinButton213.Visible = false;
                bunifuThinButton215.Visible = false;
            if(lbltotalprod.Text=="0")
            {
                bunifuThinButton26.Visible = false;
                bunifuSubmit.Visible = false;
                bunifuThinButton216.Visible = false;
                label9.Visible = false;
                    txtbagsprinting.Visible = false;
                txttotalbulkentry.Visible = false;
                txt.Visible = false;

                lbltotalbulk.Visible = false;
                lbltotalbagging.Visible = false;
                NoDataFound2();
            }
            else
            {


                label9.Visible = true;
                //txtbagsprinting.Visible = true;
                txttotalbulkentry.Visible = true;
                txt.Visible = true;

                lbltotalbulk.Visible = true;
                lbltotalbagging.Visible = true;



            }


        }


        public void loadSchedulesDuplicate()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_production_advance]  WHERE prod_id = '" + lblprod_id.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
           dgvduplicatedata.DataSource = dt;





            label8.Visible = false;
            label7.Visible = false;
            bunifuThinButton28.Visible = false;
            txtactualcount.Visible = false;
            txtproductionbatch.Visible = false;
            bunifuThinButton214.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label6.Visible = false;
            txtoutofprobatch.Visible = false;
            txtbags2.Visible = false;
            bunifuThinButton213.Visible = false;
            bunifuThinButton215.Visible = false;
            if (lbltotalprod.Text == "0")
            {
                bunifuThinButton26.Visible = false;
                bunifuSubmit.Visible = false;
                bunifuThinButton216.Visible = false;
                label9.Visible = false;
                txtbagsprinting.Visible = false;
                txttotalbulkentry.Visible = false;
                txt.Visible = false;

                lbltotalbulk.Visible = false;
                lbltotalbagging.Visible = false;
                NoDataFound2();
            }
            else
            {


                label9.Visible = true;
                //txtbagsprinting.Visible = true;
                txttotalbulkentry.Visible = true;
                txt.Visible = true;

                lbltotalbulk.Visible = true;
                lbltotalbagging.Visible = true;



            }


        }


        void NoDataFound2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "NO DATA FOUND " + txtaddedby.Text + "!";
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

            label19.Visible = false;
            txtbagsmonitoring.Visible = false;

            dataView.Visible = false;
            label1.Visible = false;
                lbltotalprod.Visible = false;
            bunifuThinButton212.Visible = false;
            lblinfo.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            lblpercentage.Visible = false;
            label3.Visible = false;
            label2.Visible = false;

                txtdate4.Visible = false;

                txtdate2.Visible = false;
            lblfeedcode.Visible = false;

                lblproddate.Visible = false;
                txtmainfeedcode.Visible = false;
                dtpproddate.Visible = false;


            txtfeedtype.Visible = false;

                lblfeedtype.Visible = false;

            lblbags.Visible = false;
            txtbags.Visible = false;
            lblbatch.Visible = false;

                txtnobatch.Visible = false;


                label4.Visible = false;
                txtdate1.Visible = false;
            label5.Visible = false;


                txtdate3.Visible = false;




            bunifuThinButton217.Visible = false;
            txtactualweight.Visible = false;
            label16.Visible = false;
            lblbulkentry.Visible = false;
            label15.Visible = false;
            txtminusbags.Visible = false;
            bunifuThinButton219.Visible = false;

            txtactualremaining.Visible = false;
            btnSave.Visible = false;
            btnSaveBulk.Visible = false;
            bunifuThinButton219.Visible = false;
                label14.Visible = false;
            bunifuThinButton29.Visible = false;
            cmbBulk.Visible = false;
            lblbulkentry.Visible = false;
            bunifuThinButton218.Visible = false;
            txtactualremaining.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            btnSaveFG.Visible = false;
            button1.Visible = false;
            bunifuThinButton26.Visible = false;
            panelCode.Visible = false;
            txtvariance.Visible = false;
            lblbagorbin.Visible = false;
        }
        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueDailyProduction();

  

        }

        void load_search()
        {

            dset_emp.Clear();
            dset_emp1.Clear();

            dset_emp8.Clear();

            //dset_emp = objStorProc.sp_getMajorTables("BulkEntrySum");

            dset_emp = objStorProc.sp_GetCategory("BulkEntrySum",0, txtprodid.Text,"","");

            //dset_emp1 = objStorProc.sp_getMajorTables("BagsEntrySum");
            doSearch();
            //doSearch2();


            //dset_emp8 = objStorProc.sp_getMajorTables("BaggingEntrySum");
            dset_emp8 = objStorProc.sp_GetCategory("BaggingEntrySum",0, txtprodid.Text,"","");

            //dset_emp1 = objStorProc.sp_getMajorTables("BagsEntrySum");
            doSearch8();

        }
        DataSet dset_emp = new DataSet();
        void doSearch()
        {
            try
            {
                if (dset_emp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp.Tables[0]);
                    //if (myglobal.global_module == "EMPLOYEE")
                    //{
                    //    //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    //}
                    //else if (myglobal.global_module == "Active")
                    //{

                    //    //dv.RowFilter = "prod_adv = '" + txtprodid.Text + "'";

                    //}
                    //else if (myglobal.global_module == "VISITORS")
                    //{
                    //    //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    //}
                    dgvbulkentry.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


            int sum = 0;
            for (int i = 0; i < dgvbulkentry.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvbulkentry.Rows[i].Cells[2].Value);
            }
            txttotalbulkentry.Text = sum.ToString();

         textBox1.Text = sum.ToString();

        }





        DataSet dset_emp8 = new DataSet();
        void doSearch8()
        {
            try
            {
                if (dset_emp8.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp8.Tables[0]);
                    //if (myglobal.global_module == "EMPLOYEE")
                    //{
                    //    //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    //}
                    //else if (myglobal.global_module == "Active")
                    //{

                    //    dv.RowFilter = "prod_adv = '" + txtprodid.Text + "'";

                    //}
                    //else if (myglobal.global_module == "VISITORS")
                    //{
                    //    //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    //}
                    dgvbagger.DataSource = dv;
                    txt.Text = dgvbagger.RowCount.ToString(); 
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


            //int sum = 0;
            //for (int i = 0; i < dgvbagger.Rows.Count; ++i)
            //{
            //    sum += Convert.ToInt32(dgvbagger.Rows[i].Cells[1].Value);
            //}
            //txt.Text = sum.ToString();

            //textBox1.Text = sum.ToString();

        }

















        DataSet dset_emp1 = new DataSet();
        void doSearch2()
        {
            //try
            //{
            //    if (dset_emp1.Tables.Count > 0)
            //    {
            //        DataView dv = new DataView(dset_emp1.Tables[0]);
            //        if (myglobal.global_module == "EMPLOYEE")
            //        {
            //            //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
            //        }
            //        else if (myglobal.global_module == "Active")
            //        {

            //            dv.RowFilter = "prod_adv = '" + txtprodid.Text + "'";

            //        }
            //        else if (myglobal.global_module == "VISITORS")
            //        {
            //            //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
            //        }
            //        dgvbags.DataSource = dv;
            //        //lblrecords.Text = dgv_table.RowCount.ToString();gerard
            //    }
            //}
            //catch (SyntaxErrorException)
            //{
            //    MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    return;
            //}
            //catch (EvaluateException)
            //{
            //    MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    return;
            //}


            //int sum = 0;
            //for (int i = 0; i < dgvbags.Rows.Count; ++i)
            //{
            //    sum += Convert.ToInt32(dgvbags.Rows[i].Cells[1].Value);
            //}
            //txttotalbags.Text = sum.ToString();


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
                        lblbagorbin.Text = dataView.CurrentRow.Cells["bagorbin"].Value.ToString();
                        dtpproddate.Text = dataView.CurrentRow.Cells["proddate"].Value.ToString();
                        txtprodid.Text = dataView.CurrentRow.Cells["prod_id"].Value.ToString();
                        txtdate3.Text = dataView.CurrentRow.Cells["macro_prep_status_date"].Value.ToString();
                        txtbags.Text = dataView.CurrentRow.Cells["p_bags"].Value.ToString();
                        txtnobatch.Text = dataView.CurrentRow.Cells["no_batch_in_production"].Value.ToString();
                        txtfeedtype.Text = dataView.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                        txtdate1.Text = dataView.CurrentRow.Cells["preparation_date_finish"].Value.ToString();
                        txtdate4.Text = dataView.CurrentRow.Cells["finish_production_date"].Value.ToString();
                        txtdate2.Text = dataView.CurrentRow.Cells["BMX_finish_date"].Value.ToString();
                        txtbagsprinting.Text = dataView.CurrentRow.Cells["bags_printing"].Value.ToString();
                        txtbags2.Text = dataView.CurrentRow.Cells["p_bags"].Value.ToString();
                        txtbagsmonitoring.Text = dataView.CurrentRow.Cells["bags_printing"].Value.ToString();
                        lblprod_id.Text = dataView.CurrentRow.Cells["prod_id"].Value.ToString();
                       txtcurrentoutright.Text = dataView.CurrentRow.Cells["total_outright_count"].Value.ToString();

                        lblbindata.Text = dataView.CurrentRow.Cells["additional_bin"].Value.ToString();
                    txtproductions.Text = dataView.CurrentRow.Cells["finish_production_date"].Value.ToString();

                        //txtremainingbatch.Text = dataView.CurrentRow.Cells["remaining_batch"].Value.ToString();
                    }

                }
            }

        }

        private void bunifucheckcount_Click(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                txtactualcount.Text = "1";
                return;
            }
            else
            {
                //txtactualcount.Text = "1";
                //return;

            }


            double mainbalance;
            mainbalance = double.Parse(txtactualcount.Text);
            if (mainbalance <= 40)
            {
                txtproductionbatch.Text = "1";
                txtoutofprobatch.Text = "40";
            }
            else if (mainbalance <= 80)
            {
                txtproductionbatch.Text = "2";
                txtoutofprobatch.Text = "80";
            }
            else if (mainbalance <= 120)
            {
                txtproductionbatch.Text = "3";
                txtoutofprobatch.Text = "120";
            }
            else if (mainbalance <= 160)
            {
                txtproductionbatch.Text = "4";
                txtoutofprobatch.Text = "160";
            }
            else if (mainbalance <= 200)
            {
                txtproductionbatch.Text = "5";
                txtoutofprobatch.Text = "200";
            }
            else if (mainbalance <= 240)
            {
                txtproductionbatch.Text = "6";
                txtoutofprobatch.Text = "240";
            }
            else if (mainbalance <= 280)
            {
                txtproductionbatch.Text = "7";
                txtoutofprobatch.Text = "280";
            }
            else if (mainbalance <= 320)
            {
                txtproductionbatch.Text = "8";
                txtoutofprobatch.Text = "320";
            }
            else if (mainbalance <= 360)
            {
                txtproductionbatch.Text = "9";
                txtoutofprobatch.Text = "360";
            }
            else if (mainbalance <= 400)
            {
                txtproductionbatch.Text = "10";
                txtoutofprobatch.Text = "400";
            }
            else if (mainbalance <= 440)
            {
                txtproductionbatch.Text = "11";
                txtoutofprobatch.Text = "440";
            }
            else if (mainbalance <= 480)
            {
                txtproductionbatch.Text = "12";
                txtoutofprobatch.Text = "480";
            }
            else if (mainbalance <= 520)
            {
                txtproductionbatch.Text = "13";
                txtoutofprobatch.Text = "520";
            }
            else if (mainbalance <= 560)
            {
                txtproductionbatch.Text = "14";
                txtoutofprobatch.Text = "560";
            }
            else if (mainbalance <= 600)
            {
                txtproductionbatch.Text = "15";
                txtoutofprobatch.Text = "600";
            }
            else if (mainbalance <= 640)
            {
                txtproductionbatch.Text = "16";
                txtoutofprobatch.Text = "640";
            }
            else if (mainbalance <= 680)
            {
                txtproductionbatch.Text = "17";
                txtoutofprobatch.Text = "680";
            }
            else if (mainbalance <= 720)
            {
                txtproductionbatch.Text = "18";
                txtoutofprobatch.Text = "720";
            }
            else if (mainbalance <= 760)
            {
                txtproductionbatch.Text = "19";
                txtoutofprobatch.Text = "760";
            }
            else if (mainbalance <= 800)
            {
                txtproductionbatch.Text = "20";
                txtoutofprobatch.Text = "800";
            }
            else if (mainbalance <= 840)
            {
                txtproductionbatch.Text = "21";
                txtoutofprobatch.Text = "840";
            }
            else if (mainbalance <= 880)
            {
                txtproductionbatch.Text = "22";
                txtoutofprobatch.Text = "880";
            }
            else if (mainbalance <= 920)
            {
                txtproductionbatch.Text = "23";
                txtoutofprobatch.Text = "920";
            }
            else if (mainbalance <= 960)
            {
                txtproductionbatch.Text = "24";
                txtoutofprobatch.Text = "960";
            }
            else if (mainbalance <= 1000)
            {
                txtproductionbatch.Text = "25";
                txtoutofprobatch.Text = "1000";
            }
            else
            {
                MessageBox.Show("Out of Range");
            }
            if (txtminus5.Text.Trim() == txtactualcount.Text.Trim())
            {
                //metroButton1_Click(sender, e);
                btnSaveFG.Visible = true;
                //bunifuThinButton26.Visible = false;
                //bunifuSubmit.Visible = false;
                load_search();
                    doSearch();
                doSearch2();
            }
            //if (txtbags.Text.Trim() == txtactualcount.Text.Trim())
            if (txtbags.Text.Trim() == txtbagsprinting.Text.Trim())
            {
                
                //metroButton1_Click(sender, e);
                btnSaveFG.Visible = true;
                //bunifuThinButton26.Visible = false; 7/23/2020 Gerard singian
                bunifuSubmit.Visible = false;
                txtactualweight.Enabled = false;
                btnSave.Visible = false;
                //btnSave.Enabled = false;
                load_search();
                doSearch();
                doSearch2();
            }
            else
            {
                txtactualweight.Enabled = true;
                //btnSave.Visible = true;
            }

    



        }

        private void txtactualcount_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtminus5.Text = (float.Parse(txtbags.Text) -5).ToString();

                if (txtbagsmonitoring.Text == "0")
                {
                    txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();
                }

                else
                {
                    txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();

                }


            }
            catch (Exception)
            {


            }
        }

        private void txtbagsprinting_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();
                bunifucheckcount_Click(sender, e);


            }
            catch (Exception)
            {


            }
            if (txtbagsprinting.Text.Trim() == string.Empty)
            {
                txtactualcount.Text = "";
            }
            else
            {
                if(lbltotalprod.Text=="0")
                {
                    return;
                }
                GetPercentage();
            }

            try
            {


                txtvariance.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();



            }
            catch (Exception)
            {


            }


        }

        private void txtbagsprinting_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (txtnobatch.Text.Trim() == txtremainingbatch.Text.Trim())
            {

            }
            else
            {
                AlreadyinProduction();

                return;
            }


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Save the Finished Goods of " + txtmainfeedcode.Text + " and the Variance is " + txtvariance.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                // start of computation of fg module

                ViewDataProduction();
                ViewCellChanger();

                DateTime time1 = DateTime.Parse(txtstartoffg.Text);
                DateTime time2 = DateTime.Parse(txtdatenowstamp.Text);

                TimeSpan difference = time2 - time1;



                txtSumofRepacking.Text = Convert.ToString(difference);

                ///end of computation


                //total hourse

                DateTime time12 = DateTime.Parse(lbldateaddedplanner.Text);
                DateTime time22 = DateTime.Parse(txtdatenowstamp.Text);

                TimeSpan difference2 = time22 - time12;



               lbltotalhours.Text = Convert.ToString(difference2);



                //start of computation of dayse

                DateTime proddate = DateTime.Parse(dtpproddate.Text);
                DateTime fgdate = DateTime.Parse(txtdatenow.Text);

                TimeSpan t = fgdate - proddate;
                double NrOfDays = t.TotalDays;

                if (txtbags.Text == "40")
                {
                    txtsumofdays.Text = Convert.ToString(NrOfDays);
                }
                else
                {
                    txtsumofdays.Text = Convert.ToString(NrOfDays);
                }

                //end of days

                //will swap the variance value inline into the invalid concern occur by the user

                txtvariance.Text = (float.Parse(txtbagsmonitoring.Text) - float.Parse(txtbags.Text)).ToString();

                QueryTryCatchProdTimes();
                mode = "add";
                if (txtaddedby.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Fill out all the required Textbox", "Message Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                    return;

                }
                else
                {
                    load_search();
                    doSearch();
                    //if (lbltotalprod.Text == "0")

                    //else
                    //{

                    //    lblxx.Visible = false;
                    //    lblyy.Visible = false;

                    //    txttotalbags.Text = (float.Parse(txtbags.Text) - float.Parse(txttotalbulkentry.Text)).ToString();

                    //    if (txttotalbulkentry.Text=="0")
                    //    {
                    //        txttotalbags.Text = (float.Parse(txtbagsprinting.Text) * 1).ToString();
                    //    }
                    //    //else
                    //    //{
                    //        txttotalbulkentry.Text = (float.Parse(txttotalbulkentry.Text) - float.Parse(txtvariance.Text)).ToString();
             
                    //    //gago

                    //}

                    //if(txttotalbulkentry.Text=="0")
                    //{
                    //    txttotalbulkentry.Text = "0";
                    //}
                    //else
                    //{



                    //}

                    //if (txttotalbulkentry.Text.StartsWith("-"))
                    //{

                    //    txttotalbulkentry.Text = "0";

                    //}


                        if (saveMode2())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];

                            dgvPrint.Visible = true;
                            //loadPrintingData();5/11
                            //dgvPrint.Rows[i].Cells["selected"].Value = true;11
                            button65.Enabled = true;

         


                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

          

                    }
                    else
                    {
                        //MessageBox.Show("Failed");
                    }
              

                }
                //SaveNotifyFG();


                //3 query function james foul
                ViewDataProduction();
                ViewCellChanger();

                QueryTryCatchProdTimes();

                //4 karat
                dSet = objStorProc.rdf_sp_new_preparation(0, txtmainfeedcode.Text, txtaddedby.Text, "7.1 Finish Goods Module", "Finished Goods the Production", txtdatenowstamp.Text, lblprod_id.Text, txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");





                txtmainfeedcode_TextChanged(sender, e);
                load_Schedules();
                //button65_Click(sender, e);
                doSearch8();




                if(lbltotalprod.Text=="0")
                {
                    timer1_Tick(new object(), new System.EventArgs());
                }
                else
                {
                    timer1.Stop();
                }


         





                    //{

            }
            else
            {
                return;
            }


            if(lbltotalprod.Text=="0")
            {
                label14.Visible = false;
            }
            ShowRemaingBatchQuery(); // out 
            frmFinishGoods_Load(sender, e);
        }
        //}




        void ViewCellChanger()
        {


            if (dgvUpdateTimeLampse.RowCount > 0)
            {
                if (dgvUpdateTimeLampse.CurrentRow != null)
                {
                    if (dgvUpdateTimeLampse.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);

                        txtstartoffg.Text = dgvUpdateTimeLampse.CurrentRow.Cells["start_fg_processs"].Value.ToString();

                        lbldateaddedplanner.Text = dgvUpdateTimeLampse.CurrentRow.Cells["aproved_date_time"].Value.ToString();

                    }

                }
            }
            //version 2

            txtdatenowstamp.Text = DateTime.Now.ToString();


            //if (lblcountfg.Text == "0")
            //{

            //}
            //else
            //{
            //    DateTime time1 = DateTime.Parse(txtstartoffg.Text);
            //    DateTime time2 = DateTime.Parse(txtdatenowstamp.Text);

            //    TimeSpan difference = time1 - time2;



            //    txtSumofRepacking.Text = Convert.ToString(difference);

            //}









        }







        void ViewDataProduction()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_production_advance] WHERE prod_id= '" + lblprod_id.Text + "' AND is_selected='1' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();

            lblcountfg.Text = dgvUpdateTimeLampse.RowCount.ToString();



        }





        void QueryTryCatchProdTimes()
        {
            txtdatenowstamp.Text = DateTime.Now.ToString();
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET fg_time='" + txtSumofRepacking.Text + "', total_hours='"+lbltotalhours.Text+"' WHERE prod_id= '" + lblprod_id.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();




        }









        void SaveNotifyFG()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Finished Good barcode receipt already print...";
            popup.ContentColor = Color.White;
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
            //txtactualweight.Text="";
            //txtactualweight.Select();
            //txtactualweight.Focus();

        }

        void SaveNotifyBULK()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FINISHED GOODS BULK ENTRY SUCCESSFULLY SAVE ,BARCODE IS READY FOR PRINTING";
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
            //txtactualweight.Text = "";
            //txtactualweight.Select();
            //txtactualweight.Focus();

        }



        void SaveNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FINISHED GOODS SUCCESSFULLY SAVE !";
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
            //txtactualweight.Text = "";
            //txtactualweight.Select();
            //txtactualweight.Focus();
            btnSaveFG.Visible = false;

            if(lbltotalprod.Text=="0")
            {

            }
            else
            {
                bunifuThinButton26.Visible = true;
                bunifuSubmit.Visible = true;
                btnSaveFG.Visible = false;
            }
        }

        public void loadPrintingData()
        {


            if (myClass.g_objStoredProc.getConnected() == true)
            {
                g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

                dset = g_objStoredProcCollection.sp_IDGenerator(0, "SelectHR", "", "", 1);
                dset2 = g_objStoredProcCollection.sp_IDGenerator(1, "SelectCompany", "", "", 1);

                Rpt_Path = WFFDR.Properties.Settings.Default.fdg;

                //Rpt_Path = ini.IniReadValue("PATH", "Report_Path");

                xClass.ActivitiesLogs(userinfo.emp_name + " Generated " + myglobal.REPORT_NAME + " Report");
            }
            else
            {
                MessageBox.Show("Unable to connect in sql server", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }



            int number_of_rows = dset2.Tables[0].Rows.Count - 1;


     

            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchFG", "All", txtSearchx.Text, 1);
            dgvPrint.DataSource = dset.Tables[0];

            //dset = g_objStoredProcCollection.sp_IDGenerator(1, "Search", "All", txtSearch.Text, 1);
            //dataView.DataSource = dset.Tables[0];

            for (int i = 0; i <= dgvPrint.RowCount; i++)
            {
                try
                {
                    dgvPrint.Rows[i].Cells["selected"].Value = false;
                }
                catch (Exception) { }
            }

            try
            {
                //cmbHR_OIC.SelectedIndex = cmbHR_OIC.FindString("Rollaine Palo");
            }
            catch (Exception) { }

            rbt_check();


        }


        void rbt_check()
        {
            if (radioButton1.Checked == true)
            {
                mode = "company";
            }
            else if (radioButton2.Checked == true)
            {
                mode = "hw";
            }
        }

        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_finish_goods(0, txtprodid.Text, txtmainfeedcode.Text, txtfeedtype.Text,txtbags.Text,txtnobatch.Text,dtpproddate.Text,txtdate1.Text,"", "","","","","","","","","","","","","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    //MessageBox.Show("Raw Material Repacking is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //submit button that will be disabled 

                    dSets = objStorProc.rdf_sp_new_finish_goods(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), txtfeedtype.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), dtpproddate.Text.Trim(), txtdate1.Text.Trim(), txtdate2.Text.Trim(), txtdate3.Text.Trim(), txtdate4.Text, "1", txtaddedby.Text.Trim(), txtactualweight.Text.Trim(), lblnumplusone.Text.Trim(), txtactualcount.Text.Trim(), txtbagsprinting.Text.Trim(), txtproductionbatch.Text.Trim(), txtoutofprobatch.Text.Trim(), "Bagging",lblcurrentstatus.Text.Trim(),lbldateformat.Text.Trim(),cboCode.Text.Trim(), "add");
                
                    SaveNotifyFG();
                    //load_Schedules();
                    loadSchedulesDuplicate();
                    BindDuplicateData();
                    loadPrintingData();
                    dgvPrint.Rows[i].Cells["selected"].Value = true;
           
                    return false;
                }

                else
                {
                    dSet.Clear();

                    //goal muna ko to gagu!5/11/2020

                    dSets = objStorProc.rdf_sp_new_finish_goods(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), txtfeedtype.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), dtpproddate.Text.Trim(), txtdate1.Text.Trim(), txtdate2.Text.Trim(), txtdate3.Text.Trim(), txtdate4.Text, "1", txtaddedby.Text.Trim(), txtactualweight.Text.Trim(), lblnumplusone.Text.Trim(), txtactualcount.Text.Trim(), txtbagsprinting.Text.Trim(), txtproductionbatch.Text.Trim(), txtoutofprobatch.Text.Trim(), "Bagging", lblcurrentstatus.Text.Trim(), lbldateformat.Text.Trim(), cboCode.Text.Trim(), "add");


                    SaveNotifyFG();
                    //load_Schedules();
                    loadSchedulesDuplicate();
                    BindDuplicateData();
                    loadPrintingData();
                    dgvPrint.Rows[i].Cells["selected"].Value = true;
                    return false;  //return true
                }
            }


            if (mode == "addbulk")
            {
                lbldateformat.Text = (DateTime.Now.ToString("M/d/yyyy"));
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_finish_goods(0, txtprodid.Text, txtmainfeedcode.Text, txtfeedtype.Text, txtbags.Text, txtnobatch.Text, dtpproddate.Text, txtdate1.Text, "", "", "", "", "", "", "", "", "", "", "", "","","","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    //MessageBox.Show("Raw Material Repacking is already added.", "Raw Materials", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //submit button that will be disabled 

                    dSets = objStorProc.rdf_sp_new_finish_goods(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), txtfeedtype.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), dtpproddate.Text.Trim(), txtdate1.Text.Trim(), txtdate2.Text.Trim(), txtdate3.Text.Trim(), txtdate4.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), lblnumplusone.Text.Trim(), txttotaltruckandmain.Text.Trim(), txtbagsprinting.Text.Trim(), txtproductionbatch.Text.Trim(), cmbBulk.Text.Trim(), txtoptions.Text.Trim(),"Good",lbldateformat.Text.Trim(),"0", "addbulk");
                    SaveNotifyBULK();
                    //txtotaltrcukmain vs cmbulk
                    //load_Schedules();//pekpek
                    loadSchedulesDuplicate();
                    BindDuplicateData();
                    loadPrintingData();
                    dgvPrint.Rows[i].Cells["selected"].Value = true;
                    btnSaveBulk.Visible = false;
                    return false;
                }

                else
                {
                    dSet.Clear();

                    //goal muna ko to gagu!5/11/2020

                    dSets = objStorProc.rdf_sp_new_finish_goods(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), txtfeedtype.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), dtpproddate.Text.Trim(), txtdate1.Text.Trim(), txtdate2.Text.Trim(), txtdate3.Text.Trim(), txtdate4.Text, "1", txtaddedby.Text.Trim(), txttimes50.Text.Trim(), lblnumplusone.Text.Trim(), txttotaltruckandmain.Text.Trim(), txtbagsprinting.Text.Trim(), txtproductionbatch.Text.Trim(), cmbBulk.Text.Trim(), txtoptions.Text.Trim(), lblcurrentstatus.Text.Trim(), lbldateformat.Text.Trim(), "0", "addbulk");

                    SaveNotifyBULK();
                    //load_Schedules();/pekpek
                    loadSchedulesDuplicate();
                    BindDuplicateData();
                    loadPrintingData();
                    dgvPrint.Rows[i].Cells["selected"].Value = true;
                    btnSaveBulk.Visible = false;
                    return false;  //return true
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                /// dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyname");

                dSet_temp.Clear();
                /// dSet_temp = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyid");

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
            return false;
        }

        public bool saveMode2()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_FG(0, txtprodid.Text, txtmainfeedcode.Text, txtfeedtype.Text, txtbags.Text, txtnobatch.Text, dtpproddate.Text, txtdate1.Text, "", "","", "", "","", "", "", "", "", "", 0,0,0,lblpercentage.Text,txtsumofdays.Text, "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {


                    //txttotalbags
                    //dSets = objStorProc.rdf_sp_new_FG(0,txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), dtpproddate.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), txtfeedtype.Text.Trim(), txtdate1.Text.Trim(), txtdate2.Text.Trim(), txtdate3.Text.Trim(), txtdate4.Text.Trim(), txtbagsprinting.Text, txtactualcount.Text.Trim(), txtproductionbatch.Text.Trim(), txtoutofprobatch.Text.Trim(), txtoptions.Text.Trim(), txtbulkentry.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), Convert.ToInt32(txtvariance.Text), Convert.ToInt32(txttotalbulkentry.Text), Convert.ToInt32(txttotalbags.Text),lblpercentage.Text.Trim(), "add");
                    dSets = objStorProc.rdf_sp_new_FG(0, txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), dtpproddate.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), txtfeedtype.Text.Trim(), txtdate1.Text.Trim(), txtdate2.Text.Trim(), txtdate3.Text.Trim(), txtdate4.Text.Trim(), txtbagsprinting.Text, txtactualcount.Text.Trim(), txtproductionbatch.Text.Trim(), txtoutofprobatch.Text.Trim(), txtoptions.Text.Trim(), txtbulkentry.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), Convert.ToInt32(txtvariance.Text), Convert.ToInt32(txttotalbulkentry.Text), Convert.ToInt32(txt.Text), lblpercentage.Text.Trim(), txtsumofdays.Text.Trim(), "add");
                    SaveNotify();
                    load_Schedules();
            
     

                    return false;
                }

                else
                {
                    dSet.Clear();

                    //goal muna ko to gagu!5/11/2020

                    dSets = objStorProc.rdf_sp_new_FG(0,txtprodid.Text.Trim(), txtmainfeedcode.Text.Trim(), dtpproddate.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), txtfeedtype.Text.Trim(), txtdate1.Text.Trim(), txtdate2.Text.Trim(), txtdate3.Text.Trim(), txtdate4.Text.Trim(), txtbagsprinting.Text.Trim(), txtactualcount.Text.Trim(), txtproductionbatch.Text.Trim(), txtoutofprobatch.Text.Trim(), txtoptions.Text.Trim(), txtbulkentry.Text.Trim(), txtdatenow.Text.Trim(), txtaddedby.Text.Trim(), Convert.ToInt32(txtvariance.Text), Convert.ToInt32(txttotalbulkentry.Text), Convert.ToInt32(txt.Text),lblpercentage.Text.Trim(), txtsumofdays.Text.Trim(), "add");
                    //txttotalbags==txtbagsprinting

                    SaveNotify();
                    load_Schedules();
       
                    return false;  //return true
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                /// dSet = objStorProc.rdf_sp_supplier(0, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyname");

                dSet_temp.Clear();
                /// dSet_temp = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text, txtContactNo.Text, txtAddress.Text, txtEmailAddress.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
 


                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Offense code is already added.", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return false;
                    }
                }
                else
                {
                    dSet.Clear();



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
            return false;
        }


















        void Lessthan50kg()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING LESS THAN 50 KILOGRAM !";
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

        void FillupEmptyFields()
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
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }




        void AlreadyinProduction()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Cannot be save because it's already in the production area";
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










        void Lessthan50kgVariance()
        {
            double mainbalance;
            double answer;
            mainbalance = double.Parse(txtactualweight.Text);
            answer = mainbalance - 50;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Variance Found ! "+answer+"";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkOrange;
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            txtmainfeedcode_TextChanged(sender, e);
            dgvCount_CurrentCellChanged(sender, e);

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Print the Barcode of " + txtmainfeedcode.Text + "? ", "Barcode GOOD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                txtmainfeedcode_TextChanged(sender, e);
                dgvCount_CurrentCellChanged(sender, e);


                if (txtbags.Text.Trim() == txtbagsprinting.Text.Trim())
                {
                    metroaddionalbags_Click(sender, e);
                }

                double a;
                double b;
                a = double.Parse(txtbags.Text);
                b = double.Parse(txtbagsprinting.Text);
                if (a > b)
                {
                    //MessageBox.Show("Gerard");

                }
                else
                {


                    if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Proceed the Bagging of " + txtmainfeedcode.Text + ", because is greathan than the actual bagging ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {


                    }
                    else
                    {
                        return;
                    }


                }

                //loadSchedulesDuplicate();

                mode = "add";
                if (txtactualweight.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Fill out all the required Textbox", "Message Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtactualweight.Select();
                    txtactualweight.Focus();
                    return;

                }
                else
                {

                    //double mainbalance;
                    //mainbalance = double.Parse(txtactualweight.Text);
                    //if (mainbalance < 51)
                    //{

                    //    Lessthan50kgVariance(); //pekpek
                    //}
                    //else
                    //{
                    //    txtactualweight.Text = "";
                    //    Lessthan50kg();
                    //    txtactualweight.Select();
                    //    txtactualweight.Focus();
                    //    return;
                    //}


                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();
                    }

                    else
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
                        //txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) * 1).ToString();
                        txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) + 1).ToString();

                    }

                    //for the new update fg Good!
                    if (radgood.Checked == true)
                    {
                        lblcurrentstatus.Text = "Good";
                    }
                    else if (radreprocess.Checked == true)
                    {
                        lblcurrentstatus.Text = "Reprocess";
                    }
                    else if (radreject.Checked == true)
                    {
                        lblcurrentstatus.Text = "Rejected";
                    }
                    else
                    {

                    }


                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtvariance.Text = (float.Parse(txtbags.Text) - 1).ToString();
                    }
                    else
                    {


                        txtvariance.Text = (float.Parse(txtvariance.Text) - 1).ToString();
                    }
                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];




                            //MessageBox.Show("BaseMixed  SuccesFully Saved.", "Raw Material Basemixed for Printing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //SaveNotifyFG();

                            //load_RawNMaster(); Close MUna itech

                            dgvPrint.Visible = true;
                            //loadPrintingData();5/11
                            //dgvPrint.Rows[i].Cells["selected"].Value = true;11
                            button65.Enabled = true;

                            //BtnSave.Enabled = false;
                            //button65_Click(sender, e);//4/27/2020 buje


                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        /// btnCancel_Click(sender, e);

                    }
                    else
                    {
                        //MessageBox.Show("Failed");
                    }
                    //MessageBox.Show("Failed");

                }
                SearchTheTotalOutRight();
                //SaveNotifyFG();
                SearchTheTotalReprocess();
                //2
                FGGood();
                //3
                FGReject();

                UpdateProductionSchedule();
                //laravel



                txtmainfeedcode_TextChanged(sender, e);
                txtactualweight.Enabled = false;
                //rpt.Refresh();
                //crV1.Refresh();
                button65_Click(sender, e);
                ShowRemaingBatchQuery(); // out 
                txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();
                load_search();
                doSearch();
                doSearch2();

                if (txtbagsmonitoring.Text == "0")
                {

                }
                else
                {
                    txtminus5.Text = (float.Parse(txtvariance.Text) * 1).ToString();
                }

                if (txtbagsmonitoring.Text == "0")
                {
                    GetPercentage();
                }
                else
                {
                    GetPercentage2();
                }
                doSearch8();

                bunifuSubmit.Visible = false;
                radgood.Checked = true;
                //if (radgood.Checked == true)
                //{

                //    lblcurrentstatus.Text = "Good";
                //    bunifuThinButton26.Visible = true;
                //    btnReprocessbtn.Visible = false;
                //}
                //else
                //{
                //    lblcurrentstatus.Text = "Reprocess";
                //}
                if (radgood.Checked == true)
                {

                    lblcurrentstatus.Text = "Good";
                    bunifuThinButton26.Visible = true;
                    btnReprocessbtn.Visible = false;
                    bunifuSubmit.Visible = false;
                    btnRejected.Visible = false;
                }
                else if (radreject.Checked == true)
                {
                    bunifuSubmit.Visible = false;
                    lblcurrentstatus.Text = "Rejected";
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = false;
                    btnRejected.Visible = true;
                }
                else if (radreprocess.Checked == true)
                {
                    bunifuSubmit.Visible = false;
                    lblcurrentstatus.Text = "Reprocess";
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = true;
                    btnRejected.Visible = false;
                }



                else
                {
                    lblcurrentstatus.Text = "Reprocess";
                }
                if (panelCode.Visible == true)
                {
                    bunifuSubmit.Visible = false;
                }
                loadSchedulesDuplicate();

                BindDuplicateData();

                MonitoringSubtractBy();
                btnReprintGood.Visible = true;
                btngoodreprint.Visible = true;
                btnReprintReprocess.Visible = false;
                btnReprintReject.Visible = false;
                SumthetotalBulkandBag();
            }
            else
            {
                return;
            }
        }

        private void txtactualweight_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnSave_Click(sender, e);
            //}
        }

        private void btnSaveFG_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //initation of the entry
            txtmainfeedcode_TextChanged(sender, e);
            dgvCount_CurrentCellChanged(sender, e);

            if (MetroFramework.MetroMessageBox.Show(this, "Start the process of Bagging, Finished Goods of " + txtmainfeedcode.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtcurrentoutright.Text.Trim() == string.Empty)
                {

                }
                else
                {
                    if (txtcurrentoutright.Text == "0")
                    {
                        panelCode.Enabled = true;
                    }
                    else
                    {
                        radoutright.Checked = true;
                        radoutright_CheckedChanged(sender, e);
                        panelCode.Enabled = false;


                    }

                }




                bunifuThinButton26.BackColor = Color.CornflowerBlue;
      
                txtoptions.Text = "BAGGING";
                bunifuSubmit.Visible = false;
                label16.Visible = true;
                label13.Visible = true;
                txtactualweight.Visible = true;
                bunifuThinButton217.Visible = true;
                btnSave.Visible = true;
                txtactualweight.Text = "50";
  
                bunifuThinButton218.Visible = true;
                label15.Visible = true;
                txtvariance.Visible = true;
                label15.Text = "AVAILABLE FOR BAGGING ENTRY";
                panelCode.Visible = true;
                txtactualweight.Enabled = false;
                if (txtbags.Text.Trim() == txtbagsprinting.Text.Trim())
                {
                    //metroButton1_Click(sender, e);
       
                    txtactualweight.Enabled = false;
                    //btnSave.Visible = false;
          
                }
                //txtactualweight.Select();
                //txtactualweight.Focus();
            }
            else
            {
                //showValueDailyProduction(); 8/3/2020
                //MessageBox.Show(txtbags.Text);
                //MessageBox.Show(txtbagsprinting.Text);
                double a;
                double b;
                a = double.Parse(txtbags.Text);
                b = double.Parse(txtbagsprinting.Text);
                if (a > b)
                {
                    //MessageBox.Show("Gerard");
                }
                else
                {
                    //MessageBox.Show("Laarnie");
                    //forNextPrevious();
                    bunifuSubmit.Visible = false;
                    return;
                }

                panelCode.Visible = false;
                label15.Text = "AVAILABLE FOR BULK WEIGHT";
                label15.Visible = false;

                bunifuThinButton218.Visible = false;

                bunifuThinButton26.BackColor = Color.LightGray;
                txtactualweight.Enabled = false;
                bunifuSubmit.Visible = true;
                btnSave.Visible = false;
                label13.Visible = false;
                txtactualweight.Visible = false;
                bunifuThinButton217.Visible = false;


                label16.Visible = false;
                txtvariance.Visible = false;
                txtoptions.Text = "";
                btnoutright.Visible = false;
                return;
            }
        }
        void GetPercentage()
        {
            double lblx;
            double lbly;
            lblx = double.Parse(txtbags.Text);
            lbly = double.Parse(txtbagsprinting.Text);

            lblxx.Text = Math.Round(lblx, 5).ToString("#,0.00");
            lblyy.Text = Math.Round(lbly, 5).ToString("#,0.00");

            double actualbags;
            double bags;
            double sagot;
            double final;
         
          bags = double.Parse(lblxx.Text);
          actualbags = double.Parse(lblyy.Text);


            sagot = actualbags / bags;
            final = sagot * (double)100;
            //getdata = final + 25;

            //lblpercentage.Text = (double.Parse(txtbagsprinting.Text) / 120).ToString();
            //txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();

            //lblpercentage.Text = Convert.ToString(final);
       
            lblpercentage.Text = Math.Round(final, 1).ToString();
        }

        void GetPercentage2()
        {
            double lblx;
            double lbly;
            lblx = double.Parse(txtbags.Text);
            lbly = double.Parse(txtbagsmonitoring.Text);

            lblxx.Text = Math.Round(lblx, 5).ToString("#,0.00");
            lblyy.Text = Math.Round(lbly, 5).ToString("#,0.00");

            double actualbags;
            double bags;
            double sagot;
            double final;

            bags = double.Parse(lblxx.Text);
            actualbags = double.Parse(lblyy.Text);


            sagot = actualbags / bags;
            final = sagot * (double)100;
            //getdata = final + 25;

            //lblpercentage.Text = (double.Parse(txtbagsprinting.Text) / 120).ToString();
            //txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();

            //lblpercentage.Text = Convert.ToString(final);

            lblpercentage.Text = Math.Round(final, 1).ToString();
        }
        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                bunifuThinButton26.Visible = false;
                return;
            }
            metroButton2_Click(sender, e);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            double mainbalance;
            double sagot;
            mainbalance = double.Parse(txtactualcount.Text);
            sagot = mainbalance - 1;

            //DialogResult dialogResult = MessageBox.Show("Printing the Finished Good Barcode  '" + sagot + "' ", "One of a Time Printing!", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
                for (int i = 0; i <= dgvPrint.RowCount - 1; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dgvPrint.Rows[i].Cells["selected"].Value.ToString()) == true)
                        {
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 1);
                        }
                        else
                        {
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                        }
                    }
                    catch
                    {

                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                    }

                }


                //txtactualweight.Enabled = true;
                button65.Visible = false;
                //txtactualweight.Select();
                //txtactualweight.Focus();

                //if (mode == "company")
                //{
                    //myglobal.REPORT_NAME = "IDRepackReport";

                    PrintDialog printDialog = new PrintDialog();
                    //if (printDialog.ShowDialog() == DialogResult.OK)

                    //{
                        //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        //rpt.Load(Rpt_Path + "\\IDFGMAIN.rpt");
                        //rpt.Load(Rpt_Path + "\\IDFGMAIN.rpt");
                rpt.Load(Rpt_Path + "\\MainFgPrintingBarcode.rpt");
                rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
                //printDialog.AllowCurrentPage = true;


                        //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
                        //////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                        rpt.Refresh();

                        //crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";






                        //rpt.SetParameterValue("Approved", myglobal.rp_item_description);
                        //rpt.SetParameterValue("Validity", myglobal.validity);
                        //rpt.SetParameterValue("Position", myglobal.position);

                        crV1.ReportSource = rpt;
                        crV1.Refresh();



                        rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                        rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);


                    //}

                    //button65.Enabled = false;


                //}
                //else if (mode == "hw")
                //{
                //    myglobal.REPORT_NAME = "IDReport(HW)";
                //}


            //    else if (dialogResult == DialogResult.No)
            //    {
            //        button65.Visible = true;
            //        return;



            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        button65.Visible = true;
            //        return;



            //    }
            //}
                //else if (mode == "hw")
                //{
                //    myglobal.REPORT_NAME = "IDReport(HW)";
                ////}
                //}

            }

        void Print()
        {

            double mainbalance;
            double sagot;
            mainbalance = double.Parse(txtactualcount.Text);
            sagot = mainbalance - 1;

            //DialogResult dialogResult = MessageBox.Show("Printing the Finished Good Barcode  '" + sagot + "' ", "One of a Time Printing!", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            for (int i = 0; i <= dgvPrint.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dgvPrint.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                }

            }


            //txtactualweight.Enabled = true;
            button65.Visible = false;
            //txtactualweight.Select();
            //txtactualweight.Focus();

            //if (mode == "company")
            //{
            //myglobal.REPORT_NAME = "IDRepackReport";

            PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == DialogResult.OK)

            //{
            //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //rpt.Load(Rpt_Path + "\\IDFGMAIN.rpt");
            //rpt.Load(Rpt_Path + "\\IDFGMAIN.rpt");
            rpt.Load(Rpt_Path + "\\MainFgPrintingBarcodeReprocess.rpt");
            rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
            //printDialog.AllowCurrentPage = true;


            //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
            //////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
            rpt.Refresh();

            //crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";






            //rpt.SetParameterValue("Approved", myglobal.rp_item_description);
            //rpt.SetParameterValue("Validity", myglobal.validity);
            //rpt.SetParameterValue("Position", myglobal.position);

            crV1.ReportSource = rpt;
            crV1.Refresh();



            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);


            //}

            //button65.Enabled = false;


            //}
            //else if (mode == "hw")
            //{
            //    myglobal.REPORT_NAME = "IDReport(HW)";
            //}


            //    else if (dialogResult == DialogResult.No)
            //    {
            //        button65.Visible = true;
            //        return;



            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        button65.Visible = true;
            //        return;



            //    }
            //}
            //else if (mode == "hw")
            //{
            //    myglobal.REPORT_NAME = "IDReport(HW)";
            ////}
            //}
        }





        void PrintOutright()
        {

            double mainbalance;
            double sagot;
            mainbalance = double.Parse(txtactualcount.Text);
            sagot = mainbalance - 1;

            //DialogResult dialogResult = MessageBox.Show("Printing the Finished Good Barcode  '" + sagot + "' ", "One of a Time Printing!", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            for (int i = 0; i <= dgvPrint.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dgvPrint.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                }

            }


            //txtactualweight.Enabled = true;
            button65.Visible = false;
            //txtactualweight.Select();
            //txtactualweight.Focus();

            //if (mode == "company")
            //{
            //myglobal.REPORT_NAME = "IDRepackReport";

            PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == DialogResult.OK)

            //{
            //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //rpt.Load(Rpt_Path + "\\IDFGMAIN.rpt");
            //rpt.Load(Rpt_Path + "\\IDFGMAIN.rpt");
            rpt.Load(Rpt_Path + "\\MainFgPrintingBarcodeOutright.rpt");
            rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
            //printDialog.AllowCurrentPage = true;


            //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
            //////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
            rpt.Refresh();

            //crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";






            //rpt.SetParameterValue("Approved", myglobal.rp_item_description);
            //rpt.SetParameterValue("Validity", myglobal.validity);
            //rpt.SetParameterValue("Position", myglobal.position);

            crV1.ReportSource = rpt;
            crV1.Refresh();



            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);


            //}

            //button65.Enabled = false;


            //}
            //else if (mode == "hw")
            //{
            //    myglobal.REPORT_NAME = "IDReport(HW)";
            //}


            //    else if (dialogResult == DialogResult.No)
            //    {
            //        button65.Visible = true;
            //        return;



            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        button65.Visible = true;
            //        return;



            //    }
            //}
            //else if (mode == "hw")
            //{
            //    myglobal.REPORT_NAME = "IDReport(HW)";
            ////}
            //}
        }





        void PrintAllFG()
        {

            double mainbalance;
            double sagot;
            mainbalance = double.Parse(txtactualcount.Text);
            sagot = mainbalance - 1;


            for (int i = 0; i <= dgvPrint.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dgvPrint.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                }

            }


            //txtactualweight.Enabled = true;
            button65.Visible = false;
            //txtactualweight.Select();
            //txtactualweight.Focus();

            //if (mode == "company")
            //{
            //myglobal.REPORT_NAME = "IDRepackReport";

            PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == DialogResult.OK)



            rpt.Load(Rpt_Path + "\\MainFgPrintingBarcodeAll.rpt");
            rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
            //printDialog.AllowCurrentPage = true;


            rpt.Refresh();



            crV1.ReportSource = rpt;
            crV1.Refresh();



            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);


        }



        void Print2()
        {

            double mainbalance;
            double sagot;
            mainbalance = double.Parse(txtactualcount.Text);
            sagot = mainbalance - 1;


            for (int i = 0; i <= dgvPrint.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dgvPrint.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                }

            }


            button65.Visible = false;

            PrintDialog printDialog = new PrintDialog();

            rpt.Load(Rpt_Path + "\\MainFgPrintingBarcodeRejected.rpt");
            rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
            //printDialog.AllowCurrentPage = true;



            rpt.Refresh();








            crV1.ReportSource = rpt;
            crV1.Refresh();



            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);



        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvCount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCount_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvCount.RowCount > 0)
            {
                if (dgvCount.CurrentRow != null)
                {
                    if (dgvCount.CurrentRow.Cells["Column1"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["prod_id"].Value);


                        lbltotalmicro.Text = dgvCount.CurrentRow.Cells["Column1"].Value.ToString();

                        txtbola.Text = dgvCount.CurrentRow.Cells["Column1"].Value.ToString();






                        //txtrecommendedsearch.Text = dgvMaster.CurrentRow.Cells["item_code"].Value.ToString();
                        //txtqtyoverall.Text = dgvMaster.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                        //txtmainstocks.Text = dgvMaster.CurrentRow.Cells["total_quantity_raw"].Value.ToString();

                        //cboCategor.Text = dgvMaster.CurrentRow.Cells["item_description"].Value.ToString();






                        //wala muna this


                    }

                }
                lblnumplusone.Text = (float.Parse(lbltotalmicro.Text) + 1).ToString();
            }

        }

        private void txtmainfeedcode_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            // AND rp_category='MICRO' ORDER BY rp_group
            string sqlquery = "SELECT IDENT_CURRENT('rdf_repackin_finishgoods') ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvCount.DataSource = dt;

            sql_con.Close(); //4//29/2020
        }


        public void nextHideBIN()

        {

            txtvariance.Visible = false;
            //bunifuSubmit.BackColor = Color.LightGray;
            txtactualweight.Enabled = false;
            bunifuThinButton26.Visible = true;
            txtoptions.Text = "";
            btnSaveBulk.Visible = false;
            btnstockson.Visible = false;
            lblupdatestocks.Visible = false;
            txttotaltruckandmain.Visible = false;
            lblbulkentry.Visible = false;
            cmbBulk.Visible = false;
            bunifuThinButton29.Visible = false;
            label15.Visible = false;
            bunifuThinButton218.Visible = false;
            txtminusbags.Visible = false;
            label14.Visible = false;
            bunifuThinButton219.Visible = false;
            txtactualremaining.Visible = false;
            txttotaltruckandmain.Visible = false;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Start the Process of Bulk Entry, Finished Goods of " + txtmainfeedcode.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if(lbltotalprod.Text=="0")
                {
                    cmbBulk.Enabled = false;
                    return;
                }
                txttotaltruckandmain.Visible = false;
                bunifuSubmit.BackColor = Color.CornflowerBlue;
         
                txtoptions.Text = "BULK ENTRY";
                bunifuThinButton26.Visible = false;

                lblbulkentry.Visible = true;
                cmbBulk.Visible = true;
                bunifuThinButton29.Visible = true;
                label15.Visible = true;
                bunifuThinButton218.Visible = true;
                //txtminusbags.Visible = true;
                txtvariance.Visible = true;
                label14.Visible = true;
                bunifuThinButton219.Visible = true;
                txtactualremaining.Visible = true;
                //txttotaltruckandmain.Visible = true;
                //lblupdatestocks.Visible = true;
                //btnstockson.Visible = true;

                if (txtbags.Text.Trim() == txtbagsprinting.Text.Trim())
                {
                    //metroButton1_Click(sender, e);

                    txtactualweight.Enabled = false;
                    cmbBulk.Enabled = false;
                }


              

            }
            else
            {
                txtvariance.Visible = false;
                bunifuSubmit.BackColor = Color.LightGray;
                txtactualweight.Enabled = false;
                bunifuThinButton26.Visible = true;
                txtoptions.Text = "";
                btnSaveBulk.Visible = false;
                btnstockson.Visible = false;
                lblupdatestocks.Visible = false;
                txttotaltruckandmain.Visible = false;
                lblbulkentry.Visible = false;
                cmbBulk.Visible = false;
                bunifuThinButton29.Visible = false;
                label15.Visible = false;
                bunifuThinButton218.Visible = false;
                txtminusbags.Visible = false;
                label14.Visible = false;
                bunifuThinButton219.Visible = false;
                txtactualremaining.Visible = false;
                txttotaltruckandmain.Visible = false;
                return;
            }
        }

        private void bunifuSubmit_Click(object sender, EventArgs e)
        {
            metroButton3_Click(sender, e);
        }

        private void txtactualweight_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void cmbBulk_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cmbBulk.Text.Trim() == string.Empty)
            {

            }
            else
            {
                if (cmbBulk.Text == "System.Data.DataRowView")
                {

                }
                else
                {//start



                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();

                        txtactualremaining.Text = (float.Parse(txtminusbags.Text) - float.Parse(cmbBulk.Text)).ToString();



                    }
                    else
                    {
                        //txtactualremaining.Text = (float.Parse(txtvariance.Text) - float.Parse(cmbBulk.Text)).ToString();
                        //MessageBox.Show(cmbBulk.Text);
                        //return;
                        //if (lblsaiyan.Text =="1")
                        //{
                        txtactualremaining.Text = (float.Parse(txtvariance.Text) - float.Parse(cmbBulk.Text)).ToString();


                    }
                    txttotaltruckandmain.Text = (float.Parse(txtbagsprinting.Text) + float.Parse(cmbBulk.Text)).ToString();
                    txttimes50.Text = (float.Parse(cmbBulk.Text) * 50).ToString();








                    //if (txtactualremaining.Text.StartsWith("-"))
                    //{
                    //    btnSaveBulk.Visible = false;
                    //}
                    //else
                    //{
                    //    btnSaveBulk.Visible = true;
                    //}






                    if (txtactualremaining.Text.StartsWith("-"))
                    {
                        //btnSaveBulk.Visible = false;
                        btnSaveBulk.Visible = true;
                    }
                    else
                    {
                        btnSaveBulk.Visible = true;
                        btnSaveBulk.Visible = true;
                    }

                }//end
            }

            }

        private void metroButton4_Click(object sender, EventArgs e)
        {



            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Save the Bulk Entry, Finished Goods of " + txtmainfeedcode.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                txtmainfeedcode_TextChanged(sender, e);
                dgvCount_CurrentCellChanged(sender, e);

                mode = "addbulk";
                if (txtactualremaining.Text.Trim() == string.Empty)
                {
                    FillupEmptyFields();
                    return;

                }
                else
                {



                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();
                    }

                    else
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
                        //txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) * 1).ToString();
                        txttotaltruckandmain.Text = (float.Parse(txtbagsmonitoring.Text) + float.Parse(cmbBulk.Text)).ToString();

                    }


                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "addbulk")
                        {
                      




                            dgvPrint.Visible = true;
             
                            button65.Enabled = true;

               


                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        /// btnCancel_Click(sender, e);

                    }
                    else
                    {
                        //MessageBox.Show("Failed");
                    }
                    //MessageBox.Show("Failed");

                }
                //SaveNotifyFG();

                txtmainfeedcode_TextChanged(sender, e);
                txtactualweight.Enabled = false;
                //button65_Click(sender, e);
                //rpt.Refresh();
                //crV1.Refresh();
                btnprintBulk_Click(sender,e);

                ShowRemaingBatchQuery(); // out 

                if (txtminusbags.Text == "0")
                {
                    //metroButton1_Click(sender, e);
                    btnSaveFG.Visible = true;
                    load_search();
                    doSearch();
                    doSearch2();
                    txtactualweight.Enabled = false;
                    btnSave.Visible = false;
                }

                load_search();
                doSearch();
                doSearch2();
                if (txtbagsmonitoring.Text == "0")
                {
                    GetPercentage();
                }
                else
                {
                    GetPercentage2();
                }


            }
            else
            {
                return;
            }

            showValueDailyProduction();
            if (txtbagsmonitoring.Text == "0")
            {

            }
            else
            {
                txtvariance.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
    txtactualremaining.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
            }
           


            if(txtbags.Text.Trim() == txtbagsmonitoring.Text.Trim())
            {
                btnSaveFG.Visible = true;
            }


            BindDuplicateData();
            ShowRemaingBatchQuery(); // out 
            SumthetotalBulkandBag();
            NextSave();

        }

        private void btnSaveBulk_Click(object sender, EventArgs e)
        {
            txtmainfeedcode_TextChanged(sender, e);
            dgvCount_CurrentCellChanged(sender, e);

            if (txtactualremaining.Text.StartsWith("-"))
            {
                //btnSaveBulk.Visible = false;

                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Save the Bulk Entry, Finished Goods of " + txtmainfeedcode.Text + " at variance of "+txtactualremaining.Text+"? ", "BIN Variance", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {


                }

                else
                {
                    return;

                }




            }
            else
            {
                btnSaveBulk.Visible = true;
            }






            metroButton4_Click(sender, e);
        }

        private void cmbBulk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnprintBulk_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Printing the Finished Good Barcode  '" + txtactualcount.Text + "' ", "One of a Time Printing!", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
                for (int i = 0; i <= dgvPrint.RowCount - 1; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dgvPrint.Rows[i].Cells["selected"].Value.ToString()) == true)
                        {
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 1);
                        }
                        else
                        {
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                        }
                    }
                    catch
                    {

                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvPrint.Rows[i].Cells["ID"].Value.ToString()), "updatefg", "", "", 0);
                    }

                }


                //txtactualweight.Enabled = true;
                //button65.Visible = false;
                //txtactualweight.Select();
                //txtactualweight.Focus();

                //if (mode == "company")
                //{
                    //myglobal.REPORT_NAME = "IDRepackReport";

                    PrintDialog printDialog = new PrintDialog();
                    //if (printDialog.ShowDialog() == DialogResult.OK)

                    //{

                        //rpt.Load(Rpt_Path + "\\IDFGMAINBULKENTRY.rpt");

                        rpt.Load(Rpt_Path + "\\MainFgBulkPrinting.rpt");
                        rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
                        //printDialog.AllowCurrentPage = true;


                        //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
                        //////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                        rpt.Refresh();

                        //crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";






                        //rpt.SetParameterValue("Approved", myglobal.rp_item_description);
                        //rpt.SetParameterValue("Validity", myglobal.validity);
                        //rpt.SetParameterValue("Position", myglobal.position);

                        crV1.ReportSource = rpt;
                        crV1.Refresh();



                        rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                        rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);


                    //}

                    //button65.Enabled = false;


                //}
                //else if (mode == "hw")
                //{
                //    myglobal.REPORT_NAME = "IDReport(HW)";
                //}


                //else if (dialogResult == DialogResult.No)
                //{
                //    button65.Visible = true;
                //    return;



                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    button65.Visible = true;
                //    return;



                //}
            //}
            //else if (mode == "hw")
            //{
            //    myglobal.REPORT_NAME = "IDReport(HW)";
            ////}
            //}

        }

        private void txtactualremaining_TextChanged(object sender, EventArgs e)
        {

            txtvariance.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
            //txtvariance.Text = (float.Parse(txtbags.Text) - float.Parse(txtactualcount.Text)).ToString();
        }

        private void txtbags2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvbulkentry_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvbulkentry.RowCount > 0)
            {
                if (dgvbulkentry.CurrentRow != null)
                {
                    if (dgvbulkentry.CurrentRow.Cells["prod_adv"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        //txttotalbulkentry.Text = dgvbulkentry.CurrentRow.Cells["Column1"].Value.ToString();


                    }

                }
            }
        }

        private void dgvbulkentry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtminusbags_TextChanged(object sender, EventArgs e)
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

        private void txtbagsmonitoring_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //3/8/2021
            //timer1.Start();
            //if(lbltotalprod.Text=="0")
            //{
            //    load_Schedules();
            //    btnSaveFG.Visible = false;
            //}
            //else

            //{



            //    timer1.Stop();
    
            //}
        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                bunifuThinButton26.Visible = false;
                return;
            }

            panelCode.Visible = false;
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
            radgood.Checked = true;
            if (radgood.Checked == true)
            {

                lblcurrentstatus.Text = "Good";
                bunifuThinButton26.Visible = true;
                btnReprocessbtn.Visible = false;
            }
            else
            {
                lblcurrentstatus.Text = "Reprocess";
            }
            forNextPrevious();
            panelCode.Visible = false;
            showValueDailyProduction();

            double a;
            double b;
            a = double.Parse(txtbags.Text);
            b = double.Parse(txtbagsprinting.Text);
            if (a > b)
            {
                //MessageBox.Show("Gerard");
                btnSaveFG.Visible = false;
            }
            else
            {
                //MessageBox.Show("Laarnie");
                //forNextPrevious();
                //btnSaveFG.Visible = false;
                bunifuSubmit.Visible = true;
                //return;
            }



            loadSchedulesDuplicate();

            MonitoringSubtractBy();

            if (txtbagsmonitoring.Text == "0")
            {
             txtactualremaining.Text = (float.Parse(txtbags.Text) * 1).ToString();
            }


            BindDuplicateData();
            ShowRemaingBatchQuery(); // out 
            SumthetotalBulkandBag();
            NextSave();



            if (txtcurrentoutright.Text.Trim() == string.Empty)
            {
                panelCode.Enabled = true;
            }
            else
            {
                if (txtcurrentoutright.Text == "0")
                {
                    panelCode.Enabled = true;
                }
                else
                {
                    radoutright.Checked = true;
                    radoutright_CheckedChanged(sender, e);
                    btnoutright.Visible = false;
                    panelCode.Enabled = false;
                }

            }
            loadCode();
        }


        void NextSave()
        {
            double a;
            double b;
            a = double.Parse(txtbags.Text);
            b = double.Parse(txtbagsmonitoring.Text);
            if (a > b)
            {
                //MessageBox.Show("Gerard");
                btnSaveFG.Visible = false;
            }
            else
            {
                //MessageBox.Show("Laarnie");
                //forNextPrevious();
                btnSaveFG.Visible = true;

                //bunifuSubmit.Visible = false; deepo 12/4/2020
                return;
            }
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
        private void btngreaterthan_Click(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                bunifuThinButton26.Visible = false;
                return;
            }
            else
            {
                SumthetotalBulkandBag();
            }

            panelCode.Visible = false;
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
            radgood.Checked = true;
            if (radgood.Checked == true)
            {

                lblcurrentstatus.Text = "Good";
                bunifuThinButton26.Visible = true;
                btnReprocessbtn.Visible = false;
            }
            else
            {
                lblcurrentstatus.Text = "Reprocess";
            }

            forNextPrevious();
            showValueDailyProduction();
            //MessageBox.Show(txtbags.Text);
            //MessageBox.Show(txtbagsprinting.Text);
            double a;
            double b;
            a = double.Parse(txtbags.Text);
            b = double.Parse(txtbagsprinting.Text);
            if (a > b)
            {
                //MessageBox.Show("Gerard");
                btnSaveFG.Visible = false;
            }
            else
            {
                //MessageBox.Show("Laarnie");
                //forNextPrevious();
                btnSaveFG.Visible = true;
                bunifuSubmit.Visible = false;
                return;
            }

            loadSchedulesDuplicate();
            MonitoringSubtractBy();
            if (txtbagsmonitoring.Text == "0")
            {
                txtactualremaining.Text = (float.Parse(txtbags.Text) * 1).ToString();
            }

            BindDuplicateData();
            BindDuplicateData();
            ShowRemaingBatchQuery(); // out 

            NextSave();//dont disable

            if (txtcurrentoutright.Text.Trim() == string.Empty)
            {
                panelCode.Enabled = true;
            }
            else
            {
                if (txtcurrentoutright.Text == "0")
                {
                    panelCode.Enabled = true;
                }
                else
                {
                    radoutright.Checked = true;
                    radoutright_CheckedChanged(sender, e);
                    btnoutright.Visible = false;
                    panelCode.Enabled = false;
                }

            }
            loadCode();
        }

        private void lblprod_id_Click(object sender, EventArgs e)
        {
        
        }
        void ShowRemaingBatchQuery()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_production]  WHERE prod_id = '" + lblprod_id.Text + "' ORDER BY product_id DESC";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRemainingProd.DataSource = dt;






        }



        private void radreprocess_CheckedChanged(object sender, EventArgs e)
        {
            if(radreprocess.Checked==true)
            {
                bunifuSubmit.Visible = false;
                lblcurrentstatus.Text = "Reprocess";
              btnSave.Visible = false;
                btnReprocessbtn.Visible = true;
                btnRejected.Visible = false;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
                cboCode.Text = "0";
            }
            else if (radreject.Checked == true)
            {
                bunifuSubmit.Visible = false;
                lblcurrentstatus.Text = "Rejected";
                btnSave.Visible = false;
                btnReprocessbtn.Visible = false;
                btnRejected.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
                cboCode.Text = "0";
            }
            else if (radgood.Checked == true)
            {
                bunifuSubmit.Visible = true;

                lblcurrentstatus.Text = "Good";
                btnSave.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
                cboCode.Text = "0";
            }


            else
            {
                bunifuSubmit.Visible = true;

                lblcurrentstatus.Text = "Good";
                btnSave.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
                cboCode.Text = "0";
            }








        }

        private void radgood_CheckedChanged(object sender, EventArgs e)
        {
            if (radgood.Checked == true)
            {

                lblcurrentstatus.Text = "Good";
                bunifuThinButton26.Visible = true;
                btnReprocessbtn.Visible = false;
                bunifuSubmit.Visible = false;
                btnRejected.Visible = false;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
                cboCode.Text = "0";
            }
            else if (radreject.Checked == true)
            {
                bunifuSubmit.Visible = false;
                lblcurrentstatus.Text = "Rejected";
                btnSave.Visible = false;
                btnReprocessbtn.Visible = false;
                btnRejected.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
            }
            else if (radreprocess.Checked == true)
            {
                bunifuSubmit.Visible = false;
                lblcurrentstatus.Text = "Reprocess";
                btnSave.Visible = false;
                btnReprocessbtn.Visible = true;
                btnRejected.Visible = false;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
                cboCode.Text = "0";
            }



            else
            {
                lblcurrentstatus.Text = "Reprocess";
                cboCode.Text = "0";
            }
        }

        private void bunifuThinButton220_Click(object sender, EventArgs e)
        {
            button65_Click(sender, e);
        }

        private void btnReprocessbtn_Click(object sender, EventArgs e)
        {

            txtmainfeedcode_TextChanged(sender, e);
            dgvCount_CurrentCellChanged(sender, e);

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Print the Barcode of " + txtmainfeedcode.Text + "? ", "Barcode REPROCESS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                txtmainfeedcode_TextChanged(sender, e);
                dgvCount_CurrentCellChanged(sender, e);

                if (txtbags.Text.Trim() == txtbagsprinting.Text.Trim())
                {
                    metroaddionalbags_Click(sender, e);
                }


                double a;
                double b;
                a = double.Parse(txtbags.Text);
                b = double.Parse(txtbagsprinting.Text);
                if (a > b)
                {
                    //MessageBox.Show("Gerard");

                }
                else
                {


                    if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Proceed the Bagging of " + txtmainfeedcode.Text + ", because is greathan than the actual bagging ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {


                    }
                    else
                    {
                        return;
                    }


                }














                mode = "add";
                if (txtactualweight.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Fill out all the required Textbox", "Message Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtactualweight.Select();
                    txtactualweight.Focus();
                    return;

                }
                else
                {

                    //double mainbalance;
                    //mainbalance = double.Parse(txtactualweight.Text);
                    //if (mainbalance < 51)
                    //{

                    //    Lessthan50kgVariance(); //pekpek
                    //}
                    //else
                    //{
                    //    txtactualweight.Text = "";
                    //    Lessthan50kg();
                    //    txtactualweight.Select();
                    //    txtactualweight.Focus();
                    //    return;
                    //}


                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();
                    }

                    else
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
                        //txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) * 1).ToString();
                        txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) + 1).ToString();

                    }


                    //if (radgood.Checked == true)
                    //{

                    //    lblcurrentstatus.Text = "Good";
                    //}
                    //else
                    //{
                    //    lblcurrentstatus.Text = "Reprocess";
                    //}



                    //for the new update fg Good!
                    if (radgood.Checked == true)
                    {
                        lblcurrentstatus.Text = "Good";
                    }
                    else if (radreprocess.Checked == true)
                    {
                        lblcurrentstatus.Text = "Reprocess";
                    }
                    else if (radreject.Checked == true)
                    {
                        lblcurrentstatus.Text = "Rejected";
                    }
                    else
                    {

                    }




                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtvariance.Text = (float.Parse(txtbags.Text) - 1).ToString();
                    }
                    else
                    {
                        txtvariance.Text = (float.Parse(txtvariance.Text) - 1).ToString();
                    }

                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];




                            //MessageBox.Show("BaseMixed  SuccesFully Saved.", "Raw Material Basemixed for Printing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //SaveNotifyFG();

                            //load_RawNMaster(); Close MUna itech

                            dgvPrint.Visible = true;
                            //loadPrintingData();5/11
                            //dgvPrint.Rows[i].Cells["selected"].Value = true;11
                            button65.Enabled = true;

                            //BtnSave.Enabled = false;
                            //button65_Click(sender, e);//4/27/2020 buje


                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        /// btnCancel_Click(sender, e);

                    }
                    else
                    {
                        //MessageBox.Show("Failed");
                    }
                    //MessageBox.Show("Failed");

                }
                SearchTheTotalOutRight();
                //SaveNotifyFG();
                SearchTheTotalReprocess();
                //2
                FGGood();
                //3
                FGReject();

                UpdateProductionSchedule();
                //laravel

                txtmainfeedcode_TextChanged(sender, e);
                txtactualweight.Enabled = false;
                //rpt.Refresh();
                //crV1.Refresh();
                Print();
                ShowRemaingBatchQuery(); // out 
                txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();
                load_search();
                doSearch();
                doSearch2();


                //txtminus5.Text = (float.Parse(txtvariance.Text) * 1).ToString();
                if (txtbagsmonitoring.Text == "0")
                {

                }
                else
                {
                    txtminus5.Text = (float.Parse(txtvariance.Text) * 1).ToString();
                }

                if (txtbagsmonitoring.Text == "0")
                {
                    GetPercentage();
                }
                else
                {
                    GetPercentage2();
                }
                doSearch8();

                bunifuSubmit.Visible = false;
                radgood.Checked = true;
                //if (radgood.Checked == true)
                //{

                //    lblcurrentstatus.Text = "Good";
                //    bunifuThinButton26.Visible = true;
                //    btnReprocessbtn.Visible = false;
                //}
                //else
                //{
                //    lblcurrentstatus.Text = "Reprocess";
                //}
                //if(panelCode.Visible==true)
                //{
                //    bunifuSubmit.Visible = false;
                //}
                if (radreprocess.Checked == true)
                {
                    bunifuSubmit.Visible = false;
                    lblcurrentstatus.Text = "Reprocess";
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = true;
                    btnRejected.Visible = false;
                }
                else if (radreject.Checked == true)
                {
                    bunifuSubmit.Visible = false;
                    lblcurrentstatus.Text = "Rejected";
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = false;
                    btnRejected.Visible = true;
                }
                else if (radgood.Checked == true)
                {
                    bunifuSubmit.Visible = true;

                    lblcurrentstatus.Text = "Good";
                    btnSave.Visible = true;
                }


                else
                {
                    bunifuSubmit.Visible = true;

                    lblcurrentstatus.Text = "Good";
                    btnSave.Visible = true;
                }

                if (panelCode.Visible == true)
                {
                    bunifuSubmit.Visible = false;
                }

                MonitoringSubtractBy();
                btnReprintReprocess.Visible = true;
                btnReprintGood.Visible = false;
                btnReprintReject.Visible = false;
                btngoodreprint.Visible = false;

                SumthetotalBulkandBag();
            }
            else
            {
                return;
            }
        }

        private void metroaddionalbags_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Proceed the Bagging of " + txtmainfeedcode.Text + ", because is greathan than the actual bagging ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


            }
            else
            {
                return;
            }

            }

        private void radreject_CheckedChanged(object sender, EventArgs e)
        {
            if (radreprocess.Checked == true)
            {
                bunifuSubmit.Visible = false;
                lblcurrentstatus.Text = "Reprocess";
                btnSave.Visible = false;
                btnReprocessbtn.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
            }
            else if(radreject.Checked == true)
            {
                bunifuSubmit.Visible = false;
                lblcurrentstatus.Text = "Rejected";
                btnSave.Visible = false;
                btnReprocessbtn.Visible = false;
                btnRejected.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
                cboCode.Text = "0";
            }
            else if (radgood.Checked == true)
            {
                bunifuSubmit.Visible = true;

                lblcurrentstatus.Text = "Good";
                btnSave.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
            }
            else if (radoutright.Checked == true)
            {
               btnoutright.Visible = true;

                lblcurrentstatus.Text = "Outright";
                cboCode.Visible = true;
                lblcombi.Visible = true;
                btnoutright.Visible = true;
            }

            else
            {
                bunifuSubmit.Visible = true;

                lblcurrentstatus.Text = "Good";
                btnSave.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
                cboCode.Text = "0";
            }


        }

        private void btnRejected_Click(object sender, EventArgs e)
        {

            txtmainfeedcode_TextChanged(sender, e);
            dgvCount_CurrentCellChanged(sender, e);

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Print the Barcode of " + txtmainfeedcode.Text + "? ", "Barcode REJECTED", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {

                txtmainfeedcode_TextChanged(sender, e);
                dgvCount_CurrentCellChanged(sender, e);


                if (txtbags.Text.Trim() == txtbagsprinting.Text.Trim())
                {
                    metroaddionalbags_Click(sender, e);
                }

                double a;
                double b;
                a = double.Parse(txtbags.Text);
                b = double.Parse(txtbagsprinting.Text);
                if (a > b)
                {
                    //MessageBox.Show("Gerard");

                }
                else
                {


                    if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Proceed the Bagging of " + txtmainfeedcode.Text + ", because is greathan than the actual bagging ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {


                    }
                    else
                    {
                        return;
                    }


                }








                mode = "add";
                if (txtactualweight.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Fill out all the required Textbox", "Message Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtactualweight.Select();
                    txtactualweight.Focus();
                    return;

                }
                else
                {

                    //double mainbalance;
                    //mainbalance = double.Parse(txtactualweight.Text);
                    //if (mainbalance < 51)
                    //{

                    //    Lessthan50kgVariance(); //pekpek
                    //}
                    //else
                    //{
                    //    txtactualweight.Text = "";
                    //    Lessthan50kg();
                    //    txtactualweight.Select();
                    //    txtactualweight.Focus();
                    //    return;
                    //}


                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();
                    }

                    else
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
                        //txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) * 1).ToString();
                        txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) + 1).ToString();

                    }

                    if (radreprocess.Checked == true)
                    {
                        bunifuSubmit.Visible = false;
                        lblcurrentstatus.Text = "Reprocess";
                        btnSave.Visible = false;
                        btnReprocessbtn.Visible = true;
                    }
                    else if (radreject.Checked == true)
                    {
                        bunifuSubmit.Visible = false;
                        lblcurrentstatus.Text = "Rejected";
                        btnSave.Visible = false;
                        btnReprocessbtn.Visible = false;
                        btnRejected.Visible = true;
                    }
                    else if (radgood.Checked == true)
                    {
                        bunifuSubmit.Visible = true;

                        lblcurrentstatus.Text = "Good";
                        btnSave.Visible = true;
                    }

                    else
                    {
                        bunifuSubmit.Visible = true;

                        lblcurrentstatus.Text = "Good";
                        btnSave.Visible = true;
                    }



                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtvariance.Text = (float.Parse(txtbags.Text) - 1).ToString();
                    }
                    else
                    {
                        txtvariance.Text = (float.Parse(txtvariance.Text) - 1).ToString();
                    }

                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];




                            //MessageBox.Show("BaseMixed  SuccesFully Saved.", "Raw Material Basemixed for Printing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //SaveNotifyFG();

                            //load_RawNMaster(); Close MUna itech

                            dgvPrint.Visible = true;
                            //loadPrintingData();5/11
                            //dgvPrint.Rows[i].Cells["selected"].Value = true;11
                            button65.Enabled = true;

                            //BtnSave.Enabled = false;
                            //button65_Click(sender, e);//4/27/2020 buje


                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        /// btnCancel_Click(sender, e);

                    }
                    else
                    {
                        //MessageBox.Show("Failed");
                    }
                    //MessageBox.Show("Failed");

                }
                //SaveNotifyFG();

                txtmainfeedcode_TextChanged(sender, e);
                txtactualweight.Enabled = false;
                //rpt.Refresh();
                //crV1.Refresh();
                //SaveNotifyFG();
                SearchTheTotalOutRight();

                SearchTheTotalReprocess();
                //2
                FGGood();
                //3
                FGReject();

                UpdateProductionSchedule();
                //laravel



                Print2();
                ShowRemaingBatchQuery(); // out 
                txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();
                load_search();
                doSearch();
                doSearch2();


                //txtminus5.Text = (float.Parse(txtvariance.Text) * 1).ToString();

                if (txtbagsmonitoring.Text == "0")
                {

                }
                else
                {
                    txtminus5.Text = (float.Parse(txtvariance.Text) * 1).ToString();
                }

                if (txtbagsmonitoring.Text == "0")
                {
                    GetPercentage();
                }
                else
                {
                    GetPercentage2();
                }
                doSearch8();

                bunifuSubmit.Visible = false;
                radgood.Checked = true;
                if (radreprocess.Checked == true)
                {
                    bunifuSubmit.Visible = false;
                    lblcurrentstatus.Text = "Reprocess";
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = true;
                }
                else if (radreject.Checked == true)
                {
                    bunifuSubmit.Visible = false;
                    lblcurrentstatus.Text = "Rejected";
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = false;
                    btnRejected.Visible = true;
                }
                else if (radgood.Checked == true)
                {
                    bunifuSubmit.Visible = true;

                    lblcurrentstatus.Text = "Good";
                    btnSave.Visible = true;
                }

                else
                {
                    bunifuSubmit.Visible = true;

                    lblcurrentstatus.Text = "Good";
                    btnSave.Visible = true;
                }

                if (panelCode.Visible == true)
                {
                    bunifuSubmit.Visible = false;
                }
                MonitoringSubtractBy();
                btnReprintReject.Visible = true;
                btnReprintGood.Visible = false;
                btnReprintReprocess.Visible = false;
                btngoodreprint.Visible = false;
                SumthetotalBulkandBag();
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Refresh the FG Module " + txtaddedby.Text + "? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {



                frmFinishGoods_Load(sender, e);
            }
            else
            {
                return;
            }
        }

        private void dgvduplicatedata_CurrentCellChanged(object sender, EventArgs e)
        {
            //BindDuplicateData();
        }

        void BindDuplicateData()

        {

            if (dgvduplicatedata.RowCount > 0)
            {
                if (dgvduplicatedata.CurrentRow != null)
                {
                    if (dgvduplicatedata.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        //txtmainfeedcode.Text = dgvduplicatedata.CurrentRow.Cells["p_feed_code"].Value.ToString();
                        //lblbagorbin.Text = dataView.CurrentRow.Cells["bagorbin"].Value.ToString();
                        //dtpproddate.Text = dataView.CurrentRow.Cells["proddate"].Value.ToString();
                        //txtprodid.Text = dataView.CurrentRow.Cells["prod_id"].Value.ToString();
                        //txtdate3.Text = dataView.CurrentRow.Cells["macro_prep_status_date"].Value.ToString();
                        //txtbags.Text = dataView.CurrentRow.Cells["p_bags"].Value.ToString();
                        //txtnobatch.Text = dataView.CurrentRow.Cells["no_batch_in_production"].Value.ToString();
                        //txtfeedtype.Text = dataView.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                        //txtdate1.Text = dataView.CurrentRow.Cells["preparation_date_finish"].Value.ToString();
                        //txtdate4.Text = dataView.CurrentRow.Cells["finish_production_date"].Value.ToString();
                        //txtdate2.Text = dataView.CurrentRow.Cells["BMX_finish_date"].Value.ToString();
                        //txtbagsprinting.Text = dataView.CurrentRow.Cells["bags_printing"].Value.ToString();
                        //txtbags2.Text = dataView.CurrentRow.Cells["p_bags"].Value.ToString();
                        txtbagsmonitoring.Text = dgvduplicatedata.CurrentRow.Cells["bags_printing"].Value.ToString();
                        lblprod_id.Text = dgvduplicatedata.CurrentRow.Cells["prod_id"].Value.ToString();
                    }

                }
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();

            loadSchedulesDuplicate();
            txtbagsmonitoring.Text = dgvduplicatedata.CurrentRow.Cells["bags_printing"].Value.ToString();
            lblprod_id.Text = dgvduplicatedata.CurrentRow.Cells["prod_id"].Value.ToString();

            //load_search();
        }

        private void txtbags_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblminus5bags.Text = (float.Parse(txtbags.Text) - 5).ToString();
            }
            catch (Exception)
            {


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

        private void btnReprintReject_Click(object sender, EventArgs e)
        {
            metroReprint_Click(sender, e);
            //crV1.Refresh();
    
        }

        private void metroReprint_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Would you like to reprint the previous reject barcode? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                panel1.Visible = true;
                btnValidate.Visible = true;
                btnValidateGood.Visible = false;
                btnValidateReprocess.Visible = false;
                btnValidateOutright.Visible = false;
                txtControlNumber.Focus();




            }

            else
            {

                panel1.Visible = false;
                btnValidate.Visible = false;
                //txtweighingscale.Focus();
                return;
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (txtControlNumber.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtControlNumber.Focus();
                return;
            }

            if (txtControlNumber.Text == "787898")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                Print2();
                btnReprintReject.Visible = false;
                btnValidate.Visible = false;






            }
            else if (txtControlNumber.Text == "787899")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                Print2();
                btnReprintReject.Visible = false;
                btnValidate.Visible = false;


            }
            else if (txtControlNumber.Text == "787420")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                Print2();
                btnReprintReject.Visible = false;
                btnValidate.Visible = false;

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

            dSet = objStorProc.rdf_sp_new_preparation(0, "Reprint FG Barcode", txtControlNumber.Text, "FG MODULE", txtaddedby.Text, txtdatenowstamp.Text, "", "", "", "", "", "", "", "", "", "", "", "", "addcontrolnumberlogs");

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


        void OutrightCodeNotAvailable()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "Outright Code Not Available";
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


        private void metroreprocess_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Would you like to reprint the previous reprocess barcode?  ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                panel1.Visible = true;
                btnValidateReprocess.Visible = true;
                btnValidate.Visible = false;
                btnValidateGood.Visible = false;
                btnValidateOutright.Visible = false;
                txtControlNumber.Focus();




            }

            else
            {

                panel1.Visible = false;
                btnValidateReprocess.Visible = false;
                //txtweighingscale.Focus();
                return;
            }
        }

        private void btnReprintReprocess_Click(object sender, EventArgs e)
        {
            metroreprocess_Click(sender, e);
        }

        private void btnValidateReprocess_Click(object sender, EventArgs e)
        {

            if (txtControlNumber.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtControlNumber.Focus();
                return;
            }

            if (txtControlNumber.Text == "787898")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                Print();
                btnReprintReprocess.Visible = false;

                btnValidateReprocess.Visible = false;





            }
            else if (txtControlNumber.Text == "787899")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                Print();
                btnReprintReprocess.Visible = false;
                btnValidateReprocess.Visible = false;


            }
            else if (txtControlNumber.Text == "787420")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                Print();
                btnReprintReprocess.Visible = false;
                btnValidateReprocess.Visible = false;

            }

            else
            {

                InvalidControlNumber();
                txtControlNumber.Text = "";
                txtControlNumber.Focus();
                return;
            }




        }
        //gerrard manyaman puta 

        void SearchTheTotalOutRight()

        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_repackin_finishgoods]  WHERE prod_adv = '" + lblprod_id.Text + "' AND status='Outright' AND reproccess_prod_id IS NULL";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvForOutright.DataSource = dt;

            lbltotaloutright.Text = dgvForOutright.RowCount.ToString();

        }



        void SearchTheTotalReprocess()

        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_repackin_finishgoods]  WHERE prod_adv = '" + lblprod_id.Text + "' AND status='Reprocess' AND reproccess_prod_id IS NULL";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateProdSched.DataSource = dt;

            lbltotalreprocess.Text = dgvUpdateProdSched.RowCount.ToString();

        }

        void FGGood()

        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_repackin_finishgoods]  WHERE prod_adv = '" + lblprod_id.Text + "' AND status='Good' AND reproccess_prod_id IS NULL";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateProdSched.DataSource = dt;

            lblfggood.Text = dgvUpdateProdSched.RowCount.ToString();

        }

        void FGReject()

        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_repackin_finishgoods]  WHERE prod_adv = '" + lblprod_id.Text + "' AND status='Rejected' AND reproccess_prod_id IS NULL";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateProdSched.DataSource = dt;

            lblfgreject.Text = dgvUpdateProdSched.RowCount.ToString();

        }




        void UpdateProductionSchedule()
        {
            //lbltotalreprocess.Text = (float.Parse(lbltotalreprocess.Text) + 1).ToString();


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET total_reprocess_count='"+lbltotalreprocess.Text+ "', total_good_count='"+lblfggood.Text+"', total_reject_count='"+lblfgreject.Text+ "', total_outright_count='"+lbltotaloutright.Text+"' WHERE prod_id = '" + lblprod_id.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateProdSched.DataSource = dt;
            lbltotalreprocess.Text = "0";
        }


        private void metrogood_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Would you like to reprint the previous good barcode?  ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                panel1.Visible = true;
                btnValidateGood.Visible = true;
                btnValidateReprocess.Visible = false;
                btnValidateOutright.Visible = false;
                btnValidate.Visible = false;
                txtControlNumber.Focus();
              




            }

            else
            {

                panel1.Visible = false;
                btnValidateGood.Visible = false;
                //txtweighingscale.Focus();
                return;
            }
        }

        private void btnReprintGood_Click(object sender, EventArgs e)
        {
            metrogood_Click(sender, e);
        }

        private void btnValidateGood_Click(object sender, EventArgs e)
        {
            if (txtControlNumber.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtControlNumber.Focus();
                return;
            }

            if (txtControlNumber.Text == "787898")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                button65_Click(sender, e);
                btnReprintGood.Visible = false;
                btnValidateGood.Visible = false;

                btngoodreprint.Visible = false;





            }
            else if (txtControlNumber.Text == "787899")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                button65_Click(sender, e);
                btnReprintGood.Visible = false;
                btnValidateGood.Visible = false;
                btngoodreprint.Visible = false;

            }
            else if (txtControlNumber.Text == "787420")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                button65_Click(sender, e);
             btnReprintGood.Visible = false;
                btnValidateGood.Visible = false;
                btngoodreprint.Visible = false;

            }

            else
            {

                InvalidControlNumber();
                txtControlNumber.Text = "";
                txtControlNumber.Focus();
                return;
            }




        }

        private void txtControlNumber_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if(btnReprintReject.Visible==true)
            {

         
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                btnValidate_Click(sender, e);
            }
            }
            else if(btnReprintReprocess.Visible==true)
            {

                if (e.KeyCode == System.Windows.Forms.Keys.Return)
                {
                    btnValidateReprocess_Click(sender, e);
                }
            }
            else if (btnReprintGood.Visible == true)
            {

                if (e.KeyCode == System.Windows.Forms.Keys.Return)
                {
                    btnValidateGood_Click(sender, e);
                }
            }


        }

        private void btngoodreprint_Click(object sender, EventArgs e)
        {
            btnReprintGood_Click(sender, e);
        }

        private void dgvUpdateTimeLampse_CurrentCellChanged(object sender, EventArgs e)
        {
            ViewCellChanger();
        }

        private void btnreprintingall_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Would you like to reprint the previous barcode?  ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                PrintAllFG();
            }

            else
            {
                return;
            }













            }

        private void dgvRemainingProd_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowProdata();
        }



        void ShowProdata()
        {

            if (dgvRemainingProd.RowCount > 0)
            {
                if (dgvRemainingProd.CurrentRow != null)
                {
                    if (dgvRemainingProd.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtremainingbatch.Text = dgvRemainingProd.CurrentRow.Cells["remaining_batch"].Value.ToString();
                    }

                }
            }
        }

        private void lblprod_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton220_Click_1(object sender, EventArgs e)
        {


        }

        void SumthetotalBulkandBag()
        {
            if(txttotalbulkentry.Text.Trim() == string.Empty)
            {
                txttotalbulkentry.Text = "0";
            }
            if(txt.Text.Trim() ==string.Empty)
            {
                txt.Text = "0";
            }


            txttotalproduce.Text = (float.Parse(txttotalbulkentry.Text) + float.Parse(txt.Text)).ToString();
            //toshowsavebutton();


        }


        void toshowsavebutton()
        {
            Double tenpercent = 0;
            Double total = 0;
            

            tenpercent = Convert.ToDouble(txtbags.Text) * 0.9;
            
            total = Convert.ToDouble(txttotalproduce.Text);
         



            if (total >= tenpercent)
            {
               
                btnSaveFG.Visible = true;
                return;

            }

           if(Convert.ToDouble(txttotalproduce.Text) >= Convert.ToDouble(txtbags.Text))
            {
              
                btnSaveFG.Visible = true;
                return;

            }
            else
            {
               
                btnSaveFG.Visible = false;
                return;

            }
        }

        private void txttotalbulkentry_TextChanged(object sender, EventArgs e)
        {

            //SumthetotalBulkandBag();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            //SumthetotalBulkandBag();
        }

        private void radoutright_CheckedChanged(object sender, EventArgs e)
        {
            if (radreprocess.Checked == true)
            {
                bunifuSubmit.Visible = false;
                lblcurrentstatus.Text = "Reprocess";
                btnSave.Visible = false;
                btnReprocessbtn.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
            }
            else if (radreject.Checked == true)
            {
                bunifuSubmit.Visible = false;
                lblcurrentstatus.Text = "Rejected";
                btnSave.Visible = false;
                btnReprocessbtn.Visible = false;
                btnRejected.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
            }
            else if (radgood.Checked == true)
            {
                bunifuSubmit.Visible = true;

                lblcurrentstatus.Text = "Good";
                btnSave.Visible = true;
                cboCode.Visible = false;
                lblcombi.Visible = false;
                btnoutright.Visible = false;
            }
            else if (radoutright.Checked == true)
            {
                btnoutright.Visible = true;

                lblcurrentstatus.Text = "Outright";
                cboCode.Visible = true;
                lblcombi.Visible = true;
                btnoutright.Visible = true;
                btnRejected.Visible = false;
                btnSave.Visible = false;
                btnReprocessbtn.Visible = false;
                loadCode();
            }

            else
            {
                btnoutright.Visible = true;

                lblcurrentstatus.Text = "Outright";
                cboCode.Visible = true;
                lblcombi.Visible = true;
            }



        }

        private void btnoutright_Click(object sender, EventArgs e)
        {

            txtmainfeedcode_TextChanged(sender, e);
            dgvCount_CurrentCellChanged(sender, e);

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Print the Barcode of " + txtmainfeedcode.Text + "? ", "Barcode OUTRIGHT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                txtmainfeedcode_TextChanged(sender, e);
                dgvCount_CurrentCellChanged(sender, e);

                if (cboCode.Text.Trim() == string.Empty)
                {
                    //MessageBox.Show("Iloveit");
                    OutrightCodeNotAvailable();
                    radgood.Checked = true;
                    return;
                }
                else
                {
                    //MessageBox.Show("Hate it");
                    //return;
                }

                if (txtbags.Text.Trim() == txtbagsprinting.Text.Trim())
                {
                    metroaddionalbags_Click(sender, e);
                }


                double a;
                double b;
                a = double.Parse(txtbags.Text);
                b = double.Parse(txtbagsprinting.Text);
                if (a > b)
                {
                    //MessageBox.Show("Gerard");

                }
                else
                {


                    if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Proceed the Bagging of " + txtmainfeedcode.Text + ", because is greathan than the actual bagging ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {


                    }
                    else
                    {
                        return;
                    }


                }














                mode = "add";
                if (txtactualweight.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Fill out all the required Textbox", "Message Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtactualweight.Select();
                    txtactualweight.Focus();
                    return;

                }
                else
                {

                    //double mainbalance;
                    //mainbalance = double.Parse(txtactualweight.Text);
                    //if (mainbalance < 51)
                    //{

                    //    Lessthan50kgVariance(); //pekpek
                    //}
                    //else
                    //{
                    //    txtactualweight.Text = "";
                    //    Lessthan50kg();
                    //    txtactualweight.Select();
                    //    txtactualweight.Focus();
                    //    return;
                    //}


                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsprinting.Text)).ToString();
                    }

                    else
                    {
                        txtminusbags.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsmonitoring.Text)).ToString();
                        //txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) * 1).ToString();
                        txtactualcount.Text = (float.Parse(txtbagsmonitoring.Text) + 1).ToString();

                    }


                    //if (radgood.Checked == true)
                    //{

                    //    lblcurrentstatus.Text = "Good";
                    //}
                    //else
                    //{
                    //    lblcurrentstatus.Text = "Reprocess";
                    //}



                    //for the new update fg Good!
                    if (radgood.Checked == true)
                    {
                        lblcurrentstatus.Text = "Good";
                    }
                    else if (radreprocess.Checked == true)
                    {
                        lblcurrentstatus.Text = "Reprocess";
                    }
                    else if (radreject.Checked == true)
                    {
                        lblcurrentstatus.Text = "Rejected";
                    }
                    else if (radoutright.Checked == true)
                    {
                        lblcurrentstatus.Text = "Outright";
                    }
                    else
                    {

                    }




                    if (txtbagsmonitoring.Text == "0")
                    {
                        txtvariance.Text = (float.Parse(txtbags.Text) - 1).ToString();
                    }
                    else
                    {
                        txtvariance.Text = (float.Parse(txtvariance.Text) - 1).ToString();
                    }

                    if (saveMode())
                    {
                        /// loadSupplier();
                        string tmode = mode;

                        if (tmode == "add")
                        {
                            //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];




                            //MessageBox.Show("BaseMixed  SuccesFully Saved.", "Raw Material Basemixed for Printing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //SaveNotifyFG();

                            //load_RawNMaster(); Close MUna itech

                            dgvPrint.Visible = true;
                            //loadPrintingData();5/11
                            //dgvPrint.Rows[i].Cells["selected"].Value = true;11
                            button65.Enabled = true;

                            //BtnSave.Enabled = false;
                            //button65_Click(sender, e);//4/27/2020 buje


                        }
                        else
                        {
                            //  dgv1.CurrentCell = dgv1[0, temp_hid];
                        }

                        /// btnCancel_Click(sender, e);

                    }
                    else
                    {
                        //MessageBox.Show("Failed");
                    }
                    //MessageBox.Show("Failed");

                }
                SearchTheTotalOutRight();

                //SaveNotifyFG();
                SearchTheTotalReprocess();
                //2
                FGGood();
                //3
                FGReject();

                UpdateProductionSchedule();
                //laravel

                txtmainfeedcode_TextChanged(sender, e);
                txtactualweight.Enabled = false;
                //rpt.Refresh();
                //crV1.Refresh();
                PrintOutright();

                ShowRemaingBatchQuery(); // out 
                txtactualcount.Text = (float.Parse(txtbagsprinting.Text) + 1).ToString();


                txtcurrentoutright.Text = (float.Parse(txtcurrentoutright.Text) + 1).ToString();
                //mabuluk
                load_search();
                doSearch();
                doSearch2();


                //txtminus5.Text = (float.Parse(txtvariance.Text) * 1).ToString();
                if (txtbagsmonitoring.Text == "0")
                {

                }
                else
                {
                    txtminus5.Text = (float.Parse(txtvariance.Text) * 1).ToString();
                }

                if (txtbagsmonitoring.Text == "0")
                {
                    GetPercentage();
                }
                else
                {
                    GetPercentage2();
                }
                doSearch8();

                bunifuSubmit.Visible = false;
                radoutright.Checked = true;
                //if (radgood.Checked == true)
                //{

                //    lblcurrentstatus.Text = "Good";
                //    bunifuThinButton26.Visible = true;
                //    btnReprocessbtn.Visible = false;
                //}
                //else
                //{
                //    lblcurrentstatus.Text = "Reprocess";
                //}
                //if(panelCode.Visible==true)
                //{
                //    bunifuSubmit.Visible = false;
                //}
                if (radreprocess.Checked == true)
                {
                    bunifuSubmit.Visible = false;
                    lblcurrentstatus.Text = "Reprocess";
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = true;
                    btnRejected.Visible = false;
                    cboCode.Visible = false;
                    lblcombi.Visible = false;
                    btnoutright.Visible = false;
                }
                else if (radreject.Checked == true)
                {
                    bunifuSubmit.Visible = false;
                    lblcurrentstatus.Text = "Rejected";
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = false;
                    btnRejected.Visible = true;
                    cboCode.Visible = false;
                    lblcombi.Visible = false;
                    btnoutright.Visible = false;
                }
                else if (radgood.Checked == true)
                {
                    bunifuSubmit.Visible = true;

                    lblcurrentstatus.Text = "Good";
                    btnSave.Visible = true;
                    cboCode.Visible = false;
                    lblcombi.Visible = false;
                    btnoutright.Visible = false;
                }
                else if (radoutright.Checked == true)
                {
                    btnoutright.Visible = true;

                    lblcurrentstatus.Text = "Outright";
                    cboCode.Visible = true;
                    lblcombi.Visible = true;
                    btnoutright.Visible = true;
                    btnRejected.Visible = false;
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = false;
                }

                else
                {
                    //cboCode.Visible = false;
                    //lblcombi.Visible = false;
                    //btnoutright.Visible = false;
                    //bunifuSubmit.Visible = true;

                    //lblcurrentstatus.Text = "Good";
                    //btnSave.Visible = true;
                    btnoutright.Visible = true;

                    lblcurrentstatus.Text = "Outright";
                    cboCode.Visible = true;
                    lblcombi.Visible = true;
                    btnoutright.Visible = true;
                    btnRejected.Visible = false;
                    btnSave.Visible = false;
                    btnReprocessbtn.Visible = false;
                }

                if (panelCode.Visible == true)
                {
                    bunifuSubmit.Visible = false;
                }

                MonitoringSubtractBy();
                btnReprintReprocess.Visible = false;
                btnReprintGood.Visible = false;
                btnReprintReject.Visible = false;
                btngoodreprint.Visible = false;
                btnReprintOutright.Visible = true;

                SumthetotalBulkandBag();


                if (txtcurrentoutright.Text.Trim() == string.Empty)
                {

                }
                else
                {
                    if (txtcurrentoutright.Text == "0")
                    {
                        panelCode.Enabled = true;
                    }
                    else
                    {
                        radoutright.Checked = true;
                        radoutright_CheckedChanged(sender, e);
                        panelCode.Enabled = false;


                    }

                }



                radoutright_CheckedChanged(sender, e);


            }
            else
            {
                return;
            }

            //sa mga code kung sobrang haba!!!
        }

        private void btnReprintOutright_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Would you like to reprint the previous Out right barcode?  ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                panel1.Visible = true;
                btnValidateOutright.Visible = true;
                btnValidateReprocess.Visible = false;
                btnValidateGood.Visible = false;
                btnValidate.Visible = false;
                txtControlNumber.Focus();





            }

            else
            {

                panel1.Visible = false;
                btnValidateOutright.Visible = false;
                //txtweighingscale.Focus();
                return;
            }




        }

        private void btnValidateOutright_Click(object sender, EventArgs e)
        {
            if (txtControlNumber.Text.Trim() == string.Empty)
            {
                FillEmptyFields();
                txtControlNumber.Focus();
                return;
            }

            if (txtControlNumber.Text == "787898")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                PrintOutright();
                btnReprintGood.Visible = false;
                btnValidateGood.Visible = false;
                btnValidateOutright.Visible = false;
                btngoodreprint.Visible = false;





            }
            else if (txtControlNumber.Text == "787899")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                PrintOutright();
                btnReprintGood.Visible = false;
                btnValidateGood.Visible = false;
                btngoodreprint.Visible = false;
                btnValidateOutright.Visible = false;
            }
            else if (txtControlNumber.Text == "787420")
            {
                panel1.Visible = false;
                storedProcCntrNumber();
                txtControlNumber.Text = "";
                PrintOutright();
                btnReprintGood.Visible = false;
                btnValidateGood.Visible = false;
                btngoodreprint.Visible = false;
                btnValidateOutright.Visible = false;
            }

            else
            {

                InvalidControlNumber();
                txtControlNumber.Text = "";
                txtControlNumber.Focus();
                return;
            }




            //ending of the loop  hahah!
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                bunifuThinButton26.Visible = false;
                return;
            }

            btnSaveBulk.Visible = false;
            panelCode.Visible = false;
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
            radgood.Checked = true;
            if (radgood.Checked == true)
            {

                lblcurrentstatus.Text = "Good";
                bunifuThinButton26.Visible = true;
                btnReprocessbtn.Visible = false;
            }
            else
            {
                lblcurrentstatus.Text = "Reprocess";
            }
            forNextPrevious();
            panelCode.Visible = false;
            showValueDailyProduction();
            //dito
            double a;
            double b;
            a = double.Parse(txtbags.Text);
            b = double.Parse(txtbagsprinting.Text);
            if (a > b)
            {

                //btnSaveFG.Visible = false;
            }
            else
            {
  
                bunifuSubmit.Visible = true;
      
            }



            loadSchedulesDuplicate();
            //dito2
            MonitoringSubtractBy();

            if (txtbagsmonitoring.Text == "0")
            {
                txtactualremaining.Text = (float.Parse(txtbags.Text) * 1).ToString();
            }


            BindDuplicateData();
            ShowRemaingBatchQuery(); // out 
            //dito ko nilagay
            SumthetotalBulkandBag();
            //NextSave();



            if (txtcurrentoutright.Text.Trim() == string.Empty)
            {
                panelCode.Enabled = true;
            }
            else
            {
                if (txtcurrentoutright.Text == "0")
                {
                    panelCode.Enabled = true;
                }
                else
                {
                    radoutright.Checked = true;
                    radoutright_CheckedChanged(sender, e);
                    btnoutright.Visible = false;
                    panelCode.Enabled = false;
                }

            }
            loadCode();
            loadBulk();
            nextHideBIN();
            //dito3
            //PercentMasterData();
            toshowsavebutton();

        }

        void PercentMasterData()
        {
            try
            {

  
            if (lbltotalprod.Text == "0")
            {

            }
            else
            {
                dataView_CurrentCellChanged(new object(), new System.EventArgs());
                txt5percent.Text = (float.Parse(txtbags2.Text) * 0.95).ToString();
                    double a;
                    double b;
                b = double.Parse(txt5percent.Text);
                a = double.Parse(txtactualcount.Text);
                if (a > b)
                {
                    btnSaveFG.Visible = true;
                }
                else
                {

                    btnSaveFG.Visible = false;
                }
            }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                bunifuThinButton26.Visible = false;
                return;
            }
            else
            {
          //      SumthetotalBulkandBag();
            }




            panelCode.Visible = false;
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
            radgood.Checked = true;
            if (radgood.Checked == true)
            {

                lblcurrentstatus.Text = "Good";
                bunifuThinButton26.Visible = true;
                btnReprocessbtn.Visible = false;
            }
            else
            {
                lblcurrentstatus.Text = "Reprocess";
            }

            forNextPrevious();
            showValueDailyProduction();
            //MessageBox.Show(txtbags.Text);
            //MessageBox.Show(txtbagsprinting.Text);
            //dito
            double a;
            double b;
            a = double.Parse(txtbags.Text);
            b = double.Parse(txtbagsprinting.Text);
            if (a > b)
            {
                //MessageBox.Show("Gerard");
                btnSaveFG.Visible = false;
            }
            else
            {
                //MessageBox.Show("Laarnie");
                //forNextPrevious();
                btnSaveFG.Visible = true;
                //bunifuSubmit.Visible = false; deepo 12/4/2020


                loadSchedulesDuplicate();

                BindDuplicateData();
                ShowRemaingBatchQuery(); // out 
                SumthetotalBulkandBag();
           //     MessageBox.Show("sample");
                return;
            }



            loadSchedulesDuplicate();
            MonitoringSubtractBy();
            if (txtbagsmonitoring.Text == "0")
            {
                txtactualremaining.Text = (float.Parse(txtbags.Text) * 1).ToString();
            }


            BindDuplicateData();
            ShowRemaingBatchQuery(); // out 
            ShowProdata();
            SumthetotalBulkandBag(); // my 11/18/2020
            NextSave();//dont disable

            if (txtcurrentoutright.Text.Trim() == string.Empty)
            {
                panelCode.Enabled = true;
            }
            else
            {
                if (txtcurrentoutright.Text == "0")
                {
                    panelCode.Enabled = true;
                }
                else
                {
                    radoutright.Checked = true;
                    radoutright_CheckedChanged(sender, e);
                    btnoutright.Visible = false;
                    panelCode.Enabled = false;
                }

            }
            loadCode();
            loadBulk();
            nextHideBIN();
            if(lbltotalprod.Text =="0")
            {
           
            }
            else
            {
                //PercentMasterData();
                toshowsavebutton();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (lbltotalprod.Text == "0")
            {
                bunifuThinButton26.Visible = false;
                return;
            }
            metroButton2_Click(sender, e);
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            txtmainfeedcode_TextChanged(sender, e);
            dgvCount_CurrentCellChanged(sender, e);
            metroButton3_Click(sender, e);
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Would you like to reprint the previous barcode?  ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                PrintAllFG();
            }

            else
            {
                return;
            }


        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void lblbagorbin_Click(object sender, EventArgs e)
        {

        }

        private void lblbindata_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_4(object sender, EventArgs e)
        {
            btnSaveFG.Visible = true;
        }

        private void button2_Click_5(object sender, EventArgs e)
        {
            btnSaveFG.Visible = true;
        }
    }
}

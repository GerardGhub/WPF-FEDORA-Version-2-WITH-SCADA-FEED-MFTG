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
    public partial class frmProductionSchedule : Form
    {

        myclasses xClass = new myclasses();

        IStoredProcedures objStorProc = null;
        IStoredProcedures g_objStoredProcCollection = null;
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dset = new DataSet();

        DataSet dset2 = new DataSet();
        DataSet dSet_temp = new DataSet();
        string mode = "";
        int p_id = 0;
        int temp_hid = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();

        public frmProductionSchedule()
        {
            InitializeComponent();
        }

        
        private void frmProductionSchedule_Load(object sender, EventArgs e)
        {


            txtQuantity.Text = "1";
            txtbagsduplicate.Text = "1";
            txtbatchduplicate.Text = "1";
            DateTime dNow = DateTime.Now;
            txtdatenow.Text = (dNow.ToString("MM/dd/yyyy"));
            txtdatenow2.Text = (dNow.ToString("M/d/yyyy"));
            //txttotalduplicatebatch.Text = "1";
            btncheckempty_Click(sender, e);
            //txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            txtmode.Text = "1";
            bunifuThinButton26.Enabled = false;
            dgv1stView.Visible = false;
            mfg_datePicker.MinDate = DateTime.Today;
            //mfg_datePicker2.MaxDate = DateTime.Today;
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            //this.WindowState = FormWindowState.Maximized;
            loadFeedCode();
            callOthers();
            load_Schedules();
            load_Schedules_approved();
            dtpCompare.Text = (dNow.ToString("M/d/yyyy"));
            loadcancel();
            lblid.Text = userinfo.user_id.ToString();
            txtaddedby.Text = userinfo.emp_name.ToUpper();
            load_SchedulesCancelByApprover();
            dgvApproved2cancel.Visible = false;
            btncheckcancel_Click(sender, e);
            IsForCancelnaApproved();
            load_Schedules_finish();
            bunifuThinButton210.Visible = false;
            myglobal.global_module = "Active";
            load_search();
            loadproductionlevel();

            picload.Visible = false;
            btnAdd.Visible = false;
            btnSubmit.Visible = true;
            btnSubmit.Enabled = true;



            if (lblrecords.Text == "0")
            {

            }
            else
            {


                Computation();
            }
            if (lblcountprod.Text == "0")
            {

            }
            else
            {
                Computation();
            }

            //btncheckcancel_Click(sender, e);
            timer1.Start();
            timer1_Tick(sender, e);


            if (lblrecords.Text == "0")
            {
                timer2_Tick(sender, e);
            }
            lblconfirmbags.Visible = false;
            txtcurrentbags.Visible = false;
            bunifuThinButton210.Visible = false;
            btnupdatelower.Visible = false;


            if (lblrecords.Text == "0")
            {

            }
            else
            {
                bunifuThinButton27.Visible = true;
                bunifuThinButton27.BringToFront();
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


        void Computation()
        {

            double actualbags;
            double bags;
            double sagot;
            double final;

            bags = double.Parse(lblactualCount.Text);
            actualbags = double.Parse(lblavailablebags.Text);


            sagot = bags / actualbags;
            final = sagot * (double)100;


            lblpercentage.Text = Math.Round(final, 1).ToString();




        }

        void load_search()
        {
            dataGridView2.Visible = false;
            dset_emp.Clear();

            dset_emp2.Clear();


            dset_emp = objStorProc.sp_getMajorTables("GetFeedType");
            dset_emp2 = objStorProc.sp_getMajorTables("GetProductionLevel");
            doSearch3();
            doSearch();





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

                        //dv.RowFilter = "feed_code like '%" + cboFeedCode.Text + "%'";
                        dv.RowFilter = "feed_code like '%" + cboFeedCode.Text + "%'";


                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataGridView2.DataSource = dv;
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


        }

        DataSet dset_emp2 = new DataSet();
        void doSearch3()
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

                        dv.RowFilter = "proddate = '" + dtpCompare.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView4.DataSource = dv;
                    lblcountprod.Text = dataGridView4.RowCount.ToString();
                    //txtseries.Text = dataGridView4.RowCount.ToString();
                    double count1;

                    double seriescount;

                    //count1 = double.Parse(txtseries.Text);
                    //rp2 = double.Parse(txtnobatch.Text);

                    //seriescount = count1 + 1;
                    //txtseries.Text = Convert.ToString(seriescount);

                    //double lblx;
                    //double lbly;
                    //lblx = double.Parse(txtbags.Text);
                    //lbly = double.Parse(txtbagsprinting.Text);

                    //lblxx.Text = Math.Round(lblx, 5).ToString("#,0.00");
                    //lblyy.Text = Math.Round(lbly, 5).ToString("#,0.00");



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
            for (int i = 0; i < dataGridView4.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView4.Rows[i].Cells[3].Value);
            }

            //lblCounts.Text = dgvImport.RowCount.ToString();
            lblactualCount.Text = sum.ToString();



        }












        void times2query()
        {
            for (int n = 0; n < (dgvImport.Rows.Count); n++)
            {
                //double s = Convert.ToDouble(dgvImport.Rows[n].Cells[4].Value);


                //double s1 = Convert.ToDouble(dgvAllFeedCode.Rows[n].Cells[7].Value);

                double s1 = Convert.ToDouble(dgvImport.Rows[n].Cells[7].Value);

                //int s1 = Convert.ToInt32(dgv1stView.Rows[n].Cells[1].Value);
                //double s13 = s * 2;
                double s15 = s1 * 2;

                //dgvImport.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
                dgvImport.Rows[n].Cells[7].Value = s15.ToString();


                //dgvAllFeedCode.Rows[n].Cells[4].Value = s13.ToString("#,0.000");
                //dgvAllFeedCode.Rows[n].Cells[7].Value = s15.ToString("#,0.000");
            }


        }

        public void IsForCancelnaApproved()
        {


            if (xClass.g_objStoredProc.getConnected() == true)
            {
                g_objStoredProcCollection = xClass.g_objStoredProc.GetCollections();

                dset = g_objStoredProcCollection.sp_IDGenerator(0, "SelectHR", "", "", 1);
                dset2 = g_objStoredProcCollection.sp_IDGenerator(1, "SelectCompany", "", "", 1);

                //Rpt_Path = WFFDR.Properties.Settings.Default.fdg;

                //Rpt_Path = ini.IniReadValue("PATH", "Report_Path");

                xClass.ActivitiesLogs(userinfo.emp_name + " Generated " + myglobal.REPORT_NAME + " Report");
            }
            else
            {
                MessageBox.Show("Unable to connect in sql server", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }



            int number_of_rows = dset2.Tables[0].Rows.Count - 1;



            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchforApprovednaCancel", "All", txtSearch.Text, 1);
            dgvApprovenacancel.DataSource = dset.Tables[0];


        }




        public void load_SchedulesCancelByApprover()
        {
            string mcolumns = "test,prod_id.p_feed_code,p_bags,p_nobatch,proddate,dateadded";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved2cancel, mcolumns, "schedules_approved_approver_cancel");
            lbllost.Text = dgvApproved2cancel.RowCount.ToString();

        }
        public void load_Schedules()
        {
            string mcolumns = "test,prod_id.p_feed_code,feed_type,p_bags,p_nobatch,proddate,dateadded,bagorbin";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "schedules_approved");
            lblrecords.Text = dgvApproved.RowCount.ToString();

        }
        public void loadcancel()
        {
            string mcolumns = "test,prod_id.p_feed_code,feed_type,p_bags,p_nobatch,proddate,dateadded,planner_cancel_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvCancel, mcolumns, "schedules_cancel");


        }



        public void loadproductionlevel()
        {
            string mcolumns = "test,levelstatus,modified_by,modified_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataGridView3, mcolumns, "production_level");
            //  lblrecords.Text = dgv_table.RowCount.ToString();
            // textBox1.Text = dgv_table.RowCount.ToString();

            lbllevelplusone.Text = (float.Parse(lblavailablebags.Text) + 1).ToString();
            txtbags.Text = "";
        }

        public void load_Schedules_approved()
        {
            string mcolumns = "prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate,dateadded,approved_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvMaster, mcolumns, "schedules_approved_preparation");

            lblapproved.Text = dgvMaster.RowCount.ToString();

        }


        public void load_Schedules_now()
        {
            string mcolumns = "prod_id,p_feed_code,feed_type,p_bags,p_nobatch,proddate,dateadded,approved_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataGridView4, mcolumns, "schedules_approved_preparation");

            //lblapproved.Text = dgvMaster.RowCount.ToString();
            //gerard
        }

        public void load_Schedules_finish()
        {
            string mcolumns = "prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate,dateadded,approved_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvfinish, mcolumns, "schedules_approved_finish");

            // textBox1.Text = dgv_table.RowCount.ToString();

        }
        public void callOthers()
        {
            //txtdatenow.Text = DateTime.Now.ToString();
        }

        void loadFeedCode()
        {
            ready = false;

            xClass.fillComboBoxRepacking(cboFeedCode, "feed_code_productionschedule", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            mode = "add";
            if (txtbags.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter No. Of Bags", "Bags", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtnobatch.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Batch", "Batch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (saveMode())
                {

                    string tmode = mode;

                    if (tmode == "add")
                    {
                        //  dgv1.CurrentCell = dgv1[0, dgv1.Rows.Count - 1];

                        MessageBox.Show("Production Advanced Added SuccesFully.", "Production Advanced", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btncheckempty_Click(sender, e);
                        Clear();
                        load_Schedules_approved();
                        load_Schedules();
                        bunifuThinButton210.Visible = false;

                    }
                    else
                    {
                        dgvMaster.CurrentCell = dgvMaster[0, temp_hid];
                    }

                    /// btnCancel_Click(sender, e);

                }
                else
                    MessageBox.Show("Failed");
                //frmMenu sa = new frmMenu();

                //sa.ActivitiesLogs(userinfo.emp_name + "update offenses");
            }
        }


        public bool saveMode()
        {
           
            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, txtbags.Text, "", "", "", "", "", "", "", "", "","", "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Duplicate Entry", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboFeedCode.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(), textBox1.Text.Trim(), txtseries.Text.Trim(), cmbBagandBin.Text.Trim(), txtretailbin.Text.Trim(), txtcorntype.Text.Trim(), txtaddedby.Text.Trim(), "add");

                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
               
                dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(), textBox1.Text.Trim(), txtseries.Text.Trim(), cmbBagandBin.Text.Trim(), txtretailbin.Text.Trim(), txtcorntype.Text.Trim(), txtaddedby.Text.Trim(), "getbyfeedcode");
                dSet_temp.Clear();


                dSet_temp = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(), textBox1.Text.Trim(), txtseries.Text.Trim(), cmbBagandBin.Text.Trim(), txtretailbin.Text.Trim(), txtcorntype.Text.Trim(), txtaddedby.Text.Trim(), "getbyid");
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][7].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();

                        dSet = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(), textBox1.Text.Trim(), txtseries.Text.Trim(), cmbBagandBin.Text.Trim(), txtretailbin.Text.Trim(), txtcorntype.Text.Trim(), txtaddedby.Text.Trim(), "edit");

                        return true;
                    }
                    else
                    {

                        dSet = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(), textBox1.Text.Trim(), txtseries.Text.Trim(), cmbBagandBin.Text.Trim(), txtretailbin.Text.Trim(), txtcorntype.Text.Trim(), txtaddedby.Text.Trim(), "edit");
                        load_Schedules();
                        UpdateOkay();

                        dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedCode.Text, txtaddedby.Text, "3.1 Production Schedule", "Updating Prod Schedule", txtdatenow2.Text, mfg_datePicker2.Text, txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");


                        return false;
                    }
                }
                else
                {
                    dSet.Clear();


                    return true;
                }
            }
            else if (mode == "cancel")
            {

                int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][7].ToString());
                if (tmpID == p_id)
                {
                    dSet.Clear();

                    dSet = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(), textBox1.Text.Trim(), txtseries.Text.Trim(), cmbBagandBin.Text.Trim(), txtretailbin.Text.Trim(), txtcorntype.Text.Trim(), txtaddedby.Text.Trim(), "cancel");

                    return true;
                }
                else
                {
                  
                    load_Schedules();
                    return false;
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

        private void txtbags_TextChanged(object sender, EventArgs e)
        {
            try
            {


                txtnobatch.Text = (float.Parse(txtbags.Text) / 40).ToString();
            }
            catch (Exception)
            {


            }
        }

        void Clear()
        {
            cboFeedCode.Text = "";
            txtbags.Text = "";
            txtnobatch.Text = "";
            mfg_datePicker.Text = "";

        }

        void EnabledTrue()
        {
            cboFeedCode.Enabled = true;
            //   txtbags.Enabled = true;
            //txtnobatch.Enabled = true;
            mfg_datePicker.Enabled = true;

        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            EnabledTrue();

            Clear();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cboFeedCode.Enabled = false;
            //   txtbags.Enabled = false;
            txtnobatch.Enabled = false;
            mfg_datePicker.Enabled = false;
            txtreason.Enabled = false;
        }

        private void dgvMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvMaster.RowCount > 0)
            {
                if (dgvMaster.CurrentRow != null)
                {
                    if (dgvMaster.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster.CurrentRow.Cells["prod_id"].Value);

                        cboFeedCode.Text = dgvMaster.CurrentRow.Cells["p_feed_code"].Value.ToString();
                        txtbags.Text = dgvMaster.CurrentRow.Cells["p_bags"].Value.ToString();
                        txtnobatch.Text = dgvMaster.CurrentRow.Cells["p_nobatch"].Value.ToString();
                        mfg_datePicker.Text = dgvMaster.CurrentRow.Cells["proddate"].Value.ToString();
                        txtdatenow.Text = dgvMaster.CurrentRow.Cells["dateadded"].Value.ToString();
                    }

                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnnew_Click_1(object sender, EventArgs e)
        {
            EnabledTrue();

            Clear();

        }

        private void txtbags_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtbags_TextChanged_1(object sender, EventArgs e)
        {


            try
            {


                txtnobatch.Text = (float.Parse(txtbags.Text) / 40).ToString();

                lblrunningqty.Text = (float.Parse(txtbags.Text) + float.Parse(lblactualCount.Text)).ToString();
            }
            catch (Exception)
            {


            }

            if (txtbags.Text.Trim() == string.Empty)
            {

                txtnobatch.Text = "";
                // txtbags.BackColor = Color.Yellow;
                cmbBagandBin.BackColor = Color.Yellow;
                txtretailbin.BackColor = Color.Yellow;
                txttotalQty.Text = "";
                txttotalduplicatebatch.Text = "";
                txtduplicatebagstotal.Text = "";
                txttotalhere.Text = "";
                lblrunningqty.Text = "";

            }

            else
            {
                cmbBagandBin.BackColor = Color.White;
                txtretailbin.BackColor = Color.White;
                this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];




                double bagsdpulicate;
                double bags;


                bagsdpulicate = double.Parse(txtbagsduplicate.Text);
                bags = double.Parse(txtbags.Text);

                if (bagsdpulicate < bags)

                {
                    //MessageBox.Show("Mataas");
                    txtduplicatebagstotal.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsduplicate.Text)).ToString();
                    txttotalduplicatebatch.Text = (float.Parse(txtnobatch.Text) - float.Parse(txtbatchduplicate.Text)).ToString();
                    txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
                    bunifuThinButton210.Visible = true;
                    btnupdatelower.Visible = false;

                    //btnhigher_Click(sender, e);


                }

                else
                {
                    //MessageBox.Show("Mababa");
                    txtduplicatebagstotal.Text = (float.Parse(txtbagsduplicate.Text) - float.Parse(txtbags.Text)).ToString();
                    txttotalduplicatebatch.Text = (float.Parse(txtbatchduplicate.Text) - float.Parse(txtnobatch.Text)).ToString();
                    txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();

                    bunifuThinButton210.Visible = false;
                    btnupdatelower.Visible = true;
                    //btnhigher_Click(sender, e);
                    //return;

                }









            }






            if (txtnobatch.Text.Contains("."))
            {
                //MessageBox.Show("Approved");

                txtnobatch.BackColor = Color.Yellow;

            }
            else
            {
                txtnobatch.BackColor = Color.White;
                //MessageBox.Show("DisApproved");
            }



            //computation

            //double rp1;
            //double rp2;
            //double rpavailable;

            //rp1 = double.Parse(txtQuantity.Text);
            //rp2 = double.Parse(txtnobatch.Text);

            //rpavailable = rp1 * rp2;


            //txttotalQty.Text = Convert.ToString(rpavailable);

            //this.cboFeedCode.Text = this.cboFeedCode.Text.ToUpper();
        }

        private void txtnobatch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {


            //double negativedot;
            //double sagot;

            //negativedot = double.Parse(txtnobatch.Text);

            if (txtnobatch.Text.Contains("."))
            {
                //MessageBox.Show("Approved");
                BagsDotNotify();
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                txtbags.Select();
                return;
            }
            else
            {
                //MessageBox.Show("DisApproved");
            }
        }

        private void txtnobatch_TextChanged(object sender, EventArgs e)
        {
            if (txtnobatch.Text.Trim() == string.Empty)
            {

            }
            else
            {


                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            }

        }




        void BagsDotNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " Actual Bags is not Divisble by 40 '" + txtnobatch.Text + "'!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void NoMixingNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " Warning No Mixing Capacity, Please update to proceed";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void BagvsMixing()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = " Actual Bags is Less than the Mixing Capacity !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void LessThanProdLevel()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Less than Production Level FROM '" + txtbags.Text + "' TO '" + lblavailablebags.Text + "'!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void LessThanProdLevel2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Less than Production Level FROM '" + lblrunningqty.Text + "' TO '" + lblavailablebags.Text + "' and the active Production is " + lblcountprod.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            txtbags.Text = "";
        }




        void SelectEntryatDataGridNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SELECT ENTRY AT THE DATAGRID FIRST !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void cancelNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Production schedule successfully cancelled!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;






            label6.Visible = false;

            txtreason.Visible = false;
            txtreason.Text = "";

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
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void InvalidBagsQty()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Invalid GrandTotal Quantity " + txtbags.Text + "!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void EmptyFieldNotifyseries()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Mixing Capacity Required for " + textBox1.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void NoDataNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "No Data Found !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void SameBagsNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Same Quantity of Bags";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void FeedCodeNotExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Feed Code does not Exists or Inactive !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;
            cboFeedCode.Focus();


        }


        void UpdateOkay()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Production Schedule updated successfully!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;



            txtbags.BackColor = Color.White;
            cmbBagandBin.Enabled = false; ;
            txtretailbin.Enabled = false;
            cboFeedCode.Focus();
            ControlBox = true;

        }
        private void txtbags_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {
            cboFeedCode_SelectedIndexChanged(sender, e);
            //bunifuThinButton27.Visible = false;
            btnupdatelower.Visible = false;
            mfg_datePicker2.Visible = true;

            if (mfg_datePicker2.Text.Trim() == dtpCompare.Text.Trim())
            {
                //btnSubmit.Enabled = false;
                //btnSubmit.Enabled = false;
            }
            else
            {

            }

            if (dgvApproved.RowCount > 0)
            {
                if (dgvApproved.CurrentRow != null)
                {
                    if (dgvApproved.CurrentRow.Cells["prod_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);
                        txtproduction_id.Text = dgvApproved.CurrentRow.Cells["prod_id"].Value.ToString();

                        txtidna.Text = dgvApproved.CurrentRow.Cells["prod_id"].Value.ToString();

                        cboFeedCode.Text = dgvApproved.CurrentRow.Cells["fcode"].Value.ToString();
                        txtbags.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();
                        txtbatchduplicate.Text = dgvApproved.CurrentRow.Cells["batch"].Value.ToString();
                        txtbagsduplicate.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();
                        txtnobatch.Text = dgvApproved.CurrentRow.Cells["batch"].Value.ToString();
                        mfg_datePicker2.Text = dgvApproved.CurrentRow.Cells["prod"].Value.ToString();

                        cmbBagandBin.Text = dgvApproved.CurrentRow.Cells["bagorbin"].Value.ToString();
                        //txtdatenow.Text = dgvApproved.CurrentRow.Cells["added"].Value.ToString();
                    }

                }
            }
            doSearch3();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {



            this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            //starting Query
            cmbBagandBin.BackColor = Color.Yellow;
            txtretailbin.BackColor = Color.Yellow;
            cboFeedCode.BackColor = Color.Yellow;
            mfg_datePicker2.CalendarMonthBackground = Color.Yellow;
            //double rpavailable;

            //rp1 = double.Parse(txtQuantity.Text);

            btnAdd.Visible = true;
            //rpavailable = rp1 * 2;


            //txtQuantity.Text = Convert.ToString(rpavailable);

            textBox1.Text = "";
            txtdatenow.Visible = false;
            txtdatenow.Text = DateTime.Now.ToString();
            mfg_datePicker.Visible = true;
            bunifuThinButton26.Enabled = true;
            EnabledTrue();
            btnSubmit.Visible = false;
            bunifuThinButton29.Visible = true;
            Clear();
            bunifuThinButton27.Enabled = false;
            bunifuCancel.Enabled = false;
            mfg_datePicker2.Visible = false;

            bunifuThinButton27.Visible = false;
            bunifuCancel.Visible = false;

            cmbBagandBin.Enabled = true;
            cboFeedCode.Focus();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            //kupal
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, txtbags.Text, "", "", "", "", "", "", "", "", "","", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboFeedCode.Focus();

            }
            else
            {
                FeedCodeNotExists();
                return;
            }


            if (cboFeedCode.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                cboFeedCode.Focus();
                cboFeedCode.Select();
                cboFeedCode.BackColor = Color.Yellow;
                return;
            }

            if (txtbags.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                txtbags.Focus();
                txtbags.Select();
                txtbags.BackColor = Color.Yellow;
                return;
            }


            if (txtnobatch.Text.Contains("."))
            {
                //MessageBox.Show("Approved");
                BagsDotNotify();
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                txtbags.Select();
                return;
            }
            else
            {
                //MessageBox.Show("DisApproved");
            }


            metroButton1_Click(sender, e);



        }

        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
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
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();

            //phase 2


        }

        private void cboFeedCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboFeedCode.Text.Trim() == string.Empty)
            {

            }
            else
            {
                cboFeedCode.BackColor = Color.White;
            }

            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Production Schedule ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
          

                btnfinishvalidation_Click(sender, e);


          






            }
            else
            {

                return;
            }
        }


        public void SaveProduction()
        {
            //MessageBox.Show("Mabulok Ka Gerard! Hhahahhaha!");
            //return;

            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(), textBox1.Text.Trim(), txtseries.Text.Trim(), cmbBagandBin.Text.Trim(), txtretailbin.Text.Trim(), txtcorntype.Text.Trim(), txtaddedby.Text.Trim(), "add");


        }

        void AddedSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Production Schedule successfully Added !";
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
            txtbags.BackColor = Color.White;

            dSet.Clear();
            dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedCode.Text, txtaddedby.Text, "3.1 Production Schedule", "Add a Prod Schedule", txtdatenow2.Text, mfg_datePicker2.Text, txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");

            cmbBagandBin.Enabled = false;
            txtretailbin.Enabled = false;

        }


        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            bunifuThinButton26.Enabled = false;
            mfg_datePicker.Visible = false;
            btnSubmit.Visible = true;
            bunifuThinButton29.Visible = false;
            cboFeedCode.Enabled = false;
            txtbags.Enabled = false;
            txtnobatch.Enabled = false;
            mfg_datePicker.Enabled = false;
            txtreason.Enabled = false;
            bunifuThinButton27.Enabled = true;
            bunifuCancel.Enabled = true;
            mfg_datePicker2.Visible = false;
            btnAdd.Visible = false;
            txtbags.BackColor = Color.White;
            cboFeedCode.BackColor = Color.White;
            cmbBagandBin.Text = "";
            cmbBagandBin.Enabled = false;

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            mfg_datePicker.Visible = true;
            mfg_datePicker2.Visible = false;
            mfg_datePicker.Enabled = true;
            // txtbags.Enabled = true;
            bunifuThinButton27.Visible = false;
            bunifuThinButton210.Visible = false;
            bunifuUndo.Visible = true;
            btnAdd.Enabled = false;
            //btnSubmit.Enabled = false;
            bunifuCancel.Visible = false;
            btnSubmit.Visible = false;
            cmbBagandBin.Enabled = true;

            //if (txtbatchduplicate.Text.Trim() == string.Empty)
            //{

            //}
            //else
            //{
            txtbags.Text = "";

            txtcurrentbags.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();

            lblconfirmbags.Visible = true;
            txtcurrentbags.Visible = true;
            txtbags.Focus();
            //    txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
            //}
        }

        private void bunifuCancel_Click(object sender, EventArgs e)
        {
            bunifuThinButton210.Enabled = false;
            txtreason.BackColor = Color.Yellow;
            txtreason.Focus();
            btnAdd.Enabled = false;

            txtreason.Visible = true;
            btngreaterthan_Click(sender, e);
            //dgvApproved_CurrentCellChanged(sender, e);
            txtbags.BackColor = Color.White;
            cboFeedCode.BackColor = Color.White;


            //txtreason.Select();
            txtreason.Enabled = true;
            bunifuCancel.Visible = false;
            bunifuSubmit.Visible = true;
            bunifuUndo.Visible = true;
            dgvApproved.Enabled = false;

            Cancelbtn.Visible = true;
            bunifuUndo.Visible = false;
            label6.Visible = true;


            //btnSubmit.Enabled = false;
            bunifuThinButton27.Enabled = false;

            btnSubmit.Visible = false;
            bunifuThinButton27.Visible = false;

            if (txtnobatch.Text.Trim() == string.Empty)
            {

            }
            else
            {


                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            }

            txtreason.BackColor = Color.White;
        }

        private void bunifuSubmit_Click(object sender, EventArgs e)
        {
            metroButton3_Click(sender, e);

            //bunifuCancel.Visible = true;
            //txtreason.Enabled = false;
            //bunifuSubmit.Visible = false;
        }

        private void dgvApproved_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            btneditvalidation_Click(sender, e);

            txtbags.BackColor = Color.White;
            cboFeedCode.BackColor = Color.White;

        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Production Schedule? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

            }
            else
            {

                return;
            }



            metroButton2_Click(sender, e);
        }

        private void bunifuUndo_Click(object sender, EventArgs e)
        {
            this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            btnAdd.Enabled = true;
            txtreason.BackColor = Color.White;
            bunifuThinButton210.Visible = false;
            btnupdatelower.Visible = false;
            bunifuThinButton27.Visible = true;
            bunifuThinButton29_Click(sender, e);
            bunifuUndo.Visible = false;
            mfg_datePicker.Visible = false;
            dgvApproved.Enabled = true;
            mfg_datePicker2.Visible = true;
            bunifuSubmit.Visible = false;
            bunifuCancel.Visible = true;
            bunifuThinButton26.Enabled = false;
            cmbBagandBin.Enabled = false;
            btnSubmit.Enabled = true;
            bunifuCancel.Enabled = true;

            btnSubmit.Enabled = true;
            bunifuThinButton27.Enabled = true;

            label6.Visible = false;

            txtreason.Visible = false;

            lblconfirmbags.Visible = false;
            txtcurrentbags.Visible = false;
            txtbags.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {


            if (lblrecords.Text == "0")

            {
                NoDataNotify();
                return;
            }
            if (txtreason.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                txtreason.Focus();
                txtreason.Select();
                txtreason.BackColor = Color.Yellow;
                return;
            }


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel the Production Schedule ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bunifuCancel.Visible = true;
                txtreason.Enabled = false;
                bunifuSubmit.Visible = false;

                ControlBox = false;
                //mode = "cancel";
                if (txtreason.Text.Trim() == string.Empty)
                {
                    SelectEntryatDataGridNotify();

                }


                else
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedCode.Text, txtaddedby.Text, "3.1 Production Schedule", "Cancelled Prod Schedule", txtdatenow2.Text, mfg_datePicker2.Text, txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");




                    CantncelButton_Click(sender, e);


                    btnRollback_Click(sender, e); // roll back the inventory

                    //btncheckempty_Click(sender, e); //to datagrid 1

                    //cancelNotify();
                    //load_Schedules();
                    //load_Schedules_approved();
                    //loadcancel();



                    //load_search();








                }
                //frmProductionSchedule_Load(sender, e);
            }

            else
            {
                return;

            }


            int sum = 0;
            for (int i = 0; i < dataGridView4.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView4.Rows[i].Cells[3].Value);
            }

            //lblCounts.Text = dgvImport.RowCount.ToString();
            lblactualCount.Text = sum.ToString();

        }

        //CantncelButton_Click(object sender, EventArgs e)

        private void txtreason_TextChanged(object sender, EventArgs e)
        {
            if (txtreason.Text.Trim() == string.Empty)
            {

                txtreason.BackColor = Color.White;

            }
            else
            {
                txtreason.BackColor = Color.White;

            }
        }

        private void dgv1stView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgv1stView.RowCount > 0)
            {
                if (dgv1stView.CurrentRow != null)
                {
                    if (dgv1stView.CurrentRow.Cells["feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                        textBox1.Text = dgv1stView.CurrentRow.Cells["rp_feed_type"].Value.ToString();


                    }

                }
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "View the cancelled Production Schedule ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //load_SchedulesCancelByApprover();
                //txtmode.Text = "0";
                frmViewApproverCancelProd sas = new frmViewApproverCancelProd();
                sas.ShowDialog();





            }
            else
            {
                //load_Schedules();
                //txtmode.Text = "1";
                return;

            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (lbllost.Text == "0")
            {

            }
            else
            {

                if (txtillusion.BackColor == Color.LightBlue)
                {
                    txtillusion.BackColor = Color.DarkOrange;
                    load_SchedulesCancelByApprover();

                }

                else
                {
                    txtillusion.BackColor = Color.LightBlue;
                    load_SchedulesCancelByApprover();

                    if (lbllost.Text == "0")
                    {
                        label7_Click(sender, e);
                    }


                }
            }


            //if (txtillusion.BackColor == Color.LightGreen)
            //{
            //    txtillusion.BackColor = Color.DarkOrange;
            //    //load_Schedules();
            //    //
            //    txtillusion.BackColor = Color.LightGreen;
            //    load_SchedulesCancelByApprover();

            //    //Tickering();
            //}
            //else
            //{
            //    txtillusion.BackColor = Color.LightGreen;
            //    load_SchedulesCancelByApprover();
            //    //load_Schedules();


            //    if (lbllost.Text == "0")
            //    {
            //        label7_Click(sender, e);
            //    }



            //}












            if (lblrecords.Text == "0")
            {
                timer2_Tick(sender, e);
            }
        }

        void Tickering()
        {

            double checkzero;
            checkzero = double.Parse(lbllost.Text);


            if (checkzero > 0)
            {




                lbllost.Visible = true;
                pictureBox1.Visible = true;
                txtillusion.Visible = true;

                load_Schedules();
            }
            else
            {

                //timer1.Stop();6/29/2020
                load_Schedules();


                pictureBox1.Visible = false;
                txtillusion.Visible = false;
                lbllost.Visible = false;

            }

        }


        private void btncheckcancel_Click(object sender, EventArgs e)
        {
            double checkzero;
            checkzero = double.Parse(lbllost.Text);


            if (checkzero > 0)
            {




                lbllost.Visible = true;
                pictureBox1.Visible = true;
                txtillusion.Visible = true;
                timer1.Start();
                timer1_Tick(sender, e);
                load_Schedules();
            }
            else
            {

                //timer1.Stop();6/29/2020
                load_Schedules();

                //twice
                timer1.Start();
                timer1_Tick(sender, e);
                pictureBox1.Visible = false;
                txtillusion.Visible = false;
                lbllost.Visible = false;

            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            btncheckcancel_Click(sender, e);

            load_Schedules();
            btncheckempty_Click(sender, e);
            load_SchedulesCancelByApprover();
            loadcancel();

        }

        private void btncheckempty_Click(object sender, EventArgs e)
        {
            if (dgvApproved.Rows.Count < 0)
            {
                //MessageBox.Show("1");

                dgvApproved.Visible = false;


            }
            else
            {

                dgvApproved.Visible = true;

            }
        }

        private void cboFeedCode_SelectedValueChanged(object sender, EventArgs e)
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            //deploy
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select distinct recipe_id,rp_type,feed_code,item_code,rp_description,rp_category,rp_group,quantity from [dbo].[rdf_recipe] WHERE feed_code = '" + cboFeedCode.Text + "' AND is_active=1 ORDER BY rp_category DESC";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvImport.DataSource = dt;



            sql_con.Close();
            if (ready == true)

                btnsum_Click(sender, e);
            times2query();

            dgvImport_CurrentCellChanged(sender, e);

            //txtbags.Text = "";
            //txtbags.Focus();


        }

        private void btnsum_Click(object sender, EventArgs e)
        {
            dgvImport[6, dgvImport.Rows.Count - 1].Value = "Total";
            dgvImport.Rows[dgvImport.Rows.Count - 1].Cells[0].Style.BackColor = Color.Green;
            dgvImport.Rows[dgvImport.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
            decimal tot = 0;

            for (int i = 0; i < dgvImport.RowCount - 1; i++)
            {
                var value = dgvImport.Rows[i].Cells["quantity2"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value) * 2;
                }
            }
            if (tot == 0)
            {

            }
            //dgvImport.Rows[dgvImport.Rows.Count - 1].Cells["quantity2"].Value = tot.ToString();

            lblCounts.Text = dgvImport.RowCount.ToString();
            lblCountss.Text = tot.ToString();
        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {
            //one

            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];

                else
                {

                    this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];

                    //MessageBox.Show("Nasa last Line knaa je");
                    bunifuThinButton26_Click(sender, e);
                    return;
                }
                //1/12/2021 == additinal 2 row
                txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                txtitemdescription.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();


                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
                //JSON FORMAT
                txtItemCode_TextChanged(sender, e);
                showRawMatsDataGrid();

                double mainbalance;
                double selectquantity;


                mainbalance = double.Parse(txtrepackavailable.Text);
                selectquantity = double.Parse(txttotalQty.Text);
                if (mainbalance < selectquantity)
                {
                    NoBalanceNotify();

                    //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                    txtbags.BackColor = Color.Yellow;
                    txtbags.Focus();
                    ControlBox = true;
                    frmProductionSchedule_Load(sender, e);
                    return;
                }
                else
                {

                    txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
                    //MessageBox.Show("Eto Ang Mensaheng Una " + txtitemdescription.Text + " " + txttotalQty.Text + "");
                    btnStartingValidation_Click(sender, e);

                }

            }


        }











        private void btngreaterthan_Click(object sender, EventArgs e)
        {

            int prev = this.dgvImport.CurrentRow.Index - 1;
            if (prev >= 0)
            {

                this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];

            }
            else
            {
                //FirstLine();
            }

        }

        void FirstLine()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.ContentText = "You are already in the First Line";
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.LightBlue;
            popup.Popup();

            popup.ContentColor = Color.Black;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.TitleColor = Color.Black;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        private void dgvImport_CurrentCellChanged(object sender, EventArgs e)
        {
            showImportDataGrid();

        }




        void showImportDataGrid()
        {
            //if (ready == true)
            //{
                if (dgvImport.CurrentRow != null)
                {
                    if (dgvImport.CurrentRow.Cells["recipe_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvImport.CurrentRow.Cells["recipe_id"].Value);
                        txtItemCode.Text = dgvImport.CurrentRow.Cells["item_code"].Value.ToString();

                        txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                        txtrpcategory.Text = dgvImport.CurrentRow.Cells["rp_category"].Value.ToString();
                        txtitemdescription.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();

                    }
                }
            //}
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            //buto

            if (txtrpcategory.Text == "MICRO")
            {




                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);

                string sqlquery = "select a.item_id,a.item_code,a.item_description,a.total_quantity_raw,a.qty_repack_available,a.qty_repack,a.qty_production,ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0) - ISNULL(t7.OUTING,0) as RESERVED from [dbo].[rdf_raw_materials] a LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where BC.transaction_type='PO' group by BC.r_item_code) t5 on a.item_code = t5.r_item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on a.item_code = t6.r_item_code LEFT JOIN ( select BC.item_code, sum(CAST(BC.formulation_qty as float))  as MACRESERVED from rdf_recipe_to_production BC where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and status_of_person IS NULL group by BC.item_code) t2 on a.item_code = t2.item_code LEFT JOIN ( select BC.item_code, sum(CAST(REPLACE(BC.qty,',','') as float))  as OUTING from rdf_transaction_out_progress BC where BC.is_active='1' group by BC.item_code) t7 on a.item_code = t7.item_code WHERE a.item_code = '" + txtItemCode.Text + "'";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvMaster2.DataSource = dt;
                sql_con.Close();
            }

            else
            {


                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);

                string sqlquery = "select a.item_id,a.item_code,a.item_description,a.total_quantity_raw,a.qty_repack_available,a.qty_repack,a.qty_production,ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0) - ISNULL(t7.OUTING,0) as RESERVED from [dbo].[rdf_raw_materials] a LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where BC.transaction_type='PO' group by BC.r_item_code) t5 on a.item_code = t5.r_item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on a.item_code = t6.r_item_code LEFT JOIN ( select BC.item_code, sum(CAST(BC.quantity as float)*2)  as MACRESERVED from rdf_recipe_to_production BC where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and status_of_person IS NULL group by BC.item_code) t2 on a.item_code = t2.item_code LEFT JOIN ( select BC.item_code, sum(CAST(REPLACE(BC.qty,',','') as float))  as OUTING from rdf_transaction_out_progress BC where BC.is_active='1' group by BC.item_code) t7 on a.item_code = t7.item_code WHERE a.item_code = '" + txtItemCode.Text + "'";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvMaster2.DataSource = dt;
                sql_con.Close();



            }
        }

        private void dgvMaster2_CurrentCellChanged(object sender, EventArgs e)
        {
  
            showRawMatsDataGrid();
        }

        void showRawMatsDataGrid()
        {
            //if (ready == true)
            //{
                if (dgvMaster2.CurrentRow != null)
                {
                    if (dgvMaster2.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster2.CurrentRow.Cells["item_id"].Value);
                        txtrepackavailable.Text = dgvMaster2.CurrentRow.Cells["RESERVED"].Value.ToString();


                    }
                }
            //}
        }

        private void btnStartingValidation_Click(object sender, EventArgs e)
        {


            //start
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, txtbags.Text, "", "", "", "", "", "", "", "", "","", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                FeedCodeNotExists();
                return;
            }


            if (cboFeedCode.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                cboFeedCode.Focus();
                cboFeedCode.Select();
                cboFeedCode.BackColor = Color.Yellow;
                return;
            }

            if (cmbBagandBin.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                cmbBagandBin.Select();
                cmbBagandBin.Focus();
                return;
            }


            //gerard singian comment
            if (txtbags.Text == "0")
            {
                InvalidBagsQty();
                cmbBagandBin.Focus();
                cmbBagandBin.Select();
                cmbBagandBin.BackColor = Color.Yellow;
                return;
            }


            if (txtseries.Text.Trim() == string.Empty)
            {
                EmptyFieldNotifyseries();
                NoMixingNotify();
                //frmmixingcapacity myMixingCapacity = new frmmixingcapacity();
                //myMixingCapacity.ShowDialog();
                return;
            }

            if (txtcorntype.Text.Trim() == string.Empty)
            {
                EmptyFieldNotifyseries();
                NoMixingNotify();
                //frmmixingcapacity myMixingCapacity = new frmmixingcapacity();
                //myMixingCapacity.ShowDialog();
                return;
            }

            if (txtbags.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                txtbags.Focus();
                txtbags.Select();
                txtbags.BackColor = Color.Yellow;
                return;
            }


            if (txtretailbin.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();

                txtretailbin.Focus();
                return;
            }

            double validation1;
            double validation2;

            validation1 = double.Parse(txtseries.Text);
            validation2 = double.Parse(txtbags.Text);

            if (validation1 < validation2)
            {
                BagvsMixing();
                txtbags.Text = "";
                txtbags.Focus();
                return;
            }
            else
            {

            }


            if (txtnobatch.Text.Contains("."))
            {

                BagsDotNotify();
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                txtbags.Select();
                return;
            }
            else
            {
                //MessageBox.Show("DisApproved");
            }




            //end
            //gerard singian

            btnSubmit.Enabled = false;
            picload.Visible = true;
            ControlBox = false;





            //4/20/2021 Debugging Paalam Fedora Hhahaha
            showImportDataGrid();
            txtItemCode_TextChanged(sender, e);
            showRawMatsDataGrid();

            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalQty.Text);
            if (mainbalance < selectquantity)
            {
                NoBalanceNotify2();

                //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                ControlBox = true;
                frmProductionSchedule_Load(sender, e);
                return;
            }
            else
            {
                //WithBalanceNotify(); alis muna 4/13/2020
                //MessageBox.Show("Epiman");
                btnlessthan_Click(sender, e);
                //MessageBox.Show("1");

            }
            //1/10/2021
            //load_search();
            //Computation();
            //picload.Visible = false;
            //ControlBox = true;
            //btnSubmit.Enabled = true;
            //txtdatenowstamp.Text = DateTime.Now.ToString("M/d/yyyy");

        }



        void NoBalanceNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "/NOT ENOUGH STOCK FOR " + txtitemdescription.Text + " CURRENT BALANCE IS " + txtrepackavailable.Text + " AND THE ACTUAL NEEDED FOR PRODUCTION IS " + txttotalQty.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            btnLowInventory_Click(new object(), new System.EventArgs());
        }


        void NoBalanceNotify3()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "///NOT ENOUGH STOCK FOR " + txtitemdescription.Text + " CURRENT BALANCE IS " + txtrepackavailable.Text + " AND THE ACTUAL NEEDED FOR PRODUCTION IS " + txttotalQty.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            btnLowInventory_Click(new object(), new System.EventArgs());
        }

        void NoBalanceNotify2()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "//NOT ENOUGH STOCK FOR " + txtitemdescription.Text + " CURRENT BALANCE IS " + txtrepackavailable.Text + " AND THE ACTUAL NEEDED FOR PRODUCTION IS " + txttotalQty.Text + "";
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

            btnLowInventory_Click(new object(), new System.EventArgs());
        }

        void NoBalanceNotify4()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "NOT ENOUGH STOCK FOR " + txtitemdescription.Text + " CURRENT BALANCE IS " + txtrepackavailable.Text + " AND THE ACTUAL NEEDED FOR PRODUCTION IS " + txttotalQty.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;

            btnLowInventory_Click(new object(), new System.EventArgs());
        }

        void NoBalanceNotifyforEdit()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "NOT ENOUGH STOCK FOR " + txtitemdescription.Text + " CURRENT BALANCE IS " + txtrepackavailable.Text + " AND THE ACTUAL NEEDED FOR PRODUCTION IS " + txttotalhere.Text + "";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }




        private void btnfinishvalidation_Click(object sender, EventArgs e)
        {
            //mani

            //sabo
            //MessageBox.Show("Jilo");


            //1/12/2021
            txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
            txtitemdescription.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();
            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalQty.Text);
            if (selectquantity > mainbalance)
            {
                NoBalanceNotify4();
                return;
            }
            else
            {
                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
                double rp1;
                double rp2;
                double rpavailable;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalQty.Text);

                rpavailable = rp1 - rp2;


                txtdeductions.Text = Convert.ToString(rpavailable);
                //WithBalanceNotify(); alis muna 4 / 13 / 2020
                QueryOutProduction();
                txtdeductions.Text = "";
                btnlessthan2_Click(sender, e);
                //MessageBox.Show("1");

            }
        }


        void QueryOutProduction()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            //deploy

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_raw_materials] SET qty_production='" + txtdeductions.Text + "'  WHERE item_code= '" + txtItemCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;

            sql_con.Close();
        }



        void QueryUpdateprodadvance()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            //deploy

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);


            DeleteFormulationEditMode();

            //2
            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET p_bags='" + txtbags.Text + "' ,p_nobatch='" + txtnobatch.Text + "',no_batch_in_production='" + txtnobatch.Text + "',bags_int='" + txtbags.Text + "',batch_int='" + txtnobatch.Text + "',bagorbin='" + cmbBagandBin.Text + "',proddate='" + mfg_datePicker.Text + "',additional_bin='" + txtretailbin.Text + "'  WHERE prod_id= '" + txtidna.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;

            cmbBagandBin.Enabled = false;
            sql_con.Close();

            btndowntime_Click(new object(), new System.EventArgs());
        }
        private void btnlessthan2_Click(object sender, EventArgs e)
        {


            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];
                else
                {
                    //LastLine();
                    //MessageBox.Show("Finish na"); 4/14/2020


                    //MessageBox.Show("Last 1");

                    mode = "add";
                    SaveProduction();
                    bunifuThinButton29_Click(sender, e); /*//pang details lang eto hide and show*/


                    AddedSuccess(); // bunifu message popup
                    Clear(); //clear logs
                    load_Schedules_approved(); //call  prod schedules
                    load_Schedules();  // load  my schedules


                    //1/23/2021

                    btndowntime_Click(sender, e);
                    //end
                    //home
                    frmProductionSchedule_Load(sender, e);
                    //


                    load_search();
                    Computation();
                    picload.Visible = false;
                    ControlBox = true;
                    btnSubmit.Enabled = true;
                    //

                    btngreaterthan_Click(sender, e);

                    return;
                }
            }


            //1/12/2021
            txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
            txtitemdescription.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();
            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();


            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txtQuantity.Text);
            if (mainbalance < selectquantity)
            {
                NoBalanceNotify3();
                return;
            }
            else


            {
                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

                double rp1;
                double rp2;
                double rpavailables;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalQty.Text);

                rpavailables = rp1 - rp2;
                txtdeductions.Text = Convert.ToString(rpavailables);
                //WithBalanceNotify();
                QueryOutProduction();
                txtdeductions.Text = "";
                btnfinishvalidation_Click(sender, e);
                //btnlessthan_Click(sender, e);
                //MessageBox.Show("1");

            }






        }

        private void txttotalQty_TextChanged(object sender, EventArgs e)
        {
            //try
            //{


            //    txtdeductions.Text = (float.Parse(txtrepackavailable.Text) - float.Parse(txttotalQty.Text)).ToString();
            //}
            //catch (Exception)
            //{


            //}
        }

        private void txtdeductions_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboFeedCode_TextChanged(object sender, EventArgs e)
        {
            doSearch();

        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
     
        





                //txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
                double rp1;
                double rp2;
                double rpavailable;
                double batch;
                double quantity;
                double answer_visible;
                double times2;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalQty.Text);
                batch = double.Parse(txtnobatch.Text);
                quantity = double.Parse(txtQuantity.Text);

                times2 = quantity * 1;
                answer_visible = times2 * batch;
                //rpavailable = rp1 + rp2;
                //gerard version 2
                rpavailable = rp1 + answer_visible;

                //txtItemCode.Text = dgvImport.CurrentRow.Cells["item_code"].Value.ToString();


                txtdeductions.Text = Convert.ToString(rpavailable);
                //MessageBox.Show("Male data"+txtitemdescription.Text +" "+rpavailable);
              
            //WithBalanceNotify(); alis muna 4 / 13 / 2020
                QueryOutProduction();
                txtdeductions.Text = "";
                btnlessthan3_Click(sender, e);
                //MessageBox.Show("1");
            //}
            //else
            //{
            //    //MessageBox.Show("Male 1");
            //    txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            //    double rp1;
            //    double rp2;
            //    double rpavailable;
            //    double batch;
            //    double quantity;
            //    double answer_visible;

            //    rp1 = double.Parse(txtrepackavailable.Text);
            //    rp2 = double.Parse(txttotalQty.Text);
            //    batch = double.Parse(txtnobatch.Text);
            //    quantity = double.Parse(txtQuantity.Text);
            //    double times2;

            //    rp1 = double.Parse(txtrepackavailable.Text);
            //    rp2 = double.Parse(txttotalQty.Text);
            //    batch = double.Parse(txtnobatch.Text);
            //    quantity = double.Parse(txtQuantity.Text);


        }

        private void btnlessthan3_Click(object sender, EventArgs e)
        {


            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];
                else
                {
                    //LastLine();
                    //MessageBox.Show("Finish  Cancel"); Remove na 4/14/2020
                    //MessageBox.Show("Last 2");


                    btncheckempty_Click(sender, e); //to datagrid 1
                    ControlBox = true;

                    UpdateInactiveFormulationEditMode();
                    cancelNotify();
                    load_Schedules();
                    load_Schedules_approved();
                    loadcancel();



                    load_search();

                    btngreaterthan_Click(sender, e);
                    frmProductionSchedule_Load(sender, e);
                    //bunifuThinButton26_Click(sender, e);
                    return;
                }
            }

            //MessageBox.Show("FeMale 2");
            //double mainbalance;
            //double selectquantity;


            //mainbalance = double.Parse(txtrepackavailable.Text);
            //selectquantity = double.Parse(txtQuantity.Text);
            //if (mainbalance < selectquantity)
            //{
            //NoBalanceNotify();
            //return;
            //txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

            double rp1;
                double rp2;
                double rpavailables;
                double batch;
                double quantity;
                double answer_visible;
                double times2;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalQty.Text);
                batch = double.Parse(txtnobatch.Text);
                quantity = double.Parse(txtQuantity.Text);

            times2 = quantity * 1;
            answer_visible = times2 * batch;
                //rpavailable = rp1 + rp2;
                //gerard version 2
                rpavailables = rp1 + answer_visible;


                //rpavailables = rp1 + rp2;
                txtdeductions.Text = Convert.ToString(rpavailables);
                //WithBalanceNotify();
                QueryOutProduction();
                txtdeductions.Text = "";
                btnRollback_Click(sender, e);




        }

        private void btnAdd_Click_2(object sender, EventArgs e)
        {
            //this.cboFeedCode.Text = this.cboFeedCode.Text.ToUpper();
            btnStartingValidation_Click(sender, e);

            txtbags.BackColor = Color.White;
            cboFeedCode.BackColor = Color.White;
        }

        private void CantncelButton_Click(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            DeleteFormulationEditMode();
            //1 cancell langh eto
            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET iscancel='1' WHERE p_feed_code='" + cboFeedCode.Text + "' AND prod_id='" + txtproduction_id.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;

            //txtsearchitems_TextChanged(sender, e);
   
            btndowntime_Click(new object(), new System.EventArgs());









            sql_con.Close();
        }

        private void btneditvalidation_Click(object sender, EventArgs e)
        {
            ControlBox = false;

            lblconfirmbags.Visible = false;
            txtcurrentbags.Visible = false;





            double validation1;
            double validation2;

            validation1 = double.Parse(txtseries.Text);
            validation2 = double.Parse(txtbags.Text);

            if (validation1 < validation2)
            {
                BagvsMixing();
                txtbags.Text = "";
                txtbags.Focus();
                return;
            }
            else
            {

            }







            double bagsdpulicate;
            double bags;


            bagsdpulicate = double.Parse(txtbagsduplicate.Text);
            bags = double.Parse(txtbags.Text);

            if (bagsdpulicate < bags)

            {
                //MessageBox.Show("Mataas"); 5/5/2020
                //txtduplicatebagstotal.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsduplicate.Text)).ToString();
                //txttotalduplicatebatch.Text = (float.Parse(txtnobatch.Text) - float.Parse(txtbatchduplicate.Text)).ToString();
                btnhigher_Click(sender, e);

                return;

            }

            else
            {
                //MessageBox.Show("Mababa");5//
                //txtduplicatebagstotal.Text = (float.Parse(txtbagsduplicate.Text) - float.Parse(txtbags.Text)).ToString();
                //txttotalduplicatebatch.Text = (float.Parse(txtbatchduplicate.Text) - float.Parse(txtnobatch.Text)).ToString();
                //btnhigher_Click(sender, e);
                btnLower_Click(sender, e);
                return;

            }





        }

        private void btnlessthanedit_Click(object sender, EventArgs e)
        {
            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];

                else
                {

                    this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                    //bunifuThinButton26_Click(sender, e);
                    //metroButton2_Click(sender, e);
                    //MessageBox.Show("Nasa last Line knaa");
                    //bunifuThinButton210_Click(sender,e);
                    //metroButton2_Click(sender, e);
                    btnfinalhighersave_Click(sender, e);
                    return;
                }

                txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
                double mainbalance;
                double selectquantity;


                mainbalance = double.Parse(txtrepackavailable.Text);
                selectquantity = double.Parse(txttotalhere.Text);
                if (mainbalance < selectquantity)
                {
                    NoBalanceNotifyforEdit();

                    //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                    txtbags.BackColor = Color.Yellow;
                    txtbags.Focus();
                    return;
                }
                else
                {
                    //MessageBox.Show("Keribels");
                    txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
                    //btneditvalidation_Click(sender, e);
                    btnhigher_Click(sender, e);

                }

            }

        }

        private void dgvApproved_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboFeedCode_SelectedIndexChanged(sender, e);

            double actualbags;
            double bags;
            double sagot;
            double final;

            bags = double.Parse(lblactualCount.Text);
            actualbags = double.Parse(lblavailablebags.Text);


            sagot = bags / actualbags;
            final = sagot * (double)100;


            lblpercentage.Text = Math.Round(final, 1).ToString();

        }


        private void txttotalduplicatebatch_TextChanged(object sender, EventArgs e)
        {
            if (txtbatchduplicate.Text.Trim() == string.Empty)
            {

            }
            else
            {


                txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtbatchduplicate.Text)).ToString();
            }
        }

        private void btnhigher_Click(object sender, EventArgs e)
        {
            picload.Visible = true;
            btnupdatelower.Enabled = false;
            btnSubmit.Enabled = false;
            bunifuThinButton210.Enabled = false;
            ControlBox = false;
            //start
            //dSet.Clear();
            //dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, txtbags.Text, "", "", "", "", "", "existsornot");

            //if (dSet.Tables[0].Rows.Count > 0)
            //{
            //    //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //cboFeedCode.Focus();

            //}
            //else
            //{
            //    FeedCodeNotExists();
            //    return;
            //}


            //if (cboFeedCode.Text.Trim() == string.Empty)
            //{
            //    EmptyFieldNotify();
            //    cboFeedCode.Focus();
            //    cboFeedCode.Select();
            //    cboFeedCode.BackColor = Color.Yellow;
            //    return;
            //}

            //if (txtbags.Text.Trim() == string.Empty)
            //{
            //    EmptyFieldNotify();
            //    txtbags.Focus();
            //    txtbags.Select();
            //    txtbags.BackColor = Color.Yellow;
            //    return;
            //}


            //if (txtnobatch.Text.Contains("."))
            //{
            //    //MessageBox.Show("Approved");
            //    BagsDotNotify();
            //    txtbags.BackColor = Color.Yellow;
            //    txtbags.Focus();
            //    txtbags.Select();
            //    return;
            //}
            //else
            //{
            //    //MessageBox.Show("DisApproved");
            //}














            //end













            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalhere.Text);
            if (mainbalance < selectquantity)
            {
                NoBalanceNotifyforEdit();

                //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                return;
            }
            else
            {

                //WithBalanceNotify(); alis muna 4/13/2020
                btnlessthanedit_Click(sender, e);
                //MessageBox.Show("1");

            }

            QueryUpdateprodadvance();//gerardsingian

            picload.Visible = false;
            btnupdatelower.Enabled = true;
            btnSubmit.Enabled = true;
            bunifuThinButton210.Enabled = true;
            ControlBox = true;
        }

        private void txtbagsduplicate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbatchduplicate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnfinishvalidationedit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Girl 1");
            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalhere.Text);
            if (selectquantity > mainbalance)
            {
                NoBalanceNotifyforEdit();
                return;
            }
            else
            {
                txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
                double rp1;
                double rp2;
                double rpavailable;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalhere.Text);

                rpavailable = rp1 - rp2;


                txtdeductions.Text = Convert.ToString(rpavailable);
                //WithBalanceNotify(); alis muna 4 / 13 / 2020
                QueryOutProduction();
                txtdeductions.Text = "";
                btnlessthan2edit_Click(sender, e);
                //MessageBox.Show("1");

            }
        }

        private void btnlessthan2edit_Click(object sender, EventArgs e)
        {

            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];
                else
                {
                    //LastLine();
                    //MessageBox.Show("Finish na"); 4/14/2020
                    //MessageBox.Show("Girl Lasing");

                    QueryUpdateprodadvance();
                    UpdateOkay();
                    picload.Visible = false;
                    ControlBox = true;
                    btnupdatelower.Enabled = true;
                    btnSubmit.Enabled = true;
                    bunifuThinButton210.Enabled = true;
                    ControlBox = true;

                    frmProductionSchedule_Load(sender, e);
                    load_Schedules();
                    load_SchedulesCancelByApprover();


                    btngreaterthan_Click(sender, e);
                    //bunifuThinButton26_Click(sender, e);
                    return;
                }
            }

            //MessageBox.Show("Girl 1");

            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalhere.Text);
            if (mainbalance < selectquantity)
            {
                NoBalanceNotifyforEdit();
                return;
            }
            else


            {
                txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();

                double rp1;
                double rp2;
                double rpavailables;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalhere.Text);

                rpavailables = rp1 - rp2;
                txtdeductions.Text = Convert.ToString(rpavailables);
                //WithBalanceNotify();
                QueryOutProduction();
                txtdeductions.Text = "";
                btnfinishvalidationedit_Click(sender, e);
                //btnlessthan_Click(sender, e);
                //MessageBox.Show("1");

            }



        }

        private void txttotalduplicatebatch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtduplicatebagstotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, txtbags.Text, "", "", "", "", "", "", "", "", "","", "existsornot");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                //MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboFeedCode.Focus();

            }
            else
            {
                FeedCodeNotExists();
                return;
            }


            if (cboFeedCode.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                cboFeedCode.Focus();
                cboFeedCode.Select();
                cboFeedCode.BackColor = Color.Yellow;
                return;
            }

            if (txtbags.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();
                txtbags.Focus();
                txtbags.Select();
                txtbags.BackColor = Color.Yellow;
                return;
            }


            if (txtnobatch.Text.Contains("."))
            {
                //MessageBox.Show("Approved");
                BagsDotNotify();
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                txtbags.Select();
                return;
            }
            else
            {
                //MessageBox.Show("DisApproved");
            }














            //end















            btnlessthaneditlower_Click(sender, e);


            //}
        }

        private void btnlessthaneditlower_Click(object sender, EventArgs e)
        {
            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];

                else
                {

                    this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                    //bunifuThinButton26_Click(sender, e);
                    //metroButton2_Click(sender, e);
                    MessageBox.Show("Nasa last Line knaa");
                    //bunifuThinButton210_Click(sender,e);
                    //metroButton2_Click(sender, e);4/16/2020

                    metrolower_Click(sender, e);
                    return;
                }
                txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
                double mainbalance;
                double selectquantity;


                //mainbalance = double.Parse(txtrepackavailable.Text);
                //selectquantity = double.Parse(txttotalhere.Text);
                //if (mainbalance > selectquantity)
                //{
                //    NoBalanceNotifyforEdit();

                //    //this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
                //    txtbags.BackColor = Color.Yellow;
                //    txtbags.Focus();
                //    return;
                //}
                //else
                //{
                //MessageBox.Show("Keribels OUTerspace");
                txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
                //btneditvalidation_Click(sender, e);
                btnLower_Click(sender, e);

                //}

            }
        }

        private void metrolower_Click(object sender, EventArgs e)
        {

            if (txtbags.Text.Trim() == txtbagsduplicate.Text.Trim())

            {
                //MessageBox.Show("Same Quantity Bags If you want to edit change the quantity of bags");
                SameBagsNotify();
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                return;
            }

            else
            {


            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Production Schedule ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                ControlBox = false;
                bunifuThinButton210.Visible = false;
                bunifuThinButton27.Visible = true;
                bunifuUndo.Visible = false;
                //bunifuThinButton29_Click(sender, e);
                //mode = "edit";

                picload.Visible = true;
                btnupdatelower.Enabled = false;
                btnSubmit.Enabled = false;
                bunifuThinButton210.Enabled = false;
                ControlBox = false;





                //if (txtbags.Text.Trim() == string.Empty)
                //{

                //}

                //else
                //{

                double validation1;
                double validation2;

                validation1 = double.Parse(txtseries.Text);
                validation2 = double.Parse(txtbags.Text);

                if (validation1 < validation2)
                {
                    BagvsMixing();
                    txtbags.Text = "";
                    txtbags.Focus();
                    return;
                }
                else
                {

                }

                //}


                picload.Visible = true;
                btnupdatelower.Enabled = false;
                btnSubmit.Enabled = false;
                bunifuThinButton210.Enabled = false;
                ControlBox = false;
                btnfinislower_Click(sender, e);
            }

            //EditMode();


            else
            {
                bunifuUndo_Click(sender, e);
                ControlBox = true;
                return;
            }
            //btnfinishvalidationedit_Click(sender, e); ///dito muna ang minus querys

        }


        void EditMode()
        {

            dSet.Clear();
            //dSet = objStorProc.rdf_sp_supplier(p_id, txtSupplier.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtEmailAddress.Text.Trim(), "edit"); buje muna
            dSet = objStorProc.rdf_sp_prod_schedules(p_id, cboFeedCode.Text.Trim(), txtbags.Text.Trim(), txtnobatch.Text.Trim(), mfg_datePicker.Text.Trim(), txtdatenow.Text.Trim(), txtreason.Text.Trim(), textBox1.Text.Trim(), txtseries.Text.Trim(), cmbBagandBin.Text.Trim(), txtretailbin.Text.Trim(), txtcorntype.Text.Trim(), txtaddedby.Text.Trim(), "edit");

            QueryUpdateprodadvance(); //gerardsingian

            dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedCode.Text, txtaddedby.Text, "3.1 Production Schedule", "Updating Prod Schedule", txtdatenow2.Text, mfg_datePicker2.Text, txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");


        }
        private void btnfinislower_Click(object sender, EventArgs e)
        {

  

            txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
            double rp1;
            double rp2;
            double rpavailable;

            rp1 = double.Parse(txtrepackavailable.Text);
            rp2 = double.Parse(txttotalhere.Text);

            rpavailable = rp1 + rp2;
            //gerard version 1

            txtdeductions.Text = Convert.ToString(rpavailable);
            //WithBalanceNotify(); alis muna 4 / 13 / 2020
            QueryOutProduction();
            txtdeductions.Text = "";
            //btnlessthan2edit_Click(sender, e);
            btnlowerfinish2_Click(sender, e);
            //MessageBox.Show("1");

            //}

        }

        private void btnlowerfinish2_Click(object sender, EventArgs e)
        {

            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];
                else
                {
                    //LastLine();
                    //MessageBox.Show("Finish na"); 4/14/2020


                    //MessageBox.Show("End process");
                    EditMode();
                    UpdateOkay();
                    ControlBox = true;

                    picload.Visible = false;
                    btnupdatelower.Enabled = true;
                    btnSubmit.Enabled = true;
                    bunifuThinButton210.Enabled = true;

                    frmProductionSchedule_Load(sender, e);




                    btngreaterthan_Click(sender, e);
                    //bunifuThinButton26_Click(sender, e);
                    return;
                }
            }



            txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();

            double rp1;
            double rp2;
            double rpavailables;

            rp1 = double.Parse(txtrepackavailable.Text);
            rp2 = double.Parse(txttotalhere.Text);

            rpavailables = rp1 + rp2;
            txtdeductions.Text = Convert.ToString(rpavailables);
            //WithBalanceNotify();
            QueryOutProduction();
            txtdeductions.Text = "";
            btnfinislower_Click(sender, e);
            //btnlessthan_Click(sender, e);
            //MessageBox.Show("1");

            //}


        }

        private void btnupdatelower_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Production Schedule? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

            }
            else
            {

                return;
            }


            metrolower_Click(sender, e);
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {

        }

        private void btnfinalhighersave_Click(object sender, EventArgs e)
        {
            //pekpek
            if (txtbags.Text == txtbagsduplicate.Text)

            {
                //MessageBox.Show("Same Quantity Bags If you want to edit change the quantity of bags");
                SameBagsNotify();
                txtbags.BackColor = Color.Yellow;
                txtbags.Focus();
                //return;
            }





            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Update the Production Schedules !?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                bunifuThinButton210.Visible = false;
                bunifuThinButton27.Visible = true;
                bunifuUndo.Visible = false;
                //bunifuThinButton29_Click(sender, e);

                picload.Visible = true;
                ControlBox = false;
                btnupdatelower.Enabled = false;
                btnSubmit.Enabled = false;
                bunifuThinButton210.Enabled = false;
                ControlBox = false;

            

                // Laarnie

                dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedCode.Text, txtaddedby.Text, "3.1 Production Schedule", "Updating Prod Schedule", txtdatenow2.Text, mfg_datePicker2.Text, txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");


                btnfinishvalidationedit_Click(sender, e); ///dito muna ang minus querys


            }
            else
            {
                bunifuUndo_Click(sender, e);
                //btnfinishvalidationedit_Click(sender, e); ///dito muna ang minus querys
                ControlBox = true;
                return;
            }
        }

        private void txtidna_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvApproved_Click(object sender, EventArgs e)
        {
            bunifuCancel.Visible = true;
            bunifuThinButton27.Visible = true;
            btnupdatelower.Visible = false;
            bunifuThinButton210.Visible = false;


        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            btnAdd.Enabled = true;
            bunifuThinButton210.Visible = false;
            btnupdatelower.Visible = false;
            bunifuThinButton27.Visible = true;
            bunifuThinButton29_Click(sender, e);
            bunifuUndo.Visible = false;
            mfg_datePicker.Visible = false;
            dgvApproved.Enabled = true;
            mfg_datePicker2.Visible = true;
            bunifuSubmit.Visible = false;
            bunifuCancel.Visible = true;
            bunifuThinButton26.Enabled = false;

            btnSubmit.Enabled = true;
            bunifuCancel.Enabled = true;
            Cancelbtn.Visible = false;
            btnSubmit.Enabled = true;
            bunifuThinButton27.Enabled = true;

            label6.Visible = false;

            txtreason.Visible = false;
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

                        textBox1.Text = dataGridView2.CurrentRow.Cells["rp_feed_type"].Value.ToString();

                        txtcorntype.Text = dataGridView2.CurrentRow.Cells["corn_type_formula"].Value.ToString();
                        txtseries.Text = dataGridView2.CurrentRow.Cells["mixing_capacity"].Value.ToString();
                    }

                }
            }
        }

        private void dgvApproved2cancel_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void mfg_datePicker2_Enter(object sender, EventArgs e)
        {

        }

        private void mfg_datePicker2_ValueChanged(object sender, EventArgs e)
        {
            //ShowTheButtons();
            this.cboFeedCode.Text = this.cboFeedCode.Text.ToUpper();
        }

        public void ShowTheButtons()
        {


            //if (bunifuUndo.Visible == true)
            //{
            double bagsdpulicate;
            double bags;


            bagsdpulicate = double.Parse(txtbagsduplicate.Text);
            bags = double.Parse(txtbags.Text);

            if (bagsdpulicate < bags)

            {
                //MessageBox.Show("Mataas");
                txtduplicatebagstotal.Text = (float.Parse(txtbags.Text) - float.Parse(txtbagsduplicate.Text)).ToString();
                txttotalduplicatebatch.Text = (float.Parse(txtnobatch.Text) - float.Parse(txtbatchduplicate.Text)).ToString();
                txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
                bunifuThinButton210.Visible = true;
                btnupdatelower.Visible = false;

                //btnhigher_Click(sender, e);


            }

            else
            {
                //MessageBox.Show("Mababa");
                txtduplicatebagstotal.Text = (float.Parse(txtbagsduplicate.Text) - float.Parse(txtbags.Text)).ToString();
                txttotalduplicatebatch.Text = (float.Parse(txtbatchduplicate.Text) - float.Parse(txtnobatch.Text)).ToString();
                txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();

                bunifuThinButton210.Visible = false;
                btnupdatelower.Visible = true;
                //btnhigher_Click(sender, e);
                //return;

            }


            //}


        }


        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                if (dataGridView3.CurrentRow != null)
                {
                    if (dataGridView3.CurrentRow.Cells["levelstatus"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                        lblavailablebags.Text = dataGridView3.CurrentRow.Cells["levelstatus"].Value.ToString();


                    }

                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void lblactualCount_Click(object sender, EventArgs e)
        {

        }

        private void dgvCancel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            timer2.Start();
            if (lblrecords.Text == "0")
            {
                load_Schedules();
            }
            else
            {
                timer2.Stop();
            }
        }

        private void mfg_datePicker_ValueChanged(object sender, EventArgs e)
        {
            //ShowTheButtons();
        }

        private void cboFeedCode_Validated(object sender, EventArgs e)
        {

        }

        private void cboFeedCode_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cmbBagandBin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboFeedCode.Text = this.cboFeedCode.Text.ToUpper();
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

        private void dgvMaster_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvCancel_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvfinish_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvApprovenacancel_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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


        private void btnLowInventory_Click(object sender, EventArgs e)
        {
            frmMaterialLowInventory frm = new frmMaterialLowInventory(cboFeedCode.Text, textBox1.Text, mfg_datePicker2.Text, txtbags.Text, txtnobatch.Text, cmbBagandBin.Text, txtseries.Text, lblrecords.Text);
            //frmMaterialLowInventory frm = new frmMaterialLowInventory(textBox1.Text);
            //frm.Value = cboFeedCode.Text;

            frm.ShowDialog();



        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

        }

        private void lbllost_Click(object sender, EventArgs e)
        {

        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            //this.cboFeedCode.Text = this.cboFeedCode.Text.ToUpper();
            btnStartingValidation_Click(sender, e);

            txtbags.BackColor = Color.White;
            cboFeedCode.BackColor = Color.White;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //cboFeedCode_SelectedIndexChanged(sender, e);
            //cboFeedCode_SelectedValueChanged(sender, e);

            //doSearch();


            ////

            this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            //starting Query
            cmbBagandBin.BackColor = Color.Yellow;
            txtretailbin.BackColor = Color.Yellow;
            cboFeedCode.BackColor = Color.Yellow;
            mfg_datePicker2.CalendarMonthBackground = Color.Yellow;
            //double rpavailable;
            txtretailbin.Text = "0";
            //rp1 = double.Parse(txtQuantity.Text);

            btnAdd.Visible = true;
            //rpavailable = rp1 * 2;


            //txtQuantity.Text = Convert.ToString(rpavailable);

            textBox1.Text = "";
            txtdatenow.Visible = false;
            txtdatenow.Text = DateTime.Now.ToString();
            mfg_datePicker.Visible = true;
            bunifuThinButton26.Enabled = true;
            EnabledTrue();
            btnSubmit.Visible = false;
            bunifuThinButton29.Visible = true;
            Clear();
            bunifuThinButton27.Enabled = false;
            bunifuCancel.Enabled = false;
            mfg_datePicker2.Visible = false;

            bunifuThinButton29.Visible = true;
            bunifuThinButton29.BringToFront();

            bunifuThinButton27.Visible = false;
            bunifuCancel.Visible = false;
            cmbBagandBin.Text = "";
            cmbBagandBin.Enabled = true;
            txtseries.Text = "";
            txtcorntype.Text = "";
            txtretailbin.Enabled = true;
            cboFeedCode.Focus();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Production Schedule? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                metroButton2_Click(sender, e);
            }
            else
            {

                return;
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Production Schedule? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                metrolower_Click(sender, e);
            }
            else
            {

                return;
            }


      
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            btnAdd.Enabled = true;
            bunifuThinButton210.Visible = false;
            btnupdatelower.Visible = false;
            bunifuThinButton27.Visible = true;
            bunifuThinButton29_Click(sender, e);
            bunifuUndo.Visible = false;
            mfg_datePicker.Visible = false;
            dgvApproved.Enabled = true;
            mfg_datePicker2.Visible = true;
            bunifuSubmit.Visible = false;
            bunifuCancel.Visible = true;
            bunifuThinButton26.Enabled = false;

            btnSubmit.Enabled = true;
            bunifuCancel.Enabled = true;
            Cancelbtn.Visible = false;
            btnSubmit.Enabled = true;
            bunifuThinButton27.Enabled = true;

            label6.Visible = false;

            txtreason.Visible = false;
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            txtretailbin.Text = "";
            txtretailbin.Enabled = false;
            bunifuThinButton26.Enabled = false;
            mfg_datePicker.Visible = false;
            btnSubmit.Visible = true;
            bunifuThinButton29.Visible = false;
            cboFeedCode.Enabled = false;
            txtbags.Enabled = false;
            txtnobatch.Enabled = false;
            mfg_datePicker.Enabled = false;
            txtreason.Enabled = false;
            bunifuThinButton27.Enabled = true;
            bunifuCancel.Enabled = true;
            mfg_datePicker2.Visible = false;
            btnAdd.Visible = false;
           cmbBagandBin.BackColor = Color.White;
            txtretailbin.BackColor = Color.White;
            cboFeedCode.BackColor = Color.White;
            cmbBagandBin.Text = "";
            cmbBagandBin.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            mfg_datePicker.Visible = true;
            mfg_datePicker2.Visible = false;
            mfg_datePicker.Enabled = true;
          //  txtbags.Enabled = true;
            bunifuThinButton27.Visible = false;
            bunifuThinButton210.Visible = false;
            bunifuUndo.Visible = true;
            btnAdd.Enabled = false;
            //btnSubmit.Enabled = false;
            bunifuCancel.Visible = false;
            btnSubmit.Visible = false;
            cmbBagandBin.Enabled = true;

            //if (txtbatchduplicate.Text.Trim() == string.Empty)
            //{

            //}
            //else
            //{
            //10/17/2020  txtbags.Text = "";
            cmbBagandBin.Enabled = true;
            txtretailbin.Enabled = true;

            txtcurrentbags.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();

            lblconfirmbags.Visible = true;
            txtcurrentbags.Visible = true;
            cmbBagandBin.Focus();
            //    txttotalhere.Text = (float.Parse(txtQuantity.Text) * float.Parse(txttotalduplicatebatch.Text)).ToString();
            //}
        }

        private void button2_Click_4(object sender, EventArgs e)
        {
            this.dgvImport.CurrentCell = this.dgvImport.Rows[0].Cells[this.dgvImport.CurrentCell.ColumnIndex];
            btnAdd.Enabled = true;
            txtreason.BackColor = Color.White;
            bunifuThinButton210.Visible = false;
            btnupdatelower.Visible = false;
            bunifuThinButton27.Visible = true;
            bunifuThinButton29_Click(sender, e);
            bunifuUndo.Visible = false;
            mfg_datePicker.Visible = false;
            dgvApproved.Enabled = true;
            mfg_datePicker2.Visible = true;
            bunifuSubmit.Visible = false;
            bunifuCancel.Visible = true;
            bunifuThinButton26.Enabled = false;
            cmbBagandBin.Enabled = false;
            btnSubmit.Enabled = true;
            bunifuCancel.Enabled = true;

            btnSubmit.Enabled = true;
            bunifuThinButton27.Enabled = true;

            label6.Visible = false;
            txtretailbin.Enabled = false;
            txtreason.Visible = false;

            lblconfirmbags.Visible = false;
            txtcurrentbags.Visible = false;
            txtbags.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            metroButton3_Click(sender, e);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            bunifuThinButton210.Enabled = false;
            txtreason.BackColor = Color.Yellow;
            txtreason.Focus();
            btnAdd.Enabled = false;

            txtreason.Visible = true;
            btngreaterthan_Click(sender, e);
            //dgvApproved_CurrentCellChanged(sender, e);
            txtbags.BackColor = Color.White;
            cboFeedCode.BackColor = Color.White;


            //txtreason.Select();
            txtreason.Enabled = true;
            bunifuCancel.Visible = false;
            bunifuSubmit.Visible = true;
            bunifuUndo.Visible = true;
            dgvApproved.Enabled = false;

            Cancelbtn.Visible = true;
            bunifuUndo.Visible = false;
            label6.Visible = true;


            //btnSubmit.Enabled = false;
            bunifuThinButton27.Enabled = false;

            btnSubmit.Visible = false;
            bunifuThinButton27.Visible = false;

            if (txtnobatch.Text.Trim() == string.Empty)
            {

            }
            else
            {


                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            }

            txtreason.BackColor = Color.White;
        }

        private void bunifuThinButton212_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {



            if (cmbBagandBin.Text.Trim() == string.Empty)
            {
                if(txtretailbin.Text.Trim() == string.Empty)
                {

                }
                else
                {
                    txtretailbin_TextChanged(sender, e);
                    return;
                }
                txtbags.Text= "";
                txtnobatch.Text = "";
            }



            if (cmbBagandBin.Text == "BIN")
            {
                return;
            }
            if (cmbBagandBin.Text == "BAG")
            {
                return;
            }

            if (cmbBagandBin.Text.Trim() == string.Empty)
            {
            }
            else
            {

                if(txtretailbin.Text.Trim() == string.Empty)
                {
                    txtretailbin.Text = "0";
                }


                txtbags.Text = (float.Parse(cmbBagandBin.Text) + float.Parse(txtretailbin.Text)).ToString();
            }


            }

        private void txtretailbin_TextChanged(object sender, EventArgs e)
        {
            if(cmbBagandBin.Text.Trim()==string.Empty)
            {

            }
            else
            {
                textBox3_TextChanged(sender, e);
                return;
            }


            if(txtretailbin.Text.Trim() == string.Empty)
            {
                txtbags.Text = "";
                //txtnobatch.Text = "";
            }

            if(cmbBagandBin.Text == "BAG")
            {
                return;
            }
            if (cmbBagandBin.Text == "BIN")
            {
                return;
            }

            if (txtretailbin.Text.Trim() == string.Empty)
            {
            }
            else
            {
                if (cmbBagandBin.Text.Trim() == string.Empty)
                {
                    cmbBagandBin.Text = "0";
                }

                txtbags.Text = (float.Parse(cmbBagandBin.Text) + float.Parse(txtretailbin.Text)).ToString();

            }
            }

        private void cmbBagandBin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click_5(object sender, EventArgs e)
        {
            btnfinishvalidation_Click(sender, e);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(txtrepackavailable.Text);
            MessageBox.Show(txttotalQty.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double mainbalance;
            double selectquantity;


            mainbalance = double.Parse(txtrepackavailable.Text);
            selectquantity = double.Parse(txttotalQty.Text);
            if (selectquantity > mainbalance)
            {
                MessageBox.Show("Yes");

                return;
            }
            else
            {
                MessageBox.Show("No");

                return;
            }


        }


        public void DeleteFormulationEditMode()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "DELETE [dbo].[rdf_recipe_to_production]  where production_id='"+txtproduction_id.Text+"'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRunningRecipe.DataSource = dt;

            sql_con.Close();

        }

        public void UpdateInactiveFormulationEditMode()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] set status_of_person='1'  where production_id='" + txtproduction_id.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRunningRecipe.DataSource = dt;

            sql_con.Close();

        }

        public void FormulationeXTRACTION()
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,total_qty,total_prod,proddate,formulation_qty,batch) SELECT item_code,quantity, feed_code, '1','" + txtproduction_id.Text + "','1',rp_type,rp_feed_type,rp_description,rp_category,rp_group,'0','0','"+mfg_datePicker2.Text+"',CAST(quantity as float)*2 * '" + txtnobatch.Text + "','" + txtnobatch.Text + "' FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MICRO'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRunningRecipe.DataSource = dt;

            sql_con.Close();


            DoMicroChecking();

            //MessageBox.Show("New Data Inserted Into Database!");

        }







        private void btndowntime_Click(object sender, EventArgs e)
        {


            dSet.Clear();
            dSet = objStorProc.rdf_sp_prod_schedules(0, txtproduction_id.Text, "", "", "", "", "", "", "", "", "", "","", "exchangeFormulation");

            if (dSet.Tables[0].Rows.Count > 0)
            {
                ////MessageBox.Show("NOT RECOGNISE", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////cboFeedCode.Focus();
                //MessageBox.Show("A");
                //return;
            }
            else
            {
                //MessageBox.Show("b");
                FormulationeXTRACTION();

            }

        

        }

        void DoMicroChecking()
        {
            if (txtnobatch.Text == "1")
            {
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "2")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "2")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "3")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "4")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "5")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "6")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "7")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "8")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "9")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "10")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "11")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "12")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "13")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "14")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "15")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "16")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "17")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "18")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "19")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "20")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "21")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "22")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "23")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "24")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "25")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "26")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "27")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "28")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "29")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "30")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "31")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "32")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "33")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "34")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "35")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();


            }
            else if (txtnobatch.Text == "36")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "37")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "38")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }

            else if (txtnobatch.Text == "39")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "40")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "41")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "42")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "43")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "44")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "45")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "46")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "47")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "48")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
            }
            else if (txtnobatch.Text == "49")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();

            }
            else if (txtnobatch.Text == "50")
            {
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();
                mainPrimaryMacro();


            }
            else
            {
                MessageBox.Show("Bacth Not Found!");
            }
        }

        void mainPrimaryMacro()
        {


            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            //string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group) SELECT item_code, quantity, feed_code, repacking_status,'" + txtid.Text + "',is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MICRO'"AND rp_group='Validate';
            string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,total_prod,total_qty,proddate) SELECT item_code, quantity, feed_code, '0','" + txtproduction_id.Text + "',is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,'0','0','" + mfg_datePicker2.Text + "' FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MACRO'";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRunningRecipe.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();

        }










    }
}

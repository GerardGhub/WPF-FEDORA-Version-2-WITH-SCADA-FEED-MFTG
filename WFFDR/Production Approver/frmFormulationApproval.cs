using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using Tulpep.NotificationWindow;

namespace WFFDR
{
    public partial class frmFormulationApproval : Form
    {

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();
        myclasses xClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;
        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();
        string mode;
        ReportDocument rpt = new ReportDocument();
        string Rpt_Path = "";
        IStoredProcedures objStorProc = null;
        int temp_hid = 0;
        int p_id = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        public frmFormulationApproval()
        {
            InitializeComponent();
        }

        private void frmFormulationApproval_Load(object sender, EventArgs e)
        {
   txtcurrentdate.Text = DateTime.Now.ToString("M/d/yyyy");
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            txtaddedby.Text = userinfo.emp_name.ToUpper();
            txtreason.Text = "";
            dgvRepacked.Visible = false;
            dtpreceivingdate.Value = DateTime.Now;
            //dtpreceivingdate.Visible = false;
            dgv1stView.Visible = false;
            dgv2ndview.Visible = false;
            //this.WindowState = FormWindowState.Maximized;
            btncheckempty_Click(sender, e);
            ForApproval();
            Approved();
            IsForCancel();
            IsForCancelnaApproved();
            //dset = g_objStoredProcCollection.sp_IDGenerator(1, "Search", "All", txtSearch.Text, 1);
            //dataView.DataSource = dset.Tables[0];

            for (int i = 0; i <= dataView.RowCount; i++)
            {
                try
                {
                    dataView.Rows[i].Cells["selected"].Value = false;
                }
                catch (Exception) { }
            }

            try
            {
                //cmbHR_OIC.SelectedIndex = cmbHR_OIC.FindString("Rollaine Palo");
            }
            catch (Exception) { }

            rbt_check();

            load_Schedules_finish();

            if (lblcount.Text == "0")
            {
                timer1.Start();
                timer1_Tick(sender, e);
            }
            else
            {
                timer1.Stop();
            }

            if(lblcount.Text=="0")
            {



            }
            else
            {
                ForApproval();
                ApprovalData();
                Query();
                cALLfEEDtYPE();

                textBox1.Text = dgv2ndview.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                showCurrentCellData();
            }
            btnvalidateformualtion.Visible = false;
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


        void cALLfEEDtYPE()
        {
            if (dgv2ndview.RowCount > 0)
            {
                if (dgv2ndview.CurrentRow != null)
                {
                    if (dgv2ndview.CurrentRow.Cells["rp_feed_type"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                        textBox1.Text = dgv2ndview.CurrentRow.Cells["rp_feed_type"].Value.ToString();


                    }

                }
            }
        }





        public void ForApproval()
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


            //txtfooter.Text = dset2.Tables[0].Rows[number_of_rows]["company_name"].ToString() + Environment.NewLine
            //                + dset2.Tables[0].Rows[number_of_rows]["company_address_number"].ToString() + Environment.NewLine
            //                + dset2.Tables[0].Rows[number_of_rows]["company_phone_number"].ToString();

            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchforApprovalApprover", "All", txtSearch.Text, 1);
            dataView.DataSource = dset.Tables[0];
       lblcount.Text = dataView.RowCount.ToString();

        }



        void showCurrentCellData()
        {

            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["ID"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);
                        Query();
                        //mfg_datePicker2.Visible = true;
                        txtid.Text = dataView.CurrentRow.Cells["ID"].Value.ToString();
                        txtbags.Text = dataView.CurrentRow.Cells["Department"].Value.ToString();
                        //txtbags.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();
                        txtnobatch.Text = dataView.CurrentRow.Cells["TotalPack"].Value.ToString();
                        cboFeedCode.Text = dataView.CurrentRow.Cells["Emp_Number"].Value.ToString();
                        mfg_datePicker2.Text = dataView.CurrentRow.Cells["Position"].Value.ToString();
                        //txtdatenow.Text = dgvApproved.CurrentRow.Cells["added"].Value.ToString();
                    }

                }
            }
        }




        public void IsForCancelnaApproved()
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

            //cmbHR_OIC.DataSource = dset.Tables[0].DefaultView;
            //cmbHR_OIC.DisplayMember = dset.Tables[0].Columns[0].ToString();
            //cmbHR_OIC.ValueMember = dset.Tables[0].Columns[1].ToString();

            int number_of_rows = dset2.Tables[0].Rows.Count - 1;


            //txtfooter.Text = dset2.Tables[0].Rows[number_of_rows]["company_name"].ToString() + Environment.NewLine
            //                + dset2.Tables[0].Rows[number_of_rows]["company_address_number"].ToString() + Environment.NewLine
            //                + dset2.Tables[0].Rows[number_of_rows]["company_phone_number"].ToString();

            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchforApprovednaCancel", "All", txtSearch.Text, 1);
            dgvApprovenacancel.DataSource = dset.Tables[0];


        }










        public void IsForCancel()
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


    
            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchforApproverRequestCancel", "All", txtSearch.Text, 1);
            dgvCancel.DataSource = dset.Tables[0];


        }


        public void Approved()
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



            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchforApproved", "All", txtSearch.Text, 1);
            dgvApproved.DataSource = dset.Tables[0];


        }

        public void load_Schedules_finish()
        {
            string mcolumns = "prod_id,p_feed_code,rp_feed_type,p_bags,p_nobatch,proddate,dateadded,approved_date";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvfinish, mcolumns, "schedules_approved_finish");


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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i <= dataView.RowCount; i++)
                {
                    try
                    {
                        dataView.Rows[i].Cells["selected"].Value = true;
                    }
                    catch (Exception) { }
                }
            }
            else
            {

                for (int i = 0; i <= dataView.RowCount; i++)
                {
                    try
                    {
                        dataView.Rows[i].Cells["selected"].Value = false;
                    }
                    catch (Exception) { }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myglobal.Searchcategory = txtSearch.Text;
   

            for (int i = 0; i <= dataView.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updateapproval", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatereapproval", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updateapproval", "", "", 0);
                }

            }

            MessageBox.Show("SuccessFull Approved !");
            ForApproval();
            Approved();



            //if (mode == "company")
            //{
            //    myglobal.REPORT_NAME = "IDRepackReport";

            //    //PrintDialog printDialog = new PrintDialog();
            //    //if (printDialog.ShowDialog() == DialogResult.OK)

            //    {
            //        //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //        rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");



            //        //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
            //        //////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
            //        rpt.Refresh();






            //        rpt.SetParameterValue("Approved", myglobal.rp_item_description);
            //        rpt.SetParameterValue("Validity", myglobal.validity);
            //        rpt.SetParameterValue("Position", myglobal.position);




            //        //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

            //        //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            //    }



            //}
            //else if (mode == "hw")
            //{
            //    myglobal.REPORT_NAME = "IDReport(HW)";
            //}

            //frmReport frmReport = new frmReport();
            //frmReport.ShowDialog();
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {


        }

        private void txtmainsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void chkAll_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i <= dataView.RowCount; i++)
                {
                    try
                    {
                        dataView.Rows[i].Cells["selected"].Value = true;
                        //bunifuThinButton26.Visible = true;
                    }
                    catch (Exception) { }
                }
            }
            else
            {

                for (int i = 0; i <= dataView.RowCount; i++)
                {
                    try
                    {
                        dataView.Rows[i].Cells["selected"].Value = false;
                        //bunifuThinButton26.Visible = false;
                    }
                    catch (Exception) { }
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Approved the selected Production Schedule? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


                txtCreationDate.Text = DateTime.Now.ToString();
                dSet.Clear();
                dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedCode.Text, txtaddedby.Text, "3.2 Production Approval", "Approved a new Prod Sched", txtCreationDate.Text,txtid.Text,txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");


                for (int i = 0; i <= dataView.RowCount - 1; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value) == true)
                        {

                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updateapproval", "", "", 1);


                        }
                        else
                        {
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatereapproval", "", "", 0);

                        }
                    }
                    catch
                    {

                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updateapproval", "", "", 0);
                        MessageBox.Show("Catch");
                        return;
                    }

                }
       
                //MessageBox.Show("SuccessFull Approved !");
                btnvalidateformualtion.Visible = true;

                dataView_CurrentCellChanged_1(sender,e);
                QueryTryCatch();
                ViewDataProduction();

                CellChangedViewer();
                UpdateProductionTimes();

                dSet.Clear();
                dSet = objStorProc.rdf_sp_prod_schedules(0, txtid.Text, "", "", "", "", "", "", "", "", "", "", "exchangeFormulation");

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
                    QueryInsertRdfRecipe();

                }


    
                SuccessFullyApproved();

                ForApproval();
                Approved();
                if (lblcount.Text == "0")
                {
                    timer1.Start();
                    timer1_Tick(sender, e);
                }
                else
                {
                    timer1.Stop();
                }


                frmFormulationApproval_Load(sender, e);

            }
            else

            {

                return;
            }
        }



        void UpdateProductionTimes()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET plannerAndapprover ='"+txtSumofProdAndApproval.Text+"' WHERE prod_id= '" + txtid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateProd.DataSource = dt;

            sql_con.Close();




        }




        void SuccessFullyApproved()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Production Schedule Successfully Approved";
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
            cboFeedCode.Text = "";
            bunifuThinButton26.Visible = false;
            bunifuThinButton28.Visible = false;



            if (lblcount.Text == "0")
            {



            }
            else
            {
                ForApproval();
                ApprovalData();
                Query();
                cALLfEEDtYPE();
                showCurrentCellData();
            }

        }


        void SuccessFullyApprovedCancel()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Successfully Cancelled the Approved Production Schedule";
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

        void WarningRepackNOTNULL()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Cannot Cancel this Production Schedule because we Already Have Material repack '"+lbltotalrepack.Text+"'";
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

        void SuccessFullyCancel()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Production Schedule successfully Cancelled";
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
        void LesthanDateNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Warning cannot the approved the production over the current date!";
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

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {


            DateTime time12 = DateTime.Parse(txtcurrentdate.Text);
            DateTime time22 = DateTime.Parse(mfg_datePicker2.Text);

            if(time12 > time22)
            {
                //MessageBox.Show("gastos");
                LesthanDateNotify();
                return;
            }
            else
            {

                //MessageBox.Show("Bastos");
                //return;
            }





            metroButton3_Click(sender, e);
        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (lblcount.Text=="0")
            {
                bunifuThinButton28.Visible = false;

                NoDataNotify();
                return;
            }
            groupBox3.Visible = true; // show if the data is not zero
            bunifuThinButton26.Visible = true;

            lblfeedcode.Visible = true;
         groupBox3.Visible = true;
            cboFeedCode.Visible = true;
            lblbags.Visible = true;
 
            txtbags.Visible = true;
        GroupBox1.Visible = true;
            lblproddate.Visible = true;
 
            mfg_datePicker2.Visible = true;
            lblbatch.Visible = true;

            txtnobatch.Visible = true;
            lblfeedtype.Visible = true;
 
            textBox1.Visible = true;
            lblreason.Visible = true;

            txtreason.Visible = true;







            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            
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

            //dgvImport_CurrentCellChanged(sender, e);
            //txtbags.Text = "";
            //txtbags.Focus();



            dgvImport_CurrentCellChanged(sender, e);

            if (txtnobatch.Text.Trim() == string.Empty)
            {

            }
            else
            {


                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            }


        }



        void ApprovalData()
        {

            if (lblcount.Text == "0")
            {
                bunifuThinButton28.Visible = false;

                NoDataNotify();
                return;
            }
            //bunifuThinButton26.Visible = true;
            GroupBox1.Visible = true;
            lblfeedcode.Visible = true;
           groupBox3.Visible = true;
            cboFeedCode.Visible = true;
            lblbags.Visible = true;
   
            txtbags.Visible = true;
  
            lblproddate.Visible = true;
      
            mfg_datePicker2.Visible = true;
            lblbatch.Visible = true;
  
            txtnobatch.Visible = true;
            lblfeedtype.Visible = true;

            textBox1.Visible = true;
            lblreason.Visible = true;
       
            txtreason.Visible = true;







            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy


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



                    btnsum_Click(new object(), new System.EventArgs());
            times2query();





            dgvImport_CurrentCellChanged(new object(), new System.EventArgs());

            if (txtnobatch.Text.Trim() == string.Empty)
            {

            }
            else
            {


                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            }

        }














        private void dataView_CurrentCellChanged_1(object sender, EventArgs e)
        {
            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["ID"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);
                        Query();
                        //mfg_datePicker2.Visible = true;
                        txtid.Text = dataView.CurrentRow.Cells["ID"].Value.ToString();
                        txtbags.Text = dataView.CurrentRow.Cells["Department"].Value.ToString();
                        //txtbags.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();
                        txtnobatch.Text = dataView.CurrentRow.Cells["TotalPack"].Value.ToString();
                        cboFeedCode.Text = dataView.CurrentRow.Cells["Emp_Number"].Value.ToString().ToUpper();
                        mfg_datePicker2.Text = dataView.CurrentRow.Cells["Position"].Value.ToString();
                        //txtdatenow.Text = dgvApproved.CurrentRow.Cells["added"].Value.ToString();
                    }

                }
            }
    
        }






        void Query()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";


            
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select * from [dbo].[rdf_recipe] WHERE feed_code = '" + cboFeedCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv2ndview.DataSource = dt;
  
            sql_con.Close();
        }




        void ViewDataProduction()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT * FROM [dbo].[rdf_production_advance] WHERE prod_id= '" + txtid.Text + "' AND is_selected='1' ";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateTimeLampse.DataSource = dt;

            sql_con.Close();





        }





        void QueryTryCatch()
        {

    txtDateAndTime.Text = DateTime.Now.ToString();
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET is_selected='1',repacking_status='ready',approved_date= '"+ dtpreceivingdate.Text + "', aproved_date_time = '"+txtDateAndTime.Text+"' WHERE prod_id= '" + txtid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateProd.DataSource = dt;
   
            sql_con.Close();




        }


        void QueryInsertRdfRecipe()
        {

            ////String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            //String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            ////deploy
            //SqlConnection sql_con = new SqlConnection(connetionString);



            ////string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group) SELECT item_code, quantity, feed_code, repacking_status,'" + txtid.Text + "',is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MICRO'";
            //string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,total_qty,total_prod,proddate) SELECT item_code, quantity, feed_code, '1','"+txtid.Text+"','1',rp_type,rp_feed_type,rp_description,rp_category,rp_group,'0','0','"+mfg_datePicker2.Text+"' FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MICRO'";
            //sql_con.Open();
            //SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            //SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            //DataTable dt = new DataTable();
            //sdr.Fill(dt);
            //dgv1stView.DataSource = dt;

            //sql_con.Close();

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,total_qty,total_prod,proddate,formulation_qty,batch) SELECT item_code,quantity, feed_code, '1','" + txtid.Text+"','1',rp_type,rp_feed_type,rp_description,rp_category,rp_group,'0','0','"+mfg_datePicker2.Text+"',CAST(quantity as float)*2 * '" + txtnobatch.Text + "','" + txtnobatch.Text + "' FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MICRO'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;

            sql_con.Close();
            DoMicroChecking();
        }

        void DoMicroChecking()
        {
            if(txtnobatch.Text=="1")
            {
                mainPrimaryMacro();
            }
            else if(txtnobatch.Text=="2")
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
            string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,total_prod,total_qty,proddate) SELECT item_code, quantity, feed_code, '0','" + txtid.Text + "',is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,'0','0','"+mfg_datePicker2.Text+"' FROM rdf_recipe WHERE feed_code= '" + cboFeedCode.Text + "' AND rp_category='MACRO'";
           
            
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvmacro.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();

        }







        void QueryCancelReason()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET iscancelapprover='" + txtreason.Text + "', iscancelapproverbit='1',approver_cancelrequest_date= '"+ dtpreceivingdate.Text + "' WHERE prod_id= '" + txtid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }

        void QueryCancelReasonRecipe()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET status_of_person='1' WHERE production_id= '" + txtid.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }

        void QueryCancelReasonRecipebottom()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_recipe_to_production] SET status_of_person='1' WHERE production_id= '" + txtapprovecancel.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }

        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            


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

        private void dataView_Click(object sender, EventArgs e)
        {
            if (lblcount.Text == "0")
            {
  
            }

            else
            {

                bunifuThinButton28.Visible = true;
            }
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            bunifuThinButton26.Visible = false;
            bunifuThinButton29.Visible = true;
            txtreason.Enabled = true;
            bunifuThinButton28.Visible = false;
            bunifuSubmit.Visible = true;
            txtreason.Focus();
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            bunifuThinButton26.Visible = false;
            txtreason.Enabled = false;
            bunifuThinButton29.Visible = false;
            bunifuSubmit.Visible = false;
            btnsubmitcancel.Visible = false;
            txtreason.BackColor = Color.White;
            if (txtrepackcount.Visible == true)
            {
                bunifuThinButton26.Visible = false;
                bunifuThinButton28.Visible = false;
            }
            else
            {
                bunifuThinButton26.Visible = true;
            }
        }


        void EmptyFieldNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Fill up the required Field";
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
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel the Production Schedule? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


                if (txtreason.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();
                    txtreason.Focus();
                    txtreason.Select();
                    txtreason.BackColor = Color.Yellow;
                    return;
                }
                ControlBox = false;
                dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedCode.Text, txtaddedby.Text, "3.2 Production Approval", "Cancel Request Production Schedule", txtDateAndTime.Text, txtid.Text, txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");



                QueryCancelReason();

                QueryCancelReasonRecipe();
                //SuccessFullyCancel();
                IsForCancel();
                bunifuSubmit.Visible = false;
                txtreason.Enabled = false;

                ////ForApproval();
                ////Approved();
                btnRollback_Click(sender, e);//4/17/2020
                bunifuThinButton29.Visible = false;
                txtreason.Text = "";
            }
            else
            {

                return;
            }
        }




        private void bunifuSubmit_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }

        private void txtreason_TextChanged(object sender, EventArgs e)
        {
            if (txtreason.Text.Trim() == string.Empty)
            {



            }
            else
            {
                txtreason.BackColor = Color.White;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(txtrepackavailable.Text.Trim() == string.Empty)
            {
                SelectAnItemFirst();
                return;
            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel the Approved Selected Production Schedule? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                groupBox3.Visible = true;
                double checkrepackentry;
                //        //double Allowances;
                double checkmacrorepackentry;

                checkrepackentry = double.Parse(txtrepackcount.Text);
                checkmacrorepackentry = double.Parse(txtmacrocount.Text);
                //        bag2 = double.Parse(txtActualQty.Text);

              lbltotalrepack.Text = (float.Parse(txtrepackcount.Text) + float.Parse(txtmacrocount.Text)).ToString();



                if (checkrepackentry > 0)
                {
                    WarningRepackNOTNULL();
                    return;
                }
                else
                {
              
                }


                if (checkmacrorepackentry > 0)
                {
                    WarningRepackNOTNULL();
                    return;
                }
                else
                {

                }




                txtreason.Enabled = true;
                txtreason.Focus();
                txtreason.Select();
                txtreason.BackColor = Color.Yellow;
                txtreason.Visible = true;
                lblreason.Visible = true;
                GroupBox1.Visible = true;
                if (txtreason.Text.Trim() == string.Empty)
                {
                    EmptyFieldNotify();

                    btnsubmitcancel.Visible = true;
                    bunifuThinButton29.Visible = true;
                    return;
                }


                dSet = objStorProc.rdf_sp_new_preparation(0, cboFeedCode.Text, txtaddedby.Text, "3.2 Production Approval", "Cancel Approved Production Schedule", txtDateAndTime.Text, txtid.Text,txtbags.Text, "", "", "", "", "", "", "", "", "", "", "addTrailLogs");


                QueryCancelApproved();

                QueryCancelReasonRecipebottom();
                IsForCancelnaApproved();

                btnRollback_Click(sender, e);

                txtreason.Visible = false;
                lblreason.Visible = false;
                GroupBox1.Visible = false;
                btnsubmitcancel.Visible = false;
                bunifuThinButton29.Visible = false;
                txtreason.Text = "";
                //frmFormulationApproval_Load(sender, e);

            }
            else

            {
               
                return;
            }

            frmFormulationApproval_Load(sender, e);
        }
        void SelectAnItemFirst()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Select the Production Schedule in the Datagrid First";
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
        void QueryCancelApproved()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            //string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET is_selected='1',repacking_status='ready',canceltheapprove='1',approved_cancel_date= '" + dtpreceivingdate.Text + "',iscancelreason='" + txtreason.Text + "' WHERE prod_id= '" + txtapprovecancel.Text + "'";

            string sqlquery = "UPDATE [dbo].[rdf_production_advance] SET is_selected='0',repacking_status='ready',canceltheapprove='1',approved_cancel_date= '"+dtpreceivingdate.Text+"',iscancelreason='" + txtreason.Text + "', iscancelapprover = '" + txtreason.Text + "', iscancelapproverbit = '1' WHERE prod_id= '" + txtapprovecancel.Text + "'";


           


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvOutMaterial.DataSource = dt; //out 4/14/2020
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvApproved.RowCount > 0)
            {
                if (dgvApproved.CurrentRow != null)
                {
                    //if (dgvApproved.CurrentRow.Cells["IDD"].Value != null)
                    //{
                        //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);
                        //Query();
                        //mfg_datePicker2.Visible = true;
                        txtapprovecancel.Text = dgvApproved.CurrentRow.Cells["IDD"].Value.ToString();
                        txtfeedCode.Text = dgvApproved.CurrentRow.Cells["FeedCode"].Value.ToString().ToUpper();
                   cboFeedCode.Text = dgvApproved.CurrentRow.Cells["FeedCode"].Value.ToString().ToUpper();
                    txtnobatch.Text = dgvApproved.CurrentRow.Cells["nobatch"].Value.ToString();
        //}

    }

                bunifuThinButton26.Visible = false;
}








            // show the total repack by cell changed
            if(txtrepackcount.Text.Trim()==string.Empty)
            {
                return;
            }
            if (txtmacrocount.Text.Trim() == string.Empty)
            {
                return;
            }
            lbltotalrepack.Text = (float.Parse(txtrepackcount.Text) + float.Parse(txtmacrocount.Text)).ToString();


        }

        private void dgvApproved_DoubleClick(object sender, EventArgs e)
        {
            metroButton2_Click(sender, e);

        }

        private void txtapprovecancel_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "select feed_code,rp_description from [dbo].[rdf_recipe_to_production] WHERE production_id = '" + txtapprovecancel.Text + "' AND repacking_status='1'";

            string sqlquery = "select feed_code,rp_description from [dbo].[rdf_recipe_to_production] WHERE production_id = '" + txtapprovecancel.Text + "' AND is_active='0' AND rp_category='MICRO'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvRepacked.DataSource = dt;
         txtrepackcount.Text = dgvRepacked.RowCount.ToString();
            sql_con.Close();
            ShowMyMacroID();
        }

        void ShowMyMacroID()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
 
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select feed_code,rp_description from [dbo].[rdf_recipe_to_production] WHERE production_id = '" + txtapprovecancel.Text + "' AND repacking_status='1' AND rp_category='MACRO'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMacroRepack.DataSource = dt;
            txtmacrocount.Text = dgvMacroRepack.RowCount.ToString();
            sql_con.Close();

        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Packby, emp.dateadded as Position from rdf_production_advance emp WHERE NOT emp.is_selected=1 AND emp.iscancel IS NULL AND emp.proddate = '"+ dtpreceivingdate.Text+ "' AND NOT emp.iscancelapproverbit IS NOT NULL";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataView.DataSource = dt;

            sql_con.Close();

        }

        private void btncheckempty_Click(object sender, EventArgs e)
        {
            if (dataView.Rows.Count > 0)
            {
                //MessageBox.Show("1");
               GroupBox1.Visible = false;


            }
            else
            {
                //bunifuThinButton212.Visible = true;
   

            }
        }

        void Show()
        {
            groupBox3.Visible = true;
            lblfeedcode.Visible = true;
 
            cboFeedCode.Visible = true;
            lblbags.Visible = true;

            txtbags.Visible = true;

            lblproddate.Visible = true;

            mfg_datePicker2.Visible = true;
            lblbatch.Visible = true;

            txtnobatch.Visible = true;
            lblfeedtype.Visible = true;


            lblreason.Visible = true;

            txtreason.Visible = true;
        }


        private void dgvApproved_Click_1(object sender, EventArgs e)
        {
            //show the Repackingh status in this entry
            
            txtrepackcount.Visible = true;
                    label8.Visible = true;
            lblmacro.Visible = true;
            lblmicro.Visible = true;
            txtmacrocount.Visible = true;

            lblgrandtotal.Visible = true;
            lbltotalrepack.Visible = true;

        }

        private void txtbags_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv2ndview_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgv2ndview.RowCount > 0)
            {
                if (dgv2ndview.CurrentRow != null)
                {
                    if (dgv2ndview.CurrentRow.Cells["recipe_id"].Value != null)
                    {
               
      
                        textBox1.Text = dgv2ndview.CurrentRow.Cells["rp_feed_type"].Value.ToString();
      
                    }

                }
            }
        }

        private void dgvImport_CurrentCellChanged(object sender, EventArgs e)
        {
            ready = true;
            showImportDataGrid2();
         
        }



        void showImportDataGrid2()
        {
            if (ready == true)
            {
                if (dgvImport.CurrentRow != null)
                {
                    if (dgvImport.CurrentRow.Cells["recipe_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvImport.CurrentRow.Cells["recipe_id"].Value);
                        txtItemCode.Text = dgvImport.CurrentRow.Cells["item_code"].Value.ToString();
                        txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
                        txtitemdescription.Text = dgvImport.CurrentRow.Cells["rp_description"].Value.ToString();

                    }
                }
            }
        }

        private void txtfeedCode_TextChanged(object sender, EventArgs e)
        {
       
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

        private void btnsum_Click(object sender, EventArgs e)
        {
            if(lblmacro.Text=="0")
            {

            }
            else
            {
                return;
            }
            if(lblmicro.Text=="0")
            {

            }
            else
            {
                return;
            }

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

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select item_id,item_code,item_description,total_quantity_raw,qty_repack_available,qty_repack,qty_production from [dbo].[rdf_raw_materials] WHERE item_code = '" + txtItemCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvMaster2.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
        }

        private void dgvMaster2_DpiChangedBeforeParent(object sender, EventArgs e)
        {

        }

        private void dgvMaster2_CurrentCellChanged(object sender, EventArgs e)
        {
            showRawMatsDataGrid();
        }




        void showRawMatsDataGrid()
        {
            if (ready == true)
            {
                if (dgvMaster2.CurrentRow != null)
                {
                    if (dgvMaster2.CurrentRow.Cells["item_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dgvMaster2.CurrentRow.Cells["item_id"].Value);
                        txtrepackavailable.Text = dgvMaster2.CurrentRow.Cells["qty_production"].Value.ToString();


                    }
                }
            }
        }

        private void btnlessthan3_Click(object sender, EventArgs e)
        {


            //if (dgvImport.Rows.Count >= 1)
            //{
            //    int i = dgvImport.CurrentRow.Index + 1;
            //    if (i >= -1 && i < dgvImport.Rows.Count)
            //        dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];
            //    else
            //    {
            //        //LastLine();
            //        //MessageBox.Show("Finish  Cancel"); Remove na 4/14/2020

            //        btngreaterthan_Click(sender, e);
            //        //bunifuThinButton26_Click(sender, e);
            //        return;
            //    }
            //}


            //double mainbalance;
            //double selectquantity;


            ////mainbalance = double.Parse(txtrepackavailable.Text);
            ////selectquantity = double.Parse(txtQuantity.Text);
            ////if (selectquantity < mainbalance)
            ////{
            ////    //NoBalanceNotify();
            //    //return;
            //    txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

            //    double rp1;
            //    double rp2;
            //    double rpavailables;

            //    rp1 = double.Parse(txtrepackavailable.Text);
            //    rp2 = double.Parse(txttotalQty.Text);

            //    rpavailables = rp1 + rp2;
            //    txtdeductions.Text = Convert.ToString(rpavailables);
            //    //WithBalanceNotify();
            //    QueryOutProduction();
            //    txtdeductions.Text = "";
            //    btnRollback_Click(sender, e);
            ////}
            ////else


            ////{
            ////    //txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

            ////    //double rp1;
            ////    //double rp2;
            ////    //double rpavailables;

            ////    //rp1 = double.Parse(txtrepackavailable.Text);
            ////    //rp2 = double.Parse(txttotalQty.Text);

            ////    //rpavailables = rp1 + rp2;
            ////    //txtdeductions.Text = Convert.ToString(rpavailables);
            ////    ////WithBalanceNotify();
            ////    //QueryOutProduction();
            ////    //txtdeductions.Text = "";
            ////    //btnRollback_Click(sender, e);
            ////    ////btnlessthan_Click(sender, e);
            ////    ////MessageBox.Show("1");

            ////}




            if (dgvImport.Rows.Count >= 1)
            {
                int i = dgvImport.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvImport.Rows.Count)
                    dgvImport.CurrentCell = dgvImport.Rows[i].Cells[0];
                else
                {

                    //MessageBox.Show("Finish  Cancel"); Remove na 4/14/2020

                    //MessageBox.Show("Tapos na");


                    SuccessFullyApprovedCancel();
                    ControlBox = true;


                    btngreaterthan_Click(sender, e);

                    ForApproval();
                    Approved();
                    frmFormulationApproval_Load(sender, e);
                    //bunifuThinButton26_Click(sender, e);
                    return;
                }
            }


            //double mainbalance;
            //double selectquantity;


            //mainbalance = double.Parse(txtrepackavailable.Text);
            //selectquantity = double.Parse(txtQuantity.Text);
            //if (mainbalance < selectquantity)
            //{
            //NoBalanceNotify();
            //return;

            //MessageBox.Show("Gerard2");
            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

                double rp1;
                double rp2;
                double rpavailables;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalQty.Text);

                rpavailables = rp1 + rp2;
                txtdeductions.Text = Convert.ToString(rpavailables);
                //WithBalanceNotify();
                QueryOutProduction();
                txtdeductions.Text = "";
                btnRollback_Click(sender, e);
           //MessageBox.Show("1");
            //}
            //else


            //{
            //    txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();

            //    double rp1;
            //    double rp2;
            //    double rpavailables;

            //    rp1 = double.Parse(txtrepackavailable.Text);
            //    rp2 = double.Parse(txttotalQty.Text);

            //    rpavailables = rp1 + rp2;
            //    txtdeductions.Text = Convert.ToString(rpavailables);
            //    //WithBalanceNotify();
            //    QueryOutProduction();
            //    txtdeductions.Text = "";
            //    btnRollback_Click(sender, e);
            //    //btnlessthan_Click(sender, e);
            //    //MessageBox.Show("1");

            //}


        }

        private void btnRollback_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Gerard1");
                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
                double rp1;
                double rp2;
                double rpavailable;

                rp1 = double.Parse(txtrepackavailable.Text);
                rp2 = double.Parse(txttotalQty.Text);

                rpavailable = rp1 + rp2;


                txtdeductions.Text = Convert.ToString(rpavailable);
                //WithBalanceNotify(); alis muna 4 / 13 / 2020
                QueryOutProduction();
                txtdeductions.Text = "";
                btnlessthan3_Click(sender, e);
           

           
        }



        void QueryOutProduction()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_raw_materials] SET qty_production='" + txtdeductions.Text + "'  WHERE item_code= '" + txtItemCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;
            //dgvMaster.Visible = true;
            ////dgv_table_2nd_sup.Visible = true;
            //lblmicroview.Visible = true;
            sql_con.Close();
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
                FirstLine();
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
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        private void txtid_TextChanged(object sender, EventArgs e)
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

        private void dgvApproved_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

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

            if (txtItemCode.Text.Trim() == string.Empty)
            {
                return;
            }


            if (txtnobatch.Text.Trim() == string.Empty)
            {

            }
            else
            {


                txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            }

        }
        void NoDataNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "No Data Found!";
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
        private void z(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }

        private void btnsubmitcancel_Click(object sender, EventArgs e)
        {
            if (txtreason.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();

                btnsubmitcancel.Visible = true;

                return;
            }

            metroButton2_Click(sender, e); ;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //timer1.Start();
       

            //if (lblcount.Text == "0")
            //{
            //    ForApproval();
            //}
            //else
            //{
            //    timer1.Stop();
            //    ForApproval();
            //    Approved();
            //    IsForCancel();
            //    IsForCancelnaApproved();
            //    load_Schedules_finish();
            //}
        }

        private void btnvalidateformualtion_Click(object sender, EventArgs e)
        {

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

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dgvApproved_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dgvUpdateTimeLampse_CurrentCellChanged(object sender, EventArgs e)
        {

            CellChangedViewer();
        }



        void CellChangedViewer()
        {

            if (dgvUpdateTimeLampse.RowCount > 0)
            {
                if (dgvUpdateTimeLampse.CurrentRow != null)
                {
                    if (dgvUpdateTimeLampse.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);

                       txtCreationDate.Text = dgvUpdateTimeLampse.CurrentRow.Cells["dateadded"].Value.ToString();

                    }

                }
            }




            DateTime time1 = DateTime.Parse(txtCreationDate.Text);
            DateTime time2 = DateTime.Parse(txtDateAndTime.Text);

            TimeSpan difference = time2 - time1;



            txtSumofProdAndApproval.Text = Convert.ToString(difference);













        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = dgvImport.CurrentRow.Cells["quantity2"].Value.ToString();
            txttotalQty.Text = (float.Parse(txtQuantity.Text) * float.Parse(txtnobatch.Text)).ToString();
            bunifuThinButton26.Visible = false;
            txtreason.Enabled = false;
            bunifuThinButton29.Visible = false;
            bunifuSubmit.Visible = false;
            btnsubmitcancel.Visible = false;
            txtreason.BackColor = Color.White;
            if (txtrepackcount.Visible == true)
            {
                bunifuThinButton26.Visible = false;
                bunifuThinButton28.Visible = false;
            }
            else
            {
                bunifuThinButton26.Visible = true;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            bunifuThinButton26.Visible = false;
            bunifuThinButton29.Visible = true;
            txtreason.Enabled = true;
            bunifuThinButton28.Visible = false;
            bunifuSubmit.Visible = true;
            txtreason.Focus();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            if (txtreason.Text.Trim() == string.Empty)
            {
                EmptyFieldNotify();

                btnsubmitcancel.Visible = true;

                return;
            }

            metroButton2_Click(sender, e); ;
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            DateTime time12 = DateTime.Parse(txtcurrentdate.Text);
            DateTime time22 = DateTime.Parse(mfg_datePicker2.Text);

            if (time12 > time22)
            {
                //MessageBox.Show("gastos");
                LesthanDateNotify();
                return;
            }
            else
            {

                //MessageBox.Show("Bastos");
                //return;
            }





            metroButton3_Click(sender, e);
        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            frmApproverViewRepackMaterials frm = new frmApproverViewRepackMaterials(cboFeedCode.Text,txtapprovecancel.Text,txtbags.Text,txtnobatch.Text,textBox1.Text, mfg_datePicker2.Text);


            frm.ShowDialog();
        }

        private void lblmacro_Click(object sender, EventArgs e)
        {

        }

        private void lblgrandtotal_Click(object sender, EventArgs e)
        {

        }

        private void lbltotalrepack_Click(object sender, EventArgs e)
        {

        }

        private void dgvApproved_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblmicro_Click(object sender, EventArgs e)
        {

        }

        private void btndowntime_Click(object sender, EventArgs e)
        {

       
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "INSERT [dbo].[rdf_recipe_to_production] (item_code, quantity, feed_code,repacking_status,production_id,is_active,rp_type,rp_feed_type,rp_description,rp_category,rp_group,total_qty,total_prod,proddate,final_qty,batch) SELECT item_code,quantity, feed_code, '1','10','1',rp_type,rp_feed_type,rp_description,rp_category,rp_group,'0','0','6/21/2021',CAST(quantity as float)*2 * '"+txtnobatch.Text+"','"+txtnobatch.Text+"' FROM rdf_recipe WHERE feed_code= 'FMP200AH' AND rp_category='MICRO'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv1stView.DataSource = dt;

            sql_con.Close();




            MessageBox.Show("New Data Inserted Into Database!");


            //end
        }
    }

}

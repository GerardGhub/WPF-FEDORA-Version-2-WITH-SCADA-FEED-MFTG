using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
    public partial class frmGenerateRepackingBarcodeID : Form
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
        DataSet dSet = new DataSet();
        IStoredProcedures objStorProc = null;
        public frmGenerateRepackingBarcodeID()
        {
            InitializeComponent();
        }

        private void frmGenerateRepackingBarcodeID_Load(object sender, EventArgs e)
        {
       
            if (myClass.g_objStoredProc.getConnected() == true)
            {
                g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

                dset = g_objStoredProcCollection.sp_IDGenerator(0, "SelectHR", "", "", 1);
                dset2 = g_objStoredProcCollection.sp_IDGenerator(1, "SelectCompany", "", "", 1);

                Rpt_Path = WFFDR.Properties.Settings.Default.fdg;

                //Rpt_Path = ini.IniReadValue("PATH", "Report_Path");
                dataView.Columns[0].Width = 135;// The id column
                dataView.Columns[1].Width = 150;// The id column
                xClass.ActivitiesLogs(userinfo.emp_name + " Generated " + myglobal.REPORT_NAME + " Report");
            }
            else
            {
                MessageBox.Show("Unable to connect in sql server", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            cmbHR_OIC.DataSource = dset.Tables[0].DefaultView;
            cmbHR_OIC.DisplayMember = dset.Tables[0].Columns[0].ToString();
            cmbHR_OIC.ValueMember = dset.Tables[0].Columns[1].ToString();

            int number_of_rows = dset2.Tables[0].Rows.Count - 1;
            

            txtfooter.Text = dset2.Tables[0].Rows[number_of_rows]["company_name"].ToString() + Environment.NewLine
                            + dset2.Tables[0].Rows[number_of_rows]["company_address_number"].ToString() + Environment.NewLine
                            + dset2.Tables[0].Rows[number_of_rows]["company_phone_number"].ToString();

            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchRepacking", "All", txtSearch.Text, 1);
            dataView.DataSource = dset.Tables[0];

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
                cmbHR_OIC.SelectedIndex = cmbHR_OIC.FindString("Rollsdsaidne Paldsdso");
            }
            catch (Exception) { }

            rbt_check();
            txtluffy.Text = dataView.RowCount.ToString();
            LessonNotify();
            mode = "company";




            objStorProc = xClass.g_objStoredProc.GetCollections();

            myglobal.global_module = "Active";
            load_search();
            //load_search();

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





        void load_search()
        {
                   
            dset_emp1.Clear();

            dset_emp1 = objStorProc.sp_getMajorTables("searchrepackreprint2");

            doSearch();


        }
        DataSet dset_emp1 = new DataSet();
        void doSearch()
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

                        dv.RowFilter = "uniquedate = '" + dateTimePicker12.Text + "' AND ProdID like'%" + txtprod_id.Text + "%' AND rp_feed_code like '%" + txtFeedCode.Text + "%' AND Emp_Number like '%" + txtItemCode.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
        dataView.DataSource = dv;
                    lblfound.Text = dataView.RowCount.ToString();

                    //gerard
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        void LessonNotify()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "DOUBLE CLICK THE DATAGRID FOR MODULE OPERATIONS";
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rbt_check();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            myglobal.Searchcategory = txtSearch.Text;
            myglobal.employee_name = cmbHR_OIC.Text;//cmbHR_OIC.Text;
            myglobal.position = cmbPos.Text;//cmbPos.Text;
            myglobal.validity = dt.Text;

            for (int i = 0; i <= dataView.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepacking", "", "", 0);
                }

            }

            if (mode == "company")
            {
                //myglobal.REPORT_NAME = "IDRepackReport";

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)

                {
                    //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
                    rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");


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
 
                    rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                }



            }
            else if (mode == "hw")
            {
                myglobal.REPORT_NAME = "IDReport(HW)";
            }
            frmReport frmReport = new frmReport();
            frmReport.ShowDialog();
        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsearchcode_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select repack_id as string_id,rp_item_code,rp_item_description,rp_mfg_date,rp_expiry_date,days_to_expired,total_repack,repack_by from [dbo].[rdf_repackin_entry] WHERE repack_id like '%" + txtsearchcode.Text + "%'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
          dataView.DataSource = dt;
            sql_con.Close();
        }

        private void bunifuThinButton218_Click(object sender, EventArgs e)
        {
            myglobal.Searchcategory = txtSearch.Text;
            myglobal.employee_name = cmbHR_OIC.Text;//cmbHR_OIC.Text;
            myglobal.position = cmbPos.Text;//cmbPos.Text;
            myglobal.validity = dt.Text;

            for (int i = 0; i <= dataView.RowCount - 1; i++)
            {
                try
                {
                    if(dataView.CurrentRow != null)
                    { 

                    if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value) == true)
                    {
                            this.dataView.CurrentCell = this.dataView.Rows[i].Cells[this.dataView.CurrentCell.ColumnIndex];
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepacking", "", "", 1);

                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount10", "", "", 10);
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount9", "", "", 9);

                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount8", "", "", 8);
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount7", "", "", 7);
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount6", "", "", 6);
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount5", "", "", 5);
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount4", "", "", 4);
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount3", "", "", 3);
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount2", "", "", 2);
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepackcount", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepacking", "", "", 1);

                    }
                    }
                }
                catch (Exception ex)
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepacking", "", "", 0);
                    MessageBox.Show(ex.Message);
                }

            }

            if (mode == "company")
            {
                myglobal.REPORT_NAME = "IDRepackReportreprint";

                //PrintDialog printDialog = new PrintDialog();
                //if (printDialog.ShowDialog() == DialogResult.)

                //{ IDRepackReport
                //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rpt.Load(Rpt_Path + "\\MainRepackingBarcodeMicroReprintmain.rpt");
                rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
      


                rpt.Refresh();

                    //crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";







                    crV1.ReportSource = rpt;
                    crV1.Refresh();



                    //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                    //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                //}



            }
            else if (mode == "hw")
            {
                myglobal.REPORT_NAME = "IDReport(HW)";
            }
            frmReport frmReport = new frmReport();
            frmReport.ShowDialog();

        
        }

        

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            myglobal.Searchcategory = txtSearch.Text;
            myglobal.employee_name = cmbHR_OIC.Text;//cmbHR_OIC.Text;
            myglobal.position = cmbPos.Text;//cmbPos.Text;
            myglobal.validity = dt.Text;

            for (int i = 0; i <= dataView.RowCount - 1; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepacking", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepacking", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["string_id"].Value.ToString()), "updaterepacking", "", "", 0);
                }

            }

            if (mode == "company")
            {
                myglobal.REPORT_NAME = "IDRepackReport";

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)

                {
                    //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");

                    rpt.Load(Rpt_Path + "\\MainRepackingBarcodeMicroReprint.rpt");
                    rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");

                    //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");
                    //////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                    rpt.Refresh();

                    //crV1.SelectionFormula = "{Command.rp_item_description} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_classification} like '*" + myglobal.Searchcategory + "*'or  {Command.rp_item_code} like '*" + myglobal.Searchcategory + "*' or  {Command.rp_mfg_date} like '*" + myglobal.Searchcategory + "*'  AND  {Command.rp_expiry_date} like '*" + myglobal.Filter + "*'";






                    //rpt.SetParameterValue("Approved", myglobal.rp_item_description);
                    //rpt.SetParameterValue("Validity", myglobal.validity);
                    //rpt.SetParameterValue("Position", myglobal.position);

                    //crV1.ReportSource = rpt;
                    //crV1.Refresh();



                    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                    rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                }



            }
            else if (mode == "hw")
            {
                myglobal.REPORT_NAME = "IDReport(HW)";
            }
            //frmReport frmReport = new frmReport();
            //frmReport.ShowDialog();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (dataView.RowCount > 0)
            //{
            //    if (dataView.CurrentRow != null)
            //    {
            //        if (dataView.CurrentRow.Cells["ID"].Value != null)
            //        {
            //            //p_id = Convert.ToInt32(dgvApproved.CurrentRow.Cells["prod_id"].Value);
        

            //cmbPos.Text = dataView.CurrentRow.Cells["Name"].Value.ToString();

            //            //txtdatenow.Text = dgvApproved.CurrentRow.Cells["added"].Value.ToString();
            //        }

            //    }
            //}
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Print the Barcode Repack Entry ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                bunifuThinButton218_Click(sender, e);
            }
            else
            {
                //bunifuThinButton21_Click(sender, e);
                return;
            }


            }

        private void dataView_DoubleClick(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void txtmare_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updatereprinting");

            frmGenerateRepackingBarcodeID_Load(sender, e);
        }

        private void txtprod_id_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void txtFeedCode_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void btngreaterthan_Click(object sender, EventArgs e)
        {

            txtprod_id.Visible = true;
            lblprod.Visible = true;
            txtFeedCode.Visible = true;
            lblfeedtype.Visible = true;
            label12.Visible = true;
            txtItemCode.Visible = true;
            txtprod_id.Focus();
         
        }
    }
}

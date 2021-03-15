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
    public partial class frmPrintBasemixedEntry : Form
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
        public frmPrintBasemixedEntry()
        {
            InitializeComponent();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmPrintBasemixedEntry_Load(object sender, EventArgs e)
        {
            if (myClass.g_objStoredProc.getConnected() == true)
            {
                g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections();

                dset = g_objStoredProcCollection.sp_IDGenerator(0, "SelectHR", "", "", 1);
                dset2 = g_objStoredProcCollection.sp_IDGenerator(1, "SelectCompany", "", "", 1);

                Rpt_Path = WFFDR.Properties.Settings.Default.fdg;

                //Rpt_Path = ini.IniReadValue("PATH", "Report_Path");
                dataView.Columns[0].Width = 135;// The id column
                dataView.Columns[1].Width = 165;// The id column
                dataView.Columns[5].Width = 175;// The id column
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

            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchBMX", "All", txtSearch.Text, 1);
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
                cmbHR_OIC.SelectedIndex = cmbHR_OIC.FindString("Rddd");
            }
            catch (Exception) { }

            rbt_check();
            txtluffy.Text = dataView.RowCount.ToString();
            LessonNotify();

            objStorProc = xClass.g_objStoredProc.GetCollections();

            myglobal.global_module = "Active";
            load_search();
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

            dset_emp1 = objStorProc.sp_getMajorTables("searchrepackbmx");

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

                        dv.RowFilter = "bmx_proddate = '" + dateTimePicker12.Text + "' AND prod_adv like '%"+txtprod_id.Text+ "%' AND PrintNo like '%"+txtprintno.Text+"%' ";

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
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatebmx", "", "", 1);
                    }
                    else
                    {
                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatebmx", "", "", 0);
                    }
                }
                catch
                {

                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatebmx", "", "", 0);
                }

            }

            if (mode == "company")
            {
                myglobal.REPORT_NAME = "IDBasedMixReportMainReprint2";

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)

                {
                    //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rpt.Load(Rpt_Path + "\\MainMicroBasemixedPrintingReprint.rpt");
                    rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");


                    //rpt.Load(Rpt_Path + "\\IDRepackReport.rpt");\IDBasedMixReportMainReprintReprint
                    //////////rpt.SetDatabaseLogon("sa", "Nescafe3in1");
                    rpt.Refresh();

                    //crV1.SelectionFormula = "{Command.bmx_proddate} like '*" + myglobal.Searchcategory + "*' or  {Command.bmx_batch_print} like '*" + myglobal.Searchcategory + "*'or  {Command.bmx_batch} like '*" + myglobal.Searchcategory + "*' or  {Command.actual_weight} like '*" + myglobal.Searchcategory + "*'  AND  {Command.bmx_id} like '*" + myglobal.Filter + "*'";






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
            //frmReport frmReport = new frmReport();
            //frmReport.ShowDialog();
        }

        private void bunifuThinButton218_Click(object sender, EventArgs e)
        {
           
        }

        private void dataView_DoubleClick(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Print Basemixed Barcoding Entry? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {



                myglobal.Searchcategory = txtSearch.Text;
                myglobal.employee_name = cmbHR_OIC.Text;//cmbHR_OIC.Text;
                myglobal.position = cmbPos.Text;//cmbPos.Text;
                myglobal.validity = dt.Text;

                //for (int i = 2; i <= dataView.RowCount - 1; i++)
                for (int i = 0; i <= dataView.RowCount - 1; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dataView.Rows[i].Cells["selected"].Value.ToString()) == true)
                        {
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatebmx", "", "", 1);



                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount10", "", "", 10);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount9", "", "", 9);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount8", "", "", 8);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount7", "", "", 7);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount6", "", "", 6);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount5", "", "", 5);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount4", "", "", 4);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount3", "", "", 3);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount2", "", "", 2);
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updaterepackbmxcount", "", "", 1);
                        }
                        else
                        {
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatebmx", "", "", 0);
                        }
                    }
                    catch
                    {

                        dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dataView.Rows[i].Cells["ID"].Value.ToString()), "updatebmx", "", "", 0);
                    }

                }

                if (mode == "company")
                {
                    //myglobal.REPORT_NAME = "BMXIDRepackReport";
                    myglobal.REPORT_NAME = "IDBasedMixReportMainReprint2";

                    //PrintDialog printDialog = new PrintDialog();
                    //if (printDialog.ShowDialog() == DialogResult.)

                    //{
                    //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    //rpt.Load(Rpt_Path + "\\BMXIDRepackReport.rpt");
                    rpt.Load(Rpt_Path + "\\MainMicroBasemixedPrintingReprint.rpt");
                    rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");


       
                    rpt.Refresh();

      






                    //rpt.SetParameterValue("Approved", myglobal.rp_item_description);
                    //rpt.SetParameterValue("Validity", myglobal.validity);
                    //rpt.SetParameterValue("Position", myglobal.position);

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
            else
            {
                return;
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            metroButton4_Click(sender, e);
        }

        private void dateTimePicker12_ValueChanged(object sender, EventArgs e)
        {
            doSearch();

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            dSet.Clear();

            dSet = objStorProc.rdf_sp_new_preparation(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "updatereprinting");

            frmPrintBasemixedEntry_Load(sender, e);
        }

        private void btngreaterthan_Click(object sender, EventArgs e)
        {
            lblprod.Visible = true;
            txtprod_id.Visible = true;

            txtprintno.Visible = true;
            lblprintno.Visible = true;
        }

        private void dataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void txtprod_id_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void txtprintno_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }
    }
}

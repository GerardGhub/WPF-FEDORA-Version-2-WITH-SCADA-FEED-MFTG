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

namespace WFFDR
{
    public partial class frmScadaMonitoringPerProdPlan : Form
    {

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();
        myclasses xClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;
        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();
        string mode;
        string Rpt_Path = "";
        IStoredProcedures objStorProc = null;
        int temp_hid = 0;
        int p_id = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        Boolean ready = false;
        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        public frmScadaMonitoringPerProdPlan()
        {
            InitializeComponent();
        }

        private void frmScadaMonitoringPerProdPlan_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            ProductionPlan();
            myglobal.global_module = "PRODPLAN";
        }

        public void ProductionPlan()
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



            dset = g_objStoredProcCollection.sp_IDGenerator(1, "SearchforPlanningActive", "All", txtSearch.Text, 1);
            dataView.DataSource = dset.Tables[0];
            lblcount.Text = dataView.RowCount.ToString();

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

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            load_search();
            doSearch();
            dataShow();
        }

        DataSet dset_emp = new DataSet();
        public void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "PRODPLAN")
            { dset_emp = objStorProc.sp_getMajorTables("search_planning"); }
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
                        //dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }

                    else if (myglobal.global_module == "PRODPLAN")
                    {
                        dv.RowFilter = "Position >= #" + dtp1.Text + "# AND Position <= #" + dtp2.Text + "# ";
                    }

                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                   dataView.DataSource = dv;
                    lblcount.Text = dataView.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtp1.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtp1.Focus();
                return;
            }

        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            load_search();
            doSearch();
            dataShow();
        }

        void dataShow()
        {
            try
            {



                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

                //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
                SqlConnection sql_con = new SqlConnection(connetionString);


                string sqlquery = "SELECT emp.item_id,emp.item_code,emp.item_description,emp.Category,emp.item_group,ISNULL(t2.SCADA,0) as SCADA,ISNULL(t5.SCADAFORMULATION,0) as SCADAFORMULATION,t2.SCADA - t5.SCADAFORMULATION as DIFFERENCE,(t2.SCADA - t5.SCADAFORMULATION) / (ISNULL(t2.SCADA,0)) * 100 as PERCENTAGE FROM rdf_raw_materials emp LEFT JOIN ( select BC.theo_item_code, sum( BC.actual_qty ) as SCADA  from theo_logs_tbl BC where CAST(Prod_Date as date) BETWEEN '" + dtp1.Text + "' and '" + dtp2.Text + "' AND theo_prod_id= '"+txtProdId.Text+"' group by BC.theo_item_code ) t2 on emp.item_code = t2.theo_item_code LEFT JOIN(select BC.theo_item_code, sum(BC.mat_sp ) as SCADAFORMULATION  from theo_logs_tbl BC where CAST(Prod_Date as date) BETWEEN '" + dtp1.Text + "' and '" + dtp2.Text + "' AND theo_prod_id= '" + txtProdId.Text + "' group by BC.theo_item_code ) t5 on emp.item_code = t5.theo_item_code WHERE emp.is_active = 1 AND emp.Category='MACRO' and not emp.item_group='Validate' AND not SCADA='0' ORDER BY emp.item_group";


                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvApproved.DataSource = dt;
                lblrecords.Text = dgvApproved.RowCount.ToString();



                sql_con.Close();

                //GrandTotal();


                decimal toty = 0;

                for (int i = 0; i < dgvApproved.RowCount - 0; i++)
                {
                    var value = dgvApproved.Rows[i].Cells["SCADA"].Value;
                    if (value != DBNull.Value)
                    {
                        toty += Convert.ToDecimal(value);
                    }
                }
                if (toty == 0)
                {

                }



                lblscadacount.Text = toty.ToString("##.00");




                decimal tot = 0;

                for (int i1 = 0; i1 < dgvApproved.RowCount - 0; i1++)
                {
                    var values = dgvApproved.Rows[i1].Cells["SCADAFORMULATION"].Value;
                    if (values != DBNull.Value)
                    {
                        tot += Convert.ToDecimal(values);
                    }
                }
                if (tot == 0)
                {

                }



                lblformulationcount.Text = tot.ToString("##.00");



                lbldifference.Text = (float.Parse(lblscadacount.Text) - float.Parse(lblformulationcount.Text)).ToString("#,0.00");//



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

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

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["Position"].Value != null)
                    {

                        txtProdPlan.Text = dataView.CurrentRow.Cells["Position"].Value.ToString();
                        txtProdId.Text = dataView.CurrentRow.Cells["ID"].Value.ToString();
                    }

                }
            }
        }

        private void txtProdId_TextChanged(object sender, EventArgs e)
        {
            dataShow();
        }
    }
}

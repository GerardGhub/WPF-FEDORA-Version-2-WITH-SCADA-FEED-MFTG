using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFDR
{
    public partial class FgDashboardMonitoring : Form
    {
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        myclasses xClass = new myclasses();
        public FgDashboardMonitoring()
        {
            InitializeComponent();
        }

        private void FgDashboardMonitoring_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            myglobal.global_module = "Active";
            load_FGmonitoring();
            load_search();

            dateTimePicker12_ValueChanged(sender, e);
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
        public void load_FGmonitoring()
        {
            string mcolumns = "test,prod_id,p_feed_code,feed_type,bags_int,batch_int,proddate,bagorbin,series_num";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "FGmonitoring");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
            //lblallmaterials.Text = dgv_po_approve.RowCount.ToString();
            //poreceived_header();
        }

        void load_search()
        {

            dset_emp1.Clear();

            dset_emp1 = objStorProc.sp_getMajorTables("FGmonitoring");

            doSearch();


            dset_emp2 = objStorProc.sp_getMajorTables("FGReproccess");

            doSearch2();

            dset_emp3 = objStorProc.sp_getMajorTables("FGReproccessDone");

            doSearch3();

            dset_emp4 = objStorProc.sp_getMajorTables("FGGood");

            doSearch4();


            dset_emp5 = objStorProc.sp_getMajorTables("FGRejected");

            doSearch5();


            dset_emp6 = objStorProc.sp_getMajorTables("FGBaggingTotal");

            doSearch6();

            dset_emp7 = objStorProc.sp_getMajorTables("FGBulkTotal");

            doSearch7();


            dset_emp8 = objStorProc.sp_getMajorTables("FGbolang");

            doSearch8();


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

                        dv.RowFilter = "proddate = '" + dateTimePicker12.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView.DataSource = dv;
                    txtluffy.Text = dataView.RowCount.ToString();

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




        DataSet dset_emp2 = new DataSet();
        void doSearch2()
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

                        dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv = '"+txtproductionid.Text+"'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView2.DataSource = dv;
                    txtreprocess.Text = dataView2.RowCount.ToString();

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







        DataSet dset_emp3 = new DataSet();
        void doSearch3()
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

                        dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv = '" + txtproductionid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView3.DataSource = dv;
                    txtreprocessdone.Text = dataView3.RowCount.ToString();

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


        DataSet dset_emp4 = new DataSet();
        void doSearch4()
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

                        dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv = '" + txtproductionid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView4.DataSource = dv;
                    lblgood.Text = dataView4.RowCount.ToString();

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



        DataSet dset_emp5 = new DataSet();
        void doSearch5()
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

                        dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv = '" + txtproductionid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView5.DataSource = dv;
                    lblreject.Text = dataView5.RowCount.ToString();

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




        DataSet dset_emp6 = new DataSet();
        void doSearch6()
        {
            try
            {
                if (dset_emp6.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp6.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv = '" + txtproductionid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView6.DataSource = dv;
                    lbltotal.Text = dataView6.RowCount.ToString();

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





        DataSet dset_emp7 = new DataSet();
        void doSearch7()
        {
            try
            {
                if (dset_emp7.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp7.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv = '" + txtproductionid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView7.DataSource = dv;
                    lbltotalbulk.Text = dataView7.RowCount.ToString();

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





            double sum = 0;
            for (int i = 0; i < dataView7.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataView7.Rows[i].Cells[21].Value);
            }
           lblbulkgrandtotal.Text = sum.ToString();

            if(lblbulkgrandtotal.Text.Trim()== string.Empty)
            {

            }
            else
            {

             lblgood.Text = (float.Parse(lblgood.Text) + float.Parse(lblbulkgrandtotal.Text)).ToString();

            }

        }








        DataSet dset_emp8 = new DataSet();
        void doSearch8()
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

                        dv.RowFilter = "production_id = '"+txtproductionid.Text+"'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView8.DataSource = dv;
                    lblActiveProduction.Text = dataView8.RowCount.ToString();

                    if(lblActiveProduction.Text =="0")
                    {
                        lblstats.Text = "DONE";
                    }
                    else
                    {
             
                        lblstats.Text = "ALREADY PROCESS";
                    }
                    //lbltotalbulk.Text = dataView7.RowCount.ToString();
       
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
                MessageBox.Show("Invalid character found 234.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btngreaterthan_Click(object sender, EventArgs e)
        {
            txtprod_id.Visible = true;
            lblprod.Visible = true;
            txtFeedCode.Visible = true;
            lblfeedtype.Visible = true;

            txtprod_id.Focus();
        }

        private void dateTimePicker12_ValueChanged(object sender, EventArgs e)
        {
            doSearch();
            doSearch2();
            doSearch3();
            doSearch4();
            doSearch5();
            doSearch7();
            doSearch6();
            doSearch8();
            txtproductionid.Visible = true;
            lblprod.Visible = true;
            dataView.Visible = true;
            panel1.Visible = true;
            lblstats.Visible = true;
            groupBox1.Visible = true;
                label5.Visible = true;
                txtluffy.Visible = true;
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dataView.RowCount > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["p_feed_code"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                  txtproductionid.Text = dataView.CurrentRow.Cells["prod_id"].Value.ToString();


                    }

                }
            }



            doSearch2();
            doSearch3();
            doSearch4();
            doSearch5();
            doSearch8();
            doSearch6();
            doSearch7();
        }
    }
}

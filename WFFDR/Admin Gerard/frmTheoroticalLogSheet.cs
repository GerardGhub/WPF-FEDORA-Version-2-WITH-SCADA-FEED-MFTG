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
    public partial class frmTheoroticalLogSheet : Form
    {
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        myclasses xClass = new myclasses();
        public frmTheoroticalLogSheet()
        {
            InitializeComponent();
        }

        private void frmTheoroticalLogSheet_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            myglobal.global_module = "Active";
            load_FGmonitoring();
            load_search();
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


            dset_emp8 = objStorProc.sp_getMajorTables("ShowPendingTheorotical");

            doSearch();

            dset_emp2 = objStorProc.sp_getMajorTables("ShowFormulatationTheorotical1and2");

            doSearch2();

            dset_emp80 = objStorProc.sp_getMajorTables("FGbolang");

            doSearch80();

        }



        DataSet dset_emp8 = new DataSet();
        void doSearch()
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

                        dv.RowFilter = "prod_id = '" + txtproductionid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataViewDetails.DataSource = dv;
                    lbltotalTheo.Text = dataViewDetails.RowCount.ToString();
                    //txtluffy.Text = dataView.RowCount.ToString();

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


        DataSet dset_emp80 = new DataSet();
        void doSearch80()
        {
            try
            {
                if (dset_emp80.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp80.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "production_id = '" + txtproductionid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataView80.DataSource = dv;
                    lblActiveProduction.Text = dataView80.RowCount.ToString();

                    if (lblActiveProduction.Text == "0")
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





        DataSet dset_emp2= new DataSet();
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

                        dv.RowFilter = "feed_code = '" + txtFeedCode.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                dgvFormulation.DataSource = dv;
                    lblmyfeedcodecount.Text = dgvFormulation.RowCount.ToString();
                    //txtluffy.Text = dataView.RowCount.ToString();

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



        private void dateTimePicker12_ValueChanged(object sender, EventArgs e)
        {
            dataView.Visible = true;
            txtproductionid.Visible = true;
            lblprod.Visible = true;
            lbltotalTheo.Visible = true;
            label1.Visible = true;
            doSearch();
            doSearch2();
            lblstats.Visible = true;
            doSearch80();
            lblmyfeedcodecount.Visible = true;
            dataViewDetails.Visible = true;
            label2.Visible = true;
            txtluffy.Visible = true;
            label5.Visible = true;
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

                        txtFeedCode.Text = dataView.CurrentRow.Cells["P_feed_code"].Value.ToString();
                    }

                }
            }
            doSearch();
            doSearch2();
            doSearch80();
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

        private void dataViewDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
    }
}

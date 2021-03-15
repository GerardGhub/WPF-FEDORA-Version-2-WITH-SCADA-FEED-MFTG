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
    public partial class frmFGMainInventory : Form
    {

        myclasses myClass = new myclasses();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_rights = new DataSet();
        DataSet dSet = new DataSet();
  


        Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        int rights_id = 0;

        public frmFGMainInventory()
        {
            InitializeComponent();
        }

        private void frmFGMainInventory_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROCEDURE
            objStorProc = xClass.g_objStoredProc.GetCollections();
            rights_id = userinfo.user_rights_id;
            dset_rights.Clear();
            load_fg_inventory();
            GrandTotal();
            myglobal.global_module = "FGINVENTORY";
            //load_search();
        }
        DataSet dset_emp = new DataSet();
        public void load_search()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "FGINVENTORY")
            { dset_emp = objStorProc.sp_getMajorTables("fg_inventory"); }
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
                        dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "MICRO")
                    {

                        dv.RowFilter = "item_description like '%" + txtsearchs.Text + "%' or item_code like '%" + txtsearchs.Text + "%'";
                    }
                    else if (myglobal.global_module == "HOME")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "item_description like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "FGINVENTORY")
                    {
                        //  dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%' or item_description like '%" + txtsearch.Text + "%'";
                        //dv.RowFilter = "item_id like '%" + txtsearch.Text + "%' or item_code like '%" + txtsearch.Text + "%'";
                        dv.RowFilter = "FeedCode like '%" + txtsearchs.Text + "%' or FeedType like '%" + txtsearchs.Text + "%'";
                    }
                    else if (myglobal.global_module == "RESIGNED EMPLOYEE")
                    {
                        dv.RowFilter = "firstname like '%" + txtsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "PHONEBOOK")
                    {
                        dv.RowFilter = "company_name like '%" + txtsearch.Text + "%' or contact_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "DA")
                    {
                        dv.RowFilter = "employee_name like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or da_number like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "ATTENDANCE")
                    {
                        dv.RowFilter = "lastname like '%" + txtsearch.Text + "%' or firstname like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_table.DataSource = dv;
                    lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearch.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsearch.Focus();
                return;
            }

        }

        void GrandTotal()
        {

            //for (int n = 0; n < (dgv_table.Rows.Count); n++)
            //{
            //    //9

            //    double s1 = Convert.ToDouble(dgv_table.Rows[n].Cells[2].Value);

            //    double s2 = Convert.ToDouble(dgv_table.Rows[n].Cells[3].Value);


            //    double s4 = Convert.ToDouble(dgv_table.Rows[n].Cells[4].Value);
            //    double s5 = Convert.ToDouble(dgv_table.Rows[n].Cells[5].Value);




            //    double grandtotal = s1 + s2;

            //    double onhand = s4 - s5;

            //    //dgv_table.Rows[n].Cells[4].Value = grandtotal.ToString();
            //    dgv_table.Rows[n].Cells[6].Value = onhand.ToString();

            //}

        }


        public void load_fg_inventory()
        {
            string mcolumns = "test,FeedCode,FeedType,BagsCount,BulkCount,GrandTotal,MoveOrder,RECEIVED,INVENTORY,BAG_RECEIPT,BULK_RECEIPT,BAG_ISSUE,BULK_ISSUE,RECEIPT,ISSUE";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "fg_inventory");
            lblrecords.Text = dgv_table.RowCount.ToString();
            lbltotalrecords.Text = dgv_table.RowCount.ToString();
        lblgrandtotal.Text = dgv_table.RowCount.ToString();
      
        }

        private void dgv_table_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("bulkentry_total"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }


            //if (e.ColumnIndex > 0)
            //{
            //    if (dgv_table.Columns[e.ColumnIndex].Name.ToLower().Contains("BulkCount"))
            //    {
            //        if (e.Value.ToString() != "")
            //        {
            //            double d = double.Parse(e.Value.ToString());
            //            e.Value = d.ToString("n0");
            //        }
            //    }
            //}








        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            bunifuSearch.Visible = true;
            txtsearchs.Visible = true;
            label7.Visible = true;
            txtsearchs.BringToFront();
            txtsearchs.Focus();

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {


            if (panel1.Visible == true)
            {

                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;

            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dtpprod1.Text;
            myglobal.DATE_REPORT2 = dtpprod2.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGInventory";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {

            if(panel6.Visible==true)
            {
                dgv_table.Enabled = false;
            }
            else
            {
                dgv_table.Enabled = true;
            }


            if (dgv_table.RowCount > 0)
            {
                if (dgv_table.CurrentRow != null)
                {
                    if (dgv_table.CurrentRow.Cells["FeedCode"].Value != null)
                    {

                        lblmyfeedcode.Text = dgv_table.CurrentRow.Cells["FeedCode"].Value.ToString();
                        lblfcode.Text = dgv_table.CurrentRow.Cells["FeedCode"].Value.ToString();

                    }
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {




            if (panel2.Visible == true)
            {

                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;

            }
        }

        private void btnFeedCodeSearch_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = f1.Text;
            myglobal.DATE_REPORT2 = f2.Text;
            myglobal.DATE_REPORT3 = lblmyfeedcode.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGInventorySearchFeedCode";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void dgv_table_DoubleClick(object sender, EventArgs e)
        {

            panel6.Visible = true;
            panel6.BringToFront();

        }

        private void btnmyProddate_Click(object sender, EventArgs e)
        {

            frmFgReporting shower = new frmFgReporting(dtpprod1.Text,dtpprod2.Text);
            shower.Show();



        }

        private void btnFeedCode_Click(object sender, EventArgs e)
        {
            dgv_table.Enabled = false;
            frmFgReportPerFeedCode shower = new frmFgReportPerFeedCode(lblfcode.Text,this);
            shower.Show();


            //if (panel2.Visible == true)
            //{

            //    panel2.Visible = false;
            //}
            //else
            //{
            //    panel2.Visible = true;
            //    panel1.Visible = false;
            //    panel6.Visible = false;

            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Execute the transaction at Crystal Report Viewer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{

                myglobal.DATE_REPORT3 = lblmyfeedcode.Text;
                //myglobal.REPORT_NAME = "DailyProductionSchedule";
                myglobal.REPORT_NAME = "FGInventorySearchFeedCodeOverAll";



                frmReport fr = new frmReport();

                fr.WindowState = FormWindowState.Maximized;
                fr.Show();

            //}
            //else
            //{

                panel6.Visible = false;
            //}
        }

        private void btnWindowsView_Click(object sender, EventArgs e)
        {


            frmFeedCodeTransactions feedcodes = new frmFeedCodeTransactions(lblmyfeedcode.Text);
            //feedcodes.MdiParent = this;
            feedcodes.ShowDialog();


            //if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Execute the transaction at Windows Application ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    MessageBox.Show("ang cute");

            //}
            //else
            //{

            //    panel6.Visible = false;
            //}
        }

        private void txtsearchs_TextChanged(object sender, EventArgs e)
        {
            load_search();
            doSearch();
            GrandTotal();
        }

        private void dgv_table_Click(object sender, EventArgs e)
        {

            if (panel6.Visible == true)
            {
                dgv_table.Enabled = false;
            }
            else
            {
                dgv_table.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            dgv_table.Enabled = true;
            panel6.Visible = false;


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            dgv_table.Enabled = true;
            textBox40.Text = "";
            frmFGMainInventory_Load(sender, e);
        }
    }
}
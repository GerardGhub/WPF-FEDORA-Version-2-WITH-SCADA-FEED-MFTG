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
    public partial class frmFeedCodeTransactions : Form
    {
        myglobal pointer_module = new myglobal();
        myclasses myClass = new myclasses();
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dsetHeader = new DataSet();
        DataSet dSet = new DataSet();
        DataSet dSet_temp = new DataSet();
        public frmFeedCodeTransactions(string feedCode)
        {
            InitializeComponent();
            this.FeedCode = feedCode;

        }
        public string FeedCode { get; set; }

        private void frmFeedCodeTransactions_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            txtFeedCode.Text = FeedCode;
            // SearchQuery();
            
            load_feedcodetransaction();
            myglobal.global_module = "feedcodetransaction";
            load_search3();
            load_fg_inventory();
            // Searchfeedcode();


        }



        public void load_fg_inventory()
        {
            string mcolumns = "test,Feed_Code,FeedType,BAGS_COUNT,BULK_COUNT,TOTAL_COUNT,BAG_RECEIPT,BULK_RECEIPT,TOTAL_RECEIPT,BAG_ISSUE,BULK_ISSUE,TOTAL_ISSUE,BAG_MOVEORDER,BULK_MOVEORDER,TOTAL_MOVEORDER,GRAND_TOTAL,TotalIssueMoveorder,TOTAL_INVENTORY,BAG_INVENTORY,BULK_INVENTORY";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "feedcodeqty");

            try
            {
                dSet_temp = objStorProc.sp_getMajorTables("feedcodeqty");



                DataView dt = new DataView(dSet_temp.Tables[0]);
                    dt.RowFilter = "Feed_Code like '%" + txtFeedCode.Text + "%'";
                dgv_table.DataSource = dt;

                lblqty.Text = dgv_table.CurrentRow.Cells["TOTAL_INVENTORY"].Value.ToString();

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

            public void load_feedcodetransaction()
        {
            string mcolumns = "test,prod_adv,fg_feed_code,fg_feed_type,fg_options,Quantity,Noformatdate,FGDate,transaction_date,added_by,transaction_type";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_feedcode, mcolumns, "feedcodetransaction");
            dgv_feedcode.Columns["Noformatdate"].Visible = false;
            dgv_feedcode.Columns["prod_adv"].Visible = false;
            dgv_feedcode.Columns["added_by"].Visible = false;
          
            

        }

      

        private void dgv_feedcode_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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


        public void load_search3()
        {
            dSet_temp.Clear();


            if (myglobal.global_module == "EMPLOYEE")
            { dSet_temp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dSet_temp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "feedcodetransaction")
            { dSet_temp = objStorProc.sp_getMajorTables("feedcodetransaction"); }
            else if (myglobal.global_module == "fg_inventory_bag")
            { dSet_temp = objStorProc.sp_getMajorTables("Callprodid"); }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            { dSet_temp = objStorProc.sp_getMajorTables("employee_B"); }
            else if (myglobal.global_module == "PHONEBOOK")
            { dSet_temp = objStorProc.sp_getMajorTables("phonebook"); }
            else if (myglobal.global_module == "DA")
            { dSet_temp = objStorProc.sp_getMajorTables("get_da"); }
            else if (myglobal.global_module == "ATTENDANCE")
            { dSet_temp = objStorProc.sp_getMajorTables("attendance_monitoring"); }
            else if (myglobal.global_module == "VISITORS")
            { dSet_temp = objStorProc.sp_getMajorTables("visitors"); }


            doSearch3();

        }
        void doSearch3()
        {

            try
            {
                if (dSet_temp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dSet_temp.Tables[0]);
                    dv.Sort = "transaction_type,transaction_date,fg_options ASC";


                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "MICRO")
                    {

                    }

                    else if (myglobal.global_module == "feedcodetransaction")
                    {


                        dv.RowFilter = "fg_feed_code like '%" + txtFeedCode.Text + "%'";
                        dgv_feedcode.DataSource = dv;
                      //  dgv_feedcode.Sort(dgv_feedcode.Columns["transaction_date"], ListSortDirection.Ascending);



                    }




                    lblrecords.Text = dgv_feedcode.RowCount.ToString();
                    //   prodtotal.Text = dgvprodd.RowCount.ToString();

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
    }
}

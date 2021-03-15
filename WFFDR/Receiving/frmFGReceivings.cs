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
    public partial class frmFGReceivings : Form
    {

        myclasses myClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_rights = new DataSet();
        DataSet dSet = new DataSet();
        //int p_id = 0;
        ////int temp_hid = 0;
        //string mode = "";
        //int emp_flag = 0;
        Boolean ready = false;
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        int rights_id = 0;

        public frmFGReceivings()
        {
            InitializeComponent();
        }

        private void frmFGReceivings_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            rights_id = userinfo.user_rights_id;
            txtProductionDate.Enabled = true;
            myglobal.global_module = "Active";
            load_fg_inventory();
            GrandTotal();
            UseWaitCursor = false;
            textBox1.Text = "";
            btnReceived.Visible = true;
            dgv_table.Enabled = true;
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

        public void load_fg_inventory()
        {
            string mcolumns = "test,ProdID,ProdDate,PrintingDate,FeedCode,FeedType,BagsCount,BulkCount,GrandTotal,MoveOrder,ACTUAL,AGING";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "fg_receiving2");
            lblrecords.Text = dgv_table.RowCount.ToString();

            //micro_materials_header();
        }


        void GrandTotal()
        {

            for (int n = 0; n < (dgv_table.Rows.Count); n++)
            {
                //9

                double s1 = Convert.ToDouble(dgv_table.Rows[n].Cells[5].Value);

                double s2 = Convert.ToDouble(dgv_table.Rows[n].Cells[6].Value);


                double s4 = Convert.ToDouble(dgv_table.Rows[n].Cells[7].Value);
                double s5 = Convert.ToDouble(dgv_table.Rows[n].Cells[8].Value);




                double grandtotal = s1 + s2;

                double onhand = s4 - s5;

                //dgv_table.Rows[n].Cells[4].Value = grandtotal.ToString();
                dgv_table.Rows[n].Cells[9].Value = onhand.ToString();

            }

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

        private void btnReceived_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Received an Finished Goods? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //UseWaitCursor = true;
                txtProductionDate.Enabled = false;
                btnReceived.Visible = false;
                dgv_table.Enabled = false;
                frmFGView shower = new frmFGView(this, lblprodid.Text, txtPrintingDate.Text);
                shower.Show();
             
            }
            else
            {
                return;
            }
      
        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgv_table.CurrentRow != null)
            {
                if (dgv_table.CurrentRow.Cells["ProdID"].Value != null)
                {
       lblprodid.Text = dgv_table.CurrentRow.Cells["ProdID"].Value.ToString();

               txtPrintingDate.Text = dgv_table.CurrentRow.Cells["PrintingDate"].Value.ToString();
                    txtProdPlan.Text = dgv_table.CurrentRow.Cells["ProdDate"].Value.ToString();

                }
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            frmFGReceivings_Load(sender, e);
        }

        private void txtFeedCode_TextChanged(object sender, EventArgs e)
        {
            if (txtProdID.Text.Trim() == string.Empty)
            {

            }
            else
            {
                load_search();
                doSearch();
       
            }
        }


        void load_search()
        {

            dset_emp1.Clear();

            dset_emp1 = objStorProc.sp_getMajorTables("fg_receiving");

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

            

                        dv.RowFilter = "PrintingDate >= #" +txtProductionDate.Text+ "# AND PrintingDate <= #" +dtpTo.Text+ "# AND FeedCode like '%" + txtFeedCode.Text + "%'";

                        //dv.RowFilter = "fg_proddate = '" + dateTimePicker12.Text + "' AND prod_adv like '%" + txtprod_id.Text + "%'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_table.DataSource = dv;
                    lblrecords.Text = dgv_table.RowCount.ToString();

                    //gerard
                }
                GrandTotal();

            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2 Gerard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //}
        }

        private void txtProductionDate_TextChanged(object sender, EventArgs e)
        {
            load_search();
            doSearch();
        }

        private void txtProductionDate_ValueChanged(object sender, EventArgs e)
        {
            load_search();
            doSearch();


        }

        private void txtFeedCode_TextChanged_1(object sender, EventArgs e)
        {
            load_search();
            doSearch();

        }
    }
}

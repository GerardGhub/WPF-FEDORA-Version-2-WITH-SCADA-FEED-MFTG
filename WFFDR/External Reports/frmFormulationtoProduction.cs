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
    public partial class frmFormulationtoProduction : Form
    {
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        myclasses xClass = new myclasses();
        public frmFormulationtoProduction()
        {
            InitializeComponent();
        }

        private void frmFormulationtoProduction_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            myglobal.global_module = "Active";
            load_Formulation();
            load_search();
        }

        public void load_Formulation()
        {
            string mcolumns = "test,emp.recipe_id,production_id,proddate,feed_code,rp_feed_type,item_code,rp_description,rp_category,rp_group,quantity,repacking_status,time_stamp_per_process,repacking_by";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "FormulationtoProduction");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
            //lblallmaterials.Text = dgv_po_approve.RowCount.ToString();
            //poreceived_header();
        }

        private void dataView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
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


        void load_search()
        {

            dset_emp1.Clear();

            dset_emp1 = objStorProc.sp_getMajorTables("FormulationtoProduction");

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

                        dv.RowFilter = "proddate = '" + dateTimePicker12.Text + "' AND production_id like'%" + txtprod_id.Text + "%' AND feed_code like '%" + txtFeedCode.Text + "%' AND item_code like '%" + txtItemCode.Text + "%'";

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

        private void dateTimePicker12_ValueChanged(object sender, EventArgs e)
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

        private void txtFeedCode_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void txtprod_id_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }
    }
}

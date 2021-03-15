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
    public partial class frmFormulationList : Form
    {
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();


        myclasses xClass = new myclasses();

        public frmFormulationList()
        {
            InitializeComponent();
        }

        private void frmFormulationList_Load(object sender, EventArgs e)
        {
            load_formulation();



            objStorProc = xClass.g_objStoredProc.GetCollections();

            myglobal.global_module = "Active";

        }

        void load_search()
        {

            dset_emp.Clear();

            dset_emp = objStorProc.sp_getMajorTables("searchFeedCode");

            doSearch();


        }
        DataSet dset_emp = new DataSet();
        void doSearch()
        {
            try
            {
                if (dset_emp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "feed_code like '%" + txtfeedcodes.Text + "%' ";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_po_approve.DataSource = dv;
                   lblfound.Text = dgv_po_approve.RowCount.ToString();
                    
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



        public void load_formulation()
        {
            string mcolumns = "test,feed_code,rp_feed_type,rp_type,rp_description,rp_category,rp_group,quantity";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_po_approve, mcolumns, "formulationlistahan");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
            lblallmaterials.Text = dgv_po_approve.RowCount.ToString();
            //poreceived_header();
        }

        private void dgv_po_approve_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void txtfeedcodes_TextChanged(object sender, EventArgs e)
        {
            load_search();
            if(txtfeedcodes.Text.Trim() == string.Empty)
            {
                load_formulation();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

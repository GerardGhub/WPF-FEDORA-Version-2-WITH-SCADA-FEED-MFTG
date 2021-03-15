using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WFFDR
{
    public partial class frmApproveQA : Form
    {
        IStoredProcedures objStorProc = null;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();


        myclasses xClass = new myclasses();
        public frmApproveQA()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnone_Click(object sender, EventArgs e)
        {
            SendKeys.Send("1");
        }

        private void frmvirtualkeyboard_Load(object sender, EventArgs e)
        {
            load_posummary_report();


            dateTimePicker1.Visible = false;
            objStorProc = xClass.g_objStoredProc.GetCollections();
            bunifuSearch_Click(sender, e);
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
        public void load_posummary_report()
        {
            string mcolumns = "test,po_number,item_code,item_description,qty_ordered,goodmaterial,stacking_level,qty_total_delivered";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_po_approve, mcolumns, "qa_po_receiving");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
            lblallmaterials.Text = dgv_po_approve.RowCount.ToString();
            //poreceived_header();
        }


        void poreceived_header()
        {
            dgv_po_approve.Columns[0].HeaderText = "ID";
            dgv_po_approve.Columns[1].HeaderText = "Received";
            dgv_po_approve.Columns[2].HeaderText = "Supplier";
            dgv_po_approve.Columns[3].HeaderText = "Category";
            dgv_po_approve.Columns[4].HeaderText = "Categorys";
            dgv_po_approve.Columns[5].HeaderText = "sample";
            dgv_po_approve.Columns[6].HeaderText = "Funty";


        }



        void load_search()
        {

            dset_emp.Clear();

            dset_emp = objStorProc.sp_getMajorTables("qa_po_receiving");

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

                        dv.RowFilter = "item_description ='" + txtmainsearch.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dgv_po_approve.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();gerard
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

        private void txtmainsearch_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            load_search();
            doSearch();

            if (txtmainsearch.Text.Trim() == string.Empty)
            {

                timer1.Start();
                timer1_Tick(sender, e);
            }

        }

        private void bunifuSearch_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
            load_posummary_report();
            label1.Visible = true;

            lblallmaterials.Visible = true;
            dgv_po_approve.Visible = true;
    
        }

        private void dgv_po_approve_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dgv_po_approve.Columns[e.ColumnIndex].Name.ToLower().Contains("goodmaterial"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }
            if (e.ColumnIndex > 0)
            {
                if (dgv_po_approve.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_ordered"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }
            if (e.ColumnIndex > 0)
            {
                if (dgv_po_approve.Columns[e.ColumnIndex].Name.ToLower().Contains("stacking_level"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }
            if (e.ColumnIndex > 0)
            {
                if (dgv_po_approve.Columns[e.ColumnIndex].Name.ToLower().Contains("qty_total_delivered"))
                {
                    if (e.Value.ToString() != "")
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("n0");
                    }
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            load_posummary_report();
        }

        private void btngreaterthan_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = dateTimePicker1.Text;
            myglobal.REPORT_NAME = "DailyMicroReceiving";




            frmReport fr = new frmReport();
            fr.Show();
        }

        private void panel_title_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

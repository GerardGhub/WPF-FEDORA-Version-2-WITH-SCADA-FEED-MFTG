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
    public partial class frmApproverViewRepackMaterials : Form
    {
 

        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();


        private const int BaudRate = 9600;

        DataSet dset_section = new DataSet();
        Boolean ready = false;


        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();





        public frmApproverViewRepackMaterials(string feedCode, string ID,string bags, string batch, string feedType,string date)
        {
            InitializeComponent();
            this.FeedCode = feedCode;
            this.MyID = ID;
            this.Bags = bags;
            this.Batch = batch;
            this.FeedType = feedType;
            this.Dated = date;
        }
        public string FeedCode { get; set; }
        public string MyID { get; set; }
        public string Bags { get; set; }
        public string Batch { get; set; }
        public string FeedType { get; set; }
        public string Dated { get; set; }
        private void frmApproverViewRepackMaterials_Load(object sender, EventArgs e)
        {

            cboFeedCode.Text = FeedCode;
            lblproductionid.Text = MyID;
            txtnobatch.Text = Batch;
            txtbags.Text = Bags;
            textBox1.Text = FeedType;

            mfg_datePicker2.Text = Dated;
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();


          



    
            myglobal.global_module = "MICROS";
            load_search();
            Query();

        }

        void Query()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy
            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";



            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select * from [dbo].[rdf_recipe] WHERE feed_code = '" + cboFeedCode.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv2ndview.DataSource = dt;

            sql_con.Close();
        }


        DataSet dset_emp = new DataSet();
        public void load_search()
        {
            dset_emp.Clear();

         dset_emp = objStorProc.sp_getMajorTables("micro_materials_approver");


            doSearch();
            myglobal.global_module = "MACROS";
            
         dset_emp = objStorProc.sp_getMajorTables("macro_materials_approver");
           doSearch2();
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

                    else if (myglobal.global_module == "MICROS")
                    {
              
                        dv.RowFilter = "prod_id_repack= " + lblproductionid.Text + "";

                 
                    }

                    else if (myglobal.global_module == "MAC")
                    {
                   //     dv.RowFilter = "visitors_lastname like '%" + txtsearchs.Text + "%' or visitors_firstname like '%" + txtsearchs.Text + "%'";
                    }
                    dgvProductionSchedules.DataSource = dv;
        lblmicro.Text = dgvProductionSchedules.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
              //  txtsearchs.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             //   txtsearchs.Focus();
                return;
            }

        }





        void doSearch2()
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

                    else if (myglobal.global_module == "MACROS")
                    {

                        dv.RowFilter = "prod_id_repack= " + lblproductionid.Text + "";


                    }

                    else if (myglobal.global_module == "MAC")
                    {
                        //     dv.RowFilter = "visitors_lastname like '%" + txtsearchs.Text + "%' or visitors_firstname like '%" + txtsearchs.Text + "%'";
                    }
               dataGridView1.DataSource = dv;
                   lblmacro.Text = dataGridView1.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  txtsearchs.Focus();
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //   txtsearchs.Focus();
                return;
            }

        lbltotal.Text = (float.Parse(lblmicro.Text) + float.Parse(lblmacro.Text)).ToString();

        txtbags.Text = (float.Parse(txtnobatch.Text) * 40).ToString();

        }


        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lblfeedcode_Click(object sender, EventArgs e)
        {

        }

        private void lblproductionid_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvProductionSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProductionSchedules_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgv2ndview_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgv2ndview.RowCount > 0)
            {
                if (dgv2ndview.CurrentRow != null)
                {
                    if (dgv2ndview.CurrentRow.Cells["recipe_id"].Value != null)
                    {


                        textBox1.Text = dgv2ndview.CurrentRow.Cells["rp_feed_type"].Value.ToString();

                    }

                }
            }


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

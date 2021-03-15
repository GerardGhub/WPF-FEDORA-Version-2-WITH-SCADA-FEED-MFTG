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
    public partial class frmActiveRepackingMonitoring : Form
    {
        public frmActiveRepackingMonitoring()
        {
            InitializeComponent();
        }

        private void frmActiveRepackingMonitoring_Load(object sender, EventArgs e)
        {
           
            txtdateplusone.Text = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
            txtdateminus1.Text = DateTime.Now.AddDays(-1).ToString("M/d/yyyy");
            txtdateofoutminus2.Text = DateTime.Now.AddDays(-2).ToString("M/d/yyyy");
            dtpreceivingdate.Value = DateTime.Now;
            txt3rdsearch_TextChanged(sender, e);



            HideData();
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


        private void txt3rdsearch_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.start_micro_repacking as MICROSTART,emp.end_micro_repacking as MICROEND, emp.micro_repacking_time as DURATION, emp.start_macro_repacking as MACROSTART,emp.end_macro_repacking as MACROEND,emp.macro_repacking_time as DURATION2, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND emp.proddate='"+dtpFilter.Text+"'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lblcountprod3.Text = dgvProdToday.RowCount.ToString();

 
            //dataViews.Visible = true;
            //dgv_table_2nd_sup.Visible = true;
            ////lblmicroview.Visible = true; close muna
            sql_con.Close();
        }

        void HideData()
        {

            panel4.Visible = false;
            dgvProdToday.Visible = false;
            lblMicroIn.Visible = false;
            lblmicrostamp.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox4Micro.Visible = false;
                txtmycount.Visible = false;
            txtmycount2.Visible = false;
            textBox4Macro.Visible = false;
            txtmycount3.Visible = false;
            txtmycount4.Visible = false;

            lblstatusmonitoring.Visible = false;
                        txtproduction_id.Visible = false;
            dtpreceivingdate.Visible = false;
            txtproduction_id2.Visible = false;
            txt3rdsearch.Visible = false;
        }


        public void showmyData()
        {

            panel4.Visible = true;
            dgvProdToday.Visible = true;
            lblMicroIn.Visible = true;
            //lblmicrostamp.Visible = true;
            label7.Visible = true;
            //label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            //textBox4Micro.Visible = true;
            txtmycount.Visible = true;
            txtmycount2.Visible = true;
            //textBox4Macro.Visible = true;
            txtmycount3.Visible = true;
            txtmycount4.Visible = true;

            lblstatusmonitoring.Visible = true;

        }

        private void txtproduction_id_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "Select emp.production_id as ID, emp.item_code as ITEMCODE, emp.rp_description as DESCRIPTION,emp.feed_code as FEEDCODE, emp.rp_feed_type as FEEDTYPE, emp.quantity as QTY , emp.time_stamp_per_process as TIMESTAMP from rdf_recipe_to_production emp WHERE emp.production_id ='" + txtproduction_id.Text + "' AND emp.is_active='0' AND rp_category='MICRO'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvrepacked.DataSource = dt;

          txtmycount.Text = dgvrepacked.RowCount.ToString();
      
            sql_con.Close();














            String connetionString2 = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con2 = new SqlConnection(connetionString2);


            string sqlquery2 = "Select emp.production_id as ID, emp.item_code as ItemCode, emp.rp_description as ItemDescription,emp.feed_code as feedCode, emp.rp_feed_type as FeedType, emp.quantity as QTY,emp.time_stamp_per_process as TimeStamp from rdf_recipe_to_production emp WHERE emp.production_id ='" + txtproduction_id.Text + "' AND emp.repacking_status='1' AND rp_category='MACRO' AND rp_group='Validate'";
            sql_con2.Open();
            SqlCommand sql_cmd2 = new SqlCommand(sqlquery2, sql_con2);
            SqlDataAdapter sdr2= new SqlDataAdapter(sql_cmd2);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
           dgvMarcoRepOK.DataSource = dt2;

          txtmycount3.Text = dgvMarcoRepOK.RowCount.ToString();

            sql_con2.Close();








            String connetionString3 = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con3 = new SqlConnection(connetionString3);


            string sqlquery3 = "Select emp.production_id as ID, emp.item_code as ItemCode, emp.rp_description as ItemDescription,emp.feed_code as feedCode, emp.rp_feed_type as FeedType, emp.quantity as QTY from rdf_recipe_to_production emp WHERE emp.production_id ='" + txtproduction_id.Text + "' AND emp.repacking_status='0' AND rp_category='MACRO' AND rp_group='Validate'";
            sql_con3.Open();
            SqlCommand sql_cmd3 = new SqlCommand(sqlquery3, sql_con3);
            SqlDataAdapter sdr3 = new SqlDataAdapter(sql_cmd3);
            DataTable dt3 = new DataTable();
            sdr3.Fill(dt3);
            dgvMacroforRepacking.DataSource = dt3;
          txtmycount4.Text = dgvMacroforRepacking.RowCount.ToString();


            sql_con3.Close();
        }

        private void dgvProdToday_CurrentCellChanged(object sender, EventArgs e)
        {
            showVal();


            if(dtpmicrostart.Text.Trim() == string.Empty)
            {
                textBox4Micro.Text = "";
                return;



            }
            if (dtpmicroend.Text.Trim() == string.Empty)
            {
                textBox4Micro.Text = "";
                return;

                

            }




            DateTime time1 = DateTime.Parse(dtpmicrostart.Text);
            DateTime time2 = DateTime.Parse(dtpmicroend.Text);

            TimeSpan difference = time2 - time1;

    

            textBox4Micro.Text = Convert.ToString(difference);




            if (dtpmacroend.Text.Trim() == string.Empty)
            {
                textBox4Macro.Text = "";
                return;



            }

            if (dtpmacrostart.Text.Trim() == string.Empty)
            {
                textBox4Macro.Text = "";
                return;



            }



            DateTime time12 = DateTime.Parse(dtpmacrostart.Text);
            DateTime time22 = DateTime.Parse(dtpmacroend.Text);

            TimeSpan difference2 = time22 - time12;
            textBox4Macro.Text = Convert.ToString(difference2);





            DateTime a = DateTime.Parse(dtpreceivingdate.Text);
            DateTime b = DateTime.Parse(txtdateplusone.Text);

            TimeSpan t = b - a;
            double NrOfDays = t.TotalDays;
            txtsumofdays.Text = Convert.ToString(NrOfDays+ "day");




        }
        void showVal()
        {
            if (dgvProdToday.RowCount > 0)
            {
                if (dgvProdToday.CurrentRow != null)
                {
                    if (dgvProdToday.CurrentRow.Cells["ID"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dgv1stView.CurrentRow.Cells["prod"].Value);

                        txtproduction_id.Text = dgvProdToday.CurrentRow.Cells["ID"].Value.ToString();

                        txtproduction_id2.Text = dgvProdToday.CurrentRow.Cells["ID"].Value.ToString();
                      dtpmicrostart.Text = dgvProdToday.CurrentRow.Cells["MicroStart"].Value.ToString();
                        dtpmicroend.Text = dgvProdToday.CurrentRow.Cells["MicroEnd"].Value.ToString();

                        dtpmacrostart.Text = dgvProdToday.CurrentRow.Cells["MacroStart"].Value.ToString();
                        dtpmacroend.Text = dgvProdToday.CurrentRow.Cells["MacroEnd"].Value.ToString();
                    }

                }
            }

            //TimeSpan result = dt2 - dt1;

        }

        private void txtproduction_id2_TextChanged(object sender, EventArgs e)
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.production_id as ID, emp.item_code as ItemCode, emp.rp_description as ItemDescription,emp.feed_code as feedCode, emp.rp_feed_type as FeedType, emp.quantity as QTY from rdf_recipe_to_production emp WHERE emp.production_id ='" + txtproduction_id.Text + "' AND emp.is_active='1' AND rp_category='MICRO' AND NOT rp_group='Theoretical1' AND NOT rp_group='Theoretical2'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvrepacked2.DataSource = dt;

            txtmycount2.Text = dgvrepacked2.RowCount.ToString();

            sql_con.Close();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            txtproduction_id2_TextChanged(sender,e);
            txtproduction_id_TextChanged(sender, e);
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtproduction_id2_TextChanged(sender, e);
            txtproduction_id_TextChanged(sender, e);
        }

        private void dgvProdToday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProdToday_Click(object sender, EventArgs e)
        {
            txtproduction_id2_TextChanged(sender, e);
            txtproduction_id_TextChanged(sender, e);
        }

        private void btnexport1_Click(object sender, EventArgs e)
        {


            ////Creating DataTable
            //DataTable dt = new DataTable();

            ////Adding the Columns
            //foreach (DataGridViewColumn column in dgvrepacked.Columns)
            //{
            //    dt.Columns.Add(column.HeaderText, column.ValueType);
            //}

            ////Adding the Rows
            //foreach (DataGridViewRow row in dgvrepacked.Rows)
            //{
            //    dt.Rows.Add();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
            //    }
            //}

            ////Exporting to Excel
            //string folderPath = "C:\\Excel\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dt, "Customers");
            //    wb.SaveAs(folderPath + "DataGridViewExport.xlsx");
            //}


























        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            txt3rdsearch_TextChanged(sender, e);
            showmyData();
            lblcountprod3.Visible = true;
            label11.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime time1 = DateTime.Parse(dtpmicrostart.Text);
           DateTime time2 = DateTime.Parse(dtpmicroend.Text);

            TimeSpan difference = time1 - time2;

            //int hours = difference.Hours;
            //int minutes = difference.Minutes;

            textBox4Micro.Text = Convert.ToString(difference);
        }

        private void dgvProdToday_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvrepacked_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvrepacked2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvMarcoRepOK_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvMacroforRepacking_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
    }
}

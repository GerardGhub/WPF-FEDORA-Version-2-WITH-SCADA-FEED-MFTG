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
    public partial class fmProductionHours : Form
    {
        public fmProductionHours()
        {
            InitializeComponent();
        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            showmyData();
        }

        private void showmyData()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date,emp.plannerAndapprover,emp.micro_repacking_time,emp.macro_repacking_time,emp.basemixed_time,emp.production_time,emp.fg_time,emp.total_hours as TotalHours from rdf_production_advance emp WHERE emp.is_selected=1 AND emp.is_active=1 AND emp.canceltheapprove IS NULL AND emp.proddate='" + dtpFilter.Text + "'";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvProdToday.DataSource = dt;
            lblcountprod3.Text = dgvProdToday.RowCount.ToString();



            sql_con.Close();


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

        private void fmProductionHours_Load(object sender, EventArgs e)
        {
            showmyData();
        }
    }
}

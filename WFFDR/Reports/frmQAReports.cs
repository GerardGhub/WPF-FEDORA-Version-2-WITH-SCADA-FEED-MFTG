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
    public partial class frmQAReports : Form
    {
        public frmQAReports()
        {
            InitializeComponent();
        }

        private void frmQAReports_Load(object sender, EventArgs e)
        {

        }


       void ShowData()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "SELECT a.[po_sum_id],b.[po_number],b.[po_date] ,a.[item_code],a.[item_description] ,a.[qty_ordered],a.[qty_good],a.[qty_uom] ,a.[vendor_name] ,a.[qty_reject] ,a.[truck_remarks1],a.[truck_remarks2]  ,a.[truck_remarks3],a.[QA_by]  ,a.[plate_no] ,a.[truck_scale_rec_no] ,a.[vehicle_type] ,a.[truck_gross_weight] ,a.[truck_tare_weight],a.[truck_net_weight],a.[actual_delivered_uom]  ,a.[unloading_date] ,a.[test_date] ,a.[lot_no]  ,a.[delivery_acceptance]  ,a.[resack_others],a.[lab_1],a.[lab_2],a.[lab_3] ,a.[lab_4] ,a.[lab_5] ,a.[lab_6],a.[lab_7],a.[lab_8] ,a.[lab_9] ,a.[lab_10]  ,a.[phys_1] ,a.[phys_2] ,a.[phys_3],a.[phys_4] ,a.[phys_5] ,a.[phys_6],a.[phys_7_total] ,a.[class_macro] ,a.[point_origin],a.[infestation]  ,a.[drying_method] FROM[Fedoramain].[dbo].[rdf_po_summary_retail] a LEFT JOIN rdf_po_summary_rpt b ON b.po_sum_id = a.primary_key where CAST(DateChecklistCreated as date) BETWEEN '"+dtp1.Text+"' AND '"+dtp2.Text+"'";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvApproved.DataSource = dt;
            lblrecords.Text = dgvApproved.RowCount.ToString();



            sql_con.Close();
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dgvApproved_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

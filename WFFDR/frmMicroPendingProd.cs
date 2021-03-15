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
    public partial class frmMicroPendingProd : Form
    {
        frmMonthlyInventoryMicro ths;
        public frmMicroPendingProd(frmMonthlyInventoryMicro frm, string item_code)
        {
            InitializeComponent();
            this.ItemCode = item_code;

            ths = frm;
        }
        public string ItemCode { get; set; }

        private void frmMicroPendingProd_Load(object sender, EventArgs e)
        {

            lblitemcode.Text = ItemCode;
            MyQueryforMicro();
        }
         


        void MyQueryforMicro()
        {



            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "select BC.item_code,BC.rp_description,BC.feed_code,BC.rp_feed_type, sum(CAST(BC.formulation_qty as float)) as Qty,BC.proddate from [dbo].[rdf_recipe_to_production] BC LEFT JOIN rdf_production_advance a ON a.prod_id = BC.production_id where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and BC.status_of_person IS NULL and BC.rp_category='MICRO' AND NOT a.canceltheapprove IS NOT NULL AND a.finish_production_date IS NULL AND a.is_selected='1' and BC.item_code='" + lblitemcode.Text+ "' group by BC.item_code,BC.proddate,BC.feed_code,BC.rp_feed_type,BC.rp_description ";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table.DataSource = dt;


            decimal toty = 0;

            for (int i = 0; i < dgv_table.RowCount - 0; i++)
            {
                var value = dgv_table.Rows[i].Cells["Qty"].Value;
                if (value != DBNull.Value)
                {
                    toty += Convert.ToDecimal(value);
                }
            }
            if (toty == 0)
            {

            }



        lbltotalqty.Text = toty.ToString("##.00");
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
    }
}

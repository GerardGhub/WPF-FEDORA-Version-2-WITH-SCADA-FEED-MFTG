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
        public frmFeedCodeTransactions(string feedCode)
        {
            InitializeComponent();
            this.FeedCode = feedCode;
        }
        public string FeedCode { get; set; }

        private void frmFeedCodeTransactions_Load(object sender, EventArgs e)
        {
            txtFeedCode.Text = FeedCode;
            SearchQuery();
        }


        void SearchQuery()
        {

            //String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=Fedoramain;Integrated Security=SSPI";
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            //deploy

            SqlConnection sql_con = new SqlConnection(connetionString);


            //string sqlquery = "SELECT emp.p_feed_code,emp.bags_int,emp.batch_int,emp.proddate,emp.feed_type,emp.bagorbin,emp.prod_id,SUM(fg.bags_total) AS BagsCount,SUM(fg.bulkentry_total) AS BulkCount,SUM(fg.bulkentry_total) AS GrandTotal FROM rdf_production_advance emp LEFT JOIN rdf_finish_goods fg ON emp.prod_id = fg_prod_id  WHERE emp.is_selected = '1'  AND NOT emp.canceltheapprove IS NOT NULL AND emp.p_feed_code = '"+txtFeedCode.Text+"' GROUP BY emp.p_feed_code,emp.bags_int,emp.batch_int,emp.proddate,emp.feed_type,emp.bagorbin,emp.series_num,emp.prod_id ORDER BY emp.prod_id ASC";


            string sqlquery = "  SELECT emp.p_feed_code,emp.bags_int,emp.batch_int,emp.proddate,emp.feed_type,emp.bagorbin,emp.prod_id,SUM(case when fg.fg_options = 'Bagging' and fg.status ='Good' then 1 else 0 end) AS BagsCount,SUM(fg.bulk_inventory) AS BulkCount,SUM(fg.bulk_inventory) + SUM(case when fg.fg_options = 'Bagging' and fg.status ='Good' then 1 else 0 end) AS GrandTotal FROM rdf_production_advance emp LEFT JOIN rdf_repackin_finishgoods fg ON emp.prod_id = fg.prod_adv  WHERE emp.is_selected = '1'  AND NOT emp.canceltheapprove IS NOT NULL AND emp.p_feed_code = '" + txtFeedCode.Text+ "' AND fg.printing_date IS NOT NULL  AND fg.is_received='1' GROUP BY emp.p_feed_code,emp.bags_int,emp.batch_int,emp.proddate,emp.feed_type,emp.bagorbin,emp.series_num,emp.prod_id ORDER BY emp.prod_id ASC";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgv_table.DataSource = dt;
            sql_con.Close();

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

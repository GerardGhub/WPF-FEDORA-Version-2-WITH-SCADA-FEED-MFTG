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
using Tulpep.NotificationWindow;

namespace WFFDR
{
    public partial class frmFGReprocessReports : Form
    {
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        public frmFGReprocessReports()
        {
            InitializeComponent();
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            data1();
           

        }

        void data1()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

          //  string sqlquery = "SELECT DISTINCT a.p_feed_code,a.prod_id,a.bags_int,a.batch_int,a.proddate,a.feed_type,a.total_reprocess_count as PENDING,SUM(case when b.status = 'Reprocess' and b.fg_reprocess_by IS NOT NULL then 1 else 0 end) as DONE,SUM(case when b.status = 'Reprocess' then 1 else 0 end) as TOTAL, b.fg_added_by FROM rdf_production_advance a LEFT JOIN rdf_repackin_finishgoods b ON a.prod_id = b.prod_adv WHERE a.is_selected = '1'  AND NOT a.canceltheapprove IS NOT NULL AND NOT a.total_reprocess_count = '0' and CAST(b.fg_added_by as date) BETWEEN '" + dtp1.Text + "' AND '" + dtp2.Text + "' GROUP BY a.p_feed_code,a.prod_id,a.bags_int,a.batch_int,a.proddate,a.feed_type,a.total_reprocess_count,b.date_added,b.fg_added_by ORDER BY a.prod_id";

            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "SELECT b.prod_adv as ProdID,b.fg_feed_code,b.fg_feed_type,b.fg_proddate,b.fg_bags,b.fg_added_by,a.total_reprocess_count as PENDING,SUM(case when b.status = 'Reprocess' and b.fg_reprocess_by IS NOT NULL then 1 else 0 end) as DONE,a.total_reprocess_count + SUM(case when FORMAT(CAST(b.fg_added_by as date),'M/d/yyyy') BETWEEN '" + dtp1.Text + "' and '" + dtp2.Text + "' and b.status = 'Reprocess' and b.fg_reprocess_by IS NOT NULL then 1 else 0 end) as TOTAL  FROM rdf_production_advance a LEFT JOIN rdf_repackin_finishgoods b ON a.prod_id = b.prod_adv WHERE a.is_selected = '1'  AND NOT a.canceltheapprove IS NOT NULL and CAST(b.fg_added_by as date) BETWEEN '" + dtp1.Text+"' and '"+dtp2.Text+"' GROUP BY a.total_reprocess_count,b.fg_added_by,b.fg_feed_code,b.prod_adv,b.fg_bags,b.fg_feed_type,b.fg_proddate";
            
            
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvApproved.DataSource = dt;
            lblrecords.Text = dgvApproved.RowCount.ToString();



            sql_con.Close();

            //GrandTotal();

        }


        void data2prod_id()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            //  string sqlquery = "SELECT DISTINCT a.p_feed_code,a.prod_id,a.bags_int,a.batch_int,a.proddate,a.feed_type,a.total_reprocess_count as PENDING,SUM(case when b.status = 'Reprocess' and b.fg_reprocess_by IS NOT NULL then 1 else 0 end) as DONE,SUM(case when b.status = 'Reprocess' then 1 else 0 end) as TOTAL, b.fg_added_by FROM rdf_production_advance a LEFT JOIN rdf_repackin_finishgoods b ON a.prod_id = b.prod_adv WHERE a.is_selected = '1'  AND NOT a.canceltheapprove IS NOT NULL AND NOT a.total_reprocess_count = '0' and CAST(b.fg_added_by as date) BETWEEN '" + dtp1.Text + "' AND '" + dtp2.Text + "' GROUP BY a.p_feed_code,a.prod_id,a.bags_int,a.batch_int,a.proddate,a.feed_type,a.total_reprocess_count,b.date_added,b.fg_added_by ORDER BY a.prod_id";

            //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";
            string sqlquery = "SELECT b.prod_adv as ProdID,b.fg_feed_code,b.fg_feed_type,b.fg_proddate,b.fg_bags,b.fg_added_by,a.total_reprocess_count as PENDING,SUM(case when b.status = 'Reprocess' and b.fg_reprocess_by IS NOT NULL then 1 else 0 end) as DONE,a.total_reprocess_count + SUM(case when FORMAT(CAST(b.fg_added_by as date),'M/d/yyyy') BETWEEN '"+dtp1.Text+"' and '"+dtp2.Text+"' and b.status = 'Reprocess' and b.fg_reprocess_by IS NOT NULL then 1 else 0 end) as TOTAL  FROM rdf_production_advance a LEFT JOIN rdf_repackin_finishgoods b ON a.prod_id = b.prod_adv WHERE a.is_selected = '1'  AND NOT a.canceltheapprove IS NOT NULL and CAST(b.fg_added_by as date) BETWEEN '" + dtp1.Text + "' and '" + dtp2.Text + "' and b.prod_adv = '" + txtProductionId.Text + "' GROUP BY a.total_reprocess_count,b.fg_added_by,b.fg_feed_code,b.prod_adv,b.fg_bags,b.fg_feed_type,b.fg_proddate";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvApproved.DataSource = dt;
            lblrecords.Text = dgvApproved.RowCount.ToString();



            sql_con.Close();

            //GrandTotal();

        }
        void GrandTotal()
        {

            for (int n = 0; n < (dgvApproved.Rows.Count); n++)
            {
                //9

                //double s1 = Convert.ToDouble(dgv_table.Rows[n].Cells[2].Value);

                //double s2 = Convert.ToDouble(dgv_table.Rows[n].Cells[3].Value);


                double s4 = Convert.ToDouble(dgvApproved.Rows[n].Cells[6].Value);
                double s5 = Convert.ToDouble(dgvApproved.Rows[n].Cells[7].Value);




                double grandtotal = s4 + s5;

                ////double onhand = s4 - s5;

                //dgv_table.Rows[n].Cells[4].Value = grandtotal.ToString();
                dgvApproved.Rows[n].Cells[8].Value = grandtotal.ToString();

            }

        }

        private void frmFGReprocessReports_Load(object sender, EventArgs e)
        {
            dtp1.Text = (DateTime.Now.ToString("M/d/yyyy"));
            dtp2.Text = (DateTime.Now.ToString("M/d/yyyy"));
            data1();
            Load_prodhisledger();
        }

        public void Load_prodhisledger()
        {
            string mcolumns = "test,ProdID,ProdPlan,Feedcode,Feedtype,Bags,TIMESTAMP,ReprocessBy,DumpDate";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, dgvprodhis, mcolumns, "prodhisledger", lblprod.Text.ToString(), 0, dtp1.Text.ToString(), dtp2.Text.ToString());
            lblrecordhis.Text = dgvprodhis.Rows.Count.ToString();
        }

            private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            if (txtProductionId.Text.Trim() == string.Empty)
            {
                data1();
            }
            else
            {
                data2prod_id();
            }
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

        private void dtp1_ValueChanged_1(object sender, EventArgs e)
        {

            if (txtProductionId.Text.Trim() == string.Empty)
            {
                data1();
            }
            else
            {
                data2prod_id();
            }


  



        }

        private void btnExits_Click(object sender, EventArgs e)
        {
            if (lblrecords.Text == "0")
            {
                NoDataFount();
                return;
            }

            if (txtProductionId.Text.Trim() == string.Empty)
            {
     
           


            myglobal.DATE_REPORT = dtp1.Text;
            myglobal.DATE_REPORT2 = dtp2.Text;

            myglobal.REPORT_NAME = "ReprocessReport";

            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

            //this.Close();

            }
            else
            {
                if(lblrecords.Text =="0")
                {
                    NoDataFount();
                    return;
                }
         //do Something Good
         else
                {

                    myglobal.DATE_REPORT = dtp1.Text;
                    myglobal.DATE_REPORT2 = dtp2.Text;
                    myglobal.DATE_REPORT3 = txtProductionId.Text;
                    myglobal.REPORT_NAME = "ReprocessReportProdID";

                    frmReport fr = new frmReport();

                    fr.WindowState = FormWindowState.Maximized;
                    fr.Show();
                    txtProductionId.Text = "";
                    //this.Close();

                }



            }

        }




        public void NoDataFount()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "No Data Found for Printing!";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        private void txtProductionId_TextChanged(object sender, EventArgs e)
        {

            if(txtProductionId.Text.Trim()==string.Empty)
            {
                data1();
            }
            else
            {
                data2prod_id();
            }

        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvApproved.RowCount > 0)
            {
                if (dgvApproved.CurrentRow != null)
                {
                    if (dgvApproved.CurrentRow.Cells["ProdID"].Value != null)
                    {

                        lblprod.Text = dgvApproved.CurrentRow.Cells["ProdID"].Value.ToString();
                        Load_prodhisledger();
                    }

                }
            }
        }

        private void dgvprodhis_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

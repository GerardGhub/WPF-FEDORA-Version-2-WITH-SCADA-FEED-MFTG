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
    public partial class frmRepackingProductionCheckList : Form
    {
        public frmRepackingProductionCheckList()
        {
            InitializeComponent();
        }

        private void frmRepackingProductionCheckList_Load(object sender, EventArgs e)
        {
            OverALLView();
        }


        public void OverALLView()
        {


  


                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

                //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
                SqlConnection sql_con = new SqlConnection(connetionString);


                //gerald             string sqlquery = "Select emp.prod_id as ID, emp.p_feed_code as Emp_Number, emp.p_bags as Department,emp.p_nobatch as TotalPack,emp.proddate as Production_Date, emp.repacking_status as repack_status from rdf_production_advance emp WHERE emp.proddate ='" + txtdateplusone.Text + "' OR emp.proddate ='"+dtpreceivingdate.Text+"' OR emp.proddate ='"+ txtdateminus1.Text+"' AND emp.is_selected=1 AND emp.repacking_status='ready' AND NOT emp.canceltheapprove IS NOT NULL";

                //if (cmdFedoraModules.Text == "Overall Reports From and To")
                //{


                string sqlquery = "Select emp.prod_id as PROD_ID,emp.proddate as PROD_PLAN, emp.p_feed_code as FEEDCODE,emp.p_bags as BAGS,emp.is_active,emp.canceltheapprove,emp.is_selected as STATUS, emp.is_selected as PLANNING, emp.micro_bit as MICRO,emp.macro_bit as MACRO, emp.micro_mixing_automation as BASEDMIXED,emp.aproved_date_time as APPROVED_DATE from [dbo].[rdf_production_advance] emp LEFT JOIN [dbo].[rdf_finish_goods] empe ON emp.prod_id=empe.fg_prod_id WHERE CAST(emp.proddate as date) BETWEEN '" + dtpFilter.Text + "' AND '" + dtpTo.Text + "' AND NOT emp.canceltheapprove IS NOT NULL AND NOT emp.iscancelreason IS NOT NULL AND emp.iscancel IS NULL AND emp.is_selected='1'";


                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvProductionSchedules.DataSource = dt;
                //lblnotdonemicro2.Text = dgvProdToday2.RowCount.ToString();

                lbltotalprod.Text = dgvProductionSchedules.RowCount.ToString();



                sql_con.Close();








        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            OverALLView();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            OverALLView();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class frmTheoScada : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
       
        
 

        public frmTheoScada()
        {
            InitializeComponent();
        }

        private void frmMicroReceiving_Load(object sender, EventArgs e)
        {
 

            objStorProc = xClass.g_objStoredProc.GetCollections();

  
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


        void dataShow()
        {
            try
            {

    

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "SELECT emp.item_id,emp.item_code,emp.item_description,emp.Category,emp.item_group,ISNULL(t2.SCADA,0) as SCADA,ISNULL(t5.SCADAFORMULATION,0) as SCADAFORMULATION,t2.SCADA - t5.SCADAFORMULATION as DIFFERENCE,(t2.SCADA - t5.SCADAFORMULATION) / (ISNULL(t2.SCADA,0)) * 100 as PERCENTAGE FROM rdf_raw_materials emp LEFT JOIN ( select BC.theo_item_code, sum( BC.actual_qty ) as SCADA  from theo_logs_tbl BC where CAST(date_time as date) BETWEEN '" + dtp1.Text+"' and '"+dtp2.Text+ "' group by BC.theo_item_code ) t2 on emp.item_code = t2.theo_item_code LEFT JOIN(select BC.theo_item_code, sum(BC.mat_sp ) as SCADAFORMULATION  from theo_logs_tbl BC where CAST(date_time as date) BETWEEN '"+dtp1.Text+"' and '"+dtp2.Text+ "' group by BC.theo_item_code ) t5 on emp.item_code = t5.theo_item_code WHERE emp.is_active = 1 AND emp.Category='MACRO' and not emp.item_group='Validate' AND not SCADA='0' ORDER BY emp.item_group";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvApproved.DataSource = dt;
            lblrecords.Text = dgvApproved.RowCount.ToString();



            sql_con.Close();

            //GrandTotal();


            decimal toty = 0;

            for (int i = 0; i < dgvApproved.RowCount - 0; i++)
            {
                var value = dgvApproved.Rows[i].Cells["SCADA"].Value;
                if (value != DBNull.Value)
                {
                    toty += Convert.ToDecimal(value);
                }
            }
            if (toty == 0)
            {

            }



          lblscadacount.Text = toty.ToString("##.00");




            decimal tot = 0;

            for (int i1 = 0; i1 < dgvApproved.RowCount - 0; i1++)
            {
                var values = dgvApproved.Rows[i1].Cells["SCADAFORMULATION"].Value;
                if (values != DBNull.Value)
                {
                    tot += Convert.ToDecimal(values);
                }
            }
            if (tot == 0)
            {

            }



           lblformulationcount.Text = tot.ToString("##.00");



lbldifference.Text = (float.Parse(lblscadacount.Text) - float.Parse(lblformulationcount.Text)).ToString("#,0.00");//



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void txtmainsearch_TextChanged(object sender, EventArgs e)
        {
          //  String connetionString = @"Server=FM-MMERCADO-L;Initial Catalog=hr_bak;Integrated Security=SSPI";

          //  //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=hr_bak;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
          //  SqlConnection sql_con = new SqlConnection(connetionString);



          //  string sqlquery = "select received_id,r_receiving_date,r_supplier,r_item_category,r_item_code,r_quantity,r_receiving_details,days_to_expired from [dbo].[rdf_microreceiving_entry] WHERE r_item_code like '%" + txtmainsearch.Text + "%'";
          //  sql_con.Open();
          //  SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
          //  SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
          //  DataTable dt = new DataTable();
          //  sdr.Fill(dt);

          //  dgv_table.DataSource = dt;
          ////  lblCounter.Text = dgv_table.RowCount.ToString();
          //  sql_con.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_table_CurrentCellChanged(object sender, EventArgs e)
        {
  
        }




        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void dgvretaillogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



  

        private void txtmainsearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            dataShow();
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            dataShow();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Print the Data ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


                myglobal.DATE_REPORT = dtp1.Text;
                myglobal.DATE_REPORT2 = dtp2.Text;

                myglobal.REPORT_NAME = "TheoScadaPrint";

                frmReport fr = new frmReport();

                fr.WindowState = FormWindowState.Maximized;
                fr.Show();




            }
            else
             {

                return;
            }


            }
    }
}

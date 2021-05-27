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
    public partial class frmReprocessAdjustment : Form
    {

        myclasses xClass = new myclasses();
        //IStoredProcedures objStorProc = null;

        //int p_id = 0;
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();


        public frmReprocessAdjustment()
        {
            InitializeComponent();
        }

        private void frmProdMonitoring_Load(object sender, EventArgs e)
        {

            load_ReprocessAdjustments();

            txtaddedby.Text = userinfo.emp_name.ToUpper();
        }

        public void load_ReprocessAdjustments()
        {
            string mcolumns = "test,fg_id,bmx_id_string,prod_adv,fg_feed_code,fg_bags,fg_options,fg_proddate,status";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dataView, mcolumns, "FGReprocessAdjustment");
            // Menu.lblrecords.Text = dgv_table.RowCount.ToString();
            lbltotaldata.Text = dataView.RowCount.ToString();
            //poreceived_header();

            //            string mcolumns = "test,prod_id,p_feed_code,feed_type,bags_int,batch_int,proddate,total_reprocess_count,DONE,TOTAL";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
        }

        private void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueOfReprocess();
        }



                void showValueOfReprocess()
                {

                    if (dataView.RowCount > 0)
                    {
                        if (dataView.CurrentRow != null)
                        {
                            if (dataView.CurrentRow.Cells["prod_adv"].Value != null)
                            {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);

                        txtfeedcode.Text = dataView.CurrentRow.Cells["fg_feed_code"].Value.ToString().ToUpper();
                        txtproductionid.Text = dataView.CurrentRow.Cells["prod_adv"].Value.ToString();
                     txtfg_id.Text = dataView.CurrentRow.Cells["fg_id"].Value.ToString();

                   txtprodplan.Text = dataView.CurrentRow.Cells["fg_proddate"].Value.ToString();
                        txtbags.Text = dataView.CurrentRow.Cells["fg_bags"].Value.ToString();
                        txtstatus.Text = dataView.CurrentRow.Cells["status"].Value.ToString();



            
                    }

                }
                    }

                }



        void saveData()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "UPDATE [dbo].[rdf_repackin_finishgoods] set bmx_id_string='" + txtfg_id.Text + "', adjusted_by='"+txtaddedby.Text+"',adjusted_date=GETDATE() where fg_id='" + txtfg_id.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataView.DataSource = dt;

            sql_con.Close();


        }

        void SaveSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Data Succesfully Adjusted !";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
 
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }







        public void SearchSomeData()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            //        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "SELECT fg_id,bmx_id_string,prod_adv,fg_feed_code,fg_feed_type,fg_bags,fg_batch,fg_proddate,fg_micro_prepa,fg_macro_prepa,fg_micro_bmx,fg_finish_production,added_by,actual_weight FROM rdf_repackin_finishgoods WHERE status='Reprocess' and not proc_time_stamp is not null and prod_adv='"+txtprod_id.Text+ "' and bmx_id_string !='NO BARCODE'";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
          dgv_fg_repack.DataSource = dt;
            lbltotalcount.Text = dgv_fg_repack.RowCount.ToString();



            sql_con.Close();
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Adjustment Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                //

                saveData();
                SaveSuccess();

                frmProdMonitoring_Load(sender, e);




            }
            else
            {
                return;
            }



            }

        private void txtprod_id_TextChanged(object sender, EventArgs e)
        {
            SearchSomeData();
        }

        private void dgv_fg_repack_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

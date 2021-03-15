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
    public partial class frmFGMaterialTracking : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;


        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        public frmFGMaterialTracking()
        {
            InitializeComponent();
        }

        private void frmSystemOnline_Load(object sender, EventArgs e)
        {
            load_micro();
            dataGridView1.Visible = false;
            lblrecords.Visible = false;

            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            myglobal.global_module = "Active";
            load_search();

            txtMainInput.Text = "";
            txtMainInput.Select();
            txtMainInput.Focus();

           lbladdedby.Text = userinfo.emp_name.ToUpper();
        }
        DataSet dset_emp = new DataSet();
        void load_search()
        {

            dset_emp.Clear();



            dset_emp = objStorProc.sp_getMajorTables("FGBarcoding");
       
            doSearch();
       

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
                        //dv.RowFilter = "firstname like '%" + txtmainsearch.Text + "%' or lastname like '%" + txtsearch.Text + "%' or employee_number like '%" + txtsearch.Text + "%' or employment_status_name like '%" + txtsearch.Text + "%'";
                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "fg_id = '" + txtMainInput.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {
                        //dv.RowFilter = "visitors_lastname like '%" + txtsearch.Text + "%' or visitors_firstname like '%" + txtsearch.Text + "%'";
                    }
                    dataGridView1.DataSource = dv;
                    lblrecords.Text = dataGridView1.RowCount.ToString();
             
                    txtMainInput.Text = "";
                    txtMainInput.Select();
                    txtMainInput.Focus();
                  if(lblrecords.Text=="0")
                    {
                        //MessageBox.Show("FG Barcode Not Found!");
                        NotExists();
                        panel1.Visible = false;
                        txtMainInput.Text = "";
                        txtMainInput.Select();
                        txtMainInput.Focus();
                        btnReprocessclick.Visible = false;
                        lblrecordforreprocess.Visible = false;
                        dgvduplicatedata.Visible = false;
                        lblstatus.Visible = false;
                        label2.Visible = false;
                    }
                  else
                    {
                        lblfglabel.Visible = true;
                        txtdate4.Visible = true;
                        panel1.Visible = true;
                        label2.Visible = true;
                        lblstatus.Visible = true;

              
                        ValidatedSuccess();//gerard
                        //if(lblstatus.Text=="Reprocess")
                        //{
                        //    LoadData();
                        //    lblprod_id.Text = dgvduplicatedata.CurrentRow.Cells["prod_id"].Value.ToString();
                        //    dgvduplicatedata.Visible = true;
                        //}
                        //else
                        //{
                        //    dgvduplicatedata.Visible = false;
                        //    lblrecordforreprocess.Text = "0";
                        //}


                        if (lblrecordforreprocess.Text=="0")
                        {
                            btnReprocessclick.Visible = false;
                            lblrecordforreprocess.Visible = false;
                        }
                        else
                        {
                            btnReprocessclick.Visible = true;
                            lblrecordforreprocess.Visible = true;
                        }

                        if(txtprocessBy.Text.Trim() == string.Empty)
                        {
              
                        }
                        else
                        {

                            lbladdedby.Visible = false;
                            dgvduplicatedata.Visible = false;
                            btnReprocessclick.Visible = false;
                            lblrecordforreprocess.Visible = false;
                            Alreadyreprocess();
                        }




                    }
                }
              
            }
   
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }
            catch (EvaluateException)
            {
                //MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtmainfeedcode.Focus();
                return;
            }

  
        }


        public void load_micro()
        {
            string mcolumns = "test,item_id,item_code,category_name,item_description,classification,quantity,supplier,address,contact_no,date_added,expiration_details,delivery_details";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgv_table, mcolumns, "micro_raw_materialsnew");
            //lblrecords.Text = dgv_table.RowCount.ToString();
         //   textBox1.Text = dgv_table.RowCount.ToString();
            micro_materials_header();
        }

        void micro_materials_header()
        {
            dgv_table.Columns[0].HeaderText = "Item ID";
            dgv_table.Columns[1].HeaderText = "Item Code";
            dgv_table.Columns[2].HeaderText = "Item Category";
            dgv_table.Columns[3].HeaderText = "Description";
            dgv_table.Columns[4].HeaderText = "Classification";
            dgv_table.Columns[5].HeaderText = "Reorder Level";
            dgv_table.Columns[6].HeaderText = "Supplier";
            dgv_table.Columns[7].HeaderText = "Supplier Address";
            dgv_table.Columns[8].HeaderText = "Supplier Contact";
            dgv_table.Columns[9].HeaderText = "Date Added";
            dgv_table.Columns[10].HeaderText = "Expiration Details";
            dgv_table.Columns[11].HeaderText = "Delivery Details";


            //   this.dgv_tablemicro.Columns["quantity"].Frozen = true;

            //  //    if (emp_flag == 2)
            /// //    {
            // dgv_table.Columns[28].HeaderText = "Date Resigned";
            //     dgv_tablemicro.Columns[28].HeaderText = "Date Of Separation";
            //    dgv_tablemicro.Columns[29].HeaderText = "Reason Of Separation";
            //   dgv_tablemicro.Columns[30].HeaderText = "Remarks";
            /// // }

        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
           if(txtMainInput.Text.Trim() == string.Empty)
            {
                FillUpRequiredFields();
                return;

            }

            doSearch();
        }

        private void txtMainInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBarcode_Click(sender, e);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            showValueDailyProduction();
        }
        void showValueDailyProduction()
        {

            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["fg_id"].Value != null)
                    {
                        //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);
                        txtdate1.Text = dataGridView1.CurrentRow.Cells["fg_micro_prepa"].Value.ToString();
                 lblproduction.Text = dataGridView1.CurrentRow.Cells["fg_finish_production"].Value.ToString();
                        txtdate2.Text = dataGridView1.CurrentRow.Cells["fg_micro_bmx"].Value.ToString();
                        txtdate3.Text = dataGridView1.CurrentRow.Cells["fg_macro_prepa"].Value.ToString();
                        txtfg_id.Text = dataGridView1.CurrentRow.Cells["fg_id"].Value.ToString();
                        txtfgoptions.Text = dataGridView1.CurrentRow.Cells["fg_options"].Value.ToString();
                        txtactualweight.Text = dataGridView1.CurrentRow.Cells["actual_weight"].Value.ToString();
                 txtfeedcode.Text = dataGridView1.CurrentRow.Cells["fg_feed_code"].Value.ToString();
                        txtbags.Text = dataGridView1.CurrentRow.Cells["fg_bags"].Value.ToString();
                        txtbatch.Text = dataGridView1.CurrentRow.Cells["fg_batch"].Value.ToString();
                        txtfeedtype.Text = dataGridView1.CurrentRow.Cells["fg_feed_type"].Value.ToString();
                        txtproductionid.Text = dataGridView1.CurrentRow.Cells["prod_adv"].Value.ToString();
                        dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fg_proddate"].Value.ToString();
                    txtdate4.Text = dataGridView1.CurrentRow.Cells["fg_date_added"].Value.ToString();
                        txtprocessBy.Text = dataGridView1.CurrentRow.Cells["fg_reprocess_by"].Value.ToString();
                        txtbulkentrytotal.Text = dataGridView1.CurrentRow.Cells["bulkentry_total"].Value.ToString();
                       txtbagsentrytotal.Text = dataGridView1.CurrentRow.Cells["bags_total"].Value.ToString();
                  lblstatus.Text = dataGridView1.CurrentRow.Cells["status"].Value.ToString();
                        //txtfeedtype.Text = dataGridView1.CurrentRow.Cells["rp_feed_type"].Value.ToString();
                    }

                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //myglobal.DATE_REPORT = dateTimePicker1.Text;
            myglobal.DATE_REPORT = txtproductionid.Text;
            myglobal.REPORT_NAME = "FGTrackingRawMaterials";
            //myglobal.DATE_REPORT = dateTimePicker1.Text;



            frmReport fr = new frmReport();
            fr.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            myglobal.DATE_REPORT = txtproductionid.Text;
            myglobal.REPORT_NAME = "FGTrackingRawMaterialsMacro";




            frmReport fr = new frmReport();
            fr.Show();
        }

        private void txtMainInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        void ValidatedSuccess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY SCAN! "+txtfeedtype.Text+"";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.AnimationDuration = 100;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 100;
            popup.AnimationInterval = 2;
            popup.AnimationDuration = 100;


            popup.ShowOptionsButton = true;


        }

        void ValidatedSuccessReprocess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY REPROCESS! " + txtfeedtype.Text + "";
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.AnimationDuration = 100;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 100;
            popup.AnimationInterval = 2;
            popup.AnimationDuration = 100;


            popup.ShowOptionsButton = true;


        }



        void NotExists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FINISHED GOOD IS NOT EXISTS!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }


        void Alreadyreprocess()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Already reprocess By "+txtprocessBy.Text+"!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }



        void FillUpRequiredFields()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "FILL UP THE REQUIRED FIELDS!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);

            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.AnimationDuration = 200;
            popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        void LoadData()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "SELECT p_feed_code as FeedCode, feed_type as FeedType, p_bags as Bags, p_nobatch as Batch, proddate as ProductionDate, prod_id FROM [dbo].[rdf_production_advance] a  WHERE  p_feed_code='"+txtfeedcode.Text+"' AND  NOT a.prod_id = '" + txtproductionid.Text + "' AND" +
                "        a.repacking_status='Finish' AND a.BMX_Status IS NOT NULL AND a.finish_production_date IS NOT NULL AND a.fg_date_finish IS NULL";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
           dgvduplicatedata.DataSource = dt;
            lblrecordforreprocess.Text = dgvduplicatedata.RowCount.ToString();



        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMainInput_TextChanged(object sender, EventArgs e)
        {

        }

        public void UpdateFg()
        {

            lbltimestamp.Text = DateTime.Now.ToString();
            txtdate.Text = DateTime.Now.ToString("M/d/yyyy");

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);



            string sqlquery = "UPDATE [dbo].[rdf_repackin_finishgoods] SET reproccess_prod_id='"+lblprod_id.Text+ "',fg_reprocess_by='" + lbladdedby.Text+"',proc_time_stamp='"+lbltimestamp.Text+"',fg_added_by='"+txtdate.Text+"'  WHERE  bmx_id_string='" + txtfg_id.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

        dgvUpdatefg.DataSource = dt;


        }

















        private void dgvduplicatedata_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvduplicatedata_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (dgvduplicatedata.RowCount > 0)
            //{
            //    if (dgvduplicatedata.CurrentRow != null)
            //    {
            //        if (dgvduplicatedata.CurrentRow.Cells["prod_id"].Value != null)
            //        {
            //            //p_id = Convert.ToInt32(dataView.CurrentRow.Cells["prod_id"].Value);
            //           lblprod_id.Text = dgvduplicatedata.CurrentRow.Cells["prod_id"].Value.ToString();

            //        }

            //    }
            //}
        }

        private void btnReprocessclick_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Reprocess  feedcode " + txtfeedcode.Text + ", ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


            }
            else
            {
                return;
            }


            UpdateFg();
            panel1.Visible = false;
            lblrecordforreprocess.Visible = false;
            dgvduplicatedata.Visible = false;
            lblstatus.Visible = false;
            label2.Visible = false;
            txtMainInput.Text = "";
            btnReprocessclick.Visible = false;
            ValidatedSuccessReprocess();
            frmSystemOnline_Load(sender,e);

            //frmSystemOnline_Load(sender, e);
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Reprocess  feedcode " + txtfeedcode.Text + ", ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {


            }
            else
            {
                return;
            }
        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

        }
    }
}

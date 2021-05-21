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
    public partial class frmShowOrder : Form
    {


 
        myclasses xClass = new myclasses();

        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();


        DataSet dSet = new DataSet();
       
        Boolean ready = false;
      

        public myclasses classes = new myclasses();
     


        public DataSet dset = new DataSet();
       
        frmFGMoveorderPrinting ths;
        public frmShowOrder(string Order_No,string EncodedBy, string Quantity, string Date,frmFGMoveorderPrinting frm)
        {
            
            InitializeComponent();
            this.Order_no = Order_No;
            this.encoder = EncodedBy;
            this.qty = Quantity;
            this.date = Date;
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }
        public string Order_no { get; set; }
        public string encoder { get; set; }
        public string qty{ get; set; }
        public string date { get; set; }

 
        private void frmShowOrder_Load(object sender, EventArgs e)
        {
            
            objStorProc = xClass.g_objStoredProc.GetCollections();
            lblorder.Text = Order_no;
            lblencodedby.Text = encoder;
            lbltotalqty.Text = qty;
            lbldate.Text = date;
        
            showTheData();
            

            foreach (DataGridViewRow dgvr in this.dgvshowQTYbag.Rows)
            {
                dgvr.Cells["binnumber"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvr.Cells["feed_code"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvr.Cells["feed_type"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
              
                dgvr.Cells["sack_bin"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvr.Cells["order_no"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvr.Cells["mama"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvr.Cells["production_date"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvr.Cells["uom"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;



            }

            txtdateandtime.Text = DateTime.Now.ToString();

            transactdate.Text = (DateTime.Now.ToString("MM/dd/yyyy"));

            txtdatenow.Text = (DateTime.Now.ToString("MM/dd/yyyy"));

            lblcanceldate.Text = (DateTime.Now.ToString("MM/dd/yyyy"));

            loadCustomer();
            loadWarehouse();
            Loadplatenumber();
            cboWarehouse_SelectedIndexChanged(sender, e);

            if(lblrecords.Text=="0")
            {

                

            }
            else
            {
                cboCustomer.Text = dgvshowQTYbag.CurrentRow.Cells["customer"].Value.ToString();
                cbplatenumber.Text = dgvshowQTYbag.CurrentRow.Cells["platenumber"].Value.ToString();


            }
         

            txtinput.Text = "";
            txtinput_TextChanged(sender, e);
            textBox1.Text = "";
            this.BringToFront();
            btnTransact.Visible = true;
            mfg_datePicker2.Text = (DateTime.Now.ToString("MM/dd/yyyy"));
            mfg_datePicker2.MaxDate = DateTime.Now;
            mfg_datePicker2.MinDate = DateTime.Now.AddDays(-14);

            lblcancelby.Text = userinfo.emp_name.ToUpper();
            if(lblrecords.Text=="0")
            {
              
                label1.Visible = false;
                lblgettotal.Visible = false;
            }
            else
            {
                GrandTotalQty();
                label1.Visible = true;
                lblgettotal.Visible = true;
            }

           
        }

        public void Loadplatenumber()
        {

            xClass.fillComboBoxplatenumber(cbplatenumber, "load_comboboxcactive_platenumber", dSet);
            //cbplatenumber.SelectedIndex = -1;

        }

        public void GrandTotalQty()
        {
          


            int sum = 0;
            for (int i = 0; i < dgvshowQTYbag.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvshowQTYbag.Rows[i].Cells["mama"].Value);
            }



            lblgettotal.Text = sum.ToString();

            //lblgettotal.Text = tot.ToString("#,0.00");



        }


        public void showTheData()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select a.order_no , a.feed_code, a.feed_type,a.sack_bin,a.qty, a.uom,a.binnumber ,a.qty_received, a.production_date, a.move_id, a.warehouse, a.customer, a.address, a.account_title, a.production, a.bags,a.platenumber from [dbo].[transact_rdf_move_order] a where a.order_no='" + lblorder.Text + "' AND a.is_active='0'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvshowQTYbag.DataSource = dt;

            sql_con.Close();

            lblrecords.Text = dgvshowQTYbag.RowCount.ToString();

        }


        private void Feedcodetransactupdate()
        {
            
           dSets.Clear();
           dSets = objStorProc.sp_rdf_fg_feedcodetransaction(0, "", "", "", "", "", "","", transactdate.Text, "", txtorder.Text, "", "transactmoveorder");

        }

       private void Updatemo()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[transact_rdf_move_order]  SET is_active='1',transaction_type='MOVEORDER',qty_received='"+txtqty.Text+ "', transact_time='"+txtdateandtime.Text+ "', transact_date ='"+txtdatenow.Text+"', delivery_date='" + mfg_datePicker2.Text + "', customer='" + cboCustomer.Text + "', address='" + lbldata2.Text + "', platenumber='"+ cbplatenumber.Text + "' where order_no='" + lblorder.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
          dgvUpdateSource.DataSource = dt;

            sql_con.Close();


        }

        void UpdateWH()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[transact_rdf_move_order]  SET warehouse='"+cboWarehouse.Text+"', account_title='" + lbldata1.Text + "' where order_no='" + lblorder.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateSource.DataSource = dt;

            sql_con.Close();


        }



        private void dgvshowQTYbag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblorder_Click(object sender, EventArgs e)
        {

        }

        private void dgvshowQTYbag_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTransact_Click(object sender, EventArgs e)
        {
            //if(txtqty.Text.Trim() == string.Empty)
            //{
            //    FillQTY();
                
            //    txtqty.Focus();
            //    return;
            //}


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Transact the selected move Order ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                //Update();
                //showTheData();

                //textBox1.Text = "DONE";
                btnTransact.Visible = false;
                panel2.Visible = true;
                //SaveSuccessFull();
                //this.Close();
            }
            else
            {

                return;
            }


        }


        void showProdId()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "select b.fg_feed_code,prod_adv,SUM(case when b.fg_options = 'Bagging' then 1 else 0 end) AS BagsCount, SUM(b.actual_weight) AS BulkCount from rdf_repackin_finishgoods b where fg_feed_code = '" + cboFeedCode.Text + "' AND b.fg_proddate = '" + cboProddate.Text + "' AND b.fg_options='" + cmbBagorSack.Text + "' GROUP BY b.fg_feed_code,b.prod_adv";
            //string sqlquery = "select b.fg_feed_code,prod_adv,c.move_order_qty,SUM(case when b.fg_options = 'Bagging' and b.status ='Good' then 1 else 0 end) AS BagsCount, SUM(c.bulkentry_total) AS BulkCount,c.fg_bags from rdf_repackin_finishgoods b LEFT JOIN rdf_finish_goods c ON b.prod_adv=c.fg_prod_id where b.fg_feed_code = '" + lblfeedcode.Text + "' AND b.fg_proddate = '" + lblproddate.Text + "' AND b.fg_options='" + lblbagorsack.Text + "' GROUP BY b.fg_feed_code,b.prod_adv,c.move_order_qty,c.fg_bags";

            string sqlquery = "select b.fg_feed_code,prod_adv,c.move_order_qty,SUM(case when b.fg_options = 'Bagging' and b.status ='Good' then 1 else 0 end) AS BagsCount, SUM(b.fg_actual_print_count) AS BulkCount,b.fg_bags from rdf_repackin_finishgoods b LEFT JOIN rdf_production_advance c ON b.prod_adv=c.prod_id where b.fg_feed_code = '" + lblfeedcode.Text + "' AND b.printing_date = '" + lblproddate.Text + "' AND b.fg_options='" + lblbagorsack.Text + "' GROUP BY b.fg_feed_code,b.prod_adv,c.move_order_qty,b.fg_bags";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvshowinventory.DataSource = dt;

            sql_con.Close();

        }

        private void dgvshowQTYbag_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvshowQTYbag.CurrentRow != null)
            {
                if (dgvshowQTYbag.CurrentRow.Cells["move_id"].Value != null)
                {
                    lblid.Text = dgvshowQTYbag.CurrentRow.Cells["move_id"].Value.ToString();
                 txtqty.Text = dgvshowQTYbag.CurrentRow.Cells["qty_received"].Value.ToString();
               lblqty.Text = dgvshowQTYbag.CurrentRow.Cells["mama"].Value.ToString();

                    txtactualqty.Text = dgvshowQTYbag.CurrentRow.Cells["mama"].Value.ToString();

                 lblfeedcode.Text = dgvshowQTYbag.CurrentRow.Cells["feed_code"].Value.ToString();
                    lblproddate.Text = dgvshowQTYbag.CurrentRow.Cells["production_date"].Value.ToString();
                    lblbagorsack.Text = dgvshowQTYbag.CurrentRow.Cells["sack_bin"].Value.ToString();

                   lblprodid.Text = dgvshowQTYbag.CurrentRow.Cells["production"].Value.ToString();

                    lblfginventory.Text = dgvshowQTYbag.CurrentRow.Cells["bags"].Value.ToString();


                    cboWarehouse.Text = dgvshowQTYbag.CurrentRow.Cells["warehouse"].Value.ToString();
                    cboCustomer.Text = dgvshowQTYbag.CurrentRow.Cells["customer"].Value.ToString();
                    cbplatenumber.Text = dgvshowQTYbag.CurrentRow.Cells["platenumber"].Value.ToString();
                }
            }
            txtinput.Text = "";
            showProdId();
            dgvshowinventory_CurrentCellChanged(sender,e);
            txtinput_TextChanged(sender, e);

        }


        public void SaveSuccessFull()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Transaction Successfully Approved";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

      

        public void SaveSuccessFullWH()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Warehouse Information Updated Successfully";

            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);

            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

       
        private void dgvshowQTYbag_DoubleClick(object sender, EventArgs e)
        {
       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

        private void btnHIDE_Click(object sender, EventArgs e)
        {

        }

        void loadCustomer()
        {
            ready = false;

            xClass.fillComboBoxWH(cboCustomer, "rdf_customer", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;
        }
        void loadWarehouse()
        {
            ready = false;

            xClass.fillComboBoxWH(cboWarehouse, "rdf_warehouse", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;

        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbldata1.Text = cboWarehouse.SelectedValue.ToString();
            lbldata1.Visible = true;

            if (lblbase.Text == "1")
            {

                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Warehouse Information ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    UpdateWH();
                    showTheData();

                    SaveSuccessFullWH();

                }
                else
                {

                  //  return;
                }










            }
            else
            {


            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbldata2.Text = cboCustomer.SelectedValue.ToString();
            lbldata2.Visible = true;


        }

        private void dgvshowinventory_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgvshowinventory.CurrentRow != null)
            {
                if (dgvshowinventory.CurrentRow.Cells["fg_feed_code"].Value != null)
                {
             
                    lblfginventory.Text = dgvshowinventory.CurrentRow.Cells["BagsCount"].Value.ToString();

                    txtmoveorder.Text = dgvshowinventory.CurrentRow.Cells["move_order_qty"].Value.ToString();
                    if (lblbagorsack.Text == "BULK ENTRY")
                    {
                       lblfginventory.Text = dgvshowinventory.CurrentRow.Cells["BulkCount"].Value.ToString();


                    }


                }
            }

        }

        private void lblfginventory_Click(object sender, EventArgs e)
        {

        }

        private void txtactualqty_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void lblavailable_Click(object sender, EventArgs e)
        {

        }

        private void txtmoveorder_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
           
        }
       
        private void txtdateandtime_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click_1(object sender, EventArgs e)
        {

        }

        private void txtinput_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void lblsubtract_Click(object sender, EventArgs e)
        {

        }

        private void lblbagorsack_Click(object sender, EventArgs e)
        {

        }

        private void cboWarehouse_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cboWarehouse_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void cboWarehouse_Click(object sender, EventArgs e)
        {
           
        }

        private void cboCustomer_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
            frmShowOrder_Load(sender, e);
        }

        private void lblcancel_Click(object sender, EventArgs e)
        {

        }

      

        private void lbldate_Click(object sender, EventArgs e)
        {

        }

      

        private void btnCancel_Click(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Transact the selected move Order ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

               Feedcodetransactupdate();
                Updatemo();
        

                textBox1.Text = "DONE";
            
                SaveSuccessFull();
                this.Close();
            }
            else
            {

                btnTransact.Visible = true;
                panel2.Visible = false;
            }

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void mfg_datePicker2_DropDown(object sender, EventArgs e)
        {
            bunifuThinButton21.Visible = true;
        }

        private void cboCustomer_SelectedValueChanged(object sender, EventArgs e)
        {


            lbldata2.Text = cboCustomer.SelectedValue.ToString();
            lbldata2.Visible = true;
           
        }

        private void lblorder_TextChanged(object sender, EventArgs e)
        {
            txtorder.Text = lblorder.Text;
        }
    }
}

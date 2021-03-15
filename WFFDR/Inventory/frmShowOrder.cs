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

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();

        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();


        private const int BaudRate = 9600;
        int sec;
        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;
        int p_id = 0;
        int s_id = 0;
        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();

        string Rpt_Path = "";

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
      

            lblorder.Text = Order_no;
            lblencodedby.Text = encoder;
            lbltotalqty.Text = qty;
            lbldate.Text = date;

            showTheData();

            txtdateandtime.Text = DateTime.Now.ToString();

            txtdatenow.Text = (DateTime.Now.ToString("M/d/yyyy"));

            lblcanceldate.Text = (DateTime.Now.ToString("M/d/yyyy"));

            loadCustomer();
            loadWarehouse();
            cboWarehouse_SelectedIndexChanged(sender, e);

            cboCustomer_SelectedIndexChanged(sender, e);
            txtinput.Text = "";
            txtinput_TextChanged(sender, e);
            textBox1.Text = "";
            this.BringToFront();
            btnTransact.Visible = true;

            lblcancelby.Text = userinfo.emp_name.ToUpper();
            if(lblrecords.Text=="0")
            {
                GrandTotalQty();
                label1.Visible = false;
                lblgettotal.Visible = false;
            }
            else
            {
                label1.Visible = true;
                lblgettotal.Visible = true;
            }
        }

        public void GrandTotalQty()
        {
            decimal tot = 0;

            for (int i = 0; i < dgvshowQTYbag.RowCount - 0; i++)
            {
                var value = dgvshowQTYbag.Rows[i].Cells["qty"].Value;
                if (value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if (tot == 0)
            {

            }

           lblgettotal.Text = tot.ToString("#,0.00");



        }


        public void showTheData()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "select a.order_no , a.feed_code, a.feed_type, a.qty, a.uom, a.qty_received, a.sack_bin, a.production_date, a.move_id, a.warehouse, a.customer, a.address, a.account_title, a.production, a.bags from [dbo].[transact_rdf_move_order] a where a.order_no='" + lblorder.Text + "' AND NOT a.is_active IS NOT NULL";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvshowQTYbag.DataSource = dt;

            sql_con.Close();

            lblrecords.Text = dgvshowQTYbag.RowCount.ToString();

        }


        void Update()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[transact_rdf_move_order]  SET is_active='1', qty_received='"+txtqty.Text+ "', transact_time='"+txtdateandtime.Text+ "', transact_date ='"+txtdatenow.Text+"', delivery_date='"+ mfg_datePicker2.Text + "' where order_no='" + lblorder.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
          dgvUpdateSource.DataSource = dt;

            sql_con.Close();


        }


        void UpdateData()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[transact_rdf_move_order]  SET qty='"+txtinput.Text+"' where move_id='" + lblid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateSource.DataSource = dt;

            sql_con.Close();


        }


        void UpdateData2()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_finish_goods]  SET move_order_qty='"+lbltotalmoveorder.Text+ "', last_qty_input='" + txtactualqty.Text + "', actual_available='"+lblsubtract.Text+"' where fg_prod_id='" + lblprodid.Text + "'";

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

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
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


        void UpdateCustomer()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[transact_rdf_move_order]  SET customer='" + cboCustomer.Text + "', address='" + lbldata2.Text + "' where order_no='" + lblorder.Text + "'";

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {
                    }

        private void label11_Click(object sender, EventArgs e)
        {                    }

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

        void UpdateDataCancel()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_production_advance]  SET move_order_qty='" + lblcancel.Text + "', last_qty_input='" + txtactualqty.Text + "', actual_available='" + lblcancel.Text + "' where prod_id='" + lblprodid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateSource.DataSource = dt;

            sql_con.Close();


        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            lblfginventory.Text = dgvshowQTYbag.CurrentRow.Cells["bags"].Value.ToString();


            if (txtmoveorder.Text.Trim() == string.Empty)
            {
                lblavailable.Text = "";
              lblavailable.Text = (float.Parse(lblfginventory.Text) - float.Parse(txtactualqty.Text)).ToString();

                lblcancel.Text = (float.Parse(lblavailable.Text) - float.Parse(txtactualqty.Text)).ToString();
            }
            else
            {


                lblcancel.Text = (float.Parse(txtmoveorder.Text) - float.Parse(txtactualqty.Text)).ToString();
            }
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel the Selected Move Order ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                UpdateDataCancel();
                UpdateDataPerItem();
                CancelSuccessFull();
                textBox1.Text = "CANCELLED";
                frmShowOrder_Load(sender, e);


            }
            else
            {

                return;
            }




            }


        void UpdateDataPerItem()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[transact_rdf_move_order]  SET is_active='1',cancel_by='" + lblcancelby.Text + "', cancel_date='" + lblcanceldate.Text + "', last_row_count='"+lblrecords.Text+"'  where move_id='" + lblid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateSource.DataSource = dt;

            sql_con.Close();


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
                }
            }
            txtinput.Text = "";
            showProdId();
            dgvshowinventory_CurrentCellChanged(sender,e);
            txtinput_TextChanged(sender, e);

        }

        public void FillQTY()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Fill up the required Field";

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

        public void CancelSuccessFull()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Transaction Successfully Cancelled";

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

        public void SaveSuccessFullCustomer()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Customer Information Updated Successfully";

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
            //panel1.BringToFront();
            //panel1.Visible = true;

            btnTransact.Visible = true;
            btnCancel.Visible = true;

            showProdId();

        lblavailable.Text = (float.Parse(lblfginventory.Text) - float.Parse(txtmoveorder.Text)).ToString();

      //      frmTransactMoveOrderQtyUpdate shower = new frmTransactMoveOrderQtyUpdate(lblprodid.Text, lblorder.Text, lblencodedby.Text, txtactualqty.Text,txtinput.Text);
       ///     shower.Show();


            new frmTransactMoveOrderQtyUpdate(this, lblprodid.Text, lblorder.Text, lblencodedby.Text, txtactualqty.Text, txtinput.Text, lblfginventory.Text, lblavailable.Text, lblsubtract.Text, txtmoveorder.Text, lblactual.Text, lbladdition.Text, lbltotalmoveorder.Text, lblid.Text).Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
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

            if (lblbase2.Text == "1")
            {

                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Update the Customer Information ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    UpdateCustomer();
                    showTheData();

                    SaveSuccessFullCustomer();

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
            if(txtinput.Text.Trim() == string.Empty)
            {
                InvalidQuantity();
                txtinput.Text = "";
                txtinput.Focus();
                return;
            }

            if(txtinput.Text=="0")
            {
                InvalidQuantity();
                txtinput.Text = "";
                txtinput.Focus();
                return;
            }

            if (lblsubtract.Text.StartsWith("-"))
            {
                //MessageBox.Show("Error");
                QtyOver();
                txtinput.BackColor = Color.Yellow;
               txtinput.Focus();
                return;
            }

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Upate the Quantity ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                UpdateData();
                UpdateData2();
                    showTheData();
                showProdId();
                dgvshowinventory_CurrentCellChanged(sender, e);

                SaveSuccessFull();
                frmShowOrder_Load(sender, e);

            }
            else
            {

                return;
            }









        }
        public void QtyOver()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "out of stock!";

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


        public void InvalidQuantity()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Invalid Quantity!";

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

        private void txtdateandtime_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click_1(object sender, EventArgs e)
        {

        }

        private void txtinput_TextChanged(object sender, EventArgs e)
        {
            if (lblfginventory.Text.Trim() == string.Empty)
            {
            }
            else
            {
                if (txtmoveorder.Text.Trim() == string.Empty)
                {
                    lblavailable.Text = (float.Parse(lblfginventory.Text) - float.Parse(txtactualqty.Text)).ToString();
                    lblsubtract.Text = (float.Parse(txtinput.Text) - float.Parse(lblfginventory.Text)).ToString();
                }
                else
                {
                    lblavailable.Text = (float.Parse(lblfginventory.Text) - float.Parse(txtmoveorder.Text)).ToString();


                    if (txtinput.Text.Trim() == string.Empty)
                    {

                        lblactual.Text = "0";
                        lblsubtract.Text = "0";
                        //lbltotalmoveorder.Text = "0";

                        //show the move order here
                        dgvshowinventory_CurrentCellChanged(sender, e);

                       // txtmoveorder.Text = dgvshowinventory.CurrentRow.Cells["move_order_qty"].Value.ToString();
                    }
                    else
                    {



                        lbladdition.Text = (float.Parse(txtactualqty.Text) + float.Parse(lblavailable.Text)).ToString();
                        lblsubtract.Text = (float.Parse(lbladdition.Text) - float.Parse(txtinput.Text)).ToString();
                       lblactual.Text = (float.Parse(txtinput.Text) - float.Parse(txtactualqty.Text)).ToString();

                        lbltotalmoveorder.Text = (float.Parse(txtmoveorder.Text) + float.Parse(lblactual.Text)).ToString();
                    }


                }

            }
        }

        private void lblsubtract_Click(object sender, EventArgs e)
        {

        }

        private void lblsample_Click(object sender, EventArgs e)
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
            lblbase.Text = "1";
        }

        private void cboCustomer_Click(object sender, EventArgs e)
        {
            lblbase2.Text = "1";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
            frmShowOrder_Load(sender, e);
        }

        private void lblcancel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_2(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Transact the selected move Order ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                Update();
                showTheData();

                textBox1.Text = "DONE";
                //btnTransact.Visible = false;
                //panel2.Visible = true;
                SaveSuccessFull();
                this.Close();
            }
            else
            {

                btnTransact.Visible = true;
                panel2.Visible = false;
            }

        }

        private void mfg_datePicker2_ValueChanged(object sender, EventArgs e)
        {
            bunifuThinButton21.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbldate_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblfginventory.Text = dgvshowQTYbag.CurrentRow.Cells["bags"].Value.ToString();


            if (txtmoveorder.Text.Trim() == string.Empty)
            {
                lblavailable.Text = "";
                lblavailable.Text = (float.Parse(lblfginventory.Text) - float.Parse(txtactualqty.Text)).ToString();

                lblcancel.Text = (float.Parse(lblavailable.Text) - float.Parse(txtactualqty.Text)).ToString();
            }
            else
            {


                lblcancel.Text = (float.Parse(txtmoveorder.Text) - float.Parse(txtactualqty.Text)).ToString();
            }
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Cancel the Selected Move Order ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                UpdateDataCancel();
                UpdateDataPerItem();
                CancelSuccessFull();
                textBox1.Text = "CANCELLED";
                frmShowOrder_Load(sender, e);


            }
            else
            {

                return;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Transact the selected move Order ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                Update();
                showTheData();

                textBox1.Text = "DONE";
                //btnTransact.Visible = false;
                //panel2.Visible = true;
                SaveSuccessFull();
                this.Close();
            }
            else
            {

                btnTransact.Visible = true;
                panel2.Visible = false;
            }

        }
    }
}

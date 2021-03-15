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
    public partial class frmMoveOrder : Form
    {


        string mode = ""; //mymode
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
   
        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;
        int p_id = 0;
   
        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();

        string Rpt_Path = "";

        //user rights class
        int rights_id = 0;
        int emp_flag = 0;

        public frmMoveOrder()
        {
            InitializeComponent();

        }

        private void frmMoveOrder_Load(object sender, EventArgs e)
        {

            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadWarehouse();
            loadCustomer();
            loadFeedCode();
        
            lbldateandtime.Text = DateTime.Now.ToString();
   lblcanceldate.Text = (DateTime.Now.ToString("M/d/yyyy"));
            lbluseractive.Text = userinfo.emp_name.ToUpper();
            lbldata1.Visible = false;
            lbldata2.Visible = false;
            //  lblFeedType.Visible = false;
            lblFeedType.Text = "";
            cmbBagorSack.Text = "";
            BindData();
            txtdatenow.Text = (DateTime.Now.ToString("M/d/yyyy"));
            load_Schedules();
            cboWarehouse_SelectedIndexChanged(sender, e);
            cboCustomer_SelectedIndexChanged(sender, e);
            textBox1.Text = "";
            if(lblrecords.Text=="0")
            {
                load_transactions_count();
                dgvApproved.Visible = false;
                btnCancel.Enabled = false;
            }
            else
            {
                btnCancel.Enabled = true;
                dgvApproved.Visible = true;
            }
            cboUOM.Text = "BAG";


            if(lblrecords.Text=="0")
            {
                cboCustomer.Enabled = true;
                cboWarehouse.Enabled = true;
              btnSave.Visible = false;
                ControlBox = true;
            }
            else
            {
                cboCustomer.Enabled = false;
                cboWarehouse.Enabled = false;
                btnSave.Visible = true;
                //ControlBox = false;
            }

            this.BringToFront();

            }

        public void load_Schedules()
        {
            string mcolumns = "test,feed_code.feed_type,qty,uom,qty_received,sack_bin,production_date,order_no";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvApproved, mcolumns, "move_order");
            lblrecords.Text = dgvApproved.RowCount.ToString();

        }
        public void load_transactions_count()
        {
            string mcolumns = "test,feed_code.feed_type,qty,uom,qty_received,sack_bin,production_date,order_no";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvTransactions, mcolumns, "transaction_order_count");
            txtorder.Text = dgvTransactions.RowCount.ToString();

        }



        public void BindData()
        {
            String cone = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection con = new SqlConnection(cone);

            con.Open();
            string strCmd = "select a.fg_proddate,SUM(case when a.fg_options = 'Bagging' and a.status='Good' then 1 else 0 end) AS BagsCount, SUM(c.bulkentry_total) as BulkCount from rdf_repackin_finishgoods a  LEFT JOIN rdf_finish_goods c ON a.prod_adv=c.fg_prod_id LEFT JOIN rdf_production_advance main ON a.prod_adv=main.prod_id    WHERE a.fg_feed_code ='" + cboFeedCode.Text+"' AND a.fg_options='"+cmbBagorSack.Text+ "'  AND main.fg_date_finish IS NOT NULL AND NOT c.move_status IS NOT NULL GROUP BY a.fg_proddate ORDER BY a.fg_proddate DESC";

            //string strCmd = " select a.fg_proddate,SUM(case when a.fg_options = 'Bagging' then 1 else 0 end) AS BagsCount, SUM(a.actual_weight) as BulkCount from rdf_repackin_finishgoods a WHERE fg_feed_code ='" + cboFeedCode.Text + "' GROUP BY a.fg_proddate";



            //string strCmd = "select a.proddate,SUM(case when b.fg_options = 'Bagging' then 1 else 0 end) AS BagsCount from rdf_production_advance a LEFT JOIN rdf_repackin_finishgoods b ON a.p_feed_code=b.fg_feed_code WHERE p_feed_code ='" + cboFeedCode.Text + "'  AND a.is_selected='1'  AND NOT a.canceltheapprove IS NOT NULL GROUP BY a.proddate";

            SqlCommand cmd = new SqlCommand(strCmd, con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
         cboProddate.DataSource = ds.Tables[0];
            cboProddate.DisplayMember = "fg_proddate";
            cboProddate.ValueMember = "BagsCount";
      //      cboProddate.Enabled = true;
           // this.cboProddate.SelectedIndex = -1;
            cmd.ExecuteNonQuery();
            con.Close();
            showProdId();
            //lblprodid.Text = cboProddate.SelectedValue.ToString();

        }


        void Insertdata()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

  
            SqlConnection sql_con = new SqlConnection(connetionString);

   
            string sqlquery = "INSERT INTO [dbo].[transact_rdf_move_order] (order_no,date_time,warehouse,account_title,customer,address,feed_code,feed_type,sack_bin,production_date,qty,uom,qty_received,available,grand_total,production,added_by,date_added,bags) SELECT order_no,date_time,warehouse,account_title,customer,address,feed_code,feed_type,sack_bin,production_date,qty,uom,qty_received,available,grand_total,production,added_by,date_added,bags FROM [dbo].[rdf_move_order] where status='1'";

        
            
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
        dgvInserting.DataSource = dt;

            sql_con.Close();

        }


        void UpdateFG()
        {


            if (txtstockonhand.Text == "0")
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);

                string sqlquery = "UPDATE [dbo].[rdf_finish_goods] set move_order_qty='" + txtmoveorder.Text + "', actual_available ='" + txtstockonhand.Text + "', last_qty_input='" + txtqty.Text + "',move_status='1' where fg_prod_id='" + lblproductionid.Text + "'";

                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvOutFG.DataSource = dt;

                sql_con.Close();

            }

            else
            {
                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);


                string sqlquery = "UPDATE [dbo].[rdf_finish_goods] set move_order_qty='" + txtmoveorder.Text + "', actual_available ='" + txtstockonhand.Text + "', last_qty_input='" + txtqty.Text + "' where fg_prod_id='" + lblproductionid.Text + "' ";
                sql_con.Open();
                SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
                SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dgvOutFG.DataSource = dt;

                sql_con.Close();

            }




        }


        void OutMoveOrder()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_move_order] set status='0'";



            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvInserting.DataSource = dt;

            sql_con.Close();
        }


        void showProdId()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "select b.fg_feed_code,prod_adv,SUM(case when b.fg_options = 'Bagging' then 1 else 0 end) AS BagsCount, SUM(b.actual_weight) AS BulkCount from rdf_repackin_finishgoods b where fg_feed_code = '" + cboFeedCode.Text + "' AND b.fg_proddate = '" + cboProddate.Text + "' AND b.fg_options='" + cmbBagorSack.Text + "' GROUP BY b.fg_feed_code,b.prod_adv";

            string sqlquery = "select b.fg_feed_code,prod_adv,c.move_order_qty,SUM(case when b.fg_options = 'Bagging' and b.status ='Good' then 1 else 0 end) AS BagsCount, SUM(c.bulkentry_total) AS BulkCount,c.fg_bags from rdf_repackin_finishgoods b LEFT JOIN rdf_finish_goods c ON b.prod_adv=c.fg_prod_id where b.fg_feed_code = '" + cboFeedCode.Text+"' AND b.fg_proddate = '"+cboProddate.Text+"' AND b.fg_options='"+cmbBagorSack.Text+ "' GROUP BY b.fg_feed_code,b.prod_adv,c.move_order_qty,c.fg_bags";

            //string sqlquery = "select b.fg_feed_code,SUM(case when b.fg_options = 'Bagging' then 1 else 0 end) AS BagsCount, SUM(b.actual_weight) AS BulkCount from rdf_repackin_finishgoods b  LEFT JOIN rdf_production_advance x ON b.fg_feed_code=x.p_feed_code where fg_feed_code='" + cboFeedCode.Text+"' AND b.fg_proddate='"+cboProddate.Text+ "'  AND x.is_selected='1'  AND NOT x.canceltheapprove IS NOT NULL AND b.fg_options='"+ cmbBagorSack.Text + "'  GROUP BY b.fg_feed_code";
            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvshowQTYbag.DataSource = dt;

            sql_con.Close();

        }

        void loadFeedCode()
        {
            ready = false;

            xClass.fillComboBoxWH(cboFeedCode, "feed_code_productionschedule2", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;

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
            //if (ready == true)
            //{
                //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));
                lbldata1.Text = cboWarehouse.SelectedValue.ToString();
            lbldata1.Visible = true;
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbldata2.Text = cboCustomer.SelectedValue.ToString();
            lbldata2.Visible = true;
        }

        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFeedType.Text = cboFeedCode.SelectedValue.ToString();
            lblFeedType.Visible = true;
            BindData();

        }

        private void cboProddate_SelectedValueChanged(object sender, EventArgs e)
        {
            txtqty.Text = "";
            // BindData();
            showProdId();

            //txtstockonhand.Text = "0";


            dgvshowQTYbag_CurrentCellChanged(sender,e);


            txtqty.Focus();
        }

        private void cboProddate_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void dgvshowQTYbag_CurrentCellChanged(object sender, EventArgs e)
        {
            txtstock.Text = "0";
            if (dgvshowQTYbag.CurrentRow != null)
            {
                if (dgvshowQTYbag.CurrentRow.Cells["fg_feed_code"].Value != null)
                {
                  lblfeed_code.Text = dgvshowQTYbag.CurrentRow.Cells["fg_feed_code"].Value.ToString();
                    txtstock.Text = dgvshowQTYbag.CurrentRow.Cells["BagsCount"].Value.ToString();
                    lblproductionid.Text = dgvshowQTYbag.CurrentRow.Cells["prod_adv"].Value.ToString();
lblbags.Text = dgvshowQTYbag.CurrentRow.Cells["fg_bags"].Value.ToString();
                    txtmoveorder.Text = dgvshowQTYbag.CurrentRow.Cells["move_order_qty"].Value.ToString();
                    if (cmbBagorSack.Text=="BULK ENTRY")
                    {
                        txtstock.Text = dgvshowQTYbag.CurrentRow.Cells["BulkCount"].Value.ToString();

                        //txtstock.Text = (float.Parse(txtstock.Text) / 50).ToString();
                    }
                

                }
            }


        }

        public void FillFeedType()
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

        public void InvalidQTY()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Invalid Quantity Input !";

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


        public void Success()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Successfully insert a new MoveOrder";

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



        public void SaveSuccess()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Move Order Transactions Successfully save";

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




        private void cmbBagorSack_SelectedValueChanged(object sender, EventArgs e)
        {
            BindData();
            showProdId();
  
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {

            if(txtstockonhand.Text.StartsWith("-"))
            {
                txtqty.BackColor = Color.Yellow;
            }
            else
            {

                txtqty.BackColor = Color.White;
            }

            if (txtqty.Text.Trim() == string.Empty)
            {
                txtstockonhand.Text = "";
                dgvshowQTYbag_CurrentCellChanged(sender, e);
            }
            else
            {

                if (txtstock.Text.Trim() == string.Empty)
                {
                    dgvshowQTYbag_CurrentCellChanged(sender, e);
                }
                else
                {


                    if (txtmoveorder.Text.Trim() == string.Empty)
                    {
             
                        txtstockonhand.Text = (float.Parse(txtstock.Text) - float.Parse(txtqty.Text)).ToString();

                    }
                    else
                    {


                        //txtstock.Text = (float.Parse(txtstock.Text) - float.Parse(txtmoveorder.Text)).ToString();

                        txtstockonhand.Text = (float.Parse(txtstock.Text) - float.Parse(txtmoveorder.Text)).ToString();


                    }

                    //if (txtstockonhand.Text.Trim() == string.Empty)
                    //{

                        if (txtmoveorder.Text.Trim() == string.Empty)
                    {


                    }
                    else
                    {

                        txtstockonhand.Text = (float.Parse(txtstockonhand.Text) - float.Parse(txtqty.Text)).ToString();

                    }




                }
            }
            
            
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {




            //if (txtqty.Text == "0")
            //{

            //    InvalidQTY();
            //    txtqty.Text = "";
            //}

            //if (lblFeedType.Text.Trim() == string.Empty)
            //{

            //    FillFeedType();
            //    lblFeedType.Focus();
            //    return;
            //}

            //if (cboProddate.Text.Trim() == string.Empty)
            //{

            //    FillFeedType();
            //    cboProddate.Focus();
            //    return;
            //}


            //if (cmbBagorSack.Text.Trim() == string.Empty)
            //{

            //    FillFeedType();
            //    cmbBagorSack.Focus();
            //    return;
            //}

            //if (txtqty.Text.Trim() == string.Empty)
            //{

            //    FillFeedType();
            //    txtqty.Focus();
            //    return;
            //}

            ////if (lbldata1.Text=="")
            ////{

            ////    FillFeedType();
            ////    lbldata1.Focus();
            ////    return;
            ////}

            ////if (lbldata2.Text=="")
            ////{

            ////    FillFeedType();
            ////    lbldata2.Focus();
            ////    return;
            ////}

            //if (cboUOM.Text.Trim() == string.Empty)
            //{

            //    FillFeedType();
            //    cboUOM.Focus();
            //    return;
            //}

            //if (txtstockonhand.Text.StartsWith("-"))
            //{
            //    //MessageBox.Show("Error");
            //    QtyOver();
            //    txtqty.BackColor = Color.Yellow;
            //    txtqty.Focus();
            //    return;
            //}

            frmAddnewMoveOrder shower = new frmAddnewMoveOrder(cboFeedCode.Text, lblFeedType.Text, cmbBagorSack.Text, cboProddate.Text, txtqty.Text, cboUOM.Text,this,cboWarehouse.Text,cboCustomer.Text,lbldata1.Text,lbldata2.Text);
            shower.Show();

            btnInsert.Visible = false;

            return;


            //if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{

            //    if (txtmoveorder.Text.Trim() == string.Empty)
            //    {

            //        //txtstockonhand.Text = (float.Parse(txtstock.Text) - float.Parse(txtqty.Text)).ToString();
            //        if (cmbBagorSack.Text == "BULK ENTRY")
            //        {

            //            txtmoveorder.Text = (float.Parse(txtqty.Text) * 1).ToString();

            //        }
            //    }
            //    else
            //    {


            //        txtmoveorder.Text = (float.Parse(txtmoveorder.Text) + float.Parse(txtqty.Text)).ToString();



            //    }




            //    mode = "add";





            //    UpdateFG();

            //    if (saveMode())
            //    {

            //        string tmode = mode;

            //        if (tmode == "add")
            //        {


            //            //AddedSuccess();
            //            //bunifuThinButton29_Click(sender, e);
            //            //btnfinishvalidation_Click(sender, e); ///dito muna ang minus querys
            //            //Clear();
            //            //load_Schedules_approved();
            //            //load_Schedules();



            //        }
            //        else
            //        {

            //        }

            //        /// btnCancel_Click(sender, e);

            //    }
            //    else
            //    {
            //        //MessageBox.Show("Failed");
            //    }







            //}
            //else
            //{

            //    return;
            //}



            //txtqty.Text = "";
            //txtstockonhand.Text = "";
            //Success();










            //    frmMoveOrder_Load(sender, e);

        }





        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text, cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim(), lbldata2.Text.Trim(), lblfeed_code.Text.Trim(), lblFeedType.Text.Trim(), cmbBagorSack.Text.Trim(), cboProddate.Text.Trim(), txtqty.Text.Trim(), cboUOM.Text.Trim(), txtqtyreceived.Text.Trim(), txtstockonhand.Text.Trim(), txtstock.Text.Trim(), lblproductionid.Text.Trim(), lbluseractive.Text.Trim(), txtdatenow.Text, Convert.ToInt32(lblbags.Text), "add");


                //dSet.Clear();
                //dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, lbldata1.Text, "", "", "", "", "", "", "", "getbyname");

                //if (dSet.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show("Duplicate Entry", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cboFeedCode.Focus();
                //    return false;
                //}
                //else
                //{
                //    //tae
                //    dSet.Clear();
                //    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text, cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim(), lbldata2.Text.Trim(), lblfeed_code.Text.Trim(), lblFeedType.Text.Trim(), cmbBagorSack.Text.Trim(), cboProddate.Text.Trim(), txtqty.Text.Trim(), cboUOM.Text.Trim(), txtqtyreceived.Text.Trim(), txtstockonhand.Text.Trim(), txtstock.Text.Trim(), lblprodid.Text.Trim(), lbluseractive.Text.Trim(), txtdatenow.Text, "add");

                //    return true;
                //}
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_supplier(p_id, "", "", "", "", "delete");

                //dSet_temp.Clear();
                //dSet_temp = objStorProc.sp_positions(p_id,0,"","delete");

                return true;
            }
            return false;
        }




        private void dgvshowQTYbag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvApproved_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboFeedCode_SelectedValueChanged(object sender, EventArgs e)
        {

            if (lblFeedType.Text.Trim() == string.Empty)
            {

            }
            else
            {
                cmbBagorSack.Enabled = true;
            }
        }

        private void dgvApproved_CurrentCellChanged(object sender, EventArgs e)
        {


 
            if (dgvApproved.CurrentRow != null)
            {
                if (dgvApproved.CurrentRow.Cells["order_no"].Value != null)
                {
                  txtorder.Text = dgvApproved.CurrentRow.Cells["order_no"].Value.ToString();

                 txtactualqty.Text = dgvApproved.CurrentRow.Cells["qty"].Value.ToString();
                 lblid.Text = dgvApproved.CurrentRow.Cells["move_id"].Value.ToString();

                    lblfginventory.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();

                    lblfeedcode.Text = dgvApproved.CurrentRow.Cells["feed_code"].Value.ToString();
                    lblproddate.Text = dgvApproved.CurrentRow.Cells["production_date"].Value.ToString();
                    lblbagorsack.Text = dgvApproved.CurrentRow.Cells["sack_bin"].Value.ToString();
           lblprodid.Text = dgvApproved.CurrentRow.Cells["production"].Value.ToString();
                }
            }


            Inventory();

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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Move Order ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {



                Insertdata();
                OutMoveOrder();
                SaveSuccess();
                bntPrint_Click(sender, e);
                frmMoveOrder_Load(sender, e);
            }

            else
            {

                return;
            }


        }

        private void txtmoveorder_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstockonhand_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntPrint_Click(object sender, EventArgs e)
        {

            myglobal.DATE_REPORT = txtorder.Text;
            //myglobal.DATE_REPORT2 = f2.Text;
            //myglobal.DATE_REPORT3 = lblmyfeedcode.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMoveOrder";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();









        }

        private void lblrecords_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dgvApproved_DoubleClick(object sender, EventArgs e)
        {
            Inventory();
            showProdId();

            //MessageBox.Show(txtmoveorder.Text);
            //return;
            lblavailable.Text = (float.Parse(lblfginventory.Text) - float.Parse(txtmoveorder.Text)).ToString();


            new frmUpdateMoveOrderModal(this, lblprodid.Text, txtorder.Text, lbluseractive.Text, txtactualqty.Text, txtinput.Text, lblfginventory.Text, lblavailable.Text, lblsubtract.Text, txtmoveorder.Text, lblactual.Text, lbladdition.Text, lbltotalmoveorder.Text, lblid.Text,lbldateandtime.Text).Show();



        }

        void Inventory()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);

            //string sqlquery = "select b.fg_feed_code,prod_adv,SUM(case when b.fg_options = 'Bagging' then 1 else 0 end) AS BagsCount, SUM(b.actual_weight) AS BulkCount from rdf_repackin_finishgoods b where fg_feed_code = '" + cboFeedCode.Text + "' AND b.fg_proddate = '" + cboProddate.Text + "' AND b.fg_options='" + cmbBagorSack.Text + "' GROUP BY b.fg_feed_code,b.prod_adv";

            string sqlquery = "select b.fg_feed_code,b.prod_adv,c.move_order_qty,SUM(case when b.fg_options = 'Bagging' and b.status ='Good' then 1 else 0 end) AS BagsCount, SUM(b.fg_actual_print_count) AS BulkCount,b.fg_bags from rdf_repackin_finishgoods b LEFT JOIN rdf_production_advance c ON b.prod_adv=c.prod_id where b.fg_feed_code = '" + lblfeedcode.Text + "' AND b.printing_date = '" + lblproddate.Text + "' AND b.fg_options='" + lblbagorsack.Text + "' GROUP BY b.fg_feed_code,b.prod_adv,c.move_order_qty,b.fg_bags";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvshowinventory.DataSource = dt;

            sql_con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    
            btnInsert.Visible = true;
            load_Schedules();
            frmMoveOrder_Load(sender, e);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddnewMoveOrder shower = new frmAddnewMoveOrder(cboFeedCode.Text, lblFeedType.Text, cmbBagorSack.Text, cboProddate.Text, txtqty.Text, cboUOM.Text, this, cboWarehouse.Text, cboCustomer.Text, lbldata1.Text, lbldata2.Text);
            shower.Show();

            btnInsert.Visible = false;

            return;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Move Order ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {



                Insertdata();
                OutMoveOrder();
                SaveSuccess();
                bntPrint_Click(sender, e);
                frmMoveOrder_Load(sender, e);
            }

            else
            {

                return;
            }

        }

        private void dgvshowinventory_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

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

        void UpdateDataPerItem()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            ////        String connetionString = @"Data Source=192.168.2.9\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=Nescafe3in1;MultipleActiveResultSets=true"
            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "UPDATE [dbo].[rdf_move_order]  SET status='0',cancel_by='" + lblcancelby.Text + "', cancel_date='" + lblcanceldate.Text + "', last_row_count='" + lblrecords.Text + "'  where move_id='" + lblid.Text + "'";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvUpdateSource.DataSource = dt;

            sql_con.Close();


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

        private void btnCancel_Click(object sender, EventArgs e)
        {

            lblfginventory.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();


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
                frmMoveOrder_Load(sender, e);


            }
            else
            {

                return;
            }






        }

        private void btnlessthan_Click(object sender, EventArgs e)
        {


            lblfginventory.Text = dgvApproved.CurrentRow.Cells["bags"].Value.ToString();


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
 

                UpdateDataCancel();
                UpdateDataPerItem();
                CancelSuccessFull();
                //textBox1.Text = "CANCELLED";
        








                if (dgvApproved.Rows.Count >= 1)
            {


                int i = dgvApproved.CurrentRow.Index + 1;
                if (i >= -1 && i < dgvApproved.Rows.Count)
                    dgvApproved.CurrentCell = dgvApproved.Rows[i].Cells[0];




                //dgvMaster_Click(sender,e);
                else
                {
                    //LastLine();
                    //MessageBox.Show("Last muna nyan  haha");

                    frmMoveOrder_Load(sender, e);


                    return;
                }



                button1_Click_1(sender, e);
        

                }














            }

        private void button1_Click_1(object sender, EventArgs e)
        {

            btnlessthan_Click(sender, e);
        }

        private void frmMoveOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblrecords.Text == "0")
            {

            }
            else
            {
                btnlessthan_Click(sender, e);
            }
        }
    }
}

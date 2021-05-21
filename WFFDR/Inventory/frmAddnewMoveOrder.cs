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
    public partial class frmAddnewMoveOrder : Form
    {
        //int rowindex;
        //int i;
        string mode = ""; //mymode
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        //DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        //DataSet dSet_temp = new DataSet();
        //DataSet dset_delete = new DataSet();

        DataSet dSet = new DataSet();
        //DataSet dset_rights = new DataSet();


        private const int BaudRate = 9600;
        //int sec;
        //DataSet dset_section = new DataSet();
        Boolean ready = false;

        //int p_id = 0;
 
        //weighing

        public myclasses classes = new myclasses();
        //myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        //DataSet dset2 = new DataSet();
        //DataSet dset3 = new DataSet();




        frmMoveOrder ths;
        public frmAddnewMoveOrder(string feedcode, string feedtype, string sackbin, string proddate, string qty, string uom,frmMoveOrder frm, string warehouse, string customer, string data1, string data2)
        {
            InitializeComponent();

            this.feedcode = feedcode;
            this.feedtype = feedtype;
            this.sackbin = sackbin;
            this.proddate = proddate;
            this.qty = qty;
            this.uom = uom;

            this.warehouse = warehouse;
            this.customer = customer;
            this.data1 = data1;
            this.data2 = data2;

            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);

        }
   public string feedcode { get; set; }
        public string feedtype { get; set; }
        public string sackbin { get; set; }
        public string proddate { get; set; }
        public string qty { get; set; }
        public string  uom { get; set; }

        public string warehouse { get; set; }
        public string customer { get; set; }
        public string data1 { get; set; }
        public string data2 { get; set; }

   

        private void frmAddnewMoveOrder_Load(object sender, EventArgs e)
        {

            cboWarehouse.Text = warehouse;
            cboCustomer.Text = customer;
            lbldata1.Text = data1;
            lbldata2.Text = data2;

            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadFeedCode();
            lblFeedType.Text = "";
            lbldateandtime.Text = DateTime.Now.ToString();
            txtdatenow.Text = (DateTime.Now.ToString("M/d/yyyy"));          
            lbluseractive.Text = userinfo.emp_name.ToUpper();
            cboUOM.Text = "BAG";

            load_transactions_count();
     
            }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        public void load_transactions_count()
        {
            string mcolumns = "test,feed_code.feed_type,qty,uom,qty_received,sack_bin,production_date,order_no";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvTransactions, mcolumns, "transaction_order_count");
            txtorder.Text = dgvTransactions.RowCount.ToString();

        }
        void loadFeedCode()
        {
            ready = false;

            xClass.fillComboBoxWH(cboFeedCode, "feed_code_productionschedule3", dSet);
           

            ready = true;

        }


        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txtstock_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFeedCode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lblFeedType.Text = cboFeedCode.SelectedValue.ToString();
            lblFeedType.Visible = true;
            BindData();
        }

        public void BindData()
        {
            String cone = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection con = new SqlConnection(cone);

            con.Open();
            string strCmd = "select a.received_date,SUM(case when a.fg_options = 'Bagging' and a.status='Good' then 1 else 0 end) AS BagsCount, SUM(c.bulkentry_total) as BulkCount from rdf_repackin_finishgoods a  LEFT JOIN rdf_finish_goods c ON a.prod_adv=c.fg_prod_id LEFT JOIN rdf_production_advance main ON a.prod_adv=main.prod_id    WHERE a.fg_feed_code ='"+cboFeedCode.Text+"' AND a.fg_options='"+cmbBagorSack.Text+ "' AND a.printing_date IS NOT NULL AND a.received_date IS NOT NULL AND NOT a.received_date='' GROUP BY a.received_date ORDER BY a.received_date DESC";

        
            SqlCommand cmd = new SqlCommand(strCmd, con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboProddate.DataSource = ds.Tables[0];
            cboProddate.DisplayMember = "received_date";
            cboProddate.ValueMember = "BagsCount";
            cmd.ExecuteNonQuery();
            con.Close();
            showProdId();

        }

        
        public void BagandBulBindData()
        {
            String cone = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection con = new SqlConnection(cone);

            con.Open();
            string strCmd = "select distinct fg_feed_code,fg_options from rdf_repackin_finishgoods where fg_feed_code='"+ cboFeedCode.Text + "' and printing_date is not null and received_date is not null and not received_date =''";

            SqlCommand cmd = new SqlCommand(strCmd, con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmbBagorSack.DataSource = ds.Tables[0];
            cmbBagorSack.DisplayMember = "fg_options";
            cmbBagorSack.ValueMember = "fg_options";
       
            cmd.ExecuteNonQuery();
            con.Close();


        }

        void showProdId()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";
            SqlConnection sql_con = new SqlConnection(connetionString);
            string sqlquery = "select b.fg_feed_code,b.prod_adv,x.move_order_qty,SUM(case when b.fg_options = 'Bagging' and b.status = 'Good' then 1 else 0 end) AS BagsCount, SUM(b.fg_actual_print_count) AS BulkCount, b.fg_bags,b.printing_date from rdf_repackin_finishgoods b LEFT JOIN rdf_production_advance x ON b.prod_adv = x.prod_id where b.fg_feed_code = '"+cboFeedCode.Text+"' AND b.received_date = '"+cboProddate.Text+"' AND b.fg_options = '"+cmbBagorSack.Text+ "' AND b.printing_date IS NOT NULL AND b.received_date IS NOT NULL GROUP BY b.fg_feed_code,b.prod_adv,x.move_order_qty,b.fg_bags,b.printing_date";

            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvshowQTYbag.DataSource = dt;

            sql_con.Close();




        }

        private void cmbBagorSack_SelectedValueChanged(object sender, EventArgs e)
        {
            cboProddate.Text = "";
            BindData();
            showProdId();


         
                if (cmbBagorSack.Text == "Bagging")
                {
                    int sum = 0;
                    for (int i = 0; i < dgvshowQTYbag.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvshowQTYbag.Rows[i].Cells[3].Value);
                    }
                    txtstock.Text = sum.ToString();
                }

                else
                {
                    int sum = 0;
                    for (int i = 0; i < dgvshowQTYbag.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvshowQTYbag.Rows[i].Cells[4].Value);
                    }
                    txtstock.Text = sum.ToString();


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


        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtqty.Text == "0")
            {

                InvalidQTY();
                txtqty.Text = "";
            }

            if (lblFeedType.Text.Trim() == string.Empty)
            {

                FillFeedType();
                lblFeedType.Focus();
                return;
            }

            if (cboProddate.Text.Trim() == string.Empty)
            {

                FillFeedType();
                cboProddate.Focus();
                return;
            }


            if (cmbBagorSack.Text.Trim() == string.Empty)
            {

                FillFeedType();
                cmbBagorSack.Focus();
                return;
            }

            if (txtqty.Text.Trim() == string.Empty)
            {

                FillFeedType();
                txtqty.Focus();
                return;
            }

         
            if (cboUOM.Text.Trim() == string.Empty)
            {

                FillFeedType();
                cboUOM.Focus();
                return;
            }

            if (txtstockonhand.Text.StartsWith("-"))
            {
                //MessageBox.Show("Error");
                QtyOver();
                txtqty.BackColor = Color.Yellow;
                txtqty.Focus();
                return;
            }


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtmoveorder.Text.Trim() == string.Empty)
                {

                    //txtstockonhand.Text = (float.Parse(txtstock.Text) - float.Parse(txtqty.Text)).ToString();
                    if (cmbBagorSack.Text == "BULK ENTRY")
                    {

                        txtmoveorder.Text = (float.Parse(txtqty.Text) * 1).ToString();

                    }
                }
                else
                {


                    txtmoveorder.Text = (float.Parse(txtmoveorder.Text) + float.Parse(txtqty.Text)).ToString();



                }




                mode = "add";





                UpdateFG();

                if (saveMode())
                {

                    string tmode = mode;

                    if (tmode == "add")
                    {


                        //AddedSuccess();
                        //bunifuThinButton29_Click(sender, e);
                        //btnfinishvalidation_Click(sender, e); ///dito muna ang minus querys
                        //Clear();
                        //load_Schedules_approved();
                        //load_Schedules();



                    }
                    else
                    {

                    }

                    /// btnCancel_Click(sender, e);

                }
                else
                {
                    //MessageBox.Show("Failed");
                }







            }
            else
            {

                return;
            }


            textBox1.Text = "Tapos";
            txtqty.Text = "";
            txtstockonhand.Text = "";
            Success();

            this.Close();




            //    frmMoveOrder_Load(sender, e);



        }


        public bool saveMode()
        {

            //if (mode == "add")
            //{
            //    dSet.Clear();
            //    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text, cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim(), lbldata2.Text.Trim(), lblfeed_code.Text.Trim(), lblFeedType.Text.Trim(), cmbBagorSack.Text.Trim(), cboProddate.Text.Trim(), txtqty.Text.Trim(), cboUOM.Text.Trim(), txtqtyreceived.Text.Trim(), txtstockonhand.Text.Trim(), txtstock.Text.Trim(), lblproductionid.Text.Trim(), lbluseractive.Text.Trim(), txtdatenow.Text,Convert.ToInt32(lblbags.Text),"","", "add");


            //    //dSet.Clear();
            //    //dSet = objStorProc.rdf_sp_prod_schedules(0, cboFeedCode.Text, lbldata1.Text, "", "", "", "", "", "", "", "getbyname");

            //    //if (dSet.Tables[0].Rows.Count > 0)
            //    //{
            //    //    MessageBox.Show("Duplicate Entry", "Offense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //    cboFeedCode.Focus();
            //    //    return false;
            //    //}
            //    //else
            //    //{
            //    //    //tae
            //    //    dSet.Clear();
            //    //    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text, cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim(), lbldata2.Text.Trim(), lblfeed_code.Text.Trim(), lblFeedType.Text.Trim(), cmbBagorSack.Text.Trim(), cboProddate.Text.Trim(), txtqty.Text.Trim(), cboUOM.Text.Trim(), txtqtyreceived.Text.Trim(), txtstockonhand.Text.Trim(), txtstock.Text.Trim(), lblprodid.Text.Trim(), lbluseractive.Text.Trim(), txtdatenow.Text, "add");

            //    //    return true;
            //    //}
            //}
            //else if (mode == "delete")
            //{
            //    dSet.Clear();
            //    dSet = objStorProc.rdf_sp_supplier(p_id, "", "", "", "", "delete");

            //    //dSet_temp.Clear();
            //    //dSet_temp = objStorProc.sp_positions(p_id,0,"","delete");

            //    return true;
            //}
            return false;
        }


        void UpdateFG()
        {


            if (txtstockonhand.Text == "0")
            {

                String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


                SqlConnection sql_con = new SqlConnection(connetionString);

                string sqlquery = "UPDATE [dbo].[rdf_production_advance] set move_order_qty='" + txtmoveorder.Text + "', actual_available ='" + txtstockonhand.Text + "', last_qty_input='" + txtqty.Text + "',move_status='1' where prod_id='" + lblproductionid.Text + "'";

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


                string sqlquery = "UPDATE [dbo].[rdf_production_advance] set move_order_qty='" + txtmoveorder.Text + "', actual_available ='" + txtstockonhand.Text + "', last_qty_input='" + txtqty.Text + "' where prod_id='" + lblproductionid.Text + "' ";
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




        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            if (txtstockonhand.Text.StartsWith("-"))
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
                    //showProdId();


                    //////Start

                    cboProddate_SelectedValueChanged(sender, e);

                    //////END














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

        private void dgvshowQTYbag_CurrentCellChanged(object sender, EventArgs e)
        {

            //txtstock.Text = "0";
            if (dgvshowQTYbag.CurrentRow != null)
            {
                if (dgvshowQTYbag.CurrentRow.Cells["fg_feed_code"].Value != null)
                {
                    lblfeed_code.Text = dgvshowQTYbag.CurrentRow.Cells["fg_feed_code"].Value.ToString();
                    //txtstock.Text = dgvshowQTYbag.CurrentRow.Cells["BagsCount"].Value.ToString();
                    //DROP THE DATA

                    lblproductionid.Text = dgvshowQTYbag.CurrentRow.Cells["prod_adv"].Value.ToString();
                    lblbags.Text = dgvshowQTYbag.CurrentRow.Cells["fg_bags"].Value.ToString();
                    txtmoveorder.Text = dgvshowQTYbag.CurrentRow.Cells["move_order_qty"].Value.ToString();
                    if (cmbBagorSack.Text == "BULK ENTRY")
                    {
                        ///DROP
                        //txtstock.Text = dgvshowQTYbag.CurrentRow.Cells["BulkCount"].Value.ToString();

                        //txtstock.Text = (float.Parse(txtstock.Text) / 50).ToString();
                    }


                }
            }




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
        }

        private void cboProddate_SelectedValueChanged(object sender, EventArgs e)
        {
            txtqty.Text = "";
            // BindData();
            showProdId();

            //txtstockonhand.Text = "0";


            dgvshowQTYbag_CurrentCellChanged(sender, e);


            txtqty.Focus();

            if (cmbBagorSack.Text.Trim() == string.Empty)
            {

            }
            else
            {
                if (cmbBagorSack.Text == "Bagging")
                {
                    int sum = 0;
                    for (int i = 0; i < dgvshowQTYbag.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvshowQTYbag.Rows[i].Cells[3].Value);
                    }
                    txtstock.Text = sum.ToString();
                }

                else
                {
                    int sum = 0;
                    for (int i = 0; i < dgvshowQTYbag.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvshowQTYbag.Rows[i].Cells[4].Value);
                    }
                    txtstock.Text = sum.ToString();


                }

            }

        }

        void MainStock()
        {

            if (cmbBagorSack.Text.Trim() == string.Empty)
            {

            }
            else
            {
                if (cmbBagorSack.Text == "Bagging")
                {
                    int sum = 0;
                    for (int i = 0; i < dgvshowQTYbag.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvshowQTYbag.Rows[i].Cells[3].Value);
                    }
                    txtstock.Text = sum.ToString();
                }

                else
                {
                    int sum = 0;
                    for (int i = 0; i < dgvshowQTYbag.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvshowQTYbag.Rows[i].Cells[4].Value);
                    }
                    txtstock.Text = sum.ToString();


                }

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            textBox1.Text = "cLOSE";
            this.Close();
        }

        private void frmAddnewMoveOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "cLOSE";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtqty.Text == "0")
            {

                InvalidQTY();
                txtqty.Text = "";
            }

            if (lblFeedType.Text.Trim() == string.Empty)
            {

                FillFeedType();
                lblFeedType.Focus();
                return;
            }

            if (cboProddate.Text.Trim() == string.Empty)
            {

                FillFeedType();
                cboProddate.Focus();
                return;
            }


            if (cmbBagorSack.Text.Trim() == string.Empty)
            {

                FillFeedType();
                cmbBagorSack.Focus();
                return;
            }

            if (txtqty.Text.Trim() == string.Empty)
            {

                FillFeedType();
                txtqty.Focus();
                return;
            }

            //if (lbldata1.Text=="")
            //{

            //    FillFeedType();
            //    lbldata1.Focus();
            //    return;
            //}

            //if (lbldata2.Text=="")
            //{

            //    FillFeedType();
            //    lbldata2.Focus();
            //    return;
            //}

            if (cboUOM.Text.Trim() == string.Empty)
            {

                FillFeedType();
                cboUOM.Focus();
                return;
            }

            if (txtstockonhand.Text.StartsWith("-"))
            {
                //MessageBox.Show("Error");
                QtyOver();
                txtqty.BackColor = Color.Yellow;
                txtqty.Focus();
                return;
            }


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (txtmoveorder.Text.Trim() == string.Empty)
                {

                    //txtstockonhand.Text = (float.Parse(txtstock.Text) - float.Parse(txtqty.Text)).ToString();
                    if (cmbBagorSack.Text == "BULK ENTRY")
                    {

                        txtmoveorder.Text = (float.Parse(txtqty.Text) * 1).ToString();

                    }
                }
                else
                {


                    txtmoveorder.Text = (float.Parse(txtmoveorder.Text) + float.Parse(txtqty.Text)).ToString();



                }




                mode = "add";





                UpdateFG();

                if (saveMode())
                {

                    string tmode = mode;

                    if (tmode == "add")
                    {


                        //AddedSuccess();
                        //bunifuThinButton29_Click(sender, e);
                        //btnfinishvalidation_Click(sender, e); ///dito muna ang minus querys
                        //Clear();
                        //load_Schedules_approved();
                        //load_Schedules();



                    }
                    else
                    {

                    }

                    /// btnCancel_Click(sender, e);

                }
                else
                {
                    //MessageBox.Show("Failed");
                }







            }
            else
            {

                return;
            }


            textBox1.Text = "Tapos";
            txtqty.Text = "";
            txtstockonhand.Text = "";
            Success();

            this.Close();








            //    frmMoveOrder_Load(sender, e);
























        }

        private void txtstockonhand_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboProddate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFeedCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BagandBulBindData();


        }
    }
}

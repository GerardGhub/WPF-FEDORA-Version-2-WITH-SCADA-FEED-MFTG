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
    public partial class frmAddNewMaterialReceivingMiscellaneous : Form
    {
        frmMiscellaneousReceiving ths;


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
        //int sec;
        DataSet dset_section = new DataSet();
        Boolean ready = false;
        //bool re = false;
        int p_id = 0;
        //int s_id = 0;
        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();


        public frmAddNewMaterialReceivingMiscellaneous(frmMiscellaneousReceiving frm, string warehouse, string account_title, string customer, string address, string reason, string mode, string item_code, string myorder, string expired, string quantity, string key)
        {
            InitializeComponent();
            ths = frm;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            this.WareHouse = warehouse;
            this.AccountTitle = account_title;
            this.Customer = customer;
            this.Address = address;
            this.Reason = reason;
            this.modes = mode;
            this.ItemCode = item_code;
            this.myOrder = myorder;
            this.Expired = expired;
            this.Quantity = quantity;
            this.Keys = key;
        }

        public string WareHouse { get; set; }
        public string AccountTitle { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public string Reason { get; set; }
        public string modes { get; set; }
        public string ItemCode { get; set; }
        public string myOrder { get; set; }
        public string Expired { get; set; }
        public string Quantity { get; set; }
        public string Keys { get; set; }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
        }

        private void mfg_datePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmAddNewMaterialReceivingMiscellaneous_Load(object sender, EventArgs e)
        {


            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            txtAddedBy.Text = userinfo.emp_name.ToUpper();
            mfg_datePicker.Text = DateTime.Now.ToString("M/d/yyyy");
            lbldateandtime.Text = DateTime.Now.ToString();
            lblmode.Text = modes;

            if (lblmode.Text == "EDIT")
            {

            }
            else
            {
                CallMaterialsDescription();
            }

                LoadItemCode();

                ComboReceivingDateBinding();
            //    CallMaterialsDescription();
                CheckTheNumberTransactions();
                txtordercount.Text = (float.Parse(lbltotaldata.Text) + 2).ToString();
           
                loadCustomer();
                loadWarehouse();
                cboWarehouse_SelectedIndexChanged(sender, e);

                cboCustomer_SelectedIndexChanged(sender, e);
         
            load_materials_out();
            if(lbldataout.Text =="0")
            {
                cboWarehouse.Enabled = false;
                cboCustomer.Enabled = false;

            }
            else
            {
                cboWarehouse.Enabled = false;
                cboCustomer.Enabled = false;
            }


            cboWarehouse.Text = WareHouse;
            lbldata1.Text = AccountTitle;
            cboCustomer.Text = Customer;
            lbldata2.Text = Address;
            txtotherdescription.Text = Reason;

         
            txtExpiryDate.Text = Expired;

            if (lblmode.Text=="EDIT")
            {

                txtExpiryDate.Visible = true;
                cboReceivingDate.Visible = false;
                cboItemCode.Text = ItemCode;
                cboReceivingDate.Text = Expired;
                lblmyorder.Text = myOrder;
              txtqty.Text = Quantity;
                txtgetqty.Text = Quantity;
                lblkey.Text = Keys;
                CallMaterialsDescription();
                cboReceivingDate.Enabled = false;
                QueryReceivingDateDetails2();


                dgvBindMaterial_CurrentCellChanged(sender, e);
                cboItemCode.Enabled = false;
                txtgetqty.Visible = true;
            }
            else
            {
                txtgetqty.Visible = false;
                txtExpiryDate.Visible = false;
                cboReceivingDate.Visible = true;
            }

            //if(txtcurrentstock.Text=="0")
            //{
            //    btnsave.Enabled = false;
            //}
        }




        public void load_materials_out()
        {
            string mcolumns = "test,item_code,item_description";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvMaterialsout, mcolumns, "materials_out");
         lbldataout.Text = dgvMaterialsout.RowCount.ToString();

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

        void CallMaterialsDescription()
        {


            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "SELECT * FROM [dbo].[rdf_raw_materials] where is_active='1' and item_code='" + cboItemCode.Text + "'";



            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvViewDescriptions.DataSource = dt;
           lblsearhcountrawmats.Text = dgvViewDescriptions.RowCount.ToString();


        }

        void CheckTheNumberTransactions()
        {

            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);


            string sqlquery = "SELECT * FROM [dbo].[rdf_transaction_out_progress]";



            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            lbltotaldata.Text = dataGridView1.RowCount.ToString();
            sql_con.Close();



        }

        public void FillRequiredFields()
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


        public void NotEnoughInventory()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Not Enough Inventory for the request";

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

            popup.ContentText = "Invalid Quantity";

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


        public void InvalidSameQTYUpdate()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Invalid  Same Quantity of Updating";

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

            popup.ContentText = "Successfully insert a new Transaction of Raw Material";

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

        void LoadItemCode()
        {
            ready = false;
            mfg_datePicker.Enabled = false;
            txtdescription.Enabled = false;
            txtxp.Enabled = false;
            xClass.fillComboBoxWH(cboItemCode, "rdf_item_code_view", dSet);
            //displayData(Convert.ToInt32(cboStandardWeight.SelectedValue.ToString()));

            ready = true;
            textBox1.Text = "";
        }


        public void ComboReceivingDateBinding()
        {

            String cone = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection con = new SqlConnection(cone);

            con.Open();
            string strCmd = "select * from  [dbo].[rdf_microreceiving_entry] WHERE r_item_code ='" + cboItemCode.Text + "' AND received_id= '"+cboReceivedId.Text + "' AND receiving_status='1' AND NOT actual_count_good='0' ORDER BY CAST(r_expiry_date as date) ASC ";

            SqlCommand cmd = new SqlCommand(strCmd, con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboReceivingDate.DataSource = ds.Tables[0];
            cboReceivingDate.DisplayMember = "r_expiry_date";
            cboReceivingDate.ValueMember = "r_item_code";
            //      cboProddate.Enabled = true;
            // this.cboProddate.SelectedIndex = -1;
            cmd.ExecuteNonQuery();
            con.Close();
    

        }

        public void ComboReceivedId()
        {

            String cone = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

            SqlConnection con = new SqlConnection(cone);

            con.Open();
            string strCmd = "select * from  [dbo].[rdf_microreceiving_entry] WHERE r_item_code ='" + cboItemCode.Text + "' AND receiving_status='1' AND NOT actual_count_good='0' ORDER BY CAST(r_expiry_date as date) ASC ";

            SqlCommand cmd = new SqlCommand(strCmd, con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboReceivedId.DataSource = ds.Tables[0];
            cboReceivedId.DisplayMember = "received_id";
            cboReceivedId.ValueMember = "r_item_code";
            //      cboProddate.Enabled = true;
            // this.cboProddate.SelectedIndex = -1;
            cmd.ExecuteNonQuery();
            con.Close();


        }













        public void QueryReceivingDateDetails()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";

 
            SqlConnection sql_con = new SqlConnection(connetionString);

            string sqlquery = "select a.item_id,a.item_code,a.Category,a.item_description,a.total_quantity_raw,a.qty_repack_available,a.qty_repack,a.qty_production,ISNULL(t5.RECEIVING,0) + ISNULL(t6.ISSUE,0) - ISNULL(t2.MACRESERVED,0) - ISNULL(t7.OUTING,0) as RESERVED,(ISNULL(t6.ISSUE,0) * 1  +ISNULL(t5.RECEIVING,0)) - (ISNULL(t3.SCADA,0)  + ISNULL(t7.OUTING,0) + ISNULL(t4.MACREPACK,0))   as ONHAND from [dbo].[rdf_raw_materials] a LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as RECEIVING from rdf_microreceiving_entry BC where BC.transaction_type='PO' group by BC.r_item_code) t5 on a.item_code = t5.r_item_code LEFT JOIN ( select BC.r_item_code, sum(CAST(REPLACE(BC.r_quantity,',','') as float))  as ISSUE from rdf_microreceiving_entry BC where BC.transaction_type='Miscellaneous Receipt' group by BC.r_item_code) t6 on a.item_code = t6.r_item_code LEFT JOIN ( select BC.item_code, sum(CAST(BC.quantity as float)*2)  as MACRESERVED from rdf_recipe_to_production BC where CAST(BC.proddate as date) BETWEEN '2021-01-12' and GETDATE()+30 and status_of_person IS NULL group by BC.item_code) t2 on a.item_code = t2.item_code LEFT JOIN ( select BC.item_code, sum(CAST(REPLACE(BC.qty,',','') as float))  as OUTING from rdf_transaction_out_progress BC where BC.is_active='1' group by BC.item_code) t7 on a.item_code = t7.item_code  LEFT JOIN ( select BC.theo_item_code, sum( BC.actual_qty ) as SCADA from theo_logs_tbl BC where CAST(date_time as date) BETWEEN '2021-01-12' and GETDATE()  group by BC.theo_item_code ) t3 on a.item_code = t3.theo_item_code LEFT JOIN ( select BC.rp_item_code, sum(CAST(BC.total_repack as float))  as MACREPACK from rdf_repackin_entry BC where CAST(BC.production_date as date) BETWEEN '2021-01-12' and GETDATE()+3 group by BC.rp_item_code) t4 on a.item_code = t4.rp_item_code WHERE a.item_code = '" + cboItemCode.Text + "'";


            //2/3/2021 coding parin nakakaksawa na !
            //string sqlquery = "Select * FROM [dbo].[rdf_microreceiving_entry] where r_expiry_date='" + cboReceivingDate.Text+"' AND r_item_code='"+cboItemCode.Text+"' AND received_id='"+ cboReceivedId.Text + "' ";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvBindMaterial.DataSource = dt;


        }



        public void QueryReceivingDateDetails2()
        {
            String connetionString = @"Data Source=10.10.2.16,1433\SQLEXPRESS;Initial Catalog=Fedoramain;User ID=sa;Password=FMf3dor@2o20;MultipleActiveResultSets=true";


            SqlConnection sql_con = new SqlConnection(connetionString);

          
            string sqlquery = "Select * FROM [dbo].[rdf_microreceiving_entry] where received_id='" + lblmyorder.Text + "' AND r_expiry_date='" + txtExpiryDate.Text + "' AND r_item_code='" + cboItemCode.Text + "' ";


            sql_con.Open();
            SqlCommand sql_cmd = new SqlCommand(sqlquery, sql_con);
            SqlDataAdapter sdr = new SqlDataAdapter(sql_cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dgvBindMaterial.DataSource = dt;


        }




        private void cboItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboReceivedId();//matic
            ComboReceivingDateBinding();
            QueryReceivingDateDetails();
       


            CallMaterialsDescription();

            dgvBindMaterial_CurrentCellChanged(sender, e);
            txtqty.Text = "";
        }

        private void cboReceivingDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryReceivingDateDetails();

            dgvBindMaterial_CurrentCellChanged(sender, e);
        }

        private void dgvBindMaterial_CurrentCellChanged(object sender, EventArgs e)
        {

            dtpMfgDate.Enabled = false;
            xpired.Enabled = false;

            if (dgvBindMaterial.CurrentRow != null)
            {
                if (dgvBindMaterial.CurrentRow.Cells["item_code"].Value != null)
                {
                    txtcurrentstock.Text = dgvBindMaterial.CurrentRow.Cells["ONHAND"].Value.ToString();

                    dtpMfgDate.Text = DateTime.Now.ToString("M/d/yyyy");
                    txtCategory.Text = dgvBindMaterial.CurrentRow.Cells["Category"].Value.ToString();
                   txtdescription.Text = dgvBindMaterial.CurrentRow.Cells["item_description"].Value.ToString();

                  txtTransactno.Text = dgvBindMaterial.CurrentRow.Cells["item_id"].Value.ToString();

                    lbltransactiontype.Text = "ISSUE";
                    //lbltransactiontype.Text = dgvBindMaterial.CurrentRow.Cells["transaction_type"].Value.ToString();

                    xpired.Text = DateTime.Now.ToString("M/d/yyyy");

                    txtxp.Text = DateTime.Now.ToString("M/d/yyyy");

                    txtremarks.Text = "ISSUE";

                    cboReason.Text = "ISSUE";



                    txtremarks.Text= "Good";
                    txtSupplier.Text = "OUT";

                }
            }








        }

        private void cboReceivingDate_SelectedValueChanged(object sender, EventArgs e)
        {
            QueryReceivingDateDetails();
        }

        private void frmAddNewMaterialReceivingMiscellaneous_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "EXit na";
        }

        private void txtactualstock_TextChanged(object sender, EventArgs e)
        {

    
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {

            if (txtactualstock.Text.Contains("-"))
            {
                btnsave.Enabled = false;
            }
            else
            {
                btnsave.Enabled = true;
            }

            if (lblmode.Text == "EDIT")
            {




                if (txtqty.Text.Contains("-"))
                {
                    return;
                }
           
                
                if (txtqty.Text.Trim() == string.Empty)
                {

                    lblsumstock.Text = "";
                    lblsumrepack.Text = "";
                    lblsumserved.Text = "";
                    txtnewstock.Text = "";
                    txtmasteranswer.Text = "";
                }

                else
                {


                    double original;
                    double actual;


                    if (txtgetqty.Text.Trim() == string.Empty)
                    {

                    }
                    else
                    {

     

                        original = double.Parse(txtgetqty.Text);

                        actual = double.Parse(txtqty.Text);


                        if (original == actual)
                        {

                        }
                        else
                        {



                            if (original > actual)
                            {
                               // MessageBox.Show("Mataaas");

                                txtmasteranswer.Text = (float.Parse(txtgetqty.Text) - float.Parse(txtqty.Text)).ToString();



                               txtnewstock.Text = (float.Parse(txtcurrentstock.Text) + float.Parse(txtmasteranswer.Text)).ToString();



                                lblsumstock.Text = (float.Parse(lbltotalqty.Text) - float.Parse(txtmasteranswer.Text)).ToString();

                                lblsumrepack.Text = (float.Parse(lbltotalrepack.Text) - float.Parse(txtmasteranswer.Text)).ToString();

                                lblsumserved.Text = (float.Parse(lbltotalreserve.Text) - float.Parse(txtmasteranswer.Text)).ToString();


                                //if (txtnewstock.Text.Contains("-"))
                                //{
                                //    // return;

                                //    btnsave.Enabled = false;
                                //}
                                //else
                                //{

                                //    btnsave.Enabled = true;
                                //}

                            }
                            else
                            {
                              //  MessageBox.Show("Mababa");

                                txtmasteranswer.Text = (float.Parse(txtqty.Text) - float.Parse(txtgetqty.Text)).ToString();

                                txtnewstock.Text = (float.Parse(txtcurrentstock.Text) - float.Parse(txtmasteranswer.Text)).ToString();


                                lblsumstock.Text = (float.Parse(lbltotalqty.Text) + float.Parse(txtmasteranswer.Text)).ToString();

                                lblsumrepack.Text = (float.Parse(lbltotalrepack.Text) + float.Parse(txtmasteranswer.Text)).ToString();

                                lblsumserved.Text = (float.Parse(lbltotalreserve.Text) + float.Parse(txtmasteranswer.Text)).ToString();


                                //if (txtnewstock.Text.Contains("-"))
                                //{

                                //    btnsave.Enabled = false;
                                //}
                                //else
                                //{

                                //    btnsave.Enabled = true;

                                //}

                            }


                        }
                        //gagai


                    }

                }

            }
            else
            {



                if (txtqty.Text.Trim() == string.Empty)
                {
                    txtactualstock.Text = "";
                    lblsumstock.Text = "";
                    lblsumrepack.Text = "";
                    lblsumserved.Text = "";
                }
                else
                {
                    txtactualstock.Text = (float.Parse(txtcurrentstock.Text) - float.Parse(txtqty.Text)).ToString();
                }



                if (lblsearhcountrawmats.Text == "0")
                {
                    return;



                }
                else
                {
                    if (txtqty.Text.Trim() == string.Empty)
                    {
                        return;
                    }


                    lblsumstock.Text = (float.Parse(lbltotalqty.Text) - float.Parse(txtqty.Text)).ToString();

                    lblsumrepack.Text = (float.Parse(lbltotalrepack.Text) - float.Parse(txtqty.Text)).ToString();

                    lblsumserved.Text = (float.Parse(lbltotalreserve.Text) - float.Parse(txtqty.Text)).ToString();
             
                
                
                }


            }
        }

        public bool saveMode()
        {

            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.sp_transaction_out(0, cboItemCode.Text.Trim(), txtdescription.Text, txtCategory.Text.Trim(), txtSupplier.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), txtAddedBy.Text.Trim(), txtxp.Text.Trim(), txtordercount.Text.Trim(), txtmaterialid.Text.Trim(),txtTransactno.Text.Trim(),txtactualstock.Text.Trim(),cboWarehouse.Text.Trim(), lbldata1.Text.Trim().Trim(), cboCustomer.Text.Trim(), lbldata2.Text.Trim(), cboReason.Text.Trim(), txtotherdescription.Text.Trim(),  "add");


    
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



        private void btnsave_Click(object sender, EventArgs e)
        {

                   if (txtactualstock.Text.Contains("-"))
            {

                NotEnoughInventory();
              txtqty.Focus();
                return;
            }

            if (lblmode.Text == "EDIT")
            {

                if (cboReason.Text.Trim() == string.Empty)
                {

                    FillRequiredFields();
                    cboReason.Focus();
                    return;
                }


                //double original;
                //double actual;




                //original = double.Parse(txtgetqty.Text);

                //actual = double.Parse(txtqty.Text);


                //if (original == actual)
                //{
                //    InvalidSameQTYUpdate();
                //    return;
                //}






















                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {


                    //Receiving Minus 
                    dSet.Clear();
                    dSet = objStorProc.sp_transaction_out(0, txtnewstock.Text.Trim(), lblmyorder.Text.Trim(), "", cboItemCode.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "minusstock");

                    //Inventory Minus
                    dSet.Clear();
                    dSet = objStorProc.sp_transaction_in(0, lblsumstock.Text.Trim(), lblsumrepack.Text, lblsumserved.Text.Trim(), cboItemCode.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "", "", "minusrawmats");





                    //transaction  out table
                    dSet.Clear();
                    dSet = objStorProc.sp_transaction_in(0, txtqty.Text.Trim(), lblkey.Text, lblsumserved.Text.Trim(), cboItemCode.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "", "", "updateStockout");



                 //   mode = "add";





 





                }
                else
                {

                    return;
                }


                textBox1.Text = "Tapos";
                txtqty.Text = "";
                txtSupplier.Text = "";
                Success();


                this.Hide();
                //  this.Close();








     
























            //
        }
            else
            {

                if (txtactualstock.Text.Contains("-"))
                {

                    InvalidQTY();
                    txtqty.Text = "";
                    txtqty.Focus();
                    return;
                }

                if (txtTransactno.Text.Trim() == string.Empty)
                {

                    FillRequiredFields();
                    txtTransactno.Focus();
                    return;
                }

                if (cboItemCode.Text.Trim() == string.Empty)
                {
                    FillRequiredFields();
                    cboItemCode.Focus();
                    return;
                }


                if (txtSupplier.Text.Trim() == string.Empty)
                {
                    FillRequiredFields();
                    txtSupplier.Focus();
                    return;
                }

                if (txtqty.Text.Trim() == string.Empty)
                {

                    FillRequiredFields();
                    txtqty.Focus();
                    return;
                }


                if (txtxp.Text.Trim() == string.Empty)
                {

                    FillRequiredFields();

                    return;
                }

                if (txtremarks.Text.Trim() == string.Empty)
                {
                    //MessageBox.Show("Error");
                    FillRequiredFields();
                    txtremarks.Focus();
                    return;
                }


                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save the Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {


                    //Receiving Minus 
                    dSet.Clear();
                    dSet = objStorProc.sp_transaction_out(0, txtactualstock.Text.Trim(), txtTransactno.Text.Trim(), "", cboItemCode.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "minusstock");

                    //Inventory Minus
                    dSet.Clear();
                    dSet = objStorProc.sp_transaction_in(0, lblsumstock.Text.Trim(), lblsumrepack.Text, lblsumserved.Text.Trim(), cboItemCode.Text.Trim(), txtqty.Text.Trim(), lbldateandtime.Text.Trim(), dtpMfgDate.Text.Trim(), xpired.Text.Trim(), txtremarks.Text.Trim(), mfg_datePicker.Text.Trim(), "", txtxp.Text.Trim(), "", "", "minusrawmats");





                    mode = "add";





                    //   UpdateFG();

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



                    textBox1.Text = "Tapos";
                    txtqty.Text = "";
                    txtSupplier.Text = "";
                    Success();


                    this.Close();



                }
                else
                {

                    return;
                }



                //  this.Close();








            }



        }

        private void dgvViewDescriptions_CurrentCellChanged(object sender, EventArgs e)
        {
            if(lblsearhcountrawmats.Text=="0")
            {
                return;
            }
      
            if (dgvViewDescriptions.CurrentRow != null)
            {
                if (dgvViewDescriptions.CurrentRow.Cells["item_code"].Value != null)
                {
                    txtdescription.Text = dgvViewDescriptions.CurrentRow.Cells["item_description"].Value.ToString();

                    txtCategory.Text = dgvViewDescriptions.CurrentRow.Cells["Category"].Value.ToString();

                    lbltotalqty.Text = dgvViewDescriptions.CurrentRow.Cells["total_quantity_raw"].Value.ToString();
                    lbltotalrepack.Text = dgvViewDescriptions.CurrentRow.Cells["qty_repack_available"].Value.ToString();
                    lbltotalreserve.Text = dgvViewDescriptions.CurrentRow.Cells["qty_production"].Value.ToString();





                }



                if (lblsearhcountrawmats.Text == "0")
                {
                    return;



                }
                else
                {
                    if(txtqty.Text.Trim() == string.Empty)
                    {
                        return;
                    }


                    lblsumstock.Text = (float.Parse(lbltotalqty.Text) - float.Parse(txtqty.Text)).ToString();

                    lblsumrepack.Text = (float.Parse(lbltotalrepack.Text) - float.Parse(txtqty.Text)).ToString();

                    lblsumserved.Text = (float.Parse(lbltotalreserve.Text) - float.Parse(txtqty.Text)).ToString();
                }



            }










        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbldata1.Text = cboWarehouse.SelectedValue.ToString();
            lbldata1.Visible = true;
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbldata2.Text = cboCustomer.SelectedValue.ToString();
            lbldata2.Visible = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dgvMaterialsout_CurrentCellChanged(object sender, EventArgs e)
        {

            if (lbldataout.Text == "0")
            {

            }
            else
            {


                if (dgvMaterialsout.CurrentRow != null)
                {
                    if (dgvMaterialsout.CurrentRow.Cells["item_code"].Value != null)
                    {
                        cboWarehouse.Text = dgvMaterialsout.CurrentRow.Cells["warehouse"].Value.ToString();
                        lbldata1.Text = dgvMaterialsout.CurrentRow.Cells["account_title"].Value.ToString();
                        cboCustomer.Text = dgvMaterialsout.CurrentRow.Cells["customer"].Value.ToString();
                        lbldata2.Text = dgvMaterialsout.CurrentRow.Cells["address"].Value.ToString();






                    }

                }

            }






                //

            }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "udlot";
            this.Close();
        }

        private void cboReceivedId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            QueryReceivingDateDetails();
            ComboReceivingDateBinding();
        }

        private void cboReceivedId_SelectedValueChanged(object sender, EventArgs e)
        {
            QueryReceivingDateDetails();
            ComboReceivingDateBinding();
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsControl(e.KeyChar)
    && !char.IsDigit(e.KeyChar)
    && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }
    }
}

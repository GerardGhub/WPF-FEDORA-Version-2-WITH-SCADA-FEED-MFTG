using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WFFDR.Finished_Goods
{
    public partial class FrmFGMiscellaneousFinanceIssue : Form
    {
        //mymode
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSets = new DataSet();

        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        DataSet dSet_temp = new DataSet();
        DataSet dset_delete = new DataSet();
        DataSet dset_date = new DataSet();
        DataSet dset_emp = new DataSet();
        DataSet dSet = new DataSet();
        DataSet dset_rights = new DataSet();
        DataSet dset_bulk = new DataSet();


        private const int BaudRate = 9600;

        DataSet dset_section = new DataSet();
        Boolean ready = false;
        bool re = false;


        //weighing

        public myclasses classes = new myclasses();
        myclasses myClass = new myclasses();


        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();
        public FrmFGMiscellaneousFinanceIssue()
        {
            InitializeComponent();
        }

        private void FrmFGMiscellaneousFinanceIssue_Load(object sender, EventArgs e)
        {
            // Calling the Stored PROC 
            objStorProc = xClass.g_objStoredProc.GetCollections();
            loadWarehouse();
            loadCustomer();
            loadFeedCode();
            load_transactions_count();
            load_Moveorder();
            
            load_fginvetory();
            Calldata();
            lblquantity.Visible = false;
            lbldateandtime.Text = DateTime.Now.ToString();

            lbldata1.Visible = false;
            lbldata2.Visible = false;
            lblsasa.Text = userinfo.emp_name.ToUpper();

            livedateandtime.Text = DateTime.Now.ToString();

            txtdatenow.Text = (DateTime.Now.ToString("MM/dd/yyyy"));
            dateonly.Text = (DateTime.Now.ToString("MM/dd/yyyy"));
            cboWarehouse_SelectedIndexChanged(sender, e);
            cboCustomer_SelectedIndexChanged(sender, e);
            Cbbagbulk_SelectionChangeCommitted(sender, e);
            Cbfeedcode_SelectionChangeCommitted(sender, e);
            txtremarks.Text = String.Empty;
            int sum = 0;
            for (int i = 0; i < Dgvmain.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(Dgvmain.Rows[i].Cells["qty"].Value);
            }



            lblquantitymain.Text = sum.ToString();



            load_FGCategory();
            LoadFeedcodeDropdown();
            Cbbagbulk.Format += (s, t) =>
            {
                t.Value = t.Value.ToString().ToUpperInvariant();
            };


            Cbfeedcode.SelectedIndex = -1;
            cboCustomer.SelectedIndex = -1;
            Cbbagbulk.SelectedIndex = -1;
           
         
            
            dgvfgdate.ClearSelection();
            dgvprodd.ClearSelection();
            load_proddate();
            Cbfgdate.SelectedIndex = -1;
            

           

        }


        public void load_FGCategory()
        {

            xClass.fillComboBoxCategory(Cbbagbulk, "fg_category", Cbfeedcode.Text.ToString(),"","", dSet);

        }

        public void load_proddate()
        {

            xClass.fillComboBoxproddate(Cbfgdate, "callproddate", Cbfeedcode.Text.ToString(), Cbbagbulk.Text.ToString(),"", dSet);
            Cbfgdate.SelectedIndex = -1;

        }

        public void LoadFeedcodeDropdown()
        {

            xClass.fillComboBoxFeedcode(Cbfeedcode, "fg_feedcode", dSet);
            Cbfeedcode.SelectedIndex = -1;

        }

        public void load_transactions_count()
        {
            string mcolumns = "test,order_no";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvTransactions, mcolumns, "transaction_issue_count");
            txtorder.Text = dgvTransactions.RowCount.ToString();
            txtorderstable.Text = dgvTransactions.RowCount.ToString();
            txtordervalidation.Text = dgvTransactions.RowCount.ToString();

        }
        void loadFeedCode()
        {


            xClass.fillComboBoxFGMoveorder(Cbfeedcode, "feed_code_fg_moveorder", dSet);



        }

        public void Calldata()
        {

            string mcolumns = "test,order_no,feed_code,feed_type,sack_bin,uom,qty,production_date,production,fgdate";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvstatus, mcolumns, "Callmoveorder");

            int sum = 0;

            for (int i = 0; i < dgvstatus.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvstatus.Rows[i].Cells["qty"].Value);
            }

            quantityaddline.Text = sum.ToString();

        }





        void loadCustomer()
        {
            ready = false;
            xClass.fillComboBoxWH(cboCustomer, "rdf_customer", dSet);
            ready = true;
        }
        void loadWarehouse()
        {
            ready = false;
            xClass.fillComboBoxWH(cboWarehouse, "rdf_warehouse", dSet);
            ready = true;
        }



        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFeedCode_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cboProddate_SelectedValueChanged(object sender, EventArgs e)
        {

        }



        public void EmptyFieldNotify()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Please fill in the required Field!";

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
        public void Invalidzero()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Sorry the quantity must not enter start from 0! ";

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

        void InvalidQuantity()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Invalid Quantity for Bulk Entry!";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            //popup.AnimationDuration = 1000;
            //popup.ShowOptionsButton.ToString();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //txtMainInput.Focus();
            //txtMainInput.Select();
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

            popup.ContentText = "The Total quantity of '" + Cbfeedcode.Text + "' are only '" + txtbxavailable.Text + " " + Cbbagbulk.Text + "',Sorry the quantity that you enter is not enough. ";

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

        public void TwoModulesareRunning()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);

            popup.ContentText = "Please try again MIscellaneous Issue and Move Order are currently running! Thank you.";

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

            popup.ContentText = "You've reach the limit!";

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

            popup.ContentText = "Successfully added Move Order!";

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

            popup.ContentText = "Miscellaneous Transactions Successfully save";

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






        private void btnInsert_Click(object sender, EventArgs e)
        {


        }



        private void dgvshowQTYbag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvApproved_CellContentClick(object sender, DataGridViewCellEventArgs e)
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






        private void dgvApproved_DoubleClick(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        public void CancelSuccessFully()
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

        private void frmMoveOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tsneworderbtn_Click(object sender, EventArgs e)
        {
            tsneworderbtn.Enabled = false;
            Cbfeedcode.Enabled = true;
            //Cbbagbulk.Enabled = true;
            gpmoveinfo.Enabled = true;
            timer1.Enabled = false;
            tscancelbtn.Enabled = false;
            tsaddlinebtn.Enabled = true;
            txtremarks.Enabled = true;
            Cbfgdate.Enabled = true;
            txtmoveorderno.Enabled = true;



            //int sum = 0;


            //txtorder.Text = dgvTransactions.RowCount.ToString();

            //sum = Convert.ToInt32(txtorder.Text) + 1;

            //txtorder.Text = sum.ToString();


            if (Lblrecordss.Text == "0")
            {

                cboCustomer.Enabled = true;

            }

            else
            {
                cboCustomer.Enabled = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        private void Resetbutton()
        {

            tsneworderbtn.Enabled = true;
            tsaddlinebtn.Enabled = false;
            Txtbxquantity.Enabled = false;
            tsconfirmorderbtn.Enabled = false;
            Cbbagbulk.Enabled = false;
            Cbfeedcode.Enabled = false;
            txtremarks.Enabled = false;

        }

        public void load_transactions_countvalidation()
        {
            string mcolumns = "test,order_no";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvTransactions, mcolumns, "transaction_issue_count");
            //txtorder.Text = dgvTransactions.RowCount.ToString();
            //txtorderstable.Text = dgvTransactions.RowCount.ToString();
            txtordervalidation.Text = dgvTransactions.RowCount.ToString();


        }

        public void load_transaction_countplus1()

        {

            int sum = 0;


            //  txtorder.Text = dgvTransactions.RowCount.ToString();

            sum = Convert.ToInt32(txtorder.Text) + 1;

            txtorder.Text = sum.ToString();

        }

        public void load_transaction_countplus1valid()

        {
            int sum = Convert.ToInt32(txtordervalidation.Text);
            int total = 0;

            total = sum + 1;

            txtorder.Text = total.ToString();


        }

        private void Loadprintout()
        {

            myglobal.DATE_REPORT = txtorder.Text;
            myglobal.DATE_REPORT2 = txtorder.Text;
            //myglobal.DATE_REPORT2 = f2.Text;
            //myglobal.DATE_REPORT3 = lblmyfeedcode.Text;
            //myglobal.REPORT_NAME = "DailyProductionSchedule";
            myglobal.REPORT_NAME = "FGMiscellaneousIssue";



            frmReport fr = new frmReport();

            fr.WindowState = FormWindowState.Maximized;
            fr.Show();

        }
        private void tsconfirmorderbtn_Click(object sender, EventArgs e)
        {
            this.Dgvmain.CurrentCell = this.Dgvmain.Rows[0].Cells[this.Dgvmain.CurrentCell.ColumnIndex];



            if (txtremarks.Text == String.Empty)

            {
                EmptyFieldNotify();
                txtremarks.Focus();
                return;


            }

            if(txtmoveorderno.Text == String.Empty)
            {
                EmptyFieldNotify();
                txtmoveorderno.Focus();
                return;

            }


            else if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want save this Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                
                Dgvmain.Columns["production"].Visible = true;
                Dgvmain.Columns["Pdate"].Visible = true;
                Dgvmain.Columns["my_fgid"].Visible = true;
                Dgvmain.Columns["added_by"].Visible = true;
                Dgvmain.Columns["order_no"].Visible = true;


                cboFeedCode.SelectedIndex = -1;
                cboProddate.SelectedIndex = -1;
                Cbbagbulk.SelectedIndex = -1;


                dgvfgdate.ClearSelection();
                dgvFGdatebulk.ClearSelection();
                dgvprodd.ClearSelection();

                load_transactions_countvalidation();

                if (txtordervalidation.Text == txtorderstable.Text)
                {
                    load_transaction_countplus1();
                }
                else
                {
                    load_transaction_countplus1valid();
                }


                Queryfinalmoveorder();
                Feedcodetransaction();
                Queryconfirmorderfinal();
                Queryupdaterdfmoveordertable();
                btnnextmain_Click(sender, e);

                Resetbutton();

                SaveSuccess();

                if (Lblrecordss.Text == "0")
                {

                    cboCustomer.Enabled = true;

                }

                else

                {
                    cboCustomer.Enabled = false;

                }


                //  button1_Click(sender, e);
                Loadprintout();
                FrmFGMiscellaneousFinanceIssue_Load(sender, e);
                timer1.Enabled = true;
                Txtbxquantity.Enabled = false;


            }
            else
            {
                return;

            }
        }

        void Cleartxt()
        {

            Txtbxquantity.Text = String.Empty;
            Txtbxfeedtype.Text = String.Empty;
            Cbfeedcode.Text = String.Empty;
            Cbbagbulk.Text = String.Empty;
            Cmbfgdate.Text = String.Empty;
            txtbxavailable.Text = String.Empty;
            txtavaildate.Text = String.Empty;
            fgid.Text = String.Empty;
            txtboxprodid.Text = String.Empty;

        }
        private void tscancelbtn_Click(object sender, EventArgs e)
        {




            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to cancel this Transaction ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //  Cleartxt();
                Clear();

                //Txtbxfeedtype.Text = String.Empty;
                //Cbbagbulk.Text = String.Empty;
                //Cbfeedcode.Text = String.Empty;
                //  timer1.Enabled = true;

                if (bagbulkmain.Text == "BULK ENTRY")
                {
                    dSet.Clear();
                    dSet = objStorProc.rdf_sp_move_order(0, ordermain.Text.Trim(), "", "", "", "", "", feedcodemain.Text.Trim(), "", bagbulkmain.Text.Trim(), fgdate.Text.Trim(), "", "", "", "", "", productionmain.Text.Trim().ToString(), lblsasa.Text, "", 0, "", "", myfgidbulk.Text.Trim().ToString(), "cancelmoveorderbulkissue");
                    Querycancelmoveorder();


                }
                else
                {
                    Querycancelrdfmoveordertable();
                    Querycancelmoveorderbagging();

                }
              





                CancelSuccessFully();
                Cbbagbulk_SelectionChangeCommitted(sender, e);
                Cbfeedcode_SelectionChangeCommitted(sender, e);
                LoadFeedcodeDropdown();
                load_FGCategory();
                load_Moveorder();
                //   load_fgdate();
                //   load_prodid();




                if (Lblrecordss.Text == "0")
                {

                    tsaddlinebtn.Enabled = false;
                    tsneworderbtn.Enabled = true;
                    gpmoveinfo.Enabled = false;
                    timer1.Enabled = true;
                    cboCustomer.Enabled = true;
                    FrmFGMiscellaneousFinanceIssue_Load(sender, e);
                    Cbbagbulk_SelectionChangeCommitted(sender, e);
                    Cbfeedcode_SelectionChangeCommitted(sender, e);


                }
                else

                {

                    cboCustomer.Enabled = false;


                }
            }

            else
            {

                return;


            }
        }

        private void Cbfeedcode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            Cleartxt();

            load_FGCategory();
            Cbbagbulk.SelectedIndex = -1;
            //Cbbagbulk.Enabled = true;
            //Cbfgdate.Items.Clear();

            try
            {
                if (Cbbagbulk.SelectedIndex == -1)
                {
                    dgvprodd.ClearSelection();
                    dgvfgdate.ClearSelection();
                    Cbfgdate.SelectedIndex = -1;
                    return;
                }

                if (Cbfeedcode.SelectedIndex == -1)
                {

                    dgvprodd.ClearSelection();
                    dgvfgdate.ClearSelection();
                    Cbfgdate.SelectedIndex = -1;
                    return;
                }


                else
                {
                   

                    if (Cbbagbulk.Text == "BAGGING")
                    {
                        myglobal.global_module = "fg_inventory_bag";
                        load_fgdate();
                        //load_search2();
                       
                       
                        load_search3();
                        load_search4();
                        Showcount();

                        Enablequantity();
                        int sum = 0;



                        for (int i = 0; i < dgvprodd.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dgvprodd.Rows[i].Cells["Total"].Value);
                        }

                        txtbxavailable.Text = sum.ToString();

                        load_proddate();
                        Cbfgdate.SelectedIndex = -1;

                        //Cbfgdate.Items.Clear();

                        //foreach (DataGridViewRow row in dgvfgdate.Rows)
                        //{
                        //    Cbfgdate.Items.Add(row.Cells["_FG_Date_"].Value.ToString());
                        //}

                        if (Cbfgdate.Text.Trim() == String.Empty)
                        {
                            stockonhand.Text = "0";
                            //return;
                        }

                        // showProdId();
                    }

                    else
                    {

                        myglobal.global_module = "fg_inventory_bulk";
                        load_fgdatebulk();
                        load_fgdatebulkfinance();
                        //load_search2();
                       
                        
                        load_search3();
                        load_search4();

                        Enablequantity();

                        int sum = 0;
                        for (int i = 0; i < dgvfgdate.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dgvfgdate.Rows[i].Cells["Total_"].Value);
                        }
                        txtbxavailable.Text = sum.ToString();


                        //Cbfgdate.Items.Clear();

                        //foreach (DataGridViewRow row in dgvFGdatebulk.Rows)
                        //{
                        //    Cbfgdate.Items.Add(row.Cells["FGD"].Value.ToString());
                        //}

                        load_proddate();
                        Cbfgdate.SelectedIndex = -1;

                        if (Cbfgdate.Text.Trim() == String.Empty)
                        {
                            stockonhand.Text = "0";
                            //return;
                        }
                        // showProdId();


                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void load_search3()
        {
            dSet_temp.Clear();


            if (myglobal.global_module == "EMPLOYEE")
            { dSet_temp = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dSet_temp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "fg_inventory_bulk")
            { /*dSet_temp = objStorProc.sp_getMajorTables("Callfgdatebulk");*/
                dSet_temp = objStorProc.sp_GetCategory("Callfgdatebulk",0, Cbfeedcode.Text, Cbbagbulk.Text, Cbfgdate.Text);
            }
            else if (myglobal.global_module == "fg_inventory_bag")
            { /*dSet_temp = objStorProc.sp_getMajorTables("Callprodid");*/
                dSet_temp = objStorProc.sp_GetCategory("Callprodid", 0, Cbfeedcode.Text, Cbbagbulk.Text, Cbfgdate.Text);
            }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            { dSet_temp = objStorProc.sp_getMajorTables("employee_B"); }
            else if (myglobal.global_module == "PHONEBOOK")
            { dSet_temp = objStorProc.sp_getMajorTables("phonebook"); }
            else if (myglobal.global_module == "DA")
            { dSet_temp = objStorProc.sp_getMajorTables("get_da"); }
            else if (myglobal.global_module == "ATTENDANCE")
            { dSet_temp = objStorProc.sp_getMajorTables("attendance_monitoring"); }
            else if (myglobal.global_module == "VISITORS")
            { dSet_temp = objStorProc.sp_getMajorTables("visitors"); }


            doSearch3();

        }
        void doSearch3()
        {

            try
            {
                if (dSet_temp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dSet_temp.Tables[0]);
                    //dv.Sort = "No_formatdate ASC";


                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "MICRO")
                    {

                    }

                    else if (myglobal.global_module == "fg_inventory_bulk")
                    {
                        ////takla
                        //dv.RowFilter = "FGFEEDCODE_ like '%" + Cbfeedcode.Text + "%' AND Bag_Bulk_ like '%" + Cbbagbulk.Text + "%' AND _FG_Date_ like '%" + Cbfgdate.Text + "%' AND Total_ >'0'";
                        dv.RowFilter = "Total_ >'0'";

                        dgvfgdate.DataSource = dv;
                        dgvfgdate.Sort(dgvfgdate.Columns["No_formatdate_"], ListSortDirection.Ascending);



                    }
                    else if (myglobal.global_module == "fg_inventory_bag")
                    {
                        //dv.RowFilter = "FGFEEDCODE like '%" + Cbfeedcode.Text + "%' AND Bag_Bulk like '%" + Cbbagbulk.Text + "%' AND FG_Date_ like '%" + Cbfgdate.Text + "%'";
                        dgvprodd.DataSource = dv;
                        dgvprodd.Sort(dgvprodd.Columns["No_formatdate"], ListSortDirection.Ascending);
                        

                    }





                    prodtotal.Text = dgvprodd.RowCount.ToString();

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

        }





        //public void load_search2()
        //{
        //    dset_emp.Clear();

        //    if (myglobal.global_module == "EMPLOYEE")
        //    { dset_emp = objStorProc.sp_getMajorTables("employee"); }
        //    else if (myglobal.global_module == "MICRO")
        //    { dset_emp = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
        //    else if (myglobal.global_module == "fg_inventory_bulk")
        //    { dset_emp = objStorProc.sp_getMajorTables("fg_inventory_overall"); }
        //    else if (myglobal.global_module == "fg_inventory_bag")
        //    { dset_emp = objStorProc.sp_getMajorTables("fg_inventory_overall"); }
        //    else if (myglobal.global_module == "RESIGNED EMPLOYEE")
        //    { dset_emp = objStorProc.sp_getMajorTables("employee_B"); }
        //    else if (myglobal.global_module == "PHONEBOOK")
        //    { dset_emp = objStorProc.sp_getMajorTables("phonebook"); }
        //    else if (myglobal.global_module == "DA")
        //    { dset_emp = objStorProc.sp_getMajorTables("get_da"); }
        //    else if (myglobal.global_module == "ATTENDANCE")
        //    { dset_emp = objStorProc.sp_getMajorTables("attendance_monitoring"); }
        //    else if (myglobal.global_module == "VISITORS")
        //    { dset_emp = objStorProc.sp_getMajorTables("visitors"); }


        //    doSearch();

        //}

        //private void doSearch()
        //{

        //    try
        //    {
        //        if (dset_emp.Tables.Count > 0)
        //        {
        //            DataView dv = new DataView(dset_emp.Tables[0]);



        //            if (myglobal.global_module == "EMPLOYEE")
        //            {

        //            }
        //            else if (myglobal.global_module == "MICRO")
        //            {

        //            }

        //            else if (myglobal.global_module == "fg_inventory_bulk")
        //            {
        //                dv.RowFilter = "FeedCode like '%" + Cbfeedcode.Text + "%' AND BULK_INVENTORY > '0'";
        //                dgvFGInventory.DataSource = dv;


        //            }
        //            else if (myglobal.global_module == "fg_inventory_bag")
        //            {
        //                dv.RowFilter = "FeedCode like '%" + Cbfeedcode.Text + "%' AND BAG_INVENTORY > '0'";
        //                dgvFGInventory.DataSource = dv;


        //            }






        //            totalrecordfg.Text = dgvFGInventory.RowCount.ToString();
        //        }
        //    }
        //    catch (SyntaxErrorException)
        //    {
        //        MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }
        //    catch (EvaluateException)
        //    {
        //        MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        return;
        //    }

        //}



        public void load_search4()
        {
            dset_date.Clear();


            if (myglobal.global_module == "EMPLOYEE")
            { dset_date = objStorProc.sp_getMajorTables("employee"); }
            else if (myglobal.global_module == "MICRO")
            { dset_date = objStorProc.sp_getMajorTables("micro_raw_materialsnew"); }
            else if (myglobal.global_module == "fg_inventory_bulk")
            {
                //load_fgdatebulk();
                //dset_date = objStorProc.sp_getMajorTables("Callfgdatebulkfinance");
                dset_date = objStorProc.sp_GetCategory("Callfgdatebulkfinance",0, Cbfeedcode.Text, Cbbagbulk.Text,"");
            }

            else if (myglobal.global_module == "fg_inventory_bag")
            {
                //load_fgdate();
                //dset_date = objStorProc.sp_getMajorTables("Callfgdate");
                dset_date = objStorProc.sp_GetCategory("Callfgdate", 0, Cbfeedcode.Text, Cbbagbulk.Text, "");
            }
            else if (myglobal.global_module == "RESIGNED EMPLOYEE")
            { dset_date = objStorProc.sp_getMajorTables("employee_B"); }
            else if (myglobal.global_module == "PHONEBOOK")
            { dset_date = objStorProc.sp_getMajorTables("phonebook"); }
            else if (myglobal.global_module == "DA")
            { dset_date = objStorProc.sp_getMajorTables("get_da"); }
            else if (myglobal.global_module == "ATTENDANCE")
            { dset_date = objStorProc.sp_getMajorTables("attendance_monitoring"); }
            else if (myglobal.global_module == "VISITORS")
            { dset_date = objStorProc.sp_getMajorTables("visitors"); }


            doSearch4();

        }
        void doSearch4()
        {

            try
            {
                if (dset_date.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_date.Tables[0]);
                    //dv.Sort = "No_formatdate_ ASC";


                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "MICRO")
                    {

                    }

                    else if (myglobal.global_module == "fg_inventory_bulk")
                    {


                        //dv.RowFilter = "FGFEEDCODE_ like '%" + Cbfeedcode.Text + "%' AND Bag_Bulk_ like '%" + Cbbagbulk.Text + "%' AND Total_>'0'";
                        //dgvfgdate.DataSource = dv;
                        //dgvfgdate.Sort(dgvfgdate.Columns["No_formatdate_"], ListSortDirection.Ascending);



                        //DataView ds = new DataView(dset_date.Tables[0]);
                        //dv.RowFilter = "FGFC like '%" + Cbfeedcode.Text + "%' AND BB like '%" + Cbbagbulk.Text + "%' AND T >'0'";
                        dv.RowFilter = "T >'0'";
                        dgvFGdatebulk.DataSource = dv;
                        dgvFGdatebulk.Sort(dgvFGdatebulk.Columns["NF"], ListSortDirection.Ascending);



                        //keni



                    }
                    else if (myglobal.global_module == "fg_inventory_bag")
                    {
                        //dv.RowFilter = "FGFEEDCODE_ like '%" + Cbfeedcode.Text + "%' AND Bag_Bulk_ like '%" + Cbbagbulk.Text + "%'";
                        dgvfgdate.DataSource = dv;
                        dgvfgdate.Sort(dgvfgdate.Columns["No_formatdate_"], ListSortDirection.Ascending);

                       


                        //lkeni

                    }



                    fgdatetotal.Text = dgvfgdate.RowCount.ToString();

                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

        }

        private void Enablequantity()
        {

            if (Txtbxfeedtype.Text == String.Empty)
            {
                Txtbxquantity.Enabled = false;
            }
            else
            {

                Txtbxquantity.Enabled = true;

            }
        }

        private void Cbbagbulk_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtbxavailable.Text = String.Empty;
            Txtbxfeedtype.Text = String.Empty;
            //Cmbfgdate.Text = String.Empty;
           
            if (Cbfeedcode.SelectedIndex == -1)
            {
                dgvfgdate.ClearSelection();
                dgvprodd.ClearSelection();
                Cbfgdate.SelectedIndex = -1;
                return;
            }

            if (Cbbagbulk.SelectedIndex == -1)
            {
                dgvfgdate.ClearSelection();
                dgvprodd.ClearSelection();
                Cbfgdate.SelectedIndex = -1;
                return;
            }



            else
            {

                if (Cbbagbulk.Text == "BAGGING")
                {
                    myglobal.global_module = "fg_inventory_bag";
                    load_fgdate();
                    //load_search2();
                    load_search3();
                    load_search4();
                    Showcount();

                    Enablequantity();

                    int sum = 0;
                    for (int i = 0; i < dgvprodd.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvprodd.Rows[i].Cells["Total"].Value);
                    }
                    txtbxavailable.Text = sum.ToString();

                    //Cbfgdate.Items.Clear();
                    load_proddate();
                    Cbfgdate.SelectedIndex = -1;

                    //foreach (DataGridViewRow row in dgvfgdate.Rows)
                    //{
                    //    Cbfgdate.Items.Add(row.Cells["_FG_Date_"].Value.ToString());
                    //}

                    if (Cbfgdate.Text.Trim() == String.Empty)
                    {
                        stockonhand.Text = "0";
                        //return;
                    }

                }

                else
                {

                    myglobal.global_module = "fg_inventory_bulk";
                    load_fgdatebulk();
                    load_fgdatebulkfinance();
                    //load_search2();
                    load_search3();
                    load_search4();

                    Enablequantity();

                    int sum = 0;
                    for (int i = 0; i < dgvfgdate.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvfgdate.Rows[i].Cells["Total_"].Value);
                    }
                    txtbxavailable.Text = sum.ToString();

                    load_proddate();
                    Cbfgdate.SelectedIndex = -1;
                    //Cbfgdate.Items.Clear();

                    //foreach (DataGridViewRow row in dgvFGdatebulk.Rows)
                    //{
                    //    Cbfgdate.Items.Add(row.Cells["FGD"].Value.ToString());
                    //}

                    if (Cbfgdate.Text.Trim() == String.Empty)
                    {
                        stockonhand.Text = "0";
                        //return;
                    }
                }

            }

        }


        private void tsaddlinebtn_Click(object sender, EventArgs e)
        {
            if (txtremarks.Text == String.Empty)

            {
                EmptyFieldNotify();
                txtremarks.Focus();
                return;


            }

            if (Cbfeedcode.SelectedIndex == -1)
            {
                EmptyFieldNotify();
                Cbfeedcode.Select();
                Cbfeedcode.Focus();
                return;
            }


            if (Cbbagbulk.SelectedIndex == -1)
            {
                EmptyFieldNotify();
                Cbbagbulk.Select();
                Cbbagbulk.Focus();
                return;
            }


            if (Cbfgdate.SelectedIndex == -1)
            {

                EmptyFieldNotify();
                Cbfgdate.Select(); 
                Cbfgdate.Focus();
                return;
            }
            
            
            if (Txtbxquantity.Text == String.Empty)
            {
                EmptyFieldNotify();
                Txtbxquantity.Focus();
                return;
            }


            if (Convert.ToInt32(Txtbxquantity.Text) > Convert.ToInt32(txtbxavailable.Text))
            {
                InvalidQTY();
                Txtbxquantity.Focus();
                return; //3/22/2021
            }


            if (Txtbxfeedtype.Text == String.Empty)
            {

                EmptyFieldNotify();
                Txtbxfeedtype.Focus();
                return;
            }

            if (Cbbagbulk.Text == "BULK ENTRY")
            {

               
                {
                    if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to add this feedcode '" + Cbfeedcode.Text + "' ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        

                            myglobal.global_module = "fg_inventory_bulk";
                            load_fgdatebulk();
                            load_fgdatebulkfinance();
                            //load_search2();


                            load_search3();
                            load_search4();

                            Enablequantity();

                            int sum = 0;
                            for (int i = 0; i < dgvfgdate.Rows.Count; ++i)
                            {
                                sum += Convert.ToInt32(dgvfgdate.Rows[i].Cells["Total_"].Value);
                            }
                            txtbxavailable.Text = sum.ToString();

                            if (Convert.ToInt32(Txtbxquantity.Text) > Convert.ToInt32(txtbxavailable.Text))
                            {

                            Clear();
                            LoadFeedcodeDropdown();
                            load_FGCategory();

                            load_proddate();
                            Cbfgdate.SelectedIndex = -1;
                            //Cbfgdate.Items.Clear();
                            TwoModulesareRunning();
                            Txtbxquantity.Focus();
                            Txtbxquantity.Text = String.Empty;
                            return; //4/29/2021
                            }
                      




                        Refreshmo();
                        Clear();
                        LoadFeedcodeDropdown();
                        load_FGCategory();
                        load_proddate();
                        Cbfgdate.SelectedIndex = -1;
                        //Cbfgdate.Items.Clear();

                        if (Lblrecordss.Text == "0")
                        {

                            cboCustomer.Enabled = true;

                        }

                        else
                        {

                            cboCustomer.Enabled = false;

                        }

                        Txtbxquantity.Enabled = false;
                    }

                    else
                    {

                        return;

                    }

                }


            }




            else

            {

                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to add this feedcode '" + Cbfeedcode.Text + "' ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    
                        myglobal.global_module = "fg_inventory_bag";
                        load_fgdate();
                        //load_search2();


                        load_search3();
                        load_search4();
                        Showcount();

                        Enablequantity();
                        int sum = 0;



                        for (int i = 0; i < dgvprodd.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dgvprodd.Rows[i].Cells["Total"].Value);
                        }

                        txtbxavailable.Text = sum.ToString();

                        if (Convert.ToInt32(Txtbxquantity.Text) > Convert.ToInt32(txtbxavailable.Text))
                        {
                        Clear();
                        LoadFeedcodeDropdown();
                        load_FGCategory();
                        load_proddate();
                        Cbfgdate.SelectedIndex = -1;
                        //Cbfgdate.Items.Clear();
                        Txtbxquantity.Text = String.Empty;
                        Txtbxquantity.Focus();
                        TwoModulesareRunning();
                        return; //4/29/2021
                        }
                  








                    Refreshmo();
                    Clear();
                    LoadFeedcodeDropdown();
                    load_FGCategory();
                    load_proddate();
                    Cbfgdate.SelectedIndex = -1;
                    //Cbfgdate.Items.Clear();
                    if (Lblrecordss.Text == "0")
                    {

                        cboCustomer.Enabled = true;

                    }

                    else
                    {

                        cboCustomer.Enabled = false;

                    }

                    Txtbxquantity.Enabled = false;
                }

                else
                {

                    return;

                }


            }
        }

        public void Clear()

        {
            row1.Text = String.Empty;
            row2.Text = String.Empty;
            row3.Text = String.Empty;
            row4.Text = String.Empty;
            row5.Text = String.Empty;
            row6.Text = String.Empty;

            txtrow2.Text = String.Empty;
            txtrow3.Text = String.Empty;
            txtrow4.Text = String.Empty;
            txtrow5.Text = String.Empty;
            txtrow6.Text = String.Empty;
            txtrow7.Text = String.Empty;

            rowone.Text = String.Empty;
            row1nrow2.Text = String.Empty;
            row1torow3.Text = String.Empty;
            row1torow4.Text = String.Empty;
            row1torow5.Text = String.Empty;
            row1torow6.Text = String.Empty;

            txtfgdatetotal.Text = String.Empty;
            txtfgtotal.Text = String.Empty;
            txtlefttotal.Text = String.Empty;
            txtavaildate.Text = String.Empty;
            txtfinal.Text = String.Empty;
            txtbxavailable.Text = String.Empty;
            Cmbfgdate.Text = String.Empty;
            txtboxprodid.Text = String.Empty;
            fgid.Text = String.Empty;

            Cbbagbulk.SelectedIndex = -1;
            Cbfeedcode.SelectedIndex = -1; 
            Txtbxfeedtype.Text = String.Empty;
            Txtbxquantity.Text = String.Empty;
            Cbfgdate.SelectedIndex = -1;
        }
        public void load_Moveorder()
        {
            string mcolumns = "test,order_no,feed_code,feed_type,sack_bin,uom,qty,Pdate,Fdate,production,my_fgid,added_by";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModuleMoveOrder(dsetHeader, Dgvmain, mcolumns, "Callissue",lblsasa.Text.ToString(),0,"","");
            Lblrecordss.Text = Dgvmain.RowCount.ToString();
            Dgvmain.Columns["production"].Visible = false;
            Dgvmain.Columns["Pdate"].Visible = false;
            Dgvmain.Columns["my_fgid"].Visible = false;
            Dgvmain.Columns["added_by"].Visible = false;
            Dgvmain.Columns["order_no"].Visible = false;

            if (Lblrecordss.Text == "0")

            {
                tsconfirmorderbtn.Enabled = false;
                tscancelbtn.Enabled = false;
            }
            else
            {
              
                tsconfirmorderbtn.Enabled = true;
                tscancelbtn.Enabled = true;
            }

            int sum = 0;
            for (int i = 0; i < Dgvmain.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(Dgvmain.Rows[i].Cells["qty"].Value);

            }

            lblquantitymain.Text = sum.ToString();

            if (lblquantitymain.Text == "0")
            {
                lblquantitymain.Text = "27";

                ////lblquantitymain.Visible = false;


            }
            else
            {


                lblquantitymain.Visible = true;
            }


        }

        public void load_prodid()

        {
            string mcolumns = "test,FGID,ProdID,FGFEEDCODE,FGFEEDTYPE,Bag_Bulk,Total,No_formatdate,FG_Date_,StatusReceived,StatusReceipt,StatusMoveorder";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvprodd, mcolumns, "Callprodid");
            prodtotal.Text = dgvprodd.RowCount.ToString();

        }
        public void load_fgdate()

        {
            string mcolumns = "test,ProductionID,FGFEEDCODE_,FGFEEDTYPE_,Bag_Bulk_,Total_,No_formatdate_,_FG_Date_,ReceivedStatus,ReceiptStatus,MoveorderStatus";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvfgdate, mcolumns, "Callfgdate");
            fgdatetotal.Text = dgvfgdate.RowCount.ToString();

       

        }

        public void load_fgdatebulkfinance()

        {
            string mcolumns = "test,PID,FGFC,FGFT,BB,T,NF,FGD,RS,RecS,MS";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvFGdatebulk, mcolumns, "Callfgdatebulkfinance");
         


        }

        public void load_fgdatebulk()

        {
            string mcolumns = "test,ProductionID,FGFEEDCODE_,FGFEEDTYPE_,Bag_Bulk_,No_formatdate_,_FG_Date_,ReceivedStatus,ReceiptStatus,MoveorderStatus,_FGID,Total_,Quantity_Moveorder,Quantity_FG";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvfgdate, mcolumns, "Callfgdatebulk");
            fgdatetotal.Text = dgvfgdate.RowCount.ToString();

            //Cbfgdate.Items.Clear();

            //foreach (DataGridViewRow row in dgvfgdate.Rows)
            //{
            //    Cbfgdate.Items.Add(row.Cells["_FG_Date_"].Value.ToString());
               
            //}

        }


        public void load_fginvetory()

        {
            string mcolumns = "test,FeedCode,FeedType,BagsCount,BAG_RECEIPT,BULK_RECEIPT,GrandTotal,MoveOrder,ISSUE,BAG_ISSUE,BULK_ISSUE,INVENTORY,BULK_INVENTORY,BAG_INVENTORY";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            pointer_module.populateModule(dsetHeader, dgvFGInventory, mcolumns, "fg_inventory_overall");
            totalrecordfg.Text = dgvFGInventory.RowCount.ToString();


        }



        private void Lblrecordss_TextChanged(object sender, EventArgs e)
        {
            lblrecords.Text = Dgvmain.RowCount.ToString();
        }



        private void dgvfgdate_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvfgdate.RowCount > 0)
            {
                if (dgvfgdate.CurrentRow != null)
                {
                    if (dgvfgdate.CurrentRow.Cells["FGFEEDCODE_"].Value != null)
                    {

                        txtfgdatetotal.Text = dgvfgdate.CurrentRow.Cells["_FG_Date_"].Value.ToString();
                        Txtbxfeedtype.Text = dgvfgdate.CurrentRow.Cells["FGFEEDTYPE_"].Value.ToString();
                        txtfgtotal.Text = dgvfgdate.CurrentRow.Cells["Total_"].Value.ToString();

                        txtboxprodid.Text = dgvfgdate.CurrentRow.Cells["ProductionID"].Value.ToString();




                        if (Cbbagbulk.Text == "BAGGING")
                        {


                            if (dgvfgdate.CurrentRow.Cells["Total_"].Value.ToString() == "0")
                            {

                                txtavaildate.Text = String.Empty;
                                txtbxavailable.Text = String.Empty;
                                fgidbulk.Text = String.Empty;

                            }
                            else
                            {
                                txtavaildate.Text = dgvfgdate.CurrentRow.Cells["Total_"].Value.ToString();

                            }


                        }

                        else

                        {

                            fgidbulk.Text = dgvfgdate.CurrentRow.Cells["_FGID"].Value.ToString();
                            if (dgvfgdate.Rows[0].Cells["Total_"].Value.ToString() == "0")
                            {
                                txtavaildate.Text = String.Empty;
                                txtbxavailable.Text = String.Empty;
                                fgidbulk.Text = String.Empty;
                            }
                            else
                            {

                                txtavaildate.Text = dgvfgdate.CurrentRow.Cells["Total_"].Value.ToString();

                            }

                        }

                    }
                   

                }
                else
                {
                    Txtbxfeedtype.Text = "";

                }


            }
        }

        private void dgvprodd_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvprodd.RowCount > 0)
            {
                if (dgvprodd.CurrentRow != null)
                {
                    if (dgvprodd.CurrentRow.Cells["FGFEEDCODE"].Value != null)
                    {


                        validfgdate.Text = dgvprodd.CurrentRow.Cells["FG_Date_"].Value.ToString();
                        validprodid.Text = dgvprodd.CurrentRow.Cells["ProdID"].Value.ToString();

                        validfgid.Text = dgvprodd.CurrentRow.Cells["FGID"].Value.ToString();
                        fgid.Text = dgvprodd.CurrentRow.Cells["FGID"].Value.ToString();

                        Cmbfgdate.Text = dgvprodd.CurrentRow.Cells["FG_Date_"].Value.ToString();


                        if (Cbbagbulk.Text == "BAGGING")
                        {


                            if (dgvprodd.CurrentRow.Cells["Total"].Value.ToString() == "0")
                            {

                                txtavaildate.Text = String.Empty;
                                txtbxavailable.Text = String.Empty;

                            }
                            else
                            {
                                txtavaildate.Text = dgvprodd.CurrentRow.Cells["Total"].Value.ToString();

                            }


                        }

                        else

                        {


                            if (dgvprodd.Rows[0].Cells["Total"].Value.ToString() == "0")
                            {
                                txtavaildate.Text = String.Empty;
                                txtbxavailable.Text = String.Empty;
                            }
                            else
                            {

                                txtavaildate.Text = dgvprodd.CurrentRow.Cells["Total"].Value.ToString();

                            }

                        }

                    }

                }


            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvprodd.Rows.Count >= 1)
                {


                    int i = dgvprodd.CurrentRow.Index + 1;



                    if (Cbbagbulk.Text == "BAGGING")
                    {

                        if (i >= -1 && i < Convert.ToInt64(Txtbxquantity.Text))
                        {
                            dgvprodd.CurrentCell = dgvprodd.Rows[i].Cells["FGID"];

                            Queryshowmoveorder();


                        }

                        else
                        {

                            // MessageBox.Show("Bagging");

                            load_Moveorder();
                            load_prodid();
                            load_fgdate();


                            return;
                        }
                    }

                    else

                    //balik naten mamaya
                    {
                        //if (i >= -1 && i < Convert.ToInt64(dgvprodd.Rows.Count))
                        //{
                        //    dgvprodd.CurrentCell = dgvprodd.Rows[i].Cells["FGID"];

                        //   if(Txtbxquantity.Text== row1nrow2.Text)
                        //    { 
                        //    int s = dgvfgdate.CurrentRow.Index + 1;
                        //    dgvprodd.CurrentCell = dgvprodd.Rows[s].Cells["FGID"];
                        //        MessageBox.Show("Bulk yayan bap");
                        //        Queryshowmoveorder();
                        //    }

                        //}

                        //else

                        //{
                        //    MessageBox.Show("stop");
                        //    //load_Moveorder();
                        //    //load_prodid();
                        //    // load_fgdate();


                        //    return;


                        //}


                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }






            btnloop_Click(sender, e);



        }

        private void btnloop_Click(object sender, EventArgs e)
        {
            btnnext_Click(sender, e);
        }

        private void Queryconfirmorderfinal()
        {

            dSet.Clear();
            dSet = objStorProc.rdf_sp_move_order(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", lblsasa.Text, dateonly.Text.Trim(), 0, "", "", "", "confirmorderfinalissue");

        }


        private void Queryupdaterdfmoveordertable()
        {

            dSet.Clear();
            dSet = objStorProc.rdf_sp_move_order(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", lblsasa.Text, "", 0, "", "", "", "updaterdfmoveordertableissue");


        }

        private void Queryshowmoveorder()

        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_move_order(0, fgid.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", lblsasa.Text, "", 0, "", "", "", "showaddlineissue");

        }

        private void Queryshowmoveorderbulk()

        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_move_order(0, fgidbulk.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", lblsasa.Text, "", 0, "", "", "", "showaddlineissue");

        }

        //private void Queryinsertmoveorder()
        //{
        //    dSet.Clear();
        //    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), Cmbfgdate.Text.Trim(), Txtbxquantity.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "add");

        //}
        private void Querycancelmoveorderbagging()

        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_move_order(0, "", "", "", "", "", "", feedcodemain.Text.Trim(), "", "", fgdate.Text.Trim(), "", "", "", "", "", productionmain.Text.Trim(), lblsasa.Text, "", 0, "", "", "", "cancelissuebagging");
        }


        private void Querycancelmoveorder()

        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_move_order(0, "", "", "", "", "", "", feedcodemain.Text.Trim(), "", bagbulkmain.Text.Trim(), fgdate.Text.Trim(), "", "", "", "", "", productionmain.Text.Trim(), lblsasa.Text, "", 0, "", "", "", "cancelissue");
        }


        private void Querycancelrdfmoveordertable()
        {
            dSet.Clear();
            dSet = objStorProc.rdf_sp_move_order(0, "", "", "", "", "", "", feedcodemain.Text.Trim(), "", bagbulkmain.Text.Trim(), fgdate.Text.Trim(), quantity.Text.Trim(), "", "", "", "", productionmain.Text.Trim().ToString(), lblsasa.Text, "", 0, lblsasa.Text.Trim(), dateonly.Text.Trim(), "", "cancelrdfmoveordertableissue");



        }


        private void Feedcodetransaction()

        {

            dSet.Clear();
            dSet = objStorProc.sp_rdf_fg_feedcodetransaction(0, productionmain.Text.Trim(), feedcodemain.Text.Trim(), feedtypemain.Text.Trim(), bagbulkmain.Text.Trim(), txtkg.Text.Trim().ToString(), "", fgdate.Text.Trim().ToString(), dateonly.Text.Trim(), "ISSUE", txtremarks.Text, lblsasa.Text.Trim(), "add");


        }

        private void Queryfinalmoveorder()

        {
            dSet.Clear(); 
             dSet = objStorProc.rdf_sp_new_finish_goods(0, txtorder.Text.Trim(), feedcodemain.Text.Trim(), feedtypemain.Text.Trim(), quantity.Text.Trim(), txtbatch.Text.Trim(),
                dateonly.Text.Trim(), fgdate.Text.Trim(), fgdate.Text.Trim(), fgdate.Text.Trim(), fgdate.Text.Trim(), "0", lblsasa.Text.Trim(), txtkg.Text.Trim(), txtmoveorderno.Text,
                quantity.Text.Trim(), ordermain.Text.Trim(), txtbatch.Text.Trim(), quantity.Text.Trim(), bagbulkmain.Text.Trim(), txtremarks.Text, fgdate.Text.Trim(), "0", "addbulk_issue_hollow");
        }

        private void btnnextmain_Click(object sender, EventArgs e)
        {
            if (Dgvmain.Rows.Count >= 1)
            {


                int i = Dgvmain.CurrentRow.Index + 1;
                if (i >= -1 && i < Dgvmain.Rows.Count)
                {
                    Dgvmain.CurrentCell = Dgvmain.Rows[i].Cells[0];

                    Queryfinalmoveorder();
                    Feedcodetransaction();
                    Queryconfirmorderfinal();
                    Queryupdaterdfmoveordertable();


                }


                else
                {

                    load_Moveorder();
                    Calldata();
                    return;
                }

                btnmainloop_Click(sender, e);
            }
        }



        

        private void Dgvmain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (Dgvmain.RowCount > 0)
            {
                if (Dgvmain.CurrentRow != null)
                {
                    if (Dgvmain.CurrentRow.Cells["feed_code"].Value != null)
                    {
                        ordermain.Text = Dgvmain.CurrentRow.Cells["order_no"].Value.ToString();
                        feedcodemain.Text = Dgvmain.CurrentRow.Cells["feed_code"].Value.ToString();
                        feedtypemain.Text = Dgvmain.CurrentRow.Cells["feed_type"].Value.ToString();
                        bagbulkmain.Text = Dgvmain.CurrentRow.Cells["sack_bin"].Value.ToString();
                        uommain.Text = Dgvmain.CurrentRow.Cells["uom"].Value.ToString();
                        quantity.Text = Dgvmain.CurrentRow.Cells["qty"].Value.ToString();
                        fgdate.Text = Dgvmain.CurrentRow.Cells["Fdate"].Value.ToString();
                        productionmain.Text = Dgvmain.CurrentRow.Cells["production"].Value.ToString();
                        myfgidbulk.Text = Dgvmain.CurrentRow.Cells["myfg_id"].Value.ToString();


                    }
                }


            }
        }

        private void btnmainloop_Click(object sender, EventArgs e)
        {
            btnnextmain_Click(sender, e);
        }



        private void Dgvmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (Dgvmain.RowCount > 0)
                {
                    if (Dgvmain.CurrentRow != null)
                    {
                        if (Dgvmain.CurrentRow.Cells["feed_code"].Value != null)

                        {
                            tscancelbtn.Enabled = true;
                            ordermain.Text = Dgvmain.CurrentRow.Cells["order_no"].Value.ToString();
                            feedcodemain.Text = Dgvmain.CurrentRow.Cells["feed_code"].Value.ToString();
                            feedtypemain.Text = Dgvmain.CurrentRow.Cells["feed_type"].Value.ToString();
                            bagbulkmain.Text = Dgvmain.CurrentRow.Cells["sack_bin"].Value.ToString();
                            uommain.Text = Dgvmain.CurrentRow.Cells["uom"].Value.ToString();
                            quantity.Text = Dgvmain.CurrentRow.Cells["qty"].Value.ToString();
                            fgdate.Text = Dgvmain.CurrentRow.Cells["Fdate"].Value.ToString();
                            productionmain.Text = Dgvmain.CurrentRow.Cells["production"].Value.ToString();
                            myfgidbulk.Text = Dgvmain.CurrentRow.Cells["myfg_id"].Value.ToString();

                        }
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }





        }
        private static bool IsNameValid(string name)
        {
            if (string.IsNullOrEmpty(name))
                return true;
            else if (name.Any(c => c < '0' || c > '9'))

            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.info;
                popup.TitleText = "Fedora Notifications";
                popup.TitleColor = Color.White;
                popup.TitlePadding = new Padding(95, 7, 0, 0);
                popup.TitleFont = new Font("Tahoma", 10);
                popup.ContentText = "Sorry your Quantity must contain digits only!";
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


                return false;
            }
            else if (name.StartsWith("0"))
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.info;
                popup.TitleText = "Fedora Notifications";
                popup.TitleColor = Color.White;
                popup.TitlePadding = new Padding(95, 7, 0, 0);
                popup.TitleFont = new Font("Tahoma", 10);
                popup.ContentText = "Sorry the quantity must not start from 0! ";
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

                return false;
            }

            return true;
        }


        private void Txtbxquantity_TextChanged(object sender, EventArgs e)

        {
            if (!IsNameValid(Txtbxquantity.Text))
            {
                Txtbxquantity.Text = string.Concat(Txtbxquantity
                .Text
                .Where(c => c >= '0' && c <= '9')
                .SkipWhile(c => c == '0'));
            }



            if (Txtbxquantity.Text.Trim() == string.Empty)
            {
                txttimes50.Text = "";
                txtbacthno.Text = "";
            }
            else
            {
                txttimes50.Text = (float.Parse(Txtbxquantity.Text) * 50).ToString();
                txtbacthno.Text = (float.Parse(Txtbxquantity.Text) / 40).ToString();
            }
            Solve();
            Availablestock();

        }

        private void Availablestock()
        {
            try
            {
                if (Txtbxquantity.Text == String.Empty)
                {
                    lblstock.Text = "0";
                    return;
                }
                else
                {
                    if (txtbxavailable.Text == String.Empty)
                    {
                        return;
                    }
                    else
                    {
                        int txtquantity = Convert.ToInt32(Txtbxquantity.Text);
                        int txtavailable = Convert.ToInt32(txtbxavailable.Text);
                        int total = 0;

                        total = txtavailable - txtquantity;

                        if (total <= 0)
                        {
                            lblstock.Text = "0";

                        }
                        else
                        {
                            lblstock.Text = total.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void Solve()
        {

            try
            {

                Showcount();

                if (Txtbxquantity.Text == String.Empty)
                {
                    return;
                }

                else
                {

                    int totalquantity = Convert.ToInt32(Txtbxquantity.Text);
                    int availquantity = Convert.ToInt32(txtbxavailable.Text);
                    int sum = 0;

                    sum = availquantity - totalquantity;


                    txtlefttotal.Text = sum.ToString();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                if (Txtbxquantity.Text == String.Empty)

                {
                    return;
                }

                else
                {
                    int totalquantity = Convert.ToInt32(Txtbxquantity.Text);
                    int availquantity = Convert.ToInt32(txtavaildate.Text);
                    int sum = 0;

                    sum = totalquantity - availquantity;


                    txtfinal.Text = sum.ToString();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //row2
            try
            {


                if (row1.Text == String.Empty)
                {

                    txtrow2.Text = String.Empty;
                    return;

                }
                else if (Txtbxquantity.Text == String.Empty)
                {


                    return;

                }
                else
                {


                    int totalquantity = Convert.ToInt32(Txtbxquantity.Text);
                    int row1quantity = Convert.ToInt32(row1.Text);
                    int sum = 0;


                    sum = totalquantity - row1quantity;


                    txtrow2.Text = sum.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //row3
            try
            {


                if (row2.Text == String.Empty)
                {

                    txtrow3.Text = String.Empty;
                    row1nrow2.Text = String.Empty;
                    return;



                }
                else if (Txtbxquantity.Text == String.Empty)
                {


                    return;

                }

                else
                {

                    int totalquantity = Convert.ToInt32(Txtbxquantity.Text);
                    int row1quantity = Convert.ToInt32(row1.Text);
                    int row2quantity = Convert.ToInt32(row2.Text);
                    int sum = 0;
                    int total = 0;
                    sum = totalquantity - (row2quantity + row1quantity);


                    txtrow3.Text = sum.ToString();





                    total = row2quantity + row1quantity;
                    row1nrow2.Text = total.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            //row4
            try
            {


                if (row3.Text == String.Empty)
                {
                    txtrow4.Text = String.Empty;
                    row1torow3.Text = String.Empty;
                    return;



                }
                else if (Txtbxquantity.Text == String.Empty)
                {


                    return;

                }

                else
                {

                    int totalquantity = Convert.ToInt32(Txtbxquantity.Text);
                    int row1quantity = Convert.ToInt32(row1.Text);
                    int row2quantity = Convert.ToInt32(row2.Text);
                    int row3quantity = Convert.ToInt32(row3.Text);
                    int sum = 0;
                    int totalsum = 0;
                    int total = 0;
                    sum = row3quantity + (row2quantity + row1quantity);

                    totalsum = totalquantity - sum;
                    txtrow4.Text = totalsum.ToString();





                    total = row3quantity + (row2quantity + row1quantity);
                    row1torow3.Text = total.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {


                if (row4.Text == String.Empty)
                {
                    txtrow5.Text = String.Empty;
                    row1torow4.Text = String.Empty;
                    return;



                }
                else if (Txtbxquantity.Text == String.Empty)
                {


                    return;

                }

                else
                {

                    int totalquantity = Convert.ToInt32(Txtbxquantity.Text);
                    int row1quantity = Convert.ToInt32(row1.Text);
                    int row2quantity = Convert.ToInt32(row2.Text);
                    int row3quantity = Convert.ToInt32(row3.Text);
                    int row4quantity = Convert.ToInt32(row4.Text);
                    int sum = 0;
                    int totalsum = 0;
                    int total = 0;
                    sum = (row4quantity + row3quantity) + (row2quantity + row1quantity);

                    totalsum = totalquantity - sum;
                    txtrow5.Text = totalsum.ToString();





                    total = (row4quantity + row3quantity) + (row2quantity + row1quantity);
                    row1torow4.Text = total.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            try
            {


                if (row5.Text == String.Empty)
                {
                    txtrow6.Text = String.Empty;
                    row1torow5.Text = String.Empty;
                    return;
                }
                else if (Txtbxquantity.Text == String.Empty)
                {
                    return;
                }

                else
                {

                    int totalquantity = Convert.ToInt32(Txtbxquantity.Text);
                    int row1quantity = Convert.ToInt32(row1.Text);
                    int row2quantity = Convert.ToInt32(row2.Text);
                    int row3quantity = Convert.ToInt32(row3.Text);
                    int row4quantity = Convert.ToInt32(row4.Text);
                    int row5quantitity = Convert.ToInt32(row5.Text);
                    int sum = 0;
                    int sum5 = 0;
                    int totalsum = 0;
                    int total = 0;
                    int finaltotal = 0;
                    sum = (row4quantity + row3quantity) + (row2quantity + row1quantity);

                    sum5 = sum + row5quantitity;

                    totalsum = totalquantity - sum5;
                    txtrow6.Text = totalsum.ToString();





                    total = (row4quantity + row3quantity) + (row2quantity + row1quantity);
                    finaltotal = total + row5quantitity;

                    row1torow5.Text = finaltotal.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {



                if (row6.Text == String.Empty)
                {
                    txtrow7.Text = String.Empty;
                    row1torow6.Text = String.Empty;

                    return;

                }

                else if (Txtbxquantity.Text == String.Empty)
                {


                    return;

                }

                else
                {

                    int totalquantity = Convert.ToInt32(Txtbxquantity.Text);
                    int row1quantity = Convert.ToInt32(row1.Text);
                    int row2quantity = Convert.ToInt32(row2.Text);
                    int row3quantity = Convert.ToInt32(row3.Text);
                    int row4quantity = Convert.ToInt32(row4.Text);
                    int row5quantitity = Convert.ToInt32(row5.Text);
                    int row6quantity = Convert.ToInt32(row6.Text);
                    int sum = 0;
                    int sum5 = 0;
                    int totalsum = 0;
                    int total = 0;
                    int finaltotal = 0;
                    sum = (row4quantity + row3quantity) + (row2quantity + row1quantity);

                    sum5 = sum + (row6quantity + row5quantitity);

                    totalsum = totalquantity - sum5;

                    total = (row4quantity + row3quantity) + (row2quantity + row1quantity);
                    finaltotal = total + (row6quantity + row5quantitity);



                    txtrow7.Text = totalsum.ToString();
                    row1torow6.Text = finaltotal.ToString();
                }









            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }



        public void Showcount()
        {

            if (fgdatetotal.Text == "0")
            {


                return;
            }


            else if (dgvfgdate.Rows.Count == 5)
            {
                row1.Text = dgvfgdate.Rows[0].Cells["Total_"].Value.ToString();
                row2.Text = dgvfgdate.Rows[1].Cells["Total_"].Value.ToString();
                row3.Text = dgvfgdate.Rows[2].Cells["Total_"].Value.ToString();
                row4.Text = dgvfgdate.Rows[3].Cells["Total_"].Value.ToString();
                row5.Text = dgvfgdate.Rows[4].Cells["Total_"].Value.ToString();
                row6.Text = "";
            }
            else if (dgvfgdate.Rows.Count == 4)
            {
                row1.Text = dgvfgdate.Rows[0].Cells["Total_"].Value.ToString();
                row2.Text = dgvfgdate.Rows[1].Cells["Total_"].Value.ToString();
                row3.Text = dgvfgdate.Rows[2].Cells["Total_"].Value.ToString();
                row4.Text = dgvfgdate.Rows[3].Cells["Total_"].Value.ToString();
                row5.Text = "";
                row6.Text = "";
            }

            else if (dgvfgdate.Rows.Count == 3)
            {
                row1.Text = dgvfgdate.Rows[0].Cells["Total_"].Value.ToString();
                row2.Text = dgvfgdate.Rows[1].Cells["Total_"].Value.ToString();
                row3.Text = dgvfgdate.Rows[2].Cells["Total_"].Value.ToString();
                row4.Text = "";
                row5.Text = "";
                row6.Text = "";
            }
            else if (dgvfgdate.Rows.Count == 2)
            {
                row1.Text = dgvfgdate.Rows[0].Cells["Total_"].Value.ToString();
                row2.Text = dgvfgdate.Rows[1].Cells["Total_"].Value.ToString();
                row3.Text = "";
                row4.Text = "";
                row5.Text = "";
                row6.Text = "";
            }
            else if (dgvfgdate.Rows.Count == 1)
            {
                row1.Text = dgvfgdate.Rows[0].Cells["Total_"].Value.ToString();

                row2.Text = "";
                row3.Text = "";
                row4.Text = "";
                row5.Text = "";
                row6.Text = "";
            }
            else
            {
                row1.Text = dgvfgdate.Rows[0].Cells["Total_"].Value.ToString();
                row2.Text = dgvfgdate.Rows[1].Cells["Total_"].Value.ToString();
                row3.Text = dgvfgdate.Rows[2].Cells["Total_"].Value.ToString();
                row4.Text = dgvfgdate.Rows[3].Cells["Total_"].Value.ToString();
                row5.Text = dgvfgdate.Rows[4].Cells["Total_"].Value.ToString();
                row6.Text = dgvfgdate.Rows[5].Cells["Total_"].Value.ToString();
            }

        }


        public void Refreshmo()
        {
            try
            {
                if (Cbbagbulk.Text == "BAGGING")

                {

                    if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1.Text))
                    {

                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), Cbfgdate.Text.Trim(), Txtbxquantity.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                        Queryshowmoveorder();
                        btnnext.PerformClick();
                    }
                    else if (Convert.ToInt32(Txtbxquantity.Text) == Convert.ToInt32(txtbxavailable.Text))
                    {

                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), Cbfgdate.Text.Trim(), txtfgtotal.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                        load_Moveorder();
                        btnnextfg.PerformClick();
                        Queryshowmoveorder();
                        btnnext.PerformClick();

                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1nrow2.Text))

                    {


                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), Cbfgdate.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                        btnnextfg.PerformClick();
                        Queryshowmoveorder();
                        btnnext.PerformClick();



                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow3.Text))

                    {


                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), Cbfgdate.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                        btnnextfg.PerformClick();
                        Queryshowmoveorder();
                        btnnext.PerformClick();



                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow4.Text))

                    {


                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), Cbfgdate.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                        btnnextfg.PerformClick();
                        Queryshowmoveorder();
                        btnnext.PerformClick();



                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))

                    {


                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), Cbfgdate.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                        btnnextfg.PerformClick();
                        Queryshowmoveorder();
                        btnnext.PerformClick();



                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))

                    {


                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), Cbfgdate.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                        btnnextfg.PerformClick();
                        Queryshowmoveorder();
                        btnnext.PerformClick();



                    }

                    else

                    {
                        QtyOver();
                        MessageBox.Show("You've reach the limit of quantity.");

                    }


                }

                //BULK 

                else
                {


                    if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1.Text))
                    {

                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), Txtbxquantity.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");

                        //if (Convert.ToInt32(Txtbxquantity.Text) == Convert.ToInt32(row1.Text))
                        //{

                        //    dSet.Clear();
                        //    dSet = objStorProc.rdf_sp_move_order(0, fgidbulk.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "showaddlinebulk");

                        //}
                        //    Queryshowmoveorder();
                        //   btnnext.PerformClick();
                    }
                    else if (Convert.ToInt32(Txtbxquantity.Text) == Convert.ToInt32(txtbxavailable.Text))
                    {


                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtfgtotal.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                        load_Moveorder();
                        btnnextfg.PerformClick();
                        Queryshowmoveorder();
                        //btnnext.PerformClick();

                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1nrow2.Text))
                    {

                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                        load_Moveorder();
                        Queryshowmoveorderbulk();
                        btnnextfg.PerformClick();

                        //  btnnext.PerformClick();//

                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow3.Text))
                    {

                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                        load_Moveorder();
                        Queryshowmoveorderbulk();
                        btnnextfg.PerformClick();



                        //  btnnext.PerformClick();//

                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow4.Text))
                    {

                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                        load_Moveorder();
                        Queryshowmoveorderbulk();
                        btnnextfg.PerformClick();



                        //  btnnext.PerformClick();//

                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                    {

                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                        load_Moveorder();
                        Queryshowmoveorderbulk();
                        btnnextfg.PerformClick();



                        //  btnnext.PerformClick();//

                    }

                    else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                    {

                        dSet.Clear();
                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row1.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                        load_Moveorder();
                        Queryshowmoveorderbulk();
                        btnnextfg.PerformClick();



                        //  btnnext.PerformClick();//

                    }



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            load_Moveorder();
            // load_fgdate();
            load_prodid();
            Cleartxt();


        }
        

        private void Dgvmain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (Dgvmain.RowCount > 0)
                {
                    if (Dgvmain.CurrentRow != null)
                    {
                        if (Dgvmain.CurrentRow.Cells["feed_code"].Value != null)

                        {
                            tscancelbtn.Enabled = true;
                            ordermain.Text = Dgvmain.CurrentRow.Cells["order_no"].Value.ToString();
                            feedcodemain.Text = Dgvmain.CurrentRow.Cells["feed_code"].Value.ToString();
                            feedtypemain.Text = Dgvmain.CurrentRow.Cells["feed_type"].Value.ToString();
                            bagbulkmain.Text = Dgvmain.CurrentRow.Cells["sack_bin"].Value.ToString();
                            uommain.Text = Dgvmain.CurrentRow.Cells["uom"].Value.ToString();
                            quantity.Text = Dgvmain.CurrentRow.Cells["qty"].Value.ToString();
                            fgdate.Text = Dgvmain.CurrentRow.Cells["Fdate"].Value.ToString();
                            productionmain.Text = Dgvmain.CurrentRow.Cells["production"].Value.ToString();
                            myfgidbulk.Text = Dgvmain.CurrentRow.Cells["myfg_id"].Value.ToString();








                        }
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtbxavailable_TextChanged(object sender, EventArgs e)
        {
            if (txtbxavailable.Text == String.Empty)
            {
                stockonhand.Text = "0";
            }
            else
            {
                stockonhand.Text = txtbxavailable.Text.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Cbfeedcode_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Cbbagbulk_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void cboCustomer_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void btnnextfg_Click(object sender, EventArgs e)
        {



            try
            {

                if (dgvfgdate.Rows.Count >= 1)
                {


                    int i = dgvfgdate.CurrentRow.Index + 1;

                    if (i >= -1 && i < dgvfgdate.Rows.Count)
                    {
                        dgvfgdate.CurrentCell = dgvfgdate.Rows[i].Cells["ProductionID"];

                        if (Cbbagbulk.Text == "BAGGING")
                        {

                            if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1nrow2.Text))
                            {

                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");

                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow3.Text))
                            {


                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow3.Text))
                                {

                                    int s = dgvfgdate.CurrentRow.Index + 1;
                                    dgvfgdate.CurrentCell = dgvfgdate.Rows[s].Cells["ProductionID"];
                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow3.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                }



                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow4.Text))
                            {


                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow4.Text))
                                {

                                    int s = dgvfgdate.CurrentRow.Index + 1;
                                    dgvfgdate.CurrentCell = dgvfgdate.Rows[s].Cells["ProductionID"];
                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row3.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");

                                    if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow4.Text))
                                    {

                                        int q = dgvfgdate.CurrentRow.Index + 1;
                                        dgvfgdate.CurrentCell = dgvfgdate.Rows[q].Cells["ProductionID"];
                                        dSet.Clear();
                                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow4.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                    }
                                }
                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                            {


                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                                {

                                    int s = dgvfgdate.CurrentRow.Index + 1;
                                    dgvfgdate.CurrentCell = dgvfgdate.Rows[s].Cells["ProductionID"];
                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row3.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");

                                    if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                                    {

                                        int q = dgvfgdate.CurrentRow.Index + 1;
                                        dgvfgdate.CurrentCell = dgvfgdate.Rows[q].Cells["ProductionID"];
                                        dSet.Clear();
                                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row4.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");

                                        if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                                        {

                                            int p = dgvfgdate.CurrentRow.Index + 1;
                                            dgvfgdate.CurrentCell = dgvfgdate.Rows[p].Cells["ProductionID"];
                                            dSet.Clear();
                                            dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow5.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                        }
                                    }
                                }
                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                            {


                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                                {

                                    int s = dgvfgdate.CurrentRow.Index + 1;
                                    dgvfgdate.CurrentCell = dgvfgdate.Rows[s].Cells["ProductionID"];
                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row3.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");

                                    if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                                    {

                                        int q = dgvfgdate.CurrentRow.Index + 1;
                                        dgvfgdate.CurrentCell = dgvfgdate.Rows[q].Cells["ProductionID"];
                                        dSet.Clear();
                                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row4.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");

                                        if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                                        {

                                            int p = dgvfgdate.CurrentRow.Index + 1;
                                            dgvfgdate.CurrentCell = dgvfgdate.Rows[p].Cells["ProductionID"];
                                            dSet.Clear();
                                            dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row5.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");

                                            if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                                            {

                                                int o = dgvfgdate.CurrentRow.Index + 1;
                                                dgvfgdate.CurrentCell = dgvfgdate.Rows[o].Cells["ProductionID"];
                                                dSet.Clear();
                                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow6.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                            }
                                        }
                                    }
                                }
                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) == Convert.ToInt32(txtbxavailable.Text))
                            {

                                int q = dgvfgdate.CurrentRow.Index - 1;
                                dgvfgdate.CurrentCell = dgvfgdate.Rows[q].Cells["ProductionID"];
                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtfgtotal.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", "", "addissue");
                                load_Moveorder();

                                if (Convert.ToInt32(lblquantitymain.Text) == Convert.ToInt32(quantityaddline.Text))
                                {

                                    return;
                                }
                                else
                                {

                                    Calldata();
                                    btnloopfg_Click(sender, e);


                                }

                            }
                        }


                        ////bulk yan
                        else
                        {
                            if (Convert.ToInt32(Txtbxquantity.Text) == Convert.ToInt32(txtbxavailable.Text))
                            {
                                //int q = dgvfgdate.CurrentRow.Index + 1;
                                //dgvfgdate.CurrentCell = dgvfgdate.Rows[q].Cells["ProductionID"];
                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtfgtotal.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                load_Moveorder();


                                if (Convert.ToInt32(lblquantitymain.Text) == Convert.ToInt32(quantityaddline.Text))
                                {

                                    return;
                                }
                                else
                                {
                                    // MessageBox.Show("eku tuknang");
                                    Calldata();
                                    btnloopfg_Click(sender, e);


                                }

                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1nrow2.Text))
                            {
                                //  MessageBox.Show("kanan ,e");

                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                if (Convert.ToInt32(txtrow2.Text) == Convert.ToInt32(row2.Text))
                                {
                                    // MessageBox.Show("takla");
                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, fgidbulk.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", lblsasa.Text, "", 0, "", "", "", "showaddlinebulkissue");

                                }



                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow3.Text))
                            {


                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");


                                if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow3.Text))
                                {
                                    int u = dgvfgdate.CurrentRow.Index + 1;
                                    dgvfgdate.CurrentCell = dgvfgdate.Rows[u].Cells["ProductionID"];


                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow3.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");



                                }



                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow4.Text))
                            {

                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                load_Moveorder();
                                Queryshowmoveorderbulk();

                                if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow4.Text))
                                {

                                    int v = dgvfgdate.CurrentRow.Index + 1;
                                    dgvfgdate.CurrentCell = dgvfgdate.Rows[v].Cells["ProductionID"];
                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row3.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                    load_Moveorder();

                                    if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow4.Text))
                                    {

                                        int j = dgvfgdate.CurrentRow.Index + 1;
                                        dgvfgdate.CurrentCell = dgvfgdate.Rows[j].Cells["ProductionID"];
                                        dSet.Clear();
                                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow4.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                        load_Moveorder();



                                    }

                                }


                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                            {

                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                load_Moveorder();

                                Queryshowmoveorderbulk();

                                if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                                {
                                    int v = dgvfgdate.CurrentRow.Index + 1;
                                    dgvfgdate.CurrentCell = dgvfgdate.Rows[v].Cells["ProductionID"];
                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row3.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                    load_Moveorder();

                                    Queryshowmoveorderbulk();

                                    if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                                    {
                                        int r = dgvfgdate.CurrentRow.Index + 1;
                                        dgvfgdate.CurrentCell = dgvfgdate.Rows[r].Cells["ProductionID"];
                                        dSet.Clear();
                                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row4.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                        load_Moveorder();


                                        if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow5.Text))
                                        {
                                            int a = dgvfgdate.CurrentRow.Index + 1;
                                            dgvfgdate.CurrentCell = dgvfgdate.Rows[a].Cells["ProductionID"];
                                            dSet.Clear();
                                            dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow5.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                            load_Moveorder();

                                            //   Queryshowmoveorderbulk();

                                        }



                                    }

                                }

                            }

                            else if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                            {

                                dSet.Clear();
                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row2.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                load_Moveorder();

                                Queryshowmoveorderbulk();
                                if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                                {
                                    int v = dgvfgdate.CurrentRow.Index + 1;
                                    dgvfgdate.CurrentCell = dgvfgdate.Rows[v].Cells["ProductionID"];
                                    dSet.Clear();
                                    dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row3.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                    load_Moveorder();

                                    Queryshowmoveorderbulk();
                                    if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                                    {
                                        int r = dgvfgdate.CurrentRow.Index + 1;
                                        dgvfgdate.CurrentCell = dgvfgdate.Rows[r].Cells["ProductionID"];
                                        dSet.Clear();
                                        dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row4.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                        load_Moveorder();

                                        Queryshowmoveorderbulk();
                                        if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                                        {
                                            int a = dgvfgdate.CurrentRow.Index + 1;
                                            dgvfgdate.CurrentCell = dgvfgdate.Rows[a].Cells["ProductionID"];
                                            dSet.Clear();
                                            dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), row5.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                            load_Moveorder();


                                            if (Convert.ToInt32(Txtbxquantity.Text) <= Convert.ToInt32(row1torow6.Text))
                                            {
                                                int y = dgvfgdate.CurrentRow.Index + 1;
                                                dgvfgdate.CurrentCell = dgvfgdate.Rows[y].Cells["ProductionID"];
                                                dSet.Clear();
                                                dSet = objStorProc.rdf_sp_move_order(0, txtorder.Text.Trim(), lbldateandtime.Text.Trim(), cboWarehouse.Text.Trim(), lbldata1.Text.Trim(), cboCustomer.Text.Trim().ToString(), lbldata2.Text.Trim().ToString(), Cbfeedcode.Text.Trim(), Txtbxfeedtype.Text.Trim(), Cbbagbulk.Text.Trim(), txtfgdatetotal.Text.Trim(), txtrow6.Text.Trim(), txtuom.Text.Trim(), txtqtyreceived.Text.Trim(), txtbxavailable.Text.Trim(), txtbxavailable.Text.Trim(), txtboxprodid.Text.Trim().ToString(), lblsasa.Text.Trim(), lbldateandtime.Text.Trim(), 0, "", "", fgidbulk.Text.Trim(), "addissue");
                                                load_Moveorder();



                                            }

                                        }



                                    }

                                }

                            }
                        }
                    }

                    else
                    {


                        //load_Moveorder();
                        //load_prodid();
                        //load_fgdate();


                        return;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnloopfg_Click(object sender, EventArgs e)
        {
            btnnextfg_Click(sender, e);
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            if (quantity.Text.Trim() == string.Empty)
            {
                txtkg.Text = "";
                txtbatch.Text = "";
            }
            else
            {
                txtkg.Text = (float.Parse(quantity.Text) * 50).ToString();
                txtbatch.Text = (float.Parse(quantity.Text) / 40).ToString();

                //if(txtbatch.Text.Contains("."))
                //{
                //    txtbatch.Text = "";
                //    txtkg.Text = "";
                //}
            }
        }

      

        private void Cbfgdate_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Cleartxt();
            
            try
            {
                if (Cbbagbulk.Text.Trim() == string.Empty)
                {

                }

                if (Cbfgdate.Text.Trim() == string.Empty)

                {


                }

                else
                {


                    if (Cbbagbulk.Text == "BAGGING")
                    {
                        myglobal.global_module = "fg_inventory_bag";
                        load_fgdate();
                        //load_search2();

                      
                        load_search3();
                        load_search4();
                        Showcount();

                        Enablequantity();
                        int sum = 0;



                        for (int i = 0; i < dgvprodd.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dgvprodd.Rows[i].Cells["Total"].Value);
                        }

                        txtbxavailable.Text = sum.ToString();








                        // showProdId();
                    }

                    else
                    {

                        myglobal.global_module = "fg_inventory_bulk";
                        load_fgdatebulk();
                        //load_search2();

                        load_search4();
                        load_search3();

                        Enablequantity();

                        int sum = 0;
                        for (int i = 0; i < dgvfgdate.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dgvfgdate.Rows[i].Cells["Total_"].Value);
                        }
                        txtbxavailable.Text = sum.ToString();


                        // showProdId();


                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void toolStripSeparator5_Click(object sender, EventArgs e)
        {

        }

        private void Cbfeedcode_Click(object sender, EventArgs e)
        {
            LoadFeedcodeDropdown();
        }

        private void Cbbagbulk_Click(object sender, EventArgs e)
        {
            load_FGCategory();
            Cbbagbulk.SelectedIndex = -1;
        }

        private void Cbfgdate_Click(object sender, EventArgs e)
        {
            load_proddate();
        }

        private void FrmFGMiscellaneousFinanceIssue_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(Lblrecordss.Text=="0")
            {

            }
            else
            { 


            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to close this form? The transaction will be reset.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dSet.Clear();
                dSet = objStorProc.rdf_sp_move_order(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", lblsasa.Text, "", 0, "", "", "", "formissuebulk");

                dSet.Clear();
                dSet = objStorProc.rdf_sp_move_order(0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", lblsasa.Text, "", 0, "", "", "", "formissue");

            }


            else
            {
                e.Cancel = true;
                return;
            }

            }
        }
    }
}
